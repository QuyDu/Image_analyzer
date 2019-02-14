using Microsoft.ProjectOxford.Face.Contract;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using System.Windows.Forms;
using GetImageMetaData.Properties;
using System.Drawing.Imaging;
using System.Drawing;
using Microsoft.ProjectOxford.Face;
using System.Globalization;

namespace GetImageMetaData
{
    // Update 02/10/2019 07:45 AM
    class GenLib
    {
        private static Options _options = new Options();
        private static FrmOptions _frmOptions = new FrmOptions();
        private const long _maxImageSize = (1024 * 1024) * 4;

        public static bool CheckForInternetConnection()
        {
            
            try
            {
                using (WebClient client = new WebClient())
                {
                    using (client.OpenRead("http://www.google.com"))
                    {
                        return true;
                    }
                }
            }
            catch
            {
                return false;
            }
        }

        public static string BrowseForFolder()
        {
            string desiredPath = string.Empty;

            using (var dlg = new FolderBrowserDialog())
            {
                DialogResult result = dlg.ShowDialog();

                if (result == DialogResult.OK && !string.IsNullOrEmpty(dlg.SelectedPath))
                    desiredPath = dlg.SelectedPath;
            }

            return desiredPath;
        }

        public static bool FileIsImage(string fn)
        {
            List<string> imageExtensions = new List<string> { ".JPG", ".JPE", ".BMP", ".GIF", ".PNG" };

            return imageExtensions.Contains(Path.GetExtension(fn)?.ToUpper());
        }

        public static bool CopyFile(string sourceFn, string destFn, bool createDestDir, out string errStr)
        {
            bool blnOk = false;
            errStr = string.Empty;

            try
            {
                // create destination directory if desired
                if (createDestDir)
                    Directory.CreateDirectory(Path.GetDirectoryName(destFn) ?? throw new InvalidOperationException());

                File.Copy(sourceFn, destFn, true);
                blnOk = true;
            }
            catch (Exception ex)
            {
                errStr = $"Unhandled exception in CopyFile: {ex.Message}";
            }

            return blnOk;
        }

        public static bool IsUknownCandidate(string name)
        {
            return name.StartsWith("unidentified", StringComparison.OrdinalIgnoreCase) || name.Equals(string.Empty);
        }

        public static async Task CreatePersonGroupIfNeededAsync(string userData = null)
        {
            //await _options.UpdateMemberVarsFromProperties();
            string personGroupID = _options.PersonGroupId;
            string personGroupDN = string.Empty;
            if (!string.IsNullOrWhiteSpace(personGroupID))
            {
                try
                {
                    await _options._faceServiceClient.GetPersonGroupAsync(personGroupID);            
                }
                catch (Exception)
                {
                    //MessageBox.Show($@"Cannot find a person group with id '{_options.PersonGroupId}'.  Attempting to create it.");
                    try
                    {
                        // person group does not exist - create it
                        await _options._faceServiceClient.CreatePersonGroupAsync(personGroupID,
                            _options._personGroupDisplayName, userData);
                        // person group now needs to be trained
                        await TrainPersonGroup(personGroupID);

                        MessageBox.Show($@"The PersonGroup'{personGroupID}' has been created and Trained and is now ready to use");
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show($@"Error creating person group '{personGroupID}': {ex.Message}");
                    }
                }

            }
            else
            {
            //    MessageBox.Show($@"Please Select or Create a new Person Group by either 
            //1. Using the Drop Down Menu to Select a PersonGroup that has already been Created and saved in the Current FACE API.
            //    or 
            //2. In the Space available Type in name for a new PeronGroup to be created.
            //note: PersonGroups should be typed lower case with no spaces");
            }

        }

        public static async Task TrainPersonGroup(string personGroupID)
        {
            await _options._faceServiceClient.TrainPersonGroupAsync(personGroupID);
        }

        public static async Task DeletePersonGroupAsync(string personGroup)
        {

            if (MessageBox.Show($"Are you sure you want to delete group '{personGroup}'?", "Confirmation", MessageBoxButtons.OKCancel) == DialogResult.OK)
            {
                await _options._faceServiceClient.DeletePersonGroupAsync(personGroup);
                Settings.Default.personGroupID = null;
                await _options.UpdateMemberVarsFromProperties();
            }
        }

        private static ImageCodecInfo GetEncoder(ImageFormat format)
        {
            ImageCodecInfo[] codecs = ImageCodecInfo.GetImageDecoders();
            return codecs.FirstOrDefault(codec => codec.FormatID == format.Guid);
        }

        public static Stream ConvertAndCompressImageFileToStream(string imageFilePath, long maxImageSize, out string errStr)
        {
            return ConvertAndCompressImageFileToStream(Image.FromFile(imageFilePath), maxImageSize, out errStr);
        }

        public static Stream ConvertAndCompressImageFileToStream(Image img, long maxImageSize, out string errStr)
        {
            Stream imgStream = null;
            errStr = "";
            EncoderParameters parameters = new EncoderParameters(1);
            int quality = 110;

            //if (new System.IO.FileInfo(imageFilePath).Length > MaxImageSize)
            //{
            // loop through, each time compressing more and more until we get a stream <= max size
            if (img != null)
            {
                try
                {
                    do
                    {
                        quality -= 10;
                        imgStream = new MemoryStream();
                        parameters.Param[0] = new EncoderParameter(System.Drawing.Imaging.Encoder.Quality, quality);
                        img.Save(imgStream, GetEncoder(ImageFormat.Jpeg), parameters);
                    } while (imgStream.Length > maxImageSize && quality > 0);

                    if (quality > 0)
                    {
                        // we were able to compress or leave as is to reach size < max
                        imgStream.Seek(0, SeekOrigin.Begin);
                    }
                    else
                        // we were unable to compress small enough - abort
                        imgStream = null;
                }
                catch (Exception ex)
                {
                    errStr = $"Exception in convertAndCompressImageFileToStream: {ex.Message}";
                }
            }
            else
                imgStream = null;

            return imgStream;
        }

        public static string GetValueAsString(string value)
        {
            if (!string.IsNullOrWhiteSpace(value))
            {
                return value;
            }
            return string.Empty;
        }

        public static string GetValueAsString(string value, string defaultValue)
        {
            if (!string.IsNullOrWhiteSpace(value))
            {
                return value;
            }
            return defaultValue;
        }

        public static async Task<PersonGroup[]> GetPersonGroups()
        {
            PersonGroup[] personGroups = null;
            if (!string.IsNullOrWhiteSpace(_options.CSKey))
            {
                personGroups = await _options._faceServiceClient.ListPersonGroupsAsync(_options.CSKey);
            }

            return personGroups;
        }

        public static async Task UpdatePersonGroupList()
        {
            await _options.UpdateMemberVarsFromProperties();
            PersonGroup[] personGroups = Array.Empty<PersonGroup>();

            //Task: Clean up this dont make sense
            if (string.IsNullOrWhiteSpace(_options.CSKey))
            {
                if (!string.IsNullOrWhiteSpace(_options.CSKey) && !string.IsNullOrWhiteSpace(_options.FaceEndpoint))
                {
                    string faceKey = _options.CSKey;
                    string faceEnd = _options.FaceEndpoint;
                    FaceServiceClient faceClient = _options._faceServiceClient;
                    personGroups = await faceClient.ListPersonGroupsAsync(faceKey);
                }
            }
            else
            {
                personGroups = await _options._faceServiceClient.ListPersonGroupsAsync(_options.CSKey);
            }
            _frmOptions.cmbPersonGroups.SelectedText = string.Empty;
            _frmOptions.cmbPersonGroups.Items.Clear();
            _frmOptions.cmbPersonGroups.Items.Add(string.Empty);
            for (var i = 0; i < personGroups.Length; i++)
            {
                PersonGroup personGroup = personGroups[i];
                _frmOptions.cmbPersonGroups.Items.Add(personGroup.PersonGroupId);
            }
            _frmOptions.cmbPersonGroups.Refresh();
        }
        public static async Task<string> AddFace(string faceImageFn, string personName, string groupId, string groupDisplayName)
        {
            return await AddFace(new MemoryStream(File.ReadAllBytes(faceImageFn)), personName, groupId, groupDisplayName);
        }
        public static async Task<string> AddFace(MemoryStream faceStream, string personName, string groupId, string groupDisplayName, bool showMsgBox = true)
        {
            string statusStr;

            try
            {
                // Does PersonGroup already exist
                try
                {
                     await _options._faceServiceClient.GetPersonGroupAsync(groupId);
                }
                catch (Exception)
                {
                    // person group does not exist - create it
                    await _options._faceServiceClient.CreatePersonGroupAsync(groupId, groupDisplayName);

                    // FIX there needs to be a wait or something to detect the new personGroup
                    await _options._faceServiceClient.GetPersonGroupAsync(groupId);
                }
                //Get list of faces if any
                Person[] people = await _options._faceServiceClient.ListPersonsAsync(groupId);
                Person p = people.FirstOrDefault(myP => myP.Name.Equals(personName, StringComparison.OrdinalIgnoreCase));
                Guid personId;
                if (p != null)
                {
                    // person already exists - train our model to include new picture
                    personId = p.PersonId;
                }
                else
                {
                    // personGroupId is the group to add the person to, personName is what the user typed in to identify this face
                    CreatePersonResult myPerson = await _options._faceServiceClient.CreatePersonAsync(groupId, personName);
                    personId = myPerson.PersonId;
                }
                // Person - List Persons in a Person Group
                // Detect faces in the image and add
                await _options._faceServiceClient.AddPersonFaceAsync(groupId, personId, faceStream);

                // whenever we add a face, docs says we need to retrain - do it!

                //await retrainPersonGroup(_options.PersonGroupId);

                //// I think this is needed
                await _options._faceServiceClient.TrainPersonGroupAsync(groupId);

                while (true)
                {
                    TrainingStatus trainingStatus = await _options._faceServiceClient.GetPersonGroupTrainingStatusAsync(groupId);

                    if (trainingStatus.Status != Status.Running) break;

                    await Task.Delay(1000);
                }

                statusStr = $@"A new face with name '{personName}' has been added and / or trained successfully in the personGroup '{groupId}'";

                //await UpdatePersonListAsync();
                //await _frmMain.UpdatePersonListAsync();

            }
            catch (Exception ex)
            {
                statusStr = $@"Unhandled excpetion while trying to add face: {ex.Message}";
            }

            if (showMsgBox) MessageBox.Show(statusStr);
            return statusStr;
        }

        public static byte[] ImageToByte(Image img)
        {
            ImageConverter converter = new ImageConverter();
            return (byte[])converter.ConvertTo(img, typeof(byte[]));
        }

        public static async Task<EnhancedFace[]> DetectFaces(string imageFilePath)
        {
            MemoryStream imageStream = new MemoryStream(File.ReadAllBytes(imageFilePath));
            return await GenLib.DetectFaces(imageStream);
        }

        public static async Task<EnhancedFace[]> DetectFaces(Image img)
        {
            string errStr = string.Empty;
            MemoryStream imageStream = new MemoryStream();
            img.Save(imageStream, ImageFormat.Png);
            imageStream.Seek(0, SeekOrigin.Begin);
            if (imageStream.Length < (_maxImageSize - 1))
            {
                return await DetectFaces(imageStream);
            }
            else
            {
                Stream fixedStream = ConvertAndCompressImageFileToStream(img, _maxImageSize, out errStr);
                MemoryStream imageStream2 = new MemoryStream();
                fixedStream.CopyTo(imageStream2);
                imageStream2.Seek(0, SeekOrigin.Begin);

                return await DetectFaces(imageStream2);
            }
        }

        public static async Task<EnhancedFace[]> DetectFaces(MemoryStream imageStream)
        {
            bool getFaceLandmarks = false;
            // Submit image to API. 
            List<FaceAttributeType> faceAttr = new List<FaceAttributeType>
            {
                FaceAttributeType.Accessories,
                FaceAttributeType.Age,
                FaceAttributeType.Blur,
                FaceAttributeType.Emotion,
                FaceAttributeType.Exposure,
                FaceAttributeType.FacialHair,
                FaceAttributeType.Gender,
                FaceAttributeType.Glasses,
                FaceAttributeType.Hair,
                FaceAttributeType.HeadPose,
                FaceAttributeType.Makeup,
                FaceAttributeType.Noise,
                FaceAttributeType.Occlusion,
                FaceAttributeType.Smile
            };

            Face[] faces = await _options._faceServiceClient.DetectAsync(imageStream, true, getFaceLandmarks, returnFaceAttributes: faceAttr);

            // if getFaceLandMarks is true , you can get data like faces[0].FaceLandmarks.NoseRootLeft
            // TASK Currently errors when
            EnhancedFace[] eFaces = new EnhancedFace[faces.Length];
            for (int index = 0; index < eFaces.Length; index++)
            {
                eFaces[index] = new EnhancedFace(faces[index], "");
            }

            return eFaces;
        }


        // return faces[] as list of chunks of 'chunkSize'
        private static List<Guid[]> getFaceIDsInChunks(EnhancedFace[] faces, int chunkSize)
        {
            List<Guid[]> faceList = new List<Guid[]>();
            for (int i = 0; i < faces.Length; i = i + chunkSize)
            {
                List<Guid> myGuids = new List<Guid>();
                for (int j = i; j < faces.Length && j - i < chunkSize; j++)
                    myGuids.Add(faces[j].FaceId);
                faceList.Add(myGuids.ToArray());
            }
            return faceList;
        }


        public static async Task<List<IdentifiedPerson>> GetCandidateNames(EnhancedFace[] faces, bool includeConfidence = true)
        {
            List<Guid[]> faceIDs = getFaceIDsInChunks(faces, 10);
            // see https://westus.dev.cognitive.microsoft.com/docs/services/563879b61984550e40cbbe8d/operations/563879b61984550f30395239/console

            //Guid[] faceIds = faces.Select(face => face.FaceId).ToArray();
            PersonGroup[] personGroups = Array.Empty<PersonGroup>();
            personGroups = await GenLib.GetPersonGroups();
            List<string> namesFound = new List<string>();
            IdentifyResult[] results;
            List<IdentifiedPerson> groupInfo = new List<IdentifiedPerson>();

            int index = 0;
            foreach (PersonGroup personGroup in personGroups)
            {
                try
                {
                    foreach (Guid[] faceArray in faceIDs)
                    {
                        results = await _options._faceServiceClient.IdentifyAsync(personGroup.PersonGroupId, faceArray);
                        foreach (IdentifyResult identifyResult in results)
                        {
                            //string name;
                            if (identifyResult.Candidates.Length > 0)
                            {
                                // we found at least one person whose face belongs in this group 
                                Person person;

                                // Get top 1 among all candidates returned...Gets the best match for each face ID in the white list and adds it to the List
                                Guid candidateId = identifyResult.Candidates[0].PersonId;
                                person = await _options._faceServiceClient.GetPersonAsync(personGroup.PersonGroupId, candidateId);

                                string personName = person?.Name ?? "Unknown";
                                string name = includeConfidence ? $"{personName} ({identifyResult.Candidates[0].Confidence.ToString(CultureInfo.InvariantCulture)})" : personName;

                                // add entry to our dictionary
                                groupInfo.Add(new IdentifiedPerson() { GroupName = personGroup.PersonGroupId, FaceID = identifyResult.FaceId, PersonName = name });
                                namesFound.Add(name);

                                // todo: clean this up so that linq is used with the where clause, and firstOrDefault to set the candidateName of the found face
                                foreach (EnhancedFace face in faces)
                                {
                                    if (face.FaceId.Equals(identifyResult.FaceId))
                                    {
                                        face.CandidateName = name;
                                    }
                                }

                                index++;
                            }
                            else
                            {
                                // Unable to idenitify a person from a face within a personGroup
                            }
                        } // for each result that was identified from the face array
                    } // for each array in our faceID list
                } // try
                catch (Exception ex)
                {
                    MessageBox.Show($"Unhandled exception in GetCandidateNames: {ex.Message}");
                }
            } // for each person in the group

            // TASK I believe this is where we need to add the method to add the "unidentified" face to the "unknown" personGroup
            //string personGroupId = "unknown";
            //string persongGrupDN = "Unidentified People";
            //string initialDate = DateTime.Now.ToString();
            //string personName = $"Unknown '{initialDate}'.";
            //// possibly use function from addface to create personGroup if needed

            return groupInfo;
        }


    } // class
} // namespace

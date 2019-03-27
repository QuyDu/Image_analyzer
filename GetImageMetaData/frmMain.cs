using GetImageMetaData.Properties;
using Microsoft.ProjectOxford.Face;
using Microsoft.ProjectOxford.Face.Contract;
using Microsoft.ProjectOxford.Vision;
using Microsoft.ProjectOxford.Vision.Contract;
using Newtonsoft.Json;
using OpenCvSharp;
using OpenCvSharp.Extensions;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using Color = System.Drawing.Color;
using Face = Microsoft.ProjectOxford.Face.Contract.Face;
using FaceRectangle = Microsoft.ProjectOxford.Face.Contract.FaceRectangle;
using MessageBox = System.Windows.Forms.MessageBox;
using Point = System.Drawing.Point;
using Rect = OpenCvSharp.Rect;
using Rectangle = System.Drawing.Rectangle;
using Size = System.Drawing.Size;

namespace GetImageMetaData
{
    // Update 03/23/2019 11:30 AM
    public partial class FrmMain : Form
    {
        #region Inital Values
        private enum EMediaType
        {
            Image,
            Video,
            Camera,
            Web,
            Doc,
            Unknown
        }

        private static readonly ImageEncodingParam[] SJpegParams =
        {
            new ImageEncodingParam(ImwriteFlags.JpegQuality, 60)
        };

        private Options _options = new Options();
        // then you really shouuld add a load/save method to the Options class and call at the beginning of frmMain _options.Load();
        // then refer to the option params inside using _options.xxxxx

        private readonly object _lockObj = new object();
        private int _rotateDegrees = 0;
        private string _ext;
        private bool _cameraModeAuto; // true if camera analysis is happening automatically
        //private string _personGroupDisplayName;  

        public ObservableCollection<LiveCameraResult> _totalApiResults = new ObservableCollection<LiveCameraResult>();
        public LiveCameraResult _apiResult { get; set; }
        public event PropertyChangedEventHandler _propertyChanged;

        private EnhancedFace[] _detectedFaces;
        private FrameGrabber<LiveCameraResult> _grabber = new FrameGrabber<LiveCameraResult>();
        private readonly object _itemsLock = new object();
        private readonly CascadeClassifier _localFaceDetector = new CascadeClassifier();
        private DateTime _startTime;

        // our active group/person vars
        private List<string> _personsInActiveGroup = new List<string>();

        //private readonly Log _analysisLog = new Log();
        private readonly ImageEncodingParam[] _sJpegParams =
        {
            new ImageEncodingParam(ImwriteFlags.JpegQuality, 60)
        };

        // constants
        private const string API_METHOD = "analyze";
        private const long MAX_IMAGE_SIZE = (1024 * 1024) * 4;
        private readonly string[] IMAGE_TYPES = {"png", "jpg", "gif", "bmp"};
        private readonly string[] VIDEO_TYPES = {"mp4", "ts", "h264", "avi", "mpg", "mov"};
        private readonly string[] DOC_TYPES = { "doc", "docx", "pdf", "txt"};
        private readonly string[] WEBSITE_SUFFIXES = {"com", "net", "org", "gov" };
        
        #endregion

        public FrmMain()
        {
            InitializeComponent();
        }

        #region Functions
        /// <summary> Function which submits a frame to the Face API. </summary>
        /// <param name="frame"> The video frame to submit. </param>
        /// <returns>
        ///     A <see cref="Task{LiveCameraResult}" /> representing the asynchronous API call,
        ///     and containing the faces returned by the API.
        /// </returns>

        private async void Form1_ShownAsync(object sender, EventArgs e)
        {
            await _options.UpdateMemberVarsFromProperties();
            bool Internet = _options.Internet;
            bool containerMode = _options.ContainerMode;
            bool PersonGroupExist = _options.personGroupFound;
            string CSKey = _options.CSKey;
            string CSEndpoint = _options.CSEndpoint;
            string PersonGroupId = _options.PersonGroupId;
            string msgType1 = "First";
            string msgType2 = "PersonGroups";
            string msgType3 = "PersonGroups";
            string msgType4 = "Internet";

            FaceServiceClient faceClient = _options._faceServiceClient;

            BuildSourceList();
            if (cmbSource.Items.Count > 0)
                cmbSource.SelectedIndex = 0;

            if (string.IsNullOrWhiteSpace(CSKey) || string.IsNullOrWhiteSpace(CSEndpoint))
            {
                MessageBox.Show(GenLib.SetMessage(msgType1, string.Empty, string.Empty, null));
                new FrmOptions().ShowDialog();

                // after options is closed update with new values
                await _options.UpdateMemberVarsFromProperties();
                Internet = _options.Internet;
                containerMode = _options.ContainerMode;
                PersonGroupExist = _options.personGroupFound;
                CSKey = _options.CSKey;
                CSEndpoint = _options.CSEndpoint;
                PersonGroupId = _options.PersonGroupId;
                faceClient = _options._faceServiceClient;

                if (!string.IsNullOrWhiteSpace(CSKey) && !string.IsNullOrWhiteSpace(CSEndpoint))
                {
                    await GenLib.UpdatePersonGroupList(CSKey, CSEndpoint, faceClient);
                    if (!string.IsNullOrWhiteSpace(PersonGroupId))
                    {
                        await UpdatePersonListAsync(PersonGroupId, PersonGroupExist);
                    }
                    else
                    {
                        MessageBox.Show(GenLib.SetMessage(msgType2, string.Empty, string.Empty, null));
                    }
                }
            }
            else
            {
                if (!containerMode)
                {
                    if (Internet)
                    {
                        await GenLib.UpdatePersonGroupList(CSKey, CSEndpoint, faceClient);

                        if (!string.IsNullOrWhiteSpace(PersonGroupId))
                        {
                            await UpdatePersonListAsync(PersonGroupId, PersonGroupExist);
                        }
                        else
                        {
                            MessageBox.Show(GenLib.SetMessage(msgType3, string.Empty, string.Empty, null));
                            new FrmOptions().ShowDialog();
                        }
                    }
                    else // no internet
                    {
                        MessageBox.Show(GenLib.SetMessage(msgType4, string.Empty, string.Empty, null));
                    }
                }
                else // ContainerMode is set to true
                {

                }
            }
        }

        private async void OptionsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            string msgType1 = "First";
            new FrmOptions().ShowDialog();
            //Below code updates after exiting options menu
            await _options.UpdateMemberVarsFromProperties();
            // TASK update to include if values are removed from options
            if (string.IsNullOrWhiteSpace(_options.CSKey) || string.IsNullOrWhiteSpace(_options.CSEndpoint))
            {
                MessageBox.Show(GenLib.SetMessage(msgType1, string.Empty, string.Empty, null));
            }
            else
            {
                await GenLib.UpdatePersonGroupList(_options.CSKey, _options.FaceEndpoint, _options._faceServiceClient);
                await UpdatePersonListAsync(_options.groupID, _options.personGroupFound);
            }

        }

        public async Task TrainPersonGroup(string groupID)
        {
            // The PersonGroup must be trained before an identification can be performed using it. 
            //Moreover, it has to be retrained after adding or removing any person, or if any person has their registered face edited. 
            //The training is done by the PersonGroup – Train API. When using the client library, it is simply a call to the TrainPersonGroupAsync method:
            await _options._faceServiceClient.TrainPersonGroupAsync(groupID);
        }

        public async Task GetTrainingStatus(string groupID)
        {
            await _options._faceServiceClient.GetPersonGroupTrainingStatusAsync(groupID);
        }

        public async Task<Tuple<string, AnalysisResult>> MakeAnalysisRequest(Image workImage)
        {
            AnalysisResult analysisResult = null;

            string errStr = string.Empty;
            //
            // Analyze the image for all visual features
            //
            Stream imageFileStream = GenLib.ConvertAndCompressImageFileToStream(workImage, MAX_IMAGE_SIZE, out errStr);
            if (imageFileStream != null)
            {
                // we were able to convert image file to stream ok - continue
                try
                {
                    VisualFeature[] visualFeatures = {
                        VisualFeature.Adult, VisualFeature.Categories, VisualFeature.Color, VisualFeature.Description,
                        VisualFeature.Faces, VisualFeature.ImageType, VisualFeature.Tags,
                    };
                    analysisResult = await _options._visionServiceClient.AnalyzeImageAsync(imageFileStream, visualFeatures);
                }
                catch (Microsoft.ProjectOxford.Vision.ClientException e)
                {
                    errStr = e.Error.Message;
                }
            }
            else
                errStr = $@"Cannot convert image to stream - image size must be <= {MAX_IMAGE_SIZE} bytes; {errStr}";

            return Tuple.Create(errStr, analysisResult);
        }

        public async Task UpdatePersonListAsync()
        {
            await _options.UpdateMemberVarsFromProperties();
            await UpdatePersonListAsync(string.Empty, _options.personGroupFound);
        }

        public async Task UpdatePersonListAsync(string groupID, bool personGroupExist)
        {
            if (personGroupExist)
            {
                try
                {
                    Person[] people = Array.Empty<Person>();
                    string personGroupId = !string.IsNullOrWhiteSpace(groupID) ? groupID :
                        !string.IsNullOrWhiteSpace(_options.PersonGroupId) ? _options.PersonGroupId : string.Empty;

                    people = await _options._faceServiceClient.ListPersonsAsync(personGroupId);
                    _personsInActiveGroup.Clear();

                    for (int i = 0; i < people.Length; i++)
                    {
                        _personsInActiveGroup.Add(people[i].Name);
                    }

                    if (_personsInActiveGroup.Count == 0)
                    {
                        MessageBox.Show(GenLib.SetMessage("UpdatePersonList", personGroupId, string.Empty, null));           
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show($@"Unhandled exception in updatePersonList: {ex.Message}");
                }
            }
        }

        #region ResizeImage code
        private static void ResizeImage(Bitmap image, int canvasWidth, int canvasHeight,
                     /* new */
                     int originalWidth, int originalHeight, out Bitmap resizedImage)
        {
            System.Drawing.Image thumbnail =
                new Bitmap(canvasWidth, canvasHeight); // changed parm names
            System.Drawing.Graphics graphic =
                         System.Drawing.Graphics.FromImage(thumbnail);

            graphic.InterpolationMode = InterpolationMode.HighQualityBicubic;
            graphic.SmoothingMode = SmoothingMode.HighQuality;
            graphic.PixelOffsetMode = PixelOffsetMode.HighQuality;
            graphic.CompositingQuality = CompositingQuality.HighQuality;

            /* ------------------ new code --------------- */

            // Figure out the ratio
            double ratioX = (double)canvasWidth / (double)originalWidth;
            double ratioY = (double)canvasHeight / (double)originalHeight;
            // use whichever multiplier is smaller
            double ratio = ratioX < ratioY ? ratioX : ratioY;

            // now we can get the new height and width
            int newHeight = Convert.ToInt32(originalHeight * ratio);
            int newWidth = Convert.ToInt32(originalWidth * ratio);

            // Now calculate the X,Y position of the upper-left corner 
            // (one of these will always be zero)
            int posX = Convert.ToInt32((canvasWidth - (originalWidth * ratio)) / 2);
            int posY = Convert.ToInt32((canvasHeight - (originalHeight * ratio)) / 2);

            graphic.Clear(Color.White); // white padding
            graphic.DrawImage(image, posX, posY, newWidth, newHeight);

            /* ------------- end new code ---------------- */

            System.Drawing.Imaging.ImageCodecInfo[] info =
                             ImageCodecInfo.GetImageEncoders();
            //var encoderParameters = new EncoderParameters(1);
            //encoderParameters.Param[0] = new EncoderParameter(Encoder.Quality,
            //                 100L);

            //thumbnail.Save(path + newWidth + "." + originalFilename, info[1],
            //                 encoderParameters);

            resizedImage = (Bitmap)thumbnail;
        }

        private static void ResizeImage(string originalFilename,
                     /* note changed names */
                     int canvasWidth, int canvasHeight,
                     /* new */
                     int originalWidth, int originalHeight, out Bitmap resizedImage)
        {
            Image image = Image.FromFile(originalFilename);
            //Image image = Image.FromFile(txtPicFilename);
            System.Drawing.Image thumbnail =
                new Bitmap(canvasWidth, canvasHeight); // changed parm names
            System.Drawing.Graphics graphic =
                         System.Drawing.Graphics.FromImage(thumbnail);

            graphic.InterpolationMode = InterpolationMode.HighQualityBicubic;
            graphic.SmoothingMode = SmoothingMode.HighQuality;
            graphic.PixelOffsetMode = PixelOffsetMode.HighQuality;
            graphic.CompositingQuality = CompositingQuality.HighQuality;

            /* ------------------ new code --------------- */

            // Figure out the ratio
            double ratioX = (double)canvasWidth / (double)originalWidth;
            double ratioY = (double)canvasHeight / (double)originalHeight;
            // use whichever multiplier is smaller
            double ratio = ratioX < ratioY ? ratioX : ratioY;

            // now we can get the new height and width
            int newHeight = Convert.ToInt32(originalHeight * ratio);
            int newWidth = Convert.ToInt32(originalWidth * ratio);

            // Now calculate the X,Y position of the upper-left corner 
            // (one of these will always be zero)
            int posX = Convert.ToInt32((canvasWidth - (originalWidth * ratio)) / 2);
            int posY = Convert.ToInt32((canvasHeight - (originalHeight * ratio)) / 2);

            graphic.Clear(Color.White); // white padding
            graphic.DrawImage(image, posX, posY, newWidth, newHeight);

            /* ------------- end new code ---------------- */

            System.Drawing.Imaging.ImageCodecInfo[] info =
                             ImageCodecInfo.GetImageEncoders();
            //var encoderParameters = new EncoderParameters(1);
            //encoderParameters.Param[0] = new EncoderParameter(Encoder.Quality,
            //                 100L);

            //thumbnail.Save(path + newWidth + "." + originalFilename, info[1],
            //                 encoderParameters);

            resizedImage = (Bitmap) thumbnail;
        }


        #endregion

        #endregion

        #region HelperFunctions

        public async Task HighlightFacesAsync(Image workImage, EnhancedFace[] faces, List<IdentifiedPerson> identified)
        {

            SolidBrush unknownFaceBrush  = new SolidBrush(Color.FromArgb(200, Color.Orange));
            SolidBrush whiteListFaceBrush  = new SolidBrush(Color.FromArgb(200, Color.Green));
            SolidBrush unknownButSeenBefore = new SolidBrush(Color.FromArgb(200, Color.Yellow));
            SolidBrush currentBrush;

            int faceSeq = 0;

            if (faces.Length <= 0) return;

            using (Graphics g = Graphics.FromImage(workImage))
            {
                foreach (EnhancedFace face in faces)
                {
                    Guid fi = face.FaceId;
                    FaceRectangle fr = face.FaceRectangle;
                    FaceAttributes fa = face.FaceAttributes;
                    FaceLandmarks fl = face.FaceLandmarks;
                    string fn = face.CandidateName;

                    string destFn = $@"{Path.GetTempPath()}\face{faceSeq}.png";

                    currentBrush = unknownFaceBrush;

                    foreach (IdentifiedPerson identity in identified)
                    {
                        if (identity.FaceID.Equals(face.FaceId))
                        {
                            string groupId = identity.GroupName.ToString();

                            try
                            {
                                PersonGroup groupInfo = await _options._faceServiceClient.GetPersonGroupAsync(groupId);

                                string userData = groupInfo.UserData;
                                int argb = 0;

                                if (!string.IsNullOrWhiteSpace(userData))
                                {
                                    if (int.TryParse(userData, out argb))
                                    {
                                        argb = Convert.ToInt32(userData);
                                    }
                                    else
                                    {
                                        argb = -16744448;
                                    }
                                    currentBrush = new SolidBrush(Color.FromArgb(argb));
                                }
                            }
                            catch
                            {
                                int milliseconds = 2000;

                                Thread.Sleep(milliseconds);

                                PersonGroup groupInfo = await _options._faceServiceClient.GetPersonGroupAsync(groupId);

                                string userData = groupInfo.UserData;
                                int argb = 0;

                                if (!string.IsNullOrWhiteSpace(userData))
                                {
                                    if (int.TryParse(userData, out argb))
                                    {
                                        argb = Convert.ToInt32(userData);
                                    }
                                    else
                                    {
                                        argb = -16744448;
                                    }
                                    currentBrush = new SolidBrush(Color.FromArgb(argb));
                                }
                            }
                        }
                    }

                    // save off individual face as a separate jpg so we can add face later
                    CropImage((Bitmap)workImage, fr.Left, fr.Top, fr.Width, fr.Height, destFn);
                    // Get original face image (color) to overlap the grayed image
                    Rectangle faceRect = new Rectangle(fr.Left, fr.Top, fr.Width, fr.Height);

                    g.DrawRectangle(new Pen(currentBrush) { Width = 8 }, faceRect);

                    #region Used to Draw Rectangle Above or below the Face Rectangle and display Person Detail
                    // Calculate where to position the detail rectangle
                    //var rectTop = fr.Top + fr.Height + 10;
                    //if (rectTop + 45 > faceBitmap.Height) rectTop = fr.Top - 30;

                    //// Draw detail rectangle and write face informations                     
                    //g.FillRectangle(currentBrush, fr.Left - 10, rectTop, fr.Width < 120 ? 120 : fr.Width + 20, 25);
                    // Defined Person info for detected face to be displayed under Face Rectangle
                    //g.DrawString($"{fa.Gender} - {(GenLib.IsUknownCandidate(face.CandidateName) ? "" : face.CandidateName + " - ")} {fa.Age:0.0}",
                    //    new Font("Arial", 32, FontStyle.Bold), Brushes.White,
                    //    fr.Left - 8,
                    //    rectTop + 4);
                    #endregion

                    faceSeq++;
                }
            }

            SetResultImage(workImage);
        } // highlightFaces

        public void CropImage(Bitmap origBitmap, int x, int y, int width, int height, string destFn)
        {
            // Here we capture the resource - image file.
            Rectangle crop = new Rectangle(x, y, width, height);

            // Here we capture another resource.
            Bitmap croppedImage = origBitmap.Clone(crop, origBitmap.PixelFormat);


            // At this point the file on disk already free - you can record to the same path.
            croppedImage.Save(destFn, ImageFormat.Jpeg);

            // It is desirable release this resource too.
            croppedImage.Dispose();
        }
        public byte[] GetImageAsByteArray(string imageFilePath)
        {
            FileStream fileStream = new FileStream(imageFilePath, FileMode.Open, FileAccess.Read);
            BinaryReader binaryReader = new BinaryReader(fileStream);
            return binaryReader.ReadBytes((int)fileStream.Length);
        }

        private async Task<AnalysisResult> AnalyzeImage()
        {
            // TASK maybe reconsider the source of the image to be analyzed , 
            // currently the image being sent to the vision API has be scaled to fit to window
            Image workImage = (Image)GetResultImage().Clone();
            //Image workImage = txtPicFilename;
            string CSKey = _options.CSKey;
            FaceServiceClient faceClient = _options._faceServiceClient;
            PersonGroup[] personGroups = Array.Empty<PersonGroup>();
            personGroups = await GenLib.GetPersonGroups(CSKey, faceClient);

            //uncumment below for testing

            //comment below out for testing
            Tuple<string, AnalysisResult> result = await MakeAnalysisRequest(workImage);
            if (!result.Equals(null))
            {
                // check if vision API failed in some way
                if (string.IsNullOrEmpty(result.Item1)) // (result.JsonObj.code == null)
                {
                    picPreview.BeginInvoke((Action)(async () =>
                    {
                    // we have no errors - show all results from vision API inside of our left tall textbox
                    txtResults.Text = ResultToStr(result.Item2);

                    //QUESTION: For some reason it may be possible that result.Item2.Description.Captions[0].Text; yields no valid value even though the image contains metadata.

                    // extract description from result and show in textbox
                    txtDescription.Text = result.Item2.Description.Captions.Any() ? result.Item2.Description.Captions[0].Text : @"No Description can be found";

                    // see if we detect any known faces
                    // Question : This seems to be the cause of the issue
                    //var detectedFaces = await DetectFaces(picView.Image);
                    Size size = workImage.Size;
                    EnhancedFace[] detectedFaces = await GenLib.DetectFaces(workImage, faceClient);

                    // save off our detected faces so that we can use it for our tooltip
                    _detectedFaces = detectedFaces;
                    picViewResult.ContextMenuStrip = _detectedFaces.Any() ? contextMenuStrip1 : null;

                    // Does detectedFaces array contain at least one entry
                    if (detectedFaces.Any())
                    {
                        // TASK error with https://chainimage.com/images/large-group-of-happy-people-standing-together.jpg
                        List<IdentifiedPerson> identified = await GenLib.GetCandidateNames(detectedFaces, personGroups, faceClient);
                        txtFaceNames.Text = detectedFaces.Any()
                            ? string.Join(", ", identified.Select(c => $"{c.PersonName} ({c.GroupName})"))
                            : "unknown";
                            try
                            {
                                await HighlightFacesAsync(workImage, detectedFaces, identified);
                            }
                            catch
                            {
                                
                                //MessageBox.Show(@"Rate Limit has been exceeded, try again later");
                            }
                    }
                    else
                    {
                        txtFaceNames.Text = $@"Face not Detected";
                    }
                    

                    }));
                }
                else
                {
                    // image size invalid - do something if necessary
                    txtFaceNames.Clear();
                    txtDescription.Clear();
                    txtResults.Text = result.Item1;
                }
            }
            else
                txtFaceNames.Text = $@"Face not Detected";

            return result.Item2;
        }


        private void LogInfo(string msg)
        {
            lstLog.Items.Add(msg);
            statusLabel.Text = msg;
            lstLog.SelectedIndex = lstLog.Items.Count - 1;
        }

        private void LogErr(string msg)
        {
            LogInfo("ERR: " + msg);
        }

        private void UpdateStatus(string msg)
        {
            statusLabel.Text = msg;
        }

        private void CmdRotateImg_Click(object sender, EventArgs e)
        {
            //var filePath = txtPicFilename.Text;
            //RotateImage(Image.FromFile(filePath));
            var curImg = Image.FromFile(txtPicFilename.Text); // GetResultImage();

            _rotateDegrees = (_rotateDegrees + 90) % 360;
            RotateImage(curImg, _rotateDegrees);
        }
        public Image RotateImage(Image img, int degrees)
        {
            RotateFlipType rotateType;

            //int rotateCount = +-1;
            var bmp = new Bitmap(img);
            using (Graphics gfx = Graphics.FromImage(bmp))
            {
                gfx.Clear(Color.White);
                gfx.DrawImage(img, 0, 0, img.Width, img.Height);
            }
            
            switch (degrees)
            {
                case 90: rotateType = RotateFlipType.Rotate90FlipX; break;
                case 180: rotateType = RotateFlipType.Rotate180FlipX; break;
                case 270: rotateType = RotateFlipType.Rotate270FlipX; break;
                default: rotateType = RotateFlipType.RotateNoneFlipNone; break;
            }
            bmp.RotateFlip(rotateType);
            SetResultImage(PrepareImage(bmp));

            return bmp;
        }
        #endregion

        private async Task DeletePersonAsync(string personName)
        {
            await DeletePersonAsync(string.Empty, personName);
        }

        private async Task DeletePersonAsync(string faceImageFn, string personName)
        {
            string CSKey = _options.CSKey;
            FaceServiceClient faceClient = _options._faceServiceClient;
            PersonGroup[] personGroups = Array.Empty<PersonGroup>();
            personGroups = await GenLib.GetPersonGroups(CSKey, faceClient);
            List<string> namesFound = new List<string>();
            List<IdentifiedPerson> groupInfo = new List<IdentifiedPerson>();
            bool personFound = false;
            foreach (PersonGroup personGroup in personGroups)
            {
                Person[] people = await _options._faceServiceClient.ListPersonsAsync(personGroup.PersonGroupId);

                foreach (Person person in people)
                {
                    if (person.Name.Equals(personName))
                    {
                        Guid selectedPersonId = person.PersonId;
                        personFound = true;
                        if (MessageBox.Show($@"Are you sure you want to delete '{personName}' from '{personGroup.PersonGroupId}' ?", @"Confirmation", MessageBoxButtons.OKCancel) == DialogResult.OK)
                        {
                            await _options._faceServiceClient.DeletePersonFromPersonGroupAsync(personGroup.PersonGroupId, selectedPersonId);
                            // you must retrain a personGroup after any modifcation
                            await _options._faceServiceClient.TrainPersonGroupAsync(personGroup.PersonGroupId);
                        }
                    }

                } 
            }
            if (!personFound)
            {
                MessageBox.Show($@" No Person was Identified to be Deleted");
            }
   
            // Request URL
            //https://westus.api.cognitive.microsoft.com/face/v1.0/persongroups/group1/persons/23685eff-de51-4776-abb2-bb1146d0021e
            // HTTP request
            //DELETE https://westus.api.cognitive.microsoft.com/face/v1.0/persongroups/group1/persons/23685eff-de51-4776-abb2-bb1146d0021e HTTP/1.1
            //Host: westus.api.cognitive.microsoft.com
            //Ocp - Apim - Subscription - Key: ••••••••••••••••••••••••••••••••
            // get personId for Person Name to be Deleted
            //https://westus.api.cognitive.microsoft.com/face/v1.0/persongroups/readydemo3/persons?%22Hugh%20Jackman%22
            //public async Task DeletePersonFromPersonGroupAsync(string personGroupId, Guid personId);
        }

        private void ExitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Close();
        }

        private async void CmdBrowse_ClickAsync(object sender, EventArgs e)
        {
            bool internet = _options.Internet;
            bool containerMode = _options.ContainerMode;
            string msgType4 = "Internet";

            
                txtFaceNames.Clear();
                txtDescription.Clear();
                txtResults.Clear();
                picViewResult.Image = null;

                string filePath = SetFilePath();
                _ext = GetExtension();

                bool webimage = filePath.StartsWith("www") || filePath.StartsWith("http");

                bool isDocument = DOC_TYPES.Contains(_ext);
                string source = webimage.Equals(true) ? "WEB" : isDocument.Equals(true) ? "DOC" : cmbSource.Text.ToUpper();

            if (containerMode)
            {
                switch (source)
                {
                    case "FILE":
                        var dlg = new OpenFileDialog
                        {
                            Filter = $@"jpg|*.jpg|png|*.png|bmp|*.bmp|gif|*.gif|mp4|*.mp4|mov|*.mov|ts|*.ts|h64|*.h64|avi|*.avi"
                        };
                        DialogResult result = dlg.ShowDialog();
                        if (result != DialogResult.OK) return;
                        filePath = dlg.FileName;
                        await SetPicViewAsync(filePath);

                        cmdAnalyze.Enabled = !string.IsNullOrWhiteSpace(filePath);
                        cmdRotateImg.Enabled = !string.IsNullOrWhiteSpace(filePath);
                        break;
                }
            }
            else if (internet)
            {
                switch (source)
                {
                    case "FILE":
                        var dlg = new OpenFileDialog
                        {
                            Filter = $@"jpg|*.jpg|png|*.png|bmp|*.bmp|gif|*.gif|mp4|*.mp4|mov|*.mov|ts|*.ts|h64|*.h64|avi|*.avi"
                        };
                        DialogResult result = dlg.ShowDialog();
                        if (result != DialogResult.OK) return;
                        filePath = dlg.FileName;
                        await SetPicViewAsync(filePath);

                        cmdAnalyze.Enabled = !string.IsNullOrWhiteSpace(filePath);
                        cmdRotateImg.Enabled = !string.IsNullOrWhiteSpace(filePath);
                        break;

                    case "WEB":
                        {
                            await SetPicViewAsync(filePath);
                            cmdAnalyze.Enabled = !string.IsNullOrWhiteSpace(filePath);
                        }
                        break;
                    case "DOC":
                        {
                            await SetPicViewAsync(filePath);
                            cmdAnalyze.Enabled = !string.IsNullOrWhiteSpace(filePath);
                        }
                        break;
                    default:
                        // should there be a Default action?
                        break;
                }
            }
            else
            {
                MessageBox.Show(GenLib.SetMessage(msgType4, string.Empty, string.Empty, null));
            }
        }

        private async Task<AnalysisResult> CameraAnalysisFunction(VideoFrame frame)
        {
            SetResultImage(frame.Image.ToBitmap());
            AnalysisResult result = await AnalyzeImage();
            return result;
        }

        private async Task SetPicViewAsync(string filePath)
        {
            txtPicFilename.Text = filePath;

            EMediaType imageType = GetImageType();
            byte[] imageData = null;
            MemoryStream ms;
            Bitmap imgBmp;

            switch (imageType)
            {
                
                case EMediaType.Image:
                    imageData = null;
                    //Bitmap[] imageData = null;

                    using (System.Net.WebClient wc = new System.Net.WebClient())
                        imageData = wc.DownloadData(filePath);
                    ms = new MemoryStream(imageData);
                    imgBmp = new Bitmap(ms);

                    Image selImage = PrepareImage(imgBmp);
                    SetResultImage(selImage);

                    break;

                case EMediaType.Web:
                    if (IMAGE_TYPES.Contains(_ext))
                    {
                        imageData = null;
                        //Bitmap[] imageData = null;

                        using (System.Net.WebClient wc = new System.Net.WebClient())
                        imageData = wc.DownloadData(filePath);
                        ms = new MemoryStream(imageData);
                        imgBmp = new Bitmap(ms);
                        selImage = PrepareImage(imgBmp);
                        SetResultImage(selImage);
                    }
                    break;

                case EMediaType.Doc:
                    var fileStream = new FileStream(filePath, FileMode.Open);
                    var docImage = Image.FromStream(fileStream);
                    //selImage = PrepareImage(docImage);
                    SetResultImage(docImage);
                    break;

                case EMediaType.Video:
                    var rtsp = txtPicFilename.Text;
                    InitializeCameraFeedAsync();
                    // FIX Needs to be awaited 

                    //SetResultImage();
                    await _grabber.StartProcessingCameraAsync(rtsp);
                    //picPreview = await _grabber.StartProcessingCameraAsync(rtsp);

                    // comment this function out if you don't want automatic analysis to happen - knh 9/11/2018
                    _grabber.AnalysisFunction = CameraAnalysisFunction; // AllApiFunction;
                    break;

                #region eMediaType.Unknown: - Currently not defined
                case EMediaType.Unknown:
                    // must handle this error later
                    break;
                    #endregion
            }
        }

        private Image PrepareImage(string fileName)
        {
            Image selImage = Image.FromFile(fileName);
            int pvHeight = picViewResult.Size.Height;
            int pvWidth = picViewResult.Size.Width;
            int selImageHeight = selImage.Size.Height;
            int selImageWidth = selImage.Size.Width;
            bool selImageToohigh = selImageHeight > pvHeight;
            bool selImageTooWide = selImageWidth > pvWidth;

            if (selImageToohigh || selImageTooWide) // Image Height is bigger than the Pic Window Height
            {
                // only Image Height is bigger than the Pic Window Height
                //picView.Image = resizedImage; // Updated code here to  reflect resizeing
                ResizeImage(fileName, pvWidth, pvHeight, selImageWidth, selImageHeight, out var resizedImage);

                //Bitmap resizedImage 

                return resizedImage;
            }
            else // image fits within Pic View
            {
                return selImage;
            }
        }

        private Image PrepareImage(Bitmap image)
        {
            // TASK currently the image being sent to the Vision API is dependant on the size of the Display,
            // So results change depending on the size of the image being sent.
            // Need to set the image to fit to window but send the image at max size to the 
            //vision and face api and get resize the result to fit in the window replacing the iniatial image.
            Bitmap selImage = image;
            int pvHeight = picViewResult.Size.Height;
            int pvWidth = picViewResult.Size.Width;
            int selImageHeight = selImage.Size.Height;
            int selImageWidth = selImage.Size.Width;
            bool selImageToohigh = selImageHeight > pvHeight;
            bool selImageTooWide = selImageWidth > pvWidth;
            
            if (selImageToohigh || selImageTooWide) // image does not fit in the window
            {
                ResizeImage(selImage, pvWidth, pvHeight, selImageWidth, selImageHeight, out var resizedImage);
                return resizedImage;
            }
            else // image fits within Pic View
            {
                return selImage;
            }
        }

        private async void CmdAnalyze_Click(object sender, EventArgs e)
        {
            Cursor = Cursors.WaitCursor;
            EMediaType imageType = GetImageType();
            
            switch (imageType)
            {
                case EMediaType.Image:
                    {
                        // make sure that all camera processing is stopped before we move to single image processing
                        await _grabber.StopProcessingAsync();                      
                        await AnalyzeImage();
                    }
                    break;

                case EMediaType.Web:
                    {
                        await AnalyzeImage();
                    }
                    break;

                case EMediaType.Video:
                    {

                    }
                    break;

                case EMediaType.Camera:
                    {
                        // take snapshot of preview window and put in result window
                        SetResultImage(picPreview.Image);
                        
                        // now analyze snapshot we just took
                        await AnalyzeImage();
                    }
                    break;
            }
            Cursor = Cursors.Arrow;
        }

        private EMediaType GetImageType()
        {
            EMediaType mediaType = EMediaType.Unknown;
            _ext = GetExtension();

            string filePath = SetFilePath();

            bool webimage = filePath.ToLower().StartsWith("www") || filePath.ToLower().StartsWith("http");
            string source = webimage.Equals(true) ? "WEB" : cmbSource.Text.ToUpper();
            switch (source)
            {
                case "FILE":
                    if (IMAGE_TYPES.Contains(_ext))
                        mediaType = EMediaType.Image;
                    else if (VIDEO_TYPES.Contains(_ext))
                        mediaType = EMediaType.Video;
                    else if (DOC_TYPES.Contains(_ext))
                        mediaType = EMediaType.Doc;
                    else
                        mediaType = EMediaType.Unknown;
                    break;
                case "WEB":
                    mediaType = EMediaType.Web;
                    break;
                default:
                    mediaType = EMediaType.Camera;
                    break;
            }
            return mediaType;
        }

        private string SetFilePath()
        {
            return !string.IsNullOrWhiteSpace(txtPicFilename.Text) ? txtPicFilename.Text : string.Empty;
        }

        private string GetExtension()
        {
            return Path.GetExtension(txtPicFilename.Text)?.ToLower().TrimStart('.');
        }

        private string ResultToStr(AnalysisResult result)
        {
            return JsonConvert.SerializeObject(result, Formatting.Indented); // Convert.ToString(result);
        }

        private string InFace(int x, int y, out int faceSeq)
        {
            string tooltipText = string.Empty;
            faceSeq = 0;
            foreach (var face in _detectedFaces)
            {
                FaceRectangle rect = face.FaceRectangle;
                if ((x >= rect.Left && x <= rect.Left + rect.Width) &&
                    (y >= rect.Top && y <= rect.Top + rect.Height))
                {
                    // we are in bounds of this face - set our tooltip text to describe this face
                    tooltipText =
                        $"{face.CandidateName} Age: {face.FaceAttributes.Age} Gender: {face.FaceAttributes.Gender}";
                    break;
                }

                faceSeq++;
            }

            return tooltipText;
        }

        private void PicView_MouseMove(object sender, MouseEventArgs e)
        {
            if (_detectedFaces == null || _detectedFaces.Length <= 0) return;
            var loc = picViewResult.PointToClient(Cursor.Position);
            tooltipFace.SetToolTip(picViewResult, InFace(loc.X, loc.Y, out int faceSeq));
        }

        private async void ContextMenuStrip1_ItemClickedAsync(object sender, ToolStripItemClickedEventArgs e)
        {
            FaceServiceClient FaceClient = _options._faceServiceClient;
            switch (e.ClickedItem.Name)
            {
                case "menuItemDeleteFace":
                    // Used to Delete FACE Profile for out of Person Group
                    //await DeletePersonAsync(string.Empty, cmbPersonName.Text);
                    Point loc = picViewResult.PointToClient(e.ClickedItem.GetCurrentParent().Location);
                    string name = InFace(loc.X, loc.Y, out int faceSeq);
                    if (name != string.Empty)
                    {
                        string[] nameSplit = name.Split('(');
                        string personName = nameSplit[0].Trim();

                        await DeletePersonAsync(personName);

                    }
                        await UpdatePersonListAsync();
                    break;

                case "menuItemAddFace":
                    loc = picViewResult.PointToClient(e.ClickedItem.GetCurrentParent().Location);
                    name = InFace(loc.X, loc.Y, out faceSeq);
                    if (name != string.Empty)
                    {
                        // we are in a face (could be recognized or may be new)
                        frmAddFace frm = new frmAddFace();

                        // tuple item1 is the name to add, item2 is the group id to add
                        Tuple<string, string> nameInfoToAdd = frm.PromptForName(FaceClient);
                        if (nameInfoToAdd.Item1 != string.Empty)
                        {
                            // user has entered a valid name to add - call our method to add this instance of the face to the face id
                            // TASK get replace with get face from memory stream
                            //var destFn = $@"{Path.GetTempPath()}\face{faceSeq}.jpg";
                            string destFn = $@"{Path.GetTempPath()}\face{faceSeq}.png";
                            string personName = nameInfoToAdd.Item1;
                            string personGroup = nameInfoToAdd.Item2;

                            string selPersonGroup = _options.PersonGroupId;
                            // try - Add personFace to a personGroup if the personGroup exist
                            try
                            {
                                PersonGroup personGroupInfo = await FaceClient.GetPersonGroupAsync(personGroup);

                                string personGroupDN = personGroupInfo.Name;

                                await GenLib.AddFace(destFn, personName, personGroup, personGroupDN, FaceClient);
                                await UpdatePersonListAsync(personGroup, _options.personGroupFound);
                                //await AddFace(destFn, nameToAdd);
                            }
                            // catch Create personGroup and add the personFace
                            catch (Exception)
                            {
                                try
                                {
                                    // person group does not exist - create it
                                    await FaceClient.CreatePersonGroupAsync(personGroup, personGroup);
                                    await TrainPersonGroup(personGroup);
                                    await GetTrainingStatus(personGroup);
                                    await GenLib.AddFace(destFn, personName, personGroup, personGroup, FaceClient);
                                    await UpdatePersonListAsync();
                                }
                                catch (Exception ex)
                                {
                                    MessageBox.Show($@"Error creating person group '{personGroup}': {ex.Message}");
                                }
                            }
                            
                        }
                    }
                    else
                        MessageBox.Show(@"Please right click inside of a valid face rectangle"); // add face context menu item was clicked
                    break;
            }
        }

        private async void CmbSource_SelectedIndexChangedAsync(object sender, EventArgs e)
        {
            bool cameraProcessing = _grabber.IsRunning;
            cmdBrowse.Text = string.Empty;
            var source = cmbSource.Text.ToUpper();
            switch (source)
            {
                case "FILE":
                     //toggle UI since file has been activated
                    ToggleUI(false);

                    cmdBrowse.Text = $@"Choose File...";
                    if (cameraProcessing)
                    {
                        await _grabber.StopProcessingAsync();
                    }
                    // File was chosen - make sure to hide preview window
                    tableLayoutPanel1.ColumnStyles[0].Width = 0;
                    //cmdBrowse.BackColor = Color.LightGray;
                    break;

                default:
                    ToggleUI(true);

                    tableLayoutPanel1.ColumnStyles[0].Width = 50;

                    if (!string.IsNullOrWhiteSpace(txtPicFilename.Text))
                    {
                        txtPicFilename.Text = null;
                    }
                    int cameraIndex = 0;
                    string rtsp = string.Empty;

                    if (cmbSource.Text.StartsWith("Camera", StringComparison.OrdinalIgnoreCase))
                    {

                        //cameraIndex = cmbSource.Text.Equals("Camera 1", StringComparison.OrdinalIgnoreCase) ? 0 : 1;
                        var split = cmbSource.Text.Split();
                        cameraIndex = Convert.ToInt32(split[1]) + -1;
                    }
                    else
                    {
                        rtsp = SetRtspStream();
                    }

                    InitializeCameraFeedAsync();
                    // FIX Needs to be awaited 
                    await _grabber.StartProcessingCameraAsync(rtsp, cameraIndex);

                    // comment this function out if you don't want automatic analysis to happen - knh 9/11/2018
                    _grabber.AnalysisFunction = CameraAnalysisFunction; // AllApiFunction;

                    break;
            }
            SetResultImage(null);
        }

        private void ToggleUI(bool isCamera)
        {
            cmdBrowse.Visible = !isCamera;
            cmdRotateImg.Visible = !isCamera;
            cmbCameraMode.Visible = isCamera;
            cmdAnalyze.Enabled = isCamera;
        }

        private static void MatchAndReplaceFaceRectangles(IReadOnlyCollection<Face> faces,
            IReadOnlyCollection<Rect> clientRects)
        {
            // Use a simple heuristic for matching the client-side faces to the faces in the
            // results. Just sort both lists left-to-right, and assume a 1:1 correspondence. 

            // Sort the faces left-to-right. 
            var sortedResultFaces = faces
                .OrderBy(f => f.FaceRectangle.Left + 0.5 * f.FaceRectangle.Width)
                .ToArray();

            // Sort the clientRects left-to-right.
            var sortedClientRects = clientRects
                .OrderBy(r => r.Left + 0.5 * r.Width)
                .ToArray();

            // Assume that the sorted lists now corrrespond directly. We can simply update the
            // FaceRectangles in sortedResultFaces, because they refer to the same underlying
            // objects as the input "faces" array. 
            for (var i = 0; i < Math.Min(faces.Count, clientRects.Count); i++)
            {
                // convert from OpenCvSharp rectangles
                var r = sortedClientRects[i];
                sortedResultFaces[i].FaceRectangle =
                    new FaceRectangle { Left = r.Left, Top = r.Top, Width = r.Width, Height = r.Height };
            }
        }
 
        public bool IsPasswordRevealButtonEnabled { get; set; }
        public string SetRtspStream()
        {
            string camo = cmbSource.Text.ToLower();
            var source = camo.Equals("ipcam") ? "ipcam" : camo.StartsWith("dvr") ? "dvr" : "other";
            var ip = camo.Equals("ipcam") ? _options.Camoip : camo.StartsWith("dvr") ? _options.Dvrip : string.Empty;
            int ch = GetChannel(camo);
            var sch = camo.Equals("ipcam") ? _options.Camoch : camo.StartsWith("dvr") ? _options.Dvrsubch : 0;
            var un = camo.Equals("ipcam") ? _options.CamoUserName : camo.StartsWith("dvr") ? _options.DvrUserName : string.Empty;
            var pw = camo.Equals("ipcam") ? _options.CamoPassword : camo.StartsWith("dvr") ? _options.DvrPassword : string.Empty;
            var rtsp = string.Empty;
            var cameraSource = source.Equals("ipcam") ? _options.SelCamera.ToLower() : source.Equals("dvr") ? _options.SelCameraNetwork.ToLower() : "other";
            switch (source)
            {
                case "ipcam":
                case "dvr":
                    switch (cameraSource)
                    {
                        case "amcrest":
                                rtsp = $"rtsp://{un}:{pw}@{ip}/cam/realmonitor?channel={ch}&subtype={sch}";
                            break;
                    }
                    break;
                case "other":
                    rtsp = _options.OtherCamera;
                    break;
                default:
                    rtsp = _options.OtherCamera;
                    break;
            }
            return rtsp;
        }

        private int GetChannel(string camo)
        {
            int ch = 0;
            if (!camo.Equals("ipcam") && !camo.StartsWith("dvr")) return ch;
            if (camo.Equals("ipcam"))
            {
                ch = _options.Camoch;
            }
            else
            {
                var split = camo.Split(' ');
                var chsel = split[3];

                if (int.TryParse(chsel, out var i)) ch = i;
            }
            return ch;
        }

        //private void GetCamera(object sender, RoutedEventArgs e)
        private void BuildSourceList()
        {
            //Local Camera 0
            int numCameras = _grabber.GetNumCameras();
            int dvrchs = Settings.Default.dvrChannels;
            string other = Settings.Default.otherVideoSource;

            List<string> listData = new List<string>();
            for (var i = 0; i <= numCameras; i++)
                if (i > 0)
                    listData.Add($"Camera {i}");
            if (!string.IsNullOrWhiteSpace(_options.Camoip)) listData.Add("ipcam");
            if (!string.IsNullOrWhiteSpace(_options.Dvrip))
                for (var x = 1; x <= dvrchs; x++)
                    if (dvrchs > 0)
                    {
                        listData.Add($@"DVR Network Camera {x}");
                    }
            if (!string.IsNullOrWhiteSpace(other))
            {
                if (!other.StartsWith("Example", StringComparison.CurrentCultureIgnoreCase))
                {
                    listData.Add($@"Other Video Source");
                }
            }
            
            cmbSource.Items.Clear();
            cmbSource.Items.Add("File");
            foreach (string camera in listData)
            {
                cmbSource.Items.Add(camera);
            }
        }
        private void InitializeCameraFeedAsync()
        {
            _startTime = DateTime.Now;

            if (_cameraModeAuto)
                // auto mode
                _grabber.TriggerAnalysisOnInterval(TimeSpan.FromMilliseconds(_options.TimeDelay));
            else
                // manual mode 
                _grabber.TriggerAnalysisOnInterval(TimeSpan.FromMilliseconds(0)); 

            // Needs to be Reset message. 
            lstLog.Text = string.Empty;

            // Set up a listener for when we acquire a new frame.

            // Set up a listener for when the client receives a new frame.
            void p(object s, FrameGrabber<LiveCameraResult>.NewFrameEventArgs e)
            {
                //picPreview.BeginInvoke((Action) () => picPreview.Image = e.Frame.Image.Clone().ToBitmap()));
                //The callback may occur on a different thread, so we must use the
                // MainWindow.Dispatcher when manipulating the UI.
                try
                {
                    picPreview.BeginInvoke
                        (
                            (Action)
                                (() =>
                                   {
                                           // NEEDS FIXED
                                           // Need to stop when video has ended 
                                           // error when video ends ($exception).Message Parameter is not valid.
                                           if (e.Frame.Image.Height != 0 && e.Frame.Image.Width != 0)
                                       {
                                           picPreview.Image = e.Frame.Image.Clone().ToBitmap();
                                       }
                                   }
                                )
                        );
                }
                catch
                {
                    // ignored
                }
            }
            _grabber.NewFrameProvided += p;
        }

        protected virtual void OnPropertyChanged(PropertyChangedEventArgs e)
        {
            _propertyChanged?.Invoke(this, e);
        }

        private void SetResultImage(Image img)
        {
            //lock (lockObj)
            //{
                picViewResult.Image = img;
            //}
        }

        private Image GetResultImage()
        {
            return picViewResult.Image;
        }

        private System.Drawing.Size GetResultImageSize()
        {
            //lock (lockObj)
            //{
                return picViewResult.Image.Size;
            //}
        }

        private void CmbCameraMode_SelectedIndexChanged(object sender, EventArgs e)
        {
            _cameraModeAuto = cmbCameraMode.Text.Equals("Auto", StringComparison.OrdinalIgnoreCase);
            InitializeCameraFeedAsync();
        }

        private void TrainFromWebToolStripMenuItem_Click(object sender, EventArgs e)
        {
            new FrmTrainFromWeb().ShowDialog();
        }

        private void TrainFromO365StripMenuItem_Click(object sender, EventArgs e)
        {
            new frmTrainFromO365().ShowDialog();
        }

        private void CmdClearPersonsList_Click(object sender, EventArgs e)
        {
            //cmbPersonName.Items.Clear();
            //UpdatePersonListAsync();
        }

        private void CategorizeFilesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmCategorizeFiles frm = new frmCategorizeFiles();
            frm.HandleCategorizeFiles(_personsInActiveGroup, MAX_IMAGE_SIZE);
        }
    } // namespace
} // class
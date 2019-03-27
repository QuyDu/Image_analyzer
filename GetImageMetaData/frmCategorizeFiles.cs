using Microsoft.ProjectOxford.Face;
using Microsoft.ProjectOxford.Face.Contract;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GetImageMetaData
{
    // Update 03/15/2019 01:00 PM
    public partial class frmCategorizeFiles : Form
    {
        private long _maxImageSize;
        private List<string> _personNames;

        private Options _options = new Options();

        public frmCategorizeFiles()
        {
            InitializeComponent();
        }

        public void HandleCategorizeFiles(List<string> personNames, long maxImageSize)
        {
            _maxImageSize = maxImageSize;
            _personNames = personNames;
            this.ShowDialog();
        }

        private async Task CategorizeFiles(string nameToFind)
        {
            await _options.UpdateMemberVarsFromProperties();
            bool internet = _options.Internet;
            bool containerMode = _options.ContainerMode;
            string msgType4 = "Internet";

            string rootFolder = GenLib.BrowseForFolder();
            int numCategorized = 0;
            int fileNum = 0;
            string errStr;
            string CSKey = _options.CSKey;
            FaceServiceClient faceClient = _options._faceServiceClient;
            PersonGroup[] personGroups = Array.Empty<PersonGroup>();
            personGroups = await GenLib.GetPersonGroups(CSKey, faceClient);

            if (!string.IsNullOrEmpty(rootFolder))
            {
                if (internet)
                {
                    // user selected a folder to scan - start scan
                    string[] files = Directory.GetFiles(rootFolder);

                    SetProgressMax(files.Length);
                    foreach (string fn in files)
                    {
                        fileNum++;
                        //Image workImage = fn.Clone();

                        if (GenLib.FileIsImage(fn))
                        {
                            // Image needs to be smaller than 4MB
                            // FIX Currently this following method does not convert img to les than 4MB
                            Image readyImage;
                            System.Drawing.Image selImage;

                            selImage = (Bitmap)Image.FromFile(fn);

                            try
                            {
                                Stream imageFileStream = GenLib.ConvertAndCompressImageFileToStream(selImage, _maxImageSize, out errStr);

                                //readyImage = selImage;
                                readyImage = Image.FromStream(imageFileStream);

                                UpdateStatus($"Detecting faces in file '{fn}'...");
                                EnhancedFace[] detectedFaces = await GenLib.DetectFaces(readyImage, faceClient);

                                if (detectedFaces.Any())
                                {
                                    List<IdentifiedPerson> foundGroupInfo = await GenLib.GetCandidateNames(detectedFaces, personGroups, faceClient, false);
                                    List<string> foundNames = foundGroupInfo.Select(g => g.PersonName).ToList<string>();

                                    if (nameToFind == "" || foundNames.Contains(nameToFind, StringComparer.OrdinalIgnoreCase))
                                    {
                                        // we found an image with our desired face in it - copy it out to our target dir
                                        CopyImageToCategoryDir(fn, nameToFind, foundNames);
                                        numCategorized++;
                                    }
                                    else
                                        LogInfo($"{detectedFaces.Length} faces found but it's not the one we are looking for in '{fn}'");
                                }
                            }
                            catch
                            {
                                LogInfo($"Unable to process the image'{fn}'");
                            }
                        } // file was an image
                        UpdateProgress(fileNum);
                    } // for each file found in user's directory

                    LogInfo($"Done.  Categorized {numCategorized}/{files.Length} files from directory '{rootFolder}' OK");
                } // if internet
                else
                {
                    if (containerMode)
                    {

                    }
                    else
                    {
                        MessageBox.Show(GenLib.SetMessage(msgType4, string.Empty, string.Empty, null));
                    }
                }
            } // user directory was defined
        } // categorizeFiles

        private bool CopyImageToCategoryDir(string imageFn, string nameToFind, List<string> foundNames)
        {
            bool blnOk = true;

            foreach (string name in foundNames)
            {
                if ((nameToFind == "" || name.Equals(nameToFind, StringComparison.OrdinalIgnoreCase)) && !GenLib.IsUknownCandidate(name))
                {
                    string destFn = $@"{Path.GetDirectoryName(imageFn)}\{name}\{Path.GetFileName(imageFn)}";
                    string errStr;
                    if (GenLib.CopyFile(imageFn, destFn, true, out errStr))
                    {
                        // copied file ok - log it
                        LogInfo($"*** Categorized file '{Path.GetFileName(imageFn)}' into directory '{Path.GetDirectoryName(destFn)}' OK");
                    }
                    else
                    {
                        LogErr($"Error copying source file '{imageFn}' to '{destFn}': {errStr}");
                        blnOk = false;
                    }
                } // we found a name we need to categorize
            }

            return blnOk;
        }

        private async Task DoFindFiles(string nameToFind)
        {
            await CategorizeFiles(nameToFind);
        }

        private void UpdateProgress(int newValue)
        {
            statusBar.Value = newValue;
        }

        private void SetProgressMax(int maxValue)
        {
            statusBar.Maximum = maxValue;
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

        private void frmCategorizeFiles_Load(object sender, EventArgs e)
        {
            // make our list of people also available for search
            cmbSearchPerson.Items.Clear();
            cmbSearchPerson.Items.AddRange(_personNames.ToArray());
        }

        private async void cmdFindFiles_Click(object sender, EventArgs e)
        {
            await DoFindFiles(cmbSearchPerson.Text);
        }
    }
}

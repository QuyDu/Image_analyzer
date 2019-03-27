using Microsoft.ProjectOxford.Face;
using Microsoft.ProjectOxford.Face.Contract;
using Microsoft.ProjectOxford.Vision;
using System;
using System.Drawing;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GetImageMetaData
{
    // Update 03/09/2019 01:30 PM
    public partial class FrmOptions : Form
    {
        private static Options _options = new Options();
        private static FaceServiceClient _faceClient;
        public static VisionServiceClient _visionServiceClient;

        public FrmOptions()
        {
            InitializeComponent();
        }

        private async void CmdSave_ClickAsync(object sender, EventArgs e)
        {
            if (GenLib.CheckForInternetConnection())
            {
                Properties.Settings.Default.Save();

                await UpdatePersonGroupsData();

                Close();
            }
        }

        private async Task UpdatePersonGroupList()
        {
            PersonGroup[] personGroups = Array.Empty<PersonGroup>();
            string cogSrvcKey = !string.IsNullOrWhiteSpace(txtCognitiveServicesAPIKey.Text) ? txtCognitiveServicesAPIKey.Text.Trim() : !string.IsNullOrWhiteSpace(_options.CSKey) ? _options.CSKey : string.Empty;
            string cogSrvcEP = !string.IsNullOrWhiteSpace(txtCognitiveServicesEndpoint.Text) ? txtCognitiveServicesEndpoint.Text.Trim() : !string.IsNullOrWhiteSpace(_options.CSEndpoint) ? _options.CSEndpoint : string.Empty;
            string faceEndpoint = !string.IsNullOrWhiteSpace(txtCognitiveServicesEndpoint.Text) ? $"{txtCognitiveServicesEndpoint.Text.Trim()}face/v1.0" : !string.IsNullOrWhiteSpace(_options.FaceEndpoint) ? _options.FaceEndpoint : string.Empty;

            if (!string.IsNullOrWhiteSpace(cogSrvcKey) && !string.IsNullOrWhiteSpace(cogSrvcEP))
            {
                try
                {
                    _faceClient = new FaceServiceClient(cogSrvcKey, faceEndpoint);
                    personGroups = await _faceClient.ListPersonGroupsAsync(cogSrvcKey);
                }
                catch
                {

                }
            }

            if (personGroups.Length > 0)
            {
                cmbPersonGroups.SelectedText = string.Empty;
                cmbPersonGroups.Items.Clear();
                cmbPersonGroups.Items.Add(string.Empty);
                for (int i = 0; i < personGroups.Length; i++)
                {
                    PersonGroup personGroup = personGroups[i];
                    cmbPersonGroups.Items.Add(personGroup.PersonGroupId);
                }
            }

        }

        private async void CmdUpdate_ClickAsync(object sender, EventArgs e)
        {
            await UpdatePersonGroupsData();
        }

        private async Task UpdatePersonGroupsData()
        {
            await _options.UpdateMemberVarsFromProperties();
            bool internet = _options.Internet;
            bool containerMode = _options.ContainerMode;
            string msgType1 = "PersonGroups";
            string msgType2 = "Internet";
            await UpdatePersonGroupList();
            string groupId = string.Empty;
            if (!containerMode)
            {
                if (internet)
                {
                    int groupsCount = cmbPersonGroups.Items.Count;
                    if (groupsCount > 1)
                    {
                        string selGroupId = !string.IsNullOrWhiteSpace(cmbPersonGroups.Items[1].ToString()) ? cmbPersonGroups.Items[1].ToString() : string.Empty;
                        groupId = !string.IsNullOrWhiteSpace(cmbPersonGroups.Text) ? cmbPersonGroups.Items.Contains(cmbPersonGroups.Text) ? cmbPersonGroups.Text : selGroupId : selGroupId;
                    }
                    if (!string.IsNullOrWhiteSpace(groupId))
                    {
                        cmbPersonGroups.Text = groupId;

                        string groupDisplayName = await GetGroupDisplayName(groupId);

                        Color color = await GetColorFromUserData(groupId);
                        txtPersonGroupDisplay.Text = groupDisplayName;
                        cmdSetColor.BackColor = color;
                    }
                    else
                    {
                        cmbPersonGroups.Text = string.Empty;
                        txtPersonGroupDisplay.Text = string.Empty;
                        MessageBox.Show(GenLib.SetMessage(msgType1, string.Empty, string.Empty, null));
                    }       
                } 
                else // if internet is false
                {
                     MessageBox.Show(GenLib.SetMessage(msgType2, string.Empty, string.Empty, null));
                }
            } 
            else // If Container mode true
            {

            }
            
        }

        private static async Task<string> GetGroupDisplayName(string groupId)
        {
            PersonGroup groupInfo = await _options._faceServiceClient.GetPersonGroupAsync(groupId);
            string groupDIsplayName = groupInfo.Name;
            return groupDIsplayName;
        }

        private static async Task<Color> GetColorFromUserData(string groupId)
        {
            PersonGroup groupInfo = await _options._faceServiceClient.GetPersonGroupAsync(groupId);
            string userData = groupInfo.UserData;
            if (int.TryParse(userData, out var argb))
            {
                argb = Convert.ToInt32(userData);
            }
            else
            {
                argb = -16744448;
            }

            Color color = Color.FromArgb(argb);
            return color;
        }

        private async void CmdDeleteGroup_ClickAsync(object sender, EventArgs e)
        {
            if (!string.IsNullOrWhiteSpace(cmbPersonGroups.Text))
            {
                await GenLib.DeletePersonGroupAsync(cmbPersonGroups.Text);
                await UpdatePersonGroupList();
                await _options.UpdateMemberVarsFromProperties();
            }
        }


        private void CmdSetColor_Click(object sender, EventArgs e)
        {
            ColorDialog dlg = new ColorDialog
            {
                AllowFullOpen = false,
                AnyColor = true,
                SolidColorOnly = true,
                Color = Color.Green
            };

            if (dlg.ShowDialog() == DialogResult.OK)
            {
                cmdSetColor.BackColor = dlg.Color;
            }
        }
        private async void CmdUpdateGroup_ClickAsync(object sender, EventArgs e)
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

            if (!string.IsNullOrWhiteSpace(_options.CSKey) && !string.IsNullOrWhiteSpace(_options.FaceEndpoint))
            {
                string userData = cmdSetColor.BackColor.ToArgb().ToString();
                string group = cmbPersonGroups.Text;
                string displayName = txtPersonGroupDisplay.Text;  //cmbPersonGroups.Text;

                string faceKey = _options.CSKey;
                string faceEnd = _options.FaceEndpoint;
                _faceClient = new FaceServiceClient(faceKey, faceEnd);
                await _faceClient.UpdatePersonGroupAsync(group, displayName, userData);
                await _faceClient.TrainPersonGroupAsync(group);
            }
        }

        private void ChbContainerMode_CheckedChanged(object sender, EventArgs e)
        {
            if(chbContainerMode.Checked)
            {
                Properties.Settings.Default.useContainerMode = true;
            }
            else
            {
                Properties.Settings.Default.useContainerMode = false;
            }
        }
    }
}

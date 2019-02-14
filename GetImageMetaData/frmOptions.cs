using Microsoft.ProjectOxford.Face;
using Microsoft.ProjectOxford.Face.Contract;
using Microsoft.ProjectOxford.Vision;
using System;
using System.Drawing;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GetImageMetaData
{
    // Update 02/02/2019 11:30 AM
    public partial class FrmOptions : Form
    {
        private static Options _options = new Options();
        private static FaceServiceClient _faceClient;
        public static VisionServiceClient _visionServiceClient;

        public FrmOptions()
        {
            InitializeComponent();
        }

        private async void cmdSave_ClickAsync(object sender, EventArgs e)
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

        private async void cmdUpdate_ClickAsync(object sender, EventArgs e)
        {
            await UpdatePersonGroupsData();
        }

        private async Task UpdatePersonGroupsData()
        {
            await _options.UpdateMemberVarsFromProperties();
            await UpdatePersonGroupList();
            string groupId = string.Empty;

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

                // knh 2-4-19 - removed dependency on frmMain from options here
                //await _frmMain.UpdatePersonListAsync(groupId);
            }
            else
            {
                cmbPersonGroups.Text = string.Empty;
                txtPersonGroupDisplay.Text = string.Empty;
                
                MessageBox.Show($@"You are recieving this message because of 1 of the following reasons:

                        1. You have Entereded an invalid Cognitive Services API Key.
                            (This App uses the Cognitive Services 1 Key)

                        2. You have entered an invalid Cognitive Services Endpoint. 
                            (Cognitive Services 1 Key Endpoint should look something like depending on region selected,
                            https://westus.api.cognitive.microsoft.com/

                        3. There are currently no personGroups registed for this API Key.
                            To create a new personGroup:
                            a. Analyze Image with a face
                            b. Click on face
                            c. Click on Add Face
                            d. Add a name of the desired persongroup
                               (personGroup name must be lowercase and no spaces)
                            e. Add a name for the person being added
                               (when creating a new personGroup you must add a new person for personGroup to be trained)
                            f. Click on Save.");

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

        private async void cmdDeleteGroup_ClickAsync(object sender, EventArgs e)
        {
            if (!string.IsNullOrWhiteSpace(cmbPersonGroups.Text))
            {
                await GenLib.DeletePersonGroupAsync(cmbPersonGroups.Text);
                await UpdatePersonGroupList();
                await _options.UpdateMemberVarsFromProperties();
            }
        }


        private void cmdSetColor_Click(object sender, EventArgs e)
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
        private async void cmdUpdateGroup_ClickAsync(object sender, EventArgs e)
        {
            await _options.UpdateMemberVarsFromProperties();
            
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

        private void txtOther_TextChanged(object sender, EventArgs e)
        {

        }
    }
}

using Microsoft.ProjectOxford.Face;
using Microsoft.ProjectOxford.Face.Contract;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GetImageMetaData
{
    // Update 02/08/2019 12:30 AM
    public partial class frmAddFace : Form
    {
        private FaceServiceClient _faceClient;
        private Options _options = new Options();

        public frmAddFace()
        {
            InitializeComponent();
        }

        public Tuple<string, string> PromptForName(FaceServiceClient faceClient)
        {
            string name = "";
            string groupID = "";

            _faceClient = faceClient;
            DialogResult result = this.ShowDialog();

            if (result == DialogResult.OK)
            {
                name = cmbPersonName.Text;
                try
                {
                    groupID = !string.IsNullOrWhiteSpace(((PersonGroup)cmbPersonGroup.SelectedItem).PersonGroupId.ToString()) ? ((PersonGroup)cmbPersonGroup.SelectedItem).PersonGroupId : cmbPersonGroup.Text.ToString();
                }
                catch
                {
                    groupID = !string.IsNullOrWhiteSpace(cmbPersonGroup.SelectedText.ToString()) ? ((PersonGroup)cmbPersonGroup.SelectedItem).PersonGroupId : cmbPersonGroup.Text.ToString();
                }
                //groupID = cmbPersonGroup.Text;
  
            }

            return Tuple.Create(name, groupID);
        }

        private void cmdAddFace_Click(object sender, EventArgs e)
        {
            if (cmbPersonName.Text == string.Empty  || cmbPersonGroup.Text == string.Empty)
            {
                if (cmbPersonName.Text == string.Empty)
                {
                    // user has clicked add face but has not given us a name yet - show err msg
                    MessageBox.Show(@"Please enter a new name or select a previously recognized name");
                }
                if (cmbPersonGroup.Text == string.Empty)
                {
                    // user has clicked add face but has not given us a personGroup to save the name yet - show err msg
                    MessageBox.Show(@"Please enter a new personGroup or select a previously created personGroup");
                }
            }
            else
            {
                // user has selected a face name - so we are good togo and close this form
                this.DialogResult = DialogResult.OK;
                this.Close();
            }
        }

        private async void frmAddFace_Load(object sender, EventArgs e)
        {
            await _options.UpdateMemberVarsFromProperties();
            // call our general library to get our list of groups and populate our combobox
            PersonGroup[] groups = await GenLib.GetPersonGroups();

            cmbPersonGroup.Items.Add(string.Empty);
            for (int i = 0; i < groups.Length; i++)
            {
                PersonGroup personGroup = groups[i];
                cmbPersonGroup.Items.Add(personGroup);
                //cmbPersonGroup.Items.Add(personGroup.PersonGroupId);
            }

            //cmbPersonGroup.Items.AddRange(groups);

            // select first group by default
            if (groups.Length > 0)
            {
                if (cmbPersonGroup.Items.Count > 0)
                    cmbPersonGroup.SelectedIndex = 1;
            }
        }

        private async void cmbPersonGroup_SelectedIndexChanged(object sender, EventArgs e)
        {
            string groupID = ((PersonGroup)(cmbPersonGroup.Items[cmbPersonGroup.SelectedIndex])).PersonGroupId;
            //string groupID = cmbPersonGroup.SelectedItem.ToString();
            if (groupID != null)
            {
                Person[] people = await _faceClient.ListPersonsAsync(groupID);
                cmbPersonName.Items.Clear();

                for (int i = 0; i < people.Length; i++)
                {
                    cmbPersonName.Items.Add(people[i].Name);
                }
            }
        }
    }
}

// 
// Copyright (c) Microsoft. All rights reserved.
// Licensed under the MIT license.
// 
// Microsoft Cognitive Services: http://www.microsoft.com/cognitive
// 
// 
// Copyright (c) Microsoft Corporation
// All rights reserved.
// 
// MIT License:
// Permission is hereby granted, free of charge, to any person obtaining
// a copy of this software and associated documentation files (the
// "Software"), to deal in the Software without restriction, including
// without limitation the rights to use, copy, modify, merge, publish,
// distribute, sublicense, and/or sell copies of the Software, and to
// permit persons to whom the Software is furnished to do so, subject to
// the following conditions:
// 
// The above copyright notice and this permission notice shall be
// included in all copies or substantial portions of the Software.
// 
// THE SOFTWARE IS PROVIDED ""AS IS"", WITHOUT WARRANTY OF ANY KIND,
// EXPRESS OR IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF
// MERCHANTABILITY, FITNESS FOR A PARTICULAR PURPOSE AND
// NONINFRINGEMENT. IN NO EVENT SHALL THE AUTHORS OR COPYRIGHT HOLDERS BE
// LIABLE FOR ANY CLAIM, DAMAGES OR OTHER LIABILITY, WHETHER IN AN ACTION
// OF CONTRACT, TORT OR OTHERWISE, ARISING FROM, OUT OF OR IN CONNECTION
// WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN THE SOFTWARE.
// 

namespace GetImageMetaData
{
    partial class FrmOptions
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.cmdSave = new System.Windows.Forms.Button();
            this.cmdCancel = new System.Windows.Forms.Button();
            this.tabAzureCosmosDB = new System.Windows.Forms.TabPage();
            this.label28 = new System.Windows.Forms.Label();
            this.label29 = new System.Windows.Forms.Label();
            this.label30 = new System.Windows.Forms.Label();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabCognitiveServicesAPI = new System.Windows.Forms.TabPage();
            this.label27 = new System.Windows.Forms.Label();
            this.label31 = new System.Windows.Forms.Label();
            this.label32 = new System.Windows.Forms.Label();
            this.tabPersonGroups = new System.Windows.Forms.TabPage();
            this.cmdUpdateGroup = new System.Windows.Forms.Button();
            this.cmdSetColor = new System.Windows.Forms.Button();
            this.label16 = new System.Windows.Forms.Label();
            this.cmdDeleteGroup = new System.Windows.Forms.Button();
            this.cmdUpdate = new System.Windows.Forms.Button();
            this.label7 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.tabCameras = new System.Windows.Forms.TabPage();
            this.label22 = new System.Windows.Forms.Label();
            this.label21 = new System.Windows.Forms.Label();
            this.cmbSelCamera = new System.Windows.Forms.ComboBox();
            this.cmbSelCameraNet = new System.Windows.Forms.ComboBox();
            this.label20 = new System.Windows.Forms.Label();
            this.txtIPCamSubChannel = new System.Windows.Forms.TextBox();
            this.label19 = new System.Windows.Forms.Label();
            this.txtIPCamChannels = new System.Windows.Forms.TextBox();
            this.label18 = new System.Windows.Forms.Label();
            this.label17 = new System.Windows.Forms.Label();
            this.txtDVRSubChannel = new System.Windows.Forms.TextBox();
            this.label14 = new System.Windows.Forms.Label();
            this.txtAnalyzeTime = new System.Windows.Forms.TextBox();
            this.label13 = new System.Windows.Forms.Label();
            this.txtDVRChannels = new System.Windows.Forms.TextBox();
            this.label12 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.colorDialog1 = new System.Windows.Forms.ColorDialog();
            this.chbContainerMode = new System.Windows.Forms.CheckBox();
            this.txtCognitiveServicesAPIKey = new System.Windows.Forms.TextBox();
            this.txtCognitiveServicesEndpoint = new System.Windows.Forms.TextBox();
            this.cmbPersonGroups = new System.Windows.Forms.ComboBox();
            this.txtPersonGroupDisplay = new System.Windows.Forms.TextBox();
            this.txtIPcamPassword = new System.Windows.Forms.TextBox();
            this.txtDVRPassword = new System.Windows.Forms.TextBox();
            this.txtOther = new System.Windows.Forms.TextBox();
            this.txtIPCamUserName = new System.Windows.Forms.TextBox();
            this.txtIPCamIp = new System.Windows.Forms.TextBox();
            this.txtDVRUserName = new System.Windows.Forms.TextBox();
            this.txtDVRIP = new System.Windows.Forms.TextBox();
            this.txtCosmosDataBasePrimConString = new System.Windows.Forms.TextBox();
            this.txtCosmosDataBasePrimKey = new System.Windows.Forms.TextBox();
            this.txtCosmosDataBaseURI = new System.Windows.Forms.TextBox();
            this.tabAzureCosmosDB.SuspendLayout();
            this.tabControl1.SuspendLayout();
            this.tabCognitiveServicesAPI.SuspendLayout();
            this.tabPersonGroups.SuspendLayout();
            this.tabCameras.SuspendLayout();
            this.SuspendLayout();
            // 
            // cmdSave
            // 
            this.cmdSave.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.cmdSave.Location = new System.Drawing.Point(768, 637);
            this.cmdSave.Margin = new System.Windows.Forms.Padding(4);
            this.cmdSave.Name = "cmdSave";
            this.cmdSave.Size = new System.Drawing.Size(128, 38);
            this.cmdSave.TabIndex = 0;
            this.cmdSave.Text = "&Save";
            this.cmdSave.UseVisualStyleBackColor = true;
            this.cmdSave.Click += new System.EventHandler(this.CmdSave_ClickAsync);
            // 
            // cmdCancel
            // 
            this.cmdCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.cmdCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.cmdCancel.Location = new System.Drawing.Point(902, 637);
            this.cmdCancel.Margin = new System.Windows.Forms.Padding(4);
            this.cmdCancel.Name = "cmdCancel";
            this.cmdCancel.Size = new System.Drawing.Size(128, 38);
            this.cmdCancel.TabIndex = 1;
            this.cmdCancel.Text = "&Cancel";
            this.cmdCancel.UseVisualStyleBackColor = true;
            // 
            // tabAzureCosmosDB
            // 
            this.tabAzureCosmosDB.Controls.Add(this.txtCosmosDataBasePrimConString);
            this.tabAzureCosmosDB.Controls.Add(this.label28);
            this.tabAzureCosmosDB.Controls.Add(this.label29);
            this.tabAzureCosmosDB.Controls.Add(this.txtCosmosDataBasePrimKey);
            this.tabAzureCosmosDB.Controls.Add(this.label30);
            this.tabAzureCosmosDB.Controls.Add(this.txtCosmosDataBaseURI);
            this.tabAzureCosmosDB.Location = new System.Drawing.Point(8, 39);
            this.tabAzureCosmosDB.Margin = new System.Windows.Forms.Padding(4);
            this.tabAzureCosmosDB.Name = "tabAzureCosmosDB";
            this.tabAzureCosmosDB.Size = new System.Drawing.Size(964, 543);
            this.tabAzureCosmosDB.TabIndex = 3;
            this.tabAzureCosmosDB.Text = "Azure Cosmos DB";
            this.tabAzureCosmosDB.UseVisualStyleBackColor = true;
            // 
            // label28
            // 
            this.label28.AutoSize = true;
            this.label28.Location = new System.Drawing.Point(18, 210);
            this.label28.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label28.Name = "label28";
            this.label28.Size = new System.Drawing.Size(381, 25);
            this.label28.TabIndex = 30;
            this.label28.Text = "Cosmos DB Primary Connection String";
            // 
            // label29
            // 
            this.label29.AutoSize = true;
            this.label29.Location = new System.Drawing.Point(18, 115);
            this.label29.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label29.Name = "label29";
            this.label29.Size = new System.Drawing.Size(247, 25);
            this.label29.TabIndex = 28;
            this.label29.Text = "Cosmos DB Primary Key";
            // 
            // label30
            // 
            this.label30.AutoSize = true;
            this.label30.Location = new System.Drawing.Point(18, 29);
            this.label30.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label30.Name = "label30";
            this.label30.Size = new System.Drawing.Size(166, 25);
            this.label30.TabIndex = 26;
            this.label30.Text = "Cosmos DB URI";
            // 
            // tabControl1
            // 
            this.tabControl1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tabControl1.Controls.Add(this.tabCognitiveServicesAPI);
            this.tabControl1.Controls.Add(this.tabPersonGroups);
            this.tabControl1.Controls.Add(this.tabCameras);
            this.tabControl1.Controls.Add(this.tabAzureCosmosDB);
            this.tabControl1.Location = new System.Drawing.Point(32, 31);
            this.tabControl1.Margin = new System.Windows.Forms.Padding(4);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(980, 590);
            this.tabControl1.TabIndex = 0;
            // 
            // tabCognitiveServicesAPI
            // 
            this.tabCognitiveServicesAPI.Controls.Add(this.chbContainerMode);
            this.tabCognitiveServicesAPI.Controls.Add(this.label27);
            this.tabCognitiveServicesAPI.Controls.Add(this.label31);
            this.tabCognitiveServicesAPI.Controls.Add(this.label32);
            this.tabCognitiveServicesAPI.Controls.Add(this.txtCognitiveServicesAPIKey);
            this.tabCognitiveServicesAPI.Controls.Add(this.txtCognitiveServicesEndpoint);
            this.tabCognitiveServicesAPI.Location = new System.Drawing.Point(8, 39);
            this.tabCognitiveServicesAPI.Margin = new System.Windows.Forms.Padding(6);
            this.tabCognitiveServicesAPI.Name = "tabCognitiveServicesAPI";
            this.tabCognitiveServicesAPI.Size = new System.Drawing.Size(964, 543);
            this.tabCognitiveServicesAPI.TabIndex = 6;
            this.tabCognitiveServicesAPI.Text = "Cognitive Services API";
            this.tabCognitiveServicesAPI.UseVisualStyleBackColor = true;
            // 
            // label27
            // 
            this.label27.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.label27.AutoSize = true;
            this.label27.Location = new System.Drawing.Point(26, 208);
            this.label27.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label27.Name = "label27";
            this.label27.Size = new System.Drawing.Size(596, 25);
            this.label27.TabIndex = 38;
            this.label27.Text = "If Cognitive Services API Changed Click on Update Group list";
            // 
            // label31
            // 
            this.label31.AutoSize = true;
            this.label31.Location = new System.Drawing.Point(26, 119);
            this.label31.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label31.Name = "label31";
            this.label31.Size = new System.Drawing.Size(321, 25);
            this.label31.TabIndex = 37;
            this.label31.Text = "Cognitive Services API Endpoint";
            // 
            // label32
            // 
            this.label32.AutoSize = true;
            this.label32.Location = new System.Drawing.Point(26, 31);
            this.label32.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label32.Name = "label32";
            this.label32.Size = new System.Drawing.Size(273, 25);
            this.label32.TabIndex = 35;
            this.label32.Text = "Cognitive Services API Key";
            // 
            // tabPersonGroups
            // 
            this.tabPersonGroups.Controls.Add(this.cmdUpdateGroup);
            this.tabPersonGroups.Controls.Add(this.cmdSetColor);
            this.tabPersonGroups.Controls.Add(this.label16);
            this.tabPersonGroups.Controls.Add(this.cmdDeleteGroup);
            this.tabPersonGroups.Controls.Add(this.cmdUpdate);
            this.tabPersonGroups.Controls.Add(this.label7);
            this.tabPersonGroups.Controls.Add(this.label6);
            this.tabPersonGroups.Controls.Add(this.cmbPersonGroups);
            this.tabPersonGroups.Controls.Add(this.txtPersonGroupDisplay);
            this.tabPersonGroups.Location = new System.Drawing.Point(8, 39);
            this.tabPersonGroups.Margin = new System.Windows.Forms.Padding(6);
            this.tabPersonGroups.Name = "tabPersonGroups";
            this.tabPersonGroups.Padding = new System.Windows.Forms.Padding(6);
            this.tabPersonGroups.Size = new System.Drawing.Size(964, 543);
            this.tabPersonGroups.TabIndex = 5;
            this.tabPersonGroups.Text = "Person Groups";
            this.tabPersonGroups.UseVisualStyleBackColor = true;
            // 
            // cmdUpdateGroup
            // 
            this.cmdUpdateGroup.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.cmdUpdateGroup.Location = new System.Drawing.Point(426, 256);
            this.cmdUpdateGroup.Margin = new System.Windows.Forms.Padding(4);
            this.cmdUpdateGroup.Name = "cmdUpdateGroup";
            this.cmdUpdateGroup.Size = new System.Drawing.Size(244, 40);
            this.cmdUpdateGroup.TabIndex = 43;
            this.cmdUpdateGroup.Text = "Update Person Group";
            this.cmdUpdateGroup.UseVisualStyleBackColor = true;
            this.cmdUpdateGroup.Click += new System.EventHandler(this.CmdUpdateGroup_ClickAsync);
            // 
            // cmdSetColor
            // 
            this.cmdSetColor.BackColor = System.Drawing.Color.Green;
            this.cmdSetColor.Location = new System.Drawing.Point(20, 256);
            this.cmdSetColor.Margin = new System.Windows.Forms.Padding(4);
            this.cmdSetColor.Name = "cmdSetColor";
            this.cmdSetColor.Size = new System.Drawing.Size(272, 44);
            this.cmdSetColor.TabIndex = 42;
            this.cmdSetColor.UseVisualStyleBackColor = false;
            this.cmdSetColor.Click += new System.EventHandler(this.CmdSetColor_Click);
            // 
            // label16
            // 
            this.label16.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.label16.AutoSize = true;
            this.label16.Location = new System.Drawing.Point(16, 231);
            this.label16.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(202, 25);
            this.label16.TabIndex = 40;
            this.label16.Text = "Person Group Color";
            // 
            // cmdDeleteGroup
            // 
            this.cmdDeleteGroup.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.cmdDeleteGroup.Location = new System.Drawing.Point(736, 52);
            this.cmdDeleteGroup.Margin = new System.Windows.Forms.Padding(4);
            this.cmdDeleteGroup.Name = "cmdDeleteGroup";
            this.cmdDeleteGroup.Size = new System.Drawing.Size(220, 40);
            this.cmdDeleteGroup.TabIndex = 38;
            this.cmdDeleteGroup.Text = "&Delete Group";
            this.cmdDeleteGroup.UseVisualStyleBackColor = true;
            this.cmdDeleteGroup.Click += new System.EventHandler(this.CmdDeleteGroup_ClickAsync);
            // 
            // cmdUpdate
            // 
            this.cmdUpdate.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.cmdUpdate.Location = new System.Drawing.Point(426, 52);
            this.cmdUpdate.Margin = new System.Windows.Forms.Padding(4);
            this.cmdUpdate.Name = "cmdUpdate";
            this.cmdUpdate.Size = new System.Drawing.Size(220, 40);
            this.cmdUpdate.TabIndex = 37;
            this.cmdUpdate.Text = "Refresh Groups";
            this.cmdUpdate.UseVisualStyleBackColor = true;
            this.cmdUpdate.Click += new System.EventHandler(this.CmdUpdate_ClickAsync);
            // 
            // label7
            // 
            this.label7.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(16, 117);
            this.label7.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(380, 25);
            this.label7.TabIndex = 35;
            this.label7.Text = "Person Group Display Name (optional)";
            // 
            // label6
            // 
            this.label6.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(16, 23);
            this.label6.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(322, 25);
            this.label6.TabIndex = 33;
            this.label6.Text = "Person Group ID (Alphanumeric)";
            // 
            // tabCameras
            // 
            this.tabCameras.Controls.Add(this.label22);
            this.tabCameras.Controls.Add(this.label21);
            this.tabCameras.Controls.Add(this.cmbSelCamera);
            this.tabCameras.Controls.Add(this.cmbSelCameraNet);
            this.tabCameras.Controls.Add(this.label20);
            this.tabCameras.Controls.Add(this.txtIPCamSubChannel);
            this.tabCameras.Controls.Add(this.label19);
            this.tabCameras.Controls.Add(this.txtIPCamChannels);
            this.tabCameras.Controls.Add(this.label18);
            this.tabCameras.Controls.Add(this.label17);
            this.tabCameras.Controls.Add(this.txtDVRSubChannel);
            this.tabCameras.Controls.Add(this.label14);
            this.tabCameras.Controls.Add(this.txtAnalyzeTime);
            this.tabCameras.Controls.Add(this.label13);
            this.tabCameras.Controls.Add(this.txtIPcamPassword);
            this.tabCameras.Controls.Add(this.txtDVRChannels);
            this.tabCameras.Controls.Add(this.txtDVRPassword);
            this.tabCameras.Controls.Add(this.label12);
            this.tabCameras.Controls.Add(this.label11);
            this.tabCameras.Controls.Add(this.label10);
            this.tabCameras.Controls.Add(this.label9);
            this.tabCameras.Controls.Add(this.label8);
            this.tabCameras.Controls.Add(this.label5);
            this.tabCameras.Controls.Add(this.txtOther);
            this.tabCameras.Controls.Add(this.txtIPCamUserName);
            this.tabCameras.Controls.Add(this.txtIPCamIp);
            this.tabCameras.Controls.Add(this.txtDVRUserName);
            this.tabCameras.Controls.Add(this.txtDVRIP);
            this.tabCameras.Location = new System.Drawing.Point(8, 39);
            this.tabCameras.Margin = new System.Windows.Forms.Padding(4);
            this.tabCameras.Name = "tabCameras";
            this.tabCameras.Size = new System.Drawing.Size(964, 543);
            this.tabCameras.TabIndex = 2;
            this.tabCameras.Text = "Cameras";
            this.tabCameras.UseVisualStyleBackColor = true;
            // 
            // label22
            // 
            this.label22.AutoSize = true;
            this.label22.Location = new System.Drawing.Point(18, 215);
            this.label22.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label22.Name = "label22";
            this.label22.Size = new System.Drawing.Size(153, 25);
            this.label22.TabIndex = 45;
            this.label22.Text = "Select Camera";
            // 
            // label21
            // 
            this.label21.AutoSize = true;
            this.label21.Location = new System.Drawing.Point(18, 35);
            this.label21.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label21.Name = "label21";
            this.label21.Size = new System.Drawing.Size(237, 25);
            this.label21.TabIndex = 44;
            this.label21.Text = "Select Camera Network";
            // 
            // cmbSelCamera
            // 
            this.cmbSelCamera.DataBindings.Add(new System.Windows.Forms.Binding("Text", global::GetImageMetaData.Properties.Settings.Default, "selCamera", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.cmbSelCamera.FormattingEnabled = true;
            this.cmbSelCamera.Items.AddRange(new object[] {
            "Amcrest",
            "Ring"});
            this.cmbSelCamera.Location = new System.Drawing.Point(266, 206);
            this.cmbSelCamera.Margin = new System.Windows.Forms.Padding(4);
            this.cmbSelCamera.Name = "cmbSelCamera";
            this.cmbSelCamera.Size = new System.Drawing.Size(460, 33);
            this.cmbSelCamera.TabIndex = 43;
            this.cmbSelCamera.Text = "Select Camera";
            // 
            // cmbSelCameraNet
            // 
            this.cmbSelCameraNet.DataBindings.Add(new System.Windows.Forms.Binding("Text", global::GetImageMetaData.Properties.Settings.Default, "selCameraNetwork", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.cmbSelCameraNet.FormattingEnabled = true;
            this.cmbSelCameraNet.Items.AddRange(new object[] {
            "Amcrest",
            "Ring"});
            this.cmbSelCameraNet.Location = new System.Drawing.Point(266, 25);
            this.cmbSelCameraNet.Margin = new System.Windows.Forms.Padding(4);
            this.cmbSelCameraNet.Name = "cmbSelCameraNet";
            this.cmbSelCameraNet.Size = new System.Drawing.Size(460, 33);
            this.cmbSelCameraNet.TabIndex = 42;
            this.cmbSelCameraNet.Text = "Select Camera Network";
            // 
            // label20
            // 
            this.label20.AutoSize = true;
            this.label20.Location = new System.Drawing.Point(860, 260);
            this.label20.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label20.Name = "label20";
            this.label20.Size = new System.Drawing.Size(86, 25);
            this.label20.TabIndex = 41;
            this.label20.Text = "Sub CH";
            // 
            // txtIPCamSubChannel
            // 
            this.txtIPCamSubChannel.DataBindings.Add(new System.Windows.Forms.Binding("Text", global::GetImageMetaData.Properties.Settings.Default, "ipCameraSubChannel", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.txtIPCamSubChannel.Location = new System.Drawing.Point(866, 287);
            this.txtIPCamSubChannel.Margin = new System.Windows.Forms.Padding(4);
            this.txtIPCamSubChannel.Name = "txtIPCamSubChannel";
            this.txtIPCamSubChannel.Size = new System.Drawing.Size(78, 31);
            this.txtIPCamSubChannel.TabIndex = 40;
            this.txtIPCamSubChannel.Text = "0";
            // 
            // label19
            // 
            this.label19.AutoSize = true;
            this.label19.Location = new System.Drawing.Point(758, 260);
            this.label19.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label19.Name = "label19";
            this.label19.Size = new System.Drawing.Size(53, 25);
            this.label19.TabIndex = 39;
            this.label19.Text = "CHs";
            // 
            // txtIPCamChannels
            // 
            this.txtIPCamChannels.DataBindings.Add(new System.Windows.Forms.Binding("Text", global::GetImageMetaData.Properties.Settings.Default, "ipCameraChannels", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.txtIPCamChannels.Location = new System.Drawing.Point(762, 287);
            this.txtIPCamChannels.Margin = new System.Windows.Forms.Padding(4);
            this.txtIPCamChannels.Name = "txtIPCamChannels";
            this.txtIPCamChannels.Size = new System.Drawing.Size(70, 31);
            this.txtIPCamChannels.TabIndex = 38;
            this.txtIPCamChannels.Text = "0";
            // 
            // label18
            // 
            this.label18.AutoSize = true;
            this.label18.Location = new System.Drawing.Point(18, 358);
            this.label18.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label18.Name = "label18";
            this.label18.Size = new System.Drawing.Size(220, 25);
            this.label18.TabIndex = 37;
            this.label18.Text = "Other Camera Stream";
            // 
            // label17
            // 
            this.label17.AutoSize = true;
            this.label17.Location = new System.Drawing.Point(858, 94);
            this.label17.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(86, 25);
            this.label17.TabIndex = 35;
            this.label17.Text = "Sub CH";
            // 
            // txtDVRSubChannel
            // 
            this.txtDVRSubChannel.DataBindings.Add(new System.Windows.Forms.Binding("Text", global::GetImageMetaData.Properties.Settings.Default, "dvrSubChannel", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.txtDVRSubChannel.Location = new System.Drawing.Point(862, 123);
            this.txtDVRSubChannel.Margin = new System.Windows.Forms.Padding(4);
            this.txtDVRSubChannel.Name = "txtDVRSubChannel";
            this.txtDVRSubChannel.Size = new System.Drawing.Size(78, 31);
            this.txtDVRSubChannel.TabIndex = 34;
            this.txtDVRSubChannel.Text = "0";
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Location = new System.Drawing.Point(18, 494);
            this.label14.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(412, 25);
            this.label14.TabIndex = 33;
            this.label14.Text = "Time Delay in Seconds for Video Analysis";
            // 
            // txtAnalyzeTime
            // 
            this.txtAnalyzeTime.DataBindings.Add(new System.Windows.Forms.Binding("Text", global::GetImageMetaData.Properties.Settings.Default, "timeDelay", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.txtAnalyzeTime.Location = new System.Drawing.Point(444, 494);
            this.txtAnalyzeTime.Margin = new System.Windows.Forms.Padding(4);
            this.txtAnalyzeTime.MaxLength = 3;
            this.txtAnalyzeTime.Name = "txtAnalyzeTime";
            this.txtAnalyzeTime.Size = new System.Drawing.Size(60, 31);
            this.txtAnalyzeTime.TabIndex = 32;
            this.txtAnalyzeTime.Text = "0";
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(502, 260);
            this.label13.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(181, 25);
            this.label13.TabIndex = 31;
            this.label13.Text = "IP Cam Password";
            // 
            // txtDVRChannels
            // 
            this.txtDVRChannels.DataBindings.Add(new System.Windows.Forms.Binding("Text", global::GetImageMetaData.Properties.Settings.Default, "dvrChannels", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.txtDVRChannels.Location = new System.Drawing.Point(762, 123);
            this.txtDVRChannels.Margin = new System.Windows.Forms.Padding(4);
            this.txtDVRChannels.Name = "txtDVRChannels";
            this.txtDVRChannels.Size = new System.Drawing.Size(70, 31);
            this.txtDVRChannels.TabIndex = 24;
            this.txtDVRChannels.Text = "0";
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(262, 260);
            this.label12.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(194, 25);
            this.label12.TabIndex = 29;
            this.label12.Text = "IP Cam User Name";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(18, 260);
            this.label11.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(191, 25);
            this.label11.TabIndex = 27;
            this.label11.Text = "IP Cam IP Address";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(758, 94);
            this.label10.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(53, 25);
            this.label10.TabIndex = 25;
            this.label10.Text = "CHs";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(502, 94);
            this.label9.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(156, 25);
            this.label9.TabIndex = 23;
            this.label9.Text = "DVR Password";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(262, 94);
            this.label8.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(169, 25);
            this.label8.TabIndex = 21;
            this.label8.Text = "DVR User Name";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(18, 94);
            this.label5.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(166, 25);
            this.label5.TabIndex = 19;
            this.label5.Text = "DVR IP Address";
            // 
            // chbContainerMode
            // 
            //this.chbContainerMode.DataBindings.Add(new System.Windows.Forms.Binding("Bool", global::GetImageMetaData.Properties.Settings.Default, "useContainerMode", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.chbContainerMode.AutoSize = true;
            this.chbContainerMode.Location = new System.Drawing.Point(30, 403);
            this.chbContainerMode.Name = "chbContainerMode";
            this.chbContainerMode.Size = new System.Drawing.Size(264, 29);
            this.chbContainerMode.TabIndex = 39;
            this.chbContainerMode.Text = "Use in Container Mode";
            this.chbContainerMode.UseVisualStyleBackColor = true;
            this.chbContainerMode.CheckedChanged += new System.EventHandler(this.ChbContainerMode_CheckedChanged);
            this.chbContainerMode.Checked = global::GetImageMetaData.Properties.Settings.Default.useContainerMode;
            // 
            // txtCognitiveServicesAPIKey
            // 
            this.txtCognitiveServicesAPIKey.DataBindings.Add(new System.Windows.Forms.Binding("Text", global::GetImageMetaData.Properties.Settings.Default, "cognitiveServicesKey", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.txtCognitiveServicesAPIKey.Location = new System.Drawing.Point(32, 60);
            this.txtCognitiveServicesAPIKey.Margin = new System.Windows.Forms.Padding(4);
            this.txtCognitiveServicesAPIKey.Name = "txtCognitiveServicesAPIKey";
            this.txtCognitiveServicesAPIKey.PasswordChar = '*';
            this.txtCognitiveServicesAPIKey.Size = new System.Drawing.Size(728, 31);
            this.txtCognitiveServicesAPIKey.TabIndex = 34;
            this.txtCognitiveServicesAPIKey.Text = global::GetImageMetaData.Properties.Settings.Default.cognitiveServicesKey;
            // 
            // txtCognitiveServicesEndpoint
            // 
            this.txtCognitiveServicesEndpoint.DataBindings.Add(new System.Windows.Forms.Binding("Text", global::GetImageMetaData.Properties.Settings.Default, "cognitiveServicesEndpoint", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.txtCognitiveServicesEndpoint.Location = new System.Drawing.Point(30, 146);
            this.txtCognitiveServicesEndpoint.Margin = new System.Windows.Forms.Padding(4);
            this.txtCognitiveServicesEndpoint.Name = "txtCognitiveServicesEndpoint";
            this.txtCognitiveServicesEndpoint.Size = new System.Drawing.Size(728, 31);
            this.txtCognitiveServicesEndpoint.TabIndex = 36;
            this.txtCognitiveServicesEndpoint.Text = global::GetImageMetaData.Properties.Settings.Default.cognitiveServicesEndpoint;
            // 
            // cmbPersonGroups
            // 
            this.cmbPersonGroups.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.cmbPersonGroups.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest;
            this.cmbPersonGroups.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cmbPersonGroups.DataBindings.Add(new System.Windows.Forms.Binding("text", global::GetImageMetaData.Properties.Settings.Default, "personGroupID", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.cmbPersonGroups.FormattingEnabled = true;
            this.cmbPersonGroups.Location = new System.Drawing.Point(20, 54);
            this.cmbPersonGroups.Margin = new System.Windows.Forms.Padding(4);
            this.cmbPersonGroups.Name = "cmbPersonGroups";
            this.cmbPersonGroups.Size = new System.Drawing.Size(366, 33);
            this.cmbPersonGroups.TabIndex = 36;
            this.cmbPersonGroups.Text = global::GetImageMetaData.Properties.Settings.Default.personGroupID;
            // 
            // txtPersonGroupDisplay
            // 
            this.txtPersonGroupDisplay.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.txtPersonGroupDisplay.DataBindings.Add(new System.Windows.Forms.Binding("Text", global::GetImageMetaData.Properties.Settings.Default, "personGroupName", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.txtPersonGroupDisplay.Location = new System.Drawing.Point(22, 160);
            this.txtPersonGroupDisplay.Margin = new System.Windows.Forms.Padding(4);
            this.txtPersonGroupDisplay.Name = "txtPersonGroupDisplay";
            this.txtPersonGroupDisplay.Size = new System.Drawing.Size(366, 31);
            this.txtPersonGroupDisplay.TabIndex = 34;
            this.txtPersonGroupDisplay.Text = global::GetImageMetaData.Properties.Settings.Default.personGroupName;
            // 
            // txtIPcamPassword
            // 
            this.txtIPcamPassword.DataBindings.Add(new System.Windows.Forms.Binding("Text", global::GetImageMetaData.Properties.Settings.Default, "ipCameraPassword", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.txtIPcamPassword.Location = new System.Drawing.Point(508, 287);
            this.txtIPcamPassword.Margin = new System.Windows.Forms.Padding(4);
            this.txtIPcamPassword.Name = "txtIPcamPassword";
            this.txtIPcamPassword.PasswordChar = '*';
            this.txtIPcamPassword.Size = new System.Drawing.Size(218, 31);
            this.txtIPcamPassword.TabIndex = 30;
            this.txtIPcamPassword.Text = global::GetImageMetaData.Properties.Settings.Default.ipCameraPassword;
            // 
            // txtDVRPassword
            // 
            this.txtDVRPassword.DataBindings.Add(new System.Windows.Forms.Binding("Text", global::GetImageMetaData.Properties.Settings.Default, "dvrPassword", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.txtDVRPassword.Location = new System.Drawing.Point(508, 123);
            this.txtDVRPassword.Margin = new System.Windows.Forms.Padding(4);
            this.txtDVRPassword.Name = "txtDVRPassword";
            this.txtDVRPassword.PasswordChar = '*';
            this.txtDVRPassword.Size = new System.Drawing.Size(218, 31);
            this.txtDVRPassword.TabIndex = 22;
            this.txtDVRPassword.Text = global::GetImageMetaData.Properties.Settings.Default.dvrPassword;
            // 
            // txtOther
            // 
            this.txtOther.DataBindings.Add(new System.Windows.Forms.Binding("Text", global::GetImageMetaData.Properties.Settings.Default, "otherVideoSource", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.txtOther.Location = new System.Drawing.Point(24, 402);
            this.txtOther.Margin = new System.Windows.Forms.Padding(4);
            this.txtOther.Name = "txtOther";
            this.txtOther.Size = new System.Drawing.Size(926, 31);
            this.txtOther.TabIndex = 36;
            this.txtOther.Text = global::GetImageMetaData.Properties.Settings.Default.otherVideoSource;
            // 
            // txtIPCamUserName
            // 
            this.txtIPCamUserName.DataBindings.Add(new System.Windows.Forms.Binding("Text", global::GetImageMetaData.Properties.Settings.Default, "ipCameraUserName", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.txtIPCamUserName.Location = new System.Drawing.Point(266, 287);
            this.txtIPCamUserName.Margin = new System.Windows.Forms.Padding(4);
            this.txtIPCamUserName.Name = "txtIPCamUserName";
            this.txtIPCamUserName.Size = new System.Drawing.Size(218, 31);
            this.txtIPCamUserName.TabIndex = 28;
            this.txtIPCamUserName.Text = global::GetImageMetaData.Properties.Settings.Default.ipCameraUserName;
            // 
            // txtIPCamIp
            // 
            this.txtIPCamIp.DataBindings.Add(new System.Windows.Forms.Binding("Text", global::GetImageMetaData.Properties.Settings.Default, "ipCameraIP", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.txtIPCamIp.Location = new System.Drawing.Point(24, 287);
            this.txtIPCamIp.Margin = new System.Windows.Forms.Padding(4);
            this.txtIPCamIp.Name = "txtIPCamIp";
            this.txtIPCamIp.Size = new System.Drawing.Size(218, 31);
            this.txtIPCamIp.TabIndex = 26;
            this.txtIPCamIp.Text = global::GetImageMetaData.Properties.Settings.Default.ipCameraIP;
            // 
            // txtDVRUserName
            // 
            this.txtDVRUserName.DataBindings.Add(new System.Windows.Forms.Binding("Text", global::GetImageMetaData.Properties.Settings.Default, "dvrUserName", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.txtDVRUserName.Location = new System.Drawing.Point(266, 123);
            this.txtDVRUserName.Margin = new System.Windows.Forms.Padding(4);
            this.txtDVRUserName.Name = "txtDVRUserName";
            this.txtDVRUserName.Size = new System.Drawing.Size(218, 31);
            this.txtDVRUserName.TabIndex = 20;
            this.txtDVRUserName.Text = global::GetImageMetaData.Properties.Settings.Default.dvrUserName;
            // 
            // txtDVRIP
            // 
            this.txtDVRIP.DataBindings.Add(new System.Windows.Forms.Binding("Text", global::GetImageMetaData.Properties.Settings.Default, "dvrIP", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.txtDVRIP.Location = new System.Drawing.Point(24, 123);
            this.txtDVRIP.Margin = new System.Windows.Forms.Padding(4);
            this.txtDVRIP.Name = "txtDVRIP";
            this.txtDVRIP.Size = new System.Drawing.Size(218, 31);
            this.txtDVRIP.TabIndex = 18;
            this.txtDVRIP.Text = global::GetImageMetaData.Properties.Settings.Default.dvrIP;
            // 
            // txtCosmosDataBasePrimConString
            // 
            this.txtCosmosDataBasePrimConString.DataBindings.Add(new System.Windows.Forms.Binding("Text", global::GetImageMetaData.Properties.Settings.Default, "cosmosPrimaryConString", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.txtCosmosDataBasePrimConString.Location = new System.Drawing.Point(22, 237);
            this.txtCosmosDataBasePrimConString.Margin = new System.Windows.Forms.Padding(4);
            this.txtCosmosDataBasePrimConString.Name = "txtCosmosDataBasePrimConString";
            this.txtCosmosDataBasePrimConString.PasswordChar = '*';
            this.txtCosmosDataBasePrimConString.Size = new System.Drawing.Size(728, 31);
            this.txtCosmosDataBasePrimConString.TabIndex = 29;
            this.txtCosmosDataBasePrimConString.Text = global::GetImageMetaData.Properties.Settings.Default.cosmosPrimaryConString;
            // 
            // txtCosmosDataBasePrimKey
            // 
            this.txtCosmosDataBasePrimKey.DataBindings.Add(new System.Windows.Forms.Binding("Text", global::GetImageMetaData.Properties.Settings.Default, "cosmosPrimaryKey", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.txtCosmosDataBasePrimKey.Location = new System.Drawing.Point(22, 144);
            this.txtCosmosDataBasePrimKey.Margin = new System.Windows.Forms.Padding(4);
            this.txtCosmosDataBasePrimKey.Name = "txtCosmosDataBasePrimKey";
            this.txtCosmosDataBasePrimKey.PasswordChar = '*';
            this.txtCosmosDataBasePrimKey.Size = new System.Drawing.Size(728, 31);
            this.txtCosmosDataBasePrimKey.TabIndex = 27;
            this.txtCosmosDataBasePrimKey.Text = global::GetImageMetaData.Properties.Settings.Default.cosmosPrimaryKey;
            // 
            // txtCosmosDataBaseURI
            // 
            this.txtCosmosDataBaseURI.DataBindings.Add(new System.Windows.Forms.Binding("Text", global::GetImageMetaData.Properties.Settings.Default, "cosmosDataBaseURI", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.txtCosmosDataBaseURI.Location = new System.Drawing.Point(22, 56);
            this.txtCosmosDataBaseURI.Margin = new System.Windows.Forms.Padding(4);
            this.txtCosmosDataBaseURI.Name = "txtCosmosDataBaseURI";
            this.txtCosmosDataBaseURI.Size = new System.Drawing.Size(728, 31);
            this.txtCosmosDataBaseURI.TabIndex = 25;
            this.txtCosmosDataBaseURI.Text = global::GetImageMetaData.Properties.Settings.Default.cosmosDataBaseURI;
            // 
            // FrmOptions
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(12F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.cmdCancel;
            this.ClientSize = new System.Drawing.Size(1038, 687);
            this.Controls.Add(this.cmdCancel);
            this.Controls.Add(this.cmdSave);
            this.Controls.Add(this.tabControl1);
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "FrmOptions";
            this.Text = "Options";
            this.tabAzureCosmosDB.ResumeLayout(false);
            this.tabAzureCosmosDB.PerformLayout();
            this.tabControl1.ResumeLayout(false);
            this.tabCognitiveServicesAPI.ResumeLayout(false);
            this.tabCognitiveServicesAPI.PerformLayout();
            this.tabPersonGroups.ResumeLayout(false);
            this.tabPersonGroups.PerformLayout();
            this.tabCameras.ResumeLayout(false);
            this.tabCameras.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Button cmdSave;
        private System.Windows.Forms.Button cmdCancel;
        private System.Windows.Forms.TabPage tabAzureCosmosDB;
        private System.Windows.Forms.TabPage tabCameras;
        private System.Windows.Forms.Label label22;
        private System.Windows.Forms.Label label21;
        private System.Windows.Forms.ComboBox cmbSelCamera;
        private System.Windows.Forms.ComboBox cmbSelCameraNet;
        private System.Windows.Forms.Label label20;
        private System.Windows.Forms.TextBox txtIPCamSubChannel;
        private System.Windows.Forms.Label label19;
        private System.Windows.Forms.TextBox txtIPCamChannels;
        private System.Windows.Forms.Label label18;
        private System.Windows.Forms.TextBox txtOther;
        private System.Windows.Forms.Label label17;
        private System.Windows.Forms.TextBox txtDVRSubChannel;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.TextBox txtAnalyzeTime;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.TextBox txtIPcamPassword;
        private System.Windows.Forms.TextBox txtDVRChannels;
        private System.Windows.Forms.TextBox txtDVRPassword;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txtIPCamUserName;
        private System.Windows.Forms.TextBox txtIPCamIp;
        private System.Windows.Forms.TextBox txtDVRUserName;
        private System.Windows.Forms.TextBox txtDVRIP;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TextBox txtCosmosDataBasePrimConString;
        private System.Windows.Forms.Label label28;
        private System.Windows.Forms.Label label29;
        private System.Windows.Forms.TextBox txtCosmosDataBasePrimKey;
        private System.Windows.Forms.TextBox txtCosmosDataBaseURI;
        private System.Windows.Forms.Label label30;
        private System.Windows.Forms.TabPage tabPersonGroups;
        private System.Windows.Forms.Button cmdDeleteGroup;
        private System.Windows.Forms.Button cmdUpdate;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label6;
        public System.Windows.Forms.ComboBox cmbPersonGroups;
        private System.Windows.Forms.TextBox txtPersonGroupDisplay;
        private System.Windows.Forms.Label label16;
        private System.Windows.Forms.Button cmdSetColor;
        private System.Windows.Forms.ColorDialog colorDialog1;
        private System.Windows.Forms.Button cmdUpdateGroup;
        private System.Windows.Forms.TabPage tabCognitiveServicesAPI;
        private System.Windows.Forms.Label label27;
        private System.Windows.Forms.Label label31;
        private System.Windows.Forms.Label label32;
        private System.Windows.Forms.TextBox txtCognitiveServicesAPIKey;
        private System.Windows.Forms.TextBox txtCognitiveServicesEndpoint;
        private System.Windows.Forms.CheckBox chbContainerMode;
    }
}
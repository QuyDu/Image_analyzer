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
    partial class FrmMain
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
            this.components = new System.ComponentModel.Container();
            this.buildYourProfilesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.cmbCameraMode = new System.Windows.Forms.ComboBox();
            this.cmbSource = new System.Windows.Forms.ComboBox();
            this.cmdAnalyze = new System.Windows.Forms.Button();
            this.cmdBrowse = new System.Windows.Forms.Button();
            this.cmdRotateImg = new System.Windows.Forms.Button();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.menuItemAddFace = new System.Windows.Forms.ToolStripMenuItem();
            this.enterYourAzureKeysToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.exitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.gettingStartedToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.getYourAzureKeysToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.howToToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.trainYourProfilesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.scanAToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.toolsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.optionsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolsToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.trainFromWebToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.trainFromO365StripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.statusLabel = new System.Windows.Forms.ToolStripStatusLabel();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.tooltipFace = new System.Windows.Forms.ToolTip(this.components);
            this.txtDescription = new System.Windows.Forms.TextBox();
            this.txtFaceNames = new System.Windows.Forms.TextBox();
            this.txtPicFilename = new System.Windows.Forms.TextBox();
            this.txtResults = new System.Windows.Forms.TextBox();
            this.categorizeFilesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.menuItemDeleteFace = new System.Windows.Forms.ToolStripMenuItem();
            this.picViewResult = new System.Windows.Forms.PictureBox();
            this.picPreview = new System.Windows.Forms.PictureBox();
            this.lstLog = new System.Windows.Forms.ListBox();
            this.contextMenuStrip1.SuspendLayout();
            this.menuStrip1.SuspendLayout();
            this.statusStrip1.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picViewResult)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picPreview)).BeginInit();
            this.SuspendLayout();
            // 
            // buildYourProfilesToolStripMenuItem
            // 
            this.buildYourProfilesToolStripMenuItem.Name = "buildYourProfilesToolStripMenuItem";
            this.buildYourProfilesToolStripMenuItem.Size = new System.Drawing.Size(390, 38);
            this.buildYourProfilesToolStripMenuItem.Text = "Build Your Profiles";
            // 
            // cmbCameraMode
            // 
            this.cmbCameraMode.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.cmbCameraMode.FormattingEnabled = true;
            this.cmbCameraMode.Items.AddRange(new object[] {
            "Manual",
            "Auto"});
            this.cmbCameraMode.Location = new System.Drawing.Point(1279, 90);
            this.cmbCameraMode.Margin = new System.Windows.Forms.Padding(4);
            this.cmbCameraMode.Name = "cmbCameraMode";
            this.cmbCameraMode.Size = new System.Drawing.Size(328, 33);
            this.cmbCameraMode.TabIndex = 31;
            this.cmbCameraMode.Text = "Manual";
            this.cmbCameraMode.Visible = false;
            this.cmbCameraMode.SelectedIndexChanged += new System.EventHandler(this.cmbCameraMode_SelectedIndexChanged);
            // 
            // cmbSource
            // 
            this.cmbSource.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.cmbSource.FormattingEnabled = true;
            this.cmbSource.Items.AddRange(new object[] {
            "File"});
            this.cmbSource.Location = new System.Drawing.Point(980, 89);
            this.cmbSource.Margin = new System.Windows.Forms.Padding(4);
            this.cmbSource.Name = "cmbSource";
            this.cmbSource.Size = new System.Drawing.Size(287, 33);
            this.cmbSource.TabIndex = 24;
            this.cmbSource.Text = "File";
            this.cmbSource.SelectedIndexChanged += new System.EventHandler(this.CmbSource_SelectedIndexChangedAsync);
            // 
            // cmdAnalyze
            // 
            this.cmdAnalyze.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.cmdAnalyze.Enabled = false;
            this.cmdAnalyze.Location = new System.Drawing.Point(1619, 78);
            this.cmdAnalyze.Margin = new System.Windows.Forms.Padding(4);
            this.cmdAnalyze.Name = "cmdAnalyze";
            this.cmdAnalyze.Size = new System.Drawing.Size(253, 56);
            this.cmdAnalyze.TabIndex = 4;
            this.cmdAnalyze.Text = "Analyze";
            this.cmdAnalyze.UseVisualStyleBackColor = true;
            this.cmdAnalyze.Click += new System.EventHandler(this.CmdAnalyze_Click);
            // 
            // cmdBrowse
            // 
            this.cmdBrowse.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.cmdBrowse.Location = new System.Drawing.Point(1279, 78);
            this.cmdBrowse.Margin = new System.Windows.Forms.Padding(4);
            this.cmdBrowse.Name = "cmdBrowse";
            this.cmdBrowse.Size = new System.Drawing.Size(220, 56);
            this.cmdBrowse.TabIndex = 2;
            this.cmdBrowse.Text = "Choose File...";
            this.cmdBrowse.UseVisualStyleBackColor = true;
            this.cmdBrowse.Click += new System.EventHandler(this.CmdBrowse_ClickAsync);
            // 
            // cmdRotateImg
            // 
            this.cmdRotateImg.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.cmdRotateImg.Location = new System.Drawing.Point(1507, 78);
            this.cmdRotateImg.Margin = new System.Windows.Forms.Padding(4);
            this.cmdRotateImg.Name = "cmdRotateImg";
            this.cmdRotateImg.Size = new System.Drawing.Size(101, 56);
            this.cmdRotateImg.TabIndex = 29;
            this.cmdRotateImg.Text = "Rotate";
            this.cmdRotateImg.UseVisualStyleBackColor = true;
            this.cmdRotateImg.Click += new System.EventHandler(this.CmdRotateImg_Click);
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.ImageScalingSize = new System.Drawing.Size(24, 24);
            this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.menuItemAddFace,
            this.menuItemDeleteFace});
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(215, 76);
            this.contextMenuStrip1.ItemClicked += new System.Windows.Forms.ToolStripItemClickedEventHandler(this.ContextMenuStrip1_ItemClickedAsync);
            // 
            // menuItemAddFace
            // 
            this.menuItemAddFace.Name = "menuItemAddFace";
            this.menuItemAddFace.Size = new System.Drawing.Size(214, 36);
            this.menuItemAddFace.Text = "Add Face";
            // 
            // enterYourAzureKeysToolStripMenuItem
            // 
            this.enterYourAzureKeysToolStripMenuItem.Name = "enterYourAzureKeysToolStripMenuItem";
            this.enterYourAzureKeysToolStripMenuItem.Size = new System.Drawing.Size(347, 38);
            this.enterYourAzureKeysToolStripMenuItem.Text = "Enter Your Azure Keys";
            // 
            // exitToolStripMenuItem
            // 
            this.exitToolStripMenuItem.Name = "exitToolStripMenuItem";
            this.exitToolStripMenuItem.Size = new System.Drawing.Size(151, 38);
            this.exitToolStripMenuItem.Text = "E&xit";
            this.exitToolStripMenuItem.Click += new System.EventHandler(this.ExitToolStripMenuItem_Click);
            // 
            // fileToolStripMenuItem
            // 
            this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.exitToolStripMenuItem});
            this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            this.fileToolStripMenuItem.Size = new System.Drawing.Size(64, 36);
            this.fileToolStripMenuItem.Text = "&File";
            // 
            // gettingStartedToolStripMenuItem
            // 
            this.gettingStartedToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.getYourAzureKeysToolStripMenuItem,
            this.enterYourAzureKeysToolStripMenuItem,
            this.howToToolStripMenuItem});
            this.gettingStartedToolStripMenuItem.Name = "gettingStartedToolStripMenuItem";
            this.gettingStartedToolStripMenuItem.Size = new System.Drawing.Size(188, 36);
            this.gettingStartedToolStripMenuItem.Text = "&Getting Started";
            // 
            // getYourAzureKeysToolStripMenuItem
            // 
            this.getYourAzureKeysToolStripMenuItem.Name = "getYourAzureKeysToolStripMenuItem";
            this.getYourAzureKeysToolStripMenuItem.Size = new System.Drawing.Size(347, 38);
            this.getYourAzureKeysToolStripMenuItem.Text = "Get Your Azure Keys";
            // 
            // howToToolStripMenuItem
            // 
            this.howToToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.buildYourProfilesToolStripMenuItem,
            this.trainYourProfilesToolStripMenuItem,
            this.scanAToolStripMenuItem});
            this.howToToolStripMenuItem.Name = "howToToolStripMenuItem";
            this.howToToolStripMenuItem.Size = new System.Drawing.Size(347, 38);
            this.howToToolStripMenuItem.Text = "How To";
            // 
            // trainYourProfilesToolStripMenuItem
            // 
            this.trainYourProfilesToolStripMenuItem.Name = "trainYourProfilesToolStripMenuItem";
            this.trainYourProfilesToolStripMenuItem.Size = new System.Drawing.Size(390, 38);
            this.trainYourProfilesToolStripMenuItem.Text = "Train Your Profiles";
            // 
            // scanAToolStripMenuItem
            // 
            this.scanAToolStripMenuItem.Name = "scanAToolStripMenuItem";
            this.scanAToolStripMenuItem.Size = new System.Drawing.Size(390, 38);
            this.scanAToolStripMenuItem.Text = "Scan a Folder or Directory";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(11, 58);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(137, 25);
            this.label1.TabIndex = 0;
            this.label1.Text = "Selected File";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(11, 135);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(84, 25);
            this.label2.TabIndex = 5;
            this.label2.Text = "Results";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(11, 210);
            this.label4.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(142, 25);
            this.label4.TabIndex = 15;
            this.label4.Text = "Known Faces";
            // 
            // label7
            // 
            this.label7.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(975, 60);
            this.label7.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(80, 25);
            this.label7.TabIndex = 25;
            this.label7.Text = "Source";
            // 
            // menuStrip1
            // 
            this.menuStrip1.BackColor = System.Drawing.SystemColors.Control;
            this.menuStrip1.ImageScalingSize = new System.Drawing.Size(32, 32);
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem,
            this.toolsToolStripMenuItem,
            this.toolsToolStripMenuItem1,
            this.gettingStartedToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Padding = new System.Windows.Forms.Padding(5, 2, 0, 2);
            this.menuStrip1.Size = new System.Drawing.Size(1899, 40);
            this.menuStrip1.TabIndex = 14;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // toolsToolStripMenuItem
            // 
            this.toolsToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.optionsToolStripMenuItem});
            this.toolsToolStripMenuItem.Name = "toolsToolStripMenuItem";
            this.toolsToolStripMenuItem.Size = new System.Drawing.Size(113, 36);
            this.toolsToolStripMenuItem.Text = "&Settings";
            //this.toolsToolStripMenuItem.Click += new System.EventHandler(this.ToolsToolStripMenuItem_Click);
            // 
            // optionsToolStripMenuItem
            // 
            this.optionsToolStripMenuItem.Name = "optionsToolStripMenuItem";
            this.optionsToolStripMenuItem.Size = new System.Drawing.Size(198, 38);
            this.optionsToolStripMenuItem.Text = "Options";
            this.optionsToolStripMenuItem.Click += new System.EventHandler(this.OptionsToolStripMenuItem_Click);
            // 
            // toolsToolStripMenuItem1
            // 
            this.toolsToolStripMenuItem1.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.trainFromWebToolStripMenuItem,
            this.trainFromO365StripMenuItem,
            this.categorizeFilesToolStripMenuItem});
            this.toolsToolStripMenuItem1.Name = "toolsToolStripMenuItem1";
            this.toolsToolStripMenuItem1.Size = new System.Drawing.Size(82, 36);
            this.toolsToolStripMenuItem1.Text = "&Tools";
            // 
            // trainFromWebToolStripMenuItem
            // 
            this.trainFromWebToolStripMenuItem.Name = "trainFromWebToolStripMenuItem";
            this.trainFromWebToolStripMenuItem.Size = new System.Drawing.Size(287, 38);
            this.trainFromWebToolStripMenuItem.Text = "Train from Web";
            this.trainFromWebToolStripMenuItem.Click += new System.EventHandler(this.trainFromWebToolStripMenuItem_Click);
            // 
            // trainFromO365StripMenuItem
            // 
            this.trainFromO365StripMenuItem.Name = "trainFromO365StripMenuItem";
            this.trainFromO365StripMenuItem.Size = new System.Drawing.Size(287, 38);
            this.trainFromO365StripMenuItem.Text = "Train from O365";
            this.trainFromO365StripMenuItem.Click += new System.EventHandler(this.trainFromO365StripMenuItem_Click);
            // 
            // statusLabel
            // 
            this.statusLabel.Name = "statusLabel";
            this.statusLabel.Size = new System.Drawing.Size(1839, 32);
            this.statusLabel.Spring = true;
            this.statusLabel.Text = "toolStripStatusLabel1";
            // 
            // statusStrip1
            // 
            this.statusStrip1.ImageScalingSize = new System.Drawing.Size(32, 32);
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.statusLabel});
            this.statusStrip1.Location = new System.Drawing.Point(0, 1291);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Padding = new System.Windows.Forms.Padding(4, 0, 56, 0);
            this.statusStrip1.Size = new System.Drawing.Size(1899, 37);
            this.statusStrip1.TabIndex = 22;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
            | System.Windows.Forms.AnchorStyles.Left)
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tableLayoutPanel1.ColumnCount = 2;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.Controls.Add(this.picViewResult, 1, 0);
            this.tableLayoutPanel1.Controls.Add(this.picPreview, 0, 0);
            this.tableLayoutPanel1.Location = new System.Drawing.Point(508, 286);
            this.tableLayoutPanel1.Margin = new System.Windows.Forms.Padding(4);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 1;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(1355, 822);
            this.tableLayoutPanel1.TabIndex = 30;
            // 
            // tooltipFace
            // 
            this.tooltipFace.AutoPopDelay = 5000;
            this.tooltipFace.InitialDelay = 1000;
            this.tooltipFace.ReshowDelay = 100;
            // 
            // txtDescription
            // 
            this.txtDescription.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtDescription.Location = new System.Drawing.Point(16, 164);
            this.txtDescription.Margin = new System.Windows.Forms.Padding(4);
            this.txtDescription.Name = "txtDescription";
            this.txtDescription.ReadOnly = true;
            this.txtDescription.Size = new System.Drawing.Size(1855, 31);
            this.txtDescription.TabIndex = 7;
            // 
            // txtFaceNames
            // 
            this.txtFaceNames.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtFaceNames.Location = new System.Drawing.Point(16, 239);
            this.txtFaceNames.Margin = new System.Windows.Forms.Padding(4);
            this.txtFaceNames.Name = "txtFaceNames";
            this.txtFaceNames.ReadOnly = true;
            this.txtFaceNames.Size = new System.Drawing.Size(1855, 31);
            this.txtFaceNames.TabIndex = 16;
            // 
            // txtPicFilename
            // 
            this.txtPicFilename.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtPicFilename.Location = new System.Drawing.Point(16, 90);
            this.txtPicFilename.Margin = new System.Windows.Forms.Padding(4);
            this.txtPicFilename.Name = "txtPicFilename";
            this.txtPicFilename.Size = new System.Drawing.Size(955, 31);
            this.txtPicFilename.TabIndex = 1;
            // 
            // txtResults
            // 
            this.txtResults.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
            | System.Windows.Forms.AnchorStyles.Left)));
            this.txtResults.Location = new System.Drawing.Point(16, 286);
            this.txtResults.Margin = new System.Windows.Forms.Padding(4);
            this.txtResults.Multiline = true;
            this.txtResults.Name = "txtResults";
            this.txtResults.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtResults.Size = new System.Drawing.Size(463, 823);
            this.txtResults.TabIndex = 6;
            // 
            // categorizeFilesToolStripMenuItem
            // 
            this.categorizeFilesToolStripMenuItem.Name = "categorizeFilesToolStripMenuItem";
            this.categorizeFilesToolStripMenuItem.Size = new System.Drawing.Size(287, 38);
            this.categorizeFilesToolStripMenuItem.Text = "Categorize Files";
            this.categorizeFilesToolStripMenuItem.Click += new System.EventHandler(this.categorizeFilesToolStripMenuItem_Click);
            // 
            // menuItemDeleteFace
            // 
            this.menuItemDeleteFace.Name = "menuItemDeleteFace";
            this.menuItemDeleteFace.Size = new System.Drawing.Size(214, 36);
            this.menuItemDeleteFace.Text = "Delete Face";
            // 
            // picViewResult
            // 
            this.picViewResult.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
            | System.Windows.Forms.AnchorStyles.Left)
            | System.Windows.Forms.AnchorStyles.Right)));
            this.picViewResult.BackColor = System.Drawing.SystemColors.Window;
            this.picViewResult.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.picViewResult.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.picViewResult.Location = new System.Drawing.Point(681, 4);
            this.picViewResult.Margin = new System.Windows.Forms.Padding(4);
            this.picViewResult.Name = "picViewResult";
            this.picViewResult.Size = new System.Drawing.Size(670, 814);
            this.picViewResult.TabIndex = 10;
            this.picViewResult.TabStop = false;
            //this.picViewResult.MouseHover += new System.EventHandler(this.PicView_MouseHover);
            this.picViewResult.MouseMove += new System.Windows.Forms.MouseEventHandler(this.PicView_MouseMove);
            // 
            // picPreview
            // 
            this.picPreview.BackColor = System.Drawing.SystemColors.Window;
            this.picPreview.Dock = System.Windows.Forms.DockStyle.Fill;
            this.picPreview.Location = new System.Drawing.Point(4, 4);
            this.picPreview.Margin = new System.Windows.Forms.Padding(4);
            this.picPreview.Name = "picPreview";
            this.picPreview.Size = new System.Drawing.Size(669, 814);
            this.picPreview.TabIndex = 11;
            this.picPreview.TabStop = false;
            // 
            // lstLog
            // 
            this.lstLog.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lstLog.FormattingEnabled = true;
            this.lstLog.ItemHeight = 25;
            this.lstLog.Location = new System.Drawing.Point(16, 1123);
            this.lstLog.Margin = new System.Windows.Forms.Padding(12, 11, 12, 11);
            this.lstLog.Name = "lstLog";
            this.lstLog.Size = new System.Drawing.Size(1855, 154);
            this.lstLog.TabIndex = 32;
            // 
            // FrmMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(12F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Control;
            this.ClientSize = new System.Drawing.Size(1899, 1328);
            this.Controls.Add(this.lstLog);
            this.Controls.Add(this.cmbCameraMode);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Controls.Add(this.cmdRotateImg);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.cmbSource);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.txtFaceNames);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.txtDescription);
            this.Controls.Add(this.txtResults);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.cmdAnalyze);
            this.Controls.Add(this.cmdBrowse);
            this.Controls.Add(this.txtPicFilename);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "FrmMain";
            this.Text = "Image Analyzer v2.0";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Shown += new System.EventHandler(this.Form1_ShownAsync);
            this.contextMenuStrip1.ResumeLayout(false);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.tableLayoutPanel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.picViewResult)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picPreview)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtPicFilename;
        private System.Windows.Forms.Button cmdBrowse;
        private System.Windows.Forms.Button cmdAnalyze;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtResults;
        private System.Windows.Forms.TextBox txtDescription;
        private System.Windows.Forms.PictureBox picViewResult;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem exitToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem toolsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem optionsToolStripMenuItem;
        private System.Windows.Forms.TextBox txtFaceNames;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripStatusLabel statusLabel;
        private System.Windows.Forms.ToolTip tooltipFace;
        private System.Windows.Forms.ToolStripMenuItem gettingStartedToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem getYourAzureKeysToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem enterYourAzureKeysToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem howToToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem buildYourProfilesToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem trainYourProfilesToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem scanAToolStripMenuItem;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.ToolStripMenuItem menuItemAddFace;
        private System.Windows.Forms.ComboBox cmbSource;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Button cmdRotateImg;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.PictureBox picPreview;
        private System.Windows.Forms.ComboBox cmbCameraMode;
        private System.Windows.Forms.ToolStripMenuItem toolsToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem trainFromWebToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem trainFromO365StripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem categorizeFilesToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem menuItemDeleteFace;
        private System.Windows.Forms.ListBox lstLog;
    }
}
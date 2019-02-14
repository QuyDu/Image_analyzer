namespace GetImageMetaData
{
    partial class frmAddFace
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
            this.cmbPersonName = new System.Windows.Forms.ComboBox();
            this.cmdAddFace = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.cmdCancel = new System.Windows.Forms.Button();
            this.cmbPersonGroup = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // cmbPersonName
            // 
            this.cmbPersonName.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest;
            this.cmbPersonName.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cmbPersonName.FormattingEnabled = true;
            this.cmbPersonName.Location = new System.Drawing.Point(31, 114);
            this.cmbPersonName.Margin = new System.Windows.Forms.Padding(4);
            this.cmbPersonName.Name = "cmbPersonName";
            this.cmbPersonName.Size = new System.Drawing.Size(327, 33);
            this.cmbPersonName.TabIndex = 20;
            // 
            // cmdAddFace
            // 
            this.cmdAddFace.Location = new System.Drawing.Point(392, 48);
            this.cmdAddFace.Margin = new System.Windows.Forms.Padding(4);
            this.cmdAddFace.Name = "cmdAddFace";
            this.cmdAddFace.Size = new System.Drawing.Size(171, 40);
            this.cmdAddFace.TabIndex = 19;
            this.cmdAddFace.Text = "Save Name";
            this.cmdAddFace.UseVisualStyleBackColor = true;
            this.cmdAddFace.Click += new System.EventHandler(this.cmdAddFace_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(24, 85);
            this.label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(340, 25);
            this.label3.TabIndex = 18;
            this.label3.Text = "Name of person currently selected";
            // 
            // cmdCancel
            // 
            this.cmdCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.cmdCancel.Location = new System.Drawing.Point(392, 114);
            this.cmdCancel.Margin = new System.Windows.Forms.Padding(4);
            this.cmdCancel.Name = "cmdCancel";
            this.cmdCancel.Size = new System.Drawing.Size(171, 40);
            this.cmdCancel.TabIndex = 21;
            this.cmdCancel.Text = "Cancel";
            this.cmdCancel.UseVisualStyleBackColor = true;
            // 
            // cmbPersonGroup
            // 
            this.cmbPersonGroup.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest;
            this.cmbPersonGroup.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cmbPersonGroup.DisplayMember = "Name";
            this.cmbPersonGroup.FormattingEnabled = true;
            this.cmbPersonGroup.Location = new System.Drawing.Point(31, 36);
            this.cmbPersonGroup.Margin = new System.Windows.Forms.Padding(4);
            this.cmbPersonGroup.Name = "cmbPersonGroup";
            this.cmbPersonGroup.Size = new System.Drawing.Size(327, 33);
            this.cmbPersonGroup.TabIndex = 23;
            this.cmbPersonGroup.SelectedIndexChanged += new System.EventHandler(this.cmbPersonGroup_SelectedIndexChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(24, 7);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(145, 25);
            this.label1.TabIndex = 22;
            this.label1.Text = "Person Group";
            // 
            // frmAddFace
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(12F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.cmdCancel;
            this.ClientSize = new System.Drawing.Size(587, 175);
            this.Controls.Add(this.cmbPersonGroup);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.cmdCancel);
            this.Controls.Add(this.cmbPersonName);
            this.Controls.Add(this.cmdAddFace);
            this.Controls.Add(this.label3);
            this.Margin = new System.Windows.Forms.Padding(5, 6, 5, 6);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmAddFace";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Add Face";
            this.Load += new System.EventHandler(this.frmAddFace_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox cmbPersonName;
        private System.Windows.Forms.Button cmdAddFace;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button cmdCancel;
        private System.Windows.Forms.ComboBox cmbPersonGroup;
        private System.Windows.Forms.Label label1;
    }
}
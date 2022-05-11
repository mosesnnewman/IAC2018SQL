namespace IAC2021SQL
{
    partial class frmPNSImport
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmPNSImport));
            this.buttonCancel = new DevExpress.XtraEditors.SimpleButton();
            this.buttonTransfer = new DevExpress.XtraEditors.SimpleButton();
            this.progressBarDownload = new DevExpress.XtraEditors.ProgressBarControl();
            this.labelDownload = new DevExpress.XtraEditors.LabelControl();
            this.buttonReImport = new DevExpress.XtraEditors.SimpleButton();
            this.buttonReprint = new DevExpress.XtraEditors.SimpleButton();
            this.groupControl1 = new DevExpress.XtraEditors.GroupControl();
            ((System.ComponentModel.ISupportInitialize)(this.progressBarDownload.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl1)).BeginInit();
            this.groupControl1.SuspendLayout();
            this.SuspendLayout();
            // 
            // buttonCancel
            // 
            this.buttonCancel.Appearance.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonCancel.Appearance.Options.UseFont = true;
            this.buttonCancel.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("buttonCancel.ImageOptions.Image")));
            this.buttonCancel.ImageOptions.Location = DevExpress.XtraEditors.ImageLocation.TopCenter;
            this.buttonCancel.Location = new System.Drawing.Point(345, 21);
            this.buttonCancel.LookAndFeel.SkinName = "McSkin";
            this.buttonCancel.LookAndFeel.UseDefaultLookAndFeel = false;
            this.buttonCancel.Margin = new System.Windows.Forms.Padding(4);
            this.buttonCancel.Name = "buttonCancel";
            this.buttonCancel.Size = new System.Drawing.Size(110, 103);
            this.buttonCancel.TabIndex = 2;
            this.buttonCancel.Text = "&Cancel";
            this.buttonCancel.Click += new System.EventHandler(this.buttonCancel_Click);
            // 
            // buttonTransfer
            // 
            this.buttonTransfer.Appearance.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonTransfer.Appearance.Options.UseFont = true;
            this.buttonTransfer.Appearance.Options.UseTextOptions = true;
            this.buttonTransfer.Appearance.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap;
            this.buttonTransfer.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("buttonTransfer.ImageOptions.Image")));
            this.buttonTransfer.ImageOptions.Location = DevExpress.XtraEditors.ImageLocation.TopCenter;
            this.buttonTransfer.Location = new System.Drawing.Point(117, 21);
            this.buttonTransfer.LookAndFeel.SkinName = "McSkin";
            this.buttonTransfer.LookAndFeel.UseDefaultLookAndFeel = false;
            this.buttonTransfer.Name = "buttonTransfer";
            this.buttonTransfer.Size = new System.Drawing.Size(110, 103);
            this.buttonTransfer.TabIndex = 1;
            this.buttonTransfer.Text = "&Import PNS Payments";
            this.buttonTransfer.Click += new System.EventHandler(this.buttonTransfer_Click);
            // 
            // progressBarDownload
            // 
            this.progressBarDownload.Location = new System.Drawing.Point(18, 239);
            this.progressBarDownload.Name = "progressBarDownload";
            this.progressBarDownload.Size = new System.Drawing.Size(543, 53);
            this.progressBarDownload.TabIndex = 3;
            // 
            // labelDownload
            // 
            this.labelDownload.Appearance.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelDownload.Appearance.Options.UseFont = true;
            this.labelDownload.Location = new System.Drawing.Point(18, 172);
            this.labelDownload.LookAndFeel.SkinName = "McSkin";
            this.labelDownload.LookAndFeel.UseDefaultLookAndFeel = false;
            this.labelDownload.Name = "labelDownload";
            this.labelDownload.Size = new System.Drawing.Size(37, 16);
            this.labelDownload.TabIndex = 14;
            this.labelDownload.Text = "label1";
            this.labelDownload.Visible = false;
            // 
            // buttonReImport
            // 
            this.buttonReImport.Appearance.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonReImport.Appearance.Options.UseFont = true;
            this.buttonReImport.Location = new System.Drawing.Point(133, 140);
            this.buttonReImport.LookAndFeel.SkinName = "McSkin";
            this.buttonReImport.LookAndFeel.UseDefaultLookAndFeel = false;
            this.buttonReImport.Name = "buttonReImport";
            this.buttonReImport.Size = new System.Drawing.Size(306, 23);
            this.buttonReImport.TabIndex = 15;
            this.buttonReImport.Text = "&Reimport Without SFTP";
            this.buttonReImport.Click += new System.EventHandler(this.buttonReImport_Click);
            // 
            // buttonReprint
            // 
            this.buttonReprint.Appearance.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonReprint.Appearance.Options.UseFont = true;
            this.buttonReprint.Appearance.Options.UseTextOptions = true;
            this.buttonReprint.Appearance.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap;
            this.buttonReprint.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("buttonReprint.ImageOptions.Image")));
            this.buttonReprint.ImageOptions.ImageToTextAlignment = DevExpress.XtraEditors.ImageAlignToText.TopCenter;
            this.buttonReprint.Location = new System.Drawing.Point(231, 21);
            this.buttonReprint.Name = "buttonReprint";
            this.buttonReprint.Size = new System.Drawing.Size(110, 103);
            this.buttonReprint.TabIndex = 91;
            this.buttonReprint.Text = "&Reprint Rejects";
            this.buttonReprint.Click += new System.EventHandler(this.buttonReprint_Click);
            // 
            // groupControl1
            // 
            this.groupControl1.Appearance.BackColor = System.Drawing.Color.LightSteelBlue;
            this.groupControl1.Appearance.Options.UseBackColor = true;
            this.groupControl1.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            this.groupControl1.Controls.Add(this.buttonReprint);
            this.groupControl1.Controls.Add(this.buttonReImport);
            this.groupControl1.Controls.Add(this.labelDownload);
            this.groupControl1.Controls.Add(this.progressBarDownload);
            this.groupControl1.Controls.Add(this.buttonTransfer);
            this.groupControl1.Controls.Add(this.buttonCancel);
            this.groupControl1.Location = new System.Drawing.Point(-3, -1);
            this.groupControl1.LookAndFeel.SkinName = "McSkin";
            this.groupControl1.LookAndFeel.UseDefaultLookAndFeel = false;
            this.groupControl1.Name = "groupControl1";
            this.groupControl1.Size = new System.Drawing.Size(572, 308);
            this.groupControl1.TabIndex = 92;
            this.groupControl1.Text = "groupControl1";
            // 
            // frmPNSImport
            // 
            this.Appearance.Options.UseFont = true;
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.ClientSize = new System.Drawing.Size(567, 306);
            this.Controls.Add(this.groupControl1);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "frmPNSImport";
            this.Text = "Import PNS";
            ((System.ComponentModel.ISupportInitialize)(this.progressBarDownload.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl1)).EndInit();
            this.groupControl1.ResumeLayout(false);
            this.groupControl1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraEditors.SimpleButton buttonCancel;
        private DevExpress.XtraEditors.SimpleButton buttonTransfer;
        private DevExpress.XtraEditors.ProgressBarControl progressBarDownload;
        private DevExpress.XtraEditors.LabelControl labelDownload;
        private DevExpress.XtraEditors.SimpleButton buttonReImport;
        public DevExpress.XtraEditors.SimpleButton buttonReprint;
        private DevExpress.XtraEditors.GroupControl groupControl1;
    }
}
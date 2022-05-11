namespace IAC2021SQL
{
    partial class frmImportDefi
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmImportDefi));
            this.buttonTransfer = new DevExpress.XtraEditors.SimpleButton();
            this.buttonCancel = new DevExpress.XtraEditors.SimpleButton();
            this.buttonPrint = new DevExpress.XtraEditors.SimpleButton();
            this.checkBoxImages = new System.Windows.Forms.CheckBox();
            this.groupControl1 = new DevExpress.XtraEditors.GroupControl();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl1)).BeginInit();
            this.groupControl1.SuspendLayout();
            this.SuspendLayout();
            // 
            // buttonTransfer
            // 
            this.buttonTransfer.Appearance.Options.UseTextOptions = true;
            this.buttonTransfer.Appearance.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap;
            this.buttonTransfer.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("buttonTransfer.ImageOptions.Image")));
            this.buttonTransfer.ImageOptions.ImageToTextAlignment = DevExpress.XtraEditors.ImageAlignToText.TopCenter;
            this.buttonTransfer.ImageOptions.Location = DevExpress.XtraEditors.ImageLocation.TopCenter;
            this.buttonTransfer.Location = new System.Drawing.Point(27, 40);
            this.buttonTransfer.Name = "buttonTransfer";
            this.buttonTransfer.Size = new System.Drawing.Size(110, 103);
            this.buttonTransfer.TabIndex = 14;
            this.buttonTransfer.Text = "&Import Defi XML Apps";
            this.buttonTransfer.Click += new System.EventHandler(this.buttonTransfer_Click);
            // 
            // buttonCancel
            // 
            this.buttonCancel.Appearance.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonCancel.Appearance.Options.UseFont = true;
            this.buttonCancel.Appearance.Options.UseTextOptions = true;
            this.buttonCancel.Appearance.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap;
            this.buttonCancel.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("buttonCancel.ImageOptions.Image")));
            this.buttonCancel.ImageOptions.ImageToTextAlignment = DevExpress.XtraEditors.ImageAlignToText.TopCenter;
            this.buttonCancel.ImageOptions.Location = DevExpress.XtraEditors.ImageLocation.TopCenter;
            this.buttonCancel.Location = new System.Drawing.Point(275, 40);
            this.buttonCancel.Margin = new System.Windows.Forms.Padding(4);
            this.buttonCancel.Name = "buttonCancel";
            this.buttonCancel.Size = new System.Drawing.Size(110, 103);
            this.buttonCancel.TabIndex = 13;
            this.buttonCancel.Text = "&Cancel";
            this.buttonCancel.Click += new System.EventHandler(this.buttonCancel_Click);
            // 
            // buttonPrint
            // 
            this.buttonPrint.Appearance.Options.UseTextOptions = true;
            this.buttonPrint.Appearance.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap;
            this.buttonPrint.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("buttonPrint.ImageOptions.Image")));
            this.buttonPrint.ImageOptions.ImageToTextAlignment = DevExpress.XtraEditors.ImageAlignToText.TopCenter;
            this.buttonPrint.ImageOptions.Location = DevExpress.XtraEditors.ImageLocation.TopCenter;
            this.buttonPrint.Location = new System.Drawing.Point(151, 40);
            this.buttonPrint.Name = "buttonPrint";
            this.buttonPrint.Size = new System.Drawing.Size(110, 103);
            this.buttonPrint.TabIndex = 15;
            this.buttonPrint.Text = "&Print";
            this.buttonPrint.Click += new System.EventHandler(this.buttonPrint_Click);
            // 
            // checkBoxImages
            // 
            this.checkBoxImages.AutoSize = true;
            this.checkBoxImages.Checked = true;
            this.checkBoxImages.CheckState = System.Windows.Forms.CheckState.Checked;
            this.checkBoxImages.Location = new System.Drawing.Point(144, 153);
            this.checkBoxImages.Name = "checkBoxImages";
            this.checkBoxImages.Size = new System.Drawing.Size(124, 17);
            this.checkBoxImages.TabIndex = 16;
            this.checkBoxImages.Text = "Import Images Also";
            this.checkBoxImages.UseVisualStyleBackColor = true;
            // 
            // groupControl1
            // 
            this.groupControl1.Appearance.BackColor = System.Drawing.Color.LightSteelBlue;
            this.groupControl1.Appearance.Options.UseBackColor = true;
            this.groupControl1.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            this.groupControl1.Controls.Add(this.checkBoxImages);
            this.groupControl1.Controls.Add(this.buttonPrint);
            this.groupControl1.Controls.Add(this.buttonTransfer);
            this.groupControl1.Controls.Add(this.buttonCancel);
            this.groupControl1.Location = new System.Drawing.Point(-1, -1);
            this.groupControl1.Name = "groupControl1";
            this.groupControl1.Size = new System.Drawing.Size(413, 210);
            this.groupControl1.TabIndex = 17;
            this.groupControl1.Text = "groupControl1";
            // 
            // frmImportDefi
            // 
            this.Appearance.Options.UseFont = true;
            this.ClientSize = new System.Drawing.Size(412, 209);
            this.Controls.Add(this.groupControl1);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Name = "frmImportDefi";
            this.Text = "Import Defi XML Applications";
            this.Load += new System.EventHandler(this.frmImportDefi_Load);
            ((System.ComponentModel.ISupportInitialize)(this.groupControl1)).EndInit();
            this.groupControl1.ResumeLayout(false);
            this.groupControl1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        public DevExpress.XtraEditors.SimpleButton buttonTransfer;
        private DevExpress.XtraEditors.SimpleButton buttonCancel;
        public DevExpress.XtraEditors.SimpleButton buttonPrint;
        private System.Windows.Forms.CheckBox checkBoxImages;
        private DevExpress.XtraEditors.GroupControl groupControl1;
    }
}

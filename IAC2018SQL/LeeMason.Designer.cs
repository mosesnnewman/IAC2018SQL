namespace IAC2021SQL
{
    partial class FormLeeMason
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
                SQLBR.Dispose();
                SQLBR = null;
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormLeeMason));
            this.splashScreenManager1 = new DevExpress.XtraSplashScreen.SplashScreenManager(this, typeof(global::IAC2021SQL.WaitFormVerifacto), true, true);
            this.groupControlVerifacto = new DevExpress.XtraEditors.GroupControl();
            this.groupControlButtons = new DevExpress.XtraEditors.GroupControl();
            this.buttonClose = new DevExpress.XtraEditors.SimpleButton();
            this.buttonLeeMasonImport = new DevExpress.XtraEditors.SimpleButton();
            this.buttonVehicleExtract = new DevExpress.XtraEditors.SimpleButton();
            this.XmlGridView = new XmlGridViewSample.XmlGridView();
            ((System.ComponentModel.ISupportInitialize)(this.groupControlVerifacto)).BeginInit();
            this.groupControlVerifacto.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.groupControlButtons)).BeginInit();
            this.groupControlButtons.SuspendLayout();
            this.SuspendLayout();
            // 
            // splashScreenManager1
            // 
            this.splashScreenManager1.ClosingDelay = 500;
            // 
            // groupControlVerifacto
            // 
            this.groupControlVerifacto.Appearance.BackColor = System.Drawing.Color.LightSteelBlue;
            this.groupControlVerifacto.Appearance.Options.UseBackColor = true;
            this.groupControlVerifacto.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            this.groupControlVerifacto.Controls.Add(this.groupControlButtons);
            this.groupControlVerifacto.Controls.Add(this.XmlGridView);
            this.groupControlVerifacto.Location = new System.Drawing.Point(0, -3);
            this.groupControlVerifacto.LookAndFeel.SkinName = "McSkin";
            this.groupControlVerifacto.LookAndFeel.UseDefaultLookAndFeel = false;
            this.groupControlVerifacto.Name = "groupControlVerifacto";
            this.groupControlVerifacto.Size = new System.Drawing.Size(1225, 631);
            this.groupControlVerifacto.TabIndex = 3;
            // 
            // groupControlButtons
            // 
            this.groupControlButtons.Appearance.BackColor = System.Drawing.Color.LightSteelBlue;
            this.groupControlButtons.Appearance.Options.UseBackColor = true;
            this.groupControlButtons.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            this.groupControlButtons.Controls.Add(this.buttonClose);
            this.groupControlButtons.Controls.Add(this.buttonLeeMasonImport);
            this.groupControlButtons.Controls.Add(this.buttonVehicleExtract);
            this.groupControlButtons.Location = new System.Drawing.Point(1, 471);
            this.groupControlButtons.LookAndFeel.SkinName = "McSkin";
            this.groupControlButtons.LookAndFeel.UseDefaultLookAndFeel = false;
            this.groupControlButtons.Name = "groupControlButtons";
            this.groupControlButtons.Size = new System.Drawing.Size(415, 159);
            this.groupControlButtons.TabIndex = 4;
            // 
            // buttonClose
            // 
            this.buttonClose.Appearance.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonClose.Appearance.Options.UseFont = true;
            this.buttonClose.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("buttonClose.ImageOptions.Image")));
            this.buttonClose.ImageOptions.ImageToTextAlignment = DevExpress.XtraEditors.ImageAlignToText.TopCenter;
            this.buttonClose.Location = new System.Drawing.Point(291, 28);
            this.buttonClose.LookAndFeel.SkinName = "McSkin";
            this.buttonClose.LookAndFeel.UseDefaultLookAndFeel = false;
            this.buttonClose.Name = "buttonClose";
            this.buttonClose.Size = new System.Drawing.Size(104, 103);
            this.buttonClose.TabIndex = 2;
            this.buttonClose.Text = "&Close";
            this.buttonClose.Click += new System.EventHandler(this.ButtonClose_Click);
            // 
            // buttonLeeMasonImport
            // 
            this.buttonLeeMasonImport.Appearance.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonLeeMasonImport.Appearance.Options.UseFont = true;
            this.buttonLeeMasonImport.Appearance.Options.UseTextOptions = true;
            this.buttonLeeMasonImport.Appearance.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap;
            this.buttonLeeMasonImport.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("buttonLeeMasonImport.ImageOptions.Image")));
            this.buttonLeeMasonImport.ImageOptions.ImageToTextAlignment = DevExpress.XtraEditors.ImageAlignToText.TopCenter;
            this.buttonLeeMasonImport.Location = new System.Drawing.Point(155, 28);
            this.buttonLeeMasonImport.LookAndFeel.SkinName = "McSkin";
            this.buttonLeeMasonImport.LookAndFeel.UseDefaultLookAndFeel = false;
            this.buttonLeeMasonImport.Name = "buttonLeeMasonImport";
            this.buttonLeeMasonImport.Size = new System.Drawing.Size(104, 103);
            this.buttonLeeMasonImport.TabIndex = 1;
            this.buttonLeeMasonImport.Text = "Verifacto &Import";
            this.buttonLeeMasonImport.Click += new System.EventHandler(this.ButtonLeeMasonImport_Click);
            // 
            // buttonVehicleExtract
            // 
            this.buttonVehicleExtract.Appearance.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonVehicleExtract.Appearance.Options.UseFont = true;
            this.buttonVehicleExtract.Appearance.Options.UseTextOptions = true;
            this.buttonVehicleExtract.Appearance.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap;
            this.buttonVehicleExtract.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("buttonVehicleExtract.ImageOptions.Image")));
            this.buttonVehicleExtract.ImageOptions.ImageToTextAlignment = DevExpress.XtraEditors.ImageAlignToText.TopCenter;
            this.buttonVehicleExtract.Location = new System.Drawing.Point(19, 28);
            this.buttonVehicleExtract.LookAndFeel.SkinName = "McSkin";
            this.buttonVehicleExtract.LookAndFeel.UseDefaultLookAndFeel = false;
            this.buttonVehicleExtract.Name = "buttonVehicleExtract";
            this.buttonVehicleExtract.Size = new System.Drawing.Size(104, 103);
            this.buttonVehicleExtract.TabIndex = 0;
            this.buttonVehicleExtract.Text = "&Export to Verifacto";
            this.buttonVehicleExtract.Click += new System.EventHandler(this.ButtonVehicleExtract_Click);
            // 
            // XmlGridView
            // 
            this.XmlGridView.DataFilePath = "";
            this.XmlGridView.DataSetTableIndex = 0;
            this.XmlGridView.Location = new System.Drawing.Point(416, 3);
            this.XmlGridView.Name = "XmlGridView";
            this.XmlGridView.Size = new System.Drawing.Size(809, 628);
            this.XmlGridView.TabIndex = 3;
            this.XmlGridView.ViewMode = XmlGridViewSample.XmlGridView.VIEW_MODE.XML;
            // 
            // FormLeeMason
            // 
            this.Appearance.Options.UseFont = true;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1226, 626);
            this.Controls.Add(this.groupControlVerifacto);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FormLeeMason";
            this.Text = "Verifacto Import and Export";
            this.Load += new System.EventHandler(this.FormLeeMason_Load);
            ((System.ComponentModel.ISupportInitialize)(this.groupControlVerifacto)).EndInit();
            this.groupControlVerifacto.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.groupControlButtons)).EndInit();
            this.groupControlButtons.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraEditors.SimpleButton buttonVehicleExtract;
        private DevExpress.XtraEditors.SimpleButton buttonLeeMasonImport;
        private DevExpress.XtraEditors.SimpleButton buttonClose;
        private DevExpress.XtraEditors.GroupControl groupControlVerifacto;
        private DevExpress.XtraEditors.GroupControl groupControlButtons;
        private XmlGridViewSample.XmlGridView XmlGridView;
        private DevExpress.XtraSplashScreen.SplashScreenManager splashScreenManager1;
    }
}
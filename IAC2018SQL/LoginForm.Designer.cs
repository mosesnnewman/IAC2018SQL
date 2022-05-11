namespace IAC2021SQL
{
    partial class LoginForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(LoginForm));
            this.bindingSourceULIST = new System.Windows.Forms.BindingSource(this.components);
            this.iACDataSet = new IAC2021SQL.IACDataSet();
            this.uLISTTableAdapter = new IAC2021SQL.IACDataSetTableAdapters.ULISTTableAdapter();
            this.groupControl1 = new DevExpress.XtraEditors.GroupControl();
            this.labelControl1 = new DevExpress.XtraEditors.LabelControl();
            this.dataLayoutControl1 = new DevExpress.XtraDataLayout.DataLayoutControl();
            this.pictureEdit1 = new DevExpress.XtraEditors.PictureEdit();
            this.txtUserID = new DevExpress.XtraEditors.LookUpEdit();
            this.txtPassword = new DevExpress.XtraEditors.TextEdit();
            this.Root = new DevExpress.XtraLayout.LayoutControlGroup();
            this.layoutControlGroupLoginInfo = new DevExpress.XtraLayout.LayoutControlGroup();
            this.ItemForLIST_ID = new DevExpress.XtraLayout.LayoutControlItem();
            this.ItemForLIST_PASSWORD = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem3 = new DevExpress.XtraLayout.LayoutControlItem();
            this.emptySpaceItem1 = new DevExpress.XtraLayout.EmptySpaceItem();
            this.btnLogin = new DevExpress.XtraEditors.SimpleButton();
            this.btnCancel = new DevExpress.XtraEditors.SimpleButton();
            ((System.ComponentModel.ISupportInitialize)(this.bindingSourceULIST)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.iACDataSet)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl1)).BeginInit();
            this.groupControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataLayoutControl1)).BeginInit();
            this.dataLayoutControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureEdit1.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtUserID.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtPassword.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Root)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroupLoginInfo)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ItemForLIST_ID)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ItemForLIST_PASSWORD)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.emptySpaceItem1)).BeginInit();
            this.SuspendLayout();
            // 
            // bindingSourceULIST
            // 
            this.bindingSourceULIST.DataMember = "ULIST";
            this.bindingSourceULIST.DataSource = this.iACDataSet;
            // 
            // iACDataSet
            // 
            this.iACDataSet.DataSetName = "IACDataSet";
            this.iACDataSet.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // uLISTTableAdapter
            // 
            this.uLISTTableAdapter.ClearBeforeFill = true;
            // 
            // groupControl1
            // 
            this.groupControl1.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            this.groupControl1.Controls.Add(this.labelControl1);
            this.groupControl1.Controls.Add(this.dataLayoutControl1);
            this.groupControl1.Controls.Add(this.btnLogin);
            this.groupControl1.Controls.Add(this.btnCancel);
            this.groupControl1.Location = new System.Drawing.Point(-2, -1);
            this.groupControl1.Name = "groupControl1";
            this.groupControl1.Size = new System.Drawing.Size(661, 397);
            this.groupControl1.TabIndex = 5;
            this.groupControl1.Text = "groupControl1";
            // 
            // labelControl1
            // 
            this.labelControl1.Appearance.Font = new System.Drawing.Font("Segoe UI", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelControl1.Appearance.Options.UseFont = true;
            this.labelControl1.Location = new System.Drawing.Point(294, 0);
            this.labelControl1.LookAndFeel.SkinName = "McSkin";
            this.labelControl1.LookAndFeel.UseDefaultLookAndFeel = false;
            this.labelControl1.Name = "labelControl1";
            this.labelControl1.Size = new System.Drawing.Size(72, 37);
            this.labelControl1.TabIndex = 11;
            this.labelControl1.Text = "Login";
            // 
            // dataLayoutControl1
            // 
            this.dataLayoutControl1.BackColor = System.Drawing.Color.LightSteelBlue;
            this.dataLayoutControl1.Controls.Add(this.pictureEdit1);
            this.dataLayoutControl1.Controls.Add(this.txtUserID);
            this.dataLayoutControl1.Controls.Add(this.txtPassword);
            this.dataLayoutControl1.DataSource = this.bindingSourceULIST;
            this.dataLayoutControl1.Location = new System.Drawing.Point(9, 32);
            this.dataLayoutControl1.LookAndFeel.SkinName = "McSkin";
            this.dataLayoutControl1.LookAndFeel.UseDefaultLookAndFeel = false;
            this.dataLayoutControl1.Name = "dataLayoutControl1";
            this.dataLayoutControl1.OptionsCustomizationForm.DesignTimeCustomizationFormPositionAndSize = new System.Drawing.Rectangle(780, 0, 650, 400);
            this.dataLayoutControl1.Root = this.Root;
            this.dataLayoutControl1.Size = new System.Drawing.Size(643, 237);
            this.dataLayoutControl1.TabIndex = 10;
            this.dataLayoutControl1.Text = "dataLayoutControl1";
            // 
            // pictureEdit1
            // 
            this.pictureEdit1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.pictureEdit1.EditValue = global::IAC2021SQL.Properties.Resources._007_SMALL;
            this.pictureEdit1.Location = new System.Drawing.Point(368, 12);
            this.pictureEdit1.Name = "pictureEdit1";
            this.pictureEdit1.Properties.Appearance.BackColor = System.Drawing.Color.Transparent;
            this.pictureEdit1.Properties.Appearance.Options.UseBackColor = true;
            this.pictureEdit1.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            this.pictureEdit1.Properties.PictureAlignment = System.Drawing.ContentAlignment.TopCenter;
            this.pictureEdit1.Properties.PictureStoreMode = DevExpress.XtraEditors.Controls.PictureStoreMode.Image;
            this.pictureEdit1.Properties.ShowCameraMenuItem = DevExpress.XtraEditors.Controls.CameraMenuItemVisibility.Auto;
            this.pictureEdit1.Properties.SizeMode = DevExpress.XtraEditors.Controls.PictureSizeMode.Squeeze;
            this.pictureEdit1.Size = new System.Drawing.Size(263, 148);
            this.pictureEdit1.StyleController = this.dataLayoutControl1;
            this.pictureEdit1.TabIndex = 6;
            // 
            // txtUserID
            // 
            this.txtUserID.DataBindings.Add(new System.Windows.Forms.Binding("EditValue", this.bindingSourceULIST, "LIST_ID", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.txtUserID.Location = new System.Drawing.Point(88, 39);
            this.txtUserID.Name = "txtUserID";
            this.txtUserID.Properties.AdvancedModeOptions.AllowCaretAnimation = DevExpress.Utils.DefaultBoolean.True;
            this.txtUserID.Properties.AdvancedModeOptions.AllowSelectionAnimation = DevExpress.Utils.DefaultBoolean.True;
            this.txtUserID.Properties.AdvancedModeOptions.UseDirectXPaint = DevExpress.Utils.DefaultBoolean.False;
            this.txtUserID.Properties.AllowDropDownWhenReadOnly = DevExpress.Utils.DefaultBoolean.False;
            this.txtUserID.Properties.Appearance.BackColor = System.Drawing.Color.White;
            this.txtUserID.Properties.Appearance.Font = new System.Drawing.Font("Segoe UI", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtUserID.Properties.Appearance.Options.UseBackColor = true;
            this.txtUserID.Properties.Appearance.Options.UseFont = true;
            this.txtUserID.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.Simple;
            this.txtUserID.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.txtUserID.Properties.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtUserID.Properties.Columns.AddRange(new DevExpress.XtraEditors.Controls.LookUpColumnInfo[] {
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("LIST_ID", "ID", 45, DevExpress.Utils.FormatType.None, "", true, DevExpress.Utils.HorzAlignment.Near, DevExpress.Data.ColumnSortOrder.None, DevExpress.Utils.DefaultBoolean.Default),
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("LIST_NAME", "NAME", 65, DevExpress.Utils.FormatType.None, "", true, DevExpress.Utils.HorzAlignment.Near, DevExpress.Data.ColumnSortOrder.None, DevExpress.Utils.DefaultBoolean.Default)});
            this.txtUserID.Properties.DataSource = this.bindingSourceULIST;
            this.txtUserID.Properties.DisplayMember = "LIST_ID";
            this.txtUserID.Properties.MaxLength = 3;
            this.txtUserID.Properties.NullText = "";
            this.txtUserID.Properties.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.Standard;
            this.txtUserID.Properties.ValueMember = "LIST_ID";
            this.txtUserID.Size = new System.Drawing.Size(276, 32);
            this.txtUserID.StyleController = this.dataLayoutControl1;
            this.txtUserID.TabIndex = 0;
            this.txtUserID.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtUserID_KeyPress);
            // 
            // txtPassword
            // 
            this.txtPassword.Location = new System.Drawing.Point(88, 147);
            this.txtPassword.Name = "txtPassword";
            this.txtPassword.Properties.AdvancedModeOptions.AllowCaretAnimation = DevExpress.Utils.DefaultBoolean.True;
            this.txtPassword.Properties.AdvancedModeOptions.AllowSelectionAnimation = DevExpress.Utils.DefaultBoolean.True;
            this.txtPassword.Properties.Appearance.Font = new System.Drawing.Font("Segoe UI", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtPassword.Properties.Appearance.Options.UseFont = true;
            this.txtPassword.Properties.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtPassword.Properties.MaxLength = 8;
            this.txtPassword.Size = new System.Drawing.Size(276, 32);
            this.txtPassword.StyleController = this.dataLayoutControl1;
            this.txtPassword.TabIndex = 1;
            this.txtPassword.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtPassword_KeyPress);
            // 
            // Root
            // 
            this.Root.AppearanceGroup.BackColor = System.Drawing.Color.LightSteelBlue;
            this.Root.AppearanceGroup.Options.UseBackColor = true;
            this.Root.EnableIndentsWithoutBorders = DevExpress.Utils.DefaultBoolean.True;
            this.Root.GroupBordersVisible = false;
            this.Root.Items.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[] {
            this.layoutControlGroupLoginInfo,
            this.layoutControlItem3,
            this.emptySpaceItem1});
            this.Root.Name = "Root";
            this.Root.Size = new System.Drawing.Size(643, 237);
            this.Root.TextVisible = false;
            // 
            // layoutControlGroupLoginInfo
            // 
            this.layoutControlGroupLoginInfo.AppearanceGroup.BackColor = System.Drawing.Color.Transparent;
            this.layoutControlGroupLoginInfo.AppearanceGroup.Options.UseBackColor = true;
            this.layoutControlGroupLoginInfo.EnableIndentsWithoutBorders = DevExpress.Utils.DefaultBoolean.False;
            this.layoutControlGroupLoginInfo.GroupBordersVisible = false;
            this.layoutControlGroupLoginInfo.GroupStyle = DevExpress.Utils.GroupStyle.Light;
            this.layoutControlGroupLoginInfo.Items.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[] {
            this.ItemForLIST_ID,
            this.ItemForLIST_PASSWORD});
            this.layoutControlGroupLoginInfo.Location = new System.Drawing.Point(0, 0);
            this.layoutControlGroupLoginInfo.Name = "layoutControlGroupLoginInfo";
            this.layoutControlGroupLoginInfo.Size = new System.Drawing.Size(356, 217);
            this.layoutControlGroupLoginInfo.Text = "Login Info";
            // 
            // ItemForLIST_ID
            // 
            this.ItemForLIST_ID.AppearanceItemCaption.BackColor = System.Drawing.Color.Transparent;
            this.ItemForLIST_ID.AppearanceItemCaption.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ItemForLIST_ID.AppearanceItemCaption.Options.UseBackColor = true;
            this.ItemForLIST_ID.AppearanceItemCaption.Options.UseFont = true;
            this.ItemForLIST_ID.AppearanceItemCaption.Options.UseTextOptions = true;
            this.ItemForLIST_ID.AppearanceItemCaption.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
            this.ItemForLIST_ID.ContentHorzAlignment = DevExpress.Utils.HorzAlignment.Far;
            this.ItemForLIST_ID.ContentVertAlignment = DevExpress.Utils.VertAlignment.Center;
            this.ItemForLIST_ID.Control = this.txtUserID;
            this.ItemForLIST_ID.Location = new System.Drawing.Point(0, 0);
            this.ItemForLIST_ID.MinSize = new System.Drawing.Size(107, 24);
            this.ItemForLIST_ID.Name = "ItemForLIST_ID";
            this.ItemForLIST_ID.Size = new System.Drawing.Size(356, 90);
            this.ItemForLIST_ID.SizeConstraintsType = DevExpress.XtraLayout.SizeConstraintsType.Custom;
            this.ItemForLIST_ID.Text = "User ID";
            this.ItemForLIST_ID.TextSize = new System.Drawing.Size(72, 21);
            // 
            // ItemForLIST_PASSWORD
            // 
            this.ItemForLIST_PASSWORD.AppearanceItemCaption.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ItemForLIST_PASSWORD.AppearanceItemCaption.Options.UseFont = true;
            this.ItemForLIST_PASSWORD.AppearanceItemCaption.Options.UseTextOptions = true;
            this.ItemForLIST_PASSWORD.AppearanceItemCaption.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
            this.ItemForLIST_PASSWORD.ContentHorzAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.ItemForLIST_PASSWORD.ContentVertAlignment = DevExpress.Utils.VertAlignment.Center;
            this.ItemForLIST_PASSWORD.Control = this.txtPassword;
            this.ItemForLIST_PASSWORD.Location = new System.Drawing.Point(0, 90);
            this.ItemForLIST_PASSWORD.MinSize = new System.Drawing.Size(107, 32);
            this.ItemForLIST_PASSWORD.Name = "ItemForLIST_PASSWORD";
            this.ItemForLIST_PASSWORD.Size = new System.Drawing.Size(356, 127);
            this.ItemForLIST_PASSWORD.SizeConstraintsType = DevExpress.XtraLayout.SizeConstraintsType.Custom;
            this.ItemForLIST_PASSWORD.Text = "Password";
            this.ItemForLIST_PASSWORD.TextSize = new System.Drawing.Size(72, 21);
            // 
            // layoutControlItem3
            // 
            this.layoutControlItem3.Control = this.pictureEdit1;
            this.layoutControlItem3.ImageOptions.Alignment = System.Drawing.ContentAlignment.MiddleCenter;
            this.layoutControlItem3.Location = new System.Drawing.Point(356, 0);
            this.layoutControlItem3.MinSize = new System.Drawing.Size(127, 24);
            this.layoutControlItem3.Name = "layoutControlItem3";
            this.layoutControlItem3.Size = new System.Drawing.Size(267, 152);
            this.layoutControlItem3.SizeConstraintsType = DevExpress.XtraLayout.SizeConstraintsType.Custom;
            this.layoutControlItem3.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlItem3.TextVisible = false;
            // 
            // emptySpaceItem1
            // 
            this.emptySpaceItem1.AllowHotTrack = false;
            this.emptySpaceItem1.Location = new System.Drawing.Point(356, 152);
            this.emptySpaceItem1.Name = "emptySpaceItem1";
            this.emptySpaceItem1.Size = new System.Drawing.Size(267, 65);
            this.emptySpaceItem1.TextSize = new System.Drawing.Size(0, 0);
            // 
            // btnLogin
            // 
            this.btnLogin.Appearance.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnLogin.Appearance.Options.UseFont = true;
            this.btnLogin.ImageOptions.Image = global::IAC2021SQL.Properties.Resources.login_button_png_18022;
            this.btnLogin.ImageOptions.Location = DevExpress.XtraEditors.ImageLocation.MiddleCenter;
            this.btnLogin.Location = new System.Drawing.Point(137, 275);
            this.btnLogin.Name = "btnLogin";
            this.btnLogin.Size = new System.Drawing.Size(257, 101);
            this.btnLogin.TabIndex = 3;
            this.btnLogin.Click += new System.EventHandler(this.btnLogin_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.Appearance.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCancel.Appearance.Options.UseFont = true;
            this.btnCancel.ImageOptions.Image = global::IAC2021SQL.Properties.Resources.Cancel_64x;
            this.btnCancel.ImageOptions.Location = DevExpress.XtraEditors.ImageLocation.MiddleCenter;
            this.btnCancel.Location = new System.Drawing.Point(432, 275);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(92, 101);
            this.btnCancel.TabIndex = 4;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // LoginForm
            // 
            this.Appearance.BackColor = System.Drawing.Color.LightSteelBlue;
            this.Appearance.Options.UseBackColor = true;
            this.Appearance.Options.UseFont = true;
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.AutoSize = true;
            this.ClientSize = new System.Drawing.Size(658, 396);
            this.ControlBox = false;
            this.Controls.Add(this.groupControl1);
            this.EnableAcrylicAccent = true;
            this.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.IconOptions.Icon = ((System.Drawing.Icon)(resources.GetObject("LoginForm.IconOptions.Icon")));
            this.LookAndFeel.SkinName = "McSkin";
            this.LookAndFeel.UseDefaultLookAndFeel = false;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "LoginForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Login";
            this.TopMost = true;
            this.Load += new System.EventHandler(this.LoginForm_Load);
            this.Shown += new System.EventHandler(this.LoginForm_Shown);
            ((System.ComponentModel.ISupportInitialize)(this.bindingSourceULIST)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.iACDataSet)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl1)).EndInit();
            this.groupControl1.ResumeLayout(false);
            this.groupControl1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataLayoutControl1)).EndInit();
            this.dataLayoutControl1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureEdit1.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtUserID.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtPassword.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Root)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroupLoginInfo)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ItemForLIST_ID)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ItemForLIST_PASSWORD)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.emptySpaceItem1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private IACDataSet iACDataSet;
        private IACDataSetTableAdapters.ULISTTableAdapter uLISTTableAdapter;
        private System.Windows.Forms.BindingSource bindingSourceULIST;
        private DevExpress.XtraEditors.GroupControl groupControl1;
        private DevExpress.XtraDataLayout.DataLayoutControl dataLayoutControl1;
        private DevExpress.XtraEditors.PictureEdit pictureEdit1;
        private DevExpress.XtraEditors.SimpleButton btnCancel;
        private DevExpress.XtraEditors.SimpleButton btnLogin;
        private DevExpress.XtraEditors.LookUpEdit txtUserID;
        private DevExpress.XtraEditors.TextEdit txtPassword;
        private DevExpress.XtraLayout.LayoutControlGroup Root;
        private DevExpress.XtraLayout.LayoutControlGroup layoutControlGroupLoginInfo;
        private DevExpress.XtraLayout.LayoutControlItem ItemForLIST_ID;
        private DevExpress.XtraLayout.LayoutControlItem ItemForLIST_PASSWORD;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem3;
        private DevExpress.XtraLayout.EmptySpaceItem emptySpaceItem1;
        private DevExpress.XtraEditors.LabelControl labelControl1;
    }
}
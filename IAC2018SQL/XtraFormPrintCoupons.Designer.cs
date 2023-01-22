namespace IAC2021SQL
{
    partial class PrintCoupons
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
            DevExpress.DataAccess.Sql.StoredProcQuery storedProcQuery5 = new DevExpress.DataAccess.Sql.StoredProcQuery();
            DevExpress.DataAccess.Sql.QueryParameter queryParameter5 = new DevExpress.DataAccess.Sql.QueryParameter();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(PrintCoupons));
            this.groupControl1 = new DevExpress.XtraEditors.GroupControl();
            this.labelControl6 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl5 = new DevExpress.XtraEditors.LabelControl();
            this.buttonPrint = new DevExpress.XtraEditors.SimpleButton();
            this.labelControl4 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl3 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl2 = new DevExpress.XtraEditors.LabelControl();
            this.textEditZip = new DevExpress.XtraEditors.TextEdit();
            this.textEditState = new DevExpress.XtraEditors.TextEdit();
            this.textEditCity = new DevExpress.XtraEditors.TextEdit();
            this.textEditAddress = new DevExpress.XtraEditors.TextEdit();
            this.textEditName = new DevExpress.XtraEditors.TextEdit();
            this.labelControl1 = new DevExpress.XtraEditors.LabelControl();
            this.spinEditStartTicket = new DevExpress.XtraEditors.SpinEdit();
            this.spinEditTicketCount = new DevExpress.XtraEditors.SpinEdit();
            this.DateEditNextPayDate = new DevExpress.XtraEditors.DateEdit();
            this.sqlDataSource1 = new DevExpress.DataAccess.Sql.SqlDataSource(this.components);
            this.textEditBalance = new DevExpress.XtraEditors.TextEdit();
            this.labelControl7 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl8 = new DevExpress.XtraEditors.LabelControl();
            this.textEditRegularPayment = new DevExpress.XtraEditors.TextEdit();
            this.buttonCancel = new DevExpress.XtraEditors.SimpleButton();
            this.cUSTOMER_NOTextBox = new DevExpress.XtraEditors.TextEdit();
            this.labelControlAccountNumber = new DevExpress.XtraEditors.LabelControl();
            this.checkEditAllNewBusiness = new DevExpress.XtraEditors.CheckEdit();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.labelControl9 = new DevExpress.XtraEditors.LabelControl();
            this.textEditPaymentsLeft = new DevExpress.XtraEditors.TextEdit();
            this.labelControl10 = new DevExpress.XtraEditors.LabelControl();
            this.textEditTotalPayments = new DevExpress.XtraEditors.TextEdit();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl1)).BeginInit();
            this.groupControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.textEditZip.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.textEditState.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.textEditCity.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.textEditAddress.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.textEditName.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.spinEditStartTicket.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.spinEditTicketCount.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.DateEditNextPayDate.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.DateEditNextPayDate.Properties.CalendarTimeProperties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.textEditBalance.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.textEditRegularPayment.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cUSTOMER_NOTextBox.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.checkEditAllNewBusiness.Properties)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.textEditPaymentsLeft.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.textEditTotalPayments.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // groupControl1
            // 
            this.groupControl1.Appearance.BackColor = System.Drawing.Color.LightSteelBlue;
            this.groupControl1.Appearance.Options.UseBackColor = true;
            this.groupControl1.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            this.groupControl1.Controls.Add(this.groupBox3);
            this.groupControl1.Controls.Add(this.groupBox2);
            this.groupControl1.Controls.Add(this.groupBox1);
            this.groupControl1.Location = new System.Drawing.Point(-1, 0);
            this.groupControl1.Name = "groupControl1";
            this.groupControl1.Size = new System.Drawing.Size(781, 395);
            this.groupControl1.TabIndex = 0;
            this.groupControl1.Text = "groupControl1";
            // 
            // labelControl6
            // 
            this.labelControl6.Appearance.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelControl6.Appearance.Options.UseFont = true;
            this.labelControl6.AutoSizeMode = DevExpress.XtraEditors.LabelAutoSizeMode.Horizontal;
            this.labelControl6.Location = new System.Drawing.Point(22, 110);
            this.labelControl6.Name = "labelControl6";
            this.labelControl6.Size = new System.Drawing.Size(144, 21);
            this.labelControl6.TabIndex = 91;
            this.labelControl6.Text = "Start with payment#:";
            // 
            // labelControl5
            // 
            this.labelControl5.Appearance.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelControl5.Appearance.Options.UseFont = true;
            this.labelControl5.AutoSizeMode = DevExpress.XtraEditors.LabelAutoSizeMode.Horizontal;
            this.labelControl5.Location = new System.Drawing.Point(24, 82);
            this.labelControl5.Name = "labelControl5";
            this.labelControl5.Size = new System.Drawing.Size(142, 21);
            this.labelControl5.TabIndex = 90;
            this.labelControl5.Text = "Number of coupons:";
            // 
            // buttonPrint
            // 
            this.buttonPrint.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("buttonPrint.ImageOptions.Image")));
            this.buttonPrint.ImageOptions.Location = DevExpress.XtraEditors.ImageLocation.MiddleCenter;
            this.buttonPrint.Location = new System.Drawing.Point(40, 21);
            this.buttonPrint.Name = "buttonPrint";
            this.buttonPrint.Size = new System.Drawing.Size(110, 103);
            this.buttonPrint.TabIndex = 89;
            this.buttonPrint.Click += new System.EventHandler(this.buttonPrint_Click);
            // 
            // labelControl4
            // 
            this.labelControl4.Appearance.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelControl4.Appearance.Options.UseFont = true;
            this.labelControl4.AutoSizeMode = DevExpress.XtraEditors.LabelAutoSizeMode.Horizontal;
            this.labelControl4.Location = new System.Drawing.Point(304, 82);
            this.labelControl4.Name = "labelControl4";
            this.labelControl4.Size = new System.Drawing.Size(101, 21);
            this.labelControl4.TabIndex = 88;
            this.labelControl4.Text = "City, State, Zip:";
            // 
            // labelControl3
            // 
            this.labelControl3.Appearance.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelControl3.Appearance.Options.UseFont = true;
            this.labelControl3.AutoSizeMode = DevExpress.XtraEditors.LabelAutoSizeMode.Horizontal;
            this.labelControl3.Location = new System.Drawing.Point(346, 54);
            this.labelControl3.Name = "labelControl3";
            this.labelControl3.Size = new System.Drawing.Size(59, 21);
            this.labelControl3.TabIndex = 87;
            this.labelControl3.Text = "Address:";
            // 
            // labelControl2
            // 
            this.labelControl2.Appearance.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelControl2.Appearance.Options.UseFont = true;
            this.labelControl2.AutoSizeMode = DevExpress.XtraEditors.LabelAutoSizeMode.Horizontal;
            this.labelControl2.Location = new System.Drawing.Point(360, 26);
            this.labelControl2.Name = "labelControl2";
            this.labelControl2.Size = new System.Drawing.Size(45, 21);
            this.labelControl2.TabIndex = 86;
            this.labelControl2.Text = "Name:";
            // 
            // textEditZip
            // 
            this.textEditZip.Enabled = false;
            this.textEditZip.Location = new System.Drawing.Point(619, 75);
            this.textEditZip.Name = "textEditZip";
            this.textEditZip.Properties.Appearance.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textEditZip.Properties.Appearance.Options.UseFont = true;
            this.textEditZip.Properties.AppearanceDisabled.ForeColor = System.Drawing.Color.Black;
            this.textEditZip.Properties.AppearanceDisabled.Options.UseForeColor = true;
            this.textEditZip.Size = new System.Drawing.Size(142, 28);
            this.textEditZip.TabIndex = 85;
            // 
            // textEditState
            // 
            this.textEditState.Enabled = false;
            this.textEditState.Location = new System.Drawing.Point(586, 75);
            this.textEditState.Name = "textEditState";
            this.textEditState.Properties.Appearance.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textEditState.Properties.Appearance.Options.UseFont = true;
            this.textEditState.Properties.AppearanceDisabled.ForeColor = System.Drawing.Color.Black;
            this.textEditState.Properties.AppearanceDisabled.Options.UseForeColor = true;
            this.textEditState.Size = new System.Drawing.Size(35, 28);
            this.textEditState.TabIndex = 84;
            // 
            // textEditCity
            // 
            this.textEditCity.Enabled = false;
            this.textEditCity.Location = new System.Drawing.Point(408, 75);
            this.textEditCity.Name = "textEditCity";
            this.textEditCity.Properties.Appearance.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textEditCity.Properties.Appearance.Options.UseFont = true;
            this.textEditCity.Properties.AppearanceDisabled.ForeColor = System.Drawing.Color.Black;
            this.textEditCity.Properties.AppearanceDisabled.Options.UseForeColor = true;
            this.textEditCity.Size = new System.Drawing.Size(179, 28);
            this.textEditCity.TabIndex = 83;
            // 
            // textEditAddress
            // 
            this.textEditAddress.Enabled = false;
            this.textEditAddress.Location = new System.Drawing.Point(408, 47);
            this.textEditAddress.Name = "textEditAddress";
            this.textEditAddress.Properties.Appearance.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textEditAddress.Properties.Appearance.Options.UseFont = true;
            this.textEditAddress.Properties.AppearanceDisabled.ForeColor = System.Drawing.Color.Black;
            this.textEditAddress.Properties.AppearanceDisabled.Options.UseForeColor = true;
            this.textEditAddress.Size = new System.Drawing.Size(353, 28);
            this.textEditAddress.TabIndex = 82;
            // 
            // textEditName
            // 
            this.textEditName.EditValue = "";
            this.textEditName.Enabled = false;
            this.textEditName.Location = new System.Drawing.Point(408, 19);
            this.textEditName.Name = "textEditName";
            this.textEditName.Properties.Appearance.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textEditName.Properties.Appearance.Options.UseFont = true;
            this.textEditName.Properties.AppearanceDisabled.ForeColor = System.Drawing.Color.Black;
            this.textEditName.Properties.AppearanceDisabled.Options.UseForeColor = true;
            this.textEditName.Size = new System.Drawing.Size(353, 28);
            this.textEditName.TabIndex = 81;
            // 
            // labelControl1
            // 
            this.labelControl1.Appearance.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelControl1.Appearance.Options.UseFont = true;
            this.labelControl1.Location = new System.Drawing.Point(14, 26);
            this.labelControl1.Name = "labelControl1";
            this.labelControl1.Size = new System.Drawing.Size(100, 21);
            this.labelControl1.TabIndex = 80;
            this.labelControl1.Text = "Next Payment:";
            // 
            // spinEditStartTicket
            // 
            this.spinEditStartTicket.EditValue = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.spinEditStartTicket.Location = new System.Drawing.Point(168, 103);
            this.spinEditStartTicket.Name = "spinEditStartTicket";
            this.spinEditStartTicket.Properties.Appearance.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.spinEditStartTicket.Properties.Appearance.Options.UseFont = true;
            this.spinEditStartTicket.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.spinEditStartTicket.Size = new System.Drawing.Size(67, 28);
            this.spinEditStartTicket.TabIndex = 79;
            // 
            // spinEditTicketCount
            // 
            this.spinEditTicketCount.EditValue = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.spinEditTicketCount.Location = new System.Drawing.Point(168, 75);
            this.spinEditTicketCount.Name = "spinEditTicketCount";
            this.spinEditTicketCount.Properties.Appearance.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.spinEditTicketCount.Properties.Appearance.Options.UseFont = true;
            this.spinEditTicketCount.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.spinEditTicketCount.Size = new System.Drawing.Size(67, 28);
            this.spinEditTicketCount.TabIndex = 78;
            // 
            // DateEditNextPayDate
            // 
            this.DateEditNextPayDate.EditValue = null;
            this.DateEditNextPayDate.Enabled = false;
            this.DateEditNextPayDate.Location = new System.Drawing.Point(116, 19);
            this.DateEditNextPayDate.Name = "DateEditNextPayDate";
            this.DateEditNextPayDate.Properties.Appearance.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.DateEditNextPayDate.Properties.Appearance.Options.UseFont = true;
            this.DateEditNextPayDate.Properties.AppearanceDisabled.ForeColor = System.Drawing.Color.Black;
            this.DateEditNextPayDate.Properties.AppearanceDisabled.Options.UseForeColor = true;
            this.DateEditNextPayDate.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.DateEditNextPayDate.Properties.CalendarTimeProperties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.DateEditNextPayDate.Properties.CalendarView = DevExpress.XtraEditors.Repository.CalendarView.Fluent;
            this.DateEditNextPayDate.Properties.LookAndFeel.SkinMaskColor = System.Drawing.Color.LightSteelBlue;
            this.DateEditNextPayDate.Properties.LookAndFeel.SkinMaskColor2 = System.Drawing.Color.Transparent;
            this.DateEditNextPayDate.Properties.LookAndFeel.SkinName = "McSkin";
            this.DateEditNextPayDate.Properties.LookAndFeel.UseDefaultLookAndFeel = false;
            this.DateEditNextPayDate.Properties.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.Standard;
            this.DateEditNextPayDate.Properties.UseAdvancedMode = DevExpress.Utils.DefaultBoolean.True;
            this.DateEditNextPayDate.Properties.VistaDisplayMode = DevExpress.Utils.DefaultBoolean.False;
            this.DateEditNextPayDate.Size = new System.Drawing.Size(119, 28);
            this.DateEditNextPayDate.TabIndex = 77;
            // 
            // sqlDataSource1
            // 
            this.sqlDataSource1.ConnectionName = "IAC2021SQL.Properties.Settings.IAC2010SQLConnectionString";
            this.sqlDataSource1.Name = "sqlDataSource1";
            storedProcQuery5.Name = "ClosedCustomerSelect";
            queryParameter5.Name = "@CUSTOMER_NO";
            queryParameter5.Type = typeof(string);
            queryParameter5.ValueInfo = "201501";
            storedProcQuery5.Parameters.AddRange(new DevExpress.DataAccess.Sql.QueryParameter[] {
            queryParameter5});
            storedProcQuery5.StoredProcName = "ClosedCustomerSelect";
            this.sqlDataSource1.Queries.AddRange(new DevExpress.DataAccess.Sql.SqlQuery[] {
            storedProcQuery5});
            this.sqlDataSource1.ResultSchemaSerializable = resources.GetString("sqlDataSource1.ResultSchemaSerializable");
            // 
            // textEditBalance
            // 
            this.textEditBalance.Enabled = false;
            this.textEditBalance.Location = new System.Drawing.Point(408, 103);
            this.textEditBalance.Name = "textEditBalance";
            this.textEditBalance.Properties.Appearance.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textEditBalance.Properties.Appearance.Options.UseFont = true;
            this.textEditBalance.Properties.AppearanceDisabled.ForeColor = System.Drawing.Color.Black;
            this.textEditBalance.Properties.AppearanceDisabled.Options.UseForeColor = true;
            this.textEditBalance.Properties.DisplayFormat.FormatString = "C2";
            this.textEditBalance.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.textEditBalance.Size = new System.Drawing.Size(142, 28);
            this.textEditBalance.TabIndex = 92;
            // 
            // labelControl7
            // 
            this.labelControl7.Appearance.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelControl7.Appearance.Options.UseFont = true;
            this.labelControl7.AutoSizeMode = DevExpress.XtraEditors.LabelAutoSizeMode.Horizontal;
            this.labelControl7.Location = new System.Drawing.Point(349, 110);
            this.labelControl7.Name = "labelControl7";
            this.labelControl7.Size = new System.Drawing.Size(56, 21);
            this.labelControl7.TabIndex = 93;
            this.labelControl7.Text = "Balance:";
            // 
            // labelControl8
            // 
            this.labelControl8.Appearance.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelControl8.Appearance.Options.UseFont = true;
            this.labelControl8.AutoSizeMode = DevExpress.XtraEditors.LabelAutoSizeMode.Horizontal;
            this.labelControl8.Location = new System.Drawing.Point(553, 110);
            this.labelControl8.Name = "labelControl8";
            this.labelControl8.Size = new System.Drawing.Size(122, 21);
            this.labelControl8.TabIndex = 95;
            this.labelControl8.Text = "Regular Payment:";
            // 
            // textEditRegularPayment
            // 
            this.textEditRegularPayment.Enabled = false;
            this.textEditRegularPayment.Location = new System.Drawing.Point(677, 103);
            this.textEditRegularPayment.Name = "textEditRegularPayment";
            this.textEditRegularPayment.Properties.Appearance.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textEditRegularPayment.Properties.Appearance.Options.UseFont = true;
            this.textEditRegularPayment.Properties.AppearanceDisabled.ForeColor = System.Drawing.Color.Black;
            this.textEditRegularPayment.Properties.AppearanceDisabled.Options.UseForeColor = true;
            this.textEditRegularPayment.Properties.DisplayFormat.FormatString = "C2";
            this.textEditRegularPayment.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.textEditRegularPayment.Size = new System.Drawing.Size(84, 28);
            this.textEditRegularPayment.TabIndex = 94;
            // 
            // buttonCancel
            // 
            this.buttonCancel.Appearance.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonCancel.Appearance.Options.UseFont = true;
            this.buttonCancel.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("buttonCancel.ImageOptions.Image")));
            this.buttonCancel.ImageOptions.Location = DevExpress.XtraEditors.ImageLocation.MiddleCenter;
            this.buttonCancel.Location = new System.Drawing.Point(175, 20);
            this.buttonCancel.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.buttonCancel.Name = "buttonCancel";
            this.buttonCancel.Size = new System.Drawing.Size(110, 103);
            this.buttonCancel.TabIndex = 96;
            this.buttonCancel.Click += new System.EventHandler(this.buttonCancel_Click);
            // 
            // cUSTOMER_NOTextBox
            // 
            this.cUSTOMER_NOTextBox.AllowDrop = true;
            this.cUSTOMER_NOTextBox.EnterMoveNextControl = true;
            this.cUSTOMER_NOTextBox.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.cUSTOMER_NOTextBox.Location = new System.Drawing.Point(114, 14);
            this.cUSTOMER_NOTextBox.Name = "cUSTOMER_NOTextBox";
            this.cUSTOMER_NOTextBox.Properties.Appearance.BackColor = System.Drawing.Color.Gold;
            this.cUSTOMER_NOTextBox.Properties.Appearance.BorderColor = System.Drawing.Color.White;
            this.cUSTOMER_NOTextBox.Properties.Appearance.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cUSTOMER_NOTextBox.Properties.Appearance.Options.UseBackColor = true;
            this.cUSTOMER_NOTextBox.Properties.Appearance.Options.UseBorderColor = true;
            this.cUSTOMER_NOTextBox.Properties.Appearance.Options.UseFont = true;
            this.cUSTOMER_NOTextBox.Properties.BeepOnError = true;
            this.cUSTOMER_NOTextBox.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.Simple;
            this.cUSTOMER_NOTextBox.Properties.EditValueChangedDelay = 5000;
            this.cUSTOMER_NOTextBox.Properties.EditValueChangedFiringMode = DevExpress.XtraEditors.Controls.EditValueChangedFiringMode.Buffered;
            this.cUSTOMER_NOTextBox.Properties.MaskSettings.Set("MaskManagerType", typeof(DevExpress.Data.Mask.RegularMaskManager));
            this.cUSTOMER_NOTextBox.Properties.MaskSettings.Set("mask", "\\d*");
            this.cUSTOMER_NOTextBox.Properties.MaskSettings.Set("placeholder", ' ');
            this.cUSTOMER_NOTextBox.Properties.MaskSettings.Set("MaskManagerSignature", "ignoreMaskBlank=True");
            this.cUSTOMER_NOTextBox.Properties.MaxLength = 6;
            this.cUSTOMER_NOTextBox.Size = new System.Drawing.Size(67, 28);
            this.cUSTOMER_NOTextBox.TabIndex = 2;
            this.cUSTOMER_NOTextBox.EditValueChanged += new System.EventHandler(this.cUSTOMER_NOTextBox_EditValueChanged);
            // 
            // labelControlAccountNumber
            // 
            this.labelControlAccountNumber.Appearance.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelControlAccountNumber.Appearance.Options.UseFont = true;
            this.labelControlAccountNumber.Location = new System.Drawing.Point(39, 21);
            this.labelControlAccountNumber.Name = "labelControlAccountNumber";
            this.labelControlAccountNumber.Size = new System.Drawing.Size(72, 21);
            this.labelControlAccountNumber.TabIndex = 3;
            this.labelControlAccountNumber.Text = "Account #:";
            // 
            // checkEditAllNewBusiness
            // 
            this.checkEditAllNewBusiness.Location = new System.Drawing.Point(197, 17);
            this.checkEditAllNewBusiness.Name = "checkEditAllNewBusiness";
            this.checkEditAllNewBusiness.Properties.Appearance.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.checkEditAllNewBusiness.Properties.Appearance.Options.UseFont = true;
            this.checkEditAllNewBusiness.Properties.Caption = "All New Business Last Posting";
            this.checkEditAllNewBusiness.Properties.CheckBoxOptions.Style = DevExpress.XtraEditors.Controls.CheckBoxStyle.SvgCheckBox1;
            this.checkEditAllNewBusiness.Properties.ContentAlignment = DevExpress.Utils.HorzAlignment.Near;
            this.checkEditAllNewBusiness.Properties.NullStyle = DevExpress.XtraEditors.Controls.StyleIndeterminate.Unchecked;
            this.checkEditAllNewBusiness.Size = new System.Drawing.Size(233, 25);
            this.checkEditAllNewBusiness.TabIndex = 4;
            this.checkEditAllNewBusiness.CheckedChanged += new System.EventHandler(this.checkEditAllNewBusiness_CheckedChanged);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.checkEditAllNewBusiness);
            this.groupBox1.Controls.Add(this.cUSTOMER_NOTextBox);
            this.groupBox1.Controls.Add(this.labelControlAccountNumber);
            this.groupBox1.Location = new System.Drawing.Point(156, 0);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(469, 56);
            this.groupBox1.TabIndex = 97;
            this.groupBox1.TabStop = false;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.labelControl10);
            this.groupBox2.Controls.Add(this.textEditTotalPayments);
            this.groupBox2.Controls.Add(this.labelControl9);
            this.groupBox2.Controls.Add(this.textEditPaymentsLeft);
            this.groupBox2.Controls.Add(this.labelControl8);
            this.groupBox2.Controls.Add(this.textEditRegularPayment);
            this.groupBox2.Controls.Add(this.labelControl7);
            this.groupBox2.Controls.Add(this.textEditBalance);
            this.groupBox2.Controls.Add(this.labelControl6);
            this.groupBox2.Controls.Add(this.labelControl5);
            this.groupBox2.Controls.Add(this.labelControl4);
            this.groupBox2.Controls.Add(this.labelControl3);
            this.groupBox2.Controls.Add(this.labelControl2);
            this.groupBox2.Controls.Add(this.textEditZip);
            this.groupBox2.Controls.Add(this.textEditState);
            this.groupBox2.Controls.Add(this.textEditCity);
            this.groupBox2.Controls.Add(this.textEditAddress);
            this.groupBox2.Controls.Add(this.textEditName);
            this.groupBox2.Controls.Add(this.labelControl1);
            this.groupBox2.Controls.Add(this.spinEditStartTicket);
            this.groupBox2.Controls.Add(this.spinEditTicketCount);
            this.groupBox2.Controls.Add(this.DateEditNextPayDate);
            this.groupBox2.Location = new System.Drawing.Point(3, 61);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(774, 179);
            this.groupBox2.TabIndex = 98;
            this.groupBox2.TabStop = false;
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.buttonCancel);
            this.groupBox3.Controls.Add(this.buttonPrint);
            this.groupBox3.Location = new System.Drawing.Point(228, 246);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(324, 136);
            this.groupBox3.TabIndex = 99;
            this.groupBox3.TabStop = false;
            // 
            // labelControl9
            // 
            this.labelControl9.Appearance.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelControl9.Appearance.Options.UseFont = true;
            this.labelControl9.AutoSizeMode = DevExpress.XtraEditors.LabelAutoSizeMode.Horizontal;
            this.labelControl9.Location = new System.Drawing.Point(308, 138);
            this.labelControl9.Name = "labelControl9";
            this.labelControl9.Size = new System.Drawing.Size(97, 21);
            this.labelControl9.TabIndex = 97;
            this.labelControl9.Text = "Payments left:";
            // 
            // textEditPaymentsLeft
            // 
            this.textEditPaymentsLeft.Enabled = false;
            this.textEditPaymentsLeft.Location = new System.Drawing.Point(408, 131);
            this.textEditPaymentsLeft.Name = "textEditPaymentsLeft";
            this.textEditPaymentsLeft.Properties.Appearance.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textEditPaymentsLeft.Properties.Appearance.Options.UseFont = true;
            this.textEditPaymentsLeft.Properties.AppearanceDisabled.ForeColor = System.Drawing.Color.Black;
            this.textEditPaymentsLeft.Properties.AppearanceDisabled.Options.UseForeColor = true;
            this.textEditPaymentsLeft.Properties.DisplayFormat.FormatString = "n0";
            this.textEditPaymentsLeft.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.textEditPaymentsLeft.Size = new System.Drawing.Size(51, 28);
            this.textEditPaymentsLeft.TabIndex = 96;
            // 
            // labelControl10
            // 
            this.labelControl10.Appearance.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelControl10.Appearance.Options.UseFont = true;
            this.labelControl10.AutoSizeMode = DevExpress.XtraEditors.LabelAutoSizeMode.Horizontal;
            this.labelControl10.Location = new System.Drawing.Point(599, 138);
            this.labelControl10.Name = "labelControl10";
            this.labelControl10.Size = new System.Drawing.Size(109, 21);
            this.labelControl10.TabIndex = 99;
            this.labelControl10.Text = "Total payments:";
            // 
            // textEditTotalPayments
            // 
            this.textEditTotalPayments.Enabled = false;
            this.textEditTotalPayments.Location = new System.Drawing.Point(710, 131);
            this.textEditTotalPayments.Name = "textEditTotalPayments";
            this.textEditTotalPayments.Properties.Appearance.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textEditTotalPayments.Properties.Appearance.Options.UseFont = true;
            this.textEditTotalPayments.Properties.AppearanceDisabled.ForeColor = System.Drawing.Color.Black;
            this.textEditTotalPayments.Properties.AppearanceDisabled.Options.UseForeColor = true;
            this.textEditTotalPayments.Properties.DisplayFormat.FormatString = "n0";
            this.textEditTotalPayments.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.textEditTotalPayments.Size = new System.Drawing.Size(51, 28);
            this.textEditTotalPayments.TabIndex = 98;
            // 
            // PrintCoupons
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(779, 394);
            this.Controls.Add(this.groupControl1);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "PrintCoupons";
            this.Text = "Print Loan Payment Coupons";
            this.Load += new System.EventHandler(this.PrintCoupons_Load);
            ((System.ComponentModel.ISupportInitialize)(this.groupControl1)).EndInit();
            this.groupControl1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.textEditZip.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.textEditState.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.textEditCity.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.textEditAddress.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.textEditName.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.spinEditStartTicket.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.spinEditTicketCount.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.DateEditNextPayDate.Properties.CalendarTimeProperties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.DateEditNextPayDate.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.textEditBalance.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.textEditRegularPayment.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cUSTOMER_NOTextBox.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.checkEditAllNewBusiness.Properties)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.textEditPaymentsLeft.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.textEditTotalPayments.Properties)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraEditors.GroupControl groupControl1;
        private DevExpress.XtraEditors.LabelControl labelControl1;
        private DevExpress.XtraEditors.SpinEdit spinEditStartTicket;
        private DevExpress.XtraEditors.SpinEdit spinEditTicketCount;
        private DevExpress.XtraEditors.DateEdit DateEditNextPayDate;
        private DevExpress.XtraEditors.TextEdit textEditZip;
        private DevExpress.XtraEditors.TextEdit textEditState;
        private DevExpress.XtraEditors.TextEdit textEditCity;
        private DevExpress.XtraEditors.TextEdit textEditAddress;
        private DevExpress.XtraEditors.TextEdit textEditName;
        private DevExpress.XtraEditors.LabelControl labelControl4;
        private DevExpress.XtraEditors.LabelControl labelControl3;
        private DevExpress.XtraEditors.LabelControl labelControl2;
        private DevExpress.DataAccess.Sql.SqlDataSource sqlDataSource1;
        public DevExpress.XtraEditors.SimpleButton buttonPrint;
        private DevExpress.XtraEditors.LabelControl labelControl6;
        private DevExpress.XtraEditors.LabelControl labelControl5;
        private DevExpress.XtraEditors.LabelControl labelControl7;
        private DevExpress.XtraEditors.TextEdit textEditBalance;
        private DevExpress.XtraEditors.LabelControl labelControl8;
        private DevExpress.XtraEditors.TextEdit textEditRegularPayment;
        private DevExpress.XtraEditors.SimpleButton buttonCancel;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.GroupBox groupBox1;
        private DevExpress.XtraEditors.CheckEdit checkEditAllNewBusiness;
        private DevExpress.XtraEditors.TextEdit cUSTOMER_NOTextBox;
        private DevExpress.XtraEditors.LabelControl labelControlAccountNumber;
        private System.Windows.Forms.GroupBox groupBox3;
        private DevExpress.XtraEditors.LabelControl labelControl10;
        private DevExpress.XtraEditors.TextEdit textEditTotalPayments;
        private DevExpress.XtraEditors.LabelControl labelControl9;
        private DevExpress.XtraEditors.TextEdit textEditPaymentsLeft;
    }
}
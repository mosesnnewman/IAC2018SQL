namespace IAC2021SQL
{
    partial class FormRepoReport
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
            System.Windows.Forms.Label label50;
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormRepoReport));
            DevExpress.DataAccess.Sql.StoredProcQuery storedProcQuery1 = new DevExpress.DataAccess.Sql.StoredProcQuery();
            DevExpress.DataAccess.Sql.QueryParameter queryParameter1 = new DevExpress.DataAccess.Sql.QueryParameter();
            DevExpress.DataAccess.Sql.QueryParameter queryParameter2 = new DevExpress.DataAccess.Sql.QueryParameter();
            DevExpress.DataAccess.Sql.QueryParameter queryParameter3 = new DevExpress.DataAccess.Sql.QueryParameter();
            DevExpress.DataAccess.Sql.QueryParameter queryParameter4 = new DevExpress.DataAccess.Sql.QueryParameter();
            DevExpress.DataAccess.Sql.QueryParameter queryParameter5 = new DevExpress.DataAccess.Sql.QueryParameter();
            DevExpress.DataAccess.Sql.StoredProcQuery storedProcQuery2 = new DevExpress.DataAccess.Sql.StoredProcQuery();
            DevExpress.DataAccess.Sql.QueryParameter queryParameter6 = new DevExpress.DataAccess.Sql.QueryParameter();
            DevExpress.DataAccess.Sql.QueryParameter queryParameter7 = new DevExpress.DataAccess.Sql.QueryParameter();
            DevExpress.DataAccess.Sql.QueryParameter queryParameter8 = new DevExpress.DataAccess.Sql.QueryParameter();
            DevExpress.DataAccess.Sql.QueryParameter queryParameter9 = new DevExpress.DataAccess.Sql.QueryParameter();
            DevExpress.DataAccess.Sql.QueryParameter queryParameter10 = new DevExpress.DataAccess.Sql.QueryParameter();
            DevExpress.DataAccess.Sql.StoredProcQuery storedProcQuery3 = new DevExpress.DataAccess.Sql.StoredProcQuery();
            DevExpress.DataAccess.Sql.MasterDetailInfo masterDetailInfo1 = new DevExpress.DataAccess.Sql.MasterDetailInfo();
            DevExpress.DataAccess.Sql.RelationColumnInfo relationColumnInfo1 = new DevExpress.DataAccess.Sql.RelationColumnInfo();
            DevExpress.DataAccess.Sql.MasterDetailInfo masterDetailInfo2 = new DevExpress.DataAccess.Sql.MasterDetailInfo();
            DevExpress.DataAccess.Sql.RelationColumnInfo relationColumnInfo2 = new DevExpress.DataAccess.Sql.RelationColumnInfo();
            this.radioButtonY = new System.Windows.Forms.RadioButton();
            this.radioButtonR = new System.Windows.Forms.RadioButton();
            this.radioButtonIndBoth = new System.Windows.Forms.RadioButton();
            this.groupBoxRepoInd = new System.Windows.Forms.GroupBox();
            this.radioButtonZ = new System.Windows.Forms.RadioButton();
            this.radioButtonI = new System.Windows.Forms.RadioButton();
            this.radioButtonP = new System.Windows.Forms.RadioButton();
            this.buttonPrint = new DevExpress.XtraEditors.SimpleButton();
            this.buttonCancel = new DevExpress.XtraEditors.SimpleButton();
            this.comboBoxRepoCodes = new System.Windows.Forms.ComboBox();
            this.bindingSourceRepoCodes = new System.Windows.Forms.BindingSource(this.components);
            this.DelinquencyData = new IAC2021SQL.IACDataSet();
            this.cUSTOMER_REPO_CDEtextBox = new System.Windows.Forms.TextBox();
            this.repoCodesTableAdapter = new IAC2021SQL.IACDataSetTableAdapters.RepoCodesTableAdapter();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.radioButtonStatusBoth = new System.Windows.Forms.RadioButton();
            this.radioButtonInactive = new System.Windows.Forms.RadioButton();
            this.radioButtonActive = new System.Windows.Forms.RadioButton();
            this.nullableDateTimePickerStartDate = new DevExpress.XtraEditors.DateEdit();
            this.nullableDateTimePickerEndDate = new DevExpress.XtraEditors.DateEdit();
            this.labelStart = new System.Windows.Forms.Label();
            this.labelEnd = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.buttonExcel = new DevExpress.XtraEditors.SimpleButton();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.groupControlRepoReport = new DevExpress.XtraEditors.GroupControl();
            this.sqlDataSourceEXCEL = new DevExpress.DataAccess.Sql.SqlDataSource(this.components);
            label50 = new System.Windows.Forms.Label();
            this.groupBoxRepoInd.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.bindingSourceRepoCodes)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.DelinquencyData)).BeginInit();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nullableDateTimePickerStartDate.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nullableDateTimePickerStartDate.Properties.CalendarTimeProperties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nullableDateTimePickerEndDate.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nullableDateTimePickerEndDate.Properties.CalendarTimeProperties)).BeginInit();
            this.groupBox2.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.groupBox4.SuspendLayout();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.groupControlRepoReport)).BeginInit();
            this.groupControlRepoReport.SuspendLayout();
            this.SuspendLayout();
            // 
            // label50
            // 
            label50.AutoSize = true;
            label50.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            label50.Location = new System.Drawing.Point(40, 25);
            label50.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            label50.Name = "label50";
            label50.Size = new System.Drawing.Size(61, 24);
            label50.TabIndex = 119;
            label50.Text = "Code:";
            // 
            // radioButtonY
            // 
            this.radioButtonY.AutoSize = true;
            this.radioButtonY.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.radioButtonY.Location = new System.Drawing.Point(21, 11);
            this.radioButtonY.Margin = new System.Windows.Forms.Padding(6);
            this.radioButtonY.Name = "radioButtonY";
            this.radioButtonY.Size = new System.Drawing.Size(84, 28);
            this.radioButtonY.TabIndex = 0;
            this.radioButtonY.TabStop = true;
            this.radioButtonY.Text = "&Y Only";
            this.radioButtonY.UseVisualStyleBackColor = true;
            // 
            // radioButtonR
            // 
            this.radioButtonR.AutoSize = true;
            this.radioButtonR.Location = new System.Drawing.Point(21, 79);
            this.radioButtonR.Margin = new System.Windows.Forms.Padding(6);
            this.radioButtonR.Name = "radioButtonR";
            this.radioButtonR.Size = new System.Drawing.Size(59, 17);
            this.radioButtonR.TabIndex = 1;
            this.radioButtonR.TabStop = true;
            this.radioButtonR.Text = "&R Only";
            this.radioButtonR.UseVisualStyleBackColor = true;
            // 
            // radioButtonIndBoth
            // 
            this.radioButtonIndBoth.AutoSize = true;
            this.radioButtonIndBoth.Location = new System.Drawing.Point(21, 181);
            this.radioButtonIndBoth.Margin = new System.Windows.Forms.Padding(6);
            this.radioButtonIndBoth.Name = "radioButtonIndBoth";
            this.radioButtonIndBoth.Size = new System.Drawing.Size(38, 17);
            this.radioButtonIndBoth.TabIndex = 2;
            this.radioButtonIndBoth.TabStop = true;
            this.radioButtonIndBoth.Text = "&All";
            this.radioButtonIndBoth.UseVisualStyleBackColor = true;
            // 
            // groupBoxRepoInd
            // 
            this.groupBoxRepoInd.Controls.Add(this.radioButtonZ);
            this.groupBoxRepoInd.Controls.Add(this.radioButtonI);
            this.groupBoxRepoInd.Controls.Add(this.radioButtonP);
            this.groupBoxRepoInd.Controls.Add(this.radioButtonIndBoth);
            this.groupBoxRepoInd.Controls.Add(this.radioButtonR);
            this.groupBoxRepoInd.Controls.Add(this.radioButtonY);
            this.groupBoxRepoInd.Location = new System.Drawing.Point(498, 88);
            this.groupBoxRepoInd.Margin = new System.Windows.Forms.Padding(6);
            this.groupBoxRepoInd.Name = "groupBoxRepoInd";
            this.groupBoxRepoInd.Padding = new System.Windows.Forms.Padding(6);
            this.groupBoxRepoInd.Size = new System.Drawing.Size(126, 221);
            this.groupBoxRepoInd.TabIndex = 3;
            this.groupBoxRepoInd.TabStop = false;
            // 
            // radioButtonZ
            // 
            this.radioButtonZ.AutoSize = true;
            this.radioButtonZ.Location = new System.Drawing.Point(21, 147);
            this.radioButtonZ.Margin = new System.Windows.Forms.Padding(6);
            this.radioButtonZ.Name = "radioButtonZ";
            this.radioButtonZ.Size = new System.Drawing.Size(58, 17);
            this.radioButtonZ.TabIndex = 5;
            this.radioButtonZ.TabStop = true;
            this.radioButtonZ.Text = "&Z Only";
            this.radioButtonZ.UseVisualStyleBackColor = true;
            // 
            // radioButtonI
            // 
            this.radioButtonI.AutoSize = true;
            this.radioButtonI.Location = new System.Drawing.Point(21, 113);
            this.radioButtonI.Margin = new System.Windows.Forms.Padding(6);
            this.radioButtonI.Name = "radioButtonI";
            this.radioButtonI.Size = new System.Drawing.Size(55, 17);
            this.radioButtonI.TabIndex = 4;
            this.radioButtonI.TabStop = true;
            this.radioButtonI.Text = "&I Only";
            this.radioButtonI.UseVisualStyleBackColor = true;
            // 
            // radioButtonP
            // 
            this.radioButtonP.AutoSize = true;
            this.radioButtonP.Location = new System.Drawing.Point(21, 45);
            this.radioButtonP.Margin = new System.Windows.Forms.Padding(6);
            this.radioButtonP.Name = "radioButtonP";
            this.radioButtonP.Size = new System.Drawing.Size(58, 17);
            this.radioButtonP.TabIndex = 3;
            this.radioButtonP.TabStop = true;
            this.radioButtonP.Text = "&P Only";
            this.radioButtonP.UseVisualStyleBackColor = true;
            // 
            // buttonPrint
            // 
            this.buttonPrint.ImageOptions.Image = global::IAC2021SQL.Properties.Resources.Printer;
            this.buttonPrint.ImageOptions.Location = DevExpress.XtraEditors.ImageLocation.MiddleCenter;
            this.buttonPrint.Location = new System.Drawing.Point(54, 27);
            this.buttonPrint.Margin = new System.Windows.Forms.Padding(6);
            this.buttonPrint.Name = "buttonPrint";
            this.buttonPrint.Size = new System.Drawing.Size(138, 135);
            this.buttonPrint.TabIndex = 4;
            this.buttonPrint.Click += new System.EventHandler(this.buttonPrint_Click);
            // 
            // buttonCancel
            // 
            this.buttonCancel.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("buttonCancel.ImageOptions.Image")));
            this.buttonCancel.ImageOptions.Location = DevExpress.XtraEditors.ImageLocation.MiddleCenter;
            this.buttonCancel.Location = new System.Drawing.Point(384, 27);
            this.buttonCancel.Margin = new System.Windows.Forms.Padding(6);
            this.buttonCancel.Name = "buttonCancel";
            this.buttonCancel.Size = new System.Drawing.Size(138, 135);
            this.buttonCancel.TabIndex = 5;
            this.buttonCancel.Click += new System.EventHandler(this.buttonCancel_Click);
            // 
            // comboBoxRepoCodes
            // 
            this.comboBoxRepoCodes.DataSource = this.bindingSourceRepoCodes;
            this.comboBoxRepoCodes.DisplayMember = "Description";
            this.comboBoxRepoCodes.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.comboBoxRepoCodes.FormattingEnabled = true;
            this.comboBoxRepoCodes.Location = new System.Drawing.Point(228, 19);
            this.comboBoxRepoCodes.Margin = new System.Windows.Forms.Padding(6);
            this.comboBoxRepoCodes.Name = "comboBoxRepoCodes";
            this.comboBoxRepoCodes.Size = new System.Drawing.Size(219, 32);
            this.comboBoxRepoCodes.TabIndex = 121;
            // 
            // bindingSourceRepoCodes
            // 
            this.bindingSourceRepoCodes.DataMember = "RepoCodes";
            this.bindingSourceRepoCodes.DataSource = this.DelinquencyData;
            // 
            // DelinquencyData
            // 
            this.DelinquencyData.DataSetName = "IACDataSet";
            this.DelinquencyData.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // cUSTOMER_REPO_CDEtextBox
            // 
            this.cUSTOMER_REPO_CDEtextBox.AllowDrop = true;
            this.cUSTOMER_REPO_CDEtextBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bindingSourceRepoCodes, "Code", true));
            this.cUSTOMER_REPO_CDEtextBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cUSTOMER_REPO_CDEtextBox.Location = new System.Drawing.Point(118, 19);
            this.cUSTOMER_REPO_CDEtextBox.Margin = new System.Windows.Forms.Padding(6);
            this.cUSTOMER_REPO_CDEtextBox.MaxLength = 4;
            this.cUSTOMER_REPO_CDEtextBox.Name = "cUSTOMER_REPO_CDEtextBox";
            this.cUSTOMER_REPO_CDEtextBox.ReadOnly = true;
            this.cUSTOMER_REPO_CDEtextBox.Size = new System.Drawing.Size(98, 29);
            this.cUSTOMER_REPO_CDEtextBox.TabIndex = 120;
            this.cUSTOMER_REPO_CDEtextBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // repoCodesTableAdapter
            // 
            this.repoCodesTableAdapter.ClearBeforeFill = true;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.radioButtonStatusBoth);
            this.groupBox1.Controls.Add(this.radioButtonInactive);
            this.groupBox1.Controls.Add(this.radioButtonActive);
            this.groupBox1.Location = new System.Drawing.Point(363, 88);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(126, 143);
            this.groupBox1.TabIndex = 122;
            this.groupBox1.TabStop = false;
            // 
            // radioButtonStatusBoth
            // 
            this.radioButtonStatusBoth.AutoSize = true;
            this.radioButtonStatusBoth.Location = new System.Drawing.Point(18, 94);
            this.radioButtonStatusBoth.Name = "radioButtonStatusBoth";
            this.radioButtonStatusBoth.Size = new System.Drawing.Size(49, 17);
            this.radioButtonStatusBoth.TabIndex = 2;
            this.radioButtonStatusBoth.TabStop = true;
            this.radioButtonStatusBoth.Text = "&Both";
            this.radioButtonStatusBoth.UseVisualStyleBackColor = true;
            // 
            // radioButtonInactive
            // 
            this.radioButtonInactive.AutoSize = true;
            this.radioButtonInactive.Location = new System.Drawing.Point(18, 57);
            this.radioButtonInactive.Name = "radioButtonInactive";
            this.radioButtonInactive.Size = new System.Drawing.Size(64, 17);
            this.radioButtonInactive.TabIndex = 1;
            this.radioButtonInactive.TabStop = true;
            this.radioButtonInactive.Text = "&Inactive";
            this.radioButtonInactive.UseVisualStyleBackColor = true;
            // 
            // radioButtonActive
            // 
            this.radioButtonActive.AutoSize = true;
            this.radioButtonActive.Location = new System.Drawing.Point(18, 20);
            this.radioButtonActive.Name = "radioButtonActive";
            this.radioButtonActive.Size = new System.Drawing.Size(55, 17);
            this.radioButtonActive.TabIndex = 0;
            this.radioButtonActive.TabStop = true;
            this.radioButtonActive.Text = "&Active";
            this.radioButtonActive.UseVisualStyleBackColor = true;
            // 
            // nullableDateTimePickerStartDate
            // 
            this.nullableDateTimePickerStartDate.EditValue = new System.DateTime(2022, 4, 5, 0, 0, 0, 0);
            this.nullableDateTimePickerStartDate.Location = new System.Drawing.Point(93, 26);
            this.nullableDateTimePickerStartDate.Name = "nullableDateTimePickerStartDate";
            this.nullableDateTimePickerStartDate.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.nullableDateTimePickerStartDate.Properties.CalendarTimeProperties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.nullableDateTimePickerStartDate.Properties.LookAndFeel.SkinName = "McSkin";
            this.nullableDateTimePickerStartDate.Properties.LookAndFeel.UseDefaultLookAndFeel = false;
            this.nullableDateTimePickerStartDate.Size = new System.Drawing.Size(118, 20);
            this.nullableDateTimePickerStartDate.TabIndex = 123;
            // 
            // nullableDateTimePickerEndDate
            // 
            this.nullableDateTimePickerEndDate.EditValue = new System.DateTime(2022, 4, 5, 0, 0, 0, 0);
            this.nullableDateTimePickerEndDate.Location = new System.Drawing.Point(93, 54);
            this.nullableDateTimePickerEndDate.Name = "nullableDateTimePickerEndDate";
            this.nullableDateTimePickerEndDate.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.nullableDateTimePickerEndDate.Properties.CalendarTimeProperties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.nullableDateTimePickerEndDate.Properties.LookAndFeel.SkinName = "McSkin";
            this.nullableDateTimePickerEndDate.Properties.LookAndFeel.UseDefaultLookAndFeel = false;
            this.nullableDateTimePickerEndDate.Size = new System.Drawing.Size(118, 20);
            this.nullableDateTimePickerEndDate.TabIndex = 124;
            // 
            // labelStart
            // 
            this.labelStart.AutoSize = true;
            this.labelStart.Location = new System.Drawing.Point(36, 31);
            this.labelStart.Name = "labelStart";
            this.labelStart.Size = new System.Drawing.Size(34, 13);
            this.labelStart.TabIndex = 125;
            this.labelStart.Text = "Start:";
            // 
            // labelEnd
            // 
            this.labelEnd.AutoSize = true;
            this.labelEnd.Location = new System.Drawing.Point(37, 59);
            this.labelEnd.Name = "labelEnd";
            this.labelEnd.Size = new System.Drawing.Size(30, 13);
            this.labelEnd.TabIndex = 126;
            this.labelEnd.Text = "End:";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.labelEnd);
            this.groupBox2.Controls.Add(this.nullableDateTimePickerEndDate);
            this.groupBox2.Controls.Add(this.nullableDateTimePickerStartDate);
            this.groupBox2.Controls.Add(this.labelStart);
            this.groupBox2.Location = new System.Drawing.Point(111, 88);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(246, 109);
            this.groupBox2.TabIndex = 127;
            this.groupBox2.TabStop = false;
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.buttonExcel);
            this.groupBox3.Controls.Add(this.buttonCancel);
            this.groupBox3.Controls.Add(this.buttonPrint);
            this.groupBox3.Location = new System.Drawing.Point(79, 314);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(576, 189);
            this.groupBox3.TabIndex = 128;
            this.groupBox3.TabStop = false;
            // 
            // buttonExcel
            // 
            this.buttonExcel.ImageOptions.Image = global::IAC2021SQL.Properties.Resources.ExportToExcel_64x;
            this.buttonExcel.ImageOptions.Location = DevExpress.XtraEditors.ImageLocation.MiddleCenter;
            this.buttonExcel.Location = new System.Drawing.Point(219, 27);
            this.buttonExcel.Name = "buttonExcel";
            this.buttonExcel.Size = new System.Drawing.Size(138, 135);
            this.buttonExcel.TabIndex = 19;
            this.buttonExcel.Click += new System.EventHandler(this.buttonExcel_Click);
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.comboBoxRepoCodes);
            this.groupBox4.Controls.Add(label50);
            this.groupBox4.Controls.Add(this.cUSTOMER_REPO_CDEtextBox);
            this.groupBox4.Location = new System.Drawing.Point(112, 12);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(487, 70);
            this.groupBox4.TabIndex = 129;
            this.groupBox4.TabStop = false;
            // 
            // panel1
            // 
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.panel1.Controls.Add(this.groupBox4);
            this.panel1.Controls.Add(this.groupBox3);
            this.panel1.Controls.Add(this.groupBox2);
            this.panel1.Controls.Add(this.groupBox1);
            this.panel1.Controls.Add(this.groupBoxRepoInd);
            this.panel1.Location = new System.Drawing.Point(48, 35);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(739, 519);
            this.panel1.TabIndex = 130;
            // 
            // groupControlRepoReport
            // 
            this.groupControlRepoReport.Appearance.BackColor = System.Drawing.Color.LightSteelBlue;
            this.groupControlRepoReport.Appearance.Options.UseBackColor = true;
            this.groupControlRepoReport.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            this.groupControlRepoReport.Controls.Add(this.panel1);
            this.groupControlRepoReport.Location = new System.Drawing.Point(-1, 0);
            this.groupControlRepoReport.Name = "groupControlRepoReport";
            this.groupControlRepoReport.Size = new System.Drawing.Size(835, 588);
            this.groupControlRepoReport.TabIndex = 131;
            this.groupControlRepoReport.Text = "groupControl1";
            // 
            // sqlDataSourceEXCEL
            // 
            this.sqlDataSourceEXCEL.ConnectionName = "IAC2021SQL.Properties.Settings.IAC2010SQLConnectionString";
            this.sqlDataSourceEXCEL.Name = "sqlDataSourceEXCEL";
            storedProcQuery1.MetaSerializable = "<Meta X=\"-70\" Y=\"-60\" Width=\"248\" Height=\"4481\" />";
            storedProcQuery1.Name = "CUSTOMER";
            queryParameter1.Name = "@RepoInd";
            queryParameter1.Type = typeof(string);
            queryParameter2.Name = "@StartDate";
            queryParameter2.Type = typeof(System.DateTime);
            queryParameter2.ValueInfo = "1753-01-01";
            queryParameter3.Name = "@EndDate";
            queryParameter3.Type = typeof(System.DateTime);
            queryParameter3.ValueInfo = "1753-01-01";
            queryParameter4.Name = "@Status";
            queryParameter4.Type = typeof(string);
            queryParameter5.Name = "@RepoCode";
            queryParameter5.Type = typeof(string);
            storedProcQuery1.Parameters.AddRange(new DevExpress.DataAccess.Sql.QueryParameter[] {
            queryParameter1,
            queryParameter2,
            queryParameter3,
            queryParameter4,
            queryParameter5});
            storedProcQuery1.StoredProcName = "ClosedCustomerFillByRepoCode";
            storedProcQuery2.MetaSerializable = "<Meta X=\"220\" Y=\"-60\" Width=\"170\" Height=\"861\" />";
            storedProcQuery2.Name = "DEALER";
            queryParameter6.Name = "@RepoInd";
            queryParameter6.Type = typeof(string);
            queryParameter7.Name = "@StartDate";
            queryParameter7.Type = typeof(System.DateTime);
            queryParameter7.ValueInfo = "1753-01-01";
            queryParameter8.Name = "@EndDate";
            queryParameter8.Type = typeof(System.DateTime);
            queryParameter8.ValueInfo = "1753-01-01";
            queryParameter9.Name = "@Status";
            queryParameter9.Type = typeof(string);
            queryParameter10.Name = "@RepoCode";
            queryParameter10.Type = typeof(string);
            storedProcQuery2.Parameters.AddRange(new DevExpress.DataAccess.Sql.QueryParameter[] {
            queryParameter6,
            queryParameter7,
            queryParameter8,
            queryParameter9,
            queryParameter10});
            storedProcQuery2.StoredProcName = "ClosedDealersFillByRepoCode";
            storedProcQuery3.MetaSerializable = "<Meta X=\"-180\" Y=\"-60\" Width=\"100\" Height=\"101\" />";
            storedProcQuery3.Name = "RepoCodes";
            storedProcQuery3.StoredProcName = "RepoCodesSelect";
            this.sqlDataSourceEXCEL.Queries.AddRange(new DevExpress.DataAccess.Sql.SqlQuery[] {
            storedProcQuery1,
            storedProcQuery2,
            storedProcQuery3});
            masterDetailInfo1.DetailQueryName = "RepoCodes";
            relationColumnInfo1.NestedKeyColumn = "Code";
            relationColumnInfo1.ParentKeyColumn = "CUSTOMER_REPO_CDE";
            masterDetailInfo1.KeyColumns.Add(relationColumnInfo1);
            masterDetailInfo1.MasterQueryName = "CUSTOMER";
            masterDetailInfo2.DetailQueryName = "DEALER";
            relationColumnInfo2.NestedKeyColumn = "id";
            relationColumnInfo2.ParentKeyColumn = "CUSTOMER_DEALER";
            masterDetailInfo2.KeyColumns.Add(relationColumnInfo2);
            masterDetailInfo2.MasterQueryName = "CUSTOMER";
            this.sqlDataSourceEXCEL.Relations.AddRange(new DevExpress.DataAccess.Sql.MasterDetailInfo[] {
            masterDetailInfo1,
            masterDetailInfo2});
            this.sqlDataSourceEXCEL.ResultSchemaSerializable = resources.GetString("sqlDataSourceEXCEL.ResultSchemaSerializable");
            // 
            // FormRepoReport
            // 
            this.Appearance.Options.UseFont = true;
            this.AutoScaleDimensions = new System.Drawing.SizeF(11F, 24F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.ClientSize = new System.Drawing.Size(832, 588);
            this.Controls.Add(this.groupControlRepoReport);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Margin = new System.Windows.Forms.Padding(6);
            this.Name = "FormRepoReport";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Repo Report";
            this.Load += new System.EventHandler(this.FormRepoReport_Load);
            this.groupBoxRepoInd.ResumeLayout(false);
            this.groupBoxRepoInd.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.bindingSourceRepoCodes)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.DelinquencyData)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nullableDateTimePickerStartDate.Properties.CalendarTimeProperties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nullableDateTimePickerStartDate.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nullableDateTimePickerEndDate.Properties.CalendarTimeProperties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nullableDateTimePickerEndDate.Properties)).EndInit();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.groupBox4.ResumeLayout(false);
            this.groupBox4.PerformLayout();
            this.panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.groupControlRepoReport)).EndInit();
            this.groupControlRepoReport.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.RadioButton radioButtonY;
        private System.Windows.Forms.RadioButton radioButtonR;
        private System.Windows.Forms.RadioButton radioButtonIndBoth;
        private System.Windows.Forms.GroupBox groupBoxRepoInd;
        private DevExpress.XtraEditors.SimpleButton buttonPrint;
        private DevExpress.XtraEditors.SimpleButton buttonCancel;
        private System.Windows.Forms.ComboBox comboBoxRepoCodes;
        private System.Windows.Forms.TextBox cUSTOMER_REPO_CDEtextBox;
        private System.Windows.Forms.BindingSource bindingSourceRepoCodes;
        private IACDataSet DelinquencyData;
        private IACDataSetTableAdapters.RepoCodesTableAdapter repoCodesTableAdapter;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.RadioButton radioButtonStatusBoth;
        private System.Windows.Forms.RadioButton radioButtonInactive;
        private System.Windows.Forms.RadioButton radioButtonActive;
        private DevExpress.XtraEditors.DateEdit nullableDateTimePickerStartDate;
        private DevExpress.XtraEditors.DateEdit nullableDateTimePickerEndDate;
        private System.Windows.Forms.Label labelStart;
        private System.Windows.Forms.Label labelEnd;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.RadioButton radioButtonP;
        private System.Windows.Forms.RadioButton radioButtonI;
        private System.Windows.Forms.RadioButton radioButtonZ;
        private DevExpress.XtraEditors.GroupControl groupControlRepoReport;
        public DevExpress.XtraEditors.SimpleButton buttonExcel;
        private DevExpress.DataAccess.Sql.SqlDataSource sqlDataSourceEXCEL;
    }
}
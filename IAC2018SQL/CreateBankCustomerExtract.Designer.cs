namespace IAC2021SQL
{
    partial class frmCreateBankCustomerExtract
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmCreateBankCustomerExtract));
            this.tabControl1 = new DevExpress.XtraTab.XtraTabControl();
            this.tabSelections = new DevExpress.XtraTab.XtraTabPage();
            this.groupControl1 = new DevExpress.XtraEditors.GroupControl();
            this.groupBoxPI = new System.Windows.Forms.GroupBox();
            this.label2 = new DevExpress.XtraEditors.LabelControl();
            this.label3 = new DevExpress.XtraEditors.LabelControl();
            this.nullableDateTimePickerPIEndDate = new DevExpress.XtraEditors.DateEdit();
            this.nullableDateTimePickerPIStartDate = new DevExpress.XtraEditors.DateEdit();
            this.groupBoxMainSelection = new System.Windows.Forms.GroupBox();
            this.lookUpEditState = new DevExpress.XtraEditors.LookUpEdit();
            this.lookUpEditDealer = new DevExpress.XtraEditors.LookUpEdit();
            this.radioGroupMatch = new DevExpress.XtraEditors.RadioGroup();
            this.simpleButtonClearRadioButtons = new DevExpress.XtraEditors.SimpleButton();
            this.txtControlDateEnd = new DevExpress.XtraEditors.TextEdit();
            this.txtControlDateStart = new DevExpress.XtraEditors.TextEdit();
            this.labelControlDateEnd = new DevExpress.XtraEditors.LabelControl();
            this.labelControlDateStart = new DevExpress.XtraEditors.LabelControl();
            this.checkBoxFundingDate = new DevExpress.XtraEditors.CheckEdit();
            this.labelBuyoutDate = new DevExpress.XtraEditors.LabelControl();
            this.nullableDateTimePickerBuyoutDate = new DevExpress.XtraEditors.DateEdit();
            this.checkBoxRepos = new DevExpress.XtraEditors.CheckEdit();
            this.label1 = new DevExpress.XtraEditors.LabelControl();
            this.labelDealerNum = new DevExpress.XtraEditors.LabelControl();
            this.nullableDateTimePickerEndDate = new DevExpress.XtraEditors.DateEdit();
            this.nullableDateTimePickerStartDate = new DevExpress.XtraEditors.DateEdit();
            this.labelEndDate = new DevExpress.XtraEditors.LabelControl();
            this.labelStartDate = new DevExpress.XtraEditors.LabelControl();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.radioButtonBoth = new System.Windows.Forms.RadioButton();
            this.radioButtonInactive = new System.Windows.Forms.RadioButton();
            this.radioButtonActive = new System.Windows.Forms.RadioButton();
            this.buttonPost = new DevExpress.XtraEditors.SimpleButton();
            this.buttonCancel = new DevExpress.XtraEditors.SimpleButton();
            this.tabFieldList = new DevExpress.XtraTab.XtraTabPage();
            this.groupControl3 = new DevExpress.XtraEditors.GroupControl();
            this.buttonMoveAllFieldsLeft = new DevExpress.XtraEditors.SimpleButton();
            this.buttonMoveSelectedFieldsLeft = new DevExpress.XtraEditors.SimpleButton();
            this.buttonMoveAllFieldsRight = new DevExpress.XtraEditors.SimpleButton();
            this.buttonMoveSelectedFieldsRight = new DevExpress.XtraEditors.SimpleButton();
            this.listBoxFieldList = new DevExpress.XtraEditors.ListBoxControl();
            this.listBoxSelectedFields = new DevExpress.XtraEditors.ListBoxControl();
            this.groupControl2 = new DevExpress.XtraEditors.GroupControl();
            this.bindingSourceDLRLISTBYNUM = new System.Windows.Forms.BindingSource(this.components);
            this.bindingSourceState = new System.Windows.Forms.BindingSource(this.components);
            this.Bank = new IAC2021SQL.IACDataSet();
            this.aCCOUNTTableAdapter = new IAC2021SQL.IACDataSetTableAdapters.ACCOUNTTableAdapter();
            this.DLRLISTBYNUMTableAdapter = new IAC2021SQL.IACDataSetTableAdapters.DLRLISTBYNUMTableAdapter();
            this.stateTableAdapter = new IAC2021SQL.IACDataSetTableAdapters.stateTableAdapter();
            ((System.ComponentModel.ISupportInitialize)(this.tabControl1)).BeginInit();
            this.tabControl1.SuspendLayout();
            this.tabSelections.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl1)).BeginInit();
            this.groupControl1.SuspendLayout();
            this.groupBoxPI.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nullableDateTimePickerPIEndDate.Properties.CalendarTimeProperties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nullableDateTimePickerPIEndDate.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nullableDateTimePickerPIStartDate.Properties.CalendarTimeProperties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nullableDateTimePickerPIStartDate.Properties)).BeginInit();
            this.groupBoxMainSelection.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.lookUpEditState.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lookUpEditDealer.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.radioGroupMatch.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtControlDateEnd.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtControlDateStart.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.checkBoxFundingDate.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nullableDateTimePickerBuyoutDate.Properties.CalendarTimeProperties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nullableDateTimePickerBuyoutDate.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.checkBoxRepos.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nullableDateTimePickerEndDate.Properties.CalendarTimeProperties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nullableDateTimePickerEndDate.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nullableDateTimePickerStartDate.Properties.CalendarTimeProperties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nullableDateTimePickerStartDate.Properties)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.tabFieldList.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl3)).BeginInit();
            this.groupControl3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.listBoxFieldList)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.listBoxSelectedFields)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bindingSourceDLRLISTBYNUM)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bindingSourceState)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Bank)).BeginInit();
            this.SuspendLayout();
            // 
            // tabControl1
            // 
            this.tabControl1.Location = new System.Drawing.Point(0, -4);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedTabPage = this.tabSelections;
            this.tabControl1.Size = new System.Drawing.Size(690, 464);
            this.tabControl1.TabIndex = 0;
            this.tabControl1.TabPages.AddRange(new DevExpress.XtraTab.XtraTabPage[] {
            this.tabSelections,
            this.tabFieldList});
            // 
            // tabSelections
            // 
            this.tabSelections.Appearance.PageClient.BackColor = System.Drawing.Color.LightSteelBlue;
            this.tabSelections.Appearance.PageClient.Options.UseBackColor = true;
            this.tabSelections.Controls.Add(this.groupControl1);
            this.tabSelections.Name = "tabSelections";
            this.tabSelections.Padding = new System.Windows.Forms.Padding(3);
            this.tabSelections.Size = new System.Drawing.Size(682, 434);
            this.tabSelections.Text = "Selection Criteria";
            // 
            // groupControl1
            // 
            this.groupControl1.Appearance.BackColor = System.Drawing.Color.LightSteelBlue;
            this.groupControl1.Appearance.Options.UseBackColor = true;
            this.groupControl1.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            this.groupControl1.Controls.Add(this.groupBoxPI);
            this.groupControl1.Controls.Add(this.groupBoxMainSelection);
            this.groupControl1.Controls.Add(this.groupBox1);
            this.groupControl1.Controls.Add(this.buttonPost);
            this.groupControl1.Controls.Add(this.buttonCancel);
            this.groupControl1.Location = new System.Drawing.Point(0, 2);
            this.groupControl1.Name = "groupControl1";
            this.groupControl1.Size = new System.Drawing.Size(685, 435);
            this.groupControl1.TabIndex = 24;
            this.groupControl1.Text = "groupControl1";
            // 
            // groupBoxPI
            // 
            this.groupBoxPI.Controls.Add(this.label2);
            this.groupBoxPI.Controls.Add(this.label3);
            this.groupBoxPI.Controls.Add(this.nullableDateTimePickerPIEndDate);
            this.groupBoxPI.Controls.Add(this.nullableDateTimePickerPIStartDate);
            this.groupBoxPI.Location = new System.Drawing.Point(465, 99);
            this.groupBoxPI.Name = "groupBoxPI";
            this.groupBoxPI.Size = new System.Drawing.Size(192, 101);
            this.groupBoxPI.TabIndex = 19;
            this.groupBoxPI.TabStop = false;
            this.groupBoxPI.Text = "Paid Interest";
            // 
            // label2
            // 
            this.label2.Location = new System.Drawing.Point(26, 59);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(50, 13);
            this.label2.TabIndex = 37;
            this.label2.Text = "End Date:";
            // 
            // label3
            // 
            this.label3.Location = new System.Drawing.Point(22, 34);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(54, 13);
            this.label3.TabIndex = 36;
            this.label3.Text = "Start Date:";
            // 
            // nullableDateTimePickerPIEndDate
            // 
            this.nullableDateTimePickerPIEndDate.EditValue = new System.DateTime(2022, 2, 13, 0, 0, 0, 0);
            this.nullableDateTimePickerPIEndDate.Location = new System.Drawing.Point(80, 52);
            this.nullableDateTimePickerPIEndDate.Name = "nullableDateTimePickerPIEndDate";
            this.nullableDateTimePickerPIEndDate.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.nullableDateTimePickerPIEndDate.Properties.CalendarTimeProperties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.nullableDateTimePickerPIEndDate.Properties.CalendarView = DevExpress.XtraEditors.Repository.CalendarView.Fluent;
            this.nullableDateTimePickerPIEndDate.Properties.LookAndFeel.SkinName = "McSkin";
            this.nullableDateTimePickerPIEndDate.Properties.LookAndFeel.UseDefaultLookAndFeel = false;
            this.nullableDateTimePickerPIEndDate.Properties.VistaDisplayMode = DevExpress.Utils.DefaultBoolean.False;
            this.nullableDateTimePickerPIEndDate.Size = new System.Drawing.Size(95, 20);
            this.nullableDateTimePickerPIEndDate.TabIndex = 21;
            // 
            // nullableDateTimePickerPIStartDate
            // 
            this.nullableDateTimePickerPIStartDate.EditValue = new System.DateTime(2022, 2, 13, 0, 0, 0, 0);
            this.nullableDateTimePickerPIStartDate.Location = new System.Drawing.Point(80, 27);
            this.nullableDateTimePickerPIStartDate.Name = "nullableDateTimePickerPIStartDate";
            this.nullableDateTimePickerPIStartDate.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.nullableDateTimePickerPIStartDate.Properties.CalendarTimeProperties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.nullableDateTimePickerPIStartDate.Properties.CalendarView = DevExpress.XtraEditors.Repository.CalendarView.Fluent;
            this.nullableDateTimePickerPIStartDate.Properties.LookAndFeel.SkinName = "McSkin";
            this.nullableDateTimePickerPIStartDate.Properties.LookAndFeel.UseDefaultLookAndFeel = false;
            this.nullableDateTimePickerPIStartDate.Properties.VistaDisplayMode = DevExpress.Utils.DefaultBoolean.False;
            this.nullableDateTimePickerPIStartDate.Size = new System.Drawing.Size(95, 20);
            this.nullableDateTimePickerPIStartDate.TabIndex = 20;
            // 
            // groupBoxMainSelection
            // 
            this.groupBoxMainSelection.Controls.Add(this.lookUpEditState);
            this.groupBoxMainSelection.Controls.Add(this.lookUpEditDealer);
            this.groupBoxMainSelection.Controls.Add(this.radioGroupMatch);
            this.groupBoxMainSelection.Controls.Add(this.simpleButtonClearRadioButtons);
            this.groupBoxMainSelection.Controls.Add(this.txtControlDateEnd);
            this.groupBoxMainSelection.Controls.Add(this.txtControlDateStart);
            this.groupBoxMainSelection.Controls.Add(this.labelControlDateEnd);
            this.groupBoxMainSelection.Controls.Add(this.labelControlDateStart);
            this.groupBoxMainSelection.Controls.Add(this.checkBoxFundingDate);
            this.groupBoxMainSelection.Controls.Add(this.labelBuyoutDate);
            this.groupBoxMainSelection.Controls.Add(this.nullableDateTimePickerBuyoutDate);
            this.groupBoxMainSelection.Controls.Add(this.checkBoxRepos);
            this.groupBoxMainSelection.Controls.Add(this.label1);
            this.groupBoxMainSelection.Controls.Add(this.labelDealerNum);
            this.groupBoxMainSelection.Controls.Add(this.nullableDateTimePickerEndDate);
            this.groupBoxMainSelection.Controls.Add(this.nullableDateTimePickerStartDate);
            this.groupBoxMainSelection.Controls.Add(this.labelEndDate);
            this.groupBoxMainSelection.Controls.Add(this.labelStartDate);
            this.groupBoxMainSelection.Location = new System.Drawing.Point(25, 99);
            this.groupBoxMainSelection.Name = "groupBoxMainSelection";
            this.groupBoxMainSelection.Size = new System.Drawing.Size(434, 209);
            this.groupBoxMainSelection.TabIndex = 5;
            this.groupBoxMainSelection.TabStop = false;
            this.groupBoxMainSelection.Text = "Standard Filters";
            // 
            // lookUpEditState
            // 
            this.lookUpEditState.Location = new System.Drawing.Point(103, 121);
            this.lookUpEditState.Name = "lookUpEditState";
            this.lookUpEditState.Properties.Appearance.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lookUpEditState.Properties.Appearance.Options.UseFont = true;
            this.lookUpEditState.Properties.BestFitMode = DevExpress.XtraEditors.Controls.BestFitMode.BestFitResizePopup;
            this.lookUpEditState.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.lookUpEditState.Properties.Columns.AddRange(new DevExpress.XtraEditors.Controls.LookUpColumnInfo[] {
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("name", "name", 37, DevExpress.Utils.FormatType.None, "", true, DevExpress.Utils.HorzAlignment.Near, DevExpress.Data.ColumnSortOrder.None, DevExpress.Utils.DefaultBoolean.Default),
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("abbreviation", "abbreviation", 74, DevExpress.Utils.FormatType.None, "", true, DevExpress.Utils.HorzAlignment.Near, DevExpress.Data.ColumnSortOrder.None, DevExpress.Utils.DefaultBoolean.Default)});
            this.lookUpEditState.Properties.DataSource = this.bindingSourceState;
            this.lookUpEditState.Properties.DisplayMember = "name";
            this.lookUpEditState.Properties.NullText = "";
            this.lookUpEditState.Properties.ValueMember = "abbreviation";
            this.lookUpEditState.Size = new System.Drawing.Size(86, 26);
            this.lookUpEditState.TabIndex = 119;
            // 
            // lookUpEditDealer
            // 
            this.lookUpEditDealer.Location = new System.Drawing.Point(103, 93);
            this.lookUpEditDealer.Name = "lookUpEditDealer";
            this.lookUpEditDealer.Properties.Appearance.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lookUpEditDealer.Properties.Appearance.Options.UseFont = true;
            this.lookUpEditDealer.Properties.BestFitMode = DevExpress.XtraEditors.Controls.BestFitMode.BestFitResizePopup;
            this.lookUpEditDealer.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.lookUpEditDealer.Properties.Columns.AddRange(new DevExpress.XtraEditors.Controls.LookUpColumnInfo[] {
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("id", "id", 100, DevExpress.Utils.FormatType.Numeric, "", true, DevExpress.Utils.HorzAlignment.Near, DevExpress.Data.ColumnSortOrder.None, DevExpress.Utils.DefaultBoolean.Default),
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("DEALER_NAME", "DEALER_NAME", 800, DevExpress.Utils.FormatType.None, "", true, DevExpress.Utils.HorzAlignment.Near, DevExpress.Data.ColumnSortOrder.None, DevExpress.Utils.DefaultBoolean.Default)});
            this.lookUpEditDealer.Properties.DataSource = this.bindingSourceDLRLISTBYNUM;
            this.lookUpEditDealer.Properties.DisplayMember = "id";
            this.lookUpEditDealer.Properties.LookAndFeel.SkinName = "McSkin";
            this.lookUpEditDealer.Properties.LookAndFeel.UseDefaultLookAndFeel = false;
            this.lookUpEditDealer.Properties.NullText = "";
            this.lookUpEditDealer.Properties.ValueMember = "id";
            this.lookUpEditDealer.Size = new System.Drawing.Size(86, 26);
            this.lookUpEditDealer.TabIndex = 12;
            // 
            // radioGroupMatch
            // 
            this.radioGroupMatch.Location = new System.Drawing.Point(280, 120);
            this.radioGroupMatch.Name = "radioGroupMatch";
            this.radioGroupMatch.Properties.Appearance.BackColor = System.Drawing.Color.LightSteelBlue;
            this.radioGroupMatch.Properties.Appearance.Options.UseBackColor = true;
            this.radioGroupMatch.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            this.radioGroupMatch.Properties.Items.AddRange(new DevExpress.XtraEditors.Controls.RadioGroupItem[] {
            new DevExpress.XtraEditors.Controls.RadioGroupItem(null, "Match N.B. Fields"),
            new DevExpress.XtraEditors.Controls.RadioGroupItem(null, "Match Trial Balance"),
            new DevExpress.XtraEditors.Controls.RadioGroupItem(null, "ExtensionExtract")});
            this.radioGroupMatch.Properties.LookAndFeel.SkinName = "McSkin";
            this.radioGroupMatch.Properties.LookAndFeel.UseDefaultLookAndFeel = false;
            this.radioGroupMatch.Size = new System.Drawing.Size(132, 83);
            this.radioGroupMatch.TabIndex = 24;
            this.radioGroupMatch.SelectedIndexChanged += new System.EventHandler(this.radioGroupMatch_SelectedIndexChanged);
            // 
            // simpleButtonClearRadioButtons
            // 
            this.simpleButtonClearRadioButtons.Location = new System.Drawing.Point(154, 182);
            this.simpleButtonClearRadioButtons.Name = "simpleButtonClearRadioButtons";
            this.simpleButtonClearRadioButtons.Size = new System.Drawing.Size(119, 23);
            this.simpleButtonClearRadioButtons.TabIndex = 118;
            this.simpleButtonClearRadioButtons.Text = "&Clear Radio Buttons";
            this.simpleButtonClearRadioButtons.Click += new System.EventHandler(this.simpleButtonClearRadioButtons_Click);
            // 
            // txtControlDateEnd
            // 
            this.txtControlDateEnd.Location = new System.Drawing.Point(356, 66);
            this.txtControlDateEnd.Name = "txtControlDateEnd";
            this.txtControlDateEnd.Properties.MaskSettings.Set("MaskManagerType", typeof(DevExpress.Data.Mask.SimpleMaskManager));
            this.txtControlDateEnd.Properties.MaskSettings.Set("MaskManagerSignature", "ignoreMaskBlank=True");
            this.txtControlDateEnd.Properties.MaskSettings.Set("mask", "00/00");
            this.txtControlDateEnd.Properties.MaskSettings.Set("saveLiterals", false);
            this.txtControlDateEnd.Properties.UseMaskAsDisplayFormat = true;
            this.txtControlDateEnd.Size = new System.Drawing.Size(41, 20);
            this.txtControlDateEnd.TabIndex = 10;
            // 
            // txtControlDateStart
            // 
            this.txtControlDateStart.Location = new System.Drawing.Point(356, 41);
            this.txtControlDateStart.Name = "txtControlDateStart";
            this.txtControlDateStart.Properties.MaskSettings.Set("MaskManagerType", typeof(DevExpress.Data.Mask.SimpleMaskManager));
            this.txtControlDateStart.Properties.MaskSettings.Set("MaskManagerSignature", "ignoreMaskBlank=True");
            this.txtControlDateStart.Properties.MaskSettings.Set("mask", "00/00");
            this.txtControlDateStart.Properties.MaskSettings.Set("saveLiterals", false);
            this.txtControlDateStart.Properties.UseMaskAsDisplayFormat = true;
            this.txtControlDateStart.Size = new System.Drawing.Size(41, 20);
            this.txtControlDateStart.TabIndex = 9;
            // 
            // labelControlDateEnd
            // 
            this.labelControlDateEnd.Location = new System.Drawing.Point(231, 75);
            this.labelControlDateEnd.Name = "labelControlDateEnd";
            this.labelControlDateEnd.Size = new System.Drawing.Size(92, 13);
            this.labelControlDateEnd.TabIndex = 116;
            this.labelControlDateEnd.Text = "End Control Date:";
            // 
            // labelControlDateStart
            // 
            this.labelControlDateStart.Location = new System.Drawing.Point(231, 50);
            this.labelControlDateStart.Name = "labelControlDateStart";
            this.labelControlDateStart.Size = new System.Drawing.Size(96, 13);
            this.labelControlDateStart.TabIndex = 114;
            this.labelControlDateStart.Text = "Start Control Date:";
            // 
            // checkBoxFundingDate
            // 
            this.checkBoxFundingDate.Location = new System.Drawing.Point(6, 156);
            this.checkBoxFundingDate.Name = "checkBoxFundingDate";
            this.checkBoxFundingDate.Properties.Caption = "Funding Date Search";
            this.checkBoxFundingDate.Properties.LookAndFeel.SkinName = "McSkin";
            this.checkBoxFundingDate.Properties.LookAndFeel.UseDefaultLookAndFeel = false;
            this.checkBoxFundingDate.Size = new System.Drawing.Size(134, 20);
            this.checkBoxFundingDate.TabIndex = 14;
            // 
            // labelBuyoutDate
            // 
            this.labelBuyoutDate.Location = new System.Drawing.Point(231, 23);
            this.labelBuyoutDate.Name = "labelBuyoutDate";
            this.labelBuyoutDate.Size = new System.Drawing.Size(67, 13);
            this.labelBuyoutDate.TabIndex = 33;
            this.labelBuyoutDate.Text = "Buyout Date:";
            // 
            // nullableDateTimePickerBuyoutDate
            // 
            this.nullableDateTimePickerBuyoutDate.EditValue = new System.DateTime(2022, 2, 13, 0, 0, 0, 0);
            this.nullableDateTimePickerBuyoutDate.Location = new System.Drawing.Point(302, 16);
            this.nullableDateTimePickerBuyoutDate.Name = "nullableDateTimePickerBuyoutDate";
            this.nullableDateTimePickerBuyoutDate.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.nullableDateTimePickerBuyoutDate.Properties.CalendarTimeProperties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.nullableDateTimePickerBuyoutDate.Properties.CalendarView = DevExpress.XtraEditors.Repository.CalendarView.Fluent;
            this.nullableDateTimePickerBuyoutDate.Properties.LookAndFeel.SkinName = "McSkin";
            this.nullableDateTimePickerBuyoutDate.Properties.LookAndFeel.UseDefaultLookAndFeel = false;
            this.nullableDateTimePickerBuyoutDate.Properties.VistaDisplayMode = DevExpress.Utils.DefaultBoolean.False;
            this.nullableDateTimePickerBuyoutDate.Size = new System.Drawing.Size(95, 20);
            this.nullableDateTimePickerBuyoutDate.TabIndex = 7;
            // 
            // checkBoxRepos
            // 
            this.checkBoxRepos.Location = new System.Drawing.Point(166, 156);
            this.checkBoxRepos.Name = "checkBoxRepos";
            this.checkBoxRepos.Properties.Caption = "Repos Only";
            this.checkBoxRepos.Properties.LookAndFeel.SkinName = "McSkin";
            this.checkBoxRepos.Properties.LookAndFeel.UseDefaultLookAndFeel = false;
            this.checkBoxRepos.Size = new System.Drawing.Size(85, 20);
            this.checkBoxRepos.TabIndex = 15;
            // 
            // label1
            // 
            this.label1.Location = new System.Drawing.Point(34, 134);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(65, 13);
            this.label1.TabIndex = 30;
            this.label1.Text = "Dealer State:";
            // 
            // labelDealerNum
            // 
            this.labelDealerNum.Location = new System.Drawing.Point(63, 106);
            this.labelDealerNum.Name = "labelDealerNum";
            this.labelDealerNum.Size = new System.Drawing.Size(36, 13);
            this.labelDealerNum.TabIndex = 22;
            this.labelDealerNum.Text = "Dealer:";
            // 
            // nullableDateTimePickerEndDate
            // 
            this.nullableDateTimePickerEndDate.EditValue = new System.DateTime(2022, 2, 13, 0, 0, 0, 0);
            this.nullableDateTimePickerEndDate.Location = new System.Drawing.Point(103, 41);
            this.nullableDateTimePickerEndDate.Name = "nullableDateTimePickerEndDate";
            this.nullableDateTimePickerEndDate.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.nullableDateTimePickerEndDate.Properties.CalendarTimeProperties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.nullableDateTimePickerEndDate.Properties.CalendarView = DevExpress.XtraEditors.Repository.CalendarView.Fluent;
            this.nullableDateTimePickerEndDate.Properties.LookAndFeel.SkinName = "McSkin";
            this.nullableDateTimePickerEndDate.Properties.LookAndFeel.UseDefaultLookAndFeel = false;
            this.nullableDateTimePickerEndDate.Properties.VistaDisplayMode = DevExpress.Utils.DefaultBoolean.False;
            this.nullableDateTimePickerEndDate.Size = new System.Drawing.Size(95, 20);
            this.nullableDateTimePickerEndDate.TabIndex = 8;
            // 
            // nullableDateTimePickerStartDate
            // 
            this.nullableDateTimePickerStartDate.EditValue = new System.DateTime(2022, 2, 13, 0, 0, 0, 0);
            this.nullableDateTimePickerStartDate.Location = new System.Drawing.Point(103, 16);
            this.nullableDateTimePickerStartDate.Name = "nullableDateTimePickerStartDate";
            this.nullableDateTimePickerStartDate.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.nullableDateTimePickerStartDate.Properties.CalendarTimeProperties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.nullableDateTimePickerStartDate.Properties.CalendarView = DevExpress.XtraEditors.Repository.CalendarView.Fluent;
            this.nullableDateTimePickerStartDate.Properties.LookAndFeel.SkinName = "McSkin";
            this.nullableDateTimePickerStartDate.Properties.LookAndFeel.UseDefaultLookAndFeel = false;
            this.nullableDateTimePickerStartDate.Properties.VistaDisplayMode = DevExpress.Utils.DefaultBoolean.False;
            this.nullableDateTimePickerStartDate.Size = new System.Drawing.Size(95, 20);
            this.nullableDateTimePickerStartDate.TabIndex = 6;
            // 
            // labelEndDate
            // 
            this.labelEndDate.Location = new System.Drawing.Point(49, 45);
            this.labelEndDate.Name = "labelEndDate";
            this.labelEndDate.Size = new System.Drawing.Size(50, 13);
            this.labelEndDate.TabIndex = 19;
            this.labelEndDate.Text = "End Date:";
            // 
            // labelStartDate
            // 
            this.labelStartDate.Location = new System.Drawing.Point(45, 23);
            this.labelStartDate.Name = "labelStartDate";
            this.labelStartDate.Size = new System.Drawing.Size(54, 13);
            this.labelStartDate.TabIndex = 16;
            this.labelStartDate.Text = "Start Date:";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.radioButtonBoth);
            this.groupBox1.Controls.Add(this.radioButtonInactive);
            this.groupBox1.Controls.Add(this.radioButtonActive);
            this.groupBox1.Location = new System.Drawing.Point(284, 3);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(115, 91);
            this.groupBox1.TabIndex = 1;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Status";
            // 
            // radioButtonBoth
            // 
            this.radioButtonBoth.AutoSize = true;
            this.radioButtonBoth.Location = new System.Drawing.Point(21, 55);
            this.radioButtonBoth.Name = "radioButtonBoth";
            this.radioButtonBoth.Size = new System.Drawing.Size(50, 17);
            this.radioButtonBoth.TabIndex = 4;
            this.radioButtonBoth.TabStop = true;
            this.radioButtonBoth.Text = "&Both";
            this.radioButtonBoth.UseVisualStyleBackColor = true;
            // 
            // radioButtonInactive
            // 
            this.radioButtonInactive.AutoSize = true;
            this.radioButtonInactive.Location = new System.Drawing.Point(21, 35);
            this.radioButtonInactive.Name = "radioButtonInactive";
            this.radioButtonInactive.Size = new System.Drawing.Size(64, 17);
            this.radioButtonInactive.TabIndex = 3;
            this.radioButtonInactive.TabStop = true;
            this.radioButtonInactive.Text = "&Inactive";
            this.radioButtonInactive.UseVisualStyleBackColor = true;
            // 
            // radioButtonActive
            // 
            this.radioButtonActive.AutoSize = true;
            this.radioButtonActive.Location = new System.Drawing.Point(21, 15);
            this.radioButtonActive.Name = "radioButtonActive";
            this.radioButtonActive.Size = new System.Drawing.Size(55, 17);
            this.radioButtonActive.TabIndex = 2;
            this.radioButtonActive.TabStop = true;
            this.radioButtonActive.Text = "&Active";
            this.radioButtonActive.UseVisualStyleBackColor = true;
            // 
            // buttonPost
            // 
            this.buttonPost.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("buttonPost.ImageOptions.Image")));
            this.buttonPost.ImageOptions.ImageToTextAlignment = DevExpress.XtraEditors.ImageAlignToText.TopCenter;
            this.buttonPost.Location = new System.Drawing.Point(222, 325);
            this.buttonPost.LookAndFeel.SkinName = "McSkin";
            this.buttonPost.LookAndFeel.UseDefaultLookAndFeel = false;
            this.buttonPost.Name = "buttonPost";
            this.buttonPost.Size = new System.Drawing.Size(110, 103);
            this.buttonPost.TabIndex = 22;
            this.buttonPost.Text = "Create &Extract";
            this.buttonPost.Click += new System.EventHandler(this.buttonTransfer_Click);
            // 
            // buttonCancel
            // 
            this.buttonCancel.Appearance.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonCancel.Appearance.Options.UseFont = true;
            this.buttonCancel.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("buttonCancel.ImageOptions.Image")));
            this.buttonCancel.ImageOptions.ImageToTextAlignment = DevExpress.XtraEditors.ImageAlignToText.TopCenter;
            this.buttonCancel.Location = new System.Drawing.Point(350, 325);
            this.buttonCancel.LookAndFeel.SkinName = "McSkin";
            this.buttonCancel.LookAndFeel.UseDefaultLookAndFeel = false;
            this.buttonCancel.Margin = new System.Windows.Forms.Padding(4);
            this.buttonCancel.Name = "buttonCancel";
            this.buttonCancel.Size = new System.Drawing.Size(110, 103);
            this.buttonCancel.TabIndex = 23;
            this.buttonCancel.Text = "&Cancel";
            this.buttonCancel.Click += new System.EventHandler(this.buttonCancel_Click);
            // 
            // tabFieldList
            // 
            this.tabFieldList.Appearance.PageClient.BackColor = System.Drawing.Color.LightSteelBlue;
            this.tabFieldList.Appearance.PageClient.Options.UseBackColor = true;
            this.tabFieldList.Controls.Add(this.groupControl3);
            this.tabFieldList.Name = "tabFieldList";
            this.tabFieldList.Padding = new System.Windows.Forms.Padding(3);
            this.tabFieldList.Size = new System.Drawing.Size(682, 434);
            this.tabFieldList.Text = "Field Selection";
            // 
            // groupControl3
            // 
            this.groupControl3.Appearance.BackColor = System.Drawing.Color.LightSteelBlue;
            this.groupControl3.Appearance.Options.UseBackColor = true;
            this.groupControl3.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            this.groupControl3.Controls.Add(this.buttonMoveAllFieldsLeft);
            this.groupControl3.Controls.Add(this.buttonMoveSelectedFieldsLeft);
            this.groupControl3.Controls.Add(this.buttonMoveAllFieldsRight);
            this.groupControl3.Controls.Add(this.buttonMoveSelectedFieldsRight);
            this.groupControl3.Controls.Add(this.listBoxFieldList);
            this.groupControl3.Controls.Add(this.listBoxSelectedFields);
            this.groupControl3.Location = new System.Drawing.Point(1, 0);
            this.groupControl3.Name = "groupControl3";
            this.groupControl3.Size = new System.Drawing.Size(685, 433);
            this.groupControl3.TabIndex = 6;
            this.groupControl3.Text = "groupControl3";
            // 
            // buttonMoveAllFieldsLeft
            // 
            this.buttonMoveAllFieldsLeft.ImageOptions.Image = global::IAC2021SQL.Properties.Resources.CollapseChevronLeftGroup_16x1;
            this.buttonMoveAllFieldsLeft.ImageOptions.Location = DevExpress.XtraEditors.ImageLocation.MiddleCenter;
            this.buttonMoveAllFieldsLeft.Location = new System.Drawing.Point(289, 303);
            this.buttonMoveAllFieldsLeft.LookAndFeel.SkinName = "McSkin";
            this.buttonMoveAllFieldsLeft.LookAndFeel.UseDefaultLookAndFeel = false;
            this.buttonMoveAllFieldsLeft.Name = "buttonMoveAllFieldsLeft";
            this.buttonMoveAllFieldsLeft.Size = new System.Drawing.Size(101, 48);
            this.buttonMoveAllFieldsLeft.TabIndex = 5;
            this.buttonMoveAllFieldsLeft.Click += new System.EventHandler(this.buttonMoveAllFieldsLeft_Click);
            // 
            // buttonMoveSelectedFieldsLeft
            // 
            this.buttonMoveSelectedFieldsLeft.ImageOptions.Image = global::IAC2021SQL.Properties.Resources.CollapseChevronLeft_16x;
            this.buttonMoveSelectedFieldsLeft.ImageOptions.Location = DevExpress.XtraEditors.ImageLocation.MiddleCenter;
            this.buttonMoveSelectedFieldsLeft.Location = new System.Drawing.Point(290, 229);
            this.buttonMoveSelectedFieldsLeft.LookAndFeel.SkinName = "McSkin";
            this.buttonMoveSelectedFieldsLeft.LookAndFeel.UseDefaultLookAndFeel = false;
            this.buttonMoveSelectedFieldsLeft.Name = "buttonMoveSelectedFieldsLeft";
            this.buttonMoveSelectedFieldsLeft.Size = new System.Drawing.Size(101, 48);
            this.buttonMoveSelectedFieldsLeft.TabIndex = 4;
            this.buttonMoveSelectedFieldsLeft.Click += new System.EventHandler(this.buttonMoveSelectedFieldsLeft_Click);
            // 
            // buttonMoveAllFieldsRight
            // 
            this.buttonMoveAllFieldsRight.ImageOptions.Image = global::IAC2021SQL.Properties.Resources.ExpandChevronRightGroup_16x;
            this.buttonMoveAllFieldsRight.ImageOptions.Location = DevExpress.XtraEditors.ImageLocation.MiddleCenter;
            this.buttonMoveAllFieldsRight.Location = new System.Drawing.Point(290, 155);
            this.buttonMoveAllFieldsRight.LookAndFeel.SkinName = "McSkin";
            this.buttonMoveAllFieldsRight.LookAndFeel.UseDefaultLookAndFeel = false;
            this.buttonMoveAllFieldsRight.Name = "buttonMoveAllFieldsRight";
            this.buttonMoveAllFieldsRight.Size = new System.Drawing.Size(101, 48);
            this.buttonMoveAllFieldsRight.TabIndex = 3;
            this.buttonMoveAllFieldsRight.Click += new System.EventHandler(this.buttonMoveAllFieldsRight_Click);
            // 
            // buttonMoveSelectedFieldsRight
            // 
            this.buttonMoveSelectedFieldsRight.ImageOptions.Image = global::IAC2021SQL.Properties.Resources.ExpandChevronRight_16x;
            this.buttonMoveSelectedFieldsRight.ImageOptions.Location = DevExpress.XtraEditors.ImageLocation.MiddleCenter;
            this.buttonMoveSelectedFieldsRight.Location = new System.Drawing.Point(289, 81);
            this.buttonMoveSelectedFieldsRight.LookAndFeel.SkinName = "McSkin";
            this.buttonMoveSelectedFieldsRight.LookAndFeel.UseDefaultLookAndFeel = false;
            this.buttonMoveSelectedFieldsRight.Name = "buttonMoveSelectedFieldsRight";
            this.buttonMoveSelectedFieldsRight.Size = new System.Drawing.Size(101, 48);
            this.buttonMoveSelectedFieldsRight.TabIndex = 2;
            this.buttonMoveSelectedFieldsRight.Click += new System.EventHandler(this.buttonMoveSelectedFieldsRight_Click);
            // 
            // listBoxFieldList
            // 
            this.listBoxFieldList.Location = new System.Drawing.Point(2, 6);
            this.listBoxFieldList.Name = "listBoxFieldList";
            this.listBoxFieldList.SelectionMode = System.Windows.Forms.SelectionMode.MultiExtended;
            this.listBoxFieldList.Size = new System.Drawing.Size(281, 420);
            this.listBoxFieldList.TabIndex = 0;
            // 
            // listBoxSelectedFields
            // 
            this.listBoxSelectedFields.Location = new System.Drawing.Point(397, 6);
            this.listBoxSelectedFields.Name = "listBoxSelectedFields";
            this.listBoxSelectedFields.SelectionMode = System.Windows.Forms.SelectionMode.MultiExtended;
            this.listBoxSelectedFields.Size = new System.Drawing.Size(281, 420);
            this.listBoxSelectedFields.TabIndex = 1;
            // 
            // groupControl2
            // 
            this.groupControl2.Appearance.BackColor = System.Drawing.Color.LightSteelBlue;
            this.groupControl2.Appearance.Options.UseBackColor = true;
            this.groupControl2.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            this.groupControl2.Location = new System.Drawing.Point(1, 26);
            this.groupControl2.Name = "groupControl2";
            this.groupControl2.Size = new System.Drawing.Size(688, 437);
            this.groupControl2.TabIndex = 1;
            this.groupControl2.Text = "groupControl2";
            // 
            // bindingSourceDLRLISTBYNUM
            // 
            this.bindingSourceDLRLISTBYNUM.DataMember = "DLRLISTBYNUM";
            this.bindingSourceDLRLISTBYNUM.DataSource = this.Bank;
            // 
            // bindingSourceState
            // 
            this.bindingSourceState.AllowNew = true;
            this.bindingSourceState.DataMember = "state";
            this.bindingSourceState.DataSource = this.Bank;
            // 
            // Bank
            // 
            this.Bank.DataSetName = "IACDataSet";
            this.Bank.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // aCCOUNTTableAdapter
            // 
            this.aCCOUNTTableAdapter.ClearBeforeFill = true;
            // 
            // DLRLISTBYNUMTableAdapter
            // 
            this.DLRLISTBYNUMTableAdapter.ClearBeforeFill = true;
            // 
            // stateTableAdapter
            // 
            this.stateTableAdapter.ClearBeforeFill = true;
            // 
            // frmCreateBankCustomerExtract
            // 
            this.Appearance.Options.UseFont = true;
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.ClientSize = new System.Drawing.Size(691, 461);
            this.Controls.Add(this.tabControl1);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "frmCreateBankCustomerExtract";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Create Bank Customer Extract";
            this.Load += new System.EventHandler(this.frmCreateBankCustomerExtract_Load);
            ((System.ComponentModel.ISupportInitialize)(this.tabControl1)).EndInit();
            this.tabControl1.ResumeLayout(false);
            this.tabSelections.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.groupControl1)).EndInit();
            this.groupControl1.ResumeLayout(false);
            this.groupBoxPI.ResumeLayout(false);
            this.groupBoxPI.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nullableDateTimePickerPIEndDate.Properties.CalendarTimeProperties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nullableDateTimePickerPIEndDate.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nullableDateTimePickerPIStartDate.Properties.CalendarTimeProperties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nullableDateTimePickerPIStartDate.Properties)).EndInit();
            this.groupBoxMainSelection.ResumeLayout(false);
            this.groupBoxMainSelection.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.lookUpEditState.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lookUpEditDealer.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.radioGroupMatch.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtControlDateEnd.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtControlDateStart.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.checkBoxFundingDate.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nullableDateTimePickerBuyoutDate.Properties.CalendarTimeProperties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nullableDateTimePickerBuyoutDate.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.checkBoxRepos.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nullableDateTimePickerEndDate.Properties.CalendarTimeProperties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nullableDateTimePickerEndDate.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nullableDateTimePickerStartDate.Properties.CalendarTimeProperties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nullableDateTimePickerStartDate.Properties)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.tabFieldList.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.groupControl3)).EndInit();
            this.groupControl3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.listBoxFieldList)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.listBoxSelectedFields)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bindingSourceDLRLISTBYNUM)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bindingSourceState)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Bank)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraTab.XtraTabControl tabControl1;
        private DevExpress.XtraTab.XtraTabPage tabSelections;
        private System.Windows.Forms.GroupBox groupBoxPI;
        private DevExpress.XtraEditors.LabelControl label2;
        private DevExpress.XtraEditors.LabelControl label3;
        private DevExpress.XtraEditors.DateEdit nullableDateTimePickerPIEndDate;
        private DevExpress.XtraEditors.DateEdit nullableDateTimePickerPIStartDate;
        private System.Windows.Forms.GroupBox groupBoxMainSelection;
        private DevExpress.XtraEditors.LabelControl labelBuyoutDate;
        private DevExpress.XtraEditors.DateEdit nullableDateTimePickerBuyoutDate;
        private DevExpress.XtraEditors.CheckEdit checkBoxRepos;
        private DevExpress.XtraEditors.LabelControl label1;
        private DevExpress.XtraEditors.LabelControl labelDealerNum;
        private DevExpress.XtraEditors.DateEdit nullableDateTimePickerEndDate;
        private DevExpress.XtraEditors.DateEdit nullableDateTimePickerStartDate;
        private DevExpress.XtraEditors.LabelControl labelEndDate;
        private DevExpress.XtraEditors.LabelControl labelStartDate;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.RadioButton radioButtonBoth;
        private System.Windows.Forms.RadioButton radioButtonInactive;
        private System.Windows.Forms.RadioButton radioButtonActive;
        private DevExpress.XtraEditors.SimpleButton buttonPost;
        private DevExpress.XtraEditors.SimpleButton buttonCancel;
        private DevExpress.XtraEditors.CheckEdit checkBoxFundingDate;
        private DevExpress.XtraEditors.LabelControl labelControlDateStart;
        private DevExpress.XtraEditors.LabelControl labelControlDateEnd;
        private DevExpress.XtraEditors.TextEdit txtControlDateEnd;
        private DevExpress.XtraEditors.TextEdit txtControlDateStart;
        private DevExpress.XtraEditors.GroupControl groupControl1;
        private DevExpress.XtraTab.XtraTabPage tabFieldList;
        private DevExpress.XtraEditors.GroupControl groupControl3;
        private DevExpress.XtraEditors.SimpleButton buttonMoveAllFieldsLeft;
        private DevExpress.XtraEditors.SimpleButton buttonMoveSelectedFieldsLeft;
        private DevExpress.XtraEditors.SimpleButton buttonMoveAllFieldsRight;
        private DevExpress.XtraEditors.SimpleButton buttonMoveSelectedFieldsRight;
        private DevExpress.XtraEditors.ListBoxControl listBoxFieldList;
        private DevExpress.XtraEditors.ListBoxControl listBoxSelectedFields;
        private DevExpress.XtraEditors.GroupControl groupControl2;
        private DevExpress.XtraEditors.RadioGroup radioGroupMatch;
        private DevExpress.XtraEditors.SimpleButton simpleButtonClearRadioButtons;
        private DevExpress.XtraEditors.LookUpEdit lookUpEditDealer;
        private DevExpress.XtraEditors.LookUpEdit lookUpEditState;
        private System.Windows.Forms.BindingSource bindingSourceDLRLISTBYNUM;
        private System.Windows.Forms.BindingSource bindingSourceState;
        private IACDataSet Bank;
        private IACDataSetTableAdapters.ACCOUNTTableAdapter aCCOUNTTableAdapter;
        private IACDataSetTableAdapters.DLRLISTBYNUMTableAdapter DLRLISTBYNUMTableAdapter;
        private IACDataSetTableAdapters.stateTableAdapter stateTableAdapter;
    }
}
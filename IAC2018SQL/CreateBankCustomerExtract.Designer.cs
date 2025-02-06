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
            this.tabControlCustomerBankExtract = new DevExpress.XtraTab.XtraTabControl();
            this.tabSelections = new DevExpress.XtraTab.XtraTabPage();
            this.layoutControlSelectionCriteria = new DevExpress.XtraLayout.LayoutControl();
            this.simpleButtonClearRadioButtons = new DevExpress.XtraEditors.SimpleButton();
            this.radioGroupMatch = new DevExpress.XtraEditors.RadioGroup();
            this.nullableDateTimePickerPIEndDate = new DevExpress.XtraEditors.DateEdit();
            this.lookUpEditState = new DevExpress.XtraEditors.LookUpEdit();
            this.bindingSourceState = new System.Windows.Forms.BindingSource(this.components);
            this.Bank = new IAC2021SQL.IACDataSet();
            this.nullableDateTimePickerPIStartDate = new DevExpress.XtraEditors.DateEdit();
            this.radioButtonBoth = new DevExpress.XtraEditors.CheckEdit();
            this.checkBoxFundingDate = new DevExpress.XtraEditors.CheckEdit();
            this.checkBoxRepos = new DevExpress.XtraEditors.CheckEdit();
            this.lookUpEditDealer = new DevExpress.XtraEditors.LookUpEdit();
            this.bindingSourceDLRLISTBYNUM = new System.Windows.Forms.BindingSource(this.components);
            this.buttonCancel = new DevExpress.XtraEditors.SimpleButton();
            this.buttonPost = new DevExpress.XtraEditors.SimpleButton();
            this.radioButtonInactive = new DevExpress.XtraEditors.CheckEdit();
            this.txtControlDateEnd = new DevExpress.XtraEditors.TextEdit();
            this.radioButtonActive = new DevExpress.XtraEditors.CheckEdit();
            this.txtControlDateStart = new DevExpress.XtraEditors.TextEdit();
            this.nullableDateTimePickerStartDate = new DevExpress.XtraEditors.DateEdit();
            this.nullableDateTimePickerEndDate = new DevExpress.XtraEditors.DateEdit();
            this.nullableDateTimePickerBuyoutDate = new DevExpress.XtraEditors.DateEdit();
            this.Root = new DevExpress.XtraLayout.LayoutControlGroup();
            this.layoutControlGroupStatus = new DevExpress.XtraLayout.LayoutControlGroup();
            this.layoutControlItemActive = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItemInactive = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItemBoth = new DevExpress.XtraLayout.LayoutControlItem();
            this.emptySpaceItem3 = new DevExpress.XtraLayout.EmptySpaceItem();
            this.layoutControlGroupStandardFilters = new DevExpress.XtraLayout.LayoutControlGroup();
            this.layoutControlItemStartDate = new DevExpress.XtraLayout.LayoutControlItem();
            this.emptySpaceItem4 = new DevExpress.XtraLayout.EmptySpaceItem();
            this.layoutControlItemEndDate = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItemBuyoutDate = new DevExpress.XtraLayout.LayoutControlItem();
            this.emptySpaceItem1 = new DevExpress.XtraLayout.EmptySpaceItem();
            this.layoutControlItemStartControlDate = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItemEndControlDate = new DevExpress.XtraLayout.LayoutControlItem();
            this.emptySpaceItem5 = new DevExpress.XtraLayout.EmptySpaceItem();
            this.layoutControlItemDealer = new DevExpress.XtraLayout.LayoutControlItem();
            this.emptySpaceItem8 = new DevExpress.XtraLayout.EmptySpaceItem();
            this.emptySpaceItem6 = new DevExpress.XtraLayout.EmptySpaceItem();
            this.layoutControlItemDealerState = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem3 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem4 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem5 = new DevExpress.XtraLayout.LayoutControlItem();
            this.emptySpaceItem9 = new DevExpress.XtraLayout.EmptySpaceItem();
            this.emptySpaceItem10 = new DevExpress.XtraLayout.EmptySpaceItem();
            this.emptySpaceItem15 = new DevExpress.XtraLayout.EmptySpaceItem();
            this.emptySpaceItem16 = new DevExpress.XtraLayout.EmptySpaceItem();
            this.emptySpaceItem20 = new DevExpress.XtraLayout.EmptySpaceItem();
            this.emptySpaceItem21 = new DevExpress.XtraLayout.EmptySpaceItem();
            this.emptySpaceItem19 = new DevExpress.XtraLayout.EmptySpaceItem();
            this.layoutControlItem1 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem2 = new DevExpress.XtraLayout.LayoutControlItem();
            this.emptySpaceItem7 = new DevExpress.XtraLayout.EmptySpaceItem();
            this.emptySpaceItem11 = new DevExpress.XtraLayout.EmptySpaceItem();
            this.emptySpaceItem12 = new DevExpress.XtraLayout.EmptySpaceItem();
            this.layoutControlGroupPaidInterest = new DevExpress.XtraLayout.LayoutControlGroup();
            this.layoutControlItemPaidInterestStartDate = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItemPaidInterestEndDate = new DevExpress.XtraLayout.LayoutControlItem();
            this.emptySpaceItem14 = new DevExpress.XtraLayout.EmptySpaceItem();
            this.emptySpaceItem13 = new DevExpress.XtraLayout.EmptySpaceItem();
            this.emptySpaceItem17 = new DevExpress.XtraLayout.EmptySpaceItem();
            this.emptySpaceItem18 = new DevExpress.XtraLayout.EmptySpaceItem();
            this.emptySpaceItem2 = new DevExpress.XtraLayout.EmptySpaceItem();
            this.tabFieldList = new DevExpress.XtraTab.XtraTabPage();
            this.layoutControlFieldSelection = new DevExpress.XtraLayout.LayoutControl();
            this.listBoxSelectedFields = new DevExpress.XtraEditors.ListBoxControl();
            this.buttonMoveAllFieldsLeft = new DevExpress.XtraEditors.SimpleButton();
            this.buttonMoveSelectedFieldsLeft = new DevExpress.XtraEditors.SimpleButton();
            this.buttonMoveAllFieldsRight = new DevExpress.XtraEditors.SimpleButton();
            this.buttonMoveSelectedFieldsRight = new DevExpress.XtraEditors.SimpleButton();
            this.listBoxFieldList = new DevExpress.XtraEditors.ListBoxControl();
            this.layoutControlGroupFieldSelection = new DevExpress.XtraLayout.LayoutControlGroup();
            this.layoutControlItemFieldList = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItemSelectedFields = new DevExpress.XtraLayout.LayoutControlItem();
            this.emptySpaceItem22 = new DevExpress.XtraLayout.EmptySpaceItem();
            this.emptySpaceItem23 = new DevExpress.XtraLayout.EmptySpaceItem();
            this.layoutControlGroupButtons = new DevExpress.XtraLayout.LayoutControlGroup();
            this.layoutControlItem7 = new DevExpress.XtraLayout.LayoutControlItem();
            this.emptySpaceItem24 = new DevExpress.XtraLayout.EmptySpaceItem();
            this.layoutControlItem8 = new DevExpress.XtraLayout.LayoutControlItem();
            this.emptySpaceItem25 = new DevExpress.XtraLayout.EmptySpaceItem();
            this.layoutControlItem9 = new DevExpress.XtraLayout.LayoutControlItem();
            this.emptySpaceItem26 = new DevExpress.XtraLayout.EmptySpaceItem();
            this.layoutControlItem10 = new DevExpress.XtraLayout.LayoutControlItem();
            this.groupControl2 = new DevExpress.XtraEditors.GroupControl();
            this.aCCOUNTTableAdapter = new IAC2021SQL.IACDataSetTableAdapters.ACCOUNTTableAdapter();
            this.DLRLISTBYNUMTableAdapter = new IAC2021SQL.IACDataSetTableAdapters.DLRLISTBYNUMTableAdapter();
            this.stateTableAdapter = new IAC2021SQL.IACDataSetTableAdapters.stateTableAdapter();
            ((System.ComponentModel.ISupportInitialize)(this.tabControlCustomerBankExtract)).BeginInit();
            this.tabControlCustomerBankExtract.SuspendLayout();
            this.tabSelections.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlSelectionCriteria)).BeginInit();
            this.layoutControlSelectionCriteria.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.radioGroupMatch.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nullableDateTimePickerPIEndDate.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nullableDateTimePickerPIEndDate.Properties.CalendarTimeProperties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lookUpEditState.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bindingSourceState)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Bank)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nullableDateTimePickerPIStartDate.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nullableDateTimePickerPIStartDate.Properties.CalendarTimeProperties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.radioButtonBoth.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.checkBoxFundingDate.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.checkBoxRepos.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lookUpEditDealer.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bindingSourceDLRLISTBYNUM)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.radioButtonInactive.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtControlDateEnd.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.radioButtonActive.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtControlDateStart.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nullableDateTimePickerStartDate.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nullableDateTimePickerStartDate.Properties.CalendarTimeProperties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nullableDateTimePickerEndDate.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nullableDateTimePickerEndDate.Properties.CalendarTimeProperties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nullableDateTimePickerBuyoutDate.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nullableDateTimePickerBuyoutDate.Properties.CalendarTimeProperties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Root)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroupStatus)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItemActive)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItemInactive)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItemBoth)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.emptySpaceItem3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroupStandardFilters)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItemStartDate)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.emptySpaceItem4)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItemEndDate)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItemBuyoutDate)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.emptySpaceItem1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItemStartControlDate)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItemEndControlDate)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.emptySpaceItem5)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItemDealer)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.emptySpaceItem8)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.emptySpaceItem6)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItemDealerState)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem4)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem5)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.emptySpaceItem9)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.emptySpaceItem10)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.emptySpaceItem15)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.emptySpaceItem16)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.emptySpaceItem20)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.emptySpaceItem21)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.emptySpaceItem19)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.emptySpaceItem7)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.emptySpaceItem11)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.emptySpaceItem12)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroupPaidInterest)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItemPaidInterestStartDate)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItemPaidInterestEndDate)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.emptySpaceItem14)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.emptySpaceItem13)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.emptySpaceItem17)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.emptySpaceItem18)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.emptySpaceItem2)).BeginInit();
            this.tabFieldList.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlFieldSelection)).BeginInit();
            this.layoutControlFieldSelection.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.listBoxSelectedFields)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.listBoxFieldList)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroupFieldSelection)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItemFieldList)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItemSelectedFields)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.emptySpaceItem22)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.emptySpaceItem23)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroupButtons)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem7)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.emptySpaceItem24)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem8)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.emptySpaceItem25)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem9)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.emptySpaceItem26)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem10)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl2)).BeginInit();
            this.SuspendLayout();
            // 
            // tabControlCustomerBankExtract
            // 
            this.tabControlCustomerBankExtract.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControlCustomerBankExtract.Location = new System.Drawing.Point(0, 0);
            this.tabControlCustomerBankExtract.Name = "tabControlCustomerBankExtract";
            this.tabControlCustomerBankExtract.SelectedTabPage = this.tabSelections;
            this.tabControlCustomerBankExtract.Size = new System.Drawing.Size(1158, 684);
            this.tabControlCustomerBankExtract.TabIndex = 0;
            this.tabControlCustomerBankExtract.TabPages.AddRange(new DevExpress.XtraTab.XtraTabPage[] {
            this.tabSelections,
            this.tabFieldList});
            // 
            // tabSelections
            // 
            this.tabSelections.Appearance.PageClient.BackColor = System.Drawing.Color.LightSteelBlue;
            this.tabSelections.Appearance.PageClient.Options.UseBackColor = true;
            this.tabSelections.Controls.Add(this.layoutControlSelectionCriteria);
            this.tabSelections.Name = "tabSelections";
            this.tabSelections.Padding = new System.Windows.Forms.Padding(3);
            this.tabSelections.Size = new System.Drawing.Size(1150, 647);
            this.tabSelections.Text = "Selection Criteria";
            // 
            // layoutControlSelectionCriteria
            // 
            this.layoutControlSelectionCriteria.Controls.Add(this.simpleButtonClearRadioButtons);
            this.layoutControlSelectionCriteria.Controls.Add(this.radioGroupMatch);
            this.layoutControlSelectionCriteria.Controls.Add(this.nullableDateTimePickerPIEndDate);
            this.layoutControlSelectionCriteria.Controls.Add(this.lookUpEditState);
            this.layoutControlSelectionCriteria.Controls.Add(this.nullableDateTimePickerPIStartDate);
            this.layoutControlSelectionCriteria.Controls.Add(this.radioButtonBoth);
            this.layoutControlSelectionCriteria.Controls.Add(this.checkBoxFundingDate);
            this.layoutControlSelectionCriteria.Controls.Add(this.checkBoxRepos);
            this.layoutControlSelectionCriteria.Controls.Add(this.lookUpEditDealer);
            this.layoutControlSelectionCriteria.Controls.Add(this.buttonCancel);
            this.layoutControlSelectionCriteria.Controls.Add(this.buttonPost);
            this.layoutControlSelectionCriteria.Controls.Add(this.radioButtonInactive);
            this.layoutControlSelectionCriteria.Controls.Add(this.txtControlDateEnd);
            this.layoutControlSelectionCriteria.Controls.Add(this.radioButtonActive);
            this.layoutControlSelectionCriteria.Controls.Add(this.txtControlDateStart);
            this.layoutControlSelectionCriteria.Controls.Add(this.nullableDateTimePickerStartDate);
            this.layoutControlSelectionCriteria.Controls.Add(this.nullableDateTimePickerEndDate);
            this.layoutControlSelectionCriteria.Controls.Add(this.nullableDateTimePickerBuyoutDate);
            this.layoutControlSelectionCriteria.Dock = System.Windows.Forms.DockStyle.Fill;
            this.layoutControlSelectionCriteria.Location = new System.Drawing.Point(3, 3);
            this.layoutControlSelectionCriteria.Name = "layoutControlSelectionCriteria";
            this.layoutControlSelectionCriteria.OptionsCustomizationForm.DesignTimeCustomizationFormPositionAndSize = new System.Drawing.Rectangle(739, 184, 650, 400);
            this.layoutControlSelectionCriteria.Root = this.Root;
            this.layoutControlSelectionCriteria.Size = new System.Drawing.Size(1144, 641);
            this.layoutControlSelectionCriteria.TabIndex = 0;
            this.layoutControlSelectionCriteria.Text = "layoutControl1";
            // 
            // simpleButtonClearRadioButtons
            // 
            this.simpleButtonClearRadioButtons.Location = new System.Drawing.Point(334, 439);
            this.simpleButtonClearRadioButtons.MaximumSize = new System.Drawing.Size(0, 31);
            this.simpleButtonClearRadioButtons.MinimumSize = new System.Drawing.Size(0, 31);
            this.simpleButtonClearRadioButtons.Name = "simpleButtonClearRadioButtons";
            this.simpleButtonClearRadioButtons.Size = new System.Drawing.Size(163, 31);
            this.simpleButtonClearRadioButtons.StyleController = this.layoutControlSelectionCriteria;
            this.simpleButtonClearRadioButtons.TabIndex = 118;
            this.simpleButtonClearRadioButtons.Text = "&Clear Radio Buttons";
            this.simpleButtonClearRadioButtons.Click += new System.EventHandler(this.simpleButtonClearRadioButtons_Click);
            // 
            // radioGroupMatch
            // 
            this.radioGroupMatch.Location = new System.Drawing.Point(469, 305);
            this.radioGroupMatch.MaximumSize = new System.Drawing.Size(0, 88);
            this.radioGroupMatch.MinimumSize = new System.Drawing.Size(0, 88);
            this.radioGroupMatch.Name = "radioGroupMatch";
            this.radioGroupMatch.Properties.Appearance.BackColor = System.Drawing.Color.Transparent;
            this.radioGroupMatch.Properties.Appearance.Options.UseBackColor = true;
            this.radioGroupMatch.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.Simple;
            this.radioGroupMatch.Properties.Items.AddRange(new DevExpress.XtraEditors.Controls.RadioGroupItem[] {
            new DevExpress.XtraEditors.Controls.RadioGroupItem(null, "Match N.B. Fields"),
            new DevExpress.XtraEditors.Controls.RadioGroupItem(null, "Match Trial Balance"),
            new DevExpress.XtraEditors.Controls.RadioGroupItem(null, "ExtensionExtract")});
            this.radioGroupMatch.Size = new System.Drawing.Size(167, 88);
            this.radioGroupMatch.StyleController = this.layoutControlSelectionCriteria;
            this.radioGroupMatch.TabIndex = 24;
            this.radioGroupMatch.SelectedIndexChanged += new System.EventHandler(this.radioGroupMatch_SelectedIndexChanged);
            // 
            // nullableDateTimePickerPIEndDate
            // 
            this.nullableDateTimePickerPIEndDate.EditValue = new System.DateTime(2022, 2, 13, 0, 0, 0, 0);
            this.nullableDateTimePickerPIEndDate.Location = new System.Drawing.Point(866, 223);
            this.nullableDateTimePickerPIEndDate.MaximumSize = new System.Drawing.Size(119, 31);
            this.nullableDateTimePickerPIEndDate.MinimumSize = new System.Drawing.Size(119, 31);
            this.nullableDateTimePickerPIEndDate.Name = "nullableDateTimePickerPIEndDate";
            this.nullableDateTimePickerPIEndDate.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.nullableDateTimePickerPIEndDate.Properties.CalendarTimeProperties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.nullableDateTimePickerPIEndDate.Properties.CalendarView = DevExpress.XtraEditors.Repository.CalendarView.Fluent;
            this.nullableDateTimePickerPIEndDate.Properties.VistaDisplayMode = DevExpress.Utils.DefaultBoolean.False;
            this.nullableDateTimePickerPIEndDate.Size = new System.Drawing.Size(119, 31);
            this.nullableDateTimePickerPIEndDate.StyleController = this.layoutControlSelectionCriteria;
            this.nullableDateTimePickerPIEndDate.TabIndex = 21;
            // 
            // lookUpEditState
            // 
            this.lookUpEditState.Location = new System.Drawing.Point(167, 346);
            this.lookUpEditState.MaximumSize = new System.Drawing.Size(285, 31);
            this.lookUpEditState.MinimumSize = new System.Drawing.Size(285, 31);
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
            this.lookUpEditState.Size = new System.Drawing.Size(285, 31);
            this.lookUpEditState.StyleController = this.layoutControlSelectionCriteria;
            this.lookUpEditState.TabIndex = 119;
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
            // nullableDateTimePickerPIStartDate
            // 
            this.nullableDateTimePickerPIStartDate.EditValue = new System.DateTime(2022, 2, 13, 0, 0, 0, 0);
            this.nullableDateTimePickerPIStartDate.Location = new System.Drawing.Point(866, 182);
            this.nullableDateTimePickerPIStartDate.MaximumSize = new System.Drawing.Size(119, 31);
            this.nullableDateTimePickerPIStartDate.MinimumSize = new System.Drawing.Size(119, 31);
            this.nullableDateTimePickerPIStartDate.Name = "nullableDateTimePickerPIStartDate";
            this.nullableDateTimePickerPIStartDate.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.nullableDateTimePickerPIStartDate.Properties.CalendarTimeProperties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.nullableDateTimePickerPIStartDate.Properties.CalendarView = DevExpress.XtraEditors.Repository.CalendarView.Fluent;
            this.nullableDateTimePickerPIStartDate.Properties.VistaDisplayMode = DevExpress.Utils.DefaultBoolean.False;
            this.nullableDateTimePickerPIStartDate.Size = new System.Drawing.Size(119, 31);
            this.nullableDateTimePickerPIStartDate.StyleController = this.layoutControlSelectionCriteria;
            this.nullableDateTimePickerPIStartDate.TabIndex = 20;
            // 
            // radioButtonBoth
            // 
            this.radioButtonBoth.Location = new System.Drawing.Point(519, 105);
            this.radioButtonBoth.Name = "radioButtonBoth";
            this.radioButtonBoth.Properties.Caption = "&Both";
            this.radioButtonBoth.Properties.CheckBoxOptions.Style = DevExpress.XtraEditors.Controls.CheckBoxStyle.SvgRadio1;
            this.radioButtonBoth.Size = new System.Drawing.Size(242, 24);
            this.radioButtonBoth.StyleController = this.layoutControlSelectionCriteria;
            this.radioButtonBoth.TabIndex = 4;
            // 
            // checkBoxFundingDate
            // 
            this.checkBoxFundingDate.Location = new System.Drawing.Point(97, 398);
            this.checkBoxFundingDate.Name = "checkBoxFundingDate";
            this.checkBoxFundingDate.Properties.Caption = "Funding Date Search";
            this.checkBoxFundingDate.Properties.CheckBoxOptions.Style = DevExpress.XtraEditors.Controls.CheckBoxStyle.SvgCheckBox1;
            this.checkBoxFundingDate.Size = new System.Drawing.Size(233, 24);
            this.checkBoxFundingDate.StyleController = this.layoutControlSelectionCriteria;
            this.checkBoxFundingDate.TabIndex = 14;
            // 
            // checkBoxRepos
            // 
            this.checkBoxRepos.Location = new System.Drawing.Point(334, 398);
            this.checkBoxRepos.Name = "checkBoxRepos";
            this.checkBoxRepos.Properties.Caption = "Repos Only";
            this.checkBoxRepos.Properties.CheckBoxOptions.Style = DevExpress.XtraEditors.Controls.CheckBoxStyle.SvgCheckBox1;
            this.checkBoxRepos.Size = new System.Drawing.Size(121, 24);
            this.checkBoxRepos.StyleController = this.layoutControlSelectionCriteria;
            this.checkBoxRepos.TabIndex = 15;
            // 
            // lookUpEditDealer
            // 
            this.lookUpEditDealer.Location = new System.Drawing.Point(168, 305);
            this.lookUpEditDealer.MaximumSize = new System.Drawing.Size(119, 31);
            this.lookUpEditDealer.MinimumSize = new System.Drawing.Size(119, 31);
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
            this.lookUpEditDealer.Properties.NullText = "";
            this.lookUpEditDealer.Properties.ValueMember = "id";
            this.lookUpEditDealer.Size = new System.Drawing.Size(119, 31);
            this.lookUpEditDealer.StyleController = this.layoutControlSelectionCriteria;
            this.lookUpEditDealer.TabIndex = 12;
            // 
            // bindingSourceDLRLISTBYNUM
            // 
            this.bindingSourceDLRLISTBYNUM.DataMember = "DLRLISTBYNUM";
            this.bindingSourceDLRLISTBYNUM.DataSource = this.Bank;
            // 
            // buttonCancel
            // 
            this.buttonCancel.Appearance.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonCancel.Appearance.Options.UseFont = true;
            this.buttonCancel.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("buttonCancel.ImageOptions.Image")));
            this.buttonCancel.ImageOptions.ImageToTextAlignment = DevExpress.XtraEditors.ImageAlignToText.TopCenter;
            this.buttonCancel.Location = new System.Drawing.Point(596, 525);
            this.buttonCancel.Margin = new System.Windows.Forms.Padding(4);
            this.buttonCancel.MaximumSize = new System.Drawing.Size(110, 103);
            this.buttonCancel.MinimumSize = new System.Drawing.Size(110, 103);
            this.buttonCancel.Name = "buttonCancel";
            this.buttonCancel.Size = new System.Drawing.Size(110, 103);
            this.buttonCancel.StyleController = this.layoutControlSelectionCriteria;
            this.buttonCancel.TabIndex = 23;
            this.buttonCancel.Text = "&Cancel";
            this.buttonCancel.Click += new System.EventHandler(this.buttonCancel_Click);
            // 
            // buttonPost
            // 
            this.buttonPost.Appearance.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonPost.Appearance.Options.UseFont = true;
            this.buttonPost.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("buttonPost.ImageOptions.Image")));
            this.buttonPost.ImageOptions.ImageToTextAlignment = DevExpress.XtraEditors.ImageAlignToText.TopCenter;
            this.buttonPost.Location = new System.Drawing.Point(437, 525);
            this.buttonPost.MaximumSize = new System.Drawing.Size(110, 103);
            this.buttonPost.MinimumSize = new System.Drawing.Size(110, 103);
            this.buttonPost.Name = "buttonPost";
            this.buttonPost.Size = new System.Drawing.Size(110, 103);
            this.buttonPost.StyleController = this.layoutControlSelectionCriteria;
            this.buttonPost.TabIndex = 22;
            this.buttonPost.Text = "Create &Extract";
            this.buttonPost.Click += new System.EventHandler(this.buttonTransfer_Click);
            // 
            // radioButtonInactive
            // 
            this.radioButtonInactive.Location = new System.Drawing.Point(519, 77);
            this.radioButtonInactive.Name = "radioButtonInactive";
            this.radioButtonInactive.Properties.Caption = "&Inactive";
            this.radioButtonInactive.Properties.CheckBoxOptions.Style = DevExpress.XtraEditors.Controls.CheckBoxStyle.SvgRadio1;
            this.radioButtonInactive.Size = new System.Drawing.Size(242, 24);
            this.radioButtonInactive.StyleController = this.layoutControlSelectionCriteria;
            this.radioButtonInactive.TabIndex = 3;
            // 
            // txtControlDateEnd
            // 
            this.txtControlDateEnd.Location = new System.Drawing.Point(508, 264);
            this.txtControlDateEnd.MaximumSize = new System.Drawing.Size(50, 31);
            this.txtControlDateEnd.MinimumSize = new System.Drawing.Size(50, 31);
            this.txtControlDateEnd.Name = "txtControlDateEnd";
            this.txtControlDateEnd.Properties.MaskSettings.Set("MaskManagerType", typeof(DevExpress.Data.Mask.SimpleMaskManager));
            this.txtControlDateEnd.Properties.MaskSettings.Set("MaskManagerSignature", "ignoreMaskBlank=True");
            this.txtControlDateEnd.Properties.MaskSettings.Set("mask", "00/00");
            this.txtControlDateEnd.Properties.MaskSettings.Set("saveLiterals", false);
            this.txtControlDateEnd.Properties.UseMaskAsDisplayFormat = true;
            this.txtControlDateEnd.Size = new System.Drawing.Size(50, 31);
            this.txtControlDateEnd.StyleController = this.layoutControlSelectionCriteria;
            this.txtControlDateEnd.TabIndex = 10;
            // 
            // radioButtonActive
            // 
            this.radioButtonActive.Location = new System.Drawing.Point(519, 49);
            this.radioButtonActive.Name = "radioButtonActive";
            this.radioButtonActive.Properties.Caption = "&Active";
            this.radioButtonActive.Properties.CheckBoxOptions.Style = DevExpress.XtraEditors.Controls.CheckBoxStyle.SvgRadio1;
            this.radioButtonActive.Size = new System.Drawing.Size(242, 24);
            this.radioButtonActive.StyleController = this.layoutControlSelectionCriteria;
            this.radioButtonActive.TabIndex = 2;
            // 
            // txtControlDateStart
            // 
            this.txtControlDateStart.Location = new System.Drawing.Point(508, 223);
            this.txtControlDateStart.MaximumSize = new System.Drawing.Size(50, 31);
            this.txtControlDateStart.MinimumSize = new System.Drawing.Size(50, 31);
            this.txtControlDateStart.Name = "txtControlDateStart";
            this.txtControlDateStart.Properties.MaskSettings.Set("MaskManagerType", typeof(DevExpress.Data.Mask.SimpleMaskManager));
            this.txtControlDateStart.Properties.MaskSettings.Set("MaskManagerSignature", "ignoreMaskBlank=True");
            this.txtControlDateStart.Properties.MaskSettings.Set("mask", "00/00");
            this.txtControlDateStart.Properties.MaskSettings.Set("saveLiterals", false);
            this.txtControlDateStart.Properties.UseMaskAsDisplayFormat = true;
            this.txtControlDateStart.Size = new System.Drawing.Size(50, 31);
            this.txtControlDateStart.StyleController = this.layoutControlSelectionCriteria;
            this.txtControlDateStart.TabIndex = 9;
            // 
            // nullableDateTimePickerStartDate
            // 
            this.nullableDateTimePickerStartDate.EditValue = new System.DateTime(2022, 2, 13, 0, 0, 0, 0);
            this.nullableDateTimePickerStartDate.Location = new System.Drawing.Point(151, 182);
            this.nullableDateTimePickerStartDate.MaximumSize = new System.Drawing.Size(119, 31);
            this.nullableDateTimePickerStartDate.MinimumSize = new System.Drawing.Size(119, 31);
            this.nullableDateTimePickerStartDate.Name = "nullableDateTimePickerStartDate";
            this.nullableDateTimePickerStartDate.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.nullableDateTimePickerStartDate.Properties.CalendarTimeProperties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.nullableDateTimePickerStartDate.Properties.CalendarView = DevExpress.XtraEditors.Repository.CalendarView.Fluent;
            this.nullableDateTimePickerStartDate.Properties.VistaDisplayMode = DevExpress.Utils.DefaultBoolean.False;
            this.nullableDateTimePickerStartDate.Size = new System.Drawing.Size(119, 31);
            this.nullableDateTimePickerStartDate.StyleController = this.layoutControlSelectionCriteria;
            this.nullableDateTimePickerStartDate.TabIndex = 6;
            // 
            // nullableDateTimePickerEndDate
            // 
            this.nullableDateTimePickerEndDate.EditValue = new System.DateTime(2022, 2, 13, 0, 0, 0, 0);
            this.nullableDateTimePickerEndDate.Location = new System.Drawing.Point(151, 223);
            this.nullableDateTimePickerEndDate.MaximumSize = new System.Drawing.Size(119, 31);
            this.nullableDateTimePickerEndDate.MinimumSize = new System.Drawing.Size(119, 31);
            this.nullableDateTimePickerEndDate.Name = "nullableDateTimePickerEndDate";
            this.nullableDateTimePickerEndDate.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.nullableDateTimePickerEndDate.Properties.CalendarTimeProperties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.nullableDateTimePickerEndDate.Properties.CalendarView = DevExpress.XtraEditors.Repository.CalendarView.Fluent;
            this.nullableDateTimePickerEndDate.Properties.VistaDisplayMode = DevExpress.Utils.DefaultBoolean.False;
            this.nullableDateTimePickerEndDate.Size = new System.Drawing.Size(119, 31);
            this.nullableDateTimePickerEndDate.StyleController = this.layoutControlSelectionCriteria;
            this.nullableDateTimePickerEndDate.TabIndex = 8;
            // 
            // nullableDateTimePickerBuyoutDate
            // 
            this.nullableDateTimePickerBuyoutDate.EditValue = new System.DateTime(2022, 2, 13, 0, 0, 0, 0);
            this.nullableDateTimePickerBuyoutDate.Location = new System.Drawing.Point(440, 182);
            this.nullableDateTimePickerBuyoutDate.MaximumSize = new System.Drawing.Size(119, 31);
            this.nullableDateTimePickerBuyoutDate.MinimumSize = new System.Drawing.Size(119, 31);
            this.nullableDateTimePickerBuyoutDate.Name = "nullableDateTimePickerBuyoutDate";
            this.nullableDateTimePickerBuyoutDate.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.nullableDateTimePickerBuyoutDate.Properties.CalendarTimeProperties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.nullableDateTimePickerBuyoutDate.Properties.CalendarView = DevExpress.XtraEditors.Repository.CalendarView.Fluent;
            this.nullableDateTimePickerBuyoutDate.Properties.VistaDisplayMode = DevExpress.Utils.DefaultBoolean.False;
            this.nullableDateTimePickerBuyoutDate.Size = new System.Drawing.Size(119, 31);
            this.nullableDateTimePickerBuyoutDate.StyleController = this.layoutControlSelectionCriteria;
            this.nullableDateTimePickerBuyoutDate.TabIndex = 7;
            // 
            // Root
            // 
            this.Root.AppearanceGroup.BackColor = System.Drawing.Color.LightSteelBlue;
            this.Root.AppearanceGroup.Options.UseBackColor = true;
            this.Root.EnableIndentsWithoutBorders = DevExpress.Utils.DefaultBoolean.True;
            this.Root.GroupBordersVisible = false;
            this.Root.Items.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[] {
            this.layoutControlGroupStatus,
            this.emptySpaceItem3,
            this.layoutControlGroupStandardFilters,
            this.layoutControlItem1,
            this.layoutControlItem2,
            this.emptySpaceItem7,
            this.emptySpaceItem11,
            this.emptySpaceItem12,
            this.layoutControlGroupPaidInterest,
            this.emptySpaceItem13,
            this.emptySpaceItem17,
            this.emptySpaceItem18,
            this.emptySpaceItem2});
            this.Root.Name = "Root";
            this.Root.Size = new System.Drawing.Size(1144, 641);
            this.Root.TextVisible = false;
            // 
            // layoutControlGroupStatus
            // 
            this.layoutControlGroupStatus.GroupStyle = DevExpress.Utils.GroupStyle.Light;
            this.layoutControlGroupStatus.Items.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[] {
            this.layoutControlItemActive,
            this.layoutControlItemInactive,
            this.layoutControlItemBoth});
            this.layoutControlGroupStatus.Location = new System.Drawing.Point(495, 0);
            this.layoutControlGroupStatus.Name = "layoutControlGroupStatus";
            this.layoutControlGroupStatus.Size = new System.Drawing.Size(270, 133);
            this.layoutControlGroupStatus.Text = "Status";
            // 
            // layoutControlItemActive
            // 
            this.layoutControlItemActive.Control = this.radioButtonActive;
            this.layoutControlItemActive.Location = new System.Drawing.Point(0, 0);
            this.layoutControlItemActive.Name = "layoutControlItemActive";
            this.layoutControlItemActive.Size = new System.Drawing.Size(246, 28);
            this.layoutControlItemActive.TextVisible = false;
            // 
            // layoutControlItemInactive
            // 
            this.layoutControlItemInactive.Control = this.radioButtonInactive;
            this.layoutControlItemInactive.Location = new System.Drawing.Point(0, 28);
            this.layoutControlItemInactive.Name = "layoutControlItemInactive";
            this.layoutControlItemInactive.Size = new System.Drawing.Size(246, 28);
            this.layoutControlItemInactive.TextVisible = false;
            // 
            // layoutControlItemBoth
            // 
            this.layoutControlItemBoth.Control = this.radioButtonBoth;
            this.layoutControlItemBoth.Location = new System.Drawing.Point(0, 56);
            this.layoutControlItemBoth.Name = "layoutControlItemBoth";
            this.layoutControlItemBoth.Size = new System.Drawing.Size(246, 28);
            this.layoutControlItemBoth.TextVisible = false;
            // 
            // emptySpaceItem3
            // 
            this.emptySpaceItem3.Location = new System.Drawing.Point(0, 0);
            this.emptySpaceItem3.MaxSize = new System.Drawing.Size(495, 133);
            this.emptySpaceItem3.MinSize = new System.Drawing.Size(495, 133);
            this.emptySpaceItem3.Name = "emptySpaceItem3";
            this.emptySpaceItem3.Size = new System.Drawing.Size(495, 133);
            this.emptySpaceItem3.SizeConstraintsType = DevExpress.XtraLayout.SizeConstraintsType.Custom;
            // 
            // layoutControlGroupStandardFilters
            // 
            this.layoutControlGroupStandardFilters.GroupStyle = DevExpress.Utils.GroupStyle.Light;
            this.layoutControlGroupStandardFilters.Items.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[] {
            this.layoutControlItemStartDate,
            this.emptySpaceItem4,
            this.layoutControlItemEndDate,
            this.layoutControlItemBuyoutDate,
            this.emptySpaceItem1,
            this.layoutControlItemStartControlDate,
            this.layoutControlItemEndControlDate,
            this.emptySpaceItem5,
            this.layoutControlItemDealer,
            this.emptySpaceItem8,
            this.emptySpaceItem6,
            this.layoutControlItemDealerState,
            this.layoutControlItem3,
            this.layoutControlItem4,
            this.layoutControlItem5,
            this.emptySpaceItem9,
            this.emptySpaceItem10,
            this.emptySpaceItem15,
            this.emptySpaceItem16,
            this.emptySpaceItem20,
            this.emptySpaceItem21,
            this.emptySpaceItem19});
            this.layoutControlGroupStandardFilters.Location = new System.Drawing.Point(48, 133);
            this.layoutControlGroupStandardFilters.Name = "layoutControlGroupStandardFilters";
            this.layoutControlGroupStandardFilters.Size = new System.Drawing.Size(715, 380);
            this.layoutControlGroupStandardFilters.Text = "Standard Filters";
            // 
            // layoutControlItemStartDate
            // 
            this.layoutControlItemStartDate.Control = this.nullableDateTimePickerStartDate;
            this.layoutControlItemStartDate.Location = new System.Drawing.Point(0, 0);
            this.layoutControlItemStartDate.MaxSize = new System.Drawing.Size(274, 41);
            this.layoutControlItemStartDate.MinSize = new System.Drawing.Size(274, 41);
            this.layoutControlItemStartDate.Name = "layoutControlItemStartDate";
            this.layoutControlItemStartDate.Padding = new DevExpress.XtraLayout.Utils.Padding(2, 2, 2, 10);
            this.layoutControlItemStartDate.Size = new System.Drawing.Size(274, 41);
            this.layoutControlItemStartDate.SizeConstraintsType = DevExpress.XtraLayout.SizeConstraintsType.Custom;
            this.layoutControlItemStartDate.Text = "Start Date";
            this.layoutControlItemStartDate.TextAlignMode = DevExpress.XtraLayout.TextAlignModeItem.AutoSize;
            this.layoutControlItemStartDate.TextToControlDistance = 5;
            // 
            // emptySpaceItem4
            // 
            this.emptySpaceItem4.Location = new System.Drawing.Point(0, 41);
            this.emptySpaceItem4.MaxSize = new System.Drawing.Size(6, 41);
            this.emptySpaceItem4.MinSize = new System.Drawing.Size(6, 41);
            this.emptySpaceItem4.Name = "emptySpaceItem4";
            this.emptySpaceItem4.Padding = new DevExpress.XtraLayout.Utils.Padding(2, 2, 2, 10);
            this.emptySpaceItem4.Size = new System.Drawing.Size(6, 41);
            this.emptySpaceItem4.SizeConstraintsType = DevExpress.XtraLayout.SizeConstraintsType.Custom;
            // 
            // layoutControlItemEndDate
            // 
            this.layoutControlItemEndDate.Control = this.nullableDateTimePickerEndDate;
            this.layoutControlItemEndDate.Location = new System.Drawing.Point(6, 41);
            this.layoutControlItemEndDate.MaxSize = new System.Drawing.Size(198, 41);
            this.layoutControlItemEndDate.MinSize = new System.Drawing.Size(198, 41);
            this.layoutControlItemEndDate.Name = "layoutControlItemEndDate";
            this.layoutControlItemEndDate.Padding = new DevExpress.XtraLayout.Utils.Padding(2, 2, 2, 10);
            this.layoutControlItemEndDate.Size = new System.Drawing.Size(198, 41);
            this.layoutControlItemEndDate.SizeConstraintsType = DevExpress.XtraLayout.SizeConstraintsType.Custom;
            this.layoutControlItemEndDate.Text = "End Date";
            this.layoutControlItemEndDate.TextAlignMode = DevExpress.XtraLayout.TextAlignModeItem.AutoSize;
            this.layoutControlItemEndDate.TextToControlDistance = 5;
            // 
            // layoutControlItemBuyoutDate
            // 
            this.layoutControlItemBuyoutDate.Control = this.nullableDateTimePickerBuyoutDate;
            this.layoutControlItemBuyoutDate.Location = new System.Drawing.Point(274, 0);
            this.layoutControlItemBuyoutDate.MaxSize = new System.Drawing.Size(417, 41);
            this.layoutControlItemBuyoutDate.MinSize = new System.Drawing.Size(417, 41);
            this.layoutControlItemBuyoutDate.Name = "layoutControlItemBuyoutDate";
            this.layoutControlItemBuyoutDate.Padding = new DevExpress.XtraLayout.Utils.Padding(2, 2, 2, 10);
            this.layoutControlItemBuyoutDate.Size = new System.Drawing.Size(417, 41);
            this.layoutControlItemBuyoutDate.SizeConstraintsType = DevExpress.XtraLayout.SizeConstraintsType.Custom;
            this.layoutControlItemBuyoutDate.Text = "Buyout Date";
            this.layoutControlItemBuyoutDate.TextAlignMode = DevExpress.XtraLayout.TextAlignModeItem.AutoSize;
            this.layoutControlItemBuyoutDate.TextToControlDistance = 5;
            // 
            // emptySpaceItem1
            // 
            this.emptySpaceItem1.Location = new System.Drawing.Point(0, 298);
            this.emptySpaceItem1.MaxSize = new System.Drawing.Size(691, 33);
            this.emptySpaceItem1.MinSize = new System.Drawing.Size(691, 33);
            this.emptySpaceItem1.Name = "emptySpaceItem1";
            this.emptySpaceItem1.Size = new System.Drawing.Size(691, 33);
            this.emptySpaceItem1.SizeConstraintsType = DevExpress.XtraLayout.SizeConstraintsType.Custom;
            // 
            // layoutControlItemStartControlDate
            // 
            this.layoutControlItemStartControlDate.Control = this.txtControlDateStart;
            this.layoutControlItemStartControlDate.Location = new System.Drawing.Point(302, 41);
            this.layoutControlItemStartControlDate.MaxSize = new System.Drawing.Size(389, 41);
            this.layoutControlItemStartControlDate.MinSize = new System.Drawing.Size(389, 41);
            this.layoutControlItemStartControlDate.Name = "layoutControlItemStartControlDate";
            this.layoutControlItemStartControlDate.Padding = new DevExpress.XtraLayout.Utils.Padding(2, 2, 2, 10);
            this.layoutControlItemStartControlDate.Size = new System.Drawing.Size(389, 41);
            this.layoutControlItemStartControlDate.SizeConstraintsType = DevExpress.XtraLayout.SizeConstraintsType.Custom;
            this.layoutControlItemStartControlDate.Text = "Start Control Date";
            this.layoutControlItemStartControlDate.TextAlignMode = DevExpress.XtraLayout.TextAlignModeItem.AutoSize;
            this.layoutControlItemStartControlDate.TextToControlDistance = 5;
            // 
            // layoutControlItemEndControlDate
            // 
            this.layoutControlItemEndControlDate.Control = this.txtControlDateEnd;
            this.layoutControlItemEndControlDate.Location = new System.Drawing.Point(308, 82);
            this.layoutControlItemEndControlDate.MaxSize = new System.Drawing.Size(383, 41);
            this.layoutControlItemEndControlDate.MinSize = new System.Drawing.Size(383, 41);
            this.layoutControlItemEndControlDate.Name = "layoutControlItemEndControlDate";
            this.layoutControlItemEndControlDate.Padding = new DevExpress.XtraLayout.Utils.Padding(2, 2, 2, 10);
            this.layoutControlItemEndControlDate.Size = new System.Drawing.Size(383, 41);
            this.layoutControlItemEndControlDate.SizeConstraintsType = DevExpress.XtraLayout.SizeConstraintsType.Custom;
            this.layoutControlItemEndControlDate.Text = "End Control Date";
            this.layoutControlItemEndControlDate.TextAlignMode = DevExpress.XtraLayout.TextAlignModeItem.AutoSize;
            this.layoutControlItemEndControlDate.TextToControlDistance = 5;
            // 
            // emptySpaceItem5
            // 
            this.emptySpaceItem5.Location = new System.Drawing.Point(0, 82);
            this.emptySpaceItem5.MaxSize = new System.Drawing.Size(308, 41);
            this.emptySpaceItem5.MinSize = new System.Drawing.Size(308, 41);
            this.emptySpaceItem5.Name = "emptySpaceItem5";
            this.emptySpaceItem5.Padding = new DevExpress.XtraLayout.Utils.Padding(2, 2, 2, 10);
            this.emptySpaceItem5.Size = new System.Drawing.Size(308, 41);
            this.emptySpaceItem5.SizeConstraintsType = DevExpress.XtraLayout.SizeConstraintsType.Custom;
            // 
            // layoutControlItemDealer
            // 
            this.layoutControlItemDealer.Control = this.lookUpEditDealer;
            this.layoutControlItemDealer.Location = new System.Drawing.Point(44, 123);
            this.layoutControlItemDealer.MaxSize = new System.Drawing.Size(343, 41);
            this.layoutControlItemDealer.MinSize = new System.Drawing.Size(343, 41);
            this.layoutControlItemDealer.Name = "layoutControlItemDealer";
            this.layoutControlItemDealer.Padding = new DevExpress.XtraLayout.Utils.Padding(2, 2, 2, 10);
            this.layoutControlItemDealer.Size = new System.Drawing.Size(343, 41);
            this.layoutControlItemDealer.SizeConstraintsType = DevExpress.XtraLayout.SizeConstraintsType.Custom;
            this.layoutControlItemDealer.Text = "Dealer";
            this.layoutControlItemDealer.TextAlignMode = DevExpress.XtraLayout.TextAlignModeItem.AutoSize;
            this.layoutControlItemDealer.TextToControlDistance = 5;
            // 
            // emptySpaceItem8
            // 
            this.emptySpaceItem8.Location = new System.Drawing.Point(0, 123);
            this.emptySpaceItem8.MaxSize = new System.Drawing.Size(44, 41);
            this.emptySpaceItem8.MinSize = new System.Drawing.Size(44, 41);
            this.emptySpaceItem8.Name = "emptySpaceItem8";
            this.emptySpaceItem8.Padding = new DevExpress.XtraLayout.Utils.Padding(2, 2, 2, 10);
            this.emptySpaceItem8.Size = new System.Drawing.Size(44, 41);
            this.emptySpaceItem8.SizeConstraintsType = DevExpress.XtraLayout.SizeConstraintsType.Custom;
            // 
            // emptySpaceItem6
            // 
            this.emptySpaceItem6.Location = new System.Drawing.Point(387, 123);
            this.emptySpaceItem6.MaxSize = new System.Drawing.Size(10, 93);
            this.emptySpaceItem6.MinSize = new System.Drawing.Size(10, 93);
            this.emptySpaceItem6.Name = "emptySpaceItem6";
            this.emptySpaceItem6.Size = new System.Drawing.Size(181, 93);
            this.emptySpaceItem6.SizeConstraintsType = DevExpress.XtraLayout.SizeConstraintsType.Custom;
            // 
            // layoutControlItemDealerState
            // 
            this.layoutControlItemDealerState.Control = this.lookUpEditState;
            this.layoutControlItemDealerState.Location = new System.Drawing.Point(0, 164);
            this.layoutControlItemDealerState.MaxSize = new System.Drawing.Size(387, 41);
            this.layoutControlItemDealerState.MinSize = new System.Drawing.Size(387, 41);
            this.layoutControlItemDealerState.Name = "layoutControlItemDealerState";
            this.layoutControlItemDealerState.Padding = new DevExpress.XtraLayout.Utils.Padding(2, 2, 2, 10);
            this.layoutControlItemDealerState.Size = new System.Drawing.Size(387, 41);
            this.layoutControlItemDealerState.SizeConstraintsType = DevExpress.XtraLayout.SizeConstraintsType.Custom;
            this.layoutControlItemDealerState.Text = "Dealer State";
            this.layoutControlItemDealerState.TextAlignMode = DevExpress.XtraLayout.TextAlignModeItem.AutoSize;
            this.layoutControlItemDealerState.TextToControlDistance = 5;
            // 
            // layoutControlItem3
            // 
            this.layoutControlItem3.Control = this.checkBoxFundingDate;
            this.layoutControlItem3.Location = new System.Drawing.Point(25, 216);
            this.layoutControlItem3.MaxSize = new System.Drawing.Size(237, 41);
            this.layoutControlItem3.MinSize = new System.Drawing.Size(237, 41);
            this.layoutControlItem3.Name = "layoutControlItem3";
            this.layoutControlItem3.Padding = new DevExpress.XtraLayout.Utils.Padding(2, 2, 2, 10);
            this.layoutControlItem3.Size = new System.Drawing.Size(237, 41);
            this.layoutControlItem3.SizeConstraintsType = DevExpress.XtraLayout.SizeConstraintsType.Custom;
            this.layoutControlItem3.TextVisible = false;
            // 
            // layoutControlItem4
            // 
            this.layoutControlItem4.Control = this.checkBoxRepos;
            this.layoutControlItem4.Location = new System.Drawing.Point(262, 216);
            this.layoutControlItem4.MaxSize = new System.Drawing.Size(125, 41);
            this.layoutControlItem4.MinSize = new System.Drawing.Size(125, 41);
            this.layoutControlItem4.Name = "layoutControlItem4";
            this.layoutControlItem4.Padding = new DevExpress.XtraLayout.Utils.Padding(2, 2, 2, 10);
            this.layoutControlItem4.Size = new System.Drawing.Size(125, 41);
            this.layoutControlItem4.SizeConstraintsType = DevExpress.XtraLayout.SizeConstraintsType.Custom;
            this.layoutControlItem4.TextVisible = false;
            // 
            // layoutControlItem5
            // 
            this.layoutControlItem5.Control = this.simpleButtonClearRadioButtons;
            this.layoutControlItem5.Location = new System.Drawing.Point(262, 257);
            this.layoutControlItem5.MaxSize = new System.Drawing.Size(167, 41);
            this.layoutControlItem5.MinSize = new System.Drawing.Size(167, 41);
            this.layoutControlItem5.Name = "layoutControlItem5";
            this.layoutControlItem5.Padding = new DevExpress.XtraLayout.Utils.Padding(2, 2, 2, 10);
            this.layoutControlItem5.Size = new System.Drawing.Size(167, 41);
            this.layoutControlItem5.SizeConstraintsType = DevExpress.XtraLayout.SizeConstraintsType.Custom;
            this.layoutControlItem5.TextVisible = false;
            // 
            // emptySpaceItem9
            // 
            this.emptySpaceItem9.Location = new System.Drawing.Point(0, 257);
            this.emptySpaceItem9.MaxSize = new System.Drawing.Size(262, 41);
            this.emptySpaceItem9.MinSize = new System.Drawing.Size(262, 41);
            this.emptySpaceItem9.Name = "emptySpaceItem9";
            this.emptySpaceItem9.Padding = new DevExpress.XtraLayout.Utils.Padding(2, 2, 2, 10);
            this.emptySpaceItem9.Size = new System.Drawing.Size(262, 41);
            this.emptySpaceItem9.SizeConstraintsType = DevExpress.XtraLayout.SizeConstraintsType.Custom;
            // 
            // emptySpaceItem10
            // 
            this.emptySpaceItem10.Location = new System.Drawing.Point(429, 257);
            this.emptySpaceItem10.MaxSize = new System.Drawing.Size(262, 41);
            this.emptySpaceItem10.MinSize = new System.Drawing.Size(262, 41);
            this.emptySpaceItem10.Name = "emptySpaceItem10";
            this.emptySpaceItem10.Padding = new DevExpress.XtraLayout.Utils.Padding(2, 2, 2, 10);
            this.emptySpaceItem10.Size = new System.Drawing.Size(262, 41);
            this.emptySpaceItem10.SizeConstraintsType = DevExpress.XtraLayout.SizeConstraintsType.Custom;
            // 
            // emptySpaceItem15
            // 
            this.emptySpaceItem15.Location = new System.Drawing.Point(0, 205);
            this.emptySpaceItem15.MaxSize = new System.Drawing.Size(387, 11);
            this.emptySpaceItem15.MinSize = new System.Drawing.Size(387, 11);
            this.emptySpaceItem15.Name = "emptySpaceItem15";
            this.emptySpaceItem15.Size = new System.Drawing.Size(387, 11);
            this.emptySpaceItem15.SizeConstraintsType = DevExpress.XtraLayout.SizeConstraintsType.Custom;
            // 
            // emptySpaceItem16
            // 
            this.emptySpaceItem16.Location = new System.Drawing.Point(204, 41);
            this.emptySpaceItem16.MaxSize = new System.Drawing.Size(98, 41);
            this.emptySpaceItem16.MinSize = new System.Drawing.Size(98, 41);
            this.emptySpaceItem16.Name = "emptySpaceItem16";
            this.emptySpaceItem16.Padding = new DevExpress.XtraLayout.Utils.Padding(2, 2, 2, 10);
            this.emptySpaceItem16.Size = new System.Drawing.Size(98, 41);
            this.emptySpaceItem16.SizeConstraintsType = DevExpress.XtraLayout.SizeConstraintsType.Custom;
            // 
            // emptySpaceItem20
            // 
            this.emptySpaceItem20.Location = new System.Drawing.Point(0, 216);
            this.emptySpaceItem20.MaxSize = new System.Drawing.Size(25, 41);
            this.emptySpaceItem20.MinSize = new System.Drawing.Size(25, 41);
            this.emptySpaceItem20.Name = "emptySpaceItem20";
            this.emptySpaceItem20.Padding = new DevExpress.XtraLayout.Utils.Padding(2, 2, 2, 10);
            this.emptySpaceItem20.Size = new System.Drawing.Size(25, 41);
            this.emptySpaceItem20.SizeConstraintsType = DevExpress.XtraLayout.SizeConstraintsType.Custom;
            // 
            // emptySpaceItem21
            // 
            this.emptySpaceItem21.Location = new System.Drawing.Point(568, 123);
            this.emptySpaceItem21.MaxSize = new System.Drawing.Size(123, 134);
            this.emptySpaceItem21.MinSize = new System.Drawing.Size(123, 134);
            this.emptySpaceItem21.Name = "emptySpaceItem21";
            this.emptySpaceItem21.Size = new System.Drawing.Size(123, 134);
            this.emptySpaceItem21.SizeConstraintsType = DevExpress.XtraLayout.SizeConstraintsType.Custom;
            // 
            // emptySpaceItem19
            // 
            this.emptySpaceItem19.Location = new System.Drawing.Point(387, 216);
            this.emptySpaceItem19.MaxSize = new System.Drawing.Size(181, 41);
            this.emptySpaceItem19.MinSize = new System.Drawing.Size(181, 41);
            this.emptySpaceItem19.Name = "emptySpaceItem19";
            this.emptySpaceItem19.Padding = new DevExpress.XtraLayout.Utils.Padding(2, 2, 2, 10);
            this.emptySpaceItem19.Size = new System.Drawing.Size(181, 41);
            this.emptySpaceItem19.SizeConstraintsType = DevExpress.XtraLayout.SizeConstraintsType.Custom;
            // 
            // layoutControlItem1
            // 
            this.layoutControlItem1.Control = this.buttonPost;
            this.layoutControlItem1.Location = new System.Drawing.Point(425, 513);
            this.layoutControlItem1.MaxSize = new System.Drawing.Size(115, 108);
            this.layoutControlItem1.MinSize = new System.Drawing.Size(115, 108);
            this.layoutControlItem1.Name = "layoutControlItem1";
            this.layoutControlItem1.Size = new System.Drawing.Size(115, 108);
            this.layoutControlItem1.SizeConstraintsType = DevExpress.XtraLayout.SizeConstraintsType.Custom;
            this.layoutControlItem1.TextVisible = false;
            // 
            // layoutControlItem2
            // 
            this.layoutControlItem2.Control = this.buttonCancel;
            this.layoutControlItem2.Location = new System.Drawing.Point(584, 513);
            this.layoutControlItem2.MaxSize = new System.Drawing.Size(115, 108);
            this.layoutControlItem2.MinSize = new System.Drawing.Size(115, 108);
            this.layoutControlItem2.Name = "layoutControlItem2";
            this.layoutControlItem2.Size = new System.Drawing.Size(115, 108);
            this.layoutControlItem2.SizeConstraintsType = DevExpress.XtraLayout.SizeConstraintsType.Custom;
            this.layoutControlItem2.TextVisible = false;
            // 
            // emptySpaceItem7
            // 
            this.emptySpaceItem7.Location = new System.Drawing.Point(540, 513);
            this.emptySpaceItem7.MaxSize = new System.Drawing.Size(44, 108);
            this.emptySpaceItem7.MinSize = new System.Drawing.Size(44, 108);
            this.emptySpaceItem7.Name = "emptySpaceItem7";
            this.emptySpaceItem7.Size = new System.Drawing.Size(44, 108);
            this.emptySpaceItem7.SizeConstraintsType = DevExpress.XtraLayout.SizeConstraintsType.Custom;
            // 
            // emptySpaceItem11
            // 
            this.emptySpaceItem11.Location = new System.Drawing.Point(0, 513);
            this.emptySpaceItem11.MaxSize = new System.Drawing.Size(425, 108);
            this.emptySpaceItem11.MinSize = new System.Drawing.Size(425, 108);
            this.emptySpaceItem11.Name = "emptySpaceItem11";
            this.emptySpaceItem11.Size = new System.Drawing.Size(425, 108);
            this.emptySpaceItem11.SizeConstraintsType = DevExpress.XtraLayout.SizeConstraintsType.Custom;
            // 
            // emptySpaceItem12
            // 
            this.emptySpaceItem12.Location = new System.Drawing.Point(699, 513);
            this.emptySpaceItem12.MaxSize = new System.Drawing.Size(425, 108);
            this.emptySpaceItem12.MinSize = new System.Drawing.Size(425, 108);
            this.emptySpaceItem12.Name = "emptySpaceItem12";
            this.emptySpaceItem12.Size = new System.Drawing.Size(425, 108);
            this.emptySpaceItem12.SizeConstraintsType = DevExpress.XtraLayout.SizeConstraintsType.Custom;
            // 
            // layoutControlGroupPaidInterest
            // 
            this.layoutControlGroupPaidInterest.GroupStyle = DevExpress.Utils.GroupStyle.Light;
            this.layoutControlGroupPaidInterest.Items.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[] {
            this.layoutControlItemPaidInterestStartDate,
            this.layoutControlItemPaidInterestEndDate,
            this.emptySpaceItem14});
            this.layoutControlGroupPaidInterest.Location = new System.Drawing.Point(763, 133);
            this.layoutControlGroupPaidInterest.Name = "layoutControlGroupPaidInterest";
            this.layoutControlGroupPaidInterest.Size = new System.Drawing.Size(226, 131);
            this.layoutControlGroupPaidInterest.Text = "Paid Interest";
            // 
            // layoutControlItemPaidInterestStartDate
            // 
            this.layoutControlItemPaidInterestStartDate.Control = this.nullableDateTimePickerPIStartDate;
            this.layoutControlItemPaidInterestStartDate.Location = new System.Drawing.Point(0, 0);
            this.layoutControlItemPaidInterestStartDate.MaxSize = new System.Drawing.Size(202, 41);
            this.layoutControlItemPaidInterestStartDate.MinSize = new System.Drawing.Size(202, 41);
            this.layoutControlItemPaidInterestStartDate.Name = "layoutControlItemPaidInterestStartDate";
            this.layoutControlItemPaidInterestStartDate.Padding = new DevExpress.XtraLayout.Utils.Padding(2, 2, 2, 10);
            this.layoutControlItemPaidInterestStartDate.Size = new System.Drawing.Size(202, 41);
            this.layoutControlItemPaidInterestStartDate.SizeConstraintsType = DevExpress.XtraLayout.SizeConstraintsType.Custom;
            this.layoutControlItemPaidInterestStartDate.Text = "Start Date";
            this.layoutControlItemPaidInterestStartDate.TextAlignMode = DevExpress.XtraLayout.TextAlignModeItem.AutoSize;
            this.layoutControlItemPaidInterestStartDate.TextToControlDistance = 5;
            // 
            // layoutControlItemPaidInterestEndDate
            // 
            this.layoutControlItemPaidInterestEndDate.Control = this.nullableDateTimePickerPIEndDate;
            this.layoutControlItemPaidInterestEndDate.Location = new System.Drawing.Point(6, 41);
            this.layoutControlItemPaidInterestEndDate.MaxSize = new System.Drawing.Size(196, 41);
            this.layoutControlItemPaidInterestEndDate.MinSize = new System.Drawing.Size(196, 41);
            this.layoutControlItemPaidInterestEndDate.Name = "layoutControlItemPaidInterestEndDate";
            this.layoutControlItemPaidInterestEndDate.Padding = new DevExpress.XtraLayout.Utils.Padding(2, 2, 2, 10);
            this.layoutControlItemPaidInterestEndDate.Size = new System.Drawing.Size(196, 41);
            this.layoutControlItemPaidInterestEndDate.SizeConstraintsType = DevExpress.XtraLayout.SizeConstraintsType.Custom;
            this.layoutControlItemPaidInterestEndDate.Text = "End Date";
            this.layoutControlItemPaidInterestEndDate.TextAlignMode = DevExpress.XtraLayout.TextAlignModeItem.AutoSize;
            this.layoutControlItemPaidInterestEndDate.TextToControlDistance = 5;
            // 
            // emptySpaceItem14
            // 
            this.emptySpaceItem14.Location = new System.Drawing.Point(0, 41);
            this.emptySpaceItem14.MaxSize = new System.Drawing.Size(6, 41);
            this.emptySpaceItem14.MinSize = new System.Drawing.Size(6, 41);
            this.emptySpaceItem14.Name = "emptySpaceItem14";
            this.emptySpaceItem14.Padding = new DevExpress.XtraLayout.Utils.Padding(2, 2, 2, 10);
            this.emptySpaceItem14.Size = new System.Drawing.Size(6, 41);
            this.emptySpaceItem14.SizeConstraintsType = DevExpress.XtraLayout.SizeConstraintsType.Custom;
            // 
            // emptySpaceItem13
            // 
            this.emptySpaceItem13.Location = new System.Drawing.Point(763, 264);
            this.emptySpaceItem13.MaxSize = new System.Drawing.Size(361, 249);
            this.emptySpaceItem13.MinSize = new System.Drawing.Size(361, 249);
            this.emptySpaceItem13.Name = "emptySpaceItem13";
            this.emptySpaceItem13.Size = new System.Drawing.Size(361, 249);
            this.emptySpaceItem13.SizeConstraintsType = DevExpress.XtraLayout.SizeConstraintsType.Custom;
            // 
            // emptySpaceItem17
            // 
            this.emptySpaceItem17.Location = new System.Drawing.Point(765, 0);
            this.emptySpaceItem17.MaxSize = new System.Drawing.Size(359, 133);
            this.emptySpaceItem17.MinSize = new System.Drawing.Size(359, 133);
            this.emptySpaceItem17.Name = "emptySpaceItem17";
            this.emptySpaceItem17.Size = new System.Drawing.Size(359, 133);
            this.emptySpaceItem17.SizeConstraintsType = DevExpress.XtraLayout.SizeConstraintsType.Custom;
            // 
            // emptySpaceItem18
            // 
            this.emptySpaceItem18.Location = new System.Drawing.Point(989, 133);
            this.emptySpaceItem18.MaxSize = new System.Drawing.Size(135, 131);
            this.emptySpaceItem18.MinSize = new System.Drawing.Size(135, 131);
            this.emptySpaceItem18.Name = "emptySpaceItem18";
            this.emptySpaceItem18.Size = new System.Drawing.Size(135, 131);
            this.emptySpaceItem18.SizeConstraintsType = DevExpress.XtraLayout.SizeConstraintsType.Custom;
            // 
            // emptySpaceItem2
            // 
            this.emptySpaceItem2.Location = new System.Drawing.Point(0, 133);
            this.emptySpaceItem2.MaxSize = new System.Drawing.Size(48, 380);
            this.emptySpaceItem2.MinSize = new System.Drawing.Size(48, 380);
            this.emptySpaceItem2.Name = "emptySpaceItem2";
            this.emptySpaceItem2.Size = new System.Drawing.Size(48, 380);
            this.emptySpaceItem2.SizeConstraintsType = DevExpress.XtraLayout.SizeConstraintsType.Custom;
            // 
            // tabFieldList
            // 
            this.tabFieldList.Appearance.PageClient.BackColor = System.Drawing.Color.LightSteelBlue;
            this.tabFieldList.Appearance.PageClient.Options.UseBackColor = true;
            this.tabFieldList.Controls.Add(this.layoutControlFieldSelection);
            this.tabFieldList.Name = "tabFieldList";
            this.tabFieldList.Padding = new System.Windows.Forms.Padding(3);
            this.tabFieldList.Size = new System.Drawing.Size(1150, 647);
            this.tabFieldList.Text = "Field Selection";
            // 
            // layoutControlFieldSelection
            // 
            this.layoutControlFieldSelection.BackColor = System.Drawing.Color.LightSteelBlue;
            this.layoutControlFieldSelection.Controls.Add(this.listBoxSelectedFields);
            this.layoutControlFieldSelection.Controls.Add(this.buttonMoveAllFieldsLeft);
            this.layoutControlFieldSelection.Controls.Add(this.buttonMoveSelectedFieldsLeft);
            this.layoutControlFieldSelection.Controls.Add(this.buttonMoveAllFieldsRight);
            this.layoutControlFieldSelection.Controls.Add(this.buttonMoveSelectedFieldsRight);
            this.layoutControlFieldSelection.Controls.Add(this.listBoxFieldList);
            this.layoutControlFieldSelection.Dock = System.Windows.Forms.DockStyle.Fill;
            this.layoutControlFieldSelection.Location = new System.Drawing.Point(3, 3);
            this.layoutControlFieldSelection.Name = "layoutControlFieldSelection";
            this.layoutControlFieldSelection.OptionsCustomizationForm.DesignTimeCustomizationFormPositionAndSize = new System.Drawing.Rectangle(452, 0, 650, 400);
            this.layoutControlFieldSelection.Root = this.layoutControlGroupFieldSelection;
            this.layoutControlFieldSelection.Size = new System.Drawing.Size(1144, 641);
            this.layoutControlFieldSelection.TabIndex = 7;
            this.layoutControlFieldSelection.Text = "layoutControl2";
            // 
            // listBoxSelectedFields
            // 
            this.listBoxSelectedFields.Location = new System.Drawing.Point(672, 12);
            this.listBoxSelectedFields.MaximumSize = new System.Drawing.Size(459, 617);
            this.listBoxSelectedFields.MinimumSize = new System.Drawing.Size(459, 617);
            this.listBoxSelectedFields.Name = "listBoxSelectedFields";
            this.listBoxSelectedFields.SelectionMode = System.Windows.Forms.SelectionMode.MultiExtended;
            this.listBoxSelectedFields.Size = new System.Drawing.Size(459, 617);
            this.listBoxSelectedFields.StyleController = this.layoutControlFieldSelection;
            this.listBoxSelectedFields.TabIndex = 1;
            // 
            // buttonMoveAllFieldsLeft
            // 
            this.buttonMoveAllFieldsLeft.ImageOptions.Image = global::IAC2021SQL.Properties.Resources.CollapseChevronLeftGroup_16x1;
            this.buttonMoveAllFieldsLeft.ImageOptions.Location = DevExpress.XtraEditors.ImageLocation.MiddleCenter;
            this.buttonMoveAllFieldsLeft.Location = new System.Drawing.Point(488, 459);
            this.buttonMoveAllFieldsLeft.Name = "buttonMoveAllFieldsLeft";
            this.buttonMoveAllFieldsLeft.Size = new System.Drawing.Size(167, 71);
            this.buttonMoveAllFieldsLeft.StyleController = this.layoutControlFieldSelection;
            this.buttonMoveAllFieldsLeft.TabIndex = 5;
            this.buttonMoveAllFieldsLeft.Click += new System.EventHandler(this.buttonMoveAllFieldsLeft_Click);
            // 
            // buttonMoveSelectedFieldsLeft
            // 
            this.buttonMoveSelectedFieldsLeft.ImageOptions.Image = global::IAC2021SQL.Properties.Resources.CollapseChevronLeft_16x;
            this.buttonMoveSelectedFieldsLeft.ImageOptions.Location = DevExpress.XtraEditors.ImageLocation.MiddleCenter;
            this.buttonMoveSelectedFieldsLeft.Location = new System.Drawing.Point(488, 343);
            this.buttonMoveSelectedFieldsLeft.Name = "buttonMoveSelectedFieldsLeft";
            this.buttonMoveSelectedFieldsLeft.Size = new System.Drawing.Size(167, 71);
            this.buttonMoveSelectedFieldsLeft.StyleController = this.layoutControlFieldSelection;
            this.buttonMoveSelectedFieldsLeft.TabIndex = 4;
            this.buttonMoveSelectedFieldsLeft.Click += new System.EventHandler(this.buttonMoveSelectedFieldsLeft_Click);
            // 
            // buttonMoveAllFieldsRight
            // 
            this.buttonMoveAllFieldsRight.ImageOptions.Image = global::IAC2021SQL.Properties.Resources.ExpandChevronRightGroup_16x;
            this.buttonMoveAllFieldsRight.ImageOptions.Location = DevExpress.XtraEditors.ImageLocation.MiddleCenter;
            this.buttonMoveAllFieldsRight.Location = new System.Drawing.Point(488, 227);
            this.buttonMoveAllFieldsRight.Name = "buttonMoveAllFieldsRight";
            this.buttonMoveAllFieldsRight.Size = new System.Drawing.Size(167, 71);
            this.buttonMoveAllFieldsRight.StyleController = this.layoutControlFieldSelection;
            this.buttonMoveAllFieldsRight.TabIndex = 3;
            this.buttonMoveAllFieldsRight.Click += new System.EventHandler(this.buttonMoveAllFieldsRight_Click);
            // 
            // buttonMoveSelectedFieldsRight
            // 
            this.buttonMoveSelectedFieldsRight.ImageOptions.Image = global::IAC2021SQL.Properties.Resources.ExpandChevronRight_16x;
            this.buttonMoveSelectedFieldsRight.ImageOptions.Location = DevExpress.XtraEditors.ImageLocation.MiddleCenter;
            this.buttonMoveSelectedFieldsRight.Location = new System.Drawing.Point(488, 111);
            this.buttonMoveSelectedFieldsRight.MaximumSize = new System.Drawing.Size(169, 71);
            this.buttonMoveSelectedFieldsRight.MinimumSize = new System.Drawing.Size(169, 71);
            this.buttonMoveSelectedFieldsRight.Name = "buttonMoveSelectedFieldsRight";
            this.buttonMoveSelectedFieldsRight.Size = new System.Drawing.Size(169, 71);
            this.buttonMoveSelectedFieldsRight.StyleController = this.layoutControlFieldSelection;
            this.buttonMoveSelectedFieldsRight.TabIndex = 2;
            this.buttonMoveSelectedFieldsRight.Click += new System.EventHandler(this.buttonMoveSelectedFieldsRight_Click);
            // 
            // listBoxFieldList
            // 
            this.listBoxFieldList.Location = new System.Drawing.Point(12, 12);
            this.listBoxFieldList.MaximumSize = new System.Drawing.Size(459, 617);
            this.listBoxFieldList.MinimumSize = new System.Drawing.Size(459, 617);
            this.listBoxFieldList.Name = "listBoxFieldList";
            this.listBoxFieldList.SelectionMode = System.Windows.Forms.SelectionMode.MultiExtended;
            this.listBoxFieldList.Size = new System.Drawing.Size(459, 617);
            this.listBoxFieldList.StyleController = this.layoutControlFieldSelection;
            this.listBoxFieldList.TabIndex = 0;
            // 
            // layoutControlGroupFieldSelection
            // 
            this.layoutControlGroupFieldSelection.AppearanceGroup.BackColor = System.Drawing.Color.LightSteelBlue;
            this.layoutControlGroupFieldSelection.AppearanceGroup.Options.UseBackColor = true;
            this.layoutControlGroupFieldSelection.EnableIndentsWithoutBorders = DevExpress.Utils.DefaultBoolean.True;
            this.layoutControlGroupFieldSelection.GroupStyle = DevExpress.Utils.GroupStyle.Light;
            this.layoutControlGroupFieldSelection.Items.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[] {
            this.layoutControlItemFieldList,
            this.layoutControlItemSelectedFields,
            this.emptySpaceItem22,
            this.emptySpaceItem23,
            this.layoutControlGroupButtons});
            this.layoutControlGroupFieldSelection.Name = "Root";
            this.layoutControlGroupFieldSelection.Size = new System.Drawing.Size(1144, 641);
            this.layoutControlGroupFieldSelection.TextVisible = false;
            // 
            // layoutControlItemFieldList
            // 
            this.layoutControlItemFieldList.Control = this.listBoxFieldList;
            this.layoutControlItemFieldList.Location = new System.Drawing.Point(0, 0);
            this.layoutControlItemFieldList.MaxSize = new System.Drawing.Size(463, 621);
            this.layoutControlItemFieldList.MinSize = new System.Drawing.Size(463, 621);
            this.layoutControlItemFieldList.Name = "layoutControlItemFieldList";
            this.layoutControlItemFieldList.Size = new System.Drawing.Size(463, 621);
            this.layoutControlItemFieldList.SizeConstraintsType = DevExpress.XtraLayout.SizeConstraintsType.Custom;
            this.layoutControlItemFieldList.TextVisible = false;
            // 
            // layoutControlItemSelectedFields
            // 
            this.layoutControlItemSelectedFields.Control = this.listBoxSelectedFields;
            this.layoutControlItemSelectedFields.Location = new System.Drawing.Point(660, 0);
            this.layoutControlItemSelectedFields.MaxSize = new System.Drawing.Size(464, 621);
            this.layoutControlItemSelectedFields.MinSize = new System.Drawing.Size(464, 621);
            this.layoutControlItemSelectedFields.Name = "layoutControlItemSelectedFields";
            this.layoutControlItemSelectedFields.Size = new System.Drawing.Size(464, 621);
            this.layoutControlItemSelectedFields.SizeConstraintsType = DevExpress.XtraLayout.SizeConstraintsType.Custom;
            this.layoutControlItemSelectedFields.TextVisible = false;
            // 
            // emptySpaceItem22
            // 
            this.emptySpaceItem22.Location = new System.Drawing.Point(463, 535);
            this.emptySpaceItem22.MaxSize = new System.Drawing.Size(197, 86);
            this.emptySpaceItem22.MinSize = new System.Drawing.Size(197, 86);
            this.emptySpaceItem22.Name = "emptySpaceItem22";
            this.emptySpaceItem22.Size = new System.Drawing.Size(197, 86);
            this.emptySpaceItem22.SizeConstraintsType = DevExpress.XtraLayout.SizeConstraintsType.Custom;
            // 
            // emptySpaceItem23
            // 
            this.emptySpaceItem23.Location = new System.Drawing.Point(463, 0);
            this.emptySpaceItem23.MaxSize = new System.Drawing.Size(197, 86);
            this.emptySpaceItem23.MinSize = new System.Drawing.Size(197, 86);
            this.emptySpaceItem23.Name = "emptySpaceItem23";
            this.emptySpaceItem23.Size = new System.Drawing.Size(197, 86);
            this.emptySpaceItem23.SizeConstraintsType = DevExpress.XtraLayout.SizeConstraintsType.Custom;
            // 
            // layoutControlGroupButtons
            // 
            this.layoutControlGroupButtons.GroupStyle = DevExpress.Utils.GroupStyle.Title;
            this.layoutControlGroupButtons.Items.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[] {
            this.layoutControlItem7,
            this.emptySpaceItem24,
            this.layoutControlItem8,
            this.emptySpaceItem25,
            this.layoutControlItem9,
            this.emptySpaceItem26,
            this.layoutControlItem10});
            this.layoutControlGroupButtons.Location = new System.Drawing.Point(463, 86);
            this.layoutControlGroupButtons.Name = "layoutControlGroupButtons";
            this.layoutControlGroupButtons.Size = new System.Drawing.Size(197, 449);
            this.layoutControlGroupButtons.Text = "Buttons";
            this.layoutControlGroupButtons.TextVisible = false;
            // 
            // layoutControlItem7
            // 
            this.layoutControlItem7.Control = this.buttonMoveSelectedFieldsRight;
            this.layoutControlItem7.Location = new System.Drawing.Point(0, 0);
            this.layoutControlItem7.MaxSize = new System.Drawing.Size(171, 75);
            this.layoutControlItem7.MinSize = new System.Drawing.Size(171, 75);
            this.layoutControlItem7.Name = "layoutControlItem7";
            this.layoutControlItem7.Size = new System.Drawing.Size(171, 75);
            this.layoutControlItem7.SizeConstraintsType = DevExpress.XtraLayout.SizeConstraintsType.Custom;
            this.layoutControlItem7.TextVisible = false;
            // 
            // emptySpaceItem24
            // 
            this.emptySpaceItem24.Location = new System.Drawing.Point(0, 75);
            this.emptySpaceItem24.MaxSize = new System.Drawing.Size(171, 41);
            this.emptySpaceItem24.MinSize = new System.Drawing.Size(171, 41);
            this.emptySpaceItem24.Name = "emptySpaceItem24";
            this.emptySpaceItem24.Size = new System.Drawing.Size(171, 41);
            this.emptySpaceItem24.SizeConstraintsType = DevExpress.XtraLayout.SizeConstraintsType.Custom;
            // 
            // layoutControlItem8
            // 
            this.layoutControlItem8.Control = this.buttonMoveAllFieldsRight;
            this.layoutControlItem8.Location = new System.Drawing.Point(0, 116);
            this.layoutControlItem8.MaxSize = new System.Drawing.Size(171, 75);
            this.layoutControlItem8.MinSize = new System.Drawing.Size(171, 75);
            this.layoutControlItem8.Name = "layoutControlItem8";
            this.layoutControlItem8.Size = new System.Drawing.Size(171, 75);
            this.layoutControlItem8.SizeConstraintsType = DevExpress.XtraLayout.SizeConstraintsType.Custom;
            this.layoutControlItem8.TextVisible = false;
            // 
            // emptySpaceItem25
            // 
            this.emptySpaceItem25.Location = new System.Drawing.Point(0, 191);
            this.emptySpaceItem25.MaxSize = new System.Drawing.Size(171, 41);
            this.emptySpaceItem25.MinSize = new System.Drawing.Size(171, 41);
            this.emptySpaceItem25.Name = "emptySpaceItem25";
            this.emptySpaceItem25.Size = new System.Drawing.Size(171, 41);
            this.emptySpaceItem25.SizeConstraintsType = DevExpress.XtraLayout.SizeConstraintsType.Custom;
            // 
            // layoutControlItem9
            // 
            this.layoutControlItem9.Control = this.buttonMoveSelectedFieldsLeft;
            this.layoutControlItem9.Location = new System.Drawing.Point(0, 232);
            this.layoutControlItem9.MaxSize = new System.Drawing.Size(171, 75);
            this.layoutControlItem9.MinSize = new System.Drawing.Size(171, 75);
            this.layoutControlItem9.Name = "layoutControlItem9";
            this.layoutControlItem9.Size = new System.Drawing.Size(171, 75);
            this.layoutControlItem9.SizeConstraintsType = DevExpress.XtraLayout.SizeConstraintsType.Custom;
            this.layoutControlItem9.TextVisible = false;
            // 
            // emptySpaceItem26
            // 
            this.emptySpaceItem26.Location = new System.Drawing.Point(0, 307);
            this.emptySpaceItem26.MaxSize = new System.Drawing.Size(171, 41);
            this.emptySpaceItem26.MinSize = new System.Drawing.Size(171, 41);
            this.emptySpaceItem26.Name = "emptySpaceItem26";
            this.emptySpaceItem26.Size = new System.Drawing.Size(171, 41);
            this.emptySpaceItem26.SizeConstraintsType = DevExpress.XtraLayout.SizeConstraintsType.Custom;
            // 
            // layoutControlItem10
            // 
            this.layoutControlItem10.Control = this.buttonMoveAllFieldsLeft;
            this.layoutControlItem10.Location = new System.Drawing.Point(0, 348);
            this.layoutControlItem10.MaxSize = new System.Drawing.Size(171, 75);
            this.layoutControlItem10.MinSize = new System.Drawing.Size(171, 75);
            this.layoutControlItem10.Name = "layoutControlItem10";
            this.layoutControlItem10.Size = new System.Drawing.Size(171, 75);
            this.layoutControlItem10.SizeConstraintsType = DevExpress.XtraLayout.SizeConstraintsType.Custom;
            this.layoutControlItem10.TextVisible = false;
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
            this.ClientSize = new System.Drawing.Size(1158, 684);
            this.Controls.Add(this.tabControlCustomerBankExtract);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "frmCreateBankCustomerExtract";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Create Bank Customer Extract";
            this.Load += new System.EventHandler(this.frmCreateBankCustomerExtract_Load);
            ((System.ComponentModel.ISupportInitialize)(this.tabControlCustomerBankExtract)).EndInit();
            this.tabControlCustomerBankExtract.ResumeLayout(false);
            this.tabSelections.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlSelectionCriteria)).EndInit();
            this.layoutControlSelectionCriteria.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.radioGroupMatch.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nullableDateTimePickerPIEndDate.Properties.CalendarTimeProperties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nullableDateTimePickerPIEndDate.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lookUpEditState.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bindingSourceState)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Bank)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nullableDateTimePickerPIStartDate.Properties.CalendarTimeProperties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nullableDateTimePickerPIStartDate.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.radioButtonBoth.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.checkBoxFundingDate.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.checkBoxRepos.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lookUpEditDealer.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bindingSourceDLRLISTBYNUM)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.radioButtonInactive.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtControlDateEnd.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.radioButtonActive.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtControlDateStart.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nullableDateTimePickerStartDate.Properties.CalendarTimeProperties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nullableDateTimePickerStartDate.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nullableDateTimePickerEndDate.Properties.CalendarTimeProperties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nullableDateTimePickerEndDate.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nullableDateTimePickerBuyoutDate.Properties.CalendarTimeProperties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nullableDateTimePickerBuyoutDate.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Root)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroupStatus)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItemActive)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItemInactive)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItemBoth)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.emptySpaceItem3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroupStandardFilters)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItemStartDate)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.emptySpaceItem4)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItemEndDate)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItemBuyoutDate)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.emptySpaceItem1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItemStartControlDate)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItemEndControlDate)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.emptySpaceItem5)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItemDealer)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.emptySpaceItem8)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.emptySpaceItem6)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItemDealerState)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem4)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem5)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.emptySpaceItem9)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.emptySpaceItem10)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.emptySpaceItem15)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.emptySpaceItem16)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.emptySpaceItem20)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.emptySpaceItem21)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.emptySpaceItem19)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.emptySpaceItem7)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.emptySpaceItem11)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.emptySpaceItem12)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroupPaidInterest)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItemPaidInterestStartDate)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItemPaidInterestEndDate)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.emptySpaceItem14)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.emptySpaceItem13)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.emptySpaceItem17)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.emptySpaceItem18)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.emptySpaceItem2)).EndInit();
            this.tabFieldList.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlFieldSelection)).EndInit();
            this.layoutControlFieldSelection.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.listBoxSelectedFields)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.listBoxFieldList)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroupFieldSelection)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItemFieldList)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItemSelectedFields)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.emptySpaceItem22)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.emptySpaceItem23)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroupButtons)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem7)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.emptySpaceItem24)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem8)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.emptySpaceItem25)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem9)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.emptySpaceItem26)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem10)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl2)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraTab.XtraTabControl tabControlCustomerBankExtract;
        private DevExpress.XtraTab.XtraTabPage tabSelections;
        private DevExpress.XtraEditors.DateEdit nullableDateTimePickerPIEndDate;
        private DevExpress.XtraEditors.DateEdit nullableDateTimePickerPIStartDate;
        private DevExpress.XtraEditors.DateEdit nullableDateTimePickerBuyoutDate;
        private DevExpress.XtraEditors.CheckEdit checkBoxRepos;
        private DevExpress.XtraEditors.DateEdit nullableDateTimePickerEndDate;
        private DevExpress.XtraEditors.DateEdit nullableDateTimePickerStartDate;
        private DevExpress.XtraEditors.CheckEdit radioButtonBoth;
        private DevExpress.XtraEditors.CheckEdit radioButtonInactive;
        private DevExpress.XtraEditors.CheckEdit radioButtonActive;
        private DevExpress.XtraEditors.SimpleButton buttonPost;
        private DevExpress.XtraEditors.SimpleButton buttonCancel;
        private DevExpress.XtraEditors.CheckEdit checkBoxFundingDate;
        private DevExpress.XtraEditors.TextEdit txtControlDateEnd;
        private DevExpress.XtraEditors.TextEdit txtControlDateStart;
        private DevExpress.XtraTab.XtraTabPage tabFieldList;
        private DevExpress.XtraEditors.SimpleButton buttonMoveAllFieldsLeft;
        private DevExpress.XtraEditors.SimpleButton buttonMoveSelectedFieldsLeft;
        private DevExpress.XtraEditors.SimpleButton buttonMoveAllFieldsRight;
        private DevExpress.XtraEditors.SimpleButton buttonMoveSelectedFieldsRight;
        private DevExpress.XtraEditors.ListBoxControl listBoxFieldList;
        private DevExpress.XtraEditors.ListBoxControl listBoxSelectedFields;
        private DevExpress.XtraEditors.GroupControl groupControl2;
        private DevExpress.XtraEditors.SimpleButton simpleButtonClearRadioButtons;
        private DevExpress.XtraEditors.LookUpEdit lookUpEditDealer;
        private DevExpress.XtraEditors.LookUpEdit lookUpEditState;
        private System.Windows.Forms.BindingSource bindingSourceDLRLISTBYNUM;
        private System.Windows.Forms.BindingSource bindingSourceState;
        private IACDataSet Bank;
        private IACDataSetTableAdapters.ACCOUNTTableAdapter aCCOUNTTableAdapter;
        private IACDataSetTableAdapters.DLRLISTBYNUMTableAdapter DLRLISTBYNUMTableAdapter;
        private IACDataSetTableAdapters.stateTableAdapter stateTableAdapter;
        private DevExpress.XtraLayout.LayoutControl layoutControlSelectionCriteria;
        private DevExpress.XtraLayout.LayoutControlGroup Root;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItemActive;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItemInactive;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItemBoth;
        private DevExpress.XtraLayout.LayoutControlGroup layoutControlGroupStatus;
        private DevExpress.XtraLayout.EmptySpaceItem emptySpaceItem3;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItemStartDate;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItemEndDate;
        private DevExpress.XtraLayout.LayoutControlGroup layoutControlGroupStandardFilters;
        private DevExpress.XtraLayout.EmptySpaceItem emptySpaceItem4;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItemBuyoutDate;
        private DevExpress.XtraLayout.EmptySpaceItem emptySpaceItem1;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItemStartControlDate;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItemEndControlDate;
        private DevExpress.XtraLayout.EmptySpaceItem emptySpaceItem5;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItemDealer;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItemDealerState;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem1;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem2;
        private DevExpress.XtraLayout.EmptySpaceItem emptySpaceItem7;
        private DevExpress.XtraLayout.EmptySpaceItem emptySpaceItem8;
        private DevExpress.XtraLayout.EmptySpaceItem emptySpaceItem6;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem3;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem4;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem5;
        private DevExpress.XtraLayout.EmptySpaceItem emptySpaceItem9;
        private DevExpress.XtraLayout.EmptySpaceItem emptySpaceItem10;
        private DevExpress.XtraLayout.EmptySpaceItem emptySpaceItem11;
        private DevExpress.XtraLayout.EmptySpaceItem emptySpaceItem12;
        private DevExpress.XtraLayout.LayoutControlGroup layoutControlGroupPaidInterest;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItemPaidInterestStartDate;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItemPaidInterestEndDate;
        private DevExpress.XtraLayout.EmptySpaceItem emptySpaceItem14;
        private DevExpress.XtraLayout.EmptySpaceItem emptySpaceItem13;
        private DevExpress.XtraLayout.EmptySpaceItem emptySpaceItem15;
        private DevExpress.XtraLayout.EmptySpaceItem emptySpaceItem17;
        private DevExpress.XtraLayout.EmptySpaceItem emptySpaceItem18;
        private DevExpress.XtraLayout.EmptySpaceItem emptySpaceItem2;
        private DevExpress.XtraLayout.EmptySpaceItem emptySpaceItem16;
        private DevExpress.XtraLayout.EmptySpaceItem emptySpaceItem20;
        private DevExpress.XtraLayout.EmptySpaceItem emptySpaceItem21;
        private DevExpress.XtraLayout.EmptySpaceItem emptySpaceItem19;
        private DevExpress.XtraEditors.RadioGroup radioGroupMatch;
        private DevExpress.XtraLayout.LayoutControl layoutControlFieldSelection;
        private DevExpress.XtraLayout.LayoutControlGroup layoutControlGroupFieldSelection;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItemFieldList;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem7;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem8;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem9;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem10;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItemSelectedFields;
        private DevExpress.XtraLayout.EmptySpaceItem emptySpaceItem22;
        private DevExpress.XtraLayout.EmptySpaceItem emptySpaceItem23;
        private DevExpress.XtraLayout.EmptySpaceItem emptySpaceItem24;
        private DevExpress.XtraLayout.EmptySpaceItem emptySpaceItem25;
        private DevExpress.XtraLayout.EmptySpaceItem emptySpaceItem26;
        private DevExpress.XtraLayout.LayoutControlGroup layoutControlGroupButtons;
    }
}
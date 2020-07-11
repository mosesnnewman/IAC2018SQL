namespace IAC2018SQL
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmCreateBankCustomerExtract));
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabSelections = new System.Windows.Forms.TabPage();
            this.groupBoxPI = new System.Windows.Forms.GroupBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.nullableDateTimePickerPIEndDate = new ProManApp.NullableDateTimePicker();
            this.nullableDateTimePickerPIStartDate = new ProManApp.NullableDateTimePicker();
            this.groupBoxMainSelection = new System.Windows.Forms.GroupBox();
            this.checkBoxExtensions = new System.Windows.Forms.CheckBox();
            this.checkBoxMatchNBFields = new System.Windows.Forms.CheckBox();
            this.txtControlDateEnd = new System.Windows.Forms.MaskedTextBox();
            this.txtControlDateStart = new System.Windows.Forms.MaskedTextBox();
            this.labelControlDateEnd = new System.Windows.Forms.Label();
            this.labelControlDateStart = new System.Windows.Forms.Label();
            this.checkBoxFundingDate = new System.Windows.Forms.CheckBox();
            this.checkBoxTrialBalance = new System.Windows.Forms.CheckBox();
            this.labelBuyoutDate = new System.Windows.Forms.Label();
            this.nullableDateTimePickerBuyoutDate = new ProManApp.NullableDateTimePicker();
            this.checkBoxRepos = new System.Windows.Forms.CheckBox();
            this.label1 = new System.Windows.Forms.Label();
            this.comboBoxState = new System.Windows.Forms.ComboBox();
            this.textBoxDealerName = new System.Windows.Forms.TextBox();
            this.comboBoxDealer = new System.Windows.Forms.ComboBox();
            this.labelDealerNum = new System.Windows.Forms.Label();
            this.nullableDateTimePickerEndDate = new ProManApp.NullableDateTimePicker();
            this.nullableDateTimePickerStartDate = new ProManApp.NullableDateTimePicker();
            this.labelEndDate = new System.Windows.Forms.Label();
            this.labelStartDate = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.radioButtonBoth = new System.Windows.Forms.RadioButton();
            this.radioButtonInactive = new System.Windows.Forms.RadioButton();
            this.radioButtonActive = new System.Windows.Forms.RadioButton();
            this.buttonPost = new System.Windows.Forms.Button();
            this.buttonCancel = new System.Windows.Forms.Button();
            this.tabFieldList = new System.Windows.Forms.TabPage();
            this.buttonMoveAllFieldsLeft = new System.Windows.Forms.Button();
            this.buttonMoveSelectedFieldsLeft = new System.Windows.Forms.Button();
            this.buttonMoveAllFieldsRight = new System.Windows.Forms.Button();
            this.buttonMoveSelectedFieldsRight = new System.Windows.Forms.Button();
            this.listBoxSelectedFields = new System.Windows.Forms.ListBox();
            this.listBoxFieldList = new System.Windows.Forms.ListBox();
            this.tabControl1.SuspendLayout();
            this.tabSelections.SuspendLayout();
            this.groupBoxPI.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nullableDateTimePickerPIEndDate)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nullableDateTimePickerPIStartDate)).BeginInit();
            this.groupBoxMainSelection.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nullableDateTimePickerBuyoutDate)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nullableDateTimePickerEndDate)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nullableDateTimePickerStartDate)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.tabFieldList.SuspendLayout();
            this.SuspendLayout();
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabSelections);
            this.tabControl1.Controls.Add(this.tabFieldList);
            this.tabControl1.Location = new System.Drawing.Point(0, -4);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(690, 464);
            this.tabControl1.TabIndex = 0;
            // 
            // tabSelections
            // 
            this.tabSelections.BackColor = System.Drawing.Color.LightSteelBlue;
            this.tabSelections.Controls.Add(this.groupBoxPI);
            this.tabSelections.Controls.Add(this.groupBoxMainSelection);
            this.tabSelections.Controls.Add(this.groupBox1);
            this.tabSelections.Controls.Add(this.buttonPost);
            this.tabSelections.Controls.Add(this.buttonCancel);
            this.tabSelections.Location = new System.Drawing.Point(4, 25);
            this.tabSelections.Name = "tabSelections";
            this.tabSelections.Padding = new System.Windows.Forms.Padding(3);
            this.tabSelections.Size = new System.Drawing.Size(682, 435);
            this.tabSelections.TabIndex = 0;
            this.tabSelections.Text = "Selection Criteria";
            // 
            // groupBoxPI
            // 
            this.groupBoxPI.Controls.Add(this.label2);
            this.groupBoxPI.Controls.Add(this.label3);
            this.groupBoxPI.Controls.Add(this.nullableDateTimePickerPIEndDate);
            this.groupBoxPI.Controls.Add(this.nullableDateTimePickerPIStartDate);
            this.groupBoxPI.Location = new System.Drawing.Point(465, 101);
            this.groupBoxPI.Name = "groupBoxPI";
            this.groupBoxPI.Size = new System.Drawing.Size(192, 101);
            this.groupBoxPI.TabIndex = 19;
            this.groupBoxPI.TabStop = false;
            this.groupBoxPI.Text = "Paid Interest";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(11, 58);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(67, 16);
            this.label2.TabIndex = 37;
            this.label2.Text = "End Date:";
            this.label2.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(8, 33);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(70, 16);
            this.label3.TabIndex = 36;
            this.label3.Text = "Start Date:";
            this.label3.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // nullableDateTimePickerPIEndDate
            // 
            this.nullableDateTimePickerPIEndDate.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.nullableDateTimePickerPIEndDate.Location = new System.Drawing.Point(80, 52);
            this.nullableDateTimePickerPIEndDate.Name = "nullableDateTimePickerPIEndDate";
            this.nullableDateTimePickerPIEndDate.Size = new System.Drawing.Size(95, 22);
            this.nullableDateTimePickerPIEndDate.TabIndex = 21;
            this.nullableDateTimePickerPIEndDate.Value = new System.DateTime(2020, 7, 7, 0, 0, 0, 0);
            // 
            // nullableDateTimePickerPIStartDate
            // 
            this.nullableDateTimePickerPIStartDate.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.nullableDateTimePickerPIStartDate.Location = new System.Drawing.Point(80, 27);
            this.nullableDateTimePickerPIStartDate.Name = "nullableDateTimePickerPIStartDate";
            this.nullableDateTimePickerPIStartDate.Size = new System.Drawing.Size(95, 22);
            this.nullableDateTimePickerPIStartDate.TabIndex = 20;
            this.nullableDateTimePickerPIStartDate.Value = new System.DateTime(2020, 7, 7, 0, 0, 0, 0);
            // 
            // groupBoxMainSelection
            // 
            this.groupBoxMainSelection.Controls.Add(this.checkBoxExtensions);
            this.groupBoxMainSelection.Controls.Add(this.checkBoxMatchNBFields);
            this.groupBoxMainSelection.Controls.Add(this.txtControlDateEnd);
            this.groupBoxMainSelection.Controls.Add(this.txtControlDateStart);
            this.groupBoxMainSelection.Controls.Add(this.labelControlDateEnd);
            this.groupBoxMainSelection.Controls.Add(this.labelControlDateStart);
            this.groupBoxMainSelection.Controls.Add(this.checkBoxFundingDate);
            this.groupBoxMainSelection.Controls.Add(this.checkBoxTrialBalance);
            this.groupBoxMainSelection.Controls.Add(this.labelBuyoutDate);
            this.groupBoxMainSelection.Controls.Add(this.nullableDateTimePickerBuyoutDate);
            this.groupBoxMainSelection.Controls.Add(this.checkBoxRepos);
            this.groupBoxMainSelection.Controls.Add(this.label1);
            this.groupBoxMainSelection.Controls.Add(this.comboBoxState);
            this.groupBoxMainSelection.Controls.Add(this.textBoxDealerName);
            this.groupBoxMainSelection.Controls.Add(this.comboBoxDealer);
            this.groupBoxMainSelection.Controls.Add(this.labelDealerNum);
            this.groupBoxMainSelection.Controls.Add(this.nullableDateTimePickerEndDate);
            this.groupBoxMainSelection.Controls.Add(this.nullableDateTimePickerStartDate);
            this.groupBoxMainSelection.Controls.Add(this.labelEndDate);
            this.groupBoxMainSelection.Controls.Add(this.labelStartDate);
            this.groupBoxMainSelection.Location = new System.Drawing.Point(25, 101);
            this.groupBoxMainSelection.Name = "groupBoxMainSelection";
            this.groupBoxMainSelection.Size = new System.Drawing.Size(434, 209);
            this.groupBoxMainSelection.TabIndex = 5;
            this.groupBoxMainSelection.TabStop = false;
            this.groupBoxMainSelection.Text = "Standard Filters";
            // 
            // checkBoxExtensions
            // 
            this.checkBoxExtensions.AutoSize = true;
            this.checkBoxExtensions.Location = new System.Drawing.Point(279, 182);
            this.checkBoxExtensions.Name = "checkBoxExtensions";
            this.checkBoxExtensions.Size = new System.Drawing.Size(125, 20);
            this.checkBoxExtensions.TabIndex = 117;
            this.checkBoxExtensions.Text = "ExtensionExtract";
            this.checkBoxExtensions.UseVisualStyleBackColor = true;
            this.checkBoxExtensions.CheckStateChanged += new System.EventHandler(this.checkBoxExtensions_CheckStateChanged);
            // 
            // checkBoxMatchNBFields
            // 
            this.checkBoxMatchNBFields.AutoSize = true;
            this.checkBoxMatchNBFields.Location = new System.Drawing.Point(279, 130);
            this.checkBoxMatchNBFields.Name = "checkBoxMatchNBFields";
            this.checkBoxMatchNBFields.Size = new System.Drawing.Size(131, 20);
            this.checkBoxMatchNBFields.TabIndex = 17;
            this.checkBoxMatchNBFields.Text = "Match N.B. Fields";
            this.checkBoxMatchNBFields.UseVisualStyleBackColor = true;
            this.checkBoxMatchNBFields.CheckedChanged += new System.EventHandler(this.checkBoxMatchNBFields_CheckedChanged);
            this.checkBoxMatchNBFields.CheckStateChanged += new System.EventHandler(this.checkBoxMatchNBFields_CheckStateChanged);
            // 
            // txtControlDateEnd
            // 
            this.txtControlDateEnd.CutCopyMaskFormat = System.Windows.Forms.MaskFormat.ExcludePromptAndLiterals;
            this.txtControlDateEnd.Location = new System.Drawing.Point(356, 66);
            this.txtControlDateEnd.Mask = "00/00";
            this.txtControlDateEnd.Name = "txtControlDateEnd";
            this.txtControlDateEnd.Size = new System.Drawing.Size(41, 22);
            this.txtControlDateEnd.TabIndex = 10;
            this.txtControlDateEnd.TextMaskFormat = System.Windows.Forms.MaskFormat.ExcludePromptAndLiterals;
            // 
            // txtControlDateStart
            // 
            this.txtControlDateStart.CutCopyMaskFormat = System.Windows.Forms.MaskFormat.ExcludePromptAndLiterals;
            this.txtControlDateStart.Location = new System.Drawing.Point(356, 41);
            this.txtControlDateStart.Mask = "00/00";
            this.txtControlDateStart.Name = "txtControlDateStart";
            this.txtControlDateStart.Size = new System.Drawing.Size(41, 22);
            this.txtControlDateStart.TabIndex = 9;
            this.txtControlDateStart.TextMaskFormat = System.Windows.Forms.MaskFormat.ExcludePromptAndLiterals;
            // 
            // labelControlDateEnd
            // 
            this.labelControlDateEnd.AutoSize = true;
            this.labelControlDateEnd.Location = new System.Drawing.Point(212, 72);
            this.labelControlDateEnd.Name = "labelControlDateEnd";
            this.labelControlDateEnd.Size = new System.Drawing.Size(112, 16);
            this.labelControlDateEnd.TabIndex = 116;
            this.labelControlDateEnd.Text = "End Control Date:";
            this.labelControlDateEnd.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // labelControlDateStart
            // 
            this.labelControlDateStart.AutoSize = true;
            this.labelControlDateStart.Location = new System.Drawing.Point(212, 47);
            this.labelControlDateStart.Name = "labelControlDateStart";
            this.labelControlDateStart.Size = new System.Drawing.Size(115, 16);
            this.labelControlDateStart.TabIndex = 114;
            this.labelControlDateStart.Text = "Start Control Date:";
            this.labelControlDateStart.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // checkBoxFundingDate
            // 
            this.checkBoxFundingDate.AutoSize = true;
            this.checkBoxFundingDate.Location = new System.Drawing.Point(9, 156);
            this.checkBoxFundingDate.Name = "checkBoxFundingDate";
            this.checkBoxFundingDate.Size = new System.Drawing.Size(153, 20);
            this.checkBoxFundingDate.TabIndex = 14;
            this.checkBoxFundingDate.Text = "Funding Date Search";
            this.checkBoxFundingDate.UseVisualStyleBackColor = true;
            // 
            // checkBoxTrialBalance
            // 
            this.checkBoxTrialBalance.AutoSize = true;
            this.checkBoxTrialBalance.Location = new System.Drawing.Point(279, 156);
            this.checkBoxTrialBalance.Name = "checkBoxTrialBalance";
            this.checkBoxTrialBalance.Size = new System.Drawing.Size(146, 20);
            this.checkBoxTrialBalance.TabIndex = 16;
            this.checkBoxTrialBalance.Text = "Match Trial Balance";
            this.checkBoxTrialBalance.UseVisualStyleBackColor = true;
            this.checkBoxTrialBalance.CheckStateChanged += new System.EventHandler(this.checkBoxTrialBalance_CheckStateChanged);
            // 
            // labelBuyoutDate
            // 
            this.labelBuyoutDate.AutoSize = true;
            this.labelBuyoutDate.Location = new System.Drawing.Point(213, 22);
            this.labelBuyoutDate.Name = "labelBuyoutDate";
            this.labelBuyoutDate.Size = new System.Drawing.Size(84, 16);
            this.labelBuyoutDate.TabIndex = 33;
            this.labelBuyoutDate.Text = "Buyout Date:";
            this.labelBuyoutDate.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // nullableDateTimePickerBuyoutDate
            // 
            this.nullableDateTimePickerBuyoutDate.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.nullableDateTimePickerBuyoutDate.Location = new System.Drawing.Point(302, 16);
            this.nullableDateTimePickerBuyoutDate.Name = "nullableDateTimePickerBuyoutDate";
            this.nullableDateTimePickerBuyoutDate.Size = new System.Drawing.Size(95, 22);
            this.nullableDateTimePickerBuyoutDate.TabIndex = 7;
            this.nullableDateTimePickerBuyoutDate.Value = new System.DateTime(2020, 7, 7, 0, 0, 0, 0);
            // 
            // checkBoxRepos
            // 
            this.checkBoxRepos.AutoSize = true;
            this.checkBoxRepos.Location = new System.Drawing.Point(166, 156);
            this.checkBoxRepos.Name = "checkBoxRepos";
            this.checkBoxRepos.Size = new System.Drawing.Size(98, 20);
            this.checkBoxRepos.TabIndex = 15;
            this.checkBoxRepos.Text = "Repos Only";
            this.checkBoxRepos.UseVisualStyleBackColor = true;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(16, 130);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(86, 16);
            this.label1.TabIndex = 30;
            this.label1.Text = "Dealer State:";
            // 
            // comboBoxState
            // 
            this.comboBoxState.DisplayMember = "abbreviation";
            this.comboBoxState.FormattingEnabled = true;
            this.comboBoxState.Location = new System.Drawing.Point(103, 126);
            this.comboBoxState.Name = "comboBoxState";
            this.comboBoxState.Size = new System.Drawing.Size(166, 24);
            this.comboBoxState.TabIndex = 13;
            this.comboBoxState.ValueMember = "abbreviation";
            // 
            // textBoxDealerName
            // 
            this.textBoxDealerName.Location = new System.Drawing.Point(169, 97);
            this.textBoxDealerName.Name = "textBoxDealerName";
            this.textBoxDealerName.ReadOnly = true;
            this.textBoxDealerName.Size = new System.Drawing.Size(220, 22);
            this.textBoxDealerName.TabIndex = 12;
            // 
            // comboBoxDealer
            // 
            this.comboBoxDealer.DisplayMember = "DEALER_ACC_NO";
            this.comboBoxDealer.FormattingEnabled = true;
            this.comboBoxDealer.Location = new System.Drawing.Point(103, 96);
            this.comboBoxDealer.Name = "comboBoxDealer";
            this.comboBoxDealer.Size = new System.Drawing.Size(59, 24);
            this.comboBoxDealer.TabIndex = 11;
            this.comboBoxDealer.ValueMember = "DEALER_ACC_NO";
            // 
            // labelDealerNum
            // 
            this.labelDealerNum.AutoSize = true;
            this.labelDealerNum.Location = new System.Drawing.Point(51, 104);
            this.labelDealerNum.Name = "labelDealerNum";
            this.labelDealerNum.Size = new System.Drawing.Size(52, 16);
            this.labelDealerNum.TabIndex = 22;
            this.labelDealerNum.Text = "Dealer:";
            this.labelDealerNum.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // nullableDateTimePickerEndDate
            // 
            this.nullableDateTimePickerEndDate.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.nullableDateTimePickerEndDate.Location = new System.Drawing.Point(103, 41);
            this.nullableDateTimePickerEndDate.Name = "nullableDateTimePickerEndDate";
            this.nullableDateTimePickerEndDate.Size = new System.Drawing.Size(95, 22);
            this.nullableDateTimePickerEndDate.TabIndex = 8;
            this.nullableDateTimePickerEndDate.Value = new System.DateTime(2020, 7, 7, 0, 0, 0, 0);
            // 
            // nullableDateTimePickerStartDate
            // 
            this.nullableDateTimePickerStartDate.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.nullableDateTimePickerStartDate.Location = new System.Drawing.Point(103, 16);
            this.nullableDateTimePickerStartDate.Name = "nullableDateTimePickerStartDate";
            this.nullableDateTimePickerStartDate.Size = new System.Drawing.Size(95, 22);
            this.nullableDateTimePickerStartDate.TabIndex = 6;
            this.nullableDateTimePickerStartDate.Value = new System.DateTime(2020, 7, 7, 0, 0, 0, 0);
            // 
            // labelEndDate
            // 
            this.labelEndDate.AutoSize = true;
            this.labelEndDate.Location = new System.Drawing.Point(37, 47);
            this.labelEndDate.Name = "labelEndDate";
            this.labelEndDate.Size = new System.Drawing.Size(67, 16);
            this.labelEndDate.TabIndex = 19;
            this.labelEndDate.Text = "End Date:";
            this.labelEndDate.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // labelStartDate
            // 
            this.labelStartDate.AutoSize = true;
            this.labelStartDate.Location = new System.Drawing.Point(34, 22);
            this.labelStartDate.Name = "labelStartDate";
            this.labelStartDate.Size = new System.Drawing.Size(70, 16);
            this.labelStartDate.TabIndex = 16;
            this.labelStartDate.Text = "Start Date:";
            this.labelStartDate.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.radioButtonBoth);
            this.groupBox1.Controls.Add(this.radioButtonInactive);
            this.groupBox1.Controls.Add(this.radioButtonActive);
            this.groupBox1.Location = new System.Drawing.Point(284, 5);
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
            this.radioButtonBoth.Size = new System.Drawing.Size(53, 20);
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
            this.radioButtonInactive.Size = new System.Drawing.Size(72, 20);
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
            this.radioButtonActive.Size = new System.Drawing.Size(63, 20);
            this.radioButtonActive.TabIndex = 2;
            this.radioButtonActive.TabStop = true;
            this.radioButtonActive.Text = "&Active";
            this.radioButtonActive.UseVisualStyleBackColor = true;
            // 
            // buttonPost
            // 
            this.buttonPost.Image = ((System.Drawing.Image)(resources.GetObject("buttonPost.Image")));
            this.buttonPost.Location = new System.Drawing.Point(222, 327);
            this.buttonPost.Name = "buttonPost";
            this.buttonPost.Size = new System.Drawing.Size(110, 103);
            this.buttonPost.TabIndex = 22;
            this.buttonPost.Text = "Create &Extract";
            this.buttonPost.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.buttonPost.UseVisualStyleBackColor = true;
            this.buttonPost.Click += new System.EventHandler(this.buttonTransfer_Click);
            // 
            // buttonCancel
            // 
            this.buttonCancel.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonCancel.Image = ((System.Drawing.Image)(resources.GetObject("buttonCancel.Image")));
            this.buttonCancel.Location = new System.Drawing.Point(350, 327);
            this.buttonCancel.Margin = new System.Windows.Forms.Padding(4);
            this.buttonCancel.Name = "buttonCancel";
            this.buttonCancel.Size = new System.Drawing.Size(110, 103);
            this.buttonCancel.TabIndex = 23;
            this.buttonCancel.Text = "&Cancel";
            this.buttonCancel.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.buttonCancel.UseVisualStyleBackColor = true;
            // 
            // tabFieldList
            // 
            this.tabFieldList.BackColor = System.Drawing.Color.LightSteelBlue;
            this.tabFieldList.Controls.Add(this.buttonMoveAllFieldsLeft);
            this.tabFieldList.Controls.Add(this.buttonMoveSelectedFieldsLeft);
            this.tabFieldList.Controls.Add(this.buttonMoveAllFieldsRight);
            this.tabFieldList.Controls.Add(this.buttonMoveSelectedFieldsRight);
            this.tabFieldList.Controls.Add(this.listBoxSelectedFields);
            this.tabFieldList.Controls.Add(this.listBoxFieldList);
            this.tabFieldList.Location = new System.Drawing.Point(4, 25);
            this.tabFieldList.Name = "tabFieldList";
            this.tabFieldList.Padding = new System.Windows.Forms.Padding(3);
            this.tabFieldList.Size = new System.Drawing.Size(682, 435);
            this.tabFieldList.TabIndex = 1;
            this.tabFieldList.Text = "Field Selection";
            // 
            // buttonMoveAllFieldsLeft
            // 
            this.buttonMoveAllFieldsLeft.Image = global::IAC2018SQL.Properties.Resources.CollapseChevronLeftGroup_16x1;
            this.buttonMoveAllFieldsLeft.Location = new System.Drawing.Point(290, 304);
            this.buttonMoveAllFieldsLeft.Name = "buttonMoveAllFieldsLeft";
            this.buttonMoveAllFieldsLeft.Size = new System.Drawing.Size(101, 48);
            this.buttonMoveAllFieldsLeft.TabIndex = 5;
            this.buttonMoveAllFieldsLeft.UseVisualStyleBackColor = true;
            this.buttonMoveAllFieldsLeft.Click += new System.EventHandler(this.buttonMoveAllFieldsLeft_Click);
            // 
            // buttonMoveSelectedFieldsLeft
            // 
            this.buttonMoveSelectedFieldsLeft.Image = global::IAC2018SQL.Properties.Resources.CollapseChevronLeft_16x;
            this.buttonMoveSelectedFieldsLeft.Location = new System.Drawing.Point(291, 230);
            this.buttonMoveSelectedFieldsLeft.Name = "buttonMoveSelectedFieldsLeft";
            this.buttonMoveSelectedFieldsLeft.Size = new System.Drawing.Size(101, 48);
            this.buttonMoveSelectedFieldsLeft.TabIndex = 4;
            this.buttonMoveSelectedFieldsLeft.UseVisualStyleBackColor = true;
            this.buttonMoveSelectedFieldsLeft.Click += new System.EventHandler(this.buttonMoveSelectedFieldsLeft_Click);
            // 
            // buttonMoveAllFieldsRight
            // 
            this.buttonMoveAllFieldsRight.Image = global::IAC2018SQL.Properties.Resources.ExpandChevronRightGroup_16x;
            this.buttonMoveAllFieldsRight.Location = new System.Drawing.Point(291, 156);
            this.buttonMoveAllFieldsRight.Name = "buttonMoveAllFieldsRight";
            this.buttonMoveAllFieldsRight.Size = new System.Drawing.Size(101, 48);
            this.buttonMoveAllFieldsRight.TabIndex = 3;
            this.buttonMoveAllFieldsRight.UseVisualStyleBackColor = true;
            this.buttonMoveAllFieldsRight.Click += new System.EventHandler(this.buttonMoveAllFieldsRight_Click);
            // 
            // buttonMoveSelectedFieldsRight
            // 
            this.buttonMoveSelectedFieldsRight.Image = global::IAC2018SQL.Properties.Resources.ExpandChevronRight_16x;
            this.buttonMoveSelectedFieldsRight.Location = new System.Drawing.Point(290, 82);
            this.buttonMoveSelectedFieldsRight.Name = "buttonMoveSelectedFieldsRight";
            this.buttonMoveSelectedFieldsRight.Size = new System.Drawing.Size(101, 48);
            this.buttonMoveSelectedFieldsRight.TabIndex = 2;
            this.buttonMoveSelectedFieldsRight.UseVisualStyleBackColor = true;
            this.buttonMoveSelectedFieldsRight.Click += new System.EventHandler(this.buttonMoveSelectedFieldsRight_Click);
            // 
            // listBoxSelectedFields
            // 
            this.listBoxSelectedFields.FormattingEnabled = true;
            this.listBoxSelectedFields.ItemHeight = 16;
            this.listBoxSelectedFields.Location = new System.Drawing.Point(397, 7);
            this.listBoxSelectedFields.Name = "listBoxSelectedFields";
            this.listBoxSelectedFields.SelectionMode = System.Windows.Forms.SelectionMode.MultiExtended;
            this.listBoxSelectedFields.Size = new System.Drawing.Size(281, 420);
            this.listBoxSelectedFields.TabIndex = 1;
            // 
            // listBoxFieldList
            // 
            this.listBoxFieldList.FormattingEnabled = true;
            this.listBoxFieldList.ItemHeight = 16;
            this.listBoxFieldList.Location = new System.Drawing.Point(3, 7);
            this.listBoxFieldList.Name = "listBoxFieldList";
            this.listBoxFieldList.SelectionMode = System.Windows.Forms.SelectionMode.MultiExtended;
            this.listBoxFieldList.Size = new System.Drawing.Size(281, 420);
            this.listBoxFieldList.TabIndex = 0;
            // 
            // frmCreateBankCustomerExtract
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.BackColor = System.Drawing.Color.LightSteelBlue;
            this.ClientSize = new System.Drawing.Size(691, 461);
            this.Controls.Add(this.tabControl1);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "frmCreateBankCustomerExtract";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Create Bank Customer Extract";
            this.Load += new System.EventHandler(this.frmCreateBankCustomerExtract_Load);
            this.tabControl1.ResumeLayout(false);
            this.tabSelections.ResumeLayout(false);
            this.groupBoxPI.ResumeLayout(false);
            this.groupBoxPI.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nullableDateTimePickerPIEndDate)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nullableDateTimePickerPIStartDate)).EndInit();
            this.groupBoxMainSelection.ResumeLayout(false);
            this.groupBoxMainSelection.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nullableDateTimePickerBuyoutDate)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nullableDateTimePickerEndDate)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nullableDateTimePickerStartDate)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.tabFieldList.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabSelections;
        private System.Windows.Forms.GroupBox groupBoxPI;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private ProManApp.NullableDateTimePicker nullableDateTimePickerPIEndDate;
        private ProManApp.NullableDateTimePicker nullableDateTimePickerPIStartDate;
        private System.Windows.Forms.GroupBox groupBoxMainSelection;
        private System.Windows.Forms.CheckBox checkBoxTrialBalance;
        private System.Windows.Forms.Label labelBuyoutDate;
        private ProManApp.NullableDateTimePicker nullableDateTimePickerBuyoutDate;
        private System.Windows.Forms.CheckBox checkBoxRepos;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox comboBoxState;
        private System.Windows.Forms.TextBox textBoxDealerName;
        private System.Windows.Forms.ComboBox comboBoxDealer;
        private System.Windows.Forms.Label labelDealerNum;
        private ProManApp.NullableDateTimePicker nullableDateTimePickerEndDate;
        private ProManApp.NullableDateTimePicker nullableDateTimePickerStartDate;
        private System.Windows.Forms.Label labelEndDate;
        private System.Windows.Forms.Label labelStartDate;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.RadioButton radioButtonBoth;
        private System.Windows.Forms.RadioButton radioButtonInactive;
        private System.Windows.Forms.RadioButton radioButtonActive;
        private System.Windows.Forms.Button buttonPost;
        private System.Windows.Forms.Button buttonCancel;
        private System.Windows.Forms.TabPage tabFieldList;
        private System.Windows.Forms.ListBox listBoxFieldList;
        private System.Windows.Forms.ListBox listBoxSelectedFields;
        private System.Windows.Forms.Button buttonMoveSelectedFieldsRight;
        private System.Windows.Forms.Button buttonMoveAllFieldsLeft;
        private System.Windows.Forms.Button buttonMoveSelectedFieldsLeft;
        private System.Windows.Forms.Button buttonMoveAllFieldsRight;
        private System.Windows.Forms.CheckBox checkBoxFundingDate;
        private System.Windows.Forms.Label labelControlDateStart;
        private System.Windows.Forms.Label labelControlDateEnd;
        private System.Windows.Forms.MaskedTextBox txtControlDateEnd;
        private System.Windows.Forms.MaskedTextBox txtControlDateStart;
        private System.Windows.Forms.CheckBox checkBoxMatchNBFields;
        private System.Windows.Forms.CheckBox checkBoxExtensions;
    }
}
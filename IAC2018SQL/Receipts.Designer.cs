namespace IAC2021SQL
{
    partial class FormReciept
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormReciept));
            this.iacDataSetReceipts = new IAC2021SQL.IACDataSet();
            this.opnclscustomerTableAdapter = new IAC2021SQL.IACDataSetTableAdapters.OPNCLSCUSTOMERTableAdapter();
            this.opndealrTableAdapter = new IAC2021SQL.IACDataSetTableAdapters.OPNDEALRTableAdapter();
            this.dealerTableAdapter = new IAC2021SQL.IACDataSetTableAdapters.DEALERTableAdapter();
            this.textBoxCustomerNo = new System.Windows.Forms.TextBox();
            this.bindingSourceCustomer = new System.Windows.Forms.BindingSource(this.components);
            this.cUSTOMER_SUFFIXTextBox = new System.Windows.Forms.TextBox();
            this.cUSTOMER_Add_OnTextBox = new System.Windows.Forms.TextBox();
            this.cUSTOMER_CONTACTTextBox = new System.Windows.Forms.TextBox();
            this.cUSTOMER_ZIP_2TextBox = new System.Windows.Forms.TextBox();
            this.cUSTOMER_ZIP_1TextBox = new System.Windows.Forms.TextBox();
            this.cUSTOMER_STATETextBox = new System.Windows.Forms.TextBox();
            this.cUSTOMER_CITYTextBox = new System.Windows.Forms.TextBox();
            this.cUSTOMER_STREET_2TextBox = new System.Windows.Forms.TextBox();
            this.cUSTOMER_STREET_1TextBox = new System.Windows.Forms.TextBox();
            this.cUSTOMER_LAST_NAMETextBox = new System.Windows.Forms.TextBox();
            this.cUSTOMER_FIRST_NAMETextBox = new System.Windows.Forms.TextBox();
            this.cUSTOMER_IAC_TypeTextBox = new System.Windows.Forms.TextBox();
            this.labelCustomer = new System.Windows.Forms.Label();
            this.labelName = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.textBoxDealerName = new System.Windows.Forms.TextBox();
            this.textBoxDealerAccNo = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.ulistTableAdapter = new IAC2021SQL.IACDataSetTableAdapters.ULISTTableAdapter();
            this.textBoxUserName = new System.Windows.Forms.TextBox();
            this.textBoxUserID = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.textBoxOldReceiptNumber = new System.Windows.Forms.TextBox();
            this.bindingSourceReceipt = new System.Windows.Forms.BindingSource(this.components);
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.toolStripButtonEdit = new System.Windows.Forms.ToolStripButton();
            this.toolStripButtonDelete = new System.Windows.Forms.ToolStripButton();
            this.toolStripButtonSave = new System.Windows.Forms.ToolStripButton();
            this.bindingSourceORECEIPT = new System.Windows.Forms.BindingSource(this.components);
            this.oRECEIPTTableAdapter = new IAC2021SQL.IACDataSetTableAdapters.ORECEIPTTableAdapter();
            this.textBoxAmountPaid = new System.Windows.Forms.TextBox();
            this.labelAmountPaid = new System.Windows.Forms.Label();
            this.textBoxCashTendered = new System.Windows.Forms.TextBox();
            this.label10 = new System.Windows.Forms.Label();
            this.textBox100s = new System.Windows.Forms.TextBox();
            this.label11 = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.textBox50s = new System.Windows.Forms.TextBox();
            this.label13 = new System.Windows.Forms.Label();
            this.textBox20s = new System.Windows.Forms.TextBox();
            this.label14 = new System.Windows.Forms.Label();
            this.textBox5s = new System.Windows.Forms.TextBox();
            this.label15 = new System.Windows.Forms.Label();
            this.textBox1s = new System.Windows.Forms.TextBox();
            this.label16 = new System.Windows.Forms.Label();
            this.textBoxCoins = new System.Windows.Forms.TextBox();
            this.label17 = new System.Windows.Forms.Label();
            this.textBoxCreditCardAmount1 = new System.Windows.Forms.TextBox();
            this.label18 = new System.Windows.Forms.Label();
            this.textBoxCheckAmount = new System.Windows.Forms.TextBox();
            this.textBoxCheckNumber = new System.Windows.Forms.TextBox();
            this.label19 = new System.Windows.Forms.Label();
            this.label20 = new System.Windows.Forms.Label();
            this.textBoxMoneyOrderNumber = new System.Windows.Forms.TextBox();
            this.label21 = new System.Windows.Forms.Label();
            this.textBoxMoneyOrderAmount = new System.Windows.Forms.TextBox();
            this.buttonCreditCard = new System.Windows.Forms.Button();
            this.buttonMoneyOrder = new System.Windows.Forms.Button();
            this.buttonCheck = new System.Windows.Forms.Button();
            this.buttonCash = new System.Windows.Forms.Button();
            this.groupBoxAmounts = new System.Windows.Forms.GroupBox();
            this.label25 = new System.Windows.Forms.Label();
            this.textBoxCreditCardAmount3 = new System.Windows.Forms.TextBox();
            this.label24 = new System.Windows.Forms.Label();
            this.textBoxCreditCardAmount2 = new System.Windows.Forms.TextBox();
            this.groupBoxCounts = new System.Windows.Forms.GroupBox();
            this.label10s = new System.Windows.Forms.Label();
            this.textBox10s = new System.Windows.Forms.TextBox();
            this.label23 = new System.Windows.Forms.Label();
            this.nullableDateTimePickerHoldDate = new UIComponent.DateTimePicker();
            this.checkBoxHold = new System.Windows.Forms.CheckBox();
            this.label35 = new System.Windows.Forms.Label();
            this.label36 = new System.Windows.Forms.Label();
            this.label37 = new System.Windows.Forms.Label();
            this.label38 = new System.Windows.Forms.Label();
            this.textBoxCreditCardApproval3 = new System.Windows.Forms.TextBox();
            this.textBoxCreditCardType3 = new System.Windows.Forms.TextBox();
            this.textBoxExpDateYear3 = new System.Windows.Forms.TextBox();
            this.textBoxExpDateMonth3 = new System.Windows.Forms.TextBox();
            this.textBoxCreditCardSecurityCode3 = new System.Windows.Forms.TextBox();
            this.labelCreditCard3 = new System.Windows.Forms.Label();
            this.textBoxCreditCardNumber3 = new System.Windows.Forms.TextBox();
            this.label30 = new System.Windows.Forms.Label();
            this.label31 = new System.Windows.Forms.Label();
            this.label32 = new System.Windows.Forms.Label();
            this.label33 = new System.Windows.Forms.Label();
            this.textBoxCreditCardApproval2 = new System.Windows.Forms.TextBox();
            this.textBoxCreditCardType2 = new System.Windows.Forms.TextBox();
            this.textBoxExpDateYear2 = new System.Windows.Forms.TextBox();
            this.textBoxExpDateMonth2 = new System.Windows.Forms.TextBox();
            this.textBoxCreditCardSecurityCode2 = new System.Windows.Forms.TextBox();
            this.labelCreditCard2 = new System.Windows.Forms.Label();
            this.textBoxCreditCardNumber2 = new System.Windows.Forms.TextBox();
            this.label29 = new System.Windows.Forms.Label();
            this.label28 = new System.Windows.Forms.Label();
            this.label27 = new System.Windows.Forms.Label();
            this.label26 = new System.Windows.Forms.Label();
            this.textBoxCreditCardApproval1 = new System.Windows.Forms.TextBox();
            this.textBoxCreditCardType1 = new System.Windows.Forms.TextBox();
            this.textBoxExpDateYear1 = new System.Windows.Forms.TextBox();
            this.textBoxExpDateMonth1 = new System.Windows.Forms.TextBox();
            this.textBoxCreditCardSecurityCode1 = new System.Windows.Forms.TextBox();
            this.labelCreditCard1 = new System.Windows.Forms.Label();
            this.textBoxCreditCardNumber1 = new System.Windows.Forms.TextBox();
            this.groupBoxTenderButtons = new System.Windows.Forms.GroupBox();
            this.button1 = new System.Windows.Forms.Button();
            this.groupBoxComment = new System.Windows.Forms.GroupBox();
            this.labelCashChange = new System.Windows.Forms.Label();
            this.textBoxCashChange = new System.Windows.Forms.TextBox();
            this.label22 = new System.Windows.Forms.Label();
            this.textBoxComment = new System.Windows.Forms.TextBox();
            this.receiptTableAdapter = new IAC2021SQL.IACDataSetTableAdapters.ReceiptTableAdapter();
            ((System.ComponentModel.ISupportInitialize)(this.iacDataSetReceipts)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bindingSourceCustomer)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bindingSourceReceipt)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.toolStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.bindingSourceORECEIPT)).BeginInit();
            this.groupBoxAmounts.SuspendLayout();
            this.groupBoxCounts.SuspendLayout();
            this.groupBoxTenderButtons.SuspendLayout();
            this.groupBoxComment.SuspendLayout();
            this.SuspendLayout();
            // 
            // iacDataSetReceipts
            // 
            this.iacDataSetReceipts.DataSetName = "IACDataSet";
            this.iacDataSetReceipts.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // opnclscustomerTableAdapter
            // 
            this.opnclscustomerTableAdapter.ClearBeforeFill = true;
            // 
            // opndealrTableAdapter
            // 
            this.opndealrTableAdapter.ClearBeforeFill = true;
            // 
            // dealerTableAdapter
            // 
            this.dealerTableAdapter.ClearBeforeFill = true;
            // 
            // textBoxCustomerNo
            // 
            this.textBoxCustomerNo.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bindingSourceCustomer, "CUSTOMER_NO", true));
            this.textBoxCustomerNo.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBoxCustomerNo.Location = new System.Drawing.Point(94, 18);
            this.textBoxCustomerNo.MaxLength = 6;
            this.textBoxCustomerNo.Name = "textBoxCustomerNo";
            this.textBoxCustomerNo.ReadOnly = true;
            this.textBoxCustomerNo.Size = new System.Drawing.Size(77, 23);
            this.textBoxCustomerNo.TabIndex = 0;
            // 
            // bindingSourceCustomer
            // 
            this.bindingSourceCustomer.DataMember = "OPNCLSCUSTOMER";
            this.bindingSourceCustomer.DataSource = this.iacDataSetReceipts;
            // 
            // cUSTOMER_SUFFIXTextBox
            // 
            this.cUSTOMER_SUFFIXTextBox.AllowDrop = true;
            this.cUSTOMER_SUFFIXTextBox.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.cUSTOMER_SUFFIXTextBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bindingSourceCustomer, "CUSTOMER_SUFFIX", true));
            this.cUSTOMER_SUFFIXTextBox.Enabled = false;
            this.cUSTOMER_SUFFIXTextBox.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cUSTOMER_SUFFIXTextBox.Location = new System.Drawing.Point(395, 42);
            this.cUSTOMER_SUFFIXTextBox.MaxLength = 3;
            this.cUSTOMER_SUFFIXTextBox.Name = "cUSTOMER_SUFFIXTextBox";
            this.cUSTOMER_SUFFIXTextBox.ReadOnly = true;
            this.cUSTOMER_SUFFIXTextBox.Size = new System.Drawing.Size(47, 23);
            this.cUSTOMER_SUFFIXTextBox.TabIndex = 6;
            // 
            // cUSTOMER_Add_OnTextBox
            // 
            this.cUSTOMER_Add_OnTextBox.AllowDrop = true;
            this.cUSTOMER_Add_OnTextBox.Enabled = false;
            this.cUSTOMER_Add_OnTextBox.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cUSTOMER_Add_OnTextBox.Location = new System.Drawing.Point(170, 18);
            this.cUSTOMER_Add_OnTextBox.MaxLength = 1;
            this.cUSTOMER_Add_OnTextBox.Name = "cUSTOMER_Add_OnTextBox";
            this.cUSTOMER_Add_OnTextBox.ReadOnly = true;
            this.cUSTOMER_Add_OnTextBox.Size = new System.Drawing.Size(21, 23);
            this.cUSTOMER_Add_OnTextBox.TabIndex = 1;
            // 
            // cUSTOMER_CONTACTTextBox
            // 
            this.cUSTOMER_CONTACTTextBox.AllowDrop = true;
            this.cUSTOMER_CONTACTTextBox.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.cUSTOMER_CONTACTTextBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bindingSourceCustomer, "CUSTOMER_CONTACT", true));
            this.cUSTOMER_CONTACTTextBox.Enabled = false;
            this.cUSTOMER_CONTACTTextBox.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cUSTOMER_CONTACTTextBox.Location = new System.Drawing.Point(94, 66);
            this.cUSTOMER_CONTACTTextBox.MaxLength = 20;
            this.cUSTOMER_CONTACTTextBox.Name = "cUSTOMER_CONTACTTextBox";
            this.cUSTOMER_CONTACTTextBox.ReadOnly = true;
            this.cUSTOMER_CONTACTTextBox.Size = new System.Drawing.Size(179, 23);
            this.cUSTOMER_CONTACTTextBox.TabIndex = 7;
            // 
            // cUSTOMER_ZIP_2TextBox
            // 
            this.cUSTOMER_ZIP_2TextBox.AllowDrop = true;
            this.cUSTOMER_ZIP_2TextBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bindingSourceCustomer, "CUSTOMER_ZIP_2", true));
            this.cUSTOMER_ZIP_2TextBox.Enabled = false;
            this.cUSTOMER_ZIP_2TextBox.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cUSTOMER_ZIP_2TextBox.Location = new System.Drawing.Point(438, 138);
            this.cUSTOMER_ZIP_2TextBox.MaxLength = 4;
            this.cUSTOMER_ZIP_2TextBox.Name = "cUSTOMER_ZIP_2TextBox";
            this.cUSTOMER_ZIP_2TextBox.ReadOnly = true;
            this.cUSTOMER_ZIP_2TextBox.Size = new System.Drawing.Size(60, 23);
            this.cUSTOMER_ZIP_2TextBox.TabIndex = 13;
            this.cUSTOMER_ZIP_2TextBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // cUSTOMER_ZIP_1TextBox
            // 
            this.cUSTOMER_ZIP_1TextBox.AllowDrop = true;
            this.cUSTOMER_ZIP_1TextBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bindingSourceCustomer, "CUSTOMER_ZIP_1", true));
            this.cUSTOMER_ZIP_1TextBox.Enabled = false;
            this.cUSTOMER_ZIP_1TextBox.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cUSTOMER_ZIP_1TextBox.Location = new System.Drawing.Point(378, 138);
            this.cUSTOMER_ZIP_1TextBox.MaxLength = 5;
            this.cUSTOMER_ZIP_1TextBox.Name = "cUSTOMER_ZIP_1TextBox";
            this.cUSTOMER_ZIP_1TextBox.ReadOnly = true;
            this.cUSTOMER_ZIP_1TextBox.Size = new System.Drawing.Size(60, 23);
            this.cUSTOMER_ZIP_1TextBox.TabIndex = 12;
            this.cUSTOMER_ZIP_1TextBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // cUSTOMER_STATETextBox
            // 
            this.cUSTOMER_STATETextBox.AllowDrop = true;
            this.cUSTOMER_STATETextBox.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.cUSTOMER_STATETextBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bindingSourceCustomer, "CUSTOMER_STATE", true));
            this.cUSTOMER_STATETextBox.Enabled = false;
            this.cUSTOMER_STATETextBox.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cUSTOMER_STATETextBox.Location = new System.Drawing.Point(279, 138);
            this.cUSTOMER_STATETextBox.MaxLength = 2;
            this.cUSTOMER_STATETextBox.Name = "cUSTOMER_STATETextBox";
            this.cUSTOMER_STATETextBox.ReadOnly = true;
            this.cUSTOMER_STATETextBox.Size = new System.Drawing.Size(31, 23);
            this.cUSTOMER_STATETextBox.TabIndex = 11;
            // 
            // cUSTOMER_CITYTextBox
            // 
            this.cUSTOMER_CITYTextBox.AllowDrop = true;
            this.cUSTOMER_CITYTextBox.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.cUSTOMER_CITYTextBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bindingSourceCustomer, "CUSTOMER_CITY", true));
            this.cUSTOMER_CITYTextBox.Enabled = false;
            this.cUSTOMER_CITYTextBox.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cUSTOMER_CITYTextBox.Location = new System.Drawing.Point(94, 138);
            this.cUSTOMER_CITYTextBox.MaxLength = 15;
            this.cUSTOMER_CITYTextBox.Name = "cUSTOMER_CITYTextBox";
            this.cUSTOMER_CITYTextBox.ReadOnly = true;
            this.cUSTOMER_CITYTextBox.Size = new System.Drawing.Size(133, 23);
            this.cUSTOMER_CITYTextBox.TabIndex = 10;
            // 
            // cUSTOMER_STREET_2TextBox
            // 
            this.cUSTOMER_STREET_2TextBox.AllowDrop = true;
            this.cUSTOMER_STREET_2TextBox.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.cUSTOMER_STREET_2TextBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bindingSourceCustomer, "CUSTOMER_STREET_2", true));
            this.cUSTOMER_STREET_2TextBox.Enabled = false;
            this.cUSTOMER_STREET_2TextBox.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cUSTOMER_STREET_2TextBox.Location = new System.Drawing.Point(94, 114);
            this.cUSTOMER_STREET_2TextBox.MaxLength = 30;
            this.cUSTOMER_STREET_2TextBox.Name = "cUSTOMER_STREET_2TextBox";
            this.cUSTOMER_STREET_2TextBox.ReadOnly = true;
            this.cUSTOMER_STREET_2TextBox.Size = new System.Drawing.Size(277, 23);
            this.cUSTOMER_STREET_2TextBox.TabIndex = 9;
            // 
            // cUSTOMER_STREET_1TextBox
            // 
            this.cUSTOMER_STREET_1TextBox.AllowDrop = true;
            this.cUSTOMER_STREET_1TextBox.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.cUSTOMER_STREET_1TextBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bindingSourceCustomer, "CUSTOMER_STREET_1", true));
            this.cUSTOMER_STREET_1TextBox.Enabled = false;
            this.cUSTOMER_STREET_1TextBox.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cUSTOMER_STREET_1TextBox.Location = new System.Drawing.Point(94, 90);
            this.cUSTOMER_STREET_1TextBox.MaxLength = 30;
            this.cUSTOMER_STREET_1TextBox.Name = "cUSTOMER_STREET_1TextBox";
            this.cUSTOMER_STREET_1TextBox.ReadOnly = true;
            this.cUSTOMER_STREET_1TextBox.Size = new System.Drawing.Size(277, 23);
            this.cUSTOMER_STREET_1TextBox.TabIndex = 8;
            // 
            // cUSTOMER_LAST_NAMETextBox
            // 
            this.cUSTOMER_LAST_NAMETextBox.AllowDrop = true;
            this.cUSTOMER_LAST_NAMETextBox.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.cUSTOMER_LAST_NAMETextBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bindingSourceCustomer, "CUSTOMER_LAST_NAME", true));
            this.cUSTOMER_LAST_NAMETextBox.Enabled = false;
            this.cUSTOMER_LAST_NAMETextBox.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cUSTOMER_LAST_NAMETextBox.Location = new System.Drawing.Point(218, 42);
            this.cUSTOMER_LAST_NAMETextBox.MaxLength = 18;
            this.cUSTOMER_LAST_NAMETextBox.Name = "cUSTOMER_LAST_NAMETextBox";
            this.cUSTOMER_LAST_NAMETextBox.ReadOnly = true;
            this.cUSTOMER_LAST_NAMETextBox.Size = new System.Drawing.Size(177, 23);
            this.cUSTOMER_LAST_NAMETextBox.TabIndex = 5;
            // 
            // cUSTOMER_FIRST_NAMETextBox
            // 
            this.cUSTOMER_FIRST_NAMETextBox.AllowDrop = true;
            this.cUSTOMER_FIRST_NAMETextBox.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.cUSTOMER_FIRST_NAMETextBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bindingSourceCustomer, "CUSTOMER_FIRST_NAME", true));
            this.cUSTOMER_FIRST_NAMETextBox.Enabled = false;
            this.cUSTOMER_FIRST_NAMETextBox.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cUSTOMER_FIRST_NAMETextBox.ForeColor = System.Drawing.Color.Black;
            this.cUSTOMER_FIRST_NAMETextBox.Location = new System.Drawing.Point(94, 42);
            this.cUSTOMER_FIRST_NAMETextBox.MaxLength = 12;
            this.cUSTOMER_FIRST_NAMETextBox.Name = "cUSTOMER_FIRST_NAMETextBox";
            this.cUSTOMER_FIRST_NAMETextBox.ReadOnly = true;
            this.cUSTOMER_FIRST_NAMETextBox.Size = new System.Drawing.Size(124, 23);
            this.cUSTOMER_FIRST_NAMETextBox.TabIndex = 4;
            // 
            // cUSTOMER_IAC_TypeTextBox
            // 
            this.cUSTOMER_IAC_TypeTextBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bindingSourceCustomer, "CUSTOMER_IAC_TYPE", true));
            this.cUSTOMER_IAC_TypeTextBox.Enabled = false;
            this.cUSTOMER_IAC_TypeTextBox.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cUSTOMER_IAC_TypeTextBox.Location = new System.Drawing.Point(197, 18);
            this.cUSTOMER_IAC_TypeTextBox.MaxLength = 1;
            this.cUSTOMER_IAC_TypeTextBox.Name = "cUSTOMER_IAC_TypeTextBox";
            this.cUSTOMER_IAC_TypeTextBox.ReadOnly = true;
            this.cUSTOMER_IAC_TypeTextBox.Size = new System.Drawing.Size(21, 23);
            this.cUSTOMER_IAC_TypeTextBox.TabIndex = 2;
            // 
            // labelCustomer
            // 
            this.labelCustomer.AutoSize = true;
            this.labelCustomer.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelCustomer.ForeColor = System.Drawing.Color.Black;
            this.labelCustomer.Location = new System.Drawing.Point(16, 26);
            this.labelCustomer.Name = "labelCustomer";
            this.labelCustomer.Size = new System.Drawing.Size(74, 15);
            this.labelCustomer.TabIndex = 27;
            this.labelCustomer.Text = "CUSTOMER:";
            // 
            // labelName
            // 
            this.labelName.AutoSize = true;
            this.labelName.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelName.ForeColor = System.Drawing.Color.Black;
            this.labelName.Location = new System.Drawing.Point(46, 50);
            this.labelName.Name = "labelName";
            this.labelName.Size = new System.Drawing.Size(44, 15);
            this.labelName.TabIndex = 28;
            this.labelName.Text = "NAME:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.Black;
            this.label1.Location = new System.Drawing.Point(59, 74);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(31, 15);
            this.label1.TabIndex = 29;
            this.label1.Text = "C/O:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.Black;
            this.label2.Location = new System.Drawing.Point(11, 98);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(79, 15);
            this.label2.TabIndex = 30;
            this.label2.Text = "ADDRESS -1:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.Black;
            this.label3.Location = new System.Drawing.Point(11, 122);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(79, 15);
            this.label3.TabIndex = 31;
            this.label3.Text = "ADDRESS -2:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.Color.Black;
            this.label4.Location = new System.Drawing.Point(55, 146);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(35, 15);
            this.label4.TabIndex = 32;
            this.label4.Text = "CITY:";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.ForeColor = System.Drawing.Color.Black;
            this.label5.Location = new System.Drawing.Point(231, 146);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(43, 15);
            this.label5.TabIndex = 33;
            this.label5.Text = "STATE:";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.ForeColor = System.Drawing.Color.Black;
            this.label6.Location = new System.Drawing.Point(344, 146);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(28, 15);
            this.label6.TabIndex = 34;
            this.label6.Text = "ZIP:";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.ForeColor = System.Drawing.Color.Black;
            this.label7.Location = new System.Drawing.Point(37, 179);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(53, 15);
            this.label7.TabIndex = 35;
            this.label7.Text = "DEALER:";
            // 
            // textBoxDealerName
            // 
            this.textBoxDealerName.Enabled = false;
            this.textBoxDealerName.Location = new System.Drawing.Point(148, 171);
            this.textBoxDealerName.Name = "textBoxDealerName";
            this.textBoxDealerName.ReadOnly = true;
            this.textBoxDealerName.Size = new System.Drawing.Size(256, 20);
            this.textBoxDealerName.TabIndex = 15;
            // 
            // textBoxDealerAccNo
            // 
            this.textBoxDealerAccNo.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bindingSourceCustomer, "CUSTOMER_DEALER", true));
            this.textBoxDealerAccNo.Enabled = false;
            this.textBoxDealerAccNo.Location = new System.Drawing.Point(94, 171);
            this.textBoxDealerAccNo.MaxLength = 3;
            this.textBoxDealerAccNo.Name = "textBoxDealerAccNo";
            this.textBoxDealerAccNo.ReadOnly = true;
            this.textBoxDealerAccNo.Size = new System.Drawing.Size(52, 20);
            this.textBoxDealerAccNo.TabIndex = 14;
            this.textBoxDealerAccNo.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.ForeColor = System.Drawing.Color.Black;
            this.label8.Location = new System.Drawing.Point(410, 179);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(40, 15);
            this.label8.TabIndex = 98;
            this.label8.Text = "USER:";
            // 
            // ulistTableAdapter
            // 
            this.ulistTableAdapter.ClearBeforeFill = true;
            // 
            // textBoxUserName
            // 
            this.textBoxUserName.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.iacDataSetReceipts, "ULIST.LIST_NAME", true));
            this.textBoxUserName.Enabled = false;
            this.textBoxUserName.Location = new System.Drawing.Point(508, 171);
            this.textBoxUserName.Name = "textBoxUserName";
            this.textBoxUserName.ReadOnly = true;
            this.textBoxUserName.Size = new System.Drawing.Size(256, 20);
            this.textBoxUserName.TabIndex = 17;
            // 
            // textBoxUserID
            // 
            this.textBoxUserID.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.iacDataSetReceipts, "ULIST.LIST_ID", true));
            this.textBoxUserID.Enabled = false;
            this.textBoxUserID.Location = new System.Drawing.Point(454, 171);
            this.textBoxUserID.MaxLength = 3;
            this.textBoxUserID.Name = "textBoxUserID";
            this.textBoxUserID.ReadOnly = true;
            this.textBoxUserID.Size = new System.Drawing.Size(52, 20);
            this.textBoxUserID.TabIndex = 16;
            this.textBoxUserID.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.ForeColor = System.Drawing.Color.Black;
            this.label9.Location = new System.Drawing.Point(573, 26);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(109, 15);
            this.label9.TabIndex = 101;
            this.label9.Text = "RECEIPT NUMBER:";
            // 
            // textBoxOldReceiptNumber
            // 
            this.textBoxOldReceiptNumber.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bindingSourceReceipt, "OldReceipt", true));
            this.textBoxOldReceiptNumber.Enabled = false;
            this.textBoxOldReceiptNumber.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBoxOldReceiptNumber.Location = new System.Drawing.Point(687, 18);
            this.textBoxOldReceiptNumber.MaxLength = 6;
            this.textBoxOldReceiptNumber.Name = "textBoxOldReceiptNumber";
            this.textBoxOldReceiptNumber.ReadOnly = true;
            this.textBoxOldReceiptNumber.Size = new System.Drawing.Size(77, 23);
            this.textBoxOldReceiptNumber.TabIndex = 3;
            // 
            // bindingSourceReceipt
            // 
            this.bindingSourceReceipt.DataMember = "Receipt";
            this.bindingSourceReceipt.DataSource = this.iacDataSetReceipts;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.textBoxOldReceiptNumber);
            this.groupBox1.Controls.Add(this.label9);
            this.groupBox1.Controls.Add(this.textBoxUserName);
            this.groupBox1.Controls.Add(this.textBoxUserID);
            this.groupBox1.Controls.Add(this.label8);
            this.groupBox1.Controls.Add(this.textBoxDealerName);
            this.groupBox1.Controls.Add(this.textBoxDealerAccNo);
            this.groupBox1.Controls.Add(this.label7);
            this.groupBox1.Controls.Add(this.label6);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.labelName);
            this.groupBox1.Controls.Add(this.labelCustomer);
            this.groupBox1.Controls.Add(this.cUSTOMER_SUFFIXTextBox);
            this.groupBox1.Controls.Add(this.cUSTOMER_Add_OnTextBox);
            this.groupBox1.Controls.Add(this.cUSTOMER_CONTACTTextBox);
            this.groupBox1.Controls.Add(this.cUSTOMER_ZIP_2TextBox);
            this.groupBox1.Controls.Add(this.cUSTOMER_ZIP_1TextBox);
            this.groupBox1.Controls.Add(this.cUSTOMER_STATETextBox);
            this.groupBox1.Controls.Add(this.cUSTOMER_CITYTextBox);
            this.groupBox1.Controls.Add(this.cUSTOMER_STREET_2TextBox);
            this.groupBox1.Controls.Add(this.cUSTOMER_STREET_1TextBox);
            this.groupBox1.Controls.Add(this.cUSTOMER_LAST_NAMETextBox);
            this.groupBox1.Controls.Add(this.cUSTOMER_FIRST_NAMETextBox);
            this.groupBox1.Controls.Add(this.cUSTOMER_IAC_TypeTextBox);
            this.groupBox1.Controls.Add(this.textBoxCustomerNo);
            this.groupBox1.Location = new System.Drawing.Point(8, 3);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(774, 215);
            this.groupBox1.TabIndex = 103;
            this.groupBox1.TabStop = false;
            // 
            // toolStrip1
            // 
            this.toolStrip1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripButtonEdit,
            this.toolStripButtonDelete,
            this.toolStripButtonSave});
            this.toolStrip1.Location = new System.Drawing.Point(0, 729);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(790, 25);
            this.toolStrip1.TabIndex = 104;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // toolStripButtonEdit
            // 
            this.toolStripButtonEdit.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.toolStripButtonEdit.Enabled = false;
            this.toolStripButtonEdit.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButtonEdit.Image")));
            this.toolStripButtonEdit.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButtonEdit.Name = "toolStripButtonEdit";
            this.toolStripButtonEdit.Size = new System.Drawing.Size(47, 22);
            this.toolStripButtonEdit.Text = "&Edit";
            // 
            // toolStripButtonDelete
            // 
            this.toolStripButtonDelete.BackColor = System.Drawing.Color.MistyRose;
            this.toolStripButtonDelete.Enabled = false;
            this.toolStripButtonDelete.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButtonDelete.Image")));
            this.toolStripButtonDelete.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButtonDelete.Name = "toolStripButtonDelete";
            this.toolStripButtonDelete.Size = new System.Drawing.Size(60, 22);
            this.toolStripButtonDelete.Text = "&Delete";
            // 
            // toolStripButtonSave
            // 
            this.toolStripButtonSave.BackColor = System.Drawing.Color.LightYellow;
            this.toolStripButtonSave.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButtonSave.Image")));
            this.toolStripButtonSave.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButtonSave.Name = "toolStripButtonSave";
            this.toolStripButtonSave.Size = new System.Drawing.Size(51, 22);
            this.toolStripButtonSave.Text = "&Save";
            // 
            // bindingSourceORECEIPT
            // 
            this.bindingSourceORECEIPT.DataMember = "ORECEIPT";
            this.bindingSourceORECEIPT.DataSource = this.iacDataSetReceipts;
            // 
            // oRECEIPTTableAdapter
            // 
            this.oRECEIPTTableAdapter.ClearBeforeFill = true;
            // 
            // textBoxAmountPaid
            // 
            this.textBoxAmountPaid.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bindingSourceReceipt, "PaidAmount", true, System.Windows.Forms.DataSourceUpdateMode.OnValidation, null, "C2"));
            this.textBoxAmountPaid.Location = new System.Drawing.Point(20, 32);
            this.textBoxAmountPaid.Name = "textBoxAmountPaid";
            this.textBoxAmountPaid.Size = new System.Drawing.Size(100, 20);
            this.textBoxAmountPaid.TabIndex = 18;
            this.textBoxAmountPaid.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // labelAmountPaid
            // 
            this.labelAmountPaid.AutoSize = true;
            this.labelAmountPaid.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelAmountPaid.Location = new System.Drawing.Point(9, 12);
            this.labelAmountPaid.Name = "labelAmountPaid";
            this.labelAmountPaid.Size = new System.Drawing.Size(78, 15);
            this.labelAmountPaid.TabIndex = 110;
            this.labelAmountPaid.Text = "Amount Paid";
            // 
            // textBoxCashTendered
            // 
            this.textBoxCashTendered.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bindingSourceReceipt, "CashTendered", true, System.Windows.Forms.DataSourceUpdateMode.OnValidation, null, "C2"));
            this.textBoxCashTendered.Enabled = false;
            this.textBoxCashTendered.Location = new System.Drawing.Point(20, 80);
            this.textBoxCashTendered.Name = "textBoxCashTendered";
            this.textBoxCashTendered.Size = new System.Drawing.Size(100, 20);
            this.textBoxCashTendered.TabIndex = 19;
            this.textBoxCashTendered.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label10.Location = new System.Drawing.Point(9, 60);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(88, 15);
            this.label10.TabIndex = 112;
            this.label10.Text = "Cash Tendered";
            // 
            // textBox100s
            // 
            this.textBox100s.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bindingSourceReceipt, "Cash100", true, System.Windows.Forms.DataSourceUpdateMode.OnValidation, null, "N0"));
            this.textBox100s.Enabled = false;
            this.textBox100s.Location = new System.Drawing.Point(8, 80);
            this.textBox100s.Name = "textBox100s";
            this.textBox100s.Size = new System.Drawing.Size(50, 20);
            this.textBox100s.TabIndex = 20;
            this.textBox100s.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.textBox100s.Validated += new System.EventHandler(this.textBox100s_Validated);
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label11.Location = new System.Drawing.Point(8, 60);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(33, 15);
            this.label11.TabIndex = 114;
            this.label11.Text = "100s";
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label12.Location = new System.Drawing.Point(66, 60);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(26, 15);
            this.label12.TabIndex = 116;
            this.label12.Text = "50s";
            // 
            // textBox50s
            // 
            this.textBox50s.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bindingSourceReceipt, "Cash50", true, System.Windows.Forms.DataSourceUpdateMode.OnValidation, null, "N0"));
            this.textBox50s.Enabled = false;
            this.textBox50s.Location = new System.Drawing.Point(66, 80);
            this.textBox50s.Name = "textBox50s";
            this.textBox50s.Size = new System.Drawing.Size(50, 20);
            this.textBox50s.TabIndex = 21;
            this.textBox50s.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.textBox50s.Validated += new System.EventHandler(this.textBox50s_Validated);
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label13.Location = new System.Drawing.Point(124, 60);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(26, 15);
            this.label13.TabIndex = 118;
            this.label13.Text = "20s";
            // 
            // textBox20s
            // 
            this.textBox20s.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bindingSourceReceipt, "Cash20", true, System.Windows.Forms.DataSourceUpdateMode.OnValidation, null, "N0"));
            this.textBox20s.Enabled = false;
            this.textBox20s.Location = new System.Drawing.Point(124, 80);
            this.textBox20s.Name = "textBox20s";
            this.textBox20s.Size = new System.Drawing.Size(50, 20);
            this.textBox20s.TabIndex = 22;
            this.textBox20s.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.textBox20s.Validated += new System.EventHandler(this.textBox20s_Validated);
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label14.Location = new System.Drawing.Point(240, 60);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(19, 15);
            this.label14.TabIndex = 120;
            this.label14.Text = "5s";
            // 
            // textBox5s
            // 
            this.textBox5s.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bindingSourceReceipt, "Cash5", true, System.Windows.Forms.DataSourceUpdateMode.OnValidation, null, "N0"));
            this.textBox5s.Enabled = false;
            this.textBox5s.Location = new System.Drawing.Point(240, 80);
            this.textBox5s.Name = "textBox5s";
            this.textBox5s.Size = new System.Drawing.Size(50, 20);
            this.textBox5s.TabIndex = 24;
            this.textBox5s.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.textBox5s.Validated += new System.EventHandler(this.textBox5s_Validated);
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label15.Location = new System.Drawing.Point(298, 60);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(19, 15);
            this.label15.TabIndex = 122;
            this.label15.Text = "1s";
            // 
            // textBox1s
            // 
            this.textBox1s.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bindingSourceReceipt, "Cash1", true, System.Windows.Forms.DataSourceUpdateMode.OnValidation, null, "N0"));
            this.textBox1s.Enabled = false;
            this.textBox1s.Location = new System.Drawing.Point(298, 80);
            this.textBox1s.Name = "textBox1s";
            this.textBox1s.Size = new System.Drawing.Size(50, 20);
            this.textBox1s.TabIndex = 25;
            this.textBox1s.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.textBox1s.Validated += new System.EventHandler(this.textBox1s_Validated);
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label16.Location = new System.Drawing.Point(354, 60);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(61, 15);
            this.label16.TabIndex = 124;
            this.label16.Text = "Coin Total";
            // 
            // textBoxCoins
            // 
            this.textBoxCoins.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bindingSourceReceipt, "CashCoins", true, System.Windows.Forms.DataSourceUpdateMode.OnValidation, null, "C2"));
            this.textBoxCoins.Enabled = false;
            this.textBoxCoins.Location = new System.Drawing.Point(354, 80);
            this.textBoxCoins.Name = "textBoxCoins";
            this.textBoxCoins.Size = new System.Drawing.Size(84, 20);
            this.textBoxCoins.TabIndex = 26;
            this.textBoxCoins.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.textBoxCoins.Validated += new System.EventHandler(this.textBoxCoins_Validated);
            // 
            // label17
            // 
            this.label17.AutoSize = true;
            this.label17.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label17.Location = new System.Drawing.Point(9, 204);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(127, 15);
            this.label17.TabIndex = 126;
            this.label17.Text = "Credit Card Amount 1";
            // 
            // textBoxCreditCardAmount1
            // 
            this.textBoxCreditCardAmount1.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bindingSourceReceipt, "CreditCardAmount1", true, System.Windows.Forms.DataSourceUpdateMode.OnValidation, null, "C2"));
            this.textBoxCreditCardAmount1.Enabled = false;
            this.textBoxCreditCardAmount1.Location = new System.Drawing.Point(20, 224);
            this.textBoxCreditCardAmount1.Name = "textBoxCreditCardAmount1";
            this.textBoxCreditCardAmount1.Size = new System.Drawing.Size(100, 20);
            this.textBoxCreditCardAmount1.TabIndex = 33;
            this.textBoxCreditCardAmount1.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // label18
            // 
            this.label18.AutoSize = true;
            this.label18.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label18.Location = new System.Drawing.Point(9, 108);
            this.label18.Name = "label18";
            this.label18.Size = new System.Drawing.Size(89, 15);
            this.label18.TabIndex = 128;
            this.label18.Text = "Check Amount";
            // 
            // textBoxCheckAmount
            // 
            this.textBoxCheckAmount.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bindingSourceReceipt, "CheckAmount", true, System.Windows.Forms.DataSourceUpdateMode.OnValidation, null, "C2"));
            this.textBoxCheckAmount.Enabled = false;
            this.textBoxCheckAmount.Location = new System.Drawing.Point(20, 128);
            this.textBoxCheckAmount.Name = "textBoxCheckAmount";
            this.textBoxCheckAmount.Size = new System.Drawing.Size(100, 20);
            this.textBoxCheckAmount.TabIndex = 27;
            this.textBoxCheckAmount.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.textBoxCheckAmount.Validated += new System.EventHandler(this.textBoxCheckAmount_Validated);
            // 
            // textBoxCheckNumber
            // 
            this.textBoxCheckNumber.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bindingSourceReceipt, "CheckNo", true));
            this.textBoxCheckNumber.Enabled = false;
            this.textBoxCheckNumber.Location = new System.Drawing.Point(8, 128);
            this.textBoxCheckNumber.Name = "textBoxCheckNumber";
            this.textBoxCheckNumber.Size = new System.Drawing.Size(100, 20);
            this.textBoxCheckNumber.TabIndex = 28;
            // 
            // label19
            // 
            this.label19.AutoSize = true;
            this.label19.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label19.Location = new System.Drawing.Point(8, 108);
            this.label19.Name = "label19";
            this.label19.Size = new System.Drawing.Size(90, 15);
            this.label19.TabIndex = 130;
            this.label19.Text = "Check Number";
            // 
            // label20
            // 
            this.label20.AutoSize = true;
            this.label20.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label20.Location = new System.Drawing.Point(8, 156);
            this.label20.Name = "label20";
            this.label20.Size = new System.Drawing.Size(130, 15);
            this.label20.TabIndex = 134;
            this.label20.Text = "Money Order Number";
            // 
            // textBoxMoneyOrderNumber
            // 
            this.textBoxMoneyOrderNumber.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bindingSourceReceipt, "MoneyOrderNo", true));
            this.textBoxMoneyOrderNumber.Enabled = false;
            this.textBoxMoneyOrderNumber.Location = new System.Drawing.Point(8, 176);
            this.textBoxMoneyOrderNumber.Name = "textBoxMoneyOrderNumber";
            this.textBoxMoneyOrderNumber.Size = new System.Drawing.Size(100, 20);
            this.textBoxMoneyOrderNumber.TabIndex = 32;
            // 
            // label21
            // 
            this.label21.AutoSize = true;
            this.label21.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label21.Location = new System.Drawing.Point(9, 156);
            this.label21.Name = "label21";
            this.label21.Size = new System.Drawing.Size(129, 15);
            this.label21.TabIndex = 132;
            this.label21.Text = "Money Order Amount";
            // 
            // textBoxMoneyOrderAmount
            // 
            this.textBoxMoneyOrderAmount.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bindingSourceReceipt, "MoneyOrderAmount", true, System.Windows.Forms.DataSourceUpdateMode.OnValidation, null, "C2"));
            this.textBoxMoneyOrderAmount.Enabled = false;
            this.textBoxMoneyOrderAmount.Location = new System.Drawing.Point(20, 176);
            this.textBoxMoneyOrderAmount.Name = "textBoxMoneyOrderAmount";
            this.textBoxMoneyOrderAmount.Size = new System.Drawing.Size(100, 20);
            this.textBoxMoneyOrderAmount.TabIndex = 31;
            this.textBoxMoneyOrderAmount.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // buttonCreditCard
            // 
            this.buttonCreditCard.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.buttonCreditCard.Image = global::IAC2021SQL.Properties.Resources.CreditCardLogos;
            this.buttonCreditCard.Location = new System.Drawing.Point(11, 216);
            this.buttonCreditCard.Name = "buttonCreditCard";
            this.buttonCreditCard.Size = new System.Drawing.Size(133, 95);
            this.buttonCreditCard.TabIndex = 60;
            this.buttonCreditCard.UseVisualStyleBackColor = true;
            this.buttonCreditCard.Click += new System.EventHandler(this.buttonCreditCard_Click);
            // 
            // buttonMoneyOrder
            // 
            this.buttonMoneyOrder.Location = new System.Drawing.Point(11, 170);
            this.buttonMoneyOrder.Name = "buttonMoneyOrder";
            this.buttonMoneyOrder.Size = new System.Drawing.Size(133, 40);
            this.buttonMoneyOrder.TabIndex = 59;
            this.buttonMoneyOrder.Text = "&Money Order";
            this.buttonMoneyOrder.UseVisualStyleBackColor = true;
            this.buttonMoneyOrder.Click += new System.EventHandler(this.buttonMoneyOrder_Click);
            // 
            // buttonCheck
            // 
            this.buttonCheck.Location = new System.Drawing.Point(11, 124);
            this.buttonCheck.Name = "buttonCheck";
            this.buttonCheck.Size = new System.Drawing.Size(133, 40);
            this.buttonCheck.TabIndex = 58;
            this.buttonCheck.Text = "&Check";
            this.buttonCheck.UseVisualStyleBackColor = true;
            this.buttonCheck.Click += new System.EventHandler(this.buttonCheck_Click);
            // 
            // buttonCash
            // 
            this.buttonCash.Location = new System.Drawing.Point(11, 78);
            this.buttonCash.Name = "buttonCash";
            this.buttonCash.Size = new System.Drawing.Size(133, 40);
            this.buttonCash.TabIndex = 57;
            this.buttonCash.Text = "C&ash";
            this.buttonCash.UseVisualStyleBackColor = true;
            this.buttonCash.Click += new System.EventHandler(this.buttonCash_Click);
            // 
            // groupBoxAmounts
            // 
            this.groupBoxAmounts.Controls.Add(this.label25);
            this.groupBoxAmounts.Controls.Add(this.textBoxCreditCardAmount3);
            this.groupBoxAmounts.Controls.Add(this.label24);
            this.groupBoxAmounts.Controls.Add(this.textBoxCreditCardAmount2);
            this.groupBoxAmounts.Controls.Add(this.label21);
            this.groupBoxAmounts.Controls.Add(this.textBoxMoneyOrderAmount);
            this.groupBoxAmounts.Controls.Add(this.label18);
            this.groupBoxAmounts.Controls.Add(this.textBoxCheckAmount);
            this.groupBoxAmounts.Controls.Add(this.label17);
            this.groupBoxAmounts.Controls.Add(this.textBoxCreditCardAmount1);
            this.groupBoxAmounts.Controls.Add(this.label10);
            this.groupBoxAmounts.Controls.Add(this.textBoxCashTendered);
            this.groupBoxAmounts.Controls.Add(this.labelAmountPaid);
            this.groupBoxAmounts.Controls.Add(this.textBoxAmountPaid);
            this.groupBoxAmounts.Location = new System.Drawing.Point(26, 221);
            this.groupBoxAmounts.Name = "groupBoxAmounts";
            this.groupBoxAmounts.Size = new System.Drawing.Size(143, 365);
            this.groupBoxAmounts.TabIndex = 139;
            this.groupBoxAmounts.TabStop = false;
            // 
            // label25
            // 
            this.label25.AutoSize = true;
            this.label25.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label25.Location = new System.Drawing.Point(9, 300);
            this.label25.Name = "label25";
            this.label25.Size = new System.Drawing.Size(127, 15);
            this.label25.TabIndex = 136;
            this.label25.Text = "Credit Card Amount 3";
            // 
            // textBoxCreditCardAmount3
            // 
            this.textBoxCreditCardAmount3.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bindingSourceReceipt, "CreditCardAmount3", true, System.Windows.Forms.DataSourceUpdateMode.OnValidation, null, "C2"));
            this.textBoxCreditCardAmount3.Enabled = false;
            this.textBoxCreditCardAmount3.Location = new System.Drawing.Point(20, 320);
            this.textBoxCreditCardAmount3.Name = "textBoxCreditCardAmount3";
            this.textBoxCreditCardAmount3.Size = new System.Drawing.Size(100, 20);
            this.textBoxCreditCardAmount3.TabIndex = 47;
            this.textBoxCreditCardAmount3.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // label24
            // 
            this.label24.AutoSize = true;
            this.label24.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label24.Location = new System.Drawing.Point(9, 252);
            this.label24.Name = "label24";
            this.label24.Size = new System.Drawing.Size(127, 15);
            this.label24.TabIndex = 134;
            this.label24.Text = "Credit Card Amount 2";
            // 
            // textBoxCreditCardAmount2
            // 
            this.textBoxCreditCardAmount2.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bindingSourceReceipt, "CreditCardAmount2", true, System.Windows.Forms.DataSourceUpdateMode.OnValidation, null, "C2"));
            this.textBoxCreditCardAmount2.Enabled = false;
            this.textBoxCreditCardAmount2.Location = new System.Drawing.Point(20, 272);
            this.textBoxCreditCardAmount2.Name = "textBoxCreditCardAmount2";
            this.textBoxCreditCardAmount2.Size = new System.Drawing.Size(100, 20);
            this.textBoxCreditCardAmount2.TabIndex = 40;
            this.textBoxCreditCardAmount2.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // groupBoxCounts
            // 
            this.groupBoxCounts.Controls.Add(this.label10s);
            this.groupBoxCounts.Controls.Add(this.textBox10s);
            this.groupBoxCounts.Controls.Add(this.label23);
            this.groupBoxCounts.Controls.Add(this.nullableDateTimePickerHoldDate);
            this.groupBoxCounts.Controls.Add(this.checkBoxHold);
            this.groupBoxCounts.Controls.Add(this.label35);
            this.groupBoxCounts.Controls.Add(this.label36);
            this.groupBoxCounts.Controls.Add(this.label37);
            this.groupBoxCounts.Controls.Add(this.label38);
            this.groupBoxCounts.Controls.Add(this.textBoxCreditCardApproval3);
            this.groupBoxCounts.Controls.Add(this.textBoxCreditCardType3);
            this.groupBoxCounts.Controls.Add(this.textBoxExpDateYear3);
            this.groupBoxCounts.Controls.Add(this.textBoxExpDateMonth3);
            this.groupBoxCounts.Controls.Add(this.textBoxCreditCardSecurityCode3);
            this.groupBoxCounts.Controls.Add(this.labelCreditCard3);
            this.groupBoxCounts.Controls.Add(this.textBoxCreditCardNumber3);
            this.groupBoxCounts.Controls.Add(this.label30);
            this.groupBoxCounts.Controls.Add(this.label31);
            this.groupBoxCounts.Controls.Add(this.label32);
            this.groupBoxCounts.Controls.Add(this.label33);
            this.groupBoxCounts.Controls.Add(this.textBoxCreditCardApproval2);
            this.groupBoxCounts.Controls.Add(this.textBoxCreditCardType2);
            this.groupBoxCounts.Controls.Add(this.textBoxExpDateYear2);
            this.groupBoxCounts.Controls.Add(this.textBoxExpDateMonth2);
            this.groupBoxCounts.Controls.Add(this.textBoxCreditCardSecurityCode2);
            this.groupBoxCounts.Controls.Add(this.labelCreditCard2);
            this.groupBoxCounts.Controls.Add(this.textBoxCreditCardNumber2);
            this.groupBoxCounts.Controls.Add(this.label29);
            this.groupBoxCounts.Controls.Add(this.label28);
            this.groupBoxCounts.Controls.Add(this.label27);
            this.groupBoxCounts.Controls.Add(this.label26);
            this.groupBoxCounts.Controls.Add(this.textBoxCreditCardApproval1);
            this.groupBoxCounts.Controls.Add(this.textBoxCreditCardType1);
            this.groupBoxCounts.Controls.Add(this.textBoxExpDateYear1);
            this.groupBoxCounts.Controls.Add(this.textBoxExpDateMonth1);
            this.groupBoxCounts.Controls.Add(this.textBoxCreditCardSecurityCode1);
            this.groupBoxCounts.Controls.Add(this.labelCreditCard1);
            this.groupBoxCounts.Controls.Add(this.textBoxCreditCardNumber1);
            this.groupBoxCounts.Controls.Add(this.label20);
            this.groupBoxCounts.Controls.Add(this.textBoxMoneyOrderNumber);
            this.groupBoxCounts.Controls.Add(this.label19);
            this.groupBoxCounts.Controls.Add(this.textBoxCheckNumber);
            this.groupBoxCounts.Controls.Add(this.label16);
            this.groupBoxCounts.Controls.Add(this.textBoxCoins);
            this.groupBoxCounts.Controls.Add(this.label15);
            this.groupBoxCounts.Controls.Add(this.textBox1s);
            this.groupBoxCounts.Controls.Add(this.label14);
            this.groupBoxCounts.Controls.Add(this.textBox5s);
            this.groupBoxCounts.Controls.Add(this.label13);
            this.groupBoxCounts.Controls.Add(this.textBox20s);
            this.groupBoxCounts.Controls.Add(this.label12);
            this.groupBoxCounts.Controls.Add(this.textBox50s);
            this.groupBoxCounts.Controls.Add(this.label11);
            this.groupBoxCounts.Controls.Add(this.textBox100s);
            this.groupBoxCounts.Location = new System.Drawing.Point(167, 221);
            this.groupBoxCounts.Name = "groupBoxCounts";
            this.groupBoxCounts.Size = new System.Drawing.Size(443, 365);
            this.groupBoxCounts.TabIndex = 140;
            this.groupBoxCounts.TabStop = false;
            // 
            // label10s
            // 
            this.label10s.AutoSize = true;
            this.label10s.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label10s.Location = new System.Drawing.Point(182, 60);
            this.label10s.Name = "label10s";
            this.label10s.Size = new System.Drawing.Size(26, 15);
            this.label10s.TabIndex = 187;
            this.label10s.Text = "10s";
            // 
            // textBox10s
            // 
            this.textBox10s.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bindingSourceReceipt, "Cash10", true, System.Windows.Forms.DataSourceUpdateMode.OnValidation, null, "N0"));
            this.textBox10s.Enabled = false;
            this.textBox10s.Location = new System.Drawing.Point(182, 80);
            this.textBox10s.Name = "textBox10s";
            this.textBox10s.Size = new System.Drawing.Size(50, 20);
            this.textBox10s.TabIndex = 23;
            this.textBox10s.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.textBox10s.Validated += new System.EventHandler(this.textBox10s_Validated);
            // 
            // label23
            // 
            this.label23.AutoSize = true;
            this.label23.Enabled = false;
            this.label23.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label23.Location = new System.Drawing.Point(257, 108);
            this.label23.Name = "label23";
            this.label23.Size = new System.Drawing.Size(60, 15);
            this.label23.TabIndex = 185;
            this.label23.Text = "HoldDate";
            // 
            // nullableDateTimePickerHoldDate
            // 
            this.nullableDateTimePickerHoldDate.DataBindings.Add(new System.Windows.Forms.Binding("Value", this.bindingSourceReceipt, "HoldDate", true, System.Windows.Forms.DataSourceUpdateMode.OnValidation, null, "d"));
            this.nullableDateTimePickerHoldDate.Enabled = false;
            this.nullableDateTimePickerHoldDate.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.nullableDateTimePickerHoldDate.Location = new System.Drawing.Point(257, 128);
            this.nullableDateTimePickerHoldDate.Name = "nullableDateTimePickerHoldDate";
            this.nullableDateTimePickerHoldDate.Size = new System.Drawing.Size(81, 20);
            this.nullableDateTimePickerHoldDate.TabIndex = 30;
            this.nullableDateTimePickerHoldDate.Value = new System.DateTime(2013, 9, 17, 0, 0, 0, 0);
            // 
            // checkBoxHold
            // 
            this.checkBoxHold.AutoSize = true;
            this.checkBoxHold.DataBindings.Add(new System.Windows.Forms.Binding("CheckState", this.bindingSourceReceipt, "Hold", true));
            this.checkBoxHold.Enabled = false;
            this.checkBoxHold.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.checkBoxHold.Location = new System.Drawing.Point(138, 132);
            this.checkBoxHold.Name = "checkBoxHold";
            this.checkBoxHold.Size = new System.Drawing.Size(94, 19);
            this.checkBoxHold.TabIndex = 29;
            this.checkBoxHold.Text = "Hold Check?";
            this.checkBoxHold.UseVisualStyleBackColor = true;
            this.checkBoxHold.CheckedChanged += new System.EventHandler(this.checkBoxHold_CheckedChanged);
            // 
            // label35
            // 
            this.label35.AutoSize = true;
            this.label35.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label35.Location = new System.Drawing.Point(338, 300);
            this.label35.Name = "label35";
            this.label35.Size = new System.Drawing.Size(79, 15);
            this.label35.TabIndex = 169;
            this.label35.Text = "Approval No.";
            // 
            // label36
            // 
            this.label36.AutoSize = true;
            this.label36.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label36.Location = new System.Drawing.Point(266, 300);
            this.label36.Name = "label36";
            this.label36.Size = new System.Drawing.Size(33, 15);
            this.label36.TabIndex = 168;
            this.label36.Text = "Type";
            // 
            // label37
            // 
            this.label37.AutoSize = true;
            this.label37.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label37.Location = new System.Drawing.Point(180, 300);
            this.label37.Name = "label37";
            this.label37.Size = new System.Drawing.Size(86, 15);
            this.label37.TabIndex = 167;
            this.label37.Text = "EXP MM/YYYY";
            // 
            // label38
            // 
            this.label38.AutoSize = true;
            this.label38.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label38.Location = new System.Drawing.Point(116, 300);
            this.label38.Name = "label38";
            this.label38.Size = new System.Drawing.Size(58, 15);
            this.label38.TabIndex = 166;
            this.label38.Text = "SEC Code";
            // 
            // textBoxCreditCardApproval3
            // 
            this.textBoxCreditCardApproval3.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bindingSourceReceipt, "CreditCardApproval3", true));
            this.textBoxCreditCardApproval3.Enabled = false;
            this.textBoxCreditCardApproval3.Location = new System.Drawing.Point(338, 320);
            this.textBoxCreditCardApproval3.MaxLength = 16;
            this.textBoxCreditCardApproval3.Name = "textBoxCreditCardApproval3";
            this.textBoxCreditCardApproval3.Size = new System.Drawing.Size(100, 20);
            this.textBoxCreditCardApproval3.TabIndex = 53;
            // 
            // textBoxCreditCardType3
            // 
            this.textBoxCreditCardType3.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bindingSourceReceipt, "CreditCardType3", true));
            this.textBoxCreditCardType3.Enabled = false;
            this.textBoxCreditCardType3.Location = new System.Drawing.Point(266, 320);
            this.textBoxCreditCardType3.Name = "textBoxCreditCardType3";
            this.textBoxCreditCardType3.Size = new System.Drawing.Size(67, 20);
            this.textBoxCreditCardType3.TabIndex = 52;
            // 
            // textBoxExpDateYear3
            // 
            this.textBoxExpDateYear3.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bindingSourceReceipt, "CreditCardExpirationDateYear3", true, System.Windows.Forms.DataSourceUpdateMode.OnValidation, null, "N0"));
            this.textBoxExpDateYear3.Enabled = false;
            this.textBoxExpDateYear3.Location = new System.Drawing.Point(210, 320);
            this.textBoxExpDateYear3.MaxLength = 4;
            this.textBoxExpDateYear3.Name = "textBoxExpDateYear3";
            this.textBoxExpDateYear3.Size = new System.Drawing.Size(44, 20);
            this.textBoxExpDateYear3.TabIndex = 51;
            this.textBoxExpDateYear3.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // textBoxExpDateMonth3
            // 
            this.textBoxExpDateMonth3.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bindingSourceReceipt, "CreditCardExpirationDateYear3", true, System.Windows.Forms.DataSourceUpdateMode.OnValidation, null, "N0"));
            this.textBoxExpDateMonth3.Enabled = false;
            this.textBoxExpDateMonth3.Location = new System.Drawing.Point(180, 320);
            this.textBoxExpDateMonth3.MaxLength = 2;
            this.textBoxExpDateMonth3.Name = "textBoxExpDateMonth3";
            this.textBoxExpDateMonth3.Size = new System.Drawing.Size(28, 20);
            this.textBoxExpDateMonth3.TabIndex = 50;
            this.textBoxExpDateMonth3.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // textBoxCreditCardSecurityCode3
            // 
            this.textBoxCreditCardSecurityCode3.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bindingSourceReceipt, "CreditCardSecurityCode3", true));
            this.textBoxCreditCardSecurityCode3.Enabled = false;
            this.textBoxCreditCardSecurityCode3.Location = new System.Drawing.Point(116, 320);
            this.textBoxCreditCardSecurityCode3.MaxLength = 4;
            this.textBoxCreditCardSecurityCode3.Name = "textBoxCreditCardSecurityCode3";
            this.textBoxCreditCardSecurityCode3.Size = new System.Drawing.Size(45, 20);
            this.textBoxCreditCardSecurityCode3.TabIndex = 49;
            // 
            // labelCreditCard3
            // 
            this.labelCreditCard3.AutoSize = true;
            this.labelCreditCard3.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelCreditCard3.Location = new System.Drawing.Point(8, 300);
            this.labelCreditCard3.Name = "labelCreditCard3";
            this.labelCreditCard3.Size = new System.Drawing.Size(80, 15);
            this.labelCreditCard3.TabIndex = 160;
            this.labelCreditCard3.Text = "CC Number 3";
            // 
            // textBoxCreditCardNumber3
            // 
            this.textBoxCreditCardNumber3.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bindingSourceReceipt, "CreditCardNumber3", true));
            this.textBoxCreditCardNumber3.Enabled = false;
            this.textBoxCreditCardNumber3.Location = new System.Drawing.Point(8, 320);
            this.textBoxCreditCardNumber3.Name = "textBoxCreditCardNumber3";
            this.textBoxCreditCardNumber3.Size = new System.Drawing.Size(100, 20);
            this.textBoxCreditCardNumber3.TabIndex = 48;
            // 
            // label30
            // 
            this.label30.AutoSize = true;
            this.label30.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label30.Location = new System.Drawing.Point(338, 252);
            this.label30.Name = "label30";
            this.label30.Size = new System.Drawing.Size(79, 15);
            this.label30.TabIndex = 158;
            this.label30.Text = "Approval No.";
            // 
            // label31
            // 
            this.label31.AutoSize = true;
            this.label31.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label31.Location = new System.Drawing.Point(266, 252);
            this.label31.Name = "label31";
            this.label31.Size = new System.Drawing.Size(33, 15);
            this.label31.TabIndex = 157;
            this.label31.Text = "Type";
            // 
            // label32
            // 
            this.label32.AutoSize = true;
            this.label32.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label32.Location = new System.Drawing.Point(180, 252);
            this.label32.Name = "label32";
            this.label32.Size = new System.Drawing.Size(86, 15);
            this.label32.TabIndex = 156;
            this.label32.Text = "EXP MM/YYYY";
            // 
            // label33
            // 
            this.label33.AutoSize = true;
            this.label33.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label33.Location = new System.Drawing.Point(116, 252);
            this.label33.Name = "label33";
            this.label33.Size = new System.Drawing.Size(58, 15);
            this.label33.TabIndex = 155;
            this.label33.Text = "SEC Code";
            // 
            // textBoxCreditCardApproval2
            // 
            this.textBoxCreditCardApproval2.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bindingSourceReceipt, "CreditCardApproval2", true));
            this.textBoxCreditCardApproval2.Enabled = false;
            this.textBoxCreditCardApproval2.Location = new System.Drawing.Point(338, 272);
            this.textBoxCreditCardApproval2.MaxLength = 16;
            this.textBoxCreditCardApproval2.Name = "textBoxCreditCardApproval2";
            this.textBoxCreditCardApproval2.Size = new System.Drawing.Size(100, 20);
            this.textBoxCreditCardApproval2.TabIndex = 46;
            // 
            // textBoxCreditCardType2
            // 
            this.textBoxCreditCardType2.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bindingSourceReceipt, "CreditCardType2", true));
            this.textBoxCreditCardType2.Enabled = false;
            this.textBoxCreditCardType2.Location = new System.Drawing.Point(266, 272);
            this.textBoxCreditCardType2.Name = "textBoxCreditCardType2";
            this.textBoxCreditCardType2.Size = new System.Drawing.Size(67, 20);
            this.textBoxCreditCardType2.TabIndex = 45;
            // 
            // textBoxExpDateYear2
            // 
            this.textBoxExpDateYear2.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bindingSourceReceipt, "CreditCardExpDateYear2", true, System.Windows.Forms.DataSourceUpdateMode.OnValidation, null, "N0"));
            this.textBoxExpDateYear2.Enabled = false;
            this.textBoxExpDateYear2.Location = new System.Drawing.Point(210, 272);
            this.textBoxExpDateYear2.MaxLength = 4;
            this.textBoxExpDateYear2.Name = "textBoxExpDateYear2";
            this.textBoxExpDateYear2.Size = new System.Drawing.Size(44, 20);
            this.textBoxExpDateYear2.TabIndex = 44;
            this.textBoxExpDateYear2.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // textBoxExpDateMonth2
            // 
            this.textBoxExpDateMonth2.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bindingSourceReceipt, "CreditCardExpDateMonth1", true, System.Windows.Forms.DataSourceUpdateMode.OnValidation, null, "N0"));
            this.textBoxExpDateMonth2.Enabled = false;
            this.textBoxExpDateMonth2.Location = new System.Drawing.Point(180, 272);
            this.textBoxExpDateMonth2.MaxLength = 2;
            this.textBoxExpDateMonth2.Name = "textBoxExpDateMonth2";
            this.textBoxExpDateMonth2.Size = new System.Drawing.Size(28, 20);
            this.textBoxExpDateMonth2.TabIndex = 43;
            this.textBoxExpDateMonth2.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // textBoxCreditCardSecurityCode2
            // 
            this.textBoxCreditCardSecurityCode2.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bindingSourceReceipt, "CreditCardSecurityCode2", true));
            this.textBoxCreditCardSecurityCode2.Enabled = false;
            this.textBoxCreditCardSecurityCode2.Location = new System.Drawing.Point(116, 272);
            this.textBoxCreditCardSecurityCode2.MaxLength = 4;
            this.textBoxCreditCardSecurityCode2.Name = "textBoxCreditCardSecurityCode2";
            this.textBoxCreditCardSecurityCode2.Size = new System.Drawing.Size(45, 20);
            this.textBoxCreditCardSecurityCode2.TabIndex = 42;
            // 
            // labelCreditCard2
            // 
            this.labelCreditCard2.AutoSize = true;
            this.labelCreditCard2.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelCreditCard2.Location = new System.Drawing.Point(8, 252);
            this.labelCreditCard2.Name = "labelCreditCard2";
            this.labelCreditCard2.Size = new System.Drawing.Size(80, 15);
            this.labelCreditCard2.TabIndex = 149;
            this.labelCreditCard2.Text = "CC Number 2";
            // 
            // textBoxCreditCardNumber2
            // 
            this.textBoxCreditCardNumber2.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bindingSourceReceipt, "CreditCardNo2", true));
            this.textBoxCreditCardNumber2.Enabled = false;
            this.textBoxCreditCardNumber2.Location = new System.Drawing.Point(8, 272);
            this.textBoxCreditCardNumber2.Name = "textBoxCreditCardNumber2";
            this.textBoxCreditCardNumber2.Size = new System.Drawing.Size(100, 20);
            this.textBoxCreditCardNumber2.TabIndex = 41;
            // 
            // label29
            // 
            this.label29.AutoSize = true;
            this.label29.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label29.Location = new System.Drawing.Point(338, 204);
            this.label29.Name = "label29";
            this.label29.Size = new System.Drawing.Size(79, 15);
            this.label29.TabIndex = 147;
            this.label29.Text = "Approval No.";
            // 
            // label28
            // 
            this.label28.AutoSize = true;
            this.label28.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label28.Location = new System.Drawing.Point(266, 204);
            this.label28.Name = "label28";
            this.label28.Size = new System.Drawing.Size(33, 15);
            this.label28.TabIndex = 146;
            this.label28.Text = "Type";
            // 
            // label27
            // 
            this.label27.AutoSize = true;
            this.label27.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label27.Location = new System.Drawing.Point(180, 204);
            this.label27.Name = "label27";
            this.label27.Size = new System.Drawing.Size(86, 15);
            this.label27.TabIndex = 145;
            this.label27.Text = "EXP MM/YYYY";
            // 
            // label26
            // 
            this.label26.AutoSize = true;
            this.label26.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label26.Location = new System.Drawing.Point(116, 204);
            this.label26.Name = "label26";
            this.label26.Size = new System.Drawing.Size(58, 15);
            this.label26.TabIndex = 144;
            this.label26.Text = "SEC Code";
            // 
            // textBoxCreditCardApproval1
            // 
            this.textBoxCreditCardApproval1.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bindingSourceReceipt, "CreditCardApproval1", true));
            this.textBoxCreditCardApproval1.Enabled = false;
            this.textBoxCreditCardApproval1.Location = new System.Drawing.Point(338, 224);
            this.textBoxCreditCardApproval1.MaxLength = 16;
            this.textBoxCreditCardApproval1.Name = "textBoxCreditCardApproval1";
            this.textBoxCreditCardApproval1.Size = new System.Drawing.Size(100, 20);
            this.textBoxCreditCardApproval1.TabIndex = 39;
            // 
            // textBoxCreditCardType1
            // 
            this.textBoxCreditCardType1.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bindingSourceReceipt, "CreditCardType1", true));
            this.textBoxCreditCardType1.Enabled = false;
            this.textBoxCreditCardType1.Location = new System.Drawing.Point(266, 224);
            this.textBoxCreditCardType1.Name = "textBoxCreditCardType1";
            this.textBoxCreditCardType1.Size = new System.Drawing.Size(67, 20);
            this.textBoxCreditCardType1.TabIndex = 38;
            // 
            // textBoxExpDateYear1
            // 
            this.textBoxExpDateYear1.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bindingSourceReceipt, "CreditcardExpDateYear1", true, System.Windows.Forms.DataSourceUpdateMode.OnValidation, null, "N0"));
            this.textBoxExpDateYear1.Enabled = false;
            this.textBoxExpDateYear1.Location = new System.Drawing.Point(210, 224);
            this.textBoxExpDateYear1.MaxLength = 4;
            this.textBoxExpDateYear1.Name = "textBoxExpDateYear1";
            this.textBoxExpDateYear1.Size = new System.Drawing.Size(44, 20);
            this.textBoxExpDateYear1.TabIndex = 37;
            this.textBoxExpDateYear1.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // textBoxExpDateMonth1
            // 
            this.textBoxExpDateMonth1.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bindingSourceReceipt, "CreditCardExpDateMonth1", true, System.Windows.Forms.DataSourceUpdateMode.OnValidation, null, "N0"));
            this.textBoxExpDateMonth1.Enabled = false;
            this.textBoxExpDateMonth1.Location = new System.Drawing.Point(180, 224);
            this.textBoxExpDateMonth1.MaxLength = 2;
            this.textBoxExpDateMonth1.Name = "textBoxExpDateMonth1";
            this.textBoxExpDateMonth1.Size = new System.Drawing.Size(28, 20);
            this.textBoxExpDateMonth1.TabIndex = 36;
            this.textBoxExpDateMonth1.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // textBoxCreditCardSecurityCode1
            // 
            this.textBoxCreditCardSecurityCode1.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bindingSourceReceipt, "CreditCardSecurityCode1", true));
            this.textBoxCreditCardSecurityCode1.Enabled = false;
            this.textBoxCreditCardSecurityCode1.Location = new System.Drawing.Point(116, 224);
            this.textBoxCreditCardSecurityCode1.MaxLength = 4;
            this.textBoxCreditCardSecurityCode1.Name = "textBoxCreditCardSecurityCode1";
            this.textBoxCreditCardSecurityCode1.Size = new System.Drawing.Size(45, 20);
            this.textBoxCreditCardSecurityCode1.TabIndex = 35;
            // 
            // labelCreditCard1
            // 
            this.labelCreditCard1.AutoSize = true;
            this.labelCreditCard1.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelCreditCard1.Location = new System.Drawing.Point(8, 204);
            this.labelCreditCard1.Name = "labelCreditCard1";
            this.labelCreditCard1.Size = new System.Drawing.Size(80, 15);
            this.labelCreditCard1.TabIndex = 138;
            this.labelCreditCard1.Text = "CC Number 1";
            // 
            // textBoxCreditCardNumber1
            // 
            this.textBoxCreditCardNumber1.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bindingSourceReceipt, "CreditCardNo1", true));
            this.textBoxCreditCardNumber1.Enabled = false;
            this.textBoxCreditCardNumber1.Location = new System.Drawing.Point(8, 224);
            this.textBoxCreditCardNumber1.Name = "textBoxCreditCardNumber1";
            this.textBoxCreditCardNumber1.Size = new System.Drawing.Size(100, 20);
            this.textBoxCreditCardNumber1.TabIndex = 34;
            // 
            // groupBoxTenderButtons
            // 
            this.groupBoxTenderButtons.Controls.Add(this.buttonCreditCard);
            this.groupBoxTenderButtons.Controls.Add(this.buttonMoneyOrder);
            this.groupBoxTenderButtons.Controls.Add(this.buttonCheck);
            this.groupBoxTenderButtons.Controls.Add(this.buttonCash);
            this.groupBoxTenderButtons.Location = new System.Drawing.Point(608, 221);
            this.groupBoxTenderButtons.Name = "groupBoxTenderButtons";
            this.groupBoxTenderButtons.Size = new System.Drawing.Size(155, 365);
            this.groupBoxTenderButtons.TabIndex = 141;
            this.groupBoxTenderButtons.TabStop = false;
            // 
            // button1
            // 
            this.button1.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button1.Image = global::IAC2021SQL.Properties.Resources.Printer;
            this.button1.Location = new System.Drawing.Point(331, 664);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(128, 59);
            this.button1.TabIndex = 56;
            this.button1.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // groupBoxComment
            // 
            this.groupBoxComment.Controls.Add(this.labelCashChange);
            this.groupBoxComment.Controls.Add(this.textBoxCashChange);
            this.groupBoxComment.Controls.Add(this.label22);
            this.groupBoxComment.Controls.Add(this.textBoxComment);
            this.groupBoxComment.Location = new System.Drawing.Point(26, 588);
            this.groupBoxComment.Name = "groupBoxComment";
            this.groupBoxComment.Size = new System.Drawing.Size(739, 69);
            this.groupBoxComment.TabIndex = 143;
            this.groupBoxComment.TabStop = false;
            // 
            // labelCashChange
            // 
            this.labelCashChange.AutoSize = true;
            this.labelCashChange.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelCashChange.Location = new System.Drawing.Point(9, 14);
            this.labelCashChange.Name = "labelCashChange";
            this.labelCashChange.Size = new System.Drawing.Size(76, 15);
            this.labelCashChange.TabIndex = 140;
            this.labelCashChange.Text = "Cash Change";
            // 
            // textBoxCashChange
            // 
            this.textBoxCashChange.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bindingSourceReceipt, "CashChange", true, System.Windows.Forms.DataSourceUpdateMode.OnValidation, null, "C2"));
            this.textBoxCashChange.Enabled = false;
            this.textBoxCashChange.Location = new System.Drawing.Point(20, 32);
            this.textBoxCashChange.Name = "textBoxCashChange";
            this.textBoxCashChange.Size = new System.Drawing.Size(100, 20);
            this.textBoxCashChange.TabIndex = 54;
            this.textBoxCashChange.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // label22
            // 
            this.label22.AutoSize = true;
            this.label22.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label22.Location = new System.Drawing.Point(157, 14);
            this.label22.Name = "label22";
            this.label22.Size = new System.Drawing.Size(62, 15);
            this.label22.TabIndex = 138;
            this.label22.Text = "Comment";
            // 
            // textBoxComment
            // 
            this.textBoxComment.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bindingSourceReceipt, "Comment", true));
            this.textBoxComment.Location = new System.Drawing.Point(157, 32);
            this.textBoxComment.MaxLength = 25;
            this.textBoxComment.Name = "textBoxComment";
            this.textBoxComment.Size = new System.Drawing.Size(425, 20);
            this.textBoxComment.TabIndex = 55;
            // 
            // receiptTableAdapter
            // 
            this.receiptTableAdapter.ClearBeforeFill = true;
            // 
            // FormReciept
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.BackColor = System.Drawing.Color.LightSteelBlue;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.ClientSize = new System.Drawing.Size(790, 754);
            this.Controls.Add(this.groupBoxComment);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.groupBoxTenderButtons);
            this.Controls.Add(this.groupBoxCounts);
            this.Controls.Add(this.groupBoxAmounts);
            this.Controls.Add(this.toolStrip1);
            this.Controls.Add(this.groupBox1);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Name = "FormReciept";
            this.Text = "Customer Receipts";
            this.Load += new System.EventHandler(this.FormReciept_Load);
            ((System.ComponentModel.ISupportInitialize)(this.iacDataSetReceipts)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bindingSourceCustomer)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bindingSourceReceipt)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.bindingSourceORECEIPT)).EndInit();
            this.groupBoxAmounts.ResumeLayout(false);
            this.groupBoxAmounts.PerformLayout();
            this.groupBoxCounts.ResumeLayout(false);
            this.groupBoxCounts.PerformLayout();
            this.groupBoxTenderButtons.ResumeLayout(false);
            this.groupBoxComment.ResumeLayout(false);
            this.groupBoxComment.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private IACDataSet iacDataSetReceipts;
        private IACDataSetTableAdapters.OPNCLSCUSTOMERTableAdapter opnclscustomerTableAdapter;
        private IACDataSetTableAdapters.OPNDEALRTableAdapter opndealrTableAdapter;
        private IACDataSetTableAdapters.DEALERTableAdapter dealerTableAdapter;
        private System.Windows.Forms.TextBox textBoxCustomerNo;
        private System.Windows.Forms.BindingSource bindingSourceCustomer;
        private System.Windows.Forms.TextBox cUSTOMER_SUFFIXTextBox;
        private System.Windows.Forms.TextBox cUSTOMER_Add_OnTextBox;
        private System.Windows.Forms.TextBox cUSTOMER_CONTACTTextBox;
        private System.Windows.Forms.TextBox cUSTOMER_ZIP_2TextBox;
        private System.Windows.Forms.TextBox cUSTOMER_ZIP_1TextBox;
        private System.Windows.Forms.TextBox cUSTOMER_STATETextBox;
        private System.Windows.Forms.TextBox cUSTOMER_CITYTextBox;
        private System.Windows.Forms.TextBox cUSTOMER_STREET_2TextBox;
        private System.Windows.Forms.TextBox cUSTOMER_STREET_1TextBox;
        private System.Windows.Forms.TextBox cUSTOMER_LAST_NAMETextBox;
        private System.Windows.Forms.TextBox cUSTOMER_FIRST_NAMETextBox;
        private System.Windows.Forms.TextBox cUSTOMER_IAC_TypeTextBox;
        private System.Windows.Forms.Label labelCustomer;
        private System.Windows.Forms.Label labelName;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox textBoxDealerName;
        private System.Windows.Forms.TextBox textBoxDealerAccNo;
        private System.Windows.Forms.Label label8;
        private IACDataSetTableAdapters.ULISTTableAdapter ulistTableAdapter;
        private System.Windows.Forms.TextBox textBoxUserName;
        private System.Windows.Forms.TextBox textBoxUserID;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.TextBox textBoxOldReceiptNumber;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripButton toolStripButtonEdit;
        private System.Windows.Forms.ToolStripButton toolStripButtonDelete;
        private System.Windows.Forms.ToolStripButton toolStripButtonSave;
        private System.Windows.Forms.BindingSource bindingSourceORECEIPT;
        private IACDataSetTableAdapters.ORECEIPTTableAdapter oRECEIPTTableAdapter;
        private System.Windows.Forms.TextBox textBoxAmountPaid;
        private System.Windows.Forms.Label labelAmountPaid;
        private System.Windows.Forms.TextBox textBoxCashTendered;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.TextBox textBox100s;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.TextBox textBox50s;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.TextBox textBox20s;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.TextBox textBox5s;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.TextBox textBox1s;
        private System.Windows.Forms.Label label16;
        private System.Windows.Forms.TextBox textBoxCoins;
        private System.Windows.Forms.Label label17;
        private System.Windows.Forms.TextBox textBoxCreditCardAmount1;
        private System.Windows.Forms.Label label18;
        private System.Windows.Forms.TextBox textBoxCheckAmount;
        private System.Windows.Forms.TextBox textBoxCheckNumber;
        private System.Windows.Forms.Label label19;
        private System.Windows.Forms.Label label20;
        private System.Windows.Forms.TextBox textBoxMoneyOrderNumber;
        private System.Windows.Forms.Label label21;
        private System.Windows.Forms.TextBox textBoxMoneyOrderAmount;
        private System.Windows.Forms.Button buttonCreditCard;
        private System.Windows.Forms.Button buttonMoneyOrder;
        private System.Windows.Forms.Button buttonCheck;
        private System.Windows.Forms.Button buttonCash;
        private System.Windows.Forms.GroupBox groupBoxAmounts;
        private System.Windows.Forms.GroupBox groupBoxCounts;
        private System.Windows.Forms.GroupBox groupBoxTenderButtons;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Label labelCreditCard1;
        private System.Windows.Forms.TextBox textBoxCreditCardNumber1;
        private System.Windows.Forms.Label label25;
        private System.Windows.Forms.TextBox textBoxCreditCardAmount3;
        private System.Windows.Forms.Label label24;
        private System.Windows.Forms.TextBox textBoxCreditCardAmount2;
        private System.Windows.Forms.Label label29;
        private System.Windows.Forms.Label label28;
        private System.Windows.Forms.Label label27;
        private System.Windows.Forms.Label label26;
        private System.Windows.Forms.TextBox textBoxCreditCardApproval1;
        private System.Windows.Forms.TextBox textBoxCreditCardType1;
        private System.Windows.Forms.TextBox textBoxExpDateYear1;
        private System.Windows.Forms.TextBox textBoxExpDateMonth1;
        private System.Windows.Forms.TextBox textBoxCreditCardSecurityCode1;
        private System.Windows.Forms.Label label35;
        private System.Windows.Forms.Label label36;
        private System.Windows.Forms.Label label37;
        private System.Windows.Forms.Label label38;
        private System.Windows.Forms.TextBox textBoxCreditCardApproval3;
        private System.Windows.Forms.TextBox textBoxCreditCardType3;
        private System.Windows.Forms.TextBox textBoxExpDateYear3;
        private System.Windows.Forms.TextBox textBoxExpDateMonth3;
        private System.Windows.Forms.TextBox textBoxCreditCardSecurityCode3;
        private System.Windows.Forms.Label labelCreditCard3;
        private System.Windows.Forms.TextBox textBoxCreditCardNumber3;
        private System.Windows.Forms.Label label30;
        private System.Windows.Forms.Label label31;
        private System.Windows.Forms.Label label32;
        private System.Windows.Forms.Label label33;
        private System.Windows.Forms.TextBox textBoxCreditCardApproval2;
        private System.Windows.Forms.TextBox textBoxCreditCardType2;
        private System.Windows.Forms.TextBox textBoxExpDateYear2;
        private System.Windows.Forms.TextBox textBoxExpDateMonth2;
        private System.Windows.Forms.TextBox textBoxCreditCardSecurityCode2;
        private System.Windows.Forms.Label labelCreditCard2;
        private System.Windows.Forms.TextBox textBoxCreditCardNumber2;
        private System.Windows.Forms.GroupBox groupBoxComment;
        private System.Windows.Forms.Label label22;
        private System.Windows.Forms.TextBox textBoxComment;
        private System.Windows.Forms.BindingSource bindingSourceReceipt;
        private IACDataSetTableAdapters.ReceiptTableAdapter receiptTableAdapter;
        private System.Windows.Forms.CheckBox checkBoxHold;
        private System.Windows.Forms.Label label23;
        private UIComponent.DateTimePicker nullableDateTimePickerHoldDate;
        private System.Windows.Forms.Label labelCashChange;
        private System.Windows.Forms.TextBox textBoxCashChange;
        private System.Windows.Forms.Label label10s;
        private System.Windows.Forms.TextBox textBox10s;
    }
}
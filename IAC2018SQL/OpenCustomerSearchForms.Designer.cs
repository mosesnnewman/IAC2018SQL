namespace IAC2021SQL
{
    partial class frmOpenCustomerLookup
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
            System.Windows.Forms.Label cUSTOMER_CONTACTLabel;
            System.Windows.Forms.Label cUSTOMER_SS_1Label;
            System.Windows.Forms.Label cUSTOMER_DOBLabel;
            System.Windows.Forms.Label cUSTOMER_CITYLabel;
            System.Windows.Forms.Label cUSTOMER_STREET_2Label;
            System.Windows.Forms.Label cUSTOMER_STREET_1Label;
            System.Windows.Forms.Label label2;
            System.Windows.Forms.Label cUSTOMER_CELL_PHONELabel;
            System.Windows.Forms.Label cUSTOMER_WORK_PHONELabel;
            System.Windows.Forms.Label cUSTOMER_PHONE_NOLabel;
            System.Windows.Forms.Label cUSTOMER_STATELabel;
            System.Windows.Forms.Label cUSTOMER_ZIP_1Label;
            System.Windows.Forms.Label label1;
            System.Windows.Forms.Label cUSTOMER_PURCHASE_ORDERLabel;
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmOpenCustomerLookup));
            this.CustomerbindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.iacDataSet1 = new IAC2021SQL.IACDataSet();
            this.customerTableAdapter1 = new IAC2021SQL.IACDataSetTableAdapters.CUSTOMERTableAdapter();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.dataGridViewCustLookup = new System.Windows.Forms.DataGridView();
            this.cUSTOMERNODataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cUSTOMERIACTYPEDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cUSTOMERSS1DataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.SOCDASH1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cUSTOMERSS2DataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.SOCDASH2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cUSTOMERSS3DataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cUSTOMERFIRSTNAMEDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cUSTOMERLASTNAMEDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cUSTOMERSTREET1DataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cUSTOMERCITYDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cUSTOMERSTATEDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cUSTOMERDEALERDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.CustomerGroupBox = new System.Windows.Forms.GroupBox();
            this.cUSTOMER_PURCHASE_ORDERTextBox = new System.Windows.Forms.TextBox();
            this.btnSearch = new System.Windows.Forms.Button();
            this.txtSrchDOB = new System.Windows.Forms.MaskedTextBox();
            this.cUSTOMER_CONTACTSrchTextBox = new System.Windows.Forms.TextBox();
            this.cUSTOMER_SS_3SrchTextBox = new System.Windows.Forms.TextBox();
            this.cUSTOMER_SS_2SrchTextBox = new System.Windows.Forms.TextBox();
            this.cUSTOMER_SS_1SrchTextBox = new System.Windows.Forms.TextBox();
            this.cUSTOMER_ZIP_2SrchTextBox = new System.Windows.Forms.TextBox();
            this.cUSTOMER_ZIP_1SrchTextBox = new System.Windows.Forms.TextBox();
            this.cUSTOMER_STATESrchTextBox = new System.Windows.Forms.TextBox();
            this.cUSTOMER_CITYSrchTextBox = new System.Windows.Forms.TextBox();
            this.cUSTOMER_STREET_2SrchTextBox = new System.Windows.Forms.TextBox();
            this.cUSTOMER_STREET_1SrchTextBox = new System.Windows.Forms.TextBox();
            this.cUSTOMER_LAST_NAMESrschTextBox = new System.Windows.Forms.TextBox();
            this.cUSTOMER_FIRST_NAMESRCHTextBox = new System.Windows.Forms.TextBox();
            this.cUSTOMER_CELL_PHONESrchTextBox = new System.Windows.Forms.MaskedTextBox();
            this.cUSTOMER_WORK_PHONESrchTextBox = new System.Windows.Forms.MaskedTextBox();
            this.cUSTOMER__PHONE_NOSrchTextBox = new System.Windows.Forms.MaskedTextBox();
            this.Vehicle_CustomerbindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.customer_VehicleTableAdapter = new IAC2021SQL.IACDataSetTableAdapters.Customer_VehicleTableAdapter();
            this.oPNCUSTTableAdapter = new IAC2021SQL.IACDataSetTableAdapters.OPNCUSTTableAdapter();
            this.bindingNavigator1 = new System.Windows.Forms.BindingNavigator(this.components);
            this.bindingNavigatorCountItem = new System.Windows.Forms.ToolStripLabel();
            this.bindingNavigatorMoveFirstItem = new System.Windows.Forms.ToolStripButton();
            this.bindingNavigatorMovePreviousItem = new System.Windows.Forms.ToolStripButton();
            this.bindingNavigatorSeparator = new System.Windows.Forms.ToolStripSeparator();
            this.bindingNavigatorPositionItem = new System.Windows.Forms.ToolStripTextBox();
            this.bindingNavigatorSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.bindingNavigatorMoveNextItem = new System.Windows.Forms.ToolStripButton();
            this.bindingNavigatorMoveLastItem = new System.Windows.Forms.ToolStripButton();
            this.bindingNavigatorSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            cUSTOMER_CONTACTLabel = new System.Windows.Forms.Label();
            cUSTOMER_SS_1Label = new System.Windows.Forms.Label();
            cUSTOMER_DOBLabel = new System.Windows.Forms.Label();
            cUSTOMER_CITYLabel = new System.Windows.Forms.Label();
            cUSTOMER_STREET_2Label = new System.Windows.Forms.Label();
            cUSTOMER_STREET_1Label = new System.Windows.Forms.Label();
            label2 = new System.Windows.Forms.Label();
            cUSTOMER_CELL_PHONELabel = new System.Windows.Forms.Label();
            cUSTOMER_WORK_PHONELabel = new System.Windows.Forms.Label();
            cUSTOMER_PHONE_NOLabel = new System.Windows.Forms.Label();
            cUSTOMER_STATELabel = new System.Windows.Forms.Label();
            cUSTOMER_ZIP_1Label = new System.Windows.Forms.Label();
            label1 = new System.Windows.Forms.Label();
            cUSTOMER_PURCHASE_ORDERLabel = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.CustomerbindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.iacDataSet1)).BeginInit();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewCustLookup)).BeginInit();
            this.CustomerGroupBox.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.Vehicle_CustomerbindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bindingNavigator1)).BeginInit();
            this.bindingNavigator1.SuspendLayout();
            this.SuspendLayout();
            // 
            // cUSTOMER_CONTACTLabel
            // 
            cUSTOMER_CONTACTLabel.AutoSize = true;
            cUSTOMER_CONTACTLabel.Location = new System.Drawing.Point(34, 90);
            cUSTOMER_CONTACTLabel.Name = "cUSTOMER_CONTACTLabel";
            cUSTOMER_CONTACTLabel.Size = new System.Drawing.Size(30, 13);
            cUSTOMER_CONTACTLabel.TabIndex = 91;
            cUSTOMER_CONTACTLabel.Text = "C/O:";
            // 
            // cUSTOMER_SS_1Label
            // 
            cUSTOMER_SS_1Label.AutoSize = true;
            cUSTOMER_SS_1Label.Location = new System.Drawing.Point(34, 20);
            cUSTOMER_SS_1Label.Name = "cUSTOMER_SS_1Label";
            cUSTOMER_SS_1Label.Size = new System.Drawing.Size(71, 13);
            cUSTOMER_SS_1Label.TabIndex = 90;
            cUSTOMER_SS_1Label.Text = "SS NUMBER:";
            // 
            // cUSTOMER_DOBLabel
            // 
            cUSTOMER_DOBLabel.AutoSize = true;
            cUSTOMER_DOBLabel.Location = new System.Drawing.Point(219, 181);
            cUSTOMER_DOBLabel.Name = "cUSTOMER_DOBLabel";
            cUSTOMER_DOBLabel.Size = new System.Drawing.Size(90, 13);
            cUSTOMER_DOBLabel.TabIndex = 89;
            cUSTOMER_DOBLabel.Text = "DATE  OF BIRTH:";
            // 
            // cUSTOMER_CITYLabel
            // 
            cUSTOMER_CITYLabel.AutoSize = true;
            cUSTOMER_CITYLabel.Location = new System.Drawing.Point(34, 159);
            cUSTOMER_CITYLabel.Name = "cUSTOMER_CITYLabel";
            cUSTOMER_CITYLabel.Size = new System.Drawing.Size(30, 13);
            cUSTOMER_CITYLabel.TabIndex = 83;
            cUSTOMER_CITYLabel.Text = "CITY:";
            // 
            // cUSTOMER_STREET_2Label
            // 
            cUSTOMER_STREET_2Label.AutoSize = true;
            cUSTOMER_STREET_2Label.BackColor = System.Drawing.Color.Transparent;
            cUSTOMER_STREET_2Label.Location = new System.Drawing.Point(34, 136);
            cUSTOMER_STREET_2Label.Name = "cUSTOMER_STREET_2Label";
            cUSTOMER_STREET_2Label.Size = new System.Drawing.Size(68, 13);
            cUSTOMER_STREET_2Label.TabIndex = 79;
            cUSTOMER_STREET_2Label.Text = "ADDRESS-2:";
            // 
            // cUSTOMER_STREET_1Label
            // 
            cUSTOMER_STREET_1Label.AutoSize = true;
            cUSTOMER_STREET_1Label.BackColor = System.Drawing.Color.Transparent;
            cUSTOMER_STREET_1Label.Location = new System.Drawing.Point(34, 116);
            cUSTOMER_STREET_1Label.Name = "cUSTOMER_STREET_1Label";
            cUSTOMER_STREET_1Label.Size = new System.Drawing.Size(68, 13);
            cUSTOMER_STREET_1Label.TabIndex = 78;
            cUSTOMER_STREET_1Label.Text = "ADDRESS-1:";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.BackColor = System.Drawing.Color.Transparent;
            label2.Location = new System.Drawing.Point(34, 67);
            label2.Name = "label2";
            label2.Size = new System.Drawing.Size(71, 13);
            label2.TabIndex = 77;
            label2.Text = "FIRST NAME:";
            // 
            // cUSTOMER_CELL_PHONELabel
            // 
            cUSTOMER_CELL_PHONELabel.AutoSize = true;
            cUSTOMER_CELL_PHONELabel.Location = new System.Drawing.Point(428, 89);
            cUSTOMER_CELL_PHONELabel.Name = "cUSTOMER_CELL_PHONELabel";
            cUSTOMER_CELL_PHONELabel.Size = new System.Drawing.Size(33, 13);
            cUSTOMER_CELL_PHONELabel.TabIndex = 72;
            cUSTOMER_CELL_PHONELabel.Text = "CELL:";
            // 
            // cUSTOMER_WORK_PHONELabel
            // 
            cUSTOMER_WORK_PHONELabel.AutoSize = true;
            cUSTOMER_WORK_PHONELabel.Location = new System.Drawing.Point(428, 66);
            cUSTOMER_WORK_PHONELabel.Name = "cUSTOMER_WORK_PHONELabel";
            cUSTOMER_WORK_PHONELabel.Size = new System.Drawing.Size(43, 13);
            cUSTOMER_WORK_PHONELabel.TabIndex = 69;
            cUSTOMER_WORK_PHONELabel.Text = "WORK:";
            // 
            // cUSTOMER_PHONE_NOLabel
            // 
            cUSTOMER_PHONE_NOLabel.AutoSize = true;
            cUSTOMER_PHONE_NOLabel.Location = new System.Drawing.Point(428, 43);
            cUSTOMER_PHONE_NOLabel.Name = "cUSTOMER_PHONE_NOLabel";
            cUSTOMER_PHONE_NOLabel.Size = new System.Drawing.Size(43, 13);
            cUSTOMER_PHONE_NOLabel.TabIndex = 66;
            cUSTOMER_PHONE_NOLabel.Text = "HOME:";
            // 
            // cUSTOMER_STATELabel
            // 
            cUSTOMER_STATELabel.AutoSize = true;
            cUSTOMER_STATELabel.Location = new System.Drawing.Point(34, 182);
            cUSTOMER_STATELabel.Name = "cUSTOMER_STATELabel";
            cUSTOMER_STATELabel.Size = new System.Drawing.Size(39, 13);
            cUSTOMER_STATELabel.TabIndex = 85;
            cUSTOMER_STATELabel.Text = "STATE:";
            // 
            // cUSTOMER_ZIP_1Label
            // 
            cUSTOMER_ZIP_1Label.AutoSize = true;
            cUSTOMER_ZIP_1Label.Location = new System.Drawing.Point(34, 205);
            cUSTOMER_ZIP_1Label.Name = "cUSTOMER_ZIP_1Label";
            cUSTOMER_ZIP_1Label.Size = new System.Drawing.Size(58, 13);
            cUSTOMER_ZIP_1Label.TabIndex = 88;
            cUSTOMER_ZIP_1Label.Text = "ZIP CODE:";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.BackColor = System.Drawing.Color.Transparent;
            label1.Location = new System.Drawing.Point(34, 43);
            label1.Name = "label1";
            label1.Size = new System.Drawing.Size(67, 13);
            label1.TabIndex = 92;
            label1.Text = "LAST NAME:";
            // 
            // cUSTOMER_PURCHASE_ORDERLabel
            // 
            cUSTOMER_PURCHASE_ORDERLabel.AutoSize = true;
            cUSTOMER_PURCHASE_ORDERLabel.Location = new System.Drawing.Point(252, 18);
            cUSTOMER_PURCHASE_ORDERLabel.Name = "cUSTOMER_PURCHASE_ORDERLabel";
            cUSTOMER_PURCHASE_ORDERLabel.Size = new System.Drawing.Size(105, 13);
            cUSTOMER_PURCHASE_ORDERLabel.TabIndex = 94;
            cUSTOMER_PURCHASE_ORDERLabel.Text = "PURCHASE ORDER:";
            // 
            // CustomerbindingSource
            // 
            this.CustomerbindingSource.DataMember = "OPNCUST";
            this.CustomerbindingSource.DataSource = this.iacDataSet1;
            // 
            // iacDataSet1
            // 
            this.iacDataSet1.DataSetName = "IACDataSet";
            this.iacDataSet1.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // customerTableAdapter1
            // 
            this.customerTableAdapter1.ClearBeforeFill = true;
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Location = new System.Drawing.Point(12, 12);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(868, 485);
            this.tabControl1.TabIndex = 18;
            // 
            // tabPage1
            // 
            this.tabPage1.BackColor = System.Drawing.Color.LightSteelBlue;
            this.tabPage1.Controls.Add(this.dataGridViewCustLookup);
            this.tabPage1.Controls.Add(this.CustomerGroupBox);
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(860, 459);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "Customer Information";
            // 
            // dataGridViewCustLookup
            // 
            this.dataGridViewCustLookup.AllowUserToAddRows = false;
            this.dataGridViewCustLookup.AllowUserToDeleteRows = false;
            this.dataGridViewCustLookup.AllowUserToOrderColumns = true;
            this.dataGridViewCustLookup.AutoGenerateColumns = false;
            this.dataGridViewCustLookup.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewCustLookup.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.cUSTOMERNODataGridViewTextBoxColumn,
            this.cUSTOMERIACTYPEDataGridViewTextBoxColumn,
            this.cUSTOMERSS1DataGridViewTextBoxColumn,
            this.SOCDASH1,
            this.cUSTOMERSS2DataGridViewTextBoxColumn,
            this.SOCDASH2,
            this.cUSTOMERSS3DataGridViewTextBoxColumn,
            this.cUSTOMERFIRSTNAMEDataGridViewTextBoxColumn,
            this.cUSTOMERLASTNAMEDataGridViewTextBoxColumn,
            this.cUSTOMERSTREET1DataGridViewTextBoxColumn,
            this.cUSTOMERCITYDataGridViewTextBoxColumn,
            this.cUSTOMERSTATEDataGridViewTextBoxColumn,
            this.cUSTOMERDEALERDataGridViewTextBoxColumn});
            this.dataGridViewCustLookup.DataSource = this.CustomerbindingSource;
            this.dataGridViewCustLookup.Location = new System.Drawing.Point(2, 259);
            this.dataGridViewCustLookup.Name = "dataGridViewCustLookup";
            this.dataGridViewCustLookup.ReadOnly = true;
            this.dataGridViewCustLookup.RowTemplate.Height = 24;
            this.dataGridViewCustLookup.Size = new System.Drawing.Size(857, 194);
            this.dataGridViewCustLookup.TabIndex = 17;
            this.dataGridViewCustLookup.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellDoubleClick);
            this.dataGridViewCustLookup.DataBindingComplete += new System.Windows.Forms.DataGridViewBindingCompleteEventHandler(this.dataGridViewCustLookup_DataBindingComplete);
            // 
            // cUSTOMERNODataGridViewTextBoxColumn
            // 
            this.cUSTOMERNODataGridViewTextBoxColumn.DataPropertyName = "CUSTOMER_NO";
            this.cUSTOMERNODataGridViewTextBoxColumn.HeaderText = "CUST NO.";
            this.cUSTOMERNODataGridViewTextBoxColumn.Name = "cUSTOMERNODataGridViewTextBoxColumn";
            this.cUSTOMERNODataGridViewTextBoxColumn.ReadOnly = true;
            this.cUSTOMERNODataGridViewTextBoxColumn.Width = 50;
            // 
            // cUSTOMERIACTYPEDataGridViewTextBoxColumn
            // 
            this.cUSTOMERIACTYPEDataGridViewTextBoxColumn.DataPropertyName = "CUSTOMER_ACT_STAT";
            this.cUSTOMERIACTYPEDataGridViewTextBoxColumn.HeaderText = "ACT STAT";
            this.cUSTOMERIACTYPEDataGridViewTextBoxColumn.Name = "cUSTOMERIACTYPEDataGridViewTextBoxColumn";
            this.cUSTOMERIACTYPEDataGridViewTextBoxColumn.ReadOnly = true;
            this.cUSTOMERIACTYPEDataGridViewTextBoxColumn.Width = 40;
            // 
            // cUSTOMERSS1DataGridViewTextBoxColumn
            // 
            this.cUSTOMERSS1DataGridViewTextBoxColumn.DataPropertyName = "CUSTOMER_SS_1";
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            this.cUSTOMERSS1DataGridViewTextBoxColumn.DefaultCellStyle = dataGridViewCellStyle1;
            this.cUSTOMERSS1DataGridViewTextBoxColumn.HeaderText = "SOCIAL SEC#";
            this.cUSTOMERSS1DataGridViewTextBoxColumn.Name = "cUSTOMERSS1DataGridViewTextBoxColumn";
            this.cUSTOMERSS1DataGridViewTextBoxColumn.ReadOnly = true;
            this.cUSTOMERSS1DataGridViewTextBoxColumn.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.cUSTOMERSS1DataGridViewTextBoxColumn.Width = 50;
            // 
            // SOCDASH1
            // 
            dataGridViewCellStyle2.NullValue = "-";
            this.SOCDASH1.DefaultCellStyle = dataGridViewCellStyle2;
            this.SOCDASH1.HeaderText = "";
            this.SOCDASH1.Name = "SOCDASH1";
            this.SOCDASH1.ReadOnly = true;
            this.SOCDASH1.Width = 10;
            // 
            // cUSTOMERSS2DataGridViewTextBoxColumn
            // 
            this.cUSTOMERSS2DataGridViewTextBoxColumn.DataPropertyName = "CUSTOMER_SS_2";
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            this.cUSTOMERSS2DataGridViewTextBoxColumn.DefaultCellStyle = dataGridViewCellStyle3;
            this.cUSTOMERSS2DataGridViewTextBoxColumn.HeaderText = "";
            this.cUSTOMERSS2DataGridViewTextBoxColumn.Name = "cUSTOMERSS2DataGridViewTextBoxColumn";
            this.cUSTOMERSS2DataGridViewTextBoxColumn.ReadOnly = true;
            this.cUSTOMERSS2DataGridViewTextBoxColumn.Width = 20;
            // 
            // SOCDASH2
            // 
            dataGridViewCellStyle4.NullValue = "-";
            this.SOCDASH2.DefaultCellStyle = dataGridViewCellStyle4;
            this.SOCDASH2.HeaderText = "";
            this.SOCDASH2.Name = "SOCDASH2";
            this.SOCDASH2.ReadOnly = true;
            this.SOCDASH2.Width = 10;
            // 
            // cUSTOMERSS3DataGridViewTextBoxColumn
            // 
            this.cUSTOMERSS3DataGridViewTextBoxColumn.DataPropertyName = "CUSTOMER_SS_3";
            dataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            this.cUSTOMERSS3DataGridViewTextBoxColumn.DefaultCellStyle = dataGridViewCellStyle5;
            this.cUSTOMERSS3DataGridViewTextBoxColumn.HeaderText = "";
            this.cUSTOMERSS3DataGridViewTextBoxColumn.Name = "cUSTOMERSS3DataGridViewTextBoxColumn";
            this.cUSTOMERSS3DataGridViewTextBoxColumn.ReadOnly = true;
            this.cUSTOMERSS3DataGridViewTextBoxColumn.Width = 35;
            // 
            // cUSTOMERFIRSTNAMEDataGridViewTextBoxColumn
            // 
            this.cUSTOMERFIRSTNAMEDataGridViewTextBoxColumn.DataPropertyName = "CUSTOMER_FIRST_NAME";
            this.cUSTOMERFIRSTNAMEDataGridViewTextBoxColumn.HeaderText = "FIRST_NAME";
            this.cUSTOMERFIRSTNAMEDataGridViewTextBoxColumn.Name = "cUSTOMERFIRSTNAMEDataGridViewTextBoxColumn";
            this.cUSTOMERFIRSTNAMEDataGridViewTextBoxColumn.ReadOnly = true;
            this.cUSTOMERFIRSTNAMEDataGridViewTextBoxColumn.Width = 135;
            // 
            // cUSTOMERLASTNAMEDataGridViewTextBoxColumn
            // 
            this.cUSTOMERLASTNAMEDataGridViewTextBoxColumn.DataPropertyName = "CUSTOMER_LAST_NAME";
            this.cUSTOMERLASTNAMEDataGridViewTextBoxColumn.HeaderText = "LAST_NAME";
            this.cUSTOMERLASTNAMEDataGridViewTextBoxColumn.Name = "cUSTOMERLASTNAMEDataGridViewTextBoxColumn";
            this.cUSTOMERLASTNAMEDataGridViewTextBoxColumn.ReadOnly = true;
            this.cUSTOMERLASTNAMEDataGridViewTextBoxColumn.Width = 135;
            // 
            // cUSTOMERSTREET1DataGridViewTextBoxColumn
            // 
            this.cUSTOMERSTREET1DataGridViewTextBoxColumn.DataPropertyName = "CUSTOMER_STREET_1";
            this.cUSTOMERSTREET1DataGridViewTextBoxColumn.HeaderText = "ADDRESS";
            this.cUSTOMERSTREET1DataGridViewTextBoxColumn.Name = "cUSTOMERSTREET1DataGridViewTextBoxColumn";
            this.cUSTOMERSTREET1DataGridViewTextBoxColumn.ReadOnly = true;
            this.cUSTOMERSTREET1DataGridViewTextBoxColumn.Width = 150;
            // 
            // cUSTOMERCITYDataGridViewTextBoxColumn
            // 
            this.cUSTOMERCITYDataGridViewTextBoxColumn.DataPropertyName = "CUSTOMER_CITY";
            this.cUSTOMERCITYDataGridViewTextBoxColumn.HeaderText = "CITY";
            this.cUSTOMERCITYDataGridViewTextBoxColumn.Name = "cUSTOMERCITYDataGridViewTextBoxColumn";
            this.cUSTOMERCITYDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // cUSTOMERSTATEDataGridViewTextBoxColumn
            // 
            this.cUSTOMERSTATEDataGridViewTextBoxColumn.DataPropertyName = "CUSTOMER_STATE";
            this.cUSTOMERSTATEDataGridViewTextBoxColumn.HeaderText = "ST";
            this.cUSTOMERSTATEDataGridViewTextBoxColumn.Name = "cUSTOMERSTATEDataGridViewTextBoxColumn";
            this.cUSTOMERSTATEDataGridViewTextBoxColumn.ReadOnly = true;
            this.cUSTOMERSTATEDataGridViewTextBoxColumn.Width = 30;
            // 
            // cUSTOMERDEALERDataGridViewTextBoxColumn
            // 
            this.cUSTOMERDEALERDataGridViewTextBoxColumn.DataPropertyName = "CUSTOMER_DEALER";
            this.cUSTOMERDEALERDataGridViewTextBoxColumn.HeaderText = "DLR";
            this.cUSTOMERDEALERDataGridViewTextBoxColumn.Name = "cUSTOMERDEALERDataGridViewTextBoxColumn";
            this.cUSTOMERDEALERDataGridViewTextBoxColumn.ReadOnly = true;
            this.cUSTOMERDEALERDataGridViewTextBoxColumn.Width = 40;
            // 
            // CustomerGroupBox
            // 
            this.CustomerGroupBox.Controls.Add(this.cUSTOMER_PURCHASE_ORDERTextBox);
            this.CustomerGroupBox.Controls.Add(cUSTOMER_PURCHASE_ORDERLabel);
            this.CustomerGroupBox.Controls.Add(label1);
            this.CustomerGroupBox.Controls.Add(this.btnSearch);
            this.CustomerGroupBox.Controls.Add(this.txtSrchDOB);
            this.CustomerGroupBox.Controls.Add(cUSTOMER_CONTACTLabel);
            this.CustomerGroupBox.Controls.Add(this.cUSTOMER_CONTACTSrchTextBox);
            this.CustomerGroupBox.Controls.Add(this.cUSTOMER_SS_3SrchTextBox);
            this.CustomerGroupBox.Controls.Add(this.cUSTOMER_SS_2SrchTextBox);
            this.CustomerGroupBox.Controls.Add(this.cUSTOMER_SS_1SrchTextBox);
            this.CustomerGroupBox.Controls.Add(this.cUSTOMER_ZIP_2SrchTextBox);
            this.CustomerGroupBox.Controls.Add(this.cUSTOMER_ZIP_1SrchTextBox);
            this.CustomerGroupBox.Controls.Add(this.cUSTOMER_STATESrchTextBox);
            this.CustomerGroupBox.Controls.Add(this.cUSTOMER_CITYSrchTextBox);
            this.CustomerGroupBox.Controls.Add(this.cUSTOMER_STREET_2SrchTextBox);
            this.CustomerGroupBox.Controls.Add(this.cUSTOMER_STREET_1SrchTextBox);
            this.CustomerGroupBox.Controls.Add(this.cUSTOMER_LAST_NAMESrschTextBox);
            this.CustomerGroupBox.Controls.Add(this.cUSTOMER_FIRST_NAMESRCHTextBox);
            this.CustomerGroupBox.Controls.Add(cUSTOMER_SS_1Label);
            this.CustomerGroupBox.Controls.Add(cUSTOMER_DOBLabel);
            this.CustomerGroupBox.Controls.Add(this.cUSTOMER_CELL_PHONESrchTextBox);
            this.CustomerGroupBox.Controls.Add(this.cUSTOMER_WORK_PHONESrchTextBox);
            this.CustomerGroupBox.Controls.Add(this.cUSTOMER__PHONE_NOSrchTextBox);
            this.CustomerGroupBox.Controls.Add(cUSTOMER_ZIP_1Label);
            this.CustomerGroupBox.Controls.Add(cUSTOMER_STATELabel);
            this.CustomerGroupBox.Controls.Add(cUSTOMER_CITYLabel);
            this.CustomerGroupBox.Controls.Add(cUSTOMER_STREET_2Label);
            this.CustomerGroupBox.Controls.Add(cUSTOMER_STREET_1Label);
            this.CustomerGroupBox.Controls.Add(label2);
            this.CustomerGroupBox.Controls.Add(cUSTOMER_CELL_PHONELabel);
            this.CustomerGroupBox.Controls.Add(cUSTOMER_WORK_PHONELabel);
            this.CustomerGroupBox.Controls.Add(cUSTOMER_PHONE_NOLabel);
            this.CustomerGroupBox.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.CustomerGroupBox.Location = new System.Drawing.Point(84, 11);
            this.CustomerGroupBox.Name = "CustomerGroupBox";
            this.CustomerGroupBox.Size = new System.Drawing.Size(693, 242);
            this.CustomerGroupBox.TabIndex = 94;
            this.CustomerGroupBox.TabStop = false;
            this.CustomerGroupBox.Text = "Searchable Fields";
            // 
            // cUSTOMER_PURCHASE_ORDERTextBox
            // 
            this.cUSTOMER_PURCHASE_ORDERTextBox.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.cUSTOMER_PURCHASE_ORDERTextBox.Location = new System.Drawing.Point(391, 10);
            this.cUSTOMER_PURCHASE_ORDERTextBox.MaxLength = 8;
            this.cUSTOMER_PURCHASE_ORDERTextBox.Name = "cUSTOMER_PURCHASE_ORDERTextBox";
            this.cUSTOMER_PURCHASE_ORDERTextBox.Size = new System.Drawing.Size(67, 22);
            this.cUSTOMER_PURCHASE_ORDERTextBox.TabIndex = 93;
            this.cUSTOMER_PURCHASE_ORDERTextBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // btnSearch
            // 
            this.btnSearch.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSearch.Location = new System.Drawing.Point(311, 200);
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.Size = new System.Drawing.Size(106, 37);
            this.btnSearch.TabIndex = 16;
            this.btnSearch.Text = "Search";
            this.btnSearch.UseVisualStyleBackColor = true;
            this.btnSearch.Click += new System.EventHandler(this.btnSearch_Click);
            // 
            // txtSrchDOB
            // 
            this.txtSrchDOB.Location = new System.Drawing.Point(315, 174);
            this.txtSrchDOB.Mask = "00/00/0000";
            this.txtSrchDOB.Name = "txtSrchDOB";
            this.txtSrchDOB.Size = new System.Drawing.Size(68, 22);
            this.txtSrchDOB.TabIndex = 12;
            this.txtSrchDOB.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.txtSrchDOB.ValidatingType = typeof(System.DateTime);
            this.txtSrchDOB.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.General_KeyPress);
            // 
            // cUSTOMER_CONTACTSrchTextBox
            // 
            this.cUSTOMER_CONTACTSrchTextBox.Location = new System.Drawing.Point(117, 83);
            this.cUSTOMER_CONTACTSrchTextBox.Name = "cUSTOMER_CONTACTSrchTextBox";
            this.cUSTOMER_CONTACTSrchTextBox.Size = new System.Drawing.Size(230, 22);
            this.cUSTOMER_CONTACTSrchTextBox.TabIndex = 5;
            this.cUSTOMER_CONTACTSrchTextBox.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.General_KeyPress);
            // 
            // cUSTOMER_SS_3SrchTextBox
            // 
            this.cUSTOMER_SS_3SrchTextBox.Location = new System.Drawing.Point(171, 13);
            this.cUSTOMER_SS_3SrchTextBox.Name = "cUSTOMER_SS_3SrchTextBox";
            this.cUSTOMER_SS_3SrchTextBox.Size = new System.Drawing.Size(37, 22);
            this.cUSTOMER_SS_3SrchTextBox.TabIndex = 2;
            this.cUSTOMER_SS_3SrchTextBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.cUSTOMER_SS_3SrchTextBox.TextChanged += new System.EventHandler(this.cUSTOMER_SS_3SrchTextBox_TextChanged);
            this.cUSTOMER_SS_3SrchTextBox.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.General_KeyPress);
            // 
            // cUSTOMER_SS_2SrchTextBox
            // 
            this.cUSTOMER_SS_2SrchTextBox.Location = new System.Drawing.Point(149, 13);
            this.cUSTOMER_SS_2SrchTextBox.Name = "cUSTOMER_SS_2SrchTextBox";
            this.cUSTOMER_SS_2SrchTextBox.Size = new System.Drawing.Size(19, 22);
            this.cUSTOMER_SS_2SrchTextBox.TabIndex = 1;
            this.cUSTOMER_SS_2SrchTextBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.cUSTOMER_SS_2SrchTextBox.TextChanged += new System.EventHandler(this.cUSTOMER_SS_2SrchTextBox_TextChanged);
            this.cUSTOMER_SS_2SrchTextBox.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.General_KeyPress);
            // 
            // cUSTOMER_SS_1SrchTextBox
            // 
            this.cUSTOMER_SS_1SrchTextBox.Location = new System.Drawing.Point(117, 13);
            this.cUSTOMER_SS_1SrchTextBox.Name = "cUSTOMER_SS_1SrchTextBox";
            this.cUSTOMER_SS_1SrchTextBox.Size = new System.Drawing.Size(29, 22);
            this.cUSTOMER_SS_1SrchTextBox.TabIndex = 0;
            this.cUSTOMER_SS_1SrchTextBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.cUSTOMER_SS_1SrchTextBox.TextChanged += new System.EventHandler(this.cUSTOMER_SS_1SrchTextBox_TextChanged);
            this.cUSTOMER_SS_1SrchTextBox.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.General_KeyPress);
            // 
            // cUSTOMER_ZIP_2SrchTextBox
            // 
            this.cUSTOMER_ZIP_2SrchTextBox.Location = new System.Drawing.Point(165, 198);
            this.cUSTOMER_ZIP_2SrchTextBox.Name = "cUSTOMER_ZIP_2SrchTextBox";
            this.cUSTOMER_ZIP_2SrchTextBox.Size = new System.Drawing.Size(45, 22);
            this.cUSTOMER_ZIP_2SrchTextBox.TabIndex = 11;
            this.cUSTOMER_ZIP_2SrchTextBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.cUSTOMER_ZIP_2SrchTextBox.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.General_KeyPress);
            // 
            // cUSTOMER_ZIP_1SrchTextBox
            // 
            this.cUSTOMER_ZIP_1SrchTextBox.Location = new System.Drawing.Point(117, 198);
            this.cUSTOMER_ZIP_1SrchTextBox.Name = "cUSTOMER_ZIP_1SrchTextBox";
            this.cUSTOMER_ZIP_1SrchTextBox.Size = new System.Drawing.Size(45, 22);
            this.cUSTOMER_ZIP_1SrchTextBox.TabIndex = 10;
            this.cUSTOMER_ZIP_1SrchTextBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.cUSTOMER_ZIP_1SrchTextBox.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.General_KeyPress);
            // 
            // cUSTOMER_STATESrchTextBox
            // 
            this.cUSTOMER_STATESrchTextBox.Location = new System.Drawing.Point(117, 175);
            this.cUSTOMER_STATESrchTextBox.Name = "cUSTOMER_STATESrchTextBox";
            this.cUSTOMER_STATESrchTextBox.Size = new System.Drawing.Size(24, 22);
            this.cUSTOMER_STATESrchTextBox.TabIndex = 9;
            this.cUSTOMER_STATESrchTextBox.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.General_KeyPress);
            // 
            // cUSTOMER_CITYSrchTextBox
            // 
            this.cUSTOMER_CITYSrchTextBox.Location = new System.Drawing.Point(117, 152);
            this.cUSTOMER_CITYSrchTextBox.Name = "cUSTOMER_CITYSrchTextBox";
            this.cUSTOMER_CITYSrchTextBox.Size = new System.Drawing.Size(230, 22);
            this.cUSTOMER_CITYSrchTextBox.TabIndex = 8;
            this.cUSTOMER_CITYSrchTextBox.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.General_KeyPress);
            // 
            // cUSTOMER_STREET_2SrchTextBox
            // 
            this.cUSTOMER_STREET_2SrchTextBox.Location = new System.Drawing.Point(117, 129);
            this.cUSTOMER_STREET_2SrchTextBox.Name = "cUSTOMER_STREET_2SrchTextBox";
            this.cUSTOMER_STREET_2SrchTextBox.Size = new System.Drawing.Size(230, 22);
            this.cUSTOMER_STREET_2SrchTextBox.TabIndex = 7;
            this.cUSTOMER_STREET_2SrchTextBox.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.General_KeyPress);
            // 
            // cUSTOMER_STREET_1SrchTextBox
            // 
            this.cUSTOMER_STREET_1SrchTextBox.Location = new System.Drawing.Point(117, 106);
            this.cUSTOMER_STREET_1SrchTextBox.Name = "cUSTOMER_STREET_1SrchTextBox";
            this.cUSTOMER_STREET_1SrchTextBox.Size = new System.Drawing.Size(230, 22);
            this.cUSTOMER_STREET_1SrchTextBox.TabIndex = 6;
            this.cUSTOMER_STREET_1SrchTextBox.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.General_KeyPress);
            // 
            // cUSTOMER_LAST_NAMESrschTextBox
            // 
            this.cUSTOMER_LAST_NAMESrschTextBox.Location = new System.Drawing.Point(117, 36);
            this.cUSTOMER_LAST_NAMESrschTextBox.Name = "cUSTOMER_LAST_NAMESrschTextBox";
            this.cUSTOMER_LAST_NAMESrschTextBox.Size = new System.Drawing.Size(131, 22);
            this.cUSTOMER_LAST_NAMESrschTextBox.TabIndex = 3;
            this.cUSTOMER_LAST_NAMESrschTextBox.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.General_KeyPress);
            // 
            // cUSTOMER_FIRST_NAMESRCHTextBox
            // 
            this.cUSTOMER_FIRST_NAMESRCHTextBox.Location = new System.Drawing.Point(117, 60);
            this.cUSTOMER_FIRST_NAMESRCHTextBox.Name = "cUSTOMER_FIRST_NAMESRCHTextBox";
            this.cUSTOMER_FIRST_NAMESRCHTextBox.Size = new System.Drawing.Size(131, 22);
            this.cUSTOMER_FIRST_NAMESRCHTextBox.TabIndex = 4;
            this.cUSTOMER_FIRST_NAMESRCHTextBox.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.General_KeyPress);
            // 
            // cUSTOMER_CELL_PHONESrchTextBox
            // 
            this.cUSTOMER_CELL_PHONESrchTextBox.Location = new System.Drawing.Point(570, 82);
            this.cUSTOMER_CELL_PHONESrchTextBox.Mask = "(999) 000-0000";
            this.cUSTOMER_CELL_PHONESrchTextBox.Name = "cUSTOMER_CELL_PHONESrchTextBox";
            this.cUSTOMER_CELL_PHONESrchTextBox.Size = new System.Drawing.Size(78, 22);
            this.cUSTOMER_CELL_PHONESrchTextBox.TabIndex = 15;
            this.cUSTOMER_CELL_PHONESrchTextBox.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.General_KeyPress);
            // 
            // cUSTOMER_WORK_PHONESrchTextBox
            // 
            this.cUSTOMER_WORK_PHONESrchTextBox.Location = new System.Drawing.Point(570, 59);
            this.cUSTOMER_WORK_PHONESrchTextBox.Mask = "(999) 000-0000";
            this.cUSTOMER_WORK_PHONESrchTextBox.Name = "cUSTOMER_WORK_PHONESrchTextBox";
            this.cUSTOMER_WORK_PHONESrchTextBox.Size = new System.Drawing.Size(78, 22);
            this.cUSTOMER_WORK_PHONESrchTextBox.TabIndex = 14;
            this.cUSTOMER_WORK_PHONESrchTextBox.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.General_KeyPress);
            // 
            // cUSTOMER__PHONE_NOSrchTextBox
            // 
            this.cUSTOMER__PHONE_NOSrchTextBox.Location = new System.Drawing.Point(570, 36);
            this.cUSTOMER__PHONE_NOSrchTextBox.Mask = "(999) 000-0000";
            this.cUSTOMER__PHONE_NOSrchTextBox.Name = "cUSTOMER__PHONE_NOSrchTextBox";
            this.cUSTOMER__PHONE_NOSrchTextBox.Size = new System.Drawing.Size(78, 22);
            this.cUSTOMER__PHONE_NOSrchTextBox.TabIndex = 13;
            this.cUSTOMER__PHONE_NOSrchTextBox.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.General_KeyPress);
            // 
            // Vehicle_CustomerbindingSource
            // 
            this.Vehicle_CustomerbindingSource.DataMember = "Customer_Vehicle";
            this.Vehicle_CustomerbindingSource.DataSource = this.iacDataSet1;
            // 
            // customer_VehicleTableAdapter
            // 
            this.customer_VehicleTableAdapter.ClearBeforeFill = true;
            // 
            // oPNCUSTTableAdapter
            // 
            this.oPNCUSTTableAdapter.ClearBeforeFill = true;
            // 
            // bindingNavigator1
            // 
            this.bindingNavigator1.AddNewItem = null;
            this.bindingNavigator1.BindingSource = this.CustomerbindingSource;
            this.bindingNavigator1.CountItem = this.bindingNavigatorCountItem;
            this.bindingNavigator1.DeleteItem = null;
            this.bindingNavigator1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.bindingNavigator1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.bindingNavigatorMoveFirstItem,
            this.bindingNavigatorMovePreviousItem,
            this.bindingNavigatorSeparator,
            this.bindingNavigatorPositionItem,
            this.bindingNavigatorCountItem,
            this.bindingNavigatorSeparator1,
            this.bindingNavigatorMoveNextItem,
            this.bindingNavigatorMoveLastItem,
            this.bindingNavigatorSeparator2});
            this.bindingNavigator1.Location = new System.Drawing.Point(0, 498);
            this.bindingNavigator1.MoveFirstItem = this.bindingNavigatorMoveFirstItem;
            this.bindingNavigator1.MoveLastItem = this.bindingNavigatorMoveLastItem;
            this.bindingNavigator1.MoveNextItem = this.bindingNavigatorMoveNextItem;
            this.bindingNavigator1.MovePreviousItem = this.bindingNavigatorMovePreviousItem;
            this.bindingNavigator1.Name = "bindingNavigator1";
            this.bindingNavigator1.PositionItem = this.bindingNavigatorPositionItem;
            this.bindingNavigator1.Size = new System.Drawing.Size(900, 25);
            this.bindingNavigator1.TabIndex = 19;
            this.bindingNavigator1.Text = "bindingNavigator1";
            // 
            // bindingNavigatorCountItem
            // 
            this.bindingNavigatorCountItem.Name = "bindingNavigatorCountItem";
            this.bindingNavigatorCountItem.Size = new System.Drawing.Size(36, 22);
            this.bindingNavigatorCountItem.Text = "of {0}";
            this.bindingNavigatorCountItem.ToolTipText = "Total number of items";
            // 
            // bindingNavigatorMoveFirstItem
            // 
            this.bindingNavigatorMoveFirstItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.bindingNavigatorMoveFirstItem.Image = ((System.Drawing.Image)(resources.GetObject("bindingNavigatorMoveFirstItem.Image")));
            this.bindingNavigatorMoveFirstItem.Name = "bindingNavigatorMoveFirstItem";
            this.bindingNavigatorMoveFirstItem.RightToLeftAutoMirrorImage = true;
            this.bindingNavigatorMoveFirstItem.Size = new System.Drawing.Size(23, 22);
            this.bindingNavigatorMoveFirstItem.Text = "Move first";
            // 
            // bindingNavigatorMovePreviousItem
            // 
            this.bindingNavigatorMovePreviousItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.bindingNavigatorMovePreviousItem.Image = ((System.Drawing.Image)(resources.GetObject("bindingNavigatorMovePreviousItem.Image")));
            this.bindingNavigatorMovePreviousItem.Name = "bindingNavigatorMovePreviousItem";
            this.bindingNavigatorMovePreviousItem.RightToLeftAutoMirrorImage = true;
            this.bindingNavigatorMovePreviousItem.Size = new System.Drawing.Size(23, 22);
            this.bindingNavigatorMovePreviousItem.Text = "Move previous";
            // 
            // bindingNavigatorSeparator
            // 
            this.bindingNavigatorSeparator.Name = "bindingNavigatorSeparator";
            this.bindingNavigatorSeparator.Size = new System.Drawing.Size(6, 25);
            // 
            // bindingNavigatorPositionItem
            // 
            this.bindingNavigatorPositionItem.AccessibleName = "Position";
            this.bindingNavigatorPositionItem.AutoSize = false;
            this.bindingNavigatorPositionItem.Name = "bindingNavigatorPositionItem";
            this.bindingNavigatorPositionItem.Size = new System.Drawing.Size(50, 23);
            this.bindingNavigatorPositionItem.Text = "0";
            this.bindingNavigatorPositionItem.ToolTipText = "Current position";
            // 
            // bindingNavigatorSeparator1
            // 
            this.bindingNavigatorSeparator1.Name = "bindingNavigatorSeparator1";
            this.bindingNavigatorSeparator1.Size = new System.Drawing.Size(6, 25);
            // 
            // bindingNavigatorMoveNextItem
            // 
            this.bindingNavigatorMoveNextItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.bindingNavigatorMoveNextItem.Image = ((System.Drawing.Image)(resources.GetObject("bindingNavigatorMoveNextItem.Image")));
            this.bindingNavigatorMoveNextItem.Name = "bindingNavigatorMoveNextItem";
            this.bindingNavigatorMoveNextItem.RightToLeftAutoMirrorImage = true;
            this.bindingNavigatorMoveNextItem.Size = new System.Drawing.Size(23, 22);
            this.bindingNavigatorMoveNextItem.Text = "Move next";
            // 
            // bindingNavigatorMoveLastItem
            // 
            this.bindingNavigatorMoveLastItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.bindingNavigatorMoveLastItem.Image = ((System.Drawing.Image)(resources.GetObject("bindingNavigatorMoveLastItem.Image")));
            this.bindingNavigatorMoveLastItem.Name = "bindingNavigatorMoveLastItem";
            this.bindingNavigatorMoveLastItem.RightToLeftAutoMirrorImage = true;
            this.bindingNavigatorMoveLastItem.Size = new System.Drawing.Size(23, 22);
            this.bindingNavigatorMoveLastItem.Text = "Move last";
            // 
            // bindingNavigatorSeparator2
            // 
            this.bindingNavigatorSeparator2.Name = "bindingNavigatorSeparator2";
            this.bindingNavigatorSeparator2.Size = new System.Drawing.Size(6, 25);
            // 
            // frmOpenCustomerLookup
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.BackColor = System.Drawing.Color.CornflowerBlue;
            this.ClientSize = new System.Drawing.Size(900, 523);
            this.Controls.Add(this.bindingNavigator1);
            this.Controls.Add(this.tabControl1);
            this.Name = "frmOpenCustomerLookup";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Open Customer Lookup";
            this.Load += new System.EventHandler(this.frmCustomerLookup_Load);
            ((System.ComponentModel.ISupportInitialize)(this.CustomerbindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.iacDataSet1)).EndInit();
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewCustLookup)).EndInit();
            this.CustomerGroupBox.ResumeLayout(false);
            this.CustomerGroupBox.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.Vehicle_CustomerbindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bindingNavigator1)).EndInit();
            this.bindingNavigator1.ResumeLayout(false);
            this.bindingNavigator1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private IACDataSet iacDataSet1;
        private System.Windows.Forms.BindingSource CustomerbindingSource;
        private IACDataSetTableAdapters.CUSTOMERTableAdapter customerTableAdapter1;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.DataGridView dataGridViewCustLookup;
        private System.Windows.Forms.GroupBox CustomerGroupBox;
        private System.Windows.Forms.Button btnSearch;
        private System.Windows.Forms.MaskedTextBox txtSrchDOB;
        private System.Windows.Forms.TextBox cUSTOMER_CONTACTSrchTextBox;
        private System.Windows.Forms.TextBox cUSTOMER_SS_3SrchTextBox;
        private System.Windows.Forms.TextBox cUSTOMER_SS_2SrchTextBox;
        private System.Windows.Forms.TextBox cUSTOMER_SS_1SrchTextBox;
        private System.Windows.Forms.TextBox cUSTOMER_CITYSrchTextBox;
        private System.Windows.Forms.TextBox cUSTOMER_STREET_2SrchTextBox;
        private System.Windows.Forms.TextBox cUSTOMER_STREET_1SrchTextBox;
        private System.Windows.Forms.TextBox cUSTOMER_LAST_NAMESrschTextBox;
        private System.Windows.Forms.TextBox cUSTOMER_FIRST_NAMESRCHTextBox;
        private System.Windows.Forms.MaskedTextBox cUSTOMER_CELL_PHONESrchTextBox;
        private System.Windows.Forms.MaskedTextBox cUSTOMER_WORK_PHONESrchTextBox;
        private System.Windows.Forms.MaskedTextBox cUSTOMER__PHONE_NOSrchTextBox;
        private System.Windows.Forms.TextBox cUSTOMER_ZIP_2SrchTextBox;
        private System.Windows.Forms.TextBox cUSTOMER_ZIP_1SrchTextBox;
        private System.Windows.Forms.TextBox cUSTOMER_STATESrchTextBox;
        private System.Windows.Forms.DataGridViewTextBoxColumn cUSTOMERNODataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn cUSTOMERIACTYPEDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn cUSTOMERSS1DataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn SOCDASH1;
        private System.Windows.Forms.DataGridViewTextBoxColumn cUSTOMERSS2DataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn SOCDASH2;
        private System.Windows.Forms.DataGridViewTextBoxColumn cUSTOMERSS3DataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn cUSTOMERFIRSTNAMEDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn cUSTOMERLASTNAMEDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn cUSTOMERSTREET1DataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn cUSTOMERCITYDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn cUSTOMERSTATEDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn cUSTOMERDEALERDataGridViewTextBoxColumn;
        private System.Windows.Forms.BindingSource Vehicle_CustomerbindingSource;
        private IACDataSetTableAdapters.Customer_VehicleTableAdapter customer_VehicleTableAdapter;
        private IACDataSetTableAdapters.OPNCUSTTableAdapter oPNCUSTTableAdapter;
        private System.Windows.Forms.BindingNavigator bindingNavigator1;
        private System.Windows.Forms.ToolStripLabel bindingNavigatorCountItem;
        private System.Windows.Forms.ToolStripButton bindingNavigatorMoveFirstItem;
        private System.Windows.Forms.ToolStripButton bindingNavigatorMovePreviousItem;
        private System.Windows.Forms.ToolStripSeparator bindingNavigatorSeparator;
        private System.Windows.Forms.ToolStripTextBox bindingNavigatorPositionItem;
        private System.Windows.Forms.ToolStripSeparator bindingNavigatorSeparator1;
        private System.Windows.Forms.ToolStripButton bindingNavigatorMoveNextItem;
        private System.Windows.Forms.ToolStripButton bindingNavigatorMoveLastItem;
        private System.Windows.Forms.ToolStripSeparator bindingNavigatorSeparator2;
        private System.Windows.Forms.TextBox cUSTOMER_PURCHASE_ORDERTextBox;
    }
}
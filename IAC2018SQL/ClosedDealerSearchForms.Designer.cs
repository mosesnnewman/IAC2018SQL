namespace IAC2021SQL
{
    partial class frmDealerLookup
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
            System.Windows.Forms.Label labelEmail;
            System.Windows.Forms.Label labelCellPhone;
            System.Windows.Forms.Label labelDealerStartDate;
            System.Windows.Forms.Label label66;
            System.Windows.Forms.Label label67;
            System.Windows.Forms.Label label68;
            System.Windows.Forms.Label label72;
            System.Windows.Forms.Label label73;
            System.Windows.Forms.Label cUSTOMER_STREET_1Label;
            System.Windows.Forms.Label label2;
            System.Windows.Forms.Label cUSTOMER_DEALERLabel;
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmDealerLookup));
            this.iacDataSet1 = new IAC2021SQL.IACDataSet();
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
            this.toolStripButtonExporttoExcel = new System.Windows.Forms.ToolStripButton();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.dataGridViewDealerLookup = new System.Windows.Forms.DataGridView();
            this.dEALERACCNODataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DEALER_STATUS = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dEALERNAMEDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dEALERADDRDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dEALERCITYDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dEALERSTDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dEALERZIPDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dealerStartDateDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.emailDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DealerbindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.CustomerGroupBox = new System.Windows.Forms.GroupBox();
            this.DealerInfogroupBox = new System.Windows.Forms.GroupBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.radioButtonBoth = new System.Windows.Forms.RadioButton();
            this.radioButtonInactive = new System.Windows.Forms.RadioButton();
            this.radioButtonActive = new System.Windows.Forms.RadioButton();
            this.btnSearch = new System.Windows.Forms.Button();
            this.textBoxDealer = new System.Windows.Forms.TextBox();
            this.maskedTextBoxStartDate = new System.Windows.Forms.MaskedTextBox();
            this.textBoxDealerEmail = new System.Windows.Forms.TextBox();
            this.maskedTextBoxCellPhone = new System.Windows.Forms.MaskedTextBox();
            this.DealerZipTextBox = new System.Windows.Forms.TextBox();
            this.DealerStateTextBox = new System.Windows.Forms.TextBox();
            this.DealerCityTextBox = new System.Windows.Forms.TextBox();
            this.DEALERWorkPhoneTextBox = new System.Windows.Forms.MaskedTextBox();
            this.DealerHomePhoneTextBox = new System.Windows.Forms.MaskedTextBox();
            this.DEALER_STREETTextBox = new System.Windows.Forms.TextBox();
            this.dEALER_NAMETextBox = new System.Windows.Forms.TextBox();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.dEALERTableAdapter = new IAC2021SQL.IACDataSetTableAdapters.DEALERTableAdapter();
            labelEmail = new System.Windows.Forms.Label();
            labelCellPhone = new System.Windows.Forms.Label();
            labelDealerStartDate = new System.Windows.Forms.Label();
            label66 = new System.Windows.Forms.Label();
            label67 = new System.Windows.Forms.Label();
            label68 = new System.Windows.Forms.Label();
            label72 = new System.Windows.Forms.Label();
            label73 = new System.Windows.Forms.Label();
            cUSTOMER_STREET_1Label = new System.Windows.Forms.Label();
            label2 = new System.Windows.Forms.Label();
            cUSTOMER_DEALERLabel = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.iacDataSet1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bindingNavigator1)).BeginInit();
            this.bindingNavigator1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewDealerLookup)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.DealerbindingSource)).BeginInit();
            this.CustomerGroupBox.SuspendLayout();
            this.DealerInfogroupBox.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.tabControl1.SuspendLayout();
            this.SuspendLayout();
            // 
            // labelEmail
            // 
            labelEmail.AutoSize = true;
            labelEmail.BackColor = System.Drawing.Color.Transparent;
            labelEmail.Location = new System.Drawing.Point(35, 154);
            labelEmail.Name = "labelEmail";
            labelEmail.Size = new System.Drawing.Size(41, 13);
            labelEmail.TabIndex = 146;
            labelEmail.Text = "EMAIL:";
            labelEmail.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // labelCellPhone
            // 
            labelCellPhone.AutoSize = true;
            labelCellPhone.Location = new System.Drawing.Point(407, 128);
            labelCellPhone.Name = "labelCellPhone";
            labelCellPhone.Size = new System.Drawing.Size(33, 13);
            labelCellPhone.TabIndex = 145;
            labelCellPhone.Text = "CELL:";
            labelCellPhone.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // labelDealerStartDate
            // 
            labelDealerStartDate.AutoSize = true;
            labelDealerStartDate.BackColor = System.Drawing.Color.Transparent;
            labelDealerStartDate.Location = new System.Drawing.Point(365, 51);
            labelDealerStartDate.Name = "labelDealerStartDate";
            labelDealerStartDate.Size = new System.Drawing.Size(67, 13);
            labelDealerStartDate.TabIndex = 143;
            labelDealerStartDate.Text = "START DATE:";
            labelDealerStartDate.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // label66
            // 
            label66.AutoSize = true;
            label66.Location = new System.Drawing.Point(155, 128);
            label66.Name = "label66";
            label66.Size = new System.Drawing.Size(58, 13);
            label66.TabIndex = 140;
            label66.Text = "ZIP CODE:";
            // 
            // label67
            // 
            label67.AutoSize = true;
            label67.Location = new System.Drawing.Point(32, 128);
            label67.Name = "label67";
            label67.Size = new System.Drawing.Size(37, 13);
            label67.TabIndex = 139;
            label67.Text = "STATE:";
            label67.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // label68
            // 
            label68.AutoSize = true;
            label68.Location = new System.Drawing.Point(43, 103);
            label68.Name = "label68";
            label68.Size = new System.Drawing.Size(30, 13);
            label68.TabIndex = 138;
            label68.Text = "CITY:";
            label68.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // label72
            // 
            label72.AutoSize = true;
            label72.Location = new System.Drawing.Point(413, 103);
            label72.Name = "label72";
            label72.Size = new System.Drawing.Size(28, 13);
            label72.TabIndex = 132;
            label72.Text = "FAX:";
            label72.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // label73
            // 
            label73.AutoSize = true;
            label73.Location = new System.Drawing.Point(411, 77);
            label73.Name = "label73";
            label73.Size = new System.Drawing.Size(31, 13);
            label73.TabIndex = 131;
            label73.Text = "BUS:";
            label73.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // cUSTOMER_STREET_1Label
            // 
            cUSTOMER_STREET_1Label.AutoSize = true;
            cUSTOMER_STREET_1Label.BackColor = System.Drawing.Color.Transparent;
            cUSTOMER_STREET_1Label.Location = new System.Drawing.Point(15, 77);
            cUSTOMER_STREET_1Label.Name = "cUSTOMER_STREET_1Label";
            cUSTOMER_STREET_1Label.Size = new System.Drawing.Size(58, 13);
            cUSTOMER_STREET_1Label.TabIndex = 43;
            cUSTOMER_STREET_1Label.Text = "ADDRESS:";
            cUSTOMER_STREET_1Label.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.BackColor = System.Drawing.Color.Transparent;
            label2.Location = new System.Drawing.Point(36, 51);
            label2.Name = "label2";
            label2.Size = new System.Drawing.Size(41, 13);
            label2.TabIndex = 41;
            label2.Text = "NAME:";
            label2.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // cUSTOMER_DEALERLabel
            // 
            cUSTOMER_DEALERLabel.AutoSize = true;
            cUSTOMER_DEALERLabel.Location = new System.Drawing.Point(5, 25);
            cUSTOMER_DEALERLabel.Name = "cUSTOMER_DEALERLabel";
            cUSTOMER_DEALERLabel.Size = new System.Drawing.Size(69, 13);
            cUSTOMER_DEALERLabel.TabIndex = 39;
            cUSTOMER_DEALERLabel.Text = "DEALER NO:";
            cUSTOMER_DEALERLabel.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // iacDataSet1
            // 
            this.iacDataSet1.DataSetName = "IACDataSet";
            this.iacDataSet1.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // bindingNavigator1
            // 
            this.bindingNavigator1.AddNewItem = null;
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
            this.bindingNavigatorSeparator2,
            this.toolStripButtonExporttoExcel});
            this.bindingNavigator1.Location = new System.Drawing.Point(0, 562);
            this.bindingNavigator1.MoveFirstItem = this.bindingNavigatorMoveFirstItem;
            this.bindingNavigator1.MoveLastItem = this.bindingNavigatorMoveLastItem;
            this.bindingNavigator1.MoveNextItem = this.bindingNavigatorMoveNextItem;
            this.bindingNavigator1.MovePreviousItem = this.bindingNavigatorMovePreviousItem;
            this.bindingNavigator1.Name = "bindingNavigator1";
            this.bindingNavigator1.PositionItem = this.bindingNavigatorPositionItem;
            this.bindingNavigator1.Size = new System.Drawing.Size(1050, 25);
            this.bindingNavigator1.TabIndex = 19;
            this.bindingNavigator1.Text = "bindingNavigator1";
            // 
            // bindingNavigatorCountItem
            // 
            this.bindingNavigatorCountItem.Name = "bindingNavigatorCountItem";
            this.bindingNavigatorCountItem.Size = new System.Drawing.Size(35, 22);
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
            // toolStripButtonExporttoExcel
            // 
            this.toolStripButtonExporttoExcel.AutoSize = false;
            this.toolStripButtonExporttoExcel.BackColor = System.Drawing.Color.GreenYellow;
            this.toolStripButtonExporttoExcel.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButtonExporttoExcel.Image")));
            this.toolStripButtonExporttoExcel.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButtonExporttoExcel.Name = "toolStripButtonExporttoExcel";
            this.toolStripButtonExporttoExcel.Size = new System.Drawing.Size(100, 22);
            this.toolStripButtonExporttoExcel.Text = "&Excel Export";
            this.toolStripButtonExporttoExcel.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.toolStripButtonExporttoExcel.Click += new System.EventHandler(this.toolStripButtonExporttoExcel_Click);
            // 
            // tabPage1
            // 
            this.tabPage1.BackColor = System.Drawing.Color.LightSteelBlue;
            this.tabPage1.Controls.Add(this.dataGridViewDealerLookup);
            this.tabPage1.Controls.Add(this.CustomerGroupBox);
            this.tabPage1.Location = new System.Drawing.Point(4, 24);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(1018, 519);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "Dealer Information";
            // 
            // dataGridViewDealerLookup
            // 
            this.dataGridViewDealerLookup.AllowUserToAddRows = false;
            this.dataGridViewDealerLookup.AllowUserToDeleteRows = false;
            this.dataGridViewDealerLookup.AllowUserToOrderColumns = true;
            this.dataGridViewDealerLookup.AutoGenerateColumns = false;
            this.dataGridViewDealerLookup.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewDealerLookup.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.dEALERACCNODataGridViewTextBoxColumn,
            this.DEALER_STATUS,
            this.dEALERNAMEDataGridViewTextBoxColumn,
            this.dEALERADDRDataGridViewTextBoxColumn,
            this.dEALERCITYDataGridViewTextBoxColumn,
            this.dEALERSTDataGridViewTextBoxColumn,
            this.dEALERZIPDataGridViewTextBoxColumn,
            this.dealerStartDateDataGridViewTextBoxColumn,
            this.emailDataGridViewTextBoxColumn});
            this.dataGridViewDealerLookup.DataSource = this.DealerbindingSource;
            this.dataGridViewDealerLookup.Location = new System.Drawing.Point(6, 309);
            this.dataGridViewDealerLookup.Name = "dataGridViewDealerLookup";
            this.dataGridViewDealerLookup.ReadOnly = true;
            this.dataGridViewDealerLookup.RowTemplate.Height = 24;
            this.dataGridViewDealerLookup.Size = new System.Drawing.Size(1006, 194);
            this.dataGridViewDealerLookup.TabIndex = 14;
            this.dataGridViewDealerLookup.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellDoubleClick);
            this.dataGridViewDealerLookup.DataBindingComplete += new System.Windows.Forms.DataGridViewBindingCompleteEventHandler(this.dataGridViewDealerLookup_DataBindingComplete);
            // 
            // dEALERACCNODataGridViewTextBoxColumn
            // 
            this.dEALERACCNODataGridViewTextBoxColumn.DataPropertyName = "DEALER_ACC_NO";
            this.dEALERACCNODataGridViewTextBoxColumn.HeaderText = "DLR_NO";
            this.dEALERACCNODataGridViewTextBoxColumn.Name = "dEALERACCNODataGridViewTextBoxColumn";
            this.dEALERACCNODataGridViewTextBoxColumn.ReadOnly = true;
            this.dEALERACCNODataGridViewTextBoxColumn.Width = 60;
            // 
            // DEALER_STATUS
            // 
            this.DEALER_STATUS.DataPropertyName = "DEALER_STATUS";
            this.DEALER_STATUS.HeaderText = "STATUS";
            this.DEALER_STATUS.Name = "DEALER_STATUS";
            this.DEALER_STATUS.ReadOnly = true;
            this.DEALER_STATUS.Width = 60;
            // 
            // dEALERNAMEDataGridViewTextBoxColumn
            // 
            this.dEALERNAMEDataGridViewTextBoxColumn.DataPropertyName = "DEALER_NAME";
            this.dEALERNAMEDataGridViewTextBoxColumn.HeaderText = "NAME";
            this.dEALERNAMEDataGridViewTextBoxColumn.Name = "dEALERNAMEDataGridViewTextBoxColumn";
            this.dEALERNAMEDataGridViewTextBoxColumn.ReadOnly = true;
            this.dEALERNAMEDataGridViewTextBoxColumn.Width = 180;
            // 
            // dEALERADDRDataGridViewTextBoxColumn
            // 
            this.dEALERADDRDataGridViewTextBoxColumn.DataPropertyName = "DEALER_ADDR";
            this.dEALERADDRDataGridViewTextBoxColumn.HeaderText = "ADDRESS";
            this.dEALERADDRDataGridViewTextBoxColumn.Name = "dEALERADDRDataGridViewTextBoxColumn";
            this.dEALERADDRDataGridViewTextBoxColumn.ReadOnly = true;
            this.dEALERADDRDataGridViewTextBoxColumn.Width = 180;
            // 
            // dEALERCITYDataGridViewTextBoxColumn
            // 
            this.dEALERCITYDataGridViewTextBoxColumn.DataPropertyName = "DEALER_CITY";
            this.dEALERCITYDataGridViewTextBoxColumn.HeaderText = "CITY";
            this.dEALERCITYDataGridViewTextBoxColumn.Name = "dEALERCITYDataGridViewTextBoxColumn";
            this.dEALERCITYDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // dEALERSTDataGridViewTextBoxColumn
            // 
            this.dEALERSTDataGridViewTextBoxColumn.DataPropertyName = "DEALER_ST";
            this.dEALERSTDataGridViewTextBoxColumn.HeaderText = "STATE";
            this.dEALERSTDataGridViewTextBoxColumn.Name = "dEALERSTDataGridViewTextBoxColumn";
            this.dEALERSTDataGridViewTextBoxColumn.ReadOnly = true;
            this.dEALERSTDataGridViewTextBoxColumn.Width = 60;
            // 
            // dEALERZIPDataGridViewTextBoxColumn
            // 
            this.dEALERZIPDataGridViewTextBoxColumn.DataPropertyName = "DEALER_ZIP";
            this.dEALERZIPDataGridViewTextBoxColumn.HeaderText = "ZIP";
            this.dEALERZIPDataGridViewTextBoxColumn.Name = "dEALERZIPDataGridViewTextBoxColumn";
            this.dEALERZIPDataGridViewTextBoxColumn.ReadOnly = true;
            this.dEALERZIPDataGridViewTextBoxColumn.Width = 60;
            // 
            // dealerStartDateDataGridViewTextBoxColumn
            // 
            this.dealerStartDateDataGridViewTextBoxColumn.DataPropertyName = "DealerStartDate";
            this.dealerStartDateDataGridViewTextBoxColumn.HeaderText = "START_DATE";
            this.dealerStartDateDataGridViewTextBoxColumn.Name = "dealerStartDateDataGridViewTextBoxColumn";
            this.dealerStartDateDataGridViewTextBoxColumn.ReadOnly = true;
            this.dealerStartDateDataGridViewTextBoxColumn.Width = 80;
            // 
            // emailDataGridViewTextBoxColumn
            // 
            this.emailDataGridViewTextBoxColumn.DataPropertyName = "Email";
            this.emailDataGridViewTextBoxColumn.HeaderText = "EMAIL";
            this.emailDataGridViewTextBoxColumn.Name = "emailDataGridViewTextBoxColumn";
            this.emailDataGridViewTextBoxColumn.ReadOnly = true;
            this.emailDataGridViewTextBoxColumn.Width = 200;
            // 
            // DealerbindingSource
            // 
            this.DealerbindingSource.DataMember = "DEALER";
            this.DealerbindingSource.DataSource = this.iacDataSet1;
            // 
            // CustomerGroupBox
            // 
            this.CustomerGroupBox.Controls.Add(this.DealerInfogroupBox);
            this.CustomerGroupBox.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.CustomerGroupBox.Location = new System.Drawing.Point(154, 3);
            this.CustomerGroupBox.Name = "CustomerGroupBox";
            this.CustomerGroupBox.Size = new System.Drawing.Size(711, 300);
            this.CustomerGroupBox.TabIndex = 94;
            this.CustomerGroupBox.TabStop = false;
            this.CustomerGroupBox.Text = "Searchable Fields";
            // 
            // DealerInfogroupBox
            // 
            this.DealerInfogroupBox.Controls.Add(this.groupBox1);
            this.DealerInfogroupBox.Controls.Add(this.btnSearch);
            this.DealerInfogroupBox.Controls.Add(this.textBoxDealer);
            this.DealerInfogroupBox.Controls.Add(this.maskedTextBoxStartDate);
            this.DealerInfogroupBox.Controls.Add(this.textBoxDealerEmail);
            this.DealerInfogroupBox.Controls.Add(labelEmail);
            this.DealerInfogroupBox.Controls.Add(labelCellPhone);
            this.DealerInfogroupBox.Controls.Add(this.maskedTextBoxCellPhone);
            this.DealerInfogroupBox.Controls.Add(labelDealerStartDate);
            this.DealerInfogroupBox.Controls.Add(this.DealerZipTextBox);
            this.DealerInfogroupBox.Controls.Add(this.DealerStateTextBox);
            this.DealerInfogroupBox.Controls.Add(this.DealerCityTextBox);
            this.DealerInfogroupBox.Controls.Add(this.DEALERWorkPhoneTextBox);
            this.DealerInfogroupBox.Controls.Add(this.DealerHomePhoneTextBox);
            this.DealerInfogroupBox.Controls.Add(label66);
            this.DealerInfogroupBox.Controls.Add(label67);
            this.DealerInfogroupBox.Controls.Add(label68);
            this.DealerInfogroupBox.Controls.Add(label72);
            this.DealerInfogroupBox.Controls.Add(label73);
            this.DealerInfogroupBox.Controls.Add(this.DEALER_STREETTextBox);
            this.DealerInfogroupBox.Controls.Add(cUSTOMER_STREET_1Label);
            this.DealerInfogroupBox.Controls.Add(label2);
            this.DealerInfogroupBox.Controls.Add(this.dEALER_NAMETextBox);
            this.DealerInfogroupBox.Controls.Add(cUSTOMER_DEALERLabel);
            this.DealerInfogroupBox.Location = new System.Drawing.Point(78, 14);
            this.DealerInfogroupBox.Name = "DealerInfogroupBox";
            this.DealerInfogroupBox.Size = new System.Drawing.Size(554, 272);
            this.DealerInfogroupBox.TabIndex = 174;
            this.DealerInfogroupBox.TabStop = false;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.radioButtonBoth);
            this.groupBox1.Controls.Add(this.radioButtonInactive);
            this.groupBox1.Controls.Add(this.radioButtonActive);
            this.groupBox1.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox1.Location = new System.Drawing.Point(410, 175);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(115, 91);
            this.groupBox1.TabIndex = 147;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Status";
            // 
            // radioButtonBoth
            // 
            this.radioButtonBoth.AutoSize = true;
            this.radioButtonBoth.Location = new System.Drawing.Point(21, 55);
            this.radioButtonBoth.Name = "radioButtonBoth";
            this.radioButtonBoth.Size = new System.Drawing.Size(50, 17);
            this.radioButtonBoth.TabIndex = 16;
            this.radioButtonBoth.TabStop = true;
            this.radioButtonBoth.Text = "&Both";
            this.radioButtonBoth.UseVisualStyleBackColor = true;
            // 
            // radioButtonInactive
            // 
            this.radioButtonInactive.AutoSize = true;
            this.radioButtonInactive.Location = new System.Drawing.Point(21, 35);
            this.radioButtonInactive.Name = "radioButtonInactive";
            this.radioButtonInactive.Size = new System.Drawing.Size(65, 17);
            this.radioButtonInactive.TabIndex = 15;
            this.radioButtonInactive.TabStop = true;
            this.radioButtonInactive.Text = "&Inactive";
            this.radioButtonInactive.UseVisualStyleBackColor = true;
            // 
            // radioButtonActive
            // 
            this.radioButtonActive.AutoSize = true;
            this.radioButtonActive.Location = new System.Drawing.Point(21, 15);
            this.radioButtonActive.Name = "radioButtonActive";
            this.radioButtonActive.Size = new System.Drawing.Size(57, 17);
            this.radioButtonActive.TabIndex = 14;
            this.radioButtonActive.TabStop = true;
            this.radioButtonActive.Text = "&Active";
            this.radioButtonActive.UseVisualStyleBackColor = true;
            // 
            // btnSearch
            // 
            this.btnSearch.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSearch.Location = new System.Drawing.Point(224, 210);
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.Size = new System.Drawing.Size(106, 37);
            this.btnSearch.TabIndex = 13;
            this.btnSearch.Text = "Search";
            this.btnSearch.UseVisualStyleBackColor = true;
            this.btnSearch.Click += new System.EventHandler(this.btnSearch_Click);
            // 
            // textBoxDealer
            // 
            this.textBoxDealer.Location = new System.Drawing.Point(80, 17);
            this.textBoxDealer.MaxLength = 3;
            this.textBoxDealer.Name = "textBoxDealer";
            this.textBoxDealer.Size = new System.Drawing.Size(45, 22);
            this.textBoxDealer.TabIndex = 1;
            this.textBoxDealer.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.General_KeyPress);
            this.textBoxDealer.Validated += new System.EventHandler(this.textBoxDealer_Validated);
            // 
            // maskedTextBoxStartDate
            // 
            this.maskedTextBoxStartDate.Location = new System.Drawing.Point(447, 44);
            this.maskedTextBoxStartDate.Mask = "00/00/0000";
            this.maskedTextBoxStartDate.Name = "maskedTextBoxStartDate";
            this.maskedTextBoxStartDate.Size = new System.Drawing.Size(78, 22);
            this.maskedTextBoxStartDate.TabIndex = 8;
            this.maskedTextBoxStartDate.ValidatingType = typeof(System.DateTime);
            this.maskedTextBoxStartDate.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.General_KeyPress);
            // 
            // textBoxDealerEmail
            // 
            this.textBoxDealerEmail.CharacterCasing = System.Windows.Forms.CharacterCasing.Lower;
            this.textBoxDealerEmail.Location = new System.Drawing.Point(80, 147);
            this.textBoxDealerEmail.MaxLength = 50;
            this.textBoxDealerEmail.Name = "textBoxDealerEmail";
            this.textBoxDealerEmail.Size = new System.Drawing.Size(445, 22);
            this.textBoxDealerEmail.TabIndex = 13;
            this.textBoxDealerEmail.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.General_KeyPress);
            // 
            // maskedTextBoxCellPhone
            // 
            this.maskedTextBoxCellPhone.Location = new System.Drawing.Point(447, 121);
            this.maskedTextBoxCellPhone.Mask = "(999) 000-0000";
            this.maskedTextBoxCellPhone.Name = "maskedTextBoxCellPhone";
            this.maskedTextBoxCellPhone.Size = new System.Drawing.Size(78, 22);
            this.maskedTextBoxCellPhone.TabIndex = 11;
            this.maskedTextBoxCellPhone.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.General_KeyPress);
            // 
            // DealerZipTextBox
            // 
            this.DealerZipTextBox.Location = new System.Drawing.Point(227, 121);
            this.DealerZipTextBox.MaxLength = 5;
            this.DealerZipTextBox.Name = "DealerZipTextBox";
            this.DealerZipTextBox.Size = new System.Drawing.Size(45, 22);
            this.DealerZipTextBox.TabIndex = 6;
            this.DealerZipTextBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.DealerZipTextBox.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.General_KeyPress);
            // 
            // DealerStateTextBox
            // 
            this.DealerStateTextBox.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.DealerStateTextBox.Location = new System.Drawing.Point(80, 121);
            this.DealerStateTextBox.MaxLength = 2;
            this.DealerStateTextBox.Name = "DealerStateTextBox";
            this.DealerStateTextBox.Size = new System.Drawing.Size(24, 22);
            this.DealerStateTextBox.TabIndex = 5;
            this.DealerStateTextBox.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.General_KeyPress);
            // 
            // DealerCityTextBox
            // 
            this.DealerCityTextBox.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.DealerCityTextBox.Location = new System.Drawing.Point(80, 96);
            this.DealerCityTextBox.MaxLength = 20;
            this.DealerCityTextBox.Name = "DealerCityTextBox";
            this.DealerCityTextBox.Size = new System.Drawing.Size(230, 22);
            this.DealerCityTextBox.TabIndex = 4;
            this.DealerCityTextBox.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.General_KeyPress);
            // 
            // DEALERWorkPhoneTextBox
            // 
            this.DEALERWorkPhoneTextBox.Location = new System.Drawing.Point(447, 96);
            this.DEALERWorkPhoneTextBox.Mask = "(999) 000-0000";
            this.DEALERWorkPhoneTextBox.Name = "DEALERWorkPhoneTextBox";
            this.DEALERWorkPhoneTextBox.Size = new System.Drawing.Size(78, 22);
            this.DEALERWorkPhoneTextBox.TabIndex = 10;
            this.DEALERWorkPhoneTextBox.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.General_KeyPress);
            // 
            // DealerHomePhoneTextBox
            // 
            this.DealerHomePhoneTextBox.Location = new System.Drawing.Point(447, 70);
            this.DealerHomePhoneTextBox.Mask = "(999) 000-0000";
            this.DealerHomePhoneTextBox.Name = "DealerHomePhoneTextBox";
            this.DealerHomePhoneTextBox.Size = new System.Drawing.Size(78, 22);
            this.DealerHomePhoneTextBox.TabIndex = 9;
            this.DealerHomePhoneTextBox.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.General_KeyPress);
            // 
            // DEALER_STREETTextBox
            // 
            this.DEALER_STREETTextBox.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.DEALER_STREETTextBox.Location = new System.Drawing.Point(80, 70);
            this.DEALER_STREETTextBox.MaxLength = 30;
            this.DEALER_STREETTextBox.Name = "DEALER_STREETTextBox";
            this.DEALER_STREETTextBox.Size = new System.Drawing.Size(230, 22);
            this.DEALER_STREETTextBox.TabIndex = 3;
            this.DEALER_STREETTextBox.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.General_KeyPress);
            // 
            // dEALER_NAMETextBox
            // 
            this.dEALER_NAMETextBox.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.dEALER_NAMETextBox.Location = new System.Drawing.Point(80, 44);
            this.dEALER_NAMETextBox.MaxLength = 25;
            this.dEALER_NAMETextBox.Name = "dEALER_NAMETextBox";
            this.dEALER_NAMETextBox.Size = new System.Drawing.Size(183, 22);
            this.dEALER_NAMETextBox.TabIndex = 2;
            this.dEALER_NAMETextBox.Text = " ";
            this.dEALER_NAMETextBox.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.General_KeyPress);
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Location = new System.Drawing.Point(12, 7);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(1026, 547);
            this.tabControl1.TabIndex = 18;
            // 
            // dEALERTableAdapter
            // 
            this.dEALERTableAdapter.ClearBeforeFill = true;
            // 
            // frmDealerLookup
            // 
            this.Appearance.BackColor = System.Drawing.Color.CornflowerBlue;
            this.Appearance.Options.UseBackColor = true;
            this.Appearance.Options.UseFont = true;
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.ClientSize = new System.Drawing.Size(1050, 587);
            this.Controls.Add(this.bindingNavigator1);
            this.Controls.Add(this.tabControl1);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LookAndFeel.SkinName = "McSkin";
            this.LookAndFeel.UseDefaultLookAndFeel = false;
            this.MaximizeBox = false;
            this.Name = "frmDealerLookup";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Closed Dealer Lookup";
            this.Load += new System.EventHandler(this.frmDealerLookup_Load);
            ((System.ComponentModel.ISupportInitialize)(this.iacDataSet1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bindingNavigator1)).EndInit();
            this.bindingNavigator1.ResumeLayout(false);
            this.bindingNavigator1.PerformLayout();
            this.tabPage1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewDealerLookup)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.DealerbindingSource)).EndInit();
            this.CustomerGroupBox.ResumeLayout(false);
            this.DealerInfogroupBox.ResumeLayout(false);
            this.DealerInfogroupBox.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.tabControl1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private IACDataSet iacDataSet1;
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
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.DataGridView dataGridViewDealerLookup;
        private System.Windows.Forms.GroupBox CustomerGroupBox;
        private System.Windows.Forms.Button btnSearch;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.GroupBox DealerInfogroupBox;
        private System.Windows.Forms.TextBox textBoxDealerEmail;
        private System.Windows.Forms.MaskedTextBox maskedTextBoxCellPhone;
        private System.Windows.Forms.TextBox DealerZipTextBox;
        private System.Windows.Forms.TextBox DealerStateTextBox;
        private System.Windows.Forms.TextBox DealerCityTextBox;
        private System.Windows.Forms.MaskedTextBox DEALERWorkPhoneTextBox;
        private System.Windows.Forms.MaskedTextBox DealerHomePhoneTextBox;
        private System.Windows.Forms.TextBox DEALER_STREETTextBox;
        private System.Windows.Forms.TextBox dEALER_NAMETextBox;
        private System.Windows.Forms.BindingSource DealerbindingSource;
        private IACDataSetTableAdapters.DEALERTableAdapter dEALERTableAdapter;
        private System.Windows.Forms.MaskedTextBox maskedTextBoxStartDate;
        private System.Windows.Forms.TextBox textBoxDealer;
        private System.Windows.Forms.ToolStripButton toolStripButtonExporttoExcel;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.RadioButton radioButtonBoth;
        private System.Windows.Forms.RadioButton radioButtonInactive;
        private System.Windows.Forms.RadioButton radioButtonActive;
        private System.Windows.Forms.DataGridViewTextBoxColumn dEALERACCNODataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn DEALER_STATUS;
        private System.Windows.Forms.DataGridViewTextBoxColumn dEALERNAMEDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn dEALERADDRDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn dEALERCITYDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn dEALERSTDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn dEALERZIPDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn dealerStartDateDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn emailDataGridViewTextBoxColumn;
    }
}
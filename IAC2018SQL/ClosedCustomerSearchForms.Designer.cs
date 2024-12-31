namespace IAC2021SQL
{
    partial class frmCustomerLookup
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
            System.Windows.Forms.Label lblMake;
            System.Windows.Forms.Label lblInsCo;
            System.Windows.Forms.Label lblModel;
            System.Windows.Forms.Label lblVehicleYear;
            System.Windows.Forms.Label cUSTOMER_STATELabel;
            System.Windows.Forms.Label cUSTOMER_ZIP_1Label;
            System.Windows.Forms.Label lblVIN;
            System.Windows.Forms.Label label1;
            System.Windows.Forms.Label label3;
            System.Windows.Forms.Label label4;
            System.Windows.Forms.Label label5;
            System.Windows.Forms.Label label6;
            System.Windows.Forms.Label label7;
            System.Windows.Forms.Label label8;
            System.Windows.Forms.Label label9;
            System.Windows.Forms.Label label10;
            System.Windows.Forms.Label label11;
            System.Windows.Forms.Label label12;
            System.Windows.Forms.Label label13;
            System.Windows.Forms.Label labelEXT;
            System.Windows.Forms.Label cUSTOMER_PURCHASE_ORDERLabel;
            System.Windows.Forms.Label label14;
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmCustomerLookup));
            this.CustomerbindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.iacDataSet1 = new IAC2021SQL.IACDataSet();
            this.customerTableAdapter1 = new IAC2021SQL.IACDataSetTableAdapters.CUSTOMERTableAdapter();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.dataGridViewCustLookup = new System.Windows.Forms.DataGridView();
            this.cUSTOMERNODataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.CustomerActType = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.CustomerActStat = new System.Windows.Forms.DataGridViewTextBoxColumn();
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
            this.EmailAddress = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.CosignerEmail = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.CustomerGroupBox = new System.Windows.Forms.GroupBox();
            this.NullableDateTimePickerSrchDOB = new ProManApp.NullableDateTimePicker();
            this.richTextBoxEmailAddress = new System.Windows.Forms.TextBox();
            this.cUSTOMER_PURCHASE_ORDERTextBox = new System.Windows.Forms.TextBox();
            this.groupBoxCosigner = new System.Windows.Forms.GroupBox();
            this.nullableDateTimePickerCOSDOB = new ProManApp.NullableDateTimePicker();
            this.textBoxCOSWORKEXT = new System.Windows.Forms.TextBox();
            this.COSIGNER_STATESrchTextBox = new System.Windows.Forms.TextBox();
            this.COSIGNER_ZIPSrchTextBox = new System.Windows.Forms.TextBox();
            this.COSIGNER_CITYSrchTextBox = new System.Windows.Forms.TextBox();
            this.COSIGNER_STREETSrchTextBox = new System.Windows.Forms.TextBox();
            this.COSIGNER_SS_3SrchTextBox = new System.Windows.Forms.TextBox();
            this.COSIGNER_SS_2SrchTextBox = new System.Windows.Forms.TextBox();
            this.COSIGNER_SS_1SrchTextBox = new System.Windows.Forms.TextBox();
            this.COSIGNER_CELL_PHONESrchTextBox = new System.Windows.Forms.MaskedTextBox();
            this.COSIGNER_WORK_PHONESrchTextBox = new System.Windows.Forms.MaskedTextBox();
            this.COSIGNER__PHONE_NOSrchTextBox = new System.Windows.Forms.MaskedTextBox();
            this.COSIGNER_LAST_NAMESrschTextBox = new System.Windows.Forms.TextBox();
            this.COSIGNER_FIRST_NAMESRCHTextBox = new System.Windows.Forms.TextBox();
            this.btnSearch = new System.Windows.Forms.Button();
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
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.dataGridViewVehicleLookup = new System.Windows.Forms.DataGridView();
            this.vEHICLECUSTNODataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.CUSTOMER_FIRST_NAME = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.CUSTOMER_LAST_NAME = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.vEHICLEYEARDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.vEHICLEMAKEDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.vEHICLEMODELDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.vEHICLEVINDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.vEHICLEINSCOMPANYDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.vEHICLEPOLICYNODataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Vehicle_CustomerbindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.VehicleGroupBox = new System.Windows.Forms.GroupBox();
            this.txtVIN = new System.Windows.Forms.TextBox();
            this.buttonVehicleSearch = new System.Windows.Forms.Button();
            this.txtMake = new System.Windows.Forms.TextBox();
            this.txtInsuranceCompany = new System.Windows.Forms.TextBox();
            this.txtModel = new System.Windows.Forms.TextBox();
            this.txtVehicleYear = new System.Windows.Forms.TextBox();
            this.customer_VehicleTableAdapter = new IAC2021SQL.IACDataSetTableAdapters.Customer_VehicleTableAdapter();
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
            this.customerMailTableAdapter = new IAC2021SQL.IACDataSetTableAdapters.CustomerMailTableAdapter();
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
            lblMake = new System.Windows.Forms.Label();
            lblInsCo = new System.Windows.Forms.Label();
            lblModel = new System.Windows.Forms.Label();
            lblVehicleYear = new System.Windows.Forms.Label();
            cUSTOMER_STATELabel = new System.Windows.Forms.Label();
            cUSTOMER_ZIP_1Label = new System.Windows.Forms.Label();
            lblVIN = new System.Windows.Forms.Label();
            label1 = new System.Windows.Forms.Label();
            label3 = new System.Windows.Forms.Label();
            label4 = new System.Windows.Forms.Label();
            label5 = new System.Windows.Forms.Label();
            label6 = new System.Windows.Forms.Label();
            label7 = new System.Windows.Forms.Label();
            label8 = new System.Windows.Forms.Label();
            label9 = new System.Windows.Forms.Label();
            label10 = new System.Windows.Forms.Label();
            label11 = new System.Windows.Forms.Label();
            label12 = new System.Windows.Forms.Label();
            label13 = new System.Windows.Forms.Label();
            labelEXT = new System.Windows.Forms.Label();
            cUSTOMER_PURCHASE_ORDERLabel = new System.Windows.Forms.Label();
            label14 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.CustomerbindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.iacDataSet1)).BeginInit();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewCustLookup)).BeginInit();
            this.CustomerGroupBox.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.NullableDateTimePickerSrchDOB)).BeginInit();
            this.groupBoxCosigner.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nullableDateTimePickerCOSDOB)).BeginInit();
            this.tabPage2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewVehicleLookup)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Vehicle_CustomerbindingSource)).BeginInit();
            this.VehicleGroupBox.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.bindingNavigator1)).BeginInit();
            this.bindingNavigator1.SuspendLayout();
            this.SuspendLayout();
            // 
            // cUSTOMER_CONTACTLabel
            // 
            cUSTOMER_CONTACTLabel.AutoSize = true;
            cUSTOMER_CONTACTLabel.Location = new System.Drawing.Point(72, 86);
            cUSTOMER_CONTACTLabel.Name = "cUSTOMER_CONTACTLabel";
            cUSTOMER_CONTACTLabel.Size = new System.Drawing.Size(30, 13);
            cUSTOMER_CONTACTLabel.TabIndex = 91;
            cUSTOMER_CONTACTLabel.Text = "C/O:";
            cUSTOMER_CONTACTLabel.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // cUSTOMER_SS_1Label
            // 
            cUSTOMER_SS_1Label.AutoSize = true;
            cUSTOMER_SS_1Label.Location = new System.Drawing.Point(31, 20);
            cUSTOMER_SS_1Label.Name = "cUSTOMER_SS_1Label";
            cUSTOMER_SS_1Label.Size = new System.Drawing.Size(70, 13);
            cUSTOMER_SS_1Label.TabIndex = 90;
            cUSTOMER_SS_1Label.Text = "SS NUMBER:";
            cUSTOMER_SS_1Label.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // cUSTOMER_DOBLabel
            // 
            cUSTOMER_DOBLabel.AutoSize = true;
            cUSTOMER_DOBLabel.Location = new System.Drawing.Point(183, 174);
            cUSTOMER_DOBLabel.Name = "cUSTOMER_DOBLabel";
            cUSTOMER_DOBLabel.Size = new System.Drawing.Size(90, 13);
            cUSTOMER_DOBLabel.TabIndex = 89;
            cUSTOMER_DOBLabel.Text = "DATE  OF BIRTH:";
            cUSTOMER_DOBLabel.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // cUSTOMER_CITYLabel
            // 
            cUSTOMER_CITYLabel.AutoSize = true;
            cUSTOMER_CITYLabel.Location = new System.Drawing.Point(72, 152);
            cUSTOMER_CITYLabel.Name = "cUSTOMER_CITYLabel";
            cUSTOMER_CITYLabel.Size = new System.Drawing.Size(31, 13);
            cUSTOMER_CITYLabel.TabIndex = 83;
            cUSTOMER_CITYLabel.Text = "CITY:";
            cUSTOMER_CITYLabel.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // cUSTOMER_STREET_2Label
            // 
            cUSTOMER_STREET_2Label.AutoSize = true;
            cUSTOMER_STREET_2Label.BackColor = System.Drawing.Color.Transparent;
            cUSTOMER_STREET_2Label.Location = new System.Drawing.Point(34, 130);
            cUSTOMER_STREET_2Label.Name = "cUSTOMER_STREET_2Label";
            cUSTOMER_STREET_2Label.Size = new System.Drawing.Size(68, 13);
            cUSTOMER_STREET_2Label.TabIndex = 79;
            cUSTOMER_STREET_2Label.Text = "ADDRESS-2:";
            cUSTOMER_STREET_2Label.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // cUSTOMER_STREET_1Label
            // 
            cUSTOMER_STREET_1Label.AutoSize = true;
            cUSTOMER_STREET_1Label.BackColor = System.Drawing.Color.Transparent;
            cUSTOMER_STREET_1Label.Location = new System.Drawing.Point(34, 108);
            cUSTOMER_STREET_1Label.Name = "cUSTOMER_STREET_1Label";
            cUSTOMER_STREET_1Label.Size = new System.Drawing.Size(68, 13);
            cUSTOMER_STREET_1Label.TabIndex = 78;
            cUSTOMER_STREET_1Label.Text = "ADDRESS-1:";
            cUSTOMER_STREET_1Label.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.BackColor = System.Drawing.Color.Transparent;
            label2.Location = new System.Drawing.Point(31, 64);
            label2.Name = "label2";
            label2.Size = new System.Drawing.Size(72, 13);
            label2.TabIndex = 77;
            label2.Text = "FIRST NAME:";
            label2.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // cUSTOMER_CELL_PHONELabel
            // 
            cUSTOMER_CELL_PHONELabel.AutoSize = true;
            cUSTOMER_CELL_PHONELabel.Location = new System.Drawing.Point(69, 262);
            cUSTOMER_CELL_PHONELabel.Name = "cUSTOMER_CELL_PHONELabel";
            cUSTOMER_CELL_PHONELabel.Size = new System.Drawing.Size(33, 13);
            cUSTOMER_CELL_PHONELabel.TabIndex = 72;
            cUSTOMER_CELL_PHONELabel.Text = "CELL:";
            cUSTOMER_CELL_PHONELabel.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // cUSTOMER_WORK_PHONELabel
            // 
            cUSTOMER_WORK_PHONELabel.AutoSize = true;
            cUSTOMER_WORK_PHONELabel.Location = new System.Drawing.Point(59, 240);
            cUSTOMER_WORK_PHONELabel.Name = "cUSTOMER_WORK_PHONELabel";
            cUSTOMER_WORK_PHONELabel.Size = new System.Drawing.Size(43, 13);
            cUSTOMER_WORK_PHONELabel.TabIndex = 69;
            cUSTOMER_WORK_PHONELabel.Text = "WORK:";
            cUSTOMER_WORK_PHONELabel.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // cUSTOMER_PHONE_NOLabel
            // 
            cUSTOMER_PHONE_NOLabel.AutoSize = true;
            cUSTOMER_PHONE_NOLabel.Location = new System.Drawing.Point(59, 218);
            cUSTOMER_PHONE_NOLabel.Name = "cUSTOMER_PHONE_NOLabel";
            cUSTOMER_PHONE_NOLabel.Size = new System.Drawing.Size(43, 13);
            cUSTOMER_PHONE_NOLabel.TabIndex = 66;
            cUSTOMER_PHONE_NOLabel.Text = "HOME:";
            cUSTOMER_PHONE_NOLabel.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // lblMake
            // 
            lblMake.AutoSize = true;
            lblMake.Location = new System.Drawing.Point(59, 90);
            lblMake.Name = "lblMake";
            lblMake.Size = new System.Drawing.Size(38, 13);
            lblMake.TabIndex = 91;
            lblMake.Text = "Make:";
            // 
            // lblInsCo
            // 
            lblInsCo.AutoSize = true;
            lblInsCo.Location = new System.Drawing.Point(59, 150);
            lblInsCo.Name = "lblInsCo";
            lblInsCo.Size = new System.Drawing.Size(111, 13);
            lblInsCo.TabIndex = 83;
            lblInsCo.Text = "Insurance Company:";
            // 
            // lblModel
            // 
            lblModel.AutoSize = true;
            lblModel.BackColor = System.Drawing.Color.Transparent;
            lblModel.Location = new System.Drawing.Point(59, 120);
            lblModel.Name = "lblModel";
            lblModel.Size = new System.Drawing.Size(43, 13);
            lblModel.TabIndex = 78;
            lblModel.Text = "Model:";
            // 
            // lblVehicleYear
            // 
            lblVehicleYear.AutoSize = true;
            lblVehicleYear.BackColor = System.Drawing.Color.Transparent;
            lblVehicleYear.Location = new System.Drawing.Point(59, 60);
            lblVehicleYear.Name = "lblVehicleYear";
            lblVehicleYear.Size = new System.Drawing.Size(69, 13);
            lblVehicleYear.TabIndex = 77;
            lblVehicleYear.Text = "Vehicle Year:";
            // 
            // cUSTOMER_STATELabel
            // 
            cUSTOMER_STATELabel.AutoSize = true;
            cUSTOMER_STATELabel.Location = new System.Drawing.Point(63, 174);
            cUSTOMER_STATELabel.Name = "cUSTOMER_STATELabel";
            cUSTOMER_STATELabel.Size = new System.Drawing.Size(39, 13);
            cUSTOMER_STATELabel.TabIndex = 85;
            cUSTOMER_STATELabel.Text = "STATE:";
            cUSTOMER_STATELabel.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // cUSTOMER_ZIP_1Label
            // 
            cUSTOMER_ZIP_1Label.AutoSize = true;
            cUSTOMER_ZIP_1Label.Location = new System.Drawing.Point(44, 196);
            cUSTOMER_ZIP_1Label.Name = "cUSTOMER_ZIP_1Label";
            cUSTOMER_ZIP_1Label.Size = new System.Drawing.Size(58, 13);
            cUSTOMER_ZIP_1Label.TabIndex = 88;
            cUSTOMER_ZIP_1Label.Text = "ZIP CODE:";
            cUSTOMER_ZIP_1Label.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // lblVIN
            // 
            lblVIN.AutoSize = true;
            lblVIN.BackColor = System.Drawing.Color.Transparent;
            lblVIN.Location = new System.Drawing.Point(59, 30);
            lblVIN.Name = "lblVIN";
            lblVIN.Size = new System.Drawing.Size(72, 13);
            lblVIN.TabIndex = 93;
            lblVIN.Text = "VIN Number:";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.BackColor = System.Drawing.Color.Transparent;
            label1.Location = new System.Drawing.Point(35, 42);
            label1.Name = "label1";
            label1.Size = new System.Drawing.Size(68, 13);
            label1.TabIndex = 92;
            label1.Text = "LAST NAME:";
            label1.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.BackColor = System.Drawing.Color.Transparent;
            label3.Location = new System.Drawing.Point(23, 53);
            label3.Name = "label3";
            label3.Size = new System.Drawing.Size(68, 13);
            label3.TabIndex = 96;
            label3.Text = "LAST NAME:";
            label3.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.BackColor = System.Drawing.Color.Transparent;
            label4.Location = new System.Drawing.Point(19, 75);
            label4.Name = "label4";
            label4.Size = new System.Drawing.Size(72, 13);
            label4.TabIndex = 95;
            label4.Text = "FIRST NAME:";
            label4.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new System.Drawing.Point(57, 229);
            label5.Name = "label5";
            label5.Size = new System.Drawing.Size(33, 13);
            label5.TabIndex = 102;
            label5.Text = "CELL:";
            label5.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Location = new System.Drawing.Point(47, 207);
            label6.Name = "label6";
            label6.Size = new System.Drawing.Size(43, 13);
            label6.TabIndex = 101;
            label6.Text = "WORK:";
            label6.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Location = new System.Drawing.Point(47, 185);
            label7.Name = "label7";
            label7.Size = new System.Drawing.Size(43, 13);
            label7.TabIndex = 100;
            label7.Text = "HOME:";
            label7.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // label8
            // 
            label8.AutoSize = true;
            label8.Location = new System.Drawing.Point(19, 31);
            label8.Name = "label8";
            label8.Size = new System.Drawing.Size(70, 13);
            label8.TabIndex = 106;
            label8.Text = "SS NUMBER:";
            label8.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // label9
            // 
            label9.AutoSize = true;
            label9.BackColor = System.Drawing.Color.Transparent;
            label9.Location = new System.Drawing.Point(32, 97);
            label9.Name = "label9";
            label9.Size = new System.Drawing.Size(58, 13);
            label9.TabIndex = 108;
            label9.Text = "ADDRESS:";
            label9.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // label10
            // 
            label10.AutoSize = true;
            label10.Location = new System.Drawing.Point(60, 119);
            label10.Name = "label10";
            label10.Size = new System.Drawing.Size(31, 13);
            label10.TabIndex = 110;
            label10.Text = "CITY:";
            label10.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // label11
            // 
            label11.AutoSize = true;
            label11.Location = new System.Drawing.Point(32, 163);
            label11.Name = "label11";
            label11.Size = new System.Drawing.Size(58, 13);
            label11.TabIndex = 113;
            label11.Text = "ZIP CODE:";
            label11.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // label12
            // 
            label12.AutoSize = true;
            label12.Location = new System.Drawing.Point(51, 141);
            label12.Name = "label12";
            label12.Size = new System.Drawing.Size(39, 13);
            label12.TabIndex = 115;
            label12.Text = "STATE:";
            label12.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // label13
            // 
            label13.AutoSize = true;
            label13.Location = new System.Drawing.Point(171, 141);
            label13.Name = "label13";
            label13.Size = new System.Drawing.Size(90, 13);
            label13.TabIndex = 117;
            label13.Text = "DATE  OF BIRTH:";
            label13.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // labelEXT
            // 
            labelEXT.AutoSize = true;
            labelEXT.Location = new System.Drawing.Point(195, 207);
            labelEXT.Name = "labelEXT";
            labelEXT.Size = new System.Drawing.Size(28, 13);
            labelEXT.TabIndex = 119;
            labelEXT.Text = "EXT:";
            labelEXT.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // cUSTOMER_PURCHASE_ORDERLabel
            // 
            cUSTOMER_PURCHASE_ORDERLabel.AutoSize = true;
            cUSTOMER_PURCHASE_ORDERLabel.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            cUSTOMER_PURCHASE_ORDERLabel.Location = new System.Drawing.Point(250, 18);
            cUSTOMER_PURCHASE_ORDERLabel.Name = "cUSTOMER_PURCHASE_ORDERLabel";
            cUSTOMER_PURCHASE_ORDERLabel.Size = new System.Drawing.Size(109, 15);
            cUSTOMER_PURCHASE_ORDERLabel.TabIndex = 118;
            cUSTOMER_PURCHASE_ORDERLabel.Text = "PURCHASE ORDER:";
            // 
            // label14
            // 
            label14.AutoSize = true;
            label14.Location = new System.Drawing.Point(61, 299);
            label14.Name = "label14";
            label14.Size = new System.Drawing.Size(41, 13);
            label14.TabIndex = 120;
            label14.Text = "EMAIL:";
            label14.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // CustomerbindingSource
            // 
            this.CustomerbindingSource.DataMember = "CustomerMail";
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
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Location = new System.Drawing.Point(12, 12);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(1026, 578);
            this.tabControl1.TabIndex = 18;
            this.tabControl1.SelectedIndexChanged += new System.EventHandler(this.tabControl1_SelectedIndexChanged);
            // 
            // tabPage1
            // 
            this.tabPage1.BackColor = System.Drawing.Color.LightSteelBlue;
            this.tabPage1.Controls.Add(this.dataGridViewCustLookup);
            this.tabPage1.Controls.Add(this.CustomerGroupBox);
            this.tabPage1.Location = new System.Drawing.Point(4, 29);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(1018, 545);
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
            this.CustomerActType,
            this.CustomerActStat,
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
            this.cUSTOMERDEALERDataGridViewTextBoxColumn,
            this.EmailAddress,
            this.CosignerEmail});
            this.dataGridViewCustLookup.DataSource = this.CustomerbindingSource;
            this.dataGridViewCustLookup.Location = new System.Drawing.Point(6, 350);
            this.dataGridViewCustLookup.Name = "dataGridViewCustLookup";
            this.dataGridViewCustLookup.ReadOnly = true;
            this.dataGridViewCustLookup.RowTemplate.Height = 24;
            this.dataGridViewCustLookup.Size = new System.Drawing.Size(1006, 196);
            this.dataGridViewCustLookup.TabIndex = 31;
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
            // CustomerActType
            // 
            this.CustomerActType.DataPropertyName = "CUSTOMER_IAC_TYPE";
            this.CustomerActType.HeaderText = "ACT TYPE";
            this.CustomerActType.Name = "CustomerActType";
            this.CustomerActType.ReadOnly = true;
            this.CustomerActType.Width = 40;
            // 
            // CustomerActStat
            // 
            this.CustomerActStat.DataPropertyName = "CUSTOMER_ACT_STAT";
            this.CustomerActStat.HeaderText = "ACT STAT";
            this.CustomerActStat.Name = "CustomerActStat";
            this.CustomerActStat.ReadOnly = true;
            this.CustomerActStat.Width = 40;
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
            // EmailAddress
            // 
            this.EmailAddress.DataPropertyName = "EmailAddress";
            this.EmailAddress.HeaderText = "EMAIL";
            this.EmailAddress.Name = "EmailAddress";
            this.EmailAddress.ReadOnly = true;
            // 
            // CosignerEmail
            // 
            this.CosignerEmail.DataPropertyName = "CosignerEmail";
            this.CosignerEmail.HeaderText = "COS EMAIL";
            this.CosignerEmail.Name = "CosignerEmail";
            this.CosignerEmail.ReadOnly = true;
            // 
            // CustomerGroupBox
            // 
            this.CustomerGroupBox.Controls.Add(this.NullableDateTimePickerSrchDOB);
            this.CustomerGroupBox.Controls.Add(label14);
            this.CustomerGroupBox.Controls.Add(this.richTextBoxEmailAddress);
            this.CustomerGroupBox.Controls.Add(this.cUSTOMER_PURCHASE_ORDERTextBox);
            this.CustomerGroupBox.Controls.Add(cUSTOMER_PURCHASE_ORDERLabel);
            this.CustomerGroupBox.Controls.Add(this.groupBoxCosigner);
            this.CustomerGroupBox.Controls.Add(label1);
            this.CustomerGroupBox.Controls.Add(this.btnSearch);
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
            this.CustomerGroupBox.Location = new System.Drawing.Point(81, 3);
            this.CustomerGroupBox.Name = "CustomerGroupBox";
            this.CustomerGroupBox.Size = new System.Drawing.Size(857, 341);
            this.CustomerGroupBox.TabIndex = 94;
            this.CustomerGroupBox.TabStop = false;
            this.CustomerGroupBox.Text = "Searchable Fields";
            // 
            // NullableDateTimePickerSrchDOB
            // 
            this.NullableDateTimePickerSrchDOB.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.NullableDateTimePickerSrchDOB.Location = new System.Drawing.Point(279, 165);
            this.NullableDateTimePickerSrchDOB.Name = "NullableDateTimePickerSrchDOB";
            this.NullableDateTimePickerSrchDOB.Size = new System.Drawing.Size(86, 22);
            this.NullableDateTimePickerSrchDOB.TabIndex = 121;
            this.NullableDateTimePickerSrchDOB.Value = new System.DateTime(2024, 12, 30, 0, 0, 0, 0);
            // 
            // richTextBoxEmailAddress
            // 
            this.richTextBoxEmailAddress.AllowDrop = true;
            this.richTextBoxEmailAddress.CharacterCasing = System.Windows.Forms.CharacterCasing.Lower;
            this.richTextBoxEmailAddress.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.richTextBoxEmailAddress.Location = new System.Drawing.Point(117, 290);
            this.richTextBoxEmailAddress.MaxLength = 50;
            this.richTextBoxEmailAddress.Name = "richTextBoxEmailAddress";
            this.richTextBoxEmailAddress.Size = new System.Drawing.Size(464, 22);
            this.richTextBoxEmailAddress.TabIndex = 119;
            // 
            // cUSTOMER_PURCHASE_ORDERTextBox
            // 
            this.cUSTOMER_PURCHASE_ORDERTextBox.AllowDrop = true;
            this.cUSTOMER_PURCHASE_ORDERTextBox.BackColor = System.Drawing.SystemColors.Window;
            this.cUSTOMER_PURCHASE_ORDERTextBox.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.cUSTOMER_PURCHASE_ORDERTextBox.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cUSTOMER_PURCHASE_ORDERTextBox.Location = new System.Drawing.Point(376, 10);
            this.cUSTOMER_PURCHASE_ORDERTextBox.Name = "cUSTOMER_PURCHASE_ORDERTextBox";
            this.cUSTOMER_PURCHASE_ORDERTextBox.Size = new System.Drawing.Size(67, 23);
            this.cUSTOMER_PURCHASE_ORDERTextBox.TabIndex = 117;
            this.cUSTOMER_PURCHASE_ORDERTextBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // groupBoxCosigner
            // 
            this.groupBoxCosigner.Controls.Add(this.nullableDateTimePickerCOSDOB);
            this.groupBoxCosigner.Controls.Add(labelEXT);
            this.groupBoxCosigner.Controls.Add(this.textBoxCOSWORKEXT);
            this.groupBoxCosigner.Controls.Add(label13);
            this.groupBoxCosigner.Controls.Add(this.COSIGNER_STATESrchTextBox);
            this.groupBoxCosigner.Controls.Add(label12);
            this.groupBoxCosigner.Controls.Add(this.COSIGNER_ZIPSrchTextBox);
            this.groupBoxCosigner.Controls.Add(label11);
            this.groupBoxCosigner.Controls.Add(this.COSIGNER_CITYSrchTextBox);
            this.groupBoxCosigner.Controls.Add(label10);
            this.groupBoxCosigner.Controls.Add(this.COSIGNER_STREETSrchTextBox);
            this.groupBoxCosigner.Controls.Add(label9);
            this.groupBoxCosigner.Controls.Add(this.COSIGNER_SS_3SrchTextBox);
            this.groupBoxCosigner.Controls.Add(this.COSIGNER_SS_2SrchTextBox);
            this.groupBoxCosigner.Controls.Add(this.COSIGNER_SS_1SrchTextBox);
            this.groupBoxCosigner.Controls.Add(label8);
            this.groupBoxCosigner.Controls.Add(this.COSIGNER_CELL_PHONESrchTextBox);
            this.groupBoxCosigner.Controls.Add(this.COSIGNER_WORK_PHONESrchTextBox);
            this.groupBoxCosigner.Controls.Add(this.COSIGNER__PHONE_NOSrchTextBox);
            this.groupBoxCosigner.Controls.Add(label5);
            this.groupBoxCosigner.Controls.Add(label6);
            this.groupBoxCosigner.Controls.Add(label7);
            this.groupBoxCosigner.Controls.Add(label3);
            this.groupBoxCosigner.Controls.Add(this.COSIGNER_LAST_NAMESrschTextBox);
            this.groupBoxCosigner.Controls.Add(this.COSIGNER_FIRST_NAMESRCHTextBox);
            this.groupBoxCosigner.Controls.Add(label4);
            this.groupBoxCosigner.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBoxCosigner.Location = new System.Drawing.Point(467, 18);
            this.groupBoxCosigner.Name = "groupBoxCosigner";
            this.groupBoxCosigner.Size = new System.Drawing.Size(365, 265);
            this.groupBoxCosigner.TabIndex = 116;
            this.groupBoxCosigner.TabStop = false;
            this.groupBoxCosigner.Text = "Cosigner Information";
            // 
            // nullableDateTimePickerCOSDOB
            // 
            this.nullableDateTimePickerCOSDOB.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.nullableDateTimePickerCOSDOB.Location = new System.Drawing.Point(267, 132);
            this.nullableDateTimePickerCOSDOB.Name = "nullableDateTimePickerCOSDOB";
            this.nullableDateTimePickerCOSDOB.Size = new System.Drawing.Size(86, 22);
            this.nullableDateTimePickerCOSDOB.TabIndex = 122;
            this.nullableDateTimePickerCOSDOB.Value = new System.DateTime(2024, 12, 30, 0, 0, 0, 0);
            // 
            // textBoxCOSWORKEXT
            // 
            this.textBoxCOSWORKEXT.Location = new System.Drawing.Point(224, 198);
            this.textBoxCOSWORKEXT.Name = "textBoxCOSWORKEXT";
            this.textBoxCOSWORKEXT.Size = new System.Drawing.Size(45, 22);
            this.textBoxCOSWORKEXT.TabIndex = 28;
            this.textBoxCOSWORKEXT.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.textBoxCOSWORKEXT.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.General_KeyPress);
            // 
            // COSIGNER_STATESrchTextBox
            // 
            this.COSIGNER_STATESrchTextBox.Location = new System.Drawing.Point(105, 132);
            this.COSIGNER_STATESrchTextBox.Name = "COSIGNER_STATESrchTextBox";
            this.COSIGNER_STATESrchTextBox.Size = new System.Drawing.Size(24, 22);
            this.COSIGNER_STATESrchTextBox.TabIndex = 23;
            this.COSIGNER_STATESrchTextBox.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.General_KeyPress);
            // 
            // COSIGNER_ZIPSrchTextBox
            // 
            this.COSIGNER_ZIPSrchTextBox.Location = new System.Drawing.Point(105, 154);
            this.COSIGNER_ZIPSrchTextBox.Name = "COSIGNER_ZIPSrchTextBox";
            this.COSIGNER_ZIPSrchTextBox.Size = new System.Drawing.Size(45, 22);
            this.COSIGNER_ZIPSrchTextBox.TabIndex = 25;
            this.COSIGNER_ZIPSrchTextBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.COSIGNER_ZIPSrchTextBox.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.General_KeyPress);
            // 
            // COSIGNER_CITYSrchTextBox
            // 
            this.COSIGNER_CITYSrchTextBox.Location = new System.Drawing.Point(105, 110);
            this.COSIGNER_CITYSrchTextBox.Name = "COSIGNER_CITYSrchTextBox";
            this.COSIGNER_CITYSrchTextBox.Size = new System.Drawing.Size(230, 22);
            this.COSIGNER_CITYSrchTextBox.TabIndex = 22;
            this.COSIGNER_CITYSrchTextBox.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.General_KeyPress);
            // 
            // COSIGNER_STREETSrchTextBox
            // 
            this.COSIGNER_STREETSrchTextBox.Location = new System.Drawing.Point(105, 88);
            this.COSIGNER_STREETSrchTextBox.Name = "COSIGNER_STREETSrchTextBox";
            this.COSIGNER_STREETSrchTextBox.Size = new System.Drawing.Size(230, 22);
            this.COSIGNER_STREETSrchTextBox.TabIndex = 21;
            this.COSIGNER_STREETSrchTextBox.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.General_KeyPress);
            // 
            // COSIGNER_SS_3SrchTextBox
            // 
            this.COSIGNER_SS_3SrchTextBox.Location = new System.Drawing.Point(159, 22);
            this.COSIGNER_SS_3SrchTextBox.Name = "COSIGNER_SS_3SrchTextBox";
            this.COSIGNER_SS_3SrchTextBox.Size = new System.Drawing.Size(37, 22);
            this.COSIGNER_SS_3SrchTextBox.TabIndex = 18;
            this.COSIGNER_SS_3SrchTextBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.COSIGNER_SS_3SrchTextBox.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.General_KeyPress);
            // 
            // COSIGNER_SS_2SrchTextBox
            // 
            this.COSIGNER_SS_2SrchTextBox.Location = new System.Drawing.Point(137, 22);
            this.COSIGNER_SS_2SrchTextBox.Name = "COSIGNER_SS_2SrchTextBox";
            this.COSIGNER_SS_2SrchTextBox.Size = new System.Drawing.Size(19, 22);
            this.COSIGNER_SS_2SrchTextBox.TabIndex = 17;
            this.COSIGNER_SS_2SrchTextBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.COSIGNER_SS_2SrchTextBox.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.General_KeyPress);
            // 
            // COSIGNER_SS_1SrchTextBox
            // 
            this.COSIGNER_SS_1SrchTextBox.Location = new System.Drawing.Point(105, 22);
            this.COSIGNER_SS_1SrchTextBox.Name = "COSIGNER_SS_1SrchTextBox";
            this.COSIGNER_SS_1SrchTextBox.Size = new System.Drawing.Size(29, 22);
            this.COSIGNER_SS_1SrchTextBox.TabIndex = 16;
            this.COSIGNER_SS_1SrchTextBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.COSIGNER_SS_1SrchTextBox.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.General_KeyPress);
            // 
            // COSIGNER_CELL_PHONESrchTextBox
            // 
            this.COSIGNER_CELL_PHONESrchTextBox.Location = new System.Drawing.Point(105, 220);
            this.COSIGNER_CELL_PHONESrchTextBox.Mask = "(999) 000-0000";
            this.COSIGNER_CELL_PHONESrchTextBox.Name = "COSIGNER_CELL_PHONESrchTextBox";
            this.COSIGNER_CELL_PHONESrchTextBox.Size = new System.Drawing.Size(78, 22);
            this.COSIGNER_CELL_PHONESrchTextBox.TabIndex = 29;
            this.COSIGNER_CELL_PHONESrchTextBox.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.General_KeyPress);
            // 
            // COSIGNER_WORK_PHONESrchTextBox
            // 
            this.COSIGNER_WORK_PHONESrchTextBox.Location = new System.Drawing.Point(105, 198);
            this.COSIGNER_WORK_PHONESrchTextBox.Mask = "(999) 000-0000";
            this.COSIGNER_WORK_PHONESrchTextBox.Name = "COSIGNER_WORK_PHONESrchTextBox";
            this.COSIGNER_WORK_PHONESrchTextBox.Size = new System.Drawing.Size(78, 22);
            this.COSIGNER_WORK_PHONESrchTextBox.TabIndex = 27;
            this.COSIGNER_WORK_PHONESrchTextBox.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.General_KeyPress);
            // 
            // COSIGNER__PHONE_NOSrchTextBox
            // 
            this.COSIGNER__PHONE_NOSrchTextBox.Location = new System.Drawing.Point(105, 176);
            this.COSIGNER__PHONE_NOSrchTextBox.Mask = "(999) 000-0000";
            this.COSIGNER__PHONE_NOSrchTextBox.Name = "COSIGNER__PHONE_NOSrchTextBox";
            this.COSIGNER__PHONE_NOSrchTextBox.Size = new System.Drawing.Size(78, 22);
            this.COSIGNER__PHONE_NOSrchTextBox.TabIndex = 26;
            this.COSIGNER__PHONE_NOSrchTextBox.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.General_KeyPress);
            // 
            // COSIGNER_LAST_NAMESrschTextBox
            // 
            this.COSIGNER_LAST_NAMESrschTextBox.Location = new System.Drawing.Point(105, 44);
            this.COSIGNER_LAST_NAMESrschTextBox.Name = "COSIGNER_LAST_NAMESrschTextBox";
            this.COSIGNER_LAST_NAMESrschTextBox.Size = new System.Drawing.Size(131, 22);
            this.COSIGNER_LAST_NAMESrschTextBox.TabIndex = 19;
            this.COSIGNER_LAST_NAMESrschTextBox.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.General_KeyPress);
            // 
            // COSIGNER_FIRST_NAMESRCHTextBox
            // 
            this.COSIGNER_FIRST_NAMESRCHTextBox.Location = new System.Drawing.Point(105, 66);
            this.COSIGNER_FIRST_NAMESRCHTextBox.Name = "COSIGNER_FIRST_NAMESRCHTextBox";
            this.COSIGNER_FIRST_NAMESRCHTextBox.Size = new System.Drawing.Size(131, 22);
            this.COSIGNER_FIRST_NAMESRCHTextBox.TabIndex = 20;
            this.COSIGNER_FIRST_NAMESRCHTextBox.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.General_KeyPress);
            // 
            // btnSearch
            // 
            this.btnSearch.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSearch.Location = new System.Drawing.Point(716, 289);
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.Size = new System.Drawing.Size(106, 37);
            this.btnSearch.TabIndex = 30;
            this.btnSearch.Text = "Search";
            this.btnSearch.UseVisualStyleBackColor = true;
            this.btnSearch.Click += new System.EventHandler(this.btnSearch_Click);
            // 
            // cUSTOMER_CONTACTSrchTextBox
            // 
            this.cUSTOMER_CONTACTSrchTextBox.Location = new System.Drawing.Point(117, 77);
            this.cUSTOMER_CONTACTSrchTextBox.Name = "cUSTOMER_CONTACTSrchTextBox";
            this.cUSTOMER_CONTACTSrchTextBox.Size = new System.Drawing.Size(230, 22);
            this.cUSTOMER_CONTACTSrchTextBox.TabIndex = 5;
            this.cUSTOMER_CONTACTSrchTextBox.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.General_KeyPress);
            // 
            // cUSTOMER_SS_3SrchTextBox
            // 
            this.cUSTOMER_SS_3SrchTextBox.Location = new System.Drawing.Point(171, 11);
            this.cUSTOMER_SS_3SrchTextBox.Name = "cUSTOMER_SS_3SrchTextBox";
            this.cUSTOMER_SS_3SrchTextBox.Size = new System.Drawing.Size(37, 22);
            this.cUSTOMER_SS_3SrchTextBox.TabIndex = 2;
            this.cUSTOMER_SS_3SrchTextBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.cUSTOMER_SS_3SrchTextBox.TextChanged += new System.EventHandler(this.cUSTOMER_SS_3SrchTextBox_TextChanged);
            this.cUSTOMER_SS_3SrchTextBox.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.General_KeyPress);
            // 
            // cUSTOMER_SS_2SrchTextBox
            // 
            this.cUSTOMER_SS_2SrchTextBox.Location = new System.Drawing.Point(149, 11);
            this.cUSTOMER_SS_2SrchTextBox.Name = "cUSTOMER_SS_2SrchTextBox";
            this.cUSTOMER_SS_2SrchTextBox.Size = new System.Drawing.Size(19, 22);
            this.cUSTOMER_SS_2SrchTextBox.TabIndex = 1;
            this.cUSTOMER_SS_2SrchTextBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.cUSTOMER_SS_2SrchTextBox.TextChanged += new System.EventHandler(this.cUSTOMER_SS_2SrchTextBox_TextChanged);
            this.cUSTOMER_SS_2SrchTextBox.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.General_KeyPress);
            // 
            // cUSTOMER_SS_1SrchTextBox
            // 
            this.cUSTOMER_SS_1SrchTextBox.Location = new System.Drawing.Point(117, 11);
            this.cUSTOMER_SS_1SrchTextBox.Name = "cUSTOMER_SS_1SrchTextBox";
            this.cUSTOMER_SS_1SrchTextBox.Size = new System.Drawing.Size(29, 22);
            this.cUSTOMER_SS_1SrchTextBox.TabIndex = 0;
            this.cUSTOMER_SS_1SrchTextBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.cUSTOMER_SS_1SrchTextBox.TextChanged += new System.EventHandler(this.cUSTOMER_SS_1SrchTextBox_TextChanged);
            this.cUSTOMER_SS_1SrchTextBox.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.General_KeyPress);
            // 
            // cUSTOMER_ZIP_2SrchTextBox
            // 
            this.cUSTOMER_ZIP_2SrchTextBox.Location = new System.Drawing.Point(165, 187);
            this.cUSTOMER_ZIP_2SrchTextBox.Name = "cUSTOMER_ZIP_2SrchTextBox";
            this.cUSTOMER_ZIP_2SrchTextBox.Size = new System.Drawing.Size(45, 22);
            this.cUSTOMER_ZIP_2SrchTextBox.TabIndex = 11;
            this.cUSTOMER_ZIP_2SrchTextBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.cUSTOMER_ZIP_2SrchTextBox.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.General_KeyPress);
            // 
            // cUSTOMER_ZIP_1SrchTextBox
            // 
            this.cUSTOMER_ZIP_1SrchTextBox.Location = new System.Drawing.Point(117, 187);
            this.cUSTOMER_ZIP_1SrchTextBox.Name = "cUSTOMER_ZIP_1SrchTextBox";
            this.cUSTOMER_ZIP_1SrchTextBox.Size = new System.Drawing.Size(45, 22);
            this.cUSTOMER_ZIP_1SrchTextBox.TabIndex = 10;
            this.cUSTOMER_ZIP_1SrchTextBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.cUSTOMER_ZIP_1SrchTextBox.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.General_KeyPress);
            // 
            // cUSTOMER_STATESrchTextBox
            // 
            this.cUSTOMER_STATESrchTextBox.Location = new System.Drawing.Point(117, 165);
            this.cUSTOMER_STATESrchTextBox.Name = "cUSTOMER_STATESrchTextBox";
            this.cUSTOMER_STATESrchTextBox.Size = new System.Drawing.Size(24, 22);
            this.cUSTOMER_STATESrchTextBox.TabIndex = 9;
            this.cUSTOMER_STATESrchTextBox.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.General_KeyPress);
            // 
            // cUSTOMER_CITYSrchTextBox
            // 
            this.cUSTOMER_CITYSrchTextBox.Location = new System.Drawing.Point(117, 143);
            this.cUSTOMER_CITYSrchTextBox.Name = "cUSTOMER_CITYSrchTextBox";
            this.cUSTOMER_CITYSrchTextBox.Size = new System.Drawing.Size(230, 22);
            this.cUSTOMER_CITYSrchTextBox.TabIndex = 8;
            this.cUSTOMER_CITYSrchTextBox.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.General_KeyPress);
            // 
            // cUSTOMER_STREET_2SrchTextBox
            // 
            this.cUSTOMER_STREET_2SrchTextBox.Location = new System.Drawing.Point(117, 121);
            this.cUSTOMER_STREET_2SrchTextBox.Name = "cUSTOMER_STREET_2SrchTextBox";
            this.cUSTOMER_STREET_2SrchTextBox.Size = new System.Drawing.Size(230, 22);
            this.cUSTOMER_STREET_2SrchTextBox.TabIndex = 7;
            this.cUSTOMER_STREET_2SrchTextBox.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.General_KeyPress);
            // 
            // cUSTOMER_STREET_1SrchTextBox
            // 
            this.cUSTOMER_STREET_1SrchTextBox.Location = new System.Drawing.Point(117, 99);
            this.cUSTOMER_STREET_1SrchTextBox.Name = "cUSTOMER_STREET_1SrchTextBox";
            this.cUSTOMER_STREET_1SrchTextBox.Size = new System.Drawing.Size(230, 22);
            this.cUSTOMER_STREET_1SrchTextBox.TabIndex = 6;
            this.cUSTOMER_STREET_1SrchTextBox.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.General_KeyPress);
            // 
            // cUSTOMER_LAST_NAMESrschTextBox
            // 
            this.cUSTOMER_LAST_NAMESrschTextBox.Location = new System.Drawing.Point(117, 33);
            this.cUSTOMER_LAST_NAMESrschTextBox.Name = "cUSTOMER_LAST_NAMESrschTextBox";
            this.cUSTOMER_LAST_NAMESrschTextBox.Size = new System.Drawing.Size(131, 22);
            this.cUSTOMER_LAST_NAMESrschTextBox.TabIndex = 3;
            this.cUSTOMER_LAST_NAMESrschTextBox.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.General_KeyPress);
            // 
            // cUSTOMER_FIRST_NAMESRCHTextBox
            // 
            this.cUSTOMER_FIRST_NAMESRCHTextBox.Location = new System.Drawing.Point(117, 55);
            this.cUSTOMER_FIRST_NAMESRCHTextBox.Name = "cUSTOMER_FIRST_NAMESRCHTextBox";
            this.cUSTOMER_FIRST_NAMESRCHTextBox.Size = new System.Drawing.Size(131, 22);
            this.cUSTOMER_FIRST_NAMESRCHTextBox.TabIndex = 4;
            this.cUSTOMER_FIRST_NAMESRCHTextBox.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.General_KeyPress);
            // 
            // cUSTOMER_CELL_PHONESrchTextBox
            // 
            this.cUSTOMER_CELL_PHONESrchTextBox.Location = new System.Drawing.Point(117, 253);
            this.cUSTOMER_CELL_PHONESrchTextBox.Mask = "(999) 000-0000";
            this.cUSTOMER_CELL_PHONESrchTextBox.Name = "cUSTOMER_CELL_PHONESrchTextBox";
            this.cUSTOMER_CELL_PHONESrchTextBox.Size = new System.Drawing.Size(78, 22);
            this.cUSTOMER_CELL_PHONESrchTextBox.TabIndex = 15;
            this.cUSTOMER_CELL_PHONESrchTextBox.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.General_KeyPress);
            // 
            // cUSTOMER_WORK_PHONESrchTextBox
            // 
            this.cUSTOMER_WORK_PHONESrchTextBox.Location = new System.Drawing.Point(117, 231);
            this.cUSTOMER_WORK_PHONESrchTextBox.Mask = "(999) 000-0000";
            this.cUSTOMER_WORK_PHONESrchTextBox.Name = "cUSTOMER_WORK_PHONESrchTextBox";
            this.cUSTOMER_WORK_PHONESrchTextBox.Size = new System.Drawing.Size(78, 22);
            this.cUSTOMER_WORK_PHONESrchTextBox.TabIndex = 14;
            this.cUSTOMER_WORK_PHONESrchTextBox.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.General_KeyPress);
            // 
            // cUSTOMER__PHONE_NOSrchTextBox
            // 
            this.cUSTOMER__PHONE_NOSrchTextBox.Location = new System.Drawing.Point(117, 209);
            this.cUSTOMER__PHONE_NOSrchTextBox.Mask = "(999) 000-0000";
            this.cUSTOMER__PHONE_NOSrchTextBox.Name = "cUSTOMER__PHONE_NOSrchTextBox";
            this.cUSTOMER__PHONE_NOSrchTextBox.Size = new System.Drawing.Size(78, 22);
            this.cUSTOMER__PHONE_NOSrchTextBox.TabIndex = 13;
            this.cUSTOMER__PHONE_NOSrchTextBox.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.General_KeyPress);
            // 
            // tabPage2
            // 
            this.tabPage2.BackColor = System.Drawing.Color.LightSteelBlue;
            this.tabPage2.Controls.Add(this.dataGridViewVehicleLookup);
            this.tabPage2.Controls.Add(this.VehicleGroupBox);
            this.tabPage2.Location = new System.Drawing.Point(4, 29);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(1018, 545);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "Vehicle Information";
            // 
            // dataGridViewVehicleLookup
            // 
            this.dataGridViewVehicleLookup.AllowUserToAddRows = false;
            this.dataGridViewVehicleLookup.AllowUserToDeleteRows = false;
            this.dataGridViewVehicleLookup.AllowUserToOrderColumns = true;
            this.dataGridViewVehicleLookup.AutoGenerateColumns = false;
            this.dataGridViewVehicleLookup.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewVehicleLookup.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.vEHICLECUSTNODataGridViewTextBoxColumn,
            this.CUSTOMER_FIRST_NAME,
            this.CUSTOMER_LAST_NAME,
            this.vEHICLEYEARDataGridViewTextBoxColumn,
            this.vEHICLEMAKEDataGridViewTextBoxColumn,
            this.vEHICLEMODELDataGridViewTextBoxColumn,
            this.vEHICLEVINDataGridViewTextBoxColumn,
            this.vEHICLEINSCOMPANYDataGridViewTextBoxColumn,
            this.vEHICLEPOLICYNODataGridViewTextBoxColumn});
            this.dataGridViewVehicleLookup.DataSource = this.Vehicle_CustomerbindingSource;
            this.dataGridViewVehicleLookup.Location = new System.Drawing.Point(5, 256);
            this.dataGridViewVehicleLookup.Name = "dataGridViewVehicleLookup";
            this.dataGridViewVehicleLookup.ReadOnly = true;
            this.dataGridViewVehicleLookup.RowTemplate.Height = 24;
            this.dataGridViewVehicleLookup.Size = new System.Drawing.Size(1009, 290);
            this.dataGridViewVehicleLookup.TabIndex = 25;
            this.dataGridViewVehicleLookup.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridViewVehicleLookup_CellDoubleClick);
            this.dataGridViewVehicleLookup.DataBindingComplete += new System.Windows.Forms.DataGridViewBindingCompleteEventHandler(this.dataGridViewVehicleLookup_DataBindingComplete);
            // 
            // vEHICLECUSTNODataGridViewTextBoxColumn
            // 
            this.vEHICLECUSTNODataGridViewTextBoxColumn.DataPropertyName = "VEHICLE_CUST_NO";
            this.vEHICLECUSTNODataGridViewTextBoxColumn.HeaderText = "CUST NO.";
            this.vEHICLECUSTNODataGridViewTextBoxColumn.Name = "vEHICLECUSTNODataGridViewTextBoxColumn";
            this.vEHICLECUSTNODataGridViewTextBoxColumn.ReadOnly = true;
            this.vEHICLECUSTNODataGridViewTextBoxColumn.Width = 50;
            // 
            // CUSTOMER_FIRST_NAME
            // 
            this.CUSTOMER_FIRST_NAME.DataPropertyName = "CUSTOMER_FIRST_NAME";
            this.CUSTOMER_FIRST_NAME.HeaderText = "FIRST NAME";
            this.CUSTOMER_FIRST_NAME.Name = "CUSTOMER_FIRST_NAME";
            this.CUSTOMER_FIRST_NAME.ReadOnly = true;
            this.CUSTOMER_FIRST_NAME.Width = 80;
            // 
            // CUSTOMER_LAST_NAME
            // 
            this.CUSTOMER_LAST_NAME.DataPropertyName = "CUSTOMER_LAST_NAME";
            this.CUSTOMER_LAST_NAME.HeaderText = "LAST NAME";
            this.CUSTOMER_LAST_NAME.Name = "CUSTOMER_LAST_NAME";
            this.CUSTOMER_LAST_NAME.ReadOnly = true;
            // 
            // vEHICLEYEARDataGridViewTextBoxColumn
            // 
            this.vEHICLEYEARDataGridViewTextBoxColumn.DataPropertyName = "VEHICLE_YEAR";
            this.vEHICLEYEARDataGridViewTextBoxColumn.HeaderText = "YEAR";
            this.vEHICLEYEARDataGridViewTextBoxColumn.Name = "vEHICLEYEARDataGridViewTextBoxColumn";
            this.vEHICLEYEARDataGridViewTextBoxColumn.ReadOnly = true;
            this.vEHICLEYEARDataGridViewTextBoxColumn.Width = 45;
            // 
            // vEHICLEMAKEDataGridViewTextBoxColumn
            // 
            this.vEHICLEMAKEDataGridViewTextBoxColumn.DataPropertyName = "VEHICLE_MAKE";
            this.vEHICLEMAKEDataGridViewTextBoxColumn.HeaderText = "MAKE";
            this.vEHICLEMAKEDataGridViewTextBoxColumn.Name = "vEHICLEMAKEDataGridViewTextBoxColumn";
            this.vEHICLEMAKEDataGridViewTextBoxColumn.ReadOnly = true;
            this.vEHICLEMAKEDataGridViewTextBoxColumn.Width = 80;
            // 
            // vEHICLEMODELDataGridViewTextBoxColumn
            // 
            this.vEHICLEMODELDataGridViewTextBoxColumn.DataPropertyName = "VEHICLE_MODEL";
            this.vEHICLEMODELDataGridViewTextBoxColumn.HeaderText = "MODEL";
            this.vEHICLEMODELDataGridViewTextBoxColumn.Name = "vEHICLEMODELDataGridViewTextBoxColumn";
            this.vEHICLEMODELDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // vEHICLEVINDataGridViewTextBoxColumn
            // 
            this.vEHICLEVINDataGridViewTextBoxColumn.DataPropertyName = "VEHICLE_VIN";
            this.vEHICLEVINDataGridViewTextBoxColumn.HeaderText = "VIN NUMBER";
            this.vEHICLEVINDataGridViewTextBoxColumn.Name = "vEHICLEVINDataGridViewTextBoxColumn";
            this.vEHICLEVINDataGridViewTextBoxColumn.ReadOnly = true;
            this.vEHICLEVINDataGridViewTextBoxColumn.Width = 180;
            // 
            // vEHICLEINSCOMPANYDataGridViewTextBoxColumn
            // 
            this.vEHICLEINSCOMPANYDataGridViewTextBoxColumn.DataPropertyName = "VEHICLE_INS_COMPANY";
            this.vEHICLEINSCOMPANYDataGridViewTextBoxColumn.HeaderText = "INSURANCE COMPANY";
            this.vEHICLEINSCOMPANYDataGridViewTextBoxColumn.Name = "vEHICLEINSCOMPANYDataGridViewTextBoxColumn";
            this.vEHICLEINSCOMPANYDataGridViewTextBoxColumn.ReadOnly = true;
            this.vEHICLEINSCOMPANYDataGridViewTextBoxColumn.Width = 180;
            // 
            // vEHICLEPOLICYNODataGridViewTextBoxColumn
            // 
            this.vEHICLEPOLICYNODataGridViewTextBoxColumn.DataPropertyName = "VEHICLE_POLICY_NO";
            this.vEHICLEPOLICYNODataGridViewTextBoxColumn.HeaderText = "POLICY NUMBER";
            this.vEHICLEPOLICYNODataGridViewTextBoxColumn.Name = "vEHICLEPOLICYNODataGridViewTextBoxColumn";
            this.vEHICLEPOLICYNODataGridViewTextBoxColumn.ReadOnly = true;
            this.vEHICLEPOLICYNODataGridViewTextBoxColumn.Width = 180;
            // 
            // Vehicle_CustomerbindingSource
            // 
            this.Vehicle_CustomerbindingSource.DataMember = "Customer_Vehicle";
            this.Vehicle_CustomerbindingSource.DataSource = this.iacDataSet1;
            // 
            // VehicleGroupBox
            // 
            this.VehicleGroupBox.Controls.Add(this.txtVIN);
            this.VehicleGroupBox.Controls.Add(lblVIN);
            this.VehicleGroupBox.Controls.Add(this.buttonVehicleSearch);
            this.VehicleGroupBox.Controls.Add(lblMake);
            this.VehicleGroupBox.Controls.Add(this.txtMake);
            this.VehicleGroupBox.Controls.Add(this.txtInsuranceCompany);
            this.VehicleGroupBox.Controls.Add(this.txtModel);
            this.VehicleGroupBox.Controls.Add(this.txtVehicleYear);
            this.VehicleGroupBox.Controls.Add(lblInsCo);
            this.VehicleGroupBox.Controls.Add(lblModel);
            this.VehicleGroupBox.Controls.Add(lblVehicleYear);
            this.VehicleGroupBox.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.VehicleGroupBox.Location = new System.Drawing.Point(268, 8);
            this.VehicleGroupBox.Name = "VehicleGroupBox";
            this.VehicleGroupBox.Size = new System.Drawing.Size(482, 242);
            this.VehicleGroupBox.TabIndex = 96;
            this.VehicleGroupBox.TabStop = false;
            this.VehicleGroupBox.Text = "Searchable Fields";
            // 
            // txtVIN
            // 
            this.txtVIN.Location = new System.Drawing.Point(174, 23);
            this.txtVIN.Name = "txtVIN";
            this.txtVIN.Size = new System.Drawing.Size(120, 22);
            this.txtVIN.TabIndex = 19;
            this.txtVIN.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.General_KeyPress);
            // 
            // buttonVehicleSearch
            // 
            this.buttonVehicleSearch.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonVehicleSearch.Location = new System.Drawing.Point(188, 188);
            this.buttonVehicleSearch.Name = "buttonVehicleSearch";
            this.buttonVehicleSearch.Size = new System.Drawing.Size(106, 37);
            this.buttonVehicleSearch.TabIndex = 24;
            this.buttonVehicleSearch.Text = "Search";
            this.buttonVehicleSearch.UseVisualStyleBackColor = true;
            this.buttonVehicleSearch.Click += new System.EventHandler(this.buttonVehicleSearch_Click);
            // 
            // txtMake
            // 
            this.txtMake.Location = new System.Drawing.Point(174, 83);
            this.txtMake.Name = "txtMake";
            this.txtMake.Size = new System.Drawing.Size(120, 22);
            this.txtMake.TabIndex = 21;
            this.txtMake.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.General_KeyPress);
            // 
            // txtInsuranceCompany
            // 
            this.txtInsuranceCompany.Location = new System.Drawing.Point(174, 143);
            this.txtInsuranceCompany.Name = "txtInsuranceCompany";
            this.txtInsuranceCompany.Size = new System.Drawing.Size(230, 22);
            this.txtInsuranceCompany.TabIndex = 23;
            this.txtInsuranceCompany.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.General_KeyPress);
            // 
            // txtModel
            // 
            this.txtModel.Location = new System.Drawing.Point(174, 113);
            this.txtModel.Name = "txtModel";
            this.txtModel.Size = new System.Drawing.Size(120, 22);
            this.txtModel.TabIndex = 22;
            this.txtModel.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.General_KeyPress);
            // 
            // txtVehicleYear
            // 
            this.txtVehicleYear.Location = new System.Drawing.Point(174, 53);
            this.txtVehicleYear.Name = "txtVehicleYear";
            this.txtVehicleYear.Size = new System.Drawing.Size(47, 22);
            this.txtVehicleYear.TabIndex = 20;
            this.txtVehicleYear.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.General_KeyPress);
            // 
            // customer_VehicleTableAdapter
            // 
            this.customer_VehicleTableAdapter.ClearBeforeFill = true;
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
            this.bindingNavigator1.Location = new System.Drawing.Point(0, 593);
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
            this.bindingNavigatorPositionItem.Font = new System.Drawing.Font("Segoe UI", 9F);
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
            // customerMailTableAdapter
            // 
            this.customerMailTableAdapter.ClearBeforeFill = true;
            // 
            // frmCustomerLookup
            // 
            this.Appearance.BackColor = System.Drawing.Color.CornflowerBlue;
            this.Appearance.Options.UseBackColor = true;
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.ClientSize = new System.Drawing.Size(1050, 618);
            this.Controls.Add(this.bindingNavigator1);
            this.Controls.Add(this.tabControl1);
            this.LookAndFeel.SkinName = "McSkin";
            this.LookAndFeel.UseDefaultLookAndFeel = false;
            this.MaximizeBox = false;
            this.Name = "frmCustomerLookup";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Closed Customer Lookup";
            this.Load += new System.EventHandler(this.frmCustomerLookup_Load);
            ((System.ComponentModel.ISupportInitialize)(this.CustomerbindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.iacDataSet1)).EndInit();
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewCustLookup)).EndInit();
            this.CustomerGroupBox.ResumeLayout(false);
            this.CustomerGroupBox.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.NullableDateTimePickerSrchDOB)).EndInit();
            this.groupBoxCosigner.ResumeLayout(false);
            this.groupBoxCosigner.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nullableDateTimePickerCOSDOB)).EndInit();
            this.tabPage2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewVehicleLookup)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Vehicle_CustomerbindingSource)).EndInit();
            this.VehicleGroupBox.ResumeLayout(false);
            this.VehicleGroupBox.PerformLayout();
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
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.DataGridView dataGridViewCustLookup;
        private System.Windows.Forms.GroupBox CustomerGroupBox;
        private System.Windows.Forms.Button btnSearch;
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
        private System.Windows.Forms.DataGridView dataGridViewVehicleLookup;
        private System.Windows.Forms.GroupBox VehicleGroupBox;
        private System.Windows.Forms.Button buttonVehicleSearch;
        private System.Windows.Forms.TextBox txtMake;
        private System.Windows.Forms.TextBox txtInsuranceCompany;
        private System.Windows.Forms.TextBox txtModel;
        private System.Windows.Forms.TextBox txtVehicleYear;
        private System.Windows.Forms.TextBox cUSTOMER_ZIP_2SrchTextBox;
        private System.Windows.Forms.TextBox cUSTOMER_ZIP_1SrchTextBox;
        private System.Windows.Forms.TextBox cUSTOMER_STATESrchTextBox;
        private System.Windows.Forms.TextBox txtVIN;
        private System.Windows.Forms.BindingSource Vehicle_CustomerbindingSource;
        private IACDataSetTableAdapters.Customer_VehicleTableAdapter customer_VehicleTableAdapter;
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
        private System.Windows.Forms.MaskedTextBox COSIGNER_CELL_PHONESrchTextBox;
        private System.Windows.Forms.MaskedTextBox COSIGNER_WORK_PHONESrchTextBox;
        private System.Windows.Forms.MaskedTextBox COSIGNER__PHONE_NOSrchTextBox;
        private System.Windows.Forms.TextBox COSIGNER_LAST_NAMESrschTextBox;
        private System.Windows.Forms.TextBox COSIGNER_FIRST_NAMESRCHTextBox;
        private System.Windows.Forms.TextBox COSIGNER_CITYSrchTextBox;
        private System.Windows.Forms.TextBox COSIGNER_STREETSrchTextBox;
        private System.Windows.Forms.TextBox COSIGNER_SS_3SrchTextBox;
        private System.Windows.Forms.TextBox COSIGNER_SS_2SrchTextBox;
        private System.Windows.Forms.TextBox COSIGNER_SS_1SrchTextBox;
        private System.Windows.Forms.GroupBox groupBoxCosigner;
        private System.Windows.Forms.TextBox COSIGNER_STATESrchTextBox;
        private System.Windows.Forms.TextBox COSIGNER_ZIPSrchTextBox;
        private System.Windows.Forms.TextBox textBoxCOSWORKEXT;
        private System.Windows.Forms.TextBox cUSTOMER_PURCHASE_ORDERTextBox;
        private System.Windows.Forms.TextBox richTextBoxEmailAddress;
        private IACDataSetTableAdapters.CustomerMailTableAdapter customerMailTableAdapter;
        private ProManApp.NullableDateTimePicker NullableDateTimePickerSrchDOB;
        private ProManApp.NullableDateTimePicker nullableDateTimePickerCOSDOB;
        private System.Windows.Forms.DataGridViewTextBoxColumn cUSTOMERNODataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn CustomerActType;
        private System.Windows.Forms.DataGridViewTextBoxColumn CustomerActStat;
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
        private System.Windows.Forms.DataGridViewTextBoxColumn EmailAddress;
        private System.Windows.Forms.DataGridViewTextBoxColumn CosignerEmail;
        private System.Windows.Forms.DataGridViewTextBoxColumn vEHICLECUSTNODataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn CUSTOMER_FIRST_NAME;
        private System.Windows.Forms.DataGridViewTextBoxColumn CUSTOMER_LAST_NAME;
        private System.Windows.Forms.DataGridViewTextBoxColumn vEHICLEYEARDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn vEHICLEMAKEDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn vEHICLEMODELDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn vEHICLEVINDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn vEHICLEINSCOMPANYDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn vEHICLEPOLICYNODataGridViewTextBoxColumn;
    }
}
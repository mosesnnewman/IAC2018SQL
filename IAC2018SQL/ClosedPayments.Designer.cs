namespace IAC2021SQL
{
    partial class formClosedPayment
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
            System.Windows.Forms.Label label7;
            System.Windows.Forms.Label label6;
            System.Windows.Forms.Label label5;
            System.Windows.Forms.Label label4;
            System.Windows.Forms.Label label3;
            System.Windows.Forms.Label label2;
            System.Windows.Forms.Label label14;
            System.Windows.Forms.Label label34;
            System.Windows.Forms.Label label36;
            System.Windows.Forms.Label label31;
            System.Windows.Forms.Label label8;
            System.Windows.Forms.Label label1;
            System.Windows.Forms.Label label9;
            System.Windows.Forms.Label label10;
            System.Windows.Forms.Label label11;
            System.Windows.Forms.Label label12;
            System.Windows.Forms.Label label15;
            System.Windows.Forms.Label label16;
            System.Windows.Forms.Label label17;
            System.Windows.Forms.Label label18;
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(formClosedPayment));
            this.CustomerbindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.ClosedPaymentiacDataSet = new IAC2021SQL.IACDataSet();
            this.cUSTOMERTableAdapter = new IAC2021SQL.IACDataSetTableAdapters.CUSTOMERTableAdapter();
            this.PaymentTypebindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.pAYMENTTYPETableAdapter = new IAC2021SQL.IACDataSetTableAdapters.PAYMENTTYPETableAdapter();
            this.DealerbindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.dEALERTableAdapter = new IAC2021SQL.IACDataSetTableAdapters.DEALERTableAdapter();
            this.PAYCODEbindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.pAYCODETableAdapter = new IAC2021SQL.IACDataSetTableAdapters.PAYCODETableAdapter();
            this.tabClosedPayments = new DevExpress.XtraTab.XtraTabControl();
            this.tabPayment = new DevExpress.XtraTab.XtraTabPage();
            this.groupControl1 = new DevExpress.XtraEditors.GroupControl();
            this.bindingNavigator = new System.Windows.Forms.BindingNavigator(this.components);
            this.PaymentbindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.bindingNavigatorCountItem = new System.Windows.Forms.ToolStripLabel();
            this.bindingNavigatorMoveFirstItem = new System.Windows.Forms.ToolStripButton();
            this.bindingNavigatorMovePreviousItem = new System.Windows.Forms.ToolStripButton();
            this.bindingNavigatorSeparator = new System.Windows.Forms.ToolStripSeparator();
            this.bindingNavigatorPositionItem = new System.Windows.Forms.ToolStripTextBox();
            this.bindingNavigatorSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.bindingNavigatorMoveNextItem = new System.Windows.Forms.ToolStripButton();
            this.bindingNavigatorMoveLastItem = new System.Windows.Forms.ToolStripButton();
            this.bindingNavigatorSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripButton2 = new System.Windows.Forms.ToolStripButton();
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.toolStripButton1 = new System.Windows.Forms.ToolStripButton();
            this.toolStripButtonAdd = new System.Windows.Forms.ToolStripButton();
            this.toolStripButtonEdit = new System.Windows.Forms.ToolStripButton();
            this.toolStripButtonDelete = new System.Windows.Forms.ToolStripButton();
            this.toolStripButtonSave = new System.Windows.Forms.ToolStripButton();
            this.toolStripButtonCancel = new System.Windows.Forms.ToolStripButton();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.lookUpEditCodeType = new DevExpress.XtraEditors.LookUpEdit();
            this.lookUpEditPaymentType = new DevExpress.XtraEditors.LookUpEdit();
            this.checkBoxNoAdjLookBack = new System.Windows.Forms.CheckBox();
            this.listBoxTSBCommentCode = new System.Windows.Forms.ListBox();
            this.specialCommentCodesBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.buttonChangeISFDate = new DevExpress.XtraEditors.SimpleButton();
            this.textBoxISFDate = new System.Windows.Forms.TextBox();
            this.PaidThroughUDtextBox = new System.Windows.Forms.TextBox();
            this.txtIncome = new System.Windows.Forms.TextBox();
            this.txtOverPayment = new System.Windows.Forms.TextBox();
            this.EFTtextBox = new System.Windows.Forms.TextBox();
            this.txtCheckValue = new System.Windows.Forms.TextBox();
            this.txtPaymentDate = new System.Windows.Forms.TextBox();
            this.txtBuyout = new System.Windows.Forms.TextBox();
            this.txtPaidThrough = new System.Windows.Forms.TextBox();
            this.txtLoanBalance = new System.Windows.Forms.TextBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.textBox6 = new System.Windows.Forms.TextBox();
            this.DealertextBox = new System.Windows.Forms.TextBox();
            this.textBox15 = new System.Windows.Forms.TextBox();
            this.textBox16 = new System.Windows.Forms.TextBox();
            this.cUSTOMER_Add_OnTextBox = new System.Windows.Forms.TextBox();
            this.cUSTOMER_IAC_TypeTextBox = new System.Windows.Forms.TextBox();
            this.cUSTOMER_NOTextBox = new System.Windows.Forms.TextBox();
            this.tabHistory = new DevExpress.XtraTab.XtraTabPage();
            this.groupControl2 = new DevExpress.XtraEditors.GroupControl();
            this.cUSTHISTDataGridView = new DevExpress.XtraGrid.GridControl();
            this.cUSTHISTBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.gridViewCustomerHistory = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.colCUSTHIST_PAY_DATE = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colCUSTHIST_ACT_STAT = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colCUSTHIST_PAYMENT_RCV = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colCUSTHIST_BALANCE = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colCUSTHIST_CONTRACT_STATUS = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colCUSTHIST_LATE_CHARGE_BAL = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colPartialPayment = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colCUSTHIST_PAID_THRU = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colCUSTHIST_PAY_REM_1 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colCUSTHIST_PAYMENT_TYPE = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colCUSTHIST_PAYMENT_CODE = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colCUSTHIST_THRU_UD = new DevExpress.XtraGrid.Columns.GridColumn();
            this.groupBox8 = new System.Windows.Forms.GroupBox();
            this.textBox22 = new System.Windows.Forms.TextBox();
            this.txtPayDate = new System.Windows.Forms.TextBox();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.textBox2 = new System.Windows.Forms.TextBox();
            this.textBox3 = new System.Windows.Forms.TextBox();
            this.textBox4 = new System.Windows.Forms.TextBox();
            this.textBox7 = new System.Windows.Forms.TextBox();
            this.textBox8 = new System.Windows.Forms.TextBox();
            this.textBox9 = new System.Windows.Forms.TextBox();
            this.label13 = new System.Windows.Forms.Label();
            this.tabComments = new DevExpress.XtraTab.XtraTabPage();
            this.groupControl3 = new DevExpress.XtraEditors.GroupControl();
            this.cOMMENTDataGridView = new DevExpress.XtraGrid.GridControl();
            this.cOMMENTBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.cOMMENTgridView = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.colDATE = new DevExpress.XtraGrid.Columns.GridColumn();
            this.repositoryItemDateEdit1 = new DevExpress.XtraEditors.Repository.RepositoryItemDateEdit();
            this.colThumb = new DevExpress.XtraGrid.Columns.GridColumn();
            this.repositoryItemPictureEdit1 = new DevExpress.XtraEditors.Repository.RepositoryItemPictureEdit();
            this.colLetterPath = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colSMSPath = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colTYPE = new DevExpress.XtraGrid.Columns.GridColumn();
            this.repositoryItemLookUpEditType = new DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit();
            this.commentTypesBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.colCOMMENT_USERID = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colCOMMENT = new DevExpress.XtraGrid.Columns.GridColumn();
            this.repositoryItemMemoEdit1 = new DevExpress.XtraEditors.Repository.RepositoryItemMemoEdit();
            this.colCOMMENT_NO = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colCOMMENT_SEQ_NO = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colCOMMENT_ID_TYPE = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colCOMMENT_DEALER = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colCOMMENT_HHMMSS = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colid1 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colImgSort = new DevExpress.XtraGrid.Columns.GridColumn();
            this.repositoryItemTextEdit1 = new DevExpress.XtraEditors.Repository.RepositoryItemTextEdit();
            this.groupBox7 = new System.Windows.Forms.GroupBox();
            this.textBox23 = new System.Windows.Forms.TextBox();
            this.textBox10 = new System.Windows.Forms.TextBox();
            this.textBox11 = new System.Windows.Forms.TextBox();
            this.textBox12 = new System.Windows.Forms.TextBox();
            this.textBox13 = new System.Windows.Forms.TextBox();
            this.txtCommentNo = new System.Windows.Forms.TextBox();
            this.cOMMENTTableAdapter = new IAC2021SQL.IACDataSetTableAdapters.COMMENTTableAdapter();
            this.cUSTHISTTableAdapter = new IAC2021SQL.IACDataSetTableAdapters.CUSTHISTTableAdapter();
            this.comment_TypesTableAdapter = new IAC2021SQL.IACDataSetTableAdapters.Comment_TypesTableAdapter();
            this.paymentTableAdapter = new IAC2021SQL.IACDataSetTableAdapters.PAYMENTTableAdapter();
            this.specialCommentCodesTableAdapter = new IAC2021SQL.IACDataSetTableAdapters.SpecialCommentCodesTableAdapter();
            this.groupControlTabPayments = new DevExpress.XtraEditors.GroupControl();
            label7 = new System.Windows.Forms.Label();
            label6 = new System.Windows.Forms.Label();
            label5 = new System.Windows.Forms.Label();
            label4 = new System.Windows.Forms.Label();
            label3 = new System.Windows.Forms.Label();
            label2 = new System.Windows.Forms.Label();
            label14 = new System.Windows.Forms.Label();
            label34 = new System.Windows.Forms.Label();
            label36 = new System.Windows.Forms.Label();
            label31 = new System.Windows.Forms.Label();
            label8 = new System.Windows.Forms.Label();
            label1 = new System.Windows.Forms.Label();
            label9 = new System.Windows.Forms.Label();
            label10 = new System.Windows.Forms.Label();
            label11 = new System.Windows.Forms.Label();
            label12 = new System.Windows.Forms.Label();
            label15 = new System.Windows.Forms.Label();
            label16 = new System.Windows.Forms.Label();
            label17 = new System.Windows.Forms.Label();
            label18 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.CustomerbindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ClosedPaymentiacDataSet)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.PaymentTypebindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.DealerbindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.PAYCODEbindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tabClosedPayments)).BeginInit();
            this.tabClosedPayments.SuspendLayout();
            this.tabPayment.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl1)).BeginInit();
            this.groupControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.bindingNavigator)).BeginInit();
            this.bindingNavigator.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.PaymentbindingSource)).BeginInit();
            this.toolStrip1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.lookUpEditCodeType.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lookUpEditPaymentType.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.specialCommentCodesBindingSource)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.tabHistory.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl2)).BeginInit();
            this.groupControl2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.cUSTHISTDataGridView)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cUSTHISTBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridViewCustomerHistory)).BeginInit();
            this.groupBox8.SuspendLayout();
            this.tabComments.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl3)).BeginInit();
            this.groupControl3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.cOMMENTDataGridView)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cOMMENTBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cOMMENTgridView)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemDateEdit1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemDateEdit1.CalendarTimeProperties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemPictureEdit1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemLookUpEditType)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.commentTypesBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemMemoEdit1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemTextEdit1)).BeginInit();
            this.groupBox7.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.groupControlTabPayments)).BeginInit();
            this.SuspendLayout();
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Location = new System.Drawing.Point(6, 247);
            label7.Name = "label7";
            label7.Size = new System.Drawing.Size(57, 13);
            label7.TabIndex = 148;
            label7.Text = "CB CODE:";
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Location = new System.Drawing.Point(174, 206);
            label6.Name = "label6";
            label6.Size = new System.Drawing.Size(30, 13);
            label6.TabIndex = 146;
            label6.Text = "(Y/N)";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new System.Drawing.Point(33, 206);
            label5.Name = "label5";
            label5.Size = new System.Drawing.Size(75, 13);
            label5.TabIndex = 145;
            label5.Text = "EFT PAYMENT:";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new System.Drawing.Point(34, 182);
            label4.Name = "label4";
            label4.Size = new System.Drawing.Size(65, 13);
            label4.TabIndex = 143;
            label4.Text = "CODE TYPE:";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new System.Drawing.Point(33, 155);
            label3.Name = "label3";
            label3.Size = new System.Drawing.Size(80, 13);
            label3.TabIndex = 141;
            label3.Text = "PAYMENT TYPE:";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new System.Drawing.Point(33, 130);
            label2.Name = "label2";
            label2.Size = new System.Drawing.Size(107, 13);
            label2.TabIndex = 139;
            label2.Text = "CHECK FACE VALUE:";
            // 
            // label14
            // 
            label14.AutoSize = true;
            label14.Location = new System.Drawing.Point(33, 104);
            label14.Name = "label14";
            label14.Size = new System.Drawing.Size(83, 13);
            label14.TabIndex = 137;
            label14.Text = "PAYMENT DATE:";
            // 
            // label34
            // 
            label34.AutoSize = true;
            label34.Location = new System.Drawing.Point(33, 78);
            label34.Name = "label34";
            label34.Size = new System.Drawing.Size(64, 13);
            label34.TabIndex = 135;
            label34.Text = "PAID THRU:";
            // 
            // label36
            // 
            label36.AutoSize = true;
            label36.Location = new System.Drawing.Point(33, 52);
            label36.Name = "label36";
            label36.Size = new System.Drawing.Size(52, 13);
            label36.TabIndex = 134;
            label36.Text = "BUYOUT:";
            // 
            // label31
            // 
            label31.AutoSize = true;
            label31.Location = new System.Drawing.Point(33, 26);
            label31.Name = "label31";
            label31.Size = new System.Drawing.Size(61, 13);
            label31.TabIndex = 133;
            label31.Text = "LOAN BAL:";
            // 
            // label8
            // 
            label8.AutoSize = true;
            label8.Location = new System.Drawing.Point(13, 45);
            label8.Name = "label8";
            label8.Size = new System.Drawing.Size(49, 13);
            label8.TabIndex = 153;
            label8.Text = "DEALER:";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new System.Drawing.Point(13, 19);
            label1.Name = "label1";
            label1.Size = new System.Drawing.Size(67, 13);
            label1.TabIndex = 4;
            label1.Text = "CUSTOMER:";
            // 
            // label9
            // 
            label9.AutoSize = true;
            label9.Location = new System.Drawing.Point(16, 41);
            label9.Name = "label9";
            label9.Size = new System.Drawing.Size(105, 13);
            label9.TabIndex = 44;
            label9.Text = "PURCHASE ORDER:";
            // 
            // label10
            // 
            label10.AutoSize = true;
            label10.Location = new System.Drawing.Point(16, 18);
            label10.Name = "label10";
            label10.Size = new System.Drawing.Size(87, 13);
            label10.TabIndex = 41;
            label10.Text = "CUSTOMER NO:";
            // 
            // label11
            // 
            label11.AutoSize = true;
            label11.Location = new System.Drawing.Point(246, 41);
            label11.Name = "label11";
            label11.Size = new System.Drawing.Size(54, 13);
            label11.TabIndex = 53;
            label11.Text = "PAY DATE:";
            // 
            // label12
            // 
            label12.AutoSize = true;
            label12.Location = new System.Drawing.Point(464, 41);
            label12.Name = "label12";
            label12.Size = new System.Drawing.Size(49, 13);
            label12.TabIndex = 52;
            label12.Text = "DEALER:";
            // 
            // label15
            // 
            label15.AutoSize = true;
            label15.BackColor = System.Drawing.Color.Transparent;
            label15.Location = new System.Drawing.Point(464, 18);
            label15.Name = "label15";
            label15.Size = new System.Drawing.Size(41, 13);
            label15.TabIndex = 46;
            label15.Text = "NAME:";
            // 
            // label16
            // 
            label16.AutoSize = true;
            label16.Location = new System.Drawing.Point(362, 52);
            label16.Name = "label16";
            label16.Size = new System.Drawing.Size(49, 13);
            label16.TabIndex = 60;
            label16.Text = "DEALER:";
            // 
            // label17
            // 
            label17.AutoSize = true;
            label17.Location = new System.Drawing.Point(14, 29);
            label17.Name = "label17";
            label17.Size = new System.Drawing.Size(87, 13);
            label17.TabIndex = 53;
            label17.Text = "CUSTOMER NO:";
            // 
            // label18
            // 
            label18.AutoSize = true;
            label18.BackColor = System.Drawing.Color.Transparent;
            label18.Location = new System.Drawing.Point(362, 29);
            label18.Name = "label18";
            label18.Size = new System.Drawing.Size(41, 13);
            label18.TabIndex = 55;
            label18.Text = "NAME:";
            // 
            // CustomerbindingSource
            // 
            this.CustomerbindingSource.DataMember = "CUSTOMER";
            this.CustomerbindingSource.DataSource = this.ClosedPaymentiacDataSet;
            // 
            // ClosedPaymentiacDataSet
            // 
            this.ClosedPaymentiacDataSet.DataSetName = "IACDataSet";
            this.ClosedPaymentiacDataSet.EnforceConstraints = false;
            this.ClosedPaymentiacDataSet.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // cUSTOMERTableAdapter
            // 
            this.cUSTOMERTableAdapter.ClearBeforeFill = true;
            // 
            // PaymentTypebindingSource
            // 
            this.PaymentTypebindingSource.DataMember = "PAYMENTTYPE";
            this.PaymentTypebindingSource.DataSource = this.ClosedPaymentiacDataSet;
            // 
            // pAYMENTTYPETableAdapter
            // 
            this.pAYMENTTYPETableAdapter.ClearBeforeFill = true;
            // 
            // DealerbindingSource
            // 
            this.DealerbindingSource.DataMember = "DEALER";
            this.DealerbindingSource.DataSource = this.ClosedPaymentiacDataSet;
            // 
            // dEALERTableAdapter
            // 
            this.dEALERTableAdapter.ClearBeforeFill = true;
            // 
            // PAYCODEbindingSource
            // 
            this.PAYCODEbindingSource.DataMember = "PAYCODE";
            this.PAYCODEbindingSource.DataSource = this.ClosedPaymentiacDataSet;
            // 
            // pAYCODETableAdapter
            // 
            this.pAYCODETableAdapter.ClearBeforeFill = true;
            // 
            // tabClosedPayments
            // 
            this.tabClosedPayments.Location = new System.Drawing.Point(1, 2);
            this.tabClosedPayments.Name = "tabClosedPayments";
            this.tabClosedPayments.SelectedTabPage = this.tabPayment;
            this.tabClosedPayments.Size = new System.Drawing.Size(1017, 602);
            this.tabClosedPayments.TabIndex = 159;
            this.tabClosedPayments.TabPages.AddRange(new DevExpress.XtraTab.XtraTabPage[] {
            this.tabPayment,
            this.tabHistory,
            this.tabComments});
            this.tabClosedPayments.SelectedPageChanged += new DevExpress.XtraTab.TabPageChangedEventHandler(this.tabClosedPayments_SelectedPageChanged);
            // 
            // tabPayment
            // 
            this.tabPayment.Appearance.PageClient.BackColor = System.Drawing.Color.LightSteelBlue;
            this.tabPayment.Appearance.PageClient.Options.UseBackColor = true;
            this.tabPayment.Controls.Add(this.groupControl1);
            this.tabPayment.Name = "tabPayment";
            this.tabPayment.Padding = new System.Windows.Forms.Padding(3);
            this.tabPayment.Size = new System.Drawing.Size(1009, 572);
            this.tabPayment.Text = "Payments";
            // 
            // groupControl1
            // 
            this.groupControl1.Appearance.BackColor = System.Drawing.Color.LightSteelBlue;
            this.groupControl1.Appearance.Options.UseBackColor = true;
            this.groupControl1.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            this.groupControl1.Controls.Add(this.bindingNavigator);
            this.groupControl1.Controls.Add(this.toolStrip1);
            this.groupControl1.Controls.Add(this.groupBox2);
            this.groupControl1.Controls.Add(this.groupBox1);
            this.groupControl1.Location = new System.Drawing.Point(-4, 0);
            this.groupControl1.Name = "groupControl1";
            this.groupControl1.Size = new System.Drawing.Size(1017, 572);
            this.groupControl1.TabIndex = 162;
            this.groupControl1.Text = "groupControl1";
            // 
            // bindingNavigator
            // 
            this.bindingNavigator.AddNewItem = null;
            this.bindingNavigator.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.bindingNavigator.BindingSource = this.PaymentbindingSource;
            this.bindingNavigator.CountItem = this.bindingNavigatorCountItem;
            this.bindingNavigator.DeleteItem = null;
            this.bindingNavigator.Dock = System.Windows.Forms.DockStyle.None;
            this.bindingNavigator.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.bindingNavigatorMoveFirstItem,
            this.bindingNavigatorMovePreviousItem,
            this.bindingNavigatorSeparator,
            this.bindingNavigatorPositionItem,
            this.bindingNavigatorCountItem,
            this.bindingNavigatorSeparator1,
            this.bindingNavigatorMoveNextItem,
            this.bindingNavigatorMoveLastItem,
            this.bindingNavigatorSeparator2,
            this.toolStripButton2});
            this.bindingNavigator.Location = new System.Drawing.Point(291, 547);
            this.bindingNavigator.MoveFirstItem = this.bindingNavigatorMoveFirstItem;
            this.bindingNavigator.MoveLastItem = this.bindingNavigatorMoveLastItem;
            this.bindingNavigator.MoveNextItem = this.bindingNavigatorMoveNextItem;
            this.bindingNavigator.MovePreviousItem = this.bindingNavigatorMovePreviousItem;
            this.bindingNavigator.Name = "bindingNavigator";
            this.bindingNavigator.PositionItem = this.bindingNavigatorPositionItem;
            this.bindingNavigator.Size = new System.Drawing.Size(232, 25);
            this.bindingNavigator.TabIndex = 161;
            this.bindingNavigator.Text = "bindingNavigator";
            // 
            // PaymentbindingSource
            // 
            this.PaymentbindingSource.DataMember = "PAYMENT";
            this.PaymentbindingSource.DataSource = this.ClosedPaymentiacDataSet;
            this.PaymentbindingSource.AddingNew += new System.ComponentModel.AddingNewEventHandler(this.PaymentbindingSource_AddingNew);
            this.PaymentbindingSource.PositionChanged += new System.EventHandler(this.PaymentbindingSource_PositionChanged);
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
            this.bindingNavigatorPositionItem.Size = new System.Drawing.Size(50, 21);
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
            // toolStripButton2
            // 
            this.toolStripButton2.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripButton2.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButton2.Image")));
            this.toolStripButton2.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton2.Name = "toolStripButton2";
            this.toolStripButton2.Size = new System.Drawing.Size(23, 22);
            this.toolStripButton2.Text = "toolStripButton2";
            // 
            // toolStrip1
            // 
            this.toolStrip1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripButton1,
            this.toolStripButtonAdd,
            this.toolStripButtonEdit,
            this.toolStripButtonDelete,
            this.toolStripButtonSave,
            this.toolStripButtonCancel});
            this.toolStrip1.Location = new System.Drawing.Point(0, 547);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(1017, 25);
            this.toolStrip1.TabIndex = 160;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // toolStripButton1
            // 
            this.toolStripButton1.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripButton1.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButton1.Image")));
            this.toolStripButton1.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton1.Name = "toolStripButton1";
            this.toolStripButton1.Size = new System.Drawing.Size(23, 22);
            this.toolStripButton1.Text = "Search";
            this.toolStripButton1.Click += new System.EventHandler(this.toolStripButton1_Click);
            // 
            // toolStripButtonAdd
            // 
            this.toolStripButtonAdd.BackColor = System.Drawing.Color.White;
            this.toolStripButtonAdd.Enabled = false;
            this.toolStripButtonAdd.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButtonAdd.Image")));
            this.toolStripButtonAdd.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButtonAdd.Name = "toolStripButtonAdd";
            this.toolStripButtonAdd.Size = new System.Drawing.Size(49, 22);
            this.toolStripButtonAdd.Text = "&Add";
            this.toolStripButtonAdd.Click += new System.EventHandler(this.toolStripButtonAdd_Click);
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
            this.toolStripButtonEdit.Click += new System.EventHandler(this.toolStripButtonEdit_Click);
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
            this.toolStripButtonDelete.Click += new System.EventHandler(this.toolStripButtonDelete_Click);
            // 
            // toolStripButtonSave
            // 
            this.toolStripButtonSave.BackColor = System.Drawing.Color.LightYellow;
            this.toolStripButtonSave.Enabled = false;
            this.toolStripButtonSave.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButtonSave.Image")));
            this.toolStripButtonSave.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButtonSave.Name = "toolStripButtonSave";
            this.toolStripButtonSave.Size = new System.Drawing.Size(51, 22);
            this.toolStripButtonSave.Text = "&Save";
            this.toolStripButtonSave.Click += new System.EventHandler(this.toolStripButtonSave_Click);
            this.toolStripButtonSave.EnabledChanged += new System.EventHandler(this.toolStripButtonSave_EnabledChanged);
            // 
            // toolStripButtonCancel
            // 
            this.toolStripButtonCancel.BackColor = System.Drawing.Color.LightYellow;
            this.toolStripButtonCancel.Enabled = false;
            this.toolStripButtonCancel.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButtonCancel.Image")));
            this.toolStripButtonCancel.ImageTransparentColor = System.Drawing.Color.Crimson;
            this.toolStripButtonCancel.Name = "toolStripButtonCancel";
            this.toolStripButtonCancel.Size = new System.Drawing.Size(85, 22);
            this.toolStripButtonCancel.Text = "&CancelAdd";
            this.toolStripButtonCancel.Click += new System.EventHandler(this.toolStripButtonCancel_Click);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.lookUpEditCodeType);
            this.groupBox2.Controls.Add(this.lookUpEditPaymentType);
            this.groupBox2.Controls.Add(this.checkBoxNoAdjLookBack);
            this.groupBox2.Controls.Add(this.listBoxTSBCommentCode);
            this.groupBox2.Controls.Add(this.buttonChangeISFDate);
            this.groupBox2.Controls.Add(this.textBoxISFDate);
            this.groupBox2.Controls.Add(this.PaidThroughUDtextBox);
            this.groupBox2.Controls.Add(this.txtIncome);
            this.groupBox2.Controls.Add(this.txtOverPayment);
            this.groupBox2.Controls.Add(label7);
            this.groupBox2.Controls.Add(label6);
            this.groupBox2.Controls.Add(label5);
            this.groupBox2.Controls.Add(this.EFTtextBox);
            this.groupBox2.Controls.Add(label4);
            this.groupBox2.Controls.Add(label3);
            this.groupBox2.Controls.Add(this.txtCheckValue);
            this.groupBox2.Controls.Add(label2);
            this.groupBox2.Controls.Add(label14);
            this.groupBox2.Controls.Add(this.txtPaymentDate);
            this.groupBox2.Controls.Add(label34);
            this.groupBox2.Controls.Add(this.txtBuyout);
            this.groupBox2.Controls.Add(label36);
            this.groupBox2.Controls.Add(this.txtPaidThrough);
            this.groupBox2.Controls.Add(this.txtLoanBalance);
            this.groupBox2.Controls.Add(label31);
            this.groupBox2.Location = new System.Drawing.Point(69, 169);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(879, 357);
            this.groupBox2.TabIndex = 159;
            this.groupBox2.TabStop = false;
            // 
            // lookUpEditCodeType
            // 
            this.lookUpEditCodeType.DataBindings.Add(new System.Windows.Forms.Binding("EditValue", this.PaymentbindingSource, "PAYMENT_CODE_2", true));
            this.lookUpEditCodeType.Location = new System.Drawing.Point(151, 173);
            this.lookUpEditCodeType.Name = "lookUpEditCodeType";
            this.lookUpEditCodeType.Properties.Appearance.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lookUpEditCodeType.Properties.Appearance.Options.UseFont = true;
            this.lookUpEditCodeType.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.lookUpEditCodeType.Properties.Columns.AddRange(new DevExpress.XtraEditors.Controls.LookUpColumnInfo[] {
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("CODE", "CODE", 39, DevExpress.Utils.FormatType.None, "", true, DevExpress.Utils.HorzAlignment.Near, DevExpress.Data.ColumnSortOrder.Ascending, DevExpress.Utils.DefaultBoolean.Default),
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("DESCRIPTION", "DESCRIPTION", 77, DevExpress.Utils.FormatType.None, "", true, DevExpress.Utils.HorzAlignment.Near, DevExpress.Data.ColumnSortOrder.None, DevExpress.Utils.DefaultBoolean.Default)});
            this.lookUpEditCodeType.Properties.DataSource = this.PaymentbindingSource;
            this.lookUpEditCodeType.Properties.DisplayMember = "CODE";
            this.lookUpEditCodeType.Properties.NullText = "";
            this.lookUpEditCodeType.Properties.ValueMember = "CODE";
            this.lookUpEditCodeType.Size = new System.Drawing.Size(60, 22);
            this.lookUpEditCodeType.TabIndex = 14;
            this.lookUpEditCodeType.Enter += new System.EventHandler(this.lookUpEditCodeType_Enter);
            // 
            // lookUpEditPaymentType
            // 
            this.lookUpEditPaymentType.DataBindings.Add(new System.Windows.Forms.Binding("EditValue", this.PaymentbindingSource, "PAYMENT_TYPE", true));
            this.lookUpEditPaymentType.EnterMoveNextControl = true;
            this.lookUpEditPaymentType.Location = new System.Drawing.Point(151, 146);
            this.lookUpEditPaymentType.Name = "lookUpEditPaymentType";
            this.lookUpEditPaymentType.Properties.Appearance.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lookUpEditPaymentType.Properties.Appearance.Options.UseFont = true;
            this.lookUpEditPaymentType.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.lookUpEditPaymentType.Properties.Columns.AddRange(new DevExpress.XtraEditors.Controls.LookUpColumnInfo[] {
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("TYPE", "TYPE", 31, DevExpress.Utils.FormatType.None, "", true, DevExpress.Utils.HorzAlignment.Near, DevExpress.Data.ColumnSortOrder.Ascending, DevExpress.Utils.DefaultBoolean.Default),
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("DESCRIPTION", "DESCRIPTION", 77, DevExpress.Utils.FormatType.None, "", true, DevExpress.Utils.HorzAlignment.Near, DevExpress.Data.ColumnSortOrder.None, DevExpress.Utils.DefaultBoolean.Default)});
            this.lookUpEditPaymentType.Properties.DataSource = this.PaymentTypebindingSource;
            this.lookUpEditPaymentType.Properties.DisplayMember = "TYPE";
            this.lookUpEditPaymentType.Properties.MaxLength = 1;
            this.lookUpEditPaymentType.Properties.NullText = "";
            this.lookUpEditPaymentType.Properties.PopupFilterMode = DevExpress.XtraEditors.PopupFilterMode.StartsWith;
            this.lookUpEditPaymentType.Properties.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.Standard;
            this.lookUpEditPaymentType.Properties.ValidateOnEnterKey = true;
            this.lookUpEditPaymentType.Properties.ValueMember = "TYPE";
            this.lookUpEditPaymentType.Size = new System.Drawing.Size(60, 22);
            this.lookUpEditPaymentType.TabIndex = 13;
            this.lookUpEditPaymentType.EditValueChanged += new System.EventHandler(this.lookUpEditPaymentType_EditValueChanged);
            this.lookUpEditPaymentType.TextChanged += new System.EventHandler(this.PaymentTypetextBox_TextChanged);
            this.lookUpEditPaymentType.Validated += new System.EventHandler(this.lookUpEditPaymentType_Validated);
            // 
            // checkBoxNoAdjLookBack
            // 
            this.checkBoxNoAdjLookBack.AutoSize = true;
            this.checkBoxNoAdjLookBack.Checked = true;
            this.checkBoxNoAdjLookBack.CheckState = System.Windows.Forms.CheckState.Checked;
            this.checkBoxNoAdjLookBack.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.checkBoxNoAdjLookBack.Location = new System.Drawing.Point(151, 240);
            this.checkBoxNoAdjLookBack.Name = "checkBoxNoAdjLookBack";
            this.checkBoxNoAdjLookBack.Size = new System.Drawing.Size(169, 17);
            this.checkBoxNoAdjLookBack.TabIndex = 159;
            this.checkBoxNoAdjLookBack.Text = "No Adjustment LookBack";
            this.checkBoxNoAdjLookBack.UseVisualStyleBackColor = true;
            // 
            // listBoxTSBCommentCode
            // 
            this.listBoxTSBCommentCode.DataBindings.Add(new System.Windows.Forms.Binding("SelectedValue", this.CustomerbindingSource, "CUSTOMER_TSB_COMMENT_CODE", true));
            this.listBoxTSBCommentCode.DataSource = this.specialCommentCodesBindingSource;
            this.listBoxTSBCommentCode.DisplayMember = "Description";
            this.listBoxTSBCommentCode.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawVariable;
            this.listBoxTSBCommentCode.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.listBoxTSBCommentCode.FormattingEnabled = true;
            this.listBoxTSBCommentCode.ItemHeight = 63;
            this.listBoxTSBCommentCode.Location = new System.Drawing.Point(8, 263);
            this.listBoxTSBCommentCode.Name = "listBoxTSBCommentCode";
            this.listBoxTSBCommentCode.Size = new System.Drawing.Size(863, 88);
            this.listBoxTSBCommentCode.TabIndex = 158;
            this.listBoxTSBCommentCode.ValueMember = "Code";
            this.listBoxTSBCommentCode.DrawItem += new System.Windows.Forms.DrawItemEventHandler(this.listBoxTSBCommentCode_DrawItem);
            this.listBoxTSBCommentCode.SelectedValueChanged += new System.EventHandler(this.listBoxTSBCommentCode_SelectedValueChanged);
            // 
            // specialCommentCodesBindingSource
            // 
            this.specialCommentCodesBindingSource.DataMember = "SpecialCommentCodes";
            this.specialCommentCodesBindingSource.DataSource = this.ClosedPaymentiacDataSet;
            // 
            // buttonChangeISFDate
            // 
            this.buttonChangeISFDate.Location = new System.Drawing.Point(469, 95);
            this.buttonChangeISFDate.Name = "buttonChangeISFDate";
            this.buttonChangeISFDate.Size = new System.Drawing.Size(109, 23);
            this.buttonChangeISFDate.TabIndex = 157;
            this.buttonChangeISFDate.Text = "Change &ISF Date";
            this.buttonChangeISFDate.Click += new System.EventHandler(this.buttonChangeISFDate_Click);
            // 
            // textBoxISFDate
            // 
            this.textBoxISFDate.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.PaymentbindingSource, "PAYMENT_ISF_DATE", true));
            this.textBoxISFDate.Enabled = false;
            this.textBoxISFDate.Location = new System.Drawing.Point(386, 98);
            this.textBoxISFDate.Name = "textBoxISFDate";
            this.textBoxISFDate.Size = new System.Drawing.Size(62, 22);
            this.textBoxISFDate.TabIndex = 156;
            this.textBoxISFDate.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.textBoxISFDate.Visible = false;
            // 
            // PaidThroughUDtextBox
            // 
            this.PaidThroughUDtextBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.PaymentbindingSource, "PAYMENT_THRU_UD", true));
            this.PaidThroughUDtextBox.Enabled = false;
            this.PaidThroughUDtextBox.Location = new System.Drawing.Point(546, 148);
            this.PaidThroughUDtextBox.Name = "PaidThroughUDtextBox";
            this.PaidThroughUDtextBox.Size = new System.Drawing.Size(32, 22);
            this.PaidThroughUDtextBox.TabIndex = 22;
            this.PaidThroughUDtextBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.PaidThroughUDtextBox.Visible = false;
            this.PaidThroughUDtextBox.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.General_KeyPress);
            // 
            // txtIncome
            // 
            this.txtIncome.Location = new System.Drawing.Point(386, 71);
            this.txtIncome.Name = "txtIncome";
            this.txtIncome.Size = new System.Drawing.Size(88, 22);
            this.txtIncome.TabIndex = 21;
            this.txtIncome.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.txtIncome.Visible = false;
            // 
            // txtOverPayment
            // 
            this.txtOverPayment.Location = new System.Drawing.Point(386, 45);
            this.txtOverPayment.Name = "txtOverPayment";
            this.txtOverPayment.Size = new System.Drawing.Size(88, 22);
            this.txtOverPayment.TabIndex = 20;
            this.txtOverPayment.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.txtOverPayment.Visible = false;
            // 
            // EFTtextBox
            // 
            this.EFTtextBox.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.EFTtextBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.PaymentbindingSource, "PAYMENT_AUTO_PAY", true));
            this.EFTtextBox.Location = new System.Drawing.Point(151, 199);
            this.EFTtextBox.MaxLength = 1;
            this.EFTtextBox.Name = "EFTtextBox";
            this.EFTtextBox.Size = new System.Drawing.Size(17, 22);
            this.EFTtextBox.TabIndex = 17;
            this.EFTtextBox.Enter += new System.EventHandler(this.EFTtextBox_Enter);
            this.EFTtextBox.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.General_KeyPress);
            // 
            // txtCheckValue
            // 
            this.txtCheckValue.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.PaymentbindingSource, "PAYMENT_AMOUNT_RCV", true, System.Windows.Forms.DataSourceUpdateMode.OnValidation, null, "C2"));
            this.txtCheckValue.Location = new System.Drawing.Point(151, 123);
            this.txtCheckValue.Name = "txtCheckValue";
            this.txtCheckValue.Size = new System.Drawing.Size(88, 22);
            this.txtCheckValue.TabIndex = 12;
            this.txtCheckValue.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.txtCheckValue.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.General_KeyPress);
            this.txtCheckValue.Validated += new System.EventHandler(this.txtCheckValue_Validated);
            // 
            // txtPaymentDate
            // 
            this.txtPaymentDate.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.PaymentbindingSource, "PAYMENT_DATE", true, System.Windows.Forms.DataSourceUpdateMode.OnValidation, null, "d"));
            this.txtPaymentDate.Enabled = false;
            this.txtPaymentDate.Location = new System.Drawing.Point(151, 97);
            this.txtPaymentDate.Name = "txtPaymentDate";
            this.txtPaymentDate.Size = new System.Drawing.Size(63, 22);
            this.txtPaymentDate.TabIndex = 11;
            this.txtPaymentDate.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // txtBuyout
            // 
            this.txtBuyout.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.CustomerbindingSource, "CUSTOMER_BALANCE", true, System.Windows.Forms.DataSourceUpdateMode.OnValidation, null, "C2"));
            this.txtBuyout.Enabled = false;
            this.txtBuyout.Location = new System.Drawing.Point(151, 45);
            this.txtBuyout.Name = "txtBuyout";
            this.txtBuyout.Size = new System.Drawing.Size(88, 22);
            this.txtBuyout.TabIndex = 9;
            this.txtBuyout.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // txtPaidThrough
            // 
            this.txtPaidThrough.Enabled = false;
            this.txtPaidThrough.Location = new System.Drawing.Point(151, 71);
            this.txtPaidThrough.Name = "txtPaidThrough";
            this.txtPaidThrough.Size = new System.Drawing.Size(43, 22);
            this.txtPaidThrough.TabIndex = 10;
            this.txtPaidThrough.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.txtPaidThrough.Validated += new System.EventHandler(this.PaidThroughtextBox_Validated);
            // 
            // txtLoanBalance
            // 
            this.txtLoanBalance.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.CustomerbindingSource, "CUSTOMER_BALANCE", true, System.Windows.Forms.DataSourceUpdateMode.OnValidation, null, "C2"));
            this.txtLoanBalance.Enabled = false;
            this.txtLoanBalance.Location = new System.Drawing.Point(151, 19);
            this.txtLoanBalance.Name = "txtLoanBalance";
            this.txtLoanBalance.Size = new System.Drawing.Size(88, 22);
            this.txtLoanBalance.TabIndex = 8;
            this.txtLoanBalance.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.textBox6);
            this.groupBox1.Controls.Add(this.DealertextBox);
            this.groupBox1.Controls.Add(label8);
            this.groupBox1.Controls.Add(this.textBox15);
            this.groupBox1.Controls.Add(this.textBox16);
            this.groupBox1.Controls.Add(this.cUSTOMER_Add_OnTextBox);
            this.groupBox1.Controls.Add(this.cUSTOMER_IAC_TypeTextBox);
            this.groupBox1.Controls.Add(this.cUSTOMER_NOTextBox);
            this.groupBox1.Controls.Add(label1);
            this.groupBox1.Location = new System.Drawing.Point(266, 46);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(485, 66);
            this.groupBox1.TabIndex = 158;
            this.groupBox1.TabStop = false;
            // 
            // textBox6
            // 
            this.textBox6.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.DealerbindingSource, "DEALER_NAME", true));
            this.textBox6.Enabled = false;
            this.textBox6.Location = new System.Drawing.Point(143, 38);
            this.textBox6.Name = "textBox6";
            this.textBox6.Size = new System.Drawing.Size(220, 22);
            this.textBox6.TabIndex = 7;
            // 
            // DealertextBox
            // 
            this.DealertextBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.CustomerbindingSource, "CUSTOMER_DEALER", true));
            this.DealertextBox.Enabled = false;
            this.DealertextBox.Location = new System.Drawing.Point(96, 38);
            this.DealertextBox.Name = "DealertextBox";
            this.DealertextBox.Size = new System.Drawing.Size(45, 22);
            this.DealertextBox.TabIndex = 6;
            this.DealertextBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // textBox15
            // 
            this.textBox15.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.CustomerbindingSource, "CUSTOMER_LAST_NAME", true));
            this.textBox15.Enabled = false;
            this.textBox15.Location = new System.Drawing.Point(340, 12);
            this.textBox15.Name = "textBox15";
            this.textBox15.Size = new System.Drawing.Size(132, 22);
            this.textBox15.TabIndex = 5;
            // 
            // textBox16
            // 
            this.textBox16.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.CustomerbindingSource, "CUSTOMER_FIRST_NAME", true));
            this.textBox16.Enabled = false;
            this.textBox16.Location = new System.Drawing.Point(204, 12);
            this.textBox16.Name = "textBox16";
            this.textBox16.Size = new System.Drawing.Size(132, 22);
            this.textBox16.TabIndex = 4;
            // 
            // cUSTOMER_Add_OnTextBox
            // 
            this.cUSTOMER_Add_OnTextBox.Enabled = false;
            this.cUSTOMER_Add_OnTextBox.Location = new System.Drawing.Point(157, 12);
            this.cUSTOMER_Add_OnTextBox.Name = "cUSTOMER_Add_OnTextBox";
            this.cUSTOMER_Add_OnTextBox.Size = new System.Drawing.Size(17, 22);
            this.cUSTOMER_Add_OnTextBox.TabIndex = 2;
            // 
            // cUSTOMER_IAC_TypeTextBox
            // 
            this.cUSTOMER_IAC_TypeTextBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.CustomerbindingSource, "CUSTOMER_IAC_TYPE", true));
            this.cUSTOMER_IAC_TypeTextBox.Enabled = false;
            this.cUSTOMER_IAC_TypeTextBox.Location = new System.Drawing.Point(178, 12);
            this.cUSTOMER_IAC_TypeTextBox.Name = "cUSTOMER_IAC_TypeTextBox";
            this.cUSTOMER_IAC_TypeTextBox.Size = new System.Drawing.Size(17, 22);
            this.cUSTOMER_IAC_TypeTextBox.TabIndex = 3;
            // 
            // cUSTOMER_NOTextBox
            // 
            this.cUSTOMER_NOTextBox.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.cUSTOMER_NOTextBox.Location = new System.Drawing.Point(96, 12);
            this.cUSTOMER_NOTextBox.MaxLength = 6;
            this.cUSTOMER_NOTextBox.Name = "cUSTOMER_NOTextBox";
            this.cUSTOMER_NOTextBox.Size = new System.Drawing.Size(58, 22);
            this.cUSTOMER_NOTextBox.TabIndex = 1;
            this.cUSTOMER_NOTextBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.cUSTOMER_NOTextBox.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.General_KeyPress);
            this.cUSTOMER_NOTextBox.Validated += new System.EventHandler(this.cUSTOMER_NOTextBox_Validated);
            // 
            // tabHistory
            // 
            this.tabHistory.Appearance.PageClient.BackColor = System.Drawing.Color.LightSteelBlue;
            this.tabHistory.Appearance.PageClient.Options.UseBackColor = true;
            this.tabHistory.Controls.Add(this.groupControl2);
            this.tabHistory.Name = "tabHistory";
            this.tabHistory.Padding = new System.Windows.Forms.Padding(3);
            this.tabHistory.Size = new System.Drawing.Size(1009, 572);
            this.tabHistory.Text = "History";
            // 
            // groupControl2
            // 
            this.groupControl2.Appearance.BackColor = System.Drawing.Color.LightSteelBlue;
            this.groupControl2.Appearance.Options.UseBackColor = true;
            this.groupControl2.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            this.groupControl2.Controls.Add(this.cUSTHISTDataGridView);
            this.groupControl2.Controls.Add(this.groupBox8);
            this.groupControl2.Location = new System.Drawing.Point(-4, 0);
            this.groupControl2.Name = "groupControl2";
            this.groupControl2.Size = new System.Drawing.Size(1014, 576);
            this.groupControl2.TabIndex = 100;
            this.groupControl2.Text = "groupControl2";
            // 
            // cUSTHISTDataGridView
            // 
            this.cUSTHISTDataGridView.DataSource = this.cUSTHISTBindingSource;
            this.cUSTHISTDataGridView.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cUSTHISTDataGridView.Location = new System.Drawing.Point(11, 91);
            this.cUSTHISTDataGridView.MainView = this.gridViewCustomerHistory;
            this.cUSTHISTDataGridView.Name = "cUSTHISTDataGridView";
            this.cUSTHISTDataGridView.Size = new System.Drawing.Size(993, 472);
            this.cUSTHISTDataGridView.TabIndex = 536;
            this.cUSTHISTDataGridView.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridViewCustomerHistory});
            // 
            // cUSTHISTBindingSource
            // 
            this.cUSTHISTBindingSource.DataMember = "CUSTHIST";
            this.cUSTHISTBindingSource.DataSource = this.ClosedPaymentiacDataSet;
            // 
            // gridViewCustomerHistory
            // 
            this.gridViewCustomerHistory.Appearance.ColumnFilterButton.Options.UseFont = true;
            this.gridViewCustomerHistory.Appearance.EvenRow.BackColor = System.Drawing.Color.Bisque;
            this.gridViewCustomerHistory.Appearance.EvenRow.Options.UseBackColor = true;
            this.gridViewCustomerHistory.Appearance.EvenRow.Options.UseFont = true;
            this.gridViewCustomerHistory.Appearance.EvenRow.Options.UseForeColor = true;
            this.gridViewCustomerHistory.Appearance.HeaderPanel.Options.UseTextOptions = true;
            this.gridViewCustomerHistory.Appearance.HeaderPanel.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
            this.gridViewCustomerHistory.Appearance.HeaderPanel.TextOptions.Trimming = DevExpress.Utils.Trimming.None;
            this.gridViewCustomerHistory.Appearance.HeaderPanel.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Top;
            this.gridViewCustomerHistory.Appearance.HeaderPanel.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap;
            this.gridViewCustomerHistory.Appearance.OddRow.BackColor = System.Drawing.Color.Transparent;
            this.gridViewCustomerHistory.Appearance.OddRow.Options.UseBackColor = true;
            this.gridViewCustomerHistory.Appearance.OddRow.Options.UseFont = true;
            this.gridViewCustomerHistory.Appearance.OddRow.Options.UseForeColor = true;
            this.gridViewCustomerHistory.AppearancePrint.HeaderPanel.Options.UseTextOptions = true;
            this.gridViewCustomerHistory.AppearancePrint.HeaderPanel.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Top;
            this.gridViewCustomerHistory.AppearancePrint.HeaderPanel.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap;
            this.gridViewCustomerHistory.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.colCUSTHIST_PAY_DATE,
            this.colCUSTHIST_ACT_STAT,
            this.colCUSTHIST_PAYMENT_RCV,
            this.colCUSTHIST_BALANCE,
            this.colCUSTHIST_CONTRACT_STATUS,
            this.colCUSTHIST_LATE_CHARGE_BAL,
            this.colPartialPayment,
            this.colCUSTHIST_PAID_THRU,
            this.colCUSTHIST_PAY_REM_1,
            this.colCUSTHIST_PAYMENT_TYPE,
            this.colCUSTHIST_PAYMENT_CODE,
            this.colCUSTHIST_THRU_UD});
            this.gridViewCustomerHistory.GridControl = this.cUSTHISTDataGridView;
            this.gridViewCustomerHistory.HorzScrollVisibility = DevExpress.XtraGrid.Views.Base.ScrollVisibility.Never;
            this.gridViewCustomerHistory.Name = "gridViewCustomerHistory";
            this.gridViewCustomerHistory.OptionsBehavior.AllowAddRows = DevExpress.Utils.DefaultBoolean.False;
            this.gridViewCustomerHistory.OptionsBehavior.AllowDeleteRows = DevExpress.Utils.DefaultBoolean.False;
            this.gridViewCustomerHistory.OptionsBehavior.Editable = false;
            this.gridViewCustomerHistory.OptionsBehavior.ReadOnly = true;
            this.gridViewCustomerHistory.OptionsBehavior.SummariesIgnoreNullValues = true;
            this.gridViewCustomerHistory.OptionsView.ColumnAutoWidth = false;
            this.gridViewCustomerHistory.OptionsView.ColumnHeaderAutoHeight = DevExpress.Utils.DefaultBoolean.True;
            this.gridViewCustomerHistory.OptionsView.EnableAppearanceEvenRow = true;
            this.gridViewCustomerHistory.OptionsView.EnableAppearanceOddRow = true;
            this.gridViewCustomerHistory.OptionsView.ShowGroupPanel = false;
            // 
            // colCUSTHIST_PAY_DATE
            // 
            this.colCUSTHIST_PAY_DATE.AppearanceCell.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.colCUSTHIST_PAY_DATE.AppearanceCell.Options.UseFont = true;
            this.colCUSTHIST_PAY_DATE.AppearanceCell.Options.UseTextOptions = true;
            this.colCUSTHIST_PAY_DATE.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
            this.colCUSTHIST_PAY_DATE.AppearanceCell.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
            this.colCUSTHIST_PAY_DATE.AppearanceHeader.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.colCUSTHIST_PAY_DATE.AppearanceHeader.Options.UseFont = true;
            this.colCUSTHIST_PAY_DATE.AppearanceHeader.Options.UseTextOptions = true;
            this.colCUSTHIST_PAY_DATE.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Near;
            this.colCUSTHIST_PAY_DATE.AppearanceHeader.TextOptions.Trimming = DevExpress.Utils.Trimming.None;
            this.colCUSTHIST_PAY_DATE.AppearanceHeader.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
            this.colCUSTHIST_PAY_DATE.AppearanceHeader.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap;
            this.colCUSTHIST_PAY_DATE.Caption = "POST DATE";
            this.colCUSTHIST_PAY_DATE.FieldName = "CUSTHIST_PAY_DATE";
            this.colCUSTHIST_PAY_DATE.Name = "colCUSTHIST_PAY_DATE";
            this.colCUSTHIST_PAY_DATE.OptionsColumn.AllowEdit = false;
            this.colCUSTHIST_PAY_DATE.Visible = true;
            this.colCUSTHIST_PAY_DATE.VisibleIndex = 0;
            this.colCUSTHIST_PAY_DATE.Width = 68;
            // 
            // colCUSTHIST_ACT_STAT
            // 
            this.colCUSTHIST_ACT_STAT.AppearanceCell.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.colCUSTHIST_ACT_STAT.AppearanceCell.Options.UseFont = true;
            this.colCUSTHIST_ACT_STAT.AppearanceHeader.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.colCUSTHIST_ACT_STAT.AppearanceHeader.Options.UseFont = true;
            this.colCUSTHIST_ACT_STAT.AppearanceHeader.Options.UseTextOptions = true;
            this.colCUSTHIST_ACT_STAT.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Near;
            this.colCUSTHIST_ACT_STAT.AppearanceHeader.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
            this.colCUSTHIST_ACT_STAT.AppearanceHeader.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap;
            this.colCUSTHIST_ACT_STAT.Caption = "ACT STAT";
            this.colCUSTHIST_ACT_STAT.FieldName = "CUSTHIST_ACT_STAT";
            this.colCUSTHIST_ACT_STAT.Name = "colCUSTHIST_ACT_STAT";
            this.colCUSTHIST_ACT_STAT.Visible = true;
            this.colCUSTHIST_ACT_STAT.VisibleIndex = 1;
            this.colCUSTHIST_ACT_STAT.Width = 62;
            // 
            // colCUSTHIST_PAYMENT_RCV
            // 
            this.colCUSTHIST_PAYMENT_RCV.AppearanceCell.Options.UseFont = true;
            this.colCUSTHIST_PAYMENT_RCV.AppearanceHeader.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Bold);
            this.colCUSTHIST_PAYMENT_RCV.AppearanceHeader.Options.UseFont = true;
            this.colCUSTHIST_PAYMENT_RCV.AppearanceHeader.Options.UseTextOptions = true;
            this.colCUSTHIST_PAYMENT_RCV.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Near;
            this.colCUSTHIST_PAYMENT_RCV.AppearanceHeader.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
            this.colCUSTHIST_PAYMENT_RCV.AppearanceHeader.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap;
            this.colCUSTHIST_PAYMENT_RCV.Caption = "PAYMENT AMOUNT";
            this.colCUSTHIST_PAYMENT_RCV.DisplayFormat.FormatString = "c2";
            this.colCUSTHIST_PAYMENT_RCV.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.colCUSTHIST_PAYMENT_RCV.FieldName = "CUSTHIST_PAYMENT_RCV";
            this.colCUSTHIST_PAYMENT_RCV.Name = "colCUSTHIST_PAYMENT_RCV";
            this.colCUSTHIST_PAYMENT_RCV.Visible = true;
            this.colCUSTHIST_PAYMENT_RCV.VisibleIndex = 2;
            this.colCUSTHIST_PAYMENT_RCV.Width = 100;
            // 
            // colCUSTHIST_BALANCE
            // 
            this.colCUSTHIST_BALANCE.AppearanceCell.Options.UseFont = true;
            this.colCUSTHIST_BALANCE.AppearanceCell.Options.UseTextOptions = true;
            this.colCUSTHIST_BALANCE.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
            this.colCUSTHIST_BALANCE.AppearanceHeader.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Bold);
            this.colCUSTHIST_BALANCE.AppearanceHeader.Options.UseFont = true;
            this.colCUSTHIST_BALANCE.AppearanceHeader.Options.UseTextOptions = true;
            this.colCUSTHIST_BALANCE.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Near;
            this.colCUSTHIST_BALANCE.AppearanceHeader.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
            this.colCUSTHIST_BALANCE.AppearanceHeader.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap;
            this.colCUSTHIST_BALANCE.Caption = "LOAN BALANCE";
            this.colCUSTHIST_BALANCE.DisplayFormat.FormatString = "c2";
            this.colCUSTHIST_BALANCE.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.colCUSTHIST_BALANCE.FieldName = "CUSTHIST_BALANCE";
            this.colCUSTHIST_BALANCE.Name = "colCUSTHIST_BALANCE";
            this.colCUSTHIST_BALANCE.Visible = true;
            this.colCUSTHIST_BALANCE.VisibleIndex = 3;
            this.colCUSTHIST_BALANCE.Width = 100;
            // 
            // colCUSTHIST_CONTRACT_STATUS
            // 
            this.colCUSTHIST_CONTRACT_STATUS.AppearanceCell.Options.UseFont = true;
            this.colCUSTHIST_CONTRACT_STATUS.AppearanceHeader.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Bold);
            this.colCUSTHIST_CONTRACT_STATUS.AppearanceHeader.Options.UseFont = true;
            this.colCUSTHIST_CONTRACT_STATUS.AppearanceHeader.Options.UseTextOptions = true;
            this.colCUSTHIST_CONTRACT_STATUS.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Near;
            this.colCUSTHIST_CONTRACT_STATUS.AppearanceHeader.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
            this.colCUSTHIST_CONTRACT_STATUS.AppearanceHeader.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap;
            this.colCUSTHIST_CONTRACT_STATUS.Caption = "CONTRACT STATUS";
            this.colCUSTHIST_CONTRACT_STATUS.DisplayFormat.FormatString = "c2";
            this.colCUSTHIST_CONTRACT_STATUS.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.colCUSTHIST_CONTRACT_STATUS.FieldName = "CUSTHIST_CONTRACT_STATUS";
            this.colCUSTHIST_CONTRACT_STATUS.Name = "colCUSTHIST_CONTRACT_STATUS";
            this.colCUSTHIST_CONTRACT_STATUS.Visible = true;
            this.colCUSTHIST_CONTRACT_STATUS.VisibleIndex = 4;
            this.colCUSTHIST_CONTRACT_STATUS.Width = 100;
            // 
            // colCUSTHIST_LATE_CHARGE_BAL
            // 
            this.colCUSTHIST_LATE_CHARGE_BAL.AppearanceCell.Options.UseFont = true;
            this.colCUSTHIST_LATE_CHARGE_BAL.AppearanceHeader.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Bold);
            this.colCUSTHIST_LATE_CHARGE_BAL.AppearanceHeader.Options.UseFont = true;
            this.colCUSTHIST_LATE_CHARGE_BAL.AppearanceHeader.Options.UseTextOptions = true;
            this.colCUSTHIST_LATE_CHARGE_BAL.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Near;
            this.colCUSTHIST_LATE_CHARGE_BAL.AppearanceHeader.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
            this.colCUSTHIST_LATE_CHARGE_BAL.AppearanceHeader.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap;
            this.colCUSTHIST_LATE_CHARGE_BAL.Caption = "LATE CHARGE BALANCE";
            this.colCUSTHIST_LATE_CHARGE_BAL.DisplayFormat.FormatString = "c2";
            this.colCUSTHIST_LATE_CHARGE_BAL.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.colCUSTHIST_LATE_CHARGE_BAL.FieldName = "CUSTHIST_LATE_CHARGE_BAL";
            this.colCUSTHIST_LATE_CHARGE_BAL.Name = "colCUSTHIST_LATE_CHARGE_BAL";
            this.colCUSTHIST_LATE_CHARGE_BAL.Visible = true;
            this.colCUSTHIST_LATE_CHARGE_BAL.VisibleIndex = 5;
            this.colCUSTHIST_LATE_CHARGE_BAL.Width = 100;
            // 
            // colPartialPayment
            // 
            this.colPartialPayment.AppearanceCell.Options.UseFont = true;
            this.colPartialPayment.AppearanceHeader.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Bold);
            this.colPartialPayment.AppearanceHeader.Options.UseFont = true;
            this.colPartialPayment.AppearanceHeader.Options.UseTextOptions = true;
            this.colPartialPayment.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Near;
            this.colPartialPayment.AppearanceHeader.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
            this.colPartialPayment.AppearanceHeader.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap;
            this.colPartialPayment.Caption = "PARTIAL PAYMENT";
            this.colPartialPayment.DisplayFormat.FormatString = "c2";
            this.colPartialPayment.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.colPartialPayment.FieldName = "PartialPayment";
            this.colPartialPayment.Name = "colPartialPayment";
            this.colPartialPayment.Visible = true;
            this.colPartialPayment.VisibleIndex = 6;
            this.colPartialPayment.Width = 100;
            // 
            // colCUSTHIST_PAID_THRU
            // 
            this.colCUSTHIST_PAID_THRU.AppearanceCell.Options.UseFont = true;
            this.colCUSTHIST_PAID_THRU.AppearanceHeader.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Bold);
            this.colCUSTHIST_PAID_THRU.AppearanceHeader.Options.UseFont = true;
            this.colCUSTHIST_PAID_THRU.AppearanceHeader.Options.UseTextOptions = true;
            this.colCUSTHIST_PAID_THRU.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Near;
            this.colCUSTHIST_PAID_THRU.AppearanceHeader.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
            this.colCUSTHIST_PAID_THRU.AppearanceHeader.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap;
            this.colCUSTHIST_PAID_THRU.Caption = "PAID THROUGH";
            this.colCUSTHIST_PAID_THRU.FieldName = "SHORT_PAID_THRU";
            this.colCUSTHIST_PAID_THRU.Name = "colCUSTHIST_PAID_THRU";
            this.colCUSTHIST_PAID_THRU.Visible = true;
            this.colCUSTHIST_PAID_THRU.VisibleIndex = 7;
            this.colCUSTHIST_PAID_THRU.Width = 72;
            // 
            // colCUSTHIST_PAY_REM_1
            // 
            this.colCUSTHIST_PAY_REM_1.AppearanceCell.Options.UseFont = true;
            this.colCUSTHIST_PAY_REM_1.AppearanceHeader.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Bold);
            this.colCUSTHIST_PAY_REM_1.AppearanceHeader.Options.UseFont = true;
            this.colCUSTHIST_PAY_REM_1.AppearanceHeader.Options.UseTextOptions = true;
            this.colCUSTHIST_PAY_REM_1.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Near;
            this.colCUSTHIST_PAY_REM_1.AppearanceHeader.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
            this.colCUSTHIST_PAY_REM_1.AppearanceHeader.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap;
            this.colCUSTHIST_PAY_REM_1.Caption = "PMT DESC";
            this.colCUSTHIST_PAY_REM_1.FieldName = "CUSTHIST_PAY_REM_1";
            this.colCUSTHIST_PAY_REM_1.Name = "colCUSTHIST_PAY_REM_1";
            this.colCUSTHIST_PAY_REM_1.Visible = true;
            this.colCUSTHIST_PAY_REM_1.VisibleIndex = 8;
            this.colCUSTHIST_PAY_REM_1.Width = 56;
            // 
            // colCUSTHIST_PAYMENT_TYPE
            // 
            this.colCUSTHIST_PAYMENT_TYPE.AppearanceCell.Options.UseFont = true;
            this.colCUSTHIST_PAYMENT_TYPE.AppearanceHeader.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Bold);
            this.colCUSTHIST_PAYMENT_TYPE.AppearanceHeader.Options.UseFont = true;
            this.colCUSTHIST_PAYMENT_TYPE.AppearanceHeader.Options.UseTextOptions = true;
            this.colCUSTHIST_PAYMENT_TYPE.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Near;
            this.colCUSTHIST_PAYMENT_TYPE.AppearanceHeader.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
            this.colCUSTHIST_PAYMENT_TYPE.AppearanceHeader.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap;
            this.colCUSTHIST_PAYMENT_TYPE.Caption = "PMT TYPE";
            this.colCUSTHIST_PAYMENT_TYPE.FieldName = "CUSTHIST_PAYMENT_TYPE";
            this.colCUSTHIST_PAYMENT_TYPE.Name = "colCUSTHIST_PAYMENT_TYPE";
            this.colCUSTHIST_PAYMENT_TYPE.Visible = true;
            this.colCUSTHIST_PAYMENT_TYPE.VisibleIndex = 9;
            this.colCUSTHIST_PAYMENT_TYPE.Width = 62;
            // 
            // colCUSTHIST_PAYMENT_CODE
            // 
            this.colCUSTHIST_PAYMENT_CODE.AppearanceCell.Options.UseFont = true;
            this.colCUSTHIST_PAYMENT_CODE.AppearanceHeader.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Bold);
            this.colCUSTHIST_PAYMENT_CODE.AppearanceHeader.Options.UseFont = true;
            this.colCUSTHIST_PAYMENT_CODE.AppearanceHeader.Options.UseTextOptions = true;
            this.colCUSTHIST_PAYMENT_CODE.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Near;
            this.colCUSTHIST_PAYMENT_CODE.AppearanceHeader.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
            this.colCUSTHIST_PAYMENT_CODE.AppearanceHeader.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap;
            this.colCUSTHIST_PAYMENT_CODE.Caption = "PMT CODE";
            this.colCUSTHIST_PAYMENT_CODE.FieldName = "CUSTHIST_PAYMENT_CODE";
            this.colCUSTHIST_PAYMENT_CODE.Name = "colCUSTHIST_PAYMENT_CODE";
            this.colCUSTHIST_PAYMENT_CODE.Visible = true;
            this.colCUSTHIST_PAYMENT_CODE.VisibleIndex = 10;
            this.colCUSTHIST_PAYMENT_CODE.Width = 64;
            // 
            // colCUSTHIST_THRU_UD
            // 
            this.colCUSTHIST_THRU_UD.AppearanceCell.Options.UseFont = true;
            this.colCUSTHIST_THRU_UD.AppearanceCell.Options.UseTextOptions = true;
            this.colCUSTHIST_THRU_UD.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Near;
            this.colCUSTHIST_THRU_UD.AppearanceCell.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
            this.colCUSTHIST_THRU_UD.AppearanceHeader.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Bold);
            this.colCUSTHIST_THRU_UD.AppearanceHeader.Options.UseFont = true;
            this.colCUSTHIST_THRU_UD.AppearanceHeader.Options.UseTextOptions = true;
            this.colCUSTHIST_THRU_UD.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Near;
            this.colCUSTHIST_THRU_UD.AppearanceHeader.TextOptions.Trimming = DevExpress.Utils.Trimming.None;
            this.colCUSTHIST_THRU_UD.AppearanceHeader.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
            this.colCUSTHIST_THRU_UD.AppearanceHeader.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap;
            this.colCUSTHIST_THRU_UD.Caption = "EXT MONTHS";
            this.colCUSTHIST_THRU_UD.DisplayFormat.FormatString = "#;#; ";
            this.colCUSTHIST_THRU_UD.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.colCUSTHIST_THRU_UD.FieldName = "CUSTHIST_THRU_UD";
            this.colCUSTHIST_THRU_UD.Name = "colCUSTHIST_THRU_UD";
            this.colCUSTHIST_THRU_UD.Visible = true;
            this.colCUSTHIST_THRU_UD.VisibleIndex = 11;
            this.colCUSTHIST_THRU_UD.Width = 66;
            // 
            // groupBox8
            // 
            this.groupBox8.Controls.Add(this.textBox22);
            this.groupBox8.Controls.Add(this.txtPayDate);
            this.groupBox8.Controls.Add(this.textBox1);
            this.groupBox8.Controls.Add(label9);
            this.groupBox8.Controls.Add(this.textBox2);
            this.groupBox8.Controls.Add(label10);
            this.groupBox8.Controls.Add(this.textBox3);
            this.groupBox8.Controls.Add(this.textBox4);
            this.groupBox8.Controls.Add(this.textBox7);
            this.groupBox8.Controls.Add(this.textBox8);
            this.groupBox8.Controls.Add(this.textBox9);
            this.groupBox8.Controls.Add(label11);
            this.groupBox8.Controls.Add(label12);
            this.groupBox8.Controls.Add(this.label13);
            this.groupBox8.Controls.Add(label15);
            this.groupBox8.Location = new System.Drawing.Point(100, 13);
            this.groupBox8.Name = "groupBox8";
            this.groupBox8.Size = new System.Drawing.Size(814, 65);
            this.groupBox8.TabIndex = 99;
            this.groupBox8.TabStop = false;
            // 
            // textBox22
            // 
            this.textBox22.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.textBox22.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.CustomerbindingSource, "CUSTOMER_SUFFIX", true));
            this.textBox22.Location = new System.Drawing.Point(747, 11);
            this.textBox22.MaxLength = 3;
            this.textBox22.Name = "textBox22";
            this.textBox22.ReadOnly = true;
            this.textBox22.Size = new System.Drawing.Size(36, 22);
            this.textBox22.TabIndex = 96;
            // 
            // txtPayDate
            // 
            this.txtPayDate.Location = new System.Drawing.Point(316, 34);
            this.txtPayDate.Name = "txtPayDate";
            this.txtPayDate.ReadOnly = true;
            this.txtPayDate.Size = new System.Drawing.Size(86, 22);
            this.txtPayDate.TabIndex = 93;
            // 
            // textBox1
            // 
            this.textBox1.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.DealerbindingSource, "DEALER_NAME", true));
            this.textBox1.Location = new System.Drawing.Point(567, 34);
            this.textBox1.Name = "textBox1";
            this.textBox1.ReadOnly = true;
            this.textBox1.Size = new System.Drawing.Size(220, 22);
            this.textBox1.TabIndex = 95;
            // 
            // textBox2
            // 
            this.textBox2.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.CustomerbindingSource, "CUSTOMER_DEALER", true));
            this.textBox2.Location = new System.Drawing.Point(520, 34);
            this.textBox2.Name = "textBox2";
            this.textBox2.ReadOnly = true;
            this.textBox2.Size = new System.Drawing.Size(45, 22);
            this.textBox2.TabIndex = 94;
            this.textBox2.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // textBox3
            // 
            this.textBox3.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.CustomerbindingSource, "CUSTOMER_LAST_NAME", true));
            this.textBox3.Location = new System.Drawing.Point(614, 11);
            this.textBox3.Name = "textBox3";
            this.textBox3.ReadOnly = true;
            this.textBox3.Size = new System.Drawing.Size(131, 22);
            this.textBox3.TabIndex = 91;
            // 
            // textBox4
            // 
            this.textBox4.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.CustomerbindingSource, "CUSTOMER_FIRST_NAME", true));
            this.textBox4.Location = new System.Drawing.Point(520, 11);
            this.textBox4.Name = "textBox4";
            this.textBox4.ReadOnly = true;
            this.textBox4.Size = new System.Drawing.Size(92, 22);
            this.textBox4.TabIndex = 90;
            // 
            // textBox7
            // 
            this.textBox7.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.CustomerbindingSource, "CUSTOMER_PURCHASE_ORDER", true));
            this.textBox7.Location = new System.Drawing.Point(131, 34);
            this.textBox7.Name = "textBox7";
            this.textBox7.ReadOnly = true;
            this.textBox7.Size = new System.Drawing.Size(58, 22);
            this.textBox7.TabIndex = 92;
            this.textBox7.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // textBox8
            // 
            this.textBox8.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.CustomerbindingSource, "CUSTOMER_ADD_ON", true));
            this.textBox8.Location = new System.Drawing.Point(315, 11);
            this.textBox8.Name = "textBox8";
            this.textBox8.ReadOnly = true;
            this.textBox8.Size = new System.Drawing.Size(17, 22);
            this.textBox8.TabIndex = 89;
            // 
            // textBox9
            // 
            this.textBox9.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.CustomerbindingSource, "CUSTOMER_NO", true));
            this.textBox9.Location = new System.Drawing.Point(131, 11);
            this.textBox9.Name = "textBox9";
            this.textBox9.ReadOnly = true;
            this.textBox9.Size = new System.Drawing.Size(58, 22);
            this.textBox9.TabIndex = 88;
            this.textBox9.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label13.Location = new System.Drawing.Point(246, 18);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(53, 13);
            this.label13.TabIndex = 51;
            this.label13.Text = "ADD ON:";
            // 
            // tabComments
            // 
            this.tabComments.Appearance.PageClient.BackColor = System.Drawing.Color.LightSteelBlue;
            this.tabComments.Appearance.PageClient.Options.UseBackColor = true;
            this.tabComments.Controls.Add(this.groupControl3);
            this.tabComments.Name = "tabComments";
            this.tabComments.Padding = new System.Windows.Forms.Padding(3);
            this.tabComments.Size = new System.Drawing.Size(1009, 572);
            this.tabComments.Text = "Comments";
            // 
            // groupControl3
            // 
            this.groupControl3.Appearance.BackColor = System.Drawing.Color.LightSteelBlue;
            this.groupControl3.Appearance.Options.UseBackColor = true;
            this.groupControl3.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            this.groupControl3.Controls.Add(this.cOMMENTDataGridView);
            this.groupControl3.Controls.Add(this.groupBox7);
            this.groupControl3.Location = new System.Drawing.Point(-4, 0);
            this.groupControl3.Name = "groupControl3";
            this.groupControl3.Size = new System.Drawing.Size(1017, 576);
            this.groupControl3.TabIndex = 106;
            this.groupControl3.Text = "groupControl3";
            // 
            // cOMMENTDataGridView
            // 
            this.cOMMENTDataGridView.DataSource = this.cOMMENTBindingSource;
            this.cOMMENTDataGridView.Font = new System.Drawing.Font("Segoe UI", 8.25F);
            this.cOMMENTDataGridView.Location = new System.Drawing.Point(12, 113);
            this.cOMMENTDataGridView.MainView = this.cOMMENTgridView;
            this.cOMMENTDataGridView.Name = "cOMMENTDataGridView";
            this.cOMMENTDataGridView.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
            this.repositoryItemDateEdit1,
            this.repositoryItemPictureEdit1,
            this.repositoryItemTextEdit1,
            this.repositoryItemLookUpEditType,
            this.repositoryItemMemoEdit1});
            this.cOMMENTDataGridView.Size = new System.Drawing.Size(993, 449);
            this.cOMMENTDataGridView.TabIndex = 613;
            this.cOMMENTDataGridView.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.cOMMENTgridView});
            // 
            // cOMMENTBindingSource
            // 
            this.cOMMENTBindingSource.DataMember = "COMMENT";
            this.cOMMENTBindingSource.DataSource = this.ClosedPaymentiacDataSet;
            // 
            // cOMMENTgridView
            // 
            this.cOMMENTgridView.Appearance.Empty.Options.UseFont = true;
            this.cOMMENTgridView.Appearance.EvenRow.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.cOMMENTgridView.Appearance.EvenRow.Options.UseBackColor = true;
            this.cOMMENTgridView.Appearance.EvenRow.Options.UseFont = true;
            this.cOMMENTgridView.Appearance.EvenRow.Options.UseForeColor = true;
            this.cOMMENTgridView.Appearance.OddRow.Options.UseBackColor = true;
            this.cOMMENTgridView.Appearance.OddRow.Options.UseFont = true;
            this.cOMMENTgridView.Appearance.Preview.Options.UseFont = true;
            this.cOMMENTgridView.Appearance.Row.Options.UseFont = true;
            this.cOMMENTgridView.Appearance.SelectedRow.Options.UseFont = true;
            this.cOMMENTgridView.Appearance.TopNewRow.Options.UseFont = true;
            this.cOMMENTgridView.Appearance.TopNewRow.Options.UseTextOptions = true;
            this.cOMMENTgridView.Appearance.TopNewRow.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap;
            this.cOMMENTgridView.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.colDATE,
            this.colThumb,
            this.colLetterPath,
            this.colSMSPath,
            this.colTYPE,
            this.colCOMMENT_USERID,
            this.colCOMMENT,
            this.colCOMMENT_NO,
            this.colCOMMENT_SEQ_NO,
            this.colCOMMENT_ID_TYPE,
            this.colCOMMENT_DEALER,
            this.colCOMMENT_HHMMSS,
            this.colid1,
            this.colImgSort});
            this.cOMMENTgridView.GridControl = this.cOMMENTDataGridView;
            this.cOMMENTgridView.Name = "cOMMENTgridView";
            this.cOMMENTgridView.OptionsView.EnableAppearanceEvenRow = true;
            this.cOMMENTgridView.OptionsView.EnableAppearanceOddRow = true;
            this.cOMMENTgridView.OptionsView.RowAutoHeight = true;
            this.cOMMENTgridView.OptionsView.ShowGroupPanel = false;
            this.cOMMENTgridView.RowCellClick += new DevExpress.XtraGrid.Views.Grid.RowCellClickEventHandler(this.cOMMENTgridView_RowCellClick);
            this.cOMMENTgridView.InitNewRow += new DevExpress.XtraGrid.Views.Grid.InitNewRowEventHandler(this.cOMMENTgridView_InitNewRow);
            this.cOMMENTgridView.CellValueChanging += new DevExpress.XtraGrid.Views.Base.CellValueChangedEventHandler(this.cOMMENTgridView_CellValueChanging);
            this.cOMMENTgridView.CustomUnboundColumnData += new DevExpress.XtraGrid.Views.Base.CustomColumnDataEventHandler(this.cOMMENTgridView_CustomUnboundColumnData);
            this.cOMMENTgridView.KeyDown += new System.Windows.Forms.KeyEventHandler(this.cOMMENTgridView_KeyDown);
            // 
            // colDATE
            // 
            this.colDATE.AppearanceCell.Options.UseFont = true;
            this.colDATE.AppearanceCell.Options.UseTextOptions = true;
            this.colDATE.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
            this.colDATE.AppearanceHeader.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Bold);
            this.colDATE.AppearanceHeader.Options.UseFont = true;
            this.colDATE.Caption = "DATE";
            this.colDATE.ColumnEdit = this.repositoryItemDateEdit1;
            this.colDATE.FieldName = "COMMENT_DATE";
            this.colDATE.MinWidth = 10;
            this.colDATE.Name = "colDATE";
            this.colDATE.OptionsColumn.AllowEdit = false;
            this.colDATE.Visible = true;
            this.colDATE.VisibleIndex = 0;
            this.colDATE.Width = 102;
            // 
            // repositoryItemDateEdit1
            // 
            this.repositoryItemDateEdit1.AutoHeight = false;
            this.repositoryItemDateEdit1.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.repositoryItemDateEdit1.CalendarTimeProperties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.repositoryItemDateEdit1.Name = "repositoryItemDateEdit1";
            // 
            // colThumb
            // 
            this.colThumb.AppearanceCell.Options.UseFont = true;
            this.colThumb.AppearanceHeader.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Bold);
            this.colThumb.AppearanceHeader.Options.UseFont = true;
            this.colThumb.AppearanceHeader.Options.UseImage = true;
            this.colThumb.ColumnEdit = this.repositoryItemPictureEdit1;
            this.colThumb.FieldName = "colThumb";
            this.colThumb.ImageOptions.Alignment = System.Drawing.StringAlignment.Center;
            this.colThumb.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("colThumb.ImageOptions.Image")));
            this.colThumb.ImageOptions.ImageIndex = 1;
            this.colThumb.MinWidth = 10;
            this.colThumb.Name = "colThumb";
            this.colThumb.OptionsColumn.AllowEdit = false;
            this.colThumb.OptionsColumn.ReadOnly = true;
            this.colThumb.OptionsColumn.ShowCaption = false;
            this.colThumb.ShowUnboundExpressionMenu = true;
            this.colThumb.UnboundDataType = typeof(object);
            this.colThumb.Visible = true;
            this.colThumb.VisibleIndex = 1;
            this.colThumb.Width = 44;
            // 
            // repositoryItemPictureEdit1
            // 
            this.repositoryItemPictureEdit1.Name = "repositoryItemPictureEdit1";
            this.repositoryItemPictureEdit1.NullText = " ";
            // 
            // colLetterPath
            // 
            this.colLetterPath.AppearanceCell.Options.UseFont = true;
            this.colLetterPath.FieldName = "LetterPath";
            this.colLetterPath.Name = "colLetterPath";
            this.colLetterPath.OptionsColumn.AllowEdit = false;
            this.colLetterPath.Width = 20;
            // 
            // colSMSPath
            // 
            this.colSMSPath.AppearanceCell.Options.UseFont = true;
            this.colSMSPath.FieldName = "SMSPath";
            this.colSMSPath.Name = "colSMSPath";
            this.colSMSPath.OptionsColumn.AllowEdit = false;
            this.colSMSPath.Width = 20;
            // 
            // colTYPE
            // 
            this.colTYPE.AppearanceCell.Options.UseFont = true;
            this.colTYPE.AppearanceHeader.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Bold);
            this.colTYPE.AppearanceHeader.Options.UseFont = true;
            this.colTYPE.Caption = "TYPE";
            this.colTYPE.ColumnEdit = this.repositoryItemLookUpEditType;
            this.colTYPE.FieldName = "COMMENT_TYPE";
            this.colTYPE.MinWidth = 10;
            this.colTYPE.Name = "colTYPE";
            this.colTYPE.Visible = true;
            this.colTYPE.VisibleIndex = 2;
            this.colTYPE.Width = 50;
            // 
            // repositoryItemLookUpEditType
            // 
            this.repositoryItemLookUpEditType.AutoHeight = false;
            this.repositoryItemLookUpEditType.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.repositoryItemLookUpEditType.DataSource = this.commentTypesBindingSource;
            this.repositoryItemLookUpEditType.DisplayMember = "ListItems";
            this.repositoryItemLookUpEditType.KeyMember = "ID";
            this.repositoryItemLookUpEditType.Name = "repositoryItemLookUpEditType";
            this.repositoryItemLookUpEditType.NullText = " ";
            this.repositoryItemLookUpEditType.ValueMember = "Type";
            // 
            // commentTypesBindingSource
            // 
            this.commentTypesBindingSource.DataMember = "Comment_Types";
            this.commentTypesBindingSource.DataSource = this.ClosedPaymentiacDataSet;
            // 
            // colCOMMENT_USERID
            // 
            this.colCOMMENT_USERID.AppearanceCell.Options.UseFont = true;
            this.colCOMMENT_USERID.AppearanceCell.Options.UseTextOptions = true;
            this.colCOMMENT_USERID.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.colCOMMENT_USERID.AppearanceHeader.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Bold);
            this.colCOMMENT_USERID.AppearanceHeader.Options.UseFont = true;
            this.colCOMMENT_USERID.Caption = "ID";
            this.colCOMMENT_USERID.FieldName = "COMMENT_USERID";
            this.colCOMMENT_USERID.MinWidth = 10;
            this.colCOMMENT_USERID.Name = "colCOMMENT_USERID";
            this.colCOMMENT_USERID.OptionsColumn.AllowEdit = false;
            this.colCOMMENT_USERID.Visible = true;
            this.colCOMMENT_USERID.VisibleIndex = 3;
            this.colCOMMENT_USERID.Width = 40;
            // 
            // colCOMMENT
            // 
            this.colCOMMENT.AppearanceCell.Options.UseFont = true;
            this.colCOMMENT.AppearanceHeader.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Bold);
            this.colCOMMENT.AppearanceHeader.Options.UseFont = true;
            this.colCOMMENT.Caption = "COMMENT";
            this.colCOMMENT.ColumnEdit = this.repositoryItemMemoEdit1;
            this.colCOMMENT.FieldName = "COMMENT_WHOLE";
            this.colCOMMENT.FilterMode = DevExpress.XtraGrid.ColumnFilterMode.DisplayText;
            this.colCOMMENT.MinWidth = 100;
            this.colCOMMENT.Name = "colCOMMENT";
            this.colCOMMENT.Visible = true;
            this.colCOMMENT.VisibleIndex = 4;
            this.colCOMMENT.Width = 736;
            // 
            // repositoryItemMemoEdit1
            // 
            this.repositoryItemMemoEdit1.Name = "repositoryItemMemoEdit1";
            // 
            // colCOMMENT_NO
            // 
            this.colCOMMENT_NO.AppearanceCell.Options.UseFont = true;
            this.colCOMMENT_NO.FieldName = "COMMENT_NO";
            this.colCOMMENT_NO.Name = "colCOMMENT_NO";
            this.colCOMMENT_NO.OptionsColumn.AllowEdit = false;
            this.colCOMMENT_NO.Width = 20;
            // 
            // colCOMMENT_SEQ_NO
            // 
            this.colCOMMENT_SEQ_NO.AppearanceCell.Options.UseFont = true;
            this.colCOMMENT_SEQ_NO.FieldName = "COMMENT_SEQ_NO";
            this.colCOMMENT_SEQ_NO.Name = "colCOMMENT_SEQ_NO";
            this.colCOMMENT_SEQ_NO.OptionsColumn.AllowEdit = false;
            this.colCOMMENT_SEQ_NO.Width = 20;
            // 
            // colCOMMENT_ID_TYPE
            // 
            this.colCOMMENT_ID_TYPE.AppearanceCell.Options.UseFont = true;
            this.colCOMMENT_ID_TYPE.FieldName = "COMMENT_ID_TYPE";
            this.colCOMMENT_ID_TYPE.Name = "colCOMMENT_ID_TYPE";
            this.colCOMMENT_ID_TYPE.OptionsColumn.AllowEdit = false;
            this.colCOMMENT_ID_TYPE.Width = 21;
            // 
            // colCOMMENT_DEALER
            // 
            this.colCOMMENT_DEALER.AppearanceCell.Options.UseFont = true;
            this.colCOMMENT_DEALER.FieldName = "COMMENT_DEALER";
            this.colCOMMENT_DEALER.Name = "colCOMMENT_DEALER";
            this.colCOMMENT_DEALER.OptionsColumn.AllowEdit = false;
            this.colCOMMENT_DEALER.Width = 21;
            // 
            // colCOMMENT_HHMMSS
            // 
            this.colCOMMENT_HHMMSS.AppearanceCell.Options.UseFont = true;
            this.colCOMMENT_HHMMSS.FieldName = "COMMENT_HHMMSS";
            this.colCOMMENT_HHMMSS.Name = "colCOMMENT_HHMMSS";
            this.colCOMMENT_HHMMSS.OptionsColumn.AllowEdit = false;
            this.colCOMMENT_HHMMSS.Width = 21;
            // 
            // colid1
            // 
            this.colid1.AppearanceCell.Options.UseFont = true;
            this.colid1.FieldName = "id";
            this.colid1.Name = "colid1";
            // 
            // colImgSort
            // 
            this.colImgSort.AppearanceCell.Options.UseFont = true;
            this.colImgSort.FieldName = "ImgSort";
            this.colImgSort.Name = "colImgSort";
            this.colImgSort.OptionsColumn.AllowEdit = false;
            this.colImgSort.Width = 25;
            // 
            // repositoryItemTextEdit1
            // 
            this.repositoryItemTextEdit1.AutoHeight = false;
            this.repositoryItemTextEdit1.Name = "repositoryItemTextEdit1";
            // 
            // groupBox7
            // 
            this.groupBox7.Controls.Add(this.textBox23);
            this.groupBox7.Controls.Add(label16);
            this.groupBox7.Controls.Add(this.textBox10);
            this.groupBox7.Controls.Add(label17);
            this.groupBox7.Controls.Add(this.textBox11);
            this.groupBox7.Controls.Add(this.textBox12);
            this.groupBox7.Controls.Add(this.textBox13);
            this.groupBox7.Controls.Add(this.txtCommentNo);
            this.groupBox7.Controls.Add(label18);
            this.groupBox7.Location = new System.Drawing.Point(140, 14);
            this.groupBox7.Name = "groupBox7";
            this.groupBox7.Size = new System.Drawing.Size(737, 79);
            this.groupBox7.TabIndex = 105;
            this.groupBox7.TabStop = false;
            // 
            // textBox23
            // 
            this.textBox23.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.textBox23.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.CustomerbindingSource, "CUSTOMER_SUFFIX", true));
            this.textBox23.Location = new System.Drawing.Point(688, 22);
            this.textBox23.MaxLength = 3;
            this.textBox23.Name = "textBox23";
            this.textBox23.ReadOnly = true;
            this.textBox23.Size = new System.Drawing.Size(36, 22);
            this.textBox23.TabIndex = 102;
            // 
            // textBox10
            // 
            this.textBox10.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.DealerbindingSource, "DEALER_NAME", true));
            this.textBox10.Location = new System.Drawing.Point(465, 45);
            this.textBox10.Name = "textBox10";
            this.textBox10.ReadOnly = true;
            this.textBox10.Size = new System.Drawing.Size(220, 22);
            this.textBox10.TabIndex = 101;
            // 
            // textBox11
            // 
            this.textBox11.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.CustomerbindingSource, "CUSTOMER_DEALER", true));
            this.textBox11.Location = new System.Drawing.Point(418, 45);
            this.textBox11.Name = "textBox11";
            this.textBox11.ReadOnly = true;
            this.textBox11.Size = new System.Drawing.Size(45, 22);
            this.textBox11.TabIndex = 100;
            this.textBox11.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // textBox12
            // 
            this.textBox12.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.CustomerbindingSource, "CUSTOMER_LAST_NAME", true));
            this.textBox12.Location = new System.Drawing.Point(553, 22);
            this.textBox12.Name = "textBox12";
            this.textBox12.ReadOnly = true;
            this.textBox12.Size = new System.Drawing.Size(132, 22);
            this.textBox12.TabIndex = 99;
            // 
            // textBox13
            // 
            this.textBox13.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.CustomerbindingSource, "CUSTOMER_FIRST_NAME", true));
            this.textBox13.Location = new System.Drawing.Point(418, 22);
            this.textBox13.Name = "textBox13";
            this.textBox13.ReadOnly = true;
            this.textBox13.Size = new System.Drawing.Size(132, 22);
            this.textBox13.TabIndex = 98;
            // 
            // txtCommentNo
            // 
            this.txtCommentNo.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.CustomerbindingSource, "CUSTOMER_NO", true));
            this.txtCommentNo.Location = new System.Drawing.Point(110, 22);
            this.txtCommentNo.Name = "txtCommentNo";
            this.txtCommentNo.ReadOnly = true;
            this.txtCommentNo.Size = new System.Drawing.Size(58, 22);
            this.txtCommentNo.TabIndex = 97;
            this.txtCommentNo.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // cOMMENTTableAdapter
            // 
            this.cOMMENTTableAdapter.ClearBeforeFill = true;
            // 
            // cUSTHISTTableAdapter
            // 
            this.cUSTHISTTableAdapter.ClearBeforeFill = true;
            // 
            // comment_TypesTableAdapter
            // 
            this.comment_TypesTableAdapter.ClearBeforeFill = true;
            // 
            // paymentTableAdapter
            // 
            this.paymentTableAdapter.ClearBeforeFill = true;
            // 
            // specialCommentCodesTableAdapter
            // 
            this.specialCommentCodesTableAdapter.ClearBeforeFill = true;
            // 
            // groupControlTabPayments
            // 
            this.groupControlTabPayments.Appearance.BackColor = System.Drawing.Color.LightSteelBlue;
            this.groupControlTabPayments.Appearance.Options.UseBackColor = true;
            this.groupControlTabPayments.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            this.groupControlTabPayments.Location = new System.Drawing.Point(3, 28);
            this.groupControlTabPayments.Name = "groupControlTabPayments";
            this.groupControlTabPayments.Size = new System.Drawing.Size(896, 573);
            this.groupControlTabPayments.TabIndex = 1;
            this.groupControlTabPayments.Text = "groupControl1";
            // 
            // formClosedPayment
            // 
            this.Appearance.BackColor = System.Drawing.Color.CornflowerBlue;
            this.Appearance.Options.UseBackColor = true;
            this.Appearance.Options.UseFont = true;
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.ClientSize = new System.Drawing.Size(1018, 604);
            this.Controls.Add(this.tabClosedPayments);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LookAndFeel.SkinName = "McSkin";
            this.LookAndFeel.UseDefaultLookAndFeel = false;
            this.MaximizeBox = false;
            this.Name = "formClosedPayment";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = " Closed Payments";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.formClosedPayment_FormClosing);
            this.Load += new System.EventHandler(this.formClosedPayment_Load);
            ((System.ComponentModel.ISupportInitialize)(this.CustomerbindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ClosedPaymentiacDataSet)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.PaymentTypebindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.DealerbindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.PAYCODEbindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tabClosedPayments)).EndInit();
            this.tabClosedPayments.ResumeLayout(false);
            this.tabPayment.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.groupControl1)).EndInit();
            this.groupControl1.ResumeLayout(false);
            this.groupControl1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.bindingNavigator)).EndInit();
            this.bindingNavigator.ResumeLayout(false);
            this.bindingNavigator.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.PaymentbindingSource)).EndInit();
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.lookUpEditCodeType.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lookUpEditPaymentType.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.specialCommentCodesBindingSource)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.tabHistory.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.groupControl2)).EndInit();
            this.groupControl2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.cUSTHISTDataGridView)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cUSTHISTBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridViewCustomerHistory)).EndInit();
            this.groupBox8.ResumeLayout(false);
            this.groupBox8.PerformLayout();
            this.tabComments.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.groupControl3)).EndInit();
            this.groupControl3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.cOMMENTDataGridView)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cOMMENTBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cOMMENTgridView)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemDateEdit1.CalendarTimeProperties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemDateEdit1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemPictureEdit1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemLookUpEditType)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.commentTypesBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemMemoEdit1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemTextEdit1)).EndInit();
            this.groupBox7.ResumeLayout(false);
            this.groupBox7.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.groupControlTabPayments)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.BindingSource CustomerbindingSource;
        private IACDataSetTableAdapters.CUSTOMERTableAdapter cUSTOMERTableAdapter;
        private System.Windows.Forms.BindingSource PaymentTypebindingSource;
        private IACDataSetTableAdapters.PAYMENTTYPETableAdapter pAYMENTTYPETableAdapter;
        private System.Windows.Forms.BindingSource DealerbindingSource;
        private IACDataSetTableAdapters.DEALERTableAdapter dEALERTableAdapter;
        private System.Windows.Forms.BindingSource PAYCODEbindingSource;
        private IACDataSetTableAdapters.PAYCODETableAdapter pAYCODETableAdapter;
        private DevExpress.XtraTab.XtraTabControl tabClosedPayments;
        private DevExpress.XtraTab.XtraTabPage tabPayment;
        private DevExpress.XtraTab.XtraTabPage tabHistory;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.TextBox PaidThroughUDtextBox;
        private System.Windows.Forms.TextBox txtIncome;
        private System.Windows.Forms.TextBox txtOverPayment;
        private System.Windows.Forms.TextBox EFTtextBox;
        private System.Windows.Forms.TextBox txtCheckValue;
        private System.Windows.Forms.TextBox txtPaymentDate;
        private System.Windows.Forms.TextBox txtBuyout;
        private System.Windows.Forms.TextBox txtPaidThrough;
        private System.Windows.Forms.TextBox txtLoanBalance;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.TextBox textBox6;
        private System.Windows.Forms.TextBox DealertextBox;
        private System.Windows.Forms.TextBox textBox15;
        private System.Windows.Forms.TextBox textBox16;
        private System.Windows.Forms.TextBox cUSTOMER_Add_OnTextBox;
        private System.Windows.Forms.TextBox cUSTOMER_IAC_TypeTextBox;
        private System.Windows.Forms.TextBox cUSTOMER_NOTextBox;
        private System.Windows.Forms.ToolStrip toolStrip1;
        private DevExpress.XtraTab.XtraTabPage tabComments;
        private System.Windows.Forms.GroupBox groupBox8;
        private System.Windows.Forms.TextBox textBox22;
        private System.Windows.Forms.TextBox txtPayDate;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.TextBox textBox2;
        private System.Windows.Forms.TextBox textBox3;
        private System.Windows.Forms.TextBox textBox4;
        private System.Windows.Forms.TextBox textBox7;
        private System.Windows.Forms.TextBox textBox8;
        private System.Windows.Forms.TextBox textBox9;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.GroupBox groupBox7;
        private System.Windows.Forms.TextBox textBox23;
        private System.Windows.Forms.TextBox textBox10;
        private System.Windows.Forms.TextBox textBox11;
        private System.Windows.Forms.TextBox textBox12;
        private System.Windows.Forms.TextBox textBox13;
        private System.Windows.Forms.TextBox txtCommentNo;
        private System.Windows.Forms.BindingSource cOMMENTBindingSource;
        private IACDataSetTableAdapters.COMMENTTableAdapter cOMMENTTableAdapter;
        private System.Windows.Forms.BindingSource commentTypesBindingSource;
        private IACDataSetTableAdapters.Comment_TypesTableAdapter comment_TypesTableAdapter;
        private System.Windows.Forms.ToolStripButton toolStripButtonDelete;
        private System.Windows.Forms.ToolStripButton toolStripButtonSave;
        private System.Windows.Forms.ToolStripButton toolStripButtonEdit;
        private IACDataSetTableAdapters.PAYMENTTableAdapter paymentTableAdapter;
        private System.Windows.Forms.BindingSource PaymentbindingSource;
        private System.Windows.Forms.BindingNavigator bindingNavigator;
        private System.Windows.Forms.ToolStripLabel bindingNavigatorCountItem;
        private System.Windows.Forms.ToolStripButton bindingNavigatorMoveFirstItem;
        private System.Windows.Forms.ToolStripButton bindingNavigatorMovePreviousItem;
        private System.Windows.Forms.ToolStripSeparator bindingNavigatorSeparator;
        private System.Windows.Forms.ToolStripTextBox bindingNavigatorPositionItem;
        private System.Windows.Forms.ToolStripSeparator bindingNavigatorSeparator1;
        private System.Windows.Forms.ToolStripButton bindingNavigatorMoveNextItem;
        private System.Windows.Forms.ToolStripButton bindingNavigatorMoveLastItem;
        private System.Windows.Forms.ToolStripSeparator bindingNavigatorSeparator2;
        private System.Windows.Forms.ToolStripButton toolStripButtonAdd;
        public System.Windows.Forms.BindingSource cUSTHISTBindingSource;
        public IACDataSetTableAdapters.CUSTHISTTableAdapter cUSTHISTTableAdapter;
        private System.Windows.Forms.ToolStripButton toolStripButtonCancel;
        private System.Windows.Forms.ToolStripButton toolStripButton1;
        private DevExpress.XtraEditors.SimpleButton buttonChangeISFDate;
        private System.Windows.Forms.TextBox textBoxISFDate;
        private System.Windows.Forms.ListBox listBoxTSBCommentCode;
        private System.Windows.Forms.BindingSource specialCommentCodesBindingSource;
        private IACDataSetTableAdapters.SpecialCommentCodesTableAdapter specialCommentCodesTableAdapter;
        private System.Windows.Forms.CheckBox checkBoxNoAdjLookBack;
        private System.Windows.Forms.ToolStripButton toolStripButton2;
        private DevExpress.XtraEditors.LookUpEdit lookUpEditCodeType;
        private DevExpress.XtraEditors.LookUpEdit lookUpEditPaymentType;
        private DevExpress.XtraEditors.GroupControl groupControl1;
        private DevExpress.XtraEditors.GroupControl groupControlTabPayments;
        private DevExpress.XtraEditors.GroupControl groupControl2;
        private DevExpress.XtraEditors.GroupControl groupControl3;
        public IACDataSet ClosedPaymentiacDataSet;
        private DevExpress.XtraGrid.GridControl cUSTHISTDataGridView;
        private DevExpress.XtraGrid.Views.Grid.GridView gridViewCustomerHistory;
        private DevExpress.XtraGrid.Columns.GridColumn colCUSTHIST_PAY_DATE;
        private DevExpress.XtraGrid.Columns.GridColumn colCUSTHIST_ACT_STAT;
        private DevExpress.XtraGrid.Columns.GridColumn colCUSTHIST_PAYMENT_RCV;
        private DevExpress.XtraGrid.Columns.GridColumn colCUSTHIST_BALANCE;
        private DevExpress.XtraGrid.Columns.GridColumn colCUSTHIST_CONTRACT_STATUS;
        private DevExpress.XtraGrid.Columns.GridColumn colCUSTHIST_LATE_CHARGE_BAL;
        private DevExpress.XtraGrid.Columns.GridColumn colPartialPayment;
        private DevExpress.XtraGrid.Columns.GridColumn colCUSTHIST_PAID_THRU;
        private DevExpress.XtraGrid.Columns.GridColumn colCUSTHIST_PAY_REM_1;
        private DevExpress.XtraGrid.Columns.GridColumn colCUSTHIST_PAYMENT_TYPE;
        private DevExpress.XtraGrid.Columns.GridColumn colCUSTHIST_PAYMENT_CODE;
        private DevExpress.XtraGrid.Columns.GridColumn colCUSTHIST_THRU_UD;
        private DevExpress.XtraGrid.GridControl cOMMENTDataGridView;
        private DevExpress.XtraGrid.Views.Grid.GridView cOMMENTgridView;
        private DevExpress.XtraGrid.Columns.GridColumn colDATE;
        private DevExpress.XtraEditors.Repository.RepositoryItemDateEdit repositoryItemDateEdit1;
        private DevExpress.XtraGrid.Columns.GridColumn colThumb;
        private DevExpress.XtraEditors.Repository.RepositoryItemPictureEdit repositoryItemPictureEdit1;
        private DevExpress.XtraGrid.Columns.GridColumn colLetterPath;
        private DevExpress.XtraGrid.Columns.GridColumn colSMSPath;
        private DevExpress.XtraGrid.Columns.GridColumn colTYPE;
        private DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit repositoryItemLookUpEditType;
        private DevExpress.XtraGrid.Columns.GridColumn colCOMMENT_USERID;
        private DevExpress.XtraGrid.Columns.GridColumn colCOMMENT;
        private DevExpress.XtraEditors.Repository.RepositoryItemMemoEdit repositoryItemMemoEdit1;
        private DevExpress.XtraGrid.Columns.GridColumn colCOMMENT_NO;
        private DevExpress.XtraGrid.Columns.GridColumn colCOMMENT_SEQ_NO;
        private DevExpress.XtraGrid.Columns.GridColumn colCOMMENT_ID_TYPE;
        private DevExpress.XtraGrid.Columns.GridColumn colCOMMENT_DEALER;
        private DevExpress.XtraGrid.Columns.GridColumn colCOMMENT_HHMMSS;
        private DevExpress.XtraGrid.Columns.GridColumn colid1;
        private DevExpress.XtraGrid.Columns.GridColumn colImgSort;
        private DevExpress.XtraEditors.Repository.RepositoryItemTextEdit repositoryItemTextEdit1;
    }
}
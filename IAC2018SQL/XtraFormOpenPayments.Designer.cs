namespace IAC2021SQL
{
    partial class XtraFormOpenPayments
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
            DevExpress.DataAccess.Sql.StoredProcQuery storedProcQuery6 = new DevExpress.DataAccess.Sql.StoredProcQuery();
            DevExpress.DataAccess.Sql.QueryParameter queryParameter3 = new DevExpress.DataAccess.Sql.QueryParameter();
            DevExpress.DataAccess.Sql.StoredProcQuery storedProcQuery7 = new DevExpress.DataAccess.Sql.StoredProcQuery();
            DevExpress.DataAccess.Sql.QueryParameter queryParameter4 = new DevExpress.DataAccess.Sql.QueryParameter();
            DevExpress.DataAccess.Sql.StoredProcQuery storedProcQuery8 = new DevExpress.DataAccess.Sql.StoredProcQuery();
            DevExpress.DataAccess.Sql.StoredProcQuery storedProcQuery9 = new DevExpress.DataAccess.Sql.StoredProcQuery();
            DevExpress.DataAccess.Sql.StoredProcQuery storedProcQuery10 = new DevExpress.DataAccess.Sql.StoredProcQuery();
            DevExpress.DataAccess.Sql.MasterDetailInfo masterDetailInfo5 = new DevExpress.DataAccess.Sql.MasterDetailInfo();
            DevExpress.DataAccess.Sql.RelationColumnInfo relationColumnInfo5 = new DevExpress.DataAccess.Sql.RelationColumnInfo();
            DevExpress.DataAccess.Sql.MasterDetailInfo masterDetailInfo6 = new DevExpress.DataAccess.Sql.MasterDetailInfo();
            DevExpress.DataAccess.Sql.RelationColumnInfo relationColumnInfo6 = new DevExpress.DataAccess.Sql.RelationColumnInfo();
            DevExpress.DataAccess.Sql.MasterDetailInfo masterDetailInfo7 = new DevExpress.DataAccess.Sql.MasterDetailInfo();
            DevExpress.DataAccess.Sql.RelationColumnInfo relationColumnInfo7 = new DevExpress.DataAccess.Sql.RelationColumnInfo();
            DevExpress.DataAccess.Sql.MasterDetailInfo masterDetailInfo8 = new DevExpress.DataAccess.Sql.MasterDetailInfo();
            DevExpress.DataAccess.Sql.RelationColumnInfo relationColumnInfo8 = new DevExpress.DataAccess.Sql.RelationColumnInfo();
            DevExpress.XtraBars.Docking2010.WindowsUIButtonImageOptions windowsUIButtonImageOptions5 = new DevExpress.XtraBars.Docking2010.WindowsUIButtonImageOptions();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(XtraFormOpenPayments));
            DevExpress.XtraBars.Docking2010.WindowsUIButtonImageOptions windowsUIButtonImageOptions6 = new DevExpress.XtraBars.Docking2010.WindowsUIButtonImageOptions();
            DevExpress.XtraBars.Docking2010.WindowsUIButtonImageOptions windowsUIButtonImageOptions7 = new DevExpress.XtraBars.Docking2010.WindowsUIButtonImageOptions();
            DevExpress.XtraBars.Docking2010.WindowsUIButtonImageOptions windowsUIButtonImageOptions8 = new DevExpress.XtraBars.Docking2010.WindowsUIButtonImageOptions();
            this.CustomerbindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.OpenPaymentiacDataSet = new IAC2021SQL.IACDataSet();
            this.PaymentTypebindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.pAYMENTTYPETableAdapter = new IAC2021SQL.IACDataSetTableAdapters.PAYMENTTYPETableAdapter();
            this.DealerbindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.PAYCODEbindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.pAYCODETableAdapter = new IAC2021SQL.IACDataSetTableAdapters.PAYCODETableAdapter();
            this.tabClosedPayments = new DevExpress.XtraTab.XtraTabControl();
            this.tabPayment = new DevExpress.XtraTab.XtraTabPage();
            this.groupControl5 = new DevExpress.XtraEditors.GroupControl();
            this.layoutControlGridAndButtons = new DevExpress.XtraLayout.LayoutControl();
            this.gridControlPayments = new DevExpress.XtraGrid.GridControl();
            this.PaymentbindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.sqlDataSourceClosedPayments = new DevExpress.DataAccess.Sql.SqlDataSource(this.components);
            this.gridView2 = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.colPAYMENT_CUSTOMER = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colPAYMENT_DATE = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colPAYMENT_AMOUNT_RCV = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colPAYMENT_TYPE = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colPAYMENT_CODE_2 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colPAYMENT_AUTO_PAY = new DevExpress.XtraGrid.Columns.GridColumn();
            this.repositoryItemCheckEdit1 = new DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit();
            this.colPAYMENT_ISF_DATE = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colPAYMENT_THRU_UD = new DevExpress.XtraGrid.Columns.GridColumn();
            this.windowsUIButtonPanel1 = new DevExpress.XtraBars.Docking2010.WindowsUIButtonPanel();
            this.layoutControlGroup1 = new DevExpress.XtraLayout.LayoutControlGroup();
            this.layoutControlPaymentGrid = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem2 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlCustomerHeader = new DevExpress.XtraLayout.LayoutControl();
            this.textEditDealerName = new DevExpress.XtraEditors.TextEdit();
            this.textEditDealerID = new DevExpress.XtraEditors.TextEdit();
            this.textEditLastName = new DevExpress.XtraEditors.TextEdit();
            this.textEdit2 = new DevExpress.XtraEditors.TextEdit();
            this.textEditCustomerID = new DevExpress.XtraEditors.TextEdit();
            this.Root = new DevExpress.XtraLayout.LayoutControlGroup();
            this.layoutControlCustomerID = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutFirstName = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutLastName = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlDealerName = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlDealerID = new DevExpress.XtraLayout.LayoutControlItem();
            this.tabHistory = new DevExpress.XtraTab.XtraTabPage();
            this.groupControl2 = new DevExpress.XtraEditors.GroupControl();
            this.layoutControl2 = new DevExpress.XtraLayout.LayoutControl();
            this.textEdit7 = new DevExpress.XtraEditors.TextEdit();
            this.textEdit8 = new DevExpress.XtraEditors.TextEdit();
            this.textEdit9 = new DevExpress.XtraEditors.TextEdit();
            this.textEdit10 = new DevExpress.XtraEditors.TextEdit();
            this.textEdit11 = new DevExpress.XtraEditors.TextEdit();
            this.layoutControlGroup3 = new DevExpress.XtraLayout.LayoutControlGroup();
            this.layoutControlItem7 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem8 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem9 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem10 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem11 = new DevExpress.XtraLayout.LayoutControlItem();
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
            this.cOMMENTBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.commentTypesBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.specialCommentCodesBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.comment_TypesTableAdapter = new IAC2021SQL.IACDataSetTableAdapters.Comment_TypesTableAdapter();
            this.specialCommentCodesTableAdapter = new IAC2021SQL.IACDataSetTableAdapters.SpecialCommentCodesTableAdapter();
            this.groupControlTabPayments = new DevExpress.XtraEditors.GroupControl();
            this.miniToolStrip = new System.Windows.Forms.ToolStrip();
            this.toolStripButton8 = new System.Windows.Forms.ToolStripButton();
            this.toolStripButton9 = new System.Windows.Forms.ToolStripButton();
            this.toolStripButton10 = new System.Windows.Forms.ToolStripButton();
            this.toolStripButton11 = new System.Windows.Forms.ToolStripButton();
            this.toolStripButton12 = new System.Windows.Forms.ToolStripButton();
            this.toolStripButton13 = new System.Windows.Forms.ToolStripButton();
            this.toolStrip2 = new System.Windows.Forms.ToolStrip();
            this.htmlTemplateCollection1 = new DevExpress.Utils.Html.HtmlTemplateCollection();
            this.htmlTemplate1 = new DevExpress.Utils.Html.HtmlTemplate();
            this.svgImageCollection1 = new DevExpress.Utils.SvgImageCollection(this.components);
            this.oPNCUSTTableAdapter = new IAC2021SQL.IACDataSetTableAdapters.OPNCUSTTableAdapter();
            this.oPNDEALRTableAdapter = new IAC2021SQL.IACDataSetTableAdapters.OPNDEALRTableAdapter();
            this.oPNHCUSTTableAdapter = new IAC2021SQL.IACDataSetTableAdapters.OPNHCUSTTableAdapter();
            this.oPNCOMMTableAdapter = new IAC2021SQL.IACDataSetTableAdapters.OPNCOMMTableAdapter();
            this.opnpayTableAdapter = new IAC2021SQL.IACDataSetTableAdapters.OPNPAYTableAdapter();
            ((System.ComponentModel.ISupportInitialize)(this.CustomerbindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.OpenPaymentiacDataSet)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.PaymentTypebindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.DealerbindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.PAYCODEbindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tabClosedPayments)).BeginInit();
            this.tabClosedPayments.SuspendLayout();
            this.tabPayment.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl5)).BeginInit();
            this.groupControl5.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGridAndButtons)).BeginInit();
            this.layoutControlGridAndButtons.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridControlPayments)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.PaymentbindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemCheckEdit1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroup1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlPaymentGrid)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlCustomerHeader)).BeginInit();
            this.layoutControlCustomerHeader.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.textEditDealerName.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.textEditDealerID.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.textEditLastName.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.textEdit2.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.textEditCustomerID.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Root)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlCustomerID)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutFirstName)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutLastName)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlDealerName)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlDealerID)).BeginInit();
            this.tabHistory.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl2)).BeginInit();
            this.groupControl2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControl2)).BeginInit();
            this.layoutControl2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.textEdit7.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.textEdit8.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.textEdit9.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.textEdit10.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.textEdit11.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroup3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem7)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem8)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem9)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem10)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem11)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cUSTHISTDataGridView)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cUSTHISTBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridViewCustomerHistory)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cOMMENTBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.commentTypesBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.specialCommentCodesBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.groupControlTabPayments)).BeginInit();
            this.toolStrip2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.svgImageCollection1)).BeginInit();
            this.SuspendLayout();
            // 
            // CustomerbindingSource
            // 
            this.CustomerbindingSource.DataMember = "OPNCUST";
            this.CustomerbindingSource.DataSource = this.OpenPaymentiacDataSet;
            // 
            // OpenPaymentiacDataSet
            // 
            this.OpenPaymentiacDataSet.DataSetName = "IACDataSet";
            this.OpenPaymentiacDataSet.EnforceConstraints = false;
            this.OpenPaymentiacDataSet.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // PaymentTypebindingSource
            // 
            this.PaymentTypebindingSource.DataMember = "PAYMENTTYPE";
            this.PaymentTypebindingSource.DataSource = this.OpenPaymentiacDataSet;
            // 
            // pAYMENTTYPETableAdapter
            // 
            this.pAYMENTTYPETableAdapter.ClearBeforeFill = true;
            // 
            // DealerbindingSource
            // 
            this.DealerbindingSource.DataMember = "OPNDEALR";
            this.DealerbindingSource.DataSource = this.OpenPaymentiacDataSet;
            // 
            // PAYCODEbindingSource
            // 
            this.PAYCODEbindingSource.DataMember = "PAYCODE";
            this.PAYCODEbindingSource.DataSource = this.OpenPaymentiacDataSet;
            // 
            // pAYCODETableAdapter
            // 
            this.pAYCODETableAdapter.ClearBeforeFill = true;
            // 
            // tabClosedPayments
            // 
            this.tabClosedPayments.Appearance.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tabClosedPayments.Appearance.Options.UseFont = true;
            this.tabClosedPayments.Location = new System.Drawing.Point(1, 2);
            this.tabClosedPayments.Name = "tabClosedPayments";
            this.tabClosedPayments.SelectedTabPage = this.tabPayment;
            this.tabClosedPayments.Size = new System.Drawing.Size(1017, 602);
            this.tabClosedPayments.TabIndex = 159;
            this.tabClosedPayments.TabPages.AddRange(new DevExpress.XtraTab.XtraTabPage[] {
            this.tabPayment,
            this.tabHistory});
            this.tabClosedPayments.SelectedPageChanged += new DevExpress.XtraTab.TabPageChangedEventHandler(this.tabClosedPayments_SelectedPageChanged);
            // 
            // tabPayment
            // 
            this.tabPayment.Controls.Add(this.groupControl5);
            this.tabPayment.Name = "tabPayment";
            this.tabPayment.Size = new System.Drawing.Size(1009, 572);
            this.tabPayment.Text = "Payments";
            // 
            // groupControl5
            // 
            this.groupControl5.Appearance.BackColor = System.Drawing.Color.LightSteelBlue;
            this.groupControl5.Appearance.Options.UseBackColor = true;
            this.groupControl5.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            this.groupControl5.Controls.Add(this.layoutControlGridAndButtons);
            this.groupControl5.Controls.Add(this.layoutControlCustomerHeader);
            this.groupControl5.Location = new System.Drawing.Point(-6, -2);
            this.groupControl5.Name = "groupControl5";
            this.groupControl5.Size = new System.Drawing.Size(1020, 576);
            this.groupControl5.TabIndex = 165;
            this.groupControl5.Text = "groupControl5";
            // 
            // layoutControlGridAndButtons
            // 
            this.layoutControlGridAndButtons.Controls.Add(this.gridControlPayments);
            this.layoutControlGridAndButtons.Controls.Add(this.windowsUIButtonPanel1);
            this.layoutControlGridAndButtons.Location = new System.Drawing.Point(7, 82);
            this.layoutControlGridAndButtons.Name = "layoutControlGridAndButtons";
            this.layoutControlGridAndButtons.OptionsCustomizationForm.DesignTimeCustomizationFormPositionAndSize = new System.Drawing.Rectangle(1270, 338, 650, 400);
            this.layoutControlGridAndButtons.Root = this.layoutControlGroup1;
            this.layoutControlGridAndButtons.Size = new System.Drawing.Size(1007, 495);
            this.layoutControlGridAndButtons.TabIndex = 166;
            this.layoutControlGridAndButtons.Text = "layoutControl1";
            // 
            // gridControlPayments
            // 
            this.gridControlPayments.DataSource = this.PaymentbindingSource;
            this.gridControlPayments.Location = new System.Drawing.Point(12, 12);
            this.gridControlPayments.MainView = this.gridView2;
            this.gridControlPayments.Name = "gridControlPayments";
            this.gridControlPayments.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
            this.repositoryItemCheckEdit1});
            this.gridControlPayments.Size = new System.Drawing.Size(702, 471);
            this.gridControlPayments.TabIndex = 163;
            this.gridControlPayments.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridView2});
            // 
            // PaymentbindingSource
            // 
            this.PaymentbindingSource.DataMember = "OPNPAY";
            this.PaymentbindingSource.DataSource = this.sqlDataSourceClosedPayments;
            this.PaymentbindingSource.PositionChanged += new System.EventHandler(this.PaymentbindingSource_PositionChanged);
            // 
            // sqlDataSourceClosedPayments
            // 
            this.sqlDataSourceClosedPayments.ConnectionName = "IAC2021SQL.Properties.Settings.IAC2010SQLConnectionString";
            this.sqlDataSourceClosedPayments.Name = "sqlDataSourceClosedPayments";
            storedProcQuery6.Name = "OPNCUST";
            queryParameter3.Name = "@CUSTOMER_NO";
            queryParameter3.Type = typeof(string);
            queryParameter3.ValueInfo = "020967";
            storedProcQuery6.Parameters.AddRange(new DevExpress.DataAccess.Sql.QueryParameter[] {
            queryParameter3});
            storedProcQuery6.StoredProcName = "OpenCustomerSelect";
            storedProcQuery7.Name = "OPNDEALR";
            queryParameter4.Name = "@OPNDEALR_ACC_NO";
            queryParameter4.Type = typeof(string);
            queryParameter4.ValueInfo = "015";
            storedProcQuery7.Parameters.AddRange(new DevExpress.DataAccess.Sql.QueryParameter[] {
            queryParameter4});
            storedProcQuery7.StoredProcName = "OpenDealerSelect";
            storedProcQuery8.Name = "PAYCODE";
            storedProcQuery8.StoredProcName = "PayCodeSelect";
            storedProcQuery9.Name = "OPNPAY";
            storedProcQuery9.StoredProcName = "OpenPaymentFillByall";
            storedProcQuery10.Name = "PAYMENTTYPE";
            storedProcQuery10.StoredProcName = "PaymentTypeSelect";
            this.sqlDataSourceClosedPayments.Queries.AddRange(new DevExpress.DataAccess.Sql.SqlQuery[] {
            storedProcQuery6,
            storedProcQuery7,
            storedProcQuery8,
            storedProcQuery9,
            storedProcQuery10});
            masterDetailInfo5.DetailQueryName = "PAYMENTTYPE";
            relationColumnInfo5.NestedKeyColumn = "TYPE";
            relationColumnInfo5.ParentKeyColumn = "PAYMENT_TYPE";
            masterDetailInfo5.KeyColumns.Add(relationColumnInfo5);
            masterDetailInfo5.MasterQueryName = "OPNPAY";
            masterDetailInfo6.DetailQueryName = "PAYCODE";
            relationColumnInfo6.NestedKeyColumn = "CODE";
            relationColumnInfo6.ParentKeyColumn = "PAYMENT_CODE_2";
            masterDetailInfo6.KeyColumns.Add(relationColumnInfo6);
            masterDetailInfo6.MasterQueryName = "OPNPAY";
            masterDetailInfo7.DetailQueryName = "OPNCUST";
            relationColumnInfo7.NestedKeyColumn = "CUSTOMER_NO";
            relationColumnInfo7.ParentKeyColumn = "PAYMENT_CUSTOMER";
            masterDetailInfo7.KeyColumns.Add(relationColumnInfo7);
            masterDetailInfo7.MasterQueryName = "OPNPAY";
            masterDetailInfo8.DetailQueryName = "OPNDLR";
            relationColumnInfo8.NestedKeyColumn = "OPNDEALR_ACC_NO";
            relationColumnInfo8.ParentKeyColumn = "PAYMENT_DEALER";
            masterDetailInfo8.KeyColumns.Add(relationColumnInfo8);
            masterDetailInfo8.MasterQueryName = "OPNPAY";
            this.sqlDataSourceClosedPayments.Relations.AddRange(new DevExpress.DataAccess.Sql.MasterDetailInfo[] {
            masterDetailInfo5,
            masterDetailInfo6,
            masterDetailInfo7,
            masterDetailInfo8});
            this.sqlDataSourceClosedPayments.ResultSchemaSerializable = resources.GetString("sqlDataSourceClosedPayments.ResultSchemaSerializable");
            // 
            // gridView2
            // 
            this.gridView2.Appearance.EvenRow.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.gridView2.Appearance.EvenRow.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gridView2.Appearance.EvenRow.Options.UseBackColor = true;
            this.gridView2.Appearance.EvenRow.Options.UseFont = true;
            this.gridView2.Appearance.EvenRow.Options.UseTextOptions = true;
            this.gridView2.Appearance.EvenRow.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.gridView2.Appearance.FooterPanel.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gridView2.Appearance.FooterPanel.Options.UseFont = true;
            this.gridView2.Appearance.HeaderPanel.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gridView2.Appearance.HeaderPanel.Options.UseFont = true;
            this.gridView2.Appearance.HeaderPanel.Options.UseTextOptions = true;
            this.gridView2.Appearance.HeaderPanel.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.gridView2.Appearance.OddRow.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gridView2.Appearance.OddRow.Options.UseFont = true;
            this.gridView2.Appearance.OddRow.Options.UseTextOptions = true;
            this.gridView2.Appearance.OddRow.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.gridView2.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.colPAYMENT_CUSTOMER,
            this.colPAYMENT_DATE,
            this.colPAYMENT_AMOUNT_RCV,
            this.colPAYMENT_TYPE,
            this.colPAYMENT_CODE_2,
            this.colPAYMENT_AUTO_PAY,
            this.colPAYMENT_ISF_DATE,
            this.colPAYMENT_THRU_UD});
            this.gridView2.GridControl = this.gridControlPayments;
            this.gridView2.Name = "gridView2";
            this.gridView2.OptionsBehavior.Editable = false;
            this.gridView2.OptionsBehavior.ReadOnly = true;
            this.gridView2.OptionsDetail.EnableMasterViewMode = false;
            this.gridView2.OptionsView.ColumnAutoWidth = false;
            this.gridView2.OptionsView.EnableAppearanceEvenRow = true;
            this.gridView2.OptionsView.EnableAppearanceOddRow = true;
            this.gridView2.OptionsView.ShowDetailButtons = false;
            this.gridView2.OptionsView.ShowFooter = true;
            this.gridView2.CustomDrawFooterCell += new DevExpress.XtraGrid.Views.Grid.FooterCellCustomDrawEventHandler(this.gridView2_CustomDrawFooterCell);
            this.gridView2.CustomColumnDisplayText += new DevExpress.XtraGrid.Views.Base.CustomColumnDisplayTextEventHandler(this.gridView2_CustomColumnDisplayText);
            // 
            // colPAYMENT_CUSTOMER
            // 
            this.colPAYMENT_CUSTOMER.AppearanceCell.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.colPAYMENT_CUSTOMER.AppearanceCell.Options.UseFont = true;
            this.colPAYMENT_CUSTOMER.Caption = "Customer";
            this.colPAYMENT_CUSTOMER.FieldName = "PAYMENT_CUSTOMER";
            this.colPAYMENT_CUSTOMER.Name = "colPAYMENT_CUSTOMER";
            this.colPAYMENT_CUSTOMER.Summary.AddRange(new DevExpress.XtraGrid.GridSummaryItem[] {
            new DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Count, "SeqNo", "{0} Payments")});
            this.colPAYMENT_CUSTOMER.Visible = true;
            this.colPAYMENT_CUSTOMER.VisibleIndex = 0;
            this.colPAYMENT_CUSTOMER.Width = 103;
            // 
            // colPAYMENT_DATE
            // 
            this.colPAYMENT_DATE.AppearanceCell.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.colPAYMENT_DATE.AppearanceCell.Options.UseFont = true;
            this.colPAYMENT_DATE.Caption = "Date";
            this.colPAYMENT_DATE.DisplayFormat.FormatString = "d";
            this.colPAYMENT_DATE.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            this.colPAYMENT_DATE.FieldName = "PAYMENT_DATE";
            this.colPAYMENT_DATE.Name = "colPAYMENT_DATE";
            this.colPAYMENT_DATE.Visible = true;
            this.colPAYMENT_DATE.VisibleIndex = 1;
            this.colPAYMENT_DATE.Width = 111;
            // 
            // colPAYMENT_AMOUNT_RCV
            // 
            this.colPAYMENT_AMOUNT_RCV.AppearanceCell.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.colPAYMENT_AMOUNT_RCV.AppearanceCell.Options.UseFont = true;
            this.colPAYMENT_AMOUNT_RCV.Caption = "Amount";
            this.colPAYMENT_AMOUNT_RCV.DisplayFormat.FormatString = "c2";
            this.colPAYMENT_AMOUNT_RCV.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.colPAYMENT_AMOUNT_RCV.FieldName = "PAYMENT_AMOUNT_RCV";
            this.colPAYMENT_AMOUNT_RCV.Name = "colPAYMENT_AMOUNT_RCV";
            this.colPAYMENT_AMOUNT_RCV.Visible = true;
            this.colPAYMENT_AMOUNT_RCV.VisibleIndex = 2;
            this.colPAYMENT_AMOUNT_RCV.Width = 122;
            // 
            // colPAYMENT_TYPE
            // 
            this.colPAYMENT_TYPE.AppearanceCell.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.colPAYMENT_TYPE.AppearanceCell.Options.UseFont = true;
            this.colPAYMENT_TYPE.Caption = "Type";
            this.colPAYMENT_TYPE.DisplayFormat.FormatString = "#";
            this.colPAYMENT_TYPE.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Custom;
            this.colPAYMENT_TYPE.FieldName = "PAYMENT_TYPE";
            this.colPAYMENT_TYPE.Name = "colPAYMENT_TYPE";
            this.colPAYMENT_TYPE.Visible = true;
            this.colPAYMENT_TYPE.VisibleIndex = 3;
            this.colPAYMENT_TYPE.Width = 48;
            // 
            // colPAYMENT_CODE_2
            // 
            this.colPAYMENT_CODE_2.AppearanceCell.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.colPAYMENT_CODE_2.AppearanceCell.Options.UseFont = true;
            this.colPAYMENT_CODE_2.Caption = "Code";
            this.colPAYMENT_CODE_2.DisplayFormat.FormatString = "#";
            this.colPAYMENT_CODE_2.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Custom;
            this.colPAYMENT_CODE_2.FieldName = "PAYMENT_CODE_2";
            this.colPAYMENT_CODE_2.Name = "colPAYMENT_CODE_2";
            this.colPAYMENT_CODE_2.Visible = true;
            this.colPAYMENT_CODE_2.VisibleIndex = 4;
            this.colPAYMENT_CODE_2.Width = 50;
            // 
            // colPAYMENT_AUTO_PAY
            // 
            this.colPAYMENT_AUTO_PAY.AppearanceCell.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.colPAYMENT_AUTO_PAY.AppearanceCell.Options.UseFont = true;
            this.colPAYMENT_AUTO_PAY.Caption = "EFT";
            this.colPAYMENT_AUTO_PAY.ColumnEdit = this.repositoryItemCheckEdit1;
            this.colPAYMENT_AUTO_PAY.FieldName = "PAYMENT_AUTO_PAY";
            this.colPAYMENT_AUTO_PAY.Name = "colPAYMENT_AUTO_PAY";
            this.colPAYMENT_AUTO_PAY.Visible = true;
            this.colPAYMENT_AUTO_PAY.VisibleIndex = 6;
            this.colPAYMENT_AUTO_PAY.Width = 53;
            // 
            // repositoryItemCheckEdit1
            // 
            this.repositoryItemCheckEdit1.Appearance.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.repositoryItemCheckEdit1.Appearance.Options.UseFont = true;
            this.repositoryItemCheckEdit1.AutoHeight = false;
            this.repositoryItemCheckEdit1.CheckBoxOptions.Style = DevExpress.XtraEditors.Controls.CheckBoxStyle.SvgCheckBox1;
            this.repositoryItemCheckEdit1.Name = "repositoryItemCheckEdit1";
            this.repositoryItemCheckEdit1.NullStyle = DevExpress.XtraEditors.Controls.StyleIndeterminate.Unchecked;
            this.repositoryItemCheckEdit1.QueryCheckStateByValue += new DevExpress.XtraEditors.Controls.QueryCheckStateByValueEventHandler(this.repositoryItemCheckEdit1_QueryCheckStateByValue);
            this.repositoryItemCheckEdit1.QueryValueByCheckState += new DevExpress.XtraEditors.Controls.QueryValueByCheckStateEventHandler(this.repositoryItemCheckEdit1_QueryValueByCheckState);
            // 
            // colPAYMENT_ISF_DATE
            // 
            this.colPAYMENT_ISF_DATE.AppearanceCell.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.colPAYMENT_ISF_DATE.AppearanceCell.Options.UseFont = true;
            this.colPAYMENT_ISF_DATE.Caption = "ISF Date";
            this.colPAYMENT_ISF_DATE.DisplayFormat.FormatString = "d";
            this.colPAYMENT_ISF_DATE.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            this.colPAYMENT_ISF_DATE.FieldName = "PAYMENT_ISF_DATE";
            this.colPAYMENT_ISF_DATE.Name = "colPAYMENT_ISF_DATE";
            this.colPAYMENT_ISF_DATE.Visible = true;
            this.colPAYMENT_ISF_DATE.VisibleIndex = 5;
            this.colPAYMENT_ISF_DATE.Width = 100;
            // 
            // colPAYMENT_THRU_UD
            // 
            this.colPAYMENT_THRU_UD.AppearanceCell.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.colPAYMENT_THRU_UD.AppearanceCell.Options.UseFont = true;
            this.colPAYMENT_THRU_UD.Caption = "Ext";
            this.colPAYMENT_THRU_UD.FieldName = "PAYMENT_THRU_UD";
            this.colPAYMENT_THRU_UD.Name = "colPAYMENT_THRU_UD";
            this.colPAYMENT_THRU_UD.Visible = true;
            this.colPAYMENT_THRU_UD.VisibleIndex = 7;
            // 
            // windowsUIButtonPanel1
            // 
            this.windowsUIButtonPanel1.AllowGlyphSkinning = false;
            this.windowsUIButtonPanel1.AppearanceButton.Hovered.Font = new System.Drawing.Font("Segoe UI Semibold", 12F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.windowsUIButtonPanel1.AppearanceButton.Hovered.Options.UseFont = true;
            this.windowsUIButtonPanel1.AppearanceButton.Normal.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.windowsUIButtonPanel1.AppearanceButton.Normal.Options.UseFont = true;
            this.windowsUIButtonPanel1.AppearanceButton.Pressed.Font = new System.Drawing.Font("Segoe UI", 12F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.windowsUIButtonPanel1.AppearanceButton.Pressed.Options.UseFont = true;
            windowsUIButtonImageOptions5.Image = ((System.Drawing.Image)(resources.GetObject("windowsUIButtonImageOptions5.Image")));
            windowsUIButtonImageOptions5.SvgImageColorizationMode = DevExpress.Utils.SvgImageColorizationMode.CommonPalette;
            windowsUIButtonImageOptions6.Image = ((System.Drawing.Image)(resources.GetObject("windowsUIButtonImageOptions6.Image")));
            windowsUIButtonImageOptions7.Image = ((System.Drawing.Image)(resources.GetObject("windowsUIButtonImageOptions7.Image")));
            windowsUIButtonImageOptions7.SvgImageColorizationMode = DevExpress.Utils.SvgImageColorizationMode.Full;
            windowsUIButtonImageOptions8.Image = ((System.Drawing.Image)(resources.GetObject("windowsUIButtonImageOptions8.Image")));
            this.windowsUIButtonPanel1.Buttons.AddRange(new DevExpress.XtraEditors.ButtonPanel.IBaseButton[] {
            new DevExpress.XtraBars.Docking2010.WindowsUIButton("Add", true, windowsUIButtonImageOptions5, DevExpress.XtraBars.Docking2010.ButtonStyle.PushButton, "", -1, true, null, true, false, true, null, 0, false),
            new DevExpress.XtraBars.Docking2010.WindowsUIButton("Edit", true, windowsUIButtonImageOptions6, DevExpress.XtraBars.Docking2010.ButtonStyle.PushButton, "", -1, true, null, true, false, true, null, 1, false),
            new DevExpress.XtraBars.Docking2010.WindowsUIButton("Delete", true, windowsUIButtonImageOptions7, DevExpress.XtraBars.Docking2010.ButtonStyle.PushButton, "", -1, true, null, true, false, true, null, 2, false),
            new DevExpress.XtraBars.Docking2010.WindowsUIButton("Exit", true, windowsUIButtonImageOptions8, DevExpress.XtraBars.Docking2010.ButtonStyle.PushButton, "", -1, true, null, true, false, true, null, 3, false)});
            this.windowsUIButtonPanel1.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.windowsUIButtonPanel1.Location = new System.Drawing.Point(718, 12);
            this.windowsUIButtonPanel1.Name = "windowsUIButtonPanel1";
            this.windowsUIButtonPanel1.Orientation = System.Windows.Forms.Orientation.Vertical;
            this.windowsUIButtonPanel1.Size = new System.Drawing.Size(277, 471);
            this.windowsUIButtonPanel1.TabIndex = 165;
            this.windowsUIButtonPanel1.Text = "windowsUIButtonPanel1";
            this.windowsUIButtonPanel1.ButtonClick += new DevExpress.XtraBars.Docking2010.ButtonEventHandler(this.windowsUIButtonPanel1_ButtonClick);
            // 
            // layoutControlGroup1
            // 
            this.layoutControlGroup1.EnableIndentsWithoutBorders = DevExpress.Utils.DefaultBoolean.True;
            this.layoutControlGroup1.GroupBordersVisible = false;
            this.layoutControlGroup1.Items.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[] {
            this.layoutControlPaymentGrid,
            this.layoutControlItem2});
            this.layoutControlGroup1.Name = "Root";
            this.layoutControlGroup1.Size = new System.Drawing.Size(1007, 495);
            this.layoutControlGroup1.TextVisible = false;
            // 
            // layoutControlPaymentGrid
            // 
            this.layoutControlPaymentGrid.Control = this.gridControlPayments;
            this.layoutControlPaymentGrid.Location = new System.Drawing.Point(0, 0);
            this.layoutControlPaymentGrid.MinSize = new System.Drawing.Size(104, 24);
            this.layoutControlPaymentGrid.Name = "layoutControlPaymentGrid";
            this.layoutControlPaymentGrid.Size = new System.Drawing.Size(706, 475);
            this.layoutControlPaymentGrid.SizeConstraintsType = DevExpress.XtraLayout.SizeConstraintsType.Custom;
            this.layoutControlPaymentGrid.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlPaymentGrid.TextVisible = false;
            // 
            // layoutControlItem2
            // 
            this.layoutControlItem2.Control = this.windowsUIButtonPanel1;
            this.layoutControlItem2.Location = new System.Drawing.Point(706, 0);
            this.layoutControlItem2.MinSize = new System.Drawing.Size(54, 4);
            this.layoutControlItem2.Name = "layoutControlItem2";
            this.layoutControlItem2.Size = new System.Drawing.Size(281, 475);
            this.layoutControlItem2.SizeConstraintsType = DevExpress.XtraLayout.SizeConstraintsType.Custom;
            this.layoutControlItem2.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlItem2.TextVisible = false;
            // 
            // layoutControlCustomerHeader
            // 
            this.layoutControlCustomerHeader.AutoScroll = false;
            this.layoutControlCustomerHeader.Controls.Add(this.textEditDealerName);
            this.layoutControlCustomerHeader.Controls.Add(this.textEditDealerID);
            this.layoutControlCustomerHeader.Controls.Add(this.textEditLastName);
            this.layoutControlCustomerHeader.Controls.Add(this.textEdit2);
            this.layoutControlCustomerHeader.Controls.Add(this.textEditCustomerID);
            this.layoutControlCustomerHeader.Dock = System.Windows.Forms.DockStyle.Top;
            this.layoutControlCustomerHeader.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.layoutControlCustomerHeader.Location = new System.Drawing.Point(0, 0);
            this.layoutControlCustomerHeader.Name = "layoutControlCustomerHeader";
            this.layoutControlCustomerHeader.OptionsCustomizationForm.DesignTimeCustomizationFormPositionAndSize = new System.Drawing.Rectangle(1161, 0, 650, 400);
            this.layoutControlCustomerHeader.Root = this.Root;
            this.layoutControlCustomerHeader.Size = new System.Drawing.Size(1020, 81);
            this.layoutControlCustomerHeader.TabIndex = 164;
            this.layoutControlCustomerHeader.Text = "layoutControl1";
            // 
            // textEditDealerName
            // 
            this.textEditDealerName.DataBindings.Add(new System.Windows.Forms.Binding("EditValue", this.DealerbindingSource, "OPNDEALR_NAME", true));
            this.textEditDealerName.Location = new System.Drawing.Point(295, 44);
            this.textEditDealerName.Name = "textEditDealerName";
            this.textEditDealerName.Properties.Appearance.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textEditDealerName.Properties.Appearance.Options.UseFont = true;
            this.textEditDealerName.Size = new System.Drawing.Size(713, 28);
            this.textEditDealerName.StyleController = this.layoutControlCustomerHeader;
            this.textEditDealerName.TabIndex = 8;
            // 
            // textEditDealerID
            // 
            this.textEditDealerID.DataBindings.Add(new System.Windows.Forms.Binding("EditValue", this.DealerbindingSource, "OPNDEALR_ACC_NO", true));
            this.textEditDealerID.Location = new System.Drawing.Point(116, 44);
            this.textEditDealerID.Name = "textEditDealerID";
            this.textEditDealerID.Properties.Appearance.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textEditDealerID.Properties.Appearance.Options.UseFont = true;
            this.textEditDealerID.Size = new System.Drawing.Size(71, 28);
            this.textEditDealerID.StyleController = this.layoutControlCustomerHeader;
            this.textEditDealerID.TabIndex = 7;
            // 
            // textEditLastName
            // 
            this.textEditLastName.DataBindings.Add(new System.Windows.Forms.Binding("EditValue", this.CustomerbindingSource, "CUSTOMER_LAST_NAME", true));
            this.textEditLastName.Location = new System.Drawing.Point(684, 12);
            this.textEditLastName.Name = "textEditLastName";
            this.textEditLastName.Properties.Appearance.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textEditLastName.Properties.Appearance.Options.UseFont = true;
            this.textEditLastName.Size = new System.Drawing.Size(324, 28);
            this.textEditLastName.StyleController = this.layoutControlCustomerHeader;
            this.textEditLastName.TabIndex = 6;
            // 
            // textEdit2
            // 
            this.textEdit2.DataBindings.Add(new System.Windows.Forms.Binding("EditValue", this.CustomerbindingSource, "CUSTOMER_FIRST_NAME", true));
            this.textEdit2.Location = new System.Drawing.Point(295, 12);
            this.textEdit2.Name = "textEdit2";
            this.textEdit2.Properties.Appearance.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textEdit2.Properties.Appearance.Options.UseFont = true;
            this.textEdit2.Size = new System.Drawing.Size(281, 28);
            this.textEdit2.StyleController = this.layoutControlCustomerHeader;
            this.textEdit2.TabIndex = 5;
            // 
            // textEditCustomerID
            // 
            this.textEditCustomerID.DataBindings.Add(new System.Windows.Forms.Binding("EditValue", this.CustomerbindingSource, "CUSTOMER_NO", true));
            this.textEditCustomerID.Location = new System.Drawing.Point(116, 12);
            this.textEditCustomerID.Name = "textEditCustomerID";
            this.textEditCustomerID.Properties.Appearance.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textEditCustomerID.Properties.Appearance.Options.UseFont = true;
            this.textEditCustomerID.Size = new System.Drawing.Size(71, 28);
            this.textEditCustomerID.StyleController = this.layoutControlCustomerHeader;
            this.textEditCustomerID.TabIndex = 4;
            // 
            // Root
            // 
            this.Root.EnableIndentsWithoutBorders = DevExpress.Utils.DefaultBoolean.True;
            this.Root.GroupBordersVisible = false;
            this.Root.Items.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[] {
            this.layoutControlCustomerID,
            this.layoutFirstName,
            this.layoutLastName,
            this.layoutControlDealerName,
            this.layoutControlDealerID});
            this.Root.Name = "Root";
            this.Root.Size = new System.Drawing.Size(1020, 84);
            this.Root.TextVisible = false;
            // 
            // layoutControlCustomerID
            // 
            this.layoutControlCustomerID.AppearanceItemCaption.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.layoutControlCustomerID.AppearanceItemCaption.Options.UseFont = true;
            this.layoutControlCustomerID.Control = this.textEditCustomerID;
            this.layoutControlCustomerID.Location = new System.Drawing.Point(0, 0);
            this.layoutControlCustomerID.Name = "layoutControlCustomerID";
            this.layoutControlCustomerID.Size = new System.Drawing.Size(179, 32);
            this.layoutControlCustomerID.Text = "Customer ID";
            this.layoutControlCustomerID.TextSize = new System.Drawing.Size(100, 21);
            // 
            // layoutFirstName
            // 
            this.layoutFirstName.AppearanceItemCaption.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.layoutFirstName.AppearanceItemCaption.Options.UseFont = true;
            this.layoutFirstName.Control = this.textEdit2;
            this.layoutFirstName.Location = new System.Drawing.Point(179, 0);
            this.layoutFirstName.Name = "layoutFirstName";
            this.layoutFirstName.Size = new System.Drawing.Size(389, 32);
            this.layoutFirstName.Text = "First Name";
            this.layoutFirstName.TextSize = new System.Drawing.Size(100, 21);
            // 
            // layoutLastName
            // 
            this.layoutLastName.AppearanceItemCaption.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.layoutLastName.AppearanceItemCaption.Options.UseFont = true;
            this.layoutLastName.Control = this.textEditLastName;
            this.layoutLastName.Location = new System.Drawing.Point(568, 0);
            this.layoutLastName.Name = "layoutLastName";
            this.layoutLastName.Size = new System.Drawing.Size(432, 32);
            this.layoutLastName.Text = "Last Name";
            this.layoutLastName.TextSize = new System.Drawing.Size(100, 21);
            // 
            // layoutControlDealerName
            // 
            this.layoutControlDealerName.AppearanceItemCaption.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.layoutControlDealerName.AppearanceItemCaption.Options.UseFont = true;
            this.layoutControlDealerName.Control = this.textEditDealerName;
            this.layoutControlDealerName.Location = new System.Drawing.Point(179, 32);
            this.layoutControlDealerName.Name = "layoutControlDealerName";
            this.layoutControlDealerName.Size = new System.Drawing.Size(821, 32);
            this.layoutControlDealerName.Text = "Dealer Name";
            this.layoutControlDealerName.TextSize = new System.Drawing.Size(100, 21);
            // 
            // layoutControlDealerID
            // 
            this.layoutControlDealerID.AppearanceItemCaption.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.layoutControlDealerID.AppearanceItemCaption.Options.UseFont = true;
            this.layoutControlDealerID.Control = this.textEditDealerID;
            this.layoutControlDealerID.Location = new System.Drawing.Point(0, 32);
            this.layoutControlDealerID.Name = "layoutControlDealerID";
            this.layoutControlDealerID.Size = new System.Drawing.Size(179, 32);
            this.layoutControlDealerID.Text = "Dealer ID";
            this.layoutControlDealerID.TextSize = new System.Drawing.Size(100, 21);
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
            this.groupControl2.Controls.Add(this.layoutControl2);
            this.groupControl2.Controls.Add(this.cUSTHISTDataGridView);
            this.groupControl2.Location = new System.Drawing.Point(-4, 0);
            this.groupControl2.Name = "groupControl2";
            this.groupControl2.Size = new System.Drawing.Size(1014, 576);
            this.groupControl2.TabIndex = 100;
            this.groupControl2.Text = "groupControl2";
            // 
            // layoutControl2
            // 
            this.layoutControl2.AutoScroll = false;
            this.layoutControl2.Controls.Add(this.textEdit7);
            this.layoutControl2.Controls.Add(this.textEdit8);
            this.layoutControl2.Controls.Add(this.textEdit9);
            this.layoutControl2.Controls.Add(this.textEdit10);
            this.layoutControl2.Controls.Add(this.textEdit11);
            this.layoutControl2.Dock = System.Windows.Forms.DockStyle.Top;
            this.layoutControl2.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.layoutControl2.Location = new System.Drawing.Point(0, 0);
            this.layoutControl2.Name = "layoutControl2";
            this.layoutControl2.OptionsCustomizationForm.DesignTimeCustomizationFormPositionAndSize = new System.Drawing.Rectangle(1161, 0, 650, 400);
            this.layoutControl2.Root = this.layoutControlGroup3;
            this.layoutControl2.Size = new System.Drawing.Size(1014, 81);
            this.layoutControl2.TabIndex = 537;
            this.layoutControl2.Text = "layoutControl1";
            // 
            // textEdit7
            // 
            this.textEdit7.DataBindings.Add(new System.Windows.Forms.Binding("EditValue", this.DealerbindingSource, "OPNDEALR_NAME", true));
            this.textEdit7.Location = new System.Drawing.Point(294, 44);
            this.textEdit7.Name = "textEdit7";
            this.textEdit7.Properties.Appearance.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textEdit7.Properties.Appearance.Options.UseFont = true;
            this.textEdit7.Size = new System.Drawing.Size(708, 28);
            this.textEdit7.StyleController = this.layoutControl2;
            this.textEdit7.TabIndex = 8;
            // 
            // textEdit8
            // 
            this.textEdit8.DataBindings.Add(new System.Windows.Forms.Binding("EditValue", this.DealerbindingSource, "OPNDEALR_ACC_NO", true));
            this.textEdit8.Location = new System.Drawing.Point(116, 44);
            this.textEdit8.Name = "textEdit8";
            this.textEdit8.Properties.Appearance.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textEdit8.Properties.Appearance.Options.UseFont = true;
            this.textEdit8.Size = new System.Drawing.Size(70, 28);
            this.textEdit8.StyleController = this.layoutControl2;
            this.textEdit8.TabIndex = 7;
            // 
            // textEdit9
            // 
            this.textEdit9.DataBindings.Add(new System.Windows.Forms.Binding("EditValue", this.CustomerbindingSource, "CUSTOMER_LAST_NAME", true));
            this.textEdit9.Location = new System.Drawing.Point(681, 12);
            this.textEdit9.Name = "textEdit9";
            this.textEdit9.Properties.Appearance.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textEdit9.Properties.Appearance.Options.UseFont = true;
            this.textEdit9.Size = new System.Drawing.Size(321, 28);
            this.textEdit9.StyleController = this.layoutControl2;
            this.textEdit9.TabIndex = 6;
            // 
            // textEdit10
            // 
            this.textEdit10.DataBindings.Add(new System.Windows.Forms.Binding("EditValue", this.CustomerbindingSource, "CUSTOMER_FIRST_NAME", true));
            this.textEdit10.Location = new System.Drawing.Point(294, 12);
            this.textEdit10.Name = "textEdit10";
            this.textEdit10.Properties.Appearance.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textEdit10.Properties.Appearance.Options.UseFont = true;
            this.textEdit10.Size = new System.Drawing.Size(279, 28);
            this.textEdit10.StyleController = this.layoutControl2;
            this.textEdit10.TabIndex = 5;
            // 
            // textEdit11
            // 
            this.textEdit11.DataBindings.Add(new System.Windows.Forms.Binding("EditValue", this.CustomerbindingSource, "CustomerID", true));
            this.textEdit11.Location = new System.Drawing.Point(116, 12);
            this.textEdit11.Name = "textEdit11";
            this.textEdit11.Properties.Appearance.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textEdit11.Properties.Appearance.Options.UseFont = true;
            this.textEdit11.Size = new System.Drawing.Size(70, 28);
            this.textEdit11.StyleController = this.layoutControl2;
            this.textEdit11.TabIndex = 4;
            // 
            // layoutControlGroup3
            // 
            this.layoutControlGroup3.EnableIndentsWithoutBorders = DevExpress.Utils.DefaultBoolean.True;
            this.layoutControlGroup3.GroupBordersVisible = false;
            this.layoutControlGroup3.Items.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[] {
            this.layoutControlItem7,
            this.layoutControlItem8,
            this.layoutControlItem9,
            this.layoutControlItem10,
            this.layoutControlItem11});
            this.layoutControlGroup3.Name = "Root";
            this.layoutControlGroup3.Size = new System.Drawing.Size(1014, 84);
            this.layoutControlGroup3.TextVisible = false;
            // 
            // layoutControlItem7
            // 
            this.layoutControlItem7.AppearanceItemCaption.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.layoutControlItem7.AppearanceItemCaption.Options.UseFont = true;
            this.layoutControlItem7.Control = this.textEdit11;
            this.layoutControlItem7.Location = new System.Drawing.Point(0, 0);
            this.layoutControlItem7.Name = "layoutControlCustomerID";
            this.layoutControlItem7.Size = new System.Drawing.Size(178, 32);
            this.layoutControlItem7.Text = "Customer ID";
            this.layoutControlItem7.TextSize = new System.Drawing.Size(100, 21);
            // 
            // layoutControlItem8
            // 
            this.layoutControlItem8.AppearanceItemCaption.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.layoutControlItem8.AppearanceItemCaption.Options.UseFont = true;
            this.layoutControlItem8.Control = this.textEdit10;
            this.layoutControlItem8.Location = new System.Drawing.Point(178, 0);
            this.layoutControlItem8.Name = "layoutFirstName";
            this.layoutControlItem8.Size = new System.Drawing.Size(387, 32);
            this.layoutControlItem8.Text = "First Name";
            this.layoutControlItem8.TextSize = new System.Drawing.Size(100, 21);
            // 
            // layoutControlItem9
            // 
            this.layoutControlItem9.AppearanceItemCaption.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.layoutControlItem9.AppearanceItemCaption.Options.UseFont = true;
            this.layoutControlItem9.Control = this.textEdit9;
            this.layoutControlItem9.Location = new System.Drawing.Point(565, 0);
            this.layoutControlItem9.Name = "layoutLastName";
            this.layoutControlItem9.Size = new System.Drawing.Size(429, 32);
            this.layoutControlItem9.Text = "Last Name";
            this.layoutControlItem9.TextSize = new System.Drawing.Size(100, 21);
            // 
            // layoutControlItem10
            // 
            this.layoutControlItem10.AppearanceItemCaption.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.layoutControlItem10.AppearanceItemCaption.Options.UseFont = true;
            this.layoutControlItem10.Control = this.textEdit7;
            this.layoutControlItem10.Location = new System.Drawing.Point(178, 32);
            this.layoutControlItem10.Name = "layoutControlDealerName";
            this.layoutControlItem10.Size = new System.Drawing.Size(816, 32);
            this.layoutControlItem10.Text = "Dealer Name";
            this.layoutControlItem10.TextSize = new System.Drawing.Size(100, 21);
            // 
            // layoutControlItem11
            // 
            this.layoutControlItem11.AppearanceItemCaption.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.layoutControlItem11.AppearanceItemCaption.Options.UseFont = true;
            this.layoutControlItem11.Control = this.textEdit8;
            this.layoutControlItem11.Location = new System.Drawing.Point(0, 32);
            this.layoutControlItem11.Name = "layoutControlDealerID";
            this.layoutControlItem11.Size = new System.Drawing.Size(178, 32);
            this.layoutControlItem11.Text = "Dealer ID";
            this.layoutControlItem11.TextSize = new System.Drawing.Size(100, 21);
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
            this.cUSTHISTBindingSource.DataMember = "OPNHCUST";
            this.cUSTHISTBindingSource.DataSource = this.OpenPaymentiacDataSet;
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
            // cOMMENTBindingSource
            // 
            this.cOMMENTBindingSource.DataMember = "OPNCOMM";
            this.cOMMENTBindingSource.DataSource = this.OpenPaymentiacDataSet;
            // 
            // commentTypesBindingSource
            // 
            this.commentTypesBindingSource.DataMember = "Comment_Types";
            this.commentTypesBindingSource.DataSource = this.OpenPaymentiacDataSet;
            // 
            // specialCommentCodesBindingSource
            // 
            this.specialCommentCodesBindingSource.DataMember = "SpecialCommentCodes";
            this.specialCommentCodesBindingSource.DataSource = this.OpenPaymentiacDataSet;
            // 
            // comment_TypesTableAdapter
            // 
            this.comment_TypesTableAdapter.ClearBeforeFill = true;
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
            // miniToolStrip
            // 
            this.miniToolStrip.AccessibleName = "New item selection";
            this.miniToolStrip.AccessibleRole = System.Windows.Forms.AccessibleRole.ButtonDropDown;
            this.miniToolStrip.AutoSize = false;
            this.miniToolStrip.CanOverflow = false;
            this.miniToolStrip.Dock = System.Windows.Forms.DockStyle.None;
            this.miniToolStrip.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
            this.miniToolStrip.Location = new System.Drawing.Point(324, 3);
            this.miniToolStrip.Name = "miniToolStrip";
            this.miniToolStrip.Size = new System.Drawing.Size(1017, 25);
            this.miniToolStrip.TabIndex = 160;
            // 
            // toolStripButton8
            // 
            this.toolStripButton8.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripButton8.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButton8.Image")));
            this.toolStripButton8.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton8.Name = "toolStripButton8";
            this.toolStripButton8.Size = new System.Drawing.Size(23, 22);
            this.toolStripButton8.Text = "Search";
            // 
            // toolStripButton9
            // 
            this.toolStripButton9.BackColor = System.Drawing.Color.White;
            this.toolStripButton9.Enabled = false;
            this.toolStripButton9.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButton9.Image")));
            this.toolStripButton9.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton9.Name = "toolStripButton9";
            this.toolStripButton9.Size = new System.Drawing.Size(49, 22);
            this.toolStripButton9.Text = "&Add";
            // 
            // toolStripButton10
            // 
            this.toolStripButton10.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.toolStripButton10.Enabled = false;
            this.toolStripButton10.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButton10.Image")));
            this.toolStripButton10.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton10.Name = "toolStripButton10";
            this.toolStripButton10.Size = new System.Drawing.Size(47, 22);
            this.toolStripButton10.Text = "&Edit";
            // 
            // toolStripButton11
            // 
            this.toolStripButton11.BackColor = System.Drawing.Color.MistyRose;
            this.toolStripButton11.Enabled = false;
            this.toolStripButton11.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButton11.Image")));
            this.toolStripButton11.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton11.Name = "toolStripButton11";
            this.toolStripButton11.Size = new System.Drawing.Size(60, 22);
            this.toolStripButton11.Text = "&Delete";
            // 
            // toolStripButton12
            // 
            this.toolStripButton12.BackColor = System.Drawing.Color.LightYellow;
            this.toolStripButton12.Enabled = false;
            this.toolStripButton12.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButton12.Image")));
            this.toolStripButton12.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton12.Name = "toolStripButton12";
            this.toolStripButton12.Size = new System.Drawing.Size(51, 22);
            this.toolStripButton12.Text = "&Save";
            // 
            // toolStripButton13
            // 
            this.toolStripButton13.BackColor = System.Drawing.Color.LightYellow;
            this.toolStripButton13.Enabled = false;
            this.toolStripButton13.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButton13.Image")));
            this.toolStripButton13.ImageTransparentColor = System.Drawing.Color.Crimson;
            this.toolStripButton13.Name = "toolStripButton13";
            this.toolStripButton13.Size = new System.Drawing.Size(85, 22);
            this.toolStripButton13.Text = "&CancelAdd";
            // 
            // toolStrip2
            // 
            this.toolStrip2.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.toolStrip2.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripButton8,
            this.toolStripButton9,
            this.toolStripButton10,
            this.toolStripButton11,
            this.toolStripButton12,
            this.toolStripButton13});
            this.toolStrip2.Location = new System.Drawing.Point(0, 547);
            this.toolStrip2.Name = "toolStrip2";
            this.toolStrip2.Size = new System.Drawing.Size(1017, 25);
            this.toolStrip2.TabIndex = 160;
            this.toolStrip2.Text = "toolStrip2";
            // 
            // htmlTemplateCollection1
            // 
            this.htmlTemplateCollection1.AddRange(new DevExpress.Utils.Html.HtmlTemplate[] {
            this.htmlTemplate1});
            // 
            // htmlTemplate1
            // 
            this.htmlTemplate1.Name = "htmlTemplate1";
            this.htmlTemplate1.Styles = resources.GetString("htmlTemplate1.Styles");
            this.htmlTemplate1.Template = resources.GetString("htmlTemplate1.Template");
            // 
            // svgImageCollection1
            // 
            this.svgImageCollection1.Add("close", "image://svgimages/outlook inspired/close.svg");
            // 
            // oPNCUSTTableAdapter
            // 
            this.oPNCUSTTableAdapter.ClearBeforeFill = true;
            // 
            // oPNDEALRTableAdapter
            // 
            this.oPNDEALRTableAdapter.ClearBeforeFill = true;
            // 
            // oPNHCUSTTableAdapter
            // 
            this.oPNHCUSTTableAdapter.ClearBeforeFill = true;
            // 
            // oPNCOMMTableAdapter
            // 
            this.oPNCOMMTableAdapter.ClearBeforeFill = true;
            // 
            // opnpayTableAdapter
            // 
            this.opnpayTableAdapter.ClearBeforeFill = true;
            // 
            // XtraFormOpenPayments
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
            this.Name = "XtraFormOpenPayments";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = " Open Payments";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.XtraFormOpenPayments_FormClosing);
            this.Load += new System.EventHandler(this.XtraFormOpenPayments_Load);
            ((System.ComponentModel.ISupportInitialize)(this.CustomerbindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.OpenPaymentiacDataSet)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.PaymentTypebindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.DealerbindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.PAYCODEbindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tabClosedPayments)).EndInit();
            this.tabClosedPayments.ResumeLayout(false);
            this.tabPayment.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.groupControl5)).EndInit();
            this.groupControl5.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGridAndButtons)).EndInit();
            this.layoutControlGridAndButtons.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gridControlPayments)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.PaymentbindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemCheckEdit1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroup1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlPaymentGrid)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlCustomerHeader)).EndInit();
            this.layoutControlCustomerHeader.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.textEditDealerName.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.textEditDealerID.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.textEditLastName.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.textEdit2.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.textEditCustomerID.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Root)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlCustomerID)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutFirstName)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutLastName)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlDealerName)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlDealerID)).EndInit();
            this.tabHistory.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.groupControl2)).EndInit();
            this.groupControl2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.layoutControl2)).EndInit();
            this.layoutControl2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.textEdit7.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.textEdit8.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.textEdit9.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.textEdit10.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.textEdit11.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroup3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem7)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem8)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem9)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem10)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem11)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cUSTHISTDataGridView)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cUSTHISTBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridViewCustomerHistory)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cOMMENTBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.commentTypesBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.specialCommentCodesBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.groupControlTabPayments)).EndInit();
            this.toolStrip2.ResumeLayout(false);
            this.toolStrip2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.svgImageCollection1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.BindingSource CustomerbindingSource;
        private System.Windows.Forms.BindingSource PaymentTypebindingSource;
        private IACDataSetTableAdapters.PAYMENTTYPETableAdapter pAYMENTTYPETableAdapter;
        private System.Windows.Forms.BindingSource DealerbindingSource;
        private System.Windows.Forms.BindingSource PAYCODEbindingSource;
        private IACDataSetTableAdapters.PAYCODETableAdapter pAYCODETableAdapter;
        private DevExpress.XtraTab.XtraTabControl tabClosedPayments;
        private DevExpress.XtraTab.XtraTabPage tabHistory;
        private System.Windows.Forms.BindingSource cOMMENTBindingSource;
        private System.Windows.Forms.BindingSource commentTypesBindingSource;
        private IACDataSetTableAdapters.Comment_TypesTableAdapter comment_TypesTableAdapter;
        private System.Windows.Forms.BindingSource PaymentbindingSource;
        public System.Windows.Forms.BindingSource cUSTHISTBindingSource;
        private System.Windows.Forms.BindingSource specialCommentCodesBindingSource;
        private IACDataSetTableAdapters.SpecialCommentCodesTableAdapter specialCommentCodesTableAdapter;
        private DevExpress.XtraEditors.GroupControl groupControlTabPayments;
        private DevExpress.XtraEditors.GroupControl groupControl2;
        public IACDataSet OpenPaymentiacDataSet;
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
        private DevExpress.DataAccess.Sql.SqlDataSource sqlDataSourceClosedPayments;
        private System.Windows.Forms.ToolStrip miniToolStrip;
        private System.Windows.Forms.ToolStripButton toolStripButton8;
        private System.Windows.Forms.ToolStripButton toolStripButton9;
        private System.Windows.Forms.ToolStripButton toolStripButton10;
        private System.Windows.Forms.ToolStripButton toolStripButton11;
        private System.Windows.Forms.ToolStripButton toolStripButton12;
        private System.Windows.Forms.ToolStripButton toolStripButton13;
        private System.Windows.Forms.ToolStrip toolStrip2;
        private DevExpress.XtraTab.XtraTabPage tabPayment;
        private DevExpress.XtraLayout.LayoutControl layoutControlCustomerHeader;
        private DevExpress.XtraLayout.LayoutControlGroup Root;
        private DevExpress.XtraEditors.TextEdit textEditLastName;
        private DevExpress.XtraEditors.TextEdit textEdit2;
        private DevExpress.XtraEditors.TextEdit textEditCustomerID;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlCustomerID;
        private DevExpress.XtraLayout.LayoutControlItem layoutFirstName;
        private DevExpress.XtraLayout.LayoutControlItem layoutLastName;
        private DevExpress.XtraEditors.TextEdit textEditDealerName;
        private DevExpress.XtraEditors.TextEdit textEditDealerID;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlDealerID;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlDealerName;
        private DevExpress.XtraEditors.GroupControl groupControl5;
        private DevExpress.XtraBars.Docking2010.WindowsUIButtonPanel windowsUIButtonPanel1;
        private DevExpress.XtraLayout.LayoutControl layoutControlGridAndButtons;
        private DevExpress.XtraLayout.LayoutControlGroup layoutControlGroup1;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem2;
        private DevExpress.XtraGrid.GridControl gridControlPayments;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView2;
        private DevExpress.XtraGrid.Columns.GridColumn colPAYMENT_CUSTOMER;
        private DevExpress.XtraGrid.Columns.GridColumn colPAYMENT_DATE;
        private DevExpress.XtraGrid.Columns.GridColumn colPAYMENT_AMOUNT_RCV;
        private DevExpress.XtraGrid.Columns.GridColumn colPAYMENT_TYPE;
        private DevExpress.XtraGrid.Columns.GridColumn colPAYMENT_CODE_2;
        private DevExpress.XtraGrid.Columns.GridColumn colPAYMENT_AUTO_PAY;
        private DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit repositoryItemCheckEdit1;
        private DevExpress.XtraGrid.Columns.GridColumn colPAYMENT_ISF_DATE;
        private DevExpress.Utils.Html.HtmlTemplateCollection htmlTemplateCollection1;
        private DevExpress.Utils.Html.HtmlTemplate htmlTemplate1;
        private DevExpress.Utils.SvgImageCollection svgImageCollection1;
        private DevExpress.XtraGrid.Columns.GridColumn colPAYMENT_THRU_UD;
        private DevExpress.XtraLayout.LayoutControl layoutControl2;
        private DevExpress.XtraEditors.TextEdit textEdit7;
        private DevExpress.XtraEditors.TextEdit textEdit8;
        private DevExpress.XtraEditors.TextEdit textEdit9;
        private DevExpress.XtraEditors.TextEdit textEdit10;
        private DevExpress.XtraEditors.TextEdit textEdit11;
        private DevExpress.XtraLayout.LayoutControlGroup layoutControlGroup3;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem7;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem8;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem9;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem10;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem11;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlPaymentGrid;
        private IACDataSetTableAdapters.OPNCUSTTableAdapter oPNCUSTTableAdapter;
        private IACDataSetTableAdapters.OPNDEALRTableAdapter oPNDEALRTableAdapter;
        private IACDataSetTableAdapters.OPNHCUSTTableAdapter oPNHCUSTTableAdapter;
        private IACDataSetTableAdapters.OPNCOMMTableAdapter oPNCOMMTableAdapter;
        private IACDataSetTableAdapters.OPNPAYTableAdapter opnpayTableAdapter;
    }
}
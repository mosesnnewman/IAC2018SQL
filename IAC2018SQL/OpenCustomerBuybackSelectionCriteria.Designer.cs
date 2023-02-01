namespace IAC2021SQL
{
    partial class frmOpenCustomerBuybackReport
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
            this.labelStartDate = new System.Windows.Forms.Label();
            this.iACDataSet = new IAC2021SQL.IACDataSet();
            this.labelEndDate = new System.Windows.Forms.Label();
            this.bindingSourceDLRLISTBYNUM = new System.Windows.Forms.BindingSource(this.components);
            this.labelDealerNum = new System.Windows.Forms.Label();
            this.dlrlistbynumTableAdapter = new IAC2021SQL.IACDataSetTableAdapters.OPNDLRLISTBYNUMTableAdapter();
            this.PaymentCodebindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.PaymentTypebindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.pAYMENTTYPETableAdapter = new IAC2021SQL.IACDataSetTableAdapters.PAYMENTTYPETableAdapter();
            this.pAYCODETableAdapter = new IAC2021SQL.IACDataSetTableAdapters.PAYCODETableAdapter();
            this.openCustomerBuybackTableAdapter = new IAC2021SQL.IACDataSetTableAdapters.OpenCustomerBuybackTableAdapter();
            this.labelDealerState = new System.Windows.Forms.Label();
            this.labelCustomerState = new System.Windows.Forms.Label();
            this.nullableDateTimePickerStartDate = new DevExpress.XtraEditors.DateEdit();
            this.nullableDateTimePickerEndDate = new DevExpress.XtraEditors.DateEdit();
            this.buttonCancel = new DevExpress.XtraEditors.SimpleButton();
            this.buttonPost = new DevExpress.XtraEditors.SimpleButton();
            this.lookUpEditDealer = new DevExpress.XtraEditors.LookUpEdit();
            this.lookUpEditDealerState = new DevExpress.XtraEditors.LookUpEdit();
            this.DealerStateBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.CustomerStateBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.stateTableAdapter1 = new IAC2021SQL.IACDataSetTableAdapters.stateTableAdapter();
            this.lookUpEditCustomerState = new DevExpress.XtraEditors.LookUpEdit();
            this.lookUpEditPaymentType = new DevExpress.XtraEditors.LookUpEdit();
            this.lookUpEditCodeType = new DevExpress.XtraEditors.LookUpEdit();
            this.groupControl1 = new DevExpress.XtraEditors.GroupControl();
            ((System.ComponentModel.ISupportInitialize)(this.iACDataSet)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bindingSourceDLRLISTBYNUM)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.PaymentCodebindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.PaymentTypebindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nullableDateTimePickerStartDate.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nullableDateTimePickerStartDate.Properties.CalendarTimeProperties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nullableDateTimePickerEndDate.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nullableDateTimePickerEndDate.Properties.CalendarTimeProperties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lookUpEditDealer.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lookUpEditDealerState.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.DealerStateBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.CustomerStateBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lookUpEditCustomerState.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lookUpEditPaymentType.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lookUpEditCodeType.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl1)).BeginInit();
            this.groupControl1.SuspendLayout();
            this.SuspendLayout();
            // 
            // labelStartDate
            // 
            this.labelStartDate.AutoSize = true;
            this.labelStartDate.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelStartDate.Location = new System.Drawing.Point(159, 39);
            this.labelStartDate.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.labelStartDate.Name = "labelStartDate";
            this.labelStartDate.Size = new System.Drawing.Size(87, 20);
            this.labelStartDate.TabIndex = 5;
            this.labelStartDate.Text = "Start Date:";
            this.labelStartDate.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // iACDataSet
            // 
            this.iACDataSet.DataSetName = "IACDataSet";
            this.iACDataSet.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // labelEndDate
            // 
            this.labelEndDate.AutoSize = true;
            this.labelEndDate.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelEndDate.Location = new System.Drawing.Point(164, 75);
            this.labelEndDate.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.labelEndDate.Name = "labelEndDate";
            this.labelEndDate.Size = new System.Drawing.Size(81, 20);
            this.labelEndDate.TabIndex = 8;
            this.labelEndDate.Text = "End Date:";
            this.labelEndDate.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // bindingSourceDLRLISTBYNUM
            // 
            this.bindingSourceDLRLISTBYNUM.DataMember = "OPNDLRLISTBYNUM";
            this.bindingSourceDLRLISTBYNUM.DataSource = this.iACDataSet;
            // 
            // labelDealerNum
            // 
            this.labelDealerNum.AutoSize = true;
            this.labelDealerNum.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelDealerNum.Location = new System.Drawing.Point(184, 111);
            this.labelDealerNum.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.labelDealerNum.Name = "labelDealerNum";
            this.labelDealerNum.Size = new System.Drawing.Size(60, 20);
            this.labelDealerNum.TabIndex = 13;
            this.labelDealerNum.Text = "Dealer:";
            this.labelDealerNum.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // dlrlistbynumTableAdapter
            // 
            this.dlrlistbynumTableAdapter.ClearBeforeFill = true;
            // 
            // PaymentCodebindingSource
            // 
            this.PaymentCodebindingSource.DataMember = "PAYCODE";
            this.PaymentCodebindingSource.DataSource = this.iACDataSet;
            // 
            // PaymentTypebindingSource
            // 
            this.PaymentTypebindingSource.DataMember = "PAYMENTTYPE";
            this.PaymentTypebindingSource.DataSource = this.iACDataSet;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(129, 219);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(113, 20);
            this.label1.TabIndex = 21;
            this.label1.Text = "Payment Type:";
            this.label1.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(128, 255);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(117, 20);
            this.label2.TabIndex = 22;
            this.label2.Text = "Payment Code:";
            this.label2.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // pAYMENTTYPETableAdapter
            // 
            this.pAYMENTTYPETableAdapter.ClearBeforeFill = true;
            // 
            // pAYCODETableAdapter
            // 
            this.pAYCODETableAdapter.ClearBeforeFill = true;
            // 
            // openCustomerBuybackTableAdapter
            // 
            this.openCustomerBuybackTableAdapter.ClearBeforeFill = true;
            // 
            // labelDealerState
            // 
            this.labelDealerState.AutoSize = true;
            this.labelDealerState.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelDealerState.Location = new System.Drawing.Point(137, 147);
            this.labelDealerState.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.labelDealerState.Name = "labelDealerState";
            this.labelDealerState.Size = new System.Drawing.Size(107, 20);
            this.labelDealerState.TabIndex = 24;
            this.labelDealerState.Text = "Dealer State :";
            this.labelDealerState.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // labelCustomerState
            // 
            this.labelCustomerState.AutoSize = true;
            this.labelCustomerState.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelCustomerState.Location = new System.Drawing.Point(115, 183);
            this.labelCustomerState.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.labelCustomerState.Name = "labelCustomerState";
            this.labelCustomerState.Size = new System.Drawing.Size(129, 20);
            this.labelCustomerState.TabIndex = 26;
            this.labelCustomerState.Text = "Customer State :";
            this.labelCustomerState.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // nullableDateTimePickerStartDate
            // 
            this.nullableDateTimePickerStartDate.EditValue = new System.DateTime(2013, 6, 12, 0, 0, 0, 0);
            this.nullableDateTimePickerStartDate.Location = new System.Drawing.Point(264, 33);
            this.nullableDateTimePickerStartDate.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.nullableDateTimePickerStartDate.Name = "nullableDateTimePickerStartDate";
            this.nullableDateTimePickerStartDate.Properties.Appearance.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.nullableDateTimePickerStartDate.Properties.Appearance.Options.UseFont = true;
            this.nullableDateTimePickerStartDate.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.nullableDateTimePickerStartDate.Properties.CalendarTimeProperties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.nullableDateTimePickerStartDate.Properties.CalendarView = DevExpress.XtraEditors.Repository.CalendarView.Fluent;
            this.nullableDateTimePickerStartDate.Properties.LookAndFeel.SkinName = "McSkin";
            this.nullableDateTimePickerStartDate.Properties.LookAndFeel.UseDefaultLookAndFeel = false;
            this.nullableDateTimePickerStartDate.Properties.VistaDisplayMode = DevExpress.Utils.DefaultBoolean.False;
            this.nullableDateTimePickerStartDate.Size = new System.Drawing.Size(126, 26);
            this.nullableDateTimePickerStartDate.TabIndex = 9;
            // 
            // nullableDateTimePickerEndDate
            // 
            this.nullableDateTimePickerEndDate.EditValue = new System.DateTime(2013, 6, 12, 0, 0, 0, 0);
            this.nullableDateTimePickerEndDate.Location = new System.Drawing.Point(264, 69);
            this.nullableDateTimePickerEndDate.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.nullableDateTimePickerEndDate.Name = "nullableDateTimePickerEndDate";
            this.nullableDateTimePickerEndDate.Properties.Appearance.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.nullableDateTimePickerEndDate.Properties.Appearance.Options.UseFont = true;
            this.nullableDateTimePickerEndDate.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.nullableDateTimePickerEndDate.Properties.CalendarTimeProperties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.nullableDateTimePickerEndDate.Properties.CalendarView = DevExpress.XtraEditors.Repository.CalendarView.Fluent;
            this.nullableDateTimePickerEndDate.Properties.LookAndFeel.SkinName = "McSkin";
            this.nullableDateTimePickerEndDate.Properties.LookAndFeel.UseDefaultLookAndFeel = false;
            this.nullableDateTimePickerEndDate.Properties.VistaDisplayMode = DevExpress.Utils.DefaultBoolean.False;
            this.nullableDateTimePickerEndDate.Size = new System.Drawing.Size(126, 26);
            this.nullableDateTimePickerEndDate.TabIndex = 10;
            // 
            // buttonCancel
            // 
            this.buttonCancel.Location = new System.Drawing.Point(318, 308);
            this.buttonCancel.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.buttonCancel.Name = "buttonCancel";
            this.buttonCancel.Size = new System.Drawing.Size(112, 35);
            this.buttonCancel.TabIndex = 29;
            this.buttonCancel.Text = "&Cancel";
            this.buttonCancel.Click += new System.EventHandler(this.buttonCancel_Click);
            // 
            // buttonPost
            // 
            this.buttonPost.Location = new System.Drawing.Point(197, 308);
            this.buttonPost.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.buttonPost.Name = "buttonPost";
            this.buttonPost.Size = new System.Drawing.Size(112, 35);
            this.buttonPost.TabIndex = 28;
            this.buttonPost.Text = "&Print";
            this.buttonPost.Click += new System.EventHandler(this.buttonPost_Click);
            // 
            // lookUpEditDealer
            // 
            this.lookUpEditDealer.Location = new System.Drawing.Point(264, 105);
            this.lookUpEditDealer.Name = "lookUpEditDealer";
            this.lookUpEditDealer.Properties.Appearance.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lookUpEditDealer.Properties.Appearance.Options.UseFont = true;
            this.lookUpEditDealer.Properties.BestFitMode = DevExpress.XtraEditors.Controls.BestFitMode.BestFitResizePopup;
            this.lookUpEditDealer.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.lookUpEditDealer.Properties.Columns.AddRange(new DevExpress.XtraEditors.Controls.LookUpColumnInfo[] {
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("OPNDEALR_ACC_NO", "id", 100, DevExpress.Utils.FormatType.None, "", true, DevExpress.Utils.HorzAlignment.Near, DevExpress.Data.ColumnSortOrder.None, DevExpress.Utils.DefaultBoolean.Default),
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("OPNDEALR_NAME", "DEALER_NAME", 800, DevExpress.Utils.FormatType.None, "", true, DevExpress.Utils.HorzAlignment.Near, DevExpress.Data.ColumnSortOrder.None, DevExpress.Utils.DefaultBoolean.Default)});
            this.lookUpEditDealer.Properties.DataSource = this.bindingSourceDLRLISTBYNUM;
            this.lookUpEditDealer.Properties.DisplayMember = "OPNDEALR_ACC_NO";
            this.lookUpEditDealer.Properties.LookAndFeel.SkinName = "McSkin";
            this.lookUpEditDealer.Properties.LookAndFeel.UseDefaultLookAndFeel = false;
            this.lookUpEditDealer.Properties.NullText = "";
            this.lookUpEditDealer.Properties.ValueMember = "OPNDEALR_ACC_NO";
            this.lookUpEditDealer.Size = new System.Drawing.Size(86, 26);
            this.lookUpEditDealer.TabIndex = 14;
            // 
            // lookUpEditDealerState
            // 
            this.lookUpEditDealerState.Location = new System.Drawing.Point(264, 141);
            this.lookUpEditDealerState.Name = "lookUpEditDealerState";
            this.lookUpEditDealerState.Properties.Appearance.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lookUpEditDealerState.Properties.Appearance.Options.UseFont = true;
            this.lookUpEditDealerState.Properties.BestFitMode = DevExpress.XtraEditors.Controls.BestFitMode.BestFitResizePopup;
            this.lookUpEditDealerState.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.lookUpEditDealerState.Properties.Columns.AddRange(new DevExpress.XtraEditors.Controls.LookUpColumnInfo[] {
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("name", "name", 37, DevExpress.Utils.FormatType.None, "", true, DevExpress.Utils.HorzAlignment.Near, DevExpress.Data.ColumnSortOrder.None, DevExpress.Utils.DefaultBoolean.Default),
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("abbreviation", "abbreviation", 74, DevExpress.Utils.FormatType.None, "", true, DevExpress.Utils.HorzAlignment.Near, DevExpress.Data.ColumnSortOrder.None, DevExpress.Utils.DefaultBoolean.Default)});
            this.lookUpEditDealerState.Properties.DataSource = this.DealerStateBindingSource;
            this.lookUpEditDealerState.Properties.DisplayMember = "name";
            this.lookUpEditDealerState.Properties.NullText = "";
            this.lookUpEditDealerState.Properties.ValueMember = "abbreviation";
            this.lookUpEditDealerState.Size = new System.Drawing.Size(247, 26);
            this.lookUpEditDealerState.TabIndex = 15;
            // 
            // DealerStateBindingSource
            // 
            this.DealerStateBindingSource.DataMember = "state";
            this.DealerStateBindingSource.DataSource = this.iACDataSet;
            // 
            // CustomerStateBindingSource
            // 
            this.CustomerStateBindingSource.DataMember = "state";
            this.CustomerStateBindingSource.DataSource = this.iACDataSet;
            // 
            // stateTableAdapter1
            // 
            this.stateTableAdapter1.ClearBeforeFill = true;
            // 
            // lookUpEditCustomerState
            // 
            this.lookUpEditCustomerState.Location = new System.Drawing.Point(264, 177);
            this.lookUpEditCustomerState.Name = "lookUpEditCustomerState";
            this.lookUpEditCustomerState.Properties.Appearance.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lookUpEditCustomerState.Properties.Appearance.Options.UseFont = true;
            this.lookUpEditCustomerState.Properties.BestFitMode = DevExpress.XtraEditors.Controls.BestFitMode.BestFitResizePopup;
            this.lookUpEditCustomerState.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.lookUpEditCustomerState.Properties.Columns.AddRange(new DevExpress.XtraEditors.Controls.LookUpColumnInfo[] {
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("name", "name", 37, DevExpress.Utils.FormatType.None, "", true, DevExpress.Utils.HorzAlignment.Near, DevExpress.Data.ColumnSortOrder.None, DevExpress.Utils.DefaultBoolean.Default),
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("abbreviation", "abbreviation", 74, DevExpress.Utils.FormatType.None, "", true, DevExpress.Utils.HorzAlignment.Near, DevExpress.Data.ColumnSortOrder.None, DevExpress.Utils.DefaultBoolean.Default)});
            this.lookUpEditCustomerState.Properties.DataSource = this.CustomerStateBindingSource;
            this.lookUpEditCustomerState.Properties.DisplayMember = "name";
            this.lookUpEditCustomerState.Properties.NullText = "";
            this.lookUpEditCustomerState.Properties.ValueMember = "abbreviation";
            this.lookUpEditCustomerState.Size = new System.Drawing.Size(247, 26);
            this.lookUpEditCustomerState.TabIndex = 16;
            // 
            // lookUpEditPaymentType
            // 
            this.lookUpEditPaymentType.Location = new System.Drawing.Point(264, 213);
            this.lookUpEditPaymentType.Name = "lookUpEditPaymentType";
            this.lookUpEditPaymentType.Properties.Appearance.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lookUpEditPaymentType.Properties.Appearance.Options.UseFont = true;
            this.lookUpEditPaymentType.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.lookUpEditPaymentType.Properties.Columns.AddRange(new DevExpress.XtraEditors.Controls.LookUpColumnInfo[] {
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("TYPE", "TYPE", 31, DevExpress.Utils.FormatType.None, "", true, DevExpress.Utils.HorzAlignment.Near, DevExpress.Data.ColumnSortOrder.Ascending, DevExpress.Utils.DefaultBoolean.Default),
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("DESCRIPTION", "DESCRIPTION", 77, DevExpress.Utils.FormatType.None, "", true, DevExpress.Utils.HorzAlignment.Near, DevExpress.Data.ColumnSortOrder.None, DevExpress.Utils.DefaultBoolean.Default)});
            this.lookUpEditPaymentType.Properties.DataSource = this.PaymentTypebindingSource;
            this.lookUpEditPaymentType.Properties.DisplayMember = "TYPE";
            this.lookUpEditPaymentType.Properties.NullText = "";
            this.lookUpEditPaymentType.Properties.ValueMember = "TYPE";
            this.lookUpEditPaymentType.Size = new System.Drawing.Size(60, 26);
            this.lookUpEditPaymentType.TabIndex = 30;
            this.lookUpEditPaymentType.EditValueChanged += new System.EventHandler(this.lookUpEditPaymentType_EditValueChanged);
            // 
            // lookUpEditCodeType
            // 
            this.lookUpEditCodeType.Location = new System.Drawing.Point(264, 249);
            this.lookUpEditCodeType.Name = "lookUpEditCodeType";
            this.lookUpEditCodeType.Properties.Appearance.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lookUpEditCodeType.Properties.Appearance.Options.UseFont = true;
            this.lookUpEditCodeType.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.lookUpEditCodeType.Properties.Columns.AddRange(new DevExpress.XtraEditors.Controls.LookUpColumnInfo[] {
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("CODE", "CODE", 39, DevExpress.Utils.FormatType.None, "", true, DevExpress.Utils.HorzAlignment.Near, DevExpress.Data.ColumnSortOrder.Ascending, DevExpress.Utils.DefaultBoolean.Default),
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("DESCRIPTION", "DESCRIPTION", 77, DevExpress.Utils.FormatType.None, "", true, DevExpress.Utils.HorzAlignment.Near, DevExpress.Data.ColumnSortOrder.None, DevExpress.Utils.DefaultBoolean.Default)});
            this.lookUpEditCodeType.Properties.DataSource = this.PaymentCodebindingSource;
            this.lookUpEditCodeType.Properties.DisplayMember = "CODE";
            this.lookUpEditCodeType.Properties.NullText = "";
            this.lookUpEditCodeType.Properties.ValueMember = "CODE";
            this.lookUpEditCodeType.Size = new System.Drawing.Size(60, 26);
            this.lookUpEditCodeType.TabIndex = 31;
            // 
            // groupControl1
            // 
            this.groupControl1.Appearance.BackColor = System.Drawing.Color.LightSteelBlue;
            this.groupControl1.Appearance.Options.UseBackColor = true;
            this.groupControl1.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            this.groupControl1.Controls.Add(this.lookUpEditCodeType);
            this.groupControl1.Controls.Add(this.lookUpEditPaymentType);
            this.groupControl1.Controls.Add(this.lookUpEditCustomerState);
            this.groupControl1.Controls.Add(this.lookUpEditDealerState);
            this.groupControl1.Controls.Add(this.lookUpEditDealer);
            this.groupControl1.Controls.Add(this.buttonCancel);
            this.groupControl1.Controls.Add(this.buttonPost);
            this.groupControl1.Controls.Add(this.nullableDateTimePickerEndDate);
            this.groupControl1.Controls.Add(this.nullableDateTimePickerStartDate);
            this.groupControl1.Controls.Add(this.labelCustomerState);
            this.groupControl1.Controls.Add(this.labelDealerState);
            this.groupControl1.Controls.Add(this.label2);
            this.groupControl1.Controls.Add(this.label1);
            this.groupControl1.Controls.Add(this.labelDealerNum);
            this.groupControl1.Controls.Add(this.labelEndDate);
            this.groupControl1.Controls.Add(this.labelStartDate);
            this.groupControl1.Location = new System.Drawing.Point(2, -3);
            this.groupControl1.Name = "groupControl1";
            this.groupControl1.Size = new System.Drawing.Size(626, 376);
            this.groupControl1.TabIndex = 32;
            this.groupControl1.Text = "groupControl1";
            // 
            // frmOpenCustomerBuybackReport
            // 
            this.Appearance.Options.UseFont = true;
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.ClientSize = new System.Drawing.Size(627, 372);
            this.Controls.Add(this.groupControl1);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.Name = "frmOpenCustomerBuybackReport";
            this.Text = "Print Open Customer Buyback Report (BUYBACK)";
            this.Load += new System.EventHandler(this.frmOpenCustomerBuybackReport_Load);
            ((System.ComponentModel.ISupportInitialize)(this.iACDataSet)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bindingSourceDLRLISTBYNUM)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.PaymentCodebindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.PaymentTypebindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nullableDateTimePickerStartDate.Properties.CalendarTimeProperties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nullableDateTimePickerStartDate.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nullableDateTimePickerEndDate.Properties.CalendarTimeProperties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nullableDateTimePickerEndDate.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lookUpEditDealer.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lookUpEditDealerState.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.DealerStateBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.CustomerStateBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lookUpEditCustomerState.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lookUpEditPaymentType.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lookUpEditCodeType.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl1)).EndInit();
            this.groupControl1.ResumeLayout(false);
            this.groupControl1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Label labelStartDate;
        private IACDataSet iACDataSet;
        private System.Windows.Forms.Label labelEndDate;
        private System.Windows.Forms.Label labelDealerNum;
        private System.Windows.Forms.BindingSource bindingSourceDLRLISTBYNUM;
        private IACDataSetTableAdapters.OPNDLRLISTBYNUMTableAdapter dlrlistbynumTableAdapter;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.BindingSource PaymentTypebindingSource;
        private IACDataSetTableAdapters.PAYMENTTYPETableAdapter pAYMENTTYPETableAdapter;
        private System.Windows.Forms.BindingSource PaymentCodebindingSource;
        private IACDataSetTableAdapters.PAYCODETableAdapter pAYCODETableAdapter;
        private IACDataSetTableAdapters.OpenCustomerBuybackTableAdapter openCustomerBuybackTableAdapter;
        private System.Windows.Forms.Label labelDealerState;
        private System.Windows.Forms.Label labelCustomerState;
        private DevExpress.XtraEditors.DateEdit nullableDateTimePickerStartDate;
        private DevExpress.XtraEditors.DateEdit nullableDateTimePickerEndDate;
        private DevExpress.XtraEditors.SimpleButton buttonCancel;
        private DevExpress.XtraEditors.SimpleButton buttonPost;
        private DevExpress.XtraEditors.LookUpEdit lookUpEditDealer;
        private DevExpress.XtraEditors.LookUpEdit lookUpEditDealerState;
        private System.Windows.Forms.BindingSource CustomerStateBindingSource;
        private IACDataSetTableAdapters.stateTableAdapter stateTableAdapter1;
        private DevExpress.XtraEditors.LookUpEdit lookUpEditCustomerState;
        private System.Windows.Forms.BindingSource DealerStateBindingSource;
        private DevExpress.XtraEditors.LookUpEdit lookUpEditPaymentType;
        private DevExpress.XtraEditors.LookUpEdit lookUpEditCodeType;
        private DevExpress.XtraEditors.GroupControl groupControl1;
    }
}
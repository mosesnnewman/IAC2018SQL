namespace IAC2021SQL
{
    partial class frmClosedPaidInFullPriorToMaturityReport
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmClosedPaidInFullPriorToMaturityReport));
            this.labelRunMonth = new System.Windows.Forms.Label();
            this.iACDataSet = new IAC2021SQL.IACDataSet();
            this.labelDealerNum = new System.Windows.Forms.Label();
            this.StatebindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.stateTableAdapter = new IAC2021SQL.IACDataSetTableAdapters.stateTableAdapter();
            this.dlrlistbynumTableAdapter = new IAC2021SQL.IACDataSetTableAdapters.DLRLISTBYNUMTableAdapter();
            this.DLRLISTBYNUMbindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.buttonCancel = new DevExpress.XtraEditors.SimpleButton();
            this.buttonPost = new DevExpress.XtraEditors.SimpleButton();
            this.PaymentCodebindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.PaymentTypebindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.pAYMENTTYPETableAdapter = new IAC2021SQL.IACDataSetTableAdapters.PAYMENTTYPETableAdapter();
            this.pAYCODETableAdapter = new IAC2021SQL.IACDataSetTableAdapters.PAYCODETableAdapter();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.groupBoxDateSelection = new System.Windows.Forms.GroupBox();
            this.nullableDateTimePickerTo = new DevExpress.XtraEditors.DateEdit();
            this.nullableDateTimePickerFrom = new DevExpress.XtraEditors.DateEdit();
            this.groupBoxState = new System.Windows.Forms.GroupBox();
            this.lookUpEditState = new DevExpress.XtraEditors.LookUpEdit();
            this.groupBoxDealer = new System.Windows.Forms.GroupBox();
            this.lookUpEditDealer = new DevExpress.XtraEditors.LookUpEdit();
            this.groupBoxPayCode = new System.Windows.Forms.GroupBox();
            this.lookUpEditCodeType = new DevExpress.XtraEditors.LookUpEdit();
            this.lookUpEditPaymentType = new DevExpress.XtraEditors.LookUpEdit();
            this.checkBoxGap = new System.Windows.Forms.CheckBox();
            this.checkBoxWarranty = new System.Windows.Forms.CheckBox();
            this.groupBoxGapWarranty = new System.Windows.Forms.GroupBox();
            this.groupControl1 = new DevExpress.XtraEditors.GroupControl();
            ((System.ComponentModel.ISupportInitialize)(this.iACDataSet)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.StatebindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.DLRLISTBYNUMbindingSource)).BeginInit();
            this.groupBox3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.PaymentCodebindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.PaymentTypebindingSource)).BeginInit();
            this.groupBoxDateSelection.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nullableDateTimePickerTo.Properties.CalendarTimeProperties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nullableDateTimePickerTo.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nullableDateTimePickerFrom.Properties.CalendarTimeProperties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nullableDateTimePickerFrom.Properties)).BeginInit();
            this.groupBoxState.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.lookUpEditState.Properties)).BeginInit();
            this.groupBoxDealer.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.lookUpEditDealer.Properties)).BeginInit();
            this.groupBoxPayCode.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.lookUpEditCodeType.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lookUpEditPaymentType.Properties)).BeginInit();
            this.groupBoxGapWarranty.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl1)).BeginInit();
            this.groupControl1.SuspendLayout();
            this.SuspendLayout();
            // 
            // labelRunMonth
            // 
            this.labelRunMonth.AutoSize = true;
            this.labelRunMonth.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelRunMonth.Location = new System.Drawing.Point(17, 48);
            this.labelRunMonth.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.labelRunMonth.Name = "labelRunMonth";
            this.labelRunMonth.Size = new System.Drawing.Size(52, 20);
            this.labelRunMonth.TabIndex = 5;
            this.labelRunMonth.Text = "State:";
            this.labelRunMonth.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // iACDataSet
            // 
            this.iACDataSet.DataSetName = "IACDataSet";
            this.iACDataSet.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // labelDealerNum
            // 
            this.labelDealerNum.AutoSize = true;
            this.labelDealerNum.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelDealerNum.Location = new System.Drawing.Point(16, 44);
            this.labelDealerNum.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.labelDealerNum.Name = "labelDealerNum";
            this.labelDealerNum.Size = new System.Drawing.Size(60, 20);
            this.labelDealerNum.TabIndex = 8;
            this.labelDealerNum.Text = "Dealer:";
            this.labelDealerNum.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // StatebindingSource
            // 
            this.StatebindingSource.DataMember = "state";
            this.StatebindingSource.DataSource = this.iACDataSet;
            // 
            // stateTableAdapter
            // 
            this.stateTableAdapter.ClearBeforeFill = true;
            // 
            // dlrlistbynumTableAdapter
            // 
            this.dlrlistbynumTableAdapter.ClearBeforeFill = true;
            // 
            // DLRLISTBYNUMbindingSource
            // 
            this.DLRLISTBYNUMbindingSource.DataMember = "DLRLISTBYNUM";
            this.DLRLISTBYNUMbindingSource.DataSource = this.iACDataSet;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(22, 23);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(50, 20);
            this.label1.TabIndex = 15;
            this.label1.Text = "From:";
            this.label1.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(41, 73);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(31, 20);
            this.label2.TabIndex = 16;
            this.label2.Text = "To:";
            this.label2.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.buttonCancel);
            this.groupBox3.Controls.Add(this.buttonPost);
            this.groupBox3.Location = new System.Drawing.Point(160, 348);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(431, 189);
            this.groupBox3.TabIndex = 17;
            this.groupBox3.TabStop = false;
            // 
            // buttonCancel
            // 
            this.buttonCancel.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("buttonCancel.ImageOptions.Image")));
            this.buttonCancel.ImageOptions.Location = DevExpress.XtraEditors.ImageLocation.MiddleCenter;
            this.buttonCancel.Location = new System.Drawing.Point(244, 27);
            this.buttonCancel.LookAndFeel.SkinName = "McSkin";
            this.buttonCancel.LookAndFeel.UseDefaultLookAndFeel = false;
            this.buttonCancel.Margin = new System.Windows.Forms.Padding(6);
            this.buttonCancel.Name = "buttonCancel";
            this.buttonCancel.Size = new System.Drawing.Size(138, 135);
            this.buttonCancel.TabIndex = 19;
            this.buttonCancel.Click += new System.EventHandler(this.buttonCancel_Click);
            // 
            // buttonPost
            // 
            this.buttonPost.ImageOptions.Image = global::IAC2021SQL.Properties.Resources.Printer;
            this.buttonPost.ImageOptions.Location = DevExpress.XtraEditors.ImageLocation.MiddleCenter;
            this.buttonPost.Location = new System.Drawing.Point(48, 27);
            this.buttonPost.LookAndFeel.SkinName = "McSkin";
            this.buttonPost.LookAndFeel.UseDefaultLookAndFeel = false;
            this.buttonPost.Margin = new System.Windows.Forms.Padding(6);
            this.buttonPost.Name = "buttonPost";
            this.buttonPost.Size = new System.Drawing.Size(138, 135);
            this.buttonPost.TabIndex = 18;
            this.buttonPost.Click += new System.EventHandler(this.buttonPost_Click);
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
            // pAYMENTTYPETableAdapter
            // 
            this.pAYMENTTYPETableAdapter.ClearBeforeFill = true;
            // 
            // pAYCODETableAdapter
            // 
            this.pAYCODETableAdapter.ClearBeforeFill = true;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(53, 68);
            this.label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(117, 20);
            this.label3.TabIndex = 135;
            this.label3.Text = "Payment Code:";
            this.label3.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(57, 26);
            this.label4.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(113, 20);
            this.label4.TabIndex = 134;
            this.label4.Text = "Payment Type:";
            this.label4.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // groupBoxDateSelection
            // 
            this.groupBoxDateSelection.Controls.Add(this.nullableDateTimePickerTo);
            this.groupBoxDateSelection.Controls.Add(this.nullableDateTimePickerFrom);
            this.groupBoxDateSelection.Controls.Add(this.label2);
            this.groupBoxDateSelection.Controls.Add(this.label1);
            this.groupBoxDateSelection.Location = new System.Drawing.Point(25, 13);
            this.groupBoxDateSelection.Name = "groupBoxDateSelection";
            this.groupBoxDateSelection.Size = new System.Drawing.Size(212, 108);
            this.groupBoxDateSelection.TabIndex = 1;
            this.groupBoxDateSelection.TabStop = false;
            // 
            // nullableDateTimePickerTo
            // 
            this.nullableDateTimePickerTo.EditValue = new System.DateTime(2013, 6, 12, 0, 0, 0, 0);
            this.nullableDateTimePickerTo.Location = new System.Drawing.Point(80, 67);
            this.nullableDateTimePickerTo.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.nullableDateTimePickerTo.Name = "nullableDateTimePickerTo";
            this.nullableDateTimePickerTo.Properties.Appearance.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.nullableDateTimePickerTo.Properties.Appearance.Options.UseFont = true;
            this.nullableDateTimePickerTo.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.nullableDateTimePickerTo.Properties.CalendarTimeProperties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.nullableDateTimePickerTo.Properties.CalendarView = DevExpress.XtraEditors.Repository.CalendarView.Fluent;
            this.nullableDateTimePickerTo.Properties.LookAndFeel.SkinName = "McSkin";
            this.nullableDateTimePickerTo.Properties.LookAndFeel.UseDefaultLookAndFeel = false;
            this.nullableDateTimePickerTo.Properties.VistaDisplayMode = DevExpress.Utils.DefaultBoolean.False;
            this.nullableDateTimePickerTo.Size = new System.Drawing.Size(126, 26);
            this.nullableDateTimePickerTo.TabIndex = 3;
            // 
            // nullableDateTimePickerFrom
            // 
            this.nullableDateTimePickerFrom.EditValue = new System.DateTime(2013, 6, 12, 0, 0, 0, 0);
            this.nullableDateTimePickerFrom.Location = new System.Drawing.Point(80, 17);
            this.nullableDateTimePickerFrom.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.nullableDateTimePickerFrom.Name = "nullableDateTimePickerFrom";
            this.nullableDateTimePickerFrom.Properties.Appearance.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.nullableDateTimePickerFrom.Properties.Appearance.Options.UseFont = true;
            this.nullableDateTimePickerFrom.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.nullableDateTimePickerFrom.Properties.CalendarTimeProperties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.nullableDateTimePickerFrom.Properties.CalendarView = DevExpress.XtraEditors.Repository.CalendarView.Fluent;
            this.nullableDateTimePickerFrom.Properties.LookAndFeel.SkinName = "McSkin";
            this.nullableDateTimePickerFrom.Properties.LookAndFeel.UseDefaultLookAndFeel = false;
            this.nullableDateTimePickerFrom.Properties.VistaDisplayMode = DevExpress.Utils.DefaultBoolean.False;
            this.nullableDateTimePickerFrom.Size = new System.Drawing.Size(126, 26);
            this.nullableDateTimePickerFrom.TabIndex = 2;
            // 
            // groupBoxState
            // 
            this.groupBoxState.Controls.Add(this.lookUpEditState);
            this.groupBoxState.Controls.Add(this.labelRunMonth);
            this.groupBoxState.Location = new System.Drawing.Point(251, 13);
            this.groupBoxState.Name = "groupBoxState";
            this.groupBoxState.Size = new System.Drawing.Size(340, 108);
            this.groupBoxState.TabIndex = 4;
            this.groupBoxState.TabStop = false;
            // 
            // lookUpEditState
            // 
            this.lookUpEditState.Location = new System.Drawing.Point(76, 42);
            this.lookUpEditState.Name = "lookUpEditState";
            this.lookUpEditState.Properties.Appearance.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lookUpEditState.Properties.Appearance.Options.UseFont = true;
            this.lookUpEditState.Properties.BestFitMode = DevExpress.XtraEditors.Controls.BestFitMode.BestFitResizePopup;
            this.lookUpEditState.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.lookUpEditState.Properties.Columns.AddRange(new DevExpress.XtraEditors.Controls.LookUpColumnInfo[] {
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("name", "name", 37, DevExpress.Utils.FormatType.None, "", true, DevExpress.Utils.HorzAlignment.Near, DevExpress.Data.ColumnSortOrder.None, DevExpress.Utils.DefaultBoolean.Default),
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("abbreviation", "abbreviation", 74, DevExpress.Utils.FormatType.None, "", true, DevExpress.Utils.HorzAlignment.Near, DevExpress.Data.ColumnSortOrder.None, DevExpress.Utils.DefaultBoolean.Default)});
            this.lookUpEditState.Properties.DataSource = this.StatebindingSource;
            this.lookUpEditState.Properties.DisplayMember = "name";
            this.lookUpEditState.Properties.NullText = "";
            this.lookUpEditState.Properties.ValueMember = "abbreviation";
            this.lookUpEditState.Size = new System.Drawing.Size(247, 26);
            this.lookUpEditState.TabIndex = 5;
            // 
            // groupBoxDealer
            // 
            this.groupBoxDealer.Controls.Add(this.lookUpEditDealer);
            this.groupBoxDealer.Controls.Add(this.labelDealerNum);
            this.groupBoxDealer.Location = new System.Drawing.Point(25, 125);
            this.groupBoxDealer.Name = "groupBoxDealer";
            this.groupBoxDealer.Size = new System.Drawing.Size(566, 108);
            this.groupBoxDealer.TabIndex = 6;
            this.groupBoxDealer.TabStop = false;
            // 
            // lookUpEditDealer
            // 
            this.lookUpEditDealer.Location = new System.Drawing.Point(80, 38);
            this.lookUpEditDealer.Name = "lookUpEditDealer";
            this.lookUpEditDealer.Properties.Appearance.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lookUpEditDealer.Properties.Appearance.Options.UseFont = true;
            this.lookUpEditDealer.Properties.BestFitMode = DevExpress.XtraEditors.Controls.BestFitMode.BestFitResizePopup;
            this.lookUpEditDealer.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.lookUpEditDealer.Properties.Columns.AddRange(new DevExpress.XtraEditors.Controls.LookUpColumnInfo[] {
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("id", "id", 100, DevExpress.Utils.FormatType.Numeric, "", true, DevExpress.Utils.HorzAlignment.Near, DevExpress.Data.ColumnSortOrder.None, DevExpress.Utils.DefaultBoolean.Default),
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("DEALER_NAME", "DEALER_NAME", 800, DevExpress.Utils.FormatType.None, "", true, DevExpress.Utils.HorzAlignment.Near, DevExpress.Data.ColumnSortOrder.None, DevExpress.Utils.DefaultBoolean.Default)});
            this.lookUpEditDealer.Properties.DataSource = this.DLRLISTBYNUMbindingSource;
            this.lookUpEditDealer.Properties.DisplayMember = "id";
            this.lookUpEditDealer.Properties.LookAndFeel.SkinName = "McSkin";
            this.lookUpEditDealer.Properties.LookAndFeel.UseDefaultLookAndFeel = false;
            this.lookUpEditDealer.Properties.NullText = "";
            this.lookUpEditDealer.Properties.ValueMember = "id";
            this.lookUpEditDealer.Size = new System.Drawing.Size(86, 26);
            this.lookUpEditDealer.TabIndex = 7;
            // 
            // groupBoxPayCode
            // 
            this.groupBoxPayCode.Controls.Add(this.lookUpEditCodeType);
            this.groupBoxPayCode.Controls.Add(this.lookUpEditPaymentType);
            this.groupBoxPayCode.Controls.Add(this.label4);
            this.groupBoxPayCode.Controls.Add(this.label3);
            this.groupBoxPayCode.Location = new System.Drawing.Point(25, 237);
            this.groupBoxPayCode.Name = "groupBoxPayCode";
            this.groupBoxPayCode.Size = new System.Drawing.Size(566, 108);
            this.groupBoxPayCode.TabIndex = 9;
            this.groupBoxPayCode.TabStop = false;
            // 
            // lookUpEditCodeType
            // 
            this.lookUpEditCodeType.Location = new System.Drawing.Point(177, 62);
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
            this.lookUpEditCodeType.TabIndex = 136;
            // 
            // lookUpEditPaymentType
            // 
            this.lookUpEditPaymentType.Location = new System.Drawing.Point(177, 20);
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
            this.lookUpEditPaymentType.TabIndex = 10;
            // 
            // checkBoxGap
            // 
            this.checkBoxGap.AutoSize = true;
            this.checkBoxGap.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.checkBoxGap.Location = new System.Drawing.Point(18, 14);
            this.checkBoxGap.Name = "checkBoxGap";
            this.checkBoxGap.Size = new System.Drawing.Size(68, 24);
            this.checkBoxGap.TabIndex = 15;
            this.checkBoxGap.Text = "Gap?";
            this.checkBoxGap.UseVisualStyleBackColor = true;
            // 
            // checkBoxWarranty
            // 
            this.checkBoxWarranty.AutoSize = true;
            this.checkBoxWarranty.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.checkBoxWarranty.Location = new System.Drawing.Point(18, 45);
            this.checkBoxWarranty.Name = "checkBoxWarranty";
            this.checkBoxWarranty.Size = new System.Drawing.Size(92, 24);
            this.checkBoxWarranty.TabIndex = 16;
            this.checkBoxWarranty.Text = "Warranty";
            this.checkBoxWarranty.UseVisualStyleBackColor = true;
            // 
            // groupBoxGapWarranty
            // 
            this.groupBoxGapWarranty.Controls.Add(this.checkBoxWarranty);
            this.groupBoxGapWarranty.Controls.Add(this.checkBoxGap);
            this.groupBoxGapWarranty.Location = new System.Drawing.Point(25, 348);
            this.groupBoxGapWarranty.Name = "groupBoxGapWarranty";
            this.groupBoxGapWarranty.Size = new System.Drawing.Size(129, 82);
            this.groupBoxGapWarranty.TabIndex = 14;
            this.groupBoxGapWarranty.TabStop = false;
            // 
            // groupControl1
            // 
            this.groupControl1.Appearance.BackColor = System.Drawing.Color.LightSteelBlue;
            this.groupControl1.Appearance.Options.UseBackColor = true;
            this.groupControl1.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            this.groupControl1.Controls.Add(this.groupBoxGapWarranty);
            this.groupControl1.Controls.Add(this.groupBoxPayCode);
            this.groupControl1.Controls.Add(this.groupBoxDealer);
            this.groupControl1.Controls.Add(this.groupBoxState);
            this.groupControl1.Controls.Add(this.groupBoxDateSelection);
            this.groupControl1.Controls.Add(this.groupBox3);
            this.groupControl1.Location = new System.Drawing.Point(0, 0);
            this.groupControl1.Name = "groupControl1";
            this.groupControl1.Size = new System.Drawing.Size(625, 545);
            this.groupControl1.TabIndex = 18;
            this.groupControl1.Text = "groupControl1";
            // 
            // frmClosedPaidInFullPriorToMaturityReport
            // 
            this.Appearance.Options.UseFont = true;
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.ClientSize = new System.Drawing.Size(624, 545);
            this.Controls.Add(this.groupControl1);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.Name = "frmClosedPaidInFullPriorToMaturityReport";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Print Closed Paid In Full Prior To Maturity Report";
            this.Load += new System.EventHandler(this.frmClosedPaidInFullPriorToMaturityReport_Load);
            ((System.ComponentModel.ISupportInitialize)(this.iACDataSet)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.StatebindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.DLRLISTBYNUMbindingSource)).EndInit();
            this.groupBox3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.PaymentCodebindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.PaymentTypebindingSource)).EndInit();
            this.groupBoxDateSelection.ResumeLayout(false);
            this.groupBoxDateSelection.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nullableDateTimePickerTo.Properties.CalendarTimeProperties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nullableDateTimePickerTo.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nullableDateTimePickerFrom.Properties.CalendarTimeProperties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nullableDateTimePickerFrom.Properties)).EndInit();
            this.groupBoxState.ResumeLayout(false);
            this.groupBoxState.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.lookUpEditState.Properties)).EndInit();
            this.groupBoxDealer.ResumeLayout(false);
            this.groupBoxDealer.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.lookUpEditDealer.Properties)).EndInit();
            this.groupBoxPayCode.ResumeLayout(false);
            this.groupBoxPayCode.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.lookUpEditCodeType.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lookUpEditPaymentType.Properties)).EndInit();
            this.groupBoxGapWarranty.ResumeLayout(false);
            this.groupBoxGapWarranty.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl1)).EndInit();
            this.groupControl1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label labelRunMonth;
        private IACDataSet iACDataSet;
        private System.Windows.Forms.Label labelDealerNum;
        private System.Windows.Forms.BindingSource StatebindingSource;
        private IACDataSetTableAdapters.stateTableAdapter stateTableAdapter;
        private IACDataSetTableAdapters.DLRLISTBYNUMTableAdapter dlrlistbynumTableAdapter;
        private System.Windows.Forms.BindingSource DLRLISTBYNUMbindingSource;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.GroupBox groupBox3;
        private DevExpress.XtraEditors.SimpleButton buttonCancel;
        private DevExpress.XtraEditors.SimpleButton buttonPost;
        private System.Windows.Forms.BindingSource PaymentCodebindingSource;
        private System.Windows.Forms.BindingSource PaymentTypebindingSource;
        private IACDataSetTableAdapters.PAYMENTTYPETableAdapter pAYMENTTYPETableAdapter;
        private IACDataSetTableAdapters.PAYCODETableAdapter pAYCODETableAdapter;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.GroupBox groupBoxDateSelection;
        private System.Windows.Forms.GroupBox groupBoxState;
        private System.Windows.Forms.GroupBox groupBoxDealer;
        private System.Windows.Forms.GroupBox groupBoxPayCode;
        private System.Windows.Forms.CheckBox checkBoxGap;
        private System.Windows.Forms.CheckBox checkBoxWarranty;
        private System.Windows.Forms.GroupBox groupBoxGapWarranty;
        private DevExpress.XtraEditors.DateEdit nullableDateTimePickerFrom;
        private DevExpress.XtraEditors.DateEdit nullableDateTimePickerTo;
        private DevExpress.XtraEditors.LookUpEdit lookUpEditState;
        private DevExpress.XtraEditors.LookUpEdit lookUpEditDealer;
        private DevExpress.XtraEditors.LookUpEdit lookUpEditPaymentType;
        private DevExpress.XtraEditors.LookUpEdit lookUpEditCodeType;
        private DevExpress.XtraEditors.GroupControl groupControl1;
    }
}
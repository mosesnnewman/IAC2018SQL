namespace IAC2021SQL
{
    partial class frmClosedChargesAppliedtoDealerReport
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
            this.buttonPost = new DevExpress.XtraEditors.SimpleButton();
            this.buttonCancel = new DevExpress.XtraEditors.SimpleButton();
            this.iACDataSet = new IAC2021SQL.IACDataSet();
            this.dealerTableAdapter = new IAC2021SQL.IACDataSetTableAdapters.DEALERTableAdapter();
            this.bindingSourceDLRLISTBYNUM = new System.Windows.Forms.BindingSource(this.components);
            this.dlrlistbynumTableAdapter = new IAC2021SQL.IACDataSetTableAdapters.DLRLISTBYNUMTableAdapter();
            this.lookUpEditDealer = new DevExpress.XtraEditors.LookUpEdit();
            this.label2 = new DevExpress.XtraEditors.LabelControl();
            this.label1 = new DevExpress.XtraEditors.LabelControl();
            this.nullableDateTimePickerStartDate = new DevExpress.XtraEditors.DateEdit();
            this.nullableDateTimePickerEndDate = new DevExpress.XtraEditors.DateEdit();
            this.labelDealerNum = new DevExpress.XtraEditors.LabelControl();
            this.groupControlChargesAppliedToDealer = new DevExpress.XtraEditors.GroupControl();
            ((System.ComponentModel.ISupportInitialize)(this.iACDataSet)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bindingSourceDLRLISTBYNUM)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lookUpEditDealer.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nullableDateTimePickerStartDate.Properties.CalendarTimeProperties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nullableDateTimePickerStartDate.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nullableDateTimePickerEndDate.Properties.CalendarTimeProperties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nullableDateTimePickerEndDate.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.groupControlChargesAppliedToDealer)).BeginInit();
            this.groupControlChargesAppliedToDealer.SuspendLayout();
            this.SuspendLayout();
            // 
            // buttonPost
            // 
            this.buttonPost.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonPost.Location = new System.Drawing.Point(196, 178);
            this.buttonPost.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.buttonPost.Name = "buttonPost";
            this.buttonPost.Size = new System.Drawing.Size(112, 35);
            this.buttonPost.TabIndex = 5;
            this.buttonPost.Text = "&Print";
            //this.buttonPost.UseVisualStyleBackColor = true;
            this.buttonPost.Click += new System.EventHandler(this.buttonPost_Click);
            // 
            // buttonCancel
            // 
            this.buttonCancel.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonCancel.Location = new System.Drawing.Point(318, 178);
            this.buttonCancel.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.buttonCancel.Name = "buttonCancel";
            this.buttonCancel.Size = new System.Drawing.Size(112, 35);
            this.buttonCancel.TabIndex = 6;
            this.buttonCancel.Text = "&Cancel";
            //this.buttonCancel.UseVisualStyleBackColor = true;
            this.buttonCancel.Click += new System.EventHandler(this.buttonCancel_Click);
            // 
            // iACDataSet
            // 
            this.iACDataSet.DataSetName = "IACDataSet";
            this.iACDataSet.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // dealerTableAdapter
            // 
            this.dealerTableAdapter.ClearBeforeFill = true;
            // 
            // bindingSourceDLRLISTBYNUM
            // 
            this.bindingSourceDLRLISTBYNUM.DataMember = "DLRLISTBYNUM";
            this.bindingSourceDLRLISTBYNUM.DataSource = this.iACDataSet;
            // 
            // dlrlistbynumTableAdapter
            // 
            this.dlrlistbynumTableAdapter.ClearBeforeFill = true;
            // 
            // lookUpEditDealer
            // 
            this.lookUpEditDealer.Location = new System.Drawing.Point(279, 112);
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
            this.lookUpEditDealer.Properties.LookAndFeel.SkinName = "McSkin";
            this.lookUpEditDealer.Properties.LookAndFeel.UseDefaultLookAndFeel = false;
            this.lookUpEditDealer.Properties.NullText = "";
            this.lookUpEditDealer.Properties.ValueMember = "id";
            this.lookUpEditDealer.Size = new System.Drawing.Size(86, 26);
            this.lookUpEditDealer.TabIndex = 20;
            // 
            // label2
            // 
            this.label2.Appearance.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Appearance.Options.UseFont = true;
            this.label2.Location = new System.Drawing.Point(251, 74);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(22, 20);
            this.label2.TabIndex = 24;
            this.label2.Text = "To:";
            // 
            // label1
            // 
            this.label1.Appearance.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Appearance.Options.UseFont = true;
            this.label1.Location = new System.Drawing.Point(232, 30);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(41, 20);
            this.label1.TabIndex = 23;
            this.label1.Text = "From:";
            // 
            // nullableDateTimePickerStartDate
            // 
            this.nullableDateTimePickerStartDate.EditValue = new System.DateTime(2013, 6, 12, 0, 0, 0, 0);
            this.nullableDateTimePickerStartDate.Location = new System.Drawing.Point(279, 24);
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
            this.nullableDateTimePickerStartDate.TabIndex = 22;
            // 
            // nullableDateTimePickerEndDate
            // 
            this.nullableDateTimePickerEndDate.EditValue = new System.DateTime(2013, 6, 12, 0, 0, 0, 0);
            this.nullableDateTimePickerEndDate.Location = new System.Drawing.Point(279, 68);
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
            this.nullableDateTimePickerEndDate.TabIndex = 21;
            // 
            // labelDealerNum
            // 
            this.labelDealerNum.Appearance.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelDealerNum.Appearance.Options.UseFont = true;
            this.labelDealerNum.Location = new System.Drawing.Point(222, 118);
            this.labelDealerNum.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.labelDealerNum.Name = "labelDealerNum";
            this.labelDealerNum.Size = new System.Drawing.Size(51, 20);
            this.labelDealerNum.TabIndex = 18;
            this.labelDealerNum.Text = "Dealer:";
            // 
            // groupControlChargesAppliedToDealer
            // 
            this.groupControlChargesAppliedToDealer.Appearance.BackColor = System.Drawing.Color.LightSteelBlue;
            this.groupControlChargesAppliedToDealer.Appearance.Options.UseBackColor = true;
            this.groupControlChargesAppliedToDealer.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            this.groupControlChargesAppliedToDealer.Controls.Add(this.lookUpEditDealer);
            this.groupControlChargesAppliedToDealer.Controls.Add(this.label2);
            this.groupControlChargesAppliedToDealer.Controls.Add(this.label1);
            this.groupControlChargesAppliedToDealer.Controls.Add(this.nullableDateTimePickerStartDate);
            this.groupControlChargesAppliedToDealer.Controls.Add(this.nullableDateTimePickerEndDate);
            this.groupControlChargesAppliedToDealer.Controls.Add(this.labelDealerNum);
            this.groupControlChargesAppliedToDealer.Controls.Add(this.buttonCancel);
            this.groupControlChargesAppliedToDealer.Controls.Add(this.buttonPost);
            this.groupControlChargesAppliedToDealer.Location = new System.Drawing.Point(2, -2);
            this.groupControlChargesAppliedToDealer.Name = "groupControlChargesAppliedToDealer";
            this.groupControlChargesAppliedToDealer.Size = new System.Drawing.Size(627, 235);
            this.groupControlChargesAppliedToDealer.TabIndex = 25;
            this.groupControlChargesAppliedToDealer.Text = "groupControl1";
            // 
            // frmClosedChargesAppliedtoDealerReport
            // 
            this.Appearance.Options.UseFont = true;
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.ClientSize = new System.Drawing.Size(627, 234);
            this.Controls.Add(this.groupControlChargesAppliedToDealer);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.Name = "frmClosedChargesAppliedtoDealerReport";
            this.Text = "Print Closed Charges Applied to Dealer Report (15)";
            this.Load += new System.EventHandler(this.frmClosedChargesAppliedtoDealerReport_Load);
            ((System.ComponentModel.ISupportInitialize)(this.iACDataSet)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bindingSourceDLRLISTBYNUM)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lookUpEditDealer.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nullableDateTimePickerStartDate.Properties.CalendarTimeProperties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nullableDateTimePickerStartDate.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nullableDateTimePickerEndDate.Properties.CalendarTimeProperties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nullableDateTimePickerEndDate.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.groupControlChargesAppliedToDealer)).EndInit();
            this.groupControlChargesAppliedToDealer.ResumeLayout(false);
            this.groupControlChargesAppliedToDealer.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraEditors.SimpleButton buttonPost;
        private DevExpress.XtraEditors.SimpleButton buttonCancel;
        private IACDataSet iACDataSet;
        private IACDataSetTableAdapters.DEALERTableAdapter dealerTableAdapter;
        private System.Windows.Forms.BindingSource bindingSourceDLRLISTBYNUM;
        private IACDataSetTableAdapters.DLRLISTBYNUMTableAdapter dlrlistbynumTableAdapter;
        private DevExpress.XtraEditors.LookUpEdit lookUpEditDealer;
        private DevExpress.XtraEditors.LabelControl label2;
        private DevExpress.XtraEditors.LabelControl label1;
        private DevExpress.XtraEditors.DateEdit nullableDateTimePickerStartDate;
        private DevExpress.XtraEditors.DateEdit nullableDateTimePickerEndDate;
        private DevExpress.XtraEditors.LabelControl labelDealerNum;
        private DevExpress.XtraEditors.GroupControl groupControlChargesAppliedToDealer;
    }
}
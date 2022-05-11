namespace IAC2021SQL
{
    partial class frmOpenChargesAppliedtoDealerReport
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
            this.labelStartDate = new System.Windows.Forms.Label();
            this.labelEndDate = new System.Windows.Forms.Label();
            this.nullableDateTimePickerStartDate = new DevExpress.XtraEditors.DateEdit();
            this.nullableDateTimePickerEndDate = new DevExpress.XtraEditors.DateEdit();
            this.labelDealerNum = new System.Windows.Forms.Label();
            this.groupControl1 = new DevExpress.XtraEditors.GroupControl();
            this.comboBoxDealer = new DevExpress.XtraEditors.LookUpEdit();
            this.bindingSourceDLRLISTBYNUM = new System.Windows.Forms.BindingSource(this.components);
            this.iACDataSet = new IAC2021SQL.IACDataSet();
            this.opndealrTableAdapter = new IAC2021SQL.IACDataSetTableAdapters.OPNDEALRTableAdapter();
            this.opndlrlistbynumTableAdapter = new IAC2021SQL.IACDataSetTableAdapters.OPNDLRLISTBYNUMTableAdapter();
            ((System.ComponentModel.ISupportInitialize)(this.nullableDateTimePickerStartDate.Properties.CalendarTimeProperties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nullableDateTimePickerStartDate.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nullableDateTimePickerEndDate.Properties.CalendarTimeProperties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nullableDateTimePickerEndDate.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl1)).BeginInit();
            this.groupControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.comboBoxDealer.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bindingSourceDLRLISTBYNUM)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.iACDataSet)).BeginInit();
            this.SuspendLayout();
            // 
            // buttonPost
            // 
            this.buttonPost.Appearance.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonPost.Appearance.Options.UseFont = true;
            this.buttonPost.Location = new System.Drawing.Point(138, 108);
            this.buttonPost.Name = "buttonPost";
            this.buttonPost.Size = new System.Drawing.Size(75, 38);
            this.buttonPost.TabIndex = 5;
            this.buttonPost.Text = "&Print";
            this.buttonPost.Click += new System.EventHandler(this.buttonPost_Click);
            // 
            // buttonCancel
            // 
            this.buttonCancel.Appearance.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonCancel.Appearance.Options.UseFont = true;
            this.buttonCancel.Location = new System.Drawing.Point(213, 108);
            this.buttonCancel.Name = "buttonCancel";
            this.buttonCancel.Size = new System.Drawing.Size(75, 38);
            this.buttonCancel.TabIndex = 6;
            this.buttonCancel.Text = "&Cancel";
            this.buttonCancel.Click += new System.EventHandler(this.buttonCancel_Click);
            // 
            // labelStartDate
            // 
            this.labelStartDate.AutoSize = true;
            this.labelStartDate.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelStartDate.Location = new System.Drawing.Point(111, 14);
            this.labelStartDate.Name = "labelStartDate";
            this.labelStartDate.Size = new System.Drawing.Size(81, 21);
            this.labelStartDate.TabIndex = 5;
            this.labelStartDate.Text = "Start Date:";
            this.labelStartDate.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // labelEndDate
            // 
            this.labelEndDate.AutoSize = true;
            this.labelEndDate.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelEndDate.Location = new System.Drawing.Point(117, 45);
            this.labelEndDate.Name = "labelEndDate";
            this.labelEndDate.Size = new System.Drawing.Size(75, 21);
            this.labelEndDate.TabIndex = 8;
            this.labelEndDate.Text = "End Date:";
            this.labelEndDate.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // nullableDateTimePickerStartDate
            // 
            this.nullableDateTimePickerStartDate.EditValue = new System.DateTime(2022, 5, 10, 0, 0, 0, 0);
            this.nullableDateTimePickerStartDate.Location = new System.Drawing.Point(196, 7);
            this.nullableDateTimePickerStartDate.Name = "nullableDateTimePickerStartDate";
            this.nullableDateTimePickerStartDate.Properties.Appearance.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.nullableDateTimePickerStartDate.Properties.Appearance.Options.UseFont = true;
            this.nullableDateTimePickerStartDate.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.nullableDateTimePickerStartDate.Properties.CalendarTimeProperties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.nullableDateTimePickerStartDate.Size = new System.Drawing.Size(113, 28);
            this.nullableDateTimePickerStartDate.TabIndex = 9;
            // 
            // nullableDateTimePickerEndDate
            // 
            this.nullableDateTimePickerEndDate.EditValue = new System.DateTime(2022, 5, 10, 0, 0, 0, 0);
            this.nullableDateTimePickerEndDate.Location = new System.Drawing.Point(196, 38);
            this.nullableDateTimePickerEndDate.Name = "nullableDateTimePickerEndDate";
            this.nullableDateTimePickerEndDate.Properties.Appearance.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.nullableDateTimePickerEndDate.Properties.Appearance.Options.UseFont = true;
            this.nullableDateTimePickerEndDate.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.nullableDateTimePickerEndDate.Properties.CalendarTimeProperties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.nullableDateTimePickerEndDate.Size = new System.Drawing.Size(113, 28);
            this.nullableDateTimePickerEndDate.TabIndex = 10;
            // 
            // labelDealerNum
            // 
            this.labelDealerNum.AutoSize = true;
            this.labelDealerNum.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelDealerNum.Location = new System.Drawing.Point(134, 76);
            this.labelDealerNum.Name = "labelDealerNum";
            this.labelDealerNum.Size = new System.Drawing.Size(58, 21);
            this.labelDealerNum.TabIndex = 13;
            this.labelDealerNum.Text = "Dealer:";
            this.labelDealerNum.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // groupControl1
            // 
            this.groupControl1.Appearance.BackColor = System.Drawing.Color.LightSteelBlue;
            this.groupControl1.Appearance.Options.UseBackColor = true;
            this.groupControl1.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            this.groupControl1.Controls.Add(this.comboBoxDealer);
            this.groupControl1.Controls.Add(this.labelDealerNum);
            this.groupControl1.Controls.Add(this.nullableDateTimePickerEndDate);
            this.groupControl1.Controls.Add(this.nullableDateTimePickerStartDate);
            this.groupControl1.Controls.Add(this.labelEndDate);
            this.groupControl1.Controls.Add(this.labelStartDate);
            this.groupControl1.Controls.Add(this.buttonCancel);
            this.groupControl1.Controls.Add(this.buttonPost);
            this.groupControl1.Location = new System.Drawing.Point(-1, -3);
            this.groupControl1.Name = "groupControl1";
            this.groupControl1.Size = new System.Drawing.Size(420, 156);
            this.groupControl1.TabIndex = 16;
            this.groupControl1.Text = "groupControl1";
            // 
            // comboBoxDealer
            // 
            this.comboBoxDealer.Location = new System.Drawing.Point(196, 69);
            this.comboBoxDealer.Name = "comboBoxDealer";
            this.comboBoxDealer.Properties.Appearance.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.comboBoxDealer.Properties.Appearance.Options.UseFont = true;
            this.comboBoxDealer.Properties.BestFitMode = DevExpress.XtraEditors.Controls.BestFitMode.BestFitResizePopup;
            this.comboBoxDealer.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.comboBoxDealer.Properties.Columns.AddRange(new DevExpress.XtraEditors.Controls.LookUpColumnInfo[] {
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("OPNDEALR_ACC_NO", "id", 100, DevExpress.Utils.FormatType.None, "", true, DevExpress.Utils.HorzAlignment.Near, DevExpress.Data.ColumnSortOrder.None, DevExpress.Utils.DefaultBoolean.Default),
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("OPNDEALR_NAME", "NAME", 800, DevExpress.Utils.FormatType.None, "", true, DevExpress.Utils.HorzAlignment.Near, DevExpress.Data.ColumnSortOrder.None, DevExpress.Utils.DefaultBoolean.Default)});
            this.comboBoxDealer.Properties.DataSource = this.bindingSourceDLRLISTBYNUM;
            this.comboBoxDealer.Properties.DisplayMember = "OPNDEALR_ACC_NO";
            this.comboBoxDealer.Properties.LookAndFeel.SkinName = "McSkin";
            this.comboBoxDealer.Properties.LookAndFeel.UseDefaultLookAndFeel = false;
            this.comboBoxDealer.Properties.NullText = "";
            this.comboBoxDealer.Properties.ValueMember = "OPNDEALR_ACC_NO";
            this.comboBoxDealer.Size = new System.Drawing.Size(113, 28);
            this.comboBoxDealer.TabIndex = 14;
            // 
            // bindingSourceDLRLISTBYNUM
            // 
            this.bindingSourceDLRLISTBYNUM.DataMember = "OPNDLRLISTBYNUM";
            this.bindingSourceDLRLISTBYNUM.DataSource = this.iACDataSet;
            // 
            // iACDataSet
            // 
            this.iACDataSet.DataSetName = "IACDataSet";
            this.iACDataSet.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // opndealrTableAdapter
            // 
            this.opndealrTableAdapter.ClearBeforeFill = true;
            // 
            // opndlrlistbynumTableAdapter
            // 
            this.opndlrlistbynumTableAdapter.ClearBeforeFill = true;
            // 
            // frmOpenChargesAppliedtoDealerReport
            // 
            this.Appearance.Options.UseFont = true;
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.ClientSize = new System.Drawing.Size(418, 150);
            this.Controls.Add(this.groupControl1);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Name = "frmOpenChargesAppliedtoDealerReport";
            this.Text = "Print Open Charges Applied to Dealer Report (15)";
            this.Load += new System.EventHandler(this.frmOpenChargesAppliedtoDealerReport_Load);
            ((System.ComponentModel.ISupportInitialize)(this.nullableDateTimePickerStartDate.Properties.CalendarTimeProperties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nullableDateTimePickerStartDate.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nullableDateTimePickerEndDate.Properties.CalendarTimeProperties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nullableDateTimePickerEndDate.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl1)).EndInit();
            this.groupControl1.ResumeLayout(false);
            this.groupControl1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.comboBoxDealer.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bindingSourceDLRLISTBYNUM)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.iACDataSet)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraEditors.SimpleButton buttonPost;
        private DevExpress.XtraEditors.SimpleButton buttonCancel;
        private System.Windows.Forms.Label labelStartDate;
        private IACDataSet iACDataSet;
        private System.Windows.Forms.Label labelEndDate;
        private DevExpress.XtraEditors.DateEdit nullableDateTimePickerStartDate;
        private DevExpress.XtraEditors.DateEdit nullableDateTimePickerEndDate;
        private System.Windows.Forms.Label labelDealerNum;
        private System.Windows.Forms.BindingSource bindingSourceDLRLISTBYNUM;
        private IACDataSetTableAdapters.OPNDEALRTableAdapter opndealrTableAdapter;
        private IACDataSetTableAdapters.OPNDLRLISTBYNUMTableAdapter opndlrlistbynumTableAdapter;
        private DevExpress.XtraEditors.GroupControl groupControl1;
        private DevExpress.XtraEditors.LookUpEdit comboBoxDealer;
    }
}
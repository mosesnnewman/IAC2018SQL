namespace IAC2021SQL
{
    partial class frmClosedPaidInFullReport
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
            this.labelRunMonth = new DevExpress.XtraEditors.LabelControl();
            this.iACDataSet = new IAC2021SQL.IACDataSet();
            this.labelDealerNum = new DevExpress.XtraEditors.LabelControl();
            this.StatebindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.stateTableAdapter = new IAC2021SQL.IACDataSetTableAdapters.stateTableAdapter();
            this.dlrlistbynumTableAdapter = new IAC2021SQL.IACDataSetTableAdapters.DLRLISTBYNUMTableAdapter();
            this.DLRLISTBYNUMbindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.nullableDateTimePickerTo = new DevExpress.XtraEditors.DateEdit();
            this.nullableDateTimePickerFrom = new DevExpress.XtraEditors.DateEdit();
            this.label1 = new DevExpress.XtraEditors.LabelControl();
            this.label2 = new DevExpress.XtraEditors.LabelControl();
            this.lookUpEditState = new DevExpress.XtraEditors.LookUpEdit();
            this.lookUpEditDealer = new DevExpress.XtraEditors.LookUpEdit();
            this.groupControlPaidInFull = new DevExpress.XtraEditors.GroupControl();
            ((System.ComponentModel.ISupportInitialize)(this.iACDataSet)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.StatebindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.DLRLISTBYNUMbindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nullableDateTimePickerTo.Properties.CalendarTimeProperties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nullableDateTimePickerTo.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nullableDateTimePickerFrom.Properties.CalendarTimeProperties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nullableDateTimePickerFrom.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lookUpEditState.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lookUpEditDealer.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.groupControlPaidInFull)).BeginInit();
            this.groupControlPaidInFull.SuspendLayout();
            this.SuspendLayout();
            // 
            // buttonPost
            // 
            this.buttonPost.Location = new System.Drawing.Point(197, 245);
            this.buttonPost.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.buttonPost.Name = "buttonPost";
            this.buttonPost.Size = new System.Drawing.Size(112, 35);
            this.buttonPost.TabIndex = 5;
            this.buttonPost.Text = "&Print";
            this.buttonPost.Click += new System.EventHandler(this.buttonPost_Click);
            // 
            // buttonCancel
            // 
            this.buttonCancel.Location = new System.Drawing.Point(318, 245);
            this.buttonCancel.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.buttonCancel.Name = "buttonCancel";
            this.buttonCancel.Size = new System.Drawing.Size(112, 35);
            this.buttonCancel.TabIndex = 6;
            this.buttonCancel.Text = "&Cancel";
            this.buttonCancel.Click += new System.EventHandler(this.buttonCancel_Click);
            // 
            // labelRunMonth
            // 
            this.labelRunMonth.Appearance.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelRunMonth.Appearance.Options.UseFont = true;
            this.labelRunMonth.Location = new System.Drawing.Point(170, 136);
            this.labelRunMonth.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.labelRunMonth.Name = "labelRunMonth";
            this.labelRunMonth.Size = new System.Drawing.Size(43, 20);
            this.labelRunMonth.TabIndex = 5;
            this.labelRunMonth.Text = "State:";
            // 
            // iACDataSet
            // 
            this.iACDataSet.DataSetName = "IACDataSet";
            this.iACDataSet.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // labelDealerNum
            // 
            this.labelDealerNum.Appearance.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelDealerNum.Appearance.Options.UseFont = true;
            this.labelDealerNum.Location = new System.Drawing.Point(162, 188);
            this.labelDealerNum.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.labelDealerNum.Name = "labelDealerNum";
            this.labelDealerNum.Size = new System.Drawing.Size(51, 20);
            this.labelDealerNum.TabIndex = 8;
            this.labelDealerNum.Text = "Dealer:";
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
            // nullableDateTimePickerTo
            // 
            this.nullableDateTimePickerTo.EditValue = new System.DateTime(2013, 6, 12, 0, 0, 0, 0);
            this.nullableDateTimePickerTo.Location = new System.Drawing.Point(217, 77);
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
            this.nullableDateTimePickerTo.TabIndex = 13;
            // 
            // nullableDateTimePickerFrom
            // 
            this.nullableDateTimePickerFrom.EditValue = new System.DateTime(2013, 6, 12, 0, 0, 0, 0);
            this.nullableDateTimePickerFrom.Location = new System.Drawing.Point(217, 26);
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
            this.nullableDateTimePickerFrom.TabIndex = 14;
            // 
            // label1
            // 
            this.label1.Appearance.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Appearance.Options.UseFont = true;
            this.label1.Location = new System.Drawing.Point(172, 32);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(41, 20);
            this.label1.TabIndex = 15;
            this.label1.Text = "From:";
            // 
            // label2
            // 
            this.label2.Appearance.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Appearance.Options.UseFont = true;
            this.label2.Location = new System.Drawing.Point(191, 83);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(22, 20);
            this.label2.TabIndex = 16;
            this.label2.Text = "To:";
            // 
            // lookUpEditState
            // 
            this.lookUpEditState.Location = new System.Drawing.Point(217, 130);
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
            this.lookUpEditState.TabIndex = 10;
            // 
            // lookUpEditDealer
            // 
            this.lookUpEditDealer.Location = new System.Drawing.Point(217, 182);
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
            this.lookUpEditDealer.TabIndex = 11;
            // 
            // groupControlPaidInFull
            // 
            this.groupControlPaidInFull.Appearance.BackColor = System.Drawing.Color.LightSteelBlue;
            this.groupControlPaidInFull.Appearance.Options.UseBackColor = true;
            this.groupControlPaidInFull.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            this.groupControlPaidInFull.Controls.Add(this.lookUpEditDealer);
            this.groupControlPaidInFull.Controls.Add(this.lookUpEditState);
            this.groupControlPaidInFull.Controls.Add(this.label2);
            this.groupControlPaidInFull.Controls.Add(this.label1);
            this.groupControlPaidInFull.Controls.Add(this.nullableDateTimePickerFrom);
            this.groupControlPaidInFull.Controls.Add(this.nullableDateTimePickerTo);
            this.groupControlPaidInFull.Controls.Add(this.labelDealerNum);
            this.groupControlPaidInFull.Controls.Add(this.labelRunMonth);
            this.groupControlPaidInFull.Controls.Add(this.buttonCancel);
            this.groupControlPaidInFull.Controls.Add(this.buttonPost);
            this.groupControlPaidInFull.Location = new System.Drawing.Point(-1, 0);
            this.groupControlPaidInFull.LookAndFeel.SkinName = "McSkin";
            this.groupControlPaidInFull.LookAndFeel.UseDefaultLookAndFeel = false;
            this.groupControlPaidInFull.Name = "groupControlPaidInFull";
            this.groupControlPaidInFull.Size = new System.Drawing.Size(627, 307);
            this.groupControlPaidInFull.TabIndex = 17;
            this.groupControlPaidInFull.Text = "groupControl1";
            // 
            // frmClosedPaidInFullReport
            // 
            this.Appearance.Options.UseFont = true;
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.ClientSize = new System.Drawing.Size(624, 305);
            this.Controls.Add(this.groupControlPaidInFull);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.Name = "frmClosedPaidInFullReport";
            this.Text = "Print Closed Paid In Full Report";
            this.Load += new System.EventHandler(this.frmClosedPaidInFullReport_Load);
            ((System.ComponentModel.ISupportInitialize)(this.iACDataSet)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.StatebindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.DLRLISTBYNUMbindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nullableDateTimePickerTo.Properties.CalendarTimeProperties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nullableDateTimePickerTo.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nullableDateTimePickerFrom.Properties.CalendarTimeProperties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nullableDateTimePickerFrom.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lookUpEditState.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lookUpEditDealer.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.groupControlPaidInFull)).EndInit();
            this.groupControlPaidInFull.ResumeLayout(false);
            this.groupControlPaidInFull.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraEditors.SimpleButton buttonPost;
        private DevExpress.XtraEditors.SimpleButton buttonCancel;
        private DevExpress.XtraEditors.LabelControl labelRunMonth;
        private IACDataSet iACDataSet;
        private DevExpress.XtraEditors.LabelControl labelDealerNum;
        private System.Windows.Forms.BindingSource StatebindingSource;
        private IACDataSetTableAdapters.stateTableAdapter stateTableAdapter;
        private IACDataSetTableAdapters.DLRLISTBYNUMTableAdapter dlrlistbynumTableAdapter;
        private System.Windows.Forms.BindingSource DLRLISTBYNUMbindingSource;
        private DevExpress.XtraEditors.DateEdit nullableDateTimePickerTo;
        private DevExpress.XtraEditors.DateEdit nullableDateTimePickerFrom;
        private DevExpress.XtraEditors.LabelControl label1;
        private DevExpress.XtraEditors.LabelControl label2;
        private DevExpress.XtraEditors.LookUpEdit lookUpEditState;
        private DevExpress.XtraEditors.LookUpEdit lookUpEditDealer;
        private DevExpress.XtraEditors.GroupControl groupControlPaidInFull;
    }
}
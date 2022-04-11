namespace IAC2021SQL
{
    partial class FormVSIExtract
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
            this.bindingSourceDLRLISTBYNUM = new System.Windows.Forms.BindingSource(this.components);
            this.iACDataSet = new IAC2021SQL.IACDataSet();
            this.dLRLISTBYNUMTableAdapter = new IAC2021SQL.IACDataSetTableAdapters.DLRLISTBYNUMTableAdapter();
            this.groupBoxSelection = new System.Windows.Forms.GroupBox();
            this.labelStartDate = new System.Windows.Forms.Label();
            this.labelEndDate = new System.Windows.Forms.Label();
            this.nullableDateTimePickerStartDate = new DevExpress.XtraEditors.DateEdit();
            this.nullableDateTimePickerEndDate = new DevExpress.XtraEditors.DateEdit();
            this.labelDealerNum = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.lookUpEditDealer = new DevExpress.XtraEditors.LookUpEdit();
            this.lookUpEditState = new DevExpress.XtraEditors.LookUpEdit();
            this.groupBoxButtons = new System.Windows.Forms.GroupBox();
            this.buttonPost = new DevExpress.XtraEditors.SimpleButton();
            this.buttonCancel = new DevExpress.XtraEditors.SimpleButton();
            this.groupControl1 = new DevExpress.XtraEditors.GroupControl();
            ((System.ComponentModel.ISupportInitialize)(this.bindingSourceDLRLISTBYNUM)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.iACDataSet)).BeginInit();
            this.groupBoxSelection.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nullableDateTimePickerStartDate.Properties.CalendarTimeProperties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nullableDateTimePickerStartDate.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nullableDateTimePickerEndDate.Properties.CalendarTimeProperties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nullableDateTimePickerEndDate.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lookUpEditDealer.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lookUpEditState.Properties)).BeginInit();
            this.groupBoxButtons.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl1)).BeginInit();
            this.groupControl1.SuspendLayout();
            this.SuspendLayout();
            // 
            // bindingSourceDLRLISTBYNUM
            // 
            this.bindingSourceDLRLISTBYNUM.DataMember = "DLRLISTBYNUM";
            this.bindingSourceDLRLISTBYNUM.DataSource = this.iACDataSet;
            // 
            // iACDataSet
            // 
            this.iACDataSet.DataSetName = "IACDataSet";
            this.iACDataSet.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // dLRLISTBYNUMTableAdapter
            // 
            this.dLRLISTBYNUMTableAdapter.ClearBeforeFill = true;
            // 
            // groupBoxSelection
            // 
            this.groupBoxSelection.Controls.Add(this.lookUpEditState);
            this.groupBoxSelection.Controls.Add(this.lookUpEditDealer);
            this.groupBoxSelection.Controls.Add(this.label1);
            this.groupBoxSelection.Controls.Add(this.labelDealerNum);
            this.groupBoxSelection.Controls.Add(this.nullableDateTimePickerEndDate);
            this.groupBoxSelection.Controls.Add(this.nullableDateTimePickerStartDate);
            this.groupBoxSelection.Controls.Add(this.labelEndDate);
            this.groupBoxSelection.Controls.Add(this.labelStartDate);
            this.groupBoxSelection.Location = new System.Drawing.Point(12, 14);
            this.groupBoxSelection.Name = "groupBoxSelection";
            this.groupBoxSelection.Size = new System.Drawing.Size(807, 163);
            this.groupBoxSelection.TabIndex = 34;
            this.groupBoxSelection.TabStop = false;
            // 
            // labelStartDate
            // 
            this.labelStartDate.AutoSize = true;
            this.labelStartDate.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelStartDate.Location = new System.Drawing.Point(41, 22);
            this.labelStartDate.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.labelStartDate.Name = "labelStartDate";
            this.labelStartDate.Size = new System.Drawing.Size(87, 20);
            this.labelStartDate.TabIndex = 23;
            this.labelStartDate.Text = "Start Date:";
            this.labelStartDate.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // labelEndDate
            // 
            this.labelEndDate.AutoSize = true;
            this.labelEndDate.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelEndDate.Location = new System.Drawing.Point(47, 55);
            this.labelEndDate.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.labelEndDate.Name = "labelEndDate";
            this.labelEndDate.Size = new System.Drawing.Size(81, 20);
            this.labelEndDate.TabIndex = 26;
            this.labelEndDate.Text = "End Date:";
            this.labelEndDate.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // nullableDateTimePickerStartDate
            // 
            this.nullableDateTimePickerStartDate.EditValue = new System.DateTime(2022, 4, 6, 0, 0, 0, 0);
            this.nullableDateTimePickerStartDate.Location = new System.Drawing.Point(133, 16);
            this.nullableDateTimePickerStartDate.Margin = new System.Windows.Forms.Padding(6, 8, 6, 8);
            this.nullableDateTimePickerStartDate.Name = "nullableDateTimePickerStartDate";
            this.nullableDateTimePickerStartDate.Properties.Appearance.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.nullableDateTimePickerStartDate.Properties.Appearance.Options.UseFont = true;
            this.nullableDateTimePickerStartDate.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.nullableDateTimePickerStartDate.Properties.CalendarTimeProperties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.nullableDateTimePickerStartDate.Properties.LookAndFeel.SkinName = "McSkin";
            this.nullableDateTimePickerStartDate.Properties.LookAndFeel.UseDefaultLookAndFeel = false;
            this.nullableDateTimePickerStartDate.Size = new System.Drawing.Size(107, 26);
            this.nullableDateTimePickerStartDate.TabIndex = 27;
            // 
            // nullableDateTimePickerEndDate
            // 
            this.nullableDateTimePickerEndDate.EditValue = new System.DateTime(2022, 4, 6, 0, 0, 0, 0);
            this.nullableDateTimePickerEndDate.Location = new System.Drawing.Point(133, 49);
            this.nullableDateTimePickerEndDate.Margin = new System.Windows.Forms.Padding(6, 8, 6, 8);
            this.nullableDateTimePickerEndDate.Name = "nullableDateTimePickerEndDate";
            this.nullableDateTimePickerEndDate.Properties.Appearance.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.nullableDateTimePickerEndDate.Properties.Appearance.Options.UseFont = true;
            this.nullableDateTimePickerEndDate.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.nullableDateTimePickerEndDate.Properties.CalendarTimeProperties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.nullableDateTimePickerEndDate.Properties.LookAndFeel.SkinName = "McSkin";
            this.nullableDateTimePickerEndDate.Properties.LookAndFeel.UseDefaultLookAndFeel = false;
            this.nullableDateTimePickerEndDate.Size = new System.Drawing.Size(107, 26);
            this.nullableDateTimePickerEndDate.TabIndex = 28;
            // 
            // labelDealerNum
            // 
            this.labelDealerNum.AutoSize = true;
            this.labelDealerNum.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelDealerNum.Location = new System.Drawing.Point(68, 90);
            this.labelDealerNum.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.labelDealerNum.Name = "labelDealerNum";
            this.labelDealerNum.Size = new System.Drawing.Size(60, 20);
            this.labelDealerNum.TabIndex = 29;
            this.labelDealerNum.Text = "Dealer:";
            this.labelDealerNum.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(76, 126);
            this.label1.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(52, 20);
            this.label1.TabIndex = 33;
            this.label1.Text = "State:";
            this.label1.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // lookUpEditDealer
            // 
            this.lookUpEditDealer.Location = new System.Drawing.Point(133, 84);
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
            this.lookUpEditDealer.TabIndex = 30;
            // 
            // lookUpEditState
            // 
            this.lookUpEditState.EditValue = "";
            this.lookUpEditState.EnterMoveNextControl = true;
            this.lookUpEditState.Location = new System.Drawing.Point(133, 120);
            this.lookUpEditState.Name = "lookUpEditState";
            this.lookUpEditState.Properties.Appearance.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lookUpEditState.Properties.Appearance.Options.UseFont = true;
            this.lookUpEditState.Properties.BestFitMode = DevExpress.XtraEditors.Controls.BestFitMode.BestFitResizePopup;
            this.lookUpEditState.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.lookUpEditState.Properties.DisplayMember = "name";
            this.lookUpEditState.Properties.LookAndFeel.SkinName = "McSkin";
            this.lookUpEditState.Properties.LookAndFeel.UseDefaultLookAndFeel = false;
            this.lookUpEditState.Properties.NullText = "";
            this.lookUpEditState.Properties.ValueMember = "abbreviation";
            this.lookUpEditState.Size = new System.Drawing.Size(107, 26);
            this.lookUpEditState.TabIndex = 32;
            // 
            // groupBoxButtons
            // 
            this.groupBoxButtons.Controls.Add(this.buttonCancel);
            this.groupBoxButtons.Controls.Add(this.buttonPost);
            this.groupBoxButtons.Location = new System.Drawing.Point(170, 192);
            this.groupBoxButtons.Name = "groupBoxButtons";
            this.groupBoxButtons.Size = new System.Drawing.Size(490, 185);
            this.groupBoxButtons.TabIndex = 35;
            this.groupBoxButtons.TabStop = false;
            // 
            // buttonPost
            // 
            this.buttonPost.Appearance.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonPost.Appearance.Options.UseFont = true;
            this.buttonPost.ImageOptions.Image = global::IAC2021SQL.Properties.Resources.ExportToExcel_64x;
            this.buttonPost.ImageOptions.Location = DevExpress.XtraEditors.ImageLocation.MiddleCenter;
            this.buttonPost.Location = new System.Drawing.Point(46, 15);
            this.buttonPost.LookAndFeel.SkinName = "McSkin";
            this.buttonPost.LookAndFeel.UseDefaultLookAndFeel = false;
            this.buttonPost.Margin = new System.Windows.Forms.Padding(6, 8, 6, 8);
            this.buttonPost.Name = "buttonPost";
            this.buttonPost.Size = new System.Drawing.Size(168, 154);
            this.buttonPost.TabIndex = 24;
            this.buttonPost.Click += new System.EventHandler(this.buttonPost_Click);
            // 
            // buttonCancel
            // 
            this.buttonCancel.Appearance.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonCancel.Appearance.Options.UseFont = true;
            this.buttonCancel.ImageOptions.Image = global::IAC2021SQL.Properties.Resources.Cancel_64x;
            this.buttonCancel.ImageOptions.Location = DevExpress.XtraEditors.ImageLocation.MiddleCenter;
            this.buttonCancel.Location = new System.Drawing.Point(276, 15);
            this.buttonCancel.LookAndFeel.SkinName = "McSkin";
            this.buttonCancel.LookAndFeel.UseDefaultLookAndFeel = false;
            this.buttonCancel.Margin = new System.Windows.Forms.Padding(6, 8, 6, 8);
            this.buttonCancel.Name = "buttonCancel";
            this.buttonCancel.Size = new System.Drawing.Size(168, 154);
            this.buttonCancel.TabIndex = 25;
            this.buttonCancel.Click += new System.EventHandler(this.buttonCancel_Click);
            // 
            // groupControl1
            // 
            this.groupControl1.Appearance.BackColor = System.Drawing.Color.LightSteelBlue;
            this.groupControl1.Appearance.Options.UseBackColor = true;
            this.groupControl1.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            this.groupControl1.Controls.Add(this.groupBoxButtons);
            this.groupControl1.Controls.Add(this.groupBoxSelection);
            this.groupControl1.Location = new System.Drawing.Point(1, 0);
            this.groupControl1.Name = "groupControl1";
            this.groupControl1.Size = new System.Drawing.Size(832, 388);
            this.groupControl1.TabIndex = 36;
            this.groupControl1.Text = "groupControl1";
            // 
            // FormVSIExtract
            // 
            this.Appearance.Options.UseFont = true;
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(832, 389);
            this.Controls.Add(this.groupControl1);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.Name = "FormVSIExtract";
            this.Text = "Customer VSI Extract";
            this.Load += new System.EventHandler(this.FormVSIExtract_Load);
            ((System.ComponentModel.ISupportInitialize)(this.bindingSourceDLRLISTBYNUM)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.iACDataSet)).EndInit();
            this.groupBoxSelection.ResumeLayout(false);
            this.groupBoxSelection.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nullableDateTimePickerStartDate.Properties.CalendarTimeProperties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nullableDateTimePickerStartDate.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nullableDateTimePickerEndDate.Properties.CalendarTimeProperties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nullableDateTimePickerEndDate.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lookUpEditDealer.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lookUpEditState.Properties)).EndInit();
            this.groupBoxButtons.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.groupControl1)).EndInit();
            this.groupControl1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.BindingSource bindingSourceDLRLISTBYNUM;
        private IACDataSet iACDataSet;
        private IACDataSetTableAdapters.DLRLISTBYNUMTableAdapter dLRLISTBYNUMTableAdapter;
        private System.Windows.Forms.GroupBox groupBoxSelection;
        private DevExpress.XtraEditors.LookUpEdit lookUpEditState;
        private DevExpress.XtraEditors.LookUpEdit lookUpEditDealer;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label labelDealerNum;
        private DevExpress.XtraEditors.DateEdit nullableDateTimePickerEndDate;
        private DevExpress.XtraEditors.DateEdit nullableDateTimePickerStartDate;
        private System.Windows.Forms.Label labelEndDate;
        private System.Windows.Forms.Label labelStartDate;
        private System.Windows.Forms.GroupBox groupBoxButtons;
        private DevExpress.XtraEditors.SimpleButton buttonCancel;
        private DevExpress.XtraEditors.SimpleButton buttonPost;
        private DevExpress.XtraEditors.GroupControl groupControl1;
    }
}
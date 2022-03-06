namespace IAC2021SQL
{
    partial class CustomerMissingTitleReport
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
            this.labelStartDate = new DevExpress.XtraEditors.LabelControl();
            this.iACDataSet = new IAC2021SQL.IACDataSet();
            this.labelEndDate = new DevExpress.XtraEditors.LabelControl();
            this.nullableDateTimePickerStartDate = new DevExpress.XtraEditors.DateEdit();
            this.nullableDateTimePickerEndDate = new DevExpress.XtraEditors.DateEdit();
            this.textBoxDealerName = new System.Windows.Forms.TextBox();
            this.bindingSourceDLRLISTBYNUM = new System.Windows.Forms.BindingSource(this.components);
            this.comboBoxDealer = new System.Windows.Forms.ComboBox();
            this.labelDealerNum = new DevExpress.XtraEditors.LabelControl();
            this.dlrlistbynumTableAdapter = new IAC2021SQL.IACDataSetTableAdapters.DLRLISTBYNUMTableAdapter();
            this.closedCustomerBuybackTableAdapter = new IAC2021SQL.IACDataSetTableAdapters.ClosedCustomerBuybackTableAdapter();
            this.radioButtonActive = new System.Windows.Forms.RadioButton();
            this.radioButtonInactive = new System.Windows.Forms.RadioButton();
            this.radioButtonBoth = new System.Windows.Forms.RadioButton();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.groupControlMissingTitle = new DevExpress.XtraEditors.GroupControl();
            this.lookUpEditState = new DevExpress.XtraEditors.LookUpEdit();
            this.stateBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.labelControlState = new DevExpress.XtraEditors.LabelControl();
            this.stateTableAdapter = new IAC2021SQL.IACDataSetTableAdapters.stateTableAdapter();
            ((System.ComponentModel.ISupportInitialize)(this.iACDataSet)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nullableDateTimePickerStartDate.Properties.CalendarTimeProperties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nullableDateTimePickerStartDate.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nullableDateTimePickerEndDate.Properties.CalendarTimeProperties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nullableDateTimePickerEndDate.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bindingSourceDLRLISTBYNUM)).BeginInit();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.groupControlMissingTitle)).BeginInit();
            this.groupControlMissingTitle.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.lookUpEditState.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.stateBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // buttonPost
            // 
            this.buttonPost.Appearance.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonPost.Appearance.Options.UseFont = true;
            this.buttonPost.Location = new System.Drawing.Point(181, 255);
            this.buttonPost.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.buttonPost.Name = "buttonPost";
            this.buttonPost.Size = new System.Drawing.Size(112, 35);
            this.buttonPost.TabIndex = 8;
            this.buttonPost.Text = "&Print";
            this.buttonPost.Click += new System.EventHandler(this.buttonPrint_Click);
            // 
            // buttonCancel
            // 
            this.buttonCancel.Appearance.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonCancel.Appearance.Options.UseFont = true;
            this.buttonCancel.Location = new System.Drawing.Point(302, 255);
            this.buttonCancel.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.buttonCancel.Name = "buttonCancel";
            this.buttonCancel.Size = new System.Drawing.Size(112, 35);
            this.buttonCancel.TabIndex = 9;
            this.buttonCancel.Text = "&Cancel";
            this.buttonCancel.Click += new System.EventHandler(this.buttonCancel_Click);
            // 
            // labelStartDate
            // 
            this.labelStartDate.Appearance.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelStartDate.Appearance.Options.UseFont = true;
            this.labelStartDate.Location = new System.Drawing.Point(56, 12);
            this.labelStartDate.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.labelStartDate.Name = "labelStartDate";
            this.labelStartDate.Size = new System.Drawing.Size(89, 20);
            this.labelStartDate.TabIndex = 5;
            this.labelStartDate.Text = "Start Date:";
            // 
            // iACDataSet
            // 
            this.iACDataSet.DataSetName = "IACDataSet";
            this.iACDataSet.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // labelEndDate
            // 
            this.labelEndDate.Appearance.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelEndDate.Appearance.Options.UseFont = true;
            this.labelEndDate.Location = new System.Drawing.Point(64, 46);
            this.labelEndDate.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.labelEndDate.Name = "labelEndDate";
            this.labelEndDate.Size = new System.Drawing.Size(81, 20);
            this.labelEndDate.TabIndex = 8;
            this.labelEndDate.Text = "End Date:";
            // 
            // nullableDateTimePickerStartDate
            // 
            this.nullableDateTimePickerStartDate.EditValue = new System.DateTime(2022, 3, 3, 0, 0, 0, 0);
            this.nullableDateTimePickerStartDate.EnterMoveNextControl = true;
            this.nullableDateTimePickerStartDate.Location = new System.Drawing.Point(150, 12);
            this.nullableDateTimePickerStartDate.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.nullableDateTimePickerStartDate.Name = "nullableDateTimePickerStartDate";
            this.nullableDateTimePickerStartDate.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.nullableDateTimePickerStartDate.Properties.CalendarTimeProperties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.nullableDateTimePickerStartDate.Size = new System.Drawing.Size(86, 20);
            this.nullableDateTimePickerStartDate.TabIndex = 1;
            // 
            // nullableDateTimePickerEndDate
            // 
            this.nullableDateTimePickerEndDate.EditValue = new System.DateTime(2022, 3, 3, 0, 0, 0, 0);
            this.nullableDateTimePickerEndDate.EnterMoveNextControl = true;
            this.nullableDateTimePickerEndDate.Location = new System.Drawing.Point(150, 46);
            this.nullableDateTimePickerEndDate.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.nullableDateTimePickerEndDate.Name = "nullableDateTimePickerEndDate";
            this.nullableDateTimePickerEndDate.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.nullableDateTimePickerEndDate.Properties.CalendarTimeProperties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.nullableDateTimePickerEndDate.Size = new System.Drawing.Size(86, 20);
            this.nullableDateTimePickerEndDate.TabIndex = 2;
            // 
            // textBoxDealerName
            // 
            this.textBoxDealerName.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bindingSourceDLRLISTBYNUM, "DEALER_NAME", true));
            this.textBoxDealerName.Location = new System.Drawing.Point(250, 79);
            this.textBoxDealerName.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.textBoxDealerName.Name = "textBoxDealerName";
            this.textBoxDealerName.ReadOnly = true;
            this.textBoxDealerName.Size = new System.Drawing.Size(328, 22);
            this.textBoxDealerName.TabIndex = 15;
            // 
            // bindingSourceDLRLISTBYNUM
            // 
            this.bindingSourceDLRLISTBYNUM.DataMember = "DLRLISTBYNUM";
            this.bindingSourceDLRLISTBYNUM.DataSource = this.iACDataSet;
            // 
            // comboBoxDealer
            // 
            this.comboBoxDealer.DataSource = this.bindingSourceDLRLISTBYNUM;
            this.comboBoxDealer.DisplayMember = "DEALER_ACC_NO";
            this.comboBoxDealer.FormattingEnabled = true;
            this.comboBoxDealer.Location = new System.Drawing.Point(150, 80);
            this.comboBoxDealer.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.comboBoxDealer.Name = "comboBoxDealer";
            this.comboBoxDealer.Size = new System.Drawing.Size(86, 21);
            this.comboBoxDealer.TabIndex = 3;
            this.comboBoxDealer.ValueMember = "DEALER_ACC_NO";
            // 
            // labelDealerNum
            // 
            this.labelDealerNum.Appearance.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelDealerNum.Appearance.Options.UseFont = true;
            this.labelDealerNum.Location = new System.Drawing.Point(87, 81);
            this.labelDealerNum.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.labelDealerNum.Name = "labelDealerNum";
            this.labelDealerNum.Size = new System.Drawing.Size(58, 20);
            this.labelDealerNum.TabIndex = 13;
            this.labelDealerNum.Text = "Dealer:";
            // 
            // dlrlistbynumTableAdapter
            // 
            this.dlrlistbynumTableAdapter.ClearBeforeFill = true;
            // 
            // closedCustomerBuybackTableAdapter
            // 
            this.closedCustomerBuybackTableAdapter.ClearBeforeFill = true;
            // 
            // radioButtonActive
            // 
            this.radioButtonActive.AutoSize = true;
            this.radioButtonActive.Checked = true;
            this.radioButtonActive.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.radioButtonActive.Location = new System.Drawing.Point(43, 11);
            this.radioButtonActive.Name = "radioButtonActive";
            this.radioButtonActive.Size = new System.Drawing.Size(76, 24);
            this.radioButtonActive.TabIndex = 5;
            this.radioButtonActive.TabStop = true;
            this.radioButtonActive.Text = "&Active";
            this.radioButtonActive.UseVisualStyleBackColor = true;
            // 
            // radioButtonInactive
            // 
            this.radioButtonInactive.AutoSize = true;
            this.radioButtonInactive.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.radioButtonInactive.Location = new System.Drawing.Point(43, 39);
            this.radioButtonInactive.Name = "radioButtonInactive";
            this.radioButtonInactive.Size = new System.Drawing.Size(90, 24);
            this.radioButtonInactive.TabIndex = 6;
            this.radioButtonInactive.Text = "&Inactive";
            this.radioButtonInactive.UseVisualStyleBackColor = true;
            // 
            // radioButtonBoth
            // 
            this.radioButtonBoth.AutoSize = true;
            this.radioButtonBoth.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.radioButtonBoth.Location = new System.Drawing.Point(43, 67);
            this.radioButtonBoth.Name = "radioButtonBoth";
            this.radioButtonBoth.Size = new System.Drawing.Size(65, 24);
            this.radioButtonBoth.TabIndex = 7;
            this.radioButtonBoth.Text = "&Both";
            this.radioButtonBoth.UseVisualStyleBackColor = true;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.radioButtonBoth);
            this.groupBox1.Controls.Add(this.radioButtonInactive);
            this.groupBox1.Controls.Add(this.radioButtonActive);
            this.groupBox1.Location = new System.Drawing.Point(213, 140);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(169, 102);
            this.groupBox1.TabIndex = 19;
            this.groupBox1.TabStop = false;
            // 
            // groupControlMissingTitle
            // 
            this.groupControlMissingTitle.Appearance.BackColor = System.Drawing.Color.LightSteelBlue;
            this.groupControlMissingTitle.Appearance.Options.UseBackColor = true;
            this.groupControlMissingTitle.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            this.groupControlMissingTitle.Controls.Add(this.lookUpEditState);
            this.groupControlMissingTitle.Controls.Add(this.labelControlState);
            this.groupControlMissingTitle.Controls.Add(this.groupBox1);
            this.groupControlMissingTitle.Controls.Add(this.textBoxDealerName);
            this.groupControlMissingTitle.Controls.Add(this.comboBoxDealer);
            this.groupControlMissingTitle.Controls.Add(this.labelDealerNum);
            this.groupControlMissingTitle.Controls.Add(this.nullableDateTimePickerEndDate);
            this.groupControlMissingTitle.Controls.Add(this.nullableDateTimePickerStartDate);
            this.groupControlMissingTitle.Controls.Add(this.labelEndDate);
            this.groupControlMissingTitle.Controls.Add(this.labelStartDate);
            this.groupControlMissingTitle.Controls.Add(this.buttonCancel);
            this.groupControlMissingTitle.Controls.Add(this.buttonPost);
            this.groupControlMissingTitle.Location = new System.Drawing.Point(1, -1);
            this.groupControlMissingTitle.Name = "groupControlMissingTitle";
            this.groupControlMissingTitle.Size = new System.Drawing.Size(627, 322);
            this.groupControlMissingTitle.TabIndex = 20;
            this.groupControlMissingTitle.Text = "groupControl1";
            // 
            // lookUpEditState
            // 
            this.lookUpEditState.EditValue = "";
            this.lookUpEditState.EnterMoveNextControl = true;
            this.lookUpEditState.Location = new System.Drawing.Point(150, 115);
            this.lookUpEditState.Name = "lookUpEditState";
            this.lookUpEditState.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.lookUpEditState.Properties.DataSource = this.stateBindingSource;
            this.lookUpEditState.Properties.DisplayMember = "name";
            this.lookUpEditState.Properties.ValueMember = "abbreviation";
            this.lookUpEditState.Size = new System.Drawing.Size(107, 20);
            this.lookUpEditState.TabIndex = 4;
            // 
            // stateBindingSource
            // 
            this.stateBindingSource.DataMember = "state";
            this.stateBindingSource.DataSource = this.iACDataSet;
            // 
            // labelControlState
            // 
            this.labelControlState.Appearance.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelControlState.Appearance.Options.UseFont = true;
            this.labelControlState.Appearance.Options.UseTextOptions = true;
            this.labelControlState.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
            this.labelControlState.Location = new System.Drawing.Point(96, 115);
            this.labelControlState.Name = "labelControlState";
            this.labelControlState.Size = new System.Drawing.Size(49, 20);
            this.labelControlState.TabIndex = 20;
            this.labelControlState.Text = "State:";
            // 
            // stateTableAdapter
            // 
            this.stateTableAdapter.ClearBeforeFill = true;
            // 
            // CustomerMissingTitleReport
            // 
            this.Appearance.Options.UseFont = true;
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.ClientSize = new System.Drawing.Size(627, 320);
            this.Controls.Add(this.groupControlMissingTitle);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.Name = "CustomerMissingTitleReport";
            this.Text = "Print CustomerMissing Title Report";
            this.Load += new System.EventHandler(this.CustomerMissingTitleReport_Load);
            ((System.ComponentModel.ISupportInitialize)(this.iACDataSet)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nullableDateTimePickerStartDate.Properties.CalendarTimeProperties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nullableDateTimePickerStartDate.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nullableDateTimePickerEndDate.Properties.CalendarTimeProperties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nullableDateTimePickerEndDate.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bindingSourceDLRLISTBYNUM)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.groupControlMissingTitle)).EndInit();
            this.groupControlMissingTitle.ResumeLayout(false);
            this.groupControlMissingTitle.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.lookUpEditState.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.stateBindingSource)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private DevExpress.XtraEditors.SimpleButton buttonPost;
        private DevExpress.XtraEditors.SimpleButton buttonCancel;
        private DevExpress.XtraEditors.LabelControl labelStartDate;
        private IACDataSet iACDataSet;
        private DevExpress.XtraEditors.LabelControl labelEndDate;
        private DevExpress.XtraEditors.DateEdit nullableDateTimePickerStartDate;
        private DevExpress.XtraEditors.DateEdit nullableDateTimePickerEndDate;
        private System.Windows.Forms.TextBox textBoxDealerName;
        private System.Windows.Forms.ComboBox comboBoxDealer;
        private DevExpress.XtraEditors.LabelControl labelDealerNum;
        private System.Windows.Forms.BindingSource bindingSourceDLRLISTBYNUM;
        private IACDataSetTableAdapters.DLRLISTBYNUMTableAdapter dlrlistbynumTableAdapter;
        private IACDataSetTableAdapters.ClosedCustomerBuybackTableAdapter closedCustomerBuybackTableAdapter;
        private System.Windows.Forms.RadioButton radioButtonActive;
        private System.Windows.Forms.RadioButton radioButtonInactive;
        private System.Windows.Forms.RadioButton radioButtonBoth;
        private System.Windows.Forms.GroupBox groupBox1;
        private DevExpress.XtraEditors.GroupControl groupControlMissingTitle;
        private DevExpress.XtraEditors.LabelControl labelControlState;
        private DevExpress.XtraEditors.LookUpEdit lookUpEditState;
        private System.Windows.Forms.BindingSource stateBindingSource;
        private IACDataSetTableAdapters.stateTableAdapter stateTableAdapter;
    }
}
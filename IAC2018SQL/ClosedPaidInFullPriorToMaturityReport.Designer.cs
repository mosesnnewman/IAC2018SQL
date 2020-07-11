namespace IAC2018SQL
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
            this.iACDataSet = new IAC2018SQL.IACDataSet();
            this.labelDealerNum = new System.Windows.Forms.Label();
            this.comboBoxState = new System.Windows.Forms.ComboBox();
            this.StatebindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.stateTableAdapter = new IAC2018SQL.IACDataSetTableAdapters.stateTableAdapter();
            this.dlrlistbynumTableAdapter = new IAC2018SQL.IACDataSetTableAdapters.DLRLISTBYNUMTableAdapter();
            this.DLRLISTBYNUMbindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.comboBoxDealer = new System.Windows.Forms.ComboBox();
            this.textBoxDealerName = new System.Windows.Forms.TextBox();
            this.nullableDateTimePickerTo = new ProManApp.NullableDateTimePicker();
            this.nullableDateTimePickerFrom = new ProManApp.NullableDateTimePicker();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.buttonCancel = new System.Windows.Forms.Button();
            this.buttonPost = new System.Windows.Forms.Button();
            this.PaymentCodebindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.PaymentTypebindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.pAYMENTTYPETableAdapter = new IAC2018SQL.IACDataSetTableAdapters.PAYMENTTYPETableAdapter();
            this.pAYCODETableAdapter = new IAC2018SQL.IACDataSetTableAdapters.PAYCODETableAdapter();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.PAYCODEcomboBox = new System.Windows.Forms.ComboBox();
            this.PaymentTypetextBox = new System.Windows.Forms.TextBox();
            this.PaymentTypecomboBox = new System.Windows.Forms.ComboBox();
            this.CodeTypetextBox = new System.Windows.Forms.TextBox();
            this.groupBoxDateSelection = new System.Windows.Forms.GroupBox();
            this.groupBoxState = new System.Windows.Forms.GroupBox();
            this.groupBoxDealer = new System.Windows.Forms.GroupBox();
            this.groupBoxPayCode = new System.Windows.Forms.GroupBox();
            this.checkBoxGap = new System.Windows.Forms.CheckBox();
            this.checkBoxWarranty = new System.Windows.Forms.CheckBox();
            this.groupBoxGapWarranty = new System.Windows.Forms.GroupBox();
            ((System.ComponentModel.ISupportInitialize)(this.iACDataSet)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.StatebindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.DLRLISTBYNUMbindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nullableDateTimePickerTo)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nullableDateTimePickerFrom)).BeginInit();
            this.groupBox3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.PaymentCodebindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.PaymentTypebindingSource)).BeginInit();
            this.groupBoxDateSelection.SuspendLayout();
            this.groupBoxState.SuspendLayout();
            this.groupBoxDealer.SuspendLayout();
            this.groupBoxPayCode.SuspendLayout();
            this.groupBoxGapWarranty.SuspendLayout();
            this.SuspendLayout();
            // 
            // labelRunMonth
            // 
            this.labelRunMonth.AutoSize = true;
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
            this.labelDealerNum.Location = new System.Drawing.Point(16, 44);
            this.labelDealerNum.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.labelDealerNum.Name = "labelDealerNum";
            this.labelDealerNum.Size = new System.Drawing.Size(60, 20);
            this.labelDealerNum.TabIndex = 8;
            this.labelDealerNum.Text = "Dealer:";
            this.labelDealerNum.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // comboBoxState
            // 
            this.comboBoxState.DataSource = this.StatebindingSource;
            this.comboBoxState.DisplayMember = "name";
            this.comboBoxState.FormattingEnabled = true;
            this.comboBoxState.Location = new System.Drawing.Point(76, 40);
            this.comboBoxState.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.comboBoxState.Name = "comboBoxState";
            this.comboBoxState.Size = new System.Drawing.Size(247, 28);
            this.comboBoxState.TabIndex = 5;
            this.comboBoxState.ValueMember = "abbreviation";
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
            // comboBoxDealer
            // 
            this.comboBoxDealer.DataSource = this.DLRLISTBYNUMbindingSource;
            this.comboBoxDealer.DisplayMember = "DEALER_ACC_NO";
            this.comboBoxDealer.FormattingEnabled = true;
            this.comboBoxDealer.Location = new System.Drawing.Point(83, 40);
            this.comboBoxDealer.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.comboBoxDealer.Name = "comboBoxDealer";
            this.comboBoxDealer.Size = new System.Drawing.Size(86, 28);
            this.comboBoxDealer.TabIndex = 7;
            this.comboBoxDealer.ValueMember = "DEALER_ACC_NO";
            // 
            // textBoxDealerName
            // 
            this.textBoxDealerName.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.DLRLISTBYNUMbindingSource, "DEALER_NAME", true));
            this.textBoxDealerName.Location = new System.Drawing.Point(183, 42);
            this.textBoxDealerName.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.textBoxDealerName.Name = "textBoxDealerName";
            this.textBoxDealerName.ReadOnly = true;
            this.textBoxDealerName.Size = new System.Drawing.Size(328, 26);
            this.textBoxDealerName.TabIndex = 8;
            // 
            // nullableDateTimePickerTo
            // 
            this.nullableDateTimePickerTo.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.nullableDateTimePickerTo.Location = new System.Drawing.Point(80, 67);
            this.nullableDateTimePickerTo.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.nullableDateTimePickerTo.Name = "nullableDateTimePickerTo";
            this.nullableDateTimePickerTo.Size = new System.Drawing.Size(111, 26);
            this.nullableDateTimePickerTo.TabIndex = 3;
            this.nullableDateTimePickerTo.Value = new System.DateTime(2018, 2, 19, 0, 0, 0, 0);
            // 
            // nullableDateTimePickerFrom
            // 
            this.nullableDateTimePickerFrom.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.nullableDateTimePickerFrom.Location = new System.Drawing.Point(80, 16);
            this.nullableDateTimePickerFrom.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.nullableDateTimePickerFrom.Name = "nullableDateTimePickerFrom";
            this.nullableDateTimePickerFrom.Size = new System.Drawing.Size(111, 26);
            this.nullableDateTimePickerFrom.TabIndex = 2;
            this.nullableDateTimePickerFrom.Value = new System.DateTime(2018, 2, 19, 0, 0, 0, 0);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(22, 17);
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
            this.label2.Location = new System.Drawing.Point(41, 68);
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
            this.groupBox3.Location = new System.Drawing.Point(164, 348);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(431, 189);
            this.groupBox3.TabIndex = 17;
            this.groupBox3.TabStop = false;
            // 
            // buttonCancel
            // 
            this.buttonCancel.Image = ((System.Drawing.Image)(resources.GetObject("buttonCancel.Image")));
            this.buttonCancel.Location = new System.Drawing.Point(244, 27);
            this.buttonCancel.Margin = new System.Windows.Forms.Padding(6);
            this.buttonCancel.Name = "buttonCancel";
            this.buttonCancel.Size = new System.Drawing.Size(138, 135);
            this.buttonCancel.TabIndex = 19;
            this.buttonCancel.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.buttonCancel.UseVisualStyleBackColor = true;
            this.buttonCancel.Click += new System.EventHandler(this.buttonCancel_Click);
            // 
            // buttonPost
            // 
            this.buttonPost.Image = global::IAC2018SQL.Properties.Resources.Printer;
            this.buttonPost.Location = new System.Drawing.Point(48, 27);
            this.buttonPost.Margin = new System.Windows.Forms.Padding(6);
            this.buttonPost.Name = "buttonPost";
            this.buttonPost.Size = new System.Drawing.Size(138, 135);
            this.buttonPost.TabIndex = 18;
            this.buttonPost.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.buttonPost.UseVisualStyleBackColor = true;
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
            this.label4.Location = new System.Drawing.Point(57, 26);
            this.label4.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(113, 20);
            this.label4.TabIndex = 134;
            this.label4.Text = "Payment Type:";
            this.label4.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // PAYCODEcomboBox
            // 
            this.PAYCODEcomboBox.DataSource = this.PaymentCodebindingSource;
            this.PAYCODEcomboBox.DisplayMember = "DESCRIPTION";
            this.PAYCODEcomboBox.FormattingEnabled = true;
            this.PAYCODEcomboBox.Location = new System.Drawing.Point(211, 60);
            this.PAYCODEcomboBox.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.PAYCODEcomboBox.Name = "PAYCODEcomboBox";
            this.PAYCODEcomboBox.Size = new System.Drawing.Size(301, 28);
            this.PAYCODEcomboBox.TabIndex = 13;
            this.PAYCODEcomboBox.ValueMember = "CODE";
            // 
            // PaymentTypetextBox
            // 
            this.PaymentTypetextBox.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.PaymentTypetextBox.Location = new System.Drawing.Point(178, 20);
            this.PaymentTypetextBox.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.PaymentTypetextBox.Name = "PaymentTypetextBox";
            this.PaymentTypetextBox.Size = new System.Drawing.Size(24, 26);
            this.PaymentTypetextBox.TabIndex = 10;
            // 
            // PaymentTypecomboBox
            // 
            this.PaymentTypecomboBox.DataSource = this.PaymentTypebindingSource;
            this.PaymentTypecomboBox.DisplayMember = "DESCRIPTION";
            this.PaymentTypecomboBox.FormattingEnabled = true;
            this.PaymentTypecomboBox.Location = new System.Drawing.Point(212, 20);
            this.PaymentTypecomboBox.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.PaymentTypecomboBox.Name = "PaymentTypecomboBox";
            this.PaymentTypecomboBox.Size = new System.Drawing.Size(301, 28);
            this.PaymentTypecomboBox.TabIndex = 11;
            this.PaymentTypecomboBox.ValueMember = "TYPE";
            // 
            // CodeTypetextBox
            // 
            this.CodeTypetextBox.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.CodeTypetextBox.Location = new System.Drawing.Point(177, 62);
            this.CodeTypetextBox.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.CodeTypetextBox.Name = "CodeTypetextBox";
            this.CodeTypetextBox.Size = new System.Drawing.Size(24, 26);
            this.CodeTypetextBox.TabIndex = 12;
            // 
            // groupBoxDateSelection
            // 
            this.groupBoxDateSelection.Controls.Add(this.label2);
            this.groupBoxDateSelection.Controls.Add(this.label1);
            this.groupBoxDateSelection.Controls.Add(this.nullableDateTimePickerFrom);
            this.groupBoxDateSelection.Controls.Add(this.nullableDateTimePickerTo);
            this.groupBoxDateSelection.Location = new System.Drawing.Point(29, 13);
            this.groupBoxDateSelection.Name = "groupBoxDateSelection";
            this.groupBoxDateSelection.Size = new System.Drawing.Size(212, 108);
            this.groupBoxDateSelection.TabIndex = 1;
            this.groupBoxDateSelection.TabStop = false;
            // 
            // groupBoxState
            // 
            this.groupBoxState.Controls.Add(this.comboBoxState);
            this.groupBoxState.Controls.Add(this.labelRunMonth);
            this.groupBoxState.Location = new System.Drawing.Point(255, 13);
            this.groupBoxState.Name = "groupBoxState";
            this.groupBoxState.Size = new System.Drawing.Size(340, 108);
            this.groupBoxState.TabIndex = 4;
            this.groupBoxState.TabStop = false;
            // 
            // groupBoxDealer
            // 
            this.groupBoxDealer.Controls.Add(this.textBoxDealerName);
            this.groupBoxDealer.Controls.Add(this.comboBoxDealer);
            this.groupBoxDealer.Controls.Add(this.labelDealerNum);
            this.groupBoxDealer.Location = new System.Drawing.Point(29, 125);
            this.groupBoxDealer.Name = "groupBoxDealer";
            this.groupBoxDealer.Size = new System.Drawing.Size(566, 108);
            this.groupBoxDealer.TabIndex = 6;
            this.groupBoxDealer.TabStop = false;
            // 
            // groupBoxPayCode
            // 
            this.groupBoxPayCode.Controls.Add(this.label4);
            this.groupBoxPayCode.Controls.Add(this.PAYCODEcomboBox);
            this.groupBoxPayCode.Controls.Add(this.PaymentTypetextBox);
            this.groupBoxPayCode.Controls.Add(this.PaymentTypecomboBox);
            this.groupBoxPayCode.Controls.Add(this.label3);
            this.groupBoxPayCode.Controls.Add(this.CodeTypetextBox);
            this.groupBoxPayCode.Location = new System.Drawing.Point(29, 237);
            this.groupBoxPayCode.Name = "groupBoxPayCode";
            this.groupBoxPayCode.Size = new System.Drawing.Size(566, 108);
            this.groupBoxPayCode.TabIndex = 9;
            this.groupBoxPayCode.TabStop = false;
            // 
            // checkBoxGap
            // 
            this.checkBoxGap.AutoSize = true;
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
            this.groupBoxGapWarranty.Location = new System.Drawing.Point(29, 348);
            this.groupBoxGapWarranty.Name = "groupBoxGapWarranty";
            this.groupBoxGapWarranty.Size = new System.Drawing.Size(129, 82);
            this.groupBoxGapWarranty.TabIndex = 14;
            this.groupBoxGapWarranty.TabStop = false;
            // 
            // frmClosedPaidInFullPriorToMaturityReport
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.BackColor = System.Drawing.Color.LightSteelBlue;
            this.ClientSize = new System.Drawing.Size(624, 545);
            this.Controls.Add(this.groupBoxGapWarranty);
            this.Controls.Add(this.groupBoxPayCode);
            this.Controls.Add(this.groupBoxDealer);
            this.Controls.Add(this.groupBoxState);
            this.Controls.Add(this.groupBoxDateSelection);
            this.Controls.Add(this.groupBox3);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.Name = "frmClosedPaidInFullPriorToMaturityReport";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Print Closed Paid In Full Prior To Maturity Report";
            this.Load += new System.EventHandler(this.frmClosedPaidInFullPriorToMaturityReport_Load);
            ((System.ComponentModel.ISupportInitialize)(this.iACDataSet)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.StatebindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.DLRLISTBYNUMbindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nullableDateTimePickerTo)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nullableDateTimePickerFrom)).EndInit();
            this.groupBox3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.PaymentCodebindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.PaymentTypebindingSource)).EndInit();
            this.groupBoxDateSelection.ResumeLayout(false);
            this.groupBoxDateSelection.PerformLayout();
            this.groupBoxState.ResumeLayout(false);
            this.groupBoxState.PerformLayout();
            this.groupBoxDealer.ResumeLayout(false);
            this.groupBoxDealer.PerformLayout();
            this.groupBoxPayCode.ResumeLayout(false);
            this.groupBoxPayCode.PerformLayout();
            this.groupBoxGapWarranty.ResumeLayout(false);
            this.groupBoxGapWarranty.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label labelRunMonth;
        private IACDataSet iACDataSet;
        private System.Windows.Forms.Label labelDealerNum;
        private System.Windows.Forms.ComboBox comboBoxState;
        private System.Windows.Forms.BindingSource StatebindingSource;
        private IACDataSetTableAdapters.stateTableAdapter stateTableAdapter;
        private IACDataSetTableAdapters.DLRLISTBYNUMTableAdapter dlrlistbynumTableAdapter;
        private System.Windows.Forms.BindingSource DLRLISTBYNUMbindingSource;
        private System.Windows.Forms.ComboBox comboBoxDealer;
        private System.Windows.Forms.TextBox textBoxDealerName;
        private ProManApp.NullableDateTimePicker nullableDateTimePickerTo;
        private ProManApp.NullableDateTimePicker nullableDateTimePickerFrom;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.Button buttonCancel;
        private System.Windows.Forms.Button buttonPost;
        private System.Windows.Forms.BindingSource PaymentCodebindingSource;
        private System.Windows.Forms.BindingSource PaymentTypebindingSource;
        private IACDataSetTableAdapters.PAYMENTTYPETableAdapter pAYMENTTYPETableAdapter;
        private IACDataSetTableAdapters.PAYCODETableAdapter pAYCODETableAdapter;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ComboBox PAYCODEcomboBox;
        private System.Windows.Forms.TextBox PaymentTypetextBox;
        private System.Windows.Forms.ComboBox PaymentTypecomboBox;
        private System.Windows.Forms.TextBox CodeTypetextBox;
        private System.Windows.Forms.GroupBox groupBoxDateSelection;
        private System.Windows.Forms.GroupBox groupBoxState;
        private System.Windows.Forms.GroupBox groupBoxDealer;
        private System.Windows.Forms.GroupBox groupBoxPayCode;
        private System.Windows.Forms.CheckBox checkBoxGap;
        private System.Windows.Forms.CheckBox checkBoxWarranty;
        private System.Windows.Forms.GroupBox groupBoxGapWarranty;
    }
}
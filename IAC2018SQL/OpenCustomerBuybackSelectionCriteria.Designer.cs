namespace IAC2018SQL
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
            this.buttonPost = new System.Windows.Forms.Button();
            this.buttonCancel = new System.Windows.Forms.Button();
            this.labelStartDate = new System.Windows.Forms.Label();
            this.iACDataSet = new IAC2018SQL.IACDataSet();
            this.labelEndDate = new System.Windows.Forms.Label();
            this.nullableDateTimePickerStartDate = new ProManApp.NullableDateTimePicker();
            this.nullableDateTimePickerEndDate = new ProManApp.NullableDateTimePicker();
            this.textBoxDealerName = new System.Windows.Forms.TextBox();
            this.comboBoxDealer = new System.Windows.Forms.ComboBox();
            this.bindingSourceDLRLISTBYNUM = new System.Windows.Forms.BindingSource(this.components);
            this.labelDealerNum = new System.Windows.Forms.Label();
            this.PAYCODEcomboBox = new System.Windows.Forms.ComboBox();
            this.PaymentCodebindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.PaymentTypetextBox = new System.Windows.Forms.TextBox();
            this.PaymentTypecomboBox = new System.Windows.Forms.ComboBox();
            this.PaymentTypebindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.CodeTypetextBox = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.pAYMENTTYPETableAdapter = new IAC2018SQL.IACDataSetTableAdapters.PAYMENTTYPETableAdapter();
            this.pAYCODETableAdapter = new IAC2018SQL.IACDataSetTableAdapters.PAYCODETableAdapter();
            this.opndlrlistbynumTableAdapter = new IAC2018SQL.IACDataSetTableAdapters.OPNDLRLISTBYNUMTableAdapter();
            ((System.ComponentModel.ISupportInitialize)(this.iACDataSet)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nullableDateTimePickerStartDate)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nullableDateTimePickerEndDate)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bindingSourceDLRLISTBYNUM)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.PaymentCodebindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.PaymentTypebindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // buttonPost
            // 
            this.buttonPost.Location = new System.Drawing.Point(150, 163);
            this.buttonPost.Name = "buttonPost";
            this.buttonPost.Size = new System.Drawing.Size(75, 23);
            this.buttonPost.TabIndex = 5;
            this.buttonPost.Text = "&Print";
            this.buttonPost.UseVisualStyleBackColor = true;
            this.buttonPost.Click += new System.EventHandler(this.buttonPost_Click);
            // 
            // buttonCancel
            // 
            this.buttonCancel.Location = new System.Drawing.Point(231, 163);
            this.buttonCancel.Name = "buttonCancel";
            this.buttonCancel.Size = new System.Drawing.Size(75, 23);
            this.buttonCancel.TabIndex = 6;
            this.buttonCancel.Text = "&Cancel";
            this.buttonCancel.UseVisualStyleBackColor = true;
            this.buttonCancel.Click += new System.EventHandler(this.buttonCancel_Click);
            // 
            // labelStartDate
            // 
            this.labelStartDate.AutoSize = true;
            this.labelStartDate.Location = new System.Drawing.Point(42, 30);
            this.labelStartDate.Name = "labelStartDate";
            this.labelStartDate.Size = new System.Drawing.Size(58, 13);
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
            this.labelEndDate.Location = new System.Drawing.Point(45, 55);
            this.labelEndDate.Name = "labelEndDate";
            this.labelEndDate.Size = new System.Drawing.Size(55, 13);
            this.labelEndDate.TabIndex = 8;
            this.labelEndDate.Text = "End Date:";
            this.labelEndDate.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // nullableDateTimePickerStartDate
            // 
            this.nullableDateTimePickerStartDate.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.nullableDateTimePickerStartDate.Location = new System.Drawing.Point(111, 23);
            this.nullableDateTimePickerStartDate.Name = "nullableDateTimePickerStartDate";
            this.nullableDateTimePickerStartDate.Size = new System.Drawing.Size(95, 20);
            this.nullableDateTimePickerStartDate.TabIndex = 9;
            this.nullableDateTimePickerStartDate.Value = new System.DateTime(2013, 7, 10, 0, 0, 0, 0);
            // 
            // nullableDateTimePickerEndDate
            // 
            this.nullableDateTimePickerEndDate.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.nullableDateTimePickerEndDate.Location = new System.Drawing.Point(111, 48);
            this.nullableDateTimePickerEndDate.Name = "nullableDateTimePickerEndDate";
            this.nullableDateTimePickerEndDate.Size = new System.Drawing.Size(95, 20);
            this.nullableDateTimePickerEndDate.TabIndex = 10;
            this.nullableDateTimePickerEndDate.Value = new System.DateTime(2013, 7, 10, 0, 0, 0, 0);
            // 
            // textBoxDealerName
            // 
            this.textBoxDealerName.Location = new System.Drawing.Point(177, 74);
            this.textBoxDealerName.Name = "textBoxDealerName";
            this.textBoxDealerName.ReadOnly = true;
            this.textBoxDealerName.Size = new System.Drawing.Size(220, 20);
            this.textBoxDealerName.TabIndex = 15;
            // 
            // comboBoxDealer
            // 
            this.comboBoxDealer.DataSource = this.bindingSourceDLRLISTBYNUM;
            this.comboBoxDealer.DisplayMember = "OPNDEALR_ACC_NO";
            this.comboBoxDealer.FormattingEnabled = true;
            this.comboBoxDealer.Location = new System.Drawing.Point(111, 73);
            this.comboBoxDealer.Name = "comboBoxDealer";
            this.comboBoxDealer.Size = new System.Drawing.Size(59, 21);
            this.comboBoxDealer.TabIndex = 14;
            this.comboBoxDealer.ValueMember = "OPNDEALR_ACC_NO";
            // 
            // bindingSourceDLRLISTBYNUM
            // 
            this.bindingSourceDLRLISTBYNUM.DataMember = "OPNDLRLISTBYNUM";
            this.bindingSourceDLRLISTBYNUM.DataSource = this.iACDataSet;
            // 
            // labelDealerNum
            // 
            this.labelDealerNum.AutoSize = true;
            this.labelDealerNum.Location = new System.Drawing.Point(59, 81);
            this.labelDealerNum.Name = "labelDealerNum";
            this.labelDealerNum.Size = new System.Drawing.Size(41, 13);
            this.labelDealerNum.TabIndex = 13;
            this.labelDealerNum.Text = "Dealer:";
            this.labelDealerNum.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // PAYCODEcomboBox
            // 
            this.PAYCODEcomboBox.DataSource = this.PaymentCodebindingSource;
            this.PAYCODEcomboBox.DisplayMember = "DESCRIPTION";
            this.PAYCODEcomboBox.FormattingEnabled = true;
            this.PAYCODEcomboBox.Location = new System.Drawing.Point(133, 125);
            this.PAYCODEcomboBox.Name = "PAYCODEcomboBox";
            this.PAYCODEcomboBox.Size = new System.Drawing.Size(202, 21);
            this.PAYCODEcomboBox.TabIndex = 20;
            this.PAYCODEcomboBox.ValueMember = "CODE";
            this.PAYCODEcomboBox.SelectedIndexChanged += new System.EventHandler(this.PAYCODEcomboBox_SelectedIndexChanged);
            // 
            // PaymentCodebindingSource
            // 
            this.PaymentCodebindingSource.DataMember = "PAYCODE";
            this.PaymentCodebindingSource.DataSource = this.iACDataSet;
            // 
            // PaymentTypetextBox
            // 
            this.PaymentTypetextBox.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.PaymentTypetextBox.Location = new System.Drawing.Point(111, 99);
            this.PaymentTypetextBox.Name = "PaymentTypetextBox";
            this.PaymentTypetextBox.Size = new System.Drawing.Size(17, 20);
            this.PaymentTypetextBox.TabIndex = 17;
            this.PaymentTypetextBox.Validated += new System.EventHandler(this.PaymentTypetextBox_Validated);
            // 
            // PaymentTypecomboBox
            // 
            this.PaymentTypecomboBox.DataSource = this.PaymentTypebindingSource;
            this.PaymentTypecomboBox.DisplayMember = "DESCRIPTION";
            this.PaymentTypecomboBox.FormattingEnabled = true;
            this.PaymentTypecomboBox.Location = new System.Drawing.Point(133, 99);
            this.PaymentTypecomboBox.Name = "PaymentTypecomboBox";
            this.PaymentTypecomboBox.Size = new System.Drawing.Size(202, 21);
            this.PaymentTypecomboBox.TabIndex = 18;
            this.PaymentTypecomboBox.ValueMember = "TYPE";
            this.PaymentTypecomboBox.SelectedIndexChanged += new System.EventHandler(this.PaymentTypecomboBox_SelectedIndexChanged);
            // 
            // PaymentTypebindingSource
            // 
            this.PaymentTypebindingSource.DataMember = "PAYMENTTYPE";
            this.PaymentTypebindingSource.DataSource = this.iACDataSet;
            // 
            // CodeTypetextBox
            // 
            this.CodeTypetextBox.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.CodeTypetextBox.Location = new System.Drawing.Point(111, 126);
            this.CodeTypetextBox.Name = "CodeTypetextBox";
            this.CodeTypetextBox.Size = new System.Drawing.Size(17, 20);
            this.CodeTypetextBox.TabIndex = 19;
            this.CodeTypetextBox.Validated += new System.EventHandler(this.CodeTypetextBox_Validated);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(22, 106);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(78, 13);
            this.label1.TabIndex = 21;
            this.label1.Text = "Payment Type:";
            this.label1.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(21, 135);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(79, 13);
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
            // opndlrlistbynumTableAdapter
            // 
            this.opndlrlistbynumTableAdapter.ClearBeforeFill = true;
            // 
            // frmOpenCustomerBuybackReport
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.BackColor = System.Drawing.Color.LightSteelBlue;
            this.ClientSize = new System.Drawing.Size(418, 208);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.PAYCODEcomboBox);
            this.Controls.Add(this.PaymentTypetextBox);
            this.Controls.Add(this.PaymentTypecomboBox);
            this.Controls.Add(this.CodeTypetextBox);
            this.Controls.Add(this.textBoxDealerName);
            this.Controls.Add(this.comboBoxDealer);
            this.Controls.Add(this.labelDealerNum);
            this.Controls.Add(this.nullableDateTimePickerEndDate);
            this.Controls.Add(this.nullableDateTimePickerStartDate);
            this.Controls.Add(this.labelEndDate);
            this.Controls.Add(this.labelStartDate);
            this.Controls.Add(this.buttonCancel);
            this.Controls.Add(this.buttonPost);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Name = "frmOpenCustomerBuybackReport";
            this.Text = "Print Open Customer Buyback Report (BUYBACK)";
            ((System.ComponentModel.ISupportInitialize)(this.iACDataSet)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nullableDateTimePickerStartDate)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nullableDateTimePickerEndDate)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bindingSourceDLRLISTBYNUM)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.PaymentCodebindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.PaymentTypebindingSource)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button buttonPost;
        private System.Windows.Forms.Button buttonCancel;
        private System.Windows.Forms.Label labelStartDate;
        private IACDataSet iACDataSet;
        private System.Windows.Forms.Label labelEndDate;
        private ProManApp.NullableDateTimePicker nullableDateTimePickerStartDate;
        private ProManApp.NullableDateTimePicker nullableDateTimePickerEndDate;
        private System.Windows.Forms.TextBox textBoxDealerName;
        private System.Windows.Forms.ComboBox comboBoxDealer;
        private System.Windows.Forms.Label labelDealerNum;
        private System.Windows.Forms.ComboBox PAYCODEcomboBox;
        private System.Windows.Forms.TextBox PaymentTypetextBox;
        private System.Windows.Forms.ComboBox PaymentTypecomboBox;
        private System.Windows.Forms.TextBox CodeTypetextBox;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.BindingSource PaymentTypebindingSource;
        private IACDataSetTableAdapters.PAYMENTTYPETableAdapter pAYMENTTYPETableAdapter;
        private System.Windows.Forms.BindingSource PaymentCodebindingSource;
        private IACDataSetTableAdapters.PAYCODETableAdapter pAYCODETableAdapter;
        private IACDataSetTableAdapters.OPNDLRLISTBYNUMTableAdapter opndlrlistbynumTableAdapter;
        private System.Windows.Forms.BindingSource bindingSourceDLRLISTBYNUM;
    }
}
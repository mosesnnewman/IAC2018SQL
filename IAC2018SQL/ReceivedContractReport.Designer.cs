namespace IAC2018SQL
{
    partial class ClosedCustomerReceivedContractReport
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
            this.bindingSourceDLRLISTBYNUM = new System.Windows.Forms.BindingSource(this.components);
            this.comboBoxDealer = new System.Windows.Forms.ComboBox();
            this.labelDealerNum = new System.Windows.Forms.Label();
            this.dlrlistbynumTableAdapter = new IAC2018SQL.IACDataSetTableAdapters.DLRLISTBYNUMTableAdapter();
            this.closedCustomerBuybackTableAdapter = new IAC2018SQL.IACDataSetTableAdapters.ClosedCustomerBuybackTableAdapter();
            this.radioButtonActive = new System.Windows.Forms.RadioButton();
            this.radioButtonInactive = new System.Windows.Forms.RadioButton();
            this.radioButtonBoth = new System.Windows.Forms.RadioButton();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            ((System.ComponentModel.ISupportInitialize)(this.iACDataSet)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nullableDateTimePickerStartDate)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nullableDateTimePickerEndDate)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bindingSourceDLRLISTBYNUM)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // buttonPost
            // 
            this.buttonPost.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonPost.Location = new System.Drawing.Point(182, 256);
            this.buttonPost.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.buttonPost.Name = "buttonPost";
            this.buttonPost.Size = new System.Drawing.Size(112, 35);
            this.buttonPost.TabIndex = 5;
            this.buttonPost.Text = "&Print";
            this.buttonPost.UseVisualStyleBackColor = true;
            this.buttonPost.Click += new System.EventHandler(this.buttonPrint_Click);
            // 
            // buttonCancel
            // 
            this.buttonCancel.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonCancel.Location = new System.Drawing.Point(303, 256);
            this.buttonCancel.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.buttonCancel.Name = "buttonCancel";
            this.buttonCancel.Size = new System.Drawing.Size(112, 35);
            this.buttonCancel.TabIndex = 6;
            this.buttonCancel.Text = "&Cancel";
            this.buttonCancel.UseVisualStyleBackColor = true;
            this.buttonCancel.Click += new System.EventHandler(this.buttonCancel_Click);
            // 
            // labelStartDate
            // 
            this.labelStartDate.AutoSize = true;
            this.labelStartDate.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelStartDate.Location = new System.Drawing.Point(48, 35);
            this.labelStartDate.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.labelStartDate.Name = "labelStartDate";
            this.labelStartDate.Size = new System.Drawing.Size(98, 20);
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
            this.labelEndDate.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelEndDate.Location = new System.Drawing.Point(53, 69);
            this.labelEndDate.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.labelEndDate.Name = "labelEndDate";
            this.labelEndDate.Size = new System.Drawing.Size(90, 20);
            this.labelEndDate.TabIndex = 8;
            this.labelEndDate.Text = "End Date:";
            this.labelEndDate.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // nullableDateTimePickerStartDate
            // 
            this.nullableDateTimePickerStartDate.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.nullableDateTimePickerStartDate.Location = new System.Drawing.Point(151, 29);
            this.nullableDateTimePickerStartDate.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.nullableDateTimePickerStartDate.Name = "nullableDateTimePickerStartDate";
            this.nullableDateTimePickerStartDate.Size = new System.Drawing.Size(140, 26);
            this.nullableDateTimePickerStartDate.TabIndex = 9;
            this.nullableDateTimePickerStartDate.Value = new System.DateTime(2021, 3, 1, 0, 0, 0, 0);
            // 
            // nullableDateTimePickerEndDate
            // 
            this.nullableDateTimePickerEndDate.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.nullableDateTimePickerEndDate.Location = new System.Drawing.Point(151, 63);
            this.nullableDateTimePickerEndDate.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.nullableDateTimePickerEndDate.Name = "nullableDateTimePickerEndDate";
            this.nullableDateTimePickerEndDate.Size = new System.Drawing.Size(140, 26);
            this.nullableDateTimePickerEndDate.TabIndex = 10;
            this.nullableDateTimePickerEndDate.Value = new System.DateTime(2021, 3, 1, 0, 0, 0, 0);
            // 
            // textBoxDealerName
            // 
            this.textBoxDealerName.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bindingSourceDLRLISTBYNUM, "DEALER_NAME", true));
            this.textBoxDealerName.Location = new System.Drawing.Point(251, 103);
            this.textBoxDealerName.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.textBoxDealerName.Name = "textBoxDealerName";
            this.textBoxDealerName.ReadOnly = true;
            this.textBoxDealerName.Size = new System.Drawing.Size(328, 26);
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
            this.comboBoxDealer.Location = new System.Drawing.Point(151, 101);
            this.comboBoxDealer.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.comboBoxDealer.Name = "comboBoxDealer";
            this.comboBoxDealer.Size = new System.Drawing.Size(86, 28);
            this.comboBoxDealer.TabIndex = 14;
            this.comboBoxDealer.ValueMember = "DEALER_ACC_NO";
            // 
            // labelDealerNum
            // 
            this.labelDealerNum.AutoSize = true;
            this.labelDealerNum.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelDealerNum.Location = new System.Drawing.Point(73, 109);
            this.labelDealerNum.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.labelDealerNum.Name = "labelDealerNum";
            this.labelDealerNum.Size = new System.Drawing.Size(67, 20);
            this.labelDealerNum.TabIndex = 13;
            this.labelDealerNum.Text = "Dealer:";
            this.labelDealerNum.TextAlign = System.Drawing.ContentAlignment.TopRight;
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
            this.radioButtonActive.TabIndex = 16;
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
            this.radioButtonInactive.TabIndex = 17;
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
            this.radioButtonBoth.TabIndex = 18;
            this.radioButtonBoth.Text = "&Both";
            this.radioButtonBoth.UseVisualStyleBackColor = true;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.radioButtonBoth);
            this.groupBox1.Controls.Add(this.radioButtonInactive);
            this.groupBox1.Controls.Add(this.radioButtonActive);
            this.groupBox1.Location = new System.Drawing.Point(214, 141);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(169, 102);
            this.groupBox1.TabIndex = 19;
            this.groupBox1.TabStop = false;
            // 
            // ClosedCustomerReceivedContractReport
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.BackColor = System.Drawing.Color.LightSteelBlue;
            this.ClientSize = new System.Drawing.Size(627, 320);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.textBoxDealerName);
            this.Controls.Add(this.comboBoxDealer);
            this.Controls.Add(this.labelDealerNum);
            this.Controls.Add(this.nullableDateTimePickerEndDate);
            this.Controls.Add(this.nullableDateTimePickerStartDate);
            this.Controls.Add(this.labelEndDate);
            this.Controls.Add(this.labelStartDate);
            this.Controls.Add(this.buttonCancel);
            this.Controls.Add(this.buttonPost);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.Name = "ClosedCustomerReceivedContractReport";
            this.Text = "Print Received Contract Report";
            this.Load += new System.EventHandler(this.ClosedCustomerReceivedContractReport_Load);
            ((System.ComponentModel.ISupportInitialize)(this.iACDataSet)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nullableDateTimePickerStartDate)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nullableDateTimePickerEndDate)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bindingSourceDLRLISTBYNUM)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
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
        private System.Windows.Forms.BindingSource bindingSourceDLRLISTBYNUM;
        private IACDataSetTableAdapters.DLRLISTBYNUMTableAdapter dlrlistbynumTableAdapter;
        private IACDataSetTableAdapters.ClosedCustomerBuybackTableAdapter closedCustomerBuybackTableAdapter;
        private System.Windows.Forms.RadioButton radioButtonActive;
        private System.Windows.Forms.RadioButton radioButtonInactive;
        private System.Windows.Forms.RadioButton radioButtonBoth;
        private System.Windows.Forms.GroupBox groupBox1;
    }
}
namespace IAC2018SQL
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
            this.buttonPost = new System.Windows.Forms.Button();
            this.buttonCancel = new System.Windows.Forms.Button();
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
            ((System.ComponentModel.ISupportInitialize)(this.iACDataSet)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.StatebindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.DLRLISTBYNUMbindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nullableDateTimePickerTo)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nullableDateTimePickerFrom)).BeginInit();
            this.SuspendLayout();
            // 
            // buttonPost
            // 
            this.buttonPost.Location = new System.Drawing.Point(195, 245);
            this.buttonPost.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.buttonPost.Name = "buttonPost";
            this.buttonPost.Size = new System.Drawing.Size(112, 35);
            this.buttonPost.TabIndex = 5;
            this.buttonPost.Text = "&Print";
            this.buttonPost.UseVisualStyleBackColor = true;
            this.buttonPost.Click += new System.EventHandler(this.buttonPost_Click);
            // 
            // buttonCancel
            // 
            this.buttonCancel.Location = new System.Drawing.Point(316, 245);
            this.buttonCancel.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.buttonCancel.Name = "buttonCancel";
            this.buttonCancel.Size = new System.Drawing.Size(112, 35);
            this.buttonCancel.TabIndex = 6;
            this.buttonCancel.Text = "&Cancel";
            this.buttonCancel.UseVisualStyleBackColor = true;
            this.buttonCancel.Click += new System.EventHandler(this.buttonCancel_Click);
            // 
            // labelRunMonth
            // 
            this.labelRunMonth.AutoSize = true;
            this.labelRunMonth.Location = new System.Drawing.Point(66, 136);
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
            this.labelDealerNum.Location = new System.Drawing.Point(58, 188);
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
            this.comboBoxState.Location = new System.Drawing.Point(136, 128);
            this.comboBoxState.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.comboBoxState.Name = "comboBoxState";
            this.comboBoxState.Size = new System.Drawing.Size(247, 28);
            this.comboBoxState.TabIndex = 10;
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
            this.comboBoxDealer.Location = new System.Drawing.Point(136, 180);
            this.comboBoxDealer.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.comboBoxDealer.Name = "comboBoxDealer";
            this.comboBoxDealer.Size = new System.Drawing.Size(86, 28);
            this.comboBoxDealer.TabIndex = 11;
            this.comboBoxDealer.ValueMember = "DEALER_ACC_NO";
            // 
            // textBoxDealerName
            // 
            this.textBoxDealerName.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.DLRLISTBYNUMbindingSource, "DEALER_NAME", true));
            this.textBoxDealerName.Location = new System.Drawing.Point(236, 182);
            this.textBoxDealerName.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.textBoxDealerName.Name = "textBoxDealerName";
            this.textBoxDealerName.ReadOnly = true;
            this.textBoxDealerName.Size = new System.Drawing.Size(328, 26);
            this.textBoxDealerName.TabIndex = 12;
            // 
            // nullableDateTimePickerTo
            // 
            this.nullableDateTimePickerTo.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.nullableDateTimePickerTo.Location = new System.Drawing.Point(136, 77);
            this.nullableDateTimePickerTo.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.nullableDateTimePickerTo.Name = "nullableDateTimePickerTo";
            this.nullableDateTimePickerTo.Size = new System.Drawing.Size(126, 26);
            this.nullableDateTimePickerTo.TabIndex = 13;
            this.nullableDateTimePickerTo.Value = new System.DateTime(2013, 6, 12, 0, 0, 0, 0);
            // 
            // nullableDateTimePickerFrom
            // 
            this.nullableDateTimePickerFrom.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.nullableDateTimePickerFrom.Location = new System.Drawing.Point(136, 26);
            this.nullableDateTimePickerFrom.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.nullableDateTimePickerFrom.Name = "nullableDateTimePickerFrom";
            this.nullableDateTimePickerFrom.Size = new System.Drawing.Size(126, 26);
            this.nullableDateTimePickerFrom.TabIndex = 14;
            this.nullableDateTimePickerFrom.Value = new System.DateTime(2013, 6, 12, 0, 0, 0, 0);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(68, 32);
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
            this.label2.Location = new System.Drawing.Point(87, 83);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(31, 20);
            this.label2.TabIndex = 16;
            this.label2.Text = "To:";
            this.label2.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // frmClosedPaidInFullReport
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.BackColor = System.Drawing.Color.LightSteelBlue;
            this.ClientSize = new System.Drawing.Size(624, 305);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.nullableDateTimePickerFrom);
            this.Controls.Add(this.nullableDateTimePickerTo);
            this.Controls.Add(this.textBoxDealerName);
            this.Controls.Add(this.comboBoxDealer);
            this.Controls.Add(this.comboBoxState);
            this.Controls.Add(this.labelDealerNum);
            this.Controls.Add(this.labelRunMonth);
            this.Controls.Add(this.buttonCancel);
            this.Controls.Add(this.buttonPost);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.Name = "frmClosedPaidInFullReport";
            this.Text = "Print Closed Paid In Full Report";
            this.Load += new System.EventHandler(this.frmClosedPaidInFullReport_Load);
            ((System.ComponentModel.ISupportInitialize)(this.iACDataSet)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.StatebindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.DLRLISTBYNUMbindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nullableDateTimePickerTo)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nullableDateTimePickerFrom)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button buttonPost;
        private System.Windows.Forms.Button buttonCancel;
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
    }
}
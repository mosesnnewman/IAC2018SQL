namespace IAC2021SQL
{
    partial class frmMasterHistoryReport
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
            this.iACDataSet = new IAC2021SQL.IACDataSet();
            this.labelEndDate = new System.Windows.Forms.Label();
            this.nullableDateTimePickerStartDate = new UIComponent.DateTimePicker();
            this.nullableDateTimePickerEndDate = new UIComponent.DateTimePicker();
            this.textBoxDealerName = new System.Windows.Forms.TextBox();
            this.bindingSourceMasterList = new System.Windows.Forms.BindingSource(this.components);
            this.comboBoxAccount = new System.Windows.Forms.ComboBox();
            this.labelAccountNum = new System.Windows.Forms.Label();
            this.masterTableAdapter = new IAC2021SQL.IACDataSetTableAdapters.MASTERTableAdapter();
            this.masthistTableAdapter = new IAC2021SQL.IACDataSetTableAdapters.MASTHISTTableAdapter();
            this.masterlistTableAdapter = new IAC2021SQL.IACDataSetTableAdapters.MASTERLISTTableAdapter();
            ((System.ComponentModel.ISupportInitialize)(this.iACDataSet)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bindingSourceMasterList)).BeginInit();
            this.SuspendLayout();
            // 
            // buttonPost
            // 
            this.buttonPost.Location = new System.Drawing.Point(106, 107);
            this.buttonPost.Name = "buttonPost";
            this.buttonPost.Size = new System.Drawing.Size(75, 23);
            this.buttonPost.TabIndex = 5;
            this.buttonPost.Text = "&Print";
            this.buttonPost.UseVisualStyleBackColor = true;
            this.buttonPost.Click += new System.EventHandler(this.buttonPost_Click);
            // 
            // buttonCancel
            // 
            this.buttonCancel.Location = new System.Drawing.Point(187, 107);
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
            this.labelStartDate.Location = new System.Drawing.Point(33, 30);
            this.labelStartDate.Name = "labelStartDate";
            this.labelStartDate.Size = new System.Drawing.Size(64, 15);
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
            this.labelEndDate.Location = new System.Drawing.Point(36, 55);
            this.labelEndDate.Name = "labelEndDate";
            this.labelEndDate.Size = new System.Drawing.Size(61, 15);
            this.labelEndDate.TabIndex = 8;
            this.labelEndDate.Text = "End Date:";
            this.labelEndDate.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // nullableDateTimePickerStartDate
            // 
            this.nullableDateTimePickerStartDate.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.nullableDateTimePickerStartDate.Location = new System.Drawing.Point(102, 23);
            this.nullableDateTimePickerStartDate.Name = "nullableDateTimePickerStartDate";
            this.nullableDateTimePickerStartDate.Size = new System.Drawing.Size(95, 21);
            this.nullableDateTimePickerStartDate.TabIndex = 9;
            this.nullableDateTimePickerStartDate.Value = new System.DateTime(2020, 10, 13, 0, 0, 0, 0);
            // 
            // nullableDateTimePickerEndDate
            // 
            this.nullableDateTimePickerEndDate.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.nullableDateTimePickerEndDate.Location = new System.Drawing.Point(102, 48);
            this.nullableDateTimePickerEndDate.Name = "nullableDateTimePickerEndDate";
            this.nullableDateTimePickerEndDate.Size = new System.Drawing.Size(95, 21);
            this.nullableDateTimePickerEndDate.TabIndex = 10;
            this.nullableDateTimePickerEndDate.Value = new System.DateTime(2020, 10, 13, 0, 0, 0, 0);
            // 
            // textBoxDealerName
            // 
            this.textBoxDealerName.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bindingSourceMasterList, "MASTER_NAME", true));
            this.textBoxDealerName.Location = new System.Drawing.Point(168, 74);
            this.textBoxDealerName.Name = "textBoxDealerName";
            this.textBoxDealerName.ReadOnly = true;
            this.textBoxDealerName.Size = new System.Drawing.Size(220, 21);
            this.textBoxDealerName.TabIndex = 15;
            // 
            // bindingSourceMasterList
            // 
            this.bindingSourceMasterList.DataMember = "MASTERLIST";
            this.bindingSourceMasterList.DataSource = this.iACDataSet;
            // 
            // comboBoxAccount
            // 
            this.comboBoxAccount.DataSource = this.bindingSourceMasterList;
            this.comboBoxAccount.DisplayMember = "MASTER_ACC_NO";
            this.comboBoxAccount.FormattingEnabled = true;
            this.comboBoxAccount.Location = new System.Drawing.Point(102, 73);
            this.comboBoxAccount.Name = "comboBoxAccount";
            this.comboBoxAccount.Size = new System.Drawing.Size(59, 23);
            this.comboBoxAccount.TabIndex = 14;
            this.comboBoxAccount.ValueMember = "MASTER_ACC_NO";
            // 
            // labelAccountNum
            // 
            this.labelAccountNum.AutoSize = true;
            this.labelAccountNum.Location = new System.Drawing.Point(31, 81);
            this.labelAccountNum.Name = "labelAccountNum";
            this.labelAccountNum.Size = new System.Drawing.Size(63, 15);
            this.labelAccountNum.TabIndex = 13;
            this.labelAccountNum.Text = "Account #:";
            this.labelAccountNum.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // masterTableAdapter
            // 
            this.masterTableAdapter.ClearBeforeFill = true;
            // 
            // masthistTableAdapter
            // 
            this.masthistTableAdapter.ClearBeforeFill = true;
            // 
            // masterlistTableAdapter
            // 
            this.masterlistTableAdapter.ClearBeforeFill = true;
            // 
            // frmMasterHistoryReport
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.BackColor = System.Drawing.Color.LightSteelBlue;
            this.ClientSize = new System.Drawing.Size(418, 152);
            this.Controls.Add(this.textBoxDealerName);
            this.Controls.Add(this.comboBoxAccount);
            this.Controls.Add(this.labelAccountNum);
            this.Controls.Add(this.nullableDateTimePickerEndDate);
            this.Controls.Add(this.nullableDateTimePickerStartDate);
            this.Controls.Add(this.labelEndDate);
            this.Controls.Add(this.labelStartDate);
            this.Controls.Add(this.buttonCancel);
            this.Controls.Add(this.buttonPost);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Name = "frmMasterHistoryReport";
            this.Text = "Print Master History Report (43)";
            this.Load += new System.EventHandler(this.frmMasterHistoryReport_Load);
            ((System.ComponentModel.ISupportInitialize)(this.iACDataSet)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bindingSourceMasterList)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button buttonPost;
        private System.Windows.Forms.Button buttonCancel;
        private System.Windows.Forms.Label labelStartDate;
        private IACDataSet iACDataSet;
        private System.Windows.Forms.Label labelEndDate;
        private UIComponent.DateTimePicker nullableDateTimePickerStartDate;
        private UIComponent.DateTimePicker nullableDateTimePickerEndDate;
        private System.Windows.Forms.TextBox textBoxDealerName;
        private System.Windows.Forms.ComboBox comboBoxAccount;
        private System.Windows.Forms.Label labelAccountNum;
        private IACDataSetTableAdapters.MASTERTableAdapter masterTableAdapter;
        private IACDataSetTableAdapters.MASTHISTTableAdapter masthistTableAdapter;
        private IACDataSetTableAdapters.MASTERLISTTableAdapter masterlistTableAdapter;
        private System.Windows.Forms.BindingSource bindingSourceMasterList;
    }
}
namespace IAC2018SQL
{
    partial class frmClosedDelinquencyReports
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
            this.nullableDateTimePickerDueDate = new ProManApp.NullableDateTimePicker();
            this.labelLateNotices = new System.Windows.Forms.Label();
            this.buttonPost = new System.Windows.Forms.Button();
            this.buttonCancel = new System.Windows.Forms.Button();
            this.comboBoxAgedPeriod = new System.Windows.Forms.ComboBox();
            this.labelAgedPeriod = new System.Windows.Forms.Label();
            this.checkBoxCollections = new System.Windows.Forms.CheckBox();
            this.comboBoxSortType = new System.Windows.Forms.ComboBox();
            this.labelSortType = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.nullableDateTimePickerDueDate)).BeginInit();
            this.SuspendLayout();
            // 
            // nullableDateTimePickerDueDate
            // 
            this.nullableDateTimePickerDueDate.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.nullableDateTimePickerDueDate.Location = new System.Drawing.Point(218, 36);
            this.nullableDateTimePickerDueDate.Margin = new System.Windows.Forms.Padding(4);
            this.nullableDateTimePickerDueDate.Name = "nullableDateTimePickerDueDate";
            this.nullableDateTimePickerDueDate.Size = new System.Drawing.Size(123, 26);
            this.nullableDateTimePickerDueDate.TabIndex = 0;
            this.nullableDateTimePickerDueDate.Value = new System.DateTime(2018, 11, 20, 0, 0, 0, 0);
            // 
            // labelLateNotices
            // 
            this.labelLateNotices.AutoSize = true;
            this.labelLateNotices.Location = new System.Drawing.Point(121, 47);
            this.labelLateNotices.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.labelLateNotices.Name = "labelLateNotices";
            this.labelLateNotices.Size = new System.Drawing.Size(82, 20);
            this.labelLateNotices.TabIndex = 1;
            this.labelLateNotices.Text = "Due Date:";
            this.labelLateNotices.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // buttonPost
            // 
            this.buttonPost.Location = new System.Drawing.Point(169, 192);
            this.buttonPost.Margin = new System.Windows.Forms.Padding(4);
            this.buttonPost.Name = "buttonPost";
            this.buttonPost.Size = new System.Drawing.Size(112, 36);
            this.buttonPost.TabIndex = 2;
            this.buttonPost.Text = "&Print";
            this.buttonPost.UseVisualStyleBackColor = true;
            this.buttonPost.Click += new System.EventHandler(this.buttonPost_Click);
            // 
            // buttonCancel
            // 
            this.buttonCancel.Location = new System.Drawing.Point(290, 192);
            this.buttonCancel.Margin = new System.Windows.Forms.Padding(4);
            this.buttonCancel.Name = "buttonCancel";
            this.buttonCancel.Size = new System.Drawing.Size(112, 36);
            this.buttonCancel.TabIndex = 3;
            this.buttonCancel.Text = "&Cancel";
            this.buttonCancel.UseVisualStyleBackColor = true;
            this.buttonCancel.Click += new System.EventHandler(this.buttonCancel_Click);
            // 
            // comboBoxAgedPeriod
            // 
            this.comboBoxAgedPeriod.FormattingEnabled = true;
            this.comboBoxAgedPeriod.Items.AddRange(new object[] {
            "30 Days",
            "60 Days",
            "90 Days",
            "120 Days",
            "150 Days",
            "180+ Days",
            "ALL PERIOD DEALER SUMMARY"});
            this.comboBoxAgedPeriod.Location = new System.Drawing.Point(218, 77);
            this.comboBoxAgedPeriod.Margin = new System.Windows.Forms.Padding(4);
            this.comboBoxAgedPeriod.Name = "comboBoxAgedPeriod";
            this.comboBoxAgedPeriod.Size = new System.Drawing.Size(325, 28);
            this.comboBoxAgedPeriod.TabIndex = 1;
            // 
            // labelAgedPeriod
            // 
            this.labelAgedPeriod.AutoSize = true;
            this.labelAgedPeriod.Location = new System.Drawing.Point(92, 89);
            this.labelAgedPeriod.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.labelAgedPeriod.Name = "labelAgedPeriod";
            this.labelAgedPeriod.Size = new System.Drawing.Size(112, 20);
            this.labelAgedPeriod.TabIndex = 5;
            this.labelAgedPeriod.Text = "Ageing Period:";
            this.labelAgedPeriod.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // checkBoxCollections
            // 
            this.checkBoxCollections.AutoSize = true;
            this.checkBoxCollections.Location = new System.Drawing.Point(96, 111);
            this.checkBoxCollections.Name = "checkBoxCollections";
            this.checkBoxCollections.Size = new System.Drawing.Size(114, 24);
            this.checkBoxCollections.TabIndex = 6;
            this.checkBoxCollections.Text = "Collections?";
            this.checkBoxCollections.UseVisualStyleBackColor = true;
            // 
            // comboBoxSortType
            // 
            this.comboBoxSortType.FormattingEnabled = true;
            this.comboBoxSortType.Items.AddRange(new object[] {
            "Customer Number",
            "Due Date"});
            this.comboBoxSortType.Location = new System.Drawing.Point(218, 134);
            this.comboBoxSortType.Name = "comboBoxSortType";
            this.comboBoxSortType.Size = new System.Drawing.Size(184, 28);
            this.comboBoxSortType.TabIndex = 7;
            // 
            // labelSortType
            // 
            this.labelSortType.AutoSize = true;
            this.labelSortType.Location = new System.Drawing.Point(122, 142);
            this.labelSortType.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.labelSortType.Name = "labelSortType";
            this.labelSortType.Size = new System.Drawing.Size(87, 20);
            this.labelSortType.TabIndex = 8;
            this.labelSortType.Text = "Sort Order:";
            this.labelSortType.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // frmClosedDelinquencyReports
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.BackColor = System.Drawing.Color.LightSteelBlue;
            this.ClientSize = new System.Drawing.Size(569, 276);
            this.Controls.Add(this.labelSortType);
            this.Controls.Add(this.comboBoxSortType);
            this.Controls.Add(this.checkBoxCollections);
            this.Controls.Add(this.labelAgedPeriod);
            this.Controls.Add(this.comboBoxAgedPeriod);
            this.Controls.Add(this.buttonCancel);
            this.Controls.Add(this.buttonPost);
            this.Controls.Add(this.labelLateNotices);
            this.Controls.Add(this.nullableDateTimePickerDueDate);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "frmClosedDelinquencyReports";
            this.Text = "Closed Delinquency Reports";
            this.Load += new System.EventHandler(this.frmClosedDelinquencyReports_Load);
            ((System.ComponentModel.ISupportInitialize)(this.nullableDateTimePickerDueDate)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private ProManApp.NullableDateTimePicker nullableDateTimePickerDueDate;
        private System.Windows.Forms.Label labelLateNotices;
        private System.Windows.Forms.Button buttonPost;
        private System.Windows.Forms.Button buttonCancel;
        private System.Windows.Forms.ComboBox comboBoxAgedPeriod;
        private System.Windows.Forms.Label labelAgedPeriod;
        private System.Windows.Forms.CheckBox checkBoxCollections;
        private System.Windows.Forms.ComboBox comboBoxSortType;
        private System.Windows.Forms.Label labelSortType;
    }
}
namespace IAC2021SQL
{
    partial class frmOpenDelinquencyReports
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
            this.SuspendLayout();
            // 
            // nullableDateTimePickerDueDate
            // 
            this.nullableDateTimePickerDueDate.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.nullableDateTimePickerDueDate.Location = new System.Drawing.Point(219, 35);
            this.nullableDateTimePickerDueDate.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.nullableDateTimePickerDueDate.Name = "nullableDateTimePickerDueDate";
            this.nullableDateTimePickerDueDate.Size = new System.Drawing.Size(122, 26);
            this.nullableDateTimePickerDueDate.TabIndex = 0;
            this.nullableDateTimePickerDueDate.Value = new System.DateTime(2015, 3, 5, 0, 0, 0, 0);
            // 
            // labelLateNotices
            // 
            this.labelLateNotices.AutoSize = true;
            this.labelLateNotices.Location = new System.Drawing.Point(122, 46);
            this.labelLateNotices.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.labelLateNotices.Name = "labelLateNotices";
            this.labelLateNotices.Size = new System.Drawing.Size(82, 20);
            this.labelLateNotices.TabIndex = 1;
            this.labelLateNotices.Text = "Due Date:";
            this.labelLateNotices.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // buttonPost
            // 
            this.buttonPost.Location = new System.Drawing.Point(168, 142);
            this.buttonPost.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.buttonPost.Name = "buttonPost";
            this.buttonPost.Size = new System.Drawing.Size(112, 35);
            this.buttonPost.TabIndex = 2;
            this.buttonPost.Text = "&Print";
            this.buttonPost.UseVisualStyleBackColor = true;
            this.buttonPost.Click += new System.EventHandler(this.buttonPost_Click);
            // 
            // buttonCancel
            // 
            this.buttonCancel.Location = new System.Drawing.Point(290, 142);
            this.buttonCancel.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.buttonCancel.Name = "buttonCancel";
            this.buttonCancel.Size = new System.Drawing.Size(112, 35);
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
            this.comboBoxAgedPeriod.Location = new System.Drawing.Point(219, 77);
            this.comboBoxAgedPeriod.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.comboBoxAgedPeriod.Name = "comboBoxAgedPeriod";
            this.comboBoxAgedPeriod.Size = new System.Drawing.Size(323, 28);
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
            // frmOpenDelinquencyReports
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.BackColor = System.Drawing.Color.LightSteelBlue;
            this.ClientSize = new System.Drawing.Size(568, 214);
            this.Controls.Add(this.labelAgedPeriod);
            this.Controls.Add(this.comboBoxAgedPeriod);
            this.Controls.Add(this.buttonCancel);
            this.Controls.Add(this.buttonPost);
            this.Controls.Add(this.labelLateNotices);
            this.Controls.Add(this.nullableDateTimePickerDueDate);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.Name = "frmOpenDelinquencyReports";
            this.Text = "Open Delinquency Reports";
            this.Load += new System.EventHandler(this.frmOpenDelinquencyReports_Load);
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
    }
}
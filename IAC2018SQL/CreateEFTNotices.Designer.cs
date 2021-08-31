namespace IAC2021SQL
{
    partial class CreateEFTNotices
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(CreateEFTNotices));
            this.comboBoxDayDue = new System.Windows.Forms.ComboBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.nullableDateTimePicker1 = new UIComponent.DateTimePicker();
            this.buttonCreateECHNotices = new System.Windows.Forms.Button();
            this.buttonSendSMS = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.checkBoxAutoPayOnly = new System.Windows.Forms.CheckBox();
            this.groupBoxButtons = new System.Windows.Forms.GroupBox();
            this.checkBoxTestOnly = new System.Windows.Forms.CheckBox();
            this.textBoxTestEmail = new System.Windows.Forms.TextBox();
            this.labelTestEmail = new System.Windows.Forms.Label();
            this.groupBoxTestAndAuto = new System.Windows.Forms.GroupBox();
            this.listBoxMergeFileName = new System.Windows.Forms.ListBox();
            this.labelFileName = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.groupBox1.SuspendLayout();
            this.groupBoxButtons.SuspendLayout();
            this.groupBoxTestAndAuto.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // comboBoxDayDue
            // 
            this.comboBoxDayDue.AllowDrop = true;
            this.comboBoxDayDue.FormattingEnabled = true;
            this.comboBoxDayDue.Items.AddRange(new object[] {
            "5",
            "10",
            "15",
            "20",
            "25",
            "30"});
            this.comboBoxDayDue.Location = new System.Drawing.Point(102, 24);
            this.comboBoxDayDue.MaxLength = 2;
            this.comboBoxDayDue.Name = "comboBoxDayDue";
            this.comboBoxDayDue.Size = new System.Drawing.Size(45, 21);
            this.comboBoxDayDue.TabIndex = 49;
            this.comboBoxDayDue.SelectedIndexChanged += new System.EventHandler(this.comboBoxDayDue_SelectedIndexChanged);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.nullableDateTimePicker1);
            this.groupBox1.Controls.Add(this.comboBoxDayDue);
            this.groupBox1.Location = new System.Drawing.Point(2, 9);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(409, 100);
            this.groupBox1.TabIndex = 51;
            this.groupBox1.TabStop = false;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(166, 78);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(233, 13);
            this.label3.TabIndex = 53;
            this.label3.Text = "* A blank due date selects ALL records!";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(19, 58);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(72, 13);
            this.label2.TabIndex = 52;
            this.label2.Text = "Debit Date:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(31, 27);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(60, 13);
            this.label1.TabIndex = 51;
            this.label1.Text = "Day Due:";
            // 
            // nullableDateTimePicker1
            // 
            this.nullableDateTimePicker1.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.nullableDateTimePicker1.Location = new System.Drawing.Point(102, 51);
            this.nullableDateTimePicker1.Name = "nullableDateTimePicker1";
            this.nullableDateTimePicker1.Size = new System.Drawing.Size(82, 20);
            this.nullableDateTimePicker1.TabIndex = 50;
            this.nullableDateTimePicker1.Value = new System.DateTime(2014, 11, 19, 0, 0, 0, 0);
            // 
            // buttonCreateECHNotices
            // 
            this.buttonCreateECHNotices.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonCreateECHNotices.Image = ((System.Drawing.Image)(resources.GetObject("buttonCreateECHNotices.Image")));
            this.buttonCreateECHNotices.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.buttonCreateECHNotices.Location = new System.Drawing.Point(8, 20);
            this.buttonCreateECHNotices.Name = "buttonCreateECHNotices";
            this.buttonCreateECHNotices.Size = new System.Drawing.Size(131, 58);
            this.buttonCreateECHNotices.TabIndex = 52;
            this.buttonCreateECHNotices.Text = "&Create EFT Notices";
            this.buttonCreateECHNotices.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.buttonCreateECHNotices.UseVisualStyleBackColor = true;
            this.buttonCreateECHNotices.Click += new System.EventHandler(this.buttonCreateECHNotices_Click);
            // 
            // buttonSendSMS
            // 
            this.buttonSendSMS.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonSendSMS.Image = ((System.Drawing.Image)(resources.GetObject("buttonSendSMS.Image")));
            this.buttonSendSMS.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.buttonSendSMS.Location = new System.Drawing.Point(142, 20);
            this.buttonSendSMS.Name = "buttonSendSMS";
            this.buttonSendSMS.Size = new System.Drawing.Size(131, 58);
            this.buttonSendSMS.TabIndex = 53;
            this.buttonSendSMS.Text = "&Send SMS";
            this.buttonSendSMS.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.buttonSendSMS.UseVisualStyleBackColor = true;
            this.buttonSendSMS.Click += new System.EventHandler(this.button2_Click);
            // 
            // button1
            // 
            this.button1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button1.Image = ((System.Drawing.Image)(resources.GetObject("button1.Image")));
            this.button1.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.button1.Location = new System.Drawing.Point(86, 93);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(112, 73);
            this.button1.TabIndex = 54;
            this.button1.Text = "&Exit";
            this.button1.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // checkBoxAutoPayOnly
            // 
            this.checkBoxAutoPayOnly.AutoSize = true;
            this.checkBoxAutoPayOnly.Checked = true;
            this.checkBoxAutoPayOnly.CheckState = System.Windows.Forms.CheckState.Checked;
            this.checkBoxAutoPayOnly.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.checkBoxAutoPayOnly.Location = new System.Drawing.Point(144, 151);
            this.checkBoxAutoPayOnly.Name = "checkBoxAutoPayOnly";
            this.checkBoxAutoPayOnly.Size = new System.Drawing.Size(113, 17);
            this.checkBoxAutoPayOnly.TabIndex = 55;
            this.checkBoxAutoPayOnly.Text = "Auto Pay Only?";
            this.checkBoxAutoPayOnly.UseVisualStyleBackColor = true;
            this.checkBoxAutoPayOnly.CheckedChanged += new System.EventHandler(this.checkBoxAutoPayOnly_CheckedChanged);
            // 
            // groupBoxButtons
            // 
            this.groupBoxButtons.Controls.Add(this.button1);
            this.groupBoxButtons.Controls.Add(this.buttonSendSMS);
            this.groupBoxButtons.Controls.Add(this.buttonCreateECHNotices);
            this.groupBoxButtons.Location = new System.Drawing.Point(67, 443);
            this.groupBoxButtons.Name = "groupBoxButtons";
            this.groupBoxButtons.Size = new System.Drawing.Size(280, 176);
            this.groupBoxButtons.TabIndex = 56;
            this.groupBoxButtons.TabStop = false;
            // 
            // checkBoxTestOnly
            // 
            this.checkBoxTestOnly.AutoSize = true;
            this.checkBoxTestOnly.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.checkBoxTestOnly.Location = new System.Drawing.Point(139, 18);
            this.checkBoxTestOnly.Name = "checkBoxTestOnly";
            this.checkBoxTestOnly.Size = new System.Drawing.Size(122, 17);
            this.checkBoxTestOnly.TabIndex = 57;
            this.checkBoxTestOnly.Text = "Test Mode Only?";
            this.checkBoxTestOnly.UseVisualStyleBackColor = true;
            this.checkBoxTestOnly.CheckedChanged += new System.EventHandler(this.checkBoxTestOnly_CheckedChanged);
            // 
            // textBoxTestEmail
            // 
            this.textBoxTestEmail.Location = new System.Drawing.Point(6, 55);
            this.textBoxTestEmail.MaxLength = 50;
            this.textBoxTestEmail.Multiline = true;
            this.textBoxTestEmail.Name = "textBoxTestEmail";
            this.textBoxTestEmail.Size = new System.Drawing.Size(388, 26);
            this.textBoxTestEmail.TabIndex = 58;
            this.textBoxTestEmail.Visible = false;
            this.textBoxTestEmail.TextChanged += new System.EventHandler(this.textBoxTestEmail_TextChanged);
            // 
            // labelTestEmail
            // 
            this.labelTestEmail.AutoSize = true;
            this.labelTestEmail.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelTestEmail.Location = new System.Drawing.Point(9, 41);
            this.labelTestEmail.Name = "labelTestEmail";
            this.labelTestEmail.Size = new System.Drawing.Size(129, 13);
            this.labelTestEmail.TabIndex = 59;
            this.labelTestEmail.Text = "Test Email Address(s)";
            this.labelTestEmail.Visible = false;
            // 
            // groupBoxTestAndAuto
            // 
            this.groupBoxTestAndAuto.Controls.Add(this.labelTestEmail);
            this.groupBoxTestAndAuto.Controls.Add(this.textBoxTestEmail);
            this.groupBoxTestAndAuto.Controls.Add(this.checkBoxTestOnly);
            this.groupBoxTestAndAuto.Controls.Add(this.checkBoxAutoPayOnly);
            this.groupBoxTestAndAuto.Location = new System.Drawing.Point(2, 111);
            this.groupBoxTestAndAuto.Name = "groupBoxTestAndAuto";
            this.groupBoxTestAndAuto.Size = new System.Drawing.Size(409, 187);
            this.groupBoxTestAndAuto.TabIndex = 60;
            this.groupBoxTestAndAuto.TabStop = false;
            // 
            // listBoxMergeFileName
            // 
            this.listBoxMergeFileName.FormattingEnabled = true;
            this.listBoxMergeFileName.Location = new System.Drawing.Point(4, 28);
            this.listBoxMergeFileName.Name = "listBoxMergeFileName";
            this.listBoxMergeFileName.Size = new System.Drawing.Size(400, 95);
            this.listBoxMergeFileName.TabIndex = 61;
            // 
            // labelFileName
            // 
            this.labelFileName.AutoSize = true;
            this.labelFileName.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelFileName.Location = new System.Drawing.Point(4, 10);
            this.labelFileName.Name = "labelFileName";
            this.labelFileName.Size = new System.Drawing.Size(156, 13);
            this.labelFileName.TabIndex = 62;
            this.labelFileName.Text = "EFT Mail Merge File Name";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.labelFileName);
            this.groupBox2.Controls.Add(this.listBoxMergeFileName);
            this.groupBox2.Location = new System.Drawing.Point(2, 300);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(409, 137);
            this.groupBox2.TabIndex = 63;
            this.groupBox2.TabStop = false;
            // 
            // CreateEFTNotices
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.ClientSize = new System.Drawing.Size(413, 628);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBoxTestAndAuto);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.groupBoxButtons);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Name = "CreateEFTNotices";
            this.Text = "EFT Notices";
            this.Load += new System.EventHandler(this.CreateECHNotices_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBoxButtons.ResumeLayout(false);
            this.groupBoxTestAndAuto.ResumeLayout(false);
            this.groupBoxTestAndAuto.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ComboBox comboBoxDayDue;
        private UIComponent.DateTimePicker nullableDateTimePicker1;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button buttonCreateECHNotices;
        private System.Windows.Forms.Button buttonSendSMS;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.CheckBox checkBoxAutoPayOnly;
        private System.Windows.Forms.GroupBox groupBoxButtons;
        private System.Windows.Forms.CheckBox checkBoxTestOnly;
        private System.Windows.Forms.TextBox textBoxTestEmail;
        private System.Windows.Forms.Label labelTestEmail;
        private System.Windows.Forms.GroupBox groupBoxTestAndAuto;
        private System.Windows.Forms.ListBox listBoxMergeFileName;
        private System.Windows.Forms.Label labelFileName;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Label label3;
    }
}
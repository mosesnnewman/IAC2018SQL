namespace IAC2018SQL
{
    partial class FormBULKSMSMessage
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormBULKSMSMessage));
            this.textBoxMessage = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.textBoxNote = new System.Windows.Forms.TextBox();
            this.labelNote = new System.Windows.Forms.Label();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.buttonSend = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.label7 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.txtPaidThrough = new System.Windows.Forms.MaskedTextBox();
            this.labelPaidThrough = new System.Windows.Forms.Label();
            this.checkBoxNoEFT = new System.Windows.Forms.CheckBox();
            this.checkBoxGracePeriod = new System.Windows.Forms.CheckBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.comboBoxDayDue = new System.Windows.Forms.ComboBox();
            this.labelStatus = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.label8 = new System.Windows.Forms.Label();
            this.nullableDateTimePickerFundingTo = new ProManApp.NullableDateTimePicker();
            this.nullableDateTimePickerFundingFrom = new ProManApp.NullableDateTimePicker();
            this.nullableDateTimePickerContractTo = new ProManApp.NullableDateTimePicker();
            this.nullableDateTimePickerContractFrom = new ProManApp.NullableDateTimePicker();
            this.nullableDateTimePickerDebitDate = new ProManApp.NullableDateTimePicker();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nullableDateTimePickerFundingTo)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nullableDateTimePickerFundingFrom)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nullableDateTimePickerContractTo)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nullableDateTimePickerContractFrom)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nullableDateTimePickerDebitDate)).BeginInit();
            this.SuspendLayout();
            // 
            // textBoxMessage
            // 
            this.textBoxMessage.Enabled = false;
            this.textBoxMessage.Location = new System.Drawing.Point(18, 319);
            this.textBoxMessage.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.textBoxMessage.MaxLength = 180;
            this.textBoxMessage.Multiline = true;
            this.textBoxMessage.Name = "textBoxMessage";
            this.textBoxMessage.Size = new System.Drawing.Size(400, 111);
            this.textBoxMessage.TabIndex = 10;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(18, 288);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(76, 16);
            this.label1.TabIndex = 1;
            this.label1.Text = "Message:";
            // 
            // textBoxNote
            // 
            this.textBoxNote.Location = new System.Drawing.Point(18, 464);
            this.textBoxNote.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.textBoxNote.Multiline = true;
            this.textBoxNote.Name = "textBoxNote";
            this.textBoxNote.Size = new System.Drawing.Size(400, 133);
            this.textBoxNote.TabIndex = 11;
            // 
            // labelNote
            // 
            this.labelNote.AutoSize = true;
            this.labelNote.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelNote.Location = new System.Drawing.Point(18, 435);
            this.labelNote.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.labelNote.Name = "labelNote";
            this.labelNote.Size = new System.Drawing.Size(45, 16);
            this.labelNote.TabIndex = 3;
            this.labelNote.Text = "Note:";
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(383, 276);
            this.pictureBox1.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(35, 37);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            this.pictureBox1.TabIndex = 5;
            this.pictureBox1.TabStop = false;
            this.pictureBox1.Click += new System.EventHandler(this.pictureBox1_Click);
            // 
            // buttonSend
            // 
            this.buttonSend.Image = ((System.Drawing.Image)(resources.GetObject("buttonSend.Image")));
            this.buttonSend.Location = new System.Drawing.Point(148, 613);
            this.buttonSend.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.buttonSend.Name = "buttonSend";
            this.buttonSend.Size = new System.Drawing.Size(141, 95);
            this.buttonSend.TabIndex = 12;
            this.buttonSend.Text = "&Send";
            this.buttonSend.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.buttonSend.UseVisualStyleBackColor = true;
            this.buttonSend.Click += new System.EventHandler(this.buttonSend_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.groupBox3);
            this.groupBox1.Controls.Add(this.groupBox2);
            this.groupBox1.Controls.Add(this.txtPaidThrough);
            this.groupBox1.Controls.Add(this.labelPaidThrough);
            this.groupBox1.Controls.Add(this.checkBoxNoEFT);
            this.groupBox1.Controls.Add(this.checkBoxGracePeriod);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.nullableDateTimePickerDebitDate);
            this.groupBox1.Controls.Add(this.comboBoxDayDue);
            this.groupBox1.Location = new System.Drawing.Point(16, 4);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(409, 264);
            this.groupBox1.TabIndex = 52;
            this.groupBox1.TabStop = false;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.label7);
            this.groupBox2.Controls.Add(this.label6);
            this.groupBox2.Controls.Add(this.nullableDateTimePickerContractTo);
            this.groupBox2.Controls.Add(this.nullableDateTimePickerContractFrom);
            this.groupBox2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox2.Location = new System.Drawing.Point(30, 132);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(349, 58);
            this.groupBox2.TabIndex = 84;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Contract Date";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(190, 26);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(31, 16);
            this.label7.TabIndex = 83;
            this.label7.Text = "To:";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(24, 26);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(47, 16);
            this.label6.TabIndex = 82;
            this.label6.Text = "From:";
            // 
            // txtPaidThrough
            // 
            this.txtPaidThrough.Location = new System.Drawing.Point(100, 98);
            this.txtPaidThrough.Mask = "00/00";
            this.txtPaidThrough.Name = "txtPaidThrough";
            this.txtPaidThrough.Size = new System.Drawing.Size(47, 26);
            this.txtPaidThrough.TabIndex = 5;
            this.txtPaidThrough.TextMaskFormat = System.Windows.Forms.MaskFormat.ExcludePromptAndLiterals;
            // 
            // labelPaidThrough
            // 
            this.labelPaidThrough.AutoSize = true;
            this.labelPaidThrough.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelPaidThrough.Location = new System.Drawing.Point(20, 108);
            this.labelPaidThrough.Name = "labelPaidThrough";
            this.labelPaidThrough.Size = new System.Drawing.Size(79, 16);
            this.labelPaidThrough.TabIndex = 56;
            this.labelPaidThrough.Text = "Paid Thru:";
            // 
            // checkBoxNoEFT
            // 
            this.checkBoxNoEFT.AutoSize = true;
            this.checkBoxNoEFT.Checked = true;
            this.checkBoxNoEFT.CheckState = System.Windows.Forms.CheckState.Checked;
            this.checkBoxNoEFT.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.checkBoxNoEFT.Location = new System.Drawing.Point(234, 50);
            this.checkBoxNoEFT.Name = "checkBoxNoEFT";
            this.checkBoxNoEFT.Size = new System.Drawing.Size(123, 20);
            this.checkBoxNoEFT.TabIndex = 4;
            this.checkBoxNoEFT.Text = "Exclude EFT?";
            this.checkBoxNoEFT.UseVisualStyleBackColor = true;
            // 
            // checkBoxGracePeriod
            // 
            this.checkBoxGracePeriod.AutoSize = true;
            this.checkBoxGracePeriod.Checked = true;
            this.checkBoxGracePeriod.CheckState = System.Windows.Forms.CheckState.Checked;
            this.checkBoxGracePeriod.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.checkBoxGracePeriod.Location = new System.Drawing.Point(234, 24);
            this.checkBoxGracePeriod.Name = "checkBoxGracePeriod";
            this.checkBoxGracePeriod.Size = new System.Drawing.Size(162, 20);
            this.checkBoxGracePeriod.TabIndex = 2;
            this.checkBoxGracePeriod.Text = "Past Grace Period?";
            this.checkBoxGracePeriod.UseVisualStyleBackColor = true;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(105, 78);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(280, 16);
            this.label3.TabIndex = 53;
            this.label3.Text = "* A blank due date selects ALL records!";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(13, 58);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(86, 16);
            this.label2.TabIndex = 52;
            this.label2.Text = "Debit Date:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(27, 27);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(72, 16);
            this.label4.TabIndex = 51;
            this.label4.Text = "Day Due:";
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
            this.comboBoxDayDue.Size = new System.Drawing.Size(45, 28);
            this.comboBoxDayDue.TabIndex = 1;
            // 
            // labelStatus
            // 
            this.labelStatus.AutoSize = true;
            this.labelStatus.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.labelStatus.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelStatus.Location = new System.Drawing.Point(18, 378);
            this.labelStatus.Name = "labelStatus";
            this.labelStatus.Size = new System.Drawing.Size(0, 16);
            this.labelStatus.TabIndex = 53;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(24, 26);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(47, 16);
            this.label5.TabIndex = 82;
            this.label5.Text = "From:";
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.label8);
            this.groupBox3.Controls.Add(this.label5);
            this.groupBox3.Controls.Add(this.nullableDateTimePickerFundingTo);
            this.groupBox3.Controls.Add(this.nullableDateTimePickerFundingFrom);
            this.groupBox3.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox3.Location = new System.Drawing.Point(30, 196);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(349, 58);
            this.groupBox3.TabIndex = 85;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Funding Date";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.Location = new System.Drawing.Point(190, 26);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(31, 16);
            this.label8.TabIndex = 83;
            this.label8.Text = "To:";
            // 
            // nullableDateTimePickerFundingTo
            // 
            this.nullableDateTimePickerFundingTo.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.nullableDateTimePickerFundingTo.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.nullableDateTimePickerFundingTo.Location = new System.Drawing.Point(222, 22);
            this.nullableDateTimePickerFundingTo.Name = "nullableDateTimePickerFundingTo";
            this.nullableDateTimePickerFundingTo.Size = new System.Drawing.Size(103, 26);
            this.nullableDateTimePickerFundingTo.TabIndex = 9;
            this.nullableDateTimePickerFundingTo.Value = new System.DateTime(2019, 12, 30, 0, 0, 0, 0);
            this.nullableDateTimePickerFundingTo.ValueChanged += new System.EventHandler(this.nullableDateTimePickerFundingTo_ValueChanged);
            // 
            // nullableDateTimePickerFundingFrom
            // 
            this.nullableDateTimePickerFundingFrom.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.nullableDateTimePickerFundingFrom.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.nullableDateTimePickerFundingFrom.Location = new System.Drawing.Point(78, 22);
            this.nullableDateTimePickerFundingFrom.Name = "nullableDateTimePickerFundingFrom";
            this.nullableDateTimePickerFundingFrom.Size = new System.Drawing.Size(103, 26);
            this.nullableDateTimePickerFundingFrom.TabIndex = 8;
            this.nullableDateTimePickerFundingFrom.Value = new System.DateTime(2019, 12, 30, 0, 0, 0, 0);
            this.nullableDateTimePickerFundingFrom.ValueChanged += new System.EventHandler(this.nullableDateTimePickerFundingFrom_ValueChanged);
            // 
            // nullableDateTimePickerContractTo
            // 
            this.nullableDateTimePickerContractTo.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.nullableDateTimePickerContractTo.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.nullableDateTimePickerContractTo.Location = new System.Drawing.Point(222, 22);
            this.nullableDateTimePickerContractTo.Name = "nullableDateTimePickerContractTo";
            this.nullableDateTimePickerContractTo.Size = new System.Drawing.Size(103, 26);
            this.nullableDateTimePickerContractTo.TabIndex = 7;
            this.nullableDateTimePickerContractTo.Value = new System.DateTime(2019, 12, 30, 0, 0, 0, 0);
            this.nullableDateTimePickerContractTo.ValueChanged += new System.EventHandler(this.nullableDateTimePickerContractTo_ValueChanged);
            // 
            // nullableDateTimePickerContractFrom
            // 
            this.nullableDateTimePickerContractFrom.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.nullableDateTimePickerContractFrom.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.nullableDateTimePickerContractFrom.Location = new System.Drawing.Point(78, 22);
            this.nullableDateTimePickerContractFrom.Name = "nullableDateTimePickerContractFrom";
            this.nullableDateTimePickerContractFrom.Size = new System.Drawing.Size(103, 26);
            this.nullableDateTimePickerContractFrom.TabIndex = 6;
            this.nullableDateTimePickerContractFrom.Value = new System.DateTime(2019, 12, 30, 0, 0, 0, 0);
            this.nullableDateTimePickerContractFrom.ValueChanged += new System.EventHandler(this.nullableDateTimePickerContractFrom_ValueChanged);
            // 
            // nullableDateTimePickerDebitDate
            // 
            this.nullableDateTimePickerDebitDate.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.nullableDateTimePickerDebitDate.Location = new System.Drawing.Point(102, 51);
            this.nullableDateTimePickerDebitDate.Name = "nullableDateTimePickerDebitDate";
            this.nullableDateTimePickerDebitDate.Size = new System.Drawing.Size(103, 26);
            this.nullableDateTimePickerDebitDate.TabIndex = 3;
            this.nullableDateTimePickerDebitDate.Value = new System.DateTime(2019, 12, 30, 0, 0, 0, 0);
            // 
            // FormBULKSMSMessage
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(438, 712);
            this.Controls.Add(this.labelStatus);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.buttonSend);
            this.Controls.Add(this.labelNote);
            this.Controls.Add(this.textBoxNote);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.textBoxMessage);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.Name = "FormBULKSMSMessage";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Bulk SMS Message";
            this.Load += new System.EventHandler(this.FormBULKSMSMessage_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nullableDateTimePickerFundingTo)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nullableDateTimePickerFundingFrom)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nullableDateTimePickerContractTo)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nullableDateTimePickerContractFrom)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nullableDateTimePickerDebitDate)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox textBoxMessage;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox textBoxNote;
        private System.Windows.Forms.Label labelNote;
        private System.Windows.Forms.Button buttonSend;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.CheckBox checkBoxGracePeriod;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label4;
        private ProManApp.NullableDateTimePicker nullableDateTimePickerDebitDate;
        private System.Windows.Forms.ComboBox comboBoxDayDue;
        private System.Windows.Forms.Label labelStatus;
        private System.Windows.Forms.CheckBox checkBoxNoEFT;
        private System.Windows.Forms.Label labelPaidThrough;
        private System.Windows.Forms.MaskedTextBox txtPaidThrough;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label6;
        private ProManApp.NullableDateTimePicker nullableDateTimePickerContractTo;
        private ProManApp.NullableDateTimePicker nullableDateTimePickerContractFrom;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label5;
        private ProManApp.NullableDateTimePicker nullableDateTimePickerFundingTo;
        private ProManApp.NullableDateTimePicker nullableDateTimePickerFundingFrom;
    }
}
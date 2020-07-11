namespace IAC2018SQL
{
    partial class GlobalCapturePDFUploader
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
            System.Windows.Forms.Label label1;
            System.Windows.Forms.Label label2;
            System.Windows.Forms.Label labelLast;
            System.Windows.Forms.Label label7;
            System.Windows.Forms.Label label53;
            System.Windows.Forms.Label label3;
            System.Windows.Forms.Label labelFudingDate;
            System.Windows.Forms.Label labelFileType;
            System.Windows.Forms.Label label4;
            this.groupBoxIndexFields = new System.Windows.Forms.GroupBox();
            this.comboBoxSide = new System.Windows.Forms.ComboBox();
            this.textBoxPageCount = new System.Windows.Forms.TextBox();
            this.textBoxFileType = new System.Windows.Forms.TextBox();
            this.nullableDateTimePickerArchivedDate = new ProManApp.NullableDateTimePicker();
            this.textBoxSSNLast4 = new System.Windows.Forms.TextBox();
            this.textBoxDealerName = new System.Windows.Forms.TextBox();
            this.textBoxDealerNo = new System.Windows.Forms.TextBox();
            this.TextBoxLastName = new System.Windows.Forms.TextBox();
            this.TextBoxFirstName = new System.Windows.Forms.TextBox();
            this.TextBoxCutomerNo = new System.Windows.Forms.TextBox();
            this.textBoxFileName = new System.Windows.Forms.TextBox();
            this.buttonImportToGlobalSearch = new System.Windows.Forms.Button();
            this.buttonSelectPDF = new System.Windows.Forms.Button();
            this.groupBoxSelectPDF = new System.Windows.Forms.GroupBox();
            label1 = new System.Windows.Forms.Label();
            label2 = new System.Windows.Forms.Label();
            labelLast = new System.Windows.Forms.Label();
            label7 = new System.Windows.Forms.Label();
            label53 = new System.Windows.Forms.Label();
            label3 = new System.Windows.Forms.Label();
            labelFudingDate = new System.Windows.Forms.Label();
            labelFileType = new System.Windows.Forms.Label();
            label4 = new System.Windows.Forms.Label();
            this.groupBoxIndexFields.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nullableDateTimePickerArchivedDate)).BeginInit();
            this.groupBoxSelectPDF.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            label1.Location = new System.Drawing.Point(65, 31);
            label1.Name = "label1";
            label1.Size = new System.Drawing.Size(104, 20);
            label1.TabIndex = 2;
            label1.Text = "CUSTOMER:";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.BackColor = System.Drawing.Color.Transparent;
            label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            label2.Location = new System.Drawing.Point(59, 64);
            label2.Name = "label2";
            label2.Size = new System.Drawing.Size(110, 20);
            label2.TabIndex = 19;
            label2.Text = "FIRST NAME:";
            // 
            // labelLast
            // 
            labelLast.AutoSize = true;
            labelLast.BackColor = System.Drawing.Color.Transparent;
            labelLast.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            labelLast.Location = new System.Drawing.Point(116, 97);
            labelLast.Name = "labelLast";
            labelLast.Size = new System.Drawing.Size(53, 20);
            labelLast.TabIndex = 101;
            labelLast.Text = "LAST:";
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Location = new System.Drawing.Point(90, 130);
            label7.Name = "label7";
            label7.Size = new System.Drawing.Size(79, 20);
            label7.TabIndex = 510;
            label7.Text = "DEALER:";
            // 
            // label53
            // 
            label53.AutoSize = true;
            label53.Location = new System.Drawing.Point(36, 163);
            label53.Name = "label53";
            label53.Size = new System.Drawing.Size(133, 20);
            label53.TabIndex = 514;
            label53.Text = "SS NUM (Last 4):";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new System.Drawing.Point(117, 196);
            label3.Name = "label3";
            label3.Size = new System.Drawing.Size(52, 20);
            label3.TabIndex = 516;
            label3.Text = "SIDE:";
            // 
            // labelFudingDate
            // 
            labelFudingDate.AutoSize = true;
            labelFudingDate.Location = new System.Drawing.Point(24, 229);
            labelFudingDate.Name = "labelFudingDate";
            labelFudingDate.Size = new System.Drawing.Size(145, 20);
            labelFudingDate.TabIndex = 518;
            labelFudingDate.Text = "ARCHIVED DATE:";
            labelFudingDate.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // labelFileType
            // 
            labelFileType.AutoSize = true;
            labelFileType.Location = new System.Drawing.Point(76, 262);
            labelFileType.Name = "labelFileType";
            labelFileType.Size = new System.Drawing.Size(93, 20);
            labelFileType.TabIndex = 520;
            labelFileType.Text = "FILE TYPE:";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new System.Drawing.Point(52, 295);
            label4.Name = "label4";
            label4.Size = new System.Drawing.Size(117, 20);
            label4.TabIndex = 522;
            label4.Text = "PAGE COUNT:";
            // 
            // groupBoxIndexFields
            // 
            this.groupBoxIndexFields.BackColor = System.Drawing.Color.LightSteelBlue;
            this.groupBoxIndexFields.Controls.Add(this.comboBoxSide);
            this.groupBoxIndexFields.Controls.Add(label4);
            this.groupBoxIndexFields.Controls.Add(this.textBoxPageCount);
            this.groupBoxIndexFields.Controls.Add(labelFileType);
            this.groupBoxIndexFields.Controls.Add(this.textBoxFileType);
            this.groupBoxIndexFields.Controls.Add(labelFudingDate);
            this.groupBoxIndexFields.Controls.Add(this.nullableDateTimePickerArchivedDate);
            this.groupBoxIndexFields.Controls.Add(label3);
            this.groupBoxIndexFields.Controls.Add(label53);
            this.groupBoxIndexFields.Controls.Add(this.textBoxSSNLast4);
            this.groupBoxIndexFields.Controls.Add(this.textBoxDealerName);
            this.groupBoxIndexFields.Controls.Add(this.textBoxDealerNo);
            this.groupBoxIndexFields.Controls.Add(label7);
            this.groupBoxIndexFields.Controls.Add(labelLast);
            this.groupBoxIndexFields.Controls.Add(this.TextBoxLastName);
            this.groupBoxIndexFields.Controls.Add(this.TextBoxFirstName);
            this.groupBoxIndexFields.Controls.Add(label2);
            this.groupBoxIndexFields.Controls.Add(this.TextBoxCutomerNo);
            this.groupBoxIndexFields.Controls.Add(label1);
            this.groupBoxIndexFields.Location = new System.Drawing.Point(106, 28);
            this.groupBoxIndexFields.Name = "groupBoxIndexFields";
            this.groupBoxIndexFields.Size = new System.Drawing.Size(512, 340);
            this.groupBoxIndexFields.TabIndex = 0;
            this.groupBoxIndexFields.TabStop = false;
            this.groupBoxIndexFields.Text = "Index Fields";
            // 
            // comboBoxSide
            // 
            this.comboBoxSide.FormattingEnabled = true;
            this.comboBoxSide.Items.AddRange(new object[] {
            "CLOSED",
            "OPEN"});
            this.comboBoxSide.Location = new System.Drawing.Point(179, 188);
            this.comboBoxSide.Name = "comboBoxSide";
            this.comboBoxSide.Size = new System.Drawing.Size(92, 28);
            this.comboBoxSide.TabIndex = 7;
            // 
            // textBoxPageCount
            // 
            this.textBoxPageCount.Enabled = false;
            this.textBoxPageCount.Location = new System.Drawing.Point(179, 289);
            this.textBoxPageCount.Name = "textBoxPageCount";
            this.textBoxPageCount.ReadOnly = true;
            this.textBoxPageCount.Size = new System.Drawing.Size(51, 26);
            this.textBoxPageCount.TabIndex = 10;
            this.textBoxPageCount.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // textBoxFileType
            // 
            this.textBoxFileType.Enabled = false;
            this.textBoxFileType.Location = new System.Drawing.Point(179, 256);
            this.textBoxFileType.Name = "textBoxFileType";
            this.textBoxFileType.ReadOnly = true;
            this.textBoxFileType.Size = new System.Drawing.Size(41, 26);
            this.textBoxFileType.TabIndex = 9;
            this.textBoxFileType.Text = ".pdf";
            this.textBoxFileType.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // nullableDateTimePickerArchivedDate
            // 
            this.nullableDateTimePickerArchivedDate.Enabled = false;
            this.nullableDateTimePickerArchivedDate.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.nullableDateTimePickerArchivedDate.Location = new System.Drawing.Point(179, 223);
            this.nullableDateTimePickerArchivedDate.Name = "nullableDateTimePickerArchivedDate";
            this.nullableDateTimePickerArchivedDate.Size = new System.Drawing.Size(119, 26);
            this.nullableDateTimePickerArchivedDate.TabIndex = 8;
            this.nullableDateTimePickerArchivedDate.Value = new System.DateTime(2020, 5, 6, 0, 0, 0, 0);
            // 
            // textBoxSSNLast4
            // 
            this.textBoxSSNLast4.Location = new System.Drawing.Point(179, 157);
            this.textBoxSSNLast4.Name = "textBoxSSNLast4";
            this.textBoxSSNLast4.Size = new System.Drawing.Size(51, 26);
            this.textBoxSSNLast4.TabIndex = 6;
            this.textBoxSSNLast4.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // textBoxDealerName
            // 
            this.textBoxDealerName.Enabled = false;
            this.textBoxDealerName.Location = new System.Drawing.Point(232, 124);
            this.textBoxDealerName.Name = "textBoxDealerName";
            this.textBoxDealerName.ReadOnly = true;
            this.textBoxDealerName.Size = new System.Drawing.Size(256, 26);
            this.textBoxDealerName.TabIndex = 5;
            // 
            // textBoxDealerNo
            // 
            this.textBoxDealerNo.Location = new System.Drawing.Point(179, 124);
            this.textBoxDealerNo.Name = "textBoxDealerNo";
            this.textBoxDealerNo.Size = new System.Drawing.Size(52, 26);
            this.textBoxDealerNo.TabIndex = 4;
            this.textBoxDealerNo.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // TextBoxLastName
            // 
            this.TextBoxLastName.AllowDrop = true;
            this.TextBoxLastName.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.TextBoxLastName.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TextBoxLastName.Location = new System.Drawing.Point(179, 91);
            this.TextBoxLastName.MaxLength = 18;
            this.TextBoxLastName.Name = "TextBoxLastName";
            this.TextBoxLastName.Size = new System.Drawing.Size(212, 26);
            this.TextBoxLastName.TabIndex = 3;
            // 
            // TextBoxFirstName
            // 
            this.TextBoxFirstName.AllowDrop = true;
            this.TextBoxFirstName.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.TextBoxFirstName.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TextBoxFirstName.ForeColor = System.Drawing.Color.Black;
            this.TextBoxFirstName.Location = new System.Drawing.Point(179, 58);
            this.TextBoxFirstName.MaxLength = 12;
            this.TextBoxFirstName.Name = "TextBoxFirstName";
            this.TextBoxFirstName.Size = new System.Drawing.Size(136, 26);
            this.TextBoxFirstName.TabIndex = 2;
            // 
            // TextBoxCutomerNo
            // 
            this.TextBoxCutomerNo.AllowDrop = true;
            this.TextBoxCutomerNo.BackColor = System.Drawing.Color.Gold;
            this.TextBoxCutomerNo.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TextBoxCutomerNo.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.TextBoxCutomerNo.Location = new System.Drawing.Point(179, 25);
            this.TextBoxCutomerNo.MaxLength = 6;
            this.TextBoxCutomerNo.Name = "TextBoxCutomerNo";
            this.TextBoxCutomerNo.Size = new System.Drawing.Size(67, 26);
            this.TextBoxCutomerNo.TabIndex = 1;
            this.TextBoxCutomerNo.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.TextBoxCutomerNo.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.TextBoxCutomerNo_KeyPress);
            this.TextBoxCutomerNo.Validated += new System.EventHandler(this.TextBoxCutomerNo_Validated);
            // 
            // textBoxFileName
            // 
            this.textBoxFileName.Enabled = false;
            this.textBoxFileName.Location = new System.Drawing.Point(10, 25);
            this.textBoxFileName.Name = "textBoxFileName";
            this.textBoxFileName.ReadOnly = true;
            this.textBoxFileName.Size = new System.Drawing.Size(618, 26);
            this.textBoxFileName.TabIndex = 12;
            // 
            // buttonImportToGlobalSearch
            // 
            this.buttonImportToGlobalSearch.Enabled = false;
            this.buttonImportToGlobalSearch.Image = global::IAC2018SQL.Properties.Resources.Import_16x;
            this.buttonImportToGlobalSearch.Location = new System.Drawing.Point(296, 478);
            this.buttonImportToGlobalSearch.Name = "buttonImportToGlobalSearch";
            this.buttonImportToGlobalSearch.Size = new System.Drawing.Size(133, 89);
            this.buttonImportToGlobalSearch.TabIndex = 14;
            this.buttonImportToGlobalSearch.Text = "Import To Global Search";
            this.buttonImportToGlobalSearch.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.buttonImportToGlobalSearch.UseVisualStyleBackColor = true;
            this.buttonImportToGlobalSearch.Click += new System.EventHandler(this.buttonImportToGlobalSearch_Click);
            // 
            // buttonSelectPDF
            // 
            this.buttonSelectPDF.Image = global::IAC2018SQL.Properties.Resources.AddFile_16x_24;
            this.buttonSelectPDF.Location = new System.Drawing.Point(634, 25);
            this.buttonSelectPDF.Name = "buttonSelectPDF";
            this.buttonSelectPDF.Size = new System.Drawing.Size(56, 34);
            this.buttonSelectPDF.TabIndex = 13;
            this.buttonSelectPDF.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.buttonSelectPDF.UseVisualStyleBackColor = true;
            this.buttonSelectPDF.Click += new System.EventHandler(this.buttonSelectPDF_Click);
            // 
            // groupBoxSelectPDF
            // 
            this.groupBoxSelectPDF.Controls.Add(this.buttonSelectPDF);
            this.groupBoxSelectPDF.Controls.Add(this.textBoxFileName);
            this.groupBoxSelectPDF.Location = new System.Drawing.Point(12, 380);
            this.groupBoxSelectPDF.Name = "groupBoxSelectPDF";
            this.groupBoxSelectPDF.Size = new System.Drawing.Size(700, 69);
            this.groupBoxSelectPDF.TabIndex = 11;
            this.groupBoxSelectPDF.TabStop = false;
            this.groupBoxSelectPDF.Text = "Select File";
            // 
            // GlobalCapturePDFUploader
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.LightSteelBlue;
            this.ClientSize = new System.Drawing.Size(724, 594);
            this.Controls.Add(this.groupBoxSelectPDF);
            this.Controls.Add(this.buttonImportToGlobalSearch);
            this.Controls.Add(this.groupBoxIndexFields);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.Name = "GlobalCapturePDFUploader";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Global Capture PDF Uploader";
            this.Load += new System.EventHandler(this.GlobalCapturePDFUploader_Load);
            this.groupBoxIndexFields.ResumeLayout(false);
            this.groupBoxIndexFields.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nullableDateTimePickerArchivedDate)).EndInit();
            this.groupBoxSelectPDF.ResumeLayout(false);
            this.groupBoxSelectPDF.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBoxIndexFields;
        private System.Windows.Forms.TextBox TextBoxCutomerNo;
        private System.Windows.Forms.TextBox TextBoxFirstName;
        private System.Windows.Forms.TextBox TextBoxLastName;
        private System.Windows.Forms.TextBox textBoxDealerName;
        private System.Windows.Forms.TextBox textBoxDealerNo;
        private System.Windows.Forms.TextBox textBoxSSNLast4;
        private ProManApp.NullableDateTimePicker nullableDateTimePickerArchivedDate;
        private System.Windows.Forms.TextBox textBoxFileType;
        private System.Windows.Forms.TextBox textBoxPageCount;
        private System.Windows.Forms.Button buttonSelectPDF;
        private System.Windows.Forms.TextBox textBoxFileName;
        private System.Windows.Forms.Button buttonImportToGlobalSearch;
        private System.Windows.Forms.GroupBox groupBoxSelectPDF;
        private System.Windows.Forms.ComboBox comboBoxSide;
    }
}
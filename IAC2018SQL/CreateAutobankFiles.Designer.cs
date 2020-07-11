namespace IAC2018SQL
{
    partial class frmCreateAutoBankFiles
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmCreateAutoBankFiles));
            this.buttonPost = new System.Windows.Forms.Button();
            this.buttonCancel = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.nullableDateTimePickerCutOffDate = new ProManApp.NullableDateTimePicker();
            this.labelBankTranDate = new System.Windows.Forms.Label();
            this.nullableDateTimePickerBsnkTranDate = new ProManApp.NullableDateTimePicker();
            this.textBoxDayDue = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.checkBoxAutobank = new System.Windows.Forms.CheckBox();
            this.buttonTransfer = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.nullableDateTimePickerCutOffDate)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nullableDateTimePickerBsnkTranDate)).BeginInit();
            this.SuspendLayout();
            // 
            // buttonPost
            // 
            this.buttonPost.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonPost.Location = new System.Drawing.Point(150, 144);
            this.buttonPost.Margin = new System.Windows.Forms.Padding(4);
            this.buttonPost.Name = "buttonPost";
            this.buttonPost.Size = new System.Drawing.Size(100, 28);
            this.buttonPost.TabIndex = 5;
            this.buttonPost.Text = "&Print / Post";
            this.buttonPost.UseVisualStyleBackColor = true;
            this.buttonPost.Click += new System.EventHandler(this.buttonPost_Click);
            // 
            // buttonCancel
            // 
            this.buttonCancel.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonCancel.Location = new System.Drawing.Point(258, 144);
            this.buttonCancel.Margin = new System.Windows.Forms.Padding(4);
            this.buttonCancel.Name = "buttonCancel";
            this.buttonCancel.Size = new System.Drawing.Size(100, 28);
            this.buttonCancel.TabIndex = 6;
            this.buttonCancel.Text = "&Cancel";
            this.buttonCancel.UseVisualStyleBackColor = true;
            this.buttonCancel.Click += new System.EventHandler(this.buttonCancel_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(117, 42);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(80, 16);
            this.label1.TabIndex = 5;
            this.label1.Text = "Cutt off date:";
            this.label1.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // nullableDateTimePickerCutOffDate
            // 
            this.nullableDateTimePickerCutOffDate.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.nullableDateTimePickerCutOffDate.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.nullableDateTimePickerCutOffDate.Location = new System.Drawing.Point(215, 36);
            this.nullableDateTimePickerCutOffDate.Margin = new System.Windows.Forms.Padding(4);
            this.nullableDateTimePickerCutOffDate.Name = "nullableDateTimePickerCutOffDate";
            this.nullableDateTimePickerCutOffDate.Size = new System.Drawing.Size(109, 22);
            this.nullableDateTimePickerCutOffDate.TabIndex = 3;
            this.nullableDateTimePickerCutOffDate.Value = new System.DateTime(2013, 6, 12, 0, 0, 0, 0);
            // 
            // labelBankTranDate
            // 
            this.labelBankTranDate.AutoSize = true;
            this.labelBankTranDate.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelBankTranDate.Location = new System.Drawing.Point(49, 101);
            this.labelBankTranDate.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.labelBankTranDate.Name = "labelBankTranDate";
            this.labelBankTranDate.Size = new System.Drawing.Size(148, 16);
            this.labelBankTranDate.TabIndex = 8;
            this.labelBankTranDate.Text = "Bank Transaction Date:";
            this.labelBankTranDate.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // nullableDateTimePickerBsnkTranDate
            // 
            this.nullableDateTimePickerBsnkTranDate.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.nullableDateTimePickerBsnkTranDate.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.nullableDateTimePickerBsnkTranDate.Location = new System.Drawing.Point(215, 94);
            this.nullableDateTimePickerBsnkTranDate.Margin = new System.Windows.Forms.Padding(4);
            this.nullableDateTimePickerBsnkTranDate.Name = "nullableDateTimePickerBsnkTranDate";
            this.nullableDateTimePickerBsnkTranDate.Size = new System.Drawing.Size(109, 22);
            this.nullableDateTimePickerBsnkTranDate.TabIndex = 7;
            this.nullableDateTimePickerBsnkTranDate.Value = new System.DateTime(2013, 6, 12, 0, 0, 0, 0);
            // 
            // textBoxDayDue
            // 
            this.textBoxDayDue.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBoxDayDue.Location = new System.Drawing.Point(214, 64);
            this.textBoxDayDue.Margin = new System.Windows.Forms.Padding(4);
            this.textBoxDayDue.MaxLength = 2;
            this.textBoxDayDue.Name = "textBoxDayDue";
            this.textBoxDayDue.Size = new System.Drawing.Size(33, 22);
            this.textBoxDayDue.TabIndex = 9;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(132, 70);
            this.label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(64, 16);
            this.label3.TabIndex = 10;
            this.label3.Text = "Due Day:";
            this.label3.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // checkBoxAutobank
            // 
            this.checkBoxAutobank.AutoSize = true;
            this.checkBoxAutobank.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.checkBoxAutobank.Location = new System.Drawing.Point(274, 66);
            this.checkBoxAutobank.Margin = new System.Windows.Forms.Padding(4);
            this.checkBoxAutobank.Name = "checkBoxAutobank";
            this.checkBoxAutobank.Size = new System.Drawing.Size(169, 20);
            this.checkBoxAutobank.TabIndex = 11;
            this.checkBoxAutobank.Text = "Create AUTOBANK File";
            this.checkBoxAutobank.UseVisualStyleBackColor = true;
            this.checkBoxAutobank.CheckedChanged += new System.EventHandler(this.checkBoxAutobank_CheckedChanged);
            // 
            // buttonTransfer
            // 
            this.buttonTransfer.Image = ((System.Drawing.Image)(resources.GetObject("buttonTransfer.Image")));
            this.buttonTransfer.Location = new System.Drawing.Point(379, 94);
            this.buttonTransfer.Name = "buttonTransfer";
            this.buttonTransfer.Size = new System.Drawing.Size(110, 103);
            this.buttonTransfer.TabIndex = 12;
            this.buttonTransfer.Text = "&Transfer Payments";
            this.buttonTransfer.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.buttonTransfer.UseVisualStyleBackColor = true;
            this.buttonTransfer.Click += new System.EventHandler(this.buttonTransfer_Click);
            // 
            // frmCreateAutoBankFiles
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.BackColor = System.Drawing.Color.LightSteelBlue;
            this.ClientSize = new System.Drawing.Size(539, 209);
            this.Controls.Add(this.buttonTransfer);
            this.Controls.Add(this.checkBoxAutobank);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.textBoxDayDue);
            this.Controls.Add(this.labelBankTranDate);
            this.Controls.Add(this.nullableDateTimePickerBsnkTranDate);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.nullableDateTimePickerCutOffDate);
            this.Controls.Add(this.buttonCancel);
            this.Controls.Add(this.buttonPost);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "frmCreateAutoBankFiles";
            this.Text = "Create EFT Files / Reports";
            this.Load += new System.EventHandler(this.frmCreateAutoBankFiles_Load);
            ((System.ComponentModel.ISupportInitialize)(this.nullableDateTimePickerCutOffDate)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nullableDateTimePickerBsnkTranDate)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button buttonPost;
        private System.Windows.Forms.Button buttonCancel;
        private System.Windows.Forms.Label label1;
        private ProManApp.NullableDateTimePicker nullableDateTimePickerCutOffDate;
        private System.Windows.Forms.Label labelBankTranDate;
        private ProManApp.NullableDateTimePicker nullableDateTimePickerBsnkTranDate;
        private System.Windows.Forms.TextBox textBoxDayDue;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.CheckBox checkBoxAutobank;
        private System.Windows.Forms.Button buttonTransfer;
    }
}
namespace IAC2018SQL
{
    partial class frmCreateTSBExtract
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmCreateTSBExtract));
            this.label1 = new System.Windows.Forms.Label();
            this.nullableDateTimePickerControlDate = new ProManApp.NullableDateTimePicker();
            this.checkBoxCreateBoth = new System.Windows.Forms.CheckBox();
            this.buttonTransfer = new System.Windows.Forms.Button();
            this.nullableDateTimePickerFrom = new ProManApp.NullableDateTimePicker();
            this.nullableDateTimePickerTo = new ProManApp.NullableDateTimePicker();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.checkBoxIgnoreBureauSwitch = new System.Windows.Forms.CheckBox();
            this.buttonCancel = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.nullableDateTimePickerControlDate)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nullableDateTimePickerFrom)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nullableDateTimePickerTo)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(109, 30);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(85, 16);
            this.label1.TabIndex = 5;
            this.label1.Text = "Control Date:";
            this.label1.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // nullableDateTimePickerControlDate
            // 
            this.nullableDateTimePickerControlDate.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.nullableDateTimePickerControlDate.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.nullableDateTimePickerControlDate.Location = new System.Drawing.Point(207, 24);
            this.nullableDateTimePickerControlDate.Margin = new System.Windows.Forms.Padding(4);
            this.nullableDateTimePickerControlDate.Name = "nullableDateTimePickerControlDate";
            this.nullableDateTimePickerControlDate.Size = new System.Drawing.Size(109, 22);
            this.nullableDateTimePickerControlDate.TabIndex = 3;
            this.nullableDateTimePickerControlDate.Value = new System.DateTime(2013, 6, 12, 0, 0, 0, 0);
            // 
            // checkBoxCreateBoth
            // 
            this.checkBoxCreateBoth.AutoSize = true;
            this.checkBoxCreateBoth.Checked = true;
            this.checkBoxCreateBoth.CheckState = System.Windows.Forms.CheckState.Checked;
            this.checkBoxCreateBoth.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.checkBoxCreateBoth.Location = new System.Drawing.Point(67, 121);
            this.checkBoxCreateBoth.Margin = new System.Windows.Forms.Padding(4);
            this.checkBoxCreateBoth.Name = "checkBoxCreateBoth";
            this.checkBoxCreateBoth.Size = new System.Drawing.Size(290, 20);
            this.checkBoxCreateBoth.TabIndex = 11;
            this.checkBoxCreateBoth.Text = "Create Extract, Report, and new Control Date";
            this.checkBoxCreateBoth.UseVisualStyleBackColor = true;
            // 
            // buttonTransfer
            // 
            this.buttonTransfer.Image = ((System.Drawing.Image)(resources.GetObject("buttonTransfer.Image")));
            this.buttonTransfer.Location = new System.Drawing.Point(99, 177);
            this.buttonTransfer.Name = "buttonTransfer";
            this.buttonTransfer.Size = new System.Drawing.Size(110, 103);
            this.buttonTransfer.TabIndex = 12;
            this.buttonTransfer.Text = "&Transfer Payments";
            this.buttonTransfer.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.buttonTransfer.UseVisualStyleBackColor = true;
            this.buttonTransfer.Click += new System.EventHandler(this.buttonTransfer_Click);
            // 
            // nullableDateTimePickerFrom
            // 
            this.nullableDateTimePickerFrom.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.nullableDateTimePickerFrom.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.nullableDateTimePickerFrom.Location = new System.Drawing.Point(207, 54);
            this.nullableDateTimePickerFrom.Margin = new System.Windows.Forms.Padding(4);
            this.nullableDateTimePickerFrom.Name = "nullableDateTimePickerFrom";
            this.nullableDateTimePickerFrom.Size = new System.Drawing.Size(109, 22);
            this.nullableDateTimePickerFrom.TabIndex = 13;
            this.nullableDateTimePickerFrom.Value = new System.DateTime(2013, 6, 12, 0, 0, 0, 0);
            // 
            // nullableDateTimePickerTo
            // 
            this.nullableDateTimePickerTo.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.nullableDateTimePickerTo.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.nullableDateTimePickerTo.Location = new System.Drawing.Point(207, 84);
            this.nullableDateTimePickerTo.Margin = new System.Windows.Forms.Padding(4);
            this.nullableDateTimePickerTo.Name = "nullableDateTimePickerTo";
            this.nullableDateTimePickerTo.Size = new System.Drawing.Size(109, 22);
            this.nullableDateTimePickerTo.TabIndex = 14;
            this.nullableDateTimePickerTo.Value = new System.DateTime(2013, 6, 12, 0, 0, 0, 0);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(152, 60);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(42, 16);
            this.label2.TabIndex = 15;
            this.label2.Text = "From:";
            this.label2.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(166, 90);
            this.label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(28, 16);
            this.label3.TabIndex = 16;
            this.label3.Text = "To:";
            this.label3.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // checkBoxIgnoreBureauSwitch
            // 
            this.checkBoxIgnoreBureauSwitch.AutoSize = true;
            this.checkBoxIgnoreBureauSwitch.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.checkBoxIgnoreBureauSwitch.Location = new System.Drawing.Point(67, 143);
            this.checkBoxIgnoreBureauSwitch.Margin = new System.Windows.Forms.Padding(4);
            this.checkBoxIgnoreBureauSwitch.Name = "checkBoxIgnoreBureauSwitch";
            this.checkBoxIgnoreBureauSwitch.Size = new System.Drawing.Size(198, 20);
            this.checkBoxIgnoreBureauSwitch.TabIndex = 17;
            this.checkBoxIgnoreBureauSwitch.Text = "Ignore \"Credit Bureau\" switch";
            this.checkBoxIgnoreBureauSwitch.UseVisualStyleBackColor = true;
            // 
            // buttonCancel
            // 
            this.buttonCancel.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonCancel.Image = ((System.Drawing.Image)(resources.GetObject("buttonCancel.Image")));
            this.buttonCancel.Location = new System.Drawing.Point(216, 177);
            this.buttonCancel.Margin = new System.Windows.Forms.Padding(4);
            this.buttonCancel.Name = "buttonCancel";
            this.buttonCancel.Size = new System.Drawing.Size(110, 103);
            this.buttonCancel.TabIndex = 18;
            this.buttonCancel.Text = "&Cancel";
            this.buttonCancel.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.buttonCancel.UseVisualStyleBackColor = true;
            // 
            // frmCreateTSBExtract
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.BackColor = System.Drawing.Color.LightSteelBlue;
            this.ClientSize = new System.Drawing.Size(425, 304);
            this.Controls.Add(this.buttonCancel);
            this.Controls.Add(this.checkBoxIgnoreBureauSwitch);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.nullableDateTimePickerTo);
            this.Controls.Add(this.nullableDateTimePickerFrom);
            this.Controls.Add(this.buttonTransfer);
            this.Controls.Add(this.checkBoxCreateBoth);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.nullableDateTimePickerControlDate);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "frmCreateTSBExtract";
            this.Text = "Create TSB Extract / Reports";
            this.Load += new System.EventHandler(this.frmCreateTSBExtract_Load);
            ((System.ComponentModel.ISupportInitialize)(this.nullableDateTimePickerControlDate)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nullableDateTimePickerFrom)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nullableDateTimePickerTo)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private ProManApp.NullableDateTimePicker nullableDateTimePickerControlDate;
        private System.Windows.Forms.CheckBox checkBoxCreateBoth;
        private System.Windows.Forms.Button buttonTransfer;
        private ProManApp.NullableDateTimePicker nullableDateTimePickerFrom;
        private ProManApp.NullableDateTimePicker nullableDateTimePickerTo;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.CheckBox checkBoxIgnoreBureauSwitch;
        private System.Windows.Forms.Button buttonCancel;
    }
}
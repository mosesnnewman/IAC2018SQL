namespace IAC2018SQL
{
    partial class ClosedOverPaymentReport
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ClosedOverPaymentReport));
            this.groupBoxDateSelection = new System.Windows.Forms.GroupBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.buttonCancel = new System.Windows.Forms.Button();
            this.buttonExcel = new System.Windows.Forms.Button();
            this.nullableDateTimePickerFrom = new ProManApp.NullableDateTimePicker();
            this.nullableDateTimePickerTo = new ProManApp.NullableDateTimePicker();
            this.groupBoxDateSelection.SuspendLayout();
            this.groupBox3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nullableDateTimePickerFrom)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nullableDateTimePickerTo)).BeginInit();
            this.SuspendLayout();
            // 
            // groupBoxDateSelection
            // 
            this.groupBoxDateSelection.Controls.Add(this.label2);
            this.groupBoxDateSelection.Controls.Add(this.label1);
            this.groupBoxDateSelection.Controls.Add(this.nullableDateTimePickerFrom);
            this.groupBoxDateSelection.Controls.Add(this.nullableDateTimePickerTo);
            this.groupBoxDateSelection.Location = new System.Drawing.Point(154, 20);
            this.groupBoxDateSelection.Name = "groupBoxDateSelection";
            this.groupBoxDateSelection.Size = new System.Drawing.Size(212, 108);
            this.groupBoxDateSelection.TabIndex = 2;
            this.groupBoxDateSelection.TabStop = false;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(41, 68);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(28, 21);
            this.label2.TabIndex = 16;
            this.label2.Text = "To:";
            this.label2.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(22, 17);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(50, 21);
            this.label1.TabIndex = 15;
            this.label1.Text = "From:";
            this.label1.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.buttonExcel);
            this.groupBox3.Controls.Add(this.buttonCancel);
            this.groupBox3.Location = new System.Drawing.Point(45, 145);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(431, 189);
            this.groupBox3.TabIndex = 18;
            this.groupBox3.TabStop = false;
            // 
            // buttonCancel
            // 
            this.buttonCancel.Image = ((System.Drawing.Image)(resources.GetObject("buttonCancel.Image")));
            this.buttonCancel.Location = new System.Drawing.Point(256, 27);
            this.buttonCancel.Margin = new System.Windows.Forms.Padding(6);
            this.buttonCancel.Name = "buttonCancel";
            this.buttonCancel.Size = new System.Drawing.Size(138, 135);
            this.buttonCancel.TabIndex = 19;
            this.buttonCancel.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.buttonCancel.UseVisualStyleBackColor = true;
            this.buttonCancel.Click += new System.EventHandler(this.buttonCancel_Click);
            // 
            // buttonExcel
            // 
            this.buttonExcel.Image = global::IAC2018SQL.Properties.Resources.ExportToExcel_64x;
            this.buttonExcel.Location = new System.Drawing.Point(37, 27);
            this.buttonExcel.Name = "buttonExcel";
            this.buttonExcel.Size = new System.Drawing.Size(138, 135);
            this.buttonExcel.TabIndex = 20;
            this.buttonExcel.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.buttonExcel.UseVisualStyleBackColor = true;
            this.buttonExcel.Click += new System.EventHandler(this.buttonExcel_Click);
            // 
            // nullableDateTimePickerFrom
            // 
            this.nullableDateTimePickerFrom.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.nullableDateTimePickerFrom.Location = new System.Drawing.Point(80, 16);
            this.nullableDateTimePickerFrom.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.nullableDateTimePickerFrom.Name = "nullableDateTimePickerFrom";
            this.nullableDateTimePickerFrom.Size = new System.Drawing.Size(111, 29);
            this.nullableDateTimePickerFrom.TabIndex = 2;
            this.nullableDateTimePickerFrom.Value = new System.DateTime(2020, 7, 22, 0, 0, 0, 0);
            // 
            // nullableDateTimePickerTo
            // 
            this.nullableDateTimePickerTo.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.nullableDateTimePickerTo.Location = new System.Drawing.Point(80, 67);
            this.nullableDateTimePickerTo.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.nullableDateTimePickerTo.Name = "nullableDateTimePickerTo";
            this.nullableDateTimePickerTo.Size = new System.Drawing.Size(111, 29);
            this.nullableDateTimePickerTo.TabIndex = 3;
            this.nullableDateTimePickerTo.Value = new System.DateTime(2020, 7, 22, 0, 0, 0, 0);
            // 
            // ClosedOverPaymentReport
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 21F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.LightSteelBlue;
            this.ClientSize = new System.Drawing.Size(521, 354);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBoxDateSelection);
            this.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.Name = "ClosedOverPaymentReport";
            this.Text = "Overpayment Report";
            this.Load += new System.EventHandler(this.ClosedOverPaymentReport_Load);
            this.groupBoxDateSelection.ResumeLayout(false);
            this.groupBoxDateSelection.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.nullableDateTimePickerFrom)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nullableDateTimePickerTo)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBoxDateSelection;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private ProManApp.NullableDateTimePicker nullableDateTimePickerFrom;
        private ProManApp.NullableDateTimePicker nullableDateTimePickerTo;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.Button buttonCancel;
        public System.Windows.Forms.Button buttonExcel;
    }
}
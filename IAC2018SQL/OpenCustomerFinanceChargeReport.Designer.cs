namespace IAC2021SQL
{
    partial class frmOpenCustomerFinanceChargeReport
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
            this.buttonPost = new System.Windows.Forms.Button();
            this.buttonCancel = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.StatementDatenullableDateTimePicker = new ProManApp.NullableDateTimePicker();
            this.SuspendLayout();
            // 
            // buttonPost
            // 
            this.buttonPost.Location = new System.Drawing.Point(111, 68);
            this.buttonPost.Name = "buttonPost";
            this.buttonPost.Size = new System.Drawing.Size(75, 23);
            this.buttonPost.TabIndex = 5;
            this.buttonPost.Text = "&Print";
            this.buttonPost.UseVisualStyleBackColor = true;
            this.buttonPost.Click += new System.EventHandler(this.buttonPost_Click);
            // 
            // buttonCancel
            // 
            this.buttonCancel.Location = new System.Drawing.Point(192, 68);
            this.buttonCancel.Name = "buttonCancel";
            this.buttonCancel.Size = new System.Drawing.Size(75, 23);
            this.buttonCancel.TabIndex = 6;
            this.buttonCancel.Text = "&Cancel";
            this.buttonCancel.UseVisualStyleBackColor = true;
            this.buttonCancel.Click += new System.EventHandler(this.buttonCancel_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(86, 37);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(110, 13);
            this.label1.TabIndex = 5;
            this.label1.Text = "Statement DUE Date:";
            this.label1.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // StatementDatenullableDateTimePicker
            // 
            this.StatementDatenullableDateTimePicker.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.StatementDatenullableDateTimePicker.Location = new System.Drawing.Point(209, 28);
            this.StatementDatenullableDateTimePicker.Name = "StatementDatenullableDateTimePicker";
            this.StatementDatenullableDateTimePicker.Size = new System.Drawing.Size(83, 20);
            this.StatementDatenullableDateTimePicker.TabIndex = 3;
            this.StatementDatenullableDateTimePicker.Value = new System.DateTime(2013, 8, 27, 0, 0, 0, 0);
            // 
            // frmOpenCustomerFinanceChargeReport
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.BackColor = System.Drawing.Color.LightSteelBlue;
            this.ClientSize = new System.Drawing.Size(379, 118);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.StatementDatenullableDateTimePicker);
            this.Controls.Add(this.buttonCancel);
            this.Controls.Add(this.buttonPost);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Name = "frmOpenCustomerFinanceChargeReport";
            this.Text = "Open Customer Finance Charge Report";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button buttonPost;
        private System.Windows.Forms.Button buttonCancel;
        private System.Windows.Forms.Label label1;
        private ProManApp.NullableDateTimePicker StatementDatenullableDateTimePicker;
    }
}
namespace IAC2018SQL
{
    partial class FormUnlock
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
            this.textBoxCustomerNo = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.listBoxOpenClose = new System.Windows.Forms.ListBox();
            this.buttonUnlock = new System.Windows.Forms.Button();
            this.buttonCancel = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // textBoxCustomerNo
            // 
            this.textBoxCustomerNo.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBoxCustomerNo.Location = new System.Drawing.Point(158, 61);
            this.textBoxCustomerNo.MaxLength = 6;
            this.textBoxCustomerNo.Name = "textBoxCustomerNo";
            this.textBoxCustomerNo.Size = new System.Drawing.Size(83, 22);
            this.textBoxCustomerNo.TabIndex = 0;
            this.textBoxCustomerNo.Validated += new System.EventHandler(this.textBoxCustomerNo_Validated);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(51, 64);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(85, 16);
            this.label1.TabIndex = 1;
            this.label1.Text = "Customer#:";
            // 
            // listBoxOpenClose
            // 
            this.listBoxOpenClose.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.listBoxOpenClose.FormattingEnabled = true;
            this.listBoxOpenClose.ItemHeight = 16;
            this.listBoxOpenClose.Items.AddRange(new object[] {
            "Closed End",
            "Open End"});
            this.listBoxOpenClose.Location = new System.Drawing.Point(100, 100);
            this.listBoxOpenClose.Name = "listBoxOpenClose";
            this.listBoxOpenClose.Size = new System.Drawing.Size(95, 52);
            this.listBoxOpenClose.TabIndex = 2;
            this.listBoxOpenClose.SelectedIndexChanged += new System.EventHandler(this.listBoxOpenClose_SelectedIndexChanged);
            // 
            // buttonUnlock
            // 
            this.buttonUnlock.Location = new System.Drawing.Point(75, 188);
            this.buttonUnlock.Name = "buttonUnlock";
            this.buttonUnlock.Size = new System.Drawing.Size(75, 23);
            this.buttonUnlock.TabIndex = 3;
            this.buttonUnlock.Text = "&Unlock";
            this.buttonUnlock.UseVisualStyleBackColor = true;
            this.buttonUnlock.Click += new System.EventHandler(this.buttonUnlock_Click);
            // 
            // buttonCancel
            // 
            this.buttonCancel.Location = new System.Drawing.Point(166, 188);
            this.buttonCancel.Name = "buttonCancel";
            this.buttonCancel.Size = new System.Drawing.Size(75, 23);
            this.buttonCancel.TabIndex = 4;
            this.buttonCancel.Text = "&Cancel";
            this.buttonCancel.UseVisualStyleBackColor = true;
            this.buttonCancel.Click += new System.EventHandler(this.buttonCancel_Click);
            // 
            // FormUnlock
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(292, 273);
            this.Controls.Add(this.buttonCancel);
            this.Controls.Add(this.buttonUnlock);
            this.Controls.Add(this.listBoxOpenClose);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.textBoxCustomerNo);
            this.Name = "FormUnlock";
            this.Text = "Unlock Customers";
            this.Load += new System.EventHandler(this.FormUnlock_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox textBoxCustomerNo;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ListBox listBoxOpenClose;
        private System.Windows.Forms.Button buttonUnlock;
        private System.Windows.Forms.Button buttonCancel;
    }
}
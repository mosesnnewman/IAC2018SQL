namespace IAC2018SQL
{
    partial class FixPaidThroughs
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
            this.buttonDoIt = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.cUSTOMER_NOTextBox = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // buttonDoIt
            // 
            this.buttonDoIt.Location = new System.Drawing.Point(361, 177);
            this.buttonDoIt.Margin = new System.Windows.Forms.Padding(4);
            this.buttonDoIt.Name = "buttonDoIt";
            this.buttonDoIt.Size = new System.Drawing.Size(100, 66);
            this.buttonDoIt.TabIndex = 0;
            this.buttonDoIt.Text = "&DoIt";
            this.buttonDoIt.UseVisualStyleBackColor = true;
            this.buttonDoIt.Click += new System.EventHandler(this.buttonDoIt_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(93, 30);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(45, 16);
            this.label1.TabIndex = 1;
            this.label1.Text = "label1";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(314, 112);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(119, 16);
            this.label2.TabIndex = 3;
            this.label2.Text = "Customer Number:";
            // 
            // cUSTOMER_NOTextBox
            // 
            this.cUSTOMER_NOTextBox.AllowDrop = true;
            this.cUSTOMER_NOTextBox.BackColor = System.Drawing.Color.Gold;
            this.cUSTOMER_NOTextBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cUSTOMER_NOTextBox.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.cUSTOMER_NOTextBox.Location = new System.Drawing.Point(439, 106);
            this.cUSTOMER_NOTextBox.MaxLength = 6;
            this.cUSTOMER_NOTextBox.Name = "cUSTOMER_NOTextBox";
            this.cUSTOMER_NOTextBox.Size = new System.Drawing.Size(67, 26);
            this.cUSTOMER_NOTextBox.TabIndex = 4;
            this.cUSTOMER_NOTextBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.cUSTOMER_NOTextBox.Validated += new System.EventHandler(this.cUSTOMER_NOTextBox_Validated);
            // 
            // FixPaidThroughs
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(821, 336);
            this.Controls.Add(this.cUSTOMER_NOTextBox);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.buttonDoIt);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "FixPaidThroughs";
            this.Text = "Fix Paid Throughs Utility";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button buttonDoIt;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox cUSTOMER_NOTextBox;
    }
}
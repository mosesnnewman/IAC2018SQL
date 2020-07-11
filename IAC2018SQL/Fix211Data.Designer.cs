namespace IAC2018SQL
{
    partial class frmFix211Data
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
            this.buttonRecalc = new System.Windows.Forms.Button();
            this.buttonCancel = new System.Windows.Forms.Button();
            this.labelDisplay = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // buttonRecalc
            // 
            this.buttonRecalc.Location = new System.Drawing.Point(59, 181);
            this.buttonRecalc.Name = "buttonRecalc";
            this.buttonRecalc.Size = new System.Drawing.Size(75, 23);
            this.buttonRecalc.TabIndex = 0;
            this.buttonRecalc.Text = "&Recalc";
            this.buttonRecalc.UseVisualStyleBackColor = true;
            this.buttonRecalc.Click += new System.EventHandler(this.buttonRecalc_Click);
            // 
            // buttonCancel
            // 
            this.buttonCancel.Location = new System.Drawing.Point(159, 181);
            this.buttonCancel.Name = "buttonCancel";
            this.buttonCancel.Size = new System.Drawing.Size(75, 23);
            this.buttonCancel.TabIndex = 1;
            this.buttonCancel.Text = "&Cancel";
            this.buttonCancel.UseVisualStyleBackColor = true;
            this.buttonCancel.Click += new System.EventHandler(this.buttonCancel_Click);
            // 
            // labelDisplay
            // 
            this.labelDisplay.AutoSize = true;
            this.labelDisplay.Location = new System.Drawing.Point(12, 18);
            this.labelDisplay.Name = "labelDisplay";
            this.labelDisplay.Size = new System.Drawing.Size(0, 13);
            this.labelDisplay.TabIndex = 3;
            // 
            // frmFix211Data
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(292, 273);
            this.Controls.Add(this.labelDisplay);
            this.Controls.Add(this.buttonCancel);
            this.Controls.Add(this.buttonRecalc);
            this.Name = "frmFix211Data";
            this.Text = "Recalc Masthist OLoans";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button buttonRecalc;
        private System.Windows.Forms.Button buttonCancel;
        private System.Windows.Forms.Label labelDisplay;
    }
}
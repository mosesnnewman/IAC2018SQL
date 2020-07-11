namespace IAC2018SQL
{
    partial class FormFixCreateDate
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
            this.labelOuput = new System.Windows.Forms.Label();
            this.progressBarProgress = new System.Windows.Forms.ProgressBar();
            this.buttonUpdate = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // labelOuput
            // 
            this.labelOuput.AutoSize = true;
            this.labelOuput.Location = new System.Drawing.Point(36, 87);
            this.labelOuput.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.labelOuput.Name = "labelOuput";
            this.labelOuput.Size = new System.Drawing.Size(0, 16);
            this.labelOuput.TabIndex = 0;
            // 
            // progressBarProgress
            // 
            this.progressBarProgress.Location = new System.Drawing.Point(17, 128);
            this.progressBarProgress.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.progressBarProgress.Name = "progressBarProgress";
            this.progressBarProgress.Size = new System.Drawing.Size(721, 53);
            this.progressBarProgress.Style = System.Windows.Forms.ProgressBarStyle.Continuous;
            this.progressBarProgress.TabIndex = 1;
            // 
            // buttonUpdate
            // 
            this.buttonUpdate.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonUpdate.Location = new System.Drawing.Point(268, 207);
            this.buttonUpdate.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.buttonUpdate.Name = "buttonUpdate";
            this.buttonUpdate.Size = new System.Drawing.Size(219, 82);
            this.buttonUpdate.TabIndex = 2;
            this.buttonUpdate.Text = "Update Create Date";
            this.buttonUpdate.UseVisualStyleBackColor = true;
            this.buttonUpdate.Click += new System.EventHandler(this.buttonUpdate_Click);
            // 
            // FormFixCreateDate
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(756, 377);
            this.Controls.Add(this.buttonUpdate);
            this.Controls.Add(this.progressBarProgress);
            this.Controls.Add(this.labelOuput);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.Name = "FormFixCreateDate";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Update Attachment Date To Create Date";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label labelOuput;
        private System.Windows.Forms.ProgressBar progressBarProgress;
        private System.Windows.Forms.Button buttonUpdate;
    }
}
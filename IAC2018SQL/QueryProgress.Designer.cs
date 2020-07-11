namespace IAC2018SQL
{
    partial class QueryProgress
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
            this.QueryprogressBar = new System.Windows.Forms.ProgressBar();
            this.lblProgress = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // QueryprogressBar
            // 
            this.QueryprogressBar.ForeColor = System.Drawing.Color.Lime;
            this.QueryprogressBar.Location = new System.Drawing.Point(19, 82);
            this.QueryprogressBar.Name = "QueryprogressBar";
            this.QueryprogressBar.Size = new System.Drawing.Size(355, 23);
            this.QueryprogressBar.Style = System.Windows.Forms.ProgressBarStyle.Continuous;
            this.QueryprogressBar.TabIndex = 0;
            // 
            // lblProgress
            // 
            this.lblProgress.AutoSize = true;
            this.lblProgress.Location = new System.Drawing.Point(19, 38);
            this.lblProgress.Name = "lblProgress";
            this.lblProgress.Size = new System.Drawing.Size(0, 13);
            this.lblProgress.TabIndex = 1;
            // 
            // QueryProgress
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.BackColor = System.Drawing.Color.LightSteelBlue;
            this.ClientSize = new System.Drawing.Size(392, 118);
            this.Controls.Add(this.lblProgress);
            this.Controls.Add(this.QueryprogressBar);
            this.Name = "QueryProgress";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Progress";
            this.Load += new System.EventHandler(this.QueryProgress_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        public System.Windows.Forms.ProgressBar QueryprogressBar;
        public System.Windows.Forms.Label lblProgress;
    }
}
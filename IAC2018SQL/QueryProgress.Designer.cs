namespace IAC2021SQL
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
            this.QueryprogressBar = new DevExpress.XtraEditors.ProgressBarControl();
            this.lblProgress = new DevExpress.XtraEditors.LabelControl();
            this.groupControl1 = new DevExpress.XtraEditors.GroupControl();
            ((System.ComponentModel.ISupportInitialize)(this.QueryprogressBar.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl1)).BeginInit();
            this.groupControl1.SuspendLayout();
            this.SuspendLayout();
            // 
            // QueryprogressBar
            // 
            this.QueryprogressBar.Location = new System.Drawing.Point(17, 80);
            this.QueryprogressBar.Name = "QueryprogressBar";
            this.QueryprogressBar.Properties.Appearance.ForeColor = System.Drawing.Color.Lime;
            this.QueryprogressBar.Properties.LookAndFeel.SkinName = "McSkin";
            this.QueryprogressBar.Properties.LookAndFeel.UseDefaultLookAndFeel = false;
            this.QueryprogressBar.Size = new System.Drawing.Size(355, 23);
            this.QueryprogressBar.TabIndex = 0;
            // 
            // lblProgress
            // 
            this.lblProgress.Appearance.Options.UseTextOptions = true;
            this.lblProgress.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Near;
            this.lblProgress.Appearance.TextOptions.Trimming = DevExpress.Utils.Trimming.None;
            this.lblProgress.Appearance.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Top;
            this.lblProgress.Appearance.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap;
            this.lblProgress.AutoSizeMode = DevExpress.XtraEditors.LabelAutoSizeMode.Vertical;
            this.lblProgress.Location = new System.Drawing.Point(15, 14);
            this.lblProgress.LookAndFeel.SkinName = "McSkin";
            this.lblProgress.LookAndFeel.UseDefaultLookAndFeel = false;
            this.lblProgress.Name = "lblProgress";
            this.lblProgress.Size = new System.Drawing.Size(370, 0);
            this.lblProgress.TabIndex = 1;
            // 
            // groupControl1
            // 
            this.groupControl1.Appearance.BackColor = System.Drawing.Color.LightSteelBlue;
            this.groupControl1.Appearance.Options.UseBackColor = true;
            this.groupControl1.AutoSize = true;
            this.groupControl1.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            this.groupControl1.Controls.Add(this.QueryprogressBar);
            this.groupControl1.Controls.Add(this.lblProgress);
            this.groupControl1.Location = new System.Drawing.Point(-2, -2);
            this.groupControl1.Name = "groupControl1";
            this.groupControl1.Size = new System.Drawing.Size(395, 120);
            this.groupControl1.TabIndex = 2;
            // 
            // QueryProgress
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.ClientSize = new System.Drawing.Size(392, 118);
            this.Controls.Add(this.groupControl1);
            this.Name = "QueryProgress";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Progress";
            this.Load += new System.EventHandler(this.QueryProgress_Load);
            ((System.ComponentModel.ISupportInitialize)(this.QueryprogressBar.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl1)).EndInit();
            this.groupControl1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        public DevExpress.XtraEditors.ProgressBarControl QueryprogressBar;
        public DevExpress.XtraEditors.LabelControl lblProgress;
        private DevExpress.XtraEditors.GroupControl groupControl1;
    }
}
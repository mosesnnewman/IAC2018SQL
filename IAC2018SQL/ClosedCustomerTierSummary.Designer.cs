namespace IAC2021SQL
{
    partial class ClosedCustomerTierSummary
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
            this.buttonPrint = new DevExpress.XtraEditors.SimpleButton();
            this.buttonCancel = new DevExpress.XtraEditors.SimpleButton();
            this.groupControlTierSummary = new DevExpress.XtraEditors.GroupControl();
            ((System.ComponentModel.ISupportInitialize)(this.groupControlTierSummary)).BeginInit();
            this.groupControlTierSummary.SuspendLayout();
            this.SuspendLayout();
            // 
            // buttonPrint
            // 
            this.buttonPrint.Appearance.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonPrint.Appearance.Options.UseFont = true;
            this.buttonPrint.Location = new System.Drawing.Point(102, 81);
            this.buttonPrint.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.buttonPrint.Name = "buttonPrint";
            this.buttonPrint.Size = new System.Drawing.Size(112, 35);
            this.buttonPrint.TabIndex = 0;
            this.buttonPrint.Text = "&Print";
            this.buttonPrint.Click += new System.EventHandler(this.buttonPrint_Click);
            // 
            // buttonCancel
            // 
            this.buttonCancel.Appearance.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonCancel.Appearance.Options.UseFont = true;
            this.buttonCancel.Location = new System.Drawing.Point(258, 81);
            this.buttonCancel.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.buttonCancel.Name = "buttonCancel";
            this.buttonCancel.Size = new System.Drawing.Size(112, 35);
            this.buttonCancel.TabIndex = 1;
            this.buttonCancel.Text = "&Cancel";
            this.buttonCancel.Click += new System.EventHandler(this.buttonCancel_Click);
            // 
            // groupControlTierSummary
            // 
            this.groupControlTierSummary.Appearance.BackColor = System.Drawing.Color.LightSteelBlue;
            this.groupControlTierSummary.Appearance.Options.UseBackColor = true;
            this.groupControlTierSummary.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            this.groupControlTierSummary.Controls.Add(this.buttonCancel);
            this.groupControlTierSummary.Controls.Add(this.buttonPrint);
            this.groupControlTierSummary.Location = new System.Drawing.Point(-1, -1);
            this.groupControlTierSummary.Name = "groupControlTierSummary";
            this.groupControlTierSummary.Size = new System.Drawing.Size(473, 202);
            this.groupControlTierSummary.TabIndex = 2;
            this.groupControlTierSummary.Text = "groupControl1";
            // 
            // ClosedCustomerTierSummary
            // 
            this.Appearance.Options.UseFont = true;
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(471, 199);
            this.Controls.Add(this.groupControlTierSummary);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.Name = "ClosedCustomerTierSummary";
            this.Text = "Print Closed Customer Tier Summary Report";
            ((System.ComponentModel.ISupportInitialize)(this.groupControlTierSummary)).EndInit();
            this.groupControlTierSummary.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraEditors.SimpleButton buttonPrint;
        private DevExpress.XtraEditors.SimpleButton buttonCancel;
        private DevExpress.XtraEditors.GroupControl groupControlTierSummary;
    }
}
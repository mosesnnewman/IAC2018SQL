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
            this.buttonPost = new DevExpress.XtraEditors.SimpleButton();
            this.buttonCancel = new DevExpress.XtraEditors.SimpleButton();
            this.label1 = new System.Windows.Forms.Label();
            this.StatementDatenullableDateTimePicker = new DevExpress.XtraEditors.DateEdit();
            this.groupControl1 = new DevExpress.XtraEditors.GroupControl();
            ((System.ComponentModel.ISupportInitialize)(this.StatementDatenullableDateTimePicker.Properties.CalendarTimeProperties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.StatementDatenullableDateTimePicker.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl1)).BeginInit();
            this.groupControl1.SuspendLayout();
            this.SuspendLayout();
            // 
            // buttonPost
            // 
            this.buttonPost.Location = new System.Drawing.Point(113, 69);
            this.buttonPost.Name = "buttonPost";
            this.buttonPost.Size = new System.Drawing.Size(75, 23);
            this.buttonPost.TabIndex = 5;
            this.buttonPost.Text = "&Print";
            this.buttonPost.Click += new System.EventHandler(this.buttonPost_Click);
            // 
            // buttonCancel
            // 
            this.buttonCancel.Location = new System.Drawing.Point(194, 69);
            this.buttonCancel.Name = "buttonCancel";
            this.buttonCancel.Size = new System.Drawing.Size(75, 23);
            this.buttonCancel.TabIndex = 6;
            this.buttonCancel.Text = "&Cancel";
            this.buttonCancel.Click += new System.EventHandler(this.buttonCancel_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(86, 36);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(114, 13);
            this.label1.TabIndex = 5;
            this.label1.Text = "Statement DUE Date:";
            this.label1.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // StatementDatenullableDateTimePicker
            // 
            this.StatementDatenullableDateTimePicker.EditValue = new System.DateTime(2022, 5, 5, 0, 0, 0, 0);
            this.StatementDatenullableDateTimePicker.Location = new System.Drawing.Point(211, 29);
            this.StatementDatenullableDateTimePicker.Name = "StatementDatenullableDateTimePicker";
            this.StatementDatenullableDateTimePicker.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.StatementDatenullableDateTimePicker.Properties.CalendarTimeProperties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.StatementDatenullableDateTimePicker.Size = new System.Drawing.Size(83, 20);
            this.StatementDatenullableDateTimePicker.TabIndex = 3;
            // 
            // groupControl1
            // 
            this.groupControl1.Appearance.BackColor = System.Drawing.Color.LightSteelBlue;
            this.groupControl1.Appearance.Options.UseBackColor = true;
            this.groupControl1.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            this.groupControl1.Controls.Add(this.label1);
            this.groupControl1.Controls.Add(this.StatementDatenullableDateTimePicker);
            this.groupControl1.Controls.Add(this.buttonCancel);
            this.groupControl1.Controls.Add(this.buttonPost);
            this.groupControl1.Location = new System.Drawing.Point(-1, -3);
            this.groupControl1.Name = "groupControl1";
            this.groupControl1.Size = new System.Drawing.Size(380, 121);
            this.groupControl1.TabIndex = 7;
            this.groupControl1.Text = "groupControl1";
            // 
            // frmOpenCustomerFinanceChargeReport
            // 
            this.Appearance.Options.UseFont = true;
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.ClientSize = new System.Drawing.Size(379, 118);
            this.Controls.Add(this.groupControl1);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Name = "frmOpenCustomerFinanceChargeReport";
            this.Text = "Open Customer Finance Charge Report";
            this.Load += new System.EventHandler(this.frmOpenCustomerFinanceChargeReport_Load);
            ((System.ComponentModel.ISupportInitialize)(this.StatementDatenullableDateTimePicker.Properties.CalendarTimeProperties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.StatementDatenullableDateTimePicker.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl1)).EndInit();
            this.groupControl1.ResumeLayout(false);
            this.groupControl1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraEditors.SimpleButton buttonPost;
        private DevExpress.XtraEditors.SimpleButton buttonCancel;
        private System.Windows.Forms.Label label1;
        private DevExpress.XtraEditors.DateEdit StatementDatenullableDateTimePicker;
        private DevExpress.XtraEditors.GroupControl groupControl1;
    }
}
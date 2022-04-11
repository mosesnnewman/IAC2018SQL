namespace IAC2021SQL
{
    partial class frmClosedPayedInAdvanceReport
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
            this.nullableDateTimePickerDueDate = new DevExpress.XtraEditors.DateEdit();
            this.labelLateNotices = new System.Windows.Forms.Label();
            this.buttonPost = new DevExpress.XtraEditors.SimpleButton();
            this.buttonCancel = new DevExpress.XtraEditors.SimpleButton();
            this.groupControlPayedInAdvance = new DevExpress.XtraEditors.GroupControl();
            ((System.ComponentModel.ISupportInitialize)(this.nullableDateTimePickerDueDate.Properties.CalendarTimeProperties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nullableDateTimePickerDueDate.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.groupControlPayedInAdvance)).BeginInit();
            this.groupControlPayedInAdvance.SuspendLayout();
            this.SuspendLayout();
            // 
            // nullableDateTimePickerDueDate
            // 
            this.nullableDateTimePickerDueDate.EditValue = new System.DateTime(2016, 7, 20, 0, 0, 0, 0);
            this.nullableDateTimePickerDueDate.Location = new System.Drawing.Point(190, 36);
            this.nullableDateTimePickerDueDate.Margin = new System.Windows.Forms.Padding(4);
            this.nullableDateTimePickerDueDate.Name = "nullableDateTimePickerDueDate";
            this.nullableDateTimePickerDueDate.Properties.Appearance.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.nullableDateTimePickerDueDate.Properties.Appearance.Options.UseFont = true;
            this.nullableDateTimePickerDueDate.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.nullableDateTimePickerDueDate.Properties.CalendarTimeProperties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.nullableDateTimePickerDueDate.Properties.CalendarView = DevExpress.XtraEditors.Repository.CalendarView.Fluent;
            this.nullableDateTimePickerDueDate.Properties.VistaDisplayMode = DevExpress.Utils.DefaultBoolean.False;
            this.nullableDateTimePickerDueDate.Size = new System.Drawing.Size(123, 28);
            this.nullableDateTimePickerDueDate.TabIndex = 0;
            // 
            // labelLateNotices
            // 
            this.labelLateNotices.AutoSize = true;
            this.labelLateNotices.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelLateNotices.Location = new System.Drawing.Point(91, 43);
            this.labelLateNotices.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.labelLateNotices.Name = "labelLateNotices";
            this.labelLateNotices.Size = new System.Drawing.Size(77, 21);
            this.labelLateNotices.TabIndex = 1;
            this.labelLateNotices.Text = "Due Date:";
            this.labelLateNotices.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // buttonPost
            // 
            this.buttonPost.Appearance.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonPost.Appearance.Options.UseFont = true;
            this.buttonPost.Location = new System.Drawing.Point(86, 142);
            this.buttonPost.Margin = new System.Windows.Forms.Padding(4);
            this.buttonPost.Name = "buttonPost";
            this.buttonPost.Size = new System.Drawing.Size(112, 36);
            this.buttonPost.TabIndex = 2;
            this.buttonPost.Text = "&Print";
            this.buttonPost.Click += new System.EventHandler(this.buttonPost_Click);
            // 
            // buttonCancel
            // 
            this.buttonCancel.Appearance.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonCancel.Appearance.Options.UseFont = true;
            this.buttonCancel.Location = new System.Drawing.Point(207, 142);
            this.buttonCancel.Margin = new System.Windows.Forms.Padding(4);
            this.buttonCancel.Name = "buttonCancel";
            this.buttonCancel.Size = new System.Drawing.Size(112, 36);
            this.buttonCancel.TabIndex = 3;
            this.buttonCancel.Text = "&Cancel";
            this.buttonCancel.Click += new System.EventHandler(this.buttonCancel_Click);
            // 
            // groupControlPayedInAdvance
            // 
            this.groupControlPayedInAdvance.Appearance.BackColor = System.Drawing.Color.LightSteelBlue;
            this.groupControlPayedInAdvance.Appearance.Options.UseBackColor = true;
            this.groupControlPayedInAdvance.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            this.groupControlPayedInAdvance.Controls.Add(this.buttonCancel);
            this.groupControlPayedInAdvance.Controls.Add(this.buttonPost);
            this.groupControlPayedInAdvance.Controls.Add(this.labelLateNotices);
            this.groupControlPayedInAdvance.Controls.Add(this.nullableDateTimePickerDueDate);
            this.groupControlPayedInAdvance.Location = new System.Drawing.Point(1, -1);
            this.groupControlPayedInAdvance.Name = "groupControlPayedInAdvance";
            this.groupControlPayedInAdvance.Size = new System.Drawing.Size(404, 214);
            this.groupControlPayedInAdvance.TabIndex = 4;
            this.groupControlPayedInAdvance.Text = "groupControl1";
            // 
            // frmClosedPayedInAdvanceReport
            // 
            this.Appearance.Options.UseFont = true;
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.ClientSize = new System.Drawing.Size(407, 213);
            this.Controls.Add(this.groupControlPayedInAdvance);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "frmClosedPayedInAdvanceReport";
            this.Text = "Closed Paid In Advance Report";
            this.Load += new System.EventHandler(this.frmClosedPayedInAdvanceReport_Load);
            ((System.ComponentModel.ISupportInitialize)(this.nullableDateTimePickerDueDate.Properties.CalendarTimeProperties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nullableDateTimePickerDueDate.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.groupControlPayedInAdvance)).EndInit();
            this.groupControlPayedInAdvance.ResumeLayout(false);
            this.groupControlPayedInAdvance.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraEditors.DateEdit nullableDateTimePickerDueDate;
        private System.Windows.Forms.Label labelLateNotices;
        private DevExpress.XtraEditors.SimpleButton buttonPost;
        private DevExpress.XtraEditors.SimpleButton buttonCancel;
        private DevExpress.XtraEditors.GroupControl groupControlPayedInAdvance;
    }
}
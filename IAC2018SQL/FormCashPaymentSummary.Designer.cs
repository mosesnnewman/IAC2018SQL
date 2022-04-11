
namespace IAC2021SQL
{
    partial class FormCashPaymentSummary
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
            this.groupBoxButtons = new System.Windows.Forms.GroupBox();
            this.buttonCancel = new DevExpress.XtraEditors.SimpleButton();
            this.buttonPost = new DevExpress.XtraEditors.SimpleButton();
            this.groupBoxSelection = new System.Windows.Forms.GroupBox();
            this.nullableDateTimePickerEndDate = new DevExpress.XtraEditors.DateEdit();
            this.nullableDateTimePickerStartDate = new DevExpress.XtraEditors.DateEdit();
            this.labelEndDate = new System.Windows.Forms.Label();
            this.labelStartDate = new System.Windows.Forms.Label();
            this.groupControlCashPaymentSummary = new DevExpress.XtraEditors.GroupControl();
            this.groupBoxButtons.SuspendLayout();
            this.groupBoxSelection.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nullableDateTimePickerEndDate.Properties.CalendarTimeProperties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nullableDateTimePickerEndDate.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nullableDateTimePickerStartDate.Properties.CalendarTimeProperties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nullableDateTimePickerStartDate.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.groupControlCashPaymentSummary)).BeginInit();
            this.groupControlCashPaymentSummary.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBoxButtons
            // 
            this.groupBoxButtons.Controls.Add(this.buttonCancel);
            this.groupBoxButtons.Controls.Add(this.buttonPost);
            this.groupBoxButtons.Location = new System.Drawing.Point(23, 110);
            this.groupBoxButtons.Name = "groupBoxButtons";
            this.groupBoxButtons.Size = new System.Drawing.Size(490, 185);
            this.groupBoxButtons.TabIndex = 36;
            this.groupBoxButtons.TabStop = false;
            // 
            // buttonCancel
            // 
            this.buttonCancel.Appearance.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonCancel.Appearance.Options.UseFont = true;
            this.buttonCancel.ImageOptions.Image = global::IAC2021SQL.Properties.Resources.Cancel_64x;
            this.buttonCancel.ImageOptions.Location = DevExpress.XtraEditors.ImageLocation.MiddleCenter;
            this.buttonCancel.Location = new System.Drawing.Point(276, 15);
            this.buttonCancel.LookAndFeel.SkinName = "McSkin";
            this.buttonCancel.LookAndFeel.UseDefaultLookAndFeel = false;
            this.buttonCancel.Margin = new System.Windows.Forms.Padding(6, 8, 6, 8);
            this.buttonCancel.Name = "buttonCancel";
            this.buttonCancel.Size = new System.Drawing.Size(168, 154);
            this.buttonCancel.TabIndex = 25;
            this.buttonCancel.Click += new System.EventHandler(this.buttonCancel_Click);
            // 
            // buttonPost
            // 
            this.buttonPost.Appearance.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonPost.Appearance.Options.UseFont = true;
            this.buttonPost.ImageOptions.Image = global::IAC2021SQL.Properties.Resources.ExportToExcel_64x;
            this.buttonPost.ImageOptions.Location = DevExpress.XtraEditors.ImageLocation.MiddleCenter;
            this.buttonPost.Location = new System.Drawing.Point(46, 15);
            this.buttonPost.LookAndFeel.SkinName = "McSkin";
            this.buttonPost.LookAndFeel.UseDefaultLookAndFeel = false;
            this.buttonPost.Margin = new System.Windows.Forms.Padding(6, 8, 6, 8);
            this.buttonPost.Name = "buttonPost";
            this.buttonPost.Size = new System.Drawing.Size(168, 154);
            this.buttonPost.TabIndex = 24;
            this.buttonPost.Click += new System.EventHandler(this.buttonPost_Click);
            // 
            // groupBoxSelection
            // 
            this.groupBoxSelection.Controls.Add(this.nullableDateTimePickerEndDate);
            this.groupBoxSelection.Controls.Add(this.nullableDateTimePickerStartDate);
            this.groupBoxSelection.Controls.Add(this.labelEndDate);
            this.groupBoxSelection.Controls.Add(this.labelStartDate);
            this.groupBoxSelection.Location = new System.Drawing.Point(122, 2);
            this.groupBoxSelection.Name = "groupBoxSelection";
            this.groupBoxSelection.Size = new System.Drawing.Size(291, 94);
            this.groupBoxSelection.TabIndex = 37;
            this.groupBoxSelection.TabStop = false;
            // 
            // nullableDateTimePickerEndDate
            // 
            this.nullableDateTimePickerEndDate.EditValue = new System.DateTime(2021, 7, 7, 0, 0, 0, 0);
            this.nullableDateTimePickerEndDate.Location = new System.Drawing.Point(141, 50);
            this.nullableDateTimePickerEndDate.Margin = new System.Windows.Forms.Padding(6, 8, 6, 8);
            this.nullableDateTimePickerEndDate.Name = "nullableDateTimePickerEndDate";
            this.nullableDateTimePickerEndDate.Properties.Appearance.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.nullableDateTimePickerEndDate.Properties.Appearance.Options.UseFont = true;
            this.nullableDateTimePickerEndDate.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.nullableDateTimePickerEndDate.Properties.CalendarTimeProperties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.nullableDateTimePickerEndDate.Properties.LookAndFeel.SkinName = "McSkin";
            this.nullableDateTimePickerEndDate.Properties.LookAndFeel.UseDefaultLookAndFeel = false;
            this.nullableDateTimePickerEndDate.Size = new System.Drawing.Size(107, 26);
            this.nullableDateTimePickerEndDate.TabIndex = 28;
            // 
            // nullableDateTimePickerStartDate
            // 
            this.nullableDateTimePickerStartDate.EditValue = new System.DateTime(2021, 7, 7, 0, 0, 0, 0);
            this.nullableDateTimePickerStartDate.Location = new System.Drawing.Point(141, 18);
            this.nullableDateTimePickerStartDate.Margin = new System.Windows.Forms.Padding(6, 8, 6, 8);
            this.nullableDateTimePickerStartDate.Name = "nullableDateTimePickerStartDate";
            this.nullableDateTimePickerStartDate.Properties.Appearance.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.nullableDateTimePickerStartDate.Properties.Appearance.Options.UseFont = true;
            this.nullableDateTimePickerStartDate.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.nullableDateTimePickerStartDate.Properties.CalendarTimeProperties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.nullableDateTimePickerStartDate.Properties.LookAndFeel.SkinName = "McSkin";
            this.nullableDateTimePickerStartDate.Properties.LookAndFeel.UseDefaultLookAndFeel = false;
            this.nullableDateTimePickerStartDate.Size = new System.Drawing.Size(107, 26);
            this.nullableDateTimePickerStartDate.TabIndex = 27;
            // 
            // labelEndDate
            // 
            this.labelEndDate.AutoSize = true;
            this.labelEndDate.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelEndDate.Location = new System.Drawing.Point(48, 57);
            this.labelEndDate.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.labelEndDate.Name = "labelEndDate";
            this.labelEndDate.Size = new System.Drawing.Size(81, 20);
            this.labelEndDate.TabIndex = 26;
            this.labelEndDate.Text = "End Date:";
            this.labelEndDate.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // labelStartDate
            // 
            this.labelStartDate.AutoSize = true;
            this.labelStartDate.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelStartDate.Location = new System.Drawing.Point(42, 24);
            this.labelStartDate.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.labelStartDate.Name = "labelStartDate";
            this.labelStartDate.Size = new System.Drawing.Size(87, 20);
            this.labelStartDate.TabIndex = 23;
            this.labelStartDate.Text = "Start Date:";
            this.labelStartDate.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // groupControlCashPaymentSummary
            // 
            this.groupControlCashPaymentSummary.Appearance.BackColor = System.Drawing.Color.LightSteelBlue;
            this.groupControlCashPaymentSummary.Appearance.Options.UseBackColor = true;
            this.groupControlCashPaymentSummary.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            this.groupControlCashPaymentSummary.Controls.Add(this.groupBoxSelection);
            this.groupControlCashPaymentSummary.Controls.Add(this.groupBoxButtons);
            this.groupControlCashPaymentSummary.Location = new System.Drawing.Point(2, 0);
            this.groupControlCashPaymentSummary.Name = "groupControlCashPaymentSummary";
            this.groupControlCashPaymentSummary.Size = new System.Drawing.Size(536, 318);
            this.groupControlCashPaymentSummary.TabIndex = 38;
            this.groupControlCashPaymentSummary.Text = "groupControl1";
            // 
            // FormCashPaymentSummary
            // 
            this.Appearance.Options.UseFont = true;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(538, 317);
            this.Controls.Add(this.groupControlCashPaymentSummary);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Name = "FormCashPaymentSummary";
            this.Text = "Cash Payment Summary Report";
            this.Load += new System.EventHandler(this.FormCashPaymentSummary_Load);
            this.groupBoxButtons.ResumeLayout(false);
            this.groupBoxSelection.ResumeLayout(false);
            this.groupBoxSelection.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nullableDateTimePickerEndDate.Properties.CalendarTimeProperties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nullableDateTimePickerEndDate.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nullableDateTimePickerStartDate.Properties.CalendarTimeProperties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nullableDateTimePickerStartDate.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.groupControlCashPaymentSummary)).EndInit();
            this.groupControlCashPaymentSummary.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBoxButtons;
        private DevExpress.XtraEditors.SimpleButton buttonCancel;
        private DevExpress.XtraEditors.SimpleButton buttonPost;
        private System.Windows.Forms.GroupBox groupBoxSelection;
        private DevExpress.XtraEditors.DateEdit nullableDateTimePickerEndDate;
        private DevExpress.XtraEditors.DateEdit nullableDateTimePickerStartDate;
        private System.Windows.Forms.Label labelEndDate;
        private System.Windows.Forms.Label labelStartDate;
        private DevExpress.XtraEditors.GroupControl groupControlCashPaymentSummary;
    }
}
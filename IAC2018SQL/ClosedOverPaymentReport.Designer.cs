namespace IAC2021SQL
{
    partial class ClosedOverPaymentReport
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ClosedOverPaymentReport));
            this.groupBoxDateSelection = new System.Windows.Forms.GroupBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.nullableDateTimePickerFrom = new DevExpress.XtraEditors.DateEdit();
            this.nullableDateTimePickerTo = new DevExpress.XtraEditors.DateEdit();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.buttonExcel = new DevExpress.XtraEditors.SimpleButton();
            this.buttonCancel = new DevExpress.XtraEditors.SimpleButton();
            this.groupControl1 = new DevExpress.XtraEditors.GroupControl();
            this.checkEditActive = new DevExpress.XtraEditors.CheckEdit();
            this.groupBoxDateSelection.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nullableDateTimePickerFrom.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nullableDateTimePickerFrom.Properties.CalendarTimeProperties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nullableDateTimePickerTo.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nullableDateTimePickerTo.Properties.CalendarTimeProperties)).BeginInit();
            this.groupBox3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl1)).BeginInit();
            this.groupControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.checkEditActive.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // groupBoxDateSelection
            // 
            this.groupBoxDateSelection.Controls.Add(this.checkEditActive);
            this.groupBoxDateSelection.Controls.Add(this.label2);
            this.groupBoxDateSelection.Controls.Add(this.label1);
            this.groupBoxDateSelection.Controls.Add(this.nullableDateTimePickerFrom);
            this.groupBoxDateSelection.Controls.Add(this.nullableDateTimePickerTo);
            this.groupBoxDateSelection.Location = new System.Drawing.Point(156, 21);
            this.groupBoxDateSelection.Name = "groupBoxDateSelection";
            this.groupBoxDateSelection.Size = new System.Drawing.Size(212, 126);
            this.groupBoxDateSelection.TabIndex = 2;
            this.groupBoxDateSelection.TabStop = false;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(41, 68);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(34, 20);
            this.label2.TabIndex = 16;
            this.label2.Text = "To:";
            this.label2.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(22, 17);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(55, 20);
            this.label1.TabIndex = 15;
            this.label1.Text = "From:";
            this.label1.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // nullableDateTimePickerFrom
            // 
            this.nullableDateTimePickerFrom.EditValue = new System.DateTime(2022, 4, 6, 0, 0, 0, 0);
            this.nullableDateTimePickerFrom.Location = new System.Drawing.Point(80, 16);
            this.nullableDateTimePickerFrom.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.nullableDateTimePickerFrom.Name = "nullableDateTimePickerFrom";
            this.nullableDateTimePickerFrom.Properties.Appearance.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.nullableDateTimePickerFrom.Properties.Appearance.Options.UseFont = true;
            this.nullableDateTimePickerFrom.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.nullableDateTimePickerFrom.Properties.CalendarTimeProperties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.nullableDateTimePickerFrom.Properties.CalendarView = DevExpress.XtraEditors.Repository.CalendarView.Fluent;
            this.nullableDateTimePickerFrom.Properties.LookAndFeel.SkinName = "McSkin";
            this.nullableDateTimePickerFrom.Properties.LookAndFeel.UseDefaultLookAndFeel = false;
            this.nullableDateTimePickerFrom.Properties.VistaDisplayMode = DevExpress.Utils.DefaultBoolean.False;
            this.nullableDateTimePickerFrom.Size = new System.Drawing.Size(111, 28);
            this.nullableDateTimePickerFrom.TabIndex = 2;
            // 
            // nullableDateTimePickerTo
            // 
            this.nullableDateTimePickerTo.EditValue = new System.DateTime(2022, 4, 6, 0, 0, 0, 0);
            this.nullableDateTimePickerTo.Location = new System.Drawing.Point(80, 67);
            this.nullableDateTimePickerTo.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.nullableDateTimePickerTo.Name = "nullableDateTimePickerTo";
            this.nullableDateTimePickerTo.Properties.Appearance.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.nullableDateTimePickerTo.Properties.Appearance.Options.UseFont = true;
            this.nullableDateTimePickerTo.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.nullableDateTimePickerTo.Properties.CalendarTimeProperties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.nullableDateTimePickerTo.Properties.CalendarView = DevExpress.XtraEditors.Repository.CalendarView.Fluent;
            this.nullableDateTimePickerTo.Properties.LookAndFeel.SkinName = "McSkin";
            this.nullableDateTimePickerTo.Properties.LookAndFeel.UseDefaultLookAndFeel = false;
            this.nullableDateTimePickerTo.Properties.VistaDisplayMode = DevExpress.Utils.DefaultBoolean.False;
            this.nullableDateTimePickerTo.Size = new System.Drawing.Size(111, 26);
            this.nullableDateTimePickerTo.TabIndex = 3;
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.buttonExcel);
            this.groupBox3.Controls.Add(this.buttonCancel);
            this.groupBox3.Location = new System.Drawing.Point(47, 146);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(431, 189);
            this.groupBox3.TabIndex = 18;
            this.groupBox3.TabStop = false;
            // 
            // buttonExcel
            // 
            this.buttonExcel.ImageOptions.Image = global::IAC2021SQL.Properties.Resources.ExportToExcel_64x;
            this.buttonExcel.ImageOptions.Location = DevExpress.XtraEditors.ImageLocation.MiddleCenter;
            this.buttonExcel.Location = new System.Drawing.Point(37, 27);
            this.buttonExcel.LookAndFeel.SkinName = "McSkin";
            this.buttonExcel.LookAndFeel.UseDefaultLookAndFeel = false;
            this.buttonExcel.Name = "buttonExcel";
            this.buttonExcel.Size = new System.Drawing.Size(138, 135);
            this.buttonExcel.TabIndex = 20;
            this.buttonExcel.Click += new System.EventHandler(this.buttonExcel_Click);
            // 
            // buttonCancel
            // 
            this.buttonCancel.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("buttonCancel.ImageOptions.Image")));
            this.buttonCancel.ImageOptions.Location = DevExpress.XtraEditors.ImageLocation.MiddleCenter;
            this.buttonCancel.Location = new System.Drawing.Point(256, 27);
            this.buttonCancel.LookAndFeel.SkinName = "McSkin";
            this.buttonCancel.LookAndFeel.UseDefaultLookAndFeel = false;
            this.buttonCancel.Margin = new System.Windows.Forms.Padding(6);
            this.buttonCancel.Name = "buttonCancel";
            this.buttonCancel.Size = new System.Drawing.Size(138, 135);
            this.buttonCancel.TabIndex = 19;
            this.buttonCancel.Click += new System.EventHandler(this.buttonCancel_Click);
            // 
            // groupControl1
            // 
            this.groupControl1.Appearance.BackColor = System.Drawing.Color.LightSteelBlue;
            this.groupControl1.Appearance.Options.UseBackColor = true;
            this.groupControl1.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            this.groupControl1.Controls.Add(this.groupBox3);
            this.groupControl1.Controls.Add(this.groupBoxDateSelection);
            this.groupControl1.Location = new System.Drawing.Point(-2, 0);
            this.groupControl1.Name = "groupControl1";
            this.groupControl1.Size = new System.Drawing.Size(524, 356);
            this.groupControl1.TabIndex = 19;
            this.groupControl1.Text = "groupControl1";
            // 
            // checkEditActive
            // 
            this.checkEditActive.Location = new System.Drawing.Point(26, 98);
            this.checkEditActive.Name = "checkEditActive";
            this.checkEditActive.Properties.Caption = "Active?";
            this.checkEditActive.Properties.CheckBoxOptions.Style = DevExpress.XtraEditors.Controls.CheckBoxStyle.SvgCheckBox1;
            this.checkEditActive.Properties.CheckBoxOptions.SvgColorChecked = System.Drawing.Color.Black;
            this.checkEditActive.Properties.NullStyle = DevExpress.XtraEditors.Controls.StyleIndeterminate.Unchecked;
            this.checkEditActive.Size = new System.Drawing.Size(121, 24);
            this.checkEditActive.TabIndex = 21;
            // 
            // ClosedOverPaymentReport
            // 
            this.Appearance.Options.UseFont = true;
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 21F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(521, 354);
            this.Controls.Add(this.groupControl1);
            this.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.Name = "ClosedOverPaymentReport";
            this.Text = "Overpayment Report";
            this.Load += new System.EventHandler(this.ClosedOverPaymentReport_Load);
            this.groupBoxDateSelection.ResumeLayout(false);
            this.groupBoxDateSelection.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nullableDateTimePickerFrom.Properties.CalendarTimeProperties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nullableDateTimePickerFrom.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nullableDateTimePickerTo.Properties.CalendarTimeProperties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nullableDateTimePickerTo.Properties)).EndInit();
            this.groupBox3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.groupControl1)).EndInit();
            this.groupControl1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.checkEditActive.Properties)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBoxDateSelection;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private DevExpress.XtraEditors.DateEdit nullableDateTimePickerFrom;
        private DevExpress.XtraEditors.DateEdit nullableDateTimePickerTo;
        private System.Windows.Forms.GroupBox groupBox3;
        private DevExpress.XtraEditors.SimpleButton buttonCancel;
        public DevExpress.XtraEditors.SimpleButton buttonExcel;
        private DevExpress.XtraEditors.GroupControl groupControl1;
        private DevExpress.XtraEditors.CheckEdit checkEditActive;
    }
}
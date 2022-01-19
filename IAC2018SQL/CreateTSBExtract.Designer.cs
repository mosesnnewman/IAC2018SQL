namespace IAC2021SQL
{
    partial class frmCreateTSBExtract
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmCreateTSBExtract));
            this.label1 = new DevExpress.XtraEditors.LabelControl();
            this.nullableDateTimePickerControlDate = new DevExpress.XtraEditors.DateEdit();
            this.checkBoxCreateBoth = new DevExpress.XtraEditors.CheckEdit();
            this.buttonTransfer = new DevExpress.XtraEditors.SimpleButton();
            this.nullableDateTimePickerFrom = new DevExpress.XtraEditors.DateEdit();
            this.nullableDateTimePickerTo = new DevExpress.XtraEditors.DateEdit();
            this.label2 = new DevExpress.XtraEditors.LabelControl();
            this.label3 = new DevExpress.XtraEditors.LabelControl();
            this.checkBoxIgnoreBureauSwitch = new DevExpress.XtraEditors.CheckEdit();
            this.buttonCancel = new DevExpress.XtraEditors.SimpleButton();
            this.groupControlTSB = new DevExpress.XtraEditors.GroupControl();
            ((System.ComponentModel.ISupportInitialize)(this.nullableDateTimePickerControlDate.Properties.CalendarTimeProperties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nullableDateTimePickerControlDate.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.checkBoxCreateBoth.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nullableDateTimePickerFrom.Properties.CalendarTimeProperties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nullableDateTimePickerFrom.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nullableDateTimePickerTo.Properties.CalendarTimeProperties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nullableDateTimePickerTo.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.checkBoxIgnoreBureauSwitch.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.groupControlTSB)).BeginInit();
            this.groupControlTSB.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.Appearance.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Appearance.Options.UseFont = true;
            this.label1.Appearance.Options.UseTextOptions = true;
            this.label1.Appearance.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Top;
            this.label1.Location = new System.Drawing.Point(98, 25);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(94, 20);
            this.label1.TabIndex = 5;
            this.label1.Text = "Control Date:";
            // 
            // nullableDateTimePickerControlDate
            // 
            this.nullableDateTimePickerControlDate.EditValue = new System.DateTime(2022, 1, 14, 0, 0, 0, 0);
            this.nullableDateTimePickerControlDate.Location = new System.Drawing.Point(205, 19);
            this.nullableDateTimePickerControlDate.Margin = new System.Windows.Forms.Padding(4);
            this.nullableDateTimePickerControlDate.Name = "nullableDateTimePickerControlDate";
            this.nullableDateTimePickerControlDate.Properties.Appearance.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.nullableDateTimePickerControlDate.Properties.Appearance.Options.UseFont = true;
            this.nullableDateTimePickerControlDate.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.nullableDateTimePickerControlDate.Properties.CalendarTimeProperties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.nullableDateTimePickerControlDate.Properties.CalendarView = DevExpress.XtraEditors.Repository.CalendarView.Fluent;
            this.nullableDateTimePickerControlDate.Properties.LookAndFeel.SkinName = "McSkin";
            this.nullableDateTimePickerControlDate.Properties.LookAndFeel.UseDefaultLookAndFeel = false;
            this.nullableDateTimePickerControlDate.Properties.VistaDisplayMode = DevExpress.Utils.DefaultBoolean.False;
            this.nullableDateTimePickerControlDate.Size = new System.Drawing.Size(109, 26);
            this.nullableDateTimePickerControlDate.TabIndex = 3;
            this.nullableDateTimePickerControlDate.EditValueChanged += new System.EventHandler(this.nullableDateTimePickerControlDate_EditValueChanged);
            // 
            // checkBoxCreateBoth
            // 
            this.checkBoxCreateBoth.EditValue = true;
            this.checkBoxCreateBoth.Location = new System.Drawing.Point(65, 116);
            this.checkBoxCreateBoth.Margin = new System.Windows.Forms.Padding(4);
            this.checkBoxCreateBoth.Name = "checkBoxCreateBoth";
            this.checkBoxCreateBoth.Properties.Appearance.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.checkBoxCreateBoth.Properties.Appearance.Options.UseFont = true;
            this.checkBoxCreateBoth.Properties.Caption = "Create Extract, Report, and new Control Date";
            this.checkBoxCreateBoth.Size = new System.Drawing.Size(289, 20);
            this.checkBoxCreateBoth.TabIndex = 11;
            // 
            // buttonTransfer
            // 
            this.buttonTransfer.Appearance.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonTransfer.Appearance.Options.UseFont = true;
            this.buttonTransfer.Appearance.Options.UseTextOptions = true;
            this.buttonTransfer.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.buttonTransfer.Appearance.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap;
            this.buttonTransfer.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("buttonTransfer.ImageOptions.Image")));
            this.buttonTransfer.ImageOptions.ImageToTextAlignment = DevExpress.XtraEditors.ImageAlignToText.TopCenter;
            this.buttonTransfer.Location = new System.Drawing.Point(96, 172);
            this.buttonTransfer.LookAndFeel.SkinName = "McSkin";
            this.buttonTransfer.LookAndFeel.UseDefaultLookAndFeel = false;
            this.buttonTransfer.Name = "buttonTransfer";
            this.buttonTransfer.Size = new System.Drawing.Size(110, 103);
            this.buttonTransfer.TabIndex = 12;
            this.buttonTransfer.Text = "&Transfer Payments";
            this.buttonTransfer.Click += new System.EventHandler(this.buttonTransfer_Click);
            // 
            // nullableDateTimePickerFrom
            // 
            this.nullableDateTimePickerFrom.EditValue = new System.DateTime(2022, 1, 14, 0, 0, 0, 0);
            this.nullableDateTimePickerFrom.Location = new System.Drawing.Point(205, 49);
            this.nullableDateTimePickerFrom.Margin = new System.Windows.Forms.Padding(4);
            this.nullableDateTimePickerFrom.Name = "nullableDateTimePickerFrom";
            this.nullableDateTimePickerFrom.Properties.Appearance.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.nullableDateTimePickerFrom.Properties.Appearance.Options.UseFont = true;
            this.nullableDateTimePickerFrom.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.nullableDateTimePickerFrom.Properties.CalendarTimeProperties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.nullableDateTimePickerFrom.Properties.CalendarView = DevExpress.XtraEditors.Repository.CalendarView.Fluent;
            this.nullableDateTimePickerFrom.Properties.LookAndFeel.SkinName = "McSkin";
            this.nullableDateTimePickerFrom.Properties.LookAndFeel.UseDefaultLookAndFeel = false;
            this.nullableDateTimePickerFrom.Properties.VistaDisplayMode = DevExpress.Utils.DefaultBoolean.False;
            this.nullableDateTimePickerFrom.Size = new System.Drawing.Size(109, 26);
            this.nullableDateTimePickerFrom.TabIndex = 13;
            this.nullableDateTimePickerFrom.EditValueChanged += new System.EventHandler(this.nullableDateTimePickerFrom_EditValueChanged);
            // 
            // nullableDateTimePickerTo
            // 
            this.nullableDateTimePickerTo.EditValue = new System.DateTime(2022, 1, 14, 0, 0, 0, 0);
            this.nullableDateTimePickerTo.Location = new System.Drawing.Point(205, 79);
            this.nullableDateTimePickerTo.Margin = new System.Windows.Forms.Padding(4);
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
            this.nullableDateTimePickerTo.Size = new System.Drawing.Size(109, 26);
            this.nullableDateTimePickerTo.TabIndex = 14;
            // 
            // label2
            // 
            this.label2.Appearance.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Appearance.Options.UseFont = true;
            this.label2.Location = new System.Drawing.Point(151, 55);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(41, 20);
            this.label2.TabIndex = 15;
            this.label2.Text = "From:";
            // 
            // label3
            // 
            this.label3.Appearance.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Appearance.Options.UseFont = true;
            this.label3.Location = new System.Drawing.Point(170, 85);
            this.label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(22, 20);
            this.label3.TabIndex = 16;
            this.label3.Text = "To:";
            // 
            // checkBoxIgnoreBureauSwitch
            // 
            this.checkBoxIgnoreBureauSwitch.Location = new System.Drawing.Point(65, 138);
            this.checkBoxIgnoreBureauSwitch.Margin = new System.Windows.Forms.Padding(4);
            this.checkBoxIgnoreBureauSwitch.Name = "checkBoxIgnoreBureauSwitch";
            this.checkBoxIgnoreBureauSwitch.Properties.Appearance.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.checkBoxIgnoreBureauSwitch.Properties.Appearance.Options.UseFont = true;
            this.checkBoxIgnoreBureauSwitch.Properties.Caption = "Ignore \"Credit Bureau\" switch";
            this.checkBoxIgnoreBureauSwitch.Size = new System.Drawing.Size(197, 20);
            this.checkBoxIgnoreBureauSwitch.TabIndex = 17;
            // 
            // buttonCancel
            // 
            this.buttonCancel.Appearance.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonCancel.Appearance.Options.UseFont = true;
            this.buttonCancel.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("buttonCancel.ImageOptions.Image")));
            this.buttonCancel.ImageOptions.ImageToTextAlignment = DevExpress.XtraEditors.ImageAlignToText.TopCenter;
            this.buttonCancel.Location = new System.Drawing.Point(221, 172);
            this.buttonCancel.LookAndFeel.SkinName = "McSkin";
            this.buttonCancel.LookAndFeel.UseDefaultLookAndFeel = false;
            this.buttonCancel.Margin = new System.Windows.Forms.Padding(4);
            this.buttonCancel.Name = "buttonCancel";
            this.buttonCancel.Size = new System.Drawing.Size(110, 103);
            this.buttonCancel.TabIndex = 18;
            this.buttonCancel.Text = "&Cancel";
            this.buttonCancel.Click += new System.EventHandler(this.buttonCancel_Click);
            // 
            // groupControlTSB
            // 
            this.groupControlTSB.Appearance.BackColor = System.Drawing.Color.LightSteelBlue;
            this.groupControlTSB.Appearance.Options.UseBackColor = true;
            this.groupControlTSB.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            this.groupControlTSB.Controls.Add(this.buttonCancel);
            this.groupControlTSB.Controls.Add(this.checkBoxIgnoreBureauSwitch);
            this.groupControlTSB.Controls.Add(this.label3);
            this.groupControlTSB.Controls.Add(this.label2);
            this.groupControlTSB.Controls.Add(this.nullableDateTimePickerTo);
            this.groupControlTSB.Controls.Add(this.nullableDateTimePickerFrom);
            this.groupControlTSB.Controls.Add(this.buttonTransfer);
            this.groupControlTSB.Controls.Add(this.checkBoxCreateBoth);
            this.groupControlTSB.Controls.Add(this.label1);
            this.groupControlTSB.Controls.Add(this.nullableDateTimePickerControlDate);
            this.groupControlTSB.Location = new System.Drawing.Point(-2, -1);
            this.groupControlTSB.LookAndFeel.SkinName = "McSkin";
            this.groupControlTSB.LookAndFeel.UseDefaultLookAndFeel = false;
            this.groupControlTSB.Name = "groupControlTSB";
            this.groupControlTSB.Size = new System.Drawing.Size(427, 306);
            this.groupControlTSB.TabIndex = 19;
            // 
            // frmCreateTSBExtract
            // 
            this.Appearance.Options.UseFont = true;
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.ClientSize = new System.Drawing.Size(425, 304);
            this.Controls.Add(this.groupControlTSB);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "frmCreateTSBExtract";
            this.Text = "Create TSB Extract / Reports";
            this.Load += new System.EventHandler(this.frmCreateTSBExtract_Load);
            ((System.ComponentModel.ISupportInitialize)(this.nullableDateTimePickerControlDate.Properties.CalendarTimeProperties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nullableDateTimePickerControlDate.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.checkBoxCreateBoth.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nullableDateTimePickerFrom.Properties.CalendarTimeProperties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nullableDateTimePickerFrom.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nullableDateTimePickerTo.Properties.CalendarTimeProperties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nullableDateTimePickerTo.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.checkBoxIgnoreBureauSwitch.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.groupControlTSB)).EndInit();
            this.groupControlTSB.ResumeLayout(false);
            this.groupControlTSB.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraEditors.LabelControl label1;
        private DevExpress.XtraEditors.DateEdit nullableDateTimePickerControlDate;
        private DevExpress.XtraEditors.CheckEdit checkBoxCreateBoth;
        private DevExpress.XtraEditors.SimpleButton buttonTransfer;
        private DevExpress.XtraEditors.DateEdit nullableDateTimePickerFrom;
        private DevExpress.XtraEditors.DateEdit nullableDateTimePickerTo;
        private DevExpress.XtraEditors.LabelControl label2;
        private DevExpress.XtraEditors.LabelControl label3;
        private DevExpress.XtraEditors.CheckEdit checkBoxIgnoreBureauSwitch;
        private DevExpress.XtraEditors.SimpleButton buttonCancel;
        private DevExpress.XtraEditors.GroupControl groupControlTSB;
    }
}
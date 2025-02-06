namespace IAC2021SQL
{
    partial class frmClosedDelinquencyReports
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
            this.labelLateNotices = new System.Windows.Forms.Label();
            this.buttonPost = new DevExpress.XtraEditors.SimpleButton();
            this.buttonCancel = new DevExpress.XtraEditors.SimpleButton();
            this.labelAgedPeriod = new System.Windows.Forms.Label();
            this.checkBoxCollections = new DevExpress.XtraEditors.CheckEdit();
            this.labelSortType = new System.Windows.Forms.Label();
            this.nullableDateTimePickerDueDate = new DevExpress.XtraEditors.DateEdit();
            this.comboBoxAgedPeriod = new DevExpress.XtraEditors.ComboBoxEdit();
            this.comboBoxSortType = new DevExpress.XtraEditors.ComboBoxEdit();
            this.groupControl1 = new DevExpress.XtraEditors.GroupControl();
            this.checkEditSortAndGroupDealerByState = new DevExpress.XtraEditors.CheckEdit();
            this.checkEditSortAndGroupDetailByState = new DevExpress.XtraEditors.CheckEdit();
            this.buttonPrint = new DevExpress.XtraEditors.SimpleButton();
            ((System.ComponentModel.ISupportInitialize)(this.checkBoxCollections.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nullableDateTimePickerDueDate.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nullableDateTimePickerDueDate.Properties.CalendarTimeProperties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.comboBoxAgedPeriod.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.comboBoxSortType.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl1)).BeginInit();
            this.groupControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.checkEditSortAndGroupDealerByState.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.checkEditSortAndGroupDetailByState.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // labelLateNotices
            // 
            this.labelLateNotices.AutoSize = true;
            this.labelLateNotices.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelLateNotices.Location = new System.Drawing.Point(82, 49);
            this.labelLateNotices.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.labelLateNotices.Name = "labelLateNotices";
            this.labelLateNotices.Size = new System.Drawing.Size(82, 20);
            this.labelLateNotices.TabIndex = 1;
            this.labelLateNotices.Text = "Due Date:";
            this.labelLateNotices.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // buttonPost
            // 
            this.buttonPost.Appearance.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonPost.Appearance.Options.UseFont = true;
            this.buttonPost.Location = new System.Drawing.Point(158, 226);
            this.buttonPost.Margin = new System.Windows.Forms.Padding(4);
            this.buttonPost.Name = "buttonPost";
            this.buttonPost.Size = new System.Drawing.Size(112, 36);
            this.buttonPost.TabIndex = 2;
            this.buttonPost.Text = "&Print";
            this.buttonPost.Click += new System.EventHandler(this.buttonPost_Click);
            // 
            // buttonCancel
            // 
            this.buttonCancel.Appearance.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonCancel.Appearance.Options.UseFont = true;
            this.buttonCancel.Location = new System.Drawing.Point(279, 226);
            this.buttonCancel.Margin = new System.Windows.Forms.Padding(4);
            this.buttonCancel.Name = "buttonCancel";
            this.buttonCancel.Size = new System.Drawing.Size(112, 36);
            this.buttonCancel.TabIndex = 3;
            this.buttonCancel.Text = "&Cancel";
            this.buttonCancel.Click += new System.EventHandler(this.buttonCancel_Click);
            // 
            // labelAgedPeriod
            // 
            this.labelAgedPeriod.AutoSize = true;
            this.labelAgedPeriod.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelAgedPeriod.Location = new System.Drawing.Point(52, 83);
            this.labelAgedPeriod.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.labelAgedPeriod.Name = "labelAgedPeriod";
            this.labelAgedPeriod.Size = new System.Drawing.Size(112, 20);
            this.labelAgedPeriod.TabIndex = 5;
            this.labelAgedPeriod.Text = "Ageing Period:";
            this.labelAgedPeriod.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // checkBoxCollections
            // 
            this.checkBoxCollections.Location = new System.Drawing.Point(171, 111);
            this.checkBoxCollections.Name = "checkBoxCollections";
            this.checkBoxCollections.Properties.Appearance.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.checkBoxCollections.Properties.Appearance.Options.UseFont = true;
            this.checkBoxCollections.Properties.Caption = "Collections?";
            this.checkBoxCollections.Size = new System.Drawing.Size(114, 24);
            this.checkBoxCollections.TabIndex = 6;
            // 
            // labelSortType
            // 
            this.labelSortType.AutoSize = true;
            this.labelSortType.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelSortType.Location = new System.Drawing.Point(77, 149);
            this.labelSortType.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.labelSortType.Name = "labelSortType";
            this.labelSortType.Size = new System.Drawing.Size(87, 20);
            this.labelSortType.TabIndex = 8;
            this.labelSortType.Text = "Sort Order:";
            this.labelSortType.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // nullableDateTimePickerDueDate
            // 
            this.nullableDateTimePickerDueDate.EditValue = new System.DateTime(2022, 4, 8, 0, 0, 0, 0);
            this.nullableDateTimePickerDueDate.Location = new System.Drawing.Point(171, 43);
            this.nullableDateTimePickerDueDate.Margin = new System.Windows.Forms.Padding(4);
            this.nullableDateTimePickerDueDate.Name = "nullableDateTimePickerDueDate";
            this.nullableDateTimePickerDueDate.Properties.Appearance.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.nullableDateTimePickerDueDate.Properties.Appearance.Options.UseFont = true;
            this.nullableDateTimePickerDueDate.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.nullableDateTimePickerDueDate.Properties.CalendarTimeProperties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.nullableDateTimePickerDueDate.Properties.CalendarView = DevExpress.XtraEditors.Repository.CalendarView.Fluent;
            this.nullableDateTimePickerDueDate.Properties.LookAndFeel.SkinName = "McSkin";
            this.nullableDateTimePickerDueDate.Properties.LookAndFeel.UseDefaultLookAndFeel = false;
            this.nullableDateTimePickerDueDate.Properties.VistaDisplayMode = DevExpress.Utils.DefaultBoolean.False;
            this.nullableDateTimePickerDueDate.Size = new System.Drawing.Size(123, 26);
            this.nullableDateTimePickerDueDate.TabIndex = 0;
            // 
            // comboBoxAgedPeriod
            // 
            this.comboBoxAgedPeriod.Location = new System.Drawing.Point(171, 77);
            this.comboBoxAgedPeriod.Name = "comboBoxAgedPeriod";
            this.comboBoxAgedPeriod.Properties.Appearance.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.comboBoxAgedPeriod.Properties.Appearance.Options.UseFont = true;
            this.comboBoxAgedPeriod.Properties.AppearanceDropDown.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.comboBoxAgedPeriod.Properties.AppearanceDropDown.Options.UseFont = true;
            this.comboBoxAgedPeriod.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.comboBoxAgedPeriod.Properties.Items.AddRange(new object[] {
            "30 Days",
            "60 Days",
            "90 Days",
            "120 Days",
            "150 Days",
            "180+ Days",
            "ALL PERIOD DEALER SUMMARY"});
            this.comboBoxAgedPeriod.Properties.LookAndFeel.SkinName = "McSkin";
            this.comboBoxAgedPeriod.Properties.LookAndFeel.UseDefaultLookAndFeel = false;
            this.comboBoxAgedPeriod.Size = new System.Drawing.Size(325, 26);
            this.comboBoxAgedPeriod.TabIndex = 1;
            // 
            // comboBoxSortType
            // 
            this.comboBoxSortType.Location = new System.Drawing.Point(171, 143);
            this.comboBoxSortType.Name = "comboBoxSortType";
            this.comboBoxSortType.Properties.Appearance.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.comboBoxSortType.Properties.Appearance.Options.UseFont = true;
            this.comboBoxSortType.Properties.AppearanceDropDown.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.comboBoxSortType.Properties.AppearanceDropDown.Options.UseFont = true;
            this.comboBoxSortType.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.comboBoxSortType.Properties.Items.AddRange(new object[] {
            "Customer Number",
            "Due Date"});
            this.comboBoxSortType.Properties.LookAndFeel.SkinName = "McSkin";
            this.comboBoxSortType.Properties.LookAndFeel.UseDefaultLookAndFeel = false;
            this.comboBoxSortType.Size = new System.Drawing.Size(184, 26);
            this.comboBoxSortType.TabIndex = 7;
            // 
            // groupControl1
            // 
            this.groupControl1.Appearance.BackColor = System.Drawing.Color.LightSteelBlue;
            this.groupControl1.Appearance.Options.UseBackColor = true;
            this.groupControl1.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            this.groupControl1.Controls.Add(this.buttonPrint);
            this.groupControl1.Controls.Add(this.checkEditSortAndGroupDealerByState);
            this.groupControl1.Controls.Add(this.checkEditSortAndGroupDetailByState);
            this.groupControl1.Controls.Add(this.comboBoxSortType);
            this.groupControl1.Controls.Add(this.comboBoxAgedPeriod);
            this.groupControl1.Controls.Add(this.labelSortType);
            this.groupControl1.Controls.Add(this.checkBoxCollections);
            this.groupControl1.Controls.Add(this.labelAgedPeriod);
            this.groupControl1.Controls.Add(this.buttonCancel);
            this.groupControl1.Controls.Add(this.buttonPost);
            this.groupControl1.Controls.Add(this.labelLateNotices);
            this.groupControl1.Controls.Add(this.nullableDateTimePickerDueDate);
            this.groupControl1.Location = new System.Drawing.Point(0, 0);
            this.groupControl1.Name = "groupControl1";
            this.groupControl1.Size = new System.Drawing.Size(570, 501);
            this.groupControl1.TabIndex = 9;
            this.groupControl1.Text = "groupControl1";
            this.groupControl1.Paint += new System.Windows.Forms.PaintEventHandler(this.groupControl1_Paint);
            // 
            // checkEditSortAndGroupDealerByState
            // 
            this.checkEditSortAndGroupDealerByState.EditValue = true;
            this.checkEditSortAndGroupDealerByState.Location = new System.Drawing.Point(171, 199);
            this.checkEditSortAndGroupDealerByState.Name = "checkEditSortAndGroupDealerByState";
            this.checkEditSortAndGroupDealerByState.Properties.Appearance.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.checkEditSortAndGroupDealerByState.Properties.Appearance.Options.UseFont = true;
            this.checkEditSortAndGroupDealerByState.Properties.Caption = "Sort And Group Dealer Summary By State?";
            this.checkEditSortAndGroupDealerByState.Size = new System.Drawing.Size(348, 24);
            this.checkEditSortAndGroupDealerByState.TabIndex = 10;
            // 
            // checkEditSortAndGroupDetailByState
            // 
            this.checkEditSortAndGroupDetailByState.EditValue = true;
            this.checkEditSortAndGroupDetailByState.Location = new System.Drawing.Point(171, 176);
            this.checkEditSortAndGroupDetailByState.Name = "checkEditSortAndGroupDetailByState";
            this.checkEditSortAndGroupDetailByState.Properties.Appearance.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.checkEditSortAndGroupDetailByState.Properties.Appearance.Options.UseFont = true;
            this.checkEditSortAndGroupDetailByState.Properties.Caption = "Sort And Group Detail By State?";
            this.checkEditSortAndGroupDetailByState.Size = new System.Drawing.Size(261, 24);
            this.checkEditSortAndGroupDetailByState.TabIndex = 9;
            // 
            // buttonPrint
            // 
            this.buttonPrint.Appearance.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonPrint.Appearance.Options.UseFont = true;
            this.buttonPrint.ImageOptions.Image = global::IAC2021SQL.Properties.Resources.ExportToExcel_64x;
            this.buttonPrint.ImageOptions.ImageToTextAlignment = DevExpress.XtraEditors.ImageAlignToText.TopCenter;
            this.buttonPrint.ImageOptions.Location = DevExpress.XtraEditors.ImageLocation.MiddleCenter;
            this.buttonPrint.Location = new System.Drawing.Point(179, 307);
            this.buttonPrint.LookAndFeel.SkinName = "McSkin";
            this.buttonPrint.LookAndFeel.UseDefaultLookAndFeel = false;
            this.buttonPrint.Margin = new System.Windows.Forms.Padding(6, 8, 6, 8);
            this.buttonPrint.Name = "buttonPrint";
            this.buttonPrint.Size = new System.Drawing.Size(213, 154);
            this.buttonPrint.TabIndex = 25;
            this.buttonPrint.Text = "Dealer Summary To Excel";
            this.buttonPrint.Click += new System.EventHandler(this.buttonPrint_Click);
            // 
            // frmClosedDelinquencyReports
            // 
            this.Appearance.Options.UseFont = true;
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.ClientSize = new System.Drawing.Size(569, 501);
            this.Controls.Add(this.groupControl1);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "frmClosedDelinquencyReports";
            this.Text = "Closed Delinquency Reports";
            this.Load += new System.EventHandler(this.frmClosedDelinquencyReports_Load);
            ((System.ComponentModel.ISupportInitialize)(this.checkBoxCollections.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nullableDateTimePickerDueDate.Properties.CalendarTimeProperties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nullableDateTimePickerDueDate.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.comboBoxAgedPeriod.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.comboBoxSortType.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl1)).EndInit();
            this.groupControl1.ResumeLayout(false);
            this.groupControl1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.checkEditSortAndGroupDealerByState.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.checkEditSortAndGroupDetailByState.Properties)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraEditors.DateEdit nullableDateTimePickerDueDate;
        private System.Windows.Forms.Label labelLateNotices;
        private DevExpress.XtraEditors.SimpleButton buttonPost;
        private DevExpress.XtraEditors.SimpleButton buttonCancel;
        private System.Windows.Forms.Label labelAgedPeriod;
        private DevExpress.XtraEditors.CheckEdit checkBoxCollections;
        private System.Windows.Forms.Label labelSortType;
        private DevExpress.XtraEditors.ComboBoxEdit comboBoxAgedPeriod;
        private DevExpress.XtraEditors.ComboBoxEdit comboBoxSortType;
        private DevExpress.XtraEditors.GroupControl groupControl1;
        private DevExpress.XtraEditors.CheckEdit checkEditSortAndGroupDealerByState;
        private DevExpress.XtraEditors.CheckEdit checkEditSortAndGroupDetailByState;
        private DevExpress.XtraEditors.SimpleButton buttonPrint;
    }
}
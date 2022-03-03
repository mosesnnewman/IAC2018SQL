namespace IAC2021SQL
{
    partial class frmOpenStatements
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
            this.components = new System.ComponentModel.Container();
            this.labelLateNotices = new System.Windows.Forms.Label();
            this.buttonPost = new DevExpress.XtraEditors.SimpleButton();
            this.buttonCancel = new DevExpress.XtraEditors.SimpleButton();
            this.StatementDataSet = new IAC2021SQL.IACDataSet();
            this.StatementbindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.opncustTableAdapter = new IAC2021SQL.IACDataSetTableAdapters.OPNCUSTTableAdapter();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.groupControlStatements = new DevExpress.XtraEditors.GroupControl();
            this.LastClosingDatenullableDateTimePicker = new DevExpress.XtraEditors.DateEdit();
            this.StatementDatenullableDateTimePicker = new DevExpress.XtraEditors.DateEdit();
            this.ClosingDatenullableDateTimePicker = new DevExpress.XtraEditors.DateEdit();
            ((System.ComponentModel.ISupportInitialize)(this.StatementDataSet)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.StatementbindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.groupControlStatements)).BeginInit();
            this.groupControlStatements.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.LastClosingDatenullableDateTimePicker.Properties.CalendarTimeProperties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.LastClosingDatenullableDateTimePicker.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.StatementDatenullableDateTimePicker.Properties.CalendarTimeProperties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.StatementDatenullableDateTimePicker.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ClosingDatenullableDateTimePicker.Properties.CalendarTimeProperties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ClosingDatenullableDateTimePicker.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // labelLateNotices
            // 
            this.labelLateNotices.AutoSize = true;
            this.labelLateNotices.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelLateNotices.Location = new System.Drawing.Point(111, 58);
            this.labelLateNotices.Name = "labelLateNotices";
            this.labelLateNotices.Size = new System.Drawing.Size(101, 21);
            this.labelLateNotices.TabIndex = 1;
            this.labelLateNotices.Text = "Closing Date:";
            this.labelLateNotices.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // buttonPost
            // 
            this.buttonPost.Appearance.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonPost.Appearance.Options.UseFont = true;
            this.buttonPost.Location = new System.Drawing.Point(108, 142);
            this.buttonPost.Name = "buttonPost";
            this.buttonPost.Size = new System.Drawing.Size(75, 43);
            this.buttonPost.TabIndex = 5;
            this.buttonPost.Text = "&Post";
            this.buttonPost.Click += new System.EventHandler(this.buttonPost_Click);
            // 
            // buttonCancel
            // 
            this.buttonCancel.Appearance.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonCancel.Appearance.Options.UseFont = true;
            this.buttonCancel.Location = new System.Drawing.Point(197, 142);
            this.buttonCancel.Name = "buttonCancel";
            this.buttonCancel.Size = new System.Drawing.Size(75, 43);
            this.buttonCancel.TabIndex = 6;
            this.buttonCancel.Text = "&Cancel";
            this.buttonCancel.Click += new System.EventHandler(this.buttonCancel_Click);
            // 
            // StatementDataSet
            // 
            this.StatementDataSet.DataSetName = "IACDataSet";
            this.StatementDataSet.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // StatementbindingSource
            // 
            this.StatementbindingSource.DataMember = "OPNNOT";
            this.StatementbindingSource.DataSource = this.StatementDataSet;
            // 
            // opncustTableAdapter
            // 
            this.opncustTableAdapter.ClearBeforeFill = true;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(93, 88);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(119, 21);
            this.label1.TabIndex = 5;
            this.label1.Text = "Statement Date:";
            this.label1.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(79, 28);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(133, 21);
            this.label2.TabIndex = 7;
            this.label2.Text = "Last Closing Date:";
            this.label2.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // groupControlStatements
            // 
            this.groupControlStatements.Appearance.BackColor = System.Drawing.Color.LightSteelBlue;
            this.groupControlStatements.Appearance.Options.UseBackColor = true;
            this.groupControlStatements.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            this.groupControlStatements.Controls.Add(this.label2);
            this.groupControlStatements.Controls.Add(this.LastClosingDatenullableDateTimePicker);
            this.groupControlStatements.Controls.Add(this.label1);
            this.groupControlStatements.Controls.Add(this.StatementDatenullableDateTimePicker);
            this.groupControlStatements.Controls.Add(this.buttonCancel);
            this.groupControlStatements.Controls.Add(this.buttonPost);
            this.groupControlStatements.Controls.Add(this.labelLateNotices);
            this.groupControlStatements.Controls.Add(this.ClosingDatenullableDateTimePicker);
            this.groupControlStatements.Location = new System.Drawing.Point(0, 0);
            this.groupControlStatements.Name = "groupControlStatements";
            this.groupControlStatements.Size = new System.Drawing.Size(381, 207);
            this.groupControlStatements.TabIndex = 8;
            this.groupControlStatements.Text = "groupControl1";
            // 
            // LastClosingDatenullableDateTimePicker
            // 
            this.LastClosingDatenullableDateTimePicker.EditValue = new System.DateTime(2021, 9, 7, 0, 0, 0, 0);
            this.LastClosingDatenullableDateTimePicker.Location = new System.Drawing.Point(218, 21);
            this.LastClosingDatenullableDateTimePicker.Name = "LastClosingDatenullableDateTimePicker";
            this.LastClosingDatenullableDateTimePicker.Properties.Appearance.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LastClosingDatenullableDateTimePicker.Properties.Appearance.Options.UseFont = true;
            this.LastClosingDatenullableDateTimePicker.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.LastClosingDatenullableDateTimePicker.Properties.CalendarTimeProperties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.LastClosingDatenullableDateTimePicker.Properties.CalendarView = DevExpress.XtraEditors.Repository.CalendarView.Fluent;
            this.LastClosingDatenullableDateTimePicker.Properties.LookAndFeel.SkinName = "McSkin";
            this.LastClosingDatenullableDateTimePicker.Properties.LookAndFeel.UseDefaultLookAndFeel = false;
            this.LastClosingDatenullableDateTimePicker.Properties.VistaDisplayMode = DevExpress.Utils.DefaultBoolean.False;
            this.LastClosingDatenullableDateTimePicker.Size = new System.Drawing.Size(113, 28);
            this.LastClosingDatenullableDateTimePicker.TabIndex = 1;
            // 
            // StatementDatenullableDateTimePicker
            // 
            this.StatementDatenullableDateTimePicker.EditValue = new System.DateTime(2021, 9, 7, 0, 0, 0, 0);
            this.StatementDatenullableDateTimePicker.Location = new System.Drawing.Point(218, 81);
            this.StatementDatenullableDateTimePicker.Name = "StatementDatenullableDateTimePicker";
            this.StatementDatenullableDateTimePicker.Properties.Appearance.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.StatementDatenullableDateTimePicker.Properties.Appearance.Options.UseFont = true;
            this.StatementDatenullableDateTimePicker.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.StatementDatenullableDateTimePicker.Properties.CalendarTimeProperties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.StatementDatenullableDateTimePicker.Properties.CalendarView = DevExpress.XtraEditors.Repository.CalendarView.Fluent;
            this.StatementDatenullableDateTimePicker.Properties.LookAndFeel.SkinName = "McSkin";
            this.StatementDatenullableDateTimePicker.Properties.LookAndFeel.UseDefaultLookAndFeel = false;
            this.StatementDatenullableDateTimePicker.Properties.VistaDisplayMode = DevExpress.Utils.DefaultBoolean.False;
            this.StatementDatenullableDateTimePicker.Size = new System.Drawing.Size(113, 28);
            this.StatementDatenullableDateTimePicker.TabIndex = 3;
            // 
            // ClosingDatenullableDateTimePicker
            // 
            this.ClosingDatenullableDateTimePicker.EditValue = new System.DateTime(2021, 9, 7, 0, 0, 0, 0);
            this.ClosingDatenullableDateTimePicker.Location = new System.Drawing.Point(218, 51);
            this.ClosingDatenullableDateTimePicker.Name = "ClosingDatenullableDateTimePicker";
            this.ClosingDatenullableDateTimePicker.Properties.Appearance.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ClosingDatenullableDateTimePicker.Properties.Appearance.Options.UseFont = true;
            this.ClosingDatenullableDateTimePicker.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.ClosingDatenullableDateTimePicker.Properties.CalendarTimeProperties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.ClosingDatenullableDateTimePicker.Properties.CalendarView = DevExpress.XtraEditors.Repository.CalendarView.Fluent;
            this.ClosingDatenullableDateTimePicker.Properties.LookAndFeel.SkinName = "McSkin";
            this.ClosingDatenullableDateTimePicker.Properties.LookAndFeel.UseDefaultLookAndFeel = false;
            this.ClosingDatenullableDateTimePicker.Properties.VistaDisplayMode = DevExpress.Utils.DefaultBoolean.False;
            this.ClosingDatenullableDateTimePicker.Size = new System.Drawing.Size(113, 28);
            this.ClosingDatenullableDateTimePicker.TabIndex = 2;
            this.ClosingDatenullableDateTimePicker.Validated += new System.EventHandler(this.NoticeDatenullableDateTimePicker_Validated);
            // 
            // frmOpenStatements
            // 
            this.Appearance.Options.UseFont = true;
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.ClientSize = new System.Drawing.Size(379, 206);
            this.Controls.Add(this.groupControlStatements);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Name = "frmOpenStatements";
            this.Text = "Open End Statements";
            this.Load += new System.EventHandler(this.frmOpenStatements_Load);
            ((System.ComponentModel.ISupportInitialize)(this.StatementDataSet)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.StatementbindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.groupControlStatements)).EndInit();
            this.groupControlStatements.ResumeLayout(false);
            this.groupControlStatements.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.LastClosingDatenullableDateTimePicker.Properties.CalendarTimeProperties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.LastClosingDatenullableDateTimePicker.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.StatementDatenullableDateTimePicker.Properties.CalendarTimeProperties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.StatementDatenullableDateTimePicker.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ClosingDatenullableDateTimePicker.Properties.CalendarTimeProperties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ClosingDatenullableDateTimePicker.Properties)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraEditors.DateEdit ClosingDatenullableDateTimePicker;
        private System.Windows.Forms.Label labelLateNotices;
        private DevExpress.XtraEditors.SimpleButton buttonPost;
        private DevExpress.XtraEditors.SimpleButton buttonCancel;
        private IACDataSet StatementDataSet;
        private System.Windows.Forms.BindingSource StatementbindingSource;
        private IACDataSetTableAdapters.OPNCUSTTableAdapter opncustTableAdapter;
        private System.Windows.Forms.Label label1;
        private DevExpress.XtraEditors.DateEdit StatementDatenullableDateTimePicker;
        private System.Windows.Forms.Label label2;
        private DevExpress.XtraEditors.DateEdit LastClosingDatenullableDateTimePicker;
        private DevExpress.XtraEditors.GroupControl groupControlStatements;
    }
}
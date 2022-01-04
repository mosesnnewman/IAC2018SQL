namespace IAC2021SQL
{
    partial class frmNotices
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
            this.NoticeiacDataSet = new IAC2021SQL.IACDataSet();
            this.NoticebindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.nOTICETableAdapter = new IAC2021SQL.IACDataSetTableAdapters.NOTICETableAdapter();
            this.customerTableAdapter = new IAC2021SQL.IACDataSetTableAdapters.CUSTOMERTableAdapter();
            this.buttonPost = new DevExpress.XtraEditors.SimpleButton();
            this.buttonCancel = new DevExpress.XtraEditors.SimpleButton();
            this.NoticeDatenullableDateTimePicker = new DevExpress.XtraEditors.DateEdit();
            ((System.ComponentModel.ISupportInitialize)(this.NoticeiacDataSet)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.NoticebindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.NoticeDatenullableDateTimePicker.Properties.CalendarTimeProperties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.NoticeDatenullableDateTimePicker.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // NoticeiacDataSet
            // 
            this.NoticeiacDataSet.DataSetName = "IACDataSet";
            this.NoticeiacDataSet.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // NoticebindingSource
            // 
            this.NoticebindingSource.DataMember = "NOTICE";
            this.NoticebindingSource.DataSource = this.NoticeiacDataSet;
            // 
            // nOTICETableAdapter
            // 
            this.nOTICETableAdapter.ClearBeforeFill = true;
            // 
            // customerTableAdapter
            // 
            this.customerTableAdapter.ClearBeforeFill = true;
            // 
            // buttonPost
            // 
            this.buttonPost.Appearance.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonPost.Appearance.Options.UseFont = true;
            this.buttonPost.Location = new System.Drawing.Point(58, 108);
            this.buttonPost.LookAndFeel.SkinName = "McSkin";
            this.buttonPost.LookAndFeel.UseDefaultLookAndFeel = false;
            this.buttonPost.Name = "buttonPost";
            this.buttonPost.Size = new System.Drawing.Size(122, 39);
            this.buttonPost.TabIndex = 1;
            this.buttonPost.Text = "&Post";
            this.buttonPost.Click += new System.EventHandler(this.buttonPost_Click);
            // 
            // buttonCancel
            // 
            this.buttonCancel.Appearance.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonCancel.Appearance.Options.UseFont = true;
            this.buttonCancel.Location = new System.Drawing.Point(198, 108);
            this.buttonCancel.LookAndFeel.SkinName = "McSkin";
            this.buttonCancel.LookAndFeel.UseDefaultLookAndFeel = false;
            this.buttonCancel.Name = "buttonCancel";
            this.buttonCancel.Size = new System.Drawing.Size(122, 39);
            this.buttonCancel.TabIndex = 2;
            this.buttonCancel.Text = "&Cancel";
            this.buttonCancel.Click += new System.EventHandler(this.buttonCancel_Click);
            // 
            // NoticeDatenullableDateTimePicker
            // 
            this.NoticeDatenullableDateTimePicker.EditValue = new System.DateTime(2021, 12, 27, 11, 0, 15, 272);
            this.NoticeDatenullableDateTimePicker.Location = new System.Drawing.Point(135, 36);
            this.NoticeDatenullableDateTimePicker.Name = "NoticeDatenullableDateTimePicker";
            this.NoticeDatenullableDateTimePicker.Properties.AdvancedModeOptions.AllowCaretAnimation = DevExpress.Utils.DefaultBoolean.True;
            this.NoticeDatenullableDateTimePicker.Properties.AdvancedModeOptions.AllowSelectionAnimation = DevExpress.Utils.DefaultBoolean.True;
            this.NoticeDatenullableDateTimePicker.Properties.AdvancedModeOptions.Label = "Notice Date";
            this.NoticeDatenullableDateTimePicker.Properties.Appearance.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.NoticeDatenullableDateTimePicker.Properties.Appearance.Options.UseFont = true;
            this.NoticeDatenullableDateTimePicker.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.NoticeDatenullableDateTimePicker.Properties.CalendarTimeProperties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.NoticeDatenullableDateTimePicker.Properties.CalendarView = DevExpress.XtraEditors.Repository.CalendarView.Fluent;
            this.NoticeDatenullableDateTimePicker.Properties.LookAndFeel.SkinName = "McSkin";
            this.NoticeDatenullableDateTimePicker.Properties.LookAndFeel.UseDefaultLookAndFeel = false;
            this.NoticeDatenullableDateTimePicker.Properties.UseAdvancedMode = DevExpress.Utils.DefaultBoolean.True;
            this.NoticeDatenullableDateTimePicker.Properties.VistaDisplayMode = DevExpress.Utils.DefaultBoolean.False;
            this.NoticeDatenullableDateTimePicker.Size = new System.Drawing.Size(109, 40);
            this.NoticeDatenullableDateTimePicker.TabIndex = 14;
            this.NoticeDatenullableDateTimePicker.Validated += new System.EventHandler(this.NoticeDatenullableDateTimePicker_Validated);
            // 
            // frmNotices
            // 
            this.Appearance.BackColor = System.Drawing.Color.LightSteelBlue;
            this.Appearance.Options.UseBackColor = true;
            this.Appearance.Options.UseFont = true;
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.ClientSize = new System.Drawing.Size(379, 183);
            this.ControlBox = false;
            this.Controls.Add(this.NoticeDatenullableDateTimePicker);
            this.Controls.Add(this.buttonCancel);
            this.Controls.Add(this.buttonPost);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Name = "frmNotices";
            this.Text = "Closed End Notices";
            this.Load += new System.EventHandler(this.frmNotices_Load);
            ((System.ComponentModel.ISupportInitialize)(this.NoticeiacDataSet)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.NoticebindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.NoticeDatenullableDateTimePicker.Properties.CalendarTimeProperties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.NoticeDatenullableDateTimePicker.Properties)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private IACDataSet NoticeiacDataSet;
        private System.Windows.Forms.BindingSource NoticebindingSource;
        private IACDataSetTableAdapters.NOTICETableAdapter nOTICETableAdapter;
        private IACDataSetTableAdapters.CUSTOMERTableAdapter customerTableAdapter;
        private DevExpress.XtraEditors.SimpleButton buttonPost;
        private DevExpress.XtraEditors.SimpleButton buttonCancel;
        private DevExpress.XtraEditors.DateEdit NoticeDatenullableDateTimePicker;
    }
}
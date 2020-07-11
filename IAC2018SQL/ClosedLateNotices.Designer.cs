namespace IAC2018SQL
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
            this.NoticeDatenullableDateTimePicker = new ProManApp.NullableDateTimePicker();
            this.labelLateNotices = new System.Windows.Forms.Label();
            this.buttonPost = new System.Windows.Forms.Button();
            this.buttonCancel = new System.Windows.Forms.Button();
            this.NoticeiacDataSet = new IAC2018SQL.IACDataSet();
            this.NoticebindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.nOTICETableAdapter = new IAC2018SQL.IACDataSetTableAdapters.NOTICETableAdapter();
            this.customerTableAdapter = new IAC2018SQL.IACDataSetTableAdapters.CUSTOMERTableAdapter();
            ((System.ComponentModel.ISupportInitialize)(this.NoticeDatenullableDateTimePicker)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.NoticeiacDataSet)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.NoticebindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // NoticeDatenullableDateTimePicker
            // 
            this.NoticeDatenullableDateTimePicker.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.NoticeDatenullableDateTimePicker.Location = new System.Drawing.Point(198, 49);
            this.NoticeDatenullableDateTimePicker.Name = "NoticeDatenullableDateTimePicker";
            this.NoticeDatenullableDateTimePicker.Size = new System.Drawing.Size(83, 20);
            this.NoticeDatenullableDateTimePicker.TabIndex = 0;
            this.NoticeDatenullableDateTimePicker.Value = new System.DateTime(2013, 8, 5, 0, 0, 0, 0);
            this.NoticeDatenullableDateTimePicker.Validated += new System.EventHandler(this.NoticeDatenullableDateTimePicker_Validated);
            // 
            // labelLateNotices
            // 
            this.labelLateNotices.AutoSize = true;
            this.labelLateNotices.Location = new System.Drawing.Point(98, 58);
            this.labelLateNotices.Name = "labelLateNotices";
            this.labelLateNotices.Size = new System.Drawing.Size(91, 13);
            this.labelLateNotices.TabIndex = 1;
            this.labelLateNotices.Text = "Late Notice Date:";
            this.labelLateNotices.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // buttonPost
            // 
            this.buttonPost.Location = new System.Drawing.Point(111, 110);
            this.buttonPost.Name = "buttonPost";
            this.buttonPost.Size = new System.Drawing.Size(75, 23);
            this.buttonPost.TabIndex = 2;
            this.buttonPost.Text = "&Post";
            this.buttonPost.UseVisualStyleBackColor = true;
            this.buttonPost.Click += new System.EventHandler(this.buttonPost_Click);
            // 
            // buttonCancel
            // 
            this.buttonCancel.Location = new System.Drawing.Point(192, 110);
            this.buttonCancel.Name = "buttonCancel";
            this.buttonCancel.Size = new System.Drawing.Size(75, 23);
            this.buttonCancel.TabIndex = 3;
            this.buttonCancel.Text = "&Cancel";
            this.buttonCancel.UseVisualStyleBackColor = true;
            this.buttonCancel.Click += new System.EventHandler(this.buttonCancel_Click);
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
            // frmNotices
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.BackColor = System.Drawing.Color.LightSteelBlue;
            this.ClientSize = new System.Drawing.Size(379, 183);
            this.Controls.Add(this.buttonCancel);
            this.Controls.Add(this.buttonPost);
            this.Controls.Add(this.labelLateNotices);
            this.Controls.Add(this.NoticeDatenullableDateTimePicker);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Name = "frmNotices";
            this.Text = "Closed End Notices";
            this.Load += new System.EventHandler(this.frmNotices_Load);
            ((System.ComponentModel.ISupportInitialize)(this.NoticeDatenullableDateTimePicker)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.NoticeiacDataSet)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.NoticebindingSource)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private ProManApp.NullableDateTimePicker NoticeDatenullableDateTimePicker;
        private System.Windows.Forms.Label labelLateNotices;
        private System.Windows.Forms.Button buttonPost;
        private System.Windows.Forms.Button buttonCancel;
        private IACDataSet NoticeiacDataSet;
        private System.Windows.Forms.BindingSource NoticebindingSource;
        private IACDataSetTableAdapters.NOTICETableAdapter nOTICETableAdapter;
        private IACDataSetTableAdapters.CUSTOMERTableAdapter customerTableAdapter;
    }
}
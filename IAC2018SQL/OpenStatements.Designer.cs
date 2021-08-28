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
            this.ClosingDatenullableDateTimePicker = new ProManApp.NullableDateTimePicker();
            this.labelLateNotices = new System.Windows.Forms.Label();
            this.buttonPost = new System.Windows.Forms.Button();
            this.buttonCancel = new System.Windows.Forms.Button();
            this.StatementDataSet = new IAC2021SQL.IACDataSet();
            this.StatementbindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.opncustTableAdapter = new IAC2021SQL.IACDataSetTableAdapters.OPNCUSTTableAdapter();
            this.label1 = new System.Windows.Forms.Label();
            this.StatementDatenullableDateTimePicker = new ProManApp.NullableDateTimePicker();
            this.label2 = new System.Windows.Forms.Label();
            this.LastClosingDatenullableDateTimePicker = new ProManApp.NullableDateTimePicker();
            ((System.ComponentModel.ISupportInitialize)(this.ClosingDatenullableDateTimePicker)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.StatementDataSet)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.StatementbindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.StatementDatenullableDateTimePicker)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.LastClosingDatenullableDateTimePicker)).BeginInit();
            this.SuspendLayout();
            // 
            // ClosingDatenullableDateTimePicker
            // 
            this.ClosingDatenullableDateTimePicker.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.ClosingDatenullableDateTimePicker.Location = new System.Drawing.Point(206, 59);
            this.ClosingDatenullableDateTimePicker.Name = "ClosingDatenullableDateTimePicker";
            this.ClosingDatenullableDateTimePicker.Size = new System.Drawing.Size(83, 20);
            this.ClosingDatenullableDateTimePicker.TabIndex = 2;
            this.ClosingDatenullableDateTimePicker.Value = new System.DateTime(2013, 8, 5, 0, 0, 0, 0);
            this.ClosingDatenullableDateTimePicker.Validated += new System.EventHandler(this.NoticeDatenullableDateTimePicker_Validated);
            // 
            // labelLateNotices
            // 
            this.labelLateNotices.AutoSize = true;
            this.labelLateNotices.Location = new System.Drawing.Point(127, 68);
            this.labelLateNotices.Name = "labelLateNotices";
            this.labelLateNotices.Size = new System.Drawing.Size(70, 13);
            this.labelLateNotices.TabIndex = 1;
            this.labelLateNotices.Text = "Closing Date:";
            this.labelLateNotices.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // buttonPost
            // 
            this.buttonPost.Location = new System.Drawing.Point(111, 151);
            this.buttonPost.Name = "buttonPost";
            this.buttonPost.Size = new System.Drawing.Size(75, 23);
            this.buttonPost.TabIndex = 5;
            this.buttonPost.Text = "&Post";
            this.buttonPost.UseVisualStyleBackColor = true;
            this.buttonPost.Click += new System.EventHandler(this.buttonPost_Click);
            // 
            // buttonCancel
            // 
            this.buttonCancel.Location = new System.Drawing.Point(192, 151);
            this.buttonCancel.Name = "buttonCancel";
            this.buttonCancel.Size = new System.Drawing.Size(75, 23);
            this.buttonCancel.TabIndex = 6;
            this.buttonCancel.Text = "&Cancel";
            this.buttonCancel.UseVisualStyleBackColor = true;
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
            this.label1.Location = new System.Drawing.Point(114, 99);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(84, 13);
            this.label1.TabIndex = 5;
            this.label1.Text = "Statement Date:";
            this.label1.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // StatementDatenullableDateTimePicker
            // 
            this.StatementDatenullableDateTimePicker.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.StatementDatenullableDateTimePicker.Location = new System.Drawing.Point(206, 90);
            this.StatementDatenullableDateTimePicker.Name = "StatementDatenullableDateTimePicker";
            this.StatementDatenullableDateTimePicker.Size = new System.Drawing.Size(83, 20);
            this.StatementDatenullableDateTimePicker.TabIndex = 3;
            this.StatementDatenullableDateTimePicker.Value = new System.DateTime(2013, 8, 5, 0, 0, 0, 0);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(104, 39);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(93, 13);
            this.label2.TabIndex = 7;
            this.label2.Text = "Last Closing Date:";
            this.label2.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // LastClosingDatenullableDateTimePicker
            // 
            this.LastClosingDatenullableDateTimePicker.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.LastClosingDatenullableDateTimePicker.Location = new System.Drawing.Point(206, 30);
            this.LastClosingDatenullableDateTimePicker.Name = "LastClosingDatenullableDateTimePicker";
            this.LastClosingDatenullableDateTimePicker.Size = new System.Drawing.Size(83, 20);
            this.LastClosingDatenullableDateTimePicker.TabIndex = 1;
            this.LastClosingDatenullableDateTimePicker.Value = new System.DateTime(2013, 8, 5, 0, 0, 0, 0);
            // 
            // frmOpenStatements
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.BackColor = System.Drawing.Color.LightSteelBlue;
            this.ClientSize = new System.Drawing.Size(379, 206);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.LastClosingDatenullableDateTimePicker);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.StatementDatenullableDateTimePicker);
            this.Controls.Add(this.buttonCancel);
            this.Controls.Add(this.buttonPost);
            this.Controls.Add(this.labelLateNotices);
            this.Controls.Add(this.ClosingDatenullableDateTimePicker);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Name = "frmOpenStatements";
            this.Text = "Open End Statements";
            ((System.ComponentModel.ISupportInitialize)(this.ClosingDatenullableDateTimePicker)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.StatementDataSet)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.StatementbindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.StatementDatenullableDateTimePicker)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.LastClosingDatenullableDateTimePicker)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private ProManApp.NullableDateTimePicker ClosingDatenullableDateTimePicker;
        private System.Windows.Forms.Label labelLateNotices;
        private System.Windows.Forms.Button buttonPost;
        private System.Windows.Forms.Button buttonCancel;
        private IACDataSet StatementDataSet;
        private System.Windows.Forms.BindingSource StatementbindingSource;
        private IACDataSetTableAdapters.OPNCUSTTableAdapter opncustTableAdapter;
        private System.Windows.Forms.Label label1;
        private ProManApp.NullableDateTimePicker StatementDatenullableDateTimePicker;
        private System.Windows.Forms.Label label2;
        private ProManApp.NullableDateTimePicker LastClosingDatenullableDateTimePicker;
    }
}
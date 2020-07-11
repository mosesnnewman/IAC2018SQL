namespace IAC2018SQL
{
    partial class frmOpenDealerSummaryReport
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
            this.buttonPost = new System.Windows.Forms.Button();
            this.buttonCancel = new System.Windows.Forms.Button();
            this.labelRunMonth = new System.Windows.Forms.Label();
            this.monthNamesBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.iACDataSet = new IAC2018SQL.IACDataSet();
            this.monthNamesTableAdapter = new IAC2018SQL.IACDataSetTableAdapters.MonthNamesTableAdapter();
            this.labelRunYear = new System.Windows.Forms.Label();
            this.textBoxRunYear = new System.Windows.Forms.TextBox();
            this.comboBoxRunMonth = new System.Windows.Forms.ComboBox();
            ((System.ComponentModel.ISupportInitialize)(this.monthNamesBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.iACDataSet)).BeginInit();
            this.SuspendLayout();
            // 
            // buttonPost
            // 
            this.buttonPost.Location = new System.Drawing.Point(140, 112);
            this.buttonPost.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.buttonPost.Name = "buttonPost";
            this.buttonPost.Size = new System.Drawing.Size(112, 35);
            this.buttonPost.TabIndex = 5;
            this.buttonPost.Text = "&Print";
            this.buttonPost.UseVisualStyleBackColor = true;
            this.buttonPost.Click += new System.EventHandler(this.buttonPost_Click);
            // 
            // buttonCancel
            // 
            this.buttonCancel.Location = new System.Drawing.Point(261, 112);
            this.buttonCancel.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.buttonCancel.Name = "buttonCancel";
            this.buttonCancel.Size = new System.Drawing.Size(112, 35);
            this.buttonCancel.TabIndex = 6;
            this.buttonCancel.Text = "&Cancel";
            this.buttonCancel.UseVisualStyleBackColor = true;
            this.buttonCancel.Click += new System.EventHandler(this.buttonCancel_Click);
            // 
            // labelRunMonth
            // 
            this.labelRunMonth.AutoSize = true;
            this.labelRunMonth.Location = new System.Drawing.Point(102, 46);
            this.labelRunMonth.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.labelRunMonth.Name = "labelRunMonth";
            this.labelRunMonth.Size = new System.Drawing.Size(92, 20);
            this.labelRunMonth.TabIndex = 5;
            this.labelRunMonth.Text = "Run Month:";
            this.labelRunMonth.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // monthNamesBindingSource
            // 
            this.monthNamesBindingSource.DataMember = "MonthNames";
            this.monthNamesBindingSource.DataSource = this.iACDataSet;
            // 
            // iACDataSet
            // 
            this.iACDataSet.DataSetName = "IACDataSet";
            this.iACDataSet.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // monthNamesTableAdapter
            // 
            this.monthNamesTableAdapter.ClearBeforeFill = true;
            // 
            // labelRunYear
            // 
            this.labelRunYear.AutoSize = true;
            this.labelRunYear.Location = new System.Drawing.Point(114, 72);
            this.labelRunYear.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.labelRunYear.Name = "labelRunYear";
            this.labelRunYear.Size = new System.Drawing.Size(81, 20);
            this.labelRunYear.TabIndex = 8;
            this.labelRunYear.Text = "Run Year:";
            this.labelRunYear.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // textBoxRunYear
            // 
            this.textBoxRunYear.Location = new System.Drawing.Point(207, 72);
            this.textBoxRunYear.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.textBoxRunYear.MaxLength = 4;
            this.textBoxRunYear.Name = "textBoxRunYear";
            this.textBoxRunYear.Size = new System.Drawing.Size(79, 26);
            this.textBoxRunYear.TabIndex = 9;
            this.textBoxRunYear.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // comboBoxRunMonth
            // 
            this.comboBoxRunMonth.DataSource = this.monthNamesBindingSource;
            this.comboBoxRunMonth.DisplayMember = "MonthName";
            this.comboBoxRunMonth.FormattingEnabled = true;
            this.comboBoxRunMonth.Location = new System.Drawing.Point(207, 34);
            this.comboBoxRunMonth.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.comboBoxRunMonth.Name = "comboBoxRunMonth";
            this.comboBoxRunMonth.Size = new System.Drawing.Size(124, 28);
            this.comboBoxRunMonth.TabIndex = 10;
            this.comboBoxRunMonth.ValueMember = "MonthNumber";
            // 
            // frmOpenDealerSummaryReport
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.BackColor = System.Drawing.Color.LightSteelBlue;
            this.ClientSize = new System.Drawing.Size(474, 182);
            this.Controls.Add(this.comboBoxRunMonth);
            this.Controls.Add(this.textBoxRunYear);
            this.Controls.Add(this.labelRunYear);
            this.Controls.Add(this.labelRunMonth);
            this.Controls.Add(this.buttonCancel);
            this.Controls.Add(this.buttonPost);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.Name = "frmOpenDealerSummaryReport";
            this.Text = "Print Open Dealer Summary Report (26)";
            this.Load += new System.EventHandler(this.frmOpenDealerSummaryReport_Load);
            ((System.ComponentModel.ISupportInitialize)(this.monthNamesBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.iACDataSet)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button buttonPost;
        private System.Windows.Forms.Button buttonCancel;
        private System.Windows.Forms.Label labelRunMonth;
        private IACDataSet iACDataSet;
        private System.Windows.Forms.BindingSource monthNamesBindingSource;
        private IACDataSetTableAdapters.MonthNamesTableAdapter monthNamesTableAdapter;
        private System.Windows.Forms.Label labelRunYear;
        private System.Windows.Forms.TextBox textBoxRunYear;
        private System.Windows.Forms.ComboBox comboBoxRunMonth;
    }
}
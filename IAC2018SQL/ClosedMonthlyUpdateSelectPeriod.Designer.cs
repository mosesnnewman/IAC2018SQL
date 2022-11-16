namespace IAC2021SQL
{
    partial class frmClosedMonthlyUpdateSelectPeriod
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
            this.buttonPost = new DevExpress.XtraEditors.SimpleButton();
            this.buttonCancel = new DevExpress.XtraEditors.SimpleButton();
            this.labelRunMonth = new System.Windows.Forms.Label();
            this.monthNamesBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.iACDataSet = new IAC2021SQL.IACDataSet();
            this.monthNamesTableAdapter = new IAC2021SQL.IACDataSetTableAdapters.MonthNamesTableAdapter();
            this.labelRunYear = new System.Windows.Forms.Label();
            this.textBoxRunYear = new System.Windows.Forms.TextBox();
            this.comboBoxRunMonth = new System.Windows.Forms.ComboBox();
            this.groupControl1 = new DevExpress.XtraEditors.GroupControl();
            ((System.ComponentModel.ISupportInitialize)(this.monthNamesBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.iACDataSet)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl1)).BeginInit();
            this.groupControl1.SuspendLayout();
            this.SuspendLayout();
            // 
            // buttonPost
            // 
            this.buttonPost.Appearance.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonPost.Appearance.Options.UseFont = true;
            this.buttonPost.Location = new System.Drawing.Point(120, 115);
            this.buttonPost.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.buttonPost.Name = "buttonPost";
            this.buttonPost.Size = new System.Drawing.Size(112, 35);
            this.buttonPost.TabIndex = 5;
            this.buttonPost.Text = "&Print";
            this.buttonPost.Click += new System.EventHandler(this.buttonPost_Click);
            // 
            // buttonCancel
            // 
            this.buttonCancel.Appearance.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonCancel.Appearance.Options.UseFont = true;
            this.buttonCancel.Location = new System.Drawing.Point(241, 115);
            this.buttonCancel.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.buttonCancel.Name = "buttonCancel";
            this.buttonCancel.Size = new System.Drawing.Size(112, 35);
            this.buttonCancel.TabIndex = 6;
            this.buttonCancel.Text = "&Cancel";
            this.buttonCancel.Click += new System.EventHandler(this.buttonCancel_Click);
            // 
            // labelRunMonth
            // 
            this.labelRunMonth.AutoSize = true;
            this.labelRunMonth.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelRunMonth.Location = new System.Drawing.Point(133, 45);
            this.labelRunMonth.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.labelRunMonth.Name = "labelRunMonth";
            this.labelRunMonth.Size = new System.Drawing.Size(91, 21);
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
            this.labelRunYear.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelRunYear.Location = new System.Drawing.Point(149, 83);
            this.labelRunYear.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.labelRunYear.Name = "labelRunYear";
            this.labelRunYear.Size = new System.Drawing.Size(75, 21);
            this.labelRunYear.TabIndex = 8;
            this.labelRunYear.Text = "Run Year:";
            this.labelRunYear.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // textBoxRunYear
            // 
            this.textBoxRunYear.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBoxRunYear.Location = new System.Drawing.Point(227, 75);
            this.textBoxRunYear.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.textBoxRunYear.MaxLength = 4;
            this.textBoxRunYear.Name = "textBoxRunYear";
            this.textBoxRunYear.Size = new System.Drawing.Size(79, 29);
            this.textBoxRunYear.TabIndex = 9;
            this.textBoxRunYear.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // comboBoxRunMonth
            // 
            this.comboBoxRunMonth.DataSource = this.monthNamesBindingSource;
            this.comboBoxRunMonth.DisplayMember = "MonthName";
            this.comboBoxRunMonth.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.comboBoxRunMonth.FormattingEnabled = true;
            this.comboBoxRunMonth.Location = new System.Drawing.Point(227, 37);
            this.comboBoxRunMonth.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.comboBoxRunMonth.Name = "comboBoxRunMonth";
            this.comboBoxRunMonth.Size = new System.Drawing.Size(124, 29);
            this.comboBoxRunMonth.TabIndex = 10;
            this.comboBoxRunMonth.ValueMember = "MonthNumber";
            // 
            // groupControl1
            // 
            this.groupControl1.Appearance.BackColor = System.Drawing.Color.LightSteelBlue;
            this.groupControl1.Appearance.Options.UseBackColor = true;
            this.groupControl1.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            this.groupControl1.Controls.Add(this.comboBoxRunMonth);
            this.groupControl1.Controls.Add(this.textBoxRunYear);
            this.groupControl1.Controls.Add(this.labelRunYear);
            this.groupControl1.Controls.Add(this.labelRunMonth);
            this.groupControl1.Controls.Add(this.buttonCancel);
            this.groupControl1.Controls.Add(this.buttonPost);
            this.groupControl1.Location = new System.Drawing.Point(1, -4);
            this.groupControl1.Name = "groupControl1";
            this.groupControl1.Size = new System.Drawing.Size(473, 187);
            this.groupControl1.TabIndex = 11;
            this.groupControl1.Text = "groupControl1";
            // 
            // frmClosedMonthlyUpdateSelectPeriod
            // 
            this.Appearance.Options.UseFont = true;
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.ClientSize = new System.Drawing.Size(474, 182);
            this.Controls.Add(this.groupControl1);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.Name = "frmClosedMonthlyUpdateSelectPeriod";
            this.Text = "Monthly Update Select Period";
            this.Load += new System.EventHandler(this.frmClosedDealerSummaryReport_Load);
            ((System.ComponentModel.ISupportInitialize)(this.monthNamesBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.iACDataSet)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl1)).EndInit();
            this.groupControl1.ResumeLayout(false);
            this.groupControl1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraEditors.SimpleButton buttonPost;
        private DevExpress.XtraEditors.SimpleButton buttonCancel;
        private System.Windows.Forms.Label labelRunMonth;
        private IACDataSet iACDataSet;
        private System.Windows.Forms.BindingSource monthNamesBindingSource;
        private IACDataSetTableAdapters.MonthNamesTableAdapter monthNamesTableAdapter;
        private System.Windows.Forms.Label labelRunYear;
        private System.Windows.Forms.TextBox textBoxRunYear;
        private System.Windows.Forms.ComboBox comboBoxRunMonth;
        private DevExpress.XtraEditors.GroupControl groupControl1;
    }
}
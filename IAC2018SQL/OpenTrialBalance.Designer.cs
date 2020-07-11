namespace IAC2018SQL
{
    partial class frmOpenTrialBalance
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmOpenTrialBalance));
            this.labelRunMonth = new System.Windows.Forms.Label();
            this.iACDataSet = new IAC2018SQL.IACDataSet();
            this.labelDealerNum = new System.Windows.Forms.Label();
            this.comboBoxState = new System.Windows.Forms.ComboBox();
            this.StatebindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.stateTableAdapter = new IAC2018SQL.IACDataSetTableAdapters.stateTableAdapter();
            this.dlrlistbynumTableAdapter = new IAC2018SQL.IACDataSetTableAdapters.DLRLISTBYNUMTableAdapter();
            this.DLRLISTBYNUMbindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.comboBoxDealer = new System.Windows.Forms.ComboBox();
            this.textBoxDealerName = new System.Windows.Forms.TextBox();
            this.buttonPost = new System.Windows.Forms.Button();
            this.buttonCancel = new System.Windows.Forms.Button();
            this.buttonExcel = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.iACDataSet)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.StatebindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.DLRLISTBYNUMbindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // labelRunMonth
            // 
            this.labelRunMonth.AutoSize = true;
            this.labelRunMonth.Location = new System.Drawing.Point(39, 28);
            this.labelRunMonth.Name = "labelRunMonth";
            this.labelRunMonth.Size = new System.Drawing.Size(35, 13);
            this.labelRunMonth.TabIndex = 5;
            this.labelRunMonth.Text = "State:";
            this.labelRunMonth.TextAlign = System.Drawing.ContentAlignment.TopRight;
            this.labelRunMonth.Visible = false;
            // 
            // iACDataSet
            // 
            this.iACDataSet.DataSetName = "IACDataSet";
            this.iACDataSet.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // labelDealerNum
            // 
            this.labelDealerNum.AutoSize = true;
            this.labelDealerNum.Location = new System.Drawing.Point(33, 52);
            this.labelDealerNum.Name = "labelDealerNum";
            this.labelDealerNum.Size = new System.Drawing.Size(41, 13);
            this.labelDealerNum.TabIndex = 8;
            this.labelDealerNum.Text = "Dealer:";
            this.labelDealerNum.TextAlign = System.Drawing.ContentAlignment.TopRight;
            this.labelDealerNum.Visible = false;
            // 
            // comboBoxState
            // 
            this.comboBoxState.DataSource = this.StatebindingSource;
            this.comboBoxState.DisplayMember = "name";
            this.comboBoxState.FormattingEnabled = true;
            this.comboBoxState.Location = new System.Drawing.Point(85, 20);
            this.comboBoxState.Name = "comboBoxState";
            this.comboBoxState.Size = new System.Drawing.Size(166, 21);
            this.comboBoxState.TabIndex = 10;
            this.comboBoxState.ValueMember = "abbreviation";
            this.comboBoxState.Visible = false;
            // 
            // StatebindingSource
            // 
            this.StatebindingSource.DataMember = "state";
            this.StatebindingSource.DataSource = this.iACDataSet;
            // 
            // stateTableAdapter
            // 
            this.stateTableAdapter.ClearBeforeFill = true;
            // 
            // dlrlistbynumTableAdapter
            // 
            this.dlrlistbynumTableAdapter.ClearBeforeFill = true;
            // 
            // DLRLISTBYNUMbindingSource
            // 
            this.DLRLISTBYNUMbindingSource.DataMember = "DLRLISTBYNUM";
            this.DLRLISTBYNUMbindingSource.DataSource = this.iACDataSet;
            // 
            // comboBoxDealer
            // 
            this.comboBoxDealer.DataSource = this.DLRLISTBYNUMbindingSource;
            this.comboBoxDealer.DisplayMember = "DEALER_ACC_NO";
            this.comboBoxDealer.FormattingEnabled = true;
            this.comboBoxDealer.Location = new System.Drawing.Point(85, 44);
            this.comboBoxDealer.Name = "comboBoxDealer";
            this.comboBoxDealer.Size = new System.Drawing.Size(59, 21);
            this.comboBoxDealer.TabIndex = 11;
            this.comboBoxDealer.ValueMember = "DEALER_ACC_NO";
            this.comboBoxDealer.Visible = false;
            // 
            // textBoxDealerName
            // 
            this.textBoxDealerName.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.DLRLISTBYNUMbindingSource, "DEALER_NAME", true));
            this.textBoxDealerName.Location = new System.Drawing.Point(151, 45);
            this.textBoxDealerName.Name = "textBoxDealerName";
            this.textBoxDealerName.ReadOnly = true;
            this.textBoxDealerName.Size = new System.Drawing.Size(220, 20);
            this.textBoxDealerName.TabIndex = 12;
            this.textBoxDealerName.Visible = false;
            // 
            // buttonPost
            // 
            this.buttonPost.Image = ((System.Drawing.Image)(resources.GetObject("buttonPost.Image")));
            this.buttonPost.Location = new System.Drawing.Point(42, 80);
            this.buttonPost.Name = "buttonPost";
            this.buttonPost.Size = new System.Drawing.Size(110, 103);
            this.buttonPost.TabIndex = 16;
            this.buttonPost.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.buttonPost.UseVisualStyleBackColor = true;
            this.buttonPost.Click += new System.EventHandler(this.buttonPost_Click);
            // 
            // buttonCancel
            // 
            this.buttonCancel.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonCancel.Image = ((System.Drawing.Image)(resources.GetObject("buttonCancel.Image")));
            this.buttonCancel.Location = new System.Drawing.Point(300, 80);
            this.buttonCancel.Margin = new System.Windows.Forms.Padding(4);
            this.buttonCancel.Name = "buttonCancel";
            this.buttonCancel.Size = new System.Drawing.Size(110, 103);
            this.buttonCancel.TabIndex = 17;
            this.buttonCancel.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.buttonCancel.UseVisualStyleBackColor = true;
            this.buttonCancel.Click += new System.EventHandler(this.buttonCancel_Click);
            // 
            // buttonExcel
            // 
            this.buttonExcel.Image = global::IAC2018SQL.Properties.Resources.ExportToExcel_64x;
            this.buttonExcel.Location = new System.Drawing.Point(169, 80);
            this.buttonExcel.Name = "buttonExcel";
            this.buttonExcel.Size = new System.Drawing.Size(110, 103);
            this.buttonExcel.TabIndex = 18;
            this.buttonExcel.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.buttonExcel.UseVisualStyleBackColor = true;
            this.buttonExcel.Click += new System.EventHandler(this.buttonExcel_Click);
            // 
            // frmOpenTrialBalance
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.BackColor = System.Drawing.Color.LightSteelBlue;
            this.ClientSize = new System.Drawing.Size(443, 203);
            this.Controls.Add(this.buttonExcel);
            this.Controls.Add(this.buttonCancel);
            this.Controls.Add(this.buttonPost);
            this.Controls.Add(this.textBoxDealerName);
            this.Controls.Add(this.comboBoxDealer);
            this.Controls.Add(this.comboBoxState);
            this.Controls.Add(this.labelDealerNum);
            this.Controls.Add(this.labelRunMonth);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Name = "frmOpenTrialBalance";
            this.Text = "Print Open Trial Balance";
            this.Load += new System.EventHandler(this.frmOpenTrialBalance_Load);
            ((System.ComponentModel.ISupportInitialize)(this.iACDataSet)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.StatebindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.DLRLISTBYNUMbindingSource)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label labelRunMonth;
        private IACDataSet iACDataSet;
        private System.Windows.Forms.Label labelDealerNum;
        private System.Windows.Forms.ComboBox comboBoxState;
        private System.Windows.Forms.BindingSource StatebindingSource;
        private IACDataSetTableAdapters.stateTableAdapter stateTableAdapter;
        private IACDataSetTableAdapters.DLRLISTBYNUMTableAdapter dlrlistbynumTableAdapter;
        private System.Windows.Forms.BindingSource DLRLISTBYNUMbindingSource;
        private System.Windows.Forms.ComboBox comboBoxDealer;
        private System.Windows.Forms.TextBox textBoxDealerName;
        public System.Windows.Forms.Button buttonPost;
        private System.Windows.Forms.Button buttonCancel;
        public System.Windows.Forms.Button buttonExcel;
    }
}
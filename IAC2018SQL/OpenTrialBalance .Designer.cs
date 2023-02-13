namespace IAC2021SQL
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
            this.labelRunMonth = new DevExpress.XtraEditors.LabelControl();
            this.iACDataSet = new IAC2021SQL.IACDataSet();
            this.labelDealerNum = new DevExpress.XtraEditors.LabelControl();
            this.StatebindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.stateTableAdapter = new IAC2021SQL.IACDataSetTableAdapters.stateTableAdapter();
            this.DLRLISTBYNUMbindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.buttonPost = new DevExpress.XtraEditors.SimpleButton();
            this.buttonCancel = new DevExpress.XtraEditors.SimpleButton();
            this.buttonExcel = new DevExpress.XtraEditors.SimpleButton();
            this.lookUpEditDealer = new DevExpress.XtraEditors.LookUpEdit();
            this.lookUpEditState = new DevExpress.XtraEditors.LookUpEdit();
            this.groupControlTrialBalance = new DevExpress.XtraEditors.GroupControl();
            this.opndealrlistTableAdapter = new IAC2021SQL.IACDataSetTableAdapters.OPNDEALRLISTTableAdapter();
            this.oPNDLRLISTBYNUMTableAdapter = new IAC2021SQL.IACDataSetTableAdapters.OPNDLRLISTBYNUMTableAdapter();
            ((System.ComponentModel.ISupportInitialize)(this.iACDataSet)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.StatebindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.DLRLISTBYNUMbindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lookUpEditDealer.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lookUpEditState.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.groupControlTrialBalance)).BeginInit();
            this.groupControlTrialBalance.SuspendLayout();
            this.SuspendLayout();
            // 
            // labelRunMonth
            // 
            this.labelRunMonth.Appearance.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelRunMonth.Appearance.Options.UseFont = true;
            this.labelRunMonth.Location = new System.Drawing.Point(77, 30);
            this.labelRunMonth.Name = "labelRunMonth";
            this.labelRunMonth.Size = new System.Drawing.Size(43, 20);
            this.labelRunMonth.TabIndex = 5;
            this.labelRunMonth.Text = "State:";
            // 
            // iACDataSet
            // 
            this.iACDataSet.DataSetName = "IACDataSet";
            this.iACDataSet.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // labelDealerNum
            // 
            this.labelDealerNum.Appearance.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelDealerNum.Appearance.Options.UseFont = true;
            this.labelDealerNum.Location = new System.Drawing.Point(69, 82);
            this.labelDealerNum.Name = "labelDealerNum";
            this.labelDealerNum.Size = new System.Drawing.Size(51, 20);
            this.labelDealerNum.TabIndex = 8;
            this.labelDealerNum.Text = "Dealer:";
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
            // DLRLISTBYNUMbindingSource
            // 
            this.DLRLISTBYNUMbindingSource.DataMember = "OPNDLRLISTBYNUM";
            this.DLRLISTBYNUMbindingSource.DataSource = this.iACDataSet;
            // 
            // buttonPost
            // 
            this.buttonPost.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("buttonPost.ImageOptions.Image")));
            this.buttonPost.ImageOptions.Location = DevExpress.XtraEditors.ImageLocation.MiddleCenter;
            this.buttonPost.Location = new System.Drawing.Point(37, 134);
            this.buttonPost.Name = "buttonPost";
            this.buttonPost.Size = new System.Drawing.Size(110, 103);
            this.buttonPost.TabIndex = 16;
            this.buttonPost.Click += new System.EventHandler(this.buttonPost_Click);
            // 
            // buttonCancel
            // 
            this.buttonCancel.Appearance.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonCancel.Appearance.Options.UseFont = true;
            this.buttonCancel.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("buttonCancel.ImageOptions.Image")));
            this.buttonCancel.ImageOptions.Location = DevExpress.XtraEditors.ImageLocation.MiddleCenter;
            this.buttonCancel.Location = new System.Drawing.Point(295, 134);
            this.buttonCancel.Margin = new System.Windows.Forms.Padding(4);
            this.buttonCancel.Name = "buttonCancel";
            this.buttonCancel.Size = new System.Drawing.Size(110, 103);
            this.buttonCancel.TabIndex = 17;
            this.buttonCancel.Click += new System.EventHandler(this.buttonCancel_Click);
            // 
            // buttonExcel
            // 
            this.buttonExcel.ImageOptions.Image = global::IAC2021SQL.Properties.Resources.ExportToExcel_64x;
            this.buttonExcel.ImageOptions.Location = DevExpress.XtraEditors.ImageLocation.MiddleCenter;
            this.buttonExcel.Location = new System.Drawing.Point(164, 134);
            this.buttonExcel.Name = "buttonExcel";
            this.buttonExcel.Size = new System.Drawing.Size(110, 103);
            this.buttonExcel.TabIndex = 18;
            this.buttonExcel.Click += new System.EventHandler(this.buttonExcel_Click);
            // 
            // lookUpEditDealer
            // 
            this.lookUpEditDealer.Location = new System.Drawing.Point(126, 76);
            this.lookUpEditDealer.Name = "lookUpEditDealer";
            this.lookUpEditDealer.Properties.Appearance.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lookUpEditDealer.Properties.Appearance.Options.UseFont = true;
            this.lookUpEditDealer.Properties.BestFitMode = DevExpress.XtraEditors.Controls.BestFitMode.BestFitResizePopup;
            this.lookUpEditDealer.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.lookUpEditDealer.Properties.Columns.AddRange(new DevExpress.XtraEditors.Controls.LookUpColumnInfo[] {
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("OPNDEALR_ACC_NO", "id", 100, DevExpress.Utils.FormatType.Numeric, "", true, DevExpress.Utils.HorzAlignment.Near, DevExpress.Data.ColumnSortOrder.None, DevExpress.Utils.DefaultBoolean.Default),
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("OPNDEALR_NAME", "DEALER_NAME", 800, DevExpress.Utils.FormatType.None, "", true, DevExpress.Utils.HorzAlignment.Near, DevExpress.Data.ColumnSortOrder.None, DevExpress.Utils.DefaultBoolean.Default)});
            this.lookUpEditDealer.Properties.DataSource = this.DLRLISTBYNUMbindingSource;
            this.lookUpEditDealer.Properties.DisplayMember = "OPNDEALR_ACC_NO";
            this.lookUpEditDealer.Properties.LookAndFeel.SkinName = "McSkin";
            this.lookUpEditDealer.Properties.LookAndFeel.UseDefaultLookAndFeel = false;
            this.lookUpEditDealer.Properties.NullText = "";
            this.lookUpEditDealer.Properties.ValueMember = "OPNDEALR_ACC_NO";
            this.lookUpEditDealer.Size = new System.Drawing.Size(86, 26);
            this.lookUpEditDealer.TabIndex = 20;
            // 
            // lookUpEditState
            // 
            this.lookUpEditState.Location = new System.Drawing.Point(126, 24);
            this.lookUpEditState.Name = "lookUpEditState";
            this.lookUpEditState.Properties.Appearance.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lookUpEditState.Properties.Appearance.Options.UseFont = true;
            this.lookUpEditState.Properties.BestFitMode = DevExpress.XtraEditors.Controls.BestFitMode.BestFitResizePopup;
            this.lookUpEditState.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.lookUpEditState.Properties.Columns.AddRange(new DevExpress.XtraEditors.Controls.LookUpColumnInfo[] {
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("name", "name", 37, DevExpress.Utils.FormatType.None, "", true, DevExpress.Utils.HorzAlignment.Near, DevExpress.Data.ColumnSortOrder.None, DevExpress.Utils.DefaultBoolean.Default),
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("abbreviation", "abbreviation", 74, DevExpress.Utils.FormatType.None, "", true, DevExpress.Utils.HorzAlignment.Near, DevExpress.Data.ColumnSortOrder.None, DevExpress.Utils.DefaultBoolean.Default)});
            this.lookUpEditState.Properties.DataSource = this.StatebindingSource;
            this.lookUpEditState.Properties.DisplayMember = "name";
            this.lookUpEditState.Properties.NullText = "";
            this.lookUpEditState.Properties.ValueMember = "abbreviation";
            this.lookUpEditState.Size = new System.Drawing.Size(247, 26);
            this.lookUpEditState.TabIndex = 19;
            // 
            // groupControlTrialBalance
            // 
            this.groupControlTrialBalance.Appearance.BackColor = System.Drawing.Color.LightSteelBlue;
            this.groupControlTrialBalance.Appearance.Options.UseBackColor = true;
            this.groupControlTrialBalance.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            this.groupControlTrialBalance.Controls.Add(this.lookUpEditDealer);
            this.groupControlTrialBalance.Controls.Add(this.lookUpEditState);
            this.groupControlTrialBalance.Controls.Add(this.buttonExcel);
            this.groupControlTrialBalance.Controls.Add(this.buttonCancel);
            this.groupControlTrialBalance.Controls.Add(this.buttonPost);
            this.groupControlTrialBalance.Controls.Add(this.labelDealerNum);
            this.groupControlTrialBalance.Controls.Add(this.labelRunMonth);
            this.groupControlTrialBalance.Location = new System.Drawing.Point(-1, -1);
            this.groupControlTrialBalance.Name = "groupControlTrialBalance";
            this.groupControlTrialBalance.Size = new System.Drawing.Size(446, 260);
            this.groupControlTrialBalance.TabIndex = 21;
            this.groupControlTrialBalance.Text = "groupControl1";
            // 
            // opndealrlistTableAdapter
            // 
            this.opndealrlistTableAdapter.ClearBeforeFill = true;
            // 
            // oPNDLRLISTBYNUMTableAdapter
            // 
            this.oPNDLRLISTBYNUMTableAdapter.ClearBeforeFill = true;
            // 
            // frmOpenTrialBalance
            // 
            this.Appearance.Options.UseFont = true;
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.ClientSize = new System.Drawing.Size(443, 259);
            this.Controls.Add(this.groupControlTrialBalance);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Name = "frmOpenTrialBalance";
            this.Text = "Print Open Trial Balance";
            this.Load += new System.EventHandler(this.frmOpenTrialBalance_Load);
            ((System.ComponentModel.ISupportInitialize)(this.iACDataSet)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.StatebindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.DLRLISTBYNUMbindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lookUpEditDealer.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lookUpEditState.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.groupControlTrialBalance)).EndInit();
            this.groupControlTrialBalance.ResumeLayout(false);
            this.groupControlTrialBalance.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion
        private DevExpress.XtraEditors.LabelControl labelRunMonth;
        private IACDataSet iACDataSet;
        private DevExpress.XtraEditors.LabelControl labelDealerNum;
        private System.Windows.Forms.BindingSource StatebindingSource;
        private IACDataSetTableAdapters.stateTableAdapter stateTableAdapter;
        private System.Windows.Forms.BindingSource DLRLISTBYNUMbindingSource;
        public DevExpress.XtraEditors.SimpleButton buttonPost;
        private DevExpress.XtraEditors.SimpleButton buttonCancel;
        public DevExpress.XtraEditors.SimpleButton buttonExcel;
        private DevExpress.XtraEditors.LookUpEdit lookUpEditDealer;
        private DevExpress.XtraEditors.LookUpEdit lookUpEditState;
        private DevExpress.XtraEditors.GroupControl groupControlTrialBalance;
        private IACDataSetTableAdapters.OPNDEALRLISTTableAdapter opndealrlistTableAdapter;
        private IACDataSetTableAdapters.OPNDLRLISTBYNUMTableAdapter oPNDLRLISTBYNUMTableAdapter;
    }
}
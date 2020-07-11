namespace IAC2010
{
    partial class MasterHistory
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle7 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle8 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.Label label5;
            System.Windows.Forms.Label label4;
            this.MASTERbindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.MasteriacDataSet = new IAC2010.IACDataSet();
            this.mASTERTableAdapter = new IAC2010.IACDataSetTableAdapters.MASTERTableAdapter();
            this.MACONTbindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.MasterListbindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.MasterHistorybindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.mASTHISTTableAdapter = new IAC2010.IACDataSetTableAdapters.MASTHISTTableAdapter();
            this.mASTERLISTTableAdapter = new IAC2010.IACDataSetTableAdapters.MASTERLISTTableAdapter();
            this.macontTableAdapter = new IAC2010.IACDataSetTableAdapters.MACONTTableAdapter();
            this.lblYTDValue2 = new System.Windows.Forms.Label();
            this.lblCurValue2 = new System.Windows.Forms.Label();
            this.txtYTDValue2 = new System.Windows.Forms.TextBox();
            this.txtCurValue2 = new System.Windows.Forms.TextBox();
            this.lblYTDValue = new System.Windows.Forms.Label();
            this.lblCurValue = new System.Windows.Forms.Label();
            this.txtYTDValue = new System.Windows.Forms.TextBox();
            this.txtCurValue = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.MasterHistorydataGridView = new System.Windows.Forms.DataGridView();
            this.mASTHISTPOSTDATEDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.mASTHISTIACTYPEDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.CurrentContColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.YTDContColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.PostDatemaskedTextBox = new System.Windows.Forms.MaskedTextBox();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.MasterAccNoTextBox = new System.Windows.Forms.TextBox();
            this.MasterNamecomboBox = new System.Windows.Forms.ComboBox();
            label5 = new System.Windows.Forms.Label();
            label4 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.MASTERbindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.MasteriacDataSet)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.MACONTbindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.MasterListbindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.MasterHistorybindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.MasterHistorydataGridView)).BeginInit();
            this.groupBox3.SuspendLayout();
            this.SuspendLayout();
            // 
            // MASTERbindingSource
            // 
            this.MASTERbindingSource.DataMember = "MASTER";
            this.MASTERbindingSource.DataSource = this.MasteriacDataSet;
            // 
            // MasteriacDataSet
            // 
            this.MasteriacDataSet.DataSetName = "IACDataSet";
            this.MasteriacDataSet.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // mASTERTableAdapter
            // 
            this.mASTERTableAdapter.ClearBeforeFill = true;
            // 
            // MACONTbindingSource
            // 
            this.MACONTbindingSource.DataMember = "MACONT";
            this.MACONTbindingSource.DataSource = this.MasteriacDataSet;
            this.MACONTbindingSource.PositionChanged += new System.EventHandler(this.MACONTbindingSource_PositionChanged);
            // 
            // MasterListbindingSource
            // 
            this.MasterListbindingSource.DataMember = "MASTERLIST";
            this.MasterListbindingSource.DataSource = this.MasteriacDataSet;
            // 
            // MasterHistorybindingSource
            // 
            this.MasterHistorybindingSource.DataMember = "MASTHIST";
            this.MasterHistorybindingSource.DataSource = this.MasteriacDataSet;
            // 
            // mASTHISTTableAdapter
            // 
            this.mASTHISTTableAdapter.ClearBeforeFill = true;
            // 
            // mASTERLISTTableAdapter
            // 
            this.mASTERLISTTableAdapter.ClearBeforeFill = true;
            // 
            // macontTableAdapter
            // 
            this.macontTableAdapter.ClearBeforeFill = true;
            // 
            // lblYTDValue2
            // 
            this.lblYTDValue2.AutoSize = true;
            this.lblYTDValue2.Location = new System.Drawing.Point(677, 145);
            this.lblYTDValue2.Name = "lblYTDValue2";
            this.lblYTDValue2.Size = new System.Drawing.Size(87, 13);
            this.lblYTDValue2.TabIndex = 209;
            this.lblYTDValue2.Text = "NOTES PAYABLE";
            // 
            // lblCurValue2
            // 
            this.lblCurValue2.AutoSize = true;
            this.lblCurValue2.Location = new System.Drawing.Point(58, 145);
            this.lblCurValue2.Name = "lblCurValue2";
            this.lblCurValue2.Size = new System.Drawing.Size(87, 13);
            this.lblCurValue2.TabIndex = 208;
            this.lblCurValue2.Text = "NOTES PAYABLE";
            // 
            // txtYTDValue2
            // 
            this.txtYTDValue2.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.MASTERbindingSource, "MASTER_YTD_NOTES", true, System.Windows.Forms.DataSourceUpdateMode.OnValidation, null, "C2"));
            this.txtYTDValue2.Enabled = false;
            this.txtYTDValue2.Location = new System.Drawing.Point(776, 138);
            this.txtYTDValue2.Name = "txtYTDValue2";
            this.txtYTDValue2.Size = new System.Drawing.Size(100, 22);
            this.txtYTDValue2.TabIndex = 207;
            this.txtYTDValue2.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // txtCurValue2
            // 
            this.txtCurValue2.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.MASTERbindingSource, "MASTER_CUR_NOTES", true, System.Windows.Forms.DataSourceUpdateMode.OnValidation, null, "C2"));
            this.txtCurValue2.Enabled = false;
            this.txtCurValue2.Location = new System.Drawing.Point(154, 138);
            this.txtCurValue2.Name = "txtCurValue2";
            this.txtCurValue2.Size = new System.Drawing.Size(100, 22);
            this.txtCurValue2.TabIndex = 206;
            this.txtCurValue2.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // lblYTDValue
            // 
            this.lblYTDValue.AutoSize = true;
            this.lblYTDValue.Location = new System.Drawing.Point(644, 123);
            this.lblYTDValue.Name = "lblYTDValue";
            this.lblYTDValue.Size = new System.Drawing.Size(120, 13);
            this.lblYTDValue.TabIndex = 205;
            this.lblYTDValue.Text = "OUTSTANDING LOANS";
            // 
            // lblCurValue
            // 
            this.lblCurValue.AutoSize = true;
            this.lblCurValue.Location = new System.Drawing.Point(25, 123);
            this.lblCurValue.Name = "lblCurValue";
            this.lblCurValue.Size = new System.Drawing.Size(120, 13);
            this.lblCurValue.TabIndex = 204;
            this.lblCurValue.Text = "OUTSTANDING LOANS";
            // 
            // txtYTDValue
            // 
            this.txtYTDValue.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.MASTERbindingSource, "MASTER_YTD_CONT", true, System.Windows.Forms.DataSourceUpdateMode.OnValidation, null, "C2"));
            this.txtYTDValue.Enabled = false;
            this.txtYTDValue.Location = new System.Drawing.Point(776, 116);
            this.txtYTDValue.Name = "txtYTDValue";
            this.txtYTDValue.Size = new System.Drawing.Size(100, 22);
            this.txtYTDValue.TabIndex = 203;
            this.txtYTDValue.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // txtCurValue
            // 
            this.txtCurValue.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.MASTERbindingSource, "MASTER_CUR_CONT", true, System.Windows.Forms.DataSourceUpdateMode.OnValidation, null, "C2"));
            this.txtCurValue.Enabled = false;
            this.txtCurValue.Location = new System.Drawing.Point(154, 116);
            this.txtCurValue.Name = "txtCurValue";
            this.txtCurValue.Size = new System.Drawing.Size(100, 22);
            this.txtCurValue.TabIndex = 202;
            this.txtCurValue.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(706, 99);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(78, 13);
            this.label7.TabIndex = 201;
            this.label7.Text = "YEAR TO DATE";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(99, 99);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(55, 13);
            this.label6.TabIndex = 200;
            this.label6.Text = "CURRENT";
            // 
            // MasterHistorydataGridView
            // 
            this.MasterHistorydataGridView.AutoGenerateColumns = false;
            this.MasterHistorydataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.MasterHistorydataGridView.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.mASTHISTPOSTDATEDataGridViewTextBoxColumn,
            this.mASTHISTIACTYPEDataGridViewTextBoxColumn,
            this.CurrentContColumn,
            this.YTDContColumn});
            this.MasterHistorydataGridView.DataSource = this.MasterHistorybindingSource;
            this.MasterHistorydataGridView.Location = new System.Drawing.Point(285, 167);
            this.MasterHistorydataGridView.Name = "MasterHistorydataGridView";
            this.MasterHistorydataGridView.RowTemplate.Height = 24;
            this.MasterHistorydataGridView.Size = new System.Drawing.Size(338, 311);
            this.MasterHistorydataGridView.TabIndex = 199;
            // 
            // mASTHISTPOSTDATEDataGridViewTextBoxColumn
            // 
            this.mASTHISTPOSTDATEDataGridViewTextBoxColumn.DataPropertyName = "MASTHIST_POST_DATE";
            dataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle5.Format = "d";
            dataGridViewCellStyle5.NullValue = null;
            this.mASTHISTPOSTDATEDataGridViewTextBoxColumn.DefaultCellStyle = dataGridViewCellStyle5;
            this.mASTHISTPOSTDATEDataGridViewTextBoxColumn.HeaderText = "POST DATE";
            this.mASTHISTPOSTDATEDataGridViewTextBoxColumn.Name = "mASTHISTPOSTDATEDataGridViewTextBoxColumn";
            this.mASTHISTPOSTDATEDataGridViewTextBoxColumn.Width = 60;
            // 
            // mASTHISTIACTYPEDataGridViewTextBoxColumn
            // 
            this.mASTHISTIACTYPEDataGridViewTextBoxColumn.DataPropertyName = "MASTHIST_IAC_TYPE";
            dataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle6.NullValue = null;
            this.mASTHISTIACTYPEDataGridViewTextBoxColumn.DefaultCellStyle = dataGridViewCellStyle6;
            this.mASTHISTIACTYPEDataGridViewTextBoxColumn.HeaderText = "";
            this.mASTHISTIACTYPEDataGridViewTextBoxColumn.Name = "mASTHISTIACTYPEDataGridViewTextBoxColumn";
            this.mASTHISTIACTYPEDataGridViewTextBoxColumn.Width = 20;
            // 
            // CurrentContColumn
            // 
            this.CurrentContColumn.DataPropertyName = "MASTHIST_CUR_CONT";
            dataGridViewCellStyle7.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle7.Format = "C2";
            dataGridViewCellStyle7.NullValue = null;
            this.CurrentContColumn.DefaultCellStyle = dataGridViewCellStyle7;
            this.CurrentContColumn.HeaderText = "CURRENT CONTINGENT";
            this.CurrentContColumn.Name = "CurrentContColumn";
            // 
            // YTDContColumn
            // 
            this.YTDContColumn.DataPropertyName = "MASTHIST_YTD_CONT";
            dataGridViewCellStyle8.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle8.Format = "C2";
            dataGridViewCellStyle8.NullValue = null;
            this.YTDContColumn.DefaultCellStyle = dataGridViewCellStyle8;
            this.YTDContColumn.HeaderText = "YEAR TO DATE CONTINGENT";
            this.YTDContColumn.Name = "YTDContColumn";
            // 
            // PostDatemaskedTextBox
            // 
            this.PostDatemaskedTextBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.MASTERbindingSource, "MASTER_POST_DATE", true));
            this.PostDatemaskedTextBox.Enabled = false;
            this.PostDatemaskedTextBox.Location = new System.Drawing.Point(499, 18);
            this.PostDatemaskedTextBox.Name = "PostDatemaskedTextBox";
            this.PostDatemaskedTextBox.Size = new System.Drawing.Size(68, 22);
            this.PostDatemaskedTextBox.TabIndex = 179;
            this.PostDatemaskedTextBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.PostDatemaskedTextBox.ValidatingType = typeof(System.DateTime);
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.MasterNamecomboBox);
            this.groupBox3.Controls.Add(this.PostDatemaskedTextBox);
            this.groupBox3.Controls.Add(label5);
            this.groupBox3.Controls.Add(this.MasterAccNoTextBox);
            this.groupBox3.Controls.Add(label4);
            this.groupBox3.Location = new System.Drawing.Point(161, 31);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(587, 56);
            this.groupBox3.TabIndex = 198;
            this.groupBox3.TabStop = false;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new System.Drawing.Point(424, 25);
            label5.Name = "label5";
            label5.Size = new System.Drawing.Size(65, 13);
            label5.TabIndex = 180;
            label5.Text = "POST DATE:";
            // 
            // MasterAccNoTextBox
            // 
            this.MasterAccNoTextBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.MASTERbindingSource, "MASTER_ACC_NO", true));
            this.MasterAccNoTextBox.Enabled = false;
            this.MasterAccNoTextBox.Location = new System.Drawing.Point(126, 18);
            this.MasterAccNoTextBox.MaxLength = 3;
            this.MasterAccNoTextBox.Name = "MasterAccNoTextBox";
            this.MasterAccNoTextBox.Size = new System.Drawing.Size(45, 22);
            this.MasterAccNoTextBox.TabIndex = 1;
            this.MasterAccNoTextBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new System.Drawing.Point(17, 25);
            label4.Name = "label4";
            label4.Size = new System.Drawing.Size(100, 13);
            label4.TabIndex = 41;
            label4.Text = "MASTER NUMBER:";
            // 
            // MasterNamecomboBox
            // 
            this.MasterNamecomboBox.DataSource = this.MasterListbindingSource;
            this.MasterNamecomboBox.DisplayMember = "MASTER_NAME";
            this.MasterNamecomboBox.FormattingEnabled = true;
            this.MasterNamecomboBox.Location = new System.Drawing.Point(196, 19);
            this.MasterNamecomboBox.Name = "MasterNamecomboBox";
            this.MasterNamecomboBox.Size = new System.Drawing.Size(194, 21);
            this.MasterNamecomboBox.TabIndex = 181;
            // 
            // MasterHistory
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.LightSteelBlue;
            this.ClientSize = new System.Drawing.Size(900, 509);
            this.Controls.Add(this.lblYTDValue2);
            this.Controls.Add(this.lblCurValue2);
            this.Controls.Add(this.txtYTDValue2);
            this.Controls.Add(this.txtCurValue2);
            this.Controls.Add(this.lblYTDValue);
            this.Controls.Add(this.lblCurValue);
            this.Controls.Add(this.txtYTDValue);
            this.Controls.Add(this.txtCurValue);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.MasterHistorydataGridView);
            this.Controls.Add(this.groupBox3);
            this.Name = "MasterHistory";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Closed Master Contingent Maintenance";
            this.Load += new System.EventHandler(this.MasterContingentMaintenance_Load);
            ((System.ComponentModel.ISupportInitialize)(this.MASTERbindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.MasteriacDataSet)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.MACONTbindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.MasterListbindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.MasterHistorybindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.MasterHistorydataGridView)).EndInit();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private IACDataSet MasteriacDataSet;
        private System.Windows.Forms.BindingSource MASTERbindingSource;
        private IACDataSetTableAdapters.MASTERTableAdapter mASTERTableAdapter;
        private System.Windows.Forms.BindingSource MasterHistorybindingSource;
        private IACDataSetTableAdapters.MASTHISTTableAdapter mASTHISTTableAdapter;
        private System.Windows.Forms.BindingSource MasterListbindingSource;
        private IACDataSetTableAdapters.MASTERLISTTableAdapter mASTERLISTTableAdapter;
        private IACDataSetTableAdapters.MACONTTableAdapter macontTableAdapter;
        private System.Windows.Forms.BindingSource MACONTbindingSource;
        private System.Windows.Forms.Label lblYTDValue2;
        private System.Windows.Forms.Label lblCurValue2;
        private System.Windows.Forms.TextBox txtYTDValue2;
        private System.Windows.Forms.TextBox txtCurValue2;
        private System.Windows.Forms.Label lblYTDValue;
        private System.Windows.Forms.Label lblCurValue;
        private System.Windows.Forms.TextBox txtYTDValue;
        private System.Windows.Forms.TextBox txtCurValue;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.DataGridView MasterHistorydataGridView;
        private System.Windows.Forms.DataGridViewTextBoxColumn mASTHISTPOSTDATEDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn mASTHISTIACTYPEDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn CurrentContColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn YTDContColumn;
        private System.Windows.Forms.MaskedTextBox PostDatemaskedTextBox;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.TextBox MasterAccNoTextBox;
        private System.Windows.Forms.ComboBox MasterNamecomboBox;
    }
}
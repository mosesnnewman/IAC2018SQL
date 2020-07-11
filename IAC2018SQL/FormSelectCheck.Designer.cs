namespace IAC2018SQL
{
    partial class FormSelectCheck
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
            System.Windows.Forms.Label label4;
            System.Windows.Forms.Label label5;
            System.Windows.Forms.Label label8;
            System.Windows.Forms.Label label7;
            System.Windows.Forms.Label label3;
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle8 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle7 = new System.Windows.Forms.DataGridViewCellStyle();
            this.opncustTableAdapter = new IAC2018SQL.IACDataSetTableAdapters.OPNCUSTTableAdapter();
            this.opnhcustTableAdapter = new IAC2018SQL.IACDataSetTableAdapters.OPNHCUSTTableAdapter();
            this.cUSTHISTBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.iACDataSet = new IAC2018SQL.IACDataSet();
            this.cUSTHISTDataGridView = new System.Windows.Forms.DataGridView();
            this.groupBox8 = new System.Windows.Forms.GroupBox();
            this.textBoxSuffix = new System.Windows.Forms.TextBox();
            this.txtPayDate = new System.Windows.Forms.TextBox();
            this.textBoxDealerName = new System.Windows.Forms.TextBox();
            this.bindingSourceOPNDEALR = new System.Windows.Forms.BindingSource(this.components);
            this.textBoxDealerNo = new System.Windows.Forms.TextBox();
            this.bindingSourceOPNCUST = new System.Windows.Forms.BindingSource(this.components);
            this.textBoxLastName = new System.Windows.Forms.TextBox();
            this.textBoxFirstName = new System.Windows.Forms.TextBox();
            this.textBoxPurchaseOrder = new System.Windows.Forms.TextBox();
            this.textBoxAddOn = new System.Windows.Forms.TextBox();
            this.textBoxCustomerNo = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.opndealrTableAdapter = new IAC2018SQL.IACDataSetTableAdapters.OPNDEALRTableAdapter();
            this.dataGridViewTextBoxColumnPostDate = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn6 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn9 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn8 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn18 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn13 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn15 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn16 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn27 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.CUSTHIST_PAYMENT_CODE = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.CUSTHIST_DATE_SEQ = new System.Windows.Forms.DataGridViewTextBoxColumn();
            label4 = new System.Windows.Forms.Label();
            label5 = new System.Windows.Forms.Label();
            label8 = new System.Windows.Forms.Label();
            label7 = new System.Windows.Forms.Label();
            label3 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.cUSTHISTBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.iACDataSet)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cUSTHISTDataGridView)).BeginInit();
            this.groupBox8.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.bindingSourceOPNDEALR)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bindingSourceOPNCUST)).BeginInit();
            this.SuspendLayout();
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new System.Drawing.Point(23, 43);
            label4.Name = "label4";
            label4.Size = new System.Drawing.Size(111, 13);
            label4.TabIndex = 44;
            label4.Text = "PURCHASE ORDER:";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new System.Drawing.Point(44, 20);
            label5.Name = "label5";
            label5.Size = new System.Drawing.Size(90, 13);
            label5.TabIndex = 41;
            label5.Text = "CUSTOMER NO:";
            // 
            // label8
            // 
            label8.AutoSize = true;
            label8.Location = new System.Drawing.Point(256, 43);
            label8.Name = "label8";
            label8.Size = new System.Drawing.Size(63, 13);
            label8.TabIndex = 53;
            label8.Text = "PAY DATE:";
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Location = new System.Drawing.Point(468, 43);
            label7.Name = "label7";
            label7.Size = new System.Drawing.Size(53, 13);
            label7.TabIndex = 52;
            label7.Text = "DEALER:";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.BackColor = System.Drawing.Color.Transparent;
            label3.Location = new System.Drawing.Point(476, 20);
            label3.Name = "label3";
            label3.Size = new System.Drawing.Size(41, 13);
            label3.TabIndex = 46;
            label3.Text = "NAME:";
            // 
            // opncustTableAdapter
            // 
            this.opncustTableAdapter.ClearBeforeFill = true;
            // 
            // opnhcustTableAdapter
            // 
            this.opnhcustTableAdapter.ClearBeforeFill = true;
            // 
            // cUSTHISTBindingSource
            // 
            this.cUSTHISTBindingSource.DataMember = "OPNHCUST";
            this.cUSTHISTBindingSource.DataSource = this.iACDataSet;
            // 
            // iACDataSet
            // 
            this.iACDataSet.DataSetName = "IACDataSet";
            this.iACDataSet.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // cUSTHISTDataGridView
            // 
            this.cUSTHISTDataGridView.AllowUserToAddRows = false;
            this.cUSTHISTDataGridView.AllowUserToDeleteRows = false;
            this.cUSTHISTDataGridView.AllowUserToOrderColumns = true;
            this.cUSTHISTDataGridView.AllowUserToResizeColumns = false;
            this.cUSTHISTDataGridView.AutoGenerateColumns = false;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.cUSTHISTDataGridView.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.cUSTHISTDataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.cUSTHISTDataGridView.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.dataGridViewTextBoxColumnPostDate,
            this.dataGridViewTextBoxColumn6,
            this.dataGridViewTextBoxColumn9,
            this.dataGridViewTextBoxColumn8,
            this.dataGridViewTextBoxColumn18,
            this.dataGridViewTextBoxColumn13,
            this.dataGridViewTextBoxColumn15,
            this.dataGridViewTextBoxColumn16,
            this.dataGridViewTextBoxColumn27,
            this.CUSTHIST_PAYMENT_CODE,
            this.CUSTHIST_DATE_SEQ});
            this.cUSTHISTDataGridView.DataSource = this.cUSTHISTBindingSource;
            dataGridViewCellStyle8.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle8.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle8.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle8.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle8.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle8.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle8.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.cUSTHISTDataGridView.DefaultCellStyle = dataGridViewCellStyle8;
            this.cUSTHISTDataGridView.Location = new System.Drawing.Point(86, 91);
            this.cUSTHISTDataGridView.Name = "cUSTHISTDataGridView";
            this.cUSTHISTDataGridView.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.AutoSizeToAllHeaders;
            this.cUSTHISTDataGridView.RowTemplate.Height = 24;
            this.cUSTHISTDataGridView.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.cUSTHISTDataGridView.Size = new System.Drawing.Size(799, 319);
            this.cUSTHISTDataGridView.TabIndex = 98;
            this.cUSTHISTDataGridView.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.cUSTHISTDataGridView_CellDoubleClick);
            this.cUSTHISTDataGridView.DataBindingComplete += new System.Windows.Forms.DataGridViewBindingCompleteEventHandler(this.cUSTHISTDataGridView_DataBindingComplete);
            // 
            // groupBox8
            // 
            this.groupBox8.Controls.Add(this.textBoxSuffix);
            this.groupBox8.Controls.Add(this.txtPayDate);
            this.groupBox8.Controls.Add(this.textBoxDealerName);
            this.groupBox8.Controls.Add(label4);
            this.groupBox8.Controls.Add(this.textBoxDealerNo);
            this.groupBox8.Controls.Add(label5);
            this.groupBox8.Controls.Add(this.textBoxLastName);
            this.groupBox8.Controls.Add(this.textBoxFirstName);
            this.groupBox8.Controls.Add(this.textBoxPurchaseOrder);
            this.groupBox8.Controls.Add(this.textBoxAddOn);
            this.groupBox8.Controls.Add(this.textBoxCustomerNo);
            this.groupBox8.Controls.Add(label8);
            this.groupBox8.Controls.Add(label7);
            this.groupBox8.Controls.Add(this.label6);
            this.groupBox8.Controls.Add(label3);
            this.groupBox8.Location = new System.Drawing.Point(78, 12);
            this.groupBox8.Name = "groupBox8";
            this.groupBox8.Size = new System.Drawing.Size(814, 65);
            this.groupBox8.TabIndex = 99;
            this.groupBox8.TabStop = false;
            // 
            // textBoxSuffix
            // 
            this.textBoxSuffix.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.textBoxSuffix.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.iACDataSet, "OPNCUST.CUSTOMER_SUFFIX", true));
            this.textBoxSuffix.Enabled = false;
            this.textBoxSuffix.Location = new System.Drawing.Point(748, 11);
            this.textBoxSuffix.MaxLength = 3;
            this.textBoxSuffix.Name = "textBoxSuffix";
            this.textBoxSuffix.Size = new System.Drawing.Size(36, 20);
            this.textBoxSuffix.TabIndex = 92;
            // 
            // txtPayDate
            // 
            this.txtPayDate.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.cUSTHISTBindingSource, "CUSTHIST_PAY_DATE", true, System.Windows.Forms.DataSourceUpdateMode.OnValidation, null, "d"));
            this.txtPayDate.Enabled = false;
            this.txtPayDate.Location = new System.Drawing.Point(316, 34);
            this.txtPayDate.Name = "txtPayDate";
            this.txtPayDate.Size = new System.Drawing.Size(86, 20);
            this.txtPayDate.TabIndex = 94;
            // 
            // textBoxDealerName
            // 
            this.textBoxDealerName.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bindingSourceOPNDEALR, "OPNDEALR_NAME", true));
            this.textBoxDealerName.Enabled = false;
            this.textBoxDealerName.Location = new System.Drawing.Point(567, 34);
            this.textBoxDealerName.Name = "textBoxDealerName";
            this.textBoxDealerName.Size = new System.Drawing.Size(220, 20);
            this.textBoxDealerName.TabIndex = 96;
            // 
            // bindingSourceOPNDEALR
            // 
            this.bindingSourceOPNDEALR.DataMember = "OPNDEALR";
            this.bindingSourceOPNDEALR.DataSource = this.iACDataSet;
            // 
            // textBoxDealerNo
            // 
            this.textBoxDealerNo.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bindingSourceOPNCUST, "CUSTOMER_DEALER", true));
            this.textBoxDealerNo.Enabled = false;
            this.textBoxDealerNo.Location = new System.Drawing.Point(520, 34);
            this.textBoxDealerNo.Name = "textBoxDealerNo";
            this.textBoxDealerNo.Size = new System.Drawing.Size(45, 20);
            this.textBoxDealerNo.TabIndex = 95;
            this.textBoxDealerNo.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // bindingSourceOPNCUST
            // 
            this.bindingSourceOPNCUST.DataMember = "OPNCUST";
            this.bindingSourceOPNCUST.DataSource = this.iACDataSet;
            // 
            // textBoxLastName
            // 
            this.textBoxLastName.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bindingSourceOPNCUST, "CUSTOMER_LAST_NAME", true));
            this.textBoxLastName.Enabled = false;
            this.textBoxLastName.Location = new System.Drawing.Point(614, 11);
            this.textBoxLastName.Name = "textBoxLastName";
            this.textBoxLastName.Size = new System.Drawing.Size(132, 20);
            this.textBoxLastName.TabIndex = 91;
            // 
            // textBoxFirstName
            // 
            this.textBoxFirstName.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bindingSourceOPNCUST, "CUSTOMER_FIRST_NAME", true));
            this.textBoxFirstName.Enabled = false;
            this.textBoxFirstName.Location = new System.Drawing.Point(520, 11);
            this.textBoxFirstName.Name = "textBoxFirstName";
            this.textBoxFirstName.Size = new System.Drawing.Size(92, 20);
            this.textBoxFirstName.TabIndex = 90;
            // 
            // textBoxPurchaseOrder
            // 
            this.textBoxPurchaseOrder.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bindingSourceOPNCUST, "CUSTOMER_PURCHASE_ORDER", true));
            this.textBoxPurchaseOrder.Enabled = false;
            this.textBoxPurchaseOrder.Location = new System.Drawing.Point(138, 34);
            this.textBoxPurchaseOrder.Name = "textBoxPurchaseOrder";
            this.textBoxPurchaseOrder.Size = new System.Drawing.Size(58, 20);
            this.textBoxPurchaseOrder.TabIndex = 93;
            this.textBoxPurchaseOrder.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // textBoxAddOn
            // 
            this.textBoxAddOn.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bindingSourceOPNCUST, "CUSTOMER_ADD_ON", true));
            this.textBoxAddOn.Enabled = false;
            this.textBoxAddOn.Location = new System.Drawing.Point(315, 11);
            this.textBoxAddOn.Name = "textBoxAddOn";
            this.textBoxAddOn.Size = new System.Drawing.Size(17, 20);
            this.textBoxAddOn.TabIndex = 89;
            // 
            // textBoxCustomerNo
            // 
            this.textBoxCustomerNo.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bindingSourceOPNCUST, "CUSTOMER_NO", true));
            this.textBoxCustomerNo.Enabled = false;
            this.textBoxCustomerNo.Location = new System.Drawing.Point(138, 11);
            this.textBoxCustomerNo.Name = "textBoxCustomerNo";
            this.textBoxCustomerNo.Size = new System.Drawing.Size(58, 20);
            this.textBoxCustomerNo.TabIndex = 88;
            this.textBoxCustomerNo.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(260, 20);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(53, 13);
            this.label6.TabIndex = 51;
            this.label6.Text = "ADD ON:";
            // 
            // opndealrTableAdapter
            // 
            this.opndealrTableAdapter.ClearBeforeFill = true;
            // 
            // dataGridViewTextBoxColumnPostDate
            // 
            this.dataGridViewTextBoxColumnPostDate.DataPropertyName = "CUSTHIST_PAY_DATE";
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle2.Format = "d";
            dataGridViewCellStyle2.NullValue = null;
            this.dataGridViewTextBoxColumnPostDate.DefaultCellStyle = dataGridViewCellStyle2;
            this.dataGridViewTextBoxColumnPostDate.HeaderText = "POST DATE";
            this.dataGridViewTextBoxColumnPostDate.Name = "dataGridViewTextBoxColumnPostDate";
            this.dataGridViewTextBoxColumnPostDate.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.dataGridViewTextBoxColumnPostDate.Width = 68;
            // 
            // dataGridViewTextBoxColumn6
            // 
            this.dataGridViewTextBoxColumn6.DataPropertyName = "CUSTHIST_ACT_STAT";
            this.dataGridViewTextBoxColumn6.HeaderText = "ACCOUNT STATUS";
            this.dataGridViewTextBoxColumn6.Name = "dataGridViewTextBoxColumn6";
            this.dataGridViewTextBoxColumn6.Width = 62;
            // 
            // dataGridViewTextBoxColumn9
            // 
            this.dataGridViewTextBoxColumn9.DataPropertyName = "CUSTHIST_PAYMENT_RCV";
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle3.Format = "C2";
            dataGridViewCellStyle3.NullValue = null;
            this.dataGridViewTextBoxColumn9.DefaultCellStyle = dataGridViewCellStyle3;
            this.dataGridViewTextBoxColumn9.HeaderText = "PAYMENT AMOUNT";
            this.dataGridViewTextBoxColumn9.Name = "dataGridViewTextBoxColumn9";
            // 
            // dataGridViewTextBoxColumn8
            // 
            this.dataGridViewTextBoxColumn8.DataPropertyName = "CUSTHIST_BALANCE";
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle4.Format = "C2";
            dataGridViewCellStyle4.NullValue = null;
            this.dataGridViewTextBoxColumn8.DefaultCellStyle = dataGridViewCellStyle4;
            this.dataGridViewTextBoxColumn8.HeaderText = "LOAN BALANCE";
            this.dataGridViewTextBoxColumn8.Name = "dataGridViewTextBoxColumn8";
            // 
            // dataGridViewTextBoxColumn18
            // 
            this.dataGridViewTextBoxColumn18.DataPropertyName = "CUSTHIST_CONTRACT_STATUS";
            dataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle5.Format = "C2";
            dataGridViewCellStyle5.NullValue = null;
            this.dataGridViewTextBoxColumn18.DefaultCellStyle = dataGridViewCellStyle5;
            this.dataGridViewTextBoxColumn18.HeaderText = "CONTRACT STATUS";
            this.dataGridViewTextBoxColumn18.Name = "dataGridViewTextBoxColumn18";
            // 
            // dataGridViewTextBoxColumn13
            // 
            this.dataGridViewTextBoxColumn13.DataPropertyName = "CUSTHIST_LATE_CHARGE_BAL";
            dataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle6.Format = "C2";
            dataGridViewCellStyle6.NullValue = null;
            this.dataGridViewTextBoxColumn13.DefaultCellStyle = dataGridViewCellStyle6;
            this.dataGridViewTextBoxColumn13.HeaderText = "LATE CHARGE BALANCE";
            this.dataGridViewTextBoxColumn13.Name = "dataGridViewTextBoxColumn13";
            // 
            // dataGridViewTextBoxColumn15
            // 
            this.dataGridViewTextBoxColumn15.DataPropertyName = "SHORT_PAID_THRU";
            dataGridViewCellStyle7.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle7.NullValue = null;
            this.dataGridViewTextBoxColumn15.DefaultCellStyle = dataGridViewCellStyle7;
            this.dataGridViewTextBoxColumn15.HeaderText = "PAID THROUGH";
            this.dataGridViewTextBoxColumn15.Name = "dataGridViewTextBoxColumn15";
            this.dataGridViewTextBoxColumn15.ReadOnly = true;
            // 
            // dataGridViewTextBoxColumn16
            // 
            this.dataGridViewTextBoxColumn16.DataPropertyName = "CUSTHIST_PAY_REM_1";
            this.dataGridViewTextBoxColumn16.HeaderText = "PAYMENT TYPE";
            this.dataGridViewTextBoxColumn16.Name = "dataGridViewTextBoxColumn16";
            this.dataGridViewTextBoxColumn16.Width = 70;
            // 
            // dataGridViewTextBoxColumn27
            // 
            this.dataGridViewTextBoxColumn27.DataPropertyName = "CUSTHIST_PAYMENT_TYPE";
            this.dataGridViewTextBoxColumn27.HeaderText = "";
            this.dataGridViewTextBoxColumn27.Name = "dataGridViewTextBoxColumn27";
            this.dataGridViewTextBoxColumn27.Width = 18;
            // 
            // CUSTHIST_PAYMENT_CODE
            // 
            this.CUSTHIST_PAYMENT_CODE.DataPropertyName = "CUSTHIST_PAYMENT_CODE";
            this.CUSTHIST_PAYMENT_CODE.HeaderText = "";
            this.CUSTHIST_PAYMENT_CODE.Name = "CUSTHIST_PAYMENT_CODE";
            this.CUSTHIST_PAYMENT_CODE.Width = 18;
            // 
            // CUSTHIST_DATE_SEQ
            // 
            this.CUSTHIST_DATE_SEQ.DataPropertyName = "CUSTHIST_DATE_SEQ";
            this.CUSTHIST_DATE_SEQ.HeaderText = "";
            this.CUSTHIST_DATE_SEQ.Name = "CUSTHIST_DATE_SEQ";
            this.CUSTHIST_DATE_SEQ.Visible = false;
            // 
            // FormSelectCheck
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.BackColor = System.Drawing.Color.LightSteelBlue;
            this.ClientSize = new System.Drawing.Size(970, 432);
            this.Controls.Add(this.groupBox8);
            this.Controls.Add(this.cUSTHISTDataGridView);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Name = "FormSelectCheck";
            this.Text = "PLEASE SELECT BOUNCED CHECK";
            this.Activated += new System.EventHandler(this.FormSelectCheck_Activated);
            this.Load += new System.EventHandler(this.FormSelectCheck_Load);
            ((System.ComponentModel.ISupportInitialize)(this.cUSTHISTBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.iACDataSet)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cUSTHISTDataGridView)).EndInit();
            this.groupBox8.ResumeLayout(false);
            this.groupBox8.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.bindingSourceOPNDEALR)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bindingSourceOPNCUST)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private IACDataSetTableAdapters.OPNCUSTTableAdapter opncustTableAdapter;
        private IACDataSetTableAdapters.OPNHCUSTTableAdapter opnhcustTableAdapter;
        private System.Windows.Forms.BindingSource cUSTHISTBindingSource;
        private IACDataSet iACDataSet;
        private System.Windows.Forms.DataGridView cUSTHISTDataGridView;
        private System.Windows.Forms.GroupBox groupBox8;
        private System.Windows.Forms.TextBox textBoxSuffix;
        private System.Windows.Forms.TextBox txtPayDate;
        private System.Windows.Forms.TextBox textBoxDealerName;
        private System.Windows.Forms.TextBox textBoxDealerNo;
        private System.Windows.Forms.TextBox textBoxLastName;
        private System.Windows.Forms.TextBox textBoxFirstName;
        private System.Windows.Forms.TextBox textBoxPurchaseOrder;
        private System.Windows.Forms.TextBox textBoxAddOn;
        private System.Windows.Forms.TextBox textBoxCustomerNo;
        private System.Windows.Forms.Label label6;
        private IACDataSetTableAdapters.OPNDEALRTableAdapter opndealrTableAdapter;
        private System.Windows.Forms.BindingSource bindingSourceOPNCUST;
        private System.Windows.Forms.BindingSource bindingSourceOPNDEALR;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumnPostDate;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn6;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn9;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn8;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn18;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn13;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn15;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn16;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn27;
        private System.Windows.Forms.DataGridViewTextBoxColumn CUSTHIST_PAYMENT_CODE;
        private System.Windows.Forms.DataGridViewTextBoxColumn CUSTHIST_DATE_SEQ;
    }
}
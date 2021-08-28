namespace IAC2021SQL
{
    partial class FormVSIExtract
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
            this.textBoxDealerName = new System.Windows.Forms.TextBox();
            this.bindingSourceDLRLISTBYNUM = new System.Windows.Forms.BindingSource(this.components);
            this.iACDataSet = new IAC2021SQL.IACDataSet();
            this.comboBoxDealer = new System.Windows.Forms.ComboBox();
            this.labelDealerNum = new System.Windows.Forms.Label();
            this.labelEndDate = new System.Windows.Forms.Label();
            this.labelStartDate = new System.Windows.Forms.Label();
            this.buttonCancel = new System.Windows.Forms.Button();
            this.buttonPost = new System.Windows.Forms.Button();
            this.textBoxState = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.dLRLISTBYNUMTableAdapter = new IAC2021SQL.IACDataSetTableAdapters.DLRLISTBYNUMTableAdapter();
            this.nullableDateTimePickerEndDate = new ProManApp.NullableDateTimePicker();
            this.nullableDateTimePickerStartDate = new ProManApp.NullableDateTimePicker();
            this.groupBoxSelection = new System.Windows.Forms.GroupBox();
            this.groupBoxButtons = new System.Windows.Forms.GroupBox();
            ((System.ComponentModel.ISupportInitialize)(this.bindingSourceDLRLISTBYNUM)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.iACDataSet)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nullableDateTimePickerEndDate)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nullableDateTimePickerStartDate)).BeginInit();
            this.groupBoxSelection.SuspendLayout();
            this.groupBoxButtons.SuspendLayout();
            this.SuspendLayout();
            // 
            // textBoxDealerName
            // 
            this.textBoxDealerName.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bindingSourceDLRLISTBYNUM, "DEALER_NAME", true));
            this.textBoxDealerName.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBoxDealerName.Location = new System.Drawing.Point(208, 84);
            this.textBoxDealerName.Margin = new System.Windows.Forms.Padding(6, 8, 6, 8);
            this.textBoxDealerName.Name = "textBoxDealerName";
            this.textBoxDealerName.ReadOnly = true;
            this.textBoxDealerName.Size = new System.Drawing.Size(490, 26);
            this.textBoxDealerName.TabIndex = 31;
            // 
            // bindingSourceDLRLISTBYNUM
            // 
            this.bindingSourceDLRLISTBYNUM.DataMember = "DLRLISTBYNUM";
            this.bindingSourceDLRLISTBYNUM.DataSource = this.iACDataSet;
            // 
            // iACDataSet
            // 
            this.iACDataSet.DataSetName = "IACDataSet";
            this.iACDataSet.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // comboBoxDealer
            // 
            this.comboBoxDealer.DataSource = this.bindingSourceDLRLISTBYNUM;
            this.comboBoxDealer.DisplayMember = "DEALER_ACC_NO";
            this.comboBoxDealer.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.comboBoxDealer.FormattingEnabled = true;
            this.comboBoxDealer.Location = new System.Drawing.Point(133, 82);
            this.comboBoxDealer.Margin = new System.Windows.Forms.Padding(6, 8, 6, 8);
            this.comboBoxDealer.Name = "comboBoxDealer";
            this.comboBoxDealer.Size = new System.Drawing.Size(63, 28);
            this.comboBoxDealer.TabIndex = 30;
            this.comboBoxDealer.ValueMember = "DEALER_ACC_NO";
            // 
            // labelDealerNum
            // 
            this.labelDealerNum.AutoSize = true;
            this.labelDealerNum.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelDealerNum.Location = new System.Drawing.Point(61, 90);
            this.labelDealerNum.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.labelDealerNum.Name = "labelDealerNum";
            this.labelDealerNum.Size = new System.Drawing.Size(60, 20);
            this.labelDealerNum.TabIndex = 29;
            this.labelDealerNum.Text = "Dealer:";
            this.labelDealerNum.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // labelEndDate
            // 
            this.labelEndDate.AutoSize = true;
            this.labelEndDate.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelEndDate.Location = new System.Drawing.Point(40, 55);
            this.labelEndDate.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.labelEndDate.Name = "labelEndDate";
            this.labelEndDate.Size = new System.Drawing.Size(81, 20);
            this.labelEndDate.TabIndex = 26;
            this.labelEndDate.Text = "End Date:";
            this.labelEndDate.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // labelStartDate
            // 
            this.labelStartDate.AutoSize = true;
            this.labelStartDate.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelStartDate.Location = new System.Drawing.Point(34, 22);
            this.labelStartDate.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.labelStartDate.Name = "labelStartDate";
            this.labelStartDate.Size = new System.Drawing.Size(87, 20);
            this.labelStartDate.TabIndex = 23;
            this.labelStartDate.Text = "Start Date:";
            this.labelStartDate.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // buttonCancel
            // 
            this.buttonCancel.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonCancel.Image = global::IAC2021SQL.Properties.Resources.Cancel_64x;
            this.buttonCancel.Location = new System.Drawing.Point(276, 15);
            this.buttonCancel.Margin = new System.Windows.Forms.Padding(6, 8, 6, 8);
            this.buttonCancel.Name = "buttonCancel";
            this.buttonCancel.Size = new System.Drawing.Size(168, 154);
            this.buttonCancel.TabIndex = 25;
            this.buttonCancel.UseVisualStyleBackColor = true;
            this.buttonCancel.Click += new System.EventHandler(this.buttonCancel_Click);
            // 
            // buttonPost
            // 
            this.buttonPost.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonPost.Image = global::IAC2021SQL.Properties.Resources.ExportToExcel_64x;
            this.buttonPost.Location = new System.Drawing.Point(46, 15);
            this.buttonPost.Margin = new System.Windows.Forms.Padding(6, 8, 6, 8);
            this.buttonPost.Name = "buttonPost";
            this.buttonPost.Size = new System.Drawing.Size(168, 154);
            this.buttonPost.TabIndex = 24;
            this.buttonPost.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.buttonPost.UseVisualStyleBackColor = true;
            this.buttonPost.Click += new System.EventHandler(this.buttonPost_Click);
            // 
            // textBoxState
            // 
            this.textBoxState.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.textBoxState.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBoxState.Location = new System.Drawing.Point(133, 120);
            this.textBoxState.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.textBoxState.MaxLength = 2;
            this.textBoxState.Name = "textBoxState";
            this.textBoxState.Size = new System.Drawing.Size(29, 26);
            this.textBoxState.TabIndex = 32;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(69, 126);
            this.label1.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(52, 20);
            this.label1.TabIndex = 33;
            this.label1.Text = "State:";
            this.label1.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // dLRLISTBYNUMTableAdapter
            // 
            this.dLRLISTBYNUMTableAdapter.ClearBeforeFill = true;
            // 
            // nullableDateTimePickerEndDate
            // 
            this.nullableDateTimePickerEndDate.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.nullableDateTimePickerEndDate.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.nullableDateTimePickerEndDate.Location = new System.Drawing.Point(133, 49);
            this.nullableDateTimePickerEndDate.Margin = new System.Windows.Forms.Padding(6, 8, 6, 8);
            this.nullableDateTimePickerEndDate.Name = "nullableDateTimePickerEndDate";
            this.nullableDateTimePickerEndDate.Size = new System.Drawing.Size(107, 26);
            this.nullableDateTimePickerEndDate.TabIndex = 28;
            this.nullableDateTimePickerEndDate.Value = new System.DateTime(2018, 1, 30, 0, 0, 0, 0);
            // 
            // nullableDateTimePickerStartDate
            // 
            this.nullableDateTimePickerStartDate.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.nullableDateTimePickerStartDate.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.nullableDateTimePickerStartDate.Location = new System.Drawing.Point(133, 16);
            this.nullableDateTimePickerStartDate.Margin = new System.Windows.Forms.Padding(6, 8, 6, 8);
            this.nullableDateTimePickerStartDate.Name = "nullableDateTimePickerStartDate";
            this.nullableDateTimePickerStartDate.Size = new System.Drawing.Size(107, 26);
            this.nullableDateTimePickerStartDate.TabIndex = 27;
            this.nullableDateTimePickerStartDate.Value = new System.DateTime(2018, 1, 30, 0, 0, 0, 0);
            // 
            // groupBoxSelection
            // 
            this.groupBoxSelection.Controls.Add(this.label1);
            this.groupBoxSelection.Controls.Add(this.textBoxState);
            this.groupBoxSelection.Controls.Add(this.textBoxDealerName);
            this.groupBoxSelection.Controls.Add(this.comboBoxDealer);
            this.groupBoxSelection.Controls.Add(this.labelDealerNum);
            this.groupBoxSelection.Controls.Add(this.nullableDateTimePickerEndDate);
            this.groupBoxSelection.Controls.Add(this.nullableDateTimePickerStartDate);
            this.groupBoxSelection.Controls.Add(this.labelEndDate);
            this.groupBoxSelection.Controls.Add(this.labelStartDate);
            this.groupBoxSelection.Location = new System.Drawing.Point(13, 14);
            this.groupBoxSelection.Name = "groupBoxSelection";
            this.groupBoxSelection.Size = new System.Drawing.Size(807, 163);
            this.groupBoxSelection.TabIndex = 34;
            this.groupBoxSelection.TabStop = false;
            // 
            // groupBoxButtons
            // 
            this.groupBoxButtons.Controls.Add(this.buttonCancel);
            this.groupBoxButtons.Controls.Add(this.buttonPost);
            this.groupBoxButtons.Location = new System.Drawing.Point(171, 192);
            this.groupBoxButtons.Name = "groupBoxButtons";
            this.groupBoxButtons.Size = new System.Drawing.Size(490, 185);
            this.groupBoxButtons.TabIndex = 35;
            this.groupBoxButtons.TabStop = false;
            // 
            // FormVSIExtract
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.LightSteelBlue;
            this.ClientSize = new System.Drawing.Size(832, 389);
            this.Controls.Add(this.groupBoxButtons);
            this.Controls.Add(this.groupBoxSelection);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.Name = "FormVSIExtract";
            this.Text = "Customer VSI Extract";
            this.Load += new System.EventHandler(this.FormVSIExtract_Load);
            ((System.ComponentModel.ISupportInitialize)(this.bindingSourceDLRLISTBYNUM)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.iACDataSet)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nullableDateTimePickerEndDate)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nullableDateTimePickerStartDate)).EndInit();
            this.groupBoxSelection.ResumeLayout(false);
            this.groupBoxSelection.PerformLayout();
            this.groupBoxButtons.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TextBox textBoxDealerName;
        private System.Windows.Forms.ComboBox comboBoxDealer;
        private System.Windows.Forms.Label labelDealerNum;
        private ProManApp.NullableDateTimePicker nullableDateTimePickerEndDate;
        private ProManApp.NullableDateTimePicker nullableDateTimePickerStartDate;
        private System.Windows.Forms.Label labelEndDate;
        private System.Windows.Forms.Label labelStartDate;
        private System.Windows.Forms.Button buttonCancel;
        private System.Windows.Forms.Button buttonPost;
        private System.Windows.Forms.TextBox textBoxState;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.BindingSource bindingSourceDLRLISTBYNUM;
        private IACDataSet iACDataSet;
        private IACDataSetTableAdapters.DLRLISTBYNUMTableAdapter dLRLISTBYNUMTableAdapter;
        private System.Windows.Forms.GroupBox groupBoxSelection;
        private System.Windows.Forms.GroupBox groupBoxButtons;
    }
}
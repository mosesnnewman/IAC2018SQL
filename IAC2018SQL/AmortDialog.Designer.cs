namespace IAC2021SQL
{
    partial class AmortDialog
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(AmortDialog));
            this.btnPrint = new DevExpress.XtraEditors.SimpleButton();
            this.txtLoanAmount = new System.Windows.Forms.TextBox();
            this.txtTerm = new System.Windows.Forms.TextBox();
            this.txtNominalRate = new System.Windows.Forms.TextBox();
            this.txtFirstPayment = new DevExpress.XtraEditors.DateEdit();
            this.txtMonthlyPayment = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.txtTotalPayment = new System.Windows.Forms.TextBox();
            this.txtTotalInterest = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.btnCalc = new DevExpress.XtraEditors.SimpleButton();
            this.buttonPrintScreen = new DevExpress.XtraEditors.SimpleButton();
            this.label7 = new System.Windows.Forms.Label();
            this.dateTimePickerContractDate = new DevExpress.XtraEditors.DateEdit();
            this.label8 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.groupControl1 = new DevExpress.XtraEditors.GroupControl();
            ((System.ComponentModel.ISupportInitialize)(this.txtFirstPayment.Properties.CalendarTimeProperties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtFirstPayment.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dateTimePickerContractDate.Properties.CalendarTimeProperties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dateTimePickerContractDate.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl1)).BeginInit();
            this.groupControl1.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnPrint
            // 
            this.btnPrint.Appearance.Font = new System.Drawing.Font("Segoe UI", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnPrint.Appearance.Options.UseFont = true;
            this.btnPrint.Appearance.Options.UseTextOptions = true;
            this.btnPrint.Appearance.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
            this.btnPrint.Appearance.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap;
            this.btnPrint.Location = new System.Drawing.Point(160, 343);
            this.btnPrint.Name = "btnPrint";
            this.btnPrint.Size = new System.Drawing.Size(137, 99);
            this.btnPrint.TabIndex = 0;
            this.btnPrint.Text = "&Print Amortization Schedule";
            this.btnPrint.Click += new System.EventHandler(this.button1_Click);
            // 
            // txtLoanAmount
            // 
            this.txtLoanAmount.Font = new System.Drawing.Font("Segoe UI", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtLoanAmount.Location = new System.Drawing.Point(262, 47);
            this.txtLoanAmount.Name = "txtLoanAmount";
            this.txtLoanAmount.Size = new System.Drawing.Size(116, 33);
            this.txtLoanAmount.TabIndex = 1;
            this.txtLoanAmount.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.txtLoanAmount.TextChanged += new System.EventHandler(this.txtLoanAmount_TextChanged);
            this.txtLoanAmount.Validated += new System.EventHandler(this.txtLoanAmount_Validated);
            // 
            // txtTerm
            // 
            this.txtTerm.Font = new System.Drawing.Font("Segoe UI", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtTerm.Location = new System.Drawing.Point(346, 80);
            this.txtTerm.Name = "txtTerm";
            this.txtTerm.Size = new System.Drawing.Size(32, 33);
            this.txtTerm.TabIndex = 2;
            this.txtTerm.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.txtTerm.TextChanged += new System.EventHandler(this.txtTerm_TextChanged);
            // 
            // txtNominalRate
            // 
            this.txtNominalRate.Font = new System.Drawing.Font("Segoe UI", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtNominalRate.Location = new System.Drawing.Point(300, 113);
            this.txtNominalRate.Name = "txtNominalRate";
            this.txtNominalRate.Size = new System.Drawing.Size(78, 33);
            this.txtNominalRate.TabIndex = 3;
            this.txtNominalRate.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.txtNominalRate.TextChanged += new System.EventHandler(this.txtAPR_TextChanged);
            // 
            // txtFirstPayment
            // 
            this.txtFirstPayment.EditValue = new System.DateTime(2022, 4, 6, 0, 0, 0, 0);
            this.txtFirstPayment.Location = new System.Drawing.Point(262, 178);
            this.txtFirstPayment.Name = "txtFirstPayment";
            this.txtFirstPayment.Properties.Appearance.Font = new System.Drawing.Font("Segoe UI", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtFirstPayment.Properties.Appearance.Options.UseFont = true;
            this.txtFirstPayment.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.txtFirstPayment.Properties.CalendarTimeProperties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.txtFirstPayment.Properties.CalendarView = DevExpress.XtraEditors.Repository.CalendarView.Fluent;
            this.txtFirstPayment.Properties.LookAndFeel.SkinName = "McSkin";
            this.txtFirstPayment.Properties.LookAndFeel.UseDefaultLookAndFeel = false;
            this.txtFirstPayment.Properties.VistaDisplayMode = DevExpress.Utils.DefaultBoolean.False;
            this.txtFirstPayment.Size = new System.Drawing.Size(116, 32);
            this.txtFirstPayment.TabIndex = 4;
            this.txtFirstPayment.EditValueChanged += new System.EventHandler(this.txtFirstPayment_ValueChanged);
            // 
            // txtMonthlyPayment
            // 
            this.txtMonthlyPayment.Font = new System.Drawing.Font("Segoe UI", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtMonthlyPayment.Location = new System.Drawing.Point(262, 210);
            this.txtMonthlyPayment.Name = "txtMonthlyPayment";
            this.txtMonthlyPayment.Size = new System.Drawing.Size(116, 33);
            this.txtMonthlyPayment.TabIndex = 5;
            this.txtMonthlyPayment.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.txtMonthlyPayment.TextChanged += new System.EventHandler(this.txtMonthlyPayment_TextChanged);
            this.txtMonthlyPayment.Validated += new System.EventHandler(this.txtMonthlyPayment_Validated);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Segoe UI", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(90, 218);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(163, 25);
            this.label4.TabIndex = 10;
            this.label4.Text = "Monthly Payment:";
            // 
            // txtTotalPayment
            // 
            this.txtTotalPayment.Font = new System.Drawing.Font("Segoe UI", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtTotalPayment.Location = new System.Drawing.Point(262, 243);
            this.txtTotalPayment.Name = "txtTotalPayment";
            this.txtTotalPayment.ReadOnly = true;
            this.txtTotalPayment.Size = new System.Drawing.Size(116, 33);
            this.txtTotalPayment.TabIndex = 11;
            this.txtTotalPayment.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // txtTotalInterest
            // 
            this.txtTotalInterest.Font = new System.Drawing.Font("Segoe UI", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtTotalInterest.Location = new System.Drawing.Point(262, 276);
            this.txtTotalInterest.Name = "txtTotalInterest";
            this.txtTotalInterest.ReadOnly = true;
            this.txtTotalInterest.Size = new System.Drawing.Size(116, 33);
            this.txtTotalInterest.TabIndex = 12;
            this.txtTotalInterest.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Segoe UI", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(120, 251);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(133, 25);
            this.label5.TabIndex = 13;
            this.label5.Text = "Total Payment:";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Segoe UI", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(129, 284);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(124, 25);
            this.label6.TabIndex = 14;
            this.label6.Text = "Total Interest:";
            // 
            // btnCalc
            // 
            this.btnCalc.Appearance.Font = new System.Drawing.Font("Segoe UI", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCalc.Appearance.Options.UseFont = true;
            this.btnCalc.Location = new System.Drawing.Point(16, 343);
            this.btnCalc.Name = "btnCalc";
            this.btnCalc.Size = new System.Drawing.Size(137, 99);
            this.btnCalc.TabIndex = 15;
            this.btnCalc.Text = "&Calculate";
            this.btnCalc.Click += new System.EventHandler(this.btnCalc_Click);
            // 
            // buttonPrintScreen
            // 
            this.buttonPrintScreen.Appearance.Font = new System.Drawing.Font("Segoe UI", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonPrintScreen.Appearance.Options.UseFont = true;
            this.buttonPrintScreen.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("buttonPrintScreen.ImageOptions.Image")));
            this.buttonPrintScreen.ImageOptions.ImageToTextAlignment = DevExpress.XtraEditors.ImageAlignToText.TopCenter;
            this.buttonPrintScreen.ImageOptions.Location = DevExpress.XtraEditors.ImageLocation.TopCenter;
            this.buttonPrintScreen.Location = new System.Drawing.Point(304, 343);
            this.buttonPrintScreen.Name = "buttonPrintScreen";
            this.buttonPrintScreen.Size = new System.Drawing.Size(137, 99);
            this.buttonPrintScreen.TabIndex = 16;
            this.buttonPrintScreen.Text = "Print &Screen";
            this.buttonPrintScreen.Click += new System.EventHandler(this.button1_Click_1);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Segoe UI", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(81, 185);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(172, 25);
            this.label7.TabIndex = 18;
            this.label7.Text = "First Payment Date:";
            // 
            // dateTimePickerContractDate
            // 
            this.dateTimePickerContractDate.EditValue = new System.DateTime(2022, 4, 6, 0, 0, 0, 0);
            this.dateTimePickerContractDate.Location = new System.Drawing.Point(262, 146);
            this.dateTimePickerContractDate.Name = "dateTimePickerContractDate";
            this.dateTimePickerContractDate.Properties.Appearance.Font = new System.Drawing.Font("Segoe UI", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dateTimePickerContractDate.Properties.Appearance.Options.UseFont = true;
            this.dateTimePickerContractDate.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.dateTimePickerContractDate.Properties.CalendarTimeProperties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.dateTimePickerContractDate.Properties.CalendarView = DevExpress.XtraEditors.Repository.CalendarView.Fluent;
            this.dateTimePickerContractDate.Properties.LookAndFeel.SkinName = "McSkin";
            this.dateTimePickerContractDate.Properties.LookAndFeel.UseDefaultLookAndFeel = false;
            this.dateTimePickerContractDate.Properties.VistaDisplayMode = DevExpress.Utils.DefaultBoolean.False;
            this.dateTimePickerContractDate.Size = new System.Drawing.Size(116, 32);
            this.dateTimePickerContractDate.TabIndex = 17;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Segoe UI", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.Location = new System.Drawing.Point(124, 55);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(129, 25);
            this.label8.TabIndex = 6;
            this.label8.Text = "Loan Amount:";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Segoe UI", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.Location = new System.Drawing.Point(77, 88);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(176, 25);
            this.label9.TabIndex = 7;
            this.label9.Text = "Term (# of Months):";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("Segoe UI", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label10.Location = new System.Drawing.Point(123, 121);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(130, 25);
            this.label10.TabIndex = 8;
            this.label10.Text = "Nominal Rate:";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Font = new System.Drawing.Font("Segoe UI", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label11.Location = new System.Drawing.Point(121, 153);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(132, 25);
            this.label11.TabIndex = 9;
            this.label11.Text = "Contract Date:";
            // 
            // groupControl1
            // 
            this.groupControl1.Appearance.BackColor = System.Drawing.Color.LightSteelBlue;
            this.groupControl1.Appearance.Options.UseBackColor = true;
            this.groupControl1.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            this.groupControl1.Controls.Add(this.label7);
            this.groupControl1.Controls.Add(this.dateTimePickerContractDate);
            this.groupControl1.Controls.Add(this.buttonPrintScreen);
            this.groupControl1.Controls.Add(this.btnCalc);
            this.groupControl1.Controls.Add(this.label6);
            this.groupControl1.Controls.Add(this.label5);
            this.groupControl1.Controls.Add(this.txtTotalInterest);
            this.groupControl1.Controls.Add(this.txtTotalPayment);
            this.groupControl1.Controls.Add(this.label4);
            this.groupControl1.Controls.Add(this.label11);
            this.groupControl1.Controls.Add(this.label10);
            this.groupControl1.Controls.Add(this.label9);
            this.groupControl1.Controls.Add(this.label8);
            this.groupControl1.Controls.Add(this.txtMonthlyPayment);
            this.groupControl1.Controls.Add(this.txtFirstPayment);
            this.groupControl1.Controls.Add(this.txtNominalRate);
            this.groupControl1.Controls.Add(this.txtTerm);
            this.groupControl1.Controls.Add(this.txtLoanAmount);
            this.groupControl1.Controls.Add(this.btnPrint);
            this.groupControl1.Location = new System.Drawing.Point(0, -2);
            this.groupControl1.Name = "groupControl1";
            this.groupControl1.Size = new System.Drawing.Size(457, 467);
            this.groupControl1.TabIndex = 19;
            this.groupControl1.Text = "groupControl1";
            // 
            // AmortDialog
            // 
            this.Appearance.Options.UseFont = true;
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.ClientSize = new System.Drawing.Size(454, 462);
            this.Controls.Add(this.groupControl1);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Name = "AmortDialog";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Amortization Parameters";
            this.Load += new System.EventHandler(this.AmortDialog_Load);
            ((System.ComponentModel.ISupportInitialize)(this.txtFirstPayment.Properties.CalendarTimeProperties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtFirstPayment.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dateTimePickerContractDate.Properties.CalendarTimeProperties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dateTimePickerContractDate.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl1)).EndInit();
            this.groupControl1.ResumeLayout(false);
            this.groupControl1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraEditors.SimpleButton btnPrint;
        private System.Windows.Forms.TextBox txtLoanAmount;
        private System.Windows.Forms.TextBox txtTerm;
        private System.Windows.Forms.TextBox txtNominalRate;
        private DevExpress.XtraEditors.DateEdit txtFirstPayment;
        private System.Windows.Forms.TextBox txtMonthlyPayment;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtTotalPayment;
        private System.Windows.Forms.TextBox txtTotalInterest;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private DevExpress.XtraEditors.SimpleButton btnCalc;
        private DevExpress.XtraEditors.SimpleButton buttonPrintScreen;
        private System.Windows.Forms.Label label7;
        private DevExpress.XtraEditors.DateEdit dateTimePickerContractDate;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label11;
        private DevExpress.XtraEditors.GroupControl groupControl1;
    }
}
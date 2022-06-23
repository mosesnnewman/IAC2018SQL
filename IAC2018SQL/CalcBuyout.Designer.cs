namespace IAC2021SQL
{
    partial class CalcBuyout
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
            this.nullableDateTimePicker1 = new DevExpress.XtraEditors.DateEdit();
            this.textBoxBuyout = new DevExpress.XtraEditors.TextEdit();
            this.labelBuyout = new DevExpress.XtraEditors.LabelControl();
            this.buttonCalcBuyout = new DevExpress.XtraEditors.SimpleButton();
            this.groupControl1 = new DevExpress.XtraEditors.GroupControl();
            ((System.ComponentModel.ISupportInitialize)(this.nullableDateTimePicker1.Properties.CalendarTimeProperties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nullableDateTimePicker1.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.textBoxBuyout.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl1)).BeginInit();
            this.groupControl1.SuspendLayout();
            this.SuspendLayout();
            // 
            // nullableDateTimePicker1
            // 
            this.nullableDateTimePicker1.EditValue = new System.DateTime(2022, 6, 23, 0, 0, 0, 0);
            this.nullableDateTimePicker1.Location = new System.Drawing.Point(86, 50);
            this.nullableDateTimePicker1.Name = "nullableDateTimePicker1";
            this.nullableDateTimePicker1.Properties.Appearance.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.nullableDateTimePicker1.Properties.Appearance.Options.UseFont = true;
            this.nullableDateTimePicker1.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.nullableDateTimePicker1.Properties.CalendarTimeProperties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.nullableDateTimePicker1.Size = new System.Drawing.Size(112, 26);
            this.nullableDateTimePicker1.TabIndex = 0;
            // 
            // textBoxBuyout
            // 
            this.textBoxBuyout.Location = new System.Drawing.Point(86, 95);
            this.textBoxBuyout.Name = "textBoxBuyout";
            this.textBoxBuyout.Properties.Appearance.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBoxBuyout.Properties.Appearance.Options.UseFont = true;
            this.textBoxBuyout.Properties.ReadOnly = true;
            this.textBoxBuyout.Size = new System.Drawing.Size(139, 26);
            this.textBoxBuyout.TabIndex = 1;
            // 
            // labelBuyout
            // 
            this.labelBuyout.Appearance.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelBuyout.Appearance.Options.UseFont = true;
            this.labelBuyout.Location = new System.Drawing.Point(17, 101);
            this.labelBuyout.Name = "labelBuyout";
            this.labelBuyout.Size = new System.Drawing.Size(66, 20);
            this.labelBuyout.TabIndex = 2;
            this.labelBuyout.Text = "Buyout: ";
            // 
            // buttonCalcBuyout
            // 
            this.buttonCalcBuyout.Appearance.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonCalcBuyout.Appearance.Options.UseFont = true;
            this.buttonCalcBuyout.Location = new System.Drawing.Point(87, 176);
            this.buttonCalcBuyout.Name = "buttonCalcBuyout";
            this.buttonCalcBuyout.Size = new System.Drawing.Size(110, 39);
            this.buttonCalcBuyout.TabIndex = 3;
            this.buttonCalcBuyout.Text = "&Calculate";
            this.buttonCalcBuyout.Click += new System.EventHandler(this.buttonCalcBuyout_Click);
            // 
            // groupControl1
            // 
            this.groupControl1.Appearance.BackColor = System.Drawing.Color.LightSteelBlue;
            this.groupControl1.Appearance.Options.UseBackColor = true;
            this.groupControl1.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            this.groupControl1.Controls.Add(this.buttonCalcBuyout);
            this.groupControl1.Controls.Add(this.labelBuyout);
            this.groupControl1.Controls.Add(this.textBoxBuyout);
            this.groupControl1.Controls.Add(this.nullableDateTimePicker1);
            this.groupControl1.Location = new System.Drawing.Point(0, -1);
            this.groupControl1.Name = "groupControl1";
            this.groupControl1.Size = new System.Drawing.Size(284, 265);
            this.groupControl1.TabIndex = 4;
            this.groupControl1.Text = "groupControl1";
            // 
            // CalcBuyout
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.ClientSize = new System.Drawing.Size(284, 264);
            this.Controls.Add(this.groupControl1);
            this.Name = "CalcBuyout";
            this.Text = "Calculate Buyout";
            this.Load += new System.EventHandler(this.CalcBuyout_Load);
            ((System.ComponentModel.ISupportInitialize)(this.nullableDateTimePicker1.Properties.CalendarTimeProperties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nullableDateTimePicker1.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.textBoxBuyout.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl1)).EndInit();
            this.groupControl1.ResumeLayout(false);
            this.groupControl1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraEditors.DateEdit nullableDateTimePicker1;
        private DevExpress.XtraEditors.TextEdit textBoxBuyout;
        private DevExpress.XtraEditors.LabelControl labelBuyout;
        private DevExpress.XtraEditors.SimpleButton buttonCalcBuyout;
        private DevExpress.XtraEditors.GroupControl groupControl1;
    }
}
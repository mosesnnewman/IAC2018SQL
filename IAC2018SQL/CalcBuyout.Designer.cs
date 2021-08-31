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
            this.nullableDateTimePicker1 = new UIComponent.DateTimePicker();
            this.textBoxBuyout = new System.Windows.Forms.TextBox();
            this.labelBuyout = new System.Windows.Forms.Label();
            this.buttonCalcBuyout = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // nullableDateTimePicker1
            // 
            this.nullableDateTimePicker1.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.nullableDateTimePicker1.Location = new System.Drawing.Point(93, 50);
            this.nullableDateTimePicker1.Name = "nullableDateTimePicker1";
            this.nullableDateTimePicker1.Size = new System.Drawing.Size(99, 20);
            this.nullableDateTimePicker1.TabIndex = 0;
            this.nullableDateTimePicker1.Value = new System.DateTime(2013, 6, 12, 0, 0, 0, 0);
            // 
            // textBoxBuyout
            // 
            this.textBoxBuyout.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBoxBuyout.Location = new System.Drawing.Point(113, 95);
            this.textBoxBuyout.Name = "textBoxBuyout";
            this.textBoxBuyout.ReadOnly = true;
            this.textBoxBuyout.Size = new System.Drawing.Size(139, 26);
            this.textBoxBuyout.TabIndex = 1;
            // 
            // labelBuyout
            // 
            this.labelBuyout.AutoSize = true;
            this.labelBuyout.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelBuyout.Location = new System.Drawing.Point(32, 101);
            this.labelBuyout.Name = "labelBuyout";
            this.labelBuyout.Size = new System.Drawing.Size(75, 20);
            this.labelBuyout.TabIndex = 2;
            this.labelBuyout.Text = "Buyout: ";
            // 
            // buttonCalcBuyout
            // 
            this.buttonCalcBuyout.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonCalcBuyout.Location = new System.Drawing.Point(87, 176);
            this.buttonCalcBuyout.Name = "buttonCalcBuyout";
            this.buttonCalcBuyout.Size = new System.Drawing.Size(110, 39);
            this.buttonCalcBuyout.TabIndex = 3;
            this.buttonCalcBuyout.Text = "&Calculate";
            this.buttonCalcBuyout.UseVisualStyleBackColor = true;
            this.buttonCalcBuyout.Click += new System.EventHandler(this.buttonCalcBuyout_Click);
            // 
            // CalcBuyout
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.ClientSize = new System.Drawing.Size(284, 264);
            this.Controls.Add(this.buttonCalcBuyout);
            this.Controls.Add(this.labelBuyout);
            this.Controls.Add(this.textBoxBuyout);
            this.Controls.Add(this.nullableDateTimePicker1);
            this.Name = "CalcBuyout";
            this.Text = "Calculate Buyout";
            this.Load += new System.EventHandler(this.CalcBuyout_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private UIComponent.DateTimePicker nullableDateTimePicker1;
        private System.Windows.Forms.TextBox textBoxBuyout;
        private System.Windows.Forms.Label labelBuyout;
        private System.Windows.Forms.Button buttonCalcBuyout;
    }
}
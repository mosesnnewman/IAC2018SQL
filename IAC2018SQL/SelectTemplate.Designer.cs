namespace IAC2018SQL
{
    partial class FormTemplates
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
            this.comboBoxTemplates = new System.Windows.Forms.ComboBox();
            this.textBoxMessage = new System.Windows.Forms.TextBox();
            this.buttonSelect = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // comboBoxTemplates
            // 
            this.comboBoxTemplates.FormattingEnabled = true;
            this.comboBoxTemplates.Location = new System.Drawing.Point(19, 26);
            this.comboBoxTemplates.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.comboBoxTemplates.Name = "comboBoxTemplates";
            this.comboBoxTemplates.Size = new System.Drawing.Size(268, 28);
            this.comboBoxTemplates.TabIndex = 0;
            this.comboBoxTemplates.SelectedIndexChanged += new System.EventHandler(this.comboBoxTemplates_SelectedIndexChanged);
            // 
            // textBoxMessage
            // 
            this.textBoxMessage.Location = new System.Drawing.Point(19, 63);
            this.textBoxMessage.Multiline = true;
            this.textBoxMessage.Name = "textBoxMessage";
            this.textBoxMessage.Size = new System.Drawing.Size(268, 178);
            this.textBoxMessage.TabIndex = 1;
            // 
            // buttonSelect
            // 
            this.buttonSelect.Location = new System.Drawing.Point(65, 258);
            this.buttonSelect.Name = "buttonSelect";
            this.buttonSelect.Size = new System.Drawing.Size(176, 41);
            this.buttonSelect.TabIndex = 2;
            this.buttonSelect.Text = "&Select This Template";
            this.buttonSelect.UseVisualStyleBackColor = true;
            this.buttonSelect.Click += new System.EventHandler(this.buttonSelect_Click);
            // 
            // FormTemplates
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(307, 325);
            this.Controls.Add(this.buttonSelect);
            this.Controls.Add(this.textBoxMessage);
            this.Controls.Add(this.comboBoxTemplates);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.Name = "FormTemplates";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Select Template";
            this.Load += new System.EventHandler(this.FormTemplates_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox comboBoxTemplates;
        private System.Windows.Forms.TextBox textBoxMessage;
        private System.Windows.Forms.Button buttonSelect;

    }
}
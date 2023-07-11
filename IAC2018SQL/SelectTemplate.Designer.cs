namespace IAC2021SQL
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
            this.comboBoxTemplates = new DevExpress.XtraEditors.LookUpEdit();
            this.textBoxMessage = new DevExpress.XtraEditors.MemoEdit();
            this.buttonSelect = new DevExpress.XtraEditors.SimpleButton();
            this.groupControl1 = new DevExpress.XtraEditors.GroupControl();
            ((System.ComponentModel.ISupportInitialize)(this.comboBoxTemplates.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.textBoxMessage.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl1)).BeginInit();
            this.groupControl1.SuspendLayout();
            this.SuspendLayout();
            // 
            // comboBoxTemplates
            // 
            this.comboBoxTemplates.Location = new System.Drawing.Point(20, 28);
            this.comboBoxTemplates.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.comboBoxTemplates.Name = "comboBoxTemplates";
            this.comboBoxTemplates.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.comboBoxTemplates.Size = new System.Drawing.Size(268, 20);
            this.comboBoxTemplates.TabIndex = 0;
            this.comboBoxTemplates.EditValueChanged += new System.EventHandler(this.comboBoxTemplates_EditValueChanged);
            // 
            // textBoxMessage
            // 
            this.textBoxMessage.Location = new System.Drawing.Point(20, 65);
            this.textBoxMessage.Name = "textBoxMessage";
            this.textBoxMessage.Properties.Appearance.Options.UseTextOptions = true;
            this.textBoxMessage.Properties.Appearance.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap;
            this.textBoxMessage.Properties.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.textBoxMessage.Size = new System.Drawing.Size(268, 189);
            this.textBoxMessage.TabIndex = 1;
            // 
            // buttonSelect
            // 
            this.buttonSelect.Location = new System.Drawing.Point(66, 260);
            this.buttonSelect.Name = "buttonSelect";
            this.buttonSelect.Size = new System.Drawing.Size(176, 41);
            this.buttonSelect.TabIndex = 2;
            this.buttonSelect.Text = "&Select This Template";
            this.buttonSelect.Click += new System.EventHandler(this.buttonSelect_Click);
            // 
            // groupControl1
            // 
            this.groupControl1.Appearance.BackColor = System.Drawing.Color.LightSteelBlue;
            this.groupControl1.Appearance.Options.UseBackColor = true;
            this.groupControl1.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            this.groupControl1.Controls.Add(this.buttonSelect);
            this.groupControl1.Controls.Add(this.textBoxMessage);
            this.groupControl1.Controls.Add(this.comboBoxTemplates);
            this.groupControl1.Location = new System.Drawing.Point(0, -2);
            this.groupControl1.Name = "groupControl1";
            this.groupControl1.Size = new System.Drawing.Size(308, 329);
            this.groupControl1.TabIndex = 3;
            this.groupControl1.Text = "groupControl1";
            // 
            // FormTemplates
            // 
            this.Appearance.Options.UseFont = true;
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(307, 325);
            this.Controls.Add(this.groupControl1);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.Name = "FormTemplates";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Select Template";
            this.Load += new System.EventHandler(this.FormTemplates_Load);
            ((System.ComponentModel.ISupportInitialize)(this.comboBoxTemplates.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.textBoxMessage.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl1)).EndInit();
            this.groupControl1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraEditors.LookUpEdit comboBoxTemplates; 
        private DevExpress.XtraEditors.MemoEdit textBoxMessage;
        private DevExpress.XtraEditors.SimpleButton buttonSelect;
        private DevExpress.XtraEditors.GroupControl groupControl1;
    }
}
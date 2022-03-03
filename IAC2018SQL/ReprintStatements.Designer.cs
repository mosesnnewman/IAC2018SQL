namespace IAC2021SQL
{
    partial class frmReprintStatements
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
            this.buttonPost = new DevExpress.XtraEditors.SimpleButton();
            this.buttonCancel = new DevExpress.XtraEditors.SimpleButton();
            this.label1 = new DevExpress.XtraEditors.LabelControl();
            this.textBoxMessage = new DevExpress.XtraEditors.TextEdit();
            this.label3 = new DevExpress.XtraEditors.LabelControl();
            this.groupControlReprintStatements = new DevExpress.XtraEditors.GroupControl();
            this.StatementDatenullableDateTimePicker = new DevExpress.XtraEditors.DateEdit();
            ((System.ComponentModel.ISupportInitialize)(this.textBoxMessage.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.groupControlReprintStatements)).BeginInit();
            this.groupControlReprintStatements.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.StatementDatenullableDateTimePicker.Properties.CalendarTimeProperties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.StatementDatenullableDateTimePicker.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // buttonPost
            // 
            this.buttonPost.Appearance.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonPost.Appearance.Options.UseFont = true;
            this.buttonPost.Location = new System.Drawing.Point(108, 126);
            this.buttonPost.Name = "buttonPost";
            this.buttonPost.Size = new System.Drawing.Size(75, 32);
            this.buttonPost.TabIndex = 5;
            this.buttonPost.Text = "&Reprint";
            this.buttonPost.Click += new System.EventHandler(this.buttonPost_Click);
            // 
            // buttonCancel
            // 
            this.buttonCancel.Appearance.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonCancel.Appearance.Options.UseFont = true;
            this.buttonCancel.Location = new System.Drawing.Point(189, 126);
            this.buttonCancel.Name = "buttonCancel";
            this.buttonCancel.Size = new System.Drawing.Size(75, 32);
            this.buttonCancel.TabIndex = 6;
            this.buttonCancel.Text = "&Cancel";
            this.buttonCancel.Click += new System.EventHandler(this.buttonCancel_Click);
            // 
            // label1
            // 
            this.label1.Appearance.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Appearance.Options.UseFont = true;
            this.label1.Location = new System.Drawing.Point(49, 23);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(157, 20);
            this.label1.TabIndex = 5;
            this.label1.Text = "Statement DUE Date:";
            // 
            // textBoxMessage
            // 
            this.textBoxMessage.Location = new System.Drawing.Point(8, 71);
            this.textBoxMessage.Name = "textBoxMessage";
            this.textBoxMessage.Properties.Appearance.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBoxMessage.Properties.Appearance.Options.UseFont = true;
            this.textBoxMessage.Properties.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.textBoxMessage.Properties.MaxLength = 50;
            this.textBoxMessage.Size = new System.Drawing.Size(365, 26);
            this.textBoxMessage.TabIndex = 4;
            this.textBoxMessage.TextChanged += new System.EventHandler(this.textBoxMessage_TextChanged);
            // 
            // label3
            // 
            this.label3.Appearance.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Appearance.Options.UseFont = true;
            this.label3.Location = new System.Drawing.Point(8, 48);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(153, 21);
            this.label3.TabIndex = 8;
            this.label3.Text = "Statement Message:";
            // 
            // groupControlReprintStatements
            // 
            this.groupControlReprintStatements.Appearance.BackColor = System.Drawing.Color.LightSteelBlue;
            this.groupControlReprintStatements.Appearance.Options.UseBackColor = true;
            this.groupControlReprintStatements.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            this.groupControlReprintStatements.Controls.Add(this.StatementDatenullableDateTimePicker);
            this.groupControlReprintStatements.Controls.Add(this.label3);
            this.groupControlReprintStatements.Controls.Add(this.textBoxMessage);
            this.groupControlReprintStatements.Controls.Add(this.label1);
            this.groupControlReprintStatements.Controls.Add(this.buttonCancel);
            this.groupControlReprintStatements.Controls.Add(this.buttonPost);
            this.groupControlReprintStatements.Location = new System.Drawing.Point(0, -2);
            this.groupControlReprintStatements.Name = "groupControlReprintStatements";
            this.groupControlReprintStatements.Size = new System.Drawing.Size(380, 175);
            this.groupControlReprintStatements.TabIndex = 9;
            this.groupControlReprintStatements.Text = "groupControl1";
            // 
            // StatementDatenullableDateTimePicker
            // 
            this.StatementDatenullableDateTimePicker.EditValue = null;
            this.StatementDatenullableDateTimePicker.Location = new System.Drawing.Point(210, 17);
            this.StatementDatenullableDateTimePicker.Name = "StatementDatenullableDateTimePicker";
            this.StatementDatenullableDateTimePicker.Properties.Appearance.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.StatementDatenullableDateTimePicker.Properties.Appearance.Options.UseFont = true;
            this.StatementDatenullableDateTimePicker.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.StatementDatenullableDateTimePicker.Properties.CalendarTimeProperties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.StatementDatenullableDateTimePicker.Properties.CalendarView = DevExpress.XtraEditors.Repository.CalendarView.Fluent;
            this.StatementDatenullableDateTimePicker.Properties.LookAndFeel.SkinName = "McSkin";
            this.StatementDatenullableDateTimePicker.Properties.LookAndFeel.UseDefaultLookAndFeel = false;
            this.StatementDatenullableDateTimePicker.Properties.VistaDisplayMode = DevExpress.Utils.DefaultBoolean.False;
            this.StatementDatenullableDateTimePicker.Size = new System.Drawing.Size(102, 26);
            this.StatementDatenullableDateTimePicker.TabIndex = 9;
            this.StatementDatenullableDateTimePicker.EditValueChanged += new System.EventHandler(this.StatementDatenullableDateTimePicker_EditValueChanged);
            // 
            // frmReprintStatements
            // 
            this.Appearance.Options.UseFont = true;
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.ClientSize = new System.Drawing.Size(379, 173);
            this.Controls.Add(this.groupControlReprintStatements);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Name = "frmReprintStatements";
            this.Text = "Reprint Statements";
            this.Load += new System.EventHandler(this.frmReprintStatements_Load);
            ((System.ComponentModel.ISupportInitialize)(this.textBoxMessage.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.groupControlReprintStatements)).EndInit();
            this.groupControlReprintStatements.ResumeLayout(false);
            this.groupControlReprintStatements.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.StatementDatenullableDateTimePicker.Properties.CalendarTimeProperties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.StatementDatenullableDateTimePicker.Properties)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        
        private DevExpress.XtraEditors.SimpleButton buttonPost;
        private DevExpress.XtraEditors.SimpleButton buttonCancel;
        private DevExpress.XtraEditors.LabelControl label1;
        private DevExpress.XtraEditors.TextEdit textBoxMessage;
        private DevExpress.XtraEditors.LabelControl label3;
        private DevExpress.XtraEditors.GroupControl groupControlReprintStatements;
        private DevExpress.XtraEditors.DateEdit StatementDatenullableDateTimePicker;
    }
}
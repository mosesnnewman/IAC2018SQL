namespace IAC2021SQL
{
    partial class frmImportDefiPDFs
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
            System.Windows.Forms.Label label3;
            System.Windows.Forms.Label label53;
            System.Windows.Forms.Label label7;
            System.Windows.Forms.Label labelLast;
            System.Windows.Forms.Label label2;
            System.Windows.Forms.Label label1;
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmImportDefiPDFs));
            this.buttonTransfer = new System.Windows.Forms.Button();
            this.buttonCancel = new System.Windows.Forms.Button();
            this.groupBoxIndexFields = new System.Windows.Forms.GroupBox();
            this.textBoxSide = new System.Windows.Forms.TextBox();
            this.textBoxSSNLast4 = new System.Windows.Forms.TextBox();
            this.textBoxDealerNo = new System.Windows.Forms.TextBox();
            this.TextBoxLastName = new System.Windows.Forms.TextBox();
            this.TextBoxFirstName = new System.Windows.Forms.TextBox();
            this.TextBoxCutomerNo = new System.Windows.Forms.TextBox();
            this.progressBarStatus = new System.Windows.Forms.ProgressBar();
            this.labelProgress = new System.Windows.Forms.Label();
            this.groupBoxProgress = new System.Windows.Forms.GroupBox();
            label3 = new System.Windows.Forms.Label();
            label53 = new System.Windows.Forms.Label();
            label7 = new System.Windows.Forms.Label();
            labelLast = new System.Windows.Forms.Label();
            label2 = new System.Windows.Forms.Label();
            label1 = new System.Windows.Forms.Label();
            this.groupBoxIndexFields.SuspendLayout();
            this.groupBoxProgress.SuspendLayout();
            this.SuspendLayout();
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new System.Drawing.Point(117, 196);
            label3.Name = "label3";
            label3.Size = new System.Drawing.Size(52, 20);
            label3.TabIndex = 516;
            label3.Text = "SIDE:";
            // 
            // label53
            // 
            label53.AutoSize = true;
            label53.Location = new System.Drawing.Point(36, 163);
            label53.Name = "label53";
            label53.Size = new System.Drawing.Size(133, 20);
            label53.TabIndex = 514;
            label53.Text = "SS NUM (Last 4):";
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Location = new System.Drawing.Point(90, 130);
            label7.Name = "label7";
            label7.Size = new System.Drawing.Size(79, 20);
            label7.TabIndex = 510;
            label7.Text = "DEALER:";
            // 
            // labelLast
            // 
            labelLast.AutoSize = true;
            labelLast.BackColor = System.Drawing.Color.Transparent;
            labelLast.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            labelLast.Location = new System.Drawing.Point(116, 97);
            labelLast.Name = "labelLast";
            labelLast.Size = new System.Drawing.Size(53, 20);
            labelLast.TabIndex = 101;
            labelLast.Text = "LAST:";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.BackColor = System.Drawing.Color.Transparent;
            label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            label2.Location = new System.Drawing.Point(59, 64);
            label2.Name = "label2";
            label2.Size = new System.Drawing.Size(110, 20);
            label2.TabIndex = 19;
            label2.Text = "FIRST NAME:";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            label1.Location = new System.Drawing.Point(65, 31);
            label1.Name = "label1";
            label1.Size = new System.Drawing.Size(104, 20);
            label1.TabIndex = 2;
            label1.Text = "CUSTOMER:";
            // 
            // buttonTransfer
            // 
            this.buttonTransfer.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonTransfer.Image = ((System.Drawing.Image)(resources.GetObject("buttonTransfer.Image")));
            this.buttonTransfer.Location = new System.Drawing.Point(268, 404);
            this.buttonTransfer.Name = "buttonTransfer";
            this.buttonTransfer.Size = new System.Drawing.Size(151, 103);
            this.buttonTransfer.TabIndex = 14;
            this.buttonTransfer.Text = "&Import Defi PDF Images";
            this.buttonTransfer.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.buttonTransfer.UseVisualStyleBackColor = true;
            this.buttonTransfer.Click += new System.EventHandler(this.buttonTransfer_Click);
            // 
            // buttonCancel
            // 
            this.buttonCancel.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonCancel.Image = ((System.Drawing.Image)(resources.GetObject("buttonCancel.Image")));
            this.buttonCancel.Location = new System.Drawing.Point(445, 404);
            this.buttonCancel.Margin = new System.Windows.Forms.Padding(4);
            this.buttonCancel.Name = "buttonCancel";
            this.buttonCancel.Size = new System.Drawing.Size(151, 103);
            this.buttonCancel.TabIndex = 13;
            this.buttonCancel.Text = "&Cancel";
            this.buttonCancel.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.buttonCancel.UseVisualStyleBackColor = true;
            this.buttonCancel.Click += new System.EventHandler(this.buttonCancel_Click);
            // 
            // groupBoxIndexFields
            // 
            this.groupBoxIndexFields.BackColor = System.Drawing.Color.LightSteelBlue;
            this.groupBoxIndexFields.Controls.Add(this.textBoxSide);
            this.groupBoxIndexFields.Controls.Add(label3);
            this.groupBoxIndexFields.Controls.Add(label53);
            this.groupBoxIndexFields.Controls.Add(this.textBoxSSNLast4);
            this.groupBoxIndexFields.Controls.Add(this.textBoxDealerNo);
            this.groupBoxIndexFields.Controls.Add(label7);
            this.groupBoxIndexFields.Controls.Add(labelLast);
            this.groupBoxIndexFields.Controls.Add(this.TextBoxLastName);
            this.groupBoxIndexFields.Controls.Add(this.TextBoxFirstName);
            this.groupBoxIndexFields.Controls.Add(label2);
            this.groupBoxIndexFields.Controls.Add(this.TextBoxCutomerNo);
            this.groupBoxIndexFields.Controls.Add(label1);
            this.groupBoxIndexFields.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBoxIndexFields.Location = new System.Drawing.Point(82, 15);
            this.groupBoxIndexFields.Name = "groupBoxIndexFields";
            this.groupBoxIndexFields.Size = new System.Drawing.Size(512, 244);
            this.groupBoxIndexFields.TabIndex = 15;
            this.groupBoxIndexFields.TabStop = false;
            this.groupBoxIndexFields.Text = "Working On";
            // 
            // textBoxSide
            // 
            this.textBoxSide.Enabled = false;
            this.textBoxSide.Location = new System.Drawing.Point(179, 190);
            this.textBoxSide.Name = "textBoxSide";
            this.textBoxSide.Size = new System.Drawing.Size(92, 26);
            this.textBoxSide.TabIndex = 517;
            // 
            // textBoxSSNLast4
            // 
            this.textBoxSSNLast4.Enabled = false;
            this.textBoxSSNLast4.Location = new System.Drawing.Point(179, 157);
            this.textBoxSSNLast4.Name = "textBoxSSNLast4";
            this.textBoxSSNLast4.Size = new System.Drawing.Size(51, 26);
            this.textBoxSSNLast4.TabIndex = 6;
            this.textBoxSSNLast4.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // textBoxDealerNo
            // 
            this.textBoxDealerNo.Enabled = false;
            this.textBoxDealerNo.Location = new System.Drawing.Point(179, 124);
            this.textBoxDealerNo.Name = "textBoxDealerNo";
            this.textBoxDealerNo.Size = new System.Drawing.Size(52, 26);
            this.textBoxDealerNo.TabIndex = 4;
            this.textBoxDealerNo.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // TextBoxLastName
            // 
            this.TextBoxLastName.AllowDrop = true;
            this.TextBoxLastName.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.TextBoxLastName.Enabled = false;
            this.TextBoxLastName.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TextBoxLastName.Location = new System.Drawing.Point(179, 91);
            this.TextBoxLastName.MaxLength = 18;
            this.TextBoxLastName.Name = "TextBoxLastName";
            this.TextBoxLastName.Size = new System.Drawing.Size(212, 26);
            this.TextBoxLastName.TabIndex = 3;
            // 
            // TextBoxFirstName
            // 
            this.TextBoxFirstName.AllowDrop = true;
            this.TextBoxFirstName.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.TextBoxFirstName.Enabled = false;
            this.TextBoxFirstName.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TextBoxFirstName.ForeColor = System.Drawing.Color.Black;
            this.TextBoxFirstName.Location = new System.Drawing.Point(179, 58);
            this.TextBoxFirstName.MaxLength = 12;
            this.TextBoxFirstName.Name = "TextBoxFirstName";
            this.TextBoxFirstName.Size = new System.Drawing.Size(136, 26);
            this.TextBoxFirstName.TabIndex = 2;
            // 
            // TextBoxCutomerNo
            // 
            this.TextBoxCutomerNo.AllowDrop = true;
            this.TextBoxCutomerNo.BackColor = System.Drawing.Color.Gold;
            this.TextBoxCutomerNo.Enabled = false;
            this.TextBoxCutomerNo.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TextBoxCutomerNo.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.TextBoxCutomerNo.Location = new System.Drawing.Point(179, 25);
            this.TextBoxCutomerNo.MaxLength = 6;
            this.TextBoxCutomerNo.Name = "TextBoxCutomerNo";
            this.TextBoxCutomerNo.Size = new System.Drawing.Size(67, 26);
            this.TextBoxCutomerNo.TabIndex = 1;
            this.TextBoxCutomerNo.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // progressBarStatus
            // 
            this.progressBarStatus.Location = new System.Drawing.Point(82, 334);
            this.progressBarStatus.Name = "progressBarStatus";
            this.progressBarStatus.Size = new System.Drawing.Size(512, 35);
            this.progressBarStatus.Style = System.Windows.Forms.ProgressBarStyle.Continuous;
            this.progressBarStatus.TabIndex = 16;
            // 
            // labelProgress
            // 
            this.labelProgress.AutoSize = true;
            this.labelProgress.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelProgress.Location = new System.Drawing.Point(85, 267);
            this.labelProgress.Name = "labelProgress";
            this.labelProgress.Size = new System.Drawing.Size(0, 16);
            this.labelProgress.TabIndex = 17;
            // 
            // groupBoxProgress
            // 
            this.groupBoxProgress.Controls.Add(this.labelProgress);
            this.groupBoxProgress.Controls.Add(this.progressBarStatus);
            this.groupBoxProgress.Controls.Add(this.groupBoxIndexFields);
            this.groupBoxProgress.Location = new System.Drawing.Point(102, 8);
            this.groupBoxProgress.Name = "groupBoxProgress";
            this.groupBoxProgress.Size = new System.Drawing.Size(677, 384);
            this.groupBoxProgress.TabIndex = 18;
            this.groupBoxProgress.TabStop = false;
            // 
            // frmImportDefiPDFs
            // 
            this.BackColor = System.Drawing.Color.LightSteelBlue;
            this.ClientSize = new System.Drawing.Size(865, 523);
            this.Controls.Add(this.groupBoxProgress);
            this.Controls.Add(this.buttonTransfer);
            this.Controls.Add(this.buttonCancel);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Name = "frmImportDefiPDFs";
            this.Text = "Import Defi PDF Images";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.frmImportDefiPDFs_FormClosed);
            this.groupBoxIndexFields.ResumeLayout(false);
            this.groupBoxIndexFields.PerformLayout();
            this.groupBoxProgress.ResumeLayout(false);
            this.groupBoxProgress.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        public System.Windows.Forms.Button buttonTransfer;
        private System.Windows.Forms.Button buttonCancel;
        private System.Windows.Forms.GroupBox groupBoxIndexFields;
        private System.Windows.Forms.TextBox textBoxSide;
        private System.Windows.Forms.TextBox textBoxSSNLast4;
        private System.Windows.Forms.TextBox textBoxDealerNo;
        private System.Windows.Forms.TextBox TextBoxLastName;
        private System.Windows.Forms.TextBox TextBoxFirstName;
        private System.Windows.Forms.TextBox TextBoxCutomerNo;
        private System.Windows.Forms.ProgressBar progressBarStatus;
        private System.Windows.Forms.Label labelProgress;
        private System.Windows.Forms.GroupBox groupBoxProgress;
    }
}

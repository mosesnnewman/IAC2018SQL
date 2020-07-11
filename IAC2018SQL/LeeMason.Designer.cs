namespace IAC2018SQL
{
    partial class FormLeeMason
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
                SQLBR.Dispose();
                SQLBR = null;
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormLeeMason));
            this.buttonVehicleExtract = new System.Windows.Forms.Button();
            this.buttonLeeMasonImport = new System.Windows.Forms.Button();
            this.buttonClose = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // buttonVehicleExtract
            // 
            this.buttonVehicleExtract.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonVehicleExtract.Image = ((System.Drawing.Image)(resources.GetObject("buttonVehicleExtract.Image")));
            this.buttonVehicleExtract.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.buttonVehicleExtract.Location = new System.Drawing.Point(58, 83);
            this.buttonVehicleExtract.Name = "buttonVehicleExtract";
            this.buttonVehicleExtract.Size = new System.Drawing.Size(104, 103);
            this.buttonVehicleExtract.TabIndex = 0;
            this.buttonVehicleExtract.Text = "&Vehicle Extract";
            this.buttonVehicleExtract.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.buttonVehicleExtract.UseVisualStyleBackColor = true;
            this.buttonVehicleExtract.Click += new System.EventHandler(this.buttonVehicleExtract_Click);
            // 
            // buttonLeeMasonImport
            // 
            this.buttonLeeMasonImport.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonLeeMasonImport.Image = ((System.Drawing.Image)(resources.GetObject("buttonLeeMasonImport.Image")));
            this.buttonLeeMasonImport.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.buttonLeeMasonImport.Location = new System.Drawing.Point(195, 83);
            this.buttonLeeMasonImport.Name = "buttonLeeMasonImport";
            this.buttonLeeMasonImport.Size = new System.Drawing.Size(104, 103);
            this.buttonLeeMasonImport.TabIndex = 1;
            this.buttonLeeMasonImport.Text = "&Lee Mason Import";
            this.buttonLeeMasonImport.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.buttonLeeMasonImport.UseVisualStyleBackColor = true;
            this.buttonLeeMasonImport.Click += new System.EventHandler(this.buttonLeeMasonImport_Click);
            // 
            // buttonClose
            // 
            this.buttonClose.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonClose.Image = ((System.Drawing.Image)(resources.GetObject("buttonClose.Image")));
            this.buttonClose.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.buttonClose.Location = new System.Drawing.Point(331, 83);
            this.buttonClose.Name = "buttonClose";
            this.buttonClose.Size = new System.Drawing.Size(104, 103);
            this.buttonClose.TabIndex = 2;
            this.buttonClose.Text = "&Close";
            this.buttonClose.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.buttonClose.UseVisualStyleBackColor = true;
            this.buttonClose.Click += new System.EventHandler(this.buttonClose_Click);
            // 
            // FormLeeMason
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(495, 269);
            this.Controls.Add(this.buttonClose);
            this.Controls.Add(this.buttonLeeMasonImport);
            this.Controls.Add(this.buttonVehicleExtract);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Name = "FormLeeMason";
            this.Text = "Lee Mason Import and Export";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button buttonVehicleExtract;
        private System.Windows.Forms.Button buttonLeeMasonImport;
        private System.Windows.Forms.Button buttonClose;
    }
}
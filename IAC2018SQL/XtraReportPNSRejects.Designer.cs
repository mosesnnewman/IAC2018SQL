namespace IAC2021SQL
{
    partial class XtraReportPNSRejects
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

        #region Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(XtraReportPNSRejects));
            DevExpress.DataAccess.Sql.StoredProcQuery storedProcQuery1 = new DevExpress.DataAccess.Sql.StoredProcQuery();
            this.Area3 = new DevExpress.XtraReports.UI.DetailBand();
            this.Area1 = new DevExpress.XtraReports.UI.ReportHeaderBand();
            this.Area2 = new DevExpress.XtraReports.UI.PageHeaderBand();
            this.Area4 = new DevExpress.XtraReports.UI.ReportFooterBand();
            this.Area5 = new DevExpress.XtraReports.UI.PageFooterBand();
            this.Name_2 = new DevExpress.XtraReports.UI.XRLabel();
            this.CustomerNo2 = new DevExpress.XtraReports.UI.XRLabel();
            this.Status2 = new DevExpress.XtraReports.UI.XRLabel();
            this.CardType1 = new DevExpress.XtraReports.UI.XRLabel();
            this.Amount2 = new DevExpress.XtraReports.UI.XRLabel();
            this.Reason2 = new DevExpress.XtraReports.UI.XRLabel();
            this.PaymentDate1 = new DevExpress.XtraReports.UI.XRLabel();
            this.IACType1 = new DevExpress.XtraReports.UI.XRLabel();
            this.Text12 = new DevExpress.XtraReports.UI.XRLabel();
            this.gsTitle1 = new DevExpress.XtraReports.UI.XRLabel();
            this.Text2 = new DevExpress.XtraReports.UI.XRLabel();
            this.Text3 = new DevExpress.XtraReports.UI.XRLabel();
            this.Text1 = new DevExpress.XtraReports.UI.XRLabel();
            this.Text4 = new DevExpress.XtraReports.UI.XRLabel();
            this.Picture1 = new DevExpress.XtraReports.UI.XRPictureBox();
            this.PageNofM1 = new DevExpress.XtraReports.UI.XRPageInfo();
            this.gsUserName_1 = new DevExpress.XtraReports.UI.XRLabel();
            this.gsUserID_1 = new DevExpress.XtraReports.UI.XRLabel();
            this.Text5 = new DevExpress.XtraReports.UI.XRLabel();
            this.DataTime1 = new DevExpress.XtraReports.UI.XRPageInfo();
            this.DataDate1 = new DevExpress.XtraReports.UI.XRPageInfo();
            this.Name_1 = new DevExpress.XtraReports.UI.CalculatedField();
            this.gsUserName = new DevExpress.XtraReports.Parameters.Parameter();
            this.gsUserID = new DevExpress.XtraReports.Parameters.Parameter();
            this.gsTitle = new DevExpress.XtraReports.Parameters.Parameter();
            this.sqlDataSource1 = new DevExpress.DataAccess.Sql.SqlDataSource(this.components);
            this.xrLine1 = new DevExpress.XtraReports.UI.XRLine();
            ((System.ComponentModel.ISupportInitialize)(this)).BeginInit();
            // 
            // Area3
            // 
            this.Area3.Controls.AddRange(new DevExpress.XtraReports.UI.XRControl[] {
            this.Name_2,
            this.CustomerNo2,
            this.Status2,
            this.CardType1,
            this.Amount2,
            this.Reason2,
            this.PaymentDate1,
            this.IACType1});
            this.Area3.HeightF = 15F;
            this.Area3.KeepTogether = true;
            this.Area3.Name = "Area3";
            this.Area3.Padding = new DevExpress.XtraPrinting.PaddingInfo(0, 0, 0, 0, 100F);
            this.Area3.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopLeft;
            // 
            // Area1
            // 
            this.Area1.HeightF = 0F;
            this.Area1.KeepTogether = true;
            this.Area1.Name = "Area1";
            this.Area1.Padding = new DevExpress.XtraPrinting.PaddingInfo(0, 0, 0, 0, 100F);
            this.Area1.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopLeft;
            // 
            // Area2
            // 
            this.Area2.Controls.AddRange(new DevExpress.XtraReports.UI.XRControl[] {
            this.xrLine1,
            this.Text12,
            this.gsTitle1,
            this.Text2,
            this.Text3,
            this.Text1,
            this.Text4,
            this.Picture1});
            this.Area2.HeightF = 129.0833F;
            this.Area2.Name = "Area2";
            this.Area2.Padding = new DevExpress.XtraPrinting.PaddingInfo(0, 0, 0, 0, 100F);
            this.Area2.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopLeft;
            // 
            // Area4
            // 
            this.Area4.HeightF = 0F;
            this.Area4.KeepTogether = true;
            this.Area4.Name = "Area4";
            this.Area4.Padding = new DevExpress.XtraPrinting.PaddingInfo(0, 0, 0, 0, 100F);
            this.Area4.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopLeft;
            // 
            // Area5
            // 
            this.Area5.Controls.AddRange(new DevExpress.XtraReports.UI.XRControl[] {
            this.PageNofM1,
            this.gsUserName_1,
            this.gsUserID_1,
            this.Text5,
            this.DataTime1,
            this.DataDate1});
            this.Area5.HeightF = 46.75F;
            this.Area5.Name = "Area5";
            this.Area5.Padding = new DevExpress.XtraPrinting.PaddingInfo(0, 0, 0, 0, 100F);
            this.Area5.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopLeft;
            // 
            // Name_2
            // 
            this.Name_2.BackColor = System.Drawing.Color.Transparent;
            this.Name_2.BorderColor = System.Drawing.Color.Black;
            this.Name_2.Borders = DevExpress.XtraPrinting.BorderSide.None;
            this.Name_2.BorderWidth = 1F;
            this.Name_2.CanGrow = false;
            this.Name_2.ExpressionBindings.AddRange(new DevExpress.XtraReports.UI.ExpressionBinding[] {
            new DevExpress.XtraReports.UI.ExpressionBinding("BeforePrint", "Text", "[Name_1]")});
            this.Name_2.Font = new System.Drawing.Font("Arial", 8F);
            this.Name_2.ForeColor = System.Drawing.Color.Black;
            this.Name_2.LocationFloat = new DevExpress.Utils.PointFloat(175F, 0F);
            this.Name_2.Name = "Name_2";
            this.Name_2.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.Name_2.SizeF = new System.Drawing.SizeF(259.375F, 15.34722F);
            this.Name_2.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopLeft;
            // 
            // CustomerNo2
            // 
            this.CustomerNo2.BackColor = System.Drawing.Color.Transparent;
            this.CustomerNo2.BorderColor = System.Drawing.Color.Black;
            this.CustomerNo2.Borders = DevExpress.XtraPrinting.BorderSide.None;
            this.CustomerNo2.BorderWidth = 1F;
            this.CustomerNo2.CanGrow = false;
            this.CustomerNo2.ExpressionBindings.AddRange(new DevExpress.XtraReports.UI.ExpressionBinding[] {
            new DevExpress.XtraReports.UI.ExpressionBinding("BeforePrint", "Text", "[CustomerNo]")});
            this.CustomerNo2.Font = new System.Drawing.Font("Arial", 8F);
            this.CustomerNo2.ForeColor = System.Drawing.Color.Black;
            this.CustomerNo2.LocationFloat = new DevExpress.Utils.PointFloat(83.33334F, 0F);
            this.CustomerNo2.Name = "CustomerNo2";
            this.CustomerNo2.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.CustomerNo2.SizeF = new System.Drawing.SizeF(56.73611F, 15.34722F);
            this.CustomerNo2.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopLeft;
            // 
            // Status2
            // 
            this.Status2.BackColor = System.Drawing.Color.Transparent;
            this.Status2.BorderColor = System.Drawing.Color.Black;
            this.Status2.Borders = DevExpress.XtraPrinting.BorderSide.None;
            this.Status2.BorderWidth = 1F;
            this.Status2.CanGrow = false;
            this.Status2.ExpressionBindings.AddRange(new DevExpress.XtraReports.UI.ExpressionBinding[] {
            new DevExpress.XtraReports.UI.ExpressionBinding("BeforePrint", "Text", "[Status]")});
            this.Status2.Font = new System.Drawing.Font("Arial", 8F);
            this.Status2.ForeColor = System.Drawing.Color.Black;
            this.Status2.LocationFloat = new DevExpress.Utils.PointFloat(150F, 0F);
            this.Status2.Name = "Status2";
            this.Status2.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.Status2.SizeF = new System.Drawing.SizeF(14.79167F, 15.34722F);
            this.Status2.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopLeft;
            // 
            // CardType1
            // 
            this.CardType1.BackColor = System.Drawing.Color.Transparent;
            this.CardType1.BorderColor = System.Drawing.Color.Black;
            this.CardType1.Borders = DevExpress.XtraPrinting.BorderSide.None;
            this.CardType1.BorderWidth = 1F;
            this.CardType1.CanGrow = false;
            this.CardType1.ExpressionBindings.AddRange(new DevExpress.XtraReports.UI.ExpressionBinding[] {
            new DevExpress.XtraReports.UI.ExpressionBinding("BeforePrint", "Text", "[CardType]")});
            this.CardType1.Font = new System.Drawing.Font("Arial", 8F);
            this.CardType1.ForeColor = System.Drawing.Color.Black;
            this.CardType1.LocationFloat = new DevExpress.Utils.PointFloat(516.6667F, 0F);
            this.CardType1.Name = "CardType1";
            this.CardType1.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.CardType1.SizeF = new System.Drawing.SizeF(76.04166F, 15.34722F);
            this.CardType1.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopLeft;
            // 
            // Amount2
            // 
            this.Amount2.BackColor = System.Drawing.Color.Transparent;
            this.Amount2.BorderColor = System.Drawing.Color.Black;
            this.Amount2.Borders = DevExpress.XtraPrinting.BorderSide.None;
            this.Amount2.BorderWidth = 1F;
            this.Amount2.CanGrow = false;
            this.Amount2.ExpressionBindings.AddRange(new DevExpress.XtraReports.UI.ExpressionBinding[] {
            new DevExpress.XtraReports.UI.ExpressionBinding("BeforePrint", "Text", "[Amount]")});
            this.Amount2.Font = new System.Drawing.Font("Arial", 8F);
            this.Amount2.ForeColor = System.Drawing.Color.Black;
            this.Amount2.LocationFloat = new DevExpress.Utils.PointFloat(441.6667F, 0F);
            this.Amount2.Name = "Amount2";
            this.Amount2.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.Amount2.SizeF = new System.Drawing.SizeF(67.15278F, 15.34722F);
            this.Amount2.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopLeft;
            this.Amount2.TextFormatString = "{0:C2}";
            // 
            // Reason2
            // 
            this.Reason2.BackColor = System.Drawing.Color.Transparent;
            this.Reason2.BorderColor = System.Drawing.Color.Black;
            this.Reason2.Borders = DevExpress.XtraPrinting.BorderSide.None;
            this.Reason2.BorderWidth = 1F;
            this.Reason2.CanGrow = false;
            this.Reason2.ExpressionBindings.AddRange(new DevExpress.XtraReports.UI.ExpressionBinding[] {
            new DevExpress.XtraReports.UI.ExpressionBinding("BeforePrint", "Text", "[Reason]")});
            this.Reason2.Font = new System.Drawing.Font("Arial", 8F);
            this.Reason2.ForeColor = System.Drawing.Color.Black;
            this.Reason2.LocationFloat = new DevExpress.Utils.PointFloat(658.3333F, 0F);
            this.Reason2.Name = "Reason2";
            this.Reason2.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.Reason2.SizeF = new System.Drawing.SizeF(390.625F, 15.34722F);
            this.Reason2.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopLeft;
            // 
            // PaymentDate1
            // 
            this.PaymentDate1.BackColor = System.Drawing.Color.Transparent;
            this.PaymentDate1.BorderColor = System.Drawing.Color.Black;
            this.PaymentDate1.Borders = DevExpress.XtraPrinting.BorderSide.None;
            this.PaymentDate1.BorderWidth = 1F;
            this.PaymentDate1.CanGrow = false;
            this.PaymentDate1.ExpressionBindings.AddRange(new DevExpress.XtraReports.UI.ExpressionBinding[] {
            new DevExpress.XtraReports.UI.ExpressionBinding("BeforePrint", "Text", "[PaymentDate]")});
            this.PaymentDate1.Font = new System.Drawing.Font("Arial", 8F);
            this.PaymentDate1.ForeColor = System.Drawing.Color.Black;
            this.PaymentDate1.LocationFloat = new DevExpress.Utils.PointFloat(0F, 0F);
            this.PaymentDate1.Name = "PaymentDate1";
            this.PaymentDate1.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.PaymentDate1.SizeF = new System.Drawing.SizeF(75F, 12.5F);
            this.PaymentDate1.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopLeft;
            this.PaymentDate1.TextFormatString = "{0:MM/dd/yyyy}";
            // 
            // IACType1
            // 
            this.IACType1.BackColor = System.Drawing.Color.Transparent;
            this.IACType1.BorderColor = System.Drawing.Color.Black;
            this.IACType1.Borders = DevExpress.XtraPrinting.BorderSide.None;
            this.IACType1.BorderWidth = 1F;
            this.IACType1.CanGrow = false;
            this.IACType1.ExpressionBindings.AddRange(new DevExpress.XtraReports.UI.ExpressionBinding[] {
            new DevExpress.XtraReports.UI.ExpressionBinding("BeforePrint", "Text", "[IACType]")});
            this.IACType1.Font = new System.Drawing.Font("Arial", 8F);
            this.IACType1.ForeColor = System.Drawing.Color.Black;
            this.IACType1.LocationFloat = new DevExpress.Utils.PointFloat(616.6667F, 0F);
            this.IACType1.Name = "IACType1";
            this.IACType1.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.IACType1.SizeF = new System.Drawing.SizeF(14.79167F, 15.34722F);
            this.IACType1.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopLeft;
            // 
            // Text12
            // 
            this.Text12.BackColor = System.Drawing.Color.Transparent;
            this.Text12.BorderColor = System.Drawing.Color.Black;
            this.Text12.Borders = DevExpress.XtraPrinting.BorderSide.None;
            this.Text12.BorderWidth = 1F;
            this.Text12.CanGrow = false;
            this.Text12.Font = new System.Drawing.Font("Arial", 8F);
            this.Text12.ForeColor = System.Drawing.Color.Black;
            this.Text12.LocationFloat = new DevExpress.Utils.PointFloat(175F, 108.3333F);
            this.Text12.Name = "Text12";
            this.Text12.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.Text12.SizeF = new System.Drawing.SizeF(36.45833F, 15.34722F);
            this.Text12.StylePriority.UseFont = false;
            this.Text12.StylePriority.UseTextAlignment = false;
            this.Text12.Text = "Name";
            this.Text12.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopLeft;
            // 
            // gsTitle1
            // 
            this.gsTitle1.BackColor = System.Drawing.Color.Transparent;
            this.gsTitle1.BorderColor = System.Drawing.Color.Black;
            this.gsTitle1.Borders = DevExpress.XtraPrinting.BorderSide.None;
            this.gsTitle1.BorderWidth = 1F;
            this.gsTitle1.CanGrow = false;
            this.gsTitle1.ExpressionBindings.AddRange(new DevExpress.XtraReports.UI.ExpressionBinding[] {
            new DevExpress.XtraReports.UI.ExpressionBinding("BeforePrint", "Text", "?gsTitle")});
            this.gsTitle1.Font = new System.Drawing.Font("Arial", 14F, System.Drawing.FontStyle.Bold);
            this.gsTitle1.ForeColor = System.Drawing.Color.Black;
            this.gsTitle1.LocationFloat = new DevExpress.Utils.PointFloat(327.5417F, 58.33333F);
            this.gsTitle1.Name = "gsTitle1";
            this.gsTitle1.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.gsTitle1.SizeF = new System.Drawing.SizeF(422.9167F, 33.33334F);
            this.gsTitle1.StylePriority.UseTextAlignment = false;
            this.gsTitle1.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopLeft;
            // 
            // Text2
            // 
            this.Text2.BackColor = System.Drawing.Color.Transparent;
            this.Text2.BorderColor = System.Drawing.Color.Black;
            this.Text2.Borders = DevExpress.XtraPrinting.BorderSide.None;
            this.Text2.BorderWidth = 1F;
            this.Text2.CanGrow = false;
            this.Text2.Font = new System.Drawing.Font("Arial", 8F);
            this.Text2.ForeColor = System.Drawing.Color.Black;
            this.Text2.LocationFloat = new DevExpress.Utils.PointFloat(516.6668F, 108.3333F);
            this.Text2.Name = "Text2";
            this.Text2.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.Text2.SizeF = new System.Drawing.SizeF(65.62488F, 15.34722F);
            this.Text2.StylePriority.UseFont = false;
            this.Text2.StylePriority.UseTextAlignment = false;
            this.Text2.Text = "Pay Method";
            this.Text2.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopLeft;
            // 
            // Text3
            // 
            this.Text3.BackColor = System.Drawing.Color.Transparent;
            this.Text3.BorderColor = System.Drawing.Color.Black;
            this.Text3.Borders = DevExpress.XtraPrinting.BorderSide.None;
            this.Text3.BorderWidth = 1F;
            this.Text3.CanGrow = false;
            this.Text3.Font = new System.Drawing.Font("Arial", 8F);
            this.Text3.ForeColor = System.Drawing.Color.Black;
            this.Text3.LocationFloat = new DevExpress.Utils.PointFloat(441.6667F, 108.3333F);
            this.Text3.Name = "Text3";
            this.Text3.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.Text3.SizeF = new System.Drawing.SizeF(67.15278F, 15.34722F);
            this.Text3.StylePriority.UseFont = false;
            this.Text3.StylePriority.UseTextAlignment = false;
            this.Text3.Text = "Amount";
            this.Text3.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopLeft;
            // 
            // Text1
            // 
            this.Text1.BackColor = System.Drawing.Color.Transparent;
            this.Text1.BorderColor = System.Drawing.Color.Black;
            this.Text1.Borders = DevExpress.XtraPrinting.BorderSide.None;
            this.Text1.BorderWidth = 1F;
            this.Text1.CanGrow = false;
            this.Text1.Font = new System.Drawing.Font("Arial", 8F);
            this.Text1.ForeColor = System.Drawing.Color.Black;
            this.Text1.LocationFloat = new DevExpress.Utils.PointFloat(0F, 108.3333F);
            this.Text1.Name = "Text1";
            this.Text1.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.Text1.SizeF = new System.Drawing.SizeF(33.33333F, 15.34722F);
            this.Text1.StylePriority.UseFont = false;
            this.Text1.StylePriority.UseTextAlignment = false;
            this.Text1.Text = "Date\n";
            this.Text1.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopLeft;
            // 
            // Text4
            // 
            this.Text4.BackColor = System.Drawing.Color.Transparent;
            this.Text4.BorderColor = System.Drawing.Color.Black;
            this.Text4.Borders = DevExpress.XtraPrinting.BorderSide.None;
            this.Text4.BorderWidth = 1F;
            this.Text4.CanGrow = false;
            this.Text4.Font = new System.Drawing.Font("Arial", 8F);
            this.Text4.ForeColor = System.Drawing.Color.Black;
            this.Text4.LocationFloat = new DevExpress.Utils.PointFloat(600F, 91.66667F);
            this.Text4.Multiline = true;
            this.Text4.Name = "Text4";
            this.Text4.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.Text4.SizeF = new System.Drawing.SizeF(41.66667F, 32.01389F);
            this.Text4.StylePriority.UseFont = false;
            this.Text4.StylePriority.UseTextAlignment = false;
            this.Text4.Text = "Open  Closed\n";
            this.Text4.TextAlignment = DevExpress.XtraPrinting.TextAlignment.BottomLeft;
            // 
            // Picture1
            // 
            this.Picture1.BackColor = System.Drawing.Color.Transparent;
            this.Picture1.BorderColor = System.Drawing.Color.Black;
            this.Picture1.Borders = DevExpress.XtraPrinting.BorderSide.None;
            this.Picture1.BorderWidth = 1F;
            this.Picture1.Font = new System.Drawing.Font("Times New Roman", 9.75F);
            this.Picture1.ForeColor = System.Drawing.Color.Black;
            this.Picture1.ImageSource = new DevExpress.XtraPrinting.Drawing.ImageSource("img", resources.GetString("Picture1.ImageSource"));
            this.Picture1.LocationFloat = new DevExpress.Utils.PointFloat(800F, 0F);
            this.Picture1.Name = "Picture1";
            this.Picture1.Padding = new DevExpress.XtraPrinting.PaddingInfo(0, 0, 0, 0, 100F);
            this.Picture1.SizeF = new System.Drawing.SizeF(246.3889F, 95F);
            // 
            // PageNofM1
            // 
            this.PageNofM1.BackColor = System.Drawing.Color.Transparent;
            this.PageNofM1.BorderColor = System.Drawing.Color.Black;
            this.PageNofM1.Borders = DevExpress.XtraPrinting.BorderSide.None;
            this.PageNofM1.BorderWidth = 1F;
            this.PageNofM1.Font = new System.Drawing.Font("Arial", 10F);
            this.PageNofM1.ForeColor = System.Drawing.Color.Black;
            this.PageNofM1.LocationFloat = new DevExpress.Utils.PointFloat(866.6667F, 0F);
            this.PageNofM1.Name = "PageNofM1";
            this.PageNofM1.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.PageNofM1.SizeF = new System.Drawing.SizeF(158.3333F, 18.33333F);
            this.PageNofM1.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopLeft;
            // 
            // gsUserName_1
            // 
            this.gsUserName_1.BackColor = System.Drawing.Color.Transparent;
            this.gsUserName_1.BorderColor = System.Drawing.Color.Black;
            this.gsUserName_1.Borders = DevExpress.XtraPrinting.BorderSide.None;
            this.gsUserName_1.BorderWidth = 1F;
            this.gsUserName_1.CanGrow = false;
            this.gsUserName_1.ExpressionBindings.AddRange(new DevExpress.XtraReports.UI.ExpressionBinding[] {
            new DevExpress.XtraReports.UI.ExpressionBinding("BeforePrint", "Text", "?gsUserName")});
            this.gsUserName_1.Font = new System.Drawing.Font("Arial", 10F);
            this.gsUserName_1.ForeColor = System.Drawing.Color.Black;
            this.gsUserName_1.LocationFloat = new DevExpress.Utils.PointFloat(291.6667F, 0F);
            this.gsUserName_1.Name = "gsUserName_1";
            this.gsUserName_1.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.gsUserName_1.SizeF = new System.Drawing.SizeF(350F, 18.33333F);
            this.gsUserName_1.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopLeft;
            // 
            // gsUserID_1
            // 
            this.gsUserID_1.BackColor = System.Drawing.Color.Transparent;
            this.gsUserID_1.BorderColor = System.Drawing.Color.Black;
            this.gsUserID_1.Borders = DevExpress.XtraPrinting.BorderSide.None;
            this.gsUserID_1.BorderWidth = 1F;
            this.gsUserID_1.CanGrow = false;
            this.gsUserID_1.ExpressionBindings.AddRange(new DevExpress.XtraReports.UI.ExpressionBinding[] {
            new DevExpress.XtraReports.UI.ExpressionBinding("BeforePrint", "Text", "?gsUserID")});
            this.gsUserID_1.Font = new System.Drawing.Font("Arial", 10F);
            this.gsUserID_1.ForeColor = System.Drawing.Color.Black;
            this.gsUserID_1.LocationFloat = new DevExpress.Utils.PointFloat(250F, 0F);
            this.gsUserID_1.Name = "gsUserID_1";
            this.gsUserID_1.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.gsUserID_1.SizeF = new System.Drawing.SizeF(41.66666F, 18.33333F);
            this.gsUserID_1.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopLeft;
            // 
            // Text5
            // 
            this.Text5.BackColor = System.Drawing.Color.Transparent;
            this.Text5.BorderColor = System.Drawing.Color.Black;
            this.Text5.Borders = DevExpress.XtraPrinting.BorderSide.None;
            this.Text5.BorderWidth = 1F;
            this.Text5.CanGrow = false;
            this.Text5.Font = new System.Drawing.Font("Arial", 10F, System.Drawing.FontStyle.Bold);
            this.Text5.ForeColor = System.Drawing.Color.Black;
            this.Text5.LocationFloat = new DevExpress.Utils.PointFloat(200F, 0F);
            this.Text5.Name = "Text5";
            this.Text5.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.Text5.SizeF = new System.Drawing.SizeF(50F, 18.33333F);
            this.Text5.Text = "USER:";
            this.Text5.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopLeft;
            // 
            // DataTime1
            // 
            this.DataTime1.BackColor = System.Drawing.Color.Transparent;
            this.DataTime1.BorderColor = System.Drawing.Color.Black;
            this.DataTime1.Borders = DevExpress.XtraPrinting.BorderSide.None;
            this.DataTime1.BorderWidth = 1F;
            this.DataTime1.Font = new System.Drawing.Font("Arial", 10F);
            this.DataTime1.ForeColor = System.Drawing.Color.Black;
            this.DataTime1.LocationFloat = new DevExpress.Utils.PointFloat(91.66666F, 0F);
            this.DataTime1.Name = "DataTime1";
            this.DataTime1.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.DataTime1.PageInfo = DevExpress.XtraPrinting.PageInfo.DateTime;
            this.DataTime1.SizeF = new System.Drawing.SizeF(70.83334F, 18.33333F);
            this.DataTime1.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopLeft;
            this.DataTime1.TextFormatString = "{0:t}";
            // 
            // DataDate1
            // 
            this.DataDate1.BackColor = System.Drawing.Color.Transparent;
            this.DataDate1.BorderColor = System.Drawing.Color.Black;
            this.DataDate1.Borders = DevExpress.XtraPrinting.BorderSide.None;
            this.DataDate1.BorderWidth = 1F;
            this.DataDate1.Font = new System.Drawing.Font("Arial", 10F);
            this.DataDate1.ForeColor = System.Drawing.Color.Black;
            this.DataDate1.LocationFloat = new DevExpress.Utils.PointFloat(8.333333F, 0F);
            this.DataDate1.Name = "DataDate1";
            this.DataDate1.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.DataDate1.PageInfo = DevExpress.XtraPrinting.PageInfo.DateTime;
            this.DataDate1.SizeF = new System.Drawing.SizeF(83.33333F, 18.33333F);
            this.DataDate1.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopLeft;
            this.DataDate1.TextFormatString = "{0:MM/dd/yyyy}";
            // 
            // Name_1
            // 
            this.Name_1.DataMember = "PNSRejects";
            this.Name_1.Expression = "Trim([Name])";
            this.Name_1.FieldType = DevExpress.XtraReports.UI.FieldType.String;
            this.Name_1.Name = "Name_1";
            // 
            // gsUserName
            // 
            this.gsUserName.Description = "Enter gsUserName:";
            this.gsUserName.Name = "gsUserName";
            this.gsUserName.ValueInfo = "Moses Newman";
            // 
            // gsUserID
            // 
            this.gsUserID.Description = "Enter gsUserID:";
            this.gsUserID.Name = "gsUserID";
            this.gsUserID.ValueInfo = "MNN";
            // 
            // gsTitle
            // 
            this.gsTitle.Description = "Enter gsTitle:";
            this.gsTitle.Name = "gsTitle";
            this.gsTitle.ValueInfo = "PNS PAYMENT REJECTS REPORT";
            // 
            // sqlDataSource1
            // 
            this.sqlDataSource1.ConnectionName = "IAC2021SQL.Properties.Settings.IAC2010SQLConnectionString";
            this.sqlDataSource1.Name = "sqlDataSource1";
            storedProcQuery1.Name = "PNSRejects";
            storedProcQuery1.StoredProcName = "PNSRejectsSelectAll";
            this.sqlDataSource1.Queries.AddRange(new DevExpress.DataAccess.Sql.SqlQuery[] {
            storedProcQuery1});
            this.sqlDataSource1.ResultSchemaSerializable = resources.GetString("sqlDataSource1.ResultSchemaSerializable");
            // 
            // xrLine1
            // 
            this.xrLine1.LineWidth = 2F;
            this.xrLine1.LocationFloat = new DevExpress.Utils.PointFloat(1.958338F, 124.0833F);
            this.xrLine1.Name = "xrLine1";
            this.xrLine1.SizeF = new System.Drawing.SizeF(1047F, 2.083333F);
            // 
            // XtraReportPNSRejects
            // 
            this.Bands.AddRange(new DevExpress.XtraReports.UI.Band[] {
            this.Area3,
            this.Area1,
            this.Area2,
            this.Area4,
            this.Area5});
            this.CalculatedFields.AddRange(new DevExpress.XtraReports.UI.CalculatedField[] {
            this.Name_1});
            this.ComponentStorage.AddRange(new System.ComponentModel.IComponent[] {
            this.sqlDataSource1});
            this.DataMember = "PNSRejects";
            this.DataSource = this.sqlDataSource1;
            this.Landscape = true;
            this.Margins = new System.Drawing.Printing.Margins(22, 22, 22, 22);
            this.PageHeight = 850;
            this.PageWidth = 1100;
            this.ParameterPanelLayoutItems.AddRange(new DevExpress.XtraReports.Parameters.ParameterPanelLayoutItem[] {
            new DevExpress.XtraReports.Parameters.ParameterLayoutItem(this.gsUserName, DevExpress.XtraReports.Parameters.Orientation.Horizontal),
            new DevExpress.XtraReports.Parameters.ParameterLayoutItem(this.gsUserID, DevExpress.XtraReports.Parameters.Orientation.Horizontal),
            new DevExpress.XtraReports.Parameters.ParameterLayoutItem(this.gsTitle, DevExpress.XtraReports.Parameters.Orientation.Horizontal)});
            this.Parameters.AddRange(new DevExpress.XtraReports.Parameters.Parameter[] {
            this.gsUserName,
            this.gsUserID,
            this.gsTitle});
            this.Version = "22.1";
            ((System.ComponentModel.ISupportInitialize)(this)).EndInit();

        }

        #endregion

        private DevExpress.XtraReports.UI.DetailBand Area3;
        private DevExpress.XtraReports.UI.XRLabel Name_2;
        private DevExpress.XtraReports.UI.XRLabel CustomerNo2;
        private DevExpress.XtraReports.UI.XRLabel Status2;
        private DevExpress.XtraReports.UI.XRLabel CardType1;
        private DevExpress.XtraReports.UI.XRLabel Amount2;
        private DevExpress.XtraReports.UI.XRLabel Reason2;
        private DevExpress.XtraReports.UI.XRLabel PaymentDate1;
        private DevExpress.XtraReports.UI.XRLabel IACType1;
        private DevExpress.XtraReports.UI.ReportHeaderBand Area1;
        private DevExpress.XtraReports.UI.PageHeaderBand Area2;
        private DevExpress.XtraReports.UI.XRLabel Text12;
        private DevExpress.XtraReports.UI.XRLabel gsTitle1;
        private DevExpress.XtraReports.UI.XRLabel Text2;
        private DevExpress.XtraReports.UI.XRLabel Text3;
        private DevExpress.XtraReports.UI.XRLabel Text1;
        private DevExpress.XtraReports.UI.XRLabel Text4;
        private DevExpress.XtraReports.UI.XRPictureBox Picture1;
        private DevExpress.XtraReports.UI.ReportFooterBand Area4;
        private DevExpress.XtraReports.UI.PageFooterBand Area5;
        private DevExpress.XtraReports.UI.XRPageInfo PageNofM1;
        private DevExpress.XtraReports.UI.XRLabel gsUserName_1;
        private DevExpress.XtraReports.UI.XRLabel gsUserID_1;
        private DevExpress.XtraReports.UI.XRLabel Text5;
        private DevExpress.XtraReports.UI.XRPageInfo DataTime1;
        private DevExpress.XtraReports.UI.XRPageInfo DataDate1;
        private DevExpress.XtraReports.UI.CalculatedField Name_1;
        private DevExpress.XtraReports.Parameters.Parameter gsUserName;
        private DevExpress.XtraReports.Parameters.Parameter gsUserID;
        private DevExpress.XtraReports.Parameters.Parameter gsTitle;
        private DevExpress.DataAccess.Sql.SqlDataSource sqlDataSource1;
        private DevExpress.XtraReports.UI.XRLine xrLine1;
    }
}

namespace IAC2021SQL
{
    partial class XtraReportClosedPaymentTypeSummary
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(XtraReportClosedPaymentTypeSummary));
            DevExpress.XtraReports.UI.XRSummary xrSummary1 = new DevExpress.XtraReports.UI.XRSummary();
            DevExpress.XtraReports.UI.XRSummary xrSummary2 = new DevExpress.XtraReports.UI.XRSummary();
            DevExpress.XtraReports.UI.XRSummary xrSummary3 = new DevExpress.XtraReports.UI.XRSummary();
            DevExpress.DataAccess.Sql.StoredProcQuery storedProcQuery1 = new DevExpress.DataAccess.Sql.StoredProcQuery();
            this.Area3 = new DevExpress.XtraReports.UI.DetailBand();
            this.PAYMENTTYPE1 = new DevExpress.XtraReports.UI.XRLabel();
            this.PAYMENTCODE21 = new DevExpress.XtraReports.UI.XRLabel();
            this.CreditCardType1 = new DevExpress.XtraReports.UI.XRLabel();
            this.FeeTot1 = new DevExpress.XtraReports.UI.XRLabel();
            this.TOTAL1 = new DevExpress.XtraReports.UI.XRLabel();
            this.TypeCount1 = new DevExpress.XtraReports.UI.XRLabel();
            this.Area1 = new DevExpress.XtraReports.UI.ReportHeaderBand();
            this.Section1 = new DevExpress.XtraReports.UI.SubBand();
            this.ReportHeaderSection1 = new DevExpress.XtraReports.UI.SubBand();
            this.Picture1 = new DevExpress.XtraReports.UI.XRPictureBox();
            this.gsFormTitle1 = new DevExpress.XtraReports.UI.XRLabel();
            this.Line1 = new DevExpress.XtraReports.UI.XRLine();
            this.Text6 = new DevExpress.XtraReports.UI.XRLabel();
            this.Text5 = new DevExpress.XtraReports.UI.XRLabel();
            this.Text4 = new DevExpress.XtraReports.UI.XRLabel();
            this.Text3 = new DevExpress.XtraReports.UI.XRLabel();
            this.Text2 = new DevExpress.XtraReports.UI.XRLabel();
            this.Title = new DevExpress.XtraReports.UI.XRLabel();
            this.Text1 = new DevExpress.XtraReports.UI.XRLabel();
            this.PageHeaderArea1 = new DevExpress.XtraReports.UI.PageHeaderBand();
            this.Area4 = new DevExpress.XtraReports.UI.ReportFooterBand();
            this.Section4 = new DevExpress.XtraReports.UI.SubBand();
            this.Text7 = new DevExpress.XtraReports.UI.XRLabel();
            this.TotalFees1 = new DevExpress.XtraReports.UI.XRLabel();
            this.Line3 = new DevExpress.XtraReports.UI.XRLine();
            this.TotalAmount1 = new DevExpress.XtraReports.UI.XRLabel();
            this.TotalCount1 = new DevExpress.XtraReports.UI.XRLabel();
            this.ReportFooterSection1 = new DevExpress.XtraReports.UI.SubBand();
            this.PageFooterArea1 = new DevExpress.XtraReports.UI.PageFooterBand();
            this.DataDate1 = new DevExpress.XtraReports.UI.XRPageInfo();
            this.DataTime1 = new DevExpress.XtraReports.UI.XRPageInfo();
            this.xrLabel1 = new DevExpress.XtraReports.UI.XRLabel();
            this.gsUserID_1 = new DevExpress.XtraReports.UI.XRLabel();
            this.gsUserName_1 = new DevExpress.XtraReports.UI.XRLabel();
            this.PageNofM1 = new DevExpress.XtraReports.UI.XRPageInfo();
            this.sqlDataSource1 = new DevExpress.DataAccess.Sql.SqlDataSource(this.components);
            this.topMarginBand1 = new DevExpress.XtraReports.UI.TopMarginBand();
            this.bottomMarginBand1 = new DevExpress.XtraReports.UI.BottomMarginBand();
            this.gsUserID = new DevExpress.XtraReports.Parameters.Parameter();
            this.gsUserName = new DevExpress.XtraReports.Parameters.Parameter();
            this.gsFormTitle = new DevExpress.XtraReports.Parameters.Parameter();
            ((System.ComponentModel.ISupportInitialize)(this)).BeginInit();
            // 
            // Area3
            // 
            this.Area3.Controls.AddRange(new DevExpress.XtraReports.UI.XRControl[] {
            this.PAYMENTTYPE1,
            this.PAYMENTCODE21,
            this.CreditCardType1,
            this.FeeTot1,
            this.TOTAL1,
            this.TypeCount1});
            this.Area3.HeightF = 15.34722F;
            this.Area3.KeepTogether = true;
            this.Area3.Name = "Area3";
            this.Area3.Padding = new DevExpress.XtraPrinting.PaddingInfo(0, 0, 0, 0, 100F);
            this.Area3.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopLeft;
            // 
            // PAYMENTTYPE1
            // 
            this.PAYMENTTYPE1.BackColor = System.Drawing.Color.Transparent;
            this.PAYMENTTYPE1.BorderColor = System.Drawing.Color.Black;
            this.PAYMENTTYPE1.Borders = DevExpress.XtraPrinting.BorderSide.None;
            this.PAYMENTTYPE1.BorderWidth = 1F;
            this.PAYMENTTYPE1.CanGrow = false;
            this.PAYMENTTYPE1.ExpressionBindings.AddRange(new DevExpress.XtraReports.UI.ExpressionBinding[] {
            new DevExpress.XtraReports.UI.ExpressionBinding("BeforePrint", "Text", "[PAYMENT_TYPE]")});
            this.PAYMENTTYPE1.Font = new DevExpress.Drawing.DXFont("Arial", 10F);
            this.PAYMENTTYPE1.ForeColor = System.Drawing.Color.Black;
            this.PAYMENTTYPE1.LocationFloat = new DevExpress.Utils.PointFloat(260.8229F, 0F);
            this.PAYMENTTYPE1.Name = "PAYMENTTYPE1";
            this.PAYMENTTYPE1.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.PAYMENTTYPE1.SizeF = new System.Drawing.SizeF(33.33333F, 15.34722F);
            this.PAYMENTTYPE1.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopCenter;
            // 
            // PAYMENTCODE21
            // 
            this.PAYMENTCODE21.BackColor = System.Drawing.Color.Transparent;
            this.PAYMENTCODE21.BorderColor = System.Drawing.Color.Black;
            this.PAYMENTCODE21.Borders = DevExpress.XtraPrinting.BorderSide.None;
            this.PAYMENTCODE21.BorderWidth = 1F;
            this.PAYMENTCODE21.CanGrow = false;
            this.PAYMENTCODE21.ExpressionBindings.AddRange(new DevExpress.XtraReports.UI.ExpressionBinding[] {
            new DevExpress.XtraReports.UI.ExpressionBinding("BeforePrint", "Text", "[PAYMENT_CODE_2]")});
            this.PAYMENTCODE21.Font = new DevExpress.Drawing.DXFont("Arial", 10F);
            this.PAYMENTCODE21.ForeColor = System.Drawing.Color.Black;
            this.PAYMENTCODE21.LocationFloat = new DevExpress.Utils.PointFloat(313.948F, 0F);
            this.PAYMENTCODE21.Name = "PAYMENTCODE21";
            this.PAYMENTCODE21.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.PAYMENTCODE21.SizeF = new System.Drawing.SizeF(33.33333F, 15.34722F);
            this.PAYMENTCODE21.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopCenter;
            // 
            // CreditCardType1
            // 
            this.CreditCardType1.BackColor = System.Drawing.Color.Transparent;
            this.CreditCardType1.BorderColor = System.Drawing.Color.Black;
            this.CreditCardType1.Borders = DevExpress.XtraPrinting.BorderSide.None;
            this.CreditCardType1.BorderWidth = 1F;
            this.CreditCardType1.CanGrow = false;
            this.CreditCardType1.ExpressionBindings.AddRange(new DevExpress.XtraReports.UI.ExpressionBinding[] {
            new DevExpress.XtraReports.UI.ExpressionBinding("BeforePrint", "Text", "[CreditCardType]")});
            this.CreditCardType1.Font = new DevExpress.Drawing.DXFont("Arial", 10F);
            this.CreditCardType1.ForeColor = System.Drawing.Color.Black;
            this.CreditCardType1.LocationFloat = new DevExpress.Utils.PointFloat(374.8854F, 0F);
            this.CreditCardType1.Name = "CreditCardType1";
            this.CreditCardType1.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.CreditCardType1.SizeF = new System.Drawing.SizeF(89.58334F, 15.34722F);
            this.CreditCardType1.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopLeft;
            // 
            // FeeTot1
            // 
            this.FeeTot1.BackColor = System.Drawing.Color.Transparent;
            this.FeeTot1.BorderColor = System.Drawing.Color.Black;
            this.FeeTot1.Borders = DevExpress.XtraPrinting.BorderSide.None;
            this.FeeTot1.BorderWidth = 1F;
            this.FeeTot1.CanGrow = false;
            this.FeeTot1.ExpressionBindings.AddRange(new DevExpress.XtraReports.UI.ExpressionBinding[] {
            new DevExpress.XtraReports.UI.ExpressionBinding("BeforePrint", "Text", "[FeeTot]")});
            this.FeeTot1.Font = new DevExpress.Drawing.DXFont("Arial", 10F);
            this.FeeTot1.ForeColor = System.Drawing.Color.Black;
            this.FeeTot1.LocationFloat = new DevExpress.Utils.PointFloat(624.8854F, 0F);
            this.FeeTot1.Name = "FeeTot1";
            this.FeeTot1.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.FeeTot1.SizeF = new System.Drawing.SizeF(83.33334F, 15.34722F);
            this.FeeTot1.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopRight;
            this.FeeTot1.TextFormatString = "{0:C2}";
            // 
            // TOTAL1
            // 
            this.TOTAL1.BackColor = System.Drawing.Color.Transparent;
            this.TOTAL1.BorderColor = System.Drawing.Color.Black;
            this.TOTAL1.Borders = DevExpress.XtraPrinting.BorderSide.None;
            this.TOTAL1.BorderWidth = 1F;
            this.TOTAL1.CanGrow = false;
            this.TOTAL1.ExpressionBindings.AddRange(new DevExpress.XtraReports.UI.ExpressionBinding[] {
            new DevExpress.XtraReports.UI.ExpressionBinding("BeforePrint", "Text", "[TOTAL]")});
            this.TOTAL1.Font = new DevExpress.Drawing.DXFont("Arial", 10F);
            this.TOTAL1.ForeColor = System.Drawing.Color.Black;
            this.TOTAL1.LocationFloat = new DevExpress.Utils.PointFloat(733.2188F, 0F);
            this.TOTAL1.Name = "TOTAL1";
            this.TOTAL1.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.TOTAL1.SizeF = new System.Drawing.SizeF(83.33334F, 15.34722F);
            this.TOTAL1.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopRight;
            this.TOTAL1.TextFormatString = "{0:C2}";
            // 
            // TypeCount1
            // 
            this.TypeCount1.BackColor = System.Drawing.Color.Transparent;
            this.TypeCount1.BorderColor = System.Drawing.Color.Black;
            this.TypeCount1.Borders = DevExpress.XtraPrinting.BorderSide.None;
            this.TypeCount1.BorderWidth = 1F;
            this.TypeCount1.CanGrow = false;
            this.TypeCount1.ExpressionBindings.AddRange(new DevExpress.XtraReports.UI.ExpressionBinding[] {
            new DevExpress.XtraReports.UI.ExpressionBinding("BeforePrint", "Text", "[TypeCount]")});
            this.TypeCount1.Font = new DevExpress.Drawing.DXFont("Arial", 10F);
            this.TypeCount1.ForeColor = System.Drawing.Color.Black;
            this.TypeCount1.LocationFloat = new DevExpress.Utils.PointFloat(549.8854F, 0F);
            this.TypeCount1.Name = "TypeCount1";
            this.TypeCount1.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.TypeCount1.SizeF = new System.Drawing.SizeF(61.45833F, 15.34722F);
            this.TypeCount1.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopRight;
            // 
            // Area1
            // 
            this.Area1.HeightF = 0F;
            this.Area1.Name = "Area1";
            this.Area1.Padding = new DevExpress.XtraPrinting.PaddingInfo(0, 0, 0, 0, 100F);
            this.Area1.SubBands.AddRange(new DevExpress.XtraReports.UI.SubBand[] {
            this.Section1,
            this.ReportHeaderSection1});
            this.Area1.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopLeft;
            // 
            // Section1
            // 
            this.Section1.HeightF = 0F;
            this.Section1.KeepTogether = true;
            this.Section1.Name = "Section1";
            this.Section1.Padding = new DevExpress.XtraPrinting.PaddingInfo(0, 0, 0, 0, 100F);
            this.Section1.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopLeft;
            // 
            // ReportHeaderSection1
            // 
            this.ReportHeaderSection1.Controls.AddRange(new DevExpress.XtraReports.UI.XRControl[] {
            this.Picture1,
            this.gsFormTitle1,
            this.Line1,
            this.Text6,
            this.Text5,
            this.Text4,
            this.Text3,
            this.Text2,
            this.Title,
            this.Text1});
            this.ReportHeaderSection1.HeightF = 189.1667F;
            this.ReportHeaderSection1.KeepTogether = true;
            this.ReportHeaderSection1.Name = "ReportHeaderSection1";
            this.ReportHeaderSection1.Padding = new DevExpress.XtraPrinting.PaddingInfo(0, 0, 0, 0, 100F);
            this.ReportHeaderSection1.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopLeft;
            // 
            // Picture1
            // 
            this.Picture1.BackColor = System.Drawing.Color.Transparent;
            this.Picture1.BorderColor = System.Drawing.Color.Black;
            this.Picture1.Borders = DevExpress.XtraPrinting.BorderSide.None;
            this.Picture1.BorderWidth = 1F;
            this.Picture1.Font = new DevExpress.Drawing.DXFont("Times New Roman", 9.75F);
            this.Picture1.ForeColor = System.Drawing.Color.Black;
            this.Picture1.ImageSource = new DevExpress.XtraPrinting.Drawing.ImageSource("img", resources.GetString("Picture1.ImageSource"));
            this.Picture1.LocationFloat = new DevExpress.Utils.PointFloat(809.6111F, 0F);
            this.Picture1.Name = "Picture1";
            this.Picture1.Padding = new DevExpress.XtraPrinting.PaddingInfo(0, 0, 0, 0, 100F);
            this.Picture1.SizeF = new System.Drawing.SizeF(246.3889F, 95F);
            // 
            // gsFormTitle1
            // 
            this.gsFormTitle1.BackColor = System.Drawing.Color.Transparent;
            this.gsFormTitle1.BorderColor = System.Drawing.Color.Black;
            this.gsFormTitle1.Borders = DevExpress.XtraPrinting.BorderSide.None;
            this.gsFormTitle1.BorderWidth = 1F;
            this.gsFormTitle1.CanGrow = false;
            this.gsFormTitle1.ExpressionBindings.AddRange(new DevExpress.XtraReports.UI.ExpressionBinding[] {
            new DevExpress.XtraReports.UI.ExpressionBinding("BeforePrint", "Text", "?gsFormTitle")});
            this.gsFormTitle1.Font = new DevExpress.Drawing.DXFont("Segoe UI", 14F, DevExpress.Drawing.DXFontStyle.Bold);
            this.gsFormTitle1.ForeColor = System.Drawing.Color.Black;
            this.gsFormTitle1.LocationFloat = new DevExpress.Utils.PointFloat(275.6667F, 66.66665F);
            this.gsFormTitle1.Name = "gsFormTitle1";
            this.gsFormTitle1.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.gsFormTitle1.SizeF = new System.Drawing.SizeF(516.6667F, 25F);
            this.gsFormTitle1.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopLeft;
            // 
            // Line1
            // 
            this.Line1.BackColor = System.Drawing.Color.Transparent;
            this.Line1.BorderColor = System.Drawing.Color.Black;
            this.Line1.Borders = DevExpress.XtraPrinting.BorderSide.Top;
            this.Line1.BorderWidth = 1F;
            this.Line1.Font = new DevExpress.Drawing.DXFont("Times New Roman", 9.75F);
            this.Line1.ForeColor = System.Drawing.Color.Black;
            this.Line1.LineWidth = 4F;
            this.Line1.LocationFloat = new DevExpress.Utils.PointFloat(251.4479F, 182F);
            this.Line1.Name = "Line1";
            this.Line1.Padding = new DevExpress.XtraPrinting.PaddingInfo(0, 0, 0, 0, 100F);
            this.Line1.SizeF = new System.Drawing.SizeF(565.1042F, 4.166687F);
            // 
            // Text6
            // 
            this.Text6.BackColor = System.Drawing.Color.Transparent;
            this.Text6.BorderColor = System.Drawing.Color.Black;
            this.Text6.Borders = DevExpress.XtraPrinting.BorderSide.None;
            this.Text6.BorderWidth = 1F;
            this.Text6.CanGrow = false;
            this.Text6.Font = new DevExpress.Drawing.DXFont("Arial", 10F, DevExpress.Drawing.DXFontStyle.Bold);
            this.Text6.ForeColor = System.Drawing.Color.Black;
            this.Text6.LocationFloat = new DevExpress.Utils.PointFloat(733.2188F, 160.4027F);
            this.Text6.Name = "Text6";
            this.Text6.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.Text6.SizeF = new System.Drawing.SizeF(83.33334F, 15.34722F);
            this.Text6.Text = "TOTAL";
            this.Text6.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopRight;
            // 
            // Text5
            // 
            this.Text5.BackColor = System.Drawing.Color.Transparent;
            this.Text5.BorderColor = System.Drawing.Color.Black;
            this.Text5.Borders = DevExpress.XtraPrinting.BorderSide.None;
            this.Text5.BorderWidth = 1F;
            this.Text5.CanGrow = false;
            this.Text5.Font = new DevExpress.Drawing.DXFont("Arial", 10F, DevExpress.Drawing.DXFontStyle.Bold);
            this.Text5.ForeColor = System.Drawing.Color.Black;
            this.Text5.LocationFloat = new DevExpress.Utils.PointFloat(624.8854F, 160.4027F);
            this.Text5.Name = "Text5";
            this.Text5.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.Text5.SizeF = new System.Drawing.SizeF(83.33334F, 15.34722F);
            this.Text5.Text = "Total Fees";
            this.Text5.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopRight;
            // 
            // Text4
            // 
            this.Text4.BackColor = System.Drawing.Color.Transparent;
            this.Text4.BorderColor = System.Drawing.Color.Black;
            this.Text4.Borders = DevExpress.XtraPrinting.BorderSide.None;
            this.Text4.BorderWidth = 1F;
            this.Text4.CanGrow = false;
            this.Text4.Font = new DevExpress.Drawing.DXFont("Arial", 10F, DevExpress.Drawing.DXFontStyle.Bold);
            this.Text4.ForeColor = System.Drawing.Color.Black;
            this.Text4.LocationFloat = new DevExpress.Utils.PointFloat(374.8854F, 160.4027F);
            this.Text4.Name = "Text4";
            this.Text4.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.Text4.SizeF = new System.Drawing.SizeF(89.58334F, 15.34722F);
            this.Text4.Text = "Card Type";
            this.Text4.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopLeft;
            // 
            // Text3
            // 
            this.Text3.BackColor = System.Drawing.Color.Transparent;
            this.Text3.BorderColor = System.Drawing.Color.Black;
            this.Text3.Borders = DevExpress.XtraPrinting.BorderSide.None;
            this.Text3.BorderWidth = 1F;
            this.Text3.CanGrow = false;
            this.Text3.Font = new DevExpress.Drawing.DXFont("Arial", 10F, DevExpress.Drawing.DXFontStyle.Bold);
            this.Text3.ForeColor = System.Drawing.Color.Black;
            this.Text3.LocationFloat = new DevExpress.Utils.PointFloat(308.2188F, 160.4027F);
            this.Text3.Name = "Text3";
            this.Text3.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.Text3.SizeF = new System.Drawing.SizeF(39.06256F, 15.34721F);
            this.Text3.Text = "Code";
            this.Text3.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopLeft;
            // 
            // Text2
            // 
            this.Text2.BackColor = System.Drawing.Color.Transparent;
            this.Text2.BorderColor = System.Drawing.Color.Black;
            this.Text2.Borders = DevExpress.XtraPrinting.BorderSide.None;
            this.Text2.BorderWidth = 1F;
            this.Text2.CanGrow = false;
            this.Text2.Font = new DevExpress.Drawing.DXFont("Arial", 10F, DevExpress.Drawing.DXFontStyle.Bold);
            this.Text2.ForeColor = System.Drawing.Color.Black;
            this.Text2.LocationFloat = new DevExpress.Utils.PointFloat(251.4479F, 160.4027F);
            this.Text2.Name = "Text2";
            this.Text2.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.Text2.SizeF = new System.Drawing.SizeF(42.70831F, 15.34721F);
            this.Text2.Text = "Type";
            this.Text2.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopLeft;
            // 
            // Title
            // 
            this.Title.BackColor = System.Drawing.Color.Transparent;
            this.Title.BorderColor = System.Drawing.Color.Black;
            this.Title.Borders = DevExpress.XtraPrinting.BorderSide.None;
            this.Title.BorderWidth = 1F;
            this.Title.CanGrow = false;
            this.Title.Font = new DevExpress.Drawing.DXFont("Arial", 14F, ((DevExpress.Drawing.DXFontStyle)((DevExpress.Drawing.DXFontStyle.Bold | DevExpress.Drawing.DXFontStyle.Underline))));
            this.Title.ForeColor = System.Drawing.Color.Black;
            this.Title.LocationFloat = new DevExpress.Utils.PointFloat(0F, 115.3333F);
            this.Title.Name = "Title";
            this.Title.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.Title.SizeF = new System.Drawing.SizeF(1056F, 25.00001F);
            this.Title.StylePriority.UseTextAlignment = false;
            this.Title.Text = "Subtotals by Payment Type and Code";
            this.Title.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopCenter;
            // 
            // Text1
            // 
            this.Text1.BackColor = System.Drawing.Color.Transparent;
            this.Text1.BorderColor = System.Drawing.Color.Black;
            this.Text1.Borders = DevExpress.XtraPrinting.BorderSide.None;
            this.Text1.BorderWidth = 1F;
            this.Text1.CanGrow = false;
            this.Text1.Font = new DevExpress.Drawing.DXFont("Arial", 10F, DevExpress.Drawing.DXFontStyle.Bold);
            this.Text1.ForeColor = System.Drawing.Color.Black;
            this.Text1.LocationFloat = new DevExpress.Utils.PointFloat(549.8854F, 160.4027F);
            this.Text1.Name = "Text1";
            this.Text1.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.Text1.SizeF = new System.Drawing.SizeF(61.45833F, 15.34722F);
            this.Text1.Text = "Count";
            this.Text1.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopRight;
            // 
            // PageHeaderArea1
            // 
            this.PageHeaderArea1.HeightF = 41F;
            this.PageHeaderArea1.Name = "PageHeaderArea1";
            this.PageHeaderArea1.Padding = new DevExpress.XtraPrinting.PaddingInfo(0, 0, 0, 0, 100F);
            this.PageHeaderArea1.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopLeft;
            // 
            // Area4
            // 
            this.Area4.HeightF = 0F;
            this.Area4.Name = "Area4";
            this.Area4.Padding = new DevExpress.XtraPrinting.PaddingInfo(0, 0, 0, 0, 100F);
            this.Area4.SubBands.AddRange(new DevExpress.XtraReports.UI.SubBand[] {
            this.Section4,
            this.ReportFooterSection1});
            this.Area4.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopLeft;
            // 
            // Section4
            // 
            this.Section4.Controls.AddRange(new DevExpress.XtraReports.UI.XRControl[] {
            this.Text7,
            this.TotalFees1,
            this.Line3,
            this.TotalAmount1,
            this.TotalCount1});
            this.Section4.HeightF = 41F;
            this.Section4.KeepTogether = true;
            this.Section4.Name = "Section4";
            this.Section4.Padding = new DevExpress.XtraPrinting.PaddingInfo(0, 0, 0, 0, 100F);
            this.Section4.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopLeft;
            // 
            // Text7
            // 
            this.Text7.BackColor = System.Drawing.Color.Transparent;
            this.Text7.BorderColor = System.Drawing.Color.Black;
            this.Text7.Borders = DevExpress.XtraPrinting.BorderSide.None;
            this.Text7.BorderWidth = 1F;
            this.Text7.CanGrow = false;
            this.Text7.Font = new DevExpress.Drawing.DXFont("Arial", 10F, DevExpress.Drawing.DXFontStyle.Bold);
            this.Text7.ForeColor = System.Drawing.Color.Black;
            this.Text7.LocationFloat = new DevExpress.Utils.PointFloat(251.4479F, 8.333333F);
            this.Text7.Name = "Text7";
            this.Text7.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.Text7.SizeF = new System.Drawing.SizeF(58.33333F, 15.34722F);
            this.Text7.Text = "Total:";
            this.Text7.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopLeft;
            // 
            // TotalFees1
            // 
            this.TotalFees1.BackColor = System.Drawing.Color.Transparent;
            this.TotalFees1.BorderColor = System.Drawing.Color.Black;
            this.TotalFees1.Borders = DevExpress.XtraPrinting.BorderSide.None;
            this.TotalFees1.BorderWidth = 1F;
            this.TotalFees1.CanGrow = false;
            this.TotalFees1.ExpressionBindings.AddRange(new DevExpress.XtraReports.UI.ExpressionBinding[] {
            new DevExpress.XtraReports.UI.ExpressionBinding("BeforePrint", "Text", "sumSum([FeeTot])")});
            this.TotalFees1.Font = new DevExpress.Drawing.DXFont("Arial", 10F, DevExpress.Drawing.DXFontStyle.Bold);
            this.TotalFees1.ForeColor = System.Drawing.Color.Black;
            this.TotalFees1.LocationFloat = new DevExpress.Utils.PointFloat(624.8854F, 8.333333F);
            this.TotalFees1.Name = "TotalFees1";
            this.TotalFees1.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.TotalFees1.SizeF = new System.Drawing.SizeF(83.33334F, 15.34722F);
            xrSummary1.Running = DevExpress.XtraReports.UI.SummaryRunning.Report;
            this.TotalFees1.Summary = xrSummary1;
            this.TotalFees1.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopRight;
            this.TotalFees1.TextFormatString = "{0:C2}";
            // 
            // Line3
            // 
            this.Line3.BackColor = System.Drawing.Color.Transparent;
            this.Line3.BorderColor = System.Drawing.Color.Black;
            this.Line3.Borders = DevExpress.XtraPrinting.BorderSide.Top;
            this.Line3.BorderWidth = 1F;
            this.Line3.Font = new DevExpress.Drawing.DXFont("Times New Roman", 9.75F);
            this.Line3.ForeColor = System.Drawing.Color.Black;
            this.Line3.LineWidth = 2F;
            this.Line3.LocationFloat = new DevExpress.Utils.PointFloat(251.4479F, 1.319444F);
            this.Line3.Name = "Line3";
            this.Line3.Padding = new DevExpress.XtraPrinting.PaddingInfo(0, 0, 0, 0, 100F);
            this.Line3.SizeF = new System.Drawing.SizeF(565.1042F, 2.083333F);
            // 
            // TotalAmount1
            // 
            this.TotalAmount1.BackColor = System.Drawing.Color.Transparent;
            this.TotalAmount1.BorderColor = System.Drawing.Color.Black;
            this.TotalAmount1.Borders = DevExpress.XtraPrinting.BorderSide.None;
            this.TotalAmount1.BorderWidth = 1F;
            this.TotalAmount1.CanGrow = false;
            this.TotalAmount1.ExpressionBindings.AddRange(new DevExpress.XtraReports.UI.ExpressionBinding[] {
            new DevExpress.XtraReports.UI.ExpressionBinding("BeforePrint", "Text", "sumSum([TOTAL])")});
            this.TotalAmount1.Font = new DevExpress.Drawing.DXFont("Arial", 10F, DevExpress.Drawing.DXFontStyle.Bold);
            this.TotalAmount1.ForeColor = System.Drawing.Color.Black;
            this.TotalAmount1.LocationFloat = new DevExpress.Utils.PointFloat(733.2188F, 8.333333F);
            this.TotalAmount1.Name = "TotalAmount1";
            this.TotalAmount1.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.TotalAmount1.SizeF = new System.Drawing.SizeF(83.33334F, 15.34722F);
            xrSummary2.Running = DevExpress.XtraReports.UI.SummaryRunning.Report;
            this.TotalAmount1.Summary = xrSummary2;
            this.TotalAmount1.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopRight;
            this.TotalAmount1.TextFormatString = "{0:C2}";
            // 
            // TotalCount1
            // 
            this.TotalCount1.BackColor = System.Drawing.Color.Transparent;
            this.TotalCount1.BorderColor = System.Drawing.Color.Black;
            this.TotalCount1.Borders = DevExpress.XtraPrinting.BorderSide.None;
            this.TotalCount1.BorderWidth = 1F;
            this.TotalCount1.CanGrow = false;
            this.TotalCount1.ExpressionBindings.AddRange(new DevExpress.XtraReports.UI.ExpressionBinding[] {
            new DevExpress.XtraReports.UI.ExpressionBinding("BeforePrint", "Text", "sumSum([TypeCount])")});
            this.TotalCount1.Font = new DevExpress.Drawing.DXFont("Arial", 10F, DevExpress.Drawing.DXFontStyle.Bold);
            this.TotalCount1.ForeColor = System.Drawing.Color.Black;
            this.TotalCount1.LocationFloat = new DevExpress.Utils.PointFloat(549.8854F, 8.333333F);
            this.TotalCount1.Name = "TotalCount1";
            this.TotalCount1.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.TotalCount1.SizeF = new System.Drawing.SizeF(61.45833F, 15.34722F);
            xrSummary3.Running = DevExpress.XtraReports.UI.SummaryRunning.Report;
            this.TotalCount1.Summary = xrSummary3;
            this.TotalCount1.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopRight;
            // 
            // ReportFooterSection1
            // 
            this.ReportFooterSection1.HeightF = 41F;
            this.ReportFooterSection1.KeepTogether = true;
            this.ReportFooterSection1.Name = "ReportFooterSection1";
            this.ReportFooterSection1.Padding = new DevExpress.XtraPrinting.PaddingInfo(0, 0, 0, 0, 100F);
            this.ReportFooterSection1.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopLeft;
            // 
            // PageFooterArea1
            // 
            this.PageFooterArea1.Controls.AddRange(new DevExpress.XtraReports.UI.XRControl[] {
            this.DataDate1,
            this.DataTime1,
            this.xrLabel1,
            this.gsUserID_1,
            this.gsUserName_1,
            this.PageNofM1});
            this.PageFooterArea1.HeightF = 41F;
            this.PageFooterArea1.Name = "PageFooterArea1";
            this.PageFooterArea1.Padding = new DevExpress.XtraPrinting.PaddingInfo(0, 0, 0, 0, 100F);
            this.PageFooterArea1.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopLeft;
            // 
            // DataDate1
            // 
            this.DataDate1.BackColor = System.Drawing.Color.Transparent;
            this.DataDate1.BorderColor = System.Drawing.Color.Black;
            this.DataDate1.Borders = DevExpress.XtraPrinting.BorderSide.None;
            this.DataDate1.BorderWidth = 1F;
            this.DataDate1.Font = new DevExpress.Drawing.DXFont("Arial", 10F);
            this.DataDate1.ForeColor = System.Drawing.Color.Black;
            this.DataDate1.LocationFloat = new DevExpress.Utils.PointFloat(0F, 0F);
            this.DataDate1.Name = "DataDate1";
            this.DataDate1.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.DataDate1.PageInfo = DevExpress.XtraPrinting.PageInfo.DateTime;
            this.DataDate1.SizeF = new System.Drawing.SizeF(80.20834F, 18.33333F);
            this.DataDate1.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopLeft;
            this.DataDate1.TextFormatString = "{0:MM/dd/yyyy}";
            // 
            // DataTime1
            // 
            this.DataTime1.BackColor = System.Drawing.Color.Transparent;
            this.DataTime1.BorderColor = System.Drawing.Color.Black;
            this.DataTime1.Borders = DevExpress.XtraPrinting.BorderSide.None;
            this.DataTime1.BorderWidth = 1F;
            this.DataTime1.Font = new DevExpress.Drawing.DXFont("Arial", 10F);
            this.DataTime1.ForeColor = System.Drawing.Color.Black;
            this.DataTime1.LocationFloat = new DevExpress.Utils.PointFloat(91.66666F, 0F);
            this.DataTime1.Name = "DataTime1";
            this.DataTime1.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.DataTime1.PageInfo = DevExpress.XtraPrinting.PageInfo.DateTime;
            this.DataTime1.SizeF = new System.Drawing.SizeF(70.83334F, 18.33333F);
            this.DataTime1.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopLeft;
            this.DataTime1.TextFormatString = "{0:t}";
            // 
            // xrLabel1
            // 
            this.xrLabel1.BackColor = System.Drawing.Color.Transparent;
            this.xrLabel1.BorderColor = System.Drawing.Color.Black;
            this.xrLabel1.Borders = DevExpress.XtraPrinting.BorderSide.None;
            this.xrLabel1.BorderWidth = 1F;
            this.xrLabel1.CanGrow = false;
            this.xrLabel1.Font = new DevExpress.Drawing.DXFont("Arial", 10F, DevExpress.Drawing.DXFontStyle.Bold);
            this.xrLabel1.ForeColor = System.Drawing.Color.Black;
            this.xrLabel1.LocationFloat = new DevExpress.Utils.PointFloat(200F, 0F);
            this.xrLabel1.Name = "xrLabel1";
            this.xrLabel1.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabel1.SizeF = new System.Drawing.SizeF(50F, 18.33333F);
            this.xrLabel1.Text = "USER:";
            this.xrLabel1.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopLeft;
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
            this.gsUserID_1.Font = new DevExpress.Drawing.DXFont("Arial", 10F);
            this.gsUserID_1.ForeColor = System.Drawing.Color.Black;
            this.gsUserID_1.LocationFloat = new DevExpress.Utils.PointFloat(250F, 0F);
            this.gsUserID_1.Name = "gsUserID_1";
            this.gsUserID_1.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.gsUserID_1.SizeF = new System.Drawing.SizeF(51.66669F, 18.33333F);
            this.gsUserID_1.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopLeft;
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
            this.gsUserName_1.Font = new DevExpress.Drawing.DXFont("Arial", 10F);
            this.gsUserName_1.ForeColor = System.Drawing.Color.Black;
            this.gsUserName_1.LocationFloat = new DevExpress.Utils.PointFloat(301.6667F, 0F);
            this.gsUserName_1.Name = "gsUserName_1";
            this.gsUserName_1.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.gsUserName_1.SizeF = new System.Drawing.SizeF(158.3333F, 18.33333F);
            this.gsUserName_1.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopLeft;
            // 
            // PageNofM1
            // 
            this.PageNofM1.BackColor = System.Drawing.Color.Transparent;
            this.PageNofM1.BorderColor = System.Drawing.Color.Black;
            this.PageNofM1.Borders = DevExpress.XtraPrinting.BorderSide.None;
            this.PageNofM1.BorderWidth = 1F;
            this.PageNofM1.Font = new DevExpress.Drawing.DXFont("Arial", 10F);
            this.PageNofM1.ForeColor = System.Drawing.Color.Black;
            this.PageNofM1.LocationFloat = new DevExpress.Utils.PointFloat(890.9999F, 0F);
            this.PageNofM1.Name = "PageNofM1";
            this.PageNofM1.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.PageNofM1.SizeF = new System.Drawing.SizeF(158.3333F, 18.33333F);
            this.PageNofM1.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopLeft;
            // 
            // sqlDataSource1
            // 
            this.sqlDataSource1.ConnectionName = "IAC2021SQL.Properties.Settings.IAC2010SQLConnectionString";
            this.sqlDataSource1.Name = "sqlDataSource1";
            storedProcQuery1.Name = "PaymentTypeCodeSummarySelect";
            storedProcQuery1.StoredProcName = "tempPaymentTypeCodeSummarySelect";
            this.sqlDataSource1.Queries.AddRange(new DevExpress.DataAccess.Sql.SqlQuery[] {
            storedProcQuery1});
            this.sqlDataSource1.ResultSchemaSerializable = resources.GetString("sqlDataSource1.ResultSchemaSerializable");
            // 
            // topMarginBand1
            // 
            this.topMarginBand1.HeightF = 22F;
            this.topMarginBand1.Name = "topMarginBand1";
            // 
            // bottomMarginBand1
            // 
            this.bottomMarginBand1.HeightF = 22F;
            this.bottomMarginBand1.Name = "bottomMarginBand1";
            // 
            // gsUserID
            // 
            this.gsUserID.Description = "Enter gsUserID";
            this.gsUserID.Name = "gsUserID";
            // 
            // gsUserName
            // 
            this.gsUserName.Description = "Enter gsUserName";
            this.gsUserName.Name = "gsUserName";
            // 
            // gsFormTitle
            // 
            this.gsFormTitle.Description = "Enter gsFormTitle";
            this.gsFormTitle.Name = "gsFormTitle";
            // 
            // XtraReportClosedPaymentTypeSummary
            // 
            this.Bands.AddRange(new DevExpress.XtraReports.UI.Band[] {
            this.Area3,
            this.Area1,
            this.PageHeaderArea1,
            this.Area4,
            this.PageFooterArea1,
            this.topMarginBand1,
            this.bottomMarginBand1});
            this.ComponentStorage.AddRange(new System.ComponentModel.IComponent[] {
            this.sqlDataSource1});
            this.DataMember = "PaymentTypeCodeSummarySelect";
            this.DataSource = this.sqlDataSource1;
            this.Landscape = true;
            this.Margins = new DevExpress.Drawing.DXMargins(22F, 22F, 22F, 22F);
            this.PageHeight = 850;
            this.PageWidth = 1100;
            this.Parameters.AddRange(new DevExpress.XtraReports.Parameters.Parameter[] {
            this.gsUserID,
            this.gsUserName,
            this.gsFormTitle});
            this.Version = "24.1";
            ((System.ComponentModel.ISupportInitialize)(this)).EndInit();

        }

        #endregion

        private DevExpress.XtraReports.UI.DetailBand Area3;
        private DevExpress.XtraReports.UI.XRLabel PAYMENTTYPE1;
        private DevExpress.XtraReports.UI.XRLabel PAYMENTCODE21;
        private DevExpress.XtraReports.UI.XRLabel CreditCardType1;
        private DevExpress.XtraReports.UI.XRLabel FeeTot1;
        private DevExpress.XtraReports.UI.XRLabel TOTAL1;
        private DevExpress.XtraReports.UI.XRLabel TypeCount1;
        private DevExpress.XtraReports.UI.ReportHeaderBand Area1;
        private DevExpress.XtraReports.UI.SubBand Section1;
        private DevExpress.XtraReports.UI.SubBand ReportHeaderSection1;
        private DevExpress.XtraReports.UI.XRLine Line1;
        private DevExpress.XtraReports.UI.XRLabel Text6;
        private DevExpress.XtraReports.UI.XRLabel Text5;
        private DevExpress.XtraReports.UI.XRLabel Text4;
        private DevExpress.XtraReports.UI.XRLabel Text3;
        private DevExpress.XtraReports.UI.XRLabel Text2;
        private DevExpress.XtraReports.UI.XRLabel Title;
        private DevExpress.XtraReports.UI.XRLabel Text1;
        private DevExpress.XtraReports.UI.PageHeaderBand PageHeaderArea1;
        private DevExpress.XtraReports.UI.ReportFooterBand Area4;
        private DevExpress.XtraReports.UI.SubBand Section4;
        private DevExpress.XtraReports.UI.XRLabel Text7;
        private DevExpress.XtraReports.UI.XRLabel TotalFees1;
        private DevExpress.XtraReports.UI.XRLine Line3;
        private DevExpress.XtraReports.UI.XRLabel TotalAmount1;
        private DevExpress.XtraReports.UI.XRLabel TotalCount1;
        private DevExpress.XtraReports.UI.SubBand ReportFooterSection1;
        private DevExpress.XtraReports.UI.PageFooterBand PageFooterArea1;
        private DevExpress.DataAccess.Sql.SqlDataSource sqlDataSource1;
        private DevExpress.XtraReports.UI.TopMarginBand topMarginBand1;
        private DevExpress.XtraReports.UI.BottomMarginBand bottomMarginBand1;
        private DevExpress.XtraReports.UI.XRPageInfo DataDate1;
        private DevExpress.XtraReports.UI.XRPageInfo DataTime1;
        private DevExpress.XtraReports.UI.XRLabel xrLabel1;
        private DevExpress.XtraReports.UI.XRLabel gsUserID_1;
        private DevExpress.XtraReports.UI.XRLabel gsUserName_1;
        private DevExpress.XtraReports.UI.XRPageInfo PageNofM1;
        private DevExpress.XtraReports.Parameters.Parameter gsUserID;
        private DevExpress.XtraReports.Parameters.Parameter gsUserName;
        private DevExpress.XtraReports.UI.XRPictureBox Picture1;
        private DevExpress.XtraReports.UI.XRLabel gsFormTitle1;
        private DevExpress.XtraReports.Parameters.Parameter gsFormTitle;
    }
}

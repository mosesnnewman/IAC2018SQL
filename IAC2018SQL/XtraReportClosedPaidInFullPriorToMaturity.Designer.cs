namespace IAC2021SQL
{
    partial class XtraReportClosedPaidInFullPriorToMaturity
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(XtraReportClosedPaidInFullPriorToMaturity));
            DevExpress.XtraReports.UI.XRSummary xrSummary1 = new DevExpress.XtraReports.UI.XRSummary();
            DevExpress.DataAccess.Sql.StoredProcQuery storedProcQuery1 = new DevExpress.DataAccess.Sql.StoredProcQuery();
            DevExpress.DataAccess.Sql.QueryParameter queryParameter1 = new DevExpress.DataAccess.Sql.QueryParameter();
            DevExpress.DataAccess.Sql.QueryParameter queryParameter2 = new DevExpress.DataAccess.Sql.QueryParameter();
            DevExpress.DataAccess.Sql.QueryParameter queryParameter3 = new DevExpress.DataAccess.Sql.QueryParameter();
            DevExpress.DataAccess.Sql.QueryParameter queryParameter4 = new DevExpress.DataAccess.Sql.QueryParameter();
            DevExpress.DataAccess.Sql.QueryParameter queryParameter5 = new DevExpress.DataAccess.Sql.QueryParameter();
            DevExpress.DataAccess.Sql.QueryParameter queryParameter6 = new DevExpress.DataAccess.Sql.QueryParameter();
            DevExpress.DataAccess.Sql.QueryParameter queryParameter7 = new DevExpress.DataAccess.Sql.QueryParameter();
            DevExpress.DataAccess.Sql.QueryParameter queryParameter8 = new DevExpress.DataAccess.Sql.QueryParameter();
            this.Area3 = new DevExpress.XtraReports.UI.DetailBand();
            this.CUSTOMERDEALER1 = new DevExpress.XtraReports.UI.XRLabel();
            this.Name1 = new DevExpress.XtraReports.UI.XRLabel();
            this.DEALERST1 = new DevExpress.XtraReports.UI.XRLabel();
            this.CUSTOMERNO2 = new DevExpress.XtraReports.UI.XRLabel();
            this.DateClosed2 = new DevExpress.XtraReports.UI.XRLabel();
            this.MaturityDate1 = new DevExpress.XtraReports.UI.XRLabel();
            this.PayCode1 = new DevExpress.XtraReports.UI.XRLabel();
            this.GapIns1 = new DevExpress.XtraReports.UI.XRLabel();
            this.WarrantyText_1 = new DevExpress.XtraReports.UI.XRLabel();
            this.Area1 = new DevExpress.XtraReports.UI.ReportHeaderBand();
            this.Picture1 = new DevExpress.XtraReports.UI.XRPictureBox();
            this.Text20 = new DevExpress.XtraReports.UI.XRLabel();
            this.Text21 = new DevExpress.XtraReports.UI.XRLabel();
            this.gdFromDate1 = new DevExpress.XtraReports.UI.XRLabel();
            this.Text22 = new DevExpress.XtraReports.UI.XRLabel();
            this.gdToDate1 = new DevExpress.XtraReports.UI.XRLabel();
            this.Area2 = new DevExpress.XtraReports.UI.PageHeaderBand();
            this.Text11 = new DevExpress.XtraReports.UI.XRLabel();
            this.Text13 = new DevExpress.XtraReports.UI.XRLabel();
            this.Text16 = new DevExpress.XtraReports.UI.XRLabel();
            this.Text19 = new DevExpress.XtraReports.UI.XRLabel();
            this.Line1 = new DevExpress.XtraReports.UI.XRLine();
            this.Text4 = new DevExpress.XtraReports.UI.XRLabel();
            this.Text7 = new DevExpress.XtraReports.UI.XRLabel();
            this.Text12 = new DevExpress.XtraReports.UI.XRLabel();
            this.Text14 = new DevExpress.XtraReports.UI.XRLabel();
            this.Text17 = new DevExpress.XtraReports.UI.XRLabel();
            this.Area4 = new DevExpress.XtraReports.UI.ReportFooterBand();
            this.Text1 = new DevExpress.XtraReports.UI.XRLabel();
            this.TotalCustomerCount1 = new DevExpress.XtraReports.UI.XRLabel();
            this.Area5 = new DevExpress.XtraReports.UI.PageFooterBand();
            this.PageNofM1 = new DevExpress.XtraReports.UI.XRPageInfo();
            this.gsUserName_1 = new DevExpress.XtraReports.UI.XRLabel();
            this.gsUserID_1 = new DevExpress.XtraReports.UI.XRLabel();
            this.Text5 = new DevExpress.XtraReports.UI.XRLabel();
            this.DataTime1 = new DevExpress.XtraReports.UI.XRPageInfo();
            this.WarrantyText = new DevExpress.XtraReports.UI.CalculatedField();
            this.gdFromDate = new DevExpress.XtraReports.Parameters.Parameter();
            this.gdToDate = new DevExpress.XtraReports.Parameters.Parameter();
            this.gsUserName = new DevExpress.XtraReports.Parameters.Parameter();
            this.gsUserID = new DevExpress.XtraReports.Parameters.Parameter();
            this.sqlDataSource1 = new DevExpress.DataAccess.Sql.SqlDataSource(this.components);
            this.topMarginBand1 = new DevExpress.XtraReports.UI.TopMarginBand();
            this.bottomMarginBand1 = new DevExpress.XtraReports.UI.BottomMarginBand();
            this.gsState = new DevExpress.XtraReports.Parameters.Parameter();
            this.gsDealerNo = new DevExpress.XtraReports.Parameters.Parameter();
            this.gsPaymentType = new DevExpress.XtraReports.Parameters.Parameter();
            this.gsPaymentCode = new DevExpress.XtraReports.Parameters.Parameter();
            this.gbGap = new DevExpress.XtraReports.Parameters.Parameter();
            this.gbWarranty = new DevExpress.XtraReports.Parameters.Parameter();
            ((System.ComponentModel.ISupportInitialize)(this)).BeginInit();
            // 
            // Area3
            // 
            this.Area3.Controls.AddRange(new DevExpress.XtraReports.UI.XRControl[] {
            this.CUSTOMERDEALER1,
            this.Name1,
            this.DEALERST1,
            this.CUSTOMERNO2,
            this.DateClosed2,
            this.MaturityDate1,
            this.PayCode1,
            this.GapIns1,
            this.WarrantyText_1});
            this.Area3.HeightF = 22F;
            this.Area3.KeepTogether = true;
            this.Area3.Name = "Area3";
            this.Area3.Padding = new DevExpress.XtraPrinting.PaddingInfo(0, 0, 0, 0, 100F);
            this.Area3.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopLeft;
            // 
            // CUSTOMERDEALER1
            // 
            this.CUSTOMERDEALER1.BackColor = System.Drawing.Color.Transparent;
            this.CUSTOMERDEALER1.BorderColor = System.Drawing.Color.Black;
            this.CUSTOMERDEALER1.Borders = DevExpress.XtraPrinting.BorderSide.None;
            this.CUSTOMERDEALER1.BorderWidth = 1F;
            this.CUSTOMERDEALER1.CanGrow = false;
            this.CUSTOMERDEALER1.ExpressionBindings.AddRange(new DevExpress.XtraReports.UI.ExpressionBinding[] {
            new DevExpress.XtraReports.UI.ExpressionBinding("BeforePrint", "Text", "[CUSTOMER_DEALER]")});
            this.CUSTOMERDEALER1.Font = new DevExpress.Drawing.DXFont("Arial", 8F);
            this.CUSTOMERDEALER1.ForeColor = System.Drawing.Color.Black;
            this.CUSTOMERDEALER1.LocationFloat = new DevExpress.Utils.PointFloat(0F, 0F);
            this.CUSTOMERDEALER1.Name = "CUSTOMERDEALER1";
            this.CUSTOMERDEALER1.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.CUSTOMERDEALER1.SizeF = new System.Drawing.SizeF(28.125F, 16.66667F);
            this.CUSTOMERDEALER1.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopLeft;
            // 
            // Name1
            // 
            this.Name1.BackColor = System.Drawing.Color.Transparent;
            this.Name1.BorderColor = System.Drawing.Color.Black;
            this.Name1.Borders = DevExpress.XtraPrinting.BorderSide.None;
            this.Name1.BorderWidth = 1F;
            this.Name1.CanGrow = false;
            this.Name1.ExpressionBindings.AddRange(new DevExpress.XtraReports.UI.ExpressionBinding[] {
            new DevExpress.XtraReports.UI.ExpressionBinding("BeforePrint", "Text", "[Name]")});
            this.Name1.Font = new DevExpress.Drawing.DXFont("Arial", 8F);
            this.Name1.ForeColor = System.Drawing.Color.Black;
            this.Name1.LocationFloat = new DevExpress.Utils.PointFloat(200F, 0F);
            this.Name1.Name = "Name1";
            this.Name1.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.Name1.SizeF = new System.Drawing.SizeF(283.3334F, 15.34722F);
            this.Name1.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopLeft;
            // 
            // DEALERST1
            // 
            this.DEALERST1.BackColor = System.Drawing.Color.Transparent;
            this.DEALERST1.BorderColor = System.Drawing.Color.Black;
            this.DEALERST1.Borders = DevExpress.XtraPrinting.BorderSide.None;
            this.DEALERST1.BorderWidth = 1F;
            this.DEALERST1.CanGrow = false;
            this.DEALERST1.ExpressionBindings.AddRange(new DevExpress.XtraReports.UI.ExpressionBinding[] {
            new DevExpress.XtraReports.UI.ExpressionBinding("BeforePrint", "Text", "[DEALER_ST]")});
            this.DEALERST1.Font = new DevExpress.Drawing.DXFont("Arial", 8F);
            this.DEALERST1.ForeColor = System.Drawing.Color.Black;
            this.DEALERST1.LocationFloat = new DevExpress.Utils.PointFloat(75F, 0F);
            this.DEALERST1.Name = "DEALERST1";
            this.DEALERST1.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.DEALERST1.SizeF = new System.Drawing.SizeF(43.75F, 16.66667F);
            this.DEALERST1.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopLeft;
            // 
            // CUSTOMERNO2
            // 
            this.CUSTOMERNO2.BackColor = System.Drawing.Color.Transparent;
            this.CUSTOMERNO2.BorderColor = System.Drawing.Color.Black;
            this.CUSTOMERNO2.Borders = DevExpress.XtraPrinting.BorderSide.None;
            this.CUSTOMERNO2.BorderWidth = 1F;
            this.CUSTOMERNO2.CanGrow = false;
            this.CUSTOMERNO2.ExpressionBindings.AddRange(new DevExpress.XtraReports.UI.ExpressionBinding[] {
            new DevExpress.XtraReports.UI.ExpressionBinding("BeforePrint", "Text", "[CUSTOMER_NO]")});
            this.CUSTOMERNO2.Font = new DevExpress.Drawing.DXFont("Arial", 8F);
            this.CUSTOMERNO2.ForeColor = System.Drawing.Color.Black;
            this.CUSTOMERNO2.LocationFloat = new DevExpress.Utils.PointFloat(133.3333F, 0F);
            this.CUSTOMERNO2.Name = "CUSTOMERNO2";
            this.CUSTOMERNO2.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.CUSTOMERNO2.SizeF = new System.Drawing.SizeF(58.33333F, 15.34722F);
            this.CUSTOMERNO2.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopLeft;
            // 
            // DateClosed2
            // 
            this.DateClosed2.BackColor = System.Drawing.Color.Transparent;
            this.DateClosed2.BorderColor = System.Drawing.Color.Black;
            this.DateClosed2.Borders = DevExpress.XtraPrinting.BorderSide.None;
            this.DateClosed2.BorderWidth = 1F;
            this.DateClosed2.CanGrow = false;
            this.DateClosed2.ExpressionBindings.AddRange(new DevExpress.XtraReports.UI.ExpressionBinding[] {
            new DevExpress.XtraReports.UI.ExpressionBinding("BeforePrint", "Text", "[DateClosed]")});
            this.DateClosed2.Font = new DevExpress.Drawing.DXFont("Arial", 8F);
            this.DateClosed2.ForeColor = System.Drawing.Color.Black;
            this.DateClosed2.LocationFloat = new DevExpress.Utils.PointFloat(483.3333F, 0F);
            this.DateClosed2.Name = "DateClosed2";
            this.DateClosed2.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.DateClosed2.SizeF = new System.Drawing.SizeF(92.70834F, 14.58333F);
            this.DateClosed2.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopLeft;
            this.DateClosed2.TextFormatString = "{0:MM/dd/yyyy}";
            // 
            // MaturityDate1
            // 
            this.MaturityDate1.BackColor = System.Drawing.Color.Transparent;
            this.MaturityDate1.BorderColor = System.Drawing.Color.Black;
            this.MaturityDate1.Borders = DevExpress.XtraPrinting.BorderSide.None;
            this.MaturityDate1.BorderWidth = 1F;
            this.MaturityDate1.CanGrow = false;
            this.MaturityDate1.ExpressionBindings.AddRange(new DevExpress.XtraReports.UI.ExpressionBinding[] {
            new DevExpress.XtraReports.UI.ExpressionBinding("BeforePrint", "Text", "[MaturityDate]")});
            this.MaturityDate1.Font = new DevExpress.Drawing.DXFont("Arial", 8F);
            this.MaturityDate1.ForeColor = System.Drawing.Color.Black;
            this.MaturityDate1.LocationFloat = new DevExpress.Utils.PointFloat(590.625F, 0F);
            this.MaturityDate1.Name = "MaturityDate1";
            this.MaturityDate1.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.MaturityDate1.SizeF = new System.Drawing.SizeF(92.70834F, 14.58333F);
            this.MaturityDate1.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopLeft;
            this.MaturityDate1.TextFormatString = "{0:MM/dd/yyyy}";
            // 
            // PayCode1
            // 
            this.PayCode1.BackColor = System.Drawing.Color.Transparent;
            this.PayCode1.BorderColor = System.Drawing.Color.Black;
            this.PayCode1.Borders = DevExpress.XtraPrinting.BorderSide.None;
            this.PayCode1.BorderWidth = 1F;
            this.PayCode1.CanGrow = false;
            this.PayCode1.ExpressionBindings.AddRange(new DevExpress.XtraReports.UI.ExpressionBinding[] {
            new DevExpress.XtraReports.UI.ExpressionBinding("BeforePrint", "Text", "[PayCode]")});
            this.PayCode1.Font = new DevExpress.Drawing.DXFont("Arial", 8F);
            this.PayCode1.ForeColor = System.Drawing.Color.Black;
            this.PayCode1.LocationFloat = new DevExpress.Utils.PointFloat(716.6666F, 0F);
            this.PayCode1.Name = "PayCode1";
            this.PayCode1.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.PayCode1.SizeF = new System.Drawing.SizeF(29.16663F, 14.58333F);
            this.PayCode1.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopCenter;
            // 
            // GapIns1
            // 
            this.GapIns1.BackColor = System.Drawing.Color.Transparent;
            this.GapIns1.BorderColor = System.Drawing.Color.Black;
            this.GapIns1.Borders = DevExpress.XtraPrinting.BorderSide.None;
            this.GapIns1.BorderWidth = 1F;
            this.GapIns1.CanGrow = false;
            this.GapIns1.ExpressionBindings.AddRange(new DevExpress.XtraReports.UI.ExpressionBinding[] {
            new DevExpress.XtraReports.UI.ExpressionBinding("BeforePrint", "Text", "[GapIns]")});
            this.GapIns1.Font = new DevExpress.Drawing.DXFont("Arial", 8F);
            this.GapIns1.ForeColor = System.Drawing.Color.Black;
            this.GapIns1.LocationFloat = new DevExpress.Utils.PointFloat(791.6666F, 0F);
            this.GapIns1.Name = "GapIns1";
            this.GapIns1.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.GapIns1.SizeF = new System.Drawing.SizeF(72.91666F, 14.58333F);
            this.GapIns1.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopLeft;
            // 
            // WarrantyText_1
            // 
            this.WarrantyText_1.BackColor = System.Drawing.Color.Transparent;
            this.WarrantyText_1.BorderColor = System.Drawing.Color.Black;
            this.WarrantyText_1.Borders = DevExpress.XtraPrinting.BorderSide.None;
            this.WarrantyText_1.BorderWidth = 1F;
            this.WarrantyText_1.CanGrow = false;
            this.WarrantyText_1.ExpressionBindings.AddRange(new DevExpress.XtraReports.UI.ExpressionBinding[] {
            new DevExpress.XtraReports.UI.ExpressionBinding("BeforePrint", "Text", "[WarrantyText]")});
            this.WarrantyText_1.Font = new DevExpress.Drawing.DXFont("Arial", 8F);
            this.WarrantyText_1.ForeColor = System.Drawing.Color.Black;
            this.WarrantyText_1.LocationFloat = new DevExpress.Utils.PointFloat(883.3333F, 0F);
            this.WarrantyText_1.Name = "WarrantyText_1";
            this.WarrantyText_1.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.WarrantyText_1.SizeF = new System.Drawing.SizeF(58.33333F, 16.66667F);
            this.WarrantyText_1.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopCenter;
            // 
            // Area1
            // 
            this.Area1.Controls.AddRange(new DevExpress.XtraReports.UI.XRControl[] {
            this.Picture1,
            this.Text20,
            this.Text21,
            this.gdFromDate1,
            this.Text22,
            this.gdToDate1});
            this.Area1.HeightF = 167F;
            this.Area1.KeepTogether = true;
            this.Area1.Name = "Area1";
            this.Area1.Padding = new DevExpress.XtraPrinting.PaddingInfo(0, 0, 0, 0, 100F);
            this.Area1.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopLeft;
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
            this.Picture1.LocationFloat = new DevExpress.Utils.PointFloat(803.6113F, 0F);
            this.Picture1.Name = "Picture1";
            this.Picture1.Padding = new DevExpress.XtraPrinting.PaddingInfo(0, 0, 0, 0, 100F);
            this.Picture1.SizeF = new System.Drawing.SizeF(246.3888F, 95F);
            // 
            // Text20
            // 
            this.Text20.BackColor = System.Drawing.Color.Transparent;
            this.Text20.BorderColor = System.Drawing.Color.Black;
            this.Text20.Borders = DevExpress.XtraPrinting.BorderSide.None;
            this.Text20.BorderWidth = 1F;
            this.Text20.CanGrow = false;
            this.Text20.Font = new DevExpress.Drawing.DXFont("Arial", 14F);
            this.Text20.ForeColor = System.Drawing.Color.Black;
            this.Text20.LocationFloat = new DevExpress.Utils.PointFloat(4.166687F, 96F);
            this.Text20.Name = "Text20";
            this.Text20.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.Text20.SizeF = new System.Drawing.SizeF(1041.667F, 25F);
            this.Text20.Text = "CLOSED CUSTOMER PAID IN FULL PRIOR TO MATURITY REPORT";
            this.Text20.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopCenter;
            // 
            // Text21
            // 
            this.Text21.BackColor = System.Drawing.Color.Transparent;
            this.Text21.BorderColor = System.Drawing.Color.Black;
            this.Text21.Borders = DevExpress.XtraPrinting.BorderSide.None;
            this.Text21.BorderWidth = 1F;
            this.Text21.CanGrow = false;
            this.Text21.Font = new DevExpress.Drawing.DXFont("Arial", 10F, DevExpress.Drawing.DXFontStyle.Bold);
            this.Text21.ForeColor = System.Drawing.Color.Black;
            this.Text21.LocationFloat = new DevExpress.Utils.PointFloat(370.8333F, 129.3333F);
            this.Text21.Name = "Text21";
            this.Text21.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.Text21.SizeF = new System.Drawing.SizeF(108.3333F, 16.66666F);
            this.Text21.Text = "DATE RANGE:";
            this.Text21.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopLeft;
            // 
            // gdFromDate1
            // 
            this.gdFromDate1.BackColor = System.Drawing.Color.Transparent;
            this.gdFromDate1.BorderColor = System.Drawing.Color.Black;
            this.gdFromDate1.Borders = DevExpress.XtraPrinting.BorderSide.None;
            this.gdFromDate1.BorderWidth = 1F;
            this.gdFromDate1.CanGrow = false;
            this.gdFromDate1.ExpressionBindings.AddRange(new DevExpress.XtraReports.UI.ExpressionBinding[] {
            new DevExpress.XtraReports.UI.ExpressionBinding("BeforePrint", "Text", "?gdFromDate")});
            this.gdFromDate1.Font = new DevExpress.Drawing.DXFont("Arial", 10F);
            this.gdFromDate1.ForeColor = System.Drawing.Color.Black;
            this.gdFromDate1.LocationFloat = new DevExpress.Utils.PointFloat(479.1667F, 129.3333F);
            this.gdFromDate1.Name = "gdFromDate1";
            this.gdFromDate1.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.gdFromDate1.SizeF = new System.Drawing.SizeF(83.33334F, 16.66667F);
            this.gdFromDate1.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopLeft;
            this.gdFromDate1.TextFormatString = "{0:MM/dd/yyyy}";
            // 
            // Text22
            // 
            this.Text22.BackColor = System.Drawing.Color.Transparent;
            this.Text22.BorderColor = System.Drawing.Color.Black;
            this.Text22.Borders = DevExpress.XtraPrinting.BorderSide.None;
            this.Text22.BorderWidth = 1F;
            this.Text22.CanGrow = false;
            this.Text22.Font = new DevExpress.Drawing.DXFont("Arial", 10F, DevExpress.Drawing.DXFontStyle.Bold);
            this.Text22.ForeColor = System.Drawing.Color.Black;
            this.Text22.LocationFloat = new DevExpress.Utils.PointFloat(570.8334F, 129.3333F);
            this.Text22.Name = "Text22";
            this.Text22.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.Text22.SizeF = new System.Drawing.SizeF(16.66667F, 16.66667F);
            this.Text22.Text = "-";
            this.Text22.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopCenter;
            // 
            // gdToDate1
            // 
            this.gdToDate1.BackColor = System.Drawing.Color.Transparent;
            this.gdToDate1.BorderColor = System.Drawing.Color.Black;
            this.gdToDate1.Borders = DevExpress.XtraPrinting.BorderSide.None;
            this.gdToDate1.BorderWidth = 1F;
            this.gdToDate1.CanGrow = false;
            this.gdToDate1.ExpressionBindings.AddRange(new DevExpress.XtraReports.UI.ExpressionBinding[] {
            new DevExpress.XtraReports.UI.ExpressionBinding("BeforePrint", "Text", "?gdToDate")});
            this.gdToDate1.Font = new DevExpress.Drawing.DXFont("Arial", 10F);
            this.gdToDate1.ForeColor = System.Drawing.Color.Black;
            this.gdToDate1.LocationFloat = new DevExpress.Utils.PointFloat(595.8334F, 129.3333F);
            this.gdToDate1.Name = "gdToDate1";
            this.gdToDate1.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.gdToDate1.SizeF = new System.Drawing.SizeF(83.33334F, 16.66667F);
            this.gdToDate1.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopLeft;
            this.gdToDate1.TextFormatString = "{0:MM/dd/yyyy}";
            // 
            // Area2
            // 
            this.Area2.Controls.AddRange(new DevExpress.XtraReports.UI.XRControl[] {
            this.Text11,
            this.Text13,
            this.Text16,
            this.Text19,
            this.Line1,
            this.Text4,
            this.Text7,
            this.Text12,
            this.Text14,
            this.Text17});
            this.Area2.HeightF = 59F;
            this.Area2.Name = "Area2";
            this.Area2.Padding = new DevExpress.XtraPrinting.PaddingInfo(0, 0, 0, 0, 100F);
            this.Area2.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopLeft;
            // 
            // Text11
            // 
            this.Text11.BackColor = System.Drawing.Color.Transparent;
            this.Text11.BorderColor = System.Drawing.Color.Black;
            this.Text11.Borders = DevExpress.XtraPrinting.BorderSide.None;
            this.Text11.BorderWidth = 1F;
            this.Text11.CanGrow = false;
            this.Text11.Font = new DevExpress.Drawing.DXFont("Arial", 8F, DevExpress.Drawing.DXFontStyle.Bold);
            this.Text11.ForeColor = System.Drawing.Color.Black;
            this.Text11.LocationFloat = new DevExpress.Utils.PointFloat(0F, 16.66667F);
            this.Text11.Name = "Text11";
            this.Text11.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.Text11.SizeF = new System.Drawing.SizeF(58.33333F, 16.66667F);
            this.Text11.StylePriority.UseTextAlignment = false;
            this.Text11.Text = "Dealer#";
            this.Text11.TextAlignment = DevExpress.XtraPrinting.TextAlignment.BottomLeft;
            // 
            // Text13
            // 
            this.Text13.BackColor = System.Drawing.Color.Transparent;
            this.Text13.BorderColor = System.Drawing.Color.Black;
            this.Text13.Borders = DevExpress.XtraPrinting.BorderSide.None;
            this.Text13.BorderWidth = 1F;
            this.Text13.CanGrow = false;
            this.Text13.Font = new DevExpress.Drawing.DXFont("Arial", 8F, DevExpress.Drawing.DXFontStyle.Bold);
            this.Text13.ForeColor = System.Drawing.Color.Black;
            this.Text13.LocationFloat = new DevExpress.Utils.PointFloat(200F, 16.66667F);
            this.Text13.Name = "Text13";
            this.Text13.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.Text13.SizeF = new System.Drawing.SizeF(100F, 16.66667F);
            this.Text13.StylePriority.UseTextAlignment = false;
            this.Text13.Text = "Customer Name";
            this.Text13.TextAlignment = DevExpress.XtraPrinting.TextAlignment.BottomLeft;
            // 
            // Text16
            // 
            this.Text16.BackColor = System.Drawing.Color.Transparent;
            this.Text16.BorderColor = System.Drawing.Color.Black;
            this.Text16.Borders = DevExpress.XtraPrinting.BorderSide.None;
            this.Text16.BorderWidth = 1F;
            this.Text16.CanGrow = false;
            this.Text16.Font = new DevExpress.Drawing.DXFont("Arial", 8F, DevExpress.Drawing.DXFontStyle.Bold);
            this.Text16.ForeColor = System.Drawing.Color.Black;
            this.Text16.LocationFloat = new DevExpress.Utils.PointFloat(483.3333F, 16.66667F);
            this.Text16.Name = "Text16";
            this.Text16.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.Text16.SizeF = new System.Drawing.SizeF(75F, 16.66667F);
            this.Text16.StylePriority.UseTextAlignment = false;
            this.Text16.Text = "Date Closed";
            this.Text16.TextAlignment = DevExpress.XtraPrinting.TextAlignment.BottomLeft;
            // 
            // Text19
            // 
            this.Text19.BackColor = System.Drawing.Color.Transparent;
            this.Text19.BorderColor = System.Drawing.Color.Black;
            this.Text19.Borders = DevExpress.XtraPrinting.BorderSide.None;
            this.Text19.BorderWidth = 1F;
            this.Text19.CanGrow = false;
            this.Text19.Font = new DevExpress.Drawing.DXFont("Arial", 8F, DevExpress.Drawing.DXFontStyle.Bold);
            this.Text19.ForeColor = System.Drawing.Color.Black;
            this.Text19.LocationFloat = new DevExpress.Utils.PointFloat(75F, 0F);
            this.Text19.Multiline = true;
            this.Text19.Name = "Text19";
            this.Text19.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.Text19.SizeF = new System.Drawing.SizeF(43.75F, 33.33333F);
            this.Text19.StylePriority.UseTextAlignment = false;
            this.Text19.Text = "Dealer\nState";
            this.Text19.TextAlignment = DevExpress.XtraPrinting.TextAlignment.BottomLeft;
            // 
            // Line1
            // 
            this.Line1.BackColor = System.Drawing.Color.Transparent;
            this.Line1.BorderColor = System.Drawing.Color.Black;
            this.Line1.Borders = DevExpress.XtraPrinting.BorderSide.Top;
            this.Line1.BorderWidth = 1F;
            this.Line1.Font = new DevExpress.Drawing.DXFont("Times New Roman", 9.75F);
            this.Line1.ForeColor = System.Drawing.Color.Black;
            this.Line1.LineWidth = 3F;
            this.Line1.LocationFloat = new DevExpress.Utils.PointFloat(1.041667F, 41.66667F);
            this.Line1.Name = "Line1";
            this.Line1.Padding = new DevExpress.XtraPrinting.PaddingInfo(0, 0, 0, 0, 100F);
            this.Line1.SizeF = new System.Drawing.SizeF(1040.625F, 3.125F);
            // 
            // Text4
            // 
            this.Text4.BackColor = System.Drawing.Color.Transparent;
            this.Text4.BorderColor = System.Drawing.Color.Black;
            this.Text4.Borders = DevExpress.XtraPrinting.BorderSide.None;
            this.Text4.BorderWidth = 1F;
            this.Text4.CanGrow = false;
            this.Text4.Font = new DevExpress.Drawing.DXFont("Arial", 8F, DevExpress.Drawing.DXFontStyle.Bold);
            this.Text4.ForeColor = System.Drawing.Color.Black;
            this.Text4.LocationFloat = new DevExpress.Utils.PointFloat(133.3333F, 16.66667F);
            this.Text4.Name = "Text4";
            this.Text4.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.Text4.SizeF = new System.Drawing.SizeF(58.33333F, 16.66667F);
            this.Text4.StylePriority.UseTextAlignment = false;
            this.Text4.Text = "Account#";
            this.Text4.TextAlignment = DevExpress.XtraPrinting.TextAlignment.BottomLeft;
            // 
            // Text7
            // 
            this.Text7.BackColor = System.Drawing.Color.Transparent;
            this.Text7.BorderColor = System.Drawing.Color.Black;
            this.Text7.Borders = DevExpress.XtraPrinting.BorderSide.None;
            this.Text7.BorderWidth = 1F;
            this.Text7.CanGrow = false;
            this.Text7.Font = new DevExpress.Drawing.DXFont("Arial", 8F, DevExpress.Drawing.DXFontStyle.Bold);
            this.Text7.ForeColor = System.Drawing.Color.Black;
            this.Text7.LocationFloat = new DevExpress.Utils.PointFloat(591.6666F, 16.66667F);
            this.Text7.Name = "Text7";
            this.Text7.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.Text7.SizeF = new System.Drawing.SizeF(75F, 16.66667F);
            this.Text7.StylePriority.UseTextAlignment = false;
            this.Text7.Text = "Maturity Date";
            this.Text7.TextAlignment = DevExpress.XtraPrinting.TextAlignment.BottomLeft;
            // 
            // Text12
            // 
            this.Text12.BackColor = System.Drawing.Color.Transparent;
            this.Text12.BorderColor = System.Drawing.Color.Black;
            this.Text12.Borders = DevExpress.XtraPrinting.BorderSide.None;
            this.Text12.BorderWidth = 1F;
            this.Text12.CanGrow = false;
            this.Text12.Font = new DevExpress.Drawing.DXFont("Arial", 8F, DevExpress.Drawing.DXFontStyle.Bold);
            this.Text12.ForeColor = System.Drawing.Color.Black;
            this.Text12.LocationFloat = new DevExpress.Utils.PointFloat(700F, 16.66667F);
            this.Text12.Name = "Text12";
            this.Text12.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.Text12.SizeF = new System.Drawing.SizeF(58.33333F, 16.66667F);
            this.Text12.StylePriority.UseTextAlignment = false;
            this.Text12.Text = "Type / CD";
            this.Text12.TextAlignment = DevExpress.XtraPrinting.TextAlignment.BottomLeft;
            // 
            // Text14
            // 
            this.Text14.BackColor = System.Drawing.Color.Transparent;
            this.Text14.BorderColor = System.Drawing.Color.Black;
            this.Text14.Borders = DevExpress.XtraPrinting.BorderSide.None;
            this.Text14.BorderWidth = 1F;
            this.Text14.CanGrow = false;
            this.Text14.Font = new DevExpress.Drawing.DXFont("Arial", 8F, DevExpress.Drawing.DXFontStyle.Bold);
            this.Text14.ForeColor = System.Drawing.Color.Black;
            this.Text14.LocationFloat = new DevExpress.Utils.PointFloat(791.6666F, 16.66667F);
            this.Text14.Name = "Text14";
            this.Text14.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.Text14.SizeF = new System.Drawing.SizeF(31.25F, 16.66667F);
            this.Text14.StylePriority.UseTextAlignment = false;
            this.Text14.Text = "Gap";
            this.Text14.TextAlignment = DevExpress.XtraPrinting.TextAlignment.BottomLeft;
            // 
            // Text17
            // 
            this.Text17.BackColor = System.Drawing.Color.Transparent;
            this.Text17.BorderColor = System.Drawing.Color.Black;
            this.Text17.Borders = DevExpress.XtraPrinting.BorderSide.None;
            this.Text17.BorderWidth = 1F;
            this.Text17.CanGrow = false;
            this.Text17.Font = new DevExpress.Drawing.DXFont("Arial", 8F, DevExpress.Drawing.DXFontStyle.Bold);
            this.Text17.ForeColor = System.Drawing.Color.Black;
            this.Text17.LocationFloat = new DevExpress.Utils.PointFloat(883.3333F, 16.66667F);
            this.Text17.Name = "Text17";
            this.Text17.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.Text17.SizeF = new System.Drawing.SizeF(58.33333F, 16.66667F);
            this.Text17.StylePriority.UseTextAlignment = false;
            this.Text17.Text = "Warranty";
            this.Text17.TextAlignment = DevExpress.XtraPrinting.TextAlignment.BottomLeft;
            // 
            // Area4
            // 
            this.Area4.Controls.AddRange(new DevExpress.XtraReports.UI.XRControl[] {
            this.Text1,
            this.TotalCustomerCount1});
            this.Area4.HeightF = 23F;
            this.Area4.KeepTogether = true;
            this.Area4.Name = "Area4";
            this.Area4.Padding = new DevExpress.XtraPrinting.PaddingInfo(0, 0, 0, 0, 100F);
            this.Area4.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopLeft;
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
            this.Text1.LocationFloat = new DevExpress.Utils.PointFloat(108.3333F, 0F);
            this.Text1.Name = "Text1";
            this.Text1.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.Text1.SizeF = new System.Drawing.SizeF(152.0833F, 16.66667F);
            this.Text1.Text = "Total Customer Count:";
            this.Text1.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopLeft;
            // 
            // TotalCustomerCount1
            // 
            this.TotalCustomerCount1.BackColor = System.Drawing.Color.Transparent;
            this.TotalCustomerCount1.BorderColor = System.Drawing.Color.Black;
            this.TotalCustomerCount1.Borders = DevExpress.XtraPrinting.BorderSide.None;
            this.TotalCustomerCount1.BorderWidth = 1F;
            this.TotalCustomerCount1.CanGrow = false;
            this.TotalCustomerCount1.ExpressionBindings.AddRange(new DevExpress.XtraReports.UI.ExpressionBinding[] {
            new DevExpress.XtraReports.UI.ExpressionBinding("BeforePrint", "Text", "sumCount([CUSTOMER_NO])")});
            this.TotalCustomerCount1.Font = new DevExpress.Drawing.DXFont("Arial", 10F);
            this.TotalCustomerCount1.ForeColor = System.Drawing.Color.Black;
            this.TotalCustomerCount1.LocationFloat = new DevExpress.Utils.PointFloat(266.6667F, 0F);
            this.TotalCustomerCount1.Name = "TotalCustomerCount1";
            this.TotalCustomerCount1.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.TotalCustomerCount1.SizeF = new System.Drawing.SizeF(63.54167F, 16.66667F);
            xrSummary1.Running = DevExpress.XtraReports.UI.SummaryRunning.Report;
            this.TotalCustomerCount1.Summary = xrSummary1;
            this.TotalCustomerCount1.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopRight;
            this.TotalCustomerCount1.TextFormatString = "{0:N0}";
            // 
            // Area5
            // 
            this.Area5.Controls.AddRange(new DevExpress.XtraReports.UI.XRControl[] {
            this.PageNofM1,
            this.gsUserName_1,
            this.gsUserID_1,
            this.Text5,
            this.DataTime1});
            this.Area5.HeightF = 41F;
            this.Area5.Name = "Area5";
            this.Area5.Padding = new DevExpress.XtraPrinting.PaddingInfo(0, 0, 0, 0, 100F);
            this.Area5.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopLeft;
            // 
            // PageNofM1
            // 
            this.PageNofM1.BackColor = System.Drawing.Color.Transparent;
            this.PageNofM1.BorderColor = System.Drawing.Color.Black;
            this.PageNofM1.Borders = DevExpress.XtraPrinting.BorderSide.None;
            this.PageNofM1.BorderWidth = 1F;
            this.PageNofM1.Font = new DevExpress.Drawing.DXFont("Arial", 10F);
            this.PageNofM1.ForeColor = System.Drawing.Color.Black;
            this.PageNofM1.LocationFloat = new DevExpress.Utils.PointFloat(783.3333F, 0F);
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
            this.gsUserName_1.Font = new DevExpress.Drawing.DXFont("Arial", 10F);
            this.gsUserName_1.ForeColor = System.Drawing.Color.Black;
            this.gsUserName_1.LocationFloat = new DevExpress.Utils.PointFloat(200F, 0F);
            this.gsUserName_1.Name = "gsUserName_1";
            this.gsUserName_1.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.gsUserName_1.SizeF = new System.Drawing.SizeF(262.5F, 18.33333F);
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
            this.gsUserID_1.Font = new DevExpress.Drawing.DXFont("Arial", 10F);
            this.gsUserID_1.ForeColor = System.Drawing.Color.Black;
            this.gsUserID_1.LocationFloat = new DevExpress.Utils.PointFloat(158.3333F, 0F);
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
            this.Text5.Font = new DevExpress.Drawing.DXFont("Arial", 10F, DevExpress.Drawing.DXFontStyle.Bold);
            this.Text5.ForeColor = System.Drawing.Color.Black;
            this.Text5.LocationFloat = new DevExpress.Utils.PointFloat(108.3333F, 0F);
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
            this.DataTime1.Font = new DevExpress.Drawing.DXFont("Arial", 10F);
            this.DataTime1.ForeColor = System.Drawing.Color.Black;
            this.DataTime1.LocationFloat = new DevExpress.Utils.PointFloat(0F, 0F);
            this.DataTime1.Name = "DataTime1";
            this.DataTime1.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.DataTime1.PageInfo = DevExpress.XtraPrinting.PageInfo.DateTime;
            this.DataTime1.SizeF = new System.Drawing.SizeF(78.125F, 18.33333F);
            this.DataTime1.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopLeft;
            this.DataTime1.TextFormatString = "{0:MM/dd/yyyy}";
            // 
            // WarrantyText
            // 
            this.WarrantyText.DataMember = "ClosedCustomerPaidInFullPriorToMaturity";
            this.WarrantyText.Expression = "Iif([Warranty], \'Yes\', \'No\')";
            this.WarrantyText.FieldType = DevExpress.XtraReports.UI.FieldType.String;
            this.WarrantyText.Name = "WarrantyText";
            // 
            // gdFromDate
            // 
            this.gdFromDate.Description = "Enter gdFromDate:";
            this.gdFromDate.Name = "gdFromDate";
            this.gdFromDate.Type = typeof(System.DateTime);
            this.gdFromDate.ValueInfo = "2021-08-01";
            // 
            // gdToDate
            // 
            this.gdToDate.Description = "Enter gdToDate:";
            this.gdToDate.Name = "gdToDate";
            this.gdToDate.Type = typeof(System.DateTime);
            this.gdToDate.ValueInfo = "2022-08-10";
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
            // sqlDataSource1
            // 
            this.sqlDataSource1.ConnectionName = "IAC2021SQL.Properties.Settings.IAC2010SQLConnectionString";
            this.sqlDataSource1.Name = "sqlDataSource1";
            storedProcQuery1.Name = "ClosedCustomerPaidInFullPriorToMaturity";
            queryParameter1.Name = "@StartDate";
            queryParameter1.Type = typeof(DevExpress.DataAccess.Expression);
            queryParameter1.Value = new DevExpress.DataAccess.Expression("?gdFromDate", typeof(System.DateTime));
            queryParameter2.Name = "@EndDate";
            queryParameter2.Type = typeof(DevExpress.DataAccess.Expression);
            queryParameter2.Value = new DevExpress.DataAccess.Expression("?gdToDate", typeof(System.DateTime));
            queryParameter3.Name = "@State";
            queryParameter3.Type = typeof(DevExpress.DataAccess.Expression);
            queryParameter3.Value = new DevExpress.DataAccess.Expression("?gsState", typeof(string));
            queryParameter4.Name = "@DealerNo";
            queryParameter4.Type = typeof(DevExpress.DataAccess.Expression);
            queryParameter4.Value = new DevExpress.DataAccess.Expression("?gsDealerNo", typeof(string));
            queryParameter5.Name = "@PaymentType";
            queryParameter5.Type = typeof(DevExpress.DataAccess.Expression);
            queryParameter5.Value = new DevExpress.DataAccess.Expression("?gsPaymentType", typeof(string));
            queryParameter6.Name = "@PaymentCode";
            queryParameter6.Type = typeof(DevExpress.DataAccess.Expression);
            queryParameter6.Value = new DevExpress.DataAccess.Expression("?gsPaymentCode", typeof(string));
            queryParameter7.Name = "@Gap";
            queryParameter7.Type = typeof(DevExpress.DataAccess.Expression);
            queryParameter7.Value = new DevExpress.DataAccess.Expression("?gbGap", typeof(bool));
            queryParameter8.Name = "@Warranty";
            queryParameter8.Type = typeof(DevExpress.DataAccess.Expression);
            queryParameter8.Value = new DevExpress.DataAccess.Expression("?gbWarranty", typeof(bool));
            storedProcQuery1.Parameters.AddRange(new DevExpress.DataAccess.Sql.QueryParameter[] {
            queryParameter1,
            queryParameter2,
            queryParameter3,
            queryParameter4,
            queryParameter5,
            queryParameter6,
            queryParameter7,
            queryParameter8});
            storedProcQuery1.StoredProcName = "ClosedCustomerPaidInFullPriorToMaturity";
            this.sqlDataSource1.Queries.AddRange(new DevExpress.DataAccess.Sql.SqlQuery[] {
            storedProcQuery1});
            this.sqlDataSource1.ResultSchemaSerializable = resources.GetString("sqlDataSource1.ResultSchemaSerializable");
            // 
            // topMarginBand1
            // 
            this.topMarginBand1.HeightF = 25F;
            this.topMarginBand1.Name = "topMarginBand1";
            // 
            // bottomMarginBand1
            // 
            this.bottomMarginBand1.HeightF = 25F;
            this.bottomMarginBand1.Name = "bottomMarginBand1";
            // 
            // gsState
            // 
            this.gsState.Description = "Enter State:";
            this.gsState.Name = "gsState";
            this.gsState.ValueInfo = "%";
            // 
            // gsDealerNo
            // 
            this.gsDealerNo.Description = "Enter Dealer Number:";
            this.gsDealerNo.Name = "gsDealerNo";
            this.gsDealerNo.ValueInfo = "%";
            // 
            // gsPaymentType
            // 
            this.gsPaymentType.Description = "Enter Payment Type:";
            this.gsPaymentType.Name = "gsPaymentType";
            this.gsPaymentType.ValueInfo = "%";
            // 
            // gsPaymentCode
            // 
            this.gsPaymentCode.Description = "Enter Payment Code:";
            this.gsPaymentCode.Name = "gsPaymentCode";
            this.gsPaymentCode.ValueInfo = "%";
            // 
            // gbGap
            // 
            this.gbGap.Description = "Gap?";
            this.gbGap.Name = "gbGap";
            this.gbGap.Type = typeof(bool);
            this.gbGap.ValueInfo = "False";
            // 
            // gbWarranty
            // 
            this.gbWarranty.Description = "Warranty?";
            this.gbWarranty.Name = "gbWarranty";
            this.gbWarranty.Type = typeof(bool);
            this.gbWarranty.ValueInfo = "False";
            // 
            // XtraReportClosedPaidInFullPriorToMaturity
            // 
            this.Bands.AddRange(new DevExpress.XtraReports.UI.Band[] {
            this.Area3,
            this.Area1,
            this.Area2,
            this.Area4,
            this.Area5,
            this.topMarginBand1,
            this.bottomMarginBand1});
            this.CalculatedFields.AddRange(new DevExpress.XtraReports.UI.CalculatedField[] {
            this.WarrantyText});
            this.ComponentStorage.AddRange(new System.ComponentModel.IComponent[] {
            this.sqlDataSource1});
            this.DataMember = "ClosedCustomerPaidInFullPriorToMaturity";
            this.DataSource = this.sqlDataSource1;
            this.Landscape = true;
            this.Margins = new DevExpress.Drawing.DXMargins(25, 25, 25, 25);
            this.PageHeight = 850;
            this.PageWidth = 1100;
            this.ParameterPanelLayoutItems.AddRange(new DevExpress.XtraReports.Parameters.ParameterPanelLayoutItem[] {
            new DevExpress.XtraReports.Parameters.ParameterLayoutItem(this.gdFromDate, DevExpress.XtraReports.Parameters.Orientation.Horizontal),
            new DevExpress.XtraReports.Parameters.ParameterLayoutItem(this.gdToDate, DevExpress.XtraReports.Parameters.Orientation.Horizontal),
            new DevExpress.XtraReports.Parameters.ParameterLayoutItem(this.gsUserName, DevExpress.XtraReports.Parameters.Orientation.Horizontal),
            new DevExpress.XtraReports.Parameters.ParameterLayoutItem(this.gsUserID, DevExpress.XtraReports.Parameters.Orientation.Horizontal),
            new DevExpress.XtraReports.Parameters.ParameterLayoutItem(this.gsState, DevExpress.XtraReports.Parameters.Orientation.Horizontal),
            new DevExpress.XtraReports.Parameters.ParameterLayoutItem(this.gsDealerNo, DevExpress.XtraReports.Parameters.Orientation.Horizontal),
            new DevExpress.XtraReports.Parameters.ParameterLayoutItem(this.gsPaymentType, DevExpress.XtraReports.Parameters.Orientation.Horizontal)});
            this.Parameters.AddRange(new DevExpress.XtraReports.Parameters.Parameter[] {
            this.gdFromDate,
            this.gdToDate,
            this.gsUserName,
            this.gsUserID,
            this.gsState,
            this.gsDealerNo,
            this.gsPaymentType,
            this.gsPaymentCode,
            this.gbGap,
            this.gbWarranty});
            this.Version = "22.1";
            ((System.ComponentModel.ISupportInitialize)(this)).EndInit();

        }

        #endregion

        private DevExpress.XtraReports.UI.DetailBand Area3;
        private DevExpress.XtraReports.UI.XRLabel CUSTOMERDEALER1;
        private DevExpress.XtraReports.UI.XRLabel Name1;
        private DevExpress.XtraReports.UI.XRLabel DEALERST1;
        private DevExpress.XtraReports.UI.XRLabel CUSTOMERNO2;
        private DevExpress.XtraReports.UI.XRLabel DateClosed2;
        private DevExpress.XtraReports.UI.XRLabel MaturityDate1;
        private DevExpress.XtraReports.UI.XRLabel PayCode1;
        private DevExpress.XtraReports.UI.XRLabel GapIns1;
        private DevExpress.XtraReports.UI.XRLabel WarrantyText_1;
        private DevExpress.XtraReports.UI.ReportHeaderBand Area1;
        private DevExpress.XtraReports.UI.XRLabel Text20;
        private DevExpress.XtraReports.UI.XRLabel Text21;
        private DevExpress.XtraReports.UI.XRLabel gdFromDate1;
        private DevExpress.XtraReports.UI.XRLabel Text22;
        private DevExpress.XtraReports.UI.XRLabel gdToDate1;
        private DevExpress.XtraReports.UI.PageHeaderBand Area2;
        private DevExpress.XtraReports.UI.XRLabel Text11;
        private DevExpress.XtraReports.UI.XRLabel Text13;
        private DevExpress.XtraReports.UI.XRLabel Text16;
        private DevExpress.XtraReports.UI.XRLabel Text19;
        private DevExpress.XtraReports.UI.XRLine Line1;
        private DevExpress.XtraReports.UI.XRLabel Text4;
        private DevExpress.XtraReports.UI.XRLabel Text7;
        private DevExpress.XtraReports.UI.XRLabel Text12;
        private DevExpress.XtraReports.UI.XRLabel Text14;
        private DevExpress.XtraReports.UI.XRLabel Text17;
        private DevExpress.XtraReports.UI.ReportFooterBand Area4;
        private DevExpress.XtraReports.UI.XRLabel Text1;
        private DevExpress.XtraReports.UI.XRLabel TotalCustomerCount1;
        private DevExpress.XtraReports.UI.PageFooterBand Area5;
        private DevExpress.XtraReports.UI.XRPageInfo PageNofM1;
        private DevExpress.XtraReports.UI.XRLabel gsUserName_1;
        private DevExpress.XtraReports.UI.XRLabel gsUserID_1;
        private DevExpress.XtraReports.UI.XRLabel Text5;
        private DevExpress.XtraReports.UI.XRPageInfo DataTime1;
        private DevExpress.XtraReports.UI.CalculatedField WarrantyText;
        private DevExpress.XtraReports.Parameters.Parameter gdFromDate;
        private DevExpress.XtraReports.Parameters.Parameter gdToDate;
        private DevExpress.XtraReports.Parameters.Parameter gsUserName;
        private DevExpress.XtraReports.Parameters.Parameter gsUserID;
        private DevExpress.XtraReports.UI.XRPictureBox Picture1;
        private DevExpress.DataAccess.Sql.SqlDataSource sqlDataSource1;
        private DevExpress.XtraReports.UI.TopMarginBand topMarginBand1;
        private DevExpress.XtraReports.UI.BottomMarginBand bottomMarginBand1;
        private DevExpress.XtraReports.Parameters.Parameter gsState;
        private DevExpress.XtraReports.Parameters.Parameter gsDealerNo;
        private DevExpress.XtraReports.Parameters.Parameter gsPaymentType;
        private DevExpress.XtraReports.Parameters.Parameter gsPaymentCode;
        private DevExpress.XtraReports.Parameters.Parameter gbGap;
        private DevExpress.XtraReports.Parameters.Parameter gbWarranty;
    }
}

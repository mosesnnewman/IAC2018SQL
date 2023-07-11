namespace IAC2021SQL
{
    partial class XtraReportClosedCustomerEditListDealerSummary
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
            DevExpress.XtraReports.UI.XRSummary xrSummary1 = new DevExpress.XtraReports.UI.XRSummary();
            DevExpress.XtraReports.UI.XRSummary xrSummary2 = new DevExpress.XtraReports.UI.XRSummary();
            DevExpress.XtraReports.UI.XRSummary xrSummary3 = new DevExpress.XtraReports.UI.XRSummary();
            DevExpress.XtraReports.UI.XRSummary xrSummary4 = new DevExpress.XtraReports.UI.XRSummary();
            DevExpress.XtraReports.UI.XRSummary xrSummary5 = new DevExpress.XtraReports.UI.XRSummary();
            DevExpress.XtraReports.UI.XRSummary xrSummary6 = new DevExpress.XtraReports.UI.XRSummary();
            DevExpress.XtraReports.UI.XRSummary xrSummary7 = new DevExpress.XtraReports.UI.XRSummary();
            DevExpress.DataAccess.Sql.StoredProcQuery storedProcQuery1 = new DevExpress.DataAccess.Sql.StoredProcQuery();
            DevExpress.DataAccess.Sql.StoredProcQuery storedProcQuery2 = new DevExpress.DataAccess.Sql.StoredProcQuery();
            DevExpress.DataAccess.Sql.MasterDetailInfo masterDetailInfo1 = new DevExpress.DataAccess.Sql.MasterDetailInfo();
            DevExpress.DataAccess.Sql.RelationColumnInfo relationColumnInfo1 = new DevExpress.DataAccess.Sql.RelationColumnInfo();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(XtraReportClosedCustomerEditListDealerSummary));
            this.DetailArea1 = new DevExpress.XtraReports.UI.DetailBand();
            this.GroupHeaderArea1 = new DevExpress.XtraReports.UI.GroupHeaderBand();
            this.GroupFooterArea1 = new DevExpress.XtraReports.UI.GroupFooterBand();
            this.CUSTOMERDEALER1 = new DevExpress.XtraReports.UI.XRLabel();
            this.TotalCustomerLoanAmount1 = new DevExpress.XtraReports.UI.XRLabel();
            this.TotalCustomerLoanInterest1 = new DevExpress.XtraReports.UI.XRLabel();
            this.TotalDealerDiscount1 = new DevExpress.XtraReports.UI.XRLabel();
            this.ReportHeaderArea1 = new DevExpress.XtraReports.UI.ReportHeaderBand();
            this.Text7 = new DevExpress.XtraReports.UI.XRLabel();
            this.Line1 = new DevExpress.XtraReports.UI.XRLine();
            this.Text8 = new DevExpress.XtraReports.UI.XRLabel();
            this.Text2 = new DevExpress.XtraReports.UI.XRLabel();
            this.Text1 = new DevExpress.XtraReports.UI.XRLabel();
            this.Text10 = new DevExpress.XtraReports.UI.XRLabel();
            this.PageHeaderArea1 = new DevExpress.XtraReports.UI.PageHeaderBand();
            this.ReportFooterArea1 = new DevExpress.XtraReports.UI.ReportFooterBand();
            this.GrandTotalCustomerLoanAmount1 = new DevExpress.XtraReports.UI.XRLabel();
            this.GrandTotalCustomerLoanInterest1 = new DevExpress.XtraReports.UI.XRLabel();
            this.GrandTotalCustomerDealerDiscount1 = new DevExpress.XtraReports.UI.XRLabel();
            this.Text3 = new DevExpress.XtraReports.UI.XRLabel();
            this.Text9 = new DevExpress.XtraReports.UI.XRLabel();
            this.TotalNewCustomers1 = new DevExpress.XtraReports.UI.XRLabel();
            this.PageFooterArea1 = new DevExpress.XtraReports.UI.PageFooterBand();
            this.Box1 = new DevExpress.XtraReports.UI.XRCrossBandBox();
            this.topMarginBand1 = new DevExpress.XtraReports.UI.TopMarginBand();
            this.bottomMarginBand1 = new DevExpress.XtraReports.UI.BottomMarginBand();
            this.sqlDataSource1 = new DevExpress.DataAccess.Sql.SqlDataSource(this.components);
            this.xrCrossBandBox1 = new DevExpress.XtraReports.UI.XRCrossBandBox();
            ((System.ComponentModel.ISupportInitialize)(this)).BeginInit();
            // 
            // DetailArea1
            // 
            this.DetailArea1.HeightF = 0F;
            this.DetailArea1.KeepTogether = true;
            this.DetailArea1.Name = "DetailArea1";
            this.DetailArea1.Padding = new DevExpress.XtraPrinting.PaddingInfo(0, 0, 0, 0, 100F);
            this.DetailArea1.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopLeft;
            this.DetailArea1.Visible = false;
            // 
            // GroupHeaderArea1
            // 
            this.GroupHeaderArea1.GroupFields.AddRange(new DevExpress.XtraReports.UI.GroupField[] {
            new DevExpress.XtraReports.UI.GroupField("CUSTOMER_DEALER", DevExpress.XtraReports.UI.XRColumnSortOrder.Ascending)});
            this.GroupHeaderArea1.HeightF = 0F;
            this.GroupHeaderArea1.KeepTogether = true;
            this.GroupHeaderArea1.Name = "GroupHeaderArea1";
            this.GroupHeaderArea1.Padding = new DevExpress.XtraPrinting.PaddingInfo(0, 0, 0, 0, 100F);
            this.GroupHeaderArea1.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopLeft;
            // 
            // GroupFooterArea1
            // 
            this.GroupFooterArea1.Controls.AddRange(new DevExpress.XtraReports.UI.XRControl[] {
            this.CUSTOMERDEALER1,
            this.TotalCustomerLoanAmount1,
            this.TotalCustomerLoanInterest1,
            this.TotalDealerDiscount1});
            this.GroupFooterArea1.HeightF = 25.06946F;
            this.GroupFooterArea1.KeepTogether = true;
            this.GroupFooterArea1.Name = "GroupFooterArea1";
            this.GroupFooterArea1.Padding = new DevExpress.XtraPrinting.PaddingInfo(0, 0, 0, 0, 100F);
            this.GroupFooterArea1.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopLeft;
            // 
            // CUSTOMERDEALER1
            // 
            this.CUSTOMERDEALER1.BackColor = System.Drawing.Color.Transparent;
            this.CUSTOMERDEALER1.BorderColor = System.Drawing.Color.Black;
            this.CUSTOMERDEALER1.Borders = DevExpress.XtraPrinting.BorderSide.None;
            this.CUSTOMERDEALER1.BorderWidth = 1F;
            this.CUSTOMERDEALER1.CanGrow = false;
            this.CUSTOMERDEALER1.ExpressionBindings.AddRange(new DevExpress.XtraReports.UI.ExpressionBinding[] {
            new DevExpress.XtraReports.UI.ExpressionBinding("BeforePrint", "Text", "[CUSTOMERDEALER].[DEALER_ST]+\'-\'+ToStr([CUSTOMERDEALER].[id])+\' \'+[CUSTOMERDEALER" +
                    "].[DEALER_NAME]\n")});
            this.CUSTOMERDEALER1.Font = new DevExpress.Drawing.DXFont("Arial", 9F, DevExpress.Drawing.DXFontStyle.Bold, DevExpress.Drawing.DXGraphicsUnit.Point, new DevExpress.Drawing.DXFontAdditionalProperty[] {new DevExpress.Drawing.DXFontAdditionalProperty("GdiCharSet", ((byte)(0)))});
            this.CUSTOMERDEALER1.ForeColor = System.Drawing.Color.Black;
            this.CUSTOMERDEALER1.LocationFloat = new DevExpress.Utils.PointFloat(88.20832F, 2.000014F);
            this.CUSTOMERDEALER1.Name = "CUSTOMERDEALER1";
            this.CUSTOMERDEALER1.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.CUSTOMERDEALER1.SizeF = new System.Drawing.SizeF(509.375F, 18.33333F);
            this.CUSTOMERDEALER1.StylePriority.UseFont = false;
            this.CUSTOMERDEALER1.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopLeft;
            // 
            // TotalCustomerLoanAmount1
            // 
            this.TotalCustomerLoanAmount1.BackColor = System.Drawing.Color.Transparent;
            this.TotalCustomerLoanAmount1.BorderColor = System.Drawing.Color.Black;
            this.TotalCustomerLoanAmount1.Borders = DevExpress.XtraPrinting.BorderSide.None;
            this.TotalCustomerLoanAmount1.BorderWidth = 1F;
            this.TotalCustomerLoanAmount1.CanGrow = false;
            this.TotalCustomerLoanAmount1.ExpressionBindings.AddRange(new DevExpress.XtraReports.UI.ExpressionBinding[] {
            new DevExpress.XtraReports.UI.ExpressionBinding("BeforePrint", "Text", "sumSum([CUSTOMER_LOAN_AMOUNT])")});
            this.TotalCustomerLoanAmount1.Font = new DevExpress.Drawing.DXFont("Arial", 9F);
            this.TotalCustomerLoanAmount1.ForeColor = System.Drawing.Color.Black;
            this.TotalCustomerLoanAmount1.LocationFloat = new DevExpress.Utils.PointFloat(607F, 2F);
            this.TotalCustomerLoanAmount1.Name = "TotalCustomerLoanAmount1";
            this.TotalCustomerLoanAmount1.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.TotalCustomerLoanAmount1.SizeF = new System.Drawing.SizeF(101.0417F, 16.66667F);
            xrSummary1.Running = DevExpress.XtraReports.UI.SummaryRunning.Group;
            this.TotalCustomerLoanAmount1.Summary = xrSummary1;
            this.TotalCustomerLoanAmount1.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopRight;
            this.TotalCustomerLoanAmount1.TextFormatString = "{0:C2}";
            this.TotalCustomerLoanAmount1.BeforePrint += new DevExpress.XtraReports.UI.BeforePrintEventHandler(this.TotalCustomerLoanAmount1_BeforePrint);
            // 
            // TotalCustomerLoanInterest1
            // 
            this.TotalCustomerLoanInterest1.BackColor = System.Drawing.Color.Transparent;
            this.TotalCustomerLoanInterest1.BorderColor = System.Drawing.Color.Black;
            this.TotalCustomerLoanInterest1.Borders = DevExpress.XtraPrinting.BorderSide.None;
            this.TotalCustomerLoanInterest1.BorderWidth = 1F;
            this.TotalCustomerLoanInterest1.CanGrow = false;
            this.TotalCustomerLoanInterest1.ExpressionBindings.AddRange(new DevExpress.XtraReports.UI.ExpressionBinding[] {
            new DevExpress.XtraReports.UI.ExpressionBinding("BeforePrint", "Text", "sumSum([CUSTOMER_LOAN_INTEREST])")});
            this.TotalCustomerLoanInterest1.Font = new DevExpress.Drawing.DXFont("Arial", 9F);
            this.TotalCustomerLoanInterest1.ForeColor = System.Drawing.Color.Black;
            this.TotalCustomerLoanInterest1.LocationFloat = new DevExpress.Utils.PointFloat(732F, 2F);
            this.TotalCustomerLoanInterest1.Name = "TotalCustomerLoanInterest1";
            this.TotalCustomerLoanInterest1.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.TotalCustomerLoanInterest1.SizeF = new System.Drawing.SizeF(101.0417F, 16.66667F);
            xrSummary2.Running = DevExpress.XtraReports.UI.SummaryRunning.Group;
            this.TotalCustomerLoanInterest1.Summary = xrSummary2;
            this.TotalCustomerLoanInterest1.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopRight;
            this.TotalCustomerLoanInterest1.TextFormatString = "{0:C2}";
            this.TotalCustomerLoanInterest1.BeforePrint += new DevExpress.XtraReports.UI.BeforePrintEventHandler(this.TotalCustomerLoanInterest1_BeforePrint);
            // 
            // TotalDealerDiscount1
            // 
            this.TotalDealerDiscount1.BackColor = System.Drawing.Color.Transparent;
            this.TotalDealerDiscount1.BorderColor = System.Drawing.Color.Black;
            this.TotalDealerDiscount1.Borders = DevExpress.XtraPrinting.BorderSide.None;
            this.TotalDealerDiscount1.BorderWidth = 1F;
            this.TotalDealerDiscount1.CanGrow = false;
            this.TotalDealerDiscount1.ExpressionBindings.AddRange(new DevExpress.XtraReports.UI.ExpressionBinding[] {
            new DevExpress.XtraReports.UI.ExpressionBinding("BeforePrint", "Text", "sumSum([CUSTOMER_DEALER_DISC])")});
            this.TotalDealerDiscount1.Font = new DevExpress.Drawing.DXFont("Arial", 9F);
            this.TotalDealerDiscount1.ForeColor = System.Drawing.Color.Black;
            this.TotalDealerDiscount1.LocationFloat = new DevExpress.Utils.PointFloat(857F, 2.000014F);
            this.TotalDealerDiscount1.Name = "TotalDealerDiscount1";
            this.TotalDealerDiscount1.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.TotalDealerDiscount1.SizeF = new System.Drawing.SizeF(93.75006F, 16.66667F);
            xrSummary3.Running = DevExpress.XtraReports.UI.SummaryRunning.Group;
            this.TotalDealerDiscount1.Summary = xrSummary3;
            this.TotalDealerDiscount1.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopRight;
            this.TotalDealerDiscount1.TextFormatString = "{0:C2}";
            this.TotalDealerDiscount1.BeforePrint += new DevExpress.XtraReports.UI.BeforePrintEventHandler(this.TotalDealerDiscount1_BeforePrint);
            // 
            // ReportHeaderArea1
            // 
            this.ReportHeaderArea1.Controls.AddRange(new DevExpress.XtraReports.UI.XRControl[] {
            this.Text7,
            this.Line1,
            this.Text8,
            this.Text2,
            this.Text1,
            this.Text10});
            this.ReportHeaderArea1.HeightF = 68.05555F;
            this.ReportHeaderArea1.KeepTogether = true;
            this.ReportHeaderArea1.Name = "ReportHeaderArea1";
            this.ReportHeaderArea1.Padding = new DevExpress.XtraPrinting.PaddingInfo(0, 0, 0, 0, 100F);
            this.ReportHeaderArea1.StylePriority.UseTextAlignment = false;
            this.ReportHeaderArea1.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopLeft;
            // 
            // Text7
            // 
            this.Text7.BackColor = System.Drawing.Color.Transparent;
            this.Text7.BorderColor = System.Drawing.Color.Black;
            this.Text7.Borders = DevExpress.XtraPrinting.BorderSide.None;
            this.Text7.BorderWidth = 1F;
            this.Text7.CanGrow = false;
            this.Text7.Font = new DevExpress.Drawing.DXFont("Arial", 9F, DevExpress.Drawing.DXFontStyle.Bold);
            this.Text7.ForeColor = System.Drawing.Color.Black;
            this.Text7.LocationFloat = new DevExpress.Utils.PointFloat(88.20832F, 41.66667F);
            this.Text7.Name = "Text7";
            this.Text7.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.Text7.SizeF = new System.Drawing.SizeF(71.87502F, 18.33333F);
            this.Text7.Text = "DEALER#";
            this.Text7.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopLeft;
            // 
            // Line1
            // 
            this.Line1.BackColor = System.Drawing.Color.Transparent;
            this.Line1.BorderColor = System.Drawing.Color.Navy;
            this.Line1.Borders = DevExpress.XtraPrinting.BorderSide.Top;
            this.Line1.BorderWidth = 1F;
            this.Line1.Font = new DevExpress.Drawing.DXFont("Times New Roman", 9.75F);
            this.Line1.ForeColor = System.Drawing.Color.Navy;
            this.Line1.LineWidth = 3F;
            this.Line1.LocationFloat = new DevExpress.Utils.PointFloat(85.08333F, 64.93053F);
            this.Line1.Name = "Line1";
            this.Line1.Padding = new DevExpress.XtraPrinting.PaddingInfo(0, 0, 0, 0, 100F);
            this.Line1.SizeF = new System.Drawing.SizeF(879.4167F, 3.125F);
            // 
            // Text8
            // 
            this.Text8.BackColor = System.Drawing.Color.Transparent;
            this.Text8.BorderColor = System.Drawing.Color.Black;
            this.Text8.Borders = DevExpress.XtraPrinting.BorderSide.None;
            this.Text8.BorderWidth = 1F;
            this.Text8.CanGrow = false;
            this.Text8.Font = new DevExpress.Drawing.DXFont("Arial", 14F, DevExpress.Drawing.DXFontStyle.Bold);
            this.Text8.ForeColor = System.Drawing.Color.Black;
            this.Text8.LocationFloat = new DevExpress.Utils.PointFloat(429.1667F, 2.499994F);
            this.Text8.Name = "Text8";
            this.Text8.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.Text8.SizeF = new System.Drawing.SizeF(191.6667F, 25F);
            this.Text8.Text = "DEALER SUMMARY";
            this.Text8.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopCenter;
            // 
            // Text2
            // 
            this.Text2.BackColor = System.Drawing.Color.Transparent;
            this.Text2.BorderColor = System.Drawing.Color.Black;
            this.Text2.Borders = DevExpress.XtraPrinting.BorderSide.None;
            this.Text2.BorderWidth = 1F;
            this.Text2.CanGrow = false;
            this.Text2.Font = new DevExpress.Drawing.DXFont("Arial", 9F, DevExpress.Drawing.DXFontStyle.Bold);
            this.Text2.ForeColor = System.Drawing.Color.Black;
            this.Text2.LocationFloat = new DevExpress.Utils.PointFloat(732F, 41.66667F);
            this.Text2.Name = "Text2";
            this.Text2.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.Text2.SizeF = new System.Drawing.SizeF(76.52778F, 18.33333F);
            this.Text2.Text = "INTEREST";
            this.Text2.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopLeft;
            // 
            // Text1
            // 
            this.Text1.BackColor = System.Drawing.Color.Transparent;
            this.Text1.BorderColor = System.Drawing.Color.Black;
            this.Text1.Borders = DevExpress.XtraPrinting.BorderSide.None;
            this.Text1.BorderWidth = 1F;
            this.Text1.CanGrow = false;
            this.Text1.Font = new DevExpress.Drawing.DXFont("Arial", 9F, DevExpress.Drawing.DXFontStyle.Bold);
            this.Text1.ForeColor = System.Drawing.Color.Black;
            this.Text1.LocationFloat = new DevExpress.Utils.PointFloat(825.5417F, 41.66667F);
            this.Text1.Name = "Text1";
            this.Text1.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.Text1.SizeF = new System.Drawing.SizeF(125.2084F, 18.33333F);
            this.Text1.Text = "DEALER DISCOUNT";
            this.Text1.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopLeft;
            // 
            // Text10
            // 
            this.Text10.BackColor = System.Drawing.Color.Transparent;
            this.Text10.BorderColor = System.Drawing.Color.Black;
            this.Text10.Borders = DevExpress.XtraPrinting.BorderSide.None;
            this.Text10.BorderWidth = 1F;
            this.Text10.CanGrow = false;
            this.Text10.Font = new DevExpress.Drawing.DXFont("Arial", 9F, DevExpress.Drawing.DXFontStyle.Bold);
            this.Text10.ForeColor = System.Drawing.Color.Black;
            this.Text10.LocationFloat = new DevExpress.Utils.PointFloat(598.6667F, 41.66667F);
            this.Text10.Name = "Text10";
            this.Text10.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.Text10.SizeF = new System.Drawing.SizeF(100F, 18.33333F);
            this.Text10.Text = "LOAN AMOUNT";
            this.Text10.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopLeft;
            // 
            // PageHeaderArea1
            // 
            this.PageHeaderArea1.HeightF = 0F;
            this.PageHeaderArea1.Name = "PageHeaderArea1";
            this.PageHeaderArea1.Padding = new DevExpress.XtraPrinting.PaddingInfo(0, 0, 0, 0, 100F);
            this.PageHeaderArea1.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopLeft;
            // 
            // ReportFooterArea1
            // 
            this.ReportFooterArea1.Controls.AddRange(new DevExpress.XtraReports.UI.XRControl[] {
            this.GrandTotalCustomerLoanAmount1,
            this.GrandTotalCustomerLoanInterest1,
            this.GrandTotalCustomerDealerDiscount1,
            this.Text3,
            this.Text9,
            this.TotalNewCustomers1});
            this.ReportFooterArea1.HeightF = 45F;
            this.ReportFooterArea1.KeepTogether = true;
            this.ReportFooterArea1.Name = "ReportFooterArea1";
            this.ReportFooterArea1.Padding = new DevExpress.XtraPrinting.PaddingInfo(0, 0, 0, 0, 100F);
            this.ReportFooterArea1.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopLeft;
            // 
            // GrandTotalCustomerLoanAmount1
            // 
            this.GrandTotalCustomerLoanAmount1.BackColor = System.Drawing.Color.Transparent;
            this.GrandTotalCustomerLoanAmount1.BorderColor = System.Drawing.Color.Black;
            this.GrandTotalCustomerLoanAmount1.Borders = DevExpress.XtraPrinting.BorderSide.None;
            this.GrandTotalCustomerLoanAmount1.BorderWidth = 1F;
            this.GrandTotalCustomerLoanAmount1.CanGrow = false;
            this.GrandTotalCustomerLoanAmount1.ExpressionBindings.AddRange(new DevExpress.XtraReports.UI.ExpressionBinding[] {
            new DevExpress.XtraReports.UI.ExpressionBinding("BeforePrint", "Text", "sumSum([CUSTOMER_LOAN_AMOUNT])")});
            this.GrandTotalCustomerLoanAmount1.Font = new DevExpress.Drawing.DXFont("Arial", 9F, DevExpress.Drawing.DXFontStyle.Bold);
            this.GrandTotalCustomerLoanAmount1.ForeColor = System.Drawing.Color.Black;
            this.GrandTotalCustomerLoanAmount1.LocationFloat = new DevExpress.Utils.PointFloat(607F, 0F);
            this.GrandTotalCustomerLoanAmount1.Name = "GrandTotalCustomerLoanAmount1";
            this.GrandTotalCustomerLoanAmount1.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.GrandTotalCustomerLoanAmount1.SizeF = new System.Drawing.SizeF(101.0417F, 16.66667F);
            xrSummary4.Running = DevExpress.XtraReports.UI.SummaryRunning.Report;
            this.GrandTotalCustomerLoanAmount1.Summary = xrSummary4;
            this.GrandTotalCustomerLoanAmount1.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopRight;
            this.GrandTotalCustomerLoanAmount1.TextFormatString = "{0:C2}";
            this.GrandTotalCustomerLoanAmount1.BeforePrint += new DevExpress.XtraReports.UI.BeforePrintEventHandler(this.GrandTotalCustomerLoanAmount1_BeforePrint);
            // 
            // GrandTotalCustomerLoanInterest1
            // 
            this.GrandTotalCustomerLoanInterest1.BackColor = System.Drawing.Color.Transparent;
            this.GrandTotalCustomerLoanInterest1.BorderColor = System.Drawing.Color.Black;
            this.GrandTotalCustomerLoanInterest1.Borders = DevExpress.XtraPrinting.BorderSide.None;
            this.GrandTotalCustomerLoanInterest1.BorderWidth = 1F;
            this.GrandTotalCustomerLoanInterest1.CanGrow = false;
            this.GrandTotalCustomerLoanInterest1.ExpressionBindings.AddRange(new DevExpress.XtraReports.UI.ExpressionBinding[] {
            new DevExpress.XtraReports.UI.ExpressionBinding("BeforePrint", "Text", "sumSum([CUSTOMER_LOAN_INTEREST])")});
            this.GrandTotalCustomerLoanInterest1.Font = new DevExpress.Drawing.DXFont("Arial", 9F, DevExpress.Drawing.DXFontStyle.Bold);
            this.GrandTotalCustomerLoanInterest1.ForeColor = System.Drawing.Color.Black;
            this.GrandTotalCustomerLoanInterest1.LocationFloat = new DevExpress.Utils.PointFloat(732F, 0F);
            this.GrandTotalCustomerLoanInterest1.Name = "GrandTotalCustomerLoanInterest1";
            this.GrandTotalCustomerLoanInterest1.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.GrandTotalCustomerLoanInterest1.SizeF = new System.Drawing.SizeF(101.0417F, 16.66667F);
            xrSummary5.Running = DevExpress.XtraReports.UI.SummaryRunning.Report;
            this.GrandTotalCustomerLoanInterest1.Summary = xrSummary5;
            this.GrandTotalCustomerLoanInterest1.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopRight;
            this.GrandTotalCustomerLoanInterest1.TextFormatString = "{0:C2}";
            this.GrandTotalCustomerLoanInterest1.BeforePrint += new DevExpress.XtraReports.UI.BeforePrintEventHandler(this.GrandTotalCustomerLoanInterest1_BeforePrint);
            // 
            // GrandTotalCustomerDealerDiscount1
            // 
            this.GrandTotalCustomerDealerDiscount1.BackColor = System.Drawing.Color.Transparent;
            this.GrandTotalCustomerDealerDiscount1.BorderColor = System.Drawing.Color.Black;
            this.GrandTotalCustomerDealerDiscount1.Borders = DevExpress.XtraPrinting.BorderSide.None;
            this.GrandTotalCustomerDealerDiscount1.BorderWidth = 1F;
            this.GrandTotalCustomerDealerDiscount1.CanGrow = false;
            this.GrandTotalCustomerDealerDiscount1.ExpressionBindings.AddRange(new DevExpress.XtraReports.UI.ExpressionBinding[] {
            new DevExpress.XtraReports.UI.ExpressionBinding("BeforePrint", "Text", "sumSum([CUSTOMER_DEALER_DISC])")});
            this.GrandTotalCustomerDealerDiscount1.Font = new DevExpress.Drawing.DXFont("Arial", 9F, DevExpress.Drawing.DXFontStyle.Bold);
            this.GrandTotalCustomerDealerDiscount1.ForeColor = System.Drawing.Color.Black;
            this.GrandTotalCustomerDealerDiscount1.LocationFloat = new DevExpress.Utils.PointFloat(857F, 0F);
            this.GrandTotalCustomerDealerDiscount1.Name = "GrandTotalCustomerDealerDiscount1";
            this.GrandTotalCustomerDealerDiscount1.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.GrandTotalCustomerDealerDiscount1.SizeF = new System.Drawing.SizeF(93.75006F, 16.66667F);
            xrSummary6.Running = DevExpress.XtraReports.UI.SummaryRunning.Report;
            this.GrandTotalCustomerDealerDiscount1.Summary = xrSummary6;
            this.GrandTotalCustomerDealerDiscount1.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopRight;
            this.GrandTotalCustomerDealerDiscount1.TextFormatString = "{0:C2}";
            this.GrandTotalCustomerDealerDiscount1.BeforePrint += new DevExpress.XtraReports.UI.BeforePrintEventHandler(this.GrandTotalCustomerDealerDiscount1_BeforePrint);
            // 
            // Text3
            // 
            this.Text3.BackColor = System.Drawing.Color.Transparent;
            this.Text3.BorderColor = System.Drawing.Color.Black;
            this.Text3.Borders = DevExpress.XtraPrinting.BorderSide.None;
            this.Text3.BorderWidth = 1F;
            this.Text3.CanGrow = false;
            this.Text3.Font = new DevExpress.Drawing.DXFont("Arial", 9F, DevExpress.Drawing.DXFontStyle.Bold);
            this.Text3.ForeColor = System.Drawing.Color.Black;
            this.Text3.LocationFloat = new DevExpress.Utils.PointFloat(88.20832F, 0F);
            this.Text3.Name = "Text3";
            this.Text3.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.Text3.SizeF = new System.Drawing.SizeF(55.20833F, 18.33333F);
            this.Text3.Text = "TOTALS";
            this.Text3.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopLeft;
            // 
            // Text9
            // 
            this.Text9.BackColor = System.Drawing.Color.Transparent;
            this.Text9.BorderColor = System.Drawing.Color.Black;
            this.Text9.Borders = DevExpress.XtraPrinting.BorderSide.None;
            this.Text9.BorderWidth = 1F;
            this.Text9.CanGrow = false;
            this.Text9.Font = new DevExpress.Drawing.DXFont("Segoe UI", 9F, DevExpress.Drawing.DXFontStyle.Bold);
            this.Text9.ForeColor = System.Drawing.Color.Black;
            this.Text9.LocationFloat = new DevExpress.Utils.PointFloat(223.6667F, 22.91668F);
            this.Text9.Name = "Text9";
            this.Text9.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.Text9.SizeF = new System.Drawing.SizeF(166.6667F, 18.33333F);
            this.Text9.Text = "TOTAL NEW CUSTOMERS:";
            this.Text9.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopLeft;
            // 
            // TotalNewCustomers1
            // 
            this.TotalNewCustomers1.BackColor = System.Drawing.Color.Transparent;
            this.TotalNewCustomers1.BorderColor = System.Drawing.Color.Black;
            this.TotalNewCustomers1.Borders = DevExpress.XtraPrinting.BorderSide.None;
            this.TotalNewCustomers1.BorderWidth = 1F;
            this.TotalNewCustomers1.CanGrow = false;
            this.TotalNewCustomers1.ExpressionBindings.AddRange(new DevExpress.XtraReports.UI.ExpressionBinding[] {
            new DevExpress.XtraReports.UI.ExpressionBinding("BeforePrint", "Text", "sumCount([CUSTOMER_NO])")});
            this.TotalNewCustomers1.Font = new DevExpress.Drawing.DXFont("Segoe UI", 9F, DevExpress.Drawing.DXFontStyle.Bold);
            this.TotalNewCustomers1.ForeColor = System.Drawing.Color.Black;
            this.TotalNewCustomers1.LocationFloat = new DevExpress.Utils.PointFloat(390.3333F, 22.91668F);
            this.TotalNewCustomers1.Name = "TotalNewCustomers1";
            this.TotalNewCustomers1.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.TotalNewCustomers1.SizeF = new System.Drawing.SizeF(41.59722F, 16.66667F);
            xrSummary7.Running = DevExpress.XtraReports.UI.SummaryRunning.Report;
            this.TotalNewCustomers1.Summary = xrSummary7;
            this.TotalNewCustomers1.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopLeft;
            // 
            // PageFooterArea1
            // 
            this.PageFooterArea1.HeightF = 41F;
            this.PageFooterArea1.Name = "PageFooterArea1";
            this.PageFooterArea1.Padding = new DevExpress.XtraPrinting.PaddingInfo(0, 0, 0, 0, 100F);
            this.PageFooterArea1.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopLeft;
            // 
            // Box1
            // 
            this.Box1.AnchorVertical = ((DevExpress.XtraReports.UI.VerticalAnchorStyles)((DevExpress.XtraReports.UI.VerticalAnchorStyles.Top | DevExpress.XtraReports.UI.VerticalAnchorStyles.Bottom)));
            this.Box1.BorderWidth = 1F;
            this.Box1.EndBand = this.GroupFooterArea1;
            this.Box1.EndPointFloat = new DevExpress.Utils.PointFloat(87.16666F, 24.63893F);
            this.Box1.Name = "Box1";
            this.Box1.StartBand = this.GroupFooterArea1;
            this.Box1.StartPointFloat = new DevExpress.Utils.PointFloat(87.16666F, 0F);
            this.Box1.WidthF = 875.25F;
            // 
            // topMarginBand1
            // 
            this.topMarginBand1.HeightF = 35F;
            this.topMarginBand1.Name = "topMarginBand1";
            // 
            // bottomMarginBand1
            // 
            this.bottomMarginBand1.HeightF = 25F;
            this.bottomMarginBand1.Name = "bottomMarginBand1";
            // 
            // sqlDataSource1
            // 
            this.sqlDataSource1.ConnectionName = "IAC2021SQL.Properties.Settings.IAC2010SQLConnectionString";
            this.sqlDataSource1.Name = "sqlDataSource1";
            storedProcQuery1.Name = "CUSTOMER";
            storedProcQuery1.StoredProcName = "ClosedCustomerFillByNonPosted";
            storedProcQuery2.Name = "DEALER";
            storedProcQuery2.StoredProcName = "ClosedDealerFillByNonPostedCustomers";
            this.sqlDataSource1.Queries.AddRange(new DevExpress.DataAccess.Sql.SqlQuery[] {
            storedProcQuery1,
            storedProcQuery2});
            masterDetailInfo1.DetailQueryName = "DEALER";
            relationColumnInfo1.NestedKeyColumn = "id";
            relationColumnInfo1.ParentKeyColumn = "CUSTOMER_DEALER";
            masterDetailInfo1.KeyColumns.Add(relationColumnInfo1);
            masterDetailInfo1.MasterQueryName = "CUSTOMER";
            this.sqlDataSource1.Relations.AddRange(new DevExpress.DataAccess.Sql.MasterDetailInfo[] {
            masterDetailInfo1});
            this.sqlDataSource1.ResultSchemaSerializable = resources.GetString("sqlDataSource1.ResultSchemaSerializable");
            // 
            // xrCrossBandBox1
            // 
            this.xrCrossBandBox1.AnchorVertical = DevExpress.XtraReports.UI.VerticalAnchorStyles.None;
            this.xrCrossBandBox1.EndBand = this.ReportFooterArea1;
            this.xrCrossBandBox1.EndPointFloat = new DevExpress.Utils.PointFloat(85.08333F, 44.74998F);
            this.xrCrossBandBox1.Name = "xrCrossBandBox1";
            this.xrCrossBandBox1.StartBand = this.ReportHeaderArea1;
            this.xrCrossBandBox1.StartPointFloat = new DevExpress.Utils.PointFloat(85.08333F, 0.4166603F);
            this.xrCrossBandBox1.WidthF = 879.4167F;
            // 
            // XtraReportClosedCustomerEditListDealerSummary
            // 
            this.Bands.AddRange(new DevExpress.XtraReports.UI.Band[] {
            this.DetailArea1,
            this.GroupHeaderArea1,
            this.GroupFooterArea1,
            this.ReportHeaderArea1,
            this.PageHeaderArea1,
            this.ReportFooterArea1,
            this.PageFooterArea1,
            this.topMarginBand1,
            this.bottomMarginBand1});
            this.ComponentStorage.AddRange(new System.ComponentModel.IComponent[] {
            this.sqlDataSource1});
            this.CrossBandControls.AddRange(new DevExpress.XtraReports.UI.XRCrossBandControl[] {
            this.xrCrossBandBox1,
            this.Box1});
            this.DataMember = "CUSTOMER";
            this.DataSource = this.sqlDataSource1;
            this.Landscape = true;
            this.Margins = new DevExpress.Drawing.DXMargins(25, 25, 35, 25);
            this.PageHeight = 850;
            this.PageWidth = 1100;
            this.Version = "22.1";
            ((System.ComponentModel.ISupportInitialize)(this)).EndInit();

        }

        #endregion

        private DevExpress.XtraReports.UI.DetailBand DetailArea1;
        private DevExpress.XtraReports.UI.GroupHeaderBand GroupHeaderArea1;
        private DevExpress.XtraReports.UI.GroupFooterBand GroupFooterArea1;
        private DevExpress.XtraReports.UI.XRLabel CUSTOMERDEALER1;
        private DevExpress.XtraReports.UI.XRLabel TotalCustomerLoanAmount1;
        private DevExpress.XtraReports.UI.XRLabel TotalCustomerLoanInterest1;
        private DevExpress.XtraReports.UI.XRLabel TotalDealerDiscount1;
        private DevExpress.XtraReports.UI.ReportHeaderBand ReportHeaderArea1;
        private DevExpress.XtraReports.UI.XRLabel Text7;
        private DevExpress.XtraReports.UI.XRLine Line1;
        private DevExpress.XtraReports.UI.XRLabel Text8;
        private DevExpress.XtraReports.UI.XRLabel Text2;
        private DevExpress.XtraReports.UI.XRLabel Text1;
        private DevExpress.XtraReports.UI.XRLabel Text10;
        private DevExpress.XtraReports.UI.PageHeaderBand PageHeaderArea1;
        private DevExpress.XtraReports.UI.ReportFooterBand ReportFooterArea1;
        private DevExpress.XtraReports.UI.XRLabel GrandTotalCustomerLoanAmount1;
        private DevExpress.XtraReports.UI.XRLabel GrandTotalCustomerLoanInterest1;
        private DevExpress.XtraReports.UI.XRLabel GrandTotalCustomerDealerDiscount1;
        private DevExpress.XtraReports.UI.XRLabel Text3;
        private DevExpress.XtraReports.UI.XRLabel Text9;
        private DevExpress.XtraReports.UI.XRLabel TotalNewCustomers1;
        private DevExpress.XtraReports.UI.PageFooterBand PageFooterArea1;
        private DevExpress.XtraReports.UI.XRCrossBandBox Box1;
        private DevExpress.XtraReports.UI.TopMarginBand topMarginBand1;
        private DevExpress.XtraReports.UI.BottomMarginBand bottomMarginBand1;
        private DevExpress.DataAccess.Sql.SqlDataSource sqlDataSource1;
        private DevExpress.XtraReports.UI.XRCrossBandBox xrCrossBandBox1;
    }
}

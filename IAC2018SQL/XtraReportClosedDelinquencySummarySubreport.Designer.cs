namespace IAC2021SQL
{
    partial class XtraReportClosedDelinquencySummarySubreport
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(XtraReportClosedDelinquencySummarySubreport));
            DevExpress.XtraReports.UI.XRSummary xrSummary5 = new DevExpress.XtraReports.UI.XRSummary();
            DevExpress.XtraReports.UI.XRSummary xrSummary6 = new DevExpress.XtraReports.UI.XRSummary();
            DevExpress.DataAccess.Sql.StoredProcQuery storedProcQuery1 = new DevExpress.DataAccess.Sql.StoredProcQuery();
            DevExpress.DataAccess.Sql.QueryParameter queryParameter1 = new DevExpress.DataAccess.Sql.QueryParameter();
            DevExpress.DataAccess.Sql.QueryParameter queryParameter2 = new DevExpress.DataAccess.Sql.QueryParameter();
            DevExpress.DataAccess.Sql.QueryParameter queryParameter3 = new DevExpress.DataAccess.Sql.QueryParameter();
            DevExpress.DataAccess.Sql.StoredProcQuery storedProcQuery2 = new DevExpress.DataAccess.Sql.StoredProcQuery();
            DevExpress.DataAccess.Sql.QueryParameter queryParameter4 = new DevExpress.DataAccess.Sql.QueryParameter();
            DevExpress.DataAccess.Sql.QueryParameter queryParameter5 = new DevExpress.DataAccess.Sql.QueryParameter();
            DevExpress.DataAccess.Sql.MasterDetailInfo masterDetailInfo1 = new DevExpress.DataAccess.Sql.MasterDetailInfo();
            DevExpress.DataAccess.Sql.RelationColumnInfo relationColumnInfo1 = new DevExpress.DataAccess.Sql.RelationColumnInfo();
            this.Area3 = new DevExpress.XtraReports.UI.DetailBand();
            this.GroupHeaderArea2 = new DevExpress.XtraReports.UI.GroupHeaderBand();
            this.GroupHeaderArea1 = new DevExpress.XtraReports.UI.GroupHeaderBand();
            this.xrLabel1 = new DevExpress.XtraReports.UI.XRLabel();
            this.GroupFooterArea1 = new DevExpress.XtraReports.UI.GroupFooterBand();
            this.TotalBalanceByDealer1 = new DevExpress.XtraReports.UI.XRLabel();
            this.TotalDelinquentsByDealer1 = new DevExpress.XtraReports.UI.XRLabel();
            this.NewDealerNumber_1 = new DevExpress.XtraReports.UI.XRLabel();
            this.GroupFooterArea2 = new DevExpress.XtraReports.UI.GroupFooterBand();
            this.GroupNameDEALERST1 = new DevExpress.XtraReports.UI.XRLabel();
            this.TotalBalanceByDealerState1 = new DevExpress.XtraReports.UI.XRLabel();
            this.TotalDelinquentsByDealerState1 = new DevExpress.XtraReports.UI.XRLabel();
            this.Area1 = new DevExpress.XtraReports.UI.ReportHeaderBand();
            this.Section1 = new DevExpress.XtraReports.UI.SubBand();
            this.ReportHeaderSection1 = new DevExpress.XtraReports.UI.SubBand();
            this.PageHeaderArea1 = new DevExpress.XtraReports.UI.PageHeaderBand();
            this.Picture2 = new DevExpress.XtraReports.UI.XRPictureBox();
            this.AgedTitle_2 = new DevExpress.XtraReports.UI.XRLabel();
            this.Text28 = new DevExpress.XtraReports.UI.XRLabel();
            this.Text27 = new DevExpress.XtraReports.UI.XRLabel();
            this.gdCurrentDate2 = new DevExpress.XtraReports.UI.XRLabel();
            this.Text26 = new DevExpress.XtraReports.UI.XRLabel();
            this.Text24 = new DevExpress.XtraReports.UI.XRLabel();
            this.Line3 = new DevExpress.XtraReports.UI.XRLine();
            this.Text23 = new DevExpress.XtraReports.UI.XRLabel();
            this.Area4 = new DevExpress.XtraReports.UI.ReportFooterBand();
            this.Section4 = new DevExpress.XtraReports.UI.SubBand();
            this.GrandTotalBalance1 = new DevExpress.XtraReports.UI.XRLabel();
            this.Text18 = new DevExpress.XtraReports.UI.XRLabel();
            this.GrandTotalDelinquentCount1 = new DevExpress.XtraReports.UI.XRLabel();
            this.ReportFooterSection1 = new DevExpress.XtraReports.UI.SubBand();
            this.Text5 = new DevExpress.XtraReports.UI.XRLabel();
            this.PageNofM1 = new DevExpress.XtraReports.UI.XRPageInfo();
            this.gsUserName_1 = new DevExpress.XtraReports.UI.XRLabel();
            this.gsUserID_1 = new DevExpress.XtraReports.UI.XRLabel();
            this.DataTime1 = new DevExpress.XtraReports.UI.XRPageInfo();
            this.DataDate1 = new DevExpress.XtraReports.UI.XRPageInfo();
            this.PageFooterArea1 = new DevExpress.XtraReports.UI.PageFooterBand();
            this.NewDealerNumber = new DevExpress.XtraReports.UI.CalculatedField();
            this.gsUserName = new DevExpress.XtraReports.Parameters.Parameter();
            this.gsUserID = new DevExpress.XtraReports.Parameters.Parameter();
            this.gnAgedMonths = new DevExpress.XtraReports.Parameters.Parameter();
            this.gdCurrentDate = new DevExpress.XtraReports.Parameters.Parameter();
            this.sqlDataSource1 = new DevExpress.DataAccess.Sql.SqlDataSource(this.components);
            this.topMarginBand1 = new DevExpress.XtraReports.UI.TopMarginBand();
            this.bottomMarginBand1 = new DevExpress.XtraReports.UI.BottomMarginBand();
            ((System.ComponentModel.ISupportInitialize)(this)).BeginInit();
            // 
            // Area3
            // 
            this.Area3.HeightF = 0F;
            this.Area3.KeepTogether = true;
            this.Area3.Name = "Area3";
            this.Area3.Padding = new DevExpress.XtraPrinting.PaddingInfo(0, 0, 0, 0, 100F);
            this.Area3.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopLeft;
            this.Area3.Visible = false;
            // 
            // GroupHeaderArea2
            // 
            this.GroupHeaderArea2.GroupFields.AddRange(new DevExpress.XtraReports.UI.GroupField[] {
            new DevExpress.XtraReports.UI.GroupField("CUSTOMER_DEALER", DevExpress.XtraReports.UI.XRColumnSortOrder.Ascending)});
            this.GroupHeaderArea2.HeightF = 0F;
            this.GroupHeaderArea2.KeepTogether = true;
            this.GroupHeaderArea2.Name = "GroupHeaderArea2";
            this.GroupHeaderArea2.Padding = new DevExpress.XtraPrinting.PaddingInfo(0, 0, 0, 0, 100F);
            this.GroupHeaderArea2.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopLeft;
            this.GroupHeaderArea2.Visible = false;
            // 
            // GroupHeaderArea1
            // 
            this.GroupHeaderArea1.Controls.AddRange(new DevExpress.XtraReports.UI.XRControl[] {
            this.xrLabel1});
            this.GroupHeaderArea1.GroupFields.AddRange(new DevExpress.XtraReports.UI.GroupField[] {
            new DevExpress.XtraReports.UI.GroupField("CUSTOMERDEALER.DEALER_ST", DevExpress.XtraReports.UI.XRColumnSortOrder.Ascending)});
            this.GroupHeaderArea1.HeightF = 22.77781F;
            this.GroupHeaderArea1.KeepTogether = true;
            this.GroupHeaderArea1.Level = 1;
            this.GroupHeaderArea1.Name = "GroupHeaderArea1";
            this.GroupHeaderArea1.Padding = new DevExpress.XtraPrinting.PaddingInfo(0, 0, 0, 0, 100F);
            this.GroupHeaderArea1.RepeatEveryPage = true;
            this.GroupHeaderArea1.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopLeft;
            // 
            // xrLabel1
            // 
            this.xrLabel1.BackColor = System.Drawing.Color.Transparent;
            this.xrLabel1.BorderColor = System.Drawing.Color.Black;
            this.xrLabel1.Borders = DevExpress.XtraPrinting.BorderSide.None;
            this.xrLabel1.BorderWidth = 1F;
            this.xrLabel1.CanGrow = false;
            this.xrLabel1.ExpressionBindings.AddRange(new DevExpress.XtraReports.UI.ExpressionBinding[] {
            new DevExpress.XtraReports.UI.ExpressionBinding("BeforePrint", "Text", "\'State: \' + [CUSTOMERDEALER].[DEALER_ST]")});
            this.xrLabel1.Font = new DevExpress.Drawing.DXFont("Arial", 10F, DevExpress.Drawing.DXFontStyle.Bold);
            this.xrLabel1.ForeColor = System.Drawing.Color.Black;
            this.xrLabel1.LocationFloat = new DevExpress.Utils.PointFloat(0F, 1.180553F);
            this.xrLabel1.Name = "xrLabel1";
            this.xrLabel1.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabel1.SizeF = new System.Drawing.SizeF(259.375F, 15.34722F);
            this.xrLabel1.StylePriority.UseFont = false;
            this.xrLabel1.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopLeft;
            // 
            // GroupFooterArea1
            // 
            this.GroupFooterArea1.Controls.AddRange(new DevExpress.XtraReports.UI.XRControl[] {
            this.TotalBalanceByDealer1,
            this.TotalDelinquentsByDealer1,
            this.NewDealerNumber_1});
            this.GroupFooterArea1.HeightF = 18.33333F;
            this.GroupFooterArea1.Name = "GroupFooterArea1";
            this.GroupFooterArea1.Padding = new DevExpress.XtraPrinting.PaddingInfo(0, 0, 0, 0, 100F);
            this.GroupFooterArea1.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopLeft;
            // 
            // TotalBalanceByDealer1
            // 
            this.TotalBalanceByDealer1.BackColor = System.Drawing.Color.Transparent;
            this.TotalBalanceByDealer1.BorderColor = System.Drawing.Color.Black;
            this.TotalBalanceByDealer1.Borders = DevExpress.XtraPrinting.BorderSide.None;
            this.TotalBalanceByDealer1.BorderWidth = 1F;
            this.TotalBalanceByDealer1.CanGrow = false;
            this.TotalBalanceByDealer1.ExpressionBindings.AddRange(new DevExpress.XtraReports.UI.ExpressionBinding[] {
            new DevExpress.XtraReports.UI.ExpressionBinding("BeforePrint", "Text", "sumSum([CUSTOMER_BALANCE])")});
            this.TotalBalanceByDealer1.Font = new DevExpress.Drawing.DXFont("Arial", 10F, DevExpress.Drawing.DXFontStyle.Bold);
            this.TotalBalanceByDealer1.ForeColor = System.Drawing.Color.Black;
            this.TotalBalanceByDealer1.LocationFloat = new DevExpress.Utils.PointFloat(920.8333F, 0F);
            this.TotalBalanceByDealer1.Name = "TotalBalanceByDealer1";
            this.TotalBalanceByDealer1.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.TotalBalanceByDealer1.SizeF = new System.Drawing.SizeF(113.6806F, 18.33333F);
            xrSummary1.Running = DevExpress.XtraReports.UI.SummaryRunning.Group;
            this.TotalBalanceByDealer1.Summary = xrSummary1;
            this.TotalBalanceByDealer1.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopRight;
            this.TotalBalanceByDealer1.TextFormatString = "{0:C2}";
            // 
            // TotalDelinquentsByDealer1
            // 
            this.TotalDelinquentsByDealer1.BackColor = System.Drawing.Color.Transparent;
            this.TotalDelinquentsByDealer1.BorderColor = System.Drawing.Color.Black;
            this.TotalDelinquentsByDealer1.Borders = DevExpress.XtraPrinting.BorderSide.None;
            this.TotalDelinquentsByDealer1.BorderWidth = 1F;
            this.TotalDelinquentsByDealer1.CanGrow = false;
            this.TotalDelinquentsByDealer1.ExpressionBindings.AddRange(new DevExpress.XtraReports.UI.ExpressionBinding[] {
            new DevExpress.XtraReports.UI.ExpressionBinding("BeforePrint", "Text", "sumCount([CUSTOMER_NO])")});
            this.TotalDelinquentsByDealer1.Font = new DevExpress.Drawing.DXFont("Arial", 10F, DevExpress.Drawing.DXFontStyle.Bold);
            this.TotalDelinquentsByDealer1.ForeColor = System.Drawing.Color.Black;
            this.TotalDelinquentsByDealer1.LocationFloat = new DevExpress.Utils.PointFloat(758.3333F, 0F);
            this.TotalDelinquentsByDealer1.Name = "TotalDelinquentsByDealer1";
            this.TotalDelinquentsByDealer1.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.TotalDelinquentsByDealer1.SizeF = new System.Drawing.SizeF(61.45833F, 18.33333F);
            xrSummary2.Running = DevExpress.XtraReports.UI.SummaryRunning.Group;
            this.TotalDelinquentsByDealer1.Summary = xrSummary2;
            this.TotalDelinquentsByDealer1.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopRight;
            this.TotalDelinquentsByDealer1.TextFormatString = "{0:#}";
            // 
            // NewDealerNumber_1
            // 
            this.NewDealerNumber_1.BackColor = System.Drawing.Color.Transparent;
            this.NewDealerNumber_1.BorderColor = System.Drawing.Color.Black;
            this.NewDealerNumber_1.Borders = DevExpress.XtraPrinting.BorderSide.None;
            this.NewDealerNumber_1.BorderWidth = 1F;
            this.NewDealerNumber_1.CanGrow = false;
            this.NewDealerNumber_1.ExpressionBindings.AddRange(new DevExpress.XtraReports.UI.ExpressionBinding[] {
            new DevExpress.XtraReports.UI.ExpressionBinding("BeforePrint", "Text", "[CUSTOMERDEALER].[NewDealerNumber]")});
            this.NewDealerNumber_1.Font = new DevExpress.Drawing.DXFont("Arial", 10F, DevExpress.Drawing.DXFontStyle.Bold);
            this.NewDealerNumber_1.ForeColor = System.Drawing.Color.Black;
            this.NewDealerNumber_1.LocationFloat = new DevExpress.Utils.PointFloat(10.00001F, 0F);
            this.NewDealerNumber_1.Name = "NewDealerNumber_1";
            this.NewDealerNumber_1.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.NewDealerNumber_1.SizeF = new System.Drawing.SizeF(657.2917F, 18.33333F);
            this.NewDealerNumber_1.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopLeft;
            // 
            // GroupFooterArea2
            // 
            this.GroupFooterArea2.Controls.AddRange(new DevExpress.XtraReports.UI.XRControl[] {
            this.GroupNameDEALERST1,
            this.TotalBalanceByDealerState1,
            this.TotalDelinquentsByDealerState1});
            this.GroupFooterArea2.HeightF = 33F;
            this.GroupFooterArea2.KeepTogether = true;
            this.GroupFooterArea2.Level = 1;
            this.GroupFooterArea2.Name = "GroupFooterArea2";
            this.GroupFooterArea2.Padding = new DevExpress.XtraPrinting.PaddingInfo(0, 0, 0, 0, 100F);
            this.GroupFooterArea2.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopLeft;
            // 
            // GroupNameDEALERST1
            // 
            this.GroupNameDEALERST1.BackColor = System.Drawing.Color.Transparent;
            this.GroupNameDEALERST1.BorderColor = System.Drawing.Color.Black;
            this.GroupNameDEALERST1.Borders = DevExpress.XtraPrinting.BorderSide.None;
            this.GroupNameDEALERST1.BorderWidth = 1F;
            this.GroupNameDEALERST1.CanGrow = false;
            this.GroupNameDEALERST1.ExpressionBindings.AddRange(new DevExpress.XtraReports.UI.ExpressionBinding[] {
            new DevExpress.XtraReports.UI.ExpressionBinding("BeforePrint", "Text", "\'TOTALS STATE OF: \' + [CUSTOMERDEALER].[DEALER_ST]")});
            this.GroupNameDEALERST1.Font = new DevExpress.Drawing.DXFont("Arial", 10F, DevExpress.Drawing.DXFontStyle.Bold);
            this.GroupNameDEALERST1.ForeColor = System.Drawing.Color.Black;
            this.GroupNameDEALERST1.LocationFloat = new DevExpress.Utils.PointFloat(0F, 0F);
            this.GroupNameDEALERST1.Name = "GroupNameDEALERST1";
            this.GroupNameDEALERST1.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.GroupNameDEALERST1.SizeF = new System.Drawing.SizeF(657.2917F, 18.33333F);
            this.GroupNameDEALERST1.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopLeft;
            // 
            // TotalBalanceByDealerState1
            // 
            this.TotalBalanceByDealerState1.BackColor = System.Drawing.Color.Transparent;
            this.TotalBalanceByDealerState1.BorderColor = System.Drawing.Color.Black;
            this.TotalBalanceByDealerState1.Borders = DevExpress.XtraPrinting.BorderSide.None;
            this.TotalBalanceByDealerState1.BorderWidth = 1F;
            this.TotalBalanceByDealerState1.CanGrow = false;
            this.TotalBalanceByDealerState1.ExpressionBindings.AddRange(new DevExpress.XtraReports.UI.ExpressionBinding[] {
            new DevExpress.XtraReports.UI.ExpressionBinding("BeforePrint", "Text", "sumSum([CUSTOMER_BALANCE])")});
            this.TotalBalanceByDealerState1.Font = new DevExpress.Drawing.DXFont("Arial", 10F, DevExpress.Drawing.DXFontStyle.Bold);
            this.TotalBalanceByDealerState1.ForeColor = System.Drawing.Color.Black;
            this.TotalBalanceByDealerState1.LocationFloat = new DevExpress.Utils.PointFloat(920.8333F, 0F);
            this.TotalBalanceByDealerState1.Name = "TotalBalanceByDealerState1";
            this.TotalBalanceByDealerState1.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.TotalBalanceByDealerState1.SizeF = new System.Drawing.SizeF(113.6806F, 18.33333F);
            xrSummary3.Running = DevExpress.XtraReports.UI.SummaryRunning.Group;
            this.TotalBalanceByDealerState1.Summary = xrSummary3;
            this.TotalBalanceByDealerState1.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopRight;
            this.TotalBalanceByDealerState1.TextFormatString = "{0:C2}";
            // 
            // TotalDelinquentsByDealerState1
            // 
            this.TotalDelinquentsByDealerState1.BackColor = System.Drawing.Color.Transparent;
            this.TotalDelinquentsByDealerState1.BorderColor = System.Drawing.Color.Black;
            this.TotalDelinquentsByDealerState1.Borders = DevExpress.XtraPrinting.BorderSide.None;
            this.TotalDelinquentsByDealerState1.BorderWidth = 1F;
            this.TotalDelinquentsByDealerState1.CanGrow = false;
            this.TotalDelinquentsByDealerState1.ExpressionBindings.AddRange(new DevExpress.XtraReports.UI.ExpressionBinding[] {
            new DevExpress.XtraReports.UI.ExpressionBinding("BeforePrint", "Text", "sumCount([CUSTOMER_NO])")});
            this.TotalDelinquentsByDealerState1.Font = new DevExpress.Drawing.DXFont("Arial", 10F, DevExpress.Drawing.DXFontStyle.Bold);
            this.TotalDelinquentsByDealerState1.ForeColor = System.Drawing.Color.Black;
            this.TotalDelinquentsByDealerState1.LocationFloat = new DevExpress.Utils.PointFloat(758.3333F, 0F);
            this.TotalDelinquentsByDealerState1.Name = "TotalDelinquentsByDealerState1";
            this.TotalDelinquentsByDealerState1.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.TotalDelinquentsByDealerState1.SizeF = new System.Drawing.SizeF(61.45833F, 18.33333F);
            xrSummary4.Running = DevExpress.XtraReports.UI.SummaryRunning.Group;
            this.TotalDelinquentsByDealerState1.Summary = xrSummary4;
            this.TotalDelinquentsByDealerState1.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopRight;
            this.TotalDelinquentsByDealerState1.TextFormatString = "{0:#}";
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
            this.Section1.Visible = false;
            // 
            // ReportHeaderSection1
            // 
            this.ReportHeaderSection1.HeightF = 0F;
            this.ReportHeaderSection1.KeepTogether = true;
            this.ReportHeaderSection1.Name = "ReportHeaderSection1";
            this.ReportHeaderSection1.Padding = new DevExpress.XtraPrinting.PaddingInfo(0, 0, 0, 0, 100F);
            this.ReportHeaderSection1.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopLeft;
            this.ReportHeaderSection1.Visible = false;
            // 
            // PageHeaderArea1
            // 
            this.PageHeaderArea1.Controls.AddRange(new DevExpress.XtraReports.UI.XRControl[] {
            this.Picture2,
            this.AgedTitle_2,
            this.Text28,
            this.Text27,
            this.gdCurrentDate2,
            this.Text26,
            this.Text24,
            this.Line3,
            this.Text23});
            this.PageHeaderArea1.HeightF = 230.7639F;
            this.PageHeaderArea1.Name = "PageHeaderArea1";
            this.PageHeaderArea1.Padding = new DevExpress.XtraPrinting.PaddingInfo(0, 0, 0, 0, 100F);
            this.PageHeaderArea1.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopLeft;
            // 
            // Picture2
            // 
            this.Picture2.BackColor = System.Drawing.Color.Transparent;
            this.Picture2.BorderColor = System.Drawing.Color.Black;
            this.Picture2.Borders = DevExpress.XtraPrinting.BorderSide.None;
            this.Picture2.BorderWidth = 1F;
            this.Picture2.Font = new DevExpress.Drawing.DXFont("Times New Roman", 9.75F);
            this.Picture2.ForeColor = System.Drawing.Color.Black;
            this.Picture2.ImageSource = new DevExpress.XtraPrinting.Drawing.ImageSource("img", resources.GetString("Picture2.ImageSource"));
            this.Picture2.LocationFloat = new DevExpress.Utils.PointFloat(803.6111F, 0.25F);
            this.Picture2.Name = "Picture2";
            this.Picture2.Padding = new DevExpress.XtraPrinting.PaddingInfo(0, 0, 0, 0, 100F);
            this.Picture2.SizeF = new System.Drawing.SizeF(246.3889F, 95F);
            // 
            // AgedTitle_2
            // 
            this.AgedTitle_2.BackColor = System.Drawing.Color.Transparent;
            this.AgedTitle_2.BorderColor = System.Drawing.Color.Black;
            this.AgedTitle_2.Borders = DevExpress.XtraPrinting.BorderSide.None;
            this.AgedTitle_2.BorderWidth = 1F;
            this.AgedTitle_2.CanGrow = false;
            this.AgedTitle_2.ExpressionBindings.AddRange(new DevExpress.XtraReports.UI.ExpressionBinding[] {
            new DevExpress.XtraReports.UI.ExpressionBinding("BeforePrint", "Text", "[AgedTitle]")});
            this.AgedTitle_2.Font = new DevExpress.Drawing.DXFont("Segoe UI", 14F, DevExpress.Drawing.DXFontStyle.Bold);
            this.AgedTitle_2.ForeColor = System.Drawing.Color.Black;
            this.AgedTitle_2.LocationFloat = new DevExpress.Utils.PointFloat(0F, 125.25F);
            this.AgedTitle_2.Name = "AgedTitle_2";
            this.AgedTitle_2.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.AgedTitle_2.SizeF = new System.Drawing.SizeF(1050F, 25F);
            this.AgedTitle_2.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopCenter;
            // 
            // Text28
            // 
            this.Text28.BackColor = System.Drawing.Color.Transparent;
            this.Text28.BorderColor = System.Drawing.Color.Black;
            this.Text28.Borders = DevExpress.XtraPrinting.BorderSide.None;
            this.Text28.BorderWidth = 1F;
            this.Text28.CanGrow = false;
            this.Text28.Font = new DevExpress.Drawing.DXFont("Arial", 8F, DevExpress.Drawing.DXFontStyle.Bold);
            this.Text28.ForeColor = System.Drawing.Color.Black;
            this.Text28.LocationFloat = new DevExpress.Utils.PointFloat(758.3332F, 200.25F);
            this.Text28.Name = "Text28";
            this.Text28.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.Text28.SizeF = new System.Drawing.SizeF(133.3333F, 18.26389F);
            this.Text28.StylePriority.UseTextAlignment = false;
            this.Text28.Text = "# OF DELINQUENCIES";
            this.Text28.TextAlignment = DevExpress.XtraPrinting.TextAlignment.BottomLeft;
            // 
            // Text27
            // 
            this.Text27.BackColor = System.Drawing.Color.Transparent;
            this.Text27.BorderColor = System.Drawing.Color.Black;
            this.Text27.Borders = DevExpress.XtraPrinting.BorderSide.None;
            this.Text27.BorderWidth = 1F;
            this.Text27.CanGrow = false;
            this.Text27.Font = new DevExpress.Drawing.DXFont("Arial", 10F, DevExpress.Drawing.DXFontStyle.Bold);
            this.Text27.ForeColor = System.Drawing.Color.Black;
            this.Text27.LocationFloat = new DevExpress.Utils.PointFloat(449.9999F, 166.9167F);
            this.Text27.Name = "Text27";
            this.Text27.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.Text27.SizeF = new System.Drawing.SizeF(75F, 15.34722F);
            this.Text27.Text = "RUN DATE:";
            this.Text27.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopLeft;
            // 
            // gdCurrentDate2
            // 
            this.gdCurrentDate2.BackColor = System.Drawing.Color.Transparent;
            this.gdCurrentDate2.BorderColor = System.Drawing.Color.Black;
            this.gdCurrentDate2.Borders = DevExpress.XtraPrinting.BorderSide.None;
            this.gdCurrentDate2.BorderWidth = 1F;
            this.gdCurrentDate2.CanGrow = false;
            this.gdCurrentDate2.ExpressionBindings.AddRange(new DevExpress.XtraReports.UI.ExpressionBinding[] {
            new DevExpress.XtraReports.UI.ExpressionBinding("BeforePrint", "Text", "?gdCurrentDate")});
            this.gdCurrentDate2.Font = new DevExpress.Drawing.DXFont("Arial", 10F);
            this.gdCurrentDate2.ForeColor = System.Drawing.Color.Black;
            this.gdCurrentDate2.LocationFloat = new DevExpress.Utils.PointFloat(533.3332F, 166.9167F);
            this.gdCurrentDate2.Name = "gdCurrentDate2";
            this.gdCurrentDate2.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.gdCurrentDate2.SizeF = new System.Drawing.SizeF(75F, 15.34722F);
            this.gdCurrentDate2.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopLeft;
            this.gdCurrentDate2.TextFormatString = "{0:MM/dd/yyyy}";
            // 
            // Text26
            // 
            this.Text26.BackColor = System.Drawing.Color.Transparent;
            this.Text26.BorderColor = System.Drawing.Color.Black;
            this.Text26.Borders = DevExpress.XtraPrinting.BorderSide.None;
            this.Text26.BorderWidth = 1F;
            this.Text26.CanGrow = false;
            this.Text26.Font = new DevExpress.Drawing.DXFont("Segoe UI", 14F, DevExpress.Drawing.DXFontStyle.Bold);
            this.Text26.ForeColor = System.Drawing.Color.Black;
            this.Text26.LocationFloat = new DevExpress.Utils.PointFloat(0F, 100.25F);
            this.Text26.Name = "Text26";
            this.Text26.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.Text26.SizeF = new System.Drawing.SizeF(1050F, 25F);
            this.Text26.Text = "CLOSED CUSTOMER DELINQUENCY DEALER SUMMARY REPORT";
            this.Text26.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopCenter;
            // 
            // Text24
            // 
            this.Text24.BackColor = System.Drawing.Color.Transparent;
            this.Text24.BorderColor = System.Drawing.Color.Black;
            this.Text24.Borders = DevExpress.XtraPrinting.BorderSide.None;
            this.Text24.BorderWidth = 1F;
            this.Text24.CanGrow = false;
            this.Text24.Font = new DevExpress.Drawing.DXFont("Arial", 8F, DevExpress.Drawing.DXFontStyle.Bold);
            this.Text24.ForeColor = System.Drawing.Color.Black;
            this.Text24.LocationFloat = new DevExpress.Utils.PointFloat(924.9999F, 200.25F);
            this.Text24.Name = "Text24";
            this.Text24.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.Text24.SizeF = new System.Drawing.SizeF(95.83325F, 18.26389F);
            this.Text24.StylePriority.UseTextAlignment = false;
            this.Text24.Text = "LOAN BALANCE";
            this.Text24.TextAlignment = DevExpress.XtraPrinting.TextAlignment.BottomLeft;
            // 
            // Line3
            // 
            this.Line3.BackColor = System.Drawing.Color.Transparent;
            this.Line3.BorderColor = System.Drawing.Color.Navy;
            this.Line3.Borders = DevExpress.XtraPrinting.BorderSide.Top;
            this.Line3.BorderWidth = 1F;
            this.Line3.Font = new DevExpress.Drawing.DXFont("Times New Roman", 9.75F);
            this.Line3.ForeColor = System.Drawing.Color.Navy;
            this.Line3.LineWidth = 3F;
            this.Line3.LocationFloat = new DevExpress.Utils.PointFloat(0F, 224.7639F);
            this.Line3.Name = "Line3";
            this.Line3.Padding = new DevExpress.XtraPrinting.PaddingInfo(0, 0, 0, 0, 100F);
            this.Line3.SizeF = new System.Drawing.SizeF(1050F, 3.125F);
            // 
            // Text23
            // 
            this.Text23.BackColor = System.Drawing.Color.Transparent;
            this.Text23.BorderColor = System.Drawing.Color.Black;
            this.Text23.Borders = DevExpress.XtraPrinting.BorderSide.None;
            this.Text23.BorderWidth = 1F;
            this.Text23.CanGrow = false;
            this.Text23.Font = new DevExpress.Drawing.DXFont("Arial", 8F, DevExpress.Drawing.DXFontStyle.Bold);
            this.Text23.ForeColor = System.Drawing.Color.Black;
            this.Text23.LocationFloat = new DevExpress.Utils.PointFloat(8.333273F, 200.25F);
            this.Text23.Name = "Text23";
            this.Text23.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.Text23.SizeF = new System.Drawing.SizeF(60.41667F, 18.26389F);
            this.Text23.StylePriority.UseTextAlignment = false;
            this.Text23.Text = "DEALER";
            this.Text23.TextAlignment = DevExpress.XtraPrinting.TextAlignment.BottomLeft;
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
            this.GrandTotalBalance1,
            this.Text18,
            this.GrandTotalDelinquentCount1});
            this.Section4.HeightF = 26F;
            this.Section4.KeepTogether = true;
            this.Section4.Name = "Section4";
            this.Section4.Padding = new DevExpress.XtraPrinting.PaddingInfo(0, 0, 0, 0, 100F);
            this.Section4.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopLeft;
            // 
            // GrandTotalBalance1
            // 
            this.GrandTotalBalance1.BackColor = System.Drawing.Color.Transparent;
            this.GrandTotalBalance1.BorderColor = System.Drawing.Color.Black;
            this.GrandTotalBalance1.Borders = DevExpress.XtraPrinting.BorderSide.None;
            this.GrandTotalBalance1.BorderWidth = 1F;
            this.GrandTotalBalance1.CanGrow = false;
            this.GrandTotalBalance1.ExpressionBindings.AddRange(new DevExpress.XtraReports.UI.ExpressionBinding[] {
            new DevExpress.XtraReports.UI.ExpressionBinding("BeforePrint", "Text", "sumSum([CUSTOMER_BALANCE])")});
            this.GrandTotalBalance1.Font = new DevExpress.Drawing.DXFont("Arial", 10F, DevExpress.Drawing.DXFontStyle.Bold);
            this.GrandTotalBalance1.ForeColor = System.Drawing.Color.Black;
            this.GrandTotalBalance1.LocationFloat = new DevExpress.Utils.PointFloat(920.8333F, 8.333333F);
            this.GrandTotalBalance1.Name = "GrandTotalBalance1";
            this.GrandTotalBalance1.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.GrandTotalBalance1.SizeF = new System.Drawing.SizeF(113.6806F, 18.33333F);
            xrSummary5.Running = DevExpress.XtraReports.UI.SummaryRunning.Report;
            this.GrandTotalBalance1.Summary = xrSummary5;
            this.GrandTotalBalance1.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopRight;
            this.GrandTotalBalance1.TextFormatString = "{0:C2}";
            // 
            // Text18
            // 
            this.Text18.BackColor = System.Drawing.Color.Transparent;
            this.Text18.BorderColor = System.Drawing.Color.Black;
            this.Text18.Borders = DevExpress.XtraPrinting.BorderSide.None;
            this.Text18.BorderWidth = 1F;
            this.Text18.CanGrow = false;
            this.Text18.Font = new DevExpress.Drawing.DXFont("Arial", 10F, DevExpress.Drawing.DXFontStyle.Bold);
            this.Text18.ForeColor = System.Drawing.Color.Black;
            this.Text18.LocationFloat = new DevExpress.Utils.PointFloat(700F, 8.333333F);
            this.Text18.Name = "Text18";
            this.Text18.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.Text18.SizeF = new System.Drawing.SizeF(50F, 15.27778F);
            this.Text18.Text = "Totals:\n";
            this.Text18.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopLeft;
            // 
            // GrandTotalDelinquentCount1
            // 
            this.GrandTotalDelinquentCount1.BackColor = System.Drawing.Color.Transparent;
            this.GrandTotalDelinquentCount1.BorderColor = System.Drawing.Color.Black;
            this.GrandTotalDelinquentCount1.Borders = DevExpress.XtraPrinting.BorderSide.None;
            this.GrandTotalDelinquentCount1.BorderWidth = 1F;
            this.GrandTotalDelinquentCount1.CanGrow = false;
            this.GrandTotalDelinquentCount1.ExpressionBindings.AddRange(new DevExpress.XtraReports.UI.ExpressionBinding[] {
            new DevExpress.XtraReports.UI.ExpressionBinding("BeforePrint", "Text", "sumCount([CUSTOMER_NO])")});
            this.GrandTotalDelinquentCount1.Font = new DevExpress.Drawing.DXFont("Arial", 10F, DevExpress.Drawing.DXFontStyle.Bold);
            this.GrandTotalDelinquentCount1.ForeColor = System.Drawing.Color.Black;
            this.GrandTotalDelinquentCount1.LocationFloat = new DevExpress.Utils.PointFloat(758.3333F, 8.333333F);
            this.GrandTotalDelinquentCount1.Name = "GrandTotalDelinquentCount1";
            this.GrandTotalDelinquentCount1.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.GrandTotalDelinquentCount1.SizeF = new System.Drawing.SizeF(61.45833F, 15.34722F);
            xrSummary6.Running = DevExpress.XtraReports.UI.SummaryRunning.Report;
            this.GrandTotalDelinquentCount1.Summary = xrSummary6;
            this.GrandTotalDelinquentCount1.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopRight;
            this.GrandTotalDelinquentCount1.TextFormatString = "{0:#}";
            // 
            // ReportFooterSection1
            // 
            this.ReportFooterSection1.HeightF = 0F;
            this.ReportFooterSection1.KeepTogether = true;
            this.ReportFooterSection1.Name = "ReportFooterSection1";
            this.ReportFooterSection1.Padding = new DevExpress.XtraPrinting.PaddingInfo(0, 0, 0, 0, 100F);
            this.ReportFooterSection1.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopLeft;
            this.ReportFooterSection1.Visible = false;
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
            this.Text5.LocationFloat = new DevExpress.Utils.PointFloat(199.9999F, 0F);
            this.Text5.Name = "Text5";
            this.Text5.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.Text5.SizeF = new System.Drawing.SizeF(50F, 18.33333F);
            this.Text5.Text = "USER:";
            this.Text5.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopLeft;
            // 
            // PageNofM1
            // 
            this.PageNofM1.BackColor = System.Drawing.Color.Transparent;
            this.PageNofM1.BorderColor = System.Drawing.Color.Black;
            this.PageNofM1.Borders = DevExpress.XtraPrinting.BorderSide.None;
            this.PageNofM1.BorderWidth = 1F;
            this.PageNofM1.Font = new DevExpress.Drawing.DXFont("Arial", 10F);
            this.PageNofM1.ForeColor = System.Drawing.Color.Black;
            this.PageNofM1.LocationFloat = new DevExpress.Utils.PointFloat(875F, 0F);
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
            this.gsUserName_1.LocationFloat = new DevExpress.Utils.PointFloat(291.6666F, 0F);
            this.gsUserName_1.Name = "gsUserName_1";
            this.gsUserName_1.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.gsUserName_1.SizeF = new System.Drawing.SizeF(158.3333F, 18.33333F);
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
            this.gsUserID_1.LocationFloat = new DevExpress.Utils.PointFloat(249.9999F, 0F);
            this.gsUserID_1.Name = "gsUserID_1";
            this.gsUserID_1.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.gsUserID_1.SizeF = new System.Drawing.SizeF(41.66669F, 18.33333F);
            this.gsUserID_1.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopLeft;
            // 
            // DataTime1
            // 
            this.DataTime1.BackColor = System.Drawing.Color.Transparent;
            this.DataTime1.BorderColor = System.Drawing.Color.Black;
            this.DataTime1.Borders = DevExpress.XtraPrinting.BorderSide.None;
            this.DataTime1.BorderWidth = 1F;
            this.DataTime1.Font = new DevExpress.Drawing.DXFont("Arial", 10F);
            this.DataTime1.ForeColor = System.Drawing.Color.Black;
            this.DataTime1.LocationFloat = new DevExpress.Utils.PointFloat(91.6666F, 0F);
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
            this.DataDate1.Font = new DevExpress.Drawing.DXFont("Arial", 10F);
            this.DataDate1.ForeColor = System.Drawing.Color.Black;
            this.DataDate1.LocationFloat = new DevExpress.Utils.PointFloat(0F, 0F);
            this.DataDate1.Name = "DataDate1";
            this.DataDate1.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.DataDate1.PageInfo = DevExpress.XtraPrinting.PageInfo.DateTime;
            this.DataDate1.SizeF = new System.Drawing.SizeF(68.75F, 18.33333F);
            this.DataDate1.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopLeft;
            this.DataDate1.TextFormatString = "{0:MM/dd/yyyy}";
            // 
            // PageFooterArea1
            // 
            this.PageFooterArea1.Controls.AddRange(new DevExpress.XtraReports.UI.XRControl[] {
            this.PageNofM1,
            this.gsUserName_1,
            this.gsUserID_1,
            this.Text5,
            this.DataTime1,
            this.DataDate1});
            this.PageFooterArea1.HeightF = 41F;
            this.PageFooterArea1.Name = "PageFooterArea1";
            this.PageFooterArea1.Padding = new DevExpress.XtraPrinting.PaddingInfo(0, 0, 0, 0, 100F);
            this.PageFooterArea1.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopLeft;
            // 
            // NewDealerNumber
            // 
            this.NewDealerNumber.DataMember = "CUSTOMER.CUSTOMERDEALER";
            this.NewDealerNumber.Expression = "[DEALER_ST] + \'-\' + FormatString(\'{0:0}\', ToStr([id])) + \' \' + [DEALER_NAME]";
            this.NewDealerNumber.FieldType = DevExpress.XtraReports.UI.FieldType.String;
            this.NewDealerNumber.Name = "NewDealerNumber";
            // 
            // gsUserName
            // 
            this.gsUserName.Description = "Enter gsUserName:";
            this.gsUserName.Name = "gsUserName";
            // 
            // gsUserID
            // 
            this.gsUserID.Description = "Enter gsUserID:";
            this.gsUserID.Name = "gsUserID";
            // 
            // gnAgedMonths
            // 
            this.gnAgedMonths.Description = "Enter gnAgedMonths:";
            this.gnAgedMonths.Name = "gnAgedMonths";
            this.gnAgedMonths.Type = typeof(double);
            // 
            // gdCurrentDate
            // 
            this.gdCurrentDate.Description = "Enter gdCurrentDate:";
            this.gdCurrentDate.Name = "gdCurrentDate";
            this.gdCurrentDate.Type = typeof(System.DateTime);
            // 
            // sqlDataSource1
            // 
            this.sqlDataSource1.ConnectionName = "IAC2021SQL.Properties.Settings.IAC2010SQLConnectionString";
            this.sqlDataSource1.Name = "sqlDataSource1";
            storedProcQuery1.MetaSerializable = "<Meta X=\"478\" Y=\"20\" Width=\"240\" Height=\"3621\" />";
            storedProcQuery1.Name = "CUSTOMER";
            queryParameter1.Name = "@AgedPeriod";
            queryParameter1.Type = typeof(int);
            queryParameter1.ValueInfo = "1";
            queryParameter2.Name = "@RunDate";
            queryParameter2.Type = typeof(System.DateTime);
            queryParameter2.ValueInfo = "2022-04-27";
            queryParameter3.Name = "@SortMethod";
            queryParameter3.Type = typeof(char);
            storedProcQuery1.Parameters.AddRange(new DevExpress.DataAccess.Sql.QueryParameter[] {
            queryParameter1,
            queryParameter2,
            queryParameter3});
            storedProcQuery1.StoredProcName = "ClosedCustomerDelinquencies";
            storedProcQuery2.MetaSerializable = "<Meta X=\"738\" Y=\"20\" Width=\"159\" Height=\"861\" />";
            storedProcQuery2.Name = "DEALER";
            queryParameter4.Name = "@AgedPeriod";
            queryParameter4.Type = typeof(int);
            queryParameter4.ValueInfo = "1";
            queryParameter5.Name = "@RunDate";
            queryParameter5.Type = typeof(System.DateTime);
            queryParameter5.ValueInfo = "2022-04-27";
            storedProcQuery2.Parameters.AddRange(new DevExpress.DataAccess.Sql.QueryParameter[] {
            queryParameter4,
            queryParameter5});
            storedProcQuery2.StoredProcName = "ClosedDealersByDelinquencies";
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
            // XtraReportClosedDelinquencySummarySubreport
            // 
            this.Bands.AddRange(new DevExpress.XtraReports.UI.Band[] {
            this.Area3,
            this.GroupHeaderArea2,
            this.GroupHeaderArea1,
            this.GroupFooterArea1,
            this.GroupFooterArea2,
            this.Area1,
            this.PageHeaderArea1,
            this.Area4,
            this.PageFooterArea1,
            this.topMarginBand1,
            this.bottomMarginBand1});
            this.CalculatedFields.AddRange(new DevExpress.XtraReports.UI.CalculatedField[] {
            this.NewDealerNumber});
            this.ComponentStorage.AddRange(new System.ComponentModel.IComponent[] {
            this.sqlDataSource1});
            this.DataMember = "CUSTOMER";
            this.DataSource = this.sqlDataSource1;
            this.Landscape = true;
            this.Margins = new DevExpress.Drawing.DXMargins(25, 25, 25, 25);
            this.PageHeight = 850;
            this.PageWidth = 1100;
            this.Parameters.AddRange(new DevExpress.XtraReports.Parameters.Parameter[] {
            this.gsUserName,
            this.gsUserID,
            this.gnAgedMonths,
            this.gdCurrentDate});
            this.Version = "21.2";
            ((System.ComponentModel.ISupportInitialize)(this)).EndInit();

        }

        #endregion

        private DevExpress.XtraReports.UI.DetailBand Area3;
        private DevExpress.XtraReports.UI.GroupHeaderBand GroupHeaderArea2;
        private DevExpress.XtraReports.UI.GroupHeaderBand GroupHeaderArea1;
        private DevExpress.XtraReports.UI.GroupFooterBand GroupFooterArea1;
        private DevExpress.XtraReports.UI.XRLabel TotalBalanceByDealer1;
        private DevExpress.XtraReports.UI.XRLabel TotalDelinquentsByDealer1;
        private DevExpress.XtraReports.UI.XRLabel NewDealerNumber_1;
        private DevExpress.XtraReports.UI.GroupFooterBand GroupFooterArea2;
        private DevExpress.XtraReports.UI.XRLabel GroupNameDEALERST1;
        private DevExpress.XtraReports.UI.XRLabel TotalBalanceByDealerState1;
        private DevExpress.XtraReports.UI.XRLabel TotalDelinquentsByDealerState1;
        private DevExpress.XtraReports.UI.ReportHeaderBand Area1;
        private DevExpress.XtraReports.UI.SubBand Section1;
        private DevExpress.XtraReports.UI.SubBand ReportHeaderSection1;
        private DevExpress.XtraReports.UI.PageHeaderBand PageHeaderArea1;
        private DevExpress.XtraReports.UI.ReportFooterBand Area4;
        private DevExpress.XtraReports.UI.SubBand Section4;
        private DevExpress.XtraReports.UI.XRLabel GrandTotalBalance1;
        private DevExpress.XtraReports.UI.XRLabel Text18;
        private DevExpress.XtraReports.UI.XRLabel GrandTotalDelinquentCount1;
        private DevExpress.XtraReports.UI.SubBand ReportFooterSection1;
        private DevExpress.XtraReports.UI.XRLabel Text5;
        private DevExpress.XtraReports.UI.XRPageInfo PageNofM1;
        private DevExpress.XtraReports.UI.XRLabel gsUserName_1;
        private DevExpress.XtraReports.UI.XRLabel gsUserID_1;
        private DevExpress.XtraReports.UI.XRPageInfo DataTime1;
        private DevExpress.XtraReports.UI.XRPageInfo DataDate1;
        private DevExpress.XtraReports.UI.PageFooterBand PageFooterArea1;
        private DevExpress.XtraReports.UI.CalculatedField NewDealerNumber;
        private DevExpress.XtraReports.Parameters.Parameter gsUserName;
        private DevExpress.XtraReports.Parameters.Parameter gsUserID;
        private DevExpress.XtraReports.Parameters.Parameter gnAgedMonths;
        private DevExpress.XtraReports.Parameters.Parameter gdCurrentDate;
        private DevExpress.DataAccess.Sql.SqlDataSource sqlDataSource1;
        private DevExpress.XtraReports.UI.TopMarginBand topMarginBand1;
        private DevExpress.XtraReports.UI.BottomMarginBand bottomMarginBand1;
        private DevExpress.XtraReports.UI.XRPictureBox Picture2;
        private DevExpress.XtraReports.UI.XRLabel AgedTitle_2;
        private DevExpress.XtraReports.UI.XRLabel Text28;
        private DevExpress.XtraReports.UI.XRLabel Text27;
        private DevExpress.XtraReports.UI.XRLabel gdCurrentDate2;
        private DevExpress.XtraReports.UI.XRLabel Text26;
        private DevExpress.XtraReports.UI.XRLabel Text24;
        private DevExpress.XtraReports.UI.XRLine Line3;
        private DevExpress.XtraReports.UI.XRLabel Text23;
        private DevExpress.XtraReports.UI.XRLabel xrLabel1;
    }
}

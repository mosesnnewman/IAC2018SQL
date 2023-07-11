namespace IAC2021SQL
{
    partial class XtraReportClosedCustomerBuybackDealerSummary
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
            DevExpress.DataAccess.Sql.StoredProcQuery storedProcQuery1 = new DevExpress.DataAccess.Sql.StoredProcQuery();
            DevExpress.DataAccess.Sql.QueryParameter queryParameter1 = new DevExpress.DataAccess.Sql.QueryParameter();
            DevExpress.DataAccess.Sql.QueryParameter queryParameter2 = new DevExpress.DataAccess.Sql.QueryParameter();
            DevExpress.DataAccess.Sql.QueryParameter queryParameter3 = new DevExpress.DataAccess.Sql.QueryParameter();
            DevExpress.DataAccess.Sql.QueryParameter queryParameter4 = new DevExpress.DataAccess.Sql.QueryParameter();
            DevExpress.DataAccess.Sql.QueryParameter queryParameter5 = new DevExpress.DataAccess.Sql.QueryParameter();
            DevExpress.DataAccess.Sql.QueryParameter queryParameter6 = new DevExpress.DataAccess.Sql.QueryParameter();
            DevExpress.DataAccess.Sql.QueryParameter queryParameter7 = new DevExpress.DataAccess.Sql.QueryParameter();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(XtraReportClosedCustomerBuybackDealerSummary));
            this.DetailArea1 = new DevExpress.XtraReports.UI.DetailBand();
            this.TotalPayments1 = new DevExpress.XtraReports.UI.XRLabel();
            this.Text4 = new DevExpress.XtraReports.UI.XRLabel();
            this.CodeCount1 = new DevExpress.XtraReports.UI.XRLabel();
            this.Text5 = new DevExpress.XtraReports.UI.XRLabel();
            this.PaymentType2 = new DevExpress.XtraReports.UI.XRLabel();
            this.PaymentCode2 = new DevExpress.XtraReports.UI.XRLabel();
            this.GroupHeaderArea1 = new DevExpress.XtraReports.UI.GroupHeaderBand();
            this.GroupFooterArea1 = new DevExpress.XtraReports.UI.GroupFooterBand();
            this.ReportHeaderArea1 = new DevExpress.XtraReports.UI.ReportHeaderBand();
            this.ReportHeaderSection1 = new DevExpress.XtraReports.UI.SubBand();
            this.ReportHeaderSection2 = new DevExpress.XtraReports.UI.SubBand();
            this.PageHeaderArea1 = new DevExpress.XtraReports.UI.PageHeaderBand();
            this.ReportFooterArea1 = new DevExpress.XtraReports.UI.ReportFooterBand();
            this.ReportFooterSection1 = new DevExpress.XtraReports.UI.SubBand();
            this.SumofTotalPayments2 = new DevExpress.XtraReports.UI.XRLabel();
            this.Text1 = new DevExpress.XtraReports.UI.XRLabel();
            this.SumofCodeCount1 = new DevExpress.XtraReports.UI.XRLabel();
            this.ReportFooterSection2 = new DevExpress.XtraReports.UI.SubBand();
            this.PageFooterArea1 = new DevExpress.XtraReports.UI.PageFooterBand();
            this.gdStartDate = new DevExpress.XtraReports.Parameters.Parameter();
            this.gdEndDate = new DevExpress.XtraReports.Parameters.Parameter();
            this.gsDealer = new DevExpress.XtraReports.Parameters.Parameter();
            this.gsDealerState = new DevExpress.XtraReports.Parameters.Parameter();
            this.gsState = new DevExpress.XtraReports.Parameters.Parameter();
            this.gsType = new DevExpress.XtraReports.Parameters.Parameter();
            this.gsCode = new DevExpress.XtraReports.Parameters.Parameter();
            this.sqlDataSource1 = new DevExpress.DataAccess.Sql.SqlDataSource(this.components);
            this.topMarginBand1 = new DevExpress.XtraReports.UI.TopMarginBand();
            this.bottomMarginBand1 = new DevExpress.XtraReports.UI.BottomMarginBand();
            ((System.ComponentModel.ISupportInitialize)(this)).BeginInit();
            // 
            // DetailArea1
            // 
            this.DetailArea1.Controls.AddRange(new DevExpress.XtraReports.UI.XRControl[] {
            this.TotalPayments1,
            this.Text4,
            this.CodeCount1,
            this.Text5,
            this.PaymentType2,
            this.PaymentCode2});
            this.DetailArea1.HeightF = 15.34722F;
            this.DetailArea1.KeepTogether = true;
            this.DetailArea1.Name = "DetailArea1";
            this.DetailArea1.Padding = new DevExpress.XtraPrinting.PaddingInfo(0, 0, 0, 0, 100F);
            this.DetailArea1.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopLeft;
            // 
            // TotalPayments1
            // 
            this.TotalPayments1.BackColor = System.Drawing.Color.Transparent;
            this.TotalPayments1.BorderColor = System.Drawing.Color.Black;
            this.TotalPayments1.Borders = DevExpress.XtraPrinting.BorderSide.None;
            this.TotalPayments1.BorderWidth = 1F;
            this.TotalPayments1.CanGrow = false;
            this.TotalPayments1.ExpressionBindings.AddRange(new DevExpress.XtraReports.UI.ExpressionBinding[] {
            new DevExpress.XtraReports.UI.ExpressionBinding("BeforePrint", "Text", "[TotalPayments]"),
            new DevExpress.XtraReports.UI.ExpressionBinding("BeforePrint", "Visible", "iif([TotalPayments]<>0, True,False)")});
            this.TotalPayments1.Font = new DevExpress.Drawing.DXFont("Arial", 10F);
            this.TotalPayments1.ForeColor = System.Drawing.Color.Black;
            this.TotalPayments1.LocationFloat = new DevExpress.Utils.PointFloat(475F, 0F);
            this.TotalPayments1.Name = "TotalPayments1";
            this.TotalPayments1.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.TotalPayments1.SizeF = new System.Drawing.SizeF(156.7361F, 15.34722F);
            this.TotalPayments1.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopRight;
            this.TotalPayments1.TextFormatString = "{0:C2}";
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
            this.Text4.LocationFloat = new DevExpress.Utils.PointFloat(208.3333F, 0F);
            this.Text4.Name = "Text4";
            this.Text4.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.Text4.SizeF = new System.Drawing.SizeF(99.99998F, 15.34722F);
            this.Text4.Text = "TOTAL CODE";
            this.Text4.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopLeft;
            // 
            // CodeCount1
            // 
            this.CodeCount1.BackColor = System.Drawing.Color.Transparent;
            this.CodeCount1.BorderColor = System.Drawing.Color.Black;
            this.CodeCount1.Borders = DevExpress.XtraPrinting.BorderSide.None;
            this.CodeCount1.BorderWidth = 1F;
            this.CodeCount1.CanGrow = false;
            this.CodeCount1.ExpressionBindings.AddRange(new DevExpress.XtraReports.UI.ExpressionBinding[] {
            new DevExpress.XtraReports.UI.ExpressionBinding("BeforePrint", "Text", "[CodeCount]")});
            this.CodeCount1.Font = new DevExpress.Drawing.DXFont("Arial", 10F);
            this.CodeCount1.ForeColor = System.Drawing.Color.Black;
            this.CodeCount1.LocationFloat = new DevExpress.Utils.PointFloat(408.3333F, 0F);
            this.CodeCount1.Name = "CodeCount1";
            this.CodeCount1.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.CodeCount1.SizeF = new System.Drawing.SizeF(44.79167F, 15.34722F);
            this.CodeCount1.StylePriority.UseTextAlignment = false;
            this.CodeCount1.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopRight;
            this.CodeCount1.TextFormatString = "{0:N0}";
            // 
            // Text5
            // 
            this.Text5.BackColor = System.Drawing.Color.Transparent;
            this.Text5.BorderColor = System.Drawing.Color.Black;
            this.Text5.Borders = DevExpress.XtraPrinting.BorderSide.None;
            this.Text5.BorderWidth = 1F;
            this.Text5.CanGrow = false;
            this.Text5.Font = new DevExpress.Drawing.DXFont("Arial", 10F);
            this.Text5.ForeColor = System.Drawing.Color.Black;
            this.Text5.LocationFloat = new DevExpress.Utils.PointFloat(366.6667F, 0F);
            this.Text5.Name = "Text5";
            this.Text5.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.Text5.SizeF = new System.Drawing.SizeF(10.41667F, 15.34722F);
            this.Text5.Text = ":";
            this.Text5.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopCenter;
            // 
            // PaymentType2
            // 
            this.PaymentType2.BackColor = System.Drawing.Color.Transparent;
            this.PaymentType2.BorderColor = System.Drawing.Color.Black;
            this.PaymentType2.Borders = DevExpress.XtraPrinting.BorderSide.None;
            this.PaymentType2.BorderWidth = 1F;
            this.PaymentType2.CanGrow = false;
            this.PaymentType2.ExpressionBindings.AddRange(new DevExpress.XtraReports.UI.ExpressionBinding[] {
            new DevExpress.XtraReports.UI.ExpressionBinding("BeforePrint", "Text", "[PaymentType]")});
            this.PaymentType2.Font = new DevExpress.Drawing.DXFont("Arial", 10F);
            this.PaymentType2.ForeColor = System.Drawing.Color.Black;
            this.PaymentType2.LocationFloat = new DevExpress.Utils.PointFloat(316.6667F, 0F);
            this.PaymentType2.Name = "PaymentType2";
            this.PaymentType2.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.PaymentType2.SizeF = new System.Drawing.SizeF(20.83333F, 15.34722F);
            this.PaymentType2.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopLeft;
            // 
            // PaymentCode2
            // 
            this.PaymentCode2.BackColor = System.Drawing.Color.Transparent;
            this.PaymentCode2.BorderColor = System.Drawing.Color.Black;
            this.PaymentCode2.Borders = DevExpress.XtraPrinting.BorderSide.None;
            this.PaymentCode2.BorderWidth = 1F;
            this.PaymentCode2.CanGrow = false;
            this.PaymentCode2.ExpressionBindings.AddRange(new DevExpress.XtraReports.UI.ExpressionBinding[] {
            new DevExpress.XtraReports.UI.ExpressionBinding("BeforePrint", "Text", "[PaymentCode]")});
            this.PaymentCode2.Font = new DevExpress.Drawing.DXFont("Arial", 10F);
            this.PaymentCode2.ForeColor = System.Drawing.Color.Black;
            this.PaymentCode2.LocationFloat = new DevExpress.Utils.PointFloat(341.6667F, 0F);
            this.PaymentCode2.Name = "PaymentCode2";
            this.PaymentCode2.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.PaymentCode2.SizeF = new System.Drawing.SizeF(20.83333F, 15.34722F);
            this.PaymentCode2.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopLeft;
            // 
            // GroupHeaderArea1
            // 
            this.GroupHeaderArea1.GroupFields.AddRange(new DevExpress.XtraReports.UI.GroupField[] {
            new DevExpress.XtraReports.UI.GroupField("TypeCode", DevExpress.XtraReports.UI.XRColumnSortOrder.Ascending)});
            this.GroupHeaderArea1.HeightF = 0F;
            this.GroupHeaderArea1.KeepTogether = true;
            this.GroupHeaderArea1.Name = "GroupHeaderArea1";
            this.GroupHeaderArea1.Padding = new DevExpress.XtraPrinting.PaddingInfo(0, 0, 0, 0, 100F);
            this.GroupHeaderArea1.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopLeft;
            // 
            // GroupFooterArea1
            // 
            this.GroupFooterArea1.HeightF = 0F;
            this.GroupFooterArea1.KeepTogether = true;
            this.GroupFooterArea1.Name = "GroupFooterArea1";
            this.GroupFooterArea1.Padding = new DevExpress.XtraPrinting.PaddingInfo(0, 0, 0, 0, 100F);
            this.GroupFooterArea1.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopLeft;
            // 
            // ReportHeaderArea1
            // 
            this.ReportHeaderArea1.HeightF = 0F;
            this.ReportHeaderArea1.Name = "ReportHeaderArea1";
            this.ReportHeaderArea1.Padding = new DevExpress.XtraPrinting.PaddingInfo(0, 0, 0, 0, 100F);
            this.ReportHeaderArea1.SubBands.AddRange(new DevExpress.XtraReports.UI.SubBand[] {
            this.ReportHeaderSection1,
            this.ReportHeaderSection2});
            this.ReportHeaderArea1.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopLeft;
            // 
            // ReportHeaderSection1
            // 
            this.ReportHeaderSection1.HeightF = 0F;
            this.ReportHeaderSection1.KeepTogether = true;
            this.ReportHeaderSection1.Name = "ReportHeaderSection1";
            this.ReportHeaderSection1.Padding = new DevExpress.XtraPrinting.PaddingInfo(0, 0, 0, 0, 100F);
            this.ReportHeaderSection1.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopLeft;
            // 
            // ReportHeaderSection2
            // 
            this.ReportHeaderSection2.HeightF = 15F;
            this.ReportHeaderSection2.KeepTogether = true;
            this.ReportHeaderSection2.Name = "ReportHeaderSection2";
            this.ReportHeaderSection2.Padding = new DevExpress.XtraPrinting.PaddingInfo(0, 0, 0, 0, 100F);
            this.ReportHeaderSection2.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopLeft;
            // 
            // PageHeaderArea1
            // 
            this.PageHeaderArea1.HeightF = 41F;
            this.PageHeaderArea1.Name = "PageHeaderArea1";
            this.PageHeaderArea1.Padding = new DevExpress.XtraPrinting.PaddingInfo(0, 0, 0, 0, 100F);
            this.PageHeaderArea1.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopLeft;
            // 
            // ReportFooterArea1
            // 
            this.ReportFooterArea1.HeightF = 0F;
            this.ReportFooterArea1.Name = "ReportFooterArea1";
            this.ReportFooterArea1.Padding = new DevExpress.XtraPrinting.PaddingInfo(0, 0, 0, 0, 100F);
            this.ReportFooterArea1.SubBands.AddRange(new DevExpress.XtraReports.UI.SubBand[] {
            this.ReportFooterSection1,
            this.ReportFooterSection2});
            this.ReportFooterArea1.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopLeft;
            // 
            // ReportFooterSection1
            // 
            this.ReportFooterSection1.Controls.AddRange(new DevExpress.XtraReports.UI.XRControl[] {
            this.SumofTotalPayments2,
            this.Text1,
            this.SumofCodeCount1});
            this.ReportFooterSection1.HeightF = 52.11108F;
            this.ReportFooterSection1.KeepTogether = true;
            this.ReportFooterSection1.Name = "ReportFooterSection1";
            this.ReportFooterSection1.Padding = new DevExpress.XtraPrinting.PaddingInfo(0, 0, 0, 0, 100F);
            this.ReportFooterSection1.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopLeft;
            // 
            // SumofTotalPayments2
            // 
            this.SumofTotalPayments2.BackColor = System.Drawing.Color.Transparent;
            this.SumofTotalPayments2.BorderColor = System.Drawing.Color.Black;
            this.SumofTotalPayments2.Borders = DevExpress.XtraPrinting.BorderSide.Bottom;
            this.SumofTotalPayments2.BorderWidth = 1F;
            this.SumofTotalPayments2.CanGrow = false;
            this.SumofTotalPayments2.ExpressionBindings.AddRange(new DevExpress.XtraReports.UI.ExpressionBinding[] {
            new DevExpress.XtraReports.UI.ExpressionBinding("BeforePrint", "Text", "sumSum([TotalPayments])")});
            this.SumofTotalPayments2.Font = new DevExpress.Drawing.DXFont("Arial", 10F, ((DevExpress.Drawing.DXFontStyle)((DevExpress.Drawing.DXFontStyle.Bold | DevExpress.Drawing.DXFontStyle.Underline))));
            this.SumofTotalPayments2.ForeColor = System.Drawing.Color.Black;
            this.SumofTotalPayments2.LocationFloat = new DevExpress.Utils.PointFloat(475F, 16.66667F);
            this.SumofTotalPayments2.Name = "SumofTotalPayments2";
            this.SumofTotalPayments2.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.SumofTotalPayments2.SizeF = new System.Drawing.SizeF(156.7361F, 15.34722F);
            this.SumofTotalPayments2.StylePriority.UseFont = false;
            xrSummary1.Running = DevExpress.XtraReports.UI.SummaryRunning.Report;
            this.SumofTotalPayments2.Summary = xrSummary1;
            this.SumofTotalPayments2.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopRight;
            this.SumofTotalPayments2.TextFormatString = "{0:C2}";
            // 
            // Text1
            // 
            this.Text1.BackColor = System.Drawing.Color.Transparent;
            this.Text1.BorderColor = System.Drawing.Color.Black;
            this.Text1.Borders = DevExpress.XtraPrinting.BorderSide.Bottom;
            this.Text1.BorderWidth = 1F;
            this.Text1.CanGrow = false;
            this.Text1.Font = new DevExpress.Drawing.DXFont("Arial", 9.75F, ((DevExpress.Drawing.DXFontStyle)((DevExpress.Drawing.DXFontStyle.Bold | DevExpress.Drawing.DXFontStyle.Underline))), DevExpress.Drawing.DXGraphicsUnit.Point, new DevExpress.Drawing.DXFontAdditionalProperty[] {new DevExpress.Drawing.DXFontAdditionalProperty("GdiCharSet", ((byte)(0)))});
            this.Text1.ForeColor = System.Drawing.Color.Black;
            this.Text1.LocationFloat = new DevExpress.Utils.PointFloat(208.3333F, 16.66667F);
            this.Text1.Name = "Text1";
            this.Text1.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.Text1.SizeF = new System.Drawing.SizeF(85.41664F, 15.34722F);
            this.Text1.StylePriority.UseFont = false;
            this.Text1.Text = "Grand Total:";
            this.Text1.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopLeft;
            // 
            // SumofCodeCount1
            // 
            this.SumofCodeCount1.BackColor = System.Drawing.Color.Transparent;
            this.SumofCodeCount1.BorderColor = System.Drawing.Color.Black;
            this.SumofCodeCount1.Borders = DevExpress.XtraPrinting.BorderSide.Bottom;
            this.SumofCodeCount1.BorderWidth = 1F;
            this.SumofCodeCount1.CanGrow = false;
            this.SumofCodeCount1.ExpressionBindings.AddRange(new DevExpress.XtraReports.UI.ExpressionBinding[] {
            new DevExpress.XtraReports.UI.ExpressionBinding("BeforePrint", "Text", "sumSum([CodeCount])")});
            this.SumofCodeCount1.Font = new DevExpress.Drawing.DXFont("Arial", 9.75F, ((DevExpress.Drawing.DXFontStyle)((DevExpress.Drawing.DXFontStyle.Bold | DevExpress.Drawing.DXFontStyle.Underline))), DevExpress.Drawing.DXGraphicsUnit.Point, new DevExpress.Drawing.DXFontAdditionalProperty[] {new DevExpress.Drawing.DXFontAdditionalProperty("GdiCharSet", ((byte)(0)))});
            this.SumofCodeCount1.ForeColor = System.Drawing.Color.Black;
            this.SumofCodeCount1.LocationFloat = new DevExpress.Utils.PointFloat(408.3333F, 16.66667F);
            this.SumofCodeCount1.Name = "SumofCodeCount1";
            this.SumofCodeCount1.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.SumofCodeCount1.SizeF = new System.Drawing.SizeF(44.79167F, 15.34722F);
            this.SumofCodeCount1.StylePriority.UseFont = false;
            xrSummary2.Running = DevExpress.XtraReports.UI.SummaryRunning.Report;
            this.SumofCodeCount1.Summary = xrSummary2;
            this.SumofCodeCount1.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopRight;
            this.SumofCodeCount1.TextFormatString = "{0:N0}";
            // 
            // ReportFooterSection2
            // 
            this.ReportFooterSection2.HeightF = 43F;
            this.ReportFooterSection2.KeepTogether = true;
            this.ReportFooterSection2.Name = "ReportFooterSection2";
            this.ReportFooterSection2.Padding = new DevExpress.XtraPrinting.PaddingInfo(0, 0, 0, 0, 100F);
            this.ReportFooterSection2.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopLeft;
            // 
            // PageFooterArea1
            // 
            this.PageFooterArea1.HeightF = 41F;
            this.PageFooterArea1.Name = "PageFooterArea1";
            this.PageFooterArea1.Padding = new DevExpress.XtraPrinting.PaddingInfo(0, 0, 0, 0, 100F);
            this.PageFooterArea1.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopLeft;
            // 
            // gdStartDate
            // 
            this.gdStartDate.Description = "Enter Start Date:";
            this.gdStartDate.Name = "gdStartDate";
            this.gdStartDate.Type = typeof(System.DateTime);
            this.gdStartDate.ValueInfo = "2022-08-01";
            // 
            // gdEndDate
            // 
            this.gdEndDate.Description = "Enter End Date:";
            this.gdEndDate.Name = "gdEndDate";
            this.gdEndDate.Type = typeof(System.DateTime);
            this.gdEndDate.ValueInfo = "2022-09-12";
            // 
            // gsDealer
            // 
            this.gsDealer.Description = "Enter Dealer Number:";
            this.gsDealer.Name = "gsDealer";
            this.gsDealer.ValueInfo = "%";
            // 
            // gsDealerState
            // 
            this.gsDealerState.Description = "Enter Dealer State;";
            this.gsDealerState.Name = "gsDealerState";
            this.gsDealerState.ValueInfo = "%";
            // 
            // gsState
            // 
            this.gsState.Description = "Enter Customer State:";
            this.gsState.Name = "gsState";
            this.gsState.ValueInfo = "%";
            // 
            // gsType
            // 
            this.gsType.Description = "Enter Payment Type:";
            this.gsType.Name = "gsType";
            this.gsType.ValueInfo = "%";
            // 
            // gsCode
            // 
            this.gsCode.AllowNull = true;
            this.gsCode.Description = "Enter Payment Code:";
            this.gsCode.Name = "gsCode";
            this.gsCode.ValueInfo = "%";
            // 
            // sqlDataSource1
            // 
            this.sqlDataSource1.ConnectionName = "IAC2021SQL.Properties.Settings.IAC2010SQLConnectionString";
            this.sqlDataSource1.Name = "sqlDataSource1";
            storedProcQuery1.Name = "ClosedCustomerBuyBackSummary";
            queryParameter1.Name = "@EndDate";
            queryParameter1.Type = typeof(DevExpress.DataAccess.Expression);
            queryParameter1.Value = new DevExpress.DataAccess.Expression("?gdEndDate", typeof(System.DateTime));
            queryParameter2.Name = "@StartDate";
            queryParameter2.Type = typeof(DevExpress.DataAccess.Expression);
            queryParameter2.Value = new DevExpress.DataAccess.Expression("?gdStartDate", typeof(System.DateTime));
            queryParameter3.Name = "@CUSTHIST_PAYMENT_TYPE";
            queryParameter3.Type = typeof(DevExpress.DataAccess.Expression);
            queryParameter3.Value = new DevExpress.DataAccess.Expression("?gsType", typeof(string));
            queryParameter4.Name = "@CUSTHIST_PAYMENT_CODE";
            queryParameter4.Type = typeof(DevExpress.DataAccess.Expression);
            queryParameter4.Value = new DevExpress.DataAccess.Expression("?gsCode", typeof(string));
            queryParameter5.Name = "@CUSTOMER_DEALER";
            queryParameter5.Type = typeof(DevExpress.DataAccess.Expression);
            queryParameter5.Value = new DevExpress.DataAccess.Expression("?gsDealer", typeof(string));
            queryParameter6.Name = "@DEALER_STATE";
            queryParameter6.Type = typeof(DevExpress.DataAccess.Expression);
            queryParameter6.Value = new DevExpress.DataAccess.Expression("?gsDealerState", typeof(string));
            queryParameter7.Name = "@CUSTOMER_STATE";
            queryParameter7.Type = typeof(DevExpress.DataAccess.Expression);
            queryParameter7.Value = new DevExpress.DataAccess.Expression("?gsState", typeof(string));
            storedProcQuery1.Parameters.AddRange(new DevExpress.DataAccess.Sql.QueryParameter[] {
            queryParameter1,
            queryParameter2,
            queryParameter3,
            queryParameter4,
            queryParameter5,
            queryParameter6,
            queryParameter7});
            storedProcQuery1.StoredProcName = "ClosedCustomerBuyBackSummary";
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
            // XtraReportClosedCustomerBuybackDealerSummary
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
            this.DataMember = "ClosedCustomerBuyBackSummary";
            this.DataSource = this.sqlDataSource1;
            this.Margins = new DevExpress.Drawing.DXMargins(22, 22, 22, 22);
            this.ParameterPanelLayoutItems.AddRange(new DevExpress.XtraReports.Parameters.ParameterPanelLayoutItem[] {
            new DevExpress.XtraReports.Parameters.ParameterLayoutItem(this.gdStartDate, DevExpress.XtraReports.Parameters.Orientation.Horizontal),
            new DevExpress.XtraReports.Parameters.ParameterLayoutItem(this.gdEndDate, DevExpress.XtraReports.Parameters.Orientation.Horizontal),
            new DevExpress.XtraReports.Parameters.ParameterLayoutItem(this.gsDealer, DevExpress.XtraReports.Parameters.Orientation.Horizontal),
            new DevExpress.XtraReports.Parameters.ParameterLayoutItem(this.gsDealerState, DevExpress.XtraReports.Parameters.Orientation.Horizontal),
            new DevExpress.XtraReports.Parameters.ParameterLayoutItem(this.gsState, DevExpress.XtraReports.Parameters.Orientation.Horizontal),
            new DevExpress.XtraReports.Parameters.ParameterLayoutItem(this.gsType, DevExpress.XtraReports.Parameters.Orientation.Horizontal),
            new DevExpress.XtraReports.Parameters.ParameterLayoutItem(this.gsCode, DevExpress.XtraReports.Parameters.Orientation.Horizontal)});
            this.Parameters.AddRange(new DevExpress.XtraReports.Parameters.Parameter[] {
            this.gdStartDate,
            this.gdEndDate,
            this.gsDealer,
            this.gsDealerState,
            this.gsState,
            this.gsType,
            this.gsCode});
            this.Version = "22.1";
            this.BeforePrint += new DevExpress.XtraReports.UI.BeforePrintEventHandler(this.XtraReportClosedCustomerBuybackDealerSummary_BeforePrint);
            ((System.ComponentModel.ISupportInitialize)(this)).EndInit();

        }

        #endregion

        private DevExpress.XtraReports.UI.DetailBand DetailArea1;
        private DevExpress.XtraReports.UI.XRLabel TotalPayments1;
        private DevExpress.XtraReports.UI.XRLabel Text4;
        private DevExpress.XtraReports.UI.XRLabel CodeCount1;
        private DevExpress.XtraReports.UI.XRLabel Text5;
        private DevExpress.XtraReports.UI.XRLabel PaymentType2;
        private DevExpress.XtraReports.UI.XRLabel PaymentCode2;
        private DevExpress.XtraReports.UI.GroupHeaderBand GroupHeaderArea1;
        private DevExpress.XtraReports.UI.GroupFooterBand GroupFooterArea1;
        private DevExpress.XtraReports.UI.ReportHeaderBand ReportHeaderArea1;
        private DevExpress.XtraReports.UI.SubBand ReportHeaderSection1;
        private DevExpress.XtraReports.UI.SubBand ReportHeaderSection2;
        private DevExpress.XtraReports.UI.PageHeaderBand PageHeaderArea1;
        private DevExpress.XtraReports.UI.ReportFooterBand ReportFooterArea1;
        private DevExpress.XtraReports.UI.SubBand ReportFooterSection1;
        private DevExpress.XtraReports.UI.XRLabel SumofTotalPayments2;
        private DevExpress.XtraReports.UI.XRLabel Text1;
        private DevExpress.XtraReports.UI.XRLabel SumofCodeCount1;
        private DevExpress.XtraReports.UI.SubBand ReportFooterSection2;
        private DevExpress.XtraReports.UI.PageFooterBand PageFooterArea1;
        private DevExpress.XtraReports.Parameters.Parameter gdStartDate;
        private DevExpress.XtraReports.Parameters.Parameter gdEndDate;
        private DevExpress.XtraReports.Parameters.Parameter gsDealer;
        private DevExpress.XtraReports.Parameters.Parameter gsDealerState;
        private DevExpress.XtraReports.Parameters.Parameter gsState;
        private DevExpress.XtraReports.Parameters.Parameter gsType;
        private DevExpress.XtraReports.Parameters.Parameter gsCode;
        private DevExpress.DataAccess.Sql.SqlDataSource sqlDataSource1;
        private DevExpress.XtraReports.UI.TopMarginBand topMarginBand1;
        private DevExpress.XtraReports.UI.BottomMarginBand bottomMarginBand1;
    }
}

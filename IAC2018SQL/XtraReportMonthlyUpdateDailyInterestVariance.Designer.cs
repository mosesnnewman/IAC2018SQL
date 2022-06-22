namespace IAC2021SQL
{
    partial class XtraReportMonthlyUpdateDailyInterestVariance
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
            DevExpress.DataAccess.Sql.StoredProcQuery storedProcQuery1 = new DevExpress.DataAccess.Sql.StoredProcQuery();
            DevExpress.DataAccess.Sql.QueryParameter queryParameter1 = new DevExpress.DataAccess.Sql.QueryParameter();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(XtraReportMonthlyUpdateDailyInterestVariance));
            this.Area3 = new DevExpress.XtraReports.UI.DetailBand();
            this.PostDate1 = new DevExpress.XtraReports.UI.XRLabel();
            this.InterestType_1 = new DevExpress.XtraReports.UI.XRLabel();
            this.MonthEndAmount1 = new DevExpress.XtraReports.UI.XRLabel();
            this.OriginalAmount1 = new DevExpress.XtraReports.UI.XRLabel();
            this.ChangeDueToISF1 = new DevExpress.XtraReports.UI.XRLabel();
            this.Area1 = new DevExpress.XtraReports.UI.ReportHeaderBand();
            this.Section1 = new DevExpress.XtraReports.UI.SubBand();
            this.ReportHeaderSection1 = new DevExpress.XtraReports.UI.SubBand();
            this.Text1 = new DevExpress.XtraReports.UI.XRLabel();
            this.Text3 = new DevExpress.XtraReports.UI.XRLabel();
            this.Text5 = new DevExpress.XtraReports.UI.XRLabel();
            this.Text4 = new DevExpress.XtraReports.UI.XRLabel();
            this.Text6 = new DevExpress.XtraReports.UI.XRLabel();
            this.Text7 = new DevExpress.XtraReports.UI.XRLabel();
            this.Line1 = new DevExpress.XtraReports.UI.XRLine();
            this.PageHeaderArea1 = new DevExpress.XtraReports.UI.PageHeaderBand();
            this.Area4 = new DevExpress.XtraReports.UI.ReportFooterBand();
            this.Section4 = new DevExpress.XtraReports.UI.SubBand();
            this.Text8 = new DevExpress.XtraReports.UI.XRLabel();
            this.TotalMonthEndAmount1 = new DevExpress.XtraReports.UI.XRLabel();
            this.TotalChangeDueToISF1 = new DevExpress.XtraReports.UI.XRLabel();
            this.TotalChangeDueToISF2 = new DevExpress.XtraReports.UI.XRLabel();
            this.Text2 = new DevExpress.XtraReports.UI.XRLabel();
            this.TotalOriginalAmountAndChange_1 = new DevExpress.XtraReports.UI.XRLabel();
            this.Line3 = new DevExpress.XtraReports.UI.XRLine();
            this.ReportFooterSection1 = new DevExpress.XtraReports.UI.SubBand();
            this.PageFooterArea1 = new DevExpress.XtraReports.UI.PageFooterBand();
            this.gsUserName_1 = new DevExpress.XtraReports.UI.XRLabel();
            this.DataTime1 = new DevExpress.XtraReports.UI.XRPageInfo();
            this.xrLabel1 = new DevExpress.XtraReports.UI.XRLabel();
            this.gsUserID_1 = new DevExpress.XtraReports.UI.XRLabel();
            this.DataDate1 = new DevExpress.XtraReports.UI.XRPageInfo();
            this.PageNofM1 = new DevExpress.XtraReports.UI.XRPageInfo();
            this.InterestType = new DevExpress.XtraReports.UI.CalculatedField();
            this.sqlDataSourceMonthlyUpdateDailyInterestVariance = new DevExpress.DataAccess.Sql.SqlDataSource(this.components);
            this.topMarginBand1 = new DevExpress.XtraReports.UI.TopMarginBand();
            this.bottomMarginBand1 = new DevExpress.XtraReports.UI.BottomMarginBand();
            this.gsUserID = new DevExpress.XtraReports.Parameters.Parameter();
            this.gsUserName = new DevExpress.XtraReports.Parameters.Parameter();
            ((System.ComponentModel.ISupportInitialize)(this)).BeginInit();
            // 
            // Area3
            // 
            this.Area3.Controls.AddRange(new DevExpress.XtraReports.UI.XRControl[] {
            this.PostDate1,
            this.InterestType_1,
            this.MonthEndAmount1,
            this.OriginalAmount1,
            this.ChangeDueToISF1});
            this.Area3.HeightF = 13F;
            this.Area3.KeepTogether = true;
            this.Area3.Name = "Area3";
            this.Area3.Padding = new DevExpress.XtraPrinting.PaddingInfo(0, 0, 0, 0, 100F);
            this.Area3.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopLeft;
            // 
            // PostDate1
            // 
            this.PostDate1.BackColor = System.Drawing.Color.Transparent;
            this.PostDate1.BorderColor = System.Drawing.Color.Black;
            this.PostDate1.Borders = DevExpress.XtraPrinting.BorderSide.None;
            this.PostDate1.BorderWidth = 1F;
            this.PostDate1.CanGrow = false;
            this.PostDate1.ExpressionBindings.AddRange(new DevExpress.XtraReports.UI.ExpressionBinding[] {
            new DevExpress.XtraReports.UI.ExpressionBinding("BeforePrint", "Text", "[PostDate]")});
            this.PostDate1.Font = new System.Drawing.Font("Lucida Sans Typewriter", 8F);
            this.PostDate1.ForeColor = System.Drawing.Color.Black;
            this.PostDate1.LocationFloat = new DevExpress.Utils.PointFloat(125F, 0F);
            this.PostDate1.Name = "PostDate1";
            this.PostDate1.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.PostDate1.SizeF = new System.Drawing.SizeF(119.8611F, 13.19444F);
            this.PostDate1.StylePriority.UseTextAlignment = false;
            this.PostDate1.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopLeft;
            this.PostDate1.TextFormatString = "{0:MM/dd/yyyy}";
            // 
            // InterestType_1
            // 
            this.InterestType_1.BackColor = System.Drawing.Color.Transparent;
            this.InterestType_1.BorderColor = System.Drawing.Color.Black;
            this.InterestType_1.Borders = DevExpress.XtraPrinting.BorderSide.None;
            this.InterestType_1.BorderWidth = 1F;
            this.InterestType_1.CanGrow = false;
            this.InterestType_1.ExpressionBindings.AddRange(new DevExpress.XtraReports.UI.ExpressionBinding[] {
            new DevExpress.XtraReports.UI.ExpressionBinding("BeforePrint", "Text", "[InterestType]")});
            this.InterestType_1.Font = new System.Drawing.Font("Lucida Sans Typewriter", 8F);
            this.InterestType_1.ForeColor = System.Drawing.Color.Black;
            this.InterestType_1.LocationFloat = new DevExpress.Utils.PointFloat(250F, 0F);
            this.InterestType_1.Name = "InterestType_1";
            this.InterestType_1.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.InterestType_1.SizeF = new System.Drawing.SizeF(214.5833F, 13.19444F);
            this.InterestType_1.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopLeft;
            // 
            // MonthEndAmount1
            // 
            this.MonthEndAmount1.BackColor = System.Drawing.Color.Transparent;
            this.MonthEndAmount1.BorderColor = System.Drawing.Color.Black;
            this.MonthEndAmount1.Borders = DevExpress.XtraPrinting.BorderSide.None;
            this.MonthEndAmount1.BorderWidth = 1F;
            this.MonthEndAmount1.CanGrow = false;
            this.MonthEndAmount1.ExpressionBindings.AddRange(new DevExpress.XtraReports.UI.ExpressionBinding[] {
            new DevExpress.XtraReports.UI.ExpressionBinding("BeforePrint", "Text", "[MonthEndAmount]"),
            new DevExpress.XtraReports.UI.ExpressionBinding("BeforePrint", "Visible", "iif([MonthEndAmount] == 0, False,True)\n")});
            this.MonthEndAmount1.Font = new System.Drawing.Font("Lucida Sans Typewriter", 8F);
            this.MonthEndAmount1.ForeColor = System.Drawing.Color.Black;
            this.MonthEndAmount1.LocationFloat = new DevExpress.Utils.PointFloat(641.6667F, 0F);
            this.MonthEndAmount1.Name = "MonthEndAmount1";
            this.MonthEndAmount1.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.MonthEndAmount1.SizeF = new System.Drawing.SizeF(143.75F, 13.19444F);
            this.MonthEndAmount1.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopRight;
            this.MonthEndAmount1.TextFormatString = "{0:$#,##0.00}";
            this.MonthEndAmount1.Visible = false;
            // 
            // OriginalAmount1
            // 
            this.OriginalAmount1.BackColor = System.Drawing.Color.Transparent;
            this.OriginalAmount1.BorderColor = System.Drawing.Color.Black;
            this.OriginalAmount1.Borders = DevExpress.XtraPrinting.BorderSide.None;
            this.OriginalAmount1.BorderWidth = 1F;
            this.OriginalAmount1.CanGrow = false;
            this.OriginalAmount1.ExpressionBindings.AddRange(new DevExpress.XtraReports.UI.ExpressionBinding[] {
            new DevExpress.XtraReports.UI.ExpressionBinding("BeforePrint", "Text", "[OriginalAmount]"),
            new DevExpress.XtraReports.UI.ExpressionBinding("BeforePrint", "Visible", "iif([OriginalAmount] == 0, False,True)\n")});
            this.OriginalAmount1.Font = new System.Drawing.Font("Lucida Sans Typewriter", 8F);
            this.OriginalAmount1.ForeColor = System.Drawing.Color.Black;
            this.OriginalAmount1.LocationFloat = new DevExpress.Utils.PointFloat(472.9167F, 0F);
            this.OriginalAmount1.Name = "OriginalAmount1";
            this.OriginalAmount1.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.OriginalAmount1.SizeF = new System.Drawing.SizeF(143.75F, 13.19444F);
            this.OriginalAmount1.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopRight;
            this.OriginalAmount1.TextFormatString = "{0:$#,##0.00}";
            this.OriginalAmount1.Visible = false;
            // 
            // ChangeDueToISF1
            // 
            this.ChangeDueToISF1.BackColor = System.Drawing.Color.Transparent;
            this.ChangeDueToISF1.BorderColor = System.Drawing.Color.Black;
            this.ChangeDueToISF1.Borders = DevExpress.XtraPrinting.BorderSide.None;
            this.ChangeDueToISF1.BorderWidth = 1F;
            this.ChangeDueToISF1.CanGrow = false;
            this.ChangeDueToISF1.ExpressionBindings.AddRange(new DevExpress.XtraReports.UI.ExpressionBinding[] {
            new DevExpress.XtraReports.UI.ExpressionBinding("BeforePrint", "Text", "[ChangeDueToISF]"),
            new DevExpress.XtraReports.UI.ExpressionBinding("BeforePrint", "Visible", "iif([ChangeDueToISF] == 0, False,True)\n")});
            this.ChangeDueToISF1.Font = new System.Drawing.Font("Lucida Sans Typewriter", 8F);
            this.ChangeDueToISF1.ForeColor = System.Drawing.Color.Black;
            this.ChangeDueToISF1.LocationFloat = new DevExpress.Utils.PointFloat(800F, 0F);
            this.ChangeDueToISF1.Name = "ChangeDueToISF1";
            this.ChangeDueToISF1.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.ChangeDueToISF1.SizeF = new System.Drawing.SizeF(143.75F, 13.19444F);
            this.ChangeDueToISF1.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopRight;
            this.ChangeDueToISF1.TextFormatString = "{0:$#,##0.00}";
            this.ChangeDueToISF1.Visible = false;
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
            this.Text1,
            this.Text3,
            this.Text5,
            this.Text4,
            this.Text6,
            this.Text7,
            this.Line1});
            this.ReportHeaderSection1.HeightF = 59F;
            this.ReportHeaderSection1.KeepTogether = true;
            this.ReportHeaderSection1.Name = "ReportHeaderSection1";
            this.ReportHeaderSection1.Padding = new DevExpress.XtraPrinting.PaddingInfo(0, 0, 0, 0, 100F);
            this.ReportHeaderSection1.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopLeft;
            // 
            // Text1
            // 
            this.Text1.BackColor = System.Drawing.Color.Transparent;
            this.Text1.BorderColor = System.Drawing.Color.Black;
            this.Text1.Borders = DevExpress.XtraPrinting.BorderSide.None;
            this.Text1.BorderWidth = 1F;
            this.Text1.CanGrow = false;
            this.Text1.Font = new System.Drawing.Font("Lucida Sans Typewriter", 8F, System.Drawing.FontStyle.Bold);
            this.Text1.ForeColor = System.Drawing.Color.Black;
            this.Text1.LocationFloat = new DevExpress.Utils.PointFloat(125F, 41.66667F);
            this.Text1.Name = "Text1";
            this.Text1.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.Text1.SizeF = new System.Drawing.SizeF(119.8611F, 13.19444F);
            this.Text1.Text = "Post Date";
            this.Text1.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopCenter;
            // 
            // Text3
            // 
            this.Text3.BackColor = System.Drawing.Color.Transparent;
            this.Text3.BorderColor = System.Drawing.Color.Black;
            this.Text3.Borders = DevExpress.XtraPrinting.BorderSide.None;
            this.Text3.BorderWidth = 1F;
            this.Text3.CanGrow = false;
            this.Text3.Font = new System.Drawing.Font("Lucida Sans Typewriter", 8F, System.Drawing.FontStyle.Bold);
            this.Text3.ForeColor = System.Drawing.Color.Black;
            this.Text3.LocationFloat = new DevExpress.Utils.PointFloat(250F, 41.66667F);
            this.Text3.Name = "Text3";
            this.Text3.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.Text3.SizeF = new System.Drawing.SizeF(214.5833F, 13.19444F);
            this.Text3.Text = "Type";
            this.Text3.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopLeft;
            // 
            // Text5
            // 
            this.Text5.BackColor = System.Drawing.Color.Transparent;
            this.Text5.BorderColor = System.Drawing.Color.Black;
            this.Text5.Borders = DevExpress.XtraPrinting.BorderSide.None;
            this.Text5.BorderWidth = 1F;
            this.Text5.CanGrow = false;
            this.Text5.Font = new System.Drawing.Font("Lucida Sans Typewriter", 8F, System.Drawing.FontStyle.Bold);
            this.Text5.ForeColor = System.Drawing.Color.Black;
            this.Text5.LocationFloat = new DevExpress.Utils.PointFloat(472.9167F, 41.66667F);
            this.Text5.Name = "Text5";
            this.Text5.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.Text5.SizeF = new System.Drawing.SizeF(143.75F, 13.19444F);
            this.Text5.Text = "Original Amount";
            this.Text5.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopRight;
            // 
            // Text4
            // 
            this.Text4.BackColor = System.Drawing.Color.Transparent;
            this.Text4.BorderColor = System.Drawing.Color.Black;
            this.Text4.Borders = DevExpress.XtraPrinting.BorderSide.None;
            this.Text4.BorderWidth = 1F;
            this.Text4.CanGrow = false;
            this.Text4.Font = new System.Drawing.Font("Lucida Sans Typewriter", 8F, System.Drawing.FontStyle.Bold);
            this.Text4.ForeColor = System.Drawing.Color.Black;
            this.Text4.LocationFloat = new DevExpress.Utils.PointFloat(641.6667F, 41.66667F);
            this.Text4.Name = "Text4";
            this.Text4.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.Text4.SizeF = new System.Drawing.SizeF(143.75F, 13.19444F);
            this.Text4.Text = "Month End Amount";
            this.Text4.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopRight;
            // 
            // Text6
            // 
            this.Text6.BackColor = System.Drawing.Color.Transparent;
            this.Text6.BorderColor = System.Drawing.Color.Black;
            this.Text6.Borders = DevExpress.XtraPrinting.BorderSide.None;
            this.Text6.BorderWidth = 1F;
            this.Text6.CanGrow = false;
            this.Text6.Font = new System.Drawing.Font("Lucida Sans Typewriter", 8F, System.Drawing.FontStyle.Bold);
            this.Text6.ForeColor = System.Drawing.Color.Black;
            this.Text6.LocationFloat = new DevExpress.Utils.PointFloat(800F, 41.66667F);
            this.Text6.Name = "Text6";
            this.Text6.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.Text6.SizeF = new System.Drawing.SizeF(143.75F, 13.19444F);
            this.Text6.Text = "Change Due To ISF";
            this.Text6.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopRight;
            // 
            // Text7
            // 
            this.Text7.BackColor = System.Drawing.Color.Transparent;
            this.Text7.BorderColor = System.Drawing.Color.Black;
            this.Text7.Borders = DevExpress.XtraPrinting.BorderSide.None;
            this.Text7.BorderWidth = 1F;
            this.Text7.CanGrow = false;
            this.Text7.Font = new System.Drawing.Font("Lucida Sans Typewriter", 14F, System.Drawing.FontStyle.Underline);
            this.Text7.ForeColor = System.Drawing.Color.Black;
            this.Text7.LocationFloat = new DevExpress.Utils.PointFloat(0F, 0F);
            this.Text7.Name = "Text7";
            this.Text7.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.Text7.SizeF = new System.Drawing.SizeF(1066.667F, 25F);
            this.Text7.Text = "Daily Interest Report";
            this.Text7.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopCenter;
            // 
            // Line1
            // 
            this.Line1.BackColor = System.Drawing.Color.Transparent;
            this.Line1.BorderColor = System.Drawing.Color.Black;
            this.Line1.Borders = DevExpress.XtraPrinting.BorderSide.Top;
            this.Line1.BorderWidth = 1F;
            this.Line1.Font = new System.Drawing.Font("Times New Roman", 9.75F);
            this.Line1.ForeColor = System.Drawing.Color.Black;
            this.Line1.LineWidth = 3F;
            this.Line1.LocationFloat = new DevExpress.Utils.PointFloat(125F, 55.20833F);
            this.Line1.Name = "Line1";
            this.Line1.Padding = new DevExpress.XtraPrinting.PaddingInfo(0, 0, 0, 0, 100F);
            this.Line1.SizeF = new System.Drawing.SizeF(816.6667F, 3.125F);
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
            this.Text8,
            this.TotalMonthEndAmount1,
            this.TotalChangeDueToISF1,
            this.TotalChangeDueToISF2,
            this.Text2,
            this.TotalOriginalAmountAndChange_1,
            this.Line3});
            this.Section4.HeightF = 40.08338F;
            this.Section4.KeepTogether = true;
            this.Section4.Name = "Section4";
            this.Section4.Padding = new DevExpress.XtraPrinting.PaddingInfo(0, 0, 0, 0, 100F);
            this.Section4.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopLeft;
            // 
            // Text8
            // 
            this.Text8.BackColor = System.Drawing.Color.Transparent;
            this.Text8.BorderColor = System.Drawing.Color.Black;
            this.Text8.Borders = DevExpress.XtraPrinting.BorderSide.None;
            this.Text8.BorderWidth = 1F;
            this.Text8.CanGrow = false;
            this.Text8.Font = new System.Drawing.Font("Lucida Sans Typewriter", 8F, System.Drawing.FontStyle.Bold);
            this.Text8.ForeColor = System.Drawing.Color.Black;
            this.Text8.LocationFloat = new DevExpress.Utils.PointFloat(125F, 25F);
            this.Text8.Name = "Text8";
            this.Text8.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.Text8.SizeF = new System.Drawing.SizeF(129.7917F, 13.19444F);
            this.Text8.Text = "Totals";
            this.Text8.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopCenter;
            // 
            // TotalMonthEndAmount1
            // 
            this.TotalMonthEndAmount1.BackColor = System.Drawing.Color.Transparent;
            this.TotalMonthEndAmount1.BorderColor = System.Drawing.Color.Black;
            this.TotalMonthEndAmount1.Borders = DevExpress.XtraPrinting.BorderSide.None;
            this.TotalMonthEndAmount1.BorderWidth = 1F;
            this.TotalMonthEndAmount1.CanGrow = false;
            this.TotalMonthEndAmount1.ExpressionBindings.AddRange(new DevExpress.XtraReports.UI.ExpressionBinding[] {
            new DevExpress.XtraReports.UI.ExpressionBinding("BeforePrint", "Text", "sumSum([MonthEndAmount])"),
            new DevExpress.XtraReports.UI.ExpressionBinding("BeforePrint", "Visible", "iif([this].[Value] == 0, False,True)\n")});
            this.TotalMonthEndAmount1.Font = new System.Drawing.Font("Lucida Sans Typewriter", 8F, System.Drawing.FontStyle.Bold);
            this.TotalMonthEndAmount1.ForeColor = System.Drawing.Color.Black;
            this.TotalMonthEndAmount1.LocationFloat = new DevExpress.Utils.PointFloat(650F, 25F);
            this.TotalMonthEndAmount1.Name = "TotalMonthEndAmount1";
            this.TotalMonthEndAmount1.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.TotalMonthEndAmount1.SizeF = new System.Drawing.SizeF(133.3333F, 13.19444F);
            xrSummary1.Running = DevExpress.XtraReports.UI.SummaryRunning.Report;
            this.TotalMonthEndAmount1.Summary = xrSummary1;
            this.TotalMonthEndAmount1.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopRight;
            this.TotalMonthEndAmount1.TextFormatString = "{0:$#,##0.00}";
            this.TotalMonthEndAmount1.Visible = false;
            // 
            // TotalChangeDueToISF1
            // 
            this.TotalChangeDueToISF1.BackColor = System.Drawing.Color.Transparent;
            this.TotalChangeDueToISF1.BorderColor = System.Drawing.Color.Black;
            this.TotalChangeDueToISF1.Borders = DevExpress.XtraPrinting.BorderSide.None;
            this.TotalChangeDueToISF1.BorderWidth = 1F;
            this.TotalChangeDueToISF1.CanGrow = false;
            this.TotalChangeDueToISF1.ExpressionBindings.AddRange(new DevExpress.XtraReports.UI.ExpressionBinding[] {
            new DevExpress.XtraReports.UI.ExpressionBinding("BeforePrint", "Text", "sumSum([ChangeDueToISF])"),
            new DevExpress.XtraReports.UI.ExpressionBinding("BeforePrint", "Visible", "iif([this].[Value] == 0, False,True)\n")});
            this.TotalChangeDueToISF1.Font = new System.Drawing.Font("Lucida Sans Typewriter", 8F, System.Drawing.FontStyle.Bold);
            this.TotalChangeDueToISF1.ForeColor = System.Drawing.Color.Black;
            this.TotalChangeDueToISF1.LocationFloat = new DevExpress.Utils.PointFloat(808.3333F, 25F);
            this.TotalChangeDueToISF1.Name = "TotalChangeDueToISF1";
            this.TotalChangeDueToISF1.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.TotalChangeDueToISF1.SizeF = new System.Drawing.SizeF(133.3333F, 13.19444F);
            xrSummary2.Running = DevExpress.XtraReports.UI.SummaryRunning.Report;
            this.TotalChangeDueToISF1.Summary = xrSummary2;
            this.TotalChangeDueToISF1.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopRight;
            this.TotalChangeDueToISF1.TextFormatString = "{0:$#,##0.00}";
            this.TotalChangeDueToISF1.Visible = false;
            // 
            // TotalChangeDueToISF2
            // 
            this.TotalChangeDueToISF2.BackColor = System.Drawing.Color.Transparent;
            this.TotalChangeDueToISF2.BorderColor = System.Drawing.Color.Black;
            this.TotalChangeDueToISF2.Borders = DevExpress.XtraPrinting.BorderSide.None;
            this.TotalChangeDueToISF2.BorderWidth = 1F;
            this.TotalChangeDueToISF2.CanGrow = false;
            this.TotalChangeDueToISF2.ExpressionBindings.AddRange(new DevExpress.XtraReports.UI.ExpressionBinding[] {
            new DevExpress.XtraReports.UI.ExpressionBinding("BeforePrint", "Text", "sumSum([ChangeDueToISF])"),
            new DevExpress.XtraReports.UI.ExpressionBinding("BeforePrint", "Visible", "iif([this].[Value] == 0, False,True)\n")});
            this.TotalChangeDueToISF2.Font = new System.Drawing.Font("Lucida Sans Typewriter", 8F, System.Drawing.FontStyle.Bold);
            this.TotalChangeDueToISF2.ForeColor = System.Drawing.Color.Black;
            this.TotalChangeDueToISF2.LocationFloat = new DevExpress.Utils.PointFloat(483.3333F, 8.333333F);
            this.TotalChangeDueToISF2.Name = "TotalChangeDueToISF2";
            this.TotalChangeDueToISF2.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.TotalChangeDueToISF2.SizeF = new System.Drawing.SizeF(133.3333F, 13.19444F);
            xrSummary3.Running = DevExpress.XtraReports.UI.SummaryRunning.Report;
            this.TotalChangeDueToISF2.Summary = xrSummary3;
            this.TotalChangeDueToISF2.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopRight;
            this.TotalChangeDueToISF2.TextFormatString = "{0:$#,##0.00}";
            // 
            // Text2
            // 
            this.Text2.BackColor = System.Drawing.Color.Transparent;
            this.Text2.BorderColor = System.Drawing.Color.Black;
            this.Text2.Borders = DevExpress.XtraPrinting.BorderSide.None;
            this.Text2.BorderWidth = 1F;
            this.Text2.CanGrow = false;
            this.Text2.Font = new System.Drawing.Font("Lucida Sans Typewriter", 8F, System.Drawing.FontStyle.Bold);
            this.Text2.ForeColor = System.Drawing.Color.Black;
            this.Text2.LocationFloat = new DevExpress.Utils.PointFloat(333.3333F, 8.333333F);
            this.Text2.Name = "Text2";
            this.Text2.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.Text2.SizeF = new System.Drawing.SizeF(135F, 13.19444F);
            this.Text2.Text = "+Change Due To ISF";
            this.Text2.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopRight;
            // 
            // TotalOriginalAmountAndChange_1
            // 
            this.TotalOriginalAmountAndChange_1.BackColor = System.Drawing.Color.Transparent;
            this.TotalOriginalAmountAndChange_1.BorderColor = System.Drawing.Color.Black;
            this.TotalOriginalAmountAndChange_1.Borders = DevExpress.XtraPrinting.BorderSide.None;
            this.TotalOriginalAmountAndChange_1.BorderWidth = 1F;
            this.TotalOriginalAmountAndChange_1.CanGrow = false;
            this.TotalOriginalAmountAndChange_1.ExpressionBindings.AddRange(new DevExpress.XtraReports.UI.ExpressionBinding[] {
            new DevExpress.XtraReports.UI.ExpressionBinding("BeforePrint", "Visible", "iif([this].[Value] == 0, False,True)\n"),
            new DevExpress.XtraReports.UI.ExpressionBinding("BeforePrint", "Text", "sumSum([OriginalAmount])+sumSum([ChangeDueToISF])")});
            this.TotalOriginalAmountAndChange_1.Font = new System.Drawing.Font("Lucida Sans Typewriter", 8F, System.Drawing.FontStyle.Bold);
            this.TotalOriginalAmountAndChange_1.ForeColor = System.Drawing.Color.Black;
            this.TotalOriginalAmountAndChange_1.LocationFloat = new DevExpress.Utils.PointFloat(483.3333F, 25F);
            this.TotalOriginalAmountAndChange_1.Name = "TotalOriginalAmountAndChange_1";
            this.TotalOriginalAmountAndChange_1.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.TotalOriginalAmountAndChange_1.SizeF = new System.Drawing.SizeF(133.3333F, 13.19444F);
            xrSummary4.Running = DevExpress.XtraReports.UI.SummaryRunning.Report;
            this.TotalOriginalAmountAndChange_1.Summary = xrSummary4;
            this.TotalOriginalAmountAndChange_1.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopRight;
            this.TotalOriginalAmountAndChange_1.TextFormatString = "{0:$#,##0.00}";
            this.TotalOriginalAmountAndChange_1.Visible = false;
            // 
            // Line3
            // 
            this.Line3.BackColor = System.Drawing.Color.Transparent;
            this.Line3.BorderColor = System.Drawing.Color.Black;
            this.Line3.Borders = DevExpress.XtraPrinting.BorderSide.Top;
            this.Line3.BorderWidth = 1F;
            this.Line3.Font = new System.Drawing.Font("Times New Roman", 9.75F);
            this.Line3.ForeColor = System.Drawing.Color.Black;
            this.Line3.LineWidth = 3F;
            this.Line3.LocationFloat = new DevExpress.Utils.PointFloat(125F, 0F);
            this.Line3.Name = "Line3";
            this.Line3.Padding = new DevExpress.XtraPrinting.PaddingInfo(0, 0, 0, 0, 100F);
            this.Line3.SizeF = new System.Drawing.SizeF(816.6667F, 3.125F);
            // 
            // ReportFooterSection1
            // 
            this.ReportFooterSection1.HeightF = 0F;
            this.ReportFooterSection1.KeepTogether = true;
            this.ReportFooterSection1.Name = "ReportFooterSection1";
            this.ReportFooterSection1.Padding = new DevExpress.XtraPrinting.PaddingInfo(0, 0, 0, 0, 100F);
            this.ReportFooterSection1.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopLeft;
            // 
            // PageFooterArea1
            // 
            this.PageFooterArea1.Controls.AddRange(new DevExpress.XtraReports.UI.XRControl[] {
            this.gsUserName_1,
            this.DataTime1,
            this.xrLabel1,
            this.gsUserID_1,
            this.DataDate1,
            this.PageNofM1});
            this.PageFooterArea1.HeightF = 41F;
            this.PageFooterArea1.Name = "PageFooterArea1";
            this.PageFooterArea1.Padding = new DevExpress.XtraPrinting.PaddingInfo(0, 0, 0, 0, 100F);
            this.PageFooterArea1.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopLeft;
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
            this.gsUserName_1.LocationFloat = new DevExpress.Utils.PointFloat(296.6666F, 1F);
            this.gsUserName_1.Name = "gsUserName_1";
            this.gsUserName_1.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.gsUserName_1.SizeF = new System.Drawing.SizeF(158.3333F, 18.33333F);
            this.gsUserName_1.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopLeft;
            // 
            // DataTime1
            // 
            this.DataTime1.BackColor = System.Drawing.Color.Transparent;
            this.DataTime1.BorderColor = System.Drawing.Color.Black;
            this.DataTime1.Borders = DevExpress.XtraPrinting.BorderSide.None;
            this.DataTime1.BorderWidth = 1F;
            this.DataTime1.Font = new System.Drawing.Font("Arial", 10F);
            this.DataTime1.ForeColor = System.Drawing.Color.Black;
            this.DataTime1.LocationFloat = new DevExpress.Utils.PointFloat(96.66667F, 1F);
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
            this.xrLabel1.Font = new System.Drawing.Font("Arial", 10F, System.Drawing.FontStyle.Bold);
            this.xrLabel1.ForeColor = System.Drawing.Color.Black;
            this.xrLabel1.LocationFloat = new DevExpress.Utils.PointFloat(205F, 1F);
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
            this.gsUserID_1.Font = new System.Drawing.Font("Arial", 10F);
            this.gsUserID_1.ForeColor = System.Drawing.Color.Black;
            this.gsUserID_1.LocationFloat = new DevExpress.Utils.PointFloat(255F, 0.9999911F);
            this.gsUserID_1.Name = "gsUserID_1";
            this.gsUserID_1.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.gsUserID_1.SizeF = new System.Drawing.SizeF(41.66661F, 18.33333F);
            this.gsUserID_1.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopLeft;
            // 
            // DataDate1
            // 
            this.DataDate1.BackColor = System.Drawing.Color.Transparent;
            this.DataDate1.BorderColor = System.Drawing.Color.Black;
            this.DataDate1.Borders = DevExpress.XtraPrinting.BorderSide.None;
            this.DataDate1.BorderWidth = 1F;
            this.DataDate1.Font = new System.Drawing.Font("Arial", 10F);
            this.DataDate1.ForeColor = System.Drawing.Color.Black;
            this.DataDate1.LocationFloat = new DevExpress.Utils.PointFloat(5.000007F, 1F);
            this.DataDate1.Name = "DataDate1";
            this.DataDate1.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.DataDate1.PageInfo = DevExpress.XtraPrinting.PageInfo.DateTime;
            this.DataDate1.SizeF = new System.Drawing.SizeF(68.75F, 18.33333F);
            this.DataDate1.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopLeft;
            this.DataDate1.TextFormatString = "{0:MM/dd/yyyy}";
            // 
            // PageNofM1
            // 
            this.PageNofM1.BackColor = System.Drawing.Color.Transparent;
            this.PageNofM1.BorderColor = System.Drawing.Color.Black;
            this.PageNofM1.Borders = DevExpress.XtraPrinting.BorderSide.None;
            this.PageNofM1.BorderWidth = 1F;
            this.PageNofM1.Font = new System.Drawing.Font("Arial", 10F);
            this.PageNofM1.ForeColor = System.Drawing.Color.Black;
            this.PageNofM1.LocationFloat = new DevExpress.Utils.PointFloat(900F, 1F);
            this.PageNofM1.Name = "PageNofM1";
            this.PageNofM1.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.PageNofM1.SizeF = new System.Drawing.SizeF(158.3333F, 18.33333F);
            this.PageNofM1.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopLeft;
            // 
            // InterestType
            // 
            this.InterestType.DataMember = "DailyInterestVariance";
            this.InterestType.FieldType = DevExpress.XtraReports.UI.FieldType.String;
            this.InterestType.Name = "InterestType";
            this.InterestType.GetValue += new DevExpress.XtraReports.UI.GetValueEventHandler(this.InterestType_GetValue);
            // 
            // sqlDataSourceMonthlyUpdateDailyInterestVariance
            // 
            this.sqlDataSourceMonthlyUpdateDailyInterestVariance.ConnectionName = "IAC2021SQL.Properties.Settings.IAC2010SQLConnectionString";
            this.sqlDataSourceMonthlyUpdateDailyInterestVariance.Name = "sqlDataSourceMonthlyUpdateDailyInterestVariance";
            storedProcQuery1.Name = "DailyInterestVariance";
            queryParameter1.Name = "@MonthEnd";
            queryParameter1.Type = typeof(System.DateTime);
            queryParameter1.ValueInfo = "2022-04-30";
            storedProcQuery1.Parameters.AddRange(new DevExpress.DataAccess.Sql.QueryParameter[] {
            queryParameter1});
            storedProcQuery1.StoredProcName = "DailyInterestVariance";
            this.sqlDataSourceMonthlyUpdateDailyInterestVariance.Queries.AddRange(new DevExpress.DataAccess.Sql.SqlQuery[] {
            storedProcQuery1});
            this.sqlDataSourceMonthlyUpdateDailyInterestVariance.ResultSchemaSerializable = resources.GetString("sqlDataSourceMonthlyUpdateDailyInterestVariance.ResultSchemaSerializable");
            // 
            // topMarginBand1
            // 
            this.topMarginBand1.HeightF = 16F;
            this.topMarginBand1.Name = "topMarginBand1";
            // 
            // bottomMarginBand1
            // 
            this.bottomMarginBand1.HeightF = 16F;
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
            // XtraReportMonthlyUpdateDailyInterestVariance
            // 
            this.Bands.AddRange(new DevExpress.XtraReports.UI.Band[] {
            this.Area3,
            this.Area1,
            this.PageHeaderArea1,
            this.Area4,
            this.PageFooterArea1,
            this.topMarginBand1,
            this.bottomMarginBand1});
            this.CalculatedFields.AddRange(new DevExpress.XtraReports.UI.CalculatedField[] {
            this.InterestType});
            this.ComponentStorage.AddRange(new System.ComponentModel.IComponent[] {
            this.sqlDataSourceMonthlyUpdateDailyInterestVariance});
            this.DataMember = "DailyInterestVariance";
            this.DataSource = this.sqlDataSourceMonthlyUpdateDailyInterestVariance;
            this.Landscape = true;
            this.Margins = new System.Drawing.Printing.Margins(16, 16, 16, 16);
            this.PageHeight = 850;
            this.PageWidth = 1100;
            this.Parameters.AddRange(new DevExpress.XtraReports.Parameters.Parameter[] {
            this.gsUserID,
            this.gsUserName});
            this.Version = "21.2";
            ((System.ComponentModel.ISupportInitialize)(this)).EndInit();

        }

        #endregion

        private DevExpress.XtraReports.UI.DetailBand Area3;
        private DevExpress.XtraReports.UI.XRLabel PostDate1;
        private DevExpress.XtraReports.UI.XRLabel InterestType_1;
        private DevExpress.XtraReports.UI.XRLabel MonthEndAmount1;
        private DevExpress.XtraReports.UI.XRLabel OriginalAmount1;
        private DevExpress.XtraReports.UI.XRLabel ChangeDueToISF1;
        private DevExpress.XtraReports.UI.ReportHeaderBand Area1;
        private DevExpress.XtraReports.UI.SubBand Section1;
        private DevExpress.XtraReports.UI.SubBand ReportHeaderSection1;
        private DevExpress.XtraReports.UI.XRLabel Text1;
        private DevExpress.XtraReports.UI.XRLabel Text3;
        private DevExpress.XtraReports.UI.XRLabel Text5;
        private DevExpress.XtraReports.UI.XRLabel Text4;
        private DevExpress.XtraReports.UI.XRLabel Text6;
        private DevExpress.XtraReports.UI.XRLabel Text7;
        private DevExpress.XtraReports.UI.XRLine Line1;
        private DevExpress.XtraReports.UI.PageHeaderBand PageHeaderArea1;
        private DevExpress.XtraReports.UI.ReportFooterBand Area4;
        private DevExpress.XtraReports.UI.SubBand Section4;
        private DevExpress.XtraReports.UI.XRLabel Text8;
        private DevExpress.XtraReports.UI.XRLabel TotalMonthEndAmount1;
        private DevExpress.XtraReports.UI.XRLabel TotalChangeDueToISF1;
        private DevExpress.XtraReports.UI.XRLabel TotalChangeDueToISF2;
        private DevExpress.XtraReports.UI.XRLabel Text2;
        private DevExpress.XtraReports.UI.XRLabel TotalOriginalAmountAndChange_1;
        private DevExpress.XtraReports.UI.XRLine Line3;
        private DevExpress.XtraReports.UI.SubBand ReportFooterSection1;
        private DevExpress.XtraReports.UI.PageFooterBand PageFooterArea1;
        private DevExpress.XtraReports.UI.CalculatedField InterestType;
        private DevExpress.DataAccess.Sql.SqlDataSource sqlDataSourceMonthlyUpdateDailyInterestVariance;
        private DevExpress.XtraReports.UI.XRLabel gsUserName_1;
        private DevExpress.XtraReports.UI.XRPageInfo DataTime1;
        private DevExpress.XtraReports.UI.XRLabel xrLabel1;
        private DevExpress.XtraReports.UI.XRLabel gsUserID_1;
        private DevExpress.XtraReports.UI.XRPageInfo DataDate1;
        private DevExpress.XtraReports.UI.XRPageInfo PageNofM1;
        private DevExpress.XtraReports.UI.TopMarginBand topMarginBand1;
        private DevExpress.XtraReports.UI.BottomMarginBand bottomMarginBand1;
        private DevExpress.XtraReports.Parameters.Parameter gsUserID;
        private DevExpress.XtraReports.Parameters.Parameter gsUserName;
    }
}

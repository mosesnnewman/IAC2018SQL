namespace IAC2021SQL
{
    partial class XtraReportClosedCustomerEditListTotalsByDueDate
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
            DevExpress.XtraReports.UI.XRSummary xrSummary1 = new DevExpress.XtraReports.UI.XRSummary();
            DevExpress.XtraReports.UI.XRSummary xrSummary2 = new DevExpress.XtraReports.UI.XRSummary();
            DevExpress.XtraReports.UI.XRSummary xrSummary3 = new DevExpress.XtraReports.UI.XRSummary();
            DevExpress.XtraReports.UI.XRSummary xrSummary4 = new DevExpress.XtraReports.UI.XRSummary();
            this.DetailArea1 = new DevExpress.XtraReports.UI.DetailBand();
            this.GroupHeaderArea1 = new DevExpress.XtraReports.UI.GroupHeaderBand();
            this.GroupFooterArea1 = new DevExpress.XtraReports.UI.GroupFooterBand();
            this.ReportHeaderArea1 = new DevExpress.XtraReports.UI.ReportHeaderBand();
            this.PageHeaderArea1 = new DevExpress.XtraReports.UI.PageHeaderBand();
            this.ReportFooterArea1 = new DevExpress.XtraReports.UI.ReportFooterBand();
            this.PageFooterArea1 = new DevExpress.XtraReports.UI.PageFooterBand();
            this.CUSTOMERDAYDUE1 = new DevExpress.XtraReports.UI.XRLabel();
            this.CustomerCount1 = new DevExpress.XtraReports.UI.XRLabel();
            this.TotalLoanAmountbyGroup1 = new DevExpress.XtraReports.UI.XRLabel();
            this.ReportHeaderSection1 = new DevExpress.XtraReports.UI.SubBand();
            this.ReportHeaderSection2 = new DevExpress.XtraReports.UI.SubBand();
            this.Text2 = new DevExpress.XtraReports.UI.XRLabel();
            this.Line7 = new DevExpress.XtraReports.UI.XRLine();
            this.Text3 = new DevExpress.XtraReports.UI.XRLabel();
            this.Text4 = new DevExpress.XtraReports.UI.XRLabel();
            this.Text1 = new DevExpress.XtraReports.UI.XRLabel();
            this.ReportFooterSection1 = new DevExpress.XtraReports.UI.SubBand();
            this.ReportFooterSection2 = new DevExpress.XtraReports.UI.SubBand();
            this.TotalLoanAmount1 = new DevExpress.XtraReports.UI.XRLabel();
            this.Line2 = new DevExpress.XtraReports.UI.XRLine();
            this.GrandTotalCustomerCount1 = new DevExpress.XtraReports.UI.XRLabel();
            ((System.ComponentModel.ISupportInitialize)(this)).BeginInit();
            // 
            // DetailArea1
            // 
            this.DetailArea1.HeightF = 21F;
            this.DetailArea1.KeepTogether = true;
            this.DetailArea1.Name = "DetailArea1";
            this.DetailArea1.Padding = new DevExpress.XtraPrinting.PaddingInfo(0, 0, 0, 0, 100F);
            this.DetailArea1.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopLeft;
            this.DetailArea1.Visible = false;
            // 
            // GroupHeaderArea1
            // 
            this.GroupHeaderArea1.GroupFields.AddRange(new DevExpress.XtraReports.UI.GroupField[] {
            new DevExpress.XtraReports.UI.GroupField("CUSTOMER_DAY_DUE", DevExpress.XtraReports.UI.XRColumnSortOrder.Ascending)});
            this.GroupHeaderArea1.HeightF = 18F;
            this.GroupHeaderArea1.KeepTogether = true;
            this.GroupHeaderArea1.Name = "GroupHeaderArea1";
            this.GroupHeaderArea1.Padding = new DevExpress.XtraPrinting.PaddingInfo(0, 0, 0, 0, 100F);
            this.GroupHeaderArea1.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopLeft;
            this.GroupHeaderArea1.Visible = false;
            // 
            // GroupFooterArea1
            // 
            this.GroupFooterArea1.Controls.AddRange(new DevExpress.XtraReports.UI.XRControl[] {
            this.CUSTOMERDAYDUE1,
            this.CustomerCount1,
            this.TotalLoanAmountbyGroup1});
            this.GroupFooterArea1.HeightF = 23F;
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
            // PageFooterArea1
            // 
            this.PageFooterArea1.HeightF = 41F;
            this.PageFooterArea1.Name = "PageFooterArea1";
            this.PageFooterArea1.Padding = new DevExpress.XtraPrinting.PaddingInfo(0, 0, 0, 0, 100F);
            this.PageFooterArea1.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopLeft;
            // 
            // CUSTOMERDAYDUE1
            // 
            this.CUSTOMERDAYDUE1.BackColor = System.Drawing.Color.Transparent;
            this.CUSTOMERDAYDUE1.BorderColor = System.Drawing.Color.Black;
            this.CUSTOMERDAYDUE1.Borders = DevExpress.XtraPrinting.BorderSide.None;
            this.CUSTOMERDAYDUE1.BorderWidth = 1F;
            this.CUSTOMERDAYDUE1.CanGrow = false;
            this.CUSTOMERDAYDUE1.ExpressionBindings.AddRange(new DevExpress.XtraReports.UI.ExpressionBinding[] {
            new DevExpress.XtraReports.UI.ExpressionBinding("BeforePrint", "Text", "[CUSTOMER_DAY_DUE]")});
            this.CUSTOMERDAYDUE1.Font = new System.Drawing.Font("Arial", 10F);
            this.CUSTOMERDAYDUE1.ForeColor = System.Drawing.Color.Black;
            this.CUSTOMERDAYDUE1.LocationFloat = new DevExpress.Utils.PointFloat(0F, 0F);
            this.CUSTOMERDAYDUE1.Name = "CUSTOMERDAYDUE1";
            this.CUSTOMERDAYDUE1.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.CUSTOMERDAYDUE1.SizeF = new System.Drawing.SizeF(32.29167F, 18.33333F);
            this.CUSTOMERDAYDUE1.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopCenter;
            // 
            // CustomerCount1
            // 
            this.CustomerCount1.BackColor = System.Drawing.Color.Transparent;
            this.CustomerCount1.BorderColor = System.Drawing.Color.Black;
            this.CustomerCount1.Borders = DevExpress.XtraPrinting.BorderSide.None;
            this.CustomerCount1.BorderWidth = 1F;
            this.CustomerCount1.CanGrow = false;
            this.CustomerCount1.ExpressionBindings.AddRange(new DevExpress.XtraReports.UI.ExpressionBinding[] {
            new DevExpress.XtraReports.UI.ExpressionBinding("BeforePrint", "Text", "sumCount([CUSTOMER_NO])")});
            this.CustomerCount1.Font = new System.Drawing.Font("Arial", 10F);
            this.CustomerCount1.ForeColor = System.Drawing.Color.Black;
            this.CustomerCount1.LocationFloat = new DevExpress.Utils.PointFloat(50F, 0F);
            this.CustomerCount1.Name = "CustomerCount1";
            this.CustomerCount1.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.CustomerCount1.SizeF = new System.Drawing.SizeF(32.29167F, 18.33333F);
            xrSummary1.Running = DevExpress.XtraReports.UI.SummaryRunning.Report;
            this.CustomerCount1.Summary = xrSummary1;
            this.CustomerCount1.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopLeft;
            // 
            // TotalLoanAmountbyGroup1
            // 
            this.TotalLoanAmountbyGroup1.BackColor = System.Drawing.Color.Transparent;
            this.TotalLoanAmountbyGroup1.BorderColor = System.Drawing.Color.Black;
            this.TotalLoanAmountbyGroup1.Borders = DevExpress.XtraPrinting.BorderSide.None;
            this.TotalLoanAmountbyGroup1.BorderWidth = 1F;
            this.TotalLoanAmountbyGroup1.CanGrow = false;
            this.TotalLoanAmountbyGroup1.ExpressionBindings.AddRange(new DevExpress.XtraReports.UI.ExpressionBinding[] {
            new DevExpress.XtraReports.UI.ExpressionBinding("BeforePrint", "Text", "sumRunningSum([CUSTOMER_LOAN_AMOUNT])")});
            this.TotalLoanAmountbyGroup1.Font = new System.Drawing.Font("Arial", 10F);
            this.TotalLoanAmountbyGroup1.ForeColor = System.Drawing.Color.Black;
            this.TotalLoanAmountbyGroup1.LocationFloat = new DevExpress.Utils.PointFloat(175F, 0F);
            this.TotalLoanAmountbyGroup1.Name = "TotalLoanAmountbyGroup1";
            this.TotalLoanAmountbyGroup1.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.TotalLoanAmountbyGroup1.SizeF = new System.Drawing.SizeF(111.4583F, 18.33333F);
            xrSummary2.Running = DevExpress.XtraReports.UI.SummaryRunning.Report;
            this.TotalLoanAmountbyGroup1.Summary = xrSummary2;
            this.TotalLoanAmountbyGroup1.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopLeft;
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
            this.ReportHeaderSection2.Controls.AddRange(new DevExpress.XtraReports.UI.XRControl[] {
            this.Text2,
            this.Line7,
            this.Text3,
            this.Text4,
            this.Text1});
            this.ReportHeaderSection2.HeightF = 71F;
            this.ReportHeaderSection2.KeepTogether = true;
            this.ReportHeaderSection2.Name = "ReportHeaderSection2";
            this.ReportHeaderSection2.Padding = new DevExpress.XtraPrinting.PaddingInfo(0, 0, 0, 0, 100F);
            this.ReportHeaderSection2.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopLeft;
            // 
            // Text2
            // 
            this.Text2.BackColor = System.Drawing.Color.Transparent;
            this.Text2.BorderColor = System.Drawing.Color.Black;
            this.Text2.Borders = DevExpress.XtraPrinting.BorderSide.None;
            this.Text2.BorderWidth = 1F;
            this.Text2.CanGrow = false;
            this.Text2.Font = new System.Drawing.Font("Arial", 10F, System.Drawing.FontStyle.Bold);
            this.Text2.ForeColor = System.Drawing.Color.Black;
            this.Text2.LocationFloat = new DevExpress.Utils.PointFloat(0F, 41.66667F);
            this.Text2.Name = "Text2";
            this.Text2.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.Text2.SizeF = new System.Drawing.SizeF(32.29167F, 18.33333F);
            this.Text2.Text = "DAY DUE";
            this.Text2.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopLeft;
            // 
            // Line7
            // 
            this.Line7.BackColor = System.Drawing.Color.Transparent;
            this.Line7.BorderColor = System.Drawing.Color.Navy;
            this.Line7.Borders = DevExpress.XtraPrinting.BorderSide.Top;
            this.Line7.BorderWidth = 1F;
            this.Line7.Font = new System.Drawing.Font("Times New Roman", 9.75F);
            this.Line7.ForeColor = System.Drawing.Color.Navy;
            this.Line7.LineWidth = 3F;
            this.Line7.LocationFloat = new DevExpress.Utils.PointFloat(0F, 65.625F);
            this.Line7.Name = "Line7";
            this.Line7.Padding = new DevExpress.XtraPrinting.PaddingInfo(0, 0, 0, 0, 100F);
            this.Line7.SizeF = new System.Drawing.SizeF(283.3333F, 3.125F);
            // 
            // Text3
            // 
            this.Text3.BackColor = System.Drawing.Color.Transparent;
            this.Text3.BorderColor = System.Drawing.Color.Black;
            this.Text3.Borders = DevExpress.XtraPrinting.BorderSide.None;
            this.Text3.BorderWidth = 1F;
            this.Text3.CanGrow = false;
            this.Text3.Font = new System.Drawing.Font("Arial", 10F, System.Drawing.FontStyle.Bold);
            this.Text3.ForeColor = System.Drawing.Color.Black;
            this.Text3.LocationFloat = new DevExpress.Utils.PointFloat(41.66667F, 41.66667F);
            this.Text3.Name = "Text3";
            this.Text3.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.Text3.SizeF = new System.Drawing.SizeF(116.6667F, 18.33333F);
            this.Text3.Text = "# OF ACCOUNTS";
            this.Text3.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopLeft;
            // 
            // Text4
            // 
            this.Text4.BackColor = System.Drawing.Color.Transparent;
            this.Text4.BorderColor = System.Drawing.Color.Black;
            this.Text4.Borders = DevExpress.XtraPrinting.BorderSide.None;
            this.Text4.BorderWidth = 1F;
            this.Text4.CanGrow = false;
            this.Text4.Font = new System.Drawing.Font("Arial", 10F, System.Drawing.FontStyle.Bold);
            this.Text4.ForeColor = System.Drawing.Color.Black;
            this.Text4.LocationFloat = new DevExpress.Utils.PointFloat(175F, 41.66667F);
            this.Text4.Name = "Text4";
            this.Text4.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.Text4.SizeF = new System.Drawing.SizeF(108.3333F, 18.33333F);
            this.Text4.Text = "LOAN AMOUNT";
            this.Text4.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopLeft;
            // 
            // Text1
            // 
            this.Text1.BackColor = System.Drawing.Color.Transparent;
            this.Text1.BorderColor = System.Drawing.Color.Black;
            this.Text1.Borders = DevExpress.XtraPrinting.BorderSide.None;
            this.Text1.BorderWidth = 1F;
            this.Text1.CanGrow = false;
            this.Text1.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.Text1.ForeColor = System.Drawing.Color.Black;
            this.Text1.LocationFloat = new DevExpress.Utils.PointFloat(66.66666F, 8.333333F);
            this.Text1.Name = "Text1";
            this.Text1.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.Text1.SizeF = new System.Drawing.SizeF(154.5833F, 18.33333F);
            this.Text1.Text = "TOTALS BY DUE DATE";
            this.Text1.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopLeft;
            // 
            // ReportFooterSection1
            // 
            this.ReportFooterSection1.Controls.AddRange(new DevExpress.XtraReports.UI.XRControl[] {
            this.TotalLoanAmount1,
            this.Line2,
            this.GrandTotalCustomerCount1});
            this.ReportFooterSection1.HeightF = 26.66667F;
            this.ReportFooterSection1.KeepTogether = true;
            this.ReportFooterSection1.Name = "ReportFooterSection1";
            this.ReportFooterSection1.Padding = new DevExpress.XtraPrinting.PaddingInfo(0, 0, 0, 0, 100F);
            this.ReportFooterSection1.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopLeft;
            // 
            // ReportFooterSection2
            // 
            this.ReportFooterSection2.HeightF = 51F;
            this.ReportFooterSection2.KeepTogether = true;
            this.ReportFooterSection2.Name = "ReportFooterSection2";
            this.ReportFooterSection2.Padding = new DevExpress.XtraPrinting.PaddingInfo(0, 0, 0, 0, 100F);
            this.ReportFooterSection2.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopLeft;
            // 
            // TotalLoanAmount1
            // 
            this.TotalLoanAmount1.BackColor = System.Drawing.Color.Transparent;
            this.TotalLoanAmount1.BorderColor = System.Drawing.Color.Black;
            this.TotalLoanAmount1.Borders = DevExpress.XtraPrinting.BorderSide.None;
            this.TotalLoanAmount1.BorderWidth = 1F;
            this.TotalLoanAmount1.CanGrow = false;
            this.TotalLoanAmount1.ExpressionBindings.AddRange(new DevExpress.XtraReports.UI.ExpressionBinding[] {
            new DevExpress.XtraReports.UI.ExpressionBinding("BeforePrint", "Text", "sumRunningSum([CUSTOMER_LOAN_AMOUNT])")});
            this.TotalLoanAmount1.Font = new System.Drawing.Font("Arial", 10F, System.Drawing.FontStyle.Bold);
            this.TotalLoanAmount1.ForeColor = System.Drawing.Color.Black;
            this.TotalLoanAmount1.LocationFloat = new DevExpress.Utils.PointFloat(175F, 8.333333F);
            this.TotalLoanAmount1.Name = "TotalLoanAmount1";
            this.TotalLoanAmount1.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.TotalLoanAmount1.SizeF = new System.Drawing.SizeF(111.4583F, 18.33333F);
            xrSummary3.Running = DevExpress.XtraReports.UI.SummaryRunning.Report;
            this.TotalLoanAmount1.Summary = xrSummary3;
            this.TotalLoanAmount1.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopRight;
            // 
            // Line2
            // 
            this.Line2.BackColor = System.Drawing.Color.Transparent;
            this.Line2.BorderColor = System.Drawing.Color.Black;
            this.Line2.Borders = DevExpress.XtraPrinting.BorderSide.Top;
            this.Line2.BorderWidth = 1F;
            this.Line2.Font = new System.Drawing.Font("Times New Roman", 9.75F);
            this.Line2.ForeColor = System.Drawing.Color.Black;
            this.Line2.LineWidth = 3F;
            this.Line2.LocationFloat = new DevExpress.Utils.PointFloat(58.33333F, 7.222222F);
            this.Line2.Name = "Line2";
            this.Line2.Padding = new DevExpress.XtraPrinting.PaddingInfo(0, 0, 0, 0, 100F);
            this.Line2.SizeF = new System.Drawing.SizeF(225F, 3.125F);
            // 
            // GrandTotalCustomerCount1
            // 
            this.GrandTotalCustomerCount1.BackColor = System.Drawing.Color.Transparent;
            this.GrandTotalCustomerCount1.BorderColor = System.Drawing.Color.Black;
            this.GrandTotalCustomerCount1.Borders = DevExpress.XtraPrinting.BorderSide.None;
            this.GrandTotalCustomerCount1.BorderWidth = 1F;
            this.GrandTotalCustomerCount1.CanGrow = false;
            this.GrandTotalCustomerCount1.ExpressionBindings.AddRange(new DevExpress.XtraReports.UI.ExpressionBinding[] {
            new DevExpress.XtraReports.UI.ExpressionBinding("BeforePrint", "Text", "sumCount([CUSTOMER_NO])")});
            this.GrandTotalCustomerCount1.Font = new System.Drawing.Font("Arial", 10F, System.Drawing.FontStyle.Bold);
            this.GrandTotalCustomerCount1.ForeColor = System.Drawing.Color.Black;
            this.GrandTotalCustomerCount1.LocationFloat = new DevExpress.Utils.PointFloat(50F, 8.333333F);
            this.GrandTotalCustomerCount1.Name = "GrandTotalCustomerCount1";
            this.GrandTotalCustomerCount1.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.GrandTotalCustomerCount1.SizeF = new System.Drawing.SizeF(32.29167F, 18.33333F);
            xrSummary4.Running = DevExpress.XtraReports.UI.SummaryRunning.Report;
            this.GrandTotalCustomerCount1.Summary = xrSummary4;
            this.GrandTotalCustomerCount1.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopLeft;
            // 
            // XtraReportClosedCustomerEditListTotalsByDueDate
            // 
            this.Bands.AddRange(new DevExpress.XtraReports.UI.Band[] {
            this.DetailArea1,
            this.GroupHeaderArea1,
            this.GroupFooterArea1,
            this.ReportHeaderArea1,
            this.PageHeaderArea1,
            this.ReportFooterArea1,
            this.PageFooterArea1});
            this.Landscape = true;
            this.Margins = new System.Drawing.Printing.Margins(11, 11, 11, 11);
            this.PageHeight = 850;
            this.PageWidth = 1100;
            this.Version = "22.1";
            ((System.ComponentModel.ISupportInitialize)(this)).EndInit();

        }

        #endregion

        private DevExpress.XtraReports.UI.DetailBand DetailArea1;
        private DevExpress.XtraReports.UI.GroupHeaderBand GroupHeaderArea1;
        private DevExpress.XtraReports.UI.GroupFooterBand GroupFooterArea1;
        private DevExpress.XtraReports.UI.XRLabel CUSTOMERDAYDUE1;
        private DevExpress.XtraReports.UI.XRLabel CustomerCount1;
        private DevExpress.XtraReports.UI.XRLabel TotalLoanAmountbyGroup1;
        private DevExpress.XtraReports.UI.ReportHeaderBand ReportHeaderArea1;
        private DevExpress.XtraReports.UI.SubBand ReportHeaderSection1;
        private DevExpress.XtraReports.UI.SubBand ReportHeaderSection2;
        private DevExpress.XtraReports.UI.XRLabel Text2;
        private DevExpress.XtraReports.UI.XRLine Line7;
        private DevExpress.XtraReports.UI.XRLabel Text3;
        private DevExpress.XtraReports.UI.XRLabel Text4;
        private DevExpress.XtraReports.UI.XRLabel Text1;
        private DevExpress.XtraReports.UI.PageHeaderBand PageHeaderArea1;
        private DevExpress.XtraReports.UI.ReportFooterBand ReportFooterArea1;
        private DevExpress.XtraReports.UI.SubBand ReportFooterSection1;
        private DevExpress.XtraReports.UI.XRLabel TotalLoanAmount1;
        private DevExpress.XtraReports.UI.XRLine Line2;
        private DevExpress.XtraReports.UI.XRLabel GrandTotalCustomerCount1;
        private DevExpress.XtraReports.UI.SubBand ReportFooterSection2;
        private DevExpress.XtraReports.UI.PageFooterBand PageFooterArea1;
    }
}

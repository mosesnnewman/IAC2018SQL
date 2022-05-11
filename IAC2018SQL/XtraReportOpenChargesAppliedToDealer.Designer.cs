namespace IAC2021SQL
{
    partial class XtraReportOpenChargesAppliedToDealer
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(XtraReportOpenChargesAppliedToDealer));
            DevExpress.XtraReports.UI.XRSummary xrSummary1 = new DevExpress.XtraReports.UI.XRSummary();
            DevExpress.XtraReports.UI.XRSummary xrSummary2 = new DevExpress.XtraReports.UI.XRSummary();
            DevExpress.XtraReports.UI.XRSummary xrSummary3 = new DevExpress.XtraReports.UI.XRSummary();
            DevExpress.DataAccess.Sql.StoredProcQuery storedProcQuery1 = new DevExpress.DataAccess.Sql.StoredProcQuery();
            DevExpress.DataAccess.Sql.QueryParameter queryParameter1 = new DevExpress.DataAccess.Sql.QueryParameter();
            DevExpress.DataAccess.Sql.QueryParameter queryParameter2 = new DevExpress.DataAccess.Sql.QueryParameter();
            DevExpress.DataAccess.Sql.QueryParameter queryParameter3 = new DevExpress.DataAccess.Sql.QueryParameter();
            this.Area3 = new DevExpress.XtraReports.UI.DetailBand();
            this.OPNDEALRACCNO1 = new DevExpress.XtraReports.UI.XRLabel();
            this.OPNDEALRNAME1 = new DevExpress.XtraReports.UI.XRLabel();
            this.FinanceCharges1 = new DevExpress.XtraReports.UI.XRLabel();
            this.LateFees1 = new DevExpress.XtraReports.UI.XRLabel();
            this.ISFCFees1 = new DevExpress.XtraReports.UI.XRLabel();
            this.Area1 = new DevExpress.XtraReports.UI.ReportHeaderBand();
            this.Picture1 = new DevExpress.XtraReports.UI.XRPictureBox();
            this.Text2 = new DevExpress.XtraReports.UI.XRLabel();
            this.gdCutOffDate1 = new DevExpress.XtraReports.UI.XRLabel();
            this.Text33 = new DevExpress.XtraReports.UI.XRLabel();
            this.Text34 = new DevExpress.XtraReports.UI.XRLabel();
            this.gdToDate1 = new DevExpress.XtraReports.UI.XRLabel();
            this.Area2 = new DevExpress.XtraReports.UI.PageHeaderBand();
            this.Text4 = new DevExpress.XtraReports.UI.XRLabel();
            this.Line1 = new DevExpress.XtraReports.UI.XRLine();
            this.Text19 = new DevExpress.XtraReports.UI.XRLabel();
            this.Text3 = new DevExpress.XtraReports.UI.XRLabel();
            this.Text1 = new DevExpress.XtraReports.UI.XRLabel();
            this.Area4 = new DevExpress.XtraReports.UI.ReportFooterBand();
            this.TotalLateFees1 = new DevExpress.XtraReports.UI.XRLabel();
            this.TotalISFCFees1 = new DevExpress.XtraReports.UI.XRLabel();
            this.Line3 = new DevExpress.XtraReports.UI.XRLine();
            this.Text9 = new DevExpress.XtraReports.UI.XRLabel();
            this.TotalFinanceCharges1 = new DevExpress.XtraReports.UI.XRLabel();
            this.Area5 = new DevExpress.XtraReports.UI.PageFooterBand();
            this.PageNofM1 = new DevExpress.XtraReports.UI.XRPageInfo();
            this.DataDate1 = new DevExpress.XtraReports.UI.XRPageInfo();
            this.DataTime1 = new DevExpress.XtraReports.UI.XRPageInfo();
            this.gsUserName_1 = new DevExpress.XtraReports.UI.XRLabel();
            this.gsUserID_1 = new DevExpress.XtraReports.UI.XRLabel();
            this.Text5 = new DevExpress.XtraReports.UI.XRLabel();
            this.gdFromDate = new DevExpress.XtraReports.Parameters.Parameter();
            this.gsUserName = new DevExpress.XtraReports.Parameters.Parameter();
            this.gsUserID = new DevExpress.XtraReports.Parameters.Parameter();
            this.gdToDate = new DevExpress.XtraReports.Parameters.Parameter();
            this.topMarginBand1 = new DevExpress.XtraReports.UI.TopMarginBand();
            this.bottomMarginBand1 = new DevExpress.XtraReports.UI.BottomMarginBand();
            this.sqlDataSource1 = new DevExpress.DataAccess.Sql.SqlDataSource(this.components);
            ((System.ComponentModel.ISupportInitialize)(this)).BeginInit();
            // 
            // Area3
            // 
            this.Area3.Controls.AddRange(new DevExpress.XtraReports.UI.XRControl[] {
            this.OPNDEALRACCNO1,
            this.OPNDEALRNAME1,
            this.FinanceCharges1,
            this.LateFees1,
            this.ISFCFees1});
            this.Area3.HeightF = 17F;
            this.Area3.KeepTogether = true;
            this.Area3.Name = "Area3";
            this.Area3.Padding = new DevExpress.XtraPrinting.PaddingInfo(0, 0, 0, 0, 100F);
            this.Area3.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopLeft;
            // 
            // OPNDEALRACCNO1
            // 
            this.OPNDEALRACCNO1.BackColor = System.Drawing.Color.Transparent;
            this.OPNDEALRACCNO1.BorderColor = System.Drawing.Color.Black;
            this.OPNDEALRACCNO1.Borders = DevExpress.XtraPrinting.BorderSide.None;
            this.OPNDEALRACCNO1.BorderWidth = 1F;
            this.OPNDEALRACCNO1.CanGrow = false;
            this.OPNDEALRACCNO1.ExpressionBindings.AddRange(new DevExpress.XtraReports.UI.ExpressionBinding[] {
            new DevExpress.XtraReports.UI.ExpressionBinding("BeforePrint", "Text", "[OPNDEALR_ACC_NO]")});
            this.OPNDEALRACCNO1.Font = new System.Drawing.Font("Arial", 10F);
            this.OPNDEALRACCNO1.ForeColor = System.Drawing.Color.Black;
            this.OPNDEALRACCNO1.LocationFloat = new DevExpress.Utils.PointFloat(8.333333F, 0F);
            this.OPNDEALRACCNO1.Name = "OPNDEALRACCNO1";
            this.OPNDEALRACCNO1.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.OPNDEALRACCNO1.SizeF = new System.Drawing.SizeF(43.75F, 15.34722F);
            this.OPNDEALRACCNO1.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopLeft;
            // 
            // OPNDEALRNAME1
            // 
            this.OPNDEALRNAME1.BackColor = System.Drawing.Color.Transparent;
            this.OPNDEALRNAME1.BorderColor = System.Drawing.Color.Black;
            this.OPNDEALRNAME1.Borders = DevExpress.XtraPrinting.BorderSide.None;
            this.OPNDEALRNAME1.BorderWidth = 1F;
            this.OPNDEALRNAME1.CanGrow = false;
            this.OPNDEALRNAME1.ExpressionBindings.AddRange(new DevExpress.XtraReports.UI.ExpressionBinding[] {
            new DevExpress.XtraReports.UI.ExpressionBinding("BeforePrint", "Text", "[OPNDEALR_NAME]")});
            this.OPNDEALRNAME1.Font = new System.Drawing.Font("Arial", 10F);
            this.OPNDEALRNAME1.ForeColor = System.Drawing.Color.Black;
            this.OPNDEALRNAME1.LocationFloat = new DevExpress.Utils.PointFloat(59.375F, 0F);
            this.OPNDEALRNAME1.Name = "OPNDEALRNAME1";
            this.OPNDEALRNAME1.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.OPNDEALRNAME1.SizeF = new System.Drawing.SizeF(261.4583F, 15.34722F);
            this.OPNDEALRNAME1.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopLeft;
            // 
            // FinanceCharges1
            // 
            this.FinanceCharges1.BackColor = System.Drawing.Color.Transparent;
            this.FinanceCharges1.BorderColor = System.Drawing.Color.Black;
            this.FinanceCharges1.Borders = DevExpress.XtraPrinting.BorderSide.None;
            this.FinanceCharges1.BorderWidth = 1F;
            this.FinanceCharges1.CanGrow = false;
            this.FinanceCharges1.ExpressionBindings.AddRange(new DevExpress.XtraReports.UI.ExpressionBinding[] {
            new DevExpress.XtraReports.UI.ExpressionBinding("BeforePrint", "Text", "[FinanceCharges]")});
            this.FinanceCharges1.Font = new System.Drawing.Font("Arial", 10F);
            this.FinanceCharges1.ForeColor = System.Drawing.Color.Black;
            this.FinanceCharges1.LocationFloat = new DevExpress.Utils.PointFloat(508.3333F, 0F);
            this.FinanceCharges1.Name = "FinanceCharges1";
            this.FinanceCharges1.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.FinanceCharges1.SizeF = new System.Drawing.SizeF(135.4167F, 15.34722F);
            this.FinanceCharges1.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopRight;
            this.FinanceCharges1.TextFormatString = "{0:C2}";
            // 
            // LateFees1
            // 
            this.LateFees1.BackColor = System.Drawing.Color.Transparent;
            this.LateFees1.BorderColor = System.Drawing.Color.Black;
            this.LateFees1.Borders = DevExpress.XtraPrinting.BorderSide.None;
            this.LateFees1.BorderWidth = 1F;
            this.LateFees1.CanGrow = false;
            this.LateFees1.ExpressionBindings.AddRange(new DevExpress.XtraReports.UI.ExpressionBinding[] {
            new DevExpress.XtraReports.UI.ExpressionBinding("BeforePrint", "Text", "[LateFees]")});
            this.LateFees1.Font = new System.Drawing.Font("Arial", 10F);
            this.LateFees1.ForeColor = System.Drawing.Color.Black;
            this.LateFees1.LocationFloat = new DevExpress.Utils.PointFloat(666.6667F, 0F);
            this.LateFees1.Name = "LateFees1";
            this.LateFees1.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.LateFees1.SizeF = new System.Drawing.SizeF(135.4167F, 15.34722F);
            this.LateFees1.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopRight;
            this.LateFees1.TextFormatString = "{0:C2}";
            // 
            // ISFCFees1
            // 
            this.ISFCFees1.BackColor = System.Drawing.Color.Transparent;
            this.ISFCFees1.BorderColor = System.Drawing.Color.Black;
            this.ISFCFees1.Borders = DevExpress.XtraPrinting.BorderSide.None;
            this.ISFCFees1.BorderWidth = 1F;
            this.ISFCFees1.CanGrow = false;
            this.ISFCFees1.ExpressionBindings.AddRange(new DevExpress.XtraReports.UI.ExpressionBinding[] {
            new DevExpress.XtraReports.UI.ExpressionBinding("BeforePrint", "Text", "[ISFCFees]")});
            this.ISFCFees1.Font = new System.Drawing.Font("Arial", 10F);
            this.ISFCFees1.ForeColor = System.Drawing.Color.Black;
            this.ISFCFees1.LocationFloat = new DevExpress.Utils.PointFloat(816.6667F, 0F);
            this.ISFCFees1.Name = "ISFCFees1";
            this.ISFCFees1.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.ISFCFees1.SizeF = new System.Drawing.SizeF(135.4166F, 15.34722F);
            this.ISFCFees1.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopRight;
            this.ISFCFees1.TextFormatString = "{0:C2}";
            // 
            // Area1
            // 
            this.Area1.Controls.AddRange(new DevExpress.XtraReports.UI.XRControl[] {
            this.Picture1,
            this.Text2,
            this.gdCutOffDate1,
            this.Text33,
            this.Text34,
            this.gdToDate1});
            this.Area1.HeightF = 163.9167F;
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
            this.Picture1.Font = new System.Drawing.Font("Times New Roman", 9.75F);
            this.Picture1.ForeColor = System.Drawing.Color.Black;
            this.Picture1.ImageSource = new DevExpress.XtraPrinting.Drawing.ImageSource("img", resources.GetString("Picture1.ImageSource"));
            this.Picture1.LocationFloat = new DevExpress.Utils.PointFloat(813.6111F, 0F);
            this.Picture1.Name = "Picture1";
            this.Picture1.Padding = new DevExpress.XtraPrinting.PaddingInfo(0, 0, 0, 0, 100F);
            this.Picture1.SizeF = new System.Drawing.SizeF(246.3889F, 95F);
            // 
            // Text2
            // 
            this.Text2.BackColor = System.Drawing.Color.Transparent;
            this.Text2.BorderColor = System.Drawing.Color.Black;
            this.Text2.Borders = DevExpress.XtraPrinting.BorderSide.None;
            this.Text2.BorderWidth = 1F;
            this.Text2.CanGrow = false;
            this.Text2.Font = new System.Drawing.Font("Arial", 14F);
            this.Text2.ForeColor = System.Drawing.Color.Black;
            this.Text2.LocationFloat = new DevExpress.Utils.PointFloat(0.8334961F, 101.1945F);
            this.Text2.Name = "Text2";
            this.Text2.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.Text2.SizeF = new System.Drawing.SizeF(1058.333F, 25F);
            this.Text2.Text = "OPEN CHARGES APPLIED TO DEALER REPORT";
            this.Text2.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopCenter;
            // 
            // gdCutOffDate1
            // 
            this.gdCutOffDate1.BackColor = System.Drawing.Color.Transparent;
            this.gdCutOffDate1.BorderColor = System.Drawing.Color.Black;
            this.gdCutOffDate1.Borders = DevExpress.XtraPrinting.BorderSide.None;
            this.gdCutOffDate1.BorderWidth = 1F;
            this.gdCutOffDate1.CanGrow = false;
            this.gdCutOffDate1.ExpressionBindings.AddRange(new DevExpress.XtraReports.UI.ExpressionBinding[] {
            new DevExpress.XtraReports.UI.ExpressionBinding("BeforePrint", "Text", "?gdFromDate")});
            this.gdCutOffDate1.Font = new System.Drawing.Font("Arial", 10F);
            this.gdCutOffDate1.ForeColor = System.Drawing.Color.Black;
            this.gdCutOffDate1.LocationFloat = new DevExpress.Utils.PointFloat(521.5F, 126.1945F);
            this.gdCutOffDate1.Name = "gdCutOffDate1";
            this.gdCutOffDate1.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.gdCutOffDate1.SizeF = new System.Drawing.SizeF(108.3333F, 15.34722F);
            this.gdCutOffDate1.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopLeft;
            this.gdCutOffDate1.TextFormatString = "{0:MM/dd/yyyy}";
            // 
            // Text33
            // 
            this.Text33.BackColor = System.Drawing.Color.Transparent;
            this.Text33.BorderColor = System.Drawing.Color.Black;
            this.Text33.Borders = DevExpress.XtraPrinting.BorderSide.None;
            this.Text33.BorderWidth = 1F;
            this.Text33.CanGrow = false;
            this.Text33.Font = new System.Drawing.Font("Arial", 10F, System.Drawing.FontStyle.Bold);
            this.Text33.ForeColor = System.Drawing.Color.Black;
            this.Text33.LocationFloat = new DevExpress.Utils.PointFloat(454.8333F, 126.1945F);
            this.Text33.Name = "Text33";
            this.Text33.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.Text33.SizeF = new System.Drawing.SizeF(50F, 15.34722F);
            this.Text33.Text = "FROM:";
            this.Text33.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopRight;
            // 
            // Text34
            // 
            this.Text34.BackColor = System.Drawing.Color.Transparent;
            this.Text34.BorderColor = System.Drawing.Color.Black;
            this.Text34.Borders = DevExpress.XtraPrinting.BorderSide.None;
            this.Text34.BorderWidth = 1F;
            this.Text34.CanGrow = false;
            this.Text34.Font = new System.Drawing.Font("Arial", 10F, System.Drawing.FontStyle.Bold);
            this.Text34.ForeColor = System.Drawing.Color.Black;
            this.Text34.LocationFloat = new DevExpress.Utils.PointFloat(454.8333F, 142.8611F);
            this.Text34.Name = "Text34";
            this.Text34.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.Text34.SizeF = new System.Drawing.SizeF(50F, 15.34721F);
            this.Text34.Text = "TO: ";
            this.Text34.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopRight;
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
            this.gdToDate1.Font = new System.Drawing.Font("Arial", 10F);
            this.gdToDate1.ForeColor = System.Drawing.Color.Black;
            this.gdToDate1.LocationFloat = new DevExpress.Utils.PointFloat(521.5F, 142.8611F);
            this.gdToDate1.Name = "gdToDate1";
            this.gdToDate1.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.gdToDate1.SizeF = new System.Drawing.SizeF(108.3333F, 15.34721F);
            this.gdToDate1.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopLeft;
            this.gdToDate1.TextFormatString = "{0:MM/dd/yyyy}";
            // 
            // Area2
            // 
            this.Area2.Controls.AddRange(new DevExpress.XtraReports.UI.XRControl[] {
            this.Text4,
            this.Line1,
            this.Text19,
            this.Text3,
            this.Text1});
            this.Area2.HeightF = 25F;
            this.Area2.Name = "Area2";
            this.Area2.Padding = new DevExpress.XtraPrinting.PaddingInfo(0, 0, 0, 0, 100F);
            this.Area2.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopLeft;
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
            this.Text4.LocationFloat = new DevExpress.Utils.PointFloat(666.6667F, 0F);
            this.Text4.Name = "Text4";
            this.Text4.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.Text4.SizeF = new System.Drawing.SizeF(135.4167F, 15.34722F);
            this.Text4.Text = "LATE FEES";
            this.Text4.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopCenter;
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
            this.Line1.LocationFloat = new DevExpress.Utils.PointFloat(8.333333F, 16.66667F);
            this.Line1.Name = "Line1";
            this.Line1.Padding = new DevExpress.XtraPrinting.PaddingInfo(0, 0, 0, 0, 100F);
            this.Line1.SizeF = new System.Drawing.SizeF(1041.667F, 3.125F);
            // 
            // Text19
            // 
            this.Text19.BackColor = System.Drawing.Color.Transparent;
            this.Text19.BorderColor = System.Drawing.Color.Black;
            this.Text19.Borders = DevExpress.XtraPrinting.BorderSide.None;
            this.Text19.BorderWidth = 1F;
            this.Text19.CanGrow = false;
            this.Text19.Font = new System.Drawing.Font("Arial", 10F, System.Drawing.FontStyle.Bold);
            this.Text19.ForeColor = System.Drawing.Color.Black;
            this.Text19.LocationFloat = new DevExpress.Utils.PointFloat(816.6667F, 0F);
            this.Text19.Name = "Text19";
            this.Text19.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.Text19.SizeF = new System.Drawing.SizeF(135.4166F, 15.34722F);
            this.Text19.Text = "ISFC FEES";
            this.Text19.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopCenter;
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
            this.Text3.LocationFloat = new DevExpress.Utils.PointFloat(8.333333F, 0F);
            this.Text3.Name = "Text3";
            this.Text3.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.Text3.SizeF = new System.Drawing.SizeF(71.875F, 15.34722F);
            this.Text3.Text = "DEALER";
            this.Text3.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopLeft;
            // 
            // Text1
            // 
            this.Text1.BackColor = System.Drawing.Color.Transparent;
            this.Text1.BorderColor = System.Drawing.Color.Black;
            this.Text1.Borders = DevExpress.XtraPrinting.BorderSide.None;
            this.Text1.BorderWidth = 1F;
            this.Text1.CanGrow = false;
            this.Text1.Font = new System.Drawing.Font("Arial", 10F, System.Drawing.FontStyle.Bold);
            this.Text1.ForeColor = System.Drawing.Color.Black;
            this.Text1.LocationFloat = new DevExpress.Utils.PointFloat(508.3333F, 0F);
            this.Text1.Name = "Text1";
            this.Text1.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.Text1.SizeF = new System.Drawing.SizeF(142.7083F, 15.34722F);
            this.Text1.Text = "FINANCE CHARGES";
            this.Text1.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopCenter;
            // 
            // Area4
            // 
            this.Area4.Controls.AddRange(new DevExpress.XtraReports.UI.XRControl[] {
            this.TotalLateFees1,
            this.TotalISFCFees1,
            this.Line3,
            this.Text9,
            this.TotalFinanceCharges1});
            this.Area4.HeightF = 26F;
            this.Area4.KeepTogether = true;
            this.Area4.Name = "Area4";
            this.Area4.Padding = new DevExpress.XtraPrinting.PaddingInfo(0, 0, 0, 0, 100F);
            this.Area4.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopLeft;
            // 
            // TotalLateFees1
            // 
            this.TotalLateFees1.BackColor = System.Drawing.Color.Transparent;
            this.TotalLateFees1.BorderColor = System.Drawing.Color.Black;
            this.TotalLateFees1.Borders = DevExpress.XtraPrinting.BorderSide.None;
            this.TotalLateFees1.BorderWidth = 1F;
            this.TotalLateFees1.CanGrow = false;
            this.TotalLateFees1.ExpressionBindings.AddRange(new DevExpress.XtraReports.UI.ExpressionBinding[] {
            new DevExpress.XtraReports.UI.ExpressionBinding("BeforePrint", "Text", "sumRunningSum([LateFees])")});
            this.TotalLateFees1.Font = new System.Drawing.Font("Arial", 10F, System.Drawing.FontStyle.Bold);
            this.TotalLateFees1.ForeColor = System.Drawing.Color.Black;
            this.TotalLateFees1.LocationFloat = new DevExpress.Utils.PointFloat(666.6667F, 8.333333F);
            this.TotalLateFees1.Name = "TotalLateFees1";
            this.TotalLateFees1.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.TotalLateFees1.SizeF = new System.Drawing.SizeF(135.4167F, 15.34722F);
            xrSummary1.Running = DevExpress.XtraReports.UI.SummaryRunning.Report;
            this.TotalLateFees1.Summary = xrSummary1;
            this.TotalLateFees1.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopRight;
            this.TotalLateFees1.TextFormatString = "{0:C2}";
            // 
            // TotalISFCFees1
            // 
            this.TotalISFCFees1.BackColor = System.Drawing.Color.Transparent;
            this.TotalISFCFees1.BorderColor = System.Drawing.Color.Black;
            this.TotalISFCFees1.Borders = DevExpress.XtraPrinting.BorderSide.None;
            this.TotalISFCFees1.BorderWidth = 1F;
            this.TotalISFCFees1.CanGrow = false;
            this.TotalISFCFees1.ExpressionBindings.AddRange(new DevExpress.XtraReports.UI.ExpressionBinding[] {
            new DevExpress.XtraReports.UI.ExpressionBinding("BeforePrint", "Text", "sumRunningSum([ISFCFees])")});
            this.TotalISFCFees1.Font = new System.Drawing.Font("Arial", 10F, System.Drawing.FontStyle.Bold);
            this.TotalISFCFees1.ForeColor = System.Drawing.Color.Black;
            this.TotalISFCFees1.LocationFloat = new DevExpress.Utils.PointFloat(814.5833F, 8.333333F);
            this.TotalISFCFees1.Name = "TotalISFCFees1";
            this.TotalISFCFees1.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.TotalISFCFees1.SizeF = new System.Drawing.SizeF(135.4167F, 15.34722F);
            xrSummary2.Running = DevExpress.XtraReports.UI.SummaryRunning.Report;
            this.TotalISFCFees1.Summary = xrSummary2;
            this.TotalISFCFees1.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopRight;
            this.TotalISFCFees1.TextFormatString = "{0:C2}";
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
            this.Line3.LocationFloat = new DevExpress.Utils.PointFloat(12.5F, 0F);
            this.Line3.Name = "Line3";
            this.Line3.Padding = new DevExpress.XtraPrinting.PaddingInfo(0, 0, 0, 0, 100F);
            this.Line3.SizeF = new System.Drawing.SizeF(1041.667F, 3.125F);
            // 
            // Text9
            // 
            this.Text9.BackColor = System.Drawing.Color.Transparent;
            this.Text9.BorderColor = System.Drawing.Color.Black;
            this.Text9.Borders = DevExpress.XtraPrinting.BorderSide.None;
            this.Text9.BorderWidth = 1F;
            this.Text9.CanGrow = false;
            this.Text9.Font = new System.Drawing.Font("Arial", 10F, System.Drawing.FontStyle.Bold);
            this.Text9.ForeColor = System.Drawing.Color.Black;
            this.Text9.LocationFloat = new DevExpress.Utils.PointFloat(8.333333F, 8.333333F);
            this.Text9.Name = "Text9";
            this.Text9.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.Text9.SizeF = new System.Drawing.SizeF(59.375F, 15.34722F);
            this.Text9.Text = "TOTALS";
            this.Text9.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopLeft;
            // 
            // TotalFinanceCharges1
            // 
            this.TotalFinanceCharges1.BackColor = System.Drawing.Color.Transparent;
            this.TotalFinanceCharges1.BorderColor = System.Drawing.Color.Black;
            this.TotalFinanceCharges1.Borders = DevExpress.XtraPrinting.BorderSide.None;
            this.TotalFinanceCharges1.BorderWidth = 1F;
            this.TotalFinanceCharges1.CanGrow = false;
            this.TotalFinanceCharges1.ExpressionBindings.AddRange(new DevExpress.XtraReports.UI.ExpressionBinding[] {
            new DevExpress.XtraReports.UI.ExpressionBinding("BeforePrint", "Text", "sumRunningSum([FinanceCharges])")});
            this.TotalFinanceCharges1.Font = new System.Drawing.Font("Arial", 10F, System.Drawing.FontStyle.Bold);
            this.TotalFinanceCharges1.ForeColor = System.Drawing.Color.Black;
            this.TotalFinanceCharges1.LocationFloat = new DevExpress.Utils.PointFloat(508.3333F, 8.333333F);
            this.TotalFinanceCharges1.Name = "TotalFinanceCharges1";
            this.TotalFinanceCharges1.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.TotalFinanceCharges1.SizeF = new System.Drawing.SizeF(135.4167F, 15.34722F);
            xrSummary3.Running = DevExpress.XtraReports.UI.SummaryRunning.Report;
            this.TotalFinanceCharges1.Summary = xrSummary3;
            this.TotalFinanceCharges1.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopRight;
            this.TotalFinanceCharges1.TextFormatString = "{0:C2}";
            // 
            // Area5
            // 
            this.Area5.Controls.AddRange(new DevExpress.XtraReports.UI.XRControl[] {
            this.PageNofM1,
            this.DataDate1,
            this.DataTime1,
            this.gsUserName_1,
            this.gsUserID_1,
            this.Text5});
            this.Area5.HeightF = 31F;
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
            this.PageNofM1.Font = new System.Drawing.Font("Arial", 8F);
            this.PageNofM1.ForeColor = System.Drawing.Color.Black;
            this.PageNofM1.LocationFloat = new DevExpress.Utils.PointFloat(891.6667F, 0F);
            this.PageNofM1.Name = "PageNofM1";
            this.PageNofM1.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.PageNofM1.SizeF = new System.Drawing.SizeF(158.3333F, 18.33333F);
            this.PageNofM1.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopLeft;
            // 
            // DataDate1
            // 
            this.DataDate1.BackColor = System.Drawing.Color.Transparent;
            this.DataDate1.BorderColor = System.Drawing.Color.Black;
            this.DataDate1.Borders = DevExpress.XtraPrinting.BorderSide.None;
            this.DataDate1.BorderWidth = 1F;
            this.DataDate1.Font = new System.Drawing.Font("Arial", 8F);
            this.DataDate1.ForeColor = System.Drawing.Color.Black;
            this.DataDate1.LocationFloat = new DevExpress.Utils.PointFloat(10.41667F, 0F);
            this.DataDate1.Name = "DataDate1";
            this.DataDate1.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.DataDate1.PageInfo = DevExpress.XtraPrinting.PageInfo.DateTime;
            this.DataDate1.SizeF = new System.Drawing.SizeF(55.48611F, 12.84722F);
            this.DataDate1.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopLeft;
            this.DataDate1.TextFormatString = "{0:MM/dd/yyyy}";
            // 
            // DataTime1
            // 
            this.DataTime1.BackColor = System.Drawing.Color.Transparent;
            this.DataTime1.BorderColor = System.Drawing.Color.Black;
            this.DataTime1.Borders = DevExpress.XtraPrinting.BorderSide.None;
            this.DataTime1.BorderWidth = 1F;
            this.DataTime1.Font = new System.Drawing.Font("Arial", 8F);
            this.DataTime1.ForeColor = System.Drawing.Color.Black;
            this.DataTime1.LocationFloat = new DevExpress.Utils.PointFloat(91.66666F, 0F);
            this.DataTime1.Name = "DataTime1";
            this.DataTime1.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.DataTime1.PageInfo = DevExpress.XtraPrinting.PageInfo.DateTime;
            this.DataTime1.SizeF = new System.Drawing.SizeF(57.15277F, 12.84722F);
            this.DataTime1.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopLeft;
            this.DataTime1.TextFormatString = "{0:t}";
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
            this.gsUserName_1.Font = new System.Drawing.Font("Arial", 8F);
            this.gsUserName_1.ForeColor = System.Drawing.Color.Black;
            this.gsUserName_1.LocationFloat = new DevExpress.Utils.PointFloat(316.6667F, 0F);
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
            this.gsUserID_1.Font = new System.Drawing.Font("Arial", 8F);
            this.gsUserID_1.ForeColor = System.Drawing.Color.Black;
            this.gsUserID_1.LocationFloat = new DevExpress.Utils.PointFloat(275F, 0F);
            this.gsUserID_1.Name = "gsUserID_1";
            this.gsUserID_1.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.gsUserID_1.SizeF = new System.Drawing.SizeF(33.33331F, 18.33333F);
            this.gsUserID_1.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopLeft;
            // 
            // Text5
            // 
            this.Text5.BackColor = System.Drawing.Color.Transparent;
            this.Text5.BorderColor = System.Drawing.Color.Black;
            this.Text5.Borders = DevExpress.XtraPrinting.BorderSide.None;
            this.Text5.BorderWidth = 1F;
            this.Text5.CanGrow = false;
            this.Text5.Font = new System.Drawing.Font("Arial", 8F, System.Drawing.FontStyle.Bold);
            this.Text5.ForeColor = System.Drawing.Color.Black;
            this.Text5.LocationFloat = new DevExpress.Utils.PointFloat(216.6667F, 0F);
            this.Text5.Name = "Text5";
            this.Text5.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.Text5.SizeF = new System.Drawing.SizeF(49.99998F, 18.33333F);
            this.Text5.Text = "USER:";
            this.Text5.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopLeft;
            // 
            // gdFromDate
            // 
            this.gdFromDate.Description = "Enter gdFromDate:";
            this.gdFromDate.Name = "gdFromDate";
            this.gdFromDate.Type = typeof(System.DateTime);
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
            // gdToDate
            // 
            this.gdToDate.Description = "Enter gdToDate:";
            this.gdToDate.Name = "gdToDate";
            this.gdToDate.Type = typeof(System.DateTime);
            // 
            // topMarginBand1
            // 
            this.topMarginBand1.HeightF = 19.68504F;
            this.topMarginBand1.Name = "topMarginBand1";
            // 
            // bottomMarginBand1
            // 
            this.bottomMarginBand1.HeightF = 19.68504F;
            this.bottomMarginBand1.Name = "bottomMarginBand1";
            // 
            // sqlDataSource1
            // 
            this.sqlDataSource1.ConnectionName = "IAC2021SQL.Properties.Settings.IAC2010SQLConnectionString";
            this.sqlDataSource1.Name = "sqlDataSource1";
            storedProcQuery1.Name = "OpenChargesAppliedToDealer";
            queryParameter1.Name = "@DealerNo";
            queryParameter1.Type = typeof(string);
            queryParameter2.Name = "@FromDate";
            queryParameter2.Type = typeof(System.DateTime);
            queryParameter2.ValueInfo = "2022-04-01";
            queryParameter3.Name = "@ToDate";
            queryParameter3.Type = typeof(System.DateTime);
            queryParameter3.ValueInfo = "2022-05-31";
            storedProcQuery1.Parameters.AddRange(new DevExpress.DataAccess.Sql.QueryParameter[] {
            queryParameter1,
            queryParameter2,
            queryParameter3});
            storedProcQuery1.StoredProcName = "OpenChargesAppliedToDealer";
            this.sqlDataSource1.Queries.AddRange(new DevExpress.DataAccess.Sql.SqlQuery[] {
            storedProcQuery1});
            this.sqlDataSource1.ResultSchemaSerializable = resources.GetString("sqlDataSource1.ResultSchemaSerializable");
            // 
            // XtraReportOpenChargesAppliedToDealer
            // 
            this.Bands.AddRange(new DevExpress.XtraReports.UI.Band[] {
            this.Area3,
            this.Area1,
            this.Area2,
            this.Area4,
            this.Area5,
            this.topMarginBand1,
            this.bottomMarginBand1});
            this.ComponentStorage.AddRange(new System.ComponentModel.IComponent[] {
            this.sqlDataSource1});
            this.DataMember = "OpenChargesAppliedToDealer";
            this.DataSource = this.sqlDataSource1;
            this.DefaultPrinterSettingsUsing.UsePaperKind = true;
            this.Landscape = true;
            this.Margins = new System.Drawing.Printing.Margins(20, 20, 20, 20);
            this.PageHeight = 850;
            this.PageWidth = 1100;
            this.Parameters.AddRange(new DevExpress.XtraReports.Parameters.Parameter[] {
            this.gdFromDate,
            this.gsUserName,
            this.gsUserID,
            this.gdToDate});
            this.Version = "21.2";
            ((System.ComponentModel.ISupportInitialize)(this)).EndInit();

        }

        #endregion

        private DevExpress.XtraReports.UI.DetailBand Area3;
        private DevExpress.XtraReports.UI.XRLabel OPNDEALRACCNO1;
        private DevExpress.XtraReports.UI.XRLabel OPNDEALRNAME1;
        private DevExpress.XtraReports.UI.XRLabel FinanceCharges1;
        private DevExpress.XtraReports.UI.XRLabel LateFees1;
        private DevExpress.XtraReports.UI.XRLabel ISFCFees1;
        private DevExpress.XtraReports.UI.ReportHeaderBand Area1;
        private DevExpress.XtraReports.UI.XRLabel Text2;
        private DevExpress.XtraReports.UI.XRLabel gdCutOffDate1;
        private DevExpress.XtraReports.UI.XRLabel Text33;
        private DevExpress.XtraReports.UI.XRLabel Text34;
        private DevExpress.XtraReports.UI.XRLabel gdToDate1;
        private DevExpress.XtraReports.UI.PageHeaderBand Area2;
        private DevExpress.XtraReports.UI.XRLabel Text4;
        private DevExpress.XtraReports.UI.XRLine Line1;
        private DevExpress.XtraReports.UI.XRLabel Text19;
        private DevExpress.XtraReports.UI.XRLabel Text3;
        private DevExpress.XtraReports.UI.XRLabel Text1;
        private DevExpress.XtraReports.UI.ReportFooterBand Area4;
        private DevExpress.XtraReports.UI.XRLabel TotalLateFees1;
        private DevExpress.XtraReports.UI.XRLabel TotalISFCFees1;
        private DevExpress.XtraReports.UI.XRLine Line3;
        private DevExpress.XtraReports.UI.XRLabel Text9;
        private DevExpress.XtraReports.UI.XRLabel TotalFinanceCharges1;
        private DevExpress.XtraReports.UI.PageFooterBand Area5;
        private DevExpress.XtraReports.UI.XRPageInfo PageNofM1;
        private DevExpress.XtraReports.UI.XRPageInfo DataDate1;
        private DevExpress.XtraReports.UI.XRPageInfo DataTime1;
        private DevExpress.XtraReports.UI.XRLabel gsUserName_1;
        private DevExpress.XtraReports.UI.XRLabel gsUserID_1;
        private DevExpress.XtraReports.UI.XRLabel Text5;
        private DevExpress.XtraReports.Parameters.Parameter gdFromDate;
        private DevExpress.XtraReports.Parameters.Parameter gsUserName;
        private DevExpress.XtraReports.Parameters.Parameter gsUserID;
        private DevExpress.XtraReports.Parameters.Parameter gdToDate;
        private DevExpress.XtraReports.UI.XRPictureBox Picture1;
        private DevExpress.XtraReports.UI.TopMarginBand topMarginBand1;
        private DevExpress.XtraReports.UI.BottomMarginBand bottomMarginBand1;
        private DevExpress.DataAccess.Sql.SqlDataSource sqlDataSource1;
    }
}

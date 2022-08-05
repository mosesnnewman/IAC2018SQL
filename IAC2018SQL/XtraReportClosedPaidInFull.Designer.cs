namespace IAC2021SQL
{
    partial class XtraReportClosedPaidInFull
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(XtraReportClosedPaidInFull));
            DevExpress.XtraReports.UI.XRSummary xrSummary1 = new DevExpress.XtraReports.UI.XRSummary();
            this.Area3 = new DevExpress.XtraReports.UI.DetailBand();
            this.CustomerNo1 = new DevExpress.XtraReports.UI.XRLabel();
            this.TypeCode_1 = new DevExpress.XtraReports.UI.XRLabel();
            this.CustomerName1 = new DevExpress.XtraReports.UI.XRLabel();
            this.SSNUM_1 = new DevExpress.XtraReports.UI.XRLabel();
            this.ContractDate1 = new DevExpress.XtraReports.UI.XRLabel();
            this.FirstPaymentDate1 = new DevExpress.XtraReports.UI.XRLabel();
            this.DateClosed1 = new DevExpress.XtraReports.UI.XRLabel();
            this.Dealer1 = new DevExpress.XtraReports.UI.XRLabel();
            this.DEALERNAME1 = new DevExpress.XtraReports.UI.XRLabel();
            this.State1 = new DevExpress.XtraReports.UI.XRLabel();
            this.Area1 = new DevExpress.XtraReports.UI.ReportHeaderBand();
            this.Picture1 = new DevExpress.XtraReports.UI.XRPictureBox();
            this.Text20 = new DevExpress.XtraReports.UI.XRLabel();
            this.Text21 = new DevExpress.XtraReports.UI.XRLabel();
            this.gdFromDate1 = new DevExpress.XtraReports.UI.XRLabel();
            this.Text22 = new DevExpress.XtraReports.UI.XRLabel();
            this.gdToDate1 = new DevExpress.XtraReports.UI.XRLabel();
            this.Area2 = new DevExpress.XtraReports.UI.PageHeaderBand();
            this.Text11 = new DevExpress.XtraReports.UI.XRLabel();
            this.Text12 = new DevExpress.XtraReports.UI.XRLabel();
            this.Text13 = new DevExpress.XtraReports.UI.XRLabel();
            this.Text14 = new DevExpress.XtraReports.UI.XRLabel();
            this.Text15 = new DevExpress.XtraReports.UI.XRLabel();
            this.Text16 = new DevExpress.XtraReports.UI.XRLabel();
            this.Text17 = new DevExpress.XtraReports.UI.XRLabel();
            this.Text18 = new DevExpress.XtraReports.UI.XRLabel();
            this.Text19 = new DevExpress.XtraReports.UI.XRLabel();
            this.Line1 = new DevExpress.XtraReports.UI.XRLine();
            this.Area4 = new DevExpress.XtraReports.UI.ReportFooterBand();
            this.Text1 = new DevExpress.XtraReports.UI.XRLabel();
            this.TotalCustomerCount1 = new DevExpress.XtraReports.UI.XRLabel();
            this.Area5 = new DevExpress.XtraReports.UI.PageFooterBand();
            this.PageNofM1 = new DevExpress.XtraReports.UI.XRPageInfo();
            this.gsUserName_1 = new DevExpress.XtraReports.UI.XRLabel();
            this.gsUserID_1 = new DevExpress.XtraReports.UI.XRLabel();
            this.Text5 = new DevExpress.XtraReports.UI.XRLabel();
            this.DataTime1 = new DevExpress.XtraReports.UI.XRPageInfo();
            this.TypeCode = new DevExpress.XtraReports.UI.CalculatedField();
            this.SSNUM = new DevExpress.XtraReports.UI.CalculatedField();
            this.gdFromDate = new DevExpress.XtraReports.Parameters.Parameter();
            this.gdToDate = new DevExpress.XtraReports.Parameters.Parameter();
            this.gsUserName = new DevExpress.XtraReports.Parameters.Parameter();
            this.gsUserID = new DevExpress.XtraReports.Parameters.Parameter();
            this.topMarginBand1 = new DevExpress.XtraReports.UI.TopMarginBand();
            this.bottomMarginBand1 = new DevExpress.XtraReports.UI.BottomMarginBand();
            ((System.ComponentModel.ISupportInitialize)(this)).BeginInit();
            // 
            // Area3
            // 
            this.Area3.Controls.AddRange(new DevExpress.XtraReports.UI.XRControl[] {
            this.CustomerNo1,
            this.TypeCode_1,
            this.CustomerName1,
            this.SSNUM_1,
            this.ContractDate1,
            this.FirstPaymentDate1,
            this.DateClosed1,
            this.Dealer1,
            this.DEALERNAME1,
            this.State1});
            this.Area3.HeightF = 17F;
            this.Area3.KeepTogether = true;
            this.Area3.Name = "Area3";
            this.Area3.Padding = new DevExpress.XtraPrinting.PaddingInfo(0, 0, 0, 0, 100F);
            this.Area3.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopLeft;
            // 
            // CustomerNo1
            // 
            this.CustomerNo1.BackColor = System.Drawing.Color.Transparent;
            this.CustomerNo1.BorderColor = System.Drawing.Color.Black;
            this.CustomerNo1.Borders = DevExpress.XtraPrinting.BorderSide.None;
            this.CustomerNo1.BorderWidth = 1F;
            this.CustomerNo1.CanGrow = false;
            this.CustomerNo1.ExpressionBindings.AddRange(new DevExpress.XtraReports.UI.ExpressionBinding[] {
            new DevExpress.XtraReports.UI.ExpressionBinding("BeforePrint", "Text", "[CustomerNo]")});
            this.CustomerNo1.Font = new System.Drawing.Font("Arial", 8F);
            this.CustomerNo1.ForeColor = System.Drawing.Color.Black;
            this.CustomerNo1.LocationFloat = new DevExpress.Utils.PointFloat(0F, 0F);
            this.CustomerNo1.Name = "CustomerNo1";
            this.CustomerNo1.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.CustomerNo1.SizeF = new System.Drawing.SizeF(64.58334F, 15.34722F);
            this.CustomerNo1.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopLeft;
            // 
            // TypeCode_1
            // 
            this.TypeCode_1.BackColor = System.Drawing.Color.Transparent;
            this.TypeCode_1.BorderColor = System.Drawing.Color.Black;
            this.TypeCode_1.Borders = DevExpress.XtraPrinting.BorderSide.None;
            this.TypeCode_1.BorderWidth = 1F;
            this.TypeCode_1.CanGrow = false;
            this.TypeCode_1.ExpressionBindings.AddRange(new DevExpress.XtraReports.UI.ExpressionBinding[] {
            new DevExpress.XtraReports.UI.ExpressionBinding("BeforePrint", "Text", "[TypeCode]")});
            this.TypeCode_1.Font = new System.Drawing.Font("Arial", 8F);
            this.TypeCode_1.ForeColor = System.Drawing.Color.Black;
            this.TypeCode_1.LocationFloat = new DevExpress.Utils.PointFloat(66.66666F, 0F);
            this.TypeCode_1.Name = "TypeCode_1";
            this.TypeCode_1.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.TypeCode_1.SizeF = new System.Drawing.SizeF(52.08333F, 15.34722F);
            this.TypeCode_1.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopLeft;
            // 
            // CustomerName1
            // 
            this.CustomerName1.BackColor = System.Drawing.Color.Transparent;
            this.CustomerName1.BorderColor = System.Drawing.Color.Black;
            this.CustomerName1.Borders = DevExpress.XtraPrinting.BorderSide.None;
            this.CustomerName1.BorderWidth = 1F;
            this.CustomerName1.CanGrow = false;
            this.CustomerName1.ExpressionBindings.AddRange(new DevExpress.XtraReports.UI.ExpressionBinding[] {
            new DevExpress.XtraReports.UI.ExpressionBinding("BeforePrint", "Text", "[CustomerName]")});
            this.CustomerName1.Font = new System.Drawing.Font("Arial", 8F);
            this.CustomerName1.ForeColor = System.Drawing.Color.Black;
            this.CustomerName1.LocationFloat = new DevExpress.Utils.PointFloat(133.3333F, 0F);
            this.CustomerName1.Name = "CustomerName1";
            this.CustomerName1.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.CustomerName1.SizeF = new System.Drawing.SizeF(204.1667F, 15.34722F);
            this.CustomerName1.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopLeft;
            // 
            // SSNUM_1
            // 
            this.SSNUM_1.BackColor = System.Drawing.Color.Transparent;
            this.SSNUM_1.BorderColor = System.Drawing.Color.Black;
            this.SSNUM_1.Borders = DevExpress.XtraPrinting.BorderSide.None;
            this.SSNUM_1.BorderWidth = 1F;
            this.SSNUM_1.CanGrow = false;
            this.SSNUM_1.ExpressionBindings.AddRange(new DevExpress.XtraReports.UI.ExpressionBinding[] {
            new DevExpress.XtraReports.UI.ExpressionBinding("BeforePrint", "Text", "[SSNUM]")});
            this.SSNUM_1.Font = new System.Drawing.Font("Arial", 8F);
            this.SSNUM_1.ForeColor = System.Drawing.Color.Black;
            this.SSNUM_1.LocationFloat = new DevExpress.Utils.PointFloat(341.6667F, 0F);
            this.SSNUM_1.Name = "SSNUM_1";
            this.SSNUM_1.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.SSNUM_1.SizeF = new System.Drawing.SizeF(96.875F, 15.34722F);
            this.SSNUM_1.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopLeft;
            // 
            // ContractDate1
            // 
            this.ContractDate1.BackColor = System.Drawing.Color.Transparent;
            this.ContractDate1.BorderColor = System.Drawing.Color.Black;
            this.ContractDate1.Borders = DevExpress.XtraPrinting.BorderSide.None;
            this.ContractDate1.BorderWidth = 1F;
            this.ContractDate1.CanGrow = false;
            this.ContractDate1.ExpressionBindings.AddRange(new DevExpress.XtraReports.UI.ExpressionBinding[] {
            new DevExpress.XtraReports.UI.ExpressionBinding("BeforePrint", "Text", "[ContractDate]")});
            this.ContractDate1.Font = new System.Drawing.Font("Arial", 8F);
            this.ContractDate1.ForeColor = System.Drawing.Color.Black;
            this.ContractDate1.LocationFloat = new DevExpress.Utils.PointFloat(450F, 0F);
            this.ContractDate1.Name = "ContractDate1";
            this.ContractDate1.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.ContractDate1.SizeF = new System.Drawing.SizeF(92.70834F, 14.58333F);
            this.ContractDate1.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopLeft;
            // 
            // FirstPaymentDate1
            // 
            this.FirstPaymentDate1.BackColor = System.Drawing.Color.Transparent;
            this.FirstPaymentDate1.BorderColor = System.Drawing.Color.Black;
            this.FirstPaymentDate1.Borders = DevExpress.XtraPrinting.BorderSide.None;
            this.FirstPaymentDate1.BorderWidth = 1F;
            this.FirstPaymentDate1.CanGrow = false;
            this.FirstPaymentDate1.ExpressionBindings.AddRange(new DevExpress.XtraReports.UI.ExpressionBinding[] {
            new DevExpress.XtraReports.UI.ExpressionBinding("BeforePrint", "Text", "[FirstPaymentDate]")});
            this.FirstPaymentDate1.Font = new System.Drawing.Font("Arial", 8F);
            this.FirstPaymentDate1.ForeColor = System.Drawing.Color.Black;
            this.FirstPaymentDate1.LocationFloat = new DevExpress.Utils.PointFloat(558.3333F, 0F);
            this.FirstPaymentDate1.Name = "FirstPaymentDate1";
            this.FirstPaymentDate1.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.FirstPaymentDate1.SizeF = new System.Drawing.SizeF(92.70834F, 14.58333F);
            this.FirstPaymentDate1.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopLeft;
            // 
            // DateClosed1
            // 
            this.DateClosed1.BackColor = System.Drawing.Color.Transparent;
            this.DateClosed1.BorderColor = System.Drawing.Color.Black;
            this.DateClosed1.Borders = DevExpress.XtraPrinting.BorderSide.None;
            this.DateClosed1.BorderWidth = 1F;
            this.DateClosed1.CanGrow = false;
            this.DateClosed1.ExpressionBindings.AddRange(new DevExpress.XtraReports.UI.ExpressionBinding[] {
            new DevExpress.XtraReports.UI.ExpressionBinding("BeforePrint", "Text", "[DateClosed]")});
            this.DateClosed1.Font = new System.Drawing.Font("Arial", 8F);
            this.DateClosed1.ForeColor = System.Drawing.Color.Black;
            this.DateClosed1.LocationFloat = new DevExpress.Utils.PointFloat(666.6667F, 0F);
            this.DateClosed1.Name = "DateClosed1";
            this.DateClosed1.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.DateClosed1.SizeF = new System.Drawing.SizeF(92.70834F, 14.58333F);
            this.DateClosed1.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopLeft;
            // 
            // Dealer1
            // 
            this.Dealer1.BackColor = System.Drawing.Color.Transparent;
            this.Dealer1.BorderColor = System.Drawing.Color.Black;
            this.Dealer1.Borders = DevExpress.XtraPrinting.BorderSide.None;
            this.Dealer1.BorderWidth = 1F;
            this.Dealer1.CanGrow = false;
            this.Dealer1.ExpressionBindings.AddRange(new DevExpress.XtraReports.UI.ExpressionBinding[] {
            new DevExpress.XtraReports.UI.ExpressionBinding("BeforePrint", "Text", "[Dealer]")});
            this.Dealer1.Font = new System.Drawing.Font("Arial", 10F);
            this.Dealer1.ForeColor = System.Drawing.Color.Black;
            this.Dealer1.LocationFloat = new DevExpress.Utils.PointFloat(766.6667F, 0F);
            this.Dealer1.Name = "Dealer1";
            this.Dealer1.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.Dealer1.SizeF = new System.Drawing.SizeF(28.125F, 16.66667F);
            this.Dealer1.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopLeft;
            // 
            // DEALERNAME1
            // 
            this.DEALERNAME1.BackColor = System.Drawing.Color.Transparent;
            this.DEALERNAME1.BorderColor = System.Drawing.Color.Black;
            this.DEALERNAME1.Borders = DevExpress.XtraPrinting.BorderSide.None;
            this.DEALERNAME1.BorderWidth = 1F;
            this.DEALERNAME1.CanGrow = false;
            this.DEALERNAME1.ExpressionBindings.AddRange(new DevExpress.XtraReports.UI.ExpressionBinding[] {
            new DevExpress.XtraReports.UI.ExpressionBinding("BeforePrint", "Text", "[DEALER_NAME]")});
            this.DEALERNAME1.Font = new System.Drawing.Font("Arial", 8F);
            this.DEALERNAME1.ForeColor = System.Drawing.Color.Black;
            this.DEALERNAME1.LocationFloat = new DevExpress.Utils.PointFloat(800F, 0F);
            this.DEALERNAME1.Name = "DEALERNAME1";
            this.DEALERNAME1.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.DEALERNAME1.SizeF = new System.Drawing.SizeF(202.0833F, 16.66667F);
            this.DEALERNAME1.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopLeft;
            // 
            // State1
            // 
            this.State1.BackColor = System.Drawing.Color.Transparent;
            this.State1.BorderColor = System.Drawing.Color.Black;
            this.State1.Borders = DevExpress.XtraPrinting.BorderSide.None;
            this.State1.BorderWidth = 1F;
            this.State1.CanGrow = false;
            this.State1.ExpressionBindings.AddRange(new DevExpress.XtraReports.UI.ExpressionBinding[] {
            new DevExpress.XtraReports.UI.ExpressionBinding("BeforePrint", "Text", "[State]")});
            this.State1.Font = new System.Drawing.Font("Arial", 10F);
            this.State1.ForeColor = System.Drawing.Color.Black;
            this.State1.LocationFloat = new DevExpress.Utils.PointFloat(1008.333F, 0F);
            this.State1.Name = "State1";
            this.State1.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.State1.SizeF = new System.Drawing.SizeF(19.79167F, 16.66667F);
            this.State1.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopLeft;
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
            this.Picture1.Font = new System.Drawing.Font("Times New Roman", 9.75F);
            this.Picture1.ForeColor = System.Drawing.Color.Black;
            this.Picture1.ImageSource = new DevExpress.XtraPrinting.Drawing.ImageSource("img", resources.GetString("Picture1.ImageSource"));
            this.Picture1.LocationFloat = new DevExpress.Utils.PointFloat(795.2779F, 0F);
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
            this.Text20.Font = new System.Drawing.Font("Arial", 14F);
            this.Text20.ForeColor = System.Drawing.Color.Black;
            this.Text20.LocationFloat = new DevExpress.Utils.PointFloat(8.333333F, 97.00001F);
            this.Text20.Name = "Text20";
            this.Text20.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.Text20.SizeF = new System.Drawing.SizeF(1041.667F, 25F);
            this.Text20.Text = "CLOSED CUSTOMER PAID IN FULL REPORT";
            this.Text20.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopCenter;
            // 
            // Text21
            // 
            this.Text21.BackColor = System.Drawing.Color.Transparent;
            this.Text21.BorderColor = System.Drawing.Color.Black;
            this.Text21.Borders = DevExpress.XtraPrinting.BorderSide.None;
            this.Text21.BorderWidth = 1F;
            this.Text21.CanGrow = false;
            this.Text21.Font = new System.Drawing.Font("Arial", 10F, System.Drawing.FontStyle.Bold);
            this.Text21.ForeColor = System.Drawing.Color.Black;
            this.Text21.LocationFloat = new DevExpress.Utils.PointFloat(316.6667F, 130.3333F);
            this.Text21.Name = "Text21";
            this.Text21.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.Text21.SizeF = new System.Drawing.SizeF(91.66666F, 16.66667F);
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
            this.gdFromDate1.Font = new System.Drawing.Font("Arial", 10F);
            this.gdFromDate1.ForeColor = System.Drawing.Color.Black;
            this.gdFromDate1.LocationFloat = new DevExpress.Utils.PointFloat(425F, 130.3333F);
            this.gdFromDate1.Name = "gdFromDate1";
            this.gdFromDate1.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.gdFromDate1.SizeF = new System.Drawing.SizeF(83.33334F, 16.66667F);
            this.gdFromDate1.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopLeft;
            // 
            // Text22
            // 
            this.Text22.BackColor = System.Drawing.Color.Transparent;
            this.Text22.BorderColor = System.Drawing.Color.Black;
            this.Text22.Borders = DevExpress.XtraPrinting.BorderSide.None;
            this.Text22.BorderWidth = 1F;
            this.Text22.CanGrow = false;
            this.Text22.Font = new System.Drawing.Font("Arial", 10F, System.Drawing.FontStyle.Bold);
            this.Text22.ForeColor = System.Drawing.Color.Black;
            this.Text22.LocationFloat = new DevExpress.Utils.PointFloat(516.6667F, 130.3333F);
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
            this.gdToDate1.Font = new System.Drawing.Font("Arial", 10F);
            this.gdToDate1.ForeColor = System.Drawing.Color.Black;
            this.gdToDate1.LocationFloat = new DevExpress.Utils.PointFloat(541.6667F, 130.3333F);
            this.gdToDate1.Name = "gdToDate1";
            this.gdToDate1.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.gdToDate1.SizeF = new System.Drawing.SizeF(83.33334F, 16.66667F);
            this.gdToDate1.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopLeft;
            // 
            // Area2
            // 
            this.Area2.Controls.AddRange(new DevExpress.XtraReports.UI.XRControl[] {
            this.Text11,
            this.Text12,
            this.Text13,
            this.Text14,
            this.Text15,
            this.Text16,
            this.Text17,
            this.Text18,
            this.Text19,
            this.Line1});
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
            this.Text11.Font = new System.Drawing.Font("Arial", 8F, System.Drawing.FontStyle.Bold);
            this.Text11.ForeColor = System.Drawing.Color.Black;
            this.Text11.LocationFloat = new DevExpress.Utils.PointFloat(0F, 16.66667F);
            this.Text11.Name = "Text11";
            this.Text11.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.Text11.SizeF = new System.Drawing.SizeF(58.33333F, 16.66667F);
            this.Text11.Text = "Account#";
            this.Text11.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopLeft;
            // 
            // Text12
            // 
            this.Text12.BackColor = System.Drawing.Color.Transparent;
            this.Text12.BorderColor = System.Drawing.Color.Black;
            this.Text12.Borders = DevExpress.XtraPrinting.BorderSide.None;
            this.Text12.BorderWidth = 1F;
            this.Text12.CanGrow = false;
            this.Text12.Font = new System.Drawing.Font("Arial", 8F, System.Drawing.FontStyle.Bold);
            this.Text12.ForeColor = System.Drawing.Color.Black;
            this.Text12.LocationFloat = new DevExpress.Utils.PointFloat(66.66666F, 16.66667F);
            this.Text12.Name = "Text12";
            this.Text12.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.Text12.SizeF = new System.Drawing.SizeF(58.33333F, 16.66667F);
            this.Text12.Text = "Type / CD";
            this.Text12.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopLeft;
            // 
            // Text13
            // 
            this.Text13.BackColor = System.Drawing.Color.Transparent;
            this.Text13.BorderColor = System.Drawing.Color.Black;
            this.Text13.Borders = DevExpress.XtraPrinting.BorderSide.None;
            this.Text13.BorderWidth = 1F;
            this.Text13.CanGrow = false;
            this.Text13.Font = new System.Drawing.Font("Arial", 8F, System.Drawing.FontStyle.Bold);
            this.Text13.ForeColor = System.Drawing.Color.Black;
            this.Text13.LocationFloat = new DevExpress.Utils.PointFloat(133.3333F, 16.66667F);
            this.Text13.Name = "Text13";
            this.Text13.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.Text13.SizeF = new System.Drawing.SizeF(100F, 16.66667F);
            this.Text13.Text = "Customer Name";
            this.Text13.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopLeft;
            // 
            // Text14
            // 
            this.Text14.BackColor = System.Drawing.Color.Transparent;
            this.Text14.BorderColor = System.Drawing.Color.Black;
            this.Text14.Borders = DevExpress.XtraPrinting.BorderSide.None;
            this.Text14.BorderWidth = 1F;
            this.Text14.CanGrow = false;
            this.Text14.Font = new System.Drawing.Font("Arial", 8F, System.Drawing.FontStyle.Bold);
            this.Text14.ForeColor = System.Drawing.Color.Black;
            this.Text14.LocationFloat = new DevExpress.Utils.PointFloat(341.6667F, 16.66667F);
            this.Text14.Name = "Text14";
            this.Text14.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.Text14.SizeF = new System.Drawing.SizeF(100F, 16.66667F);
            this.Text14.Text = "Social Security #";
            this.Text14.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopLeft;
            // 
            // Text15
            // 
            this.Text15.BackColor = System.Drawing.Color.Transparent;
            this.Text15.BorderColor = System.Drawing.Color.Black;
            this.Text15.Borders = DevExpress.XtraPrinting.BorderSide.None;
            this.Text15.BorderWidth = 1F;
            this.Text15.CanGrow = false;
            this.Text15.Font = new System.Drawing.Font("Arial", 8F, System.Drawing.FontStyle.Bold);
            this.Text15.ForeColor = System.Drawing.Color.Black;
            this.Text15.LocationFloat = new DevExpress.Utils.PointFloat(450F, 16.66667F);
            this.Text15.Name = "Text15";
            this.Text15.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.Text15.SizeF = new System.Drawing.SizeF(75F, 16.66667F);
            this.Text15.Text = "Date Open";
            this.Text15.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopLeft;
            // 
            // Text16
            // 
            this.Text16.BackColor = System.Drawing.Color.Transparent;
            this.Text16.BorderColor = System.Drawing.Color.Black;
            this.Text16.Borders = DevExpress.XtraPrinting.BorderSide.None;
            this.Text16.BorderWidth = 1F;
            this.Text16.CanGrow = false;
            this.Text16.Font = new System.Drawing.Font("Arial", 8F, System.Drawing.FontStyle.Bold);
            this.Text16.ForeColor = System.Drawing.Color.Black;
            this.Text16.LocationFloat = new DevExpress.Utils.PointFloat(666.6667F, 16.66667F);
            this.Text16.Name = "Text16";
            this.Text16.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.Text16.SizeF = new System.Drawing.SizeF(75F, 16.66667F);
            this.Text16.Text = "Date Closed";
            this.Text16.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopLeft;
            // 
            // Text17
            // 
            this.Text17.BackColor = System.Drawing.Color.Transparent;
            this.Text17.BorderColor = System.Drawing.Color.Black;
            this.Text17.Borders = DevExpress.XtraPrinting.BorderSide.None;
            this.Text17.BorderWidth = 1F;
            this.Text17.CanGrow = false;
            this.Text17.Font = new System.Drawing.Font("Arial", 8F, System.Drawing.FontStyle.Bold);
            this.Text17.ForeColor = System.Drawing.Color.Black;
            this.Text17.LocationFloat = new DevExpress.Utils.PointFloat(558.3333F, 16.66667F);
            this.Text17.Name = "Text17";
            this.Text17.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.Text17.SizeF = new System.Drawing.SizeF(75F, 16.66667F);
            this.Text17.Text = "1st Pay Date";
            this.Text17.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopLeft;
            // 
            // Text18
            // 
            this.Text18.BackColor = System.Drawing.Color.Transparent;
            this.Text18.BorderColor = System.Drawing.Color.Black;
            this.Text18.Borders = DevExpress.XtraPrinting.BorderSide.None;
            this.Text18.BorderWidth = 1F;
            this.Text18.CanGrow = false;
            this.Text18.Font = new System.Drawing.Font("Arial", 8F, System.Drawing.FontStyle.Bold);
            this.Text18.ForeColor = System.Drawing.Color.Black;
            this.Text18.LocationFloat = new DevExpress.Utils.PointFloat(766.6667F, 16.66667F);
            this.Text18.Name = "Text18";
            this.Text18.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.Text18.SizeF = new System.Drawing.SizeF(75F, 16.66667F);
            this.Text18.Text = "Dealer";
            this.Text18.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopLeft;
            // 
            // Text19
            // 
            this.Text19.BackColor = System.Drawing.Color.Transparent;
            this.Text19.BorderColor = System.Drawing.Color.Black;
            this.Text19.Borders = DevExpress.XtraPrinting.BorderSide.None;
            this.Text19.BorderWidth = 1F;
            this.Text19.CanGrow = false;
            this.Text19.Font = new System.Drawing.Font("Arial", 8F, System.Drawing.FontStyle.Bold);
            this.Text19.ForeColor = System.Drawing.Color.Black;
            this.Text19.LocationFloat = new DevExpress.Utils.PointFloat(1008.333F, 16.66667F);
            this.Text19.Name = "Text19";
            this.Text19.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.Text19.SizeF = new System.Drawing.SizeF(33.33333F, 16.66667F);
            this.Text19.Text = "State";
            this.Text19.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopLeft;
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
            this.Line1.LocationFloat = new DevExpress.Utils.PointFloat(1.041667F, 41.66667F);
            this.Line1.Name = "Line1";
            this.Line1.Padding = new DevExpress.XtraPrinting.PaddingInfo(0, 0, 0, 0, 100F);
            this.Line1.SizeF = new System.Drawing.SizeF(1040.625F, 3.125F);
            // 
            // Area4
            // 
            this.Area4.Controls.AddRange(new DevExpress.XtraReports.UI.XRControl[] {
            this.Text1,
            this.TotalCustomerCount1});
            this.Area4.HeightF = 21F;
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
            this.Text1.Font = new System.Drawing.Font("Arial", 10F, System.Drawing.FontStyle.Bold);
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
            new DevExpress.XtraReports.UI.ExpressionBinding("BeforePrint", "Text", "sumCount([CustomerNo])")});
            this.TotalCustomerCount1.Font = new System.Drawing.Font("Arial", 10F);
            this.TotalCustomerCount1.ForeColor = System.Drawing.Color.Black;
            this.TotalCustomerCount1.LocationFloat = new DevExpress.Utils.PointFloat(266.6667F, 0F);
            this.TotalCustomerCount1.Name = "TotalCustomerCount1";
            this.TotalCustomerCount1.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.TotalCustomerCount1.SizeF = new System.Drawing.SizeF(63.54167F, 16.66667F);
            xrSummary1.Running = DevExpress.XtraReports.UI.SummaryRunning.Report;
            this.TotalCustomerCount1.Summary = xrSummary1;
            this.TotalCustomerCount1.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopRight;
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
            this.PageNofM1.Font = new System.Drawing.Font("Arial", 10F);
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
            this.gsUserName_1.Font = new System.Drawing.Font("Arial", 10F);
            this.gsUserName_1.ForeColor = System.Drawing.Color.Black;
            this.gsUserName_1.LocationFloat = new DevExpress.Utils.PointFloat(200F, 0F);
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
            this.gsUserID_1.Font = new System.Drawing.Font("Arial", 10F);
            this.gsUserID_1.ForeColor = System.Drawing.Color.Black;
            this.gsUserID_1.LocationFloat = new DevExpress.Utils.PointFloat(158.3333F, 0F);
            this.gsUserID_1.Name = "gsUserID_1";
            this.gsUserID_1.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.gsUserID_1.SizeF = new System.Drawing.SizeF(33.33333F, 18.33333F);
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
            this.DataTime1.Font = new System.Drawing.Font("Arial", 10F);
            this.DataTime1.ForeColor = System.Drawing.Color.Black;
            this.DataTime1.LocationFloat = new DevExpress.Utils.PointFloat(0F, 0F);
            this.DataTime1.Name = "DataTime1";
            this.DataTime1.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.DataTime1.PageInfo = DevExpress.XtraPrinting.PageInfo.DateTime;
            this.DataTime1.SizeF = new System.Drawing.SizeF(70.83334F, 18.33333F);
            this.DataTime1.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopLeft;
            this.DataTime1.TextFormatString = "{0:t}";
            // 
            // TypeCode
            // 
            this.TypeCode.Expression = "[PaidInFull.PaymentType] + \' / \' + [PaidInFull.PaymentCode]";
            this.TypeCode.FieldType = DevExpress.XtraReports.UI.FieldType.String;
            this.TypeCode.Name = "TypeCode";
            // 
            // SSNUM
            // 
            this.SSNUM.Expression = "Iif(True, \'#NOT_SUPPORTED#\', \'Left([PaidInFull.SocialSecurity], 3)\') + \'-\' + Subs" +
    "tring([PaidInFull.SocialSecurity], 4, 2) + \'-\' + Iif(True, \'#NOT_SUPPORTED#\', \'R" +
    "ight([PaidInFull.SocialSecurity], 4)\')";
            this.SSNUM.FieldType = DevExpress.XtraReports.UI.FieldType.String;
            this.SSNUM.Name = "SSNUM";
            // 
            // gdFromDate
            // 
            this.gdFromDate.Description = "Enter gdFromDate:";
            this.gdFromDate.Name = "gdFromDate";
            this.gdFromDate.Type = typeof(System.DateTime);
            // 
            // gdToDate
            // 
            this.gdToDate.Description = "Enter gdToDate:";
            this.gdToDate.Name = "gdToDate";
            this.gdToDate.Type = typeof(System.DateTime);
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
            // XtraReportClosedPaidInFull
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
            this.TypeCode,
            this.SSNUM});
            this.Landscape = true;
            this.Margins = new System.Drawing.Printing.Margins(25, 25, 25, 25);
            this.PageHeight = 850;
            this.PageWidth = 1100;
            this.Parameters.AddRange(new DevExpress.XtraReports.Parameters.Parameter[] {
            this.gdFromDate,
            this.gdToDate,
            this.gsUserName,
            this.gsUserID});
            this.Version = "22.1";
            ((System.ComponentModel.ISupportInitialize)(this)).EndInit();

        }

        #endregion

        private DevExpress.XtraReports.UI.DetailBand Area3;
        private DevExpress.XtraReports.UI.XRLabel CustomerNo1;
        private DevExpress.XtraReports.UI.XRLabel TypeCode_1;
        private DevExpress.XtraReports.UI.XRLabel CustomerName1;
        private DevExpress.XtraReports.UI.XRLabel SSNUM_1;
        private DevExpress.XtraReports.UI.XRLabel ContractDate1;
        private DevExpress.XtraReports.UI.XRLabel FirstPaymentDate1;
        private DevExpress.XtraReports.UI.XRLabel DateClosed1;
        private DevExpress.XtraReports.UI.XRLabel Dealer1;
        private DevExpress.XtraReports.UI.XRLabel DEALERNAME1;
        private DevExpress.XtraReports.UI.XRLabel State1;
        private DevExpress.XtraReports.UI.ReportHeaderBand Area1;
        private DevExpress.XtraReports.UI.XRLabel Text20;
        private DevExpress.XtraReports.UI.XRLabel Text21;
        private DevExpress.XtraReports.UI.XRLabel gdFromDate1;
        private DevExpress.XtraReports.UI.XRLabel Text22;
        private DevExpress.XtraReports.UI.XRLabel gdToDate1;
        private DevExpress.XtraReports.UI.PageHeaderBand Area2;
        private DevExpress.XtraReports.UI.XRLabel Text11;
        private DevExpress.XtraReports.UI.XRLabel Text12;
        private DevExpress.XtraReports.UI.XRLabel Text13;
        private DevExpress.XtraReports.UI.XRLabel Text14;
        private DevExpress.XtraReports.UI.XRLabel Text15;
        private DevExpress.XtraReports.UI.XRLabel Text16;
        private DevExpress.XtraReports.UI.XRLabel Text17;
        private DevExpress.XtraReports.UI.XRLabel Text18;
        private DevExpress.XtraReports.UI.XRLabel Text19;
        private DevExpress.XtraReports.UI.XRLine Line1;
        private DevExpress.XtraReports.UI.ReportFooterBand Area4;
        private DevExpress.XtraReports.UI.XRLabel Text1;
        private DevExpress.XtraReports.UI.XRLabel TotalCustomerCount1;
        private DevExpress.XtraReports.UI.PageFooterBand Area5;
        private DevExpress.XtraReports.UI.XRPageInfo PageNofM1;
        private DevExpress.XtraReports.UI.XRLabel gsUserName_1;
        private DevExpress.XtraReports.UI.XRLabel gsUserID_1;
        private DevExpress.XtraReports.UI.XRLabel Text5;
        private DevExpress.XtraReports.UI.XRPageInfo DataTime1;
        private DevExpress.XtraReports.UI.CalculatedField TypeCode;
        private DevExpress.XtraReports.UI.CalculatedField SSNUM;
        private DevExpress.XtraReports.Parameters.Parameter gdFromDate;
        private DevExpress.XtraReports.Parameters.Parameter gdToDate;
        private DevExpress.XtraReports.Parameters.Parameter gsUserName;
        private DevExpress.XtraReports.Parameters.Parameter gsUserID;
        private DevExpress.XtraReports.UI.XRPictureBox Picture1;
        private DevExpress.XtraReports.UI.TopMarginBand topMarginBand1;
        private DevExpress.XtraReports.UI.BottomMarginBand bottomMarginBand1;
    }
}

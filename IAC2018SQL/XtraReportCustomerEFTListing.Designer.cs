namespace IAC2021SQL
{
    partial class XtraReportCustomerEFTListing
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(XtraReportCustomerEFTListing));
            DevExpress.XtraReports.UI.XRSummary xrSummary3 = new DevExpress.XtraReports.UI.XRSummary();
            DevExpress.XtraReports.UI.XRSummary xrSummary4 = new DevExpress.XtraReports.UI.XRSummary();
            DevExpress.DataAccess.Sql.StoredProcQuery storedProcQuery1 = new DevExpress.DataAccess.Sql.StoredProcQuery();
            DevExpress.DataAccess.Sql.QueryParameter queryParameter1 = new DevExpress.DataAccess.Sql.QueryParameter();
            DevExpress.DataAccess.Sql.QueryParameter queryParameter2 = new DevExpress.DataAccess.Sql.QueryParameter();
            this.Area3 = new DevExpress.XtraReports.UI.DetailBand();
            this.CUSTOMERNO1 = new DevExpress.XtraReports.UI.XRLabel();
            this.SSNumber_1 = new DevExpress.XtraReports.UI.XRLabel();
            this.Name_2 = new DevExpress.XtraReports.UI.XRLabel();
            this.CUSTOMERREGULARAMOUNT1 = new DevExpress.XtraReports.UI.XRLabel();
            this.CUSTOMERINITDATE1 = new DevExpress.XtraReports.UI.XRLabel();
            this.CUSTOMERDAYDUE1 = new DevExpress.XtraReports.UI.XRLabel();
            this.PaidThrough_1 = new DevExpress.XtraReports.UI.XRLabel();
            this.OPNBANKCHECKDIGIT1 = new DevExpress.XtraReports.UI.XRLabel();
            this.OPNBANKTRANCODE1 = new DevExpress.XtraReports.UI.XRLabel();
            this.OPNBANKACCOUNTNO1 = new DevExpress.XtraReports.UI.XRLabel();
            this.CUSTOMERAUTOPAY1 = new DevExpress.XtraReports.UI.XRLabel();
            this.GroupHeaderArea1 = new DevExpress.XtraReports.UI.GroupHeaderBand();
            this.GroupName_1 = new DevExpress.XtraReports.UI.XRLabel();
            this.GroupFooterArea1 = new DevExpress.XtraReports.UI.GroupFooterBand();
            this.GroupName_2 = new DevExpress.XtraReports.UI.XRLabel();
            this.Text16 = new DevExpress.XtraReports.UI.XRLabel();
            this.CountofCUSTOMERNO2 = new DevExpress.XtraReports.UI.XRLabel();
            this.SumofCUSTOMERREGULARAMOUNT2 = new DevExpress.XtraReports.UI.XRLabel();
            this.Area1 = new DevExpress.XtraReports.UI.ReportHeaderBand();
            this.Text15 = new DevExpress.XtraReports.UI.XRLabel();
            this.Area2 = new DevExpress.XtraReports.UI.PageHeaderBand();
            this.Picture1 = new DevExpress.XtraReports.UI.XRPictureBox();
            this.Text1 = new DevExpress.XtraReports.UI.XRLabel();
            this.Text2 = new DevExpress.XtraReports.UI.XRLabel();
            this.Text3 = new DevExpress.XtraReports.UI.XRLabel();
            this.Text4 = new DevExpress.XtraReports.UI.XRLabel();
            this.Text6 = new DevExpress.XtraReports.UI.XRLabel();
            this.Text7 = new DevExpress.XtraReports.UI.XRLabel();
            this.Text9 = new DevExpress.XtraReports.UI.XRLabel();
            this.Text10 = new DevExpress.XtraReports.UI.XRLabel();
            this.Text11 = new DevExpress.XtraReports.UI.XRLabel();
            this.Text12 = new DevExpress.XtraReports.UI.XRLabel();
            this.Text13 = new DevExpress.XtraReports.UI.XRLabel();
            this.Line1 = new DevExpress.XtraReports.UI.XRLine();
            this.Text8 = new DevExpress.XtraReports.UI.XRLabel();
            this.CutOff_1 = new DevExpress.XtraReports.UI.XRLabel();
            this.DayDue_1 = new DevExpress.XtraReports.UI.XRLabel();
            this.Area4 = new DevExpress.XtraReports.UI.ReportFooterBand();
            this.SumofCUSTOMERREGULARAMOUNT1 = new DevExpress.XtraReports.UI.XRLabel();
            this.CountofCUSTOMERNO1 = new DevExpress.XtraReports.UI.XRLabel();
            this.Text17 = new DevExpress.XtraReports.UI.XRLabel();
            this.Area5 = new DevExpress.XtraReports.UI.PageFooterBand();
            this.PageNofM1 = new DevExpress.XtraReports.UI.XRPageInfo();
            this.gsUserName_1 = new DevExpress.XtraReports.UI.XRLabel();
            this.gsUserID_1 = new DevExpress.XtraReports.UI.XRLabel();
            this.Text5 = new DevExpress.XtraReports.UI.XRLabel();
            this.DataTime1 = new DevExpress.XtraReports.UI.XRPageInfo();
            this.DataDate1 = new DevExpress.XtraReports.UI.XRPageInfo();
            this.SSNumber = new DevExpress.XtraReports.UI.CalculatedField();
            this.Name_1 = new DevExpress.XtraReports.UI.CalculatedField();
            this.PaidThrough = new DevExpress.XtraReports.UI.CalculatedField();
            this.GroupName = new DevExpress.XtraReports.UI.CalculatedField();
            this.CutOff = new DevExpress.XtraReports.UI.CalculatedField();
            this.DayDue = new DevExpress.XtraReports.UI.CalculatedField();
            this.gsUserID = new DevExpress.XtraReports.Parameters.Parameter();
            this.gsUserName = new DevExpress.XtraReports.Parameters.Parameter();
            this.gdCutOff = new DevExpress.XtraReports.Parameters.Parameter();
            this.gnDayDue = new DevExpress.XtraReports.Parameters.Parameter();
            this.sqlDataSource1 = new DevExpress.DataAccess.Sql.SqlDataSource(this.components);
            this.topMarginBand1 = new DevExpress.XtraReports.UI.TopMarginBand();
            this.bottomMarginBand1 = new DevExpress.XtraReports.UI.BottomMarginBand();
            ((System.ComponentModel.ISupportInitialize)(this)).BeginInit();
            // 
            // Area3
            // 
            this.Area3.Controls.AddRange(new DevExpress.XtraReports.UI.XRControl[] {
            this.CUSTOMERNO1,
            this.SSNumber_1,
            this.Name_2,
            this.CUSTOMERREGULARAMOUNT1,
            this.CUSTOMERINITDATE1,
            this.CUSTOMERDAYDUE1,
            this.PaidThrough_1,
            this.OPNBANKCHECKDIGIT1,
            this.OPNBANKTRANCODE1,
            this.OPNBANKACCOUNTNO1,
            this.CUSTOMERAUTOPAY1});
            this.Area3.HeightF = 15F;
            this.Area3.KeepTogether = true;
            this.Area3.Name = "Area3";
            this.Area3.Padding = new DevExpress.XtraPrinting.PaddingInfo(0, 0, 0, 0, 100F);
            this.Area3.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopLeft;
            // 
            // CUSTOMERNO1
            // 
            this.CUSTOMERNO1.BackColor = System.Drawing.Color.Transparent;
            this.CUSTOMERNO1.BorderColor = System.Drawing.Color.Black;
            this.CUSTOMERNO1.Borders = DevExpress.XtraPrinting.BorderSide.None;
            this.CUSTOMERNO1.BorderWidth = 1F;
            this.CUSTOMERNO1.CanGrow = false;
            this.CUSTOMERNO1.ExpressionBindings.AddRange(new DevExpress.XtraReports.UI.ExpressionBinding[] {
            new DevExpress.XtraReports.UI.ExpressionBinding("BeforePrint", "Text", "[CUSTOMER_NO]")});
            this.CUSTOMERNO1.Font = new DevExpress.Drawing.DXFont("Arial", 8F);
            this.CUSTOMERNO1.ForeColor = System.Drawing.Color.Black;
            this.CUSTOMERNO1.LocationFloat = new DevExpress.Utils.PointFloat(0F, 0F);
            this.CUSTOMERNO1.Name = "CUSTOMERNO1";
            this.CUSTOMERNO1.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.CUSTOMERNO1.SizeF = new System.Drawing.SizeF(76.04166F, 15.34722F);
            this.CUSTOMERNO1.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopLeft;
            // 
            // SSNumber_1
            // 
            this.SSNumber_1.BackColor = System.Drawing.Color.Transparent;
            this.SSNumber_1.BorderColor = System.Drawing.Color.Black;
            this.SSNumber_1.Borders = DevExpress.XtraPrinting.BorderSide.None;
            this.SSNumber_1.BorderWidth = 1F;
            this.SSNumber_1.CanGrow = false;
            this.SSNumber_1.ExpressionBindings.AddRange(new DevExpress.XtraReports.UI.ExpressionBinding[] {
            new DevExpress.XtraReports.UI.ExpressionBinding("BeforePrint", "Text", "[SSNumber]")});
            this.SSNumber_1.Font = new DevExpress.Drawing.DXFont("Arial", 8F);
            this.SSNumber_1.ForeColor = System.Drawing.Color.Black;
            this.SSNumber_1.LocationFloat = new DevExpress.Utils.PointFloat(91.66666F, 0F);
            this.SSNumber_1.Name = "SSNumber_1";
            this.SSNumber_1.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.SSNumber_1.SizeF = new System.Drawing.SizeF(80.20834F, 15.34722F);
            this.SSNumber_1.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopLeft;
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
            this.Name_2.Font = new DevExpress.Drawing.DXFont("Arial", 8F);
            this.Name_2.ForeColor = System.Drawing.Color.Black;
            this.Name_2.LocationFloat = new DevExpress.Utils.PointFloat(183.3333F, 0F);
            this.Name_2.Name = "Name_2";
            this.Name_2.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.Name_2.SizeF = new System.Drawing.SizeF(250F, 15.34722F);
            this.Name_2.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopLeft;
            // 
            // CUSTOMERREGULARAMOUNT1
            // 
            this.CUSTOMERREGULARAMOUNT1.BackColor = System.Drawing.Color.Transparent;
            this.CUSTOMERREGULARAMOUNT1.BorderColor = System.Drawing.Color.Black;
            this.CUSTOMERREGULARAMOUNT1.Borders = DevExpress.XtraPrinting.BorderSide.None;
            this.CUSTOMERREGULARAMOUNT1.BorderWidth = 1F;
            this.CUSTOMERREGULARAMOUNT1.CanGrow = false;
            this.CUSTOMERREGULARAMOUNT1.ExpressionBindings.AddRange(new DevExpress.XtraReports.UI.ExpressionBinding[] {
            new DevExpress.XtraReports.UI.ExpressionBinding("BeforePrint", "Text", "[CUSTOMER_REGULAR_AMOUNT]")});
            this.CUSTOMERREGULARAMOUNT1.Font = new DevExpress.Drawing.DXFont("Arial", 8F);
            this.CUSTOMERREGULARAMOUNT1.ForeColor = System.Drawing.Color.Black;
            this.CUSTOMERREGULARAMOUNT1.LocationFloat = new DevExpress.Utils.PointFloat(441.6667F, 0F);
            this.CUSTOMERREGULARAMOUNT1.Name = "CUSTOMERREGULARAMOUNT1";
            this.CUSTOMERREGULARAMOUNT1.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.CUSTOMERREGULARAMOUNT1.SizeF = new System.Drawing.SizeF(72.43056F, 12.84722F);
            this.CUSTOMERREGULARAMOUNT1.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopRight;
            this.CUSTOMERREGULARAMOUNT1.TextFormatString = "{0:C2}";
            // 
            // CUSTOMERINITDATE1
            // 
            this.CUSTOMERINITDATE1.BackColor = System.Drawing.Color.Transparent;
            this.CUSTOMERINITDATE1.BorderColor = System.Drawing.Color.Black;
            this.CUSTOMERINITDATE1.Borders = DevExpress.XtraPrinting.BorderSide.None;
            this.CUSTOMERINITDATE1.BorderWidth = 1F;
            this.CUSTOMERINITDATE1.CanGrow = false;
            this.CUSTOMERINITDATE1.ExpressionBindings.AddRange(new DevExpress.XtraReports.UI.ExpressionBinding[] {
            new DevExpress.XtraReports.UI.ExpressionBinding("BeforePrint", "Text", "[CUSTOMER_INIT_DATE]")});
            this.CUSTOMERINITDATE1.Font = new DevExpress.Drawing.DXFont("Arial", 8F);
            this.CUSTOMERINITDATE1.ForeColor = System.Drawing.Color.Black;
            this.CUSTOMERINITDATE1.LocationFloat = new DevExpress.Utils.PointFloat(525F, 0F);
            this.CUSTOMERINITDATE1.Name = "CUSTOMERINITDATE1";
            this.CUSTOMERINITDATE1.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.CUSTOMERINITDATE1.SizeF = new System.Drawing.SizeF(66.52778F, 12.84722F);
            this.CUSTOMERINITDATE1.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopLeft;
            this.CUSTOMERINITDATE1.TextFormatString = "{0:MM/dd/yyyy}";
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
            this.CUSTOMERDAYDUE1.Font = new DevExpress.Drawing.DXFont("Arial", 8F);
            this.CUSTOMERDAYDUE1.ForeColor = System.Drawing.Color.Black;
            this.CUSTOMERDAYDUE1.LocationFloat = new DevExpress.Utils.PointFloat(608.3333F, 0F);
            this.CUSTOMERDAYDUE1.Name = "CUSTOMERDAYDUE1";
            this.CUSTOMERDAYDUE1.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.CUSTOMERDAYDUE1.SizeF = new System.Drawing.SizeF(22.70833F, 12.84722F);
            this.CUSTOMERDAYDUE1.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopRight;
            // 
            // PaidThrough_1
            // 
            this.PaidThrough_1.BackColor = System.Drawing.Color.Transparent;
            this.PaidThrough_1.BorderColor = System.Drawing.Color.Black;
            this.PaidThrough_1.Borders = DevExpress.XtraPrinting.BorderSide.None;
            this.PaidThrough_1.BorderWidth = 1F;
            this.PaidThrough_1.CanGrow = false;
            this.PaidThrough_1.ExpressionBindings.AddRange(new DevExpress.XtraReports.UI.ExpressionBinding[] {
            new DevExpress.XtraReports.UI.ExpressionBinding("BeforePrint", "Text", "[PaidThrough]")});
            this.PaidThrough_1.Font = new DevExpress.Drawing.DXFont("Arial", 8F);
            this.PaidThrough_1.ForeColor = System.Drawing.Color.Black;
            this.PaidThrough_1.LocationFloat = new DevExpress.Utils.PointFloat(666.6667F, 0F);
            this.PaidThrough_1.Name = "PaidThrough_1";
            this.PaidThrough_1.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.PaidThrough_1.SizeF = new System.Drawing.SizeF(43.75F, 15.34722F);
            this.PaidThrough_1.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopLeft;
            // 
            // OPNBANKCHECKDIGIT1
            // 
            this.OPNBANKCHECKDIGIT1.BackColor = System.Drawing.Color.Transparent;
            this.OPNBANKCHECKDIGIT1.BorderColor = System.Drawing.Color.Black;
            this.OPNBANKCHECKDIGIT1.Borders = DevExpress.XtraPrinting.BorderSide.None;
            this.OPNBANKCHECKDIGIT1.BorderWidth = 1F;
            this.OPNBANKCHECKDIGIT1.CanGrow = false;
            this.OPNBANKCHECKDIGIT1.ExpressionBindings.AddRange(new DevExpress.XtraReports.UI.ExpressionBinding[] {
            new DevExpress.XtraReports.UI.ExpressionBinding("BeforePrint", "Text", "[OPNBANK_CHECK_DIGIT]")});
            this.OPNBANKCHECKDIGIT1.Font = new DevExpress.Drawing.DXFont("Arial", 8F);
            this.OPNBANKCHECKDIGIT1.ForeColor = System.Drawing.Color.Black;
            this.OPNBANKCHECKDIGIT1.LocationFloat = new DevExpress.Utils.PointFloat(850F, 0F);
            this.OPNBANKCHECKDIGIT1.Name = "OPNBANKCHECKDIGIT1";
            this.OPNBANKCHECKDIGIT1.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.OPNBANKCHECKDIGIT1.SizeF = new System.Drawing.SizeF(11.45833F, 15.34722F);
            this.OPNBANKCHECKDIGIT1.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopLeft;
            // 
            // OPNBANKTRANCODE1
            // 
            this.OPNBANKTRANCODE1.BackColor = System.Drawing.Color.Transparent;
            this.OPNBANKTRANCODE1.BorderColor = System.Drawing.Color.Black;
            this.OPNBANKTRANCODE1.Borders = DevExpress.XtraPrinting.BorderSide.None;
            this.OPNBANKTRANCODE1.BorderWidth = 1F;
            this.OPNBANKTRANCODE1.CanGrow = false;
            this.OPNBANKTRANCODE1.ExpressionBindings.AddRange(new DevExpress.XtraReports.UI.ExpressionBinding[] {
            new DevExpress.XtraReports.UI.ExpressionBinding("BeforePrint", "Text", "[OPNBANK_TRAN_CODE]")});
            this.OPNBANKTRANCODE1.Font = new DevExpress.Drawing.DXFont("Arial", 8F);
            this.OPNBANKTRANCODE1.ForeColor = System.Drawing.Color.Black;
            this.OPNBANKTRANCODE1.LocationFloat = new DevExpress.Utils.PointFloat(750F, 0F);
            this.OPNBANKTRANCODE1.Name = "OPNBANKTRANCODE1";
            this.OPNBANKTRANCODE1.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.OPNBANKTRANCODE1.SizeF = new System.Drawing.SizeF(92.70834F, 15.34722F);
            this.OPNBANKTRANCODE1.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopLeft;
            // 
            // OPNBANKACCOUNTNO1
            // 
            this.OPNBANKACCOUNTNO1.BackColor = System.Drawing.Color.Transparent;
            this.OPNBANKACCOUNTNO1.BorderColor = System.Drawing.Color.Black;
            this.OPNBANKACCOUNTNO1.Borders = DevExpress.XtraPrinting.BorderSide.None;
            this.OPNBANKACCOUNTNO1.BorderWidth = 1F;
            this.OPNBANKACCOUNTNO1.CanGrow = false;
            this.OPNBANKACCOUNTNO1.ExpressionBindings.AddRange(new DevExpress.XtraReports.UI.ExpressionBinding[] {
            new DevExpress.XtraReports.UI.ExpressionBinding("BeforePrint", "Text", "[OPNBANK_ACCOUNT_NO]")});
            this.OPNBANKACCOUNTNO1.Font = new DevExpress.Drawing.DXFont("Arial", 8F);
            this.OPNBANKACCOUNTNO1.ForeColor = System.Drawing.Color.Black;
            this.OPNBANKACCOUNTNO1.LocationFloat = new DevExpress.Utils.PointFloat(875F, 0F);
            this.OPNBANKACCOUNTNO1.Name = "OPNBANKACCOUNTNO1";
            this.OPNBANKACCOUNTNO1.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.OPNBANKACCOUNTNO1.SizeF = new System.Drawing.SizeF(105.2083F, 15.34722F);
            this.OPNBANKACCOUNTNO1.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopLeft;
            // 
            // CUSTOMERAUTOPAY1
            // 
            this.CUSTOMERAUTOPAY1.BackColor = System.Drawing.Color.Transparent;
            this.CUSTOMERAUTOPAY1.BorderColor = System.Drawing.Color.Black;
            this.CUSTOMERAUTOPAY1.Borders = DevExpress.XtraPrinting.BorderSide.None;
            this.CUSTOMERAUTOPAY1.BorderWidth = 1F;
            this.CUSTOMERAUTOPAY1.CanGrow = false;
            this.CUSTOMERAUTOPAY1.ExpressionBindings.AddRange(new DevExpress.XtraReports.UI.ExpressionBinding[] {
            new DevExpress.XtraReports.UI.ExpressionBinding("BeforePrint", "Text", "[CUSTOMER_AUTOPAY]")});
            this.CUSTOMERAUTOPAY1.Font = new DevExpress.Drawing.DXFont("Arial", 10F);
            this.CUSTOMERAUTOPAY1.ForeColor = System.Drawing.Color.Black;
            this.CUSTOMERAUTOPAY1.LocationFloat = new DevExpress.Utils.PointFloat(1025F, 0F);
            this.CUSTOMERAUTOPAY1.Name = "CUSTOMERAUTOPAY1";
            this.CUSTOMERAUTOPAY1.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.CUSTOMERAUTOPAY1.SizeF = new System.Drawing.SizeF(16.66667F, 15.34722F);
            this.CUSTOMERAUTOPAY1.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopLeft;
            // 
            // GroupHeaderArea1
            // 
            this.GroupHeaderArea1.Controls.AddRange(new DevExpress.XtraReports.UI.XRControl[] {
            this.GroupName_1});
            this.GroupHeaderArea1.GroupFields.AddRange(new DevExpress.XtraReports.UI.GroupField[] {
            new DevExpress.XtraReports.UI.GroupField("CUSTOMER_IAC_TYPE", DevExpress.XtraReports.UI.XRColumnSortOrder.Ascending)});
            this.GroupHeaderArea1.HeightF = 23F;
            this.GroupHeaderArea1.KeepTogether = true;
            this.GroupHeaderArea1.Name = "GroupHeaderArea1";
            this.GroupHeaderArea1.Padding = new DevExpress.XtraPrinting.PaddingInfo(0, 0, 0, 0, 100F);
            this.GroupHeaderArea1.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopLeft;
            // 
            // GroupName_1
            // 
            this.GroupName_1.BackColor = System.Drawing.Color.Transparent;
            this.GroupName_1.BorderColor = System.Drawing.Color.Black;
            this.GroupName_1.Borders = DevExpress.XtraPrinting.BorderSide.None;
            this.GroupName_1.BorderWidth = 1F;
            this.GroupName_1.CanGrow = false;
            this.GroupName_1.ExpressionBindings.AddRange(new DevExpress.XtraReports.UI.ExpressionBinding[] {
            new DevExpress.XtraReports.UI.ExpressionBinding("BeforePrint", "Text", "[GroupName]")});
            this.GroupName_1.Font = new DevExpress.Drawing.DXFont("Arial", 8F, DevExpress.Drawing.DXFontStyle.Bold);
            this.GroupName_1.ForeColor = System.Drawing.Color.Black;
            this.GroupName_1.LocationFloat = new DevExpress.Utils.PointFloat(0F, 0F);
            this.GroupName_1.Name = "GroupName_1";
            this.GroupName_1.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.GroupName_1.SizeF = new System.Drawing.SizeF(110.4167F, 15.34722F);
            this.GroupName_1.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopLeft;
            // 
            // GroupFooterArea1
            // 
            this.GroupFooterArea1.Controls.AddRange(new DevExpress.XtraReports.UI.XRControl[] {
            this.GroupName_2,
            this.Text16,
            this.CountofCUSTOMERNO2,
            this.SumofCUSTOMERREGULARAMOUNT2});
            this.GroupFooterArea1.HeightF = 23F;
            this.GroupFooterArea1.KeepTogether = true;
            this.GroupFooterArea1.Name = "GroupFooterArea1";
            this.GroupFooterArea1.Padding = new DevExpress.XtraPrinting.PaddingInfo(0, 0, 0, 0, 100F);
            this.GroupFooterArea1.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopLeft;
            // 
            // GroupName_2
            // 
            this.GroupName_2.BackColor = System.Drawing.Color.Transparent;
            this.GroupName_2.BorderColor = System.Drawing.Color.Black;
            this.GroupName_2.Borders = DevExpress.XtraPrinting.BorderSide.None;
            this.GroupName_2.BorderWidth = 1F;
            this.GroupName_2.CanGrow = false;
            this.GroupName_2.ExpressionBindings.AddRange(new DevExpress.XtraReports.UI.ExpressionBinding[] {
            new DevExpress.XtraReports.UI.ExpressionBinding("BeforePrint", "Text", "[GroupName]")});
            this.GroupName_2.Font = new DevExpress.Drawing.DXFont("Arial", 8F, DevExpress.Drawing.DXFontStyle.Bold);
            this.GroupName_2.ForeColor = System.Drawing.Color.Black;
            this.GroupName_2.LocationFloat = new DevExpress.Utils.PointFloat(25F, 0F);
            this.GroupName_2.Name = "GroupName_2";
            this.GroupName_2.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.GroupName_2.SizeF = new System.Drawing.SizeF(110.4167F, 15.27778F);
            this.GroupName_2.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopLeft;
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
            this.Text16.LocationFloat = new DevExpress.Utils.PointFloat(141.6667F, 0F);
            this.Text16.Name = "Text16";
            this.Text16.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.Text16.SizeF = new System.Drawing.SizeF(60.41667F, 15.34722F);
            this.Text16.Text = "TOTALS";
            this.Text16.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopLeft;
            // 
            // CountofCUSTOMERNO2
            // 
            this.CountofCUSTOMERNO2.BackColor = System.Drawing.Color.Transparent;
            this.CountofCUSTOMERNO2.BorderColor = System.Drawing.Color.Black;
            this.CountofCUSTOMERNO2.Borders = DevExpress.XtraPrinting.BorderSide.None;
            this.CountofCUSTOMERNO2.BorderWidth = 1F;
            this.CountofCUSTOMERNO2.CanGrow = false;
            this.CountofCUSTOMERNO2.ExpressionBindings.AddRange(new DevExpress.XtraReports.UI.ExpressionBinding[] {
            new DevExpress.XtraReports.UI.ExpressionBinding("BeforePrint", "Text", "sumCount([CUSTOMER_NO])")});
            this.CountofCUSTOMERNO2.Font = new DevExpress.Drawing.DXFont("Arial", 8F, DevExpress.Drawing.DXFontStyle.Bold);
            this.CountofCUSTOMERNO2.ForeColor = System.Drawing.Color.Black;
            this.CountofCUSTOMERNO2.LocationFloat = new DevExpress.Utils.PointFloat(223.9583F, 0F);
            this.CountofCUSTOMERNO2.Name = "CountofCUSTOMERNO2";
            this.CountofCUSTOMERNO2.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.CountofCUSTOMERNO2.SizeF = new System.Drawing.SizeF(35.06944F, 13.33333F);
            xrSummary1.Running = DevExpress.XtraReports.UI.SummaryRunning.Group;
            this.CountofCUSTOMERNO2.Summary = xrSummary1;
            this.CountofCUSTOMERNO2.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopCenter;
            this.CountofCUSTOMERNO2.TextFormatString = "{0:N0}";
            // 
            // SumofCUSTOMERREGULARAMOUNT2
            // 
            this.SumofCUSTOMERREGULARAMOUNT2.BackColor = System.Drawing.Color.Transparent;
            this.SumofCUSTOMERREGULARAMOUNT2.BorderColor = System.Drawing.Color.Black;
            this.SumofCUSTOMERREGULARAMOUNT2.Borders = DevExpress.XtraPrinting.BorderSide.None;
            this.SumofCUSTOMERREGULARAMOUNT2.BorderWidth = 1F;
            this.SumofCUSTOMERREGULARAMOUNT2.CanGrow = false;
            this.SumofCUSTOMERREGULARAMOUNT2.ExpressionBindings.AddRange(new DevExpress.XtraReports.UI.ExpressionBinding[] {
            new DevExpress.XtraReports.UI.ExpressionBinding("BeforePrint", "Text", "sumSum([CUSTOMER_REGULAR_AMOUNT])")});
            this.SumofCUSTOMERREGULARAMOUNT2.Font = new DevExpress.Drawing.DXFont("Arial", 8F, DevExpress.Drawing.DXFontStyle.Bold);
            this.SumofCUSTOMERREGULARAMOUNT2.ForeColor = System.Drawing.Color.Black;
            this.SumofCUSTOMERREGULARAMOUNT2.LocationFloat = new DevExpress.Utils.PointFloat(283.3333F, 0F);
            this.SumofCUSTOMERREGULARAMOUNT2.Name = "SumofCUSTOMERREGULARAMOUNT2";
            this.SumofCUSTOMERREGULARAMOUNT2.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.SumofCUSTOMERREGULARAMOUNT2.SizeF = new System.Drawing.SizeF(91.66666F, 13.33333F);
            xrSummary2.Running = DevExpress.XtraReports.UI.SummaryRunning.Group;
            this.SumofCUSTOMERREGULARAMOUNT2.Summary = xrSummary2;
            this.SumofCUSTOMERREGULARAMOUNT2.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopRight;
            this.SumofCUSTOMERREGULARAMOUNT2.TextFormatString = "{0:C2}";
            // 
            // Area1
            // 
            this.Area1.Controls.AddRange(new DevExpress.XtraReports.UI.XRControl[] {
            this.Text15});
            this.Area1.HeightF = 15F;
            this.Area1.KeepTogether = true;
            this.Area1.Name = "Area1";
            this.Area1.Padding = new DevExpress.XtraPrinting.PaddingInfo(0, 0, 0, 0, 100F);
            this.Area1.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopLeft;
            // 
            // Text15
            // 
            this.Text15.BackColor = System.Drawing.Color.Transparent;
            this.Text15.BorderColor = System.Drawing.Color.Black;
            this.Text15.Borders = DevExpress.XtraPrinting.BorderSide.None;
            this.Text15.BorderWidth = 1F;
            this.Text15.CanGrow = false;
            this.Text15.Font = new DevExpress.Drawing.DXFont("Arial", 10F);
            this.Text15.ForeColor = System.Drawing.Color.Black;
            this.Text15.LocationFloat = new DevExpress.Utils.PointFloat(0F, 0F);
            this.Text15.Name = "Text15";
            this.Text15.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.Text15.SizeF = new System.Drawing.SizeF(129.7917F, 15.34722F);
            this.Text15.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopLeft;
            // 
            // Area2
            // 
            this.Area2.Controls.AddRange(new DevExpress.XtraReports.UI.XRControl[] {
            this.Picture1,
            this.Text1,
            this.Text2,
            this.Text3,
            this.Text4,
            this.Text6,
            this.Text7,
            this.Text9,
            this.Text10,
            this.Text11,
            this.Text12,
            this.Text13,
            this.Line1,
            this.Text8,
            this.CutOff_1,
            this.DayDue_1});
            this.Area2.HeightF = 197.5556F;
            this.Area2.Name = "Area2";
            this.Area2.Padding = new DevExpress.XtraPrinting.PaddingInfo(0, 0, 0, 0, 100F);
            this.Area2.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopLeft;
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
            this.Picture1.LocationFloat = new DevExpress.Utils.PointFloat(811.4583F, 0F);
            this.Picture1.Name = "Picture1";
            this.Picture1.Padding = new DevExpress.XtraPrinting.PaddingInfo(0, 0, 0, 0, 100F);
            this.Picture1.SizeF = new System.Drawing.SizeF(246.3889F, 95F);
            // 
            // Text1
            // 
            this.Text1.BackColor = System.Drawing.Color.Transparent;
            this.Text1.BorderColor = System.Drawing.Color.Black;
            this.Text1.Borders = DevExpress.XtraPrinting.BorderSide.None;
            this.Text1.BorderWidth = 1F;
            this.Text1.CanGrow = false;
            this.Text1.Font = new DevExpress.Drawing.DXFont("Arial", 14F);
            this.Text1.ForeColor = System.Drawing.Color.Black;
            this.Text1.LocationFloat = new DevExpress.Utils.PointFloat(0F, 96.875F);
            this.Text1.Name = "Text1";
            this.Text1.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.Text1.SizeF = new System.Drawing.SizeF(1058.333F, 25F);
            this.Text1.Text = "CUSTOMER EFT LISTING\n";
            this.Text1.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopCenter;
            // 
            // Text2
            // 
            this.Text2.BackColor = System.Drawing.Color.Transparent;
            this.Text2.BorderColor = System.Drawing.Color.Black;
            this.Text2.Borders = DevExpress.XtraPrinting.BorderSide.None;
            this.Text2.BorderWidth = 1F;
            this.Text2.CanGrow = false;
            this.Text2.Font = new DevExpress.Drawing.DXFont("Arial", 8F, DevExpress.Drawing.DXFontStyle.Bold);
            this.Text2.ForeColor = System.Drawing.Color.Black;
            this.Text2.LocationFloat = new DevExpress.Utils.PointFloat(0F, 180.2083F);
            this.Text2.Name = "Text2";
            this.Text2.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.Text2.SizeF = new System.Drawing.SizeF(70.83334F, 15.34722F);
            this.Text2.Text = "ACCOUNT";
            this.Text2.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopLeft;
            // 
            // Text3
            // 
            this.Text3.BackColor = System.Drawing.Color.Transparent;
            this.Text3.BorderColor = System.Drawing.Color.Black;
            this.Text3.Borders = DevExpress.XtraPrinting.BorderSide.None;
            this.Text3.BorderWidth = 1F;
            this.Text3.CanGrow = false;
            this.Text3.Font = new DevExpress.Drawing.DXFont("Arial", 8F, DevExpress.Drawing.DXFontStyle.Bold);
            this.Text3.ForeColor = System.Drawing.Color.Black;
            this.Text3.LocationFloat = new DevExpress.Utils.PointFloat(91.66666F, 180.2083F);
            this.Text3.Name = "Text3";
            this.Text3.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.Text3.SizeF = new System.Drawing.SizeF(70.83334F, 15.34722F);
            this.Text3.Text = "SOC. SEC";
            this.Text3.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopLeft;
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
            this.Text4.LocationFloat = new DevExpress.Utils.PointFloat(183.3333F, 180.2083F);
            this.Text4.Name = "Text4";
            this.Text4.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.Text4.SizeF = new System.Drawing.SizeF(125F, 15.34722F);
            this.Text4.Text = "CUSTOMER NAME";
            this.Text4.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopLeft;
            // 
            // Text6
            // 
            this.Text6.BackColor = System.Drawing.Color.Transparent;
            this.Text6.BorderColor = System.Drawing.Color.Black;
            this.Text6.Borders = DevExpress.XtraPrinting.BorderSide.None;
            this.Text6.BorderWidth = 1F;
            this.Text6.CanGrow = false;
            this.Text6.Font = new DevExpress.Drawing.DXFont("Arial", 8F, DevExpress.Drawing.DXFontStyle.Bold);
            this.Text6.ForeColor = System.Drawing.Color.Black;
            this.Text6.LocationFloat = new DevExpress.Utils.PointFloat(441.6667F, 180.2083F);
            this.Text6.Name = "Text6";
            this.Text6.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.Text6.SizeF = new System.Drawing.SizeF(70.83334F, 15.34722F);
            this.Text6.Text = "PAYMENT";
            this.Text6.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopLeft;
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
            this.Text7.LocationFloat = new DevExpress.Utils.PointFloat(525F, 180.2083F);
            this.Text7.Name = "Text7";
            this.Text7.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.Text7.SizeF = new System.Drawing.SizeF(70.83334F, 15.34722F);
            this.Text7.Text = "1ST-DATE";
            this.Text7.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopLeft;
            // 
            // Text9
            // 
            this.Text9.BackColor = System.Drawing.Color.Transparent;
            this.Text9.BorderColor = System.Drawing.Color.Black;
            this.Text9.Borders = DevExpress.XtraPrinting.BorderSide.None;
            this.Text9.BorderWidth = 1F;
            this.Text9.CanGrow = false;
            this.Text9.Font = new DevExpress.Drawing.DXFont("Arial", 8F, DevExpress.Drawing.DXFontStyle.Bold);
            this.Text9.ForeColor = System.Drawing.Color.Black;
            this.Text9.LocationFloat = new DevExpress.Utils.PointFloat(666.6667F, 180.2083F);
            this.Text9.Name = "Text9";
            this.Text9.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.Text9.SizeF = new System.Drawing.SizeF(66.66666F, 15.34722F);
            this.Text9.Text = "PAID-THRU";
            this.Text9.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopLeft;
            // 
            // Text10
            // 
            this.Text10.BackColor = System.Drawing.Color.Transparent;
            this.Text10.BorderColor = System.Drawing.Color.Black;
            this.Text10.Borders = DevExpress.XtraPrinting.BorderSide.None;
            this.Text10.BorderWidth = 1F;
            this.Text10.CanGrow = false;
            this.Text10.Font = new DevExpress.Drawing.DXFont("Arial", 8F, DevExpress.Drawing.DXFontStyle.Bold);
            this.Text10.ForeColor = System.Drawing.Color.Black;
            this.Text10.LocationFloat = new DevExpress.Utils.PointFloat(750F, 180.2083F);
            this.Text10.Name = "Text10";
            this.Text10.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.Text10.SizeF = new System.Drawing.SizeF(58.33333F, 15.34722F);
            this.Text10.Text = "BANK-NO";
            this.Text10.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopLeft;
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
            this.Text11.LocationFloat = new DevExpress.Utils.PointFloat(850F, 180.2083F);
            this.Text11.Name = "Text11";
            this.Text11.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.Text11.SizeF = new System.Drawing.SizeF(16.66667F, 15.34722F);
            this.Text11.Text = "CD";
            this.Text11.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopLeft;
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
            this.Text12.LocationFloat = new DevExpress.Utils.PointFloat(875F, 180.2083F);
            this.Text12.Name = "Text12";
            this.Text12.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.Text12.SizeF = new System.Drawing.SizeF(116.6667F, 15.34722F);
            this.Text12.Text = "BANK-ACCOUNT-NO";
            this.Text12.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopLeft;
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
            this.Text13.LocationFloat = new DevExpress.Utils.PointFloat(991.6667F, 180.2083F);
            this.Text13.Name = "Text13";
            this.Text13.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.Text13.SizeF = new System.Drawing.SizeF(66.6665F, 15.34721F);
            this.Text13.Text = "EFT-CODE";
            this.Text13.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopLeft;
            // 
            // Line1
            // 
            this.Line1.BackColor = System.Drawing.Color.Transparent;
            this.Line1.BorderColor = System.Drawing.Color.Black;
            this.Line1.Borders = DevExpress.XtraPrinting.BorderSide.Top;
            this.Line1.BorderWidth = 1F;
            this.Line1.Font = new DevExpress.Drawing.DXFont("Times New Roman", 9.75F);
            this.Line1.ForeColor = System.Drawing.Color.Black;
            this.Line1.LocationFloat = new DevExpress.Utils.PointFloat(0F, 195.5556F);
            this.Line1.Name = "Line1";
            this.Line1.Padding = new DevExpress.XtraPrinting.PaddingInfo(0, 0, 0, 0, 100F);
            this.Line1.SizeF = new System.Drawing.SizeF(1056.25F, 2F);
            // 
            // Text8
            // 
            this.Text8.BackColor = System.Drawing.Color.Transparent;
            this.Text8.BorderColor = System.Drawing.Color.Black;
            this.Text8.Borders = DevExpress.XtraPrinting.BorderSide.None;
            this.Text8.BorderWidth = 1F;
            this.Text8.CanGrow = false;
            this.Text8.Font = new DevExpress.Drawing.DXFont("Arial", 8F, DevExpress.Drawing.DXFontStyle.Bold);
            this.Text8.ForeColor = System.Drawing.Color.Black;
            this.Text8.LocationFloat = new DevExpress.Utils.PointFloat(608.3333F, 180.2083F);
            this.Text8.Name = "Text8";
            this.Text8.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.Text8.SizeF = new System.Drawing.SizeF(58.33337F, 15.34721F);
            this.Text8.Text = "DAY-DUE";
            this.Text8.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopLeft;
            // 
            // CutOff_1
            // 
            this.CutOff_1.BackColor = System.Drawing.Color.Transparent;
            this.CutOff_1.BorderColor = System.Drawing.Color.Black;
            this.CutOff_1.Borders = DevExpress.XtraPrinting.BorderSide.None;
            this.CutOff_1.BorderWidth = 1F;
            this.CutOff_1.CanGrow = false;
            this.CutOff_1.ExpressionBindings.AddRange(new DevExpress.XtraReports.UI.ExpressionBinding[] {
            new DevExpress.XtraReports.UI.ExpressionBinding("BeforePrint", "Text", "[CutOff]")});
            this.CutOff_1.Font = new DevExpress.Drawing.DXFont("Arial", 10F, DevExpress.Drawing.DXFontStyle.Bold);
            this.CutOff_1.ForeColor = System.Drawing.Color.Black;
            this.CutOff_1.LocationFloat = new DevExpress.Utils.PointFloat(375F, 130.2083F);
            this.CutOff_1.Name = "CutOff_1";
            this.CutOff_1.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.CutOff_1.SizeF = new System.Drawing.SizeF(200F, 15.34722F);
            this.CutOff_1.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopLeft;
            this.CutOff_1.TextFormatString = "{0:MM/dd/yyyy}";
            // 
            // DayDue_1
            // 
            this.DayDue_1.BackColor = System.Drawing.Color.Transparent;
            this.DayDue_1.BorderColor = System.Drawing.Color.Black;
            this.DayDue_1.Borders = DevExpress.XtraPrinting.BorderSide.None;
            this.DayDue_1.BorderWidth = 1F;
            this.DayDue_1.CanGrow = false;
            this.DayDue_1.ExpressionBindings.AddRange(new DevExpress.XtraReports.UI.ExpressionBinding[] {
            new DevExpress.XtraReports.UI.ExpressionBinding("BeforePrint", "Text", "[DayDue]")});
            this.DayDue_1.Font = new DevExpress.Drawing.DXFont("Arial", 10F, DevExpress.Drawing.DXFontStyle.Bold);
            this.DayDue_1.ForeColor = System.Drawing.Color.Black;
            this.DayDue_1.LocationFloat = new DevExpress.Utils.PointFloat(591.6667F, 130.2083F);
            this.DayDue_1.Name = "DayDue_1";
            this.DayDue_1.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.DayDue_1.SizeF = new System.Drawing.SizeF(138.5417F, 15.34722F);
            this.DayDue_1.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopLeft;
            this.DayDue_1.TextFormatString = "{0:N0}";
            // 
            // Area4
            // 
            this.Area4.Controls.AddRange(new DevExpress.XtraReports.UI.XRControl[] {
            this.SumofCUSTOMERREGULARAMOUNT1,
            this.CountofCUSTOMERNO1,
            this.Text17});
            this.Area4.HeightF = 30F;
            this.Area4.KeepTogether = true;
            this.Area4.Name = "Area4";
            this.Area4.Padding = new DevExpress.XtraPrinting.PaddingInfo(0, 0, 0, 0, 100F);
            this.Area4.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopLeft;
            // 
            // SumofCUSTOMERREGULARAMOUNT1
            // 
            this.SumofCUSTOMERREGULARAMOUNT1.BackColor = System.Drawing.Color.Transparent;
            this.SumofCUSTOMERREGULARAMOUNT1.BorderColor = System.Drawing.Color.Black;
            this.SumofCUSTOMERREGULARAMOUNT1.Borders = DevExpress.XtraPrinting.BorderSide.None;
            this.SumofCUSTOMERREGULARAMOUNT1.BorderWidth = 1F;
            this.SumofCUSTOMERREGULARAMOUNT1.CanGrow = false;
            this.SumofCUSTOMERREGULARAMOUNT1.ExpressionBindings.AddRange(new DevExpress.XtraReports.UI.ExpressionBinding[] {
            new DevExpress.XtraReports.UI.ExpressionBinding("BeforePrint", "Text", "sumSum([CUSTOMER_REGULAR_AMOUNT])")});
            this.SumofCUSTOMERREGULARAMOUNT1.Font = new DevExpress.Drawing.DXFont("Arial", 8F, DevExpress.Drawing.DXFontStyle.Bold);
            this.SumofCUSTOMERREGULARAMOUNT1.ForeColor = System.Drawing.Color.Black;
            this.SumofCUSTOMERREGULARAMOUNT1.LocationFloat = new DevExpress.Utils.PointFloat(283.3333F, 0F);
            this.SumofCUSTOMERREGULARAMOUNT1.Name = "SumofCUSTOMERREGULARAMOUNT1";
            this.SumofCUSTOMERREGULARAMOUNT1.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.SumofCUSTOMERREGULARAMOUNT1.SizeF = new System.Drawing.SizeF(91.66666F, 13.33333F);
            xrSummary3.Running = DevExpress.XtraReports.UI.SummaryRunning.Report;
            this.SumofCUSTOMERREGULARAMOUNT1.Summary = xrSummary3;
            this.SumofCUSTOMERREGULARAMOUNT1.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopRight;
            this.SumofCUSTOMERREGULARAMOUNT1.TextFormatString = "{0:C2}";
            // 
            // CountofCUSTOMERNO1
            // 
            this.CountofCUSTOMERNO1.BackColor = System.Drawing.Color.Transparent;
            this.CountofCUSTOMERNO1.BorderColor = System.Drawing.Color.Black;
            this.CountofCUSTOMERNO1.Borders = DevExpress.XtraPrinting.BorderSide.None;
            this.CountofCUSTOMERNO1.BorderWidth = 1F;
            this.CountofCUSTOMERNO1.CanGrow = false;
            this.CountofCUSTOMERNO1.ExpressionBindings.AddRange(new DevExpress.XtraReports.UI.ExpressionBinding[] {
            new DevExpress.XtraReports.UI.ExpressionBinding("BeforePrint", "Text", "sumCount([CUSTOMER_NO])")});
            this.CountofCUSTOMERNO1.Font = new DevExpress.Drawing.DXFont("Arial", 8F, DevExpress.Drawing.DXFontStyle.Bold);
            this.CountofCUSTOMERNO1.ForeColor = System.Drawing.Color.Black;
            this.CountofCUSTOMERNO1.LocationFloat = new DevExpress.Utils.PointFloat(223.9583F, 0F);
            this.CountofCUSTOMERNO1.Name = "CountofCUSTOMERNO1";
            this.CountofCUSTOMERNO1.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.CountofCUSTOMERNO1.SizeF = new System.Drawing.SizeF(35.06944F, 13.33333F);
            xrSummary4.Running = DevExpress.XtraReports.UI.SummaryRunning.Report;
            this.CountofCUSTOMERNO1.Summary = xrSummary4;
            this.CountofCUSTOMERNO1.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopCenter;
            this.CountofCUSTOMERNO1.TextFormatString = "{0:N0}";
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
            this.Text17.LocationFloat = new DevExpress.Utils.PointFloat(108.3333F, 0F);
            this.Text17.Name = "Text17";
            this.Text17.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.Text17.SizeF = new System.Drawing.SizeF(91.66666F, 15.34722F);
            this.Text17.Text = "GRAND TOTALS";
            this.Text17.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopLeft;
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
            this.PageNofM1.LocationFloat = new DevExpress.Utils.PointFloat(811.4583F, 0F);
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
            this.gsUserName_1.LocationFloat = new DevExpress.Utils.PointFloat(283.3333F, 0F);
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
            this.gsUserID_1.LocationFloat = new DevExpress.Utils.PointFloat(241.6667F, 0F);
            this.gsUserID_1.Name = "gsUserID_1";
            this.gsUserID_1.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.gsUserID_1.SizeF = new System.Drawing.SizeF(41.66655F, 18.33333F);
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
            this.Text5.LocationFloat = new DevExpress.Utils.PointFloat(191.6667F, 0F);
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
            this.DataTime1.LocationFloat = new DevExpress.Utils.PointFloat(80.20834F, 0F);
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
            this.DataDate1.SizeF = new System.Drawing.SizeF(76.04166F, 18.33333F);
            this.DataDate1.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopLeft;
            this.DataDate1.TextFormatString = "{0:MM/dd/yyyy}";
            // 
            // SSNumber
            // 
            this.SSNumber.DataMember = "EFTList";
            this.SSNumber.Expression = "[CUSTOMER_SS_1] + \'-\' + [CUSTOMER_SS_2] + \'-\' + [CUSTOMER_SS_3]";
            this.SSNumber.FieldType = DevExpress.XtraReports.UI.FieldType.String;
            this.SSNumber.Name = "SSNumber";
            // 
            // Name_1
            // 
            this.Name_1.DataMember = "EFTList";
            this.Name_1.Expression = "Trim([CUSTOMER_FIRST_NAME]) + \' \' + Trim([CUSTOMER_LAST_NAME])";
            this.Name_1.FieldType = DevExpress.XtraReports.UI.FieldType.String;
            this.Name_1.Name = "Name_1";
            // 
            // PaidThrough
            // 
            this.PaidThrough.DataMember = "EFTList";
            this.PaidThrough.Expression = "Trim([CUSTOMER_PAID_THRU_MM]) + \'/\' + Trim([CUSTOMER_PAID_THRU_YY])";
            this.PaidThrough.FieldType = DevExpress.XtraReports.UI.FieldType.String;
            this.PaidThrough.Name = "PaidThrough";
            // 
            // GroupName
            // 
            this.GroupName.DataMember = "EFTList";
            this.GroupName.Expression = "Iif([CUSTOMER_IAC_TYPE] = \'C\', \'CLOSED END\', \'OPEN END\')";
            this.GroupName.FieldType = DevExpress.XtraReports.UI.FieldType.String;
            this.GroupName.Name = "GroupName";
            // 
            // CutOff
            // 
            this.CutOff.DataMember = "EFTList";
            this.CutOff.Expression = "Iif(IsNullOrEmpty(ToStr(GetDate(?gdCutOff))), \'\',\'Requested Cut-Off: \' + ToStr(Ge" +
    "tDate(?gdCutOff)))";
            this.CutOff.FieldType = DevExpress.XtraReports.UI.FieldType.String;
            this.CutOff.Name = "CutOff";
            // 
            // DayDue
            // 
            this.DayDue.DataMember = "EFTList";
            this.DayDue.Expression = "Iif(?gnDayDue > 0, \'Day-Due: \' + FormatString(\'{0:0}\', ?gnDayDue), \'\')";
            this.DayDue.FieldType = DevExpress.XtraReports.UI.FieldType.String;
            this.DayDue.Name = "DayDue";
            // 
            // gsUserID
            // 
            this.gsUserID.Description = "Enter gsUserID:";
            this.gsUserID.Name = "gsUserID";
            this.gsUserID.ValueInfo = "MNN";
            // 
            // gsUserName
            // 
            this.gsUserName.Description = "Enter gsUserName:";
            this.gsUserName.Name = "gsUserName";
            this.gsUserName.ValueInfo = "Moses Newman";
            // 
            // gdCutOff
            // 
            this.gdCutOff.AllowNull = true;
            this.gdCutOff.Description = "Enter gdCutOff:";
            this.gdCutOff.Name = "gdCutOff";
            this.gdCutOff.Type = typeof(System.DateTime);
            // 
            // gnDayDue
            // 
            this.gnDayDue.Description = "Enter gnDayDue:";
            this.gnDayDue.Name = "gnDayDue";
            this.gnDayDue.Type = typeof(int);
            this.gnDayDue.ValueInfo = "5";
            // 
            // sqlDataSource1
            // 
            this.sqlDataSource1.ConnectionName = "IAC2021SQL.Properties.Settings.IAC2010SQLConnectionString";
            this.sqlDataSource1.Name = "sqlDataSource1";
            storedProcQuery1.Name = "EFTList";
            queryParameter1.Name = "@CUSTOMER_DAY_DUE";
            queryParameter1.Type = typeof(DevExpress.DataAccess.Expression);
            queryParameter1.Value = new DevExpress.DataAccess.Expression("?gnDayDue", typeof(int));
            queryParameter2.Name = "@CUSTOMER_INIT_DATE";
            queryParameter2.Type = typeof(DevExpress.DataAccess.Expression);
            queryParameter2.Value = new DevExpress.DataAccess.Expression("?gdCutOff", typeof(System.DateTime));
            storedProcQuery1.Parameters.AddRange(new DevExpress.DataAccess.Sql.QueryParameter[] {
            queryParameter1,
            queryParameter2});
            storedProcQuery1.StoredProcName = "EFTListFillByDayDueWithCuttOff";
            this.sqlDataSource1.Queries.AddRange(new DevExpress.DataAccess.Sql.SqlQuery[] {
            storedProcQuery1});
            this.sqlDataSource1.ResultSchemaSerializable = resources.GetString("sqlDataSource1.ResultSchemaSerializable");
            // 
            // topMarginBand1
            // 
            this.topMarginBand1.HeightF = 20F;
            this.topMarginBand1.Name = "topMarginBand1";
            // 
            // bottomMarginBand1
            // 
            this.bottomMarginBand1.HeightF = 20F;
            this.bottomMarginBand1.Name = "bottomMarginBand1";
            // 
            // XtraReportCustomerEFTListing
            // 
            this.Bands.AddRange(new DevExpress.XtraReports.UI.Band[] {
            this.Area3,
            this.GroupHeaderArea1,
            this.GroupFooterArea1,
            this.Area1,
            this.Area2,
            this.Area4,
            this.Area5,
            this.topMarginBand1,
            this.bottomMarginBand1});
            this.CalculatedFields.AddRange(new DevExpress.XtraReports.UI.CalculatedField[] {
            this.SSNumber,
            this.Name_1,
            this.PaidThrough,
            this.GroupName,
            this.CutOff,
            this.DayDue});
            this.ComponentStorage.AddRange(new System.ComponentModel.IComponent[] {
            this.sqlDataSource1});
            this.DataMember = "EFTList";
            this.DataSource = this.sqlDataSource1;
            this.Landscape = true;
            this.Margins = new DevExpress.Drawing.DXMargins(20F, 20F, 20F, 20F);
            this.PageHeight = 850;
            this.PageWidth = 1100;
            this.ParameterPanelLayoutItems.AddRange(new DevExpress.XtraReports.Parameters.ParameterPanelLayoutItem[] {
            new DevExpress.XtraReports.Parameters.ParameterLayoutItem(this.gsUserID, DevExpress.XtraReports.Parameters.Orientation.Horizontal),
            new DevExpress.XtraReports.Parameters.ParameterLayoutItem(this.gsUserName, DevExpress.XtraReports.Parameters.Orientation.Horizontal),
            new DevExpress.XtraReports.Parameters.ParameterLayoutItem(this.gdCutOff, DevExpress.XtraReports.Parameters.Orientation.Horizontal),
            new DevExpress.XtraReports.Parameters.ParameterLayoutItem(this.gnDayDue, DevExpress.XtraReports.Parameters.Orientation.Horizontal)});
            this.Parameters.AddRange(new DevExpress.XtraReports.Parameters.Parameter[] {
            this.gsUserID,
            this.gsUserName,
            this.gdCutOff,
            this.gnDayDue});
            this.Version = "23.1";
            this.DataSourceDemanded += new System.EventHandler<System.EventArgs>(this.XtraReportCustomerEFTListing_DataSourceDemanded);
            ((System.ComponentModel.ISupportInitialize)(this)).EndInit();

        }

        #endregion

        private DevExpress.XtraReports.UI.DetailBand Area3;
        private DevExpress.XtraReports.UI.XRLabel CUSTOMERNO1;
        private DevExpress.XtraReports.UI.XRLabel SSNumber_1;
        private DevExpress.XtraReports.UI.XRLabel Name_2;
        private DevExpress.XtraReports.UI.XRLabel CUSTOMERREGULARAMOUNT1;
        private DevExpress.XtraReports.UI.XRLabel CUSTOMERINITDATE1;
        private DevExpress.XtraReports.UI.XRLabel CUSTOMERDAYDUE1;
        private DevExpress.XtraReports.UI.XRLabel PaidThrough_1;
        private DevExpress.XtraReports.UI.XRLabel OPNBANKCHECKDIGIT1;
        private DevExpress.XtraReports.UI.XRLabel OPNBANKTRANCODE1;
        private DevExpress.XtraReports.UI.XRLabel OPNBANKACCOUNTNO1;
        private DevExpress.XtraReports.UI.XRLabel CUSTOMERAUTOPAY1;
        private DevExpress.XtraReports.UI.GroupHeaderBand GroupHeaderArea1;
        private DevExpress.XtraReports.UI.XRLabel GroupName_1;
        private DevExpress.XtraReports.UI.GroupFooterBand GroupFooterArea1;
        private DevExpress.XtraReports.UI.XRLabel GroupName_2;
        private DevExpress.XtraReports.UI.XRLabel Text16;
        private DevExpress.XtraReports.UI.XRLabel CountofCUSTOMERNO2;
        private DevExpress.XtraReports.UI.XRLabel SumofCUSTOMERREGULARAMOUNT2;
        private DevExpress.XtraReports.UI.ReportHeaderBand Area1;
        private DevExpress.XtraReports.UI.XRLabel Text15;
        private DevExpress.XtraReports.UI.PageHeaderBand Area2;
        private DevExpress.XtraReports.UI.XRLabel Text1;
        private DevExpress.XtraReports.UI.XRLabel Text2;
        private DevExpress.XtraReports.UI.XRLabel Text3;
        private DevExpress.XtraReports.UI.XRLabel Text4;
        private DevExpress.XtraReports.UI.XRLabel Text6;
        private DevExpress.XtraReports.UI.XRLabel Text7;
        private DevExpress.XtraReports.UI.XRLabel Text9;
        private DevExpress.XtraReports.UI.XRLabel Text10;
        private DevExpress.XtraReports.UI.XRLabel Text11;
        private DevExpress.XtraReports.UI.XRLabel Text12;
        private DevExpress.XtraReports.UI.XRLabel Text13;
        private DevExpress.XtraReports.UI.XRLine Line1;
        private DevExpress.XtraReports.UI.XRLabel Text8;
        private DevExpress.XtraReports.UI.XRLabel CutOff_1;
        private DevExpress.XtraReports.UI.XRLabel DayDue_1;
        private DevExpress.XtraReports.UI.ReportFooterBand Area4;
        private DevExpress.XtraReports.UI.XRLabel SumofCUSTOMERREGULARAMOUNT1;
        private DevExpress.XtraReports.UI.XRLabel CountofCUSTOMERNO1;
        private DevExpress.XtraReports.UI.XRLabel Text17;
        private DevExpress.XtraReports.UI.PageFooterBand Area5;
        private DevExpress.XtraReports.UI.XRPageInfo PageNofM1;
        private DevExpress.XtraReports.UI.XRLabel gsUserName_1;
        private DevExpress.XtraReports.UI.XRLabel gsUserID_1;
        private DevExpress.XtraReports.UI.XRLabel Text5;
        private DevExpress.XtraReports.UI.XRPageInfo DataTime1;
        private DevExpress.XtraReports.UI.XRPageInfo DataDate1;
        private DevExpress.XtraReports.UI.CalculatedField SSNumber;
        private DevExpress.XtraReports.UI.CalculatedField Name_1;
        private DevExpress.XtraReports.UI.CalculatedField PaidThrough;
        private DevExpress.XtraReports.UI.CalculatedField GroupName;
        private DevExpress.XtraReports.UI.CalculatedField CutOff;
        private DevExpress.XtraReports.UI.CalculatedField DayDue;
        private DevExpress.XtraReports.Parameters.Parameter gsUserID;
        private DevExpress.XtraReports.Parameters.Parameter gsUserName;
        private DevExpress.XtraReports.Parameters.Parameter gdCutOff;
        private DevExpress.XtraReports.Parameters.Parameter gnDayDue;
        private DevExpress.XtraReports.UI.XRPictureBox Picture1;
        private DevExpress.DataAccess.Sql.SqlDataSource sqlDataSource1;
        private DevExpress.XtraReports.UI.TopMarginBand topMarginBand1;
        private DevExpress.XtraReports.UI.BottomMarginBand bottomMarginBand1;
    }
}

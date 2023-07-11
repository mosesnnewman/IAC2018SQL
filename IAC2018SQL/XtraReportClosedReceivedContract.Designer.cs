namespace IAC2021SQL
{
    partial class XtraReportClosedReceivedContract
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(XtraReportClosedReceivedContract));
            DevExpress.DataAccess.Sql.StoredProcQuery storedProcQuery1 = new DevExpress.DataAccess.Sql.StoredProcQuery();
            DevExpress.DataAccess.Sql.QueryParameter queryParameter1 = new DevExpress.DataAccess.Sql.QueryParameter();
            DevExpress.DataAccess.Sql.QueryParameter queryParameter2 = new DevExpress.DataAccess.Sql.QueryParameter();
            DevExpress.DataAccess.Sql.QueryParameter queryParameter3 = new DevExpress.DataAccess.Sql.QueryParameter();
            DevExpress.DataAccess.Sql.QueryParameter queryParameter4 = new DevExpress.DataAccess.Sql.QueryParameter();
            DevExpress.DataAccess.Sql.StoredProcQuery storedProcQuery2 = new DevExpress.DataAccess.Sql.StoredProcQuery();
            DevExpress.DataAccess.Sql.MasterDetailInfo masterDetailInfo1 = new DevExpress.DataAccess.Sql.MasterDetailInfo();
            DevExpress.DataAccess.Sql.RelationColumnInfo relationColumnInfo1 = new DevExpress.DataAccess.Sql.RelationColumnInfo();
            this.Area3 = new DevExpress.XtraReports.UI.DetailBand();
            this.Area2 = new DevExpress.XtraReports.UI.PageHeaderBand();
            this.Area5 = new DevExpress.XtraReports.UI.PageFooterBand();
            this.CUSTOMERFIRSTNAME1 = new DevExpress.XtraReports.UI.XRLabel();
            this.CUSTOMERLASTNAME1 = new DevExpress.XtraReports.UI.XRLabel();
            this.CUSTOMERBALANCE1 = new DevExpress.XtraReports.UI.XRLabel();
            this.DateContractReceived1 = new DevExpress.XtraReports.UI.XRLabel();
            this.CUSTOMERNO1 = new DevExpress.XtraReports.UI.XRLabel();
            this.NewDealer_1 = new DevExpress.XtraReports.UI.XRLabel();
            this.Text3 = new DevExpress.XtraReports.UI.XRLabel();
            this.Text9 = new DevExpress.XtraReports.UI.XRLabel();
            this.Text10 = new DevExpress.XtraReports.UI.XRLabel();
            this.Text11 = new DevExpress.XtraReports.UI.XRLabel();
            this.Text12 = new DevExpress.XtraReports.UI.XRLabel();
            this.Line1 = new DevExpress.XtraReports.UI.XRLine();
            this.DataDate1 = new DevExpress.XtraReports.UI.XRPageInfo();
            this.DataTime1 = new DevExpress.XtraReports.UI.XRPageInfo();
            this.gsUserID_1 = new DevExpress.XtraReports.UI.XRLabel();
            this.gsUserName_1 = new DevExpress.XtraReports.UI.XRLabel();
            this.Text5 = new DevExpress.XtraReports.UI.XRLabel();
            this.NewDealer = new DevExpress.XtraReports.UI.CalculatedField();
            this.gsUserName = new DevExpress.XtraReports.Parameters.Parameter();
            this.gsUserID = new DevExpress.XtraReports.Parameters.Parameter();
            this.gdStartDate = new DevExpress.XtraReports.Parameters.Parameter();
            this.gdEndDate = new DevExpress.XtraReports.Parameters.Parameter();
            this.gsStatus = new DevExpress.XtraReports.Parameters.Parameter();
            this.xrPictureBox1 = new DevExpress.XtraReports.UI.XRPictureBox();
            this.xrPageInfo1 = new DevExpress.XtraReports.UI.XRPageInfo();
            this.sqlDataSource1 = new DevExpress.DataAccess.Sql.SqlDataSource(this.components);
            this.gsDealer = new DevExpress.XtraReports.Parameters.Parameter();
            this.xrLabel1 = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLabel2 = new DevExpress.XtraReports.UI.XRLabel();
            ((System.ComponentModel.ISupportInitialize)(this)).BeginInit();
            // 
            // Area3
            // 
            this.Area3.Controls.AddRange(new DevExpress.XtraReports.UI.XRControl[] {
            this.CUSTOMERFIRSTNAME1,
            this.CUSTOMERLASTNAME1,
            this.CUSTOMERBALANCE1,
            this.DateContractReceived1,
            this.CUSTOMERNO1,
            this.NewDealer_1});
            this.Area3.HeightF = 23F;
            this.Area3.KeepTogether = true;
            this.Area3.Name = "Area3";
            this.Area3.Padding = new DevExpress.XtraPrinting.PaddingInfo(0, 0, 0, 0, 100F);
            this.Area3.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopLeft;
            // 
            // Area2
            // 
            this.Area2.Controls.AddRange(new DevExpress.XtraReports.UI.XRControl[] {
            this.xrLabel2,
            this.xrLabel1,
            this.xrPictureBox1,
            this.Text3,
            this.Text9,
            this.Text10,
            this.Text11,
            this.Text12,
            this.Line1});
            this.Area2.HeightF = 174F;
            this.Area2.Name = "Area2";
            this.Area2.Padding = new DevExpress.XtraPrinting.PaddingInfo(0, 0, 0, 0, 100F);
            this.Area2.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopLeft;
            // 
            // Area5
            // 
            this.Area5.Controls.AddRange(new DevExpress.XtraReports.UI.XRControl[] {
            this.xrPageInfo1,
            this.DataDate1,
            this.DataTime1,
            this.gsUserID_1,
            this.gsUserName_1,
            this.Text5});
            this.Area5.HeightF = 24.45834F;
            this.Area5.Name = "Area5";
            this.Area5.Padding = new DevExpress.XtraPrinting.PaddingInfo(0, 0, 0, 0, 100F);
            this.Area5.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopLeft;
            // 
            // CUSTOMERFIRSTNAME1
            // 
            this.CUSTOMERFIRSTNAME1.BackColor = System.Drawing.Color.Transparent;
            this.CUSTOMERFIRSTNAME1.BorderColor = System.Drawing.Color.Black;
            this.CUSTOMERFIRSTNAME1.Borders = DevExpress.XtraPrinting.BorderSide.None;
            this.CUSTOMERFIRSTNAME1.BorderWidth = 1F;
            this.CUSTOMERFIRSTNAME1.CanGrow = false;
            this.CUSTOMERFIRSTNAME1.ExpressionBindings.AddRange(new DevExpress.XtraReports.UI.ExpressionBinding[] {
            new DevExpress.XtraReports.UI.ExpressionBinding("BeforePrint", "Text", "[CUSTOMER_FIRST_NAME]")});
            this.CUSTOMERFIRSTNAME1.Font = new DevExpress.Drawing.DXFont("Arial", 8F);
            this.CUSTOMERFIRSTNAME1.ForeColor = System.Drawing.Color.Black;
            this.CUSTOMERFIRSTNAME1.LocationFloat = new DevExpress.Utils.PointFloat(176.0417F, 0F);
            this.CUSTOMERFIRSTNAME1.Name = "CUSTOMERFIRSTNAME1";
            this.CUSTOMERFIRSTNAME1.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.CUSTOMERFIRSTNAME1.SizeF = new System.Drawing.SizeF(146.875F, 15.34722F);
            this.CUSTOMERFIRSTNAME1.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopLeft;
            // 
            // CUSTOMERLASTNAME1
            // 
            this.CUSTOMERLASTNAME1.BackColor = System.Drawing.Color.Transparent;
            this.CUSTOMERLASTNAME1.BorderColor = System.Drawing.Color.Black;
            this.CUSTOMERLASTNAME1.Borders = DevExpress.XtraPrinting.BorderSide.None;
            this.CUSTOMERLASTNAME1.BorderWidth = 1F;
            this.CUSTOMERLASTNAME1.CanGrow = false;
            this.CUSTOMERLASTNAME1.ExpressionBindings.AddRange(new DevExpress.XtraReports.UI.ExpressionBinding[] {
            new DevExpress.XtraReports.UI.ExpressionBinding("BeforePrint", "Text", "[CUSTOMER_LAST_NAME]")});
            this.CUSTOMERLASTNAME1.Font = new DevExpress.Drawing.DXFont("Arial", 8F);
            this.CUSTOMERLASTNAME1.ForeColor = System.Drawing.Color.Black;
            this.CUSTOMERLASTNAME1.LocationFloat = new DevExpress.Utils.PointFloat(340.625F, 0F);
            this.CUSTOMERLASTNAME1.Name = "CUSTOMERLASTNAME1";
            this.CUSTOMERLASTNAME1.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.CUSTOMERLASTNAME1.SizeF = new System.Drawing.SizeF(200F, 15.34722F);
            this.CUSTOMERLASTNAME1.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopLeft;
            // 
            // CUSTOMERBALANCE1
            // 
            this.CUSTOMERBALANCE1.BackColor = System.Drawing.Color.Transparent;
            this.CUSTOMERBALANCE1.BorderColor = System.Drawing.Color.Black;
            this.CUSTOMERBALANCE1.Borders = DevExpress.XtraPrinting.BorderSide.None;
            this.CUSTOMERBALANCE1.BorderWidth = 1F;
            this.CUSTOMERBALANCE1.CanGrow = false;
            this.CUSTOMERBALANCE1.ExpressionBindings.AddRange(new DevExpress.XtraReports.UI.ExpressionBinding[] {
            new DevExpress.XtraReports.UI.ExpressionBinding("BeforePrint", "Text", "[CUSTOMER_BALANCE]"),
            new DevExpress.XtraReports.UI.ExpressionBinding("BeforePrint", "Visible", "iif([CUSTOMER_BALANCE]<>0, True,False)")});
            this.CUSTOMERBALANCE1.Font = new DevExpress.Drawing.DXFont("Arial", 8F);
            this.CUSTOMERBALANCE1.ForeColor = System.Drawing.Color.Black;
            this.CUSTOMERBALANCE1.LocationFloat = new DevExpress.Utils.PointFloat(558.3333F, 0F);
            this.CUSTOMERBALANCE1.Name = "CUSTOMERBALANCE1";
            this.CUSTOMERBALANCE1.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.CUSTOMERBALANCE1.SizeF = new System.Drawing.SizeF(66.66666F, 15.34722F);
            this.CUSTOMERBALANCE1.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopRight;
            this.CUSTOMERBALANCE1.TextFormatString = "{0:C2}";
            // 
            // DateContractReceived1
            // 
            this.DateContractReceived1.BackColor = System.Drawing.Color.Transparent;
            this.DateContractReceived1.BorderColor = System.Drawing.Color.Black;
            this.DateContractReceived1.Borders = DevExpress.XtraPrinting.BorderSide.None;
            this.DateContractReceived1.BorderWidth = 1F;
            this.DateContractReceived1.CanGrow = false;
            this.DateContractReceived1.ExpressionBindings.AddRange(new DevExpress.XtraReports.UI.ExpressionBinding[] {
            new DevExpress.XtraReports.UI.ExpressionBinding("BeforePrint", "Text", "[DateContractReceived]")});
            this.DateContractReceived1.Font = new DevExpress.Drawing.DXFont("Arial", 8F);
            this.DateContractReceived1.ForeColor = System.Drawing.Color.Black;
            this.DateContractReceived1.LocationFloat = new DevExpress.Utils.PointFloat(676.0417F, 0F);
            this.DateContractReceived1.Name = "DateContractReceived1";
            this.DateContractReceived1.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.DateContractReceived1.SizeF = new System.Drawing.SizeF(98.95834F, 15.34722F);
            this.DateContractReceived1.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopLeft;
            this.DateContractReceived1.TextFormatString = "{0:MM/dd/yyyy}";
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
            this.CUSTOMERNO1.LocationFloat = new DevExpress.Utils.PointFloat(91.66666F, 0F);
            this.CUSTOMERNO1.Name = "CUSTOMERNO1";
            this.CUSTOMERNO1.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.CUSTOMERNO1.SizeF = new System.Drawing.SizeF(58.33333F, 15.34722F);
            this.CUSTOMERNO1.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopLeft;
            // 
            // NewDealer_1
            // 
            this.NewDealer_1.BackColor = System.Drawing.Color.Transparent;
            this.NewDealer_1.BorderColor = System.Drawing.Color.Black;
            this.NewDealer_1.Borders = DevExpress.XtraPrinting.BorderSide.None;
            this.NewDealer_1.BorderWidth = 1F;
            this.NewDealer_1.CanGrow = false;
            this.NewDealer_1.ExpressionBindings.AddRange(new DevExpress.XtraReports.UI.ExpressionBinding[] {
            new DevExpress.XtraReports.UI.ExpressionBinding("BeforePrint", "Text", "[NewDealer]")});
            this.NewDealer_1.Font = new DevExpress.Drawing.DXFont("Arial", 8F);
            this.NewDealer_1.ForeColor = System.Drawing.Color.Black;
            this.NewDealer_1.LocationFloat = new DevExpress.Utils.PointFloat(0F, 0F);
            this.NewDealer_1.Name = "NewDealer_1";
            this.NewDealer_1.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.NewDealer_1.SizeF = new System.Drawing.SizeF(66.66666F, 15.34722F);
            this.NewDealer_1.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopLeft;
            // 
            // Text3
            // 
            this.Text3.BackColor = System.Drawing.Color.Transparent;
            this.Text3.BorderColor = System.Drawing.Color.Black;
            this.Text3.Borders = DevExpress.XtraPrinting.BorderSide.None;
            this.Text3.BorderWidth = 1F;
            this.Text3.CanGrow = false;
            this.Text3.Font = new DevExpress.Drawing.DXFont("Segoe UI", 14F, DevExpress.Drawing.DXFontStyle.Bold);
            this.Text3.ForeColor = System.Drawing.Color.Black;
            this.Text3.LocationFloat = new DevExpress.Utils.PointFloat(0F, 108.3333F);
            this.Text3.Name = "Text3";
            this.Text3.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.Text3.SizeF = new System.Drawing.SizeF(800F, 25.00001F);
            this.Text3.Text = "CLOSED RECEIVED CONTRACTS";
            this.Text3.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopCenter;
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
            this.Text9.LocationFloat = new DevExpress.Utils.PointFloat(0F, 150F);
            this.Text9.Name = "Text9";
            this.Text9.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.Text9.SizeF = new System.Drawing.SizeF(66.66666F, 15.34722F);
            this.Text9.Text = "Dealer No.";
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
            this.Text10.LocationFloat = new DevExpress.Utils.PointFloat(91.66667F, 150F);
            this.Text10.Name = "Text10";
            this.Text10.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.Text10.SizeF = new System.Drawing.SizeF(58.33333F, 15.34722F);
            this.Text10.Text = "Account";
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
            this.Text11.LocationFloat = new DevExpress.Utils.PointFloat(558.3333F, 150F);
            this.Text11.Name = "Text11";
            this.Text11.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.Text11.SizeF = new System.Drawing.SizeF(66.66666F, 15.34722F);
            this.Text11.Text = "Balance";
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
            this.Text12.LocationFloat = new DevExpress.Utils.PointFloat(635F, 150F);
            this.Text12.Name = "Text12";
            this.Text12.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.Text12.SizeF = new System.Drawing.SizeF(140F, 15.34723F);
            this.Text12.Text = "Date Contract Received";
            this.Text12.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopLeft;
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
            this.Line1.LocationFloat = new DevExpress.Utils.PointFloat(0F, 170.8333F);
            this.Line1.Name = "Line1";
            this.Line1.Padding = new DevExpress.XtraPrinting.PaddingInfo(0, 0, 0, 0, 100F);
            this.Line1.SizeF = new System.Drawing.SizeF(775F, 3.125F);
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
            this.gsUserID_1.SizeF = new System.Drawing.SizeF(41.66666F, 18.33333F);
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
            this.gsUserName_1.LocationFloat = new DevExpress.Utils.PointFloat(291.6667F, 0F);
            this.gsUserName_1.Name = "gsUserName_1";
            this.gsUserName_1.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.gsUserName_1.SizeF = new System.Drawing.SizeF(158.3333F, 18.33333F);
            this.gsUserName_1.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopLeft;
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
            this.Text5.LocationFloat = new DevExpress.Utils.PointFloat(200F, 0F);
            this.Text5.Name = "Text5";
            this.Text5.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.Text5.SizeF = new System.Drawing.SizeF(50F, 18.33333F);
            this.Text5.Text = "USER:";
            this.Text5.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopLeft;
            // 
            // NewDealer
            // 
            this.NewDealer.DataMember = "CUSTOMER";
            this.NewDealer.Expression = "[CUSTOMERDEALER].[DEALER_ST] + \'-\' + FormatString(\'{0:0}\', [CUSTOMER_DEALER])";
            this.NewDealer.FieldType = DevExpress.XtraReports.UI.FieldType.String;
            this.NewDealer.Name = "NewDealer";
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
            // gdStartDate
            // 
            this.gdStartDate.Description = "Enter gdStartDate:";
            this.gdStartDate.Name = "gdStartDate";
            this.gdStartDate.Type = typeof(System.DateTime);
            this.gdStartDate.ValueInfo = "2021-08-01";
            // 
            // gdEndDate
            // 
            this.gdEndDate.Description = "Enter gdEndDate:";
            this.gdEndDate.Name = "gdEndDate";
            this.gdEndDate.Type = typeof(System.DateTime);
            this.gdEndDate.ValueInfo = "2022-08-08";
            // 
            // gsStatus
            // 
            this.gsStatus.Description = "Enter gsStatus:";
            this.gsStatus.Name = "gsStatus";
            this.gsStatus.ValueInfo = "A%";
            // 
            // xrPictureBox1
            // 
            this.xrPictureBox1.BackColor = System.Drawing.Color.Transparent;
            this.xrPictureBox1.BorderColor = System.Drawing.Color.Black;
            this.xrPictureBox1.Borders = DevExpress.XtraPrinting.BorderSide.None;
            this.xrPictureBox1.BorderWidth = 1F;
            this.xrPictureBox1.Font = new DevExpress.Drawing.DXFont("Times New Roman", 9.75F);
            this.xrPictureBox1.ForeColor = System.Drawing.Color.Black;
            this.xrPictureBox1.ImageSource = new DevExpress.XtraPrinting.Drawing.ImageSource("img", resources.GetString("xrPictureBox1.ImageSource"));
            this.xrPictureBox1.LocationFloat = new DevExpress.Utils.PointFloat(553.6112F, 0F);
            this.xrPictureBox1.Name = "xrPictureBox1";
            this.xrPictureBox1.Padding = new DevExpress.XtraPrinting.PaddingInfo(0, 0, 0, 0, 100F);
            this.xrPictureBox1.SizeF = new System.Drawing.SizeF(246.3888F, 95F);
            // 
            // xrPageInfo1
            // 
            this.xrPageInfo1.BackColor = System.Drawing.Color.Transparent;
            this.xrPageInfo1.BorderColor = System.Drawing.Color.Black;
            this.xrPageInfo1.Borders = DevExpress.XtraPrinting.BorderSide.None;
            this.xrPageInfo1.BorderWidth = 1F;
            this.xrPageInfo1.Font = new DevExpress.Drawing.DXFont("Arial", 10F);
            this.xrPageInfo1.ForeColor = System.Drawing.Color.Black;
            this.xrPageInfo1.LocationFloat = new DevExpress.Utils.PointFloat(641.6667F, 3.814697E-06F);
            this.xrPageInfo1.Name = "xrPageInfo1";
            this.xrPageInfo1.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrPageInfo1.SizeF = new System.Drawing.SizeF(158.3333F, 18.33333F);
            this.xrPageInfo1.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopLeft;
            // 
            // sqlDataSource1
            // 
            this.sqlDataSource1.ConnectionName = "IAC2021SQL.Properties.Settings.IAC2010SQLConnectionString";
            this.sqlDataSource1.Name = "sqlDataSource1";
            storedProcQuery1.Name = "CUSTOMER";
            queryParameter1.Name = "@DealerNo";
            queryParameter1.Type = typeof(DevExpress.DataAccess.Expression);
            queryParameter1.Value = new DevExpress.DataAccess.Expression("?gsDealer", typeof(string));
            queryParameter2.Name = "@Status";
            queryParameter2.Type = typeof(DevExpress.DataAccess.Expression);
            queryParameter2.Value = new DevExpress.DataAccess.Expression("?gsStatus", typeof(string));
            queryParameter3.Name = "@StartDate";
            queryParameter3.Type = typeof(DevExpress.DataAccess.Expression);
            queryParameter3.Value = new DevExpress.DataAccess.Expression("?gdStartDate", typeof(System.DateTime));
            queryParameter4.Name = "@EndDate";
            queryParameter4.Type = typeof(DevExpress.DataAccess.Expression);
            queryParameter4.Value = new DevExpress.DataAccess.Expression("?gdEndDate", typeof(System.DateTime));
            storedProcQuery1.Parameters.AddRange(new DevExpress.DataAccess.Sql.QueryParameter[] {
            queryParameter1,
            queryParameter2,
            queryParameter3,
            queryParameter4});
            storedProcQuery1.StoredProcName = "ClosedReceivedContract";
            storedProcQuery2.Name = "DEALER";
            storedProcQuery2.StoredProcName = "ClosedDealerFillByAll";
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
            // gsDealer
            // 
            this.gsDealer.Description = "Enter Dealer Numnber: ";
            this.gsDealer.Name = "gsDealer";
            this.gsDealer.ValueInfo = "%";
            // 
            // xrLabel1
            // 
            this.xrLabel1.BackColor = System.Drawing.Color.Transparent;
            this.xrLabel1.BorderColor = System.Drawing.Color.Black;
            this.xrLabel1.Borders = DevExpress.XtraPrinting.BorderSide.None;
            this.xrLabel1.BorderWidth = 1F;
            this.xrLabel1.CanGrow = false;
            this.xrLabel1.Font = new DevExpress.Drawing.DXFont("Arial", 8F, DevExpress.Drawing.DXFontStyle.Bold);
            this.xrLabel1.ForeColor = System.Drawing.Color.Black;
            this.xrLabel1.LocationFloat = new DevExpress.Utils.PointFloat(176.0417F, 150F);
            this.xrLabel1.Name = "xrLabel1";
            this.xrLabel1.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabel1.SizeF = new System.Drawing.SizeF(146.875F, 15.34722F);
            this.xrLabel1.Text = "First Name";
            this.xrLabel1.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopLeft;
            // 
            // xrLabel2
            // 
            this.xrLabel2.BackColor = System.Drawing.Color.Transparent;
            this.xrLabel2.BorderColor = System.Drawing.Color.Black;
            this.xrLabel2.Borders = DevExpress.XtraPrinting.BorderSide.None;
            this.xrLabel2.BorderWidth = 1F;
            this.xrLabel2.CanGrow = false;
            this.xrLabel2.Font = new DevExpress.Drawing.DXFont("Arial", 8F, DevExpress.Drawing.DXFontStyle.Bold);
            this.xrLabel2.ForeColor = System.Drawing.Color.Black;
            this.xrLabel2.LocationFloat = new DevExpress.Utils.PointFloat(340.625F, 150F);
            this.xrLabel2.Name = "xrLabel2";
            this.xrLabel2.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabel2.SizeF = new System.Drawing.SizeF(200F, 15.34722F);
            this.xrLabel2.Text = "Last Name";
            this.xrLabel2.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopLeft;
            // 
            // XtraReportClosedReceivedContract
            // 
            this.Bands.AddRange(new DevExpress.XtraReports.UI.Band[] {
            this.Area3,
            this.Area2,
            this.Area5});
            this.CalculatedFields.AddRange(new DevExpress.XtraReports.UI.CalculatedField[] {
            this.NewDealer});
            this.ComponentStorage.AddRange(new System.ComponentModel.IComponent[] {
            this.sqlDataSource1});
            this.DataMember = "CUSTOMER";
            this.DataSource = this.sqlDataSource1;
            this.Margins = new DevExpress.Drawing.DXMargins(25, 25, 25, 25);
            this.ParameterPanelLayoutItems.AddRange(new DevExpress.XtraReports.Parameters.ParameterPanelLayoutItem[] {
            new DevExpress.XtraReports.Parameters.ParameterLayoutItem(this.gsUserName, DevExpress.XtraReports.Parameters.Orientation.Horizontal),
            new DevExpress.XtraReports.Parameters.ParameterLayoutItem(this.gsUserID, DevExpress.XtraReports.Parameters.Orientation.Horizontal),
            new DevExpress.XtraReports.Parameters.ParameterLayoutItem(this.gdStartDate, DevExpress.XtraReports.Parameters.Orientation.Horizontal),
            new DevExpress.XtraReports.Parameters.ParameterLayoutItem(this.gdEndDate, DevExpress.XtraReports.Parameters.Orientation.Horizontal),
            new DevExpress.XtraReports.Parameters.ParameterLayoutItem(this.gsStatus, DevExpress.XtraReports.Parameters.Orientation.Horizontal),
            new DevExpress.XtraReports.Parameters.ParameterLayoutItem(this.gsDealer, DevExpress.XtraReports.Parameters.Orientation.Horizontal)});
            this.Parameters.AddRange(new DevExpress.XtraReports.Parameters.Parameter[] {
            this.gsUserName,
            this.gsUserID,
            this.gdStartDate,
            this.gdEndDate,
            this.gsStatus,
            this.gsDealer});
            this.Version = "22.1";
            ((System.ComponentModel.ISupportInitialize)(this)).EndInit();

        }

        #endregion

        private DevExpress.XtraReports.UI.DetailBand Area3;
        private DevExpress.XtraReports.UI.XRLabel CUSTOMERFIRSTNAME1;
        private DevExpress.XtraReports.UI.XRLabel CUSTOMERLASTNAME1;
        private DevExpress.XtraReports.UI.XRLabel CUSTOMERBALANCE1;
        private DevExpress.XtraReports.UI.XRLabel DateContractReceived1;
        private DevExpress.XtraReports.UI.XRLabel CUSTOMERNO1;
        private DevExpress.XtraReports.UI.XRLabel NewDealer_1;
        private DevExpress.XtraReports.UI.PageHeaderBand Area2;
        private DevExpress.XtraReports.UI.XRLabel Text3;
        private DevExpress.XtraReports.UI.XRLabel Text9;
        private DevExpress.XtraReports.UI.XRLabel Text10;
        private DevExpress.XtraReports.UI.XRLabel Text11;
        private DevExpress.XtraReports.UI.XRLabel Text12;
        private DevExpress.XtraReports.UI.XRLine Line1;
        private DevExpress.XtraReports.UI.PageFooterBand Area5;
        private DevExpress.XtraReports.UI.XRPageInfo DataDate1;
        private DevExpress.XtraReports.UI.XRPageInfo DataTime1;
        private DevExpress.XtraReports.UI.XRLabel gsUserID_1;
        private DevExpress.XtraReports.UI.XRLabel gsUserName_1;
        private DevExpress.XtraReports.UI.XRLabel Text5;
        private DevExpress.XtraReports.UI.CalculatedField NewDealer;
        private DevExpress.XtraReports.Parameters.Parameter gsUserName;
        private DevExpress.XtraReports.Parameters.Parameter gsUserID;
        private DevExpress.XtraReports.Parameters.Parameter gdStartDate;
        private DevExpress.XtraReports.Parameters.Parameter gdEndDate;
        private DevExpress.XtraReports.Parameters.Parameter gsStatus;
        private DevExpress.XtraReports.UI.XRPictureBox xrPictureBox1;
        private DevExpress.XtraReports.UI.XRPageInfo xrPageInfo1;
        private DevExpress.DataAccess.Sql.SqlDataSource sqlDataSource1;
        private DevExpress.XtraReports.Parameters.Parameter gsDealer;
        private DevExpress.XtraReports.UI.XRLabel xrLabel2;
        private DevExpress.XtraReports.UI.XRLabel xrLabel1;
    }
}

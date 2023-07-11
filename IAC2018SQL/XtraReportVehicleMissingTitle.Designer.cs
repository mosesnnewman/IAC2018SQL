namespace IAC2021SQL
{
    partial class XtraReportVehicleMissingTitle
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(XtraReportVehicleMissingTitle));
            this.Area3 = new DevExpress.XtraReports.UI.DetailBand();
            this.VEHICLECUSTNO1 = new DevExpress.XtraReports.UI.XRLabel();
            this.CustomerName_1 = new DevExpress.XtraReports.UI.XRLabel();
            this.Dealer_1 = new DevExpress.XtraReports.UI.XRLabel();
            this.VEHICLEYEAR1 = new DevExpress.XtraReports.UI.XRLabel();
            this.VEHICLEMAKE1 = new DevExpress.XtraReports.UI.XRLabel();
            this.VEHICLEVIN1 = new DevExpress.XtraReports.UI.XRLabel();
            this.VEHICLEMODEL1 = new DevExpress.XtraReports.UI.XRLabel();
            this.ControlDate1 = new DevExpress.XtraReports.UI.XRLabel();
            this.Area1 = new DevExpress.XtraReports.UI.ReportHeaderBand();
            this.Area2 = new DevExpress.XtraReports.UI.PageHeaderBand();
            this.xrPictureBox1 = new DevExpress.XtraReports.UI.XRPictureBox();
            this.Text18 = new DevExpress.XtraReports.UI.XRLabel();
            this.Line1 = new DevExpress.XtraReports.UI.XRLine();
            this.Text1 = new DevExpress.XtraReports.UI.XRLabel();
            this.Text2 = new DevExpress.XtraReports.UI.XRLabel();
            this.Text3 = new DevExpress.XtraReports.UI.XRLabel();
            this.Text4 = new DevExpress.XtraReports.UI.XRLabel();
            this.gdStartDate1 = new DevExpress.XtraReports.UI.XRLabel();
            this.gdEndDate1 = new DevExpress.XtraReports.UI.XRLabel();
            this.Text5 = new DevExpress.XtraReports.UI.XRLabel();
            this.Text6 = new DevExpress.XtraReports.UI.XRLabel();
            this.Text7 = new DevExpress.XtraReports.UI.XRLabel();
            this.gsStatus1 = new DevExpress.XtraReports.UI.XRLabel();
            this.Area4 = new DevExpress.XtraReports.UI.ReportFooterBand();
            this.Area5 = new DevExpress.XtraReports.UI.PageFooterBand();
            this.PageNofM1 = new DevExpress.XtraReports.UI.XRPageInfo();
            this.gsUserName_1 = new DevExpress.XtraReports.UI.XRLabel();
            this.gsUserID_1 = new DevExpress.XtraReports.UI.XRLabel();
            this.Text17 = new DevExpress.XtraReports.UI.XRLabel();
            this.DataTime1 = new DevExpress.XtraReports.UI.XRPageInfo();
            this.DataDate1 = new DevExpress.XtraReports.UI.XRPageInfo();
            this.CustomerName = new DevExpress.XtraReports.UI.CalculatedField();
            this.Dealer = new DevExpress.XtraReports.UI.CalculatedField();
            this.gsUserName = new DevExpress.XtraReports.Parameters.Parameter();
            this.gsUserID = new DevExpress.XtraReports.Parameters.Parameter();
            this.gdStartDate = new DevExpress.XtraReports.Parameters.Parameter();
            this.gdEndDate = new DevExpress.XtraReports.Parameters.Parameter();
            this.gsStatus = new DevExpress.XtraReports.Parameters.Parameter();
            this.aLTNAMETableAdapter = new IAC2021SQL.IACDataSetTableAdapters.ALTNAMETableAdapter();
            this.vehicleMissingTitleTableAdapter1 = new IAC2021SQL.IACDataSetTableAdapters.VehicleMissingTitleTableAdapter();
            this.topMarginBand1 = new DevExpress.XtraReports.UI.TopMarginBand();
            this.bottomMarginBand1 = new DevExpress.XtraReports.UI.BottomMarginBand();
            this.iacDataSet1 = new IAC2021SQL.IACDataSet();
            ((System.ComponentModel.ISupportInitialize)(this.iacDataSet1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this)).BeginInit();
            // 
            // Area3
            // 
            this.Area3.Controls.AddRange(new DevExpress.XtraReports.UI.XRControl[] {
            this.VEHICLECUSTNO1,
            this.CustomerName_1,
            this.Dealer_1,
            this.VEHICLEYEAR1,
            this.VEHICLEMAKE1,
            this.VEHICLEVIN1,
            this.VEHICLEMODEL1,
            this.ControlDate1});
            this.Area3.HeightF = 25F;
            this.Area3.KeepTogether = true;
            this.Area3.Name = "Area3";
            this.Area3.Padding = new DevExpress.XtraPrinting.PaddingInfo(0, 0, 0, 0, 100F);
            this.Area3.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopLeft;
            // 
            // VEHICLECUSTNO1
            // 
            this.VEHICLECUSTNO1.BackColor = System.Drawing.Color.Transparent;
            this.VEHICLECUSTNO1.BorderColor = System.Drawing.Color.Black;
            this.VEHICLECUSTNO1.Borders = DevExpress.XtraPrinting.BorderSide.None;
            this.VEHICLECUSTNO1.BorderWidth = 1F;
            this.VEHICLECUSTNO1.CanGrow = false;
            this.VEHICLECUSTNO1.ExpressionBindings.AddRange(new DevExpress.XtraReports.UI.ExpressionBinding[] {
            new DevExpress.XtraReports.UI.ExpressionBinding("BeforePrint", "Text", "[VEHICLE_CUST_NO]")});
            this.VEHICLECUSTNO1.Font = new DevExpress.Drawing.DXFont("Arial", 8F);
            this.VEHICLECUSTNO1.ForeColor = System.Drawing.Color.Black;
            this.VEHICLECUSTNO1.LocationFloat = new DevExpress.Utils.PointFloat(0F, 0F);
            this.VEHICLECUSTNO1.Name = "VEHICLECUSTNO1";
            this.VEHICLECUSTNO1.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.VEHICLECUSTNO1.SizeF = new System.Drawing.SizeF(43.75F, 16.66667F);
            this.VEHICLECUSTNO1.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopLeft;
            // 
            // CustomerName_1
            // 
            this.CustomerName_1.BackColor = System.Drawing.Color.Transparent;
            this.CustomerName_1.BorderColor = System.Drawing.Color.Black;
            this.CustomerName_1.Borders = DevExpress.XtraPrinting.BorderSide.None;
            this.CustomerName_1.BorderWidth = 1F;
            this.CustomerName_1.CanGrow = false;
            this.CustomerName_1.ExpressionBindings.AddRange(new DevExpress.XtraReports.UI.ExpressionBinding[] {
            new DevExpress.XtraReports.UI.ExpressionBinding("BeforePrint", "Text", "trim([CUSTOMER_FIRST_NAME]) + \' \' + trim([CUSTOMER_LAST_NAME])")});
            this.CustomerName_1.Font = new DevExpress.Drawing.DXFont("Arial", 8F);
            this.CustomerName_1.ForeColor = System.Drawing.Color.Black;
            this.CustomerName_1.LocationFloat = new DevExpress.Utils.PointFloat(50F, 0F);
            this.CustomerName_1.Name = "CustomerName_1";
            this.CustomerName_1.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.CustomerName_1.SizeF = new System.Drawing.SizeF(187.5F, 16.66667F);
            this.CustomerName_1.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopLeft;
            // 
            // Dealer_1
            // 
            this.Dealer_1.BackColor = System.Drawing.Color.Transparent;
            this.Dealer_1.BorderColor = System.Drawing.Color.Black;
            this.Dealer_1.Borders = DevExpress.XtraPrinting.BorderSide.None;
            this.Dealer_1.BorderWidth = 1F;
            this.Dealer_1.CanGrow = false;
            this.Dealer_1.ExpressionBindings.AddRange(new DevExpress.XtraReports.UI.ExpressionBinding[] {
            new DevExpress.XtraReports.UI.ExpressionBinding("BeforePrint", "Text", "Trim([DEALER_ST])+\'-\'+trim([DEALER_ACC_NO]) + \' \' +trim([DEALER_NAME])")});
            this.Dealer_1.Font = new DevExpress.Drawing.DXFont("Arial", 8F);
            this.Dealer_1.ForeColor = System.Drawing.Color.Black;
            this.Dealer_1.LocationFloat = new DevExpress.Utils.PointFloat(241.6667F, 0F);
            this.Dealer_1.Name = "Dealer_1";
            this.Dealer_1.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.Dealer_1.SizeF = new System.Drawing.SizeF(207.2917F, 16.66667F);
            this.Dealer_1.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopLeft;
            // 
            // VEHICLEYEAR1
            // 
            this.VEHICLEYEAR1.BackColor = System.Drawing.Color.Transparent;
            this.VEHICLEYEAR1.BorderColor = System.Drawing.Color.Black;
            this.VEHICLEYEAR1.Borders = DevExpress.XtraPrinting.BorderSide.None;
            this.VEHICLEYEAR1.BorderWidth = 1F;
            this.VEHICLEYEAR1.CanGrow = false;
            this.VEHICLEYEAR1.ExpressionBindings.AddRange(new DevExpress.XtraReports.UI.ExpressionBinding[] {
            new DevExpress.XtraReports.UI.ExpressionBinding("BeforePrint", "Text", "[VEHICLE_YEAR]")});
            this.VEHICLEYEAR1.Font = new DevExpress.Drawing.DXFont("Arial", 8F);
            this.VEHICLEYEAR1.ForeColor = System.Drawing.Color.Black;
            this.VEHICLEYEAR1.LocationFloat = new DevExpress.Utils.PointFloat(458.3333F, 0F);
            this.VEHICLEYEAR1.Name = "VEHICLEYEAR1";
            this.VEHICLEYEAR1.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.VEHICLEYEAR1.SizeF = new System.Drawing.SizeF(37.5F, 16.66667F);
            this.VEHICLEYEAR1.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopLeft;
            // 
            // VEHICLEMAKE1
            // 
            this.VEHICLEMAKE1.BackColor = System.Drawing.Color.Transparent;
            this.VEHICLEMAKE1.BorderColor = System.Drawing.Color.Black;
            this.VEHICLEMAKE1.Borders = DevExpress.XtraPrinting.BorderSide.None;
            this.VEHICLEMAKE1.BorderWidth = 1F;
            this.VEHICLEMAKE1.CanGrow = false;
            this.VEHICLEMAKE1.ExpressionBindings.AddRange(new DevExpress.XtraReports.UI.ExpressionBinding[] {
            new DevExpress.XtraReports.UI.ExpressionBinding("BeforePrint", "Text", "[VEHICLE_MAKE]")});
            this.VEHICLEMAKE1.Font = new DevExpress.Drawing.DXFont("Arial", 8F);
            this.VEHICLEMAKE1.ForeColor = System.Drawing.Color.Black;
            this.VEHICLEMAKE1.LocationFloat = new DevExpress.Utils.PointFloat(504.1667F, 0F);
            this.VEHICLEMAKE1.Name = "VEHICLEMAKE1";
            this.VEHICLEMAKE1.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.VEHICLEMAKE1.SizeF = new System.Drawing.SizeF(125F, 16.66667F);
            this.VEHICLEMAKE1.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopLeft;
            // 
            // VEHICLEVIN1
            // 
            this.VEHICLEVIN1.BackColor = System.Drawing.Color.Transparent;
            this.VEHICLEVIN1.BorderColor = System.Drawing.Color.Black;
            this.VEHICLEVIN1.Borders = DevExpress.XtraPrinting.BorderSide.None;
            this.VEHICLEVIN1.BorderWidth = 1F;
            this.VEHICLEVIN1.CanGrow = false;
            this.VEHICLEVIN1.ExpressionBindings.AddRange(new DevExpress.XtraReports.UI.ExpressionBinding[] {
            new DevExpress.XtraReports.UI.ExpressionBinding("BeforePrint", "Text", "[VEHICLE_VIN]")});
            this.VEHICLEVIN1.Font = new DevExpress.Drawing.DXFont("Arial", 8F);
            this.VEHICLEVIN1.ForeColor = System.Drawing.Color.Black;
            this.VEHICLEVIN1.LocationFloat = new DevExpress.Utils.PointFloat(766.6667F, 0F);
            this.VEHICLEVIN1.Name = "VEHICLEVIN1";
            this.VEHICLEVIN1.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.VEHICLEVIN1.SizeF = new System.Drawing.SizeF(200F, 16.66667F);
            this.VEHICLEVIN1.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopLeft;
            // 
            // VEHICLEMODEL1
            // 
            this.VEHICLEMODEL1.BackColor = System.Drawing.Color.Transparent;
            this.VEHICLEMODEL1.BorderColor = System.Drawing.Color.Black;
            this.VEHICLEMODEL1.Borders = DevExpress.XtraPrinting.BorderSide.None;
            this.VEHICLEMODEL1.BorderWidth = 1F;
            this.VEHICLEMODEL1.CanGrow = false;
            this.VEHICLEMODEL1.ExpressionBindings.AddRange(new DevExpress.XtraReports.UI.ExpressionBinding[] {
            new DevExpress.XtraReports.UI.ExpressionBinding("BeforePrint", "Text", "[VEHICLE_MODEL]")});
            this.VEHICLEMODEL1.Font = new DevExpress.Drawing.DXFont("Arial", 8F);
            this.VEHICLEMODEL1.ForeColor = System.Drawing.Color.Black;
            this.VEHICLEMODEL1.LocationFloat = new DevExpress.Utils.PointFloat(643.75F, 0F);
            this.VEHICLEMODEL1.Name = "VEHICLEMODEL1";
            this.VEHICLEMODEL1.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.VEHICLEMODEL1.SizeF = new System.Drawing.SizeF(114.5833F, 16.66667F);
            this.VEHICLEMODEL1.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopLeft;
            // 
            // ControlDate1
            // 
            this.ControlDate1.AutoWidth = true;
            this.ControlDate1.BackColor = System.Drawing.Color.Transparent;
            this.ControlDate1.BorderColor = System.Drawing.Color.Black;
            this.ControlDate1.Borders = DevExpress.XtraPrinting.BorderSide.None;
            this.ControlDate1.BorderWidth = 1F;
            this.ControlDate1.CanGrow = false;
            this.ControlDate1.ExpressionBindings.AddRange(new DevExpress.XtraReports.UI.ExpressionBinding[] {
            new DevExpress.XtraReports.UI.ExpressionBinding("BeforePrint", "Text", "[ControlDate]")});
            this.ControlDate1.Font = new DevExpress.Drawing.DXFont("Arial", 8F);
            this.ControlDate1.ForeColor = System.Drawing.Color.Black;
            this.ControlDate1.LocationFloat = new DevExpress.Utils.PointFloat(975F, 0F);
            this.ControlDate1.Name = "ControlDate1";
            this.ControlDate1.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.ControlDate1.SizeF = new System.Drawing.SizeF(68.75F, 18.33333F);
            this.ControlDate1.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopLeft;
            this.ControlDate1.TextFormatString = "{0:MM/dd/yyyy}";
            // 
            // Area1
            // 
            this.Area1.HeightF = 0F;
            this.Area1.KeepTogether = true;
            this.Area1.Name = "Area1";
            this.Area1.Padding = new DevExpress.XtraPrinting.PaddingInfo(0, 0, 0, 0, 100F);
            this.Area1.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopLeft;
            // 
            // Area2
            // 
            this.Area2.Controls.AddRange(new DevExpress.XtraReports.UI.XRControl[] {
            this.xrPictureBox1,
            this.Text18,
            this.Line1,
            this.Text1,
            this.Text2,
            this.Text3,
            this.Text4,
            this.gdStartDate1,
            this.gdEndDate1,
            this.Text5,
            this.Text6,
            this.Text7,
            this.gsStatus1});
            this.Area2.HeightF = 202.6367F;
            this.Area2.Name = "Area2";
            this.Area2.Padding = new DevExpress.XtraPrinting.PaddingInfo(0, 0, 0, 0, 100F);
            this.Area2.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopLeft;
            // 
            // xrPictureBox1
            // 
            this.xrPictureBox1.ImageAlignment = DevExpress.XtraPrinting.ImageAlignment.MiddleCenter;
            this.xrPictureBox1.ImageSource = new DevExpress.XtraPrinting.Drawing.ImageSource("img", resources.GetString("xrPictureBox1.ImageSource"));
            this.xrPictureBox1.LocationFloat = new DevExpress.Utils.PointFloat(850F, 0F);
            this.xrPictureBox1.Name = "xrPictureBox1";
            this.xrPictureBox1.SizeF = new System.Drawing.SizeF(200F, 100F);
            this.xrPictureBox1.Sizing = DevExpress.XtraPrinting.ImageSizeMode.Squeeze;
            // 
            // Text18
            // 
            this.Text18.BackColor = System.Drawing.Color.Transparent;
            this.Text18.BorderColor = System.Drawing.Color.Black;
            this.Text18.Borders = DevExpress.XtraPrinting.BorderSide.None;
            this.Text18.BorderWidth = 1F;
            this.Text18.CanGrow = false;
            this.Text18.Font = new DevExpress.Drawing.DXFont("Arial", 14F, ((DevExpress.Drawing.DXFontStyle)((DevExpress.Drawing.DXFontStyle.Bold | DevExpress.Drawing.DXFontStyle.Underline))));
            this.Text18.ForeColor = System.Drawing.Color.Black;
            this.Text18.LocationFloat = new DevExpress.Utils.PointFloat(0F, 100F);
            this.Text18.Name = "Text18";
            this.Text18.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.Text18.SizeF = new System.Drawing.SizeF(1050F, 25F);
            this.Text18.Text = "Vehicle Missing Title Report";
            this.Text18.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopCenter;
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
            this.Line1.LocationFloat = new DevExpress.Utils.PointFloat(0F, 198.9583F);
            this.Line1.Name = "Line1";
            this.Line1.Padding = new DevExpress.XtraPrinting.PaddingInfo(0, 0, 0, 0, 100F);
            this.Line1.SizeF = new System.Drawing.SizeF(1050F, 3.125F);
            // 
            // Text1
            // 
            this.Text1.BackColor = System.Drawing.Color.Transparent;
            this.Text1.BorderColor = System.Drawing.Color.Black;
            this.Text1.Borders = DevExpress.XtraPrinting.BorderSide.None;
            this.Text1.BorderWidth = 1F;
            this.Text1.Font = new DevExpress.Drawing.DXFont("Arial", 8F, DevExpress.Drawing.DXFontStyle.Bold);
            this.Text1.ForeColor = System.Drawing.Color.Black;
            this.Text1.LocationFloat = new DevExpress.Utils.PointFloat(0F, 175F);
            this.Text1.Name = "Text1";
            this.Text1.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.Text1.SizeF = new System.Drawing.SizeF(41.66667F, 16.66667F);
            this.Text1.Text = "Acct#\n";
            this.Text1.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopLeft;
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
            this.Text2.LocationFloat = new DevExpress.Utils.PointFloat(50F, 175F);
            this.Text2.Name = "Text2";
            this.Text2.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.Text2.SizeF = new System.Drawing.SizeF(187.5F, 16.66667F);
            this.Text2.Text = "Customer";
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
            this.Text3.LocationFloat = new DevExpress.Utils.PointFloat(241.6667F, 175F);
            this.Text3.Name = "Text3";
            this.Text3.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.Text3.SizeF = new System.Drawing.SizeF(163.5417F, 16.66667F);
            this.Text3.Text = "Dealer";
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
            this.Text4.LocationFloat = new DevExpress.Utils.PointFloat(458.3333F, 175F);
            this.Text4.Name = "Text4";
            this.Text4.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.Text4.SizeF = new System.Drawing.SizeF(581.6666F, 14.86003F);
            this.Text4.Text = "Year       Make\t                Model                           VIN\t             " +
    "                                          CTRL Date";
            this.Text4.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopLeft;
            // 
            // gdStartDate1
            // 
            this.gdStartDate1.BackColor = System.Drawing.Color.Transparent;
            this.gdStartDate1.BorderColor = System.Drawing.Color.Black;
            this.gdStartDate1.Borders = DevExpress.XtraPrinting.BorderSide.None;
            this.gdStartDate1.BorderWidth = 1F;
            this.gdStartDate1.CanGrow = false;
            this.gdStartDate1.ExpressionBindings.AddRange(new DevExpress.XtraReports.UI.ExpressionBinding[] {
            new DevExpress.XtraReports.UI.ExpressionBinding("BeforePrint", "Text", "?gdStartDate")});
            this.gdStartDate1.Font = new DevExpress.Drawing.DXFont("Arial", 8F);
            this.gdStartDate1.ForeColor = System.Drawing.Color.Black;
            this.gdStartDate1.LocationFloat = new DevExpress.Utils.PointFloat(400F, 133.3333F);
            this.gdStartDate1.Name = "gdStartDate1";
            this.gdStartDate1.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.gdStartDate1.SizeF = new System.Drawing.SizeF(68.75F, 16.66667F);
            this.gdStartDate1.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopCenter;
            this.gdStartDate1.TextFormatString = "{0:MM/dd/yyyy}";
            // 
            // gdEndDate1
            // 
            this.gdEndDate1.BackColor = System.Drawing.Color.Transparent;
            this.gdEndDate1.BorderColor = System.Drawing.Color.Black;
            this.gdEndDate1.Borders = DevExpress.XtraPrinting.BorderSide.None;
            this.gdEndDate1.BorderWidth = 1F;
            this.gdEndDate1.CanGrow = false;
            this.gdEndDate1.ExpressionBindings.AddRange(new DevExpress.XtraReports.UI.ExpressionBinding[] {
            new DevExpress.XtraReports.UI.ExpressionBinding("BeforePrint", "Text", "?gdEndDate")});
            this.gdEndDate1.Font = new DevExpress.Drawing.DXFont("Arial", 8F);
            this.gdEndDate1.ForeColor = System.Drawing.Color.Black;
            this.gdEndDate1.LocationFloat = new DevExpress.Utils.PointFloat(516.6667F, 133.3333F);
            this.gdEndDate1.Name = "gdEndDate1";
            this.gdEndDate1.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.gdEndDate1.SizeF = new System.Drawing.SizeF(68.75F, 16.66667F);
            this.gdEndDate1.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopCenter;
            this.gdEndDate1.TextFormatString = "{0:MM/dd/yyyy}";
            // 
            // Text5
            // 
            this.Text5.BackColor = System.Drawing.Color.Transparent;
            this.Text5.BorderColor = System.Drawing.Color.Black;
            this.Text5.Borders = DevExpress.XtraPrinting.BorderSide.None;
            this.Text5.BorderWidth = 1F;
            this.Text5.CanGrow = false;
            this.Text5.Font = new DevExpress.Drawing.DXFont("Arial", 8F, DevExpress.Drawing.DXFontStyle.Bold);
            this.Text5.ForeColor = System.Drawing.Color.Black;
            this.Text5.LocationFloat = new DevExpress.Utils.PointFloat(350F, 133.3333F);
            this.Text5.Name = "Text5";
            this.Text5.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.Text5.SizeF = new System.Drawing.SizeF(41.66667F, 16.66667F);
            this.Text5.Text = "From:";
            this.Text5.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopCenter;
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
            this.Text6.LocationFloat = new DevExpress.Utils.PointFloat(483.3333F, 133.3333F);
            this.Text6.Name = "Text6";
            this.Text6.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.Text6.SizeF = new System.Drawing.SizeF(25F, 16.66667F);
            this.Text6.Text = "To:";
            this.Text6.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopCenter;
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
            this.Text7.LocationFloat = new DevExpress.Utils.PointFloat(608.3333F, 133.3333F);
            this.Text7.Name = "Text7";
            this.Text7.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.Text7.SizeF = new System.Drawing.SizeF(41.66667F, 16.66667F);
            this.Text7.Text = "Status:";
            this.Text7.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopCenter;
            // 
            // gsStatus1
            // 
            this.gsStatus1.BackColor = System.Drawing.Color.Transparent;
            this.gsStatus1.BorderColor = System.Drawing.Color.Black;
            this.gsStatus1.Borders = DevExpress.XtraPrinting.BorderSide.None;
            this.gsStatus1.BorderWidth = 1F;
            this.gsStatus1.CanGrow = false;
            this.gsStatus1.ExpressionBindings.AddRange(new DevExpress.XtraReports.UI.ExpressionBinding[] {
            new DevExpress.XtraReports.UI.ExpressionBinding("BeforePrint", "Text", "?gsStatus")});
            this.gsStatus1.Font = new DevExpress.Drawing.DXFont("Arial", 8F);
            this.gsStatus1.ForeColor = System.Drawing.Color.Black;
            this.gsStatus1.LocationFloat = new DevExpress.Utils.PointFloat(658.3333F, 133.3333F);
            this.gsStatus1.Name = "gsStatus1";
            this.gsStatus1.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.gsStatus1.SizeF = new System.Drawing.SizeF(66.66666F, 16.66667F);
            this.gsStatus1.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopCenter;
            // 
            // Area4
            // 
            this.Area4.HeightF = 0.4882813F;
            this.Area4.KeepTogether = true;
            this.Area4.Name = "Area4";
            this.Area4.Padding = new DevExpress.XtraPrinting.PaddingInfo(0, 0, 0, 0, 100F);
            this.Area4.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopLeft;
            // 
            // Area5
            // 
            this.Area5.Controls.AddRange(new DevExpress.XtraReports.UI.XRControl[] {
            this.PageNofM1,
            this.gsUserName_1,
            this.gsUserID_1,
            this.Text17,
            this.DataTime1,
            this.DataDate1});
            this.Area5.HeightF = 46F;
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
            this.PageNofM1.Font = new DevExpress.Drawing.DXFont("Arial", 8F);
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
            this.gsUserName_1.Font = new DevExpress.Drawing.DXFont("Arial", 8F);
            this.gsUserName_1.ForeColor = System.Drawing.Color.Black;
            this.gsUserName_1.LocationFloat = new DevExpress.Utils.PointFloat(291.6667F, 0F);
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
            this.gsUserID_1.Font = new DevExpress.Drawing.DXFont("Arial", 8F);
            this.gsUserID_1.ForeColor = System.Drawing.Color.Black;
            this.gsUserID_1.LocationFloat = new DevExpress.Utils.PointFloat(250F, 0F);
            this.gsUserID_1.Name = "gsUserID_1";
            this.gsUserID_1.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.gsUserID_1.SizeF = new System.Drawing.SizeF(33.33333F, 18.33333F);
            this.gsUserID_1.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopLeft;
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
            this.Text17.LocationFloat = new DevExpress.Utils.PointFloat(200F, 0F);
            this.Text17.Name = "Text17";
            this.Text17.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.Text17.SizeF = new System.Drawing.SizeF(50F, 18.33333F);
            this.Text17.Text = "USER:";
            this.Text17.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopLeft;
            // 
            // DataTime1
            // 
            this.DataTime1.BackColor = System.Drawing.Color.Transparent;
            this.DataTime1.BorderColor = System.Drawing.Color.Black;
            this.DataTime1.Borders = DevExpress.XtraPrinting.BorderSide.None;
            this.DataTime1.BorderWidth = 1F;
            this.DataTime1.Font = new DevExpress.Drawing.DXFont("Arial", 8F);
            this.DataTime1.ForeColor = System.Drawing.Color.Black;
            this.DataTime1.LocationFloat = new DevExpress.Utils.PointFloat(91.66666F, 0F);
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
            this.DataDate1.Font = new DevExpress.Drawing.DXFont("Arial", 8F);
            this.DataDate1.ForeColor = System.Drawing.Color.Black;
            this.DataDate1.LocationFloat = new DevExpress.Utils.PointFloat(0F, 0F);
            this.DataDate1.Name = "DataDate1";
            this.DataDate1.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.DataDate1.PageInfo = DevExpress.XtraPrinting.PageInfo.DateTime;
            this.DataDate1.SizeF = new System.Drawing.SizeF(68.75F, 18.33333F);
            this.DataDate1.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopLeft;
            // 
            // CustomerName
            // 
            this.CustomerName.Expression = "Iif(True, \'#NOT_SUPPORTED#\', \'trimright([VehicleMissingTitle.CUSTOMER_FIRST_NAME]" +
    ")\') + \' \' + Iif(True, \'#NOT_SUPPORTED#\', \'trimright([VehicleMissingTitle.CUSTOME" +
    "R_LAST_NAME])\')";
            this.CustomerName.FieldType = DevExpress.XtraReports.UI.FieldType.String;
            this.CustomerName.Name = "CustomerName";
            // 
            // Dealer
            // 
            this.Dealer.Expression = "Trim([VehicleMissingTitle.DEALER_ACC_NO]) + \' \' + Trim([VehicleMissingTitle.DEALE" +
    "R_NAME])";
            this.Dealer.FieldType = DevExpress.XtraReports.UI.FieldType.String;
            this.Dealer.Name = "Dealer";
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
            // gdStartDate
            // 
            this.gdStartDate.Description = "Enter gdStartDate:";
            this.gdStartDate.Name = "gdStartDate";
            this.gdStartDate.Type = typeof(System.DateTime);
            // 
            // gdEndDate
            // 
            this.gdEndDate.Description = "Enter gdEndDate:";
            this.gdEndDate.Name = "gdEndDate";
            this.gdEndDate.Type = typeof(System.DateTime);
            // 
            // gsStatus
            // 
            this.gsStatus.Description = "Enter gsStatus:";
            this.gsStatus.Name = "gsStatus";
            // 
            // aLTNAMETableAdapter
            // 
            this.aLTNAMETableAdapter.ClearBeforeFill = true;
            // 
            // vehicleMissingTitleTableAdapter1
            // 
            this.vehicleMissingTitleTableAdapter1.ClearBeforeFill = true;
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
            // iacDataSet1
            // 
            this.iacDataSet1.DataSetName = "IACDataSet";
            this.iacDataSet1.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // XtraReportVehicleMissingTitle
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
            this.CustomerName,
            this.Dealer});
            this.ComponentStorage.AddRange(new System.ComponentModel.IComponent[] {
            this.iacDataSet1});
            this.DataMember = "VehicleMissingTitle";
            this.DataSource = this.iacDataSet1;
            this.DataSourceSchema = resources.GetString("$this.DataSourceSchema");
            this.Landscape = true;
            this.Margins = new DevExpress.Drawing.DXMargins(25, 25, 25, 25);
            this.PageHeight = 850;
            this.PageWidth = 1100;
            this.Parameters.AddRange(new DevExpress.XtraReports.Parameters.Parameter[] {
            this.gsUserName,
            this.gsUserID,
            this.gdStartDate,
            this.gdEndDate,
            this.gsStatus});
            this.Version = "21.2";
            ((System.ComponentModel.ISupportInitialize)(this.iacDataSet1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this)).EndInit();

        }

        #endregion

        private DevExpress.XtraReports.UI.DetailBand Area3;
        private DevExpress.XtraReports.UI.XRLabel VEHICLECUSTNO1;
        private DevExpress.XtraReports.UI.XRLabel CustomerName_1;
        private DevExpress.XtraReports.UI.XRLabel Dealer_1;
        private DevExpress.XtraReports.UI.XRLabel VEHICLEYEAR1;
        private DevExpress.XtraReports.UI.XRLabel VEHICLEMAKE1;
        private DevExpress.XtraReports.UI.XRLabel VEHICLEVIN1;
        private DevExpress.XtraReports.UI.XRLabel VEHICLEMODEL1;
        private DevExpress.XtraReports.UI.XRLabel ControlDate1;
        private DevExpress.XtraReports.UI.ReportHeaderBand Area1;
        private DevExpress.XtraReports.UI.PageHeaderBand Area2;
        private DevExpress.XtraReports.UI.XRLabel Text18;
        private DevExpress.XtraReports.UI.XRLine Line1;
        private DevExpress.XtraReports.UI.XRLabel Text1;
        private DevExpress.XtraReports.UI.XRLabel Text2;
        private DevExpress.XtraReports.UI.XRLabel Text3;
        private DevExpress.XtraReports.UI.XRLabel Text4;
        private DevExpress.XtraReports.UI.XRLabel gdStartDate1;
        private DevExpress.XtraReports.UI.XRLabel gdEndDate1;
        private DevExpress.XtraReports.UI.XRLabel Text5;
        private DevExpress.XtraReports.UI.XRLabel Text6;
        private DevExpress.XtraReports.UI.XRLabel Text7;
        private DevExpress.XtraReports.UI.XRLabel gsStatus1;
        private DevExpress.XtraReports.UI.ReportFooterBand Area4;
        private DevExpress.XtraReports.UI.PageFooterBand Area5;
        private DevExpress.XtraReports.UI.XRPageInfo PageNofM1;
        private DevExpress.XtraReports.UI.XRLabel gsUserName_1;
        private DevExpress.XtraReports.UI.XRLabel gsUserID_1;
        private DevExpress.XtraReports.UI.XRLabel Text17;
        private DevExpress.XtraReports.UI.XRPageInfo DataTime1;
        private DevExpress.XtraReports.UI.XRPageInfo DataDate1;
        private DevExpress.XtraReports.UI.CalculatedField CustomerName;
        private DevExpress.XtraReports.UI.CalculatedField Dealer;
        private DevExpress.XtraReports.Parameters.Parameter gsUserName;
        private DevExpress.XtraReports.Parameters.Parameter gsUserID;
        private DevExpress.XtraReports.Parameters.Parameter gdStartDate;
        private DevExpress.XtraReports.Parameters.Parameter gdEndDate;
        private DevExpress.XtraReports.Parameters.Parameter gsStatus;
        private IACDataSetTableAdapters.ALTNAMETableAdapter aLTNAMETableAdapter;
        private IACDataSetTableAdapters.VehicleMissingTitleTableAdapter vehicleMissingTitleTableAdapter1;
        private DevExpress.XtraReports.UI.XRPictureBox xrPictureBox1;
        private DevExpress.XtraReports.UI.TopMarginBand topMarginBand1;
        private DevExpress.XtraReports.UI.BottomMarginBand bottomMarginBand1;
        private IACDataSet iacDataSet1;
    }
}

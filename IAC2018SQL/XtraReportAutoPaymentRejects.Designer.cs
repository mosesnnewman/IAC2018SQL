namespace IAC2021SQL
{
    partial class XtraReportAutoPaymentRejects
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(XtraReportAutoPaymentRejects));
            DevExpress.XtraReports.UI.XRSummary xrSummary2 = new DevExpress.XtraReports.UI.XRSummary();
            DevExpress.DataAccess.Sql.StoredProcQuery storedProcQuery1 = new DevExpress.DataAccess.Sql.StoredProcQuery();
            this.Area3 = new DevExpress.XtraReports.UI.DetailBand();
            this.IACType1 = new DevExpress.XtraReports.UI.XRLabel();
            this.CustomerNo1 = new DevExpress.XtraReports.UI.XRLabel();
            this.Status1 = new DevExpress.XtraReports.UI.XRLabel();
            this.Amount1 = new DevExpress.XtraReports.UI.XRLabel();
            this.PaymentType1 = new DevExpress.XtraReports.UI.XRLabel();
            this.PaymentCode1 = new DevExpress.XtraReports.UI.XRLabel();
            this.Reason1 = new DevExpress.XtraReports.UI.XRLabel();
            this.Name_2 = new DevExpress.XtraReports.UI.XRLabel();
            this.Source1 = new DevExpress.XtraReports.UI.XRLabel();
            this.GroupHeaderArea1 = new DevExpress.XtraReports.UI.GroupHeaderBand();
            this.ClosedOpen_1 = new DevExpress.XtraReports.UI.XRLabel();
            this.GroupFooterArea1 = new DevExpress.XtraReports.UI.GroupFooterBand();
            this.SumofAmount1 = new DevExpress.XtraReports.UI.XRLabel();
            this.ClosedOpen_2 = new DevExpress.XtraReports.UI.XRLabel();
            this.Area1 = new DevExpress.XtraReports.UI.ReportHeaderBand();
            this.Area2 = new DevExpress.XtraReports.UI.PageHeaderBand();
            this.Picture1 = new DevExpress.XtraReports.UI.XRPictureBox();
            this.Text2 = new DevExpress.XtraReports.UI.XRLabel();
            this.Text3 = new DevExpress.XtraReports.UI.XRLabel();
            this.Text4 = new DevExpress.XtraReports.UI.XRLabel();
            this.Text7 = new DevExpress.XtraReports.UI.XRLabel();
            this.Text8 = new DevExpress.XtraReports.UI.XRLabel();
            this.Text9 = new DevExpress.XtraReports.UI.XRLabel();
            this.Text11 = new DevExpress.XtraReports.UI.XRLabel();
            this.Text12 = new DevExpress.XtraReports.UI.XRLabel();
            this.Text10 = new DevExpress.XtraReports.UI.XRLabel();
            this.gsTitle1 = new DevExpress.XtraReports.UI.XRLabel();
            this.Area4 = new DevExpress.XtraReports.UI.ReportFooterBand();
            this.SumofAmount2 = new DevExpress.XtraReports.UI.XRLabel();
            this.Text1 = new DevExpress.XtraReports.UI.XRLabel();
            this.Area5 = new DevExpress.XtraReports.UI.PageFooterBand();
            this.PageNofM1 = new DevExpress.XtraReports.UI.XRPageInfo();
            this.gsUserName_1 = new DevExpress.XtraReports.UI.XRLabel();
            this.gsUserID_1 = new DevExpress.XtraReports.UI.XRLabel();
            this.Text5 = new DevExpress.XtraReports.UI.XRLabel();
            this.DataTime1 = new DevExpress.XtraReports.UI.XRPageInfo();
            this.DataDate1 = new DevExpress.XtraReports.UI.XRPageInfo();
            this.Name_1 = new DevExpress.XtraReports.UI.CalculatedField();
            this.ClosedOpen = new DevExpress.XtraReports.UI.CalculatedField();
            this.gsUserName = new DevExpress.XtraReports.Parameters.Parameter();
            this.gsUserID = new DevExpress.XtraReports.Parameters.Parameter();
            this.gsTitle = new DevExpress.XtraReports.Parameters.Parameter();
            this.sqlDataSource1 = new DevExpress.DataAccess.Sql.SqlDataSource(this.components);
            this.topMarginBand1 = new DevExpress.XtraReports.UI.TopMarginBand();
            this.bottomMarginBand1 = new DevExpress.XtraReports.UI.BottomMarginBand();
            ((System.ComponentModel.ISupportInitialize)(this)).BeginInit();
            // 
            // Area3
            // 
            this.Area3.Controls.AddRange(new DevExpress.XtraReports.UI.XRControl[] {
            this.IACType1,
            this.CustomerNo1,
            this.Status1,
            this.Amount1,
            this.PaymentType1,
            this.PaymentCode1,
            this.Reason1,
            this.Name_2,
            this.Source1});
            this.Area3.HeightF = 15F;
            this.Area3.KeepTogether = true;
            this.Area3.Name = "Area3";
            this.Area3.Padding = new DevExpress.XtraPrinting.PaddingInfo(0, 0, 0, 0, 100F);
            this.Area3.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopLeft;
            // 
            // IACType1
            // 
            this.IACType1.BackColor = System.Drawing.Color.Transparent;
            this.IACType1.BorderColor = System.Drawing.Color.Black;
            this.IACType1.Borders = DevExpress.XtraPrinting.BorderSide.None;
            this.IACType1.BorderWidth = 1F;
            this.IACType1.CanGrow = false;
            this.IACType1.ExpressionBindings.AddRange(new DevExpress.XtraReports.UI.ExpressionBinding[] {
            new DevExpress.XtraReports.UI.ExpressionBinding("BeforePrint", "Text", "[IACType]")});
            this.IACType1.Font = new DevExpress.Drawing.DXFont("Arial", 8F);
            this.IACType1.ForeColor = System.Drawing.Color.Black;
            this.IACType1.LocationFloat = new DevExpress.Utils.PointFloat(4.166667F, 0F);
            this.IACType1.Name = "IACType1";
            this.IACType1.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.IACType1.SizeF = new System.Drawing.SizeF(38.88889F, 15.34722F);
            this.IACType1.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopLeft;
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
            this.CustomerNo1.Font = new DevExpress.Drawing.DXFont("Arial", 8F);
            this.CustomerNo1.ForeColor = System.Drawing.Color.Black;
            this.CustomerNo1.LocationFloat = new DevExpress.Utils.PointFloat(51.38889F, 0F);
            this.CustomerNo1.Name = "CustomerNo1";
            this.CustomerNo1.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.CustomerNo1.SizeF = new System.Drawing.SizeF(56.73611F, 15.34722F);
            this.CustomerNo1.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopLeft;
            // 
            // Status1
            // 
            this.Status1.BackColor = System.Drawing.Color.Transparent;
            this.Status1.BorderColor = System.Drawing.Color.Black;
            this.Status1.Borders = DevExpress.XtraPrinting.BorderSide.None;
            this.Status1.BorderWidth = 1F;
            this.Status1.CanGrow = false;
            this.Status1.ExpressionBindings.AddRange(new DevExpress.XtraReports.UI.ExpressionBinding[] {
            new DevExpress.XtraReports.UI.ExpressionBinding("BeforePrint", "Text", "[Status]")});
            this.Status1.Font = new DevExpress.Drawing.DXFont("Arial", 8F);
            this.Status1.ForeColor = System.Drawing.Color.Black;
            this.Status1.LocationFloat = new DevExpress.Utils.PointFloat(125F, 0F);
            this.Status1.Name = "Status1";
            this.Status1.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.Status1.SizeF = new System.Drawing.SizeF(14.79167F, 15.34722F);
            this.Status1.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopLeft;
            // 
            // Amount1
            // 
            this.Amount1.BackColor = System.Drawing.Color.Transparent;
            this.Amount1.BorderColor = System.Drawing.Color.Black;
            this.Amount1.Borders = DevExpress.XtraPrinting.BorderSide.None;
            this.Amount1.BorderWidth = 1F;
            this.Amount1.CanGrow = false;
            this.Amount1.ExpressionBindings.AddRange(new DevExpress.XtraReports.UI.ExpressionBinding[] {
            new DevExpress.XtraReports.UI.ExpressionBinding("BeforePrint", "Text", "[Amount]")});
            this.Amount1.Font = new DevExpress.Drawing.DXFont("Arial", 8F);
            this.Amount1.ForeColor = System.Drawing.Color.Black;
            this.Amount1.LocationFloat = new DevExpress.Utils.PointFloat(427.9861F, 0F);
            this.Amount1.Name = "Amount1";
            this.Amount1.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.Amount1.SizeF = new System.Drawing.SizeF(67.15278F, 12.84722F);
            this.Amount1.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopLeft;
            this.Amount1.TextFormatString = "{0:C2}";
            // 
            // PaymentType1
            // 
            this.PaymentType1.BackColor = System.Drawing.Color.Transparent;
            this.PaymentType1.BorderColor = System.Drawing.Color.Black;
            this.PaymentType1.Borders = DevExpress.XtraPrinting.BorderSide.None;
            this.PaymentType1.BorderWidth = 1F;
            this.PaymentType1.CanGrow = false;
            this.PaymentType1.ExpressionBindings.AddRange(new DevExpress.XtraReports.UI.ExpressionBinding[] {
            new DevExpress.XtraReports.UI.ExpressionBinding("BeforePrint", "Text", "[PaymentType]")});
            this.PaymentType1.Font = new DevExpress.Drawing.DXFont("Arial", 8F);
            this.PaymentType1.ForeColor = System.Drawing.Color.Black;
            this.PaymentType1.LocationFloat = new DevExpress.Utils.PointFloat(527.0833F, 0F);
            this.PaymentType1.Name = "PaymentType1";
            this.PaymentType1.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.PaymentType1.SizeF = new System.Drawing.SizeF(13.54167F, 15.34722F);
            this.PaymentType1.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopLeft;
            // 
            // PaymentCode1
            // 
            this.PaymentCode1.BackColor = System.Drawing.Color.Transparent;
            this.PaymentCode1.BorderColor = System.Drawing.Color.Black;
            this.PaymentCode1.Borders = DevExpress.XtraPrinting.BorderSide.None;
            this.PaymentCode1.BorderWidth = 1F;
            this.PaymentCode1.CanGrow = false;
            this.PaymentCode1.ExpressionBindings.AddRange(new DevExpress.XtraReports.UI.ExpressionBinding[] {
            new DevExpress.XtraReports.UI.ExpressionBinding("BeforePrint", "Text", "[PaymentCode]")});
            this.PaymentCode1.Font = new DevExpress.Drawing.DXFont("Arial", 8F);
            this.PaymentCode1.ForeColor = System.Drawing.Color.Black;
            this.PaymentCode1.LocationFloat = new DevExpress.Utils.PointFloat(569.7917F, 0F);
            this.PaymentCode1.Name = "PaymentCode1";
            this.PaymentCode1.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.PaymentCode1.SizeF = new System.Drawing.SizeF(13.54167F, 15.34722F);
            this.PaymentCode1.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopLeft;
            // 
            // Reason1
            // 
            this.Reason1.BackColor = System.Drawing.Color.Transparent;
            this.Reason1.BorderColor = System.Drawing.Color.Black;
            this.Reason1.Borders = DevExpress.XtraPrinting.BorderSide.None;
            this.Reason1.BorderWidth = 1F;
            this.Reason1.CanGrow = false;
            this.Reason1.ExpressionBindings.AddRange(new DevExpress.XtraReports.UI.ExpressionBinding[] {
            new DevExpress.XtraReports.UI.ExpressionBinding("BeforePrint", "Text", "[Reason]")});
            this.Reason1.Font = new DevExpress.Drawing.DXFont("Arial", 8F);
            this.Reason1.ForeColor = System.Drawing.Color.Black;
            this.Reason1.LocationFloat = new DevExpress.Utils.PointFloat(658.3333F, 0F);
            this.Reason1.Name = "Reason1";
            this.Reason1.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.Reason1.SizeF = new System.Drawing.SizeF(390.625F, 15.34722F);
            this.Reason1.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopLeft;
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
            this.Name_2.LocationFloat = new DevExpress.Utils.PointFloat(158.3333F, 0F);
            this.Name_2.Name = "Name_2";
            this.Name_2.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.Name_2.SizeF = new System.Drawing.SizeF(259.375F, 15.34722F);
            this.Name_2.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopLeft;
            // 
            // Source1
            // 
            this.Source1.BackColor = System.Drawing.Color.Transparent;
            this.Source1.BorderColor = System.Drawing.Color.Black;
            this.Source1.Borders = DevExpress.XtraPrinting.BorderSide.None;
            this.Source1.BorderWidth = 1F;
            this.Source1.CanGrow = false;
            this.Source1.ExpressionBindings.AddRange(new DevExpress.XtraReports.UI.ExpressionBinding[] {
            new DevExpress.XtraReports.UI.ExpressionBinding("BeforePrint", "Text", "[Source]")});
            this.Source1.Font = new DevExpress.Drawing.DXFont("Arial", 8F);
            this.Source1.ForeColor = System.Drawing.Color.Black;
            this.Source1.LocationFloat = new DevExpress.Utils.PointFloat(608.3333F, 0F);
            this.Source1.Name = "Source1";
            this.Source1.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.Source1.SizeF = new System.Drawing.SizeF(13.54167F, 15.34722F);
            this.Source1.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopLeft;
            // 
            // GroupHeaderArea1
            // 
            this.GroupHeaderArea1.Controls.AddRange(new DevExpress.XtraReports.UI.XRControl[] {
            this.ClosedOpen_1});
            this.GroupHeaderArea1.GroupFields.AddRange(new DevExpress.XtraReports.UI.GroupField[] {
            new DevExpress.XtraReports.UI.GroupField("IACType", DevExpress.XtraReports.UI.XRColumnSortOrder.Ascending)});
            this.GroupHeaderArea1.HeightF = 39.66666F;
            this.GroupHeaderArea1.KeepTogether = true;
            this.GroupHeaderArea1.Name = "GroupHeaderArea1";
            this.GroupHeaderArea1.Padding = new DevExpress.XtraPrinting.PaddingInfo(0, 0, 0, 0, 100F);
            this.GroupHeaderArea1.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopLeft;
            // 
            // ClosedOpen_1
            // 
            this.ClosedOpen_1.BackColor = System.Drawing.Color.Transparent;
            this.ClosedOpen_1.BorderColor = System.Drawing.Color.Black;
            this.ClosedOpen_1.Borders = DevExpress.XtraPrinting.BorderSide.None;
            this.ClosedOpen_1.BorderWidth = 1F;
            this.ClosedOpen_1.CanGrow = false;
            this.ClosedOpen_1.ExpressionBindings.AddRange(new DevExpress.XtraReports.UI.ExpressionBinding[] {
            new DevExpress.XtraReports.UI.ExpressionBinding("BeforePrint", "Text", "[ClosedOpen]")});
            this.ClosedOpen_1.Font = new DevExpress.Drawing.DXFont("Arial", 8F);
            this.ClosedOpen_1.ForeColor = System.Drawing.Color.Black;
            this.ClosedOpen_1.LocationFloat = new DevExpress.Utils.PointFloat(8.333333F, 16.66667F);
            this.ClosedOpen_1.Name = "ClosedOpen_1";
            this.ClosedOpen_1.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.ClosedOpen_1.SizeF = new System.Drawing.SizeF(138.5417F, 15.34722F);
            this.ClosedOpen_1.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopLeft;
            // 
            // GroupFooterArea1
            // 
            this.GroupFooterArea1.Controls.AddRange(new DevExpress.XtraReports.UI.XRControl[] {
            this.SumofAmount1,
            this.ClosedOpen_2});
            this.GroupFooterArea1.HeightF = 39.66666F;
            this.GroupFooterArea1.KeepTogether = true;
            this.GroupFooterArea1.Name = "GroupFooterArea1";
            this.GroupFooterArea1.Padding = new DevExpress.XtraPrinting.PaddingInfo(0, 0, 0, 0, 100F);
            this.GroupFooterArea1.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopLeft;
            // 
            // SumofAmount1
            // 
            this.SumofAmount1.BackColor = System.Drawing.Color.Transparent;
            this.SumofAmount1.BorderColor = System.Drawing.Color.Black;
            this.SumofAmount1.Borders = ((DevExpress.XtraPrinting.BorderSide)((DevExpress.XtraPrinting.BorderSide.Top | DevExpress.XtraPrinting.BorderSide.Bottom)));
            this.SumofAmount1.BorderWidth = 1F;
            this.SumofAmount1.CanGrow = false;
            this.SumofAmount1.ExpressionBindings.AddRange(new DevExpress.XtraReports.UI.ExpressionBinding[] {
            new DevExpress.XtraReports.UI.ExpressionBinding("BeforePrint", "Text", "sumSum([Amount])")});
            this.SumofAmount1.Font = new DevExpress.Drawing.DXFont("Arial", 8F, DevExpress.Drawing.DXFontStyle.Bold);
            this.SumofAmount1.ForeColor = System.Drawing.Color.Black;
            this.SumofAmount1.LocationFloat = new DevExpress.Utils.PointFloat(183.3333F, 16.66667F);
            this.SumofAmount1.Name = "SumofAmount1";
            this.SumofAmount1.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.SumofAmount1.SizeF = new System.Drawing.SizeF(66.80556F, 13.33333F);
            xrSummary1.Running = DevExpress.XtraReports.UI.SummaryRunning.Group;
            this.SumofAmount1.Summary = xrSummary1;
            this.SumofAmount1.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopLeft;
            this.SumofAmount1.TextFormatString = "{0:C2}";
            // 
            // ClosedOpen_2
            // 
            this.ClosedOpen_2.BackColor = System.Drawing.Color.Transparent;
            this.ClosedOpen_2.BorderColor = System.Drawing.Color.Black;
            this.ClosedOpen_2.Borders = DevExpress.XtraPrinting.BorderSide.None;
            this.ClosedOpen_2.BorderWidth = 1F;
            this.ClosedOpen_2.CanGrow = false;
            this.ClosedOpen_2.ExpressionBindings.AddRange(new DevExpress.XtraReports.UI.ExpressionBinding[] {
            new DevExpress.XtraReports.UI.ExpressionBinding("BeforePrint", "Text", "[ClosedOpen]")});
            this.ClosedOpen_2.Font = new DevExpress.Drawing.DXFont("Arial", 8F);
            this.ClosedOpen_2.ForeColor = System.Drawing.Color.Black;
            this.ClosedOpen_2.LocationFloat = new DevExpress.Utils.PointFloat(8.333333F, 11.875F);
            this.ClosedOpen_2.Name = "ClosedOpen_2";
            this.ClosedOpen_2.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.ClosedOpen_2.SizeF = new System.Drawing.SizeF(138.5417F, 15.34722F);
            this.ClosedOpen_2.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopLeft;
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
            this.Picture1,
            this.Text2,
            this.Text3,
            this.Text4,
            this.Text7,
            this.Text8,
            this.Text9,
            this.Text11,
            this.Text12,
            this.Text10,
            this.gsTitle1});
            this.Area2.HeightF = 153F;
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
            this.Text2.Font = new DevExpress.Drawing.DXFont("Arial", 8F, DevExpress.Drawing.DXFontStyle.Underline);
            this.Text2.ForeColor = System.Drawing.Color.Black;
            this.Text2.LocationFloat = new DevExpress.Utils.PointFloat(0F, 136.6667F);
            this.Text2.Name = "Text2";
            this.Text2.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.Text2.SizeF = new System.Drawing.SizeF(50F, 15.34722F);
            this.Text2.Text = "IACType";
            this.Text2.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopLeft;
            // 
            // Text3
            // 
            this.Text3.BackColor = System.Drawing.Color.Transparent;
            this.Text3.BorderColor = System.Drawing.Color.Black;
            this.Text3.Borders = DevExpress.XtraPrinting.BorderSide.None;
            this.Text3.BorderWidth = 1F;
            this.Text3.CanGrow = false;
            this.Text3.Font = new DevExpress.Drawing.DXFont("Arial", 8F, DevExpress.Drawing.DXFontStyle.Underline);
            this.Text3.ForeColor = System.Drawing.Color.Black;
            this.Text3.LocationFloat = new DevExpress.Utils.PointFloat(51.38889F, 136.6667F);
            this.Text3.Name = "Text3";
            this.Text3.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.Text3.SizeF = new System.Drawing.SizeF(56.73611F, 15.34722F);
            this.Text3.Text = "Customer#";
            this.Text3.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopLeft;
            // 
            // Text4
            // 
            this.Text4.BackColor = System.Drawing.Color.Transparent;
            this.Text4.BorderColor = System.Drawing.Color.Black;
            this.Text4.Borders = DevExpress.XtraPrinting.BorderSide.None;
            this.Text4.BorderWidth = 1F;
            this.Text4.CanGrow = false;
            this.Text4.Font = new DevExpress.Drawing.DXFont("Arial", 8F, DevExpress.Drawing.DXFontStyle.Underline);
            this.Text4.ForeColor = System.Drawing.Color.Black;
            this.Text4.LocationFloat = new DevExpress.Utils.PointFloat(116.6667F, 136.6667F);
            this.Text4.Name = "Text4";
            this.Text4.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.Text4.SizeF = new System.Drawing.SizeF(41.6666F, 15.34722F);
            this.Text4.Text = "Status";
            this.Text4.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopLeft;
            // 
            // Text7
            // 
            this.Text7.BackColor = System.Drawing.Color.Transparent;
            this.Text7.BorderColor = System.Drawing.Color.Black;
            this.Text7.Borders = DevExpress.XtraPrinting.BorderSide.None;
            this.Text7.BorderWidth = 1F;
            this.Text7.CanGrow = false;
            this.Text7.Font = new DevExpress.Drawing.DXFont("Arial", 8F, DevExpress.Drawing.DXFontStyle.Underline);
            this.Text7.ForeColor = System.Drawing.Color.Black;
            this.Text7.LocationFloat = new DevExpress.Utils.PointFloat(425F, 136.6667F);
            this.Text7.Name = "Text7";
            this.Text7.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.Text7.SizeF = new System.Drawing.SizeF(67.15278F, 15.34722F);
            this.Text7.Text = "Amount";
            this.Text7.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopRight;
            // 
            // Text8
            // 
            this.Text8.BackColor = System.Drawing.Color.Transparent;
            this.Text8.BorderColor = System.Drawing.Color.Black;
            this.Text8.Borders = DevExpress.XtraPrinting.BorderSide.None;
            this.Text8.BorderWidth = 1F;
            this.Text8.CanGrow = false;
            this.Text8.Font = new DevExpress.Drawing.DXFont("Arial", 8F, DevExpress.Drawing.DXFontStyle.Underline);
            this.Text8.ForeColor = System.Drawing.Color.Black;
            this.Text8.LocationFloat = new DevExpress.Utils.PointFloat(516.6667F, 136.6667F);
            this.Text8.Name = "Text8";
            this.Text8.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.Text8.SizeF = new System.Drawing.SizeF(33.33333F, 15.34722F);
            this.Text8.Text = "Type";
            this.Text8.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopLeft;
            // 
            // Text9
            // 
            this.Text9.BackColor = System.Drawing.Color.Transparent;
            this.Text9.BorderColor = System.Drawing.Color.Black;
            this.Text9.Borders = DevExpress.XtraPrinting.BorderSide.None;
            this.Text9.BorderWidth = 1F;
            this.Text9.CanGrow = false;
            this.Text9.Font = new DevExpress.Drawing.DXFont("Arial", 8F, DevExpress.Drawing.DXFontStyle.Underline);
            this.Text9.ForeColor = System.Drawing.Color.Black;
            this.Text9.LocationFloat = new DevExpress.Utils.PointFloat(558.3333F, 136.6667F);
            this.Text9.Name = "Text9";
            this.Text9.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.Text9.SizeF = new System.Drawing.SizeF(41.66663F, 15.34722F);
            this.Text9.Text = "Code";
            this.Text9.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopLeft;
            // 
            // Text11
            // 
            this.Text11.BackColor = System.Drawing.Color.Transparent;
            this.Text11.BorderColor = System.Drawing.Color.Black;
            this.Text11.Borders = DevExpress.XtraPrinting.BorderSide.None;
            this.Text11.BorderWidth = 1F;
            this.Text11.CanGrow = false;
            this.Text11.Font = new DevExpress.Drawing.DXFont("Arial", 8F, DevExpress.Drawing.DXFontStyle.Underline);
            this.Text11.ForeColor = System.Drawing.Color.Black;
            this.Text11.LocationFloat = new DevExpress.Utils.PointFloat(658.3333F, 136.6667F);
            this.Text11.Name = "Text11";
            this.Text11.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.Text11.SizeF = new System.Drawing.SizeF(44.79167F, 15.34722F);
            this.Text11.Text = "Reason";
            this.Text11.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopLeft;
            // 
            // Text12
            // 
            this.Text12.BackColor = System.Drawing.Color.Transparent;
            this.Text12.BorderColor = System.Drawing.Color.Black;
            this.Text12.Borders = DevExpress.XtraPrinting.BorderSide.None;
            this.Text12.BorderWidth = 1F;
            this.Text12.CanGrow = false;
            this.Text12.Font = new DevExpress.Drawing.DXFont("Arial", 8F, DevExpress.Drawing.DXFontStyle.Underline);
            this.Text12.ForeColor = System.Drawing.Color.Black;
            this.Text12.LocationFloat = new DevExpress.Utils.PointFloat(158.3333F, 136.6667F);
            this.Text12.Name = "Text12";
            this.Text12.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.Text12.SizeF = new System.Drawing.SizeF(38.54166F, 15.34722F);
            this.Text12.Text = "Name";
            this.Text12.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopLeft;
            // 
            // Text10
            // 
            this.Text10.BackColor = System.Drawing.Color.Transparent;
            this.Text10.BorderColor = System.Drawing.Color.Black;
            this.Text10.Borders = DevExpress.XtraPrinting.BorderSide.None;
            this.Text10.BorderWidth = 1F;
            this.Text10.CanGrow = false;
            this.Text10.Font = new DevExpress.Drawing.DXFont("Arial", 8F, DevExpress.Drawing.DXFontStyle.Underline);
            this.Text10.ForeColor = System.Drawing.Color.Black;
            this.Text10.LocationFloat = new DevExpress.Utils.PointFloat(600F, 136.6667F);
            this.Text10.Name = "Text10";
            this.Text10.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.Text10.SizeF = new System.Drawing.SizeF(41.66667F, 15.34722F);
            this.Text10.Text = "Source";
            this.Text10.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopLeft;
            // 
            // gsTitle1
            // 
            this.gsTitle1.BackColor = System.Drawing.Color.Transparent;
            this.gsTitle1.BorderColor = System.Drawing.Color.Black;
            this.gsTitle1.Borders = DevExpress.XtraPrinting.BorderSide.None;
            this.gsTitle1.BorderWidth = 1F;
            this.gsTitle1.CanGrow = false;
            this.gsTitle1.ExpressionBindings.AddRange(new DevExpress.XtraReports.UI.ExpressionBinding[] {
            new DevExpress.XtraReports.UI.ExpressionBinding("BeforePrint", "Text", "?gsTitle")});
            this.gsTitle1.Font = new DevExpress.Drawing.DXFont("Arial", 14F, DevExpress.Drawing.DXFontStyle.Bold);
            this.gsTitle1.ForeColor = System.Drawing.Color.Black;
            this.gsTitle1.LocationFloat = new DevExpress.Utils.PointFloat(0F, 95F);
            this.gsTitle1.Name = "gsTitle1";
            this.gsTitle1.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.gsTitle1.SizeF = new System.Drawing.SizeF(1050F, 33.33333F);
            this.gsTitle1.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopCenter;
            // 
            // Area4
            // 
            this.Area4.Controls.AddRange(new DevExpress.XtraReports.UI.XRControl[] {
            this.SumofAmount2,
            this.Text1});
            this.Area4.HeightF = 22F;
            this.Area4.KeepTogether = true;
            this.Area4.Name = "Area4";
            this.Area4.Padding = new DevExpress.XtraPrinting.PaddingInfo(0, 0, 0, 0, 100F);
            this.Area4.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopLeft;
            // 
            // SumofAmount2
            // 
            this.SumofAmount2.BackColor = System.Drawing.Color.Transparent;
            this.SumofAmount2.BorderColor = System.Drawing.Color.Black;
            this.SumofAmount2.Borders = DevExpress.XtraPrinting.BorderSide.Bottom;
            this.SumofAmount2.BorderWidth = 1F;
            this.SumofAmount2.CanGrow = false;
            this.SumofAmount2.ExpressionBindings.AddRange(new DevExpress.XtraReports.UI.ExpressionBinding[] {
            new DevExpress.XtraReports.UI.ExpressionBinding("BeforePrint", "Text", "sumSum([Amount])")});
            this.SumofAmount2.Font = new DevExpress.Drawing.DXFont("Arial", 8F, DevExpress.Drawing.DXFontStyle.Bold);
            this.SumofAmount2.ForeColor = System.Drawing.Color.Black;
            this.SumofAmount2.LocationFloat = new DevExpress.Utils.PointFloat(427.9861F, 0F);
            this.SumofAmount2.Name = "SumofAmount2";
            this.SumofAmount2.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.SumofAmount2.SizeF = new System.Drawing.SizeF(66.80556F, 13.33333F);
            xrSummary2.Running = DevExpress.XtraReports.UI.SummaryRunning.Report;
            this.SumofAmount2.Summary = xrSummary2;
            this.SumofAmount2.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopLeft;
            this.SumofAmount2.TextFormatString = "{0:C2}";
            // 
            // Text1
            // 
            this.Text1.BackColor = System.Drawing.Color.Transparent;
            this.Text1.BorderColor = System.Drawing.Color.Black;
            this.Text1.Borders = DevExpress.XtraPrinting.BorderSide.Bottom;
            this.Text1.BorderWidth = 1F;
            this.Text1.CanGrow = false;
            this.Text1.Font = new DevExpress.Drawing.DXFont("Arial", 8F, DevExpress.Drawing.DXFontStyle.Bold);
            this.Text1.ForeColor = System.Drawing.Color.Black;
            this.Text1.LocationFloat = new DevExpress.Utils.PointFloat(4.166667F, 0F);
            this.Text1.Name = "Text1";
            this.Text1.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.Text1.SizeF = new System.Drawing.SizeF(71.875F, 15.34722F);
            this.Text1.Text = "Grand Total:";
            this.Text1.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopLeft;
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
            this.PageNofM1.Font = new DevExpress.Drawing.DXFont("Arial", 10F);
            this.PageNofM1.ForeColor = System.Drawing.Color.Black;
            this.PageNofM1.LocationFloat = new DevExpress.Utils.PointFloat(866.6667F, 0F);
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
            this.gsUserName_1.LocationFloat = new DevExpress.Utils.PointFloat(291.6667F, 0F);
            this.gsUserName_1.Name = "gsUserName_1";
            this.gsUserName_1.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.gsUserName_1.SizeF = new System.Drawing.SizeF(232.2917F, 18.33333F);
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
            this.gsUserID_1.LocationFloat = new DevExpress.Utils.PointFloat(250F, 0F);
            this.gsUserID_1.Name = "gsUserID_1";
            this.gsUserID_1.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.gsUserID_1.SizeF = new System.Drawing.SizeF(41.66675F, 18.33333F);
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
            this.Text5.LocationFloat = new DevExpress.Utils.PointFloat(200F, 0F);
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
            this.DataDate1.Font = new DevExpress.Drawing.DXFont("Arial", 10F);
            this.DataDate1.ForeColor = System.Drawing.Color.Black;
            this.DataDate1.LocationFloat = new DevExpress.Utils.PointFloat(8.333333F, 0F);
            this.DataDate1.Name = "DataDate1";
            this.DataDate1.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.DataDate1.PageInfo = DevExpress.XtraPrinting.PageInfo.DateTime;
            this.DataDate1.SizeF = new System.Drawing.SizeF(83.33333F, 18.33333F);
            this.DataDate1.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopLeft;
            this.DataDate1.TextFormatString = "{0:MM/dd/yyyy}";
            // 
            // Name_1
            // 
            this.Name_1.DataMember = "AutoPayRejects";
            this.Name_1.Expression = "Trim([FirstName]) + \' \' + Trim([LastName])";
            this.Name_1.FieldType = DevExpress.XtraReports.UI.FieldType.String;
            this.Name_1.Name = "Name_1";
            // 
            // ClosedOpen
            // 
            this.ClosedOpen.DataMember = "AutoPayRejects";
            this.ClosedOpen.Expression = "Iif([IACType] = \'O\', \'OPEN END PAYMENTS\', \'CLOSED END PAYMENTS\')";
            this.ClosedOpen.FieldType = DevExpress.XtraReports.UI.FieldType.String;
            this.ClosedOpen.Name = "ClosedOpen";
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
            // gsTitle
            // 
            this.gsTitle.Description = "Enter gsTitle:";
            this.gsTitle.Name = "gsTitle";
            this.gsTitle.ValueInfo = "EFT PAYMENT REJECTS REPORT";
            // 
            // sqlDataSource1
            // 
            this.sqlDataSource1.ConnectionName = "IAC2021SQL.Properties.Settings.IAC2010SQLConnectionString";
            this.sqlDataSource1.Name = "sqlDataSource1";
            storedProcQuery1.Name = "AutoPayRejects";
            storedProcQuery1.StoredProcName = "AutoPayRejectsSelectAll";
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
            // XtraReportAutoPaymentRejects
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
            this.Name_1,
            this.ClosedOpen});
            this.ComponentStorage.AddRange(new System.ComponentModel.IComponent[] {
            this.sqlDataSource1});
            this.DataMember = "AutoPayRejects";
            this.DataSource = this.sqlDataSource1;
            this.Landscape = true;
            this.Margins = new DevExpress.Drawing.DXMargins(20F, 20F, 20F, 20F);
            this.PageHeight = 850;
            this.PageWidth = 1100;
            this.ParameterPanelLayoutItems.AddRange(new DevExpress.XtraReports.Parameters.ParameterPanelLayoutItem[] {
            new DevExpress.XtraReports.Parameters.ParameterLayoutItem(this.gsUserName, DevExpress.XtraReports.Parameters.Orientation.Horizontal),
            new DevExpress.XtraReports.Parameters.ParameterLayoutItem(this.gsUserID, DevExpress.XtraReports.Parameters.Orientation.Horizontal),
            new DevExpress.XtraReports.Parameters.ParameterLayoutItem(this.gsTitle, DevExpress.XtraReports.Parameters.Orientation.Horizontal)});
            this.Parameters.AddRange(new DevExpress.XtraReports.Parameters.Parameter[] {
            this.gsUserName,
            this.gsUserID,
            this.gsTitle});
            this.Version = "23.1";
            ((System.ComponentModel.ISupportInitialize)(this)).EndInit();

        }

        #endregion

        private DevExpress.XtraReports.UI.DetailBand Area3;
        private DevExpress.XtraReports.UI.XRLabel IACType1;
        private DevExpress.XtraReports.UI.XRLabel CustomerNo1;
        private DevExpress.XtraReports.UI.XRLabel Status1;
        private DevExpress.XtraReports.UI.XRLabel Amount1;
        private DevExpress.XtraReports.UI.XRLabel PaymentType1;
        private DevExpress.XtraReports.UI.XRLabel PaymentCode1;
        private DevExpress.XtraReports.UI.XRLabel Reason1;
        private DevExpress.XtraReports.UI.XRLabel Name_2;
        private DevExpress.XtraReports.UI.XRLabel Source1;
        private DevExpress.XtraReports.UI.GroupHeaderBand GroupHeaderArea1;
        private DevExpress.XtraReports.UI.XRLabel ClosedOpen_1;
        private DevExpress.XtraReports.UI.GroupFooterBand GroupFooterArea1;
        private DevExpress.XtraReports.UI.XRLabel SumofAmount1;
        private DevExpress.XtraReports.UI.XRLabel ClosedOpen_2;
        private DevExpress.XtraReports.UI.ReportHeaderBand Area1;
        private DevExpress.XtraReports.UI.PageHeaderBand Area2;
        private DevExpress.XtraReports.UI.XRLabel Text2;
        private DevExpress.XtraReports.UI.XRLabel Text3;
        private DevExpress.XtraReports.UI.XRLabel Text4;
        private DevExpress.XtraReports.UI.XRLabel Text7;
        private DevExpress.XtraReports.UI.XRLabel Text8;
        private DevExpress.XtraReports.UI.XRLabel Text9;
        private DevExpress.XtraReports.UI.XRLabel Text11;
        private DevExpress.XtraReports.UI.XRLabel Text12;
        private DevExpress.XtraReports.UI.XRLabel Text10;
        private DevExpress.XtraReports.UI.XRLabel gsTitle1;
        private DevExpress.XtraReports.UI.ReportFooterBand Area4;
        private DevExpress.XtraReports.UI.XRLabel SumofAmount2;
        private DevExpress.XtraReports.UI.XRLabel Text1;
        private DevExpress.XtraReports.UI.PageFooterBand Area5;
        private DevExpress.XtraReports.UI.XRPageInfo PageNofM1;
        private DevExpress.XtraReports.UI.XRLabel gsUserName_1;
        private DevExpress.XtraReports.UI.XRLabel gsUserID_1;
        private DevExpress.XtraReports.UI.XRLabel Text5;
        private DevExpress.XtraReports.UI.XRPageInfo DataTime1;
        private DevExpress.XtraReports.UI.XRPageInfo DataDate1;
        private DevExpress.XtraReports.UI.CalculatedField Name_1;
        private DevExpress.XtraReports.UI.CalculatedField ClosedOpen;
        private DevExpress.XtraReports.Parameters.Parameter gsUserName;
        private DevExpress.XtraReports.Parameters.Parameter gsUserID;
        private DevExpress.XtraReports.Parameters.Parameter gsTitle;
        private DevExpress.XtraReports.UI.XRPictureBox Picture1;
        private DevExpress.DataAccess.Sql.SqlDataSource sqlDataSource1;
        private DevExpress.XtraReports.UI.TopMarginBand topMarginBand1;
        private DevExpress.XtraReports.UI.BottomMarginBand bottomMarginBand1;
    }
}

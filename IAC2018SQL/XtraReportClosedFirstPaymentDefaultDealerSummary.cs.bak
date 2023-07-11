using DevExpress.XtraReports.UI;
using System;
using System.Collections;
using System.ComponentModel;
using System.Drawing;

namespace IAC2021SQL
{
    public partial class XtraReportClosedFirstPaymentDefaultDealerSummary : DevExpress.XtraReports.UI.XtraReport
    {
        public XtraReportClosedFirstPaymentDefaultDealerSummary()
        {
            InitializeComponent();
        }

        private void XtraReportClosedFirstPaymentDefaultDealerSummary_BeforePrint(object sender, System.Drawing.Printing.PrintEventArgs e)
        {
            // Moses Newman 09/08/2022 Turn off PageHeaderSection2 when printing dealer summary subreport.
            this.MasterReport.Bands["Area2"].SubBands[0].Visible = false;
            this.MasterReport.Bands["Area2"].SubBands[1].Visible = true;
        }
    }
}

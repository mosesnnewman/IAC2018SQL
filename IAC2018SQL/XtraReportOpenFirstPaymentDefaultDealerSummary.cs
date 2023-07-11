using DevExpress.XtraReports.UI;
using System;
using System.Collections;
using System.ComponentModel;
using System.Drawing;

namespace IAC2021SQL
{
    public partial class XtraReportOpenFirstPaymentDefaultDealerSummary : DevExpress.XtraReports.UI.XtraReport
    {
        public XtraReportOpenFirstPaymentDefaultDealerSummary()
        {
            InitializeComponent();
        }

        private void XtraReportOpenFirstPaymentDefaultDealerSummary_BeforePrint(object sender, CancelEventArgs e)
        {
            // Moses Newman 01/31/2023 Turn off PageHeaderSection2 when printing dealer summary subreport.
            this.MasterReport.Bands["Area2"].SubBands[0].Visible = false;
            this.MasterReport.Bands["Area2"].SubBands[1].Visible = true;
        }
    }
}

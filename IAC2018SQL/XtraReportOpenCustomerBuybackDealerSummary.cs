using DevExpress.XtraReports.UI;
using System;
using System.Collections;
using System.ComponentModel;
using System.Drawing;

namespace IAC2021SQL
{
    public partial class XtraReportOpenCustomerBuybackDealerSummary : DevExpress.XtraReports.UI.XtraReport
    {
        public XtraReportOpenCustomerBuybackDealerSummary()
        {
            InitializeComponent();
        }

        private void XtraReportOpenCustomerBuybackDealerSummary_BeforePrint(object sender, CancelEventArgs e)
        {
            // Moses Newman 01/31/2023 Turn off Area2 SubBand1 when printing dealer summary subreport.
            this.MasterReport.Bands["Area2"].SubBands[0].Visible = false;
        }
    }
}

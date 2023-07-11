using DevExpress.XtraReports.UI;
using System;
using System.Collections;
using System.ComponentModel;
using System.Drawing;

namespace IAC2021SQL
{
    public partial class XtraReportClosedCustomerBuybackDealerSummary : DevExpress.XtraReports.UI.XtraReport
    {
        public XtraReportClosedCustomerBuybackDealerSummary()
        {
            InitializeComponent();
        }

        private void XtraReportClosedCustomerBuybackDealerSummary_BeforePrint(object sender, CancelEventArgs e)
        {
            // Moses Newman 09/12/2022 Turn off Area2 SubBand1 when printing dealer summary subreport.
            this.MasterReport.Bands["Area2"].SubBands[0].Visible = false;
        }
    }
}

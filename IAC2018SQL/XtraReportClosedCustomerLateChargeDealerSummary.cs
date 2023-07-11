using DevExpress.XtraReports.UI;
using System;
using System.Collections;
using System.ComponentModel;
using System.Drawing;

namespace IAC2021SQL
{
    public partial class XtraReportClosedCustomerLateChargeDealerSummary : DevExpress.XtraReports.UI.XtraReport
    {
        public XtraReportClosedCustomerLateChargeDealerSummary()
        {
            InitializeComponent();
        }

        private void XtraReportClosedCustomerLateChargeDealerSummary_BeforePrint(object sender, CancelEventArgs e)
        {
            // Moses Newman 08/05/2022 Turn off PageHeaderSection2 when printing dealer summary subreport.
            this.MasterReport.Bands["Area2"].SubBands[1].Visible = false;
        }
    }
}

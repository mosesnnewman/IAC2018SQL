using DevExpress.XtraReports.UI;
using System;
using System.Collections;
using System.ComponentModel;
using System.Drawing;

namespace IAC2021SQL
{
    public partial class XtraReportClosedPaidInAdvanceDealerSummary : DevExpress.XtraReports.UI.XtraReport
    {
        public XtraReportClosedPaidInAdvanceDealerSummary()
        {
            InitializeComponent();
        }

        private void XtraReportClosedPaidInAdvanceDealerSummary_BeforePrint(object sender, System.Drawing.Printing.PrintEventArgs e)
        {
            // Moses Newman 09/07/2022 Turn off PageHeaderSection2 when printing dealer summary subreport.
            //this.MasterReport.Bands["Area2"].SubBands[0].Visible = false;
            //this.MasterReport.Bands["Area2"].SubBands[1].Visible = false;
        }
    }
}

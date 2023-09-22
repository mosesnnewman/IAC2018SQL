using DevExpress.XtraReports.UI;
using System;
using System.Collections;
using System.ComponentModel;
using System.Drawing;

namespace IAC2021SQL
{
    public partial class XtraReportClosedCustomerComments : DevExpress.XtraReports.UI.XtraReport
    {
        public XtraReportClosedCustomerComments()
        {
            InitializeComponent();
        }

        private void XtraReportClosedCustomerComments_BeforePrint(object sender, CancelEventArgs e)
        {
            // Moses Newman 09/22/2023 Turn off Area2 GridHeader when printing comments subreport.
            this.MasterReport.Bands["Area2"].SubBands[0].Visible = false;
        }
    }
}

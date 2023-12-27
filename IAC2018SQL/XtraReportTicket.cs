using DevExpress.XtraReports.UI;
using System;
using System.Collections;
using System.ComponentModel;
using System.Drawing;

namespace IAC2021SQL
{
    public partial class XtraReportTicket : DevExpress.XtraReports.UI.XtraReport
    {
        public XtraReportTicket()
        {
            InitializeComponent();
        }

        private void Debit1_BeforePrint(object sender, CancelEventArgs e)
        {
            e.Cancel = Convert.ToDouble(Debit1.Value) == 0;
        }

        private void Credit1_BeforePrint(object sender, CancelEventArgs e)
        {
            e.Cancel = Convert.ToDouble(Credit1.Value) == 0;
        }

        private void SubDealer1_BeforePrint(object sender, CancelEventArgs e)
        {
            e.Cancel = Convert.ToDouble(SubDealer1.Value) == 0;
        }
    }
}

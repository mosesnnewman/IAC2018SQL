using DevExpress.XtraReports.UI;
using System;
using System.Collections;
using System.ComponentModel;
using System.Drawing;

namespace IAC2021SQL
{
    public partial class XtraReportAmortization : DevExpress.XtraReports.UI.XtraReport
    {
        public XtraReportAmortization()
        {
            InitializeComponent();
        }

        private void Payments1_BeforePrint(object sender, System.Drawing.Printing.PrintEventArgs e)
        {
            e.Cancel = Convert.ToDouble(Payments1.Summary.GetResult()) == 0;
        }

        private void TotalInterest2_BeforePrint(object sender, System.Drawing.Printing.PrintEventArgs e)
        {
            e.Cancel = Convert.ToDouble(TotalInterest2.Summary.GetResult()) == 0;
        }

        private void TotalPrincipal1_BeforePrint(object sender, System.Drawing.Printing.PrintEventArgs e)
        {
            e.Cancel = Convert.ToDouble(TotalPrincipal1.Summary.GetResult()) == 0;
        }

        private void GrandTotalPayments1_BeforePrint(object sender, System.Drawing.Printing.PrintEventArgs e)
        {
            e.Cancel = Convert.ToDouble(GrandTotalPayments1.Summary.GetResult()) == 0;
        }

        private void GrandTotalInterest1_BeforePrint(object sender, System.Drawing.Printing.PrintEventArgs e)
        {
            e.Cancel = Convert.ToDouble(GrandTotalInterest1.Summary.GetResult()) == 0;
        }

        private void GrandTotalPrincipal1_BeforePrint(object sender, System.Drawing.Printing.PrintEventArgs e)
        {
            e.Cancel = Convert.ToDouble(GrandTotalPrincipal1.Summary.GetResult()) == 0;
        }
    }
}

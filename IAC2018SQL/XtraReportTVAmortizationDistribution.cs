using DevExpress.XtraReports.UI;
using System;
using System.Collections;
using System.ComponentModel;
using System.Drawing;

namespace IAC2021SQL
{
    public partial class XtraReportTVAmortizationDistribution : DevExpress.XtraReports.UI.XtraReport
    {
        public XtraReportTVAmortizationDistribution()
        {
            InitializeComponent();
        }

        private void TotalNewLoans1_BeforePrint(object sender, System.Drawing.Printing.PrintEventArgs e)
        {
            e.Cancel = Convert.ToDouble(TotalNewLoans1.Summary.GetResult()) == 0;
        }

        private void TotalLateFees1_BeforePrint(object sender, System.Drawing.Printing.PrintEventArgs e)
        {
            e.Cancel = Convert.ToDouble(TotalLateFees1.Summary.GetResult()) == 0;
        }

        private void TotalISFFees1_BeforePrint(object sender, System.Drawing.Printing.PrintEventArgs e)
        {
            e.Cancel = Convert.ToDouble(TotalISFFees1.Summary.GetResult()) == 0;
        }

        private void TotalNonCash1_BeforePrint(object sender, System.Drawing.Printing.PrintEventArgs e)
        {
            e.Cancel = Convert.ToDouble(TotalNonCash1.Summary.GetResult()) == 0;
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

        private void GrandTotalNewLoans1_BeforePrint(object sender, System.Drawing.Printing.PrintEventArgs e)
        {
            e.Cancel = Convert.ToDouble(GrandTotalNewLoans1.Summary.GetResult()) == 0;
        }

        private void GrandTotalLateFees1_BeforePrint(object sender, System.Drawing.Printing.PrintEventArgs e)
        {
            e.Cancel = Convert.ToDouble(GrandTotalLateFees1.Summary.GetResult()) == 0;
        }

        private void GrandTotalISFFees1_BeforePrint(object sender, System.Drawing.Printing.PrintEventArgs e)
        {
            e.Cancel = Convert.ToDouble(GrandTotalISFFees1.Summary.GetResult()) == 0;
        }

        private void GrandTotalNonCash1_BeforePrint(object sender, System.Drawing.Printing.PrintEventArgs e)
        {
            e.Cancel = Convert.ToDouble(GrandTotalNonCash1.Summary.GetResult()) == 0;
        }

        private void GrandTotalPayments1_BeforePrint(object sender, System.Drawing.Printing.PrintEventArgs e)
        {
            e.Cancel = Convert.ToDouble(GrandTotalPayments1.Summary.GetResult()) == 0;
        }

        private void GrandTotalInterest1_BeforePrint(object sender, System.Drawing.Printing.PrintEventArgs e)
        {
            e.Cancel = Convert.ToDouble(GrandTotalInterest1.Summary.GetResult()) == 0;
        }

        private void NewTotalPrincipal_1_BeforePrint(object sender, System.Drawing.Printing.PrintEventArgs e)
        {
            e.Cancel = Convert.ToDouble(NewTotalPrincipal_1.Summary.GetResult()) == 0;
        }

        private void GrandTotalBalance_1_BeforePrint(object sender, System.Drawing.Printing.PrintEventArgs e)
        {
            e.Cancel = Convert.ToDouble(GrandTotalBalance_1.Summary.GetResult()) == 0;
        }

        private void Payment_1_BeforePrint(object sender, System.Drawing.Printing.PrintEventArgs e)
        {
            XRLabel label = (XRLabel)sender;
            XtraReportBase report = label.Report;
            string Event = Convert.ToString(report.GetCurrentColumnValue("NewEvent"));

            if (Event.Equals("RTCHG"))
            {
                label.Text = string.Format("{0:##0.000;#;#}", label.Value) + " %";
            }
        }
    }
}

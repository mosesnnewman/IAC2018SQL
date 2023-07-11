using DevExpress.XtraReports.UI;
using System;
using System.Collections;
using System.ComponentModel;
using System.Drawing;

namespace IAC2021SQL
{
    public partial class XtraReportClosedCustomerEditList : DevExpress.XtraReports.UI.XtraReport
    {
        public XtraReportClosedCustomerEditList()
        {
            InitializeComponent();
        }

        private void TotalLoanAmount1_BeforePrint(object sender, System.Drawing.Printing.PrintEventArgs e)
        {
            decimal.TryParse(Convert.ToString(TotalLoanAmount1.Summary.GetResult()), out decimal totalLoanAmount);
            if (totalLoanAmount == 0)
            {
                e.Cancel = true;
            }
        }

        private void TotalCash1_BeforePrint(object sender, System.Drawing.Printing.PrintEventArgs e)
        {
            decimal.TryParse(Convert.ToString(TotalCash1.Summary.GetResult()), out decimal totalCash);
            if (totalCash == 0)
            {
                e.Cancel = true;
            }
        }

        private void TotalInterest1_BeforePrint(object sender, System.Drawing.Printing.PrintEventArgs e)
        {
            decimal.TryParse(Convert.ToString(TotalInterest1.Summary.GetResult()), out decimal totalInterest);
            if (totalInterest == 0)
            {
                e.Cancel = true;
            }
        }

        private void TotalDealerDisc1_BeforePrint(object sender, System.Drawing.Printing.PrintEventArgs e)
        {
            decimal.TryParse(Convert.ToString(TotalDealerDisc1.Summary.GetResult()), out decimal totalDealerDisc);
            if (totalDealerDisc == 0)
            {
                e.Cancel = true;
            }
        }
    }
}

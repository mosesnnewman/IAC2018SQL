using DevExpress.XtraReports.UI;
using System;
using System.Collections;
using System.ComponentModel;
using System.Drawing;

namespace IAC2021SQL
{
    public partial class XtraReportOpenCustomerEditList : DevExpress.XtraReports.UI.XtraReport
    {
        public XtraReportOpenCustomerEditList()
        {
            InitializeComponent();
        }

        private void TotalLoanAmount1_BeforePrint(object sender, CancelEventArgs e)
        {
            decimal.TryParse(Convert.ToString(TotalLoanAmount1.Summary.GetResult()), out decimal totalLoanAmount);
            if (totalLoanAmount == 0)
            {
                e.Cancel = true;
            }
        }

        private void TotalCash1_BeforePrint(object sender, CancelEventArgs e)
        {
            decimal.TryParse(Convert.ToString(TotalCash1.Summary.GetResult()), out decimal totalCash);
            if (totalCash == 0)
            {
                e.Cancel = true;
            }
        }

        private void TotalInterest1_BeforePrint(object sender, CancelEventArgs e)
        {
            decimal.TryParse(Convert.ToString(TotalInterest1.Summary.GetResult()), out decimal totalInterest);
            if (totalInterest == 0)
            {
                e.Cancel = true;
            }
        }
    }
}

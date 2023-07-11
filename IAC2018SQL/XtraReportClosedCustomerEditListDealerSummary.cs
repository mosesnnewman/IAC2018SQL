using DevExpress.XtraReports.UI;
using System;
using System.Collections;
using System.ComponentModel;
using System.Drawing;

namespace IAC2021SQL
{
    public partial class XtraReportClosedCustomerEditListDealerSummary : DevExpress.XtraReports.UI.XtraReport
    {
        public XtraReportClosedCustomerEditListDealerSummary()
        {
            InitializeComponent();
        }

        private void TotalCustomerLoanAmount1_BeforePrint(object sender, CancelEventArgs e)
        {
            decimal.TryParse(Convert.ToString(TotalCustomerLoanAmount1.Summary.GetResult()), out decimal totalLoanAmount);
            if (totalLoanAmount == 0)
            {
                e.Cancel = true;
            }
        }

        private void TotalCustomerLoanInterest1_BeforePrint(object sender, CancelEventArgs e)
        {
            decimal.TryParse(Convert.ToString(TotalCustomerLoanInterest1.Summary.GetResult()), out decimal totalLoanInterest);
            if (totalLoanInterest == 0)
            {
                e.Cancel = true;
            }
        }

        private void TotalDealerDiscount1_BeforePrint(object sender, CancelEventArgs e)
        {
            decimal.TryParse(Convert.ToString(TotalDealerDiscount1.Summary.GetResult()), out decimal totalDealerDiscount);
            if (totalDealerDiscount == 0)
            {
                e.Cancel = true;
            }
        }

        private void GrandTotalCustomerLoanAmount1_BeforePrint(object sender, CancelEventArgs e)
        {
            decimal.TryParse(Convert.ToString(GrandTotalCustomerLoanAmount1.Summary.GetResult()), out decimal totalGrandTotalLoanAmount);
            if (totalGrandTotalLoanAmount == 0)
            {
                e.Cancel = true;
            }
        }

        private void GrandTotalCustomerLoanInterest1_BeforePrint(object sender, CancelEventArgs e)
        {
            decimal.TryParse(Convert.ToString(GrandTotalCustomerLoanInterest1.Summary.GetResult()), out decimal totalGrandTotalLoanInterest);
            if (totalGrandTotalLoanInterest == 0)
            {
                e.Cancel = true;
            }
        }

        private void GrandTotalCustomerDealerDiscount1_BeforePrint(object sender, CancelEventArgs e)
        {
            decimal.TryParse(Convert.ToString(GrandTotalCustomerDealerDiscount1.Summary.GetResult()), out decimal totalGrandTotalDealerDiscount);
            if (totalGrandTotalDealerDiscount == 0)
            {
                e.Cancel = true;
            }
        }
    }
}

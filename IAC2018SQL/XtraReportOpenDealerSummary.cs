using DevExpress.XtraReports.UI;
using System;
using System.Collections;
using System.ComponentModel;
using System.Drawing;

namespace IAC2021SQL
{
    public partial class XtraReportOpenDealerSummary : DevExpress.XtraReports.UI.XtraReport
    {
        public XtraReportOpenDealerSummary()
        {
            InitializeComponent();
        }

        private void TotalDealerNR1_BeforePrint(object sender, CancelEventArgs e)
        {
            decimal.TryParse(Convert.ToString(TotalDealerNR1.Summary.GetResult()), out decimal totalNR);
            if (totalNR == 0)
            {
                e.Cancel = true;
            }
        }

        private void TotalDealerCont1_BeforePrint(object sender, CancelEventArgs e)
        {
            decimal.TryParse(Convert.ToString(TotalDealerCont1.Summary.GetResult()), out decimal totalCont);
            if (totalCont == 0)
            {
                e.Cancel = true;
            }
        }

        private void TotalDealerAdj1_BeforePrint(object sender, CancelEventArgs e)
        {
            decimal.TryParse(Convert.ToString(TotalDealerAdj1.Summary.GetResult()), out decimal totalADJ);
            if (totalADJ == 0)
            {
                e.Cancel = true;
            }
        }

        private void TotalDealerLossRsv1_BeforePrint(object sender, CancelEventArgs e)
        {
            decimal.TryParse(Convert.ToString(TotalDealerLossRsv1.Summary.GetResult()), out decimal totalLossRsv);
            if (totalLossRsv == 0)
            {
                e.Cancel = true;
            }
        }
    }
}

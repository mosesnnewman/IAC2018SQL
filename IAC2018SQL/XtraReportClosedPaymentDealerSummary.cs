using DevExpress.XtraReports.UI;
using System;
using System.Collections;
using System.ComponentModel;
using System.Drawing;

namespace IAC2021SQL
{
    public partial class XtraReportClosedPaymentDealerSummary : DevExpress.XtraReports.UI.XtraReport
    {
        private void SIMPLE_INTEREST_1_SummaryCalculated(object sender, TextFormatEventArgs e)
        {
            if (e.Value != null)
                (MasterReport as XtraReportClosedPaymentBalanceJournal).gnSimpleInterest += Convert.ToDecimal(e.Value);
        }

        public XtraReportClosedPaymentDealerSummary()
        {
            InitializeComponent();
        }

        private void AMORTIZED_INTEREST_1_SummaryCalculated(object sender, TextFormatEventArgs e)
        {
            if (e.Value != null)
                (MasterReport as XtraReportClosedPaymentBalanceJournal).gnAmortInterest += Convert.ToDecimal(e.Value) *-1;
        }

        private void NON_AMORT_INTEREST_1_SummaryCalculated(object sender, TextFormatEventArgs e)
        {
            if (e.Value != null)
                (MasterReport as XtraReportClosedPaymentBalanceJournal).gnOldInterest += Convert.ToDecimal(e.Value) * -1;
        }

        private void TotalSimpleInterest1_SummaryCalculated(object sender, TextFormatEventArgs e)
        {
            if (e.Value != null)
                (MasterReport as XtraReportClosedPaymentBalanceJournal).gnSimpleInterest += Convert.ToDecimal(e.Value) * -1;
        }
    }
}


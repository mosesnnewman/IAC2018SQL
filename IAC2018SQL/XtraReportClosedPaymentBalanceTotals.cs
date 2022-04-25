using DevExpress.XtraReports.UI;
using System;
using System.Collections;
using System.ComponentModel;
using System.Drawing;

namespace IAC2021SQL
{
    public partial class XtraReportClosedPaymentBalanceTotals : DevExpress.XtraReports.UI.XtraReport
    {
        public XtraReportClosedPaymentBalanceTotals()
        {
            InitializeComponent();
        }

        private void NewAmortizedInterest_GetValue(object sender, GetValueEventArgs e)
        {
            e.Value = (MasterReport as XtraReportClosedPaymentBalanceJournal).gnAmortInterest;
        }

        private void OldNonAmortInterest_GetValue(object sender, GetValueEventArgs e)
        {
            e.Value = (MasterReport as XtraReportClosedPaymentBalanceJournal).gnOldInterest;
        }

        private void SimpleInterest_GetValue(object sender, GetValueEventArgs e)
        {
            e.Value = (MasterReport as XtraReportClosedPaymentBalanceJournal).gnSimpleInterest;
        }

        private void DealerDiscount_GetValue(object sender, GetValueEventArgs e)
        {
             e.Value = (MasterReport as XtraReportClosedPaymentBalanceJournal).gnDealerDisc;
        }
    }
}

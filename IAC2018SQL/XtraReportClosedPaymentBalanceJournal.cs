using DevExpress.XtraReports.UI;
using System;
using System.Collections;
using System.ComponentModel;
using System.Drawing;

namespace IAC2021SQL
{
    public partial class XtraReportClosedPaymentBalanceJournal : DevExpress.XtraReports.UI.XtraReport
    {
        public Decimal gnAmortInterest
        {
            get; set; 
        }
        public Decimal gnOldInterest
        {
            get; set;
        }

        public Decimal gnSimpleInterest
        {
            get; set;
        }

        public Decimal gnDealerDisc
        {
            get; set;
        }

        public XtraReportClosedPaymentBalanceJournal()
        {
            InitializeComponent();
        }

        private void xrLabelTotalDealerDisc_SummaryGetResult(object sender, SummaryGetResultEventArgs e)
        {
           
        }

        private void SubreportDealerSummary_BeforePrint(object sender, System.Drawing.Printing.PrintEventArgs e)
        {
        }

        private void PaidDiscount1_SummaryCalculated(object sender, TextFormatEventArgs e)
        {
            if (e.Value != null)
                (MasterReport as XtraReportClosedPaymentBalanceJournal).gnDealerDisc += Convert.ToDecimal(e.Value);
        }
}
}

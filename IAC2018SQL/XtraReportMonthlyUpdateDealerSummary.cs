using DevExpress.XtraReports.UI;
using System;
using System.Collections;
using System.ComponentModel;
using System.Data;
using System.Drawing;

namespace IAC2021SQL
{
    public partial class XtraReportMonthlyUpdateDealerSummary : DevExpress.XtraReports.UI.XtraReport
    {
        public XtraReportMonthlyUpdateDealerSummary()
        {
            InitializeComponent();
        }

        Decimal DealerTotalInterest = 0,
                DealerPreviousBalance = 0,
                DealerAnnualYield = 0,
                StateTotalInterest = 0,
                StatePreviousBalance = 0,
                StateAnnualYield = 0,
                TotalInterest = 0,
                PreviousBalance = 0,
                AnnualYield = 0;

        Int32 DaysInMonth = 0;

        private void InterestByDealer1_SummaryCalculated(object sender, TextFormatEventArgs e)
        {
            if (e.Value != null)
                DealerTotalInterest += Convert.ToDecimal(e.Value);
        }

        private void AuditBalanceByDealer1_BeforePrint(object sender, System.Drawing.Printing.PrintEventArgs e)
        {
            DateTime RunDate = (DateTime)this.Parameters["gdLastRun"].Value;
            DealerPreviousBalance = (Decimal)this.PrevBalanceByDealer1.Summary.GetResult();
            DealerTotalInterest = (Decimal)this.InterestByDealer1.Summary.GetResult();
            DaysInMonth = DateTime.DaysInMonth(RunDate.Year, RunDate.Month);
            if (DealerTotalInterest != 0 && DealerPreviousBalance != 0)
            {
                DealerAnnualYield = (DealerTotalInterest / DealerPreviousBalance) / DaysInMonth * 365 * 100;
                AuditBalanceByDealer1.Text = string.Format("{0:##0.000;#;#}", DealerAnnualYield) + "%";
            }
            else
                AuditBalanceByDealer1.Text = "";
        }

        private void xrLabel17_SummaryCalculated(object sender, TextFormatEventArgs e)
        {
            if (e.Value != null)
                StateTotalInterest += Convert.ToDecimal(e.Value);
        }

        private void xrLabel23_BeforePrint(object sender, System.Drawing.Printing.PrintEventArgs e)
        {
            DateTime RunDate = (DateTime)this.Parameters["gdLastRun"].Value;
            StatePreviousBalance = (Decimal)this.xrLabel14.Summary.GetResult();
            StateTotalInterest = (Decimal)this.xrLabel17.Summary.GetResult();
            DaysInMonth = DateTime.DaysInMonth(RunDate.Year, RunDate.Month);
            StateAnnualYield = (StateTotalInterest / StatePreviousBalance) / DaysInMonth * 365 * 100;
            xrLabel23.Text = string.Format("{0:##0.000;#;#}", StateAnnualYield) + "%";
        }

        private void PrevBalanceByDealer1_SummaryCalculated(object sender, TextFormatEventArgs e)
        {
            if (e.Value != null)
                DealerPreviousBalance += Convert.ToDecimal(e.Value);
        }

        private void TotalInterest1_SummaryCalculated(object sender, TextFormatEventArgs e)
        {
            if (e.Value != null)
                TotalInterest += Convert.ToDecimal(e.Value);
        }

        private void XtraReportMonthlyUpdateDealerSummary_BeforePrint(object sender, System.Drawing.Printing.PrintEventArgs e)
        {
            // Moses Newman 10/7/2022 Turn off Area2 SubBand2 when printing dealer summary subreport.
            this.MasterReport.Bands["Area2"].SubBands[1].Visible = false;
        }

        private void xrLabel14_SummaryCalculated(object sender, TextFormatEventArgs e)
        {
            if (e.Value != null)
                StatePreviousBalance += Convert.ToDecimal(e.Value);
        }

        private void TotalAuditBalance1_BeforePrint(object sender, System.Drawing.Printing.PrintEventArgs e)
        {
            DateTime RunDate = (DateTime)this.Parameters["gdLastRun"].Value;
            PreviousBalance = (Decimal)this.TotalPrevBalance1.Summary.GetResult();
            TotalInterest = (Decimal)this.TotalInterest1.Summary.GetResult();
            DaysInMonth = DateTime.DaysInMonth(RunDate.Year, RunDate.Month);
            AnnualYield = (TotalInterest / PreviousBalance) / DaysInMonth * 365 * 100;
            TotalAuditBalance1.Text = string.Format("{0:##0.000;#;#}", AnnualYield)+"%";
        }
        private void TotalPrevBalance1_SummaryCalculated(object sender, TextFormatEventArgs e)
        {
            if (e.Value != null)
                PreviousBalance += Convert.ToDecimal(e.Value);
        }
    }
}

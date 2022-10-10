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

        private void NextMonthEndDate_BeforePrint(object sender, System.Drawing.Printing.PrintEventArgs e)
        {
            DateTime NewRunDate = (DateTime)this.Parameters["gdLastRun"].Value;
            DateTime NextMonthDate = NewRunDate.AddDays(1);
            Int32 DaysInNewMonth = DateTime.DaysInMonth(NextMonthDate.Year, NextMonthDate.Month);
            String NewText = "Projected Interest For ";
            DateTime NewDate = DateTime.Parse(NextMonthDate.Month.ToString() + "/" + DaysInNewMonth.ToString() + "/" + NextMonthDate.Year.ToString());
            NewText += string.Format("{0:MM/dd/yyyy}", NewDate)+": ";
            DateTime RunDate = (DateTime)this.Parameters["gdLastRun"].Value;
            PreviousBalance = (Decimal)this.TotalPrevBalance1.Summary.GetResult();
            TotalInterest = (Decimal)this.TotalInterest1.Summary.GetResult();
            DaysInMonth = DateTime.DaysInMonth(RunDate.Year, RunDate.Month);
            Decimal NextMonthYield = (TotalInterest / PreviousBalance) / DaysInMonth * DaysInNewMonth;
            Decimal TotalBalance = (Decimal)this.TotalBalance1.Summary.GetResult();
            Decimal NewInterest = NextMonthYield * TotalBalance;
            NewText += " " + string.Format("{0:$#,##0.00}", NewInterest);
            NextMonthEndDate.Text = NewText;
        }

        private void ChangeDueToISF1_BeforePrint(object sender, System.Drawing.Printing.PrintEventArgs e)
        {
            decimal.TryParse(Convert.ToString(ChangeDueToISF1.Summary.GetResult()), out decimal changeDueToISF);
            if (changeDueToISF == 0)
            {
                e.Cancel = true;
            }
        }

        private void NewBusinessbyDealer1_BeforePrint(object sender, System.Drawing.Printing.PrintEventArgs e)
        {
            decimal.TryParse(Convert.ToString(NewBusinessbyDealer1.Summary.GetResult()), out decimal newBusinessbyDealer);
            if (newBusinessbyDealer == 0)
            {
                e.Cancel = true;
            }
        }

        private void PrevBalanceByDealer1_BeforePrint(object sender, System.Drawing.Printing.PrintEventArgs e)
        {
            decimal.TryParse(Convert.ToString(PrevBalanceByDealer1.Summary.GetResult()), out decimal prevBalanceByDealer);
            if (prevBalanceByDealer == 0)
            {
                e.Cancel = true;
            }
        }

        private void InterestByDealer1_BeforePrint(object sender, System.Drawing.Printing.PrintEventArgs e)
        {
            decimal.TryParse(Convert.ToString(InterestByDealer1.Summary.GetResult()), out decimal interestByDealer);
            if (interestByDealer == 0)
            {
                e.Cancel = true;
            }
        }

        private void LateFeesbyDealer1_BeforePrint(object sender, System.Drawing.Printing.PrintEventArgs e)
        {
            decimal.TryParse(Convert.ToString(LateFeesbyDealer1.Summary.GetResult()), out decimal lateFeesbyDealer);
            if (lateFeesbyDealer == 0)
            {
                e.Cancel = true;
            }
        }

        private void ISFFeesbyDealer1_BeforePrint(object sender, System.Drawing.Printing.PrintEventArgs e)
        {
            decimal.TryParse(Convert.ToString(ISFFeesbyDealer1.Summary.GetResult()), out decimal iSFFeesbyDealer);
            if (iSFFeesbyDealer == 0)
            {
                e.Cancel = true;
            }
        }

        private void NonCashFeesbyDealer1_BeforePrint(object sender, System.Drawing.Printing.PrintEventArgs e)
        {
            decimal.TryParse(Convert.ToString(NonCashFeesbyDealer1.Summary.GetResult()), out decimal nonCashFeesbyDealer);
            if (nonCashFeesbyDealer == 0)
            {
                e.Cancel = true;
            }
        }

        private void PaymentsbyDealer1_BeforePrint(object sender, System.Drawing.Printing.PrintEventArgs e)
        {
            decimal.TryParse(Convert.ToString(PaymentsbyDealer1.Summary.GetResult()), out decimal paymentsbyDealer);
            if (paymentsbyDealer == 0)
            {
                e.Cancel = true;
            }
        }

        private void BalanceByDealer1_BeforePrint(object sender, System.Drawing.Printing.PrintEventArgs e)
        {
            decimal.TryParse(Convert.ToString(BalanceByDealer1.Summary.GetResult()), out decimal balanceByDealer);
            if (balanceByDealer == 0)
            {
                e.Cancel = true;
            }
        }

        private void stateprevbal_BeforePrint(object sender, System.Drawing.Printing.PrintEventArgs e)
        {
            decimal.TryParse(Convert.ToString(stateprevbal.Summary.GetResult()), out decimal statePreviousBalance);
            if (statePreviousBalance == 0)
            {
                e.Cancel = true;
            }
        }

        private void StateChangeDueToISF_BeforePrint(object sender, System.Drawing.Printing.PrintEventArgs e)
        {
            decimal.TryParse(Convert.ToString(StateChangeDueToISF.Summary.GetResult()), out decimal stateChangeDueToISF);
            if (stateChangeDueToISF == 0)
            {
                e.Cancel = true;
            }
        }

        private void StateNewBusiness_BeforePrint(object sender, System.Drawing.Printing.PrintEventArgs e)
        {
            decimal.TryParse(Convert.ToString(StateNewBusiness.Summary.GetResult()), out decimal stateNewBusiness);
            if (stateNewBusiness == 0)
            {
                e.Cancel = true;
            }
        }

        private void StateInterest_BeforePrint(object sender, System.Drawing.Printing.PrintEventArgs e)
        {
            decimal.TryParse(Convert.ToString(StateInterest.Summary.GetResult()), out decimal stateInterest);
            if (stateInterest == 0)
            {
                e.Cancel = true;
            }
        }

        private void StateLateFees_BeforePrint(object sender, System.Drawing.Printing.PrintEventArgs e)
        {
            decimal.TryParse(Convert.ToString(StateLateFees.Summary.GetResult()), out decimal stateLateFees);
            if (stateLateFees == 0)
            {
                e.Cancel = true;
            }
        }

        private void StateISFFees_BeforePrint(object sender, System.Drawing.Printing.PrintEventArgs e)
        {
            decimal.TryParse(Convert.ToString(StateISFFees.Summary.GetResult()), out decimal stateISFFees);
            if (stateISFFees == 0)
            {
                e.Cancel = true;
            }
        }

        private void StateNonCash_BeforePrint(object sender, System.Drawing.Printing.PrintEventArgs e)
        {
            decimal.TryParse(Convert.ToString(StateNonCash.Summary.GetResult()), out decimal stateNonCash);
            if (stateNonCash == 0)
            {
                e.Cancel = true;
            }
        }

        private void StatePayments_BeforePrint(object sender, System.Drawing.Printing.PrintEventArgs e)
        {
            decimal.TryParse(Convert.ToString(StatePayments.Summary.GetResult()), out decimal statePayments);
            if (statePayments == 0)
            {
                e.Cancel = true;
            }
        }

        private void StateNewBalance_BeforePrint(object sender, System.Drawing.Printing.PrintEventArgs e)
        {
            decimal.TryParse(Convert.ToString(StateNewBalance.Summary.GetResult()), out decimal stateNewBalance);
            if (stateNewBalance == 0)
            {
                e.Cancel = true;
            }
        }

        private void xrLabel17_SummaryCalculated(object sender, TextFormatEventArgs e)
        {
            if (e.Value != null)
                StateTotalInterest += Convert.ToDecimal(e.Value);
        }

        private void xrLabel23_BeforePrint(object sender, System.Drawing.Printing.PrintEventArgs e)
        {
            DateTime RunDate = (DateTime)this.Parameters["gdLastRun"].Value;
            StatePreviousBalance = (Decimal)this.stateprevbal.Summary.GetResult();
            StateTotalInterest = (Decimal)this.StateInterest.Summary.GetResult();
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

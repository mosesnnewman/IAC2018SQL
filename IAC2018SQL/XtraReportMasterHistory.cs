using DevExpress.XtraReports.UI;
using System;
using System.Collections;
using System.ComponentModel;
using System.Drawing;

namespace IAC2021SQL
{
    public partial class XtraReportMasterHistory : DevExpress.XtraReports.UI.XtraReport
    {
        public XtraReportMasterHistory()
        {
            InitializeComponent();
        }

        private void TotalCurReserve1_BeforePrint(object sender, CancelEventArgs e)
        {
            decimal.TryParse(Convert.ToString(TotalCurReserve1.Summary.GetResult()), out decimal totalCurReserve);
            if (totalCurReserve == 0)
            {
                e.Cancel = true;
            }
        }

        private void TotalYTDReserve1_BeforePrint(object sender, CancelEventArgs e)
        {
            decimal.TryParse(Convert.ToString(TotalYTDReserve1.Summary.GetResult()), out decimal totalYTDReserve);
            if (totalYTDReserve == 0)
            {
                e.Cancel = true;
            }
        }

        private void TotalCurCont1_BeforePrint(object sender, CancelEventArgs e)
        {
            decimal.TryParse(Convert.ToString(TotalCurCont1.Summary.GetResult()), out decimal totalCurCont);
            if (totalCurCont == 0)
            {
                e.Cancel = true;
            }
        }

        private void TotalYTDCont1_BeforePrint(object sender, CancelEventArgs e)
        {
            decimal.TryParse(Convert.ToString(TotalYTDCont1.Summary.GetResult()), out decimal totalYTDCont);
            if (totalYTDCont == 0)
            {
                e.Cancel = true;
            }
        }

        private void TotalCurOLoan1_BeforePrint(object sender, CancelEventArgs e)
        {
            decimal.TryParse(Convert.ToString(TotalCurOLoan1.Summary.GetResult()), out decimal totalCurOloan);
            if (totalCurOloan == 0)
            {
                e.Cancel = true;
            }
        }

        private void TotalYTDOLoan1_BeforePrint(object sender, CancelEventArgs e)
        {
            decimal.TryParse(Convert.ToString(TotalYTDOLoan1.Summary.GetResult()), out decimal totalYTDOloan);
            if (totalYTDOloan == 0)
            {
                e.Cancel = true;
            }
        }

        private void TotalCurNotesPayable1_BeforePrint(object sender, CancelEventArgs e)
        {
            decimal.TryParse(Convert.ToString(TotalCurNotesPayable1.Summary.GetResult()), out decimal totalCurNotesPayable);
            if (totalCurNotesPayable == 0)
            {
                e.Cancel = true;
            }
        }

        private void TotalTYDNotesPayable1_BeforePrint(object sender, CancelEventArgs e)
        {
            decimal.TryParse(Convert.ToString(TotalTYDNotesPayable1.Summary.GetResult()), out decimal totalYTDNotesPayable);
            if (totalYTDNotesPayable == 0)
            {
                e.Cancel = true;
            }
        }

        private void TotalCurBad1_BeforePrint(object sender, CancelEventArgs e)
        {
            decimal.TryParse(Convert.ToString(TotalCurBad1.Summary.GetResult()), out decimal totalCurBad);
            if (totalCurBad == 0)
            {
                e.Cancel = true;
            }
        }

        private void TotalYTDBad1_BeforePrint(object sender, CancelEventArgs e)
        {
            decimal.TryParse(Convert.ToString(TotalYTDBad1.Summary.GetResult()), out decimal totalYTDBad);
            if (totalYTDBad == 0)
            {
                e.Cancel = true;
            }
        }

        private void TotalCurLoss1_BeforePrint(object sender, CancelEventArgs e)
        {
            decimal.TryParse(Convert.ToString(TotalCurLoss1.Summary.GetResult()), out decimal totalCurLoss);
            if (totalCurLoss == 0)
            {
                e.Cancel = true;
            }
        }

        private void TotalYTDLoss1_BeforePrint(object sender, CancelEventArgs e)
        {
            decimal.TryParse(Convert.ToString(TotalYTDLoss1.Summary.GetResult()), out decimal totalYTDLoss);
            if (totalYTDLoss == 0)
            {
                e.Cancel = true;
            }
        }

        private void TotalCurAdj1_BeforePrint(object sender, CancelEventArgs e)
        {
            decimal.TryParse(Convert.ToString(TotalCurAdj1.Summary.GetResult()), out decimal totalCurAdj);
            if (totalCurAdj == 0)
            {
                e.Cancel = true;
            }
        }

        private void TotalYTDAdj1_BeforePrint(object sender, CancelEventArgs e)
        {
            decimal.TryParse(Convert.ToString(TotalYTDAdj1.Summary.GetResult()), out decimal totalYTDAdj);
            if (totalYTDAdj == 0)
            {
                e.Cancel = true;
            }
        }

        private void TotalCurInt1_BeforePrint(object sender, CancelEventArgs e)
        {
            decimal.TryParse(Convert.ToString(TotalCurInt1.Summary.GetResult()), out decimal totalCurInt);
            if (totalCurInt == 0)
            {
                e.Cancel = true;
            }
        }

        private void TotalYTDInt1_BeforePrint(object sender, CancelEventArgs e)
        {
            decimal.TryParse(Convert.ToString(TotalYTDInt1.Summary.GetResult()), out decimal totalYTDInt);
            if (totalYTDInt == 0)
            {
                e.Cancel = true;
            }
        }

        private void TotalCurAmortInt1_BeforePrint(object sender, CancelEventArgs e)
        {
            decimal.TryParse(Convert.ToString(TotalCurAmortInt1.Summary.GetResult()), out decimal totalCurAmortInt);
            if (totalCurAmortInt == 0)
            {
                e.Cancel = true;
            }
        }

        private void TotalYTDAmortInt1_BeforePrint(object sender, CancelEventArgs e)
        {
            decimal.TryParse(Convert.ToString(TotalYTDAmortInt1.Summary.GetResult()), out decimal totalYTDAmortInt);
            if (totalYTDAmortInt == 0)
            {
                e.Cancel = true;
            }
        }
    }
}

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Threading;
using System.IO;

namespace IAC2018SQL
{
    public partial class frmOpenTrialBalance : Form
    {

        public frmOpenTrialBalance()
        {
            InitializeComponent();
        }

        private void frmOpenTrialBalance_Load(object sender, EventArgs e)
        {
            Int32 lnRunMonth = DateTime.Now.Date.Month, lnRunYear = DateTime.Now.Date.Year;

            stateTableAdapter.Fill(iACDataSet.state);
            StatebindingSource.AddNew();
            StatebindingSource.EndEdit();
            iACDataSet.state.Rows[StatebindingSource.Position].SetField<String>("abbreviation", "");
            iACDataSet.state.Rows[StatebindingSource.Position].SetField<String>("name", "");
            StatebindingSource.EndEdit();
            dlrlistbynumTableAdapter.Fill(iACDataSet.DLRLISTBYNUM);
            DLRLISTBYNUMbindingSource.AddNew();
            DLRLISTBYNUMbindingSource.EndEdit();
            iACDataSet.DLRLISTBYNUM.Rows[DLRLISTBYNUMbindingSource.Position].SetField<String>("DEALER_ACC_NO", "   ");
            iACDataSet.DLRLISTBYNUM.Rows[DLRLISTBYNUMbindingSource.Position].SetField<String>("DEALER_NAME", "                  ");
            DLRLISTBYNUMbindingSource.EndEdit();
        }
        
        private void buttonPost_Click(object sender, EventArgs e)
        {
            Hide();
            MDIIAC2013 MDImain = (MDIIAC2013)MdiParent;
            MDImain.CreateFormInstance("ReportViewer", false);
            ReportViewer rptViewr = (ReportViewer)MDImain.ActiveMdiChild;

            PrintOpenTrialBalance(rptViewr);
            Close();
        }

        private void buttonCancel_Click(Object sender, EventArgs e)
        {
            Close();
        }

        private void PrintOpenTrialBalance(ReportViewer rptViewer)
        {
            String  lsDealerNum = comboBoxDealer.Text.TrimEnd().TrimStart() + "%",lsState;

            lsState = (comboBoxState.SelectedValue != null) ? comboBoxState.SelectedValue.ToString().TrimStart().TrimEnd() + "%" : "%";

            IACDataSetTableAdapters.OPNCUSTTableAdapter CUSTOMERTableAdapter = new IACDataSetTableAdapters.OPNCUSTTableAdapter();
            IACDataSetTableAdapters.OPNDEALRTableAdapter DEALERTableAdapter = new IACDataSetTableAdapters.OPNDEALRTableAdapter();
            IACDataSetTableAdapters.WS_OPNDEALR_TRIAL_BALANCETableAdapter WS_DEALER_TRIAL_BALANCETableAdapter = new IACDataSetTableAdapters.WS_OPNDEALR_TRIAL_BALANCETableAdapter();
            IACDataSetTableAdapters.MastHistTotalsTableAdapter MastHistTotalsTableAdapter = new IACDataSetTableAdapters.MastHistTotalsTableAdapter();

            CUSTOMERTableAdapter.CustomizeFill(@"SELECT * FROM OPNCUST WHERE CUSTOMER_ACT_STAT = 'A' ORDER BY CUSTOMER_DEALER");
            CUSTOMERTableAdapter.CustomFillBy(iACDataSet.OPNCUST);
            DEALERTableAdapter.CustomizeFill(@"SELECT * FROM OPNDEALR WHERE OPNDEALR_ACC_NO IN (SELECT CUSTOMER_DEALER FROM OPNCUST WHERE CUSTOMER_ACT_STAT = 'A') ORDER BY OPNDEALR_ACC_NO");
            DEALERTableAdapter.CustomFillBy(iACDataSet.OPNDEALR);
            WS_DEALER_TRIAL_BALANCETableAdapter.Fill(iACDataSet.WS_OPNDEALR_TRIAL_BALANCE);
            MastHistTotalsTableAdapter.Fill(iACDataSet.MastHistTotals, "O");

            OpenLoanTrialBalance myReportObject = new OpenLoanTrialBalance();
            myReportObject.SetDataSource(iACDataSet);
            myReportObject.SetParameterValue("gsUserID", Program.gsUserID);
            myReportObject.SetParameterValue("gsUserName", Program.gsUserName);

            rptViewer.crystalReportViewer.ReportSource = myReportObject;
            rptViewer.crystalReportViewer.Refresh();
            rptViewer.Show();
        }

        private void buttonExcel_Click(object sender, EventArgs e)
        {
            SQLBackupandRestore SQLBR = new SQLBackupandRestore();
            TrialBalancePretty TBP = new TrialBalancePretty();

            String lsDealerNum = comboBoxDealer.Text.TrimEnd().TrimStart() + "%", lsState;

            lsState = (comboBoxState.SelectedValue != null) ? comboBoxState.SelectedValue.ToString().TrimStart().TrimEnd() + "%" : "%";

            IACDataSetTableAdapters.OPNCUSTTableAdapter CUSTOMERTableAdapter = new IACDataSetTableAdapters.OPNCUSTTableAdapter();
            IACDataSetTableAdapters.OpenDealerSummaryTableAdapter OpenDealerSummaryTableAdapter = new IACDataSetTableAdapters.OpenDealerSummaryTableAdapter();
            IACDataSetTableAdapters.WS_OPNDEALR_TRIAL_BALANCETableAdapter WS_DEALER_TRIAL_BALANCETableAdapter = new IACDataSetTableAdapters.WS_OPNDEALR_TRIAL_BALANCETableAdapter();
            // Moses Newman 05/3/2014 Get rid of SQL Pass Through!
            CUSTOMERTableAdapter.CustomizeFill(@"SELECT * FROM OPNCUST WHERE CUSTOMER_ACT_STAT = 'A' ORDER BY CUSTOMER_DEALER");
            CUSTOMERTableAdapter.CustomFillBy(iACDataSet.OPNCUST);
            OpenDealerSummaryTableAdapter.Fill(iACDataSet.OpenDealerSummary, DateTime.Now.Month, DateTime.Now.Year);
            WS_DEALER_TRIAL_BALANCETableAdapter.Fill(iACDataSet.WS_OPNDEALR_TRIAL_BALANCE);
            Int32 elapsed = 0;
            if (SQLBR.RunJob("OpenTrialBalance", "Export Open Trial Balance To EXCEL", false))
            {
                TBP.IACType = "O";
                TBP.CustDealerCount = iACDataSet.OPNCUST.Rows.Count;
                TBP.DealerCount = iACDataSet.WS_OPNDEALR_TRIAL_BALANCE.Rows.Count;
                TBP.DealerSummaryCount = iACDataSet.OpenDealerSummary.Rows.Count;
                TBP.FullSourcePath = @"\\Dc-iac\public\AccStuff\mfdata\comp1000\OpenTrialBalance.xlsx";

                Thread.Sleep(5000);
                var fi1 = new FileInfo(TBP.FullSourcePath);

                while (TBP.IsFileLocked(fi1) && elapsed < 500000)
                {
                    Thread.Sleep(1000);
                    elapsed += 1000;
                }

                TBP.TBPRetty();
            }
        }
    }
}

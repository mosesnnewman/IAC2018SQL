﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Windows.Forms;
using System.IO;
using DevExpress.XtraReports.UI;
using DevExpress.DataAccess.Sql;
using DevExpress.DataAccess.Sql.DataApi;

namespace IAC2021SQL
{
    public partial class frmClosedTrialBalance : DevExpress.XtraEditors.XtraForm
    {

        public frmClosedTrialBalance()
        {
            InitializeComponent();
        }

        private void frmClosedTrialBalance_Load(object sender, EventArgs e)
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
            
            iACDataSet.DLRLISTBYNUM.Rows[DLRLISTBYNUMbindingSource.Position].SetField<String>("DEALER_NAME", "                  ");
            DLRLISTBYNUMbindingSource.EndEdit();
        }
        
        private void buttonPost_Click(object sender, EventArgs e)
        {
            PrintClosedTrialBalance();
            Close();
        }

        private void buttonCancel_Click(Object sender, EventArgs e)
        {
            Close();
        }

        private void PrintClosedTrialBalance()
        {
            Hide();
            MDIIAC2013 MDImain = (MDIIAC2013)MdiParent;

            String lsDealerNum = lookUpEditDealer.EditValue != null ? lookUpEditDealer.EditValue.ToString().Trim():"" + "%",lsState;

            lsState = (lookUpEditState.EditValue != null) ? lookUpEditState.EditValue.ToString().Trim() + "%" : "%";

            // Moses Newman 03/03/2022 Covert to XtraReport
            var report = new XtraReportTrialBalance(); 
            SqlDataSource ds = report.DataSource as SqlDataSource;
           
            ds.Queries[0].Parameters[0].Value = lsState;
            ds.Queries[0].Parameters[1].Value = lsDealerNum;
            ds.Queries[1].Parameters[0].Value = lsState;
            ds.Queries[1].Parameters[1].Value = lsDealerNum;
            ds.Queries[2].Parameters[0].Value = "C";
            ds.Queries[3].Parameters[0].Value = lsState;
            ds.Queries[3].Parameters[1].Value = lsDealerNum;

            report.DataSource = ds;
            report.RequestParameters = false;
            report.Parameters["gsUserID"].Value = Program.gsUserID;
            report.Parameters["gsUserName"].Value = Program.gsUserName;

            // Moses Newman 04/17/2022 Now do DealerSummary Sub Report datasource!
            XRSubreport subReport = report.FindControl("DealerSummary", true) as XRSubreport;
            XtraReport reportSource = subReport.ReportSource as XtraReport;
            SqlDataSource subds = reportSource.DataSource as SqlDataSource;
            subds.Queries[0].Parameters[0].Value = lsState;
            subds.Queries[0].Parameters[1].Value = lsDealerNum;
            subds.Queries[1].Parameters[0].Value = "C";
            subds.Queries[2].Parameters[0].Value = lsState;
            subds.Queries[2].Parameters[1].Value = lsDealerNum;
            reportSource.DataSource = subds;

            var tool = new ReportPrintTool(report);

            tool.PreviewRibbonForm.MdiParent = MDImain;
            tool.AutoShowParametersPanel = false;
            tool.PreviewRibbonForm.WindowState = FormWindowState.Maximized;
            tool.ShowRibbonPreview();
        }

        private void buttonExcel_Click(object sender, EventArgs e)
        {
            SQLBackupandRestore SQLBR = new SQLBackupandRestore();
            TrialBalancePretty TBP = new TrialBalancePretty();

            String lsDealerNum = lookUpEditDealer.EditValue != null ? lookUpEditDealer.EditValue.ToString().Trim() : "" + "%", lsState;

            lsState = (lookUpEditState.EditValue != null) ? lookUpEditState.EditValue.ToString().Trim() + "%" : "%";

            IACDataSetTableAdapters.CUSTOMERTableAdapter CUSTOMERTableAdapter = new IACDataSetTableAdapters.CUSTOMERTableAdapter();
            IACDataSetTableAdapters.ClosedDealerSummaryTableAdapter ClosedDealerSummaryTableAdapter = new IACDataSetTableAdapters.ClosedDealerSummaryTableAdapter();
            IACDataSetTableAdapters.WS_DEALER_TRIAL_BALANCETableAdapter WS_DEALER_TRIAL_BALANCETableAdapter = new IACDataSetTableAdapters.WS_DEALER_TRIAL_BALANCETableAdapter();
            // Moses Newman 05/3/2014 Get rid of SQL Pass Through!
            CUSTOMERTableAdapter.FillByStateDealer(iACDataSet.CUSTOMER, lsState, lsDealerNum);
            ClosedDealerSummaryTableAdapter.Fill(iACDataSet.ClosedDealerSummary, DateTime.Now.Month, DateTime.Now.Year);
            WS_DEALER_TRIAL_BALANCETableAdapter.FillByStateDealer(iACDataSet.WS_DEALER_TRIAL_BALANCE, lsState, lsDealerNum);
            Int32 elapsed = 0;
            if (SQLBR.RunJob("TrialBalance", "Export Trial Balance To EXCEL", false))
            {
                TBP.IACType = "C";
                TBP.CustDealerCount = iACDataSet.CUSTOMER.Rows.Count;
                TBP.DealerCount = iACDataSet.WS_DEALER_TRIAL_BALANCE.Rows.Count;
                TBP.DealerSummaryCount = iACDataSet.ClosedDealerSummary.Rows.Count;
                TBP.FullSourcePath = @"\\Dc-iac\public\AccStuff\mfdata\comp1000\ClosedTrialBalance.xlsx";
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

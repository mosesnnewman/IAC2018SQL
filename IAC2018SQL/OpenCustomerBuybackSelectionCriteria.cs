using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace IAC2021SQL
{
    public partial class frmOpenCustomerBuybackReport : Form
    {

        public frmOpenCustomerBuybackReport()
        {
            InitializeComponent();
        }

        private void frmOpenCustomerBuybackReport_Load(object sender, EventArgs e)
        {
            this.pAYCODETableAdapter.Fill(this.iACDataSet.PAYCODE);
            this.pAYMENTTYPETableAdapter.Fill(this.iACDataSet.PAYMENTTYPE);
            Int32 lnRunMonth = DateTime.Now.Date.Month, lnRunYear = DateTime.Now.Date.Year;

            nullableDateTimePickerStartDate.Value = DateTime.Now.Date;
            nullableDateTimePickerEndDate.Value = DateTime.Now.Date;
            opndlrlistbynumTableAdapter.Fill(iACDataSet.OPNDLRLISTBYNUM);
            bindingSourceDLRLISTBYNUM.AddNew();
            bindingSourceDLRLISTBYNUM.EndEdit();
            iACDataSet.DLRLISTBYNUM.Rows[bindingSourceDLRLISTBYNUM.Position].SetField<String>("OPNDLR_ACC_NO", "   ");
            iACDataSet.DLRLISTBYNUM.Rows[bindingSourceDLRLISTBYNUM.Position].SetField<String>("OPNDLR_NAME", "                  ");
            bindingSourceDLRLISTBYNUM.EndEdit();
            PaymentTypecomboBox.Text = "";
        }
        
        private void buttonPost_Click(object sender, EventArgs e)
        {
            Hide();
            MDIIAC2013 MDImain = (MDIIAC2013)MdiParent;
            MDImain.CreateFormInstance("ReportViewer", false);
            ReportViewer rptViewr = (ReportViewer)MDImain.ActiveMdiChild;

            PrintCustomerBuyback(rptViewr);
            Close();
        }

        private void buttonCancel_Click(Object sender, EventArgs e)
        {
            Close();
        }

        private void PrintCustomerBuyback(ReportViewer rptViewer)
        {
            IACDataSetTableAdapters.OpenCustomerBuybackTableAdapter OpenCustomerBuybackTableAdapter =
                                new IACDataSetTableAdapters.OpenCustomerBuybackTableAdapter();
            IACDataSetTableAdapters.OpenCustomerBuybackSummaryTableAdapter OpenCustomerBuybackSummaryTableAdapter = 
                                new IACDataSetTableAdapters.OpenCustomerBuybackSummaryTableAdapter();
            String  lsType      = PaymentTypetextBox.Text.TrimEnd() + "%", lsCode = PAYCODEcomboBox.Text.TrimEnd() + "%",
                    lsDealer    = comboBoxDealer.Text.TrimEnd() + "%";

            OpenCustomerBuybackTableAdapter.Fill(iACDataSet.OpenCustomerBuyback, ((DateTime)nullableDateTimePickerEndDate.Value).Date, ((DateTime)nullableDateTimePickerStartDate.Value).Date, lsType,lsCode,lsDealer);
            OpenCustomerBuybackSummaryTableAdapter.Fill(iACDataSet.OpenCustomerBuybackSummary, ((DateTime)nullableDateTimePickerEndDate.Value).Date, ((DateTime)nullableDateTimePickerStartDate.Value).Date, lsType, lsCode, lsDealer);
            
            if (iACDataSet.OpenCustomerBuyback.Rows.Count == 0)
                MessageBox.Show("*** Sorry there are no OPEN CUSTOMER HISTORY records for the DATES and /or DEALER you selected!!! ***");
            else
            {
                OpenCustomerBuybackReport myReportObject = new OpenCustomerBuybackReport();
                myReportObject.SetDataSource(iACDataSet);
                myReportObject.SetParameterValue("gdStartDate", ((DateTime)nullableDateTimePickerStartDate.Value).Date);
                myReportObject.SetParameterValue("gdEndDate", ((DateTime)nullableDateTimePickerEndDate.Value).Date);
                myReportObject.SetParameterValue("gsUserID", Program.gsUserID);
                myReportObject.SetParameterValue("gsUserName", Program.gsUserName);
                rptViewer.crystalReportViewer.ReportSource = myReportObject;
                rptViewer.crystalReportViewer.Refresh();
                rptViewer.Show();
            }
        }

        private void PaymentTypecomboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (PaymentTypecomboBox.SelectedIndex >= 0)
            {
                PaymentTypetextBox.Text = iACDataSet.PAYMENTTYPE.Rows[PaymentTypecomboBox.SelectedIndex].Field<String>("TYPE");
            }
            if (PaymentTypetextBox.Text.ToString().ToUpper().TrimEnd() == "W")
                pAYCODETableAdapter.FillByCodeW(iACDataSet.PAYCODE);
            else
                pAYCODETableAdapter.Fill(iACDataSet.PAYCODE);
            if (ActiveControl == PaymentTypecomboBox)
            {
                ActiveControl = CodeTypetextBox;
                CodeTypetextBox.SelectAll();
            }
        }

        private void PaymentTypetextBox_Validated(object sender, EventArgs e)
        {
            if (PaymentTypetextBox.Text.TrimEnd() == "")
                return;
            DataRow FoundRow;
            if (iACDataSet.PAYMENTTYPE.Rows.Count == 0)
                pAYMENTTYPETableAdapter.Fill(iACDataSet.PAYMENTTYPE);
            FoundRow = iACDataSet.PAYMENTTYPE.Rows.Find(PaymentTypetextBox.Text.ToString().TrimEnd());

            if (FoundRow == null)
            {
                if (PaymentTypetextBox.Text.ToString().Trim().Length != 0)
                    MessageBox.Show("Incorrect Payment Type entered. Please respecify.");
                if (Program.gbClosedPaymentAdd || Modal)
                {
                    ActiveControl = PaymentTypecomboBox;
                    PaymentTypecomboBox.SelectAll();
                }
            }
            else
            {
                PaymentTypecomboBox.Text = FoundRow.Field<String>("DESCRIPTION");
                if (PaymentTypetextBox.Text.ToString().ToUpper().TrimEnd() == "W")
                    pAYCODETableAdapter.FillByCodeW(iACDataSet.PAYCODE);
                else
                    pAYCODETableAdapter.Fill(iACDataSet.PAYCODE);
                    if (Modal || Program.gbClosedPaymentAdd)
                    {
                        ActiveControl = CodeTypetextBox;
                        CodeTypetextBox.SelectAll();
                    }
                }

        }

        private void CodeTypetextBox_Validated(object sender, EventArgs e)
        {
            if (iACDataSet.PAYCODE.Rows.Count < 1 || CodeTypetextBox.Text.TrimEnd() == "")
                return;

            DataRow FoundRow;

            if ((CodeTypetextBox.Text == "H" || CodeTypetextBox.Text == "L") && PaymentTypetextBox.Text != "W")
                PaymentTypetextBox.Text = "W";

            if (PaymentTypetextBox.Text == "W")
            {
                switch (CodeTypetextBox.Text.ToString().TrimEnd())
                {
                    case "L":
                    case "H":
                        break;
                    case "C":
                    default:
                        CodeTypetextBox.Text = "H";
                        break;
                }
            }

            if (PaymentTypetextBox.Text == "W" && iACDataSet.PAYCODE.Rows.Count != 2)
                pAYCODETableAdapter.FillByCodeW(iACDataSet.PAYCODE);
            FoundRow = iACDataSet.PAYCODE.Rows.Find(CodeTypetextBox.Text.ToString().TrimEnd());

            if (FoundRow == null)
            {
                if (CodeTypetextBox.Text.ToString().Trim().Length != 0)
                {
                    MessageBox.Show("Sorry no payment code found that matches your selected payment code!");
                    CodeTypetextBox.Text = "";
                    ActiveControl = PAYCODEcomboBox;
                    CodeTypetextBox.SelectAll();
                }
            }
            else
                PAYCODEcomboBox.Text = FoundRow.Field<String>("DESCRIPTION");
        }

        private void PAYCODEcomboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (iACDataSet.PAYCODE.Rows.Count < 1)
                return;
            if (PAYCODEcomboBox.SelectedIndex > -1)
                CodeTypetextBox.Text = iACDataSet.PAYCODE.Rows[PAYCODEcomboBox.SelectedIndex].Field<String>("CODE");
            else
            {
                if (PaymentTypetextBox.Text != "W")
                    if (CodeTypetextBox.Text.TrimEnd() == "")
                        CodeTypetextBox.Text = "N";
                    else
                        if (CodeTypetextBox.Text.TrimEnd() != "L" || CodeTypetextBox.Text.TrimEnd() != "H")
                            CodeTypetextBox.Text = "H";
                CodeTypetextBox_Validated(sender, e);
            }
        }
    }
}

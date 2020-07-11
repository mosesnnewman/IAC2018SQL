using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
// Moses Newman 12/21/2017 Use System.Globilization with parsing instead of Convert function to prevent issues on
// multiple amorts, AFTER the $ and formating is added to Loan Amount or Monthly Payment
using System.Globalization;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using CrystalDecisions.CrystalReports.Engine;
using CrystalDecisions.Shared;

namespace IAC2018SQL
{
    public partial class AmortDialog : Form
    {
        private Amortization myReportObject = new Amortization();
        private Program.AmortRec[] AmortTable;

        private Double lnRegularPay = 0, lnTotal = 0, lnTerm = 0, lnLoanInterest = 0, lnCash = 0;
        private Double lnNominalRate = 0, lnAnnualPercentageRate = 0;
        IACDataSet ReportData = new IACDataSet();
        // Moses Newman 09/12/2013 Grab Actual REAL TILA Loan Interest
        private IACDataSetTableAdapters.TVAPRInfoTableAdapter TVAPRInfoTableAdapter = new IACDataSetTableAdapters.TVAPRInfoTableAdapter();

        public AmortDialog()
        {
            InitializeComponent();
        }


        private void button1_Click(object sender, System.EventArgs e)
        {
            ReportViewer rptViewr = new ReportViewer();
            IACDataSetTableAdapters.AmortTempTableAdapter AmortTempTableAdapter = new IACDataSetTableAdapters.AmortTempTableAdapter();

            AmortTempTableAdapter.FillByCustomer(ReportData.AmortTemp,"99-" + Program.gsUserID);

            myReportObject.SetDataSource(ReportData);
           
            myReportObject.SetParameterValue("CompoundPeriod", "Daily Exact");
            myReportObject.SetParameterValue("NominalRate", lnNominalRate);
            myReportObject.SetParameterValue("AnnualPercentageRate", lnAnnualPercentageRate);
            myReportObject.SetParameterValue("Term", lnTerm);
            myReportObject.SetParameterValue("AmountBorrowed", lnCash);
            myReportObject.SetParameterValue("TotalInterest", lnLoanInterest);
            myReportObject.SetParameterValue("FirstPaymentDate", (DateTime)txtFirstPayment.Value);
            myReportObject.SetParameterValue("ContractDate", (DateTime)dateTimePickerContractDate.Value);
            myReportObject.SetParameterValue("gsUserID", "XXX");
            myReportObject.SetParameterValue("gsUserName", "Stand Alone");
            myReportObject.SetParameterValue("CustomerPrint", false);
            myReportObject.SetParameterValue("gsCustomer", "99-" + Program.gsUserID);


            rptViewr.crystalReportViewer.ReportSource = myReportObject;
            rptViewr.crystalReportViewer.Refresh();
            rptViewr.Show();
        }

        private void btnCalc_Click(object sender, EventArgs e)
        {
            // Moses Newman 12/21/2017 Use System.Globilization with parsing instead of Convert function to prevent issues on
            // multiple amorts, AFTER the $ and formating is added to Loan Amount or Monthly Payment
            lnNominalRate = (txtNominalRate.Text.ToString().TrimEnd() != "") ? Double.Parse(txtNominalRate.Text, CultureInfo.CreateSpecificCulture("en-US")) / 100 : 0;
            lnTerm = (txtTerm.Text.ToString().TrimEnd() != "") ? Convert.ToDouble(txtTerm.Text.ToString()) : 0;
            lnCash = (txtLoanAmount.Text.ToString().TrimEnd() != "") ? Double.Parse(txtLoanAmount.Text, NumberStyles.Currency, CultureInfo.CreateSpecificCulture("en-US")) : 0;
            lnRegularPay = (txtMonthlyPayment.Text.ToString().TrimEnd() != "") ? Double.Parse(txtMonthlyPayment.Text, NumberStyles.Currency, CultureInfo.CreateSpecificCulture("en-US")) : 0;

            AmortTable = new Program.AmortRec[Convert.ToInt32(lnTerm)];

            if (lnNominalRate == 0 && lnRegularPay == 0)
            {
                MessageBox.Show("You MUST supply either the Nominal Rate, or Weekly Payment or BOTH!", "Missing Data Error");
                ActiveControl = txtNominalRate;
                txtNominalRate.SelectAll();
                return;
            }
            if (lnCash == 0)
            {
                MessageBox.Show("You MUST supply the loan amount!", "Missing Data Error");
                ActiveControl = txtLoanAmount;
                txtLoanAmount.SelectAll();
                return;
            }
            if (lnTerm == 0)
            {
                MessageBox.Show("You MUST supply the term of the loan in months", "Missing Data Error");
                ActiveControl = txtTerm;
                txtTerm.SelectAll();
                return;
            }


            String lsErrorMessage = "DAmort Table Created!";
            // Moses Newman 09/12/2013 No more precalculated loans.
            Program.TVAmortize(dateTimePickerContractDate.Value, txtFirstPayment.Value, ref lnCash, ref lnTerm, ref lnNominalRate, ref lnRegularPay, ref lsErrorMessage, ref AmortTable, false, "99-" + Program.gsUserID, true);
            TVAPRInfoTableAdapter.Fill(ReportData.TVAPRInfo, "99-" + Program.gsUserID);
            if (ReportData.TVAPRInfo.Rows.Count > 0)
            {
                lnAnnualPercentageRate = (Double)ReportData.TVAPRInfo.Rows[0].Field<Decimal>("APR");
                lnCash = (Double)ReportData.TVAPRInfo.Rows[0].Field<Decimal>("AmountFinanced");
                lnLoanInterest = (Double)ReportData.TVAPRInfo.Rows[0].Field<Decimal>("FinanceCharge");
                lnTotal = (Double)ReportData.TVAPRInfo.Rows[0].Field<Decimal>("TotalofPayments");
            }
            txtLoanAmount.Text = lnCash.ToString("C", new System.Globalization.CultureInfo("en-US"));
            txtNominalRate.Text = (lnNominalRate * 100).ToString("##.###", new System.Globalization.CultureInfo(""));
            txtMonthlyPayment.Text = (lnRegularPay).ToString("C", new System.Globalization.CultureInfo("en-US"));
            if (lnRegularPay != 0 && lnTerm != 0)
            {
                txtTotalPayment.Text = lnTotal.ToString("C", new System.Globalization.CultureInfo("en-US"));
                txtTotalInterest.Text = lnLoanInterest.ToString("C", new System.Globalization.CultureInfo("en-US"));
            }

            //lnAnnualPercentageRate = Math.Round(Math.Pow((1 + (lnNominalRate / 12)), 12), 8) - 1;
            btnPrint.Enabled = true;
            buttonPrintScreen.Enabled = true;
            btnCalc.Enabled = false;

        }

        private void AmortDialog_Load(object sender, EventArgs e)
        {
            btnPrint.Enabled = false;
            buttonPrintScreen.Enabled = false;
            PerformAutoScale();
        }

        //This is the Print Screen Button
        private void button1_Click_1(object sender, EventArgs e)
        {
            MailMergeComponents MM = new MailMergeComponents();
            Image bit = new Bitmap(Screen.PrimaryScreen.WorkingArea.Width, Screen.PrimaryScreen.WorkingArea.Height);


            Graphics gs = Graphics.FromImage(bit);
            String lsPath = Program.GsDataPath + @"\MailMerge\TEMPSCRN.JPG";

            gs.CopyFromScreen(

            new Point(0, 0), new Point(0, 0), bit.Size);
            MM.SaveJpeg(lsPath, bit, 100);

            MM.ScrnPrnt(lsPath);
            bit.Dispose();
            MM = null;
        }

        private void txtLoanAmount_TextChanged(object sender, EventArgs e)
        {   
            // Moses Newman 03/23/2012 allow recaculation!
            if (!btnCalc.Enabled)
            {
                btnCalc.Enabled = true;
                lnRegularPay = 0;
                txtMonthlyPayment.Text = "";
            }
        }

        private void txtTerm_TextChanged(object sender, EventArgs e)
        {
            // Moses Newman 03/23/2012 allow recaculation!
            if (!btnCalc.Enabled)
            {
                btnCalc.Enabled = true;
                lnRegularPay = 0;
                txtMonthlyPayment.Text = "";
            }
        }

        private void txtAPR_TextChanged(object sender, EventArgs e)
        {
            // Moses Newman 03/23/2012 allow recaculation!
            if (!btnCalc.Enabled)
            {
                btnCalc.Enabled = true;
                lnRegularPay = 0;
                txtMonthlyPayment.Text = "";
            }
        }

        private void txtFirstPayment_ValueChanged(object sender, EventArgs e)
        {
            // Moses Newman 03/23/2012 allow recaculation!
            if (!btnCalc.Enabled)
            {
                btnCalc.Enabled = true;
                lnRegularPay = 0;
                txtMonthlyPayment.Text = "";
            }
        }

        private void txtMonthlyPayment_TextChanged(object sender, EventArgs e)
        {
            // Moses Newman 03/23/2012 allow recaculation!
            if (!btnCalc.Enabled)
                btnCalc.Enabled = true;
        }

        // Moses Newman 12/21/2017 Use System.Globilization with parsing instead of Convert function to prevent issues on
        // multiple amorts, AFTER the $ and formating is added to Loan Amount or Monthly Payment
        private void txtLoanAmount_Validated(object sender, EventArgs e)
        {
            if (txtLoanAmount.Text == "")
                return;
            txtLoanAmount.Text = Double.Parse(txtLoanAmount.Text, NumberStyles.Currency,
                CultureInfo.CreateSpecificCulture("en-US")).ToString("C",CultureInfo.CreateSpecificCulture("en-US"));

        }

        // Moses Newman 12/21/2017 Use System.Globilization with parsing instead of Convert function to prevent issues on
        // multiple amorts, AFTER the $ and formating is added to Loan Amount or Monthly Payment
        private void txtMonthlyPayment_Validated(object sender, EventArgs e)
        {
            if (txtMonthlyPayment.Text == "")
                return;
            txtMonthlyPayment.Text = Double.Parse(txtMonthlyPayment.Text, NumberStyles.Currency,
                CultureInfo.CreateSpecificCulture("en-US")).ToString("C", CultureInfo.CreateSpecificCulture("en-US"));
        }
    }  
}
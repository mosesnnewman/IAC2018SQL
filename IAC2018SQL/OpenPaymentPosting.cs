using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Linq;
using System.Windows.Forms;

namespace IAC2021SQL
{
    class OpenPaymentPosting:IDisposable
    {
        private Int32  lnNoPay = 0, lnTodayDiff = 0, lnPTDiff = 0, lnTermRem = 0, lnCheckExtension = 0;
                     
        private Double lnCustUEI = 0, lnPaidInt = 0, lnBalance = 0,
                       lnCustOP = 0, lnCustExt = 0, lnMasterExt = 0, lnMasterSundry = 0,
                       lnMasterNP = 0, lnMasterNPNP = 0, lnMasterOloan = 0, lnMasterOP = 0,
                       lnMasterUEI = 0, lnMasterInterest = 0, lnMasterDiscount = 0, lnMasterAmortInterest = 0, 
                       lnMasterAmortDiscount = 0, lnIntAdj = 0;

        private Decimal lnArrears = 0, lnHoldContractStatus = 0, lnCheckFinance = 0, lnHoldBucket = 0;

        private Decimal[] lnFinanceBucket = new Decimal[11], lnBucketTable = new Decimal[11]; // We are ignoring element 0 

        private BindingSource OPNCUSTBindingSource = new BindingSource();
        private BindingSource OPNHCUSTBindingSource = new BindingSource();
        private BindingSource OPNDEALRBindingSource = new BindingSource();
        private BindingSource OPNHDEALBindingSource = new BindingSource();
        private BindingSource MASTERBindingSource = new BindingSource();
        private BindingSource MASTHISTBindingSource = new BindingSource();
        private BindingSource OPN_WS_DEALER_PAYBindingSource = new BindingSource();
        private BindingSource CUSTHISTBindingSource = new BindingSource();
        private BindingSource DEALHISTBindingSource = new BindingSource();

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }


        //Start of Open End Payment Processing
        public void NewOpenPaymenPosting(ref IACDataSet OPNPAYPostDataSet, ref BackgroundWorker worker, Boolean Post = false)
        {
            IACDataSetTableAdapters.OPNCUSTTableAdapter OPNCUSTTableAdapter = new IACDataSetTableAdapters.OPNCUSTTableAdapter();
            IACDataSetTableAdapters.OPNPAYTableAdapter OPNPAYTableAdapter = new IACDataSetTableAdapters.OPNPAYTableAdapter();
            IACDataSetTableAdapters.MasterTotalTempTableAdapter MasterTotalTempTableAdapter = new IACDataSetTableAdapters.MasterTotalTempTableAdapter();
            IACDataSetTableAdapters.OPNNOTTableAdapter OPNNOTTableAdapter = new IACDataSetTableAdapters.OPNNOTTableAdapter();


            OPNCUSTBindingSource.DataSource = OPNPAYPostDataSet.OPNCUST;

            Int32 OPNCUSTPos = 0;

            OPNPAYTableAdapter.FillByAll(OPNPAYPostDataSet.OPNPAY);
            if (OPNPAYPostDataSet.OPNPAY.Rows.Count == 0)
            {
                MessageBox.Show("No new OPNPAYs to post!", "New OPNPAYs Posting Error");
                return;
            }
            OPNCUSTTableAdapter.FillByUnPostedPayments(OPNPAYPostDataSet.OPNCUST);
            worker.ReportProgress(2);
            for (int OPNPAYPos = 0; OPNPAYPos < OPNPAYPostDataSet.OPNPAY.Rows.Count; OPNPAYPos++)
            {
                OPNCUSTPos = OPNCUSTBindingSource.Find("CUSTOMER_NO", OPNPAYPostDataSet.OPNPAY.Rows[OPNPAYPos].Field<String>("PAYMENT_CUSTOMER"));
                OPNPAYProcessOpenCUST(OPNPAYPos, OPNCUSTPos, ref OPNPAYPostDataSet, ref worker);
                worker.ReportProgress(((OPNPAYPos + 1) / OPNPAYPostDataSet.OPNPAY.Rows.Count) * 8);
            }
            OpenOPNDEALRPost(ref OPNPAYPostDataSet, ref worker);
            OpenMasterPost(ref OPNPAYPostDataSet, ref worker);
            OpenMASTHISTPost(ref OPNPAYPostDataSet, ref worker);
            MasterTotalTempTableAdapter.DeleteAll();
            MasterTotalTempTableAdapter.Insert(Convert.ToDecimal(lnMasterNP), Convert.ToDecimal(lnMasterUEI), Convert.ToDecimal(lnMasterNPNP),
                                               Convert.ToDecimal(lnMasterOloan), Convert.ToDecimal(lnMasterOP), Convert.ToDecimal(lnMasterExt),
                                               Convert.ToDecimal(lnMasterSundry), 0);

            worker.ReportProgress(56);
            if (Post)
            {
                OpenPaymentWriteAllData(OPNPAYPostDataSet, ref worker);
                OPNNOTTableAdapter.DeleteNonArrears();
                OPNPAYTableAdapter.DeleteQueryAll();
            }
            worker.ReportProgress(100);
        }

        protected virtual void Dispose(bool disposing)
        {
            if (disposing)
            {
                // free managed resources
                if (OPNHCUSTBindingSource != null)
                {
                    OPNHCUSTBindingSource.Dispose();
                    OPNHCUSTBindingSource = null;
                }
                if (OPNCUSTBindingSource != null)
                {
                    OPNCUSTBindingSource.Dispose();
                    OPNCUSTBindingSource = null;
                }
                if (OPNDEALRBindingSource != null)
                {
                    OPNDEALRBindingSource.Dispose();
                    OPNDEALRBindingSource = null;
                }
                if (OPNHDEALBindingSource != null)
                {
                    OPNHDEALBindingSource.Dispose();
                    OPNHDEALBindingSource = null;
                }
                if (MASTERBindingSource != null)
                {
                    MASTERBindingSource.Dispose();
                    MASTERBindingSource = null;
                }
                if (MASTHISTBindingSource != null)
                {
                    MASTHISTBindingSource.Dispose();
                    MASTHISTBindingSource = null;
                }
                if (OPN_WS_DEALER_PAYBindingSource != null)
                {
                    OPN_WS_DEALER_PAYBindingSource.Dispose();
                    OPN_WS_DEALER_PAYBindingSource = null;
                }
                if (CUSTHISTBindingSource != null)
                {
                    CUSTHISTBindingSource.Dispose();
                    CUSTHISTBindingSource = null;
                }
                if (DEALHISTBindingSource != null)
                {
                    DEALHISTBindingSource.Dispose();
                    DEALHISTBindingSource = null;
                }
            }
        }

        void OpenPaymentWriteAllData(IACDataSet OPNPAYPostDataSet, ref BackgroundWorker worker)
        {
            OpenPaymentWriteOPNCUSTChanges(ref OPNPAYPostDataSet, ref worker);
            OpenPaymentWriteOPNHCUSTChanges(ref OPNPAYPostDataSet, ref worker);
            OpenPaymentWriteOPNDEALRChanges(ref OPNPAYPostDataSet, ref worker);
            OpenPaymentWriteOPNHDEALChanges(ref OPNPAYPostDataSet, ref worker);
            OpenPaymentWriteMASTerChanges(ref OPNPAYPostDataSet, ref worker);
            OpenPaymentWriteMASTHistChanges(ref OPNPAYPostDataSet, ref worker);
        }


        void OPNPAYProcessOpenCUST(int OPNPAYPos, int OPNCUSTPos, ref IACDataSet OPNPAYPostDataSet, ref BackgroundWorker worker)
        {
            IACDataSetTableAdapters.OPNCUSTTableAdapter OPNCUSTTableAdapter = new IACDataSetTableAdapters.OPNCUSTTableAdapter();
            IACDataSetTableAdapters.OPNHCUSTTableAdapter OPNOPNHCUSTTableAdapter = new IACDataSetTableAdapters.OPNHCUSTTableAdapter();
            IACDataSetTableAdapters.OPNPAYTableAdapter OPNPAYTableAdapter = new IACDataSetTableAdapters.OPNPAYTableAdapter();
            IACDataSetTableAdapters.OpenPaymentDistributionTableAdapter OpenPaymentDistributionTableAdapter = new IACDataSetTableAdapters.OpenPaymentDistributionTableAdapter();

            if (OPNPAYPostDataSet.OPNPAY.Rows.Count == 0)
                return;

            lnBalance = 0;
            lnTermRem = 0;
            lnCustOP = 0;
            lnCustExt = 0;
            lnNoPay = 0;

            if (OPNPAYPostDataSet.OPNPAY.Rows[OPNPAYPos].Field<String>("PAYMENT_TYPE") == "E")
            {
                //Updates Sundry Income Only
                lnBalance = 0;
                lnCustExt = Convert.ToDouble(OPNPAYPostDataSet.OPNPAY.Rows[OPNPAYPos].Field<Decimal>("PAYMENT_AMOUNT_RCV"));
                if (OPNPAYPostDataSet.OPNPAY.Rows[OPNPAYPos].Field<Decimal>("PAYMENT_AMOUNT_RCV") > 0)
                {
                    lnMasterExt += lnCustExt;
                    lnMasterExt = Math.Round(lnMasterExt, 2);
                    lnMasterSundry += lnCustExt;
                    lnMasterSundry = Math.Round(lnMasterSundry, 2);
                    lnMasterNP += lnCustExt;
                    lnMasterNP = Math.Round(lnMasterNP, 2);
                }
                lnNoPay = (OPNPAYPostDataSet.OPNPAY.Rows[OPNPAYPos].Field<Int32>("PAYMENT_THRU_UD"));
                // Add Dummy Payment Distribution Record even if Extension
                OpenPaymentDistributionTableAdapter.Delete(OPNPAYPostDataSet.OPNPAY.Rows[OPNPAYPos].Field<String>("PAYMENT_CUSTOMER"), OPNPAYPostDataSet.OPNPAY.Rows[OPNPAYPos].Field<DateTime>("PAYMENT_DATE"));
                OpenPaymentDistributionTableAdapter.Insert(OPNPAYPostDataSet.OPNPAY.Rows[OPNPAYPos].Field<String>("PAYMENT_CUSTOMER"), OPNPAYPostDataSet.OPNPAY.Rows[OPNPAYPos].Field<DateTime>("PAYMENT_DATE"), 0, 0, 0, 0, 0, 0);

                if (OPNPAYPostDataSet.OPNCUST.Rows[OPNCUSTPos].Field<Int32>("CUSTOMER_STATUS_NO") > 0)
                    OPNPAYPostDataSet.OPNCUST.Rows[OPNCUSTPos].SetField<Int32>("CUSTOMER_STATUS_NO", OPNPAYPostDataSet.OPNCUST.Rows[OPNCUSTPos].Field<Int32>("CUSTOMER_STATUS_NO") - OPNPAYPostDataSet.OPNPAY.Rows[OPNPAYPos].Field<Int32>("PAYMENT_THRU_UD"));
                OPNPAYPostDataSet.OPNCUST.Rows[OPNCUSTPos].SetField<String>("CUSTOMER_PAY_REM_1", "EXT");
                // This will compute CUSTOMER_CONTRACT_STATUS
                // 12/7/2011 Moses Newman replaced hard code with call to OpenNewContractStatus
                OpenNewContractStatus(OPNCUSTPos,ref OPNPAYPostDataSet);
                // End of 12/7/2011 Mod
                ExtensionBuckets(OPNPAYPos, OPNCUSTPos, ref OPNPAYPostDataSet);
                OpenMoveOPNPAYtoOPNHCUST(OPNPAYPos, OPNCUSTPos, ref OPNPAYPostDataSet, ref worker);
            }
            else
                OpenProcessOPNPAY(OPNPAYPos, OPNCUSTPos, ref OPNPAYPostDataSet, ref worker);
        }

        void OpenProcessOPNPAY(Int32 OPNPAYPos, Int32 OPNCUSTPos, ref IACDataSet OPNPAYDataSet, ref BackgroundWorker worker)
        {
            String lsPaidThru = "0000";
            Int32 lnFirstPayYY = 0, lnFirstPayMM = 0, lnPTYY = 0, lnPTMM = 0, lnPTNOYR = 0, lnRDFTodayPT = 0, lnRDFPT = 0;

            lnFirstPayYY = Convert.ToInt32(OPNPAYDataSet.OPNCUST.Rows[OPNCUSTPos].Field<DateTime>("CUSTOMER_INIT_DATE").Year.ToString().Substring(2, 2));
            lnFirstPayMM = Convert.ToInt32(OPNPAYDataSet.OPNCUST.Rows[OPNCUSTPos].Field<DateTime>("CUSTOMER_INIT_DATE").Month);
            if (OPNPAYDataSet.OPNCUST.Rows[OPNCUSTPos].Field<String>("CUSTOMER_PAID_THRU").Length == 3)
                OPNPAYDataSet.OPNCUST.Rows[OPNCUSTPos].SetField<String>("CUSTOMER_PAID_THRU", '0' + OPNPAYDataSet.OPNCUST.Rows[OPNCUSTPos].Field<String>("CUSTOMER_PAID_THRU"));
            lsPaidThru = OPNPAYDataSet.OPNCUST.Rows[OPNCUSTPos].Field<String>("CUSTOMER_PAID_THRU");
            lnPTYY = Convert.ToInt32(lsPaidThru.Substring(2, 2));
            lnPTMM = Convert.ToInt32(lsPaidThru.Substring(0, 2));
            lnPTNOYR = Convert.ToInt32(DateTime.Today.Year.ToString().Substring(2, 2)) - lnPTYY;
            if (lnPTNOYR < 0)
            {
                lnPTYY += lnPTNOYR;
                lnPTMM += (lnPTNOYR - 1) * 12;
            }
            else
            {
                lnPTYY -= lnPTNOYR;
                lnPTMM += lnPTNOYR * 12;
            }
            if (OPNPAYDataSet.OPNCUST.Rows[OPNCUSTPos].Field<Nullable<DateTime>>("CUSTOMER_LAST_PAYMENT_DATE") != null)
            {
                lnRDFPT = ((OPNPAYDataSet.OPNCUST.Rows[OPNCUSTPos].Field<DateTime>("CUSTOMER_LAST_PAYMENT_DATE").Year) * 100) + lnPTMM;
                lnRDFTodayPT = (DateTime.Today.Year * 100) + DateTime.Today.Month;
                lnPTDiff = lnRDFTodayPT - lnRDFPT;
            }
            else
                lnPTDiff = 0;

            if (OPNPAYDataSet.OPNPAY.Rows[OPNPAYPos].Field<String>("PAYMENT_TYPE") == "W" && OPNPAYDataSet.OPNPAY.Rows[OPNPAYPos].Field<String>("PAYMENT_CODE_2") == "L")
            {
                OPNPAYDataSet.OPNCUST.Rows[OPNCUSTPos].SetField<Decimal>("CUSTOMER_LATE_CHARGE_BAL", OPNPAYDataSet.OPNCUST.Rows[OPNCUSTPos].Field<Decimal>("CUSTOMER_LATE_CHARGE_BAL") - OPNPAYDataSet.OPNPAY.Rows[OPNPAYPos].Field<Decimal>("PAYMENT_AMOUNT_RCV"));
                OPNPAYDataSet.OPNCUST.Rows[OPNCUSTPos].SetField<Decimal>("CUSTOMER_LATE_CHARGE", OPNPAYDataSet.OPNCUST.Rows[OPNCUSTPos].Field<Decimal>("CUSTOMER_LATE_CHARGE") - OPNPAYDataSet.OPNPAY.Rows[OPNPAYPos].Field<Decimal>("PAYMENT_AMOUNT_RCV"));
                if (OPNPAYDataSet.OPNCUST.Rows[OPNCUSTPos].Field<Decimal>("CUSTOMER_LATE_CHARGE_BAL") < 0)
                    OPNPAYDataSet.OPNCUST.Rows[OPNCUSTPos].SetField<Decimal>("CUSTOMER_LATE_CHARGE_BAL", 0);
                if (OPNPAYDataSet.OPNCUST.Rows[OPNCUSTPos].Field<Decimal>("CUSTOMER_LATE_CHARGE") < 0)
                    OPNPAYDataSet.OPNCUST.Rows[OPNCUSTPos].SetField<Decimal>("CUSTOMER_LATE_CHARGE", 0);
            }
            // Update regardless of balance due
            lnBalance = Convert.ToDouble(OPNPAYDataSet.OPNPAY.Rows[OPNPAYPos].Field<Decimal>("PAYMENT_AMOUNT_RCV"));

            if (lnBalance > Convert.ToDouble(OPNPAYDataSet.OPNCUST.Rows[OPNCUSTPos].Field<Decimal>("CUSTOMER_BALANCE")))
                OpenOverPayment(OPNCUSTPos, ref OPNPAYDataSet);

            if (OPNPAYDataSet.OPNCUST.Rows[OPNCUSTPos].Field<Decimal>("CUSTOMER_BALANCE") != 0)
                OPNPAYDataSet.OPNCUST.Rows[OPNCUSTPos].SetField<Decimal>("CUSTOMER_BALANCE", OPNPAYDataSet.OPNCUST.Rows[OPNCUSTPos].Field<Decimal>("CUSTOMER_BALANCE") - OPNPAYDataSet.OPNPAY.Rows[OPNPAYPos].Field<Decimal>("PAYMENT_AMOUNT_RCV"));
            if (OPNPAYDataSet.OPNPAY.Rows[OPNPAYPos].Field<String>("PAYMENT_TYPE") == "N")
                OPNPAYDataSet.OPNCUST.Rows[OPNCUSTPos].SetField<Decimal>("CUSTOMER_TOTAL_ISF", OPNPAYDataSet.OPNCUST.Rows[OPNCUSTPos].Field<Decimal>("CUSTOMER_TOTAL_ISF") + OPNPAYDataSet.OPNPAY.Rows[OPNPAYPos].Field<Decimal>("PAYMENT_AMOUNT_RCV"));
            else
                if (OPNPAYDataSet.OPNPAY.Rows[OPNPAYPos].Field<String>("PAYMENT_TYPE") != "W" && OPNPAYDataSet.OPNPAY.Rows[OPNPAYPos].Field<String>("PAYMENT_CODE_2") != "L")
                    OPNPAYDataSet.OPNCUST.Rows[OPNCUSTPos].SetField<Decimal>("CUSTOMER_TOTAL_PAYMENTS", OPNPAYDataSet.OPNCUST.Rows[OPNCUSTPos].Field<Decimal>("CUSTOMER_TOTAL_PAYMENTS") + OPNPAYDataSet.OPNPAY.Rows[OPNPAYPos].Field<Decimal>("PAYMENT_AMOUNT_RCV"));

            //This will compute the contract status
            if (OPNPAYDataSet.OPNPAY.Rows[OPNPAYPos].Field<String>("PAYMENT_TYPE") == "W" && OPNPAYDataSet.OPNPAY.Rows[OPNPAYPos].Field<String>("PAYMENT_CODE_2") == "L")
            {
                OPNPAYDataSet.OPNCUST.Rows[OPNCUSTPos].SetField<Decimal>("CUSTOMER_TOTAL_LATE_CHARGE", OPNPAYDataSet.OPNCUST.Rows[OPNCUSTPos].Field<Decimal>("CUSTOMER_TOTAL_LATE_CHARGE") - OPNPAYDataSet.OPNPAY.Rows[OPNPAYPos].Field<Decimal>("PAYMENT_AMOUNT_RCV"));
                if (OPNPAYDataSet.OPNCUST.Rows[OPNCUSTPos].Field<Decimal>("CUSTOMER_TOTAL_LATE_CHARGE") < 0)
                    OPNPAYDataSet.OPNCUST.Rows[OPNCUSTPos].SetField<Decimal>("CUSTOMER_TOTAL_LATE_CHARGE", 0);
            }
            OPNPAYDataSet.OPNCUST.Rows[OPNCUSTPos].SetField<Decimal>("CUSTOMER_CONTRACT_STATUS",
                OPNPAYDataSet.OPNCUST.Rows[OPNCUSTPos].Field<Decimal>("CUSTOMER_TOTAL_PAYMENTS") -
                (((OPNPAYDataSet.OPNCUST.Rows[OPNCUSTPos].Field<Decimal>("CUSTOMER_REG_AMOUNT1") * OPNPAYDataSet.OPNCUST.Rows[OPNCUSTPos].Field<Int32>("CUSTOMER_STAT1")) +
                  (OPNPAYDataSet.OPNCUST.Rows[OPNCUSTPos].Field<Decimal>("CUSTOMER_REG_AMOUNT2") * OPNPAYDataSet.OPNCUST.Rows[OPNCUSTPos].Field<Int32>("CUSTOMER_STAT2")) +
                  (OPNPAYDataSet.OPNCUST.Rows[OPNCUSTPos].Field<Decimal>("CUSTOMER_REGULAR_AMOUNT") * OPNPAYDataSet.OPNCUST.Rows[OPNCUSTPos].Field<Int32>("CUSTOMER_STATUS_NO"))) +
                  OPNPAYDataSet.OPNCUST.Rows[OPNCUSTPos].Field<Decimal>("CUSTOMER_TOTAL_LATE_CHARGE")));

            if (OPNPAYDataSet.OPNCUST.Rows[OPNCUSTPos].Field<Decimal>("CUSTOMER_CONTRACT_STATUS") < 0)
                if (OPNPAYDataSet.OPNCUST.Rows[OPNCUSTPos].Field<Decimal>("CUSTOMER_BALANCE") < (OPNPAYDataSet.OPNCUST.Rows[OPNCUSTPos].Field<Decimal>("CUSTOMER_CONTRACT_STATUS") * -1))
                    OPNPAYDataSet.OPNCUST.Rows[OPNCUSTPos].SetField<Decimal>("CUSTOMER_CONTRACT_STATUS", (OPNPAYDataSet.OPNCUST.Rows[OPNCUSTPos].Field<Decimal>("CUSTOMER_BALANCE") * -1));
            if (OPNPAYDataSet.OPNCUST.Rows[OPNCUSTPos].Field<Decimal>("CUSTOMER_CONTRACT_STATUS") != 0)
                lnHoldContractStatus = OPNPAYDataSet.OPNCUST.Rows[OPNCUSTPos].Field<Decimal>("CUSTOMER_CONTRACT_STATUS");
            else
                lnHoldContractStatus = 0;
            if (OPNPAYDataSet.OPNCUST.Rows[OPNCUSTPos].Field<Decimal>("CUSTOMER_BALANCE") == 0)
                OpenCloseOut(OPNCUSTPos, ref OPNPAYDataSet, ref worker);
            // Now decide what type of finance bucket handling
            lnNoPay = 0;
            switch (OPNPAYDataSet.OPNPAY.Rows[OPNPAYPos].Field<String>("PAYMENT_TYPE"))
            {
                case "N":
                    break;
                case "W":
                    if (OPNPAYDataSet.OPNPAY.Rows[OPNPAYPos].Field<String>("PAYMENT_CODE_2") == "L")
                        break;
                    else
                        if (OPNPAYDataSet.OPNPAY.Rows[OPNPAYPos].Field<String>("PAYMENT_CODE_2") == "H" &&
                            OPNPAYDataSet.OPNPAY.Rows[OPNPAYPos].Field<Decimal>("PAYMENT_AMOUNT_RCV") < 0)
                        {
                            ISFBuckets(OPNPAYPos, OPNCUSTPos, ref OPNPAYDataSet);
                            break;
                        }
                        else
                            goto default;
                case "A":
                    if (OPNPAYDataSet.OPNPAY.Rows[OPNPAYPos].Field<Decimal>("PAYMENT_AMOUNT_RCV") < 0)
                    {
                        ISFBuckets(OPNPAYPos, OPNCUSTPos, ref OPNPAYDataSet);
                        break;
                    }
                    else
                        goto default;
                case "I":
                    ISFBuckets(OPNPAYPos, OPNCUSTPos, ref OPNPAYDataSet);
                    break;
                default:
                    CheckFinanceBuckets(OPNPAYPos, OPNCUSTPos, ref OPNPAYDataSet);
                    BucketTable();
                    break;
            }
            if (lnNoPay == 0 &&
               (OPNPAYDataSet.OPNPAY.Rows[OPNPAYPos].Field<String>("PAYMENT_TYPE") == "R" ||
                OPNPAYDataSet.OPNPAY.Rows[OPNPAYPos].Field<String>("PAYMENT_TYPE") == "V" ||
                OPNPAYDataSet.OPNPAY.Rows[OPNPAYPos].Field<String>("PAYMENT_TYPE") == "P" ||
                OPNPAYDataSet.OPNPAY.Rows[OPNPAYPos].Field<String>("PAYMENT_TYPE") == "S" ||
                OPNPAYDataSet.OPNPAY.Rows[OPNPAYPos].Field<String>("PAYMENT_TYPE") == "M" ||
                OPNPAYDataSet.OPNPAY.Rows[OPNPAYPos].Field<String>("PAYMENT_TYPE") == "H"))
                if (OPNPAYDataSet.OPNPAY.Rows[OPNPAYPos].Field<Decimal>("PAYMENT_AMOUNT_RCV") >= OPNPAYDataSet.OPNCUST.Rows[OPNCUSTPos].Field<Decimal>("CUSTOMER_REGULAR_AMOUNT"))
                    lnNoPay = 1;
            OPNPAYDataSet.OPNCUST.Rows[OPNCUSTPos].SetField<Int32>("CUSTOMER_NO_OF_PAYMENTS_MADE", OPNPAYDataSet.OPNCUST.Rows[OPNCUSTPos].Field<Int32>("CUSTOMER_NO_OF_PAYMENTS_MADE") + lnNoPay);
            if (lnNoPay == 0)
                if (OPNPAYDataSet.OPNPAY.Rows[OPNPAYPos].Field<Decimal>("PAYMENT_AMOUNT_RCV") >= OPNPAYDataSet.OPNCUST.Rows[OPNCUSTPos].Field<Decimal>("CUSTOMER_REGULAR_AMOUNT"))
                    OPNPAYDataSet.OPNCUST.Rows[OPNCUSTPos].SetField<Int32>("CUSTOMER_NO_OF_PAYMENTS_MADE", OPNPAYDataSet.OPNCUST.Rows[OPNCUSTPos].Field<Int32>("CUSTOMER_NO_OF_PAYMENTS_MADE") + 1);
            if (OPNPAYDataSet.OPNCUST.Rows[OPNCUSTPos].Field<Decimal>("CUSTOMER_BALANCE") == 0)
            {
                lnTermRem = 0;
                OPNPAYDataSet.OPNCUST.Rows[OPNCUSTPos].SetField<String>("CUSTOMER_ACT_STAT", "I");
                OPNPAYDataSet.OPNCUST.Rows[OPNCUSTPos].SetField<String>("CUSTOMER_PAY_REM_1", "PAID");
            }
            else
            {
                // Moses Newman 09/18/2013 fix Null Number of Payments made and or TERM
                if (OPNPAYDataSet.OPNCUST.Rows[OPNCUSTPos].Field<Nullable<Int32>>("CUSTOMER_NO_OF_PAYMENTS_MADE") == null)
                    OPNPAYDataSet.OPNCUST.Rows[OPNCUSTPos].SetField<Int32>("CUSTOMER_NO_OF_PAYMENTS_MADE", 0);
                if (OPNPAYDataSet.OPNCUST.Rows[OPNCUSTPos].Field<Nullable<Int32>>("CUSTOMER_TERM") == null)
                    OPNPAYDataSet.OPNCUST.Rows[OPNCUSTPos].SetField<Int32>("CUSTOMER_TERM", 0);
                lnTermRem = OPNPAYDataSet.OPNCUST.Rows[OPNCUSTPos].Field<Int32>("CUSTOMER_TERM") - OPNPAYDataSet.OPNCUST.Rows[OPNCUSTPos].Field<Int32>("CUSTOMER_NO_OF_PAYMENTS_MADE");
                if (lnTermRem < 0)
                    lnTermRem = 0;
            }
            OPNPAYDataSet.OPNCUST.Rows[OPNCUSTPos].SetField<Int32>("CUSTOMER_PAY_REM_2", lnTermRem);

            //Accumulate fiekds for updating at end
            if (OPNPAYDataSet.OPNCUST.Rows[OPNCUSTPos].Field<String>("CUSTOMER_ACT_STAT") != "R")
            {
                OpenSumOPNDEALRTotals(OPNPAYPos, OPNCUSTPos, ref OPNPAYDataSet, ref worker);
                OpenAccumIOL(OPNPAYPos, ref OPNPAYDataSet, ref worker);
            }
            OpenMoveOPNPAYtoOPNHCUST(OPNPAYPos, OPNCUSTPos, ref OPNPAYDataSet, ref worker);
        }

        void OpenMoveOPNPAYtoOPNHCUST(int OPNPAYPos, int OPNCUSTPos, ref IACDataSet OPNPAYDataSet, ref BackgroundWorker worker)
        {
            int lnSeq = 0;
            Object loOPNHCUSTSeq;
            DataRow[] FoundItems = null;

            String lsCustKey = "", lsExpression = "", lsSort = "";

            DateTime ldCustDate;

            IACDataSetTableAdapters.OPNHCUSTTableAdapter OPNHCUSTTableAdapter = new IACDataSetTableAdapters.OPNHCUSTTableAdapter();
            OPNHCUSTBindingSource.DataSource = OPNPAYDataSet.OPNHCUST;

            //This code gets the next available sequence number for todays date if another history record for today exists
            loOPNHCUSTSeq = OPNHCUSTTableAdapter.SeqNoQuery(OPNPAYDataSet.OPNPAY.Rows[OPNPAYPos].Field<String>("PAYMENT_CUSTOMER"), DateTime.Now.Date);
            if (loOPNHCUSTSeq != null)
                lnSeq = (int)loOPNHCUSTSeq + 1;
            else
                lnSeq = 1;

            lsCustKey = OPNPAYDataSet.OPNPAY.Rows[OPNPAYPos].Field<String>("PAYMENT_CUSTOMER");
            ldCustDate = OPNPAYDataSet.OPNPAY.Rows[OPNPAYPos].Field<DateTime>("PAYMENT_DATE");
            // If any history records with the same OPNCUST no already exist in the DataTable, we must check IT for the last sequence number.
            lsExpression = "CUSTHIST_NO = \'" + lsCustKey + "\' and CUSTHIST_PAY_DATE = \'" + ldCustDate.ToShortDateString() + "\' and max(CUSTHIST_date_seq) > 0";
            lsSort = "CUSTHIST_date_seq desc";
            FoundItems = OPNPAYDataSet.OPNHCUST.Select(lsExpression, lsSort);

            if (FoundItems.Length != 0)
            {
                lnSeq = FoundItems[0].Field<Int32>("CUSTHIST_DATE_SEQ") + 1;
            }

            OPNHCUSTBindingSource.AddNew();
            OPNHCUSTBindingSource.EndEdit();

            OPNPAYDataSet.OPNHCUST.Rows[OPNHCUSTBindingSource.Position].SetField<String>("CUSTHIST_NO", OPNPAYDataSet.OPNPAY.Rows[OPNPAYPos].Field<String>("PAYMENT_CUSTOMER"));
            OPNPAYDataSet.OPNHCUST.Rows[OPNHCUSTBindingSource.Position].SetField<String>("CUSTHIST_ADD_ON", OPNPAYDataSet.OPNPAY.Rows[OPNPAYPos].Field<String>("PAYMENT_ADD_ON"));
            OPNPAYDataSet.OPNHCUST.Rows[OPNHCUSTBindingSource.Position].SetField<String>("CUSTHIST_IAC_TYPE", OPNPAYDataSet.OPNPAY.Rows[OPNPAYPos].Field<String>("PAYMENT_IAC_TYPE"));
            OPNPAYDataSet.OPNHCUST.Rows[OPNHCUSTBindingSource.Position].SetField<DateTime>("CUSTHIST_PAY_DATE", OPNPAYDataSet.OPNPAY.Rows[OPNPAYPos].Field<DateTime>("PAYMENT_DATE"));
            OPNPAYDataSet.OPNHCUST.Rows[OPNHCUSTBindingSource.Position].SetField<Int32>("CUSTHIST_DATE_SEQ", lnSeq);
            OPNPAYDataSet.OPNHCUST.Rows[OPNHCUSTBindingSource.Position].SetField<String>("CUSTHIST_ACT_STAT", OPNPAYDataSet.OPNCUST.Rows[OPNCUSTPos].Field<String>("CUSTOMER_ACT_STAT"));
            OPNPAYDataSet.OPNHCUST.Rows[OPNHCUSTBindingSource.Position].SetField<Decimal>("CUSTHIST_BALANCE", OPNPAYDataSet.OPNCUST.Rows[OPNCUSTPos].Field<Decimal>("CUSTOMER_BALANCE"));
            OPNPAYDataSet.OPNHCUST.Rows[OPNHCUSTBindingSource.Position].SetField<Decimal>("CUSTHIST_PAID_INTEREST", Convert.ToDecimal(OPNPAYDataSet.OPNCUST.Rows[OPNCUSTPos].Field<Decimal>("CUSTOMER_PAID_INTEREST")));
            OPNPAYDataSet.OPNHCUST.Rows[OPNHCUSTBindingSource.Position].SetField<Decimal>("CUSTHIST_PAYMENT_RCV", OPNPAYDataSet.OPNPAY.Rows[OPNPAYPos].Field<Decimal>("PAYMENT_AMOUNT_RCV"));
            OPNPAYDataSet.OPNHCUST.Rows[OPNHCUSTBindingSource.Position].SetField<Decimal>("CUSTHIST_LATE_CHARGE", 0);
            OPNPAYDataSet.OPNCUST.Rows[OPNCUSTPos].SetField<Decimal>("CUSTOMER_LATE_CHARGE", 0);
            OPNPAYDataSet.OPNHCUST.Rows[OPNHCUSTBindingSource.Position].SetField<Decimal>("CUSTHIST_LATE_CHARGE_BAL", OPNPAYDataSet.OPNCUST.Rows[OPNCUSTPos].Field<Decimal>("CUSTOMER_LATE_CHARGE_BAL"));
            OPNPAYDataSet.OPNHCUST.Rows[OPNHCUSTBindingSource.Position].SetField<Decimal>("CUSTHIST_CONTRACT_STATUS", lnHoldContractStatus);
            OPNPAYDataSet.OPNHCUST.Rows[OPNHCUSTBindingSource.Position].SetField<String>("CUSTHIST_PAYMENT_TYPE", OPNPAYDataSet.OPNPAY.Rows[OPNPAYPos].Field<String>("PAYMENT_TYPE"));
            OPNPAYDataSet.OPNHCUST.Rows[OPNHCUSTBindingSource.Position].SetField<String>("CUSTHIST_PAYMENT_CODE", OPNPAYDataSet.OPNPAY.Rows[OPNPAYPos].Field<String>("PAYMENT_CODE_2"));
            OPNPAYDataSet.OPNHCUST.Rows[OPNHCUSTBindingSource.Position].SetField<Int32>("CUSTHIST_THRU_UD", OPNPAYDataSet.OPNPAY.Rows[OPNPAYPos].Field<Int32>("PAYMENT_THRU_UD"));
            if (OPNPAYDataSet.OPNPAY.Rows[OPNPAYPos].Field<String>("PAYMENT_ALLOTMENT") == "Y")
                OPNPAYDataSet.OPNHCUST.Rows[OPNHCUSTBindingSource.Position].SetField<String>("CUSTHIST_ALLOTMENT", "Y");
            else
                OPNPAYDataSet.OPNHCUST.Rows[OPNHCUSTBindingSource.Position].SetField<String>("CUSTHIST_ALLOTMENT", "N");
            if (OPNPAYDataSet.OPNPAY.Rows[OPNPAYPos].Field<String>("PAYMENT_AUTO_PAY") == "Y")
                OPNPAYDataSet.OPNHCUST.Rows[OPNHCUSTBindingSource.Position].SetField<String>("CUSTHIST_AUTO_PAY", "Y");
            else
                OPNPAYDataSet.OPNHCUST.Rows[OPNHCUSTBindingSource.Position].SetField<String>("CUSTHIST_AUTO_PAY", "N");

            if (OPNPAYDataSet.OPNCUST.Rows[OPNCUSTPos].Field<String>("CUSTOMER_ACT_STAT") == "I")
                OPNPAYDataSet.OPNHCUST.Rows[OPNHCUSTBindingSource.Position].SetField<String>("CUSTHIST_PAY_REM_1", "PAID ");
            else
            {
                switch (OPNPAYDataSet.OPNPAY.Rows[OPNPAYPos].Field<String>("PAYMENT_TYPE"))
                {
                    case "R":
                        OPNPAYDataSet.OPNHCUST.Rows[OPNHCUSTBindingSource.Position].SetField<String>("CUSTHIST_PAY_REM_1", "PAY  ");
                        break;
                    case "E":
                        OPNPAYDataSet.OPNHCUST.Rows[OPNHCUSTBindingSource.Position].SetField<String>("CUSTHIST_PAY_REM_1", "EXT  ");
                        break;
                    case "I":
                        OPNPAYDataSet.OPNHCUST.Rows[OPNHCUSTBindingSource.Position].SetField<String>("CUSTHIST_PAY_REM_1", "INSUF");
                        break;
                    case "N":
                        OPNPAYDataSet.OPNHCUST.Rows[OPNHCUSTBindingSource.Position].SetField<String>("CUSTHIST_PAY_REM_1", "ISFC ");
                        break;
                    case "W":
                        OPNPAYDataSet.OPNHCUST.Rows[OPNHCUSTBindingSource.Position].SetField<String>("CUSTHIST_PAY_REM_1", "WAVE ");
                        break;
                    case "A":
                        OPNPAYDataSet.OPNHCUST.Rows[OPNHCUSTBindingSource.Position].SetField<String>("CUSTHIST_PAY_REM_1", "ADJ  ");
                        break;
                    case "C":
                        OPNPAYDataSet.OPNHCUST.Rows[OPNHCUSTBindingSource.Position].SetField<String>("CUSTHIST_PAY_REM_1", "CANCL");
                        break;
                    case "B":
                        OPNPAYDataSet.OPNHCUST.Rows[OPNHCUSTBindingSource.Position].SetField<String>("CUSTHIST_PAY_REM_1", "BUYBK");
                        break;
                    case "V":
                        OPNPAYDataSet.OPNHCUST.Rows[OPNHCUSTBindingSource.Position].SetField<String>("CUSTHIST_PAY_REM_1", "CCARD");
                        break;
                    case "P":
                        OPNPAYDataSet.OPNHCUST.Rows[OPNHCUSTBindingSource.Position].SetField<String>("CUSTHIST_PAY_REM_1", "PWRCK");
                        break;
                    case "S":
                        OPNPAYDataSet.OPNHCUST.Rows[OPNHCUSTBindingSource.Position].SetField<String>("CUSTHIST_PAY_REM_1", "STLMT");
                        break;
                    case "M":
                        OPNPAYDataSet.OPNHCUST.Rows[OPNHCUSTBindingSource.Position].SetField<String>("CUSTHIST_PAY_REM_1", "MRCHT");
                        break;
                    case "H":
                        OPNPAYDataSet.OPNHCUST.Rows[OPNHCUSTBindingSource.Position].SetField<String>("CUSTHIST_PAY_REM_1", "HOUSE");
                        break;
                    case "T":
                        OPNPAYDataSet.OPNHCUST.Rows[OPNHCUSTBindingSource.Position].SetField<String>("CUSTHIST_PAY_REM_1", "TRNSF");
                        break;
                    case "D":
                        OPNPAYDataSet.OPNHCUST.Rows[OPNHCUSTBindingSource.Position].SetField<String>("CUSTHIST_PAY_REM_1", "DLRTR");
                        break;
                    default:
                        OPNPAYDataSet.OPNHCUST.Rows[OPNHCUSTBindingSource.Position].SetField<String>("CUSTHIST_PAY_REM_1", "");
                        break;
                }
            }
            OPNPAYDataSet.OPNHCUST.Rows[OPNHCUSTBindingSource.Position].SetField<Decimal>("CUSTHIST_FINANCE_BUCKET_1", lnFinanceBucket[1]);
            OPNPAYDataSet.OPNHCUST.Rows[OPNHCUSTBindingSource.Position].SetField<Decimal>("CUSTHIST_FINANCE_BUCKET_2", lnFinanceBucket[2]);
            OPNPAYDataSet.OPNHCUST.Rows[OPNHCUSTBindingSource.Position].SetField<Decimal>("CUSTHIST_FINANCE_BUCKET_3", lnFinanceBucket[3]);
            OPNPAYDataSet.OPNHCUST.Rows[OPNHCUSTBindingSource.Position].SetField<Decimal>("CUSTHIST_FINANCE_BUCKET_4", lnFinanceBucket[4]);
            OPNPAYDataSet.OPNHCUST.Rows[OPNHCUSTBindingSource.Position].SetField<Decimal>("CUSTHIST_FINANCE_BUCKET_5", lnFinanceBucket[5]);
            OPNPAYDataSet.OPNHCUST.Rows[OPNHCUSTBindingSource.Position].SetField<Decimal>("CUSTHIST_FINANCE_BUCKET_6", lnFinanceBucket[6]);
            OPNPAYDataSet.OPNHCUST.Rows[OPNHCUSTBindingSource.Position].SetField<Decimal>("CUSTHIST_FINANCE_BUCKET_7", lnFinanceBucket[7]);
            OPNPAYDataSet.OPNHCUST.Rows[OPNHCUSTBindingSource.Position].SetField<Decimal>("CUSTHIST_FINANCE_BUCKET_8", lnFinanceBucket[8]);
            OPNPAYDataSet.OPNHCUST.Rows[OPNHCUSTBindingSource.Position].SetField<Decimal>("CUSTHIST_FINANCE_BUCKET_9", lnFinanceBucket[9]);
            OPNPAYDataSet.OPNHCUST.Rows[OPNHCUSTBindingSource.Position].SetField<Decimal>("CUSTHIST_FINANCE_BUCKET_10", lnFinanceBucket[10]);

            OPNPAYDataSet.OPNHCUST.Rows[OPNHCUSTBindingSource.Position].SetField<Decimal>("CUSTHIST_NO_PAYMENTS", lnNoPay);
            // Moses Newman 03/08/2012 CUSTHIST_NUMBER IS AN INTEGER AND NOT A STRING!!!
            OPNPAYDataSet.OPNHCUST.Rows[OPNHCUSTBindingSource.Position].SetField<Int32>("CUSTHIST_NUMBER", Convert.ToInt32(OPNPAYDataSet.OPNPAY.Rows[OPNPAYPos].Field<String>("PAYMENT_CUSTOMER")));
            OPNPAYDataSet.OPNHCUST.Rows[OPNHCUSTBindingSource.Position].SetField<DateTime>("CUSTHIST_DATE", OPNPAYDataSet.OPNPAY.Rows[OPNPAYPos].Field<DateTime>("PAYMENT_DATE"));
            MoveOPNPAYtoOPNCUST(OPNPAYPos, OPNCUSTPos, ref OPNPAYDataSet, ref worker);
            OPNPAYDataSet.OPNHCUST.Rows[OPNHCUSTBindingSource.Position].SetField<String>("CUSTHIST_PAID_THRU", OPNPAYDataSet.OPNCUST.Rows[OPNCUSTPos].Field<String>("CUSTOMER_PAID_THRU"));
        }

        void MoveOPNPAYtoOPNCUST(int OPNPAYPos, int OPNCUSTPos, ref IACDataSet OPNPAYDataSet, ref BackgroundWorker worker)
        {
            int lnNewMonth = 0, lnNewYear = 0, lnNoYears;
            OPNPAYDataSet.OPNCUST.Rows[OPNCUSTPos].SetField<Decimal>("CUSTOMER_LAST_PAYMENT_MADE", OPNPAYDataSet.OPNPAY.Rows[OPNPAYPos].Field<Decimal>("PAYMENT_AMOUNT_RCV"));
            OPNPAYDataSet.OPNCUST.Rows[OPNCUSTPos].SetField<DateTime>("CUSTOMER_LAST_PAYMENT_DATE", OPNPAYDataSet.OPNPAY.Rows[OPNPAYPos].Field<DateTime>("PAYMENT_DATE"));
            OPNPAYDataSet.OPNCUST.Rows[OPNCUSTPos].SetField<Int32>("CUSTOMER_FORM_NO", 0);
            OPNPAYDataSet.OPNCUST.Rows[OPNCUSTPos].SetField<String>("CUSTOMER_POST_IND", "P");
            OPNPAYDataSet.OPNCUST.Rows[OPNCUSTPos].SetField<String>("CUSTOMER_PAY_TYPE", OPNPAYDataSet.OPNPAY.Rows[OPNPAYPos].Field<String>("PAYMENT_TYPE"));
            OPNPAYDataSet.OPNCUST.Rows[OPNCUSTPos].SetField<String>("CUSTOMER_PAY_CODE", OPNPAYDataSet.OPNPAY.Rows[OPNPAYPos].Field<String>("PAYMENT_CODE_2"));


            lnNewMonth = Convert.ToInt32(OPNPAYDataSet.OPNCUST.Rows[OPNCUSTPos].Field<String>("CUSTOMER_PAID_THRU_MM"));
            lnNewYear = Convert.ToInt32(OPNPAYDataSet.OPNCUST.Rows[OPNCUSTPos].Field<String>("CUSTOMER_PAID_THRU_YY"));
            lnNewMonth += lnNoPay;
            if (lnNewMonth > 12)
            {
                lnNoYears = lnNewMonth / 12;
                lnNewYear += lnNoYears;
                lnNewMonth -= 12 * lnNoYears;
            }
            if (lnNewMonth == 0)
            {
                lnNewMonth = 12;
                lnNewYear -= 1;
            }

            if (lnNewMonth < 0)
            {
                lnNewYear -= 1;
                lnNewMonth += 12;
            }
            OPNPAYDataSet.OPNCUST.Rows[OPNCUSTPos].SetField<String>("CUSTOMER_PAID_THRU", lnNewMonth.ToString().TrimStart().PadLeft(2, '0') + lnNewYear.ToString().TrimStart().PadLeft(2, '0'));
            // Moses Newman 12/19/2013 CUSTOMER_PAID_THRU_MM and CUSTOMER_PAID_THRU_YY are now computed fields so no need to set!

            //Logic to adjust advance accounts

            switch (OPNPAYDataSet.OPNPAY.Rows[OPNPAYPos].Field<String>("PAYMENT_TYPE"))
            {
                case "E":
                case "N":
                case "I":
                    break;
                case "W":
                    if ((OPNPAYDataSet.OPNPAY.Rows[OPNPAYPos].Field<String>("PAYMENT_CODE_2") == "H" && OPNPAYDataSet.OPNPAY.Rows[OPNPAYPos].Field<Decimal>("PAYMENT_AMOUNT_RCV") < 0) ||
                        (OPNPAYDataSet.OPNPAY.Rows[OPNPAYPos].Field<String>("PAYMENT_CODE_2") == "L"))
                        break;
                    else
                        goto default;
                case "A":
                    if (OPNPAYDataSet.OPNPAY.Rows[OPNPAYPos].Field<Decimal>("PAYMENT_AMOUNT_RCV") < 0)
                        break;
                    else
                        goto default;
                default:
                    CheckMonth(OPNCUSTPos, ref OPNPAYDataSet);
                    break;
            }
            if (lnNoPay > 0)
                getInterestRates(OPNCUSTPos, ref OPNPAYDataSet);
            lnArrears = OPNPAYDataSet.OPNCUST.Rows[OPNCUSTPos].Field<Decimal>("CUSTOMER_CONTRACT_STATUS");
            OPNPAYDataSet.OPNCUST.Rows[OPNCUSTPos].SetField<String>("CUSTOMER_TSB_COMMENT_CODE", OPNPAYDataSet.OPNPAY.Rows[OPNPAYPos].Field<String>("PAYMENT_TSB_COMMENT_CODE"));
        }

        void CheckMonth(Int32 OPNCUSTPos, ref IACDataSet OPNDataSet)
        {
            Int32 lnActDateDiff = 0, lnTmpMM = 0, lnTmpYY = 0;
            String lsTempPaidThru = OPNDataSet.OPNCUST.Rows[OPNCUSTPos].Field<String>("CUSTOMER_PAID_THRU_MM") + "/" + OPNDataSet.OPNCUST.Rows[OPNCUSTPos].Field<Int32>("CUSTOMER_DAY_DUE").ToString().TrimStart() + "/" + DateTime.Now.Year.ToString().Substring(0, 2) + OPNDataSet.OPNCUST.Rows[OPNCUSTPos].Field<String>("CUSTOMER_PAID_THRU_YY");

            DateTime ldNewPaidThru = Convert.ToDateTime(lsTempPaidThru);

            TimeSpan ltActDateDiff;

            ltActDateDiff = DateTime.Now.Subtract(ldNewPaidThru);
            lnActDateDiff = ((Int32)(ltActDateDiff.TotalDays / 30));

            if (lnActDateDiff > 30)
            {
                lnTmpMM = DateTime.Now.Month;
                lnTmpMM += 1;
                lnTmpYY = Convert.ToInt32(OPNDataSet.OPNCUST.Rows[OPNCUSTPos].Field<String>("CUSTOMER_PAID_THRU_YY"));
                if (lnTmpMM > 12)
                {
                    lnTmpMM -= 12;
                    lnTmpYY += 1;
                }
                // Moses Newman 12/19/2013 No need to set CUSTOMER_PAID_THRU_MM or CUSTOMER_PAID_THRU_YY as they are now computed fields!
                OPNDataSet.OPNCUST.Rows[OPNCUSTPos].SetField<String>("CUSTOMER_PAID_THRU", lnTmpMM.ToString().TrimStart().PadLeft(2, '0') + lnTmpYY.ToString().TrimStart().PadLeft(2, '0'));
            }
            lnTodayDiff = lnActDateDiff;
        }

        void getInterestRates(Int32 OPNCUSTPos, ref IACDataSet OPNPAYDataSet)
        {
            Decimal lnHoldRate1 = 0, lnHoldRate2 = 0, lnHoldRate3 = 0;
            Double lnHoldInterest1 = 0, lnHoldInterest2 = 0, lnHoldInterest3 = 0;

            IACDataSetTableAdapters.OPNRATETableAdapter OPNRATETableAdapter = new IACDataSetTableAdapters.OPNRATETableAdapter();

            OPNRATETableAdapter.Fill(OPNPAYDataSet.OPNRATE, OPNPAYDataSet.OPNCUST.Rows[OPNCUSTPos].Field<String>("CUSTOMER_STATE"));

            if (OPNPAYDataSet.OPNRATE.Rows[0].Field<Decimal>("OPFRATE3_Y") != 0)
                if (OPNPAYDataSet.OPNCUST.Rows[OPNCUSTPos].Field<Decimal>("CUSTOMER_BALANCE") > OPNPAYDataSet.OPNRATE.Rows[0].Field<Decimal>("OPFRANG2_Y"))
                {
                    lnHoldRate3 = OPNPAYDataSet.OPNCUST.Rows[OPNCUSTPos].Field<Decimal>("CUSTOMER_BALANCE") - OPNPAYDataSet.OPNRATE.Rows[0].Field<Decimal>("OPFRANG2_Y");
                    lnHoldInterest3 = Convert.ToDouble(lnHoldRate3 * (OPNPAYDataSet.OPNRATE.Rows[0].Field<Decimal>("OPFRATE3_M") / 100));
                }

            if (OPNPAYDataSet.OPNRATE.Rows[0].Field<Decimal>("OPFRATE2_Y") != 0)
                if (OPNPAYDataSet.OPNCUST.Rows[OPNCUSTPos].Field<Decimal>("CUSTOMER_BALANCE") > OPNPAYDataSet.OPNRATE.Rows[0].Field<Decimal>("OPFRANG1_Y"))
                {
                    lnHoldRate2 = OPNPAYDataSet.OPNCUST.Rows[OPNCUSTPos].Field<Decimal>("CUSTOMER_BALANCE") - OPNPAYDataSet.OPNRATE.Rows[0].Field<Decimal>("OPFRANG1_Y") + lnHoldRate3;
                    lnHoldInterest2 = Convert.ToDouble(lnHoldRate2 * (OPNPAYDataSet.OPNRATE.Rows[0].Field<Decimal>("OPFRATE2_M") / 100));
                }

            if (OPNPAYDataSet.OPNRATE.Rows[0].Field<Decimal>("OPFRATE1_Y") != 0)
            {
                lnHoldRate1 = OPNPAYDataSet.OPNCUST.Rows[OPNCUSTPos].Field<Decimal>("CUSTOMER_BALANCE") - lnHoldRate3 + lnHoldRate2;
                lnHoldInterest1 = Convert.ToDouble(lnHoldRate1 * (OPNPAYDataSet.OPNRATE.Rows[0].Field<Decimal>("OPFRATE1_M") / 100));
            }

            OPNPAYDataSet.OPNCUST.Rows[OPNCUSTPos].SetField<Decimal>("CUSTOMER_PAID_INTEREST", Convert.ToDecimal(lnHoldInterest1 + lnHoldInterest2 + lnHoldInterest3));
            OPNPAYDataSet.OPNCUST.Rows[OPNCUSTPos].SetField<String>("CUSTOMER_PAY_REM_1", "");
        }

        public void OpenNewContractStatus(int OPNCUSTPos, ref IACDataSet OPNPAYPostDataSet)
        {
            // 12/7/2007 Moses Newman added missing OPNPAYPostDataSet.OPNCUST.Rows[OPNCUSTPos].Field<Decimal>("CUSTOMER_TOTAL_PAYMENTS")- to calcualtion.
            // This will compute CUSTOMER_CONTRACT_STATUS
            if (OPNPAYPostDataSet.OPNCUST.Rows[OPNCUSTPos].Field<Nullable<Decimal>>("CUSTOMER_TOTAL_LATE_CHARGE") == null)
                OPNPAYPostDataSet.OPNCUST.Rows[OPNCUSTPos].SetField<Decimal>("CUSTOMER_TOTAL_LATE_CHARGE", 0);
            if (OPNPAYPostDataSet.OPNCUST.Rows[OPNCUSTPos].Field<Nullable<Decimal>>("CUSTOMER_TOTAL_PAYMENTS") == null)
                OPNPAYPostDataSet.OPNCUST.Rows[OPNCUSTPos].SetField<Decimal>("CUSTOMER_TOTAL_PAYMENTS", 0);
            if (OPNPAYPostDataSet.OPNCUST.Rows[OPNCUSTPos].Field<Nullable<Decimal>>("CUSTOMER_REGULAR_AMOUNT") == null)
                OPNPAYPostDataSet.OPNCUST.Rows[OPNCUSTPos].SetField<Decimal>("CUSTOMER_REGULAR_AMOUNT", 0);
            if (OPNPAYPostDataSet.OPNCUST.Rows[OPNCUSTPos].Field<Nullable<Decimal>>("CUSTOMER_REG_AMOUNT1") == null)
                OPNPAYPostDataSet.OPNCUST.Rows[OPNCUSTPos].SetField<Decimal>("CUSTOMER_REG_AMOUNT1", 0);
            if (OPNPAYPostDataSet.OPNCUST.Rows[OPNCUSTPos].Field<Nullable<Decimal>>("CUSTOMER_REG_AMOUNT2") == null)
                OPNPAYPostDataSet.OPNCUST.Rows[OPNCUSTPos].SetField<Decimal>("CUSTOMER_REG_AMOUNT2", 0);
            if (OPNPAYPostDataSet.OPNCUST.Rows[OPNCUSTPos].Field<Nullable<Int32>>("CUSTOMER_STAT1") == null)
                OPNPAYPostDataSet.OPNCUST.Rows[OPNCUSTPos].SetField<Int32>("CUSTOMER_STAT1", 0);
            if (OPNPAYPostDataSet.OPNCUST.Rows[OPNCUSTPos].Field<Nullable<Int32>>("CUSTOMER_STAT2") == null)
                OPNPAYPostDataSet.OPNCUST.Rows[OPNCUSTPos].SetField<Int32>("CUSTOMER_STAT2", 0);
            if (OPNPAYPostDataSet.OPNCUST.Rows[OPNCUSTPos].Field<Nullable<Int32>>("CUSTOMER_STATUS_NO") == null)
                OPNPAYPostDataSet.OPNCUST.Rows[OPNCUSTPos].SetField<Int32>("CUSTOMER_STATUS_NO", 0);

            OPNPAYPostDataSet.OPNCUST.Rows[OPNCUSTPos].SetField<Decimal>("CUSTOMER_CONTRACT_STATUS",
                OPNPAYPostDataSet.OPNCUST.Rows[OPNCUSTPos].Field<Decimal>("CUSTOMER_TOTAL_PAYMENTS")-   // End of 12/7/2007 Mod
                (((OPNPAYPostDataSet.OPNCUST.Rows[OPNCUSTPos].Field<Decimal>("CUSTOMER_REG_AMOUNT1")    * OPNPAYPostDataSet.OPNCUST.Rows[OPNCUSTPos].Field<Int32>("CUSTOMER_STAT1")) +
                  (OPNPAYPostDataSet.OPNCUST.Rows[OPNCUSTPos].Field<Decimal>("CUSTOMER_REG_AMOUNT2")    * OPNPAYPostDataSet.OPNCUST.Rows[OPNCUSTPos].Field<Int32>("CUSTOMER_STAT2")) +
                  (OPNPAYPostDataSet.OPNCUST.Rows[OPNCUSTPos].Field<Decimal>("CUSTOMER_REGULAR_AMOUNT") * OPNPAYPostDataSet.OPNCUST.Rows[OPNCUSTPos].Field<Int32>("CUSTOMER_STATUS_NO"))) +
                 OPNPAYPostDataSet.OPNCUST.Rows[OPNCUSTPos].Field<Decimal>("CUSTOMER_TOTAL_LATE_CHARGE")));

            if (OPNPAYPostDataSet.OPNCUST.Rows[OPNCUSTPos].Field<Decimal>("CUSTOMER_CONTRACT_STATUS") < 0)
            {
                if (OPNPAYPostDataSet.OPNCUST.Rows[OPNCUSTPos].Field<Decimal>("CUSTOMER_BALANCE") < (OPNPAYPostDataSet.OPNCUST.Rows[OPNCUSTPos].Field<Decimal>("CUSTOMER_CONTRACT_STATUS") * -1))
                    OPNPAYPostDataSet.OPNCUST.Rows[OPNCUSTPos].SetField<Decimal>("CUSTOMER_CONTRACT_STATUS", OPNPAYPostDataSet.OPNCUST.Rows[OPNCUSTPos].Field<Decimal>("CUSTOMER_BALANCE") * -1);
            }
            else
                // 2011-12-06 Moses Newman add missing if Statement from COBOL side
                if (OPNPAYPostDataSet.OPNCUST.Rows[OPNCUSTPos].Field<Decimal>("CUSTOMER_CONTRACT_STATUS") > OPNPAYPostDataSet.OPNCUST.Rows[OPNCUSTPos].Field<Decimal>("CUSTOMER_BALANCE"))
                    OPNPAYPostDataSet.OPNCUST.Rows[OPNCUSTPos].SetField<Decimal>("CUSTOMER_CONTRACT_STATUS", OPNPAYPostDataSet.OPNCUST.Rows[OPNCUSTPos].Field<Decimal>("CUSTOMER_BALANCE"));
            // End of 2011-12-06 Mod

            // 12/7/2011 Moses Newman removed initilization of CUSTOMER_CONTRACT_STATUS to 0 for new cusotmers since it will be that anyway even after formula!
            lnHoldContractStatus = OPNPAYPostDataSet.OPNCUST.Rows[OPNCUSTPos].Field<Decimal>("CUSTOMER_CONTRACT_STATUS");
        }

        void OpenOverPayment(int OPNCUSTPos, ref IACDataSet OPNPAYDataSet)
        {
            lnCustOP = Math.Round(lnBalance - Convert.ToDouble(OPNPAYDataSet.OPNCUST.Rows[OPNCUSTPos].Field<Decimal>("CUSTOMER_BALANCE")), 2);
            lnMasterSundry = Math.Round(lnMasterSundry + lnCustOP, 2);
            lnMasterOP = Math.Round(lnMasterOP + lnCustOP, 2);
            lnBalance = Convert.ToDouble(OPNPAYDataSet.OPNCUST.Rows[OPNCUSTPos].Field<Decimal>("CUSTOMER_BALANCE"));
            OPNPAYDataSet.OPNCUST.Rows[OPNCUSTPos].SetField<Decimal>("CUSTOMER_BALANCE", 0);
            OPNPAYDataSet.OPNCUST.Rows[OPNCUSTPos].SetField<Decimal>("CUSTOMER_LATE_CHARGE_BAL", 0);
        }


        void OpenOverBuyout(int OPNPAYPos, int OPNCUSTPos, ref IACDataSet OPNPAYDataSet, ref BackgroundWorker worker)
        {
            lnCustOP = Math.Round(Convert.ToDouble(OPNPAYDataSet.OPNPAY.Rows[OPNPAYPos].Field<Decimal>("PAYMENT_AMOUNT_RCV")) - Convert.ToDouble(OPNPAYDataSet.OPNCUST.Rows[OPNCUSTPos].Field<Decimal>("CUSTOMER_BUYOUT")), 2);
            lnMasterSundry = Math.Round(lnMasterSundry + lnCustOP, 2);
            lnMasterOP = Math.Round(lnMasterOP + lnCustOP, 2);
        }

        void OpenProcessBuyout(int OPNPAYPos, int OPNCUSTPos, ref IACDataSet OPNPAYDataSet, ref BackgroundWorker worker)
        {
            OPNPAYDataSet.OPNCUST.Rows[OPNCUSTPos].SetField<String>("CUSTOMER_BUY_OUT", "Y");
            lnBalance = Convert.ToDouble(OPNPAYDataSet.OPNCUST.Rows[OPNCUSTPos].Field<Decimal>("CUSTOMER_BALANCE"));
            lnMasterUEI = Math.Round(lnMasterUEI + Convert.ToDouble(OPNPAYDataSet.OPNCUST.Rows[OPNCUSTPos].Field<Decimal>("CUSTOMER_BALANCE") - OPNPAYDataSet.OPNCUST.Rows[OPNCUSTPos].Field<Decimal>("CUSTOMER_BUYOUT")), 2);
            lnCustUEI = Math.Round(Convert.ToDouble(OPNPAYDataSet.OPNCUST.Rows[OPNCUSTPos].Field<Decimal>("CUSTOMER_BALANCE") - OPNPAYDataSet.OPNCUST.Rows[OPNCUSTPos].Field<Decimal>("CUSTOMER_BUYOUT")), 2);
        }

        void OpenCloseOut(int OPNCUSTPos, ref IACDataSet OPNPAYDataSet, ref BackgroundWorker worker)
        {
            OPNPAYDataSet.OPNCUST.Rows[OPNCUSTPos].SetField<Decimal>("CUSTOMER_BALANCE", 0);
            OPNPAYDataSet.OPNCUST.Rows[OPNCUSTPos].SetField<Decimal>("CUSTOMER_LATE_CHARGE_BAL", 0);
            OPNPAYDataSet.OPNCUST.Rows[OPNCUSTPos].SetField<Decimal>("CUSTOMER_CONTRACT_STATUS", 0);
            OPNPAYDataSet.OPNCUST.Rows[OPNCUSTPos].SetField<String>("CUSTOMER_PAY_REM_1", "PAID ");
        }


        void OpenOPNDEALRPost(ref IACDataSet OPNPAYDataSet, ref BackgroundWorker worker)
        {

            int OPNDEALRPos = 0;
            IACDataSetTableAdapters.OPNDEALRTableAdapter OPNDEALRTableAdapter = new IACDataSetTableAdapters.OPNDEALRTableAdapter();

            OPNDEALRBindingSource.DataSource = OPNPAYDataSet.OPNDEALR;

            OPNDEALRTableAdapter.FillBYUnPostedPayments(OPNPAYDataSet.OPNDEALR);
            for (Int32 dlrCount = 0; dlrCount < OPNPAYDataSet.OPN_WS_DEALER_PAY.Rows.Count; dlrCount++)
            {
                OPNDEALRPos = OPNDEALRBindingSource.Find("OPNDEALR_ACC_NO", OPNPAYDataSet.OPN_WS_DEALER_PAY.Rows[dlrCount].Field<String>("KEY"));

                if (OPNDEALRPos > -1)
                {
                    OPNPAYDataSet.OPN_WS_DEALER_PAY.Rows[dlrCount].SetField<Decimal>("OS_L", OPNPAYDataSet.OPN_WS_DEALER_PAY.Rows[dlrCount].Field<Decimal>("OS_L") * -1);
                    OPNPAYDataSet.OPNDEALR.Rows[OPNDEALRPos].SetField<Decimal>("OPNDEALR_CUR_RSV", 0);
                    OPNPAYDataSet.OPNDEALR.Rows[OPNDEALRPos].SetField<Decimal>("OPNDEALR_CUR_CONT", 0);
                    OPNPAYDataSet.OPNDEALR.Rows[OPNDEALRPos].SetField<Decimal>("OPNDEALR_CUR_OLOAN", 0);
                    OPNPAYDataSet.OPNDEALR.Rows[OPNDEALRPos].SetField<Decimal>("OPNDEALR_CUR_ADJ", 0);
                    OPNPAYDataSet.OPNDEALR.Rows[OPNDEALRPos].SetField<Decimal>("OPNDEALR_CUR_BAD", 0);
                    OPNPAYDataSet.OPNDEALR.Rows[OPNDEALRPos].SetField<Decimal>("OPNDEALR_CUR_LOSS", 0);
                    OPNPAYDataSet.OPNDEALR.Rows[OPNDEALRPos].SetField<Decimal>("OPNDEALR_CUR_OLOAN", OPNPAYDataSet.OPN_WS_DEALER_PAY.Rows[dlrCount].Field<Decimal>("OS_L"));
                    OPNPAYDataSet.OPNDEALR.Rows[OPNDEALRPos].SetField<Decimal>("OPNDEALR_YTD_OLOAN", OPNPAYDataSet.OPNDEALR.Rows[OPNDEALRPos].Field<Decimal>("OPNDEALR_YTD_OLOAN") + OPNPAYDataSet.OPN_WS_DEALER_PAY.Rows[dlrCount].Field<Decimal>("OS_L"));
                    OPNPAYDataSet.OPNDEALR.Rows[OPNDEALRPos].SetField<DateTime>("OPNDEALR_POST_DATE", DateTime.Now.Date);

                    OpenOPNHDEALPost(OPNDEALRPos, ref OPNPAYDataSet, ref worker);
                }
                else
                    MessageBox.Show("*** ERROR! OPNDEALR IS NOT IN OPNDEALR FILE, SOMETHING IS WRONG! ***");
            }
            worker.ReportProgress(12);
        }

        void OpenOPNHDEALPost(int OPNDEALRPos, ref IACDataSet OPNPAYDataSet, ref BackgroundWorker worker)
        {
            int lnSeq = 0, OPNHDEALPos = 0;
            Object loOPNHDEALSeq;


            IACDataSetTableAdapters.OPNDEALRTableAdapter OPNDEALRTableAdapter = new IACDataSetTableAdapters.OPNDEALRTableAdapter();
            IACDataSetTableAdapters.OPNHDEALTableAdapter OPNHDEALTableAdapter = new IACDataSetTableAdapters.OPNHDEALTableAdapter();

            OPNHDEALBindingSource.DataSource = OPNPAYDataSet.OPNHDEAL;

            OPNHDEALBindingSource.AddNew();
            OPNHDEALBindingSource.EndEdit();

            OPNHDEALPos = OPNHDEALBindingSource.Position;

            if (OPNHDEALPos > -1)
            {
                loOPNHDEALSeq = OPNHDEALTableAdapter.SeqNoQuery(OPNPAYDataSet.OPNDEALR.Rows[OPNDEALRPos].Field<String>("OPNDEALR_ACC_NO"), DateTime.Now.Date, OPNPAYDataSet.OPNDEALR.Rows[OPNDEALRPos].Field<DateTime>("OPNDEALR_POST_DATE"));
                if (loOPNHDEALSeq != null)
                    lnSeq = (int)loOPNHDEALSeq + 1;
                else
                    lnSeq = 1;
                // Set up the new history record key
                OPNPAYDataSet.OPNHDEAL.Rows[OPNHDEALPos].SetField<String>("DEALHIST_ACC_NO", OPNPAYDataSet.OPNDEALR.Rows[OPNDEALRPos].Field<String>("OPNDEALR_ACC_NO"));
                OPNPAYDataSet.OPNHDEAL.Rows[OPNHDEALPos].SetField<Int32>("DEALHIST_SEQ_NO", lnSeq);
                OPNPAYDataSet.OPNHDEAL.Rows[OPNHDEALPos].SetField<DateTime>("DEALHIST_POST_DATE", DateTime.Now.Date);
                //  End of OPNHDEAL KEY
                OPNPAYDataSet.OPNHDEAL.Rows[OPNHDEALPos].SetField<Decimal>("DEALHIST_CUR_ADJ", OPNPAYDataSet.OPNDEALR.Rows[OPNDEALRPos].Field<Decimal>("OPNDEALR_CUR_ADJ"));
                OPNPAYDataSet.OPNHDEAL.Rows[OPNHDEALPos].SetField<Decimal>("DEALHIST_CUR_CONT", OPNPAYDataSet.OPNDEALR.Rows[OPNDEALRPos].Field<Decimal>("OPNDEALR_CUR_CONT"));
                OPNPAYDataSet.OPNHDEAL.Rows[OPNHDEALPos].SetField<Decimal>("DEALHIST_CUR_BAD", OPNPAYDataSet.OPNDEALR.Rows[OPNDEALRPos].Field<Decimal>("OPNDEALR_CUR_BAD"));
                OPNPAYDataSet.OPNHDEAL.Rows[OPNHDEALPos].SetField<Decimal>("DEALHIST_CUR_RSV", OPNPAYDataSet.OPNDEALR.Rows[OPNDEALRPos].Field<Decimal>("OPNDEALR_CUR_RSV"));
                OPNPAYDataSet.OPNHDEAL.Rows[OPNHDEALPos].SetField<Decimal>("DEALHIST_CUR_LOSS", OPNPAYDataSet.OPNDEALR.Rows[OPNDEALRPos].Field<Decimal>("OPNDEALR_CUR_LOSS"));
                OPNPAYDataSet.OPNHDEAL.Rows[OPNHDEALPos].SetField<Decimal>("DEALHIST_CUR_OLOAN", OPNPAYDataSet.OPNDEALR.Rows[OPNDEALRPos].Field<Decimal>("OPNDEALR_CUR_OLOAN"));
                OPNPAYDataSet.OPNHDEAL.Rows[OPNHDEALPos].SetField<Decimal>("DEALHIST_YTD_ADJ", OPNPAYDataSet.OPNDEALR.Rows[OPNDEALRPos].Field<Decimal>("OPNDEALR_YTD_ADJ"));
                OPNPAYDataSet.OPNHDEAL.Rows[OPNHDEALPos].SetField<Decimal>("DEALHIST_YTD_CONT", OPNPAYDataSet.OPNDEALR.Rows[OPNDEALRPos].Field<Decimal>("OPNDEALR_YTD_CONT"));
                OPNPAYDataSet.OPNHDEAL.Rows[OPNHDEALPos].SetField<Decimal>("DEALHIST_YTD_BAD", OPNPAYDataSet.OPNDEALR.Rows[OPNDEALRPos].Field<Decimal>("OPNDEALR_YTD_BAD"));
                OPNPAYDataSet.OPNHDEAL.Rows[OPNHDEALPos].SetField<Decimal>("DEALHIST_YTD_RSV", OPNPAYDataSet.OPNDEALR.Rows[OPNDEALRPos].Field<Decimal>("OPNDEALR_YTD_RSV"));
                OPNPAYDataSet.OPNHDEAL.Rows[OPNHDEALPos].SetField<Decimal>("DEALHIST_YTD_LOSS", OPNPAYDataSet.OPNDEALR.Rows[OPNDEALRPos].Field<Decimal>("OPNDEALR_YTD_LOSS"));
                OPNPAYDataSet.OPNHDEAL.Rows[OPNHDEALPos].SetField<Decimal>("DEALHIST_YTD_OLOAN", OPNPAYDataSet.OPNDEALR.Rows[OPNDEALRPos].Field<Decimal>("OPNDEALR_YTD_OLOAN"));
                OPNPAYDataSet.OPNHDEAL.Rows[OPNHDEALPos].SetField<DateTime>("DEALHIST_LAST_POST_DATE", OPNPAYDataSet.OPNDEALR.Rows[OPNDEALRPos].Field<DateTime>("OPNDEALR_POST_DATE"));
                OPNPAYDataSet.OPNHDEAL.Rows[OPNHDEALPos].SetField<String>("DEALHIST_POST_CODE", "R");
                worker.ReportProgress(16);
            }
        }

        void OpenMasterPost(ref IACDataSet OPNPAYDataSet, ref BackgroundWorker worker)
        {
            int MASTERPos = 0;
            Object loMasterKey;
            String lsMasterKey = "";
            Decimal lnInterestTally = Convert.ToDecimal(lnMasterDiscount + lnMasterInterest),
                    lnInterestAmortTally = Convert.ToDecimal(lnMasterAmortDiscount + lnMasterAmortInterest);

            IACDataSetTableAdapters.MASTERTableAdapter MASTERTableAdapter = new IACDataSetTableAdapters.MASTERTableAdapter();
            IACDataSetTableAdapters.ACCOUNTTableAdapter ACCOUNTTableAdapter = new IACDataSetTableAdapters.ACCOUNTTableAdapter();

            MASTERBindingSource.DataSource = OPNPAYDataSet.MASTER;

            MASTERTableAdapter.FillAllRecords(OPNPAYDataSet.MASTER);

            loMasterKey = ACCOUNTTableAdapter.AccountNumber("OS_LOANS");
            lsMasterKey = (String)loMasterKey;
            MASTERPos = MASTERBindingSource.Find("MASTER_ACC_NO", lsMasterKey);
            if (MASTERPos > -1)
            {
                OPNPAYDataSet.MASTER.Rows[MASTERPos].SetField<Decimal>("MASTER_CUR_RSV", 0);
                OPNPAYDataSet.MASTER.Rows[MASTERPos].SetField<Decimal>("MASTER_CUR_CONT", 0);
                OPNPAYDataSet.MASTER.Rows[MASTERPos].SetField<Decimal>("MASTER_CUR_OLOAN", 0);
                OPNPAYDataSet.MASTER.Rows[MASTERPos].SetField<Decimal>("MASTER_CUR_ADJ", 0);
                OPNPAYDataSet.MASTER.Rows[MASTERPos].SetField<Decimal>("MASTER_CUR_BAD", 0);
                OPNPAYDataSet.MASTER.Rows[MASTERPos].SetField<Decimal>("MASTER_CUR_LOSS", 0);
                OPNPAYDataSet.MASTER.Rows[MASTERPos].SetField<Decimal>("MASTER_CUR_INT", 0);
                OPNPAYDataSet.MASTER.Rows[MASTERPos].SetField<Decimal>("MASTER_CUR_NOTES", 0);
                OPNPAYDataSet.MASTER.Rows[MASTERPos].SetField<Decimal>("MASTER_AMORT_CUR_OLOAN", 0);
                OPNPAYDataSet.MASTER.Rows[MASTERPos].SetField<Decimal>("MASTER_AMORT_CUR_NOTES", 0);
                OPNPAYDataSet.MASTER.Rows[MASTERPos].SetField<Decimal>("MASTER_AMORT_CUR_INT", 0);

                OPNPAYDataSet.MASTER.Rows[MASTERPos].SetField<Decimal>("MASTER_CUR_OLOAN", Convert.ToDecimal(lnMasterOloan * -1));
                OPNPAYDataSet.MASTER.Rows[MASTERPos].SetField<Decimal>("MASTER_YTD_OLOAN", OPNPAYDataSet.MASTER.Rows[MASTERPos].Field<Decimal>("MASTER_YTD_OLOAN") + Convert.ToDecimal(lnMasterOloan * -1));
                OPNPAYDataSet.MASTER.Rows[MASTERPos].SetField<Decimal>("MASTER_CUR_NOTES", Convert.ToDecimal(lnMasterNP * -1));
                OPNPAYDataSet.MASTER.Rows[MASTERPos].SetField<Decimal>("MASTER_YTD_NOTES", OPNPAYDataSet.MASTER.Rows[MASTERPos].Field<Decimal>("MASTER_YTD_NOTES") + Convert.ToDecimal(lnMasterNP * -1));

                OPNPAYDataSet.MASTER.Rows[MASTERPos].SetField<DateTime>("MASTER_POST_DATE", DateTime.Now.Date);
            }
            worker.ReportProgress(24);
        }

        void OpenMASTHISTPost(ref IACDataSet OPNPAYDataSet, ref BackgroundWorker worker)
        {
            int lnSeq = 0, MASTHISTPos = 0, MASTERPos = 0;
            Object loMASTHISTSeq, loMasterKey;
            String lsMasterKey = "";

            IACDataSetTableAdapters.ACCOUNTTableAdapter ACCOUNTTableAdapter = new IACDataSetTableAdapters.ACCOUNTTableAdapter();
            IACDataSetTableAdapters.MASTERTableAdapter MASTERTableAdapter = new IACDataSetTableAdapters.MASTERTableAdapter();
            IACDataSetTableAdapters.MASTHISTTableAdapter MASTHISTTableAdapter = new IACDataSetTableAdapters.MASTHISTTableAdapter();

            MASTERBindingSource.DataSource = OPNPAYDataSet.MASTER;
            MASTHISTBindingSource.DataSource = OPNPAYDataSet.MASTHIST;

            MASTHISTBindingSource.AddNew();
            MASTHISTBindingSource.EndEdit();

            MASTHISTPos = MASTHISTBindingSource.Position;

            loMasterKey = ACCOUNTTableAdapter.AccountNumber("OS_LOANS");
            lsMasterKey = (String)loMasterKey;
            MASTERPos = MASTERBindingSource.Find("MASTER_ACC_NO", lsMasterKey);

            if (MASTHISTPos > -1)
            {
                loMASTHISTSeq = MASTHISTTableAdapter.SeqNoQuery(OPNPAYDataSet.MASTER.Rows[MASTERPos].Field<String>("MASTER_ACC_NO"), DateTime.Now.Date);
                if (loMASTHISTSeq != null)
                    lnSeq = (int)loMASTHISTSeq + 1;
                else
                    lnSeq = 1;
                // Set up the new history record key
                OPNPAYDataSet.MASTHIST.Rows[MASTHISTPos].SetField<String>("MASTHIST_ACC_NO", OPNPAYDataSet.MASTER.Rows[MASTERPos].Field<String>("MASTER_ACC_NO"));
                OPNPAYDataSet.MASTHIST.Rows[MASTHISTPos].SetField<Int32>("MASTHIST_SEQ_NO", lnSeq);
                OPNPAYDataSet.MASTHIST.Rows[MASTHISTPos].SetField<DateTime>("MASTHIST_POST_DATE", DateTime.Now.Date);
                OPNPAYDataSet.MASTHIST.Rows[MASTHISTPos].SetField<String>("MASTHIST_NAME", OPNPAYDataSet.MASTER.Rows[MASTERPos].Field<String>("MASTER_NAME"));
                OPNPAYDataSet.MASTHIST.Rows[MASTHISTPos].SetField<String>("MASTHIST_IAC_TYPE", "O");

                //  End of MASTHIST KEY

                OPNPAYDataSet.MASTHIST.Rows[MASTHISTPos].SetField<Decimal>("MASTHIST_CUR_OLOAN", OPNPAYDataSet.MASTER.Rows[MASTERPos].Field<Decimal>("MASTER_CUR_OLOAN"));
                OPNPAYDataSet.MASTHIST.Rows[MASTHISTPos].SetField<Decimal>("MASTHIST_YTD_OLOAN", OPNPAYDataSet.MASTER.Rows[MASTERPos].Field<Decimal>("MASTER_YTD_OLOAN"));
                OPNPAYDataSet.MASTHIST.Rows[MASTHISTPos].SetField<Decimal>("MASTHIST_CUR_NOTES", OPNPAYDataSet.MASTER.Rows[MASTERPos].Field<Decimal>("MASTER_CUR_NOTES"));
                OPNPAYDataSet.MASTHIST.Rows[MASTHISTPos].SetField<Decimal>("MASTHIST_YTD_NOTES", OPNPAYDataSet.MASTER.Rows[MASTERPos].Field<Decimal>("MASTER_YTD_NOTES"));
            }

            worker.ReportProgress(48);
        }

        void OpenSumOPNDEALRTotals(int OPNPAYPos, Int32 OPNCUSTPos, ref IACDataSet OPNPAYDataSet, ref BackgroundWorker worker)
        {
            int WSOPNDEALRPos = 0;

            IACDataSetTableAdapters.OPN_WS_DEALER_PAYTableAdapter OPN_WS_DEALER_PAYTableAdapter = new IACDataSetTableAdapters.OPN_WS_DEALER_PAYTableAdapter();
            IACDataSetTableAdapters.OpenPaymentDistributionTableAdapter OpenPaymentDistributionTableAdapter = new IACDataSetTableAdapters.OpenPaymentDistributionTableAdapter();

            OpenPaymentDistributionTableAdapter.Delete(OPNPAYDataSet.OPNPAY.Rows[OPNPAYPos].Field<String>("PAYMENT_CUSTOMER"), OPNPAYDataSet.OPNPAY.Rows[OPNPAYPos].Field<DateTime>("PAYMENT_DATE"));
            OpenPaymentDistributionTableAdapter.Insert(OPNPAYDataSet.OPNPAY.Rows[OPNPAYPos].Field<String>("PAYMENT_CUSTOMER"), OPNPAYDataSet.OPNPAY.Rows[OPNPAYPos].Field<DateTime>("PAYMENT_DATE"), 0, 0, 0, 0, 0, 0);
            OpenPaymentDistributionTableAdapter.Fill(OPNPAYDataSet.OpenPaymentDistribution, OPNPAYDataSet.OPNPAY.Rows[OPNPAYPos].Field<String>("PAYMENT_CUSTOMER"), OPNPAYDataSet.OPNPAY.Rows[OPNPAYPos].Field<DateTime>("PAYMENT_DATE"));

            OPN_WS_DEALER_PAYBindingSource.DataSource = OPNPAYDataSet.OPN_WS_DEALER_PAY;

            WSOPNDEALRPos = OPN_WS_DEALER_PAYBindingSource.Find("KEY", OPNPAYDataSet.OPNPAY.Rows[OPNPAYPos].Field<String>("PAYMENT_DEALER"));
            if (WSOPNDEALRPos >= 0)
                OPNPAYDataSet.OPN_WS_DEALER_PAY.Rows[WSOPNDEALRPos].SetField<Decimal>("OS_L", OPNPAYDataSet.OPN_WS_DEALER_PAY.Rows[WSOPNDEALRPos].Field<Decimal>("OS_L") + Convert.ToDecimal(lnBalance));
            if (OPNPAYDataSet.OpenPaymentDistribution.Rows.Count > 0)
            {
                OPNPAYDataSet.OpenPaymentDistribution.Rows[0].SetField<Decimal>("PrincipalPaid", OPNPAYDataSet.OPNPAY.Rows[OPNPAYPos].Field<Decimal>("PAYMENT_AMOUNT_RCV") - Convert.ToDecimal(lnCustOP));
                OPNPAYDataSet.OpenPaymentDistribution.Rows[0].SetField<Decimal>("InterestPaid", Convert.ToDecimal(lnPaidInt - lnIntAdj));
                OPNPAYDataSet.OpenPaymentDistribution.Rows[0].SetField<Decimal>("OverPayment", Convert.ToDecimal(lnCustOP));
                OPNPAYDataSet.OpenPaymentDistribution.Rows[0].SetField<Decimal>("Extension", Convert.ToDecimal(lnCustExt));
            }
            OpenPaymentDistributionTableAdapter.Update(OPNPAYDataSet.OpenPaymentDistribution.Rows[0]);
        }

        void OpenPartialOPNPAY(int OPNPAYPos, Int32 OPNCUSTPos, ref IACDataSet OPNPAYDataSet, ref BackgroundWorker worker)
        {
            Double lnACTPartialPay = 0, lnCustPartial = 0;

            if (OPNPAYDataSet.OPNPAY.Rows[OPNPAYPos].Field<String>("PAYMENT_TYPE") == "N" ||
                OPNPAYDataSet.OPNPAY.Rows[OPNPAYPos].Field<String>("PAYMENT_TYPE") == "B" ||
                OPNPAYDataSet.OPNPAY.Rows[OPNPAYPos].Field<String>("PAYMENT_TYPE") == "C" ||
                OPNPAYDataSet.OPNPAY.Rows[OPNPAYPos].Field<String>("PAYMENT_TYPE") == "E" ||
                OPNPAYDataSet.OPNPAY.Rows[OPNPAYPos].Field<String>("PAYMENT_TYPE") == "T" ||
                OPNPAYDataSet.OPNPAY.Rows[OPNPAYPos].Field<String>("PAYMENT_TYPE") == "D" ||
                (OPNPAYDataSet.OPNPAY.Rows[OPNPAYPos].Field<String>("PAYMENT_TYPE") == "W" && OPNPAYDataSet.OPNPAY.Rows[OPNPAYPos].Field<String>("PAYMENT_CODE_2") != "C"))
                return;
            lnACTPartialPay = (lnBalance / Convert.ToDouble(OPNPAYDataSet.OPNCUST.Rows[OPNCUSTPos].Field<Decimal>("CUSTOMER_REGULAR_AMOUNT"))) - lnNoPay;
            OPNPAYDataSet.OPNCUST.Rows[OPNCUSTPos].SetField<Double>("CUSTOMER_PARTIAL_OPNPAYS", OPNPAYDataSet.OPNCUST.Rows[OPNCUSTPos].Field<Double>("CUSTOMER_PARTIAL_OPNPAYS") + lnACTPartialPay);
            if (OPNPAYDataSet.OPNCUST.Rows[OPNCUSTPos].Field<Double>("CUSTOMER_PARTIAL_OPNPAYS") > .998 && OPNPAYDataSet.OPNCUST.Rows[OPNCUSTPos].Field<Double>("CUSTOMER_PARTIAL_OPNPAYS") < 1)
                OPNPAYDataSet.OPNCUST.Rows[OPNCUSTPos].SetField<Double>("CUSTOMER_PARTIAL_OPNPAYS", 1);
            lnCustPartial = (Int32)(OPNPAYDataSet.OPNCUST.Rows[OPNCUSTPos].Field<Double>("CUSTOMER_PARTIAL_OPNPAYS"));
            OPNPAYDataSet.OPNCUST.Rows[OPNCUSTPos].SetField<Double>("CUSTOMER_PARTIAL_OPNPAYS", OPNPAYDataSet.OPNCUST.Rows[OPNCUSTPos].Field<Double>("CUSTOMER_PARTIAL_OPNPAYS") - lnCustPartial);
            lnNoPay += (Int32)lnCustPartial;
        }

        void OpenAccumIOL(int OPNPAYPos, ref IACDataSet OPNPAYDataSet, ref BackgroundWorker worker)
        {
            lnMasterOloan += lnBalance;
            lnMasterOloan = Math.Round(lnMasterOloan, 2);

            switch (OPNPAYDataSet.OPNPAY.Rows[OPNPAYPos].Field<String>("PAYMENT_TYPE"))
            {
                case "N":
                case "A":
                case "B":
                case "C":
                case "W":
                case "H":
                case "T":
                case "D":
                case "V":
                case "P":
                case "I":
                    lnMasterNPNP += Convert.ToDouble(OPNPAYDataSet.OPNPAY.Rows[OPNPAYPos].Field<Decimal>("PAYMENT_AMOUNT_RCV"));
                    lnMasterNPNP = Math.Round(lnMasterNPNP, 2);
                    break;
                default:
                    lnMasterNP += Convert.ToDouble(OPNPAYDataSet.OPNPAY.Rows[OPNPAYPos].Field<Decimal>("PAYMENT_AMOUNT_RCV"));
                    lnMasterNP = Math.Round(lnMasterNP, 2);
                    break;
            }
        }


        void CheckFinanceBuckets(Int32 OPNPAYPos, Int32 OPNCUSTPos, ref IACDataSet OPNCUSTDataSet)
        {
            if (OPNCUSTDataSet.OPNPAY.Rows[OPNPAYPos].Field<Decimal>("PAYMENT_AMOUNT_RCV") == 0)
                return;
            lnNoPay = 0;
            for (int x = 1; x < 11; x++)
                lnFinanceBucket[x] = 0;

            lnCheckFinance = OPNCUSTDataSet.OPNPAY.Rows[OPNPAYPos].Field<Decimal>("PAYMENT_AMOUNT_RCV");

            for (int i = 10; i > 0; i--)
            {
                if (TestFinanceBucket(OPNCUSTPos, i, ref OPNCUSTDataSet) == 0)
                    return;
            }
            switch (OPNCUSTDataSet.OPNPAY.Rows[OPNPAYPos].Field<String>("PAYMENT_TYPE"))
            {
                case "R":
                case "V":
                case "P":
                case "S":
                case "M":
                case "H":
                    if (OPNCUSTDataSet.OPNPAY.Rows[OPNPAYPos].Field<Decimal>("PAYMENT_AMOUNT_RCV") <= OPNCUSTDataSet.OPNCUST.Rows[OPNCUSTPos].Field<Decimal>("CUSTOMER_REGULAR_AMOUNT"))
                        return;
                    break;

            }
            if (OPNCUSTDataSet.OPNCUST.Rows[OPNCUSTPos].Field<Decimal>("CUSTOMER_FINANCE_BUCKET_1") == 0 && OPNCUSTDataSet.OPNCUST.Rows[OPNCUSTPos].Field<Decimal>("CUSTOMER_LATE_CHARGE_BAL") > 0)
            {
                OPNCUSTDataSet.OPNCUST.Rows[OPNCUSTPos].SetField<Decimal>("CUSTOMER_LATE_CHARGE_BAL", OPNCUSTDataSet.OPNCUST.Rows[OPNCUSTPos].Field<Decimal>("CUSTOMER_LATE_CHARGE_BAL") - lnCheckFinance);
                if (OPNCUSTDataSet.OPNCUST.Rows[OPNCUSTPos].Field<Decimal>("CUSTOMER_LATE_CHARGE_BAL") < 0)
                    OPNCUSTDataSet.OPNCUST.Rows[OPNCUSTPos].SetField<Decimal>("CUSTOMER_LATE_CHARGE_BAL", 0);
            }
        }

        Decimal TestFinanceBucket(Int32 OPNCUSTPos, Int32 tnBucketNumber, ref IACDataSet OPNCUSTDataSet)
        {
            String lsBucket = "CUSTOMER_FINANCE_BUCKET_" + tnBucketNumber.ToString().TrimStart();

            if (OPNCUSTDataSet.OPNCUST.Rows[OPNCUSTPos].Field<Decimal>(lsBucket) > 0)
            {
                lnHoldBucket = OPNCUSTDataSet.OPNCUST.Rows[OPNCUSTPos].Field<Decimal>(lsBucket);
                OPNCUSTDataSet.OPNCUST.Rows[OPNCUSTPos].SetField<Decimal>(lsBucket, OPNCUSTDataSet.OPNCUST.Rows[OPNCUSTPos].Field<Decimal>(lsBucket) - lnCheckFinance);
                lnCheckFinance -= lnHoldBucket;

                //This replacese 080-CHECK-FINANCE-CALC
                if (lnCheckFinance < 0)
                    lnCheckFinance = 0;

                CheckBucket(OPNCUSTPos, tnBucketNumber, ref OPNCUSTDataSet);
                if (OPNCUSTDataSet.OPNCUST.Rows[OPNCUSTPos].Field<Decimal>(lsBucket) <= 0)
                {
                    OPNCUSTDataSet.OPNCUST.Rows[OPNCUSTPos].SetField<Decimal>(lsBucket, 0);
                    lnNoPay += 1;
                    return lnCheckFinance;
                }
            }
            return 1;
        }

        void CheckBucket(Int32 OPNCUSTPos, Int32 tnBucketNumber, ref IACDataSet OPNCUSTDataSet)
        {
            String lsBucket = "CUSTOMER_FINANCE_BUCKET_" + tnBucketNumber.ToString().TrimStart();

            if (OPNCUSTDataSet.OPNCUST.Rows[OPNCUSTPos].Field<Decimal>(lsBucket) < 0)
            {
                lnFinanceBucket[tnBucketNumber] = lnHoldBucket;
                return;
            }

            lnFinanceBucket[tnBucketNumber] += (lnHoldBucket - OPNCUSTDataSet.OPNCUST.Rows[OPNCUSTPos].Field<Decimal>(lsBucket));
            if (lnFinanceBucket[tnBucketNumber] < 0)
                lnFinanceBucket[tnBucketNumber] = lnHoldBucket;
        }

        void ExtensionBuckets(Int32 OPNPAYPos, Int32 OPNCUSTPos, ref IACDataSet OPNCUSTDataSet)
        {
            lnCheckExtension = OPNCUSTDataSet.OPNPAY.Rows[OPNPAYPos].Field<Int32>("PAYMENT_THRU_UD");

            for (Int32 i = 10; i > 0; i--)
            {
                if (TestExtensionBucket(OPNPAYPos, OPNCUSTPos, i, ref OPNCUSTDataSet) == 0)
                    return;
            }
        }

        Int32 TestExtensionBucket(Int32 OPNPAYPos, Int32 OPNCUSTPos, Int32 tnBucketNumber, ref IACDataSet OPNCUSTDataSet)
        {
            String lsBucket = "CUSTOMER_FINANCE_BUCKET_" + tnBucketNumber.ToString().TrimStart();
            if (OPNCUSTDataSet.OPNCUST.Rows[OPNCUSTPos].Field<Decimal>(lsBucket) > 0)
            {
                OPNCUSTDataSet.OPNCUST.Rows[OPNCUSTPos].SetField<Decimal>(lsBucket, 0);
                lnCheckExtension -= 1;
                return lnCheckExtension;
            }
            return 1;
        }

        void BucketTable()
        {
            int MaxBucketNum = 0;

            for (int i = 1; i < 11; i++)
            {
                lnBucketTable[i] = 0;
                if (lnFinanceBucket[i] > 0)
                {
                    MaxBucketNum = i;
                    lnBucketTable[i] = lnFinanceBucket[i];
                }
                lnFinanceBucket[i] = 0;
            }
            if (MaxBucketNum > lnNoPay)
            {
                lnFinanceBucket[1] = lnBucketTable[1] + lnBucketTable[2];
                for (int x = 3; x < 11; x++)
                    lnFinanceBucket[x - 1] = lnBucketTable[x];
                lnFinanceBucket[10] = 0;
            }
            else
                for (int x = 1; x < 11; x++)
                    lnFinanceBucket[x] = lnBucketTable[x];
        }

        void ISFBuckets(Int32 OPNPAYPos, Int32 OPNCUSTPos, ref IACDataSet OPNCUSTDataSet)
        {
            IACDataSetTableAdapters.OPNHCUSTTableAdapter OPNHCUSTTableAdapter = new IACDataSetTableAdapters.OPNHCUSTTableAdapter();
            if (OPNCUSTDataSet.OPNPAY.Rows[OPNPAYPos].Field<Nullable<DateTime>>("PAYMENT_ISF_DATE") == null)
                return;
            OPNHCUSTTableAdapter.ClearBeforeFill = false;
            OPNHCUSTTableAdapter.FillByCustPayDatePayment(OPNCUSTDataSet.OPNHCUST, OPNCUSTDataSet.OPNPAY.Rows[OPNPAYPos].Field<String>("PAYMENT_CUSTOMER"), OPNCUSTDataSet.OPNPAY.Rows[OPNPAYPos].Field<DateTime>("PAYMENT_ISF_DATE"));
            OPNHCUSTTableAdapter.ClearBeforeFill = true;
            if (OPNCUSTDataSet.OPNHCUST.Rows.Count == 0)
                return;
            testISFBucket(OPNCUSTPos, OPNPAYPos, ref OPNCUSTDataSet);
        }

        void testISFBucket(Int32 OPNCUSTPos, Int32 OPNPAYPos, ref IACDataSet OPNCUSTDataSet)
        {

            string lsCUSTHISTBucket = "", lsCUSTBucket = "";
            Int32 lnHistPos = 0;

            OPNHCUSTBindingSource.DataSource = OPNCUSTDataSet.OPNHCUST;
            lnHistPos = OPNHCUSTBindingSource.Find("CUSTHIST_DATE", OPNCUSTDataSet.OPNPAY.Rows[OPNPAYPos].Field<Nullable<DateTime>>("PAYMENT_ISF_DATE"));
            if (lnHistPos < 0)
            {
                OPNHCUSTBindingSource.Dispose();
                return;
            }
            for (int x = 1; x < 10; x++)  // First 9 buckets here only
            {
                lsCUSTBucket = "CUSTOMER_FINANCE_BUCKET_" + x.ToString().TrimStart();
                if (OPNCUSTDataSet.OPNCUST.Rows[OPNCUSTPos].Field<Decimal>(lsCUSTBucket) == 0)
                {
                    for (int i = 1; i < 11; i++)
                    {
                        lsCUSTHISTBucket = "CUSTHIST_FINANCE_BUCKET_" + i.ToString().TrimStart();
                        if (OPNCUSTDataSet.OPNHCUST.Rows[lnHistPos].Field<Decimal>(lsCUSTHISTBucket) > 0)
                        {
                            OPNCUSTDataSet.OPNCUST.Rows[OPNCUSTPos].SetField<Decimal>(lsCUSTBucket, OPNCUSTDataSet.OPNHCUST.Rows[lnHistPos].Field<Decimal>(lsCUSTHISTBucket));
                            OPNCUSTDataSet.OPNHCUST.Rows[lnHistPos].SetField<Decimal>(lsCUSTHISTBucket, 0);
                            break;
                        }
                    }
                }
            }
            for (int x = 1; x < 11; x++)
            {
                lsCUSTHISTBucket = "CUSTHIST_FINANCE_BUCKET_" + x.ToString().TrimStart();
                if (OPNCUSTDataSet.OPNHCUST.Rows[lnHistPos].Field<Decimal>(lsCUSTHISTBucket) > 0)
                {
                    OPNCUSTDataSet.OPNCUST.Rows[OPNCUSTPos].SetField<Decimal>("CUSTOMER_FINANCE_BUCKET_10",
                        OPNCUSTDataSet.OPNCUST.Rows[OPNCUSTPos].Field<Decimal>("CUSTOMER_FINANCE_BUCKET_10") +
                        OPNCUSTDataSet.OPNHCUST.Rows[lnHistPos].Field<Decimal>(lsCUSTHISTBucket));
                    OPNCUSTDataSet.OPNHCUST.Rows[lnHistPos].SetField<Decimal>(lsCUSTHISTBucket, 0);
                }
            }
            if (OPNCUSTDataSet.OPNPAY.Rows[OPNPAYPos].Field<Decimal>("PAYMENT_AMOUNT_RCV") < 0)
                lnNoPay = OPNCUSTDataSet.OPNHCUST.Rows[lnHistPos].Field<Int32>("CUSTHIST_NO_PAYMENTS") * -1;
            else
                lnNoPay = OPNCUSTDataSet.OPNHCUST.Rows[lnHistPos].Field<Int32>("CUSTHIST_NO_PAYMENTS");
            // Load up buckets for history
            for (int i = 1; i < 11; i++)
            {
                lsCUSTBucket = "CUSTOMER_FINANCE_BUCKET_" + i.ToString().TrimStart();
                lnFinanceBucket[i] = OPNCUSTDataSet.OPNCUST.Rows[OPNCUSTPos].Field<Decimal>(lsCUSTBucket);
            }
        }

        void OpenPaymentWriteOPNCUSTChanges(ref IACDataSet OPNCUSTDataSet, ref BackgroundWorker worker)
        {
            IACDataSetTableAdapters.OPNCUSTTableAdapter OPNCUSTTableAdapter = new IACDataSetTableAdapters.OPNCUSTTableAdapter();
            OPNCUSTTableAdapter.Update(OPNCUSTDataSet.OPNCUST);
            worker.ReportProgress(62);
        }

        void OpenPaymentWriteOPNHCUSTChanges(ref IACDataSet OPNHCUSTDataSet, ref BackgroundWorker worker)
        {
            Object loCustHistSeq = null;
            Int32 lnSeq = 0;

            IACDataSetTableAdapters.OPNHCUSTTableAdapter CUSTHISTTableAdapter = new IACDataSetTableAdapters.OPNHCUSTTableAdapter();

            CUSTHISTBindingSource.DataSource = OPNHCUSTDataSet.OPNHCUST;

            try
            {
                CUSTHISTBindingSource.MoveFirst();
                for (int i = 0; i < OPNHCUSTDataSet.OPNHCUST.Rows.Count; i++)
                {
                    loCustHistSeq = CUSTHISTTableAdapter.SeqNoQuery(OPNHCUSTDataSet.OPNHCUST.Rows[i].Field<String>("CUSTHIST_NO"), DateTime.Now.Date);
                    if (loCustHistSeq != null)
                        lnSeq = (int)loCustHistSeq + 1;
                    else
                    {
                        lnSeq = 1;
                    }
                    // Dont change sequence number is record exists alread due to ISF payment
                    if (OPNHCUSTDataSet.OPNHCUST.Rows[i].Field<DateTime>("CUSTHIST_PAY_DATE") == DateTime.Now.Date)
                    {
                        OPNHCUSTDataSet.OPNHCUST.Rows[i].SetField<Int32>("CUSTHIST_DATE_SEQ", lnSeq);
                        CUSTHISTBindingSource.EndEdit();
                    }
                }
                CUSTHISTTableAdapter.Update(OPNHCUSTDataSet.OPNHCUST);
            }
            catch (System.Data.SqlClient.SqlException ex)
            {
                MessageBox.Show("This is a Microsoft SQL Server database error: " + ex.Message.ToString());
            }
            catch (System.InvalidOperationException ex)
            {
                MessageBox.Show("Invalid Operation Error: " + ex.Message.ToString());
            }
            catch (Exception ex)
            {
                MessageBox.Show("General Exception Error: " + ex.Message.ToString());
            }
            finally
            {
                OPNHCUSTDataSet.OPNHCUST.AcceptChanges();
                CUSTHISTBindingSource.Dispose();
                CUSTHISTTableAdapter.Dispose();
                worker.ReportProgress(68);
            }
        }

        void OpenPaymentWriteOPNDEALRChanges(ref IACDataSet OPNDEALRDataSet, ref BackgroundWorker worker)
        {
            IACDataSetTableAdapters.OPNDEALRTableAdapter OPNDEALRTableAdapter = new IACDataSetTableAdapters.OPNDEALRTableAdapter();
            OPNDEALRTableAdapter.Update(OPNDEALRDataSet.OPNDEALR);
            worker.ReportProgress(74);
        }

        void OpenPaymentWriteOPNHDEALChanges(ref IACDataSet OPNDEALRDataSet, ref BackgroundWorker worker)
        {
            Object loDealhistSeq = null;
            Int32 lnSeq = 0;

            IACDataSetTableAdapters.OPNHDEALTableAdapter DEALHISTTableAdapter = new IACDataSetTableAdapters.OPNHDEALTableAdapter();

            DEALHISTBindingSource.DataSource = OPNDEALRDataSet.OPNHDEAL;
            try
            {

                DEALHISTBindingSource.MoveFirst();
                for (int i = 0; i < OPNDEALRDataSet.OPNHDEAL.Rows.Count; i++)
                {
                    loDealhistSeq = DEALHISTTableAdapter.SeqNoQuery(OPNDEALRDataSet.OPNHDEAL.Rows[i].Field<String>("DEALHIST_ACC_NO"), DateTime.Now.Date, DateTime.Now.Date);
                    if (loDealhistSeq != null)
                        lnSeq = (int)loDealhistSeq + 1;
                    else
                        lnSeq = 1;
                    OPNDEALRDataSet.OPNHDEAL.Rows[i].SetField<Int32>("DEALHIST_SEQ_NO", lnSeq);
                    OPNDEALRDataSet.OPNHDEAL.Rows[i].SetField<DateTime>("DEALHIST_LAST_POST_DATE", DateTime.Now.Date);
                    DEALHISTBindingSource.EndEdit();
                }
                DEALHISTTableAdapter.Update(OPNDEALRDataSet.OPNHDEAL);
            }
            catch (System.Data.SqlClient.SqlException ex)
            {
                MessageBox.Show("This is a Microsoft SQL Server database error: " + ex.Message.ToString());
            }
            catch (System.InvalidOperationException ex)
            {
                MessageBox.Show("Invalid Operation Error: " + ex.Message.ToString());
            }
            catch (Exception ex)
            {
                MessageBox.Show("General Exception Error: " + ex.Message.ToString());
            }
            finally
            {
                OPNDEALRDataSet.OPNHDEAL.AcceptChanges();
                DEALHISTBindingSource.Dispose();
                DEALHISTTableAdapter.Dispose();
                worker.ReportProgress(80);
            }
            worker.ReportProgress(80);
        }

        void OpenPaymentWriteMASTerChanges(ref IACDataSet MASTERDataSet, ref BackgroundWorker worker)
        {
            IACDataSetTableAdapters.MASTERTableAdapter MASTERTableAdapter = new IACDataSetTableAdapters.MASTERTableAdapter();
            MASTERTableAdapter.Update(MASTERDataSet.MASTER);
            worker.ReportProgress(86);
        }

        void OpenPaymentWriteMASTHistChanges(ref IACDataSet MASTERDataSet, ref BackgroundWorker worker)
        {
            ClosedPaymentPosting CPaymentPosting = new ClosedPaymentPosting();
            CPaymentPosting.ClosedPaymentWriteMASTHistChanges(ref MASTERDataSet, ref worker);
            worker.ReportProgress(92);
        }
    }
}

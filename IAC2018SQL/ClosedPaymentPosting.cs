using System;
using System.Globalization;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Linq;
using System.Windows.Forms;
using System.IO;
using IAC2021SQL.IACDataSetTableAdapters;
using Newtonsoft.Json;

namespace IAC2021SQL
{
    class ClosedPaymentPosting : IDisposable
    {
        public String gsProgMessage = "";
        public BackgroundWorker worker;
        private Int32 lnNoPay = 0, lnAPPPay = 0, lnTodayDiff = 0, lnPTDiff = 0, lnTermRem = 0;
        private Double lnNewInt = 0, lnPaidDiscount = 0, lnDlrDiscount = 0;

        private Decimal lnExtraContract = 0, lnArrears = 0, lnLCBPay = 0, lnMoneyRemaining = 0, lnAVStatus = 0,
                        SavedInterestApplied = 0, SavedPaidInterest = 0, lnPrinciplePaid = 0,
                        lnSimpleDiff = 0, lnNonCashFeesandCharges = 0, lnBalance = 0, lnCustOP = 0, lnMasterSundry = 0, lnMasterOP = 0, lnCustExt = 0,
                        lnMasterExt = 0, lnMasterNP = 0, lnMasterNPNP = 0, lnMasterAmortNP = 0, lnMasterSimpleNP = 0, lnMasterOloan = 0, lnMasterAmortOloan = 0, lnLateChargePaid = 0,
                        lnCustUEI = 0, lnAccruedInt = 0, lnPaidDis = 0, lnDisPay = 0, lnPayDue = 0,
                        lnMasterUEI = 0, lnMasterInterest = 0, lnMasterDiscount = 0, lnMasterAmortInterest = 0, lnMasterAmortDiscount = 0,
                        lnMasterSimpleInterest = 0, lnMasterSimpleDiscount = 0, lnPaidSimpleInt = 0, lnPaidSimpleDisc = 0, lnMasterSimpleOloan = 0, lnIntPay = 0,
                        lnSimpleBalance = 0, lnIntAdj = 0, lnOldBalance = 0, lnISFTotal = 0;

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        public Decimal LateChargeBalancePayment
        {
            get { return lnLCBPay; }
            set { lnLCBPay = value; }
        }


        private Double lnNoDis = 0, lnDlrDisc = 0, lnDisInt = 0, lnRebate = 0;

        private BindingSource AmortTempBindingSource = new BindingSource();
        private BindingSource DEALERBindingSource = new BindingSource();
        private BindingSource DEALHISTBindingSource = new BindingSource();
        private BindingSource MASTERBindingSource = new BindingSource();
        private BindingSource MASTHISTBindingSource = new BindingSource();
        private BindingSource CUSTOMERBindingSource = new BindingSource();
        private BindingSource AMORTIZEBindingSource = new BindingSource();

        protected virtual void Dispose(bool disposing)
        {
            if (disposing)
            {
                // free managed resources
                if (AmortTempBindingSource != null)
                {
                    AmortTempBindingSource.Dispose();
                    AmortTempBindingSource = null;
                }
                if (AMORTIZEBindingSource != null)
                {
                    AMORTIZEBindingSource.Dispose();
                    AMORTIZEBindingSource = null;
                }
                if (CUSTOMERBindingSource != null)
                {
                    CUSTOMERBindingSource.Dispose();
                    CUSTOMERBindingSource = null;
                }
                if (DEALERBindingSource != null)
                {
                    DEALERBindingSource.Dispose();
                    DEALERBindingSource = null;
                }
                if (DEALHISTBindingSource != null)
                {
                    DEALHISTBindingSource.Dispose();
                    DEALHISTBindingSource = null;
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
            }
        }

        /// <summary>
        /// Start of Closed end Payment Posting routines
        /// </summary>
        /// <param name="worker"></param>
        public void NewClosedPaymentPosting(ref IACDataSet PAYMENTPostDataSet, ref BackgroundWorker worker, Boolean Post = false)
        {
            IACDataSetTableAdapters.AMORTIZETableAdapter AMORTIZETableAdapter = new IACDataSetTableAdapters.AMORTIZETableAdapter();
            IACDataSetTableAdapters.CUSTOMERTableAdapter CustomerTableAdapter = new IACDataSetTableAdapters.CUSTOMERTableAdapter();
            IACDataSetTableAdapters.PAYMENTTableAdapter PAYMENTTableAdapter = new IACDataSetTableAdapters.PAYMENTTableAdapter();
            IACDataSetTableAdapters.MasterTotalTempTableAdapter MasterTotalTempTableAdapter = new IACDataSetTableAdapters.MasterTotalTempTableAdapter();
            IACDataSetTableAdapters.NOTICETableAdapter NOTICETableAdapter = new IACDataSetTableAdapters.NOTICETableAdapter();
            IACDataSetTableAdapters.PaymentDistributionTableAdapter PaymentDistributionTableAdapter = new IACDataSetTableAdapters.PaymentDistributionTableAdapter();

            AMORTIZEBindingSource.DataSource = PAYMENTPostDataSet.AMORTIZE;
            CUSTOMERBindingSource.DataSource = PAYMENTPostDataSet.CUSTOMER;
            AmortTempBindingSource.DataSource = PAYMENTPostDataSet.AmortTemp;
            DEALERBindingSource.DataSource = PAYMENTPostDataSet.DEALER;
            DEALHISTBindingSource.DataSource = PAYMENTPostDataSet.DEALHIST;
            MASTERBindingSource.DataSource = PAYMENTPostDataSet.MASTER;
            MASTHISTBindingSource.DataSource = PAYMENTPostDataSet.MASTHIST;


            Int32 CustomerPos = 0, AmortPos = 0;
            lnCustUEI = 0; lnAccruedInt = 0; lnPaidDis = 0; lnIntPay = 0; lnDisPay = 0; lnPayDue = 0; lnBalance = 0;
            lnCustOP = 0; lnCustExt = 0; lnMasterExt = 0; lnMasterSundry = 0;
            lnMasterNP = 0; lnMasterNPNP = 0; lnMasterAmortNP = 0; lnMasterOloan = 0; lnMasterAmortOloan = 0; lnLateChargePaid = 0; lnMasterOP = 0;
            lnMasterUEI = 0; lnMasterInterest = 0; lnMasterDiscount = 0; lnMasterAmortInterest = 0; lnMasterAmortDiscount = 0;
            lnMasterSimpleInterest = 0; lnMasterSimpleDiscount = 0; lnPaidSimpleInt = 0; lnPaidSimpleDisc = 0; lnPrinciplePaid = 0;
            lnMasterSimpleOloan = 0; lnMasterSimpleNP = 0;

            PAYMENTTableAdapter.FillByAll(PAYMENTPostDataSet.PAYMENT);
            if (PAYMENTPostDataSet.PAYMENT.Rows.Count == 0)
            {
                MessageBox.Show("No new payments to post!", "New Payments Posting Error");
                return;
            }
            CustomerTableAdapter.FillByUnPostedPayments(PAYMENTPostDataSet.CUSTOMER);
            AMORTIZETableAdapter.FillByPayments(PAYMENTPostDataSet.AMORTIZE);
            // Moses Newman 04/28/2018 No need to have anymore than today data in here, going to phase this table out and use TVAmort
            PaymentDistributionTableAdapter.DeleteAll();
            //PaymentDistributionTableAdapter.DeleteAllbyDate(PAYMENTPostDataSet.PAYMENT.Rows[0].Field<DateTime>("PAYMENT_DATE"));
            // Moses Newman 03/18/2018 Add TempPT for multiple payment PaidThrough accuracy
            PAYMENTPostDataSet.CUSTOMER.Columns.Add("TempPT", typeof(String));
            Decimal CurrentBalance = 0;
            Object loCustomerPayCount = null;
            Decimal NewBalance = 0;
            Int32 lnCustomerPayCount = 0;
            for (int PaymentPos = 0; PaymentPos < PAYMENTPostDataSet.PAYMENT.Rows.Count; PaymentPos++)
            {
                lnCustomerPayCount = 0;
                CustomerPos = CUSTOMERBindingSource.Find("CUSTOMER_NO", PAYMENTPostDataSet.PAYMENT.Rows[PaymentPos].Field<String>("PAYMENT_CUSTOMER"));
                AmortPos = AMORTIZEBindingSource.Find("AMORTIZE_CUST_NO", PAYMENTPostDataSet.PAYMENT.Rows[PaymentPos].Field<String>("PAYMENT_CUSTOMER"));
                //try
                //{
                lnCustUEI = 0;
                lnAccruedInt = 0;
                lnPaidDis = 0;
                lnBalance = 0;
                lnTermRem = 0;
                lnLCBPay = 0;
                lnAPPPay = 0;
                lnCustOP = 0;
                lnCustExt = 0;
                lnPrinciplePaid = 0;
                lnPaidSimpleInt = 0;
                lnPaidSimpleDisc = 0;

                loCustomerPayCount = PAYMENTTableAdapter.PaymentCountByCustomer(PAYMENTPostDataSet.PAYMENT.Rows[PaymentPos].Field<String>("PAYMENT_CUSTOMER"));
                lnCustomerPayCount = (loCustomerPayCount != null) ? (Int32)loCustomerPayCount : 1;
                CurrentBalance = PAYMENTPostDataSet.CUSTOMER.Rows[CustomerPos].Field<Decimal>("CUSTOMER_BALANCE");
                NewBalance = 0;
                for (Int32 pcount = 0; pcount < lnCustomerPayCount; pcount++)
                {
                    // Moses Newman if on a multi payment customer one already closes the account, ignore the subsequent payments.
                    if (PAYMENTPostDataSet.CUSTOMER.Rows[CustomerPos].Field<String>("CUSTOMER_ACT_STAT") == "A")
                    {
                        // Moses Newman 01/20/2021 AmortizeBindingSource only has one record per customer! so AmortPos should always be 0 if found
                        NewBalance = ClosedPaymentProcessPayment(PaymentPos + pcount, CustomerPos, AmortPos, ref AMORTIZEBindingSource, ref PAYMENTPostDataSet, ref worker, Post, CurrentBalance, (lnCustomerPayCount > 1 && pcount < lnCustomerPayCount -1 ) ? true:false);
                        CurrentBalance = NewBalance;
                    }
                }
                PaymentPos += lnCustomerPayCount - 1;
                //}
                /*catch (Exception e)
                {
                    MessageBox.Show("Posting failed at CUSTOMER NO: " + PAYMENTPostDataSet.PAYMENT.Rows[PaymentPos].Field<String>("PAYMENT_CUSTOMER") + "Error Message: " + e.Message, "*** POSTING ERROR! ***", MessageBoxButtons.OK);
                }*/
                worker.ReportProgress((Int32)((Double)(((Double)PaymentPos + 1.0000) / (Double)PAYMENTPostDataSet.PAYMENT.Rows.Count) * 100.0000));
            }
            ClosedPaymentDealerPost(ref PAYMENTPostDataSet, ref worker);
            ClosedPaymentMasterPost(ref PAYMENTPostDataSet, ref worker);
            ClosedPaymentMASTHISTPost(ref PAYMENTPostDataSet, ref worker);
            MasterTotalTempTableAdapter.DeleteAll();
            MasterTotalTempTableAdapter.Insert(lnMasterNP, lnMasterUEI, lnMasterNPNP, lnMasterOloan, lnMasterOP, lnMasterExt, lnMasterSundry, lnISFTotal);

            worker.ReportProgress(56);
            if (Post)
            {
                // Moses Newman 03/18/2018 Now remove temporary column TempPT prior to write.
                PAYMENTPostDataSet.CUSTOMER.Columns.Remove("TempPT");
                ClosedPaymentWriteAllData(PAYMENTPostDataSet, ref worker);
                try
                {
                    NOTICETableAdapter.DeleteNonArrears();
                    PAYMENTTableAdapter.DeleteQueryAll();
                }
                catch (System.InvalidOperationException ex)
                {
                    MessageBox.Show("There was a database error deleting payment or notices for those no longer in arrears: " + ex.Message);
                }
                IACDataSetTableAdapters.CUSTOMERTableAdapter CUSTOMERTableAdapter = new IACDataSetTableAdapters.CUSTOMERTableAdapter();
            }
            worker.ReportProgress(100);
        }

        void ClosedPaymentWriteAllData(IACDataSet PAYMENTPostDataSet, ref BackgroundWorker worker)
        {
            IACDataSetTableAdapters.DEALERTableAdapter DEALERTableAdapter = new DEALERTableAdapter();
            IACDataSetTableAdapters.PAYMENTTableAdapter PAYMENTTableAdapter = new PAYMENTTableAdapter();
            Object loTotalIVR = null, loTotalIVRAmex = null, loTotalIVRFees = null;
            Decimal lnTotalIVR = 0, lnTotalIVRAmex = 0, lnTotalIVRFees = 0;
            loTotalIVR = PAYMENTTableAdapter.IVRSUM();
            loTotalIVRAmex = PAYMENTTableAdapter.AMEXTOT();
            loTotalIVRFees = PAYMENTTableAdapter.IVRFEETOT();
            lnTotalIVR = loTotalIVR != null ? (Decimal)loTotalIVR : lnTotalIVR;
            lnTotalIVRAmex = loTotalIVRAmex != null ? (Decimal)loTotalIVRAmex : lnTotalIVRAmex;
            lnTotalIVRFees = loTotalIVRFees != null ? (Decimal)loTotalIVRFees : lnTotalIVRFees;

            ClosedPaymentWriteCustomerChanges(ref PAYMENTPostDataSet, ref worker);
            ClosedPaymentWriteCustHistChanges(ref PAYMENTPostDataSet, ref worker);
            ClosedPaymentWriteDealerChanges(ref PAYMENTPostDataSet, ref worker);
            ClosedPaymentWriteDealHistChanges(ref PAYMENTPostDataSet, ref worker);
            ClosedPaymentWriteMASTerChanges(ref PAYMENTPostDataSet, ref worker);
            ClosedPaymentWriteMASTHistChanges(ref PAYMENTPostDataSet, ref worker);
            DailyDataSetTableAdapters.DailyBalanceTotalsTableAdapter DailyBalanceTotalsTableAdapter = new DailyDataSetTableAdapters.DailyBalanceTotalsTableAdapter();
            DailyDataSetTableAdapters.DailyDealerSummaryTableAdapter DailyDealerSummaryTableAdapter = new DailyDataSetTableAdapters.DailyDealerSummaryTableAdapter();
            DailyDataSetTableAdapters.DailyInterestTableAdapter DailyInterestTableAdapter = new DailyDataSetTableAdapters.DailyInterestTableAdapter();
            DailyDataSetTableAdapters.DailyPaymentTypeTotalsTableAdapter DailyPaymentTypeTotalsTableAdapter = new DailyDataSetTableAdapters.DailyPaymentTypeTotalsTableAdapter();
            DailyDataSet DailySet = new DailyDataSet();
            // Moses Newman 03/19/2021 Use todays date instead of the first record date PAYMENTPostDataSet.PAYMENT.Rows[0].Field<DateTime>("PAYMENT_DATE").Date
            DailyBalanceTotalsTableAdapter.Insert(DateTime.Now.Date,
                    lnMasterNP, lnMasterUEI, lnISFTotal, lnMasterNPNP, lnMasterNP + lnMasterUEI + lnMasterNPNP, lnMasterSimpleInterest, lnMasterAmortInterest, 0, (Decimal)lnDlrDiscount,
                    lnMasterSimpleInterest + lnMasterAmortInterest + (Decimal)lnDlrDiscount, lnMasterOloan, lnMasterNP + lnMasterUEI + lnMasterNPNP - lnMasterOloan, lnMasterSundry, lnMasterExt,
                    lnMasterNP + lnMasterUEI + lnMasterNPNP, lnTotalIVR, lnTotalIVRFees, lnTotalIVRAmex, lnMasterNP + (lnMasterUEI + lnMasterNPNP - lnMasterOloan) - (lnMasterSimpleInterest + lnMasterAmortInterest + (Decimal)lnDlrDiscount));
            for (int i = 0; i < PAYMENTPostDataSet.DEALER.Rows.Count; i++)
            {
                DailyDealerSummaryTableAdapter.Insert(DateTime.Now.Date.Date,
                                                      PAYMENTPostDataSet.DEALER.Rows[i].Field<String>("DEALER_ACC_NO"),
                                                      PAYMENTPostDataSet.DEALER.Rows[i].Field<Decimal>("DEALER_CUR_OLOAN"),
                                                      PAYMENTPostDataSet.DEALER.Rows[i].Field<Decimal>("DEALER_CUR_SIMPLE_INT"),
                                                      PAYMENTPostDataSet.DEALER.Rows[i].Field<Decimal>("DEALER_CUR_AMORT_INT"),
                                                      PAYMENTPostDataSet.DEALER.Rows[i].Field<Decimal>("DEALER_CUR_OLD_INT"));
            }
            DailyInterestTableAdapter.Insert(DateTime.Now.Date, "P", lnMasterNP + lnMasterUEI + lnMasterNPNP - lnMasterOloan, 0, (lnMasterNP + lnMasterUEI + lnMasterNPNP - lnMasterOloan) - (lnMasterSimpleInterest + lnMasterAmortInterest + (Decimal)lnDlrDiscount),
                                             new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.DaysInMonth(DateTime.Now.Year, DateTime.Now.Month)));
            for (int i = 0; i < PAYMENTPostDataSet.PaymentTypeCodeSummarySelect.Rows.Count; i++)
            {
                DailyPaymentTypeTotalsTableAdapter.Insert(DateTime.Now.Date,
                        PAYMENTPostDataSet.PaymentTypeCodeSummarySelect.Rows[i].Field<String>("PAYMENT_TYPE"),
                        PAYMENTPostDataSet.PaymentTypeCodeSummarySelect.Rows[i].Field<String>("PAYMENT_CODE_2"),
                        PAYMENTPostDataSet.PaymentTypeCodeSummarySelect.Rows[i].Field<String>("CreditCardType"),
                        PAYMENTPostDataSet.PaymentTypeCodeSummarySelect.Rows[i].Field<Int32>("TypeCount"),
                        PAYMENTPostDataSet.PaymentTypeCodeSummarySelect.Rows[i].Field<Decimal>("FeeTot"),
                        PAYMENTPostDataSet.PaymentTypeCodeSummarySelect.Rows[i].Field<Decimal>("TOTAL"));
            }
        }

        Decimal ClosedPaymentProcessPayment(Int32 PaymentPos, Int32 CustomerPos, Int32 AmortPos, ref BindingSource AmortizeBindingSource, ref IACDataSet PAYMENTDataSet, ref BackgroundWorker worker, Boolean post,Decimal CurBal, Boolean IsMulti)
        {
            Decimal lnTodaysBalance = 0;
            IACDataSetTableAdapters.AMORTIZETableAdapter AMORTIZETableAdapter = new IACDataSetTableAdapters.AMORTIZETableAdapter();
            // Moses Newman 07/10/2019 Fix CUSTOMER_PAID_INTEREST TO be TVAmortTableAdapter.InterestSoFar(CUSTOMER_NO), INSTEAD OF ACCUMULATING
            IACDataSetTableAdapters.TVAmortTableAdapter TVAmortTableAdapter = new IACDataSetTableAdapters.TVAmortTableAdapter();
            IACDataSetTableAdapters.PAYMENTTableAdapter PAYMENTTableAdapter = new PAYMENTTableAdapter();

            String lnAPaidThru = "0000", lnCustPaidThru = "0000", lnPaidThru = "0000";
            Decimal lnIOP = 0, lnLateChargeBal = PAYMENTDataSet.CUSTOMER.Rows[CustomerPos].Field<Decimal>("CUSTOMER_LATE_CHARGE_BAL");

            // Moses Newman 07/10/2019 Fix CUSTOMER_PAID_INTERESTTO be TVAmortTableAdapter.InterestSoFar(CUSTOMER_NO), INSTEAD OF ACCUMULATING
            Object loInterestSoFar = null;
            Decimal lnInterestSoFar = 0;

            lnSimpleBalance = 0;
            lnAPaidThru = PAYMENTDataSet.CUSTOMER.Rows[CustomerPos].Field<String>("CUSTOMER_PAID_THRU");
            lnCustPaidThru = PAYMENTDataSet.CUSTOMER.Rows[CustomerPos].Field<String>("CUSTOMER_PAID_THRU");

            lnAPPPay = (int)(PAYMENTDataSet.PAYMENT.Rows[PaymentPos].Field<Decimal>("PAYMENT_AMOUNT_RCV") / PAYMENTDataSet.CUSTOMER.Rows[CustomerPos].Field<Decimal>("CUSTOMER_REGULAR_AMOUNT"));
            lnLCBPay = PAYMENTDataSet.PAYMENT.Rows[PaymentPos].Field<Decimal>("PAYMENT_AMOUNT_RCV") % PAYMENTDataSet.CUSTOMER.Rows[CustomerPos].Field<Decimal>("CUSTOMER_REGULAR_AMOUNT");
            if (PAYMENTDataSet.CUSTOMER.Rows[CustomerPos].Field<Decimal>("CUSTOMER_LATE_CHARGE_BAL") > 0)
            {
                if (lnAPPPay == 0)
                    lnLCBPay = 0;
                if (lnLCBPay > PAYMENTDataSet.CUSTOMER.Rows[CustomerPos].Field<Decimal>("CUSTOMER_LATE_CHARGE_BAL"))
                    lnLCBPay = PAYMENTDataSet.CUSTOMER.Rows[CustomerPos].Field<Decimal>("CUSTOMER_LATE_CHARGE_BAL");
            }
            lnTodaysBalance = CurBal;
            // Moses Newman 08/2/2013 Store pre-processing balance
            /*lnTodaysBalance = Program.TVSimpleGetBuyout(PAYMENTDataSet,
                                               PAYMENTDataSet.PAYMENT.Rows[PaymentPos].Field<DateTime>("PAYMENT_DATE"),
                                               (Double)PAYMENTDataSet.CUSTOMER.Rows[CustomerPos].Field<Int32>("CUSTOMER_TERM"),
                                               (Double)(PAYMENTDataSet.CUSTOMER.Rows[CustomerPos].Field<Decimal>("CUSTOMER_ANNUAL_PERCENTAGE_RATE") / 100),
                                               (Double)PAYMENTDataSet.CUSTOMER.Rows[CustomerPos].Field<Decimal>("CUSTOMER_REGULAR_AMOUNT"),
                                               PAYMENTDataSet.CUSTOMER.Rows[CustomerPos].Field<String>("CUSTOMER_NO"),
                // Moses Newman 04/30/2017 Add support for Simple Interest and Normal Daily Compounding
                                               PAYMENTDataSet.CUSTOMER.Rows[CustomerPos].Field<String>("CUSTOMER_AMORTIZE_IND") == "S" ? true : false, true, false, false, -1, true);
            */
            lnOldBalance = CurBal; // Moses Newman 11/18/2020 change to parameter so the case of more than one payment from the same customer can be dealt with.  
            if (PAYMENTDataSet.CUSTOMER.Rows[CustomerPos].Field<String>("CUSTOMER_ACT_STAT") == "A" &&
                PAYMENTDataSet.CUSTOMER.Rows[CustomerPos].Field<String>("CUSTOMER_BUY_OUT") != "N") // Moses Newman 02/17/2021  make N if Active and Y
                PAYMENTDataSet.CUSTOMER.Rows[CustomerPos].SetField<String>("CUSTOMER_BUY_OUT", "N");  

            //lnOldBalance = 0;
            // Moses Newman 05/01/2018 ALWAYS use last history balance rather than CUSTOMER_BALANCE because
            // CUSTOMER_BALANCE is changed at the first run of this routine!
            IACDataSetTableAdapters.CUSTHISTTableAdapter CUSTHISTTableAdapter = new IACDataSetTableAdapters.CUSTHISTTableAdapter();
            /*Object loLastBalance = null;
            if (lnOldBalance == 0)
            {
                loLastBalance = CUSTHISTTableAdapter.LastBalance(PAYMENTDataSet.CUSTOMER.Rows[CustomerPos].Field<String>("CUSTOMER_NO"));
                if (loLastBalance != null)
                    lnOldBalance = (Decimal)loLastBalance;
            }*/
            switch (PAYMENTDataSet.CUSTOMER.Rows[CustomerPos].Field<String>("CUSTOMER_AMORTIZE_IND"))
            {
                // Amortization using no compounding US RULE SIMPLE INTEREST
                case "S":
                case "N":
                    lnIntPay = SimpleInterestPaymentAllocation(PaymentPos, AmortPos, CustomerPos, ref AmortizeBindingSource, ref PAYMENTDataSet, ref worker, post);
                    // Moses Newman 12/16/2014 lnOldBalance must be BALANCE as of TODAY 
                    break;
                // Old flat interest method (Divide total interest on loan by the term)
                default:
                    lnIntPay = Math.Round((PAYMENTDataSet.CUSTOMER.Rows[CustomerPos].Field<Decimal>("CUSTOMER_LOAN_INTEREST") / PAYMENTDataSet.CUSTOMER.Rows[CustomerPos].Field<Int32>("CUSTOMER_TERM")), 2);
                    break;
            }

            lnDisPay = Math.Round((PAYMENTDataSet.CUSTOMER.Rows[CustomerPos].Field<Decimal>("CUSTOMER_DEALER_DISC") / PAYMENTDataSet.CUSTOMER.Rows[CustomerPos].Field<Int32>("CUSTOMER_TERM")), 2);
            // Moses Newman 08/24/2013 Remove int override
            if (PAYMENTDataSet.CUSTOMER.Rows[CustomerPos].Field<Decimal>("CUSTOMER_DEALER_DISC") == 0 || PAYMENTDataSet.CUSTOMER.Rows[CustomerPos].Field<Decimal>("CUSTOMER_DEALER_DISC_BAL") == 0)
                lnDlrDisc = 0;
            else
                lnDlrDisc = Math.Round(Convert.ToDouble(PAYMENTDataSet.CUSTOMER.Rows[CustomerPos].Field<Decimal>("CUSTOMER_DEALER_DISC_BAL") / PAYMENTDataSet.CUSTOMER.Rows[CustomerPos].Field<Int32>("CUSTOMER_PAY_REM_2")), 2);
            lnCustPaidThru = PAYMENTDataSet.CUSTOMER.Rows[CustomerPos].Field<String>("CUSTOMER_PAID_THRU");
            lnPaidThru = PAYMENTDataSet.CUSTOMER.Rows[CustomerPos].Field<String>("CUSTOMER_PAID_THRU");
            PaidThru(CustomerPos, ref PAYMENTDataSet);
            lnPTDiff = lnTodayDiff;

            if (lnPTDiff == 0)
                lnPayDue = PAYMENTDataSet.CUSTOMER.Rows[CustomerPos].Field<Decimal>("CUSTOMER_LATE_CHARGE_BAL");
            else
                if (lnPTDiff > 0)
                    lnPayDue = PAYMENTDataSet.CUSTOMER.Rows[CustomerPos].Field<Decimal>("CUSTOMER_CONTRACT_STATUS") * -1;
                else
                    lnPayDue = PAYMENTDataSet.CUSTOMER.Rows[CustomerPos].Field<Decimal>("CUSTOMER_REGULAR_AMOUNT") - PAYMENTDataSet.CUSTOMER.Rows[CustomerPos].Field<Decimal>("CUSTOMER_CONTRACT_STATUS");
            // Moses Newman 06/24/2014 Set payments remaining to 0 if NULL
            if (PAYMENTDataSet.CUSTOMER.Rows[CustomerPos].Field<Nullable<Int32>>("CUSTOMER_PAY_REM_2") == null)
                PAYMENTDataSet.CUSTOMER.Rows[CustomerPos].SetField<Int32>("CUSTOMER_PAY_REM_2", 0);
            // Moses Newman 06/24/2014 Set Number of payments made = 0 if NULL
            if (PAYMENTDataSet.CUSTOMER.Rows[CustomerPos].Field<Nullable<Int32>>("CUSTOMER_NO_OF_PAYMENTS_MADE") == null)
                PAYMENTDataSet.CUSTOMER.Rows[CustomerPos].SetField<Int32>("CUSTOMER_NO_OF_PAYMENTS_MADE", 0);
            if ((PAYMENTDataSet.CUSTOMER.Rows[CustomerPos].Field<Int32>("CUSTOMER_TERM") == PAYMENTDataSet.CUSTOMER.Rows[CustomerPos].Field<Int32>("CUSTOMER_PAY_REM_2")) && PAYMENTDataSet.CUSTOMER.Rows[CustomerPos].Field<Decimal>("CUSTOMER_BUYOUT") == 0)
            {
                lnTermRem = PAYMENTDataSet.CUSTOMER.Rows[CustomerPos].Field<Int32>("CUSTOMER_TERM");
                ClosedPaymentCalculatebuyout(PaymentPos, CustomerPos, ref PAYMENTDataSet, ref worker);
            }
            lnLateChargePaid = 0;
            // Moses Newman 12/01/2014 no longer call ClosedPaymentHandleLateCharge or do any CUSTOMER_LATE_CHARGE_BAL handling
            // because its all now done in GetPartialPaymentandLateFeeBalance
            if (PAYMENTDataSet.CUSTOMER.Rows[CustomerPos].Field<Decimal?>("CUSTOMER_LATE_CHARGE") == null)
                PAYMENTDataSet.CUSTOMER.Rows[CustomerPos].SetField<Decimal>("CUSTOMER_LATE_CHARGE", 0);
            if (PAYMENTDataSet.CUSTOMER.Rows[CustomerPos].Field<Decimal>("CUSTOMER_LATE_CHARGE") < 0)
                PAYMENTDataSet.CUSTOMER.Rows[CustomerPos].SetField<Decimal>("CUSTOMER_LATE_CHARGE", 0);

            // Moses Newman 08/12/2013 Test against balance BEFORE payment is applied!
            if (PAYMENTDataSet.PAYMENT.Rows[PaymentPos].Field<Decimal>("PAYMENT_AMOUNT_RCV") == lnTodaysBalance)
                ClosedPaymentEqualBalance(PaymentPos, CustomerPos, ref PAYMENTDataSet, ref worker);
            else
                if (PAYMENTDataSet.PAYMENT.Rows[PaymentPos].Field<Decimal>("PAYMENT_AMOUNT_RCV") > lnTodaysBalance)
                {
                    lnBalance = PAYMENTDataSet.PAYMENT.Rows[PaymentPos].Field<Decimal>("PAYMENT_AMOUNT_RCV");
                    // Moses Newman 02/17/2021 Don't set CUSTOMER_BUY_OUT = "N" even on overpayments!
                    ClosedPaymentOverPayment(CustomerPos, ref PAYMENTDataSet, ref worker);
                }
                else
                {
                    lnBalance = PAYMENTDataSet.PAYMENT.Rows[PaymentPos].Field<Decimal>("PAYMENT_AMOUNT_RCV");
                    PAYMENTDataSet.CUSTOMER.Rows[CustomerPos].SetField<String>("CUSTOMER_BUY_OUT", "N");
                }
            // Moses Newman 11/12/2020 Get real credit to note (Payment - Accrued Interest) so that is is for only one of the payments if the same account had
            // multiple payments today.
            String CustTemp = PAYMENTDataSet.PAYMENT.Rows[PaymentPos].Field<String>("PAYMENT_CUSTOMER");
            //lnSimpleDiff = lnSimpleBalance -lnOldBalance;
            //lnSimpleDiff = (lnBalance - lnIntPay) *-1;
            //if(Math.Abs(lnSimpleDiff - (lnSimpleBalance - lnOldBalance)) > (Decimal).01)
            lnSimpleDiff = lnSimpleBalance - lnOldBalance;
            //if(lnIntPay == 0)
            //lnIntPay = PAYMENTDataSet.PAYMENT.Rows[PaymentPos].Field<Decimal>("PAYMENT_AMOUNT_RCV")+lnSimpleDiff;
            // Moses Newman 11/30/2020 INSUF will not show in amort, so the interest it causes must be 0 IF more than one payment today; 

            lnAccruedInt = lnIntPay;

            PAYMENTDataSet.CUSTOMER.Rows[CustomerPos].SetField<Decimal>("CUSTOMER_PREV_BALANCE", lnOldBalance);
            lnNonCashFeesandCharges = lnSimpleDiff - lnBalance - lnIntPay;
            if (PAYMENTDataSet.CUSTOMER.Rows[CustomerPos].Field<Decimal>("CUSTOMER_CONTRACT_STATUS") > lnSimpleBalance)
                PAYMENTDataSet.CUSTOMER.Rows[CustomerPos].SetField<Decimal>("CUSTOMER_CONTRACT_STATUS", lnSimpleBalance);
            else
                if (PAYMENTDataSet.CUSTOMER.Rows[CustomerPos].Field<Decimal>("CUSTOMER_CONTRACT_STATUS") < 0)
                {
                    //Moses Newman 01/21/2015 Checking absolute value so must multiply by -1!
                    lnAVStatus = PAYMENTDataSet.CUSTOMER.Rows[CustomerPos].Field<Decimal>("CUSTOMER_CONTRACT_STATUS") * -1;
                    if (lnAVStatus > lnSimpleBalance)
                        PAYMENTDataSet.CUSTOMER.Rows[CustomerPos].SetField<Decimal>("CUSTOMER_CONTRACT_STATUS", lnSimpleBalance * -1);
                }

            ClosedPaymentPartialPayment(PaymentPos, CustomerPos, ref PAYMENTDataSet, ref worker, post);
            // Moses Newman 01/29/2015 Move CloseOut AFTER GetPartialPaymentandLateFeeBalance happens!
            //if (CurBal == 0)
            if (lnSimpleBalance == 0)
                ClosedPaymentCloseOut(CustomerPos, ref PAYMENTDataSet, ref worker);

            //Update Interest and Dealer Discount Paid fields
            // Moses Newman 04/30/2017 Handle S simple interest or N Normal Daily Compounding
            if (PAYMENTDataSet.CUSTOMER.Rows[CustomerPos].Field<String>("CUSTOMER_AMORTIZE_IND") == "Y" || PAYMENTDataSet.CUSTOMER.Rows[CustomerPos].Field<String>("CUSTOMER_AMORTIZE_IND") == "S" || PAYMENTDataSet.CUSTOMER.Rows[CustomerPos].Field<String>("CUSTOMER_AMORTIZE_IND") == "N")
            {
                lnAccruedInt = lnIntPay;
                // Moses Newman 04/30/2017 Handle S simple interest or N Normal Daily Compounding
                if (PAYMENTDataSet.CUSTOMER.Rows[CustomerPos].Field<String>("CUSTOMER_AMORTIZE_IND") == "S" || PAYMENTDataSet.CUSTOMER.Rows[CustomerPos].Field<String>("CUSTOMER_AMORTIZE_IND") == "N")
                {
                    lnPaidSimpleInt = lnIntPay;
                    lnPaidSimpleDisc = Math.Round(lnDisPay * lnNoPay, 2);
                }
            }
            else
                lnAccruedInt = Math.Round(lnIntPay * lnNoPay, 2);
            lnPaidDis = Math.Round(lnDisPay * lnNoPay, 2);
            lnPaidDiscount = Math.Round(lnDlrDiscount * lnNoPay, 2);
            PAYMENTDataSet.CUSTOMER.Rows[CustomerPos].SetField<Decimal>("CUSTOMER_DEALER_DISC_BAL", PAYMENTDataSet.CUSTOMER.Rows[CustomerPos].Field<Decimal>("CUSTOMER_DEALER_DISC_BAL") - Convert.ToDecimal(lnPaidDiscount));
            loInterestSoFar = TVAmortTableAdapter.InterestSoFar(PAYMENTDataSet.CUSTOMER.Rows[CustomerPos].Field<String>("CUSTOMER_NO"));
            if(loInterestSoFar != null)
                lnInterestSoFar = (Decimal)loInterestSoFar;
            PAYMENTDataSet.CUSTOMER.Rows[CustomerPos].SetField<Decimal>("CUSTOMER_PAID_INTEREST", lnInterestSoFar);
            // Moses Newman 05/12/2013 with simple interest paid interest can easily be greater than the estimated interest!
            // Moses Newman 04/30/2017 Handle S simple interest or N Normal Daily Compounding
            if (PAYMENTDataSet.CUSTOMER.Rows[CustomerPos].Field<String>("CUSTOMER_AMORTIZE_IND") != "S" && PAYMENTDataSet.CUSTOMER.Rows[CustomerPos].Field<String>("CUSTOMER_AMORTIZE_IND") != "N")
            {
                if (PAYMENTDataSet.CUSTOMER.Rows[CustomerPos].Field<Decimal>("CUSTOMER_PAID_INTEREST") > PAYMENTDataSet.CUSTOMER.Rows[CustomerPos].Field<Decimal>("CUSTOMER_LOAN_INTEREST"))
                {
                    lnIOP = PAYMENTDataSet.CUSTOMER.Rows[CustomerPos].Field<Decimal>("CUSTOMER_PAID_INTEREST") - PAYMENTDataSet.CUSTOMER.Rows[CustomerPos].Field<Decimal>("CUSTOMER_LOAN_INTEREST");
                    PAYMENTDataSet.CUSTOMER.Rows[CustomerPos].SetField<Decimal>("CUSTOMER_PAID_INTEREST", PAYMENTDataSet.CUSTOMER.Rows[CustomerPos].Field<Decimal>("CUSTOMER_LOAN_INTEREST"));
                    lnAccruedInt = Math.Round(lnAccruedInt - lnIOP, 2);
                }
            }
            PAYMENTDataSet.CUSTOMER.Rows[CustomerPos].SetField<Double>("CUSTOMER_PAID_DISCOUNT", Math.Round(PAYMENTDataSet.CUSTOMER.Rows[CustomerPos].Field<Double>("CUSTOMER_PAID_DISCOUNT") - lnDlrDiscount, 2));
            if (PAYMENTDataSet.CUSTOMER.Rows[CustomerPos].Field<Double>("CUSTOMER_PAID_DISCOUNT") > Convert.ToDouble(PAYMENTDataSet.CUSTOMER.Rows[CustomerPos].Field<Decimal>("CUSTOMER_DEALER_DISC")))
            {
                lnIOP = (Decimal)(PAYMENTDataSet.CUSTOMER.Rows[CustomerPos].Field<Double>("CUSTOMER_PAID_DISCOUNT") - (Double)PAYMENTDataSet.CUSTOMER.Rows[CustomerPos].Field<Decimal>("CUSTOMER_DEALER_DISC"));
                PAYMENTDataSet.CUSTOMER.Rows[CustomerPos].SetField<Double>("CUSTOMER_PAID_DISCOUNT", Convert.ToDouble(PAYMENTDataSet.CUSTOMER.Rows[CustomerPos].Field<Decimal>("CUSTOMER_DEALER_DISC")));
                lnPaidDis = Math.Round(lnPaidDis - lnIOP, 2);
            }                                                                                                 // GetPartialPaymentandLateFeeBalance
                                                                                                              // Moses Newman 12/1/2014 NO LONGER USING CUSTOMER_PAYMENTS MADE AS AN ACCUMULATOR, IT GETS SET IN   GetPartialPaymentandLateFeeBalance
                                                                                                              // Moses Newman 08/12/2013 mark customer's with 0 or overpaid balances to Inactive!
            if (lnSimpleBalance == 0)
            //if (CurBal == 0)
            {
                lnTermRem = 0;
                PAYMENTDataSet.CUSTOMER.Rows[CustomerPos].SetField<String>("CUSTOMER_ACT_STAT", "I");
            }
            else
            {
                lnTermRem = PAYMENTDataSet.CUSTOMER.Rows[CustomerPos].Field<Int32>("CUSTOMER_TERM") - PAYMENTDataSet.CUSTOMER.Rows[CustomerPos].Field<Int32>("CUSTOMER_NO_OF_PAYMENTS_MADE");
                if (lnTermRem < 0)
                    lnTermRem = 0;
            }
            // Moses Newman 12/1/2014 NO LONGER USING CUSTOMER_PAY_REM_2 (Payments Remaining) AS AN ACCUMULATOR, IT GETS SET IN GetPartialPaymentandLateFeeBalance           
            if (PAYMENTDataSet.CUSTOMER.Rows[CustomerPos].Field<Nullable<Decimal>>("CUSTOMER_HIGHEST_BALANCE_DUE") == null)
                PAYMENTDataSet.CUSTOMER.Rows[CustomerPos].SetField<Decimal>("CUSTOMER_HIGHEST_BALANCE_DUE", 0);
            if (Convert.ToDecimal(lnPayDue) > PAYMENTDataSet.CUSTOMER.Rows[CustomerPos].Field<Decimal>("CUSTOMER_HIGHEST_BALANCE_DUE"))
                PAYMENTDataSet.CUSTOMER.Rows[CustomerPos].SetField<Decimal>("CUSTOMER_HIGHEST_BALANCE_DUE", Convert.ToDecimal(lnPayDue));
            if (lnSimpleBalance == 0)
                //if (CurBal == 0)
                ClosedPaymentCalculatebuyout(PaymentPos, CustomerPos, ref PAYMENTDataSet, ref worker);
            SumDealerTotals(PaymentPos, CustomerPos, ref PAYMENTDataSet, ref worker);
            if (PAYMENTDataSet.CUSTOMER.Rows[CustomerPos].Field<String>("CUSTOMER_ACT_STAT") != "R")
            {
                ClosedPaymentAccumIOL(PaymentPos, ref PAYMENTDataSet, ref worker);
                // Moses Newman 04/30/2017 Handle Simple interest and Normal Daily Compunding!
                if (PAYMENTDataSet.CUSTOMER.Rows[CustomerPos].Field<String>("CUSTOMER_AMORTIZE_IND") == "Y" ||
                    PAYMENTDataSet.CUSTOMER.Rows[CustomerPos].Field<String>("CUSTOMER_AMORTIZE_IND") == "S" ||
                    PAYMENTDataSet.CUSTOMER.Rows[CustomerPos].Field<String>("CUSTOMER_AMORTIZE_IND") == "N")
                    ClosedPaymentAmortAccumIOL(PaymentPos, ref PAYMENTDataSet, ref worker);
            }
            MovePaymenttoCustHist(PaymentPos, CustomerPos, AmortPos, ref PAYMENTDataSet, ref worker, post);

            if (PAYMENTDataSet.PAYMENT.Rows[PaymentPos].Field<Decimal>("PAYMENT_AMOUNT_RCV") < 0 && PAYMENTDataSet.PAYMENT.Rows[PaymentPos].Field<String>("PAYMENT_TYPE") != "I")
            {
                PAYMENTDataSet.AMORTIZE.Rows[AmortPos].SetField<Decimal>("AMORTIZE_LAST_INTEREST_APPLIED", SavedInterestApplied);
            }
        return lnSimpleBalance;
        }

        public Decimal SimpleInterestPaymentAllocation(Int32 PaymentPos, Int32 AmortPos, Int32 CustomerPos, ref BindingSource AmortizeBindingSource, ref IACDataSet PAYMENTDataSet, ref BackgroundWorker worker, Boolean post)
        {
            IACDataSetTableAdapters.PaymentDistributionTableAdapter PaymentDistributionTableAdapter = new IACDataSetTableAdapters.PaymentDistributionTableAdapter();
            IACDataSetTableAdapters.TVAmortTableAdapter TVAmortTableAdapter = new IACDataSetTableAdapters.TVAmortTableAdapter();
            BindingSource PaymentDistributionBindingsource = new BindingSource();
            Object loIntPaid = null;

            PaymentDistributionBindingsource.DataSource = PAYMENTDataSet.PaymentDistribution;

            lnPaidSimpleInt = 0;
            lnLateChargePaid = 0;

            lnMoneyRemaining = PAYMENTDataSet.PAYMENT.Rows[PaymentPos].Field<Decimal>("PAYMENT_AMOUNT_RCV");
            lnMoneyRemaining -= lnLCBPay;
            // Buyout as of today is balance
            /*lnSimpleBalance = Program.TVSimpleGetBuyout(PAYMENTDataSet,
                                                PAYMENTDataSet.PAYMENT.Rows[PaymentPos].Field<DateTime>("PAYMENT_DATE"),
                                                (Double)PAYMENTDataSet.CUSTOMER.Rows[CustomerPos].Field<Int32>("CUSTOMER_TERM"),
                                                (Double)(PAYMENTDataSet.CUSTOMER.Rows[CustomerPos].Field<Decimal>("CUSTOMER_ANNUAL_PERCENTAGE_RATE") / 100),
                                                (Double)PAYMENTDataSet.CUSTOMER.Rows[CustomerPos].Field<Decimal>("CUSTOMER_REGULAR_AMOUNT"),
                                                PAYMENTDataSet.CUSTOMER.Rows[CustomerPos].Field<String>("CUSTOMER_NO"),
                                                // Moses Newman 04/30/2017 Handle Simple interest or Daily Compunding
                                                PAYMENTDataSet.CUSTOMER.Rows[CustomerPos].Field<String>("CUSTOMER_AMORTIZE_IND") == "S" ? true:false, true, false, true, PaymentPos, true);
            */
            // Moses Newman 10/17/2018 Make sure we have latest amort for both payments if multiple payments for same customer!
            GetPartialPaymentandLateFeeBalance(ref worker, PAYMENTDataSet.CUSTOMER.Rows[CustomerPos].Field<String>("CUSTOMER_NO"), ref PAYMENTDataSet, CustomerPos, true, PaymentPos, false);
            TVAmortTableAdapter.FillByCustomerNoandPaymentSeq(PAYMENTDataSet.TVAmort, PAYMENTDataSet.CUSTOMER.Rows[CustomerPos].Field<String>("CUSTOMER_NO"), PAYMENTDataSet.PAYMENT.Rows[PaymentPos].Field<Int32>("SeqNo"));
            lnPrinciplePaid = 0;
            String TempCust = PAYMENTDataSet.CUSTOMER.Rows[CustomerPos].Field<String>("CUSTOMER_NO");
            if (PAYMENTDataSet.TVAmort.Rows.Count > 0)
            {
                lnPaidSimpleInt = PAYMENTDataSet.TVAmort.Rows[0].Field<Decimal>("Interest");
                lnPrinciplePaid = PAYMENTDataSet.TVAmort.Rows[0].Field<Decimal>("Principal");
                if (lnPrinciplePaid == 0)
                    lnPrinciplePaid = 0 - lnPaidSimpleInt;
            }
            else
            {
                if (PAYMENTDataSet.CUSTOMER.Rows[CustomerPos].Field<Nullable<DateTime>>("CUSTOMER_LAST_PAYMENT_DATE") != null)
                    loIntPaid = TVAmortTableAdapter.InterestSinceLastPayment(PAYMENTDataSet.CUSTOMER.Rows[CustomerPos].Field<String>("CUSTOMER_NO"), PAYMENTDataSet.CUSTOMER.Rows[CustomerPos].Field<DateTime>("CUSTOMER_LAST_PAYMENT_DATE"), DateTime.Now.Date);
                else
                    loIntPaid = TVAmortTableAdapter.InterestSoFar(PAYMENTDataSet.CUSTOMER.Rows[CustomerPos].Field<String>("CUSTOMER_NO"));
                if (loIntPaid != null)
                    lnPaidSimpleInt = (Decimal)loIntPaid;
                else
                    lnPaidSimpleInt = 0;
            }
            TVAmortTableAdapter.FillByCustomerNo(PAYMENTDataSet.TVAmort, PAYMENTDataSet.CUSTOMER.Rows[CustomerPos].Field<String>("CUSTOMER_NO"));
            // Moses Newman 8/9/2013 need to add a new field on summary for ISF and NOT include in total cash.
            if (PAYMENTDataSet.PAYMENT.Rows[PaymentPos].Field<String>("PAYMENT_TYPE") == "I")
            {
                lnISFTotal += PAYMENTDataSet.PAYMENT.Rows[PaymentPos].Field<Decimal>("PAYMENT_AMOUNT_RCV");
                if (PAYMENTDataSet.PAYMENT.Rows[PaymentPos].Field<Nullable<DateTime>>("PAYMENT_ISF_DATE") != null)
                {
                    // Moses Newman 05/17/2013 Interest Paid and Late Charge Paid must be changed to negative because now we are returning those amounts.
                    lnPaidSimpleInt = PAYMENTDataSet.PAYMENT.Rows[PaymentPos].Field<Decimal>("PAYMENT_CURR_INT") * -1;
                    lnLateChargePaid = PAYMENTDataSet.PAYMENT.Rows[PaymentPos].Field<Decimal>("PAYMENT_LATE_CHARGE_PAID") * -1;
                    lnMoneyRemaining = PAYMENTDataSet.PAYMENT.Rows[PaymentPos].Field<Decimal>("PAYMENT_AMOUNT_RCV");
                    lnMoneyRemaining -= lnLateChargePaid;
                }
            }
            lnIntPay = lnPaidSimpleInt;
            lnMoneyRemaining -= (Decimal)lnPaidSimpleInt;
            if (PAYMENTDataSet.PAYMENT.Rows[PaymentPos].Field<String>("PAYMENT_TYPE") == "I" && PAYMENTDataSet.PAYMENT.Rows[PaymentPos].Field<Nullable<DateTime>>("PAYMENT_ISF_DATE") != null)
                lnPrinciplePaid = lnMoneyRemaining - (Decimal)lnPaidSimpleInt;
            else
                if(lnPrinciplePaid == 0)
                    lnPrinciplePaid = PAYMENTDataSet.TVAmort.Rows[PAYMENTDataSet.TVAmort.Rows.Count - 2].Field<Decimal>("Principal");

            lnMoneyRemaining = 0;
            PAYMENTDataSet.AMORTIZE.Rows[AmortPos].SetField<Decimal>("AMORTIZE_INTEREST_PAID_TOT", PAYMENTDataSet.AMORTIZE.Rows[AmortPos].Field<Decimal>("AMORTIZE_INTEREST_PAID_TOT") + (Decimal)lnIntPay);
            PAYMENTDataSet.AMORTIZE.Rows[AmortPos].SetField<Decimal>("AMORTIZE_PRINCIPLE_PAID_TOT", PAYMENTDataSet.AMORTIZE.Rows[AmortPos].Field<Decimal>("AMORTIZE_PRINCIPLE_PAID_TOT") + lnPrinciplePaid);
            
            // Moses Newman 04/30/2018 why touch CUSTOMER_BALANCE until post!?!
            PAYMENTDataSet.CUSTOMER.Rows[CustomerPos].SetField<Decimal>("CUSTOMER_BALANCE", lnSimpleBalance);
            return (Decimal)lnPaidSimpleInt;
        }

        void PaidThru(int CustomerPos, ref IACDataSet PAYMENTDataSet)
        {
            IACDataSetTableAdapters.TVAmortTableAdapter TVAmortTableAdapter = new IACDataSetTableAdapters.TVAmortTableAdapter();
            int lnActDateDiff = 0;
            String lsTempPaidThru = "";
            DateTime ldNewPaidThru;
            IACDataSet.TVAmortDataTable TVAmort = PAYMENTDataSet.TVAmort;
            IACDataSet.CUSTOMERDataTable CUSTOMER = PAYMENTDataSet.CUSTOMER;

            // Moses Newman 11/23/2014 We already have the new payment in TVAmort because TimeValue routine was called is SimpleInterestAmortAllocation,
            // So try and grab the SQL Server function CorrectPaidThrough instead of using old method of adding to existing paid thru.   
            Object loPaidThru = TVAmortTableAdapter.PaidThrough(PAYMENTDataSet.CUSTOMER.Rows[CustomerPos].Field<String>("CUSTOMER_NO"));
            if (loPaidThru != null)
            {
                lsTempPaidThru = (String)loPaidThru;

                if (PAYMENTDataSet.CUSTOMER.Rows[CustomerPos].Field<Int32>("CUSTOMER_DAY_DUE") == 30 && Convert.ToInt32(((String)loPaidThru).Substring(0, 2)) == 2)
                {
                    lsTempPaidThru = "03/01/" + DateTime.Now.Year.ToString().Substring(0, 2) + ((String)loPaidThru).Substring(2, 2);
                    ldNewPaidThru = DateTime.Parse(lsTempPaidThru).Date;
                    ldNewPaidThru = ldNewPaidThru.AddDays(-1);     // Last day of February
                }
                else
                {
                    lsTempPaidThru = ((String)loPaidThru).Substring(0, 2) + "/" + PAYMENTDataSet.CUSTOMER.Rows[CustomerPos].Field<Int32>("CUSTOMER_DAY_DUE").ToString().TrimStart() + "/" + DateTime.Now.Year.ToString().Substring(0, 2) + ((String)loPaidThru).Substring(2, 2);
                    ldNewPaidThru = DateTime.Parse(lsTempPaidThru).Date;
                }
            }
            else
            {
                if (PAYMENTDataSet.CUSTOMER.Rows[CustomerPos].Field<Int32>("CUSTOMER_DAY_DUE") == 30 && Convert.ToInt32(PAYMENTDataSet.CUSTOMER.Rows[CustomerPos].Field<String>("CUSTOMER_PAID_THRU").Substring(0, 2)) == 2)
                {
                    lsTempPaidThru = "03/01/" + DateTime.Now.Year.ToString().Substring(0, 2) + PAYMENTDataSet.CUSTOMER.Rows[CustomerPos].Field<String>("CUSTOMER_PAID_THRU").Substring(2, 2);
                    ldNewPaidThru = DateTime.Parse(lsTempPaidThru).Date;
                    ldNewPaidThru = ldNewPaidThru.AddDays(-1);     // Last day of February
                }
                else
                {
                    lsTempPaidThru = PAYMENTDataSet.CUSTOMER.Rows[CustomerPos].Field<String>("CUSTOMER_PAID_THRU").Substring(0, 2) + "/" + PAYMENTDataSet.CUSTOMER.Rows[CustomerPos].Field<Int32>("CUSTOMER_DAY_DUE").ToString().TrimStart() + "/" + DateTime.Now.Year.ToString().Substring(0, 2) + PAYMENTDataSet.CUSTOMER.Rows[CustomerPos].Field<String>("CUSTOMER_PAID_THRU").Substring(2, 2);
                    ldNewPaidThru = DateTime.Parse(lsTempPaidThru).Date;
                }
                ldNewPaidThru = ldNewPaidThru.AddMonths(lnNoPay);      // Add number of payments to get next Paid Through Date.
            }


            TimeSpan ltActDateDiff;

            ltActDateDiff = DateTime.Now.Subtract(ldNewPaidThru);
            lnActDateDiff = ((Int32)(ltActDateDiff.TotalDays / 30));
            lnTodayDiff = lnActDateDiff;
            TVAmortTableAdapter.Dispose();
            TVAmortTableAdapter = null;
            // Moses Newman 11/24/2014 We have new paid through so save it NOW and not in move payment to customer!!!
            PAYMENTDataSet.CUSTOMER.Rows[CustomerPos].SetField<String>("CUSTOMER_PAID_THRU", ldNewPaidThru.Month.ToString().TrimStart().PadLeft(2, '0') + ldNewPaidThru.Year.ToString().TrimStart().Substring(2, 2).PadLeft(2, '0'));
        }

        void MovePaymenttoCustHist(int PaymentPos, int CustomerPos, int AmortPos, ref IACDataSet PAYMENTDataSet, ref BackgroundWorker worker, Boolean Post = false)
        { 
            int lnSeq = 0;
            Object loCustHistSeq;
            DataRow[] FoundItems = null;

            String lsCustKey = "", lsExpression = "", lsSort = "";

            DateTime ldCustDate;

            IACDataSetTableAdapters.AMORTIZETableAdapter AMORTIZETableAdapter = new IACDataSetTableAdapters.AMORTIZETableAdapter();
            IACDataSetTableAdapters.CUSTHISTTableAdapter CUSTHISTTableAdapter = new IACDataSetTableAdapters.CUSTHISTTableAdapter();
            BindingSource CUSTHISTBindingSource = new BindingSource();
            CUSTHISTBindingSource.DataSource = PAYMENTDataSet.CUSTHIST;

            TicketsTableAdapters.TicketHeaderTableAdapter TicketHeaderTableAdapter = new TicketsTableAdapters.TicketHeaderTableAdapter();
            TicketsTableAdapters.TicketDetailTableAdapter TicketDetailTableAdapter = new TicketsTableAdapters.TicketDetailTableAdapter();

            //This code gets the next available sequence number for todays date if another history record for today exists
            loCustHistSeq = CUSTHISTTableAdapter.SeqNoQuery(PAYMENTDataSet.PAYMENT.Rows[PaymentPos].Field<String>("PAYMENT_CUSTOMER"), PAYMENTDataSet.PAYMENT.Rows[PaymentPos].Field<DateTime>("PAYMENT_DATE"));
            if (loCustHistSeq != null)
                lnSeq = (int)loCustHistSeq + 1;
            else
                lnSeq = 1;
            lsCustKey = PAYMENTDataSet.PAYMENT.Rows[PaymentPos].Field<String>("PAYMENT_CUSTOMER");
            ldCustDate = PAYMENTDataSet.PAYMENT.Rows[PaymentPos].Field<DateTime>("PAYMENT_DATE");
            
            // If any history records with the same customer no already exist in the DataTable, we must check IT for the last sequence number.
            lsExpression = "CUSTHIST_NO = \'" + lsCustKey + "\' and CUSTHIST_PAY_DATE = \'" + ldCustDate.ToShortDateString() + "\' and max(CUSTHIST_DATE_SEQ) > 0";
            lsSort = "CUSTHIST_DATE_SEQ desc";
            FoundItems = PAYMENTDataSet.CUSTHIST.Select(lsExpression, lsSort);

            if (FoundItems.Length != 0)
            {
                lnSeq = FoundItems[0].Field<Int32>("CUSTHIST_DATE_SEQ") + 1;
            }
            
            CUSTHISTBindingSource.AddNew();
            CUSTHISTBindingSource.EndEdit();

            PAYMENTDataSet.CUSTHIST.Rows[CUSTHISTBindingSource.Position].SetField<String>("CUSTHIST_NO", PAYMENTDataSet.PAYMENT.Rows[PaymentPos].Field<String>("PAYMENT_CUSTOMER"));
            PAYMENTDataSet.CUSTHIST.Rows[CUSTHISTBindingSource.Position].SetField<String>("CUSTHIST_ADD_ON", PAYMENTDataSet.PAYMENT.Rows[PaymentPos].Field<String>("PAYMENT_ADD_ON"));
            PAYMENTDataSet.CUSTHIST.Rows[CUSTHISTBindingSource.Position].SetField<String>("CUSTHIST_IAC_TYPE", PAYMENTDataSet.PAYMENT.Rows[PaymentPos].Field<String>("PAYMENT_IAC_TYPE"));
            PAYMENTDataSet.CUSTHIST.Rows[CUSTHISTBindingSource.Position].SetField<DateTime>("CUSTHIST_PAY_DATE", PAYMENTDataSet.PAYMENT.Rows[PaymentPos].Field<DateTime>("PAYMENT_DATE"));
            PAYMENTDataSet.CUSTHIST.Rows[CUSTHISTBindingSource.Position].SetField<Nullable<DateTime>>("CUSTHIST_ISF_DATE", PAYMENTDataSet.PAYMENT.Rows[PaymentPos].Field<Nullable<DateTime>>("PAYMENT_ISF_DATE"));
            // Moses Newman 04/13/2018 Add ISFSeqNo, ISFPaymentType, and ISFPaymentCode so that selected bounced check can be located.
            PAYMENTDataSet.CUSTHIST.Rows[CUSTHISTBindingSource.Position].SetField<Nullable<Int32>>("ISFSeqNo", PAYMENTDataSet.PAYMENT.Rows[PaymentPos].Field<Nullable<Int32>>("ISFSeqNo"));
            PAYMENTDataSet.CUSTHIST.Rows[CUSTHISTBindingSource.Position].SetField<String>("ISFPaymentType", PAYMENTDataSet.PAYMENT.Rows[PaymentPos].Field<String>("ISFPaymentType"));
            PAYMENTDataSet.CUSTHIST.Rows[CUSTHISTBindingSource.Position].SetField<String>("ISFPaymentCode", PAYMENTDataSet.PAYMENT.Rows[PaymentPos].Field<String>("ISFPaymentCode"));
            // Moses Newman 10/10/2020
            PAYMENTDataSet.CUSTHIST.Rows[CUSTHISTBindingSource.Position].SetField<Nullable<Int32>>("ISFID", PAYMENTDataSet.PAYMENT.Rows[PaymentPos].Field<Nullable<Int32>>("ISFID"));
            PAYMENTDataSet.CUSTHIST.Rows[CUSTHISTBindingSource.Position].SetField<Int32>("CUSTHIST_DATE_SEQ", lnSeq);
            // Moses Newman 03/15/2018 Added TransactionDate, Fee, FromIVR
            if (PAYMENTDataSet.PAYMENT.Rows[PaymentPos].Field<Nullable<DateTime>>("TransactionDate") == null)
                PAYMENTDataSet.PAYMENT.Rows[PaymentPos].SetField<DateTime>("TransactionDate", PAYMENTDataSet.PAYMENT.Rows[PaymentPos].Field<DateTime>("PAYMENT_DATE"));
            PAYMENTDataSet.CUSTHIST.Rows[CUSTHISTBindingSource.Position].SetField<DateTime>("TransactionDate", PAYMENTDataSet.PAYMENT.Rows[PaymentPos].Field<DateTime>("TransactionDate"));
            PAYMENTDataSet.CUSTHIST.Rows[CUSTHISTBindingSource.Position].SetField<Decimal>("Fee", PAYMENTDataSet.PAYMENT.Rows[PaymentPos].Field<Decimal>("Fee"));
            PAYMENTDataSet.CUSTHIST.Rows[CUSTHISTBindingSource.Position].SetField<Boolean>("FromIVR", PAYMENTDataSet.PAYMENT.Rows[PaymentPos].Field<Boolean>("FromIVR"));
            PAYMENTDataSet.CUSTHIST.Rows[CUSTHISTBindingSource.Position].SetField<String>("CUSTHIST_ACT_STAT", PAYMENTDataSet.CUSTOMER.Rows[CustomerPos].Field<String>("CUSTOMER_ACT_STAT"));
            PAYMENTDataSet.CUSTHIST.Rows[CUSTHISTBindingSource.Position].SetField<Decimal>("CUSTHIST_BALANCE", PAYMENTDataSet.CUSTOMER.Rows[CustomerPos].Field<Decimal>("CUSTOMER_BALANCE"));
            PAYMENTDataSet.CUSTHIST.Rows[CUSTHISTBindingSource.Position].SetField<Decimal>("CUSTHIST_PAID_DISCOUNT", Convert.ToDecimal(PAYMENTDataSet.CUSTOMER.Rows[CustomerPos].Field<Double>("CUSTOMER_PAID_DISCOUNT")));
            PAYMENTDataSet.CUSTHIST.Rows[CUSTHISTBindingSource.Position].SetField<Decimal>("CUSTHIST_PAID_INTEREST", PAYMENTDataSet.CUSTOMER.Rows[CustomerPos].Field<Decimal>("CUSTOMER_PAID_INTEREST"));
            PAYMENTDataSet.CUSTHIST.Rows[CUSTHISTBindingSource.Position].SetField<Decimal>("CUSTHIST_PAYMENT_RCV", PAYMENTDataSet.PAYMENT.Rows[PaymentPos].Field<Decimal>("PAYMENT_AMOUNT_RCV"));
            PAYMENTDataSet.CUSTHIST.Rows[CUSTHISTBindingSource.Position].SetField<Decimal>("CUSTHIST_LATE_CHARGE", 0);
            PAYMENTDataSet.CUSTOMER.Rows[CustomerPos].SetField<Decimal>("CUSTOMER_LATE_CHARGE", 0);
            PAYMENTDataSet.CUSTHIST.Rows[CUSTHISTBindingSource.Position].SetField<Decimal>("CUSTHIST_LATE_CHARGE_BAL", PAYMENTDataSet.CUSTOMER.Rows[CustomerPos].Field<Decimal>("CUSTOMER_LATE_CHARGE_BAL"));
            PAYMENTDataSet.CUSTHIST.Rows[CUSTHISTBindingSource.Position].SetField<Decimal>("CUSTHIST_LATE_CHARGE_PAID", Convert.ToDecimal(lnLateChargePaid));
            PAYMENTDataSet.CUSTHIST.Rows[CUSTHISTBindingSource.Position].SetField<Decimal>("CUSTHIST_BUYOUT", PAYMENTDataSet.CUSTOMER.Rows[CustomerPos].Field<Decimal>("CUSTOMER_BUYOUT"));
            PAYMENTDataSet.CUSTHIST.Rows[CUSTHISTBindingSource.Position].SetField<String>("CUSTHIST_AUTO_PAY", PAYMENTDataSet.PAYMENT.Rows[PaymentPos].Field<String>("PAYMENT_AUTO_PAY"));
            // Moses Newman 01/22/2013 Create a function to add payment descriptors
            Program.MarkPaymentDescriptor(ref PAYMENTDataSet, CustomerPos, CUSTHISTBindingSource.Position, PaymentPos);
            PAYMENTDataSet.CUSTHIST.Rows[CUSTHISTBindingSource.Position].SetField<Int32>("CUSTHIST_PAY_REM_2", PAYMENTDataSet.CUSTOMER.Rows[CustomerPos].Field<Int32>("CUSTOMER_PAY_REM_2"));
            PAYMENTDataSet.CUSTHIST.Rows[CUSTHISTBindingSource.Position].SetField<String>("CUSTHIST_PAYMENT_TYPE", PAYMENTDataSet.PAYMENT.Rows[PaymentPos].Field<String>("PAYMENT_TYPE"));
            PAYMENTDataSet.CUSTHIST.Rows[CUSTHISTBindingSource.Position].SetField<String>("CUSTHIST_PAYMENT_CODE", PAYMENTDataSet.PAYMENT.Rows[PaymentPos].Field<String>("PAYMENT_CODE_2"));
            PAYMENTDataSet.CUSTHIST.Rows[CUSTHISTBindingSource.Position].SetField<Int32>("CUSTHIST_THRU_UD", PAYMENTDataSet.PAYMENT.Rows[PaymentPos].Field<Int32>("PAYMENT_THRU_UD"));
            // Moses Newman 11/04/2021 Keep track of total extensions
            if (PAYMENTDataSet.PAYMENT.Rows[PaymentPos].Field<Int32>("PAYMENT_THRU_UD") > 0)
                PAYMENTDataSet.CUSTOMER.Rows[CustomerPos].SetField<Int32>("CUSTOMER_TOTAL_EXT", PAYMENTDataSet.CUSTOMER.Rows[CustomerPos].Field<Int32>("CUSTOMER_TOTAL_EXT") + PAYMENTDataSet.PAYMENT.Rows[PaymentPos].Field<Int32>("PAYMENT_THRU_UD"));
            // Moses Newman 08/18/2021 Begin Mod
            if (PAYMENTDataSet.PAYMENT.Rows[PaymentPos].Field<Int32?>("TicketID") != null)
            {
                PAYMENTDataSet.CUSTHIST.Rows[CUSTHISTBindingSource.Position].SetField<Int32>("TicketID", PAYMENTDataSet.PAYMENT.Rows[PaymentPos].Field<Int32>("TicketID"));
                if (Post) // Only mark posted if this is really the posting and not the 07 report!
                {
                    TicketHeaderTableAdapter.MarkPosted(PAYMENTDataSet.PAYMENT.Rows[PaymentPos].Field<Int32>("TicketID"));
                    if (PAYMENTDataSet.PAYMENT.Rows[PaymentPos].Field<Int32?>("TicketDetailID") != null)
                        TicketDetailTableAdapter.MarkPosted(PAYMENTDataSet.PAYMENT.Rows[PaymentPos].Field<Int32>("TicketID"), PAYMENTDataSet.PAYMENT.Rows[PaymentPos].Field<Int32>("TicketDetailID"));
                }
            }
            if (PAYMENTDataSet.PAYMENT.Rows[PaymentPos].Field<Int32?>("TicketDetailID") != null)
                PAYMENTDataSet.CUSTHIST.Rows[CUSTHISTBindingSource.Position].SetField<Int32>("TicketDetailID", PAYMENTDataSet.PAYMENT.Rows[PaymentPos].Field<Int32>("TicketDetailID"));
            // Moses Newman 08/18/2021 End Mod

            if (PAYMENTDataSet.CUSTOMER.Rows[CustomerPos].Field<String>("CUSTOMER_AMORTIZE_IND") == "Y" && PAYMENTDataSet.CUSTOMER.Rows[CustomerPos].Field<String>("CUSTOMER_BUY_OUT") == "Y" && PAYMENTDataSet.CUSTOMER.Rows[CustomerPos].Field<String>("CUSTOMER_PAY_REM_1") == "PAID")
                PAYMENTDataSet.CUSTHIST.Rows[CUSTHISTBindingSource.Position].SetField<Decimal>("CUSTHIST_CURR_INT", PAYMENTDataSet.CUSTOMER.Rows[CustomerPos].Field<Decimal>("CUSTOMER_PAID_INT") - SavedPaidInterest);
            else
                if (AmortPos != -1)
                    PAYMENTDataSet.CUSTHIST.Rows[CUSTHISTBindingSource.Position].SetField<Decimal>("CUSTHIST_CURR_INT", PAYMENTDataSet.AMORTIZE.Rows[AmortPos].Field<Decimal>("AMORTIZE_LAST_INTEREST_APPLIED"));
                else
                    PAYMENTDataSet.CUSTHIST.Rows[CUSTHISTBindingSource.Position].SetField<Decimal>("CUSTHIST_CURR_INT", 0);
            // Moses Newman 12/16/2020 Handle RateChanges
            if (PAYMENTDataSet.PAYMENT.Rows[PaymentPos].Field<String>("PAYMENT_TYPE") == "F")
            {
                PAYMENTDataSet.CUSTHIST.Rows[CUSTHISTBindingSource.Position].SetField<String>("CUSTHIST_PAY_REM_1", "RTCHG");
                PAYMENTDataSet.CUSTHIST.Rows[CUSTHISTBindingSource.Position].SetField<Decimal>("TVRateChange", 
                    (PAYMENTDataSet.CUSTOMER.Rows[CustomerPos].Field<String>("CUSTOMER_INT_OVERRIDE") == "Y") ? 
                        0:PAYMENTDataSet.CUSTOMER.Rows[CustomerPos].Field<Decimal>("CUSTOMER_ANNUAL_PERCENTAGE_RATE"));
            }
            MovePaymenttoCustomer(PaymentPos, CustomerPos, ref PAYMENTDataSet, ref worker); //Calls ClosePaymentNewcontractStatus so this must happen before next line!
            PAYMENTDataSet.CUSTHIST.Rows[CUSTHISTBindingSource.Position].SetField<Decimal>("CUSTHIST_CONTRACT_STATUS", PAYMENTDataSet.CUSTOMER.Rows[CustomerPos].Field<Decimal>("CUSTOMER_CONTRACT_STATUS"));
            PAYMENTDataSet.CUSTHIST.Rows[CUSTHISTBindingSource.Position].SetField<String>("CUSTHIST_PAID_THRU", PAYMENTDataSet.CUSTOMER.Rows[CustomerPos].Field<String>("CUSTOMER_PAID_THRU"));
            // Moses Newman 11/29/2014 start saving partial payment to customer history from now on!
            PAYMENTDataSet.CUSTHIST.Rows[CUSTHISTBindingSource.Position].SetField<Decimal>("PartialPayment", PAYMENTDataSet.CUSTOMER.Rows[CustomerPos].Field<Decimal>("PartialPayment"));
        }

        void MovePaymenttoCustomer(int PaymentPos, int CustomerPos, ref IACDataSet PAYMENTDataSet, ref BackgroundWorker worker)
        {
            PAYMENTDataSet.CUSTOMER.Rows[CustomerPos].SetField<Decimal>("CUSTOMER_LAST_PAYMENT_MADE", PAYMENTDataSet.PAYMENT.Rows[PaymentPos].Field<Decimal>("PAYMENT_AMOUNT_RCV"));
            PAYMENTDataSet.CUSTOMER.Rows[CustomerPos].SetField<DateTime>("CUSTOMER_LAST_PAYMENT_DATE", PAYMENTDataSet.PAYMENT.Rows[PaymentPos].Field<DateTime>("PAYMENT_DATE"));
            PAYMENTDataSet.CUSTOMER.Rows[CustomerPos].SetField<Int32>("CUSTOMER_FORM_NO", 0);
            PAYMENTDataSet.CUSTOMER.Rows[CustomerPos].SetField<String>("CUSTOMER_POST_IND", "P");
            lnArrears = PAYMENTDataSet.CUSTOMER.Rows[CustomerPos].Field<Decimal>("CUSTOMER_CONTRACT_STATUS");
            PAYMENTDataSet.CUSTOMER.Rows[CustomerPos].SetField<Int32>("CUSTOMER_LAST_LC_DATE", 0);
            PAYMENTDataSet.CUSTOMER.Rows[CustomerPos].SetField<String>("CUSTOMER_PAYMENT_TYPE", PAYMENTDataSet.PAYMENT.Rows[PaymentPos].Field<String>("PAYMENT_TYPE"));
            PAYMENTDataSet.CUSTOMER.Rows[CustomerPos].SetField<String>("CUSTOMER_PAYMENT_CODE", PAYMENTDataSet.PAYMENT.Rows[PaymentPos].Field<String>("PAYMENT_CODE_2"));
            PAYMENTDataSet.CUSTOMER.Rows[CustomerPos].SetField<String>("CUSTOMER_TSB_COMMENT_CODE", PAYMENTDataSet.PAYMENT.Rows[PaymentPos].Field<String>("PAYMENT_TSB_COMMENT_CODE"));
            // Moses Newman 05/12/2013 NO UNEARNED INTEREST ON SIMPLE INTEREST LOANS AT BUYOUT!
            // Moses Newman 04/30/2017 S for simple N for Normal
            if (PAYMENTDataSet.CUSTOMER.Rows[CustomerPos].Field<String>("CUSTOMER_AMORTIZE_IND") != "S" && PAYMENTDataSet.CUSTOMER.Rows[CustomerPos].Field<String>("CUSTOMER_AMORTIZE_IND") != "N")
            {
                if (PAYMENTDataSet.CUSTOMER.Rows[CustomerPos].Field<String>("CUSTOMER_BUY_OUT") == "Y" && PAYMENTDataSet.CUSTOMER.Rows[CustomerPos].Field<String>("CUSTOMER_PAY_REM_1").TrimEnd() == "PAID")
                    PAYMENTDataSet.CUSTOMER.Rows[CustomerPos].SetField<Decimal>("CUSTOMER_UE_INTEREST", Convert.ToDecimal(lnCustUEI));
                else
                    PAYMENTDataSet.CUSTOMER.Rows[CustomerPos].SetField<Decimal>("CUSTOMER_UE_INTEREST", PAYMENTDataSet.CUSTOMER.Rows[CustomerPos].Field<Decimal>("CUSTOMER_LOAN_INTEREST") - PAYMENTDataSet.CUSTOMER.Rows[CustomerPos].Field<Decimal>("CUSTOMER_PAID_INTEREST"));
            }
            else
                PAYMENTDataSet.CUSTOMER.Rows[CustomerPos].SetField<Decimal>("CUSTOMER_UE_INTEREST", 0);
        }

        public void ClosedPaymentNewContractStatus(int CustomerPos, ref IACDataSet PAYMENTDataSet)
        {
            // Moses Newman 05/28/2014 Changed to use new stored procedure.
            if (PAYMENTDataSet.CUSTOMER.Rows[CustomerPos].Field<String>("CUSTOMER_PAY_REM_1") == null)
                PAYMENTDataSet.CUSTOMER.Rows[CustomerPos].SetField<String>("CUSTOMER_PAY_REM_1", "");
            if (PAYMENTDataSet.CUSTOMER.Rows[CustomerPos].Field<String>("CUSTOMER_PAY_REM_1").TrimEnd() == "PAID")
            {
                PAYMENTDataSet.CUSTOMER.Rows[CustomerPos].SetField<Decimal>("CUSTOMER_CONTRACT_STATUS", 0);
                return;
            }
            Decimal lnContractStatus = 0;
            Object loContractStatus = null;
            IACDataSetTableAdapters.CUSTOMERTableAdapter CUSTOMERTableAdapter = new IACDataSetTableAdapters.CUSTOMERTableAdapter();
            IACDataSetTableAdapters.CUSTHISTTableAdapter CUSTHISTTableAdapter = new IACDataSetTableAdapters.CUSTHISTTableAdapter();
            loContractStatus = CUSTHISTTableAdapter.ContractStatus(PAYMENTDataSet.CUSTOMER.Rows[CustomerPos].Field<String>("CUSTOMER_NO"),DateTime.Now.Date,"",0,true);
            if (loContractStatus != null)
                lnContractStatus = (Decimal)loContractStatus;
            PAYMENTDataSet.CUSTOMER.Rows[CustomerPos].SetField<Decimal>("CUSTOMER_CONTRACT_STATUS", lnContractStatus);
            loContractStatus = null;
            CUSTOMERTableAdapter.Dispose();
            CUSTOMERTableAdapter = null;
            CUSTHISTTableAdapter.Dispose();
            CUSTHISTTableAdapter = null;

            if (PAYMENTDataSet.CUSTOMER.Rows[CustomerPos].Field<Decimal>("PartialPayment") < 0)
                PAYMENTDataSet.CUSTOMER.Rows[CustomerPos].SetField<Decimal>("PartialPayment", 0);
        }

        void ClosedPaymentOverPayment(int CustomerPos, ref IACDataSet PAYMENTDataSet, ref BackgroundWorker worker)
        {
            if (PAYMENTDataSet.CUSTOMER.Rows[CustomerPos].Field<Decimal>("CUSTOMER_BALANCE") >= 0)
                return;
            // Moses Newman 02/17/2021 Set to Y if closed no matter what!!!
            // Moses Newman 04/10/2021 Loan never closes now without 0 balance so NEVER set CUSTOMER_BUY_OUT = Y!
            PAYMENTDataSet.CUSTOMER.Rows[CustomerPos].SetField<String>("CUSTOMER_BUY_OUT", "N");
            // With TimeValue OverPayment is simply customer balance * -1.
            lnCustOP = PAYMENTDataSet.CUSTOMER.Rows[CustomerPos].Field<Decimal>("CUSTOMER_BALANCE") * -1;
            lnMasterSundry += lnCustOP;
        }


        void ClosedPaymentEqualBalance(int PaymentPos, int CustomerPos, ref IACDataSet PAYMENTDataSet, ref BackgroundWorker worker)
        {
            lnCustOP = 0;  //  Moses Newman 02/04/2021 
            // With TValue balance is the new buyout!
            PAYMENTDataSet.CUSTOMER.Rows[CustomerPos].SetField<String>("CUSTOMER_BUY_OUT", "Y");
            lnBalance = PAYMENTDataSet.PAYMENT.Rows[PaymentPos].Field<Decimal>("PAYMENT_AMOUNT_RCV");
            // Moses Newman 02/04/2021
            lnMasterUEI = 0;
            lnCustUEI = 0;
        }

        void ClosedPaymentOverBuyout(int PaymentPos, int CustomerPos, ref IACDataSet PAYMENTDataSet, ref BackgroundWorker worker)
        {
            // Moses Newman 02/17/2021 Set to Y if closed no matter what!!!
            PAYMENTDataSet.CUSTOMER.Rows[CustomerPos].SetField<String>("CUSTOMER_BUY_OUT", "Y");
            // With TValue Balance is the new Buyout!
            lnCustOP = PAYMENTDataSet.PAYMENT.Rows[PaymentPos].Field<Decimal>("PAYMENT_AMOUNT_RCV") - PAYMENTDataSet.CUSTOMER.Rows[CustomerPos].Field<Decimal>("CUSTOMER_BALANCE");
            lnMasterSundry += lnCustOP;
        }

        void ClosedPaymentProcessBuyout(int PaymentPos, int CustomerPos, ref IACDataSet PAYMENTDataSet, ref BackgroundWorker worker)
        {
            PAYMENTDataSet.CUSTOMER.Rows[CustomerPos].SetField<String>("CUSTOMER_BUY_OUT", "Y");
            // Moses Newman 04/30/2017 Handle S for Simple N for Normal!
            if (PAYMENTDataSet.CUSTOMER.Rows[CustomerPos].Field<String>("CUSTOMER_AMORTIZE_IND") != "S" || PAYMENTDataSet.CUSTOMER.Rows[CustomerPos].Field<String>("CUSTOMER_AMORTIZE_IND") != "N")
            {
                lnBalance = PAYMENTDataSet.CUSTOMER.Rows[CustomerPos].Field<Decimal>("CUSTOMER_BALANCE");
                lnMasterUEI += PAYMENTDataSet.CUSTOMER.Rows[CustomerPos].Field<Decimal>("CUSTOMER_BALANCE") - PAYMENTDataSet.CUSTOMER.Rows[CustomerPos].Field<Decimal>("CUSTOMER_BUYOUT");
                lnCustUEI = PAYMENTDataSet.CUSTOMER.Rows[CustomerPos].Field<Decimal>("CUSTOMER_BALANCE") - PAYMENTDataSet.CUSTOMER.Rows[CustomerPos].Field<Decimal>("CUSTOMER_BUYOUT");
            }
            else
            // No Unearned Interest on a Simple Interest Loan
            {
                // Outstanding Loans ONLY reduced by payment itself if NOT a Pre-Calculated Loan. (No Unearned Interest in this case)
                lnBalance = PAYMENTDataSet.PAYMENT.Rows[PaymentPos].Field<Decimal>("PAYMENT_AMOUNT_RCV");
                lnMasterUEI = 0;
                lnCustUEI = 0;
            }
        }

        void ClosedPaymentCloseOut(int CustomerPos, ref IACDataSet PAYMENTDataSet, ref BackgroundWorker worker)
        {
            // Moses Newman 02/17/2021 Set to Y if closed no matter what!!!
            PAYMENTDataSet.CUSTOMER.Rows[CustomerPos].SetField<String>("CUSTOMER_BUY_OUT", "Y");
            // Moses Newman 08/2/2013 never update customer balance except with TimeValue Data!!!
            // PAYMENTDataSet.CUSTOMER.Rows[CustomerPos].SetField<Decimal>("CUSTOMER_BALANCE", 0);
            PAYMENTDataSet.CUSTOMER.Rows[CustomerPos].SetField<Decimal>("CUSTOMER_LATE_CHARGE_BAL", 0);
            PAYMENTDataSet.CUSTOMER.Rows[CustomerPos].SetField<Decimal>("CUSTOMER_BUYOUT", 0);
            PAYMENTDataSet.CUSTOMER.Rows[CustomerPos].SetField<Decimal>("CUSTOMER_CONTRACT_STATUS", 0);
            PAYMENTDataSet.CUSTOMER.Rows[CustomerPos].SetField<String>("CUSTOMER_PAY_REM_1", "PAID");
        }

        public void ClosedPaymentCalculatebuyout(Int32 PaymentPos, Int32 CustomerPos, ref IACDataSet PAYMENTDataSet, ref BackgroundWorker worker, String tsBuyoutDate = "", Boolean tbSave = true, Boolean tbCutoff = false)
        {
            Decimal lnBuyout = 0;
            IACDataSet.STATEREBDataTable STATEREB = new IACDataSet.STATEREBDataTable();

            IACDataSetTableAdapters.STATEREBTableAdapter STATEREBTableAdapter = new IACDataSetTableAdapters.STATEREBTableAdapter();
            // Moses Newman 04/30/2017 Handle S for Simple N for Normal!
            if (PAYMENTDataSet.CUSTOMER.Rows[CustomerPos].Field<String>("CUSTOMER_AMORTIZE_IND") == "S" || PAYMENTDataSet.CUSTOMER.Rows[CustomerPos].Field<String>("CUSTOMER_AMORTIZE_IND") == "N")
            {
                if (PaymentPos > -1)
                    // Buyout as of End of Month is Buyout!
                    lnBuyout = Program.TVSimpleGetBuyout(PAYMENTDataSet,
                                       PAYMENTDataSet.PAYMENT.Rows[PaymentPos].Field<DateTime>("PAYMENT_DATE"),
                                       (Double)PAYMENTDataSet.CUSTOMER.Rows[CustomerPos].Field<Int32>("CUSTOMER_TERM"),
                                       (Double)(PAYMENTDataSet.CUSTOMER.Rows[CustomerPos].Field<Decimal>("CUSTOMER_ANNUAL_PERCENTAGE_RATE") / 100),
                                       (Double)PAYMENTDataSet.CUSTOMER.Rows[CustomerPos].Field<Decimal>("CUSTOMER_REGULAR_AMOUNT"),
                                        PAYMENTDataSet.CUSTOMER.Rows[CustomerPos].Field<String>("CUSTOMER_NO"),
                                        // Moses Newman 04/30/2017 Handle Simple Interest US Rule OR Normal Daily Compounding
                                        PAYMENTDataSet.CUSTOMER.Rows[CustomerPos].Field<String>("CUSTOMER_AMORTIZE_IND") == "S" ? true:false, tbSave, true, true, PaymentPos);
                else
                {
                    DateTime ldBuyoutDate = DateTime.Parse(tsBuyoutDate);
                    lnBuyout = Program.TVSimpleGetBuyout(PAYMENTDataSet,
                               ldBuyoutDate,
                               (Double)PAYMENTDataSet.CUSTOMER.Rows[CustomerPos].Field<Int32>("CUSTOMER_TERM"),
                               (Double)(PAYMENTDataSet.CUSTOMER.Rows[CustomerPos].Field<Decimal>("CUSTOMER_ANNUAL_PERCENTAGE_RATE") / 100),
                               (Double)PAYMENTDataSet.CUSTOMER.Rows[CustomerPos].Field<Decimal>("CUSTOMER_REGULAR_AMOUNT"),
                               PAYMENTDataSet.CUSTOMER.Rows[CustomerPos].Field<String>("CUSTOMER_NO"),
                               // Moses Newman 04/30/2017 Handle Simple Interest US Rule OR Normal Daily Compounding
                               PAYMENTDataSet.CUSTOMER.Rows[CustomerPos].Field<String>("CUSTOMER_AMORTIZE_IND") == "S" ? true : false, tbSave, true, false, -1, tbCutoff);
                }
                PAYMENTDataSet.CUSTOMER.Rows[CustomerPos].SetField<Decimal>("CUSTOMER_BUYOUT", lnBuyout);
            }
            else
            {
                STATEREBTableAdapter.Fill(STATEREB, PAYMENTDataSet.CUSTOMER.Rows[CustomerPos].Field<String>("CUSTOMER_STATE"));
                if (STATEREB.Rows.Count == 0)
                    return;
                if (STATEREB.Rows[0].Field<String>("REBATE_CODE") != "78" && STATEREB.Rows[0].Field<String>("REBATE_CODE") != "AC")
                    return;
                switch (STATEREB.Rows[0].Field<String>("REBATE_STATE"))
                {
                    case "ND":
                        if (PAYMENTDataSet.CUSTOMER.Rows[CustomerPos].Field<Decimal>("CUSTOMER_LOAN_AMOUNT") < 10000)
                        {
                            ClosedPaymentBuyoutBy78S(PaymentPos, CustomerPos, ref PAYMENTDataSet, ref worker);
                            return;
                        }
                        goto default;
                    case "MT":
                        if (PAYMENTDataSet.CUSTOMER.Rows[CustomerPos].Field<Int32>("CUSTOMER_TERM") < 61)
                        {
                            ClosedPaymentBuyoutBy78S(PaymentPos, CustomerPos, ref PAYMENTDataSet, ref worker);
                            return;
                        }
                        goto default;
                    case "NH":
                        if (PAYMENTDataSet.CUSTOMER.Rows[CustomerPos].Field<Int32>("CUSTOMER_TERM") < 48)
                        {
                            ClosedPaymentBuyoutBy78S(PaymentPos, CustomerPos, ref PAYMENTDataSet, ref worker);
                            return;
                        }
                        goto default;
                    default:
                        if (STATEREB.Rows[0].Field<String>("REBATE_CODE") == "78")
                        {
                            ClosedPaymentBuyoutBy78S(PaymentPos, CustomerPos, ref PAYMENTDataSet, ref worker);
                            return;
                        }
                        break;
                }
                // Moses Newman 0824/2013 NO MORE INTEREST OVERRIDE!
                /*
                if (PAYMENTDataSet.CUSTOMER.Rows[CustomerPos].Field<String>("CUSTOMER_INT_OVERRIDE") == "Y")
                    PAYMENTDataSet.CUSTOMER.Rows[CustomerPos].SetField<Decimal>("CUSTOMER_LOAN_INTEREST", 0);
                else*/
                lnNewInt = Convert.ToDouble(PAYMENTDataSet.CUSTOMER.Rows[CustomerPos].Field<Decimal>("CUSTOMER_LOAN_INTEREST"));
                lnDisInt = Math.Round(lnNewInt / Convert.ToDouble(PAYMENTDataSet.CUSTOMER.Rows[CustomerPos].Field<Int32>("CUSTOMER_TERM")), 2);
                lnNoDis = Math.Round((lnDisInt * Convert.ToDouble(PAYMENTDataSet.CUSTOMER.Rows[CustomerPos].Field<Int32>("CUSTOMER_NUMBER_OF_MONTHS"))) + 25, 2);
                lnRebate = Math.Round(lnNewInt - lnNoDis, 2);
                PAYMENTDataSet.CUSTOMER.Rows[CustomerPos].SetField<Decimal>("CUSTOMER_BUYOUT", Convert.ToDecimal(Math.Round(Convert.ToDouble(PAYMENTDataSet.CUSTOMER.Rows[CustomerPos].Field<Decimal>("CUSTOMER_BALANCE")) - lnRebate, 2)));
            }
        }

        // Calculate buyout by rule of 78s No BUYOUT table use standard rule of 78s formula instead
        public void ClosedPaymentBuyoutBy78S(Int32 PaymentPos, Int32 CustomerPos, ref IACDataSet PAYMENTDataSet, ref BackgroundWorker worker)
        {
            Double lnBuyoutPercent = 0, lnMonthsEarly = 0, lnTerm = 0, lnUnearnerdInterest = 0, lnLoanInterest = 0;

            if (PAYMENTDataSet.CUSTOMER.Rows[CustomerPos].Field<String>("CUSTOMER_INT_OVERRIDE") == "Y" ||
                (PAYMENTDataSet.CUSTOMER.Rows[CustomerPos].Field<Int32>("CUSTOMER_UPD_COUNT") >= (PAYMENTDataSet.CUSTOMER.Rows[CustomerPos].Field<Int32>("CUSTOMER_TERM") - 2)) ||
                (PAYMENTDataSet.CUSTOMER.Rows[CustomerPos].Field<Decimal>("CUSTOMER_LOAN_INTEREST") == 0))
            {
                PAYMENTDataSet.CUSTOMER.Rows[CustomerPos].SetField<Decimal>("CUSTOMER_BUYOUT", PAYMENTDataSet.CUSTOMER.Rows[CustomerPos].Field<Decimal>("CUSTOMER_BALANCE"));
                return;
            }
            if (PAYMENTDataSet.CUSTOMER.Rows[CustomerPos].Field<Int32>("CUSTOMER_UPD_COUNT") == 0)
            {
                if (PaymentPos > -1)  // Moses added to handle a call from MonthUpdate by sending a -1 as PaymentPos
                    PAYMENTDataSet.CUSTOMER.Rows[CustomerPos].SetField<Decimal>("CUSTOMER_BUYOUT", PAYMENTDataSet.CUSTOMER.Rows[CustomerPos].Field<Decimal>("CUSTOMER_BUYOUT") - PAYMENTDataSet.PAYMENT.Rows[PaymentPos].Field<Decimal>("PAYMENT_AMOUNT_RCV"));
                else
                    PAYMENTDataSet.CUSTOMER.Rows[CustomerPos].SetField<Decimal>("CUSTOMER_BUYOUT", PAYMENTDataSet.CUSTOMER.Rows[CustomerPos].Field<Decimal>("CUSTOMER_BUYOUT"));
                return;
            }
            // [Unearned Interest] = [Loan Interest] * ([Months Early] * ([Months Early] + 1)) / (Term * (Term + 1))
            // NO MORE BUYOUT TABLE NEEDED!!!
            lnLoanInterest = Convert.ToDouble(PAYMENTDataSet.CUSTOMER.Rows[CustomerPos].Field<Decimal>("CUSTOMER_LOAN_INTEREST"));
            lnTerm = Convert.ToDouble(PAYMENTDataSet.CUSTOMER.Rows[CustomerPos].Field<Int32>("CUSTOMER_TERM"));
            lnMonthsEarly = Convert.ToDouble(PAYMENTDataSet.CUSTOMER.Rows[CustomerPos].Field<Int32>("CUSTOMER_TERM") - PAYMENTDataSet.CUSTOMER.Rows[CustomerPos].Field<Int32>("CUSTOMER_UPD_COUNT"));
            lnBuyoutPercent = Math.Round((lnMonthsEarly * (lnMonthsEarly + 1)) / (lnTerm * (lnTerm + 1)), 4);
            lnUnearnerdInterest = Math.Round((lnLoanInterest - 25) * lnBuyoutPercent, 2);
            PAYMENTDataSet.CUSTOMER.Rows[CustomerPos].SetField<Decimal>("CUSTOMER_BUYOUT", PAYMENTDataSet.CUSTOMER.Rows[CustomerPos].Field<Decimal>("CUSTOMER_BALANCE") - Convert.ToDecimal(lnUnearnerdInterest));
            if (PAYMENTDataSet.CUSTOMER.Rows[CustomerPos].Field<Decimal>("CUSTOMER_BUYOUT") > PAYMENTDataSet.CUSTOMER.Rows[CustomerPos].Field<Decimal>("CUSTOMER_BALANCE"))
                PAYMENTDataSet.CUSTOMER.Rows[CustomerPos].SetField<Decimal>("CUSTOMER_BUYOUT", PAYMENTDataSet.CUSTOMER.Rows[CustomerPos].Field<Decimal>("CUSTOMER_BALANCE"));
        }

        void ClosedPaymentHandleLateCharge(Int32 PaymentPos, Int32 CustomerPos, ref IACDataSet PAYMENTDataSet, ref BackgroundWorker worker)
        {
            lnAPPPay = ((Int32)(PAYMENTDataSet.PAYMENT.Rows[PaymentPos].Field<Decimal>("PAYMENT_AMOUNT_RCV") / PAYMENTDataSet.CUSTOMER.Rows[CustomerPos].Field<Decimal>("CUSTOMER_REGULAR_AMOUNT")));
            lnLCBPay = PAYMENTDataSet.PAYMENT.Rows[PaymentPos].Field<Decimal>("PAYMENT_AMOUNT_RCV") % PAYMENTDataSet.CUSTOMER.Rows[CustomerPos].Field<Decimal>("CUSTOMER_REGULAR_AMOUNT");
            if (!(PAYMENTDataSet.PAYMENT.Rows[PaymentPos].Field<String>("PAYMENT_TYPE") == "W" && PAYMENTDataSet.PAYMENT.Rows[PaymentPos].Field<String>("PAYMENT_CODE_2") == "L"))
            {
                if (lnAPPPay == 0)
                {
                    lnExtraContract = lnLCBPay;
                    lnLCBPay = 0;
                }
                else
                    lnExtraContract = 0;
            }
            else
                lnLCBPay = 0;
            PAYMENTDataSet.CUSTOMER.Rows[CustomerPos].SetField<Decimal>("CUSTOMER_LATE_CHARGE_BAL", (PAYMENTDataSet.CUSTOMER.Rows[CustomerPos].Field<Decimal>("CUSTOMER_LATE_CHARGE_BAL") >= 0) ? PAYMENTDataSet.CUSTOMER.Rows[CustomerPos].Field<Decimal>("CUSTOMER_LATE_CHARGE_BAL") - lnLCBPay : 0);
            // Moses Newman 04/30/2017 Handle S for Simple and N for Normal Interest
            if (PAYMENTDataSet.CUSTOMER.Rows[CustomerPos].Field<String>("CUSTOMER_AMORTIZE_IND") == "S" || PAYMENTDataSet.CUSTOMER.Rows[CustomerPos].Field<String>("CUSTOMER_AMORTIZE_IND") == "N")
            {
                lnLateChargePaid = 0;
                lnLCBPay = 0;
                lnAPPPay = 0;
            }


            else
                lnLateChargePaid = lnLCBPay;
        }

        void ClosedPaymentDealerPost(ref IACDataSet PAYMENTDataSet, ref BackgroundWorker worker)
        {

            int DEALERPos = 0;
            IACDataSetTableAdapters.DEALERTableAdapter DEALERTableAdapter = new IACDataSetTableAdapters.DEALERTableAdapter();

            DEALERTableAdapter.FillByUnPostedPayments(PAYMENTDataSet.DEALER);
            for (Int32 dlrCount = 0; dlrCount < PAYMENTDataSet.WS_DEALER_PAY.Rows.Count; dlrCount++)
            {
                DEALERPos = DEALERBindingSource.Find("DEALER_ACC_NO", PAYMENTDataSet.WS_DEALER_PAY.Rows[dlrCount].Field<String>("KEY"));
                if (DEALERPos > -1)
                {
                    PAYMENTDataSet.WS_DEALER_PAY.Rows[dlrCount].SetField<Decimal>("OS_L", PAYMENTDataSet.WS_DEALER_PAY.Rows[dlrCount].Field<Decimal>("OS_L") * -1);
                    PAYMENTDataSet.DEALER.Rows[DEALERPos].SetField<Decimal>("DEALER_CUR_RSV", 0);
                    PAYMENTDataSet.DEALER.Rows[DEALERPos].SetField<Decimal>("DEALER_CUR_CONT", 0);
                    PAYMENTDataSet.DEALER.Rows[DEALERPos].SetField<Decimal>("DEALER_CUR_OLOAN", 0);
                    PAYMENTDataSet.DEALER.Rows[DEALERPos].SetField<Decimal>("DEALER_CUR_ADJ", 0);
                    PAYMENTDataSet.DEALER.Rows[DEALERPos].SetField<Decimal>("DEALER_CUR_BAD", 0);
                    PAYMENTDataSet.DEALER.Rows[DEALERPos].SetField<Decimal>("DEALER_CUR_LOSS", 0);
                    PAYMENTDataSet.DEALER.Rows[DEALERPos].SetField<Decimal>("DEALER_CUR_AMORT_INT", 0);
                    PAYMENTDataSet.DEALER.Rows[DEALERPos].SetField<Decimal>("DEALER_CUR_SIMPLE_INT", 0);
                    PAYMENTDataSet.DEALER.Rows[DEALERPos].SetField<Decimal>("DEALER_CUR_OLD_INT", 0);
                    PAYMENTDataSet.DEALER.Rows[DEALERPos].SetField<Decimal>("DEALER_CUR_AMORT_PDI", 0);
                    PAYMENTDataSet.DEALER.Rows[DEALERPos].SetField<Decimal>("DEALER_CUR_SIMPLE_PDI", 0);
                    PAYMENTDataSet.DEALER.Rows[DEALERPos].SetField<Decimal>("DEALER_CUR_OLD_PDI", 0);

                    PAYMENTDataSet.DEALER.Rows[DEALERPos].SetField<Decimal>("DEALER_CUR_OLOAN", PAYMENTDataSet.WS_DEALER_PAY.Rows[dlrCount].Field<Decimal>("OS_L"));
                    PAYMENTDataSet.DEALER.Rows[DEALERPos].SetField<Decimal>("DEALER_YTD_OLOAN", PAYMENTDataSet.DEALER.Rows[DEALERPos].Field<Decimal>("DEALER_YTD_OLOAN") + PAYMENTDataSet.WS_DEALER_PAY.Rows[dlrCount].Field<Decimal>("OS_L"));
                    PAYMENTDataSet.DEALER.Rows[DEALERPos].SetField<DateTime>("DEALER_POST_DATE", DateTime.Now.Date);
                    PAYMENTDataSet.DEALER.Rows[DEALERPos].SetField<Decimal>("DEALER_CUR_AMORT_PDI", PAYMENTDataSet.WS_DEALER_PAY.Rows[dlrCount].Field<Decimal>("AMORT_INT"));
                    PAYMENTDataSet.DEALER.Rows[DEALERPos].SetField<Decimal>("DEALER_YTD_AMORT_PDI", PAYMENTDataSet.DEALER.Rows[DEALERPos].Field<Decimal>("DEALER_YTD_AMORT_PDI") + PAYMENTDataSet.WS_DEALER_PAY.Rows[dlrCount].Field<Decimal>("AMORT_INT"));
                    PAYMENTDataSet.DEALER.Rows[DEALERPos].SetField<Decimal>("DEALER_CUR_OLD_PDI", PAYMENTDataSet.WS_DEALER_PAY.Rows[dlrCount].Field<Decimal>("OLD_INT"));
                    PAYMENTDataSet.DEALER.Rows[DEALERPos].SetField<Decimal>("DEALER_YTD_OLD_PDI", PAYMENTDataSet.DEALER.Rows[DEALERPos].Field<Decimal>("DEALER_YTD_OLD_PDI") + PAYMENTDataSet.WS_DEALER_PAY.Rows[dlrCount].Field<Decimal>("OLD_INT"));
                    PAYMENTDataSet.DEALER.Rows[DEALERPos].SetField<Decimal>("DEALER_CUR_SIMPLE_PDI", PAYMENTDataSet.WS_DEALER_PAY.Rows[dlrCount].Field<Decimal>("SIMPLE_INT"));
                    if (PAYMENTDataSet.DEALER.Rows[DEALERPos].Field<Nullable<Decimal>>("DEALER_YTD_SIMPLE_PDI") != null)
                        PAYMENTDataSet.DEALER.Rows[DEALERPos].SetField<Nullable<Decimal>>("DEALER_YTD_SIMPLE_PDI", PAYMENTDataSet.DEALER.Rows[DEALERPos].Field<Nullable<Decimal>>("DEALER_YTD_SIMPLE_PDI") + PAYMENTDataSet.WS_DEALER_PAY.Rows[dlrCount].Field<Decimal>("SIMPLE_INT"));
                    else
                        PAYMENTDataSet.DEALER.Rows[DEALERPos].SetField<Nullable<Decimal>>("DEALER_YTD_SIMPLE_PDI", PAYMENTDataSet.WS_DEALER_PAY.Rows[dlrCount].Field<Decimal>("SIMPLE_INT"));
                    PAYMENTDataSet.WS_DEALER_PAY.Rows[dlrCount].SetField<Decimal>("AMORT_INT", PAYMENTDataSet.WS_DEALER_PAY.Rows[dlrCount].Field<Decimal>("AMORT_INT") + PAYMENTDataSet.WS_DEALER_PAY.Rows[dlrCount].Field<Decimal>("AMORT_ADJ"));
                    PAYMENTDataSet.WS_DEALER_PAY.Rows[dlrCount].SetField<Decimal>("OLD_INT", PAYMENTDataSet.WS_DEALER_PAY.Rows[dlrCount].Field<Decimal>("OLD_INT") + PAYMENTDataSet.WS_DEALER_PAY.Rows[dlrCount].Field<Decimal>("OLD_ADJ"));
                    PAYMENTDataSet.WS_DEALER_PAY.Rows[dlrCount].SetField<Decimal>("SIMPLE_INT", PAYMENTDataSet.WS_DEALER_PAY.Rows[dlrCount].Field<Decimal>("SIMPLE_INT") + PAYMENTDataSet.WS_DEALER_PAY.Rows[dlrCount].Field<Decimal>("SIMPLE_ADJ"));

                    PAYMENTDataSet.WS_DEALER_PAY.Rows[dlrCount].SetField<Decimal>("AMORT_INT", PAYMENTDataSet.WS_DEALER_PAY.Rows[dlrCount].Field<Decimal>("AMORT_INT") * -1);
                    PAYMENTDataSet.WS_DEALER_PAY.Rows[dlrCount].SetField<Decimal>("OLD_INT", PAYMENTDataSet.WS_DEALER_PAY.Rows[dlrCount].Field<Decimal>("OLD_INT") * -1);
                    PAYMENTDataSet.WS_DEALER_PAY.Rows[dlrCount].SetField<Decimal>("SIMPLE_INT", PAYMENTDataSet.WS_DEALER_PAY.Rows[dlrCount].Field<Decimal>("SIMPLE_INT") * -1);

                    // Do NOT make simple interest negative!!! Not working down pre-computed balance for simple interest!

                    PAYMENTDataSet.DEALER.Rows[DEALERPos].SetField<Decimal>("DEALER_CUR_AMORT_INT", PAYMENTDataSet.WS_DEALER_PAY.Rows[dlrCount].Field<Decimal>("AMORT_INT"));
                    PAYMENTDataSet.DEALER.Rows[DEALERPos].SetField<Decimal>("DEALER_YTD_AMORT_INT", PAYMENTDataSet.DEALER.Rows[DEALERPos].Field<Decimal>("DEALER_YTD_AMORT_INT") + PAYMENTDataSet.WS_DEALER_PAY.Rows[dlrCount].Field<Decimal>("AMORT_INT"));
                    PAYMENTDataSet.DEALER.Rows[DEALERPos].SetField<Decimal>("DEALER_CUR_OLD_INT", PAYMENTDataSet.WS_DEALER_PAY.Rows[dlrCount].Field<Decimal>("OLD_INT"));
                    PAYMENTDataSet.DEALER.Rows[DEALERPos].SetField<Decimal>("DEALER_YTD_OLD_INT", PAYMENTDataSet.DEALER.Rows[DEALERPos].Field<Decimal>("DEALER_YTD_OLD_INT") + PAYMENTDataSet.WS_DEALER_PAY.Rows[dlrCount].Field<Decimal>("OLD_INT"));
                    PAYMENTDataSet.DEALER.Rows[DEALERPos].SetField<Decimal>("DEALER_CUR_SIMPLE_INT", PAYMENTDataSet.WS_DEALER_PAY.Rows[dlrCount].Field<Decimal>("SIMPLE_INT"));
                    if (PAYMENTDataSet.DEALER.Rows[DEALERPos].Field<Nullable<Decimal>>("DEALER_YTD_SIMPLE_INT") != null)
                        PAYMENTDataSet.DEALER.Rows[DEALERPos].SetField<Nullable<Decimal>>("DEALER_YTD_SIMPLE_INT", PAYMENTDataSet.DEALER.Rows[DEALERPos].Field<Nullable<Decimal>>("DEALER_YTD_SIMPLE_INT") + PAYMENTDataSet.WS_DEALER_PAY.Rows[dlrCount].Field<Decimal>("SIMPLE_INT"));
                    else
                        PAYMENTDataSet.DEALER.Rows[DEALERPos].SetField<Nullable<Decimal>>("DEALER_YTD_SIMPLE_INT", PAYMENTDataSet.WS_DEALER_PAY.Rows[dlrCount].Field<Decimal>("SIMPLE_INT"));
                    ClosedPaymentDEALHISTPost(DEALERPos, ref PAYMENTDataSet, ref worker);
                }
                else
                    MessageBox.Show("*** ERROR! DEALER IS NOT IN DEALER FILE, SOMETHING IS WRONG! ***");
            }
            worker.ReportProgress(12);
        }

        void ClosedPaymentDEALHISTPost(int DEALERPos, ref IACDataSet PAYMENTDataSet, ref BackgroundWorker worker)
        {
            Int32 DEALHISTPos = 0;


            IACDataSetTableAdapters.DEALERTableAdapter DEALERTableAdapter = new IACDataSetTableAdapters.DEALERTableAdapter();
            IACDataSetTableAdapters.DEALHISTTableAdapter DEALHISTTableAdapter = new IACDataSetTableAdapters.DEALHISTTableAdapter();

            DEALHISTBindingSource.AddNew();
            DEALHISTBindingSource.EndEdit();

            DEALHISTPos = DEALHISTBindingSource.Position;

            if (DEALHISTPos > -1)
            {
                // Set up the new history record key
                PAYMENTDataSet.DEALHIST.Rows[DEALHISTPos].SetField<String>("DEALHIST_ACC_NO", PAYMENTDataSet.DEALER.Rows[DEALERPos].Field<String>("DEALER_ACC_NO"));
                PAYMENTDataSet.DEALHIST.Rows[DEALHISTPos].SetField<DateTime>("DEALHIST_POST_DATE", DateTime.Now.Date);
                PAYMENTDataSet.DEALHIST.Rows[DEALHISTPos].SetField<DateTime>("DEALHIST_LAST_POST_DATE", DateTime.Now.Date);
                //  End of DEALHIST KEY
                PAYMENTDataSet.DEALHIST.Rows[DEALHISTPos].SetField<String>("DEALHIST_NAME", PAYMENTDataSet.DEALER.Rows[DEALERPos].Field<String>("DEALER_NAME"));
                PAYMENTDataSet.DEALHIST.Rows[DEALHISTPos].SetField<Decimal>("DEALHIST_CUR_ADJ", PAYMENTDataSet.DEALER.Rows[DEALERPos].Field<Decimal>("DEALER_CUR_ADJ"));
                PAYMENTDataSet.DEALHIST.Rows[DEALHISTPos].SetField<Decimal>("DEALHIST_CUR_CONT", PAYMENTDataSet.DEALER.Rows[DEALERPos].Field<Decimal>("DEALER_CUR_CONT"));
                PAYMENTDataSet.DEALHIST.Rows[DEALHISTPos].SetField<Decimal>("DEALHIST_CUR_BAD", PAYMENTDataSet.DEALER.Rows[DEALERPos].Field<Decimal>("DEALER_CUR_BAD"));
                PAYMENTDataSet.DEALHIST.Rows[DEALHISTPos].SetField<Decimal>("DEALHIST_CUR_RSV", PAYMENTDataSet.DEALER.Rows[DEALERPos].Field<Decimal>("DEALER_CUR_RSV"));
                PAYMENTDataSet.DEALHIST.Rows[DEALHISTPos].SetField<Decimal>("DEALHIST_CUR_LOSS", PAYMENTDataSet.DEALER.Rows[DEALERPos].Field<Decimal>("DEALER_CUR_LOSS"));
                PAYMENTDataSet.DEALHIST.Rows[DEALHISTPos].SetField<Decimal>("DEALHIST_CUR_OLOAN", PAYMENTDataSet.DEALER.Rows[DEALERPos].Field<Decimal>("DEALER_CUR_OLOAN"));
                PAYMENTDataSet.DEALHIST.Rows[DEALHISTPos].SetField<Decimal>("DEALHIST_YTD_ADJ", PAYMENTDataSet.DEALER.Rows[DEALERPos].Field<Decimal>("DEALER_YTD_ADJ"));
                PAYMENTDataSet.DEALHIST.Rows[DEALHISTPos].SetField<Decimal>("DEALHIST_YTD_CONT", PAYMENTDataSet.DEALER.Rows[DEALERPos].Field<Decimal>("DEALER_YTD_CONT"));
                PAYMENTDataSet.DEALHIST.Rows[DEALHISTPos].SetField<Decimal>("DEALHIST_YTD_BAD", PAYMENTDataSet.DEALER.Rows[DEALERPos].Field<Decimal>("DEALER_YTD_BAD"));
                PAYMENTDataSet.DEALHIST.Rows[DEALHISTPos].SetField<Decimal>("DEALHIST_YTD_RSV", PAYMENTDataSet.DEALER.Rows[DEALERPos].Field<Decimal>("DEALER_YTD_RSV"));
                PAYMENTDataSet.DEALHIST.Rows[DEALHISTPos].SetField<Decimal>("DEALHIST_YTD_LOSS", PAYMENTDataSet.DEALER.Rows[DEALERPos].Field<Decimal>("DEALER_YTD_LOSS"));
                PAYMENTDataSet.DEALHIST.Rows[DEALHISTPos].SetField<Decimal>("DEALHIST_YTD_OLOAN", PAYMENTDataSet.DEALER.Rows[DEALERPos].Field<Decimal>("DEALER_YTD_OLOAN"));
                PAYMENTDataSet.DEALHIST.Rows[DEALHISTPos].SetField<String>("DEALHIST_POST_CODE", "R");
                PAYMENTDataSet.DEALHIST.Rows[DEALHISTPos].SetField<Decimal>("DEALHIST_CUR_AMORT_INT", PAYMENTDataSet.DEALER.Rows[DEALERPos].Field<Decimal>("DEALER_CUR_AMORT_INT"));
                PAYMENTDataSet.DEALHIST.Rows[DEALHISTPos].SetField<Decimal>("DEALHIST_CUR_OLD_INT", PAYMENTDataSet.DEALER.Rows[DEALERPos].Field<Decimal>("DEALER_CUR_OLD_INT"));
                PAYMENTDataSet.DEALHIST.Rows[DEALHISTPos].SetField<Decimal>("DEALHIST_CUR_SIMPLE_INT", PAYMENTDataSet.DEALER.Rows[DEALERPos].Field<Decimal>("DEALER_CUR_SIMPLE_INT"));
                PAYMENTDataSet.DEALHIST.Rows[DEALHISTPos].SetField<Decimal>("DEALHIST_YTD_AMORT_INT", PAYMENTDataSet.DEALER.Rows[DEALERPos].Field<Decimal>("DEALER_YTD_AMORT_INT"));
                PAYMENTDataSet.DEALHIST.Rows[DEALHISTPos].SetField<Decimal>("DEALHIST_YTD_OLD_INT", PAYMENTDataSet.DEALER.Rows[DEALERPos].Field<Decimal>("DEALER_YTD_OLD_INT"));
                PAYMENTDataSet.DEALHIST.Rows[DEALHISTPos].SetField<Decimal>("DEALHIST_YTD_SIMPLE_INT", PAYMENTDataSet.DEALER.Rows[DEALERPos].Field<Decimal>("DEALER_YTD_SIMPLE_INT"));

                PAYMENTDataSet.DEALHIST.Rows[DEALHISTPos].SetField<Decimal>("DEALHIST_CUR_AMORT_PDI", PAYMENTDataSet.DEALER.Rows[DEALERPos].Field<Decimal>("DEALER_CUR_AMORT_PDI"));
                PAYMENTDataSet.DEALHIST.Rows[DEALHISTPos].SetField<Decimal>("DEALHIST_CUR_OLD_PDI", PAYMENTDataSet.DEALER.Rows[DEALERPos].Field<Decimal>("DEALER_CUR_OLD_PDI"));
                PAYMENTDataSet.DEALHIST.Rows[DEALHISTPos].SetField<Decimal>("DEALHIST_CUR_SIMPLE_PDI", PAYMENTDataSet.DEALER.Rows[DEALERPos].Field<Decimal>("DEALER_CUR_SIMPLE_PDI"));
                PAYMENTDataSet.DEALHIST.Rows[DEALHISTPos].SetField<Decimal>("DEALHIST_YTD_AMORT_PDI", PAYMENTDataSet.DEALER.Rows[DEALERPos].Field<Decimal>("DEALER_YTD_AMORT_PDI"));
                PAYMENTDataSet.DEALHIST.Rows[DEALHISTPos].SetField<Decimal>("DEALHIST_YTD_OLD_PDI", PAYMENTDataSet.DEALER.Rows[DEALERPos].Field<Decimal>("DEALER_YTD_OLD_PDI"));
                PAYMENTDataSet.DEALHIST.Rows[DEALHISTPos].SetField<Decimal>("DEALHIST_YTD_SIMPLE_PDI", PAYMENTDataSet.DEALER.Rows[DEALERPos].Field<Decimal>("DEALER_YTD_SIMPLE_PDI"));
                worker.ReportProgress(16);
            }
        }

        void ClosedPaymentMasterPost(ref IACDataSet PAYMENTDataSet, ref BackgroundWorker worker)
        {
            int MASTERPos = 0;
            Object loMasterKey;
            String lsMasterKey = "";
            Decimal lnInterestTally = (Decimal)(lnMasterDiscount + lnMasterInterest),
                    lnInterestAmortTally = (Decimal)(lnMasterAmortDiscount + lnMasterAmortInterest),
                    lnInterestSimpleTally = (Decimal)(lnMasterSimpleDiscount + lnMasterSimpleInterest);

            IACDataSetTableAdapters.MASTERTableAdapter MASTERTableAdapter = new IACDataSetTableAdapters.MASTERTableAdapter();
            IACDataSetTableAdapters.ACCOUNTTableAdapter ACCOUNTTableAdapter = new IACDataSetTableAdapters.ACCOUNTTableAdapter();

            MASTERTableAdapter.FillAllRecords(PAYMENTDataSet.MASTER);

            loMasterKey = ACCOUNTTableAdapter.AccountNumber("OS_LOANS");
            lsMasterKey = (String)loMasterKey;
            MASTERPos = MASTERBindingSource.Find("MASTER_ACC_NO", lsMasterKey);
            if (MASTERPos > -1)
            {
                PAYMENTDataSet.MASTER.Rows[MASTERPos].SetField<Decimal>("MASTER_CUR_RSV", 0);
                PAYMENTDataSet.MASTER.Rows[MASTERPos].SetField<Decimal>("MASTER_CUR_CONT", 0);
                PAYMENTDataSet.MASTER.Rows[MASTERPos].SetField<Decimal>("MASTER_CUR_OLOAN", 0);
                PAYMENTDataSet.MASTER.Rows[MASTERPos].SetField<Decimal>("MASTER_CUR_ADJ", 0);
                PAYMENTDataSet.MASTER.Rows[MASTERPos].SetField<Decimal>("MASTER_CUR_BAD", 0);
                PAYMENTDataSet.MASTER.Rows[MASTERPos].SetField<Decimal>("MASTER_CUR_LOSS", 0);
                PAYMENTDataSet.MASTER.Rows[MASTERPos].SetField<Decimal>("MASTER_CUR_INT", 0);
                PAYMENTDataSet.MASTER.Rows[MASTERPos].SetField<Decimal>("MASTER_CUR_NOTES", 0);
                PAYMENTDataSet.MASTER.Rows[MASTERPos].SetField<Decimal>("MASTER_AMORT_CUR_OLOAN", 0);
                PAYMENTDataSet.MASTER.Rows[MASTERPos].SetField<Decimal>("MASTER_AMORT_CUR_NOTES", 0);
                PAYMENTDataSet.MASTER.Rows[MASTERPos].SetField<Decimal>("MASTER_AMORT_CUR_INT", 0);
                PAYMENTDataSet.MASTER.Rows[MASTERPos].SetField<Decimal>("MASTER_SIMPLE_CUR_OLOAN", 0);
                PAYMENTDataSet.MASTER.Rows[MASTERPos].SetField<Decimal>("MASTER_SIMPLE_CUR_NOTES", 0);
                PAYMENTDataSet.MASTER.Rows[MASTERPos].SetField<Decimal>("MASTER_SIMPLE_CUR_INT", 0);

                PAYMENTDataSet.MASTER.Rows[MASTERPos].SetField<Decimal>("MASTER_CUR_OLOAN", (Decimal)(lnMasterOloan * -1));
                PAYMENTDataSet.MASTER.Rows[MASTERPos].SetField<Decimal>("MASTER_YTD_OLOAN", PAYMENTDataSet.MASTER.Rows[MASTERPos].Field<Decimal>("MASTER_YTD_OLOAN") - (Decimal)lnMasterOloan);
                PAYMENTDataSet.MASTER.Rows[MASTERPos].SetField<Decimal>("MASTER_CUR_NOTES", (Decimal)lnMasterNP * -1);
                PAYMENTDataSet.MASTER.Rows[MASTERPos].SetField<Decimal>("MASTER_YTD_NOTES", PAYMENTDataSet.MASTER.Rows[MASTERPos].Field<Decimal>("MASTER_YTD_NOTES") - (Decimal)lnMasterNP);

                PAYMENTDataSet.MASTER.Rows[MASTERPos].SetField<Decimal>("MASTER_SIMPLE_CUR_OLOAN", (Decimal)(lnMasterSimpleOloan * -1));
                PAYMENTDataSet.MASTER.Rows[MASTERPos].SetField<Nullable<Decimal>>("MASTER_SIMPLE_YTD_OLOAN", PAYMENTDataSet.MASTER.Rows[MASTERPos].Field<Nullable<Decimal>>("MASTER_SIMPLE_YTD_OLOAN") + (Decimal)(lnMasterSimpleOloan * -1));
                PAYMENTDataSet.MASTER.Rows[MASTERPos].SetField<Nullable<Decimal>>("MASTER_SIMPLE_CUR_NOTES", (Decimal)(lnMasterSimpleNP));
                PAYMENTDataSet.MASTER.Rows[MASTERPos].SetField<Nullable<Decimal>>("MASTER_SIMPLE_YTD_NOTES", PAYMENTDataSet.MASTER.Rows[MASTERPos].Field<Nullable<Decimal>>("MASTER_SIMPLE_YTD_NOTES") + (Decimal)(lnMasterSimpleNP));
                PAYMENTDataSet.MASTER.Rows[MASTERPos].SetField<DateTime>("MASTER_POST_DATE", DateTime.Now.Date);
            }

            loMasterKey = ACCOUNTTableAdapter.AccountNumber("INTEREST");
            lsMasterKey = (String)loMasterKey;
            MASTERPos = MASTERBindingSource.Find("MASTER_ACC_NO", lsMasterKey);
            if (MASTERPos > -1)
            {
                PAYMENTDataSet.MASTER.Rows[MASTERPos].SetField<Decimal>("MASTER_CUR_RSV", 0);
                PAYMENTDataSet.MASTER.Rows[MASTERPos].SetField<Decimal>("MASTER_CUR_CONT", 0);
                PAYMENTDataSet.MASTER.Rows[MASTERPos].SetField<Decimal>("MASTER_CUR_OLOAN", 0);
                PAYMENTDataSet.MASTER.Rows[MASTERPos].SetField<Decimal>("MASTER_CUR_ADJ", 0);
                PAYMENTDataSet.MASTER.Rows[MASTERPos].SetField<Decimal>("MASTER_CUR_BAD", 0);
                PAYMENTDataSet.MASTER.Rows[MASTERPos].SetField<Decimal>("MASTER_CUR_LOSS", 0);
                PAYMENTDataSet.MASTER.Rows[MASTERPos].SetField<Decimal>("MASTER_CUR_INT", 0);
                PAYMENTDataSet.MASTER.Rows[MASTERPos].SetField<Decimal>("MASTER_CUR_NOTES", 0);
                PAYMENTDataSet.MASTER.Rows[MASTERPos].SetField<Decimal>("MASTER_AMORT_CUR_OLOAN", 0);
                PAYMENTDataSet.MASTER.Rows[MASTERPos].SetField<Decimal>("MASTER_AMORT_CUR_NOTES", 0);
                PAYMENTDataSet.MASTER.Rows[MASTERPos].SetField<Decimal>("MASTER_AMORT_CUR_INT", 0);

                PAYMENTDataSet.MASTER.Rows[MASTERPos].SetField<Decimal>("MASTER_CUR_INT", (lnInterestTally * -1));
                PAYMENTDataSet.MASTER.Rows[MASTERPos].SetField<Decimal>("MASTER_YTD_INT", PAYMENTDataSet.MASTER.Rows[MASTERPos].Field<Decimal>("MASTER_YTD_INT") + (lnInterestTally * -1));
                PAYMENTDataSet.MASTER.Rows[MASTERPos].SetField<Decimal>("MASTER_AMORT_CUR_INT", (lnInterestAmortTally * -1));
                PAYMENTDataSet.MASTER.Rows[MASTERPos].SetField<Decimal>("MASTER_AMORT_YTD_INT", PAYMENTDataSet.MASTER.Rows[MASTERPos].Field<Decimal>("MASTER_AMORT_YTD_INT") + (lnInterestAmortTally * -1));
                PAYMENTDataSet.MASTER.Rows[MASTERPos].SetField<Decimal>("MASTER_SIMPLE_CUR_INT", lnInterestSimpleTally * -1);
                PAYMENTDataSet.MASTER.Rows[MASTERPos].SetField<Nullable<Decimal>>("MASTER_SIMPLE_YTD_INT", PAYMENTDataSet.MASTER.Rows[MASTERPos].Field<Nullable<Decimal>>("MASTER_SIMPLE_YTD_INT") + lnInterestSimpleTally * -1);
                PAYMENTDataSet.MASTER.Rows[MASTERPos].SetField<DateTime>("MASTER_POST_DATE", DateTime.Now.Date);
            }

            loMasterKey = ACCOUNTTableAdapter.AccountNumber("AMORT_INT");
            lsMasterKey = (String)loMasterKey;
            MASTERPos = MASTERBindingSource.Find("MASTER_ACC_NO", lsMasterKey);
            if (MASTERPos > -1)
            {
                PAYMENTDataSet.MASTER.Rows[MASTERPos].SetField<Decimal>("MASTER_CUR_RSV", 0);
                PAYMENTDataSet.MASTER.Rows[MASTERPos].SetField<Decimal>("MASTER_CUR_CONT", 0);
                PAYMENTDataSet.MASTER.Rows[MASTERPos].SetField<Decimal>("MASTER_CUR_OLOAN", 0);
                PAYMENTDataSet.MASTER.Rows[MASTERPos].SetField<Decimal>("MASTER_CUR_ADJ", 0);
                PAYMENTDataSet.MASTER.Rows[MASTERPos].SetField<Decimal>("MASTER_CUR_BAD", 0);
                PAYMENTDataSet.MASTER.Rows[MASTERPos].SetField<Decimal>("MASTER_CUR_LOSS", 0);
                PAYMENTDataSet.MASTER.Rows[MASTERPos].SetField<Decimal>("MASTER_CUR_INT", 0);
                PAYMENTDataSet.MASTER.Rows[MASTERPos].SetField<Decimal>("MASTER_CUR_NOTES", 0);
                PAYMENTDataSet.MASTER.Rows[MASTERPos].SetField<Decimal>("MASTER_AMORT_CUR_OLOAN", 0);
                PAYMENTDataSet.MASTER.Rows[MASTERPos].SetField<Decimal>("MASTER_AMORT_CUR_NOTES", 0);
                PAYMENTDataSet.MASTER.Rows[MASTERPos].SetField<Decimal>("MASTER_AMORT_CUR_INT", 0);

                PAYMENTDataSet.MASTER.Rows[MASTERPos].SetField<Decimal>("MASTER_CUR_INT", (lnInterestAmortTally * -1));
                PAYMENTDataSet.MASTER.Rows[MASTERPos].SetField<Decimal>("MASTER_YTD_INT", PAYMENTDataSet.MASTER.Rows[MASTERPos].Field<Decimal>("MASTER_YTD_INT") + (lnInterestAmortTally * -1));

                PAYMENTDataSet.MASTER.Rows[MASTERPos].SetField<Decimal>("MASTER_AMORT_CUR_INT", (lnInterestAmortTally * -1));
                PAYMENTDataSet.MASTER.Rows[MASTERPos].SetField<Decimal>("MASTER_AMORT_YTD_INT", PAYMENTDataSet.MASTER.Rows[MASTERPos].Field<Decimal>("MASTER_AMORT_YTD_INT") + (lnInterestAmortTally * -1));

                PAYMENTDataSet.MASTER.Rows[MASTERPos].SetField<DateTime>("MASTER_POST_DATE", DateTime.Now.Date);
            }

            loMasterKey = ACCOUNTTableAdapter.AccountNumber("SIMPLE_INT");
            lsMasterKey = (String)loMasterKey;
            MASTERPos = MASTERBindingSource.Find("MASTER_ACC_NO", lsMasterKey);
            if (MASTERPos > -1)
            {
                PAYMENTDataSet.MASTER.Rows[MASTERPos].SetField<Decimal>("MASTER_CUR_RSV", 0);
                PAYMENTDataSet.MASTER.Rows[MASTERPos].SetField<Decimal>("MASTER_CUR_CONT", 0);
                PAYMENTDataSet.MASTER.Rows[MASTERPos].SetField<Decimal>("MASTER_CUR_OLOAN", 0);
                PAYMENTDataSet.MASTER.Rows[MASTERPos].SetField<Decimal>("MASTER_CUR_ADJ", 0);
                PAYMENTDataSet.MASTER.Rows[MASTERPos].SetField<Decimal>("MASTER_CUR_BAD", 0);
                PAYMENTDataSet.MASTER.Rows[MASTERPos].SetField<Decimal>("MASTER_CUR_LOSS", 0);
                PAYMENTDataSet.MASTER.Rows[MASTERPos].SetField<Decimal>("MASTER_CUR_INT", 0);
                PAYMENTDataSet.MASTER.Rows[MASTERPos].SetField<Decimal>("MASTER_CUR_NOTES", 0);
                PAYMENTDataSet.MASTER.Rows[MASTERPos].SetField<Decimal>("MASTER_AMORT_CUR_OLOAN", 0);
                PAYMENTDataSet.MASTER.Rows[MASTERPos].SetField<Decimal>("MASTER_AMORT_CUR_NOTES", 0);
                PAYMENTDataSet.MASTER.Rows[MASTERPos].SetField<Decimal>("MASTER_AMORT_CUR_INT", 0);

                PAYMENTDataSet.MASTER.Rows[MASTERPos].SetField<Decimal>("MASTER_CUR_INT", (lnInterestSimpleTally * -1));
                PAYMENTDataSet.MASTER.Rows[MASTERPos].SetField<Decimal>("MASTER_YTD_INT", PAYMENTDataSet.MASTER.Rows[MASTERPos].Field<Decimal>("MASTER_YTD_INT") + (lnInterestSimpleTally * -1));

                PAYMENTDataSet.MASTER.Rows[MASTERPos].SetField<Decimal>("MASTER_SIMPLE_CUR_INT", lnInterestSimpleTally * -1);
                if (PAYMENTDataSet.MASTER.Rows[MASTERPos].Field<Nullable<Decimal>>("MASTER_SIMPLE_YTD_INT") != null)
                    PAYMENTDataSet.MASTER.Rows[MASTERPos].SetField<Decimal>("MASTER_SIMPLE_YTD_INT", PAYMENTDataSet.MASTER.Rows[MASTERPos].Field<Decimal>("MASTER_SIMPLE_YTD_INT") + lnInterestSimpleTally * -1);
                else
                    PAYMENTDataSet.MASTER.Rows[MASTERPos].SetField<Decimal>("MASTER_SIMPLE_YTD_INT", lnInterestSimpleTally * -1);
                PAYMENTDataSet.MASTER.Rows[MASTERPos].SetField<DateTime>("MASTER_POST_DATE", DateTime.Now.Date);
            }

            worker.ReportProgress(24);
        }

        void ClosedPaymentMASTHISTPost(ref IACDataSet PAYMENTDataSet, ref BackgroundWorker worker)
        {
            int lnSeq = 0, MASTHISTPos = 0, MASTERPos = 0;
            Object loMASTHISTSeq, loMasterKey;
            String lsMasterKey = "";

            IACDataSetTableAdapters.ACCOUNTTableAdapter ACCOUNTTableAdapter = new IACDataSetTableAdapters.ACCOUNTTableAdapter();
            IACDataSetTableAdapters.MASTERTableAdapter MASTERTableAdapter = new IACDataSetTableAdapters.MASTERTableAdapter();
            IACDataSetTableAdapters.MASTHISTTableAdapter MASTHISTTableAdapter = new IACDataSetTableAdapters.MASTHISTTableAdapter();

            MASTHISTBindingSource.AddNew();
            MASTHISTBindingSource.EndEdit();

            MASTHISTPos = MASTHISTBindingSource.Position;

            loMasterKey = ACCOUNTTableAdapter.AccountNumber("OS_LOANS");
            lsMasterKey = (String)loMasterKey;
            MASTERPos = MASTERBindingSource.Find("MASTER_ACC_NO", lsMasterKey);

            if (MASTHISTPos > -1)
            {
                loMASTHISTSeq = MASTHISTTableAdapter.SeqNoQuery(lsMasterKey, DateTime.Now.Date);
                if (loMASTHISTSeq != null)
                    lnSeq = (int)loMASTHISTSeq + 1;
                else
                    lnSeq = 1;
                // Set up the new history record key
                PAYMENTDataSet.MASTHIST.Rows[MASTHISTPos].SetField<String>("MASTHIST_ACC_NO", PAYMENTDataSet.MASTER.Rows[MASTERPos].Field<String>("MASTER_ACC_NO"));
                PAYMENTDataSet.MASTHIST.Rows[MASTHISTPos].SetField<Int32>("MASTHIST_SEQ_NO", lnSeq);
                PAYMENTDataSet.MASTHIST.Rows[MASTHISTPos].SetField<DateTime>("MASTHIST_POST_DATE", DateTime.Now.Date);
                PAYMENTDataSet.MASTHIST.Rows[MASTHISTPos].SetField<String>("MASTHIST_NAME", PAYMENTDataSet.MASTER.Rows[MASTERPos].Field<String>("MASTER_NAME"));
                PAYMENTDataSet.MASTHIST.Rows[MASTHISTPos].SetField<String>("MASTHIST_IAC_TYPE", "C");

                //  End of MASTHIST KEY

                PAYMENTDataSet.MASTHIST.Rows[MASTHISTPos].SetField<Decimal>("MASTHIST_CUR_OLOAN", PAYMENTDataSet.MASTER.Rows[MASTERPos].Field<Decimal>("MASTER_CUR_OLOAN"));
                PAYMENTDataSet.MASTHIST.Rows[MASTHISTPos].SetField<Decimal>("MASTHIST_YTD_OLOAN", PAYMENTDataSet.MASTER.Rows[MASTERPos].Field<Decimal>("MASTER_YTD_OLOAN"));
                PAYMENTDataSet.MASTHIST.Rows[MASTHISTPos].SetField<Decimal>("MASTHIST_CUR_NOTES", PAYMENTDataSet.MASTER.Rows[MASTERPos].Field<Decimal>("MASTER_CUR_NOTES"));
                PAYMENTDataSet.MASTHIST.Rows[MASTHISTPos].SetField<Decimal>("MASTHIST_YTD_NOTES", PAYMENTDataSet.MASTER.Rows[MASTERPos].Field<Decimal>("MASTER_YTD_NOTES"));
            }

            MASTHISTBindingSource.AddNew();
            MASTHISTBindingSource.EndEdit();

            MASTHISTPos = MASTHISTBindingSource.Position;

            loMasterKey = ACCOUNTTableAdapter.AccountNumber("INTEREST");
            lsMasterKey = (String)loMasterKey;
            MASTERPos = MASTERBindingSource.Find("MASTER_ACC_NO", lsMasterKey);

            if (MASTHISTPos > -1)
            {
                loMASTHISTSeq = MASTHISTTableAdapter.SeqNoQuery(lsMasterKey, DateTime.Now.Date);
                if (loMASTHISTSeq != null)
                    lnSeq = (int)loMASTHISTSeq + 1;
                else
                    lnSeq = 1;
                // Set up the new history record key
                PAYMENTDataSet.MASTHIST.Rows[MASTHISTPos].SetField<String>("MASTHIST_ACC_NO", PAYMENTDataSet.MASTER.Rows[MASTERPos].Field<String>("MASTER_ACC_NO"));
                PAYMENTDataSet.MASTHIST.Rows[MASTHISTPos].SetField<Int32>("MASTHIST_SEQ_NO", lnSeq);
                PAYMENTDataSet.MASTHIST.Rows[MASTHISTPos].SetField<DateTime>("MASTHIST_POST_DATE", DateTime.Now.Date);
                PAYMENTDataSet.MASTHIST.Rows[MASTHISTPos].SetField<String>("MASTHIST_NAME", PAYMENTDataSet.MASTER.Rows[MASTERPos].Field<String>("MASTER_NAME"));
                PAYMENTDataSet.MASTHIST.Rows[MASTHISTPos].SetField<String>("MASTHIST_IAC_TYPE", "C");

                //  End of MASTHIST KEY

                PAYMENTDataSet.MASTHIST.Rows[MASTHISTPos].SetField<Decimal>("MASTHIST_CUR_INT", PAYMENTDataSet.MASTER.Rows[MASTERPos].Field<Decimal>("MASTER_CUR_INT"));
                PAYMENTDataSet.MASTHIST.Rows[MASTHISTPos].SetField<Decimal>("MASTHIST_YTD_INT", PAYMENTDataSet.MASTER.Rows[MASTERPos].Field<Decimal>("MASTER_YTD_INT"));
            }

            MASTHISTBindingSource.AddNew();
            MASTHISTBindingSource.EndEdit();

            MASTHISTPos = MASTHISTBindingSource.Position;

            loMasterKey = ACCOUNTTableAdapter.AccountNumber("AMORT_INT");
            lsMasterKey = (String)loMasterKey;
            MASTERPos = MASTERBindingSource.Find("MASTER_ACC_NO", lsMasterKey);

            if (MASTHISTPos > -1)
            {
                loMASTHISTSeq = MASTHISTTableAdapter.SeqNoQuery(lsMasterKey, DateTime.Now.Date);
                if (loMASTHISTSeq != null)
                    lnSeq = (int)loMASTHISTSeq + 1;
                else
                    lnSeq = 1;
                // Set up the new history record key
                PAYMENTDataSet.MASTHIST.Rows[MASTHISTPos].SetField<String>("MASTHIST_ACC_NO", PAYMENTDataSet.MASTER.Rows[MASTERPos].Field<String>("MASTER_ACC_NO"));
                PAYMENTDataSet.MASTHIST.Rows[MASTHISTPos].SetField<Int32>("MASTHIST_SEQ_NO", lnSeq);
                PAYMENTDataSet.MASTHIST.Rows[MASTHISTPos].SetField<DateTime>("MASTHIST_POST_DATE", DateTime.Now.Date);
                PAYMENTDataSet.MASTHIST.Rows[MASTHISTPos].SetField<String>("MASTHIST_NAME", PAYMENTDataSet.MASTER.Rows[MASTERPos].Field<String>("MASTER_NAME"));
                PAYMENTDataSet.MASTHIST.Rows[MASTHISTPos].SetField<String>("MASTHIST_IAC_TYPE", "C");

                //  End of MASTHIST KEY

                PAYMENTDataSet.MASTHIST.Rows[MASTHISTPos].SetField<Decimal>("MASTHIST_AMORT_CUR_INT", PAYMENTDataSet.MASTER.Rows[MASTERPos].Field<Decimal>("MASTER_AMORT_CUR_INT"));
                PAYMENTDataSet.MASTHIST.Rows[MASTHISTPos].SetField<Decimal>("MASTHIST_AMORT_YTD_INT", PAYMENTDataSet.MASTER.Rows[MASTERPos].Field<Decimal>("MASTER_AMORT_YTD_INT"));
            }

            MASTHISTBindingSource.AddNew();
            MASTHISTBindingSource.EndEdit();

            MASTHISTPos = MASTHISTBindingSource.Position;

            loMasterKey = ACCOUNTTableAdapter.AccountNumber("SIMPLE_INT");
            lsMasterKey = (String)loMasterKey;
            MASTERPos = MASTERBindingSource.Find("MASTER_ACC_NO", lsMasterKey);

            if (MASTHISTPos > -1)
            {
                loMASTHISTSeq = MASTHISTTableAdapter.SeqNoQuery(lsMasterKey, DateTime.Now.Date);
                if (loMASTHISTSeq != null)
                    lnSeq = (int)loMASTHISTSeq + 1;
                else
                    lnSeq = 1;
                // Set up the new history record key
                PAYMENTDataSet.MASTHIST.Rows[MASTHISTPos].SetField<String>("MASTHIST_ACC_NO", PAYMENTDataSet.MASTER.Rows[MASTERPos].Field<String>("MASTER_ACC_NO"));
                PAYMENTDataSet.MASTHIST.Rows[MASTHISTPos].SetField<Int32>("MASTHIST_SEQ_NO", lnSeq);
                PAYMENTDataSet.MASTHIST.Rows[MASTHISTPos].SetField<DateTime>("MASTHIST_POST_DATE", DateTime.Now.Date);
                PAYMENTDataSet.MASTHIST.Rows[MASTHISTPos].SetField<String>("MASTHIST_NAME", PAYMENTDataSet.MASTER.Rows[MASTERPos].Field<String>("MASTER_NAME"));
                PAYMENTDataSet.MASTHIST.Rows[MASTHISTPos].SetField<String>("MASTHIST_IAC_TYPE", "C");

                //  End of MASTHIST KEY

                PAYMENTDataSet.MASTHIST.Rows[MASTHISTPos].SetField<Decimal>("MASTHIST_SIMPLE_CUR_INT", PAYMENTDataSet.MASTER.Rows[MASTERPos].Field<Decimal>("MASTER_SIMPLE_CUR_INT"));
                PAYMENTDataSet.MASTHIST.Rows[MASTHISTPos].SetField<Decimal>("MASTHIST_SIMPLE_YTD_INT", PAYMENTDataSet.MASTER.Rows[MASTERPos].Field<Decimal>("MASTER_SIMPLE_YTD_INT"));
            }

            worker.ReportProgress(48);
        }

        void SumDealerTotals(int PaymentPos, Int32 CustomerPos, ref IACDataSet PAYMENTDataSet, ref BackgroundWorker worker)
        {
            int WSDealerPos = 0;

            IACDataSetTableAdapters.PaymentDistributionTableAdapter PaymentDistributionTableAdapter = new IACDataSetTableAdapters.PaymentDistributionTableAdapter();
            IACDataSetTableAdapters.WS_DEALER_PAYTableAdapter WS_DEALER_PAYTableAdapter = new IACDataSetTableAdapters.WS_DEALER_PAYTableAdapter();
            BindingSource WS_DEALER_PAYBindingsource = new BindingSource();
            BindingSource PaymentDistributionBindingsource = new BindingSource();

            WS_DEALER_PAYBindingsource.DataSource = PAYMENTDataSet.WS_DEALER_PAY;
            PaymentDistributionBindingsource.DataSource = PAYMENTDataSet.PaymentDistribution;

            WS_DEALER_PAYBindingsource.MoveFirst();
            WSDealerPos = WS_DEALER_PAYBindingsource.Find("KEY", PAYMENTDataSet.CUSTOMER.Rows[CustomerPos].Field<String>("CUSTOMER_DEALER"));
            if (WSDealerPos >= 0)
            {
                // Moses Newman 08/20/2012  Fix rounding
                // Moses Newman 03/05/2012  Change lnBalance to lnSimpleDiff for new simple interest style posting
                PAYMENTDataSet.WS_DEALER_PAY.Rows[WSDealerPos].SetField<Decimal>("OS_L", PAYMENTDataSet.WS_DEALER_PAY.Rows[WSDealerPos].Field<Decimal>("OS_L") - lnSimpleDiff);
                if (PAYMENTDataSet.CUSTOMER.Rows[CustomerPos].Field<String>("CUSTOMER_PAY_REM_1").TrimEnd() == "PAID")
                    lnIntAdj = lnCustUEI;
                else
                    lnIntAdj = 0;
                PAYMENTDataSet.WS_DEALER_PAY.Rows[WSDealerPos].SetField<Decimal>("INT", PAYMENTDataSet.WS_DEALER_PAY.Rows[WSDealerPos].Field<Decimal>("INT") + Convert.ToDecimal(lnAccruedInt - lnIntAdj));

                switch (PAYMENTDataSet.CUSTOMER.Rows[CustomerPos].Field<String>("CUSTOMER_AMORTIZE_IND"))
                {
                    case "Y":
                        PAYMENTDataSet.WS_DEALER_PAY.Rows[WSDealerPos].SetField<Decimal>("AMORT_INT", PAYMENTDataSet.WS_DEALER_PAY.Rows[WSDealerPos].Field<Decimal>("AMORT_INT") + Convert.ToDecimal(lnAccruedInt - lnIntAdj));
                        PAYMENTDataSet.WS_DEALER_PAY.Rows[WSDealerPos].SetField<Decimal>("AMORT_ADJ", PAYMENTDataSet.WS_DEALER_PAY.Rows[WSDealerPos].Field<Decimal>("AMORT_ADJ") + Convert.ToDecimal(lnIntAdj));
                        break;
                    case "S":
                    case "N":  // Moses Newman 04/30/2017 Handle S for Simple and N for Normal Interest!
                        if (PAYMENTDataSet.PAYMENT.Rows[PaymentPos].Field<Boolean>("IsSimple"))
                        {
                            PAYMENTDataSet.WS_DEALER_PAY.Rows[WSDealerPos].SetField<Decimal>("SIMPLE_INT", PAYMENTDataSet.WS_DEALER_PAY.Rows[WSDealerPos].Field<Decimal>("SIMPLE_INT") + Convert.ToDecimal(lnAccruedInt - lnIntAdj));
                            PAYMENTDataSet.WS_DEALER_PAY.Rows[WSDealerPos].SetField<Decimal>("SIMPLE_ADJ", PAYMENTDataSet.WS_DEALER_PAY.Rows[WSDealerPos].Field<Decimal>("SIMPLE_ADJ") + Convert.ToDecimal(lnIntAdj));
                        }
                        else
                        {
                            PAYMENTDataSet.WS_DEALER_PAY.Rows[WSDealerPos].SetField<Decimal>("AMORT_INT", PAYMENTDataSet.WS_DEALER_PAY.Rows[WSDealerPos].Field<Decimal>("AMORT_INT") + Convert.ToDecimal(lnAccruedInt - lnIntAdj));
                            PAYMENTDataSet.WS_DEALER_PAY.Rows[WSDealerPos].SetField<Decimal>("AMORT_ADJ", PAYMENTDataSet.WS_DEALER_PAY.Rows[WSDealerPos].Field<Decimal>("AMORT_ADJ") + Convert.ToDecimal(lnIntAdj));
                        }
                        break;
                    default:
                        PAYMENTDataSet.WS_DEALER_PAY.Rows[WSDealerPos].SetField<Decimal>("OLD_INT", PAYMENTDataSet.WS_DEALER_PAY.Rows[WSDealerPos].Field<Decimal>("OLD_INT") + Convert.ToDecimal(lnAccruedInt - lnIntAdj));
                        PAYMENTDataSet.WS_DEALER_PAY.Rows[WSDealerPos].SetField<Decimal>("OLD_ADJ", PAYMENTDataSet.WS_DEALER_PAY.Rows[WSDealerPos].Field<Decimal>("OLD_ADJ") + Convert.ToDecimal(lnIntAdj));
                        break;

                }
                // Moses Newman 03/13/2018 add sequence number
                PaymentDistributionTableAdapter.Delete(PAYMENTDataSet.PAYMENT.Rows[PaymentPos].Field<String>("PAYMENT_CUSTOMER"), PAYMENTDataSet.PAYMENT.Rows[PaymentPos].Field<DateTime>("PAYMENT_DATE"),PAYMENTDataSet.PAYMENT.Rows[PaymentPos].Field<Int32>("SeqNo"));
                PaymentDistributionBindingsource.AddNew();
                PaymentDistributionBindingsource.EndEdit();
                PAYMENTDataSet.PaymentDistribution.Rows[PaymentDistributionBindingsource.Position].SetField<String>("Customer_no", PAYMENTDataSet.PAYMENT.Rows[PaymentPos].Field<String>("PAYMENT_CUSTOMER"));
                PAYMENTDataSet.PaymentDistribution.Rows[PaymentDistributionBindingsource.Position].SetField<DateTime>("PaymentDate", PAYMENTDataSet.PAYMENT.Rows[PaymentPos].Field<DateTime>("PAYMENT_DATE"));
                PAYMENTDataSet.PaymentDistribution.Rows[PaymentDistributionBindingsource.Position].SetField<Decimal>("Amount", PAYMENTDataSet.PAYMENT.Rows[PaymentPos].Field<Decimal>("PAYMENT_AMOUNT_RCV"));
                PAYMENTDataSet.PaymentDistribution.Rows[PaymentDistributionBindingsource.Position].SetField<Decimal>("LateChargePaid", (Decimal)lnLateChargePaid);
                PAYMENTDataSet.PaymentDistribution.Rows[PaymentDistributionBindingsource.Position].SetField<Decimal>("InterestPaid", (Decimal)lnAccruedInt);
                PAYMENTDataSet.PaymentDistribution.Rows[PaymentDistributionBindingsource.Position].SetField<Decimal>("InterestAccrued", (Decimal)lnAccruedInt);
                // Moses Newman Principal Paid is really Credit To Notes Receivable NOT Principle paid, lnSimpleDiff is in the reverse sign.
                PAYMENTDataSet.PaymentDistribution.Rows[PaymentDistributionBindingsource.Position].SetField<Decimal>("PrincipalPaid", lnSimpleDiff * -1);
                PAYMENTDataSet.PaymentDistribution.Rows[PaymentDistributionBindingsource.Position].SetField<Decimal>("OverPayment", (Decimal)lnCustOP);
                PAYMENTDataSet.PaymentDistribution.Rows[PaymentDistributionBindingsource.Position].SetField<Decimal>("Extension", (Decimal)lnCustExt);
                PAYMENTDataSet.PaymentDistribution.Rows[PaymentDistributionBindingsource.Position].SetField<Decimal>("PaidDiscount", (Decimal)lnPaidDiscount);
                PAYMENTDataSet.PaymentDistribution.Rows[PaymentDistributionBindingsource.Position].SetField<Decimal>("UnearnedInterest", (Decimal)lnCustUEI);
                PAYMENTDataSet.PaymentDistribution.Rows[PaymentDistributionBindingsource.Position].SetField<Int32>("SeqNo", PAYMENTDataSet.PAYMENT.Rows[PaymentPos].Field<Int32>("SeqNo"));

                PaymentDistributionBindingsource.EndEdit();
                PaymentDistributionTableAdapter.Update(PAYMENTDataSet.PaymentDistribution.Rows[PaymentDistributionBindingsource.Position]);
                PaymentDistributionTableAdapter.Fill(PAYMENTDataSet.PaymentDistribution, PAYMENTDataSet.CUSTOMER.Rows[CustomerPos].Field<String>("CUSTOMER_NO"), PAYMENTDataSet.PAYMENT.Rows[PaymentPos].Field<DateTime>("PAYMENT_DATE"), PAYMENTDataSet.PAYMENT.Rows[PaymentPos].Field<Int32>("SeqNo"));
            }
        }

        // Moses Newman 11/29/2014 Finally got rid of Frank's legacy COBOL converted Algorithms!!!
        // Now Calls Stored Procedure to calculate Partial Payments and stores the whole number and not a fraction now!
        // Moses Newman 12/22/2014 must now pass the Post paramaeter to determine if the CUSTOMER record should be rewritten or not!
        void ClosedPaymentPartialPayment(int PaymentPos, Int32 CustomerPos, ref IACDataSet PAYMENTDataSet, ref BackgroundWorker worker, Boolean Post = false)
        {
            // Moses Newman 12/22/2014 must now pass the Post paramaeter to determine if the CUSTOMER record should be rewritten or not!
            GetPartialPaymentandLateFeeBalance(ref worker,PAYMENTDataSet.CUSTOMER.Rows[CustomerPos].Field<String>("CUSTOMER_NO"), ref PAYMENTDataSet,CustomerPos, true, PaymentPos,Post);
            CUSTOMERBindingSource.EndEdit();
            PAYMENTDataSet.CUSTOMER.Rows[CustomerPos].SetField<Double>("CUSTOMER_PARTIAL_PAYMENTS", (Double)(PAYMENTDataSet.CUSTOMER.Rows[CustomerPos].Field<Decimal>("PartialPayment") / PAYMENTDataSet.CUSTOMER.Rows[CustomerPos].Field<Decimal>("CUSTOMER_REGULAR_AMOUNT")));
        }

        void ClosedPaymentAccumIOL(int PaymentPos, ref IACDataSet PAYMENTDataSet, ref BackgroundWorker worker)
        {
            lnMasterInterest += lnAccruedInt;

            lnMasterDiscount += (Decimal)lnPaidDiscount;

            // Moses Newman 03/05/2013 Simple Interest change lnBalance to lnSimpleDiff
            // Moses Newman 08/2/2013 changed to properly adjust MasterOloan
            lnMasterOloan -= lnSimpleDiff;

            switch (PAYMENTDataSet.PAYMENT.Rows[PaymentPos].Field<String>("PAYMENT_TYPE"))
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
                    lnMasterNPNP += PAYMENTDataSet.PAYMENT.Rows[PaymentPos].Field<Decimal>("PAYMENT_AMOUNT_RCV");
                    lnNonCashFeesandCharges = lnMasterOloan;
                    break;
                default:
                    lnMasterNP += PAYMENTDataSet.PAYMENT.Rows[PaymentPos].Field<Decimal>("PAYMENT_AMOUNT_RCV");
                    break;
            }
        }

        void ClosedPaymentAmortAccumIOL(int PaymentPos, ref IACDataSet PAYMENTDataSet, ref BackgroundWorker worker)
        {
            if (PAYMENTDataSet.CUSTOMER.FindByCustomerID(Convert.ToInt32(PAYMENTDataSet.PAYMENT.Rows[PaymentPos].Field<String>("PAYMENT_CUSTOMER"))).CUSTOMER_AMORTIZE_IND == "S" &&
                PAYMENTDataSet.PAYMENT.Rows[PaymentPos].Field<Boolean>("IsSimple"))
            {
                lnMasterSimpleInterest += lnAccruedInt;

                lnMasterSimpleDiscount += (Decimal)lnPaidDiscount;
                // Moses Newman 03/05/2013 Simple Interest change lnBalance to lnSimpleDiff
                lnMasterSimpleOloan -= lnSimpleDiff;
            }
            else
            {
                lnMasterAmortInterest += lnAccruedInt;

                lnMasterAmortDiscount += (Decimal)lnPaidDiscount;

                lnMasterAmortOloan += lnBalance;
            }
            switch (PAYMENTDataSet.PAYMENT.Rows[PaymentPos].Field<String>("PAYMENT_TYPE"))
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
                    break;
                default:
                    lnMasterAmortNP += PAYMENTDataSet.PAYMENT.Rows[PaymentPos].Field<Decimal>("PAYMENT_AMOUNT_RCV");
                    break;
            }
        }

        void ClosedPaymentWriteCustomerChanges(ref IACDataSet CUSTOMERDataSet, ref BackgroundWorker worker)
        {
            IACDataSetTableAdapters.CUSTOMERTableAdapter CUSTOMERTableAdapter = new IACDataSetTableAdapters.CUSTOMERTableAdapter();
            CUSTOMERBindingSource.MoveFirst();
            CUSTOMERBindingSource.EndEdit();
            try
            {
                CUSTOMERTableAdapter.Update(CUSTOMERDataSet.CUSTOMER);
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
                worker.ReportProgress(62);
            }
        }

        void ClosedPaymentWriteCustHistChanges(ref IACDataSet CUSTOMERDataSet, ref BackgroundWorker worker)
        {
            Object loCustHistSeq = null;
            Int32 lnSeq = 0;

            IACDataSetTableAdapters.CUSTHISTTableAdapter CUSTHISTTableAdapter = new IACDataSetTableAdapters.CUSTHISTTableAdapter();
            BindingSource CUSTHISTBindingSource = new BindingSource();

            CUSTHISTBindingSource.DataSource = CUSTOMERDataSet.CUSTHIST;

            try
            {
                CUSTHISTBindingSource.MoveFirst();
                for (int i = 0; i < CUSTOMERDataSet.CUSTHIST.Rows.Count; i++)
                {
                    loCustHistSeq = CUSTHISTTableAdapter.SeqNoQuery(CUSTOMERDataSet.CUSTHIST.Rows[i].Field<String>("CUSTHIST_NO"), CUSTOMERDataSet.CUSTHIST.Rows[i].Field<DateTime>("CUSTHIST_PAY_DATE"));
                    // Moses Newman 03/13/2018 Handle sequence number now that there may be mutiple records for the same customer.
                    if (loCustHistSeq != null)
                        lnSeq = (int)loCustHistSeq + CUSTOMERDataSet.CUSTHIST.Rows[i].Field<Int32>("CUSTHIST_DATE_SEQ");
                    else
                        lnSeq = CUSTOMERDataSet.CUSTHIST.Rows[i].Field<Int32>("CUSTHIST_DATE_SEQ");
                    // Moses Newman 09/30/2019 Handle duplicate Sequence #
                    try
                    {
                        CUSTOMERDataSet.CUSTHIST.Rows[i].SetField<Int32>("CUSTHIST_DATE_SEQ", lnSeq);
                    }
                    catch(System.Data.ConstraintException)
                    {
                        lnSeq += 10;
                        CUSTOMERDataSet.CUSTHIST.Rows[i].SetField<Int32>("CUSTHIST_DATE_SEQ", lnSeq);
                    }
                    CUSTHISTBindingSource.EndEdit();

                    // Moses Newman 09/11/2013 Remove paid flag if returned check changed status
                    if (CUSTOMERDataSet.CUSTHIST.Rows[i].Field<String>("CUSTHIST_PAYMENT_TYPE") == "I" && CUSTOMERDataSet.CUSTHIST.Rows[i].Field<String>("CUSTHIST_ACT_STAT") == "I")
                    {
                        CUSTHISTTableAdapter.UnflagLastPaidRecord(CUSTOMERDataSet.CUSTHIST.Rows[i].Field<String>("CUSTHIST_NO"));
                    }
                    // Moses Newman 10/10/2020 set bounced check IsINSUF flag
                    // Moses Newman 11/16/2020 Or reverese credit card! Or adjustment tied to check!
                    if (CUSTOMERDataSet.CUSTHIST.Rows[i].Field<String>("CUSTHIST_PAYMENT_TYPE") == "I" || ((CUSTOMERDataSet.CUSTHIST.Rows[i].Field<Int32?>("ISFID") != null) ? CUSTOMERDataSet.CUSTHIST.Rows[i].Field<Int32>("ISFID"):0) != 0)
                        CUSTHISTTableAdapter.ClosedCustomerHistorySetISINSUF(CUSTOMERDataSet.CUSTHIST.Rows[i].Field<Int32>("ISFID"));
                }
                CUSTHISTTableAdapter.Update(CUSTOMERDataSet.CUSTHIST);
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
                CUSTOMERDataSet.CUSTHIST.AcceptChanges();
                CUSTHISTBindingSource.Dispose();
                CUSTHISTTableAdapter.Dispose();
                worker.ReportProgress(68);
            }
        }

        void ClosedPaymentWriteDealerChanges(ref IACDataSet DEALERDataSet, ref BackgroundWorker worker)
        {
            IACDataSetTableAdapters.DEALERTableAdapter DEALERTableAdapter = new IACDataSetTableAdapters.DEALERTableAdapter();

            DEALERBindingSource.MoveFirst();

            DEALERBindingSource.EndEdit();
            try
            {
                DEALERTableAdapter.Update(DEALERDataSet.DEALER);
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
                worker.ReportProgress(74);
            }
        }

        void ClosedPaymentWriteDealHistChanges(ref IACDataSet DEALERDataSet, ref BackgroundWorker worker)
        {
            Object loDealhistSeq = null;
            Int32 lnSeq = 0;

            IACDataSetTableAdapters.DEALHISTTableAdapter DEALHISTTableAdapter = new IACDataSetTableAdapters.DEALHISTTableAdapter();

            try
            {

                DEALHISTBindingSource.MoveFirst();
                for (int i = 0; i < DEALERDataSet.DEALHIST.Rows.Count; i++)
                {
                    loDealhistSeq = DEALHISTTableAdapter.SeqNoQuery(DEALERDataSet.DEALHIST.Rows[i].Field<String>("DEALHIST_ACC_NO"), DateTime.Now.Date, DateTime.Now.Date);
                    if (loDealhistSeq != null)
                        lnSeq = (int)loDealhistSeq + 1;
                    else
                        lnSeq = 0;
                    DEALERDataSet.DEALHIST.Rows[i].SetField<Int32>("DEALHIST_SEQ_NO", lnSeq);
                    DEALERDataSet.DEALHIST.Rows[i].SetField<DateTime>("DEALHIST_LAST_POST_DATE", DateTime.Now.Date);
                    DEALHISTBindingSource.EndEdit();
                }
                DEALHISTTableAdapter.Update(DEALERDataSet.DEALHIST);
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
                DEALERDataSet.DEALHIST.AcceptChanges();
                DEALHISTBindingSource.Dispose();
                DEALHISTTableAdapter.Dispose();
                worker.ReportProgress(80);
            }
        }

        void ClosedPaymentWriteMASTerChanges(ref IACDataSet MASTERDataSet, ref BackgroundWorker worker)
        {
            IACDataSetTableAdapters.MASTERTableAdapter MASTERTableAdapter = new IACDataSetTableAdapters.MASTERTableAdapter();
            MASTERBindingSource.MoveFirst();
            MASTERBindingSource.EndEdit();
            try
            {
                MASTERTableAdapter.Update(MASTERDataSet.MASTER);
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
                worker.ReportProgress(86);
            }
        }

        public void ClosedPaymentWriteMASTHistChanges(ref IACDataSet MASTERDataSet, ref BackgroundWorker worker)
        {
            Object loMASTHISTSeq = null;
            Int32 lnSeq = 0;

            IACDataSetTableAdapters.MASTHISTTableAdapter MASTHISTTableAdapter = new IACDataSetTableAdapters.MASTHISTTableAdapter();
            BindingSource MASTHISTBindingSource = new BindingSource();

            MASTHISTBindingSource.DataSource = MASTERDataSet.MASTHIST;

            try
            {
                MASTHISTBindingSource.MoveFirst();
                for (int i = 0; i < MASTERDataSet.MASTHIST.Rows.Count; i++)
                {
                    loMASTHISTSeq = MASTHISTTableAdapter.SeqNoQuery(MASTERDataSet.MASTHIST.Rows[i].Field<String>("MASTHIST_ACC_NO"), DateTime.Now.Date);
                    if (loMASTHISTSeq != null)
                        lnSeq = (int)loMASTHISTSeq + 1;
                    else
                        lnSeq = 1;
                    MASTERDataSet.MASTHIST.Rows[i].SetField<Int32>("MASTHIST_SEQ_NO", lnSeq);
                    MASTHISTBindingSource.EndEdit();
                }
                MASTHISTTableAdapter.Update(MASTERDataSet.MASTHIST);
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
                MASTERDataSet.MASTHIST.AcceptChanges();
                MASTHISTBindingSource.Dispose();
                MASTHISTTableAdapter.Dispose();
                worker.ReportProgress(92);
            }
        }

        // Moses Newman 12/1/2014 Complete Partial Payment Late Fee Balance Paid Throughs and Number of Payments Made
        public void GetPartialPaymentandLateFeeBalance(ref BackgroundWorker worker, String tsCustomerNo, ref IACDataSet DT, Int32 CustPos = 0, Boolean tbPayment = false,
            Int32 tnPaymentPos = -1, Boolean tbPost = false, Boolean UpdateLast = false)
        {
            IACDataSetTableAdapters.CUSTOMERTableAdapter CUSTOMERTableAdapter = new IACDataSetTableAdapters.CUSTOMERTableAdapter();
            IACDataSetTableAdapters.CUSTHISTTableAdapter CUSTHISTTableAdapter = new IACDataSetTableAdapters.CUSTHISTTableAdapter();
            IACDataSetTableAdapters.TVAmortTableAdapter TVAmortTableAdapter = new IACDataSetTableAdapters.TVAmortTableAdapter();
            IACDataSetTableAdapters.PAYMENTTableAdapter PAYMENTTableAdapter = new IACDataSetTableAdapters.PAYMENTTableAdapter();

            Decimal lnSimpBal = 0;

            if (DT.CUSTOMER.Rows.Count == 0)
            {
                CUSTOMERTableAdapter.Fill(DT.CUSTOMER, tsCustomerNo);
                CustPos = 0;
            }

            if (tbPayment && tnPaymentPos != -1)
            {
                lnSimpBal = Program.TVSimpleGetBuyout(DT, DT.PAYMENT.Rows[tnPaymentPos].Field<DateTime>("PAYMENT_DATE").Date,
                                 (Double)DT.CUSTOMER.Rows[CustPos].Field<Int32>("CUSTOMER_TERM"),
                                 (Double)(DT.CUSTOMER.Rows[CustPos].Field<Decimal>("CUSTOMER_ANNUAL_PERCENTAGE_RATE") / 100),
                                 (Double)DT.CUSTOMER.Rows[CustPos].Field<Decimal>("CUSTOMER_REGULAR_AMOUNT"),
                                 DT.CUSTOMER.Rows[CustPos].Field<String>("CUSTOMER_NO"),
                                 // 04/30/2017 Handle BOTH Simple Interest and Normal Daily Compounding
                                 // Moses Newman 04/02/2018 fixed Payment and PaymentPos parameters so TVSimpleGetBuyout knows to add payments!
                                 DT.CUSTOMER.Rows[CustPos].Field<String>("CUSTOMER_AMORTIZE_IND") == "S" ? true : false, true, false, tbPayment, tnPaymentPos, true);
            }
            lnSimpleBalance = lnSimpBal;
            TVAmortTableAdapter.FillByCustomerNo(DT.TVAmort, tsCustomerNo);
            Program.FixLateandPartialBuckets(tsCustomerNo,tbPayment); // Moses Newman 09/19/2018 Tell FixLateandPartialBuckets to use ALL of todays payments for this customer!
            TVAmortTableAdapter.FillByCustomerNo(DT.TVAmort, tsCustomerNo);
            Int32 LastRow = DT.TVAmort.Rows.Count - 1, lnNumPay = 0;
            Decimal lnLateCharge = 0;
            Object loNumPay = null,loLateCharge = null;
            loNumPay = TVAmortTableAdapter.NumberofPayments(tsCustomerNo);
            if (loNumPay != null)
                lnNumPay = (Int32)loNumPay;

            loLateCharge = CUSTOMERTableAdapter.LateCharge(tsCustomerNo);
            if (loLateCharge != null)
                lnLateCharge = (Decimal)loLateCharge;

            DT.CUSTOMER.Rows[CustPos].SetField<Decimal>("PartialPayment", DT.TVAmort.Rows[LastRow].Field<Decimal>("PartialPayment"));
            // Moses Newman 04/24/2018 if the second to last row is a late use its latecharge!
            if (DT.TVAmort.Rows[LastRow - 1].Field<String>("Event").Trim() != "LATE")
                DT.CUSTOMER.Rows[CustPos].SetField<Decimal>("CUSTOMER_LATE_CHARGE", lnLateCharge);
            else
                DT.CUSTOMER.Rows[CustPos].SetField<Decimal>("CUSTOMER_LATE_CHARGE", DT.TVAmort.Rows[LastRow - 1].Field<Decimal>("LateFee"));
            DT.CUSTOMER.Rows[CustPos].SetField<Decimal>("CUSTOMER_LATE_CHARGE_BAL", DT.TVAmort.Rows[LastRow].Field<Decimal?>("LateFeeBalance") != null ? DT.TVAmort.Rows[LastRow].Field<Decimal>("LateFeeBalance"):0);

            DT.CUSTOMER.Rows[CustPos].SetField<Int32>("CUSTOMER_NO_OF_PAYMENTS_MADE", lnNumPay);
            DT.CUSTOMER.Rows[CustPos].SetField<Int32>("CUSTOMER_PAY_REM_2", DT.CUSTOMER.Rows[CustPos].Field<Int32>("CUSTOMER_TERM") - lnNumPay);
            DT.CUSTOMER.Rows[CustPos].SetField<String>("CUSTOMER_PAID_THRU", 
                            DT.TVAmort.Rows[LastRow].Field<DateTime>("PaidThrough").Date.Month.ToString().Trim().PadLeft(2, '0') + 
                            DT.TVAmort.Rows[LastRow].Field<DateTime>("Paidthrough").Date.Year.ToString().Trim().Substring(2, 2));
            if (DT.TVAmort.Rows[LastRow - 1].Field<Decimal?>("ContractStatus") != null)
                DT.CUSTOMER.Rows[CustPos].SetField<Decimal>("CUSTOMER_CONTRACT_STATUS", DT.TVAmort.Rows[LastRow - 1].Field<Decimal>("ContractStatus"));
            else
                DT.CUSTOMER.Rows[CustPos].SetField<Decimal>("CUSTOMER_CONTRACT_STATUS", 0);
            DT.CUSTOMER.Rows[CustPos].EndEdit();
            // Moses Newman 12/22/2014 DO NOT Update Customer Record Unless Posting!
            if (tbPost)
            {
                CUSTOMERTableAdapter.Update(DT.CUSTOMER.Rows[CustPos]);
                if (UpdateLast)
                    CUSTHISTTableAdapter.UpdateLastRecord(tsCustomerNo);
            }
            CUSTOMERTableAdapter.Dispose();
            CUSTHISTTableAdapter.Dispose();
            PAYMENTTableAdapter.Dispose();
            TVAmortTableAdapter.Dispose();
        }

        public void ResetHistoryPaidThroughandLateChargeBalance(ref BackgroundWorker worker,string tsCustomerNo)
        {
            IACDataSet ResetDT = new IACDataSet();
            String Event = "";
            DateTime Date;
            DateTime? ISFDate;

            IACDataSetTableAdapters.CUSTOMERTableAdapter CUSTOMERTableAdapter = new IACDataSetTableAdapters.CUSTOMERTableAdapter();
            IACDataSetTableAdapters.CUSTHISTTableAdapter CUSTHISTTableAdapter = new IACDataSetTableAdapters.CUSTHISTTableAdapter();
            IACDataSetTableAdapters.TVAmortTableAdapter TVAmortTableAdapter = new IACDataSetTableAdapters.TVAmortTableAdapter();

            TVAmortTableAdapter.FillByCustomerNo(ResetDT.TVAmort, tsCustomerNo);

            Object loContractStatus = null;

            for (int i = 0; i < ResetDT.TVAmort.Rows.Count; i++)
            {
                Event = ResetDT.TVAmort.Rows[i].Field<String>("Event").TrimEnd();
                if (Event != "BUYOUT" && Event != "UNEARNED")
                {
                    CUSTHISTTableAdapter.FillByEventDateAcct(ResetDT.CUSTHIST, tsCustomerNo,
                                                             ResetDT.TVAmort.Rows[i].Field<DateTime>("Date"),
                                                             ResetDT.TVAmort.Rows[i].Field<String>("Event"),
                                                             ResetDT.TVAmort.Rows[i].Field<Nullable<Int32>>("HistorySeq"));
                    if( ResetDT.CUSTHIST.Rows.Count == 0)
                        CUSTHISTTableAdapter.FillByEventDateAcct(ResetDT.CUSTHIST, tsCustomerNo,
                                                                  ResetDT.TVAmort.Rows[i].Field<DateTime>("Date"),
                                                                  "PAID",
                                                                  ResetDT.TVAmort.Rows[i].Field<Nullable<Int32>>("HistorySeq"));
                    if (ResetDT.CUSTHIST.Rows.Count == 0)
                        continue;
                    Date = ResetDT.CUSTHIST.Rows[0].Field<DateTime>("CUSTHIST_PAY_DATE");
                    ISFDate = ResetDT.CUSTHIST.Rows[0].Field<Nullable<DateTime>>("CUSTHIST_ISF_DATE");

                    // Moses Newman 12/31/2014 Need Late Charge Balance in History in order for Contract Status to work!
                    ResetDT.CUSTHIST.Rows[0].SetField<Decimal>("CUSTHIST_LATE_CHARGE_BAL", ResetDT.TVAmort.Rows[i].Field<Decimal>("LateFeeBalance"));
                    CUSTOMERTableAdapter.Fill(ResetDT.CUSTOMER, tsCustomerNo);
                    // Moses Newman 06/30/2015 Make sure PartialPayment field in CUSTHIST gets updated!
                    ResetDT.CUSTHIST.Rows[0].SetField<Decimal>("PartialPayment", ResetDT.TVAmort.Rows[i].Field<Decimal>("PartialPayment"));
                    loContractStatus = CUSTHISTTableAdapter.ContractStatus(tsCustomerNo, (Event != "INSUF" || ISFDate == null) ? Date : ISFDate, ResetDT.TVAmort.Rows[i].Field<DateTime>("PaidThrough").Month.ToString().PadLeft(2, '0') + ResetDT.TVAmort.Rows[i].Field<DateTime>("PaidThrough").Year.ToString().Substring(2, 2), ResetDT.TVAmort.Rows[i].Field<Decimal>("PartialPayment"), false);
                    if (loContractStatus != null)
                    {
                        // Moses Newman 05/27/2015 Handle zeroind of Status if PAID
                        if (ResetDT.CUSTHIST.Rows[0].Field<String>("CUSTHIST_PAY_REM_1").TrimEnd() != "UPD" || ResetDT.CUSTHIST.Rows[0].Field<String>("CUSTHIST_ACT_STAT") == "A" )
                        {
                            ResetDT.CUSTHIST.Rows[0].SetField<Decimal>("CUSTHIST_CONTRACT_STATUS", (Decimal)loContractStatus);
                            if (ResetDT.CUSTOMER.Rows.Count > 0)
                                ResetDT.CUSTOMER.Rows[0].SetField<Decimal>("CUSTOMER_CONTRACT_STATUS", ResetDT.CUSTHIST.Rows[0].Field<Decimal>("CUSTHIST_CONTRACT_STATUS"));
                        }
                        else
                        {
                            ResetDT.CUSTHIST.Rows[0].SetField<Decimal>("CUSTHIST_CONTRACT_STATUS", 0);
                            if (ResetDT.CUSTOMER.Rows.Count > 0)
                                ResetDT.CUSTOMER.Rows[0].SetField<Decimal>("CUSTOMER_CONTRACT_STATUS", 0);
                        }
                    }
                    ResetDT.CUSTHIST.Rows[0].SetField<String>("CUSTHIST_PAID_THRU", ResetDT.TVAmort.Rows[i].Field<DateTime>("PaidThrough").Month.ToString().PadLeft(2, '0') + ResetDT.TVAmort.Rows[i].Field<DateTime>("PaidThrough").Year.ToString().Substring(2, 2));
                    if (ResetDT.CUSTOMER.Rows.Count > 0) 
                        ResetDT.CUSTOMER.Rows[0].SetField<String>("CUSTOMER_PAID_THRU", ResetDT.TVAmort.Rows[i].Field<DateTime>("PaidThrough").Month.ToString().PadLeft(2, '0') + ResetDT.TVAmort.Rows[i].Field<DateTime>("PaidThrough").Year.ToString().Substring(2, 2));
                    CUSTHISTTableAdapter.Update(ResetDT.CUSTHIST.Rows[0]);
                }
            }
            // Moses Newman 01/12/2015 Make sure CUSTOMER_CONTRACT_STATUS Mathces last history row.
            if (ResetDT.CUSTOMER.Rows.Count > 0) 
                CUSTOMERTableAdapter.Update(ResetDT.CUSTOMER.Rows[0]);
            ResetDT.Clear();
            ResetDT.Dispose();
            ResetDT = null;
            CUSTOMERTableAdapter.Dispose();
            CUSTOMERTableAdapter = null;
            CUSTHISTTableAdapter.Dispose();
            CUSTHISTTableAdapter = null;
            TVAmortTableAdapter.Dispose();
            TVAmortTableAdapter = null;
        }

        public void worker_DorRecalcPTLF(object sender, DoWorkEventArgs e)
        {
            var result = MessageBox.Show("*** DO YOU REALLY WANT TO RECALCULATE PAID THROUGHS, LATE CHARGES, AND STATUSES? ***", "Recalculate Warning", MessageBoxButtons.YesNo);

            if (result == DialogResult.Yes)
            {
                IACDataSet dt = new IACDataSet();
                IACDataSetTableAdapters.CUSTOMERTableAdapter CUSTOMERTableAdapter = new IACDataSetTableAdapters.CUSTOMERTableAdapter();
                CUSTOMERTableAdapter.FillByAllPosted(dt.CUSTOMER);
                for (int itr = 0; itr < dt.CUSTOMER.Rows.Count; itr++)
                {
                    Program.gsProgMessage = "Recalculating Closed Partial Payments, Late Fees and Paid Throughs\n" +
                       "Customer number: " + (itr + 1).ToString() + " of " + dt.CUSTOMER.Rows.Count.ToString();
                    //if (dt.CUSTOMER.Rows[itr].Field<String>("CUSTOMER_NO") != "140422")
                       // continue;
                    worker.ReportProgress((Int32)((Double)(((Double)itr + 1.0000) / (Double)dt.CUSTOMER.Rows.Count) * 100.0000));
                    // Moses Newman 12/22/2014 Must update CUSTOMER RECORD IN RECALC MODE!
                   GetPartialPaymentandLateFeeBalance(ref worker, dt.CUSTOMER.Rows[itr].Field<String>("CUSTOMER_NO"), ref dt, itr, false, -1, true);
                   ResetHistoryPaidThroughandLateChargeBalance(ref worker, dt.CUSTOMER.Rows[itr].Field<String>("CUSTOMER_NO"));
                }
                Program.gsProgMessage = "";
                dt.Dispose();
                dt = null;
                CUSTOMERTableAdapter.Dispose();
                CUSTOMERTableAdapter = null;
            }
        }
    }
    // End of Closed End Payment Posting Routines
}


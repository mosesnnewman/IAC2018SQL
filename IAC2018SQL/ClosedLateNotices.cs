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
    public partial class frmNotices : DevExpress.XtraEditors.XtraForm
    {
        Int32 lnFormNo = 0, lnPTDiff = 0, lnPaidMonth = 0, lnPaidYear = 0;
        Boolean UpdateSW = false;
        // 12/13/2011 Moses Newman removed all references to lnTotLateCharge as we are no longer using an itterative add, using SQL Query instead 
        Decimal     lnLateCharge = 0, lnCustContractStat = 0, lnCustBuyout = 0,lnCustLCBal = 0,lnCustBalance = 0,lnDeltaCustBal = 0,
                        gnTotalLateCharge = 0,gnTotalInt =0, lnTempMasthistOLOAN = 0,lnDealerYTDOloanTemp = 0;
        // End of 12/13/2011 Mod

        IACDataSetTableAdapters.WS_NOTICE_DEALERTableAdapter WS_NOTICE_DEALERTableAdapter = new IACDataSetTableAdapters.WS_NOTICE_DEALERTableAdapter();
        BindingSource WS_NOTICE_DEALERBindingSource = new BindingSource();

        QueryProgress lfrm;

        BackgroundWorker worker;

        String lsProgMessage = "";

        public frmNotices()
        {
            InitializeComponent();
        }

        private void frmNotices_Load(object sender, EventArgs e)
        {
            // Moses Newman 01/05/2022 Intelligently determine the desired rundate even if running a few days late.
            DateTime tmpDate = DateTime.Now.Date.AddDays(-15);
            switch (tmpDate.Day)
            {
                case 5:
                case 6:
                case 7: 
                case 8:
                case 9:
                    tmpDate = DateTime.Parse(tmpDate.Year.ToString() + "-" + tmpDate.Month.ToString() + "-5"); 
                    break;
                case 10:
                case 11:
                case 12:
                case 13:
                case 14:
                    tmpDate = DateTime.Parse(tmpDate.Year.ToString() + "-" + tmpDate.Month.ToString() + "-10");
                    break;
                case 15:
                case 16:
                case 17:
                case 18:
                case 19:
                    tmpDate = DateTime.Parse(tmpDate.Year.ToString() + "-" + tmpDate.Month.ToString() + "-15");
                    break;
                case 20:
                case 21:
                case 22:
                case 23:
                case 24:
                    tmpDate = DateTime.Parse(tmpDate.Year.ToString() + "-" + tmpDate.Month.ToString() + "-20");
                    break;
                case 25:
                case 26:
                case 27:
                    tmpDate = DateTime.Parse(tmpDate.Year.ToString() + "-" + tmpDate.Month.ToString() + "-25");
                    break;
                case 30:
                case 28:
                case 29:
                case 1:
                case 2:
                case 3:
                case 4:
                    tmpDate = DateTime.Parse(tmpDate.Year.ToString() + "-" + tmpDate.Month.ToString() + "-30");
                    break;
            }
            NoticeDatenullableDateTimePicker.EditValue = tmpDate;  // Moses Newman 11/30/2021 Subtract 15 for run date default!
            PerformAutoScale();
        }

        private void PostLateNotices()
        {
            IACDataSetTableAdapters.SystemTableAdapter SystemTableAdapter = new IACDataSetTableAdapters.SystemTableAdapter();

            int lnProgress = 0,lnTotalSteps = 0;
            // Moses Newman 03/25/2014 Removed SQL pass through and called new stored procedure
            customerTableAdapter.FillByLateNotices(NoticeiacDataSet.CUSTOMER);

            if (NoticeiacDataSet.CUSTOMER.Rows.Count == 0)
            {
                MessageBox.Show("There are no customers that qualify for notices!");
                return;
            }
            nOTICETableAdapter.DeleteAll();    // Delete all previously created notices!
            WS_NOTICE_DEALERBindingSource.DataSource = NoticeiacDataSet.WS_NOTICE_DEALER;

            SystemTableAdapter.Fill(NoticeiacDataSet.System,1);

            if (NoticeiacDataSet.System.Rows.Count == 0)
            {
                SystemTableAdapter.Insert((DateTime)NoticeDatenullableDateTimePicker.EditValue, Convert.ToDateTime("01/01/1900"), Convert.ToDateTime("12/11/2013"));
            }
            else
                SystemTableAdapter.Update((DateTime)NoticeDatenullableDateTimePicker.EditValue, NoticeiacDataSet.System.Rows[0].Field<DateTime>("OpenNoticeRunDate"), NoticeiacDataSet.System.Rows[0].Field<DateTime>("LastUpdateDate"),1);

            SystemTableAdapter.Connection.Close();
            SystemTableAdapter.Dispose();

            lnTotalSteps = NoticeiacDataSet.CUSTOMER.Rows.Count + 2;
            for (int i = 0; i < NoticeiacDataSet.CUSTOMER.Rows.Count; i++)
            {
                TopOfJob(i);
                lnProgress = (Int32)(Math.Round(((Double)i / (Double)lnTotalSteps), 2) * 100);
                worker.ReportProgress(lnProgress);
            }
            ActDealerPost();
            worker.ReportProgress(88); 
            UpdateMaster();
            worker.ReportProgress(98);
            CreateMastHist();
            UpdateDailyInterest(); // Moses Newman 11/25/2020 Add interest post
            worker.ReportProgress(100);
            // Moses Newman 06/26/2015 CreateNoticeLetters
            MailMergeComponents CreateNoticeLetters = new MailMergeComponents();

            CreateNoticeLetters.CreateNotices(0, true, ref worker, ref lsProgMessage);
            CreateNoticeLetters.CreateNotices(1,true, ref worker, ref lsProgMessage);
            // Moses Newman 08/21/2018 change second parameter of Notice 2 and 3 to true so that attachments are now made for 02 and 03.
            CreateNoticeLetters.CreateNotices(2, true, ref worker, ref lsProgMessage);
            CreateNoticeLetters.CreateNotices(3, true, ref worker, ref lsProgMessage);
            CreateNoticeLetters.CreateNotices(4, true, ref worker, ref lsProgMessage);
            CreateNoticeLetters.CreateNotices(5, true, ref worker, ref lsProgMessage);
            CreateNoticeLetters.CreateNotices(6,true, ref worker, ref lsProgMessage);
            CreateNoticeLetters.CreateNotices(9,true, ref worker, ref lsProgMessage);
            CreateNoticeLetters = null;
        }

        private void TopOfJob(Int32 CustomerPos)
        {
            IACDataSetTableAdapters.LateRatesSelectTableAdapter LateRatesSelectTableAdapter = new IACDataSetTableAdapters.LateRatesSelectTableAdapter();
            Decimal lnAmountDifference = 0;
            Int32 lnActDateDiff = 0, lnFormDay = 0, lnMassDateDiff = 0, lnMassFormNo = 0, // Moses Newman 11/14/2021 Add Mass Date Diff
                  lnMassDueDay = 0;
            // Initialize for each record
            lnFormNo = 0;
            lnLateCharge = 0;
            lnCustLCBal = 0;
            lnCustBalance = 0;
            lnCustContractStat = 0;

            // Moses Newman 12/09/2018 Add test for OverrideLateCharge flag.
            if (NoticeiacDataSet.CUSTOMER.Rows[CustomerPos].Field<String>("CUSTOMER_ACT_STAT") == "I" ||
                NoticeiacDataSet.CUSTOMER.Rows[CustomerPos].Field<String>("CUSTOMER_CREDIT_STATUS") == "Y" || NoticeiacDataSet.CUSTOMER.Rows[CustomerPos].Field<Boolean>("OverrideLateCharge") == true)
                return;

            lnAmountDifference = NoticeiacDataSet.CUSTOMER.Rows[CustomerPos].Field<Decimal>("CUSTOMER_BALANCE") - 10;
            if (NoticeiacDataSet.CUSTOMER.Rows[CustomerPos].Field<Decimal>("CUSTOMER_REGULAR_AMOUNT") > lnAmountDifference)
                return;

            DateTime ldNewPaidThru, ldFormDate = (DateTime)NoticeDatenullableDateTimePicker.EditValue,
                     ldFebEndThisYear = Convert.ToDateTime("03/01/" + DateTime.Now.Date.Year.ToString().Substring(2, 2)).AddDays(-1); ;
            // Moses Newman 12/16/2014 proper C# way to do antiquated date add above!!! 
            // Moses Newman 04/16/2018 call Program.NextDueDate instead of hardcode!
            ldNewPaidThru = Program.NextDueDate(CustomerPos, NoticeiacDataSet);
            lnPaidMonth = ldNewPaidThru.Month;
            lnPaidYear = Convert.ToInt32(ldNewPaidThru.Year.ToString().Substring(2, 2));
            lnFormDay = ldFormDate.Day;
            // Moses Newman 04/26/2012 make form date actual DUE Date if 2/28 or 2/29(Leap Year)
            if (ldFormDate.Month == 2 && ldFormDate.Day > 27)
            {
                ldFormDate = ldFebEndThisYear;
                lnFormDay = 30;
            }

            TimeSpan ltActDateDiff,ltMassDateDiff; // Moses Newman 11/14/2021 Create Mass Date Diff
            ldFormDate = (DateTime)NoticeDatenullableDateTimePicker.EditValue;
            ltActDateDiff = ldFormDate - ldNewPaidThru;
            lnActDateDiff = (Int32)(ltActDateDiff.TotalDays);
            // Moses Newman 01/05/2022 Now we base mass off the month in advance delinquency report
            ltMassDateDiff = DateTime.Now.Date.AddMonths(1) - ldNewPaidThru;   // Moses Newman 11/14/2021 Create Mass Date Diff 
            lnMassDateDiff = (Int32)(ltMassDateDiff.TotalDays); // Moses Newman 11/14/2021 Create Mass Date Diff 
            // Moses Newman 01/05/2022 Mass 2 and 4 due date schedule
            switch(lnFormDay)
            {
                case 5:
                    lnMassDueDay = 10;
                    break;
                case 10:
                    lnMassDueDay = 15;
                    break;
                case 15:
                    lnMassDueDay = 20;
                    break;
                case 20:
                    lnMassDueDay = 25;
                    break;
                case 25:
                    lnMassDueDay = 30;
                    break;
                case 30:
                    lnMassDueDay = 5;
                    break;
            }
            // Moses Newman 04/04/2018 if February and NOT 1/30/YYYY due date and date difference is not zero must add the difference between 30 and 28 or 29 in a leap year!
            // Moses Newman 03/21/2019 Modified to add extra 2 days (or 1 if leap year) when the due date is is February of this year but the Month of the run date is >2.
            if ((ldFormDate.Day > 25 && ldFormDate.Day != 30 && lnActDateDiff != 0) || (ldNewPaidThru.Month <= 2 && ldFormDate.Month > 2 && ldFormDate.Year == ldNewPaidThru.Year))
                lnActDateDiff += 30 - ldFebEndThisYear.Day;
            /*// Moses Newman 03/25/2014 If the date entered into the from is February 27,28, or 29 and CUSTOMER_DAY_DUE = 30 the lnActDateDiff must equal 30 so form 6 prints!
            if (lnActDateDiff >= 27 && lnFormDay == 30)
                lnActDateDiff = 30; */    
            if (lnActDateDiff == 0)
                if (!((ldFormDate.Year == ldNewPaidThru.Year) && (ldFormDate.Month == ldNewPaidThru.Month)))
                    return;

            if (((ldFormDate.Month < ldNewPaidThru.Month) && (ldFormDate.Year == ldNewPaidThru.Year))||
                (ldFormDate.Year < ldNewPaidThru.Year))
                return;

            // Moses Newman 04/04/2018 This code was skipping people with January paid through dates if late fees are run for the 2/28 or 2/29 in a leap year
            // We dont want them skipped!
            /*if ((ldFormDate.Month == ldNewPaidThru.Month) && (ldFormDate.Year == ldNewPaidThru.Year))
                // Moses Newman 03/19/2012 Fixed FormDate of February 28 & 29
                if (ldFormDate.Month == 2 && lnFormDay == 30)
                    return;*/

            TestLCDate(lnActDateDiff);
            // Moses Newman 11/14/2021 Handle Mass Form 2 generating 10 days earlier
            // Moses Newman 11/17/2021 For two cycles we use old 2 calculation as well!
            // Moses Newman 11/30/2021 Only new calc from now on for Mass!
            if (NoticeiacDataSet.CUSTOMER.Rows[CustomerPos].Field<String>("CUSTOMER_STATE") == "MA")
            {
                Int32 lnAge = lnMassDateDiff / 30;
                // Moses Newman 01/4/2022 Mass 2 and 4 now = lnMassDateDiff / 30 = 1 then form 2 if = 2 then form 4
                switch(lnAge)
                {
                    case 1:
                        if(NoticeiacDataSet.CUSTOMER.Rows[CustomerPos].Field<Int32>("CUSTOMER_DAY_DUE") == lnMassDueDay)
                            lnFormNo = 2;
                        break;
                    case 2:
                        if (NoticeiacDataSet.CUSTOMER.Rows[CustomerPos].Field<Int32>("CUSTOMER_DAY_DUE") == lnMassDueDay)
                        {
                            lnMassFormNo = 4;
                            lnFormNo = 4;
                        }
                        break;
                }
                //lnMassFormNo = (lnMassDateDiff / 5) + 1;
            }

            // Moses Newman 06/25/2014 make sure no of payments made, and remaining payments are not null!
            if (NoticeiacDataSet.CUSTOMER.Rows[CustomerPos].Field<Nullable<Int32>>("CUSTOMER_PAY_REM_2") == null)
                NoticeiacDataSet.CUSTOMER.Rows[CustomerPos].SetField<Int32>("CUSTOMER_PAY_REM_2", 0);
            if (NoticeiacDataSet.CUSTOMER.Rows[CustomerPos].Field<Nullable<Int32>>("CUSTOMER_NO_OF_PAYMENTS_MADE") == null)
                NoticeiacDataSet.CUSTOMER.Rows[CustomerPos].SetField<Int32>("CUSTOMER_NO_OF_PAYMENTS_MADE", 0);
            if (NoticeiacDataSet.CUSTOMER.Rows[CustomerPos].Field<Int32>("CUSTOMER_TERM") == NoticeiacDataSet.CUSTOMER.Rows[CustomerPos].Field<Int32>("CUSTOMER_PAY_REM_2") &&
                NoticeiacDataSet.CUSTOMER.Rows[CustomerPos].Field<Decimal>("CUSTOMER_LATE_CHARGE_BAL") == 0)
                // Moses Newman 02/15/2019 use normal Form if they already got a First Payment Default notice!
                lnFormNo = 0;
            else
            {
                // If notice is 4 or 5 already do not create notice!
                if ((lnFormNo == 4 && lnMassFormNo != 4) || lnFormNo == 5)
                    return;
                // Moses Newman 02/26/2019 Handle new Notice 04 and 05
                // Moses Newman 03/25/2019 Fix issue with notices becoming 7 or 8 and getting late charges!
                // Moses Newman 11/17/2021 For two cycles generate form 4 using old and new logic
                // Moses Newman 11/30/2021 Only new calc from now on for Mass!
                /*if (NoticeiacDataSet.CUSTOMER.Rows[CustomerPos].Field<String>("CUSTOMER_STATE") == "MA")
                    if (lnMassDateDiff < 35 || lnMassDateDiff > 39)
                        lnMassDateDiff = lnActDateDiff; */
                if (lnFormDay != NoticeiacDataSet.CUSTOMER.Rows[CustomerPos].Field<Int32>("CUSTOMER_DAY_DUE") &&
                                //((lnMassDateDiff >= 35 && lnMassDateDiff < 40 && NoticeiacDataSet.CUSTOMER.Rows[CustomerPos].Field<String>("CUSTOMER_STATE") == "MA") || (lnActDateDiff >= 40 && lnActDateDiff < 45 && NoticeiacDataSet.CUSTOMER.Rows[CustomerPos].Field<String>("CUSTOMER_STATE") != "MA")))
                                // Moses Newman 01/04/2022 Now we already know if MassFormNo == 4
                                (lnActDateDiff >= 40 && lnActDateDiff < 45 && NoticeiacDataSet.CUSTOMER.Rows[CustomerPos].Field<String>("CUSTOMER_STATE") != "MA"))
                // Moses Newman 11/14/2021 Handle Mass Form 4 generating 10 days earlier
                    switch (lnActDateDiff)
                    {
                        case 40:
                        case 41:
                        case 42:
                        case 43:
                        case 44:
                            lnFormNo = 5;
                            break;
                    }
                if (lnFormNo > 12)
                    lnFormNo = 9;
                else
                    if (lnFormNo > 5)
                        lnFormNo = 6;
            }
            Int32 lnACTFirstDiff = CheckFirstPayment(CustomerPos, ldFormDate);
            // Moses Newman lnFormNo is always initially 0 so if it is 0 after TestLCDate and the lnActDateDiff is < 0 don't produce the notice!
            if (lnFormNo == 0 && lnActDateDiff < 0)
                return;
            if (lnACTFirstDiff < 0)
                return;

            lnLateCharge =0;
            lnDeltaCustBal = 0;
            if (lnFormNo > 1 && lnFormNo < 6) //|| ((lnFormNo == 0 || lnFormNo == 6 || lnFormNo == 9) && lnFormDay != NoticeiacDataSet.CUSTOMER.Rows[CustomerPos].Field<Int32>("CUSTOMER_DAY_DUE"))
                                              // Moses Newman 02/10/2019 ALWAYS create ALL forms even if it's not the customers due date! 
            {
                CreateForm(CustomerPos, ldNewPaidThru);
                return;
            }

            if ((lnFormNo == 0 || lnFormNo == 6 || lnFormNo == 9) && lnFormDay != NoticeiacDataSet.CUSTOMER.Rows[CustomerPos].Field<Int32>("CUSTOMER_DAY_DUE"))
                return;
            // Moses Newman 04/24/2018 No Late Charges for customers with a partial payment that is less than $1 short of a full payment!
            // Moses Newman 07/12/2018 Added () around lnFormNo == 0 || lnFormNo == 1 so lnFormNo == 0 does not get skipped!
            if ((lnFormNo == 0 || lnFormNo == 1) &&
               (NoticeiacDataSet.CUSTOMER.Rows[CustomerPos].Field<Decimal>("CUSTOMER_REGULAR_AMOUNT") -
                NoticeiacDataSet.CUSTOMER.Rows[CustomerPos].Field<Decimal>("PartialPayment")) < (Decimal)1)
                return;

            //Compute Late Charge
            // Moses Newman 01/15/2015 Don't mess with CONTRACT STATUS anymore because it is handled it GetPartialPaymentandLateFeeBalance
            //if (lnFormNo == 0)
                //if (ldFormDate.Month == ldNewPaidThru.Month)
                    //NoticeiacDataSet.CUSTOMER.Rows[CustomerPos].SetField<Decimal>("CUSTOMER_CONTRACT_STATUS", 0);
            //if (lnFormNo == 1)
                //NoticeiacDataSet.CUSTOMER.Rows[CustomerPos].SetField<Decimal>("CUSTOMER_CONTRACT_STATUS", NoticeiacDataSet.CUSTOMER.Rows[CustomerPos].Field<Decimal>("CUSTOMER_LATE_CHARGE_BAL") * -1);
            lnLateCharge = 0;

            // If this is the customer's first late payment this calculation will give the delinquent amount
            // Moses Newman 03/08/2015 Add LateRates table instead of hardcoded rates and cutoff to handle Exception States like MA!
            LateRatesSelectTableAdapter.Fill(NoticeiacDataSet.LateRatesSelect, NoticeiacDataSet.CUSTOMER.Rows[CustomerPos].Field<String>("CUSTOMER_STATE"));
            // Moses Newman 11/29/2014 Replace legacy fractional CUSTOMER_PARTIAL_PAYMENT with new field PartialPayment so no multiplication by CUSTOMER_REGULAR_AMOUNT
            if (NoticeiacDataSet.LateRatesSelect.Rows.Count > 0)
            {
                if (lnFormNo == 1 || lnFormNo == 0)
                    lnLateCharge = (NoticeiacDataSet.CUSTOMER.Rows[CustomerPos].Field<Decimal>("CUSTOMER_REGULAR_AMOUNT") - NoticeiacDataSet.CUSTOMER.Rows[CustomerPos].Field<Decimal>("PartialPayment")) *
                                    NoticeiacDataSet.LateRatesSelect.Rows[0].Field<Decimal>("Rate");
                else 
                    lnLateCharge = (NoticeiacDataSet.CUSTOMER.Rows[CustomerPos].Field<Decimal>("CUSTOMER_REGULAR_AMOUNT") *
                        NoticeiacDataSet.LateRatesSelect.Rows[0].Field<Decimal>("Rate"));

                lnLateCharge = Math.Round(lnLateCharge, 2);
                // Moses Newman 11/8/2017 If CuttOff field set to zero just use rate only, for VA
                if ( lnLateCharge > NoticeiacDataSet.LateRatesSelect.Rows[0].Field<Decimal>("CutOff") && NoticeiacDataSet.LateRatesSelect.Rows[0].Field<Decimal>("CutOff") != 0)
                    lnLateCharge = NoticeiacDataSet.LateRatesSelect.Rows[0].Field<Decimal>("CutOff");

            }
            else
            {
                if (lnFormNo == 1 || lnFormNo == 0)
                    lnLateCharge = (NoticeiacDataSet.CUSTOMER.Rows[CustomerPos].Field<Decimal>("CUSTOMER_REGULAR_AMOUNT") - NoticeiacDataSet.CUSTOMER.Rows[CustomerPos].Field<Decimal>("PartialPayment")) * (Decimal).05;
                else
                    lnLateCharge = (NoticeiacDataSet.CUSTOMER.Rows[CustomerPos].Field<Decimal>("CUSTOMER_REGULAR_AMOUNT") *
                        (Decimal).05);

                // Moses Newman 08/13/2013 Round late charge to 2 decimal places to prevent penny issue!
                lnLateCharge = Math.Round(lnLateCharge, 2);
                if (lnLateCharge > 10)
                    lnLateCharge = 10;
            }
            // 12/13/2011 Moses Newman removed all references to lnTotLateCharge as we are no longer using an itterative add using SQL Query instead 
            // End of 12/13/2011 Mod

            // Moses Newman 09/27/2013 Move from end so History Rec can be used in TimeValue to get Customer Balance and Buyout
            UpdateSW = true;
            // Moses Newman 09/27/2013 Added New PaidThru parameter
            CustomerHistory(CustomerPos, ldNewPaidThru);

            CreateForm(CustomerPos, ldNewPaidThru);   // Update last added NOTICE record do not insert
        }

        private void CustomerHistory(Int32 CustomerPos, DateTime tdNewPaidThru)
        {
            IACDataSetTableAdapters.CUSTHISTTableAdapter CUSTHISTTableAdapter = new IACDataSetTableAdapters.CUSTHISTTableAdapter();
            BindingSource CUSTHISTBindingSource = new BindingSource();

            Int32 lnSeq = 0;
            Object loCustHistSeq = null;
            Decimal lnOldBalance = 0;

            CUSTHISTBindingSource.DataSource = NoticeiacDataSet.CUSTHIST;
            lnOldBalance = NoticeiacDataSet.CUSTOMER.Rows[CustomerPos].Field<Decimal>("CUSTOMER_BALANCE");
            CUSTHISTBindingSource.AddNew();
            CUSTHISTBindingSource.EndEdit();
            NoticeiacDataSet.CUSTHIST.Rows[CUSTHISTBindingSource.Position].SetField<String>("CUSTHIST_NO", NoticeiacDataSet.CUSTOMER.Rows[CustomerPos].Field<String>("CUSTOMER_NO"));
            NoticeiacDataSet.CUSTHIST.Rows[CUSTHISTBindingSource.Position].SetField<String>("CUSTHIST_ADD_ON", NoticeiacDataSet.CUSTOMER.Rows[CustomerPos].Field<String>("CUSTOMER_ADD_ON"));
            NoticeiacDataSet.CUSTHIST.Rows[CUSTHISTBindingSource.Position].SetField<DateTime>("CUSTHIST_PAY_DATE", DateTime.Now.Date);
            // Moses Newman 03/15/2018 Added TransactionDate, Fee, FromIVR
            NoticeiacDataSet.CUSTHIST.Rows[CUSTHISTBindingSource.Position].SetField<DateTime>("TransactionDate", DateTime.Now.Date);
            NoticeiacDataSet.CUSTHIST.Rows[CUSTHISTBindingSource.Position].SetField<Decimal>("Fee", 0);
            NoticeiacDataSet.CUSTHIST.Rows[CUSTHISTBindingSource.Position].SetField<Boolean>("FromIVR", false);
            NoticeiacDataSet.CUSTHIST.Rows[CUSTHISTBindingSource.Position].SetField<String>("CUSTHIST_IAC_TYPE", NoticeiacDataSet.CUSTOMER.Rows[CustomerPos].Field<String>("CUSTOMER_IAC_TYPE"));
            NoticeiacDataSet.CUSTHIST.Rows[CUSTHISTBindingSource.Position].SetField<Decimal>("CUSTHIST_LATE_CHARGE", lnLateCharge);
            // Moses Newman 09/30/2103 accumulate total late charges for creating two seperate MASTHIST 211 records one with late charges and one with interest;
            gnTotalLateCharge += lnLateCharge;
            loCustHistSeq = CUSTHISTTableAdapter.SeqNoQuery(NoticeiacDataSet.CUSTOMER.Rows[CustomerPos].Field<String>("CUSTOMER_NO"), DateTime.Now.Date);
            if (loCustHistSeq != null)
                lnSeq = (int)loCustHistSeq + 1;
            else
                lnSeq = 1;
            NoticeiacDataSet.CUSTHIST.Rows[CUSTHISTBindingSource.Position].SetField<Int32>("CUSTHIST_DATE_SEQ", lnSeq);
            NoticeiacDataSet.CUSTHIST.Rows[CUSTHISTBindingSource.Position].SetField<Decimal>("CUSTHIST_PAYMENT_RCV", 0);
            NoticeiacDataSet.CUSTHIST.Rows[CUSTHISTBindingSource.Position].SetField<String>("CUSTHIST_ACT_STAT", NoticeiacDataSet.CUSTOMER.Rows[CustomerPos].Field<String>("CUSTOMER_ACT_STAT"));
            NoticeiacDataSet.CUSTHIST.Rows[CUSTHISTBindingSource.Position].SetField<Decimal>("CUSTHIST_BALANCE", NoticeiacDataSet.CUSTOMER.Rows[CustomerPos].Field<Decimal>("CUSTOMER_BALANCE"));
            NoticeiacDataSet.CUSTHIST.Rows[CUSTHISTBindingSource.Position].SetField<String>("CUSTHIST_PAID_THRU", NoticeiacDataSet.CUSTOMER.Rows[CustomerPos].Field<String>("CUSTOMER_PAID_THRU").TrimStart().TrimEnd().PadLeft(4, '0'));
            NoticeiacDataSet.CUSTHIST.Rows[CUSTHISTBindingSource.Position].SetField<Decimal>("CUSTHIST_PAID_DISCOUNT", Convert.ToDecimal(NoticeiacDataSet.CUSTOMER.Rows[CustomerPos].Field<Double>("CUSTOMER_PAID_DISCOUNT")));
            NoticeiacDataSet.CUSTHIST.Rows[CUSTHISTBindingSource.Position].SetField<Decimal>("CUSTHIST_PAID_INTEREST", NoticeiacDataSet.CUSTOMER.Rows[CustomerPos].Field<Decimal>("CUSTOMER_PAID_INTEREST"));
            NoticeiacDataSet.CUSTHIST.Rows[CUSTHISTBindingSource.Position].SetField<Decimal>("CUSTHIST_LATE_CHARGE_BAL", NoticeiacDataSet.CUSTOMER.Rows[CustomerPos].Field<Decimal>("CUSTOMER_LATE_CHARGE_BAL"));
            NoticeiacDataSet.CUSTHIST.Rows[CUSTHISTBindingSource.Position].SetField<String>("CUSTHIST_BUY_OUT", NoticeiacDataSet.CUSTOMER.Rows[CustomerPos].Field<String>("CUSTOMER_BUY_OUT"));
            NoticeiacDataSet.CUSTHIST.Rows[CUSTHISTBindingSource.Position].SetField<Decimal>("CUSTHIST_BUYOUT", NoticeiacDataSet.CUSTOMER.Rows[CustomerPos].Field<Decimal>("CUSTOMER_BUYOUT"));
            NoticeiacDataSet.CUSTHIST.Rows[CUSTHISTBindingSource.Position].SetField<String>("CUSTHIST_PAY_REM_1", "LATE");
            NoticeiacDataSet.CUSTHIST.Rows[CUSTHISTBindingSource.Position].SetField<Int32>("CUSTHIST_PAY_REM_2", NoticeiacDataSet.CUSTOMER.Rows[CustomerPos].Field<Int32>("CUSTOMER_PAY_REM_2"));
            NoticeiacDataSet.CUSTHIST.Rows[CUSTHISTBindingSource.Position].SetField<Decimal>("CUSTHIST_CONTRACT_STATUS", NoticeiacDataSet.CUSTOMER.Rows[CustomerPos].Field<Decimal>("CUSTOMER_CONTRACT_STATUS"));
            CUSTHISTBindingSource.EndEdit();
            CUSTHISTTableAdapter.Update(NoticeiacDataSet.CUSTHIST.Rows[CUSTHISTBindingSource.Position]);
            NoticeiacDataSet.CUSTHIST.AcceptChanges();
            // Moses Newman 09/27/2013 Get REAL CUSTOMER_BALANCE AND CUSTOMER_BUYOUT from TimeValue
            NoticeiacDataSet.CUSTOMER.Rows[CustomerPos].SetField<Decimal>("CUSTOMER_BALANCE", Program.TVSimpleGetBuyout(NoticeiacDataSet,
                           DateTime.Now.Date,
                           (Double)NoticeiacDataSet.CUSTOMER.Rows[CustomerPos].Field<Int32>("CUSTOMER_TERM"),
                           (Double)(NoticeiacDataSet.CUSTOMER.Rows[CustomerPos].Field<Decimal>("CUSTOMER_ANNUAL_PERCENTAGE_RATE") / 100),
                           (Double)NoticeiacDataSet.CUSTOMER.Rows[CustomerPos].Field<Decimal>("CUSTOMER_REGULAR_AMOUNT"),
                           NoticeiacDataSet.CUSTOMER.Rows[CustomerPos].Field<String>("CUSTOMER_NO"),
                           // Moses Newman 04/30/2017 Handle Normal Amortization and Simple Interest US Rule.
                           NoticeiacDataSet.CUSTOMER.Rows[CustomerPos].Field<String>("CUSTOMER_AMORTIZE_IND") == "S" ? true:false, true, false, false, -1, true));
            NoticeiacDataSet.CUSTOMER.Rows[CustomerPos].SetField<Decimal>("CUSTOMER_BUYOUT", Program.TVSimpleGetBuyout(NoticeiacDataSet,
                                            DateTime.Now.Date,
                                            (Double)NoticeiacDataSet.CUSTOMER.Rows[CustomerPos].Field<Int32>("CUSTOMER_TERM"),
                                            (Double)(NoticeiacDataSet.CUSTOMER.Rows[CustomerPos].Field<Decimal>("CUSTOMER_ANNUAL_PERCENTAGE_RATE") / 100),
                                            (Double)NoticeiacDataSet.CUSTOMER.Rows[CustomerPos].Field<Decimal>("CUSTOMER_REGULAR_AMOUNT"),
                                            NoticeiacDataSet.CUSTOMER.Rows[CustomerPos].Field<String>("CUSTOMER_NO"),
                                            // Moses Newman 04/30/2017 Handle Normal Amortization and Simple Interest US Rule.
                                            NoticeiacDataSet.CUSTOMER.Rows[CustomerPos].Field<String>("CUSTOMER_AMORTIZE_IND") == "S" ? true : false, true, true, false));

            lnCustBalance = NoticeiacDataSet.CUSTOMER.Rows[CustomerPos].Field<Decimal>("CUSTOMER_BALANCE");
            // Moses Newman 09/27/2013 Add DeltaCustBal for updating OSLoans in DEALER and MASTER OSLOANS
            lnDeltaCustBal = lnCustBalance - lnOldBalance;
            lnCustBuyout = NoticeiacDataSet.CUSTOMER.Rows[CustomerPos].Field<Decimal>("CUSTOMER_BUYOUT");

            NoticeiacDataSet.CUSTOMER.Rows[CustomerPos].SetField<Decimal>("CUSTOMER_LATE_CHARGE_BAL", Math.Round(NoticeiacDataSet.CUSTOMER.Rows[CustomerPos].Field<Decimal>("CUSTOMER_LATE_CHARGE_BAL") + lnLateCharge, 2));
            // Moses Newman 06/5/2014 Must write cust changes or New Contract Status will NOT have correct LATE_CHARGE_BAL!
            customerTableAdapter.Update(NoticeiacDataSet.CUSTOMER.Rows[CustomerPos]);
            lnCustLCBal = NoticeiacDataSet.CUSTOMER.Rows[CustomerPos].Field<Decimal>("CUSTOMER_LATE_CHARGE_BAL");

            MonthDifference(CustomerPos, tdNewPaidThru);
            // Moses Newman 01/15/2015 DO NOT MESS WITH CONTRACT_STATUS becuase GetPartialPaymentandLateFeeBalance will get it!

            // Moses Newman 09/27/2013 Fix fields changed from TimeValue
            NoticeiacDataSet.CUSTHIST.Rows[CUSTHISTBindingSource.Position].SetField<Decimal>("CUSTHIST_BALANCE", NoticeiacDataSet.CUSTOMER.Rows[CustomerPos].Field<Decimal>("CUSTOMER_BALANCE"));
            NoticeiacDataSet.CUSTHIST.Rows[CUSTHISTBindingSource.Position].SetField<Decimal>("CUSTHIST_PAID_INTEREST", NoticeiacDataSet.CUSTOMER.Rows[CustomerPos].Field<Decimal>("CUSTOMER_PAID_INTEREST"));
            NoticeiacDataSet.CUSTHIST.Rows[CUSTHISTBindingSource.Position].SetField<Decimal>("CUSTHIST_LATE_CHARGE_BAL", NoticeiacDataSet.CUSTOMER.Rows[CustomerPos].Field<Decimal>("CUSTOMER_LATE_CHARGE_BAL"));
            NoticeiacDataSet.CUSTHIST.Rows[CUSTHISTBindingSource.Position].SetField<Decimal>("CUSTHIST_BUYOUT", NoticeiacDataSet.CUSTOMER.Rows[CustomerPos].Field<Decimal>("CUSTOMER_BUYOUT"));
            NoticeiacDataSet.CUSTHIST.Rows[CUSTHISTBindingSource.Position].SetField<Decimal>("CUSTHIST_CONTRACT_STATUS", NoticeiacDataSet.CUSTOMER.Rows[CustomerPos].Field<Decimal>("CUSTOMER_CONTRACT_STATUS"));
            // Moses Newman 09/27/2013 Change in Customer Balance - Late Fee = Interest Calculated up to new Late Fee Transaction
            gnTotalInt += lnDeltaCustBal - lnLateCharge; // Moses Newman 09/30/2013 add accumulator for total interest for second MASTHIST 211 RECORD
            NoticeiacDataSet.CUSTHIST.Rows[CUSTHISTBindingSource.Position].SetField<Decimal>("CUSTHIST_FINANCE_CHARGE", lnDeltaCustBal - lnLateCharge);
            CUSTHISTBindingSource.EndEdit();
            CUSTHISTTableAdapter.Update(NoticeiacDataSet.CUSTHIST.Rows[CUSTHISTBindingSource.Position]);
            NoticeiacDataSet.CUSTHIST.AcceptChanges();
            // Moses Newman 12/15/2014 Must have actual late charge in payment stream to get proper Contract Status etc., so 
            // Recreate and remark history accordingly after post!
            ClosedPaymentPosting CP = new ClosedPaymentPosting();
            // Moses Newman 12/22/2014 must now pass the Post parameter to determine if the CUSTOMER record should be rewritten or not!
            CP.GetPartialPaymentandLateFeeBalance(ref worker, NoticeiacDataSet.CUSTOMER.Rows[CustomerPos].Field<String>("CUSTOMER_NO"), ref NoticeiacDataSet, CustomerPos,false,-1,true,true);
            //CP.ResetHistoryPaidThroughandLateChargeBalance(ref worker, NoticeiacDataSet.CUSTOMER.Rows[CustomerPos].Field<String>("CUSTOMER_NO"));
            CP.Dispose();
            CP = null;
            IACDataSet DS = new IACDataSet();
            customerTableAdapter.Fill(DS.CUSTOMER, NoticeiacDataSet.CUSTOMER.Rows[CustomerPos].Field<String>("CUSTOMER_NO"));
            if (DS.CUSTOMER.Rows.Count > 0)
            {
                NoticeiacDataSet.CUSTOMER.Rows[CustomerPos].SetField<Decimal>("CUSTOMER_CONTRACT_STATUS", DS.CUSTOMER.Rows[0].Field<Decimal>("CUSTOMER_CONTRACT_STATUS"));
                NoticeiacDataSet.CUSTOMER.Rows[CustomerPos].EndEdit();
                customerTableAdapter.Update(NoticeiacDataSet.CUSTOMER.Rows[CustomerPos]);
                lnCustContractStat = NoticeiacDataSet.CUSTOMER.Rows[CustomerPos].Field<Decimal>("CUSTOMER_CONTRACT_STATUS");
            }

            if (lnCustContractStat < (NoticeiacDataSet.CUSTOMER.Rows[CustomerPos].Field<Decimal>("CUSTOMER_BALANCE") * -1))
            {
                lnCustContractStat = (NoticeiacDataSet.CUSTOMER.Rows[CustomerPos].Field<Decimal>("CUSTOMER_BALANCE") * -1);
                NoticeiacDataSet.CUSTOMER.Rows[CustomerPos].SetField<Decimal>("CUSTOMER_CONTRACT_STATUS", lnCustContractStat);
            } 
            
            IACDataSetTableAdapters.TVAmortTableAdapter TVAmortTableAdapter = new IACDataSetTableAdapters.TVAmortTableAdapter();
            nOTICETableAdapter.Fill(NoticeiacDataSet.NOTICE, NoticeiacDataSet.CUSTOMER.Rows[CustomerPos].Field<String>("CUSTOMER_NO"));
            if (NoticeiacDataSet.NOTICE.Rows.Count > 0)
            {
                Object loIntToDate = null;
                loIntToDate = TVAmortTableAdapter.InterestSoFar(NoticeiacDataSet.CUSTOMER.Rows[CustomerPos].Field<String>("CUSTOMER_NO"));
                if (loIntToDate != null)
                {
                    NoticeiacDataSet.NOTICE.Rows[0].SetField<Decimal>("NOTICE_INT_TODATE", (Decimal)loIntToDate);
                }
                NoticeiacDataSet.NOTICE.Rows[0].SetField<Decimal>("NOTICE_CONTRACT_STATUS", NoticeiacDataSet.CUSTOMER.Rows[CustomerPos].Field<Decimal>("CUSTOMER_CONTRACT_STATUS"));
                NoticeiacDataSet.NOTICE.Rows[0].SetField<String>("NOTICE_PAID_THRU", NoticeiacDataSet.CUSTOMER.Rows[CustomerPos].Field<String>("CUSTOMER_PAID_THRU"));
                nOTICETableAdapter.Update(NoticeiacDataSet.NOTICE.Rows[0]);
                loIntToDate = null;
            }
            TVAmortTableAdapter.Dispose();
            TVAmortTableAdapter = null;
            DS.Dispose();
            DS = null;
        }

        private void ActDealerPost()
        {
            Int32 lnProgress = 0,lnTotalWork = 0;
            IACDataSetTableAdapters.DEALERTableAdapter DEALERTableAdapter = new IACDataSetTableAdapters.DEALERTableAdapter();
            BindingSource DEALERBindingSource = new BindingSource();

            DEALERBindingSource.DataSource = NoticeiacDataSet.DEALER;
            // Moses Newman 09/25/2013 Fill here because ActDealerPost is the first proc to use it, and all CUSTHIST and NOTICE records have been created
            // as that is necessary for WS_NOTICE_DEALERTableAdapter.Fill to work correctly.
            WS_NOTICE_DEALERTableAdapter.Fill(NoticeiacDataSet.WS_NOTICE_DEALER, DateTime.Now.Date);
            lnTotalWork = NoticeiacDataSet.WS_NOTICE_DEALER.Rows.Count;
            for (Int32 i = 0; i < NoticeiacDataSet.WS_NOTICE_DEALER.Rows.Count; i++)
            {
                DEALERTableAdapter.Fill(NoticeiacDataSet.DEALER, NoticeiacDataSet.WS_NOTICE_DEALER[i].Field<String>("KEY"));
                if (NoticeiacDataSet.DEALER.Rows.Count != 0)
                {
                    NoticeiacDataSet.DEALER.Rows[0].SetField<Decimal>("DEALER_CUR_RSV", 0);
                    NoticeiacDataSet.DEALER.Rows[0].SetField<Decimal>("DEALER_CUR_CONT", 0);
                    NoticeiacDataSet.DEALER.Rows[0].SetField<Decimal>("DEALER_CUR_OLOAN", 0);
                    NoticeiacDataSet.DEALER.Rows[0].SetField<Decimal>("DEALER_CUR_ADJ", 0);
                    NoticeiacDataSet.DEALER.Rows[0].SetField<Decimal>("DEALER_CUR_BAD", 0);
                    NoticeiacDataSet.DEALER.Rows[0].SetField<Decimal>("DEALER_CUR_LOSS", 0);
                    NoticeiacDataSet.DEALER.Rows[0].SetField<Decimal>("DEALER_CUR_AMORT_INT", 0);
                    NoticeiacDataSet.DEALER.Rows[0].SetField<Decimal>("DEALER_CUR_OLD_INT", 0);
                    NoticeiacDataSet.DEALER.Rows[0].SetField<Decimal>("DEALER_CUR_SIMPLE_INT", 0);
                    NoticeiacDataSet.DEALER.Rows[0].SetField<Decimal>("DEALER_CUR_AMORT_PDI", 0);
                    NoticeiacDataSet.DEALER.Rows[0].SetField<Decimal>("DEALER_CUR_OLD_PDI", 0);
                    NoticeiacDataSet.DEALER.Rows[0].SetField<Decimal>("DEALER_CUR_SIMPLE_PDI", 0);
                    if (NoticeiacDataSet.DEALER.Rows[0].Field<Nullable<Decimal>>("DEALER_YTD_SIMPLE_INT") == null)
                        NoticeiacDataSet.DEALER.Rows[0].SetField<Decimal>("DEALER_YTD_SIMPLE_INT", 0);
                    if (NoticeiacDataSet.DEALER.Rows[0].Field<Nullable<Decimal>>("DEALER_YTD_SIMPLE_PDI") == null)
                        NoticeiacDataSet.DEALER.Rows[0].SetField<Decimal>("DEALER_YTD_SIMPLE_PDI", 0);
                    NoticeiacDataSet.DEALER.Rows[0].SetField<DateTime>("DEALER_POST_DATE", DateTime.Now.Date);
                    // Moses Newman 09/30/2013 Make CUR_OLOAN reflect interest to date as that is the last of the TWO history records we are now adding
                    lnDealerYTDOloanTemp = NoticeiacDataSet.DEALER.Rows[0].Field<Decimal>("DEALER_YTD_OLOAN");
                    NoticeiacDataSet.DEALER.Rows[0].SetField<Decimal>("DEALER_CUR_OLOAN", NoticeiacDataSet.WS_NOTICE_DEALER.Rows[i].Field<Decimal>("InterestToDate"));
                    NoticeiacDataSet.DEALER.Rows[0].SetField<Decimal>("DEALER_YTD_OLOAN", NoticeiacDataSet.DEALER.Rows[0].Field<Decimal>("DEALER_YTD_OLOAN") + NoticeiacDataSet.WS_NOTICE_DEALER.Rows[i].Field<Decimal>("LateCharge") +
                                                                                                                                     NoticeiacDataSet.WS_NOTICE_DEALER.Rows[i].Field<Decimal>("InterestToDate"));
                    DEALERBindingSource.EndEdit();
                    DEALERTableAdapter.Update(NoticeiacDataSet.DEALER.Rows[0]);
                    NoticeiacDataSet.DEALER.AcceptChanges();
                    DealHistPost(i);
                    lnProgress = (Int32)Math.Round(((Double)i / (Double)lnTotalWork) * (Double)100,2);
                    worker.ReportProgress(lnProgress);
                }
            }
        }

        private void DealHistPost(Int32 i)
        {
            Int32 lnSeq = 0;
            Object loDealerHistSeq = null;

            IACDataSetTableAdapters.DEALHISTTableAdapter DEALHISTTableAdapter = new IACDataSetTableAdapters.DEALHISTTableAdapter();
            BindingSource DEALHISTBindingSource = new BindingSource();

            DEALHISTBindingSource.DataSource = NoticeiacDataSet.DEALHIST;

            DEALHISTBindingSource.AddNew();
            DEALHISTBindingSource.EndEdit();

            // Start of DEALHIST KEY Fields
            NoticeiacDataSet.DEALHIST.Rows[DEALHISTBindingSource.Position].SetField<String>("DEALHIST_ACC_NO", NoticeiacDataSet.DEALER.Rows[0].Field<String>("DEALER_ACC_NO"));
            NoticeiacDataSet.DEALHIST.Rows[DEALHISTBindingSource.Position].SetField<DateTime>("DEALHIST_POST_DATE", NoticeiacDataSet.DEALER.Rows[0].Field<DateTime>("DEALER_POST_DATE"));
            NoticeiacDataSet.DEALHIST.Rows[DEALHISTBindingSource.Position].SetField<DateTime>("DEALHIST_LAST_POST_DATE", NoticeiacDataSet.DEALER.Rows[0].Field<DateTime>("DEALER_POST_DATE"));
            loDealerHistSeq = DEALHISTTableAdapter.SeqNoQuery(NoticeiacDataSet.DEALER.Rows[0].Field<String>("DEALER_ACC_NO"), DateTime.Now.Date, NoticeiacDataSet.DEALER.Rows[0].Field<DateTime>("DEALER_POST_DATE").Date);
            if (loDealerHistSeq != null)
                lnSeq = (int)loDealerHistSeq + 1;
            else
                lnSeq = 0;
            NoticeiacDataSet.DEALHIST.Rows[DEALHISTBindingSource.Position].SetField<Int32>("DEALHIST_SEQ_NO", lnSeq);
            // End of DEALHIST KEY Fields
            NoticeiacDataSet.DEALHIST.Rows[DEALHISTBindingSource.Position].SetField<Decimal>("DEALHIST_CUR_RSV", NoticeiacDataSet.DEALER.Rows[0].Field<Decimal>("DEALER_CUR_RSV"));
            NoticeiacDataSet.DEALHIST.Rows[DEALHISTBindingSource.Position].SetField<Decimal>("DEALHIST_CUR_CONT", NoticeiacDataSet.DEALER.Rows[0].Field<Decimal>("DEALER_CUR_CONT"));
            NoticeiacDataSet.DEALHIST.Rows[DEALHISTBindingSource.Position].SetField<Decimal>("DEALHIST_CUR_OLOAN",  NoticeiacDataSet.WS_NOTICE_DEALER.Rows[i].Field<Decimal>("LateCharge"));
            NoticeiacDataSet.DEALHIST.Rows[DEALHISTBindingSource.Position].SetField<Decimal>("DEALHIST_CUR_ADJ", NoticeiacDataSet.DEALER.Rows[0].Field<Decimal>("DEALER_CUR_ADJ"));
            NoticeiacDataSet.DEALHIST.Rows[DEALHISTBindingSource.Position].SetField<Decimal>("DEALHIST_CUR_BAD", NoticeiacDataSet.DEALER.Rows[0].Field<Decimal>("DEALER_CUR_BAD"));
            NoticeiacDataSet.DEALHIST.Rows[DEALHISTBindingSource.Position].SetField<Decimal>("DEALHIST_CUR_LOSS", NoticeiacDataSet.DEALER.Rows[0].Field<Decimal>("DEALER_CUR_LOSS"));
            NoticeiacDataSet.DEALHIST.Rows[DEALHISTBindingSource.Position].SetField<Decimal>("DEALHIST_CUR_AMORT_INT", NoticeiacDataSet.DEALER.Rows[0].Field<Decimal>("DEALER_CUR_AMORT_INT"));
            NoticeiacDataSet.DEALHIST.Rows[DEALHISTBindingSource.Position].SetField<Decimal>("DEALHIST_CUR_OLD_INT", NoticeiacDataSet.DEALER.Rows[0].Field<Decimal>("DEALER_CUR_OLD_INT"));
            NoticeiacDataSet.DEALHIST.Rows[DEALHISTBindingSource.Position].SetField<Decimal>("DEALHIST_CUR_SIMPLE_INT", NoticeiacDataSet.DEALER.Rows[0].Field<Decimal>("DEALER_CUR_SIMPLE_INT"));
            NoticeiacDataSet.DEALHIST.Rows[DEALHISTBindingSource.Position].SetField<Decimal>("DEALHIST_CUR_AMORT_PDI", NoticeiacDataSet.DEALER.Rows[0].Field<Decimal>("DEALER_CUR_AMORT_PDI"));
            NoticeiacDataSet.DEALHIST.Rows[DEALHISTBindingSource.Position].SetField<Decimal>("DEALHIST_CUR_OLD_PDI", NoticeiacDataSet.DEALER.Rows[0].Field<Decimal>("DEALER_CUR_OLD_PDI"));
            NoticeiacDataSet.DEALHIST.Rows[DEALHISTBindingSource.Position].SetField<Decimal>("DEALHIST_CUR_SIMPLE_PDI", NoticeiacDataSet.DEALER.Rows[0].Field<Decimal>("DEALER_CUR_SIMPLE_PDI"));
            NoticeiacDataSet.DEALHIST.Rows[DEALHISTBindingSource.Position].SetField<Decimal>("DEALHIST_YTD_RSV", NoticeiacDataSet.DEALER.Rows[0].Field<Decimal>("DEALER_YTD_RSV"));
            NoticeiacDataSet.DEALHIST.Rows[DEALHISTBindingSource.Position].SetField<Decimal>("DEALHIST_YTD_CONT", NoticeiacDataSet.DEALER.Rows[0].Field<Decimal>("DEALER_YTD_CONT"));
            // Moses Newman 09/30/2013 Now add two DEALHIST RECORDS one for Late Fees and One For Interest!
            lnDealerYTDOloanTemp += NoticeiacDataSet.WS_NOTICE_DEALER.Rows[i].Field<Decimal>("LateCharge");
            NoticeiacDataSet.DEALHIST.Rows[DEALHISTBindingSource.Position].SetField<Decimal>("DEALHIST_YTD_OLOAN", lnDealerYTDOloanTemp);
            NoticeiacDataSet.DEALHIST.Rows[DEALHISTBindingSource.Position].SetField<Decimal>("DEALHIST_YTD_ADJ", NoticeiacDataSet.DEALER.Rows[0].Field<Decimal>("DEALER_YTD_ADJ"));
            NoticeiacDataSet.DEALHIST.Rows[DEALHISTBindingSource.Position].SetField<Decimal>("DEALHIST_YTD_BAD", NoticeiacDataSet.DEALER.Rows[0].Field<Decimal>("DEALER_YTD_BAD"));
            NoticeiacDataSet.DEALHIST.Rows[DEALHISTBindingSource.Position].SetField<Decimal>("DEALHIST_YTD_LOSS", NoticeiacDataSet.DEALER.Rows[0].Field<Decimal>("DEALER_YTD_LOSS"));
            NoticeiacDataSet.DEALHIST.Rows[DEALHISTBindingSource.Position].SetField<Decimal>("DEALHIST_YTD_AMORT_INT", NoticeiacDataSet.DEALER.Rows[0].Field<Decimal>("DEALER_YTD_AMORT_INT"));
            NoticeiacDataSet.DEALHIST.Rows[DEALHISTBindingSource.Position].SetField<Decimal>("DEALHIST_YTD_OLD_INT", NoticeiacDataSet.DEALER.Rows[0].Field<Decimal>("DEALER_YTD_OLD_INT"));
            NoticeiacDataSet.DEALHIST.Rows[DEALHISTBindingSource.Position].SetField<Decimal>("DEALHIST_YTD_SIMPLE_INT", NoticeiacDataSet.DEALER.Rows[0].Field<Decimal>("DEALER_YTD_SIMPLE_INT"));
            NoticeiacDataSet.DEALHIST.Rows[DEALHISTBindingSource.Position].SetField<Decimal>("DEALHIST_YTD_AMORT_PDI", NoticeiacDataSet.DEALER.Rows[0].Field<Decimal>("DEALER_YTD_AMORT_PDI"));
            NoticeiacDataSet.DEALHIST.Rows[DEALHISTBindingSource.Position].SetField<Decimal>("DEALHIST_YTD_OLD_PDI", NoticeiacDataSet.DEALER.Rows[0].Field<Decimal>("DEALER_YTD_OLD_PDI"));
            NoticeiacDataSet.DEALHIST.Rows[DEALHISTBindingSource.Position].SetField<Decimal>("DEALHIST_YTD_SIMPLE_PDI", NoticeiacDataSet.DEALER.Rows[0].Field<Decimal>("DEALER_YTD_SIMPLE_PDI"));

            NoticeiacDataSet.DEALHIST.Rows[DEALHISTBindingSource.Position].SetField<String>("DEALHIST_POST_CODE", "L");
            DEALHISTBindingSource.EndEdit();
            DEALHISTTableAdapter.Update(NoticeiacDataSet.DEALHIST.Rows[DEALHISTBindingSource.Position]);
            NoticeiacDataSet.DEALHIST.AcceptChanges();

            // Moses Newman 09/30/2013 Now add Interest to date record  for OLOAN update
            DEALHISTBindingSource.AddNew();
            DEALHISTBindingSource.EndEdit();

            // Start of DEALHIST KEY Fields
            NoticeiacDataSet.DEALHIST.Rows[DEALHISTBindingSource.Position].SetField<String>("DEALHIST_ACC_NO", NoticeiacDataSet.DEALER.Rows[0].Field<String>("DEALER_ACC_NO"));
            NoticeiacDataSet.DEALHIST.Rows[DEALHISTBindingSource.Position].SetField<DateTime>("DEALHIST_POST_DATE", NoticeiacDataSet.DEALER.Rows[0].Field<DateTime>("DEALER_POST_DATE"));
            NoticeiacDataSet.DEALHIST.Rows[DEALHISTBindingSource.Position].SetField<DateTime>("DEALHIST_LAST_POST_DATE", NoticeiacDataSet.DEALER.Rows[0].Field<DateTime>("DEALER_POST_DATE"));
            loDealerHistSeq = DEALHISTTableAdapter.SeqNoQuery(NoticeiacDataSet.DEALER.Rows[0].Field<String>("DEALER_ACC_NO"), DateTime.Now.Date, NoticeiacDataSet.DEALER.Rows[0].Field<DateTime>("DEALER_POST_DATE").Date);
            if (loDealerHistSeq != null)
                lnSeq = (int)loDealerHistSeq + 1;
            else
                lnSeq = 0;
            NoticeiacDataSet.DEALHIST.Rows[DEALHISTBindingSource.Position].SetField<Int32>("DEALHIST_SEQ_NO", lnSeq);
            // End of DEALHIST KEY Fields
            NoticeiacDataSet.DEALHIST.Rows[DEALHISTBindingSource.Position].SetField<Decimal>("DEALHIST_CUR_RSV", NoticeiacDataSet.DEALER.Rows[0].Field<Decimal>("DEALER_CUR_RSV"));
            NoticeiacDataSet.DEALHIST.Rows[DEALHISTBindingSource.Position].SetField<Decimal>("DEALHIST_CUR_CONT", NoticeiacDataSet.DEALER.Rows[0].Field<Decimal>("DEALER_CUR_CONT"));
            NoticeiacDataSet.DEALHIST.Rows[DEALHISTBindingSource.Position].SetField<Decimal>("DEALHIST_CUR_OLOAN", NoticeiacDataSet.WS_NOTICE_DEALER.Rows[i].Field<Decimal>("InterestToDate"));
            NoticeiacDataSet.DEALHIST.Rows[DEALHISTBindingSource.Position].SetField<Decimal>("DEALHIST_CUR_ADJ", NoticeiacDataSet.DEALER.Rows[0].Field<Decimal>("DEALER_CUR_ADJ"));
            NoticeiacDataSet.DEALHIST.Rows[DEALHISTBindingSource.Position].SetField<Decimal>("DEALHIST_CUR_BAD", NoticeiacDataSet.DEALER.Rows[0].Field<Decimal>("DEALER_CUR_BAD"));
            NoticeiacDataSet.DEALHIST.Rows[DEALHISTBindingSource.Position].SetField<Decimal>("DEALHIST_CUR_LOSS", NoticeiacDataSet.DEALER.Rows[0].Field<Decimal>("DEALER_CUR_LOSS"));
            NoticeiacDataSet.DEALHIST.Rows[DEALHISTBindingSource.Position].SetField<Decimal>("DEALHIST_CUR_AMORT_INT", NoticeiacDataSet.DEALER.Rows[0].Field<Decimal>("DEALER_CUR_AMORT_INT"));
            NoticeiacDataSet.DEALHIST.Rows[DEALHISTBindingSource.Position].SetField<Decimal>("DEALHIST_CUR_OLD_INT", NoticeiacDataSet.DEALER.Rows[0].Field<Decimal>("DEALER_CUR_OLD_INT"));
            NoticeiacDataSet.DEALHIST.Rows[DEALHISTBindingSource.Position].SetField<Decimal>("DEALHIST_CUR_SIMPLE_INT", NoticeiacDataSet.DEALER.Rows[0].Field<Decimal>("DEALER_CUR_SIMPLE_INT"));
            NoticeiacDataSet.DEALHIST.Rows[DEALHISTBindingSource.Position].SetField<Decimal>("DEALHIST_CUR_AMORT_PDI", NoticeiacDataSet.DEALER.Rows[0].Field<Decimal>("DEALER_CUR_AMORT_PDI"));
            NoticeiacDataSet.DEALHIST.Rows[DEALHISTBindingSource.Position].SetField<Decimal>("DEALHIST_CUR_OLD_PDI", NoticeiacDataSet.DEALER.Rows[0].Field<Decimal>("DEALER_CUR_OLD_PDI"));
            NoticeiacDataSet.DEALHIST.Rows[DEALHISTBindingSource.Position].SetField<Decimal>("DEALHIST_CUR_SIMPLE_PDI", NoticeiacDataSet.DEALER.Rows[0].Field<Decimal>("DEALER_CUR_SIMPLE_PDI"));
            NoticeiacDataSet.DEALHIST.Rows[DEALHISTBindingSource.Position].SetField<Decimal>("DEALHIST_YTD_RSV", NoticeiacDataSet.DEALER.Rows[0].Field<Decimal>("DEALER_YTD_RSV"));
            NoticeiacDataSet.DEALHIST.Rows[DEALHISTBindingSource.Position].SetField<Decimal>("DEALHIST_YTD_CONT", NoticeiacDataSet.DEALER.Rows[0].Field<Decimal>("DEALER_YTD_CONT"));
            // Moses Newman 09/30/2013 Now add two DEALHIST RECORDS one for Late Fees and One For Interest!
            lnDealerYTDOloanTemp += NoticeiacDataSet.WS_NOTICE_DEALER.Rows[i].Field<Decimal>("InterestToDate");
            NoticeiacDataSet.DEALHIST.Rows[DEALHISTBindingSource.Position].SetField<Decimal>("DEALHIST_YTD_OLOAN", lnDealerYTDOloanTemp);
            NoticeiacDataSet.DEALHIST.Rows[DEALHISTBindingSource.Position].SetField<Decimal>("DEALHIST_YTD_ADJ", NoticeiacDataSet.DEALER.Rows[0].Field<Decimal>("DEALER_YTD_ADJ"));
            NoticeiacDataSet.DEALHIST.Rows[DEALHISTBindingSource.Position].SetField<Decimal>("DEALHIST_YTD_BAD", NoticeiacDataSet.DEALER.Rows[0].Field<Decimal>("DEALER_YTD_BAD"));
            NoticeiacDataSet.DEALHIST.Rows[DEALHISTBindingSource.Position].SetField<Decimal>("DEALHIST_YTD_LOSS", NoticeiacDataSet.DEALER.Rows[0].Field<Decimal>("DEALER_YTD_LOSS"));
            NoticeiacDataSet.DEALHIST.Rows[DEALHISTBindingSource.Position].SetField<Decimal>("DEALHIST_YTD_AMORT_INT", NoticeiacDataSet.DEALER.Rows[0].Field<Decimal>("DEALER_YTD_AMORT_INT"));
            NoticeiacDataSet.DEALHIST.Rows[DEALHISTBindingSource.Position].SetField<Decimal>("DEALHIST_YTD_OLD_INT", NoticeiacDataSet.DEALER.Rows[0].Field<Decimal>("DEALER_YTD_OLD_INT"));
            NoticeiacDataSet.DEALHIST.Rows[DEALHISTBindingSource.Position].SetField<Decimal>("DEALHIST_YTD_SIMPLE_INT", NoticeiacDataSet.DEALER.Rows[0].Field<Decimal>("DEALER_YTD_SIMPLE_INT"));
            NoticeiacDataSet.DEALHIST.Rows[DEALHISTBindingSource.Position].SetField<Decimal>("DEALHIST_YTD_AMORT_PDI", NoticeiacDataSet.DEALER.Rows[0].Field<Decimal>("DEALER_YTD_AMORT_PDI"));
            NoticeiacDataSet.DEALHIST.Rows[DEALHISTBindingSource.Position].SetField<Decimal>("DEALHIST_YTD_OLD_PDI", NoticeiacDataSet.DEALER.Rows[0].Field<Decimal>("DEALER_YTD_OLD_PDI"));
            NoticeiacDataSet.DEALHIST.Rows[DEALHISTBindingSource.Position].SetField<Decimal>("DEALHIST_YTD_SIMPLE_PDI", NoticeiacDataSet.DEALER.Rows[0].Field<Decimal>("DEALER_YTD_SIMPLE_PDI"));

            NoticeiacDataSet.DEALHIST.Rows[DEALHISTBindingSource.Position].SetField<String>("DEALHIST_POST_CODE", "L");
            DEALHISTBindingSource.EndEdit();
            DEALHISTTableAdapter.Update(NoticeiacDataSet.DEALHIST.Rows[DEALHISTBindingSource.Position]);
            NoticeiacDataSet.DEALHIST.AcceptChanges();
        }

        private void TestLCDate(Int32 lnActDiff)
        {
            if (lnActDiff == 0)
            {
                lnFormNo = 1;
                return;
            }
            else
                if (lnActDiff < 1)
                    return;
            lnFormNo = (lnActDiff / 5) + 1;
            if (lnFormNo == 2)  // Moses Newman 11/14/2021 Only form 2 for mass, and uses different calculation later.
                lnFormNo = 0;
        }

        private Int32 CheckFirstPayment(Int32 CustomerPos,DateTime ldACTDate)
        {
            DateTime ldFirstPayment;
            DateTime? ldFirstPaymentTemp = NoticeiacDataSet.CUSTOMER.Rows[CustomerPos].Field<DateTime?>("CUSTOMER_INIT_DATE");

            if (ldFirstPaymentTemp == null)
                return 0;
            else
                ldFirstPayment = (DateTime)ldFirstPaymentTemp;
            Int32 lnNoYRS = 0, lnFirstPayMM = 0, lnFirstPayDD = 0, lnFirstPayYY = 0, lnActDateDiff = 0;

            lnFirstPayDD = ldFirstPayment.Day;
            lnFirstPayMM = ldFirstPayment.Month;
            lnFirstPayMM += NoticeiacDataSet.CUSTOMER.Rows[CustomerPos].Field<Int32>("CUSTOMER_TERM");

            lnFirstPayYY = ldFirstPayment.Year;

            if (lnFirstPayMM > 12)
            {
                lnNoYRS = lnFirstPayMM / 12;
                lnFirstPayYY += lnNoYRS;
                lnFirstPayMM -= (12 * lnNoYRS);
                if (lnFirstPayMM == 0)
                {
                    lnFirstPayYY -= 1;
                    lnFirstPayMM = 12;
                }
            }
            if (lnFirstPayDD == 29 && lnFirstPayMM == 2)
                lnFirstPayDD = 30;
            if (lnFirstPayMM == 2 && lnFirstPayDD == 30)
            {
                lnFirstPayMM = 3;
                lnFirstPayDD = 2;
            }
            ldFirstPayment = Convert.ToDateTime(lnFirstPayMM.ToString() + "/" + lnFirstPayDD.ToString() + "/" + lnFirstPayYY.ToString());
            TimeSpan ltActDateDiff;
            ltActDateDiff = ldFirstPayment - ldACTDate;
            lnActDateDiff = (Int32)(ltActDateDiff.TotalDays);

            return lnActDateDiff;
        }

        private void CreateForm(Int32 CustomerPos,DateTime ldNewDueDate)
        {
            String TestCust = NoticeiacDataSet.CUSTOMER.Rows[CustomerPos].Field<String>("CUSTOMER_NO");
            // Moses Newman 08/19/2018 Don't create Form02 if NOT Mass!
            if (lnFormNo == 2 && NoticeiacDataSet.CUSTOMER.Rows[CustomerPos].Field<String>("CUSTOMER_STATE") != "MA")
                return;
            // Moses Newman 08/21/2018 Don't create Form03 if not Mass!
            if (lnFormNo == 3 && NoticeiacDataSet.CUSTOMER.Rows[CustomerPos].Field<String>("CUSTOMER_STATE") == "MA")
                return;
            NoticebindingSource.AddNew();
            NoticebindingSource.EndEdit();
            // Moses Newman 06/25/2018 Add space between first and last name!
            NoticeiacDataSet.NOTICE.Rows[NoticebindingSource.Position].SetField<String>("NOTICE_NAME", NoticeiacDataSet.CUSTOMER.Rows[CustomerPos].Field<String>("CUSTOMER_FIRST_NAME").TrimEnd() + " " + NoticeiacDataSet.CUSTOMER.Rows[CustomerPos].Field<String>("CUSTOMER_LAST_NAME"));
            NoticeiacDataSet.NOTICE.Rows[NoticebindingSource.Position].SetField<String>("NOTICE_NO", NoticeiacDataSet.CUSTOMER.Rows[CustomerPos].Field<String>("CUSTOMER_NO"));
            NoticeiacDataSet.NOTICE.Rows[NoticebindingSource.Position].SetField<String>("NOTICE_ADD_ON", NoticeiacDataSet.CUSTOMER.Rows[CustomerPos].Field<String>("CUSTOMER_ADD_ON"));
            NoticeiacDataSet.NOTICE.Rows[NoticebindingSource.Position].SetField<String>("NOTICE_IAC_TYPE", NoticeiacDataSet.CUSTOMER.Rows[CustomerPos].Field<String>("CUSTOMER_IAC_TYPE"));
            NoticeiacDataSet.NOTICE.Rows[NoticebindingSource.Position].SetField<String>("NOTICE_DEALER", NoticeiacDataSet.CUSTOMER.Rows[CustomerPos].Field<String>("CUSTOMER_DEALER"));
            NoticeiacDataSet.NOTICE.Rows[NoticebindingSource.Position].SetField<Int32>("NOTICE_DAY_DUE", NoticeiacDataSet.CUSTOMER.Rows[CustomerPos].Field<Int32>("CUSTOMER_DAY_DUE"));
            NoticeiacDataSet.NOTICE.Rows[NoticebindingSource.Position].SetField<String>("NOTICE_STREET_1", NoticeiacDataSet.CUSTOMER.Rows[CustomerPos].Field<String>("CUSTOMER_STREET_1"));
            NoticeiacDataSet.NOTICE.Rows[NoticebindingSource.Position].SetField<String>("NOTICE_PHONE_NO", NoticeiacDataSet.CUSTOMER.Rows[CustomerPos].Field<String>("CUSTOMER_PHONE_NO"));
            NoticeiacDataSet.NOTICE.Rows[NoticebindingSource.Position].SetField<String>("NOTICE_WORK_PHONE", NoticeiacDataSet.CUSTOMER.Rows[CustomerPos].Field<String>("CUSTOMER_WORK_PHONE"));
            NoticeiacDataSet.NOTICE.Rows[NoticebindingSource.Position].SetField<String>("NOTICE_CITY", NoticeiacDataSet.CUSTOMER.Rows[CustomerPos].Field<String>("CUSTOMER_CITY"));
            NoticeiacDataSet.NOTICE.Rows[NoticebindingSource.Position].SetField<String>("NOTICE_STATE", NoticeiacDataSet.CUSTOMER.Rows[CustomerPos].Field<String>("CUSTOMER_STATE"));
            NoticeiacDataSet.NOTICE.Rows[NoticebindingSource.Position].SetField<String>("NOTICE_ZIP_CODE", NoticeiacDataSet.CUSTOMER.Rows[CustomerPos].Field<String>("CUSTOMER_ZIP_1") + ((NoticeiacDataSet.CUSTOMER.Rows[CustomerPos].Field<String>("CUSTOMER_ZIP_2").TrimEnd() == "") ? "":"-" + NoticeiacDataSet.CUSTOMER.Rows[CustomerPos].Field<String>("CUSTOMER_ZIP_2")));
            NoticeiacDataSet.NOTICE.Rows[NoticebindingSource.Position].SetField<Int32>("NOTICE_FORM_NO", lnFormNo);
            NoticeiacDataSet.NOTICE.Rows[NoticebindingSource.Position].SetField<DateTime>("NOTICE_LATE_DATE", ldNewDueDate);
            NoticeiacDataSet.NOTICE.Rows[NoticebindingSource.Position].SetField<Decimal>("NOTICE_CONTRACT_STATUS", NoticeiacDataSet.CUSTOMER.Rows[CustomerPos].Field<Decimal>("CUSTOMER_CONTRACT_STATUS"));
            NoticeiacDataSet.NOTICE.Rows[NoticebindingSource.Position].SetField<Decimal>("NOTICE_REGULAR_AMOUNT", NoticeiacDataSet.CUSTOMER.Rows[CustomerPos].Field<Decimal>("CUSTOMER_REGULAR_AMOUNT"));
            NoticeiacDataSet.NOTICE.Rows[NoticebindingSource.Position].SetField<Decimal>("NOTICE_BALANCE", NoticeiacDataSet.CUSTOMER.Rows[CustomerPos].Field<Decimal>("CUSTOMER_BALANCE"));
            NoticeiacDataSet.NOTICE.Rows[NoticebindingSource.Position].SetField<Decimal>("NOTICE_LATE_CHARGE", lnLateCharge);
            NoticeiacDataSet.NOTICE.Rows[NoticebindingSource.Position].SetField<Decimal>("NOTICE_LATE_CHARGE_BAL", NoticeiacDataSet.CUSTOMER.Rows[CustomerPos].Field<Decimal>("CUSTOMER_LATE_CHARGE_BAL"));
            NoticeiacDataSet.NOTICE.Rows[NoticebindingSource.Position].SetField<String>("NOTICE_WRONG_ADDRESS", NoticeiacDataSet.CUSTOMER.Rows[CustomerPos].Field<String>("CUSTOMER_WRONG_ADDRESS"));
            // Moses Newman 12/12/2018 Move CUSTOMER_CONTACT to NOTICE_CO_NAME instead of CUSTOMER_STREET_2
            // Moses Newman 09/20/2013 fix crash when legth of customer_street_2 < 25
            NoticeiacDataSet.NOTICE.Rows[NoticebindingSource.Position].SetField<String>("NOTICE_CO_NAME", NoticeiacDataSet.CUSTOMER.Rows[CustomerPos].Field<String>("CUSTOMER_CONTACT"));
            /*if (NoticeiacDataSet.CUSTOMER.Rows[CustomerPos].Field<String>("CUSTOMER_STREET_2").Length > 25)
                NoticeiacDataSet.NOTICE.Rows[NoticebindingSource.Position].SetField<String>("NOTICE_CO_NAME", NoticeiacDataSet.CUSTOMER.Rows[CustomerPos].Field<String>("CUSTOMER_STREET_2").Substring(0,25));
            else
                NoticeiacDataSet.NOTICE.Rows[NoticebindingSource.Position].SetField<String>("NOTICE_CO_NAME", NoticeiacDataSet.CUSTOMER.Rows[CustomerPos].Field<String>("CUSTOMER_STREET_2"));*/
            NoticeiacDataSet.NOTICE.Rows[NoticebindingSource.Position].SetField<Int32>("NOTICE_DISTRIBUTOR_NO", NoticeiacDataSet.CUSTOMER.Rows[CustomerPos].Field<Int32>("CUSTOMER_DISTRIBUTOR_NO"));
            NoticeiacDataSet.NOTICE.Rows[NoticebindingSource.Position].SetField<String>("NOTICE_PAID_THRU", NoticeiacDataSet.CUSTOMER.Rows[CustomerPos].Field<String>("CUSTOMER_PAID_THRU"));
            NoticeiacDataSet.NOTICE.Rows[NoticebindingSource.Position].SetField<String>("NOTICE_ALLOTMENT", NoticeiacDataSet.CUSTOMER.Rows[CustomerPos].Field<String>("CUSTOMER_ALLOTMENT"));
            NoticeiacDataSet.NOTICE.Rows[NoticebindingSource.Position].SetField<String>("NOTICE_AUTOPAY", NoticeiacDataSet.CUSTOMER.Rows[CustomerPos].Field<String>("CUSTOMER_AUTOPAY"));
            NoticeiacDataSet.NOTICE.Rows[NoticebindingSource.Position].SetField<String>("NOTICE_PO_NUMBER", NoticeiacDataSet.CUSTOMER.Rows[CustomerPos].Field<String>("CUSTOMER_PURCHASE_ORDER"));
            // Moses Newman 09/27/2013 Store Interest to Date in NOTICE Record for reporting
            NoticeiacDataSet.NOTICE.Rows[NoticebindingSource.Position].SetField<Decimal>("NOTICE_INT_TODATE", lnDeltaCustBal -  lnLateCharge);
            // Moses Newman 06/21/2018 Add PostDate
            NoticeiacDataSet.NOTICE.Rows[NoticebindingSource.Position].SetField<DateTime>("PostDate", DateTime.Now.Date);
            // Moses Newman 06/21/2018 AmountPastDue = Status - RegularAmount - LateCharge + PartialPayment
            NoticeiacDataSet.NOTICE.Rows[NoticebindingSource.Position].SetField<Decimal>("AmountPastDue", 
                (NoticeiacDataSet.CUSTOMER.Rows[CustomerPos].Field<Decimal>("CUSTOMER_CONTRACT_STATUS") *-1) - 
                NoticeiacDataSet.CUSTOMER.Rows[CustomerPos].Field<Decimal>("CUSTOMER_REGULAR_AMOUNT")-
                lnLateCharge + NoticeiacDataSet.CUSTOMER.Rows[CustomerPos].Field<Decimal>("PartialPayment"));
            // Moses Newman 11/17/2021 Handle proper Amount Past Due if 2 or 4 new calculation
            if (NoticeiacDataSet.CUSTOMER.Rows[CustomerPos].Field<String>("CUSTOMER_STATE") == "MA" &&
               (NoticeiacDataSet.NOTICE.Rows[NoticebindingSource.Position].Field<Decimal>("AmountPastDue") < 0 )) /*||
               (NoticeiacDataSet.NOTICE.Rows[NoticebindingSource.Position].Field<Decimal>("AmountPastDue") <
                NoticeiacDataSet.CUSTOMER.Rows[CustomerPos].Field<Decimal>("CUSTOMER_REGULAR_AMOUNT") && NoticeiacDataSet.CUSTOMER.Rows[CustomerPos].Field<Decimal>("CUSTOMER_BALANCE") >= NoticeiacDataSet.CUSTOMER.Rows[CustomerPos].Field<Decimal>("CUSTOMER_REGULAR_AMOUNT"))))*/
                //if (lnFormNo == 2 || lnFormNo == 4) Moses Newman 01/04/2022 Only add extra month for MASS Form4
                if (lnFormNo == 4)
                {
                    NoticeiacDataSet.NOTICE.Rows[NoticebindingSource.Position].SetField<Decimal>("AmountPastDue",
                        (NoticeiacDataSet.CUSTOMER.Rows[CustomerPos].Field<Decimal>("CUSTOMER_CONTRACT_STATUS") * -1) -
                        lnLateCharge + NoticeiacDataSet.CUSTOMER.Rows[CustomerPos].Field<Decimal>("PartialPayment"));
                    NoticeiacDataSet.NOTICE.Rows[NoticebindingSource.Position].SetField<Decimal>("NOTICE_CONTRACT_STATUS",
                        (NoticeiacDataSet.NOTICE.Rows[NoticebindingSource.Position].Field<Decimal>("NOTICE_REGULAR_AMOUNT") +
                        NoticeiacDataSet.NOTICE.Rows[NoticebindingSource.Position].Field<Decimal>("NOTICE_LATE_CHARGE") +
                        NoticeiacDataSet.NOTICE.Rows[NoticebindingSource.Position].Field<Decimal>("AmountPastDue") -
                        NoticeiacDataSet.CUSTOMER.Rows[CustomerPos].Field<Decimal>("PartialPayment")) * -1);
                }
            // Moses Newman 06/21/2018 Add PartialPayment
            NoticeiacDataSet.NOTICE.Rows[NoticebindingSource.Position].SetField<Decimal>("PartialPayment", 
                NoticeiacDataSet.CUSTOMER.Rows[CustomerPos].Field<Decimal>("PartialPayment"));
            NoticebindingSource.EndEdit();
            nOTICETableAdapter.Update(NoticeiacDataSet.NOTICE.Rows[NoticebindingSource.Position]);
            NoticeiacDataSet.NOTICE.AcceptChanges();
            if (UpdateSW)
            {
                UpdateSW = false;
                update_customer(CustomerPos);
            }
        }

        // Moses Newman 11/25/2020 Add interest post to DailyInterest Table
        private void UpdateDailyInterest()
        {
            DailyDataSetTableAdapters.DailyInterestTableAdapter DailyInterestTableAdapter = new DailyDataSetTableAdapters.DailyInterestTableAdapter();
            DailyDataSet DailySet = new DailyDataSet();
            DailyInterestTableAdapter.Insert(DateTime.Now.Date, "L", gnTotalInt, gnTotalInt, 0,
                new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.DaysInMonth(DateTime.Now.Year, DateTime.Now.Month)));

        }

        private void UpdateMaster()
        {
            IACDataSetTableAdapters.ACCOUNTTableAdapter ACCOUNTTableAdapter = new IACDataSetTableAdapters.ACCOUNTTableAdapter();
            IACDataSetTableAdapters.MASTERTableAdapter MASTERTableAdapter = new IACDataSetTableAdapters.MASTERTableAdapter();
            BindingSource MASTERBindingSource = new BindingSource();

            MASTERBindingSource.DataSource = NoticeiacDataSet.MASTER;

            Object loMasterKey = ACCOUNTTableAdapter.AccountNumber("OS_LOANS");
            String lsMasterKey = (String)loMasterKey;

            MASTERTableAdapter.Fill(NoticeiacDataSet.MASTER, lsMasterKey);

            if (NoticeiacDataSet.MASTER.Rows.Count != 0)
            {
                NoticeiacDataSet.MASTER.Rows[0].SetField<Decimal>("MASTER_CUR_RSV", 0);
                NoticeiacDataSet.MASTER.Rows[0].SetField<Decimal>("MASTER_CUR_CONT", 0);
                NoticeiacDataSet.MASTER.Rows[0].SetField<Decimal>("MASTER_CUR_OLOAN", 0);
                NoticeiacDataSet.MASTER.Rows[0].SetField<Decimal>("MASTER_CUR_ADJ", 0);
                NoticeiacDataSet.MASTER.Rows[0].SetField<Decimal>("MASTER_CUR_BAD", 0);
                NoticeiacDataSet.MASTER.Rows[0].SetField<Decimal>("MASTER_CUR_LOSS", 0);
                NoticeiacDataSet.MASTER.Rows[0].SetField<Decimal>("MASTER_CUR_INT", 0);
                NoticeiacDataSet.MASTER.Rows[0].SetField<Decimal>("MASTER_CUR_NOTES", 0);
                NoticeiacDataSet.MASTER.Rows[0].SetField<Decimal>("MASTER_AMORT_CUR_OLOAN", 0);
                NoticeiacDataSet.MASTER.Rows[0].SetField<Decimal>("MASTER_AMORT_CUR_NOTES", 0);
                NoticeiacDataSet.MASTER.Rows[0].SetField<Decimal>("MASTER_AMORT_CUR_INT", 0);

                NoticeiacDataSet.MASTER.Rows[0].SetField<DateTime>("MASTER_POST_DATE", DateTime.Now.Date);
                // Moses Newman 09/30/2013 make sure current MASTER OLOAN is the interest becase that will be the last of the two 211 MASTHIST records posted
                lnTempMasthistOLOAN = NoticeiacDataSet.MASTER.Rows[0].Field<Decimal>("MASTER_YTD_OLOAN");
                NoticeiacDataSet.MASTER.Rows[0].SetField<Decimal>("MASTER_CUR_OLOAN", gnTotalInt);
                NoticeiacDataSet.MASTER.Rows[0].SetField<Decimal>("MASTER_YTD_OLOAN", NoticeiacDataSet.MASTER.Rows[0].Field<Decimal>("MASTER_YTD_OLOAN") + gnTotalInt + gnTotalLateCharge);
                MASTERBindingSource.EndEdit();
                MASTERTableAdapter.Update(NoticeiacDataSet.MASTER.Rows[0]);
                NoticeiacDataSet.MASTER.AcceptChanges();
            }
        }

        private void CreateMastHist()
        {
            IACDataSetTableAdapters.ACCOUNTTableAdapter ACCOUNTTableAdapter = new IACDataSetTableAdapters.ACCOUNTTableAdapter();
            IACDataSetTableAdapters.MASTERTableAdapter MASTERTableAdapter = new IACDataSetTableAdapters.MASTERTableAdapter();
            IACDataSetTableAdapters.MASTHISTTableAdapter MASTHISTTableAdapter = new IACDataSetTableAdapters.MASTHISTTableAdapter();
            BindingSource MASTHISTBindingSource = new BindingSource();

            MASTHISTBindingSource.DataSource = NoticeiacDataSet.MASTHIST;

            Object loMasterKey = ACCOUNTTableAdapter.AccountNumber("OS_LOANS"),loMasterHistSeq = null;
            String lsMasterKey = (String)loMasterKey;
            Int32 lnSeq = 0;

            MASTERTableAdapter.Fill(NoticeiacDataSet.MASTER, lsMasterKey);
            if (NoticeiacDataSet.MASTER.Rows.Count != 0)
            {
                MASTHISTBindingSource.AddNew();
                MASTHISTBindingSource.EndEdit();
                NoticeiacDataSet.MASTHIST.Rows[MASTHISTBindingSource.Position].SetField<String>("MASTHIST_ACC_NO",NoticeiacDataSet.MASTER.Rows[0].Field<String>("MASTER_ACC_NO"));
                NoticeiacDataSet.MASTHIST.Rows[MASTHISTBindingSource.Position].SetField<DateTime>("MASTHIST_POST_DATE", NoticeiacDataSet.MASTER.Rows[0].Field<DateTime>("MASTER_POST_DATE"));
                loMasterHistSeq = MASTHISTTableAdapter.SeqNoQuery(NoticeiacDataSet.MASTER.Rows[0].Field<String>("MASTER_ACC_NO"), NoticeiacDataSet.MASTER.Rows[0].Field<DateTime>("MASTER_POST_DATE"));
                if (loMasterHistSeq != null)
                    lnSeq = (int)loMasterHistSeq + 1;
                else
                    lnSeq = 1;
                NoticeiacDataSet.MASTHIST.Rows[MASTHISTBindingSource.Position].SetField<Int32>("MASTHIST_SEQ_NO", lnSeq);
                NoticeiacDataSet.MASTHIST.Rows[MASTHISTBindingSource.Position].SetField<String>("MASTHIST_NAME", NoticeiacDataSet.MASTER.Rows[0].Field<String>("MASTER_NAME"));
                NoticeiacDataSet.MASTHIST.Rows[MASTHISTBindingSource.Position].SetField<Decimal>("MASTHIST_CUR_OLOAN", gnTotalLateCharge);
                lnTempMasthistOLOAN += gnTotalLateCharge;
                NoticeiacDataSet.MASTHIST.Rows[MASTHISTBindingSource.Position].SetField<Decimal>("MASTHIST_YTD_OLOAN", lnTempMasthistOLOAN);
                NoticeiacDataSet.MASTHIST.Rows[MASTHISTBindingSource.Position].SetField<Decimal>("MASTHIST_CUR_NOTES", 0);
                NoticeiacDataSet.MASTHIST.Rows[MASTHISTBindingSource.Position].SetField<Decimal>("MASTHIST_YTD_NOTES", NoticeiacDataSet.MASTER.Rows[0].Field<Decimal>("MASTER_YTD_NOTES"));
                NoticeiacDataSet.MASTHIST.Rows[MASTHISTBindingSource.Position].SetField<String>("MASTHIST_IAC_TYPE", "C");
                MASTHISTBindingSource.EndEdit();
                MASTHISTTableAdapter.Update(NoticeiacDataSet.MASTHIST.Rows[MASTHISTBindingSource.Position]);
                NoticeiacDataSet.MASTHIST.AcceptChanges();
                // Moses Newman 09/30/013  Split interest and late charges into two history records now
                MASTHISTBindingSource.AddNew();
                MASTHISTBindingSource.EndEdit();
                NoticeiacDataSet.MASTHIST.Rows[MASTHISTBindingSource.Position].SetField<String>("MASTHIST_ACC_NO", NoticeiacDataSet.MASTER.Rows[0].Field<String>("MASTER_ACC_NO"));
                NoticeiacDataSet.MASTHIST.Rows[MASTHISTBindingSource.Position].SetField<DateTime>("MASTHIST_POST_DATE", NoticeiacDataSet.MASTER.Rows[0].Field<DateTime>("MASTER_POST_DATE"));
                loMasterHistSeq = MASTHISTTableAdapter.SeqNoQuery(NoticeiacDataSet.MASTER.Rows[0].Field<String>("MASTER_ACC_NO"), NoticeiacDataSet.MASTER.Rows[0].Field<DateTime>("MASTER_POST_DATE"));
                if (loMasterHistSeq != null)
                    lnSeq = (int)loMasterHistSeq + 1;
                else
                    lnSeq = 1;
                NoticeiacDataSet.MASTHIST.Rows[MASTHISTBindingSource.Position].SetField<Int32>("MASTHIST_SEQ_NO", lnSeq);
                NoticeiacDataSet.MASTHIST.Rows[MASTHISTBindingSource.Position].SetField<String>("MASTHIST_NAME", NoticeiacDataSet.MASTER.Rows[0].Field<String>("MASTER_NAME"));
                lnTempMasthistOLOAN += gnTotalInt;
                NoticeiacDataSet.MASTHIST.Rows[MASTHISTBindingSource.Position].SetField<Decimal>("MASTHIST_CUR_OLOAN", gnTotalInt);
                NoticeiacDataSet.MASTHIST.Rows[MASTHISTBindingSource.Position].SetField<Decimal>("MASTHIST_YTD_OLOAN", lnTempMasthistOLOAN);
                NoticeiacDataSet.MASTHIST.Rows[MASTHISTBindingSource.Position].SetField<Decimal>("MASTHIST_CUR_NOTES", 0);
                NoticeiacDataSet.MASTHIST.Rows[MASTHISTBindingSource.Position].SetField<Decimal>("MASTHIST_YTD_NOTES", NoticeiacDataSet.MASTER.Rows[0].Field<Decimal>("MASTER_YTD_NOTES"));
                NoticeiacDataSet.MASTHIST.Rows[MASTHISTBindingSource.Position].SetField<String>("MASTHIST_IAC_TYPE", "C");
                MASTHISTBindingSource.EndEdit();
                MASTHISTTableAdapter.Update(NoticeiacDataSet.MASTHIST.Rows[MASTHISTBindingSource.Position]);
                NoticeiacDataSet.MASTHIST.AcceptChanges();
            }

        }

        private void update_customer(Int32 CustomerPos)
        {
            BindingSource CUSTOMERBindingSource = new BindingSource();

            CUSTOMERBindingSource.DataSource = NoticeiacDataSet.CUSTOMER;

            NoticeiacDataSet.CUSTOMER.Rows[CustomerPos].SetField<Decimal>("CUSTOMER_LATE_CHARGE", lnLateCharge);
            NoticeiacDataSet.CUSTOMER.Rows[CustomerPos].SetField<Decimal>("CUSTOMER_CONTRACT_STATUS", lnCustContractStat);
            NoticeiacDataSet.CUSTOMER.Rows[CustomerPos].SetField<Decimal>("CUSTOMER_BUYOUT", lnCustBuyout);
            NoticeiacDataSet.CUSTOMER.Rows[CustomerPos].SetField<Decimal>("CUSTOMER_LATE_CHARGE_BAL", lnCustLCBal);
            NoticeiacDataSet.CUSTOMER.Rows[CustomerPos].SetField<Decimal>("CUSTOMER_BALANCE", lnCustBalance);
            NoticeiacDataSet.CUSTOMER.Rows[CustomerPos].SetField<Int32>("CUSTOMER_FORM_NO", lnFormNo);

            if (NoticeiacDataSet.CUSTOMER.Rows[CustomerPos].Field<Decimal>("CUSTOMER_CONTRACT_STATUS") > NoticeiacDataSet.CUSTOMER.Rows[CustomerPos].Field<Decimal>("CUSTOMER_BALANCE"))
                NoticeiacDataSet.CUSTOMER.Rows[CustomerPos].SetField<Decimal>("CUSTOMER_CONTRACT_STATUS", NoticeiacDataSet.CUSTOMER.Rows[CustomerPos].Field<Decimal>("CUSTOMER_BALANCE") * -1);
            
            if (NoticeiacDataSet.CUSTOMER.Rows[CustomerPos].Field<Int32>("CUSTOMER_PAY_REM_2") < 3)
                NoticeiacDataSet.CUSTOMER.Rows[CustomerPos].SetField<Decimal>("CUSTOMER_BUYOUT", NoticeiacDataSet.CUSTOMER.Rows[CustomerPos].Field<Decimal>("CUSTOMER_BALANCE"));

            CUSTOMERBindingSource.EndEdit();
            customerTableAdapter.Update(NoticeiacDataSet.CUSTOMER.Rows[CustomerPos]);
            NoticeiacDataSet.CUSTOMER.AcceptChanges();
        }

        private void MonthDifference(Int32 CustomerPos,DateTime tdCustDate)
        {
            // Same year but current month
            if (tdCustDate.Year == DateTime.Now.Year && tdCustDate.Month > DateTime.Now.Month)
            {
                lnPTDiff = 0;
                return;
            }
            // Same year
            if (tdCustDate.Year == DateTime.Now.Year)
            {
                lnPTDiff = DateTime.Now.Month - tdCustDate.Month;
                if (NoticeiacDataSet.CUSTOMER.Rows[CustomerPos].Field<Int32>("CUSTOMER_DAY_DUE") > DateTime.Now.Day)
                    lnPTDiff += 1;
                return;
            }
            // Different year
            if (tdCustDate.Year != DateTime.Now.Year)
            {
                lnPTDiff = ((12 - tdCustDate.Month) + DateTime.Now.Month);
                if (tdCustDate.Day > DateTime.Now.Day)
                    lnPTDiff -= 1;
            }
        }

        private void NoticeDatenullableDateTimePicker_Validated(object sender, EventArgs e)
        {
            DateTime? ldCurrentDate = (DateTime?)NoticeDatenullableDateTimePicker.EditValue;
            if (NoticeDatenullableDateTimePicker.EditValue != null)
                if (ldCurrentDate.Value.Month == 2 && ldCurrentDate.Value.Day == 30)
                    NoticeDatenullableDateTimePicker.EditValue = Convert.ToDateTime("02/28" + ldCurrentDate.Value.Year.ToString());

        }

        private void worker_PostLateNotices(object sender, DoWorkEventArgs e)
        {
            PostLateNotices();
        }

        private void buttonPost_Click(object sender, EventArgs e)
        {
            MDIIAC2013 MDImain = (MDIIAC2013)MdiParent;
            lfrm = new QueryProgress();
            worker = new BackgroundWorker();
            worker.WorkerReportsProgress = true;
            worker.DoWork += new DoWorkEventHandler(worker_PostLateNotices);
            worker.RunWorkerCompleted += new RunWorkerCompletedEventHandler(worker_RunWorkerCompleted);
            worker.ProgressChanged += new ProgressChangedEventHandler(worker_ProgressChanged);
            worker.RunWorkerAsync();
            lsProgMessage = "Posting Closed Side Notices";
            lfrm.Text = "Closed Notice Posting";
            lfrm.lblProgress.Text = lsProgMessage;
            lfrm.ShowDialog();
        }


        private void buttonCancel_Click(object sender, EventArgs e)
        {
            customerTableAdapter.Connection.Close();
            customerTableAdapter.Dispose();
            nOTICETableAdapter.Connection.Close();
            nOTICETableAdapter.Dispose();
            NoticeiacDataSet.Dispose();
            Close();
        }

        void worker_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            lfrm.Close();
            customerTableAdapter.Connection.Close();
            customerTableAdapter.Dispose();
            nOTICETableAdapter.Connection.Close();
            nOTICETableAdapter.Dispose();
            NoticeiacDataSet.Dispose();
            Close();
        }

        void worker_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            lfrm.QueryprogressBar.EditValue = e.ProgressPercentage;
            lfrm.lblProgress.Text = lsProgMessage;
            lfrm.lblProgress.Refresh();
            lfrm.BringToFront();
        }

    }
}

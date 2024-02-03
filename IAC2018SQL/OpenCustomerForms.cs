using DevExpress.XtraEditors;
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
    public partial class frmOpenCustMaint : DevExpress.XtraEditors.XtraForm
    {
        private string lPaidThroughMM, lPaidThroughYY, lPaidThrough, lControl_Month, lControl_Year, lControlDate,
                lcExpYear1, lcExpYear2, lcExpYear3, lcExpYear4, lcExpYear5, lcExpYear6, lcExpYear7, lcExpYear8,
                lcExpYear9, lcExpYear10, _CustomerNo;
        private System.Data.SqlClient.SqlTransaction tableAdapTran = null;
        private System.Data.SqlClient.SqlConnection tableAdapConn = null;
        private bool lbAddFlag = false,lbEdit = false,lbILockedIt = false;
        private DataGridViewComboBoxEditingControl editingControl;
        private int lnSeq = 0;

        private IACDataSetTableAdapters.OPNRATETableAdapter OPNRATETableAdapter = new IACDataSetTableAdapters.OPNRATETableAdapter();

        private frmOpenCustomerLookup form2inst;

        public Boolean FromWarranty
        {
            get;
            set;
        }

        public String Dealer
        {
            get;
            set;
        }
        public String CustomerNumber
        {
            get
            {
                return _CustomerNo;
            }
            set
            {
                _CustomerNo = value;
                cUSTOMER_NOTextBox.Text = _CustomerNo;
                cUSTOMER_NOTextBox.Refresh();
                ActiveControl = cUSTOMER_FIRST_NAMETextBox;
            }
        }

        public String FirstName { get; set; }
        public String LastName { get; set; }
        public String CustomerSuffix { get; set; }
        public String Contact { get; set; }
        public String Address1 { get; set; }
        public String Address2 { get; set; }
        public String City { get; set; }
        public String State { get; set; }
        public String ZipCode { get; set; }
        public String ZipPlus4 { get; set; }
        public String HomePhone { get; set; }
        public String HomeExt { get; set; }
        public String WorkPhone { get; set; }
        public String WorkExt { get; set; }
        public String CellPhone { get; set; }
        public DateTime DOB { get; set; }
        public String SS1 { get; set; }
        public String SS2 { get; set; }
        public String SS3 { get; set; }
        public String Comment1 { get; set; }
        public String Comment2 { get; set; }
        public String CountryCode { get; set; }
        public String WrongAddress { get; set; }
        public String NoContact { get; set; }
        public String AutoPay { get; set; }
        public String AllotmentProg { get; set; }
        public String MilitaryService { get; set; }
        public String ProductCode { get; set; }
        public Int32 CreditScoreN { get; set; }
        public String CreditScoreA { get; set; }
        public Int32 DistributorNo { get; set; }
        public String CosignName { get; set; }
        public String CosHomePhone { get; set; }
        public String CosHomeExt { get; set; }
        public String CosCellPhone { get; set; }
        public String AltName1 { get; set; }
        public String AltRelation1 { get; set; }
        public String AltPhone1 { get; set; }
        public String AltExt1 { get; set; }
        public String AltName2 { get; set; }
        public String AltRelation2 { get; set; }
        public String AltPhone2 { get; set; }
        public String AltExt2 { get; set; }
        public String AltName3 { get; set; }
        public String AltRelation3 { get; set; }
        public String AltPhone3 { get; set; }
        public String AltExt3 { get; set; }
        public String AltName4 { get; set; }
        public String AltRelation4 { get; set; }
        public String AltPhone4 { get; set; }
        public String AltExt4 { get; set; }
        public String BankName { get; set; }
        public String BankCity { get; set; }
        public String BankState { get; set; }
        public String BankRoutingNo { get; set; }
        public String BankCheckDigit { get; set; }
        public String BankAccountNo { get; set; }
        public String BankAutoPay { get; set; }
        public String CreditCardNumber { get; set; }
        public String CreditCardName { get; set; }
        public String CreditCVV { get; set; }
        public String CreditExpMonth { get; set; }
        public String CreditExpYear { get; set; }
        public Int32 DayDue { get; set; }
        public String CreditStatus { get; set; }
        public String CreditBureau { get; set; }









        public frmOpenCustMaint()
        {
            InitializeComponent();
        }

        private void frmOpenCustMaint_Load(object sender, EventArgs e)
        {
            this.termsFrequencyTableAdapter.Fill(this.tsbDataSet.TermsFrequency);
            this.portfolioTypesTableAdapter.Fill(this.tsbDataSet.PortfolioTypes);
            this.interestTypesTableAdapter.Fill(this.tsbDataSet.InterestTypes);
            this.eCOACodesTableAdapter.Fill(this.tsbDataSet.ECOACodes);
            this.complianceConditionCodesTableAdapter.Fill(this.tsbDataSet.ComplianceConditionCodes);
            this.consumerIndicatorsTableAdapter.Fill(this.tsbDataSet.ConsumerIndicators);
            this.accountTypesTableAdapter.Fill(this.tsbDataSet.AccountTypes);
            this.paymentRatingsTableAdapter.Fill(this.tsbDataSet.PaymentRatings);
            this.accountStatusesTableAdapter.Fill(this.tsbDataSet.AccountStatuses);
            this.specialCommentCodesTableAdapter.Fill(this.iACDataSet.SpecialCommentCodes);
            StartupConfiguration();
            DataGridViewRow row = cOMMENTDataGridView.RowTemplate;
            row.Height = 45;
            row.DefaultCellStyle.BackColor = (row.Index % 2 == 0) ? Color.Bisque : Color.White;
            row.MinimumHeight = 20;
            PerformAutoScale();
        }

        private void StartupConfiguration()
        {
            if (!lbEdit)
            {
                letterTypeTableAdapter.Fill(iACDataSet.LetterType);
                letterNumberTableAdapter.Fill(iACDataSet.LetterNumber);
                comment_TypesTableAdapter.Fill(iACDataSet.Comment_Types);
                oPNDLRLISTBYNUMTableAdapter.Fill(iACDataSet.OPNDLRLISTBYNUM);
                oPNDEALRLISTTableAdapter.FillAll(iACDataSet.OPNDEALRLIST);
                monthNamesTableAdapter.Fill(iACDataSet.MonthNames);
            }
            cUSTOMER_NOTextBox.Text = (Program.gsKey != null) ? Program.gsKey : "";
            if (FromWarranty)
                Program.gsKey = this.CustomerNumber;
            if (Program.gsKey != null)
            {
                setRelatedData();
                if (iACDataSet.OPNCUST.Rows.Count == 0 && !FromWarranty)
                {
                    cUSTOMER_NOTextBox.Text = "";
                    cUSTOMER_DEALERcomboBox.Text = "";
                    DealerNamecomboBox.Text = "";
                    cUSTOMER_DEALERcomboBox.Text = "";
                }
            }
            else
            {
                cUSTOMER_NOTextBox.Text = "";
                cUSTOMER_PURCHASE_ORDERTextBox.Text = "";
                DealerNamecomboBox.Text = "";
                cUSTOMER_DEALERcomboBox.Text = "";
            }
            Program.gsKey = null;
            if (!lbEdit)
            {
                SetViewMode();
            }
            else
                if (iACDataSet.OPNCUST.Rows.Count > 0)
                {
                    SetEditMode();
                }

            ActiveControl = cUSTOMER_NOTextBox;
            cUSTOMER_NOTextBox.SelectAll();
            // Moses Newman 03/23/2012 return to same tab before edit mode!
            if (lbEdit)
                tabOpenCustomerMaintenance.SelectedIndex = Program.gnOpenCustomerTab;
        }

        private void SetViewMode()
        {
            Text = "Open Customer Maintenance (VIEW Mode)";
            // Customer Info
            cUSTOMER_NOTextBox.Enabled = true;
            cUSTOMER_PURCHASE_ORDERTextBox.Enabled = true;
            cUSTOMER_ACT_STATTextBox.Enabled = false;
            cUSTOMER_FIRST_NAMETextBox.Enabled = false;
            cUSTOMER_LAST_NAMETextBox.Enabled = false;
            cUSTOMER_SUFFIXTextBox.Enabled = false;
            cUSTOMER_CONTACTTextBox.Enabled = false;
            cUSTOMER_STREET_1TextBox.Enabled = false;
            cUSTOMER_STREET_2TextBox.Enabled = false;
            cUSTOMER_CITYTextBox.Enabled = false;
            cUSTOMER_STATETextBox.Enabled = false;
            cUSTOMER_ZIP_1TextBox.Enabled = false;
            cUSTOMER_ZIP_2TextBox.Enabled = false;
            cUSTOMER_PHONE_NOTextBox.Enabled = false;
            cUSTOMER_PHONE_EXTtextBox.Enabled = false;
            cUSTOMER_WORK_EXTtextBox.Enabled = false;
            cUSTOMER_WORK_PHONETextBox.Enabled = false;
            cUSTOMER_WORK_EXTtextBox.Enabled = false;
            cUSTOMER_CELL_PHONETextBox.Enabled = false;
            txtDOB.Enabled = false;
            cUSTOMER_SS_1TextBox.Enabled = false;
            cUSTOMER_SS_2TextBox.Enabled = false;
            cUSTOMER_SS_3TextBox.Enabled = false;
            cUSTOMER_DEALERcomboBox.Enabled = false;
            DealerNamecomboBox.Enabled = false;
            cUSTOMER_COMMENT_1TextBox.Enabled = false;
            cUSTOMER_COMMENT_2TextBox.Enabled = false;
            cUSTOMER_AUTOPAYTextBox.Enabled = false;
            cUSTOMER_CREDIT_SCORE_NTextBox.Enabled = false;
            cUSTOMER_CREDIT_SCORE_ATextBox.Enabled = false;
            cUSTOMER_ALLOTMENTTextBox.Enabled = false;
            cUSTOMER_DISTRIBUTOR_NOTextBox.Enabled = false;
            cUSTOMER_WRONG_ADDRESSTextBox.Enabled = false;
            cUSTOMER_NO_CONTACTTextBox.Enabled = false;
            cUSTOMER_COS_NAMETextBox.Enabled = false;
            cUSTOMER_COS_PHONETextBox.Enabled = false;
            comboBoxLetterNo.Enabled = true;
            comboBoxLetterType.Enabled = true;
            buttonLetter.Enabled = true;
            textBoxState1.Enabled = false;
            textBoxCountryCode.Enabled = false;
            textBoxMilitaryService.Enabled = false;
            textBoxProductCode.Enabled = false;

            // Customer Info 2
            comboBoxDayDue.Enabled = false;
            txtCollectionAgent.Enabled = false;
            txtRegularPay.Enabled = false;
            txtLoan.Enabled = false;
            txtFirstPayDate.Enabled = false;
            dateTimePickerContractDate.Enabled = false;
            txtPaymentDate.Enabled = false;
            txtPaidThrough.Enabled = false;
            textBoxLastFinCharge.Enabled = false;
            textBoxTotalFinance.Enabled = false;
            txtPaymentCode.Enabled = false;
            txtPaymentType.Enabled = false;
            txtLateCharge.Enabled = false;
            txtLateChargeBal.Enabled = false;
            txtLastPaymentMade.Enabled = false;
            txtCustomerBalance.Enabled = false;
            textBoxPaidInterest.Enabled = false;
            txtContractStatus.Enabled = false;
            textBoxInterestRate.Enabled = false;
            // Moses Newman 09/28/2020 Remove old TSB Crap
            //txtCreditBureau.Enabled = false;
            //txtTSBCommentCode.Enabled = false;
            txtCreditLimit.Enabled = false;
            textBoxControlDateMM.Enabled = false;
            textBoxControlDateYY.Enabled = false;
            textBoxCreditAvailable.Enabled = false;
            textBoxFinanceBucket1.Enabled = false;
            textBoxFinanceBucket2.Enabled = false;
            textBoxFinanceBucket3.Enabled = false;
            textBoxFinanceBucket4.Enabled = false;
            textBoxFinanceBucket5.Enabled = false;
            textBoxFinanceBucket6.Enabled = false;
            textBoxFinanceBucket7.Enabled = false;
            textBoxFinanceBucket8.Enabled = false;
            textBoxFinanceBucket9.Enabled = false;
            textBoxFinanceBucket10.Enabled = false;
            textBoxStatusNo.Enabled = false;
            textBoxTotalPayments.Enabled = false;
            textBoxTotalLate.Enabled = false;
            textBoxStatus1.Enabled = false;
            textBoxRegAmt1.Enabled = false;
            textBoxTotalISF.Enabled = false;
            textBoxStatus2.Enabled = false;
            textBoxRegAmt2.Enabled = false;
            toolStripButtonEdit.Enabled = false;
            txtNoOfPaymentsMade.Enabled = false;
            txtCASH.Enabled = false;
            // Moses Newman 09/28/2020 remove old TSB Crap
            //checkBoxTSBOverride.Enabled = false;
            //textBoxTSBPaymentRating.Enabled = false;
          


            //Cosigner Info
            cUSTOMER_COS_PHONETextBox.Enabled = false;
            txtCOSExt.Enabled = false;

            //ALTNAME
            txtALTContact1.Enabled = false;
            txtALTContact2.Enabled = false;
            txtALTContact3.Enabled = false;
            txtALTContact4.Enabled = false;
            txtALTRelation1.Enabled = false;
            txtALTRelation2.Enabled = false;
            txtALTRelation3.Enabled = false;
            txtALTRelation4.Enabled = false;
            txtALTPhone1.Enabled = false;
            txtALTPhone2.Enabled = false;
            txtALTPhone3.Enabled = false;
            txtALTPhone4.Enabled = false;
            txtALTExt1.Enabled = false;
            txtALTExt2.Enabled = false;
            txtALTExt3.Enabled = false;
            txtALTExt4.Enabled = false;

            //Bank Info

            //EFT/eCHeck
            textEditBankName.Enabled = false;
            textEditBankCity.Enabled = false;
            textEditBankState.Enabled = false;
            textEditBankRoutingNumber.Enabled = false;
            textEditBankCheckDigit.Enabled = false;
            textEditBankAccountNumber.Enabled = false;
            checkEditBankAutoPay.Enabled = false;
            textEditBankMonthlyPayment.Enabled = false;
            // Moses Newman 02/23/2023
            radioGroupAccountType.Enabled = false;

            //Credit Card Info
            textEditCreditCardNumber.Enabled = false;
            textEditCreditCardName.Enabled = false;
            textEditCreditCardCVV.Enabled = false;
            lookUpEditExpMonth.Enabled = false;
            comboBoxEditExpYear.Enabled = false;

            //cOMMENTDataGridView.Enabled = false;
            cOMMENTDataGridView.AllowUserToAddRows = false;
            cOMMENTDataGridView.AllowUserToDeleteRows = false;
            toolStripButtonSave.Enabled = false;
            toolStripButtonEdit.Enabled = true;
            // Moses Newman 08/03/2020
            //TSB
            textBoxCurrentBalance.Enabled = false;
            textBoxAmountPastDue.Enabled = false;
            textBoxActualPaymentAmount.Enabled = false;
            textBoxHighestCredit.Enabled = false;
            textBoxOrgChargeOffAmount.Enabled = false;
            textBoxSchMonthlyPaymentAmount.Enabled = false;
            textBoxCreditLimit.Enabled = false;
            nullableDateTimePickerDateofLastPayment.Enabled = false;
            nullableDateTimePickerDateofFirstDelinquency.Enabled = false;
            nullableDateTimePickerDateofAccountInformation.Enabled = false;
            nullableDateTimePickerDateOpened.Enabled = false;
            nullableDateTimePickerDateClosed.Enabled = false;
            nullableDateTimePickerFollowUpDate.Enabled = false;
            comboBoxAccountStatus.Enabled = false;
            comboBoxPaymentRating.Enabled = false;
            comboBoxSpecialComment.Enabled = false;
            comboBoxAccountType.Enabled = false;
            comboBoxConsumerIndicator.Enabled = false;
            comboBoxComplianceConditionCode.Enabled = false;
            comboBoxECOACode.Enabled = false;
            comboBoxInterestType.Enabled = false;
            comboBoxPortfolioType.Enabled = false;
            comboBoxTermsFrequency.Enabled = false;
            textBoxTermsDuration.Enabled = false;
            // Moses Newman 08/24/2020 disable new override TSB checkboxes
            checkBoxReportTSB.Enabled = false;
            checkBoxPurge.Enabled = false;
            checkBoxFollowUpDate.Enabled = false;
            checkBoxAccountStatus.Enabled = false;
            checkBoxPaymentRating.Enabled = false;
            checkBoxSpecialComment.Enabled = false;
            checkBoxAccountType.Enabled = false;
            checkBoxConsumerIndicator.Enabled = false;
            checkBoxComplianceCode.Enabled = false;
            checkBoxECOACode.Enabled = false;
            checkBoxPaymentProfile.Enabled = false;
            // Moses Newman 09/04/2020 Turn off Edit Payment History Button
            buttonEditPaymentHistory.Enabled = false;
        }
        private void SetEditMode()
        {
            Text = "Open Customer Maintenance (EDIT Mode)";
            lnSeq = 0;

            // Customer Info
            cUSTOMER_NOTextBox.Enabled = false;
            cUSTOMER_ACT_STATTextBox.Enabled = true;
            cUSTOMER_PURCHASE_ORDERTextBox.Enabled = true;
            cUSTOMER_FIRST_NAMETextBox.Enabled = true;
            cUSTOMER_LAST_NAMETextBox.Enabled = true;
            cUSTOMER_SUFFIXTextBox.Enabled = true;
            cUSTOMER_CONTACTTextBox.Enabled = true;
            cUSTOMER_STREET_1TextBox.Enabled = true;
            cUSTOMER_STREET_2TextBox.Enabled = true;
            cUSTOMER_CITYTextBox.Enabled = true;
            cUSTOMER_STATETextBox.Enabled = true;
            cUSTOMER_ZIP_1TextBox.Enabled = true;
            cUSTOMER_ZIP_2TextBox.Enabled = true;
            cUSTOMER_PHONE_NOTextBox.Enabled = true;
            cUSTOMER_PHONE_EXTtextBox.Enabled = true;
            cUSTOMER_WORK_PHONETextBox.Enabled = true;
            cUSTOMER_WORK_EXTtextBox.Enabled = true;
            cUSTOMER_CELL_PHONETextBox.Enabled = true;
            txtDOB.Enabled = true;
            cUSTOMER_SS_1TextBox.Enabled = true;
            cUSTOMER_SS_2TextBox.Enabled = true;
            cUSTOMER_SS_3TextBox.Enabled = true;
            cUSTOMER_DEALERcomboBox.Enabled = true;
            DealerNamecomboBox.Enabled = true;
            cUSTOMER_COMMENT_1TextBox.Enabled = true;
            cUSTOMER_COMMENT_2TextBox.Enabled = true;
            cUSTOMER_AUTOPAYTextBox.Enabled = true;
            cUSTOMER_CREDIT_SCORE_NTextBox.Enabled = true;
            cUSTOMER_CREDIT_SCORE_ATextBox.Enabled = true;
            cUSTOMER_ALLOTMENTTextBox.Enabled = true;
            cUSTOMER_DISTRIBUTOR_NOTextBox.Enabled = true;
            cUSTOMER_WRONG_ADDRESSTextBox.Enabled = true;
            cUSTOMER_NO_CONTACTTextBox.Enabled = true;
            cUSTOMER_COS_NAMETextBox.Enabled = true;
            cUSTOMER_COS_PHONETextBox.Enabled = true;
            comboBoxLetterNo.Enabled = false;
            comboBoxLetterType.Enabled = false;
            buttonLetter.Enabled = false;
            textBoxState1.Enabled = true;
            textBoxCountryCode.Enabled = true;
            textBoxMilitaryService.Enabled = true;
            textBoxProductCode.Enabled = true;

            // Customer Info 2
            txtFirstPayDate.Enabled = true;
            comboBoxDayDue.Enabled = true;
            txtCollectionAgent.Enabled = true;
            dateTimePickerContractDate.Enabled = true;
            txtRegularPay.Enabled = true;
            txtLoan.Enabled = true;
            txtNoOfPaymentsMade.Enabled = true;
            txtCASH.Enabled = true;
            textBoxLastFinCharge.Enabled = true;
            textBoxTotalFinance.Enabled = true;
            txtPaymentDate.Enabled = true;
            txtPaymentCode.Enabled = true;
            txtPaymentType.Enabled = true;
            txtLateCharge.Enabled = true;
            txtLateChargeBal.Enabled = true;
            txtLastPaymentMade.Enabled = true;
            txtCustomerBalance.Enabled = true;
            textBoxPaidInterest.Enabled = true;
            txtPaidThrough.Enabled = true;
            txtContractStatus.Enabled = true;
            textBoxInterestRate.Enabled = true;
            // Moses Newman 09/28/2020 Remove old TSB Crap
            //txtCreditBureau.Enabled = true;
            //txtTSBCommentCode.Enabled = true;
            txtCreditLimit.Enabled = true;
            textBoxControlDateMM.Enabled = true;
            textBoxControlDateYY.Enabled = true;
            textBoxCreditAvailable.Enabled = true;
            textBoxFinanceBucket1.Enabled = true;
            textBoxFinanceBucket2.Enabled = true;
            textBoxFinanceBucket3.Enabled = true;
            textBoxFinanceBucket4.Enabled = true;
            textBoxFinanceBucket5.Enabled = true;
            textBoxFinanceBucket6.Enabled = true;
            textBoxFinanceBucket7.Enabled = true;
            textBoxFinanceBucket8.Enabled = true;
            textBoxFinanceBucket9.Enabled = true;
            textBoxFinanceBucket10.Enabled = true;
            textBoxStatusNo.Enabled = true;
            textBoxTotalPayments.Enabled = true;
            textBoxTotalLate.Enabled = true;
            textBoxStatus1.Enabled = true;
            textBoxRegAmt1.Enabled = true;
            textBoxTotalISF.Enabled = true;
            textBoxStatus2.Enabled = true;
            textBoxRegAmt2.Enabled = true;
            toolStripButtonEdit.Enabled = false;
            // Moses Newman 09/28/2020 remove old TSB Crap
            //checkBoxTSBOverride.Enabled = true;
            //textBoxTSBPaymentRating.Enabled = true;


            //Cosigner Info
            cUSTOMER_COS_NAMETextBox.Enabled = true;
            cUSTOMER_COS_PHONETextBox.Enabled = true;
            txtCOSExt.Enabled = true;

            //ALTNAME
            txtALTContact1.Enabled = true;
            txtALTContact2.Enabled = true;
            txtALTContact3.Enabled = true;
            txtALTContact4.Enabled = true;
            txtALTRelation1.Enabled = true;
            txtALTRelation2.Enabled = true;
            txtALTRelation3.Enabled = true;
            txtALTRelation4.Enabled = true;
            txtALTPhone1.Enabled = true;
            txtALTPhone2.Enabled = true;
            txtALTPhone3.Enabled = true;
            txtALTPhone4.Enabled = true;
            txtALTExt1.Enabled = true;
            txtALTExt2.Enabled = true;
            txtALTExt3.Enabled = true;
            txtALTExt4.Enabled = true;

            //Bank Info

            //EFT/eCHeck
            textEditBankName.Enabled = true;
            textEditBankCity.Enabled = true;
            textEditBankState.Enabled = true;
            textEditBankRoutingNumber.Enabled = true;
            textEditBankCheckDigit.Enabled = true;
            textEditBankAccountNumber.Enabled = true;
            checkEditBankAutoPay.Enabled = true;
            textEditBankMonthlyPayment.Enabled = true;
            // Moses Newman 02/23/2023
            radioGroupAccountType.Enabled = true;



            //Credit Card Info
            textEditCreditCardNumber.Enabled = true;
            textEditCreditCardName.Enabled = true;
            textEditCreditCardCVV.Enabled = true;
            lookUpEditExpMonth.Enabled = true;
            comboBoxEditExpYear.Enabled = true;

            cOMMENTDataGridView.Enabled = true;
            cOMMENTDataGridView.AllowUserToAddRows = true;
            cOMMENTDataGridView.AllowUserToDeleteRows = true;
            // Moses Newman 08/03/2020
            //TSB
            //textBoxCurrentBalance.Enabled = true;
            //textBoxAmountPastDue.Enabled = true;
            //textBoxActualPaymentAmount.Enabled = true;
            //textBoxHighestCredit.Enabled = true;
            //textBoxOrgChargeOffAmount.Enabled = true;
            //textBoxSchMonthlyPaymentAmount.Enabled = true;
            //textBoxCreditLimit.Enabled = true;
            //nullableDateTimePickerDateofLastPayment.Enabled = true;
            //nullableDateTimePickerDateofFirstDelinquency.Enabled = true;
            //nullableDateTimePickerDateofAccountInformation.Enabled = true;
            //nullableDateTimePickerDateOpened.Enabled = true;
            //nullableDateTimePickerDateClosed.Enabled = true;
            nullableDateTimePickerFollowUpDate.Enabled = true;
            comboBoxAccountStatus.Enabled = true;
            comboBoxPaymentRating.Enabled = true;
            comboBoxSpecialComment.Enabled = true;
            comboBoxAccountType.Enabled = true;
            comboBoxConsumerIndicator.Enabled = true;
            comboBoxComplianceConditionCode.Enabled = true;
            comboBoxECOACode.Enabled = true;
            //comboBoxInterestType.Enabled = true;
            //comboBoxPortfolioType.Enabled = true;
            //comboBoxTermsFrequency.Enabled = true;
            //textBoxTermsDuration.Enabled = true;
            // Moses Newman 08/24/2020 enable new override TSB checkboxes
            checkBoxReportTSB.Enabled = true;
            checkBoxPurge.Enabled = true;
            checkBoxFollowUpDate.Enabled = true;
            checkBoxAccountStatus.Enabled = true;
            checkBoxPaymentRating.Enabled = true;
            checkBoxSpecialComment.Enabled = true;
            checkBoxAccountType.Enabled = true;
            checkBoxConsumerIndicator.Enabled = true;
            checkBoxComplianceCode.Enabled = true;
            checkBoxECOACode.Enabled = true;
            checkBoxPaymentProfile.Enabled = true;

            // Moses Newman 09/04/2020 toggle Edit Payment History only enable if there is a Credit Manager Record
            if (tsbDataSet.ClosedCreditManager.Rows.Count != 0)
                this.buttonEditPaymentHistory.Enabled = true;
            else
                this.buttonEditPaymentHistory.Enabled = false;

            toolStripButtonEdit.Enabled = false;
            toolStripButtonSave.Enabled = false;
        }

        private void setRelatedData()
        {
            Int32 lnExpYear1 = DateTime.Now.Year;

            if (lbAddFlag || lbEdit)
                return;
            if (cUSTOMER_NOTextBox.Text.ToString().TrimEnd().Length > 0)
            {
                oPNCUSTTableAdapter.Fill(iACDataSet.OPNCUST, cUSTOMER_NOTextBox.Text.ToString());
            }
            else
                if (cUSTOMER_PURCHASE_ORDERTextBox.Text.ToString().Length > 0)
                {
                    oPNCUSTTableAdapter.FillByPurchaseOrder(iACDataSet.OPNCUST, cUSTOMER_PURCHASE_ORDERTextBox.Text.ToString());
                }
                else
                    return;

            if (iACDataSet.OPNCUST.Rows.Count > 0)
            {
                cUSTOMER_PURCHASE_ORDERTextBox.Text = iACDataSet.OPNCUST.Rows[0].Field<String>("CUSTOMER_PURCHASE_ORDER").ToString();
                oPNHCUSTTableAdapter.FillByCustomerNo(iACDataSet.OPNHCUST, cUSTOMER_NOTextBox.Text.ToString());
                oPNCOMMTableAdapter.FillByCustNo(iACDataSet.OPNCOMM, cUSTOMER_NOTextBox.Text.ToString());
                aLTNAMETableAdapter.Fill(iACDataSet.ALTNAME, cUSTOMER_NOTextBox.Text.ToString(), cUSTOMER_IAC_TypeTextBox.Text.ToString());
                oPNBANKTableAdapter.Fill(iACDataSet.OPNBANK, cUSTOMER_NOTextBox.Text.ToString(), "O");
                // Moses Newman 09/26/2020 Add ClosedCreditManager code 15 for Credit Line Loans (Open End)
                // Moses Newman 01/15/2022 Now we use Portfolio Type instead of ACCT_TYPE_CODE.
                closedCreditManagerTableAdapter.Fill(tsbDataSet.ClosedCreditManager, cUSTOMER_NOTextBox.Text.ToString(), "C");
                if (iACDataSet.ALTNAME.Rows.Count == 0)
                    Create_New_ALTNAMERecord(cUSTOMER_NOTextBox.Text.ToString());
                StateRatesTableAdapter.Fill(iACDataSet.StateRates, iACDataSet.OPNCUST.Rows[0].Field<String>("CUSTOMER_STATE"));
                if (iACDataSet.StateRates.Rows.Count > 0)
                {
                    // Moses Newman 06/05/2015 Handle possible null value in STATE1
                    StateRatesbindingSource.Position = StateRatesbindingSource.Find("MORE_STATECOD", (iACDataSet.OPNCUST.Rows[0].Field<Nullable<Int32>>("CUSTOMER_STATE1") != null) ? iACDataSet.OPNCUST.Rows[0].Field<Int32>("CUSTOMER_STATE1") : (Int32)0);
                    if (StateRatesbindingSource.Position > -1)
                        textBoxInterestRate.Text = iACDataSet.StateRates.Rows[StateRatesbindingSource.Position].Field<Decimal>("OPFRATE1_Y").ToString().TrimEnd().TrimStart();
                }
                if (iACDataSet.ALTNAME.Rows.Count == 0)
                    Create_New_ALTNAMERecord(cUSTOMER_NOTextBox.Text.ToString().TrimEnd());
                if (iACDataSet.OPNBANK.Rows.Count == 0)
                    Create_New_OPNBANKRecord(cUSTOMER_NOTextBox.Text.ToString().TrimEnd());
            }
            else
                return;

            cUSTOMERBindingSource.MoveFirst();
            txtPayDate.Enabled = false;
            // Moses Newman 04/26/2012 Handle refresh of Dealer Name after cancel from edit!
            DealerListCustbindingSource.Position = DealerListCustbindingSource.Find("OPNDEALR_ACC_NO", iACDataSet.OPNCUST.Rows[0].Field<String>("CUSTOMER_DEALER"));
            if (iACDataSet.OPNBANK.Rows.Count == 0)  // Moses Newman 03/01/2012 Create OPNBANK record if there is none!
                Create_New_OPNBANKRecord(cUSTOMER_NOTextBox.Text.ToString().TrimEnd());
            iACDataSet.OPNBANK.Rows[0].SetField<String>("OPNBANK_EXP_MMYY", iACDataSet.OPNBANK.Rows[0].Field<String>("OPNBANK_EXP_MMYY").PadRight(4, ' '));
            if (iACDataSet.OPNBANK.Rows[0].Field<String>("OPNBANK_EXP_MMYY").Substring(2, 2).Trim() != "")
            {
                lcExpYear1 = DateTime.Now.Year.ToString().Substring(0, 2) + iACDataSet.OPNBANK.Rows[0].Field<String>("OPNBANK_EXP_MMYY").Substring(2, 2).PadLeft(2, '0');
                lnExpYear1 = Convert.ToInt32(lcExpYear1) - 5;
                lcExpYear1 = lnExpYear1.ToString();
            }
            else
                lcExpYear1 = lnExpYear1.ToString();
            lcExpYear2 = (lnExpYear1 + 1).ToString();
            lcExpYear3 = (lnExpYear1 + 2).ToString();
            lcExpYear4 = (lnExpYear1 + 3).ToString();
            lcExpYear5 = (lnExpYear1 + 4).ToString();
            lcExpYear6 = (lnExpYear1 + 5).ToString();
            lcExpYear7 = (lnExpYear1 + 6).ToString();
            lcExpYear8 = (lnExpYear1 + 7).ToString();
            lcExpYear9 = (lnExpYear1 + 8).ToString();
            lcExpYear10 = (lnExpYear1 + 9).ToString();

            comboBoxEditExpYear.Properties.Items.AddRange(new object[] {
                    "",
                    lcExpYear1,
                    lcExpYear2,
                    lcExpYear3,
                    lcExpYear4,
                    lcExpYear5,
                    lcExpYear6,
                    lcExpYear7,
                    lcExpYear8,
                    lcExpYear9,
                    lcExpYear10});

            if (iACDataSet.OPNBANK.Rows[0].Field<String>("OPNBANK_EXP_MMYY").Substring(2, 2).Trim() != "")
            {
                if (iACDataSet.OPNBANK.Rows[0].Field<String>("OPNBANK_EXP_MMYY").Substring(0, 2).Trim() != "")
                {
                    lookUpEditExpMonth.EditValue = iACDataSet.OPNBANK.Rows[0].Field<String>("OPNBANK_EXP_MMYY").Substring(0, 2).Trim();
                }
                comboBoxEditExpYear.EditValue = lcExpYear6;
            }

            int lnRowCount = iACDataSet.OPNCOMM.Rows.Count;
            if (lnRowCount > 0)
                lblCustHasComments.Visible = true;
            else
                lblCustHasComments.Visible = false;

            if (iACDataSet.OPNCUST.Rows.Count > 0)
            {
                lPaidThroughMM = "";
                lPaidThroughYY = "";
                if (iACDataSet.OPNCUST.Rows[0].Field<String>("CUSTOMER_PAID_THRU") != null)
                {
                    if (iACDataSet.OPNCUST.Rows[0].Field<String>("CUSTOMER_PAID_THRU").Length == 4)
                    {
                        lPaidThroughMM = iACDataSet.OPNCUST.Rows[0].Field<String>("CUSTOMER_PAID_THRU").Substring(0, 2);
                        lPaidThroughYY = iACDataSet.OPNCUST.Rows[0].Field<String>("CUSTOMER_PAID_THRU").Substring(2, 2);
                    }
                    else
                    {
                        lPaidThroughMM = "  ";
                        lPaidThroughYY = "  ";
                    }
                }
                lPaidThrough = lPaidThroughMM.TrimEnd() + '/' + lPaidThroughYY.TrimEnd();
                txtPaidThrough.Text = lPaidThrough;
                lControl_Month = iACDataSet.OPNCUST.Rows[0].Field<String>("CUSTOMER_CONTROL_MONTH").TrimEnd().PadLeft(2, '0');
                lControl_Year = iACDataSet.OPNCUST.Rows[0].Field<String>("CUSTOMER_CONTROL_YEAR").TrimEnd().PadLeft(2, '0');
                lControlDate = lControl_Month.TrimEnd() + '/' + lControl_Year.TrimEnd();
            }
            // Moses Newman 12/19/2013 No longer have CUSTOMER_LETTER_NN FIELDS in CUSTOMER FILES so no defaulting letter dropdowns.
            comboBoxLetterNo.SelectedIndex = 0;
            comboBoxLetterType.SelectedIndex = 0;
        }


        private void cUSTOMER_NOTextBox_Validated(object sender, EventArgs e)
        {
            string lsCustomerNo;
            if (lbEdit)
                return;  // Do not requery data on an edit!!!
            if (cUSTOMER_NOTextBox.Text.ToString().Trim().Length < 6 && cUSTOMER_NOTextBox.Text.ToString().Trim().Length > 0)
                cUSTOMER_NOTextBox.Text = cUSTOMER_NOTextBox.Text.PadLeft(6, '0');
            lsCustomerNo = cUSTOMER_NOTextBox.Text.ToString().Trim();
            // Moses Newman 04/26/2012 Make Match Closed Form remove lbAddFlag.
            if (lsCustomerNo == "")
                return;
            if (!lbAddFlag)
                setRelatedData();
            if (iACDataSet.OPNCUST.Rows.Count == 0 && (lsCustomerNo != "" || Program.gsKey == ""))
            {
                var ldlgAnswer = MessageBox.Show("Sorry no customers found that match your selected account number! Would you like to add a new record?", "Add New Prompt", MessageBoxButtons.YesNo);
                if (ldlgAnswer == DialogResult.No)
                {
                    cUSTOMER_NOTextBox.Text = "";
                    ActiveControl = cUSTOMER_NOTextBox;
                    cUSTOMER_NOTextBox.Select();
                }
                else
                {
                    Text = "Open Customer Maintenance (ADD Mode)";
                    String lcHighValue = "";
                    lcHighValue += (char)255;

                    lbAddFlag = true;
                    cUSTOMERBindingSource.AddNew();
                    cUSTOMERBindingSource.EndEdit();
                    toolStripButton1.Enabled = false;
                    toolStripButtonSave.Enabled = true;
                    iACDataSet.OPNCUST.Rows[cUSTOMERBindingSource.Position].SetField<String>("CUSTOMER_NO", lsCustomerNo);
                    iACDataSet.OPNCUST.Rows[cUSTOMERBindingSource.Position].SetField<String>("CUSTOMER_PURCHASE_ORDER", "");
                    iACDataSet.OPNCUST.Rows[cUSTOMERBindingSource.Position].SetField<String>("CUSTOMER_ADD_ON", "");
                    iACDataSet.OPNCUST.Rows[cUSTOMERBindingSource.Position].SetField<String>("CUSTOMER_IAC_TYPE", "O");
                    iACDataSet.OPNCUST.Rows[cUSTOMERBindingSource.Position].SetField<String>("CUSTOMER_POST_IND", lcHighValue);
                    iACDataSet.OPNCUST.Rows[cUSTOMERBindingSource.Position].SetField<String>("CUSTOMER_ACT_STAT", "A");
                    if (!FromWarranty)
                    {
                        iACDataSet.OPNCUST.Rows[cUSTOMERBindingSource.Position].SetField<String>("CUSTOMER_FIRST_NAME", "");
                        iACDataSet.OPNCUST.Rows[cUSTOMERBindingSource.Position].SetField<String>("CUSTOMER_LAST_NAME", "");
                        iACDataSet.OPNCUST.Rows[cUSTOMERBindingSource.Position].SetField<String>("CUSTOMER_SUFFIX", "");
                        iACDataSet.OPNCUST.Rows[cUSTOMERBindingSource.Position].SetField<String>("CUSTOMER_CONTACT", "");
                        iACDataSet.OPNCUST.Rows[cUSTOMERBindingSource.Position].SetField<String>("CUSTOMER_STREET_1", "");
                        iACDataSet.OPNCUST.Rows[cUSTOMERBindingSource.Position].SetField<String>("CUSTOMER_STREET_2", "");
                        iACDataSet.OPNCUST.Rows[cUSTOMERBindingSource.Position].SetField<String>("CUSTOMER_CITY", "");
                        iACDataSet.OPNCUST.Rows[cUSTOMERBindingSource.Position].SetField<String>("CUSTOMER_STATE", "");
                        iACDataSet.OPNCUST.Rows[cUSTOMERBindingSource.Position].SetField<String>("CUSTOMER_ZIP_1", "");
                        iACDataSet.OPNCUST.Rows[cUSTOMERBindingSource.Position].SetField<String>("CUSTOMER_ZIP_2", "");
                        iACDataSet.OPNCUST.Rows[cUSTOMERBindingSource.Position].SetField<String>("CUSTOMER_PHONE_NO", "");
                        iACDataSet.OPNCUST.Rows[cUSTOMERBindingSource.Position].SetField<String>("CUSTOMER_PHONE_EXT", "");
                        iACDataSet.OPNCUST.Rows[cUSTOMERBindingSource.Position].SetField<String>("CUSTOMER_WORK_PHONE", "");
                        iACDataSet.OPNCUST.Rows[cUSTOMERBindingSource.Position].SetField<String>("CUSTOMER_WORK_EXT", "");
                        iACDataSet.OPNCUST.Rows[cUSTOMERBindingSource.Position].SetField<String>("CUSTOMER_CELL_PHONE", "");
                        iACDataSet.OPNCUST.Rows[cUSTOMERBindingSource.Position].SetField<String>("CUSTOMER_SS_1", "");
                        iACDataSet.OPNCUST.Rows[cUSTOMERBindingSource.Position].SetField<String>("CUSTOMER_SS_2", "");
                        iACDataSet.OPNCUST.Rows[cUSTOMERBindingSource.Position].SetField<String>("CUSTOMER_SS_3", "");
                        iACDataSet.OPNCUST.Rows[cUSTOMERBindingSource.Position].SetField<String>("CUSTOMER_REBATE_CODE", "");
                        iACDataSet.OPNCUST.Rows[cUSTOMERBindingSource.Position].SetField<String>("CUSTOMER_COMMENT_1", "");
                        iACDataSet.OPNCUST.Rows[cUSTOMERBindingSource.Position].SetField<String>("CUSTOMER_COMMENT_2", "");
                        iACDataSet.OPNCUST.Rows[cUSTOMERBindingSource.Position].SetField<String>("CUSTOMER_INSURANCE", "N");
                        iACDataSet.OPNCUST.Rows[cUSTOMERBindingSource.Position].SetField<String>("CUSTOMER_AUTO_PAY", "N");
                        iACDataSet.OPNCUST.Rows[cUSTOMERBindingSource.Position].SetField<Int32>("CUSTOMER_CREDIT_SCORE_N", 0);
                        iACDataSet.OPNCUST.Rows[cUSTOMERBindingSource.Position].SetField<String>("CUSTOMER_CREDIT_SCORE_A", "");
                        iACDataSet.OPNCUST.Rows[cUSTOMERBindingSource.Position].SetField<String>("CUSTOMER_ALLOTMENT", "N");
                        iACDataSet.OPNCUST.Rows[cUSTOMERBindingSource.Position].SetField<Int32>("CUSTOMER_DISTRIBUTOR_NO", 0);
                        iACDataSet.OPNCUST.Rows[cUSTOMERBindingSource.Position].SetField<String>("CUSTOMER_WRONG_ADDRESS", "N");
                        iACDataSet.OPNCUST.Rows[cUSTOMERBindingSource.Position].SetField<String>("CUSTOMER_NO_CONTACT", "N");
                        iACDataSet.OPNCUST.Rows[cUSTOMERBindingSource.Position].SetField<String>("CUSTOMER_COS_NAME", "");
                        iACDataSet.OPNCUST.Rows[cUSTOMERBindingSource.Position].SetField<String>("CUSTOMER_COS_PHONE", "");
                        iACDataSet.OPNCUST.Rows[cUSTOMERBindingSource.Position].SetField<String>("CUSTOMER_COS_EXT", "");
                        iACDataSet.OPNCUST.Rows[cUSTOMERBindingSource.Position].SetField<String>("CUSTOMER_PAY_TYPE", "");
                        iACDataSet.OPNCUST.Rows[cUSTOMERBindingSource.Position].SetField<String>("CUSTOMER_PAY_CODE", "");
                        iACDataSet.OPNCUST.Rows[cUSTOMERBindingSource.Position].SetField<DateTime>("CUSTOMER_INIT_DATE", DateTime.Now.Date);
                        iACDataSet.OPNCUST.Rows[cUSTOMERBindingSource.Position].SetField<DateTime>("CUSTOMER_CONTRACT_DATE", DateTime.Now.Date);
                        iACDataSet.OPNCUST.Rows[cUSTOMERBindingSource.Position].SetField<DateTime>("CUSTOMER_LAST_PAYMENT_DATE", DateTime.Now.Date);
                        iACDataSet.OPNCUST.Rows[cUSTOMERBindingSource.Position].SetField<Int32>("CUSTOMER_DAY_DUE", 0);
                        iACDataSet.OPNCUST.Rows[cUSTOMERBindingSource.Position].SetField<String>("CUSTOMER_CREDIT_STATUS", "N");
                        iACDataSet.OPNCUST.Rows[cUSTOMERBindingSource.Position].SetField<Decimal>("CUSTOMER_REGULAR_AMOUNT", 0);
                        iACDataSet.OPNCUST.Rows[cUSTOMERBindingSource.Position].SetField<Decimal>("CUSTOMER_BALANCE", 0);
                        iACDataSet.OPNCUST.Rows[cUSTOMERBindingSource.Position].SetField<Decimal>("CUSTOMER_LOAN_AMOUNT", 0);
                        iACDataSet.OPNCUST.Rows[cUSTOMERBindingSource.Position].SetField<Decimal>("CUSTOMER_LOAN_INTEREST", 0);
                        iACDataSet.OPNCUST.Rows[cUSTOMERBindingSource.Position].SetField<Decimal>("CUSTOMER_LATE_CHARGE", 0);
                        iACDataSet.OPNCUST.Rows[cUSTOMERBindingSource.Position].SetField<Decimal>("CUSTOMER_LATE_CHARGE_BAL", 0);
                        iACDataSet.OPNCUST.Rows[cUSTOMERBindingSource.Position].SetField<Decimal>("CUSTOMER_PAID_INTEREST", 0);
                        iACDataSet.OPNCUST.Rows[cUSTOMERBindingSource.Position].SetField<Decimal>("CUSTOMER_ANNUAL_PERCENTAGE_RATE", 0);
                        iACDataSet.OPNCUST.Rows[cUSTOMERBindingSource.Position].SetField<Decimal>("CUSTOMER_LOAN_CASH", 0);
                        iACDataSet.OPNCUST.Rows[cUSTOMERBindingSource.Position].SetField<Int32>("CUSTOMER_NO_OF_PAYMENTS_MADE", 0);
                        iACDataSet.OPNCUST.Rows[cUSTOMERBindingSource.Position].SetField<String>("CUSTOMER_CREDIT_BUREAU", "N");
                        iACDataSet.OPNCUST.Rows[cUSTOMERBindingSource.Position].SetField<Int32>("CUSTOMER_CREDIT_LIMIT", 0);
                        iACDataSet.OPNCUST.Rows[cUSTOMERBindingSource.Position].SetField<Decimal>("CUSTOMER_LAST_PAYMENT_MADE", 0);
                        iACDataSet.OPNCUST.Rows[cUSTOMERBindingSource.Position].SetField<String>("CUSTOMER_REBATE_CODE", "78");
                        iACDataSet.OPNCUST.Rows[cUSTOMERBindingSource.Position].SetField<Int32>("CUSTOMER_CONTROL_MONTH", 0);
                        iACDataSet.OPNCUST.Rows[cUSTOMERBindingSource.Position].SetField<Int32>("CUSTOMER_CONTROL_YEAR", 0);
                        iACDataSet.OPNCUST.Rows[cUSTOMERBindingSource.Position].SetField<Int32>("CUSTOMER_CREDIT_AVAILABLE", 0);
                        iACDataSet.OPNCUST.Rows[cUSTOMERBindingSource.Position].SetField<String>("CUSTOMER_ALT_FLAG", "N");
                        iACDataSet.OPNCUST.Rows[cUSTOMERBindingSource.Position].SetField<String>("CUSTOMER_COSIGNER_CELL_PHONE", "");
                    }
                    else
                    {
                        iACDataSet.OPNCUST.Rows[cUSTOMERBindingSource.Position].SetField<String>("CUSTOMER_FIRST_NAME", FirstName);
                        iACDataSet.OPNCUST.Rows[cUSTOMERBindingSource.Position].SetField<String>("CUSTOMER_LAST_NAME", LastName);
                        iACDataSet.OPNCUST.Rows[cUSTOMERBindingSource.Position].SetField<String>("CUSTOMER_SUFFIX", CustomerSuffix);
                        iACDataSet.OPNCUST.Rows[cUSTOMERBindingSource.Position].SetField<String>("CUSTOMER_CONTACT", Contact);
                        iACDataSet.OPNCUST.Rows[cUSTOMERBindingSource.Position].SetField<String>("CUSTOMER_STREET_1", Address1);
                        iACDataSet.OPNCUST.Rows[cUSTOMERBindingSource.Position].SetField<String>("CUSTOMER_STREET_2", Address2);
                        iACDataSet.OPNCUST.Rows[cUSTOMERBindingSource.Position].SetField<String>("CUSTOMER_CITY", City);
                        iACDataSet.OPNCUST.Rows[cUSTOMERBindingSource.Position].SetField<String>("CUSTOMER_STATE", State);
                        iACDataSet.OPNCUST.Rows[cUSTOMERBindingSource.Position].SetField<String>("CUSTOMER_ZIP_1", ZipCode);
                        iACDataSet.OPNCUST.Rows[cUSTOMERBindingSource.Position].SetField<String>("CUSTOMER_ZIP_2", ZipPlus4);
                        iACDataSet.OPNCUST.Rows[cUSTOMERBindingSource.Position].SetField<String>("CUSTOMER_PHONE_NO", HomePhone);
                        iACDataSet.OPNCUST.Rows[cUSTOMERBindingSource.Position].SetField<String>("CUSTOMER_PHONE_EXT", HomeExt);
                        iACDataSet.OPNCUST.Rows[cUSTOMERBindingSource.Position].SetField<String>("CUSTOMER_WORK_PHONE", WorkPhone);
                        iACDataSet.OPNCUST.Rows[cUSTOMERBindingSource.Position].SetField<String>("CUSTOMER_WORK_EXT", WorkExt);
                        iACDataSet.OPNCUST.Rows[cUSTOMERBindingSource.Position].SetField<String>("CUSTOMER_CELL_PHONE", CellPhone);
                        // Moses Newman 01/28/2019 Don't forget Date of Birth!
                        iACDataSet.OPNCUST.Rows[cUSTOMERBindingSource.Position].SetField<DateTime>("CUSTOMER_DOB_DATE", DOB);
                        // Moses Newman 01/18/2019 Set 0 APR using 99 record.
                        iACDataSet.OPNCUST.Rows[cUSTOMERBindingSource.Position].SetField<Int32>("CUSTOMER_STATE1", 99);
                        iACDataSet.OPNCUST.Rows[cUSTOMERBindingSource.Position].SetField<String>("CUSTOMER_SS_1", SS1);
                        iACDataSet.OPNCUST.Rows[cUSTOMERBindingSource.Position].SetField<String>("CUSTOMER_SS_2", SS2);
                        iACDataSet.OPNCUST.Rows[cUSTOMERBindingSource.Position].SetField<String>("CUSTOMER_SS_3", SS3);
                        iACDataSet.OPNCUST.Rows[cUSTOMERBindingSource.Position].SetField<String>("CUSTOMER_REBATE_CODE", "");
                        iACDataSet.OPNCUST.Rows[cUSTOMERBindingSource.Position].SetField<String>("CUSTOMER_COMMENT_1", Comment1);
                        iACDataSet.OPNCUST.Rows[cUSTOMERBindingSource.Position].SetField<String>("CUSTOMER_COMMENT_2", Comment2);
                        iACDataSet.OPNCUST.Rows[cUSTOMERBindingSource.Position].SetField<String>("CUSTOMER_INSURANCE", "N");
                        iACDataSet.OPNCUST.Rows[cUSTOMERBindingSource.Position].SetField<String>("CUSTOMER_AUTO_PAY", AutoPay);
                        iACDataSet.OPNCUST.Rows[cUSTOMERBindingSource.Position].SetField<Int32>("CUSTOMER_CREDIT_SCORE_N", CreditScoreN);
                        iACDataSet.OPNCUST.Rows[cUSTOMERBindingSource.Position].SetField<String>("CUSTOMER_CREDIT_SCORE_A", CreditScoreA);
                        iACDataSet.OPNCUST.Rows[cUSTOMERBindingSource.Position].SetField<String>("CUSTOMER_ALLOTMENT", AllotmentProg);
                        iACDataSet.OPNCUST.Rows[cUSTOMERBindingSource.Position].SetField<Int32>("CUSTOMER_DISTRIBUTOR_NO", DistributorNo);
                        iACDataSet.OPNCUST.Rows[cUSTOMERBindingSource.Position].SetField<String>("CUSTOMER_WRONG_ADDRESS", WrongAddress);
                        iACDataSet.OPNCUST.Rows[cUSTOMERBindingSource.Position].SetField<String>("CUSTOMER_NO_CONTACT", NoContact);
                        iACDataSet.OPNCUST.Rows[cUSTOMERBindingSource.Position].SetField<String>("CUSTOMER_COS_NAME", CosignName);
                        iACDataSet.OPNCUST.Rows[cUSTOMERBindingSource.Position].SetField<String>("CUSTOMER_COS_PHONE", CosHomePhone);
                        iACDataSet.OPNCUST.Rows[cUSTOMERBindingSource.Position].SetField<String>("CUSTOMER_COS_EXT", CosHomeExt);
                        iACDataSet.OPNCUST.Rows[cUSTOMERBindingSource.Position].SetField<String>("CUSTOMER_PAY_TYPE", "");
                        iACDataSet.OPNCUST.Rows[cUSTOMERBindingSource.Position].SetField<String>("CUSTOMER_PAY_CODE", "");
                        iACDataSet.OPNCUST.Rows[cUSTOMERBindingSource.Position].SetField<DateTime>("CUSTOMER_INIT_DATE", DateTime.Now.Date);
                        iACDataSet.OPNCUST.Rows[cUSTOMERBindingSource.Position].SetField<DateTime>("CUSTOMER_CONTRACT_DATE", DateTime.Now.Date);
                        iACDataSet.OPNCUST.Rows[cUSTOMERBindingSource.Position].SetField<DateTime>("CUSTOMER_LAST_PAYMENT_DATE", DateTime.Now.Date);
                        comboBoxDayDue.SelectedIndex = comboBoxDayDue.FindStringExact(DayDue.ToString().Trim());
                        comboBoxDayDue.Refresh();
                        iACDataSet.OPNCUST.Rows[cUSTOMERBindingSource.Position].SetField<Int32>("CUSTOMER_DAY_DUE", DayDue);
                        iACDataSet.OPNCUST.Rows[cUSTOMERBindingSource.Position].SetField<String>("CUSTOMER_CREDIT_STATUS", "N");
                        iACDataSet.OPNCUST.Rows[cUSTOMERBindingSource.Position].SetField<Decimal>("CUSTOMER_REGULAR_AMOUNT", 0);
                        iACDataSet.OPNCUST.Rows[cUSTOMERBindingSource.Position].SetField<Decimal>("CUSTOMER_BALANCE", 0);
                        iACDataSet.OPNCUST.Rows[cUSTOMERBindingSource.Position].SetField<Decimal>("CUSTOMER_LOAN_AMOUNT", 0);
                        iACDataSet.OPNCUST.Rows[cUSTOMERBindingSource.Position].SetField<Decimal>("CUSTOMER_LOAN_INTEREST", 0);
                        iACDataSet.OPNCUST.Rows[cUSTOMERBindingSource.Position].SetField<Decimal>("CUSTOMER_LATE_CHARGE", 0);
                        iACDataSet.OPNCUST.Rows[cUSTOMERBindingSource.Position].SetField<Decimal>("CUSTOMER_LATE_CHARGE_BAL", 0);
                        iACDataSet.OPNCUST.Rows[cUSTOMERBindingSource.Position].SetField<Decimal>("CUSTOMER_PAID_INTEREST", 0);
                        iACDataSet.OPNCUST.Rows[cUSTOMERBindingSource.Position].SetField<Decimal>("CUSTOMER_ANNUAL_PERCENTAGE_RATE", 0);
                        iACDataSet.OPNCUST.Rows[cUSTOMERBindingSource.Position].SetField<Decimal>("CUSTOMER_LOAN_CASH", 0);
                        iACDataSet.OPNCUST.Rows[cUSTOMERBindingSource.Position].SetField<Int32>("CUSTOMER_NO_OF_PAYMENTS_MADE", 0);
                        iACDataSet.OPNCUST.Rows[cUSTOMERBindingSource.Position].SetField<String>("CUSTOMER_CREDIT_BUREAU", CreditBureau);
                        iACDataSet.OPNCUST.Rows[cUSTOMERBindingSource.Position].SetField<Int32>("CUSTOMER_CREDIT_LIMIT", 0);
                        iACDataSet.OPNCUST.Rows[cUSTOMERBindingSource.Position].SetField<Decimal>("CUSTOMER_LAST_PAYMENT_MADE", 0);
                        iACDataSet.OPNCUST.Rows[cUSTOMERBindingSource.Position].SetField<String>("CUSTOMER_REBATE_CODE", "78");
                        iACDataSet.OPNCUST.Rows[cUSTOMERBindingSource.Position].SetField<Int32>("CUSTOMER_CONTROL_MONTH", 0);
                        iACDataSet.OPNCUST.Rows[cUSTOMERBindingSource.Position].SetField<Int32>("CUSTOMER_CONTROL_YEAR", 0);
                        iACDataSet.OPNCUST.Rows[cUSTOMERBindingSource.Position].SetField<Int32>("CUSTOMER_CREDIT_AVAILABLE", 0);
                        iACDataSet.OPNCUST.Rows[cUSTOMERBindingSource.Position].SetField<String>("CUSTOMER_ALT_FLAG", "N");
                        iACDataSet.OPNCUST.Rows[cUSTOMERBindingSource.Position].SetField<String>("CUSTOMER_COSIGNER_CELL_PHONE", CosCellPhone);

                        iACDataSet.OPNCUST.Rows[cUSTOMERBindingSource.Position].SetField<String>("CUSTOMER_DEALER", Dealer);

                        cUSTOMERBindingSource.EndEdit();
                        cUSTOMER_DEALERcomboBox.Refresh();
                        comboBoxDayDue.Refresh();

                        // Moses Newman 01/28/2019 Added Dealer Name population.
                        DealerListCustbindingSource.Position = DealerListCustbindingSource.Find("OPNDEALR_ACC_NO", Dealer);
                        StateRatesTableAdapter.Fill(iACDataSet.StateRates, cUSTOMER_STATETextBox.Text);
                        if (iACDataSet.StateRates.Rows.Count > 0)
                        {
                            StateRatesbindingSource.Position = StateRatesbindingSource.Find("MORE_STATECOD", iACDataSet.OPNCUST.Rows[0].Field<Nullable<Int32>>("CUSTOMER_STATE1"));
                            if (StateRatesbindingSource.Position > -1)
                                textBoxInterestRate.Text = iACDataSet.StateRates.Rows[StateRatesbindingSource.Position].Field<Decimal>("OPFRATE1_Y").ToString().TrimEnd().TrimStart();
                        }

                        ActiveControl = cUSTOMER_NOTextBox;
                    }


                    Create_New_ALTNAMERecord(lsCustomerNo);
                    Create_New_OPNBANKRecord(lsCustomerNo);

                    // Customer Info
                    cUSTOMER_NOTextBox.Enabled = true;
                    cUSTOMER_PURCHASE_ORDERTextBox.Enabled = true;
                    cUSTOMER_FIRST_NAMETextBox.Enabled = true;
                    cUSTOMER_LAST_NAMETextBox.Enabled = true;
                    cUSTOMER_SUFFIXTextBox.Enabled = true;
                    cUSTOMER_CONTACTTextBox.Enabled = true;
                    cUSTOMER_STREET_1TextBox.Enabled = true;
                    cUSTOMER_STREET_2TextBox.Enabled = true;
                    cUSTOMER_CITYTextBox.Enabled = true;
                    cUSTOMER_STATETextBox.Enabled = true;
                    cUSTOMER_ZIP_1TextBox.Enabled = true;
                    cUSTOMER_ZIP_2TextBox.Enabled = true;
                    cUSTOMER_PHONE_NOTextBox.Enabled = true;
                    cUSTOMER_PHONE_EXTtextBox.Enabled = true;
                    cUSTOMER_WORK_PHONETextBox.Enabled = true;
                    cUSTOMER_WORK_EXTtextBox.Enabled = true;
                    cUSTOMER_CELL_PHONETextBox.Enabled = true;
                    txtDOB.Enabled = true;
                    cUSTOMER_SS_1TextBox.Enabled = true;
                    cUSTOMER_SS_2TextBox.Enabled = true;
                    cUSTOMER_SS_3TextBox.Enabled = true;
                    cUSTOMER_DEALERcomboBox.Enabled = true;
                    DealerNamecomboBox.Enabled = true;
                    cUSTOMER_COMMENT_1TextBox.Enabled = true;
                    cUSTOMER_COMMENT_2TextBox.Enabled = true;
                    cUSTOMER_AUTOPAYTextBox.Enabled = true;
                    cUSTOMER_CREDIT_SCORE_NTextBox.Enabled = true;
                    cUSTOMER_CREDIT_SCORE_ATextBox.Enabled = true;
                    cUSTOMER_ALLOTMENTTextBox.Enabled = true;
                    cUSTOMER_DISTRIBUTOR_NOTextBox.Enabled = true;
                    cUSTOMER_WRONG_ADDRESSTextBox.Enabled = true;
                    cUSTOMER_NO_CONTACTTextBox.Enabled = true;
                    cUSTOMER_COS_NAMETextBox.Enabled = true;
                    cUSTOMER_COS_PHONETextBox.Enabled = true;
                    comboBoxLetterNo.Enabled = true;
                    comboBoxLetterType.Enabled = true;
                    textBoxState1.Enabled = true;
                    textBoxCountryCode.Enabled = true;
                    textBoxMilitaryService.Enabled = true;
                    textBoxProductCode.Enabled = true;


                    // Customer Info 2
                    txtFirstPayDate.Enabled = true;
                    comboBoxDayDue.Enabled = true;
                    txtCollectionAgent.Enabled = true;
                    dateTimePickerContractDate.Enabled = true;
                    txtRegularPay.Enabled = true;
                    txtCASH.Enabled = true;
                    txtPaidThrough.Enabled = true;
                    txtCreditLimit.Enabled = true;
                    // Moses Newman 09/28/2020 remove old TSB Crap
                    //txtCreditBureau.Enabled = true;
                    //checkBoxTSBOverride.Enabled = true;
                    //textBoxTSBPaymentRating.Enabled = true;

                    // Alternate Address / Cosigner Info
                    cUSTOMER_COS_NAMETextBox.Enabled = true;
                    cUSTOMER_COS_PHONETextBox.Enabled = true;
                    txtCOSExt.Enabled = true;
                    txtCOSCell.Enabled = true;

                    txtALTContact1.Enabled = true;
                    txtALTContact2.Enabled = true;
                    txtALTContact3.Enabled = true;
                    txtALTContact4.Enabled = true;
                    txtALTRelation1.Enabled = true;
                    txtALTRelation2.Enabled = true;
                    txtALTRelation3.Enabled = true;
                    txtALTRelation4.Enabled = true;
                    txtALTPhone1.Enabled = true;
                    txtALTPhone2.Enabled = true;
                    txtALTPhone3.Enabled = true;
                    txtALTPhone4.Enabled = true;
                    txtALTExt1.Enabled = true;
                    txtALTExt2.Enabled = true;
                    txtALTExt3.Enabled = true;
                    txtALTExt4.Enabled = true;

                    textEditBankName.Enabled = true;
                    textEditBankCity.Enabled = true;
                    textEditBankState.Enabled = true;
                    textEditBankRoutingNumber.Enabled = true;
                    textEditBankCheckDigit.Enabled = true;
                    textEditBankAccountNumber.Enabled = true;
                    checkEditBankAutoPay.Enabled = true;
                    textEditBankMonthlyPayment.Enabled = true;
                    // Moses Newman 02/23/2023
                    radioGroupAccountType.Enabled = true;


                    cOMMENTDataGridView.Enabled = true;
                    cOMMENTDataGridView.AllowUserToAddRows = true;
                    cOMMENTDataGridView.AllowUserToDeleteRows = true;

                    // Moses Newman 08/03/2020
                    //TSB
                    //textBoxCurrentBalance.Enabled = true;
                    //textBoxAmountPastDue.Enabled = true;
                    //textBoxActualPaymentAmount.Enabled = true;
                    //textBoxHighestCredit.Enabled = true;
                    //textBoxOrgChargeOffAmount.Enabled = true;
                    //textBoxSchMonthlyPaymentAmount.Enabled = true;
                    //textBoxCreditLimit.Enabled = true;
                    //nullableDateTimePickerDateofLastPayment.Enabled = true;
                    //nullableDateTimePickerDateofFirstDelinquency.Enabled = true;
                    //nullableDateTimePickerDateofAccountInformation.Enabled = true;
                    //nullableDateTimePickerDateOpened.Enabled = true;
                    //nullableDateTimePickerDateClosed.Enabled = true;
                    nullableDateTimePickerFollowUpDate.Enabled = true;
                    comboBoxAccountStatus.Enabled = true;
                    comboBoxPaymentRating.Enabled = true;
                    comboBoxSpecialComment.Enabled = true;
                    comboBoxAccountType.Enabled = true;
                    comboBoxConsumerIndicator.Enabled = true;
                    comboBoxComplianceConditionCode.Enabled = true;
                    comboBoxECOACode.Enabled = true;
                    //comboBoxInterestType.Enabled = true;
                    //comboBoxPortfolioType.Enabled = true;
                    //comboBoxTermsFrequency.Enabled = true;
                    //textBoxTermsDuration.Enabled = true;
                    // Moses Newman 08/24/2020 enable new override TSB checkboxes
                    checkBoxReportTSB.Enabled = true;
                    checkBoxPurge.Enabled = true;
                    checkBoxFollowUpDate.Enabled = true;
                    checkBoxAccountStatus.Enabled = true;
                    checkBoxPaymentRating.Enabled = true;
                    checkBoxSpecialComment.Enabled = true;
                    checkBoxAccountType.Enabled = true;
                    checkBoxConsumerIndicator.Enabled = true;
                    checkBoxComplianceCode.Enabled = true;
                    checkBoxECOACode.Enabled = true;
                    checkBoxPaymentProfile.Enabled = true;
                    // Moses Newman 09/04/2020 toggle Edit Payment History only enable if there is a Credit Manager Record
                    if (tsbDataSet.ClosedCreditManager.Rows.Count != 0)
                        this.buttonEditPaymentHistory.Enabled = true;
                    else
                        this.buttonEditPaymentHistory.Enabled = false;

                    this.toolStripButtonEdit.Enabled = false;

                    ActiveControl = cUSTOMER_DEALERcomboBox;
                    ActiveControl = cUSTOMER_PURCHASE_ORDERTextBox;
                    cUSTOMER_PURCHASE_ORDERTextBox.SelectAll();

                }
            }
            else
            {
                if (!lbAddFlag && !lbEdit)
                    toolStripButtonEdit.Enabled = true;
                if (iACDataSet.OPNHCUST.Rows.Count == 0 && !lbEdit)
                    toolStripButtonDelete.Enabled = true;
                else
                    toolStripButtonDelete.Enabled = false;
                ActiveControl = cUSTOMER_FIRST_NAMETextBox;
                cUSTOMER_FIRST_NAMETextBox.Select();
            }
        }

        private void cUSTOMER_PURCHASE_ORDERTextBox_Validated(object sender, EventArgs e)
        {
            if (lbAddFlag || lbEdit)
                return;     // If in add or Edit mode not doing a lookup on the PO Number!
            // Moses Newman 03/01/2011 Do NOT ZERO PAD purchase order number. It must be right space padded to 8.
            if (cUSTOMER_PURCHASE_ORDERTextBox.Text.ToString().Trim().Length < 8 && cUSTOMER_PURCHASE_ORDERTextBox.Text.ToString().Trim().Length > 0)
                cUSTOMER_PURCHASE_ORDERTextBox.Text = cUSTOMER_PURCHASE_ORDERTextBox.Text.PadRight(8, ' ');
            cUSTOMER_NOTextBox.Text = "";
            setRelatedData();
            if (iACDataSet.OPNCUST.Rows.Count == 0 && cUSTOMER_PURCHASE_ORDERTextBox.Text.ToString().Trim().Length != 0)
            {
                MessageBox.Show("Sorry no customers found that match your selected purchase order number!");
                cUSTOMER_PURCHASE_ORDERTextBox.Text = "";
                ActiveControl = cUSTOMER_PURCHASE_ORDERTextBox;
                cUSTOMER_PURCHASE_ORDERTextBox.Select();
            }
            else
            {
                ActiveControl = cUSTOMER_FIRST_NAMETextBox;
                cUSTOMER_FIRST_NAMETextBox.Select();
            }
        }

        private void General_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == '\r')
            {
                e.Handled = true;
                System.Windows.Forms.SendKeys.Send("{TAB}");
            }
            else
            {
                if (ActiveControl == cUSTOMER_NOTextBox || (ActiveControl == cUSTOMER_PURCHASE_ORDERTextBox && (!lbAddFlag || lbEdit)))
                    return;
                toolStripButtonSave.Enabled = true;
            }
        }

        // The Binoculors SEARCH button
        public void toolStripButton1_Click(object sender, EventArgs e)
        {
            Visible = false;
            form2inst = new frmOpenCustomerLookup();

            form2inst.ShowDialog();
            form2inst.Dispose();
            Visible = true;
            if (Program.gsKey != null)
            {
                cUSTOMER_NOTextBox.Text = Program.gsKey;
                setRelatedData();
                ActiveControl = cUSTOMER_FIRST_NAMETextBox;
                cUSTOMER_FIRST_NAMETextBox.Select();
            }
            Program.gsKey = null;
        }

        //Move to FirstPayDate
        private void textBox46_Validated(object sender, EventArgs e)
        {
            tabOpenCustomerMaintenance.SelectedIndex = 1;
            ActiveControl = txtFirstPayDate;
            txtFirstPayDate.Select();
        }

        private void txtJointOwner_Validated(object sender, EventArgs e)
        {
            tabOpenCustomerMaintenance.SelectedIndex = 3;
            ActiveControl = cUSTOMER_COS_NAMETextBox;
            cUSTOMER_COS_NAMETextBox.Select();
        }

        private void cUSTHISTDataGridView_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            foreach(DataGridViewRow r in cUSTHISTDataGridView.Rows)
                r.DefaultCellStyle.BackColor = (r.Index % 2 == 0) ? Color.White : Color.LightYellow;
        }

        private void cOMMENTDataGridView_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            foreach (DataGridViewRow r in cOMMENTDataGridView.Rows)
                r.DefaultCellStyle.BackColor = (r.Index % 2 == 0) ? Color.White : Color.LightYellow;
            if (!lbEdit || lbAddFlag)
                toolStripButtonSave.Enabled = false;
        }

        private void cUSTOMER_DEALERcomboBox_Validated(object sender, EventArgs e)
        {
            if (iACDataSet.OPNCUST.Rows.Count == 0 && !FromWarranty)
                return;
            Int32 DLRPOS = -1;
            Object Key = null;
            if (cUSTOMER_DEALERcomboBox.Text.ToString().Trim().Length < 3 && cUSTOMER_DEALERcomboBox.Text.ToString().Trim().Length > 0)
                cUSTOMER_DEALERcomboBox.Text = cUSTOMER_DEALERcomboBox.Text.PadLeft(3, '0');

            Key = cUSTOMER_DEALERcomboBox.Text.TrimEnd();
            DLRPOS = OPNDLRLISTBYNUMbindingSource.Find("OPNDEALR_ACC_NO", Key);

            if (DLRPOS == -1 && cUSTOMER_DEALERcomboBox.Text.ToString().Trim().Length != 0)
            {
                MessageBox.Show("Sorry no dealer found that matches your selected dealer number!");
                Key = null;
                DealerNamecomboBox.Text = "";
                cUSTOMER_DEALERcomboBox.Text = "";
                ActiveControl = DealerNamecomboBox;
                DealerNamecomboBox.SelectAll();
            }
            else
            {
                DealerListCustbindingSource.Position = DealerListCustbindingSource.Find("OPNDEALR_ACC_NO", Key);
                if (lbEdit || lbAddFlag)
                    toolStripButtonSave.Enabled = true;
                ActiveControl = cUSTOMER_COMMENT_1TextBox;
                cUSTOMER_COMMENT_1TextBox.SelectAll();
                errorProviderCustomerForm.Clear();
            }
        }

        private void cUSTOMER_DEALERcomboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (lbEdit || lbAddFlag)
                // Moses Newman 03/01/2012 Only TAB out of CUSTOMER_NO field if that is the active field!
                if (ActiveControl == cUSTOMER_NOTextBox || FromWarranty)
                    System.Windows.Forms.SendKeys.Send("{TAB}");
        }

        private void LockCustomerRecord(bool byPO = false)
        {
            Object loLockedBy   = oPNCUSTTableAdapter.LockedBy(cUSTOMER_NOTextBox.Text),
                   loLockedTime = oPNCUSTTableAdapter.LockTime(cUSTOMER_NOTextBox.Text);

            if (loLockedBy != null && ((String)loLockedBy).TrimEnd() != "")
            {
                IACDataSetTableAdapters.ULISTTableAdapter ULISTTableAdapter = new IACDataSetTableAdapters.ULISTTableAdapter();
                ULISTTableAdapter.FillById(iACDataSet.ULIST, Program.gsUserID);
                MessageBox.Show("*** CUSTOMER: " + cUSTOMER_NOTextBox.Text + " WAS LOCKED BY USER: " +
                    loLockedBy + " " +
                    iACDataSet.ULIST.Rows[0].Field<String>("LIST_NAME") +
                    "\nON: " + ((DateTime)loLockedTime).ToLongDateString() + " " +
                    ((DateTime)loLockedTime).ToLongTimeString() + "\n" +
                    "YOU MUST WAIT UNTIL THEY RELEASE IT! ***", "RECORD LOCKED", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                toolStripButtonSave.Enabled = false;
                ULISTTableAdapter.Dispose();
                loLockedBy = null;
                lbEdit = false;  
                iACDataSet.Clear();
                StartupConfiguration(); 
            }
            else
            {
                // Moses Newman 02/03/2024 Handle index out of range possibility
                if (iACDataSet.OPNCUST.Rows.Count > 0)
                {
                    oPNCUSTTableAdapter.LockRecord(Program.gsUserID, iACDataSet.OPNCUST.Rows[0].Field<String>("CUSTOMER_NO"));
                    lbILockedIt = true;   //  Make sure other instances of form don't unlocke this record!
                }
                if (iACDataSet.ALTNAME.Rows.Count == 0)
                    Create_New_ALTNAMERecord(cUSTOMER_NOTextBox.Text.ToString().TrimEnd());
                if (iACDataSet.OPNBANK.Rows.Count == 0)
                    Create_New_OPNBANKRecord(cUSTOMER_NOTextBox.Text.ToString().TrimEnd());
            }
        }

        private void toolStripButtonSave_Click(object sender, EventArgs e)
        {
            string lsCustomerNo;

            Validate();  //Validate form so all data sets are updated with field values
            cUSTOMERBindingSource.EndEdit();

            if (cUSTOMER_FIRST_NAMETextBox.Text.Length == 0)
            {
                GeneralValidationError("*** You must enter a FIRST NAME! ***", cUSTOMER_FIRST_NAMETextBox);
                return;
            }

            if (cUSTOMER_LAST_NAMETextBox.Text.Length == 0)
            {
                GeneralValidationError("*** You must enter a LAST NAME! ***", cUSTOMER_LAST_NAMETextBox);
                return;
            }

            if (cUSTOMER_STREET_1TextBox.Text.Length == 0)
            {
                GeneralValidationError("*** You must enter at least ONE ADDRESS line! ***", cUSTOMER_STREET_1TextBox);
                return;
            }
            if (cUSTOMER_CITYTextBox.Text.Length == 0)
            {
                GeneralValidationError(@"*** You must enter the customer's CITY! ***", cUSTOMER_CITYTextBox);
                return;
            }
            if (cUSTOMER_STATETextBox.Text.Length == 0)
            {
                GeneralValidationError(@"*** You must enter the customer's STATE! ***", cUSTOMER_STATETextBox);
                return;
            }
            if (cUSTOMER_ZIP_1TextBox.Text.Length == 0)
            {
                GeneralValidationError(@"*** You must enter the customer's ZIP CODE! ***", cUSTOMER_ZIP_1TextBox);
                return;
            }

            if (cUSTOMER_DEALERcomboBox.Text.Length == 0)
            {
                GeneralValidationError("*** You must enter a DEALER NUMBER! ***", cUSTOMER_DEALERcomboBox);
                return;
            }
            if (lbAddFlag)
            {
                if (txtCASH.Text.Length == 0 || Convert.ToDecimal(txtCASH.Text.Substring(1)) == 0)
                {
                    tabOpenCustomerMaintenance.SelectedIndex = 1;
                    GeneralValidationError(@"*** You must enter the customer's loan amount (CASH)! ***", txtCASH);
                    ActiveControl = txtCASH;
                    txtCASH.SelectAll();
                    return;
                }
                if (txtRegularPay.Text.Length == 0 || Convert.ToDecimal(txtRegularPay.Text.Substring(1)) == 0)
                {
                    tabOpenCustomerMaintenance.SelectedIndex = 1;
                    GeneralValidationError(@"*** You must enter either the customer's Monthly Payment (REGULAR PAYMENT)! ***", txtRegularPay);
                    ActiveControl = txtRegularPay;
                    txtRegularPay.SelectAll();
                    return;
                }
                if (textBoxState1.SelectedIndex < 0 && textBoxState1.Text.Length == 0)
                {
                    GeneralValidationError(@"*** You must enter the customer's STATE APR CODE! ***", textBoxState1);
                }
                if (comboBoxDayDue.SelectedIndex < 0 && comboBoxDayDue.Text.Length == 0)
                {
                    tabOpenCustomerMaintenance.SelectedIndex = 1;
                    GeneralValidationError(@"*** You must enter the customer's DAY DUE ***", comboBoxDayDue);
                    ActiveControl = comboBoxDayDue;
                    comboBoxDayDue.SelectAll();
                    return;
                }
            }
            lsCustomerNo = cUSTOMER_NOTextBox.Text.ToString().Trim();
            cUSTOMERBindingSource.EndEdit();
            cUSTHISTBindingSource.EndEdit();
            cOMMENTBindingSource.EndEdit();
            ALTNAMEbindingSource.EndEdit();
            OPNBANKbindingSource.EndEdit();
            // Moses Newman 09/26/2020 Add save of TSB data
            closedCreditManagerBindingSource.EndEdit();
            tableAdapConn = new System.Data.SqlClient.SqlConnection();
            tableAdapConn.ConnectionString = IAC2021SQL.Properties.Settings.Default.IAC2010SQLConnectionString;

            tableAdapConn.Open();
            oPNCUSTTableAdapter.Connection = tableAdapConn;
            tableAdapTran = oPNCUSTTableAdapter.BeginTransaction();
            oPNCUSTTableAdapter.Transaction = tableAdapTran;
            aLTNAMETableAdapter.Connection = tableAdapConn;
            aLTNAMETableAdapter.Transaction = tableAdapTran;
            oPNBANKTableAdapter.Connection = tableAdapConn;
            oPNBANKTableAdapter.Transaction = tableAdapTran;
            oPNCOMMTableAdapter.Connection = tableAdapConn;
            oPNCOMMTableAdapter.Transaction = tableAdapTran;
            iACDataSet.OPNCUST.Rows[cUSTOMERBindingSource.Position].SetField<Decimal>("CUSTOMER_INTEREST_RATE1", iACDataSet.StateRates.Rows[StateRatesbindingSource.Position].Field<Decimal>("OPFRATE1_Y"));
            try
            {
                cUSTOMERBindingSource.EndEdit();
                // Moses Newman 06/05/2015 default STATE1 to 1 if null.
                if (iACDataSet.OPNCUST.Rows[cUSTOMERBindingSource.Position].Field<Nullable<Int32>>("CUSTOMER_STATE1") == null)
                {
                    iACDataSet.OPNCUST.Rows[cUSTOMERBindingSource.Position].SetField<Int32>("CUSTOMER_STATE1", 1);
                    cUSTOMERBindingSource.EndEdit();
                }
                oPNCUSTTableAdapter.Update(iACDataSet.OPNCUST.Rows[cUSTOMERBindingSource.Position]);
                aLTNAMETableAdapter.Update(iACDataSet.ALTNAME.Rows[ALTNAMEbindingSource.Position]);
                oPNBANKTableAdapter.Update(iACDataSet.OPNBANK.Rows[OPNBANKbindingSource.Position]);
                Program.UpdateComments(ref iACDataSet, ref cOMMENTBindingSource, true);
                oPNCOMMTableAdapter.Update(iACDataSet.OPNCOMM);  // Delete, Update, and Insert all the customers comment records!
                oPNCUSTTableAdapter.UnlockRecord(iACDataSet.OPNCUST.Rows[cUSTOMERBindingSource.Position].Field<String>("CUSTOMER_NO"));
                // Moses Newman 09/26/2020 Add save of TSB data
                if (tsbDataSet.ClosedCreditManager.Rows.Count != 0)
                {
                    closedCreditManagerTableAdapter.Connection = tableAdapConn;
                    closedCreditManagerTableAdapter.Transaction = tableAdapTran;
                    closedCreditManagerTableAdapter.Update(tsbDataSet.ClosedCreditManager.Rows[closedCreditManagerBindingSource.Position]);
                }
                tableAdapTran.Commit();
            }
            catch (System.Data.SqlClient.SqlException ex)
            {
                tableAdapTran.Rollback();
                oPNCUSTTableAdapter.UnlockRecord(iACDataSet.OPNCUST.Rows[cUSTOMERBindingSource.Position].Field<String>("CUSTOMER_NO"));
                MessageBox.Show("There is a Micriosft SQL Server database error " + ex.Message.ToString());
            }
            catch (System.InvalidOperationException ex)
            {
                tableAdapTran.Rollback();
                oPNCUSTTableAdapter.UnlockRecord(iACDataSet.OPNCUST.Rows[cUSTOMERBindingSource.Position].Field<String>("CUSTOMER_NO"));
                MessageBox.Show("Error: " + ex.Message.ToString());
            }

            finally
            {
                iACDataSet.AcceptChanges();
                tableAdapConn.Close();
                tableAdapConn = null;
                tableAdapTran = null;
                toolStripButtonSave.Enabled = false;
                Program.gsKey = lsCustomerNo;
                if (lbAddFlag)
                {
                    lbAddFlag = false;
                    iACDataSet.OPNCUST.Clear();
                    frmOpenCustMaint_Load(sender, e);
                }
                iACDataSet.AcceptChanges();
                if (lbEdit)
                {
                    lbEdit = false;
                    SetViewMode();
                }
            }
        }

        private void toolStripButtonEdit_Click(object sender, EventArgs e)
        {
            lbEdit = true;
            LockCustomerRecord();
            if (lbEdit)
                SetEditMode();
            else
                Refresh();
        }

        private void toolStripButtonDelete_Click(object sender, EventArgs e)
        {
            string lsCustomerNo = "";

            Validate();  //Validate form so all data sets are updated with field values
            lsCustomerNo = cUSTOMER_NOTextBox.Text.ToString().TrimEnd();

            tableAdapConn = new System.Data.SqlClient.SqlConnection();
            tableAdapConn.ConnectionString = IAC2021SQL.Properties.Settings.Default.IAC2010SQLConnectionString;
            tableAdapConn.Open();
            oPNCUSTTableAdapter.Connection = tableAdapConn;
            tableAdapTran = oPNCUSTTableAdapter.BeginTransaction();
            aLTNAMETableAdapter.Connection = tableAdapConn;
            aLTNAMETableAdapter.Transaction = tableAdapTran;
            oPNBANKTableAdapter.Connection = tableAdapConn;
            oPNBANKTableAdapter.Transaction = tableAdapTran;
            oPNCOMMTableAdapter.Connection = tableAdapConn;
            oPNCOMMTableAdapter.Transaction = tableAdapTran;
            try
            {
                oPNCUSTTableAdapter.DeleteQuery(lsCustomerNo);
                aLTNAMETableAdapter.DeleteQuery(lsCustomerNo, "O");
                oPNBANKTableAdapter.DeleteQuery(lsCustomerNo,"O");
                oPNCOMMTableAdapter.DeleteQuery(lsCustomerNo);
                tableAdapTran.Commit();
            }
            catch (System.Data.SqlClient.SqlException ex)
            {
                tableAdapTran.Rollback();
                MessageBox.Show("This is a Microsoft SQL Server database error: " + ex.Message.ToString());
            }
            catch (System.InvalidOperationException ex)
            {
                tableAdapTran.Rollback();
                MessageBox.Show("Invalid Operation Error: " + ex.Message.ToString());
            }
            catch (Exception ex)
            {
                tableAdapTran.Rollback();
                MessageBox.Show("General Exception Error: " + ex.Message.ToString());
            }
            finally
            {
                iACDataSet.AcceptChanges();
                tableAdapConn.Close();
                tableAdapConn = null;
                tableAdapTran = null;
                toolStripButtonDelete.Enabled = false;
                toolStripButtonEdit.Enabled = false;
                iACDataSet.Clear();
                Program.gsKey = null;
                frmOpenCustMaint_Load(sender, e);
            }
        }

        private void cOMMENTDataGridView_DefaultValuesNeeded(object sender, DataGridViewRowEventArgs e)
        {
            object loQuery = null;
            e.Row.Cells["ID"].Value = Program.gsUserID.TrimEnd();
            e.Row.Cells["Date"].Value = DateTime.Now;
            e.Row.Cells["COMMENT_NO"].Value = txtCommentNo.Text.ToString().TrimEnd();
            e.Row.Cells["COMMENT_HHMMSS"].Value = DateTime.Now.Hour.ToString().PadLeft(2, '0') + DateTime.Now.Minute.ToString().PadLeft(2, '0') + DateTime.Now.Second.ToString().PadLeft(2, '0');
            if (lnSeq == 0)
            {
                loQuery = oPNCOMMTableAdapter.SeqNoQuery(txtCommentNo.Text.ToString().TrimEnd(), DateTime.Now.Date);
                if (loQuery != null)
                    lnSeq = (int)loQuery + 1;
                else
                    lnSeq = 1;
            }
            else
                lnSeq = lnSeq + 1;
            e.Row.Cells["COMMENT_SEQ_NO"].Value = lnSeq;
            e.Row.Cells["COMMENT_DEALER"].Value = cUSTOMER_DEALERcomboBox.Text.ToString().TrimEnd();
        }

        private void cOMMENTDataGridView_EditingControlShowing(object sender, DataGridViewEditingControlShowingEventArgs e)
        {
            if (e.Control.GetType().Name != "DataGridViewComboBoxEditingControl")
            {
                editingControl = null;
                return;
            }
            editingControl = (DataGridViewComboBoxEditingControl)e.Control;
            if (!lbEdit)
                editingControl.Enabled = false;
            editingControl.SelectedIndexChanged += new EventHandler(editingControl_SelectedIndexChanged);
        }

        private void editingControl_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (editingControl == null)
                return;
            if (editingControl.SelectedIndex >= 0)
            {
                toolStripButtonSave.Enabled = true;
                cOMMENTDataGridView.Rows[cOMMENTDataGridView.CurrentRow.Index].Cells["Comment"].Value = iACDataSet.Comment_Types.Rows[editingControl.SelectedIndex].Field<String>("Description").ToString().TrimEnd().ToUpper();
                cOMMENTDataGridView.Rows[cOMMENTDataGridView.CurrentRow.Index].Cells["COMMENT_SEQ_NO"].Value = lnSeq;
                cOMMENTDataGridView.Rows[cOMMENTDataGridView.CurrentRow.Index].Cells["COMMENT_DEALER"].Value = cUSTOMER_DEALERcomboBox.Text.ToString().TrimEnd();
                cOMMENTDataGridView.Rows[cOMMENTDataGridView.CurrentRow.Index].Cells["COMMENT_ID_TYPE"].Value = cOMMENTDataGridView.Rows[cOMMENTDataGridView.CurrentRow.Index].Cells["ID"].Value.ToString().TrimEnd() + iACDataSet.Comment_Types.Rows[editingControl.SelectedIndex].Field<String>("Type").ToString().TrimEnd();
            }
        }

        private void cOMMENTDataGridView_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            if (editingControl == null)
                return;
            editingControl.SelectedIndexChanged -= new EventHandler(editingControl_SelectedIndexChanged);
            editingControl = null;
        }

        private void cOMMENTDataGridView_DataError(object sender, DataGridViewDataErrorEventArgs e)
        {
            MessageBox.Show("The error is: " + e.Exception.ToString() + " The bad value is:" + cOMMENTDataGridView.Rows[e.RowIndex].Cells[e.ColumnIndex].Value.ToString() + '\n' + e.Context.ToString());
        }

        private void cOMMENTDataGridView_UserDeletedRow(object sender, DataGridViewRowEventArgs e)
        {
            toolStripButtonSave.Enabled = true;
        }

        private void cOMMENTDataGridView_UserAddedRow(object sender, DataGridViewRowEventArgs e)
        {
            toolStripButtonSave.Enabled = true;
        }

        private void cOMMENTDataGridView_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            toolStripButtonSave.Enabled = true;
        }

        private void Create_New_ALTNAMERecord(String lsCustomerNo)
        {
            ALTNAMEbindingSource.AddNew();
            ALTNAMEbindingSource.EndEdit();

            // ALTNAME
            iACDataSet.ALTNAME.Rows[ALTNAMEbindingSource.Position].SetField<String>("ALTNAME_NO", lsCustomerNo);
            iACDataSet.ALTNAME.Rows[ALTNAMEbindingSource.Position].SetField<String>("ALTNAME_ADD_ON", "");
            iACDataSet.ALTNAME.Rows[ALTNAMEbindingSource.Position].SetField<String>("ALTNAME_TYPE", "O");
            iACDataSet.ALTNAME.Rows[ALTNAMEbindingSource.Position].SetField<String>("ALTNAME_NAME_1", "");
            iACDataSet.ALTNAME.Rows[ALTNAMEbindingSource.Position].SetField<String>("ALTNAME_NAME_2", "");
            iACDataSet.ALTNAME.Rows[ALTNAMEbindingSource.Position].SetField<String>("ALTNAME_NAME_3", "");
            iACDataSet.ALTNAME.Rows[ALTNAMEbindingSource.Position].SetField<String>("ALTNAME_NAME_4", "");
            iACDataSet.ALTNAME.Rows[ALTNAMEbindingSource.Position].SetField<String>("ALTNAME_RELATION_1", "");
            iACDataSet.ALTNAME.Rows[ALTNAMEbindingSource.Position].SetField<String>("ALTNAME_RELATION_2", "");
            iACDataSet.ALTNAME.Rows[ALTNAMEbindingSource.Position].SetField<String>("ALTNAME_RELATION_3", "");
            iACDataSet.ALTNAME.Rows[ALTNAMEbindingSource.Position].SetField<String>("ALTNAME_RELATION_4", "");
            iACDataSet.ALTNAME.Rows[ALTNAMEbindingSource.Position].SetField<String>("ALTNAME_PHONE_NO_1", "");
            iACDataSet.ALTNAME.Rows[ALTNAMEbindingSource.Position].SetField<String>("ALTNAME_PHONE_NO_2", "");
            iACDataSet.ALTNAME.Rows[ALTNAMEbindingSource.Position].SetField<String>("ALTNAME_PHONE_NO_3", "");
            iACDataSet.ALTNAME.Rows[ALTNAMEbindingSource.Position].SetField<String>("ALTNAME_PHONE_NO_4", "");
            iACDataSet.ALTNAME.Rows[ALTNAMEbindingSource.Position].SetField<String>("ALTNAME_PHONE_EXT_1", "");
            iACDataSet.ALTNAME.Rows[ALTNAMEbindingSource.Position].SetField<String>("ALTNAME_PHONE_EXT_2", "");
            iACDataSet.ALTNAME.Rows[ALTNAMEbindingSource.Position].SetField<String>("ALTNAME_PHONE_EXT_3", "");
            iACDataSet.ALTNAME.Rows[ALTNAMEbindingSource.Position].SetField<String>("ALTNAME_PHONE_EXT_4", "");
        }

        private void Create_New_OPNBANKRecord(String lsCustomerNo)
        {
            OPNBANKbindingSource.AddNew();
            OPNBANKbindingSource.EndEdit();

            //OPNBANK
            iACDataSet.OPNBANK.Rows[OPNBANKbindingSource.Position].SetField<String>("OPNBANK_CUST_NO", lsCustomerNo);
            iACDataSet.OPNBANK.Rows[OPNBANKbindingSource.Position].SetField<String>("OPNBANK_TYPE", "O");
            iACDataSet.OPNBANK.Rows[OPNBANKbindingSource.Position].SetField<String>("OPNBANK_ACCOUNT_NO", "");
            iACDataSet.OPNBANK.Rows[OPNBANKbindingSource.Position].SetField<String>("OPNBANK_NAME", "");
            iACDataSet.OPNBANK.Rows[OPNBANKbindingSource.Position].SetField<String>("OPNBANK_CITY", "");
            iACDataSet.OPNBANK.Rows[OPNBANKbindingSource.Position].SetField<String>("OPNBANK_STATE", "");
            iACDataSet.OPNBANK.Rows[OPNBANKbindingSource.Position].SetField<String>("OPNBANK_TRAN_CODE", "");
            iACDataSet.OPNBANK.Rows[OPNBANKbindingSource.Position].SetField<String>("OPNBANK_CHECK_DIGIT", "");
            iACDataSet.OPNBANK.Rows[OPNBANKbindingSource.Position].SetField<String>("OPNBANK_SELECTION_CODE", "");
            iACDataSet.OPNBANK.Rows[OPNBANKbindingSource.Position].SetField<String>("OPNBANK_CARD_NO", "");
            iACDataSet.OPNBANK.Rows[OPNBANKbindingSource.Position].SetField<String>("OPNBANK_CUST_NAME", "");
            iACDataSet.OPNBANK.Rows[OPNBANKbindingSource.Position].SetField<String>("OPNBANK_CW_CODE", "");
            iACDataSet.OPNBANK.Rows[OPNBANKbindingSource.Position].SetField<String>("OPNBANK_EXP_MMYY", "");
            // Moses Newman 10/24/2013 Default OPNBANK_MONTHLY_PAYMENT to CUSTOMER_REGULAR_AMOUNT
            iACDataSet.OPNBANK.Rows[OPNBANKbindingSource.Position].SetField<Decimal>("OPNBANK_MONTHLY_PAYMENT",
             iACDataSet.OPNCUST.Rows[cUSTOMERBindingSource.Position].Field<Decimal>("CUSTOMER_REGULAR_AMOUNT"));
        }

        private void comboBoxLetterNo_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (lbEdit)
                toolStripButtonSave.Enabled = true;
            if (comboBoxLetterNo.SelectedIndex > 0 && lbEdit)
            {
                comboBoxLetterType.Enabled = false;
                buttonLetter.Enabled = false;
            }
            else
            {
                if (comboBoxLetterNo.SelectedIndex == 0)
                    comboBoxLetterType.Text = " ";
                comboBoxLetterType.Enabled = true;
                buttonLetter.Enabled = true;
            }
        }

        private void comboBoxLetterType_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (lbEdit)
                toolStripButtonSave.Enabled = true;
        }

        private void toolStripButton3_Click(object sender, EventArgs e)
        {
            MDIIAC2013 MDImain = (MDIIAC2013)MdiParent;
            MDImain.CreateFormInstance("ReportViewer", false);
            ReportViewer rptViewr = (ReportViewer)MDImain.frm;

            IACDataSet ReportData = new IACDataSet();
            IACDataSetTableAdapters.OPNCUSTTableAdapter OPNCUSTTableAdapter = new IACDataSetTableAdapters.OPNCUSTTableAdapter();
            IACDataSetTableAdapters.OPNHCUSTTableAdapter OPNHCUSTTableAdapter = new IACDataSetTableAdapters.OPNHCUSTTableAdapter();
            IACDataSetTableAdapters.OPNCOMMTableAdapter OPNCOMMTableAdapter = new IACDataSetTableAdapters.OPNCOMMTableAdapter();
            IACDataSetTableAdapters.OPNDEALRTableAdapter OPNDEALRTableAdapter = new IACDataSetTableAdapters.OPNDEALRTableAdapter();

            OPNCUSTTableAdapter.Fill(ReportData.OPNCUST, cUSTOMER_NOTextBox.Text);
            OPNHCUSTTableAdapter.FillByCustomerNo(ReportData.OPNHCUST, ReportData.OPNCUST.Rows[0].Field<String>("CUSTOMER_NO"));
            OPNCOMMTableAdapter.FillByCustNo(ReportData.OPNCOMM, ReportData.OPNCUST.Rows[0].Field<String>("CUSTOMER_NO"));
            OPNDEALRTableAdapter.Fill(ReportData.OPNDEALR, ReportData.OPNCUST.Rows[0].Field<String>("CUSTOMER_DEALER"));
            OpenCustomerHistory myReportObject = new OpenCustomerHistory();
            myReportObject.SetDataSource(ReportData);
            myReportObject.SetParameterValue("gsUserID", Program.gsUserID);
            myReportObject.SetParameterValue("gsUserName", Program.gsUserName);

            rptViewr.crystalReportViewer.ReportSource = myReportObject;
            rptViewr.crystalReportViewer.Refresh();
            rptViewr.Show();
        }

        private void toolStripButton2_Click(object sender, EventArgs e)
        {
            MDIIAC2013 MDImain = (MDIIAC2013)MdiParent;
            MDImain.CreateFormInstance("FormReciept", false, false, true);
            FormReciept receipt = (FormReciept)MDImain.frm;

            receipt.gsCustomerNo = cUSTOMER_NOTextBox.Text;
            receipt.gsOpenClose = "O";
            receipt.Show();
        }

        private void checkEditAutopay_QueryCheckStateByValue(object sender, DevExpress.XtraEditors.Controls.QueryCheckStateByValueEventArgs e)
        {
            string val = e.Value.ToString();
            switch (val)
            {
                case "Y":
                    e.CheckState = CheckState.Checked;
                    break;
                case "N":
                    e.CheckState = CheckState.Unchecked;
                    break;
                default:
                    e.CheckState = CheckState.Unchecked;
                    break;
            }
            e.Handled = true;
        }

        private void checkEditAutopay_QueryValueByCheckState(object sender, DevExpress.XtraEditors.Controls.QueryValueByCheckStateEventArgs e)
        {
            CheckEdit edit = sender as CheckEdit;
            object val = edit.EditValue;
            switch (e.CheckState)
            {
                case CheckState.Checked:
                    e.Value = "Y";
                    break;
                case CheckState.Unchecked:
                    e.Value = "N";
                    break;
                default:
                    e.Value = "N";
                    break;
            }
            e.Handled = true;
        }

        private void lookUpEditExpMonth_EditValueChanged(object sender, EventArgs e)
        {
            LookUpEdit expMonth = sender as LookUpEdit;

            if (expMonth.EditValue.ToString().Trim() == "")
                return;
            if ((lbEdit || lbAddFlag) && OPNBANKbindingSource.Position > -1 && comboBoxEditExpYear.Text.Trim() != "" && expMonth.EditValue != null)
            {
                iACDataSet.OPNBANK.Rows[OPNBANKbindingSource.Position].SetField<String>("OPNBANK_EXP_MMYY",
                    expMonth.EditValue.ToString().PadLeft(2, '0') + comboBoxEditExpYear.EditValue.ToString().Substring(2, 2));
                OPNBANKbindingSource.EndEdit();
                toolStripButtonSave.Enabled = true;
            }
        }

        private void lookUpEditExpYear_EditValueChanged(object sender, EventArgs e)
        {
            LookUpEdit expYear = sender as LookUpEdit;
            if (cUSTOMER_NOTextBox.Text.ToString().Trim() == "")
                return;
            if ((lbEdit || lbAddFlag) && OPNBANKbindingSource.Position > -1 && expYear.EditValue != null)
            {
                if (expYear.ToString().Length == 4)
                {
                    iACDataSet.OPNBANK.Rows[OPNBANKbindingSource.Position].SetField<String>("OPNBANK_EXP_MMYY",
                        lookUpEditExpMonth.EditValue.ToString().PadLeft(2, '0') + expYear.ToString().Substring(2, 2));
                }
                else
                    iACDataSet.OPNBANK.Rows[OPNBANKbindingSource.Position].SetField<String>("OPNBANK_EXP_MMYY", "");
                OPNBANKbindingSource.EndEdit();
                toolStripButtonSave.Enabled = true;
            }
        }

        private void comboBoxEditExpYear_EditValueChanged(object sender, EventArgs e)
        {
            DevExpress.XtraEditors.ComboBoxEdit expYear = sender as DevExpress.XtraEditors.ComboBoxEdit;

            if (cUSTOMER_NOTextBox.Text.ToString().Trim() == "")
                return;
            if ((lbEdit || lbAddFlag) && OPNBANKbindingSource.Position > -1 && expYear.EditValue != null)
            {
                if (comboBoxEditExpYear.Text.Length == 4)
                {
                    iACDataSet.OPNBANK.Rows[OPNBANKbindingSource.Position].SetField<String>("OPNBANK_EXP_MMYY",
                        lookUpEditExpMonth.EditValue.ToString().PadLeft(2, '0') + expYear.EditValue.ToString().Substring(2, 2));
                }
                else
                    iACDataSet.OPNBANK.Rows[OPNBANKbindingSource.Position].SetField<String>("OPNBANK_EXP_MMYY", "");
                OPNBANKbindingSource.EndEdit();
                toolStripButtonSave.Enabled = true;
            }
        }

        private void textEditBankRoutingNumber_TextChanged(object sender, EventArgs e)
        {
            if (lbEdit && toolStripButtonSave.Enabled == false)
                toolStripButtonSave.Enabled = true;
            if (textEditBankRoutingNumber.Text.Length == 9)
            {
                textEditBankCheckDigit.Text = textEditBankRoutingNumber.Text.Substring(8, 1);
                textEditBankRoutingNumber.Text = textEditBankRoutingNumber.Text.Substring(0, 8);
                System.Windows.Forms.SendKeys.Send("{TAB}");
            }
        }

        private void checkEditBankAutoPay_CheckedChanged(object sender, EventArgs e)
        {
            if (lbAddFlag || lbEdit)
                toolStripButtonSave.Enabled = true;
        }

        private void txtFirstPayDate_Validated(object sender, EventArgs e)
        {
            String lcHighValue = "";
            lcHighValue += (char)255;

            if (!lbAddFlag && iACDataSet.OPNCUST.Rows[0].Field<String>("CUSTOMER_POST_IND") != lcHighValue)
                return;
            DateTime ldTempDate;

            ldTempDate = iACDataSet.OPNCUST.Rows[0].Field<DateTime>("CUSTOMER_INIT_DATE");
            ldTempDate = iACDataSet.OPNCUST.Rows[0].Field<DateTime>("CUSTOMER_INIT_DATE").AddMonths(-1);
            txtPaidThrough.Text = ldTempDate.Month.ToString().PadLeft(2, '0') + ldTempDate.Year.ToString().Substring(2, 2);
        }

        private void buttonLetter_Click(object sender, EventArgs e)
        {
            Int32 lnSeq = -1;
            object loQuery = null;
            String lsLetterNo = comboBoxLetterNo.Text.TrimEnd(), lsLetterType = comboBoxLetterType.Text.TrimEnd().ToUpper();

            if (iACDataSet.OPNCUST.Rows.Count == 0)
            {
                return;
            }

            MailMergeComponents MailMerge = new MailMergeComponents();

            MailMerge.OpenCreateMailMerge(iACDataSet, @"OPNAUTOLETTER#" + lsLetterNo,lsLetterType);

            cOMMENTBindingSource.AddNew();
            cOMMENTBindingSource.EndEdit();
            if (lnSeq == -1)
            {
                loQuery = oPNCOMMTableAdapter.SeqNoQuery(cUSTOMER_NOTextBox.Text, DateTime.Now.Date);
                if (loQuery != null)
                    lnSeq = (int)loQuery + 1;
                else
                    lnSeq = 0;
            }
            else
                lnSeq = lnSeq + 1;
            oPNCOMMTableAdapter.Insert(cUSTOMER_NOTextBox.Text,DateTime.Now.Date,lnSeq,Program.gsUserID,
                                       "Created and sent Letter#"+comboBoxLetterNo.Text.TrimEnd().TrimStart()+".",
                                       " "," ","  ",cUSTOMER_DEALERcomboBox.Text.ToString().TrimEnd(),
                                       Program.gsUserID+"  ",
                                       DateTime.Now.Hour.ToString().PadLeft(2, '0') + DateTime.Now.Minute.ToString().PadLeft(2, '0') + DateTime.Now.Second.ToString().PadLeft(2, '0'),false);
            oPNCOMMTableAdapter.FillByCustNo(iACDataSet.OPNCOMM, cUSTOMER_NOTextBox.Text);
            comboBoxLetterNo.Text = " ";
            comboBoxLetterType.Text = " ";
        }

        private void cUSTOMER_STATETextBox_Validated(object sender, EventArgs e)
        {
            textBoxState1.Enabled = false;
            if (cUSTOMER_STATETextBox.Text.Length == 2)
            {
               textBoxState1.Enabled = true;
               if (lbEdit || lbAddFlag)
                   toolStripButtonSave.Enabled = true;
               StateRatesTableAdapter.Fill(iACDataSet.StateRates, cUSTOMER_STATETextBox.Text);
               if (iACDataSet.StateRates.Rows.Count > 0)
               {
                   StateRatesbindingSource.Position = StateRatesbindingSource.Find("MORE_STATECOD", iACDataSet.OPNCUST.Rows[0].Field<Nullable<Int32>>("CUSTOMER_STATE1"));
                   if (StateRatesbindingSource.Position > -1)
                       textBoxInterestRate.Text = iACDataSet.StateRates.Rows[StateRatesbindingSource.Position].Field<Decimal>("OPFRATE1_Y").ToString().TrimEnd().TrimStart();
               }
            }
        }

        private void textBoxState1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (!lbEdit && !lbAddFlag)
                return;
            if (textBoxState1.SelectedIndex > -1)
            {
                StateRatesbindingSource.Position = StateRatesbindingSource.Find("MORE_STATECOD", textBoxState1.SelectedValue);
                if (StateRatesbindingSource.Position > 0)
                {
                    textBoxInterestRate.Text = iACDataSet.StateRates.Rows[StateRatesbindingSource.Position].Field<Decimal>("OPFRATE1_Y").ToString().TrimStart().TrimEnd();
                    textBoxInterestRate.Refresh();
                }
                toolStripButtonSave.Enabled = true;
            }
        }

        private void cUSTOMER_ACT_STATTextBox_TextChanged(object sender, EventArgs e)
        {
            if (lbEdit)
                toolStripButtonSave.Enabled = true;
        }

        private void txtCASH_Validated(object sender, EventArgs e)
        {
            if (txtCASH.Text.Length != 0)
                if (Convert.ToDecimal(txtCASH.Text.Substring(1)) != 0)
                {
                    txtLoan.Text = txtCASH.Text; 
                    errorProviderCustomerForm.Clear();
                }
        }
       
        private void GeneralValidationError(String error, Control Ctrl)
        {
            errorProviderCustomerForm.SetError(Ctrl, error);
        }

        private void txtDOB_ValueChanged(object sender, EventArgs e)
        {
            if (lbEdit && toolStripButtonSave.Enabled == false)
                toolStripButtonSave.Enabled = true;
        }

        private void buttonEditPaymentHistory_Click(object sender, EventArgs e)
        {
            String OldProfile = tsbDataSet.ClosedCreditManager.Rows[0].Field<String>("PaymentProfile");

            FormDelinquencyPeriods newdelinquencyperiods = new FormDelinquencyPeriods();
            newdelinquencyperiods.CustomerID = iACDataSet.OPNCUST.Rows[0].Field<Int32>("CustomerID");
            newdelinquencyperiods.PeriodEnd = tsbDataSet.ClosedCreditManager.Rows[0].Field<DateTime>("DateOfAccountInformation");
            newdelinquencyperiods.Profile = OldProfile;
            newdelinquencyperiods.ShowDialog();
            tsbDataSet.ClosedCreditManager.Rows[closedCreditManagerBindingSource.Position].SetField<String>("PaymentProfile", newdelinquencyperiods.Profile);
            closedCreditManagerBindingSource.EndEdit();
            newdelinquencyperiods.Hide();
            this.textBoxPaymentHistoryProfile.Refresh();
            if (newdelinquencyperiods.Profile != OldProfile)
                toolStripButtonSave.Enabled = true;
            newdelinquencyperiods.Dispose();
        }

        private void checkBoxReportTSB_CheckedChanged(object sender, EventArgs e)
        {
            if (lbAddFlag || lbEdit)
            {
                toolStripButtonSave.Enabled = true;
                // Moses Newman 09/26/2020 Toggle CUSTOMER_CREDIT_BUREAU if this is checked!
                if (checkBoxReportTSB.Checked)
                    iACDataSet.OPNCUST.Rows[0].SetField<String>("CUSTOMER_CREDIT_BUREAU", "Y");
                else
                    iACDataSet.OPNCUST.Rows[0].SetField<String>("CUSTOMER_CREDIT_BUREAU", "N");
            }
        }

        private void checkBoxPurge_CheckedChanged(object sender, EventArgs e)
        {
            if (lbAddFlag || lbEdit)
                toolStripButtonSave.Enabled = true;
        }

        private void checkBoxFollowUpDate_CheckedChanged(object sender, EventArgs e)
        {
            if (lbAddFlag || lbEdit)
                toolStripButtonSave.Enabled = true;
        }

        private void comboBoxAccountStatus_SelectedValueChanged(object sender, EventArgs e)
        {
            if (lbAddFlag || lbEdit)
            {
                toolStripButtonSave.Enabled = true;
                // Moses Newman 09/26/2020 enable Payment Rating if Account Status is changed to 13,65,89,94, or 95.
                switch (comboBoxAccountStatus.SelectedValue)
                {
                    case "13":
                    case "65":
                    case "89":
                    case "94":
                    case "95":
                        comboBoxPaymentRating.Enabled = true;
                        break;
                    default:
                        comboBoxPaymentRating.Enabled = false;
                        break;
                }
            }
        }

        private void checkBoxAccountStatus_CheckedChanged(object sender, EventArgs e)
        {
            if (lbAddFlag || lbEdit)
                toolStripButtonSave.Enabled = true;
        }

        private void checkBoxPaymentRating_CheckedChanged(object sender, EventArgs e)
        {
            if (lbAddFlag || lbEdit)
                toolStripButtonSave.Enabled = true;
        }

        private void checkBoxSpecialComment_CheckedChanged(object sender, EventArgs e)
        {
            if (lbAddFlag || lbEdit)
                toolStripButtonSave.Enabled = true;
        }

        private void checkBoxAccountType_CheckedChanged(object sender, EventArgs e)
        {
            if (lbAddFlag || lbEdit)
                toolStripButtonSave.Enabled = true;
        }

        private void checkBoxConsumerIndicator_CheckedChanged(object sender, EventArgs e)
        {
            if (lbAddFlag || lbEdit)
                toolStripButtonSave.Enabled = true;
        }

        private void checkBoxComplianceCode_CheckedChanged(object sender, EventArgs e)
        {
            if (lbAddFlag || lbEdit)
                toolStripButtonSave.Enabled = true;
        }

        private void checkBoxECOACode_CheckedChanged(object sender, EventArgs e)
        {
            if (lbAddFlag || lbEdit)
                toolStripButtonSave.Enabled = true;
        }

        private void checkBoxPaymentProfile_CheckedChanged(object sender, EventArgs e)
        {
            if (lbAddFlag || lbEdit)
                toolStripButtonSave.Enabled = true;
        }

        private void comboBoxPaymentRating_SelectedValueChanged(object sender, EventArgs e)
        {
            if (lbAddFlag || lbEdit)
                toolStripButtonSave.Enabled = true;
        }

        private void comboBoxSpecialComment_SelectedValueChanged(object sender, EventArgs e)
        {
            if (lbAddFlag || lbEdit)
                toolStripButtonSave.Enabled = true;
        }

        private void comboBoxAccountType_SelectedValueChanged(object sender, EventArgs e)
        {
            if (lbAddFlag || lbEdit)
                toolStripButtonSave.Enabled = true;
        }

        private void comboBoxConsumerIndicator_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (lbAddFlag || lbEdit)
                toolStripButtonSave.Enabled = true;
        }

        private void comboBoxComplianceConditionCode_SelectedValueChanged(object sender, EventArgs e)
        {
            if (lbAddFlag || lbEdit)
                toolStripButtonSave.Enabled = true;
        }

        private void comboBoxECOACode_SelectedValueChanged(object sender, EventArgs e)
        {
            if (lbAddFlag || lbEdit)
                toolStripButtonSave.Enabled = true;
        }

        private void comboBoxInterestType_SelectedValueChanged(object sender, EventArgs e)
        {
            if (lbAddFlag || lbEdit)
                toolStripButtonSave.Enabled = true;
        }

        private void comboBoxPortfolioType_SelectedValueChanged(object sender, EventArgs e)
        {
            if (lbAddFlag || lbEdit)
                toolStripButtonSave.Enabled = true;
        }

        // Moses Newman 02/23/2023
        private void radioGroupAccountType_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (lbEdit || lbAddFlag)
                toolStripButtonSave.Enabled = true;
        }

        private void checkEditBankAutoPay_CheckedChanged_1(object sender, EventArgs e)
        {
            if (lbAddFlag || lbEdit)
                toolStripButtonSave.Enabled = true;
        }

        private void lookUpEditExpMonth_EditValueChanged_1(object sender, EventArgs e)
        {
            LookUpEdit expMonth = sender as LookUpEdit;

            if (expMonth.EditValue.ToString().Trim() == "")
                return;
            if ((lbEdit || lbAddFlag) && OPNBANKbindingSource.Position > -1 && comboBoxEditExpYear.Text.Trim() != "" && expMonth.EditValue != null)
            {
                iACDataSet.OPNBANK.Rows[OPNBANKbindingSource.Position].SetField<String>("OPNBANK_EXP_MMYY",
                    expMonth.EditValue.ToString().PadLeft(2, '0') + comboBoxEditExpYear.EditValue.ToString().Substring(2, 2));
                OPNBANKbindingSource.EndEdit();
                toolStripButtonSave.Enabled = true;
            }
        }

        private void comboBoxEditExpYear_EditValueChanged_1(object sender, EventArgs e)
        {
            DevExpress.XtraEditors.ComboBoxEdit expYear = sender as DevExpress.XtraEditors.ComboBoxEdit;

            if (cUSTOMER_NOTextBox.Text.ToString().Trim() == "")
                return;
            if ((lbEdit || lbAddFlag) && OPNBANKbindingSource.Position > -1 && expYear.EditValue != null)
            {
                if (comboBoxEditExpYear.Text.Length == 4)
                {
                    iACDataSet.OPNBANK.Rows[OPNBANKbindingSource.Position].SetField<String>("OPNBANK_EXP_MMYY",
                        lookUpEditExpMonth.EditValue.ToString().PadLeft(2, '0') + expYear.EditValue.ToString().Substring(2, 2));
                }
                else
                    iACDataSet.OPNBANK.Rows[OPNBANKbindingSource.Position].SetField<String>("OPNBANK_EXP_MMYY", "");
                OPNBANKbindingSource.EndEdit();
                toolStripButtonSave.Enabled = true;
            }
        }

        private void checkEditBankAutoPay_QueryCheckStateByValue(object sender, DevExpress.XtraEditors.Controls.QueryCheckStateByValueEventArgs e)
        {
            string val = e.Value.ToString();
            switch (val)
            {
                case "Y":
                    e.CheckState = CheckState.Checked;
                    break;
                case "N":
                    e.CheckState = CheckState.Unchecked;
                    break;
                default:
                    e.CheckState = CheckState.Unchecked;
                    break;
            }
            e.Handled = true;
        }

        private void checkEditBankAutoPay_QueryValueByCheckState(object sender, DevExpress.XtraEditors.Controls.QueryValueByCheckStateEventArgs e)
        {
            CheckEdit edit = sender as CheckEdit;
            object val = edit.EditValue;
            switch (e.CheckState)
            {
                case CheckState.Checked:
                    e.Value = "Y";
                    break;
                case CheckState.Unchecked:
                    e.Value = "N";
                    break;
                default:
                    e.Value = "N";
                    break;
            }
            e.Handled = true;
        }

        private void comboBoxTermsFrequency_SelectedValueChanged(object sender, EventArgs e)
        {
            if (lbAddFlag || lbEdit)
                toolStripButtonSave.Enabled = true;
        }

        private void cUSTOMER_FIRST_NAMETextBox_Validated(object sender, EventArgs e)
        {
            if (cUSTOMER_FIRST_NAMETextBox.Text.Length != 0)
                errorProviderCustomerForm.Clear();
        }

        private void cUSTOMER_LAST_NAMETextBox_Validated(object sender, EventArgs e)
        {
            if (cUSTOMER_LAST_NAMETextBox.Text.Length != 0)
                errorProviderCustomerForm.Clear();
        }

        private void cUSTOMER_STREET_1TextBox_Validated(object sender, EventArgs e)
        {
            if (cUSTOMER_STREET_1TextBox.Text.Length != 0)
                errorProviderCustomerForm.Clear();
        }

        private void cUSTOMER_CITYTextBox_Validated(object sender, EventArgs e)
        {
            if (cUSTOMER_CITYTextBox.Text.Length != 0)
                errorProviderCustomerForm.Clear();
        }

        private void cUSTOMER_ZIP_1TextBox_Validated(object sender, EventArgs e)
        {
            if (cUSTOMER_ZIP_1TextBox.Text.Length != 0)
                errorProviderCustomerForm.Clear();
        }

        private void comboBoxDayDue_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBoxDayDue.SelectedIndex >= 0)
            {
                errorProviderCustomerForm.Clear();
            }
        }

        private void comboBoxDayDue_Validated(object sender, EventArgs e)
        {
            if (comboBoxDayDue.Text.Length != 0)
            {
                errorProviderCustomerForm.Clear();
            }
        }

        private void txtRegularPay_Validated(object sender, EventArgs e)
        {
            if (txtRegularPay.Text.Length != 0)
                if (Convert.ToDecimal(txtRegularPay.Text.Substring(1)) != 0)
                {
                    errorProviderCustomerForm.Clear();
                    // Moses Newman 10/24/2013 if OPNBANK_MONTHLY_PAYMENT == 0 THEN COPY CUSTOMER_REGULAR_PAYMENT.
                    if (iACDataSet.OPNBANK.Rows[OPNBANKbindingSource.Position].Field<Decimal>("OPNBANK_MONTHLY_PAYMENT") == 0)
                        iACDataSet.OPNBANK.Rows[OPNBANKbindingSource.Position].SetField<Decimal>("OPNBANK_MONTHLY_PAYMENT", Convert.ToDecimal(txtRegularPay.Text.Substring(1)));
                }
        }

        private void textBoxState1_Validated(object sender, EventArgs e)
        {
            if (textBoxState1.Text.Length != 0)
            {
                errorProviderCustomerForm.Clear();
            }
        }

        private void frmOpenCustMaint_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (lbEdit)
            {
                lbEdit = false;
                cUSTOMERBindingSource.CancelEdit();
                ALTNAMEbindingSource.CancelEdit();
                OPNBANKbindingSource.CancelEdit();
                cOMMENTBindingSource.CancelEdit();
                SetViewMode();
                e.Cancel = true;
            }
            if (iACDataSet.OPNCUST.Rows.Count == 0)
                return;
            Object loLockedBy = null;

            loLockedBy =    oPNCUSTTableAdapter.LockedBy(iACDataSet.OPNCUST.Rows[0].Field<String>("CUSTOMER_NO"));
            if (loLockedBy != null)
            {
                if ((String)loLockedBy == Program.gsUserID && lbILockedIt)
                    oPNCUSTTableAdapter.UnlockRecord(iACDataSet.OPNCUST.Rows[0].Field<String>("CUSTOMER_NO"));
            }

        }

        private void cUSTOMER_PURCHASE_ORDERTextBox_TextChanged(object sender, EventArgs e)
        {
            if (lbEdit || lbAddFlag)
                if (toolStripButtonSave.Enabled != true)
                    toolStripButtonSave.Enabled = true;
        }

        private void cUSTOMER_SS_1TextBox_TextChanged(object sender, EventArgs e)
        {
            if (!lbEdit && !lbAddFlag)
                return;
            if (cUSTOMER_SS_1TextBox.Text.Length == 3)
                System.Windows.Forms.SendKeys.Send("{TAB}");
        }

        private void cUSTOMER_SS_2TextBox_TextChanged(object sender, EventArgs e)
        {
            if (!lbEdit && !lbAddFlag)
                return;
            if (cUSTOMER_SS_2TextBox.Text.Length == 2)
                System.Windows.Forms.SendKeys.Send("{TAB}");
        }

        private void cUSTOMER_SS_3TextBox_TextChanged(object sender, EventArgs e)
        {
            if (!lbEdit && !lbAddFlag)
                return;
            if (cUSTOMER_SS_3TextBox.Text.Length == 4)
                System.Windows.Forms.SendKeys.Send("{TAB}");
        }

        private void txtPaidThrough_Validated(object sender, EventArgs e)
        {
            if (txtPaidThrough.Text.TrimStart().TrimEnd().Length == 3)
                txtPaidThrough.Text = "0" + txtPaidThrough.Text;
            // Moses Newman 12/19/2013 CUSTOMER_PAID_THRU_MM and CUSTOMER_PAID_THRU_YY are now computed fields so no need to set!
        }

        private void txtTSBCommentCode_SelectedValueChanged(object sender, EventArgs e)
        {
            if (lbAddFlag || lbEdit)
                toolStripButtonSave.Enabled = true;
        }

        // Moses Newman 09/28/2020 Remove old TSB Comment Code ListBox
        /*
        // Moses Newman 06/15/2015 User Draw TSB listbox so that it can be 3 lines wide PER ITEM!
        private void txtTSBCommentCode_DrawItem(object sender, DrawItemEventArgs e)
        {
            DataRowView TSBDataRow;

            TSBDataRow = (DataRowView)txtTSBCommentCode.Items[e.Index];
            e.DrawBackground();
            if (lbAddFlag || lbEdit)
                e.Graphics.DrawString(TSBDataRow["Description"].ToString(), e.Font, new SolidBrush(e.ForeColor), e.Bounds);
            else
                e.Graphics.DrawString(TSBDataRow["Description"].ToString(), e.Font, SystemBrushes.GrayText, e.Bounds);
        }*/

        private void checkBoxTSBOverride_CheckedChanged(object sender, EventArgs e)
        {
            if (lbAddFlag || lbEdit)
                toolStripButtonSave.Enabled = true;
        }

    }
}

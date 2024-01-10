using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.DirectoryServices.AccountManagement;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Globalization;
using Microsoft.Office;
using Microsoft.Office.Core;
using Microsoft.Office.Interop;
using Outlook = Microsoft.Office.Interop.Outlook;
using IAC2021SQL.GeneralWSProxy;
using IAC2021SQL.LoginWSProxy;
using IAC2021SQL.MessageWSProxy;
using IAC2021SQL.SubscriberWSProxy;
using Word = Microsoft.Office.Interop.Word;
using Excel = Microsoft.Office.Interop.Excel;
using Microsoft.Office.Tools.Excel;
using System.IO;
using IAC2021SQL.TSBDataSetTableAdapters;
//Moses Newman 11/23/2021 Use DevExpress GridView instead of DataGridView for comments tab now
using DevExpress.XtraGrid.Views.Base;
using DevExpress.XtraGrid.Views.Grid;
using DevExpress.XtraGrid.Columns;
using DevExpress.XtraGrid.Repository;
using DevExpress.XtraEditors;
using DevExpress.Data;
using DevExpress.XtraBars;
using DevExpress.XtraReports.UI;
using DevExpress.DataAccess.Sql;
using DevExpress.DataAccess.Sql.DataApi;
using Microsoft.IdentityModel.Tokens;
using IAC2021SQL.PaymentDataSetTableAdapters;
using DevExpress.LookAndFeel;
using DevExpress.XtraGrid;


namespace IAC2021SQL
{
    public partial class frmNewCustMaint : DevExpress.XtraEditors.XtraForm
    {
        // Moses Newman 12/16/2020
        BindingSource PaymentBindingSource = new BindingSource();
        IACDataSetTableAdapters.PAYMENTTableAdapter PAYMENTTableAdapter = new IACDataSetTableAdapters.PAYMENTTableAdapter();
        // Moses Newman 05/08/2023
        IACDataSetTableAdapters.WarrantyCompanyTableAdapter WarrantyCompanyTableAdapter = new IACDataSetTableAdapters.WarrantyCompanyTableAdapter();
        // Moses Newman 08/2/2013 need to save orginal BALANCE so that maintenance DOES NOT ALTER IT!
        private Object loLastBalance = null;
        private Decimal gnCustomerBalance = 0, gnCustomerBuyout = 0, gnTotalFees = 0, gnRepoFees = 0, gnStorageFees = 0, gnImpoundFees = 0, gnResaleFees = 0,
                        gnRepairFee1 = 0, gnRepairFee2 = 0, gnRepairFee3 = 0, gnRepairFee4 = 0, gnRepairFee5 = 0;
        private string lControl_Month, lControl_Year, lControlDate,
                        lcExpYear1, lcExpYear2, lcExpYear3, lcExpYear4, lcExpYear5, lcExpYear6, lcExpYear7, lcExpYear8,
                        lcExpYear9, lcExpYear10, lsUNCROOT = "", lsDataPath = "";
        private double lPaidInterest;
        private System.Data.SqlClient.SqlTransaction tableAdapTran = null;
        private System.Data.SqlClient.SqlConnection tableAdapConn = null;
        private bool lbAddFlag = false, lbEdit = false, lbILockedIt = false, lbAlreadyIntOverride = false, lbInFullRecourseCheck = false, gbInSave = false;
        private int lnSeq = 0;

        private Program.AmortRec[] AmortTable;

        private frmCustomerLookup form2inst;

        // Moses Newman 09/12/2013 Grab Actual REAL TILA Loan Interest
        private IACDataSetTableAdapters.TVAPRInfoTableAdapter TVAPRInfoTableAdapter = new IACDataSetTableAdapters.TVAPRInfoTableAdapter();
        // Moses Newman 05/31/2018 Add Repo Indicators Dropdown
        private IACDataSetTableAdapters.RepoIndicatorsTableAdapter RepoIndicatorsTableAdapter = new IACDataSetTableAdapters.RepoIndicatorsTableAdapter();
        // Moses Newman 06/12/2018 Add Fees Tab
        private IACDataSetTableAdapters.CustomerFeesTableAdapter CustomerFeesTableAdapter = new IACDataSetTableAdapters.CustomerFeesTableAdapter();
        // Moses Newman 04/18/2019 Add Repo Log Tab
        private RepoDataSet RepoData = new RepoDataSet();
        private RepoDataSetTableAdapters.RepoLogTableAdapter RepoLogTableAdapter = new RepoDataSetTableAdapters.RepoLogTableAdapter();
        // Moses Newman 07/10/2020 ADD TSB Payment Rating Dropdown
        private TSBDataSetTableAdapters.PaymentRatingsTableAdapter PaymentRatingsTableAdapter = new TSBDataSetTableAdapters.PaymentRatingsTableAdapter();
        // Moses Newman 08/14/2020 
        private TSBDataSetTableAdapters.AccountTypesTableAdapter AccountTypesTableAdapter = new TSBDataSetTableAdapters.AccountTypesTableAdapter();

        private struct WholeComment
        {
            public String Field1,
                          Field2,
                          Field3;
        }

        public frmNewCustMaint()
        {
            InitializeComponent();
        }

        private void frmNewCustMaint_Load(object sender, EventArgs e)
        {
            this.termsFrequencyTableAdapter.Fill(this.tsbDataSet.TermsFrequency);
            this.portfolioTypesTableAdapter.Fill(this.tsbDataSet.PortfolioTypes);
            this.interestTypesTableAdapter.Fill(this.tsbDataSet.InterestTypes);
            this.eCOACodesTableAdapter.Fill(this.tsbDataSet.ECOACodes);
            complianceConditionCodesTableAdapter.Fill(tsbDataSet.ComplianceConditionCodes);
            // Moses Newman 08/14/2020 add AccountTypes
            AccountTypesTableAdapter.Fill(tsbDataSet.AccountTypes);
            PaymentRatingsTableAdapter.Fill(tsbDataSet.PaymentRatings);
            consumerIndicatorsTableAdapter.Fill(tsbDataSet.ConsumerIndicators);
            accountStatusesTableAdapter.Fill(tsbDataSet.AccountStatuses);
            StartupConfiguration();
            PerformAutoScale();
            // Moses Newman 07/14/2020 Set DataBindings NullValue to string.Empty to prevent getting stuck in blank field.
            textBoxCosignerTierPoints.DataBindings["Text"].NullValue = string.Empty;
            textBoxTier.DataBindings["Text"].NullValue = string.Empty;
            // Moses Newman 02/28/2021
            nullableDateTimePickerDateContractReceived.Visible = false;
            /*DataGridViewRow row2 = cUSTHISTDataGridView.RowTemplate;
            ColorTextBox cTB = new ColorTextBox();
            cUSTHISTDataGridView.Controls.Add(cTB);
            cTB.Location = this.cUSTHISTDataGridView.GetCellDisplayRectangle(4, row2.Index, true).Location;
            cTB.Size = this.cUSTHISTDataGridView.GetCellDisplayRectangle(4, row2.Index, true).Size;*/
            this.cUSTOMER_DEALERcomboBox.EditValueChanged += new System.EventHandler(this.cUSTOMER_DEALERcomboBox_EditValueChanged);
            warrantyCompanyTableAdapter.FillByAll(iACDataSet.WarrantyCompany);
        }

        private void StartupConfiguration()
        {
            // Moses Newman 11/21/2017 Remove hard coded UNC pathing
            lsUNCROOT = Program.GsDataPath;
            lsDataPath = "";

            xtraTabControlCustomerMaint.SelectedTabPageIndex = 0;
            genCodesTableAdapter.Fill(iACDataSet.GenCodes);
            gapSelectionsTableAdapter.Fill(iACDataSet.GapSelections);
            specialCommentCodesTableAdapter.Fill(iACDataSet.SpecialCommentCodes);
            repoCodesTableAdapter.Fill(iACDataSet.RepoCodes);
            RepoIndicatorsTableAdapter.Fill(iACDataSet.RepoIndicators);
            letterTypeTableAdapter.Fill(iACDataSet.LetterType);
            letterNumberTableAdapter.Fill(iACDataSet.LetterNumber);
            txtFirstPayDate.DataBindings.Clear();
            txtFirstPayDate.DataBindings.Add(new System.Windows.Forms.Binding("EditValue", cUSTOMERBindingSource, "CUSTOMER_INIT_DATE", true));
            comment_TypesTableAdapter.Fill(iACDataSet.Comment_Types);
            dLRLISTBYNUMTableAdapter.Fill(iACDataSet.DLRLISTBYNUM);
            dealerlistTableAdapterCust.FillAll(iACDataSet.DEALERLIST);
            // Moses Newman 10/24/2013 Add Binding sources to DEALER NAME fields on History and Comment Tabs so it does not disply dealer 112 if no customer
            textBox1.DataBindings.Clear();
            textBox8.DataBindings.Clear();
            monthNamesTableAdapter.Fill(iACDataSet.MonthNames);
            cUSTOMER_NOTextBox.EditValue = (Program.gsKey != null) ? Program.gsKey : "";
            if (Program.gsKey != null)
            {
                setRelatedData();
                if (iACDataSet.CUSTOMER.Rows.Count == 0)
                {
                    gnCustomerBalance = 0;
                    gnCustomerBuyout = 0;
                    cUSTOMER_NOTextBox.EditValue = "";
                    cUSTOMER_DEALERcomboBox.EditValue = null;
                }
                else
                {
                    // Moses Newman 05/24/2022 change to nullable int
                    cUSTOMER_DEALERcomboBox.EditValue = iACDataSet.CUSTOMER.Rows[0].Field<Int32?>("CUSTOMER_DEALER");
                }
            }
            else
            {
                gnCustomerBalance = 0;
                gnCustomerBuyout = 0;
                cUSTOMER_NOTextBox.EditValue = "";
                cUSTOMER_PURCHASE_ORDERTextBox.EditValue = "";
                cUSTOMER_DEALERcomboBox.EditValue = "";
                textBox1.Text = "";
            }
            Program.gsKey = null;
            if (!lbEdit)
            {
                SetViewMode();
            }


            cUSTOMER_NOTextBox.Focus();
            cUSTOMER_NOTextBox.SelectAll();
        }


        private void SetViewMode()
        {
            Text = "Closed Customer Maintenance (VIEW Mode)";
            // Customer Info
            cUSTOMER_NOTextBox.Enabled = true;
            cUSTOMER_PURCHASE_ORDERTextBox.Enabled = true;
            cUSTOMER_ACT_STATTextBox.Enabled = false;
            cUSTOMER_FIRST_NAMETextBox.Enabled = false;
            cUSTOMER_LAST_NAMETextBox.Enabled = false;
            comboBoxGN.Enabled = false;
            cUSTOMER_CONTACTTextBox.Enabled = false;
            cUSTOMER_STREET_1TextBox.Enabled = false;
            cUSTOMER_STREET_2TextBox.Enabled = false;
            cUSTOMER_CITYTextBox.Enabled = false;
            cUSTOMER_STATETextBox.Enabled = false;
            cUSTOMER_ZIP_1TextBox.Enabled = false;
            cUSTOMER_ZIP_2TextBox.Enabled = false;
            cUSTOMER_PHONE_NOTextBox.Enabled = false;
            cUSTOMER_PHONE_EXTtextBox.Enabled = false;
            cUSTOMER_WORK_PHONETextBox.Enabled = false;
            cUSTOMER_WORK_EXTtextBox.Enabled = false;
            cUSTOMER_CELL_PHONETextBox.Enabled = false;
            txtDOB.Enabled = false;
            cUSTOMER_SS_1TextBox.Enabled = false;
            cUSTOMER_SS_2TextBox.Enabled = false;
            cUSTOMER_SS_3TextBox.Enabled = false;
            cUSTOMER_DEALERcomboBox.Enabled = false;
            cUSTOMER_COMMENT_1TextBox.Enabled = false;
            cUSTOMER_COMMENT_2TextBox.Enabled = false;
            checkEditCustomerInsurance.Enabled = false;
            checkEditAutoPay.Enabled = false;
            cUSTOMER_CREDIT_SCORE_NTextBox.Enabled = false;
            cUSTOMER_CREDIT_SCORE_ATextBox.Enabled = false;
            checkEditAllotment.Enabled = false;
            cUSTOMER_DISTRIBUTOR_NOTextBox.Enabled = false;
            cUSTOMER_BRANCH_NUMBERTextBox.Enabled = false;
            checkEditWrongAddress.Enabled = false;
            checkEditNoContact.Enabled = false;
            // Moses Newman 12/23/2013 Added Email Address
            richTextBoxEmailAddress.Enabled = false;
            // Moses Newman 12/23/2013 Added Refi CheckBox
            checkBoxRefi.Enabled = false;
            textBoxAccount.Enabled = false;
            // Moses Newman 01/13/2019 Added Warranty CheckBox and OpenAccount
            checkBoxVehicleWarranty.Enabled = false;
            textBoxOpenAccount.Enabled = false;
            if (checkBoxVehicleWarranty.Checked)
            {
                checkBoxVehicleWarranty.ForeColor = Color.Red;
                textBoxOpenAccount.Enabled = true;
            }
            else
                checkBoxVehicleWarranty.ForeColor = SystemColors.ControlText;
            comboBoxLetterNo.Enabled = true;
            comboBoxLetterType.Enabled = true;
            buttonLetter.Enabled = true;
            // Moses Newman 01/29/2017 Added Middle Name, GAP Insurance type, Warranty, TIN
            textBoxMiddleName.Enabled = false;
            comboBoxGAP.Enabled = false;
            // Moses Newman 06/01/2022 Add Warranty Company
            textEditWarrantyCompany.Enabled = false;
            checkBoxWarranty.Enabled = false;
            // Moses Newman 01/24/2018 added ExcludeVSI
            checkBoxExcludeVSI.Enabled = false;
            textBoxTIN.Enabled = false;
            // Moses Newman 09/02/2017
            //buttonValidate.Enabled = false;
            // Moses Newman 09/06/2017
            radioButtonAcct.Enabled = false;
            buttonConfirm.Enabled = true;
            textBoxAuthNo.Enabled = false;
            checkBoxDNTAcct.Enabled = false;
            // Moses Newman 09/20/2021
            radioButtonCOSAcct.Enabled = false;
            buttonCOSConfirm.Enabled = true;
            textBoxCOSAuthNo.Enabled = false;
            checkBoxCOSDNTAcct.Enabled = false;
            // Moses Newman 05/24/2018 
            checkEditMilitary.Enabled = false;
            // Moses Newman 05/24/2018 added CosLetterNo and CosLetterType
            comboBoxCosLetterNo.Enabled = true;
            comboBoxCosLetterType.Enabled = true;
            buttonCosLetter.Enabled = true;
            // Moses Newman 12/19/2019 Send to Dealer Checkbox added.
            checkBoxSendToDealer.Visible = true;
            checkBoxSendToDealer.Enabled = false;
            // Customer Info 2
            txtFirstPayDate.Enabled = false;
            comboBoxDayDue.Enabled = false;
            txtTerm.Enabled = false;
            checkEditCollectionAgent.Enabled = false;
            txtRegularPay.Enabled = false;
            txtLoan.Enabled = false;
            txtLoanInterest.Enabled = false;
            txtAPR.Enabled = false;
            txtCASH.Enabled = false;
            txtNoOfPaymentsMade.Enabled = false;
            checkEditOverideInterest.Enabled = false;
            //txtPartialPayment.Enabled = false;
            txtPaymentDate.Enabled = false;
            txtPaymentType.Enabled = false;
            txtPaymentCode.Enabled = false;
            txtLateCharge.Enabled = false;
            txtLateChargeBal.Enabled = false;
            txtLastPaymentMade.Enabled = false;
            txtCustomerBalance.Enabled = false;
            txtPaidInterest.Enabled = false;
            txtUEInterest.Enabled = false;
            txtPaidThrough.Enabled = false;
            txtCustomerBuyout.Enabled = false;
            txtCustomerPayRem2.Enabled = false;
            txtDealerDisc.Enabled = false;
            //txtContractStatus.Enabled = false;
            txtPaidDiscount.Enabled = false;
            txtDealerDiscBal.Enabled = false;
            txtCreditLimit.Enabled = false;
            txtRebateCode.Enabled = false;
            txtCreditAvailable.Enabled = false;
            txtControlDate.Enabled = false;
            txtNumberofMonths.Enabled = false;
            // Moses Newman 08/26/2020 retired these objects
            //txtCreditBureau.Enabled = false;
            //listBoxTSBCommentCode.Enabled = false;
            toolStripButtonEdit.Enabled = false;
            // Moses Newman 01/20/2015 Add ContractDate
            DateTimePickerContractDate.Enabled = false;
            // Moses Newman 06/19/2015 add TSB Payment Rating Override
            // Moses Newman 08/26/2020 retired these items
            //checkBoxTSBOverride.Enabled = false;
            //comboBoxTSBPaymentRating.Enabled = false;
            // Moses Newman 01/29/2017 Added Maturity Date
            MaturityDate.Enabled = false;
            // Moses Newman 12/09/2018 Add OverrideLateCharge
            checkBoxOverrideLateCharge.Enabled = false;
            // Moses Newman 12/22/2019
            nullableDateTimePickerFundingDate.Enabled = false;
            // Moses Newman 07/21/2020 Add checkbox for overpayment check issue and check number.
            checkBoxCheckIssued.Enabled = false;
            textBoxCheckNo.Enabled = false;
            // Moses Newman 02/28/2021 Add CheckBox for Received Contrat? and Date Contract Received fields
            colorCheckBoxReceivedContract.Enabled = false;
            if (colorCheckBoxReceivedContract.Checked)
            {
                nullableDateTimePickerDateContractReceived.Visible = true;
                nullableDateTimePickerDateContractReceived.Enabled = false;
            }
            else
            {
                nullableDateTimePickerDateContractReceived.Visible = false;
                nullableDateTimePickerDateContractReceived.Enabled = false;
            }

            //Vehicle Info
            txtVehicleYear.Enabled = false;
            txtMake.Enabled = false;
            txtModel.Enabled = false;
            txtVIN.Enabled = false;
            txtInsuranceCompany.Enabled = false;
            txtPolicyNumber.Enabled = false;
            txtInsuranceAgent.Enabled = false;
            txtAgentPhone.Enabled = false;
            txtEffectiveDate.Enabled = false;
            txtExpirationDate.Enabled = false;
            txtJointOwner.Enabled = false;
            checkEditJointOwnership.Enabled = false;
            // Moses Newman 01/30/2022 Verifacto Fields
            textEditPolicyStatus.Enabled = false;
            dateEditCancellationDate.Enabled = false;
            textEditPortfolio.Enabled = false;
            textEditIssueName1.Enabled = false;
            dateEditIssueDate1.Enabled = false;
            textEditIssueName2.Enabled = false;
            dateEditIssueDate2.Enabled = false;
            textEditIssueName3.Enabled = false;
            dateEditIssueDate3.Enabled = false;
            // Moses Newman 02/11/2022
            checkEditHasCollision.Enabled = false;
            checkEditHasComprehensive.Enabled = false;
            textEditCollisionDeductible.Enabled = false;
            textEditComprehensiveDeductible.Enabled = false;

            // Moses Newman 12/18/2013 Add new fields to Vehicle tab and move Credit score, Repo, and Misc fields to Vehicle Tab.
            textBoxMileage.Enabled = false;
            nullableDateTimePickerRepoDate.Enabled = false;
            textBoxRepoAgent.Enabled = false;
            textBoxCurrentLocation.Enabled = false;
            textBoxAuctionHouse.Enabled = false;
            checkBoxTitleReceived.Enabled = false;
            nullableDateTimePickerTitleDateReceived.Enabled = false;
            // Moses Newman 09/08/2019 TitleReleased, DateTitleReleased, ElectronicLien
            checkBoxTitleReleased.Enabled = false;
            nullableDateTimePickerDateTitleReleased.Enabled = false;
            checkBoxElectronicLien.Enabled = false;
            cUSTOMER_CREDIT_SCORE_NTextBox.Enabled = false;
            cUSTOMER_CREDIT_SCORE_ATextBox.Enabled = false;
            cUSTOMER_REPO_INDtextBox.Enabled = false;
            cUSTOMER_REPO_CDEtextBox.Enabled = false;
            comboBoxRepoCodes.Enabled = false;
            // Moses Newman 05/31/2018 add Repo Indicators Dropdown
            comboBoxRepoInd.Enabled = false;
            cUSTOMER_COS_NAMETextBox.Enabled = false;
            cUSTOMER_COS_PHONETextBox.Enabled = false;
            // Moses Newman 01/09/2014 Add Current Location Date and Auction House Date
            nullableDateTimePickerLocDate.Enabled = false;
            nullableDateTimePickerAucDate.Enabled = false;
            // Moses Newman 04/10/2014 Add Full Recourse Checkbox
            checkBoxFullRecourse.Enabled = false;
            // Moses Newman 06/13/2018 Add Full Recourse CheckBox to first tab also;
            checkBoxFullRecourseTab1.Enabled = false;
            // Moses Newman 01/29/2017
            textBoxBuyersAnnualIncome.Enabled = false;
            textBoxTier.Enabled = false;
            // Moses Newman 04/30/2019 Added TierPoints
            textBoxTierPoints.Enabled = false;
            // Moses Newman 05/13/2019 Add LTV
            textBoxLTV.Enabled = false;
            // Moses Newman 05/20/2019 Added DealerCashPrice
            textBoxDealerCashPrice.Enabled = false;


            //Cosigner Info
            txtCOSFirstName.Enabled = false;
            txtCOSLastName.Enabled = false;
            // Moses Newman 06/09/2017 changed txtCOSJunior to comboBox supporting gencodes.
            comboBoxCOSJunior.Enabled = false;
            txtCOSPhone.Enabled = false;
            checkEditUsePrimaryAddress.Enabled = false;
            txtCOSWorkPhone.Enabled = false;
            txtCOSWorkExt.Enabled = false;
            txtCOSAddress.Enabled = false;
            txtCOSCell.Enabled = false;
            txtCOSCity.Enabled = false;
            txtCOSSS_1.Enabled = false;
            txtCOSSS_2.Enabled = false;
            txtCOSSS_3.Enabled = false;
            txtCOSState.Enabled = false;
            txtCOSZip.Enabled = false;
            txtCOSDOB.Enabled = false;
            // Moses Newman 01/29/2017
            textBoxCosignerCreditScore.Enabled = false;
            textBoxCosignerAnnualIncome.Enabled = false;
            textBoxCosignerEmail.Enabled = false;
            // Moses Newman 04/30/2019 Added CosignerTierPoints
            textBoxCosignerTierPoints.Enabled = false;


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
            // Moses Newman 02/22/2023
            radioGroupAccountType.Enabled = false;

            // Moses Newman 12/04/2023 
            // Split Payments
            comboBoxEditPaymentDay1.Enabled = false;
            comboBoxEditPaymentDay2.Enabled = false;
            comboBoxEditPaymentDay3.Enabled = false;
            comboBoxEditPaymentDay4.Enabled = false;
            textEditPayment1.Enabled = false;
            textEditPayment2.Enabled = false;
            textEditPayment3.Enabled = false;
            textEditPayment4.Enabled = false;
            checkEditSplitPay.Enabled = false;

            //Credit Card Info
            textEditCreditCardNumber.Enabled = false;
            textEditCreditCardName.Enabled = false;
            textEditCreditCardCVV.Enabled = false;
            lookUpEditExpMonth.Enabled = false;
            comboBoxEditExpYear.Enabled = false;
            //Moses Newman 11/23/2021 Use DevExpress GridView instead of DataGridView for comments tab now
            cOMMENTGridControl.Enabled = true;
            cOMMENTgridView.OptionsBehavior.Editable = false;
            cOMMENTgridView.OptionsView.NewItemRowPosition = NewItemRowPosition.None;

            toolStripButtonSave.Enabled = false;
            toolStripButtonEdit.Enabled = true;
            xtraTabControlCustomerMaint.SelectedTabPageIndex = 0;
            ActiveControl = cUSTOMER_NOTextBox;
            cUSTOMER_NOTextBox.SelectAll();
            // Moses Newman 06/12/2018
            // Fees
            textBoxRepoFees.Enabled = false;
            textBoxStorageFees.Enabled = false;
            textBoxImpoundFees.Enabled = false;
            textBoxResaleFees.Enabled = false;
            textBoxRepairFee1.Enabled = false;
            textBoxRepairFee2.Enabled = false;
            textBoxRepairFee3.Enabled = false;
            textBoxRepairFee4.Enabled = false;
            textBoxRepairFee5.Enabled = false;
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
            // Moses Newman 4/07/2014 do not eneter if no customer selected! 
            if (cUSTOMERBindingSource.Position == -1)
                return;
            Text = "Closed Customer Maintenance (EDIT Mode)";
            lnSeq = 0;  // Reset comment sequence number

            // Customer Info
            cUSTOMER_NOTextBox.Enabled = false;
            cUSTOMER_PURCHASE_ORDERTextBox.Enabled = true;
            cUSTOMER_ACT_STATTextBox.Enabled = true;
            cUSTOMER_FIRST_NAMETextBox.Enabled = true;
            cUSTOMER_LAST_NAMETextBox.Enabled = true;
            comboBoxGN.Enabled = true;
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
            cUSTOMER_COMMENT_1TextBox.Enabled = true;
            cUSTOMER_COMMENT_2TextBox.Enabled = true;
            checkEditCustomerInsurance.Enabled = true;
            checkEditAutoPay.Enabled = true;
            cUSTOMER_CREDIT_SCORE_NTextBox.Enabled = true;
            cUSTOMER_CREDIT_SCORE_ATextBox.Enabled = true;
            checkEditAllotment.Enabled = true;
            cUSTOMER_DISTRIBUTOR_NOTextBox.Enabled = true;
            cUSTOMER_BRANCH_NUMBERTextBox.Enabled = true;
            checkEditWrongAddress.Enabled = true;
            checkEditNoContact.Enabled = true;
            // Moses Newman 12/23/2013 Added Email Address
            richTextBoxEmailAddress.Enabled = true;
            // Moses Newman 12/23/2013 Added Refi CheckBox
            checkBoxRefi.Enabled = true;
            if (checkBoxRefi.Checked)
                textBoxAccount.Enabled = true;
            else
                textBoxAccount.Enabled = false;
            // Moses Newman 01/13/2019 Added Vehicle Warranty CheckBox and OpenAccount
            checkBoxVehicleWarranty.Enabled = true;
            if (checkBoxVehicleWarranty.Checked)
                textBoxOpenAccount.Enabled = true;
            else
                textBoxOpenAccount.Enabled = false;
            comboBoxLetterNo.Enabled = false;
            comboBoxLetterType.Enabled = false;
            buttonLetter.Enabled = false;
            // Moses Newman 01/29/2017 Added Middle Name, GAP Insurance type, Warranty, TIN
            textBoxMiddleName.Enabled = true;
            comboBoxGAP.Enabled = true;
            // Moses Newman 06/01/2022 Add Warranty Company
            textEditWarrantyCompany.Enabled = true;
            checkBoxWarranty.Enabled = true;
            // Moses Newman 01/24/2018 added ExcludeVSI
            checkBoxExcludeVSI.Enabled = true;
            textBoxTIN.Enabled = true;
            // Moses Newman 09/02/2017
            //buttonValidate.Enabled = true;
            // Moses Newman 09/06/2017
            radioButtonAcct.Enabled = true;
            buttonConfirm.Enabled = true;
            textBoxAuthNo.Enabled = true;
            checkBoxDNTAcct.Enabled = true;
            // Moses Newman 09/20/2021
            radioButtonCOSAcct.Enabled = true;
            buttonCOSConfirm.Enabled = true;
            textBoxCOSAuthNo.Enabled = true;
            checkBoxCOSDNTAcct.Enabled = true;
            // Moses Newman 05/24/2018 
            checkEditMilitary.Enabled = true;
            // Moses Newman 05/24/2018 added CosLetterNo and CosLetterType
            comboBoxCosLetterNo.Enabled = false;
            comboBoxCosLetterType.Enabled = false;
            buttonCosLetter.Enabled = false;
            // Moses Newman 12/19/2019 Send to Dealer Checkbox added.
            if (textBoxDealerEmail.Text.Trim() != "")
            {
                checkBoxSendToDealer.Visible = true;
                checkBoxSendToDealer.Enabled = true;
            }
            else
            {
                checkBoxSendToDealer.Enabled = false;
                checkBoxSendToDealer.Visible = false;
            }
            checkBoxSendToDealer.Refresh();
            // Customer Info 2
            txtFirstPayDate.Enabled = true;
            comboBoxDayDue.Enabled = true;
            txtTerm.Enabled = true;
            checkEditCollectionAgent.Enabled = true;
            txtRegularPay.Enabled = true;
            txtLoan.Enabled = false;
            txtLoanInterest.Enabled = false;
            txtAPR.Enabled = true;
            txtCASH.Enabled = true;
            txtNoOfPaymentsMade.Enabled = true;
            // Moses Newman 01/08/2014 if CUSTOMER is NOT already set to INTEREST OVERRIDE, DO NOT Activate field unless Annual Interest Rate is NOT set to ZERO!
            if (iACDataSet.CUSTOMER.Rows[cUSTOMERBindingSource.Position].Field<Decimal>("CUSTOMER_ANNUAL_PERCENTAGE_RATE") != 0) //&& !lbAlreadyIntOverride) Moses Newman 06/07/2021
                checkEditOverideInterest.Enabled = true;
            else
                checkEditOverideInterest.Enabled = false;
            if (lbAddFlag)
                txtPaymentDate.EditValue = null;
            //nullableDateTimePickerPayDate.Value = txtPaymentDate.Value;
            //nullableDateTimePickerPayDate.Text = txtPaymentDate.Text;
            txtPaymentDate.Enabled = false;
            txtPaymentType.Enabled = false;
            txtPaymentCode.Enabled = false;
            txtLateCharge.Enabled = false;
            txtLateChargeBal.Enabled = true;
            txtLastPaymentMade.Enabled = true;
            txtCustomerBalance.Enabled = true;
            txtPaidInterest.Enabled = true;
            txtUEInterest.Enabled = true;
            txtPaidThrough.Enabled = true;
            txtCustomerBuyout.Enabled = true;
            txtCustomerPayRem2.Enabled = true;
            txtDealerDisc.Enabled = true;
            txtContractStatus.Enabled = true;
            txtPaidDiscount.Enabled = true;
            txtDealerDiscBal.Enabled = true;
            txtCreditLimit.Enabled = true;
            txtRebateCode.Enabled = true;
            txtCreditAvailable.Enabled = true;
            txtControlDate.Enabled = true;
            txtNumberofMonths.Enabled = true;
            // Moses Newman 08/26/2020 retired these objects
            //txtCreditBureau.Enabled = true;
            //listBoxTSBCommentCode.Enabled = true;
            toolStripButtonEdit.Enabled = true;
            // Moses Newman 01/20/2015 Add Contract Date
            DateTimePickerContractDate.Enabled = true;
            // Moses Newman 06/19/2015 add TSB Payment Rating Override
            // Moses Newman 08/26/2020 retired these items
            //checkBoxTSBOverride.Enabled = true;
            //comboBoxTSBPaymentRating.Enabled = true;
            // Moses Newman 01/29/2017 Added Maturity Date
            MaturityDate.Enabled = true;
            // Moses Newman 12/09/2018 Add OverrideLateCharge
            checkBoxOverrideLateCharge.Enabled = true;
            // Moses Newman 12/22/2019
            nullableDateTimePickerFundingDate.Enabled = true;
            // Moses Newman 07/21/2020 Add checkbox for overpayment check issue and check number.
            checkBoxCheckIssued.Enabled = true;
            textBoxCheckNo.Enabled = true;
            // Moses Newman 02/28/2021 Add CheckBox for Received Contrat? and Date Contract Received fields
            colorCheckBoxReceivedContract.Enabled = true;
            if (colorCheckBoxReceivedContract.Checked)
            {
                nullableDateTimePickerDateContractReceived.Enabled = true;
                nullableDateTimePickerDateContractReceived.Visible = true;
            }
            else
            {
                nullableDateTimePickerDateContractReceived.Enabled = false;
                nullableDateTimePickerDateContractReceived.Visible = false;
            }



            //Vehicle Info
            txtVehicleYear.Enabled = true;
            txtMake.Enabled = true;
            txtModel.Enabled = true;
            txtVIN.Enabled = true;
            txtInsuranceCompany.Enabled = true;
            txtPolicyNumber.Enabled = true;
            txtInsuranceAgent.Enabled = true;
            txtAgentPhone.Enabled = true;
            txtEffectiveDate.Enabled = true;
            txtExpirationDate.Enabled = true;
            txtJointOwner.Enabled = true;
            checkEditJointOwnership.Enabled = true;
            // Moses Newman 01/30/2022 Verifacto Fields
            textEditPolicyStatus.Enabled = true;
            dateEditCancellationDate.Enabled = true;
            textEditPortfolio.Enabled = true;
            textEditIssueName1.Enabled = true;
            dateEditIssueDate1.Enabled = true;
            textEditIssueName2.Enabled = true;
            dateEditIssueDate2.Enabled = true;
            textEditIssueName3.Enabled = true;
            dateEditIssueDate3.Enabled = true;
            // Moses Newman 02/11/2022
            checkEditHasCollision.Enabled = true;
            checkEditHasComprehensive.Enabled = true;
            textEditCollisionDeductible.Enabled = true;
            textEditComprehensiveDeductible.Enabled = true;

            // Moses Newman 01/29/2017
            textBoxBuyersAnnualIncome.Enabled = true;

            // Moses Newman 12/18/2013 Add new fields to Vehicle tab and move Credit score, Repo, and Misc fields to Vehicle Tab.
            textBoxMileage.Enabled = true;
            nullableDateTimePickerRepoDate.Enabled = true;
            textBoxRepoAgent.Enabled = true;
            textBoxCurrentLocation.Enabled = true;
            textBoxAuctionHouse.Enabled = true;
            checkBoxTitleReceived.Enabled = true;
            nullableDateTimePickerTitleDateReceived.Enabled = true;
            // Moses Newman 09/08/2019 TitleReleased, DateTitleReleased, ElectronicLien
            checkBoxTitleReleased.Enabled = true;
            nullableDateTimePickerDateTitleReleased.Enabled = true;
            checkBoxElectronicLien.Enabled = true;
            cUSTOMER_CREDIT_SCORE_NTextBox.Enabled = true;
            cUSTOMER_CREDIT_SCORE_ATextBox.Enabled = true;
            // Moses Newman 12/9/2013 Add dropdowns for credit score and reposessions
            cUSTOMER_REPO_INDtextBox.Enabled = true;
            cUSTOMER_REPO_CDEtextBox.Enabled = true;
            // Moses Newman 11/22/2016 Add handling of New IND code R.
            if (iACDataSet.CUSTOMER.Rows[cUSTOMERBindingSource.Position].Field<String>("cUSTOMER_REPO_IND") != "N")
            {
                comboBoxRepoCodes.Enabled = true;
            }
            else
                comboBoxRepoCodes.Enabled = false;
            // Moses Newman 05/31/2018
            comboBoxRepoInd.Enabled = true;
            cUSTOMER_COS_NAMETextBox.Enabled = true;
            cUSTOMER_COS_PHONETextBox.Enabled = true;
            // Moses Newman 01/09/2014 Add Current Location Date and Auction House Date
            nullableDateTimePickerLocDate.Enabled = true;
            nullableDateTimePickerAucDate.Enabled = true;
            // Moses Newman 04/10/2014 Add Full Recourse Checkbox
            checkBoxFullRecourse.Enabled = true;
            // Moses Newman 06/13/2018 Add Full Recourse CheckBox to first tab also;
            checkBoxFullRecourseTab1.Enabled = true;
            textBoxTier.Enabled = true;
            // Moses Newman 04/30/2019 Added TierPoints
            textBoxTierPoints.Enabled = true;
            // Moses Newman 05/13/2019 Add LTV
            textBoxLTV.Enabled = true;
            // Moses Newman 05/20/2019 Added DealerCashPrice
            textBoxDealerCashPrice.Enabled = true;




            //Cosigner Info
            txtCOSFirstName.Enabled = true;
            txtCOSLastName.Enabled = true;
            // Moses Newman 06/09/2017 changed txtCOSJunior to comboBox supporting gencodes.
            comboBoxCOSJunior.Enabled = true;
            txtCOSPhone.Enabled = true;
            checkEditUsePrimaryAddress.Enabled = true;
            txtCOSWorkPhone.Enabled = true;
            txtCOSWorkExt.Enabled = true;
            txtCOSAddress.Enabled = true;
            txtCOSCell.Enabled = true;
            txtCOSCity.Enabled = true;
            txtCOSSS_1.Enabled = true;
            txtCOSSS_2.Enabled = true;
            txtCOSSS_3.Enabled = true;
            txtCOSState.Enabled = true;
            txtCOSZip.Enabled = true;
            txtCOSDOB.Enabled = true;
            // Moses Newman 01/29/2017
            textBoxCosignerCreditScore.Enabled = true;
            textBoxCosignerAnnualIncome.Enabled = true;
            textBoxCosignerEmail.Enabled = true;
            // Moses Newman 04/30/2019 Added CosignerTierPoints
            textBoxCosignerTierPoints.Enabled = true;


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
            // Moses Newman 02/22/2023
            radioGroupAccountType.Enabled = true;

            // Moses Newman 12/04/2023 
            // Split Payments
            comboBoxEditPaymentDay1.Enabled = true;
            comboBoxEditPaymentDay2.Enabled = true;
            comboBoxEditPaymentDay3.Enabled = true;
            comboBoxEditPaymentDay4.Enabled = true;
            textEditPayment1.Enabled = true;
            textEditPayment2.Enabled = true;
            textEditPayment3.Enabled = true;
            textEditPayment4.Enabled = true;
            checkEditSplitPay.Enabled = true;

            //Credit Card Info
            textEditCreditCardNumber.Enabled = true;
            textEditCreditCardName.Enabled = true;
            textEditCreditCardCVV.Enabled = true;
            lookUpEditExpMonth.Enabled = true;
            comboBoxEditExpYear.Enabled = true;
            //Moses Newman 11/23/2021 Use DevExpress GridView instead of DataGridView for comments tab now
            cOMMENTGridControl.Enabled = true;
            cOMMENTgridView.OptionsBehavior.Editable = true;
            cOMMENTgridView.OptionsView.NewItemRowPosition = NewItemRowPosition.Top;
            // Moses Newman 06/12/2018
            // Fees
            textBoxRepoFees.Enabled = true;
            textBoxStorageFees.Enabled = true;
            textBoxImpoundFees.Enabled = true;
            textBoxResaleFees.Enabled = true;
            textBoxRepairFee1.Enabled = true;
            textBoxRepairFee2.Enabled = true;
            textBoxRepairFee3.Enabled = true;
            textBoxRepairFee4.Enabled = true;
            textBoxRepairFee5.Enabled = true;
            // Moses Newman 08/03/2020
            //TSB
            textBoxCurrentBalance.Enabled = true;
            textBoxAmountPastDue.Enabled = true;
            textBoxActualPaymentAmount.Enabled = true;
            textBoxHighestCredit.Enabled = true;
            textBoxOrgChargeOffAmount.Enabled = true;
            textBoxSchMonthlyPaymentAmount.Enabled = true;
            textBoxCreditLimit.Enabled = true;
            nullableDateTimePickerDateofLastPayment.Enabled = true;
            nullableDateTimePickerDateofFirstDelinquency.Enabled = true;
            nullableDateTimePickerDateofAccountInformation.Enabled = true;
            nullableDateTimePickerDateOpened.Enabled = true;
            nullableDateTimePickerDateClosed.Enabled = true;
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
            toolStripButtonSave.Enabled = false;
            toolStripButtonEdit.Enabled = false;
        }

        private void setRelatedData()
        {
            Int32 lnExpYear1 = DateTime.Now.Year;
            gnTotalFees = 0;
            gnRepoFees = 0; gnStorageFees = 0; gnImpoundFees = 0; gnResaleFees = 0;
            gnRepairFee1 = 0; gnRepairFee2 = 0; gnRepairFee3 = 0; gnRepairFee4 = 0; gnRepairFee5 = 0;
            if (lbAddFlag || lbEdit)
                return;

            iACDataSet.ALTNAME.Clear();
            iACDataSet.COMMENT.Clear();
            iACDataSet.CUSTHIST.Clear();
            iACDataSet.DEALER.Clear();
            iACDataSet.Email.Clear();
            iACDataSet.OPNBANK.Clear();
            iACDataSet.VEHICLE.Clear();

            cUSTOMERTableAdapter.Connection.Close();
            if (!String.IsNullOrEmpty(cUSTOMER_NOTextBox.EditValue.ToString())) // Moses Newman 05/21/2022 use ToString() instead of cast.
            {
                iACDataSet.CUSTOMER.Clear();
                cUSTOMERTableAdapter.Fill(iACDataSet.CUSTOMER, cUSTOMER_NOTextBox.EditValue.ToString().Trim());
            }
            else
            {
                String tempPO = cUSTOMER_PURCHASE_ORDERTextBox.EditValue != null ? cUSTOMER_PURCHASE_ORDERTextBox.EditValue.ToString().Trim() : "";
                iACDataSet.CUSTOMER.Clear();
                if (!String.IsNullOrEmpty(tempPO))  // Moses Newman 05/21/2022 use ToString() instead of cast.
                {
                    cUSTOMERTableAdapter.FillByPurchaseOrder(iACDataSet.CUSTOMER, tempPO);
                    // Moses Newman 02/28/2018 Added fill of cUSTOMER_NOTextBox.EditValue with found customer_no
                    if (iACDataSet.CUSTOMER.Rows.Count > 0)
                    {
                        cUSTOMER_NOTextBox.EditValue = iACDataSet.CUSTOMER.Rows[0].Field<String>("CUSTOMER_NO");
                        cUSTOMER_NOTextBox.Refresh();
                    }
                }
                else
                    return;
            }
            if (iACDataSet.CUSTOMER.Rows.Count > 0)
            {
                // Moses Newman 12/9/2013 preselect Credit Score Drop Down Choice and Repo Drop Down Choice if he coresponding customer record fields are valid.
                Int32 RepoIndex = repoCodesBindingSource.Find("Code", iACDataSet.CUSTOMER.Rows[0].Field<String>("CUSTOMER_REPO_CDE")),
                      RepoIndIndex = RepoIndicatorsBindingSource.Find("Code", iACDataSet.CUSTOMER.Rows[0].Field<String>("CUSTOMER_REPO_IND"));  // Moses Newman 05/31/2018
                // Moses Newman 1/8/2014 Set in lbAlreadyIntOveride field so that interest overide record is NOT created if alreadty overided to zero.
                if (iACDataSet.CUSTOMER.Rows[0].Field<String>("CUSTOMER_INT_OVERRIDE") == "Y")
                    lbAlreadyIntOverride = true;
                else
                    lbAlreadyIntOverride = false;
                if (RepoIndex > -1)
                    comboBoxRepoCodes.SelectedIndex = RepoIndex;
                else
                    comboBoxRepoCodes.SelectedIndex = 10;
                // Moses Newman 05/31/2018
                if (RepoIndIndex > -1)
                    comboBoxRepoInd.SelectedIndex = RepoIndIndex;
                else
                    comboBoxRepoInd.SelectedIndex = 1;
                // Moses Newman 10/24/2013 Add Binding sources to DEALER NAME fields on History and Comment Tabs so it does not disply dealer 112 if no customer
                textBox1.DataBindings.Clear();
                textBox8.DataBindings.Clear();
                textBox1.DataBindings.Add(new System.Windows.Forms.Binding("Text", DealerListCustbindingSource, "DEALER_NAME", true));
                textBox8.DataBindings.Add(new System.Windows.Forms.Binding("Text", DealerListCustbindingSource, "DEALER_NAME", true));
                // Moses Newman 04/10/2014 add dealer state to first tab customer screen
                dEALERTableAdapter.Fill(iACDataSet.DEALER, iACDataSet.CUSTOMER.Rows[0].Field<Int32>("CUSTOMER_DEALER"));
                cUSTOMER_PURCHASE_ORDERTextBox.EditValue = iACDataSet.CUSTOMER.Rows[0].Field<String>("CUSTOMER_PURCHASE_ORDER").ToString();
                cUSTHISTTableAdapter.FillByCustomerNo(iACDataSet.CUSTHIST, cUSTOMER_NOTextBox.EditValue.ToString().Trim());
                cOMMENTTableAdapter.FillByCustNo(iACDataSet.COMMENT, cUSTOMER_NOTextBox.EditValue.ToString().Trim());
                vEHICLETableAdapter.FillByCustomerNo(iACDataSet.VEHICLE, cUSTOMER_NOTextBox.EditValue.ToString().Trim());
                aLTNAMETableAdapter.Fill(iACDataSet.ALTNAME, cUSTOMER_NOTextBox.EditValue.ToString().Trim(), cUSTOMER_IAC_TypeTextBox.Text.ToString());
                oPNBANKTableAdapter.Fill(iACDataSet.OPNBANK, cUSTOMER_NOTextBox.EditValue.ToString().Trim(), "C");
                // Moses Newman 01/10/2024 Fill Invoices
                invoicesTableAdapter.FillAllByCustomerId(paymentDataSet.Invoices, Convert.ToInt32(cUSTOMER_NOTextBox.EditValue.ToString().Trim()));
                // Moses Newman 08/02/2020 Add ClosedCreditManager 
                closedCreditManagerTableAdapter.Fill(tsbDataSet.ClosedCreditManager, cUSTOMER_NOTextBox.EditValue.ToString().Trim(), "I");
                // Moses Newman 08/24/2020 possibly unsecured NON-AUTO loan!
                //if(tsbDataSet.ClosedCreditManager.Rows.Count == 0)
                //closedCreditManagerTableAdapter.Fill(tsbDataSet.ClosedCreditManager, cUSTOMER_NOTextBox.EditValue.ToString(), "01");
                // Moses Newman 12/23/2013 Add Email Address Record
                emailTableAdapter.Fill(iACDataSet.Email, cUSTOMER_NOTextBox.EditValue.ToString().Trim());
                // Moses Newman 04/18/2019 Add Repo Log Tab
                RepoLogTableAdapter.FillByCustomerNo(RepoData.RepoLog, cUSTOMER_NOTextBox.EditValue.ToString().Trim());
                gridControlRepoLog.DataSource = RepoData.RepoLog;
                // Moses Newman 05/08/2023 
                WarrantyCompanyTableAdapter.FillByAll(iACDataSet.WarrantyCompany);
                bindingSourceWarrantyCompany.Position = bindingSourceWarrantyCompany.Find("id", iACDataSet.VEHICLE.Rows[VehiclebindingSource.Position].Field<Int32>("WarrantyID"));
                if (bindingSourceWarrantyCompany.Position == -1)
                    bindingSourceWarrantyCompany.Position = 0; // First record id = 1 is NONE
                // Moses Newman 04/07/2022 
                cUSTOMER_DEALERcomboBox.EditValue = iACDataSet.CUSTOMER.Rows[0].Field<Int32>("CUSTOMER_DEALER");
                // Moses Newman 08/02/2013 Save CUSTOMER_BALANCE so maintenance can NOT ALTER IT even though we display the current balance only posting routines may recalculate it and write the data.
                if (iACDataSet.CUSTOMER.Rows[0].Field<Nullable<Decimal>>("CUSTOMER_BALANCE") != null && iACDataSet.CUSTOMER.Rows[0].Field<Nullable<Decimal>>("CUSTOMER_BALANCE") != 0)
                {
                    gnCustomerBalance = iACDataSet.CUSTOMER.Rows[0].Field<Decimal>("CUSTOMER_BALANCE");
                }
                else
                {
                    loLastBalance = cUSTHISTTableAdapter.LastBalance(cUSTOMER_NOTextBox.EditValue.ToString().Trim());
                    if (loLastBalance != null)
                        gnCustomerBalance = (Decimal)loLastBalance;
                    else
                        gnCustomerBalance = 0;
                }
                if (iACDataSet.CUSTOMER.Rows[0].Field<Nullable<Decimal>>("CUSTOMER_BUYOUT") != null && iACDataSet.CUSTOMER.Rows[0].Field<Nullable<Decimal>>("CUSTOMER_BUYOUT") != 0)
                {
                    gnCustomerBuyout = iACDataSet.CUSTOMER.Rows[0].Field<Decimal>("CUSTOMER_BUYOUT");
                }
                else
                    gnCustomerBuyout = gnCustomerBalance;
                if (iACDataSet.ALTNAME.Rows.Count == 0)
                    Create_New_ALTNAMERecord(cUSTOMER_NOTextBox.EditValue.ToString().Trim());
                if (iACDataSet.OPNBANK.Rows.Count == 0)
                    Create_New_OPNBANKRecord(cUSTOMER_NOTextBox.EditValue.ToString().Trim());
                if (iACDataSet.VEHICLE.Rows.Count == 0)
                    Create_New_VEHICLERecord(cUSTOMER_NOTextBox.EditValue.ToString().Trim());
                // Moses Newman 12/23/2013 Add Email Address Record
                if (iACDataSet.Email.Rows.Count == 0)
                    Create_New_EmailRecord(cUSTOMER_NOTextBox.EditValue.ToString().Trim());
                // Moses Newman 09/5/2012 set unearned interest to 0 if NULL!
                if (iACDataSet.CUSTOMER.Rows[0].Field<Nullable<Decimal>>("CUSTOMER_UE_INTEREST") == null)
                    iACDataSet.CUSTOMER.Rows[0].SetField<Decimal>("CUSTOMER_UE_INTEREST", 0);
                // Moses Newman 04/30/2017 Handle US rule simple interest now and Normal Daily Compounding as N
                if (iACDataSet.CUSTOMER.Rows[0].Field<String>("CUSTOMER_AMORTIZE_IND") == "S" || iACDataSet.CUSTOMER.Rows[0].Field<String>("CUSTOMER_AMORTIZE_IND") == "N")
                {
                    if (iACDataSet.CUSTOMER.Rows[0].Field<String>("CUSTOMER_AMORTIZE_IND") == "S")
                    {
                        checkBoxSimple.Checked = true;
                        checkBoxSimple.Visible = true;
                    }
                    else
                    {
                        checkBoxSimple.Checked = false;
                        checkBoxSimple.Visible = false;
                    }
                    barButtonItemCaculateBuyout.Enabled = true;
                    barButtonItemCaculateBuyout.Visibility = BarItemVisibility.Always;
                    String lcHighValue = "";
                    lcHighValue += (char)255;
                    // Moses Newman 04/30/2017 Handle US rule simple interest now and Normal Daily Compounding Set flag to checkbox valuye not forced true!
                    if (!lbAddFlag && iACDataSet.CUSTOMER.Rows[0].Field<String>("CUSTOMER_POST_IND") != lcHighValue)
                        iACDataSet.CUSTOMER.Rows[0].SetField<Decimal>("CUSTOMER_BALANCE", Program.TVSimpleGetBuyout(iACDataSet,
                                                   DateTime.Now.Date,
                                                   (Double)iACDataSet.CUSTOMER.Rows[0].Field<Int32>("CUSTOMER_TERM"),
                                                   (Double)(iACDataSet.CUSTOMER.Rows[0].Field<Decimal>("CUSTOMER_ANNUAL_PERCENTAGE_RATE") / 100),
                                                   (Double)iACDataSet.CUSTOMER.Rows[0].Field<Decimal>("CUSTOMER_REGULAR_AMOUNT"),
                                                   iACDataSet.CUSTOMER.Rows[0].Field<String>("CUSTOMER_NO"),
                                                   checkBoxSimple.Checked, true, false, false, -1, true));
                    if (!lbAddFlag && iACDataSet.CUSTOMER.Rows[0].Field<String>("CUSTOMER_POST_IND") != lcHighValue)
                        iACDataSet.CUSTOMER.Rows[0].SetField<Decimal>("CUSTOMER_BUYOUT", Program.TVSimpleGetBuyout(iACDataSet,
                                                    DateTime.Now.Date,
                                                    (Double)iACDataSet.CUSTOMER.Rows[0].Field<Int32>("CUSTOMER_TERM"),
                                                    (Double)(iACDataSet.CUSTOMER.Rows[0].Field<Decimal>("CUSTOMER_ANNUAL_PERCENTAGE_RATE") / 100),
                                                    (Double)iACDataSet.CUSTOMER.Rows[0].Field<Decimal>("CUSTOMER_REGULAR_AMOUNT"),
                                                    iACDataSet.CUSTOMER.Rows[0].Field<String>("CUSTOMER_NO"),
                                                    checkBoxSimple.Checked, true, true, false));
                    if (iACDataSet.CUSTOMER.Rows[0].Field<String>("CUSTOMER_BUY_OUT") == "Y")
                        if (iACDataSet.CUSTOMER.Rows[0].Field<Decimal>("CUSTOMER_BUYOUT") != 0)
                        {
                            iACDataSet.CUSTOMER.Rows[0].SetField<Decimal>("CUSTOMER_UE_INTEREST", iACDataSet.CUSTOMER.Rows[0].Field<Decimal>("CUSTOMER_BUYOUT"));
                            iACDataSet.CUSTOMER.Rows[0].SetField<Decimal>("CUSTOMER_BUYOUT", 0);
                            iACDataSet.CUSTOMER.Rows[0].SetField<Decimal>("CUSTOMER_BALANCE", 0);
                        }
                    iACDataSet.CUSTOMER.Rows[0].SetField<Decimal>("TotalDue", 0);  //Moses Newman 04/30/2022
                    // Moses Newman 03/25/2021 Use CUSTOMER_BUYOUT for TotalDue if Total Due is greater than balance.
                    if (!lbAddFlag && iACDataSet.CUSTOMER.Rows[0].Field<String>("CUSTOMER_POST_IND") != lcHighValue)
                    {
                        if (iACDataSet.CUSTOMER.Rows[0].Field<String>("CUSTOMER_ACT_STAT") == "A")
                        {
                            DateTime ldNewPaidThru;
                            TimeSpan TotDueDateDiff;
                            Int32 MonthsDiff;

                            // Moses Newman 04/30/2022
                            if (iACDataSet.CUSTOMER.Rows[0].Field<Int32>("CUSTOMER_DAY_DUE") == 30 && Convert.ToInt32(iACDataSet.CUSTOMER.Rows[0].Field<String>("CUSTOMER_PAID_THRU_MM")) == 2)
                            {
                                ldNewPaidThru = Convert.ToDateTime("02/1/" + DateTime.Now.Year.ToString().Substring(0, 2) + iACDataSet.CUSTOMER.Rows[0].Field<String>("CUSTOMER_PAID_THRU_YY"));
                                //ldNewPaidThru = ldNewPaidThru.AddDays(-1); // Force Date to proper February Date!
                            }
                            else
                                ldNewPaidThru = Convert.ToDateTime(iACDataSet.CUSTOMER.Rows[0].Field<String>("CUSTOMER_PAID_THRU_MM") + "/01/" + DateTime.Now.Year.ToString().Substring(0, 2) + iACDataSet.CUSTOMER.Rows[0].Field<String>("CUSTOMER_PAID_THRU_YY"));
                            TotDueDateDiff = DateTime.Now.Date - ldNewPaidThru;
                            MonthsDiff = (Int32)(TotDueDateDiff.Days / (365.2425 / 12));
                            iACDataSet.CUSTOMER.Rows[0].SetField<Decimal>("TotalDue",
                                MonthsDiff * iACDataSet.CUSTOMER.Rows[0].Field<Decimal>("CUSTOMER_REGULAR_AMOUNT") - iACDataSet.CUSTOMER.Rows[0].Field<Decimal>("PartialPayment") + iACDataSet.CUSTOMER.Rows[0].Field<Decimal>("CUSTOMER_LATE_CHARGE_BAL"));
                        }
                        // Moses Newman 3/29/2021-30
                        if (iACDataSet.CUSTOMER.Rows[0].Field<Decimal>("TotalDue") >= gnCustomerBalance || (iACDataSet.CUSTOMER.Rows[0].Field<Decimal>("TotalDue") < 0 && gnCustomerBalance < 0))
                            iACDataSet.CUSTOMER.Rows[0].SetField<Decimal>("TotalDue", iACDataSet.CUSTOMER.Rows[0].Field<Decimal>("CUSTOMER_BUYOUT") > 0 ?
                                iACDataSet.CUSTOMER.Rows[0].Field<Decimal>("CUSTOMER_BUYOUT") : 0);
                        // Moses Newman 03/26/2021 if total due is negative
                        if (iACDataSet.CUSTOMER.Rows[0].Field<Decimal>("TotalDue") < 0)
                            iACDataSet.CUSTOMER.Rows[0].SetField<Decimal>("TotalDue",
                                iACDataSet.CUSTOMER.Rows[0].Field<Decimal>("CUSTOMER_REGULAR_AMOUNT") +
                                iACDataSet.CUSTOMER.Rows[0].Field<Decimal>("CUSTOMER_LATE_CHARGE") +
                                (iACDataSet.CUSTOMER.Rows[0].Field<Decimal>("CUSTOMER_CONTRACT_STATUS") < 0 ?
                                Math.Abs(iACDataSet.CUSTOMER.Rows[0].Field<Decimal>("CUSTOMER_CONTRACT_STATUS")) -
                                iACDataSet.CUSTOMER.Rows[0].Field<Decimal>("CUSTOMER_LATE_CHARGE") : 0) -
                                iACDataSet.CUSTOMER.Rows[0].Field<Decimal>("PartialPayment"));
                    }
                }
                else
                {
                    checkBoxSimple.Checked = false;
                    // Moses Newman 04/30/2017 hide simple interest checkbox for old customers.
                    checkBoxSimple.Visible = false;
                    barButtonItemCaculateBuyout.Visibility = BarItemVisibility.Always;
                }
                txtPaidInterest.Text = iACDataSet.CUSTOMER.Rows[0].Field<String>("CUSTOMER_BUY_OUT") == "Y" ?
                    (iACDataSet.CUSTOMER.Rows[0].Field<Decimal>("CUSTOMER_PAID_INTEREST") -
                     iACDataSet.CUSTOMER.Rows[0].Field<Decimal>("CUSTOMER_UE_INTEREST")).ToString("C", new System.Globalization.CultureInfo("en-US")) :
                     iACDataSet.CUSTOMER.Rows[0].Field<Decimal>("CUSTOMER_PAID_INTEREST").ToString("C", new System.Globalization.CultureInfo("en-US"));
                // Moses Newman 06/12/2018 Add CustomerFees fill for new Fees tab.
                CustomerFeesTableAdapter.Fill(iACDataSet.CustomerFees, iACDataSet.CUSTOMER.Rows[0].Field<String>("CUSTOMER_NO"));
                if (iACDataSet.CustomerFees.Rows.Count < 1)  // Moses Newman 06/12/2018 Add new record if none exists in CustomerFees!
                {
                    IACDataSet.CustomerFeesRow NewCustomerFeesRow = iACDataSet.CustomerFees.NewCustomerFeesRow();
                    NewCustomerFeesRow.CustomerNo = iACDataSet.CUSTOMER.Rows[0].Field<String>("CUSTOMER_NO");
                    iACDataSet.CustomerFees.Rows.Add(NewCustomerFeesRow);
                    // Add record even if not yet in add or edit mode!
                    // Moses Newman 02/23/2019 Make sure new record has the correct CUSTOMER_NO!!!
                    iACDataSet.CustomerFees.Rows[0].SetField<String>("CustomerNo", iACDataSet.CUSTOMER.Rows[0].Field<String>("CUSTOMER_NO"));
                    CustomerFeesTableAdapter.Update(iACDataSet.CustomerFees.Rows[0]);
                }
                // Moses Newamn 06/12/2018 Calculate total fees after population globals.
                // Moses Newman 05/25/2022 Don't allow nulls
                gnRepoFees = iACDataSet.CustomerFees.Rows[0].Field<Decimal?>("Repo") != null ? iACDataSet.CustomerFees.Rows[0].Field<Decimal>("Repo") : (Decimal)0;
                gnStorageFees = iACDataSet.CustomerFees.Rows[0].Field<Decimal?>("Storage") != null ? iACDataSet.CustomerFees.Rows[0].Field<Decimal>("Storage") : (Decimal)0;
                gnImpoundFees = iACDataSet.CustomerFees.Rows[0].Field<Decimal?>("Impound") != null ? iACDataSet.CustomerFees.Rows[0].Field<Decimal>("Impound") : (Decimal)0;
                gnResaleFees = iACDataSet.CustomerFees.Rows[0].Field<Decimal?>("Resale") != null ? iACDataSet.CustomerFees.Rows[0].Field<Decimal>("Resale") : (Decimal)0;
                gnRepairFee1 = iACDataSet.CustomerFees.Rows[0].Field<Decimal?>("Repair1") != null ? iACDataSet.CustomerFees.Rows[0].Field<Decimal>("Repair1") : (Decimal)0;
                gnRepairFee2 = iACDataSet.CustomerFees.Rows[0].Field<Decimal?>("Repair2") != null ? iACDataSet.CustomerFees.Rows[0].Field<Decimal>("Repair2") : (Decimal)0;
                gnRepairFee3 = iACDataSet.CustomerFees.Rows[0].Field<Decimal?>("Repair3") != null ? iACDataSet.CustomerFees.Rows[0].Field<Decimal>("Repair3") : (Decimal)0;
                gnRepairFee4 = iACDataSet.CustomerFees.Rows[0].Field<Decimal?>("Repair4") != null ? iACDataSet.CustomerFees.Rows[0].Field<Decimal>("Repair4") : (Decimal)0;
                gnRepairFee5 = iACDataSet.CustomerFees.Rows[0].Field<Decimal?>("Repair5") != null ? iACDataSet.CustomerFees.Rows[0].Field<Decimal>("Repair5") : (Decimal)0;
                /* Moses Newman 06/13/2018 Make sure Full Recourse Checkbox on first tab is checked if IsFullRecourse!
                if(iACDataSet.CUSTOMER.Rows[0].Field<Boolean>("IsFullRecourse"))
                {
                    checkBoxFullRecourseTab1.Checked = false;
                    checkBoxFullRecourseTab1.Checked = true;
                }*/
                if (lbEdit)
                {
                    if (textBoxDealerEmail.Text.Trim() != "")
                    {
                        checkBoxSendToDealer.Visible = true;
                        checkBoxSendToDealer.Enabled = false;
                    }
                    else
                    {
                        checkBoxSendToDealer.Enabled = false;
                        checkBoxSendToDealer.Visible = false;
                    }
                }
                checkBoxSendToDealer.Refresh();
            }
            else
                return;

            cUSTOMERBindingSource.MoveFirst();
            cUSTOMERBindingSource.EndEdit();
            // Moses Newman 04/26/2012 Handle refresh of Dealer Name after cancel from edit!
            // Moses Newman 03/20/2022 Now use id instead of DEALER_ACC_NO
            DealerListCustbindingSource.Position = DealerListCustbindingSource.Find("id", iACDataSet.CUSTOMER.Rows[0].Field<Int32>("CUSTOMER_DEALER"));

            // Moses Newman 03/01/2012 Create new opnbank record if none!
            if (iACDataSet.OPNBANK.Rows.Count == 0)
                Create_New_OPNBANKRecord(cUSTOMER_NOTextBox.EditValue.ToString().Trim());
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

            int lnRowCount = iACDataSet.COMMENT.Rows.Count;
            if (lnRowCount > 0)
                labelCustHasComments.Visible = true;
            else
                labelCustHasComments.Visible = false;

            // Moses Newman 12/23/2013 Add Customer's Vehicle Has Been Repo'd message if it has
            if (iACDataSet.CUSTOMER.Rows[0].Field<String>("CUSTOMER_REPO_IND") != "N")
                labelCustinRepo.Visible = true;
            else
                labelCustinRepo.Visible = false;

            // Moses Newman 08/06/2014 Add Insurance Has Expired message if insurance has expired
            labelInsuranceExpired.Visible = false;
            if (iACDataSet.VEHICLE.Rows[0].Field<Nullable<DateTime>>("VEHICLE_EXP_DATE") != null)
                if (iACDataSet.VEHICLE.Rows[0].Field<Nullable<DateTime>>("VEHICLE_EXP_DATE") < DateTime.Now.Date)
                    labelInsuranceExpired.Visible = true;

            if (iACDataSet.CUSTOMER.Rows.Count > 0)
            {
                // Moses Newman 11/29/2014 No longer need to calculate partial payment for display, added whole number partial payment field!
                lControl_Month = iACDataSet.CUSTOMER.Rows[0].Field<Int32>("CUSTOMER_CONTROL_MONTH").ToString().PadLeft(2, '0');
                lControl_Year = iACDataSet.CUSTOMER.Rows[0].Field<Int32>("CUSTOMER_CONTROL_YEAR").ToString().PadLeft(2, '0');
                lControlDate = lControl_Month.TrimEnd() + '/' + lControl_Year.TrimEnd();
                txtControlDate.Text = lControlDate;
                lPaidInterest = Convert.ToDouble(iACDataSet.CUSTOMER.Rows[0].Field<Nullable<Decimal>>("CUSTOMER_LOAN_INTEREST") - iACDataSet.CUSTOMER.Rows[0].Field<Nullable<Decimal>>("CUSTOMER_UE_INTEREST"));
                //txtPaidInterest.Text = String.Format("{0:0.00}", lPaidInterest);
                //txtPaidInterest.Text = lPaidInterest.ToString("C",new System.Globalization.CultureInfo("en-US"));

                // Moses Newman 12/19/2013 No longer have CUSTOMER_LETTER_NN FIELDS in CUSTOMER FILES so no defaulting letter dropdowns.
                //comboBoxLetterNo.SelectedIndex = 0;
                //comboBoxLetterType.SelectedIndex = 0;
                // Moses Newman 09/12/2017 Handle a user who texted STOP!
                try
                {
                    if (iACDataSet.CUSTOMER.Rows[0].Field<Boolean>("TConfirmed"))
                    {
                        if (GetSubscriberStatus(iACDataSet.CUSTOMER.Rows[0].Field<String>("CUSTOMER_CELL_PHONE")) == "Inactive")
                        {
                            if (!lbEdit && !lbAddFlag)
                                cUSTOMERTableAdapter.ResetSBT(iACDataSet.CUSTOMER.Rows[0].Field<String>("CUSTOMER_NO"), false);
                            iACDataSet.CUSTOMER.Rows[0].SetField<Boolean>("TAcct", false);
                            radioButtonAcct.Checked = false;
                            iACDataSet.CUSTOMER.Rows[0].SetField<String>("TPin", "");
                            buttonConfirm.ForeColor = Color.Crimson;
                            iACDataSet.CUSTOMER.Rows[0].SetField<Boolean>("TConfirmed", false);
                            iACDataSet.CUSTOMER.Rows[0].SetField<Boolean>("DNTAcct", true);
                            iACDataSet.CUSTOMER.Rows[0].EndEdit();
                            MakeComment("CUSTOMER UNSUBSCRIBED SBT BY TEXTING STOP.", "", 0, false);
                        }
                    }
                }
                catch (System.ServiceModel.ServerTooBusyException e)
                {
                    MessageBox.Show(e.Message);
                }

                buttonValidate.ForeColor = iACDataSet.CUSTOMER.Rows[0].Field<Boolean>("CellValid") ? Color.Green : Color.Crimson;
                buttonConfirm.ForeColor = iACDataSet.CUSTOMER.Rows[0].Field<Boolean>("TConfirmed") ? Color.Green : Color.Crimson;
                buttonMessage.Enabled = iACDataSet.CUSTOMER.Rows[0].Field<Boolean>("TConfirmed");
                // Moses Newman 09/13/2017 Store the orginal value of the phone number to test for changes!
                cUSTOMER_CELL_PHONETextBox.Tag = cUSTOMER_CELL_PHONETextBox.Text;

                try
                {
                    // Moses Newman 09/18/2021 Handle a cosigner who texted STOP!
                    if (iACDataSet.CUSTOMER.Rows[0].Field<Boolean>("COSTConfirmed"))
                    {
                        if (GetSubscriberStatus(iACDataSet.CUSTOMER.Rows[0].Field<String>("COSIGNER_CELL_PHONE")) == "Inactive")
                        {
                            if (!lbEdit && !lbAddFlag)
                                cUSTOMERTableAdapter.ResetSBT(iACDataSet.CUSTOMER.Rows[0].Field<String>("CUSTOMER_NO"), true);
                            iACDataSet.CUSTOMER.Rows[0].SetField<Boolean>("COSTAcct", false);
                            radioButtonCOSAcct.Checked = false;
                            iACDataSet.CUSTOMER.Rows[0].SetField<String>("COSTPin", "");
                            buttonCOSConfirm.ForeColor = Color.Crimson;
                            iACDataSet.CUSTOMER.Rows[0].SetField<Boolean>("COSTConfirmed", false);
                            iACDataSet.CUSTOMER.Rows[0].SetField<Boolean>("COSDNTAcct", true);
                            iACDataSet.CUSTOMER.Rows[0].EndEdit();
                            MakeComment("COSIGNER UNSUBSCRIBED SBT BY TEXTING STOP.", "", 0, false);
                        }
                    }
                }
                catch (System.ServiceModel.ServerTooBusyException e)
                {
                    MessageBox.Show(e.Message);
                }
                buttonCOSValidate.ForeColor = iACDataSet.CUSTOMER.Rows[0].Field<Boolean>("COSCellValid") ? Color.Green : Color.Crimson;
                buttonCOSConfirm.ForeColor = iACDataSet.CUSTOMER.Rows[0].Field<Boolean>("COSTConfirmed") ? Color.Green : Color.Crimson;
                buttonCOSMessage.Enabled = iACDataSet.CUSTOMER.Rows[0].Field<Boolean>("COSTConfirmed");
                // Moses Newman 09/18/2021 Store the orginal value of the phone number to test for changes!
                txtCOSCell.Tag = txtCOSCell.Text;
            }
            if (checkEditMilitary.Checked)
            {
                checkEditMilitary.Enabled = true;
                checkEditMilitary.Font = new System.Drawing.Font(checkEditMilitary.Font, FontStyle.Bold);
                checkEditMilitary.ForeColor = Color.Red;
            }
            else
            {
                checkEditMilitary.Enabled = false;
                checkEditMilitary.Font = new System.Drawing.Font(checkEditMilitary.Font, FontStyle.Regular);
                checkEditMilitary.ForeColor = SystemColors.ControlText;
            }
            cOMMENTGridControl.Refresh();
        }

        private void General_KeyPress(object sender, KeyPressEventArgs e)
        {
            if ((!lbAddFlag && !lbEdit) && ActiveControl == textBoxOpenAccount)
                e.Handled = true;
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

        //Move to FirstPayDate
        private void textBox46_Validated(object sender, EventArgs e)
        {
            xtraTabControlCustomerMaint.SelectedTabPageIndex = 1;
            ActiveControl = txtFirstPayDate;
            txtFirstPayDate.Select();
        }

        //Move to Vevhicle Year
        private void textBox45_Validated(object sender, EventArgs e)
        {
            xtraTabControlCustomerMaint.SelectedTabPageIndex = 2;
            ActiveControl = txtVehicleYear;
            txtVehicleYear.Select();
        }

        private void LockCustomerRecord(bool byPO = false)
        {
            // Moses Newman 8/8/2013 Return if No Customer Selected
            if (iACDataSet.CUSTOMER.Rows.Count == 0)
                return;
            Object loLockedBy = cUSTOMERTableAdapter.LockedBy(cUSTOMER_NOTextBox.EditValue.ToString().Trim()),
                   loLockedTime = cUSTOMERTableAdapter.LockTime(cUSTOMER_NOTextBox.EditValue.ToString().Trim());

            if (loLockedBy != null && ((String)loLockedBy).TrimEnd() != "")
            {
                IACDataSetTableAdapters.ULISTTableAdapter ULISTTableAdapter = new IACDataSetTableAdapters.ULISTTableAdapter();
                ULISTTableAdapter.FillById(iACDataSet.ULIST, Program.gsUserID);
                MessageBox.Show("*** CUSTOMER: " + cUSTOMER_NOTextBox.EditValue.ToString().Trim() + " WAS LOCKED BY USER: " +
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
                cUSTOMERTableAdapter.LockRecord(Program.gsUserID, iACDataSet.CUSTOMER.Rows[0].Field<String>("CUSTOMER_NO"));
                lbILockedIt = true;   //  Make sure other instances of form don't unlocke this record!
                if (iACDataSet.ALTNAME.Rows.Count == 0)
                    Create_New_ALTNAMERecord(cUSTOMER_NOTextBox.EditValue.ToString().TrimEnd());
                if (iACDataSet.OPNBANK.Rows.Count == 0)
                    Create_New_OPNBANKRecord(cUSTOMER_NOTextBox.EditValue.ToString().TrimEnd());
                if (iACDataSet.VEHICLE.Rows.Count == 0)
                    Create_New_VEHICLERecord(cUSTOMER_NOTextBox.EditValue.ToString().TrimEnd());
            }
        }

        // Moses Newman 12/23/2013 Add Email Address Record
        private void Create_New_EmailRecord(String tsCustomerNo)
        {
            EmailbindingSource.AddNew();
            EmailbindingSource.EndEdit();
            iACDataSet.Email.Rows[EmailbindingSource.Position].SetField<String>("CustomerNo", tsCustomerNo);
        }

        private void Create_New_ALTNAMERecord(String lsCustomerNo)
        {
            ALTNAMEbindingSource.AddNew();
            ALTNAMEbindingSource.EndEdit();

            // ALTNAME
            iACDataSet.ALTNAME.Rows[ALTNAMEbindingSource.Position].SetField<String>("ALTNAME_NO", lsCustomerNo);
            iACDataSet.ALTNAME.Rows[ALTNAMEbindingSource.Position].SetField<String>("ALTNAME_ADD_ON", "");
            iACDataSet.ALTNAME.Rows[ALTNAMEbindingSource.Position].SetField<String>("ALTNAME_TYPE", "C");
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
            iACDataSet.OPNBANK.Rows[OPNBANKbindingSource.Position].SetField<String>("OPNBANK_TYPE", "C");
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
            iACDataSet.CUSTOMER.Rows[cUSTOMERBindingSource.Position].Field<Decimal>("CUSTOMER_REGULAR_AMOUNT"));
        }

        private void Create_New_VEHICLERecord(String lsCustomerNo)
        {
            //VEHICLE
            VehiclebindingSource.AddNew();
            VehiclebindingSource.EndEdit();
            iACDataSet.VEHICLE.Rows[VehiclebindingSource.Position].SetField<String>("VEHICLE_CUST_NO", lsCustomerNo);
            iACDataSet.VEHICLE.Rows[VehiclebindingSource.Position].SetField<String>("VEHICLE_MAKE", "");
            iACDataSet.VEHICLE.Rows[VehiclebindingSource.Position].SetField<String>("VEHICLE_MODEL", "");
            iACDataSet.VEHICLE.Rows[VehiclebindingSource.Position].SetField<String>("VEHICLE_VIN", "");
            iACDataSet.VEHICLE.Rows[VehiclebindingSource.Position].SetField<String>("VEHICLE_INS_COMPANY", "");
            iACDataSet.VEHICLE.Rows[VehiclebindingSource.Position].SetField<String>("VEHICLE_POLICY_NO", "");
            iACDataSet.VEHICLE.Rows[VehiclebindingSource.Position].SetField<Nullable<DateTime>>("VEHICLE_EFF_DATE", null);
            iACDataSet.VEHICLE.Rows[VehiclebindingSource.Position].SetField<Nullable<DateTime>>("VEHICLE_EXP_DATE", null);
            iACDataSet.VEHICLE.Rows[VehiclebindingSource.Position].SetField<String>("VEHICLE_JOINT_OWNER", "N");
            iACDataSet.VEHICLE.Rows[VehiclebindingSource.Position].SetField<String>("VEHICLE_JOINT_NAME", "");
            iACDataSet.VEHICLE.Rows[VehiclebindingSource.Position].SetField<String>("VEHICLE_INSUR_AGENT", "");
            iACDataSet.VEHICLE.Rows[VehiclebindingSource.Position].SetField<String>("VEHICLE_AGENT_PHONE", "");
        }

        // Moses Newman 01/29/2019 Call this from now on instead of back tracking to Regular Payments validation!
        private void Reamortize()
        {
            Double lnRegularPay = 0, lnTotal = 0, lnTerm = 0, lnLoanInterest = 0, lnCash = 0;
            Double lnAPR = 0;
            if (txtTerm.Text == "")
                return;
            if (txtAPR.Text == "" && txtCASH.Text == "")
                return;
            if (txtAPR.Text != "")
                lnAPR = Convert.ToDouble(txtAPR.Text.ToString()) / 100;
            else
                lnAPR = 0;
            lnTerm = Convert.ToDouble(txtTerm.Text.ToString());
            lnCash = Convert.ToDouble(txtCASH.Text.Substring(1));
            if (txtRegularPay.Text.ToString().IndexOf("$") >= 0)
                lnRegularPay = Convert.ToDouble(txtRegularPay.Text.Substring(1));
            else
                lnRegularPay = Convert.ToDouble(txtRegularPay.Text.ToString());
            AmortTable = null;
            AmortTable = new Program.AmortRec[Convert.ToInt32(lnTerm)];

            if (lnTerm == 0)
                return;
            if (lnAPR == 0 && lnRegularPay == 0)
                return;
            if (lnCash == 0)
                return;
            String lsErrorMessage = "DAmort Table Created!";
            // Moses Newman 01/21/2015 Handle Contract Date!
            DateTime ldStartDate = iACDataSet.CUSTOMER.Rows[0].Field<DateTime>("ContractDate"),
                     ldFirstPaymentDate = iACDataSet.CUSTOMER.Rows[0].Field<DateTime>("CUSTOMER_INIT_DATE");
            // Moses Newman 09/12/2013 ALL use simple routines now
            // Moses Newman 01/21/2015 Handle Contract Date!
            if (ldStartDate >= ldFirstPaymentDate)
            {
                MessageBox.Show("*** Contract Date must be earlier than the first payment date! ***", "Bad Dates!", MessageBoxButtons.OK);
                return;
            }

            // Moses Newman 08/23/2021
            Program.TVAmortize(ldStartDate, ldFirstPaymentDate, ref lnCash, ref lnTerm, ref lnAPR, ref lnRegularPay, ref lsErrorMessage, ref AmortTable, false, cUSTOMER_NOTextBox.EditValue.ToString().Trim(), true);
            if (lnRegularPay != 0 && lnTerm != 0)
            {
                lnTotal = lnRegularPay * lnTerm;
                TVAPRInfoTableAdapter.Fill(iACDataSet.TVAPRInfo, cUSTOMER_NOTextBox.EditValue.ToString().Trim());
                if (iACDataSet.TVAPRInfo.Rows.Count > 0)
                {
                    lnCash = (Double)iACDataSet.TVAPRInfo.Rows[0].Field<Decimal>("AmountFinanced");
                    lnLoanInterest = (Double)iACDataSet.TVAPRInfo.Rows[0].Field<Decimal>("FinanceCharge");
                    lnTotal = (Double)iACDataSet.TVAPRInfo.Rows[0].Field<Decimal>("TotalofPayments");
                }
                else
                    lnLoanInterest = lnTotal - lnCash;
                //if (checkBoxSimple.Checked) Moses Newman 04/30/2017 ALL loans dont include interest in total now.
                lnTotal = lnCash;        // Loan Interest NOT included in total on Simple Interest Loan!
            }
            // Moses Newman 03/25/2014 change direct field fills to table fills instead!
            lnAPR *= 100;
            //txtLoan.Text = lnCash.ToString("C", new System.Globalization.CultureInfo("en-US"));
            // Moses Newman 03/27/2013 Can NOT update binding source of current field during it's own validation event!
            //txtAPR.Text = lnAPR.ToString("F4", new System.Globalization.CultureInfo("en-US"));
            //txtLoanInterest.Text = lnLoanInterest.ToString("C", new System.Globalization.CultureInfo("en-US"));
            //txtRegularPay.Text = lnRegularPay.ToString("C", new System.Globalization.CultureInfo("en-US"));
            if (lbEdit || lbAddFlag)
                toolStripButtonSave.Enabled = true;
            //errorProviderCustomerForm.Clear();
            // Moses Newman 10/24/2013 if OPNBANK_MONTHLY_PAYMENT == 0 THEN COPY CUSTOMER_REGULAR_PAYMENT.
            if (iACDataSet.OPNBANK.Rows[OPNBANKbindingSource.Position].Field<Decimal>("OPNBANK_MONTHLY_PAYMENT") == 0)
                iACDataSet.OPNBANK.Rows[OPNBANKbindingSource.Position].SetField<Decimal>("OPNBANK_MONTHLY_PAYMENT", (Decimal)lnRegularPay);
            cUSTOMERBindingSource.SuspendBinding();
            iACDataSet.CUSTOMER.Rows[0].SetField<Decimal>("CUSTOMER_LOAN_INTEREST", (Decimal)lnLoanInterest);
            iACDataSet.CUSTOMER.Rows[0].SetField<Decimal>("CUSTOMER_ANNUAL_PERCENTAGE_RATE", (Decimal)lnAPR);
            iACDataSet.CUSTOMER.Rows[0].SetField<Decimal>("CUSTOMER_LOAN_CASH", (Decimal)lnCash);
            iACDataSet.CUSTOMER.Rows[0].SetField<Decimal>("CUSTOMER_LOAN_AMOUNT", (Decimal)lnCash);
            iACDataSet.CUSTOMER.Rows[0].SetField<Decimal>("CUSTOMER_REGULAR_AMOUNT", (Decimal)lnRegularPay);
            cUSTOMERBindingSource.EndEdit();
            cUSTOMERBindingSource.ResumeBinding();
        }

        private void txtRegularPay_Validated(object sender, EventArgs e)
        {
            errorProviderCustomerForm.Clear();
            // Moses Newman 01/29/2019 Now call one routine instead of al the back references here from other fields like term!
            Reamortize();
        }

        private void cUSTOMER_STATETextBox_Validated(object sender, EventArgs e)
        {
            IACDataSetTableAdapters.STATEREBTableAdapter STATEREBTableAdapter = new IACDataSetTableAdapters.STATEREBTableAdapter();

            STATEREBTableAdapter.Fill(iACDataSet.STATEREB, cUSTOMER_STATETextBox.Text.ToString());

            if (iACDataSet.STATEREB.Rows.Count > 0)
            {
                txtRebateCode.Text = iACDataSet.STATEREB.Rows[0].Field<String>("REBATE_CODE");
                iACDataSet.CUSTOMER.Rows[0].SetField<String>("CUSTOMER_REBATE_CODE", iACDataSet.STATEREB.Rows[0].Field<String>("REBATE_CODE"));
                txtRebateCode.Refresh();
            }
            if (cUSTOMER_STATETextBox.Text.Length != 0)
                errorProviderCustomerForm.Clear();
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

        private void toolStripButton2_Click(object sender, EventArgs e)
        {
            MDIIAC2013 MDImain = (MDIIAC2013)MdiParent;
            MDImain.CreateFormInstance("FormReciept", false, false, true);
            FormReciept receipt = (FormReciept)MDImain.frm;

            receipt.gsCustomerNo = cUSTOMER_NOTextBox.EditValue.ToString().Trim();
            receipt.gsOpenClose = "C";
            receipt.Show();
        }

        private void buttonLetter_Click(object sender, EventArgs e)
        {
            Int32 lnSeq = 0;
            object loQuery = null;
            String lsCommentKey = "", lsFullComment = "";
            IACDataSetTableAdapters.CUSTOMERTableAdapter CustomerTableAdapter = new IACDataSetTableAdapters.CUSTOMERTableAdapter();
            IACDataSetTableAdapters.COMMENTTableAdapter COMMENTTableAdapter = new IACDataSetTableAdapters.COMMENTTableAdapter();

            String lsLetterNo = comboBoxLetterNo.Text.TrimEnd(), lsLetterType = comboBoxLetterType.Text.TrimEnd().ToUpper();
            if (lsLetterNo == "")  // Moses Newman 12/24/2019 don't do anything if no letter selected!
                return;
            if (iACDataSet.CUSTOMER.Rows.Count == 0)
            {
                return;
            }

            cOMMENTBindingSource.AddNew();
            cOMMENTBindingSource.EndEdit();
            if (lnSeq == 0)
            {
                loQuery = cOMMENTTableAdapter.SeqNoQuery(cUSTOMER_NOTextBox.EditValue.ToString().Trim(), DateTime.Now.Date);
                if (loQuery != null)
                    lnSeq = (int)loQuery + 1;
                else
                    lnSeq = 1;
            }
            else
                lnSeq = lnSeq + 1;

            // Moses Newman 10/18/2017 create string unique key that will become word filename!
            lsCommentKey = cUSTOMER_NOTextBox.EditValue.ToString().Trim() + DateTime.Now.Date.ToString("yyyyMMdd") + lnSeq.ToString().Trim() + Program.gsUserID;
            MailMergeComponents MailMerge = new MailMergeComponents();
            lsDataPath = lsUNCROOT.Trim() + @"CommentAttachments\Letters\";
            // Moses Newman 11/21/2017 Remove hard coded UNC Pathing
            MailMerge.CreateMailMerge(iACDataSet, true, @"AUTOLETTER#" + lsLetterNo, lsLetterType, false, "", lsDataPath + lsCommentKey + ".docx");
            // Moses Newman 02/22/2019 Add Full Comment
            lsFullComment = "Created and sent Letter#" + comboBoxLetterNo.Text.TrimEnd().TrimStart() + ".";
            // Moses Newman 11/21/2017 Remove hard coded UNC Pathing
            cOMMENTTableAdapter.Insert(cUSTOMER_NOTextBox.EditValue.ToString().Trim(), DateTime.Now.Date, lnSeq, Program.gsUserID,
                                       lsFullComment,
                                       //"Created and sent Letter#" + comboBoxLetterNo.Text.TrimEnd().TrimStart() + ".",
                                       //" ", " ",
                                       "  ", (Int32)cUSTOMER_DEALERcomboBox.EditValue,
                                       Program.gsUserID + "  ",
                                       DateTime.Now.Hour.ToString().PadLeft(2, '0') + DateTime.Now.Minute.ToString().PadLeft(2, '0') + DateTime.Now.Second.ToString().PadLeft(2, '0'),
                                       false, @"WordDoc.bmp", lsDataPath + lsCommentKey + ".docx",
                                       Convert.ToInt32(comboBoxLetterNo.Text.TrimEnd().TrimStart()), "", "", 0);
            cOMMENTTableAdapter.FillByCustNo(iACDataSet.COMMENT, cUSTOMER_NOTextBox.EditValue.ToString().Trim());
            // Moses Newman 12/23/2019 Send the mailmerge to dealer email if Copy To Dealer selected.
            if (checkBoxSendToDealer.Checked && textBoxDealerEmail.Text.Trim() != "")
            {
                cOMMENTBindingSource.AddNew();
                cOMMENTBindingSource.EndEdit();
                if (lnSeq == 0)
                {
                    loQuery = cOMMENTTableAdapter.SeqNoQuery(cUSTOMER_NOTextBox.EditValue.ToString().Trim(), DateTime.Now.Date);
                    if (loQuery != null)
                        lnSeq = (int)loQuery + 1;
                    else
                        lnSeq = 1;
                }
                else
                    lnSeq = lnSeq + 1;

                // Moses Newman 10/18/2017 create string unique key that will become word filename!
                lsCommentKey = cUSTOMER_NOTextBox.EditValue.ToString().Trim() + DateTime.Now.Date.ToString("yyyyMMdd") + lnSeq.ToString().Trim() + cUSTOMER_DEALERcomboBox.EditValue.ToString().Trim() + Program.gsUserID;
                // Moses Newman 11/21/2017 Remove hard coded UNC Pathing
                MailMergeComponents DealerMailMerge = new MailMergeComponents();
                DealerMailMerge.CreateMailMerge(iACDataSet, true, @"AUTOLETTER#" + lsLetterNo, lsLetterType, true, textBoxDealerEmail.Text.Trim(), lsDataPath + lsCommentKey + ".docx");
                // Moses Newman 02/22/2019 Add Full Comment
                lsFullComment = "Created and sent dealer Letter#" + comboBoxLetterNo.Text.TrimEnd().TrimStart() + ".";
                // Moses Newman 11/21/2017 Remove hard coded UNC Pathing
                cOMMENTTableAdapter.Insert(cUSTOMER_NOTextBox.EditValue.ToString().Trim(), DateTime.Now.Date, lnSeq, Program.gsUserID,
                                           lsFullComment,
                                           //"Created and sent Letter#" + comboBoxLetterNo.Text.TrimEnd().TrimStart() + ".",
                                           //" ", " ",
                                           "  ", (Int32)cUSTOMER_DEALERcomboBox.EditValue,
                                           Program.gsUserID + "  ",
                                           DateTime.Now.Hour.ToString().PadLeft(2, '0') + DateTime.Now.Minute.ToString().PadLeft(2, '0') + DateTime.Now.Second.ToString().PadLeft(2, '0'),
                                           false, @"WordDoc.bmp", lsDataPath + lsCommentKey + ".docx",
                                           Convert.ToInt32(comboBoxLetterNo.Text.TrimEnd().TrimStart()), "", "", 0);
                cOMMENTTableAdapter.FillByCustNo(iACDataSet.COMMENT, cUSTOMER_NOTextBox.EditValue.ToString().Trim());
            }
            comboBoxLetterNo.Text = " ";
            comboBoxLetterType.Text = " ";
        }

        private void cUSTOMER_PURCHASE_ORDERTextBox_TextChanged(object sender, EventArgs e)
        {
            if (lbEdit || lbAddFlag)
                if (toolStripButtonSave.Enabled != true)
                    toolStripButtonSave.Enabled = true;
        }

        private void cUSTOMER_PURCHASE_ORDERTextBox_Enter(object sender, EventArgs e)
        {
            cUSTOMER_PURCHASE_ORDERTextBox.Focus();
            cUSTOMER_PURCHASE_ORDERTextBox.SelectAll();
            cUSTOMER_PURCHASE_ORDERTextBox.Cursor = Cursors.IBeam;
            Cursor.Show();
        }

        private void GeneralValidationError(String error, Control Ctrl)
        {
            errorProviderCustomerForm.SetError(Ctrl, error);
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

        private void cUSTOMER_ACT_STATTextBox_TextChanged(object sender, EventArgs e)
        {
            if (lbEdit)
                toolStripButtonSave.Enabled = true;
        }

        private void checkEditUsePrimaryAddress_Validated(object sender, EventArgs e)
        {
            // Moses Newman 05/03/2012 Must copy main address if this box is Y!
            if (checkEditUsePrimaryAddress.Text.TrimEnd().ToUpper() == "Y")
            {
                iACDataSet.CUSTOMER.Rows[cUSTOMERBindingSource.Position].SetField<String>("COSIGNER_ADDRESS1", iACDataSet.CUSTOMER.Rows[cUSTOMERBindingSource.Position].Field<String>("CUSTOMER_STREET_1"));
                iACDataSet.CUSTOMER.Rows[cUSTOMERBindingSource.Position].SetField<String>("COSIGNER_CITY", iACDataSet.CUSTOMER.Rows[cUSTOMERBindingSource.Position].Field<String>("CUSTOMER_CITY"));
                iACDataSet.CUSTOMER.Rows[cUSTOMERBindingSource.Position].SetField<String>("COSIGNER_STATE", iACDataSet.CUSTOMER.Rows[cUSTOMERBindingSource.Position].Field<String>("CUSTOMER_STATE"));
                iACDataSet.CUSTOMER.Rows[cUSTOMERBindingSource.Position].SetField<String>("COSIGNER_ZIP_CODE",
                    iACDataSet.CUSTOMER.Rows[cUSTOMERBindingSource.Position].Field<String>("CUSTOMER_ZIP_1") +
                    iACDataSet.CUSTOMER.Rows[cUSTOMERBindingSource.Position].Field<String>("CUSTOMER_ZIP_2"));
                cUSTOMERBindingSource.EndEdit();
            }
        }

        private void frmCustMaint_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (iACDataSet.CUSTOMER.Rows.Count == 0)
                return;
            Object loLockedBy = null;

            loLockedBy = cUSTOMERTableAdapter.LockedBy(iACDataSet.CUSTOMER.Rows[0].Field<String>("CUSTOMER_NO"));
            if (loLockedBy != null)
            {
                if ((String)loLockedBy == Program.gsUserID && lbILockedIt)
                    cUSTOMERTableAdapter.UnlockRecord(iACDataSet.CUSTOMER.Rows[0].Field<String>("CUSTOMER_NO"));
            }
            iACDataSet.Clear();     // Moses Newman 09/04/2021  
            iACDataSet.Dispose();   // Moses Newman 09/04/2021 
        }

        private void cUSTOMER_SS_1TextBox_TextChanged(object sender, EventArgs e)
        {
            if (!lbEdit && !lbAddFlag)
                return;
            if (toolStripButtonSave.Enabled == false)
                toolStripButtonSave.Enabled = true;
            if (cUSTOMER_SS_1TextBox.Text.Length == 3)
                System.Windows.Forms.SendKeys.Send("{TAB}");
        }

        private void cUSTOMER_SS_2TextBox_TextChanged(object sender, EventArgs e)
        {
            if (!lbEdit && !lbAddFlag)
                return;
            if (toolStripButtonSave.Enabled == false)
                toolStripButtonSave.Enabled = true;
            if (cUSTOMER_SS_2TextBox.Text.Length == 2)
                System.Windows.Forms.SendKeys.Send("{TAB}");
        }

        private void cUSTOMER_SS_3TextBox_TextChanged(object sender, EventArgs e)
        {

            if (!lbEdit && !lbAddFlag)
                return;
            if (toolStripButtonSave.Enabled == false)
                toolStripButtonSave.Enabled = true;
            if (cUSTOMER_SS_3TextBox.Text.Length == 4)
                System.Windows.Forms.SendKeys.Send("{TAB}");
        }

        private void txtCOSSS_1_TextChanged(object sender, EventArgs e)
        {
            if (!lbEdit && !lbAddFlag)
                return;
            if (toolStripButtonSave.Enabled == false)
                toolStripButtonSave.Enabled = true;
            if (txtCOSSS_1.Text.Length == 3)
                System.Windows.Forms.SendKeys.Send("{TAB}");
        }

        private void txtCOSSS_2_TextChanged(object sender, EventArgs e)
        {
            if (!lbEdit && !lbAddFlag)
                return;
            if (toolStripButtonSave.Enabled == false)
                toolStripButtonSave.Enabled = true;
            if (txtCOSSS_2.Text.Length == 2)
                System.Windows.Forms.SendKeys.Send("{TAB}");
        }

        private void txtCOSSS_3_TextChanged(object sender, EventArgs e)
        {
            if (!lbEdit && !lbAddFlag)
                return;
            if (toolStripButtonSave.Enabled == false)
                toolStripButtonSave.Enabled = true;
            if (txtCOSSS_3.Text.Length == 4)
                System.Windows.Forms.SendKeys.Send("{TAB}");
        }

        private void cUSTOMER_PHONE_NOTextBox_TextChanged(object sender, EventArgs e)
        {
            if (lbEdit && toolStripButtonSave.Enabled == false)
                toolStripButtonSave.Enabled = true;
        }

        private void cUSTOMER_PHONE_EXTtextBox_TextChanged(object sender, EventArgs e)
        {
            if (lbEdit && toolStripButtonSave.Enabled == false)
                toolStripButtonSave.Enabled = true;
        }

        private void cUSTOMER_WORK_PHONETextBox_MaskInputRejected(object sender, MaskInputRejectedEventArgs e)
        {
            if (lbEdit && toolStripButtonSave.Enabled == false)
                toolStripButtonSave.Enabled = true;
        }

        private void cUSTOMER_WORK_EXTtextBox_TextChanged(object sender, EventArgs e)
        {
            if (lbEdit && toolStripButtonSave.Enabled == false)
                toolStripButtonSave.Enabled = true;
        }

        private void cUSTOMER_CELL_PHONETextBox_MaskInputRejected(object sender, MaskInputRejectedEventArgs e)
        {
            if (lbEdit && toolStripButtonSave.Enabled == false)
                toolStripButtonSave.Enabled = true;
        }

        private void txtDOB_ValueChanged(object sender, EventArgs e)
        {
            if (lbEdit && toolStripButtonSave.Enabled == false)
                toolStripButtonSave.Enabled = true;
        }

        private void cUSTOMER_COS_PHONETextBox_Validated(object sender, EventArgs e)
        {
        }

        private void comboBoxCreditCode_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void comboBoxRepoCodes_SelectedIndexChanged(object sender, EventArgs e)
        {
            if ((lbAddFlag || lbEdit) && comboBoxRepoCodes.SelectedIndex > -1)
            {
                cUSTOMER_REPO_CDEtextBox.Text = iACDataSet.RepoCodes.Rows[comboBoxRepoCodes.SelectedIndex].Field<String>("Code");
                iACDataSet.CUSTOMER.Rows[cUSTOMERBindingSource.Position].SetField<String>("CUSTOMER_REPO_CDE", iACDataSet.RepoCodes.Rows[comboBoxRepoCodes.SelectedIndex].Field<String>("Code"));
                toolStripButtonSave.Enabled = true;
                repoCodesBindingSource.EndEdit();
            }
        }

        private void cUSTOMER_REPO_INDtextBox_TextChanged(object sender, EventArgs e)
        {
            if (lbEdit || lbAddFlag)
            {
                // Moses Newman 04/13/2017 Handle new IND Code P.
                // Moses Newman 11/22/2016 Handle new IND code R.
                // Moses Newman 12/9/2013 Add dropdown for Repo codes
                // Moses Newman 06/12/2018 Add Z.
                if (cUSTOMER_REPO_INDtextBox.Text == "Y" || cUSTOMER_REPO_INDtextBox.Text == "P" || cUSTOMER_REPO_INDtextBox.Text == "R" || cUSTOMER_REPO_INDtextBox.Text == "I" || cUSTOMER_REPO_INDtextBox.Text == "Z")
                    comboBoxRepoCodes.Enabled = true;
                else
                {
                    // Moses Newman 04/07/2014 deault repo code dropdown to empty
                    comboBoxRepoCodes.SelectedIndex = -1;
                    comboBoxRepoCodes.Enabled = false;
                }
                toolStripButtonSave.Enabled = true;
            }
        }

        private void richTextBoxEmailAddress_Validating(object sender, CancelEventArgs e)
        {
            // Moses Newman 12/19/2019 switch to new generic Email validator.
            //string errorMsg;
            Program.EmailValidator(ref sender, ref e, ref this.errorProviderCustomerForm);
            if (e.Cancel)
            {
                ((TextBox)sender).Select(0, ((TextBox)sender).Text.Length);
            }
            /*
            if (!ValidEmailAddress(richTextBoxEmailAddress.Text, out errorMsg))
            {
                // Cancel the event and select the text to be corrected by the user.
                e.Cancel = true;
                textBox1.Select(0, richTextBoxEmailAddress.Text.Length);

                // Set the ErrorProvider error with the text to display.  
                this.errorProviderCustomerForm.SetError(richTextBoxEmailAddress, errorMsg);
            }*/
        }

        public bool ValidEmailAddress(string emailAddress, out string errorMessage)
        {
            // Do not require an email address
            if (emailAddress.Length == 0)
            {
                errorMessage = "";
                return true;
            }

            // Confirm that there is an "@" and a "." in the e-mail address, and in the correct order.
            if (emailAddress.IndexOf("@") > -1)
            {
                if (emailAddress.IndexOf(".", emailAddress.IndexOf("@")) > emailAddress.IndexOf("@"))
                {
                    errorMessage = "";
                    return true;
                }
            }

            errorMessage = "e-mail address must be in valid e-mail address format.\n" +
               "For example 'someone@example.com' ";
            return false;
        }

        private void richTextBoxEmailAddress_Validated(object sender, EventArgs e)
        {
            // If all conditions have been met, clear the ErrorProvider of errors.
            errorProviderCustomerForm.SetError(textBox1, "");
        }

        private void tabCustomerMaint_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void nullableDateTimePickerTitleDateReceived_ValueChanged(object sender, EventArgs e)
        {
            if (lbAddFlag || lbEdit)
                toolStripButtonSave.Enabled = true;
        }

        private void nullableDateTimePickerRepoDate_ValueChanged(object sender, EventArgs e)
        {
            if (lbAddFlag || lbEdit)
                toolStripButtonSave.Enabled = true;
        }

        private void cUSTOMER_REPO_CDEtextBox_TextChanged(object sender, EventArgs e)
        {
            if (lbAddFlag || lbEdit)
                toolStripButtonSave.Enabled = true;
        }

        private void checkBoxRefi_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBoxRefi.Checked && (lbAddFlag || lbEdit))
            {
                textBoxAccount.Enabled = true;
                ActiveControl = textBoxAccount;
                textBoxAccount.SelectAll();
            }
            else
                textBoxAccount.Enabled = false;
            if (lbAddFlag || lbEdit)
                toolStripButtonSave.Enabled = true;
        }

        private void CreateOutlookEmail(String mailToText)
        {
            try
            {
                Object mailitem;
                String CurrentUserEmail = UserPrincipal.Current.EmailAddress;
                Outlook.Application outlookApp = new Outlook.Application();
                mailitem = outlookApp.CreateItem(Outlook.OlItemType.olMailItem);
                Outlook.MailItem mailItem = (Outlook.MailItem)mailitem;
                mailItem.Subject = "***ATTENTION: MESSAGE FROM INDUSTRIAL ACCEPTANCE CORPORATION. ***";
                mailItem.SentOnBehalfOfName = CurrentUserEmail;
                mailItem.To = mailToText;
                mailItem.Importance = Outlook.OlImportance.olImportanceHigh;
                mailItem.Display(true);
            }
            catch (Exception eX)
            {
                throw new Exception("cDocument: Error occurred trying to Create an Outlook Email"
                                    + Environment.NewLine + eX.Message);
            }
        }

        private void buttonSendMail_Click(object sender, EventArgs e)
        {
            String lsLetterNo = comboBoxLetterNo.Text.TrimEnd(), lsLetterType = comboBoxLetterType.Text.TrimEnd().ToUpper(), lsFullComment = "";
            if (iACDataSet.CUSTOMER.Rows.Count == 0 || richTextBoxEmailAddress.Text.TrimEnd() == "")
                return;
            if (lsLetterNo.TrimEnd() == "" && richTextBoxEmailAddress.Text.TrimEnd() != "")
                CreateOutlookEmail(richTextBoxEmailAddress.Text);
            else
            {
                Int32 lnSeq = 0;
                object loQuery = null;
                IACDataSetTableAdapters.CUSTOMERTableAdapter CustomerTableAdapter = new IACDataSetTableAdapters.CUSTOMERTableAdapter();
                IACDataSetTableAdapters.COMMENTTableAdapter COMMENTTableAdapter = new IACDataSetTableAdapters.COMMENTTableAdapter();
                MailMergeComponents MailMerge = new MailMergeComponents();
                // Moses Newman 01/02/2014 Put letter in an Outlook Email if the EMAIL address field is populated!
                MailMerge.CreateMailMerge(iACDataSet, true, @"AUTOLETTER#" + lsLetterNo, lsLetterType, true, richTextBoxEmailAddress.Text.TrimEnd());
                cOMMENTBindingSource.AddNew();
                cOMMENTBindingSource.EndEdit();
                if (lnSeq == 0)
                {
                    loQuery = cOMMENTTableAdapter.SeqNoQuery(cUSTOMER_NOTextBox.EditValue.ToString().Trim(), DateTime.Now.Date);
                    if (loQuery != null)
                        lnSeq = (int)loQuery + 1;
                    else
                        lnSeq = 1;
                }
                else
                    lnSeq = lnSeq + 1;
                // Moses Newman 11/21/2017 Remove hard coded UNC Pathing.
                lsDataPath = lsUNCROOT.Trim() + @"CommentAttachments\Letters";
                // Moses Newman 02/22/2019 Add Full Comment
                lsFullComment = "Created and sent Letter#" + comboBoxLetterNo.Text.TrimEnd().TrimStart() + ".";
                cOMMENTTableAdapter.Insert(cUSTOMER_NOTextBox.EditValue.ToString().Trim(), DateTime.Now.Date, lnSeq, Program.gsUserID,
                                           lsFullComment,
                                           //"Created and sent Letter#" + comboBoxLetterNo.Text.TrimEnd().TrimStart() + ".",
                                           //" ", " ",
                                           "  ", (Int32)cUSTOMER_DEALERcomboBox.EditValue,
                                           Program.gsUserID + "  ",
                                           DateTime.Now.Hour.ToString().PadLeft(2, '0') + DateTime.Now.Minute.ToString().PadLeft(2, '0') + DateTime.Now.Second.ToString().PadLeft(2, '0'), false, "WordDoc.bmp", lsDataPath, Convert.ToInt32(comboBoxLetterNo.Text.TrimEnd().TrimStart()), "", "", 0);
                cOMMENTTableAdapter.FillByCustNo(iACDataSet.COMMENT, cUSTOMER_NOTextBox.EditValue.ToString().Trim());
                comboBoxLetterNo.Text = " ";
                comboBoxLetterType.Text = " ";
            }
        }

        private void nullableDateTimePickerLocDate_ValueChanged(object sender, EventArgs e)
        {
            if (lbAddFlag || lbEdit)
                toolStripButtonSave.Enabled = true;
        }

        private void nullableDateTimePickerAucDate_ValueChanged(object sender, EventArgs e)
        {
            if (lbAddFlag || lbEdit)
                toolStripButtonSave.Enabled = true;
        }

        private void comboBoxCreditCode_Validated(object sender, EventArgs e)
        {
            /*xtraTabControlCustomerMaint.SelectedTabPageIndex = 3;
            ActiveControl = txtCOSFirstName;
            txtCOSFirstName.Select();*/
        }


        private void checkBoxFullRecourse_CheckedChanged(object sender, EventArgs e)
        {
            Object SendTest = sender;
            CheckEdit edit = sender as CheckEdit;

            if (lbInFullRecourseCheck || gbInSave)
                return;
            if (lbAddFlag || lbEdit)
                toolStripButtonSave.Enabled = true;

            if (edit.Checked)
            {
                checkBoxFullRecourse.ForeColor = Color.Red;
                checkBoxFullRecourse.Refresh();
                checkBoxFullRecourseHist.ForeColor = Color.Red;
                checkBoxFullRecourseHist.Refresh();
                checkBoxFullRecourseTab1.ForeColor = Color.Red;
                checkBoxFullRecourseTab1.Refresh();
                lbInFullRecourseCheck = true;
                //checkBoxFullRecourse.Checked = true;                
                //checkBoxFullRecourseHist.Checked = true;
                //checkBoxFullRecourseTab1.Checked = true;
            }
            else
            {
                checkBoxFullRecourse.ForeColor = SystemColors.ControlText;
                checkBoxFullRecourse.Refresh();
                checkBoxFullRecourseHist.ForeColor = SystemColors.ControlText;
                checkBoxFullRecourseHist.Refresh();
                checkBoxFullRecourseTab1.ForeColor = SystemColors.ControlText;
                checkBoxFullRecourseTab1.Refresh();
                lbInFullRecourseCheck = true;
                checkBoxFullRecourse.Checked = false;
                checkBoxFullRecourseHist.Checked = false;
                checkBoxFullRecourseTab1.Checked = false;
            }
            lbInFullRecourseCheck = false;
            checkBoxFullRecourse.Refresh();
            checkBoxFullRecourseHist.Refresh();
            checkBoxFullRecourseTab1.Refresh();
            cUSTOMERBindingSource.EndEdit();
        }

        private void DateTimePickerContractDate_Validated(object sender, EventArgs e)
        {

        }

        /* Moses Newman 08/26/2020 Retired this ListBox
        // Moses Newman 06/15/2015 User Draw TSB listbox so that it can be 3 lines wide PER ITEM!
        private void txtTSBCommentCode_DrawItem(object sender, DrawItemEventArgs e)
        {
            DataRowView TSBDataRow;

            if (e.Index == -1)
                return;
            TSBDataRow = (DataRowView)listBoxTSBCommentCode.Items[e.Index];
            e.DrawBackground();
            if ((e.State & DrawItemState.Selected) == DrawItemState.Selected)
            {
                e.Graphics.FillRectangle(new SolidBrush(Color.LightBlue), e.Bounds);
            }
            else
            {
                e.Graphics.FillRectangle(new SolidBrush(SystemColors.Window), e.Bounds);
            }
            if (lbAddFlag || lbEdit)
                e.Graphics.DrawString(TSBDataRow["Description"].ToString(), e.Font, new SolidBrush(Color.Black), e.Bounds);
            else
                e.Graphics.DrawString(TSBDataRow["Description"].ToString(), e.Font, SystemBrushes.InfoText, e.Bounds);
        }*/

        private void txtTSBCommentCode_SelectedValueChanged(object sender, EventArgs e)
        {
            if (lbAddFlag || lbEdit)
                toolStripButtonSave.Enabled = true;
        }

        private void textBoxRepoFees_Validated(object sender, EventArgs e)
        {
            if (!Decimal.TryParse(textBoxRepoFees.Text, NumberStyles.Currency,
                CultureInfo.CreateSpecificCulture("en-US"), out gnRepoFees))
                return;
            textBoxRepoFees.Text = gnRepoFees.ToString("C", CultureInfo.CreateSpecificCulture("en-US"));
            CalcTotalFees();
        }

        private void textBoxStorageFees_Validated(object sender, EventArgs e)
        {
            if (!Decimal.TryParse(textBoxStorageFees.Text, NumberStyles.Currency,
                    CultureInfo.CreateSpecificCulture("en-US"), out gnStorageFees))
                return;
            textBoxStorageFees.Text = gnStorageFees.ToString("C", CultureInfo.CreateSpecificCulture("en-US"));
            CalcTotalFees();
        }

        private void textBoxImpoundFees_Validated(object sender, EventArgs e)
        {
            if (!Decimal.TryParse(textBoxImpoundFees.Text, NumberStyles.Currency,
                    CultureInfo.CreateSpecificCulture("en-US"), out gnImpoundFees))
                return;
            textBoxImpoundFees.Text = gnImpoundFees.ToString("C", CultureInfo.CreateSpecificCulture("en-US"));
            CalcTotalFees();
        }

        private void textBoxResaleFees_Validated(object sender, EventArgs e)
        {
            if (!Decimal.TryParse(textBoxResaleFees.Text, NumberStyles.Currency,
                CultureInfo.CreateSpecificCulture("en-US"), out gnResaleFees))
                return;
            textBoxResaleFees.Text = gnResaleFees.ToString("C", CultureInfo.CreateSpecificCulture("en-US"));
            CalcTotalFees();
        }

        private void textBoxRepairFee1_Validated(object sender, EventArgs e)
        {
            if (!Decimal.TryParse(textBoxRepairFee1.Text, NumberStyles.Currency,
                    CultureInfo.CreateSpecificCulture("en-US"), out gnRepairFee1))
                return;
            textBoxRepairFee1.Text = gnRepairFee1.ToString("C", CultureInfo.CreateSpecificCulture("en-US"));
            CalcTotalFees();
        }

        private void textBoxRepairFee2_Validated(object sender, EventArgs e)
        {
            if (!Decimal.TryParse(textBoxRepairFee2.Text, NumberStyles.Currency,
                    CultureInfo.CreateSpecificCulture("en-US"), out gnRepairFee2))
                return;
            textBoxRepairFee2.Text = gnRepairFee2.ToString("C", CultureInfo.CreateSpecificCulture("en-US"));
            CalcTotalFees();
        }

        private void textBoxOpenAccount_DoubleClick(object sender, EventArgs e)
        {
            ActiveControl = textBoxOpenAccount;
            textBoxOpenAccount.SelectAll();
            if (textBoxOpenAccount.Text.Length < 6)
                return;
            else
            {
                IACDataSetTableAdapters.OPNCUSTTableAdapter OPNCUSTTableAdapter = new IACDataSetTableAdapters.OPNCUSTTableAdapter();
                OPNCUSTTableAdapter.Fill(iACDataSet.OPNCUST, textBoxOpenAccount.Text);
                Int32 lnOpenCustCount = iACDataSet.OPNCUST.Rows.Count;

                Program.gsKey = textBoxOpenAccount.Text;
                iACDataSet.OPNCUST.Clear();
                OPNCUSTTableAdapter.Dispose();

                MDIIAC2013 MDImain = (MDIIAC2013)MdiParent;
                MDImain.CreateFormInstance("frmOpenCustMaint", false);
                frmOpenCustMaint OpenCustForm = (frmOpenCustMaint)MDImain.ActiveMdiChild;
                //OpenCustForm.Hide();
                if (lnOpenCustCount == 0)
                {
                    OpenCustForm.FromWarranty = true;

                    // Moses Newman 01/28/2019 Added missing Fields
                    OpenCustForm.SS1 = cUSTOMER_SS_1TextBox.Text;
                    OpenCustForm.SS2 = cUSTOMER_SS_2TextBox.Text;
                    OpenCustForm.SS3 = cUSTOMER_SS_3TextBox.Text;

                    OpenCustForm.WrongAddress = checkEditWrongAddress.Text;

                    OpenCustForm.DOB = (DateTime)txtDOB.EditValue;

                    // End of 01/28/2019 Changes

                    OpenCustForm.FirstName = cUSTOMER_FIRST_NAMETextBox.Text;
                    OpenCustForm.LastName = cUSTOMER_LAST_NAMETextBox.Text;
                    OpenCustForm.CustomerSuffix = (String)comboBoxGN.SelectedValue;
                    OpenCustForm.Dealer = "025"; // IAC MISC
                    OpenCustForm.Contact = cUSTOMER_CONTACTTextBox.Text;
                    OpenCustForm.Address1 = cUSTOMER_STREET_1TextBox.Text;
                    OpenCustForm.Address2 = cUSTOMER_STREET_2TextBox.Text;
                    OpenCustForm.City = cUSTOMER_CITYTextBox.Text;
                    OpenCustForm.State = cUSTOMER_STATETextBox.Text;
                    OpenCustForm.ZipCode = cUSTOMER_ZIP_1TextBox.Text;
                    OpenCustForm.ZipPlus4 = cUSTOMER_ZIP_2TextBox.Text;
                    OpenCustForm.HomePhone = cUSTOMER_PHONE_NOTextBox.Text;
                    OpenCustForm.HomeExt = cUSTOMER_PHONE_EXTtextBox.Text;
                    OpenCustForm.WorkPhone = cUSTOMER_WORK_PHONETextBox.Text;
                    OpenCustForm.WorkExt = cUSTOMER_WORK_EXTtextBox.Text;
                    OpenCustForm.CellPhone = cUSTOMER_CELL_PHONETextBox.Text;
                    OpenCustForm.Comment1 = cUSTOMER_COMMENT_1TextBox.Text;
                    OpenCustForm.Comment2 = cUSTOMER_COMMENT_2TextBox.Text;
                    OpenCustForm.CreditScoreN = cUSTOMER_CREDIT_SCORE_NTextBox.Text.TrimEnd() != "" ? Convert.ToInt32(cUSTOMER_CREDIT_SCORE_NTextBox.Text.TrimEnd()) : 0;
                    OpenCustForm.CreditScoreA = cUSTOMER_CREDIT_SCORE_ATextBox.Text;
                    OpenCustForm.AllotmentProg = checkEditAllotment.Text;
                    OpenCustForm.DistributorNo = cUSTOMER_DISTRIBUTOR_NOTextBox.Text.TrimEnd() != "" ? Convert.ToInt32(cUSTOMER_DISTRIBUTOR_NOTextBox.Text.TrimEnd()) : 0;
                    OpenCustForm.NoContact = checkEditNoContact.Text;
                    OpenCustForm.CosignName = cUSTOMER_COS_NAMETextBox.Text;
                    OpenCustForm.CosHomePhone = cUSTOMER_COS_PHONETextBox.Text;
                    OpenCustForm.CosCellPhone = txtCOSCell.Text;
                    OpenCustForm.DayDue = iACDataSet.CUSTOMER.Rows[cUSTOMERBindingSource.Position].Field<Int32>("CUSTOMER_DAY_DUE");
                    OpenCustForm.CreditStatus = checkEditCollectionAgent.Text;
                    OpenCustForm.AutoPay = checkEditAutoPay.Text;

                    OpenCustForm.AltName1 = txtALTContact1.Text;
                    OpenCustForm.AltRelation1 = txtALTRelation1.Text;
                    OpenCustForm.AltPhone1 = txtALTPhone1.Text;
                    OpenCustForm.AltExt1 = txtALTExt1.Text;

                    OpenCustForm.AltName2 = txtALTContact2.Text;
                    OpenCustForm.AltRelation2 = txtALTRelation2.Text;
                    OpenCustForm.AltPhone2 = txtALTPhone2.Text;
                    OpenCustForm.AltExt2 = txtALTExt2.Text;

                    OpenCustForm.AltName3 = txtALTContact3.Text;
                    OpenCustForm.AltRelation3 = txtALTRelation3.Text;
                    OpenCustForm.AltPhone3 = txtALTPhone3.Text;
                    OpenCustForm.AltExt3 = txtALTExt3.Text;

                    OpenCustForm.AltName4 = txtALTContact4.Text;
                    OpenCustForm.AltRelation4 = txtALTRelation4.Text;
                    OpenCustForm.AltPhone4 = txtALTPhone4.Text;
                    OpenCustForm.AltExt4 = txtALTExt4.Text;


                    OpenCustForm.CustomerNumber = textBoxOpenAccount.Text;
                    OpenCustForm.Refresh();
                    OpenCustForm.Show();
                }
            }
        }

        private void tabRepoHistory_Click(object sender, EventArgs e)
        {

        }

        private void textBoxLTV_Validating(object sender, CancelEventArgs e)
        {
            if (textBoxLTV.Text == "")
                textBoxLTV.Text = "0.00";
        }

        private void CheckBoxTitleReleased_CheckedChanged(object sender, EventArgs e)
        {
            if (lbAddFlag || lbEdit)
                toolStripButtonSave.Enabled = true;
        }

        private void NullableDateTimePickerDateTitleReleased_ValueChanged(object sender, EventArgs e)
        {
            if (lbAddFlag || lbEdit)
                toolStripButtonSave.Enabled = true;
        }

        private void CheckBoxTitleReceived_CheckedChanged(object sender, EventArgs e)
        {
            if (lbAddFlag || lbEdit)
                toolStripButtonSave.Enabled = true;
        }

        private void CheckBoxElectronicLien_CheckedChanged(object sender, EventArgs e)
        {
            if (lbAddFlag || lbEdit)
                toolStripButtonSave.Enabled = true;
        }

        // Moses Newman 12/18/2019 Validate cosigner email
        private void textBoxCosignerEmail_Validating(object sender, CancelEventArgs e)
        {
            Program.EmailValidator(ref sender, ref e, ref this.errorProviderCustomerForm);
            if (e.Cancel)
            {
                ((TextBox)sender).Select(0, ((TextBox)sender).Text.Length);
            }

        }

        private void checkBoxSendToDealer_CheckedChanged(object sender, EventArgs e)
        {
            if (lbAddFlag || lbEdit)
                toolStripButtonSave.Enabled = true;
        }

        //Moses Newman 12/20/2019 Add Direct Email To Dealer Button
        private void buttonDealerEmail_Click(object sender, EventArgs e)
        {
            String lsLetterNo = comboBoxLetterNo.Text.TrimEnd(), lsLetterType = comboBoxLetterType.Text.TrimEnd().ToUpper(), lsFullComment = "";
            if (iACDataSet.CUSTOMER.Rows.Count == 0 || textBoxDealerEmail.Text.TrimEnd() == "")
                return;
            if (lsLetterNo.TrimEnd() == "")
                CreateOutlookEmail(textBoxDealerEmail.Text);
            else
            {
                Int32 lnSeq = 0;
                object loQuery = null;
                IACDataSetTableAdapters.CUSTOMERTableAdapter CustomerTableAdapter = new IACDataSetTableAdapters.CUSTOMERTableAdapter();
                IACDataSetTableAdapters.COMMENTTableAdapter COMMENTTableAdapter = new IACDataSetTableAdapters.COMMENTTableAdapter();
                MailMergeComponents MailMerge = new MailMergeComponents();
                // Moses Newman 01/02/2014 Put letter in an Outlook Email if the EMAIL address field is populated!
                MailMerge.CreateMailMerge(iACDataSet, true, @"AUTOLETTER#" + lsLetterNo, lsLetterType, true, textBoxDealerEmail.Text.TrimEnd());
                cOMMENTBindingSource.AddNew();
                cOMMENTBindingSource.EndEdit();
                if (lnSeq == 0)
                {
                    loQuery = cOMMENTTableAdapter.SeqNoQuery(cUSTOMER_NOTextBox.EditValue.ToString().Trim(), DateTime.Now.Date);
                    if (loQuery != null)
                        lnSeq = (int)loQuery + 1;
                    else
                        lnSeq = 1;
                }
                else
                    lnSeq = lnSeq + 1;
                // Moses Newman 11/21/2017 Remove hard coded UNC Pathing.
                lsDataPath = lsUNCROOT.Trim() + @"CommentAttachments\Letters";
                // Moses Newman 02/22/2019 Add Full Comment
                lsFullComment = "Created and sent dealer Letter#" + comboBoxLetterNo.Text.TrimEnd().TrimStart() + ".";
                cOMMENTTableAdapter.Insert(cUSTOMER_NOTextBox.EditValue.ToString().Trim(), DateTime.Now.Date, lnSeq, Program.gsUserID,
                                           lsFullComment,
                                           //"Created and sent Letter#" + comboBoxLetterNo.Text.TrimEnd().TrimStart() + ".",
                                           //" ", " ",
                                           "  ", (Int32)cUSTOMER_DEALERcomboBox.EditValue,
                                           Program.gsUserID + "  ",
                                           DateTime.Now.Hour.ToString().PadLeft(2, '0') + DateTime.Now.Minute.ToString().PadLeft(2, '0') + DateTime.Now.Second.ToString().PadLeft(2, '0'), false, "WordDoc.bmp", lsDataPath, Convert.ToInt32(comboBoxLetterNo.Text.TrimEnd().TrimStart()), "", "", 0);
                cOMMENTTableAdapter.FillByCustNo(iACDataSet.COMMENT, cUSTOMER_NOTextBox.EditValue.ToString().Trim());
                comboBoxLetterNo.Text = " ";
                comboBoxLetterType.Text = " ";
            }

        }

        private void textBoxDealerEmail_TextChanged(object sender, EventArgs e)
        {
            if (lbEdit || lbAddFlag)
            {
                // Moses Newman 12/19/2019 Send to Dealer Checkbox added.
                if (textBoxDealerEmail.Text.Trim() != "")
                {
                    checkBoxSendToDealer.Visible = true;
                    checkBoxSendToDealer.Enabled = true;
                }
                else
                {
                    checkBoxSendToDealer.Enabled = false;
                    checkBoxSendToDealer.Visible = false;
                }
            }
            else
            {
                // Moses Newman 12/19/2019 Send to Dealer Checkbox added.
                if (textBoxDealerEmail.Text.Trim() != "")
                {
                    checkBoxSendToDealer.Visible = true;
                    checkBoxSendToDealer.Enabled = false;
                }
                else
                {
                    checkBoxSendToDealer.Enabled = false;
                    checkBoxSendToDealer.Visible = false;
                }
            }
            checkBoxSendToDealer.Refresh();
        }

        private void comboBoxTSBPaymentRating_SelectedValueChanged(object sender, EventArgs e)
        {
            if (lbAddFlag || lbEdit)
            {
                toolStripButtonSave.Enabled = true;
            }
        }

        private void comboBoxConsumerIndicator_SelectedValueChanged(object sender, EventArgs e)
        {
            if (lbAddFlag || lbEdit)
                toolStripButtonSave.Enabled = true;
        }

        private void comboBoxPaymentRating_SelectedValueChanged(object sender, EventArgs e)
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

        private void comboBoxTermsFrequency_SelectedValueChanged(object sender, EventArgs e)
        {
            if (lbAddFlag || lbEdit)
                toolStripButtonSave.Enabled = true;
        }

        // Moses Newman 08/15/2020 ONLY enable Payment Rating field if Account Status is 15,65,89,94, or 95!
        private void comboBoxPaymentRating_EnabledChanged(object sender, EventArgs e)
        {
            if (comboBoxPaymentRating.Enabled)
            {
                switch (comboBoxAccountStatus.EditValue)
                {
                    case "13":
                    case "65":
                    case "89":
                    case "94":
                    case "95":
                        break;
                    default:
                        comboBoxPaymentRating.Enabled = false;
                        break;
                }
            }
        }

        private void checkBox2_CheckedChanged(object sender, EventArgs e)
        {
            if (lbAddFlag || lbEdit)
                toolStripButtonSave.Enabled = true;
        }

        private void textBoxRepairFee3_Validated(object sender, EventArgs e)
        {
            if (!Decimal.TryParse(textBoxRepairFee3.Text, NumberStyles.Currency,
                    CultureInfo.CreateSpecificCulture("en-US"), out gnRepairFee3))
                return;
            textBoxRepairFee3.Text = gnRepairFee3.ToString("C", CultureInfo.CreateSpecificCulture("en-US"));
            CalcTotalFees();
        }

        private void checkBoxFollowUpDate_CheckedChanged(object sender, EventArgs e)
        {
            if (lbAddFlag || lbEdit)
                toolStripButtonSave.Enabled = true;
        }

        private void checkBoxReportTSB_CheckedChanged(object sender, EventArgs e)
        {
            if (lbAddFlag || lbEdit)
            {
                toolStripButtonSave.Enabled = true;
                // Moses Newman 08/26/2020 Toggle CUSTOMER_CREDIT_BUREAU if this is checked!
                if (checkBoxReportTSB.Checked)
                    iACDataSet.CUSTOMER.Rows[0].SetField<String>("CUSTOMER_CREDIT_BUREAU", "Y");
                else
                    iACDataSet.CUSTOMER.Rows[0].SetField<String>("CUSTOMER_CREDIT_BUREAU", "N");
            }
        }

        private void checkBoxPurge_CheckedChanged(object sender, EventArgs e)
        {
            if (lbAddFlag || lbEdit)
                toolStripButtonSave.Enabled = true;
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

        private void buttonEditPaymentHistory_Click(object sender, EventArgs e)
        {
            String OldProfile = tsbDataSet.ClosedCreditManager.Rows[0].Field<String>("PaymentProfile");

            FormDelinquencyPeriods newdelinquencyperiods = new FormDelinquencyPeriods();
            newdelinquencyperiods.CustomerID = iACDataSet.CUSTOMER.Rows[0].Field<Int32>("CustomerID");
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

        private void colorCheckBoxReceivedContract_CheckedChanged(object sender, EventArgs e)
        {
            CheckEdit edit = sender as CheckEdit;
            if (lbAddFlag || lbEdit)
                toolStripButtonSave.Enabled = true;
            // Moses Newman 02/28/2021
            if (edit.Checked)
            {
                colorCheckBoxReceivedContract.ForeColor = Color.Green;
                nullableDateTimePickerDateContractReceived.Enabled = true;
                nullableDateTimePickerDateContractReceived.Visible = true;
                nullableDateTimePickerDateContractReceived.EditValue = DateTime.Now.Date;
            }
            else
            {
                colorCheckBoxReceivedContract.ForeColor = SystemColors.ControlText;
                nullableDateTimePickerDateContractReceived.Enabled = false;
                nullableDateTimePickerDateContractReceived.Visible = false;
                nullableDateTimePickerDateContractReceived.EditValue = null;
            }
        }

        private void buttonCOSValidate_Click(object sender, EventArgs e)
        {
            if (!lbAddFlag && !lbEdit)
                return;

            GroupClient generalService = new GroupClient("ReportWSServiceHttpEndpoint2");
            string securityToken = sbtLogin();
            string orgCode = "wt63419";
            string[] phone = txtCOSCell.Text.Trim().Split(',');

            WSCarrierLookupResponse wSCarrierLookupResponse = generalService.GetCarrierLookup(securityToken, phone, orgCode);

            if (!wSCarrierLookupResponse.Result)
            {
                MakeComment("*** Failed to VALIDATE cosigner cell phone number! ***", wSCarrierLookupResponse.Message, 0, false);
                //handle error
                buttonCOSValidate.ForeColor = Color.Crimson;
                iACDataSet.CUSTOMER.Rows[0].SetField<Boolean>("COSCellValid", false);
            }
            else
            {
                if (wSCarrierLookupResponse.Result && !wSCarrierLookupResponse.Response[0].Landline)
                {
                    MakeComment("Cosigner Cell Phone Number VALIDATED.", wSCarrierLookupResponse.Message, 0, false);
                    buttonCOSValidate.ForeColor = Color.Green;
                    iACDataSet.CUSTOMER.Rows[0].SetField<Boolean>("COSCellValid", true);
                    // Moses Newman reset COSTpin from AUTO to nothing 07/13/2022
                    iACDataSet.CUSTOMER.Rows[0].SetField<String>("COSTPin", "");
                    cUSTOMERBindingSource.EndEdit();
                    radioButtonCOSAcct.Checked = false;
                }
                else
                {
                    MakeComment("*** Cosigner Cell Number not VALIDATED because it is a LANDLINE! ***", wSCarrierLookupResponse.Message, 0, false);
                    buttonCOSValidate.ForeColor = Color.Crimson;
                    iACDataSet.CUSTOMER.Rows[0].SetField<Boolean>("COSCellValid", false);
                    // Moses Newman reset COSTpin from AUTO to nothing 07/13/2022
                    iACDataSet.CUSTOMER.Rows[0].SetField<String>("COSTPin", "");
                    cUSTOMERBindingSource.EndEdit();
                    radioButtonCOSAcct.Checked = false;
                }
            }
            toolStripButtonSave.Enabled = true;
        }

        private void checkBoxCOSDNTAcct_CheckedChanged(object sender, EventArgs e)
        {
            if (lbAddFlag || lbEdit)
                toolStripButtonSave.Enabled = true;
        }

        private void checkBoxCOSDNTAcct_Click(object sender, EventArgs e)
        {
            var ldlgResult = MessageBox.Show("Are you absolutely sure you want to unsubcribe this subscriber?  If you do so you will have to verify by text and reconfirm the subscriber again if at a later date you wish to reinstate this subscriber!", "Change Statuts to DO NOT TEXT", MessageBoxButtons.YesNo);
            if (ldlgResult == DialogResult.No)
                return;
            if (lbAddFlag || lbEdit)
                toolStripButtonSave.Enabled = true;
            SubscriberClient subscriberResult = new SubscriberClient("SubscriberWSServiceHttpEndpoint");

            string securityToken = sbtLogin();

            SubscriberDetails subscriber = new SubscriberDetails();
            subscriber.MobilePhone = txtCOSCell.Text;
            subscriber.OrgCode = "wt63419";
            WSUnsubscriberResponse wsUnSubscribeResponse = subscriberResult.UnSubscribe(securityToken, subscriber);

            if (!wsUnSubscribeResponse.Result && (wsUnSubscribeResponse.Message != "Subscriber already unsubscribed"))
            {
                iACDataSet.CUSTOMER.Rows[0].SetField<Boolean>("COSDNTAcct", false);
                MessageBox.Show(wsUnSubscribeResponse.Message);
                MakeComment("*** UNSUBSCRIBE COSIGNER SBT FAILED! ***", wsUnSubscribeResponse.Message, 0, false);
            }
            else
            {
                iACDataSet.CUSTOMER.Rows[0].SetField<Boolean>("COSTAcct", false);
                radioButtonCOSAcct.Checked = false;
                iACDataSet.CUSTOMER.Rows[0].SetField<String>("COSTPin", "");
                buttonCOSConfirm.ForeColor = Color.Crimson;
                iACDataSet.CUSTOMER.Rows[0].SetField<Boolean>("COSTConfirmed", false);
                iACDataSet.CUSTOMER.Rows[0].SetField<Boolean>("COSDNTAcct", true);
                MakeComment("COSIGNER CELL PHONE UNSUBSCRIBED FROM SBT.", wsUnSubscribeResponse.Message, 0, false);
                MessageBox.Show(wsUnSubscribeResponse.Message, "Unsubscribed");
            }
        }

        private void radioButtonCOSAcct_CheckedChanged(object sender, EventArgs e)
        {
            if (lbAddFlag || lbEdit)
                toolStripButtonSave.Enabled = true;
        }

        private void radioButtonCOSAcct_Click(object sender, EventArgs e)
        {
            if (textBoxCOSAuthNo.Text.TrimEnd() != "" || txtCOSCell.Text.TrimEnd() == "" || buttonCOSValidate.ForeColor != Color.Green)
            {
                if (radioButtonCOSAcct.Checked)
                {
                    radioButtonCOSAcct.Checked = false;
                    checkBoxCOSDNTAcct.Checked = true;
                }
                return;
            }
            if (lbAddFlag || lbEdit)
                toolStripButtonSave.Enabled = true;
            if (radioButtonCOSAcct.Checked)
            {
                string VBTError = "";
                MessageClient messageResult = new MessageClient("MessageWSServiceHttpEndpoint");
                string securityToken = sbtLogin();
                string orgCode = "wt63419";
                string phoneNo = txtCOSCell.Text;

                WSVerificationResponse wSVerificationResponse = messageResult.RequestVBT(securityToken, orgCode, phoneNo);
                if (!wSVerificationResponse.Result)
                {
                    iACDataSet.CUSTOMER.Rows[0].SetField<String>("COSTPin", "");
                    textBoxCOSAuthNo.Refresh();

                    VBTError = wSVerificationResponse.Message;
                    if (VBTError.TrimEnd() != "Subscriber information already exists")
                    {
                        iACDataSet.CUSTOMER.Rows[0].SetField<Boolean>("COSTAcct", false);
                        MakeComment("*** COSIGNER VBT PIN NOT CREATED! ***", VBTError, 0, false);
                        MessageBox.Show(VBTError);
                    }
                }
                else
                {
                    iACDataSet.CUSTOMER.Rows[0].SetField<Boolean>("COSDNTAcct", false);
                    iACDataSet.CUSTOMER.Rows[0].SetField<Boolean>("COSTAcct", true);
                    iACDataSet.CUSTOMER.Rows[0].SetField<String>("COSTPin", "AUTO");
                    textBoxCOSAuthNo.Refresh();
                    radioButtonCOSAcct.Checked = true;
                    radioButtonCOSMktg.Checked = false;
                    UpdateSubscriberCOS(securityToken);  // Moses Newman 09/22/2021
                    iACDataSet.CUSTOMER.Rows[0].SetField<Boolean>("COSTConfirmed", true);
                    buttonCOSConfirm.ForeColor = Color.Green;
                    MakeComment("COSIGNER AUTO CONFIRMED (NO PIN)!", "AUTO", 0, false);
                }
            }
        }

        private void checkBoxCOSDNTMktg_CheckedChanged(object sender, EventArgs e)
        {
            if (lbAddFlag || lbEdit)
                toolStripButtonSave.Enabled = true;
        }

        private void radioButtonCOSMktg_CheckedChanged(object sender, EventArgs e)
        {
            if (lbAddFlag || lbEdit)
                toolStripButtonSave.Enabled = true;
        }

        private void buttonCOSConfirm_Click(object sender, EventArgs e)
        {
            return;
        }

        private void buttonCOSMessage_Click(object sender, EventArgs e)
        {
            String lsMessage = "", lsAPIMessage = "";
            Int32 lnTemplateID = 0;

            FormSMSMessage newmessage = new FormSMSMessage();
            newmessage.CellPhone = txtCOSCell.Text.TrimEnd();
            //newmessage.securityToken = sbtLogin(); login now from Message Form! 08/12/2020 Moses Newman
            newmessage.CustomerNo = iACDataSet.CUSTOMER.Rows[0].Field<String>("CUSTOMER_NO");
            newmessage.ShowDialog();
            lsMessage = newmessage.MessageSent;
            lnTemplateID = newmessage.TempID;
            lsAPIMessage = newmessage.APIMessage;
            newmessage.Hide();
            newmessage.Dispose();

            if (lsMessage != "NONE")
                if (lsMessage != "")
                    MakeComment(lsMessage, lsAPIMessage, lnTemplateID, true, true); // Moses Newman 09/22/2021 add cosigner text sent
                else
                    MakeComment("Cosigner Message SEND failed!", lsAPIMessage, lnTemplateID, false);
        }

        private void textBoxRepairFee4_Validated(object sender, EventArgs e)
        {
            if (!Decimal.TryParse(textBoxRepairFee4.Text, NumberStyles.Currency,
                    CultureInfo.CreateSpecificCulture("en-US"), out gnRepairFee4))
                return;
            textBoxRepairFee4.Text = gnRepairFee4.ToString("C", CultureInfo.CreateSpecificCulture("en-US"));
            CalcTotalFees();
        }

        // Return the WordImage for a specific row.
        private Bitmap getWordImage(GridView view, int listSourceRowIndex)
        {
            Bitmap img;
            img = new Bitmap(IAC2021SQL.Properties.Resources.WordDoc);
            if (!String.IsNullOrEmpty(Convert.ToString(view.GetListSourceRowCellValue(listSourceRowIndex, "LetterPath"))) || !String.IsNullOrEmpty(Convert.ToString(view.GetListSourceRowCellValue(listSourceRowIndex, "SMSPath"))))
                return img;
            else
                return null;
        }

        // Return the Path for a specific row.
        private String getPath(GridView view, int listSourceRowIndex)
        {
            return !String.IsNullOrEmpty(Convert.ToString(view.GetListSourceRowCellValue(listSourceRowIndex, "LetterPath"))) ?
                    Convert.ToString(view.GetListSourceRowCellValue(listSourceRowIndex, "LetterPath")) :
                    Convert.ToString(view.GetListSourceRowCellValue(listSourceRowIndex, "SMSPath"));
        }

        private void gridView1_CustomUnboundColumnData(object sender, DevExpress.XtraGrid.Views.Base.CustomColumnDataEventArgs e)
        {
            GridView view = sender as GridView;
            if (e.Column.FieldName == "colThumb" && e.IsGetData)
                e.Value = getWordImage(view, e.ListSourceRowIndex);
        }

        private void gridView1_RowCellClick(object sender, RowCellClickEventArgs e)
        {
            GridView view = sender as GridView;
            if (e.Column.FieldName == "colThumb")
            {
                String lsPath = getPath(view, view.GetDataSourceRowIndex(e.RowHandle));
                // If the LetterPath field is not empty open the word document.
                if (!String.IsNullOrEmpty(lsPath))
                {

                    if (System.IO.File.Exists(lsPath))
                    {
                        Word._Application application = new Word.Application();
                        Word._Document document = application.Documents.Open(lsPath);
                        // Old method to open using windows default editor for filetype.
                        //System.Diagnostics.Process.Start(lsPath);
                        document.Activate();
                        application.Visible = true;
                    }
                    else
                        MessageBox.Show("The document: " + lsPath + " seems to be missing!",
                                        "Specified Document Missing");
                }
            }
        }

        //Moses Newman 11/23/2021 Use DevExpress GridView instead of DataGridView for comments tab now
        private void cOMMENTgridView_CellValueChanging(object sender, CellValueChangedEventArgs e)
        {
            if (lbAddFlag || lbEdit)
                toolStripButtonSave.Enabled = true;
        }

        //Moses Newman 11/23/2021 Use DevExpress GridView instead of DataGridView for comments tab now

        private void xtraTabControlCustomerMaint_CloseButtonClick(object sender, EventArgs e)
        {
            Close();
        }

        private void txtContractStatus_EditValueChanged(object sender, EventArgs e)
        {
            TextEdit edit = sender as TextEdit;

            var value = edit.EditValue as Decimal?;

            if (value == null)
                return;

            if (value > 0)
                edit.ForeColor = Color.Green;
            else
                if (value < 0)
                edit.ForeColor = Color.Red;
            else
                    if (!Enabled)
                edit.ForeColor = System.Drawing.SystemColors.GrayText;
            else
                edit.ForeColor = System.Drawing.SystemColors.ControlText;
        }

        private void colorTextBoxTotalDue_EditValueChanged(object sender, EventArgs e)
        {
            TextEdit edit = sender as TextEdit;

            var value = edit.EditValue as Decimal?;

            if (value == null)
                return;

            if (value > 0)
                edit.ForeColor = Color.Purple;
            else
                if (value < 0)
                edit.ForeColor = Color.DarkSeaGreen;
            else
                if (!Enabled)
                edit.ForeColor = System.Drawing.SystemColors.GrayText;
            else
                edit.ForeColor = System.Drawing.SystemColors.ControlText;
        }

        private void tabFormControl1_Click(object sender, EventArgs e)
        {

        }

        private void toolStripButton1_Click(object sender, ItemClickEventArgs e)
        {
            Visible = false;
            form2inst = new frmCustomerLookup();
            // Moses Newman 02/21/2018 set new property of lookup form so it knows its Closed ONLY!
            form2inst.LookupFormType = "C";

            form2inst.ShowDialog();
            form2inst.Dispose();
            Visible = true;
            if (Program.gsKey != null)
            {
                cUSTOMER_NOTextBox.Focus();
                cUSTOMER_NOTextBox.SelectAll();
                cUSTOMER_NOTextBox.EditValue = Program.gsKey;
                SendKeys.Send("{ENTER}");
            }
            Program.gsKey = null;
        }

        private void toolStripButtonDelete_ItemClick(object sender, ItemClickEventArgs e)
        {
            String lcHighValue = "" + (char)255;
            // Moses Newman 06/12/2020 Second test to make sure that only NON-POSTED NEW business can be deleted!
            // Moes Newman 01/10/2023 Change binding source position to 0 because there must be only one record anyway, and it may be possible for the binding source position to be off
            if (iACDataSet.CUSTOMER.Rows[0].Field<String>("CUSTOMER_POST_IND") != lcHighValue)
                return;
            string lsCustomerNo = "";

            Validate();  //Validate form so all data sets are updated with field values
            lsCustomerNo = cUSTOMER_NOTextBox.EditValue.ToString().Trim();

            tableAdapConn = new System.Data.SqlClient.SqlConnection();
            tableAdapConn.ConnectionString = IAC2021SQL.Properties.Settings.Default.IAC2010SQLConnectionString;
            tableAdapConn.Open();
            cUSTOMERTableAdapter.Connection = tableAdapConn;
            tableAdapTran = cUSTOMERTableAdapter.BeginTransaction();
            aLTNAMETableAdapter.Connection = tableAdapConn;
            aLTNAMETableAdapter.Transaction = tableAdapTran;
            oPNBANKTableAdapter.Connection = tableAdapConn;
            oPNBANKTableAdapter.Transaction = tableAdapTran;
            vEHICLETableAdapter.Connection = tableAdapConn;
            vEHICLETableAdapter.Transaction = tableAdapTran;
            cOMMENTTableAdapter.Connection = tableAdapConn;
            cOMMENTTableAdapter.Transaction = tableAdapTran;
            // Moses Newman 03/27/2013 Add delete from Email SQL server Table!!!
            emailTableAdapter.Connection = tableAdapConn;
            emailTableAdapter.Transaction = tableAdapTran;

            try
            {
                cUSTOMERTableAdapter.DeleteQuery(lsCustomerNo);
                aLTNAMETableAdapter.DeleteQuery(lsCustomerNo, "C");
                oPNBANKTableAdapter.DeleteQuery(lsCustomerNo, "C");
                vEHICLETableAdapter.DeleteQuery(lsCustomerNo);
                cOMMENTTableAdapter.DeleteQuery(lsCustomerNo);
                // Moses Newman 03/27/2013 Add delete from Email SQL server Table!!!
                emailTableAdapter.Delete(lsCustomerNo);
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
                tableAdapConn.Close();
                tableAdapConn = null;
                tableAdapTran = null;
                toolStripButtonDelete.Enabled = false;
                toolStripButtonEdit.Enabled = false;
                iACDataSet.CUSTOMER.Clear();
                iACDataSet.ALTNAME.Clear();
                iACDataSet.OPNBANK.Clear();
                iACDataSet.VEHICLE.Clear();
                iACDataSet.COMMENT.Clear();
                // Moses Newman 03/27/2013 Add SQL Serrver Email Table to DELETE
                iACDataSet.Email.Clear();
                cUSTOMER_DEALERcomboBox.EditValue = null;
                Program.gsKey = null;
                frmNewCustMaint_Load(sender, e);
            }
        }

        private void toolStripButtonSave_ItemClick(object sender, ItemClickEventArgs e)
        {
            if (!lbAddFlag && !lbEdit)
            {
                toolStripButtonSave.Enabled = false;
                return;
            }
            gbInSave = true;
            string lsCustomerNo;
            // Moses Newman 01/09/2014 Added Form.Validate() call so that current field gets validated prior to the BindingSource.EndEdit() call!
            Validate();
            // Moses Newman 08/02/2013 if we were in EDIT mode as opposed to ADD mode we must restore original CUSTOMER_BALANCE as only posting routines and new business can alter the balance.
            if (lbEdit)
            {
                // Moses Newman 07/13/2020 Get last CUSTOMER_BALANCE AND BUYOUT inc case gn variables not properly set.  NEVER CHANGE THOSE FIELDS durig maintenance update.
                IACDataSet OldData = new IACDataSet();
                cUSTOMERTableAdapter.Fill(OldData.CUSTOMER, iACDataSet.CUSTOMER.Rows[cUSTOMERBindingSource.Position].Field<String>("CUSTOMER_NO"));
                if (OldData.CUSTOMER.Rows.Count != 0)
                {
                    if (gnCustomerBalance != OldData.CUSTOMER.Rows[0].Field<Decimal>("CUSTOMER_BALANCE"))
                        gnCustomerBalance = OldData.CUSTOMER.Rows[0].Field<Decimal>("CUSTOMER_BALANCE");
                    if (gnCustomerBuyout != OldData.CUSTOMER.Rows[0].Field<Decimal>("CUSTOMER_BUYOUT"))
                        gnCustomerBuyout = OldData.CUSTOMER.Rows[0].Field<Decimal>("CUSTOMER_BUYOUT");
                }
                OldData.Dispose();
                // 07/13/2020 End old buyout and balance check. 
                if (gnCustomerBalance != 0)
                {
                    iACDataSet.CUSTOMER.Rows[cUSTOMERBindingSource.Position].SetField<Decimal>("CUSTOMER_BALANCE", gnCustomerBalance);
                }

                if (gnCustomerBuyout != 0)
                    iACDataSet.CUSTOMER.Rows[cUSTOMERBindingSource.Position].SetField<Decimal>("CUSTOMER_BUYOUT", gnCustomerBuyout);

                if (iACDataSet.CUSTOMER.Rows[cUSTOMERBindingSource.Position].Field<Decimal>("CUSTOMER_BALANCE") == 0)
                {
                    loLastBalance = cUSTHISTTableAdapter.LastBalance(cUSTOMER_NOTextBox.EditValue.ToString().Trim());
                    if (loLastBalance != null)
                        gnCustomerBalance = (Decimal)loLastBalance;
                    if (gnCustomerBalance != 0)
                        iACDataSet.CUSTOMER.Rows[cUSTOMERBindingSource.Position].SetField<Decimal>("CUSTOMER_BALANCE", gnCustomerBalance);
                }
            }
            gnCustomerBalance = 0;
            gnCustomerBuyout = 0;
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

            if (cUSTOMER_DEALERcomboBox.EditValue == null)
            {
                GeneralValidationError("*** You must enter a DEALER NUMBER! ***", cUSTOMER_DEALERcomboBox);
                return;
            }
            if (lbAddFlag)
            {
                if (txtCASH.Text.Length == 0 || Convert.ToDecimal(txtCASH.Text.Substring(1)) == 0)
                {
                    xtraTabControlCustomerMaint.SelectedTabPageIndex = 1;
                    GeneralValidationError(@"*** You must enter the customer's loan amount (CASH)! ***", txtCASH);
                    ActiveControl = txtCASH;
                    txtCASH.SelectAll();
                    return;
                }
                if (txtTerm.Text.Length == 0 || Convert.ToInt32(txtTerm.Text) == 0)
                {
                    xtraTabControlCustomerMaint.SelectedTabPageIndex = 1;
                    GeneralValidationError(@"*** You must enter the customer's loan TERM! ***", txtTerm);
                    ActiveControl = txtTerm;
                    txtTerm.SelectAll();
                    return;
                }
                if ((txtRegularPay.Text.Length == 0 || Convert.ToDecimal(txtRegularPay.Text.Substring(1)) == 0) &&
                    (txtAPR.Text.Length == 0 || Convert.ToDecimal(txtAPR.Text) == 0))
                {
                    xtraTabControlCustomerMaint.SelectedTabPageIndex = 1;
                    GeneralValidationError(@"*** You must enter either the customer's Monthly Payment (REGULAR PAYMENT), APR, OR BOTH! ***", txtRegularPay);
                    GeneralValidationError(@"*** You must enter either the customer's Monthly Payment (REGULAR PAYMENT), APR, OR BOTH! ***", txtAPR);
                    ActiveControl = txtRegularPay;
                    txtRegularPay.SelectAll();
                    return;
                }
                if (comboBoxDayDue.SelectedIndex < 0 && comboBoxDayDue.Text.Length == 0)
                {
                    xtraTabControlCustomerMaint.SelectedTabPageIndex = 1;
                    GeneralValidationError(@"*** You must enter the customer's DAY DUE ***", comboBoxDayDue);
                    ActiveControl = comboBoxDayDue;
                    comboBoxDayDue.SelectAll();
                    return;
                }
            }
            // Moses Newman 11/12/2013 Add check for Valid Vehicle Year if the field is NOT left blank!
            if (txtVehicleYear.Text.Length > 0 && Convert.ToInt32(txtVehicleYear.Text) < 1000 && txtVehicleYear.Text.TrimEnd() != "0")
            {
                xtraTabControlCustomerMaint.SelectedTabPageIndex = 2;
                GeneralValidationError(@"*** You must enter a valid VEHICLE Year if the field is NOT left blank! ***", txtVehicleYear);
                ActiveControl = txtVehicleYear;
                txtVehicleYear.SelectAll();
                return;
            }
            lsCustomerNo = cUSTOMER_NOTextBox.EditValue.ToString().Trim();
            cUSTOMER_PURCHASE_ORDERTextBox.EditValue = cUSTOMER_PURCHASE_ORDERTextBox.EditValue.ToString().Trim();
            cUSTOMERBindingSource.EndEdit();
            cUSTHISTBindingSource.EndEdit();
            cOMMENTBindingSource.EndEdit();
            ALTNAMEbindingSource.EndEdit();
            VehiclebindingSource.EndEdit();
            OPNBANKbindingSource.EndEdit();
            // Moses Newman 12/23/2013 Added email address record!
            EmailbindingSource.EndEdit();
            // Moses Newman 06/12/2018 Added CustomerFees record!
            CustomerFeesBindingSource.EndEdit();
            // Moses Newman 08/13/2020 Add save of TSB data
            closedCreditManagerBindingSource.EndEdit();

            try
            {
                tableAdapConn = new System.Data.SqlClient.SqlConnection();
                tableAdapConn.ConnectionString = IAC2021SQL.Properties.Settings.Default.IAC2010SQLConnectionString;
                tableAdapConn.Open();
                cUSTOMERTableAdapter.Connection = tableAdapConn;
                tableAdapTran = cUSTOMERTableAdapter.BeginTransaction();
                cUSTOMERTableAdapter.Transaction = tableAdapTran;

                cUSTOMERTableAdapter.Update(iACDataSet.CUSTOMER.Rows[cUSTOMERBindingSource.Position]);
                // Moses Newman 10/23/2013 Add Code to create rate change event to turn on or off interest depending on interest overide setting
                if (lbEdit)
                {
                    String lsCustKey = iACDataSet.CUSTOMER.Rows[cUSTOMERBindingSource.Position].Field<String>("CUSTOMER_NO");//, lsExpression = "", lsSort = "";
                    Boolean lbInterestOveride = false;
                    Object loLastIntOverideZero = null;// loCustHistSeq = null;
                    DateTime ldCustDate = DateTime.Now.Date;
                    //DataRow[] FoundItems = null;
                    // Moses Newman 01/08/2014 DO NOT CREATE AN INTEREST OVERIDE RECORD IF THE CUSTOMER IS ALREADY IN INTEREST OVERRIDE STATUS!
                    if (iACDataSet.CUSTOMER.Rows[cUSTOMERBindingSource.Position].Field<String>("CUSTOMER_INT_OVERRIDE") == "Y" && !lbAlreadyIntOverride)
                    {
                        loLastIntOverideZero = cUSTHISTTableAdapter.IsLastRateChangeZero(lsCustKey);
                        if (loLastIntOverideZero != null)
                            lbInterestOveride = ((Int32)loLastIntOverideZero == 1) ? true : false;
                        if (!lbInterestOveride)
                        {
                            PaymentBindingSource.DataSource = iACDataSet.PAYMENT;
                            PaymentBindingSource.AddNew();
                            PaymentBindingSource.EndEdit();

                            iACDataSet.PAYMENT.Rows[PaymentBindingSource.Position].SetField<String>("PAYMENT_CUSTOMER", lsCustKey);
                            iACDataSet.PAYMENT.Rows[PaymentBindingSource.Position].SetField<String>("PAYMENT_ADD_ON", " ");
                            iACDataSet.PAYMENT.Rows[PaymentBindingSource.Position].SetField<String>("PAYMENT_IAC_TYPE", "C");
                            iACDataSet.PAYMENT.Rows[PaymentBindingSource.Position].SetField<DateTime>("PAYMENT_DATE", DateTime.Now.Date);
                            iACDataSet.PAYMENT.Rows[PaymentBindingSource.Position].SetField<String>("PAYMENT_POST_INDICATOR", " ");
                            iACDataSet.PAYMENT.Rows[PaymentBindingSource.Position].SetField<Int32>("PAYMENT_DEALER", iACDataSet.CUSTOMER.Rows[cUSTOMERBindingSource.Position].Field<Int32>("CUSTOMER_DEALER"));
                            iACDataSet.PAYMENT.Rows[PaymentBindingSource.Position].SetField<String>("PAYMENT_TYPE", "F");
                            iACDataSet.PAYMENT.Rows[PaymentBindingSource.Position].SetField<String>("PAYMENT_CODE_2", " ");
                            iACDataSet.PAYMENT.Rows[PaymentBindingSource.Position].SetField<String>("PAYMENT_AUTO_PAY", iACDataSet.CUSTOMER.Rows[cUSTOMERBindingSource.Position].Field<String>("CUSTOMER_AUTOPAY"));
                            iACDataSet.PAYMENT.Rows[PaymentBindingSource.Position].SetField<String>("PAYMENT_TSB_COMMENT_CODE", "");
                            iACDataSet.PAYMENT.Rows[PaymentBindingSource.Position].SetField<Decimal>("PAYMENT_AMOUNT_RCV", 0);

                            PaymentBindingSource.EndEdit();
                            PAYMENTTableAdapter.Connection = tableAdapConn;
                            PAYMENTTableAdapter.Transaction = tableAdapTran;
                            PAYMENTTableAdapter.Update(iACDataSet.PAYMENT.Rows[PaymentBindingSource.Position]);
                            /*//This code gets the next available sequence number for todays date if another history record for today exists
                            loCustHistSeq = cUSTHISTTableAdapter.SeqNoQuery(lsCustKey, DateTime.Now.Date);
                            if (loCustHistSeq != null)
                                lnSeq = (int)loCustHistSeq + 1;
                            else
                                lnSeq = 1;
                            ldCustDate = DateTime.Now.Date;
                            // If any history records with the same customer no already exist in the DataTable, we must check IT for the last sequence number.
                            lsExpression = "CUSTHIST_NO = \'" + lsCustKey + "\' and CUSTHIST_PAY_DATE = \'" + ldCustDate.ToShortDateString() + "\' and max(custhist_date_seq) > 0";
                            lsSort = "custhist_date_seq desc";
                            FoundItems = iACDataSet.CUSTHIST.Select(lsExpression, lsSort);

                            if (FoundItems.Length != 0)
                            {
                                lnSeq = FoundItems[0].Field<Int32>("CUSTHIST_DATE_SEQ") + 1;
                            }
                            cUSTHISTBindingSource.AddNew();
                            cUSTHISTBindingSource.EndEdit();

                            iACDataSet.CUSTHIST.Rows[cUSTHISTBindingSource.Position].SetField<String>("CUSTHIST_NO", lsCustKey);
                            iACDataSet.CUSTHIST.Rows[cUSTHISTBindingSource.Position].SetField<DateTime>("CUSTHIST_PAY_DATE", DateTime.Now.Date);
                            iACDataSet.CUSTHIST.Rows[cUSTHISTBindingSource.Position].SetField<Int32>("CUSTHIST_DATE_SEQ", lnSeq);
                            // Moses Newman 03/15/2018 Added TransactionDate, Fee, FromIVR
                            iACDataSet.CUSTHIST.Rows[cUSTHISTBindingSource.Position].SetField<DateTime>("TransactionDate", DateTime.Now.Date);
                            iACDataSet.CUSTHIST.Rows[cUSTHISTBindingSource.Position].SetField<Decimal>("Fee", 0);
                            iACDataSet.CUSTHIST.Rows[cUSTHISTBindingSource.Position].SetField<Boolean>("FromIVR", false);
                            iACDataSet.CUSTHIST.Rows[cUSTHISTBindingSource.Position].SetField<String>("CUSTHIST_ACT_STAT", iACDataSet.CUSTOMER.Rows[cUSTOMERBindingSource.Position].Field<String>("CUSTOMER_ACT_STAT"));
                            iACDataSet.CUSTHIST.Rows[cUSTHISTBindingSource.Position].SetField<Decimal>("CUSTHIST_BALANCE", iACDataSet.CUSTOMER.Rows[cUSTOMERBindingSource.Position].Field<Decimal>("CUSTOMER_BALANCE"));
                            iACDataSet.CUSTHIST.Rows[cUSTHISTBindingSource.Position].SetField<Decimal>("CUSTHIST_PAID_DISCOUNT", Convert.ToDecimal(iACDataSet.CUSTOMER.Rows[cUSTOMERBindingSource.Position].Field<Double>("CUSTOMER_PAID_DISCOUNT")));
                            iACDataSet.CUSTHIST.Rows[cUSTHISTBindingSource.Position].SetField<Decimal>("CUSTHIST_PAID_INTEREST", iACDataSet.CUSTOMER.Rows[cUSTOMERBindingSource.Position].Field<Decimal>("CUSTOMER_PAID_INTEREST"));
                            iACDataSet.CUSTHIST.Rows[cUSTHISTBindingSource.Position].SetField<Decimal>("CUSTHIST_PAYMENT_RCV", 0);
                            iACDataSet.CUSTHIST.Rows[cUSTHISTBindingSource.Position].SetField<Decimal>("CUSTHIST_LATE_CHARGE", 0);
                            iACDataSet.CUSTHIST.Rows[cUSTHISTBindingSource.Position].SetField<Decimal>("CUSTHIST_LATE_CHARGE_BAL", iACDataSet.CUSTOMER.Rows[cUSTOMERBindingSource.Position].Field<Decimal>("CUSTOMER_LATE_CHARGE_BAL"));
                            iACDataSet.CUSTHIST.Rows[cUSTHISTBindingSource.Position].SetField<Decimal>("CUSTHIST_LATE_CHARGE_PAID", 0);
                            iACDataSet.CUSTHIST.Rows[cUSTHISTBindingSource.Position].SetField<Decimal>("CUSTHIST_BUYOUT", iACDataSet.CUSTOMER.Rows[cUSTOMERBindingSource.Position].Field<Decimal>("CUSTOMER_BUYOUT"));
                            iACDataSet.CUSTHIST.Rows[cUSTHISTBindingSource.Position].SetField<String>("CUSTHIST_AUTO_PAY", iACDataSet.CUSTOMER.Rows[cUSTOMERBindingSource.Position].Field<String>("CUSTOMER_AUTOPAY"));
                            iACDataSet.CUSTHIST.Rows[cUSTHISTBindingSource.Position].SetField<String>("CUSTHIST_PAY_REM_1", "RTCHG");
                            iACDataSet.CUSTHIST.Rows[cUSTHISTBindingSource.Position].SetField<Int32>("CUSTHIST_PAY_REM_2", iACDataSet.CUSTOMER.Rows[cUSTOMERBindingSource.Position].Field<Int32>("CUSTOMER_PAY_REM_2"));
                            iACDataSet.CUSTHIST.Rows[cUSTHISTBindingSource.Position].SetField<String>("CUSTHIST_PAYMENT_TYPE", "F");
                            iACDataSet.CUSTHIST.Rows[cUSTHISTBindingSource.Position].SetField<String>("CUSTHIST_PAYMENT_CODE", "");
                            iACDataSet.CUSTHIST.Rows[cUSTHISTBindingSource.Position].SetField<Decimal>("CUSTHIST_CONTRACT_STATUS", iACDataSet.CUSTOMER.Rows[cUSTOMERBindingSource.Position].Field<Decimal>("CUSTOMER_CONTRACT_STATUS"));
                            iACDataSet.CUSTHIST.Rows[cUSTHISTBindingSource.Position].SetField<String>("CUSTHIST_PAID_THRU", iACDataSet.CUSTOMER.Rows[cUSTOMERBindingSource.Position].Field<String>("CUSTOMER_PAID_THRU"));
                            iACDataSet.CUSTHIST.Rows[cUSTHISTBindingSource.Position].SetField<Decimal>("TVRateChange", 0);
                            cUSTHISTBindingSource.EndEdit();

                            cUSTHISTTableAdapter.Connection = tableAdapConn;
                            cUSTHISTTableAdapter.Transaction = tableAdapTran;
                            cUSTHISTTableAdapter.Update(iACDataSet.CUSTHIST.Rows[cUSTHISTBindingSource.Position]);*/
                        }
                    }
                    else
                    {
                        if (iACDataSet.CUSTOMER.Rows[cUSTOMERBindingSource.Position].Field<String>("CUSTOMER_INT_OVERRIDE") == "N")
                        {
                            loLastIntOverideZero = cUSTHISTTableAdapter.IsLastRateChangeZero(lsCustKey);
                            if (loLastIntOverideZero != null)
                                lbInterestOveride = ((Int32)loLastIntOverideZero == 1) ? true : false;
                            // Last interest overide record exists and was zero
                            if (lbInterestOveride)
                            {
                                PaymentBindingSource.DataSource = iACDataSet.PAYMENT;
                                PaymentBindingSource.AddNew();
                                PaymentBindingSource.EndEdit();

                                iACDataSet.PAYMENT.Rows[PaymentBindingSource.Position].SetField<String>("PAYMENT_CUSTOMER", lsCustKey);
                                iACDataSet.PAYMENT.Rows[PaymentBindingSource.Position].SetField<String>("PAYMENT_ADD_ON", " ");
                                iACDataSet.PAYMENT.Rows[PaymentBindingSource.Position].SetField<String>("PAYMENT_IAC_TYPE", "C");
                                iACDataSet.PAYMENT.Rows[PaymentBindingSource.Position].SetField<DateTime>("PAYMENT_DATE", DateTime.Now.Date);
                                iACDataSet.PAYMENT.Rows[PaymentBindingSource.Position].SetField<String>("PAYMENT_POST_INDICATOR", " ");
                                iACDataSet.PAYMENT.Rows[PaymentBindingSource.Position].SetField<Int32>("PAYMENT_DEALER", iACDataSet.CUSTOMER.Rows[cUSTOMERBindingSource.Position].Field<Int32>("CUSTOMER_DEALER"));
                                iACDataSet.PAYMENT.Rows[PaymentBindingSource.Position].SetField<String>("PAYMENT_TYPE", "F");
                                iACDataSet.PAYMENT.Rows[PaymentBindingSource.Position].SetField<String>("PAYMENT_CODE_2", " ");
                                iACDataSet.PAYMENT.Rows[PaymentBindingSource.Position].SetField<String>("PAYMENT_AUTO_PAY", iACDataSet.CUSTOMER.Rows[cUSTOMERBindingSource.Position].Field<String>("CUSTOMER_AUTOPAY"));
                                iACDataSet.PAYMENT.Rows[PaymentBindingSource.Position].SetField<String>("PAYMENT_TSB_COMMENT_CODE", "");
                                iACDataSet.PAYMENT.Rows[PaymentBindingSource.Position].SetField<Decimal>("PAYMENT_AMOUNT_RCV", 0);

                                PaymentBindingSource.EndEdit();
                                PAYMENTTableAdapter.Connection = tableAdapConn;
                                PAYMENTTableAdapter.Transaction = tableAdapTran;
                                PAYMENTTableAdapter.Update(iACDataSet.PAYMENT.Rows[PaymentBindingSource.Position]);

                                /*
                                //This code gets the next available sequence number for todays date if another history record for today exists
                                loCustHistSeq = cUSTHISTTableAdapter.SeqNoQuery(lsCustKey, DateTime.Now.Date);
                                if (loCustHistSeq != null)
                                    lnSeq = (int)loCustHistSeq + 1;
                                else
                                    lnSeq = 1;
                                ldCustDate = DateTime.Now.Date;
                                // If any history records with the same customer no already exist in the DataTable, we must check IT for the last sequence number.
                                lsExpression = "CUSTHIST_NO = \'" + lsCustKey + "\' and CUSTHIST_PAY_DATE = \'" + ldCustDate.ToShortDateString() + "\' and max(custhist_date_seq) > 0";
                                lsSort = "custhist_date_seq desc";
                                FoundItems = iACDataSet.CUSTHIST.Select(lsExpression, lsSort);

                                if (FoundItems.Length != 0)
                                {
                                    lnSeq = FoundItems[0].Field<Int32>("CUSTHIST_DATE_SEQ") + 1;
                                }

                                cUSTHISTBindingSource.AddNew();
                                cUSTHISTBindingSource.EndEdit();

                                iACDataSet.CUSTHIST.Rows[cUSTHISTBindingSource.Position].SetField<String>("CUSTHIST_NO", lsCustKey);
                                iACDataSet.CUSTHIST.Rows[cUSTHISTBindingSource.Position].SetField<DateTime>("CUSTHIST_PAY_DATE", DateTime.Now.Date);
                                iACDataSet.CUSTHIST.Rows[cUSTHISTBindingSource.Position].SetField<Int32>("CUSTHIST_DATE_SEQ", lnSeq);
                                // Moses Newman 03/15/2018 Added TransactionDate, Fee, FromIVR
                                iACDataSet.CUSTHIST.Rows[cUSTHISTBindingSource.Position].SetField<DateTime>("TransactionDate", DateTime.Now.Date);
                                iACDataSet.CUSTHIST.Rows[cUSTHISTBindingSource.Position].SetField<Decimal>("Fee", 0);
                                iACDataSet.CUSTHIST.Rows[cUSTHISTBindingSource.Position].SetField<Boolean>("FromIVR", false);
                                iACDataSet.CUSTHIST.Rows[cUSTHISTBindingSource.Position].SetField<String>("CUSTHIST_ACT_STAT", iACDataSet.CUSTOMER.Rows[cUSTOMERBindingSource.Position].Field<String>("CUSTOMER_ACT_STAT"));
                                iACDataSet.CUSTHIST.Rows[cUSTHISTBindingSource.Position].SetField<Decimal>("CUSTHIST_BALANCE", iACDataSet.CUSTOMER.Rows[cUSTOMERBindingSource.Position].Field<Decimal>("CUSTOMER_BALANCE"));
                                iACDataSet.CUSTHIST.Rows[cUSTHISTBindingSource.Position].SetField<Decimal>("CUSTHIST_PAID_DISCOUNT", Convert.ToDecimal(iACDataSet.CUSTOMER.Rows[cUSTOMERBindingSource.Position].Field<Double>("CUSTOMER_PAID_DISCOUNT")));
                                iACDataSet.CUSTHIST.Rows[cUSTHISTBindingSource.Position].SetField<Decimal>("CUSTHIST_PAID_INTEREST", iACDataSet.CUSTOMER.Rows[cUSTOMERBindingSource.Position].Field<Decimal>("CUSTOMER_PAID_INTEREST"));
                                iACDataSet.CUSTHIST.Rows[cUSTHISTBindingSource.Position].SetField<Decimal>("CUSTHIST_PAYMENT_RCV", 0);
                                iACDataSet.CUSTHIST.Rows[cUSTHISTBindingSource.Position].SetField<Decimal>("CUSTHIST_LATE_CHARGE", 0);
                                iACDataSet.CUSTHIST.Rows[cUSTHISTBindingSource.Position].SetField<Decimal>("CUSTHIST_LATE_CHARGE_BAL", iACDataSet.CUSTOMER.Rows[cUSTOMERBindingSource.Position].Field<Decimal>("CUSTOMER_LATE_CHARGE_BAL"));
                                iACDataSet.CUSTHIST.Rows[cUSTHISTBindingSource.Position].SetField<Decimal>("CUSTHIST_LATE_CHARGE_PAID", 0);
                                iACDataSet.CUSTHIST.Rows[cUSTHISTBindingSource.Position].SetField<Decimal>("CUSTHIST_BUYOUT", iACDataSet.CUSTOMER.Rows[cUSTOMERBindingSource.Position].Field<Decimal>("CUSTOMER_BUYOUT"));
                                iACDataSet.CUSTHIST.Rows[cUSTHISTBindingSource.Position].SetField<String>("CUSTHIST_AUTO_PAY", iACDataSet.CUSTOMER.Rows[cUSTOMERBindingSource.Position].Field<String>("CUSTOMER_AUTOPAY"));
                                iACDataSet.CUSTHIST.Rows[cUSTHISTBindingSource.Position].SetField<String>("CUSTHIST_PAY_REM_1", "RTCHG");
                                iACDataSet.CUSTHIST.Rows[cUSTHISTBindingSource.Position].SetField<Int32>("CUSTHIST_PAY_REM_2", iACDataSet.CUSTOMER.Rows[cUSTOMERBindingSource.Position].Field<Int32>("CUSTOMER_PAY_REM_2"));
                                iACDataSet.CUSTHIST.Rows[cUSTHISTBindingSource.Position].SetField<String>("CUSTHIST_PAYMENT_TYPE", "F");
                                iACDataSet.CUSTHIST.Rows[cUSTHISTBindingSource.Position].SetField<String>("CUSTHIST_PAYMENT_CODE", "");
                                iACDataSet.CUSTHIST.Rows[cUSTHISTBindingSource.Position].SetField<Decimal>("CUSTHIST_CONTRACT_STATUS", iACDataSet.CUSTOMER.Rows[cUSTOMERBindingSource.Position].Field<Decimal>("CUSTOMER_CONTRACT_STATUS"));
                                iACDataSet.CUSTHIST.Rows[cUSTHISTBindingSource.Position].SetField<String>("CUSTHIST_PAID_THRU", iACDataSet.CUSTOMER.Rows[cUSTOMERBindingSource.Position].Field<String>("CUSTOMER_PAID_THRU"));
                                // TURN INTEREST BACK ON!
                                iACDataSet.CUSTHIST.Rows[cUSTHISTBindingSource.Position].SetField<Decimal>("TVRateChange", iACDataSet.CUSTOMER.Rows[cUSTOMERBindingSource.Position].Field<Decimal>("CUSTOMER_ANNUAL_PERCENTAGE_RATE"));
                                cUSTHISTBindingSource.EndEdit();

                                cUSTHISTTableAdapter.Connection = tableAdapConn;
                                cUSTHISTTableAdapter.Transaction = tableAdapTran;
                                cUSTHISTTableAdapter.Update(iACDataSet.CUSTHIST.Rows[cUSTHISTBindingSource.Position]);
                                */
                            }
                        }
                    }
                }
                aLTNAMETableAdapter.Connection = tableAdapConn;
                aLTNAMETableAdapter.Transaction = tableAdapTran;
                aLTNAMETableAdapter.Update(iACDataSet.ALTNAME.Rows[ALTNAMEbindingSource.Position]);

                oPNBANKTableAdapter.Connection = tableAdapConn;
                oPNBANKTableAdapter.Transaction = tableAdapTran;
                oPNBANKTableAdapter.Update(iACDataSet.OPNBANK.Rows[OPNBANKbindingSource.Position]);

                vEHICLETableAdapter.Connection = tableAdapConn;
                vEHICLETableAdapter.Transaction = tableAdapTran;
                vEHICLETableAdapter.Update(iACDataSet.VEHICLE.Rows[VehiclebindingSource.Position]);

                //Program.UpdateComments(ref iACDataSet, ref cOMMENTBindingSource);

                cOMMENTTableAdapter.Connection = tableAdapConn;
                cOMMENTTableAdapter.Transaction = tableAdapTran;
                cOMMENTTableAdapter.Update(iACDataSet.COMMENT);  // Delete, Update, and Insert all the customers comment records!


                // Moses Newman 12/23/2013 Add Email address             
                emailTableAdapter.Connection = tableAdapConn;
                emailTableAdapter.Transaction = tableAdapTran;
                emailTableAdapter.Update(iACDataSet.Email.Rows[EmailbindingSource.Position]);

                // Moses Newman 06/12/2018 Add CustomerFees
                CustomerFeesTableAdapter.Connection = tableAdapConn;
                CustomerFeesTableAdapter.Transaction = tableAdapTran;
                CustomerFeesTableAdapter.Update(iACDataSet.CustomerFees.Rows[CustomerFeesBindingSource.Position]);

                // Moses Newman 08/13/2020 Add save of TSB data
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
                cUSTOMERTableAdapter.UnlockRecord(iACDataSet.CUSTOMER.Rows[cUSTOMERBindingSource.Position].Field<String>("CUSTOMER_NO"));
                MessageBox.Show("There is a Micriosft SQL Server database error " + ex.Message.ToString());
            }
            catch (System.InvalidOperationException ex)
            {
                tableAdapTran.Rollback();
                cUSTOMERTableAdapter.UnlockRecord(iACDataSet.CUSTOMER.Rows[cUSTOMERBindingSource.Position].Field<String>("CUSTOMER_NO"));
                MessageBox.Show("Error: " + ex.Message.ToString());
            }
            catch (System.Data.DBConcurrencyException ex)
            {
                tableAdapTran.Rollback();
                cUSTOMERTableAdapter.UnlockRecord(iACDataSet.CUSTOMER.Rows[cUSTOMERBindingSource.Position].Field<String>("CUSTOMER_NO"));
                MessageBox.Show("Error: " + ex.Message.ToString());
            }
            finally
            {
                cUSTOMERTableAdapter.UnlockRecord(iACDataSet.CUSTOMER.Rows[cUSTOMERBindingSource.Position].Field<String>("CUSTOMER_NO"));
                tableAdapConn.Close();
                tableAdapConn = null;
                tableAdapTran = null;
                toolStripButtonSave.Enabled = false;
                Program.gsKey = null;
                lbAddFlag = false;
                lbEdit = false;
            }
            SetViewMode();
            gbInSave = false;
        }

        private void barButtonItem1_ItemClick(object sender, ItemClickEventArgs e)
        {
            if (iACDataSet.CUSTOMER.Rows.Count < 1)
                return;
            Double lnAnnualPercentageRate = 0, lnLoanInterest = 0, lnTotal = 0;
            MDIIAC2013 MDImain = (MDIIAC2013)MdiParent;
            //MDImain.CreateFormInstance("ReportViewer", false);
            //ReportViewer rptViewr = (ReportViewer)MDImain.ActiveMdiChild;
            switch (iACDataSet.CUSTOMER.Rows[0].Field<String>("CUSTOMER_AMORTIZE_IND"))
            {
                case " ":
                    MessageBox.Show("Older account, amortization does not apply.");
                    break;
                case "A":
                    Double lnApr = (Double)(iACDataSet.CUSTOMER.Rows[0].Field<Decimal>("CUSTOMER_ANNUAL_PERCENTAGE_RATE") / 100),
                            lnCash = (Double)iACDataSet.CUSTOMER.Rows[0].Field<Decimal>("CUSTOMER_LOAN_CASH"),
                            lnRegularAmount = (Double)iACDataSet.CUSTOMER.Rows[0].Field<Decimal>("CUSTOMER_REGULAR_AMOUNT"),
                            lnTerm = (Double)iACDataSet.CUSTOMER.Rows[0].Field<Int32>("CUSTOMER_TERM");
                    // Moses Newman 01/21/2015 Add Contract Date Handling!
                    DateTime ldStartDate = iACDataSet.CUSTOMER.Rows[0].Field<DateTime>("ContractDate"),
                             ldFirstPaymentDate = iACDataSet.CUSTOMER.Rows[0].Field<DateTime>("CUSTOMER_INIT_DATE");
                    ClosedPaymentPosting CP = new ClosedPaymentPosting();
                    BackgroundWorker worker = new BackgroundWorker();

                    IACDataSetTableAdapters.AmortTempTableAdapter AmortTempTableAdapter = new IACDataSetTableAdapters.AmortTempTableAdapter();

                    AmortTempTableAdapter.FillByCustomer(iACDataSet.AmortTemp, iACDataSet.CUSTOMER.Rows[0].Field<String>("CUSTOMER_NO"));

                    Program.AmortRec[] loAmortRec;
                    String lsMessage = "";
                    loAmortRec = new Program.AmortRec[Convert.ToInt32(lnTerm)];

                    if (iACDataSet.AmortTemp.Rows.Count == 0 && !checkBoxSimple.Checked)
                    {
                        // Moses Newman 01/21/2015 Add Contract Date Handling!
                        // Moses Newman 08/23/2021
                        Program.TVAmortize(ldStartDate, ldFirstPaymentDate, ref lnCash, ref lnTerm, ref lnApr, ref lnRegularAmount, ref lsMessage, ref loAmortRec, false, iACDataSet.CUSTOMER.Rows[0].Field<String>("CUSTOMER_NO"), true);
                        AmortTempTableAdapter.FillByCustomer(iACDataSet.AmortTemp, iACDataSet.CUSTOMER.Rows[0].Field<String>("CUSTOMER_NO"));
                    }
                    worker.Dispose();
                    CP.Dispose();
                    CP = null;
                    // Moses Newman 07/12m/2022 Covert to XtraReport
                    var report = new XtraReportTVAmortizationDistribution();
                    SqlDataSource ds = report.DataSource as SqlDataSource;

                    ds.Queries[0].Parameters[0].Value = "99-" + Program.gsUserID;

                    report.DataSource = ds;
                    report.RequestParameters = false;
                    if (!checkBoxSimple.Checked)
                        report.Parameters["CompoundPeriod"].Value = "Compound Daily";
                    else
                        report.Parameters["CompoundPeriod"].Value = "Daily Exact";
                    report.Parameters["APR"].Value = iACDataSet.CUSTOMER.Rows[0].Field<Decimal>("CUSTOMER_ANNUAL_PERCENTAGE_RATE") / 100;
                    report.Parameters["EffectiveAnnualRate"].Value = Math.Round(Math.Pow((1 + ((Double)(iACDataSet.CUSTOMER.Rows[0].Field<Decimal>("CUSTOMER_ANNUAL_PERCENTAGE_RATE") / 100) / 12)), 12), 8) - 1;
                    report.Parameters["Term"].Value = iACDataSet.CUSTOMER.Rows[0].Field<Int32>("CUSTOMER_TERM");
                    report.Parameters["FirstPaymentDate"].Value = iACDataSet.CUSTOMER.Rows[0].Field<DateTime>("CUSTOMER_INIT_DATE");
                    report.Parameters["gsUserID"].Value = Program.gsUserID;
                    report.Parameters["gsUserName"].Value = Program.gsUserName;
                    report.Parameters["CustomerPrint"].Value = true;
                    report.Parameters["gsCustomer"].Value = iACDataSet.CUSTOMER.Rows[0].Field<String>("CUSTOMER_NO");


                    var tool = new ReportPrintTool(report);

                    tool.PreviewRibbonForm.MdiParent = MDImain;
                    tool.AutoShowParametersPanel = false;
                    tool.PreviewRibbonForm.WindowState = FormWindowState.Maximized;
                    tool.ShowRibbonPreview();
                    break;
                case "S":
                case "N":
                    // Moses Newman 08/28/2013 Make sure Amortization Date is always >= the last transaction date or TimeValue will crash.
                    Object loLastDate = cUSTHISTTableAdapter.LastTransactionDate(iACDataSet.CUSTOMER.Rows[0].Field<String>("CUSTOMER_NO"));
                    IACDataSetTableAdapters.TVAmortTableAdapter TVAmortTableAdapter = new IACDataSetTableAdapters.TVAmortTableAdapter();
                    // Moses Newman 08/23/2013 Variables added to handle Amort date always >= last tran date
                    DateTime ldAmortDate = DateTime.Now.Date, ldLastDate = ldAmortDate;
                    if (loLastDate != null)
                        ldLastDate = (DateTime)loLastDate;
                    if (ldLastDate > DateTime.Now.Date)
                        ldAmortDate = ldLastDate;
                    // Moses Newman 06/24/2014 Changed tbSave to true so that TV5 file is created matching Amort History
                    // Moses Newman 04/30/2017 change true for simple interest to checkbox value!
                    Program.TVSimpleGetBuyout(iACDataSet,
                            ldAmortDate,
                            (Double)iACDataSet.CUSTOMER.Rows[0].Field<Int32>("CUSTOMER_TERM"),
                            (Double)(iACDataSet.CUSTOMER.Rows[0].Field<Decimal>("CUSTOMER_ANNUAL_PERCENTAGE_RATE") / 100),
                            (Double)iACDataSet.CUSTOMER.Rows[0].Field<Decimal>("CUSTOMER_REGULAR_AMOUNT"),
                            iACDataSet.CUSTOMER.Rows[0].Field<String>("CUSTOMER_NO"),
                            checkBoxSimple.Checked, true, false, false);

                    TVAmortTableAdapter.FillByCustomerNo(iACDataSet.TVAmort, iACDataSet.CUSTOMER.Rows[0].Field<String>("CUSTOMER_NO"));
                    TVAPRInfoTableAdapter.Fill(iACDataSet.TVAPRInfo, "99-" + Program.gsUserID);
                    if (iACDataSet.TVAPRInfo.Rows.Count > 0)
                    {
                        lnAnnualPercentageRate = (Double)iACDataSet.TVAPRInfo.Rows[0].Field<Decimal>("APR");
                        lnCash = (Double)iACDataSet.TVAPRInfo.Rows[0].Field<Decimal>("AmountFinanced");
                        lnLoanInterest = (Double)iACDataSet.TVAPRInfo.Rows[0].Field<Decimal>("FinanceCharge");
                        lnTotal = (Double)iACDataSet.TVAPRInfo.Rows[0].Field<Decimal>("TotalofPayments");
                    }
                    // Moses Newman 07/11/2022 Covert to XtraReport
                    var reportA = new XtraReportTVAmortizationDistribution();
                    SqlDataSource dsA = reportA.DataSource as SqlDataSource;

                    //dsA.Queries[0].Parameters[0].Value = iACDataSet.CUSTOMER.Rows[0].Field<String>("CUSTOMER_NO");
                    //dsA.Queries[1].Parameters[0].Value = iACDataSet.CUSTOMER.Rows[0].Field<String>("CUSTOMER_NO");

                    reportA.DataSource = dsA;
                    reportA.RequestParameters = false;
                    if (!checkBoxSimple.Checked)
                        reportA.Parameters["CompoundPeriod"].Value = "Daily Exact";
                    else
                        reportA.Parameters["CompoundPeriod"].Value = "Exact Days";
                    reportA.Parameters["APR"].Value = iACDataSet.CUSTOMER.Rows[0].Field<Decimal>("CUSTOMER_ANNUAL_PERCENTAGE_RATE") / 100;
                    reportA.Parameters["EffectiveAnnualRate"].Value = Math.Round(Math.Pow((1 + ((Double)(iACDataSet.CUSTOMER.Rows[0].Field<Decimal>("CUSTOMER_ANNUAL_PERCENTAGE_RATE") / 100) / 12)), 12), 8) - 1;
                    reportA.Parameters["Term"].Value = iACDataSet.CUSTOMER.Rows[0].Field<Int32>("CUSTOMER_TERM");
                    reportA.Parameters["FirstPaymentDate"].Value = iACDataSet.CUSTOMER.Rows[0].Field<DateTime>("ContractDate");
                    reportA.Parameters["gsUserID"].Value = Program.gsUserID;
                    reportA.Parameters["gsUserName"].Value = Program.gsUserName;
                    reportA.Parameters["CustomerPrint"].Value = true;
                    reportA.Parameters["gsCustomer"].Value = iACDataSet.CUSTOMER.Rows[0].Field<String>("CUSTOMER_NO");
                    reportA.Parameters["IsSimple"].Value = checkBoxSimple.Checked;

                    var toolA = new ReportPrintTool(reportA);

                    toolA.PreviewRibbonForm.MdiParent = MDImain;
                    toolA.AutoShowParametersPanel = false;
                    toolA.PreviewRibbonForm.WindowState = FormWindowState.Maximized;
                    toolA.ShowRibbonPreview();
                    break;
            }

        }

        private void barButtonItemPrintCustomerReceipt_ItemClick(object sender, ItemClickEventArgs e)
        {
            MDIIAC2013 MDImain = (MDIIAC2013)MdiParent;
            MDImain.CreateFormInstance("FormReciept", false, false, true);
            FormReciept receipt = (FormReciept)MDImain.frm;

            receipt.gsCustomerNo = cUSTOMER_NOTextBox.EditValue.ToString().Trim();
            receipt.gsOpenClose = "C";
            receipt.Show();
        }

        private void barButtonItemTimeValueToExcel_ItemClick(object sender, ItemClickEventArgs e)
        {
            // Moses Newman 04/02/2018 Create EXCEL output dump of TVAmort file showing GetPartialPaymentandLateFeeBalance extra fields.
            IACDataSet PT = new IACDataSet();
            IACDataSetTableAdapters.TVAmortTableAdapter TVAmortTableAdapter = new IACDataSetTableAdapters.TVAmortTableAdapter();
            TVAmortTableAdapter.FillByCustomerNo(iACDataSet.TVAmort, cUSTOMER_NOTextBox.EditValue.ToString().Trim());

            BackgroundWorker BW = new BackgroundWorker();
            ClosedPaymentPosting CP = new ClosedPaymentPosting();

            CP.NewGetPartialPaymentandLateFeeBalance(cUSTOMER_NOTextBox.EditValue.ToString().Trim(), ref PT, 0, false, -1, false, false);

            SqlConnection cnn;
            string connectionstring = null;
            string sql = null;
            string data = null;
            int i = 0;
            int j = 0;

            String lsUNCROOT = Program.GsDataPath, lsExcelFileOut = lsUNCROOT + @"\moses\TVEXCEL\" + cUSTOMER_NOTextBox.EditValue.ToString().Trim() + "TVAmort.xlsx";
            connectionstring = IAC2021SQL.Properties.Settings.Default.IAC2010SQLConnectionString.ToUpper();
            cnn = new SqlConnection(connectionstring);
            cnn.Open();
            //sql = "SELECT * FROM TVAmort WHERE CustomerNo = '" + cUSTOMER_NOTextBox.EditValue.ToString().Trim() + "'";
            // Moses Newman 07/25/2019 Order By CUSTHIST order.
            // Moses Newman 12/27/2023 Reorder by ID and window Row Number over ID
            sql = "SELECT [CustomerNo],ROW_NUMBER() OVER(ORDER BY ID)[RowNumber], " +
                        " [Event],[HistoryDate] [Date],[New],[LateFee],[ISF],[NonCash],[Payment],[Interest],[Principal],[Balance],[RateChange],[ContractStatus]," +
                        " [PartialPayment], [LateFeeBalance],[PaidThrough],[ExtensionMonths],[LastPPBBalance],[LastLFBalance],[LastPPBUsed],[LastPPBUsedLC],[PrevPPBUsed],[PrevPPBUsedLC]," +
                        " [DeltaPTMonths],[ISFDate],[ISFSeqNo],[ISFPaymentType],[ISFPaymentCode],[HistorySeq],[PaymentSeq],[PaymentCode],[HistoryDate] " +
                        " FROM [TVAmort] " +
                        " WHERE CustomerNo = '" + cUSTOMER_NOTextBox.EditValue.ToString().Trim() + "' ORDER BY ID";
            SqlDataAdapter dscmd = new SqlDataAdapter(sql, cnn);
            DataSet ds = new DataSet();
            dscmd.Fill(ds);

            if (File.Exists(lsExcelFileOut))
                File.Delete(lsExcelFileOut);

            if (!File.Exists(lsExcelFileOut))
            {
                // Moses Newman 01/30/2017 Add Excel Automation column and page formatting
                //Create an Excel application instance
                Excel.Application excelApp = new Excel.Application();

                //Create an Excel workbook open excel workbook
                Excel.Workbook excelWorkBook = excelApp.Workbooks.Add();

                //Add a new worksheet to workbook with the Datatable name

                excelApp.Visible = true;
                excelApp.WindowState = Excel.XlWindowState.xlMinimized;
                excelApp.WindowState = Excel.XlWindowState.xlMaximized;

                Excel.Worksheet excelWorkSheet;
                excelWorkSheet = excelWorkBook.Worksheets.Add();
                excelWorkSheet.Name = cUSTOMER_NOTextBox.EditValue.ToString().Trim() + "TVAmort";
                foreach (Excel.Worksheet sheet in excelWorkBook.Worksheets)
                    if (sheet.Name != excelWorkSheet.Name)
                        sheet.Delete();
                excelWorkSheet.Select(System.Type.Missing);

                for (i = 0; i < ds.Tables[0].Rows.Count; i++)
                {
                    for (j = 0; j < ds.Tables[0].Columns.Count; j++)
                    {
                        data = ds.Tables[0].Rows[i].ItemArray[j].ToString();
                        excelWorkSheet.Cells[i + 2, j + 1] = data;
                    }
                }



                excelWorkSheet.PageSetup.CenterHeader = "&\"Arial\"&B&12&KFF0000" + cUSTOMER_NOTextBox.EditValue.ToString().Trim() + "TVAmort";
                excelWorkSheet.Visible = Excel.XlSheetVisibility.xlSheetVisible;

                Excel.Range CustomerNo = excelWorkSheet.get_Range("A:A");
                CustomerNo.Columns.EntireColumn.AutoFit();
                CustomerNo.Columns.ColumnWidth = 6.14;
                excelWorkSheet.get_Range("A1:A1").Font.FontStyle = "Bold";
                excelWorkSheet.get_Range("A1:A1").Value = "Account#";

                Excel.Range RowNumber = excelWorkSheet.get_Range("B:B");
                RowNumber.Columns.EntireColumn.AutoFit();
                RowNumber.Columns.ColumnWidth = 3;
                excelWorkSheet.get_Range("B1:B1").Font.FontStyle = "Bold";
                excelWorkSheet.get_Range("B1:B1").Value = "Row#";

                Excel.Range Event = excelWorkSheet.get_Range("C:C");
                Event.Columns.EntireColumn.AutoFit();
                Event.Columns.ColumnWidth = 7.57;
                excelWorkSheet.get_Range("C1:C1").Font.FontStyle = "Bold";
                excelWorkSheet.get_Range("C1:C1").Value = "Event";

                Excel.Range Date = excelWorkSheet.get_Range("D:D");
                Date.Columns.EntireColumn.AutoFit();
                Date.Columns.ColumnWidth = 11.43;
                Date.Columns.NumberFormat = "mm/dd/yyyy";
                excelWorkSheet.get_Range("D1:D1").Font.FontStyle = "Bold";
                excelWorkSheet.get_Range("D1:D1").Value = "Date";

                Excel.Range New = excelWorkSheet.get_Range("E:E");
                New.Columns.EntireColumn.AutoFit();
                New.Columns.ColumnWidth = 10.29;
                New.Columns.NumberFormat = "$#,##0.00_);[Red]($#,##0.00)";
                excelWorkSheet.get_Range("E1:E1").Font.FontStyle = "Bold";
                excelWorkSheet.get_Range("E1:E1").Value = "New";

                Excel.Range LateFee = excelWorkSheet.get_Range("F:F");
                LateFee.Columns.EntireColumn.AutoFit();
                LateFee.Columns.ColumnWidth = 11.43;
                LateFee.Columns.NumberFormat = "$#,##0.00_);[Red]($#,##0.00)";
                excelWorkSheet.get_Range("F1:F1").Font.FontStyle = "Bold";
                excelWorkSheet.get_Range("F1:F1").Value = "LateFee";

                Excel.Range ISF = excelWorkSheet.get_Range("G:G");
                ISF.Columns.EntireColumn.AutoFit();
                ISF.Columns.ColumnWidth = 7;
                ISF.Columns.NumberFormat = "$#,##0.00_);[Red]($#,##0.00)";
                excelWorkSheet.get_Range("G1:G1").Font.FontStyle = "Bold";
                excelWorkSheet.get_Range("G1:G1").Value = "ISF";

                Excel.Range NonCash = excelWorkSheet.get_Range("H:H");
                NonCash.Columns.EntireColumn.AutoFit();
                NonCash.Columns.ColumnWidth = 12.29;
                NonCash.Columns.NumberFormat = "$#,##0.00_);[Red]($#,##0.00)";
                excelWorkSheet.get_Range("H1:H1").Font.FontStyle = "Bold";
                excelWorkSheet.get_Range("H1:H1").Value = "NonCash";

                Excel.Range Payment = excelWorkSheet.get_Range("I:I");
                Payment.Columns.EntireColumn.AutoFit();
                Payment.Columns.ColumnWidth = 12.29;
                Payment.Columns.Columns.NumberFormat = "$#,##0.00_);[Red]($#,##0.00)";
                excelWorkSheet.get_Range("I1:I1").Font.FontStyle = "Bold";
                excelWorkSheet.get_Range("I1:I1").Value = "Payment";

                Excel.Range Interest = excelWorkSheet.get_Range("J:J");
                Interest.Columns.EntireColumn.AutoFit();
                Interest.Columns.ColumnWidth = 11.43;
                Interest.Columns.NumberFormat = "$#,##0.00_);[Red]($#,##0.00)";
                excelWorkSheet.get_Range("J1:J1").Font.FontStyle = "Bold";
                excelWorkSheet.get_Range("J1:J1").Value = "Interest";

                Excel.Range Principle = excelWorkSheet.get_Range("K:K");
                Principle.Columns.EntireColumn.AutoFit();
                Principle.Columns.ColumnWidth = 12.14;
                Principle.Columns.NumberFormat = "$#,##0.00_);[Red]($#,##0.00)";
                excelWorkSheet.get_Range("K1:K1").Font.FontStyle = "Bold";
                excelWorkSheet.get_Range("K1:K1").Value = "Principal";

                Excel.Range Balance = excelWorkSheet.get_Range("L:L");
                Balance.Columns.EntireColumn.AutoFit();
                Balance.Columns.ColumnWidth = 11.29;
                Balance.Columns.NumberFormat = "$#,##0.00_);[Red]($#,##0.00)";
                excelWorkSheet.get_Range("L1:L1").Font.FontStyle = "Bold";
                excelWorkSheet.get_Range("L1:L1").Value = "Balance";

                Excel.Range RateChange = excelWorkSheet.get_Range("M:M");
                RateChange.Columns.EntireColumn.AutoFit();
                RateChange.Columns.ColumnWidth = 3;
                excelWorkSheet.get_Range("M1:M1").Font.FontStyle = "Bold";
                excelWorkSheet.get_Range("M1:M1").Value = "RateChange";

                Excel.Range ContractStatus = excelWorkSheet.get_Range("N:N");
                ContractStatus.Columns.EntireColumn.AutoFit();
                ContractStatus.Columns.ColumnWidth = 12.14;
                ContractStatus.Columns.NumberFormat = "$#,##0.00_);[Red]($#,##0.00)";
                excelWorkSheet.get_Range("N1:N1").Font.FontStyle = "Bold";
                excelWorkSheet.get_Range("N1:N1").Value = "ContractStatus";

                Excel.Range PartialPayment = excelWorkSheet.get_Range("O:O");
                PartialPayment.Columns.EntireColumn.AutoFit();
                PartialPayment.Columns.ColumnWidth = 12.14;
                PartialPayment.Columns.NumberFormat = "$#,##0.00_);[Red]($#,##0.00)";
                excelWorkSheet.get_Range("O1:O1").Font.FontStyle = "Bold";
                excelWorkSheet.get_Range("O1:O1").Value = "PartialPayment";

                Excel.Range LateFeeBalance = excelWorkSheet.get_Range("P:P");
                LateFeeBalance.Columns.EntireColumn.AutoFit();
                LateFeeBalance.Columns.ColumnWidth = 12.14;
                LateFeeBalance.Columns.NumberFormat = "$#,##0.00_);[Red]($#,##0.00)";
                excelWorkSheet.get_Range("P1:P1").Font.FontStyle = "Bold";
                excelWorkSheet.get_Range("P1:P1").Value = "LateFeeBalance";

                Excel.Range PaidThrough = excelWorkSheet.get_Range("Q:Q");
                PaidThrough.Columns.EntireColumn.AutoFit();
                PaidThrough.Columns.NumberFormat = "mm/yy";
                PaidThrough.Columns.ColumnWidth = 8;
                excelWorkSheet.get_Range("Q1:Q1").Font.FontStyle = "Bold";
                excelWorkSheet.get_Range("Q1:Q1").Value = "PaidThrough";

                Excel.Range Extension = excelWorkSheet.get_Range("R:R");
                Extension.Columns.EntireColumn.AutoFit();
                Extension.Columns.ColumnWidth = 6;
                excelWorkSheet.get_Range("R1:R1").Font.FontStyle = "Bold";
                excelWorkSheet.get_Range("R1:R1").Value = "Ext";

                Excel.Range LastPPBBalance = excelWorkSheet.get_Range("S:S");
                LastPPBBalance.Columns.EntireColumn.Delete();

                Excel.Range LastLFBalance = excelWorkSheet.get_Range("S:S");
                LastLFBalance.Columns.EntireColumn.Delete();

                Excel.Range LastPPBUsed = excelWorkSheet.get_Range("S:S");
                LastPPBUsed.Columns.EntireColumn.Delete();

                Excel.Range LastPPBUsedLC = excelWorkSheet.get_Range("S:S");
                LastPPBUsedLC.Columns.EntireColumn.Delete();

                Excel.Range r1 = excelWorkSheet.get_Range("A1:AC1");
                Excel.Range r = excelWorkSheet.get_Range("A2:AC" + (ds.Tables[0].Rows.Count + 1).ToString());

                Excel.Range PrevPPBUsed = excelWorkSheet.get_Range("S:S");
                PrevPPBUsed.Columns.EntireColumn.AutoFit();
                PrevPPBUsed.Columns.ColumnWidth = 6;
                PrevPPBUsed.Columns.NumberFormat = "$#,##0.00_);[Red]($#,##0.00)";
                excelWorkSheet.get_Range("S1:S1").Font.FontStyle = "Bold";
                excelWorkSheet.get_Range("S1:S1").Value = "PrevPPBUsed";

                Excel.Range PrevPPBUsedLC = excelWorkSheet.get_Range("T:T");
                PrevPPBUsedLC.Columns.EntireColumn.AutoFit();
                PrevPPBUsedLC.Columns.ColumnWidth = 6;
                PrevPPBUsedLC.Columns.NumberFormat = "$#,##0.00_);[Red]($#,##0.00)";
                excelWorkSheet.get_Range("T1:T1").Font.FontStyle = "Bold";
                excelWorkSheet.get_Range("T1:T1").Value = "PrevPPBUsedLC";

                Excel.Range DeltaPTMonths = excelWorkSheet.get_Range("U:U");
                DeltaPTMonths.Columns.EntireColumn.AutoFit();
                DeltaPTMonths.Columns.ColumnWidth = 6;
                excelWorkSheet.get_Range("U1:U1").Font.FontStyle = "Bold";
                excelWorkSheet.get_Range("U1:U1").Value = "DeltaPTMonths";

                Excel.Range ISFDate = excelWorkSheet.get_Range("V:V");
                ISFDate.Columns.EntireColumn.AutoFit();
                ISFDate.Columns.ColumnWidth = 11.43;
                ISFDate.Columns.NumberFormat = "mm/dd/yyyy";
                excelWorkSheet.get_Range("V1:V1").Font.FontStyle = "Bold";
                excelWorkSheet.get_Range("V1:V1").Value = "ISFDate";

                Excel.Range ISFSeqNo = excelWorkSheet.get_Range("W:W");
                ISFSeqNo.Columns.EntireColumn.AutoFit();
                ISFSeqNo.Columns.ColumnWidth = 6;
                excelWorkSheet.get_Range("W1:W1").Font.FontStyle = "Bold";
                excelWorkSheet.get_Range("W1:W1").Value = "ISFSeqNo";

                Excel.Range ISFPaymentType = excelWorkSheet.get_Range("X:X");
                ISFPaymentType.Columns.EntireColumn.AutoFit();
                ISFPaymentType.Columns.ColumnWidth = 6;
                excelWorkSheet.get_Range("X1:X1").Font.FontStyle = "Bold";
                excelWorkSheet.get_Range("X1:X1").Value = "ISFPaymentType";

                Excel.Range ISFPaymentCode = excelWorkSheet.get_Range("Y:Y");
                ISFPaymentCode.Columns.EntireColumn.AutoFit();
                ISFPaymentCode.Columns.ColumnWidth = 6;
                excelWorkSheet.get_Range("Y1:Y1").Font.FontStyle = "Bold";
                excelWorkSheet.get_Range("Y1:Y1").Value = "ISFPaymentType";

                Excel.Range HistorySeq = excelWorkSheet.get_Range("Z:Z");
                HistorySeq.Columns.EntireColumn.AutoFit();
                HistorySeq.Columns.ColumnWidth = 6;
                excelWorkSheet.get_Range("Z1:Z1").Font.FontStyle = "Bold";
                excelWorkSheet.get_Range("Z1:Z1").Value = "Hist Seq";

                Excel.Range PaymentSeq = excelWorkSheet.get_Range("AA:AA");
                PaymentSeq.Columns.EntireColumn.AutoFit();
                PaymentSeq.Columns.ColumnWidth = 6;
                excelWorkSheet.get_Range("AA1:AA1").Font.FontStyle = "Bold";
                excelWorkSheet.get_Range("AA1:AA1").Value = "PMT Seq";

                Excel.Range PaymentCode = excelWorkSheet.get_Range("AB:AB");
                PaymentCode.Columns.EntireColumn.AutoFit();
                PaymentCode.Columns.ColumnWidth = 6;
                excelWorkSheet.get_Range("AB1:AB1").Font.FontStyle = "Bold";
                excelWorkSheet.get_Range("AB1:AB1").Value = "PMT Seq";

                Excel.Range HistoryDate = excelWorkSheet.get_Range("AC:AC");
                HistoryDate.Columns.EntireColumn.AutoFit();
                HistoryDate.Columns.ColumnWidth = 11.43;
                HistoryDate.Columns.NumberFormat = "mm/dd/yyyy";
                excelWorkSheet.get_Range("AC1:AC1").Font.FontStyle = "Bold";
                excelWorkSheet.get_Range("AC1:AC1").Value = "HistoryDate";

                r1.Font.Bold = true;
                r1.Interior.Color = Excel.XlRgbColor.rgbLightSalmon;

                Excel.FormatCondition format = r.Rows.FormatConditions.Add(Excel.XlFormatConditionType.xlExpression, Excel.XlFormatConditionOperator.xlEqual, "=MOD(ROW(),2) = 0");
                format.Interior.Color = Excel.XlRgbColor.rgbBisque;
                r.Borders.LineStyle = Excel.XlLineStyle.xlContinuous;
                r1.Borders.LineStyle = Excel.XlLineStyle.xlContinuous;

                excelWorkSheet.PageSetup.PaperSize = Excel.XlPaperSize.xlPaperLetter;
                excelWorkSheet.PageSetup.Orientation = Excel.XlPageOrientation.xlPortrait;
                //excelWorkSheet.PageSetup.TopMargin = .25;
                excelWorkSheet.PageSetup.LeftMargin = .25;
                excelWorkSheet.PageSetup.RightMargin = .25;
                excelWorkSheet.PageSetup.BottomMargin = .25;
                excelWorkSheet.PageSetup.FitToPagesWide = 1;
                excelWorkSheet.PageSetup.Zoom = false;

                excelApp.ActiveWindow.View = Excel.XlWindowView.xlNormalView;

                excelWorkSheet.get_Range("A:R").Font.Size = 11;
                // Moses Newman 08/01/2018 Freeze header row.
                Excel.Range firstRow = (Excel.Range)excelWorkSheet.Rows[1];
                excelWorkSheet.Activate();
                excelWorkSheet.Application.ActiveWindow.SplitRow = 1;
                firstRow.Application.ActiveWindow.FreezePanes = true;

                excelWorkBook.SaveAs(lsExcelFileOut, Excel.XlFileFormat.xlWorkbookDefault);
                //excelWorkBook.Close();
                //excelApp.Quit();
                // Moses Newman 01/30/2018 End Excel Formatting
                PT.Dispose();
                BW.Dispose();
                CP.Dispose();
            }

        }

        private void toolStripButtonEdit_ItemClick(object sender, ItemClickEventArgs e)
        {
            lbEdit = true;
            LockCustomerRecord();
            if (lbEdit)
                SetEditMode();
            else
                Refresh();
        }

        private void checkBoxVehicleWarranty_CheckedChanged(object sender, EventArgs e)
        {
            CheckEdit edit = sender as CheckEdit;
            if (edit.Checked)
                edit.ForeColor = Color.Red;
            else
            {
                edit.ForeColor = SystemColors.ControlText;
            }
            if (checkBoxVehicleWarranty.Checked && (lbAddFlag || lbEdit))
            {
                textBoxOpenAccount.Enabled = true;
                ActiveControl = textBoxOpenAccount;
                textBoxOpenAccount.SelectAll();
            }
            else
            {
                if (!checkBoxVehicleWarranty.Checked)
                    textBoxOpenAccount.Enabled = false;
                else
                    textBoxOpenAccount.Enabled = true;
            }
            if (lbAddFlag || lbEdit)
                toolStripButtonSave.Enabled = true;
        }
        private void xtraTabControlCustomerMaint_SelectedPageChanged(object sender, DevExpress.XtraTab.TabPageChangedEventArgs e)
        {
            switch (xtraTabControlCustomerMaint.SelectedTabPageIndex)
            {
                case 1:
                    setRelatedData();
                    break;
                case 4:
                    if (checkEditSplitPay.Checked)
                        xtraTabControl1.TabPages[1].PageEnabled = true;
                    else
                        xtraTabControl1.TabPages[1].PageEnabled = false;
                    break;
                case 7:
                    setRelatedData();
                    // Moses Newman 12/1/2021 order by id descending
                    GridColumn colID = cOMMENTgridView.Columns["id"];
                    //GridColumn colDate = cOMMENTgridView.Columns["COMMENT_DATE"];
                    //GridColumn colSeqNo = cOMMENTgridView.Columns["COMMENT_SEQ_NO"];
                    cOMMENTgridView.BeginSort();
                    try
                    {
                        cOMMENTgridView.ClearSorting();
                        // Moses Newman 12/1/2021 order by id descending
                        colID.SortOrder = ColumnSortOrder.Descending;
                    }
                    finally
                    {
                        cOMMENTgridView.EndSort();
                    }
                    // Moses Newman 11/13/2023 Add filter selection of system generated comments only or all.
                    // Moses Newman 11/15/2023 If TEXT SENT: and no template then treat as USER generated!
                    cOMMENTgridView.ActiveFilterString = "(StartsWith([COMMENT_WHOLE], 'TEXT SENT:') AND [SMSTemplate] > 0) OR [COMMENT_USERID] = 'SYS'";
                    cOMMENTgridView.ActiveFilterString = "(NOT StartsWith([COMMENT_WHOLE], 'TEXT SENT:') OR [SMSTemplate] <= 0) AND [COMMENT_USERID] <> 'SYS'";
                    cOMMENTgridView.ActiveFilterEnabled = false;
                    break;
                case 9:
                    // Moses Newman 12/20/2021 order by id descending
                    GridColumn colidRepo = gridViewRepoLog.Columns["id"];
                    gridViewRepoLog.BeginSort();
                    try
                    {
                        gridViewRepoLog.ClearSorting();
                        // Moses Newman 12/20/2021 order by id decending.
                        colidRepo.SortOrder = ColumnSortOrder.Descending;
                    }
                    finally
                    {
                        gridViewRepoLog.EndSort();
                    }
                    break;
            }
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
            if (cUSTOMER_NOTextBox.EditValue.ToString().Trim() == "")
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

            if (cUSTOMER_NOTextBox.EditValue.ToString().Trim() == "")
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

        private void xtraTabPage1_Enter(object sender, EventArgs e)
        {
        }

        private void checkEditCustomerInsurance_CheckedChanged(object sender, EventArgs e)
        {
            if (lbAddFlag || lbEdit)
                toolStripButtonSave.Enabled = true;
        }

        private void checkEditCustomerInsurance_QueryCheckStateByValue(object sender, DevExpress.XtraEditors.Controls.QueryCheckStateByValueEventArgs e)
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

        private void checkEditCustomerInsurance_QueryValueByCheckState(object sender, DevExpress.XtraEditors.Controls.QueryValueByCheckStateEventArgs e)
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

        private void checkEditAutoPay_CheckedChanged(object sender, EventArgs e)
        {
            if (lbAddFlag || lbEdit)
                toolStripButtonSave.Enabled = true;
        }

        private void checkEditAutoPay_QueryCheckStateByValue_1(object sender, DevExpress.XtraEditors.Controls.QueryCheckStateByValueEventArgs e)
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

        private void checkEditAutoPay_QueryValueByCheckState_1(object sender, DevExpress.XtraEditors.Controls.QueryValueByCheckStateEventArgs e)
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

        private void checkEditWrongAddress_CheckedChanged(object sender, EventArgs e)
        {
            if (lbAddFlag || lbEdit)
                toolStripButtonSave.Enabled = true;
        }

        private void checkEditWrongAddress_QueryCheckStateByValue(object sender, DevExpress.XtraEditors.Controls.QueryCheckStateByValueEventArgs e)
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

        private void checkEditWrongAddress_QueryValueByCheckState(object sender, DevExpress.XtraEditors.Controls.QueryValueByCheckStateEventArgs e)
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

        private void checkEditNoContact_CheckedChanged(object sender, EventArgs e)
        {
            if (lbAddFlag || lbEdit)
                toolStripButtonSave.Enabled = true;
        }

        private void checkEditNoContact_QueryCheckStateByValue(object sender, DevExpress.XtraEditors.Controls.QueryCheckStateByValueEventArgs e)
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

        private void checkEditNoContact_QueryValueByCheckState(object sender, DevExpress.XtraEditors.Controls.QueryValueByCheckStateEventArgs e)
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

        private void checkEditAllotment_CheckedChanged(object sender, EventArgs e)
        {
            if (lbAddFlag || lbEdit)
                toolStripButtonSave.Enabled = true;
        }

        private void checkEditAllotment_QueryCheckStateByValue(object sender, DevExpress.XtraEditors.Controls.QueryCheckStateByValueEventArgs e)
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

        private void checkEditAllotment_QueryValueByCheckState(object sender, DevExpress.XtraEditors.Controls.QueryValueByCheckStateEventArgs e)
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

        private void txtEffectiveDate_EditValueChanged(object sender, EventArgs e)
        {
            if (lbAddFlag || lbEdit)
                toolStripButtonSave.Enabled = true;
        }

        private void txtExpirationDate_EditValueChanged(object sender, EventArgs e)
        {
            if (lbAddFlag || lbEdit)
                toolStripButtonSave.Enabled = true;
        }

        private void nullableDateTimePickerLocDate_EditValueChanged(object sender, EventArgs e)
        {
            if (lbAddFlag || lbEdit)
                toolStripButtonSave.Enabled = true;
        }

        private void nullableDateTimePickerAucDate_EditValueChanged(object sender, EventArgs e)
        {
            if (lbAddFlag || lbEdit)
                toolStripButtonSave.Enabled = true;
        }

        private void nullableDateTimePickerTitleDateReceived_EditValueChanged(object sender, EventArgs e)
        {
            if (lbAddFlag || lbEdit)
                toolStripButtonSave.Enabled = true;
        }

        private void nullableDateTimePickerDateTitleReleased_EditValueChanged(object sender, EventArgs e)
        {
            if (lbAddFlag || lbEdit)
                toolStripButtonSave.Enabled = true;
        }

        private void nullableDateTimePickerDateContractReceived_EditValueChanged(object sender, EventArgs e)
        {
            if (lbEdit && toolStripButtonSave.Enabled == false)
                toolStripButtonSave.Enabled = true;
        }

        private void nullableDateTimePickerDateContractReceived_EnabledChanged(object sender, EventArgs e)
        {
            Control lastControl = ActiveControl;

            DateEdit edit = sender as DateEdit;

            if (edit.Enabled == true)
            {
                if (!lbAddFlag && !lbEdit)
                    edit.Enabled = false;
                ActiveControl = lastControl;
                lastControl.Focus();
            }
        }

        private void txtFirstPayDate_Validated(object sender, EventArgs e)
        {
            if (!lbAddFlag)
                return;
            // Moses Newman 12/12/2014 Call TVAmortTableAdapter.PaidThrough to get correctrect new Paid Through 
            IACDataSetTableAdapters.TVAmortTableAdapter TVAmortTableAdapter = new IACDataSetTableAdapters.TVAmortTableAdapter();
            Object loPTDate = null;
            DateTime ldTempDate;

            loPTDate = TVAmortTableAdapter.PaidThrough(cUSTOMER_NOTextBox.EditValue.ToString().Trim());
            if (loPTDate != null)
                txtPaidThrough.Text = (String)loPTDate;
            else
            {
                ldTempDate = iACDataSet.CUSTOMER.Rows[0].Field<DateTime>("CUSTOMER_INIT_DATE");
                ldTempDate = iACDataSet.CUSTOMER.Rows[0].Field<DateTime>("CUSTOMER_INIT_DATE").AddMonths(-1);
                txtPaidThrough.Text = ldTempDate.Month.ToString().PadLeft(2, '0') + ldTempDate.Year.ToString().Substring(2, 2);
            }
            nullableDateTimePickerFirstPayDate.EditValue = txtFirstPayDate.EditValue;
            // Moses Newman 01/20/2015 Added Contract Date
            if (DateTimePickerContractDate.EditValue == null)
                DateTimePickerContractDate.EditValue = DateTime.Now.Date;
            nullableDateTimePickerHistContractDate.EditValue = DateTimePickerContractDate.EditValue;
            loPTDate = null;
            TVAmortTableAdapter.Dispose();
            TVAmortTableAdapter = null;
        }

        private void comboBoxDayDue_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBoxDayDue.SelectedIndex >= 0)
            {
                errorProviderCustomerForm.Clear();
                Reamortize(); // Moses Newman 01/29/2019 call new Reamortize instead of regular payment valid call!
            }
        }

        private void comboBoxDayDue_Validated(object sender, EventArgs e)
        {
            if (comboBoxDayDue.Text.TrimStart().TrimEnd() == "5" && comboBoxDayDue.Text == "10" && comboBoxDayDue.Text == "15" && comboBoxDayDue.Text == "20" && comboBoxDayDue.Text == "25" && comboBoxDayDue.Text == "30")
            {
                errorProviderCustomerForm.Clear();
                Reamortize();
            }
        }

        private void comboBoxDayDue_Validating(object sender, CancelEventArgs e)
        {
            if (comboBoxDayDue.Text.TrimStart().TrimEnd() != "5" && comboBoxDayDue.Text != "10" && comboBoxDayDue.Text != "15" && comboBoxDayDue.Text != "20" && comboBoxDayDue.Text != "25" && comboBoxDayDue.Text != "30")
            {
                // Cancel the event and select the text to be corrected by the user.
                e.Cancel = true;
                comboBoxDayDue.Select(0, comboBoxDayDue.Text.Length);

                // Set the ErrorProvider error with the text to display.  
                this.errorProviderCustomerForm.SetError(comboBoxDayDue, "You must enter a either 5,10,15,20,25 or 30 in the day due field!");
            }
        }

        private void checkBoxOverrideLateCharge_CheckedChanged(object sender, EventArgs e)
        {
            if (lbAddFlag || lbEdit)
                toolStripButtonSave.Enabled = true;
        }

        private void checkBoxSimple_CheckedChanged(object sender, EventArgs e)
        {
            if (lbAddFlag || lbEdit)
                toolStripButtonSave.Enabled = true;
        }

        private void txtAPR_Validated(object sender, EventArgs e)
        {
            if (txtAPR.Text.Length != 0)
            {
                if (Convert.ToDecimal(txtAPR.Text) != 0)
                {
                    errorProviderCustomerForm.Clear();
                    // Moses Newman 01/04/2014 enable Interest Override if Annual Percentage Rate is not equal to 0!
                    if (lbEdit || lbAddFlag)
                        checkEditOverideInterest.Enabled = true;
                    //if (txtRegularPay.Text.Length == 0 || Convert.ToDecimal(txtRegularPay.Text.Substring(1)) == 0)
                    Reamortize(); // Moses Newman 01/29/2019 call new Reamortize instead of regular payment valid call!
                }
                return;
            }
            else
                if (txtRegularPay.Text.Length != 0)
            {
                if (Convert.ToDecimal(txtRegularPay.Text.Substring(1)) != 0)
                    errorProviderCustomerForm.Clear();
                // Moses Newman 01/04/2014 enable Interest Override if Annual Percentage Rate is not equal to 0!
                if (lbEdit || lbAddFlag)
                    checkEditOverideInterest.Enabled = true;
            }
        }

        private void txtCASH_Validated(object sender, EventArgs e)
        {
            if (txtCASH.Text.Length != 0)
                if (Convert.ToDecimal(txtCASH.Text.Substring(1)) != 0)
                    errorProviderCustomerForm.Clear();
            if (txtRegularPay.Text.Length != 0 || Convert.ToDecimal(txtRegularPay.Text.Substring(1)) != 0)
                Reamortize(); // Moses Newman 01/29/2019 call new Reamortize instead of regular payment valid call!
        }

        private void DateTimePickerContractDate_Validated_1(object sender, EventArgs e)
        {
            // Moses Newman 01/20/2015 Make sure that history screen field is visually updated on Contract Date edit!
            if (lbAddFlag || lbEdit)
            {
                nullableDateTimePickerHistContractDate.EditValue = DateTimePickerContractDate.EditValue;
                toolStripButtonSave.Enabled = true;
            }
        }

        private void txtPaidThrough_Validated(object sender, EventArgs e)
        {

        }

        private void txtTerm_Validated(object sender, EventArgs e)
        {
            if (txtTerm.Text.Length != 0)
                if (Convert.ToInt32(txtTerm.Text) != 0)
                {
                    errorProviderCustomerForm.Clear();
                    //Reamortize(); // Moses Newman 01/29/2019 call new Reamortize instead of regular payment valid call!
                    iACDataSet.CUSTOMER.Rows[cUSTOMERBindingSource.Position].SetField<DateTime>("MaturityDate", iACDataSet.CUSTOMER.Rows[cUSTOMERBindingSource.Position].Field<DateTime>("CUSTOMER_INIT_DATE").AddMonths(iACDataSet.CUSTOMER.Rows[cUSTOMERBindingSource.Position].Field<Int32>("CUSTOMER_TERM") - 1));
                    this.MaturityDate.EditValue = iACDataSet.CUSTOMER.Rows[cUSTOMERBindingSource.Position].Field<DateTime>("CUSTOMER_INIT_DATE").AddMonths(iACDataSet.CUSTOMER.Rows[cUSTOMERBindingSource.Position].Field<Int32>("CUSTOMER_TERM") - 1);
                }
            return;
        }

        private void checkEditOverideInterest_CheckedChanged(object sender, EventArgs e)
        {
            if (lbAddFlag || lbEdit)
                toolStripButtonSave.Enabled = true;
        }

        private void checkEditOverideInterest_QueryCheckStateByValue(object sender, DevExpress.XtraEditors.Controls.QueryCheckStateByValueEventArgs e)
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

        private void checkEditOverideInterest_QueryValueByCheckState(object sender, DevExpress.XtraEditors.Controls.QueryValueByCheckStateEventArgs e)
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

        private void checkEditCollectionAgent_CheckedChanged(object sender, EventArgs e)
        {
            if (lbAddFlag || lbEdit)
                toolStripButtonSave.Enabled = true;
        }

        private void checkEditCollectionAgent_QueryCheckStateByValue(object sender, DevExpress.XtraEditors.Controls.QueryCheckStateByValueEventArgs e)
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

        private void checkEditCollectionAgent_QueryValueByCheckState(object sender, DevExpress.XtraEditors.Controls.QueryValueByCheckStateEventArgs e)
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

        private void checkEditOverideInterestHistory_CheckedChanged(object sender, EventArgs e)
        {
            if (lbAddFlag || lbEdit)
                toolStripButtonSave.Enabled = true;
        }

        private void checkEditOverideInterestHistory_QueryCheckStateByValue(object sender, DevExpress.XtraEditors.Controls.QueryCheckStateByValueEventArgs e)
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

        private void checkEditOverideInterestHistory_QueryValueByCheckState(object sender, DevExpress.XtraEditors.Controls.QueryValueByCheckStateEventArgs e)
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

        private void checkEditCollectionAgentHistory_CheckedChanged(object sender, EventArgs e)
        {
            if (lbAddFlag || lbEdit)
                toolStripButtonSave.Enabled = true;
        }


        private void checkEditCollectionAgentHistory_QueryCheckStateByValue(object sender, DevExpress.XtraEditors.Controls.QueryCheckStateByValueEventArgs e)
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

        private void checkEditCollectionAgentHistory_QueryValueByCheckState(object sender, DevExpress.XtraEditors.Controls.QueryValueByCheckStateEventArgs e)
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

        private void checkBoxCheckIssued_CheckedChanged(object sender, EventArgs e)
        {
            if (lbAddFlag || lbEdit)
                toolStripButtonSave.Enabled = true;
            if (checkBoxCheckIssued.Checked)
            {
                labelCheckNumber.Visible = true;
                textBoxCheckNo.Visible = true;
            }
            else
            {
                labelCheckNumber.Visible = false;
                textBoxCheckNo.Visible = false;
            }
        }

        // Moses Newman 07/16/2020 Add comment on check number box validation if Check Number box is filled in.
        private void textBoxCheckNo_Validated(object sender, EventArgs e)
        {
            // Moses Newman 07/16/2021 Make sure the Overpayment comment does not already exist!
            Int32 lnCount = 0;
            if (cUSTOMER_ACT_STATTextBox.Text == "I" && textBoxCheckNo.Text != "")
            {
                var loCount = cOMMENTTableAdapter.OverpayCount(iACDataSet.CUSTOMER.Rows[0].Field<String>("CUSTOMER_NO"));

                lnCount = loCount != null ? (Int32)loCount : 0;
                if (lnCount == 0)
                    MakeComment("*** Overpayment Check Issued Check Number: " + textBoxCheckNo.Text + " ***", "", 0, false);
            }
        }

        private void checkEditJointOwnership_CheckedChanged(object sender, EventArgs e)
        {
            if (lbAddFlag || lbEdit)
                toolStripButtonSave.Enabled = true;
        }

        private void checkEditJointOwnership_QueryCheckStateByValue(object sender, DevExpress.XtraEditors.Controls.QueryCheckStateByValueEventArgs e)
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

        private void checkEditJointOwnership_QueryValueByCheckState(object sender, DevExpress.XtraEditors.Controls.QueryValueByCheckStateEventArgs e)
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

        private void checkEditUsePrimaryAddress_CheckedChanged(object sender, EventArgs e)
        {
            if (lbAddFlag || lbEdit)
                toolStripButtonSave.Enabled = true;
        }

        private void checkEditUsePrimaryAddress_QueryCheckStateByValue(object sender, DevExpress.XtraEditors.Controls.QueryCheckStateByValueEventArgs e)
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

        private void checkEditUsePrimaryAddress_QueryValueByCheckState(object sender, DevExpress.XtraEditors.Controls.QueryValueByCheckStateEventArgs e)
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

        private void checkEditHasCollision_CheckedChanged(object sender, EventArgs e)
        {
            if (lbAddFlag || lbEdit)
                toolStripButtonSave.Enabled = true;
        }

        private void checkEditHasComprehensive_CheckedChanged(object sender, EventArgs e)
        {
            if (lbAddFlag || lbEdit)
                toolStripButtonSave.Enabled = true;
        }

        private void checkBoxAccountType_CheckedChanged(object sender, EventArgs e)
        {
            if (lbAddFlag || lbEdit)
                toolStripButtonSave.Enabled = true;
        }

        private void comboBoxAccountType_SelectedValueChanged(object sender, EventArgs e)
        {
            if (lbAddFlag || lbEdit)
                toolStripButtonSave.Enabled = true;
        }

        private void comboBoxSpecialComment_SelectedValueChanged(object sender, EventArgs e)
        {
            if (lbAddFlag || lbEdit)
                toolStripButtonSave.Enabled = true;
        }

        private void cUSTOMER_DEALERcomboBox_EditValueChanged(object sender, EventArgs e)
        {
            LookUpEdit textEditor = (LookUpEdit)sender;

            if (lbEdit || lbAddFlag)
            {
                toolStripButtonSave.Enabled = true;
                // Moses Newman 12/19/2019 Send to Dealer Checkbox added.
                if (textBoxDealerEmail.Text.Trim() != "")
                {
                    checkBoxSendToDealer.Visible = true;
                    checkBoxSendToDealer.Enabled = true;
                }
                else
                {
                    checkBoxSendToDealer.Enabled = false;
                    checkBoxSendToDealer.Visible = false;
                }
                checkBoxSendToDealer.Refresh();
            }
            // Moses Newman 05/03/2022 new stuff
            String tmpEditValStr = textEditor.EditValue == null ? String.Empty : textEditor.EditValue.ToString();
            Int32 lnEditVal = !String.IsNullOrEmpty(tmpEditValStr) ? (Int32)textEditor.EditValue : 0;
            if (lnEditVal == 0)
                return;
            // End New Stuff

            ActiveControl = cUSTOMER_DEALERcomboBox;
            dEALERTableAdapter.Fill(iACDataSet.DEALER, (Int32)textEditor.EditValue);
            //textEditDealerName.Refresh();
            System.Windows.Forms.SendKeys.Send("{TAB}");
        }

        private void cUSTOMER_FIRST_NAMETextBox_Validated(object sender, EventArgs e)
        {
            if (cUSTOMER_FIRST_NAMETextBox.Text.Length != 0)
                errorProviderCustomerForm.Clear();
        }

        private void comboBoxAccountStatus_EditValueChanged(object sender, EventArgs e)
        {
            if (lbAddFlag || lbEdit)
                toolStripButtonSave.Enabled = true;
        }

        private void cUSTOMER_NOTextBox_EditValueChanged(object sender, EventArgs e)
        {
            TextEdit textEdit = (TextEdit)sender;

            string lsCustomerNo;
            if (lbEdit || String.IsNullOrEmpty((String)textEdit.EditValue))
                return;  // Do not requery data on an edit!!!
            if (textEdit.EditValue.ToString().Trim().Length < 6 && textEdit.EditValue.ToString().Trim().Length > 0)
                textEdit.EditValue = textEdit.EditValue.ToString().Trim().PadLeft(6, '0');
            lsCustomerNo = textEdit.EditValue.ToString().Trim();
            if (lsCustomerNo == "")  // Moses Newman 03/02/2012 previously only returned if in Add Mode!!!
                return;
            if (!lbAddFlag)
                setRelatedData();
            if (iACDataSet.CUSTOMER.Rows.Count == 0 && lsCustomerNo != "")
            {
                var ldlgAnswer = MessageBox.Show("Sorry no customers found that match your selected account number! Would you like to add a new record?", "Add New Prompt", MessageBoxButtons.YesNo);
                if (ldlgAnswer == DialogResult.No)
                {
                    textEdit.EditValue = "";
                    cUSTOMER_NOTextBox.Focus();
                    cUSTOMER_NOTextBox.Select();
                }
                else
                {
                    Text = "Closed Customer Maintenance (ADD Mode)";
                    String lcHighValue = "";
                    lcHighValue += (char)255;

                    lbAddFlag = true;
                    cUSTOMERBindingSource.AddNew();
                    cUSTOMERBindingSource.EndEdit();
                    toolStripButton1.Enabled = false;
                    toolStripButtonSave.Enabled = true;
                    iACDataSet.CUSTOMER.Rows[cUSTOMERBindingSource.Position].SetField<String>("CUSTOMER_NO", lsCustomerNo);
                    cUSTOMERBindingSource.EndEdit();
                    iACDataSet.CUSTOMER.Rows[cUSTOMERBindingSource.Position].SetField<String>("CUSTOMER_PURCHASE_ORDER", "");
                    iACDataSet.CUSTOMER.Rows[cUSTOMERBindingSource.Position].SetField<String>("CUSTOMER_ADD_ON", " ");
                    iACDataSet.CUSTOMER.Rows[cUSTOMERBindingSource.Position].SetField<String>("CUSTOMER_IAC_TYPE", "C");
                    iACDataSet.CUSTOMER.Rows[cUSTOMERBindingSource.Position].SetField<String>("CUSTOMER_POST_IND", lcHighValue);
                    iACDataSet.CUSTOMER.Rows[cUSTOMERBindingSource.Position].SetField<String>("CUSTOMER_ACT_STAT", "A");
                    iACDataSet.CUSTOMER.Rows[cUSTOMERBindingSource.Position].SetField<String>("CUSTOMER_FIRST_NAME", "");
                    iACDataSet.CUSTOMER.Rows[cUSTOMERBindingSource.Position].SetField<String>("CUSTOMER_LAST_NAME", "");
                    iACDataSet.CUSTOMER.Rows[cUSTOMERBindingSource.Position].SetField<String>("CUSTOMER_SUFFIX", "");
                    iACDataSet.CUSTOMER.Rows[cUSTOMERBindingSource.Position].SetField<String>("CUSTOMER_CONTACT", "");
                    iACDataSet.CUSTOMER.Rows[cUSTOMERBindingSource.Position].SetField<String>("CUSTOMER_STREET_1", "");
                    iACDataSet.CUSTOMER.Rows[cUSTOMERBindingSource.Position].SetField<String>("CUSTOMER_STREET_2", "");
                    iACDataSet.CUSTOMER.Rows[cUSTOMERBindingSource.Position].SetField<String>("CUSTOMER_CITY", "");
                    iACDataSet.CUSTOMER.Rows[cUSTOMERBindingSource.Position].SetField<String>("CUSTOMER_STATE", "");
                    iACDataSet.CUSTOMER.Rows[cUSTOMERBindingSource.Position].SetField<String>("CUSTOMER_ZIP_1", "");
                    iACDataSet.CUSTOMER.Rows[cUSTOMERBindingSource.Position].SetField<String>("CUSTOMER_ZIP_2", "");
                    iACDataSet.CUSTOMER.Rows[cUSTOMERBindingSource.Position].SetField<String>("CUSTOMER_PHONE_NO", "");
                    iACDataSet.CUSTOMER.Rows[cUSTOMERBindingSource.Position].SetField<String>("CUSTOMER_PHONE_EXT", "");
                    iACDataSet.CUSTOMER.Rows[cUSTOMERBindingSource.Position].SetField<String>("CUSTOMER_WORK_PHONE", "");
                    iACDataSet.CUSTOMER.Rows[cUSTOMERBindingSource.Position].SetField<String>("CUSTOMER_WORK_EXT", "");
                    iACDataSet.CUSTOMER.Rows[cUSTOMERBindingSource.Position].SetField<String>("CUSTOMER_CELL_PHONE", "");
                    iACDataSet.CUSTOMER.Rows[cUSTOMERBindingSource.Position].SetField<String>("CUSTOMER_SS_1", "");
                    iACDataSet.CUSTOMER.Rows[cUSTOMERBindingSource.Position].SetField<String>("CUSTOMER_SS_2", "");
                    iACDataSet.CUSTOMER.Rows[cUSTOMERBindingSource.Position].SetField<String>("CUSTOMER_SS_3", "");
                    iACDataSet.CUSTOMER.Rows[cUSTOMERBindingSource.Position].SetField<String>("CUSTOMER_REBATE_CODE", "");
                    iACDataSet.CUSTOMER.Rows[cUSTOMERBindingSource.Position].SetField<String>("CUSTOMER_COMMENT_1", "");
                    iACDataSet.CUSTOMER.Rows[cUSTOMERBindingSource.Position].SetField<String>("CUSTOMER_COMMENT_2", "");
                    iACDataSet.CUSTOMER.Rows[cUSTOMERBindingSource.Position].SetField<String>("CUSTOMER_INSURANCE", "N");
                    iACDataSet.CUSTOMER.Rows[cUSTOMERBindingSource.Position].SetField<String>("CUSTOMER_AUTOPAY", "N");
                    iACDataSet.CUSTOMER.Rows[cUSTOMERBindingSource.Position].SetField<Int32>("CUSTOMER_CREDIT_SCORE_N", 0);
                    iACDataSet.CUSTOMER.Rows[cUSTOMERBindingSource.Position].SetField<String>("CUSTOMER_CREDIT_SCORE_A", "");
                    iACDataSet.CUSTOMER.Rows[cUSTOMERBindingSource.Position].SetField<String>("CUSTOMER_ALLOTMENT", "N");
                    iACDataSet.CUSTOMER.Rows[cUSTOMERBindingSource.Position].SetField<Int32>("CUSTOMER_DISTRIBUTOR_NO", 0);
                    iACDataSet.CUSTOMER.Rows[cUSTOMERBindingSource.Position].SetField<Int32>("CUSTOMER_BRANCH_NUMBER", 0);
                    iACDataSet.CUSTOMER.Rows[cUSTOMERBindingSource.Position].SetField<String>("CUSTOMER_WRONG_ADDRESS", "N");
                    iACDataSet.CUSTOMER.Rows[cUSTOMERBindingSource.Position].SetField<String>("CUSTOMER_NO_CONTACT", "N");
                    iACDataSet.CUSTOMER.Rows[cUSTOMERBindingSource.Position].SetField<String>("CUSTOMER_COS_NAME", "");
                    iACDataSet.CUSTOMER.Rows[cUSTOMERBindingSource.Position].SetField<String>("CUSTOMER_COS_PHONE", "");
                    iACDataSet.CUSTOMER.Rows[cUSTOMERBindingSource.Position].SetField<String>("CUSTOMER_REPO_IND", "N");
                    iACDataSet.CUSTOMER.Rows[cUSTOMERBindingSource.Position].SetField<String>("CUSTOMER_REPO_CDE", "");
                    iACDataSet.CUSTOMER.Rows[cUSTOMERBindingSource.Position].SetField<String>("CUSTOMER_PAYMENT_TYPE", "");
                    iACDataSet.CUSTOMER.Rows[cUSTOMERBindingSource.Position].SetField<String>("CUSTOMER_PAYMENT_CODE", "");
                    iACDataSet.CUSTOMER.Rows[cUSTOMERBindingSource.Position].SetField<DateTime>("CUSTOMER_INIT_DATE", DateTime.Now.Date.AddMonths(1));
                    // Moses Newman 01/20/2015 Add Contract Date
                    iACDataSet.CUSTOMER.Rows[cUSTOMERBindingSource.Position].SetField<DateTime>("ContractDate", DateTime.Now.Date);
                    iACDataSet.CUSTOMER.Rows[cUSTOMERBindingSource.Position].SetField<Nullable<DateTime>>("CUSTOMER_LAST_PAYMENT_DATE", null);
                    iACDataSet.CUSTOMER.Rows[cUSTOMERBindingSource.Position].SetField<Int32>("CUSTOMER_DAY_DUE", 0);
                    iACDataSet.CUSTOMER.Rows[cUSTOMERBindingSource.Position].SetField<Int32>("CUSTOMER_TERM", 0);
                    iACDataSet.CUSTOMER.Rows[cUSTOMERBindingSource.Position].SetField<String>("CUSTOMER_CREDIT_STATUS", "N");
                    iACDataSet.CUSTOMER.Rows[cUSTOMERBindingSource.Position].SetField<Decimal>("CUSTOMER_REGULAR_AMOUNT", 0);
                    iACDataSet.CUSTOMER.Rows[cUSTOMERBindingSource.Position].SetField<Decimal>("CUSTOMER_BALANCE", 0);
                    iACDataSet.CUSTOMER.Rows[cUSTOMERBindingSource.Position].SetField<Decimal>("CUSTOMER_LOAN_AMOUNT", 0);
                    iACDataSet.CUSTOMER.Rows[cUSTOMERBindingSource.Position].SetField<Decimal>("CUSTOMER_LOAN_INTEREST", 0);
                    iACDataSet.CUSTOMER.Rows[cUSTOMERBindingSource.Position].SetField<Decimal>("CUSTOMER_LATE_CHARGE", 0);
                    iACDataSet.CUSTOMER.Rows[cUSTOMERBindingSource.Position].SetField<Decimal>("CUSTOMER_LATE_CHARGE_BAL", 0);
                    iACDataSet.CUSTOMER.Rows[cUSTOMERBindingSource.Position].SetField<Decimal>("CUSTOMER_PAID_INTEREST", 0);
                    iACDataSet.CUSTOMER.Rows[cUSTOMERBindingSource.Position].SetField<Decimal>("CUSTOMER_UE_INTEREST", 0);
                    iACDataSet.CUSTOMER.Rows[cUSTOMERBindingSource.Position].SetField<Decimal>("CUSTOMER_ANNUAL_PERCENTAGE_RATE", 0);
                    iACDataSet.CUSTOMER.Rows[cUSTOMERBindingSource.Position].SetField<Decimal>("CUSTOMER_LOAN_CASH", 0);
                    iACDataSet.CUSTOMER.Rows[cUSTOMERBindingSource.Position].SetField<Int32>("CUSTOMER_NO_OF_PAYMENTS_MADE", 0);
                    iACDataSet.CUSTOMER.Rows[cUSTOMERBindingSource.Position].SetField<String>("CUSTOMER_INT_OVERRIDE", "N");
                    iACDataSet.CUSTOMER.Rows[cUSTOMERBindingSource.Position].SetField<Double>("CUSTOMER_PARTIAL_PAYMENTS", 0);
                    iACDataSet.CUSTOMER.Rows[cUSTOMERBindingSource.Position].SetField<String>("CUSTOMER_CREDIT_BUREAU", "Y");
                    iACDataSet.CUSTOMER.Rows[cUSTOMERBindingSource.Position].SetField<Decimal>("CUSTOMER_DEALER_DISC", 0);
                    iACDataSet.CUSTOMER.Rows[cUSTOMERBindingSource.Position].SetField<Decimal>("CUSTOMER_DEALER_DISC_BAL", 0);
                    iACDataSet.CUSTOMER.Rows[cUSTOMERBindingSource.Position].SetField<Int32>("CUSTOMER_CREDIT_LIMIT", 0);
                    iACDataSet.CUSTOMER.Rows[cUSTOMERBindingSource.Position].SetField<Decimal>("CUSTOMER_LAST_PAYMENT_MADE", 0);
                    iACDataSet.CUSTOMER.Rows[cUSTOMERBindingSource.Position].SetField<String>("CUSTOMER_REBATE_CODE", "");
                    iACDataSet.CUSTOMER.Rows[cUSTOMERBindingSource.Position].SetField<String>("CUSTOMER_AMORTIZE_IND", "S");
                    // Moses Newman 12/18/2013 Remove all references to CUSTOMER_LETTER_N FIELDS AS NO LONGER IN TABLE!
                    iACDataSet.CUSTOMER.Rows[cUSTOMERBindingSource.Position].SetField<Int32>("CUSTOMER_BUYOUT", 0);
                    iACDataSet.CUSTOMER.Rows[cUSTOMERBindingSource.Position].SetField<Int32>("CUSTOMER_CONTROL_MONTH", 0);
                    iACDataSet.CUSTOMER.Rows[cUSTOMERBindingSource.Position].SetField<Int32>("CUSTOMER_CONTROL_YEAR", 0);
                    iACDataSet.CUSTOMER.Rows[cUSTOMERBindingSource.Position].SetField<Int32>("CUSTOMER_CREDIT_AVAILABLE", 0);
                    iACDataSet.CUSTOMER.Rows[cUSTOMERBindingSource.Position].SetField<String>("CUSTOMER_ALT_FLAG", "N");
                    iACDataSet.CUSTOMER.Rows[cUSTOMERBindingSource.Position].SetField<String>("COSIGNER_FIRST_NAME", "");
                    iACDataSet.CUSTOMER.Rows[cUSTOMERBindingSource.Position].SetField<String>("COSIGNER_LAST_NAME", "");
                    iACDataSet.CUSTOMER.Rows[cUSTOMERBindingSource.Position].SetField<String>("COSIGNER_HOME_PHONE", "");
                    iACDataSet.CUSTOMER.Rows[cUSTOMERBindingSource.Position].SetField<String>("COSIGNER_WORK_PHONE", "");
                    iACDataSet.CUSTOMER.Rows[cUSTOMERBindingSource.Position].SetField<String>("COSIGNER_WORK_EXT", "");
                    iACDataSet.CUSTOMER.Rows[cUSTOMERBindingSource.Position].SetField<String>("COSIGNER_CELL_PHONE", "");
                    iACDataSet.CUSTOMER.Rows[cUSTOMERBindingSource.Position].SetField<String>("COSIGNER_ADDRESS1", "");
                    iACDataSet.CUSTOMER.Rows[cUSTOMERBindingSource.Position].SetField<String>("COSIGNER_CITY", "");
                    iACDataSet.CUSTOMER.Rows[cUSTOMERBindingSource.Position].SetField<String>("COSIGNER_STATE", "");
                    iACDataSet.CUSTOMER.Rows[cUSTOMERBindingSource.Position].SetField<String>("COSIGNER_ZIP_CODE", "");
                    iACDataSet.CUSTOMER.Rows[cUSTOMERBindingSource.Position].SetField<String>("COSIGNER_SS1", "");
                    iACDataSet.CUSTOMER.Rows[cUSTOMERBindingSource.Position].SetField<String>("COSIGNER_SS2", "");
                    iACDataSet.CUSTOMER.Rows[cUSTOMERBindingSource.Position].SetField<String>("COSIGNER_SS3", "");
                    iACDataSet.CUSTOMER.Rows[cUSTOMERBindingSource.Position].SetField<String>("COSIGNER_SAME_ADDRESS", "N");
                    iACDataSet.CUSTOMER.Rows[cUSTOMERBindingSource.Position].SetField<String>("COSIGNER_JUNIOR", "");
                    iACDataSet.CUSTOMER.Rows[cUSTOMERBindingSource.Position].SetField<Nullable<DateTime>>("COSIGNER_DOB_DATE", null);
                    iACDataSet.CUSTOMER.Rows[cUSTOMERBindingSource.Position].SetField<DateTime>("MaturityDate", iACDataSet.CUSTOMER.Rows[cUSTOMERBindingSource.Position].Field<DateTime>("CUSTOMER_INIT_DATE").AddMonths(iACDataSet.CUSTOMER.Rows[cUSTOMERBindingSource.Position].Field<Int32>("CUSTOMER_TERM") - 1));
                    this.MaturityDate.EditValue = iACDataSet.CUSTOMER.Rows[cUSTOMERBindingSource.Position].Field<DateTime>("CUSTOMER_INIT_DATE").AddMonths(iACDataSet.CUSTOMER.Rows[cUSTOMERBindingSource.Position].Field<Int32>("CUSTOMER_TERM") - 1);
                    this.MaturityDate.Refresh();
                    Create_New_ALTNAMERecord(lsCustomerNo);
                    Create_New_OPNBANKRecord(lsCustomerNo);
                    Create_New_VEHICLERecord(lsCustomerNo);
                    // Moses Newman 12/23/2013 Create Email Address Record
                    Create_New_EmailRecord(lsCustomerNo);

                    // Moses Newman 06/12/2018 Create new CustomerFees Record
                    // Moses Newman 09/21/2018 ONLY add if a CustomerFees record does NOT already exist!
                    CustomerFeesTableAdapter.Fill(iACDataSet.CustomerFees, iACDataSet.CUSTOMER.Rows[0].Field<String>("CUSTOMER_NO"));
                    if (iACDataSet.CustomerFees.Rows.Count < 1)  // Moses Newman 06/12/2018 Add new record if none exists in CustomerFees!
                    {
                        IACDataSet.CustomerFeesRow NewCustomerFeesRow = iACDataSet.CustomerFees.NewCustomerFeesRow();
                        NewCustomerFeesRow.CustomerNo = iACDataSet.CUSTOMER.Rows[0].Field<String>("CUSTOMER_NO");
                        iACDataSet.CustomerFees.Rows.Add(NewCustomerFeesRow);
                        // Moses Newman 02/23/2019 Make sure new record has the correct CUSTOMER_NO!!!
                        iACDataSet.CustomerFees.Rows[0].SetField<String>("CustomerNo", iACDataSet.CUSTOMER.Rows[0].Field<String>("CUSTOMER_NO"));
                        // Add record even if not yet in add or edit mode!
                        CustomerFeesTableAdapter.Update(iACDataSet.CustomerFees.Rows[0]);
                    }


                    // Customer Info
                    cUSTOMER_NOTextBox.Enabled = true;
                    cUSTOMER_PURCHASE_ORDERTextBox.Enabled = true;
                    cUSTOMER_ACT_STATTextBox.Enabled = false;
                    cUSTOMER_FIRST_NAMETextBox.Enabled = true;
                    cUSTOMER_LAST_NAMETextBox.Enabled = true;
                    comboBoxGN.Enabled = true;
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
                    cUSTOMER_COMMENT_1TextBox.Enabled = true;
                    cUSTOMER_COMMENT_2TextBox.Enabled = true;
                    checkEditCustomerInsurance.Enabled = true;
                    checkEditAutoPay.Enabled = true;
                    cUSTOMER_CREDIT_SCORE_NTextBox.Enabled = true;
                    cUSTOMER_CREDIT_SCORE_ATextBox.Enabled = true;
                    checkEditAllotment.Enabled = true;
                    cUSTOMER_DISTRIBUTOR_NOTextBox.Enabled = true;
                    cUSTOMER_BRANCH_NUMBERTextBox.Enabled = true;
                    checkEditWrongAddress.Enabled = true;
                    checkEditNoContact.Enabled = true;
                    // Moses Newman 12/23/2013 Added Email Address
                    richTextBoxEmailAddress.Enabled = true;
                    // Moses Newman 12/23/2013 Added Refi CheckBox
                    checkBoxRefi.Enabled = true;
                    //
                    // Moses Newman 01/13/2019 Added Warranty CheckBox and OpenAccount
                    checkBoxVehicleWarranty.Enabled = true;
                    //
                    // Moses Newman 01/29/2017 Added Middle Name, GAP Insurance type, Warranty, TIN
                    textBoxMiddleName.Enabled = true;
                    comboBoxGAP.Enabled = true;
                    // Moses Newman 06/01/2022 Add Warranty Company
                    textEditWarrantyCompany.Enabled = true;
                    checkBoxWarranty.Enabled = true;
                    // Moses Newman 01/24/2018 added ExcludeVSI
                    checkBoxExcludeVSI.Enabled = true;
                    textBoxTIN.Enabled = true;
                    // Moses Newman 09/02/2017
                    //buttonValidate.Enabled = true;
                    // Moses Newman 09/06/2017
                    radioButtonAcct.Enabled = true;
                    buttonConfirm.Enabled = true;
                    textBoxAuthNo.Enabled = true;
                    checkBoxDNTAcct.Enabled = true;
                    // Moses Newman 09/20/2021
                    radioButtonCOSAcct.Enabled = true;
                    buttonCOSConfirm.Enabled = true;
                    textBoxCOSAuthNo.Enabled = true;
                    checkBoxCOSDNTAcct.Enabled = true;
                    // Moses Newman 05/24/2018 
                    checkEditMilitary.Enabled = true;
                    // Moses Newman 12/19/2019 Send to Dealer Checkbox added.
                    if (textBoxDealerEmail.Text.Trim() != "")
                    {
                        checkBoxSendToDealer.Visible = true;
                        checkBoxSendToDealer.Enabled = true;
                    }
                    else
                    {
                        checkBoxSendToDealer.Enabled = false;
                        checkBoxSendToDealer.Visible = false;
                    }
                    checkBoxSendToDealer.Refresh();
                    // Customer Info 2
                    txtFirstPayDate.Enabled = true;
                    comboBoxDayDue.Enabled = true;
                    txtTerm.Enabled = true;
                    checkEditCollectionAgent.Enabled = true;
                    txtRegularPay.Enabled = true;
                    txtLoan.Enabled = true;
                    txtLoanInterest.Enabled = true;
                    txtAPR.Enabled = true;
                    txtCASH.Enabled = true;
                    txtNoOfPaymentsMade.Enabled = true;
                    // Moses Newman 01/08/2014 Do not enable override interest field if Annual Interest is set to ZERO!!!
                    if (iACDataSet.CUSTOMER.Rows[cUSTOMERBindingSource.Position].Field<Decimal>("CUSTOMER_ANNUAL_PERCENTAGE_RATE") != 0)
                        checkEditOverideInterest.Enabled = true;
                    else
                        checkEditOverideInterest.Enabled = false;
                    txtPaymentDate.Enabled = false;
                    txtPaymentDate.EditValue = null;
                    nullableDateTimePickerPayDate.EditValue = txtPaymentDate.EditValue;
                    nullableDateTimePickerPayDate.Text = txtPaymentDate.Text;
                    txtPaymentType.Enabled = true;
                    txtPaymentCode.Enabled = true;
                    txtLateCharge.Enabled = true;
                    txtLateChargeBal.Enabled = true;
                    txtLastPaymentMade.Enabled = true;
                    txtCustomerBalance.Enabled = true;
                    txtPaidInterest.Enabled = true;
                    txtUEInterest.Enabled = true;
                    txtPaidThrough.Enabled = true;
                    txtCustomerBuyout.Enabled = true;
                    txtCustomerPayRem2.Enabled = true;
                    txtDealerDisc.Enabled = true;
                    txtContractStatus.Enabled = true;
                    txtPaidDiscount.Enabled = true;
                    txtDealerDiscBal.Enabled = true;
                    txtCreditLimit.Enabled = true;
                    txtRebateCode.Enabled = true;
                    txtCreditAvailable.Enabled = true;
                    txtControlDate.Enabled = true;
                    txtNumberofMonths.Enabled = true;
                    // Moses Newman 08/26/2020 retired these objects
                    //txtCreditBureau.Enabled = true;
                    //listBoxTSBCommentCode.Enabled = true;
                    // Moses Newman 01/20/2015 Add Contract Date
                    DateTimePickerContractDate.Enabled = true;
                    // Moses Newman 06/19/2015 add TSB Payment Rating Override
                    // Moses Newman 08/26/2020 retired these items
                    //checkBoxTSBOverride.Enabled = true;
                    //comboBoxTSBPaymentRating.Enabled = true;
                    // Moses Newman 12/09/2018 Add OverrideLateCharge
                    checkBoxOverrideLateCharge.Enabled = true;
                    // Moses Newman 12/22/2019
                    nullableDateTimePickerFundingDate.Enabled = true;
                    // Moses Newman 07/21/2020 Add checkbox for overpayment check issue and check number.
                    checkBoxCheckIssued.Enabled = true;
                    textBoxCheckNo.Enabled = true;
                    // Moses Newman 02/28/2021 Add CheckBox for Received Contrat? and Date Contract Received fields
                    colorCheckBoxReceivedContract.Enabled = true;
                    if (colorCheckBoxReceivedContract.Checked)
                    {
                        nullableDateTimePickerDateContractReceived.Enabled = true;
                        nullableDateTimePickerDateContractReceived.Visible = true;
                    }
                    else
                    {
                        nullableDateTimePickerDateContractReceived.Enabled = false;
                        nullableDateTimePickerDateContractReceived.Visible = false;
                    }

                    txtCOSFirstName.Enabled = true;
                    txtCOSLastName.Enabled = true;
                    // Moses Newman 06/09/2017 changed txtCOSJunior to comboBox supporting gencodes.
                    comboBoxCOSJunior.Enabled = true;
                    txtCOSPhone.Enabled = true;
                    checkEditUsePrimaryAddress.Enabled = true;
                    txtCOSWorkPhone.Enabled = true;
                    txtCOSWorkExt.Enabled = true;
                    txtCOSAddress.Enabled = true;
                    txtCOSCell.Enabled = true;
                    txtCOSCity.Enabled = true;
                    txtCOSSS_1.Enabled = true;
                    txtCOSSS_2.Enabled = true;
                    txtCOSSS_3.Enabled = true;
                    txtCOSState.Enabled = true;
                    txtCOSZip.Enabled = true;
                    txtCOSDOB.Enabled = true;
                    txtCOSDOB.EditValue = null;
                    // Moses Newman 04/30/2019 Added CosignerTierPoints
                    textBoxCosignerTierPoints.Enabled = true;



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
                    // Moses Newman 01/29/2017
                    textBoxCosignerCreditScore.Enabled = true;
                    textBoxCosignerAnnualIncome.Enabled = true;
                    textBoxCosignerEmail.Enabled = true;

                    //EFT/eCHeck
                    textEditBankName.Enabled = true;
                    textEditBankCity.Enabled = true;
                    textEditBankState.Enabled = true;
                    textEditBankRoutingNumber.Enabled = true;
                    textEditBankCheckDigit.Enabled = true;
                    textEditBankAccountNumber.Enabled = true;
                    checkEditBankAutoPay.Enabled = true;
                    textEditBankMonthlyPayment.Enabled = true;
                    // Moses Newman 02/22/2023
                    radioGroupAccountType.Enabled = true;
                    // Moses Newman 01/29/2017 Added Maturity Date
                    MaturityDate.Enabled = true;

                    // Moses Newman 12/04/2023 
                    // Split Payments
                    comboBoxEditPaymentDay1.Enabled = true;
                    comboBoxEditPaymentDay2.Enabled = true;
                    comboBoxEditPaymentDay3.Enabled = true;
                    comboBoxEditPaymentDay4.Enabled = true;
                    textEditPayment1.Enabled = true;
                    textEditPayment2.Enabled = true;
                    textEditPayment3.Enabled = true;
                    textEditPayment4.Enabled = true;
                    checkEditSplitPay.Enabled = true;

                    // Vehice Tab
                    txtVehicleYear.Enabled = true;
                    txtMake.Enabled = true;
                    txtModel.Enabled = true;
                    txtVIN.Enabled = true;
                    txtInsuranceCompany.Enabled = true;
                    txtPolicyNumber.Enabled = true;
                    txtInsuranceAgent.Enabled = true;
                    txtAgentPhone.Enabled = true;
                    txtEffectiveDate.Enabled = true;
                    txtEffectiveDate.EditValue = null;

                    txtExpirationDate.Enabled = true;
                    txtExpirationDate.EditValue = null;

                    txtJointOwner.Enabled = true;
                    checkEditJointOwnership.Enabled = true;
                    // Moses Newman 01/30/2022 Verifacto Fields
                    textEditPolicyStatus.Enabled = true;
                    dateEditCancellationDate.Enabled = true;
                    textEditPortfolio.Enabled = true;
                    textEditIssueName1.Enabled = true;
                    dateEditIssueDate1.Enabled = true;
                    textEditIssueName2.Enabled = true;
                    dateEditIssueDate2.Enabled = true;
                    textEditIssueName3.Enabled = true;
                    dateEditIssueDate3.Enabled = true;
                    // Moses Newman 02/11/2022
                    checkEditHasCollision.Enabled = true;
                    checkEditHasComprehensive.Enabled = true;
                    textEditCollisionDeductible.Enabled = true;
                    textEditComprehensiveDeductible.Enabled = true;


                    // Moses Newman 12/18/2013 Add new fields to Vehicle tab and move Credit score, Repo, and Misc fields to Vehicle Tab.
                    textBoxMileage.Enabled = true;
                    nullableDateTimePickerRepoDate.Enabled = true;
                    textBoxRepoAgent.Enabled = true;
                    textBoxCurrentLocation.Enabled = true;
                    textBoxAuctionHouse.Enabled = true;
                    checkBoxTitleReceived.Enabled = true;
                    nullableDateTimePickerTitleDateReceived.Enabled = true;
                    // Moses Newman 09/08/2019 TitleReleased, DateTitleReleased, ElectronicLien
                    checkBoxTitleReleased.Enabled = true;
                    nullableDateTimePickerDateTitleReleased.Enabled = true;
                    checkBoxElectronicLien.Enabled = true;
                    cUSTOMER_CREDIT_SCORE_NTextBox.Enabled = true;
                    cUSTOMER_CREDIT_SCORE_ATextBox.Enabled = true;
                    // Moses Newman 12/9/2013 Add dropdowns for credit score and reposessions
                    cUSTOMER_REPO_INDtextBox.Enabled = true;
                    cUSTOMER_REPO_CDEtextBox.Enabled = true;
                    // Moses Newman 11/22/2016 Handle new IND code of R.
                    if (cUSTOMER_REPO_INDtextBox.Text == "Y" || cUSTOMER_REPO_INDtextBox.Text == "P" || cUSTOMER_REPO_INDtextBox.Text == "R" || cUSTOMER_REPO_INDtextBox.Text == "Z")
                    {
                        comboBoxRepoCodes.Enabled = true;
                    }
                    else
                        comboBoxRepoCodes.Enabled = false;
                    comboBoxRepoInd.Enabled = true;
                    cUSTOMER_COS_NAMETextBox.Enabled = true;
                    cUSTOMER_COS_PHONETextBox.Enabled = true;
                    // Moses Newman 01/09/2014 Add Current Location Date and Auction House Date
                    nullableDateTimePickerLocDate.Enabled = true;
                    nullableDateTimePickerAucDate.Enabled = true;
                    // Moses Newman 04/10/2014 Add Full Recourse Checkbox
                    checkBoxFullRecourse.Enabled = true;
                    // Moses Newman 06/13/2018 Add Full Recourse CheckBox to first tab also;
                    checkBoxFullRecourseTab1.Enabled = true;
                    // Moses Newman 01/29/2017
                    textBoxBuyersAnnualIncome.Enabled = true;
                    textBoxTier.Enabled = true;
                    // Moses Newman 04/30/2019 Added TierPoints
                    textBoxTierPoints.Enabled = true;
                    // Moses Newman 05/13/2019 Add LTV
                    textBoxLTV.Enabled = true;
                    // Moses Newman 05/20/2019 Added DealerCashPrice
                    textBoxDealerCashPrice.Enabled = true;



                    // Comment Tab
                    //Moses Newman 11/23/2021 Use DevExpress GridView instead of DataGridView for comments tab now
                    cOMMENTGridControl.Enabled = true;
                    cOMMENTgridView.OptionsBehavior.Editable = true;
                    cOMMENTgridView.OptionsView.NewItemRowPosition = NewItemRowPosition.Top;

                    checkBoxSimple.Checked = true;
                    checkBoxSimple.Visible = true;

                    // Moses Newman 06/12/2018
                    // Fees
                    textBoxRepoFees.Enabled = true;
                    textBoxStorageFees.Enabled = true;
                    textBoxImpoundFees.Enabled = true;
                    textBoxResaleFees.Enabled = true;
                    textBoxRepairFee1.Enabled = true;
                    textBoxRepairFee2.Enabled = true;
                    textBoxRepairFee3.Enabled = true;
                    textBoxRepairFee4.Enabled = true;
                    textBoxRepairFee5.Enabled = true;

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
                    cUSTOMER_PURCHASE_ORDERTextBox.Focus();
                    cUSTOMER_PURCHASE_ORDERTextBox.SelectAll();
                }
            }
            else
            {
                if (!lbAddFlag && !lbEdit)
                    toolStripButtonEdit.Enabled = true;
                // Moses Newman 06/12/2020 Add test for not posted, can only delete non posted new business!
                String lcHighValue = "" + (char)255;
                // Moses Newman 01/10/2024 Change Binding Source position to just 0 since there must only be one customer and positon could be off here
                if (iACDataSet.CUSTHIST.Rows.Count == 0 && !lbEdit && iACDataSet.CUSTOMER.Rows[0].Field<String>("CUSTOMER_POST_IND") == lcHighValue)
                    toolStripButtonDelete.Enabled = true;
                else
                    toolStripButtonDelete.Enabled = false;
                ActiveControl = cUSTOMER_FIRST_NAMETextBox;
                cUSTOMER_FIRST_NAMETextBox.Select();
            }
        }

        private void cUSTOMER_PURCHASE_ORDERTextBox_EditValueChanged(object sender, EventArgs e)
        {
            TextEdit textEdit = sender as TextEdit;

            // Moses Newman 05/21/2022 Move from Validated event!
            if (lbAddFlag || lbEdit || !String.IsNullOrEmpty(cUSTOMER_NOTextBox.EditValue.ToString().Trim()))
                return;     // If in add or Edit mode not doing a lookup on the PO Number!
            if (textEdit.EditValue == null)
                textEdit.EditValue = "";
            // Moses Newman 03/01/2011 Do Not Zero pad purchase order it must be right space padded to 8
            /*if (cUSTOMER_PURCHASE_ORDERTextBox.EditValue.ToString().Trim().Length < 8 && cUSTOMER_PURCHASE_ORDERTextBox.EditValue.ToString().Trim().Length > 0)
                cUSTOMER_PURCHASE_ORDERTextBox.EditValue = cUSTOMER_PURCHASE_ORDERTextBox.EditValue.ToString().PadRight(8, ' ');*/
            //cUSTOMER_NOTextBox.EditValue = "";
            setRelatedData();
            if (iACDataSet.CUSTOMER.Rows.Count == 0 && textEdit.EditValue.ToString().Trim().Length != 0)
            {
                MessageBox.Show("Sorry no customers found that match your selected purchase order number!");
                textEdit.EditValue = "";
                cUSTOMER_PURCHASE_ORDERTextBox.Focus();
                cUSTOMER_PURCHASE_ORDERTextBox.SelectAll();
            }
            else
            {
                ActiveControl = cUSTOMER_FIRST_NAMETextBox;
                cUSTOMER_FIRST_NAMETextBox.SelectAll();
            }
        }

        private void textEditWarrantyCompany_EditValueChanged(object sender, EventArgs e)
        {
            // Moses Newman 06/01/2022 Add Warranty Company Field
            if (lbAddFlag || lbEdit)
                toolStripButtonSave.Enabled = true;
        }

        // Moses Newman 02/22/2023
        private void radioGroupAccountType_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (lbEdit || lbAddFlag)
                toolStripButtonSave.Enabled = true;
        }

        private void hyperLinkEditWarrantyEmail_OpenLink(object sender, DevExpress.XtraEditors.Controls.OpenLinkEventArgs e)
        {
            if (e.EditValue.ToString().IsNullOrEmpty())
                return;
            const string mailPrefix = "mailto:";
            if (!e.EditValue.ToString().ToLower().StartsWith(mailPrefix))
            {
                e.EditValue = mailPrefix + e.EditValue.ToString();
            }
        }

        // Moses Newman 11/13/2023 Add filter selection of system generated comments only or all.
        private void cOMMENTgridView_CustomFilterDisplayText(object sender, DevExpress.XtraEditors.Controls.ConvertEditValueEventArgs e)
        {
            if (e.Value == null)
            {
                e.Value = "All Comments";
            }
            else
                switch (e.Value.ToString())
                {
                    // Moses Newman 11/15/2023 If TEXT SENT: and no template then treat as USER generated!
                    case "(Not StartsWith([COMMENT_WHOLE], 'TEXT SENT:') Or [SMSTemplate] <= 0) And [COMMENT_USERID] <> 'SYS'":
                        e.Value = "User Entered Comments Only";
                        break;
                    default:
                        e.Value = "System Generated Comments Only";
                        break;
                }
            e.Handled = true;
        }

        private void comboBoxEditPaymentDay1_EditValueChanged(object sender, EventArgs e)
        {
            if (lbAddFlag || lbEdit)
                toolStripButtonSave.Enabled = true;
        }

        private void comboBoxEditPaymentDay2_EditValueChanged(object sender, EventArgs e)
        {
            if (lbAddFlag || lbEdit)
                toolStripButtonSave.Enabled = true;
        }

        private void comboBoxEditPaymentDay3_EditValueChanged(object sender, EventArgs e)
        {
            if (lbAddFlag || lbEdit)
                toolStripButtonSave.Enabled = true;
        }

        private void comboBoxEditPaymentDay4_EditValueChanged(object sender, EventArgs e)
        {
            if (lbAddFlag || lbEdit)
                toolStripButtonSave.Enabled = true;
        }

        private void textEditPayment1_EditValueChanged(object sender, EventArgs e)
        {
            TextEdit textEdit = (TextEdit)sender;
            if (lbAddFlag || lbEdit)
            {
                toolStripButtonSave.Enabled = true;
            }
        }

        private void textEditPayment2_EditValueChanged(object sender, EventArgs e)
        {
            if (lbAddFlag || lbEdit)
            {
                toolStripButtonSave.Enabled = true;
            }
        }

        private void textEditPayment3_EditValueChanged(object sender, EventArgs e)
        {
            if (lbAddFlag || lbEdit)
            {
                toolStripButtonSave.Enabled = true;
            }
        }

        private void textEditPayment4_EditValueChanged(object sender, EventArgs e)
        {
            if (lbAddFlag || lbEdit)
            {
                toolStripButtonSave.Enabled = true;
            }
        }

        private void SumSplitPayments()
        {
            if (iACDataSet.OPNBANK.Rows.Count > 0)
            {
                Decimal SplitSum = 0, PaymentUnused = iACDataSet.OPNBANK.Rows[0].Field<Decimal>("OPNBANK_MONTHLY_PAYMENT");
                SplitSum += iACDataSet.OPNBANK.Rows[0].Field<Decimal?>("Payment1") != null ? iACDataSet.OPNBANK.Rows[0].Field<Decimal>("Payment1") : 0;
                SplitSum += iACDataSet.OPNBANK.Rows[0].Field<Decimal?>("Payment2") != null ? iACDataSet.OPNBANK.Rows[0].Field<Decimal>("Payment2") : 0;
                SplitSum += iACDataSet.OPNBANK.Rows[0].Field<Decimal?>("Payment3") != null ? iACDataSet.OPNBANK.Rows[0].Field<Decimal>("Payment3") : 0;
                SplitSum += iACDataSet.OPNBANK.Rows[0].Field<Decimal?>("Payment4") != null ? iACDataSet.OPNBANK.Rows[0].Field<Decimal>("Payment4") : 0;
                textEditTotalPayments.EditValue = SplitSum;
                textEditTotalPayments.Refresh();
                PaymentUnused -= SplitSum;
                textEditAmountUnused.EditValue = PaymentUnused;
                textEditAmountUnused.Refresh();
            }
        }

        private void textEditPayment1_Validated(object sender, EventArgs e)
        {
            SumSplitPayments();
        }

        private void textEditPayment2_Validated(object sender, EventArgs e)
        {
            SumSplitPayments();
        }

        private void textEditPayment3_Validated(object sender, EventArgs e)
        {
            SumSplitPayments();
        }

        private void textEditPayment4_Validated(object sender, EventArgs e)
        {
            SumSplitPayments();
        }

        private void textEditPayment1_Validating(object sender, CancelEventArgs e)
        {
            if (iACDataSet.OPNBANK.Rows.Count < 1)
                return;
            System.Globalization.CultureInfo info = System.Globalization.CultureInfo.GetCultureInfo("en-US");
            TextEdit textEdit = sender as TextEdit;
            Decimal OldValue = !textEdit.OldEditValue.ToString().IsNullOrEmpty() ? Convert.ToDecimal(textEdit.OldEditValue) : 0,
                    Unused = (Decimal?)textEditAmountUnused.EditValue != null ? Convert.ToDecimal(textEditAmountUnused.EditValue) : iACDataSet.OPNBANK.Rows[0].Field<Decimal>("OPNBANK_MONTHLY_PAYMENT"),
                    thisValue = !textEdit.EditValue.ToString().IsNullOrEmpty() ? Convert.ToDecimal(textEdit.EditValue) : 0;
            Unused += OldValue;
            if (thisValue > Unused)
            {
                e.Cancel = true;
                textEdit.ErrorText = "You only have " + Unused.ToString("c2", info) + " available!";
            }
        }

        private void textEditPayment2_Validating(object sender, CancelEventArgs e)
        {
            if (iACDataSet.OPNBANK.Rows.Count < 1)
                return;
            System.Globalization.CultureInfo info = System.Globalization.CultureInfo.GetCultureInfo("en-US");
            TextEdit textEdit = sender as TextEdit;
            Decimal OldValue = !textEdit.OldEditValue.ToString().IsNullOrEmpty() ? Convert.ToDecimal(textEdit.OldEditValue) : 0,
                    Unused = (Decimal?)textEditAmountUnused.EditValue != null ? Convert.ToDecimal(textEditAmountUnused.EditValue) : iACDataSet.OPNBANK.Rows[0].Field<Decimal>("OPNBANK_MONTHLY_PAYMENT"),
                    thisValue = !textEdit.EditValue.ToString().IsNullOrEmpty() ? Convert.ToDecimal(textEdit.EditValue) : 0;
            Unused += OldValue;
            if (thisValue > Unused)
            {
                e.Cancel = true;
                textEdit.ErrorText = "You only have " + Unused.ToString("c2", info) + " available!";
            }
        }

        private void textEditPayment3_Validating(object sender, CancelEventArgs e)
        {
            if (iACDataSet.OPNBANK.Rows.Count < 1)
                return;
            System.Globalization.CultureInfo info = System.Globalization.CultureInfo.GetCultureInfo("en-US");
            TextEdit textEdit = sender as TextEdit;
            Decimal OldValue = !textEdit.OldEditValue.ToString().IsNullOrEmpty() ? Convert.ToDecimal(textEdit.OldEditValue) : 0,
                    Unused = (Decimal?)textEditAmountUnused.EditValue != null ? Convert.ToDecimal(textEditAmountUnused.EditValue) : iACDataSet.OPNBANK.Rows[0].Field<Decimal>("OPNBANK_MONTHLY_PAYMENT"),
                    thisValue = !textEdit.EditValue.ToString().IsNullOrEmpty() ? Convert.ToDecimal(textEdit.EditValue) : 0;
            Unused += OldValue;
            if (thisValue > Unused)
            {
                e.Cancel = true;
                textEdit.ErrorText = "You only have " + Unused.ToString("c2", info) + " available!";
            }
        }

        private void textEditPayment4_Validating(object sender, CancelEventArgs e)
        {
            if (iACDataSet.OPNBANK.Rows.Count < 1)
                return;
            System.Globalization.CultureInfo info = System.Globalization.CultureInfo.GetCultureInfo("en-US");
            TextEdit textEdit = sender as TextEdit;
            Decimal OldValue = !textEdit.OldEditValue.ToString().IsNullOrEmpty() ? Convert.ToDecimal(textEdit.OldEditValue) : 0,
                    Unused = (Decimal?)textEditAmountUnused.EditValue != null ? Convert.ToDecimal(textEditAmountUnused.EditValue) : iACDataSet.OPNBANK.Rows[0].Field<Decimal>("OPNBANK_MONTHLY_PAYMENT"),
                    thisValue = !textEdit.EditValue.ToString().IsNullOrEmpty() ? Convert.ToDecimal(textEdit.EditValue) : 0;
            Unused += OldValue;
            if (thisValue > Unused)
            {
                e.Cancel = true;
                textEdit.ErrorText = "You only have " + Unused.ToString("c2", info) + " available!";
            }
        }

        private void checkEditSplitPay_CheckedChanged(object sender, EventArgs e)
        {
            CheckEdit checkEdit = sender as CheckEdit;

            if (lbAddFlag || lbEdit)
                toolStripButtonSave.Enabled = true;
            if (checkEdit.Checked)
                xtraTabControl1.TabPages[1].PageEnabled = true;
            else
                xtraTabControl1.TabPages[1].PageEnabled = false;
        }

        private void xtraTabControl1_SelectedPageChanged(object sender, DevExpress.XtraTab.TabPageChangedEventArgs e)
        {
            if (xtraTabControl1.SelectedTabPageIndex == 1)
                SumSplitPayments();
        }

        private void xtraTabControl1_Enter(object sender, EventArgs e)
        {
            if (checkEditSplitPay.Checked)
                xtraTabControl1.TabPages[1].PageEnabled = true;
            else
                xtraTabControl1.TabPages[1].PageEnabled = false;
        }

        private void xtraTabControlCustomerMaint_Click(object sender, EventArgs e)
        {

        }

        private void gridViewInvoices_CustomDrawFooterCell(object sender, FooterCellCustomDrawEventArgs e)
        {
            int dx = e.Bounds.Height;
            Brush brush = e.Cache.GetSolidBrush(DXSkinColors.ForeColors.Information);
            Rectangle r = e.Bounds;
            r.Inflate(-1, -1);
            e.Cache.FillRectangle(brush, r);
            r.Inflate(-6, 0);
            e.Appearance.ForeColor = Color.White;
            e.Appearance.DrawString(e.Cache, e.Info.DisplayText, r);
            e.Handled = true;
        }

        private void gridViewInvoices_CustomSummaryCalculate(object sender, CustomSummaryEventArgs e)
        {
            GridView view = sender as GridView;
            Decimal TotalContractStatus = 0, TotalLateChargeBalance = 0, TotalPartialPayment = 0;
            String FinalPaidThru = "";
            DateTime FinalPaidThroughDate = DateTime.Now.Date;   // Get the summary ID. 
            int summaryID = Convert.ToInt32((e.Item as GridSummaryItem).Tag);
            PaymentDataSetTableAdapters.InvoicesTableAdapter invoicesTableAdapter = new InvoicesTableAdapter();
            // Initialization. 
            if (e.SummaryProcess == CustomSummaryProcess.Start)
            {
                switch (summaryID)
                {
                    case 1: // The total summary calculated against the 'UnitPrice' column. 
                        Object loContractStatus = invoicesTableAdapter.ContractStatus((Int32)view.GetRowCellValue(e.RowHandle, "CustomerID"), DateTime.Now.Date);
                        TotalContractStatus = loContractStatus != null ? (Decimal)loContractStatus : 0;
                        e.TotalValue = TotalContractStatus;
                        break;
                    case 2:
                        Object loLateFeeBalance = invoicesTableAdapter.LateChargeBalance((Int32)view.GetRowCellValue(e.RowHandle, "CustomerID"));
                        TotalLateChargeBalance = loLateFeeBalance != null ? (Decimal)loLateFeeBalance : 0;
                        e.TotalValue = TotalLateChargeBalance;
                        break;
                    case 3:
                        Object loPartialPayment = invoicesTableAdapter.PartialPayment((Int32)view.GetRowCellValue(e.RowHandle, "CustomerID"));
                        TotalPartialPayment = loPartialPayment != null ? (Decimal)loPartialPayment : 0;
                        e.TotalValue = TotalPartialPayment;
                        break;
                    case 4:
                        Object loPaidThrough = invoicesTableAdapter.PaidThru((Int32)view.GetRowCellValue(e.RowHandle, "CustomerID"));
                        FinalPaidThru = loPaidThrough != null ? ((String)loPaidThrough).Substring(0, 2) + "/" + ((String)loPaidThrough).Substring(2, 2) : "";
                        e.TotalValue = FinalPaidThru;
                        break;
                    case 5:
                        Object loPaidThroughDate = invoicesTableAdapter.PaidThroughDate((Int32)view.GetRowCellValue(e.RowHandle, "CustomerID"));
                        FinalPaidThroughDate = loPaidThroughDate != null ? (DateTime)loPaidThroughDate : DateTime.Parse("01/01/1900");
                        e.TotalValue = FinalPaidThroughDate;
                        break;
                }
            }
        }
        
        private void cUSTOMER_NOTextBox_PreviewKeyDown(object sender, PreviewKeyDownEventArgs e)
        {
            /*if (e.KeyData == Keys.Tab)
                e.IsInputKey = true;*/
        }

        private void checkEditMilitary_CheckedChanged(object sender, EventArgs e)
        {
            Object SendTest = sender;
            CheckEdit edit = sender as CheckEdit;
            if (lbAddFlag || lbEdit)
                toolStripButtonSave.Enabled = true;
            if (edit.Checked)
            {
                edit.ForeColor = Color.Red;
                edit.Refresh();
            }
            else
            {
                edit.ForeColor = SystemColors.ControlText;
                edit.Refresh();
            }
        }
            private void barButtonItemCaculateBuyout_ItemClick(object sender, ItemClickEventArgs e)
        {
            MDIIAC2013 MDImain = (MDIIAC2013)MdiParent;
            MDImain.CreateFormInstance("CalcBuyout", false, false, true);
            CalcBuyout BuyOut = (CalcBuyout)MDImain.frm;

            BuyOut.gdsDataSet = iACDataSet;
            BuyOut.Show();
        }

        //Moses Newman 11/23/2021 Use DevExpress GridView instead of DataGridView for comments tab now
        private void cOMMENTgridView_InitNewRow(object sender, InitNewRowEventArgs e)
        {
            GridView view = sender as GridView;

            object loQuery = null;
            view.SetRowCellValue(e.RowHandle, "COMMENT_USERID", Program.gsUserID.TrimEnd());
            view.SetRowCellValue(e.RowHandle, "COMMENT_DATE", DateTime.Now.Date);
            view.SetRowCellValue(e.RowHandle, "COMMENT_NO", txtCommentNo.Text.ToString().TrimEnd());
            view.SetRowCellValue(e.RowHandle, "COMMENT_HHMMSS", 
                DateTime.Now.Hour.ToString().PadLeft(2, '0') + DateTime.Now.Minute.ToString().PadLeft(2, '0') + DateTime.Now.Second.ToString().PadLeft(2, '0'));
            if (lnSeq == 0)
            {
                loQuery = cOMMENTTableAdapter.SeqNoQuery(txtCommentNo.Text.ToString().TrimEnd(), DateTime.Now.Date);
                if (loQuery != null)
                    lnSeq = (int)loQuery + 1;
                else
                    lnSeq = 1;
            }
            else
                lnSeq = lnSeq + 1;
            view.SetRowCellValue(e.RowHandle, "COMMENT_SEQ_NO", lnSeq);
            view.SetRowCellValue(e.RowHandle, "COMMENT_DEALER", (Int32)cUSTOMER_DEALERcomboBox.EditValue);
        }

        //Moses Newman 11/23/2021 Use DevExpress GridView instead of DataGridView for comments tab now
        private void cOMMENTgridView_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Delete && e.Modifiers == Keys.Control && (lbEdit || lbAddFlag))
            {
                if (MessageBox.Show("Delete row?", "Confirmation", MessageBoxButtons.YesNo) !=
                  DialogResult.Yes)
                    return;
                GridView view = sender as GridView;
                view.DeleteRow(view.FocusedRowHandle);
                toolStripButtonSave.Enabled = true;
            }
        }

        private void CalcTotalFees()
        {
            gnTotalFees = gnRepoFees + gnStorageFees + gnImpoundFees + gnResaleFees + gnRepairFee1 + gnRepairFee2 +
                          gnRepairFee3 + gnRepairFee4 + gnRepairFee5;
            textBoxTotalFees.Text = gnTotalFees.ToString("C", CultureInfo.CreateSpecificCulture("en-US"));
            textBoxTotalFees.Refresh();
        }

        private void checkBoxWarranty_CheckedChanged(object sender, EventArgs e)
        {
            if (lbAddFlag || lbEdit)
                toolStripButtonSave.Enabled = true;
        }

        private void comboBoxGN_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (lbAddFlag || lbEdit)
                toolStripButtonSave.Enabled = true;
        }

        private String sbtLogin()
        {
            LoginAPIClient login = new LoginAPIClient("LoginAPIServiceHttpEndpoint");

            // Create loginRequestDetails
            LoginRequestDetails loginRequestDetails = new LoginRequestDetails();

            loginRequestDetails.APIKey = "Arm7TJLjZmsxS3NZm3cxkltVhUFnjjyJImm4sG62P9KhUj0p0r6p9rYHXBwxoU1E";
            WSLoginResponse wSLoginResponse = login.AuthenticateAPIKey(loginRequestDetails);

            //process response
            if (!wSLoginResponse.Result)
            {
                //handle error
                // txtToken.Text = wSLoginResponse.Message;

                return "BadKey" + wSLoginResponse.Message;
            }
            else
            {
                return wSLoginResponse.SecurityToken;
            }
        }

        private void buttonValidate_Click(object sender, EventArgs e)
        {
            if (!lbAddFlag && !lbEdit)
                return;

            GroupClient generalService = new GroupClient("ReportWSServiceHttpEndpoint2");
            string securityToken = sbtLogin();
            string orgCode = "wt63419";
            string[] phone = cUSTOMER_CELL_PHONETextBox.Text.Trim().Split(',');

            WSCarrierLookupResponse wSCarrierLookupResponse = generalService.GetCarrierLookup(securityToken, phone, orgCode);

            if (!wSCarrierLookupResponse.Result)
            {
                MakeComment("*** Failed to VALIDATE cell phone number! ***", wSCarrierLookupResponse.Message, 0, false);
                //handle error
                buttonValidate.ForeColor = Color.Crimson;
                iACDataSet.CUSTOMER.Rows[0].SetField<Boolean>("CellValid", false);
            }
            else
            {
                if (wSCarrierLookupResponse.Result && !wSCarrierLookupResponse.Response[0].Landline)
                {
                    MakeComment("Cell Phone Number VALIDATED.", wSCarrierLookupResponse.Message, 0, false);
                    buttonValidate.ForeColor = Color.Green;
                    iACDataSet.CUSTOMER.Rows[0].SetField<Boolean>("CellValid", true);
                    // Moses Newman reset PIN from AUTO to nothing 07/08/2022
                    iACDataSet.CUSTOMER.Rows[0].SetField<String>("TPin", "");
                    cUSTOMERBindingSource.EndEdit();
                    radioButtonAcct.Checked = false; 
                }
                else
                {
                    MakeComment("*** Cell Number not VALIDATED because it is a LANDLINE! ***", wSCarrierLookupResponse.Message, 0, false);
                    buttonValidate.ForeColor = Color.Crimson;
                    iACDataSet.CUSTOMER.Rows[0].SetField<Boolean>("CellValid", false);
                    // Moses Newman reset PIN from AUTO to nothing 07/08/2022
                    iACDataSet.CUSTOMER.Rows[0].SetField<String>("TPin", "");
                    cUSTOMERBindingSource.EndEdit();
                    radioButtonAcct.Checked = false;
                }
            }
            toolStripButtonSave.Enabled = true;
        }

        private void buttonConfirm_Click(object sender, EventArgs e)
        {
            return;
        }

        private void radioButtonAcct_Click(object sender, EventArgs e)
        {
            if (textBoxAuthNo.Text.TrimEnd() != "" || cUSTOMER_CELL_PHONETextBox.Text.TrimEnd() == "" || buttonValidate.ForeColor != Color.Green)
            {
                if (radioButtonAcct.Checked)
                {
                    radioButtonAcct.Checked = false;
                    checkBoxDNTAcct.Checked = true;
                }
                return;
            }
            if (lbAddFlag || lbEdit)
                toolStripButtonSave.Enabled = true;
            if (radioButtonAcct.Checked)
            {
                string VBTError = "";
                MessageClient messageResult = new MessageClient("MessageWSServiceHttpEndpoint");
                string securityToken = sbtLogin();
                string orgCode = "wt63419";
                string phoneNo = cUSTOMER_CELL_PHONETextBox.Text;

                WSVerificationResponse wSVerificationResponse = messageResult.RequestVBT(securityToken, orgCode, phoneNo);
                if (!wSVerificationResponse.Result)
                {
                    iACDataSet.CUSTOMER.Rows[0].SetField<String>("TPin", "");
                    textBoxAuthNo.Refresh();

                    VBTError = wSVerificationResponse.Message;
                    if (VBTError.TrimEnd() != "Subscriber information already exists")
                    {
                        iACDataSet.CUSTOMER.Rows[0].SetField<Boolean>("TAcct", false);
                        MakeComment("*** VBT PIN NOT CREATED! ***", VBTError, 0, false);
                        MessageBox.Show(VBTError);
                    }
                }
                else
                {
                    iACDataSet.CUSTOMER.Rows[0].SetField<Boolean>("DNTAcct", false);
                    iACDataSet.CUSTOMER.Rows[0].SetField<Boolean>("TAcct", true);
                    iACDataSet.CUSTOMER.Rows[0].SetField<String>("TPin", "AUTO");
                    textBoxAuthNo.Refresh();
                    radioButtonAcct.Checked = true;
                    radioButtonMktg.Checked = false;
                    UpdateSubscriber(securityToken);
                    iACDataSet.CUSTOMER.Rows[0].SetField<Boolean>("TConfirmed", true);
                    buttonConfirm.ForeColor = Color.Green;
                    MakeComment("AUTO CONFIRMED (NO PIN)!", "AUTO", 0, false);
                }
            }
        }

        private void checkBoxDNTAcct_Click(object sender, EventArgs e)
        {
            var ldlgResult = MessageBox.Show("Are you absolutely sure you want to unsubcribe this subscriber?  If you do so you will have to verify by text and reconfirm the subscriber again if at a later date you wish to reinstate this subscriber!", "Change Statuts to DO NOT TEXT", MessageBoxButtons.YesNo);
            if (ldlgResult == DialogResult.No)
                return;
            if (lbAddFlag || lbEdit)
                toolStripButtonSave.Enabled = true;
            SubscriberClient subscriberResult = new SubscriberClient("SubscriberWSServiceHttpEndpoint");

            string securityToken = sbtLogin();

            SubscriberDetails subscriber = new SubscriberDetails();
            subscriber.MobilePhone = cUSTOMER_CELL_PHONETextBox.Text;
            subscriber.OrgCode = "wt63419";
            WSUnsubscriberResponse wsUnSubscribeResponse = subscriberResult.UnSubscribe(securityToken, subscriber);

            if (!wsUnSubscribeResponse.Result && (wsUnSubscribeResponse.Message != "Subscriber already unsubscribed"))
            {
                iACDataSet.CUSTOMER.Rows[0].SetField<Boolean>("DNTAcct", false);
                MessageBox.Show(wsUnSubscribeResponse.Message);
                MakeComment("*** UNSUBSCRIBE SBT FAILED! ***", wsUnSubscribeResponse.Message, 0, false);
            }
            else
            {
                iACDataSet.CUSTOMER.Rows[0].SetField<Boolean>("TAcct", false);
                radioButtonAcct.Checked = false;
                iACDataSet.CUSTOMER.Rows[0].SetField<String>("TPin", "");
                buttonConfirm.ForeColor = Color.Crimson;
                iACDataSet.CUSTOMER.Rows[0].SetField<Boolean>("TConfirmed", false);
                iACDataSet.CUSTOMER.Rows[0].SetField<Boolean>("DNTAcct", true);
                MakeComment("CELL PHONE UNSUBSCRIBED FROM SBT.", wsUnSubscribeResponse.Message, 0, false);
                MessageBox.Show(wsUnSubscribeResponse.Message, "Unsubscribed");
            }
        }

        private void UpdateSubscriber(string securityToken)
        {
            SubscriberClient subscriberService = new SubscriberClient("SubscriberWSServiceHttpEndpoint");


            SubscriberInfo subscriber = new SubscriberInfo();

            subscriber.MobilePhone = cUSTOMER_CELL_PHONETextBox.Text;

            subscriber.FName = cUSTOMER_FIRST_NAMETextBox.Text;
            subscriber.LName = cUSTOMER_LAST_NAMETextBox.Text;
            subscriber.Email = richTextBoxEmailAddress.Text;
            subscriber.City = cUSTOMER_CITYTextBox.Text;
            subscriber.Street = cUSTOMER_STREET_1TextBox.Text;
            subscriber.Street2 = cUSTOMER_STREET_2TextBox.Text;
            subscriber.ZipCode = cUSTOMER_ZIP_1TextBox.Text + cUSTOMER_ZIP_2TextBox.Text;
            subscriber.CustomField1 = "";
            subscriber.CustomField2 = "";
            subscriber.CustomField3 = "";
            subscriber.PrivateCode = !String.IsNullOrEmpty((String)cUSTOMER_PURCHASE_ORDERTextBox.EditValue) ? cUSTOMER_PURCHASE_ORDERTextBox.EditValue.ToString().Trim():"";
            subscriber.UniqueID = cUSTOMER_NOTextBox.EditValue.ToString().Trim();

            WSSubscriberResponse wSSubscriberResponse = subscriberService.UpdateSubscriber(securityToken, subscriber);

            if (!wSSubscriberResponse.Result)
            {
                MakeComment("*** SBT SUBSCRIBER FIELDS UPDATE FAILED! ***", wSSubscriberResponse.Message, 0, false);
                MessageBox.Show(wSSubscriberResponse.Message);
            }
            else
            {
                MakeComment("SBT SUBSCRIBER FIELDS UPDATED.", wSSubscriberResponse.Message, 0, false);
            }
        }

        private void UpdateSubscriberCOS(string securityToken)
        {
            SubscriberClient subscriberService = new SubscriberClient("SubscriberWSServiceHttpEndpoint");


            SubscriberInfo subscriber = new SubscriberInfo();

            subscriber.MobilePhone = txtCOSCell.Text;

            subscriber.FName = txtCOSFirstName.Text;
            subscriber.LName = txtCOSLastName.Text;
            subscriber.Email = textBoxCosignerEmail.Text;
            subscriber.City = txtCOSCity.Text;
            subscriber.Street = txtCOSAddress.Text;
            subscriber.Street2 = "";
            subscriber.ZipCode = txtCOSZip.Text;
            subscriber.CustomField1 = "";
            subscriber.CustomField2 = "";
            subscriber.CustomField3 = "";
            subscriber.PrivateCode = cUSTOMER_PURCHASE_ORDERTextBox.EditValue.ToString().Trim() + "COS";
            subscriber.UniqueID = cUSTOMER_NOTextBox.EditValue.ToString().Trim() + "COS";

            WSSubscriberResponse wSSubscriberResponse = subscriberService.UpdateSubscriber(securityToken, subscriber);

            if (!wSSubscriberResponse.Result)
            {
                MakeComment("*** SBT COSIGNER SUBSCRIBER FIELDS UPDATE FAILED! ***", wSSubscriberResponse.Message, 0, false);
                MessageBox.Show(wSSubscriberResponse.Message);
            }
            else
            {
                MakeComment("SBT COSIGNER SUBSCRIBER FIELDS UPDATED.", wSSubscriberResponse.Message, 0, false);
            }
        }

        private void buttonMessage_Click(object sender, EventArgs e)
        {
            String lsMessage = "", lsAPIMessage = "";
            Int32 lnTemplateID = 0;

            FormSMSMessage newmessage = new FormSMSMessage();
            newmessage.CellPhone = cUSTOMER_CELL_PHONETextBox.Text.TrimEnd();
            //newmessage.securityToken = sbtLogin(); login now from Message Form! 08/12/2020 Moses Newman
            newmessage.CustomerNo = iACDataSet.CUSTOMER.Rows[0].Field<String>("CUSTOMER_NO");
            newmessage.ShowDialog();
            lsMessage = newmessage.MessageSent;
            lnTemplateID = newmessage.TempID;
            lsAPIMessage = newmessage.APIMessage;
            newmessage.Hide();
            newmessage.Dispose();

            if(lsMessage != "NONE")
                if (lsMessage != "")
                    MakeComment(lsMessage, lsAPIMessage, lnTemplateID);
                else
                    MakeComment("Message SEND failed!", lsAPIMessage, lnTemplateID, false);
        }

        private String GetSubscriberStatus(String mobileNumber)
        {
            SubscriberClient subscriberService = new SubscriberClient("SubscriberWSServiceHttpEndpoint");
            string securityToken = sbtLogin();
            string orgCode = "wt63419";
            List<string> phone = new List<string>();

            phone.Add(mobileNumber);
            WSSubscribersStatusResponse wSSubscribersStatusResponse;

            // Moses Newman 07/12/2019 catch EndpointNotFound errors.
            try
            {
                wSSubscribersStatusResponse = subscriberService.GetSubscribersStatus(securityToken, orgCode, phone.ToArray());
            }
            catch (System.ServiceModel.EndpointNotFoundException e)
            {
                return e.Message;
            }
            catch(System.ServiceModel.ServerTooBusyException e)
            {
                return e.Message;
            }
            if (!wSSubscribersStatusResponse.Result)
            {
                return wSSubscribersStatusResponse.Message;
            }
            else
            {
                return wSSubscribersStatusResponse.Response[0].Status;
            }
        }

        private void cUSTOMER_CELL_PHONETextBox_Validated(object sender, EventArgs e)
        {
            if (lbEdit)
                if (((MaskedTextBox)sender).Text != (String)((MaskedTextBox)sender).Tag)
                {
                    if (iACDataSet.CUSTOMER.Rows[0].Field<Boolean>("TConfirmed"))
                    {
                        SubscriberClient subscriberResult = new SubscriberClient("SubscriberWSServiceHttpEndpoint");

                        string securityToken = sbtLogin();

                        SubscriberDetails subscriber = new SubscriberDetails();
                        // Moses Newman 09/13/2017 use OLD phone number!
                        subscriber.MobilePhone = (String)cUSTOMER_CELL_PHONETextBox.Tag;
                        subscriber.OrgCode = "wt63419";
                        WSUnsubscriberResponse wsUnSubscribeResponse = subscriberResult.UnSubscribe(securityToken, subscriber);

                        if (!wsUnSubscribeResponse.Result && (wsUnSubscribeResponse.Message != "Subscriber already unsubscribed"))
                        {
                            MessageBox.Show(wsUnSubscribeResponse.Message);
                            iACDataSet.CUSTOMER.Rows[0].SetField<Boolean>("DNTAcct", false);
                        }
                        else
                        {
                            iACDataSet.CUSTOMER.Rows[0].SetField<Boolean>("TAcct", false);
                            radioButtonAcct.Checked = false;
                            iACDataSet.CUSTOMER.Rows[0].SetField<String>("TPin", "");
                            buttonConfirm.ForeColor = Color.Crimson;
                            iACDataSet.CUSTOMER.Rows[0].SetField<Boolean>("TConfirmed", false);
                            iACDataSet.CUSTOMER.Rows[0].SetField<Boolean>("DNTAcct", true);
                        }

                    }
                    buttonValidate.ForeColor = Color.Crimson;
                    toolStripButtonSave.Enabled = true;
                    iACDataSet.CUSTOMER.Rows[0].SetField<Boolean>("CellValid", false);
                    iACDataSet.CUSTOMER.Rows[0].EndEdit();
                }
        }

        private void MakeComment(String CommentMessage, String APIMessage, Int32 tnTemplateNo = 0, Boolean tbAddTextSent = true,Boolean tbCosginerTextSent = false)
        {
            // Moses Newman 07/22/2022
            if (iACDataSet.CUSTOMER.Rows.Count < 1)
                return;
            CommentMessage = CommentMessage.Replace("{MISC$}", iACDataSet.CUSTOMER.Rows[0].Field<Decimal>("CUSTOMER_REGULAR_AMOUNT").ToString("C", new CultureInfo("en-US")));
            CommentMessage = CommentMessage.Replace("{MISC1}", Program.NextDueDate(0, iACDataSet).ToString("d", new CultureInfo("en-US")));
            Object oMissing = System.Reflection.Missing.Value,
                   oTrue = false,
                   oFalse = true,
                   loQuery = null,
                   start = 0,
                   end = 0, FileName = "";

            Int32 lnSeq = 0;
            String lsCommentKey = "",lsFullComment = "";

            Microsoft.Office.Interop.Word._Application oWord = new Microsoft.Office.Interop.Word.Application();
            oWord.Visible = true;
            Microsoft.Office.Interop.Word._Document oWordDoc = new Microsoft.Office.Interop.Word.Document();

            oWordDoc = oWord.Documents.Add();
            Microsoft.Office.Interop.Word.Range rng = oWordDoc.Range(ref start, ref end);

            Object oTemplatePath = "";

            if (lnSeq == 0)
            {
                loQuery = cOMMENTTableAdapter.SeqNoQuery(iACDataSet.CUSTOMER.Rows[0].Field<String>("CUSTOMER_NO"), DateTime.Now.Date);
                if (loQuery != null)
                    lnSeq = (int)loQuery + 1;
                else
                    lnSeq = 1;
            }
            else
                lnSeq = lnSeq + 1;
            // Moses Newman 10/18/2017 create string unique key that will become word filename!
            lsCommentKey = cUSTOMER_NOTextBox.EditValue.ToString().Trim() + DateTime.Now.Date.ToString("yyyyMMdd") + lnSeq.ToString().Trim() + Program.gsUserID;
            // Moses Newman 11/21/2017 Remove hard coded UNC Pathing.
            FileName = lsUNCROOT + @"CommentAttachments\SMS\" + lsCommentKey + ".docx";
            rng.Text = CommentMessage;
            rng.Select();
            oWordDoc.Application.ActiveDocument.SaveAs2(FileName,
                                                         Microsoft.Office.Interop.Word.WdSaveFormat.wdFormatDocumentDefault,
                                                         ref oMissing,
                                                         ref oMissing,
                                                         ref oMissing,
                                                         ref oMissing,
                                                         ref oMissing,
                                                         oTrue,
                                                         ref oMissing,
                                                         oTrue,
                                                         ref oMissing,
                                                         ref oMissing,
                                                         ref oMissing,
                                                         ref oMissing,
                                                         ref oMissing,
                                                         ref oMissing,
                                                         ref oMissing);
            oWordDoc.Saved = true;
            oWordDoc.Close(ref oFalse, ref oMissing, ref oMissing);
            oWordDoc = null;
            oWord.Quit();
            oWord = null;
            WholeComment loTempComment;

            CommentMessage = (tbAddTextSent) ? (!tbCosginerTextSent ? "TEXT SENT: " : "COSIGNER TEXT SENT: ") + CommentMessage : CommentMessage;
            loTempComment = SplitComments(CommentMessage + " API MSG: " + APIMessage);
            // Moses Newman 02/22/2019 Add Full Comment
            lsFullComment = loTempComment.Field1 + loTempComment.Field2 + loTempComment.Field3;
            cOMMENTTableAdapter.Insert(iACDataSet.CUSTOMER.Rows[0].Field<String>("CUSTOMER_NO"),
                                        DateTime.Now.Date, lnSeq,
                                        Program.gsUserID,
                                        lsFullComment,
                                        //loTempComment.Field1,
                                        //loTempComment.Field2,
                                        //loTempComment.Field3,
                                        "",
                                        iACDataSet.CUSTOMER.Rows[0].Field<Int32>("CUSTOMER_DEALER"),
                                        Program.gsUserID + "  ",
                                        DateTime.Now.Hour.ToString().PadLeft(2, '0') + DateTime.Now.Minute.ToString().PadLeft(2, '0') + DateTime.Now.Second.ToString().PadLeft(2, '0'),
                                        false, "", "",
                                        0, @"WordDoc.bmp", FileName.ToString(), tnTemplateNo);

            cOMMENTTableAdapter.FillByCustNo(iACDataSet.COMMENT, cUSTOMER_NOTextBox.EditValue.ToString().Trim());
            if (lbAddFlag || lbEdit)
                toolStripButtonSave.Enabled = true;
        }

        private void checkBoxDNTAcct_CheckedChanged(object sender, EventArgs e)
        {
            if (lbAddFlag || lbEdit)
                toolStripButtonSave.Enabled = true;
        }

        private void checkBoxDNTMktg_CheckedChanged(object sender, EventArgs e)
        {
            if (lbAddFlag || lbEdit)
                toolStripButtonSave.Enabled = true;
        }

        private void radioButtonAcct_CheckedChanged(object sender, EventArgs e)
        {
            if (lbAddFlag || lbEdit)
                toolStripButtonSave.Enabled = true;
        }

        private void radioButtonMktg_CheckedChanged(object sender, EventArgs e)
        {
            if (lbAddFlag || lbEdit)
                toolStripButtonSave.Enabled = true;
        }

        private WholeComment SplitComments(String tsComment)
        {
            WholeComment loReturn;

            String lsComment1, lsComment2, lsComment3;
            Int32 lnCommentLength = 0;

            lsComment1 = "";
            lsComment2 = "";
            lsComment3 = "";
            lnCommentLength = tsComment.Length;
            if (lnCommentLength <= 60)
                lsComment1 = tsComment;
            else
            {
                lsComment1 = tsComment.Substring(0, 60);
                if (lnCommentLength <= 120)
                    lsComment2 = tsComment.Substring(60, lnCommentLength - 60);
                else
                {
                    lsComment2 = tsComment.Substring(60, 60);
                    lsComment3 = tsComment.Substring(120, lnCommentLength - 120);
                }
            }

            loReturn.Field1 = lsComment1;
            loReturn.Field2 = lsComment2;
            loReturn.Field3 = lsComment3;

            return loReturn;
        }

        // Moses Newman 11/09/2017 Add Mail Button to Cosinger Info screen.
        private void buttonSendMailCosigner_Click(object sender, EventArgs e)
        {
            if (iACDataSet.CUSTOMER.Rows.Count == 0 || textBoxCosignerEmail.Text.TrimEnd() == "")
                return;
            
            CreateOutlookEmail(textBoxCosignerEmail.Text);
        }

        // Moses Newman 01/24/2018 added Exclude VSI
        private void checkBoxExcludeVSI_CheckedChanged(object sender, EventArgs e)
        {
            if (lbAddFlag || lbEdit)
                toolStripButtonSave.Enabled = true;
        }

        private void comboBoxCosLetterNo_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (lbEdit)
                toolStripButtonSave.Enabled = true;
            if (comboBoxCosLetterNo.SelectedIndex > 0 && lbEdit)
            {
                comboBoxCosLetterType.Enabled = false;
                buttonCosLetter.Enabled = false;
            }
            else
            {
                if (comboBoxCosLetterNo.SelectedIndex == 0)
                    comboBoxCosLetterType.Text = " ";
                comboBoxCosLetterType.Enabled = true;
                buttonCosLetter.Enabled = true;
            }
        }

        private void buttonCosLetter_Click(object sender, EventArgs e)
        {
            Int32 lnSeq = 0;
            object loQuery = null;
            String lsCommentKey = "",lsFullComment = "";
            IACDataSetTableAdapters.CUSTOMERTableAdapter CustomerTableAdapter = new IACDataSetTableAdapters.CUSTOMERTableAdapter();
            IACDataSetTableAdapters.COMMENTTableAdapter COMMENTTableAdapter = new IACDataSetTableAdapters.COMMENTTableAdapter();

            String lsLetterNo = comboBoxCosLetterNo.Text.TrimEnd(), lsLetterType = comboBoxCosLetterType.Text.TrimEnd().ToUpper();
            if (iACDataSet.CUSTOMER.Rows.Count == 0)
            {
                return;
            }

            cOMMENTBindingSource.AddNew();
            cOMMENTBindingSource.EndEdit();
            if (lnSeq == 0)
            {
                loQuery = cOMMENTTableAdapter.SeqNoQuery(cUSTOMER_NOTextBox.EditValue.ToString().Trim(), DateTime.Now.Date);
                if (loQuery != null)
                    lnSeq = (int)loQuery + 1;
                else
                    lnSeq = 1;
            }
            else
                lnSeq = lnSeq + 1;

            // Moses Newman 10/18/2017 create string unique key that will become word filename!
            lsCommentKey = cUSTOMER_NOTextBox.EditValue.ToString().Trim() + DateTime.Now.Date.ToString("yyyyMMdd") + lnSeq.ToString().Trim() + Program.gsUserID;
            MailMergeComponents MailMerge = new MailMergeComponents();
            lsDataPath = lsUNCROOT.Trim() + @"CommentAttachments\Letters\";
            // Moses Newman 11/21/2017 Remove hard coded UNC Pathing
            MailMerge.CreateMailMerge(iACDataSet, true, @"AUTOLETTERCOS#" + lsLetterNo, lsLetterType, false, "", lsDataPath + lsCommentKey + ".docx");
            // Moses Newman 02/22/2019 Add Full Comment
            lsFullComment = "Created and sent cosigner Letter#" + comboBoxCosLetterNo.Text.TrimEnd().TrimStart() + ".";
            // Moses Newman 11/21/2017 Remove hard coded UNC Pathing
            cOMMENTTableAdapter.Insert(cUSTOMER_NOTextBox.EditValue.ToString().Trim(), DateTime.Now.Date, lnSeq, Program.gsUserID,
                                       lsFullComment,
                                       //"Created and sent cosigner Letter#" + comboBoxCosLetterNo.Text.TrimEnd().TrimStart() + ".",
                                       //" ", " ", 
                                       "  ", (Int32)cUSTOMER_DEALERcomboBox.EditValue,
                                       Program.gsUserID + "  ",
                                       DateTime.Now.Hour.ToString().PadLeft(2, '0') + DateTime.Now.Minute.ToString().PadLeft(2, '0') + DateTime.Now.Second.ToString().PadLeft(2, '0'),
                                       false, @"WordDoc.bmp", lsDataPath + lsCommentKey + ".docx",
                                       Convert.ToInt32(comboBoxCosLetterNo.Text.TrimEnd().TrimStart()), "", "", 0);
            cOMMENTTableAdapter.FillByCustNo(iACDataSet.COMMENT, cUSTOMER_NOTextBox.EditValue.ToString().Trim());

            comboBoxCosLetterNo.Text = " ";
            comboBoxCosLetterType.Text = " ";
        }

        private void comboBoxCosLetterType_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (lbEdit)
                toolStripButtonSave.Enabled = true;
        }

        private void comboBoxRepoInd_SelectedIndexChanged(object sender, EventArgs e)
        {
            if ((lbAddFlag || lbEdit) && comboBoxRepoInd.SelectedIndex > -1)
            {
                cUSTOMER_REPO_INDtextBox.Text = iACDataSet.RepoIndicators.Rows[comboBoxRepoInd.SelectedIndex].Field<String>("Code");
                iACDataSet.CUSTOMER.Rows[cUSTOMERBindingSource.Position].SetField<String>("CUSTOMER_REPO_IND", iACDataSet.RepoIndicators.Rows[comboBoxRepoInd.SelectedIndex].Field<String>("Code"));
                toolStripButtonSave.Enabled = true;
                RepoIndicatorsBindingSource.EndEdit();
                comboBoxRepoCodes.Enabled = true;
            }
        }
    }
}

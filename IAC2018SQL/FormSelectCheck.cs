using IAC2021SQL.IACDataSetTableAdapters;
using System;
using System.Data;
using System.Windows.Forms;
using DevExpress.XtraGrid.Views.Grid;
using DevExpress.Utils.Html;
using DevExpress.XtraEditors;



namespace IAC2021SQL
{
    public partial class FormSelectCheck : DevExpress.XtraEditors.XtraForm
    {
        private String _CustNo,_ISFPaymentType,_ISFPaymentCode;
        private DateTime _ISFDate;
        private Boolean _IsClosed,_IsSimple,_IsNotCheck = true,_DoNotShow = false;
        private Decimal _PaidInt, _LateCharge;
        private Int32 _ISFSeqNo,_ISFID;

        public String lsCustomer
        {
            get { return _CustNo; }
            set { _CustNo = lsCustomer; }
        }

        public DateTime ldISFDate
        {
            get { return _ISFDate; }
            set { _ISFDate = ldISFDate; }
        }

        public Decimal lnLateChargePaid
        {
            get { return _LateCharge; }
            set { _LateCharge = lnLateChargePaid; }
        }

        public Decimal lnCurrInt
        {
            get { return _PaidInt; }
            set { _PaidInt = lnCurrInt; }
        }

        public Boolean lbIsSimple
        {
            get { return _IsSimple; }
            set { _IsSimple = lbIsSimple; }
        }

        // Moses Newman add IsNotCheck property to flag use of NonCheck HistoryFill
        public Boolean IsNotCheck
        {
            get { return _IsNotCheck; }
            set { _IsNotCheck = IsNotCheck; }
        }

        // Moses Newman 10/09/2020 Add IsINSUF
        public Int32 ISFID
        {
            get { return _ISFID; }
            set { _ISFID = ISFID; }
        }

        public Boolean DoNotShow
        {
            get { return _DoNotShow; }
            set { _DoNotShow = DoNotShow; }
        } 

        // Moses Newman 04/13/2018 added ISFSeqNo, ISFPaymentType, and ISFPaymentCode properties.
        public Int32 ISFSeqNo
        {
            get { return _ISFSeqNo; }
            set { _ISFSeqNo = ISFSeqNo; }
        }

        public String ISFPaymentType
        {
            get { return _ISFPaymentType; }
            set { _ISFPaymentType = ISFPaymentType; }
        }

        private void gridView1_RowClick(object sender, DevExpress.XtraGrid.Views.Grid.RowClickEventArgs e)
        {
            GridView view = sender as GridView;
            int index = view.GetDataRowHandleByGroupRowHandle(e.RowHandle);
            var cellValue = view.GetRowCellValue(index, "CUSTHIST_PAY_DATE");
            int dataSourceRowIndex = view.GetDataSourceRowIndex(e.RowHandle);
            if (!_IsClosed)
            {
                if (iACDataSet.OPNCUST.Count > 0 && view.SelectedRowsCount > 0)
                {
                    _ISFDate = (DateTime)cellValue;
                    Close();
                }
            }
            else
            {
                if (iACDataSet.CUSTOMER.Count > 0 && view.SelectedRowsCount > 0)
                {
                    _ISFDate = (DateTime)cellValue;
                    _PaidInt = iACDataSet.CUSTHIST.Rows[dataSourceRowIndex].Field<Decimal>("CUSTHIST_CURR_INT");
                    _LateCharge = iACDataSet.CUSTHIST.Rows[dataSourceRowIndex].Field<Decimal>("CUSTHIST_LATE_CHARGE_PAID");
                    _IsSimple = iACDataSet.CUSTHIST.Rows[dataSourceRowIndex].Field<Boolean>("IsSimple");
                    // Moses Newman 04/13/2018 set _ISFSeqNo,_ISFPaymentType,_ISFPaymentCode
                    _ISFSeqNo = iACDataSet.CUSTHIST.Rows[dataSourceRowIndex].Field<Int32>("CUSTHIST_DATE_SEQ");
                    _ISFPaymentType = iACDataSet.CUSTHIST.Rows[dataSourceRowIndex].Field<String>("CUSTHIST_PAYMENT_TYPE");
                    _ISFPaymentCode = iACDataSet.CUSTHIST.Rows[dataSourceRowIndex].Field<String>("CUSTHIST_PAYMENT_CODE");
                    // Moses Newman 10/09/2020 
                    _ISFID = iACDataSet.CUSTHIST.Rows[dataSourceRowIndex].Field<Int32>("ID");
                    Close();
                }
            }
        }

        public String ISFPaymentCode
        {
            get { return _ISFPaymentCode; }
            set { _ISFPaymentCode = ISFPaymentCode; }
        }

        public FormSelectCheck()
        {
            InitializeComponent();
        }

        public FormSelectCheck(String tsCustno,Boolean tbClosed = false, String tsPayType = "")
            : this()
        {
            _IsClosed = tbClosed;
            _CustNo = tsCustno;
            if (!_IsClosed)
            {
                opncustTableAdapter.Fill(iACDataSet.OPNCUST, _CustNo);
                if (iACDataSet.OPNCUST.Rows.Count == 0)
                {
                    Close();
                    return;
                }
                opndealrTableAdapter.Fill(iACDataSet.OPNDEALR, iACDataSet.OPNCUST.Rows[0].Field<String>("CUSTOMER_DEALER"));
                opnhcustTableAdapter.FillByCheckPayments(iACDataSet.OPNHCUST, _CustNo);
            }
            else
            {
                String Answer = "No";
                if (tsPayType == "I")
                {
                    Answer = "Yes"; // Moses Newman 09/07/2023 Make sure always shows if Insuficient and no assigned check.
                    _IsNotCheck = false;
                }
                _DoNotShow = false;
                if (_IsNotCheck)
                {
                    HtmlTemplateCollection htmlTemplates = new HtmlTemplateCollection();
                    var msgArgs = new XtraMessageBoxArgs();
                    msgArgs.HtmlTemplate.Assign(htmlTemplate1);
                    msgArgs.HtmlImages = svgImageCollection1;
                    msgArgs.Text = "Apply negative payment to a previous payment?";
                    msgArgs.Caption = "Apply Negative Payment";
                    Answer = XtraMessageBox.Show(msgArgs).ToString();
                }
                IACDataSetTableAdapters.CUSTOMERTableAdapter CUSTOMERTableAdapter = new IACDataSetTableAdapters.CUSTOMERTableAdapter();
                IACDataSetTableAdapters.DEALERTableAdapter DEALERTableAdapter = new IACDataSetTableAdapters.DEALERTableAdapter();
                IACDataSetTableAdapters.CUSTHISTTableAdapter CUSTHISTTableAdapter = new IACDataSetTableAdapters.CUSTHISTTableAdapter();
                if (Answer == "Yes")
                    CUSTOMERTableAdapter.Fill(iACDataSet.CUSTOMER, _CustNo);
                else
                    _DoNotShow = true;
                if (iACDataSet.CUSTOMER.Rows.Count == 0)
                {
                    Close();
                    return;
                }
                DEALERTableAdapter.Fill(iACDataSet.DEALER, iACDataSet.CUSTOMER.Rows[0].Field<Int32>("CUSTOMER_DEALER"));
                // Moses Newman 04/17/2018 Add filling with NON CHECK PAYMENTS option
                if(_IsNotCheck)
                    CUSTHISTTableAdapter.FillByNonCheckPayments(iACDataSet.CUSTHIST, _CustNo);
                else
                    CUSTHISTTableAdapter.FillByCheckPayments(iACDataSet.CUSTHIST, _CustNo);
                bindingSourceOPNCUST.DataSource = iACDataSet.CUSTOMER;
                bindingSourceOPNDEALR.DataSource = iACDataSet.DEALER;
                cUSTHISTBindingSource.DataSource = iACDataSet.CUSTHIST;
                textBoxDealerName.DataBindings.Clear();
                textBoxDealerName.DataBindings.Add(new Binding("Text",iACDataSet,"DEALER.DEALER_NAME"));
            }   
        }

        private void FormSelectCheck_Load(object sender, EventArgs e)
        {
            PerformAutoScale();
        }
    }
}

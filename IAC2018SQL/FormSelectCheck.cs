using IAC2021SQL.IACDataSetTableAdapters;
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
    public partial class FormSelectCheck : Form
    {
        private String _CustNo,_ISFPaymentType,_ISFPaymentCode;
        private DateTime _ISFDate;
        private Boolean _IsClosed,_IsSimple,_IsNotCheck = false,_DoNotShow = false;
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
            if (!tbClosed)
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
                if (tsPayType == "I")
                    _IsNotCheck = true;
                _DoNotShow = false;
                String Answer = "Yes";
                if(!_IsNotCheck)
                    Answer = MessageBox.Show("Apply negative payment to a previous payment?", "Apply Negative Payment", MessageBoxButtons.YesNo).ToString();
                IACDataSetTableAdapters.CUSTOMERTableAdapter CUSTOMERTableAdapter = new IACDataSetTableAdapters.CUSTOMERTableAdapter();
                IACDataSetTableAdapters.DEALERTableAdapter DEALERTableAdapter = new IACDataSetTableAdapters.DEALERTableAdapter();
                IACDataSetTableAdapters.CUSTHISTTableAdapter CUSTHISTTableAdapter = new IACDataSetTableAdapters.CUSTHISTTableAdapter();
                if (Answer != "No")
                    CUSTOMERTableAdapter.Fill(iACDataSet.CUSTOMER, _CustNo);
                else
                    _DoNotShow = true;
                if (iACDataSet.CUSTOMER.Rows.Count == 0)
                {
                    Close();
                    return;
                }
                DEALERTableAdapter.Fill(iACDataSet.DEALER, iACDataSet.CUSTOMER.Rows[0].Field<String>("CUSTOMER_DEALER"));
                // Moses Newman 04/17/2018 Add filling with NON CHECK PAYMENTS option
                if(_IsNotCheck)
                    CUSTHISTTableAdapter.FillByCheckPayments(iACDataSet.CUSTHIST, _CustNo);
                else
                    CUSTHISTTableAdapter.FillByNonCheckPayments(iACDataSet.CUSTHIST, _CustNo);
                bindingSourceOPNCUST.DataSource = iACDataSet.CUSTOMER;
                bindingSourceOPNDEALR.DataSource = iACDataSet.DEALER;
                cUSTHISTBindingSource.DataSource = iACDataSet.CUSTHIST;
                textBoxDealerName.DataBindings.Clear();
                textBoxDealerName.DataBindings.Add(new Binding("Text",iACDataSet,"DEALER.DEALER_NAME"));
                cUSTHISTDataGridView.DataSource = cUSTHISTBindingSource;
            }   
        }

        private void cUSTHISTDataGridView_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            foreach (DataGridViewRow r in cUSTHISTDataGridView.Rows)
                r.DefaultCellStyle.BackColor = (r.Index % 2 == 0) ? Color.White : Color.LightYellow;
        }

        private void cUSTHISTDataGridView_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (!_IsClosed)
            {
                if (iACDataSet.OPNCUST.Count > 0 && cUSTHISTDataGridView.SelectedRows.Count > 0)
                {
                    _ISFDate = (DateTime)(cUSTHISTDataGridView.SelectedRows[0].Cells["dataGridViewTextBoxColumnPostDate"].Value);
                    Close();
                }
            }
           else
                if (iACDataSet.CUSTOMER.Count > 0 && cUSTHISTDataGridView.SelectedRows.Count > 0)
                {
                    _ISFDate = (DateTime)(cUSTHISTDataGridView.SelectedRows[0].Cells["dataGridViewTextBoxColumnPostDate"].Value);
                    _PaidInt = iACDataSet.CUSTHIST.Rows[cUSTHISTDataGridView.SelectedRows[0].Index].Field<Decimal>("CUSTHIST_CURR_INT");
                    _LateCharge = iACDataSet.CUSTHIST.Rows[cUSTHISTDataGridView.SelectedRows[0].Index].Field<Decimal>("CUSTHIST_LATE_CHARGE_PAID");
                    _IsSimple = iACDataSet.CUSTHIST.Rows[cUSTHISTDataGridView.SelectedRows[0].Index].Field<Boolean>("IsSimple");
                    // Moses Newman 04/13/2018 set _ISFSeqNo,_ISFPaymentType,_ISFPaymentCode
                    _ISFSeqNo = iACDataSet.CUSTHIST.Rows[cUSTHISTDataGridView.SelectedRows[0].Index].Field<Int32>("CUSTHIST_DATE_SEQ");
                    _ISFPaymentType = iACDataSet.CUSTHIST.Rows[cUSTHISTDataGridView.SelectedRows[0].Index].Field<String>("CUSTHIST_PAYMENT_TYPE");
                    _ISFPaymentCode = iACDataSet.CUSTHIST.Rows[cUSTHISTDataGridView.SelectedRows[0].Index].Field<String>("CUSTHIST_PAYMENT_CODE");
                    // Moses Newman 10/09/2020 
                    _ISFID = iACDataSet.CUSTHIST.Rows[cUSTHISTDataGridView.SelectedRows[0].Index].Field<Int32>("ID");                    
                    Close();
                }
        }

        private void FormSelectCheck_Load(object sender, EventArgs e)
        {
            PerformAutoScale();
        }

        private void FormSelectCheck_Activated(object sender, EventArgs e)
        {
        }
    }
}

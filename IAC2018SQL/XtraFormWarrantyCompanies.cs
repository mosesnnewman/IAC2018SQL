using DevExpress.XtraEditors;
using DevExpress.XtraLayout;
using DevExpress.XtraLayout.Helpers;
using IAC2021SQL.IACDataSetTableAdapters;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace IAC2021SQL
{
    public partial class XtraFormWarrantyCompanies : DevExpress.XtraBars.Ribbon.RibbonForm
    {
        public XtraFormWarrantyCompanies()
        {
            InitializeComponent();
        }

        private void XtraFormWarrantyCompanies_Load(object sender, EventArgs e)
        {
            warrantyCompanyTableAdapter.FillByAll(iACDataSet.WarrantyCompany);
            bindingSourceWarrantyCompany.DataSource = iACDataSet.WarrantyCompany;
            stateTableAdapter.Fill(iACDataSet.state);
        }

        private void bbiClose_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            Close();
        }

        private void bbiReset_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            bindingSourceWarrantyCompany.CancelEdit();
        }

        private void bbiDelete_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            bindingSourceWarrantyCompany.RemoveCurrent();
        }

        private void bbiSave_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            bindingSourceWarrantyCompany.EndEdit();
            warrantyCompanyTableAdapter.Update(iACDataSet.WarrantyCompany);
            iACDataSet.WarrantyCompany.AcceptChanges();
        }

        private void bbiSaveAndClose_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            bindingSourceWarrantyCompany.EndEdit();
            warrantyCompanyTableAdapter.Update(iACDataSet.WarrantyCompany);
            iACDataSet.WarrantyCompany.AcceptChanges();
            Close();
        }

        private void bbiSaveAndNew_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            bindingSourceWarrantyCompany.EndEdit();
            warrantyCompanyTableAdapter.Update(iACDataSet.WarrantyCompany);
            iACDataSet.WarrantyCompany.AcceptChanges();
            bindingSourceWarrantyCompany.AddNew();
        }

        private void lookUpEditCompany_EditValueChanged(object sender, EventArgs e)
        {
            object row = lookUpEditCompany.Properties.GetDataSourceRowByKeyValue(lookUpEditCompany.EditValue);
            if (row == null)
                return;
            IList list = (IList)ListBindingHelper.GetList(lookUpEditCompany.Properties.DataSource);
            int index = list.IndexOf(row);
            if (index != -1)
                bindingSourceWarrantyCompany.Position = index;
        }

        private void StateLookUpEdit_EditValueChanged(object sender, EventArgs e)
        {
            object row = StateLookUpEdit.Properties.GetDataSourceRowByKeyValue(StateLookUpEdit.EditValue);
            if (row == null)
                return;
            IList list = (IList)ListBindingHelper.GetList(StateLookUpEdit.Properties.DataSource);
            int index = list.IndexOf(row);
            if (index != -1)
                bindingSourceState.Position = index;
        }
    }
}
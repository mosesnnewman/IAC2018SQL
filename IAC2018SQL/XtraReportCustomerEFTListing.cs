using DevExpress.CodeParser;
using DevExpress.DataAccess.Sql;
using DevExpress.ReportServer.ServiceModel.DataContracts;
using DevExpress.XtraReports.UI;
using IAC2021SQL.IACDataSetTableAdapters;
using Microsoft.Office.Interop.Excel;
using System;
using System.Collections;
using System.ComponentModel;
using System.Drawing;
//using System.Web.UI.WebControls;
using DevExpress.Drawing;

namespace IAC2021SQL
{
    public partial class XtraReportCustomerEFTListing : DevExpress.XtraReports.UI.XtraReport
    {
        public XtraReportCustomerEFTListing()
        {
            InitializeComponent();
        }

        private void XtraReportCustomerEFTListing_DataSourceDemanded(object sender, EventArgs e)
        {
            SqlDataSource ds = this.DataSource as SqlDataSource;
            var queryName = "EFTList";
            var loCutOff = this.Parameters["gdCutOff"].Value;
            var loDayDue = this.Parameters["gnDayDue"].Value;
            DateTime ldCutOff = loCutOff != null ? (DateTime)loCutOff:DateTime.Parse("01/01/1900");
            Int32 lnDayDue = loDayDue != null ? (Int32)loDayDue : 0;
            if (loCutOff != null)
            {
                if (lnDayDue != 0)
                {
                    var storedProcedureQuery = new StoredProcQuery()
                    {
                        Name = queryName,
                        StoredProcName = "EFTListFillByDayDueWithCuttOff"
                    };
                    ds.Queries.Clear();
                    ds.Queries.Add(storedProcedureQuery);
                    var DayDueParameter = new QueryParameter()
                    {
                        Name = "@CUSTOMER_DAY_DUE",
                        Type = typeof(DevExpress.DataAccess.Expression),
                        Value = new DevExpress.DataAccess.Expression("?gnDayDue", typeof(int))
                    };
                    storedProcedureQuery.Parameters.Add(DayDueParameter);
                    var CutOffParameter = new QueryParameter()
                    {
                        Name = "@CUSTOMER_INIT_DATE",
                        Type = typeof(DevExpress.DataAccess.Expression),
                        Value = new DevExpress.DataAccess.Expression("?gdCutOff", typeof(DateTime))
                    };
                    storedProcedureQuery.Parameters.Add(CutOffParameter);
                }
                else
                {
                    var storedProcedureQuery = new StoredProcQuery()
                    {
                        Name = queryName,
                        StoredProcName = "EFTListFillByCuttOff"
                    };
                    ds.Queries.Clear();
                    ds.Queries.Add(storedProcedureQuery);
                    var CutOffParameter = new QueryParameter()
                    {
                        Name = "@CUSTOMER_INIT_DATE",
                        Type = typeof(DevExpress.DataAccess.Expression),
                        Value = new DevExpress.DataAccess.Expression("?gdCutOff", typeof(DateTime))
                    };
                    storedProcedureQuery.Parameters.Add(CutOffParameter);
                }
            }
            else
            {
                if (lnDayDue != 0)
                {
                    var storedProcedureQuery = new StoredProcQuery()
                    {
                        Name = queryName,
                        StoredProcName = "EFTListFillByDayDue"
                    };
                    ds.Queries.Clear();
                    ds.Queries.Add(storedProcedureQuery);
                    var DayDueParameter = new QueryParameter()
                    {
                        Name = "@CUSTOMER_DAY_DUE",
                        Type = typeof(DevExpress.DataAccess.Expression),
                        Value = new DevExpress.DataAccess.Expression("?gnDayDue", typeof(int))
                    };
                    storedProcedureQuery.Parameters.Add(DayDueParameter);
                }
                else
                {
                    var storedProcedureQuery = new StoredProcQuery()
                    {
                        Name = queryName,
                        StoredProcName = "EFTListFillByAll"
                    };
                    ds.Queries.Clear();
                    ds.Queries.Add(storedProcedureQuery);
                }
            }
        }

        // Moses Newman 04/21/2024 Make payment amount RED and BOLD if it is a splitpay account.
        private void CUSTOMERREGULARAMOUNT1_BeforePrint(object sender, CancelEventArgs e)
        {
            XRLabel label = (XRLabel)sender;
            XtraReportBase report = label.Report;
            Boolean lbSplitPay = Convert.ToBoolean(report.GetCurrentColumnValue("SplitPay"));
            if (lbSplitPay)
            {
                label.ForeColor = System.Drawing.Color.Red;
                label.Font = new System.Drawing.Font(label.Font, FontStyle.Bold);
            }
            else
            {
                label.ForeColor = System.Drawing.Color.Black;
                label.Font = new System.Drawing.Font(label.Font, FontStyle.Regular);
            }

        }
    }
}

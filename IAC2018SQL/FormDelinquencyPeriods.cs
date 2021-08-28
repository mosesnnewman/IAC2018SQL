using IAC2021SQL.IACDataSetTableAdapters;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace IAC2021SQL
{
    public partial class FormDelinquencyPeriods : Form
    {
        public int CustomerID { get; set; }
        public DateTime PeriodEnd { get; set; }
        public String Profile {get; set;}
        public Boolean UpdateProfile { get; set; }

        public FormDelinquencyPeriods()
        {
            InitializeComponent();
        }

        private void FormDelinquencyPeriods_Load(object sender, EventArgs e)
        {
            this.delinquencyPeriodsTableAdapter.Fill(this.tsbDataSet.DelinquencyPeriods);
            this.tSBCustomerDelinquenciesTableAdapter.Fill(this.tsbDataSet.TSBCustomerDelinquencies, CustomerID);
            if (this.tsbDataSet.TSBCustomerDelinquencies.Rows.Count < 1)
            {

                TSBDataSet.TSBCustomerDelinquenciesRow DR = (TSBDataSet.TSBCustomerDelinquenciesRow)this.tsbDataSet.TSBCustomerDelinquencies.NewRow();
                DR.CustomerID = CustomerID;

                this.tsbDataSet.TSBCustomerDelinquencies.Rows.Add(DR);
                this.TSBCustomerDelinquenciesbindingSource.EndEdit();
            }
            else
                this.TSBCustomerDelinquenciesbindingSource.MoveFirst();

            this.tsbDataSet.TSBCustomerDelinquencies.Rows[TSBCustomerDelinquenciesbindingSource.Position].SetField<String>("p1", Profile.Substring(7, 1));
            this.tsbDataSet.TSBCustomerDelinquencies.Rows[TSBCustomerDelinquenciesbindingSource.Position].SetField<String>("p2", Profile.Substring(8, 1));
            this.tsbDataSet.TSBCustomerDelinquencies.Rows[TSBCustomerDelinquenciesbindingSource.Position].SetField<String>("p3", Profile.Substring(9, 1));
            this.tsbDataSet.TSBCustomerDelinquencies.Rows[TSBCustomerDelinquenciesbindingSource.Position].SetField<String>("p4", Profile.Substring(10, 1));
            this.tsbDataSet.TSBCustomerDelinquencies.Rows[TSBCustomerDelinquenciesbindingSource.Position].SetField<String>("p5", Profile.Substring(11, 1));
            this.tsbDataSet.TSBCustomerDelinquencies.Rows[TSBCustomerDelinquenciesbindingSource.Position].SetField<String>("p6", Profile.Substring(12, 1));
            this.tsbDataSet.TSBCustomerDelinquencies.Rows[TSBCustomerDelinquenciesbindingSource.Position].SetField<String>("p7", Profile.Substring(13, 1));
            this.tsbDataSet.TSBCustomerDelinquencies.Rows[TSBCustomerDelinquenciesbindingSource.Position].SetField<String>("p8", Profile.Substring(14, 1));
            this.tsbDataSet.TSBCustomerDelinquencies.Rows[TSBCustomerDelinquenciesbindingSource.Position].SetField<String>("p9", Profile.Substring(15, 1));
            this.tsbDataSet.TSBCustomerDelinquencies.Rows[TSBCustomerDelinquenciesbindingSource.Position].SetField<String>("p10", Profile.Substring(16, 1));
            this.tsbDataSet.TSBCustomerDelinquencies.Rows[TSBCustomerDelinquenciesbindingSource.Position].SetField<String>("p11", Profile.Substring(17, 1));
            this.tsbDataSet.TSBCustomerDelinquencies.Rows[TSBCustomerDelinquenciesbindingSource.Position].SetField<String>("p12", Profile.Substring(18, 1));

            this.tsbDataSet.TSBCustomerDelinquencies.Rows[TSBCustomerDelinquenciesbindingSource.Position].SetField<String>("p13", Profile.Substring(19, 1));
            this.tsbDataSet.TSBCustomerDelinquencies.Rows[TSBCustomerDelinquenciesbindingSource.Position].SetField<String>("p14", Profile.Substring(20, 1));
            this.tsbDataSet.TSBCustomerDelinquencies.Rows[TSBCustomerDelinquenciesbindingSource.Position].SetField<String>("p15", Profile.Substring(21, 1));
            this.tsbDataSet.TSBCustomerDelinquencies.Rows[TSBCustomerDelinquenciesbindingSource.Position].SetField<String>("p16", Profile.Substring(22, 1));
            this.tsbDataSet.TSBCustomerDelinquencies.Rows[TSBCustomerDelinquenciesbindingSource.Position].SetField<String>("p17", Profile.Substring(23, 1));
            this.tsbDataSet.TSBCustomerDelinquencies.Rows[TSBCustomerDelinquenciesbindingSource.Position].SetField<String>("p18", Profile.Substring(24, 1));
            this.tsbDataSet.TSBCustomerDelinquencies.Rows[TSBCustomerDelinquenciesbindingSource.Position].SetField<String>("p19", Profile.Substring(25, 1));
            this.tsbDataSet.TSBCustomerDelinquencies.Rows[TSBCustomerDelinquenciesbindingSource.Position].SetField<String>("p20", Profile.Substring(26, 1));
            this.tsbDataSet.TSBCustomerDelinquencies.Rows[TSBCustomerDelinquenciesbindingSource.Position].SetField<String>("p21", Profile.Substring(27, 1));
            this.tsbDataSet.TSBCustomerDelinquencies.Rows[TSBCustomerDelinquenciesbindingSource.Position].SetField<String>("p22", Profile.Substring(28, 1));
            this.tsbDataSet.TSBCustomerDelinquencies.Rows[TSBCustomerDelinquenciesbindingSource.Position].SetField<String>("p23", Profile.Substring(29, 1));
            this.tsbDataSet.TSBCustomerDelinquencies.Rows[TSBCustomerDelinquenciesbindingSource.Position].SetField<String>("p24", Profile.Substring(30, 1));
            TSBCustomerDelinquenciesbindingSource.EndEdit();

            this.tSBCustomerDelinquenciesTableAdapter.Update(this.tsbDataSet.TSBCustomerDelinquencies.Rows[TSBCustomerDelinquenciesbindingSource.Position]);
            this.Refresh();

            DateTime RealPeriodEnd = PeriodEnd.AddDays(-1);

            labelp1Date.Text = RealPeriodEnd.Date.Month.ToString().PadLeft(2,'0') + "/" + RealPeriodEnd.Date.Year.ToString();
            labelp2Date.Text = RealPeriodEnd.Date.AddMonths(-1).Month.ToString().PadLeft(2, '0') + "/" + RealPeriodEnd.Date.AddMonths(-1).Year.ToString();
            labelp3Date.Text = RealPeriodEnd.Date.AddMonths(-2).Month.ToString().PadLeft(2, '0') + "/" + RealPeriodEnd.Date.AddMonths(-2).Year.ToString();
            labelp4Date.Text = RealPeriodEnd.Date.AddMonths(-3).Month.ToString().PadLeft(2, '0') + "/" + RealPeriodEnd.Date.AddMonths(-3).Year.ToString();
            labelp5Date.Text = RealPeriodEnd.Date.AddMonths(-4).Month.ToString().PadLeft(2, '0') + "/" + RealPeriodEnd.Date.AddMonths(-4).Year.ToString();
            labelp6Date.Text = RealPeriodEnd.Date.AddMonths(-5).Month.ToString().PadLeft(2, '0') + "/" + RealPeriodEnd.Date.AddMonths(-5).Year.ToString();
            labelp7Date.Text = RealPeriodEnd.Date.AddMonths(-6).Month.ToString().PadLeft(2, '0') + "/" + RealPeriodEnd.Date.AddMonths(-6).Year.ToString();
            labelp8Date.Text = RealPeriodEnd.Date.AddMonths(-7).Month.ToString().PadLeft(2, '0') + "/" + RealPeriodEnd.Date.AddMonths(-7).Year.ToString();
            labelp9Date.Text = RealPeriodEnd.Date.AddMonths(-8).Month.ToString().PadLeft(2, '0') + "/" + RealPeriodEnd.Date.AddMonths(-8).Year.ToString();
            labelp10Date.Text = RealPeriodEnd.Date.AddMonths(-9).Month.ToString().PadLeft(2, '0') + "/" + RealPeriodEnd.Date.AddMonths(-9).Year.ToString();
            labelp11Date.Text = RealPeriodEnd.Date.AddMonths(-10).Month.ToString().PadLeft(2, '0') + "/" + RealPeriodEnd.Date.AddMonths(-10).Year.ToString();
            labelp12Date.Text = RealPeriodEnd.Date.AddMonths(-11).Month.ToString().PadLeft(2, '0') + "/" + RealPeriodEnd.Date.AddMonths(-11).Year.ToString();

            labelp13Date.Text = RealPeriodEnd.Date.AddMonths(-12).Month.ToString().PadLeft(2, '0') + "/" + RealPeriodEnd.Date.AddMonths(-12).Year.ToString();
            labelp14Date.Text = RealPeriodEnd.Date.AddMonths(-13).Month.ToString().PadLeft(2, '0') + "/" + RealPeriodEnd.Date.AddMonths(-13).Year.ToString();
            labelp15Date.Text = RealPeriodEnd.Date.AddMonths(-14).Month.ToString().PadLeft(2, '0') + "/" + RealPeriodEnd.Date.AddMonths(-14).Year.ToString();
            labelp16Date.Text = RealPeriodEnd.Date.AddMonths(-15).Month.ToString().PadLeft(2, '0') + "/" + RealPeriodEnd.Date.AddMonths(-15).Year.ToString();
            labelp17Date.Text = RealPeriodEnd.Date.AddMonths(-16).Month.ToString().PadLeft(2, '0') + "/" + RealPeriodEnd.Date.AddMonths(-16).Year.ToString();
            labelp18Date.Text = RealPeriodEnd.Date.AddMonths(-17).Month.ToString().PadLeft(2, '0') + "/" + RealPeriodEnd.Date.AddMonths(-17).Year.ToString();
            labelp19Date.Text = RealPeriodEnd.Date.AddMonths(-18).Month.ToString().PadLeft(2, '0') + "/" + RealPeriodEnd.Date.AddMonths(-18).Year.ToString();
            labelp20Date.Text = RealPeriodEnd.Date.AddMonths(-19).Month.ToString().PadLeft(2, '0') + "/" + RealPeriodEnd.Date.AddMonths(-19).Year.ToString();
            labelp21Date.Text = RealPeriodEnd.Date.AddMonths(-20).Month.ToString().PadLeft(2, '0') + "/" + RealPeriodEnd.Date.AddMonths(-20).Year.ToString();
            labelp22Date.Text = RealPeriodEnd.Date.AddMonths(-21).Month.ToString().PadLeft(2, '0') + "/" + RealPeriodEnd.Date.AddMonths(-21).Year.ToString();
            labelp23Date.Text = RealPeriodEnd.Date.AddMonths(-22).Month.ToString().PadLeft(2, '0') + "/" + RealPeriodEnd.Date.AddMonths(-22).Year.ToString();
            labelp24Date.Text = RealPeriodEnd.Date.AddMonths(-23).Month.ToString().PadLeft(2, '0') + "/" + RealPeriodEnd.Date.AddMonths(-23).Year.ToString();
        }

        private void buttonCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void buttonOk_Click(object sender, EventArgs e)
        {
            
            String DatePart, History;
            DatePart = this.Profile.Substring(0, 7);

            History =
                this.tsbDataSet.TSBCustomerDelinquencies.Rows[TSBCustomerDelinquenciesbindingSource.Position].Field<String>("p1") +
                this.tsbDataSet.TSBCustomerDelinquencies.Rows[TSBCustomerDelinquenciesbindingSource.Position].Field<String>("p2") +
                this.tsbDataSet.TSBCustomerDelinquencies.Rows[TSBCustomerDelinquenciesbindingSource.Position].Field<String>("p3") +
                this.tsbDataSet.TSBCustomerDelinquencies.Rows[TSBCustomerDelinquenciesbindingSource.Position].Field<String>("p4") +
                this.tsbDataSet.TSBCustomerDelinquencies.Rows[TSBCustomerDelinquenciesbindingSource.Position].Field<String>("p5") +
                this.tsbDataSet.TSBCustomerDelinquencies.Rows[TSBCustomerDelinquenciesbindingSource.Position].Field<String>("p6") +
                this.tsbDataSet.TSBCustomerDelinquencies.Rows[TSBCustomerDelinquenciesbindingSource.Position].Field<String>("p7") +
                this.tsbDataSet.TSBCustomerDelinquencies.Rows[TSBCustomerDelinquenciesbindingSource.Position].Field<String>("p8") +
                this.tsbDataSet.TSBCustomerDelinquencies.Rows[TSBCustomerDelinquenciesbindingSource.Position].Field<String>("p9") +
                this.tsbDataSet.TSBCustomerDelinquencies.Rows[TSBCustomerDelinquenciesbindingSource.Position].Field<String>("p10") +
                this.tsbDataSet.TSBCustomerDelinquencies.Rows[TSBCustomerDelinquenciesbindingSource.Position].Field<String>("p11") +
                this.tsbDataSet.TSBCustomerDelinquencies.Rows[TSBCustomerDelinquenciesbindingSource.Position].Field<String>("p12") +

                this.tsbDataSet.TSBCustomerDelinquencies.Rows[TSBCustomerDelinquenciesbindingSource.Position].Field<String>("p13") +
                this.tsbDataSet.TSBCustomerDelinquencies.Rows[TSBCustomerDelinquenciesbindingSource.Position].Field<String>("p14") +
                this.tsbDataSet.TSBCustomerDelinquencies.Rows[TSBCustomerDelinquenciesbindingSource.Position].Field<String>("p15") +
                this.tsbDataSet.TSBCustomerDelinquencies.Rows[TSBCustomerDelinquenciesbindingSource.Position].Field<String>("p16") +
                this.tsbDataSet.TSBCustomerDelinquencies.Rows[TSBCustomerDelinquenciesbindingSource.Position].Field<String>("p17") +
                this.tsbDataSet.TSBCustomerDelinquencies.Rows[TSBCustomerDelinquenciesbindingSource.Position].Field<String>("p18") +
                this.tsbDataSet.TSBCustomerDelinquencies.Rows[TSBCustomerDelinquenciesbindingSource.Position].Field<String>("p19") +
                this.tsbDataSet.TSBCustomerDelinquencies.Rows[TSBCustomerDelinquenciesbindingSource.Position].Field<String>("p20") +
                this.tsbDataSet.TSBCustomerDelinquencies.Rows[TSBCustomerDelinquenciesbindingSource.Position].Field<String>("p21") +
                this.tsbDataSet.TSBCustomerDelinquencies.Rows[TSBCustomerDelinquenciesbindingSource.Position].Field<String>("p22") +
                this.tsbDataSet.TSBCustomerDelinquencies.Rows[TSBCustomerDelinquenciesbindingSource.Position].Field<String>("p23") +
                this.tsbDataSet.TSBCustomerDelinquencies.Rows[TSBCustomerDelinquenciesbindingSource.Position].Field<String>("p24");
                
            this.tSBCustomerDelinquenciesTableAdapter.Update(this.tsbDataSet.TSBCustomerDelinquencies.Rows[0]);
            this.Profile = DatePart + History;
            this.Close();
        }
    }
}

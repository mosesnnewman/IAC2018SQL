using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace IAC2018SQL
{
    public partial class FormLeeMason : Form
    {
        private SQLBackupandRestore SQLBR = new SQLBackupandRestore();

        public FormLeeMason()
        {
            InitializeComponent();
        }

        private void buttonVehicleExtract_Click(object sender, EventArgs e)
        {
            SQLBR.VehicleExtractJob();
        }

        private void buttonLeeMasonImport_Click(object sender, EventArgs e)
        {
            IACDataSetTableAdapters.leemasonTableAdapter leemasonTableAdapter = new IACDataSetTableAdapters.leemasonTableAdapter();
            IACDataSetTableAdapters.VEHICLETableAdapter VEHICLETableAdapter = new IACDataSetTableAdapters.VEHICLETableAdapter();
            leemasonTableAdapter.DeleteAll();
            SQLBR.LeeMasonJob();
            leemasonTableAdapter.Dispose();

            // Moses Newman 11/11/2013 Call Import Query For Lee Mason to Vehicle table
            //VEHICLETableAdapter.CreateLeeMasonChanges();
            VEHICLETableAdapter.CreateLeeMasonChangesAndUpdateVehicle();
            VEHICLETableAdapter.Dispose();
        }

        private void buttonClose_Click(object sender, EventArgs e)
        {
            SQLBR.Dispose();
            SQLBR = null;
            Close();
        }

    }
}

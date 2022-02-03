using System;
using System.Net;
using RestSharp;
using System.IO;
using System.Xml;
using System.Threading;
using System.Windows.Forms;

namespace IAC2021SQL
{
    public partial class FormLeeMason : DevExpress.XtraEditors.XtraForm
    {
        private SQLBackupandRestore SQLBR = new SQLBackupandRestore();

        public FormLeeMason()
        {
            InitializeComponent();
        }

        private void ButtonVehicleExtract_Click(object sender, EventArgs e)
        {
            SQLBR.VehicleExtractJob();

            
            splashScreenManager1.ShowWaitForm();
            

            Thread.Sleep(5000);
            
            String fileBytes = File.ReadAllText(@"\\DC-IAC\Public\AccStuff\mfdata\Verifacto\verifacto.csv");
            RestClient ApiClient = new RestClient("https://apps.verifacto.com")
            {
                Timeout = 600000 //Ten Minutes
            };
            var request = new RestRequest("/vf4/automation/web/index.php?r=import_api", Method.POST);
            request.AddParameter("account_code", "ct-iac", ParameterType.GetOrPost);
            request.AddParameter("access_key","1MQrNQIAuTqq0aoI", ParameterType.GetOrPost);
            request.AddParameter("upload_data",fileBytes, ParameterType.GetOrPost);

            var response = ApiClient.Execute(request);
            if (response.StatusCode != HttpStatusCode.OK)
            {
                splashScreenManager1.CloseWaitForm();
                throw new Exception("Unable to upload file to Verifacto: " + response.Content);
            }
            else
            {
                splashScreenManager1.CloseWaitForm();
                XmlDocument xdoc = new XmlDocument();
                xdoc.LoadXml(response.Content);
                xdoc.Save(@"\\DC-IAC\Public\AccStuff\mfdata\Verifacto\VerifactoResponse.xml");
                string sOpenPath = @"\\DC-IAC\Public\AccStuff\mfdata\Verifacto\VerifactoResponse.xml";
                if (sOpenPath != string.Empty)
                {
                    XmlGridView.DataFilePath = sOpenPath;
                    XmlGridView.DataSetTableIndex = 0;
                    XmlGridView.ViewMode = XmlGridViewSample.XmlGridView.VIEW_MODE.XML;
                }
            }
        }

        private void ButtonLeeMasonImport_Click(object sender, EventArgs e)
        {
            splashScreenManager1.ShowWaitForm();
            splashScreenManager1.SetWaitFormCaption("Downloading VERIFACTO data feed");
            splashScreenManager1.SetWaitFormDescription("Receiving VERIFACTO_DATA_EXPORT.csv ...");

            RestClient ApiClient = new RestClient("https://apps.verifacto.com");
            var request = new RestRequest("/vf4/automation/web/index.php?r=export_api", Method.POST);
            request.AddParameter("account_code", "ct-iac", ParameterType.GetOrPost);
            request.AddParameter("access_key", "1MQrNQIAuTqq0aoI", ParameterType.GetOrPost);

            var response = ApiClient.Execute(request);
            if (response.StatusCode != HttpStatusCode.OK)
            {
                splashScreenManager1.CloseWaitForm();
                throw new Exception("Unable to download Verifacto data:  " + response.Content);
            }
            else
            {
                byte[] fileBytes = ApiClient.DownloadData(request);
                File.WriteAllBytes(@"\\DC-IAC\Public\AccStuff\mfdata\Verifacto\VERIFACTO_DATA_EXPORT.csv", fileBytes);
            }

            splashScreenManager1.SetWaitFormCaption("Importing VERIFACTO feed into VEHICLE. Please wait.");
            splashScreenManager1.SetWaitFormDescription("Importing to VEHICLE ...");

            IACDataSetTableAdapters.VERIFACTOTableAdapter vERIFACTOTableAdapter = new IACDataSetTableAdapters.VERIFACTOTableAdapter();
            IACDataSetTableAdapters.VEHICLETableAdapter VEHICLETableAdapter = new IACDataSetTableAdapters.VEHICLETableAdapter();
            vERIFACTOTableAdapter.DeleteAll();
            SQLBR.VERIFACTOJob();
            vERIFACTOTableAdapter.Dispose();
            Thread.Sleep(5000);

            // Moses Newman 01/29/2022 Call Import Query For VERIFACTO to Vehicle table
            VEHICLETableAdapter.CreateVerifactoChangesAndUpdateVehicle();
            VEHICLETableAdapter.Dispose();
            splashScreenManager1.CloseWaitForm();
            MessageBox.Show("*** Completed VERIFACTO upload to VEHICLE! ***");
        }

        private void ButtonClose_Click(object sender, EventArgs e)
        {
            SQLBR.Dispose();
            SQLBR = null;
            Close();
        }

        private void FormLeeMason_Load(object sender, EventArgs e)
        {
            XmlGridView.ViewMode = XmlGridViewSample.XmlGridView.VIEW_MODE.XML;
        }
    }
}

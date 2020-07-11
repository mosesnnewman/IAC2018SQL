using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using Word = Microsoft.Office.Interop.Word;
using System.Reflection;

namespace IAC2018SQL
{
    public partial class FormFixCreateDate : Form
    {
        public FormFixCreateDate()
        {
            InitializeComponent();
        }

        private void buttonUpdate_Click(object sender, EventArgs e)
        {
            String lsUNCROOT = Program.GsDataPath, lsNewFile, FilePath = @"\\dc-iac\Public\CommentAttachments\Letters\";

            var filenames = Directory
            .EnumerateFiles(FilePath, "*.docx", SearchOption.TopDirectoryOnly)
            .Select(Path.GetFileName); // <-- note you can shorten the lambda
            float pdone,i=0;
            Int32 fcount = filenames.Count();

            Word._Document doc;
            Word.Application app = new Word.Application();
            app.Visible = false;

            object docName;
            object missing = Missing.Value;
            object saveChanges;


            foreach (String filename in filenames)
            {
                i++;
                if (i > 22403)
                {
                    lsNewFile = lsUNCROOT + @"CommentAttachments\Letters\" + filename;
                    labelOuput.Text = "*** Working on file: " + filename + " " + i.ToString() + " of " + fcount.ToString();
                    labelOuput.Refresh();
                    pdone = (float)(i / fcount) * 100;
                    progressBarProgress.Value = (int)pdone;
                    progressBarProgress.Refresh();
                    docName = lsNewFile;
                    try
                    {
                        doc = app.Documents.Open(ref docName,
                            ref missing, ref missing, ref missing, ref missing,
                            ref missing, ref missing, ref missing, ref missing,
                            ref missing, ref missing, ref missing, ref missing,
                            ref missing, ref missing, ref missing);
                    }
                    catch (System.Runtime.InteropServices.COMException)
                    {
                        continue;
                    }
                    Program.ReplaceMailMergeField(ref doc, ref app, lsNewFile, "DATE", " CREATEDATE  \\@ \"MMMM d, yyyy\" ");
                    saveChanges = Word.WdSaveOptions.wdSaveChanges;
                    doc.Close(ref saveChanges, ref missing, ref missing);
                }
            }
            app.Quit(ref missing, ref missing, ref missing);
            this.Close();
        }
    }
}

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Windows.Forms;
using KeywordManagement.ReportTemplate;
using Novacode;

namespace KeywordManagement.Report
{
    public partial class frmSearchResultReport : Form
    {
        private ReportWriter _reportWriter;

        public frmSearchResultReport(TreeView treeKeywords, DataGridView grdReferences, DataGridView grdSentences)
        {
            InitializeComponent();
            _reportWriter = new ReportWriter(treeKeywords, grdSentences, grdReferences, ReportType.Keyword, cbHierarchically.Checked);
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            saveReportFileDialog.ShowDialog();
        }

        private void saveReportFileDialog_FileOk(object sender, CancelEventArgs e)
        {
            var fileName = saveReportFileDialog.FileName;
            var doc = DocX.Create(fileName);

            var reportType = ReportType.Keyword;
            if (SentenceReportRedio.Checked)
            {
                reportType = ReportType.Sentenctes;
            }
            else if (ReferenceRedio.Checked)
            {
                reportType = ReportType.References;
            }
            Utils.DoWithWait(this, () => _reportWriter.TransformToDocx(doc, reportType, cbHierarchically.Checked));
            try
            {
                if (cbOpenWord.Checked)
                {
                    Process.Start("WINWORD", fileName);
                    this.Close();    
                }                
            }
            catch 
            {
                //ignore exception
            }
        }
    }
}

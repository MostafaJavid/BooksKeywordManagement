using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using KeywordManagement.Report;
using Novacode;

namespace KeywordManagement.ReportTemplate
{
    partial class AddressReport
    {
        private TreeView _treeView;
        private DataGridView _grdReferences;
        private DataGridView _grdSentences;
        public AddressReport(TreeView resultTreeView, DataGridView grdSentences, DataGridView grdReferences, ReportType reportType)
        {
            _treeView = resultTreeView;
            _grdReferences = grdReferences;
            _grdSentences = grdSentences;            
        }

        public string TransformToDocx()
        {
            string fileName = @"D:\DocXExample.docx";

            // Create a document in memory:
            var doc = DocX.Create(fileName);

            // Insert a paragrpah:
            Paragraph insertParagraph = doc.InsertParagraph("");
            insertParagraph.Direction = Direction.RightToLeft;

            // Save to the output directory:
            doc.Save();

            return fileName;
        }

        private Paragraph CreateParagraph(DocX doc, String content, Direction direction)
        {
            Paragraph insertParagraph = doc.InsertParagraph(content);
            insertParagraph.Direction = direction;
            return insertParagraph;
        }
    }
}

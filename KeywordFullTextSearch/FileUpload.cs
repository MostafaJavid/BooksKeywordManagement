using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using DocumentFormat.OpenXml.Drawing;
using DocumentFormat.OpenXml.Packaging;
using DocumentFormat.OpenXml.Wordprocessing;
using KeywordFullTextSearch.Domain;
using Break = DocumentFormat.OpenXml.Wordprocessing.Break;
using Paragraph = KeywordFullTextSearch.Domain.Paragraph;
using Run = DocumentFormat.OpenXml.Wordprocessing.Run;

namespace KeywordFullTextSearch
{
    public partial class FileUpload : Form
    {
        public FileUpload()
        {
            InitializeComponent();
        }

        private void btnUpload_Click(object sender, EventArgs e)
        {
            IList<Book> books = new List<Book>();
            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                openFileDialog.FileNames.ToList().ForEach(fileName =>
                {
                    var book = new Book()
                    {
                        Name = fileName
                    };

                    using (WordprocessingDocument wordDocument = WordprocessingDocument.Open(fileName, false))
                    {
                        var body = wordDocument.MainDocumentPart.Document.Body;
                        var pageNumber = 0;
                        var paragraphNumber = 1;

                        foreach (var element in body.Descendants())
                        {
                            if (element is LastRenderedPageBreak ||
                                (element is DocumentFormat.OpenXml.Wordprocessing.Paragraph &&
                                 (ContainPageBreak((DocumentFormat.OpenXml.Wordprocessing.Paragraph)element) ||
                                                        ContainLastRenderedPageBreak((DocumentFormat.OpenXml.Wordprocessing.Paragraph)element))))
                            {
                                pageNumber++;
                                paragraphNumber = 1;
                            }

                            if (element is DocumentFormat.OpenXml.Wordprocessing.Paragraph && element.InnerText != "")
                            {
                                book.Paragraphs.Add(new Paragraph() { Entry = element.InnerText, PageNo = pageNumber, ParagraphNo = paragraphNumber++ });
                            }
                        }

                        books.Add(book);
                    }

                });
            }
            using (var bookContext = new BookContext())
            {
                bookContext.Database.Log = (log) =>
                {
                    Console.WriteLine(log);
                };
//                books.ToList().ForEach(book => bookContext.Books.Add(book));
//                bookContext.SaveChanges();
            }
        }

        public bool ContainPageBreak(DocumentFormat.OpenXml.Wordprocessing.Paragraph p)
        {
            return p.Elements<Run>().FirstOrDefault(r => r.Elements<Break>().FirstOrDefault() != null) != null ||
                    p.Elements<SectionProperties>().FirstOrDefault(r => r.Elements<SectionType>().FirstOrDefault(s => s.Val == SectionMarkValues.NextPage) != null) != null;
        } 
        public bool ContainLastRenderedPageBreak(DocumentFormat.OpenXml.Wordprocessing.Paragraph p)
        {
            return p.Elements<Run>().FirstOrDefault(r => r.Elements<LastRenderedPageBreak>().FirstOrDefault() != null) != null;
        }
    }
}

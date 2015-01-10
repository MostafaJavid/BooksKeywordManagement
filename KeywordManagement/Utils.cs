using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace KeywordManagement
{
    static class Utils
    {
        public static void DoWithWait(Form frm, Action action)
        {
            var frmWait = new frmWait();
            try
            {
                frmWait.Show();
                frm.Cursor = Cursors.WaitCursor;
                Application.DoEvents();
                action();
                Application.DoEvents();
            }
            finally
            {
                frm.Cursor = Cursors.Default;
                frmWait.Close();
            }
        }

        public static void initSampleDB()
        {
            using (var db = new KeywordManagementContext())
            {
                var author = new Author() { FullName = "حضرت استاد علامه حسن زاده آملی" };
                var books = new Dictionary<int, Book>();
                var b1 = new Book() { Title = "معرفت نفس", PublicationYear = "1360", Publisher = "انتشارات" , PublishNumber="چاپ اول"};
                b1.Authors.Add(author);
                books.Add(1,b1);
                var b2 = new Book() { Title = "انسان در عرف عرفان", PublicationYear = "1370", Publisher = "انتشارات", PublishNumber = "چاپ اول" };
                b2.Authors.Add(author);
                books.Add(2,b2);
                for (int i = 1; i <= 5; i++)
                {
                    var keyword = new Keyword { Content = "لغت " + i.ToString() };
                    for (int j = 1; j <= 3; j++)
                    {
                        var sentence = new Sentence() { Content = "این یک جمله نمونه است " + (i * j).ToString() };
                        for (int k = 1; k <= 2; k++)
                        {
                            var reference = new Reference() { PageNumber = (i * j * k).ToString() };
                            reference.Book = books[k];
                            sentence.References.Add(reference);
                        }
                        keyword.Sentences.Add(sentence);    
                    }
                    
                    db.Keywords.Add(keyword);
                }
                db.SaveChanges();

                //// Display all Blogs from the database 
                //var query = from b in db.Keywords
                //            select b;

                //foreach (var item in query)
                //{
                //    MessageBox.Show(item.Content);
                //}

                MessageBox.Show("Data Initialized");

            }
        }
    }
}

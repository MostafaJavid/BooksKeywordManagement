using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace KeywordManagement
{
    public partial class frmBookManagement : Form
    {
        public frmBookManagement()
        {
            InitializeComponent();
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            RefreshResult();
        }

        private void RefreshResult()
        {
            Utils.DoWithWait(this, () =>
            {
                var title = txtTitle.Text;
                using (var db = new KeywordManagementContext())
                {
                    var books = db.Books.Where(b => b.Title != null && b.Title.Contains(title)).ToList();
                    grdBooks.DataSource = books.Select(b => new SearchResult(b)).ToList();
                }
            });
        }

        private void btnRemove_Click(object sender, EventArgs e)
        {
            Utils.DoWithWait(this, () =>
            {
                if (grdBooks.SelectedRows != null && grdBooks.SelectedRows.Count > 0)
                {
                    var id = Convert.ToInt32(grdBooks.SelectedRows[0].Cells["BookId"].Value);
                    using (var db = new KeywordManagementContext())
                    {
                        var book = db.Books.Where(b => b.BookId == id).Single();
                        db.Books.Remove(book);
                        db.SaveChanges();
                        MessageBox.Show("اطلاعات با موفقیت حذف گردید");
                    }
                }
            });
            RefreshResult();
        }
    }
}

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
    public partial class frmKeyword : Form
    {
        Keyword keyword;

        public frmKeyword()
        {
            InitializeComponent();
            this.Load += new EventHandler(frmKeyword_Load);
        }

        void frmKeyword_Load(object sender, EventArgs e)
        {

        }

        public frmKeyword(Keyword keyword)
            : this()
        {
            this.keyword = keyword;
            this.textBox1.Text = keyword == null ? "" : keyword.Content;
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            Utils.DoWithWait(this, () =>
            {
                string key = textBox1.Text;
                using (var db = new KeywordManagementContext())
                {
                    if (keyword == null)
                    {
                        db.Keywords.Add(new Keyword() { Content = key });
                    }
                    else
                    {                        
                        var old = db.Keywords.Where(k => k.KeywordId == this.keyword.KeywordId).Single();
                        var child = new Keyword() { Content = key };
                        child.Parent = old;
                        old.Childs.Add(child);
                    }
                    db.SaveChanges();
                }
            });
            MessageBox.Show("عملیات با موفقیت انجام شد" + "\n" + "لطفا برای دیدن اطلاعات بروزرسانی شده لطفا مجددا جستجو نمایید");
            this.Close();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}

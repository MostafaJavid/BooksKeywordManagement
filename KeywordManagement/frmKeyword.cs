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
        int? instanceToUpdate;
        public frmKeyword()
        {
            InitializeComponent();
            this.Load += new EventHandler(frmKeyword_Load);
        }

        void frmKeyword_Load(object sender, EventArgs e)
        {

        }

        public frmKeyword(int? id, string content)
            : this()
        {
            this.instanceToUpdate = id;
            this.textBox1.Text = content;
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            Utils.DoWithWait(this, () =>
            {
                string key = textBox1.Text;
                using (var db = new MyContext())
                {
                    if (instanceToUpdate == null)
                    {
                        db.Keywords.Add(new Keyword() { Content = key });
                    }
                    else
                    {
                        var old = db.Keywords.Where(k => k.KeywordId == instanceToUpdate).Single();
                        old.Content = key;
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

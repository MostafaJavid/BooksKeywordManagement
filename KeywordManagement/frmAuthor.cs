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
    public partial class frmAuthor : Form
    {
        int? instanceToUpdate;
        public frmAuthor()
        {
            InitializeComponent();
        }


        public frmAuthor(int? id, string content)
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
                using (var db = new KeywordManagementContext())
                {
                    if (instanceToUpdate == null)
                    {
                        db.Authors.Add(new Author() { FullName = key });
                    }
                    else
                    {
                        var old = db.Authors.Where(k => k.AuthorId == instanceToUpdate).Single();
                        old.FullName = key;
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

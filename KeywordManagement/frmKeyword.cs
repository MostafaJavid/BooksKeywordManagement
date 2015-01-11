using KeywordManagement.Domain;
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
        TreeNode treeNode;
        FormMode formMode;
        Func<Keyword, TreeNode> createTreeNode;

        public frmKeyword()
        {
            InitializeComponent();
            this.Load += new EventHandler(frmKeyword_Load);
        }

        void frmKeyword_Load(object sender, EventArgs e)
        {

        }

        public frmKeyword(TreeNode treeNode, FormMode formMode, Func<Keyword, TreeNode> createTreeNode)
            : this()
        {
            if (treeNode == null)
                throw new ArgumentException();
            this.treeNode = treeNode;
            this.formMode = formMode;
            this.createTreeNode = createTreeNode;
            this.textBox1.Text = treeNode.Tag == null ? "" : ((Keyword)treeNode.Tag).Content;
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            Utils.DoWithWait(this, () =>
            {
                string key = textBox1.Text;
                using (var db = new KeywordManagementContext())
                {
                    switch (this.formMode)
                    {
                        case FormMode.Create:
                            var keyword = new Keyword() { Content = key, Parent = (Keyword)treeNode.Tag  };
                            db.Keywords.Add(keyword);
                            db.SaveChanges();                            
                            treeNode.Nodes.Add(this.createTreeNode(keyword));
                            break;
                        case FormMode.Update:
                            this.treeNode.Tag = keyword = db.Keywords.Where(k => k.KeywordId == ((Keyword)this.treeNode.Tag).KeywordId).Single();
                            this.treeNode.Text = keyword.Content = key;
                            db.SaveChanges();
                            break;
                    }
                }
            });
            //MessageBox.Show("عملیات با موفقیت انجام شد" + "\n" + "لطفا برای دیدن اطلاعات بروزرسانی شده لطفا مجددا جستجو نمایید");
            this.Close();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}

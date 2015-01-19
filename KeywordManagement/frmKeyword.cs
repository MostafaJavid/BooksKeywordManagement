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
                    var keyword = default(Keyword);
                    switch (this.formMode)
                    {
                        case FormMode.Create:
                            var parent = treeNode.Tag as Keyword;
                            if (parent != null) { parent = db.Keywords.Attach(parent); }
                            keyword = new Keyword() { Content = key, Parent = parent  };
                            db.Keywords.Add(keyword);
                            db.SaveChanges();                            
                            treeNode.Nodes.Add(this.createTreeNode(keyword));
                            treeNode.BackColor = Color.LightSkyBlue;
                            break;
                        case FormMode.Update:
                            this.treeNode.Tag = keyword = db.Keywords.Attach((Keyword)this.treeNode.Tag);
                            this.treeNode.Text = keyword.Content = key;
                            db.SaveChanges();
                            break;
                    }
                }
            });
            //MessageBox.Show("عملیات با موفقیت انجام شد" + "\n" + "لطفا برای دیدن اطلاعات بروزرسانی شده لطفا مجددا جستجو نمایید");
            this.treeNode.TreeView.Sort();
            this.Close();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}

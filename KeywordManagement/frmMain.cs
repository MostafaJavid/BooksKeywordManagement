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
    public partial class frmMain : Form
    {
        public frmMain()
        {
            InitializeComponent();
            this.Load += new EventHandler(frmMain_Load);
        }

        void frmMain_Load(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Maximized;
            //RefreshTree();
        }

        private void refreshToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var treeNode = treeKeywords.SelectedNode;
            if (treeNode != null)
            {
                CreateOrUpdateKeyword(Convert.ToInt32(treeNode.Tag.ToString()), treeNode.Text);
            }
        }

        private void RefreshTree()
        {
            Utils.DoWithWait(this, () =>
            {
                string key = textBox1.Text;
                treeKeywords.Nodes.Clear();
                using (var db = new MyContext())
                {
                    foreach (var k in db.Keywords.Where(k => !string.IsNullOrEmpty(k.Content) && k.Content.Contains(key)).OrderBy(k => k.Content))
                    {
                        var node = new TreeNode(k.Content)
                        {
                            Tag = k.KeywordId,
                        };
                        node.ContextMenuStrip = treeMenu;
                        treeKeywords.Nodes.Add(node);
                    }
                }
            });

        }

        private void btnKeywordSearch_Click(object sender, EventArgs e)
        {
            RefreshTree();
        }

        private void textBox1_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                RefreshTree();
            }
        }

        private void btnKeywordAdd_Click(object sender, EventArgs e)
        {
            CreateOrUpdateKeyword(null, null);
        }

        private void CreateOrUpdateKeyword(int? id, string content)
        {
            frmKeyword frm = new frmKeyword(id, content);
            frm.Show();
        }


        private void treeKeywords_AfterSelect(object sender, TreeViewEventArgs e)
        {
            Utils.DoWithWait(this, () =>
            {
                int key = Convert.ToInt32(e.Node.Tag);
                using (var db = new MyContext())
                {
                    var keyword = db.Keywords.Where(k => k.KeywordId == key).Single();
                    grdSentences.DataSource = keyword.Sentences;
                }
            });

        }

        private void grdSentences_SelectionChanged(object sender, EventArgs e)
        {
            if (grdSentences.SelectedRows.Count > 0)
            {
                var sentenceId = Convert.ToInt32(grdSentences.SelectedRows[0].Cells["SentenceId"].Value);
                Utils.DoWithWait(this, () =>
                {
                    using (var db = new MyContext())
                    {
                        var sentence = db.Sentences.Where(s => s.SentenceId == sentenceId).Single();
                        grdReferences.DataSource = sentence.References.Select(s => new SearchResult(s)).ToList();
                    }
                });
            }

        }


        private void ExitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void AuthorManagementToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmAuthor frm = new frmAuthor();
            frm.Show();
        }

        private void initDBToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Utils.initSampleDB();
            RefreshTree();
        }

        private void BookManagementToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmBookManagement frm = new frmBookManagement();
            frm.Show();
        }

    }
}

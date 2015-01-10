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

            RefreshTree(1);
        }

        private void refreshToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var treeNode = treeKeywords.SelectedNode;
            if (treeNode != null)
            {
                CreateOrUpdateKeyword((Keyword)treeNode.Tag);
            }
        }

        private void RefreshTree(int maxDepth = 0)
        {
            Utils.DoWithWait(this, () =>
            {
                string key = textBox1.Text;
                treeKeywords.Nodes.Clear();
                treeKeywords.Nodes.Add(new TreeNode("ریشه")
                {
                    Name = "_",
                    ContextMenuStrip = treeMenu,
                    Tag = null,
                });
                using (var db = new KeywordManagementContext())
                {
                    foreach (var keyword in db.Keywords.Include("Parent").Where(k => !string.IsNullOrEmpty(k.Content) && k.Content.Contains(key)).OrderBy(k => k.Content))
                    {
                        var root = getRoot(keyword);
                        var newNode = newTreeNode(root, 0, maxDepth, key);
                        if (newNode != null && !treeKeywords.Nodes[0].Nodes.ContainsKey(newNode.Name))
                        {
                            treeKeywords.Nodes[0].Nodes.Add(newNode);
                        }
                    }
                }
                treeKeywords.Nodes[0].Expand();
            });
        }

        private TreeNode newTreeNode(Keyword keyword, int depth = 0, int maxDepth = 0, string keySearch = "")
        {
            if (maxDepth > 0 && depth >= maxDepth)
                return null;
            var node = new TreeNode(keyword.Content)
            {
                Name = keyword.KeywordId.ToString(),
                Tag = keyword
            };
            node.ContextMenuStrip = treeMenu;
            keyword.Childs.Where(keywordChild => keywordChild.Content.Contains(keySearch))
                          .ToList()
                          .ForEach(keywordChild =>
                            {
                                var newNode = newTreeNode(keywordChild, ++depth, maxDepth, keySearch);
                                if (newNode != null)
                                    node.Nodes.Add(newNode);
                            });
            if (keyword.Childs.Count > 0)
            {
                node.BackColor = Color.LightSkyBlue;
            }
            return node;
        }

        private Keyword getRoot(Keyword keyword)
        {
            if (keyword.Parent == null)
                return keyword;
            return getRoot(keyword.Parent);
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
            CreateOrUpdateKeyword(treeKeywords.SelectedNode == null ? null : (Keyword)treeKeywords.SelectedNode.Tag);
        }

        private void CreateOrUpdateKeyword(Keyword keyword)
        {
            frmKeyword frm = new frmKeyword(keyword);
            frm.Show();
        }


        private void treeKeywords_AfterSelect(object sender, TreeViewEventArgs e)
        {
            Utils.DoWithWait(this, () =>
            {
                if (e.Node.Tag == null)
                    return;
                int key = Convert.ToInt32(((Keyword)e.Node.Tag).KeywordId);
                using (var db = new KeywordManagementContext())
                {
                    var keyword = db.Keywords.Where(k => k.KeywordId == key).Single();
                    grdSentences.DataSource = keyword.Sentences;
                    if (e.Node.Nodes.Count == 0)
                    {
                        keyword.Childs.ForEach(keywordChild =>
                        {
                            var newNode = newTreeNode(keywordChild);
                            if (newNode != null)
                                e.Node.Nodes.Add(newNode);
                        });
                    }
                    e.Node.Expand();
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
                    using (var db = new KeywordManagementContext())
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

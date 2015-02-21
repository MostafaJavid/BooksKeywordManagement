using KeywordManagement.Domain;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Dynamic;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace KeywordManagement
{
    public partial class frmMain : Form
    {
        private IDictionary<int, TreeNode> pickedNodes;
        private BindingSource bindingSource;
        public frmMain()
        {
            InitializeComponent();
            treeKeywords.TreeViewNodeSorter = new TreeContentComparer();
            grdSentences.AutoGenerateColumns = false;
            grdReferences.AutoGenerateColumns = false;
            bindingSource = new BindingSource();
            pickedNodes = new Dictionary<int, TreeNode>();
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
                CreateOrUpdateKeyword(treeNode, FormMode.Update);
            }
        }

        private void RefreshTree(int maxDepth = 0)
        {
            Utils.DoWithWait(this, () =>
            {
                string key = textBox1.Text;
                treeKeywords.Nodes.Clear();
                pickedNodes.Clear();
                treeKeywords.Nodes.Add(new TreeNode("*")
                {
                    Name = "_",
                    ContextMenuStrip = treeMenu,
                    Tag = null,
                });
                using (var db = new KeywordManagementContext())
                {
                    foreach (var keyword in db.Keywords.Include("Parent").OrderBy(k => k.Content))
                    {
                        var root = getRoot(keyword);
                        var newNode = newTreeNode(root, 0, maxDepth, key);
                        if (newNode != null && !treeKeywords.Nodes[0].Nodes.ContainsKey(newNode.Name))
                        {
                            treeKeywords.Nodes[0].Nodes.Add(newNode);
                        }
                        if (!string.IsNullOrEmpty(key) && keyword.Content.Contains(key))
                        {
                            pickedNodes.Add(keyword.KeywordId, newNode);
                            newNode.BackColor = SystemColors.ControlLight;
                        }
                    }
                }
                treeKeywords.Nodes[0].Expand();
                if (pickedNodes.Count > 0)
                {
                    treeKeywords.SelectedNode = pickedNodes.First().Value;
                }
                treeKeywords.Focus();
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
            CreateOrUpdateKeyword(/*treeKeywords.SelectedNode ?? */treeKeywords.Nodes[0], FormMode.Create);
        }

        private void CreateOrUpdateKeyword(TreeNode treeNode, FormMode formMode)
        {
            frmKeyword frm = new frmKeyword(treeNode, formMode, (keyword => { return this.newTreeNode(keyword); }));
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
                        //var treeNode = treeKeywords.Nodes.Find(sentence.Keyword.KeywordId.ToString(), true).FirstOrDefault();
                        //if (treeNode != null)
                        //{
                        //    treeKeywords.SelectedNode = treeNode;
                        //}
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

        private void RemoveToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var treeNode = treeKeywords.SelectedNode;
            if (treeNode == null || treeNode.Parent == null)
                return;
            Utils.DoWithWait(this, () =>
            {
                using (var db = new KeywordManagementContext())
                {
                    var keyword = treeNode.Tag as Keyword;
                    db.Keywords.Attach(keyword);
                    db.Keywords.Remove(keyword);
                    if (keyword.Parent != null)
                    {
                        keyword.Parent.Childs.Remove(keyword);
                    }
                    db.SaveChanges();
                    treeNode.Parent.Nodes.Remove(treeNode);
                }
            });
        }

        private void InsertToolStripMenuItem_Click(object sender, EventArgs e)
        {
            CreateOrUpdateKeyword(treeKeywords.SelectedNode ?? treeKeywords.Nodes[0], FormMode.Create);
        }

        private void btnAddSentences_Click(object sender, EventArgs e)
        {
            if (treeKeywords.SelectedNode == null || treeKeywords.SelectedNode.Tag == null)
            {
                MessageBox.Show("لطفا یک کلید واژه انتخاب نمایید", "خطا در افزودن جلمه");
                return;
            }

            var frmSentence = new frmSentence((Keyword)treeKeywords.SelectedNode.Tag, FormMode.Create);
            frmSentence.Show();
            frmSentence.FormClosed += frmSentence_FormClosed;
        }

        void frmSentence_FormClosed(object sender, FormClosedEventArgs e)
        {
            if (treeKeywords.SelectedNode != null && treeKeywords.SelectedNode.Tag != null)
            {
                using (var db = new KeywordManagementContext())
                {
                    var keyword = db.Keywords.FirstOrDefault(word => word.KeywordId == ((Keyword)treeKeywords.SelectedNode.Tag).KeywordId);
                    var index = grdSentences.Rows.Count == keyword.Sentences.Count ? this.grdSentences.CurrentRow.Index : keyword.Sentences.Count - 1;
                    this.grdSentences.DataSource = keyword.Sentences;
                    this.grdSentences.ClearSelection();
                    this.grdSentences.Rows[index].Selected = true;
                    treeKeywords.Focus();
                }
            }
        }

        private void btnSearchSentence_Click(object sender, EventArgs e)
        {
            if (treeKeywords.SelectedNode != null && treeKeywords.SelectedNode.Tag != null)
            {
                using (var db = new KeywordManagementContext())
                {
                    var keyword = (Keyword)treeKeywords.SelectedNode.Tag;
                    db.Keywords.Attach(keyword);
                    this.grdSentences.DataSource = keyword.Sentences.Where(sentence => sentence.Content.Contains(textSentenceSearch.Text)).ToList();
                }
            }
        }

        private void btnAddReference_Click(object sender, EventArgs e)
        {
            if (treeKeywords.SelectedNode == null || treeKeywords.SelectedNode.Tag == null || grdSentences.SelectedRows.Count == 0)
            {
                MessageBox.Show("لطفا یک جلمه انتخاب نمایید", "خطا در افزودن ارجاع");
                return;
            }
            Sentence theSentence = null;
            using (var db = new KeywordManagementContext())
            {
                var sentenceId = Convert.ToInt32(grdSentences.SelectedRows[0].Cells["SentenceId"].Value);
                theSentence = db.Sentences.Include("Keyword").FirstOrDefault(sentence => sentence.SentenceId == sentenceId);
            }
            var frmSentence = new frmSentence(theSentence, theSentence.Keyword, FormMode.Update);
            frmSentence.Show();
            frmSentence.FormClosed += frmSentence_FormClosed;
        }

        private void treeKeywords_KeyDown(object sender, KeyEventArgs e)
        {
            if (treeKeywords.SelectedNode != null && pickedNodes.Count > 0 && e.Control)
            {
                IEnumerator<KeyValuePair<int, TreeNode>> enumerator;
                TreeNode selectedNode;
                pickedNodes.TryGetValue(((Keyword)treeKeywords.SelectedNode.Tag).KeywordId, out selectedNode);
                switch (e.KeyCode)
                {
                    case Keys.Down:
                        if (selectedNode == null)
                        {
                            selectedNode = pickedNodes.Values.Where(node => node == treeKeywords.SelectedNode).FirstOrDefault() ?? pickedNodes.FirstOrDefault().Value;
                            treeKeywords.SelectedNode = selectedNode;
                        }
                        else
                        {
                            enumerator = pickedNodes.OrderBy(pickedNode => pickedNode.Value.Text).SkipWhile(pickedNode => pickedNode.Key != ((Keyword)selectedNode.Tag).KeywordId).GetEnumerator();
                            if (enumerator.MoveNext() && enumerator.MoveNext())
                            {
                                treeKeywords.SelectedNode = enumerator.Current.Value;
                            }
                            else
                            {
                                treeKeywords.SelectedNode = pickedNodes.FirstOrDefault().Value;
                            }
                        }
                        break;
                }
            }
        }
    }
}

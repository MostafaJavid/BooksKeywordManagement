namespace KeywordManagement
{
    partial class frmMain
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.grpKeywordsSearch = new System.Windows.Forms.GroupBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.btnKeywordAdd = new System.Windows.Forms.Button();
            this.btnKeywordSearch = new System.Windows.Forms.Button();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.grpTree = new System.Windows.Forms.GroupBox();
            this.treeKeywords = new System.Windows.Forms.TreeView();
            this.splitContainer2 = new System.Windows.Forms.SplitContainer();
            this.grpSentences = new System.Windows.Forms.GroupBox();
            this.grdSentences = new System.Windows.Forms.DataGridView();
            this.Content = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Description = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.SentenceId = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.panel2 = new System.Windows.Forms.Panel();
            this.textSentenceSearch = new System.Windows.Forms.TextBox();
            this.btnAddSentence = new System.Windows.Forms.Button();
            this.btnSearchSentence = new System.Windows.Forms.Button();
            this.grpRefrences = new System.Windows.Forms.GroupBox();
            this.grdReferences = new System.Windows.Forms.DataGridView();
            this.BookTitle = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.PageNumber = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ReferenceDescription = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.panel3 = new System.Windows.Forms.Panel();
            this.btnAddReference = new System.Windows.Forms.Button();
            this.button4 = new System.Windows.Forms.Button();
            this.treeMenu = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.InsertToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.refreshToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.RemoveToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.منواصلیToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.مدیریتکتابهاToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.مدیریتنویسندگانToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.خروجToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.initDBToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.grpKeywordsSearch.SuspendLayout();
            this.panel1.SuspendLayout();
            this.grpTree.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer2)).BeginInit();
            this.splitContainer2.Panel1.SuspendLayout();
            this.splitContainer2.Panel2.SuspendLayout();
            this.splitContainer2.SuspendLayout();
            this.grpSentences.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grdSentences)).BeginInit();
            this.panel2.SuspendLayout();
            this.grpRefrences.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grdReferences)).BeginInit();
            this.panel3.SuspendLayout();
            this.treeMenu.SuspendLayout();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // splitContainer1
            // 
            this.splitContainer1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.splitContainer1.Location = new System.Drawing.Point(0, 27);
            this.splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.grpKeywordsSearch);
            this.splitContainer1.Panel1.Controls.Add(this.grpTree);
            this.splitContainer1.Panel1.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.splitContainer2);
            this.splitContainer1.Panel2.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.splitContainer1.Size = new System.Drawing.Size(926, 391);
            this.splitContainer1.SplitterDistance = 184;
            this.splitContainer1.TabIndex = 0;
            // 
            // grpKeywordsSearch
            // 
            this.grpKeywordsSearch.Controls.Add(this.panel1);
            this.grpKeywordsSearch.Controls.Add(this.textBox1);
            this.grpKeywordsSearch.Dock = System.Windows.Forms.DockStyle.Top;
            this.grpKeywordsSearch.Location = new System.Drawing.Point(0, 0);
            this.grpKeywordsSearch.Name = "grpKeywordsSearch";
            this.grpKeywordsSearch.Size = new System.Drawing.Size(184, 76);
            this.grpKeywordsSearch.TabIndex = 2;
            this.grpKeywordsSearch.TabStop = false;
            this.grpKeywordsSearch.Text = "لغات کلیدی";
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.btnKeywordAdd);
            this.panel1.Controls.Add(this.btnKeywordSearch);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel1.Location = new System.Drawing.Point(3, 42);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(178, 31);
            this.panel1.TabIndex = 2;
            // 
            // btnKeywordAdd
            // 
            this.btnKeywordAdd.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.btnKeywordAdd.Location = new System.Drawing.Point(15, 3);
            this.btnKeywordAdd.Name = "btnKeywordAdd";
            this.btnKeywordAdd.Size = new System.Drawing.Size(75, 23);
            this.btnKeywordAdd.TabIndex = 1;
            this.btnKeywordAdd.Text = "افزودن";
            this.btnKeywordAdd.UseVisualStyleBackColor = true;
            this.btnKeywordAdd.Click += new System.EventHandler(this.btnKeywordAdd_Click);
            // 
            // btnKeywordSearch
            // 
            this.btnKeywordSearch.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.btnKeywordSearch.Location = new System.Drawing.Point(95, 2);
            this.btnKeywordSearch.Name = "btnKeywordSearch";
            this.btnKeywordSearch.Size = new System.Drawing.Size(75, 23);
            this.btnKeywordSearch.TabIndex = 0;
            this.btnKeywordSearch.Text = "جستجو";
            this.btnKeywordSearch.UseVisualStyleBackColor = true;
            this.btnKeywordSearch.Click += new System.EventHandler(this.btnKeywordSearch_Click);
            // 
            // textBox1
            // 
            this.textBox1.Dock = System.Windows.Forms.DockStyle.Top;
            this.textBox1.Location = new System.Drawing.Point(3, 16);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(178, 20);
            this.textBox1.TabIndex = 0;
            this.textBox1.KeyUp += new System.Windows.Forms.KeyEventHandler(this.textBox1_KeyUp);
            // 
            // grpTree
            // 
            this.grpTree.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.grpTree.Controls.Add(this.treeKeywords);
            this.grpTree.Location = new System.Drawing.Point(0, 79);
            this.grpTree.Name = "grpTree";
            this.grpTree.Size = new System.Drawing.Size(184, 312);
            this.grpTree.TabIndex = 1;
            this.grpTree.TabStop = false;
            // 
            // treeKeywords
            // 
            this.treeKeywords.Dock = System.Windows.Forms.DockStyle.Fill;
            this.treeKeywords.HideSelection = false;
            this.treeKeywords.Location = new System.Drawing.Point(3, 16);
            this.treeKeywords.Name = "treeKeywords";
            this.treeKeywords.RightToLeftLayout = true;
            this.treeKeywords.Size = new System.Drawing.Size(178, 293);
            this.treeKeywords.TabIndex = 1;
            this.treeKeywords.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this.treeKeywords_AfterSelect);
            this.treeKeywords.KeyDown += new System.Windows.Forms.KeyEventHandler(this.treeKeywords_KeyDown);
            // 
            // splitContainer2
            // 
            this.splitContainer2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer2.Location = new System.Drawing.Point(0, 0);
            this.splitContainer2.Name = "splitContainer2";
            this.splitContainer2.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer2.Panel1
            // 
            this.splitContainer2.Panel1.Controls.Add(this.grpSentences);
            this.splitContainer2.Panel1.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            // 
            // splitContainer2.Panel2
            // 
            this.splitContainer2.Panel2.Controls.Add(this.grpRefrences);
            this.splitContainer2.Panel2.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.splitContainer2.Size = new System.Drawing.Size(738, 391);
            this.splitContainer2.SplitterDistance = 210;
            this.splitContainer2.TabIndex = 0;
            // 
            // grpSentences
            // 
            this.grpSentences.Controls.Add(this.grdSentences);
            this.grpSentences.Controls.Add(this.panel2);
            this.grpSentences.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grpSentences.Location = new System.Drawing.Point(0, 0);
            this.grpSentences.Name = "grpSentences";
            this.grpSentences.Size = new System.Drawing.Size(738, 210);
            this.grpSentences.TabIndex = 1;
            this.grpSentences.TabStop = false;
            this.grpSentences.Text = "لیست جملات مربوطه";
            // 
            // grdSentences
            // 
            this.grdSentences.AllowUserToAddRows = false;
            this.grdSentences.AllowUserToDeleteRows = false;
            this.grdSentences.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.grdSentences.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Content,
            this.Description,
            this.SentenceId});
            this.grdSentences.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grdSentences.Location = new System.Drawing.Point(3, 47);
            this.grdSentences.Name = "grdSentences";
            this.grdSentences.ReadOnly = true;
            this.grdSentences.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.grdSentences.Size = new System.Drawing.Size(732, 160);
            this.grdSentences.TabIndex = 4;
            this.grdSentences.SelectionChanged += new System.EventHandler(this.grdSentences_SelectionChanged);
            // 
            // Content
            // 
            this.Content.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.Content.DataPropertyName = "Content";
            this.Content.HeaderText = "جمله";
            this.Content.Name = "Content";
            this.Content.ReadOnly = true;
            this.Content.Width = 52;
            // 
            // Description
            // 
            this.Description.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.Description.DataPropertyName = "Description";
            this.Description.HeaderText = "توضیحات";
            this.Description.Name = "Description";
            this.Description.ReadOnly = true;
            // 
            // SentenceId
            // 
            this.SentenceId.DataPropertyName = "SentenceId";
            this.SentenceId.HeaderText = "SentenceId";
            this.SentenceId.Name = "SentenceId";
            this.SentenceId.ReadOnly = true;
            this.SentenceId.Visible = false;
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.textSentenceSearch);
            this.panel2.Controls.Add(this.btnAddSentence);
            this.panel2.Controls.Add(this.btnSearchSentence);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel2.Location = new System.Drawing.Point(3, 16);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(732, 31);
            this.panel2.TabIndex = 3;
            // 
            // textSentenceSearch
            // 
            this.textSentenceSearch.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.textSentenceSearch.Location = new System.Drawing.Point(453, 5);
            this.textSentenceSearch.Name = "textSentenceSearch";
            this.textSentenceSearch.Size = new System.Drawing.Size(276, 20);
            this.textSentenceSearch.TabIndex = 2;
            // 
            // btnAddSentence
            // 
            this.btnAddSentence.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.btnAddSentence.Location = new System.Drawing.Point(292, 3);
            this.btnAddSentence.Name = "btnAddSentence";
            this.btnAddSentence.Size = new System.Drawing.Size(75, 23);
            this.btnAddSentence.TabIndex = 1;
            this.btnAddSentence.Text = "افزودن";
            this.btnAddSentence.UseVisualStyleBackColor = true;
            this.btnAddSentence.Click += new System.EventHandler(this.btnAddSentences_Click);
            // 
            // btnSearchSentence
            // 
            this.btnSearchSentence.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.btnSearchSentence.Location = new System.Drawing.Point(372, 2);
            this.btnSearchSentence.Name = "btnSearchSentence";
            this.btnSearchSentence.Size = new System.Drawing.Size(75, 23);
            this.btnSearchSentence.TabIndex = 0;
            this.btnSearchSentence.Text = "جستجو";
            this.btnSearchSentence.UseVisualStyleBackColor = true;
            this.btnSearchSentence.Click += new System.EventHandler(this.btnSearchSentence_Click);
            // 
            // grpRefrences
            // 
            this.grpRefrences.Controls.Add(this.grdReferences);
            this.grpRefrences.Controls.Add(this.panel3);
            this.grpRefrences.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grpRefrences.Location = new System.Drawing.Point(0, 0);
            this.grpRefrences.Name = "grpRefrences";
            this.grpRefrences.Size = new System.Drawing.Size(738, 177);
            this.grpRefrences.TabIndex = 1;
            this.grpRefrences.TabStop = false;
            this.grpRefrences.Text = "لیست ارجاعات";
            // 
            // grdReferences
            // 
            this.grdReferences.AllowUserToAddRows = false;
            this.grdReferences.AllowUserToDeleteRows = false;
            this.grdReferences.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.grdReferences.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.BookTitle,
            this.PageNumber,
            this.ReferenceDescription});
            this.grdReferences.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grdReferences.Location = new System.Drawing.Point(3, 47);
            this.grdReferences.Name = "grdReferences";
            this.grdReferences.ReadOnly = true;
            this.grdReferences.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.grdReferences.Size = new System.Drawing.Size(732, 127);
            this.grdReferences.TabIndex = 5;
            // 
            // BookTitle
            // 
            this.BookTitle.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.BookTitle.DataPropertyName = "BookTitle";
            this.BookTitle.HeaderText = "نام کتاب";
            this.BookTitle.Name = "BookTitle";
            this.BookTitle.ReadOnly = true;
            this.BookTitle.Width = 71;
            // 
            // PageNumber
            // 
            this.PageNumber.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.PageNumber.DataPropertyName = "PageNumber";
            this.PageNumber.HeaderText = "شماره صفحه";
            this.PageNumber.Name = "PageNumber";
            this.PageNumber.ReadOnly = true;
            this.PageNumber.Width = 90;
            // 
            // ReferenceDescription
            // 
            this.ReferenceDescription.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.ReferenceDescription.DataPropertyName = "Description";
            this.ReferenceDescription.HeaderText = "آدرس";
            this.ReferenceDescription.Name = "ReferenceDescription";
            this.ReferenceDescription.ReadOnly = true;
            // 
            // panel3
            // 
            this.panel3.Controls.Add(this.btnAddReference);
            this.panel3.Controls.Add(this.button4);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel3.Location = new System.Drawing.Point(3, 16);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(732, 31);
            this.panel3.TabIndex = 4;
            // 
            // btnAddReference
            // 
            this.btnAddReference.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.btnAddReference.Location = new System.Drawing.Point(292, 3);
            this.btnAddReference.Name = "btnAddReference";
            this.btnAddReference.Size = new System.Drawing.Size(75, 23);
            this.btnAddReference.TabIndex = 1;
            this.btnAddReference.Text = "افزودن";
            this.btnAddReference.UseVisualStyleBackColor = true;
            this.btnAddReference.Click += new System.EventHandler(this.btnAddReference_Click);
            // 
            // button4
            // 
            this.button4.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.button4.Location = new System.Drawing.Point(372, 2);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(75, 23);
            this.button4.TabIndex = 0;
            this.button4.Text = "جستجو";
            this.button4.UseVisualStyleBackColor = true;
            // 
            // treeMenu
            // 
            this.treeMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.InsertToolStripMenuItem,
            this.refreshToolStripMenuItem,
            this.RemoveToolStripMenuItem});
            this.treeMenu.Name = "treeMenu";
            this.treeMenu.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.treeMenu.Size = new System.Drawing.Size(106, 70);
            // 
            // InsertToolStripMenuItem
            // 
            this.InsertToolStripMenuItem.Name = "InsertToolStripMenuItem";
            this.InsertToolStripMenuItem.Size = new System.Drawing.Size(105, 22);
            this.InsertToolStripMenuItem.Text = "ایجاد";
            this.InsertToolStripMenuItem.Click += new System.EventHandler(this.InsertToolStripMenuItem_Click);
            // 
            // refreshToolStripMenuItem
            // 
            this.refreshToolStripMenuItem.Name = "refreshToolStripMenuItem";
            this.refreshToolStripMenuItem.Size = new System.Drawing.Size(105, 22);
            this.refreshToolStripMenuItem.Text = "ویرایش";
            this.refreshToolStripMenuItem.Click += new System.EventHandler(this.refreshToolStripMenuItem_Click);
            // 
            // RemoveToolStripMenuItem
            // 
            this.RemoveToolStripMenuItem.Name = "RemoveToolStripMenuItem";
            this.RemoveToolStripMenuItem.Size = new System.Drawing.Size(105, 22);
            this.RemoveToolStripMenuItem.Text = "حذف";
            this.RemoveToolStripMenuItem.Click += new System.EventHandler(this.RemoveToolStripMenuItem_Click);
            // 
            // menuStrip1
            // 
            this.menuStrip1.BackColor = System.Drawing.Color.LightSteelBlue;
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.منواصلیToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(926, 24);
            this.menuStrip1.TabIndex = 2;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // منواصلیToolStripMenuItem
            // 
            this.منواصلیToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.مدیریتکتابهاToolStripMenuItem,
            this.مدیریتنویسندگانToolStripMenuItem,
            this.خروجToolStripMenuItem,
            this.initDBToolStripMenuItem});
            this.منواصلیToolStripMenuItem.Name = "منواصلیToolStripMenuItem";
            this.منواصلیToolStripMenuItem.Size = new System.Drawing.Size(62, 20);
            this.منواصلیToolStripMenuItem.Text = "منو اصلی";
            // 
            // مدیریتکتابهاToolStripMenuItem
            // 
            this.مدیریتکتابهاToolStripMenuItem.Name = "مدیریتکتابهاToolStripMenuItem";
            this.مدیریتکتابهاToolStripMenuItem.Size = new System.Drawing.Size(144, 22);
            this.مدیریتکتابهاToolStripMenuItem.Text = "مدیریت کتاب ها";
            this.مدیریتکتابهاToolStripMenuItem.Click += new System.EventHandler(this.BookManagementToolStripMenuItem_Click);
            // 
            // مدیریتنویسندگانToolStripMenuItem
            // 
            this.مدیریتنویسندگانToolStripMenuItem.Name = "مدیریتنویسندگانToolStripMenuItem";
            this.مدیریتنویسندگانToolStripMenuItem.Size = new System.Drawing.Size(144, 22);
            this.مدیریتنویسندگانToolStripMenuItem.Text = "افزودن نویسنده";
            this.مدیریتنویسندگانToolStripMenuItem.Click += new System.EventHandler(this.AuthorManagementToolStripMenuItem_Click);
            // 
            // خروجToolStripMenuItem
            // 
            this.خروجToolStripMenuItem.Name = "خروجToolStripMenuItem";
            this.خروجToolStripMenuItem.Size = new System.Drawing.Size(144, 22);
            this.خروجToolStripMenuItem.Text = "خروج";
            this.خروجToolStripMenuItem.Click += new System.EventHandler(this.ExitToolStripMenuItem_Click);
            // 
            // initDBToolStripMenuItem
            // 
            this.initDBToolStripMenuItem.Name = "initDBToolStripMenuItem";
            this.initDBToolStripMenuItem.Size = new System.Drawing.Size(144, 22);
            this.initDBToolStripMenuItem.Text = "InitDB";
            this.initDBToolStripMenuItem.Click += new System.EventHandler(this.initDBToolStripMenuItem_Click);
            // 
            // frmMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(926, 418);
            this.Controls.Add(this.menuStrip1);
            this.Controls.Add(this.splitContainer1);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "frmMain";
            this.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.Text = "برنامه مدیریت لغات کلیدی";
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.grpKeywordsSearch.ResumeLayout(false);
            this.grpKeywordsSearch.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.grpTree.ResumeLayout(false);
            this.splitContainer2.Panel1.ResumeLayout(false);
            this.splitContainer2.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer2)).EndInit();
            this.splitContainer2.ResumeLayout(false);
            this.grpSentences.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.grdSentences)).EndInit();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.grpRefrences.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.grdReferences)).EndInit();
            this.panel3.ResumeLayout(false);
            this.treeMenu.ResumeLayout(false);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.GroupBox grpTree;
        private System.Windows.Forms.TreeView treeKeywords;
        private System.Windows.Forms.ContextMenuStrip treeMenu;
        private System.Windows.Forms.ToolStripMenuItem refreshToolStripMenuItem;
        private System.Windows.Forms.GroupBox grpKeywordsSearch;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Button btnKeywordAdd;
        private System.Windows.Forms.Button btnKeywordSearch;
        private System.Windows.Forms.SplitContainer splitContainer2;
        private System.Windows.Forms.GroupBox grpSentences;
        private System.Windows.Forms.GroupBox grpRefrences;
        private System.Windows.Forms.DataGridView grdSentences;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Button btnAddSentence;
        private System.Windows.Forms.Button btnSearchSentence;
        private System.Windows.Forms.DataGridView grdReferences;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Button btnAddReference;
        private System.Windows.Forms.Button button4;
        private System.Windows.Forms.DataGridViewTextBoxColumn Content;
        private System.Windows.Forms.DataGridViewTextBoxColumn Description;
        private System.Windows.Forms.DataGridViewTextBoxColumn SentenceId;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem منواصلیToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem مدیریتکتابهاToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem مدیریتنویسندگانToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem خروجToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem initDBToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem RemoveToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem InsertToolStripMenuItem;
        private System.Windows.Forms.TextBox textSentenceSearch;
        private System.Windows.Forms.DataGridViewTextBoxColumn BookTitle;
        private System.Windows.Forms.DataGridViewTextBoxColumn PageNumber;
        private System.Windows.Forms.DataGridViewTextBoxColumn ReferenceDescription;
    }
}


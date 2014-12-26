namespace KeywordManagement
{
    partial class frmBookManagement
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
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.txtTitle = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.btnAdd = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.btnSearch = new System.Windows.Forms.Button();
            this.grdBooks = new System.Windows.Forms.DataGridView();
            this.btnRemove = new System.Windows.Forms.Button();
            this.BookTitle = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.PageNumber = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Author0_FullName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Author1_FullName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.BookPublicationYear = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.BookPublisher = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.BookPublishNumber = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ReferenceDescription = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ReferenceId = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.BookId = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grdBooks)).BeginInit();
            this.SuspendLayout();
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.Location = new System.Drawing.Point(0, 0);
            this.splitContainer1.Name = "splitContainer1";
            this.splitContainer1.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.txtTitle);
            this.splitContainer1.Panel1.Controls.Add(this.label1);
            this.splitContainer1.Panel1.Controls.Add(this.groupBox1);
            this.splitContainer1.Panel1.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.grdBooks);
            this.splitContainer1.Panel2.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.splitContainer1.Size = new System.Drawing.Size(623, 489);
            this.splitContainer1.SplitterDistance = 78;
            this.splitContainer1.TabIndex = 0;
            // 
            // txtTitle
            // 
            this.txtTitle.Location = new System.Drawing.Point(385, 9);
            this.txtTitle.Name = "txtTitle";
            this.txtTitle.Size = new System.Drawing.Size(153, 20);
            this.txtTitle.TabIndex = 2;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(542, 13);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(63, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "عنوان کتاب:";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.btnRemove);
            this.groupBox1.Controls.Add(this.btnAdd);
            this.groupBox1.Controls.Add(this.btnCancel);
            this.groupBox1.Controls.Add(this.btnSearch);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.groupBox1.Location = new System.Drawing.Point(0, 29);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(623, 49);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            // 
            // btnAdd
            // 
            this.btnAdd.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.btnAdd.Location = new System.Drawing.Point(369, 19);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(104, 23);
            this.btnAdd.TabIndex = 2;
            this.btnAdd.Text = "افزودن کتاب جدید";
            this.btnAdd.UseVisualStyleBackColor = true;
            // 
            // btnCancel
            // 
            this.btnCancel.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.btnCancel.Location = new System.Drawing.Point(94, 20);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(75, 23);
            this.btnCancel.TabIndex = 1;
            this.btnCancel.Text = "انصراف";
            this.btnCancel.UseVisualStyleBackColor = true;
            // 
            // btnSearch
            // 
            this.btnSearch.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.btnSearch.Location = new System.Drawing.Point(288, 20);
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.Size = new System.Drawing.Size(75, 23);
            this.btnSearch.TabIndex = 0;
            this.btnSearch.Text = "جستجو";
            this.btnSearch.UseVisualStyleBackColor = true;
            this.btnSearch.Click += new System.EventHandler(this.btnSearch_Click);
            // 
            // grdBooks
            // 
            this.grdBooks.AllowUserToAddRows = false;
            this.grdBooks.AllowUserToDeleteRows = false;
            this.grdBooks.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.grdBooks.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.BookTitle,
            this.PageNumber,
            this.Author0_FullName,
            this.Author1_FullName,
            this.BookPublicationYear,
            this.BookPublisher,
            this.BookPublishNumber,
            this.ReferenceDescription,
            this.ReferenceId,
            this.BookId});
            this.grdBooks.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grdBooks.Location = new System.Drawing.Point(0, 0);
            this.grdBooks.Name = "grdBooks";
            this.grdBooks.ReadOnly = true;
            this.grdBooks.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.grdBooks.Size = new System.Drawing.Size(623, 407);
            this.grdBooks.TabIndex = 6;
            // 
            // btnRemove
            // 
            this.btnRemove.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.btnRemove.Location = new System.Drawing.Point(175, 21);
            this.btnRemove.Name = "btnRemove";
            this.btnRemove.Size = new System.Drawing.Size(75, 23);
            this.btnRemove.TabIndex = 3;
            this.btnRemove.Text = "حذف";
            this.btnRemove.UseVisualStyleBackColor = true;
            this.btnRemove.Click += new System.EventHandler(this.btnRemove_Click);
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
            this.PageNumber.Visible = false;
            this.PageNumber.Width = 90;
            // 
            // Author0_FullName
            // 
            this.Author0_FullName.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.Author0_FullName.DataPropertyName = "Author0_FullName";
            this.Author0_FullName.HeaderText = "نام نویسنده اول";
            this.Author0_FullName.Name = "Author0_FullName";
            this.Author0_FullName.ReadOnly = true;
            this.Author0_FullName.Width = 97;
            // 
            // Author1_FullName
            // 
            this.Author1_FullName.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.Author1_FullName.DataPropertyName = "Author1_FullName";
            this.Author1_FullName.HeaderText = "نام نویسنده دوم";
            this.Author1_FullName.Name = "Author1_FullName";
            this.Author1_FullName.ReadOnly = true;
            this.Author1_FullName.Visible = false;
            this.Author1_FullName.Width = 97;
            // 
            // BookPublicationYear
            // 
            this.BookPublicationYear.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.BookPublicationYear.DataPropertyName = "BookPublicationYear";
            this.BookPublicationYear.HeaderText = "تاریخ نشر کتاب";
            this.BookPublicationYear.Name = "BookPublicationYear";
            this.BookPublicationYear.ReadOnly = true;
            this.BookPublicationYear.Width = 96;
            // 
            // BookPublisher
            // 
            this.BookPublisher.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.BookPublisher.DataPropertyName = "BookPublisher";
            this.BookPublisher.HeaderText = "ناشر";
            this.BookPublisher.Name = "BookPublisher";
            this.BookPublisher.ReadOnly = true;
            this.BookPublisher.Width = 54;
            // 
            // BookPublishNumber
            // 
            this.BookPublishNumber.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.BookPublishNumber.DataPropertyName = "BookPublishNumber";
            this.BookPublishNumber.HeaderText = "نوبت چاپ";
            this.BookPublishNumber.Name = "BookPublishNumber";
            this.BookPublishNumber.ReadOnly = true;
            this.BookPublishNumber.Width = 70;
            // 
            // ReferenceDescription
            // 
            this.ReferenceDescription.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.ReferenceDescription.DataPropertyName = "Description";
            this.ReferenceDescription.HeaderText = "توضیحات";
            this.ReferenceDescription.Name = "ReferenceDescription";
            this.ReferenceDescription.ReadOnly = true;
            this.ReferenceDescription.Visible = false;
            // 
            // ReferenceId
            // 
            this.ReferenceId.DataPropertyName = "ReferenceId";
            this.ReferenceId.HeaderText = "ReferenceId";
            this.ReferenceId.Name = "ReferenceId";
            this.ReferenceId.ReadOnly = true;
            this.ReferenceId.Visible = false;
            // 
            // BookId
            // 
            this.BookId.DataPropertyName = "BookId";
            this.BookId.HeaderText = "BookId";
            this.BookId.Name = "BookId";
            this.BookId.ReadOnly = true;
            this.BookId.Visible = false;
            // 
            // frmBookManagement
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(623, 489);
            this.Controls.Add(this.splitContainer1);
            this.Name = "frmBookManagement";
            this.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "مدیریت کتاب ها";
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel1.PerformLayout();
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.grdBooks)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button btnAdd;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Button btnSearch;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtTitle;
        private System.Windows.Forms.DataGridView grdBooks;
        private System.Windows.Forms.Button btnRemove;
        private System.Windows.Forms.DataGridViewTextBoxColumn BookTitle;
        private System.Windows.Forms.DataGridViewTextBoxColumn PageNumber;
        private System.Windows.Forms.DataGridViewTextBoxColumn Author0_FullName;
        private System.Windows.Forms.DataGridViewTextBoxColumn Author1_FullName;
        private System.Windows.Forms.DataGridViewTextBoxColumn BookPublicationYear;
        private System.Windows.Forms.DataGridViewTextBoxColumn BookPublisher;
        private System.Windows.Forms.DataGridViewTextBoxColumn BookPublishNumber;
        private System.Windows.Forms.DataGridViewTextBoxColumn ReferenceDescription;
        private System.Windows.Forms.DataGridViewTextBoxColumn ReferenceId;
        private System.Windows.Forms.DataGridViewTextBoxColumn BookId;
    }
}
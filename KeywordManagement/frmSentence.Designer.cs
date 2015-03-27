using KeywordManagement.Domain;
using System;
using System.ComponentModel;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
namespace KeywordManagement
{
    public partial class frmSentence : Form
    {
        private Keyword keyword;
        private FormMode formMode;
        private Sentence sentence;
        private IContainer components;
        private Label label1;
        private TextBox txtSentence;
        private Label label2;
        private Label label3;
        private Label label5;
        private TextBox txtDescription;
        private Button bntSave;
        private Button btnCancle;
        protected override void Dispose(bool disposing)
        {
            if (disposing && this.components != null)
            {
                this.components.Dispose();
            }
            base.Dispose(disposing);
        }
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmSentence));
            this.label1 = new System.Windows.Forms.Label();
            this.txtSentence = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.txtDescription = new System.Windows.Forms.TextBox();
            this.bntSave = new System.Windows.Forms.Button();
            this.btnCancle = new System.Windows.Forms.Button();
            this.cbBookTitle = new System.Windows.Forms.ComboBox();
            this.cbAuthor = new System.Windows.Forms.ComboBox();
            this.txtKeyword = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.txtAddress = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.btnAddReference = new System.Windows.Forms.Button();
            this.imageList1 = new System.Windows.Forms.ImageList(this.components);
            this.btnRemoveReference = new System.Windows.Forms.Button();
            this.btnEditReference = new System.Windows.Forms.Button();
            this.grdReferences = new System.Windows.Forms.DataGridView();
            this.BookTitle = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Description = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ReferenceId = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.grdReferences)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(558, 37);
            this.label1.Margin = new System.Windows.Forms.Padding(3);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(30, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "جمله:";
            // 
            // txtSentence
            // 
            this.txtSentence.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtSentence.Location = new System.Drawing.Point(14, 34);
            this.txtSentence.Name = "txtSentence";
            this.txtSentence.Size = new System.Drawing.Size(541, 20);
            this.txtSentence.TabIndex = 1;
            // 
            // label2
            // 
            this.label2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(539, 69);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(49, 13);
            this.label2.TabIndex = 2;
            this.label2.Text = "نام کتاب:";
            // 
            // label3
            // 
            this.label3.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(201, 69);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(64, 13);
            this.label3.TabIndex = 4;
            this.label3.Text = "نام نویسنده:";
            // 
            // label5
            // 
            this.label5.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(536, 363);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(52, 13);
            this.label5.TabIndex = 8;
            this.label5.Text = "توضیحات:";
            // 
            // txtDescription
            // 
            this.txtDescription.Location = new System.Drawing.Point(14, 381);
            this.txtDescription.Multiline = true;
            this.txtDescription.Name = "txtDescription";
            this.txtDescription.Size = new System.Drawing.Size(571, 77);
            this.txtDescription.TabIndex = 6;
            // 
            // bntSave
            // 
            this.bntSave.Location = new System.Drawing.Point(309, 477);
            this.bntSave.Name = "bntSave";
            this.bntSave.Size = new System.Drawing.Size(75, 24);
            this.bntSave.TabIndex = 7;
            this.bntSave.Text = "ثبت";
            this.bntSave.UseVisualStyleBackColor = true;
            this.bntSave.Click += new System.EventHandler(this.bntSave_Click);
            // 
            // btnCancle
            // 
            this.btnCancle.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancle.Location = new System.Drawing.Point(217, 477);
            this.btnCancle.Name = "btnCancle";
            this.btnCancle.Size = new System.Drawing.Size(75, 24);
            this.btnCancle.TabIndex = 8;
            this.btnCancle.Text = "انصراف";
            this.btnCancle.UseVisualStyleBackColor = true;
            this.btnCancle.Click += new System.EventHandler(this.btnCancle_Click);
            // 
            // cbBookTitle
            // 
            this.cbBookTitle.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.cbBookTitle.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.CustomSource;
            this.cbBookTitle.FormattingEnabled = true;
            this.cbBookTitle.Location = new System.Drawing.Point(271, 65);
            this.cbBookTitle.Name = "cbBookTitle";
            this.cbBookTitle.Size = new System.Drawing.Size(264, 21);
            this.cbBookTitle.TabIndex = 2;
            // 
            // cbAuthor
            // 
            this.cbAuthor.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.cbAuthor.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.CustomSource;
            this.cbAuthor.Enabled = false;
            this.cbAuthor.FormattingEnabled = true;
            this.cbAuthor.Location = new System.Drawing.Point(14, 64);
            this.cbAuthor.Name = "cbAuthor";
            this.cbAuthor.Size = new System.Drawing.Size(183, 21);
            this.cbAuthor.TabIndex = 3;
            // 
            // txtKeyword
            // 
            this.txtKeyword.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtKeyword.Enabled = false;
            this.txtKeyword.Location = new System.Drawing.Point(14, 7);
            this.txtKeyword.Name = "txtKeyword";
            this.txtKeyword.Size = new System.Drawing.Size(521, 20);
            this.txtKeyword.TabIndex = 10;
            // 
            // label6
            // 
            this.label6.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(536, 10);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(52, 13);
            this.label6.TabIndex = 9;
            this.label6.Text = "کلید واژه:";
            // 
            // txtAddress
            // 
            this.txtAddress.Location = new System.Drawing.Point(12, 114);
            this.txtAddress.Multiline = true;
            this.txtAddress.Name = "txtAddress";
            this.txtAddress.Size = new System.Drawing.Size(571, 26);
            this.txtAddress.TabIndex = 5;
            // 
            // label4
            // 
            this.label4.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(555, 96);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(33, 13);
            this.label4.TabIndex = 12;
            this.label4.Text = "آدرس:";
            // 
            // btnAddReference
            // 
            this.btnAddReference.ImageKey = "iconmonstr-plus-2-icon-256.png";
            this.btnAddReference.ImageList = this.imageList1;
            this.btnAddReference.Location = new System.Drawing.Point(551, 151);
            this.btnAddReference.Name = "btnAddReference";
            this.btnAddReference.Size = new System.Drawing.Size(30, 28);
            this.btnAddReference.TabIndex = 13;
            this.btnAddReference.UseVisualStyleBackColor = true;
            this.btnAddReference.Click += new System.EventHandler(this.btnAddReference_Click);
            // 
            // imageList1
            // 
            this.imageList1.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageList1.ImageStream")));
            this.imageList1.TransparentColor = System.Drawing.Color.Transparent;
            this.imageList1.Images.SetKeyName(0, "iconmonstr-plus-2-icon-256.png");
            this.imageList1.Images.SetKeyName(1, "iconmonstr-minus-2-icon-256.png");
            this.imageList1.Images.SetKeyName(2, "iconmonstr-pencil-8-icon-256.png");
            // 
            // btnRemoveReference
            // 
            this.btnRemoveReference.Enabled = false;
            this.btnRemoveReference.ImageIndex = 1;
            this.btnRemoveReference.ImageList = this.imageList1;
            this.btnRemoveReference.Location = new System.Drawing.Point(479, 151);
            this.btnRemoveReference.Name = "btnRemoveReference";
            this.btnRemoveReference.Size = new System.Drawing.Size(30, 28);
            this.btnRemoveReference.TabIndex = 14;
            this.btnRemoveReference.UseVisualStyleBackColor = true;
            this.btnRemoveReference.Visible = false;
            // 
            // btnEditReference
            // 
            this.btnEditReference.ImageKey = "iconmonstr-pencil-8-icon-256.png";
            this.btnEditReference.ImageList = this.imageList1;
            this.btnEditReference.Location = new System.Drawing.Point(515, 151);
            this.btnEditReference.Name = "btnEditReference";
            this.btnEditReference.Size = new System.Drawing.Size(30, 28);
            this.btnEditReference.TabIndex = 15;
            this.btnEditReference.UseVisualStyleBackColor = true;
            this.btnEditReference.Click += new System.EventHandler(this.btnEditReference_Click);
            // 
            // grdReferences
            // 
            this.grdReferences.AllowUserToAddRows = false;
            this.grdReferences.AllowUserToDeleteRows = false;
            this.grdReferences.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.grdReferences.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.grdReferences.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.BookTitle,
            this.Description,
            this.ReferenceId});
            this.grdReferences.Location = new System.Drawing.Point(12, 185);
            this.grdReferences.Name = "grdReferences";
            this.grdReferences.ReadOnly = true;
            this.grdReferences.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.grdReferences.Size = new System.Drawing.Size(571, 173);
            this.grdReferences.TabIndex = 16;
            this.grdReferences.SelectionChanged += new System.EventHandler(this.grdReferences_SelectionChanged);
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
            // Description
            // 
            this.Description.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.Description.DataPropertyName = "Description";
            this.Description.HeaderText = "آدرس";
            this.Description.Name = "Description";
            this.Description.ReadOnly = true;
            // 
            // ReferenceId
            // 
            this.ReferenceId.DataPropertyName = "ReferenceId";
            this.ReferenceId.HeaderText = "ReferenceId";
            this.ReferenceId.Name = "ReferenceId";
            this.ReferenceId.ReadOnly = true;
            this.ReferenceId.Visible = false;
            // 
            // frmSentence
            // 
            this.AcceptButton = this.bntSave;
            this.CancelButton = this.btnCancle;
            this.ClientSize = new System.Drawing.Size(598, 514);
            this.Controls.Add(this.grdReferences);
            this.Controls.Add(this.btnEditReference);
            this.Controls.Add(this.btnRemoveReference);
            this.Controls.Add(this.btnAddReference);
            this.Controls.Add(this.txtAddress);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.txtKeyword);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.cbAuthor);
            this.Controls.Add(this.cbBookTitle);
            this.Controls.Add(this.btnCancle);
            this.Controls.Add(this.bntSave);
            this.Controls.Add(this.txtDescription);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txtSentence);
            this.Controls.Add(this.label1);
            this.Name = "frmSentence";
            this.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.Text = "ثبت ارجاع";
            ((System.ComponentModel.ISupportInitialize)(this.grdReferences)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        private ComboBox cbBookTitle;
        private ComboBox cbAuthor;
        private TextBox txtKeyword;
        private Label label6;
        private TextBox txtAddress;
        private Label label4;
        private Button btnAddReference;
        private Button btnRemoveReference;
        private Button btnEditReference;
        private ImageList imageList1;
        private DataGridView grdReferences;
        private DataGridViewTextBoxColumn BookTitle;
        private DataGridViewTextBoxColumn Description;
        private DataGridViewTextBoxColumn ReferenceId;
    }
}

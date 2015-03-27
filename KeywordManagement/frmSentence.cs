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
    public partial class frmSentence : Form
    {
        private readonly IList<SearchResult> _referenceList = new List<SearchResult>();

        public frmSentence(FormMode formMode)
        {
            this.InitializeComponent();
            this.formMode = formMode;
            grdReferences.AutoGenerateColumns = false;
            using (KeywordManagementContext keywordManagementContext = new KeywordManagementContext())
            {
                cbBookTitle.AutoCompleteCustomSource.AddRange(keywordManagementContext.Books.Select(book => book.Title).ToArray());
                cbAuthor.Text = keywordManagementContext.Authors.Where(author => author.FullName.Contains("علامه")).FirstOrDefault().FullName;
            }

        }
        public frmSentence(Keyword keyword, FormMode formMode)
            : this(formMode)
        {
            if (keyword == null)
                throw new ArgumentNullException("مقدار کلمه واژه نباید خالی باشد");
            this.keyword = keyword;
            this.txtKeyword.Text = keyword.Content;
            this.txtSentence.Focus();
        }
        public frmSentence(Sentence sentence, Keyword keyword, FormMode formMode)
            : this(keyword, formMode)
        {
            this.sentence = sentence;
            this.txtSentence.Text = sentence.Content;
            this.txtDescription.Text = sentence.Description;
            grdReferences.DataSource = _referenceList = sentence.References.Select(reference => new SearchResult(reference)).ToList();
            this.txtAddress.Focus();
        }
        private void bntSave_Click(object sender, EventArgs e)
        {
            Utils.DoWithWait(this, delegate
            {
                using (KeywordManagementContext keywordManagementContext = new KeywordManagementContext())
                {
                    switch (this.formMode)
                    {
                        case FormMode.Create:
                            {
                                keywordManagementContext.Keywords.Attach(this.keyword);
                                Sentence newSentence = new Sentence
                                {
                                    Content = this.txtSentence.Text,
                                    Description = this.txtDescription.Text
                                };
                                foreach (var searchResult in _referenceList)
                                {
                                    Reference reference = new Reference()
                                    {
                                        ReferenceId = searchResult.ReferenceId,
                                        Book = Book.CreateNewBook(searchResult.BookTitle, searchResult.Author0_FullName),
                                        Description = searchResult.Description,
                                        PageNumber = searchResult.PageNumber,
                                        Sentence = newSentence
                                    };
                                    keywordManagementContext.Books.Attach(reference.Book);                                        
                                    newSentence.References.Add(reference);
                                    newSentence.Description = txtDescription.Text;
                                }
                                this.keyword.Sentences.Add(newSentence);
                                keywordManagementContext.SaveChanges();
                                break;
                            }
                        case FormMode.Update:
                            {
                                keywordManagementContext.Sentences.Attach(this.sentence);
                                foreach (var searchResult in _referenceList)
                                {
                                    var theReference = sentence.References.FirstOrDefault(reference => reference.ReferenceId == searchResult.ReferenceId);
                                    if (theReference == null)
                                    {
                                        theReference = Reference.CreateNewReference(searchResult.BookTitle,
                                            searchResult.Author0_FullName, searchResult.Description);
                                        sentence.References.Add(theReference);
                                        theReference.Sentence = sentence;
                                    }
                                    else
                                    {
                                        var theBook =
                                            keywordManagementContext.Books.FirstOrDefault(
                                                book => book.Title == searchResult.BookTitle);
                                        Author theAuthor;
                                        if (theBook == null)
                                        {
                                            if (
                                                (theAuthor =
                                                    keywordManagementContext.Authors.FirstOrDefault(
                                                        (Author author) =>
                                                            author.FullName == searchResult.Author0_FullName)) == null)
                                            {
                                                theAuthor = new Author
                                                {
                                                    FullName = searchResult.Author0_FullName
                                                };
                                            }
                                            theBook = new Book
                                            {
                                                Title = searchResult.BookTitle
                                            };
                                            theAuthor.Books.Add(theBook);
                                            theBook.Authors.Add(theAuthor);
                                        }
                                        theReference.Book = theBook;
                                        theBook.References.Add(theReference);
                                        theReference.Description = searchResult.Description;
                                        theReference.PageNumber = searchResult.PageNumber;
                                        this.sentence.Content = this.txtSentence.Text;
                                        this.sentence.Description = txtDescription.Text;
                                    }
                                }
                                keywordManagementContext.SaveChanges();
                                break;
                            }
                    }
                }
            });
            base.Close();
        }

        private void btnCancle_Click(object sender, EventArgs e)
        {
            base.Close();
        }

        private void grdReferences_SelectionChanged(object sender, EventArgs e)
        {
            if (grdReferences.SelectedRows.Count == 0)
                return;            
            txtAddress.Text = grdReferences.SelectedRows[0].Cells["Description"].Value.ToString();
            cbBookTitle.Text = grdReferences.SelectedRows[0].Cells["BookTitle"].Value.ToString();
        }

        private void btnAddReference_Click(object sender, EventArgs e)
        {
            var address = this.txtAddress.Text;
            var bookTitile = cbBookTitle.Text;
            var authorName = cbAuthor.Text;
            if (String.IsNullOrEmpty(bookTitile) || String.IsNullOrEmpty(address))
            {
                MessageBox.Show("لطفا آدرس ارجاع و نام کتاب را وارد نمایید", "خطا در ثبت ارجاع");
                return;
            }
                
            Utils.DoWithWait(this, () =>
            {
                Reference reference = Reference.CreateNewReference(bookTitile, authorName, address);
                _referenceList.Add(new SearchResult(reference));

                grdReferences.DataSource = _referenceList.ToList();
                cbBookTitle.Text = "";
                txtAddress.Text = "";
            });
            cbBookTitle.Focus();
        }

        private void btnEditReference_Click(object sender, EventArgs e)
        {
            if (grdReferences.SelectedRows.Count == 0)
            {
                MessageBox.Show("لطفا یک ارجاع انتخاب نمایید", "خطا در ویرایش ارجاع");
                return;
            }
            var bookTitile = cbBookTitle.Text;
            var authorName = cbAuthor.Text;
            var address = txtAddress.Text;

            int? referenceId = (int?)grdReferences.SelectedRows[0].Cells["ReferenceId"].Value;
            SearchResult searchResult = referenceId.HasValue ? _referenceList.First(search => search.ReferenceId == referenceId) : _referenceList[grdReferences.SelectedRows[0].Index];

            searchResult.BookTitle = bookTitile;
            searchResult.Author0_FullName = authorName;
            searchResult.Description = address;

            grdReferences.DataSource = _referenceList.ToList();
        }
    }
}

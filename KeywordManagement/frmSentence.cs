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
    public partial class frmSentence: Form
    {
        public frmSentence(FormMode formMode)
        {
            this.InitializeComponent();
            this.formMode = formMode;
            using (KeywordManagementContext keywordManagementContext = new KeywordManagementContext()){
                cbBookTitle.AutoCompleteCustomSource.AddRange(keywordManagementContext.Books.Select(book => book.Title).ToArray());
                cbAuthor.AutoCompleteCustomSource.AddRange(keywordManagementContext.Authors.Select(author => author.FullName).ToArray());
            }
            
        }
        public frmSentence(Keyword keyword, FormMode formMode)
            : this(formMode)
        {
            this.keyword = keyword;
        }
        public frmSentence(Sentence sentence, FormMode formMode)
            : this(formMode)
        {
            this.sentence = sentence;
            this.txtSentence.Text = sentence.Content;
            this.txtSentence.Enabled = false;
        }
        private void bntSave_Click(object sender, EventArgs e)
        {
            var bookTitile = cbBookTitle.Text;
            var authorName = cbAuthor.Text;
            if (String.IsNullOrEmpty(txtSentence.Text) || String.IsNullOrEmpty(bookTitile))
                return;
            Utils.DoWithWait(this, delegate
            {
                using (KeywordManagementContext keywordManagementContext = new KeywordManagementContext())
                {
                    switch (this.formMode)
                    {
                        case FormMode.Create:
                            {
                                keywordManagementContext.Keywords.Attach(this.keyword);
                                Book theBook = keywordManagementContext.Books.FirstOrDefault((Book book) => book.Title == bookTitile);
                                if (theBook == null)
                                {
                                    Author theAuthor;
                                    if ((theAuthor = keywordManagementContext.Authors.FirstOrDefault((Author author) => author.FullName == authorName)) == null)
                                    {
                                        theAuthor = new Author
                                        {
                                            FullName = authorName
                                        };
                                    }
                                    theBook = new Book
                                    {
                                        Title = bookTitile
                                    };
                                    theAuthor.Books.Add(theBook);
                                    theBook.Authors.Add(theAuthor);
                                }
                                Sentence sentence = new Sentence
                                {
                                    Content = this.txtSentence.Text
                                };
                                Reference item = new Reference
                                {
                                    Description = this.txtDescription.Text,
                                    PageNumber = this.txtPageNo.Text,
                                    Sentence = sentence,
                                    Book = theBook
                                };
                                sentence.References.Add(item);
                                this.keyword.Sentences.Add(sentence);
                                keywordManagementContext.SaveChanges();
                                break;
                            }
                        case FormMode.Update:
                            {
                                keywordManagementContext.Sentences.Attach(this.sentence);
                                Book theBook = keywordManagementContext.Books.FirstOrDefault((Book book) => book.Title == bookTitile);
                                if (theBook == null)
                                {
                                    Author theAuthor;
                                    if ((theAuthor = keywordManagementContext.Authors.FirstOrDefault((Author author) => author.FullName == authorName)) == null)
                                    {
                                        theAuthor = new Author
                                        {
                                            FullName = authorName
                                        };
                                    }
                                    theBook = new Book
                                    {
                                        Title = bookTitile
                                    };
                                    theAuthor.Books.Add(theBook);
                                    theBook.Authors.Add(theAuthor);
                                }
                                Reference item = new Reference
                                {
                                    Description = this.txtDescription.Text,
                                    PageNumber = this.txtPageNo.Text,
                                    Sentence = this.sentence,
                                    Book = theBook
                                };
                                this.sentence.References.Add(item);
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
    }
}

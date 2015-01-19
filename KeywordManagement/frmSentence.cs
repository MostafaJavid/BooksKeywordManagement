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
            this.textBox1.Text = sentence.Content;
            this.textBox1.Enabled = false;
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
                                Book theBook = keywordManagementContext.Books.FirstOrDefault((Book book) => book.Title == this.txtBookTitle.Text);
                                if (theBook == null)
                                {
                                    Author theAuthor;
                                    if ((theAuthor = keywordManagementContext.Authors.FirstOrDefault((Author author) => author.FullName == this.txtAuthorName.Text)) == null)
                                    {
                                        theAuthor = new Author
                                        {
                                            FullName = this.txtAuthorName.Text
                                        };
                                    }
                                    theBook = new Book
                                    {
                                        Title = this.txtBookTitle.Text
                                    };
                                    theAuthor.Books.Add(theBook);
                                    theBook.Authors.Add(theAuthor);
                                }
                                Sentence sentence = new Sentence
                                {
                                    Content = this.textBox1.Text
                                };
                                Reference item = new Reference
                                {
                                    Description = this.textBox5.Text,
                                    PageNumber = this.textBox4.Text,
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
                                Book theBook = keywordManagementContext.Books.FirstOrDefault((Book book) => book.Title == this.txtBookTitle.Text);
                                if (theBook == null)
                                {
                                    Author theAuthor;
                                    if ((theAuthor = keywordManagementContext.Authors.FirstOrDefault((Author author) => author.FullName == this.txtAuthorName.Text)) == null)
                                    {
                                        theAuthor = new Author
                                        {
                                            FullName = this.txtAuthorName.Text
                                        };
                                    }
                                    theBook = new Book
                                    {
                                        Title = this.txtBookTitle.Text
                                    };
                                    theAuthor.Books.Add(theBook);
                                    theBook.Authors.Add(theAuthor);
                                }
                                Reference item = new Reference
                                {
                                    Description = this.textBox5.Text,
                                    PageNumber = this.textBox4.Text,
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
    }
}

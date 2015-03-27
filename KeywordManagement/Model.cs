using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.Entity;
using System.ComponentModel.DataAnnotations;

namespace KeywordManagement
{
    public class Keyword
    {
        public Keyword()
        {
            this.Sentences = new List<Sentence>();
            this.Childs = new List<Keyword>();
        }
        public int KeywordId { get; set; }
        [Required]
        public string Content { get; set; }

        public Keyword Parent { get; set; }

        public virtual List<Sentence> Sentences { get; set; }

        public virtual List<Keyword> Childs { get; set; }

    }

    public class Sentence
    {
        public Sentence()
        {
            this.References = new List<Reference>();
        }
        public int SentenceId { get; set; }
        [Required]
        public string Content { get; set; }
        public string Description { get; set; }
        public virtual Keyword Keyword { get; set; }
        public virtual List<Reference> References { get; set; }
    }

    public class Reference
    {
        public int ReferenceId { get; set; }
        public string PageNumber { get; set; }
        public string Description { get; set; }

        public int SentenceId { get; set; }
        public virtual Sentence Sentence { get; set; }
        public int BookId { get; set; }
        public virtual Book Book { get; set; }

        public static Reference CreateNewReference(String bookTitle, String authorName, String address)
        {
            Reference reference;
                
                reference = new Reference
                {
                    Description = address,
                    Book = Book.CreateNewBook(bookTitle, authorName)
                };
            return reference;
        }
    }

    public class Book
    {
        public Book()
        {
            this.Authors = new List<Author>();
            this.References = new List<Reference>();
        }
        public int BookId { get; set; }
        [Required]
        public string Title { get; set; }
        public string PublicationYear { get; set; }
        public string Publisher { get; set; }
        public string Description { get; set; }
        public string PublishNumber { get; set; }
        
        public virtual List<Reference> References { get; set; }
        public virtual List<Author> Authors { get; set; }

        public static Book CreateNewBook(String bookTitle, String authorName, Reference reference = null)
        {
            Book theBook;
            using (var keywordManagementContext = new KeywordManagementContext())
            {
                theBook = keywordManagementContext.Books.Include("Authors").FirstOrDefault((Book book) => book.Title == bookTitle);
                Author theAuthor;
                if (theBook == null)
                {
                    if (
                        (theAuthor =
                            keywordManagementContext.Authors.FirstOrDefault(
                                (Author author) => author.FullName == authorName)) == null)
                    {
                        theAuthor = new Author
                        {
                            FullName = authorName
                        };
                    }
                    theBook = new Book
                    {
                        Title = bookTitle
                    };
                    theAuthor.Books.Add(theBook);
                    theBook.Authors.Add(theAuthor);
                }
                if (reference != null)
                {
                    theBook.References.Add(reference);                    
                }
            }
            return theBook;
        }
    }

    public class Author
    {
        public Author()
        {
            Books = new List<Book>();
        }

        public int AuthorId { get; set; }
        [Required]
        public string FullName { get; set; }
        public string Description { get; set; }

        public virtual List<Book> Books { get; set; }
    }

    //public class Publisher
    //{
    //    public int PublisherId { get; set; }
    //    public string Title { get; set; }

    //    public virtual List<Book> Books { get; set; }
    //}

    public class KeywordManagementContext : DbContext
    {
        public KeywordManagementContext()
        {

        }
        public DbSet<Keyword> Keywords { get; set; }
        public DbSet<Sentence> Sentences { get; set; }
        public DbSet<Reference> References { get; set; }
        public DbSet<Book> Books { get; set; }
        public DbSet<Author> Authors { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<Keyword>()
                   .HasMany<Sentence>(k => k.Sentences)
                   .WithRequired(s => s.Keyword)
                   .Map(cs =>
                   {
                       cs.MapKey("KeywordRefId");
                   });

            modelBuilder.Entity<Book>()
                   .HasMany<Author>(k => k.Authors)
                   .WithMany(a => a.Books)
                   .Map(cs =>
                   {
                       cs.MapLeftKey("BookRefId");
                       cs.MapRightKey("AuthorRefId");
                       cs.ToTable("BookAuthor");
                   });
        }
        
    }
}

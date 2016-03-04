using System.Data.Entity;

namespace KeywordFullTextSearch.Domain
{
    public class BookContext: DbContext
    {
        public BookContext()
            : base("name=bookArchiveContext")
        {
//            Database.SetInitializer<BookContext>(null);
        }

        public DbSet<Book> Books { get; set; }
        public DbSet<Paragraph> Paragraphs { get; set; }


    }
}
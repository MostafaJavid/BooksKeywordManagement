using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace KeywordManagement
{
    public class SearchResult
    {
        public string PageNumber { get; set; }
        public string BookTitle { get; set; }
        public string BookPublicationYear { get; set; }
        public string BookPublisher { get; set; }
        public string Author0_FullName { get; set; }
        public string Author1_FullName { get; set; }
        public string Description { get; set; }
        public string BookPublishNumber { get; set; }
        public int BookId { get; set; }
        public int ReferenceId { get; set; }

        public SearchResult()
        {

        }

        public SearchResult(Book book)
            :this()
        {
            if (book != null)
            {
                this.BookId = book.BookId;
                this.BookTitle = book.Title;
                this.BookPublicationYear = book.PublicationYear;
                this.BookPublisher = book.Publisher;
                this.BookPublishNumber = book.PublishNumber;
                if (book.Authors != null && book.Authors.Count > 0)
                {
                    this.Author0_FullName = book.Authors[0].FullName;
                    if (book.Authors.Count > 1)
                    {
                        this.Author1_FullName = book.Authors[1].FullName;
                    }
                }
            }
        }

        public SearchResult(Reference reference)
            :this(reference.Book)
        {
            this.PageNumber = reference.PageNumber;
            this.Description = reference.Description;
            this.ReferenceId = reference.ReferenceId;
        }
    }

}

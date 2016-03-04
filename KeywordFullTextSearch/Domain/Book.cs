using System.Collections;
using System.Collections.Generic;

namespace KeywordFullTextSearch.Domain
{
    public class Book
    {
        public Book()
        {
            Paragraphs= new List<Paragraph>();
        }
        public long ID { get; set; }
        public string Name { get; set; }
        public IList<Paragraph> Paragraphs{ get; set; }

    }
}
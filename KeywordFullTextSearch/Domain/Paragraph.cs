using System;
using System.Data.SqlTypes;

namespace KeywordFullTextSearch.Domain
{
    public class Paragraph
    {
        public long ID { get; set; }
        public long PageId { get; set; }
        public int PageNo { get; set; }
        public int ParagraphNo { get; set; }
        public string Entry { get; set; }
    }
}
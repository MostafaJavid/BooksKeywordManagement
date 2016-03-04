using System;
using System.Collections;
using System.Collections.Generic;
using System.Data.SqlTypes;

namespace KeywordFullTextSearch.Domain
{
    public class Page
    {
        public Page()
        {
        }
        public long ID { get; set; }
        public long BookId { get; set; }
        public Book Book { get; set; }
        public int PageNo { get; set; }
        public string Entry { get; set; }
    }
}
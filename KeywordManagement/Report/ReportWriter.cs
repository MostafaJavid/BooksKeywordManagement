using System;
using System.Collections;
using System.Linq;
using System.Collections.Generic;
using System.Windows.Forms;
using Novacode;

namespace KeywordManagement.Report
{
    public class ReportWriter
    {
        private TreeView _treeView;
        private DataGridView _grdReferences;
        private DataGridView _grdSentences;
        private ReportType _reportType;
        private bool _hirarchically;

        public ReportWriter(TreeView resultTreeView, DataGridView grdSentences, DataGridView grdReferences,
            ReportType reportType, bool hirarchically)
        {
            _treeView = resultTreeView;
            _grdReferences = grdReferences;
            _grdSentences = grdSentences;
            _reportType = reportType;
            _hirarchically = hirarchically;
        }

        public bool TransformToDocx(DocX doc, ReportType reportType, bool hirarchically)
        {
            _reportType = reportType;
            _hirarchically = hirarchically;
            return TransformToDocx(doc);
        }

        public bool TransformToDocx(DocX doc)
        {
            switch (_reportType)
            {
                case ReportType.Keyword:
                    KeywordReport(doc, _hirarchically);
                    break;
                case ReportType.References:
                    referenceReport(doc, _hirarchically);
                    break;
                case ReportType.Sentenctes:
                    sentenceReport(doc, _hirarchically);
                    break;
            }
            // Insert a paragrpah:
            Paragraph insertParagraph = doc.InsertParagraph("");
            insertParagraph.Direction = Direction.RightToLeft;

            // Save to the output directory:
            doc.Save();

            return false;
        }

        private void sentenceReport(DocX doc, bool hirarchically)
        {
            var sentences = _grdSentences.DataSource as IList<Sentence>;
            var keywords = new Dictionary<int, Keyword>();
            if (sentences == null) return;
            if (hirarchically)
            {
                using (var db = new KeywordManagementContext())
                {
                    foreach (var sentence in sentences)
                    {
                        Keyword keyword = null;
                        db.Sentences.Attach(sentence);
                        var innerSentence = new Sentence()
                        {
                            SentenceId = sentence.SentenceId,
                            Content = sentence.Content
                        };
                        innerSentence.References.AddRange(sentence.References
                                                                  .Select(reference => new Reference()
                                                                  {
                                                                      Book = reference.Book, 
                                                                      Description = reference.Description
                                                                  }));
                        if (keywords.TryGetValue(sentence.Keyword.KeywordId, out keyword))
                        {
                            keyword.Sentences.Add(innerSentence);
                        }
                        else
                        {
                            keyword = new Keyword()
                            {
                                KeywordId = sentence.Keyword.KeywordId,
                                Content = sentence.Keyword.Content
                            };
                            keyword.Sentences.Add(innerSentence);
                            keywords.Add(keyword.KeywordId, keyword);
                        }
                    }                    
                }
                WirteKeywords(doc, keywords);
            }
            else
            {
                sentences.ToList().ForEach(sentence => createParagraph(doc, sentence.Content + "\r\n"));
            }
        }

        private void referenceReport(DocX doc, bool hirarchically)
        {
            var searchResults = _grdReferences.DataSource as IList<SearchResult>;
            var keywords = new Dictionary<int, Keyword>();
            if (searchResults == null) return;
            if (hirarchically)
            {
                foreach (var searchResult in searchResults)
                {
                    Keyword keyword = null;
                    var sentence = new Sentence()
                    {
                        SentenceId = searchResult.Sentence.SentenceId,
                        Content = searchResult.Sentence.Content
                    };
                    var reference = new Reference()
                    {
                        ReferenceId = searchResult.ReferenceId,
                        Book = new Book()
                        {
                            BookId = searchResult.BookId,
                            Title = searchResult.BookTitle
                        },
                        Description = searchResult.Description
                    };
                    sentence.References.Add(reference);
                    if (keywords.TryGetValue(searchResult.Sentence.Keyword.KeywordId, out keyword))
                    {                        
                        keyword.Sentences.Add(sentence);
                    }
                    else
                    {
                        keyword = new Keyword()
                        {
                            KeywordId = searchResult.Sentence.Keyword.KeywordId,
                            Content = searchResult.Sentence.Keyword.Content
                        };                      
                        keyword.Sentences.Add(sentence);
                        keywords.Add(keyword.KeywordId, keyword);
                    }
                }
                WirteKeywords(doc, keywords);
            }
            else
            {
                searchResults.ToList().ForEach(searchResult => createParagraph(doc, searchResult.BookTitle + "\t" + searchResult.Description + "\r\n"));
            }
        }

        private void WirteKeywords(DocX doc, Dictionary<int, Keyword> keywords)
        {
            using (var db = new KeywordManagementContext())
            {
                foreach (var keyword in keywords.Values)
                {
                    createParagraph(doc, keyword.Content, isBold: true);
                    foreach (var sentence in keyword.Sentences)
                    {
                        createParagraph(doc, "\r\n\t" + sentence.Content, isBold: true);
                        foreach (var reference in sentence.References)
                        {
                            createParagraph(doc, "\r\n\t\t" + reference.Book.Title + "\t" + reference.Description);
                        }
                    }
                }
            }
        }

        private void KeywordReport(DocX doc, bool hirarchically)
        {
            if (hirarchically)
            {
                foreach (var keyword in from TreeNode node in _treeView.Nodes[0].Nodes where (node.IsSelected || (node.Parent != null && node.Parent.IsSelected)) && (node.Tag != null || node.Tag is Keyword) select node.Tag as Keyword)
                {
                    using (var db = new KeywordManagementContext())
                    {
                        db.Keywords.Attach(keyword);
                        createParagraph(doc, keyword.Content, isBold: true);
                        foreach (Sentence sentence in keyword.Sentences)
                        {
                            createParagraph(doc, "\r\n\t" + sentence.Content, isBold: true);
                            foreach (Reference reference in sentence.References)
                            {
                                createParagraph(doc, "\r\n\t\t" + reference.Book.Title + "\t" + reference.Description);
                            }
                        }
                    }
                }
            }
            else
            {
                foreach (var keyword in from TreeNode node in _treeView.Nodes[0].Nodes where node.Tag != null || node.Tag is Keyword select node.Tag as Keyword)
                {
                    createParagraph(doc, keyword.Content);
                }                
            }
        }

        private Paragraph createParagraph(DocX doc, String content, Direction direction = Direction.RightToLeft, bool isBold = false)
        {
            Paragraph insertParagraph = doc.InsertParagraph(content);
            insertParagraph.Direction = direction;
            if (isBold)
            {
                insertParagraph.Bold();
            }
            return insertParagraph;
        }
    }
}
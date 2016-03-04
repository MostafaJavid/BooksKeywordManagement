CREATE FULLTEXT CATALOG ArcBookCat AS DEFAULT;
GO
CREATE FULLTEXT INDEX ON Paragraphs
(
    entry                         --Full-text index column name 
        --TYPE COLUMN  file_type   --Name of column that contains file type information
        Language 1025                 --1025 is the LCID for Arabic
)
KEY INDEX [PK_dbo.Paragraphs] ON ArcBookCat --Unique index
WITH CHANGE_TRACKING AUTO            --Population type;
GO

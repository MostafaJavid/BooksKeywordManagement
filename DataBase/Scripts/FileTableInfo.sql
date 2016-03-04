SELECT DB_NAME(database_id), non_transacted_access, non_transacted_access_desc, directory_name
    FROM sys.database_filestream_options;
GO

select * from sys.fulltext_document_types
-- =========================================
-- Create FileTable template
-- =========================================
USE Archive
GO

CREATE TABLE books AS FILETABLE
  WITH
  (
    FILETABLE_DIRECTORY = 'Docs',
    FILETABLE_COLLATE_FILENAME = database_default,
	FILETABLE_STREAMID_UNIQUE_CONSTRAINT_NAME=UQ_stream_id
  )
GO




DECLARE @FileTableRoot varchar(1000);
SELECT @FileTableRoot = FileTableRootPath('dbo.Books');
print @FileTableRoot
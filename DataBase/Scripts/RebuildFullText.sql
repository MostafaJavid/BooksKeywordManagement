USE Archive
GO
-- ALTER FULLTEXT CATALOG ArchBooksFTCat REBUILD
GO

declare @FTCatalogName nvarchar(250)
set @FTCatalogName = 'ArchBooksFTCat'
 
SELECT
cat.name AS [Name],
cat.fulltext_catalog_id AS [ID],
CAST(FULLTEXTCATALOGPROPERTY(cat.name,'AccentSensitivity') AS bit) AS [IsAccentSensitive],
CAST(cat.is_default AS bit) AS [IsDefault],
dp.name AS [Owner],
FULLTEXTCATALOGPROPERTY(cat.name,'LogSize') AS [ErrorLogSize],
FULLTEXTCATALOGPROPERTY(cat.name,'IndexSize') AS [FullTextIndexSize (MB)],
FULLTEXTCATALOGPROPERTY(cat.name,'ItemCount') AS [ItemCount]
,(SELECT CASE FULLTEXTCATALOGPROPERTY(cat.name,'PopulateStatus')
        WHEN 0 THEN 'Idle'
        WHEN 1 THEN 'Full Population In Progress'
        WHEN 2 THEN 'Paused'
        WHEN 3 THEN 'Throttled'
        WHEN 4 THEN 'Recovering'
        WHEN 5 THEN 'Shutdown'
        WHEN 6 THEN 'Incremental Population In Progress'
        WHEN 7 THEN 'Building Index'
        WHEN 8 THEN 'Disk Full.  Paused'
        WHEN 9 THEN 'Change Tracking' END) AS PopulateStatus
FROM
sys.fulltext_catalogs AS cat
LEFT OUTER JOIN sys.filegroups AS fg ON cat.data_space_id = fg.data_space_id
LEFT OUTER JOIN sys.database_principals AS dp ON cat.principal_id=dp.principal_id
WHERE
(cat.name=@FTCatalogName)
GO
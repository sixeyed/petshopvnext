USE [master]

DECLARE @spid smallint
DECLARE @sql varchar(4000)

DECLARE crsr CURSOR FAST_FORWARD FOR
	SELECT spid FROM sysprocesses p INNER JOIN sysdatabases d ON d.[name] = 'MSPetShop4Profile' AND p.dbid = d.dbid

OPEN crsr
FETCH NEXT FROM crsr INTO @spid

WHILE @@FETCH_STATUS != -1
BEGIN
	SET @sql = 'KILL ' + CAST(@spid AS varchar)
	EXEC(@sql)
	FETCH NEXT FROM crsr INTO @spid
END

CLOSE crsr
DEALLOCATE crsr

DROP DATABASE [MSPetShop4Profile]
USE [master]
IF  EXISTS (SELECT * FROM master.dbo.syslogins WHERE name = N'mspetshop')
EXEC master.dbo.sp_droplogin @loginame = N'mspetshop'
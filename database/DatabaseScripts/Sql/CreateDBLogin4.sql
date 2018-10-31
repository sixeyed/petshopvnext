USE [MSPetShop4Services]

if not exists (select * from master.dbo.syslogins where loginname = N'mspetshop')
BEGIN
	exec sp_addlogin 'mspetshop' ,'pass@word1', 'MSPetShop4Services'
END

exec sp_grantdbaccess 'mspetshop'

exec sp_addrolemember 'db_owner', 'mspetshop'
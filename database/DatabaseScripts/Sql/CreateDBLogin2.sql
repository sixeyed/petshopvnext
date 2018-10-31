USE [MSPetShop4Orders]

if not exists (select * from master.dbo.syslogins where loginname = N'mspetshop')
BEGIN
	exec sp_addlogin 'mspetshop' ,'pass@word1', 'MSPetShop4Orders'
END

exec sp_grantdbaccess 'mspetshop'

exec sp_addrolemember 'db_owner', 'mspetshop'
@Echo Off
cls

REM ***************************************************************************
REM **
REM **        Name: UninstallDatabases
REM **        Desc: SQL Server Database Uninstaller for Pet Shop 4 Application.
REM **
REM **        Date: 10/24/2005
REM **
REM **************************************************************************/

@Echo.
@Echo *******************************************************************************
@Echo *                                                                             *
@Echo * Pet Shop 4 Database Uninstall Script                                        *
@Echo *                                                                             *
@Echo *                                                                             *
@Echo * This script will delete Pet Shop 4 databases                                *
@Echo *                                                                             *
@Echo * Modify this script to reflect the way you connect to the SQL Server         *
@Echo * as well as if location of the .NET 2.0 runtime on your computer             *
@Echo * is different from C:\WINDOWS\Microsoft.NET\Framework\v2.0.50727.            *
@Echo *                                                                             *
@Echo * If you wish to cancel, press [CTRL]-C to terminate the batch job.           *
@Echo *                                                                             *
@Echo *******************************************************************************
@Echo. 
pause

@Echo.
@Echo.
@Echo *******************************************************************************
@Echo * Uninstalling Databases...                                                   *
@Echo *******************************************************************************
@Echo. 

C:\WINDOWS\Microsoft.NET\Framework\v2.0.50727\aspnet_regsql -S localhost -E -R all -Q -d MSPetShop4Services
osql -E -i Sql/DropDatabase1.sql
osql -E -i Sql/DropDatabase2.sql
osql -E -i Sql/DropDatabase3.sql
osql -E -i Sql/DropDatabase4.sql
osql -E -i Sql/DropDBLogin.sql

@Echo.
@Echo.
@Echo *******************************************************************************
@Echo *                                                                             *
@Echo * Databases Uninstalled                                                       *
@Echo *                                                                             *
@Echo *******************************************************************************
@Echo.
pause
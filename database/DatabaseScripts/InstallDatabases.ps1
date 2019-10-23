
Invoke-SqlCmd -InputFile Sql/CreateDatabase1.sql
Invoke-SqlCmd -InputFile Sql/CreateDatabase2.sql
Invoke-SqlCmd -InputFile Sql/CreateDatabase3.sql
C:\WINDOWS\Microsoft.NET\Framework\v4.0.30319\aspnet_regsql -S localhost -E -A all -d MSPetShop4Services

Invoke-SqlCmd -InputFile Sql/CreateDBLogin1.sql
Invoke-SqlCmd -InputFile Sql/CreateDBLogin2.sql
Invoke-SqlCmd -InputFile Sql/CreateDBLogin3.sql
Invoke-SqlCmd -InputFile Sql/CreateDBLogin4.sql

Invoke-SqlCmd -InputFile Sql/CreateTables1.sql
Invoke-SqlCmd -InputFile Sql/CreateTables2.sql
Invoke-SqlCmd -InputFile Sql/CreateTables3.sql

Invoke-SqlCmd -InputFile Sql/LoadTables1.sql

C:\WINDOWS\Microsoft.NET\Framework\v4.0.30319\aspnet_regsql -S localhost -E -d MSPetShop4 -ed
C:\WINDOWS\Microsoft.NET\Framework\v4.0.30319\aspnet_regsql -S localhost -E -d MSPetShop4 -t Item -et
C:\WINDOWS\Microsoft.NET\Framework\v4.0.30319\aspnet_regsql -S localhost -E -d MSPetShop4 -t Product -et
C:\WINDOWS\Microsoft.NET\Framework\v4.0.30319\aspnet_regsql -S localhost -E -d MSPetShop4 -t Category -et

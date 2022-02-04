# .net simple project showing how to use EF Core CRUD operations

-> package installation
dotnet add package Microsoft.EntityFrameworkCore
dotnet add package Microsoft.EntityFrameworkCore.SqlServer
dotnet add package Microsoft.EntityFrameworkCore.Design
dotnet add package Microsoft.EntityFrameworkCore.Tools


-> Create migration:
dotnet ef migrations add primeiraMigracao

-> Creating scripts based on migration
dotnet ef migrations script -o .\Data\ScriptPrimeiraMigracao.sql

-> Creating scripts with idepotence
dotnet ef migrations script -o .\Data\ScriptIdepotente.sql -i

-> Applying migration on DB
dotnet ef database update

-> Remove last executed migration and remove its files
dotnet ef migrations remove
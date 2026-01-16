# videogame-catalogue-api
 
# Install below packages after clone this application

dotnet add package Microsoft.EntityFrameworkCore

dotnet add package Microsoft.EntityFrameworkCore.SqlServer

dotnet add package Microsoft.EntityFrameworkCore.Tools

Install-Package Microsoft.EntityFrameworkCore.InMemory

Install-Package Microsoft.AspNetCore.Mvc

# Create Table in SQL Server and change server name in appsettings.json
 Create Table VideoGames (
 
 Id uniqueidentifier NOT NULL DEFAULT NEWID() PRIMARY KEY,
 
 Title Nvarchar(Max) Not Null,
 
 Platform Nvarchar(Max),
 
 Genre Nvarchar(Max),
 
 ReleaseDate datetime 
 
 )





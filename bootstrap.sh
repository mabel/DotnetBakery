#!/bin/bash

dotnet new sln
dotnet new mvc -o app
dotnet new nunit -o tests
dotnet sln add app/app.csproj
dotnet sln add tests/tests.csproj
cd tests
dotnet add reference ../app/app.csproj
cd ../app
mkdir Data
dotnet add package Microsoft.EntityFrameworkCore.Design
dotnet add package Microsoft.EntityFrameworkCore.Sqlite

#dotnet tool install --global dotnet-ef
#dotnet ef migrations add InitialCreate
#dotnet ef database update

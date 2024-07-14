# .NET API with Postgres DB

Quick project with the code base for a .NET json API with Postgres database.

Source:

<a href="https://learn.microsoft.com/fr-fr/aspnet/core/tutorials/first-web-api?view=aspnetcore-8.0&tabs=visual-studio-code">.NET Web api controller guide</a>

## Create the project

```bash
dotnet new webapi --use-controllers -o <api_name>
cd <api_name>
dotnet add package Microsoft.EntityFrameworkCore.InMemory
code -r ../TodoApi
```

## Installation

With docker :
```bash
docker compose up -d
```

Manual install :
```bash
dotnet restore
dotnet run
```

## How to

### Server

Build:

```bash
dotnet build
```

Run the server :

```bash
dotnet run
```

### Env variable

Env variable are required for the `appsettings.json` file :
For example : 
```json
{
  "ConnectionStrings": {
    "DefaultConnection": "Server=localhost;Port=5431;Database=default_db;;Username={DB_USERNAME};Password={DB_PASSWORD}"
  }
}
```

You must set them in the `.env` file similary to the `.env.example`.

### Postgres

#### Add dependencies :

```bash
dotnet add package Npgsql.EntityFrameworkCore.PostgreSQL
dotnet add package Microsoft.EntityFrameworkCore.Tools
dotnet add package Microsoft.EntityFrameworkCore.Design
```

#### Configure DB connection :

```json
"ConnectionStrings": {
  "DefaultConnection": "Server=<ServerName>;Port=<PortNumber>;Database=<Your_Database>;;Username=<Your_Username>;Password=<Your_Password>"
}
```

#### Migrations:

Install dotnet-ef

```bash
dotnet tool install --global dotnet-ef
```

then run

```bash
dotnet ef migrations add <nameForYourMigration>
```

To update the DB from the migration files :

```bash
dotnet ef database update
```

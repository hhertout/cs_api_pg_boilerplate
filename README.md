# .NET learn

## Postgres

Add dependencies : 

```bash
dotnet add package Npgsql.EntityFrameworkCore.PostgreSQL
dotnet add package Microsoft.EntityFrameworkCore.Tools
dotnet add package Microsoft.EntityFrameworkCore.Design
```

Configure DB connection : 

```json
"ConnectionStrings": {
  "DefaultConnection": "Server=<ServerName>;Port=<PortNumber>;Database=<Your_Database>;;Username=<Your_Username>;Password=<Your_Password>"
}
```

Migrations:

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
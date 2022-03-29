#https://docs.microsoft.com/en-us/ef/core/cli/dotnet
#https://www.entityframeworktutorial.net/
#https://docs.microsoft.com/en-us/ef/core/cli/dotnet#dotnet-ef-dbcontext-scaffold

################################## Database First ######################### .NET Core CLI: 


--Instalar cmd
dotnet tool install --global dotnet-ef

-- Obtener el modelo 
dotnet ef dbcontext scaffold "Host=psql-scharff-dev-server.postgres.database.azure.com;Database=db_courier;Ssl Mode=Require;Username=dev_courier@psql-scharff-dev-server;Password=d3vc0ur13r" Npgsql.EntityFrameworkCore.PostgreSQL -o DbModel --context-dir DbContexts -c SharffDbContext

--Obtener modelo con tablas seleccionadas
dotnet ef dbcontext scaffold "Host=psql-scharff-dev-server.postgres.database.azure.com;Database=db_courier;Ssl Mode=Require;Username=dev_courier@psql-scharff-dev-server;Password=d3vc0ur13r" Npgsql.EntityFrameworkCore.PostgreSQL -o DbModel -t PgStatStatement -t tbl2 -t tbl3 -f  


################################## Code First ######################### .NET Core CLI: 

--Crear migración inicial
dotnet ef migrations add InitialCreate --context SharffDbContext --output-dir Migrations/PostGresMigrations

--Crear migración en sprints
dotnet ef migrations add Sprint1_1 --context SharffDbContext --output-dir Migrations/PostGresMigrations

--Eliminar ultima migración
dotnet ef migrations remove --context SharffDbContext

--Para aplicar las migraciones a una base de datos
dotnet ef database update --context SharffDbContext --connection <connection_string> 
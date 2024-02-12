# Readme

## Setup local environment (API+DB)
`docker-compose up --build --force-recreate -d`

`docker comose down`

`dotnet tool install --global dotnet-ef --version 6.*`

`dotnet ef migrations add InitialCreate -p ./Data/BankApp.Data.csproj -s ./API/BankApp.API.csproj`

`dotnet ef database update  -p ./Data/BankApp.Data.csproj -s ./API/BankApp.API.csproj`
## Setup database
Connect to database and run manually the script of init-db.sql
(PRO OPTIONs:
- https://stackoverflow.com/questions/69941444/how-to-have-docker-compose-init-a-sql-server-database)
- https://www.softwaredeveloper.blog/initialize-mssql-in-docker-container

## Save database
docker commit & docker push
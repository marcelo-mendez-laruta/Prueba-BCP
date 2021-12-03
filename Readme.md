# Examen de Desarrollo - BCP

```docker run --name bcpDB -e "ACCEPT_EULA=Y" -e "SA_PASSWORD=bcp12345" -p 1433:1433 -d mcr.microsoft.com/mssql/server:2019-latest```

Data Source=host.docker.internal,1433;Initial Catalog=MyDB;User ID=MyUser;Password=MyPassword
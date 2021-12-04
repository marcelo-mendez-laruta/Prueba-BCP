# Examen de Desarrollo - BCP

## Base de Datos

Para el siguiente ejemplo se utilizo un contenedor Docker con los siguientes comandos:

````bash
docker pull mcr.microsoft.com/mssql/server
docker run --name bcpDB -e "ACCEPT_EULA=Y" -e "SA_PASSWORD=bcp12345" -p 1433:1433 -d mcr.microsoft.com/mssql/server:2019-latest
````

En el archivo  **appsettings.json** de **Examen_Desarrollo_BCP.Server** se agrego las siguientes líneas de código para configurar la conexión:

````json
"ConnectionStrings": {
    "BCP_Connection": "Data Source=host.docker.internal,1433;Initial Catalog=bcpdb;User ID=sa;Password=bcp12345"
  }
````

Modificar las conexiones según se requiera.

### Tablas

En **BCP_DB** se encuentra la carpeta **Tablas** con los scripts necesarios para crear todas las tablas, tomar en cuenta que la base de datos tiene que existir previamente.

### Procedimientos Almacenados

Al igual que las tablas los scripts para la creación de los procedimientos almacenados se encuentran en **BCP_DB** en la carpeta **Stored Procedure**.

### Publicación 

En **BCP_DB** se encuentra el archivo **BCP_DB.publish.xml** con el cual se podrá publicar el proyecto con las tablas, procedimiento almacenado y la creación de las monedas.

Una vez publicado el proyecto **BCP_DB** se puede poner en funcionamiento el servidor y el cliente de la solución.

## Sobre el proyecto y sus alcances

Si bien se trato de cumplir todos los objetivos de la prueba, en **Transferencia** entre cuentas, no se tomo en cuenta el tipo de moneda, al momento de realizar el **abono** y el **debito**. Por este motivo tampoco se pudo documentar apropiadamente el proyecto. Sin embargo es fácilmente subsanable. Debido al factor tiempo y para poder entregar un software funcional en el tiempo establecido se asumió el cambio de moneda.

## Agradecimiento

Agradecerle por el tiempo que dispone para evaluarme, espero pueda darme la oportunidad de trabajar en **Banco de Crédito de Bolivia S.A.** y demostrar que puedo aportar y mejorar mis conocimientos con su equipo de trabajo.



Marcelo Carlos Mendez Laruta

**Full Stack Developer**
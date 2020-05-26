# EjemplosEntityFramework

## ¿Cómo iniciar un proyecto?

Este es un ejemplo para realizar un proyecto simple con NetCore y Entity Framework en la Versón 3.1.4 a partir de la metodología CODE-FIRST, usando el Motor de base de datos MYSQL - MariaDb, El código tiene las líneas necesarias para conectar a SQLSERVER

### 1) Instalar NetCore SDK

Para instalar NetCore es necesario instalar el SDK(Disponible para todas las plataformas) <https://dotnet.microsoft.com/download>

### 2) Instalar la herramienta de Entity Framework (Nuestro ORM)

El **ORM** (Object-Relational-Mapping) es el encargado de administrar nuestra base de datos

En terminal de comandos se debe ejecutar el siguiente comando

`dotnet tool install --global dotnet-ef`

Este comando Instala las herramientas Entity Framework de manera global

### 3) Inicializar el proyecto que vayamos a utilizar

--- Por escribir

### 4) Agregar las bibliotecas para EF Core

Para aplicar los comandos de instalación debemos estar en el directorio del proyecto

Para hacer la conexión a MySQL

`dotnet add package Microsoft.EntityFrameworkCore.Design`

Esta librería permite hacer la operación de los comandos de migración y actualización instalados con la herramienta global del paso 2

`dotnet add package Mysql.Data.EntityFrameworkCore`

Esta es la librería encargada de hacer la conexión con MySQL

### 5) Restablecer las librerías de Netcore

`dotnet restore`

Este comando nos permite revisar que todas nuestras bibliotecas se encuentren funcionales

### 6) Realizar toda la lógica del proyecto

En esta parte se escribirá el código de nuestra aplicación

Modelos, Configuración de Entidades, DBContext

### 7) Crear la base de datos

Antes de aplicar cualquier comando para generar la base de datos automáticamente, es necesario crear de manera manual la base de datos y una tabla que tiene como requerimiento de Entity Framework para funcionar los pasos se enlistan a continuación:

1. Generar en **mysql** la base de datos con el nombre deseado
2. Crear una tabla con el nombre **"\_\_efmigrationshistory"**
3. Anexar la columna **MigrationId** con el tipo varchar(150) NOT NULL
4. Anexar la columna **ProductVersion** - varchar(32) NOT NUL

### 8) Hacer la primera migración

Las migraciones son automatizaciones de código generadas a partir de nuestros modelos y nuestro DBContext, este paso no hace ejecuciones o cambios en la BD solo es el preámbulo.

Para hacer una migración

`dotnet-ef migrations add **nombremigracion**`

Si por alguna razón cometimos una error y se desea eliminar la migración se debe usar el comando

`dotnet-ef migrations remove **nombremigracion**`

### 9) Aplicar la migración a la base de datos

Para que los cambios se apliquen de manera física en la base de datos necesitamos usar el comando

`dotnet ef database update`

### 10) Para actualizar la base de datos a una migración en especifico

Si deseamos aplicar o regresar a una versión que teníamos previamente lo realizamos con el comando

`dotnet ef database update NombreDeLaMigracion`

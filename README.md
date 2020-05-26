# EjemplosEntityFramework

## ¿Cómo iniciar un proyecto?

Este es un ejemplo para realizar un proyecto simple con NetCore y Entity Framework en la Versón 3.1.4 a partir de la metodologia CODE-FIRST, usando el Motor de base de datos MYSQL - MariaDb, El código tiene las lineas neserarias para conectar a SQLSERVER

### 1) Instalar NetCore SDK

Para instalar NetCore es nesesario instalar el SDK(Disponible para todas las plataformas)<https://dotnet.microsoft.com/download>

### 2) Instalar la herramienta de Entity Framework (Nuestro ORM)

El ORM (Object-Relational-Mapping) es el encargado de administar nuestra base de datos

    1. En terminal de comandos se debe ejecutar el siguente comando
    `dotnet tool install --global dotnet-ef`
    Este comando Instala las herramientas Entity Framework de manera global

### 3) Inicializar el proyecto que vayamos a utilizar

    --- Por escribir

### 4) Agregar las bibliotecas para EF Core

    Para aplicar los comandos de intalación debemos estar en el directorio del proyecto

    Para hacer la conexión a MySQL
    `dotnet add package Microsoft.EntityFrameworkCore.Design`
    Esta librería permite hacer la operacion de los comandos de migración y actualización instalados con  la herramienta global del paso 2

    `dotnet add package Mysql.Data.EntityFrameworkCore`
    Esta es la libreria encargada de hacer la conexión con MySQL

### 5) Restablecer las librerias de Netcore

    `dotnet restore`
    Este comando nos permite revisar que todas nuestras bibliotecas se encuentren funcionales

### 6) Realizar toda la lógica del proyecto

    En esta parte se escribirá el codigo de nuettra applicación
    Modelos, Configuración de Entidades, DBContext

### 7) Crear la base de datos

Antes de aplicar cualquer comando para generar la base de datos automaticamente, es necesario crar de manera manual la base de datos y una tabla que tiene como requerimiento de Entity Framework para funcionar los pasos se enlistan a continuación: 1. Generar en **mysql** la base de datos con el nombre deseado 2. Crear una tabla con el nombre **"\_\_efmigrationshistory"** 3. Anexar la columna **MigrationId** con el tipo varchar(150) NOT NULL 4. Anexar la columna **ProductVersion** - varchar(32) NOT NUL

### 8) Hacer la primera migración

    Las migraciones son automatizaciones de codigo generadas a partir de nuestros modelos y nuestro DBContext, este paso no hace ejecuciones o cambios en la BD solo es el preambulo.

    Para hacer una migación
    	`dotnet-ef migrations add **nombremigracion**`

    Si por alguna razón cometimos una error y se desea eliminar la migración se debe usar el comando
        `dotnet-ef migrations remove **nombremigracion**`

### 9) Aplicar la migración a la base de datos

    Para que los cambios se apliquen de manera fisica en la base de datos necesitamos usar el comando
    	`dotnet ef database update`

### 10) Para actualizar la base de datos a una migracion en especifico

    Si deseamos  aplicar o regresar a una versión que teniamos previamente lo realizamos con el comando
        `dotnet ef database update NombreDeLaMigracion`

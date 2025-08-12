CREATE DATABASE TiendaKamil;

USE TiendaKamil;

CREATE TABLE CATALOGO_PUESTOS (
    ID_Puesto INT IDENTITY(1,1) PRIMARY KEY,
    Descripcion_Puesto VARCHAR(100) NOT NULL
);

CREATE TABLE CATALOGO_CENTROS (
    ID_Centro INT IDENTITY(1,1) PRIMARY KEY,
    Nombre_Centro VARCHAR(100) NOT NULL,
    Ciudad VARCHAR(50) NOT NULL
);


CREATE TABLE EMPLEADOS (
    ID_Empleado INT IDENTITY(1,1) PRIMARY KEY,
    Nombre VARCHAR(50) NOT NULL,
    Apellido_Paterno VARCHAR(50) NOT NULL,
    Apellido_Materno VARCHAR(50) NOT NULL,
    Fecha_Nacimiento DATE NOT NULL,
    RFC VARCHAR(13) NOT NULL UNIQUE,
    Centro_Trabajo INT NOT NULL,
    ID_Puesto INT NOT NULL,
    Es_Directivo BIT NOT NULL DEFAULT 0,
    
    -- Restricciones de clave foránea
    CONSTRAINT FK_Empleados_Puesto 
        FOREIGN KEY (ID_Puesto) REFERENCES CATALOGO_PUESTOS(ID_Puesto),
    CONSTRAINT FK_Empleados_Centro 
        FOREIGN KEY (Centro_Trabajo) REFERENCES CATALOGO_CENTROS(ID_Centro)
);

CREATE TABLE DIRECTIVOS (
    ID_Empleado INT PRIMARY KEY,
    Centro_Supervisado INT NOT NULL,
    Prestacion_Combustible BIT NOT NULL DEFAULT 0,
    
    -- Restricción de clave foránea hacia EMPLEADOS
    CONSTRAINT FK_Directivos_Empleado 
        FOREIGN KEY (ID_Empleado) REFERENCES EMPLEADOS(ID_Empleado)
        ON DELETE CASCADE,
    
    -- Restricción de clave foránea hacia CATALOGO_CENTROS
    CONSTRAINT FK_Directivos_Centro 
        FOREIGN KEY (Centro_Supervisado) REFERENCES CATALOGO_CENTROS(ID_Centro)
        ON DELETE CASCADE,
);

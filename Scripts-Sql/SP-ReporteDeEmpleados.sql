CREATE PROCEDURE sp_ReporteEmpleados
AS
BEGIN
    SELECT 
        e.ID_Empleado AS NumeroEmpleado,
        CONCAT(e.Nombre, ' ', e.Apellido_Paterno, ' ', e.Apellido_Materno) AS NombreCompleto,
        e.Fecha_Nacimiento AS FechaNacimiento,
        e.RFC,
        c.Nombre_Centro AS Centro,
        p.Descripcion_Puesto AS Puesto,
        CASE 
            WHEN E.Es_Directivo = 1 THEN CAST(1 AS BIT)
            ELSE CAST(0 AS BIT)
        END AS EsDirector
    FROM 
        EMPLEADOS e 
        JOIN CATALOGO_CENTROS c ON e.Centro_Trabajo = c.ID_Centro
        JOIN CATALOGO_PUESTOS p ON e.ID_Puesto = p.ID_Puesto;
END;
namespace EmployeeManagment.Models
{
    public class Empleado
    {
        public int IdEmpleado { get; set; }
        public string Nombre { get; set; } = null!;
        public string ApellidoPaterno { get; set; } = null!;
        public string ApellidoMaterno { get; set; } = null!;
        public DateOnly FechaNacimiento { get; set; }
        public string RFC { get; set; } = null!;
        public int CentroTrabajo { get; set; }
        public int IdPuesto { get; set; }
        public bool EsDirectivo { get; set; }

        // Propiedades de navegación
        public CatalogoPuesto? Puesto { get; set; }
        public CatalogoCentro? CentroTrabajoNavigation { get; set; }
        public Directivo? Directivo { get; set; }
    }
}

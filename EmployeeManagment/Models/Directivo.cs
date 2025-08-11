namespace EmployeeManagment.Models
{
    public class Directivo
    {
        public int IdEmpleado { get; set; }
        public int CentroSupervisado { get; set; }
        public bool PrestacionCombustible { get; set; }

        // Propiedades de navegación
        public Empleado? Empleado { get; set; }
        public CatalogoCentro? CentroSupervisadoNavigation { get; set; }
    }
}

namespace EmployeeManagment.Models
{
    public class CatalogoCentro
    {
        public int IdCentro { get; set; }
        public string NombreCentro { get; set; } = null!;
        public string Ciudad { get; set; } = null!;

        public ICollection<Empleado> Empleados { get; set; } = [];
        public ICollection<Directivo> DirectivosSupervisores { get; set; } = [];
    }
}

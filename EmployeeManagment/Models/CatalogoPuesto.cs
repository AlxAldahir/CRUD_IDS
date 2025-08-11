namespace EmployeeManagment.Models
{
    public class CatalogoPuesto
    {
        public int IdPuesto { get; set; }
        public string DescripcionPuesto { get; set; } = null!;

        public ICollection<Empleado> Empleados { get; set; } = [];
    }
}

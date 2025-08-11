namespace EmployeeManagment.Models.ViewModels
{
    // Keyless view model mapped to the stored procedure sp_ReporteEmpleados
    public class ReporteEmpleadosViewModel
    {
        public int NumeroEmpleado { get; set; }
        public string NombreCompleto { get; set; } = string.Empty;
        public DateOnly FechaNacimiento { get; set; }
        public string RFC { get; set; } = string.Empty;
        public string Centro { get; set; } = string.Empty;
        public string Puesto { get; set; } = string.Empty;
        public bool EsDirector { get; set; }
    }
}

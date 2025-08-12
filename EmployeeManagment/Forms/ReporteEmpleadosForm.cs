using EmployeeManagment.Models.ViewModels;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel;

namespace EmployeeManagment.Forms
{
    public partial class ReporteEmpleadosForm : Form
    {
        private BindingSource binding = new BindingSource();

        public ReporteEmpleadosForm()
        {
            InitializeComponent();

            if (!IsDesignMode())
            {
                Load += async (s, e) => await LoadDataAsync();
            }

            btnRefrescar.Click += async (s, e) => await LoadDataAsync();
        }

        private bool IsDesignMode()
        {
            return LicenseManager.UsageMode == LicenseUsageMode.Designtime || DesignMode;
        }

        /*Este es el método que realiza la consulta de los datos del reporte*/
        private async System.Threading.Tasks.Task LoadDataAsync()
        {
            using var ctx = new ApplicationDbContext();

            // Ejecuta el SP y mapea al ViewModel
            var list = await ctx.Set<ReporteEmpleadosViewModel>()
                .FromSqlRaw("EXEC sp_ReporteEmpleados")
                .ToListAsync();
            binding.DataSource = list;
            grid.DataSource = binding;
        }
    }
}

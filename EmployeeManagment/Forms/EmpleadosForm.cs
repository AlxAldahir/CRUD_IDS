using System;
using System.ComponentModel;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using System.Windows.Forms;
using EmployeeManagment.Models;

namespace EmployeeManagment.Forms
{
    public partial class EmpleadosForm : Form
    {
        private BindingSource binding = new BindingSource();

        public EmpleadosForm()
        {
            InitializeComponent();

            if (!IsDesignMode())
            {
                Load += async (s, e) => await LoadDataAsync();
            }

            btnAdd.Click += async (s, e) => await AddAsync();
            btnEdit.Click += async (s, e) => await EditAsync();
            btnDelete.Click += async (s, e) => await DeleteAsync();
        }

        private bool IsDesignMode()
        {
            return LicenseManager.UsageMode == LicenseUsageMode.Designtime || DesignMode;
        }

        private async System.Threading.Tasks.Task LoadDataAsync()
        {
            using var ctx = new ApplicationDbContext();
            var data = await ctx.Empleados
                .Include(e => e.Puesto)
                .Include(e => e.CentroTrabajoNavigation)
                .OrderBy(e => e.IdEmpleado)
                .ToListAsync();
            binding.DataSource = data;
            grid.DataSource = binding;
        }

        private async System.Threading.Tasks.Task AddAsync()
        {
            using var dlg = new EmpleadoEditForm();
            if (dlg.ShowDialog(this) == DialogResult.OK)
                await LoadDataAsync();
        }

        private Empleado? Current => binding.Current as Empleado;

        private async System.Threading.Tasks.Task EditAsync()
        {
            if (Current == null) return;
            using var dlg = new EmpleadoEditForm(Current.IdEmpleado);
            if (dlg.ShowDialog(this) == DialogResult.OK)
                await LoadDataAsync();
        }

        private async System.Threading.Tasks.Task DeleteAsync()
        {
            if (Current == null) return;
            using var ctx = new ApplicationDbContext();
            var entity = await ctx.Empleados.FindAsync(Current.IdEmpleado);
            if (entity == null) return;
            ctx.Empleados.Remove(entity);
            await ctx.SaveChangesAsync();
            await LoadDataAsync();
        }
    }
}

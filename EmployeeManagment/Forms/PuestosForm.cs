using System.ComponentModel;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using System.Windows.Forms;
using EmployeeManagment.Models;

namespace EmployeeManagment.Forms
{
    public partial class PuestosForm : Form
    {
        private BindingSource binding = new BindingSource();

        public PuestosForm()
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
            var list = await ctx.CatalogoPuestos.OrderBy(p => p.IdPuesto).ToListAsync();
            binding.DataSource = list;
            grid.DataSource = binding;
        }

    private CatalogoPuesto? Current => binding.Current as CatalogoPuesto;

        private async System.Threading.Tasks.Task AddAsync()
        {
            using var ctx = new ApplicationDbContext();
            ctx.CatalogoPuestos.Add(new CatalogoPuesto { DescripcionPuesto = "Nuevo Puesto" });
            await ctx.SaveChangesAsync();
            await LoadDataAsync();
        }

        private async System.Threading.Tasks.Task EditAsync()
        {
            if (Current == null) return;
            using var ctx = new ApplicationDbContext();
            var entity = await ctx.CatalogoPuestos.FindAsync(Current.IdPuesto);
            if (entity == null) return;
            entity.DescripcionPuesto = entity.DescripcionPuesto + "*";
            await ctx.SaveChangesAsync();
            await LoadDataAsync();
        }

        private async System.Threading.Tasks.Task DeleteAsync()
        {
            if (Current == null) return;
            using var ctx = new ApplicationDbContext();
            var entity = await ctx.CatalogoPuestos.FindAsync(Current.IdPuesto);
            if (entity == null) return;
            ctx.CatalogoPuestos.Remove(entity);
            await ctx.SaveChangesAsync();
            await LoadDataAsync();
        }
    }
}

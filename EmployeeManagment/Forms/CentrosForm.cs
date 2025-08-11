using System.ComponentModel;
using EmployeeManagment.Models;
using Microsoft.EntityFrameworkCore;

namespace EmployeeManagment.Forms
{
    public partial class CentrosForm : Form
    {
        private BindingSource binding = new BindingSource();

        public CentrosForm()
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
            var list = await ctx.CatalogoCentros.OrderBy(c => c.IdCentro).ToListAsync();
            binding.DataSource = list;
            grid.DataSource = binding;
        }

        private CatalogoCentro? Current => binding.Current as CatalogoCentro;

        private async System.Threading.Tasks.Task AddAsync()
        {
            using var ctx = new ApplicationDbContext();
            ctx.CatalogoCentros.Add(new CatalogoCentro { NombreCentro = "Centro Nuevo", Ciudad = "CDMX" });
            await ctx.SaveChangesAsync();
            await LoadDataAsync();
        }

        private async System.Threading.Tasks.Task EditAsync()
        {
            if (Current == null) return;
            using var ctx = new ApplicationDbContext();
            var entity = await ctx.CatalogoCentros.FindAsync(Current.IdCentro);
            if (entity == null) return;
            entity.NombreCentro = entity.NombreCentro + "*";
            await ctx.SaveChangesAsync();
            await LoadDataAsync();
        }

    // Designer-generated InitializeComponent lives in CentrosForm.Designer.cs

        private async System.Threading.Tasks.Task DeleteAsync()
        {
            if (Current == null) return;
            using var ctx = new ApplicationDbContext();
            var entity = await ctx.CatalogoCentros.FindAsync(Current.IdCentro);
            if (entity == null) return;
            ctx.CatalogoCentros.Remove(entity);
            await ctx.SaveChangesAsync();
            await LoadDataAsync();
        }
    }
}

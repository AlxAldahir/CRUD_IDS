using System.Linq;
using System.Windows.Forms;
using EmployeeManagment.Models;
using Microsoft.EntityFrameworkCore;

namespace EmployeeManagment.Controls
{
    public class CentrosControl : UserControl
    {
        private DataGridView grid = new DataGridView { Dock = DockStyle.Fill, AutoGenerateColumns = false, ReadOnly = true, SelectionMode = DataGridViewSelectionMode.FullRowSelect };
        private BindingSource binding = new BindingSource();
    private ToolStrip tool = new ToolStrip { Dock = DockStyle.Top, ImageScalingSize = new Size(20, 20) };
        private ToolStripButton btnAdd = new ToolStripButton("Agregar");
        private ToolStripButton btnEdit = new ToolStripButton("Editar");
        private ToolStripButton btnDelete = new ToolStripButton("Eliminar");

        public CentrosControl()
        {
            Dock = DockStyle.Fill;
            tool.Items.AddRange(new ToolStripItem[] { btnAdd, btnEdit, btnDelete });
            tool.Height = 36;
            btnAdd.AutoSize = false; btnAdd.Height = 28; btnAdd.Width = 80;
            btnEdit.AutoSize = false; btnEdit.Height = 28; btnEdit.Width = 80;
            btnDelete.AutoSize = false; btnDelete.Height = 28; btnDelete.Width = 80;
            var panel = new Panel { Dock = DockStyle.Fill, Padding = new Padding(0, 4, 0, 0) };
            panel.Controls.Add(grid);
            Controls.Add(panel);
            Controls.Add(tool);

            grid.Columns.Add(new DataGridViewTextBoxColumn { DataPropertyName = nameof(CatalogoCentro.IdCentro), Visible = false });
            grid.Columns.Add(new DataGridViewTextBoxColumn { DataPropertyName = nameof(CatalogoCentro.NombreCentro), HeaderText = "Centro" });
            grid.Columns.Add(new DataGridViewTextBoxColumn { DataPropertyName = nameof(CatalogoCentro.Ciudad), HeaderText = "Ciudad" });

            Load += async (s, e) => await LoadDataAsync();
            btnAdd.Click += async (s, e) => await AddAsync();
            btnEdit.Click += async (s, e) => await EditAsync();
            btnDelete.Click += async (s, e) => await DeleteAsync();
        }

        private async System.Threading.Tasks.Task LoadDataAsync()
        {
            using var ctx = new ApplicationDbContext();
            binding.DataSource = await ctx.CatalogoCentros.OrderBy(c => c.IdCentro).ToListAsync();
            grid.DataSource = binding;
        }

        private CatalogoCentro? Current => binding.Current as CatalogoCentro;

        private async System.Threading.Tasks.Task AddAsync()
        {
            using var dlg = new Forms.CentroEditForm();
            if (dlg.ShowDialog(FindForm()) == DialogResult.OK)
                await LoadDataAsync();
        }

        private async System.Threading.Tasks.Task EditAsync()
        {
            if (Current == null) return;
            using var dlg = new Forms.CentroEditForm(Current.IdCentro);
            if (dlg.ShowDialog(FindForm()) == DialogResult.OK)
                await LoadDataAsync();
        }

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

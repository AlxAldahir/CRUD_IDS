using System.Linq;
using System.Windows.Forms;
using EmployeeManagment.Models;
using Microsoft.EntityFrameworkCore;

namespace EmployeeManagment.Controls
{
    public class PuestosControl : UserControl
    {
        private DataGridView grid = new DataGridView { Dock = DockStyle.Fill, AutoGenerateColumns = false, ReadOnly = true, SelectionMode = DataGridViewSelectionMode.FullRowSelect };
        private BindingSource binding = new BindingSource();
    private ToolStrip tool = new ToolStrip { Dock = DockStyle.Top, ImageScalingSize = new Size(20, 20) };
        private ToolStripButton btnAdd = new ToolStripButton("Agregar");
        private ToolStripButton btnEdit = new ToolStripButton("Editar");
        private ToolStripButton btnDelete = new ToolStripButton("Eliminar");

        public PuestosControl()
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

            grid.Columns.Add(new DataGridViewTextBoxColumn { DataPropertyName = nameof(CatalogoPuesto.IdPuesto), Visible = false });
            grid.Columns.Add(new DataGridViewTextBoxColumn { DataPropertyName = nameof(CatalogoPuesto.DescripcionPuesto), HeaderText = "Descripción" });

            Load += async (s, e) => await LoadDataAsync();
            btnAdd.Click += async (s, e) => await AddAsync();
            btnEdit.Click += async (s, e) => await EditAsync();
            btnDelete.Click += async (s, e) => await DeleteAsync();
        }

        private async System.Threading.Tasks.Task LoadDataAsync()
        {
            using var ctx = new ApplicationDbContext();
            binding.DataSource = await ctx.CatalogoPuestos.OrderBy(p => p.IdPuesto).ToListAsync();
            grid.DataSource = binding;
        }

        private CatalogoPuesto? Current => binding.Current as CatalogoPuesto;

        private async System.Threading.Tasks.Task AddAsync()
        {
            using var dlg = new Forms.PuestoEditForm();
            if (dlg.ShowDialog(FindForm()) == DialogResult.OK)
                await LoadDataAsync();
        }

        private async System.Threading.Tasks.Task EditAsync()
        {
            if (Current == null) return;
            using var dlg = new Forms.PuestoEditForm(Current.IdPuesto);
            if (dlg.ShowDialog(FindForm()) == DialogResult.OK)
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

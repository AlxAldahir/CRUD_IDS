using System;
using System.Linq;
using System.Windows.Forms;
using EmployeeManagment.Models;
using Microsoft.EntityFrameworkCore;

namespace EmployeeManagment.Controls
{
    public class EmpleadosControl : UserControl
    {
        private DataGridView grid = new DataGridView { Dock = DockStyle.Fill, AutoGenerateColumns = false, ReadOnly = true, SelectionMode = DataGridViewSelectionMode.FullRowSelect };
        private BindingSource binding = new BindingSource();
    private ToolStrip tool = new ToolStrip { Dock = DockStyle.Top, ImageScalingSize = new Size(20, 20) };
        private ToolStripButton btnAdd = new ToolStripButton("Agregar");
        private ToolStripButton btnEdit = new ToolStripButton("Editar");
        private ToolStripButton btnDelete = new ToolStripButton("Eliminar");

        public EmpleadosControl()
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

            // Columns
            grid.Columns.Add(new DataGridViewTextBoxColumn { DataPropertyName = nameof(Empleado.IdEmpleado), Visible = false });
            grid.Columns.Add(new DataGridViewTextBoxColumn { DataPropertyName = nameof(Empleado.Nombre), HeaderText = "Nombre" });
            grid.Columns.Add(new DataGridViewTextBoxColumn { DataPropertyName = nameof(Empleado.ApellidoPaterno), HeaderText = "Apellido Paterno" });
            grid.Columns.Add(new DataGridViewTextBoxColumn { DataPropertyName = nameof(Empleado.ApellidoMaterno), HeaderText = "Apellido Materno" });
            grid.Columns.Add(new DataGridViewTextBoxColumn { DataPropertyName = nameof(Empleado.RFC), HeaderText = "RFC" });
            grid.Columns.Add(new DataGridViewTextBoxColumn { DataPropertyName = nameof(Empleado.CentroTrabajoNavigation) + "." + nameof(CatalogoCentro.NombreCentro), HeaderText = "Centro" });
            grid.Columns.Add(new DataGridViewTextBoxColumn { DataPropertyName = nameof(Empleado.Puesto) + "." + nameof(CatalogoPuesto.DescripcionPuesto), HeaderText = "Puesto" });
            grid.Columns.Add(new DataGridViewCheckBoxColumn { DataPropertyName = nameof(Empleado.EsDirectivo), HeaderText = "¿Es Director?" });

            Load += async (s, e) => await LoadDataAsync();
            btnAdd.Click += async (s, e) => await AddAsync();
            btnEdit.Click += async (s, e) => await EditAsync();
            btnDelete.Click += async (s, e) => await DeleteAsync();
        }

        private async System.Threading.Tasks.Task LoadDataAsync()
        {
            using var ctx = new ApplicationDbContext();
            var data = await ctx.Empleados.Include(e => e.Puesto).Include(e => e.CentroTrabajoNavigation).OrderBy(e => e.IdEmpleado).ToListAsync();
            binding.DataSource = data;
            grid.DataSource = binding;
        }

        private Empleado? Current => binding.Current as Empleado;

        private async System.Threading.Tasks.Task AddAsync()
        {
            using var dlg = new Forms.EmpleadoEditForm();
            if (dlg.ShowDialog(FindForm()) == DialogResult.OK)
                await LoadDataAsync();
        }

        private async System.Threading.Tasks.Task EditAsync()
        {
            if (Current == null) return;
            using var dlg = new Forms.EmpleadoEditForm(Current.IdEmpleado);
            if (dlg.ShowDialog(FindForm()) == DialogResult.OK)
                await LoadDataAsync();
        }

        private async System.Threading.Tasks.Task DeleteAsync()
        {
            if (Current == null) return;
            if (MessageBox.Show("¿Eliminar empleado seleccionado?", "Confirmar", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) != DialogResult.Yes)
                return;
            using var ctx = new ApplicationDbContext();
            var entity = await ctx.Empleados.FindAsync(Current.IdEmpleado);
            if (entity == null) return;
            ctx.Empleados.Remove(entity);
            await ctx.SaveChangesAsync();
            await LoadDataAsync();
        }
    }
}

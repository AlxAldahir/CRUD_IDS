using System.Windows.Forms;
using EmployeeManagment.Models.ViewModels;
using Microsoft.EntityFrameworkCore;

namespace EmployeeManagment.Controls
{
    public class ReporteEmpleadosControl : UserControl
    {
        private DataGridView grid = new DataGridView { Dock = DockStyle.Fill, AutoGenerateColumns = false, ReadOnly = true, SelectionMode = DataGridViewSelectionMode.FullRowSelect };
        private BindingSource binding = new BindingSource();
    private ToolStrip tool = new ToolStrip { Dock = DockStyle.Top, ImageScalingSize = new Size(20, 20) };
        private ToolStripButton btnRefresh = new ToolStripButton("Refrescar");

        public ReporteEmpleadosControl()
        {
            Dock = DockStyle.Fill;
            tool.Items.Add(btnRefresh);
            tool.Height = 36;
            btnRefresh.AutoSize = false; btnRefresh.Height = 28; btnRefresh.Width = 90;
            var panel = new Panel { Dock = DockStyle.Fill, Padding = new Padding(0, 4, 0, 0) };
            panel.Controls.Add(grid);
            Controls.Add(panel);
            Controls.Add(tool);

            grid.Columns.Add(new DataGridViewTextBoxColumn { DataPropertyName = nameof(ReporteEmpleadosViewModel.NumeroEmpleado), HeaderText = "Numero de Empleado" });
            grid.Columns.Add(new DataGridViewTextBoxColumn { DataPropertyName = nameof(ReporteEmpleadosViewModel.NombreCompleto), HeaderText = "Nombre Completo" });
            grid.Columns.Add(new DataGridViewTextBoxColumn { DataPropertyName = nameof(ReporteEmpleadosViewModel.FechaNacimiento), HeaderText = "Fecha de Nacimiento" });
            grid.Columns.Add(new DataGridViewTextBoxColumn { DataPropertyName = nameof(ReporteEmpleadosViewModel.RFC), HeaderText = "RFC" });
            grid.Columns.Add(new DataGridViewTextBoxColumn { DataPropertyName = nameof(ReporteEmpleadosViewModel.Centro), HeaderText = "Centro" });
            grid.Columns.Add(new DataGridViewTextBoxColumn { DataPropertyName = nameof(ReporteEmpleadosViewModel.Puesto), HeaderText = "Puesto" });
            grid.Columns.Add(new DataGridViewCheckBoxColumn { DataPropertyName = nameof(ReporteEmpleadosViewModel.EsDirector), HeaderText = "¿Es Director?" });

            Load += async (s, e) => await LoadDataAsync();
            btnRefresh.Click += async (s, e) => await LoadDataAsync();
        }

        private async System.Threading.Tasks.Task LoadDataAsync()
        {
            using var ctx = new ApplicationDbContext();
            var list = await ctx.Set<ReporteEmpleadosViewModel>().FromSqlRaw("EXEC sp_ReporteEmpleados").ToListAsync();
            binding.DataSource = list;
            grid.DataSource = binding;
        }
    }
}

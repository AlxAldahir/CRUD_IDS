using System.Drawing;
using System.Windows.Forms;
using EmployeeManagment.Models.ViewModels;

namespace EmployeeManagment.Forms
{
    partial class ReporteEmpleadosForm
    {
        private System.ComponentModel.IContainer components = null;
        private DataGridView grid;
        private Button btnRefrescar;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null)) components.Dispose();
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            components = new System.ComponentModel.Container();
            grid = new DataGridView();
            btnRefrescar = new Button();
            ((System.ComponentModel.ISupportInitialize)grid).BeginInit();
            SuspendLayout();
            // 
            // btnRefrescar
            // 
            btnRefrescar.Text = "Refrescar";
            btnRefrescar.Dock = DockStyle.Top;
            btnRefrescar.Height = 40;
            // 
            // grid
            // 
            grid.Dock = DockStyle.Fill;
            grid.AutoGenerateColumns = false;
            grid.ReadOnly = true;
            grid.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            grid.MultiSelect = false;
            grid.Columns.Add(new DataGridViewTextBoxColumn { DataPropertyName = nameof(ReporteEmpleadosViewModel.NumeroEmpleado), HeaderText = "Numero de Empleado" });
            grid.Columns.Add(new DataGridViewTextBoxColumn { DataPropertyName = nameof(ReporteEmpleadosViewModel.NombreCompleto), HeaderText = "Nombre Completo" });
            grid.Columns.Add(new DataGridViewTextBoxColumn { DataPropertyName = nameof(ReporteEmpleadosViewModel.FechaNacimiento), HeaderText = "Fecha de Nacimiento" });
            grid.Columns.Add(new DataGridViewTextBoxColumn { DataPropertyName = nameof(ReporteEmpleadosViewModel.RFC), HeaderText = "RFC" });
            grid.Columns.Add(new DataGridViewTextBoxColumn { DataPropertyName = nameof(ReporteEmpleadosViewModel.Centro), HeaderText = "Centro" });
            grid.Columns.Add(new DataGridViewTextBoxColumn { DataPropertyName = nameof(ReporteEmpleadosViewModel.Puesto), HeaderText = "Puesto" });
            grid.Columns.Add(new DataGridViewCheckBoxColumn { DataPropertyName = nameof(ReporteEmpleadosViewModel.EsDirector), HeaderText = "¿Es Director?" });
            // 
            // ReporteEmpleadosForm
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1000, 600);
            Controls.Add(grid);
            Controls.Add(btnRefrescar);
            Name = "ReporteEmpleadosForm";
            Text = "Reporte de empleados";
            ((System.ComponentModel.ISupportInitialize)grid).EndInit();
            ResumeLayout(false);
        }
    }
}

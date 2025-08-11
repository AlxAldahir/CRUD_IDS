using EmployeeManagment.Models;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel;

namespace EmployeeManagment.Forms
{
    public partial class EmpleadoEditForm : Form
    {
        private readonly int? _empleadoId;
        public Empleado? Result { get; private set; }

        public EmpleadoEditForm(int? empleadoId = null)
        {
            _empleadoId = empleadoId;
            InitializeComponent();

            Text = empleadoId.HasValue ? "Editar Empleado" : "Nuevo Empleado";
            AcceptButton = btnGuardar;
            CancelButton = btnCancelar;

            // Evitar lógica de BD en modo diseñador
            if (!IsDesignMode())
            {
                Load += EmpleadoEditForm_Load;
            }
        }

        private bool IsDesignMode()
        {
            return LicenseManager.UsageMode == LicenseUsageMode.Designtime || DesignMode;
        }

        private async void EmpleadoEditForm_Load(object? sender, EventArgs e)
        {
            await ReloadCombosAsync();

            if (cboCentro.Items.Count == 0 || cboPuesto.Items.Count == 0)
            {
                MessageBox.Show("No hay Centros o Puestos registrados. Abre los catálogos para crearlos.", "Catálogos vacíos", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }

            if (_empleadoId.HasValue)
            {
                using var ctx = new ApplicationDbContext();
                var emp = await ctx.Empleados.FindAsync(_empleadoId.Value);
                if (emp != null)
                {
                    txtNombre.Text = emp.Nombre;
                    txtApellidoPaterno.Text = emp.ApellidoPaterno;
                    txtApellidoMaterno.Text = emp.ApellidoMaterno;
                    dtpNacimiento.Value = new DateTime(emp.FechaNacimiento.Year, emp.FechaNacimiento.Month, emp.FechaNacimiento.Day);
                    txtRFC.Text = emp.RFC;
                    cboCentro.SelectedValue = emp.CentroTrabajo;
                    cboPuesto.SelectedValue = emp.IdPuesto;
                    chkDirectivo.Checked = emp.EsDirectivo;
                }
            }
        }

        private async void btnGuardar_Click(object? sender, EventArgs e)
        {
            if (!ValidateInputs()) return;

            using var ctx = new ApplicationDbContext();
            Empleado entity;
            if (_empleadoId.HasValue)
            {
                entity = await ctx.Empleados.FindAsync(_empleadoId.Value) ?? new Empleado();
            }
            else
            {
                entity = new Empleado();
                ctx.Empleados.Add(entity);
            }

            entity.Nombre = txtNombre.Text.Trim();
            entity.ApellidoPaterno = txtApellidoPaterno.Text.Trim();
            entity.ApellidoMaterno = txtApellidoMaterno.Text.Trim();
            entity.FechaNacimiento = DateOnly.FromDateTime(dtpNacimiento.Value.Date);
            entity.RFC = txtRFC.Text.Trim().ToUpper();
            entity.CentroTrabajo = Convert.ToInt32(cboCentro.SelectedValue);
            entity.IdPuesto = Convert.ToInt32(cboPuesto.SelectedValue);
            entity.EsDirectivo = chkDirectivo.Checked;

            try
            {
                await ctx.SaveChangesAsync();
                Result = entity;
                DialogResult = DialogResult.OK;
                Close();
            }
            catch (DbUpdateException ex)
            {
                MessageBox.Show($"Error al guardar: {ex.GetBaseException().Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private async System.Threading.Tasks.Task ReloadCombosAsync()
        {
            using var ctx = new ApplicationDbContext();
            var centros = await ctx.CatalogoCentros.OrderBy(c => c.NombreCentro).ToListAsync();
            var puestos = await ctx.CatalogoPuestos.OrderBy(p => p.DescripcionPuesto).ToListAsync();

            cboCentro.DataSource = centros;
            cboCentro.DisplayMember = nameof(CatalogoCentro.NombreCentro);
            cboCentro.ValueMember = nameof(CatalogoCentro.IdCentro);

            cboPuesto.DataSource = puestos;
            cboPuesto.DisplayMember = nameof(CatalogoPuesto.DescripcionPuesto);
            cboPuesto.ValueMember = nameof(CatalogoPuesto.IdPuesto);
        }

        private bool ValidateInputs()
        {
            if (string.IsNullOrWhiteSpace(txtNombre.Text)) { MessageBox.Show("Nombre es requerido"); return false; }
            if (string.IsNullOrWhiteSpace(txtApellidoPaterno.Text)) { MessageBox.Show("Apellido Paterno es requerido"); return false; }
            if (string.IsNullOrWhiteSpace(txtApellidoMaterno.Text)) { MessageBox.Show("Apellido Materno es requerido"); return false; }
            if (string.IsNullOrWhiteSpace(txtRFC.Text) || txtRFC.Text.Trim().Length != 13) { MessageBox.Show("RFC debe tener 13 caracteres"); return false; }
            if (cboCentro.SelectedItem == null) { MessageBox.Show("Selecciona un Centro de Trabajo"); return false; }
            if (cboPuesto.SelectedItem == null) { MessageBox.Show("Selecciona un Puesto"); return false; }
            return true;
        }
    }
}

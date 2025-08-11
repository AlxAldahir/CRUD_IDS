using EmployeeManagment.Models;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel; // LicenseManager

namespace EmployeeManagment.Forms
{
    public partial class CentroEditForm : Form
    {
        private readonly int? _idCentro;
        public CatalogoCentro? Result { get; private set; }

        public CentroEditForm(int? idCentro = null)
        {
            _idCentro = idCentro;
            InitializeComponent();

            Text = idCentro.HasValue ? "Editar Centro" : "Nuevo Centro";
            AcceptButton = btnGuardar;
            CancelButton = btnCancelar;

            // Eventos gestionados por el diseñador; evitar doble suscripción

            // Avoid DB logic at design-time to keep Designer stable
            if (!IsDesignMode())
            {
                Load += CentroEditForm_Load;
            }
        }

        private bool IsDesignMode()
        {
            return LicenseManager.UsageMode == LicenseUsageMode.Designtime || DesignMode;
        }

        private async void CentroEditForm_Load(object? sender, EventArgs e)
        {
            if (_idCentro.HasValue)
            {
                using var ctx = new ApplicationDbContext();
                var c = await ctx.CatalogoCentros.FindAsync(_idCentro.Value);
                if (c != null)
                {
                    txtNombre.Text = c.NombreCentro;
                    txtCiudad.Text = c.Ciudad;
                }
            }
        }

        private async void btnGuardar_Click(object? sender, EventArgs e)
        {
            if (!ValidateInputs()) return;

            using var ctx = new ApplicationDbContext();
            CatalogoCentro entity;
            if (_idCentro.HasValue)
            {
                entity = await ctx.CatalogoCentros.FindAsync(_idCentro.Value) ?? new CatalogoCentro();
            }
            else
            {
                entity = new CatalogoCentro();
                ctx.CatalogoCentros.Add(entity);
            }
            entity.NombreCentro = txtNombre.Text.Trim();
            entity.Ciudad = txtCiudad.Text.Trim();
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

        private bool ValidateInputs()
        {
            if (string.IsNullOrWhiteSpace(txtNombre.Text))
            {
                MessageBox.Show("El nombre es requerido"); return false;
            }
            if (string.IsNullOrWhiteSpace(txtCiudad.Text))
            {
                MessageBox.Show("La ciudad es requerida"); return false;
            }
            return true;
        }
    }
}

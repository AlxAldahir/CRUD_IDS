using System;
using System.ComponentModel;
using System.Windows.Forms;
using EmployeeManagment.Models;
using Microsoft.EntityFrameworkCore;

namespace EmployeeManagment.Forms
{
    public partial class PuestoEditForm : Form
    {
        private readonly int? _idPuesto;
        public CatalogoPuesto? Result { get; private set; }

        public PuestoEditForm(int? idPuesto = null)
        {
            _idPuesto = idPuesto;
            InitializeComponent();

            Text = idPuesto.HasValue ? "Editar Puesto" : "Nuevo Puesto";
            AcceptButton = btnGuardar;
            CancelButton = btnCancelar;

            if (!IsDesignMode())
            {
                Load += PuestoEditForm_Load;
            }
        }

        private bool IsDesignMode()
        {
            return LicenseManager.UsageMode == LicenseUsageMode.Designtime || DesignMode;
        }

        private async void PuestoEditForm_Load(object? sender, EventArgs e)
        {
            if (_idPuesto.HasValue)
            {
                using var ctx = new ApplicationDbContext();
                var p = await ctx.CatalogoPuestos.FindAsync(_idPuesto.Value);
                if (p != null)
                {
                    txtDescripcion.Text = p.DescripcionPuesto;
                }
            }
        }

        private async void btnGuardar_Click(object? sender, EventArgs e)
        {
            if (!ValidateInputs()) return;
            using var ctx = new ApplicationDbContext();
            CatalogoPuesto entity;
            if (_idPuesto.HasValue)
            {
                entity = await ctx.CatalogoPuestos.FindAsync(_idPuesto.Value) ?? new CatalogoPuesto();
            }
            else
            {
                entity = new CatalogoPuesto();
                ctx.CatalogoPuestos.Add(entity);
            }
            entity.DescripcionPuesto = txtDescripcion.Text.Trim();
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
            if (string.IsNullOrWhiteSpace(txtDescripcion.Text))
            {
                MessageBox.Show("La descripción es requerida", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }
            return true;
        }
    }
}

namespace EmployeeManagment
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private async void Form1_Load(object sender, EventArgs e)
        {
            await VerificarConexionAsync();
        }

        private static async Task VerificarConexionAsync()
        {
            try
            {
                using var context = new ApplicationDbContext();
                var sePuedeConectar = await context.Database.CanConnectAsync();

                if (sePuedeConectar)
                {
                    MessageBox.Show(
                        "Se realizo la conexión a la base de datos 'TiendaKamil'",
                        "Éxito",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Information
                    );
                }
                else
                {
                    MessageBox.Show(
                        "No se pudo establecer conexión con la base de datos.",
                        "Error",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Error
                    );
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    $"Error al intentar conectar con la base de datos: {ex.Message}",
                    "Error",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error
                );
            }
        }

        private void empleadosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            LoadIntoContent(new Controls.EmpleadosControl());
        }

        private void puestosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            LoadIntoContent(new Controls.PuestosControl());
        }

        private void centrosTrabajoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            LoadIntoContent(new Controls.CentrosControl());
        }

        private void reporteEmpleadosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            LoadIntoContent(new Controls.ReporteEmpleadosControl());
        }

        private void LoadIntoContent(Control control)
        {
            panelContent.SuspendLayout();
            panelContent.Controls.Clear();
            control.Dock = DockStyle.Fill;
            panelContent.Controls.Add(control);
            panelContent.ResumeLayout();
        }
    }
}

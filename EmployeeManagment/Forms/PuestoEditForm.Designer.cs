using System.Windows.Forms;

namespace EmployeeManagment.Forms
{
    partial class PuestoEditForm
    {
        private System.ComponentModel.IContainer components = null;
        private TableLayoutPanel tableLayoutPanel1;
        private FlowLayoutPanel buttonsPanel;
        private Label lblDescripcion;
        private TextBox txtDescripcion;
        private Button btnGuardar;
        private Button btnCancelar;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
                components.Dispose();
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            components = new System.ComponentModel.Container();
            tableLayoutPanel1 = new TableLayoutPanel();
            buttonsPanel = new FlowLayoutPanel();
            lblDescripcion = new Label();
            txtDescripcion = new TextBox();
            btnGuardar = new Button();
            btnCancelar = new Button();

            SuspendLayout();

            // Form
            AutoScaleMode = AutoScaleMode.Font;
            StartPosition = FormStartPosition.CenterParent;
            FormBorderStyle = FormBorderStyle.FixedDialog;
            MaximizeBox = false;
            MinimizeBox = false;
            ClientSize = new System.Drawing.Size(420, 160);

            // TableLayoutPanel
            tableLayoutPanel1.Dock = DockStyle.Fill;
            tableLayoutPanel1.Padding = new Padding(10);
            tableLayoutPanel1.ColumnCount = 2;
            tableLayoutPanel1.RowCount = 1;
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 35F));
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 65F));
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Absolute, 34F));

            // Label
            lblDescripcion.Text = "Descripción";
            lblDescripcion.AutoSize = true;

            // TextBox
            txtDescripcion.Anchor = AnchorStyles.Left | AnchorStyles.Right;

            // Add to table
            tableLayoutPanel1.Controls.Add(lblDescripcion, 0, 0);
            tableLayoutPanel1.Controls.Add(txtDescripcion, 1, 0);

            // Buttons panel
            buttonsPanel.Dock = DockStyle.Bottom;
            buttonsPanel.FlowDirection = FlowDirection.RightToLeft;
            buttonsPanel.Padding = new Padding(10);
            buttonsPanel.Height = 48;

            // Buttons
            btnGuardar.Text = "Guardar"; btnGuardar.AutoSize = true; btnGuardar.Height = 30;
            btnCancelar.Text = "Cancelar"; btnCancelar.AutoSize = true; btnCancelar.Height = 30; btnCancelar.DialogResult = DialogResult.Cancel;
            this.btnGuardar.Click += new System.EventHandler(this.btnGuardar_Click);

            buttonsPanel.Controls.Add(btnCancelar);
            buttonsPanel.Controls.Add(btnGuardar);

            // Compose
            Controls.Add(tableLayoutPanel1);
            Controls.Add(buttonsPanel);

            ResumeLayout(false);
        }
    }
}

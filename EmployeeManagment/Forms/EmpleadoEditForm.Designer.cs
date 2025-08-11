using System.Windows.Forms;
using System.Drawing;

namespace EmployeeManagment.Forms
{
    partial class EmpleadoEditForm
    {
        private System.ComponentModel.IContainer components = null;
        private TableLayoutPanel tableLayoutPanel1;
        private FlowLayoutPanel buttonsPanel;
        private Label lblNombre;
        private Label lblApellidoPaterno;
        private Label lblApellidoMaterno;
        private Label lblFechaNac;
        private Label lblRFC;
        private Label lblCentro;
        private Label lblPuesto;

        // Controls referenced by code-behind
        private TextBox txtNombre;
        private TextBox txtApellidoPaterno;
        private TextBox txtApellidoMaterno;
        private DateTimePicker dtpNacimiento;
        private TextBox txtRFC;
        private ComboBox cboCentro;
        private ComboBox cboPuesto;
        private CheckBox chkDirectivo;
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
            lblNombre = new Label();
            lblApellidoPaterno = new Label();
            lblApellidoMaterno = new Label();
            lblFechaNac = new Label();
            lblRFC = new Label();
            lblCentro = new Label();
            lblPuesto = new Label();
            txtNombre = new TextBox();
            txtApellidoPaterno = new TextBox();
            txtApellidoMaterno = new TextBox();
            dtpNacimiento = new DateTimePicker();
            txtRFC = new TextBox();
            cboCentro = new ComboBox();
            cboPuesto = new ComboBox();
            chkDirectivo = new CheckBox();
            btnGuardar = new Button();
            btnCancelar = new Button();

            tableLayoutPanel1.SuspendLayout();
            buttonsPanel.SuspendLayout();
            SuspendLayout();

            // Form
            AutoScaleMode = AutoScaleMode.Font;
            StartPosition = FormStartPosition.CenterParent;
            FormBorderStyle = FormBorderStyle.FixedDialog;
            MaximizeBox = false;
            MinimizeBox = false;
            ClientSize = new System.Drawing.Size(520, 420);

            // TableLayoutPanel
            tableLayoutPanel1.Dock = DockStyle.Fill;
            tableLayoutPanel1.Padding = new Padding(10);
            tableLayoutPanel1.ColumnCount = 2;
            tableLayoutPanel1.RowCount = 8;
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 35F));
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 65F));
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Absolute, 34F));
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Absolute, 34F));
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Absolute, 34F));
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Absolute, 34F));
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Absolute, 34F));
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Absolute, 34F));
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Absolute, 34F));
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Absolute, 34F));

            // Labels
            lblNombre.Text = "Nombre"; lblNombre.AutoSize = true;
            lblApellidoPaterno.Text = "Apellido Paterno"; lblApellidoPaterno.AutoSize = true;
            lblApellidoMaterno.Text = "Apellido Materno"; lblApellidoMaterno.AutoSize = true;
            lblFechaNac.Text = "Fecha Nacimiento"; lblFechaNac.AutoSize = true;
            lblRFC.Text = "RFC"; lblRFC.AutoSize = true;
            lblCentro.Text = "Centro de Trabajo"; lblCentro.AutoSize = true;
            lblPuesto.Text = "Puesto"; lblPuesto.AutoSize = true;

            // Inputs
            txtNombre.Anchor = AnchorStyles.Left | AnchorStyles.Right;
            txtApellidoPaterno.Anchor = AnchorStyles.Left | AnchorStyles.Right;
            txtApellidoMaterno.Anchor = AnchorStyles.Left | AnchorStyles.Right;
            dtpNacimiento.Format = DateTimePickerFormat.Short; dtpNacimiento.Anchor = AnchorStyles.Left;
            txtRFC.Anchor = AnchorStyles.Left | AnchorStyles.Right;
            cboCentro.DropDownStyle = ComboBoxStyle.DropDownList; cboCentro.Anchor = AnchorStyles.Left | AnchorStyles.Right;
            cboPuesto.DropDownStyle = ComboBoxStyle.DropDownList; cboPuesto.Anchor = AnchorStyles.Left | AnchorStyles.Right;
            chkDirectivo.Text = "Es Directivo"; chkDirectivo.Anchor = AnchorStyles.Left;

            // Add to table (explicit row indices for Designer compatibility)
            tableLayoutPanel1.Controls.Add(lblNombre, 0, 0);
            tableLayoutPanel1.Controls.Add(txtNombre, 1, 0);
            tableLayoutPanel1.Controls.Add(lblApellidoPaterno, 0, 1);
            tableLayoutPanel1.Controls.Add(txtApellidoPaterno, 1, 1);
            tableLayoutPanel1.Controls.Add(lblApellidoMaterno, 0, 2);
            tableLayoutPanel1.Controls.Add(txtApellidoMaterno, 1, 2);
            tableLayoutPanel1.Controls.Add(lblFechaNac, 0, 3);
            tableLayoutPanel1.Controls.Add(dtpNacimiento, 1, 3);
            tableLayoutPanel1.Controls.Add(lblRFC, 0, 4);
            tableLayoutPanel1.Controls.Add(txtRFC, 1, 4);
            tableLayoutPanel1.Controls.Add(lblCentro, 0, 5);
            tableLayoutPanel1.Controls.Add(cboCentro, 1, 5);
            tableLayoutPanel1.Controls.Add(lblPuesto, 0, 6);
            tableLayoutPanel1.Controls.Add(cboPuesto, 1, 6);
            tableLayoutPanel1.Controls.Add(chkDirectivo, 1, 7);

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

            tableLayoutPanel1.ResumeLayout(false);
            tableLayoutPanel1.PerformLayout();
            buttonsPanel.ResumeLayout(false);
            buttonsPanel.PerformLayout();
            ResumeLayout(false);
        }
    }
}

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
            tableLayoutPanel1 = new TableLayoutPanel();
            lblNombre = new Label();
            txtNombre = new TextBox();
            lblApellidoPaterno = new Label();
            txtApellidoPaterno = new TextBox();
            lblApellidoMaterno = new Label();
            txtApellidoMaterno = new TextBox();
            lblFechaNac = new Label();
            dtpNacimiento = new DateTimePicker();
            lblRFC = new Label();
            txtRFC = new TextBox();
            lblCentro = new Label();
            cboCentro = new ComboBox();
            lblPuesto = new Label();
            cboPuesto = new ComboBox();
            chkDirectivo = new CheckBox();
            buttonsPanel = new FlowLayoutPanel();
            btnCancelar = new Button();
            btnGuardar = new Button();
            tableLayoutPanel1.SuspendLayout();
            buttonsPanel.SuspendLayout();
            SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            tableLayoutPanel1.ColumnCount = 2;
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 35F));
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 65F));
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
            tableLayoutPanel1.Dock = DockStyle.Fill;
            tableLayoutPanel1.Location = new Point(0, 0);
            tableLayoutPanel1.Name = "tableLayoutPanel1";
            tableLayoutPanel1.Padding = new Padding(10);
            tableLayoutPanel1.RowCount = 8;
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Absolute, 34F));
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Absolute, 34F));
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Absolute, 34F));
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Absolute, 34F));
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Absolute, 34F));
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Absolute, 34F));
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Absolute, 34F));
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Absolute, 34F));
            tableLayoutPanel1.Size = new Size(520, 372);
            tableLayoutPanel1.TabIndex = 0;
            // 
            // lblNombre
            // 
            lblNombre.AutoSize = true;
            lblNombre.Location = new Point(13, 10);
            lblNombre.Name = "lblNombre";
            lblNombre.Size = new Size(64, 20);
            lblNombre.TabIndex = 0;
            lblNombre.Text = "Nombre";
            // 
            // txtNombre
            // 
            txtNombre.Anchor = AnchorStyles.Left | AnchorStyles.Right;
            txtNombre.Location = new Point(188, 13);
            txtNombre.Name = "txtNombre";
            txtNombre.Size = new Size(319, 27);
            txtNombre.TabIndex = 1;
            // 
            // lblApellidoPaterno
            // 
            lblApellidoPaterno.AutoSize = true;
            lblApellidoPaterno.Location = new Point(13, 44);
            lblApellidoPaterno.Name = "lblApellidoPaterno";
            lblApellidoPaterno.Size = new Size(120, 20);
            lblApellidoPaterno.TabIndex = 2;
            lblApellidoPaterno.Text = "Apellido Paterno";
            // 
            // txtApellidoPaterno
            // 
            txtApellidoPaterno.Anchor = AnchorStyles.Left | AnchorStyles.Right;
            txtApellidoPaterno.Location = new Point(188, 47);
            txtApellidoPaterno.Name = "txtApellidoPaterno";
            txtApellidoPaterno.Size = new Size(319, 27);
            txtApellidoPaterno.TabIndex = 3;
            // 
            // lblApellidoMaterno
            // 
            lblApellidoMaterno.AutoSize = true;
            lblApellidoMaterno.Location = new Point(13, 78);
            lblApellidoMaterno.Name = "lblApellidoMaterno";
            lblApellidoMaterno.Size = new Size(126, 20);
            lblApellidoMaterno.TabIndex = 4;
            lblApellidoMaterno.Text = "Apellido Materno";
            // 
            // txtApellidoMaterno
            // 
            txtApellidoMaterno.Anchor = AnchorStyles.Left | AnchorStyles.Right;
            txtApellidoMaterno.Location = new Point(188, 81);
            txtApellidoMaterno.Name = "txtApellidoMaterno";
            txtApellidoMaterno.Size = new Size(319, 27);
            txtApellidoMaterno.TabIndex = 5;
            // 
            // lblFechaNac
            // 
            lblFechaNac.AutoSize = true;
            lblFechaNac.Location = new Point(13, 112);
            lblFechaNac.Name = "lblFechaNac";
            lblFechaNac.Size = new Size(128, 20);
            lblFechaNac.TabIndex = 6;
            lblFechaNac.Text = "Fecha Nacimiento";
            // 
            // dtpNacimiento
            // 
            dtpNacimiento.Anchor = AnchorStyles.Left;
            dtpNacimiento.Format = DateTimePickerFormat.Short;
            dtpNacimiento.Location = new Point(188, 115);
            dtpNacimiento.Name = "dtpNacimiento";
            dtpNacimiento.Size = new Size(200, 27);
            dtpNacimiento.TabIndex = 7;
            // 
            // lblRFC
            // 
            lblRFC.AutoSize = true;
            lblRFC.Location = new Point(13, 146);
            lblRFC.Name = "lblRFC";
            lblRFC.Size = new Size(34, 20);
            lblRFC.TabIndex = 8;
            lblRFC.Text = "RFC";
            // 
            // txtRFC
            // 
            txtRFC.Anchor = AnchorStyles.Left | AnchorStyles.Right;
            txtRFC.Location = new Point(188, 149);
            txtRFC.Name = "txtRFC";
            txtRFC.Size = new Size(319, 27);
            txtRFC.TabIndex = 9;
            // 
            // lblCentro
            // 
            lblCentro.AutoSize = true;
            lblCentro.Location = new Point(13, 180);
            lblCentro.Name = "lblCentro";
            lblCentro.Size = new Size(128, 20);
            lblCentro.TabIndex = 10;
            lblCentro.Text = "Centro de Trabajo";
            // 
            // cboCentro
            // 
            cboCentro.Anchor = AnchorStyles.Left | AnchorStyles.Right;
            cboCentro.DropDownStyle = ComboBoxStyle.DropDownList;
            cboCentro.Location = new Point(188, 183);
            cboCentro.Name = "cboCentro";
            cboCentro.Size = new Size(319, 28);
            cboCentro.TabIndex = 11;
            // 
            // lblPuesto
            // 
            lblPuesto.AutoSize = true;
            lblPuesto.Location = new Point(13, 214);
            lblPuesto.Name = "lblPuesto";
            lblPuesto.Size = new Size(53, 20);
            lblPuesto.TabIndex = 12;
            lblPuesto.Text = "Puesto";
            // 
            // cboPuesto
            // 
            cboPuesto.Anchor = AnchorStyles.Left | AnchorStyles.Right;
            cboPuesto.DropDownStyle = ComboBoxStyle.DropDownList;
            cboPuesto.Location = new Point(188, 217);
            cboPuesto.Name = "cboPuesto";
            cboPuesto.Size = new Size(319, 28);
            cboPuesto.TabIndex = 13;
            // 
            // chkDirectivo
            // 
            chkDirectivo.Anchor = AnchorStyles.Left;
            chkDirectivo.Location = new Point(188, 293);
            chkDirectivo.Name = "chkDirectivo";
            chkDirectivo.Size = new Size(150, 24);
            chkDirectivo.TabIndex = 14;
            chkDirectivo.Text = "Es Directivo";
            // 
            // buttonsPanel
            // 
            buttonsPanel.Controls.Add(btnCancelar);
            buttonsPanel.Controls.Add(btnGuardar);
            buttonsPanel.Dock = DockStyle.Bottom;
            buttonsPanel.FlowDirection = FlowDirection.RightToLeft;
            buttonsPanel.Location = new Point(0, 372);
            buttonsPanel.Name = "buttonsPanel";
            buttonsPanel.Padding = new Padding(10);
            buttonsPanel.Size = new Size(520, 48);
            buttonsPanel.TabIndex = 1;
            // 
            // btnCancelar
            // 
            btnCancelar.AutoSize = true;
            btnCancelar.DialogResult = DialogResult.Cancel;
            btnCancelar.Location = new Point(421, 13);
            btnCancelar.Name = "btnCancelar";
            btnCancelar.Size = new Size(76, 30);
            btnCancelar.TabIndex = 0;
            btnCancelar.Text = "Cancelar";
            // 
            // btnGuardar
            // 
            btnGuardar.AutoSize = true;
            btnGuardar.Location = new Point(340, 13);
            btnGuardar.Name = "btnGuardar";
            btnGuardar.Size = new Size(75, 30);
            btnGuardar.TabIndex = 1;
            btnGuardar.Text = "Guardar";
            btnGuardar.Click += btnGuardar_Click;
            // 
            // EmpleadoEditForm
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(520, 420);
            Controls.Add(tableLayoutPanel1);
            Controls.Add(buttonsPanel);
            FormBorderStyle = FormBorderStyle.FixedDialog;
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "EmpleadoEditForm";
            StartPosition = FormStartPosition.CenterParent;
            tableLayoutPanel1.ResumeLayout(false);
            tableLayoutPanel1.PerformLayout();
            buttonsPanel.ResumeLayout(false);
            buttonsPanel.PerformLayout();
            ResumeLayout(false);
        }
    }
}

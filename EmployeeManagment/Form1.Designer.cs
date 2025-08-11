namespace EmployeeManagment
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            menuStrip1 = new MenuStrip();
            empleadosToolStripMenuItem = new ToolStripMenuItem();
            puestosToolStripMenuItem = new ToolStripMenuItem();
            centrosTrabajoToolStripMenuItem = new ToolStripMenuItem();
            reporteEmpleadosToolStripMenuItem = new ToolStripMenuItem();
            panelHeader = new Panel();
            lblHeader = new Label();
            panelContent = new Panel();
            panelRoot = new Panel();
            menuStrip1.SuspendLayout();
            panelHeader.SuspendLayout();
            panelRoot.SuspendLayout();
            SuspendLayout();
            // 
            // menuStrip1
            // 
            menuStrip1.ImageScalingSize = new Size(20, 20);
            menuStrip1.Items.AddRange(new ToolStripItem[] { empleadosToolStripMenuItem, puestosToolStripMenuItem, centrosTrabajoToolStripMenuItem, reporteEmpleadosToolStripMenuItem });
            menuStrip1.Location = new Point(0, 0);
            menuStrip1.Name = "menuStrip1";
            menuStrip1.Size = new Size(1203, 28);
            menuStrip1.TabIndex = 0;
            menuStrip1.Text = "menuStrip1";
            // 
            // empleadosToolStripMenuItem
            // 
            empleadosToolStripMenuItem.Name = "empleadosToolStripMenuItem";
            empleadosToolStripMenuItem.Size = new Size(97, 24);
            empleadosToolStripMenuItem.Text = "Empleados";
            empleadosToolStripMenuItem.Click += empleadosToolStripMenuItem_Click;
            // 
            // puestosToolStripMenuItem
            // 
            puestosToolStripMenuItem.Name = "puestosToolStripMenuItem";
            puestosToolStripMenuItem.Size = new Size(73, 24);
            puestosToolStripMenuItem.Text = "Puestos";
            puestosToolStripMenuItem.Click += puestosToolStripMenuItem_Click;
            // 
            // centrosTrabajoToolStripMenuItem
            // 
            centrosTrabajoToolStripMenuItem.Name = "centrosTrabajoToolStripMenuItem";
            centrosTrabajoToolStripMenuItem.Size = new Size(148, 24);
            centrosTrabajoToolStripMenuItem.Text = "Centros de Trabajo";
            centrosTrabajoToolStripMenuItem.Click += centrosTrabajoToolStripMenuItem_Click;
            // 
            // reporteEmpleadosToolStripMenuItem
            // 
            reporteEmpleadosToolStripMenuItem.Name = "reporteEmpleadosToolStripMenuItem";
            reporteEmpleadosToolStripMenuItem.Size = new Size(175, 24);
            reporteEmpleadosToolStripMenuItem.Text = "Reporte de empleados";
            reporteEmpleadosToolStripMenuItem.Click += reporteEmpleadosToolStripMenuItem_Click;
            // 
            // panelHeader
            // 
            panelHeader.Controls.Add(lblHeader);
            panelHeader.Dock = DockStyle.Top;
            panelHeader.Location = new Point(0, 0);
            panelHeader.Name = "panelHeader";
            panelHeader.Padding = new Padding(10, 8, 10, 8);
            panelHeader.Size = new Size(1203, 60);
            panelHeader.TabIndex = 1;
            // 
            // lblHeader
            // 
            lblHeader.Dock = DockStyle.Fill;
            lblHeader.Font = new Font("Segoe UI", 16F, FontStyle.Bold);
            lblHeader.Location = new Point(10, 8);
            lblHeader.Name = "lblHeader";
            lblHeader.Size = new Size(1183, 44);
            lblHeader.TabIndex = 0;
            lblHeader.Text = "GESTION DE PERSONAL TIENDA KAMIL";
            lblHeader.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // panelContent
            // 
            panelContent.Dock = DockStyle.Fill;
            panelContent.Location = new Point(0, 60);
            panelContent.Name = "panelContent";
            panelContent.Padding = new Padding(10);
            panelContent.Size = new Size(1203, 549);
            panelContent.TabIndex = 0;
            // 
            // panelRoot
            // 
            panelRoot.Controls.Add(panelContent);
            panelRoot.Controls.Add(panelHeader);
            panelRoot.Dock = DockStyle.Fill;
            panelRoot.Location = new Point(0, 28);
            panelRoot.Name = "panelRoot";
            panelRoot.Size = new Size(1203, 609);
            panelRoot.TabIndex = 0;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1203, 637);
            Controls.Add(panelRoot);
            Controls.Add(menuStrip1);
            MainMenuStrip = menuStrip1;
            Name = "Form1";
            Text = "Gestión de Empleados";
            Load += Form1_Load;
            menuStrip1.ResumeLayout(false);
            menuStrip1.PerformLayout();
            panelHeader.ResumeLayout(false);
            panelRoot.ResumeLayout(false);
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private MenuStrip menuStrip1;
    private ToolStripMenuItem empleadosToolStripMenuItem;
    private ToolStripMenuItem puestosToolStripMenuItem;
    private ToolStripMenuItem centrosTrabajoToolStripMenuItem;
    private ToolStripMenuItem reporteEmpleadosToolStripMenuItem;
    private Panel panelHeader;
    private Label lblHeader;
    private Panel panelContent;
    private Panel panelRoot;
    }
}

using System.Drawing;
using System.Windows.Forms;
using EmployeeManagment.Models;

namespace EmployeeManagment.Forms
{
    partial class CentrosForm
    {
        private System.ComponentModel.IContainer components = null;
        private DataGridView grid;
        private Panel panelTop;
        private Button btnAdd;
        private Button btnEdit;
        private Button btnDelete;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null)) components.Dispose();
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            grid = new DataGridView();
            panelTop = new Panel();
            btnAdd = new Button();
            btnEdit = new Button();
            btnDelete = new Button();
            ((System.ComponentModel.ISupportInitialize)grid).BeginInit();
            panelTop.SuspendLayout();
            SuspendLayout();
            // 
            // grid
            // 
            grid.ColumnHeadersHeight = 29;
            grid.Dock = DockStyle.Fill;
            grid.Location = new Point(0, 40);
            grid.MultiSelect = false;
            grid.Name = "grid";
            grid.ReadOnly = true;
            grid.RowHeadersWidth = 51;
            grid.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            grid.Size = new Size(700, 410);
            grid.TabIndex = 0;
            // 
            // panelTop
            // 
            panelTop.Controls.Add(btnAdd);
            panelTop.Controls.Add(btnEdit);
            panelTop.Controls.Add(btnDelete);
            panelTop.Dock = DockStyle.Top;
            panelTop.Location = new Point(0, 0);
            panelTop.Name = "panelTop";
            panelTop.Size = new Size(700, 40);
            panelTop.TabIndex = 1;
            // 
            // btnAdd
            // 
            btnAdd.Location = new Point(0, 5);
            btnAdd.Name = "btnAdd";
            btnAdd.Size = new Size(75, 29);
            btnAdd.TabIndex = 0;
            btnAdd.Text = "Agregar";
            // 
            // btnEdit
            // 
            btnEdit.Location = new Point(100, 5);
            btnEdit.Name = "btnEdit";
            btnEdit.Size = new Size(75, 29);
            btnEdit.TabIndex = 1;
            btnEdit.Text = "Editar";
            // 
            // btnDelete
            // 
            btnDelete.Location = new Point(200, 5);
            btnDelete.Name = "btnDelete";
            btnDelete.Size = new Size(75, 29);
            btnDelete.TabIndex = 2;
            btnDelete.Text = "Eliminar";
            // 
            // CentrosForm
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(700, 450);
            Controls.Add(grid);
            Controls.Add(panelTop);
            Name = "CentrosForm";
            Text = "Centros de Trabajo";
            ((System.ComponentModel.ISupportInitialize)grid).EndInit();
            panelTop.ResumeLayout(false);
            ResumeLayout(false);
        }
    }
}

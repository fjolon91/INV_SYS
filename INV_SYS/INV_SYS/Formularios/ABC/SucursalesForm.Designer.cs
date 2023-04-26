
namespace INV_SYS.Formularios.ABC
{
    partial class SucursalesForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
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
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.panel1 = new System.Windows.Forms.Panel();
            this.dgSucursales = new System.Windows.Forms.DataGridView();
            this.editar = new System.Windows.Forms.DataGridViewLinkColumn();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgSucursales)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.dgSucursales);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(744, 479);
            this.panel1.TabIndex = 0;
            // 
            // dgSucursales
            // 
            this.dgSucursales.AllowUserToAddRows = false;
            this.dgSucursales.AllowUserToDeleteRows = false;
            this.dgSucursales.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgSucursales.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.editar});
            this.dgSucursales.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgSucursales.Location = new System.Drawing.Point(0, 0);
            this.dgSucursales.Name = "dgSucursales";
            this.dgSucursales.ReadOnly = true;
            this.dgSucursales.Size = new System.Drawing.Size(744, 479);
            this.dgSucursales.TabIndex = 0;
            // 
            // editar
            // 
            this.editar.HeaderText = "Editar";
            this.editar.Name = "editar";
            this.editar.ReadOnly = true;
            this.editar.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.editar.Text = "Editar";
            this.editar.ToolTipText = "Modificar sucursal";
            // 
            // SucursalesForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(744, 479);
            this.Controls.Add(this.panel1);
            this.MaximizeBox = false;
            this.Name = "SucursalesForm";
            this.Text = "Sucursales";
            this.Load += new System.EventHandler(this.SucursalesForm_Load);
            this.panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgSucursales)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.DataGridView dgSucursales;
        private System.Windows.Forms.DataGridViewLinkColumn editar;
    }
}
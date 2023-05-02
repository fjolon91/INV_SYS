using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace INV_SYS.Formularios.ABC
{
    public partial class SucursalesForm : Form
    {
        public SucursalesForm()
        {
            InitializeComponent();
        }

        private void SucursalesForm_Load(object sender, EventArgs e)
        {
            DataTable dtSucursales = RSucursal.listarSucursales();

            if(dtSucursales != null)
            {
                dgSucursales.DataSource = dtSucursales;
                //dgSucursales.Columns.Add("modificar", "Modificar");

            }
        }

        private void dgSucursales_DoubleClick(object sender, EventArgs e)
        {
            var filaSeleccionada = dgSucursales.CurrentCell.RowIndex;
            var sucursalSeleccionada = dgSucursales.Rows[filaSeleccionada].Cells["sucursal"].Value;
            MessageBox.Show(sucursalSeleccionada.ToString());

            SucursalForm sucursal = new SucursalForm(sucursalSeleccionada.ToString());
            sucursal.Show();
        }
    }
}

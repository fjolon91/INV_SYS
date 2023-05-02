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
    public partial class SucursalForm : Form
    {

        private string _idSucursal;
        public SucursalForm(string idSucursal)
        {
            InitializeComponent();
            _idSucursal = idSucursal;
        }

        private void SucursalForm_Load(object sender, EventArgs e)
        {
            chkVigente.Checked = true;
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}

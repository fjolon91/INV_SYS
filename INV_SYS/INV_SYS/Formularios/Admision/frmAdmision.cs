using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace INV_SYS
{
    public partial class frmAdmision : Form
    {
        private string admision;
        private string tipoAdmision;
        private string idEspecialidad;
        private string sucursal;
        private string cliente;
        public frmAdmision(string admision, string tipoAdmision, string idEspecialidad, string sucursal, string cliente)
        {
            InitializeComponent();
            this.admision = admision;
            this.tipoAdmision = tipoAdmision;
            this.idEspecialidad = idEspecialidad;
            this.sucursal = sucursal;
            this.cliente = cliente;
            cargarInformacion();
        }

        public void cargarInformacion()
        {
            DataTable dtAdmision = RAdmision.obtenerAdmision(admision, tipoAdmision, idEspecialidad,sucursal,cliente);
            if(dtAdmision.Rows.Count>0)
            {
                lblOrden.Text = dtAdmision.Rows[0]["Admision"].ToString();
                lblNombre.Text = dtAdmision.Rows[0]["Nombre"].ToString();
                lblPaciente.Text = dtAdmision.Rows[0]["Paciente"].ToString();
                lblMedico.Text = dtAdmision.Rows[0]["NombreMedico"].ToString();

                int cantidad=1;
                string descripcion="";
                decimal precio=0;
                decimal subTotal=0;
                decimal granTotal=0;
                for(int r=0;r<dtAdmision.Rows.Count;r++)
                {
                    cantidad = Convert.ToInt32( dtAdmision.Rows[r]["cantidad"].ToString());
                    descripcion = dtAdmision.Rows[r]["Estudio"].ToString();
                    precio = Convert.ToDecimal( dtAdmision.Rows[r]["Venta"].ToString());
                    subTotal = Convert.ToDecimal(dtAdmision.Rows[r]["SubTotal"].ToString());
                    dgvDetalle.Rows.Add(cantidad,descripcion,precio.ToString("C2"),subTotal.ToString("C2"));
                    granTotal += subTotal;
                }
                lblGranTotal.Text = granTotal.ToString("C2");
                lblCantidad.Text = "Estudios: "+ dtAdmision.Rows.Count;
            }
        }
    }
}

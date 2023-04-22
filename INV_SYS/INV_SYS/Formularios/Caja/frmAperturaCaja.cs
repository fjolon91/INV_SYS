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
    public partial class frmAperturaCaja : Form
    {
        private string userid;
        private string accion;
        private double cent05;
        private double cent010;
        private double cent025;
        private double cent050;
        private double qtz1;
        private double totalMonedas;
        private double bill1;
        private double bill5;
        private double bill10;
        private double bill20;
        private double bill50;
        private double bill100;
        private double bill200;
        private double totalBilletes;
        private double granTotal;
        public frmAperturaCaja(string userid, string accion)
        {
            InitializeComponent();
            this.userid = userid;
            this.accion = accion;
            DataTable dtInfoUsuario = RUsuario.verificarUsuario(userid);
            txtUsuario.Text = dtInfoUsuario.Rows[0]["nombre"].ToString();
            cargarCombos();
        }

        public void cargarCombos()
        {
            switch (accion)
            {
                //C=Cierre de caja | A: Apertura de caja 
                case "C":
                    cmbSucursal.DataSource = RSucursal.listarSucursales();
                    cmbSucursal.DisplayMember = "nombre";
                    cmbSucursal.ValueMember = "sucursal";

                    listarCajasXstatus("C");
                    cmbConcepto.DataSource = RConceptoCaja.ListarConceptosCajaId("1");
                    cmbConcepto.DisplayMember = "descripcion";
                    cmbConcepto.ValueMember = "concepto";

                    cmbConcepto.SelectedValue = 1;
                    cmbConcepto.Enabled = false;
                    break;
                case "A":
                    cmbSucursal.DataSource = RSucursal.listarSucursales();
                    cmbSucursal.DisplayMember = "nombre";
                    cmbSucursal.ValueMember = "sucursal";
                    listarCajasXstatus("A");
                    cmbConcepto.DataSource = RConceptoCaja.ListarConceptosCajaId("6");
                    cmbConcepto.DisplayMember = "descripcion";
                    cmbConcepto.ValueMember = "concepto";
                    cmbConcepto.Enabled = false;
                    break;
            }

        }
        private void listarCajasXstatus(string status)
        {
            cmbCaja.DataSource = RCaja.listarCajasStatus(cmbSucursal.SelectedValue.ToString(), status);
            cmbCaja.DisplayMember = "Descripcion";
            cmbCaja.ValueMember = "caja";

        }

        private void label12_Click(object sender, EventArgs e)
        {

        }

        private void calcularMonedas()
        {
            if(String.IsNullOrEmpty(txt5Cent.Text))
            {
                txt5Cent.Text = "0";
            }
            else
            {
                cent05 = 0.05 * Convert.ToDouble(txt5Cent.Text);
                lblTocal5Cent.Text = cent05.ToString("C");
            }
            if (String.IsNullOrEmpty(txt10Cent.Text))
            {
                txt10Cent.Text = "0";
            }
            else
            {
                cent010 = 0.10 * Convert.ToDouble(txt10Cent.Text);
                lblTotal10Cent.Text = cent010.ToString("C");
            }
            if (String.IsNullOrEmpty(txt25Cent.Text))
            {
                txt25Cent.Text = "0";
            }
            else
            {
                cent025 = 0.25 * Convert.ToDouble(txt25Cent.Text);
                lblTotal25Cent.Text = cent025.ToString("C");
            }
            if (String.IsNullOrEmpty(txt50Cent.Text))
            {
                txt50Cent.Text = "0";
            }
            else
            {
                cent050 = 0.50 * Convert.ToDouble(txt50Cent.Text);
                lblTotal50Cent.Text = cent050.ToString("C");
            }
            if (String.IsNullOrEmpty(txt1Quetzal.Text))
            {
               txt1Quetzal.Text = "0";
            }
            else
            {
                qtz1 = 1 * Convert.ToDouble(txt1Quetzal.Text);
                lblTotal1Qtzl.Text = qtz1.ToString("C");
            }

            totalMonedas = cent05 + cent010 + cent025 +cent050 + qtz1;
            lblTotalBilletes.Text = totalBilletes.ToString("C");
            lblTotalMonedas.Text = totalMonedas.ToString("C");
            granTotal = totalBilletes + totalMonedas;
            lblGranTotal.Text = granTotal.ToString("C");
        }

        private void calcularBilletes()
        {
            if(String.IsNullOrEmpty(txt1Qtz.Text))
            {
                txt1Qtz.Text = "0";
            }
            else
            {
                bill1 = 1 * Convert.ToDouble(txt1Qtz.Text);
                lblTotalQtzl.Text = bill1.ToString("C");
            }
            if (String.IsNullOrEmpty(txt5Qtz.Text))
            {
                txt5Qtz.Text = "0";
            }
            else
            {
                bill5 = 5 * Convert.ToDouble(txt5Qtz.Text);
                lblTotal5Qtzl.Text = bill5.ToString("C");
            }
            if (String.IsNullOrEmpty(txt10Qtz.Text))
            {
                txt10Qtz.Text = "0";
            }
            else
            {
                bill10 = 10 * Convert.ToDouble(txt10Qtz.Text);
                lblTotal10Qtzl.Text = bill10.ToString("C");
            }
            if (String.IsNullOrEmpty(txt20Qtz.Text))
            {
                txt20Qtz.Text = "0";
            }
            else
            {
                bill20 = 20 * Convert.ToDouble(txt20Qtz.Text);
                lblTotal20Qtzl.Text = bill20.ToString("C");
            }
            if (String.IsNullOrEmpty(txt50Qtzl.Text))
            {
                txt50Qtzl.Text = "0";
            }
            else
            {
                bill50 = 50 * Convert.ToDouble(txt50Qtzl.Text);
                lblTotal50Qtzl.Text = bill50.ToString("C");
            }
            if (String.IsNullOrEmpty(txt100Qtzl.Text))
            {
                txt100Qtzl.Text = "0";
            }
            else
            {
                bill100 = 100 * Convert.ToDouble(txt100Qtzl.Text);
                lblTotal100Qtzl.Text = bill100.ToString("C");
            }
            if (String.IsNullOrEmpty(txt200Qtzl.Text))
            {
                txt200Qtzl.Text = "0";
            }
            else
            {
                bill200 = 200 * Convert.ToDouble(txt200Qtzl.Text);
                lblTotal200Qtzl.Text = bill200.ToString("C");
            }

            totalBilletes = bill1 + bill5 + bill10 + bill20 + bill50 + bill100 + bill200;
            lblTotalBilletes.Text = totalBilletes.ToString("C");
            lblTotalMonedas.Text = totalMonedas.ToString("C");
            granTotal = totalBilletes + totalMonedas;
            lblGranTotal.Text = granTotal.ToString("C");
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            crearAperturaCajar();
        }

        private void crearAperturaCajar()
        {

        }

        private void txt5Cent_Leave(object sender, EventArgs e)
        {
            calcularMonedas();
        }

        private void txt10Cent_Leave(object sender, EventArgs e)
        {
            calcularMonedas();
        }

        private void txt25Cent_Leave(object sender, EventArgs e)
        {
            calcularMonedas();
        }

        private void txt50Cent_Leave(object sender, EventArgs e)
        {
            calcularMonedas();
        }

        private void txt1Quetzal_Leave(object sender, EventArgs e)
        {
            calcularMonedas();
        }

        private void txt1Qtz_Leave(object sender, EventArgs e)
        {
            calcularBilletes();
        }

        private void txt5Qtz_Leave(object sender, EventArgs e)
        {
            calcularBilletes();
        }

        private void txt10Qtz_TextChanged(object sender, EventArgs e)
        {
            calcularBilletes();
        }

        private void txt1Qtz_TextChanged(object sender, EventArgs e)
        {
            calcularBilletes();
        }

        private void txt5Qtz_TextChanged(object sender, EventArgs e)
        {
            calcularBilletes();
        }

        private void txt20Qtz_TextChanged(object sender, EventArgs e)
        {
            calcularBilletes();
        }

        private void txt50Qtzl_TextChanged(object sender, EventArgs e)
        {
            calcularBilletes();
        }

        private void txt100Qtzl_TextChanged(object sender, EventArgs e)
        {
            calcularBilletes();
        }

        private void txt200Qtzl_TextChanged(object sender, EventArgs e)
        {
            calcularBilletes();
        }

        private void txt5Cent_TextChanged(object sender, EventArgs e)
        {
            calcularMonedas();
        }

        private void txt10Cent_TextChanged(object sender, EventArgs e)
        {
            calcularMonedas();
        }

        private void txt25Cent_TextChanged(object sender, EventArgs e)
        {
            calcularMonedas();
        }

        private void txt50Cent_TextChanged(object sender, EventArgs e)
        {
            calcularMonedas();
        }

        private void txt1Quetzal_TextChanged(object sender, EventArgs e)
        {
            calcularMonedas();
        }

        private void registrarMovimiento(string _status)
        {
            EMovimientoCaja movCaja = new EMovimientoCaja();
            movCaja.caja = cmbCaja.SelectedValue.ToString();
            movCaja.concepto = cmbConcepto.SelectedValue.ToString();
            DataTable dtTipoOperacion = RConceptoCaja.ListarConceptosCajaId(movCaja.concepto);
            if(dtTipoOperacion.Rows.Count>0)
            {
                movCaja.operacion = Convert.ToInt32( dtTipoOperacion.Rows[0]["tipo"].ToString());
            }
            else
            {
                movCaja.operacion = 0;
            }
            string totalRegistro = lblGranTotal.Text.Replace("Q","");
            movCaja.montoEfectivo = Convert.ToDouble( totalRegistro);
            movCaja.moneda05 = Convert.ToInt32(txt5Cent.Text);
            movCaja.moneda010 = Convert.ToInt32(txt10Cent.Text);
            movCaja.moneda050 = Convert.ToInt32(txt50Cent.Text);
            movCaja.moneda01 = Convert.ToInt32(txt1Quetzal.Text);
            movCaja.billete1 = Convert.ToInt32(txt1Qtz.Text);
            movCaja.billete10 = Convert.ToInt32(txt10Qtz.Text);
            movCaja.billete5 = Convert.ToInt32(txt5Qtz.Text);
            movCaja.billete20 = Convert.ToInt32(txt20Qtz.Text);
            movCaja.billete50 = Convert.ToInt32(txt50Qtzl.Text);
            movCaja.billete100 = Convert.ToInt32(txt100Qtzl.Text);
            movCaja.billete200 = Convert.ToInt32(txt200Qtzl.Text);
            movCaja.fechaRegistro = dtpFechaRecpecion.Value;
            movCaja.usuario = userid;
            if (RMovimientoCaja.registrarMovimientoCaja(movCaja) > 0)
            {
                ECaja eCaja = new ECaja();
                eCaja.caja = movCaja.caja;
                eCaja.status = _status;
                eCaja.sucursal = cmbSucursal.SelectedValue.ToString();
                eCaja.Pc = Environment.MachineName;
                if(RCaja.actualizarStatusCaja(eCaja)>0)
                    MessageBox.Show("Caja aperturada con éxito", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
                MessageBox.Show("Ocurrio un error al aperturar caja", "Alerta", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
        private void btnAperturar_Click(object sender, EventArgs e)
        {
            string status = "";
            if (accion == "C")
                status = "A";
            if (accion == "A")
                status = "C";                
            registrarMovimiento(status);
        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }
    }
}

using INV_SYS.Formularios.ABC;
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
    public partial class frmInvSys : Form
    {
        private string userid;
        private string ordenador;
        private string idCaja;
        public frmInvSys(string userid)
        {
            InitializeComponent();
            ordenador = Environment.MachineName;
            this.userid = userid;
            verificarCaja();
           
        }

        private bool verificarCaja()
        {

            bool estado = false;
            DataTable dtCaja = RCaja.obtenerStatusCaja(ordenador); //Status; A=Abierto, C=Cerrado
            if (dtCaja.Rows.Count > 0)
            {
                idCaja = dtCaja.Rows[0]["caja"].ToString();
                string status = dtCaja.Rows[0]["status"].ToString();
                switch (status)
                {
                    case "A":
                        tbcGeneral.Visible = true;
                        cargarLaboratorios();
                        break;
                    case "C":
                        tbcGeneral.Visible = false;
                        MessageBox.Show("Debe aperturar caja para esta estación de trabajo " + ordenador, "Información", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        break;
                }
            }
            return estado;
        }

        private void cargarLaboratorios()
        {
            DataTable dtOrdensLab = RAdmision.laboratorioXFacturar();
            if(dtOrdensLab.Rows.Count>0)
            {
                string admision = "";
                string tipoAdmision = "";
                string paciente ="";
                string fechaIngreso = "";
                decimal total = 0;
                string idEspcialidad = "";
                string especialidad = "";
                string idTipoPaciente = "";
                string tipoPaciente = "";
                string status = "";
                string idSucursal = "";
                dgvFacturas.Rows.Clear();
                for(int r=0; r<dtOrdensLab.Rows.Count;r++)
                {
                    admision = dtOrdensLab.Rows[r]["Admision"].ToString();
                    tipoAdmision = dtOrdensLab.Rows[r]["tipoAdmision"].ToString();
                    paciente = dtOrdensLab.Rows[r]["Nombre"].ToString();
                    fechaIngreso = dtOrdensLab.Rows[r]["FechaRecepcion"].ToString();
                    idEspcialidad = dtOrdensLab.Rows[r]["IdEspecialidad"].ToString();
                    especialidad = dtOrdensLab.Rows[r]["Especialidad"].ToString();
                    idTipoPaciente = dtOrdensLab.Rows[r]["idTipoPaciente"].ToString();
                    tipoPaciente = dtOrdensLab.Rows[r]["tipoPaciente"].ToString();
                    status = dtOrdensLab.Rows[r]["status"].ToString();
                    total = Convert.ToDecimal( dtOrdensLab.Rows[r]["Total"].ToString());
                    idSucursal = dtOrdensLab.Rows[r]["sucursal"].ToString();
                    dgvFacturas.Rows.Add(admision,tipoAdmision,paciente,fechaIngreso,total.ToString("C2"),"",idEspcialidad,especialidad,idTipoPaciente,tipoPaciente,status,idSucursal);
                }
            }
            formatearGridAdmision();
        }

        private void frmInvSys_Load(object sender, EventArgs e)
        {
            
        }

        private void sesiónToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void cerrarSesion()//tsbCerrarSesion_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void aperturarCajaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            gestionarCaja(userid, "A");
        }

        private void gestionarCaja(string userid, string accion)
        {
            frmAperturaCaja _frmAperturaCaja = new frmAperturaCaja(userid, accion);
            _frmAperturaCaja.ShowDialog(this);
            verificarCaja();
        }
        
        private void cargarClientes()
        {
            DataTable dtClientes = RCliente.listarClientes();
            if(dtClientes.Rows.Count>0)
            {
                cmbClientes.DataSource = dtClientes;
                cmbClientes.DisplayMember = "Descripcion";
                cmbClientes.ValueMember = "NIT";
            }
            
        }
        private void btnGenerarFacturaInstitucion_Click(object sender, EventArgs e)
        {

        }

        private void tabControl1_Selected(object sender, TabControlEventArgs e)
        {
            cargarClientes();
            cargarFacturas();
            cargarProveedores();
            cargarGastos();
        }

        private void seleccionarAdmision()
        {
            string admision = "";
            string tipoAdmision = "";
            string idEspecialidad = "";
            string _idSucursal = "";
            if (dgvFacturas.SelectedRows.Count==1)
            {
                admision = dgvFacturas.CurrentRow.Cells["noOrden"].Value.ToString();
                tipoAdmision = dgvFacturas.CurrentRow.Cells["TipoAdmision"].Value.ToString();
                idEspecialidad = dgvFacturas.CurrentRow.Cells["IdEspecialidad"].Value.ToString();
                _idSucursal = dgvFacturas.CurrentRow.Cells["idSucursal"].Value.ToString();
                frmAdmision _frmAdmision = new frmAdmision(admision, tipoAdmision, idEspecialidad,_idSucursal);
                _frmAdmision.ShowDialog(this);
            }
        }

        private void dgvFacturas_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            seleccionarAdmision();
        }

        private void formatearGridAdmision()
        {
            dgvFacturas.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
        }

        private void formatearGridFacturas()
        {
            dgvFacturasEmitidas.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
        }

        private void formatearGridGastos()
        {
            dgvGastos.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
        }

        private void btnVerDetalleFactura_Click(object sender, EventArgs e)
        {
            seleccionarAdmision();
        }

        private void btnGenerarFactura_Click(object sender, EventArgs e)
        {
            facturarAdmision();
            cargarLaboratorios();
        }

        private void facturarAdmision()
        {
            string admision = "";
            string tipoAdmision = "";
            string idEspecialidad = "";
            string idSucursal = "";
            if (dgvFacturas.SelectedRows.Count == 1)
            {
                admision = dgvFacturas.CurrentRow.Cells["noOrden"].Value.ToString();
                tipoAdmision = dgvFacturas.CurrentRow.Cells["TipoAdmision"].Value.ToString();
                idEspecialidad = dgvFacturas.CurrentRow.Cells["IdEspecialidad"].Value.ToString();
                idSucursal = dgvFacturas.CurrentRow.Cells["idSucursal"].Value.ToString();
                frmDocumento _frmDocumento = new frmDocumento(admision, tipoAdmision, idEspecialidad,userid,idSucursal,"");
                _frmDocumento.ShowDialog(this);
            }
        }

        public void cargarFacturas()
        {
            DataTable dtFacturas = new DataTable();
            dtFacturas = RDocumento.historialDocumentos(dtpInicio.Value, dtpFinal.Value, "", 0, "", "", "", true);
            if(dtFacturas.Rows.Count>0)
            {
                string orden = "";
                string paciente = "";
                string nit="";
                string fechaRegistro="";
                double totalFacturado=0;
                string documento = "";
                string tipoDocumento = "";
                string sucursal = "";
                string serie = "";
                string autorizacion = "";
                string numeroFEL = "";
                string serieFEL = "";
                dgvFacturasEmitidas.Rows.Clear();
                for (int r=0;r<dtFacturas.Rows.Count; r++)
                {
                    sucursal = dtFacturas.Rows[r]["sede"].ToString();
                    fechaRegistro = dtFacturas.Rows[r]["Fecha"].ToString();
                    documento = dtFacturas.Rows[r]["Numero"].ToString();
                    tipoDocumento = dtFacturas.Rows[r]["Tipo"].ToString();
                    totalFacturado = Convert.ToDouble(dtFacturas.Rows[r]["total"].ToString());
                    paciente = dtFacturas.Rows[r]["cliente"].ToString();
                    nit = dtFacturas.Rows[r]["nit"].ToString();
                    orden = dtFacturas.Rows[r]["referencia"].ToString();
                    serie = dtFacturas.Rows[r]["serieDocumento"].ToString();
                    autorizacion = dtFacturas.Rows[r]["FELNoAutorizacion"].ToString();
                    numeroFEL = dtFacturas.Rows[r]["FELDocumento"].ToString();
                    serieFEL = dtFacturas.Rows[r]["FELSerieDocumento"].ToString();
                    dgvFacturasEmitidas.Rows.Add(orden,paciente,nit,fechaRegistro,totalFacturado.ToString("C2"),"",serie,documento,tipoDocumento,sucursal,autorizacion,numeroFEL,serieFEL);
                }
            }
            formatearGridFacturas();
        }
        private void btnAnularFactura_Click(object sender, EventArgs e)
        {

        }

        private void dgvFacturasEmitidas_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            seleccionarFactura();
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            cargarFacturas();
        }


        private void seleccionarFactura()
        {
            string documento = "";
            string tipo = "";
            string sucursal = "";
            string serie = "";
            if (dgvFacturasEmitidas.SelectedRows.Count == 1)
            {
                documento = dgvFacturasEmitidas.CurrentRow.Cells["Documento"].Value.ToString();
                tipo = dgvFacturasEmitidas.CurrentRow.Cells["Tipo"].Value.ToString();
                sucursal = dgvFacturasEmitidas.CurrentRow.Cells["sucursal"].Value.ToString();
                serie = dgvFacturasEmitidas.CurrentRow.Cells["serie"].Value.ToString();
                frmDocumento frmdocumento = new frmDocumento(tipo, serie, documento, sucursal, userid); ;
                frmdocumento.ShowDialog(this);
            }
        }

        private void panel3_Paint(object sender, PaintEventArgs e)
        {
        }

        private void cargarProveedores()
        {
            DataTable dtProveedores = RProveedor.listarProveedoresVigentes();
            cmbProveedores.DataSource = dtProveedores;
            cmbProveedores.DisplayMember = "ProveedorNit";
            cmbProveedores.ValueMember = "Proveedor";
        }

        private void btnEgreso_Click(object sender, EventArgs e)
        {
            registrarEgreso();
            cargarGastos();
            txtConcepto.Text = "";
            txtMonto.Text = "";
            cargarProveedores();
        }

        private void registrarEgreso()
        {
            string caja = "";
            DataTable dtUltimoGasto = RGasto.ultimoGasto();
            string _gasto = dtUltimoGasto.Rows[0]["gasto"].ToString();
            DataTable dtCajaActiva = RCaja.listarCajasPC(Environment.MachineName, "A");
            if(dtCajaActiva.Rows.Count>0)
            {
                caja = dtCajaActiva.Rows[0]["caja"].ToString();
            }
            EGasto gasto = new EGasto();
            if (String.IsNullOrEmpty(_gasto))
                gasto.gasto = 1;
            else
                gasto.gasto = Convert.ToInt32(dtUltimoGasto.Rows[0]["gasto"].ToString());
            //gasto = gasto.gasto;
            gasto.fecha = DateTime.Now;
            gasto.concepto = "4";// rubro 4= Otros Gastos 
            gasto.vigente = true;
            gasto.caja = caja;
            gasto.proveedor = cmbProveedores.SelectedValue.ToString();

            if (RGasto.registrarGasto(gasto) > 0)
            {
                EDetalleGasto detalle = new EDetalleGasto();
                detalle.gasto = gasto.gasto;
                detalle.detalle = 1;
                detalle.referenciaGasto = txtConcepto.Text;
                detalle.monto = Convert.ToDouble( txtMonto.Text);
                detalle.usuario = userid;
                detalle.fecha = DateTime.Now;

                if(RDetalleGasto.registrarGasto(detalle)>0)
                {
                    EMovimientoCaja movCaja = new EMovimientoCaja();
                    movCaja.caja = gasto.caja;
                    movCaja.concepto = gasto.concepto;
                    movCaja.fechaRegistro = DateTime.Now;
                    movCaja.montoEfectivo = detalle.monto;
                    movCaja.operacion = -1;
                    movCaja.tipoMovimiento = "G";
                    movCaja.movimientoReferencia = gasto.gasto.ToString();
                    movCaja.usuario = userid;
                    if(RMovimientoCaja.registrarMovimientoCaja(movCaja)==1)
                    {
                        MessageBox.Show("Gasto registro con éxito", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
            }

        }

        private void tmrData_Tick(object sender, EventArgs e)
        {
            obtenerDatosLab();
        }


        private void cargarGastos()
        {
            DataTable dtGastos = RGasto.listarGastos(DateTime.Now,DateTime.Now, idCaja);
            if(dtGastos.Rows.Count>0)
            {
                string gasto = "";
                DateTime fecha;
                string concepto = "";
                string proveedor = "";
                string descripcion = "";
                double monto = 0;
                dgvGastos.Rows.Clear();
                for (int j=0; j<dtGastos.Rows.Count;j++)
                {
                    gasto = dtGastos.Rows[j]["gasto"].ToString();
                    fecha = Convert.ToDateTime(dtGastos.Rows[j]["fecha"].ToString());
                    concepto = dtGastos.Rows[j]["concepto"].ToString();
                    proveedor = dtGastos.Rows[j]["proveedor"].ToString();
                    descripcion = dtGastos.Rows[j]["referenciaGasto"].ToString();
                    monto = Convert.ToDouble(dtGastos.Rows[j]["monto"].ToString());
                    dgvGastos.Rows.Add(gasto,fecha,concepto,proveedor,descripcion,monto,"","");
                }
                formatearGridGastos();
            }
        }

        private void obtenerDatosLab()
        {
            DataTable dtOrdenLab = ROrdenExterna.obtenerDatos();
            if(dtOrdenLab.Rows.Count>0)
            {
                EAdmision adm = new EAdmision();
                EDetalleAdmision det = new EDetalleAdmision();
                for(int r=0; r<dtOrdenLab.Rows.Count;r++)
                {
                    adm.tipoAdmision = dtOrdenLab.Rows[r]["TipoOrden"].ToString();
                    adm.Admision = dtOrdenLab.Rows[r]["Orden"].ToString();
                    adm.especialidad = "LABO";
                    adm.fechaRecepcion = Convert.ToDateTime(dtOrdenLab.Rows[r]["FechaRecepcion"].ToString());
                    adm.paciente = dtOrdenLab.Rows[r]["paciente"].ToString();//
                    adm.nombre = dtOrdenLab.Rows[r]["Nombre"].ToString()+" "+ dtOrdenLab.Rows[r]["PrimerApellido"].ToString()+" "+ dtOrdenLab.Rows[r]["SegundoApellido"].ToString(); ;
                    adm.sexo = dtOrdenLab.Rows[r]["Sexo"].ToString();
                    adm.fechaNacimiento = Convert.ToDateTime(dtOrdenLab.Rows[r]["FechaNacimiento"].ToString());
                    adm.medico = dtOrdenLab.Rows[r]["Medico"].ToString(); 
                    adm.nombreMedico = dtOrdenLab.Rows[r]["NombreMedico"].ToString();

                    DataTable dtTipoCliente = RTipoCliente.ListarTipoClienteId(dtOrdenLab.Rows[r]["tipoCliente"].ToString());
                    if (dtTipoCliente.Rows.Count == 0)
                    {
                        ETipoCliente eTipoCliente = new ETipoCliente();
                        eTipoCliente.tipoCliente = dtOrdenLab.Rows[r]["tipoCliente"].ToString();
                        eTipoCliente.descripcion = dtOrdenLab.Rows[r]["descripcion"].ToString();
                        eTipoCliente.orden = 99;
                        eTipoCliente.status = true;
                        eTipoCliente.descuento = 0;
                        RTipoCliente.crearTipoCliente(eTipoCliente);
                    }

                    DataTable dtCliente = RCliente.verificarCliente(dtOrdenLab.Rows[r]["cliente"].ToString());
                    if (dtCliente.Rows.Count == 0)
                    {
                        ECliente ecliente = new ECliente();
                        ecliente.cliente = dtOrdenLab.Rows[r]["cliente"].ToString();
                        ecliente.codigoAlterno = ecliente.cliente;
                        ecliente.nombre = dtOrdenLab.Rows[r]["nombreCliente"].ToString();
                        ecliente.tipoCliente = dtOrdenLab.Rows[r]["tipoCliente"].ToString();
                        RCliente.crearCliente(ecliente);
                    }

                    if(String.IsNullOrEmpty(adm.medico))
                    {
                        adm.medico = "0";
                        adm.nombre = "A QUIERN INTERESE";
                    }
                    DataTable dtMedicos = RMedico.buscarMedico(dtOrdenLab.Rows[r]["Medico"].ToString());
                    if (dtMedicos.Rows.Count == 0)
                    {
                        EMedico emedico = new EMedico();
                        emedico.medico = dtOrdenLab.Rows[r]["Medico"].ToString();
                        emedico.nombre = dtOrdenLab.Rows[r]["nombreMedico"].ToString();
                        emedico.comision = 0;
                        emedico.status = true;
                        RMedico.crearMedico(emedico);
                    }

                    adm.cliente = dtOrdenLab.Rows[r]["Cliente"].ToString();
                    adm.tipoCliente = dtOrdenLab.Rows[r]["TipoCliente"].ToString();
                    adm.sucursal = dtOrdenLab.Rows[r]["Sucursal"].ToString();
                    adm.usuario = "INV_SYS";

                    DataTable dtExisteOrden = RAdmision.verificarAdmision(adm.Admision, adm.tipoAdmision, adm.especialidad, adm.sucursal);

                    if(dtExisteOrden.Rows.Count==0)
                    {
                        if (RAdmision.crearAdmision(adm) > 0)
                        {
                            DataTable dtDetalle = new DataTable();
                            dtDetalle = ROrdenExterna.obtenerDetalle(adm.tipoAdmision, adm.Admision, adm.sucursal);
                            if (dtDetalle.Rows.Count > 0)
                            {
                                for (int j = 0; j < dtDetalle.Rows.Count; j++)
                                {
                                    det.tipoAdmision = adm.tipoAdmision;
                                    det.admision = adm.Admision;
                                    det.especialidad = adm.especialidad;
                                    det.sucursal = adm.sucursal;
                                    det.detalle = Convert.ToInt32(dtDetalle.Rows[j]["LineaOrden"].ToString());
                                    det.servicio = dtDetalle.Rows[j]["CodigoExamen"].ToString();
                                    det.descripcion = dtDetalle.Rows[j]["Examen"].ToString();
                                    det.precio = dtDetalle.Rows[j]["Precio"].ToString();

                                    DataTable dtProducto = RProducto.buscarProducto(det.servicio);
                                    EProducto eproducto = new EProducto();
                                    if (dtProducto.Rows.Count==0)
                                    {                                        
                                        eproducto.producto = det.servicio;
                                        eproducto.descripcion = det.descripcion;
                                        eproducto.proveedor = "N/A";
                                        eproducto.serie = false;
                                        eproducto.fechaCreacion = DateTime.Now;
                                        eproducto.precioCosto = 0;
                                        eproducto.precioVenta = Convert.ToDouble(det.precio);
                                        eproducto.status = true;
                                        eproducto.categoria = "S";
                                        eproducto.fabricante = "OTR";
                                        eproducto.lote = false;
                                        eproducto.orden = 99;
                                        eproducto.activarCobro = true;
                                        RProducto.agregarProducto(eproducto);
                                    }
                                    else
                                    {
                                        eproducto.producto = det.servicio;
                                        eproducto.descripcion = det.descripcion;
                                        eproducto.precioVenta = Convert.ToDouble(det.precio);
                                        RProducto.actualizarProducto(eproducto);
                                    }
                                    RDetalleAdmision.crearDetalleAdmision(det);
                                }
                                ROrdenExterna.eliminarOrden(adm.tipoAdmision, adm.Admision, adm.sucursal);
                            }
                        }
                    } 
                    else
                    {
                        RAdmision.eliminarAdmision(adm.Admision, adm.tipoAdmision, adm.especialidad, adm.sucursal);
                    }
                    
                }
            }

        }

        private void cerrarCajaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            gestionarCaja(userid, "C");
        }

        private void cerrarSesiónToolStripMenuItem_Click(object sender, EventArgs e)
        {
            cerrarSesion();
        }

        private void verSucursalesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SucursalesForm sr = new SucursalesForm();
            sr.ShowDialog();
        }

        private void corteDeCajaToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            gestionarCaja(userid, "P");
        }
    }
}

﻿using INV_SYS.Formularios.ABC;
using INV_SYS.Formularios;
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
        private string sucrusalPc;
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
                sucrusalPc = dtCaja.Rows[0]["sucursal"].ToString();
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
            DataTable dtOrdensLab = RAdmision.laboratorioXFacturar(dtpFPendInicio.Value, dtpFPendFin.Value);
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
                string idAdmision = "";

                dgvFacturas.Rows.Clear();
                for(int r=0; r<dtOrdensLab.Rows.Count;r++)
                {
                    idAdmision = dtOrdensLab.Rows[r]["idAdmision"].ToString();
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
                    dgvFacturas.Rows.Add(idAdmision, admision, tipoAdmision,paciente,fechaIngreso,total.ToString("C2"),"",idEspcialidad,especialidad,idTipoPaciente,tipoPaciente,status,idSucursal);
                }
            }
            else
            {
                dgvFacturas.Rows.Clear();
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
            DataTable dtClientes = RCliente.listarClientesInstitucion();
            if(dtClientes.Rows.Count>0)
            {
                cmbClientes.DataSource = dtClientes;
                cmbClientes.DisplayMember = "Descripcion";
                cmbClientes.ValueMember = "NIT";
            }
            
        }
        private void btnGenerarFacturaInstitucion_Click(object sender, EventArgs e)
        {
            string total = lblTotalFactura.Text.Replace("Q", "");
            List<string> idOrdenes = new List<string>();
            List<string> ordenes = new List<string>();
            for(int r =0; r< dgvOrdenInstitucion.Rows.Count; r++)
            {
                string _orden = dgvOrdenInstitucion.Rows[r].Cells["noOrdenI"].Value.ToString();
                ordenes.Add(_orden);

                string _idOrden = dgvOrdenInstitucion.Rows[r].Cells["idAdmisionI"].Value.ToString();
                idOrdenes.Add(_idOrden);
            }

            frmDocumento frmDoc = new frmDocumento(userid, sucrusalPc, "I", Convert.ToDouble(total),cmbClientes.SelectedValue.ToString(),ordenes, idOrdenes);
            frmDoc.ShowDialog(this);
        }

        private void seleccionarAdmision()
        {
            string admision = "";
            string tipoAdmision = "";
            string idEspecialidad = "";
            string _idSucursal = "";
            string _cliente = "";
            if (dgvFacturas.SelectedRows.Count==1)
            {
                admision = dgvFacturas.CurrentRow.Cells["noOrden"].Value.ToString();
                tipoAdmision = dgvFacturas.CurrentRow.Cells["TipoAdmision"].Value.ToString();
                idEspecialidad = dgvFacturas.CurrentRow.Cells["IdEspecialidad"].Value.ToString();
                _idSucursal = dgvFacturas.CurrentRow.Cells["idSucursal"].Value.ToString();
                _cliente = dgvFacturas.CurrentRow.Cells["cliente"].Value.ToString();
                frmAdmision _frmAdmision = new frmAdmision(admision, tipoAdmision, idEspecialidad,_idSucursal,_cliente);
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

        private void facturarAdmision() //factura individual
        {
            string admision = "";
            string tipoAdmision = "";
            string idEspecialidad = "";
            string idSucursal = "";
            string idAdmision = "";

            if (dgvFacturas.SelectedRows.Count == 1)
            {
                idAdmision = dgvFacturas.CurrentRow.Cells["idAdmision"].Value.ToString();
                admision = dgvFacturas.CurrentRow.Cells["noOrden"].Value.ToString();
                tipoAdmision = dgvFacturas.CurrentRow.Cells["TipoAdmision"].Value.ToString();
                idEspecialidad = dgvFacturas.CurrentRow.Cells["IdEspecialidad"].Value.ToString();
                idSucursal = dgvFacturas.CurrentRow.Cells["idSucursal"].Value.ToString();
                frmDocumento _frmDocumento = new frmDocumento(admision, tipoAdmision, idEspecialidad,userid,idSucursal,"",idAdmision);
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
                    DataTable dtTipoAdmision = RTipoAdmision.buscarTipoAdmision(adm.tipoAdmision);
                    if(dtTipoAdmision.Rows.Count==0)
                    {
                        ETipoAdmision etipoadmision = new ETipoAdmision();
                        etipoadmision.tipoAdmision = adm.tipoAdmision;
                        etipoadmision.descripcion = dtOrdenLab.Rows[r]["Sucursal"].ToString();
                        etipoadmision.orden = 99;
                        etipoadmision.status = true;
                        RTipoAdmision.crearTipoAdmision(etipoadmision);
                    }
                    DataTable dtSucursal = RSucursal.buscarSucursal(adm.tipoAdmision);
                    if(dtSucursal.Rows.Count==0)
                    {
                        ESucursal esucursal = new ESucursal();
                        esucursal.sucursal = adm.tipoAdmision;
                        esucursal.nombre = dtOrdenLab.Rows[r]["Sucursal"].ToString();
                        esucursal.status = true;
                        esucursal.orden = 99;
                        RSucursal.crearSucursal(esucursal);
                    }
                    adm.especialidad = "LABO";
                    adm.fechaRecepcion = Convert.ToDateTime(dtOrdenLab.Rows[r]["FechaRecepcion"].ToString());
                    adm.paciente = dtOrdenLab.Rows[r]["paciente"].ToString();//
                    adm.nombre = dtOrdenLab.Rows[r]["Nombre"].ToString()+" "+ dtOrdenLab.Rows[r]["PrimerApellido"].ToString()+" "+ dtOrdenLab.Rows[r]["SegundoApellido"].ToString(); ;
                    adm.sexo = dtOrdenLab.Rows[r]["Sexo"].ToString();
                    adm.fechaNacimiento = Convert.ToDateTime(dtOrdenLab.Rows[r]["FechaNacimiento"].ToString());
                    adm.medico = dtOrdenLab.Rows[r]["Medico"].ToString(); 
                    adm.nombreMedico = dtOrdenLab.Rows[r]["NombreMedico"].ToString();

                    if(!string.IsNullOrEmpty(dtOrdenLab.Rows[r]["tipoCliente"].ToString()))
                    {
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
                    }

                    if (!string.IsNullOrEmpty(dtOrdenLab.Rows[r]["cliente"].ToString()))
                    {
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
                    }
                    

                    if(String.IsNullOrEmpty(adm.medico))
                    {
                        adm.medico = "0";
                        adm.nombreMedico = "A QUIERN INTERESE";
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
                    adm.sucursal = dtOrdenLab.Rows[r]["TipoOrden"].ToString();
                    adm.usuario = "INV_SYS";

                    //  no se utiliza porque pueden haber duplicados
                    DataTable dtExisteOrden = RAdmision.verificarAdmision(adm.Admision, adm.tipoAdmision, adm.especialidad, adm.sucursal, adm.cliente);

                    if (dtExisteOrden.Rows.Count == 0)
                    {
                        if (RAdmision.crearAdmision(adm) > 0)
                        {
                            DataTable admisionCreada = RAdmision.verificarAdmision(adm.Admision, adm.tipoAdmision, adm.especialidad, adm.sucursal, adm.cliente);
                           
                            DataTable dtDetalle = new DataTable();
                            dtDetalle = ROrdenExterna.obtenerDetalle(adm.tipoAdmision, adm.Admision, adm.sucursal, adm.cliente);
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
                                    det.venta = dtDetalle.Rows[j]["Precio"].ToString();
                                    det.idAdmision = admisionCreada.Rows[0]["idAdmision"].ToString();

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
                                ROrdenExterna.eliminarOrden(adm.tipoAdmision, adm.Admision, adm.sucursal, adm.cliente);
                            }
                        }
                    }
                    //else
                    //{
                    //    RAdmision.eliminarAdmision(adm.Admision, adm.tipoAdmision, adm.especialidad, adm.sucursal);
                    //}                    
                }
            }
            //cargarLaboratorios();

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

        private void ordenInstitucion(DateTime fInicio, DateTime fFin, string institucion)
        {
            DataTable dtLabInstitucion = RAdmision.laboratoriosInstitucion(fInicio, fFin, institucion);
            if (dtLabInstitucion.Rows.Count > 0)
            {
                
                string admision = "";
                string tipoAdmision = "";
                string paciente = "";
                string fechaIngreso = "";
                decimal total = 0;
                string idEspcialidad = "";
                string especialidad = "";
                string idTipoPaciente = "";
                string tipoPaciente = "";
                string status = "";
                string idSucursal = "";
                string idAdmisionI = "";
                decimal granTotal=0;
                dgvOrdenInstitucion.Rows.Clear();
                for (int r = 0; r < dtLabInstitucion.Rows.Count; r++)
                {
                    idAdmisionI = dtLabInstitucion.Rows[r]["idAdmision"].ToString();
                    admision = dtLabInstitucion.Rows[r]["Admision"].ToString();
                    tipoAdmision = dtLabInstitucion.Rows[r]["tipoAdmision"].ToString();
                    paciente = dtLabInstitucion.Rows[r]["Nombre"].ToString();
                    fechaIngreso = dtLabInstitucion.Rows[r]["FechaRecepcion"].ToString();
                    idEspcialidad = dtLabInstitucion.Rows[r]["IdEspecialidad"].ToString();
                    especialidad = dtLabInstitucion.Rows[r]["Especialidad"].ToString();
                    idTipoPaciente = dtLabInstitucion.Rows[r]["idTipoPaciente"].ToString();
                    tipoPaciente = dtLabInstitucion.Rows[r]["tipoPaciente"].ToString();
                    status = dtLabInstitucion.Rows[r]["status"].ToString();
                    total = Convert.ToDecimal(dtLabInstitucion.Rows[r]["Total"].ToString());
                    idSucursal = dtLabInstitucion.Rows[r]["sucursal"].ToString();
                    dgvOrdenInstitucion.Rows.Add(idAdmisionI,admision, tipoAdmision, paciente, fechaIngreso, total.ToString("C2"), "", idEspcialidad, especialidad, idTipoPaciente, tipoPaciente, status, idSucursal);
                    granTotal += total;
                }
                lblTotalFactura.Text = granTotal.ToString("C2");
            }
            else
            {
                dgvOrdenInstitucion.Rows.Clear();
            }
        }
        private void btnBuscarOrden_Click(object sender, EventArgs e)
        {
            ordenInstitucion(dtpFechaInicial.Value, dtpFechaFinal.Value, cmbClientes.SelectedValue.ToString());
            lblCantidadOrden.Text = " "+ dgvOrdenInstitucion.Rows.Count;
        }

        private void btnBuscarFacturasPendientes_Click(object sender, EventArgs e)
        {
            cargarLaboratorios();
        }

        private void tabControl1_Selected(object sender, TabControlEventArgs e)
        {
            //Se envía a activación del componente correcto:

            //cargarClientes();
            //cargarFacturas();
            cargarProveedores();
            cargarGastos();
        }

        private void tpInstituciones_Enter(object sender, EventArgs e)
        {
            //MessageBox.Show("entra a instituciones");
            cargarClientes();
            //cargarFacturas();
            //cargarProveedores();
            //cargarGastos();
        }

        private void tpFacturar_Enter(object sender, EventArgs e)
        {
            //MessageBox.Show("entra a facturas");
            cargarFacturas();
        }

        private void btnReimprimirFactura_Click(object sender, EventArgs e)
        {
            int tipoImpresion = 1;// Tipo 1= Impresion de facturas
            string tipoDocumento = "";
            string serieDocumento = "";
            string documento = "";
            string sucursal = "";
            if (dgvFacturasEmitidas.SelectedRows.Count==1)
            {
                tipoDocumento = "F";
                serieDocumento = dgvFacturasEmitidas.CurrentRow.Cells["serie"].Value.ToString();
                documento = dgvFacturasEmitidas.CurrentRow.Cells["documento"].Value.ToString();
                sucursal = dgvFacturasEmitidas.CurrentRow.Cells["sucursal"].Value.ToString();
                imprimirFactura(tipoImpresion,tipoDocumento,serieDocumento,documento,sucursal);
            }
        }

        public void imprimirFactura(int tipoImpresion, string tipoDocumento,string serieDocumento, string documento, string sucursal )
        {
            frmImpresionDocumento imprimir = new frmImpresionDocumento(tipoImpresion,tipoDocumento, serieDocumento, documento, sucursal);
            imprimir.ShowDialog(this);
        }
    }
}

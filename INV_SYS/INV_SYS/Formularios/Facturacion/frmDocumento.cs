using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using System.Drawing.Imaging;
using Newtonsoft.Json;
//using GoEmail;
using System.Xml;
using System.Net;
using System.Net.Sockets;
using INV_SYS.Formularios;

namespace INV_SYS
{
    public partial class frmDocumento : Form
    {
        private string admision;
        private string tipoAdmision;
        private string especialidad;
        private string user;
        private string tipo;
        private string documento;
        private string sucursal;
        private string serie;
        private string estacion;
        private string rutaFELQR;
        private string idSucursal;
        private string modo;
        private string idCliente;
        private double totalInstitucion;
        private string idAdmision;
        private List<string> ordenes;
        private List<string> idOrdenes;

        public frmDocumento(string admision, string tipoAdmision, string especialidad, string user, string idSucursal,string modo, string idAdmision)
        {
            InitializeComponent();
            this.admision = admision;
            this.tipoAdmision = tipoAdmision;
            this.especialidad = especialidad;
            this.user = user;
            this.idSucursal = idSucursal;
            this.modo = modo;
            this.idAdmision = idAdmision;
            estacion = Environment.MachineName;
            iniciarCargarCombos();
            cargarAdmision();
        }
        //Facturar por institucion
        public frmDocumento(string user, string idSucursal, string modo, double totalInstitucion, string idCliente, List<string>ordenes, List<string> idOrdenes)
         {
            InitializeComponent();
            this.user = user;
            this.idSucursal = idSucursal;
            this.modo = modo;
            this.idCliente = idCliente;
            this.totalInstitucion = totalInstitucion;
            estacion = Environment.MachineName;
            this.ordenes = ordenes;
            this.idOrdenes = idOrdenes;

            iniciarCargarCombos();
            cargarServicio();
            cargarDatosInstitucion();
        }

        private void cargarDatosInstitucion()
        {
            DataTable dtInstitucion = RCliente.verificarCliente(idCliente);
            if (dtInstitucion.Rows.Count > 0)
            {
                txtNit.Text = dtInstitucion.Rows[0]["cliente"].ToString();
                txtNombre.Text = dtInstitucion.Rows[0]["Nombre"].ToString();
                txtDireccion.Text = dtInstitucion.Rows[0]["Direccion"].ToString();
            }
            else
            {
                MessageBox.Show("No se encontro insitución","Alerta", MessageBoxButtons.OK,MessageBoxIcon.Warning);
            }
        }

        private void cargarServicio()
        {
            int linea = 1;
            int cantidad = 1;
            string idProducto = "";
            string descripcion = "";
            double precio = 0;
            double subTotal = 0;
            DataTable dtConfig = RParametros.VerificarConfiguracion("FAC", "ConceptoFacturaInstitucion");
            if (dtConfig.Rows.Count > 0)
            {
                idProducto = dtConfig.Rows[0]["valorString"].ToString();
                DataTable dtProducto = RProducto.buscarProducto(idProducto);
                descripcion = dtProducto.Rows[0]["descripcion"].ToString();
                precio = totalInstitucion;
                subTotal = cantidad * totalInstitucion;
                dgvDetalle.Rows.Add(linea,cantidad,idProducto,descripcion,precio,subTotal);
                lblGranTotal.Text = subTotal.ToString("C2");
            }
            else
            {
                MessageBox.Show("Configure el codigo del servicio a facturar en los parametros del sistema", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }            
        }

        public frmDocumento(string tipo, string serie,string documento, string sucursal, string user)
        {
            InitializeComponent();
            this.tipo = tipo;
            this.documento = documento;
            this.idSucursal = sucursal;
            this.serie = serie;
            this.user = user;
            iniciarCargarCombos();
            cargarAdmision();
            cargarDocumento(tipo, serie,documento, sucursal);
        }

        private void cargarDocumento(string tipoDocumento, string serie,string documento, string idSucursal)
        {
            DataTable dtInfoDocumento = new DataTable();
            dtInfoDocumento = RDocumento.verificarInfoDocumento(tipoDocumento,serie,idSucursal,documento);
            if(dtInfoDocumento.Rows.Count>0)
            {
                int linea = 0;
                int cantidad = 1;
                string estudio = "";
                string descripcion = "";
                decimal precio = 0;
                decimal subTotal = 0;
                decimal granTotal = 0;
                cmbSucursal.SelectedValue = dtInfoDocumento.Rows[0]["sucursal"].ToString();
                cmbSerieInterna.SelectedValue = dtInfoDocumento.Rows[0]["serieDocumento"].ToString();
                txtNombre.Text = dtInfoDocumento.Rows[0]["cliente"].ToString();
                txtNit.Text = dtInfoDocumento.Rows[0]["nit"].ToString();
                cmbFormaPago.SelectedValue = dtInfoDocumento.Rows[0]["formaPago"].ToString();
                cmbTipoPago.SelectedValue = dtInfoDocumento.Rows[0]["tipoPago"].ToString();
                lblNoDocumento.Text = dtInfoDocumento.Rows[0]["NoDocumento"].ToString();
                for (int j=0; j<dtInfoDocumento.Rows.Count; j++ )
                {
                    linea = Convert.ToInt32(dtInfoDocumento.Rows[j]["detalle"].ToString());
                    cantidad = Convert.ToInt32(dtInfoDocumento.Rows[j]["cantidad"].ToString());
                    estudio = dtInfoDocumento.Rows[j]["codigo"].ToString();
                    descripcion = dtInfoDocumento.Rows[j]["descripcion"].ToString();
                    precio = Convert.ToDecimal(dtInfoDocumento.Rows[j]["PrecioVenta"].ToString());
                    subTotal = cantidad * precio;
                    dgvDetalle.Rows.Add(linea, cantidad, estudio, descripcion, precio.ToString("C2"), subTotal.ToString("C2"));
                    granTotal += subTotal;
                }
                cmbTipoPago.Enabled = false;
                cmbFormaPago.Enabled = false;
                btnGenerarFactura.Enabled = false;
                txtDireccion.Enabled = false;
                txtNit.Enabled = false;
                txtNombre.Enabled = false;
                lblGranTotal.Text = granTotal.ToString("C2");
            }
        }

        private void iniciarCargarCombos()
        {
            cargarSucursal();
            cargarSerie();
            cargarFormaPago();
            cargarMetodoPago();
        }

        private void cargarAdmision()
        {
            DataTable dtAdmision = RAdmision.obtenerAdmision(admision, tipoAdmision, especialidad,idSucursal, "");
            if(dtAdmision.Rows.Count>0)
            {
                int linea=0;
                int cantidad = 1;
                string estudio = "";
                string descripcion = "";
                decimal precio=0;
                decimal subTotal = 0;
                decimal granTotal = 0;
                string idCliente = "";
                string tipoCliente = "";
                idCliente = dtAdmision.Rows[0]["cliente"].ToString();
                tipoCliente = dtAdmision.Rows[0]["tipoCliente"].ToString();
                if(String.IsNullOrEmpty(idCliente))
                {
                    txtNombre.Text = dtAdmision.Rows[0]["nombre"].ToString();
                }
                else
                {
                    DataTable dtCliente = RCliente.buscarCliente(idCliente);
                    if(dtCliente.Rows.Count>0)
                    {
                        txtNit.Text = dtCliente.Rows[0]["NIT"].ToString();
                        txtNombre.Text = dtCliente.Rows[0]["cliente"].ToString();
                        txtDireccion.Text = dtCliente.Rows[0]["direccion"].ToString();
                    }
                }
                
                for(int r=0; r<dtAdmision.Rows.Count;r++)
                {
                    linea= r + 1;
                    cantidad = Convert.ToInt32(dtAdmision.Rows[r]["cantidad"].ToString());
                    estudio = dtAdmision.Rows[r]["servicio"].ToString();
                    descripcion = dtAdmision.Rows[r]["Estudio"].ToString();
                    precio = Convert.ToDecimal(dtAdmision.Rows[r]["venta"].ToString());                    
                    subTotal = cantidad * precio;
                    dgvDetalle.Rows.Add(linea, cantidad, estudio, descripcion, precio.ToString("C2"),subTotal.ToString("C2"));
                    granTotal += subTotal;
                }
                lblGranTotal.Text = granTotal.ToString("C2");
            }
        }

        private void cargarSucursal()
        {
            cmbSucursal.DataSource = RSucursal.listarSucursales();
            cmbSucursal.DisplayMember = "nombre";
            cmbSucursal.ValueMember = "Sucursal";
        }

        private void cargarSerie()
        {
            cmbSerieInterna.DataSource = RSerie.listarSerieDocumento();
            cmbSerieInterna.DisplayMember = "descripcion";
            cmbSerieInterna.ValueMember = "serieDocumento";
        }

        private void cargarFormaPago()
        {
            cmbTipoPago.DataSource = RTipoPago.listarTipoPago();
            cmbTipoPago.DisplayMember = "descripcion";
            cmbTipoPago.ValueMember = "tipoPago";
        }


        private void cargarMetodoPago()
        {
            cmbFormaPago.DataSource = RFormaPago.listarFormasDePagoVigente();
            cmbFormaPago.DisplayMember = "descripcion";
            cmbFormaPago.ValueMember = "formaPago";
        }
        private void guardarDocumento()
        {
            EDocumento documento = new EDocumento();
            EDetalleDocumento detalle = new EDetalleDocumento();
            DataTable dt = new DataTable();
            dt = RDocumento.ultimoDocumento("F", cmbSerieInterna.SelectedValue.ToString(), cmbSucursal.SelectedValue.ToString());
            if(dt.Rows.Count>0)
            {
                documento.NoDocumento = Convert.ToInt32(dt.Rows[0]["ultimoDocumento"].ToString()) + 1;
            }
            else
            {
                documento.NoDocumento = 1;
            }
            documento.SerieDocumento = cmbSerieInterna.SelectedValue.ToString();
            documento.sucursal = cmbSucursal.SelectedValue.ToString();
            documento.tipoDocumento = "F";            
            documento.fechaCreacion = DateTime.Now;
            documento.cliente = txtNit.Text;
            if(String.IsNullOrEmpty(documento.cliente))
            {
                txtNit.Text = "C/F";
                documento.cliente = "C/F";
            }

            DataTable dtCliente = RCliente.verificarCliente(txtNit.Text);
            if(dtCliente.Rows.Count==0)
            {
                ECliente cliente = new ECliente();
                cliente.cliente = txtNit.Text;
                cliente.codigoAlterno = txtNit.Text;
                cliente.nombre = txtNombre.Text;
                cliente.direccion = txtDireccion.Text;
                RCliente.crearCliente(cliente);
            }
            documento.Nombre = txtNombre.Text;
            documento.Status = true;
            documento.usuario = user;
            documento.referencia = admision;
            documento.tipoReferencia = tipoAdmision;
            documento.especialidad = "LABO";
            documento.FEL = false;
            documento.tipoPago = cmbTipoPago.SelectedValue.ToString();
            documento.formaPago = cmbFormaPago.SelectedValue.ToString();
            documento.proceso = "F"; //Proceso del documento F= Facturado
            if(RDocumento.crearDocumento(documento)==1)
            {
                for (int j = 0; j < dgvDetalle.Rows.Count-1; j++)
                {
                    detalle.sucursal = documento.sucursal;
                    detalle.tipoDocumento = documento.tipoDocumento;
                    detalle.serieDocumento = documento.SerieDocumento;
                    detalle.NoDocumento = documento.NoDocumento;
                    detalle.detalle = Convert.ToInt32(dgvDetalle.Rows[j].Cells["linea"].Value);
                    detalle.producto = dgvDetalle.Rows[j].Cells["Estudio"].Value.ToString();
                    detalle.descripcion = dgvDetalle.Rows[j].Cells["descripcion"].Value.ToString();
                    detalle.cantidad = Convert.ToDouble(dgvDetalle.Rows[j].Cells["cantidad"].Value);
                    var montoFormato = dgvDetalle.Rows[j].Cells["Precio"].Value.ToString().Replace("Q","");
                    detalle.precioVenta = Convert.ToDouble(montoFormato);
                    detalle.status = true;
                    detalle.fechaCreacion = DateTime.Now;
                    lblNoDocumento.Text = documento.NoDocumento.ToString();
                    if( RDetalleDocumento.crearDetalleDocumento(detalle)>0)
                    {
                        //F = admision Facturada                        
                    }
                }
                if (registrarIngreso())
                {
                    if(enviarFactura(documento.sucursal,documento.tipoDocumento,documento.NoDocumento.ToString(),documento.SerieDocumento)>0)
                    {
                        if(modo.CompareTo("I")==0)
                        {
                            string _tipoAdmision = "";
                            string _admision = "";
                            string _cliente = documento.cliente;
                            string _idOrden = "";
                            for (int r=0; r< ordenes.Count; r++)
                            {
                                _tipoAdmision = idSucursal;
                                _admision = ordenes[r];
                                _idOrden = idOrdenes[r];

                                RAdmision.cambiarStatusAdmisionInstitucion(_tipoAdmision, _admision, "LABO", "F", false, cmbSucursal.SelectedValue.ToString(), _cliente, _idOrden);
                            }
                            MessageBox.Show("Ordenes facturadas con exito", "Alerta", MessageBoxButtons.OK, MessageBoxIcon.Information);

                            this.Close();
                        }
                        else
                        {
                            if (RAdmision.cambiarStatusAdmision(tipoAdmision, admision, "LABO", "F", false, cmbSucursal.SelectedValue.ToString(), this.idAdmision) > 0)
                                MessageBox.Show("Orden: " + admision + " Facturada con exito", "Alerta", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }                        
                    }
                    frmImpresionDocumento imprimir = new frmImpresionDocumento(1, documento.tipoDocumento, documento.SerieDocumento, documento.NoDocumento.ToString(), documento.sucursal);
                    imprimir.ShowDialog(this);
                }

            }            
        }

        private int enviarFactura(string sucursal, string tipoDocumento, string NoDocumento, string serieDocumento)
        {
            string usuarioFirmaFEL;
            string llaveFirmaFEL;
            string usuarioApiFEL;
            string llaveApiFEL;
            string identificadorFEL;
            string idOrigenFEL;
            string ipFEL;
            string firmaEmisorFEL;
            string serieFel;
            string numeroFel;
            string codigoEstablecimientoFEL;
            string nitEmisorFEL;
            string nombreComercialEmisorFEL;
            string nombreEmisorFEL;
            string direccionEmisorFEL;
            string codigoPostalEmisorFEL;
            string municipioEmisorFEL;
            string departamentoEmisorFEL;
            string codigoEscenarioFEL;
            string codigoFraseFEL;
            string xmlWSFel;
            DateTime fechaHoraEmision;
            string XML = string.Empty;
            StringBuilder sbXML = new StringBuilder();
            DataTable dtPermiso = new DataTable();

            dtPermiso = RParametros.VerificarConfiguracion("FEL", "LLaveFirmaFEL");
            llaveFirmaFEL = dtPermiso.Rows[0]["valorString"].ToString();

            dtPermiso = RParametros.VerificarConfiguracion("FEL", "usuarioFirmaFEL");
            usuarioFirmaFEL = dtPermiso.Rows[0]["valorString"].ToString();

            dtPermiso = RParametros.VerificarConfiguracion("FEL", "usuarioApiFEL");
            usuarioApiFEL = dtPermiso.Rows[0]["valorString"].ToString();

            dtPermiso = RParametros.VerificarConfiguracion("FEL", "LLaveApiFEL");
            llaveApiFEL = dtPermiso.Rows[0]["valorString"].ToString();

            dtPermiso = RParametros.VerificarConfiguracion("FEL", "codigoEstablecimientoFEL");
            codigoEstablecimientoFEL = dtPermiso.Rows[0]["valorString"].ToString();

            dtPermiso = RParametros.VerificarConfiguracion("FEL", "nitEmisorFEL");
            nitEmisorFEL = dtPermiso.Rows[0]["valorString"].ToString();

            dtPermiso = RParametros.VerificarConfiguracion("FEL", "nombreEmisorFEL");
            nombreEmisorFEL = dtPermiso.Rows[0]["valorString"].ToString();

            dtPermiso = RParametros.VerificarConfiguracion("FEL", "nombreComercialEmisorFEL");
            nombreComercialEmisorFEL = dtPermiso.Rows[0]["valorString"].ToString();

            dtPermiso = RParametros.VerificarConfiguracion("FEL", "direccionEmisorFEL");
            direccionEmisorFEL = dtPermiso.Rows[0]["valorString"].ToString();

            dtPermiso = RParametros.VerificarConfiguracion("FEL", "codigoPostalEmisorFEL");
            codigoPostalEmisorFEL = dtPermiso.Rows[0]["valorString"].ToString();

            dtPermiso = RParametros.VerificarConfiguracion("FEL", "municipioEmisorFEL");
            municipioEmisorFEL = dtPermiso.Rows[0]["valorString"].ToString();

            dtPermiso = RParametros.VerificarConfiguracion("FEL", "departamentoEmisorFEL");
            departamentoEmisorFEL = dtPermiso.Rows[0]["valorString"].ToString();

            dtPermiso = RParametros.VerificarConfiguracion("FEL", "codigoEscenarioFEL");
            codigoEscenarioFEL = dtPermiso.Rows[0]["valorString"].ToString();

            dtPermiso = RParametros.VerificarConfiguracion("FEL", "codigoFraseFEL");
            codigoFraseFEL = dtPermiso.Rows[0]["valorString"].ToString();

            dtPermiso = RParametros.VerificarConfiguracion("FEL", "XmlWsFEL");
            xmlWSFel = dtPermiso.Rows[0]["valorString"].ToString();
            // string XmlnsFactura = Properties.Settings.Default.WsFEL     
            string XmlnsFactura = xmlWSFel;
            string localIP = string.Empty;
            using (Socket socket = new Socket(AddressFamily.InterNetwork, SocketType.Dgram, 0))
            {
                socket.Connect("8.8.8.8", 65530);
                IPEndPoint endPoint = socket.LocalEndPoint as IPEndPoint;
                localIP = endPoint.Address.ToString();
                ipFEL = localIP;
            }
            DataTable dtFEL = RDocumento.verificarDocumentoFEL(tipoDocumento, serieDocumento, sucursal, NoDocumento);
            if (dtFEL.Rows.Count > 0)
            {
                fechaHoraEmision = DateTime.Now;
                var fechaEmisionFEL = String.Format("{0:s}", fechaHoraEmision);
                try
                {
                    sbXML.Append("<?xml version=\"1.0\" encoding=\"UTF-8\"?>");
                    sbXML.AppendLine();
                   /* sbXML.Append("< dte:GTDocumento Version = \"0.1\" \nxmlns: dte = \"http://www.sat.gob.gt/dte/fel/0.2.0\" \nxmlns: cfc = \"http://www.sat.gob.gt/dte/fel/CompCambiaria/0.1.0\" \nxmlns: cex = \"http://www.sat.gob.gt/face2/ComplementoExportaciones/0.1.0\" \nxmlns: cfe = \"http://www.sat.gob.gt/face2/ComplementoFacturaEspecial/0.1.0\" \nxmlns: cno = \"http://www.sat.gob.gt/face2/ComplementoReferenciaNota/0.1.0\"\nxmlns: ds = \"http://www.w3.org/2000/09/xmldsig#\" \nxmlns: xsi = \"http://www.w3.org/2001/XMLSchema-instance\" > ");
                    sbXML.AppendLine();*/
                    sbXML.Append("<dte:GTDocumento xmlns:ds=\"http://www.w3.org/2000/09/xmldsig#\" xmlns:dte=\"http://www.sat.gob.gt/dte/fel/0.2.0\" xmlns:xsi =\"http://www.w3.org/2001/XMLSchema-instance\"   Version =\"0.1\"   xsi:schemaLocation=\"http://www.sat.gob.gt/dte/fel/0.2.0\">");
                    sbXML.AppendLine();
                    sbXML.Append(" <dte:SAT ClaseDocumento=\"dte\">");
                    sbXML.AppendLine();
                    sbXML.Append("   <dte:DTE ID=\"DatosCertificados\">");
                    sbXML.AppendLine();
                    sbXML.Append("     <dte:DatosEmision ID=\"DatosEmision\">");
                    sbXML.AppendLine();
                    sbXML.AppendFormat("       <dte:DatosGenerales CodigoMoneda=\"GTQ\" FechaHoraEmision=\"{0}\" Tipo=\"{1}\"></dte:DatosGenerales>", fechaEmisionFEL, "FACT");
                    sbXML.AppendLine();

                    //EMISOR
                    sbXML.AppendFormat("       <dte:Emisor AfiliacionIVA=\"GEN\" CodigoEstablecimiento=\"{0}\" NITEmisor=\"{1}\" NombreComercial=\"{2}\" NombreEmisor=\"{3}\">", codigoEstablecimientoFEL, nitEmisorFEL, nombreComercialEmisorFEL, nombreEmisorFEL);
                    sbXML.AppendLine();
                    //CUERPO EMISOR
                    sbXML.Append("          <dte:DireccionEmisor>");
                    sbXML.AppendLine();
                    sbXML.AppendFormat("            <dte:Direccion>{0}</dte:Direccion>", direccionEmisorFEL);
                    sbXML.AppendLine();
                    sbXML.AppendFormat("            <dte:CodigoPostal>{0}</dte:CodigoPostal>", codigoPostalEmisorFEL);
                    sbXML.AppendLine();
                    sbXML.AppendFormat("            <dte:Municipio>{0}</dte:Municipio>", municipioEmisorFEL);
                    sbXML.AppendLine();
                    sbXML.AppendFormat("            <dte:Departamento>{0}</dte:Departamento>", departamentoEmisorFEL);
                    sbXML.AppendLine();
                    sbXML.AppendFormat("            <dte:Pais>{0}</dte:Pais>", "GT");
                    sbXML.AppendLine();
                    sbXML.Append("          </dte:DireccionEmisor>");
                    sbXML.AppendLine();
                    //FIN CUERPO EMISOR                      
                    sbXML.Append("       </dte:Emisor>");
                    sbXML.AppendLine();
                    //FIN EMISOR

                    //DATOS DEL CLIENTE
                    string NitCliente = dtFEL.Rows[0]["NIT"].ToString().Replace("-", "");
                    string NombreCliente = dtFEL.Rows[0]["Cliente"].ToString();
                    string Direccioncliente = dtFEL.Rows[0]["direccion"].ToString();
                    if (String.IsNullOrEmpty(Direccioncliente))
                        Direccioncliente = txtDireccion.Text;
                    if (String.IsNullOrEmpty(NombreCliente))
                        NombreCliente = txtNombre.Text;
                    if (String.IsNullOrEmpty(NitCliente))
                        NitCliente = txtNit.Text;

                    if (NitCliente.Equals("CF") || NitCliente.Equals("cf") || NitCliente.Equals("C/F") || NitCliente.Equals("C.F."))
                    {
                        NitCliente = "CF";
                        NombreCliente = "CONSUMIDOR FINAL";
                        Direccioncliente = "CIUDAD";
                    }

                    //RECEPTOR
                    sbXML.AppendFormat("       <dte:Receptor CorreoReceptor=\"\" IDReceptor=\"{0}\" NombreReceptor=\"{1}\">", NitCliente, NombreCliente);
                    sbXML.AppendLine();
                    //CUERPO RECEPTOR
                    sbXML.Append("          <dte:DireccionReceptor>");
                    sbXML.AppendLine();
                    sbXML.AppendFormat("            <dte:Direccion>{0}</dte:Direccion>", Direccioncliente);
                    sbXML.AppendLine();
                    sbXML.AppendFormat("            <dte:CodigoPostal>{0}</dte:CodigoPostal>", codigoPostalEmisorFEL);
                    sbXML.AppendLine();
                    sbXML.AppendFormat("            <dte:Municipio>{0}</dte:Municipio>", municipioEmisorFEL);
                    sbXML.AppendLine();
                    sbXML.AppendFormat("            <dte:Departamento>{0}</dte:Departamento>", departamentoEmisorFEL);
                    sbXML.AppendLine();
                    sbXML.AppendFormat("            <dte:Pais>{0}</dte:Pais>", "GT");
                    sbXML.AppendLine();
                    sbXML.Append("          </dte:DireccionReceptor>");
                    sbXML.AppendLine();
                    //FIN CUERPO RECEPTOR                      
                    sbXML.Append("       </dte:Receptor>");
                    sbXML.AppendLine();
                    //FIN RECEPTOR

                    //FRASES
                    sbXML.Append("       <dte:Frases>");
                    sbXML.AppendLine();
                    //CUERPO FRASES
                    sbXML.AppendFormat("         <dte:Frase CodigoEscenario=\"{0}\" TipoFrase=\"{1}\"></dte:Frase>", codigoEscenarioFEL, codigoFraseFEL);
                    //FIN CUERPO FRASES
                    sbXML.AppendLine();
                    sbXML.Append("       </dte:Frases>");
                    sbXML.AppendLine();
                    //FIN FRASES

                    //ITEMS
                    sbXML.Append("       <dte:Items>");
                    sbXML.AppendLine();
                    //CUERPO ITEMS
                    decimal dTotal = 0;
                    decimal precioVenta = 0;
                    int cantidad = 0;

                    for (int x = 0; x < dtFEL.Rows.Count; x++)
                    {
                        precioVenta = 0;
                        cantidad = 0;
                        cantidad = Convert.ToInt32(dtFEL.Rows[x]["cantidad"].ToString());
                        precioVenta = decimal.Parse(dtFEL.Rows[x]["precioVenta"].ToString());
                        dTotal += cantidad * precioVenta;
                    }

                    decimal dTotalImpuesto = 0;
                    string categoriaFel = "";
                    int Linea = 1;
                    for (int z = 0; z < dtFEL.Rows.Count; z++)
                    {
                        categoriaFel = "";
                        categoriaFel = dtFEL.Rows[z]["categoria"].ToString();
                        if (categoriaFel.CompareTo("S") == 0)
                            categoriaFel = "S";
                        else
                            categoriaFel = "B";
                        decimal lTotalxArticulo = decimal.Round(int.Parse(dtFEL.Rows[z]["cantidad"].ToString()) * decimal.Parse(dtFEL.Rows[z]["precioVenta"].ToString()), 4);
                        decimal lTotalxArticuloSinIva = decimal.Round((lTotalxArticulo / decimal.Parse("1.12")), 4);
                        decimal lIva = decimal.Round(((int.Parse(dtFEL.Rows[z]["cantidad"].ToString()) * decimal.Parse(dtFEL.Rows[z]["precioVenta"].ToString())) / decimal.Parse("1.12")), 4);
                        decimal lTotalxArticuloIva = decimal.Round(lTotalxArticulo - lIva, 4);
                        dTotalImpuesto += lTotalxArticuloIva;

                        sbXML.AppendFormat("         <dte:Item BienOServicio=\"{1}\" NumeroLinea=\"{0}\">", Linea, "" + categoriaFel + "");
                        sbXML.AppendLine();
                        sbXML.AppendFormat("           <dte:Cantidad>{0}</dte:Cantidad>", decimal.Round(int.Parse(dtFEL.Rows[z]["cantidad"].ToString()), 4));
                        sbXML.AppendLine();
                        sbXML.AppendFormat("           <dte:UnidadMedida>{0}</dte:UnidadMedida>", "UNI");
                        sbXML.AppendLine();
                        sbXML.AppendFormat("           <dte:Descripcion>{0}</dte:Descripcion>", dtFEL.Rows[z]["descripcion"].ToString().Replace("&", "Y").Replace("\"", " "));
                        sbXML.AppendLine();
                        sbXML.AppendFormat("           <dte:PrecioUnitario>{0}</dte:PrecioUnitario>", decimal.Round(decimal.Parse(dtFEL.Rows[z]["precioVenta"].ToString()), 4));
                        sbXML.AppendLine();
                        sbXML.AppendFormat("           <dte:Precio>{0}</dte:Precio>", lTotalxArticulo);
                        sbXML.AppendLine();
                        sbXML.AppendFormat("           <dte:Descuento>{0}</dte:Descuento>", "0.00");
                        sbXML.AppendLine();
                        sbXML.Append("           <dte:Impuestos>");
                        sbXML.AppendLine();
                        sbXML.Append("             <dte:Impuesto>");
                        sbXML.AppendLine();
                        sbXML.AppendFormat("               <dte:NombreCorto>{0}</dte:NombreCorto>", "IVA");
                        sbXML.AppendLine();
                        sbXML.AppendFormat("               <dte:CodigoUnidadGravable>{0}</dte:CodigoUnidadGravable>", "1");
                        sbXML.AppendLine();
                        sbXML.AppendFormat("               <dte:MontoGravable>{0}</dte:MontoGravable>", lTotalxArticuloSinIva);
                        sbXML.AppendLine();
                        sbXML.AppendFormat("               <dte:MontoImpuesto>{0}</dte:MontoImpuesto>", lTotalxArticuloIva);
                        sbXML.AppendLine();
                        sbXML.Append("             </dte:Impuesto>");
                        sbXML.AppendLine();
                        sbXML.Append("           </dte:Impuestos>");
                        sbXML.AppendLine();
                        sbXML.AppendFormat("           <dte:Total>{0}</dte:Total>", lTotalxArticulo);
                        sbXML.AppendLine();
                        sbXML.Append("         </dte:Item>");
                        sbXML.AppendLine();
                        Linea++;
                    }

                    //FIN CUERPO ITEMS
                    sbXML.AppendLine();
                    sbXML.Append("       </dte:Items>");
                    sbXML.AppendLine();
                    //FIN ITEMS

                    //TOTALES
                    sbXML.Append("       <dte:Totales>");
                    sbXML.AppendLine();
                    //CUERPO TOTALES

                    sbXML.Append("         <dte:TotalImpuestos>");
                    sbXML.AppendLine();
                    sbXML.AppendFormat("           <dte:TotalImpuesto NombreCorto=\"IVA\" TotalMontoImpuesto=\"{0}\"></dte:TotalImpuesto>", dTotalImpuesto);
                    sbXML.AppendLine();
                    sbXML.Append("         </dte:TotalImpuestos>");
                    sbXML.AppendLine();
                    sbXML.AppendFormat("         <dte:GranTotal>{0}</dte:GranTotal>", dTotal);

                    //FIN CUERPO TOTALES
                    sbXML.AppendLine();
                    sbXML.Append("       </dte:Totales>");
                    sbXML.AppendLine();
                    //FIN TOTALES    
                    /*sbXML.Append("     </dte:DatosEmision>");
                    sbXML.AppendLine();*/
                    sbXML.Append("   </dte:DTE>");
                    sbXML.AppendLine();
                    /*sbXML.Append("   <dte:Adenda>");
                    sbXML.AppendLine();
                    sbXML.Append("      <Diseno>M</Diseno>");
                    sbXML.AppendLine();
                    sbXML.Append("   </dte:Adenda>");
                    sbXML.AppendLine();*/
                    sbXML.Append(" </dte:SAT>");
                    sbXML.AppendLine();
                    sbXML.Append("</dte:GTDocumento>");
                    XML = sbXML.ToString();
                }
                catch (Exception)
                { }

                if (string.IsNullOrWhiteSpace(XML))
                {
                    MessageBox.Show("Certificación Factura", "Factura generada, No se genero XLM certificado ", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return -1;
                }

                try
                {
                   // string vsEntidadWS = certificadorDocumento;
                    string vsEntidadWS = "";
                    /*StringBuilder vsXmlAutenticacion = new StringBuilder();
                     vsXmlAutenticacion.Append("<Autenticacion>");
                     vsXmlAutenticacion.AppendLine();
                      vsXmlAutenticacion.AppendFormat(" <pn_usuario>{0}</pn_usuario>", usuarioFEL);
                      vsXmlAutenticacion.AppendLine();
                      vsXmlAutenticacion.AppendFormat(" <pn_clave>{0}</pn_clave>", claveFEL);
                      vsXmlAutenticacion.AppendLine();
                      vsXmlAutenticacion.AppendFormat(" <pn_cliente>{0}</pn_cliente>", clienteFEL);
                      vsXmlAutenticacion.AppendLine();
                      vsXmlAutenticacion.AppendFormat(" <pn_contrato>{0}</pn_contrato>", contratoFEL);
                      vsXmlAutenticacion.AppendLine();
                      vsXmlAutenticacion.AppendFormat(" <pn_id_origen>{0}</pn_id_origen>", idOrigenFEL);
                      vsXmlAutenticacion.AppendLine();
                      vsXmlAutenticacion.AppendFormat(" <pn_ip_origen>{0}</pn_ip_origen>", ipFEL);
                      vsXmlAutenticacion.AppendLine();
                      vsXmlAutenticacion.AppendFormat(" <pn_firmar_emisor>{0}</pn_firmar_emisor>", "SI");
                      vsXmlAutenticacion.AppendLine();
                      vsXmlAutenticacion.Append("</Autenticacion>");*/

                    StringBuilder vsXmlDocumento = new StringBuilder();
                    /*vsXmlDocumento.Append("<Documento>");
                    vsXmlDocumento.AppendLine();*/
                    vsXmlDocumento.AppendFormat(" <![CDATA[{0}]]>", XML);
                    /*vsXmlDocumento.AppendLine();
                    vsXmlDocumento.Append("</Documento>");*/

                   /* StringBuilder vsXmlBody = new StringBuilder();
                    vsXmlBody.Append("<Envelope xmlns=\"http://schemas.xmlsoap.org/soap/envelope/\">");
                    vsXmlBody.AppendLine();
                    vsXmlBody.Append(" <Body>");
                    vsXmlBody.AppendLine();
                    vsXmlBody.AppendFormat("   <CertificacionDocumento xmlns=\"{0}\">", XmlnsFactura);
                    vsXmlBody.AppendLine();
                    vsXmlBody.AppendFormat("    {0}", vsXmlAutenticacion);
                    vsXmlBody.AppendLine();
                    vsXmlBody.AppendFormat("    {0}", vsXmlDocumento);
                    vsXmlBody.AppendLine();
                    vsXmlBody.Append("   </CertificacionDocumento>");
                    vsXmlBody.AppendLine();
                    vsXmlBody.Append(" </Body>");
                    vsXmlBody.AppendLine();
                    vsXmlBody.Append("</Envelope>");*/

                    string vsRespuestaServicio = string.Empty;

                    try
                    {
                        vsEntidadWS = "https://certificador.feel.com.gt/fel/procesounificado/transaccion/v2/xml";
                        clsXMLHTTP vclsXMLHTTP = new clsXMLHTTP();
                        ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls12;
                        vclsXMLHTTP.open("POST", vsEntidadWS, "FALSE");
                        //vclsXMLHTTP.Send(vsXmlBody);
                        vclsXMLHTTP.Send(XML);
                        vsRespuestaServicio = vclsXMLHTTP.ResponseText;
                    }
                    catch (Exception e)
                    {
                        MessageBox.Show("Error: " + e.ToString(), "Factura generada, No se genero la factura certificada", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return -2;
                    }
                    certificadorFEL respuestaInfile = new certificadorFEL(); 
                    if (!string.IsNullOrWhiteSpace(vsRespuestaServicio))
                    {
                        using (StringReader reader = new StringReader(vsRespuestaServicio))
                        {
                            respuestaInfile = JsonConvert.DeserializeObject<certificadorFEL>(vsRespuestaServicio);
                        }
                        
                        //dsResultado.ReadXml(reader);
                        if (respuestaInfile != null)
                        {
                            if (respuestaInfile.cantidad_errores == 0)
                            {
                                /* string strDocumentoCertificado = dsResultado.Tables[1].Rows[0].Field<string>("DocumentoCertificado");
                                 string strRepresentacionGrafica = dsResultado.Tables[1].Rows[0].Field<string>("RepresentacionGrafica");
                                 string strCodigoQR = dsResultado.Tables[1].Rows[0].Field<string>("CodigoQR");
                                 string strNITCertificador = dsResultado.Tables[1].Rows[0].Field<string>("NITCertificador");
                                 string strNombreCertificador = dsResultado.Tables[1].Rows[0].Field<string>("NombreCertificador");*/
                                string strCodigoQR = "";
                                string strNumeroAutorizacion = respuestaInfile.uuid;
                                string strNumeroDocumento = respuestaInfile.numero;
                                string strSerieDocumento = respuestaInfile.serie;
                                DateTime strFechaHoraCertificacion = Convert.ToDateTime(respuestaInfile.fecha);
                                string strXMLCertificado = respuestaInfile.xml_certificado;
                                RDocumento.marcarDocumentoFEL(sucursal, tipoDocumento, NoDocumento, serieDocumento);
                                try
                                {
                                    imgQR(strCodigoQR, strNumeroDocumento);
                                }
                                catch (Exception) { }
                                RDocumento.actualizarDocumentoFEL(sucursal, tipoDocumento, NoDocumento, serieDocumento, strNumeroDocumento, strSerieDocumento, fechaEmisionFEL, strNumeroAutorizacion, strFechaHoraCertificacion, "Documento Certificado Exitosamente!", rutaFELQR);
                                //factura.actualizaFel(idFactura, "Documento Certificado Exitosamente!", strFechaHoraCertificacion, strSerieDocumento, strNumeroDocumento, strNumeroAutorizacion);
                                serieFel = strSerieDocumento;
                                numeroFel = strNumeroDocumento;
                            }
                            else
                            {
                                MessageBox.Show("Certificación Factura", "Factura generada, No se genero la factura certificada", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                return -2;
                            }
                        }
                        else
                        {
                            MessageBox.Show("Certificación Factura", "Factura generada, No se genero la factura certificada", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            return -2;
                        }                        
                    }
                    else
                    {
                        MessageBox.Show("Certificación Factura", "Factura generada, No se genero la factura certificada", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return -2;
                    }
                }
                catch (Exception e)
                {
                    MessageBox.Show("Certificación Factura", "Factura generada, No se genero la factura certificada", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return -2;
                }
            }
            return 1;        
        }

        public Image imgQR(string base64String, string wsDocumentoFEL)
        {
            DataTable dtPermiso = new DataTable();
            dtPermiso = RParametros.VerificarConfiguracion("FEL", "rutaQRFEL");
            rutaFELQR = "";
            string folderPath = dtPermiso.Rows[0]["valorString"].ToString();
            if (!Directory.Exists(folderPath))
            {
                Directory.CreateDirectory(folderPath);
            }
            //if()
            File.Delete(folderPath + "\\QR_FEL_" + wsDocumentoFEL + ".jpeg");
            // Convert base 64 string to byte[]
            byte[] imageBytes = Convert.FromBase64String(base64String);
            // Convert byte[] to Image
            using (var ms = new MemoryStream(imageBytes, 0, imageBytes.Length))
            {
                Image image = Image.FromStream(ms, true);
                image.Save(folderPath + "QR_FEL_" + wsDocumentoFEL + ".jpeg");
                rutaFELQR = folderPath + "QR_FEL_" + wsDocumentoFEL + ".jpeg";

                return image;
            }

        }
        private bool registrarIngreso()
        {
            bool ingreso = false;
            EMovimientoCaja movCaja = new EMovimientoCaja();
            DataTable dtCaja = RCaja.listarCajasPC(estacion, "A");
            if(dtCaja.Rows.Count>0)
            {
                movCaja.caja = dtCaja.Rows[0]["caja"].ToString();   
            }
            movCaja.concepto = "3"; //Ingresos Ordinarios de la tabla Concepto Caja
            movCaja.operacion = 1; //Operacion: 1 = suma a caja, -1 = resta a caja, 0 = solo registro para caja
            string totalFinal = lblGranTotal.Text.Replace("Q", "");
            movCaja.montoEfectivo = Convert.ToDouble( totalFinal);
            movCaja.usuario = user;
            movCaja.fechaRegistro = DateTime.Now;
            movCaja.tipoMovimiento = tipoAdmision; // Tipo de Documento Interno F=Factura;
            movCaja.movimientoReferencia = admision; // No. de Admision
            if (RMovimientoCaja.registrarMovimientoCaja(movCaja) > 0)
                ingreso = true;
            else
                ingreso = false;
            return ingreso;
        }
        private void btnGenerarFactura_Click(object sender, EventArgs e)
        {
            guardarDocumento();//Registra la orden como Factura
        }
    }
}

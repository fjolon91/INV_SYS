
namespace INV_SYS
{
    partial class frmInvSys
    {
        /// <summary>
        /// Variable del diseñador necesaria.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Limpiar los recursos que se estén usando.
        /// </summary>
        /// <param name="disposing">true si los recursos administrados se deben desechar; false en caso contrario.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Código generado por el Diseñador de Windows Forms

        /// <summary>
        /// Método necesario para admitir el Diseñador. No se puede modificar
        /// el contenido de este método con el editor de código.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle9 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle7 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle8 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmInvSys));
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.cajaToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.corteDeCajaToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.facturasToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.generarFacturaToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.reportesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.imprimirListaDeFacturasToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.cortesParcialesDelDíaToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.egresosDelDíaToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.corteDeCajaToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.configuracionesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.sucursalesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.crearSucursalToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.verSucursalesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.usuariosToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.crearUsuarioToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.modificarUsuarioToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.cajaToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.crearCajaNuevaToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.catálogosToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.institucionesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.médicosToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.tiposDeCortesParcialesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.tiposDeEgresosToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.sesiónToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
            this.tsFastAccessTools = new System.Windows.Forms.ToolStrip();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.tmrData = new System.Windows.Forms.Timer(this.components);
            this.tpEgresos = new System.Windows.Forms.TabPage();
            this.panel8 = new System.Windows.Forms.Panel();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.dgvGastos = new System.Windows.Forms.DataGridView();
            this.gasto = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.FechaEgreso = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tipoEgreso = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Proveedor = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Descripcion = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Monto = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.opEditar = new System.Windows.Forms.DataGridViewButtonColumn();
            this.opEliminar = new System.Windows.Forms.DataGridViewButtonColumn();
            this.panel2 = new System.Windows.Forms.Panel();
            this.label2 = new System.Windows.Forms.Label();
            this.txtMonto = new System.Windows.Forms.TextBox();
            this.txtConcepto = new System.Windows.Forms.TextBox();
            this.label12 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.btnEgreso = new System.Windows.Forms.Button();
            this.cmbProveedores = new System.Windows.Forms.ComboBox();
            this.dateTimePicker2 = new System.Windows.Forms.DateTimePicker();
            this.lblTipoEgreso = new System.Windows.Forms.Label();
            this.lblFechaEgreso = new System.Windows.Forms.Label();
            this.flowLayoutPanel16 = new System.Windows.Forms.FlowLayoutPanel();
            this.btnImprimirEgresosDia = new System.Windows.Forms.Button();
            this.tpInstituciones = new System.Windows.Forms.TabPage();
            this.panel1 = new System.Windows.Forms.Panel();
            this.panel7 = new System.Windows.Forms.Panel();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.lblTotalFactura = new System.Windows.Forms.Label();
            this.lblFechaFinal = new System.Windows.Forms.Label();
            this.lblFechaInicial = new System.Windows.Forms.Label();
            this.lblInstitucion = new System.Windows.Forms.Label();
            this.lblNIT = new System.Windows.Forms.Label();
            this.lblinfototal = new System.Windows.Forms.Label();
            this.lblInfofFinal = new System.Windows.Forms.Label();
            this.lblInfoFInicial = new System.Windows.Forms.Label();
            this.lblinfoInstitucion = new System.Windows.Forms.Label();
            this.lblInfoNit = new System.Windows.Forms.Label();
            this.panel6 = new System.Windows.Forms.Panel();
            this.lblTituloInsituciones = new System.Windows.Forms.Label();
            this.lblFechaInicialFactura = new System.Windows.Forms.Label();
            this.lblFechaFinalFactura = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.lblInstitucionFact = new System.Windows.Forms.Label();
            this.cmbClientes = new System.Windows.Forms.ComboBox();
            this.dtpFechaInicial = new System.Windows.Forms.DateTimePicker();
            this.dtpFechaFinal = new System.Windows.Forms.DateTimePicker();
            this.flowLayoutPanel15 = new System.Windows.Forms.FlowLayoutPanel();
            this.btnGenerarFacturaInstitucion = new System.Windows.Forms.Button();
            this.btnListaPeticiones = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.tpRevision = new System.Windows.Forms.TabPage();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.panel4 = new System.Windows.Forms.Panel();
            this.dgvFacturasEmitidas = new System.Windows.Forms.DataGridView();
            this.noOrdenRevisar = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Cliente = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.NIT = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.fechaFacturaRevisar = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.totalFacturadoRevisar = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.verDetalleRevisado = new System.Windows.Forms.DataGridViewButtonColumn();
            this.Serie = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Documento = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Tipo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Sucursal = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Autorizacion = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Numero = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.SerieFel = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.panel5 = new System.Windows.Forms.Panel();
            this.btnBuscar = new System.Windows.Forms.Button();
            this.label20 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.dtpFinal = new System.Windows.Forms.DateTimePicker();
            this.dtpInicio = new System.Windows.Forms.DateTimePicker();
            this.flowLayoutPanel14 = new System.Windows.Forms.FlowLayoutPanel();
            this.btnReimprimirFactura = new System.Windows.Forms.Button();
            this.btnAnularFactura = new System.Windows.Forms.Button();
            this.tpFacturar = new System.Windows.Forms.TabPage();
            this.dgvFacturas = new System.Windows.Forms.DataGridView();
            this.noOrden = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tipoAdmision = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.paciente = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.fechaIngreso = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.totalFactura = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.verDetalle = new System.Windows.Forms.DataGridViewButtonColumn();
            this.idEspecialidad = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Especialidad = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.IdTipoPaciente = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.TipoPaciente = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.IdPaciente = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.idSucursal = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.flowLayoutPanel3 = new System.Windows.Forms.FlowLayoutPanel();
            this.btnGenerarFactura = new System.Windows.Forms.Button();
            this.btnVerDetalleFactura = new System.Windows.Forms.Button();
            this.tbcGeneral = new System.Windows.Forms.TabControl();
            this.panel3 = new System.Windows.Forms.Panel();
            this.tsbAperturarCaja = new System.Windows.Forms.ToolStripButton();
            this.tsbCerrarSesion = new System.Windows.Forms.ToolStripButton();
            this.aperturarCajaToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.cerrarCajaToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.menuStrip1.SuspendLayout();
            this.tsFastAccessTools.SuspendLayout();
            this.tpEgresos.SuspendLayout();
            this.panel8.SuspendLayout();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvGastos)).BeginInit();
            this.panel2.SuspendLayout();
            this.flowLayoutPanel16.SuspendLayout();
            this.tpInstituciones.SuspendLayout();
            this.panel1.SuspendLayout();
            this.panel7.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.panel6.SuspendLayout();
            this.flowLayoutPanel15.SuspendLayout();
            this.tpRevision.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            this.panel4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvFacturasEmitidas)).BeginInit();
            this.panel5.SuspendLayout();
            this.flowLayoutPanel14.SuspendLayout();
            this.tpFacturar.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvFacturas)).BeginInit();
            this.flowLayoutPanel3.SuspendLayout();
            this.tbcGeneral.SuspendLayout();
            this.panel3.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.cajaToolStripMenuItem,
            this.facturasToolStripMenuItem,
            this.reportesToolStripMenuItem,
            this.configuracionesToolStripMenuItem,
            this.sesiónToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Padding = new System.Windows.Forms.Padding(4, 2, 0, 2);
            this.menuStrip1.Size = new System.Drawing.Size(1414, 24);
            this.menuStrip1.TabIndex = 5;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // cajaToolStripMenuItem
            // 
            this.cajaToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.aperturarCajaToolStripMenuItem,
            this.cerrarCajaToolStripMenuItem,
            this.corteDeCajaToolStripMenuItem1});
            this.cajaToolStripMenuItem.Name = "cajaToolStripMenuItem";
            this.cajaToolStripMenuItem.Size = new System.Drawing.Size(42, 20);
            this.cajaToolStripMenuItem.Text = "Caja";
            // 
            // corteDeCajaToolStripMenuItem1
            // 
            this.corteDeCajaToolStripMenuItem1.Name = "corteDeCajaToolStripMenuItem1";
            this.corteDeCajaToolStripMenuItem1.Size = new System.Drawing.Size(148, 22);
            this.corteDeCajaToolStripMenuItem1.Text = "Corte parcial";
            // 
            // facturasToolStripMenuItem
            // 
            this.facturasToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.generarFacturaToolStripMenuItem});
            this.facturasToolStripMenuItem.Name = "facturasToolStripMenuItem";
            this.facturasToolStripMenuItem.Size = new System.Drawing.Size(63, 20);
            this.facturasToolStripMenuItem.Text = "Facturas";
            // 
            // generarFacturaToolStripMenuItem
            // 
            this.generarFacturaToolStripMenuItem.Name = "generarFacturaToolStripMenuItem";
            this.generarFacturaToolStripMenuItem.Size = new System.Drawing.Size(155, 22);
            this.generarFacturaToolStripMenuItem.Text = "Generar factura";
            // 
            // reportesToolStripMenuItem
            // 
            this.reportesToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.imprimirListaDeFacturasToolStripMenuItem,
            this.cortesParcialesDelDíaToolStripMenuItem,
            this.egresosDelDíaToolStripMenuItem,
            this.corteDeCajaToolStripMenuItem});
            this.reportesToolStripMenuItem.Name = "reportesToolStripMenuItem";
            this.reportesToolStripMenuItem.Size = new System.Drawing.Size(65, 20);
            this.reportesToolStripMenuItem.Text = "Reportes";
            // 
            // imprimirListaDeFacturasToolStripMenuItem
            // 
            this.imprimirListaDeFacturasToolStripMenuItem.Name = "imprimirListaDeFacturasToolStripMenuItem";
            this.imprimirListaDeFacturasToolStripMenuItem.Size = new System.Drawing.Size(205, 22);
            this.imprimirListaDeFacturasToolStripMenuItem.Text = "Imprimir lista de facturas";
            // 
            // cortesParcialesDelDíaToolStripMenuItem
            // 
            this.cortesParcialesDelDíaToolStripMenuItem.Name = "cortesParcialesDelDíaToolStripMenuItem";
            this.cortesParcialesDelDíaToolStripMenuItem.Size = new System.Drawing.Size(205, 22);
            this.cortesParcialesDelDíaToolStripMenuItem.Text = "Cortes parciales del día";
            // 
            // egresosDelDíaToolStripMenuItem
            // 
            this.egresosDelDíaToolStripMenuItem.Name = "egresosDelDíaToolStripMenuItem";
            this.egresosDelDíaToolStripMenuItem.Size = new System.Drawing.Size(205, 22);
            this.egresosDelDíaToolStripMenuItem.Text = "Egresos del día";
            // 
            // corteDeCajaToolStripMenuItem
            // 
            this.corteDeCajaToolStripMenuItem.Name = "corteDeCajaToolStripMenuItem";
            this.corteDeCajaToolStripMenuItem.Size = new System.Drawing.Size(205, 22);
            this.corteDeCajaToolStripMenuItem.Text = "Corte de caja";
            // 
            // configuracionesToolStripMenuItem
            // 
            this.configuracionesToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.sucursalesToolStripMenuItem,
            this.usuariosToolStripMenuItem,
            this.cajaToolStripMenuItem1,
            this.catálogosToolStripMenuItem});
            this.configuracionesToolStripMenuItem.Name = "configuracionesToolStripMenuItem";
            this.configuracionesToolStripMenuItem.Size = new System.Drawing.Size(106, 20);
            this.configuracionesToolStripMenuItem.Text = "Configuraciones";
            // 
            // sucursalesToolStripMenuItem
            // 
            this.sucursalesToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.crearSucursalToolStripMenuItem,
            this.verSucursalesToolStripMenuItem});
            this.sucursalesToolStripMenuItem.Name = "sucursalesToolStripMenuItem";
            this.sucursalesToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.sucursalesToolStripMenuItem.Text = "Sucursales";
            // 
            // crearSucursalToolStripMenuItem
            // 
            this.crearSucursalToolStripMenuItem.Name = "crearSucursalToolStripMenuItem";
            this.crearSucursalToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.crearSucursalToolStripMenuItem.Text = "Crear sucursal";
            // 
            // verSucursalesToolStripMenuItem
            // 
            this.verSucursalesToolStripMenuItem.Name = "verSucursalesToolStripMenuItem";
            this.verSucursalesToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.verSucursalesToolStripMenuItem.Text = "Sucursales";
            this.verSucursalesToolStripMenuItem.Click += new System.EventHandler(this.verSucursalesToolStripMenuItem_Click);
            // 
            // usuariosToolStripMenuItem
            // 
            this.usuariosToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.crearUsuarioToolStripMenuItem,
            this.modificarUsuarioToolStripMenuItem});
            this.usuariosToolStripMenuItem.Name = "usuariosToolStripMenuItem";
            this.usuariosToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.usuariosToolStripMenuItem.Text = "Usuarios";
            // 
            // crearUsuarioToolStripMenuItem
            // 
            this.crearUsuarioToolStripMenuItem.Name = "crearUsuarioToolStripMenuItem";
            this.crearUsuarioToolStripMenuItem.Size = new System.Drawing.Size(167, 22);
            this.crearUsuarioToolStripMenuItem.Text = "Crear usuario";
            // 
            // modificarUsuarioToolStripMenuItem
            // 
            this.modificarUsuarioToolStripMenuItem.Name = "modificarUsuarioToolStripMenuItem";
            this.modificarUsuarioToolStripMenuItem.Size = new System.Drawing.Size(167, 22);
            this.modificarUsuarioToolStripMenuItem.Text = "Modificar usuario";
            // 
            // cajaToolStripMenuItem1
            // 
            this.cajaToolStripMenuItem1.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.crearCajaNuevaToolStripMenuItem});
            this.cajaToolStripMenuItem1.Name = "cajaToolStripMenuItem1";
            this.cajaToolStripMenuItem1.Size = new System.Drawing.Size(180, 22);
            this.cajaToolStripMenuItem1.Text = "Caja";
            // 
            // crearCajaNuevaToolStripMenuItem
            // 
            this.crearCajaNuevaToolStripMenuItem.Name = "crearCajaNuevaToolStripMenuItem";
            this.crearCajaNuevaToolStripMenuItem.Size = new System.Drawing.Size(161, 22);
            this.crearCajaNuevaToolStripMenuItem.Text = "Crear caja nueva";
            // 
            // catálogosToolStripMenuItem
            // 
            this.catálogosToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.institucionesToolStripMenuItem,
            this.médicosToolStripMenuItem,
            this.tiposDeCortesParcialesToolStripMenuItem,
            this.tiposDeEgresosToolStripMenuItem});
            this.catálogosToolStripMenuItem.Name = "catálogosToolStripMenuItem";
            this.catálogosToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.catálogosToolStripMenuItem.Text = "Catálogos";
            // 
            // institucionesToolStripMenuItem
            // 
            this.institucionesToolStripMenuItem.Name = "institucionesToolStripMenuItem";
            this.institucionesToolStripMenuItem.Size = new System.Drawing.Size(202, 22);
            this.institucionesToolStripMenuItem.Text = "Instituciones";
            // 
            // médicosToolStripMenuItem
            // 
            this.médicosToolStripMenuItem.Name = "médicosToolStripMenuItem";
            this.médicosToolStripMenuItem.Size = new System.Drawing.Size(202, 22);
            this.médicosToolStripMenuItem.Text = "Médicos";
            // 
            // tiposDeCortesParcialesToolStripMenuItem
            // 
            this.tiposDeCortesParcialesToolStripMenuItem.Name = "tiposDeCortesParcialesToolStripMenuItem";
            this.tiposDeCortesParcialesToolStripMenuItem.Size = new System.Drawing.Size(202, 22);
            this.tiposDeCortesParcialesToolStripMenuItem.Text = "Tipos de cortes parciales";
            // 
            // tiposDeEgresosToolStripMenuItem
            // 
            this.tiposDeEgresosToolStripMenuItem.Name = "tiposDeEgresosToolStripMenuItem";
            this.tiposDeEgresosToolStripMenuItem.Size = new System.Drawing.Size(202, 22);
            this.tiposDeEgresosToolStripMenuItem.Text = "Tipos de egresos";
            // 
            // sesiónToolStripMenuItem
            // 
            this.sesiónToolStripMenuItem.Name = "sesiónToolStripMenuItem";
            this.sesiónToolStripMenuItem.Size = new System.Drawing.Size(87, 20);
            this.sesiónToolStripMenuItem.Text = "Cerrar sesión";
            this.sesiónToolStripMenuItem.Click += new System.EventHandler(this.sesiónToolStripMenuItem_Click);
            // 
            // flowLayoutPanel1
            // 
            this.flowLayoutPanel1.AutoSize = true;
            this.flowLayoutPanel1.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.flowLayoutPanel1.Location = new System.Drawing.Point(0, 50);
            this.flowLayoutPanel1.Name = "flowLayoutPanel1";
            this.flowLayoutPanel1.Size = new System.Drawing.Size(0, 0);
            this.flowLayoutPanel1.TabIndex = 7;
            // 
            // tsFastAccessTools
            // 
            this.tsFastAccessTools.AutoSize = false;
            this.tsFastAccessTools.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.tsFastAccessTools.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsbAperturarCaja,
            this.toolStripSeparator1,
            this.tsbCerrarSesion});
            this.tsFastAccessTools.Location = new System.Drawing.Point(0, 24);
            this.tsFastAccessTools.Name = "tsFastAccessTools";
            this.tsFastAccessTools.Size = new System.Drawing.Size(1414, 27);
            this.tsFastAccessTools.TabIndex = 9;
            this.tsFastAccessTools.Text = "Herramientas";
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(6, 27);
            // 
            // tmrData
            // 
            this.tmrData.Enabled = true;
            this.tmrData.Interval = 10000;
            this.tmrData.Tick += new System.EventHandler(this.tmrData_Tick);
            // 
            // tpEgresos
            // 
            this.tpEgresos.Controls.Add(this.panel8);
            this.tpEgresos.Controls.Add(this.panel2);
            this.tpEgresos.Controls.Add(this.flowLayoutPanel16);
            this.tpEgresos.Location = new System.Drawing.Point(4, 22);
            this.tpEgresos.Name = "tpEgresos";
            this.tpEgresos.Padding = new System.Windows.Forms.Padding(3);
            this.tpEgresos.Size = new System.Drawing.Size(1406, 597);
            this.tpEgresos.TabIndex = 3;
            this.tpEgresos.Text = "Egresos";
            this.tpEgresos.ToolTipText = "Registrar egresos";
            this.tpEgresos.UseVisualStyleBackColor = true;
            // 
            // panel8
            // 
            this.panel8.Controls.Add(this.groupBox2);
            this.panel8.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel8.Location = new System.Drawing.Point(3, 229);
            this.panel8.Name = "panel8";
            this.panel8.Size = new System.Drawing.Size(1264, 365);
            this.panel8.TabIndex = 10;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.dgvGastos);
            this.groupBox2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox2.Location = new System.Drawing.Point(0, 0);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(1264, 365);
            this.groupBox2.TabIndex = 11;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Egresos del día";
            // 
            // dgvGastos
            // 
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvGastos.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dgvGastos.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvGastos.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.gasto,
            this.FechaEgreso,
            this.tipoEgreso,
            this.Proveedor,
            this.Descripcion,
            this.Monto,
            this.opEditar,
            this.opEliminar});
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvGastos.DefaultCellStyle = dataGridViewCellStyle2;
            this.dgvGastos.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvGastos.Location = new System.Drawing.Point(3, 16);
            this.dgvGastos.Name = "dgvGastos";
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvGastos.RowHeadersDefaultCellStyle = dataGridViewCellStyle3;
            this.dgvGastos.RowHeadersWidth = 51;
            this.dgvGastos.Size = new System.Drawing.Size(1258, 346);
            this.dgvGastos.TabIndex = 0;
            // 
            // gasto
            // 
            this.gasto.HeaderText = "Gasto";
            this.gasto.Name = "gasto";
            this.gasto.Visible = false;
            // 
            // FechaEgreso
            // 
            this.FechaEgreso.HeaderText = "Fecha de egreso";
            this.FechaEgreso.MinimumWidth = 6;
            this.FechaEgreso.Name = "FechaEgreso";
            this.FechaEgreso.ReadOnly = true;
            this.FechaEgreso.Width = 125;
            // 
            // tipoEgreso
            // 
            this.tipoEgreso.HeaderText = "Tipo de Egreso";
            this.tipoEgreso.MinimumWidth = 6;
            this.tipoEgreso.Name = "tipoEgreso";
            this.tipoEgreso.ReadOnly = true;
            this.tipoEgreso.Width = 125;
            // 
            // Proveedor
            // 
            this.Proveedor.HeaderText = "Proveedor";
            this.Proveedor.Name = "Proveedor";
            this.Proveedor.ReadOnly = true;
            // 
            // Descripcion
            // 
            this.Descripcion.HeaderText = "Descripción";
            this.Descripcion.MinimumWidth = 6;
            this.Descripcion.Name = "Descripcion";
            this.Descripcion.ReadOnly = true;
            this.Descripcion.Width = 125;
            // 
            // Monto
            // 
            this.Monto.HeaderText = "Monto";
            this.Monto.Name = "Monto";
            this.Monto.ReadOnly = true;
            // 
            // opEditar
            // 
            this.opEditar.HeaderText = "Editar egreso";
            this.opEditar.MinimumWidth = 6;
            this.opEditar.Name = "opEditar";
            this.opEditar.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.opEditar.Width = 125;
            // 
            // opEliminar
            // 
            this.opEliminar.HeaderText = "Eliminar Egreso";
            this.opEliminar.MinimumWidth = 6;
            this.opEliminar.Name = "opEliminar";
            this.opEliminar.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.opEliminar.Width = 125;
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.WhiteSmoke;
            this.panel2.Controls.Add(this.label2);
            this.panel2.Controls.Add(this.txtMonto);
            this.panel2.Controls.Add(this.txtConcepto);
            this.panel2.Controls.Add(this.label12);
            this.panel2.Controls.Add(this.label1);
            this.panel2.Controls.Add(this.btnEgreso);
            this.panel2.Controls.Add(this.cmbProveedores);
            this.panel2.Controls.Add(this.dateTimePicker2);
            this.panel2.Controls.Add(this.lblTipoEgreso);
            this.panel2.Controls.Add(this.lblFechaEgreso);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel2.Location = new System.Drawing.Point(3, 3);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(1264, 226);
            this.panel2.TabIndex = 9;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(23, 175);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(40, 13);
            this.label2.TabIndex = 12;
            this.label2.Text = "Monto:";
            // 
            // txtMonto
            // 
            this.txtMonto.Location = new System.Drawing.Point(195, 175);
            this.txtMonto.Multiline = true;
            this.txtMonto.Name = "txtMonto";
            this.txtMonto.Size = new System.Drawing.Size(97, 23);
            this.txtMonto.TabIndex = 11;
            // 
            // txtConcepto
            // 
            this.txtConcepto.Location = new System.Drawing.Point(195, 126);
            this.txtConcepto.Multiline = true;
            this.txtConcepto.Name = "txtConcepto";
            this.txtConcepto.Size = new System.Drawing.Size(456, 43);
            this.txtConcepto.TabIndex = 10;
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(23, 126);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(95, 13);
            this.label12.TabIndex = 9;
            this.label12.Text = "Detalle del egreso:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(20, 13);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(215, 31);
            this.label1.TabIndex = 8;
            this.label1.Text = "Registrar egreso";
            // 
            // btnEgreso
            // 
            this.btnEgreso.Location = new System.Drawing.Point(490, 175);
            this.btnEgreso.Name = "btnEgreso";
            this.btnEgreso.Size = new System.Drawing.Size(161, 23);
            this.btnEgreso.TabIndex = 6;
            this.btnEgreso.Text = "Guardar egreso";
            this.btnEgreso.UseVisualStyleBackColor = true;
            this.btnEgreso.Click += new System.EventHandler(this.btnEgreso_Click);
            // 
            // cmbProveedores
            // 
            this.cmbProveedores.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbProveedores.FormattingEnabled = true;
            this.cmbProveedores.Location = new System.Drawing.Point(195, 99);
            this.cmbProveedores.Name = "cmbProveedores";
            this.cmbProveedores.Size = new System.Drawing.Size(456, 21);
            this.cmbProveedores.TabIndex = 5;
            // 
            // dateTimePicker2
            // 
            this.dateTimePicker2.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dateTimePicker2.Location = new System.Drawing.Point(195, 73);
            this.dateTimePicker2.Name = "dateTimePicker2";
            this.dateTimePicker2.Size = new System.Drawing.Size(97, 20);
            this.dateTimePicker2.TabIndex = 3;
            // 
            // lblTipoEgreso
            // 
            this.lblTipoEgreso.AutoSize = true;
            this.lblTipoEgreso.Location = new System.Drawing.Point(23, 99);
            this.lblTipoEgreso.Name = "lblTipoEgreso";
            this.lblTipoEgreso.Size = new System.Drawing.Size(106, 13);
            this.lblTipoEgreso.TabIndex = 2;
            this.lblTipoEgreso.Text = "Institución a facturar:";
            // 
            // lblFechaEgreso
            // 
            this.lblFechaEgreso.AutoSize = true;
            this.lblFechaEgreso.Location = new System.Drawing.Point(23, 73);
            this.lblFechaEgreso.Name = "lblFechaEgreso";
            this.lblFechaEgreso.Size = new System.Drawing.Size(75, 13);
            this.lblFechaEgreso.TabIndex = 0;
            this.lblFechaEgreso.Text = "Fecha egreso:";
            // 
            // flowLayoutPanel16
            // 
            this.flowLayoutPanel16.BackColor = System.Drawing.Color.WhiteSmoke;
            this.flowLayoutPanel16.Controls.Add(this.btnImprimirEgresosDia);
            this.flowLayoutPanel16.Dock = System.Windows.Forms.DockStyle.Right;
            this.flowLayoutPanel16.Location = new System.Drawing.Point(1267, 3);
            this.flowLayoutPanel16.Name = "flowLayoutPanel16";
            this.flowLayoutPanel16.Size = new System.Drawing.Size(136, 591);
            this.flowLayoutPanel16.TabIndex = 7;
            // 
            // btnImprimirEgresosDia
            // 
            this.btnImprimirEgresosDia.Location = new System.Drawing.Point(3, 3);
            this.btnImprimirEgresosDia.Name = "btnImprimirEgresosDia";
            this.btnImprimirEgresosDia.Size = new System.Drawing.Size(130, 41);
            this.btnImprimirEgresosDia.TabIndex = 0;
            this.btnImprimirEgresosDia.Text = "Imprimir Egresos del día";
            this.btnImprimirEgresosDia.UseVisualStyleBackColor = true;
            // 
            // tpInstituciones
            // 
            this.tpInstituciones.Controls.Add(this.panel1);
            this.tpInstituciones.Controls.Add(this.flowLayoutPanel15);
            this.tpInstituciones.Location = new System.Drawing.Point(4, 22);
            this.tpInstituciones.Name = "tpInstituciones";
            this.tpInstituciones.Padding = new System.Windows.Forms.Padding(3);
            this.tpInstituciones.Size = new System.Drawing.Size(1406, 597);
            this.tpInstituciones.TabIndex = 2;
            this.tpInstituciones.Text = "Instituciones";
            this.tpInstituciones.ToolTipText = "Generar facturas a instituciones";
            this.tpInstituciones.UseVisualStyleBackColor = true;
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.WhiteSmoke;
            this.panel1.Controls.Add(this.panel7);
            this.panel1.Controls.Add(this.panel6);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(3, 3);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1264, 591);
            this.panel1.TabIndex = 8;
            // 
            // panel7
            // 
            this.panel7.Controls.Add(this.groupBox1);
            this.panel7.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel7.Location = new System.Drawing.Point(0, 210);
            this.panel7.Name = "panel7";
            this.panel7.Size = new System.Drawing.Size(1264, 381);
            this.panel7.TabIndex = 10;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.lblTotalFactura);
            this.groupBox1.Controls.Add(this.lblFechaFinal);
            this.groupBox1.Controls.Add(this.lblFechaInicial);
            this.groupBox1.Controls.Add(this.lblInstitucion);
            this.groupBox1.Controls.Add(this.lblNIT);
            this.groupBox1.Controls.Add(this.lblinfototal);
            this.groupBox1.Controls.Add(this.lblInfofFinal);
            this.groupBox1.Controls.Add(this.lblInfoFInicial);
            this.groupBox1.Controls.Add(this.lblinfoInstitucion);
            this.groupBox1.Controls.Add(this.lblInfoNit);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox1.Location = new System.Drawing.Point(0, 0);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(1264, 381);
            this.groupBox1.TabIndex = 7;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Detalle de facturación";
            // 
            // lblTotalFactura
            // 
            this.lblTotalFactura.AutoSize = true;
            this.lblTotalFactura.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTotalFactura.Location = new System.Drawing.Point(204, 305);
            this.lblTotalFactura.Name = "lblTotalFactura";
            this.lblTotalFactura.Size = new System.Drawing.Size(92, 13);
            this.lblTotalFactura.TabIndex = 17;
            this.lblTotalFactura.Text = "lblTotalFactura";
            // 
            // lblFechaFinal
            // 
            this.lblFechaFinal.AutoSize = true;
            this.lblFechaFinal.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblFechaFinal.Location = new System.Drawing.Point(204, 183);
            this.lblFechaFinal.Name = "lblFechaFinal";
            this.lblFechaFinal.Size = new System.Drawing.Size(23, 13);
            this.lblFechaFinal.TabIndex = 16;
            this.lblFechaFinal.Text = "----";
            // 
            // lblFechaInicial
            // 
            this.lblFechaInicial.AutoSize = true;
            this.lblFechaInicial.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblFechaInicial.Location = new System.Drawing.Point(204, 134);
            this.lblFechaInicial.Name = "lblFechaInicial";
            this.lblFechaInicial.Size = new System.Drawing.Size(23, 13);
            this.lblFechaInicial.TabIndex = 15;
            this.lblFechaInicial.Text = "----";
            // 
            // lblInstitucion
            // 
            this.lblInstitucion.AutoSize = true;
            this.lblInstitucion.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblInstitucion.Location = new System.Drawing.Point(204, 85);
            this.lblInstitucion.Name = "lblInstitucion";
            this.lblInstitucion.Size = new System.Drawing.Size(23, 13);
            this.lblInstitucion.TabIndex = 14;
            this.lblInstitucion.Text = "----";
            // 
            // lblNIT
            // 
            this.lblNIT.AutoSize = true;
            this.lblNIT.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblNIT.Location = new System.Drawing.Point(204, 38);
            this.lblNIT.Name = "lblNIT";
            this.lblNIT.Size = new System.Drawing.Size(23, 13);
            this.lblNIT.TabIndex = 13;
            this.lblNIT.Text = "----";
            // 
            // lblinfototal
            // 
            this.lblinfototal.AutoSize = true;
            this.lblinfototal.Location = new System.Drawing.Point(34, 305);
            this.lblinfototal.Name = "lblinfototal";
            this.lblinfototal.Size = new System.Drawing.Size(82, 13);
            this.lblinfototal.TabIndex = 12;
            this.lblinfototal.Text = "Total a facturar:";
            // 
            // lblInfofFinal
            // 
            this.lblInfofFinal.AutoSize = true;
            this.lblInfofFinal.Location = new System.Drawing.Point(34, 183);
            this.lblInfofFinal.Name = "lblInfofFinal";
            this.lblInfofFinal.Size = new System.Drawing.Size(133, 13);
            this.lblInfofFinal.TabIndex = 11;
            this.lblInfofFinal.Text = "Fecha final de facturación:";
            // 
            // lblInfoFInicial
            // 
            this.lblInfoFInicial.AutoSize = true;
            this.lblInfoFInicial.Location = new System.Drawing.Point(34, 134);
            this.lblInfoFInicial.Name = "lblInfoFInicial";
            this.lblInfoFInicial.Size = new System.Drawing.Size(140, 13);
            this.lblInfoFInicial.TabIndex = 10;
            this.lblInfoFInicial.Text = "Fecha inicial de facturación:";
            // 
            // lblinfoInstitucion
            // 
            this.lblinfoInstitucion.AutoSize = true;
            this.lblinfoInstitucion.Location = new System.Drawing.Point(34, 85);
            this.lblinfoInstitucion.Name = "lblinfoInstitucion";
            this.lblinfoInstitucion.Size = new System.Drawing.Size(58, 13);
            this.lblinfoInstitucion.TabIndex = 9;
            this.lblinfoInstitucion.Text = "Institución:";
            // 
            // lblInfoNit
            // 
            this.lblInfoNit.AutoSize = true;
            this.lblInfoNit.Location = new System.Drawing.Point(34, 38);
            this.lblInfoNit.Name = "lblInfoNit";
            this.lblInfoNit.Size = new System.Drawing.Size(28, 13);
            this.lblInfoNit.TabIndex = 8;
            this.lblInfoNit.Text = "NIT:";
            // 
            // panel6
            // 
            this.panel6.Controls.Add(this.lblTituloInsituciones);
            this.panel6.Controls.Add(this.lblFechaInicialFactura);
            this.panel6.Controls.Add(this.lblFechaFinalFactura);
            this.panel6.Controls.Add(this.button1);
            this.panel6.Controls.Add(this.lblInstitucionFact);
            this.panel6.Controls.Add(this.cmbClientes);
            this.panel6.Controls.Add(this.dtpFechaInicial);
            this.panel6.Controls.Add(this.dtpFechaFinal);
            this.panel6.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel6.Location = new System.Drawing.Point(0, 0);
            this.panel6.Name = "panel6";
            this.panel6.Size = new System.Drawing.Size(1264, 210);
            this.panel6.TabIndex = 9;
            // 
            // lblTituloInsituciones
            // 
            this.lblTituloInsituciones.AutoSize = true;
            this.lblTituloInsituciones.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTituloInsituciones.Location = new System.Drawing.Point(29, 17);
            this.lblTituloInsituciones.Name = "lblTituloInsituciones";
            this.lblTituloInsituciones.Size = new System.Drawing.Size(245, 31);
            this.lblTituloInsituciones.TabIndex = 8;
            this.lblTituloInsituciones.Text = "Facturar institución";
            // 
            // lblFechaInicialFactura
            // 
            this.lblFechaInicialFactura.AutoSize = true;
            this.lblFechaInicialFactura.Location = new System.Drawing.Point(32, 77);
            this.lblFechaInicialFactura.Name = "lblFechaInicialFactura";
            this.lblFechaInicialFactura.Size = new System.Drawing.Size(69, 13);
            this.lblFechaInicialFactura.TabIndex = 0;
            this.lblFechaInicialFactura.Text = "Fecha inicial:";
            // 
            // lblFechaFinalFactura
            // 
            this.lblFechaFinalFactura.AutoSize = true;
            this.lblFechaFinalFactura.Location = new System.Drawing.Point(32, 103);
            this.lblFechaFinalFactura.Name = "lblFechaFinalFactura";
            this.lblFechaFinalFactura.Size = new System.Drawing.Size(62, 13);
            this.lblFechaFinalFactura.TabIndex = 1;
            this.lblFechaFinalFactura.Text = "Fecha final:";
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(499, 164);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(161, 29);
            this.button1.TabIndex = 6;
            this.button1.Text = "Ver información";
            this.button1.UseVisualStyleBackColor = true;
            // 
            // lblInstitucionFact
            // 
            this.lblInstitucionFact.AutoSize = true;
            this.lblInstitucionFact.Location = new System.Drawing.Point(32, 128);
            this.lblInstitucionFact.Name = "lblInstitucionFact";
            this.lblInstitucionFact.Size = new System.Drawing.Size(106, 13);
            this.lblInstitucionFact.TabIndex = 2;
            this.lblInstitucionFact.Text = "Institución a facturar:";
            // 
            // cmbClientes
            // 
            this.cmbClientes.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbClientes.FormattingEnabled = true;
            this.cmbClientes.Location = new System.Drawing.Point(204, 125);
            this.cmbClientes.Name = "cmbClientes";
            this.cmbClientes.Size = new System.Drawing.Size(456, 21);
            this.cmbClientes.TabIndex = 5;
            // 
            // dtpFechaInicial
            // 
            this.dtpFechaInicial.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpFechaInicial.Location = new System.Drawing.Point(204, 71);
            this.dtpFechaInicial.Name = "dtpFechaInicial";
            this.dtpFechaInicial.Size = new System.Drawing.Size(97, 20);
            this.dtpFechaInicial.TabIndex = 3;
            // 
            // dtpFechaFinal
            // 
            this.dtpFechaFinal.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpFechaFinal.Location = new System.Drawing.Point(204, 97);
            this.dtpFechaFinal.Name = "dtpFechaFinal";
            this.dtpFechaFinal.Size = new System.Drawing.Size(97, 20);
            this.dtpFechaFinal.TabIndex = 4;
            // 
            // flowLayoutPanel15
            // 
            this.flowLayoutPanel15.BackColor = System.Drawing.Color.WhiteSmoke;
            this.flowLayoutPanel15.Controls.Add(this.btnGenerarFacturaInstitucion);
            this.flowLayoutPanel15.Controls.Add(this.btnListaPeticiones);
            this.flowLayoutPanel15.Controls.Add(this.button2);
            this.flowLayoutPanel15.Dock = System.Windows.Forms.DockStyle.Right;
            this.flowLayoutPanel15.Location = new System.Drawing.Point(1267, 3);
            this.flowLayoutPanel15.Name = "flowLayoutPanel15";
            this.flowLayoutPanel15.Size = new System.Drawing.Size(136, 591);
            this.flowLayoutPanel15.TabIndex = 7;
            // 
            // btnGenerarFacturaInstitucion
            // 
            this.btnGenerarFacturaInstitucion.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnGenerarFacturaInstitucion.Location = new System.Drawing.Point(3, 3);
            this.btnGenerarFacturaInstitucion.Name = "btnGenerarFacturaInstitucion";
            this.btnGenerarFacturaInstitucion.Size = new System.Drawing.Size(130, 26);
            this.btnGenerarFacturaInstitucion.TabIndex = 0;
            this.btnGenerarFacturaInstitucion.Text = "Generar Factura";
            this.btnGenerarFacturaInstitucion.UseVisualStyleBackColor = true;
            this.btnGenerarFacturaInstitucion.Click += new System.EventHandler(this.btnGenerarFacturaInstitucion_Click);
            // 
            // btnListaPeticiones
            // 
            this.btnListaPeticiones.Location = new System.Drawing.Point(3, 35);
            this.btnListaPeticiones.Name = "btnListaPeticiones";
            this.btnListaPeticiones.Size = new System.Drawing.Size(130, 26);
            this.btnListaPeticiones.TabIndex = 1;
            this.btnListaPeticiones.Text = "Ver Lista de Peticiones";
            this.btnListaPeticiones.UseVisualStyleBackColor = true;
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(3, 67);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(130, 43);
            this.button2.TabIndex = 2;
            this.button2.Text = "Imprimir detalle de peticiones";
            this.button2.UseVisualStyleBackColor = true;
            // 
            // tpRevision
            // 
            this.tpRevision.Controls.Add(this.tableLayoutPanel1);
            this.tpRevision.Controls.Add(this.flowLayoutPanel14);
            this.tpRevision.Location = new System.Drawing.Point(4, 22);
            this.tpRevision.Name = "tpRevision";
            this.tpRevision.Padding = new System.Windows.Forms.Padding(3);
            this.tpRevision.Size = new System.Drawing.Size(1406, 597);
            this.tpRevision.TabIndex = 1;
            this.tpRevision.Text = "Revisar facturas";
            this.tpRevision.ToolTipText = "Revisar facturas generadas";
            this.tpRevision.UseVisualStyleBackColor = true;
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 1;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.Controls.Add(this.panel4, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.panel5, 0, 0);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(3, 3);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 2;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 8.231174F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 91.76883F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(1264, 591);
            this.tableLayoutPanel1.TabIndex = 8;
            // 
            // panel4
            // 
            this.panel4.Controls.Add(this.dgvFacturasEmitidas);
            this.panel4.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel4.Location = new System.Drawing.Point(3, 51);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(1258, 537);
            this.panel4.TabIndex = 0;
            // 
            // dgvFacturasEmitidas
            // 
            this.dgvFacturasEmitidas.AllowUserToAddRows = false;
            this.dgvFacturasEmitidas.AllowUserToDeleteRows = false;
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle4.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle4.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle4.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle4.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle4.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvFacturasEmitidas.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle4;
            this.dgvFacturasEmitidas.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvFacturasEmitidas.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.noOrdenRevisar,
            this.Cliente,
            this.NIT,
            this.fechaFacturaRevisar,
            this.totalFacturadoRevisar,
            this.verDetalleRevisado,
            this.Serie,
            this.Documento,
            this.Tipo,
            this.Sucursal,
            this.Autorizacion,
            this.Numero,
            this.SerieFel});
            dataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle5.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle5.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle5.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle5.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle5.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle5.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvFacturasEmitidas.DefaultCellStyle = dataGridViewCellStyle5;
            this.dgvFacturasEmitidas.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvFacturasEmitidas.Location = new System.Drawing.Point(0, 0);
            this.dgvFacturasEmitidas.Name = "dgvFacturasEmitidas";
            this.dgvFacturasEmitidas.ReadOnly = true;
            this.dgvFacturasEmitidas.RowHeadersWidth = 51;
            this.dgvFacturasEmitidas.Size = new System.Drawing.Size(1258, 537);
            this.dgvFacturasEmitidas.TabIndex = 0;
            this.dgvFacturasEmitidas.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvFacturasEmitidas_CellContentClick);
            // 
            // noOrdenRevisar
            // 
            this.noOrdenRevisar.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.noOrdenRevisar.HeaderText = "Orden";
            this.noOrdenRevisar.MinimumWidth = 6;
            this.noOrdenRevisar.Name = "noOrdenRevisar";
            this.noOrdenRevisar.ReadOnly = true;
            this.noOrdenRevisar.Width = 61;
            // 
            // Cliente
            // 
            this.Cliente.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.Cliente.HeaderText = "Cliente";
            this.Cliente.MinimumWidth = 6;
            this.Cliente.Name = "Cliente";
            this.Cliente.ReadOnly = true;
            this.Cliente.Width = 64;
            // 
            // NIT
            // 
            this.NIT.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.NIT.HeaderText = "NIT";
            this.NIT.MinimumWidth = 6;
            this.NIT.Name = "NIT";
            this.NIT.ReadOnly = true;
            this.NIT.Width = 50;
            // 
            // fechaFacturaRevisar
            // 
            this.fechaFacturaRevisar.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.fechaFacturaRevisar.HeaderText = "Fecha de factura";
            this.fechaFacturaRevisar.MinimumWidth = 6;
            this.fechaFacturaRevisar.Name = "fechaFacturaRevisar";
            this.fechaFacturaRevisar.ReadOnly = true;
            this.fechaFacturaRevisar.Width = 104;
            // 
            // totalFacturadoRevisar
            // 
            this.totalFacturadoRevisar.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.totalFacturadoRevisar.HeaderText = "Total facturado";
            this.totalFacturadoRevisar.MinimumWidth = 6;
            this.totalFacturadoRevisar.Name = "totalFacturadoRevisar";
            this.totalFacturadoRevisar.ReadOnly = true;
            this.totalFacturadoRevisar.Width = 96;
            // 
            // verDetalleRevisado
            // 
            this.verDetalleRevisado.HeaderText = "Ver detalle facturado";
            this.verDetalleRevisado.MinimumWidth = 6;
            this.verDetalleRevisado.Name = "verDetalleRevisado";
            this.verDetalleRevisado.ReadOnly = true;
            this.verDetalleRevisado.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.verDetalleRevisado.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.verDetalleRevisado.Text = "Abrir";
            this.verDetalleRevisado.ToolTipText = "Abrir";
            this.verDetalleRevisado.Visible = false;
            this.verDetalleRevisado.Width = 125;
            // 
            // Serie
            // 
            this.Serie.HeaderText = "Serie";
            this.Serie.MinimumWidth = 6;
            this.Serie.Name = "Serie";
            this.Serie.ReadOnly = true;
            this.Serie.Visible = false;
            this.Serie.Width = 125;
            // 
            // Documento
            // 
            this.Documento.HeaderText = "Documento";
            this.Documento.MinimumWidth = 6;
            this.Documento.Name = "Documento";
            this.Documento.ReadOnly = true;
            this.Documento.Visible = false;
            this.Documento.Width = 125;
            // 
            // Tipo
            // 
            this.Tipo.HeaderText = "Tipo";
            this.Tipo.MinimumWidth = 6;
            this.Tipo.Name = "Tipo";
            this.Tipo.ReadOnly = true;
            this.Tipo.Visible = false;
            this.Tipo.Width = 125;
            // 
            // Sucursal
            // 
            this.Sucursal.HeaderText = "Sucursal";
            this.Sucursal.MinimumWidth = 6;
            this.Sucursal.Name = "Sucursal";
            this.Sucursal.ReadOnly = true;
            this.Sucursal.Visible = false;
            this.Sucursal.Width = 125;
            // 
            // Autorizacion
            // 
            this.Autorizacion.HeaderText = "Autorizacion";
            this.Autorizacion.MinimumWidth = 6;
            this.Autorizacion.Name = "Autorizacion";
            this.Autorizacion.ReadOnly = true;
            this.Autorizacion.Width = 125;
            // 
            // Numero
            // 
            this.Numero.HeaderText = "Numero";
            this.Numero.MinimumWidth = 6;
            this.Numero.Name = "Numero";
            this.Numero.ReadOnly = true;
            this.Numero.Width = 125;
            // 
            // SerieFel
            // 
            this.SerieFel.HeaderText = "Serie";
            this.SerieFel.MinimumWidth = 6;
            this.SerieFel.Name = "SerieFel";
            this.SerieFel.ReadOnly = true;
            this.SerieFel.Width = 125;
            // 
            // panel5
            // 
            this.panel5.Controls.Add(this.btnBuscar);
            this.panel5.Controls.Add(this.label20);
            this.panel5.Controls.Add(this.label3);
            this.panel5.Controls.Add(this.dtpFinal);
            this.panel5.Controls.Add(this.dtpInicio);
            this.panel5.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel5.Location = new System.Drawing.Point(3, 3);
            this.panel5.Name = "panel5";
            this.panel5.Size = new System.Drawing.Size(1258, 42);
            this.panel5.TabIndex = 1;
            // 
            // btnBuscar
            // 
            this.btnBuscar.Location = new System.Drawing.Point(358, 8);
            this.btnBuscar.Name = "btnBuscar";
            this.btnBuscar.Size = new System.Drawing.Size(130, 26);
            this.btnBuscar.TabIndex = 4;
            this.btnBuscar.Text = "Buscar";
            this.btnBuscar.UseVisualStyleBackColor = true;
            this.btnBuscar.Click += new System.EventHandler(this.btnBuscar_Click);
            // 
            // label20
            // 
            this.label20.AutoSize = true;
            this.label20.Location = new System.Drawing.Point(185, 15);
            this.label20.Name = "label20";
            this.label20.Size = new System.Drawing.Size(38, 13);
            this.label20.TabIndex = 3;
            this.label20.Text = "Hasta:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(15, 15);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(41, 13);
            this.label3.TabIndex = 2;
            this.label3.Text = "Desde:";
            // 
            // dtpFinal
            // 
            this.dtpFinal.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpFinal.Location = new System.Drawing.Point(229, 9);
            this.dtpFinal.Name = "dtpFinal";
            this.dtpFinal.Size = new System.Drawing.Size(105, 20);
            this.dtpFinal.TabIndex = 1;
            // 
            // dtpInicio
            // 
            this.dtpInicio.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpInicio.Location = new System.Drawing.Point(64, 9);
            this.dtpInicio.Name = "dtpInicio";
            this.dtpInicio.Size = new System.Drawing.Size(96, 20);
            this.dtpInicio.TabIndex = 0;
            // 
            // flowLayoutPanel14
            // 
            this.flowLayoutPanel14.BackColor = System.Drawing.Color.WhiteSmoke;
            this.flowLayoutPanel14.Controls.Add(this.btnReimprimirFactura);
            this.flowLayoutPanel14.Controls.Add(this.btnAnularFactura);
            this.flowLayoutPanel14.Dock = System.Windows.Forms.DockStyle.Right;
            this.flowLayoutPanel14.Location = new System.Drawing.Point(1267, 3);
            this.flowLayoutPanel14.Name = "flowLayoutPanel14";
            this.flowLayoutPanel14.Size = new System.Drawing.Size(136, 591);
            this.flowLayoutPanel14.TabIndex = 7;
            // 
            // btnReimprimirFactura
            // 
            this.btnReimprimirFactura.Location = new System.Drawing.Point(3, 3);
            this.btnReimprimirFactura.Name = "btnReimprimirFactura";
            this.btnReimprimirFactura.Size = new System.Drawing.Size(130, 26);
            this.btnReimprimirFactura.TabIndex = 0;
            this.btnReimprimirFactura.Text = "Reimprimir Factura";
            this.btnReimprimirFactura.UseVisualStyleBackColor = true;
            // 
            // btnAnularFactura
            // 
            this.btnAnularFactura.Location = new System.Drawing.Point(3, 35);
            this.btnAnularFactura.Name = "btnAnularFactura";
            this.btnAnularFactura.Size = new System.Drawing.Size(130, 26);
            this.btnAnularFactura.TabIndex = 1;
            this.btnAnularFactura.Text = "Anular Factura";
            this.btnAnularFactura.UseVisualStyleBackColor = true;
            this.btnAnularFactura.Click += new System.EventHandler(this.btnAnularFactura_Click);
            // 
            // tpFacturar
            // 
            this.tpFacturar.Controls.Add(this.dgvFacturas);
            this.tpFacturar.Controls.Add(this.flowLayoutPanel3);
            this.tpFacturar.Location = new System.Drawing.Point(4, 22);
            this.tpFacturar.Name = "tpFacturar";
            this.tpFacturar.Padding = new System.Windows.Forms.Padding(3);
            this.tpFacturar.Size = new System.Drawing.Size(1406, 597);
            this.tpFacturar.TabIndex = 0;
            this.tpFacturar.Text = "Facturar";
            this.tpFacturar.ToolTipText = "Generar factura nueva";
            this.tpFacturar.UseVisualStyleBackColor = true;
            // 
            // dgvFacturas
            // 
            this.dgvFacturas.AllowUserToAddRows = false;
            this.dgvFacturas.AllowUserToDeleteRows = false;
            this.dgvFacturas.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.DisplayedCells;
            dataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle6.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle6.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle6.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle6.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle6.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle6.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvFacturas.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle6;
            this.dgvFacturas.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.noOrden,
            this.tipoAdmision,
            this.paciente,
            this.fechaIngreso,
            this.totalFactura,
            this.verDetalle,
            this.idEspecialidad,
            this.Especialidad,
            this.IdTipoPaciente,
            this.TipoPaciente,
            this.IdPaciente,
            this.idSucursal});
            dataGridViewCellStyle9.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle9.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle9.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle9.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle9.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle9.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle9.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvFacturas.DefaultCellStyle = dataGridViewCellStyle9;
            this.dgvFacturas.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvFacturas.Location = new System.Drawing.Point(3, 3);
            this.dgvFacturas.Name = "dgvFacturas";
            this.dgvFacturas.ReadOnly = true;
            this.dgvFacturas.RowHeadersWidth = 51;
            this.dgvFacturas.Size = new System.Drawing.Size(1263, 591);
            this.dgvFacturas.TabIndex = 6;
            this.dgvFacturas.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvFacturas_CellContentClick);
            // 
            // noOrden
            // 
            this.noOrden.HeaderText = "Orden";
            this.noOrden.MaxInputLength = 25;
            this.noOrden.MinimumWidth = 6;
            this.noOrden.Name = "noOrden";
            this.noOrden.ReadOnly = true;
            this.noOrden.ToolTipText = "No. de orden de laboratorio";
            this.noOrden.Width = 61;
            // 
            // tipoAdmision
            // 
            this.tipoAdmision.HeaderText = "tipoAdmision";
            this.tipoAdmision.MinimumWidth = 6;
            this.tipoAdmision.Name = "tipoAdmision";
            this.tipoAdmision.ReadOnly = true;
            this.tipoAdmision.Visible = false;
            this.tipoAdmision.Width = 91;
            // 
            // paciente
            // 
            this.paciente.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.paciente.HeaderText = "Paciente";
            this.paciente.MinimumWidth = 6;
            this.paciente.Name = "paciente";
            this.paciente.ReadOnly = true;
            this.paciente.Width = 74;
            // 
            // fechaIngreso
            // 
            this.fechaIngreso.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            dataGridViewCellStyle7.Format = "g";
            dataGridViewCellStyle7.NullValue = null;
            this.fechaIngreso.DefaultCellStyle = dataGridViewCellStyle7;
            this.fechaIngreso.HeaderText = "Fecha de ingreso";
            this.fechaIngreso.MinimumWidth = 6;
            this.fechaIngreso.Name = "fechaIngreso";
            this.fechaIngreso.ReadOnly = true;
            this.fechaIngreso.Width = 114;
            // 
            // totalFactura
            // 
            this.totalFactura.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            dataGridViewCellStyle8.Format = "C2";
            dataGridViewCellStyle8.NullValue = null;
            this.totalFactura.DefaultCellStyle = dataGridViewCellStyle8;
            this.totalFactura.HeaderText = "Total a facturar";
            this.totalFactura.MinimumWidth = 6;
            this.totalFactura.Name = "totalFactura";
            this.totalFactura.ReadOnly = true;
            this.totalFactura.Width = 104;
            // 
            // verDetalle
            // 
            this.verDetalle.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.verDetalle.HeaderText = "Ver detalle";
            this.verDetalle.MinimumWidth = 15;
            this.verDetalle.Name = "verDetalle";
            this.verDetalle.ReadOnly = true;
            this.verDetalle.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.verDetalle.Text = "Abrir";
            this.verDetalle.ToolTipText = "Abrir Orden";
            this.verDetalle.UseColumnTextForButtonValue = true;
            this.verDetalle.Visible = false;
            this.verDetalle.Width = 63;
            // 
            // idEspecialidad
            // 
            this.idEspecialidad.HeaderText = "idEspecialidad";
            this.idEspecialidad.MinimumWidth = 6;
            this.idEspecialidad.Name = "idEspecialidad";
            this.idEspecialidad.ReadOnly = true;
            this.idEspecialidad.Visible = false;
            // 
            // Especialidad
            // 
            this.Especialidad.HeaderText = "Especialidad";
            this.Especialidad.MinimumWidth = 6;
            this.Especialidad.Name = "Especialidad";
            this.Especialidad.ReadOnly = true;
            this.Especialidad.Visible = false;
            this.Especialidad.Width = 92;
            // 
            // IdTipoPaciente
            // 
            this.IdTipoPaciente.HeaderText = "IdTipoPaciente";
            this.IdTipoPaciente.MinimumWidth = 6;
            this.IdTipoPaciente.Name = "IdTipoPaciente";
            this.IdTipoPaciente.ReadOnly = true;
            this.IdTipoPaciente.Visible = false;
            this.IdTipoPaciente.Width = 104;
            // 
            // TipoPaciente
            // 
            this.TipoPaciente.HeaderText = "TipoPaciente";
            this.TipoPaciente.MinimumWidth = 6;
            this.TipoPaciente.Name = "TipoPaciente";
            this.TipoPaciente.ReadOnly = true;
            this.TipoPaciente.Visible = false;
            this.TipoPaciente.Width = 95;
            // 
            // IdPaciente
            // 
            this.IdPaciente.HeaderText = "status";
            this.IdPaciente.MinimumWidth = 6;
            this.IdPaciente.Name = "IdPaciente";
            this.IdPaciente.ReadOnly = true;
            this.IdPaciente.Visible = false;
            this.IdPaciente.Width = 60;
            // 
            // idSucursal
            // 
            this.idSucursal.HeaderText = "Sucursal";
            this.idSucursal.MinimumWidth = 6;
            this.idSucursal.Name = "idSucursal";
            this.idSucursal.ReadOnly = true;
            this.idSucursal.Visible = false;
            this.idSucursal.Width = 73;
            // 
            // flowLayoutPanel3
            // 
            this.flowLayoutPanel3.BackColor = System.Drawing.Color.WhiteSmoke;
            this.flowLayoutPanel3.Controls.Add(this.btnGenerarFactura);
            this.flowLayoutPanel3.Controls.Add(this.btnVerDetalleFactura);
            this.flowLayoutPanel3.Dock = System.Windows.Forms.DockStyle.Right;
            this.flowLayoutPanel3.Location = new System.Drawing.Point(1266, 3);
            this.flowLayoutPanel3.Name = "flowLayoutPanel3";
            this.flowLayoutPanel3.Size = new System.Drawing.Size(137, 591);
            this.flowLayoutPanel3.TabIndex = 5;
            // 
            // btnGenerarFactura
            // 
            this.btnGenerarFactura.Location = new System.Drawing.Point(3, 3);
            this.btnGenerarFactura.Name = "btnGenerarFactura";
            this.btnGenerarFactura.Size = new System.Drawing.Size(130, 26);
            this.btnGenerarFactura.TabIndex = 0;
            this.btnGenerarFactura.Text = "Generar Factura";
            this.btnGenerarFactura.UseVisualStyleBackColor = true;
            this.btnGenerarFactura.Click += new System.EventHandler(this.btnGenerarFactura_Click);
            // 
            // btnVerDetalleFactura
            // 
            this.btnVerDetalleFactura.Location = new System.Drawing.Point(3, 35);
            this.btnVerDetalleFactura.Name = "btnVerDetalleFactura";
            this.btnVerDetalleFactura.Size = new System.Drawing.Size(130, 26);
            this.btnVerDetalleFactura.TabIndex = 1;
            this.btnVerDetalleFactura.Text = "Ver detalle de Factura";
            this.btnVerDetalleFactura.UseVisualStyleBackColor = true;
            this.btnVerDetalleFactura.Click += new System.EventHandler(this.btnVerDetalleFactura_Click);
            // 
            // tbcGeneral
            // 
            this.tbcGeneral.Controls.Add(this.tpFacturar);
            this.tbcGeneral.Controls.Add(this.tpRevision);
            this.tbcGeneral.Controls.Add(this.tpInstituciones);
            this.tbcGeneral.Controls.Add(this.tpEgresos);
            this.tbcGeneral.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tbcGeneral.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbcGeneral.ItemSize = new System.Drawing.Size(150, 18);
            this.tbcGeneral.Location = new System.Drawing.Point(0, 0);
            this.tbcGeneral.Multiline = true;
            this.tbcGeneral.Name = "tbcGeneral";
            this.tbcGeneral.SelectedIndex = 0;
            this.tbcGeneral.Size = new System.Drawing.Size(1414, 623);
            this.tbcGeneral.SizeMode = System.Windows.Forms.TabSizeMode.Fixed;
            this.tbcGeneral.TabIndex = 1;
            this.tbcGeneral.Visible = false;
            this.tbcGeneral.Selected += new System.Windows.Forms.TabControlEventHandler(this.tabControl1_Selected);
            // 
            // panel3
            // 
            this.panel3.Controls.Add(this.tbcGeneral);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel3.Location = new System.Drawing.Point(0, 51);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(1414, 623);
            this.panel3.TabIndex = 10;
            // 
            // tsbAperturarCaja
            // 
            this.tsbAperturarCaja.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tsbAperturarCaja.Image = global::INV_SYS.Properties.Resources.caja_registradora;
            this.tsbAperturarCaja.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbAperturarCaja.Name = "tsbAperturarCaja";
            this.tsbAperturarCaja.Size = new System.Drawing.Size(24, 24);
            this.tsbAperturarCaja.Text = "Aperturar caja";
            this.tsbAperturarCaja.Click += new System.EventHandler(this.aperturarCajaToolStripMenuItem_Click);
            // 
            // tsbCerrarSesion
            // 
            this.tsbCerrarSesion.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tsbCerrarSesion.Image = global::INV_SYS.Properties.Resources.receipt_close;
            this.tsbCerrarSesion.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbCerrarSesion.Name = "tsbCerrarSesion";
            this.tsbCerrarSesion.Size = new System.Drawing.Size(24, 24);
            this.tsbCerrarSesion.Text = "tsbCerrarCaja";
            this.tsbCerrarSesion.ToolTipText = "Cerrar caja";
            this.tsbCerrarSesion.Click += new System.EventHandler(this.cerrarCajaToolStripMenuItem_Click);
            // 
            // aperturarCajaToolStripMenuItem
            // 
            this.aperturarCajaToolStripMenuItem.Image = global::INV_SYS.Properties.Resources.caja_registradora;
            this.aperturarCajaToolStripMenuItem.Name = "aperturarCajaToolStripMenuItem";
            this.aperturarCajaToolStripMenuItem.Size = new System.Drawing.Size(148, 22);
            this.aperturarCajaToolStripMenuItem.Text = "Aperturar caja";
            this.aperturarCajaToolStripMenuItem.Click += new System.EventHandler(this.aperturarCajaToolStripMenuItem_Click);
            // 
            // cerrarCajaToolStripMenuItem
            // 
            this.cerrarCajaToolStripMenuItem.Image = global::INV_SYS.Properties.Resources.receipt_close;
            this.cerrarCajaToolStripMenuItem.Name = "cerrarCajaToolStripMenuItem";
            this.cerrarCajaToolStripMenuItem.Size = new System.Drawing.Size(148, 22);
            this.cerrarCajaToolStripMenuItem.Text = "Cerrar caja";
            this.cerrarCajaToolStripMenuItem.Click += new System.EventHandler(this.cerrarCajaToolStripMenuItem_Click);
            // 
            // frmInvSys
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1414, 674);
            this.Controls.Add(this.panel3);
            this.Controls.Add(this.tsFastAccessTools);
            this.Controls.Add(this.flowLayoutPanel1);
            this.Controls.Add(this.menuStrip1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "frmInvSys";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Sistema de Caja";
            this.Load += new System.EventHandler(this.frmInvSys_Load);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.tsFastAccessTools.ResumeLayout(false);
            this.tsFastAccessTools.PerformLayout();
            this.tpEgresos.ResumeLayout(false);
            this.panel8.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvGastos)).EndInit();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.flowLayoutPanel16.ResumeLayout(false);
            this.tpInstituciones.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.panel7.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.panel6.ResumeLayout(false);
            this.panel6.PerformLayout();
            this.flowLayoutPanel15.ResumeLayout(false);
            this.tpRevision.ResumeLayout(false);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.panel4.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvFacturasEmitidas)).EndInit();
            this.panel5.ResumeLayout(false);
            this.panel5.PerformLayout();
            this.flowLayoutPanel14.ResumeLayout(false);
            this.tpFacturar.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvFacturas)).EndInit();
            this.flowLayoutPanel3.ResumeLayout(false);
            this.tbcGeneral.ResumeLayout(false);
            this.panel3.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem cajaToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem facturasToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem reportesToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem configuracionesToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem sesiónToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem aperturarCajaToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem cerrarCajaToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem generarFacturaToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem imprimirListaDeFacturasToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem cortesParcialesDelDíaToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem egresosDelDíaToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem corteDeCajaToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem sucursalesToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem crearSucursalToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem verSucursalesToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem usuariosToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem crearUsuarioToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem modificarUsuarioToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem cajaToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem crearCajaNuevaToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem catálogosToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem institucionesToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem médicosToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem tiposDeCortesParcialesToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem tiposDeEgresosToolStripMenuItem;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel1;
        private System.Windows.Forms.ToolStrip tsFastAccessTools;
        private System.Windows.Forms.ToolStripButton tsbCerrarSesion;
        private System.Windows.Forms.ToolStripButton tsbAperturarCaja;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripMenuItem corteDeCajaToolStripMenuItem1;
        private System.Windows.Forms.Timer tmrData;
        private System.Windows.Forms.TabPage tpEgresos;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtMonto;
        private System.Windows.Forms.TextBox txtConcepto;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnEgreso;
        private System.Windows.Forms.ComboBox cmbProveedores;
        private System.Windows.Forms.DateTimePicker dateTimePicker2;
        private System.Windows.Forms.Label lblTipoEgreso;
        private System.Windows.Forms.Label lblFechaEgreso;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel16;
        private System.Windows.Forms.Button btnImprimirEgresosDia;
        private System.Windows.Forms.TabPage tpInstituciones;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label lblTituloInsituciones;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.ComboBox cmbClientes;
        private System.Windows.Forms.DateTimePicker dtpFechaFinal;
        private System.Windows.Forms.DateTimePicker dtpFechaInicial;
        private System.Windows.Forms.Label lblInstitucionFact;
        private System.Windows.Forms.Label lblFechaFinalFactura;
        private System.Windows.Forms.Label lblFechaInicialFactura;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel15;
        private System.Windows.Forms.Button btnGenerarFacturaInstitucion;
        private System.Windows.Forms.Button btnListaPeticiones;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.TabPage tpRevision;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel14;
        private System.Windows.Forms.Button btnReimprimirFactura;
        private System.Windows.Forms.Button btnAnularFactura;
        private System.Windows.Forms.TabPage tpFacturar;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel3;
        private System.Windows.Forms.Button btnGenerarFactura;
        private System.Windows.Forms.Button btnVerDetalleFactura;
        private System.Windows.Forms.TabControl tbcGeneral;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.DataGridView dgvFacturas;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.DataGridView dgvFacturasEmitidas;
        private System.Windows.Forms.Panel panel5;
        private System.Windows.Forms.Button btnBuscar;
        private System.Windows.Forms.Label label20;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.DateTimePicker dtpFinal;
        private System.Windows.Forms.DateTimePicker dtpInicio;
        private System.Windows.Forms.DataGridViewTextBoxColumn noOrden;
        private System.Windows.Forms.DataGridViewTextBoxColumn tipoAdmision;
        private System.Windows.Forms.DataGridViewTextBoxColumn paciente;
        private System.Windows.Forms.DataGridViewTextBoxColumn fechaIngreso;
        private System.Windows.Forms.DataGridViewTextBoxColumn totalFactura;
        private System.Windows.Forms.DataGridViewButtonColumn verDetalle;
        private System.Windows.Forms.DataGridViewTextBoxColumn idEspecialidad;
        private System.Windows.Forms.DataGridViewTextBoxColumn Especialidad;
        private System.Windows.Forms.DataGridViewTextBoxColumn IdTipoPaciente;
        private System.Windows.Forms.DataGridViewTextBoxColumn TipoPaciente;
        private System.Windows.Forms.DataGridViewTextBoxColumn IdPaciente;
        private System.Windows.Forms.DataGridViewTextBoxColumn idSucursal;
        private System.Windows.Forms.DataGridViewTextBoxColumn noOrdenRevisar;
        private System.Windows.Forms.DataGridViewTextBoxColumn Cliente;
        private System.Windows.Forms.DataGridViewTextBoxColumn NIT;
        private System.Windows.Forms.DataGridViewTextBoxColumn fechaFacturaRevisar;
        private System.Windows.Forms.DataGridViewTextBoxColumn totalFacturadoRevisar;
        private System.Windows.Forms.DataGridViewButtonColumn verDetalleRevisado;
        private System.Windows.Forms.DataGridViewTextBoxColumn Serie;
        private System.Windows.Forms.DataGridViewTextBoxColumn Documento;
        private System.Windows.Forms.DataGridViewTextBoxColumn Tipo;
        private System.Windows.Forms.DataGridViewTextBoxColumn Sucursal;
        private System.Windows.Forms.DataGridViewTextBoxColumn Autorizacion;
        private System.Windows.Forms.DataGridViewTextBoxColumn Numero;
        private System.Windows.Forms.DataGridViewTextBoxColumn SerieFel;
        private System.Windows.Forms.Panel panel6;
        private System.Windows.Forms.Panel panel7;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label lblTotalFactura;
        private System.Windows.Forms.Label lblFechaFinal;
        private System.Windows.Forms.Label lblFechaInicial;
        private System.Windows.Forms.Label lblInstitucion;
        private System.Windows.Forms.Label lblNIT;
        private System.Windows.Forms.Label lblinfototal;
        private System.Windows.Forms.Label lblInfofFinal;
        private System.Windows.Forms.Label lblInfoFInicial;
        private System.Windows.Forms.Label lblinfoInstitucion;
        private System.Windows.Forms.Label lblInfoNit;
        private System.Windows.Forms.Panel panel8;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.DataGridView dgvGastos;
        private System.Windows.Forms.DataGridViewTextBoxColumn gasto;
        private System.Windows.Forms.DataGridViewTextBoxColumn FechaEgreso;
        private System.Windows.Forms.DataGridViewTextBoxColumn tipoEgreso;
        private System.Windows.Forms.DataGridViewTextBoxColumn Proveedor;
        private System.Windows.Forms.DataGridViewTextBoxColumn Descripcion;
        private System.Windows.Forms.DataGridViewTextBoxColumn Monto;
        private System.Windows.Forms.DataGridViewButtonColumn opEditar;
        private System.Windows.Forms.DataGridViewButtonColumn opEliminar;
    }
}


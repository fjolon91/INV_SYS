using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using CrystalDecisions.CrystalReports.Engine;
using CrystalDecisions.Shared;
using System.Data.SqlClient;

namespace INV_SYS.Formularios
{
    public partial class frmImpresionDocumento : Form
    {
        public ReportDocument cryRpt;
        private string documento;
        private string serieDocumento;
        private string tipoDocumento;
        private int tipoImpresion;
        private string sucursal;
        private string pathRpt;
        public frmImpresionDocumento(int tipoImpresion, string tipoDocumento,  string serieDocumento, string documento, string sucursal)
        {
            InitializeComponent();
            this.tipoImpresion = tipoImpresion;
            this.tipoDocumento = tipoDocumento;
            this.serieDocumento = serieDocumento;
            this.documento = documento;
            this.sucursal = sucursal;
            cargarDocumentoRPT();

        }
        public void loginCrystal(string _dataSoursce, string _dataDB, string _userId, string _passworDB)
        {
            TableLogOnInfos crtableLogoninfos = new TableLogOnInfos();
            TableLogOnInfo crtableLogoninfo = new TableLogOnInfo();
            ConnectionInfo crConnectionInfo = new ConnectionInfo();
            Tables CrTables;
            crConnectionInfo.ServerName = _dataSoursce;
            crConnectionInfo.DatabaseName = _dataDB;
            crConnectionInfo.UserID = _userId;
            crConnectionInfo.Password = _passworDB;
            CrTables = cryRpt.Database.Tables;
            foreach (CrystalDecisions.CrystalReports.Engine.Table CrTable in CrTables)
            {
                crtableLogoninfo = CrTable.LogOnInfo;
                crtableLogoninfo.ConnectionInfo = crConnectionInfo;
                CrTable.ApplyLogOnInfo(crtableLogoninfo);
            }
        }
        private void cargarDocumentoRPT()
        {
            string cadena = Properties.Settings.Default.Conexion;
            SqlConnectionStringBuilder SConn = new SqlConnectionStringBuilder(cadena);
            pathRpt = Application.StartupPath + @"\Reportes";
            cryRpt = new ReportDocument();

            switch (tipoImpresion)
            {
                case 1://Facturas
                    cryRpt.Load("" + pathRpt + @"\Facturacion\FACTURA.rpt");
                    cryRpt.SetParameterValue("documento", documento);
                    cryRpt.SetParameterValue("serieDocumento", serieDocumento);
                    cryRpt.SetParameterValue("tipoDocumento", tipoDocumento);
                    cryRpt.SetParameterValue("sucursal", sucursal);

                    string rutaQRFel = "";
                    DataTable dtRutaQr = new DataTable();
                    dtRutaQr = RDocumento.existeDocumento(tipoDocumento, serieDocumento, sucursal, documento);

                    if (tipoDocumento.CompareTo("F") == 0)
                    {
                        rutaQRFel = dtRutaQr.Rows[0]["FELQr"].ToString();
                        cryRpt.SetParameterValue("rutaQR", @"" + rutaQRFel);
                    }
                    else
                    {
                        cryRpt.SetParameterValue("rutaQR", "");
                    }
                    break;                   
            }
            loginCrystal(SConn.DataSource, SConn.InitialCatalog, SConn.UserID, SConn.Password);
            rptDocumento.ReportSource = cryRpt;
            rptDocumento.Refresh();
        }

        
    }
}

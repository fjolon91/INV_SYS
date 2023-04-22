using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;


namespace INV_SYS
{
    public class RConceptoCaja
    {
        public static DataTable listarConceptosCaja()
        {
            using (SqlConnection cnn = RConexion.Conectando(Properties.Settings.Default.Conexion))
            {
                SqlCommand query = new SqlCommand(string.Format(@"SELECT *
                                                                      FROM [dbo].[CONCEPTO_CAJA] WHERE Vigente=1 ORDER BY DESCRIPCION"), cnn);
                DataTable dt = new DataTable();
                dt.Load(query.ExecuteReader());
                return dt;
            }
        }

        public static DataTable conceptosCorteCaja()
        {
            using (SqlConnection cnn = RConexion.Conectando(Properties.Settings.Default.Conexion))
            {
                SqlCommand query = new SqlCommand(string.Format(@"SELECT *
                                                                      FROM [dbo].[CONCEPTO_CAJA] WHERE Vigente=1 AND descripcion ='CORTE DE CAJA' ORDER BY DESCRIPCION"), cnn);
                DataTable dt = new DataTable();
                dt.Load(query.ExecuteReader());
                return dt;
            }
        }
        public static DataTable listarConceptosCajaGastos()
        {
            using (SqlConnection cnn = RConexion.Conectando(Properties.Settings.Default.Conexion))
            {
                SqlCommand query = new SqlCommand(string.Format(@"SELECT *
                                                                      FROM [dbo].[CONCEPTO_CAJA] WHERE Vigente=1 and tipo ='-1' ORDER BY DESCRIPCION"), cnn);
                DataTable dt = new DataTable();
                dt.Load(query.ExecuteReader());
                return dt;
            }
        }
        public static DataTable ListarConceptosCajaId(string id)
        {
            using (SqlConnection cnn = RConexion.Conectando(Properties.Settings.Default.Conexion))
            {
                SqlCommand query = new SqlCommand(string.Format(@"SELECT *
                                                                      FROM [dbo].[CONCEPTO_CAJA] WHERE  Vigente=1 and concepto ='" + id + "'"), cnn);
                DataTable dt = new DataTable();
                dt.Load(query.ExecuteReader());
                return dt;
            }
        }
    }
}

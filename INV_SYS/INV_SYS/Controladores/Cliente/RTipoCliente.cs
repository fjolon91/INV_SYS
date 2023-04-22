using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;

namespace INV_SYS
{
    public class RTipoCliente
    {
        public static DataTable ListarTipoCliente()
        {
            using (SqlConnection cnn = RConexion.Conectando(Properties.Settings.Default.Conexion))
            {
                SqlCommand query = new SqlCommand(string.Format(@"SELECT tipoCliente,descripcion,descuento,vigente,orden
                                                                    FROM [dbo].[TIPO_CLIENTE] where vigente = 1 order by orden asc"), cnn);
                DataTable dt = new DataTable();
                dt.Load(query.ExecuteReader());
                return dt;
            }
        }

        public static DataTable ListarTipoClienteId(string id)
        {
            using (SqlConnection cnn = RConexion.Conectando(Properties.Settings.Default.Conexion))
            {
                SqlCommand query = new SqlCommand(string.Format(@"SELECT tipoCliente,descripcion,descuento,vigente,orden
                                                                    FROM [dbo].[TIPO_CLIENTE] where vigente = 1 and tipoCliente='" + id + "'"), cnn);
                DataTable dt = new DataTable();
                dt.Load(query.ExecuteReader());
                return dt;
            }
        }
    }
}

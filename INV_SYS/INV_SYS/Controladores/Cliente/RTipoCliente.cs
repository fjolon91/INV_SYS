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

        public static int crearTipoCliente(ETipoCliente cliente)
        {
            int retorno;
            if (String.IsNullOrEmpty(cliente.tipoCliente))
                cliente.tipoCliente = "DEFAULT";
            using (SqlConnection cnn = RConexion.Conectando(Properties.Settings.Default.Conexion))
            {
                SqlCommand query = new SqlCommand(string.Format(@"INSERT INTO [dbo].[TIPO_CLIENTE]
                                                                                       ([tipocliente]
                                                                                       ,[descripcion]
                                                                                       ,[descuento]
                                                                                       ,[orden]
                                                                                       ,[vigente])
                                                                                 VALUES
                                                                                       ('" + cliente.tipoCliente + "'" +
                                                                                       ",'" + cliente.descuento + "'" +
                                                                                       ",'" + cliente.descuento + "'" +
                                                                                       ", '" + cliente.orden + "'" +
                                                                                       ",'" + cliente.status + "')"), cnn);
                retorno = query.ExecuteNonQuery();
                cnn.Close();
            }

            return retorno;
        }
    }
}

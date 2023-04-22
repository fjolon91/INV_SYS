using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;


namespace INV_SYS
{
    public class RTipoDocumento
    {
        public static DataTable listarTipoDocumento()
        {
            using (SqlConnection cnn = RConexion.Conectando(Properties.Settings.Default.Conexion))
            {
                SqlCommand query = new SqlCommand(string.Format(@"SELECT [tipoDocumento]
                                                                      ,[descripcion]
                                                                      ,[orden]
                                                                      ,[status]
                                                                  FROM [dbo].[TIPO_DOCUMENTO] where status = 1 order by orden asc"), cnn);
                DataTable dt = new DataTable();
                dt.Load(query.ExecuteReader());
                return dt;
            }
        }

        public static DataTable buscarTipoDocumentoId(string id)
        {
            using (SqlConnection cnn = RConexion.Conectando(Properties.Settings.Default.Conexion))
            {
                SqlCommand query = new SqlCommand(string.Format(@"SELECT [tipoDocumento]
                                                                      ,[descripcion]
                                                                      ,[orden]
                                                                      ,[status]
                                                                  FROM [dbo].[TIPO_DOCUMENTO] where status = 1 and tipoDocumento ='" + id + "' order by orden asc"), cnn);
                DataTable dt = new DataTable();
                dt.Load(query.ExecuteReader());
                return dt;
            }
        }

    }
}

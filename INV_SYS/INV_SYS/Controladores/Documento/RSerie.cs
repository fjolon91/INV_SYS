using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;

namespace INV_SYS
{
    public class RSerie
    {
        public static DataTable listarSerieDocumento()
        {
            using (SqlConnection cnn = RConexion.Conectando(Properties.Settings.Default.Conexion))
            {
                SqlCommand query = new SqlCommand(string.Format(@"SELECT [serieDocumento]
                                                                      ,[descripcion]
                                                                      ,[status]
                                                                      ,[orden]
                                                                  FROM [dbo].[SERIE_DOCUMENTO] where status = 1 order by orden asc"), cnn);
                DataTable dt = new DataTable();
                dt.Load(query.ExecuteReader());
                return dt;
            }
        }
    }
}

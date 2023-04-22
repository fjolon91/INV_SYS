using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;

namespace INV_SYS
{
    public class RTipoPago
    {
        public static DataTable listarTipoPago()
        {
            using (SqlConnection cnn = RConexion.Conectando(Properties.Settings.Default.Conexion))
            {
                SqlCommand query = new SqlCommand(string.Format(@"SELECT [tipoPago]
                                                                      ,[descripcion]
                                                                      ,[orden]
                                                                      ,[status]
                                                                  FROM [dbo].[TIPO_PAGO] WHERE status =1 order by orden asc"), cnn);
                DataTable dt = new DataTable();
                dt.Load(query.ExecuteReader());
                return dt;
            }
        }
    }
}

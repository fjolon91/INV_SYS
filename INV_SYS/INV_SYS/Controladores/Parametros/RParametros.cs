using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;

namespace INV_SYS
{
    public class RParametros
    {
        public static DataTable VerificarConfiguracion(string categoria, string propiedad)
        {
            using (SqlConnection cnn = RConexion.Conectando(Properties.Settings.Default.Conexion))
            {
                SqlCommand query = new SqlCommand(string.Format(@"SELECT *
                                                                      FROM [dbo].[PARAMETROS] WHERE categoria='" + categoria + "' and propiedad='" + propiedad + "'"), cnn);
                DataTable dt = new DataTable();
                dt.Load(query.ExecuteReader());
                return dt;
            }
        }
    }
}

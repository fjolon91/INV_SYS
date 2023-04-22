using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;

namespace INV_SYS
{
    public class RSucursal
    {
        public static DataTable listarSucursales()
        {
            using (SqlConnection cnn = RConexion.Conectando(Properties.Settings.Default.Conexion))
            {
                SqlCommand query = new SqlCommand(string.Format(@"SELECT [sucursal]
                                                                  ,[nombre]
                                                                  ,[direccion]
                                                                  ,[telefono]
                                                                  ,[email]
                                                                    FROM [dbo].[SUCURSAL] where status = 1 order by orden asc"), cnn);
                DataTable dt = new DataTable();
                dt.Load(query.ExecuteReader());
                return dt;
            }
        }

        public static DataTable obtenerSucursalDefualt()
        {
            using (SqlConnection cnn = RConexion.Conectando(Properties.Settings.Default.Conexion))
            {
                SqlCommand query = new SqlCommand(string.Format(@"SELECT * FROM [dbo].[SUCURSAL] where status = 1 and uso=1 order by orden asc"), cnn);
                DataTable dt = new DataTable();
                dt.Load(query.ExecuteReader());
                return dt;
            }
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
namespace INV_SYS
{
    public class RProveedor
    {
        public static DataTable listarProveedoresVigentes()
        {
            using (SqlConnection cnn = RConexion.Conectando(Properties.Settings.Default.Conexion))
            {
                SqlCommand query = new SqlCommand(string.Format(@"SELECT [proveedor]
                                                                          ,[nombre], nombre +' - '+ proveedor AS ProveedorNit
                                                                          ,[direccion]
                                                                          ,[telefono]
                                                                          ,[email]
                                                                          ,[orden]
                                                                          ,[status]
                                                                      FROM [dbo].[PROVEEDOR]  where Status = 1 AND nombre<>'' order by nombre asc"), cnn);
                DataTable dt = new DataTable();
                dt.Load(query.ExecuteReader());
                return dt;
            }
        }
    }
}

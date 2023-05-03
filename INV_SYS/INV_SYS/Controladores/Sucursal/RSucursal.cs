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

        public static DataTable buscarSucursal(string id)
        {
            using (SqlConnection cnn = RConexion.Conectando(Properties.Settings.Default.Conexion))
            {
                SqlCommand query = new SqlCommand(string.Format(@"SELECT [sucursal]
                                                                  ,[nombre]
                                                                  ,[direccion]
                                                                  ,[telefono]
                                                                  ,[email]
                                                                    FROM [dbo].[SUCURSAL] where sucursal ='"+id+"' and status = 1 order by orden asc"), cnn);
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

        public static int crearSucursal(ESucursal sucursal)
        {
            int retorno;
            using (SqlConnection cnn = RConexion.Conectando(Properties.Settings.Default.Conexion))
            {
                SqlCommand query = new SqlCommand(string.Format(@"INSERT INTO [dbo].[SUCURSAL]
                                                                                               ([sucursal]
                                                                                               ,[nombre]
                                                                                               ,[status]
                                                                                               ,[orden])
                                                                                      VALUES
                                                                                       ('" + sucursal.sucursal + "'" +
                                                                                       ",'" + sucursal.nombre + "'" +
                                                                                         ", '" + sucursal.status + "'" +
                                                                                       ",'" + sucursal.orden + "')"), cnn);
                retorno = query.ExecuteNonQuery();
                cnn.Close();
            }
            return retorno;
        }
    }
}

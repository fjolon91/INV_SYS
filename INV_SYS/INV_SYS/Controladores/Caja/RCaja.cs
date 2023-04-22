using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;

namespace INV_SYS
{
    public class RCaja
    {
        public static int registrarCaja(ECaja caja)
        {
            int retorno;
            using (SqlConnection cnn = RConexion.Conectando(Properties.Settings.Default.Conexion))
            {

                SqlCommand query = new SqlCommand(string.Format(@"INSERT INTO [dbo].[CAJA]
                                                                                   ([caja]
                                                                                   ,[descripcion],
                                                                                   ,[sucursal],
                                                                                   ,[status],
                                                                                    [vigente])
                                                                                     VALUES
                                                                                       ('" + caja.caja + "'" +
                                                                                       ",'" + caja.descripcion + "'" +
                                                                                       ",'" + caja.sucursal + "'" +
                                                                                       ", 'C'" +
                                                                                       ",'" + caja.vigente + "')"), cnn);
                retorno = query.ExecuteNonQuery();
                cnn.Close();
            }

            return retorno;
        }

        public static int actualizarStatusCaja(ECaja caja)
        {
            int retorno;
            using (SqlConnection cnn = RConexion.Conectando(Properties.Settings.Default.Conexion))
            {

                SqlCommand query = new SqlCommand(string.Format(@"UPDATE [dbo].[CAJA] SET [status] = '" + caja.status + "'" +
                                                                      " WHERE caja ='" + caja.caja + "' AND sucursal ='" + caja.sucursal + "'"), cnn);
                retorno = query.ExecuteNonQuery();
                cnn.Close();
            }

            return retorno;
        }

        public static int actualizarCaja(ECaja caja)
        {
            int retorno;
            using (SqlConnection cnn = RConexion.Conectando(Properties.Settings.Default.Conexion))
            {

                SqlCommand query = new SqlCommand(string.Format(@"UPDATE [dbo].[CAJA] SET [descripcion] = '" + caja.descripcion + "'" +
                                                                      ",[vigente] = '" + caja.vigente + "'" +
                                                                      " WHERE caja ='" + caja.caja + "' AND sucursal ='" + caja.sucursal + "'"), cnn);
                retorno = query.ExecuteNonQuery();
                cnn.Close();
            }

            return retorno;
        }


        public static DataTable listarCajas()
        {
            using (SqlConnection cnn = RConexion.Conectando(Properties.Settings.Default.Conexion))
            {
                SqlCommand query = new SqlCommand(string.Format(@"SELECT * FROM [dbo].[CAJA] WHERE  Vigente=1"), cnn);
                DataTable dt = new DataTable();
                dt.Load(query.ExecuteReader());
                return dt;
            }
        }


        public static DataTable listarCajasStatus(string sucursal, string status)
        {
            using (SqlConnection cnn = RConexion.Conectando(Properties.Settings.Default.Conexion))
            {
                SqlCommand query = new SqlCommand(string.Format(@"SELECT * FROM [dbo].[CAJA] WHERE  Vigente=1 AND sucursal='" + sucursal + "' AND status='" + status + "'"), cnn);
                DataTable dt = new DataTable();
                dt.Load(query.ExecuteReader());
                return dt;
            }
        }
        public static DataTable listarCajasPC(string PC, string status)
        {
            using (SqlConnection cnn = RConexion.Conectando(Properties.Settings.Default.Conexion))
            {
                SqlCommand query = new SqlCommand(string.Format(@"SELECT * FROM [dbo].[CAJA] WHERE  Vigente=1 AND pc='" + PC + "' AND status='" + status + "'"), cnn);
                DataTable dt = new DataTable();
                dt.Load(query.ExecuteReader());
                return dt;
            }
        }

        public static DataTable obtenerStatusCaja(string PC)
        {
            using (SqlConnection cnn = RConexion.Conectando(Properties.Settings.Default.Conexion))
            {
                SqlCommand query = new SqlCommand(string.Format(@"SELECT * FROM [dbo].[CAJA] WHERE  Vigente=1 AND pc='" + PC + "'"), cnn);
                DataTable dt = new DataTable();
                dt.Load(query.ExecuteReader());
                return dt;
            }
        }
        public static DataTable listarCajasSucursal(string sucursal)
        {
            using (SqlConnection cnn = RConexion.Conectando(Properties.Settings.Default.Conexion))
            {
                SqlCommand query = new SqlCommand(string.Format(@"SELECT * FROM [dbo].[CAJA] WHERE  Vigente=1 AND sucursal ='" + sucursal + "'"), cnn);
                DataTable dt = new DataTable();
                dt.Load(query.ExecuteReader());
                return dt;
            }
        }
        public static DataTable listarCajasId(string id, string sucursal)
        {
            using (SqlConnection cnn = RConexion.Conectando(Properties.Settings.Default.Conexion))
            {
                SqlCommand query = new SqlCommand(string.Format(@"SELECT * FROM [dbo].[CAJA] WHERE  Vigente=1 and caja ='" + id + "'"), cnn);
                DataTable dt = new DataTable();
                dt.Load(query.ExecuteReader());
                return dt;
            }
        }

        public static DataTable verificarAperturaCaja(string id, string sucursal)
        {
            using (SqlConnection cnn = RConexion.Conectando(Properties.Settings.Default.Conexion))
            {
                SqlCommand query = new SqlCommand(string.Format(@"SELECT * FROM [dbo].[CAJA] WHERE  Vigente=1 and caja ='" + id + "' and sucursal='" + sucursal + "' and status ='C' "), cnn);
                DataTable dt = new DataTable();
                dt.Load(query.ExecuteReader());
                return dt;
            }
        }

    }
}

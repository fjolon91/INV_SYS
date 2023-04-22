using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;

namespace INV_SYS
{
    public class RUsuario
    {
        public static DataTable loginUsuario(string user, string pass)
        {
            using (SqlConnection cnn = RConexion.Conectando(Properties.Settings.Default.Conexion))
            {
                SqlCommand query = new SqlCommand(string.Format(@"SELECT usuario, clave 
                                                                    FROM USUARIO
                                                                    WHERE usuario = '" + user + "' and clave = '" + pass + "' and status= 1"), cnn);
                DataTable dt = new DataTable();
                dt.Load(query.ExecuteReader());
                cnn.Close();
                return dt;
            }
        }
        public static DataTable listarUsuarios()
        {
            using (SqlConnection cnn = RConexion.Conectando(Properties.Settings.Default.Conexion))
            {
                SqlCommand query = new SqlCommand(string.Format(@"SELECT U.Usuario, U.Nombre, R.descripcion as Rol, U.Telefono, U.Email 
                                                                 FROM USUARIO U
                                                                INNER JOIN ROLES R ON R.rol = U.rol
                                                                WHERE U.status=1;"), cnn);
                DataTable dt = new DataTable();
                dt.Load(query.ExecuteReader());
                return dt;
            }
        }

        public static DataTable verificarUsuario(string user)
        {
            using (SqlConnection cnn = RConexion.Conectando(Properties.Settings.Default.Conexion))
            {
                SqlCommand query = new SqlCommand(string.Format(@"SELECT * 
                                                                    FROM USUARIO
                                                                    WHERE usuario = '" + user + "'"), cnn);
                DataTable dt = new DataTable();
                dt.Load(query.ExecuteReader());
                return dt;
            }
        }

        public static int crearUsuario(EUsuario user)
        {
            int retorno;
            using (SqlConnection cnn = RConexion.Conectando(Properties.Settings.Default.Conexion))
            {
                SqlCommand query = new SqlCommand(string.Format(@"INSERT INTO [dbo].[USUARIO]
                                                                                       ([usuario]
                                                                                       ,[nombre]
                                                                                       ,[clave]
                                                                                       ,[rol]
                                                                                       ,[telefono]
                                                                                       ,[email],[medicoAsociado]
                                                                                       ,[status])
                                                                                      VALUES
                                                                                       ('" + user.usuario + "'" +
                                                                                       ",'" + user.nombre + "'" +
                                                                                       ",'" + user.clave + "'" +
                                                                                       ", '" + user.rol + "'" +
                                                                                        ", '" + user.telefono + "'" +
                                                                                         ", '" + user.email + "'" +
                                                                                       ",'" + user.status + "')"), cnn);
                retorno = query.ExecuteNonQuery();
                cnn.Close();
            }

            return retorno;
        }


        public static int actualizarUsario(EUsuario user)
        {
            int retorno;
            using (SqlConnection cnn = RConexion.Conectando(Properties.Settings.Default.Conexion))
            {
                SqlCommand query = new SqlCommand(string.Format(@"UPDATE [USUARIO] SET
                                                                                               [nombre]=   '" + user.nombre + "'" +
                                                                                               ",[clave]= '" + user.clave + "'" +
                                                                                                ",[rol]= '" + user.rol + "'" +
                                                                                               ",[telefono]= '" + user.telefono + "'" +
                                                                                               ",[email]= '" + user.email + "'" +
                                                                                               ",[status]= '" + user.status + "' WHERE usuario = '" + user.usuario + "'"), cnn);
                retorno = query.ExecuteNonQuery();
                cnn.Close();
            }

            return retorno;
        }
    }
}

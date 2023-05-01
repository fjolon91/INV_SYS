using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using System.Data.SqlClient;
using System.Data;

namespace INV_SYS
{
    public class RPaciente
    {
        public static DataTable verificarPaciente(string id, string tipoPaciente)
        {
            using (SqlConnection cnn = RConexion.Conectando(Properties.Settings.Default.Conexion))
            {
                SqlCommand query = new SqlCommand(string.Format(@"SELECT *
                                                              FROM [dbo].[_CAT_PACIENTE] WHERE  paciente ='" + id + "' and tipoPaciente='" + tipoPaciente + "'"), cnn);
                DataTable dt = new DataTable();
                dt.Load(query.ExecuteReader());
                return dt;
            }
        }

        public static int agregarPaciente(string nombre, DateTime fechaNacimiento, string tipoAdmision, string admision, string tipoPaciente)
        {
            int retorno;
            using (SqlConnection cnn = RConexion.Conectando(Properties.Settings.Default.Conexion))
            {

                SqlCommand query = new SqlCommand(string.Format(@"UPDATE [dbo].[_ADMISION] 
                                                                   SET [nombre]='" + nombre + "', fechaNacimiento='" + fechaNacimiento.ToString("yyyyMMdd") + "', tipoPaciente ='" + tipoPaciente + "' WHERE tipoAdmision ='" + tipoAdmision + "' and Admision='" + admision + "'"), cnn);

                retorno = query.ExecuteNonQuery();

                cnn.Close();
            }

            return retorno;
        }
    }
}

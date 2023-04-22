using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace INV_SYS
{
    public class RConexion
    {
        public string CadenaConexion = Properties.Settings.Default.Conexion;
        public static SqlConnection Conectando(string CadenaConexion)
        {
            SqlConnection cnn = new SqlConnection(CadenaConexion);
            try
            {
                cnn.Open();
                return cnn;
            }
            catch (SqlException e)
            {
                MessageBox.Show("Error de conexión " + CadenaConexion + " \n" + e.InnerException, "Alerta", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            return cnn;
        }
    }
}

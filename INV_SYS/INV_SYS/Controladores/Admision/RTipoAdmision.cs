using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;

namespace INV_SYS
{
    public class RTipoAdmision
    {
        public static DataTable listarTipoAdmision()
        {
            using (SqlConnection cnn = RConexion.Conectando(Properties.Settings.Default.Conexion))
            {
                SqlCommand query = new SqlCommand(string.Format(@"SELECT tipoAdmision,descripcion,status,orden
                                                                    FROM [dbo].[TIPO_ADMISION] where status = 1 order by orden asc"), cnn);
                DataTable dt = new DataTable();
                dt.Load(query.ExecuteReader());
                return dt;
            }
        }

        public static DataTable buscarTipoAdmision(string id)
        {
            using (SqlConnection cnn = RConexion.Conectando(Properties.Settings.Default.Conexion))
            {
                SqlCommand query = new SqlCommand(string.Format(@"SELECT tipoAdmision,descripcion,status,orden
                                                                    FROM [dbo].[TIPO_ADMISION] where tipoAdmision ='"+id+"' and status = 1 order by orden asc"), cnn);
                DataTable dt = new DataTable();
                dt.Load(query.ExecuteReader());
                return dt;
            }
        }

        public static int crearTipoAdmision(ETipoAdmision tipo)
        {
            int retorno;
            using (SqlConnection cnn = RConexion.Conectando(Properties.Settings.Default.Conexion))
            {
                SqlCommand query = new SqlCommand(string.Format(@"INSERT INTO [dbo].[TIPO_ADMISION]
                                                                                               ([tipoAdmision]
                                                                                               ,[descripcion]
                                                                                               ,[status]
                                                                                               ,[orden])
                                                                                      VALUES
                                                                                       ('" + tipo.tipoAdmision + "'" +
                                                                                       ",'" + tipo.descripcion+ "'" +
                                                                                         ", '" + tipo.status + "'" +
                                                                                       ",'" + tipo.orden+ "')"), cnn);
                retorno = query.ExecuteNonQuery();
                cnn.Close();
            }
            return retorno;
        }

    }
}

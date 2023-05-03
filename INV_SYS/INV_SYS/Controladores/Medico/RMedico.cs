using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;

namespace INV_SYS
{
    public class RMedico
    {
        public static DataTable buscarMedico(string Id)
        {
            using (SqlConnection cnn = RConexion.Conectando(Properties.Settings.Default.Conexion))
            {
                SqlCommand query = new SqlCommand(string.Format(@"SELECT [Medico]
                                                                              ,[Nombre]
                                                                              ,[Colegiado]
                                                                              ,[Telefono]
                                                                              ,[Email]
                                                                              ,[Comision]
                                                                              ,[Status]
                                                                          FROM [dbo].[MEDICO] where medico= '" + Id + "' and  status=1 order by nombre asc"), cnn);
                DataTable dt = new DataTable();
                dt.Load(query.ExecuteReader());
                return dt;
            }
        }

        public static int crearMedico(EMedico medico)
        {
            int retorno;
            using (SqlConnection cnn = RConexion.Conectando(Properties.Settings.Default.Conexion))
            {
                SqlCommand query = new SqlCommand(string.Format(@"INSERT INTO [dbo].[MEDICO]
                                                                                               ([medico]
                                                                                               ,[nombre]
                                                                                               ,[colegiado]
                                                                                               ,[telefono]
                                                                                               ,[email]
                                                                                               ,[comision]
                                                                                               ,[status])
                                                                                      VALUES
                                                                                       ('" + medico.medico + "'" +
                                                                                       ",'" + medico.nombre + "'" +
                                                                                       ",'" + medico.colegiado + "'" +
                                                                                       ", '" + medico.telefono + "'" +
                                                                                        ", '" + medico.email + "'" +
                                                                                         ", '" + medico.comision + "'" +
                                                                                       ",'" + medico.status + "')"), cnn);
                retorno = query.ExecuteNonQuery();
                cnn.Close();
            }
            return retorno;
        }
    }
}

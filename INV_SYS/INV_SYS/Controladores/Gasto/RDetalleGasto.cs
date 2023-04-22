using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;

namespace INV_SYS
{
    class RDetalleGasto
    {
        public static int registrarGasto(EDetalleGasto detalleGasto)
        {
            int retorno;

            using (SqlConnection cnn = RConexion.Conectando(Properties.Settings.Default.Conexion))
            {

                SqlCommand query = new SqlCommand(string.Format(@"INSERT INTO [dbo].[DETALLE_GASTO]
                                                                                   ([gasto],
                                                                                    [detalle],
                                                                                    [referenciaGasto],
                                                                                    [monto],
                                                                                    [usuario],
                                                                                    [fecha])
                                                                                     VALUES
                                                                                       ('" + detalleGasto.gasto + "'" +
                                                                                       ",'" + detalleGasto.detalle + "'" +
                                                                                       ",'" + detalleGasto.referenciaGasto + "'" +
                                                                                       ",'" + detalleGasto.monto + "'" +
                                                                                       ",'" + detalleGasto.usuario + "'" +
                                                                                       ",getDate())"), cnn);
                retorno = query.ExecuteNonQuery();
                cnn.Close();
            }

            return retorno;
        }
    }

}

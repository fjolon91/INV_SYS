using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;
using System.Drawing.Imaging;
using System.Windows.Forms;
using System.IO;

namespace INV_SYS
{
    public class RProducto
    {
        public static DataTable buscarProducto(string id)
        {
            using (SqlConnection cnn = RConexion.Conectando(Properties.Settings.Default.Conexion))
            {
                SqlCommand query = new SqlCommand(string.Format(@"SELECT *
                                                              FROM [dbo].[PRODUCTOS] WHERE  producto ='" + id + "'"), cnn);
                DataTable dt = new DataTable();
                dt.Load(query.ExecuteReader());
                return dt;
            }
        }

        public static int agregarProducto(EProducto produ)
        {

            int retorno;
            using (SqlConnection cnn = RConexion.Conectando(Properties.Settings.Default.Conexion))
            {
                retorno = 0;

                SqlCommand query = new SqlCommand(string.Format(@"INSERT INTO [dbo].[PRODUCTOS]
                                                                                   ([producto]
                                                                                   ,[descripcion]
                                                                                   ,[proveedor]
                                                                                   ,[serie],[fechaCreacion],[precioCosto],[precioVenta],[status],
                                                                                    [categoria],[fabricante],[lote],
                                                                                    [familia],[orden],[activarCobro])
                                                                                 VALUES
                                                                                       ('" + produ.producto + "'" +
                                                                                      ", '" + produ.descripcion + "'" +
                                                                                      ", '" + produ.proveedor + "'" +
                                                                                      ", '" + produ.serie + "'" +
                                                                                      ", '" + produ.fechaCreacion + "'" +
                                                                                      ", '" + produ.precioCosto + "'" +
                                                                                      ", '" + produ.precioVenta + "'" +
                                                                                      ", '" + produ.status + "'" +
                                                                                      ", '" + produ.categoria + "'" +
                                                                                      ", '" + produ.fabricante + "'" +
                                                                                      ", '" + produ.lote + "'" +
                                                                                      ", '" + produ.familia + "'" +
                                                                                      ", '" + produ.orden + "'" +
                                                                                      ",'" + produ.activarCobro+ "')"), cnn);
                retorno = query.ExecuteNonQuery();
                cnn.Close();
            }

            return retorno;
        }

        public static int actualizarProducto(EProducto eProducto)
        {
            int retorno;
            using (SqlConnection cnn = RConexion.Conectando(Properties.Settings.Default.Conexion))
            {
                SqlCommand query = new SqlCommand(string.Format(@" UPDATE PRODUCTOS
                                                                  SET precioVenta = '" + eProducto.precioVenta + "', descripcion ='"+eProducto.descripcion+"'  WHERE producto = '" + eProducto.producto + "'"), cnn);

                retorno = query.ExecuteNonQuery();
                cnn.Close();
            }

            return retorno;
        }
    }
}

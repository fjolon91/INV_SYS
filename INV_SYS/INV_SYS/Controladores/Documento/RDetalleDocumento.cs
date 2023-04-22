using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;


namespace INV_SYS
{
    public class RDetalleDocumento
    {
        public static int anularDetalleDocumento(string sucursal, string tipoDocumento, int NoDocumento, string serieDocumento)
        {
            int retorno;
            using (SqlConnection cnn = RConexion.Conectando(Properties.Settings.Default.Conexion))
            {
                SqlCommand query = new SqlCommand(string.Format(@"UPDATE _DETALLE_DOCUMENTO SET status=0 WHERE sucursal ='" + sucursal + "' and tipoDocumento = '" + tipoDocumento + "' and NoDocumento= '" + NoDocumento + "' and serieDocumento='" + serieDocumento + "'"), cnn);
                retorno = query.ExecuteNonQuery();
                cnn.Close();
            }

            return retorno;
        }


        public static int actualizarDetalleDocumento(EDetalleDocumento Detalle)
        {
            int retorno;
            using (SqlConnection cnn = RConexion.Conectando(Properties.Settings.Default.Conexion))
            {

                SqlCommand query = new SqlCommand(string.Format(@"UPDATE [dbo].[_DETALLE_DOCUMENTO]
                                                                               SET 
                                                                                  [producto] = '" + Detalle.producto + "'" +
                                                                                  " ,[descripcion] = '" + Detalle.descripcion + "'" +
                                                                                  " ,[precioVenta] = " + Detalle.precioVenta + "" +
                                                                                  " ,[cantidad] = " + Detalle.cantidad + "" +
                                                                                  " ,[status] = '" + Detalle.status + "'" +
                                                                                  " ,[usuario] = '" + Detalle.usuario + "'" +
                                                                                  " ,[fechaCreacion] =  '" + Detalle.fechaCreacion.ToString("yyyyMMdd HH:mm:ss") + "'" +
                                                                                  " ,[observacion] = '" + Detalle.observacion + "'" +
                                                                                  " ,[serie] = '" + Detalle.serie + "'" +
                                                                                  " ,[lote] = '" + Detalle.lote + "'" +
                                                                                  " ,[cargar] =  '" + Detalle.cargar + "'" +
                                                                                  " ,[bodega] =  '" + Detalle.bodega + "'" +
                                                                                  " ,[ubicacion] =  '" + Detalle.ubicacion + "'" +
                                                                                  " ,[cantidadRecetada] =  '" + Detalle.receta + "' WHERE tipoDocumento ='" + Detalle.tipoDocumento + "' and  NoDocumento = '" + Detalle.NoDocumento + "' and serieDocumento ='" + Detalle.serieDocumento + "' and sucursal = '" + Detalle.sucursal + "' and detalle='" + Detalle.detalle + "' "), cnn);
                retorno = query.ExecuteNonQuery();
                cnn.Close();
            }

            return retorno;
        }


        public static int crearDetalleDocumento(EDetalleDocumento Detalle)
        {
            int retorno;
            using (SqlConnection cnn = RConexion.Conectando(Properties.Settings.Default.Conexion))
            {

                SqlCommand query = new SqlCommand(string.Format(@"INSERT INTO [dbo].[DETALLE_DOCUMENTO]
                                                                                           ([tipoDocumento]
                                                                                           ,[sucursal]
                                                                                           ,[serieDocumento]
                                                                                           ,[NoDocumento]
                                                                                           ,[detalle]
                                                                                           ,[fechaCreacion]
                                                                                           ,[producto]
                                                                                           ,[descripcion]
                                                                                           ,[precioVenta]
                                                                                           ,[cantidad]
                                                                                           ,[status]
                                                                                           ,[observacion]
                                                                                           ,[serie],[lote],[cargar],[bodega],[ubicacion],[cantidadRecetada],[idPresentacion],[factor]
                                                                                           ,[usuario])
                                                                                     VALUES
                                                                                       ('" + Detalle.tipoDocumento + "'" +
                                                                                       " ,'" + Detalle.sucursal + "'" +
                                                                                       ",'" + Detalle.serieDocumento + "'" +
                                                                                       ", '" + Detalle.NoDocumento + "'" +
                                                                                       ", " + Detalle.detalle + "" +
                                                                                       ", getDate() " +
                                                                                       ",'" + Detalle.producto + "'" +
                                                                                       ",'" + Detalle.descripcion + "'" +
                                                                                       "," + Detalle.precioVenta + "" +
                                                                                       "," + Detalle.cantidad + "" +
                                                                                       ", '" + Detalle.status + "'" +
                                                                                       ", '" + Detalle.observacion + "'" +
                                                                                       ", '" + Detalle.serie + "'" +
                                                                                       ", '" + Detalle.lote + "'" +
                                                                                       ", '" + Detalle.cargar + "'" +
                                                                                       ", '" + Detalle.bodega + "'" +
                                                                                       ", '" + Detalle.ubicacion + "'" +
                                                                                       ", '" + Detalle.receta + "'" +
                                                                                       ", '" + Detalle.presentacion + "'" +
                                                                                       ", '" + Detalle.factor + "'" +
                                                                                       ",'" + Detalle.usuario + "')"), cnn);
                retorno = query.ExecuteNonQuery();

                if (retorno == 0)
                {
                    SqlCommand rollBack = new SqlCommand(string.Format(@"DELETE  FROM DOCUMENTO WHERE serieDocumento='" + Detalle.serieDocumento + "' and NoDocumento='" + Detalle.NoDocumento + "'"), cnn);
                    retorno = rollBack.ExecuteNonQuery();
                }

                cnn.Close();
            }

            return retorno;
        }

        public static DataTable existeLineaDetalle(string sucursal, string tipoDocumento, string serieDocumento, int documento, int detalle)
        {
            using (SqlConnection cnn = RConexion.Conectando(Properties.Settings.Default.Conexion))
            {
                SqlCommand query = new SqlCommand(string.Format(@"SELECT * FROM _DETALLE_DOCUMENTO WHERE sucursal = '" + sucursal + "' AND tipoDocumento = '" + tipoDocumento + "' AND serieDocumento ='" + serieDocumento + "' AND NoDocumento = '" + documento + "' AND detalle =" + detalle + ""), cnn);
                DataTable dt = new DataTable();
                dt.Load(query.ExecuteReader());
                return dt;
            }
        }


        public static DataTable existeDetalle(string sucursal, string tipoDocumento, string serieDocumento, string documento)
        {
            using (SqlConnection cnn = RConexion.Conectando(Properties.Settings.Default.Conexion))
            {
                SqlCommand query = new SqlCommand(string.Format(@"SELECT * FROM _DETALLE_DOCUMENTO WHERE sucursal = '" + sucursal + "' AND tipoDocumento = '" + tipoDocumento + "' AND serieDocumento ='" + serieDocumento + "' AND NoDocumento = '" + documento + "'"), cnn);
                DataTable dt = new DataTable();
                dt.Load(query.ExecuteReader());
                return dt;
            }
        }

        public static DataTable obtenerDetalleDocumento(string sucursal, string tipoDocumento, string serieDocumento, string documento)
        {
            using (SqlConnection cnn = RConexion.Conectando(Properties.Settings.Default.Conexion))
            {
                SqlCommand query = new SqlCommand(string.Format(@"SELECT DD.Cantidad, DD.Producto as Codigo, DD.descripcion as Producto, GM.descripcion as [Unidad Medida], DD.PrecioVenta as Precio,DD.fechaCreacion as [Fecha Registro] 
                FROM _DETALLE_DOCUMENTO DD LEFT JOIN _CAT_GRUPO_MEDIDAS GM ON GM.grupo = DD.idPresentacion AND  GM.producto = DD.producto 
                WHERE DD.sucursal = '" + sucursal + "' AND DD.tipoDocumento = '" + tipoDocumento + "' AND DD.serieDocumento ='" + serieDocumento + "' AND DD.NoDocumento = '" + documento + "'"), cnn);
                DataTable dt = new DataTable();
                dt.Load(query.ExecuteReader());
                return dt;
            }
        }

    }
}

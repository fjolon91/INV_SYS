using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;

namespace INV_SYS
{
    public class  RDocumento
    {
        public static DataTable ultimoDocumento(string tipo, string serie, string sucursal)
        {
            using (SqlConnection cnn = RConexion.Conectando(Properties.Settings.Default.Conexion))
            {

                SqlCommand query = new SqlCommand(string.Format(@"SELECT MAX(NoDocumento) as UltimoDocumento 
                                                                  FROM DOCUMENTO WHERE tipoDocumento='" + tipo + "' and serieDocumento = '" + serie + "' and sucursal ='" + sucursal + "'"), cnn);

                DataTable dt = new DataTable();
                dt.Load(query.ExecuteReader());
                return dt;
            }
        }


        public static DataTable DocumentoXReferencias(string tipo, string referencia, string especialidRef)
        {
            using (SqlConnection cnn = RConexion.Conectando(Properties.Settings.Default.Conexion))
            {

                SqlCommand query = new SqlCommand(string.Format(@"SELECT tipoDocumento,SerieDocumento,NoDocumento,Sucursal 
                                                                  FROM DOCUMENTO WHERE tipoDocumento='RC' AND tipoReferencia='" + tipo + "' and referencia = '" + referencia + "' and especialidadReferencia ='" + especialidRef + "'"), cnn);

                DataTable dt = new DataTable();
                dt.Load(query.ExecuteReader());
                return dt;
            }
        }


        public static DataTable verificarDocumento(string tipo, string serie, string sucursal, string documento)
        {
            using (SqlConnection cnn = RConexion.Conectando(Properties.Settings.Default.Conexion))
            {

                SqlCommand query = new SqlCommand(string.Format(@"SELECT *
                                                                  FROM DOCUMENTO WHERE tipoDocumento='" + tipo + "' and serieDocumento = '" + serie + "' and sucursal ='" + sucursal + "' and NoDocumento=" + documento + ""), cnn);

                DataTable dt = new DataTable();
                dt.Load(query.ExecuteReader());
                return dt;
            }
        }

        public static DataTable verificarInfoDocumento(string tipo, string serie, string sucursal, string documento)
        {
            using (SqlConnection cnn = RConexion.Conectando(Properties.Settings.Default.Conexion))
            {
                SqlCommand query = new SqlCommand(string.Format(@"SELECT D.fechaCreacion, D.sucursal,D.serieDocumento,D.tipoPago,D.formaPago, D.NoDocumento, D.cliente AS NIT, D.nombre AS Cliente, C.direccion,DD.producto AS Codigo, DD.descripcion,DD.cantidad, DD.precioVenta, P.categoria, DD.detalle
                                                                    FROM DOCUMENTO D 
                                                                    LEFT JOIN CLIENTE C ON D.cliente=C.cliente AND D.codigoAlterno = C.codigoAlterno
                                                                    INNER JOIN DETALLE_DOCUMENTO DD ON D.sucursal= DD.sucursal AND D.tipoDocumento=DD.tipoDocumento AND D.NoDocumento=DD.NoDocumento
                                                                    INNER JOIN PRODUCTOS P ON DD.producto = P.producto
                                                                    WHERE D.tipoDocumento='" + tipo + "' and D.serieDocumento = '" + serie + "' and D.sucursal ='" + sucursal + "' and D.NoDocumento=" + documento), cnn);
                DataTable dt = new DataTable();
                dt.Load(query.ExecuteReader());
                return dt;
            }
        }

        public static DataTable verificarDocumentoFEL(string tipo, string serie, string sucursal, string documento)
        {
            using (SqlConnection cnn = RConexion.Conectando(Properties.Settings.Default.Conexion))
            {

                SqlCommand query = new SqlCommand(string.Format(@"SELECT D.fechaCreacion, D.serieDocumento, D.NoDocumento, D.cliente AS NIT, D.nombre AS Cliente, C.direccion,DD.producto AS Codigo, DD.descripcion,DD.cantidad, DD.precioVenta, P.categoria
                                                                    FROM DOCUMENTO D 
                                                                    LEFT JOIN CLIENTE C ON D.cliente=C.cliente AND D.codigoAlterno = C.codigoAlterno
                                                                    INNER JOIN DETALLE_DOCUMENTO DD ON D.sucursal= DD.sucursal AND D.tipoDocumento=DD.tipoDocumento AND D.NoDocumento=DD.NoDocumento
                                                                    INNER JOIN PRODUCTOS P ON DD.producto = P.producto
                                                                    WHERE D.tipoDocumento='" + tipo + "' and D.serieDocumento = '" + serie + "' and D.sucursal ='" + sucursal + "' and D.NoDocumento=" + documento + " AND FEL=0"), cnn);

                DataTable dt = new DataTable();
                dt.Load(query.ExecuteReader());
                return dt;
            }
        }


        public static DataTable obtenerDocumentoFEL(string tipo, string serie, string sucursal, string documento)
        {
            using (SqlConnection cnn = RConexion.Conectando(Properties.Settings.Default.Conexion))
            {

                SqlCommand query = new SqlCommand(string.Format(@"SELECT D.fechaCreacion, D.serieDocumento, D.NoDocumento, D.cliente AS NIT, D.nombre AS Cliente, C.direccion,DD.producto AS Codigo, DD.descripcion,DD.cantidad, DD.precioVenta, P.categoria, D.FELDocumento, D.FELSerieDocumento, D.FELFecha, D.FELNoAutorizacion
                                                                    FROM _DOCUMENTO D 
                                                                    INNER JOIN CLIENTE C ON D.cliente=C.cliente AND D.codigoAlterno = C.codigoAlterno
                                                                    INNER JOIN DETALLE_DOCUMENTO DD ON D.sucursal= DD.sucursal AND D.tipoDocumento=DD.tipoDocumento AND D.NoDocumento=DD.NoDocumento
                                                                    INNER JOIN PRODUCTOS P ON DD.producto = P.producto
                                                                    WHERE D.tipoDocumento='" + tipo + "' and D.serieDocumento = '" + serie + "' and D.sucursal ='" + sucursal + "' and D.NoDocumento=" + documento + " AND FEL=1"), cnn);

                DataTable dt = new DataTable();
                dt.Load(query.ExecuteReader());
                return dt;
            }
        }


        public static int crearDocumento(EDocumento Doc)
        {
            int retorno;
            using (SqlConnection cnn = RConexion.Conectando(Properties.Settings.Default.Conexion))
            {
                DataTable DtConfig = new DataTable();
                DtConfig = RParametros.VerificarConfiguracion("FAC", "CorrelativoAutomatico");
                bool Config;
                Config = Convert.ToBoolean(DtConfig.Rows[0]["valorBool"].ToString());

                if (Config == false && Doc.tipoDocumento.ToString().CompareTo("F") == 0)
                {
                    Doc.NoDocumento = Doc.NoDocumento;
                }
                else
                {
                    int correlativo = 0;
                    RDocumento _UltimoDoc = new RDocumento();
                    DataTable dtNoDoc = RDocumento.ultimoDocumento(Doc.tipoDocumento, Doc.SerieDocumento, Doc.sucursal);
                    if (dtNoDoc is null || dtNoDoc.Rows.Count == 0)
                        correlativo = 0;
                    try
                    {
                        correlativo = Convert.ToInt32(dtNoDoc.Rows[0][0].ToString());
                        Doc.NoDocumento = correlativo + 1;
                    }
                    catch (Exception)
                    {
                        Doc.NoDocumento = 1;

                    }

                }
                SqlCommand query = new SqlCommand(string.Format(@"INSERT INTO [dbo].[DOCUMENTO]
                                                                                       ([tipoDocumento]
                                                                                       ,[sucursal]   
                                                                                       ,[serieDocumento]
                                                                                       ,[NoDocumento]
                                                                                       ,[fechaCreacion]
                                                                                       ,[cliente]
                                                                                       ,[nombre]
                                                                                       ,[status]
                                                                                       ,[tipoPago],[formaPago],[Proceso],[referencia],[tipoReferencia],[especialidadReferencia],[codigoAlterno]
                                                                                       ,[usuario])
                                                                                      VALUES
                                                                                       ('" + Doc.tipoDocumento + "'" +
                                                                                        ", '" + Doc.sucursal + "'" +
                                                                                       ",'" + Doc.SerieDocumento + "'" +
                                                                                       ", " + Doc.NoDocumento + "" +
                                                                                       ", getDate()" +
                                                                                       ",'" + Doc.cliente + "'" +
                                                                                       ",'" + Doc.Nombre + "'" +
                                                                                       ", '" + Doc.Status + "'" +
                                                                                       ", '" + Doc.tipoPago + "'" +
                                                                                       ", '" + Doc.formaPago + "'" +
                                                                                       ", '" + Doc.proceso + "'" +
                                                                                       ", '" + Doc.referencia + "'" +
                                                                                       ", '" + Doc.tipoReferencia + "'" +
                                                                                       ", '" + Doc.especialidad + "'" +
                                                                                       ", '" + Doc.codigoAlterno + "'" +
                                                                                       ",'" + Doc.usuario + "')"), cnn);
                retorno = query.ExecuteNonQuery();
                cnn.Close();
            }

            return retorno;
        }


        public static int actualizarDocumento(EDocumento Doc)
        {
            int retorno;
            using (SqlConnection cnn = RConexion.Conectando(Properties.Settings.Default.Conexion))
            {
                SqlCommand query = new SqlCommand(string.Format(@"UPDATE [DOCUMENTO] SET
                                                                                               [cliente]=  '" + Doc.cliente + "'" +
                                                                                              " ,[nombre]=   '" + Doc.Nombre + "'" +
                                                                                               ",[tipoPago]= '" + Doc.tipoPago + "'" +
                                                                                               ",[codigoAlterno]= '" + Doc.codigoAlterno + "'" +
                                                                                               ",[formaPago]= '" + Doc.formaPago + "'" +
                                                                                               " WHERE sucursal = '" + Doc.sucursal + "' and tipoDocumento ='" + Doc.tipoDocumento + "' and serieDocumento ='" + Doc.SerieDocumento + "' and NoDocumento=" + Doc.NoDocumento + " "), cnn);
                retorno = query.ExecuteNonQuery();
                cnn.Close();
            }

            return retorno;
        }

        public static int actualizarDocumentoFEL(string sucursal, string tipoDocumento, string NoDocumento, string serieDocumento, string FELDocumento, string FELSerieDocumento, string FELFecha, string FELAutorizacion, DateTime FELAutorizacionFecha, string FELObservacion, string FELQr)
        {
            int retorno;
            using (SqlConnection cnn = RConexion.Conectando(Properties.Settings.Default.Conexion))
            {
                DateTime fechaCertificacion;
                fechaCertificacion = Convert.ToDateTime(FELFecha);

                SqlCommand query = new SqlCommand(string.Format(@"UPDATE [DOCUMENTO] SET
                                                                                               [FELDocumento]=  '" + FELDocumento + "'" +
                                                                                              " ,[FELSerieDocumento]=   '" + FELSerieDocumento + "'" +
                                                                                              " ,[FELNoAutorizacion]=   '" + FELAutorizacion + "'" +
                                                                                               " ,[FELObservacion]=   '" + FELObservacion + "'" +
                                                                                               " ,[FELQr]=   '" + FELQr + "'" +
                                                                                               ",[FELFecha]= '" + fechaCertificacion.ToString("yyyyMMdd HH:mm:ss") + "'" +
                                                                                               ",[FELAutorizacionFecha]= '" + FELAutorizacionFecha.ToString("yyyyMMdd HH:mm:ss") + "'" +
                                                                                               " WHERE sucursal = '" + sucursal + "' and tipoDocumento ='" + tipoDocumento + "' and serieDocumento ='" + serieDocumento + "' and NoDocumento=" + NoDocumento + " "), cnn);
                retorno = query.ExecuteNonQuery();
                cnn.Close();
            }

            return retorno;
        }
        public static int marcarDocumentoFEL(string sucursal, string tipoDocumento, string NoDocumento, string serieDocumento)
        {
            int retorno;
            using (SqlConnection cnn = RConexion.Conectando(Properties.Settings.Default.Conexion))
            {

                SqlCommand query = new SqlCommand(string.Format(@"UPDATE [DOCUMENTO] SET
                                                                                               [FEL]=  1" +

                                                                                               " WHERE sucursal = '" + sucursal + "' and tipoDocumento ='" + tipoDocumento + "' and serieDocumento ='" + serieDocumento + "' and NoDocumento=" + NoDocumento + " "), cnn);
                retorno = query.ExecuteNonQuery();
                cnn.Close();
            }

            return retorno;
        }
        public static int AnularDocumento(string sucursal, string tipoDocumento, int NoDocumento, string serieDocumento)
        {
            int retorno;
            using (SqlConnection cnn = RConexion.Conectando(Properties.Settings.Default.Conexion))
            {
                SqlCommand query = new SqlCommand(string.Format(@"UPDATE DOCUMENTO SET status=0 WHERE sucursal ='" + sucursal + "' and tipoDocumento = '" + tipoDocumento + "' and NoDocumento= '" + NoDocumento + "' and serieDocumento='" + serieDocumento + "'"), cnn);
                retorno = query.ExecuteNonQuery();
                cnn.Close();
            }

            return retorno;
        }

        public static int AnularDocumentoFel(string sucursal, string tipoDocumento, int NoDocumento, string serieDocumento, DateTime fechaAnulacion)
        {
            int retorno;
            using (SqlConnection cnn = RConexion.Conectando(Properties.Settings.Default.Conexion))
            {
                SqlCommand query = new SqlCommand(string.Format(@"UPDATE DOCUMENTO SET status=0 , FELAnulacion=1 , FELObservacion ='Documento anulado con éxito', FELAnulacionFecha= '" + fechaAnulacion.ToString("yyyyMMdd HH:mm:ss") + "' WHERE sucursal ='" + sucursal + "' and tipoDocumento = '" + tipoDocumento + "' and NoDocumento= '" + NoDocumento + "' and serieDocumento='" + serieDocumento + "'"), cnn);
                retorno = query.ExecuteNonQuery();
                cnn.Close();
            }

            return retorno;
        }



        public static int FinalizarDocumento(string sucursal, string tipoDocumento, int NoDocumento, string serieDocumento)
        {
            int retorno;
            using (SqlConnection cnn = RConexion.Conectando(Properties.Settings.Default.Conexion))
            {
                SqlCommand query = new SqlCommand(string.Format(@"UPDATE DOCUMENTO SET proceso='F' WHERE sucursal ='" + sucursal + "' and tipoDocumento = '" + tipoDocumento + "' and NoDocumento= '" + NoDocumento + "' and serieDocumento='" + serieDocumento + "'"), cnn);
                retorno = query.ExecuteNonQuery();
                cnn.Close();
            }

            return retorno;
        }

        public static DataTable historialDocumentos(DateTime finicio, DateTime ffin, string tipoDocumento, int Num, string serie, string nombre, string sucursal, bool status)
        {
            string subQuerytipoDocumento;
            string subQueryNoDocumento;
            string subQuerySerie;
            string subQueryNombre;
            string subQuerySucursal;
            string subQueryFecha;
            string subQueryStatus;

            subQueryFecha = " and  D.fechaCreacion BETWEEN '" + finicio.ToString("yyyyMMdd 00:00:00") + "' AND '" + ffin.ToString("yyyyMMdd 23:59:59") + "'";

            if (nombre.CompareTo("") == 0)
            {
                subQueryNombre = " ";
            }
            else
            {
                subQueryNombre = " AND D.nombre like '%" + nombre + "%' ";
            }


            if (tipoDocumento.CompareTo("") == 0)
            {
                subQuerytipoDocumento = "  ";
            }
            else
            {
                subQuerytipoDocumento = "AND D.tipoDocumento = '" + tipoDocumento + "' ";
            }

            if (sucursal.CompareTo("") == 0)
            {
                subQuerySucursal = "  ";
            }
            else
            {
                subQuerySucursal = "AND D.sucursal = '" + sucursal + "' ";
            }
            if (Num == 0)
            {
                subQueryNoDocumento = " ";
            }
            else
            {
                subQueryNoDocumento = "AND D.NoDocumento = " + Num + " ";
                subQueryFecha = "";
            }
            if (serie.CompareTo("") == 0)
            {
                subQuerySerie = " ";
            }
            else
            {
                subQuerySerie = "AND D.SerieDocumento = '" + serie + "' ";
            }

            using (SqlConnection cnn = RConexion.Conectando(Properties.Settings.Default.Conexion))
            {

                SqlCommand query = new SqlCommand(string.Format(@"  SELECT S.sucursal as Sede, D.fechaCreacion as Fecha,  Td.tipoDocumento as Tipo,td.descripcion as Documento ,D.serieDocumento,D.NoDocumento as Numero,SD.descripcion Serie,D.cliente as NIT, D.nombre as Cliente, sum(DD.cantidad * DD.precioVenta) as Total, fp.descripcion as FormaPago, tp.descripcion as TipoPago,  D.status
                                                                         ,D.FElDocumento,D.FELSerieDocumento, D.FELNoAutorizacion, D.referencia,D.tipoReferencia
                                                                        FROM DOCUMENTO D
                                                                        INNER JOIN DETALLE_DOCUMENTO DD ON D.tipoDocumento = DD.tipoDocumento AND D.serieDocumento = DD.serieDocumento AND D.NoDocumento = DD.NoDocumento
                                                                        INNER JOIN TIPO_DOCUMENTO TD ON TD.tipoDocumento = D.tipoDocumento" +
                                                                        " INNER JOIN SUCURSAL S ON S.sucursal = D.sucursal" +
                                                                        " INNER JOIN TIPO_PAGO TP ON TP.tipoPago = D.tipoPago " +
                                                                        " INNER JOIN FORMA_PAGO FP  ON FP.formaPago = D.formaPago" +
                                                                        " INNER JOIN SERIE_DOCUMENTO SD ON SD.serieDocumento = D.serieDocumento" +
                                                                        " WHERE D.status='" + status + "'  " + subQueryFecha + "" +
                                                                        " " + subQuerytipoDocumento + " " + " " + subQueryNoDocumento + "" + " " + subQuerySerie + " " + " " + subQueryNombre + " " + subQuerySucursal + " " +
                                                                        " GROUP BY d.NoDocumento, s.sucursal,D.FechaCreacion,td.tipoDocumento, td.descripcion, D.serieDocumento,D.cliente,sd.descripcion, d.nombre, fp.descripcion, tp.descripcion, D.status,D.FElDocumento,D.FELSerieDocumento, D.FELNoAutorizacion, D.referencia,D.tipoReferencia  ORDER BY Numero asc"), cnn);
                DataTable dt = new DataTable();
                dt.Load(query.ExecuteReader());
                return dt;

            }
        }
    }
}

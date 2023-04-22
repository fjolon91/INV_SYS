using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;

namespace INV_SYS
{
    public class RDetalleAdmision
    {
        public static int crearDetalleAdmision(EDetalleAdmision Detalle)
        {
            int retorno;
            using (SqlConnection cnn = RConexion.Conectando(Properties.Settings.Default.Conexion))
            {
                SqlCommand query = new SqlCommand(string.Format(@"INSERT INTO [dbo].[DETALLE_ADMISION]
                                                                                       ([tipoAdmision]
                                                                                       ,[admision],[especialidad],[sucursal]
                                                                                       ,[detalle]
                                                                                       ,[servicio]
                                                                                       ,[descripcion]
                                                                                       ,[observaciones]
                                                                                       ,[precio]
                                                                                       ,[venta],[fecha]
                                                                                       ,[status])
                                                                                     VALUES
                                                                                       ('" + Detalle.tipoAdmision + "'" +
                                                                                       " ,'" + Detalle.admision + "'" +
                                                                                       " ,'" + Detalle.especialidad + "'" +
                                                                                        " ,'" + Detalle.sucursal + "'" +
                                                                                       ",'" + Detalle.detalle + "'" +
                                                                                       ", '" + Detalle.servicio + "'" +
                                                                                       ",'" + Detalle.descripcion + "'" +
                                                                                       ", '" + Detalle.observaciones + "'" +
                                                                                       ", '" + Detalle.precio + "'" +
                                                                                       ", '" + Detalle.venta + "'" +
                                                                                       ", getDate() " +
                                                                                       ",'" + Detalle.status + "')"), cnn);
                retorno = query.ExecuteNonQuery();
                cnn.Close();
            }

            return retorno;
        }


        public static int anularLineaDetalleAdmision(string tipo, string admision, int linea, string Idprueba, string status)
        {
            int retorno;
            using (SqlConnection cnn = RConexion.Conectando(Properties.Settings.Default.Conexion))
            {
                SqlCommand query = new SqlCommand(string.Format(@"UPDATE DETALLE_ADMISION SET status ='" + status + "' WHERE tipoAdmision ='" + tipo + "' AND admision ='" + admision + "' AND detalle =" + linea + " AND servicio ='" + Idprueba + "'"), cnn);
                retorno = query.ExecuteNonQuery();
                cnn.Close();
            }

            return retorno;
        }


        public static DataTable verificarLineaDetalleAdmision(string tipoAdmision, string admision, string especialidad, string servicio, int linea)
        {
            using (SqlConnection cnn = RConexion.Conectando(Properties.Settings.Default.Conexion))
            {
                SqlCommand query = new SqlCommand(string.Format(@"SELECT [tipoAdmision]
                                                                              ,[admision]
                                                                              ,[detalle],[especialidad]
                                                                              ,[servicio]
                                                                              ,[descripcion]
                                                                              ,[observaciones]
                                                                              ,[precio]
                                                                              ,[venta]
                                                                              ,[status]
                                                                          FROM [dbo].[DETALLE_ADMISION] WHERE tipoAdmision='" + tipoAdmision + "' and admision = '" + admision + "' and servicio= '" + servicio + "' and especialidad ='" + especialidad + "' and detalle=" + linea + " order by detalle asc "), cnn);
                DataTable dt = new DataTable();
                dt.Load(query.ExecuteReader());
                return dt;
            }
        }


        public static DataTable ultimaLineaDetalleAdmision(string tipoAdmision, string admision, string especialidad)
        {
            using (SqlConnection cnn = RConexion.Conectando(Properties.Settings.Default.Conexion))
            {
                SqlCommand query = new SqlCommand(string.Format(@"SELECT MAX(detalle)+1 as ultimaLinea                                       
                                                                          FROM [dbo].[DETALLE_ADMISION] WHERE tipoAdmision='" + tipoAdmision + "' and admision = '" + admision + "'  and especialidad ='" + especialidad + "' "), cnn);
                DataTable dt = new DataTable();
                dt.Load(query.ExecuteReader());
                return dt;
            }
        }


        public static DataTable listarLineasDetalleAdmision(string tipoAdmision, string admision, string especialidad, string servicio)
        {
            using (SqlConnection cnn = RConexion.Conectando(Properties.Settings.Default.Conexion))
            {
                SqlCommand query = new SqlCommand(string.Format(@" SELECT [tipoAdmision],[admision]
                                                                              ,[detalle],[especialidad]
                                                                              ,[servicio]
                                                                              ,P.[descripcion]
                                                                              ,[observaciones]
                                                                              ,[precio]
                                                                              ,[venta]
                                                                              ,D.[status], FP.familia
                                                                  FROM [dbo].[DETALLE_ADMISION] D
                                                                  INNER JOIN PRODUCTOS P ON P.producto = D.servicio
                                                                  INNER JOIN FAMILIA_PRODUCTOS FP ON FP.familia = P.familia
                                                                 WHERE tipoAdmision='" + tipoAdmision + "' and admision = '" + admision + "'  and especialidad ='" + especialidad + "' order by detalle asc"), cnn);
                DataTable dt = new DataTable();
                dt.Load(query.ExecuteReader());
                return dt;
            }
        }


        public static DataTable listarLineasDetalleAdmisionLab(string tipoAdmision, string admision, string especialidad, string familia)
        {
            using (SqlConnection cnn = RConexion.Conectando(Properties.Settings.Default.Conexion))
            {
                SqlCommand query = new SqlCommand(string.Format(@" SELECT [tipoAdmision],[admision]
                                                                              ,[detalle],[especialidad]
                                                                              ,[servicio]
                                                                              ,P.[descripcion]
                                                                              ,[observaciones]
                                                                              ,[precio]
                                                                              ,[venta]
                                                                              ,D.[status], FP.familia
                                                                  FROM [dbo].[DETALLE_ADMISION] D
                                                                  INNER JOIN PRODUCTOS P ON P.producto = D.servicio
                                                                  INNER JOIN FAMILIA_PRODUCTOS FP ON FP.familia = P.familia
                                                                 WHERE tipoAdmision='" + tipoAdmision + "' and admision = '" + admision + "'  and especialidad ='" + especialidad + "' and FP.familia ='" + familia + "' order by detalle asc"), cnn);
                DataTable dt = new DataTable();
                dt.Load(query.ExecuteReader());
                return dt;
            }
        }

    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;

namespace INV_SYS
{
    class RGasto
    {
        public static int registrarGasto(EGasto _gasto)
        {
            int retorno;
            //DataTable dtUlitmo = ultimoGasto();


            using (SqlConnection cnn = RConexion.Conectando(Properties.Settings.Default.Conexion))
            {

                SqlCommand query = new SqlCommand(string.Format(@"INSERT INTO [dbo].[GASTO]
                                                                                   (gasto,
                                                                                    [fecha],
                                                                                    [caja],
                                                                                    [concepto],[proveedor],
                                                                                    [vigente])
                                                                                     VALUES
                                                                                       ('" + _gasto.gasto + "'" +
                                                                                               " ,getDate()" +
                                                                                       ",'" + _gasto.caja + "'" +
                                                                                       ",'" + _gasto.concepto + "'" +
                                                                                       ",'" + _gasto.proveedor + "'" +
                                                                                       ",'" + _gasto.vigente + "')"), cnn);
                retorno = query.ExecuteNonQuery();
                cnn.Close();
            }

            return retorno;
        }
        public static DataTable ultimoGasto()
        {
            using (SqlConnection cnn = RConexion.Conectando(Properties.Settings.Default.Conexion))
            {
                SqlCommand query = new SqlCommand(string.Format(@"SELECT max(gasto) +1 AS gasto
                                                                      FROM [dbo].[GASTO]"), cnn);
                DataTable dt = new DataTable();
                dt.Load(query.ExecuteReader());
                return dt;
            }
        }

        public static DataTable listarGastos(DateTime fechaInicio, DateTime fechaFin, string caja)
        {
            using (SqlConnection cnn = RConexion.Conectando(Properties.Settings.Default.Conexion))
            {
                SqlCommand query = new SqlCommand(string.Format(@"SELECT G.gasto, G.fecha,C.descripcion Concepto,P.nombre AS Proveedor, DG.referenciaGasto, DG.monto, MC.caja FROM GASTO G
                                                                  INNER JOIN CONCEPTO_CAJA C ON G.concepto = C.concepto
                                                                  INNER JOIN PROVEEDOR P ON P.proveedor = G.proveedor
                                                                  INNER JOIN DETALLE_GASTO DG ON DG.gasto = G.gasto
                                                                  INNER JOIN MOVIMIENTO_CAJA MC ON MC.tipoMovimiento= 'G' AND MC.movimientoReferencia=G.gasto 
                                                                   WHERE  G.fecha BETWEEN '" + fechaInicio.ToString("yyyyMMdd 00:00:00") + "' AND '" + fechaFin.ToString("yyyyMMdd 23:59:59") + "' AND MC.caja ='"+caja+"'"), cnn);
                DataTable dt = new DataTable();
                dt.Load(query.ExecuteReader());
                return dt;
            }
        }

    }
}


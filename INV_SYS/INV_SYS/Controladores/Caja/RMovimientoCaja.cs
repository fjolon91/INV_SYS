using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
namespace INV_SYS
{
    public class RMovimientoCaja
    {
        public static int registrarMovimientoCaja(EMovimientoCaja mov)
        {
            int retorno;
            using (SqlConnection cnn = RConexion.Conectando(Properties.Settings.Default.Conexion))
            {

                SqlCommand query = new SqlCommand(string.Format(@"INSERT INTO [dbo].[MOVIMIENTO_CAJA]
                                                                                       ([caja]
                                                                                       ,[concepto]
                                                                                       ,[operacion]
                                                                                       ,[montoEfectivo]
                                                                                       ,[montoTarjeta]
                                                                                       ,[montoCheque]
                                                                                       ,[referencia]
                                                                                       ,[usuario]
                                                                                       ,[fechaRegistro]
                                                                                       ,[vigente]
                                                                                       ,[tipoMovimiento]
                                                                                       ,[movimientoReferencia]
                                                                                       ,[moneda05]
                                                                                       ,[moneda010]
                                                                                       ,[moneda025]
                                                                                       ,[moneda050]
                                                                                       ,[moneda1]
                                                                                       ,[billete1]
                                                                                       ,[billete5]
                                                                                       ,[billete10]
                                                                                       ,[billete20]
                                                                                       ,[billete50]
                                                                                       ,[billete100]
                                                                                       ,[billete200]
                                                                                       ,[observaciones])
                                                                                     VALUES
                                                                                       ('" + mov.caja + "'" +
                                                                                       ",'" + mov.concepto + "'" +
                                                                                       ", '" + mov.operacion + "'" +
                                                                                       ",'" + mov.montoEfectivo + "'" +
                                                                                       ",'" + mov.montoTarjeta + "'" +
                                                                                       ", '" + mov.montoCheque + "'" +
                                                                                         ", '" + mov.referencia + "'" +
                                                                                       ", '" + mov.usuario + "'" +
                                                                                       ", '" + mov.fechaRegistro.ToString("yyyyMMdd HH:mm:ss") + "'" +
                                                                                       ",'" + true + "'" +
                                                                                       ", '" + mov.tipoMovimiento + "'" +
                                                                                       ", '" + mov.movimientoReferencia + "'" +
                                                                                       ", '" + mov.moneda05 + "'" +
                                                                                       ", '" + mov.moneda010 + "'" +
                                                                                       ", '" + mov.moneda025 + "'" +
                                                                                       ", '" + mov.moneda01 + "'" +
                                                                                       ", '" + mov.billete1 + "'" +
                                                                                       ", '" + mov.billete5 + "'" +
                                                                                       ", '" + mov.billete10 + "'" +
                                                                                       ", '" + mov.billete20 + "'" +
                                                                                       ", '" + mov.billete50 + "'" +
                                                                                       ", '" + mov.billete100 + "'" +
                                                                                       ", '" + mov.billete200 + "'" +
                                                                                       ", '" + mov.movimientoReferencia + "'" +
                                                                                       ",'" + mov.observaciones + "')"), cnn);
                retorno = query.ExecuteNonQuery();
                cnn.Close();
            }

            return retorno;
        }
    }
}

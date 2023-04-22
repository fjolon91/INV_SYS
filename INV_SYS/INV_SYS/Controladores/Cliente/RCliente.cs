using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;

namespace INV_SYS
{
    public class RCliente
    {
        public static DataTable verificarCliente(string id)
        {
            using (SqlConnection cnn = RConexion.Conectando(Properties.Settings.Default.Conexion))
            {
                SqlCommand query = new SqlCommand(string.Format(@"SELECT [cliente]
                                                                      ,[nombre]
                                                                      ,[direccion]
                                                                      ,[telefono]
                                                                      ,[Email]
                                                                      ,[identificacion]
                                                                      ,[Movil]
                                                                      ,[Observacion],[codigoAlterno],[tipoCliente]
                                                                  FROM [dbo].[CLIENTE]
                                                                            WHERE  (cliente ='" + id + "' or codigoAlterno='" + id + "')"), cnn);
                DataTable dt = new DataTable();
                dt.Load(query.ExecuteReader());
                return dt;
            }
        }
        public static DataTable listarClientes()
        {
            using (SqlConnection cnn = RConexion.Conectando(Properties.Settings.Default.Conexion))
            {
                SqlCommand query = new SqlCommand(string.Format(@"SELECT [Cliente] as NIT,
                                                                        [codigoAlterno]
                                                                       ,[nombre] as Cliente,(cliente+'-'+nombre )as Descripcion,
                                                                       TC.descripcion as TipoCliente, TC.descuento as [Descuento%]
                                                                      ,[Direccion]
                                                                      ,[Telefono]
                                                                      ,[Email]
                                                                      ,[Identificacion]
                                                                      ,[Movil]
                                                                      ,[Observacion] as Observaciones
                                                                  FROM [dbo].[CLIENTE] C
                                                                  INNER JOIN TIPO_CLIENTE TC ON C.tipoCliente = TC.tipoCliente order by nombre"), cnn);
                DataTable dt = new DataTable();
                dt.Load(query.ExecuteReader());
                return dt;
            }
        }
        public static DataTable buscarCliente(string idName)
        {
            using (SqlConnection cnn = RConexion.Conectando(Properties.Settings.Default.Conexion))
            {
                SqlCommand query = new SqlCommand(string.Format(@"SELECT [Cliente] as NIT,
                                                                        [codigoAlterno]
                                                                       ,[nombre] as Cliente,TC.descripcion as TipoCliente, TC.descuento as [Descuento%]
                                                                      ,[Direccion]
                                                                      ,[Telefono]
                                                                      ,[Email]
                                                                      ,[Identificacion]
                                                                      ,[Movil]
                                                                      ,[Observacion] as Observaciones
                                                                  FROM [dbo].[CLIENTE] C
                                                                  INNER JOIN TIPO_CLIENTE TC ON C.tipoCliente = TC.tipoCliente
                                                                            WHERE  (cliente ='" + idName + "' or codigoAlterno='" + idName + "' or nombre like '%" + idName + "%')"), cnn);
                DataTable dt = new DataTable();
                dt.Load(query.ExecuteReader());
                return dt;
            }
        }

        public static DataTable verificarClienteTipo(string id, string idAlterno, string tipoCliente)
        {
            using (SqlConnection cnn = RConexion.Conectando(Properties.Settings.Default.Conexion))
            {
                SqlCommand query = new SqlCommand(string.Format(@"SELECT [cliente]
                                                                      ,[nombre]
                                                                      ,[direccion]
                                                                      ,[telefono]
                                                                      ,[Email]
                                                                      ,[identificacion]
                                                                      ,[Movil]
                                                                      ,[Observacion],[codigoAlterno],[tipoCliente]
                                                                  FROM [dbo].[CLIENTE]
                                                                            WHERE ( cliente ='" + id + "' AND codigoAlterno='" + idAlterno + "')"), cnn);
                DataTable dt = new DataTable();
                dt.Load(query.ExecuteReader());
                return dt;
            }
        }

        public static int crearCliente(ECliente cliente)
        {
            int retorno;
            if (String.IsNullOrEmpty(cliente.tipoCliente))
                cliente.tipoCliente = "DEFAULT";
            using (SqlConnection cnn = RConexion.Conectando(Properties.Settings.Default.Conexion))
            {
                SqlCommand query = new SqlCommand(string.Format(@"INSERT INTO [dbo].[CLIENTE]
                                                                                       ([cliente]
                                                                                       ,[nombre]
                                                                                       ,[direccion]
                                                                                       ,[telefono]
                                                                                       ,[Email]
                                                                                       ,[identificacion]
                                                                                       ,[Movil],[codigoAlterno],[tipoCliente]
                                                                                       ,[Observacion])
                                                                                 VALUES
                                                                                       ('" + cliente.cliente + "'" +
                                                                                       ",'" + cliente.nombre + "'" +
                                                                                       ",'" + cliente.direccion + "'" +
                                                                                       ", '" + cliente.telefono + "'" +
                                                                                        ", '" + cliente.email + "'" +
                                                                                         ", '" + cliente.identificacion + "'" +
                                                                                       ", '" + cliente.Movil + "'" +
                                                                                        ", '" + cliente.codigoAlterno + "'" +
                                                                                         ", '" + cliente.tipoCliente + "'" +
                                                                                       ",'" + cliente.observacion + "')"), cnn);
                retorno = query.ExecuteNonQuery();
                cnn.Close();
            }

            return retorno;
        }

        public static int actualizarCliente(ECliente cliente)
        {
            int retorno;
            using (SqlConnection cnn = RConexion.Conectando(Properties.Settings.Default.Conexion))
            {
                if (String.IsNullOrEmpty(cliente.tipoCliente))
                    cliente.tipoCliente = "Default";
                SqlCommand query = new SqlCommand(string.Format(@"UPDATE [dbo].[CLIENTE]
                                                                   SET [nombre] = '" + cliente.nombre + "'" +
                                                                      " ,[direccion] = '" + cliente.direccion + "'" +
                                                                      " ,[telefono] = '" + cliente.telefono + "'" +
                                                                      " ,[email] = '" + cliente.email + "'" +
                                                                      " ,[identificacion] =' " + cliente.identificacion + "'" +
                                                                      " ,[movil] = '" + cliente.Movil + "'" +
                                                                      " ,[tipoCliente] = '" + cliente.tipoCliente + "'" +
                                                                      " ,[Cliente] = '" + cliente.cliente + "'" +
                                                                      " ,[observacion] = '" + cliente.observacion + "'" +
                                                                 "WHERE cliente = '" + cliente.cliente + "'  AND CodigoAlterno='" + cliente.codigoAlterno + "'"), cnn);
                retorno = query.ExecuteNonQuery();
                cnn.Close();
            }

            return retorno;
        }
    }
}

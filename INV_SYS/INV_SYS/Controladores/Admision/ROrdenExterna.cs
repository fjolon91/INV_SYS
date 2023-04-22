using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;


namespace INV_SYS
{
    public class ROrdenExterna
    {
        public static DataTable obtenerDatos()
        {
            using (SqlConnection cnn = RConexionExterna.Conectando(Properties.Settings.Default.conexionExterna))
            {

                SqlCommand query = new SqlCommand(string.Format(@"SELECT distinct fechaRecepcion, TipoCliente, Sucursal,TipoOrden, orden,Nombre, Nombre,PrimerApellido,SegundoApellido,Sexo,FechaNacimiento,Cliente,TipoCliente,Paciente,Medico,NombreMedico
                                                                    FROM DATA "), cnn);

                DataTable dt = new DataTable();
                dt.Load(query.ExecuteReader());
                return dt;
            }
        }

        public static DataTable obtenerDetalle(string tipoOrden, string orden, string sucursal)
        {
            using (SqlConnection cnn = RConexionExterna.Conectando(Properties.Settings.Default.conexionExterna))
            {

                SqlCommand query = new SqlCommand(string.Format(@"SELECT LineaOrden,CodigoExamen,Examen,Precio,Descuento 
                                                                    FROM DATA WHERE TipoOrden ='"+tipoOrden+"' AND Orden ='"+orden+"' AND Sucursal='"+sucursal+"' "), cnn);

                DataTable dt = new DataTable();
                dt.Load(query.ExecuteReader());
                return dt;
            }
        }

        public static DataTable eliminarOrden(string tipoOrden, string orden, string sucursal)
        {
            using (SqlConnection cnn = RConexionExterna.Conectando(Properties.Settings.Default.conexionExterna))
            {

                SqlCommand query = new SqlCommand(string.Format(@"DELETE FROM DATA WHERE TipoOrden ='" + tipoOrden + "' AND Orden ='" + orden + "' AND Sucursal='" + sucursal + "'"), cnn);

                DataTable dt = new DataTable();
                dt.Load(query.ExecuteReader());
                return dt;
            }
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;

namespace INV_SYS
{
    public class RAdmision
    {
        string fmt;
        string correlativo;
        public static DataTable ultimaAdmision(string tipo, string especialidad, DateTime fecha)
        {
            fecha = DateTime.Now;
            using (SqlConnection cnn = RConexion.Conectando(Properties.Settings.Default.Conexion))
            {

                SqlCommand query = new SqlCommand(string.Format(@"SELECT count(admision) as UltimaAdmision 
                                                                  FROM ADMISION WHERE fechaRecepcion between '" + fecha.ToString("yyyyMMdd 00:00:00") + "' and '" + fecha.ToString("yyyyMMdd 23:59:59") + "' and tipoAdmision='" + tipo + "' and especialidad = '" + especialidad + "' "), cnn);

                DataTable dt = new DataTable();
                dt.Load(query.ExecuteReader());
                return dt;
            }
        }

        public static DataTable obtenerAdmision(string admision, string tipoAdmision, string idEspecialidad, string sucursal)
        {
            
            using (SqlConnection cnn = RConexion.Conectando(Properties.Settings.Default.Conexion))
            {

                SqlCommand query = new SqlCommand(string.Format(@"SELECT A.Admision,A.tipoAdmision, A.FechaRecepcion,E.especialidad as IdEspecialidad ,E.descripcion as Especialidad,CTP.tipoPaciente as IdTipoPaciente, CTP.descripcion as TipoPaciente,A.paciente, A.nombre,A.fechaNacimiento,G.descripcion as Sexo,A.Medico
                                                                                   ,a.status, A.nombreMedico,DA.cantidad, DA.servicio, DA.descripcion as Estudio, DA.Venta,(DA.cantidad*DA.Venta)AS subTotal, A.sucursal  FROM ADMISION A
                                                                                    INNER JOIN DETALLE_ADMISION DA ON A.tipoAdmision = DA.tipoAdmision AND A.admision = DA.admision AND A.especialidad= DA.especialidad AND A.sucursal= DA.sucursal
                                                                                    INNER JOIN TIPO_ADMISION TA ON TA.tipoAdmision = A.tipoAdmision 
                                                                                    INNER JOIN GENERO G ON G.sexo = a.sexo
                                                                                    INNER JOIN ESPECIALIDAD E ON E.especialidad = A.especialidad
                                                                                    INNER JOIN TIPO_PACIENTE CTP ON CTP.tipoPaciente = A.tipoPaciente                                                                                    
                                                                                    WHERE A.status<>'F' AND A.admision='"+admision+"' AND A.tipoAdmision='"+tipoAdmision+"' AND A.Especialidad='"+idEspecialidad+"' AND A.sucursal='"+sucursal+"'"), cnn);
                DataTable dt = new DataTable();
                dt.Load(query.ExecuteReader());
                return dt;
            }
        }

        public static DataTable laboratorioXFacturar()
        {

            using (SqlConnection cnn = RConexion.Conectando(Properties.Settings.Default.Conexion))
            {

                SqlCommand query = new SqlCommand(string.Format(@"SELECT DISTINCT(A.Admision),A.tipoAdmision, A.FechaRecepcion,E.especialidad as IdEspecialidad ,E.descripcion as Especialidad,CTP.tipoPaciente as IdTipoPaciente, CTP.descripcion as TipoPaciente,A.paciente, A.nombre,A.fechaNacimiento,G.descripcion as Sexo,A.Medico
                                                                                   ,a.status, SUM(DA.cantidad*DA.venta)AS Total, A.Sucursal FROM ADMISION A
                                                                                    INNER JOIN DETALLE_ADMISION DA ON A.tipoAdmision = DA.tipoAdmision AND A.admision = DA.admision AND A.especialidad= DA.especialidad AND A.sucursal= DA.sucursal
                                                                                    INNER JOIN TIPO_ADMISION TA ON TA.tipoAdmision = A.tipoAdmision 
                                                                                    INNER JOIN GENERO G ON G.sexo = a.sexo
                                                                                    INNER JOIN ESPECIALIDAD E ON E.especialidad = A.especialidad
                                                                                    INNER JOIN TIPO_PACIENTE CTP ON CTP.tipoPaciente = A.tipoPaciente                                                                                    
                                                                                    WHERE A.Especialidad ='LABO' AND A.status<>'F' GROUP BY A.Admision,A.tipoAdmision, A.FechaRecepcion,E.especialidad,A.sucursal, E.descripcion ,CTP.tipoPaciente, CTP.descripcion,A.paciente, A.nombre,A.fechaNacimiento,G.descripcion ,A.Medico, A.status"), cnn);

                DataTable dt = new DataTable();
                dt.Load(query.ExecuteReader());
                return dt;
            }
        }




        public static DataTable listaLaboratoriosPx(string Px)
        {


            using (SqlConnection cnn = RConexion.Conectando(Properties.Settings.Default.Conexion))
            {

                SqlCommand query = new SqlCommand(string.Format(@"SELECT DISTINCT(A.Admision),A.tipoAdmision, A.FechaRecepcion,E.especialidad as IdEspecialidad ,E.descripcion as Especialidad,CTP.tipoPaciente as IdTipoPaciente, CTP.descripcion as TipoPaciente,A.paciente, A.nombre,A.fechaNacimiento,G.descripcion as Sexo,A.Medico, A.sucursal
                                                                                    FROM ADMISION A
                                                                                    INNER JOIN DETALLE_ADMISION DA ON A.tipoAdmision = DA.tipoAdmision AND A.admision = DA.admision AND A.especialidad= DA.especialidad AND A.sucursal= DA.sucursal
                                                                                    INNER JOIN TIPO_ADMISION TA ON TA.tipoAdmision = A.tipoAdmision 
                                                                                    INNER JOIN GENERO G ON G.sexo = a.sexo
                                                                                    INNER JOIN ESPECIALIDAD E ON E.especialidad = A.especialidad
                                                                                    INNER JOIN TIPO_PACIENTE CTP ON CTP.tipoPaciente = A.tipoPaciente
                                                                                    INNER JOIN PRODUCTOS P ON P.producto = DA.servicio
                                                                                    INNER JOIN CAT_DETALLE_SERVICIO  S ON S.servicio = P.producto
                                                                                    INNER JOIN RESULTADOS R ON R.tipoAdmision = DA.tipoAdmision AND R.admision =DA.admision AND R.lineaAdmision = DA.detalle AND R.lineaServicio = S.linea
                                                                                    WHERE A.Especialidad ='LABO' and A.paciente='" + Px + "' order by fechaRecepcion desc "), cnn);

                DataTable dt = new DataTable();
                dt.Load(query.ExecuteReader());
                return dt;
            }
        }

        public static DataTable listaFacturasPendientesInstitucion(string cliente, string fechaInicio, string fechaFin)
        {


            using (SqlConnection cnn = RConexion.Conectando(Properties.Settings.Default.Conexion))
            {

                SqlCommand query = new SqlCommand(string.Format(@"SELECT S1.tipoAdmision, S1.NIT, S1.NOMBRECLIENTE, S1.direccion, S1.EMAIL,
	                                                                    S1.descripcion AS PRODUCTO,
	                                                                    SUM(S1.cantidad) AS CANTIDAD,
	                                                                    SUM(S1.ST) AS SUBTOTAL
                                                                    FROM (
	                                                                    SELECT A.tipoAdmision, C.CLIENTE AS NIT, ISNULL(C.nombre,'') AS NOMBRECLIENTE, C.direccion, C.Email,
		                                                                    DA.descripcion, DA.cantidad, DA.precio,
		                                                                    (DA.cantidad * DA.precio) AS ST
	                                                                    FROM ADMISION A
		                                                                    INNER JOIN DETALLE_ADMISION DA ON A.tipoAdmision = DA.tipoAdmision AND A.admision = DA.admision
		                                                                    LEFT JOIN CLIENTE C ON A.tipoCliente = C.tipoCliente AND A.cliente = C.cliente
	                                                                    WHERE A.tipoAdmision ='1'
		                                                                    AND A.fechaRecepcion BETWEEN '" + fechaInicio +"' AND '" + fechaFin + "' " +		                                                                    --AND A.status = 1
		                                                                    "AND A.cliente = '" + cliente + "' " +
                                                                            "AND A.Especialidad ='LABO' " +
                                                                            "--AND D_A.status = 1 " +
                                                                            ") AS S1 " +
                                                                    "GROUP BY S1.tipoAdmision, S1.NIT, S1.NOMBRECLIENTE, S1.direccion, S1.EMAIL, " +
                                                                        "S1.descripcion "), cnn);

                DataTable dt = new DataTable();
                dt.Load(query.ExecuteReader());
                return dt;
            }
        }


        public static DataTable verificarAdmision(string No, string tipo,string especialidad, string sucursal)
        {
            using (SqlConnection cnn = RConexion.Conectando(Properties.Settings.Default.Conexion))
            {

                SqlCommand query = new SqlCommand(string.Format(@"SELECT *, dbo.calcularEdad(fechaNacimiento,fechaRecepcion) as Edad
                                                                  FROM ADMISION WHERE admision = '" + No + "' and tipoAdmision='" + tipo + "' and especialidad='"+especialidad+"' and sucursal ='"+sucursal+"'"), cnn);

                DataTable dt = new DataTable();
                dt.Load(query.ExecuteReader());
                return dt;
            }
        }

        public static DataTable eliminarAdmision(string No, string tipo, string especialidad, string sucursal)
        {
            using (SqlConnection cnn = RConexion.Conectando(Properties.Settings.Default.Conexion))
            {

                SqlCommand query = new SqlCommand(string.Format(@"DELETE FROM ADMISION WHERE admision = '" + No + "' and tipoAdmision='" + tipo + "' and especialidad='" + especialidad + "' and sucursal ='" + sucursal + "'"), cnn);

                DataTable dt = new DataTable();
                dt.Load(query.ExecuteReader());
                return dt;
            }
        }

        public static DataTable historicoPX(string IdPX, string tipoPx)
        {
            using (SqlConnection cnn = RConexion.Conectando(Properties.Settings.Default.Conexion))
            {

                SqlCommand query = new SqlCommand(string.Format(@"SELECT CONVERT(VARCHAR(10), FechaRecepcion, 103) as Fecha,A.Admision,A.observaciones AS Motivo, A.observacion2 as Diagnostico,DA.Descripcion,R.nombreServicio as Parametro, R.Resultado
                                                                FROM ADMISION A 
                                                                INNER JOIN  DETALLE_ADMISION DA ON A.tipoAdmision = DA.tipoAdmision AND A.admision = DA.admision AND A.especialidad = DA.especialidad AND A.sucursal= DA.sucursal
                                                                INNER JOIN RESULTADOS R ON r.tipoAdmision= DA.tipoAdmision AND R.admision = DA.admision AND R.especialidad = DA.especialidad
                                                                AND R.lineaAdmision = DA.detalle WHERE A.PACIENTE = '" + IdPX + "'  and A.tipoAdmision ='ADMI' AND R.validado=1  AND A.STATUS NOT IN('X') ORDER BY A.fechaRecepcion desc"), cnn);

                DataTable dt = new DataTable();
                dt.Load(query.ExecuteReader());
                return dt;
            }
        }


        public static int cambiarStatusAdmision(string tipoAdmision, string Admision, string especialidad, string status, bool altaMedica, string sucursal)
        {
            int retorno;
            using (SqlConnection cnn = RConexion.Conectando(Properties.Settings.Default.Conexion))
            {

                SqlCommand query = new SqlCommand(string.Format(@"UPDATE [dbo].[ADMISION] SET STATUS='" + status + "' , altaMedica='" + altaMedica + "' ,fechaFinProceso=getDate() WHERE tipoAdmision='" + tipoAdmision + "' and Admision='" + Admision + "' and especialidad= '" + especialidad + "' and sucursal='"+sucursal+"'"), cnn);
                retorno = query.ExecuteNonQuery();
                cnn.Close();
            }

            return retorno;
        }


        public static int modificarAdmision(EAdmision adm)
        {
            int retorno;
            using (SqlConnection cnn = RConexion.Conectando(Properties.Settings.Default.Conexion))
            {
                SqlCommand query = new SqlCommand(string.Format(@"UPDATE [dbo].[ADMISION] SET paciente='" + adm.paciente + "' , nombre ='" + adm.nombre + "', sexo='" + adm.sexo + "', fechaNacimiento='" + adm.fechaNacimiento.ToString("yyyyMMdd HH:mm:ss") + "', tipoPaciente='" + adm.tipoPaciente + "', medico='" + adm.medico + "', nombreMedico='" + adm.nombreMedico + "', observaciones='" + adm.observaciones + "', observacion2='" + adm.observacion2 + "' , stat = '" + adm.stat + "', razon = '" + adm.razon + "', hospitalizacion = '" + adm.hospitalizacion + "', medicoRefiere = '" + adm.medicoRefiere + "', nombreMedicoRefiere = '" + adm.nombreMedicoRefiere + "', procedencia ='" + adm.procedencia + "', habitacion='" + adm.habitacion + "', cama='" + adm.cama + "' WHERE tipoAdmision='" + adm.tipoAdmision + "' and Admision='" + adm.Admision + "' and especialidad= '" + adm.especialidad + "' and sucursal='"+adm.sucursal+"'"), cnn);
                retorno = query.ExecuteNonQuery();
                cnn.Close();
            }

            return retorno;
        }



        public void ultimAdmision(string especialidad, string tipo)
        {


            try
            {

                int No;
                DataTable dt = new DataTable();
                dt = RAdmision.ultimaAdmision(tipo, especialidad, DateTime.Now);
                string NumDoc = dt.Rows[0]["ultimaAdmision"].ToString();
                if (NumDoc.CompareTo("") == 0)
                {
                    No = 1;
                }
                else
                {

                    No = Convert.ToInt32(NumDoc) + 1;
                }

                if (No < 10)
                {
                    fmt = new String('0', 2) + No;
                    No = Convert.ToInt32(fmt);
                }
                if (No > 9)
                {
                    fmt = new String('0', 1) + No;
                    No = Convert.ToInt32(fmt);
                }
                if (No > 99)
                {
                    fmt = Convert.ToString(No);
                    No = Convert.ToInt32(fmt);

                }


                DateTime moment = DateTime.Now;
                int year = moment.Year;
                int month = moment.Month;
                int day = moment.Day;
                Convert.ToString(No);
                Convert.ToString(day);
                Convert.ToString(month);
                String var = Convert.ToString(year.ToString());
                int tam_var = var.Length;
                String Var_Sub = var.Substring((tam_var - 2), 2);

                string newNo = "";
                newNo = day.ToString() + "" + month + "" + Var_Sub + "" + fmt + "";
                No = Convert.ToInt32(newNo);
                //lblNoAdmin.Text = No.ToString();

            }
            catch (Exception)
            { }

        }

        public static string obtenerCorrelavio(int No)
        {
            string fmt;
            string correlativo;
            Convert.ToString(No);
            string Num = "";
            if (No < 10)
            {
                fmt = new String('0', 2) + No;
                Num = fmt;
            }
            if (No > 9)
            {
                fmt = new String('0', 1) + No;
                Num = fmt;
            }
            if (No > 99)
            {
                fmt = Convert.ToString(No);
                Num = fmt;

            }
            correlativo = Num.ToString();
            return correlativo;
        }

        public static int crearAdmision(EAdmision admi)
        {

            int retorno;
            /*int No;
            string correlativoDay = "";
            string correlativoMonth = "";
            DataTable dt = new DataTable();
            dt = RAdmision.ultimaAdmision(admi.tipoAdmision, admi.especialidad, DateTime.Now);
            string NumDoc = dt.Rows[0]["ultimaAdmision"].ToString();
            if (NumDoc.CompareTo("") == 0)
            {
                No = 1;
            }
            else
            {

                No = Convert.ToInt32(NumDoc) + 1;
            }
            string fmt2 = "";
            fmt2 = obtenerCorrelavio(No);

            DateTime moment = DateTime.Now;
            int year = moment.Year;
            int month = moment.Month;
            int day = moment.Day;

            if (day < 10)
            {
                string fmt = "";
                fmt = new String('0', 1) + day;
                correlativoDay = fmt;
            }
            else
            {
                correlativoDay = day.ToString();
            }

            if (month < 10)
            {
                string fmtM = "";
                fmtM = new String('0', 1) + month;
                correlativoMonth = fmtM;
            }
            else
            {
                correlativoMonth = month.ToString();
            }
            Convert.ToString(No);
            Convert.ToString(day);
            Convert.ToString(month);
            String var = Convert.ToString(year.ToString());
            int tam_var = var.Length;
            String Var_Sub = var.Substring((tam_var - 2), 2);

            string newNo = "";
            newNo = correlativoDay + "" + correlativoMonth + "" + Var_Sub + "" + fmt2 + "";

            //lblNoAdmin.Text = No.ToString();
            admi.Admision = newNo;*/

            using (SqlConnection cnn = RConexion.Conectando(Properties.Settings.Default.Conexion))
            {
                SqlCommand query = new SqlCommand(string.Format(@"INSERT INTO [dbo].[ADMISION]
                                                                                       ([tipoAdmision]
                                                                                       ,[admision]
                                                                                       ,[especialidad]
                                                                                       ,[sucursal]
                                                                                       ,[paciente]
                                                                                       ,[nombre]
                                                                                       ,[sexo]
                                                                                       ,[fechaNacimiento]
                                                                                       ,[fechaRecepcion]
                                                                                       ,[tipoPaciente]
                                                                                       ,[medico]
                                                                                       ,[nombreMedico]
                                                                                       ,[status]
                                                                                        ,[observaciones],[stat],[razon],
                                                                                        [hospitalizacion],[medicoRefiere],
                                                                                        [nombreMedicoRefiere],[procedencia],
                                                                                        [habitacion],[cama],[tipoCliente],[cliente]
                                                                                       ,[usuario])
                                                                                      VALUES
                                                                                       ('" + admi.tipoAdmision + "'" +
                                                                                        ", '" + admi.Admision + "'" +
                                                                                       ", '" + admi.especialidad + "'" +
                                                                                       ", '" + admi.sucursal + "'" +
                                                                                       ",'" + admi.paciente + "'" +
                                                                                       ",'" + admi.nombre + "'" +
                                                                                       ", '" + admi.sexo + "'" +
                                                                                       ", '" + admi.fechaNacimiento.ToString("yyyyMMdd HH:mm:ss") + "'" +
                                                                                       ", '" + admi.fechaRecepcion.ToString("yyyyMMdd HH:mm:ss") + "'" +
                                                                                       ",'" + admi.tipoPaciente + "'" +
                                                                                       ",'" + admi.medico + "'" +
                                                                                       ", '" + admi.nombreMedico + "'" +
                                                                                       ", '" + admi.status + "'" +
                                                                                        ", '" + admi.observaciones + "'" +
                                                                                        ", '" + admi.stat + "'" +
                                                                                        ", '" + admi.razon + "'" +
                                                                                        ", '" + admi.hospitalizacion + "'" +
                                                                                        ", '" + admi.medicoRefiere + "'" +
                                                                                        ", '" + admi.nombreMedicoRefiere + "'" +
                                                                                        ", '" + admi.procedencia + "'" +
                                                                                        ", '" + admi.habitacion + "'" +
                                                                                        ", '" + admi.cama + "'" +
                                                                                         ", '" + admi.tipoCliente + "'" +
                                                                                          ", '" + admi.cliente + "'" +
                                                                                       ",'" + admi.usuario + "')"), cnn);
                retorno = query.ExecuteNonQuery();
                cnn.Close();
            }

            return retorno;
        }



        public static DataTable historicoAdmision(DateTime finicio, DateTime ffin, string tipoAdmision, string especialidad, string status, string Paciente)
        {
            string subQueryFecha = "";
            string subQueryPaciente = "";
            subQueryFecha = " A.fechaRecepcion BETWEEN '" + finicio.ToString("yyyyMMdd HH:mm:ss") + "' AND '" + ffin.ToString("yyyyMMdd HH:mm:ss") + "'";


            string subQueryStatus = "";
            if (status.CompareTo("") == 0)
            {
                subQueryStatus = " AND A.status NOT IN ('A','F','RV','H')";
            }
            else
            {
                switch (status)
                {
                    case "EN CONSULTA":
                        status = "C";
                        break;
                    case "EN ESPERA":
                        status = "E";
                        break;
                    case "CONSULTA FINALIZADA":
                        status = "RV";
                        break;
                    case "FACTURADO":
                        status = "F";
                        break;
                    case "ATENDIDO":
                        status = "A";
                        break;
                    case "CANCELADA":
                        status = "X";
                        break;
                    case "HOSPITALIZADO":
                        status = "H";
                        break;

                }


                subQueryStatus = " AND A.status = '" + status + "'";
                if (status == "TODOS")
                    subQueryStatus = " AND A.status like '%%'";
            }

            if (especialidad.CompareTo("C1") == 0 || especialidad.CompareTo("C2") == 0)
                especialidad = "C1','C2";


            if (Paciente.CompareTo("") != 0)
            {
                subQueryFecha = "";
                subQueryPaciente = " A.nombre like '" + Paciente + "%'";
                subQueryStatus = " AND A.STATUS LIKE '%%' ";
            }
            if (status.CompareTo("H") == 0)
            {
                subQueryFecha = "";
                subQueryStatus = "";
                subQueryStatus = " A.status='H' ";
            }


            using (SqlConnection cnn = RConexion.Conectando(Properties.Settings.Default.Conexion))
            {

                SqlCommand query = new SqlCommand(string.Format(@" SELECT A.TipoAdmision, A.Admision,A.fechaRecepcion, A.Paciente, A.tipoPaciente as IdTipoPaciente ,P.descripcion AS TipoPaciente ,A.Nombre, A.Sexo,
                                                                        A.medico, A.NombreMedico, A.status, a.usuario,PRO.procedencia as idProcedencia,PRO.descripcion as Procedencia,a.especialidad as IdEspecialidad, e.Descripcion as Especialidad,CASE A.status 
                                                                                      WHEN 'E' THEN 'EN ESPERA'
																					  WHEN 'C' THEN 'EN CONSULTA'
                                                                                      WHEN 'RV' THEN 'CONSULTA FINALIZADA'
																					  WHEN 'F' THEN 'FACTURADO'
                                                                                      WHEN 'X' THEN 'CANCELADA'
                                                                                      WHEN 'H' THEN 'HOPITALIZACION'
																					  WHEN 'A' THEN 'ATENDIDO' END AS Estado, a.Stat as Emergencia, M.descripcion as Motivo " +
                                                                        " FROM ADMISION A " +
                                                                        " INNER JOIN TIPO_ADMISION TA ON TA.tipoAdmision = A.tipoAdmision " +
                                                                        " INNER JOIN ESPECIALIDAD E ON E.especialidad = A.especialidad " +
                                                                        " INNER JOIN TIPO_PACIENTE P ON P.tipoPaciente =A.tipoPaciente " +
                                                                        " INNER JOIN MOTIVO_CONSULTA M ON M.motivo = A.razon " +
                                                                        " LEFT JOIN PROCEDENCIA PRO ON PRO.procedencia = A.procedencia " +
                                                                        " WHERE   " + subQueryFecha + " " + subQueryPaciente + "" + subQueryStatus + "" +
                                                                        " AND A.TipoAdmision ='" + tipoAdmision + "' and A.especialidad IN('" + especialidad + "')" +
                                                                        " ORDER BY  a.stat desc, a.Admision asc"), cnn);
                DataTable dt = new DataTable();
                dt.Load(query.ExecuteReader());
                return dt;
            }
        }

    }
}

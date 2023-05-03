using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Net;
using System.Data;
using System.Data.SqlClient;

namespace INV_SYS
{

    public class clsXMLHTTP
    {
        private WebRequest urlWebRequest;
        private string strResponseText;
        private string strUrl;
        private string strMethod;
        private string usuarioFirma;
        private string llaveFirma;
        private string usuarioApi;
        private string llaveApi;
        private string identificador;
        public virtual void setRequestHeader(string bstrHeader, string bstrValue)
        {
            DataTable dtUFirma = RParametros.VerificarConfiguracion("FEL", "UsuarioFirmaFEL");
            usuarioFirma = dtUFirma.Rows[0]["valorString"].ToString();

            DataTable dtllFirma = RParametros.VerificarConfiguracion("FEL", "LLaveFirmaFEL");
            llaveFirma = dtllFirma.Rows[0]["valorString"].ToString();

            DataTable dtUsuarioApi = RParametros.VerificarConfiguracion("FEL", "UsuarioApiFEL");
            usuarioApi = dtUsuarioApi.Rows[0]["valorString"].ToString();

            DataTable dtLLaveApi = RParametros.VerificarConfiguracion("FEL", "LLaveApiFEL");
            llaveApi = dtLLaveApi.Rows[0]["valorString"].ToString();

            DataTable dtIdentificador = RParametros.VerificarConfiguracion("FEL", "IdentificadorFEL");
            identificador = dtIdentificador.Rows[0]["valorString"].ToString();

            switch (bstrHeader)
            {
                case "Content-Type":
                    {
                        urlWebRequest.ContentType = bstrValue;
                        urlWebRequest.Headers.Add("UsuarioFirma", usuarioFirma);
                        urlWebRequest.Headers.Add("LlaveFirma", llaveFirma);
                        urlWebRequest.Headers.Add("UsuarioApi",usuarioApi);
                        urlWebRequest.Headers.Add("LlaveApi", llaveApi);
                        urlWebRequest.Headers.Add("identificador", identificador);

                        break;
                    }

                default:
                    {
                        urlWebRequest.Headers[bstrHeader] = bstrValue;
                        break;
                    }
            }
        }
        public virtual void open(string bstrMethod, string bstrUrl, object varAsync = null, object bstrUser = null, object bstrPassword = null)
        {
            strUrl = bstrUrl;
            strMethod = bstrMethod;
            urlWebRequest = WebRequest.Create(strUrl);
            urlWebRequest.Method = strMethod;

            if ((strMethod == "POST"))
                setRequestHeader("Content-Type", "text/xml; charset=utf-8");
        }

        public virtual void Send(object objBody = null)
        {
            Stream strmReceiveStream;
            Encoding encode;
            StreamReader sr;
            urlWebRequest.Method = "POST";

            // Crear array de bytes de la cadena  
            byte[] byteData;
            byteData = UTF8Encoding.UTF8.GetBytes(objBody.ToString());

            // Setear el largo del stream  
            urlWebRequest.ContentLength = byteData.Length;

            // Escribir datos
            Stream postStream = null;
            postStream = urlWebRequest.GetRequestStream();
            postStream.Write(byteData, 0, byteData.Length);

            // Enviar los datos (si buffer está activado) y recuperar la respuesta
            WebResponse Response;
            Response = urlWebRequest.GetResponse();

            strmReceiveStream = Response.GetResponseStream();
            encode = Encoding.GetEncoding("utf-8");
            sr = new StreamReader(strmReceiveStream, encode);

            char[] read = new char[257];
            int count = sr.Read(read, 0, 256);
            while (count > 0)
            {
                string str = new string(read, 0, count);
                strResponseText = strResponseText + str;
                count = sr.Read(read, 0, 256);
            }
        }
        public virtual string ResponseText
        {
            get
            {
                return strResponseText;
            }
        }
    }
}

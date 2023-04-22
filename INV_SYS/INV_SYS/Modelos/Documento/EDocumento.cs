using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace INV_SYS
{
    public class EDocumento
    {
        public string tipoDocumento { get; set; }
        public string SerieDocumento { get; set; }
        public int NoDocumento { get; set; }
        public DateTime fechaCreacion { get; set; }
        public string cliente { get; set; }
        public string Nombre { get; set; }
        public bool Status { get; set; }
        public string usuario { get; set; }
        public string sucursal { get; set; }
        public string tipoPago { get; set; }
        public string observaciones { get; set; }
        public string formaPago { get; set; }
        public string proceso { get; set; }
        public string referencia { get; set; }
        public string tipoReferencia { get; set; }
        public string especialidad { get; set; }
        public string codigoAlterno { get; set; }
        public string FELDocumento { get; set; }
        public string FELSerieDocumento {get; set;}
        public DateTime FELFecha { get; set; }
        public string FELNoAutorizacion { get; set; }
        public string FELObservacion { get; set; }
        public string FELQR { get; set; }
        public bool FEL { get; set; }
        public DateTime FELAutorizacionFecha { get; set; }
        public DateTime FELAnulacionFecha { get; set; }

        public bool FELAnulacion { get; set; }

    }
}

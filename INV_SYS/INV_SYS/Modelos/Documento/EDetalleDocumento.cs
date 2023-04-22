using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace INV_SYS
{
    public class EDetalleDocumento
    {
        public string tipoDocumento { get; set; }
        public string serieDocumento { get; set; }
        public int NoDocumento { get; set; }
        public int detalle { get; set; }
        public string producto { get; set; }
        public string descripcion { get; set; }
        public double precioVenta { get; set; }
        public double cantidad { get; set; }
        public double receta { get; set; }
        public bool status { get; set; }
        public string usuario { get; set; }
        public string sucursal { get; set; }
        public DateTime fechaCreacion { get; set; }
        public string observacion { get; set; }
        public string serie { get; set; }
        public string lote { get; set; }
        public bool cargar { get; set; }
        public string ubicacion { get; set; }
        public string bodega { get; set; }
        public int presentacion { get; set; }
        public double factor { get; set; }
    }
}

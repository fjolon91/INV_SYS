using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace INV_SYS
{
    public class EDetalleAdmision
    {
        public string tipoAdmision { get; set; }
        public string especialidad { get; set; }
        public string admision { get; set; }
        public string sucursal { get; set; }
        public int detalle { get; set; }
        public string servicio { get; set; }
        public string descripcion { get; set; }
        public string observaciones { get; set; }
        public string precio { get; set; }
        public string venta { get; set; }
        public string status { get; set; }
        public bool cargar { get; set; }
    }
}

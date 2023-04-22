using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace INV_SYS
{
    public class EProducto
    {
        public string producto { get; set; }
        public string descripcion { get; set; }
        public string talla { get; set; }
        public string color { get; set; }
        public string fabricante { get; set; }
        public bool serie { get; set; }
        public bool lote { get; set; }
        public double precioCosto { get; set; }
        public double precioVenta { get; set; }
        public string observacion { get; set; }
        public string proveedor { get; set; }
        public bool status { get; set; }
        public string categoria { get; set; }
        public DateTime fechaCreacion { get; set; }
        public byte[] imagen { get; set; }
        public int cantidad { get; set; }
        public int orden { get; set; }
        public string unidadMedida { get; set; }
        public string nombreGenerico { get; set; }
        public string familia { get; set; }

        public bool activarCobro { get; set; }
    }
}

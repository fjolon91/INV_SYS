using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace INV_SYS
{
    public class EDetalleGasto
    {
        public int gasto { get; set; }
        public int detalle { get; set; }
        public string referenciaGasto { get; set; }
        public string usuario { get; set; }
        public double monto { get; set; }
        public DateTime fecha { get; set; }
    }
}

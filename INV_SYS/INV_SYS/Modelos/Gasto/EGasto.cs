using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace INV_SYS
{ 
    public class EGasto
    {
        public int gasto { get; set; }
        public DateTime fecha { get; set; }
        public string concepto { get; set; }
        public string caja { get; set; }
        public bool vigente { get; set; }

        public string proveedor { get; set; }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace INV_SYS
{
    public class ETipoPago
    {
        public string tipoPago { get; set; }
        public string descripcion { get; set; }
        public int orden { get; set; }
        public bool status { get; set; }
    }
}

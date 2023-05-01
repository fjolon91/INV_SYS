using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace INV_SYS
{
    public class ETipoCliente
    {
        public string tipoCliente { get; set; }
        public string descripcion { get; set; }
        public int orden { get; set; }
        public decimal descuento { get; set; }
        public bool status { get; set; }
    }
}

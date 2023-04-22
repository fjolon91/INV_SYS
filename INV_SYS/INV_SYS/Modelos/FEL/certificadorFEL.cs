using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace INV_SYS
{
    public class certificadorFEL
    {
        public string resultado { get; set; }
        public string fecha { get; set; }
        public string origen { get; set; }
        public string descripcion { get; set; }
        public bool alertas_infile { get; set; }
        //public string descripcion_alertas_infile { get; set; }
        public bool alertas_sat { get; set; }
        public int cantidad_errores { get; set; }
        //public string descripcion_errores { get; set; }
        public string uuid { get; set; }
        public string serie { get; set; }
        public string numero { get; set; }
        public string xml_certificado { get; set; }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace INV_SYS
{
    public class Paciente
    {
        public string tipoPaciente { get; set; }
        public string paciente { get; set; }
        public string nombre { get; set; }
        public DateTime fechaNacimiento { get; set; }
        public string sexo { get; set; }
        public string observaciones { get; set; }
        public string direccion { get; set; }
        public string identificacion { get; set; }
        public byte[] foto { get; set; }
        public string ocupacion { get; set; }
        public string estadoCivil { get; set; }
        public int lugarProcedencia { get; set; }
        public string telefono { get; set; }
        public string email { get; set; }
    }
}

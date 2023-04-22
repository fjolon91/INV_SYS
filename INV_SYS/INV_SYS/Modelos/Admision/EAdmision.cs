using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace INV_SYS
{
    public class EAdmision
    {
        public string tipoAdmision { get; set; }
        public string Admision { get; set; }
        public string sucursal { get; set; }
        public string paciente { get; set; }
        public string nombre { get; set; }
        public string sexo { get; set; }
        public DateTime fechaNacimiento { get; set; }
        public DateTime fechaRecepcion { get; set; }
        public string tipoPaciente { get; set; }
        public string medico { get; set; }
        public string nombreMedico { get; set; }
        public string especialidad { get; set; }
        public string status { get; set; }
        public string usuario { get; set; }
        public string observaciones { get; set; }
        public string observacion2 { get; set; }
        public bool stat { get; set; }
        public int razon { get; set; }
        public bool hospitalizacion { get; set; }
        public string medicoRefiere { get; set; }
        public string nombreMedicoRefiere { get; set; }
        public string procedencia { get; set; }
        public int habitacion { get; set; }
        public int cama { get; set; }

        public string tipoCliente { get; set; }

        public string cliente { get; set; }
    }
}

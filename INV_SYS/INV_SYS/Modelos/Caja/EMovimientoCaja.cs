using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace INV_SYS
{
    public class EMovimientoCaja
    {
        public string caja { get; set; }
        public string concepto { get; set; }
        public int operacion { get; set; }
        public double montoEfectivo { get; set; }
        public double montoCheque { get; set; }
        public double montoTarjeta { get; set; }
        public string referencia { get; set; }
        public string usuario { get; set; }
        public string observaciones { get; set; }
        public DateTime fechaRegistro { get; set; }
        public bool vigente { get; set; }
        public string tipoMovimiento { get; set; }
        public string movimientoReferencia { get; set; }
        public int moneda05 { get; set; }
        public int moneda010 { get; set; }
        public int moneda025 { get; set; }
        public int moneda050 { get; set; }
        public int moneda01 { get; set; }
        public int billete1 { get; set; }
        public int billete5 { get; set; }
        public int billete10 { get; set; }
        public int billete20 { get; set; }
        public int billete50 { get; set; }
        public int billete100 { get; set; }
        public int billete200 { get; set; }
    }
}

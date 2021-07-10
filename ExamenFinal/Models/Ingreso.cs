using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ExamenFinal.Models
{
    public class Ingreso
    {
        public int Id_Ingreso { get; set; }
        public int Id_Cuenta { get; set; }
        public DateTime Fecha_Hora { get; set; }
        public decimal Monto { get; set; }
        public string Descripcion { get; set; }
    }
}

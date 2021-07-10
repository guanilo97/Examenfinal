using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ExamenFinal.Models
{
    public class Transferencia
    {
        public int Id_Transferencia { get; set; }
        public int Id_Cuenta_Origen { get; set; }
        public int Id_Cuenta_Destino { get; set; }
        public string Descripcion { get; set; }
        public decimal Monto { get; set; }
        public int Id_Usuario { get; set; }
        public DateTime Fecha_Hora { get; set; }
    }
}

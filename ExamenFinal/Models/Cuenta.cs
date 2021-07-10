using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ExamenFinal.Models
{
    public class Cuenta
    {
        public int Id_Cuenta { get; set; }
        public string Nombre { get; set; }
        public int Categoria { get; set; }
        public decimal Saldo_Inicial { get; set; }
        public int Id_Usuario { get; set; }
        public Decimal Limite_Credito { get; set; }
    }
}

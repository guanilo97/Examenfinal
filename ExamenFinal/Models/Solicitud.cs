using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ExamenFinal.Models
{
    public class Solicitud
    {
        public int Id_Solicitud { get; set; }
        public int Id_Usuario_Origen { get; set; }
        public int Id_Usuario_Destino { get; set; }
        public bool Estado_Aceptacion { get; set; }
    }
}

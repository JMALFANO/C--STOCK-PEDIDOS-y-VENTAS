using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Entidades
{
    public class EscalonPrecios
    {
        public int? Id { get; set; }
        public int NumeroEscalon { get; set; }
        public int Iva { get; set; }
        public int Pico { get; set; }
        public int Gramaje { get; set; }
        public double Precio {get; set; }
    }
}

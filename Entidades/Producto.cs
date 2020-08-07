using Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Entidades
{
    public class Producto : IEntity
    {
        public int? Id { get; set; }
        public int Tipo { get; set; } //1: Envase 2:Tapa 3:Otro
        public string Nombre { get; set; }
        public int CantidadBolson { get; set; } //CANTIDAD POR BOLSON
        public int Gramaje { get; set; }
        public int Pico { get; set; } //1: ROSCA 2:ACEITE 3:BOCA ANCHA
        public int Stock { get; set; }
        public int Pedidas { get; set; }
        public int Disponibles { get; set; }


       

    }
}

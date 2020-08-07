using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Interfaces;

namespace Entidades
{
    public class Cliente : IEntity
    {
        public int? Id { get; set; }
        public string Nombre { get; set; }
        public string Telefono { get; set; }
        public string Direccion { get; set; }
        public string Mail { get; set; }
        public string Cuit { get; set; }
        public string Horarios { get; set; }
        public string Comentarios { get; set; }
        public int NumeroEscalon { get; set; }
        public double Saldo { get; set; }

     


    }
}

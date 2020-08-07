using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Interfaces;

namespace Entidades
{
    public class Venta : IEntity
    {
        public int? Id { get; set; }
        public int IdCliente { get; set; }
        public int IdVendedor { get; set; } 
        public DateTime Fecha { get; set; }
        public int TipoComprobante{ get; set; } 
        public int CodigoFactura { get; set; }
        public int Iva { get; set; }
        public double Total { get; set; } 

    }
}

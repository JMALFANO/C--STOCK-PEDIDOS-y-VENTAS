using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Entidades
{
    public class Pedido
    {
        public int? Id { get; set; }
        public int IdCliente { get; set; }
        public int IdVendedor { get; set; }
        public DateTime Fecha { get; set; }
        public int IdProducto { get; set; }
        public string Detalle { get; set; }
        public int Cantidad { get; set; }
    }
}

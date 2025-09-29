using System;
using System.Collections.Generic;

namespace CapaEntities
{
    public class Ventas
    {
        public string FormaPago { get; set; }
        public int IdUsuario { get; set; }
        public DateTime Fecha { get; set; }
        public decimal total { get; set; }
        public int cliente { get; set; }
        public string comprobante  { get; set; }
        public List<(string Idproducto,string Producto, int Cantidad, int Descuento, decimal precio)> Detalle { get; set; }

    }
}

using System;
using System.Collections.Generic;

namespace CapaEntities
{
    public class OrdendeCompra
    {
        public int IdUsuario { get; set; }
        public int IdSolicitud { get; set; }
        public DateTime Fecha { get; set; }
        public List<(string IdProducto,string Producto,int IdDetalleCoti,Decimal Precio)> Detalle { get; set; }
    }
}

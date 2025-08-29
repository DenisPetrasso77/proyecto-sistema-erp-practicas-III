using System;
using System.Collections.Generic;

namespace CapaEntities
{
    public class Devoluciones
    {
        public List<(int IdRecepcion, string IdProducto, int Cantidad, string Estado, int IdUsuario)> Detalle { get; set; }

    }
}

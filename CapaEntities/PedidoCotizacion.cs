using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaEntities
{
    public class PedidoCotizacion
    {
        public int IdPR { get; set; }
        public int IdProducto { get; set; }
        public string Producto { get; set; }
        public int IdProveedor { get; set; }
        public DateTime FechaLimite { get; set; }
        public string cantidad { get; set; }

    }
}

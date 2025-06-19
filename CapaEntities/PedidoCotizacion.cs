using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaEntities
{
    public class PedidoCotizacion
    {
        public int IdPR { get; set; }
        public string IdProducto { get; set; }
        public int IdProveedor { get; set; }
        public DateTime FechaLimite { get; set; }
        public string Estado { get; set; }
        public string FechaAlta { get; set; }
        public int IdUsuarioAlta { get; set; }
        public DateTime FechaUltModificacion { get; set; }
        public int IdUsuarioUltModificacion { get; set; }
        public string CantidadPedida { get; set; }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaEntities
{
    public class DetalleSoliCotizaciones
    {
        public string IdProducto { get; set; }
        public int IdProveedor { get; set; }
        public DateTime FechaLimite { get; set; }
        public string Cantidad { get; set; }
    }
}

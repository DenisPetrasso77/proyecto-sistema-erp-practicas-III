using System;

namespace CapaEntities
{
    public class DetalleSoliCotizaciones
    {
        public string IdProducto { get; set; }
        public string Producto { get; set; }
        public int IdProveedor { get; set; }
        public DateTime FechaLimite { get; set; }
        public string Cantidad { get; set; }
    }
}

using System;
using System.Collections.Generic;

namespace CapaEntities
{
    public class ProductoNuevo
    {
        public string CodigoProducto { get; set; }
        public int Nombre { get; set; }
        public int IdCategoria { get; set; }
        public int IdMarca { get; set; }
        public int IdMedida { get; set; }
        public int? IdUnidadVenta { get; set; }
        public int StockMin { get; set; }
        public int StockMax{ get; set; }
        public int StockActual { get; set; }
        public string Estado { get; set; }
        public DateTime FechaAlta { get; set; }
        public int IdUsuarioAlta { get; set; }
        public decimal PrecioCompra { get; set; }
        public decimal PrecioVenta { get; set; }
        public List<(int CantidadMinima, int Porcentaje)> Descuentos { get; set; }
        public int DVH { get; set; }

    }
}

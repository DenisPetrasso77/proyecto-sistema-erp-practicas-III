using System;
using System.Collections.Generic;

namespace CapaEntities
{
    public class OrdenesPago
    {
        public List<(int IdRecepcion, string RazonSocial, string Cuit, string NroFactura, string NroNC,string FormaPago,DateTime FechaAlta, int IdUsuarioAlta,string Estado)> Detalle { get; set; }

    }
}

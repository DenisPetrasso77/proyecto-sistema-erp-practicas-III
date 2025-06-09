using System;

namespace CapaEntities
{
    public class Proveedor
    {
            public string NombreComercial { get; set; }
            public string RazonSocial { get; set; }
            public string TipoIdentificacion { get; set; }
            public string NumeroDeIdentificacion { get; set; }
            public string Correo { get; set; }
            public int? CodigoArea { get; set; }
            public int? Telefono { get; set; }
            public string DireccionCalle { get; set; }
            public int? DireccionAltura { get; set; }
            public int? DireccionProvincia { get; set; }
            public int? DireccionLocalidad { get; set; }
            public int? DireccionCodigoPostal { get; set; }
            public string Observaciones { get; set; }
            public int IdUsuarioAlta { get; set; }
            public int? IdUsuarioUltModificacion { get; set; }
        }
}

using System;
using System.Collections.Generic;

namespace CapaEntities
{
    public class InformesRecepcion
    {
        public int IdOrdenCompra { get; set; }
        public int IdUsuario { get; set; }
        public string Estado { get; set; }
        public int puestonumero { get; set; }
        public int numeroremito { get; set; }
        public string cuit { get; set; }
        public string razonsocial { get; set; }
        public List<(string Idproducto, string Producto, int CantidadPedida, int CantidadRecibida,int Diferencia,string IdProveedor,int Motivo)> Detalle { get; set; }
    }
}


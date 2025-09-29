namespace CapaEntities
{
    public class Cliente
    {
        public int IdCliente { get; set; }
        public string Nombre { get; set; }
        public string Apellido { get; set; }
        public string Dni { get; set; }
        public string Correo { get; set; }
        public int? CodigoArea { get; set; }
        public int? Telefono { get; set; }
        public string DireccionCalle { get; set; }
        public int? DireccionAltura { get; set; }
        public int? DireccionProvincia { get; set; }
        public int? DireccionLocalidad { get; set; }
        public int? DireccionCodigoPostal { get; set; }
        public string Observaciones { get; set; }
        public int IdUsuario { get; set; }
    }
}

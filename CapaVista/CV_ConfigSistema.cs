using System;
using System.Drawing;
using System.Globalization;
using System.Threading;
using System.Windows.Forms;

namespace CapaVista
{
    public enum TipoTema
    {
        Estandar,
        Oscuro,
        ContrasteAlto
    }

    public enum TamañoFuente
    {
        Chico,
        Mediano,
        Grande
    }

    public static class CV_ConfigSistema
    {
        // ---------------- Variables Colores y Fuentes ----------------
        public static Color ColorPrincipal { get; set; } = Color.WhiteSmoke;
        public static Color ColorTexto { get; set; } = Color.Black;
        public static TipoTema TemaActual { get; set; } = TipoTema.Estandar;
        public static TamañoFuente TamañoFuenteActual { get; set; } = TamañoFuente.Mediano;
        public static string IdiomaActual { get; set; } = "es"; // "es" o "en"

        public static Font GetFuente()
        {
            float tamaño = 12f;
            switch (TamañoFuenteActual)
            {
                case TamañoFuente.Chico: tamaño = 8f; break;
                case TamañoFuente.Mediano: tamaño = 12f; break;
                case TamañoFuente.Grande: tamaño = 14f; break;
            }
            return new Font("Segoe UI", tamaño, FontStyle.Bold);
        }

    }
}

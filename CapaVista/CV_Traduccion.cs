using Newtonsoft.Json;
using System.Collections.Generic;
using System.IO;
using System.Windows.Forms;

public static class Traductor
{
    private static Dictionary<string, Dictionary<string, string>> diccionario;
    public static string Idioma { get; set; } = "es";

    public static void CargarJson(string ruta)
    {
        var json = File.ReadAllText(ruta);
        diccionario = JsonConvert.DeserializeObject<Dictionary<string, Dictionary<string, string>>>(json);
    }

    public static void TraducirFormulario(Control form)
    {
        foreach (Control ctrl in form.Controls)
        {
            TraducirControl(ctrl);
        }
    }

    private static void TraducirControl(Control ctrl)
    {
        if (diccionario != null &&
            diccionario.ContainsKey(Idioma) &&
            diccionario[Idioma].ContainsKey(ctrl.Name))
        {
            ctrl.Text = diccionario[Idioma][ctrl.Name];
        }

        foreach (Control child in ctrl.Controls)
        {
            TraducirControl(child);
        }
    }
    public static string TraducirTexto(string clave)
    {
        if (diccionario != null && diccionario.ContainsKey(Idioma) && diccionario[Idioma].ContainsKey(clave))
        {
            return diccionario[Idioma][clave];
        }
        return clave; 
    }
}

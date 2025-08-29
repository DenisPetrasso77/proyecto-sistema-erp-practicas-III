using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;

namespace ProyectoPracticas
{
    public static class UI_Utilidad
    {
        // 🔹 Botón redondeado con estilo principal
        public static void EstiloBotonPrimario(Button boton)
        {
            boton.BackColor = Color.FromArgb(33, 150, 243); // Azul Material
            boton.ForeColor = Color.White;
            boton.FlatStyle = FlatStyle.Flat;
            boton.FlatAppearance.BorderSize = 0;
            boton.Font = new Font("Consolas", 14, FontStyle.Bold);

            // Bordes redondeados
            RedondearControl(boton, 15);
        }

        // TextBox redondeado con placeholder
        public static void EstiloTextBox(TextBox txt)
        {
            txt.BorderStyle = BorderStyle.None;
            txt.BackColor = Color.White;
            txt.ForeColor = Color.Gray;
            txt.Font = new Font("Segoe UI", 10, FontStyle.Italic);
            

            // Bordes redondeados
            RedondearControl(txt, 10);
        }

        // Label de títulos
        public static void EstiloTitulo(Label lbl)
        {
            lbl.Font = new Font("Consolas", 16, FontStyle.Bold);
            lbl.ForeColor = Color.Black;
        }

        // Label de subtítulos / links
        public static void EstiloLink(Label lbl)
        {
            lbl.Font = new Font("Consolas", 9, FontStyle.Regular);
            lbl.ForeColor = Color.FromArgb(33, 150, 243);
        }

        // Fondo del Form
        public static void EstiloForm(Form form)
        {
            form.BackColor = Color.FromArgb(245, 245, 245); // Gris claro
            form.FormBorderStyle = FormBorderStyle.None;    // Sin borde feo
        }

      
        // Método auxiliar general
      
         public static void RedondearControl(Control control, int radio = 15)
        {
            GraphicsPath path = new GraphicsPath();
            path.AddArc(0, 0, radio, radio, 180, 90);
            path.AddArc(control.Width - radio, 0, radio, radio, 270, 90);
            path.AddArc(control.Width - radio, control.Height - radio, radio, radio, 0, 90);
            path.AddArc(0, control.Height - radio, radio, radio, 90, 90);
            path.CloseAllFigures();
            control.Region = new Region(path);
        }

        public static void RedondearForm(Form form, int radio = 30)
        {
            GraphicsPath path = new GraphicsPath();
            path.StartFigure();
            path.AddArc(new Rectangle(0, 0, radio, radio), 180, 90);
            path.AddLine(radio, 0, form.Width - radio, 0);
            path.AddArc(new Rectangle(form.Width - radio, 0, radio, radio), -90, 90);
            path.AddLine(form.Width, radio, form.Width, form.Height - radio);
            path.AddArc(new Rectangle(form.Width - radio, form.Height - radio, radio, radio), 0, 90);
            path.AddLine(form.Width - radio, form.Height, radio, form.Height);
            path.AddArc(new Rectangle(0, form.Height - radio, radio, radio), 90, 90);
            path.CloseFigure();

            form.Region = new Region(path);
        }

        //Botones del Home

        public static void EstiloBotonPrimarioDegradado(Button boton)
        {
            boton.FlatStyle = FlatStyle.Flat;
            boton.FlatAppearance.BorderSize = 0;
            boton.BackColor = Color.FromArgb(245, 246, 248); // gris MUY claro
            boton.ForeColor = Color.FromArgb(30, 30, 30);    // gris oscuro para texto
            boton.Font = new Font("Consolas", 11, FontStyle.Bold);

            // Redondear esquinas
            int radio = 15;
            using (GraphicsPath path = new GraphicsPath())
            {
                path.AddArc(0, 0, radio, radio, 180, 90);
                path.AddArc(boton.Width - radio, 0, radio, radio, 270, 90);
                path.AddArc(boton.Width - radio, boton.Height - radio, radio, radio, 0, 90);
                path.AddArc(0, boton.Height - radio, radio, radio, 90, 90);
                path.CloseAllFigures();
                boton.Region = new Region(path);
            }
        }

    }
}

using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;

namespace ProyectoPracticas
{
    public static class UI_Utilidad
    {
        public static void EstiloLabels(Form form)
        {
            AplicarEstiloLabelsRecursivo(form);
        }

        private static void AplicarEstiloLabelsRecursivo(Control parent)
        {
            foreach (Control ctrl in parent.Controls)
            {
                if (ctrl is Label lbl)
                {
                    // 🔹 Solo modificar si el Label está en tamaño chico (ej. <= 12)
                    if (lbl.Font.Size <= 12)
                    {
                        lbl.Font = new Font("Segoe UI", 12, FontStyle.Regular);
                        lbl.ForeColor = Color.Black; // opcional
                    }
                }

                if (ctrl.HasChildren)
                {
                    AplicarEstiloLabelsRecursivo(ctrl);
                }
            }
        }

        public static void EstiloTextBox(TextBox txt, string placeholder = "")
        {
            // Aplicar bordes redondeados
            RedondearControl(txt, 15);

            // Estilos base
            txt.BorderStyle = BorderStyle.None;
            txt.BackColor = Color.White;
            txt.ForeColor = Color.Black;
            txt.Font = new Font("Segoe UI", 10, FontStyle.Regular);

            // Agregar padding interno
            txt.Padding = new Padding(8, 5, 8, 5);

            if (!string.IsNullOrWhiteSpace(placeholder))
            {
                // Aplicar placeholder inicial
                txt.Text = placeholder;
                txt.ForeColor = Color.Gray;

                // Evento al entrar
                txt.GotFocus += (s, e) =>
                {
                    if (txt.Text == placeholder)
                    {
                        txt.Text = "";
                        txt.ForeColor = Color.Black;
                    }
                };

                // Evento al salir
                txt.LostFocus += (s, e) =>
                {
                    if (string.IsNullOrWhiteSpace(txt.Text))
                    {
                        txt.Text = placeholder;
                        txt.ForeColor = Color.Gray;
                    }
                };
            }
        }

        public static void EstiloForm(Form form)
        {
            form.BackColor = Color.FromArgb(230, 230, 230); // Gris claro
            form.FormBorderStyle = FormBorderStyle.None;
        }

        //public static void CambiarColorPaneles(Control parent)
        //{
        //    foreach (Control ctrl in parent.Controls)
        //    {
        //        if (ctrl is Panel)
        //        {
        //            ctrl.BackColor = Color.FromArgb(245, 245, 245); // gris claro
        //        }

        //        // Si tiene hijos, los recorro también
        //        if (ctrl.HasChildren)
        //        {
        //            CambiarColorPaneles(ctrl);
        //        }
        //    }
        //}

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

        public static void EstiloBotonPrimarioDegradado(Button boton, int radio = 15)
        {
            //  Configuración básica
            boton.FlatStyle = FlatStyle.Flat;
            boton.FlatAppearance.BorderSize = 0;
            boton.UseVisualStyleBackColor = false;
            boton.BackColor = Color.FromArgb(100, 140, 230); // azul suave por defecto
            boton.ForeColor = Color.WhiteSmoke;
            boton.Font = new Font("Segoe UI", 12, FontStyle.Bold);

            //  Guardar color original para hover
            boton.Tag = boton.BackColor; // guardamos el color normal
            Color colorHover = Color.FromArgb(65, 110, 225); // azul más fuerte al pasar mouse

            // Eventos hover
            boton.MouseEnter += (s, e) =>
            {
                boton.BackColor = colorHover;
                boton.Refresh();
            };
            boton.MouseLeave += (s, e) =>
            {
                boton.BackColor = (Color)boton.Tag;
                boton.Refresh();
            };

            // 4️⃣ Redondear esquinas dinámicamente
            void Redondear()
            {
                int r = Math.Min(radio, Math.Min(boton.Width, boton.Height) / 2);
                using (GraphicsPath path = new GraphicsPath())
                {
                    path.AddArc(0, 0, r, r, 180, 90);
                    path.AddArc(boton.Width - r, 0, r, r, 270, 90);
                    path.AddArc(boton.Width - r, boton.Height - r, r, r, 0, 90);
                    path.AddArc(0, boton.Height - r, r, r, 90, 90);
                    path.CloseAllFigures();
                    boton.Region = new Region(path);
                }
            }

            Redondear(); // redondeo inicial
            boton.Resize += (s, e) => Redondear(); // redondeo dinámico si cambia el tamaño
        }

        //public static void DibujarFondo(Form form)
        //{
        //    // 🔹 Activar DoubleBuffered con reflexión (evita parpadeos)
        //    typeof(Form).InvokeMember("DoubleBuffered",
        //        System.Reflection.BindingFlags.SetProperty |
        //        System.Reflection.BindingFlags.Instance |
        //        System.Reflection.BindingFlags.NonPublic,
        //        null, form, new object[] { true });

        //    // 🔹 Suscribimos al evento Paint
        //    form.Paint += (s, e) =>
        //    {
        //        Graphics g = e.Graphics;
        //        g.SmoothingMode = SmoothingMode.AntiAlias;

        //        // Fondo degradado (podés cambiar colores o ángulo)
        //        using (LinearGradientBrush brush = new LinearGradientBrush(
        //            form.ClientRectangle,
        //            Color.MediumPurple,
        //            Color.DeepSkyBlue,
        //            LinearGradientMode.ForwardDiagonal))
        //        {
        //            g.FillRectangle(brush, form.ClientRectangle);
        //        }
        //    };

        //    // 🔹 Redibujar si el form cambia de tamaño
        //    form.Resize += (s, e) => form.Invalidate();

        //    // 🔹 Hacer controles transparentes (recursivo)
        //    HacerControlesTransparentes(form);
        //}


        public static void AplicarEfectoHover(PictureBox pb, int tamañoOriginal = 40, int tamañoAgrandado = 47)
        {
            // Cuando el mouse entra
            pb.MouseEnter += (s, e) =>
            {
                pb.Size = new Size(tamañoAgrandado, tamañoAgrandado);
                // Opcional: mantener centrado
                pb.Location = new Point(pb.Location.X - (tamañoAgrandado - tamañoOriginal) / 2,
                                        pb.Location.Y - (tamañoAgrandado - tamañoOriginal) / 2);
            };

            // Cuando el mouse sale
            pb.MouseLeave += (s, e) =>
            {
                pb.Size = new Size(tamañoOriginal, tamañoOriginal);
                // Volver a la posición original
                pb.Location = new Point(pb.Location.X + (tamañoAgrandado - tamañoOriginal) / 2,
                                        pb.Location.Y + (tamañoAgrandado - tamañoOriginal) / 2);
            };
        }


        //private static void HacerControlesTransparentes(Control parent)
        //{
        //    foreach (Control ctrl in parent.Controls)
        //    {
        //        // Los que pueden tapar el degradado
        //        if (ctrl is Label || ctrl is PictureBox)
        //        {
        //            ctrl.BackColor = Color.Transparent;
        //        }

        //        // Si tiene hijos, aplicar recursivo
        //        if (ctrl.HasChildren)
        //        {
        //            HacerControlesTransparentes(ctrl);
        //        }
        //    }
        //}


    }
}

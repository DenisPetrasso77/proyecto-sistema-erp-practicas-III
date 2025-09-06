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
            boton.ForeColor = Color.White;
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

        public static void EstiloFormDegradado(Form form, Color color1, Color color2, float angle = 90f)
        {
            form.FormBorderStyle = FormBorderStyle.None;
            form.BackColor = Color.White; // cualquier color sólido sino rompe

            // Suscribir al evento Paint para dibujar el fondo
            form.Paint += (s, e) =>
            {
                using (LinearGradientBrush brush = new LinearGradientBrush(
                    form.ClientRectangle, color1, color2, angle))
                {
                    e.Graphics.FillRectangle(brush, form.ClientRectangle);
                }
            };

            // Forzar redibujado si el form cambia de tamaño
            form.Resize += (s, e) => form.Invalidate();
        }


    }
}

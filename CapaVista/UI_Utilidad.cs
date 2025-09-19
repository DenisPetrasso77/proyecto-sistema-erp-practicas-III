using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Reflection;
using System.Runtime.InteropServices;
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
                    // Solo modificar si el Label está en tamaño chico (ej. <= 12)
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

        public static void EstiloTextBox(Control ctrl, string placeholder = "")
        {
            if (ctrl is TextBox txt)
            {
                txt.Multiline = true;
                txt.AutoSize = false;
                txt.BorderStyle = BorderStyle.None;
                txt.BackColor = Color.White;
                txt.ForeColor = Color.Black;
                txt.Font = new Font("Segoe UI", 12, FontStyle.Regular);
                TextBoxHelper.SetPadding(txt, 15, 5);

                //Esquinas redondeadas con borde
                txt.Region = new Region(RoundedRect(txt.ClientRectangle, 12));
                txt.BorderStyle = BorderStyle.None;
                txt.BackColorChanged += (s, e) => txt.Invalidate();
                txt.Resize += (s, e) => txt.Region = new Region(RoundedRect(txt.ClientRectangle, 12));
                txt.Paint += (s, e) =>
                {
                    e.Graphics.SmoothingMode = SmoothingMode.AntiAlias;
                    var rect = txt.ClientRectangle;
                    rect.Width -= 1;
                    rect.Height -= 1;

                    using (var path = RoundedRect(rect, txt.Height / 2))
                    using (var backBrush = new SolidBrush(txt.BackColor))
                    using (var borderPen = new Pen(Color.LightGray, 1.8f)) // Borde visible
                    {
                        e.Graphics.FillPath(backBrush, path);
                        e.Graphics.DrawPath(borderPen, path);
                    }
                };

                //Placeholder
                if (!string.IsNullOrWhiteSpace(placeholder))
                {
                    txt.Text = placeholder;
                    txt.ForeColor = Color.Gray;

                    txt.GotFocus += (s, e) =>
                    {
                        if (txt.Text == placeholder)
                        {
                            txt.Text = "";
                            txt.ForeColor = Color.Black;
                        }
                    };
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
            else if (ctrl is ComboBox cb)
            {
                cb.FlatStyle = FlatStyle.Flat;
                cb.BackColor = Color.White;
                cb.ForeColor = Color.Black;
                cb.Font = new Font("Segoe UI", 10, FontStyle.Regular);
                cb.DropDownStyle = ComboBoxStyle.DropDownList;

                cb.Region = new Region(RoundedRect(cb.ClientRectangle, 6));
                cb.Resize += (s, e) => cb.Region = new Region(RoundedRect(cb.ClientRectangle, 6));

                cb.Paint += (s, e) =>
                {
                    e.Graphics.SmoothingMode = SmoothingMode.AntiAlias;
                    var rect = cb.ClientRectangle;
                    rect.Width -= 1;
                    rect.Height -= 1;

                    using (var path = RoundedRect(rect, cb.Height / 2))
                    using (var backBrush = new SolidBrush(cb.BackColor))
                    using (var borderPen = new Pen(Color.LightGray, 1.8f))
                    {
                        e.Graphics.FillPath(backBrush, path);
                        e.Graphics.DrawPath(borderPen, path);
                    }
                };

                // 🔹 Placeholder
                if (!string.IsNullOrWhiteSpace(placeholder))
                {
                    cb.Items.Insert(0, placeholder);
                    cb.SelectedIndex = 0;
                    cb.ForeColor = Color.Gray;

                    cb.SelectedIndexChanged += (s, e) =>
                    {
                        cb.ForeColor = cb.SelectedIndex == 0 ? Color.Gray : Color.Black;
                    };
                }
            }
        }

        // auxiliar para redondear
        private static System.Drawing.Drawing2D.GraphicsPath RoundedRect(Rectangle bounds, int radius)
        {
            int d = radius * 2;
            var path = new System.Drawing.Drawing2D.GraphicsPath();
            path.AddArc(bounds.X, bounds.Y, d, d, 180, 90);
            path.AddArc(bounds.Right - d, bounds.Y, d, d, 270, 90);
            path.AddArc(bounds.Right - d, bounds.Bottom - d, d, d, 0, 90);
            path.AddArc(bounds.X, bounds.Bottom - d, d, d, 90, 90);
            path.CloseFigure();
            return path;
        }

        public static void EstiloForm(Form form, Color? backColor = null)
        {
            // Fondo configurable (por defecto gris suave)
            form.BackColor = backColor ?? Color.FromArgb(230, 230, 230);

            // Quitar bordes
            form.FormBorderStyle = FormBorderStyle.None;

            // Activar propiedades protegidas mediante reflexión
            typeof(Control).GetProperty("DoubleBuffered", BindingFlags.NonPublic | BindingFlags.Instance)
                           .SetValue(form, true, null);

            typeof(Control).GetProperty("ResizeRedraw", BindingFlags.NonPublic | BindingFlags.Instance)
                           .SetValue(form, true, null);
        }

        public static void RedondearForm(Form form, int radio = 30)
        {
            if (form.Width <= 0 || form.Height <= 0) return;

            using (GraphicsPath path = new GraphicsPath())
            {
                path.StartFigure();

                // Esquina superior izquierda
                path.AddArc(new Rectangle(0, 0, radio, radio), 180, 90);
                path.AddLine(radio, 0, form.Width - radio, 0);

                // Esquina superior derecha
                path.AddArc(new Rectangle(form.Width - radio, 0, radio, radio), -90, 90);
                path.AddLine(form.Width, radio, form.Width, form.Height - radio);

                // Esquina inferior derecha
                path.AddArc(new Rectangle(form.Width - radio, form.Height - radio, radio, radio), 0, 90);
                path.AddLine(form.Width - radio, form.Height, radio, form.Height);

                // Esquina inferior izquierda
                path.AddArc(new Rectangle(0, form.Height - radio, radio, radio), 90, 90);
                path.CloseFigure();

                form.Region = new Region(path);
            }
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

        public static void AplicarEfectoHover(PictureBox pb, float factorAgrandado = 1.2f)
        {
            // Guardamos la posición y tamaño original en el Tag solo una vez
            var datosOriginales = new
            {
                Posicion = pb.Location,
                Tamaño = pb.Size
            };
            pb.Tag = datosOriginales;

            pb.MouseEnter += (s, e) =>
            {
                var orig = (dynamic)pb.Tag;
                int nuevoAncho = (int)(orig.Tamaño.Width * factorAgrandado);
                int nuevoAlto = (int)(orig.Tamaño.Height * factorAgrandado);

                pb.Size = new Size(nuevoAncho, nuevoAlto);

                // Recentrar para que crezca desde el medio
                pb.Location = new Point(
                    orig.Posicion.X - (nuevoAncho - orig.Tamaño.Width) / 2,
                    orig.Posicion.Y - (nuevoAlto - orig.Tamaño.Height) / 2
                );
            };

            pb.MouseLeave += (s, e) =>
            {
                var orig = (dynamic)pb.Tag;

                pb.Size = orig.Tamaño;
                pb.Location = orig.Posicion;
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

        public static void HacerCircular(PictureBox pictureBox)
        {
            // Crear un GraphicsPath que contenga un círculo
            GraphicsPath path = new GraphicsPath();
            path.AddEllipse(0, 0, pictureBox.Width, pictureBox.Height);

            // Aplicar la región circular al PictureBox
            pictureBox.Region = new Region(path);
        }

        public class TextBoxHelper
        {
            private const int EM_SETMARGINS = 0xD3;
            private const int EC_LEFTMARGIN = 0x1;
            private const int EC_RIGHTMARGIN = 0x2;

            [DllImport("user32.dll", CharSet = CharSet.Auto)]
            private static extern IntPtr SendMessage(IntPtr hWnd, int msg, int wParam, int lParam);

            public static void SetPadding(TextBox txt, int left, int right)
            {
                SendMessage(txt.Handle, EM_SETMARGINS, EC_LEFTMARGIN | EC_RIGHTMARGIN, (right << 16) | left);
            }
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



        public static void EstiloDataGridView(DataGridView dgv)
        {
            if (dgv == null) return;

            // Colores base
            dgv.BackgroundColor = Color.White;
            dgv.BorderStyle = BorderStyle.None;
            dgv.GridColor = Color.LightSteelBlue;

            // Filas
            dgv.DefaultCellStyle.BackColor = Color.White;
            dgv.DefaultCellStyle.ForeColor = Color.Black;
            dgv.DefaultCellStyle.Font = new Font("Segoe UI", 10, FontStyle.Regular);
            dgv.DefaultCellStyle.Padding = new Padding(4, 2, 4, 2);
            dgv.RowTemplate.Height = 28;

            // Filas alternas
            dgv.AlternatingRowsDefaultCellStyle.BackColor = Color.FromArgb(248, 248, 248);

            // Selección
            dgv.DefaultCellStyle.SelectionBackColor = Color.FromArgb(100, 140, 230);
            dgv.DefaultCellStyle.SelectionForeColor = Color.White;

            // Encabezados
            dgv.EnableHeadersVisualStyles = false;
            dgv.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.None;
            dgv.ColumnHeadersDefaultCellStyle.BackColor = Color.FromArgb(65, 110, 225);
            dgv.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;
            dgv.ColumnHeadersDefaultCellStyle.Font = new Font("Segoe UI Semibold", 12, FontStyle.Bold);
            dgv.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dgv.ColumnHeadersDefaultCellStyle.WrapMode = DataGridViewTriState.True; // ✅ permite salto de línea
            dgv.ColumnHeadersHeight = 40; // un poquito más alto para que no corte el texto
            dgv.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.DisableResizing;

            // Ajuste columnas automático
            dgv.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;

            // Evitar que se "desaparezcan" si está vacío
            dgv.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;
            dgv.AllowUserToAddRows = false; // oculta la fila vacía extra
            dgv.RowHeadersVisible = false;  // saca la columna gris de la izquierda

            // Bordes de celdas
            dgv.CellBorderStyle = DataGridViewCellBorderStyle.SingleHorizontal;

            // Estilo filas al pasar mouse
            dgv.RowPrePaint += (s, ev) =>
            {
                if ((ev.State & DataGridViewElementStates.Selected) == 0)
                {
                    ev.Graphics.FillRectangle(new SolidBrush(
                        ev.RowIndex % 2 == 0 ? Color.White : Color.FromArgb(248, 248, 248)
                    ), ev.RowBounds);
                }
            };

            // ✅ Si está vacío, mostrar mensaje en vez de que quede raro
            dgv.Paint += (s, e) =>
            {
                if (dgv.Rows.Count == 0)
                {
                    TextRenderer.DrawText(
                        e.Graphics,
                        "No hay datos para mostrar",
                        new Font("Segoe UI", 11, FontStyle.Italic),
                        dgv.ClientRectangle,
                        Color.Gray,
                        TextFormatFlags.HorizontalCenter | TextFormatFlags.VerticalCenter
                    );
                }
            };
        }

        public static void EstiloGroupBoxSoloTitulo(GroupBox gb, Font tituloFont, Font hijosFont)
        {
            // Cambiar el font del título
            gb.Font = tituloFont;

            // Restaurar los hijos con otra fuente
            foreach (Control ctrl in gb.Controls)
            {
                ctrl.Font = hijosFont;
            }
        }


    }
}

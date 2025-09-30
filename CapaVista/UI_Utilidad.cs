using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Reflection;
using System.Runtime.InteropServices;
using System.Windows.Forms;
using CapaVista;

namespace ProyectoPracticas
{
    public static class UI_Utilidad
    {
        // ================================
        //         ESTILOS BÁSICOS
        // ================================
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
                    if (lbl.Font.Size <= 12)
                    {
                        lbl.Font = new Font("Segoe UI", 12, FontStyle.Regular);
                        lbl.ForeColor = Color.Black;
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

                txt.Region = new Region(RoundedRect(txt.ClientRectangle, 12));
                txt.Resize += (s, e) => txt.Region = new Region(RoundedRect(txt.ClientRectangle, 12));

                txt.Paint += (s, e) =>
                {
                    e.Graphics.SmoothingMode = SmoothingMode.AntiAlias;
                    var rect = txt.ClientRectangle;
                    rect.Width -= 1;
                    rect.Height -= 1;

                    using (var path = RoundedRect(rect, txt.Height / 2))
                    using (var backBrush = new SolidBrush(txt.BackColor))
                    using (var borderPen = new Pen(Color.LightGray, 1.8f))
                    {
                        e.Graphics.FillPath(backBrush, path);
                        e.Graphics.DrawPath(borderPen, path);
                    }
                };

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

        private static GraphicsPath RoundedRect(Rectangle bounds, int radius)
        {
            int d = radius * 2;
            var path = new GraphicsPath();
            path.AddArc(bounds.X, bounds.Y, d, d, 180, 90);
            path.AddArc(bounds.Right - d, bounds.Y, d, d, 270, 90);
            path.AddArc(bounds.Right - d, bounds.Bottom - d, d, d, 0, 90);
            path.AddArc(bounds.X, bounds.Bottom - d, d, d, 90, 90);
            path.CloseFigure();
            return path;
        }

        public static void EstiloForm(Form form, Color? backColor = null)
        {
            form.BackColor = backColor ?? Color.FromArgb(230, 230, 230);
            form.FormBorderStyle = FormBorderStyle.None;

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
        }

        public static void EstiloBotonPrimarioDegradado(Button boton, int radio = 15)
        {
            boton.FlatStyle = FlatStyle.Flat;
            boton.FlatAppearance.BorderSize = 0;
            boton.UseVisualStyleBackColor = false;
            boton.Font = new Font("Segoe UI", 12, FontStyle.Bold);

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

            Redondear();
            boton.Resize += (s, e) => Redondear();

            // Ajustar colores según tema
            if (CV_ConfigSistema.TemaActual == TipoTema.Estandar)
            {
                boton.BackColor = Color.FromArgb(100, 140, 230);
                boton.ForeColor = Color.WhiteSmoke;

                Color colorHover = Color.FromArgb(65, 110, 225);
                boton.Tag = boton.BackColor;

                boton.MouseEnter += (s, e) => { boton.BackColor = colorHover; };
                boton.MouseLeave += (s, e) => { boton.BackColor = (Color)boton.Tag; };
            }
            else if (CV_ConfigSistema.TemaActual == TipoTema.Oscuro || CV_ConfigSistema.TemaActual == TipoTema.ContrasteAlto)
            {
                boton.BackColor = Color.Gray; // ahora de entrada gris
                boton.ForeColor = CV_ConfigSistema.TemaActual == TipoTema.Oscuro ? Color.WhiteSmoke : Color.Yellow;

                // hover fijo igual gris
                boton.Tag = boton.BackColor;
                boton.MouseEnter += (s, e) => { boton.BackColor = boton.BackColor; };
                boton.MouseLeave += (s, e) => { boton.BackColor = boton.BackColor; };
            }
        }

        public static void AplicarEfectoHover(PictureBox pb, float factorAgrandado = 1.2f)
        {
            var datosOriginales = new { Posicion = pb.Location, Tamaño = pb.Size };
            pb.Tag = datosOriginales;

            pb.MouseEnter += (s, e) =>
            {
                var orig = (dynamic)pb.Tag;
                int nuevoAncho = (int)(orig.Tamaño.Width * factorAgrandado);
                int nuevoAlto = (int)(orig.Tamaño.Height * factorAgrandado);

                pb.Size = new Size(nuevoAncho, nuevoAlto);
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

        public static void HacerCircular(PictureBox pictureBox)
        {
            GraphicsPath path = new GraphicsPath();
            path.AddEllipse(0, 0, pictureBox.Width, pictureBox.Height);
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

        public static void EstiloDataGridView(DataGridView dgv)
        {
            if (dgv == null) return;

            dgv.BackgroundColor = Color.White;
            dgv.BorderStyle = BorderStyle.None;
            dgv.GridColor = Color.LightSteelBlue;

            dgv.DefaultCellStyle.BackColor = Color.White;
            dgv.DefaultCellStyle.ForeColor = Color.Black;
            dgv.DefaultCellStyle.Font = new Font("Segoe UI", 10, FontStyle.Regular);
            dgv.DefaultCellStyle.Padding = new Padding(4, 2, 4, 2);
            dgv.RowTemplate.Height = 28;

            dgv.AlternatingRowsDefaultCellStyle.BackColor = Color.FromArgb(248, 248, 248);

            dgv.DefaultCellStyle.SelectionBackColor = Color.FromArgb(100, 140, 230);
            dgv.DefaultCellStyle.SelectionForeColor = Color.White;

            dgv.EnableHeadersVisualStyles = false;
            dgv.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.None;
            dgv.ColumnHeadersDefaultCellStyle.BackColor = Color.FromArgb(65, 110, 225);
            dgv.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;
            dgv.ColumnHeadersDefaultCellStyle.Font = new Font("Segoe UI Semibold", 12, FontStyle.Bold);
            dgv.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dgv.ColumnHeadersDefaultCellStyle.WrapMode = DataGridViewTriState.True;
            dgv.ColumnHeadersHeight = 40;
            dgv.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.DisableResizing;

            dgv.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgv.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;
            dgv.AllowUserToAddRows = false;
            dgv.RowHeadersVisible = false;
            dgv.CellBorderStyle = DataGridViewCellBorderStyle.SingleHorizontal;

            dgv.RowPrePaint += (s, ev) =>
            {
                if ((ev.State & DataGridViewElementStates.Selected) == 0)
                {
                    ev.Graphics.FillRectangle(new SolidBrush(
                        ev.RowIndex % 2 == 0 ? Color.White : Color.FromArgb(248, 248, 248)
                    ), ev.RowBounds);
                }
            };

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
            gb.Font = tituloFont;
            foreach (Control ctrl in gb.Controls)
            {
                ctrl.Font = hijosFont;
            }
        }

        // ================================
        //             TEMAS
        // ================================

        private static Dictionary<Control, (Color Back, Color Fore)> ColoresOriginales
        = new Dictionary<Control, (Color, Color)>();

        public static void GuardarColoresOriginales(Control parent)
        {
            if (!ColoresOriginales.ContainsKey(parent))
            {
                ColoresOriginales[parent] = (parent.BackColor, parent.ForeColor);
            }

            foreach (Control ctrl in parent.Controls)
            {
                if (!ColoresOriginales.ContainsKey(ctrl))
                {
                    ColoresOriginales[ctrl] = (ctrl.BackColor, ctrl.ForeColor);
                }

                if (ctrl.HasChildren)
                    GuardarColoresOriginales(ctrl);
            }
        }
        public static void AplicarTema(TipoTema tema)
        {
            switch (tema)
            {
                case TipoTema.Estandar:
                    // 🔹 En lugar de forzar blanco/negro, restauramos los originales
                    CV_ConfigSistema.ColorPrincipal = Color.Empty; // marcador
                    CV_ConfigSistema.ColorTexto = Color.Empty;
                    break;

                case TipoTema.Oscuro:
                    CV_ConfigSistema.ColorPrincipal = Color.FromArgb(45, 45, 48);
                    CV_ConfigSistema.ColorTexto = Color.WhiteSmoke;
                    break;

                case TipoTema.ContrasteAlto:
                    CV_ConfigSistema.ColorPrincipal = Color.Black;
                    CV_ConfigSistema.ColorTexto = Color.Yellow;
                    break;
            }

            CV_ConfigSistema.TemaActual = tema;
        }

        public static void AplicarTemaAControles(Control parent)
        {
            foreach (Control ctrl in parent.Controls)
            {
                if (CV_ConfigSistema.TemaActual == TipoTema.Estandar)
                {
                    if (ColoresOriginales.ContainsKey(ctrl))
                    {
                        ctrl.BackColor = ColoresOriginales[ctrl].Back;
                        ctrl.ForeColor = ColoresOriginales[ctrl].Fore;
                    }
                }
                else
                {
                    if (ctrl is Panel)
                    {
                        ctrl.BackColor = Color.Gray;
                        ctrl.ForeColor = CV_ConfigSistema.ColorTexto;
                    }
                    else if (ctrl is Button)
                    {
                        EstiloBotonPrimarioDegradado((Button)ctrl);
                    }
                    else if (ctrl is PictureBox pb)
                    {
                        pb.BackColor = Color.Transparent;
                        pb.SizeMode = PictureBoxSizeMode.Zoom;

                        // Excluir algunos por nombre
                        //if (ConfigSistema.TemaActual != TipoTema.Estandar && pb.Image != null &&
                        //    pb.Name != "pictureBox1" && pb.Name != "lbltituloHome")
                        //{
                        //    pb.Image = ConvertirImagenAGris(pb.Image);
                        //}
                    }
                    else if (ctrl is DataGridView dgv)
                    {
                        if (CV_ConfigSistema.TemaActual != TipoTema.Estandar)
                        {
                            // Fondo de toda la grilla
                            dgv.BackgroundColor = Color.Gray;
                            dgv.DefaultCellStyle.BackColor = Color.Gray;
                            dgv.DefaultCellStyle.ForeColor = Color.White;
                            dgv.DefaultCellStyle.SelectionBackColor = Color.DarkGray;
                            dgv.DefaultCellStyle.SelectionForeColor = Color.White;

                            // Cabeceras
                            dgv.ColumnHeadersDefaultCellStyle.BackColor = Color.Black;
                            dgv.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;
                            dgv.ColumnHeadersDefaultCellStyle.SelectionBackColor = Color.Black;
                            dgv.ColumnHeadersDefaultCellStyle.SelectionForeColor = Color.White;

                            // Opcional: filas alternadas
                            dgv.AlternatingRowsDefaultCellStyle.BackColor = Color.DimGray;
                            dgv.AlternatingRowsDefaultCellStyle.ForeColor = Color.White;

                            // Quitar borde de selección si querés más limpio
                            dgv.CellBorderStyle = DataGridViewCellBorderStyle.SingleHorizontal;
                            dgv.RowHeadersVisible = false;
                            dgv.EnableHeadersVisualStyles = false; // muy importante para que tome los colores personalizados
                        }

                        else
                        {
                            // Si querés volver al tema estándar, podés resetear colores
                            dgv.BackgroundColor = SystemColors.Window;
                            dgv.DefaultCellStyle.BackColor = SystemColors.Window;
                            dgv.DefaultCellStyle.ForeColor = SystemColors.ControlText;
                            dgv.ColumnHeadersDefaultCellStyle.BackColor = SystemColors.Control;
                            dgv.ColumnHeadersDefaultCellStyle.ForeColor = SystemColors.ControlText;
                            dgv.EnableHeadersVisualStyles = true;
                        }
                    }
                    else if (ctrl is Label lbl)
                    {
                        if (CV_ConfigSistema.TemaActual != TipoTema.Estandar)
                        {
                            lbl.BackColor = lbl.Parent?.BackColor ?? CV_ConfigSistema.ColorPrincipal;
                            lbl.ForeColor = Color.LightGray; // O ConfigSistema.ColorTexto
                        }
                        else
                        {
                            lbl.BackColor = SystemColors.Control;
                            lbl.ForeColor = SystemColors.ControlText;
                        }
                    }

                    else
                    {
                        ctrl.BackColor = CV_ConfigSistema.ColorPrincipal;
                        ctrl.ForeColor = CV_ConfigSistema.ColorTexto;
                    }

                }

                // Recursividad para todos los hijos, incluyendo paneles dentro de paneles
                if (ctrl.HasChildren)
                    AplicarTemaAControles(ctrl);
            }

            // Asegurarse de que el form principal también tenga color de fondo del tema
            if (parent is Form)
            {
                if (CV_ConfigSistema.TemaActual != TipoTema.Estandar)
                {
                    parent.BackColor = CV_ConfigSistema.ColorPrincipal;
                    parent.ForeColor = CV_ConfigSistema.ColorTexto;
                }
            }
        }
        public static void AplicarTemaATodosLosForms()
        {
            foreach (Form form in Application.OpenForms)
            {
                AplicarTemaAControles(form);
            }
        }

        // ================================
        //             Fuentes
        // ================================

        public static void AplicarFuenteAControles(Control parent)
        {
            foreach (Control ctrl in parent.Controls)
            {
                if (ctrl.Tag?.ToString() == "noCambiarFuente")
                    continue; // lo salteamos

                if (ctrl is Button || ctrl is Label || ctrl is GroupBox)
                {
                    ctrl.Font = CV_ConfigSistema.GetFuente();
                }

                if (ctrl.HasChildren)
                    AplicarFuenteAControles(ctrl);
            }
        }

        public static void AplicarFuenteATodosLosForms()
        {
            foreach (Form form in Application.OpenForms)
            {
                AplicarFuenteAControles(form);
            }
        }
    }
}

using CapaEntities;
using CapaLogica;
using ProyectoPracticas;
using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Windows.Forms;

namespace CapaVista
{
    public partial class FrmNuevoProducto : Form
    {
        CL_Metodos metodos = new CL_Metodos();
        private string rutaImagenTemporal = null;

        public FrmNuevoProducto()
        {
            InitializeComponent();
        }

        private void FrmBaseProductos_Shown(object sender, EventArgs e)
        {
            if (this.DesignMode) return;
            this.ActiveControl = null;
            UI_Utilidad.EstiloLabels(this);
            UI_Utilidad.EstiloForm(this);
            UI_Utilidad.RedondearForm(this, 28);
            UI_Utilidad.EstiloBotonPrimarioDegradado(bntCargarImagen);
            UI_Utilidad.EstiloBotonPrimarioDegradado(btnSalir);
            UI_Utilidad.EstiloBotonPrimarioDegradado(btnGuardar);
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox1.Checked)
            { 
                groupBox1.Enabled = true;
                checkBox2.Enabled = true;
            }
            else
            {
                checkBox2.Enabled = false;
                groupBox1.Enabled = !groupBox1.Enabled;
            }
        }

        private void Cargarcbxcategorias()
        {
            cmbCategorias.Items.Clear();
            DataTable CacheCategorias = metodos.TraerTodo("CategoriasProductos");
            foreach (DataRow filas in CacheCategorias.Rows)
            {
                if (filas["Estado"].ToString().Trim() != "Inactivo")
                {
                    string fila = $"{filas["IdCategoria"]} - {filas["Categoria"]}";
                    cmbCategorias.Items.Add(fila);
                }
            }
        }
        private void Cargarcbxtpoproducto()
        {
            cmbProducto.Items.Clear();
            DataTable CacheTipoProducto = metodos.TraerTodo("TipoProductos");
            foreach (DataRow filas in CacheTipoProducto.Rows)
            {
                string fila = $"{filas["IdTipoProducto"]} - {filas["TipoProducto"]}";
                cmbProducto.Items.Add(fila);
            }
        }
        private void Cargarcbxmedidas()
        {
            cmbMedidas.Items.Clear();
            DataTable CacheMedidas = metodos.TraerTodo("Medidas");
            foreach (DataRow filas in CacheMedidas.Rows)
            {
                string fila = $"{filas["Idmedidas"]} - {filas["Medida"]}";
                cmbMedidas.Items.Add(fila);
            }
        }
        private void Cargarcbxmarcas()
        {
            cmbMarcas.Items.Clear();
            DataTable CacheMarcas = metodos.TraerTodo("Marca");
            foreach (DataRow filas in CacheMarcas.Rows)
            {
                string fila = $"{filas["Idmarca"]} - {filas["Marca"]}";
                cmbMarcas.Items.Add(fila);
            }
        }
        private void Cargarcbxventa()
        {
            cmbVenta.Items.Clear();
            DataTable CacheFVentas = metodos.TraerTodo("UnidadReferencia");
            foreach (DataRow filas in CacheFVentas.Rows)
            {
                string fila = $"{filas["idUnidad"]} - {filas["Unidad"]}";
                cmbVenta.Items.Add(fila);
            }
        }
        private void FrmNuevoProducto_Load(object sender, EventArgs e)
        {
            Cargarcbxcategorias();
            Cargarcbxtpoproducto();
            Cargarcbxmedidas();
            Cargarcbxmarcas();
            Cargarcbxventa();
            cmbEstado.SelectedIndex = 0;
        }

        private void pictureBox5_Click(object sender, EventArgs e)
        {
            new FrmCargarTipoProducto().ShowDialog();
            Cargarcbxtpoproducto();
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            new FrmCargarMarcas().ShowDialog();
            Cargarcbxmarcas();
        }

        private void pictureBox4_Click(object sender, EventArgs e)
        {
            new FrmCargarCategorias().ShowDialog();
            Cargarcbxcategorias();
        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {
            //new FrmGestionMedidas().ShowDialog();
            Cargarcbxmedidas();
        }
        private void VerificarCaracter(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == '.')
            {
                e.KeyChar = ',';
            }
            if (!char.IsDigit(e.KeyChar) && e.KeyChar != (char)8 && e.KeyChar != ',')
            {
                e.Handled = true;
            }
        }
        private void ConvertirDecimal(System.Windows.Forms.TextBox tx)
        {
            if (!string.IsNullOrEmpty(tx.Text))
            {
                tx.Text = decimal.Parse(tx.Text).ToString("N2");
            }
            else
            {
                MessageBox.Show("Ingrese un valor numerico valido");
            }
        }

        private void textBox6_Leave(object sender, EventArgs e)
        {
            ConvertirDecimal(txtCompra);
        }

        private void textBox7_Leave(object sender, EventArgs e)
        {
            ConvertirDecimal(txtVenta);

        }

        private void checkBox2_CheckedChanged(object sender, EventArgs e)
        {
            groupBox3.Enabled = checkBox2.Checked;

            if (groupBox3.Enabled)
            {
                txtCant1.Text = string.Empty;
                txtPor1.Text = string.Empty;
                txtPor2.Text = string.Empty;
                txtCant2.Text = string.Empty;
                txtPor3.Text = string.Empty;
                txtCant3.Text = string.Empty;
                txtPor4.Text = string.Empty;
                txtCant4.Text = string.Empty;
            }
            else
            {
                txtCant1.Text = string.Empty;
                txtPor1.Text = string.Empty;
                txtPor2.Text = string.Empty;
                txtCant2.Text = string.Empty;
                txtPor3.Text = string.Empty;
                txtCant3.Text = string.Empty;
                txtPor4.Text = string.Empty;
                txtCant4.Text = string.Empty;
                pictureBox9.Visible = false;
                pictureBox10.Visible = false;
                pictureBox12.Visible = false;
                pictureBox13.Visible = false;
                txtPor2.Visible = false;
                txtCant2.Visible = false;
                txtPor3.Visible = false;
                txtCant3.Visible = false;
                txtPor4.Visible = false;
                txtCant4.Visible = false;
            }
        }

        private void pictureBox6_Click(object sender, EventArgs e)
        {
            txtCant2.Visible = true;
            txtPor2.Visible = true;
            pictureBox9.Visible = true;
            pictureBox12.Visible = true;
            pictureBox6.Visible = false;


        }

        private void pictureBox9_Click(object sender, EventArgs e)
        {
            txtPor3.Visible = true;
            txtCant3.Visible = true;
            pictureBox9.Visible = false;
            pictureBox10.Visible = true;
            pictureBox13.Visible = true;
            pictureBox12.Visible = false;
        }

        private void pictureBox12_Click(object sender, EventArgs e)
        {
            pictureBox12.Visible = false;
            pictureBox9.Visible = false;
            pictureBox6.Visible = true;
            txtPor2.Visible = false;
            txtCant2.Visible = false;
        }

        private void pictureBox10_Click(object sender, EventArgs e)
        {
            txtPor4.Visible = true;
            txtCant4.Visible = true;
            pictureBox9.Visible = false;
            pictureBox12.Visible = false;
            pictureBox10.Visible = false;
            pictureBox13.Visible = false;
            pictureBox14.Visible = true;


        }

        private void pictureBox13_Click(object sender, EventArgs e)
        {
            pictureBox13.Visible = false;
            pictureBox10.Visible = false;
            txtPor3.Visible = false;
            txtCant3.Visible = false;
            pictureBox9.Visible = true;
            pictureBox12.Visible = true;
            txtPor2.Visible = true;
            txtCant2.Visible = true;

        }

        private void pictureBox14_Click(object sender, EventArgs e)
        {
            txtPor4.Visible = false;
            txtCant4.Visible = false;
            txtPor3.Visible = true;
            txtCant3.Visible = true;
            pictureBox14.Visible = false;
            pictureBox13.Visible = true;
            pictureBox10.Visible = true;
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            if (!checkBox1.Checked)
            {
                if (CV_Utiles.TextboxVacios(txtCodigo) && CV_Utiles.ComboboxVacios(cmbProducto, cmbMarcas, cmbCategorias, cmbMedidas, cmbEstado))
                {
                    MessageBox.Show("Por favor complete los datos del producto");
                    return;
                }
            }
            if (!checkBox2.Checked)
            {
                if (CV_Utiles.TextboxVacios(txtMaximo, txtCompra, txtVenta, txtActual, txtMinimo) && CV_Utiles.ComboboxVacios(cmbVenta))
                {
                    MessageBox.Show("Por favor complete el stock y el precio del producto");
                    return;
                }
            }
            else if (checkBox2.Checked)
            {
                if (CV_Utiles.TextboxVacios(txtCant1, txtPor1))
                {
                    MessageBox.Show("Por favor coloque al menos 1 descuento");
                    return;
                }
            }
            try
            {
                string codigo = txtCodigo.Text.Trim();
                int tipoproducto = Convert.ToInt32(cmbProducto.Text.Split('-')[0].Trim());
                int marca = Convert.ToInt32(cmbMarcas.Text.Split('-')[0].Trim());
                int medidas = Convert.ToInt32(cmbMedidas.Text.Split('-')[0].Trim());
                int cate = Convert.ToInt32(cmbCategorias.Text.Split('-')[0].Trim());
                string estado = cmbEstado.Text.Trim();
                int? fventa = string.IsNullOrWhiteSpace(cmbVenta.Text) ? (int?)null : Convert.ToInt32(cmbVenta.Text.Split('-')[0].Trim());
                decimal preciocompra = string.IsNullOrWhiteSpace(txtCompra.Text) ? (decimal)0 : Convert.ToDecimal(txtCompra.Text.Trim());
                decimal precioventa = string.IsNullOrWhiteSpace(txtVenta.Text) ? (decimal)0 : Convert.ToDecimal(txtVenta.Text.Trim());
                int stockactual = string.IsNullOrWhiteSpace(txtActual.Text) ? (int)0 : Convert.ToInt32(txtActual.Text.Trim());
                int stockmax = string.IsNullOrWhiteSpace(txtMaximo.Text) ? (int)0 : Convert.ToInt32(txtMaximo.Text.Trim());
                int stockmin = string.IsNullOrWhiteSpace(txtMinimo.Text) ? (int)0 : Convert.ToInt32(txtMinimo.Text.Trim());
                int can1 = string.IsNullOrWhiteSpace(txtCant1.Text) ? 0 : Convert.ToInt32(txtCant1.Text.Trim());
                int por1 = string.IsNullOrWhiteSpace(txtPor1.Text) ? 0 : Convert.ToInt32(txtPor1.Text.Trim());
                int can2 = string.IsNullOrWhiteSpace(txtCant2.Text) ? 0 : Convert.ToInt32(txtCant2.Text.Trim());
                int por2 = string.IsNullOrWhiteSpace(txtPor2.Text) ? 0 : Convert.ToInt32(txtPor2.Text.Trim());
                int can3 = string.IsNullOrWhiteSpace(txtCant3.Text) ? 0 : Convert.ToInt32(txtCant3.Text.Trim());
                int por3 = string.IsNullOrWhiteSpace(txtPor3.Text) ? 0 : Convert.ToInt32(txtPor3.Text.Trim());
                int can4 = string.IsNullOrWhiteSpace(txtCant4.Text) ? 0 : Convert.ToInt32(txtCant4.Text.Trim());
                int por4 = string.IsNullOrWhiteSpace(txtPor4.Text) ? 0 : Convert.ToInt32(txtPor4.Text.Trim());
                DateTime fecha = DateTime.Now;

                var descuentos = new List<(int cantidadMinima, int porcentaje)>
                {
                    (can1, por1),
                    (can2, por2),
                    (can3, por3),
                    (can4, por4)
                }.Where(d => d.cantidadMinima > 0 && d.porcentaje > 0)
                .OrderByDescending(d => d.cantidadMinima)
                .ToList();
                ProductoNuevo productoNuevo = new ProductoNuevo
                {
                    CodigoProducto = codigo,
                    Nombre = tipoproducto,
                    IdCategoria = cate,
                    IdMarca = marca,
                    IdMedida = medidas,
                    IdUnidadVenta = fventa,
                    StockMin = stockmin,
                    StockMax = stockmax,
                    StockActual = stockactual,
                    Estado = estado,
                    FechaAlta = fecha,
                    IdUsuarioAlta = Sesion.Usuario.IdUsuario,
                    PrecioCompra = preciocompra,
                    PrecioVenta = precioventa,
                    Descuentos = descuentos,
                    DVH = CV_Seguridad.CalcularDVH(codigo + tipoproducto + cate + marca + medidas + fventa + estado + fecha + 1 + "Normal")
                };
                string resultado = metodos.InsertarProducto(productoNuevo);
                MessageBox.Show(resultado);
                
            }
            catch
            {
                MessageBox.Show("Error al Guardar el producto","Error",MessageBoxButtons.OK,MessageBoxIcon.Error);
                return;
            }
            try
            {
                string carpetaDestino = Path.Combine(Application.StartupPath, "Imagenes", "Productos");
                if (!Directory.Exists(carpetaDestino))
                    Directory.CreateDirectory(carpetaDestino);

                string extension = Path.GetExtension(rutaImagenTemporal);
                string destino = Path.Combine(carpetaDestino, txtCodigo.Text + extension);

                if (File.Exists(destino))
                {
                    File.Delete(destino);
                }

                File.Copy(rutaImagenTemporal, destino, true);
            }
            catch
            {
            MessageBox.Show("Error al guardar la imagen del producto","Error",MessageBoxButtons.OK,MessageBoxIcon.Error);
            }
            CV_Utiles.LimpiarControles(this);
            pictureBox1.Image = null;
            txtCodigo.Focus();
        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void bntCargarImagen_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog ofd = new OpenFileDialog())
            {
                ofd.Filter = "Archivos de imagen|*.jpg;*.jpeg;*.png;*.bmp";

                if (ofd.ShowDialog() == DialogResult.OK)
                {
                    rutaImagenTemporal = ofd.FileName; 
                    pictureBox1.Image = Image.FromFile(rutaImagenTemporal);
                }
            }
        }
    }
}

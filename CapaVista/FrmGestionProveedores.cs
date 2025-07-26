using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using CapaEntities;
using CapaLogica;

namespace CapaVista
{
    public partial class FrmGestionProveedores : Form
    {
        CL_Metodos metodos = new CL_Metodos();
        public FrmGestionProveedores()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (CV_Utiles.TextboxVacios(textBox2, textBox3, textBox4, textBox5, textBox6, textBox7, textBox8) && CV_Utiles.ComboboxVacios(comboBox2, comboBox3))
            {
                MessageBox.Show("Por favor complete todos los campos");
                return;
            }
            if (CV_Utiles.CampoMail(textBox6.Text))
            {
                MessageBox.Show("Formato de Mail Incorrecto");
                return;
            }

            string nrotelefono = maskedTextBox1.Text;
            string soloNumeros = new string(nrotelefono.Where(char.IsDigit).ToArray());
            string numeroidentificacion = comboBox1.Text.Trim() == "DNI" ? textBox4.Text.Trim() : textBox3.Text.Trim() + textBox4.Text.Trim() + textBox5.Text.Trim();
            int CodigoArea = Convert.ToInt32(soloNumeros.Substring(0, 3));
            int Telefono = Convert.ToInt32(soloNumeros.Substring(3));
            Proveedor proveedor = new Proveedor
            {
                NombreComercial = textBox1.Text.Trim(),
                RazonSocial = textBox2.Text.Trim(),
                TipoIdentificacion = comboBox1.Text.Trim(),
                NumeroDeIdentificacion = numeroidentificacion,
                Correo = textBox6.Text.Trim(),
                CodigoArea = CodigoArea,
                Telefono = Telefono,
                DireccionCalle = textBox7.Text.Trim(),
                DireccionAltura = Convert.ToInt32(textBox8.Text.Trim()),
                DireccionProvincia = Convert.ToInt32(comboBox2.Text.Split('-')[0].Trim()),
                DireccionLocalidad = Convert.ToInt32(comboBox3.Text.Split('-')[0].Trim()),
                DireccionCodigoPostal = Convert.ToInt32(textBox10.Text.Trim()),
                Observaciones = textBox9.Text.Trim(),
                IdUsuarioAlta = 1,
            };
            try
            {
                string resultado = metodos.InsertarProveedor(proveedor);
                MessageBox.Show(resultado);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al guardar proveedor: " + ex.Message);
            }
        }
        private void CargarProvincias()
        {
            CV_Utiles.LimpiarControles(comboBox2);
            DataTable cacheprovincias = metodos.TraerTodo("Provincias");
            foreach (DataRow filas in cacheprovincias.Rows)
            {
                string fila = $"{filas["IdProvincia"]} - {filas["Provincia"]}";
                comboBox2.Items.Add(fila);
            }
        }
        private void CargarLocalidades(int id)
        {
            CV_Utiles.LimpiarControles(comboBox3);
            DataTable cacheLocalidades = metodos.Localidades(id);
            foreach (DataRow filas in cacheLocalidades.Rows)
            {
                string fila = $"{filas["IdLocalidad"]} - {filas["Localidad"]}";
                comboBox3.Items.Add(fila);
            }
        }
        private void FrmGestionProveedores_Load(object sender, EventArgs e)
        {
            CargarProvincias();
        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBox2.Text != null)
            {
                int idprovincia = Convert.ToInt32(comboBox2.Text.Split('-')[0].Trim());
                CargarLocalidades(idprovincia);
                comboBox3.Enabled = true;
            }
            else
            {
                CV_Utiles.LimpiarControles(comboBox2);
                comboBox3.Enabled = false;
            }
        }

        private void comboBox3_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBox3.Text != null)
            {
                int idlocalidad = Convert.ToInt32(comboBox3.Text.Split('-')[0].Trim());
                textBox10.Text = metodos.CodigoPostal(idlocalidad).ToString();
            }
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBox1.Text == "DNI")
            {
                textBox3.Enabled = false;
                textBox5.Enabled = false;
            }
        }
        private void VerificarCaracter(object sender, KeyPressEventArgs e)
        {
            if (!char.IsDigit(e.KeyChar) && e.KeyChar != (char)8)
            {
                e.Handled = true;
            }
        }

        private void textBox1_Enter(object sender, EventArgs e)
        {
            if (textBox1.Text == "IMPORTADOR 4K (OPCIONAL)")
            { 
                textBox1.ForeColor = Color.Black;
            }
        }

        private void textBox1_Leave(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(textBox1.Text))
            {
                textBox1.ForeColor = SystemColors.ActiveBorder;
                textBox1.Text = "IMPORTADOR 4K (OPCIONAL)";
            }
        }
    }
}

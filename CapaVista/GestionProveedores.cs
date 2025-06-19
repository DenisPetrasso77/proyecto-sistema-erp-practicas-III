using CapaLogica;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Net.Mime.MediaTypeNames;

namespace CapaVista
{
    public partial class GestionProveedores : Form
    {
        DataTable proveedorescache;
        CL_Metodos metodos = new CL_Metodos();
        public GestionProveedores()
        {
            InitializeComponent();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            Cargarbuscador();
        }
        private void Cargarbuscador()
        {
            string texto = textBox1.Text.Trim();

            if (string.IsNullOrWhiteSpace(texto))
            {
                listBox1.Visible = false;
                return;
            }

            proveedorescache = metodos.Proveedores();
            listBox1.Items.Clear();

            foreach (DataRow fila in proveedorescache.Rows)
            {
                string razon = fila["RazonSocial"].ToString().ToLower();
                string dni = fila["NumeroDeIdentificacion"].ToString().ToLower();

                if (razon.Contains(texto) || dni.Contains(texto))
                {
                    string item = $"{fila["idProveedor"]} - {fila["RazonSocial"]} - {fila["NumeroDeIdentificacion"]}";
                    listBox1.Items.Add(item);
                }
            }

            listBox1.Visible = listBox1.Items.Count > 0;
        }

        private void textBox1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Down && listBox1.Visible && listBox1.Items.Count > 0)
            {
                listBox1.Focus();
                listBox1.SelectedIndex = 0;
            }
        }

        private void textBox1_Enter(object sender, EventArgs e)
        {
            if (textBox1.Text == "BUSCAR POR RAZON SOCIAL CUIT/CUIL/DNI")
            {
                textBox1.Text = "";
            }
        }

        private void textBox1_Leave(object sender, EventArgs e)
        {
            if (textBox1.Text == "")
            {
                textBox1.Text = "BUSCAR POR RAZON SOCIAL CUIT/CUIL/DNI";
            }
        }
        private void AgregarProveedor(int id)
        {
            DataTable datosproveedor = new DataTable();
            datosproveedor = metodos.Proveedores(id);
            foreach (DataRow datos in datosproveedor.Rows)
            {
                string numero = datos["NumeroDeIdentificacion"].ToString();
                textBox5.Text = datos["NombreComercial"].ToString();
                textBox6.Text = datos["RazonSocial"].ToString();
                comboBox1.Text = datos["TipoIdentificacion"].ToString();
                if (comboBox1.Text != "DNI")
                {
                    textBox2.Text = numero.Substring(0, 2);
                    textBox3.Text = numero.Substring(2, 9);
                    textBox4.Text = numero.Substring(10);
                }

            }

        }

        private void listBox1_Click(object sender, EventArgs e)
        {
            textBox1.Text = listBox1.SelectedItem.ToString();
            AgregarProveedor(Convert.ToInt32(textBox1.Text.Split('-')[0].ToString()));
        }
        
    }
}

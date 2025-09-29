using CapaLogica;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static TheArtOfDevHtmlRenderer.Adapters.RGraphicsPath;

namespace CapaVista
{
    public partial class FrmGestionClientes : Form
    {
        CL_Metodos metodos = new CL_Metodos();
        public FrmGestionClientes()
        {
            InitializeComponent();
        }
        private void CargarClientes()
        { 
            DataTable cacheclientes = metodos.SeleccionarListadoClientes();
            dataGridView1.Rows.Clear();
            string texto = txtBuscador.Text.ToLower().Trim();
            foreach (DataRow row in cacheclientes.Rows)
            {
                int id = Convert.ToInt32(row["IdCliente"]);
                string nombreapellido = $"{row["Nombre"].ToString()} {row["Apellido"].ToString()}";
                string correo = row["Correo"].ToString();
                string dni = row["Dni"].ToString();
                string telefono = row["Telefono"].ToString();
                string localidad = row["Localidad"].ToString();
                if (!string.IsNullOrEmpty(texto) && texto != "buscador...")
                {
                    if (!(nombreapellido.ToLower().Contains(texto) ||
                          correo.ToLower().Contains(texto) ||
                          dni.ToLower().Contains(texto) ||
                          telefono.ToLower().Contains(texto) ||
                          localidad.ToLower().Contains(texto)
                          ))
                    {
                        continue;
                    }
                }
                dataGridView1.Rows.Add(id, nombreapellido, correo, dni, telefono, localidad);
               
            }
        }

        private void FrmGestionClientes_Load(object sender, EventArgs e)
        {
            CargarClientes();
        }

        private void txtBuscador_TextChanged(object sender, EventArgs e)
        {
            CargarClientes();
        }

        private void btnCerrar_Click(object sender, EventArgs e)
        {
            this.Close();
            FrmHome home = new FrmHome();
            home.Show();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            FrmNuevoCliente frm = new FrmNuevoCliente();
            frm.ShowDialog();
            CargarClientes();
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            FrmEditarCliente frm = new FrmEditarCliente(Convert.ToInt32(dataGridView1.CurrentRow.Cells[0].Value));
            frm.ShowDialog();
            CargarClientes();
        }
    }
}

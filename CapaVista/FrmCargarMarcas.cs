using CapaLogica;
using System.Data;
using System.Windows.Forms;

namespace CapaVista
{
    public partial class FrmCargarMarcas : Form
    {
        CL_Metodos metodos = new CL_Metodos();
        DataTable cachemarcas = new DataTable();
        public FrmCargarMarcas()
        {
            InitializeComponent();
        }
        private void Cargarmarcas()
        {
            cachemarcas = metodos.Marcas();
            string texto = textBox1.Text.Trim().ToLower();
            dataGridView1.Rows.Clear();

            foreach (DataRow fila in cachemarcas.Rows)
            {
                string nombreCategoria = fila["Marca"].ToString().ToLower();
                string estado = fila["Estado"].ToString();

                if (estado == "Inactivo" && !checkBox1.Checked)
                    continue;

                if (string.IsNullOrWhiteSpace(texto) || textBox1.Text == "BUSCADOR...")
                {
                    dataGridView1.Rows.Add(fila["Idmarca"], fila["Marca"], fila["Estado"]);
                }
                else if (nombreCategoria.Contains(texto))
                {
                    dataGridView1.Rows.Add(fila["Idmarca"], fila["Marca"], fila["Estado"]);
                }
            }
        }

        private void button1_Click(object sender, System.EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(textBox2.Text))
            {
                MessageBox.Show("Por favor ingrese el nombre de la nueva categoria");
                return;
            }
            try
            {
                MessageBox.Show(metodos.InsertarMarca(textBox2.Text));
                textBox2.Text = "";
                textBox2.Focus();
            }
            catch
            {
                MessageBox.Show("Error al contactar con la Base de Datos");
            }
            Cargarmarcas();
        }

        private void FrmCargarMarcas_Load(object sender, System.EventArgs e)
        {
            Cargarmarcas();
            dataGridView1.Columns["ID"].ReadOnly = true;
            dataGridView1.Columns["CATEGORIA"].ReadOnly = true;
            dataGridView1.Columns["ESTADO"].ReadOnly = false;
        }
    }
}

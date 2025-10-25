using System;
using System.Windows.Forms;
using ProyectoPracticas;
using static ProyectoPracticas.UI_Utilidad;

namespace CapaVista
{
    public partial class FrmRemito : Form
    {
        string Cuit;
        string razonSocial;
        public FrmRemito(string cuit, string razonSocial)
        {
            InitializeComponent();
            this.Cuit = cuit;
            this.razonSocial = razonSocial;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (CV_Utiles.TextboxVacios(textBox1, textBox2, textBox4, textBox5))
            {
                MessageBox.Show("Por favor complete todos los campos");
                return;
            }
            this.Hide();
        }
        public string PuestoNumero
        {
            get { return textBox1.Text; }
        }
        public string NumeroRemito
        {
            get { return textBox2.Text; }
        }
        public string cuit
        {
            get { return textBox4.Text; }
        }
        public string RazonSocial
        {
            get { return textBox5.Text; }
        }
        public void Limpiar()
        {
            CV_Utiles.LimpiarControles(this);
        }

        private void FrmRemito_Load(object sender, EventArgs e)
        {
            textBox4.Text = Cuit;
            textBox5.Text = razonSocial;
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void FrmRemito_Shown(object sender, EventArgs e)
        {
            this.Text = "Papelera";
            FormDragHelper.EnableDrag(this, panel1);

            UI_Utilidad.EstiloForm(this);
            UI_Utilidad.RedondearForm(this, 28);

            UI_Utilidad.EstiloBotonPrimarioDegradado(btnAceptar);
            UI_Utilidad.EstiloBotonPrimarioDegradado(btnAtras);
        }
    }
}

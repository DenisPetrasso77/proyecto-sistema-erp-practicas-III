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

namespace CapaVista
{
    public partial class FrmRecupero : Form
    {
        CL_Metodos metodos = new CL_Metodos();
        public FrmRecupero()
        {
            InitializeComponent();
        }
        private void ValidarDatos()
        { 
            if (CV_Utiles.TextboxVacios(txtDato))
            {
                MessageBox.Show("Por favor complete los datos de ingreso");
                return;
            }
            if (CV_Utiles.CamposNumericos(txtDato))
            {
                MessageBox.Show("Los datos no pueden ser numericos");
                return;
            }
            DataTable dt = metodos.TraerPregunta(txtDato.Text);
            if (dt.Rows.Count > 0)
            {
                textBox1.Text = dt.Rows[0]["Pregunta"].ToString();
                txtDato.Enabled = true;
                button1.Enabled = true;
                label2.Visible = true;
                textBox1.Visible = true;
                button2.Visible = true;
            }
            else
            {
                MessageBox.Show("Verifique el dato ingresado");
                return;
            }
        }
    }
}

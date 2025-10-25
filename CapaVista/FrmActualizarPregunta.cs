using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using CapaEntities;
using CapaLogica;
using ProyectoPracticas;
using static ProyectoPracticas.UI_Utilidad;

namespace CapaVista
{
    public partial class FrmActualizarPregunta : Form
    {
        CL_Metodos metodos = new CL_Metodos();
        public FrmActualizarPregunta()
        {
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        private void CargarPreguntas()
        { 
            DataTable dt = metodos.SeleccionarPreguntas();
            foreach (DataRow row in dt.Rows)
            {
                string dato = $"{row["IdPregunta"].ToString()} - {row["Pregunta"].ToString()}";
                comboBox1.Items.Add(dato);
            }
        }

        private void FrmActualizarPregunta_Load(object sender, EventArgs e)
        {
            CargarPreguntas();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (CV_Utiles.ComboboxVacios(comboBox1) || CV_Utiles.TextboxVacios(textBox1,textBox2))
            {
                MessageBox.Show("Por favor, complete todos los campos.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (CV_Utiles.CamposNumericos(textBox1,textBox2))
            {
                MessageBox.Show("La respuesta no puede ser numérica.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (textBox1.Text != textBox2.Text)
            {
                MessageBox.Show("Las respuestas no coinciden.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            try
            {
                int idPregunta = Convert.ToInt32(comboBox1.SelectedItem.ToString().Split('-')[0].Trim());
                string respuesta = CV_Seguridad.HashearSHA256(textBox1.Text.Trim());
                string mensaje = metodos.ActualizarPregunta(idPregunta, respuesta);
                MessageBox.Show(mensaje, "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.Close();
            }
            catch (Exception)
            {
                MessageBox.Show("Error al Actualizar los Datos.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            
        }

        private void FrmActualizarPregunta_Shown(object sender, EventArgs e)
        {
            this.ActiveControl = null;
            this.Text = "Papelera";


            UI_Utilidad.EstiloLabels(this);

            UI_Utilidad.EstiloForm(this);
            UI_Utilidad.RedondearForm(this, 28);

            UI_Utilidad.EstiloBotonPrimarioDegradado(btnActualizar);
            UI_Utilidad.EstiloBotonPrimarioDegradado(btnAtras);

            FormDragHelper.EnableDrag(this, panel1);
        }
    }
}

using System;
using System.Security.Cryptography;
using System.Text;
using System.Text.RegularExpressions;
using System.Windows.Forms;

namespace CapaVista
{
    public class CV_Utiles
    {
        public static bool TextboxVacios(params TextBox[] campos)
        {
            foreach (TextBox campo in campos)
            {
                if (string.IsNullOrWhiteSpace(campo.Text))
                {
                    return true;
                }
            }
            return false;
        }
        
        public static bool ComboboxVacios(params ComboBox[] campos)
        {
            foreach (ComboBox campo in campos)
            {
                if (string.IsNullOrWhiteSpace(campo.Text))
                {
                    return true;
                }
            }
            return false;
        }
        public static bool CamposNumericos(params TextBox[] campos)
        {
            foreach (TextBox campo in campos)
            {
                if (int.TryParse(campo.Text, out _))
                {
                    return true;
                }
            }
            return false;
        }
        public static bool CampoMail(string dato)
        {
            string patron = "^[^@\\s]+@[^@\\s]+\\.[^@\\s]+$";

            if (Regex.IsMatch(dato, patron))
            {
                return true;
            }
            return false;
        }
        public static void LimpiarControles(Control control)
        {
            foreach (Control c in control.Controls)
            {
                if (c is TextBox)
                {
                    ((TextBox)c).Clear();
                }
                else if (c is ComboBox)
                {
                    ((ComboBox)c).SelectedIndex = -1;
                }
                else if (c is CheckBox)
                {
                    ((CheckBox)c).Checked = false;
                }
                if (c.HasChildren)
                {
                    LimpiarControles(c);
                }
            }
        }
        public static void LimpiarFormulario(Control control)
        {
            foreach (Control c in control.Controls)
            {
                if (c is TextBox txt)
                {
                    txt.Clear();
                }
                else if (c is ComboBox combo)
                {
                    combo.SelectedIndex = -1;
                }
                else if (c is CheckBox chk)
                {
                    chk.Checked = false;
                }
                else if (c is RadioButton rdo)
                {
                    rdo.Checked = false;
                }
                else if (c is DateTimePicker dtp)
                {
                    dtp.Value = DateTime.Now;
                }
                else if (c is NumericUpDown nud)
                {
                    nud.Value = nud.Minimum;
                }
                else if (c is DataGridView dgv)
                {
                    dgv.DataSource = null;
                    dgv.Rows.Clear();
                }
                if (c.HasChildren)
                {
                    LimpiarFormulario(c);
                }
            }
        }
        public static int Num_aleatorio()
        {
            Random random = new Random();
            return random.Next(1000, 10000);
        }
    }
}

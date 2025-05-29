using System;
using System.Text.RegularExpressions;
using System.Windows.Forms;

namespace CapaVista
{
    public class CV_Utiles
    {
        private bool validado = false;
        public bool TextboxVacios(params TextBox[] campos)
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
        public bool ComboboxVacios(params ComboBox[] campos)
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
        public bool CamposNumericos(params TextBox[] campos)
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
        public bool CampoMail(string dato)
        {
            string patron = "^[^@\\s]+@[^@\\s]+\\.[^@\\s]+$";

            if (Regex.IsMatch(dato, patron))
            {
                return true;
            }
            return false;
        }
        public void LimpiarControles(Control control)
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


        public int Num_aleatorio()
        {
            Random random = new Random();
            return random.Next(1000, 10000);
        }

        public void ValorValidado(bool valor)
        {
            validado = valor;
        }
        public bool Validado()
        {
            return validado;
        }


    }

}

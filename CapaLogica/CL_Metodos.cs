using CapaDatos;
using System;
using System.Data;

namespace CapaLogica
{
    public class CL_Metodos
    {
        CD_Metodos metodos = new CD_Metodos();

        #region METODOS
        public string DatosIngreso(string Usuario)
        {
            return metodos.DatosIngreso(Usuario);
        }
        public int InsertarCate(string nombre)
        {
            return metodos.InsertarCate(nombre);
        }

        public int InsertarProductos(string codigo, string descripcion, int cate, int stock, int cantminima, decimal preciobulto, decimal preciounidad, decimal preciox10, decimal preciox25, decimal preciox50, decimal preciox100)
        {
            return metodos.InsertarProductos(codigo,descripcion,cate, stock, cantminima, preciobulto, preciounidad, preciox10, preciox25, preciox50, preciox100);
        }

        public DataTable MostrarTodo(string Tabla)
        {
            return metodos.MostrarTodo(Tabla);
        }
        #endregion
    }
}

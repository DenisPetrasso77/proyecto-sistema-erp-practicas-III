using CapaDatos;
using Entities;
using System;
using System.Data;

namespace CapaLogica
{
    public class CL_Metodos
    {
        CD_Metodos metodos = new CD_Metodos();

        #region METODOS
        public Usuarioactual DatosIngreso(string Usuario)
        {
            return metodos.DatosIngreso(Usuario);
        }
        public int Bitacora(string descripcion, DateTime fecha)
        { 
            return metodos.Bitacora(descripcion, fecha);
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
        public int Registro(string usuario, string clave, string nombre, string apellido, string dni, int autorizante)
        {
            return metodos.Registro(usuario,clave,nombre, apellido,dni,autorizante);
        }

        public int StatusBloq(string Usuario)
        { 
            return metodos.StatusBloq(Usuario);
        }
        public int InsertarVentas(decimal total)
        {
            return metodos.InsertarVentas(total);
        }
        public int BorrarUsuario(string usuario)
        {
            return metodos.BorrarUsuario(usuario);
        }
        #endregion
    }
}

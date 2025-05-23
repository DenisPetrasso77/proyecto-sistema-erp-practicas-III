using CapaDatos;
using Entities;
using System;
using System.Collections.Generic;
using System.Data;

namespace CapaLogica
{
    public class CL_Metodos
    {
        CD_Metodos metodos = new CD_Metodos();

        #region METODOS
        //public Usuarioactual DatosIngreso(string Usuario)
        //{
        //    return metodos.DatosIngreso(Usuario);
        //}

        public int ActualizarUsuario(string usuario, string nombre, string apellido, string dni, int rol, int bloqueado)
        {
            return metodos.ActualizarUsuario(usuario, nombre, apellido, dni, rol, bloqueado);
        }
        public int Bitacora(string descripcion, DateTime fecha)
        { 
            return metodos.Bitacora(descripcion, fecha);
        }
        public int InsertarCate(string nombre)
        {
            return metodos.InsertarCate(nombre);
        }

        public string InsertarProducto(string codigo, string descripcion, string cate, int stockmin, int stockmax, string unidadcarga, int cantunicarga, int cantporunicarga, int vendeporunidades, int vendeporkilo, int vendeporpack, decimal precioporunidad, decimal precioporkilo, decimal precioporpack, int usuarioalta, string usuarioreferencia, List<(int cantidadMinima, int porcentaje)> descuentos)
        {
            return metodos.InsertarProducto(codigo, descripcion,cate, stockmin, stockmax, unidadcarga, cantunicarga, cantporunicarga, vendeporunidades, vendeporkilo, vendeporpack, precioporunidad, precioporkilo, precioporpack, usuarioalta,usuarioreferencia,descuentos);
        }

        public DataTable MostrarTodo(string Tabla)
        {
            return metodos.MostrarTodo(Tabla);
        }
        public string Registro(string usuario, string clave, string nombre, string apellido)
        {
            return metodos.Registro(usuario,clave,nombre, apellido);
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

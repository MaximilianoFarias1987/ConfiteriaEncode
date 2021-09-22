using DAL;
using Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    public class BLLUsuario
    {
        //INSERTAR
        public static bool InsertarUsuario(Usuario u)
        {
            return DALUsuario.InsertarUsuario(u);
        }


        //Actualizar
        public static bool ActualizarUsuario(Usuario u)
        {
            return DALUsuario.ActualizarUsuario(u);
        }


        //OBTENER USUARIOS
        public static bool EliminarUsuario(Usuario u)
        {
            return DALUsuario.EliminarUsuario(u);
        }


        //OBTENER USUARIO ID
        public static Usuario ObtenerUsuarioID(Usuario u)
        {
            return DALUsuario.ObtenerUsuarioID(u);
        }


        //OBTENER USAURIOS
        public static List<Usuario> ObtenerUsuarios()
        {
            return DALUsuario.ObtenerUsuarios();
        }


        //VALIDAR NOMBRE USUARIO
        public static bool ValidarUsuarioUnico(string nombreUsuario, int tipoDoc, string numDoc)
        {
            return DALUsuario.ValidarUsuarioUnico(nombreUsuario,tipoDoc,numDoc);
        }
    }
}

using DAL;
using Entidades;
using Entidades.DTOs;
using System;
using System.Collections.Generic;
using System.Data;
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
        public static bool EliminarUsuario(int id)
        {
            return DALUsuario.EliminarUsuario(id);
        }


        //OBTENER USUARIO ID
        public static Usuario ObtenerUsuarioID(Usuario u)
        {
            return DALUsuario.ObtenerUsuarioID(u);
        }


        //OBTENER USAURIOS
        public static List<UsuariosDTO> ObtenerUsuarios()
        {
            return DALUsuario.ObtenerUsuarios();
        }

        
        //VALIDAR NOMBRE USUARIO
        public static bool ValidarUsuarioUnico(string nombreUsuario, int tipoDoc, string numDoc)
        {
            return DALUsuario.ValidarUsuarioUnico(nombreUsuario,tipoDoc,numDoc);
        }


        //OBTENER TIPO DOCUMENTO CON DATATABLE
        public static DataTable ObtenerTipoDocumento()
        {
            return DALUsuario.ObtenerTipoDocumento();
        }


        //OBTENER ROLES CON DATATABLE
        public static DataTable ObtenerRoles()
        {
            return DALUsuario.ObtenerRoles();
        }

        public static Usuario UsuarioSesion(string usuario, string pass)
        {
            return DALUsuario.UsuarioSesion(usuario, pass);
        }
    }
}

using DAL;
using Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    public class BLLArticulo
    {
        //INSERTAR
        public static bool InsertarArticulo(Articulo a)
        {
            return DALArticulo.InsertarArticulo(a);
        }


        //Actualizar
        public static bool ActualizarArticulo(Articulo a)
        {
            return DALArticulo.ActualizarArticulo(a);
        }


        //ELIMINAR ARTICULO
        public static bool EliminarArticulo(Articulo a)
        {
            return DALArticulo.EliminarArticulo(a);
        }


        //OBTENER Articulo ID

        public static Articulo ObtenerArticuloID(Articulo a)
        {
            return DALArticulo.ObtenerArticuloID(a);
        }


        //OBTENER Articulos
        public static List<Articulo> ObtenerArticulo()
        {
            return DALArticulo.ObtenerArticulos();
        }


        //VALIDAR Articulo

        public static bool ValidarArticuloUnico(string descripcion, int idRubro)
        {
            return DALArticulo.ValidarArticuloUnico(descripcion,idRubro);
        }
    }
}

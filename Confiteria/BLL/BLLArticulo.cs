using DAL;
using Entidades;
using System;
using System.Collections.Generic;
using System.Data;
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
        public static bool EliminarArticulo(int id)
        {
            return DALArticulo.EliminarArticulo(id);
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


        public static DataTable ObtenerRubro()
        {
            return DALArticulo.ObtenerRubro();
        }
    }
}

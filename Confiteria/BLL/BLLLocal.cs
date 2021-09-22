using DAL;
using Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    public class BLLLocal
    {
        //INSERTAR
        public static bool InsertarLocal(Local l)
        {
            return DALLocal.InsertarLocal(l);
        }


        //Actualizar
        public static bool ActualizarLocal(Local l)
        {
            return DALLocal.ActualizarLocal(l);
        }


        //ELIMINAR LOCAL
        public static bool EliminarLocal(Local l)
        {
            return DALLocal.EliminarLocal(l);
        }


        //OBTENER Articulo ID

        public static Local ObtenerLocalID(Local l)
        {
            return DALLocal.ObtenerLocalID(l);
        }


        //OBTENER Articulos
        public static List<Local> ObtenerLocales()
        {
            return DALLocal.ObtenerLocales();
        }


        //VALIDAR Articulo

        public static bool ValidarLocalUnico(string cuit, string direccion)
        {
            return DALLocal.ValidarLocalUnico(cuit, direccion);
        }
    }
}

using DAL;
using Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    public class BLLMozo
    {
        //INSERTAR
        public static bool InsertarMozo(Mozo m)
        {
            return DALMozo.InsertarMozo(m);
        }


        //Actualizar
        public static bool ActualizarMozo(Mozo m)
        {
            return DALMozo.ActualizarMozo(m);
        }


        //ELIMINAR MOZO
        public static bool EliminarMozo(int id)
        {
            return DALMozo.EliminarMozo(id);
        }


        //OBTENER MOZO ID

        public static Mozo ObtenerMozoID(Mozo m)
        {
            return DALMozo.ObtenerMozoID(m);
        }


        //OBTENER MOZO
        public static List<Mozo> ObtenerMozos()
        {
            return DALMozo.ObtenerMozos();
        }


        //VALIDAR MOZO

        public static bool ValidarMozoUnico(string email, int tipoDoc, string numDoc)
        {
            return DALMozo.ValidarMozoUnico(email, tipoDoc, numDoc);
        }
    }
}

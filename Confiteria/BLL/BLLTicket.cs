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
    public class BLLTicket
    {
        public static DataTable ObtenerArticulos()
        {
            return DALTicket.ObtenerArticulos();
        }

        public static DataTable ObtenerMozos()
        {
            return DALTicket.ObtenerMozos();
        }

        public static DataTable ObtenerFormasPago()
        {
            return DALTicket.ObtenerFormasPago();
        }

        public static int InsertarTicket(Ticket t)
        {
            return DALTicket.InsertarTicket(t);
        }


        public static bool InsertarDetalleTicket(TicketDetalle td)
        {
            return DALTicket.InsertarDetalleTicket(td);
        }
    }
}

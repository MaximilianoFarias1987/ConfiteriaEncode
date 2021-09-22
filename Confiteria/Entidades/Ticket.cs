using System;

namespace Entidades
{
    public class Ticket
    {
        public int IdTicket { get; set; }
        public int idLocal { get; set; }
        public int IdUsuario { get; set; }
        public int IdMozo { get; set; }
        public int IdFormaPago { get; set; }
        public DateTime Fecha { get; set; }
    }
}

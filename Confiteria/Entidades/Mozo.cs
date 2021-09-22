using System;

namespace Entidades
{
    public class Mozo : Persona
    {
        public string Email { get; set; }
        public string Telefono { get; set; }
        public string Direccion { get; set; }
        public double PorComision { get; set; }
        public DateTime FechaIngreso { get; set; }
    }
}

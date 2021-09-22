using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class Local
    {
        public int IdLocal { get; set; }
        public string RazonSocial { get; set; }
        public string Direccion { get; set; }
        public string Cuit { get; set; }
        public int IdTipoIva { get; set; }
        public double IngBruto { get; set; }
    }
}

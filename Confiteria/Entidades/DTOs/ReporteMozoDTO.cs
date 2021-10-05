using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades.DTOs
{
    public class ReporteMozoDTO
    {
        public string Mozo { get; set; }
        public int CantidadArt { get; set; }
        public double ImpTotal { get; set; }
        public double Comision { get; set; }
        public double Apagar { get; set; }
    }
}

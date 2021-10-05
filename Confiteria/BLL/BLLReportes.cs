using DAL;
using Entidades.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    public class BLLReportes
    {
        public static List<ReporteArticuloDTO> ObtenerReporteArticulo(DateTime fecha)
        {
            return DALReportes.ObtenerReporteArticulo(fecha);
        }

        public static List<ReporteMozoDTO> ObtenerReporteMozo(DateTime fecha)
        {
            return DALReportes.ObtenerReporteMozo(fecha);
        }
    }
}

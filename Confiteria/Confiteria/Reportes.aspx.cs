using BLL;
using Entidades.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Confiteria
{
    public partial class Reportes : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                lblFecha.Text = DateTime.Now.ToString("dd/MM/yyyy");
            }
        }

        protected void btnReporteArticulo_Click(object sender, EventArgs e)
        {
            DateTime fecha = DateTime.Parse(InputFecha.Value);
            List<ReporteArticuloDTO> lst = BLLReportes.ObtenerReporteArticulo(fecha);

            if (lst != null)
            {
                gvVentsArticulo.DataSource = lst;
                gvVentsArticulo.DataBind();
            }
        }

        protected void btnReporteMozo_Click(object sender, EventArgs e)
        {
            DateTime fecha = DateTime.Parse(InputFecha.Value);
            List<ReporteMozoDTO> lst = BLLReportes.ObtenerReporteMozo(fecha);

            if (lst != null)
            {
                gvVentasMozo.DataSource = lst;
                gvVentasMozo.DataBind();
            }
        }
    }
}
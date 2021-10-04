using Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Confiteria
{
    public partial class Index : System.Web.UI.MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                
                Usuario usuario = (Usuario)Session["Login"];
                if (usuario == null)
                {
                    Response.Redirect("Login.aspx");
                }
                lblUsuarioSesion.Text = "Hola " + usuario.NombreUsuario + "!";
                lblFecha.Text = DateTime.Now.ToString();
                

                if (usuario.IdRol == 2)
                {
                    lnkUsuario.Visible = false;
                    lnkLocal.Visible = false;
                    lnkMozos.Visible = false;
                }
            }
        }

        //protected void btnSalir_Click(object sender, EventArgs e)
        //{
        //    Session.Remove("Login");
        //    Response.Redirect("Login.aspx");
        //}

        protected void lnkSalir_Click(object sender, EventArgs e)
        {
            Session.Remove("Login");
            Response.Redirect("Login.aspx");
        }
    }
}
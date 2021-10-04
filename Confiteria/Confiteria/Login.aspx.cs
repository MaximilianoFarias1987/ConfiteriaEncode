using BLL;
using DAL.ConexionDB;
using Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Confiteria
{
    public partial class Login : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnIniciarSesion_Click(object sender, EventArgs e)
        {
            //string pass = EncryptKeys.EncriptarPassword(txtPassword.Text, "keys");
            Usuario usuario = BLLUsuario.UsuarioSesion(txtNombreUsuario.Text, txtPassword.Text);
            

            if (usuario != null)
            {
                //string pass = EncryptKeys.DesencriptarPassword(usuario.Password, "keys");
                //if (pass == txtPassword.Text)
                //{
                    Session["Login"] = usuario;
                    Response.Redirect("Home.aspx");
                //}
                
            }
            else
            {
                Page.ClientScript.RegisterStartupScript(this.GetType(), "MyFunction", "MensajeErrorUsuario();", true);
            }
        }
    }
}
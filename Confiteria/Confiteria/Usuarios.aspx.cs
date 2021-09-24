using BLL;
using Entidades;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Services;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Confiteria
{
    public partial class Usuarios : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        //public void CargarComboTipoDoc()
        //{
        //    ListItem i;
        //    List<TipoDocumento> lst = BLLUsuario.ObtenerTipoDoc();
        //    foreach (var x in lst)
        //    {
        //        cboTipoDoc.Items.Add(i);
        //    }
        //}

        //WEBMETHOD

        [WebMethod]
        public static List<Usuario> listaUsuarios()
        {
            List<Usuario> lst = BLLUsuario.ObtenerUsuarios();

            return lst;
        }

        public bool insertarUsuario(string nombre, string apellido, int tipoDoc, string documento,string user,string pass, int rol)
        {
            if (BLLUsuario.ValidarUsuarioUnico(user,tipoDoc,documento))
            {
                Page.ClientScript.RegisterStartupScript(this.GetType(), "MyFunction", "MensajeErrorValidacion();", true);
                return false;
            }
            else
            {
                Usuario u = new Usuario
                {
                    Nombre = nombre,
                    Apellido = apellido,
                    IdTipoDoc = tipoDoc,
                    NumeroDoc = documento,
                    NombreUsuario = user,
                    Password = pass,
                    IdRol = rol
                };
                return BLLUsuario.InsertarUsuario(u);
            }
        }

        protected void btnRegistrar_Click(object sender, EventArgs e)
        {
            if (insertarUsuario(txtNombre.Text,txtApellido.Text,Convert.ToInt32(cboTipoDoc.Text), txtNumDocumento.Text,txtNombreUsuario.Text,txtPassword.Text, Convert.ToInt32(cboRol.Text)))
            {
                Page.ClientScript.RegisterStartupScript(this.GetType(), "MyFunction", "MensajeSuccess();", true);
                txtNombre.Text = string.Empty;
                txtApellido.Text = string.Empty;
                cboTipoDoc.SelectedIndex = 0;
                cboRol.SelectedIndex = 0;
                txtNumDocumento.Text = string.Empty;
                txtNombreUsuario.Text = string.Empty;
                txtPassword.Text = string.Empty;
            }
            else
            {
                Page.ClientScript.RegisterStartupScript(this.GetType(), "MyFunction", "MensajeError();", true);
            }
        }
    }
}
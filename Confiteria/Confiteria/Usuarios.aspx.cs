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
            if (!IsPostBack)
            {
                CargarComboTipoDoc();
                CargarComboRoles();
                CargarComboTipoDocActualizar();
                CargarComboRolesAct();
            }
        }

        public void CargarComboTipoDoc()
        {
            DataTable table = BLLUsuario.ObtenerTipoDocumento();
            cboTipoDoc.DataSource = table;
            cboTipoDoc.DataTextField = table.Columns[1].ColumnName;
            cboTipoDoc.DataValueField = table.Columns[0].ColumnName;
            cboTipoDoc.DataBind();
            cboTipoDoc.Items.Insert(0, new ListItem("Seleccione un tipo de documento..."));
        }

        public void CargarComboTipoDocActualizar()
        {
            DataTable table = BLLUsuario.ObtenerTipoDocumento();
            cboTipoDocAct.DataSource = table;
            cboTipoDocAct.DataTextField = table.Columns[1].ColumnName;
            cboTipoDocAct.DataValueField = table.Columns[0].ColumnName;
            cboTipoDocAct.DataBind();
        }

        public void CargarComboRoles()
        {
            DataTable table = BLLUsuario.ObtenerRoles();
            cboRol.DataSource = table;
            cboRol.DataTextField = table.Columns[1].ColumnName;
            cboRol.DataValueField = table.Columns[0].ColumnName;
            cboRol.DataBind();
            cboRol.Items.Insert(0, new ListItem("Seleccione un Rol de Usuario..."));
        }

        public void CargarComboRolesAct()
        {
            DataTable table = BLLUsuario.ObtenerRoles();
            cboRolAct.DataSource = table;
            cboRolAct.DataTextField = table.Columns[1].ColumnName;
            cboRolAct.DataValueField = table.Columns[0].ColumnName;
            cboRolAct.DataBind();
        }

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



        public bool ActualizarUsuario(int id, string nombre, string apellido, int tipoDoc, string documento, string user, string pass, int rol)
        {
            if (BLLUsuario.ValidarUsuarioUnico(user, tipoDoc, documento))
            {
                Page.ClientScript.RegisterStartupScript(this.GetType(), "MyFunction", "MensajeErrorValidacion();", true);
                return false;
            }
            else
            {
                Usuario u = new Usuario
                {
                    Id = id,
                    Nombre = nombre,
                    Apellido = apellido,
                    IdTipoDoc = tipoDoc,
                    NumeroDoc = documento,
                    NombreUsuario = user,
                    Password = pass,
                    IdRol = rol
                };
                return BLLUsuario.ActualizarUsuario(u);
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

        protected void btnActualizar_Click(object sender, EventArgs e)
        {
            var id = HdIDUsuario.Value;
            if (ActualizarUsuario(Convert.ToInt32(id),txtNombreActualizar.Text, txtApellidoAct.Text, Convert.ToInt32(cboTipoDocAct.Text), txtDocAct.Text, txtNombreUsuarioAct.Text, txtPasswordAct.Text, Convert.ToInt32(cboRolAct.Text)))
            {
                Page.ClientScript.RegisterStartupScript(this.GetType(), "MyFunction", "MensajeActualizrOk();", true);
                txtNombreActualizar.Text = string.Empty;
                txtApellidoAct.Text = string.Empty;
                cboTipoDocAct.SelectedIndex = 0;
                cboRolAct.SelectedIndex = 0;
                txtDocAct.Text = string.Empty;
                txtNombreUsuarioAct.Text = string.Empty;
                txtPasswordAct.Text = string.Empty;
            }
            else
            {
                Page.ClientScript.RegisterStartupScript(this.GetType(), "MyFunction", "MensajeErrorActualizar();", true);
            }
        }

        protected void btnEliminar_Click(object sender, EventArgs e)
        {
            var id = hdIdUsuarioElim.Value;

            if (BLLUsuario.EliminarUsuario(Convert.ToInt32(id)))
            {
                Page.ClientScript.RegisterStartupScript(this.GetType(), "MyFunction", "MensajeEliminarOk();", true);
            }
            else
            {
                Page.ClientScript.RegisterStartupScript(this.GetType(), "MyFunction", "MensajeErrorEliminar();", true);
            }
        }
    }
}
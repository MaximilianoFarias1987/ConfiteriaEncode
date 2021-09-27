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
    public partial class Mozos : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                CargarComboTipoDoc();
                CargarComboTipoDocActualizar();
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


        //WEBMETHOD

        [WebMethod]
        public static List<Mozo> listaMozos()
        {
            List<Mozo> lst = BLLMozo.ObtenerMozos();

            return lst;
        }


        //METODO REGISTRAR
        public bool insertarMozo(string nombre, string apellido, int tipoDoc, string documento, string email, string tel, string direccion, double porCom)
        {
            if (BLLMozo.ValidarMozoUnico(email, tipoDoc, documento))
            {
                Page.ClientScript.RegisterStartupScript(this.GetType(), "MyFunction", "MensajeErrorValidacion();", true);
                return false;
            }
            else
            {
                Mozo m = new Mozo
                {
                    Nombre = nombre,
                    Apellido = apellido,
                    IdTipoDoc = tipoDoc,
                    NumeroDoc = documento,
                    Email = email,
                    Telefono = tel,
                    Direccion = direccion,
                    PorComision = porCom
                };
                return BLLMozo.InsertarMozo(m);
            }
        }


        //METODO ACTUALIZAR
        public bool ActualizarMozo(int id, string nombre, string apellido, int tipoDoc, string documento, string email, string tel, string direccion, double porCom)
        {
            if (BLLMozo.ValidarMozoUnico(email, tipoDoc, documento))
            {
                Page.ClientScript.RegisterStartupScript(this.GetType(), "MyFunction", "MensajeErrorValidacion();", true);
                return false;
            }
            else
            {
                Mozo m = new Mozo
                {
                    Id = id,
                    Nombre = nombre,
                    Apellido = apellido,
                    IdTipoDoc = tipoDoc,
                    NumeroDoc = documento,
                    Email = email,
                    Telefono = tel,
                    Direccion = direccion,
                    PorComision = porCom
                };
                return BLLMozo.ActualizarMozo(m);
            }
        }

        protected void btnRegistrar_Click(object sender, EventArgs e)
        {
            if (insertarMozo(txtNombre.Text, txtApellido.Text, Convert.ToInt32(cboTipoDoc.Text), txtNumDocumento.Text, txtEmail.Text, txtTelefono.Text, txtDireccion.Text,Convert.ToDouble(txtComision.Text)))
            {
                
                txtNombre.Text = string.Empty;
                txtApellido.Text = string.Empty;
                cboTipoDoc.SelectedIndex = 0;
                txtNumDocumento.Text = string.Empty;
                txtEmail.Text = string.Empty;
                txtTelefono.Text = string.Empty;
                txtDireccion.Text = string.Empty;
                txtComision.Text = string.Empty;
                //Response.Redirect("Mozos.aspx");
                Page.ClientScript.RegisterStartupScript(this.GetType(), "MyFunction", "MensajeSuccess();", true);
            }
            else
            {
                Page.ClientScript.RegisterStartupScript(this.GetType(), "MyFunction", "MensajeError();", true);
            }
        }

        protected void btnActualizar_Click(object sender, EventArgs e)
        {
            var id = HdIDMozo.Value;
            if (ActualizarMozo(Convert.ToInt32(id), txtNombreAct.Text, txtApellidoAct.Text, Convert.ToInt32(cboTipoDocAct.Text), txtDocumentoAct.Text, txtEmailAct.Text,txtTelefonoAct.Text, txtDireccionAct.Text, Convert.ToDouble(txtComisionAct.Text)))
            {
                Page.ClientScript.RegisterStartupScript(this.GetType(), "MyFunction", "MensajeActualizrOk();", true);
                txtNombreAct.Text = string.Empty;
                txtApellidoAct.Text = string.Empty;
                cboTipoDocAct.SelectedIndex = 0;
                txtDocumentoAct.Text = string.Empty;
                txtEmailAct.Text = string.Empty;
                txtTelefonoAct.Text = string.Empty;
                txtDireccionAct.Text = string.Empty;
                txtComisionAct.Text = string.Empty;
            }
            else
            {
                Page.ClientScript.RegisterStartupScript(this.GetType(), "MyFunction", "MensajeErrorActualizar();", true);
            }
        }

        protected void btnEliminar_Click(object sender, EventArgs e)
        {
            var id = hdIdMozoElim.Value;

            if (BLLMozo.EliminarMozo(Convert.ToInt32(id)))
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
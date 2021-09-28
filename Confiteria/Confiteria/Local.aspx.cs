using BLL;
using System;
using Entidades;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Services;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Confiteria
{
    public partial class Local : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                CargarComboTipoIva();
                CargarComboTipoIvaAct();
            }
        }

        public void CargarComboTipoIva()
        {
            DataTable table = BLLLocal.ObtenerTipoIva();
            cboTipoIva.DataSource = table;
            cboTipoIva.DataTextField = table.Columns[1].ColumnName;
            cboTipoIva.DataValueField = table.Columns[0].ColumnName;
            cboTipoIva.DataBind();
            cboTipoIva.Items.Insert(0, new ListItem("Seleccione un Tipo de IVA..."));
        }

        public void CargarComboTipoIvaAct()
        {
            DataTable table = BLLLocal.ObtenerTipoIva();
            cboTipoIvaAct.DataSource = table;
            cboTipoIvaAct.DataTextField = table.Columns[1].ColumnName;
            cboTipoIvaAct.DataValueField = table.Columns[0].ColumnName;
            cboTipoIvaAct.DataBind();
            cboTipoIvaAct.Items.Insert(0, new ListItem("Seleccione un Tipo de IVA..."));
        }


        //WEBMETHOD

        [WebMethod]
        public static List<Entidades.Local> listaLocales()
        {
            List<Entidades.Local> lst = BLLLocal.ObtenerLocales();

            return lst;
        }


        //METODO REGISTRAR
        public bool insertarLocal(string razSocial, string dire, string cuit, int tipoIva, double ingBruto)
        {
            if (BLLLocal.ValidarLocalUnico(cuit, dire))
            {
                Page.ClientScript.RegisterStartupScript(this.GetType(), "MyFunction", "MensajeErrorValidacion();", true);
                return false;
            }
            else
            {
                Entidades.Local l = new Entidades.Local
                {
                    RazonSocial = razSocial,
                    Direccion = dire,
                    Cuit = cuit,
                    IdTipoIva = tipoIva,
                    IngBruto = ingBruto
                };
                return BLLLocal.InsertarLocal(l);
            }
        }


        //METODO ACTUALIZAR
        public bool ActualizarLocal(int id, string razSocial, string dire, string cuit, int tipoIva, double ingBruto)
        {
            if (BLLLocal.ValidarLocalUnico(cuit, dire))
            {
                Page.ClientScript.RegisterStartupScript(this.GetType(), "MyFunction", "MensajeErrorValidacion();", true);
                return false;
            }
            else
            {
                Entidades.Local l = new Entidades.Local
                {
                    IdLocal = id,
                    RazonSocial = razSocial,
                    Direccion = dire,
                    Cuit = cuit,
                    IdTipoIva = tipoIva,
                    IngBruto = ingBruto
                };
                return BLLLocal.ActualizarLocal(l);
            }
        }
        protected void btnRegistrar_Click(object sender, EventArgs e)
        {
            if (insertarLocal(txtRazonSocial.Text, txtDireccion.Text, txtCuit.Text, Convert.ToInt32(cboTipoIva.Text), Convert.ToDouble(txtIngBrutos.Text)))
            {

                txtRazonSocial.Text = string.Empty;
                txtDireccion.Text = string.Empty;
                cboTipoIva.SelectedIndex = 0;
                txtCuit.Text = string.Empty;
                txtIngBrutos.Text = string.Empty;
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
            var id = HdIDLocal.Value;
            if (ActualizarLocal(Convert.ToInt32(id), txtRazonSocialAct.Text, txtDireccionAct.Text, txtCuitAct.Text, Convert.ToInt32(cboTipoIvaAct.Text), Convert.ToDouble(txtIngBrutoAct.Text)))
            {
                Page.ClientScript.RegisterStartupScript(this.GetType(), "MyFunction", "MensajeActualizrOk();", true);
                txtRazonSocial.Text = string.Empty;
                txtDireccion.Text = string.Empty;
                cboTipoIva.SelectedIndex = 0;
                txtCuit.Text = string.Empty;
                txtIngBrutos.Text = string.Empty;
            }
            else
            {
                Page.ClientScript.RegisterStartupScript(this.GetType(), "MyFunction", "MensajeErrorActualizar();", true);
            }
        }

        protected void btnEliminar_Click(object sender, EventArgs e)
        {
            var id = hdIdLocalElim.Value;

            if (BLLLocal.EliminarLocal(Convert.ToInt32(id)))
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
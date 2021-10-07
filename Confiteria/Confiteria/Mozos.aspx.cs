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
            cboTipoDocAct.Items.Insert(0, new ListItem("Seleccione un tipo de documento..."));
        }


        //WEBMETHOD

        [WebMethod]
        public static List<Mozo> listaMozos()
        {
            List<Mozo> lst = BLLMozo.ObtenerMozos();

            return lst;
        }


        //METODO REGISTRAR
        public bool insertarMozo(string nombre, string apellido, int tipoDoc, string documento, string tel, double porCom)
        {
            if (BLLMozo.ValidarMozoUnico(tipoDoc, documento))
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
                    Telefono = tel,
                    PorComision = porCom
                };
                return BLLMozo.InsertarMozo(m);
            }
        }


        //METODO ACTUALIZAR
        public bool ActualizarMozo(int id, string nombre, string apellido, int tipoDoc, string documento, string tel, double porCom)
        {
            if (BLLMozo.ValidarMozoUnico(tipoDoc, documento))
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
                    Telefono = tel,
                    PorComision = porCom
                };
                return BLLMozo.ActualizarMozo(m);
            }
        }


        private bool ValidacionRegistrar()
        {
            if (txtNombre.Text == string.Empty)
            {
                return false;
            }
            if (txtApellido.Text == string.Empty)
            {
                return false;
            }
            if (cboTipoDoc.SelectedIndex == 0)
            {
                return false;
            }
            if (txtNumDocumento.Text == string.Empty)
            {
                return false;
            }
            if (txtTelefono.Text == string.Empty)
            {
                return false;
            }
            if (txtComision.Text == string.Empty)
            {
                return false;
            }
            return true;
        }



        private bool ValidacionActualizar()
        {
            if (txtNombreAct.Text == string.Empty)
            {
                return false;
            }
            if (txtApellidoAct.Text == string.Empty)
            {
                return false;
            }
            if (cboTipoDocAct.SelectedIndex == 0)
            {
                return false;
            }
            if (txtDocumentoAct.Text == string.Empty)
            {
                return false;
            }
            if (txtTelefonoAct.Text == string.Empty)
            {
                return false;
            }
            if (txtComisionAct.Text == string.Empty)
            {
                return false;
            }
            return true;
        }

        protected void btnRegistrar_Click(object sender, EventArgs e)
        {
            if (ValidacionRegistrar())
            {
                if (insertarMozo(txtNombre.Text, txtApellido.Text, Convert.ToInt32(cboTipoDoc.Text), txtNumDocumento.Text, txtTelefono.Text, Convert.ToDouble(txtComision.Text)))
                {

                    txtNombre.Text = string.Empty;
                    txtApellido.Text = string.Empty;
                    cboTipoDoc.SelectedIndex = 0;
                    txtNumDocumento.Text = string.Empty;
                    txtTelefono.Text = string.Empty;
                    txtComision.Text = string.Empty;
                    //Response.Redirect("Mozos.aspx");
                    Page.ClientScript.RegisterStartupScript(this.GetType(), "MyFunction", "MensajeSuccess();", true);
                }
                else
                {
                    Page.ClientScript.RegisterStartupScript(this.GetType(), "MyFunction", "MensajeError();", true);
                }
            }
            else
            {
                ScriptManager.RegisterClientScriptBlock(this.Page, this.Page.GetType(), "sweetAlert", "validacionRegistro();", true);
            }
            
        }

        protected void btnActualizar_Click(object sender, EventArgs e)
        {
            if (ValidacionActualizar())
            {
                var id = HdIDMozo.Value;
                if (ActualizarMozo(Convert.ToInt32(id), txtNombreAct.Text, txtApellidoAct.Text, Convert.ToInt32(cboTipoDocAct.Text), txtDocumentoAct.Text, txtTelefonoAct.Text, Convert.ToDouble(txtComisionAct.Text)))
                {
                    Page.ClientScript.RegisterStartupScript(this.GetType(), "MyFunction", "MensajeActualizrOk();", true);
                    txtNombreAct.Text = string.Empty;
                    txtApellidoAct.Text = string.Empty;
                    cboTipoDocAct.SelectedIndex = 0;
                    txtDocumentoAct.Text = string.Empty;
                    txtTelefonoAct.Text = string.Empty;
                    txtComisionAct.Text = string.Empty;
                }
                else
                {
                    Page.ClientScript.RegisterStartupScript(this.GetType(), "MyFunction", "MensajeErrorActualizar();", true);
                }
            }
            else
            {
                    ScriptManager.RegisterClientScriptBlock(this.Page, this.Page.GetType(), "sweetAlert", "validacionActualizar();", true);
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
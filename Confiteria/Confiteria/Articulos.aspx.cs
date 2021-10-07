using BLL;
using Entidades;
using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Web;
using System.Web.Services;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Confiteria
{
    public partial class Articulos : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                CargarComboRubro();
                CargarComboRubroAct();
                
            }
        }

        public void CargarComboRubro()
        {
            DataTable table = BLLArticulo.ObtenerRubro();
            cboRubro.DataSource = table;
            cboRubro.DataTextField = table.Columns[1].ColumnName;
            cboRubro.DataValueField = table.Columns[0].ColumnName;
            cboRubro.DataBind();
            cboRubro.Items.Insert(0, new ListItem("Seleccione un Rubro..."));
        }


        public void CargarComboRubroAct()
        {
            DataTable table = BLLArticulo.ObtenerRubro();
            cboRubroAct.DataSource = table;
            cboRubroAct.DataTextField = table.Columns[1].ColumnName;
            cboRubroAct.DataValueField = table.Columns[0].ColumnName;
            cboRubroAct.DataBind();
            cboRubroAct.Items.Insert(0, new ListItem("Seleccione un Rubro..."));
        }


        //WEBMETHOD

        [WebMethod]
        public static List<Articulo> listaArticulos()
        {
            List<Articulo> lst = BLLArticulo.ObtenerArticulo();

            return lst;
        }



        //METODO REGISTRAR
        public bool insertarArticulo(string desc, double prec, int stock, int rubro)
        {
            if (BLLArticulo.ValidarArticuloUnico(desc, rubro))
            {
                Page.ClientScript.RegisterStartupScript(this.GetType(), "MyFunction", "MensajeErrorValidacion();", true);
                return false;
            }
            else
            {
                Articulo a = new Articulo
                {
                    Descripcion = desc,
                    Precio = prec,
                    Stock = stock,
                    IdRubro = rubro
                };
                return BLLArticulo.InsertarArticulo(a);
            }
        }


        //METODO ACTUALIZAR
        public bool ActualizarArticulo(int id, string desc, double prec, int stock, int rubro)
        {
            if (BLLArticulo.ValidarArticuloUnico(desc, rubro))
            {
                Page.ClientScript.RegisterStartupScript(this.GetType(), "MyFunction", "MensajeErrorValidacion();", true);
                return false;
            }
            else
            {
                Articulo a = new Articulo
                {
                    IdArticulo = id,
                    Descripcion = desc,
                    Precio = prec,
                    Stock = stock,
                    IdRubro = rubro
                };
                return BLLArticulo.ActualizarArticulo(a);
            }
        }

        private bool validacion()
        {
            if (txtDescripcion.Text == string.Empty )
            {

                ScriptManager.RegisterClientScriptBlock(this.Page, this.Page.GetType(), "sweetAlert", "MensajeValidacion();", true);
                txtDescripcion.Focus();
                //lblErrorDescripcion.Text = "Debe ingresar un Nombre de Articulo";
                //lblErrorDescripcion.ForeColor = Color.Red;
                //lblErrorDescripcion.Visible = true;
                return false;
            }
            if (txtPrecio.Text == string.Empty)
            {
                ScriptManager.RegisterClientScriptBlock(this.Page, this.Page.GetType(), "sweetAlert", "MensajeValidacion();", true);

                txtPrecio.Focus();
                //lblErrorPrecio.Text = "Debe ingresar un Precio";
                //lblErrorPrecio.ForeColor = Color.Red;
                //lblErrorPrecio.Visible = true;
                return false;
            }
            if (txtStock.Text == string.Empty)
            {
                ScriptManager.RegisterClientScriptBlock(this.Page, this.Page.GetType(), "sweetAlert", "MensajeValidacion();", true);

                txtStock.Focus();
                //lblErrorStock.Text = "Debe ingresar un Stock";
                //lblErrorStock.ForeColor = Color.Red;
                //lblErrorStock.Visible = true;
                return false;
            }
            if (cboRubro.SelectedIndex < 1)
            {
                ScriptManager.RegisterClientScriptBlock(this.Page, this.Page.GetType(), "sweetAlert", "MensajeValidacion();", true);

                cboRubro.Focus();
                //lblErrorRubro.Text = "Debe seleccionar un Rubro";
                //lblErrorRubro.ForeColor = Color.Red;
                //lblErrorRubro.Visible = true;
                return false;
            }
            //lblErrorDescripcion.Visible = false;
            //lblErrorPrecio.Visible = false;
            //lblErrorStock.Visible = false;
            //lblErrorRubro.Visible = false;
            return true;
        }


        private bool validacionActualizar()
        {
            if (txtDescripcionAct.Text == string.Empty)
            {
                ScriptManager.RegisterClientScriptBlock(this.Page, this.Page.GetType(), "sweetAlert", "MensajeValidacion();", true);

                //txtDescripcionAct.Focus();
                return false;
            }
            if (txtPrecioAct.Text == string.Empty)
            {
                ScriptManager.RegisterClientScriptBlock(this.Page, this.Page.GetType(), "sweetAlert", "MensajeValidacion();", true);

                //txtPrecioAct.Focus();
                return false;
            }
            if (txtStockAct.Text == string.Empty)
            {
                ScriptManager.RegisterClientScriptBlock(this.Page, this.Page.GetType(), "sweetAlert", "MensajeValidacion();", true);

                //txtStockAct.Focus();
                return false;
            }
            if (cboRubroAct.SelectedIndex < 1)
            {
                ScriptManager.RegisterClientScriptBlock(this.Page, this.Page.GetType(), "sweetAlert", "MensajeValidacion();", true);

                cboRubroAct.Focus();
                return false;
            }
            return true;
        }


        protected void btnRegistrar_Click(object sender, EventArgs e)
        {
            if (validacion())
            {
                if (insertarArticulo(txtDescripcion.Text, Convert.ToDouble(txtPrecio.Text), Convert.ToInt32(txtStock.Text), Convert.ToInt32(cboRubro.Text)))
                {

                    txtDescripcion.Text = string.Empty;
                    txtPrecio.Text = string.Empty;
                    cboRubro.SelectedIndex = 0;
                    txtStock.Text = string.Empty;
                    //Response.Redirect("Mozos.aspx");
                    //Page.ClientScript.RegisterStartupScript(this.GetType(), "MyFunction", "MensajeSuccess();", true);
                    ScriptManager.RegisterClientScriptBlock(this.Page, this.Page.GetType(), "sweetAlert", "MensajeSuccess();", true);

                }
                else
                {
                    Page.ClientScript.RegisterStartupScript(this.GetType(), "MyFunction", "MensajeError();", true);
                }
            }
            else
            {
                Page.ClientScript.RegisterStartupScript(this.GetType(), "MyFunction", "validacionRegistro();", true);
                
            }

        }

        protected void btnActualizar_Click(object sender, EventArgs e)
        {
            var id = HdIDArticulo.Value;
            if (validacionActualizar())
            {
                if (ActualizarArticulo(Convert.ToInt32(id), txtDescripcionAct.Text, Convert.ToDouble(txtPrecioAct.Text), Convert.ToInt32(txtStockAct.Text), Convert.ToInt32(cboRubroAct.Text)))
                {
                    ScriptManager.RegisterClientScriptBlock(this.Page, this.Page.GetType(), "sweetAlert", "MensajeActualizrOk();", true);
                    //Page.ClientScript.RegisterStartupScript(this.GetType(), "MyFunction", "MensajeActualizrOk();", true);
                    txtDescripcion.Text = string.Empty;
                    txtPrecio.Text = string.Empty;
                    cboRubro.SelectedIndex = 0;
                    txtStock.Text = string.Empty;
                }
                else
                {
                    Page.ClientScript.RegisterStartupScript(this.GetType(), "MyFunction", "MensajeErrorActualizar();", true);
                }
            }
            
        }

        protected void btnEliminar_Click(object sender, EventArgs e)
        {
            var id = hdIdArticuloElim.Value;

            if (BLLArticulo.EliminarArticulo(Convert.ToInt32(id)))
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
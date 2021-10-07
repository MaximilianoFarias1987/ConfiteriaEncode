using BLL;
using Entidades;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Confiteria
{
    public partial class GenerarTicket : System.Web.UI.Page
    {

        double precio;
        
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                CargarComboArticulo();
                CargarComboMozo();
                CargarComboFormaPago();
                
            }
        }

        public void CargarComboArticulo()
        {
            DataTable table = BLLTicket.ObtenerArticulos();
            cboArticulos.DataSource = table;
            cboArticulos.DataTextField = table.Columns[1].ColumnName;
            cboArticulos.DataValueField = table.Columns[0].ColumnName;
            cboArticulos.DataBind();
            cboArticulos.Items.Insert(0, new ListItem("Seleccione un Articulo..."));
        }

        public void CargarComboMozo()
        {
            DataTable table = BLLTicket.ObtenerMozos();
            cboMozo.DataSource = table;
            cboMozo.DataTextField = table.Columns[1].ColumnName;
            cboMozo.DataValueField = table.Columns[0].ColumnName;
            cboMozo.DataBind();
            cboMozo.Items.Insert(0, new ListItem("Seleccione un Mozo..."));
        }

        public void CargarComboFormaPago()
        {
            DataTable table = BLLTicket.ObtenerFormasPago();
            cboFormaPago.DataSource = table;
            cboFormaPago.DataTextField = table.Columns[1].ColumnName;
            cboFormaPago.DataValueField = table.Columns[0].ColumnName;
            cboFormaPago.DataBind();
            cboFormaPago.Items.Insert(0, new ListItem("Seleccione una Forma Pago..."));
        }

        private void CargarTabla()
        {
            DataTable dt;
            if (Session["datos"] == null)
            {
                dt = new DataTable();
                dt.Columns.Add("Codigo Articulo");
                dt.Columns.Add("Cantidad");
                dt.Columns.Add("Precio Unitario");
                dt.Columns.Add("Importe");
            }
            else
            {
                dt = Session["datos"] as DataTable;
            }
        }


        

        private bool ValidarCamposTabla()
        {
            if (txtCantidad.Text == "" || cboArticulos.SelectedIndex == 0)
            {
                Page.ClientScript.RegisterStartupScript(this.GetType(), "MyFunction", "validacionAgregarAlCarro();", true);
                return false;
            }
            else
            {
                return true;
            }
            
        }

        protected void btnCargarTabla_Click(object sender, EventArgs e)
        {
            if (ValidarCamposTabla())
            {
                btnGenerarTicket.Visible = true;

                double total = 0;
                DataTable dt;
                if (Session["datos"] != null)
                {
                    dt = Session["datos"] as DataTable;
                }
                else
                {
                    dt = new DataTable();
                    dt.Columns.Add("Codigo Articulo");
                    dt.Columns.Add("Cantidad");
                    dt.Columns.Add("Precio Unitario");
                    dt.Columns.Add("Importe");
                }
                DataRow row = dt.NewRow();
                double importe = Convert.ToDouble(txtCantidad.Text) * Convert.ToDouble(ViewState["precio"]);
                row["Codigo Articulo"] = cboArticulos.Text;
                row["Cantidad"] = txtCantidad.Text;
                row["Precio Unitario"] = ViewState["precio"];
                row["Importe"] = importe.ToString();
                dt.Rows.Add(row);




                gvCarrito.DataSource = dt;
                gvCarrito.DataBind();
                Session["datos"] = dt;

                //Recorro el gridview para acumular la columna importe
                foreach (GridViewRow x in gvCarrito.Rows)
                {
                    total += Convert.ToDouble(row["Importe"].ToString());
                }

                lblMsjTotal.Text = "Total: ";
                lblMsjTotal.Visible = true;
                lblTotal.Visible = true;
                lblTotal.Text = " $" + total.ToString();
            }
            else
            {
                Page.ClientScript.RegisterStartupScript(this.GetType(), "MyFunction", "validacionAgregarAlCarro();", true);
            }

            



        }

        private bool ValidacionTicket()
        {
            if (cboFormaPago.SelectedIndex == 0 || cboMozo.SelectedIndex == 0)
            {
                return false;
            }
            else
            {
                return true;
            }
        }

        //METODO PARA GENERAR TICKET CON SU DETALLE
        private bool CrearTicket(int idLocal, int idUsuario, int idMozo, int idFormaPago )
        {
            
            try
            {
                
                Ticket t = new Ticket
                {
                    IdLocal = idLocal,
                    IdUsuario = idUsuario,
                    IdMozo = idMozo,
                    IdFormaPago = idFormaPago
                };

                

                int ticketId = BLLTicket.InsertarTicket(t);
                TicketDetalle td = null;
                foreach (GridViewRow x in gvCarrito.Rows)
                {
                    td = new TicketDetalle
                    {
                        IdTicket = ticketId,
                        IdArticulo = Convert.ToInt32(x.Cells[0].Text),
                        Cantidad = Convert.ToInt32(x.Cells[1].Text),
                        PreUnitario = Convert.ToDouble(x.Cells[2].Text)
                    };

                    BLLTicket.InsertarDetalleTicket(td);
                }
                return true;
            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }
            

            
        }


        protected void gvListaDetalle_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        protected void gvListaDetalle_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {

        }

        protected void gvListaDetalle_RowDataBound(object sender, GridViewRowEventArgs e)
        {

        }

        protected void cboArticulos_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cboArticulos.SelectedIndex == 0)
            {
                Page.ClientScript.RegisterStartupScript(this.GetType(), "MyFunction", "MensajeErrorCbo();", true);
            }
            else
            {
                int idArticulo = Convert.ToInt32(cboArticulos.Text);

                precio = BLLArticulo.ObtenerPrecio(idArticulo);
                ViewState["precio"] = precio;

            }

        }

        protected void btnGenerarTicket_Click(object sender, EventArgs e)
        {
            if (ValidacionTicket())
            {
                Usuario usuario = (Usuario)Session["Login"];
                int idLocal = BLLLocal.ObtenerLocalID();
                if (CrearTicket(idLocal, usuario.Id, Convert.ToInt32(cboMozo.Text), Convert.ToInt32(cboFormaPago.Text)))
                {
                    Page.ClientScript.RegisterStartupScript(this.GetType(), "MyFunction", "MensajeTicketSuccess();", true);
                }
                else
                {
                    Page.ClientScript.RegisterStartupScript(this.GetType(), "MyFunction", "MensajeTicketError();", true);
                }
            }
            else
            {
                Page.ClientScript.RegisterStartupScript(this.GetType(), "MyFunction", "validacionGenerarTicket()", true);
            }



        }
    }
}
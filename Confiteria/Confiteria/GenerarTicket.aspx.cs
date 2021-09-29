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

        protected void btnCargarTabla_Click(object sender, EventArgs e)
        {

            double total = Convert.ToDouble(txtCantidad.Text) * Convert.ToDouble(ViewState["precio"]);

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
        }



        //METODO PARA GENERAR TICKET CON SU DETALLE
        private bool CrearTicket(int idLocal, int idUsuario, int idMozo, int idFormaPago )
        {
            //Suscriptor suscriptor = new Suscriptor();
            //suscriptor.Nombre = nombre;
            //suscriptor.Apellido = apellido;
            //suscriptor.Documento = numDoc;
            //suscriptor.TipoDocumento = tipoDoc;
            //suscriptor.Direccion = direccion;
            //suscriptor.Telefono = tel;
            //suscriptor.Email = email;
            //suscriptor.NombreUsuario = user;
            //suscriptor.Contrasena = pass;
            //return BLL.BLLSuscriptor.Insertar(suscriptor);
            //bool resultado = false;
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
                        IdArticulo = Convert.ToInt32(x.Cells[0]),
                        Cantidad = Convert.ToInt32(x.Cells[1]),
                        PreUnitario = Convert.ToDouble(x.Cells[2])
                    };

                    BLLTicket.InsertarDetalleTicket(td);
                }
                return true;
            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }
            

            //if (t != null && td != null )
            //{
            //    resultado = true;
            //}
            //else
            //{
            //    resultado = false;
            //}
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
            if (CrearTicket(1, 3, 1, 1))
            {
                Page.ClientScript.RegisterStartupScript(this.GetType(), "MyFunction", "MensajeTicketSuccess();", true);
            }
            else
            {
                Page.ClientScript.RegisterStartupScript(this.GetType(), "MyFunction", "MensajeTicketError();", true);
            }
            

        }
    }
}
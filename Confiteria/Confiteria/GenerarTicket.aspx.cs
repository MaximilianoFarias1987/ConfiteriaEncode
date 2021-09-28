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
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                CargarComboArticulo();;
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

        protected void btnCargarTabla_Click(object sender, EventArgs e)
        {
            
            int articulo = Convert.ToInt32(cboArticulos.Text);
            //txtPrecio.Text = BLLArticulo.ObtenerPrecio(articulo).ToString();
            int cantidad = Convert.ToInt32(txtCantidad.Text);
            double precio = Convert.ToDouble(txtPrecio.Text);
            List<CarritoCompra> lst = new List<CarritoCompra>();
            var carrito = new CarritoCompra
            {
                Descripcion = articulo.ToString(),
                Cantidad = cantidad,
                Precio = precio
            };
            lst.Add(carrito);
            gvCarrito.DataSource = lst;
            gvCarrito.DataBind();

            cboArticulos.SelectedIndex = 0;
            txtCantidad.Text = string.Empty;
            txtPrecio.Text = string.Empty;
            txtTotal.Text = (cantidad * precio).ToString();
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

            int idArticulo = Convert.ToInt32(cboArticulos.Text);
            txtPrecio.Text = BLLArticulo.ObtenerPrecio(idArticulo).ToString();
            //ViewState["ArticuloId"] = idArticulo;
        }
    }
}
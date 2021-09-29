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
                dt.Columns.Add("Precio");
            }
            else
            {
                dt = Session["datos"] as DataTable;
            }
        }

        protected void btnCargarTabla_Click(object sender, EventArgs e)
        {

            double total = Convert.ToDouble(txtCantidad.Text) * Convert.ToDouble(txtPrecio.Text);
            txtTotal.Text = total.ToString();
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
                dt.Columns.Add("Precio");
            }
            DataRow row = dt.NewRow();
            row["Codigo Articulo"] = cboArticulos.Text;
            row["Cantidad"] = txtCantidad.Text;
            row["Precio"] = txtPrecio.Text;
            dt.Rows.Add(row);

            gvCarrito.DataSource = dt;
            gvCarrito.DataBind();
            Session["datos"] = dt;

            //DataTable dt = new DataTable();
            //DataRow row = dt.NewRow();

            //dt.Columns.Add("Codigo Articulo");
            //dt.Columns.Add("Cantidad");
            //dt.Columns.Add("Precio");

            //row["Codigo Articulo"] = cboArticulos.Text;
            //row["Cantidad"] = txtCantidad.Text;
            //row["Precio"] = txtPrecio.Text;

            //dt.Rows.Add(row);

            //gvCarrito.DataSource = dt;
            //gvCarrito.DataBind();
            //Session["datos"] = dt;

            //List<CarritoCompra> lst = new List<CarritoCompra>();
            //int articulo = Convert.ToInt32(cboArticulos.Text);
            ////txtPrecio.Text = BLLArticulo.ObtenerPrecio(articulo).ToString();
            //int cantidad = Convert.ToInt32(txtCantidad.Text);
            //double precio = Convert.ToDouble(txtPrecio.Text);

            //var carrito = new CarritoCompra
            //{
            //    Descripcion = articulo.ToString(),
            //    Cantidad = cantidad,
            //    Precio = precio
            //};
            //lst.Add(carrito);

            //gvCarrito.DataSource = lst;
            //gvCarrito.DataBind();

            //cboArticulos.SelectedIndex = 0;
            //txtCantidad.Text = string.Empty;
            //txtPrecio.Text = string.Empty;
            //txtTotal.Text = (cantidad * precio).ToString();



            //DataTable dt = new DataTable();
            //DataRow row = dt.NewRow();
            //row["Column0"] = cboArticulos.Text;
            //row["Column1"] = txtCantidad.Text;
            //row["Column2"] = txtPrecio.Text;
            //dt.Rows.Add(row);
            //gvCarrito.DataSource = dt;
            //gvCarrito.DataBind();
            //Session["datos"] = dt;
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
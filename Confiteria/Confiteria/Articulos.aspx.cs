﻿using BLL;
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


        protected void btnRegistrar_Click(object sender, EventArgs e)
        {
            if (insertarArticulo(txtDescripcion.Text,Convert.ToDouble(txtPrecio.Text), Convert.ToInt32(txtStock.Text), Convert.ToInt32(cboRubro.Text)))
            {

                txtDescripcion.Text = string.Empty;
                txtPrecio.Text = string.Empty;
                cboRubro.SelectedIndex = 0;
                txtStock.Text = string.Empty;
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
            var id = HdIDArticulo.Value;
            if (ActualizarArticulo(Convert.ToInt32(id), txtDescripcionAct.Text, Convert.ToDouble(txtPrecioAct.Text), Convert.ToInt32(txtStockAct.Text), Convert.ToInt32(cboRubroAct.Text)))
            {
                Page.ClientScript.RegisterStartupScript(this.GetType(), "MyFunction", "MensajeActualizrOk();", true);
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
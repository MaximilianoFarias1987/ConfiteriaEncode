using DAL.ConexionDB;
using Entidades.DTOs;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class DALReportes
    {
        //METODO CARGAR OBJETO REPORTE ARTICULO
        public static ReporteArticuloDTO CrearObjeto(SqlDataReader dr)
        {
            var x = new ReporteArticuloDTO();
            if (dr["Articulo"].ToString() != null)
            {
                x.CodArticulo = (int)dr["Articulo"];
            }
            if (dr["Descripcion"].ToString() != null)
            {
                x.Descripcion = dr["Descripcion"].ToString();
            }
            if (dr["Cantidad"].ToString() != null)
            {
                x.Cantidad = (int)dr["Cantidad"];
            }
            if (dr["Importe"].ToString() != null)
            {
                x.Importe = (double)dr["Importe"];
            }
            
            return x;
        }

        //OBTENER Reporte Articulo
        public static List<ReporteArticuloDTO> ObtenerReporteArticulo(DateTime fecha)
        {

            SqlConnection con = new SqlConnection();
            SqlCommand cmd = new SqlCommand();
            List<ReporteArticuloDTO> lst = new List<ReporteArticuloDTO>();
            ReporteArticuloDTO a = null;
            try
            {
                string nombreSP = "sp_ArticuloporFecha";
                con.ConnectionString = Conexion.ObtenerConexion();
                con.Open();
                cmd.Connection = con;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = nombreSP;
                cmd.Parameters.AddWithValue("@fecha", fecha);
                SqlDataReader dr = cmd.ExecuteReader();
                lst.Clear();

                while (dr.Read())
                {
                    a = CrearObjeto(dr);
                    lst.Add(a);
                }
                con.Close();
                return lst;

            }
            catch (Exception)
            {
                //Conexion.BeginTransaction();
                throw new Exception("Ha ocurrido un error");
            }
            finally
            {
                con.Close();
            }
        }



        //METODO CARGAR OBJETO REPORTE MOZO
        public static ReporteMozoDTO CrearObjetoRepMozo(SqlDataReader dr)
        {
            var x = new ReporteMozoDTO();
            if (dr["Mozo"].ToString() != null)
            {
                x.Mozo = dr["Mozo"].ToString();
            }
            if (dr["Cantidad_Articulos"].ToString() != null)
            {
                x.CantidadArt = (int)dr["Cantidad_Articulos"];
            }
            if (dr["Importe_Total"].ToString() != null)
            {
                x.ImpTotal = (double)dr["Importe_Total"];
            }
            if (dr["Comision"].ToString() != null)
            {
                x.Comision = (double)dr["Comision"];
            }
            if (dr["A_Pagar"].ToString() != null)
            {
                x.Apagar = (double)dr["A_Pagar"];
            }

            return x;
        }


        //OBTENER Reporte Mozo
        public static List<ReporteMozoDTO> ObtenerReporteMozo(DateTime fecha)
        {

            SqlConnection con = new SqlConnection();
            SqlCommand cmd = new SqlCommand();
            List<ReporteMozoDTO> lst = new List<ReporteMozoDTO>();
            ReporteMozoDTO a = null;
            try
            {
                string nombreSP = "sp_VentaPorMozo";
                con.ConnectionString = Conexion.ObtenerConexion();
                con.Open();
                cmd.Connection = con;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = nombreSP;
                cmd.Parameters.AddWithValue("@fecha", fecha);
                SqlDataReader dr = cmd.ExecuteReader();
                lst.Clear();

                while (dr.Read())
                {
                    a = CrearObjetoRepMozo(dr);
                    lst.Add(a);
                }
                con.Close();
                return lst;

            }
            catch (SqlException e)
            {
                //Conexion.BeginTransaction();
                throw new Exception(e.Message);
            }
            finally
            {
                con.Close();
            }
        }
    }
}

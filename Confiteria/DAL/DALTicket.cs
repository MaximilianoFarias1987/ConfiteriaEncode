using DAL.ConexionDB;
using Entidades;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class DALTicket
    {



        //OBTENER TIPOS DE IVA PARA CARGAR COMBO
        public static DataTable ObtenerArticulos()
        {

            SqlConnection con = new SqlConnection();
            SqlCommand cmd = new SqlCommand();
            DataTable tabla = new DataTable();
            try
            {
                string query = "select * from Articulos";
                con.ConnectionString = Conexion.ObtenerConexion();
                cmd.Connection = con;
                cmd.CommandText = query;
                con.Open();
                tabla.Load(cmd.ExecuteReader());
                return tabla;

            }
            catch (Exception e)
            {
                //Conexion.BeginTransaction();
                throw new Exception("Ha ocurrido un error " + e);
            }
            finally
            {
                con.Close();
            }
        }


        public static DataTable ObtenerMozos()
        {

            SqlConnection con = new SqlConnection();
            SqlCommand cmd = new SqlCommand();
            DataTable tabla = new DataTable();
            try
            {
                string query = "select * from Mozos";
                con.ConnectionString = Conexion.ObtenerConexion();
                cmd.Connection = con;
                cmd.CommandText = query;
                con.Open();
                tabla.Load(cmd.ExecuteReader());
                return tabla;

            }
            catch (Exception e)
            {
                //Conexion.BeginTransaction();
                throw new Exception("Ha ocurrido un error " + e);
            }
            finally
            {
                con.Close();
            }
        }

        public static DataTable ObtenerFormasPago()
        {

            SqlConnection con = new SqlConnection();
            SqlCommand cmd = new SqlCommand();
            DataTable tabla = new DataTable();
            try
            {
                string query = "select * from FormasPago";
                con.ConnectionString = Conexion.ObtenerConexion();
                cmd.Connection = con;
                cmd.CommandText = query;
                con.Open();
                tabla.Load(cmd.ExecuteReader());
                return tabla;

            }
            catch (Exception e)
            {
                //Conexion.BeginTransaction();
                throw new Exception("Ha ocurrido un error " + e);
            }
            finally
            {
                con.Close();
            }
        }


        //INSERTAR TICKET
        public static int InsertarTicket(Ticket t)
        {

            SqlConnection con = new SqlConnection();
            SqlCommand cmd = new SqlCommand();
            
            try
            {
                //int id;
                string nombreSP = "sp_InserarTicket";
                con.ConnectionString = Conexion.ObtenerConexion();
                con.Open();
                cmd.Connection = con;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = nombreSP;
                cmd.Parameters.AddWithValue("@idLocal", t.IdLocal);
                cmd.Parameters.AddWithValue("@idUsuario", t.IdUsuario);
                cmd.Parameters.AddWithValue("@idMozo", t.IdMozo);
                cmd.Parameters.AddWithValue("@idFormaPago", t.IdFormaPago);
                cmd.Parameters.AddWithValue("@fecha", DateTime.Today);

                SqlParameter outputIdParam = new SqlParameter("@idTicket", SqlDbType.Int)
                {
                    Direction = ParameterDirection.Output
                };
                cmd.Parameters.Add(outputIdParam);
                //Conexion.transaction = Conexion.conexion.BeginTransaction();
                //Conexion.Cmd.Transaction = Conexion.transaction;
                cmd.ExecuteNonQuery();
                cmd.Parameters.Clear();

                int id = (int)outputIdParam.Value;
                return id;
                //Conexion.CommitTransaction();
                //if (fila > 0)
                //{
                //    return true;
                //}
                //else
                //{
                //    return false;
                //}
            }
            catch (SqlException e)
            {
                //Conexion.BeginTransaction();
                //return false;
                throw new Exception(e.Message);
            }
            finally
            {
                con.Close();
            }
        }



        //INSERTAR DETALLE DE TICKET
        public static bool InsertarDetalleTicket(TicketDetalle td)
        {

            SqlConnection con = new SqlConnection();
            SqlCommand cmd = new SqlCommand();

            try
            {
                string nombreSP = "sp_InsertarDetalleTicket";
                con.ConnectionString = Conexion.ObtenerConexion();
                con.Open();
                cmd.Connection = con;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = nombreSP;
                cmd.Parameters.AddWithValue("@idTicket", td.IdTicket);
                cmd.Parameters.AddWithValue("@idArticulo", td.IdArticulo);
                cmd.Parameters.AddWithValue("@cantidad", td.Cantidad);
                cmd.Parameters.AddWithValue("@preUnitario", td.PreUnitario);


                //Conexion.transaction = Conexion.conexion.BeginTransaction();
                //Conexion.Cmd.Transaction = Conexion.transaction;
                int fila = cmd.ExecuteNonQuery();
                cmd.Parameters.Clear();
                //Conexion.CommitTransaction();
                if (fila > 0)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch (Exception)
            {
                //Conexion.BeginTransaction();
                return false;
            }
            finally
            {
                con.Close();
            }
        }
    }
}

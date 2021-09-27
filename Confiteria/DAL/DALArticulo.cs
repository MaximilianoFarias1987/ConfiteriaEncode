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
    public class DALArticulo
    {
        //INSERTAR
        public static bool InsertarArticulo(Articulo a)
        {

            SqlConnection con = new SqlConnection();
            SqlCommand cmd = new SqlCommand();

            try
            {
                string nombreSP = "sp_InsertaArticulo";
                con.ConnectionString = Conexion.ObtenerConexion();
                con.Open();
                cmd.Connection = con;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = nombreSP;
                cmd.Parameters.AddWithValue("@descripcion", a.Descripcion);
                cmd.Parameters.AddWithValue("@precio", a.Precio);
                cmd.Parameters.AddWithValue("@stock", a.Stock);
                cmd.Parameters.AddWithValue("@idRubro", a.IdRubro);

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


        //Actualizar
        public static bool ActualizarArticulo(Articulo a)
        {

            SqlConnection con = new SqlConnection();
            SqlCommand cmd = new SqlCommand();

            try
            {
                string nombreSP = "sp_ActualizarArticulo";
                con.ConnectionString = Conexion.ObtenerConexion();
                con.Open();
                cmd.Connection = con;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = nombreSP;
                cmd.Parameters.AddWithValue("@idArticulo", a.IdArticulo);
                cmd.Parameters.AddWithValue("@descripcion", a.Descripcion);
                cmd.Parameters.AddWithValue("@precio", a.Precio);
                cmd.Parameters.AddWithValue("@stock", a.Stock);
                cmd.Parameters.AddWithValue("@idRubro", a.IdRubro);

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


        //ELIMINAR ARTICULO
        public static bool EliminarArticulo(int id)
        {

            SqlConnection con = new SqlConnection();
            SqlCommand cmd = new SqlCommand();

            try
            {
                string nombreSP = "sp_EliminarArticulo";
                con.ConnectionString = Conexion.ObtenerConexion();
                con.Open();
                cmd.Connection = con;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = nombreSP;
                cmd.Parameters.AddWithValue("@idArticulo", id);

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


        //METODO CARGAR OBJETO
        public static Articulo CrearObjeto(SqlDataReader dr)
        {
            var x = new Articulo();
            if (dr["idArticulo"].ToString() != null)
            {
                x.IdArticulo = (int)dr["idArticulo"];
            }
            if (dr["descripcion"].ToString() != null)
            {
                x.Descripcion = dr["descripcion"].ToString();
            }
            if (dr["precio"].ToString() != null)
            {
                x.Precio = (double)dr["precio"];
            }
            if (dr["stock"].ToString() != null)
            {
                x.Stock = (int)dr["stock"];
            }
            if (dr["idRubro"].ToString() != null)
            {
                x.IdRubro = (int)dr["idRubro"];
            }
            return x;
        }


        //OBTENER Articulo ID

        public static Articulo ObtenerArticuloID(Articulo a)
        {

            SqlConnection con = new SqlConnection();
            SqlCommand cmd = new SqlCommand();
            Articulo obj = null;
            try
            {
                string nombreSP = "sp_ObtenerArticuloID";
                con.ConnectionString = Conexion.ObtenerConexion();
                con.Open();
                cmd.Connection = con;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = nombreSP;
                cmd.Parameters.AddWithValue("@idArticulo", a.IdArticulo);
                SqlDataReader dr = cmd.ExecuteReader();

                if (dr.Read())
                {
                    obj = CrearObjeto(dr);
                }
                con.Close();
                return obj;

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





        //OBTENER Articulos
        public static List<Articulo> ObtenerArticulos()
        {

            SqlConnection con = new SqlConnection();
            SqlCommand cmd = new SqlCommand();
            List<Articulo> lst = new List<Articulo>();
            Articulo a = null;
            try
            {
                string nombreSP = "sp_ObtenerArticulos";
                con.ConnectionString = Conexion.ObtenerConexion();
                con.Open();
                cmd.Connection = con;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = nombreSP;
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



        //VALIDAR Articulo

        public static bool ValidarArticuloUnico(string descripcion, int idRubro)
        {
            SqlConnection con = new SqlConnection();
            SqlCommand cmd = new SqlCommand();

            try
            {
                string query = string.Format("select Count(*) from Articulos where descripcion = '{0}' and idRubro = {1}", descripcion, idRubro);
                con.ConnectionString = Conexion.ObtenerConexion();
                cmd.Connection = con;
                cmd.CommandText = query;
                con.Open();
                int fila = (int)cmd.ExecuteScalar();
                if (fila != 0)
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
                con.Close();
                return false;
            }
        }

        //OBTENER TIPOS DE DOCUMENTOS PARA CARGAR COMBO
        public static DataTable ObtenerRubro()
        {

            SqlConnection con = new SqlConnection();
            SqlCommand cmd = new SqlCommand();
            DataTable tabla = new DataTable();
            try
            {
                string query = "select * from Rubro";
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
    }
}

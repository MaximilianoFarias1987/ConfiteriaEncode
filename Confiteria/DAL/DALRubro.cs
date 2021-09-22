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
    public class DALRubro
    {
        //INSERTAR
        public static bool InsertarRubro(Rubro r)
        {

            SqlConnection con = new SqlConnection();
            SqlCommand cmd = new SqlCommand();

            try
            {
                string nombreSP = "sp_InsertarRubro";
                con.ConnectionString = Conexion.ObtenerConexion();
                con.Open();
                cmd.Connection = con;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = nombreSP;
                cmd.Parameters.AddWithValue("@descripcion", r.Descripcion);

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


        //Actualizar
        public static bool ActualizarRubro(Rubro r)
        {

            SqlConnection con = new SqlConnection();
            SqlCommand cmd = new SqlCommand();

            try
            {
                string nombreSP = "sp_ActualizarRubro";
                con.ConnectionString = Conexion.ObtenerConexion();
                con.Open();
                cmd.Connection = con;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = nombreSP;
                cmd.Parameters.AddWithValue("@idRubro", r.IdRubro);
                cmd.Parameters.AddWithValue("@descripcion", r.Descripcion);

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


        //ELIMINAR LOCAL
        public static bool EliminarRubro(Rubro r)
        {

            SqlConnection con = new SqlConnection();
            SqlCommand cmd = new SqlCommand();

            try
            {
                string nombreSP = "sp_EliminarRubro";
                con.ConnectionString = Conexion.ObtenerConexion();
                con.Open();
                cmd.Connection = con;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = nombreSP;
                cmd.Parameters.AddWithValue("@idRubro", r.IdRubro);

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
        public static Rubro CrearObjeto(SqlDataReader dr)
        {
            var x = new Rubro();
            if (dr["idRubro"].ToString() != null)
            {
                x.IdRubro = (int)dr["idRubro"];
            }
            if (dr["descripcion"].ToString() != null)
            {
                x.Descripcion = dr["descripcion"].ToString();
            }
            
            return x;
        }


        //OBTENER Articulo ID

        public static Rubro ObtenerLocalID(Rubro r)
        {

            SqlConnection con = new SqlConnection();
            SqlCommand cmd = new SqlCommand();
            Rubro obj = null;
            try
            {
                string nombreSP = "sp_ObtenerRubroID";
                con.ConnectionString = Conexion.ObtenerConexion();
                con.Open();
                cmd.Connection = con;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = nombreSP;
                cmd.Parameters.AddWithValue("@idRubro", r.IdRubro);
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



        //continuar refactorizando desde aca

        //OBTENER Articulos
        public static List<Local> ObtenerLocales()
        {

            SqlConnection con = new SqlConnection();
            SqlCommand cmd = new SqlCommand();
            List<Local> lst = new List<Local>();
            Local l = null;
            try
            {
                string nombreSP = "sp_ObtenerLocales";
                con.ConnectionString = Conexion.ObtenerConexion();
                con.Open();
                cmd.Connection = con;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = nombreSP;
                SqlDataReader dr = cmd.ExecuteReader();
                lst.Clear();

                while (dr.Read())
                {
                    l = CrearObjeto(dr);
                    lst.Add(l);
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

        public static bool ValidarLocalUnico(string cuit, string direccion)
        {
            SqlConnection con = new SqlConnection();
            SqlCommand cmd = new SqlCommand();

            try
            {
                string query = string.Format("select Count(*) from Locales where cuit = '{0}' or direccion = '{1}'", cuit, direccion);
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
    }
}

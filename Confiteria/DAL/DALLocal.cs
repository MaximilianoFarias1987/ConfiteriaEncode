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
    public class DALLocal
    {
        //INSERTAR
        public static bool InsertarLocal(Local l)
        {

            SqlConnection con = new SqlConnection();
            SqlCommand cmd = new SqlCommand();

            try
            {
                string nombreSP = "sp_InsertarLocal";
                con.ConnectionString = Conexion.ObtenerConexion();
                con.Open();
                cmd.Connection = con;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = nombreSP;
                cmd.Parameters.AddWithValue("@razonSocial", l.RazonSocial);
                cmd.Parameters.AddWithValue("@direccion", l.Direccion);
                cmd.Parameters.AddWithValue("@cuit", l.Cuit);
                cmd.Parameters.AddWithValue("@idTipoIva", l.IdTipoIva);
                cmd.Parameters.AddWithValue("@ingBruto", l.IngBruto);

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
        public static bool ActualizarLocal(Local l)
        {

            SqlConnection con = new SqlConnection();
            SqlCommand cmd = new SqlCommand();

            try
            {
                string nombreSP = "sp_ActualizarLocal";
                con.ConnectionString = Conexion.ObtenerConexion();
                con.Open();
                cmd.Connection = con;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = nombreSP;
                cmd.Parameters.AddWithValue("@idLocal", l.IdLocal);
                cmd.Parameters.AddWithValue("@razonSocial", l.RazonSocial);
                cmd.Parameters.AddWithValue("@direccion", l.Direccion);
                cmd.Parameters.AddWithValue("@cuit", l.Cuit);
                cmd.Parameters.AddWithValue("@idTipoIva", l.IdTipoIva);
                cmd.Parameters.AddWithValue("@ingBruto", l.IngBruto);

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
        public static bool EliminarLocal(int id)
        {

            SqlConnection con = new SqlConnection();
            SqlCommand cmd = new SqlCommand();

            try
            {
                string nombreSP = "sp_EliminarLocal";
                con.ConnectionString = Conexion.ObtenerConexion();
                con.Open();
                cmd.Connection = con;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = nombreSP;
                cmd.Parameters.AddWithValue("@idLocal", id);

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
        public static Local CrearObjeto(SqlDataReader dr)
        {
            var x = new Local();
            if (dr["idLocal"].ToString() != null)
            {
                x.IdLocal = (int)dr["idLocal"];
            }
            if (dr["razonSocial"].ToString() != null)
            {
                x.RazonSocial = dr["razonSocial"].ToString();
            }
            if (dr["direccion"].ToString() != null)
            {
                x.Direccion = dr["direccion"].ToString();
            }
            if (dr["cuit"].ToString() != null)
            {
                x.Cuit = dr["cuit"].ToString();
            }
            if (dr["idTipoIva"].ToString() != null)
            {
                x.IdTipoIva = (int)dr["idTipoIva"];
            }
            if (dr["ingBruto"].ToString() != null)
            {
                x.IngBruto = (double)dr["ingBruto"];
            }
            return x;
        }


        //OBTENER Articulo ID

        public static int ObtenerLocalID()
        {

            SqlConnection con = new SqlConnection();
            SqlCommand cmd = new SqlCommand();
            try
            {
                int idLocal = 0;
                string nombreSP = "sp_ObtenerLocalID";
                con.ConnectionString = Conexion.ObtenerConexion();
                con.Open();
                cmd.Connection = con;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = nombreSP;
                SqlDataReader dr = cmd.ExecuteReader();

                if (dr.Read())
                {
                    if (dr["idLocal"].ToString() != null)
                    {
                        idLocal = (int)dr["idLocal"];
                    }
                }
                con.Close();
                return idLocal;

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



        //OBTENER TIPOS DE IVA PARA CARGAR COMBO
        public static DataTable ObtenerTipoIva()
        {

            SqlConnection con = new SqlConnection();
            SqlCommand cmd = new SqlCommand();
            DataTable tabla = new DataTable();
            try
            {
                string query = "select * from TiposIva";
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

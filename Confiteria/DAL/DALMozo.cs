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
    public class DALMozo
    {
        //INSERTAR
        public static bool InsertarMozo(Mozo m)
        {

            SqlConnection con = new SqlConnection();
            SqlCommand cmd = new SqlCommand();

            try
            {
                string nombreSP = "sp_InsertarMozo";
                con.ConnectionString = Conexion.ObtenerConexion();
                con.Open();
                cmd.Connection = con;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = nombreSP;
                cmd.Parameters.AddWithValue("@nombre", m.Nombre);
                cmd.Parameters.AddWithValue("@apellido", m.Apellido);
                cmd.Parameters.AddWithValue("@idTipoDoc", m.IdTipoDoc);
                cmd.Parameters.AddWithValue("@numDocumento", m.NumeroDoc);
                cmd.Parameters.AddWithValue("@email", m.Email);
                cmd.Parameters.AddWithValue("@telefono", m.Telefono);
                cmd.Parameters.AddWithValue("@direccion", m.Direccion);
                cmd.Parameters.AddWithValue("@porComision", m.PorComision);
                cmd.Parameters.AddWithValue("@fechaIngreso", DateTime.Today);


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
        public static bool ActualizarMozo(Mozo m)
        {

            SqlConnection con = new SqlConnection();
            SqlCommand cmd = new SqlCommand();

            try
            {
                string nombreSP = "sp_ActualizarMozo";
                con.ConnectionString = Conexion.ObtenerConexion();
                con.Open();
                cmd.Connection = con;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = nombreSP;
                cmd.Parameters.AddWithValue("@idMozo", m.Id);
                cmd.Parameters.AddWithValue("@nombre", m.Nombre);
                cmd.Parameters.AddWithValue("@apellido", m.Apellido);
                cmd.Parameters.AddWithValue("@idTipoDoc", m.IdTipoDoc);
                cmd.Parameters.AddWithValue("@numDocumento", m.NumeroDoc);
                cmd.Parameters.AddWithValue("@email", m.Email);
                cmd.Parameters.AddWithValue("@telefono", m.Telefono);
                cmd.Parameters.AddWithValue("@direccion", m.Direccion);
                cmd.Parameters.AddWithValue("@porComision", m.PorComision);
                cmd.Parameters.AddWithValue("@fechaIngreso", DateTime.Now);

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


        //ELIMINAR MOZO
        public static bool EliminarMozo(int id)
        {

            SqlConnection con = new SqlConnection();
            SqlCommand cmd = new SqlCommand();

            try
            {
                string nombreSP = "sp_EliminarMozo";
                con.ConnectionString = Conexion.ObtenerConexion();
                con.Open();
                cmd.Connection = con;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = nombreSP;
                cmd.Parameters.AddWithValue("@idMozo", id);

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
        public static Mozo CrearObjeto(SqlDataReader dr)
        {
            var m = new Mozo();
            if (dr["idMozo"].ToString() != null)
            {
                m.Id = (int)dr["idMozo"];
            }
            if (dr["nombre"].ToString() != null)
            {
                m.Nombre = dr["nombre"].ToString();
            }
            if (dr["apellido"].ToString() != null)
            {
                m.Apellido = dr["apellido"].ToString();
            }
            if (dr["idTipoDoc"].ToString() != null)
            {
                m.IdTipoDoc = (int)dr["idTipoDoc"];
            }
            if (dr["numDocumento"].ToString() != null)
            {
                m.NumeroDoc = dr["numDocumento"].ToString();
            }
            if (dr["email"].ToString() != null)
            {
                m.Email = dr["email"].ToString();
            }
            if (dr["telefono"].ToString() != null)
            {
                m.Telefono = dr["telefono"].ToString();
            }
            if (dr["direccion"].ToString() != null)
            {
                m.Direccion = dr["direccion"].ToString();
            }
            if (dr["porComision"].ToString() != null)
            {
                m.PorComision = (double)dr["porComision"];
            }
            if (dr["fechaIngreso"].ToString() != null)
            {
                m.FechaIngreso = (DateTime)dr["fechaIngreso"];
            }



            return m;
        }


        //OBTENER MOZO ID

        public static Mozo ObtenerMozoID(Mozo m)
        {

            SqlConnection con = new SqlConnection();
            SqlCommand cmd = new SqlCommand();
            Mozo obj = null;
            try
            {
                string nombreSP = "sp_ObtenerMozoId";
                con.ConnectionString = Conexion.ObtenerConexion();
                con.Open();
                cmd.Connection = con;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = nombreSP;
                cmd.Parameters.AddWithValue("@idMozo", m.Id);
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





        //OBTENER MOZO
        public static List<Mozo> ObtenerMozos()
        {

            SqlConnection con = new SqlConnection();
            SqlCommand cmd = new SqlCommand();
            List<Mozo> lst = new List<Mozo>();
            Mozo m = null;
            try
            {
                string nombreSP = "sp_ObtenerMozos";
                con.ConnectionString = Conexion.ObtenerConexion();
                con.Open();
                cmd.Connection = con;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = nombreSP;
                SqlDataReader dr = cmd.ExecuteReader();
                lst.Clear();

                while (dr.Read())
                {
                    m = CrearObjeto(dr);
                    lst.Add(m);
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



        //VALIDAR MOZO

        public static bool ValidarMozoUnico(string email, int tipoDoc, string numDoc)
        {
            SqlConnection con = new SqlConnection();
            SqlCommand cmd = new SqlCommand();

            try
            {
                string query = string.Format("select Count(*) from Mozos where email = '{0}' and idTipoDoc = {1} and numeroDoc = '{2}'", email, tipoDoc, numDoc);
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

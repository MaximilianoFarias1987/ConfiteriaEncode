using DAL.ConexionDB;
using Entidades;
using Entidades.DTOs;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace DAL
{
    public class DALUsuario
    {
        //INSERTAR
        public static bool InsertarUsuario(Usuario u)
        {

            SqlConnection con = new SqlConnection();
            SqlCommand cmd = new SqlCommand();

            try
            {
                string nombreSP = "sp_InsertarUsuario";
                con.ConnectionString = Conexion.ObtenerConexion();
                con.Open();
                cmd.Connection = con;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = nombreSP;
                cmd.Parameters.AddWithValue("@nombre", u.Nombre);
                cmd.Parameters.AddWithValue("@apellido", u.Apellido);
                cmd.Parameters.AddWithValue("@idTipoDoc", u.IdTipoDoc);
                cmd.Parameters.AddWithValue("@numeroDoc", u.NumeroDoc);
                cmd.Parameters.AddWithValue("@nombreUsuario", u.NombreUsuario);
                cmd.Parameters.AddWithValue("@contrasenia", EncryptKeys.EncriptarPassword(u.Password, "keys"));
                cmd.Parameters.AddWithValue("@idRol", u.IdRol);

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
        public static bool ActualizarUsuario(Usuario u)
        {

            SqlConnection con = new SqlConnection();
            SqlCommand cmd = new SqlCommand();

            try
            {
                string nombreSP = "sp_ActualizarUsuario";
                con.ConnectionString = Conexion.ObtenerConexion();
                con.Open();
                cmd.Connection = con;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = nombreSP;
                cmd.Parameters.AddWithValue("@idUsuario", u.Id);
                cmd.Parameters.AddWithValue("@nombre", u.Nombre);
                cmd.Parameters.AddWithValue("@apellido", u.Apellido);
                cmd.Parameters.AddWithValue("@idTipoDoc", u.IdTipoDoc);
                cmd.Parameters.AddWithValue("@numeroDoc", u.NumeroDoc);
                cmd.Parameters.AddWithValue("@nombreUsuario", u.NombreUsuario);
                cmd.Parameters.AddWithValue("@contrasenia", EncryptKeys.EncriptarPassword(u.Password, "keys"));
                cmd.Parameters.AddWithValue("@idRol", u.IdRol);

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


        //OBTENER USUARIOS
        public static bool EliminarUsuario(int id)
        {

            SqlConnection con = new SqlConnection();
            SqlCommand cmd = new SqlCommand();

            try
            {
                string nombreSP = "sp_EliminarUsuario";
                con.ConnectionString = Conexion.ObtenerConexion();
                con.Open();
                cmd.Connection = con;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = nombreSP;
                cmd.Parameters.AddWithValue("@idUsuario", id);

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
                throw new Exception(e.Message);
                //return false;
            }
            finally
            {
                con.Close();
            }
        }


        //METODO CARGAR OBJETO
        public static Usuario CrearObjeto(SqlDataReader dr)
        {
            var u = new Usuario();
            if (dr["idUsuario"].ToString() != null)
            {
                u.Id = (int)dr["idUsuario"];
            }
            if (dr["nombre"].ToString() != null)
            {
                u.Nombre = dr["nombre"].ToString();
            }
            if (dr["apellido"].ToString() != null)
            {
                u.Apellido = dr["apellido"].ToString();
            }
            if (dr["idTipoDoc"].ToString() != null)
            {
                u.IdTipoDoc = (int)dr["idTipoDoc"];
            }
            if (dr["numeroDoc"].ToString() != null)
            {
                u.NumeroDoc = dr["numeroDoc"].ToString();
            }
            if (dr["nombreUsuario"].ToString() != null)
            {
                u.NombreUsuario = dr["nombreUsuario"].ToString();
            }
            if (dr["contrasenia"].ToString() != null)
            {
                u.Password = dr["contrasenia"].ToString();
            }
            if (dr["idRol"].ToString() != null)
            {
                u.IdRol = (int)dr["idRol"];
            }

            return u;
        }


        public static UsuariosDTO CrearObjetoDTO(SqlDataReader dr)
        {
            var u = new UsuariosDTO();
            if (dr["idUsuario"].ToString() != null)
            {
                u.IdUsuario = (int)dr["idUsuario"];
            }
            if (dr["Nombre"].ToString() != null)
            {
                u.Nombre = dr["Nombre"].ToString();
            }
            if (dr["Apellido"].ToString() != null)
            {
                u.Apellido = dr["Apellido"].ToString();
            }
            if (dr["TipoDocumento"].ToString() != null)
            {
                u.TipoDoc = dr["TipoDocumento"].ToString();
            }
            if (dr["Documento"].ToString() != null)
            {
                u.Documento = dr["Documento"].ToString();
            }
            if (dr["NombreUsuario"].ToString() != null)
            {
                u.NombreUsuario = dr["NombreUsuario"].ToString();
            }
            if (dr["contrasenia"].ToString() != null)
            {
                u.Password = dr["contrasenia"].ToString();
            }
            if (dr["Rol"].ToString() != null)
            {
                u.Rol = dr["Rol"].ToString();
            }

            return u;
        }


        //METODO CARGAR OBJETO TIPO DOC
        public static TipoDocumento CrearObjetoTipo(SqlDataReader dr)
        {
            var t = new TipoDocumento();
            if (dr["idTipoDoc"].ToString() != null)
            {
                t.IdTipoDocumento = (int)dr["idTipoDoc"];
            }
            if (dr["descripcion"].ToString() != null)
            {
                t.Descripcion = dr["descripcion"].ToString();
            }
            

            return t;
        }


        //OBTENER USUARIO ID

        public static Usuario ObtenerUsuarioID(Usuario u)
        {

            SqlConnection con = new SqlConnection();
            SqlCommand cmd = new SqlCommand();
            Usuario usu = null;
            try
            {
                string nombreSP = "sp_ObtenerUsuarioID";
                con.ConnectionString = Conexion.ObtenerConexion();
                con.Open();
                cmd.Connection = con;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = nombreSP;
                cmd.Parameters.AddWithValue("@idUsuario", u.Id);
                SqlDataReader dr = cmd.ExecuteReader();

                if(dr.Read())
                {
                    usu = CrearObjeto(dr);
                }
                con.Close();
                return usu;

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





        //OBTENER USAURIOS
        //public static List<Usuario> ObtenerUsuarios()
        //{

        //    SqlConnection con = new SqlConnection();
        //    SqlCommand cmd = new SqlCommand();
        //    List<Usuario> lst = new List<Usuario>();
        //    Usuario u = null;
        //    try
        //    {
        //        string nombreSP = "sp_ObtenerUsuarios";
        //        con.ConnectionString = Conexion.ObtenerConexion();
        //        con.Open();
        //        cmd.Connection = con;
        //        cmd.CommandType = CommandType.StoredProcedure;
        //        cmd.CommandText = nombreSP;
        //        SqlDataReader dr = cmd.ExecuteReader();
        //        lst.Clear();

        //        while (dr.Read())
        //        {
        //            u = CrearObjeto(dr);
        //            lst.Add(u);
        //        }
        //        con.Close();
        //        return lst;

        //    }
        //    catch (Exception)
        //    {
        //        //Conexion.BeginTransaction();
        //        throw new Exception("Ha ocurrido un error");
        //    }
        //    finally
        //    {
        //        con.Close();
        //    }
        //}


        public static List<UsuariosDTO> ObtenerUsuarios()
        {

            SqlConnection con = new SqlConnection();
            SqlCommand cmd = new SqlCommand();
            List<UsuariosDTO> lst = new List<UsuariosDTO>();
            UsuariosDTO u = null;
            try
            {
                string nombreSP = "sp_ObtenerUsuarios2";
                con.ConnectionString = Conexion.ObtenerConexion();
                con.Open();
                cmd.Connection = con;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = nombreSP;
                SqlDataReader dr = cmd.ExecuteReader();
                lst.Clear();

                while (dr.Read())
                {
                    u = CrearObjetoDTO(dr);
                    lst.Add(u);
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







        //OBTENER TIPOS DE DOCUMENTOS PARA CARGAR COMBO
        public static DataTable ObtenerTipoDocumento()
        {

            SqlConnection con = new SqlConnection();
            SqlCommand cmd = new SqlCommand();
            DataTable tabla = new DataTable();
            try
            {
                string query = "select * from TipoDocumentos";
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


        //OBTENER ROLES PARA CARGAR COMBO
        public static DataTable ObtenerRoles()
        {

            SqlConnection con = new SqlConnection();
            SqlCommand cmd = new SqlCommand();
            DataTable tabla = new DataTable();
            try
            {
                string query = "select * from Roles";
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



        //VALIDAR NOMBRE USUARIO

        public static bool ValidarUsuarioUnico(string nombreUsuario, int tipoDoc, string numDoc)
        {
            SqlConnection con = new SqlConnection();
            SqlCommand cmd = new SqlCommand();

            try
            {
                string query = string.Format("select Count(*) from Usuarios where nombreUsuario = '{0}' and idTipoDoc = {1} and numeroDoc = '{2}'", nombreUsuario,tipoDoc,numDoc);
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

        //INICIO SESION

        public static Usuario UsuarioSesion(string usuario, string pass)
        {
            pass = EncryptKeys.EncriptarPassword(pass, "keys");
            SqlConnection con = new SqlConnection();
            SqlCommand cmd = new SqlCommand();
            Usuario u = null;
            try
            {
                string query = string.Format("select * from Usuarios where nombreUsuario = '{0}' and contrasenia = '{1}'", usuario, pass);
                con.ConnectionString = Conexion.ObtenerConexion();
                cmd.Connection = con;
                cmd.CommandText = query;
                con.Open();
                SqlDataReader dr = cmd.ExecuteReader();

                if (dr.Read())
                {
                    u = CrearObjeto(dr);
                }
                con.Close();
                return u;
            }
            catch (Exception ex)
            {
                con.Close();
                throw new Exception(ex.Message);
            }
        }

        //public static Usuario UsuarioSesion(string usuario)
        //{
        //    SqlConnection con = new SqlConnection();
        //    SqlCommand cmd = new SqlCommand();
        //    Usuario u = null;
        //    try
        //    {
        //        string query = string.Format("select * from Usuarios where nombreUsuario = '{0}'", usuario);
        //        con.ConnectionString = Conexion.ObtenerConexion();
        //        cmd.Connection = con;
        //        cmd.CommandText = query;
        //        con.Open();
        //        SqlDataReader dr = cmd.ExecuteReader();

        //        if (dr.Read())
        //        {
        //            u = CrearObjeto(dr);
        //        }
        //        con.Close();
        //        return u;
        //    }
        //    catch (Exception ex)
        //    {
        //        con.Close();
        //        throw new Exception(ex.Message);
        //    }
        //}


    }
}

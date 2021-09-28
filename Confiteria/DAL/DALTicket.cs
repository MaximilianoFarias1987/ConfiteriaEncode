using DAL.ConexionDB;
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
    }
}

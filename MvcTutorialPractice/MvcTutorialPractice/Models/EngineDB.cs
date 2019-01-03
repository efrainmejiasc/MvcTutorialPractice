using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Services;
using MvcTutorialPractice.Models;

namespace MvcTutorialPractice.Models
{
    public class EngineDB
    {
        private static string cadenaConexion = System.Configuration.ConfigurationManager.ConnectionStrings["MvcPractice"].ToString();

        public int SeleccionarIdUsuario(LoginData Usuario)
        {
            object obj = new object();
            int resultado = 0;
            SqlConnection Conexion = new SqlConnection(cadenaConexion);
            using (Conexion)
            {
                Conexion.Open();
                SqlCommand command = new SqlCommand("Sp_SeleccionarIdUsuario", Conexion);
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.Clear();
                command.Parameters.AddWithValue("@Username", Usuario.UserName);
                command.Parameters.AddWithValue("@Password", Usuario.Password);
                obj = command.ExecuteScalar();
                Conexion.Close();
            }
            if (obj != null)
            {
                resultado = Convert.ToInt32(obj);
            }
            return resultado;
        }

        public static  int InsertarUsuario(RegisterData Usuario)
        {
            int resultado = new int();
            SqlConnection Conexion = new SqlConnection(cadenaConexion);
            using (Conexion)
            {
                Conexion.Open();
                SqlCommand command = new SqlCommand("Sp_InsertarUsuario", Conexion);
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.Clear();
                command.Parameters.AddWithValue("@Username", Usuario.UserName);
                command.Parameters.AddWithValue("@Password", Usuario.Password);
                resultado = command.ExecuteNonQuery();
                Conexion.Close();
            }
            return resultado;
        }
    }
}
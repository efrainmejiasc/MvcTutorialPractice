using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace MvcTutorialPractice.Models
{
    public class EgineDB
    {
        private static string cadenaConexion = System.Configuration.ConfigurationManager.ConnectionStrings["MvcPractice"].ToString();

        public int SeleccionMail(string MAIL)
        {
            object obj = new object();
            int resultado = 0;
            SqlConnection Conexion = new SqlConnection(cadenaConexion);
            using (Conexion)
            {
                Conexion.Open();
                SqlCommand command = new SqlCommand("Sp_SeleccionMail", Conexion);
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.Clear();
                command.Parameters.AddWithValue("@MAIL", MAIL);
                obj = command.ExecuteScalar();
                Conexion.Close();
            }
            if (obj != null)
            {
                resultado = Convert.ToInt32(obj);
            }
            return resultado;
        }

        public int ActualizarNombreAdministrador(string MAIL, string ADMINISTRADOR, string PASSWORD, string ESTADO)
        {
            int resultado = new int();
            SqlConnection Conexion = new SqlConnection(cadenaConexion);
            using (Conexion)
            {
                Conexion.Open();
                SqlCommand command = new SqlCommand("Sp_ActualizarEstadoAdministrador", Conexion);
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.Clear();
                command.Parameters.AddWithValue("@MAIL", MAIL);
                command.Parameters.AddWithValue("@ADMINISTRADOR", ADMINISTRADOR);
                command.Parameters.AddWithValue("@PASSWORD", PASSWORD);
                command.Parameters.AddWithValue("@ESTADO", ESTADO);
                resultado = command.ExecuteNonQuery();
                Conexion.Close();
            }

            return resultado;
        }
    }
}
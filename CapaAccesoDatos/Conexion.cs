using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;

namespace CapaAccesoDatos
{
    public class Conexion
    {
        #region "PATRON SINGLETON"
        private static Conexion conexion = null;
        private Conexion() { }
        public static Conexion getInstance()
        {
            if (conexion == null)
            {
                conexion = new Conexion();
            }
            return conexion;
        }

        #endregion
        public SqlConnection ConexionDB()
        {
            SqlConnection conexion = new SqlConnection();
            //conexion.ConnectionString = "Data Source=SQL5097.site4now.net;Initial Catalog=db_a7554f_veterinaria;User Id=db_a7554f_veterinaria_admin;Password=veterinaria2021";
            conexion.ConnectionString = GetConnectionString();
            return conexion;
        }

        public String GetConnectionString()
        {
            return ConfigurationManager.ConnectionStrings["local_veterinaria"].ConnectionString;
        }
    }
}

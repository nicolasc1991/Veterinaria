using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using CapaEntidad;

namespace CapaAccesoDatos
{
    public class BitacoraDAO
    {

        
        #region "PATRON SINGLETON"
        private static BitacoraDAO daoBitacora = null;
        private BitacoraDAO() { }
        public static BitacoraDAO getInstance()
        {
            if (daoBitacora == null)
            {
                daoBitacora = new BitacoraDAO();
            }
            return daoBitacora;
        }
        #endregion
        public List<Bitacora> ListarBitacora()
        {
            List<Bitacora> Lista = new List<Bitacora>();
            SqlConnection con = null;
            SqlCommand cmd = null;
            SqlDataReader dr = null;

            try
            {
                con = Conexion.getInstance().ConexionDB();
                cmd = new SqlCommand("spListarEmpleados", con);
                cmd.CommandType = CommandType.StoredProcedure;
                con.Open();
                dr = cmd.ExecuteReader();

                while (dr.Read())
                {
                    
                    Bitacora objBitacora = new Bitacora();
                    objBitacora.id = Convert.ToInt32(dr["id"].ToString());
                    objBitacora.accion = dr["accion"].ToString();
                    objBitacora.usuario = dr["usuario"].ToString();
                    objBitacora.create_at = Convert.ToDateTime(dr["created_at"]);

                    // añadir a la lista de objetos
                    Lista.Add(objBitacora);
                }

            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                con.Close();
            }
            return Lista;
        }

    }
}
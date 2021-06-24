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
    public class EmpleadoDAO
    {

        
        #region "PATRON SINGLETON"
        private static EmpleadoDAO daoEmpleado = null;
        private EmpleadoDAO() { }
        public static EmpleadoDAO getInstance()
        {
            if (daoEmpleado == null)
            {
                daoEmpleado = new EmpleadoDAO();
            }
            return daoEmpleado;
        }
        #endregion
        public Empleado AccesoSistema(String user, String pass)
        {
            SqlConnection conexion = null;
            SqlCommand cmd = null;
            Empleado objEmpleado = null;
            SqlDataReader dr = null;
            try
            {
                conexion = Conexion.getInstance().ConexionDB();
                cmd = new SqlCommand("spAccesoSistema", conexion);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@prmUser", user);
                cmd.Parameters.AddWithValue("@prmPass", pass);
                conexion.Open();
                dr = cmd.ExecuteReader();
                if (dr.Read())
                {
                    objEmpleado = new Empleado();
                    objEmpleado.ID = Convert.ToInt32(dr["idEmpleado"].ToString());
                    objEmpleado.Usuario = dr["usuario"].ToString();
                    objEmpleado.Clave = dr["clave"].ToString();
                    objEmpleado.Estado = Convert.ToBoolean(dr["estado"].ToString());
                    objEmpleado.IdTipoEmpleado = Convert.ToInt32(dr["IdTipoEmpleado"].ToString());
                    objEmpleado.ApMaterno = dr["apMaterno"].ToString();
                    objEmpleado.ApPaterno = dr["apPaterno"].ToString();
                    objEmpleado.Nombre = dr["nombres"].ToString();
                }
            }
            catch (Exception ex)
            {
                objEmpleado = null;
                throw ex;
            }
            finally
            {
                conexion.Close();
            }
            return objEmpleado;
        }
        public bool RegistrarEmpleado(Empleado objEmpleado)
        {
            SqlConnection con = null;
            SqlCommand cmd = null;
            bool response = false;
            try
            {
                con = Conexion.getInstance().ConexionDB();
                cmd = new SqlCommand("spRegistrarEmpleado", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@prmNombres", objEmpleado.Nombre);
                cmd.Parameters.AddWithValue("@prmApPaterno", objEmpleado.ApPaterno);
                cmd.Parameters.AddWithValue("@prmApMaterno", objEmpleado.ApMaterno);
                cmd.Parameters.AddWithValue("@prmNroDoc", objEmpleado.NroDocumento);
                cmd.Parameters.AddWithValue("@prmEstado", objEmpleado.Estado);
                con.Open();

                int filas = cmd.ExecuteNonQuery();
                if (filas > 0) response = true;

            }
            catch (Exception ex)
            {
                response = false;
                throw ex;
            }
            finally
            {
                con.Close();
            }
            return response;
        }

        public List<Empleado> ListarEmpleados()
        {
            List<Empleado> Lista = new List<Empleado>();
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
                    // Crear objetos de tipo Empleado
                    Empleado objEmpleado = new Empleado();
                    objEmpleado.ID = Convert.ToInt32(dr["idEmpleado"].ToString());
                    objEmpleado.Nombre = dr["nombres"].ToString();
                    objEmpleado.ApPaterno = dr["apPaterno"].ToString();
                    objEmpleado.ApMaterno = dr["apMaterno"].ToString();
                    objEmpleado.NroDocumento = dr["nroDocumento"].ToString();
                    objEmpleado.Usuario = dr["usuario"].ToString();
                    objEmpleado.Estado = true;

                    // añadir a la lista de objetos
                    Lista.Add(objEmpleado);
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

        public bool Actualizar(Empleado objEmpleado)
        {
            bool ok = false;
            SqlConnection conexion = null;
            SqlCommand cmd = null;
            try
            {
                conexion = Conexion.getInstance().ConexionDB();
                cmd = new SqlCommand("spActualizarDatosEmpleado", conexion);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@prmID", objEmpleado.ID);
                cmd.Parameters.AddWithValue("@prmUsuario", objEmpleado.Usuario);

                conexion.Open();

                cmd.ExecuteNonQuery();

                ok = true;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                conexion.Close();
            }
            return ok;
        }

        public bool Eliminar(int id)
        {
            SqlConnection conexion = null;
            SqlCommand cmd = null;
            bool ok = false;
            try
            {
                conexion = Conexion.getInstance().ConexionDB();
                cmd = new SqlCommand("spEliminarEmpleado", conexion);
                cmd.Parameters.AddWithValue("@prmIdEmpleado", id);
                cmd.CommandType = CommandType.StoredProcedure;

                conexion.Open();

                cmd.ExecuteNonQuery();

                ok = true;

            }
            catch (Exception ex)
            {
                ok = false;
                throw ex;
            }
            finally
            {
                conexion.Close();
            }
            return ok;
        }

        public Empleado BuscarEmpleadoDNI(string dni)
        {
            SqlConnection conex = null;
            SqlCommand cmd = null;
            SqlDataReader dr = null;
            Empleado objEmpleado = null;

            try
            {
                conex = Conexion.getInstance().ConexionDB();
                cmd = new SqlCommand("spBuscarEmpleadoDNI", conex);
                cmd.Parameters.AddWithValue("@prmDni", dni);
                cmd.CommandType = CommandType.StoredProcedure;

                conex.Open();
                dr = cmd.ExecuteReader();

                if (dr.Read())
                {
                    objEmpleado = new Empleado
                    {
                        ID = Convert.ToInt32(dr["idEmpleado"].ToString()),
                        Nombre = dr["Nombres"].ToString(),
                        ApPaterno = dr["ApPaterno"].ToString(),
                        ApMaterno = dr["ApMaterno"].ToString(),
                    };
                }
            }
            catch (Exception ex)
            {
                objEmpleado = null;
                throw ex;
            }
            finally
            {
                conex.Close();
            }
            return objEmpleado;
        }

        public Empleado BuscarEmpleadoIdCita(Int32 idCita)
        {
            SqlConnection conex = null;
            SqlCommand cmd = null;
            SqlDataReader dr = null;
            Empleado objEmpleado = null;

            try
            {
                conex = Conexion.getInstance().ConexionDB();
                cmd = new SqlCommand("spBuscarEmpleadoIdCita", conex);
                cmd.Parameters.AddWithValue("@prmIdCita", idCita);
                cmd.CommandType = CommandType.StoredProcedure;

                conex.Open();
                dr = cmd.ExecuteReader();

                if (dr.Read())
                {
                    objEmpleado = new Empleado
                    {
                        ID = Convert.ToInt32(dr["idEmpleado"].ToString()),
                        Nombre = dr["Nombres"].ToString(),
                        ApPaterno = dr["ApPaterno"].ToString(),
                        ApMaterno = dr["ApMaterno"].ToString(),
                        
                    };
                }
            }
            catch (Exception ex)
            {
                objEmpleado = null;
                throw ex;
            }
            finally
            {
                conex.Close();
            }
            return objEmpleado;
        }

    }
}
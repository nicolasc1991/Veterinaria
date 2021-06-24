using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using CapaEntidad;
using CapaAccesoDatos;

namespace CapaLogica
{
    public class EmpleadoLN
    {
        #region "PATRON SINGLETON"
        private static EmpleadoLN objEmpleado = null;
        private EmpleadoLN()
        {

        }
        public static EmpleadoLN getInstance()
        {
            if (objEmpleado == null)
            {
                objEmpleado = new EmpleadoLN();
            }
            return objEmpleado;
        }
        #endregion
        public Empleado AccesoSistema(String user, String pass)
        {
            try
            {
                return EmpleadoDAO.getInstance().AccesoSistema(user, pass);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public bool RegistrarEmpleado(Empleado objEmpleado)
        {
            try
            {
                return EmpleadoDAO.getInstance().RegistrarEmpleado(objEmpleado);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public List<Empleado> ListarEmpleados()
        {
            try
            {
                return EmpleadoDAO.getInstance().ListarEmpleados();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public bool Actualizar(Empleado objEmpleado)
        {
            try
            {
                return EmpleadoDAO.getInstance().Actualizar(objEmpleado);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public bool Eliminar(int id)
        {
            try
            {
                return EmpleadoDAO.getInstance().Eliminar(id);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public Empleado BuscarEmpleadoDNI(string dni)
        {
            try
            {
                return EmpleadoDAO.getInstance().BuscarEmpleadoDNI(dni);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public Empleado BuscarEmpleadoIdCita(Int32 IdCita)
        {
            try
            {
                return EmpleadoDAO.getInstance().BuscarEmpleadoIdCita(IdCita);
            }
            catch (Exception)
            {
                throw;
            }
        }

    }
}
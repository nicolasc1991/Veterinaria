using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using CapaEntidad;
using CapaLogica;
using System.Web.Services;
using System.Web.Script.Serialization;
using Veterinaria.Custom;

namespace Veterinaria.js
{
    public partial class Usuarios : System.Web.UI.Page
    {
        
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["ID"] == null && Convert.ToInt32(Session["IdTipoEmpleado"]) == 1)
            {
                Response.Redirect("Login.aspx");
            }
            if (Convert.ToInt32(Session["IdTipoEmpleado"]) == 1)
            {

            }
            else
            {
                Response.Redirect("PanelGeneral.aspx");
            }
        }
        [WebMethod]
        public static List<Empleado> ListarEmpleados()
        {
            List<Empleado> Lista = null;
            try
            {
                Lista = EmpleadoLN.getInstance().ListarEmpleados();
            }
            catch (Exception ex)
            {
                Lista = new List<Empleado>();
            }
            return Lista;
        }

        [WebMethod]
        public static bool ActualizarDatosEmpleado(String id, String direccion)
        {
            Empleado objEmpleado = new Empleado()
            {
                ID = Convert.ToInt32(id)
            };

            bool ok = EmpleadoLN.getInstance().Actualizar(objEmpleado);
            return ok;
        }

        [WebMethod]
        public static bool EliminarDatosEmpleado(String id)
        {
            Int32 idEmpleado = Convert.ToInt32(id);

            bool ok = EmpleadoLN.getInstance().Eliminar(idEmpleado);

            return ok;

        }

        private Empleado GetEntity()
        {
            Empleado objEmpleado = new Empleado();
            objEmpleado.ID = 0;
            objEmpleado.Nombre = txtNombres.Text;
            objEmpleado.ApPaterno = txtApPaterno.Text;
            objEmpleado.ApMaterno = txtApMaterno.Text;
            objEmpleado.Usuario = txtUsuario.Text;
            objEmpleado.IdTipoEmpleado = Convert.ToInt32(ddlTipo.SelectedValue);
            objEmpleado.NroDocumento = txtNroDocumento.Text;
            objEmpleado.Clave = GenerarMD5.crearMD5(txtClave.Text);
            objEmpleado.Estado = true;
            objEmpleado.Create = (string)Session["Usuario"];
            return objEmpleado;
        }

        protected void btnRegistrar_Click(object sender, EventArgs e)
        {
            // Registro del Empleado
            Empleado objEmpleado = GetEntity();
            // enviar a la capa de logica de negocio
            bool response = EmpleadoLN.getInstance().RegistrarEmpleado(objEmpleado);
            if (response)
            {
                Response.Write("<script>alert('REGISTRO CORRECTO.')</script>");

            }
            else
            {
                Response.Write("<script>alert('REGISTRO INCORRECTO.')</script>");
            }
        }

        protected void GridView1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}
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


namespace Veterinaria
{
    public partial class RegistrarAnimales : BasePage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["ID"] == null)
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
        public static List<Paciente> ListarPacientes()
        {
            List<Paciente> Lista = null;
            try
            {
                Lista = PacienteLN.getInstance().ListarPacientes();
            }
            catch (Exception ex)
            {
                Lista = new List<Paciente>();
            }
            return Lista;
        }

        [WebMethod]
        public static bool ActualizarDatosPaciente(String id, String direccion)
        {
            Paciente objPaciente = new Paciente()
            {
                IdPaciente = Convert.ToInt32(id),
                Direccion = direccion
            };

            bool ok = PacienteLN.getInstance().Actualizar(objPaciente);
            return ok;
        }

        [WebMethod]
        public static bool EliminarDatosPaciente(String id,Paciente objPaciente)
        {
            Int32 idPaciente = Convert.ToInt32(id);

            bool ok = PacienteLN.getInstance().Eliminar(idPaciente,objPaciente);

            return ok;

        }

        private Paciente GetEntity()
        {
            Paciente objPaciente = new Paciente();
            objPaciente.IdPaciente = 0;
            objPaciente.Nombres = txtNombres.Text;
            objPaciente.ApPaterno = txtApPaterno.Text;
            objPaciente.Edad = Convert.ToInt32(txtEdad.Text);
            objPaciente.Sexo = (ddlSexo.SelectedValue == "Femenino") ? 'F' : 'M'; // Masculino , Femenino
            objPaciente.Direccion = txtDireccion.Text;
            objPaciente.Telefono = txtTelefono.Text;
            objPaciente.Estado = true;
            objPaciente.Create = (string)Session["Usuario"];

            return objPaciente;
        }

        protected void btnRegistrar_Click(object sender, EventArgs e)
        {
            // Registro del paciente
            Paciente objPaciente = GetEntity();
            // enviar a la capa de logica de negocio
            bool response = PacienteLN.getInstance().RegistrarPaciente(objPaciente);
            if (response)
            {
                Response.Write("<script>alert('REGISTRO CORRECTO.')</script>");

            }
            else
            {
                Response.Write("<script>alert('REGISTRO INCORRECTO.')</script>");
            }
        }
    }
}
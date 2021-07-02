using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.Security;
using CapaEntidad;
using CapaLogica;
using Veterinaria.Custom;

namespace Veterinaria
{
    public partial class Login : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
           
        }

        protected void btnIngresar_Click(object sender, EventArgs e)
        {
            Empleado objEmpleado = EmpleadoLN.getInstance().AccesoSistema(txtUsuario.Text, GenerarMD5.crearMD5(txtPassword.Text));
            
            if (objEmpleado != null)
            {
                Session["Usuario"] = objEmpleado.Usuario;
                Session["ID"] = objEmpleado.ID;
                Session["Nombre"] = objEmpleado.Nombre;
                Session["Apellidos"] = objEmpleado.ApPaterno + " " + objEmpleado.ApMaterno;
                Session["Estado"] = objEmpleado.Estado;
                Session["IdTipoEmpleado"] = objEmpleado.IdTipoEmpleado;
                if (objEmpleado.Estado == true)
                {
                    Response.Redirect("PanelGeneral.aspx");
                }
                else
                {
                    Response.Write("<script>alert('USUARIO INACTIVO')</script>");
                }
            }
            else
            {
                Response.Write("<script>alert('USUARIO INCORRECTO')</script>");
            }
        }
    }
}
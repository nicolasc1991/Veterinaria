using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Veterinaria
{
    public partial class Home : System.Web.UI.MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            Label1.Text = (string)Session["Nombre"];
            if (Convert.ToInt32(Session["IdTipoEmpleado"])==1) {
                MenuUser.Visible = false;
                MenuAdmin.Visible = true;
            }
            else
            {
                MenuAdmin.Visible = false;
                MenuUser.Visible = true;
            }
        }

        protected void lnkCerrarSesion_Click(object sender, EventArgs e)
        {
            Session.Clear();
            Session["ID"] = null;
            Session.Abandon();
            Response.Redirect("~/Login.aspx");
        }

    }
}
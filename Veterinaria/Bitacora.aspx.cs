using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Veterinaria
{
    public partial class Bitacora : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["ID"] == null)
            {
                Response.Redirect("Login.aspx");
            }
            if(Convert.ToInt32(Session["IdTipoEmpleado"]) == 1)
            {
               
            }
            else
            {
                Response.Redirect("PanelGeneral.aspx");
            }
        }
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using EntidadesCompartidas;

public partial class MasterPage : System.Web.UI.MasterPage
{
    protected void Page_Load(object sender, EventArgs e)
    {
        try
        {
            Usuarios unUsuario = (Usuarios)Session["Usuarios"];
            if (unUsuario is Usuarios)
                lblUsuarios.Text = unUsuario.ToString();
        }
        catch
        {
            Response.Redirect("Default.aspx");
        }
    }


    protected void ImageButton1_Click1(object sender, ImageClickEventArgs e)
    {
        Session["Usuarios"] = null;
        Response.Redirect("Default.aspx");

    }
}
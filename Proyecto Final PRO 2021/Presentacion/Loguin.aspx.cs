using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using EntidadesCompartidas;
using Logica;

public partial class Loguin : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        Session["Usuarios"] = null;
    }


    
    protected void btnIngresar_Click(object sender, System.EventArgs e)
    {
        try
        {
            Usuarios unUsuario = LogicaUsuario.Logueo(txtNombreLogueo.Text.Trim(), txtContraseña.Text.Trim());
            if (unUsuario != null)
            {
                Session["Usuarios"] = unUsuario;
                if (unUsuario is Usuarios)
                    Response.Redirect("ProUsuarios.aspx");
            }
            else
                lblError.Text = "Datos Incorrectos";
        }
        catch (Exception ex)
        {
            lblError.Text = ex.Message;
        }
    }
}
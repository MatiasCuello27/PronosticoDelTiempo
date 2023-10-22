using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using EntidadesCompartidas;
using Logica;

public partial class ProUsuarios : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            Usuarios U;

            U = (Usuarios)Session["Usuarios"];
            this.DesActivoBotones();
            this.LimpioControles();
            txtContraseña.Enabled = false;
            txtNombreCompleto.Enabled = false;
        }
    }
    //----------------------------------------------------------
    private void DesActivoBotones()
    {
        btnAlta.Enabled = false;
        btnBaja.Enabled = false;
        btnModificar.Enabled = false;
        txtNombreLogueo.Enabled = true;

    }
    //----------------------------------------------------------

    private void LimpioControles()
    {
        txtNombreLogueo.Text = "";
        txtContraseña.Text = "";
        txtNombreCompleto.Text = "";
        lblError.Text = "";
    }
    //-----------------------------------------------------------
    
    protected void btnAlta_Click1(object sender, EventArgs e)
    {
        try
        {
            Usuarios _unUsuario = null;
            _unUsuario = new Usuarios(txtNombreLogueo.Text.Trim(), (txtContraseña.Text.Trim()), txtNombreCompleto.Text.Trim());
            LogicaUsuario.AltaUsuario(_unUsuario);
            this.DesActivoBotones();
            this.LimpioControles();
            lblError.Text = "Alta con Exito";
            txtContraseña.Enabled = false;
            txtNombreCompleto.Enabled = false;

        }
        catch (Exception ex)
        {
            lblError.Text = ex.Message;
        }
    }
    //--------------------------------------------------------------------------------------------------------------------------
    protected void btnBaja_Click1(object sender, EventArgs e)
    {
        try
        {
            Usuarios _unUsu = (Usuarios)Session["Usuarios"];
            LogicaUsuario.BajaUsuario(_unUsu);
            this.DesActivoBotones();
            this.LimpioControles();
            lblError.Text = "Baja con Exito";
        }
        catch (Exception ex)
        {
            lblError.Text = ex.Message;
        }
    }
    //-------------------------------------------------------------------------------------------------------------------------

    protected void btnModificar_Click1(object sender, EventArgs e)
    {
        try
        {
            Usuarios _unUsu = (Usuarios)Session["Usuarios"];
            _unUsu.Contraseña = txtContraseña.Text.Trim();
            _unUsu.NombreCompleto = txtNombreCompleto.Text.Trim();

            LogicaUsuario.ModificarUsuario(_unUsu);
            this.DesActivoBotones();
            this.LimpioControles();
            lblError.Text = "Modificacion con Exito";
        }
        catch (Exception ex)
        {
            lblError.Text = ex.Message;
        }
    }
    //----------------------------------------------------------------------------------------------------------------------

    protected void btnRefresh_Click(object sender, EventArgs e)
    {
        DesActivoBotones();
        LimpioControles();
        txtContraseña.Enabled = false;
        txtNombreCompleto.Enabled = false;
    }
    //----------------------------------------------------------------------------------------------------------------------
    protected void btnBuscar_Click1(object sender, EventArgs e)
    {
        try
        {
            Usuarios _unUsuario = null;
            _unUsuario = LogicaUsuario.Buscar((txtNombreLogueo.Text).ToString());
            if (_unUsuario == null)
            {
                btnAlta.Enabled = true;
                btnBaja.Enabled = false;
                btnModificar.Enabled = false;
                txtContraseña.Enabled = true;
                txtNombreCompleto.Enabled = true;
                lblError.Text = "REALIZAR ALTA DE USUARIO";

            }
            else
            {

                btnModificar.Enabled = true;
                txtNombreLogueo.Enabled = false;
                txtContraseña.Enabled = true;
                txtNombreCompleto.Enabled = true;
                btnBaja.Enabled = true;
                Session["Usuarios"] = _unUsuario;
                txtNombreLogueo.Text = _unUsuario.NombreLogueo;
                txtContraseña.Text = _unUsuario.Contraseña.ToString();
                txtNombreCompleto.Text = _unUsuario.NombreCompleto;
            }
        }
        catch (Exception ex)
        {
            lblError.Text = ex.Message;
        }
        //----------------------------------------------------------------------------------------------------
    }
}
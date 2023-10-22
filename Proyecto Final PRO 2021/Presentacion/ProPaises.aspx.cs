using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using EntidadesCompartidas;
using Logica;

public partial class ProPaises : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            Usuarios unUsuario;

            unUsuario = (Usuarios)Session["Usuarios"];
            this.DesActivoBotones();
            this.LimpioControles();
            txtCodigoPais.Enabled = true;
            txtNombrePais.Enabled = false;
        }
    }
    //----------------------------------------------------
    private void DesActivoBotones()
    {
        btnAlta.Enabled = false;
        btnBaja.Enabled = false;
        btnModificar.Enabled = false;
        txtCodigoPais.Enabled = true;

    }
    //-----------------------------------------------------
    private void LimpioControles()
    {
        txtCodigoPais.Text = "";
        txtNombrePais.Text = "";
        lblError.Text = "";
    }
    //------------------------------------------------------------------------------------------

    
    protected void btnAlta_Click1(object sender, EventArgs e)
    {
        try
        {
            Paises _unPais = null;
            _unPais = new Paises((txtCodigoPais.Text.Trim()), (txtNombrePais.Text.Trim()));
            LogicaPaises.Agregar(_unPais);
            this.DesActivoBotones();
            this.LimpioControles();
            lblError.Text = "Alta con Exito";



        }
        catch (Exception ex)
        {
            lblError.Text = ex.Message;
        }
    }
    //---------------------------------------------------------------------------------------------------

    protected void btnBaja_Click1(object sender, EventArgs e)
    {
        try
        {
            Paises _unPais = (Paises)Session["UnPais"];
            LogicaPaises.Eliminar(_unPais);
            this.DesActivoBotones();
            this.LimpioControles();
            lblError.Text = "Baja con Exito";
        }
        catch (Exception ex)
        {
            lblError.Text = ex.Message;
        }
    }
    //-----------------------------------------------------------------------------------------------------

    protected void btnModificar_Click1(object sender, EventArgs e)
    {
        try
        {
            Paises _unPais = (Paises)Session["UnPais"];
            _unPais.CodigoPais = txtCodigoPais.Text.Trim();
            _unPais.NombrePais = txtNombrePais.Text.Trim();

            
            LogicaPaises.Modificar(_unPais);

            lblError.Text = "Modificacion con Exito";
            this.DesActivoBotones();
            this.LimpioControles();
        }
        catch (Exception ex)
        {
            lblError.Text = ex.Message;
        }
    }
    //----------------------------------------------------------------------------------------------------

    protected void btnLimpiar_Click1(object sender, EventArgs e)
    {
        DesActivoBotones();
        LimpioControles();
        txtCodigoPais.Enabled = true;
        txtNombrePais.Enabled = false;
    }
    //------------------------------------------------------------------------------------------------------
    protected void btnBuscar_Click(object sender, EventArgs e)
    {
        try
        {
            Paises _unPais = null;
            _unPais = LogicaPaises.Buscar((txtCodigoPais.Text.Trim()));
            if (_unPais == null)
            {
                btnAlta.Enabled = true;
                btnBaja.Enabled = false;
                btnModificar.Enabled = false;

                txtCodigoPais.Enabled = true;
                txtNombrePais.Enabled = true;
                lblError.Text = "CODIGO DE PAIS NO EXISTE- REALIZAR ALTA";

            }
            else
            {
                btnModificar.Enabled = true;
                txtCodigoPais.Enabled = false;
                txtNombrePais.Enabled = true;
                btnBaja.Enabled = true;
                Session["unPais"] = _unPais;
                txtNombrePais.Text = _unPais.NombrePais;
            }
        }
        catch (Exception ex)
        {
            lblError.Text = ex.Message;
        }
    }
    //---------------------------------------------------------------------------------------------------
}
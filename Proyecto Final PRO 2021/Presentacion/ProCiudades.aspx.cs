using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using Logica;
using EntidadesCompartidas;

public partial class ProCiudades : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            Usuarios E = (Usuarios)Session["Usuarios"];
            try
            {
                Session["listaP"] = LogicaPaises.ListarPaises();
                DropDown.DataSource = (List<Paises>)Session["listaP"];
                DropDown.DataValueField = "CodigoPais";
                DropDown.DataTextField = "NombrePais";
                DropDown.DataBind();
                DesActivoBotones();
                LimpioControles();
                txtNombreCiudad.Enabled = false;
            }
            catch (Exception ex)
            {
                lblError.Text = ex.Message;
            }


        }
    }
    //----------------------------------------------------------------------------------------------------------
    private void DesActivoBotones()
    {
        btnAlta.Enabled = false;
        btnBaja.Enabled = false;
        btnModificar.Enabled = false;
        txtCodigoCiudad.Enabled = true;
        txtNombreCiudad.Enabled = false;
    }
    //----------------------------------------------------------------------------------------------------------
    private void LimpioControles()
    {
        txtCodigoCiudad.Text = "";
        txtNombreCiudad.Text = "";
        lblError.Text = "";
    }
    //----------------------------------------------------------------------------------------------------------
    
    
    protected void btnAlta_Click1(object sender, EventArgs e)
    {
        try
        {
            if (DropDown.SelectedIndex >= 0)
            {
                List<Paises> _MiLista = (List<Paises>)Session["listaP"];
                Paises _unPais = _MiLista[DropDown.SelectedIndex];
                Ciudades _unaCiudad = null;


                _unaCiudad = new Ciudades(txtCodigoCiudad.Text.Trim(), txtNombreCiudad.Text.Trim(), _unPais);
                LogicaCiudad.AltaCiudad(_unaCiudad);
                this.DesActivoBotones();
                this.LimpioControles();
                lblError.Text = "Alta con Exito";
                txtNombreCiudad.Enabled = false;
            }

        }
        catch (Exception ex)
        {
            lblError.Text = ex.Message;
        }
    }
    //----------------------------------------------------------------------------------------------------------------


    protected void btnModificar_Click1(object sender, EventArgs e)
    {
        try
        {
            Ciudades _unaCiudad = (Ciudades)Session["UnaCiudad"];
            _unaCiudad.NombreCiudad = txtNombreCiudad.Text.Trim();
            LogicaCiudad.ModificarCiudad(_unaCiudad);
            this.DesActivoBotones();
            this.LimpioControles();

            lblError.Text = "Modificacion con Exito";
        }
        catch (Exception ex)
        {
            lblError.Text = ex.Message;
        }
    }
    //----------------------------------------------------------------------------------------------------------------
    protected void btnLimpiar_Click1(object sender, EventArgs e)
    {
        DesActivoBotones();
        LimpioControles();
        txtNombreCiudad.Enabled = false;
    }
    //----------------------------------------------------------------------------------------------------------------
    protected void btnBuscar_Click(object sender, EventArgs e)
    {
        try
        {
            Ciudades _unaCiudad = null;
            string CodigoPais = DropDown.SelectedItem.Value;
            _unaCiudad = LogicaCiudad.BuscarCiudad(CodigoPais,(txtCodigoCiudad.Text.Trim()));

            if (_unaCiudad == null)
            {
                btnAlta.Enabled = true;
                btnBaja.Enabled = false;
                btnModificar.Enabled = false;

                txtNombreCiudad.Enabled = true;
                lblError.Text = "Codigo Ciudad-No Existe";

            }
            else
            {
                btnModificar.Enabled = true;
                txtCodigoCiudad.Enabled = false;
                txtNombreCiudad.Enabled = true;
                btnBaja.Enabled = true;
                Session["UnaCiudad"] = _unaCiudad;
                txtNombreCiudad.Text = _unaCiudad.NombreCiudad.ToString();
            }
        }
        catch (Exception ex)
        {
            lblError.Text = ex.Message;
        }
    }
    //---------------------------------------------------------------------------------------------------------
    protected void btnBaja_Click(object sender, EventArgs e)
    {
        try
        {
            Ciudades _unaCiudad = (Ciudades)Session["UnaCiudad"];
            LogicaCiudad.Eliminar(_unaCiudad);
            this.DesActivoBotones();
            this.LimpioControles();
            lblError.Text = "Baja con Exito";
        }
        catch (Exception ex)
        {
            lblError.Text = ex.Message;
        }
    }
    //-------------------------------------------------------------------------------------------------------
}
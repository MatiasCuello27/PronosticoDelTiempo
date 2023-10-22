using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using EntidadesCompartidas;
using Logica;

public partial class PROPronosticoPorCiudad : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        try
        {
            lblError.Text = "";

            if (!IsPostBack)
            {
                CargoDatosPais();
            }
        }
        catch (Exception ex)
        {
            lblError.Text = ex.Message;
        }
    }
//--------------------------------------------------------------------------------------------------------
    private void CargoDatosPais()
    {
        try
        {
            List<Paises> pPais = LogicaPaises.ListarPaises();
            Session["ListarPaises"] = pPais;

            if (pPais.Count > 0)
            {
                ddlPais.DataSource = pPais;
                ddlPais.DataTextField = "CodigoPais";
                ddlPais.DataValueField = "CodigoPais";
                ddlPais.DataBind();
                ddlPais.Items.Insert(0, new ListItem("---------------------------------------------"));
            }

            else
            {
                lblError.Text = "No existe ningun Pais Disponible";
            }
        }
        catch (Exception ex)
        {
            lblError.Text = ex.Message;
        }
    }
//------------------------------------------------------------------------------------------------------    
    
    protected void ddlPais_SelectedIndexChanged1(object sender, EventArgs e)
    {
        try
        {
            string codigoP;
            List<Paises> pPais = (List<Paises>)Session["ListarPaises"];
            Paises oPais = null;

            if (ddlPais.SelectedIndex != 0)
                codigoP = ddlPais.SelectedValue;

            else
                throw new Exception("Seleccione un Pais");

            foreach (Paises p in pPais)
            {
                if (p.CodigoPais == codigoP)
                {
                    oPais = p;
                    Session["ListarPaises"] = oPais;
                    break;
                }
            }

            List<Ciudades> CodigoCiudad = LogicaCiudad.ListarCiudadesPorPais(oPais);
            Session["ListarCiudadesPorPais"] = (List<Ciudades>)CodigoCiudad;

            if (CodigoCiudad.Count > 0)
            {
                GRID.DataSource = CodigoCiudad;
                GRID.DataBind();
            }

            else
            {
                GRID.DataSource = null;
                GRID.DataBind();



                throw new Exception("No hay Ciudades Disponibles");
            }
        }
        catch (Exception ex)
        {
            lblError.Text = ex.Message;
        }

    }
    //---------------------------------------------------------------------------------------
    protected void GRID_SelectedIndexChanged(object sender, EventArgs e)
    {
        try
        {
            List<Ciudades> unaCiudad = (List<Ciudades>)Session["ListarCiudadesPorPais"];

            int indice = GRID.SelectedIndex;
            Ciudades CodigoCiudad = unaCiudad[indice];

            List<Pronostico> ColecciondePronostico = LogicaPronostico.ListarPronosticoPorCiudad(CodigoCiudad);

            if (ColecciondePronostico.Count == 0)
            {

                throw new Exception("No hay Ciudades Asociadas");
            }

            else
            {
                gvCiudadPronosticos.DataSource = ColecciondePronostico;
                gvCiudadPronosticos.DataBind();
            }
        }
        catch (Exception ex)
        {
            lblError.Text = ex.Message;
        }
    }
}
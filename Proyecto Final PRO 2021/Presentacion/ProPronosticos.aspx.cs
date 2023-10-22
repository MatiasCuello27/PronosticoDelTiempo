using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using Logica;
using EntidadesCompartidas;

public partial class ProPronosticos : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            Usuarios U = (Usuarios)Session["Usuarios"];
            this.DesActivoBotones();
            this.LimpioControles();
            this.CargoGrilla();
        }
    }
    //--------------------------------------------------------------------------------
    private void CargoGrilla()
    {
        try
        {
      
            Session["listaP"] = LogicaCiudad.ListarCiudad();
            List<Ciudades> _ListP = (List<Ciudades>)Session["listaP"];

            if (_ListP == null)
                lblError.Text = "No hay Ciudad Disponibles !!!";
            else
            {
                GRID.DataSource = (List<Ciudades>)Session["listaP"];
                GRID.DataBind();
            }
        }
        catch (Exception ex)
        {
            lblError.Text = ex.Message;
        }
    }
    //--------------------------------------------------------------------------------
    private void DesActivoBotones()
    {

        txtHora.Enabled = false;
        btnAgregar.Enabled = false;
        txtTemperaturaMax.Enabled = false;
        txtTemperaturaMin.Enabled = false;
        txtVelocidadViento.Enabled = false;
        txtProbabilidadLluvia.Enabled = false;
    }
    //-------------------------------------------------------------------------------
    private void LimpioControles()
    {
        GRID.SelectedIndex = 0;
        txtHora.Text = "";
        txtTemperaturaMax.Text = "";
        txtTemperaturaMin.Text = "";
        txtVelocidadViento.Text = "";
        txtProbabilidadLluvia.Text = "";
        lblError.Text = "";
        lblInfo.Text = "";
    }
    //--------------------------------------------------------------------------------
    protected void btnBuscar_Click(object sender, EventArgs e)
    {
        try
        {
            DateTime Fecha = Convert.ToDateTime(txtHora.Text);

            Pronostico P = LogicaPronostico.BuscarPronosticoDia(Fecha);
            if (P == null)
            {
                lblError.Text = "No existe pronostico Para ese Dia !!!";
                Ciudades UnaC = (Ciudades)Session["Ciudad"];
                Usuarios U = (Usuarios)Session["Usuarios"];
                DateTime unaF = Convert.ToDateTime(txtHora.Text);
                Pronostico unP = new Pronostico(0, unaF, txtHora.Text, Convert.ToInt32(txtTemperaturaMax.Text), Convert.ToInt32(txtTemperaturaMin.Text), Convert.ToInt32(txtVelocidadViento.Text), txtTipodeCielo.Text, Convert.ToInt32(txtProbabilidadLluvia.Text), U, UnaC);
                LogicaPronostico.AltaPronostico(unP);
                lblError.Text = "aaa";
            }
            else
                lblError.Text = "Ya hay prono para ese dia!!!";
        }
        catch (Exception ex)
        {
            lblError.Text = ex.Message;
        }
    }
    //-----------------------------------------------------------------------------------
    
    //------------------------------------------------------------------------------------
    protected void GRID_SelectedIndexChanged(object sender, EventArgs e)
    {
        try
        {
            if (GRID.SelectedIndex >= 0)
            {
                List<Ciudades> _MiLista = (List<Ciudades>)Session["listaP"];
                Ciudades _unaCiudad = _MiLista[GRID.SelectedIndex];
                Session["Ciudad"] = (Ciudades)_unaCiudad;
                lblInfo.Text = _unaCiudad.UnPais.ToString();
                txtFecha.Enabled = true;
                txtHora.Enabled = true;
                txtTemperaturaMax.Enabled = true;
                txtTemperaturaMin.Enabled = true;
                txtProbabilidadLluvia.Enabled = true;
                txtVelocidadViento.Enabled = true;
                btnAgregar.Enabled = true;
            }

        }
        catch (Exception ex)
        {
            lblError.Text = ex.Message;
        }
    }
    //-----------------------------------------------------------------------------------------

    protected void btnAgregar_Click(object sender, EventArgs e)
    {
        try
        {
            if (GRID.SelectedIndex >= 0)
            {
                List<Ciudades> _MiLista = (List<Ciudades>)Session["listaP"];
                Ciudades _unaCiudad = _MiLista[GRID.SelectedIndex];
                Usuarios _unUsuario = (Usuarios)Session["Usuarios"];
                
                DateTime Hora = Convert.ToDateTime(txtHora.Text);
                Pronostico _unPronostico = new Pronostico(0, Convert.ToDateTime(txtFecha.Text), txtHora.Text, Convert.ToInt32(txtTemperaturaMax.Text), Convert.ToInt32(txtTemperaturaMin.Text), Convert.ToInt32(txtVelocidadViento.Text), txtTipodeCielo.Text, Convert.ToInt32(txtProbabilidadLluvia.Text), _unUsuario, _unaCiudad);
                LogicaPronostico.AltaPronostico(_unPronostico);
                DesActivoBotones();
                LimpioControles();
                CargoGrilla();


                lblError.Text = "Pronostico realizada correctamente";
            }
        }
        catch (Exception ex)
        {
            lblError.Text = ex.Message;
        }
    }
    //-------------------------------------------------------------------------------------------
    protected void btnLimpiar_Click(object sender, EventArgs e)
    {
        DesActivoBotones();
        LimpioControles();
    }
    //-------------------------------------------------------------------------------------------
}
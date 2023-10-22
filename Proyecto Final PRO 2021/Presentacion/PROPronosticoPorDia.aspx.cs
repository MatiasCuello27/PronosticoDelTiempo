using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using EntidadesCompartidas;
using Logica;

public partial class PROPronosticoPorDia : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        try
        {
            lblError.Text = "";

            if (!IsPostBack)
            {
                txtFecha.Attributes.Add("Type", "Date");
            }
        }
        catch (Exception ex)
        {
            lblError.Text = ex.Message;
        }
    }

    private void LimpioFormulario()
    {
        txtFecha.Text = "";
        txtFecha.Enabled = true;

        btnConsultar.Enabled = true;
    }



    protected void btnConsultar_Click(object sender, EventArgs e)
    {
        try
        {
            DateTime Fecha;

            try
            {
                Fecha = Convert.ToDateTime(txtFecha.Text);
            }
            catch
            {
                throw new Exception("Ingrese una Fecha");
            }

            List<Pronostico> pPronosticos = LogicaPronostico.ListarPronosticoPorDia(Fecha);

            if (pPronosticos.Count > 0)
            {
                gvPronosticoDia.DataSource = pPronosticos;
                gvPronosticoDia.DataBind();
            }

            else
            {
                lblError.Text = "No hay Pronosticos para la fecha indicada";

                LimpioFormulario();
            }
        }
        catch (Exception ex)
        {
            lblError.Text = ex.Message;
        }
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using EntidadesCompartidas;
using Persistencia;

namespace Logica
{
    public class LogicaPronostico
    {
        public static void AltaPronostico(Pronostico unPro)
        {
            if (unPro.Fecha > DateTime.Now)
                PersistenciaPronostico.Agregar(unPro);
            else
                throw new Exception("La fecha debe ser a Futuro");
        }
        //------------------------------------------------------------------------
        public static List<Pronostico> ListarPronosticoPorDia(DateTime _Fecha)
        {
            return (PersistenciaPronostico.ListarPronosticoPorDia(_Fecha));
        }
        //------------------------------------------------------------------------
        public static List<Pronostico> ListarPronosticoDefault()
        {
            return (PersistenciaPronostico.ListarPronosticoDefault());
        }
        //-------------------------------------------------------------------------
        public static Pronostico BuscarPronosticoDia(DateTime Fecha)
        {
             return (PersistenciaPronostico.BuscarPronoDia(Fecha));
        }
        //-----------------------------------------------------------------------------
        public static List<Pronostico> ListarPronosticoPorCiudad(Ciudades CodigoCiudad)
        {
            return (PersistenciaPronostico.ListarPronosticoPorCiudad(CodigoCiudad));
        }
        //------------------------------------------------------------------------
    }
}

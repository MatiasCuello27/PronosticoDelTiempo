using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using EntidadesCompartidas;
using Persistencia;

namespace Logica
{
    public class LogicaCiudad
    {
        //---------------------------------------------------------------------------------
        public static void AltaCiudad(Ciudades unaCiudad)
        {
            PersistenciaCiudades.Agregar(unaCiudad);
        }

        //----------------------------------------------------------------------------------
        public static void ModificarCiudad(Ciudades unaCiudad)
        {
            PersistenciaCiudades.Modificar(unaCiudad);
        }
        //---------------------------------------------------------------------------------
        public static void Eliminar(Ciudades unaCiudad)
        {
            PersistenciaCiudades.Eliminar(unaCiudad);
        }
        //----------------------------------------------------------------------------------
        public static Ciudades BuscarCiudad(string pCodigoPais, string pCodigoCiudad)
        {
            return PersistenciaCiudades.BuscarCiudad(pCodigoPais, pCodigoCiudad);
        }
        //-----------------------------------------------------------------------------------
        public static List<Ciudades> ListarCiudad()
        {
            return (PersistenciaCiudades.ListarCiudades());
        }
        //-----------------------------------------------------------------------------------
        public static List<Ciudades> ListarCiudadesPorPais(Paises _Pais)
        {
            return PersistenciaCiudades.ListarCiudadesPorPais(_Pais);
        }
    }
}

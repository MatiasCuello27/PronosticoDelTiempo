using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using EntidadesCompartidas;
using Persistencia;

namespace Logica
{
    public class LogicaPaises
    {
        public static void Agregar(Paises unPais)
        {
            PersistenciaPaises.Agregar(unPais);
        }
        //------------------------------------------------------------------

        public static void Modificar(Paises unPais)
        {
            PersistenciaPaises.Modificar(unPais);
        }
        //-----------------------------------------------------------------
        public static void Eliminar(Paises unPais)
        {
            PersistenciaPaises.Eliminar(unPais);
        }
        //--------------------------------------------------------------------
        public static Paises Buscar(string pCodigoPais)
        {
            return (PersistenciaPaises.Buscar(pCodigoPais));
        }
        //--------------------------------------------------------------------
        public static List<Paises> ListarPaises()
        {
            return (PersistenciaPaises.ListarPaises());
        }
        //---------------------------------------------------------------------
    }
}

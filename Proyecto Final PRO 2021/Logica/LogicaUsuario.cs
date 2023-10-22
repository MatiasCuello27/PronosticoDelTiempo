using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using EntidadesCompartidas;
using Persistencia;

namespace Logica
{
    public class LogicaUsuario
    {
        public static Usuarios Logueo(string pUsuario, string pContraseña)
        {
            Usuarios unUsu = null;

    
            unUsu = PersistenciaUsuario.Login(pUsuario, pContraseña);

            
            return unUsu;
        }

        public static void AltaUsuario(Usuarios unUsu)
        {
            PersistenciaUsuario.Agregar(unUsu);
        }

        public static void BajaUsuario(Usuarios unUsu)
        {
            PersistenciaUsuario.Eliminar(unUsu);
        }

        public static void ModificarUsuario(Usuarios unUsu)
        {
            PersistenciaUsuario.Modificar(unUsu);
        }

        public static Usuarios Buscar(string pUsuario)
        {
            return (PersistenciaUsuario.Buscar(pUsuario));
        }
    }
}

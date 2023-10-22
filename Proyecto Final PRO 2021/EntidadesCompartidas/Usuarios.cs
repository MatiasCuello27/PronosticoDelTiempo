using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EntidadesCompartidas
{
    public class Usuarios
    {
        private string _NombreLogueo;
        private string _Contraseña;
        private string _NombreCompleto;

        public string NombreLogueo
        {
            get { return _NombreLogueo; }
            set
            {
                if ((value.Trim().Length > 20) && (value.Trim().Length <= 0))
                    throw new Exception("Error en Nombre Logueo");
                else
                    _NombreLogueo = value;
            }
        }

        public string Contraseña
        {
            get { return _Contraseña; }
            set
            {
                if ((value.Trim().Length > 20) && (value.Trim().Length <= 0))
                    throw new Exception("Error en Contraseña");
                else
                    _Contraseña = value;
            }
        }

        public string NombreCompleto
        {
            get { return _NombreCompleto; }
            set
            {
                if ((value.Trim().Length > 50) || (value.Trim().Length <= 0))
                    throw new Exception("Error en Nombre Completo de Usuario");
                else
                    _NombreCompleto = value;
            }
        }

        public Usuarios(string pNombreLogueo, string pContraseña, string pNombreCompleto)
        {
            NombreLogueo = pNombreLogueo; 
            Contraseña = pContraseña;
            NombreCompleto = pNombreCompleto;
        }

        public override string ToString()
        {
            return (" Nombre Usuario: " + _NombreLogueo +
                    "    Nombre Completo: " + _NombreCompleto);
        }
    }
}

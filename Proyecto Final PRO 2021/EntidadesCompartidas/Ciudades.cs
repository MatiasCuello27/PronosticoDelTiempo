using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EntidadesCompartidas
{
    public class Ciudades
    {
        private string _NombreCiudad;
        private string _CodCiudad;
        private Paises _unPais;


        public string NombreCiudad
        {
            get { return _NombreCiudad; }
            set
            {
                if ((value.Trim().Length > 20) || (value.Trim().Length <= 0))
                    throw new Exception("Error en Ciudad");
                else
                    _NombreCiudad = value;
            }
        }

        public string CodigoCiudad 
        {
            get { return _CodCiudad; }

            set
            {
                if (value.Length == 3)
                    _CodCiudad = value;
                
                else  
                    throw new Exception("El código debe tener exactamente 3 letras");
                
                
            }

        }

        public Paises UnPais
        {
            get { return _unPais; }
            set
            {
                if (value == null)
                    throw new Exception("Se Nececita un Pais");
                else
                    _unPais = value;
            }
        }



        public Ciudades( string pCodigoCiudad, string pNombreCiudad, Paises pCodPais )
        {
            CodigoCiudad = pCodigoCiudad;
            NombreCiudad = pNombreCiudad;
            UnPais = pCodPais;

        }

        public override string ToString()
        {
            return ("Codigo Pais: " + this._unPais.CodigoPais +
                "<br/> Codigo Ciudad : " + _CodCiudad +
                "<br/> Nombre Ciudad: " + _NombreCiudad);
        }
    }
}

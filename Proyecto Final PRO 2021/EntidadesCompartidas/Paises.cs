using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EntidadesCompartidas
{
    public class Paises
    {
        private string _NombrePais;
        private string _CodPais;

        public string NombrePais
        {
            get { return _NombrePais; }
            set
            {
                if ((value.Trim().Length > 20) || (value.Trim().Length <= 0))
                    throw new Exception("Error en Nombre de Pais");
                else
                    _NombrePais = value;
            }
        }

        public string CodigoPais
        {
            get { return _CodPais; }

            set 
                {
                if (value.Length == 3)
                    _CodPais = value;
                else
                     throw new Exception("El código debe tener exactamente 3 letras");
                } 
        }
        



        public Paises (string pCodPais,string pNombrePais)
        {
            
            CodigoPais = pCodPais;
            NombrePais = pNombrePais;
        }

        public override string ToString()
        {
            return ("Codigo Pais: "+ _CodPais +
                "<br/>  Nombre: " + _NombrePais);
        }
    }
}

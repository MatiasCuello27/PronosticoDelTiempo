using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

namespace EntidadesCompartidas
{
    public class Pronostico
    {
        private int _CodRegistro;
        private DateTime fecha;
        private string hora;
        private int _TemperaturaMax;
        private int _TemperaturaMin;
        private int _VelocidadViento;
        private string _TipodeCielo;
        private int _ProbabilidadLluvia;

        private string formatoHora = "^([01]?[0-9]|2[0-3]):[0-5][0-9]$";


        private Usuarios _unUsuario;
        private Ciudades _unaCiudad;
        
        public int CodRegistro
        {
            get { return _CodRegistro; }
            set
            {_CodRegistro = value;}
        }

        public DateTime Fecha
        {
            get { return fecha; }
            set { fecha = value; }
        }

        public string Hora
        {
            get { return hora; }
            set
            {
                if (!Regex.IsMatch(value.ToString(), formatoHora))
                {
                    throw new Exception("El Formato de Hora no es valido, El formato tiene que ser HH:MM:SS");
                }

                hora = value;
            }
        }

        public int TemperaturaMax
        {
            get { return _TemperaturaMax; }
            set
            {
                if ( value < 0 || value > 50 )
                    throw new Exception("Error en la Temperatura Maxima");
                else
                    _TemperaturaMax = value;
            }
        }

        public int TemperaturaMin
        {
            get { return _TemperaturaMin; }
            set
            {
                if (value < 0 || value > 50)
                    throw new Exception("Error en la Temperatura Minima");
                else
                    _TemperaturaMin = value;
            }
        }


        public int VelocidadViento
        {
            get { return _VelocidadViento; }
            set {
                if (value < 0 || value > 100)
                    throw new Exception("Error en la Velocidad del Viento");
                else
                    _VelocidadViento = value;
            }
        }

        public string TipodeCielo
        {
            get { return _TipodeCielo; }
            set
            {
                if (value != "Despejado" && value != "Parcialmente Nuboso" && value != "Nuboso")
                    throw new Exception("Debe elegir uno de los 3 datos");

                _TipodeCielo = value;

            }
        } 

        public int ProbabilidadLluvia
        {
            get { return _ProbabilidadLluvia; }
            set
            {
                if (value < 0 || value > 100)
                    throw new Exception("Error en la Probabilidad de Lluvia");
                else
                    _ProbabilidadLluvia = value;
            }
        }

        public Usuarios unUsuario
        {
            get { return _unUsuario; }
            set
            {
                if (value == null)
                    throw new Exception("Se Nececita un Usuario");
                else
                    _unUsuario = value;
            }
        }

        public Ciudades unaCiudad
        {
            get { return _unaCiudad; }
            set
            {
                if (value == null)
                    throw new Exception("Se Nececita una Ciudad");
                else
                    _unaCiudad = value;
            }
        }



        public Pronostico(int pCodRegistro, DateTime pFecha, string pHora, int pTemperaturaMax,
            int pTemperaturaMin, int pVelocidadViento, string pTipodeCielo, int pProbabilidadLluvia,
            Usuarios pUsuario, Ciudades pCiudad)
        {
            CodRegistro = pCodRegistro;
            Fecha = pFecha;
            Hora = pHora;
            TemperaturaMax = pTemperaturaMax;
            TemperaturaMin = pTemperaturaMin;
            VelocidadViento = pVelocidadViento;
            TipodeCielo = pTipodeCielo;
            ProbabilidadLluvia = pProbabilidadLluvia;
            unUsuario = pUsuario;
            unaCiudad = pCiudad;
            
        }

        public override string ToString()
        {
            return ("Cod. Registro:" + _CodRegistro +
                    "<br/>  Fecha y hora: " +  Fecha.ToShortDateString() +
                    "<br/>  Hora del Pronostico: " + Hora.ToString().Substring(0, 5) +
                    "<br/>  Temperatura Maxima: " + _TemperaturaMax +
                    "<br/>  Temperatura Minima: " + _TemperaturaMin +
                    "<br/>  Velocidad del Viento: " + _VelocidadViento +
                    "<br/>  Tipo de Cielo: " + _TipodeCielo +
                    "<br/>  Probavilidad Lluvia: " + _ProbabilidadLluvia);
        }
    }
}

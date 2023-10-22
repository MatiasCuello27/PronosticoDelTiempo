using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using System.Data.SqlClient;
using System.Data;
using EntidadesCompartidas;

namespace Persistencia
{
    public class PersistenciaPronostico
    {
        //-----------------------------------------------------------------------------------
        public static void Agregar(Pronostico pPronostico)
        {
            SqlConnection oConexion = new SqlConnection(CONEXION.STR);
            SqlCommand oComando = new SqlCommand("AltaPronostico", oConexion);
            oComando.CommandType = CommandType.StoredProcedure;

            oComando.Parameters.AddWithValue("@CodigoCiudad", pPronostico.unaCiudad.CodigoCiudad);
            oComando.Parameters.AddWithValue("@CodigoPais", pPronostico.unaCiudad.UnPais.CodigoPais);
            oComando.Parameters.AddWithValue("@NombreLogueo", pPronostico.unUsuario.NombreLogueo);
            oComando.Parameters.AddWithValue("@Fecha", pPronostico.Fecha);
            oComando.Parameters.AddWithValue("@Hora", pPronostico.Hora);
            oComando.Parameters.AddWithValue("@TemperaturaMax", pPronostico.TemperaturaMax);
            oComando.Parameters.AddWithValue("@TemperaturaMin", pPronostico.TemperaturaMin);
            oComando.Parameters.AddWithValue("@VelocidadViento", pPronostico.VelocidadViento);
            oComando.Parameters.AddWithValue("@TipodeCielo", pPronostico.TipodeCielo);
            oComando.Parameters.AddWithValue("@ProbabilidadLluvia", pPronostico.ProbabilidadLluvia);

            SqlParameter oRetorno = new SqlParameter("@Retorno", SqlDbType.Int);
            oRetorno.Direction = ParameterDirection.ReturnValue;
            oComando.Parameters.Add(oRetorno);

            try
            {
                oConexion.Open();
                oComando.ExecuteNonQuery();

                int oAfectados = (int)oComando.Parameters["@Retorno"].Value;

                if (oAfectados == -1)
                    throw new Exception("Ya Existe Pronostico");
                else if (oAfectados == 0)
                    throw new Exception("Error");
                else if (oAfectados == -2)
                    throw new Exception("No se puede agregar ya existe pais y ciudad asociado a este Pronostico");
                else if (oAfectados == -3)
                    throw new Exception("No se puede agregar, no se permite tener un pronostico con la misma fecha y hora");
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                oConexion.Close();
            }
        }
        //------------------------------------------------------------------------------------------------------
        public static List<Pronostico> ListarPronosticoPorDia(DateTime pfecha)
        {
            int _CodRegistro;
            string _CodigoCiudad;
            string _NombreLogueo;
            DateTime _Fecha;
            string _Hora;
            int _TemperaturaMax;
            int _TemperaturaMin;
            int _VelocidadViento;
            string _TipodeCielo;
            int _ProbabilidadLluvia;
            string _CodigoPais;

            Usuarios UnUsuario;
            Ciudades UnaCiudad;

            List<Pronostico> _Lista = new List<Pronostico>();
            SqlDataReader _Reader;

            SqlConnection _conexion = new SqlConnection(CONEXION.STR);
            SqlCommand _comando = new SqlCommand("ListarPronosticoPorDia", _conexion);
            _comando.CommandType = System.Data.CommandType.StoredProcedure;

            _comando.Parameters.AddWithValue("@fecha", pfecha);

            try
            {
                _conexion.Open();
                _Reader = _comando.ExecuteReader();
                while (_Reader.Read())
                {
                    _CodRegistro = (int)_Reader["CodRegistro"];
                    _TipodeCielo = (string)_Reader["TipodeCielo"];
                    _ProbabilidadLluvia = (int)_Reader["ProbabilidadLluvia"];
                    _VelocidadViento = (int)_Reader["VelocidadViento"];
                    _TemperaturaMin = (int)_Reader["TemperaturaMin"];
                    _Fecha = Convert.ToDateTime(_Reader["Fecha"]);
                    _Hora = _Reader["Hora"].ToString().Substring(0, 5);
                    _TemperaturaMax = (int)_Reader["TemperaturaMax"];
                    _NombreLogueo = (string)_Reader["NombreLogueo"];
                    _CodigoPais = (string)_Reader["CodigoPais"];
                    _CodigoCiudad = (string)_Reader["CodigoCiudad"];

                    UnUsuario = PersistenciaUsuario.Buscar(_NombreLogueo);
                    UnaCiudad = PersistenciaCiudades.BuscarCiudad(_CodigoPais, _CodigoCiudad);
                    Pronostico P = new Pronostico(_CodRegistro, _Fecha, _Hora, _TemperaturaMax, _TemperaturaMin, _VelocidadViento, _TipodeCielo, _ProbabilidadLluvia, UnUsuario, UnaCiudad);
                    _Lista.Add(P);
                }
                _Reader.Close();
            }
            catch (Exception ex)
            {
                throw new ApplicationException("Problemas con la base de datos:" + ex.Message);
            }
            finally
            {
                _conexion.Close();
            }
            return _Lista;
        }
        //---------------------------------------------------------------------------------------------------------
        public static List<Pronostico> ListarPronosticoDefault()
        {
            int _CodRegistro;
            string _CodigoCiudad;
            string _NombreLogueo;
            DateTime _Fecha;
            string _Hora;
            int _TemperaturaMax;
            int _TemperaturaMin;
            int _VelocidadViento;
            string _TipodeCielo;
            int _ProbabilidadLluvia;
            string _CodigoPais;

            List<Pronostico> _Lista = new List<Pronostico>();
            SqlConnection _Conexion = new SqlConnection(CONEXION.STR);
            SqlCommand _Comando = new SqlCommand("ListarPronosticoDefault", _Conexion);
            _Comando.CommandType = System.Data.CommandType.StoredProcedure;
            SqlDataReader _Reader;
            try
            {
                _Conexion.Open();
                _Reader = _Comando.ExecuteReader();
                while (_Reader.Read())
                {
                    _CodRegistro = (int)_Reader["CodRegistro"];
                    _TipodeCielo = (string)_Reader["TipodeCielo"];
                    _ProbabilidadLluvia = (int)_Reader["ProbabilidadLluvia"];
                    _VelocidadViento = (int)_Reader["VelocidadViento"];
                    _TemperaturaMin = (int)_Reader["TemperaturaMin"];
                    _Fecha = Convert.ToDateTime(_Reader["Fecha"]);
                    _Hora = _Reader["Hora"].ToString().Substring(0, 5);
                    _TemperaturaMax = (int)_Reader["TemperaturaMax"];
                    _NombreLogueo = (string)_Reader["NombreLogueo"];
                    _CodigoPais = (string)_Reader["CodigoPais"];
                    _CodigoCiudad = (string)_Reader["CodigoCiudad"];

                    Usuarios _U = PersistenciaUsuario.Buscar(_NombreLogueo);
                    Ciudades _C = PersistenciaCiudades.BuscarCiudad(_CodigoPais, _CodigoCiudad);
                    Pronostico P = new Pronostico(_CodRegistro, _Fecha, _Hora, _TemperaturaMax, _TemperaturaMin, _VelocidadViento, _TipodeCielo, _ProbabilidadLluvia, _U, _C);
                    _Lista.Add(P);
                }
                _Reader.Close();
            }
            catch (Exception ex)
            {
                throw new ApplicationException("Problemas con la base de datos:" + ex.Message);
            }
            finally
            {
                _Conexion.Close();
            }
            return _Lista;
        }

        //-----------------------------------------------------------------------------------------------
        //------------------------------------------------------------------------------------------------
        public static Pronostico BuscarPronoDia(DateTime fecha)
        {
            int _CodRegistro;
            string _CodigoCiudad;
            string _NombreLogueo;
            DateTime _Fecha;
            string _Hora;
            int _TemperaturaMax;
            int _TemperaturaMin;
            int _VelocidadViento;
            string _TipodeCielo;
            int _ProbabilidadLluvia;
            string _CodigoPais;
            Pronostico P = null;


            SqlConnection oConexion = new SqlConnection(CONEXION.STR);
            SqlCommand _comando = new SqlCommand("BuscarPronosticoDia", oConexion);
            _comando.CommandType = System.Data.CommandType.StoredProcedure;
            _comando.Parameters.AddWithValue("@FechaHora", fecha);
            SqlDataReader _Reader;

            try
            {
                oConexion.Open();
                _Reader = _comando.ExecuteReader();
                if (_Reader.Read())
                {
                    _CodRegistro = (int)_Reader["CodRegistro"];
                    _TipodeCielo = (string)_Reader["TipodeCielo"];
                    _ProbabilidadLluvia = (int)_Reader["ProbabilidadLluvia"];
                    _VelocidadViento = (int)_Reader["VelocidadViento"];
                    _TemperaturaMin = (int)_Reader["TemperaturaMin"];
                    _Fecha = Convert.ToDateTime(_Reader["Fecha"]);
                    _Hora = _Reader["Hora"].ToString().Substring(0, 5);
                    _TemperaturaMax = (int)_Reader["TemperaturaMax"];
                    _NombreLogueo = (string)_Reader["NombreLogueo"];
                    _CodigoPais = (string)_Reader["CodigoPais"];
                    _CodigoCiudad = (string)_Reader["CodigoCiudad"];

                    Usuarios _U = PersistenciaUsuario.Buscar(_NombreLogueo);
                    Ciudades _C = PersistenciaCiudades.BuscarCiudad(_CodigoPais, _CodigoCiudad);
                    P = new Pronostico(_CodRegistro, _Fecha, _Hora, _TemperaturaMax, _TemperaturaMin, _VelocidadViento, _TipodeCielo, _ProbabilidadLluvia, _U, _C);
                }
                _Reader.Close();
            }
            catch (Exception ex)
            {
                throw new ApplicationException("Problemas con la base de datos:" + ex.Message);
            }
            finally
            {
                oConexion.Close();
            }
            return P;

        }
        //-----------------------------------------------------------------------------------------------------------------------------
        public static List<Pronostico> ListarPronosticoPorCiudad(Ciudades CodigoCiudad)
        {
            int _CodRegistro;
            string _CodigoCiudad;
            string _Usuario;
            DateTime _Fecha;
            string _Hora;
            int _TemperaturaMax;
            int _TemperaturaMin;
            int _VelocidadViento;
            string _TipodeCielo;
            int _ProbabilidadLluvia;
            string _CodigoPais;

            Usuarios UnUsuario;
            Ciudades UnaCiudad;
            List<Pronostico> unPronosticos = new List<Pronostico>();

            SqlConnection oConexion = new SqlConnection(CONEXION.STR);
            SqlCommand oComando = new SqlCommand("ListarPronosticoPorCiudad", oConexion);
            oComando.CommandType = CommandType.StoredProcedure;

            oComando.Parameters.AddWithValue("@CodigoCiudad", CodigoCiudad.CodigoCiudad);
            oComando.Parameters.AddWithValue("@CodigoPais", CodigoCiudad.UnPais.CodigoPais);

            try
            {
                oConexion.Open();
                SqlDataReader _Reader = oComando.ExecuteReader();

                if (_Reader.HasRows)
                {
                    while (_Reader.Read())
                    {
                        _CodRegistro = (int)_Reader["CodRegistro"];
                        _TipodeCielo = (string)_Reader["TipodeCielo"];
                        _ProbabilidadLluvia = (int)_Reader["ProbabilidadLluvia"];
                        _VelocidadViento = (int)_Reader["VelocidadViento"];
                        _TemperaturaMin = (int)_Reader["TemperaturaMin"];
                        _Fecha = Convert.ToDateTime(_Reader["Fecha"]);
                        _Hora = _Reader["Hora"].ToString().Substring(0, 5);
                        _TemperaturaMax = (int)_Reader["TemperaturaMax"];
                        _Usuario = (string)_Reader["NombreLogueo"];
                        _CodigoPais = (string)_Reader["CodigoPais"];
                        _CodigoCiudad = (string)_Reader["CodigoCiudad"];

                        UnaCiudad = PersistenciaCiudades.BuscarCiudad(_CodigoPais, _CodigoCiudad);

                        UnUsuario = PersistenciaUsuario.Buscar(_Usuario);

                        Pronostico pPronostico = new Pronostico(_CodRegistro, _Fecha, _Hora, _TemperaturaMax, 
                            _TemperaturaMin, _VelocidadViento, _TipodeCielo, _ProbabilidadLluvia, UnUsuario, UnaCiudad);
                        unPronosticos.Add(pPronostico);
                    }

                }

                _Reader.Close();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }

            finally
            {
                oConexion.Close();
            }
            return unPronosticos;
        }
    }
}


using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using System.Data.SqlClient;
using System.Data;
using EntidadesCompartidas;

namespace Persistencia
{
    public class PersistenciaCiudades
    {
        //-----------------------------------------------------------------------------------------
        public static void Agregar(Ciudades pCiudades)
        {
            SqlConnection oConexion = new SqlConnection(CONEXION.STR);
            SqlCommand oComando = new SqlCommand("AltaCiudad", oConexion);
            oComando.CommandType = CommandType.StoredProcedure;

            oComando.Parameters.AddWithValue("@CodigoPais", pCiudades.UnPais.CodigoPais);
            oComando.Parameters.AddWithValue("@CodigoCiudad", pCiudades.CodigoCiudad);
            oComando.Parameters.AddWithValue("@NombreCiudad", pCiudades.NombreCiudad);

            SqlParameter oRetorno = new SqlParameter("@Retorno", SqlDbType.Int);
            oRetorno.Direction = ParameterDirection.ReturnValue;
            oComando.Parameters.Add(oRetorno);

            try
            {
                oConexion.Open();
                oComando.ExecuteNonQuery();

                int oAfectados = (int)oComando.Parameters["@Retorno"].Value;

                if (oAfectados == -1)
                    throw new Exception("Ya Existe esa Ciudad");
                else if (oAfectados == 0)
                    throw new Exception("Error");
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
        //----------------------------------------------------------------------------------------
        public static void Modificar(Ciudades pCiudades)
        {
            SqlConnection oConexion = new SqlConnection(CONEXION.STR);
            SqlCommand oComando = new SqlCommand("ModificarCiudad", oConexion);
            oComando.CommandType = CommandType.StoredProcedure;


            oComando.Parameters.AddWithValue("@CodigoPais", pCiudades.UnPais.CodigoPais);
            oComando.Parameters.AddWithValue("@CodigoCiudad", pCiudades.CodigoCiudad);
            oComando.Parameters.AddWithValue("@NombreCiudad", pCiudades.NombreCiudad);

            SqlParameter oRetorno = new SqlParameter("@Retorno", SqlDbType.Int);
            oRetorno.Direction = ParameterDirection.ReturnValue;
            oComando.Parameters.Add(oRetorno);

            try
            {
                oConexion.Open();
                oComando.ExecuteNonQuery();

                int oAfectados = (int)oComando.Parameters["@Retorno"].Value;

                if (oAfectados == -1)
                    throw new Exception("No existe - No se Modifica");
                else if (oAfectados == 0)
                    throw new Exception("Error");
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
        //------------------------------------------------------------------------------------
        public static void Eliminar(Ciudades pCiudades)
        {
            SqlConnection _STR = new SqlConnection(CONEXION.STR);
            SqlCommand _comando = new SqlCommand("BajaCiudad", _STR);
            _comando.CommandType = System.Data.CommandType.StoredProcedure;

            _comando.Parameters.AddWithValue("@CodigoPais", pCiudades.UnPais.CodigoPais);
            _comando.Parameters.AddWithValue("@CodigoCiudad", pCiudades.CodigoCiudad);
            SqlParameter _retorno = new SqlParameter("@Retorno", System.Data.SqlDbType.Int);
            _retorno.Direction = System.Data.ParameterDirection.ReturnValue;
            _comando.Parameters.Add(_retorno);

            try
            {
                _STR.Open();
                _comando.ExecuteNonQuery();
                if ((int)_retorno.Value == -1)
                    throw new Exception("La Ciudad No Existe");
                else if ((int)_retorno.Value == -2)
                    throw new Exception("Ciudad tiene Pronostico asociado");
                else if ((int)_retorno.Value == -3)
                    throw new Exception("No se pudo eliminar Ciudad");
                else if ((int)_retorno.Value == -4)
                    throw new Exception("Error");
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            finally
            {
                _STR.Close();
            }
        }
        //------------------------------------------------------------------------------------------------
        public static Ciudades BuscarCiudad(string pCodigoPais, string pCodigoCiudad)
        {
            string _CodigoPais;
            string _CodigoCiudad;
            string _NombreCiudad;

            Ciudades C = null;
            Paises P = null;

            SqlConnection oConexion = new SqlConnection(CONEXION.STR);
            SqlCommand _comando = new SqlCommand("BuscarCiudad", oConexion);
            _comando.CommandType = System.Data.CommandType.StoredProcedure;
            _comando.Parameters.AddWithValue("@CodigoPais", pCodigoPais);
            _comando.Parameters.AddWithValue("@CodigoCiudad", pCodigoCiudad);
            SqlDataReader oReader;

            try
            {
                oConexion.Open();
                oReader = _comando.ExecuteReader();
                if (oReader.Read())
                {
                    _CodigoPais = (string)oReader["CodigoPais"];
                    _CodigoCiudad = (string)oReader["CodigoCiudad"];
                    _NombreCiudad = (string)oReader["NombreCiudad"];

                    P = PersistenciaPaises.Buscar(_CodigoPais);
                    C = new Ciudades(_CodigoCiudad, _NombreCiudad, P);
                }
                oReader.Close();
            }
            catch (Exception ex)
            {
                throw new ApplicationException("Problemas con la base de datos:" + ex.Message);
            }
            finally
            {
                oConexion.Close();
            }
            return C;
        }
        //------------------------------------------------------------------------------------------------
        public static List<Ciudades> ListarCiudades()
        {
            List<Ciudades> _lista = new List<Ciudades>();
            SqlDataReader _Reader;
            string _CodigoPais;
            string _CodigoCiudad;
            string _NombreCiudad;


            SqlConnection _Conexion = new SqlConnection(CONEXION.STR);
            SqlCommand _Comando = new SqlCommand("ListarCiudadess", _Conexion);
            _Comando.CommandType = System.Data.CommandType.StoredProcedure;

            try
            {
                _Conexion.Open();
                _Reader = _Comando.ExecuteReader();

                if (_Reader.HasRows)
                {
                    while (_Reader.Read())
                    {
                        _CodigoPais = (string)_Reader["CodigoPais"];
                        _CodigoCiudad = (string)_Reader["CodigoCiudad"];
                        _NombreCiudad = (string)_Reader["NombreCiudad"];

                        Paises P = PersistenciaPaises.Buscar(_CodigoPais);
                        Ciudades C = new Ciudades(_CodigoCiudad,_NombreCiudad , P);
                        _lista.Add(C);
                    }
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
            return _lista;
        }
        //----------------------------------------------------------------------------------------------
        public static List<Ciudades> ListarCiudadesPorPais(Paises oPais)
        {
            Ciudades oCiudad;
            List<Ciudades> cCiudad = new List<Ciudades>();
            SqlDataReader oReader;

            SqlConnection oConexion = new SqlConnection(CONEXION.STR);
            SqlCommand oComando = new SqlCommand("ListarCiudadesPorPais", oConexion);
            oComando.CommandType = CommandType.StoredProcedure;

            oComando.Parameters.AddWithValue("@CodigoPais", oPais.CodigoPais);

            try
            {
                oConexion.Open();
                oReader = oComando.ExecuteReader();

                if (oReader.HasRows)
                {
                    while (oReader.Read())
                    {
                        string CodigoCiudad = oReader["CodigoCiudad"].ToString();
                        string CodigoPais = oReader["CodigoPais"].ToString();
                        string NombreCiudad = oReader["NombreCiudad"].ToString();

                        oCiudad = new Ciudades(CodigoCiudad, NombreCiudad, oPais);
                        cCiudad.Add(oCiudad);
                    }
                }

                oReader.Close();

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }

            finally
            {
                oConexion.Close();
            }

            return cCiudad;
        } 

    }
}

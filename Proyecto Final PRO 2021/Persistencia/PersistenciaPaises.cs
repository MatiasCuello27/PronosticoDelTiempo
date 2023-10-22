using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using System.Data.SqlClient;
using System.Data;
using EntidadesCompartidas;


namespace Persistencia
{
    public class PersistenciaPaises
    {
        //-----------------------------------------------------------------------------------------
        public static void Agregar(Paises pPaises)
        {
            SqlConnection oConexion = new SqlConnection(CONEXION.STR);
            SqlCommand oComando = new SqlCommand("AltaPais", oConexion);
            oComando.CommandType = CommandType.StoredProcedure;

            oComando.Parameters.AddWithValue("@NombrePais", pPaises.NombrePais);
            oComando.Parameters.AddWithValue("@CodigoPais", pPaises.CodigoPais);

            SqlParameter oRetorno = new SqlParameter("@Retorno", SqlDbType.Int);
            oRetorno.Direction = ParameterDirection.ReturnValue;
            oComando.Parameters.Add(oRetorno);

            try
            {
                oConexion.Open();
                oComando.ExecuteNonQuery();

                int oAfectados = (int)oComando.Parameters["@Retorno"].Value;

                if (oAfectados == -1)
                    throw new Exception("Ya Existe el Pais");
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
        public static void Modificar(Paises pPaises)
        {
            SqlConnection oConexion = new SqlConnection(CONEXION.STR);
            SqlCommand oComando = new SqlCommand("ModificarPais", oConexion);
            oComando.CommandType = CommandType.StoredProcedure;

            oComando.Parameters.AddWithValue("@NombrePais", pPaises.NombrePais);
            oComando.Parameters.AddWithValue("@CodigoPais", pPaises.CodigoPais);

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
        public static void Eliminar(Paises pPaises)
        {
            SqlConnection _STR = new SqlConnection(CONEXION.STR);
            SqlCommand _comando = new SqlCommand("BajaPais", _STR);
            _comando.CommandType = System.Data.CommandType.StoredProcedure;

            _comando.Parameters.AddWithValue("@CodigoPais", pPaises.CodigoPais);
            SqlParameter _retorno = new SqlParameter("@Retorno", System.Data.SqlDbType.Int);
            _retorno.Direction = System.Data.ParameterDirection.ReturnValue;
            _comando.Parameters.Add(_retorno);

            try
            {
                _STR.Open();
                _comando.ExecuteNonQuery();

                if ((int)_retorno.Value == -1)
                    throw new Exception("El Pais No Existe");
                else if ((int)_retorno.Value == -2)
                    throw new Exception("El Pais tiene Pronostico asociado");
                else if ((int)_retorno.Value == -3)
                    throw new Exception("No se pudo eliminar el Pais");
                else if ((int)_retorno.Value == -4)
                    throw new Exception("Error");
            }
            catch (Exception ex)
            {
                throw new ApplicationException("Problemas con la base de datos:" + ex.Message);
            }
            finally
            {
                _STR.Close();
            }
        }
        //-------------------------------------------------------------------------------------------------
        public static Paises Buscar(string pCodigoPais)
        {
            SqlConnection _STR = new SqlConnection(CONEXION.STR);
            Paises _unPais = null;

            SqlCommand _comando = new SqlCommand("BuscarPais", _STR);
            _comando.CommandType = System.Data.CommandType.StoredProcedure;
            _comando.Parameters.AddWithValue("@CodigoPais", pCodigoPais);

            try
            {
                _STR.Open();
                SqlDataReader _lector = _comando.ExecuteReader();
                if (_lector.HasRows)
                {
                    _lector.Read();
                    _unPais = new Paises(pCodigoPais, (string)_lector["NombrePais"]);
                }
            }
            catch (Exception ex)
            {
                throw new ApplicationException("Problemas con la base de datos:" + ex.Message);
            }
            finally
            {
                _STR.Close();
            }
            return _unPais;
        }
        //----------------------------------------------------------------------------------------------------------
        public static List<Paises> ListarPaises()
        {
            List<Paises> _lista = new List<Paises>(); ;
            SqlDataReader _Reader;

            SqlConnection _Conexion = new SqlConnection(CONEXION.STR);
            SqlCommand _Comando = new SqlCommand("ListarPaises", _Conexion);
            _Comando.CommandType = CommandType.StoredProcedure;

            try
            {
                _Conexion.Open();
                _Reader = _Comando.ExecuteReader();

                if (_Reader.HasRows)
                {
                    while (_Reader.Read())
                    {
                        Paises P = new Paises (_Reader["CodigoPais"].ToString(),
                            _Reader["NombrePais"].ToString());
                        _lista.Add(P);
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
        //-----------------------------------------------------------------------------------------------------------------------
    }
}

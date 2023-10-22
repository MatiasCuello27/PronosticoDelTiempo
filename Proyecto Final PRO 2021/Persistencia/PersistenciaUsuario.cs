using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using System.Data.SqlClient;
using System.Data;
using EntidadesCompartidas;

namespace Persistencia
{
    public class PersistenciaUsuario
    {
        //-----------------------------------------------------------------------------------------
        public static Usuarios Login(string pUsuario, string pContraseña)
        {
            SqlConnection _Conexion = new SqlConnection(CONEXION.STR);
            SqlCommand _comando = new SqlCommand("LogueoUsuario", _Conexion);
            _comando.CommandType = CommandType.StoredProcedure;
            Usuarios unUsu = null;

            _comando.Parameters.AddWithValue("@NombreLogueo", pUsuario);
            _comando.Parameters.AddWithValue("@Contraseña", pContraseña);

            try
            {
                _Conexion.Open();
                SqlDataReader _lector = _comando.ExecuteReader();
                if (_lector.HasRows)
                {
                    _lector.Read();
                    string _NombreLogueo = (string)_lector["NombreLogueo"];
                    string _Contraseña = (string)_lector["Contraseña"];
                    string _NombreCompleto = (string)_lector["NombreCompleto"];
                    unUsu = new Usuarios(_NombreLogueo, _Contraseña, _NombreCompleto);
                }
                _lector.Close();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                _Conexion.Close();
            }
            return unUsu;
        }
        //-----------------------------------------------------------------------------------------
        public static void Agregar(Usuarios pUsuario)
        {
            SqlConnection oConexion = new SqlConnection(CONEXION.STR);
            SqlCommand oComando = new SqlCommand("AltaUsuario", oConexion);
            oComando.CommandType = CommandType.StoredProcedure;

            oComando.Parameters.AddWithValue("@NombreLogueo", pUsuario.NombreLogueo);
            oComando.Parameters.AddWithValue("@Contraseña", pUsuario.Contraseña);
            oComando.Parameters.AddWithValue("@NombreCompleto", pUsuario.NombreCompleto);

            SqlParameter oRetorno = new SqlParameter("@Retorno", SqlDbType.Int);
            oRetorno.Direction = ParameterDirection.ReturnValue;
            oComando.Parameters.Add(oRetorno);

            try
            {
                oConexion.Open();
                oComando.ExecuteNonQuery();

                int oAfectados = (int)oComando.Parameters["@Retorno"].Value;

                if (oAfectados == 1)
                    throw new Exception("Ya Existe Usuario");
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
        public static void Modificar(Usuarios pUsuario)
        {
            SqlConnection oConexion = new SqlConnection(CONEXION.STR);
            SqlCommand oComando = new SqlCommand("ModificarUsuario", oConexion);
            oComando.CommandType = CommandType.StoredProcedure;

            oComando.Parameters.AddWithValue("@NombreLogueo", pUsuario.NombreLogueo);
            oComando.Parameters.AddWithValue("@Contraseña", pUsuario.Contraseña);
            oComando.Parameters.AddWithValue("@NombreCompleto", pUsuario.NombreCompleto);

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
        public static Usuarios Buscar(string pNombreLogueo)
        {
            string oNombreLogueo, oContraseña, oNombreCompleto;

            Usuarios p = null;
            

            SqlConnection oConexion = new SqlConnection(CONEXION.STR);
            SqlCommand oComando = new SqlCommand("Exec BuscaUsuario " + pNombreLogueo, oConexion);

            SqlDataReader oReader;

            try
            {
                oConexion.Open();
                oReader = oComando.ExecuteReader();

                if (oReader.Read())
                {
                    oNombreLogueo =(string)oReader["NombreLogueo"];
                    oContraseña = (string)oReader["Contraseña"];
                    oNombreCompleto =(string)oReader["NombreCompleto"];

                    p=new Usuarios (oNombreLogueo, oContraseña, oNombreCompleto);
                }
                oReader.Close();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                oConexion.Close();
            }
            return p;

        }
        //-----------------------------------------------------------------------------------
        public static void Eliminar(Usuarios pUsuario)
        {
            SqlConnection oConexion = new SqlConnection(CONEXION.STR);
            SqlCommand oComando = new SqlCommand("BajaUsuario", oConexion);
            oComando.CommandType = CommandType.StoredProcedure;

            SqlParameter oNombreLogueo = new SqlParameter("@NombreLogueo", pUsuario.NombreLogueo);

            SqlParameter oRetorno = new SqlParameter("@Retorno", SqlDbType.Int);
            oRetorno.Direction = ParameterDirection.ReturnValue;

            oComando.Parameters.Add(oNombreLogueo);
            oComando.Parameters.Add(oRetorno);

            try
            {
                oConexion.Open();
                oComando.ExecuteNonQuery();

                int oAfectados = (int)oComando.Parameters["@Retorno"].Value;

                if (oAfectados == -1)
                    throw new Exception("No Existe Usuario - No se Elimina");
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
    }
}

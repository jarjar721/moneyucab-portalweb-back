using Comunes.Comun;
using DAO.Interfaces;
using Excepciones;
using Excepciones.Excepciones_Especificas;
using Npgsql;
using System;
using System.Collections.Generic;

namespace DAO
{
    /// <summary>
    /// Class <c>DAOLogin</c>
    /// Establece la clase para el manejo de datos query a través de PostgreSQL.
    /// </summary>
    public class DAOBase : DAOPsql, IDAO
    {

        /// <summary>
        /// Establece la creación del DAO para el manejo del módulo de ingreso a través de la base de datos.
        /// </summary>
        public DAOBase()
        {
            NpgsqlConnectionStringBuilder conn_string = new NpgsqlConnectionStringBuilder();
            conn_string.Host = "127.0.0.1";
            conn_string.Port = 5432;
            conn_string.Username = "postgres";
            //conn_string.Password = "lolazo123";
            conn_string.Password = "escudero22";                
            //conn_string.Database = "postgres";
            conn_string.Database = "Desarrollo";        
            //StringConexion = ConfigurationManager.AppSettings.Get("IdentityConnection");
            stringConexion = conn_string.ToString();
        }

        //Operaciones de consulta---------------------------------------------------------------
        public List<ComEstadoCivil> EstadosCiviles()
        {

            //log.Debug("Entrando al metodo: " + MethodBase.GetCurrentMethod().Name);

            try
            {
                Conectar();

                comandoSQL = conector.CreateCommand();

                comandoSQL.CommandText = string.Format("SELECT * FROM Estados_Civiles();");
                lectorTablaSQL = comandoSQL.ExecuteReader();
                List<ComEstadoCivil> estadosCiviles = new List<ComEstadoCivil>();
                ComEstadoCivil row;
                while (lectorTablaSQL.Read())
                {
                    row = new ComEstadoCivil();
                    row.LlenadoDataNpgsql(lectorTablaSQL);
                    estadosCiviles.Add(row);
                }
                return estadosCiviles;
            }
            catch (NpgsqlException ex)
            {
                //Manejo de errores para el cierre de la conexión.
                //Logger para el manejo de errores
                //log.Error("Error en la conexion a base de datos", ex);
                Desconectar();
                throw new NpgsqlException();
            }
            catch (Exception ex)
            {
                //log.Error("Error en la conexion a base de datos", ex);
                Desconectar();
                throw new MoneyUcabException(ex, "Error Desconocido", 1);
            }
            finally
            {
                Desconectar();
            }
        }

        public List<ComTipoTarjeta> TiposTarjeta()
        {

            //log.Debug("Entrando al metodo: " + MethodBase.GetCurrentMethod().Name);

            try
            {
                Conectar();

                comandoSQL = conector.CreateCommand();

                comandoSQL.CommandText = string.Format("SELECT * FROM tipos_tarjeta();");
                lectorTablaSQL = comandoSQL.ExecuteReader();
                List<ComTipoTarjeta> tiposTarjetas = new List<ComTipoTarjeta>();
                ComTipoTarjeta row = new ComTipoTarjeta();
                while (lectorTablaSQL.Read())
                {
                    row = new ComTipoTarjeta();
                    row.LlenadoDataNpgsql(lectorTablaSQL);
                    tiposTarjetas.Add(row);
                }
                return tiposTarjetas;
            }
            catch (NpgsqlException ex)
            {
                //Manejo de errores para el cierre de la conexión.
                //Logger para el manejo de errores
                //log.Error("Error en la conexion a base de datos", ex);
                Desconectar();
                throw new NpgsqlException();
            }
            catch (Exception ex)
            {
                //log.Error("Error en la conexion a base de datos", ex);
                Desconectar();
                throw new MoneyUcabException(ex, "Error Desconocido", 1);
            }
            finally
            {
                Desconectar();
            }

            /*if (afectados == 0) throw new UsuarioInexistenteException();
            if (afectados > 1) throw new LotoUcabException("Usiarios duplicados en Base de datos", 1);*/
        }

        public List<ComBanco> Bancos()
        {

            //log.Debug("Entrando al metodo: " + MethodBase.GetCurrentMethod().Name);

            try
            {
                Conectar();

                comandoSQL = conector.CreateCommand();

                comandoSQL.CommandText = string.Format("SELECT * FROM Bancos();");
                lectorTablaSQL = comandoSQL.ExecuteReader();
                List<ComBanco> bancos = new List<ComBanco>();
                ComBanco row;
                while (lectorTablaSQL.Read())
                {
                    row = new ComBanco();
                    row.LlenadoDataNpgsql(lectorTablaSQL);
                    bancos.Add(row);
                }
                return bancos;
            }
            catch (NpgsqlException ex)
            {
                //Manejo de errores para el cierre de la conexión.
                //Logger para el manejo de errores
                //log.Error("Error en la conexion a base de datos", ex);
                Desconectar();
                throw ex;
            }
            catch (Exception ex)
            {
                //log.Error("Error en la conexion a base de datos", ex);
                Desconectar();
                throw new MoneyUcabException(ex, "Error Desconocido", 1);
            }
            finally
            {
                Desconectar();
            }

            /*if (afectados == 0) throw new UsuarioInexistenteException();
            if (afectados > 1) throw new LotoUcabException("Usiarios duplicados en Base de datos", 1);*/
        }

        public List<ComTipoCuenta> TiposCuentas()
        {

            //log.Debug("Entrando al metodo: " + MethodBase.GetCurrentMethod().Name);

            try
            {
                Conectar();

                comandoSQL = conector.CreateCommand();

                comandoSQL.CommandText = string.Format("SELECT * FROM Tipos_Cuentas();");
                lectorTablaSQL = comandoSQL.ExecuteReader();
                List<ComTipoCuenta> tiposCuentas = new List<ComTipoCuenta>();
                ComTipoCuenta row;
                while (lectorTablaSQL.Read())
                {
                    row = new ComTipoCuenta();
                    row.LlenadoDataNpgsql(lectorTablaSQL);
                    tiposCuentas.Add(row);
                }
                return tiposCuentas;
            }
            catch (NpgsqlException ex)
            {
                //Manejo de errores para el cierre de la conexión.
                //Logger para el manejo de errores
                //log.Error("Error en la conexion a base de datos", ex);
                Desconectar();
                throw ex;
            }
            catch (Exception ex)
            {
                //log.Error("Error en la conexion a base de datos", ex);
                Desconectar();
                throw new MoneyUcabException(ex, "Error Desconocido", 1);
            }
            finally
            {
                Desconectar();
            }

            /*if (afectados == 0) throw new UsuarioInexistenteException();
            if (afectados > 1) throw new LotoUcabException("Usiarios duplicados en Base de datos", 1);*/
        }

        public List<ComTipoParametro> TiposParametros()
        {

            //log.Debug("Entrando al metodo: " + MethodBase.GetCurrentMethod().Name);

            try
            {
                Conectar();

                comandoSQL = conector.CreateCommand();

                comandoSQL.CommandText = string.Format("SELECT * FROM Tipos_Parametros();");
                lectorTablaSQL = comandoSQL.ExecuteReader();
                List<ComTipoParametro> tiposParametros = new List<ComTipoParametro>();
                ComTipoParametro row;
                while (lectorTablaSQL.Read())
                {
                    row = new ComTipoParametro();
                    row.LlenadoDataNpgsql(lectorTablaSQL);
                    tiposParametros.Add(row);
                }
                return tiposParametros;
            }
            catch (NpgsqlException ex)
            {
                //Manejo de errores para el cierre de la conexión.
                //Logger para el manejo de errores
                //log.Error("Error en la conexion a base de datos", ex);
                Desconectar();
                throw ex;
            }
            catch (Exception ex)
            {
                //log.Error("Error en la conexion a base de datos", ex);
                Desconectar();
                throw new MoneyUcabException(ex, "Error Desconocido", 1);
            }
            finally
            {
                Desconectar();
            }

            /*if (afectados == 0) throw new UsuarioInexistenteException();
            if (afectados > 1) throw new LotoUcabException("Usiarios duplicados en Base de datos", 1);*/
        }

        public List<ComFrecuencia> Frecuencias()
        {

            //log.Debug("Entrando al metodo: " + MethodBase.GetCurrentMethod().Name);

            try
            {
                Conectar();

                comandoSQL = conector.CreateCommand();

                comandoSQL.CommandText = string.Format("SELECT * FROM Frecuencias();");
                lectorTablaSQL = comandoSQL.ExecuteReader();
                List<ComFrecuencia> frecuencias = new List<ComFrecuencia>();
                ComFrecuencia row;
                while (lectorTablaSQL.Read())
                {
                    row = new ComFrecuencia();
                    row.LlenadoDataNpgsql(lectorTablaSQL);
                    frecuencias.Add(row);
                }
                return frecuencias;
            }
            catch (NpgsqlException ex)
            {
                //Manejo de errores para el cierre de la conexión.
                //Logger para el manejo de errores
                //log.Error("Error en la conexion a base de datos", ex);
                Desconectar();
                throw ex;
            }
            catch (Exception ex)
            {
                //log.Error("Error en la conexion a base de datos", ex);
                Desconectar();
                throw new MoneyUcabException(ex, "Error Desconocido", 1);
            }
            finally
            {
                Desconectar();
            }

            /*if (afectados == 0) throw new UsuarioInexistenteException();
            if (afectados > 1) throw new LotoUcabException("Usiarios duplicados en Base de datos", 1);*/
        }

        public List<ComParametro> Parametros()
        {

            //log.Debug("Entrando al metodo: " + MethodBase.GetCurrentMethod().Name);

            try
            {
                Conectar();

                comandoSQL = conector.CreateCommand();

                comandoSQL.CommandText = string.Format("SELECT * FROM Parametros();");
                lectorTablaSQL = comandoSQL.ExecuteReader();
                List<ComParametro> parametros = new List<ComParametro>();
                ComParametro row;
                while (lectorTablaSQL.Read())
                {
                    row = new ComParametro();
                    row.LlenadoDataNpgsql(lectorTablaSQL);
                    parametros.Add(row);
                }
                return parametros;
            }
            catch (NpgsqlException ex)
            {
                //Manejo de errores para el cierre de la conexión.
                //Logger para el manejo de errores
                //log.Error("Error en la conexion a base de datos", ex);
                Desconectar();
                throw ex;
            }
            catch (Exception ex)
            {
                //log.Error("Error en la conexion a base de datos", ex);
                Desconectar();
                throw new MoneyUcabException(ex, "Error Desconocido", 1);
            }
            finally
            {
                Desconectar();
            }

            /*if (afectados == 0) throw new UsuarioInexistenteException();
            if (afectados > 1) throw new LotoUcabException("Usiarios duplicados en Base de datos", 1);*/
        }

        public List<ComTipoOperacion> TiposOperaciones()
        {

            //log.Debug("Entrando al metodo: " + MethodBase.GetCurrentMethod().Name);

            try
            {
                Conectar();

                comandoSQL = conector.CreateCommand();

                comandoSQL.CommandText = string.Format("SELECT * FROM Tipos_Operaciones();");
                lectorTablaSQL = comandoSQL.ExecuteReader();
                List<ComTipoOperacion> tiposOperaciones = new List<ComTipoOperacion>();
                ComTipoOperacion row;
                while (lectorTablaSQL.Read())
                {
                    row = new ComTipoOperacion();
                    row.LlenadoDataNpgsql(lectorTablaSQL);
                    tiposOperaciones.Add(row);
                }
                return tiposOperaciones;
            }
            catch (NpgsqlException ex)
            {
                //Manejo de errores para el cierre de la conexión.
                //Logger para el manejo de errores
                //log.Error("Error en la conexion a base de datos", ex);
                Desconectar();
                throw ex;
            }
            catch (Exception ex)
            {
                //log.Error("Error en la conexion a base de datos", ex);
                Desconectar();
                throw new MoneyUcabException(ex, "Error Desconocido", 1);
            }
            finally
            {
                Desconectar();
            }

            /*if (afectados == 0) throw new UsuarioInexistenteException();
            if (afectados > 1) throw new LotoUcabException("Usiarios duplicados en Base de datos", 1);*/
        }

        public List<ComTipoIdentificacion> TiposIdentificaciones()
        {

            //log.Debug("Entrando al metodo: " + MethodBase.GetCurrentMethod().Name);

            try
            {
                Conectar();

                comandoSQL = conector.CreateCommand();

                comandoSQL.CommandText = string.Format("SELECT * FROM Tipos_Identificaciones();");
                lectorTablaSQL = comandoSQL.ExecuteReader();
                List<ComTipoIdentificacion> tiposIdentificaciones = new List<ComTipoIdentificacion>();
                ComTipoIdentificacion row;
                while (lectorTablaSQL.Read())
                {
                    row = new ComTipoIdentificacion();
                    row.LlenadoDataNpgsql(lectorTablaSQL);
                    tiposIdentificaciones.Add(row);
                }
                return tiposIdentificaciones;
            }
            catch (NpgsqlException ex)
            {
                //Manejo de errores para el cierre de la conexión.
                //Logger para el manejo de errores
                //log.Error("Error en la conexion a base de datos", ex);
                Desconectar();
                throw ex;
            }
            catch (Exception ex)
            {
                //log.Error("Error en la conexion a base de datos", ex);
                Desconectar();
                throw new MoneyUcabException(ex, "Error Desconocido", 1);
            }
            finally
            {
                Desconectar();
            }

            /*if (afectados == 0) throw new UsuarioInexistenteException();
            if (afectados > 1) throw new LotoUcabException("Usiarios duplicados en Base de datos", 1);*/
        }

        public List<ComTarjeta> Tarjetas(int IdUsuario)
        {

            //log.Debug("Entrando al metodo: " + MethodBase.GetCurrentMethod().Name);

            try
            {
                Conectar();

                comandoSQL = conector.CreateCommand();

                comandoSQL.CommandText = string.Format("SELECT * FROM Tarjetas(@UsuarioId);");
                comandoSQL.Parameters.Add(new NpgsqlParameter("UsuarioId", IdUsuario));
                lectorTablaSQL = comandoSQL.ExecuteReader();
                List<ComTarjeta> tarjetas = new List<ComTarjeta>();
                ComTarjeta row;
                while (lectorTablaSQL.Read())
                {
                    row = new ComTarjeta();
                    row.LlenadoDataNpgsql(lectorTablaSQL);
                    tarjetas.Add(row);
                }
                return tarjetas;
            }
            catch (NpgsqlException ex)
            {
                //Manejo de errores para el cierre de la conexión.
                //Logger para el manejo de errores
                //log.Error("Error en la conexion a base de datos", ex);
                Desconectar();
                throw ex;
            }
            catch (Exception ex)
            {
                //log.Error("Error en la conexion a base de datos", ex);
                Desconectar();
                throw new MoneyUcabException(ex, "Error Desconocido", 1);
            }
            finally
            {
                Desconectar();
            }

            /*if (afectados == 0) throw new UsuarioInexistenteException();
            if (afectados > 1) throw new LotoUcabException("Usiarios duplicados en Base de datos", 1);*/
        }

        public List<ComCuenta> Cuentas(int IdUsuario)
        {

            //log.Debug("Entrando al metodo: " + MethodBase.GetCurrentMethod().Name);

            try
            {
                Conectar();

                comandoSQL = conector.CreateCommand();

                comandoSQL.CommandText = string.Format("SELECT * FROM Cuentas(@UsuarioId);");
                comandoSQL.Parameters.Add(new NpgsqlParameter("UsuarioId", IdUsuario));
                lectorTablaSQL = comandoSQL.ExecuteReader();
                List<ComCuenta> cuentas = new List<ComCuenta>();
                ComCuenta row;
                while (lectorTablaSQL.Read())
                {
                    row = new ComCuenta();
                    row.LlenadoDataNpgsql(lectorTablaSQL);
                    cuentas.Add(row);
                }
                return cuentas;
            }
            catch (NpgsqlException ex)
            {
                //Manejo de errores para el cierre de la conexión.
                //Logger para el manejo de errores
                //log.Error("Error en la conexion a base de datos", ex);
                Desconectar();
                throw ex;
            }
            catch (Exception ex)
            {
                //log.Error("Error en la conexion a base de datos", ex);
                Desconectar();
                throw new MoneyUcabException(ex, "Error Desconocido", 1);
            }
            finally
            {
                Desconectar();
            }

            /*if (afectados == 0) throw new UsuarioInexistenteException();
            if (afectados > 1) throw new LotoUcabException("Usiarios duplicados en Base de datos", 1);*/
        }

        public List<ComReintegro> ReintegrosActivos(int IdUsuario, int Solicitante)
        {

            //log.Debug("Entrando al metodo: " + MethodBase.GetCurrentMethod().Name);

            try
            {
                Conectar();

                comandoSQL = conector.CreateCommand();

                comandoSQL.CommandText = string.Format("SELECT * FROM Reintegros_Activos(@UsuarioId, @solicitante);");
                comandoSQL.Parameters.Add(new NpgsqlParameter("UsuarioId", IdUsuario));
                comandoSQL.Parameters.Add(new NpgsqlParameter("solicitante", Solicitante));
                lectorTablaSQL = comandoSQL.ExecuteReader();
                List<ComReintegro> reintegros = new List<ComReintegro>();
                ComReintegro row;
                while (lectorTablaSQL.Read())
                {
                    row = new ComReintegro();
                    row.LlenadoDataNpgsql(lectorTablaSQL);
                    reintegros.Add(row);
                }
                return reintegros;
            }
            catch (NpgsqlException ex)
            {
                //Manejo de errores para el cierre de la conexión.
                //Logger para el manejo de errores
                //log.Error("Error en la conexion a base de datos", ex);
                Desconectar();
                throw ex;
            }
            catch (Exception ex)
            {
                //log.Error("Error en la conexion a base de datos", ex);
                Desconectar();
                throw new MoneyUcabException(ex, "Error Desconocido", 1);
            }
            finally
            {
                Desconectar();
            }

            /*if (afectados == 0) throw new UsuarioInexistenteException();
            if (afectados > 1) throw new LotoUcabException("Usiarios duplicados en Base de datos", 1);*/
        }

        public List<ComReintegro> ReintegrosCancelados(int IdUsuario, int Solicitante)
        {

            //log.Debug("Entrando al metodo: " + MethodBase.GetCurrentMethod().Name);

            try
            {
                Conectar();

                comandoSQL = conector.CreateCommand();

                comandoSQL.CommandText = string.Format("SELECT * FROM Reintegros_Cancelados(@UsuarioId, @solicitante);");
                comandoSQL.Parameters.Add(new NpgsqlParameter("UsuarioId", IdUsuario));
                comandoSQL.Parameters.Add(new NpgsqlParameter("solicitante", Solicitante));
                lectorTablaSQL = comandoSQL.ExecuteReader();
                List<ComReintegro> reintegros = new List<ComReintegro>();
                ComReintegro row;
                while (lectorTablaSQL.Read())
                {
                    row = new ComReintegro();
                    row.LlenadoDataNpgsql(lectorTablaSQL);
                    reintegros.Add(row);
                }
                return reintegros;
            }
            catch (NpgsqlException ex)
            {
                //Manejo de errores para el cierre de la conexión.
                //Logger para el manejo de errores
                //log.Error("Error en la conexion a base de datos", ex);
                Desconectar();
                throw ex;
            }
            catch (Exception ex)
            {
                //log.Error("Error en la conexion a base de datos", ex);
                Desconectar();
                throw new MoneyUcabException(ex, "Error Desconocido", 1);
            }
            finally
            {
                Desconectar();
            }

            /*if (afectados == 0) throw new UsuarioInexistenteException();
            if (afectados > 1) throw new LotoUcabException("Usiarios duplicados en Base de datos", 1);*/
        }

        public List<ComReintegro> ReintegrosExitosos(int IdUsuario, int Solicitante)
        {

            //log.Debug("Entrando al metodo: " + MethodBase.GetCurrentMethod().Name);

            try
            {
                Conectar();

                comandoSQL = conector.CreateCommand();

                comandoSQL.CommandText = string.Format("SELECT * FROM Reintegros_Exitosos(@UsuarioId, @solicitante);");
                comandoSQL.Parameters.Add(new NpgsqlParameter("UsuarioId", IdUsuario));
                comandoSQL.Parameters.Add(new NpgsqlParameter("solicitante", Solicitante));
                lectorTablaSQL = comandoSQL.ExecuteReader();
                List<ComReintegro> reintegros = new List<ComReintegro>();
                ComReintegro row;
                while (lectorTablaSQL.Read())
                {
                    row = new ComReintegro();
                    row.LlenadoDataNpgsql(lectorTablaSQL);
                    reintegros.Add(row);
                }
                return reintegros;
            }
            catch (NpgsqlException ex)
            {
                //Manejo de errores para el cierre de la conexión.
                //Logger para el manejo de errores
                //log.Error("Error en la conexion a base de datos", ex);
                Desconectar();
                throw ex;
            }
            catch (Exception ex)
            {
                //log.Error("Error en la conexion a base de datos", ex);
                Desconectar();
                throw new MoneyUcabException(ex, "Error Desconocido", 1);
            }
            finally
            {
                Desconectar();
            }

            /*if (afectados == 0) throw new UsuarioInexistenteException();
            if (afectados > 1) throw new LotoUcabException("Usiarios duplicados en Base de datos", 1);*/
        }

        public List<ComPago> CobrosActivos(int IdUsuario, int Solicitante)
        {

            //log.Debug("Entrando al metodo: " + MethodBase.GetCurrentMethod().Name);

            try
            {
                Conectar();

                comandoSQL = conector.CreateCommand();

                comandoSQL.CommandText = string.Format("SELECT * FROM Cobros_Activos(@UsuarioId, @solicitante);");
                comandoSQL.Parameters.Add(new NpgsqlParameter("UsuarioId", IdUsuario));
                comandoSQL.Parameters.Add(new NpgsqlParameter("solicitante", Solicitante));
                lectorTablaSQL = comandoSQL.ExecuteReader();
                List<ComPago> cobros = new List<ComPago>();
                ComPago row;
                while (lectorTablaSQL.Read())
                {
                    row = new ComPago();
                    row.LlenadoDataNpgsql(lectorTablaSQL);
                    cobros.Add(row);
                }
                return cobros;
            }
            catch (NpgsqlException ex)
            {
                //Manejo de errores para el cierre de la conexión.
                //Logger para el manejo de errores
                //log.Error("Error en la conexion a base de datos", ex);
                Desconectar();
                throw ex;
            }
            catch (Exception ex)
            {
                //log.Error("Error en la conexion a base de datos", ex);
                Desconectar();
                throw new MoneyUcabException(ex, "Error Desconocido", 1);
            }
            finally
            {
                Desconectar();
            }

            /*if (afectados == 0) throw new UsuarioInexistenteException();
            if (afectados > 1) throw new LotoUcabException("Usiarios duplicados en Base de datos", 1);*/
        }

        public List<ComPago> CobrosCancelados(int IdUsuario, int Solicitante)
        {

            //log.Debug("Entrando al metodo: " + MethodBase.GetCurrentMethod().Name);

            try
            {
                Conectar();

                comandoSQL = conector.CreateCommand();

                comandoSQL.CommandText = string.Format("SELECT * FROM Cobros_Cancelados(@UsuarioId, @solicitante);");
                comandoSQL.Parameters.Add(new NpgsqlParameter("UsuarioId", IdUsuario));
                comandoSQL.Parameters.Add(new NpgsqlParameter("solicitante", Solicitante));
                lectorTablaSQL = comandoSQL.ExecuteReader();
                List<ComPago> cobros = new List<ComPago>();
                ComPago row;
                while (lectorTablaSQL.Read())
                {
                    row = new ComPago();
                    row.LlenadoDataNpgsql(lectorTablaSQL);
                    cobros.Add(row);
                }
                return cobros;
            }
            catch (NpgsqlException ex)
            {
                //Manejo de errores para el cierre de la conexión.
                //Logger para el manejo de errores
                //log.Error("Error en la conexion a base de datos", ex);
                Desconectar();
                throw ex;
            }
            catch (Exception ex)
            {
                //log.Error("Error en la conexion a base de datos", ex);
                Desconectar();
                throw new MoneyUcabException(ex, "Error Desconocido", 1);
            }
            finally
            {
                Desconectar();
            }

            /*if (afectados == 0) throw new UsuarioInexistenteException();
            if (afectados > 1) throw new LotoUcabException("Usiarios duplicados en Base de datos", 1);*/
        }

        public List<ComPago> CobrosExitosos(int IdUsuario, int Solicitante)
        {

            //log.Debug("Entrando al metodo: " + MethodBase.GetCurrentMethod().Name);

            try
            {
                Conectar();

                comandoSQL = conector.CreateCommand();

                comandoSQL.CommandText = string.Format("SELECT * FROM Cobros_Exitosos(@UsuarioId, @solicitante);");
                comandoSQL.Parameters.Add(new NpgsqlParameter("UsuarioId", IdUsuario));
                comandoSQL.Parameters.Add(new NpgsqlParameter("solicitante", Solicitante));
                lectorTablaSQL = comandoSQL.ExecuteReader();
                List<ComPago> cobros = new List<ComPago>();
                ComPago row;
                while (lectorTablaSQL.Read())
                {
                    row = new ComPago();
                    row.LlenadoDataNpgsql(lectorTablaSQL);
                    cobros.Add(row);
                }
                return cobros;
            }
            catch (NpgsqlException ex)
            {
                //Manejo de errores para el cierre de la conexión.
                //Logger para el manejo de errores
                //log.Error("Error en la conexion a base de datos", ex);
                Desconectar();
                throw ex;
            }
            catch (Exception ex)
            {
                //log.Error("Error en la conexion a base de datos", ex);
                Desconectar();
                throw new MoneyUcabException(ex, "Error Desconocido", 1);
            }
            finally
            {
                Desconectar();
            }

            /*if (afectados == 0) throw new UsuarioInexistenteException();
            if (afectados > 1) throw new LotoUcabException("Usiarios duplicados en Base de datos", 1);*/
        }

        public List<ComUsuarioParametro> ParametrosUsuario(int IdUsuario)
        {

            //log.Debug("Entrando al metodo: " + MethodBase.GetCurrentMethod().Name);

            try
            {
                Conectar();

                comandoSQL = conector.CreateCommand();

                comandoSQL.CommandText = string.Format("SELECT * FROM Parametros_Usuario(@UsuarioId);");
                comandoSQL.Parameters.Add(new NpgsqlParameter("UsuarioId", IdUsuario));
                lectorTablaSQL = comandoSQL.ExecuteReader();
                List<ComUsuarioParametro> parametrosUsuario = new List<ComUsuarioParametro>();
                ComUsuarioParametro row;
                while (lectorTablaSQL.Read())
                {
                    row = new ComUsuarioParametro();
                    row.LlenadoDataNpgsql(lectorTablaSQL);
                    parametrosUsuario.Add(row);
                }
                return parametrosUsuario;
            }
            catch (NpgsqlException ex)
            {
                //Manejo de errores para el cierre de la conexión.
                //Logger para el manejo de errores
                //log.Error("Error en la conexion a base de datos", ex);
                Desconectar();
                throw ex;
            }
            catch (Exception ex)
            {
                //log.Error("Error en la conexion a base de datos", ex);
                Desconectar();
                throw new MoneyUcabException(ex, "Error Desconocido", 1);
            }
            finally
            {
                Desconectar();
            }

            /*if (afectados == 0) throw new UsuarioInexistenteException();
            if (afectados > 1) throw new LotoUcabException("Usiarios duplicados en Base de datos", 1);*/
        }

        public ComUsuario InformacionPersona(string Usuario)
        {

            //log.Debug("Entrando al metodo: " + MethodBase.GetCurrentMethod().Name);

            try
            {
                Conectar();

                comandoSQL = conector.CreateCommand();

                comandoSQL.CommandText = string.Format("SELECT * FROM Informacion_persona(@usuario);");
                comandoSQL.Parameters.Add(new NpgsqlParameter("usuario", Usuario));
                lectorTablaSQL = comandoSQL.ExecuteReader();
                if (lectorTablaSQL.Read())
                {
                    ComUsuario informacion_persona = new ComUsuario();
                    informacion_persona.LlenadoDataNpgsql(lectorTablaSQL);
                    return informacion_persona;
                }
                else
                {
                    UsuarioExistenteException.UsuarioNoExistente();
                    return null;
                }
            }
            catch (NpgsqlException ex)
            {
                //Manejo de errores para el cierre de la conexión.
                //Logger para el manejo de errores
                //log.Error("Error en la conexion a base de datos", ex);
                Desconectar();
                throw ex;
            }
            catch (Exception ex)
            {
                //log.Error("Error en la conexion a base de datos", ex);
                Desconectar();
                throw new MoneyUcabException(ex, "Error Desconocido", 1);
            }
            finally
            {
                Desconectar();
            }

            /*if (afectados == 0) throw new UsuarioInexistenteException();
            if (afectados > 1) throw new LotoUcabException("Usiarios duplicados en Base de datos", 1);*/
        }

        public double SaldoMonedero(int IdUsuario)
        {

            //log.Debug("Entrando al metodo: " + MethodBase.GetCurrentMethod().Name);
            double saldo;
            try
            {
                Conectar();

                comandoSQL = conector.CreateCommand();

                comandoSQL.CommandText = string.Format("SELECT Saldo_Monedero(@UsuarioId);");
                comandoSQL.Parameters.Add(new NpgsqlParameter("UsuarioId", IdUsuario));
                lectorTablaSQL = comandoSQL.ExecuteReader();
                lectorTablaSQL.Read();
                saldo = lectorTablaSQL.GetDouble(0);
                return saldo;
            }
            catch (NpgsqlException ex)
            {
                //Manejo de errores para el cierre de la conexión.
                //Logger para el manejo de errores
                //log.Error("Error en la conexion a base de datos", ex);
                Desconectar();
                throw ex;
            }
            catch (Exception ex)
            {
                //log.Error("Error en la conexion a base de datos", ex);
                Desconectar();
                throw new MoneyUcabException(ex, "Error Desconocido", 1);
            }
            finally
            {
                Desconectar();
            }

            /*if (afectados == 0) throw new UsuarioInexistenteException();
            if (afectados > 1) throw new LotoUcabException("Usiarios duplicados en Base de datos", 1);*/
        }

        //Debe retornar el historial de operaciones
        public List<ComOperacionTarjeta> HistorialOperacionesTarjeta(int IdTarjeta)
        {

            //log.Debug("Entrando al metodo: " + MethodBase.GetCurrentMethod().Name);

            try
            {
                Conectar();

                comandoSQL = conector.CreateCommand();

                comandoSQL.CommandText = string.Format("SELECT * FROM Historial_Operaciones_Tarjetas(@tarjetaId);");
                comandoSQL.Parameters.Add(new NpgsqlParameter("tarjetaId", IdTarjeta));
                lectorTablaSQL = comandoSQL.ExecuteReader();
                List<ComOperacionTarjeta> operacionesTarjeta = new List<ComOperacionTarjeta>();
                ComOperacionTarjeta row;
                while (lectorTablaSQL.Read())
                {
                    row = new ComOperacionTarjeta();
                    row.LlenadoDataNpgsql(lectorTablaSQL);
                    operacionesTarjeta.Add(row);
                }
                return operacionesTarjeta;
            }
            catch (NpgsqlException ex)
            {
                //Manejo de errores para el cierre de la conexión.
                //Logger para el manejo de errores
                //log.Error("Error en la conexion a base de datos", ex);
                Desconectar();
                throw ex;
            }
            catch (Exception ex)
            {
                //log.Error("Error en la conexion a base de datos", ex);
                Desconectar();
                throw new MoneyUcabException(ex, "Error Desconocido", 1);
            }
            finally
            {
                Desconectar();
            }

            /*if (afectados == 0) throw new UsuarioInexistenteException();
            if (afectados > 1) throw new LotoUcabException("Usiarios duplicados en Base de datos", 1);*/
        }

        //Debe retornar el historial de operaciones
        public List<ComOperacionCuenta> HistorialOperacionesCuenta(int IdCuenta)
        {

            //log.Debug("Entrando al metodo: " + MethodBase.GetCurrentMethod().Name);

            try
            {
                Conectar();

                comandoSQL = conector.CreateCommand();

                comandoSQL.CommandText = string.Format("SELECT * FROM Historial_Operaciones_Cuenta(@CuentaId);");
                comandoSQL.Parameters.Add(new NpgsqlParameter("CuentaId", IdCuenta));
                lectorTablaSQL = comandoSQL.ExecuteReader();
                List<ComOperacionCuenta> operacionesCuenta = new List<ComOperacionCuenta>();
                ComOperacionCuenta row;
                while (lectorTablaSQL.Read())
                {
                    row = new ComOperacionCuenta();
                    row.LlenadoDataNpgsql(lectorTablaSQL);
                    operacionesCuenta.Add(row);
                }
                return operacionesCuenta;
            }
            catch (NpgsqlException ex)
            {
                //Manejo de errores para el cierre de la conexión.
                //Logger para el manejo de errores
                //log.Error("Error en la conexion a base de datos", ex);
                Desconectar();
                throw ex;
            }
            catch (Exception ex)
            {
                //log.Error("Error en la conexion a base de datos", ex);
                Desconectar();
                throw new MoneyUcabException(ex, "Error Desconocido", 1);
            }
            finally
            {
                Desconectar();
            }

            /*if (afectados == 0) throw new UsuarioInexistenteException();
            if (afectados > 1) throw new LotoUcabException("Usiarios duplicados en Base de datos", 1);*/
        }

        public List<ComOperacionMonedero> HistorialOperacionesMonedero(int IdUsuario)
        {

            //log.Debug("Entrando al metodo: " + MethodBase.GetCurrentMethod().Name);

            try
            {
                Conectar();

                comandoSQL = conector.CreateCommand();

                comandoSQL.CommandText = string.Format("SELECT * FROM Historial_Operaciones_Monedero(@UsuarioId);");
                comandoSQL.Parameters.Add(new NpgsqlParameter("UsuarioId", IdUsuario));
                lectorTablaSQL = comandoSQL.ExecuteReader();
                List<ComOperacionMonedero> operacionesMonedero = new List<ComOperacionMonedero>();
                ComOperacionMonedero row;
                while (lectorTablaSQL.Read())
                {
                    row = new ComOperacionMonedero();
                    row.LlenadoDataNpgsql(lectorTablaSQL);
                    operacionesMonedero.Add(row);
                }
                return operacionesMonedero;
            }
            catch (NpgsqlException ex)
            {
                //Manejo de errores para el cierre de la conexión.
                //Logger para el manejo de errores
                //log.Error("Error en la conexion a base de datos", ex);
                Desconectar();
                throw ex;
            }
            catch (Exception ex)
            {
                //log.Error("Error en la conexion a base de datos", ex);
                Desconectar();
                throw new MoneyUcabException(ex, "Error Desconocido", 1);
            }
            finally
            {
                Desconectar();
            }

            /*if (afectados == 0) throw new UsuarioInexistenteException();
            if (afectados > 1) throw new LotoUcabException("Usiarios duplicados en Base de datos", 1);*/
        }
        //--------------------------------------------------------------------------------------

        //Operaciones de lógica-----------------------------------------------------------------
        public void RegistroUsuarioPersona(ComUsuario Formulario)
        {
            try
            {
                Conectar();

                comandoSQL = conector.CreateCommand();

                comandoSQL.CommandText = string.Format("SELECT Registro_Usuario(@TipoUsuarioId, @TipoIdentificacionId, @Usuario, @FechaRegistro, @NroIdentificacion, " +
                    "@Email, @Telefono, @Direccion, @Estatus, @TipoSol, @Nombre, @Apellido, @Contrasena, @RazonSocial, @IdEstadoCivil, @FechaNacimiento)");
                Formulario.LlenadoDataFormPersona(comandoSQL);
                lectorTablaSQL = comandoSQL.ExecuteReader();
            }
            catch (NpgsqlException ex)
            {
                //Manejo de errores para el cierre de la conexión.
                //Logger para el manejo de errores
                Desconectar();
                throw ex;
            }
            catch (Exception ex)
            {
                Desconectar();
                throw new MoneyUcabException(ex, "Error Desconocido", 1);
            }
            finally
            {
                if (lectorTablaSQL.Read())
                {
                    if (!lectorTablaSQL.GetBoolean(0))
                    {
                        throw new MoneyUcabException("No se pudo registrar al usuario", 201);
                    }
                }
                else
                    throw new MoneyUcabException("No se pudo registrar al usuario", 201);
                Desconectar();
            }
        }

        public void RegistroUsuarioComercio(ComUsuario Formulario)
        {
            try
            {
                Conectar();

                comandoSQL = conector.CreateCommand();

                comandoSQL.CommandText = string.Format("SELECT Registro_Usuario(@TipoUsuarioId, @TipoIdentificacionId, @Usuario, @FechaRegistro, @NroIdentificacion, " +
                    "@Email, @Telefono, @Direccion, @Estatus, @TipoSol, @Nombre, @Apellido, @Contrasena, @RazonSocial, @IdEstadoCivil, @FechaNacimiento)");
                Formulario.LlenadoDataFormComercio(comandoSQL);
                lectorTablaSQL = comandoSQL.ExecuteReader();
            }
            catch (NpgsqlException ex)
            {
                //Manejo de errores para el cierre de la conexión.
                //Logger para el manejo de errores
                Desconectar();
                throw ex;
            }
            catch (Exception ex)
            {
                Desconectar();
                throw new MoneyUcabException(ex, "Error Desconocido", 1);
            }
            finally
            {
                if (lectorTablaSQL.Read())
                {
                    if (!lectorTablaSQL.GetBoolean(0))
                    {
                        throw new MoneyUcabException("No se pudo registrar al usuario", 201);
                    }
                }
                else
                    throw new MoneyUcabException("No se pudo registrar al usuario", 201);
                Desconectar();
            }
        }
        
        public void RegistroCuenta(ComCuenta Formulario)
        {
            try
            {
                Conectar();

                comandoSQL = conector.CreateCommand();

                comandoSQL.CommandText = string.Format("SELECT Registro_Cuenta(@UsuarioId, @TipoCuentaId, @BancoId, @Numero)");
                Formulario.LlenadoDataForm(comandoSQL);
                lectorTablaSQL = comandoSQL.ExecuteReader();
            }
            catch (NpgsqlException ex)
            {
                //Manejo de errores para el cierre de la conexión.
                //Logger para el manejo de errores
                Desconectar();
                throw ex;
            }
            catch (Exception ex)
            {
                Desconectar();
                throw new MoneyUcabException(ex, "Error Desconocido", 1);
            }
            finally
            {
                if (lectorTablaSQL.Read())
                {
                    if (!lectorTablaSQL.GetBoolean(0))
                    {
                        throw new MoneyUcabException("No se pudo registrar al cuenta", 202);
                    }
                }
                else
                    throw new MoneyUcabException("No se pudo registrar al cuenta", 202);
                Desconectar();
            }
        }

        public void RegistroTarjeta(ComTarjeta Formulario)
        {
            try
            {
                Conectar();

                comandoSQL = conector.CreateCommand();

                comandoSQL.CommandText = string.Format("SELECT Registro_Tarjeta(@UsuarioId, @TipoTarjetaId, @BancoId, @Numero, @FechaVencimiento, @cvc, @Estatus)");
                Formulario.LlenadoDataForm(comandoSQL);
                lectorTablaSQL = comandoSQL.ExecuteReader();
            }
            catch (NpgsqlException ex)
            {
                //Manejo de errores para el cierre de la conexión.
                //Logger para el manejo de errores
                Desconectar();
                throw ex;
            }
            catch (Exception ex)
            {
                Desconectar();
                throw new MoneyUcabException(ex, "Error Desconocido", 1);
            }
            finally
            {
                if (lectorTablaSQL.Read())
                {
                    if (!lectorTablaSQL.GetBoolean(0))
                    {
                        throw new MoneyUcabException("No se pudo registrar la tarjeta", 202);
                    }
                }
                else
                    throw new MoneyUcabException("No se pudo registrar la tarjeta", 202);
                Desconectar();
            }
        }

        public void EstablecerParametro(ComUsuarioParametro Formulario)
        {
            try
            {
                Conectar();

                comandoSQL = conector.CreateCommand();

                comandoSQL.CommandText = string.Format("SELECT Establecer_Parametro(@UsuarioId, @ParametroId, @Validacion, @Estatus)");
                Formulario.LlenadoDataForm(comandoSQL);
                lectorTablaSQL = comandoSQL.ExecuteReader();
            }
            catch (NpgsqlException ex)
            {
                //Manejo de errores para el cierre de la conexión.
                //Logger para el manejo de errores
                Desconectar();
                throw ex;
            }
            catch (Exception ex)
            {
                Desconectar();
                throw new MoneyUcabException(ex, "Error Desconocido", 1);
            }
            finally
            {
                if (lectorTablaSQL.Read())
                {
                    if (!lectorTablaSQL.GetBoolean(0))
                    {
                        throw new MoneyUcabException("No se pudo registrar el parámetro", 203);
                    }
                }
                else
                    throw new MoneyUcabException("No se pudo registrar el parámetro", 203);
                Desconectar();
            }
        }

        public void Cobro(int IdUsuarioCobrador, string IdUsuarioPaga, double Monto)
        {
            try
            {
                Conectar();

                comandoSQL = conector.CreateCommand();

                comandoSQL.CommandText = string.Format("SELECT Cobro(@UsuarioId, @UsuarioACobrar, @Monto)");
                comandoSQL.Parameters.Add(new NpgsqlParameter("UsuarioId", IdUsuarioCobrador));
                comandoSQL.Parameters.Add(new NpgsqlParameter("UsuarioACobrar", IdUsuarioPaga));
                comandoSQL.Parameters.Add(new NpgsqlParameter("Monto", Monto));
                lectorTablaSQL = comandoSQL.ExecuteReader();
            }
            catch (NpgsqlException ex)
            {
                //Manejo de errores para el cierre de la conexión.
                //Logger para el manejo de errores
                Desconectar();
                throw ex;
            }
            catch (Exception ex)
            {
                Desconectar();
                throw new MoneyUcabException(ex, "Error Desconocido", 1);
            }
            finally
            {
                if (lectorTablaSQL.Read())
                {
                    if (!lectorTablaSQL.GetBoolean(0))
                    {
                        throw new MoneyUcabException("No se pudo realizar el cobro", 204);
                    }
                }
                else
                    throw new MoneyUcabException("No se pudo registrar la tarjeta", 204);
                Desconectar();
            }
        }

        public void Reintegro(int IdUsuarioCobrador, string IdUsuarioPaga, string Referencia)
        {
            try
            {
                Conectar();

                comandoSQL = conector.CreateCommand();

                comandoSQL.CommandText = string.Format("SELECT Reintegro(@UsuarioId, @UsuarioACobrar, @Referencia)");
                comandoSQL.Parameters.Add(new NpgsqlParameter("UsuarioId", IdUsuarioCobrador));
                comandoSQL.Parameters.Add(new NpgsqlParameter("UsuarioACobrar", IdUsuarioPaga));
                comandoSQL.Parameters.Add(new NpgsqlParameter("Referencia", Referencia));
                lectorTablaSQL = comandoSQL.ExecuteReader();
            }
            catch (NpgsqlException ex)
            {
                //Manejo de errores para el cierre de la conexión.
                //Logger para el manejo de errores
                Desconectar();
                throw ex;
            }
            catch (Exception ex)
            {
                Desconectar();
                throw new MoneyUcabException(ex, "Error Desconocido", 1);
            }
            finally
            {
                if (lectorTablaSQL.Read())
                {
                    if (!lectorTablaSQL.GetBoolean(0))
                    {
                        throw new MoneyUcabException("No se pudo realizar el cobro", 204);
                    }
                }
                else
                    throw new MoneyUcabException("No se pudo registrar la tarjeta", 204);
                Desconectar();
            }
        }

        public void CancelarCobro(int IdCobro)
        {
            try
            {
                Conectar();

                comandoSQL = conector.CreateCommand();

                comandoSQL.CommandText = string.Format("SELECT Cancelar_Cobro(@IdCobro)");
                comandoSQL.Parameters.Add(new NpgsqlParameter("IdCobro", IdCobro));
                lectorTablaSQL = comandoSQL.ExecuteReader();
            }
            catch (NpgsqlException ex)
            {
                //Manejo de errores para el cierre de la conexión.
                //Logger para el manejo de errores
                Desconectar();
                throw ex;
            }
            catch (Exception ex)
            {
                Desconectar();
                throw new MoneyUcabException(ex, "Error Desconocido", 1);
            }
            finally
            {
                if (lectorTablaSQL.Read())
                {
                    if (!lectorTablaSQL.GetBoolean(0))
                    {
                        throw new MoneyUcabException("No se pudo realizar el cobro", 204);
                    }
                }
                else
                    throw new MoneyUcabException("No se pudo registrar la tarjeta", 204);
                Desconectar();
            }
        }

        public void CancelarReintegro(int IdReintegro)
        {
            try
            {
                Conectar();

                comandoSQL = conector.CreateCommand();

                comandoSQL.CommandText = string.Format("SELECT Cancelar_Reintegro(@IdReintegro)");
                comandoSQL.Parameters.Add(new NpgsqlParameter("IdReintegro", IdReintegro));
                lectorTablaSQL = comandoSQL.ExecuteReader();
            }
            catch (NpgsqlException ex)
            {
                //Manejo de errores para el cierre de la conexión.
                //Logger para el manejo de errores
                Desconectar();
                throw ex;
            }
            catch (Exception ex)
            {
                Desconectar();
                throw new MoneyUcabException(ex, "Error Desconocido", 1);
            }
            finally
            {
                if (lectorTablaSQL.Read())
                {
                    if (!lectorTablaSQL.GetBoolean(0))
                    {
                        throw new MoneyUcabException("No se pudo realizar el cobro", 204);
                    }
                }
                else
                    throw new MoneyUcabException("No se pudo registrar la tarjeta", 204);
                Desconectar();
            }
        }

        public void Pago_Tarjeta(int IdUsuarioReceptor, int IdTarjetaPago, double Monto, int IdCobro)
        {
            try
            {
                Conectar();

                comandoSQL = conector.CreateCommand();

                comandoSQL.CommandText = string.Format("SELECT Pago_Tarjeta(@IdUsuarioReceptor, @IdTarjetaPago, @Monto, @IdCobro)");
                comandoSQL.Parameters.Add(new NpgsqlParameter("IdUsuarioReceptor", IdUsuarioReceptor));
                comandoSQL.Parameters.Add(new NpgsqlParameter("IdTarjetaPago", IdTarjetaPago));
                comandoSQL.Parameters.Add(new NpgsqlParameter("Monto", Monto));
                comandoSQL.Parameters.Add(new NpgsqlParameter("IdCobro", IdCobro));
                lectorTablaSQL = comandoSQL.ExecuteReader();
            }
            catch (NpgsqlException ex)
            {
                //Manejo de errores para el cierre de la conexión.
                //Logger para el manejo de errores
                Desconectar();
                throw ex;
            }
            catch (Exception ex)
            {
                Desconectar();
                throw new MoneyUcabException(ex, "Error Desconocido", 1);
            }
            finally
            {
                if (lectorTablaSQL.Read())
                {
                    if (!lectorTablaSQL.GetBoolean(0))
                    {
                        throw new MoneyUcabException("No se pudo realizar el cobro", 204);
                    }
                }
                else
                    throw new MoneyUcabException("No se pudo registrar la tarjeta", 204);
                Desconectar();
            }
        }

        public void Pago_Cuenta(int IdUsuarioReceptor, int IdCuentaPago, double Monto, int IdCobro)
        {
            try
            {
                Conectar();

                comandoSQL = conector.CreateCommand();

                comandoSQL.CommandText = string.Format("SELECT Pago_Cuenta(@IdUsuarioReceptor, @IdCuentaPago, @Monto, @IdCobro)");
                comandoSQL.Parameters.Add(new NpgsqlParameter("IdUsuarioReceptor", IdUsuarioReceptor));
                comandoSQL.Parameters.Add(new NpgsqlParameter("IdCuentaPago", IdCuentaPago));
                comandoSQL.Parameters.Add(new NpgsqlParameter("Monto", Monto));
                comandoSQL.Parameters.Add(new NpgsqlParameter("IdCobro", IdCobro));
                lectorTablaSQL = comandoSQL.ExecuteReader();
            }
            catch (NpgsqlException ex)
            {
                //Manejo de errores para el cierre de la conexión.
                //Logger para el manejo de errores
                Desconectar();
                throw ex;
            }
            catch (Exception ex)
            {
                Desconectar();
                throw new MoneyUcabException(ex, "Error Desconocido", 1);
            }
            finally
            {
                if (lectorTablaSQL.Read())
                {
                    if (!lectorTablaSQL.GetBoolean(0))
                    {
                        throw new MoneyUcabException("No se pudo realizar el cobro", 204);
                    }
                }
                else
                    throw new MoneyUcabException("No se pudo registrar la tarjeta", 204);
                Desconectar();
            }
        }

        public void Pago_Monedero(int IdUsuarioReceptor, int IdUsuarioPago, double Monto, int IdCobro)
        {
            try
            {
                Conectar();

                comandoSQL = conector.CreateCommand();

                comandoSQL.CommandText = string.Format("SELECT Pago_Monedero(@IdUsuarioReceptor, @IdUsuarioPago, @Monto, @IdCobro)");
                comandoSQL.Parameters.Add(new NpgsqlParameter("IdUsuarioReceptor", IdUsuarioReceptor));
                comandoSQL.Parameters.Add(new NpgsqlParameter("IdUsuarioPago", IdUsuarioPago));
                comandoSQL.Parameters.Add(new NpgsqlParameter("Monto", Monto));
                comandoSQL.Parameters.Add(new NpgsqlParameter("IdCobro", IdCobro));
                lectorTablaSQL = comandoSQL.ExecuteReader();
            }
            catch (NpgsqlException ex)
            {
                //Manejo de errores para el cierre de la conexión.
                //Logger para el manejo de errores
                Desconectar();
                throw ex;
            }
            catch (Exception ex)
            {
                Desconectar();
                throw new MoneyUcabException(ex, "Error Desconocido", 1);
            }
            finally
            {
                if (lectorTablaSQL.Read())
                {
                    if (!lectorTablaSQL.GetBoolean(0))
                    {
                        throw new MoneyUcabException("No se pudo realizar el cobro", 204);
                    }
                }
                else
                    throw new MoneyUcabException("No se pudo realizar el cobro", 204);
                Desconectar();
            }
        }

        public void Reintegro_Tarjeta(int IdUsuarioReceptor, int IdTarjetaPago, double Monto, int IdCobro)
        {
            try
            {
                Conectar();

                comandoSQL = conector.CreateCommand();

                comandoSQL.CommandText = string.Format("SELECT Reintegro_Tarjeta(@IdUsuarioReceptor, @IdTarjetaPago, @Monto, @IdCobro)");
                comandoSQL.Parameters.Add(new NpgsqlParameter("IdUsuarioReceptor", IdUsuarioReceptor));
                comandoSQL.Parameters.Add(new NpgsqlParameter("IdTarjetaPago", IdTarjetaPago));
                comandoSQL.Parameters.Add(new NpgsqlParameter("Monto", Monto));
                comandoSQL.Parameters.Add(new NpgsqlParameter("IdCobro", IdCobro));
                lectorTablaSQL = comandoSQL.ExecuteReader();
            }
            catch (NpgsqlException ex)
            {
                //Manejo de errores para el cierre de la conexión.
                //Logger para el manejo de errores
                Desconectar();
                throw ex;
            }
            catch (Exception ex)
            {
                Desconectar();
                throw new MoneyUcabException(ex, "Error Desconocido", 1);
            }
            finally
            {
                if (lectorTablaSQL.Read())
                {
                    if (!lectorTablaSQL.GetBoolean(0))
                    {
                        throw new MoneyUcabException("No se pudo realizar el cobro", 204);
                    }
                }
                else
                    throw new MoneyUcabException("No se pudo registrar la tarjeta", 204);
                Desconectar();
            }
        }

        public void Reintegro_Cuenta(int IdUsuarioReceptor, int IdCuentaPago, double Monto, int IdCobro)
        {
            try
            {
                Conectar();

                comandoSQL = conector.CreateCommand();

                comandoSQL.CommandText = string.Format("SELECT Reintegro_Cuenta(@IdUsuarioReceptor, @IdCuentaPago, @Monto, @IdCobro)");
                comandoSQL.Parameters.Add(new NpgsqlParameter("IdUsuarioReceptor", IdUsuarioReceptor));
                comandoSQL.Parameters.Add(new NpgsqlParameter("IdCuentaPago", IdCuentaPago));
                comandoSQL.Parameters.Add(new NpgsqlParameter("Monto", Monto));
                comandoSQL.Parameters.Add(new NpgsqlParameter("IdCobro", IdCobro));
                lectorTablaSQL = comandoSQL.ExecuteReader();
            }
            catch (NpgsqlException ex)
            {
                //Manejo de errores para el cierre de la conexión.
                //Logger para el manejo de errores
                Desconectar();
                throw ex;
            }
            catch (Exception ex)
            {
                Desconectar();
                throw new MoneyUcabException(ex, "Error Desconocido", 1);
            }
            finally
            {
                if (lectorTablaSQL.Read())
                {
                    if (!lectorTablaSQL.GetBoolean(0))
                    {
                        throw new MoneyUcabException("No se pudo realizar el cobro", 204);
                    }
                }
                else
                    throw new MoneyUcabException("No se pudo registrar la tarjeta", 204);
                Desconectar();
            }
        }

        public void Reintegro_Monedero(int IdUsuarioReceptor, int IdUsuarioPago, double Monto, int IdCobro)
        {
            try
            {
                Conectar();

                comandoSQL = conector.CreateCommand();

                comandoSQL.CommandText = string.Format("SELECT Pago_Tarjeta(@IdUsuarioReceptor, @IdUsuarioPago, @Monto, @IdCobro)");
                comandoSQL.Parameters.Add(new NpgsqlParameter("IdUsuarioReceptor", IdUsuarioReceptor));
                comandoSQL.Parameters.Add(new NpgsqlParameter("IdUsuarioPago", IdUsuarioPago));
                comandoSQL.Parameters.Add(new NpgsqlParameter("Monto", Monto));
                comandoSQL.Parameters.Add(new NpgsqlParameter("IdCobro", IdCobro));
                lectorTablaSQL = comandoSQL.ExecuteReader();
            }
            catch (NpgsqlException ex)
            {
                //Manejo de errores para el cierre de la conexión.
                //Logger para el manejo de errores
                Desconectar();
                throw ex;
            }
            catch (Exception ex)
            {
                Desconectar();
                throw new MoneyUcabException(ex, "Error Desconocido", 1);
            }
            finally
            {
                if (lectorTablaSQL.Read())
                {
                    if (!lectorTablaSQL.GetBoolean(0))
                    {
                        throw new MoneyUcabException("No se pudo realizar el cobro", 204);
                    }
                }
                else
                    throw new MoneyUcabException("No se pudo registrar la tarjeta", 204);
                Desconectar();
            }
        }

        public void Modificación_Usuario(string Usuario, string Email, string Telefono, string Direccion, int IdUsuario)
        {
            try
            {
                Conectar();

                comandoSQL = conector.CreateCommand();

                comandoSQL.CommandText = string.Format("SELECT Modificación_Usuario(@usuario, @email, @telefono, @direccion)");
                comandoSQL.Parameters.Add(new NpgsqlParameter("IdUsuarioReceptor", IdUsuario));
                comandoSQL.Parameters.Add(new NpgsqlParameter("usuario", Usuario));
                comandoSQL.Parameters.Add(new NpgsqlParameter("email", Email));
                comandoSQL.Parameters.Add(new NpgsqlParameter("telefono", Telefono));
                comandoSQL.Parameters.Add(new NpgsqlParameter("direccion", Direccion));
                lectorTablaSQL = comandoSQL.ExecuteReader();
            }
            catch (NpgsqlException ex)
            {
                //Manejo de errores para el cierre de la conexión.
                //Logger para el manejo de errores
                Desconectar();
                throw ex;
            }
            catch (Exception ex)
            {
                Desconectar();
                throw new MoneyUcabException(ex, "Error Desconocido", 1);
            }
            finally
            {
                if (lectorTablaSQL.Read())
                {
                    if (!lectorTablaSQL.GetBoolean(0))
                    {
                        throw new MoneyUcabException("No se pudo realizar el cobro", 204);
                    }
                }
                else
                    throw new MoneyUcabException("No se pudo registrar la tarjeta", 204);
                Desconectar();
            }
        }

        public ComOperacionMonedero Ejecutar_Cierre(int IdUsuario)
        {
            try
            {
                Conectar();

                comandoSQL = conector.CreateCommand();

                comandoSQL.CommandText = string.Format("SELECT Ejecutar_Cierre(@IdUsuario)");
                comandoSQL.Parameters.Add(new NpgsqlParameter("IdUsuario", IdUsuario));
                lectorTablaSQL = comandoSQL.ExecuteReader();
                if (lectorTablaSQL.Read())
                {
                    ComOperacionMonedero operacion_monedero = new ComOperacionMonedero();
                    operacion_monedero.LlenadoDataNpgsql(lectorTablaSQL);
                    return operacion_monedero;
                }
            }
            catch (NpgsqlException ex)
            {
                //Manejo de errores para el cierre de la conexión.
                //Logger para el manejo de errores
                Desconectar();
                throw ex;
            }
            catch (Exception ex)
            {
                Desconectar();
                throw new MoneyUcabException(ex, "Error Desconocido", 1);
            }
            finally
            {
                if (lectorTablaSQL.Read())
                {
                    if (!lectorTablaSQL.GetBoolean(0))
                    {
                        throw new MoneyUcabException("No se pudo realizar el cobro", 204);
                    }
                }
                else
                    throw new MoneyUcabException("No se pudo registrar la tarjeta", 204);
                Desconectar();
            }
            return null;
        }

        public void EliminarCuenta(int IdCuenta)
        {
            try
            {
                Conectar();

                comandoSQL = conector.CreateCommand();

                comandoSQL.CommandText = string.Format("SELECT Eliminar_Cuenta(@CuentaId)");
                comandoSQL.Parameters.Add(new NpgsqlParameter("CuentaId", IdCuenta));
                lectorTablaSQL = comandoSQL.ExecuteReader();
            }
            catch (NpgsqlException ex)
            {
                //Manejo de errores para el cierre de la conexión.
                //Logger para el manejo de errores
                Desconectar();
                throw ex;
            }
            catch (Exception ex)
            {
                Desconectar();
                throw new MoneyUcabException(ex, "Error Desconocido", 1);
            }
            finally
            {
                if (lectorTablaSQL.Read())
                {
                    if (!lectorTablaSQL.GetBoolean(0))
                    {
                        throw new MoneyUcabException("No se pudo registrar al cuenta", 202);
                    }
                }
                else
                    throw new MoneyUcabException("No se pudo registrar al cuenta", 202);
                Desconectar();
            }
        }

        public void EliminarTarjeta(int IdTarjeta)
        {
            try
            {
                Conectar();

                comandoSQL = conector.CreateCommand();

                comandoSQL.CommandText = string.Format("SELECT Eliminar_Tarjeta(@TarjetaId)");
                comandoSQL.Parameters.Add(new NpgsqlParameter("CuentaId", IdTarjeta));
                lectorTablaSQL = comandoSQL.ExecuteReader();
            }
            catch (NpgsqlException ex)
            {
                //Manejo de errores para el cierre de la conexión.
                //Logger para el manejo de errores
                Desconectar();
                throw ex;
            }
            catch (Exception ex)
            {
                Desconectar();
                throw new MoneyUcabException(ex, "Error Desconocido", 1);
            }
            finally
            {
                if (lectorTablaSQL.Read())
                {
                    if (!lectorTablaSQL.GetBoolean(0))
                    {
                        throw new MoneyUcabException("No se pudo eliminar la tarjeta", 202);
                    }
                }
                else
                    throw new MoneyUcabException("No se pudo eliminar la tarjeta", 202);
                Desconectar();
            }
        }
    }
}

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
            conn_string.Password = "lolazo123";
            conn_string.Database = "postgres";
            //StringConexion = ConfigurationManager.AppSettings.Get("IdentityConnection");
            StringConexion = conn_string.ToString();
        }

        public List<ComEstadoCivil> EstadosCiviles()
        {

            //log.Debug("Entrando al metodo: " + MethodBase.GetCurrentMethod().Name);

            try
            {
                Conectar();

                ComandoSQL = Conector.CreateCommand();

                ComandoSQL.CommandText = string.Format("SELECT * FROM Estados_Civiles();");
                LectorTablaSQL = ComandoSQL.ExecuteReader();
                List<ComEstadoCivil> estadosCiviles = new List<ComEstadoCivil>();
                ComEstadoCivil row;
                while (LectorTablaSQL.Read())
                {
                    row = new ComEstadoCivil();
                    row.LlenadoDataNpgsql(LectorTablaSQL);
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

            /*if (afectados == 0) throw new UsuarioInexistenteException();
            if (afectados > 1) throw new LotoUcabException("Usiarios duplicados en Base de datos", 1);*/
        }

        public List<ComTipoTarjeta> TiposTarjeta()
        {

            //log.Debug("Entrando al metodo: " + MethodBase.GetCurrentMethod().Name);

            try
            {
                Conectar();

                ComandoSQL = Conector.CreateCommand();

                ComandoSQL.CommandText = string.Format("SELECT * FROM tipos_tarjeta();");
                LectorTablaSQL = ComandoSQL.ExecuteReader();
                List<ComTipoTarjeta> tiposTarjetas = new List<ComTipoTarjeta>();
                ComTipoTarjeta row = new ComTipoTarjeta();
                while (LectorTablaSQL.Read())
                {
                    row.LlenadoDataNpgsql(LectorTablaSQL);
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

                ComandoSQL = Conector.CreateCommand();

                ComandoSQL.CommandText = string.Format("SELECT * FROM Bancos();");
                LectorTablaSQL = ComandoSQL.ExecuteReader();
                List<ComBanco> bancos = new List<ComBanco>();
                ComBanco row;
                while (LectorTablaSQL.Read())
                {
                    row = new ComBanco();
                    row.LlenadoDataNpgsql(LectorTablaSQL);
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

        public List<ComTipoCuenta> TiposCuentas()
        {

            //log.Debug("Entrando al metodo: " + MethodBase.GetCurrentMethod().Name);

            try
            {
                Conectar();

                ComandoSQL = Conector.CreateCommand();

                ComandoSQL.CommandText = string.Format("SELECT * FROM Tipos_Cuentas();");
                LectorTablaSQL = ComandoSQL.ExecuteReader();
                List<ComTipoCuenta> tiposCuentas = new List<ComTipoCuenta>();
                ComTipoCuenta row;
                while (LectorTablaSQL.Read())
                {
                    row = new ComTipoCuenta();
                    row.LlenadoDataNpgsql(LectorTablaSQL);
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

        public List<ComTipoParametro> TiposParametros()
        {

            //log.Debug("Entrando al metodo: " + MethodBase.GetCurrentMethod().Name);

            try
            {
                Conectar();

                ComandoSQL = Conector.CreateCommand();

                ComandoSQL.CommandText = string.Format("SELECT * FROM Tipos_Parametros();");
                LectorTablaSQL = ComandoSQL.ExecuteReader();
                List<ComTipoParametro> tiposParametros = new List<ComTipoParametro>();
                ComTipoParametro row;
                while (LectorTablaSQL.Read())
                {
                    row = new ComTipoParametro();
                    row.LlenadoDataNpgsql(LectorTablaSQL);
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

        public List<ComFrecuencia> Frecuencias()
        {

            //log.Debug("Entrando al metodo: " + MethodBase.GetCurrentMethod().Name);

            try
            {
                Conectar();

                ComandoSQL = Conector.CreateCommand();

                ComandoSQL.CommandText = string.Format("SELECT * FROM Frecuencias();");
                LectorTablaSQL = ComandoSQL.ExecuteReader();
                List<ComFrecuencia> frecuencias = new List<ComFrecuencia>();
                ComFrecuencia row;
                while (LectorTablaSQL.Read())
                {
                    row = new ComFrecuencia();
                    row.LlenadoDataNpgsql(LectorTablaSQL);
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

        public List<ComParametro> Parametros()
        {

            //log.Debug("Entrando al metodo: " + MethodBase.GetCurrentMethod().Name);

            try
            {
                Conectar();

                ComandoSQL = Conector.CreateCommand();

                ComandoSQL.CommandText = string.Format("SELECT * FROM Parametros();");
                LectorTablaSQL = ComandoSQL.ExecuteReader();
                List<ComParametro> parametros = new List<ComParametro>();
                ComParametro row;
                while (LectorTablaSQL.Read())
                {
                    row = new ComParametro();
                    row.LlenadoDataNpgsql(LectorTablaSQL);
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

        public List<ComTipoOperacion> TiposOperaciones()
        {

            //log.Debug("Entrando al metodo: " + MethodBase.GetCurrentMethod().Name);

            try
            {
                Conectar();

                ComandoSQL = Conector.CreateCommand();

                ComandoSQL.CommandText = string.Format("SELECT * FROM Tipos_Operaciones();");
                LectorTablaSQL = ComandoSQL.ExecuteReader();
                List<ComTipoOperacion> tiposOperaciones = new List<ComTipoOperacion>();
                ComTipoOperacion row;
                while (LectorTablaSQL.Read())
                {
                    row = new ComTipoOperacion();
                    row.LlenadoDataNpgsql(LectorTablaSQL);
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

        public List<ComTipoIdentificacion> TiposIdentificaciones()
        {

            //log.Debug("Entrando al metodo: " + MethodBase.GetCurrentMethod().Name);

            try
            {
                Conectar();

                ComandoSQL = Conector.CreateCommand();

                ComandoSQL.CommandText = string.Format("SELECT * FROM Tipos_Identificaciones();");
                LectorTablaSQL = ComandoSQL.ExecuteReader();
                List<ComTipoIdentificacion> tiposIdentificaciones = new List<ComTipoIdentificacion>();
                ComTipoIdentificacion row;
                while (LectorTablaSQL.Read())
                {
                    row = new ComTipoIdentificacion();
                    row.LlenadoDataNpgsql(LectorTablaSQL);
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

        public List<ComTarjeta> Tarjetas(int UsuarioId)
        {

            //log.Debug("Entrando al metodo: " + MethodBase.GetCurrentMethod().Name);

            try
            {
                Conectar();

                ComandoSQL = Conector.CreateCommand();

                ComandoSQL.CommandText = string.Format("SELECT * FROM Tarjetas(@UsuarioId);");
                ComandoSQL.Parameters.Add(new NpgsqlParameter("UsuarioId", UsuarioId));
                LectorTablaSQL = ComandoSQL.ExecuteReader();
                List<ComTarjeta> tarjetas = new List<ComTarjeta>();
                ComTarjeta row;
                while (LectorTablaSQL.Read())
                {
                    row = new ComTarjeta();
                    row.LlenadoDataNpgsql(LectorTablaSQL);
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

        public List<ComCuenta> Cuentas(int UsuarioId)
        {

            //log.Debug("Entrando al metodo: " + MethodBase.GetCurrentMethod().Name);

            try
            {
                Conectar();

                ComandoSQL = Conector.CreateCommand();

                ComandoSQL.CommandText = string.Format("SELECT * FROM Cuentas(@UsuarioId);");
                ComandoSQL.Parameters.Add(new NpgsqlParameter("UsuarioId", UsuarioId));
                LectorTablaSQL = ComandoSQL.ExecuteReader();
                List<ComCuenta> cuentas = new List<ComCuenta>();
                ComCuenta row;
                while (LectorTablaSQL.Read())
                {
                    row = new ComCuenta();
                    row.LlenadoDataNpgsql(LectorTablaSQL);
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

        public List<ComReintegro> ReintegrosActivos(int UsuarioId, int solicitante)
        {

            //log.Debug("Entrando al metodo: " + MethodBase.GetCurrentMethod().Name);

            try
            {
                Conectar();

                ComandoSQL = Conector.CreateCommand();

                ComandoSQL.CommandText = string.Format("SELECT * FROM Reintegros_Activos(@UsuarioId, @solicitante);");
                ComandoSQL.Parameters.Add(new NpgsqlParameter("UsuarioId", UsuarioId));
                ComandoSQL.Parameters.Add(new NpgsqlParameter("solicitante", solicitante));
                LectorTablaSQL = ComandoSQL.ExecuteReader();
                List<ComReintegro> reintegros = new List<ComReintegro>();
                ComReintegro row;
                while (LectorTablaSQL.Read())
                {
                    row = new ComReintegro();
                    row.LlenadoDataNpgsql(LectorTablaSQL);
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

        public List<ComReintegro> ReintegrosCancelados(int UsuarioId, int solicitante)
        {

            //log.Debug("Entrando al metodo: " + MethodBase.GetCurrentMethod().Name);

            try
            {
                Conectar();

                ComandoSQL = Conector.CreateCommand();

                ComandoSQL.CommandText = string.Format("SELECT * FROM Reintegros_Cancelados(@UsuarioId, @solicitante);");
                ComandoSQL.Parameters.Add(new NpgsqlParameter("UsuarioId", UsuarioId));
                ComandoSQL.Parameters.Add(new NpgsqlParameter("solicitante", solicitante));
                LectorTablaSQL = ComandoSQL.ExecuteReader();
                List<ComReintegro> reintegros = new List<ComReintegro>();
                ComReintegro row;
                while (LectorTablaSQL.Read())
                {
                    row = new ComReintegro();
                    row.LlenadoDataNpgsql(LectorTablaSQL);
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

        public List<ComReintegro> ReintegrosExitosos(int UsuarioId, int solicitante)
        {

            //log.Debug("Entrando al metodo: " + MethodBase.GetCurrentMethod().Name);

            try
            {
                Conectar();

                ComandoSQL = Conector.CreateCommand();

                ComandoSQL.CommandText = string.Format("SELECT * FROM Reintegros_Exitosos(@UsuarioId, @solicitante);");
                ComandoSQL.Parameters.Add(new NpgsqlParameter("UsuarioId", UsuarioId));
                ComandoSQL.Parameters.Add(new NpgsqlParameter("solicitante", solicitante));
                LectorTablaSQL = ComandoSQL.ExecuteReader();
                List<ComReintegro> reintegros = new List<ComReintegro>();
                ComReintegro row;
                while (LectorTablaSQL.Read())
                {
                    row = new ComReintegro();
                    row.LlenadoDataNpgsql(LectorTablaSQL);
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

        public List<ComPago> CobrosActivos(int UsuarioId, int solicitante)
        {

            //log.Debug("Entrando al metodo: " + MethodBase.GetCurrentMethod().Name);

            try
            {
                Conectar();

                ComandoSQL = Conector.CreateCommand();

                ComandoSQL.CommandText = string.Format("SELECT * FROM Cobros_Activos(@UsuarioId, @solicitante);");
                ComandoSQL.Parameters.Add(new NpgsqlParameter("UsuarioId", UsuarioId));
                ComandoSQL.Parameters.Add(new NpgsqlParameter("solicitante", solicitante));
                LectorTablaSQL = ComandoSQL.ExecuteReader();
                List<ComPago> cobros = new List<ComPago>();
                ComPago row;
                while (LectorTablaSQL.Read())
                {
                    row = new ComPago();
                    row.LlenadoDataNpgsql(LectorTablaSQL);
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

        public List<ComPago> CobrosCancelados(int UsuarioId, int solicitante)
        {

            //log.Debug("Entrando al metodo: " + MethodBase.GetCurrentMethod().Name);

            try
            {
                Conectar();

                ComandoSQL = Conector.CreateCommand();

                ComandoSQL.CommandText = string.Format("SELECT * FROM Cobros_Cancelados(@UsuarioId, @solicitante);");
                ComandoSQL.Parameters.Add(new NpgsqlParameter("UsuarioId", UsuarioId));
                ComandoSQL.Parameters.Add(new NpgsqlParameter("solicitante", solicitante));
                LectorTablaSQL = ComandoSQL.ExecuteReader();
                List<ComPago> cobros = new List<ComPago>();
                ComPago row;
                while (LectorTablaSQL.Read())
                {
                    row = new ComPago();
                    row.LlenadoDataNpgsql(LectorTablaSQL);
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

        public List<ComPago> CobrosExitosos(int UsuarioId, int solicitante)
        {

            //log.Debug("Entrando al metodo: " + MethodBase.GetCurrentMethod().Name);

            try
            {
                Conectar();

                ComandoSQL = Conector.CreateCommand();

                ComandoSQL.CommandText = string.Format("SELECT * FROM Cobros_Exitosos(@UsuarioId, @solicitante);");
                ComandoSQL.Parameters.Add(new NpgsqlParameter("UsuarioId", UsuarioId));
                ComandoSQL.Parameters.Add(new NpgsqlParameter("solicitante", solicitante));
                LectorTablaSQL = ComandoSQL.ExecuteReader();
                List<ComPago> cobros = new List<ComPago>();
                ComPago row;
                while (LectorTablaSQL.Read())
                {
                    row = new ComPago();
                    row.LlenadoDataNpgsql(LectorTablaSQL);
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

        public List<ComUsuarioParametro> ParametrosUsuario(int UsuarioId)
        {

            //log.Debug("Entrando al metodo: " + MethodBase.GetCurrentMethod().Name);

            try
            {
                Conectar();

                ComandoSQL = Conector.CreateCommand();

                ComandoSQL.CommandText = string.Format("SELECT * FROM Parametros_Usuario(@UsuarioId);");
                ComandoSQL.Parameters.Add(new NpgsqlParameter("UsuarioId", UsuarioId));
                LectorTablaSQL = ComandoSQL.ExecuteReader();
                List<ComUsuarioParametro> parametrosUsuario = new List<ComUsuarioParametro>();
                ComUsuarioParametro row;
                while (LectorTablaSQL.Read())
                {
                    row = new ComUsuarioParametro();
                    row.LlenadoDataNpgsql(LectorTablaSQL);
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

        public ComUsuario InformacionPersona(string usuario)
        {

            //log.Debug("Entrando al metodo: " + MethodBase.GetCurrentMethod().Name);

            try
            {
                Conectar();

                ComandoSQL = Conector.CreateCommand();

                ComandoSQL.CommandText = string.Format("SELECT * FROM Informacion_persona(@usuario);");
                ComandoSQL.Parameters.Add(new NpgsqlParameter("usuario", usuario));
                LectorTablaSQL = ComandoSQL.ExecuteReader();
                if (LectorTablaSQL.Read())
                {
                    ComUsuario informacion_persona = new ComUsuario();
                    informacion_persona.LlenadoDataNpgsql(LectorTablaSQL);
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

        public double SaldoMonedero(int UsuarioId)
        {

            //log.Debug("Entrando al metodo: " + MethodBase.GetCurrentMethod().Name);
            double saldo;
            try
            {
                Conectar();

                ComandoSQL = Conector.CreateCommand();

                ComandoSQL.CommandText = string.Format("SELECT * FROM Saldo_Monedero(@UsuarioId);");
                ComandoSQL.Parameters.Add(new NpgsqlParameter("UsuarioId", UsuarioId));
                LectorTablaSQL = ComandoSQL.ExecuteReader();
                try
                {
                    saldo = Double.Parse(LectorTablaSQL.GetString(0));
                }
                catch (Exception ex)
                {
                    saldo = 0;
                }
                return saldo;
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

        //Debe retornar el historial de operaciones
        public List<ComOperacionTarjeta> HistorialOperacionesTarjeta(int tarjetaId)
        {

            //log.Debug("Entrando al metodo: " + MethodBase.GetCurrentMethod().Name);

            try
            {
                Conectar();

                ComandoSQL = Conector.CreateCommand();

                ComandoSQL.CommandText = string.Format("SELECT * FROM Historial_Operaciones_Tarjetas(@tarjetaId);");
                ComandoSQL.Parameters.Add(new NpgsqlParameter("tarjetaId", tarjetaId));
                LectorTablaSQL = ComandoSQL.ExecuteReader();
                List<ComOperacionTarjeta> operacionesTarjeta = new List<ComOperacionTarjeta>();
                ComOperacionTarjeta row;
                while (LectorTablaSQL.Read())
                {
                    row = new ComOperacionTarjeta();
                    row.LlenadoDataNpgsql(LectorTablaSQL);
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

        //Debe retornar el historial de operaciones
        public List<ComOperacionCuenta> HistorialOperacionesCuenta(int CuentaId)
        {

            //log.Debug("Entrando al metodo: " + MethodBase.GetCurrentMethod().Name);

            try
            {
                Conectar();

                ComandoSQL = Conector.CreateCommand();

                ComandoSQL.CommandText = string.Format("SELECT * FROM Historial_Operaciones_Cuenta(@CuentaId);");
                ComandoSQL.Parameters.Add(new NpgsqlParameter("CuentaId", CuentaId));
                LectorTablaSQL = ComandoSQL.ExecuteReader();
                List<ComOperacionCuenta> operacionesCuenta = new List<ComOperacionCuenta>();
                ComOperacionCuenta row;
                while (LectorTablaSQL.Read())
                {
                    row = new ComOperacionCuenta();
                    row.LlenadoDataNpgsql(LectorTablaSQL);
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

        public List<ComOperacionMonedero> HistorialOperacionesMonedero(int UsuarioId)
        {

            //log.Debug("Entrando al metodo: " + MethodBase.GetCurrentMethod().Name);

            try
            {
                Conectar();

                ComandoSQL = Conector.CreateCommand();

                ComandoSQL.CommandText = string.Format("SELECT * FROM Historial_Operaciones_Monedero(@UsuarioId);");
                ComandoSQL.Parameters.Add(new NpgsqlParameter("UsuarioId", UsuarioId));
                LectorTablaSQL = ComandoSQL.ExecuteReader();
                List<ComOperacionMonedero> operacionesMonedero = new List<ComOperacionMonedero>();
                ComOperacionMonedero row;
                while (LectorTablaSQL.Read())
                {
                    row = new ComOperacionMonedero();
                    row.LlenadoDataNpgsql(LectorTablaSQL);
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

    }
}

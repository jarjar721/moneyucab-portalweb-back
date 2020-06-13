using Npgsql;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Reflection;
using DAO.Interfaces;
using Excepciones;

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

        public void EstadosCiviles()
        {

            //log.Debug("Entrando al metodo: " + MethodBase.GetCurrentMethod().Name);

            try
            {
                Conectar();

                ComandoSQL = Conector.CreateCommand();

                ComandoSQL.CommandText = string.Format("SELECT * FROM Estados_Civiles();");
                LectorTablaSQL = ComandoSQL.ExecuteReader();
                if (LectorTablaSQL.Read())
                {
                    Console.WriteLine(LectorTablaSQL.GetString(0));
                }
                else
                {
                    //Llenado de datos para devolverlos.
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

        public void TiposTarjeta()
        {

            //log.Debug("Entrando al metodo: " + MethodBase.GetCurrentMethod().Name);

            try
            {
                Conectar();

                ComandoSQL = Conector.CreateCommand();

                ComandoSQL.CommandText = string.Format("SELECT * FROM tipos_tarjeta();");
                LectorTablaSQL = ComandoSQL.ExecuteReader();
                if (LectorTablaSQL.Read())
                {
                    Console.WriteLine(LectorTablaSQL.GetString(0));
                }
                else
                {
                    //Llenado de datos para devolverlos.
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

        public void Bancos()
        {

            //log.Debug("Entrando al metodo: " + MethodBase.GetCurrentMethod().Name);

            try
            {
                Conectar();

                ComandoSQL = Conector.CreateCommand();

                ComandoSQL.CommandText = string.Format("SELECT * FROM Bancos();");
                LectorTablaSQL = ComandoSQL.ExecuteReader();
                if (LectorTablaSQL.Read())
                {
                    Console.WriteLine(LectorTablaSQL.GetString(0));
                }
                else
                {
                    //Llenado de datos para devolverlos.
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

        public void TiposCuentas()
        {

            //log.Debug("Entrando al metodo: " + MethodBase.GetCurrentMethod().Name);

            try
            {
                Conectar();

                ComandoSQL = Conector.CreateCommand();

                ComandoSQL.CommandText = string.Format("SELECT * FROM Tipos_Cuentas();");
                LectorTablaSQL = ComandoSQL.ExecuteReader();
                if (LectorTablaSQL.Read())
                {
                    Console.WriteLine(LectorTablaSQL.GetString(0));
                }
                else
                {
                    //Llenado de datos para devolverlos.
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

        public void TiposParametros()
        {

            //log.Debug("Entrando al metodo: " + MethodBase.GetCurrentMethod().Name);

            try
            {
                Conectar();

                ComandoSQL = Conector.CreateCommand();

                ComandoSQL.CommandText = string.Format("SELECT * FROM Tipos_Parametros();");
                LectorTablaSQL = ComandoSQL.ExecuteReader();
                if (LectorTablaSQL.Read())
                {
                    Console.WriteLine(LectorTablaSQL.GetString(0));
                }
                else
                {
                    //Llenado de datos para devolverlos.
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

        public void Frecuencias()
        {

            //log.Debug("Entrando al metodo: " + MethodBase.GetCurrentMethod().Name);

            try
            {
                Conectar();

                ComandoSQL = Conector.CreateCommand();

                ComandoSQL.CommandText = string.Format("SELECT * FROM Frecuencias();");
                LectorTablaSQL = ComandoSQL.ExecuteReader();
                if (LectorTablaSQL.Read())
                {
                    Console.WriteLine(LectorTablaSQL.GetString(0));
                }
                else
                {
                    //Llenado de datos para devolverlos.
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

        public void Parametros()
        {

            //log.Debug("Entrando al metodo: " + MethodBase.GetCurrentMethod().Name);

            try
            {
                Conectar();

                ComandoSQL = Conector.CreateCommand();

                ComandoSQL.CommandText = string.Format("SELECT * FROM Parametros();");
                LectorTablaSQL = ComandoSQL.ExecuteReader();
                if (LectorTablaSQL.Read())
                {
                    Console.WriteLine(LectorTablaSQL.GetString(0));
                }
                else
                {
                    //Llenado de datos para devolverlos.
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

        public void TiposOperaciones()
        {

            //log.Debug("Entrando al metodo: " + MethodBase.GetCurrentMethod().Name);

            try
            {
                Conectar();

                ComandoSQL = Conector.CreateCommand();

                ComandoSQL.CommandText = string.Format("SELECT * FROM Tipos_Operaciones();");
                LectorTablaSQL = ComandoSQL.ExecuteReader();
                if (LectorTablaSQL.Read())
                {
                    Console.WriteLine(LectorTablaSQL.GetString(0));
                }
                else
                {
                    //Llenado de datos para devolverlos.
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

        public void TiposIdentificaciones()
        {

            //log.Debug("Entrando al metodo: " + MethodBase.GetCurrentMethod().Name);

            try
            {
                Conectar();

                ComandoSQL = Conector.CreateCommand();

                ComandoSQL.CommandText = string.Format("SELECT * FROM Tipos_Identificaciones();");
                LectorTablaSQL = ComandoSQL.ExecuteReader();
                if (LectorTablaSQL.Read())
                {
                    Console.WriteLine(LectorTablaSQL.GetString(0));
                }
                else
                {
                    //Llenado de datos para devolverlos.
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

        public void Tarjetas(int UsuarioId)
        {

            //log.Debug("Entrando al metodo: " + MethodBase.GetCurrentMethod().Name);

            try
            {
                Conectar();

                ComandoSQL = Conector.CreateCommand();

                ComandoSQL.CommandText = string.Format("SELECT * FROM Tarjetas(@UsuarioId);");
                ComandoSQL.Parameters.Add(new NpgsqlParameter("UsuarioId", UsuarioId));
                LectorTablaSQL = ComandoSQL.ExecuteReader();
                if (LectorTablaSQL.Read())
                {
                    Console.WriteLine(LectorTablaSQL.GetString(0));
                }
                else
                {
                    //Llenado de datos para devolverlos.
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

        public void Cuentas(int UsuarioId)
        {

            //log.Debug("Entrando al metodo: " + MethodBase.GetCurrentMethod().Name);

            try
            {
                Conectar();

                ComandoSQL = Conector.CreateCommand();

                ComandoSQL.CommandText = string.Format("SELECT * FROM Cuentas(@UsuarioId);");
                ComandoSQL.Parameters.Add(new NpgsqlParameter("UsuarioId", UsuarioId));
                LectorTablaSQL = ComandoSQL.ExecuteReader();
                if (LectorTablaSQL.Read())
                {
                    Console.WriteLine(LectorTablaSQL.GetString(0));
                }
                else
                {
                    //Llenado de datos para devolverlos.
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

        public void ReintegrosActivos(int UsuarioId, int solicitante)
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
                if (LectorTablaSQL.Read())
                {
                    Console.WriteLine(LectorTablaSQL.GetString(0));
                }
                else
                {
                    //Llenado de datos para devolverlos.
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

        public void ReintegrosCancelados(int UsuarioId, int solicitante)
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
                if (LectorTablaSQL.Read())
                {
                    Console.WriteLine(LectorTablaSQL.GetString(0));
                }
                else
                {
                    //Llenado de datos para devolverlos.
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

        public void ReintegrosExitosos(int UsuarioId, int solicitante)
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
                if (LectorTablaSQL.Read())
                {
                    Console.WriteLine(LectorTablaSQL.GetString(0));
                }
                else
                {
                    //Llenado de datos para devolverlos.
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

        public void CobrosActivos(int UsuarioId, int solicitante)
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
                if (LectorTablaSQL.Read())
                {
                    Console.WriteLine(LectorTablaSQL.GetString(0));
                }
                else
                {
                    //Llenado de datos para devolverlos.
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

        public void CobrosCancelados(int UsuarioId, int solicitante)
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
                if (LectorTablaSQL.Read())
                {
                    Console.WriteLine(LectorTablaSQL.GetString(0));
                }
                else
                {
                    //Llenado de datos para devolverlos.
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

        public void CobrosExitosos(int UsuarioId, int solicitante)
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
                if (LectorTablaSQL.Read())
                {
                    Console.WriteLine(LectorTablaSQL.GetString(0));
                }
                else
                {
                    //Llenado de datos para devolverlos.
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

        public void ParametrosUsuario(int UsuarioId)
        {

            //log.Debug("Entrando al metodo: " + MethodBase.GetCurrentMethod().Name);

            try
            {
                Conectar();

                ComandoSQL = Conector.CreateCommand();

                ComandoSQL.CommandText = string.Format("SELECT * FROM Parametros_Usuario(@UsuarioId);");
                ComandoSQL.Parameters.Add(new NpgsqlParameter("UsuarioId", UsuarioId));
                LectorTablaSQL = ComandoSQL.ExecuteReader();
                if (LectorTablaSQL.Read())
                {
                    Console.WriteLine(LectorTablaSQL.GetString(0));
                }
                else
                {
                    //Llenado de datos para devolverlos.
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

        public void InformacionPersona(string usuario)
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
                    Console.WriteLine(LectorTablaSQL.GetString(0));
                }
                else
                {
                    //Llenado de datos para devolverlos.
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

        public void SaldoMonedero(int UsuarioId)
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
                if (LectorTablaSQL.Read())
                {
                    try
                    {
                        saldo = Double.Parse(LectorTablaSQL.GetString(0));
                    }
                    catch (Exception ex)
                    {
                        saldo = 0;
                    }
                }
                else
                {
                    //Llenado de datos para devolverlos.
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

        //Debe retornar el historial de operaciones
        public void HistorialOperacionesTarjeta(int tarjetaId)
        {

            //log.Debug("Entrando al metodo: " + MethodBase.GetCurrentMethod().Name);

            try
            {
                Conectar();

                ComandoSQL = Conector.CreateCommand();

                ComandoSQL.CommandText = string.Format("SELECT * FROM Historial_Operaciones_Tarjetas(@tarjetaId);");
                ComandoSQL.Parameters.Add(new NpgsqlParameter("tarjetaId", tarjetaId));
                LectorTablaSQL = ComandoSQL.ExecuteReader();
                if (LectorTablaSQL.Read())
                {
                    Console.WriteLine(LectorTablaSQL.GetString(0));
                }
                else
                {
                    //Llenado de datos para devolverlos.
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

        //Debe retornar el historial de operaciones
        public void HistorialOperacionesCuenta(int CuentaId)
        {

            //log.Debug("Entrando al metodo: " + MethodBase.GetCurrentMethod().Name);

            try
            {
                Conectar();

                ComandoSQL = Conector.CreateCommand();

                ComandoSQL.CommandText = string.Format("SELECT * FROM Historial_Operaciones_Cuenta(@CuentaId);");
                ComandoSQL.Parameters.Add(new NpgsqlParameter("CuentaId", CuentaId));
                LectorTablaSQL = ComandoSQL.ExecuteReader();
                if (LectorTablaSQL.Read())
                {
                    Console.WriteLine(LectorTablaSQL.GetString(0));
                }
                else
                {
                    //Llenado de datos para devolverlos.
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

        public void HistorialOperacionesMonedero(int UsuarioId)
        {

            //log.Debug("Entrando al metodo: " + MethodBase.GetCurrentMethod().Name);

            try
            {
                Conectar();

                ComandoSQL = Conector.CreateCommand();

                ComandoSQL.CommandText = string.Format("SELECT * FROM Historial_Operaciones_Monedero(@UsuarioId);");
                ComandoSQL.Parameters.Add(new NpgsqlParameter("UsuarioId", UsuarioId));
                LectorTablaSQL = ComandoSQL.ExecuteReader();
                if (LectorTablaSQL.Read())
                {
                    Console.WriteLine(LectorTablaSQL.GetString(0));
                }
                else
                {
                    //Llenado de datos para devolverlos.
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

    }
}

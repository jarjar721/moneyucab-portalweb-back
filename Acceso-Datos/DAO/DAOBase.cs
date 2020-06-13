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
    public class DAOBase : DAO, IDAO
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
    }
}

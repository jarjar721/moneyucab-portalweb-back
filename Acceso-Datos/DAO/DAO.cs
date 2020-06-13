using Excepciones;
using Npgsql;
using System;
using System.Configuration;

namespace DAO
{
    /// <summary>
    /// Class <c>DAO</c>
    /// Establece la estructura y el medio para poder actuar y conectarse con la base de datos para poder manejar inforamción necesario para el sistema.
    /// Contiene todos los atributos necesarios para su buena operatividad.
    /// </summary>
    public class DAO
    {
        /// <summary>
        /// Establece la conexión con la base de datos.
        /// </summary>
        private Npgsql.NpgsqlConnection _conector;

        /// <summary>
        /// Establece el dato y el medio por el cuaal se conforma la conexión de la base de datos.
        /// </summary>
        private string _stringConexion;

        /// <summary>
        /// Establece el medio de comandos query contra la base de datos.
        /// </summary>
        private NpgsqlCommand _comandoSQL;

        /// <summary>
        /// Establece el medio lector para todas las respuestas que de la base de datos dentro del sistema.
        /// </summary>
        private NpgsqlDataReader _lectorTablaSQL;

        public NpgsqlConnection Conector
        {
            get { return _conector; }
            set { _conector = value; }
        }

        public string StringConexion
        {
            get { return _stringConexion; }
            set { _stringConexion = value; }
        }

        public NpgsqlCommand ComandoSQL
        {
            get { return _comandoSQL; }
            set { _comandoSQL = value; }
        }

        public NpgsqlDataReader LectorTablaSQL
        {
            get { return _lectorTablaSQL; }
            set { _lectorTablaSQL = value; }
        }

        /// <summary>
        /// Establece el método para realizar la apertura de conexión contra la base de datos.
        /// </summary>
        public void Conectar()
        {

            try
            {
                Conector = new NpgsqlConnection(StringConexion);
                Conector.Open();
            }
            catch (NpgsqlException ex)
            {
                throw new Exception();
            }
            catch (Exception ex)
            {
                throw new MoneyUcabException(ex);
            }

        }

        /// <summary>
        /// Establece el método par realizar la clausura de conexión contra la base de datos.
        /// </summary>
        public void Desconectar()
        {
            if (Conector != null)
            {
                Conector.Close();
                Conector.Dispose();
            }
        }


    }
}

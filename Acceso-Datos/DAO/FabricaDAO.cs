namespace DAO
{
    /// <summary>
    /// Class <c>FabricaDAO</c>
    /// Establece el medio de acción para realizar una creación específica de la implementación de acceso a datos sea por distintos sistemas.
    /// </summary>
    public class FabricaDAO
    {

        /// <summary>
        /// Establece la creación y la fabricación de la instanciación de un acceso a datos por la base de datos, siendo el DAOLogin.
        /// </summary>
        /// <returns>Retorna una instanciación de la clase DAOLogin</returns>
        public static DAOPsql CrearDaoPsql()
        {
            return new DAOPsql();
        }

        public static DAOBase CrearDaoBase()
        {
            return new DAOBase();
        }
    }
}

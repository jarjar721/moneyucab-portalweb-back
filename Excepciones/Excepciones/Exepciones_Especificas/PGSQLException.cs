using Npgsql;

namespace Excepciones.Excepciones_Especificas
{

    public class PGSQLException : MoneyUcabException
    {
        public static void ProcesamientoException(NpgsqlException ex)
        {
            PGSQLException exception = new PGSQLException();
            exception.codigo = ex.ErrorCode;
            exception.error = ex.Message;
            exception.excepcionOrigen = ex;
            throw exception;
        }
    }
}

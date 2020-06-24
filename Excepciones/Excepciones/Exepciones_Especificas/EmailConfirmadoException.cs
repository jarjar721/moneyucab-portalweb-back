namespace Excepciones.Excepciones_Especificas
{
    public class EmailConfirmadoException : MoneyUcabException
    {
        public static void EmailConfirmado()
        {
            EmailConfirmadoException exception = new EmailConfirmadoException();
            exception.codigo = 9;
            exception.error = "El usuario especificado ya tiene el email confirmado.";
            throw exception;
        }

        public static void EmailFalloEnvioConfirmacion()
        {
            EmailConfirmadoException exception = new EmailConfirmadoException();
            exception.codigo = 10;
            exception.error = "Ocurrió un problema al intentar enviar el correo de confirmación.";
            throw exception;
        }

        public static void EmailNoConfirmado()
        {
            EmailConfirmadoException exception = new EmailConfirmadoException();
            exception.codigo = 16;
            exception.error = "El usuario no tiene el email confirmado.";
            throw exception;
        }
    }
}

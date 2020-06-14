namespace Excepciones.Excepciones_Especificas
{
    public class EmailConfirmadoException : MoneyUcabException
    {
        public static void EmailConfirmado()
        {
            EmailConfirmadoException exception = new EmailConfirmadoException();
            exception.Codigo = 9;
            exception.Error = "El usuario especificado ya tiene el email confirmado.";
            throw exception;
        }

        public static void EmailFalloEnvioConfirmacion()
        {
            EmailConfirmadoException exception = new EmailConfirmadoException();
            exception.Codigo = 10;
            exception.Error = "Ocurrió un problema al intentar enviar el correo de confirmación.";
            throw exception;
        }

        public static void EmailNoConfirmado()
        {
            EmailConfirmadoException exception = new EmailConfirmadoException();
            exception.Codigo = 16;
            exception.Error = "El usuario no tiene el email confirmado.";
            throw exception;
        }
    }
}

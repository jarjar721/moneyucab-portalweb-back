namespace Excepciones.Excepciones_Especificas
{

    public class UsuarioExistenteException : MoneyUcabException
    {
        public static void UsuarioNoExistente()
        {
            UsuarioExistenteException exception = new UsuarioExistenteException();
            exception.codigo = 11;
            exception.error = "El usuario no existe en el sistema";
            throw exception;
        }

        public static void UsuarioExistente()
        {
            UsuarioExistenteException exception = new UsuarioExistenteException();
            exception.codigo = 17;
            exception.error = "El usuario existe en el sistema";
            throw exception;
        }
    }
}

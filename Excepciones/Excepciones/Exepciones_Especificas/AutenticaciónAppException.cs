namespace Excepciones.Excepciones_Especificas
{

    public class AutenticacionAppException : MoneyUcabException
    {
        public static void UsuarioInvalidoApp()
        {
            AutenticacionAppException exception = new AutenticacionAppException();
            exception.codigo = 50;
            exception.error = "El usuario no está autenticado en una aplicación la cual no tiene acceso";
            throw exception;
        }
    }
}

namespace Excepciones.Excepciones_Especificas
{

    public class AutenticacionException : MoneyUcabException
    {
        public static void UsuarioNoAutenticado()
        {
            AutenticacionException exception = new AutenticacionException();
            exception.codigo = 15;
            exception.error = "El usuario no está autenticado";
            throw exception;
        }
    }
}

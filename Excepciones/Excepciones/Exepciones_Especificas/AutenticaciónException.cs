namespace Excepciones.Excepciones_Especificas
{

    public class AutenticacionException : MoneyUcabException
    {
        public static void UsuarioNoAutenticado()
        {
            AutenticacionException exception = new AutenticacionException();
            exception.Codigo = 15;
            exception.Error = "El usuario no está autenticado";
            throw exception;
        }
    }
}

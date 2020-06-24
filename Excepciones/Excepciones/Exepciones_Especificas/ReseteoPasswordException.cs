namespace Excepciones.Excepciones_Especificas
{

    public class ReseteoPasswordException : MoneyUcabException
    {
        public static void ReseteoPasswordFallido()
        {
            ReseteoPasswordException exception = new ReseteoPasswordException();
            exception.codigo = 14;
            exception.error = "El password no se logró realizar el reseteo.";
            throw exception;
        }
    }
}

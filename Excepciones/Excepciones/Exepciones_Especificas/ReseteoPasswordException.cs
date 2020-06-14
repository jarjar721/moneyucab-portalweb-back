namespace Excepciones.Excepciones_Especificas
{

    public class ReseteoPasswordException : MoneyUcabException
    {
        public static void ReseteoPasswordFallido()
        {
            ReseteoPasswordException exception = new ReseteoPasswordException();
            exception.Codigo = 14;
            exception.Error = "El password no se logró realizar el reseteo.";
            throw exception;
        }
    }
}

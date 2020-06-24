using System;

namespace Excepciones.Excepciones_Especificas
{
    public class UsuarioBloqueadoException : MoneyUcabException
    {
        public static void UsuarioBloqueado(DateTimeOffset Date)
        {
            UsuarioBloqueadoException exception = new UsuarioBloqueadoException();
            exception.codigo = 12;
            exception.error = "El usuario se encuentra bloqueado desde la fecha: " + Date.ToString();
            throw exception;
        }

        public static void IntentoFallido(int IntentosRestantes)
        {
            UsuarioBloqueadoException exception = new UsuarioBloqueadoException();
            exception.codigo = 13;
            exception.error = "El usuario falló en el intento de realizar login, tiene " + IntentosRestantes + " intentos restantes.";
            throw exception;
        }
    }
}

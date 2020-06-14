using System;

namespace Excepciones.Excepciones_Especificas
{
    public class UsuarioBloqueadoException : MoneyUcabException
    {
        public static void UsuarioBloqueado(DateTimeOffset date)
        {
            UsuarioBloqueadoException exception = new UsuarioBloqueadoException();
            exception.Codigo = 12;
            exception.Error = "El usuario se encuentra bloqueado desde la fecha: " + date.ToString();
            throw exception;
        }

        public static void IntentoFallido(int intentos_restantes)
        {
            UsuarioBloqueadoException exception = new UsuarioBloqueadoException();
            exception.Codigo = 13;
            exception.Error = "El usuario falló en el intento de realizar login, tiene " + intentos_restantes + " intentos restantes.";
            throw exception;
        }
    }
}

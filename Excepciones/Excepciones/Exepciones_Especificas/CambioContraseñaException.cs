namespace Excepciones.Excepciones_Especificas
{
    /// <summary>
    /// Excepción personalizada respecto a la autenticación dentro de una app, establece la difernecia de login entre las aplicaciones y la categorización de usuario: comercio y persona.
    /// </summary>
    public class CambioContraseñaException : MoneyUcabException
    {
        /// <summary>
        /// Método predeterminado para arrojar una excepción definida de este tipo.
        /// </summary>
        public static void CambioContraseñaError()
        {
            CambioContraseñaException exception = new CambioContraseñaException();
            exception.codigo = 70;
            exception.error = "No se pudo concretar el cambio de contraseña";
            throw exception;
        }
    }
}

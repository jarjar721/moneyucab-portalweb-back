﻿namespace Excepciones.Excepciones_Especificas
{
    /// <summary>
    /// Excepción personalizada de autenticación, establece que el usuario no ha realizado un login.
    /// </summary>
    public class AutenticacionException : MoneyUcabException
    {
        /// <summary>
        /// Método predeterminado para establecer que el usuario no ha sido autenticado.
        /// </summary>
        public static void UsuarioNoAutenticado()
        {
            AutenticacionException exception = new AutenticacionException();
            exception.codigo = 15;
            exception.error = "El usuario no está autenticado";
            throw exception;
        }
    }
}

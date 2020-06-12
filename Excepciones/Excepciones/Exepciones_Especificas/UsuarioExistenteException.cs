using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Excepciones.Excepciones_Especificas
{
    
    public class UsuarioExistenteException : MoneyUcabException
    {
        public static void UsuarioNoExistente()
        {
            UsuarioExistenteException exception = new UsuarioExistenteException();
            exception.Codigo = 11;
            exception.Error = "El usuario no existe en el sistema";
            throw exception;
        }

        public static void UsuarioExistente()
        {
            UsuarioExistenteException exception = new UsuarioExistenteException();
            exception.Codigo = 17;
            exception.Error = "El usuario existe en el sistema";
            throw exception;
        }
    }
}

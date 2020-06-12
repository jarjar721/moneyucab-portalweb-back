using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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

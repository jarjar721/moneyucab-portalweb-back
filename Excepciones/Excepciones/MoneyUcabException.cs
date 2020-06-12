using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Excepciones
{
    public class MoneyUcabException : Exception
    {
        protected string _error;
        protected int _codigo;
        protected Exception _excepcionOrigen;

        public MoneyUcabException(Exception ex)
        {
            this.ExcepcionOrigen = ex;
        }

        public MoneyUcabException(string error, int codigo)
        {
            this.Error = error;
            this.Codigo = codigo;
        }

        public MoneyUcabException(Exception ex, string error, int codigo)
        {
            this.ExcepcionOrigen = ex;
            this.Error = error;
            this.Codigo = codigo;
        }

        public string Error
        {
            get { return _error; }
            set { _error = value; }
        }

        public int Codigo
        {
            get { return _codigo; }
            set { _codigo = value; }
        }
        
        public MoneyUcabException() { }

        public Exception ExcepcionOrigen
        {
            get { return _excepcionOrigen; }
            set { _excepcionOrigen = value; }
        }

        public Object response()
        {
            return new { error = this.Error, codigo = this.Codigo};
        }
    }
}

﻿using System;

namespace Excepciones
{
    public class MoneyUcabException : Exception
    {
        protected string _error;
        protected int _codigo;
        protected Exception _excepcionOrigen;

        public MoneyUcabException(Exception Ex)
        {
            this.excepcionOrigen = Ex;
        }

        public MoneyUcabException(string Error, int Codigo)
        {
            this.error = Error;
            this.codigo = Codigo;
        }

        public MoneyUcabException(Exception Ex, string Error, int Codigo)
        {
            this.excepcionOrigen = Ex;
            this.error = Error;
            this.codigo = Codigo;
        }

        public string error
        {
            get { return _error; }
            set { _error = value; }
        }

        public int codigo
        {
            get { return _codigo; }
            set { _codigo = value; }
        }

        public MoneyUcabException() { }

        public Exception excepcionOrigen
        {
            get { return _excepcionOrigen; }
            set { _excepcionOrigen = value; }
        }

        public Object Response()
        {
            return new { error = this.error, codigo = this.codigo };
        }

        public static Object ResponseErrorDesconocido(Exception Ex)
        {
            return new { Error = "Error desconocido. Comunicarse con el administrador e informar: " + Ex.StackTrace };
        }
    }
}

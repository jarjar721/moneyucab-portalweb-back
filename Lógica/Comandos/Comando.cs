﻿using Comandos;

namespace Comandos
{
    public abstract class Comando<TSalida> : IComando<TSalida>
    {
        /// <summary>
        /// Metood que ejecuta la accion del comando
        /// </summary>
        /// <returns></returns>
        public abstract TSalida EjecutarAsync();
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Comandos.ComandosService.Simples
{
    /// <summary>
    /// Clase <c>ComandoVerificarStatusUsuario</c>.
    /// Ejecuta únicamente la verificación del status de usuario para pode conocer dicho atributo en el contexto del sistema.
    /// </summary>
    /// <remarks>
    /// <para>La operación de esta clase puede contener cualquier métodos concebido para esta funcionalidad.</para>
    /// </remarks>
    public class ComandoVerificarStatusUsuario : Comando<bool>
    {
        /// <summary>
        /// Establece el contexto en el que se encuentra el usuario.
        /// </summary>
        private int _status;

        /// <summary>
        /// Establece los parámetros necesarios en su ejecución al instanciar el comando.
        /// </summary>
        /// <param name="status">Establece el contexto en el que se encuentra el usuario.</param>
        public ComandoVerificarStatusUsuario(int status)
        {
            Status = status;
        }

        public int Status
        {
            get { return _status; }
            set { _status = value; }
        }

        public override bool Ejecutar()
        {
            throw new NotImplementedException();
        }
    }
}

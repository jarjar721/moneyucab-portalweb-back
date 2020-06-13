using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAO.Interfaces
{
    /// <summary>
    /// Interface <c>IDAOLogin</c>
    /// Interfaz que establece los métodos que deben implementar cualquier dao para realizar los distintos ingresos en l sistema.
    /// </summary>
    public interface IDAO
    {
        //Operaciones de consulta sobre las entidades existentes
        void EstadosCiviles();

        void TiposTarjeta();

        void Bancos();

        void TiposCuentas();

        void TiposParametros();

        void Frecuencias();

        void Parametros();

        void TiposOperaciones();

        void TiposIdentificaciones();

        void Tarjetas(int UsuarioId);

        void Cuentas(int UsuarioId);

        void ReintegrosActivos(int UsuarioId, int solicitante);

        void ReintegrosCancelados(int UsuarioId, int solicitante);

        void ReintegrosExitosos(int UsuarioId, int solicitante);

        void CobrosActivos(int UsuarioId, int solicitante);

        void CobrosCancelados(int UsuarioId, int solicitante);

        void CobrosExitosos(int UsuarioId, int solicitante);

        void ParametrosUsuario(int UsuarioId);

        void InformacionPersona(string usuario);

        void SaldoMonedero(int UsuarioId);

        //Debe retornar el historial de operaciones
        void HistorialOperacionesTarjeta(int tarjetaId);

        //Debe retornar el historial de operaciones
        void HistorialOperacionesCuenta(int CuentaId);

        void HistorialOperacionesMonedero(int UsuarioId);

        //Operaciones de acción sobre la base de datos

    }
}
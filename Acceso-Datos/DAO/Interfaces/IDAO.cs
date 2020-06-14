using Comunes.Comun;
using System.Collections.Generic;

namespace DAO.Interfaces
{
    /// <summary>
    /// Interface <c>IDAOLogin</c>
    /// Interfaz que establece los métodos que deben implementar cualquier dao para realizar los distintos ingresos en l sistema.
    /// </summary>
    public interface IDAO
    {
        //Operaciones de consulta sobre las entidades existentes
        List<ComEstadoCivil> EstadosCiviles();

        List<ComTipoTarjeta> TiposTarjeta();

        List<ComBanco> Bancos();

        List<ComTipoCuenta> TiposCuentas();

        List<ComTipoParametro> TiposParametros();

        List<ComFrecuencia> Frecuencias();

        List<ComParametro> Parametros();

        List<ComTipoOperacion> TiposOperaciones();

        List<ComTipoIdentificacion> TiposIdentificaciones();

        List<ComTarjeta> Tarjetas(int UsuarioId);

        List<ComCuenta> Cuentas(int UsuarioId);

        List<ComReintegro> ReintegrosActivos(int UsuarioId, int solicitante);

        List<ComReintegro> ReintegrosCancelados(int UsuarioId, int solicitante);

        List<ComReintegro> ReintegrosExitosos(int UsuarioId, int solicitante);

        List<ComPago> CobrosActivos(int UsuarioId, int solicitante);

        List<ComPago> CobrosCancelados(int UsuarioId, int solicitante);

        List<ComPago> CobrosExitosos(int UsuarioId, int solicitante);

        List<ComUsuarioParametro> ParametrosUsuario(int UsuarioId);

        ComUsuario InformacionPersona(string usuario);

        double SaldoMonedero(int UsuarioId);

        //Debe retornar el historial de operaciones
        List<ComOperacionTarjeta> HistorialOperacionesTarjeta(int tarjetaId);

        //Debe retornar el historial de operaciones
        List<ComOperacionCuenta> HistorialOperacionesCuenta(int CuentaId);

        List<ComOperacionMonedero> HistorialOperacionesMonedero(int UsuarioId);

        //Operaciones de acción sobre la base de datos

    }
}
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

        List<ComTarjeta> Tarjetas(int IdUsuario);

        List<ComCuenta> Cuentas(int IdUsuario);

        List<ComReintegro> ReintegrosActivos(int IdUsuario, int Solicitante);

        List<ComReintegro> ReintegrosCancelados(int IdUsuario, int Solicitante);

        List<ComReintegro> ReintegrosExitosos(int IdUsuario, int Solicitante);

        List<ComPago> CobrosActivos(int IdUsuario, int Solicitante);

        List<ComPago> CobrosCancelados(int IdUsuario, int Solicitante);

        List<ComPago> CobrosExitosos(int IdUsuario, int Solicitante);

        List<ComUsuarioParametro> ParametrosUsuario(int UsuarioId);

        ComUsuario InformacionPersona(string Usuario);

        double SaldoMonedero(int IdUsuario);

        //Debe retornar el historial de operaciones
        List<ComOperacionTarjeta> HistorialOperacionesTarjeta(int IdTarjeta);

        //Debe retornar el historial de operaciones
        List<ComOperacionCuenta> HistorialOperacionesCuenta(int IdCuenta);

        List<ComOperacionMonedero> HistorialOperacionesMonedero(int IdUsuario);

        //Operaciones de acción sobre la base de datos
        void RegistroUsuarioPersona(ComUsuario Formulario);

        void RegistroUsuarioComercio(ComUsuario Formulario);

        void RegistroCuenta(ComCuenta Formulario);

        void RegistroTarjeta(ComTarjeta Formulario);

        void EstablecerParametro(ComUsuarioParametro Formulario);

        void Cobro(int IdUsuarioCobrador, string IdUsuarioPaga, double Monto);

        void Reintegro(int IdUsuarioCobrador, string IdUsuarioPaga, string Referencia);

        void CancelarCobro(int IdCobro);

        void CancelarReintegro(int IdReintegro);

        void Pago_Tarjeta(int IdUsuarioReceptor, int IdTarjetaPago, double Monto, int IdCobro);

        void Pago_Cuenta(int IdUsuarioReceptor, int IdCuentaPago, double Monto, int IdCobro);

        void Pago_Monedero(int IdUsuarioReceptor, int IdUsuarioPago, double Monto, int IdCobro);

        void Reintegro_Tarjeta(int IdUsuarioReceptor, int IdTarjetaPago, double Monto, int IdCobro);

        void Reintegro_Cuenta(int IdUsuarioReceptor, int IdCuentaPago, double Monto, int IdCobro);

        void Reintegro_Monedero(int IdUsuarioReceptor, int IdUsuarioPago, double Monto, int IdCobro);

        void Modificación_Usuario(string Usuario, string Email, string Telefono, string Direccion, int IdUsuario);

        ComOperacionMonedero Ejecutar_Cierre(int IdUsuario);

        void EliminarCuenta(int IdCuenta);

        void EliminarTarjeta(int IdTarjeta);
    }
}
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
        /// <summary>
        /// Realiza la consulta con base de datos de los estados civiles disponibles en la lógica de negocio.
        /// </summary>
        /// <returns>
        /// Entrega la lista de los estados civiles posibles para el llenado de formulario.
        /// </returns>
        /// <exception cref="PGSQLException">Tira excepción relacionado a la base de datos.</exception>
        /// <exception cref="MoneyUcabException">Tira excepción relacionado a lógica de negocio que se esté manejando en este punto.</exception>
        /// <exception cref="Exception">Exception para controlar cualquier error inesperado y no controlado por el backend.</exception>
        List<ComEstadoCivil> EstadosCiviles();

        /// <summary>
        /// Realiza la consulta con base de datos de los tipos de tarjeta disponibles en la lógica de negocio.
        /// </summary>
        /// <returns>
        /// Entrega la lista de los tipos de tarjeta posibles para el llenado de formulario.
        /// </returns>
        /// <exception cref="PGSQLException">Tira excepción relacionado a la base de datos.</exception>
        /// <exception cref="MoneyUcabException">Tira excepción relacionado a lógica de negocio que se esté manejando en este punto.</exception>
        /// <exception cref="Exception">Exception para controlar cualquier error inesperado y no controlado por el backend.</exception>
        List<ComTipoTarjeta> TiposTarjeta();

        /// <summary>
        /// Realiza la consulta con base de datos de los bancos disponibles en la lógica de negocio.
        /// </summary>
        /// <returns>
        /// Entrega la lista de los bancos posibles para el llenado de formulario.
        /// </returns>
        /// <exception cref="PGSQLException">Tira excepción relacionado a la base de datos.</exception>
        /// <exception cref="MoneyUcabException">Tira excepción relacionado a lógica de negocio que se esté manejando en este punto.</exception>
        /// <exception cref="Exception">Exception para controlar cualquier error inesperado y no controlado por el backend.</exception>
        List<ComBanco> Bancos();

        /// <summary>
        /// Realiza la consulta con base de datos de los tipos de cuentas disponibles en la lógica de negocio.
        /// </summary>
        /// <returns>
        /// Entrega la lista de los tipos de cuentas posibles para el llenado de formulario.
        /// </returns>
        /// <exception cref="PGSQLException">Tira excepción relacionado a la base de datos.</exception>
        /// <exception cref="MoneyUcabException">Tira excepción relacionado a lógica de negocio que se esté manejando en este punto.</exception>
        /// <exception cref="Exception">Exception para controlar cualquier error inesperado y no controlado por el backend.</exception>
        List<ComTipoCuenta> TiposCuentas();

        /// <summary>
        /// Realiza la consulta con base de datos de los tipos de parametro disponibles en la lógica de negocio.
        /// </summary>
        /// <returns>
        /// Entrega la lista de los tipos de parametro posibles para el llenado de formulario.
        /// </returns>
        /// <exception cref="PGSQLException">Tira excepción relacionado a la base de datos.</exception>
        /// <exception cref="MoneyUcabException">Tira excepción relacionado a lógica de negocio que se esté manejando en este punto.</exception>
        /// <exception cref="Exception">Exception para controlar cualquier error inesperado y no controlado por el backend.</exception>
        List<ComTipoParametro> TiposParametros();

        /// <summary>
        /// Realiza la consulta con base de datos de las frecuencias disponibles en la lógica de negocio.
        /// </summary>
        /// <returns>
        /// Entrega la lista de las frecuencias posibles para el llenado de formulario.
        /// </returns>
        /// <exception cref="PGSQLException">Tira excepción relacionado a la base de datos.</exception>
        /// <exception cref="MoneyUcabException">Tira excepción relacionado a lógica de negocio que se esté manejando en este punto.</exception>
        /// <exception cref="Exception">Exception para controlar cualquier error inesperado y no controlado por el backend.</exception>
        List<ComFrecuencia> Frecuencias();

        /// <summary>
        /// Realiza la consulta con base de datos de los parametros disponibles en la lógica de negocio.
        /// </summary>
        /// <returns>
        /// Entrega la lista de los parametros posibles para el llenado de formulario.
        /// </returns>
        /// <exception cref="PGSQLException">Tira excepción relacionado a la base de datos.</exception>
        /// <exception cref="MoneyUcabException">Tira excepción relacionado a lógica de negocio que se esté manejando en este punto.</exception>
        /// <exception cref="Exception">Exception para controlar cualquier error inesperado y no controlado por el backend.</exception>
        List<ComParametro> Parametros();

        /// <summary>
        /// Realiza la consulta con base de datos de los tipos de operaciones disponibles en la lógica de negocio.
        /// </summary>
        /// <returns>
        /// Entrega la lista de los tipos de operaciones posibles para el llenado de formulario.
        /// </returns>
        /// <exception cref="PGSQLException">Tira excepción relacionado a la base de datos.</exception>
        /// <exception cref="MoneyUcabException">Tira excepción relacionado a lógica de negocio que se esté manejando en este punto.</exception>
        /// <exception cref="Exception">Exception para controlar cualquier error inesperado y no controlado por el backend.</exception>
        List<ComTipoOperacion> TiposOperaciones();

        /// <summary>
        /// Realiza la consulta con base de datos de los tipos de identificaciones disponibles en la lógica de negocio.
        /// </summary>
        /// <returns>
        /// Entrega la lista de los tipos de identificaciones posibles para el llenado de formulario.
        /// </returns>
        /// <exception cref="PGSQLException">Tira excepción relacionado a la base de datos.</exception>
        /// <exception cref="MoneyUcabException">Tira excepción relacionado a lógica de negocio que se esté manejando en este punto.</exception>
        /// <exception cref="Exception">Exception para controlar cualquier error inesperado y no controlado por el backend.</exception>
        List<ComTipoIdentificacion> TiposIdentificaciones();

        /// <summary>
        /// Realiza la consulta con base de datos de las tarjetas disponibles en la lógica de negocio de un usuario.
        /// </summary>
        /// <returns>
        /// Entrega la lista de las tarjetas que posee dicho usuario.
        /// </returns>
        /// <param name="IdUsuario">Id del usuario al que se realizará consulta.</param>
        /// <exception cref="PGSQLException">Tira excepción relacionado a la base de datos.</exception>
        /// <exception cref="MoneyUcabException">Tira excepción relacionado a lógica de negocio que se esté manejando en este punto.</exception>
        /// <exception cref="Exception">Exception para controlar cualquier error inesperado y no controlado por el backend.</exception>
        List<ComTarjeta> Tarjetas(int IdUsuario);

        /// <summary>
        /// Realiza la consulta con base de datos de las cuentas que posee dicho usuario.
        /// </summary>
        /// <returns>
        /// Entrega la lista de las cuentas que posee dicho usuario.
        /// </returns>
        /// <param name="IdUsuario">Id del usuario al que se realizará consulta.</param>
        /// <exception cref="PGSQLException">Tira excepción relacionado a la base de datos.</exception>
        /// <exception cref="MoneyUcabException">Tira excepción relacionado a lógica de negocio que se esté manejando en este punto.</exception>
        /// <exception cref="Exception">Exception para controlar cualquier error inesperado y no controlado por el backend.</exception>
        List<ComCuenta> Cuentas(int IdUsuario);

        /// <summary>
        /// Realiza la consulta con base de datos de los reintegros activos que posee dicho usuario.
        /// </summary>
        /// <returns>
        /// Entrega la lista de los reintegros activos que posee dicho usuario.
        /// </returns>
        /// <param name="IdUsuario">Id del usuario al que se realizará consulta.</param>
        /// <param name="Solicitante">Indica con "1" si es solicitante y con cualquier otro valor cuando no lo es.</param>
        /// <exception cref="PGSQLException">Tira excepción relacionado a la base de datos.</exception>
        /// <exception cref="MoneyUcabException">Tira excepción relacionado a lógica de negocio que se esté manejando en este punto.</exception>
        /// <exception cref="Exception">Exception para controlar cualquier error inesperado y no controlado por el backend.</exception>
        List<ComReintegro> ReintegrosActivos(int IdUsuario, int Solicitante);

        /// <summary>
        /// Realiza la consulta con base de datos de los reintegros cancelados que posee dicho usuario.
        /// </summary>
        /// <returns>
        /// Entrega la lista de los reintegros cancelados que posee dicho usuario.
        /// </returns>
        /// <param name="IdUsuario">Id del usuario al que se realizará consulta.</param>
        /// <param name="Solicitante">Indica con "1" si es solicitante y con cualquier otro valor cuando no lo es.</param>
        /// <exception cref="PGSQLException">Tira excepción relacionado a la base de datos.</exception>
        /// <exception cref="MoneyUcabException">Tira excepción relacionado a lógica de negocio que se esté manejando en este punto.</exception>
        /// <exception cref="Exception">Exception para controlar cualquier error inesperado y no controlado por el backend.</exception>
        List<ComReintegro> ReintegrosCancelados(int IdUsuario, int Solicitante);

        /// <summary>
        /// Realiza la consulta con base de datos de los reintegros exitosos que posee dicho usuario.
        /// </summary>
        /// <returns>
        /// Entrega la lista de los reintegros exitosos que posee dicho usuario.
        /// </returns>
        /// <param name="IdUsuario">Id del usuario al que se realizará consulta.</param>
        /// <param name="Solicitante">Indica con "1" si es solicitante y con cualquier otro valor cuando no lo es.</param>
        /// <exception cref="PGSQLException">Tira excepción relacionado a la base de datos.</exception>
        /// <exception cref="MoneyUcabException">Tira excepción relacionado a lógica de negocio que se esté manejando en este punto.</exception>
        /// <exception cref="Exception">Exception para controlar cualquier error inesperado y no controlado por el backend.</exception>
        List<ComReintegro> ReintegrosExitosos(int IdUsuario, int Solicitante);

        /// <summary>
        /// Realiza la consulta con base de datos de los cobros activos que posee dicho usuario.
        /// </summary>
        /// <returns>
        /// Entrega la lista de los cobros activos que posee dicho usuario.
        /// </returns>
        /// <param name="IdUsuario">Id del usuario al que se realizará consulta.</param>
        /// <param name="Solicitante">Indica con "1" si es solicitante y con cualquier otro valor cuando no lo es.</param>
        /// <exception cref="PGSQLException">Tira excepción relacionado a la base de datos.</exception>
        /// <exception cref="MoneyUcabException">Tira excepción relacionado a lógica de negocio que se esté manejando en este punto.</exception>
        /// <exception cref="Exception">Exception para controlar cualquier error inesperado y no controlado por el backend.</exception>
        List<ComPago> CobrosActivos(int IdUsuario, int Solicitante);

        /// <summary>
        /// Realiza la consulta con base de datos de los cobros cancelados que posee dicho usuario.
        /// </summary>
        /// <returns>
        /// Entrega la lista de los cobros cancelados que posee dicho usuario.
        /// </returns>
        /// <param name="IdUsuario">Id del usuario al que se realizará consulta.</param>
        /// <param name="Solicitante">Indica con "1" si es solicitante y con cualquier otro valor cuando no lo es.</param>
        /// <exception cref="PGSQLException">Tira excepción relacionado a la base de datos.</exception>
        /// <exception cref="MoneyUcabException">Tira excepción relacionado a lógica de negocio que se esté manejando en este punto.</exception>
        /// <exception cref="Exception">Exception para controlar cualquier error inesperado y no controlado por el backend.</exception>
        List<ComPago> CobrosCancelados(int IdUsuario, int Solicitante);

        /// <summary>
        /// Realiza la consulta con base de datos de los cobros exitosos que posee dicho usuario.
        /// </summary>
        /// <returns>
        /// Entrega la lista de los cobros exitosos que posee dicho usuario.
        /// </returns>
        /// <param name="IdUsuario">Id del usuario al que se realizará consulta.</param>
        /// <param name="Solicitante">Indica con "1" si es solicitante y con cualquier otro valor cuando no lo es.</param>
        /// <exception cref="PGSQLException">Tira excepción relacionado a la base de datos.</exception>
        /// <exception cref="MoneyUcabException">Tira excepción relacionado a lógica de negocio que se esté manejando en este punto.</exception>
        /// <exception cref="Exception">Exception para controlar cualquier error inesperado y no controlado por el backend.</exception>
        List<ComPago> CobrosExitosos(int IdUsuario, int Solicitante);

        /// <summary>
        /// Realiza la consulta con base de datos de los parametros que posee dicho usuario.
        /// </summary>
        /// <returns>
        /// Entrega la lista de los parametros que posee dicho usuario.
        /// </returns>
        /// <param name="IdUsuario">Id del usuario al que se realizará consulta.</param>
        /// <exception cref="PGSQLException">Tira excepción relacionado a la base de datos.</exception>
        /// <exception cref="MoneyUcabException">Tira excepción relacionado a lógica de negocio que se esté manejando en este punto.</exception>
        /// <exception cref="Exception">Exception para controlar cualquier error inesperado y no controlado por el backend.</exception>
        List<ComUsuarioParametro> ParametrosUsuario(int UsuarioId);


        /// <summary>
        /// Realiza la consulta con base de datos de la información que posee dicho usuario.
        /// </summary>
        /// <returns>
        /// Entrega la información que contiene dicho usuario
        /// </returns>
        /// <param name="Usuario">Nombre del usuario al que se realizará consulta.</param>
        /// <exception cref="PGSQLException">Tira excepción relacionado a la base de datos.</exception>
        /// <exception cref="MoneyUcabException">Tira excepción relacionado a lógica de negocio que se esté manejando en este punto.</exception>
        /// <exception cref="Exception">Exception para controlar cualquier error inesperado y no controlado por el backend.</exception>
        ComUsuario InformacionPersona(string Usuario);

        /// <summary>
        /// Realiza la consulta con base de datos del saldo que posee dicho usuario sobre su monedero.
        /// </summary>
        /// <returns>
        /// Entrega el saldo de monedero que contiene el usuario
        /// </returns>
        /// <param name="IdUsuario">Id del usuario al que se realizará consulta.</param>
        /// <exception cref="PGSQLException">Tira excepción relacionado a la base de datos.</exception>
        /// <exception cref="MoneyUcabException">Tira excepción relacionado a lógica de negocio que se esté manejando en este punto.</exception>
        /// <exception cref="Exception">Exception para controlar cualquier error inesperado y no controlado por el backend.</exception>
        double SaldoMonedero(int IdUsuario);

        /// <summary>
        /// Realiza la consulta con base de datos del historial de operaciones sobre el medio indicado.
        /// </summary>
        /// <returns>
        /// Entrega la información que contiene dicho medio (billetera)
        /// </returns>
        /// <param name="IdTarjeta">Id de la tarjeta a la que se consultará su historial de operaciones.</param>
        /// <exception cref="PGSQLException">Tira excepción relacionado a la base de datos.</exception>
        /// <exception cref="MoneyUcabException">Tira excepción relacionado a lógica de negocio que se esté manejando en este punto.</exception>
        /// <exception cref="Exception">Exception para controlar cualquier error inesperado y no controlado por el backend.</exception>
        List<ComOperacionTarjeta> HistorialOperacionesTarjeta(int IdTarjeta);

        /// <summary>
        /// Realiza la consulta con base de datos del historial de operaciones sobre el medio indicado.
        /// </summary>
        /// <returns>
        /// Entrega la información que contiene dicho medio (billetera)
        /// </returns>
        /// <param name="IdCuenta">Id de la cuenta a la que se consultará su historial de operaciones.</param>
        /// <exception cref="PGSQLException">Tira excepción relacionado a la base de datos.</exception>
        /// <exception cref="MoneyUcabException">Tira excepción relacionado a lógica de negocio que se esté manejando en este punto.</exception>
        /// <exception cref="Exception">Exception para controlar cualquier error inesperado y no controlado por el backend.</exception>
        List<ComOperacionCuenta> HistorialOperacionesCuenta(int IdCuenta);

        /// <summary>
        /// Realiza la consulta con base de datos del historial de operaciones sobre el medio indicado.
        /// </summary>
        /// <returns>
        /// Entrega la información que contiene dicho medio (billetera)
        /// </returns>
        /// <param name="IdUsuario">Id del usuario a la que se consultará su historial de operaciones a través de su monedero.</param>
        /// <exception cref="PGSQLException">Tira excepción relacionado a la base de datos.</exception>
        /// <exception cref="MoneyUcabException">Tira excepción relacionado a lógica de negocio que se esté manejando en este punto.</exception>
        /// <exception cref="Exception">Exception para controlar cualquier error inesperado y no controlado por el backend.</exception>
        List<ComOperacionMonedero> HistorialOperacionesMonedero(int IdUsuario);

        /// <summary>
        /// Realiza el registro de un usuario como persona dentro del modelo de negocio.
        /// </summary>
        /// <param name="Formulario">Formulario de llenado para realizar el registro.</param>
        /// <exception cref="PGSQLException">Tira excepción relacionado a la base de datos.</exception>
        /// <exception cref="MoneyUcabException">Tira excepción relacionado a lógica de negocio que se esté manejando en este punto.</exception>
        /// <exception cref="Exception">Exception para controlar cualquier error inesperado y no controlado por el backend.</exception>
        void RegistroUsuarioPersona(ComUsuario Formulario);

        /// <summary>
        /// Realiza el registro de un usuario como comercio dentro del modelo de negocio.
        /// </summary>
        /// <param name="Formulario">Formulario de llenado para realizar el registro.</param>
        /// <exception cref="PGSQLException">Tira excepción relacionado a la base de datos.</exception>
        /// <exception cref="MoneyUcabException">Tira excepción relacionado a lógica de negocio que se esté manejando en este punto.</exception>
        /// <exception cref="Exception">Exception para controlar cualquier error inesperado y no controlado por el backend.</exception>
        void RegistroUsuarioComercio(ComUsuario Formulario);

        /// <summary>
        /// Realiza el registro de una cuenta como billetera dentro del modelo de negocio.
        /// </summary>
        /// <param name="Formulario">Formulario de llenado para realizar el registro.</param>
        /// <exception cref="PGSQLException">Tira excepción relacionado a la base de datos.</exception>
        /// <exception cref="MoneyUcabException">Tira excepción relacionado a lógica de negocio que se esté manejando en este punto.</exception>
        /// <exception cref="Exception">Exception para controlar cualquier error inesperado y no controlado por el backend.</exception>
        void RegistroCuenta(ComCuenta Formulario);

        /// <summary>
        /// Realiza el registro de una tarjeta como billetera dentro del modelo de negocio.
        /// </summary>
        /// <param name="Formulario">Formulario de llenado para realizar el registro.</param>
        /// <exception cref="PGSQLException">Tira excepción relacionado a la base de datos.</exception>
        /// <exception cref="MoneyUcabException">Tira excepción relacionado a lógica de negocio que se esté manejando en este punto.</exception>
        /// <exception cref="Exception">Exception para controlar cualquier error inesperado y no controlado por el backend.</exception>
        void RegistroTarjeta(ComTarjeta Formulario);

        /// <summary>
        /// Establecer el parametro personalizado para el usuario.
        /// </summary>
        /// <param name="Formulario">Formulario de llenado para realizar el registro.</param>
        /// <exception cref="PGSQLException">Tira excepción relacionado a la base de datos.</exception>
        /// <exception cref="MoneyUcabException">Tira excepción relacionado a lógica de negocio que se esté manejando en este punto.</exception>
        /// <exception cref="Exception">Exception para controlar cualquier error inesperado y no controlado por el backend.</exception>
        void EstablecerParametro(ComUsuarioParametro Formulario);

        /// <summary>
        /// Realiza la solicitud de cobro a un usuario especificando el monto determinado.
        /// </summary>
        /// <param name="IdUsuarioCobrador">Especifica el id del usuario que cobra.</param>
        /// <param name="UsuarioPaga">Especifica el nombre del usuario que debe realiazr el pago.</param>
        /// <param name="monto">Especifica el monto por el cual se cobra al usuario.</param>
        /// <exception cref="PGSQLException">Tira excepción relacionado a la base de datos.</exception>
        /// <exception cref="MoneyUcabException">Tira excepción relacionado a lógica de negocio que se esté manejando en este punto.</exception>
        /// <exception cref="Exception">Exception para controlar cualquier error inesperado y no controlado por el backend.</exception>
        void Cobro(int IdUsuarioCobrador, string UsuarioPaga, double Monto);

        /// <summary>
        /// Realiza la solicitud de cobro a un usuario especificando el monto determinado.
        /// </summary>
        /// <param name="IdUsuarioCobrador">Especifica el id del usuario que solicita el reintegro.</param>
        /// <param name="UsuarioPaga">Especifica el nombre del usuario que debe realizar el pago del reintegro.</param>
        /// <param name="Referencia">Especifica la referencia que establece sobre qué operación se solicita reintegro.</param>
        /// <exception cref="PGSQLException">Tira excepción relacionado a la base de datos.</exception>
        /// <exception cref="MoneyUcabException">Tira excepción relacionado a lógica de negocio que se esté manejando en este punto.</exception>
        /// <exception cref="Exception">Exception para controlar cualquier error inesperado y no controlado por el backend.</exception>
        void Reintegro(int IdUsuarioCobrador, string UsuarioPaga, string Referencia);

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
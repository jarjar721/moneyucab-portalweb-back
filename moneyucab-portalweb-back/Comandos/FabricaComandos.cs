
using Microsoft.AspNetCore.Identity;
using moneyucab_portalweb_back.Comandos.ComandosService.Login.Simples;
using moneyucab_portalweb_back.Comandos.ComandosService.Login.ConsultasDAO;
using moneyucab_portalweb_back.Comandos.ComandosService.Utilidades.Email;
using moneyucab_portalweb_back.EntitiesForm;
using moneyucab_portalweb_back.Models;
using System;
using System.Security.Claims;
using System.Threading.Tasks;
using NpgsqlTypes;
using moneyucab_portalweb_back.Comandos.ComandosService.Login.LogicaDAO;

namespace moneyucab_portalweb_back.Comandos
{
    /// <summary>
    /// Class <c>FabricaComandos</c>
    /// Clase que se encarga de la fábrica de los comandos simples para la lógica del backend.
    /// </summary>
    public static class FabricaComandos
    {

        public static Comando_Verificar_Registro_Usuario Fabricar_Cmd_Verificar_Registro_Usuario(UserManager<Usuario> _userManager, RegistrationModel _registration)
        {
            return new Comando_Verificar_Registro_Usuario(_userManager, _registration);
        }

        public static Comando_Registro_Usuario Fabricar_Cmd_Registro_Usuario(UserManager<Usuario> _userManager, RegistrationModel _registration, ApplicationSettings appSettings, IEmailSender _emailSender)
        {
            return new Comando_Registro_Usuario(_userManager, _registration, appSettings, _emailSender);
        }

        public static Comando_Existencia_Usuario Fabricar_Cmd_Existencia_Usuario(UserManager<Usuario> _userManager, string userName, string email, string userId)
        {
            return new Comando_Existencia_Usuario(_userManager, userName, email, userId);
        }

        public static Comando_Inicio_Sesion Fabricar_Cmd_Inicio_Sesion(UserManager<Usuario> _userManager, LoginModel _registration, ApplicationSettings appSettings, SignInManager<Usuario> signInManager)
        {
            return new Comando_Inicio_Sesion(_userManager, _registration, appSettings, signInManager);
        }

        public static Comando_Verificar_Parametros Fabricar_Cmd_Verificar_Parametros(params string[] parametros)
        {
            return new Comando_Verificar_Parametros(parametros);
        }

        public static Comando_Confirmar_Email Fabricar_Cmd_Confirmar_Email(string userId, UserManager<Usuario> userManager, ConfirmEmailModel _userModel)
        {
            return new Comando_Confirmar_Email(userId, userManager, _userModel);
        }

        public static Comando_Olvido_Contraseña Fabricar_Cmd_Olvido_Contraseña(UserManager<Usuario> userManager, ForgotPasswordModel model, ApplicationSettings appSettings, IEmailSender emailSender)
        {
            return new Comando_Olvido_Contraseña(userManager, model, appSettings, emailSender);
        }

        public static Comando_Resetear_Password Fabricar_Cmd_Resetear_Password(UserManager<Usuario> userManager, ResetPasswordModel model)
        {
            return new Comando_Resetear_Password(userManager, model);
        }

        public static Comando_Verificar_Email_Confirmado Fabricar_Cmd_Verificar_Email_Confirmado(string User, UserManager<Usuario> _userManager)
        {
            return new Comando_Verificar_Email_Confirmado(User, _userManager);
        }

        public static Comando_Estados_Civiles Fabricar_Cmd_Estados_Civiles()
        {
            return new Comando_Estados_Civiles();
        }

        public static Comando_Tipos_Tarjetas Fabricar_Cmd_Tipos_Tarjetas()
        {
            return new Comando_Tipos_Tarjetas();
        }

        public static Comando_Bancos Fabricar_Cmd_Bancos()
        {
            return new Comando_Bancos();
        }

        public static Comando_Tipos_Cuentas Fabricar_Cmd_Tipos_Cuentas()
        {
            return new Comando_Tipos_Cuentas();
        }

        public static Comando_Tipos_Parametros Fabricar_Cmd_Tipos_Parametros()
        {
            return new Comando_Tipos_Parametros();
        }

        public static Comando_Frecuencias Fabricar_Cmd_Frecuencias()
        {
            return new Comando_Frecuencias();
        }

        public static Comando_Parametros Fabricar_Cmd_Parametros()
        {
            return new Comando_Parametros();
        }

        public static Comando_Tipos_Operaciones Fabricar_Cmd_Tipos_Operaciones()
        {
            return new Comando_Tipos_Operaciones();
        }

        public static Comando_Tipos_Identificaciones Fabricar_Cmd_Tipos_Identificaciones()
        {
            return new Comando_Tipos_Identificaciones();
        }

        public static Comando_Reintegros_Activos Fabricar_Cmd_Reintegros_Activos(int UsuarioId, int solicitante)
        {
            return new Comando_Reintegros_Activos(UsuarioId, solicitante);
        }

        public static Comando_Reintegros_Exitosos Fabricar_Cmd_Reintegros_Exitosos(int UsuarioId, int solicitante)
        {
            return new Comando_Reintegros_Exitosos(UsuarioId, solicitante);
        }

        public static Comando_Reintegros_Cancelados Fabricar_Cmd_Reintegros_Cancelados(int UsuarioId, int solicitante)
        {
            return new Comando_Reintegros_Cancelados(UsuarioId, solicitante);
        }

        public static Comando_Cobros_Activos Fabricar_Cmd_Cobros_Activos(int UsuarioId, int solicitante)
        {
            return new Comando_Cobros_Activos(UsuarioId, solicitante);
        }

        public static Comando_Cobros_Exitosos Fabricar_Cmd_Cobros_Exitosos(int UsuarioId, int solicitante)
        {
            return new Comando_Cobros_Exitosos(UsuarioId, solicitante);
        }

        public static Comando_Cobros_Cancelados Fabricar_Cmd_Cobros_Cancelados(int UsuarioId, int solicitante)
        {
            return new Comando_Cobros_Cancelados(UsuarioId, solicitante);
        }

        public static Comando_Tarjetas Fabricar_Cmd_Tarjetas(int UsuarioId)
        {
            return new Comando_Tarjetas(UsuarioId);
        }

        public static Comando_Cuentas Fabricar_Cmd_Cuentas(int UsuarioId)
        {
            return new Comando_Cuentas(UsuarioId);
        }

        public static Comando_Parametros_Usuario Fabricar_Cmd_Parametros_Usuario(int UsuarioId)
        {
            return new Comando_Parametros_Usuario(UsuarioId);
        }

        public static Comando_Verificar_Saldo Fabricar_Cmd_Verificar_Saldo(int UsuarioId)
        {
            return new Comando_Verificar_Saldo(UsuarioId);
        }

        public static Comando_Informacion_Persona Fabricar_Cmd_Informacion_Persona(string Usuario)
        {
            return new Comando_Informacion_Persona(Usuario);
        }

        public static Comando_Historial_Operaciones_Monedero Fabricar_Cmd_Hist_OpMonedero(int Usuario)
        {
            return new Comando_Historial_Operaciones_Monedero(Usuario);
        }

        public static Comando_Historial_Operaciones_Cuenta Fabricar_Cmd_Hist_OpCuenta(int Cuenta)
        {
            return new Comando_Historial_Operaciones_Cuenta(Cuenta);
        }

        public static Comando_Historial_Operaciones_Tarjeta Fabricar_Cmd_Hist_OpTarjeta(int Tarjeta)
        {
            return new Comando_Historial_Operaciones_Tarjeta(Tarjeta);
        }

        public static Comando_Registro_Usuario_DAO Fabricar_Cmd_Registro_Usuario_DAO(RegistrationModel form)
        {
            return new Comando_Registro_Usuario_DAO(form);
        }

        public static Comando_Realizar_Cobro Fabricar_Cmd_Realizar_Cobro(int UsuarioId, string email, double monto)
        {
            return new Comando_Realizar_Cobro(UsuarioId, email, monto);
        }

        public static Comando_Solicitar_Reintegro Fabricar_Cmd_Solicitar_Reintegro(int UsuarioId, string email, string referencia)
        {
            return new Comando_Solicitar_Reintegro(UsuarioId, email, referencia);
        }

        public static Comando_Cancelar_Cobro Fabricar_Cmd_Cancelar_Cobro(int UsuarioId)
        {
            return new Comando_Cancelar_Cobro(UsuarioId);
        }

        public static Comando_Cancelar_Reintegro Fabricar_Cmd_Cancelar_Reintegro(int UsuarioId)
        {
            return new Comando_Cancelar_Reintegro(UsuarioId);
        }

        public static Comando_Pago_Cuenta Fabricar_Cmd_Pago_Cuenta(int UsuarioReceptor, int idMedioPaga, double monto, int idOperacion)
        {
            return new Comando_Pago_Cuenta(UsuarioReceptor, idMedioPaga, monto, idOperacion);
        }

        public static Comando_Pago_Tarjeta Fabricar_Cmd_Pago_Tarjeta(int UsuarioReceptor, int idMedioPaga, double monto, int idOperacion)
        {
            return new Comando_Pago_Tarjeta(UsuarioReceptor, idMedioPaga, monto, idOperacion);
        }

        public static Comando_Pago_Monedero Fabricar_Cmd_Pago_Monedero(int UsuarioReceptor, int idMedioPaga, double monto, int idOperacion)
        {
            return new Comando_Pago_Monedero(UsuarioReceptor, idMedioPaga, monto, idOperacion);
        }

        public static Comando_Reintegro_Cuenta Fabricar_Cmd_Reintegro_Cuenta(int UsuarioReceptor, int idMedioPaga, double monto, int idOperacion)
        {
            return new Comando_Reintegro_Cuenta(UsuarioReceptor, idMedioPaga, monto, idOperacion);
        }

        public static Comando_Reintegro_Tarjeta Fabricar_Cmd_Reintegro_Tarjeta(int UsuarioReceptor, int idMedioPaga, double monto, int idOperacion)
        {
            return new Comando_Reintegro_Tarjeta(UsuarioReceptor, idMedioPaga, monto, idOperacion);
        }

        public static Comando_Reintegro_Monedero Fabricar_Cmd_Reintegro_Monedero(int UsuarioReceptor, int idMedioPaga, double monto, int idOperacion)
        {
            return new Comando_Reintegro_Monedero(UsuarioReceptor, idMedioPaga, monto, idOperacion);
        }

        public static Comando_Modificacion_Usuario Fabricar_Cmd_Modificar_Usuario(string usuario, string email, string telefono, string direccion, int IdUsuario)
        {
            return new Comando_Modificacion_Usuario(usuario, email, telefono, direccion, IdUsuario);
        }

        public static Comando_Ejecutar_Cierre Fabricar_Cmd_Ejecutar_Cierre(int usuarioId)
        {
            return new Comando_Ejecutar_Cierre(usuarioId);
        }

        public static Comando_Eliminar_Billetera_Cuenta Fabricar_Cmd_Eliminar_Cuenta(int usuarioId)
        {
            return new Comando_Eliminar_Billetera_Cuenta(usuarioId);
        }

        public static Comando_Eliminar_Billetera_Tarjeta Fabricar_Cmd_Eliminar_Tarjeta(int usuarioId)
        {
            return new Comando_Eliminar_Billetera_Tarjeta(usuarioId);
        }

        public static Comando_Registrar_Billetera_Tarjeta Fabricar_Cmd_Registrar_Tarjeta(int idUsuario, int idTipoTarjeta, int idBanco, int numero, NpgsqlDate fecha_vencimiento, int cvc, int estatus)
        {
            return new Comando_Registrar_Billetera_Tarjeta(idUsuario, idTipoTarjeta, idBanco, numero, fecha_vencimiento, cvc, estatus);
        }

        public static Comando_Registrar_Billetera_Cuenta Fabricar_Cmd_Registrar_Cuenta(int idUsuario, int idTipoCuenta, int idBanco, string numero)
        {
            return new Comando_Registrar_Billetera_Cuenta(idUsuario, idTipoCuenta, idBanco, numero);
        }

        public static Comando_Establecer_Parametro Fabricar_Cmd_Establecer_Parametro(int idUsuario, int idParametro, string validacion, int estatus)
        {
            return new Comando_Establecer_Parametro(idUsuario, idParametro, validacion, estatus);
        }
    }
}

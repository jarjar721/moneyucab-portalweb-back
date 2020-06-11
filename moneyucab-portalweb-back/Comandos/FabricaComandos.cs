
using Microsoft.AspNetCore.Identity;
using moneyucab_portalweb_back.Comandos.ComandosService.Login.Simples;
using moneyucab_portalweb_back.Comandos.ComandosService.Utilidades.Email;
using moneyucab_portalweb_back.Entities;
using moneyucab_portalweb_back.Models;
using moneyucab_portalweb_back.Models.FormModels;

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

        public static Comando_Inicio_Sesion Fabricar_Cmd_Inicio_Sesion(UserManager<Usuario> _userManager, LoginModel _registration, ApplicationSettings appSettings)
        {
            return new Comando_Inicio_Sesion(_userManager, _registration, appSettings);
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
    }
}

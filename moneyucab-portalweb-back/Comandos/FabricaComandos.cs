
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

        public static Comando_Existencia_Usuario Fabricar_Cmd_Existencia_Usuario(UserManager<Usuario> _userManager, string userName, string email)
        {
            return new Comando_Existencia_Usuario(_userManager, userName, email);
        }

        public static Comando_Inicio_Sesion Fabricar_Cmd_Inicio_Sesion(UserManager<Usuario> _userManager, LoginModel _registration, ApplicationSettings appSettings)
        {
            return new Comando_Inicio_Sesion(_userManager, _registration, appSettings);
        }

        public static Comando_Verificar_Parametros Fabricar_Cmd_Verificar_Parametros(ConfirmEmailModel _userModel)
        {
            return new Comando_Verificar_Parametros(_userModel);
        }
    }
}

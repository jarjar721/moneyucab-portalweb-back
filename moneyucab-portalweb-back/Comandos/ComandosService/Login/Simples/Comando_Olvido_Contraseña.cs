using Comandos;
using Microsoft.AspNetCore.Identity;
using moneyucab_portalweb_back.Comandos.ComandosService.Utilidades.Email;
using moneyucab_portalweb_back.EntitiesForm;
using moneyucab_portalweb_back.Models;
using System;
using System.Threading.Tasks;

namespace moneyucab_portalweb_back.Comandos.ComandosService.Login.Simples
{
    public class Comando_Olvido_Contraseña : Comando<Boolean>
    {

        private UserManager<Usuario> _userManager;
        private ForgotPasswordModel model;
        private readonly ApplicationSettings _appSettings;
        private readonly string clientBaseURI = "http://localhost:4200/#/";
        private IEmailSender _emailSender;

        public Comando_Olvido_Contraseña(UserManager<Usuario> userManager, ForgotPasswordModel model, ApplicationSettings appSettings, IEmailSender emailSender)
        {
            this._appSettings = appSettings;
            this._userManager = userManager;
            this.model = model;
        }

        async public Task<Boolean> Ejecutar()
        {
            var usuario = await _userManager.FindByEmailAsync(model.Email);
            // Se genera el codigo para confirmar el email del usuario recien creado
            var code = await _userManager.GeneratePasswordResetTokenAsync(usuario);
            // Se codifica el token para poder enviarlo por parametro
            var encodedToken = code.Replace("/", "_").Replace("+", "-").Replace("=", ".");
            // Busco el ID del template que será usado en el correo a enviar.
            var templateID = _appSettings.ConfirmAccountTemplateID;
            // Se crea el link que será anexado al template del correo
            var callbackURL = clientBaseURI + "pw-reset/" + usuario.Id + "/" + encodedToken;

            // Se crea el mensaje con sus detalles para el envío
            var emailDetails = new SendEmailDetails
            {
                FromName = "MoneyUCAB",
                FromEmail = "moneyucab@gmail.com",
                ToName = usuario.UserName,
                ToEmail = usuario.Email,
                Subject = "MoneyUCAB - Restablece tu contraseña",
                TemplateID = templateID,
                TemplateData = new EmailData
                {
                    Name = usuario.UserName,
                    URL = callbackURL,
                    Message = "¿Has olvidado tu contraseña? ¡No te preocupes! " +
                              "Te enviamos este mensaje para que puedas restablecerla. " +
                              "Solo debes hacer click en el botón.",
                    ButtonTitle = "Restablecer contraseña"
                }
            };

            // Se envía el mensaje al correo del usuario registrado
            await _emailSender.SendEmailAsync(emailDetails);
            return true;
        }

    }
}

using Comandos;
using Excepciones.Excepciones_Especificas;
using Microsoft.AspNetCore.Identity;
using moneyucab_portalweb_back.Entities;
using moneyucab_portalweb_back.Models.FormModels;
using System;
using System.Threading.Tasks;

namespace moneyucab_portalweb_back.Comandos.ComandosService.Login.Simples
{
    public class Comando_Confirmar_Email : Comando<Boolean>
    {
        private string UserId;
        private UserManager<Usuario> _userManager;
        private ConfirmEmailModel model;

        public Comando_Confirmar_Email(string UserId, UserManager<Usuario> userManager, ConfirmEmailModel model)
        {
            this.UserId = UserId;
            this._userManager = userManager;
            this.model = model;
        }

        async public Task<Boolean> Ejecutar()
        {
            var usuario = await _userManager.FindByIdAsync(UserId);
            if (usuario.EmailConfirmed) //Si ya es un usuario con email confirmado
            {
                //Código 1 para error de usuario con email confirmado
                EmailConfirmadoException.EmailConfirmado();
            }

            // Decodificando el token
            var decodedToken = model.ConfirmationToken.Replace("_", "/").Replace("-", "+").Replace(".", "=");

            // Cambia en la BD el "ConfirmEmail" a TRUE
            var result = await _userManager.ConfirmEmailAsync(usuario, decodedToken);

            if (result.Succeeded)
            {
                return true;
            }
            else
            {
                EmailConfirmadoException.EmailFalloEnvioConfirmacion();
            }
            return false;
        }
    }
}

using Comandos;
using Microsoft.AspNetCore.Identity;
using moneyucab_portalweb_back.Entities;
using moneyucab_portalweb_back.Models.FormModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace moneyucab_portalweb_back.Comandos.ComandosService.Login.Simples
{
    public class Comando_Resetear_Password : Comando<Boolean>
    {
        private ResetPasswordModel model;
        private UserManager<Usuario> _userManager;

        public Comando_Resetear_Password(UserManager<Usuario> userManager, ResetPasswordModel model)
        {
            this._userManager = userManager;
            this.model = model;
        }

        async public Task<Boolean> Ejecutar()
        {
            // Decodificando el token
            var decodedToken = model.ResetPasswordToken.Replace("_", "/").Replace("-", "+").Replace(".", "=");

            var usuario = await _userManager.FindByIdAsync(model.UserID);
            // Cambia la contraseña del usuario
            var result = await _userManager.ResetPasswordAsync(usuario, decodedToken, model.NewPassword);

            if (result.Succeeded)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}

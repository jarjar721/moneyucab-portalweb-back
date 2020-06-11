using Comandos;
using Microsoft.AspNetCore.Identity;
using moneyucab_portalweb_back.Entities;
using moneyucab_portalweb_back.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace moneyucab_portalweb_back.Comandos.ComandosService.Login.Simples
{
    public class Comando_Existencia_Usuario : Comando<Boolean>
    {

        private UserManager<Usuario> _userManager;
        private string UserName;
        private string Email;

        public Comando_Existencia_Usuario(UserManager<Usuario> userManager, string userName, string email)
        {
            this._userManager = userManager;
            this.UserName = userName;
            this.Email = email;
        }

        async public Task<Boolean> Ejecutar()
        {
            //Este comando debe retornar una excepción sino consigue  el usuario o email
            // Chequeo que el username no este registrado
            if (await _userManager.FindByNameAsync(UserName) != null)
            {
                return true;
            }
            // Chequeo que el email no este registrado
            if (await _userManager.FindByEmailAsync(Email) != null)
            {
                return true;
            }
            return false;
        }

    }
}

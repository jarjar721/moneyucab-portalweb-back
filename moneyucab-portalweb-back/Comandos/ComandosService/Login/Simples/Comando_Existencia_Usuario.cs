using Comandos;
using Excepciones.Excepciones_Especificas;
using Microsoft.AspNetCore.Identity;
using moneyucab_portalweb_back.Entities;
using System;
using System.Threading.Tasks;

namespace moneyucab_portalweb_back.Comandos.ComandosService.Login.Simples
{
    public class Comando_Existencia_Usuario : Comando<Boolean>
    {

        private UserManager<Usuario> _userManager;
        private string UserName;
        private string Email;
        private string UserId;

        public Comando_Existencia_Usuario(UserManager<Usuario> userManager, string userName, string email, string UserId)
        {
            this._userManager = userManager;
            this.UserName = userName;
            this.Email = email;
            this.UserId = UserId;
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
            if (await _userManager.FindByIdAsync(UserId) != null)
            {
                return true;
            }
            //Se realiza el throw acá
            UsuarioExistenteException.UsuarioNoExistente();
            return false;
        }

    }
}

using Comandos;
using Excepciones.Excepciones_Especificas;
using Microsoft.AspNetCore.Identity;
using moneyucab_portalweb_back.Entities;
using System;
using System.Threading.Tasks;

namespace moneyucab_portalweb_back.Comandos.ComandosService.Login.Simples
{
    public class Comando_Verificar_Email_Confirmado : Comando<Boolean>
    {
        private Object user;
        private UserManager<Usuario> _userManager;

        public Comando_Verificar_Email_Confirmado(Object User, UserManager<Usuario> _userManager)
        {
            this.user = user;
            this._userManager = _userManager;

        }

        async public Task<Boolean> Ejecutar()
        {
            // Check if email has been confirmed
            if (await _userManager.IsEmailConfirmedAsync((Usuario)user))
            {
                return true;
            }
            EmailConfirmadoException.EmailNoConfirmado();
            return false;
        }


    }
}

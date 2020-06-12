using Comandos;
using Excepciones.Excepciones_Especificas;
using Microsoft.AspNetCore.Identity;
using moneyucab_portalweb_back.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace moneyucab_portalweb_back.Comandos.ComandosService.Login.Simples
{
    public class Comando_Verificar_Autenticacion: Comando<Object>
    {
        private ClaimsPrincipal User;
        private UserManager<Usuario> _userManager;

        public Comando_Verificar_Autenticacion(ClaimsPrincipal User, UserManager<Usuario> _userManager)
        {
            this.User = User;
            this._userManager = _userManager;
        }

        async public Task<Object> Ejecutar()
        {
            if (!User.Identity.IsAuthenticated)
            {
                AutenticacionException.UsuarioNoAutenticado();
            }
            string userId = User.Claims.First(c => c.Type == "UserID").Value;
            var user = await _userManager.FindByIdAsync(userId);
            return user;
        }


    }
}

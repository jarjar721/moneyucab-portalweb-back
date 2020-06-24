using Comandos;
using Excepciones.Excepciones_Especificas;
using Microsoft.AspNetCore.Identity;
using Microsoft.IdentityModel.Tokens;
using moneyucab_portalweb_back.EntitiesForm;
using System;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace moneyucab_portalweb_back.Comandos.ComandosService.Login.Simples
{
    public class Comando_Verificar_Autenticacion : Comando<Object>
    {
        //private FormP formulario;
        private UserManager<Usuario> _userManager;

        public Comando_Verificar_Autenticacion()
        {
            throw new NotImplementedException();
        }

        async public Task<Boolean> Ejecutar()
        {
            throw new NotImplementedException();
        }


    }
}

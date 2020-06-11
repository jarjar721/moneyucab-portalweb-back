using Comandos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using moneyucab_portalweb_back.Models;
using moneyucab_portalweb_back.Entities;

namespace Lógica.Comandos.ComandosService.Login.Simples
{
    class Comando_Verificar_Registro_Usuario : IComando<Boolean>
    {

        public Comando_Verificar_Registro_Usuario()
        {

        }


        public async Task<bool> EjecutarAsync()
        {
            var usuario = new Usuario()
            {
                UserName = userModel.UserName,
                Email = userModel.Email,
                SignupDate = DateTime.Now
            };

            // Chequeo que el username no este registrado
            if (await _userManager.FindByNameAsync(usuario.UserName) != null)
            {
                return BadRequest(new { key = "DuplicateUserName", message = "Intente ingresar un username distinto" });
            }
            // Chequeo que el email no este registrado
            if (await _userManager.FindByEmailAsync(usuario.Email) != null)
            {
                return BadRequest(new { key = "DuplicateEmail", message = "Intente ingresar un correo electrónico distinto" });
            }
        }
    }
}

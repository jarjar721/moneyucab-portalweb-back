using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Excepciones;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using moneyucab_portalweb_back.Comandos;
using moneyucab_portalweb_back.Entities;

namespace moneyucab_portalweb_back.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DashboardController : ControllerBase
    {
        private UserManager<Usuario> _userManager;

        public DashboardController(UserManager<Usuario> userManager)
        {
            _userManager = userManager;
        }

        [HttpGet]
        [Authorize]
        //GET: /api/Dashbard
        public async Task<Object> GetDashboard() 
        {
            try
            {
                var user = (Usuario) await FabricaComandos.Fabrica_Cmd_Verificar_Autenticacion(_userManager, User).Ejecutar();

                var emailConfirmed = await FabricaComandos.Fabrica_Cmd_Verificar_Email_Confirmado(user, _userManager).Ejecutar();

                return new
                {
                    user.UserName,
                    emailConfirmed
                    //aqui se agregan ls campos que quieres devolver al front
                };
            }
            catch(MoneyUcabException ex)
            {
                return BadRequest(ex.response());
            }
        }

    }
}
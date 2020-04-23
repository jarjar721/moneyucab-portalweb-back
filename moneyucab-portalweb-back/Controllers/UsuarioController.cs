using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using moneyucab_portalweb_back.Models;
using moneyucab_portalweb_back.Models.Entities;

namespace moneyucab_portalweb_back.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsuarioController : ControllerBase
    {
        private UserManager<Usuario> _userManager;
        private SignInManager<Usuario> _signInManager;

        public UsuarioController(UserManager<Usuario> userManager, SignInManager<Usuario> signInManager)
        {
            _userManager = userManager;
            _signInManager = signInManager;
        }

        [HttpPost]
        [Route("Register")]
        //Post : /api/Usuario/Register
        public async Task<Object> PostUsuario(WebAppUserModel userModel)
        {
            var usuario = new Usuario()
            {
                UserName = userModel.UserName,
                Email = userModel.Email,
                SignupDate = DateTime.Now
            };

            try
            {
                var result = await _userManager.CreateAsync(usuario, userModel.Password);
                return Ok(result);
            }
            catch (Exception ex)
            {

                throw ex;
            }

        }

    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using moneyucab_portalweb_back.Models.Entities;

namespace moneyucab_portalweb_back.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PerfilController : ControllerBase
    {

        private UserManager<Usuario> _userManager;

        public PerfilController(UserManager<Usuario> userManager)
        {
            _userManager = userManager;
        }

        [HttpGet]
        [Route("Profile")]
        //Get: /api/Usuario/Profile
        public async Task<Object> GetPersonalDetails()
        {
            string userId = User.Claims.First(c => c.Type == "UserID").Value;
            var user = await _userManager.FindByIdAsync(userId);

            return new { };
        }
    }
}
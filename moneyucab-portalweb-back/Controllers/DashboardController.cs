﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using moneyucab_portalweb_back.Models.Entities;

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
            string userId = User.Claims.First(c => c.Type == "UserID").Value;
            var user = await _userManager.FindByIdAsync(userId);

            return new
            {
                user.UserName
                //aqui se agregan ls campos que quieres devolver al front
            };

        }

    }
}
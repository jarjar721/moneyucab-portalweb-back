using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace moneyucab_portalweb_back.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DashboardController : ControllerBase
    {
        [HttpGet]
        [Authorize]
        //GET: /api/Dashbard
        public async Task<Object> GetDashboard() 
        {
            string userId = User.Claims.First(c => c.Type == "UserID").Value;
        }

    }
}
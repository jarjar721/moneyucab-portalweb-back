using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace moneyucab_portalweb_back.Models
{
    public class LoginModel
    {
        //public string UserName { get; set; } En caso de que se quiera hacer login con username
        public string Email { get; set; }
        public string Password { get; set; }
    }
}

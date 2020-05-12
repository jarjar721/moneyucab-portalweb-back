using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace moneyucab_portalweb_back.Models.FormModels
{
    public class ResetPasswordModel
    {
        [Required]
        public string UserID { get; set; }
        [Required]
        public string ResetPasswordToken { get; set; }
        [Required]
        public string NewPassword { get; set; }
    }
}

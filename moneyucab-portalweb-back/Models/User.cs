using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace moneyucab_portalweb_back.Models
{
    public class User
    {
        [Key]
        public int id { get; set; }

        [Required]
        public string username { get; set; }

        [Required] 
        public string email { get; set; }

        [Required]
        public string password { get; set; }
    }
}

using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

using Microsoft.AspNetCore.Identity;

namespace moneyucab_portalweb_back.Models.Entities
{
    public class Usuario : IdentityUser
    {
        [Required]
        [Column(TypeName = "DATE")]
        public DateTime SignupDate { get; set; }

        public UsuarioIntermedio UsuarioIntermedio { get; set; }
    }
}

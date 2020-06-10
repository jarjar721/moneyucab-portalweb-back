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
<<<<<<< HEAD
=======
        public Usuario() : base()
        {
            PreviousUserPasswords = new List<PreviousPasswords>();
        }

        [Column(TypeName="date")]
>>>>>>> development
        [Required]
        [Column(TypeName = "DATE")]
        public DateTime SignupDate { get; set; }

<<<<<<< HEAD
        public UsuarioIntermedio UsuarioIntermedio { get; set; }
=======
        public virtual IList<PreviousPasswords> PreviousUserPasswords { get; set; }
>>>>>>> development
    }
}

﻿using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace moneyucab_portalweb_back.Entities
{
    public class Usuario : IdentityUser
    {
        public Usuario() : base()
        {
            PreviousUserPasswords = new List<PreviousPasswords>();
        }

        [Column(TypeName = "date")]
        [Required]
        public DateTime SignupDate { get; set; }

        public virtual IList<PreviousPasswords> PreviousUserPasswords { get; set; }
    }
}

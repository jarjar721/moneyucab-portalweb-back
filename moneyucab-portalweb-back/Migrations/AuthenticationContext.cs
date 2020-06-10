﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;


using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using moneyucab_portalweb_back.Models.Entities;

namespace moneyucab_portalweb_back.Migrations
{
    public class AuthenticationContext : IdentityDbContext<Usuario>
    {
        public AuthenticationContext(DbContextOptions options) : base(options)
        {
        }

        public DbSet<Usuario> Usuarios { get; set; }
    }
}
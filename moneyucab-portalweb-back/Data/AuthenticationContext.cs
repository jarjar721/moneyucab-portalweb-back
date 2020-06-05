using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using moneyucab_portalweb_back.Models.Entities;

namespace moneyucab_portalweb_back.Data
{
    public class AuthenticationContext : IdentityDbContext<Usuario>
    {
        public AuthenticationContext(DbContextOptions options) : base(options)
        {
        }

        public DbSet<Usuario> Usuarios { get; set; }


        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            builder.Entity<Persona>()
                .HasOne(p => p.UsuarioIntermedio)
                .WithOne(b => b.Persona)
                .HasForeignKey<Persona>(p => p.UsuarioID)
                .HasConstraintName("FK_Persona_Usuario");

            builder.Entity<Persona>()
                .HasOne<EstadoCivil>()
                .WithMany()
                .HasForeignKey(p => p.EstadoCivilID)
                .HasConstraintName("FK_Persona_EstadoCivil");

            builder.Entity<Comercio>()
                .HasOne(p => p.UsuarioIntermedio)
                .WithOne(b => b.Comercio)
                .HasForeignKey<Comercio>(p => p.UsuarioID)
                .HasConstraintName("FK_Comercio_Usuario");

            builder.Entity<UsuarioIntermedio>()
                .HasOne(p => p.Usuario)
                .WithOne(b => b.UsuarioIntermedio)
                .HasForeignKey<UsuarioIntermedio>(p => p.EntityID)
                .HasConstraintName("FK_Usuario_Entity");
        }
    }
}

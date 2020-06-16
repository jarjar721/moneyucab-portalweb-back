using Microsoft.EntityFrameworkCore;
using moneyucab_portalweb_back.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace moneyucab_portalweb_back.Contextos
{
	public class DatosUsuarioDBContext : DbContext
	{
		public DatosUsuarioDBContext(DbContextOptions<DatosUsuarioDBContext> opciones) :base(opciones)
		{

		}

		public DbSet<DatosUsuario> DatosUsuario { get; set; }

		protected override void OnModelCreating(ModelBuilder modeloCreador)
		{
			new DatosUsuario.Mapeo(modeloCreador.Entity<DatosUsuario>());
		}
	}
}

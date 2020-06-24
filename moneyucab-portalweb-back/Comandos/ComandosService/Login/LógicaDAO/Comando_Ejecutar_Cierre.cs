using Comunes.Comun;
using DAO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace moneyucab_portalweb_back.Comandos.ComandosService.Login.Simples
{
	public class Comando_Ejecutar_Cierre
	{
		public int IdUsuario { get; set; }

		public Comando_Ejecutar_Cierre(int _IdUsuario)
		{
			IdUsuario = _IdUsuario;
		}

		async public Task<ComOperacionMonedero> Ejecutar()
		{
			DAOBase dao = new DAOBase();
			return dao.Ejecutar_Cierre(IdUsuario);
		}
	}
}

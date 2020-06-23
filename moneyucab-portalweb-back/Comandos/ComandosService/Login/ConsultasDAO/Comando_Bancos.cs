using Comunes.Comun;
using DAO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace moneyucab_portalweb_back.Comandos.ComandosService.Login.ConsultasDAO
{
	public class Comando_Bancos
	{

		public Comando_Bancos()
		{

		}
		async public Task<List<ComBanco>> Ejecutar()
		{
			DAOBase dao = FabricaDAO.crearDaoBase();
			return dao.Bancos();
		}
		
		
	}
}

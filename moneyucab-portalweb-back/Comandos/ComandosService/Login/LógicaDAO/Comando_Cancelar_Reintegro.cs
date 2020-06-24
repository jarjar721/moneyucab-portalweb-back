using DAO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace moneyucab_portalweb_back.Comandos.ComandosService.Login.Simples
{
	public class Comando_Cancelar_Reintegro
	{
		public int idReintegro { get; set; }


		public Comando_Cancelar_Reintegro(int _idReintegro)
		{
			idReintegro = _idReintegro;
		}

		async public Task<Boolean> Ejecutar()
		{
			DAOBase dao = new DAOBase();
			dao.CancelarReintegro(idReintegro);
			return true;
		}
	}
}

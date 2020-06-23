using DAO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace moneyucab_portalweb_back.Comandos.ComandosService.Login.Simples
{
	public class Comando_Cancelar_Cobro
	{
		public int idCobro { get; set; }


		public Comando_Cancelar_Cobro(int _idCobro)
		{
			idCobro = _idCobro;
		}

		async public Task<Boolean> Ejecutar()
		{
			DAOBase dao = new DAOBase();
			dao.CancelarCobro(idCobro);
			return true;
		}
	}
}

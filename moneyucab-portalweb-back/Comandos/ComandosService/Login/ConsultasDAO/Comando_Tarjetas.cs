using Comunes.Comun;
using DAO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace moneyucab_portalweb_back.Comandos.ComandosService.Login.ConsultasDAO
{
	public class Comando_Tarjetas
	{
		private int _UsuarioId;

		public Comando_Tarjetas()
		{

		}

		public Comando_Tarjetas(int UsuarioId)
		{
			this._UsuarioId = UsuarioId;
		}

		async public Task<List<ComTarjeta>> Ejecutar()
		{
			DAOBase dao = FabricaDAO.crearDaoBase();
			return dao.Tarjetas(this._UsuarioId);
		}
		
		
	}
}

using Comunes.Comun;
using DAO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace moneyucab_portalweb_back.Comandos.ComandosService.Login.ConsultasDAO
{
	public class Comando_Historial_Operaciones_Monedero
	{
		private int _UsuarioId;

		public Comando_Historial_Operaciones_Monedero()
		{

		}

		public Comando_Historial_Operaciones_Monedero(int UsuarioId)
		{
			this._UsuarioId = UsuarioId;
		}

		async public Task<List<ComOperacionMonedero>> Ejecutar()
		{
			DAOBase dao = FabricaDAO.crearDaoBase();
			return dao.HistorialOperacionesMonedero(this._UsuarioId);
		}
		
		
	}
}

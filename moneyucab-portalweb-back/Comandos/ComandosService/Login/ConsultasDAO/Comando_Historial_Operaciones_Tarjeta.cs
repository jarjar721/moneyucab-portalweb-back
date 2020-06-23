using Comunes.Comun;
using DAO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace moneyucab_portalweb_back.Comandos.ComandosService.Login.ConsultasDAO
{
	public class Comando_Historial_Operaciones_Tarjeta
	{
		private int _TarjetaId;

		public Comando_Historial_Operaciones_Tarjeta()
		{

		}

		public Comando_Historial_Operaciones_Tarjeta(int TarjetaId)
		{
			this._TarjetaId = TarjetaId;
		}

		async public Task<List<ComOperacionCuenta>> Ejecutar()
		{
			DAOBase dao = FabricaDAO.crearDaoBase();
			return dao.HistorialOperacionesCuenta(this._TarjetaId);
		}
		
		
	}
}

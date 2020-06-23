using Comunes.Comun;
using DAO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace moneyucab_portalweb_back.Comandos.ComandosService.Login.ConsultasDAO
{
	public class Comando_Historial_Operaciones_Cuenta
	{
		private int _CuentaId;

		public Comando_Historial_Operaciones_Cuenta()
		{

		}

		public Comando_Historial_Operaciones_Cuenta(int CuentaId)
		{
			this._CuentaId = CuentaId;
		}

		async public Task<List<ComOperacionCuenta>> Ejecutar()
		{
			DAOBase dao = FabricaDAO.crearDaoBase();
			return dao.HistorialOperacionesCuenta(this._CuentaId);
		}
		
		
	}
}

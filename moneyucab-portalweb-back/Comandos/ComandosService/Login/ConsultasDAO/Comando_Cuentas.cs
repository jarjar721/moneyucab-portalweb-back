using Comunes.Comun;
using DAO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace moneyucab_portalweb_back.Comandos.ComandosService.Login.ConsultasDAO
{
	public class Comando_Cuentas
	{
		private int _idUsuario;

		public Comando_Cuentas()
		{

		}

		public Comando_Cuentas(int IdUsuario)
		{
			this._idUsuario = IdUsuario;
		}

		async public Task<List<ComCuenta>> Ejecutar()
		{
			DAOBase dao = FabricaDAO.CrearDaoBase();
			return dao.Cuentas(this._idUsuario);
		}
		
		
	}
}

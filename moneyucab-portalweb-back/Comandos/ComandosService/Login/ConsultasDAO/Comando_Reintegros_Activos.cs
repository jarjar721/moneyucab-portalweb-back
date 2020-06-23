using Comunes.Comun;
using DAO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace moneyucab_portalweb_back.Comandos.ComandosService.Login.ConsultasDAO
{
	public class Comando_Reintegros_Activos
	{
		private int UsuarioId;
		private int solicitante;
		public Comando_Reintegros_Activos(int UsuarioId, int solicitante)
		{
			this.UsuarioId = UsuarioId;
			this.solicitante = solicitante;
		}
		async public Task<List<ComReintegro>> Ejecutar()
		{
			DAOBase dao = FabricaDAO.crearDaoBase();
			return dao.ReintegrosActivos(this.UsuarioId, this.solicitante);
		}
		
		
	}
}

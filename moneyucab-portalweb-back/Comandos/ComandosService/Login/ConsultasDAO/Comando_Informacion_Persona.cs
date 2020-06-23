using Comunes.Comun;
using DAO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace moneyucab_portalweb_back.Comandos.ComandosService.Login.ConsultasDAO
{
	public class Comando_Informacion_Persona
	{
		private string _Usuario;

		public Comando_Informacion_Persona()
		{

		}

		public Comando_Informacion_Persona(string Usuario)
		{
			this._Usuario = Usuario;
		}

		async public Task<ComUsuario> Ejecutar()
		{
			DAOBase dao = FabricaDAO.crearDaoBase();
			return dao.InformacionPersona(this._Usuario);
		}
		
		
	}
}

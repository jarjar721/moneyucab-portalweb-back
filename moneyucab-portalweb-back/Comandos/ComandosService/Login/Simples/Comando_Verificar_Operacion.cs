using Comunes.Comun;
using DAO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace moneyucab_portalweb_back.Comandos.ComandosService.Login.Simples
{
	public class Comando_Verificar_Operacion
	{
		public List<ComOperacionMonedero> operaciones = new List<ComOperacionMonedero>();
		public int idUsuarioReceptor;

		public Comando_Verificar_Operacion(int _idUsuario)
		{
			idUsuarioReceptor = _idUsuario;
			operaciones = new List<ComOperacionMonedero>();
		}
		async public Task<Boolean> Ejecutar()
		{
			DAOBase dao = new DAOBase();

			operaciones = dao.HistorialOperacionesMonedero(idUsuarioReceptor);

			return true;
		}
	}
}

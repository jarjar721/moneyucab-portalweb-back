using DAO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace moneyucab_portalweb_back.Comandos.ComandosService.Login.Simples
{
	public class Comando_Eliminar_Billetera_Cuenta

	{
		public int idUsuario { get; set; }

		public Comando_Eliminar_Billetera_Cuenta(int _idUsuario)
		{
			this.idUsuario = _idUsuario;
		}

		async public Task<Boolean> Ejecutar()
		{
			DAOBase dao = new DAOBase();
			dao.Ejecutar_Cierre(idUsuario);

			return true;
		}
	}
}

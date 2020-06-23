using DAO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace moneyucab_portalweb_back.Comandos.ComandosService.Login.Simples
{
	public class Comando_Realizar_Cobro
	{
		public int idUsuarioSolicitante { get; set; }
		public String emailPagador { get; set; }
		public int monto { get; set; }

		public Boolean cobroRealizado = false;

		public Comando_Realizar_Cobro(int _idUsuarioSolicitante,String _emailPagador,int _monto)
		{
			idUsuarioSolicitante = _idUsuarioSolicitante;
			emailPagador = _emailPagador;
			monto = _monto;
		}

		async public Task<Boolean> Ejecutar()
		{
			DAOBase dao = new DAOBase();
			dao.Cobro(idUsuarioSolicitante, emailPagador, monto);
			cobroRealizado = true;
			return true;
		}
	}
}

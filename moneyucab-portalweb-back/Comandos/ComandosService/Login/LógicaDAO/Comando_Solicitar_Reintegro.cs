using DAO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace moneyucab_portalweb_back.Comandos.ComandosService.Login.Simples
{
	public class Comando_Solicitar_Reintegro
	{
		public int idUsuarioSolicitante { get; set; }
		public String emailPagador { get; set; }
		public string referencia { get; set; }

		public Boolean cobroRealizado = false;

		public Comando_Solicitar_Reintegro(int _idUsuarioSolicitante,String _emailPagador,string _referencia)
		{
			idUsuarioSolicitante = _idUsuarioSolicitante;
			emailPagador = _emailPagador;
			referencia = _referencia;
		}

		async public Task<Boolean> Ejecutar()
		{
			DAOBase dao = new DAOBase();
			dao.Reintegro(idUsuarioSolicitante, emailPagador, referencia);
			return true;
		}
	}
}

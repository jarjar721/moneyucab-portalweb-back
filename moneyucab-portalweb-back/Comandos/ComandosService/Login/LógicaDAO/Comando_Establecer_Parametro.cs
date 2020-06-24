using Comunes.Comun;
using DAO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace moneyucab_portalweb_back.Comandos.ComandosService.Login.Simples
{
	public class Comando_Establecer_Parametro
	{
		public int _idUsuario { get; set; }
		public int _idParametro { get; set; }
		public string _validacion { get; set; }
		public int _estatus { get; set; }


		public Comando_Establecer_Parametro(int idUsuario, int idParametro, string validacion, int estatus)
		{
			this._idUsuario = idUsuario;
			this._idParametro = idParametro;
			this._validacion = validacion;
			this._estatus = estatus;
		}

		async public Task<Boolean> Ejecutar()
		{
			DAOBase dao = new DAOBase();
			dao.EstablecerParametro(new ComUsuarioParametro(this._idUsuario, this._idParametro, this._validacion, this._estatus));
			return true;
		}
	}
}

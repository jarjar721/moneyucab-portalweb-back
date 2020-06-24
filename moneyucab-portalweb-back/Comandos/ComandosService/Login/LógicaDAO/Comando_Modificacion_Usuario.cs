using DAO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace moneyucab_portalweb_back.Comandos.ComandosService.Login.Simples
{
	public class Comando_Modificacion_Usuario
	{
		private string _usuario { get; set; }
		private string _email { get; set; }
		private string _telefono { get; set; }
		private string _direccion { get; set; }
		private int _idUsuario { get; set; }

		public Comando_Modificacion_Usuario(string Usuario,string Email, string Telefono, string Direccion, int IdUsuario)
		{
			this._usuario = Usuario;
			this._email = Email;
			this._telefono = Telefono;
			this._direccion = Direccion;
			_idUsuario = IdUsuario;
		}

		async public Task<Boolean> Ejecutar()
		{
			DAOBase dao = new DAOBase();
			dao.Modificación_Usuario(_usuario, _email, _telefono, _direccion, _idUsuario);
			return true;
		}
	}
}

using DAO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace moneyucab_portalweb_back.Comandos.ComandosService.Login.Simples
{
	public class Comando_Modificacion_Usuario
	{
		public string usuario { get; set; }
		public string email { get; set; }
		public string telefono { get; set; }
		public string direccion { get; set; }
		public int IdUsuario { get; set; }

		public Comando_Modificacion_Usuario(string _usuario,string _email, string _telefono, string _direccion, int _IdUsuario)
		{
			usuario = _usuario;
			email = _email;
			telefono = _telefono;
			direccion = _direccion;
			IdUsuario = _IdUsuario;
		}

		async public Task<Boolean> Ejecutar()
		{
			DAOBase dao = new DAOBase();
			dao.Modificación_Usuario(usuario, email, telefono, direccion, IdUsuario);
			return true;
		}
	}
}

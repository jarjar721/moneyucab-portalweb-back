using Comunes.Comun;
using DAO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace moneyucab_portalweb_back.Comandos.ComandosService.Utilidades
{
	public class Comando_Registrar_Billetera_Cuenta
	{
		public int idUsuario { get; set; }
		public int idTipoCuenta { get; set; }
		public int idBanco { get; set; }
		public string numero { get; set; }

		public Comando_Registrar_Billetera_Cuenta(int _idUsuario, int _idTipoCuenta,int _idBanco, string _numero)
		{
			this.idUsuario = _idUsuario;
			this.idTipoCuenta = _idTipoCuenta;
			this.idBanco = _idBanco;
			this.numero = _numero;
		}
		async public Task<Boolean> Ejecutar()
		{
			DAOBase dao = new DAOBase();
			ComBanco comBanco = new ComBanco(idBanco);
			ComTipoCuenta comTipoCuenta = new ComTipoCuenta(idTipoCuenta);
			ComCuenta comCuenta = new ComCuenta(comTipoCuenta, comBanco, idUsuario, numero);
			dao.RegistroCuenta(comCuenta);

			return true;
		}
	}
}

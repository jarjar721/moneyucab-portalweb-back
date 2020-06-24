using Comunes.Comun;
using DAO;
using NpgsqlTypes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace moneyucab_portalweb_back.Comandos.ComandosService.Login.Simples
{
	public class Comando_Registrar_Billetera_Tarjeta
	{
		public int idUsuario { get; set; }
		public int idTipoTarjeta { get; set; }
		public int idBanco { get; set; }
		public int numero { get; set; }
		public NpgsqlDate fecha_vencimiento { get; set; }
		public int cvc { get; set; }
		public int estatus { get; set; }

		public Comando_Registrar_Billetera_Tarjeta(int _idUsuario, int _idTipoTarjeta, int _idBanco, int _numero , NpgsqlDate fecha_vencimiento, int _cvc, int _estatus)
		{
			this.idUsuario = _idUsuario;
			this.idTipoTarjeta = _idTipoTarjeta;
			this.idBanco = _idBanco;
			this.numero = _numero;
			this.fecha_vencimiento = fecha_vencimiento;
			this.cvc = _cvc;
			this.estatus = _estatus;
		}
		async public Task<Boolean> Ejecutar()
		{
			DAOBase dao = new DAOBase();
			ComTipoTarjeta comTipoTarjeta = new ComTipoTarjeta(idTipoTarjeta);
			ComBanco comBanco = new ComBanco(idBanco);
			ComTarjeta comTarjeta = new ComTarjeta(comTipoTarjeta, comBanco, idUsuario, numero, fecha_vencimiento, cvc, estatus);
			dao.RegistroTarjeta(comTarjeta);

			return true;
		}
	}
}

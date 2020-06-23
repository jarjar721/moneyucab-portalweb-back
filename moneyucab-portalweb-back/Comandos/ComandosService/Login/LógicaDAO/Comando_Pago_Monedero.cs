using DAO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace moneyucab_portalweb_back.Comandos.ComandosService.Login.Simples
{
	public class Comando_Pago_Monedero
	{
		public int idUsuarioReceptor { get; set; }
		public int idMedioPaga { get; set; }
		public double monto { get; set; }
		public int idOperacion { get; set; }

		public Boolean cobroRealizado = false;

		public Comando_Pago_Monedero(int _idUsuarioReceptor, int _idMedioPaga,double _monto, int _idOperacion)
		{
			idUsuarioReceptor = _idUsuarioReceptor;
			idMedioPaga = _idMedioPaga;
			monto = _monto;
			idOperacion = _idOperacion;
		}

		async public Task<Boolean> Ejecutar()
		{
			DAOBase dao = new DAOBase();
			dao.Pago_Monedero(idUsuarioReceptor, idMedioPaga, monto, idOperacion);
			return true;
		}
	}
}

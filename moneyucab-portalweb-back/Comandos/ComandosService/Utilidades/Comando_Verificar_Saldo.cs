using DAO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace moneyucab_portalweb_back.Comandos.ComandosService.Utilidades
{
	public class Comando_Verificar_Saldo
	{
		public double saldoActual;
		public int idUsuario;

		public Comando_Verificar_Saldo(int _idUsuario)
		{
			idUsuario = _idUsuario;
			saldoActual = 0;
		}
		async public Task<Boolean> Ejecutar()
		{
			DAOBase dao = new DAOBase();
			
			saldoActual = dao.SaldoMonedero(idUsuario);

			return true;
		}
		
		
	}
}

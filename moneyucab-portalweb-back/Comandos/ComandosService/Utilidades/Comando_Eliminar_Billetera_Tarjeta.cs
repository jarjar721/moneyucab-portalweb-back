using DAO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace moneyucab_portalweb_back.Comandos.ComandosService.Utilidades
{
	public class Comando_Eliminar_Billetera_Tarjeta
	{
		public int idUsuario { get; set; }
		public int idTipoTarjeta { get; set; }
		public int idBanco { get; set; }
		public int numero { get; set; }
		public int cvc { get; set; }
		public int estatus { get; set; }
		public Boolean eliminacionCorrecta = false;

		public Comando_Eliminar_Billetera_Tarjeta(int _idUsuario, int _idTipoTarjeta, int _idBanco, int _numero, int _cvc, int _estatus)
		{
			this.idUsuario = _idUsuario;
			this.idTipoTarjeta = _idTipoTarjeta;
			this.idBanco = _idBanco;
			this.numero = _numero;
			this.cvc = _cvc;
			this.estatus = _estatus;
			
	}

		async public Task<Boolean> Ejecutar()
		{
			DAOBase dao = new DAOBase();
			//metodo de dao base que elimina tarjeta
			//poner eliminacion correcta en true cuando se haga la eliminacion
			return true;
		}
	}
}

using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace moneyucab_portalweb_back.Entities
{
	public class Saldo
	{
		public Double saldoEnCuenta { get; set; }
		public int idUsuario { get; set; }

		public string JSONconvert()
		{
			//paso todos los datos
			Saldo saldo = new Saldo();
			saldo.saldoEnCuenta = this.saldoEnCuenta;

			//devuelvo el string
			string json = JsonConvert.SerializeObject(saldo);
			return json;
		}
	}
}

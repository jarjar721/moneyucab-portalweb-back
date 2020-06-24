using NpgsqlTypes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace moneyucab_portalweb_back.EntitiesForm
{
	public class BilleteraTarjeta
	{
		public int idUsuario { get; set; }
		public int idTipoTarjeta { get; set; }
		public int idBanco { get; set; }
		public int numero { get; set; }
		public NpgsqlDate fechaVencimiento { get; set; }
		public int cvc { get; set; }
		public int estatus { get; set; }

	}
}

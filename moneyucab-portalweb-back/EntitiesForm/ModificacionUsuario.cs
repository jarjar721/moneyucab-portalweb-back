using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace moneyucab_portalweb_back.EntitiesForm
{
	public class ModificacionUsuario
	{
		public string usuario { get; set; }
		public string email { get; set; }
		public string telefono { get; set; }
		public string direccion { get; set; } 
		public int IdUsuario { get; set; }
	}
}

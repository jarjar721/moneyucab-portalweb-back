using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace moneyucab_portalweb_back.Models.Entities
{
    public class CuentaBancaria
    {
        public int ID { get; set; }
        public string NumeroCuenta { get; set; }
        public string Status { get; set; }
        public int BancoID { get; set; }
        public int TipoCuentaID { get; set; }
        public int UsuarioID { get; set; }
    }
}

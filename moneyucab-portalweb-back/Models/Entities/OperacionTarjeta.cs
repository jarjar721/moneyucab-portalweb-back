using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace moneyucab_portalweb_back.Models.Entities
{
    public class OperacionTarjeta
    {
        public int ID { get; set; }
        public string UsuarioReceptorID { get; set; }
        public int TarjetaID { get; set; }
        public DateTime Fecha { get; set; }
        public double Monto { get; set; }
        public string Referencia { get; set; }
    }
}

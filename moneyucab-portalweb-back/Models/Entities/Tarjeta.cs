using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace moneyucab_portalweb_back.Models.Entities
{
    public class Tarjeta
    {
        public int ID { get; set; }
        public string Titular { get; set; }
        public string NumeroTarjeta { get; set; }
        public int TipoTarjetaID { get; set; }
        public DateTime FechaExpiracion { get; set; }
        public string Tecnologia { get; set; } // Si la tarjeta es Mastercard, Visa, Maestro, Diners Club, etc.
        public int CCV { get; set; }
        public string Status { get; set; }
        public int BancoID { get; set; }
        public string UsuarioID { get; set; }

    }
}

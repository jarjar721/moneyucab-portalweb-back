using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace moneyucab_portalweb_back.Models.Entities
{
    [NotMapped]
    public class OperacionMonedero
    {
        public int ID { get; set; }
        public string UsuarioID { get; set; }
        public int TipoOperacion { get; set; }
        public DateTime Fecha { get; set; }
        public double Monto { get; set; }
        public string Referencia { get; set; }
    }
}

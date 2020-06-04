using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace moneyucab_portalweb_back.Models.Entities
{
    [NotMapped]
    public class Frecuencia
    {
        public int ID { get; set; }
        public char Codigo { get; set; }
        public string Descripcion { get; set; }
        public int Status { get; set; }
    }
}

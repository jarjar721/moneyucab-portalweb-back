using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace moneyucab_portalweb_back.Models.Entities
{
    [NotMapped]
    public class Banco
    {
        public int ID { get; set; }
        public string Banesco { get; set; }
        public int Status { get; set; }

    }
}

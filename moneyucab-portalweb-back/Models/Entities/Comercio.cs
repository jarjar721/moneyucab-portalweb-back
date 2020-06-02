using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace moneyucab_portalweb_back.Models.Entities
{
    public class Comercio
    {
        public int ID { get; set; }
        public string RIF { get; set; }
        public string RazonSocial { get; set; }
        public string NombreRepresentante { get; set; }
        public string ApellidoRepresentante { get; set; }
    }
}

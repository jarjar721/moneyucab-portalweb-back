using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace moneyucab_portalweb_back.Models.Entities
{
    public class Parametro
    {
        public int ID { get; set; }
        public int FrecuenciaID { get; set; }
        public int TipoParametroID { get; set; }
        public string Nombre { get; set; }
        public int Status { get; set; }
    }
}

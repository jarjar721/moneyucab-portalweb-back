using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace moneyucab_portalweb_back.Models.Entities
{
    public class Reintegro
    {
        public int ID { get; set; }
        public string UsuarioEmisorID { get; set; }
        public string UsuarioReceptorID { get; set; }
        public DateTime FechaSolicitud { get; set; }
        public string Referencia { get; set; }
        public int Status { get; set; }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace moneyucab_portalweb_back.Models.Entities
{
    public class OpcionMenu
    {
        public int ID { get; set; }
        public int AplicacionID { get; set; }
        public string Nombre { get; set; }
        public string Descripcion { get; set; }
        public string URL { get; set; }
        public int Posicion { get; set; }
        public int Status { get; set; }
    }
}

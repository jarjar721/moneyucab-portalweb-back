using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace moneyucab_portalweb_back.Models.Entities
{
    [NotMapped]
    public class Bitacora
    {
        public int ID { get; set; }
        public int EventoID { get; set; }
        public string UsuarioID { get; set; }
        public DateTime Fecha { get; set; }
        public string Descripcion { get; set; }
        public string CausaError { get; set; }
    }
}

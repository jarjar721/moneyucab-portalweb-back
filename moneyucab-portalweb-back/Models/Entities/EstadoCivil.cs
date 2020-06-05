using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace moneyucab_portalweb_back.Models.Entities
{
    [Table("EstadoCivil")]
    public class EstadoCivil
    {
        [Column("idEstadoCivil", TypeName = "INT")]
        public int ID { get; set; }

        [Required]
        [Column("descripcion", TypeName = "VARCHAR(45)")]
        public string Descripcion { get; set; }

        [Required]
        [Column("codigo", TypeName = "CHAR(1)")]
        public char Codigo { get; set; }

        [Required]
        [Column("estatus", TypeName = "INT")]
        public int Estatus { get; set; }
    }
}

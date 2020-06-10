using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace moneyucab_portalweb_back.Models.Entities
{
    [Table("Comercio")]
    public class Comercio
    {
        [Key]
        [Column("idUsuario", TypeName = "INT")]
        public int ID { get; set; }

        [Required]
        [Column("razon_social", TypeName = "VARCHAR(45)")]
        public string RazonSocial { get; set; }

        [Required]
        [Column("nombre_representante", TypeName = "VARCHAR(45)")]
        public string NombreRepresentante { get; set; }

        [Required]
        [Column("apellido_representante", TypeName = "VARCHAR(45)")]
        public string ApellidoRepresentante { get; set; }

        [Column("idUsuario", TypeName = "INT")]
        public int UsuarioID { get; set; }


        [ForeignKey("idUsuario")]
        public UsuarioIntermedio UsuarioIntermedio { get; set; }
    }
}

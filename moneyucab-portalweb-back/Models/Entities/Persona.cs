using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace moneyucab_portalweb_back.Models.Entities
{
    [Table("Persona")]
    public class Persona
    {
        [Key]
        [Column("idUsuario", TypeName = "INT")]
        public int ID { get; set; }

        [Required]
        [Column("nombre", TypeName = "VARCHAR(45)")]
        public string Nombre { get; set; }

        [Required]
        [Column("apellido", TypeName = "VARCHAR(45)")]
        public string Apellido { get; set; }

        [Required]
        [Column("fecha_nacimiento", TypeName = "DATE")]
        public DateTime FechaNacimiento { get; set; }

        [Column("idEstadoCivil", TypeName = "INT")]
        public int EstadoCivilID { get; set; }

        [Column("idUsuario", TypeName = "INT")]
        public int UsuarioID { get; set; }



        [ForeignKey("idEstadoCivil")]
        public EstadoCivil EstadoCivil { get; set; }
        [ForeignKey("idUsuario")]
        public UsuarioIntermedio UsuarioIntermedio { get; set; }

    }
}

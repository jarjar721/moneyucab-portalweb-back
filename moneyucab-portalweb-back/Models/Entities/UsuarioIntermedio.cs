using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace moneyucab_portalweb_back.Models.Entities
{
    public class UsuarioIntermedio
    {
        [Key]
        [Column("idUsuario", TypeName = "SERIAL")]
        public int ID { get; set; }

        [Required]
        [Column("idTipoUsuario", TypeName = "VARCHAR(200)")]
        public int TipoUsuarioID { get; set; }

        [Required]
        [Column("idTipoIdentificacion", TypeName = "VARCHAR(200)")]
        public int TipoIdentificacionID { get; set; }

        [Required]
        [Column("idEntity", TypeName = "VARCHAR(200)")]
        public int EntityID { get; set; }

        [Required]
        [Column("usuario", TypeName = "VARCHAR(20)")]
        public string UserName { get; set; }

        [Required]
        [Column("codigo", TypeName = "CHAR(1)")]
        public DateTime FechaRegistro { get; set; }

        [Required]
        [Column("fecha_registro", TypeName = "DATE")]
        public int NumeroIdentificacion { get; set; }

        [Required]
        [Column("email", TypeName = "VARCHAR(200)")]
        public string Email { get; set; }

        [Required]
        [Column("telefono", TypeName = "VARCHAR(12)")]
        public string Telefono { get; set; }

        [Required]
        [Column("direccion", TypeName = "VARCHAR(500)")]
        public string Direccion { get; set; }

        [Required]
        [Column("estatus", TypeName = "INT")]
        public int Estatus { get; set; }



        [ForeignKey("idEntity")]
        public Usuario Usuario { get; set; }
        public Persona Persona { get; set; }
        public Comercio Comercio { get; set; }
    }
}

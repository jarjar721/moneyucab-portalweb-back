using Npgsql;
using System;

namespace Comunes.Comun
{
    public class ComBanco : EntidadComun, IEntidadComun
    {
        public int idBanco { get; set; }
        public string nombre { get; set; }
        public int estatus { get; set; }

        public ComBanco()
        {

        }

        public ComBanco(int idBanco)
        {
            this.idBanco = idBanco;
        }

        public void LlenadoDataNpgsql(NpgsqlDataReader data)
        {
            this.idBanco = data.GetInt32(0 + offset);
            this.nombre = data.GetString(1 + offset);
            this.estatus = data.GetInt32(2 + offset);
        }
    }
}

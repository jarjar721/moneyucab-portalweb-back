using Npgsql;
using System;

namespace Comunes.Comun
{
    public class ComTipoTarjeta : EntidadComun, IEntidadComun
    {
        public int idTipoTarjeta { get; set; }
        public string descripcion { get; set; }
        public int estatus { get; set; }

        public ComTipoTarjeta()
        {

        }

        public ComTipoTarjeta(int IdTipoTarjeta)
        {
            this.idTipoTarjeta = IdTipoTarjeta;
        }

        public void LlenadoDataNpgsql(NpgsqlDataReader Data)
        {
            this.idTipoTarjeta = Data.GetInt32(0 + offset);
            this.descripcion = Data.GetString(1 + offset);
            this.estatus = Data.GetInt32(2 + offset);
        }
    }
}

using Npgsql;
using System;

namespace Comunes.Comun
{
    public class ComTipoParametro : EntidadComun, IEntidadComun
    {
        public int idTipoParametro { get; set; }
        public string descripcion { get; set; }
        public int estatus { get; set; }

        public ComTipoParametro()
        {

        }

        public void LlenadoDataNpgsql(NpgsqlDataReader Data)
        {
            this.idTipoParametro = Data.GetInt32(0 + offset);
            this.descripcion = Data.GetString(1 + offset);
            this.estatus = Data.GetInt32(2 + offset);
        }
    }
}

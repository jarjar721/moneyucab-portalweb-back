using Npgsql;
using System;

namespace Comunes.Comun
{
    public class ComTipoParametro : EntidadComun, IEntidadComun
    {
        public int _idTipoParametro { get; set; }
        public string _descripcion { get; set; }
        public int _estatus { get; set; }

        public ComTipoParametro()
        {

        }

        public void LlenadoDataNpgsql(NpgsqlDataReader data)
        {
            this._idTipoParametro = data.GetInt32(0 + _offset);
            this._descripcion = data.GetString(1 + _offset);
            this._estatus = data.GetInt32(2 + _offset);
        }
    }
}

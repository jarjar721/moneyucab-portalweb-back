using Npgsql;
using System;

namespace Comunes.Comun
{
    public class ComTipoTarjeta : EntidadComun, IEntidadComun
    {
        private int _idTipoTarjeta;
        private string _descripcion;
        private int _estatus;

        public void LlenadoDataNpgsql(NpgsqlDataReader data)
        {
            this._idTipoTarjeta = data.GetInt32(0 + _offset);
            this._descripcion = data.GetString(1 + _offset);
            this._estatus = data.GetInt32(2 + _offset);
        }
    }
}

using Npgsql;
using System;

namespace Comunes.Comun
{
    public class ComTipoTarjeta : EntidadComun, IEntidadComun
    {
        public int _idTipoTarjeta;
        private string _descripcion;
        private int _estatus;

        public ComTipoTarjeta()
        {

        }

        public ComTipoTarjeta(int idTipoTarjeta)
        {
            this._idTipoTarjeta = idTipoTarjeta;
        }

        public void LlenadoDataNpgsql(NpgsqlDataReader data)
        {
            this._idTipoTarjeta = data.GetInt32(0 + _offset);
            this._descripcion = data.GetString(1 + _offset);
            this._estatus = data.GetInt32(2 + _offset);
        }
    }
}

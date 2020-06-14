using Npgsql;
using System;

namespace Comunes.Comun
{
    public class ComTipoParametro : EntidadComun, IEntidadComun
    {
        private int _idTipoParametro;
        private string _descripcion;
        private int _estatus;

        public void LlenadoDataNpgsql(NpgsqlDataReader data)
        {
            this._idTipoParametro = data.GetInt32(0 + _offset);
            this._descripcion = data.GetString(1 + _offset);
            this._estatus = data.GetInt32(2 + _offset);
        }
    }
}

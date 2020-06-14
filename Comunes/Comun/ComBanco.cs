using Npgsql;
using System;

namespace Comunes.Comun
{
    public class ComBanco : EntidadComun, IEntidadComun
    {
        private int _idBanco;
        private string _nombre;
        private int _estatus;

        public void LlenadoDataNpgsql(NpgsqlDataReader data)
        {
            this._idBanco = data.GetInt32(0 + _offset);
            this._nombre = data.GetString(1 + _offset);
            this._estatus = data.GetInt32(2 + _offset);
        }
    }
}

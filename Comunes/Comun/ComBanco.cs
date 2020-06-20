using Npgsql;
using System;

namespace Comunes.Comun
{
    public class ComBanco : EntidadComun, IEntidadComun
    {
        public int _idBanco;
        private string _nombre;
        private int _estatus;

        public ComBanco()
        {

        }

        public ComBanco(int idBanco)
        {
            this._idBanco = idBanco;
        }

        public void LlenadoDataNpgsql(NpgsqlDataReader data)
        {
            this._idBanco = data.GetInt32(0 + _offset);
            this._nombre = data.GetString(1 + _offset);
            this._estatus = data.GetInt32(2 + _offset);
        }
    }
}

using Npgsql;
using System;

namespace Comunes.Comun
{
    public class ComEstadoCivil : EntidadComun, IEntidadComun
    {
        private int _idEstadoCivil;
        private string _descripcion;
        private char _codigo;
        private int _estatus;

        public void LlenadoDataNpgsql(NpgsqlDataReader data)
        {
            this._idEstadoCivil = data.GetInt32(0 + _offset);
            this._descripcion = data.GetString(1 + _offset);
            this._codigo = data.GetChar(2 + _offset);
            this._estatus = data.GetInt32(3 + _offset);
        }
    }
}

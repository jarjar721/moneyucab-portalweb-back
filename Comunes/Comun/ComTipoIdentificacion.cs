using Npgsql;
using System;

namespace Comunes.Comun
{
    public class ComTipoIdentificacion : EntidadComun, IEntidadComun
    {
        private int _idTipoIdentificacion;
        private char _codigo;
        private string _descripcion;
        private int _estatus;

        public void LlenadoDataNpgsql(NpgsqlDataReader data)
        {
            this._idTipoIdentificacion = data.GetInt32(0 + _offset);
            this._codigo = data.GetChar(1 + _offset);
            this._descripcion = data.GetString(2 + _offset);
            this._estatus = data.GetInt32(3 + _offset);
        }
    }
}

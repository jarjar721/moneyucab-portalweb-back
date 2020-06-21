using Npgsql;
using System;

namespace Comunes.Comun
{
    public class ComTipoOperacion : EntidadComun, IEntidadComun
    {
        private int _idTipoIdentificacion;
        private string _descripcion;
        private int _estatus;

        public ComTipoOperacion()
        {

        }

        public void LlenadoDataNpgsql(NpgsqlDataReader data)
        {
            this._idTipoIdentificacion = data.GetInt32(0 + _offset);
            this._descripcion = data.GetString(1 + _offset);
            this._estatus = data.GetInt32(2 + _offset);
        }
    }
}

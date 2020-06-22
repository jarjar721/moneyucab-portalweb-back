using Npgsql;
using System;

namespace Comunes.Comun
{
    public class ComTipoOperacion : EntidadComun, IEntidadComun
    {
        private int _idTipoIdentificacion { get; set; }
        private string _descripcion { get; set; }
        private int _estatus { get; set; }

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

using Npgsql;
using System;

namespace Comunes.Comun
{
    public class ComFrecuencia : EntidadComun, IEntidadComun
    {
        private int _idFrecuencia { get; set; }
        private char _codigo { get; set; }
        private string _descripcion { get; set; }
        private int _estatus { get; set; }

        public ComFrecuencia()
        {

        }

        public void LlenadoDataNpgsql(NpgsqlDataReader data)
        {
            this._idFrecuencia = data.GetInt32(0 + _offset);
            this._codigo = data.GetChar(1 + _offset);
            this._descripcion = data.GetString(2 + _offset);
            this._estatus = data.GetInt32(3 + _offset);
        }
    }
}

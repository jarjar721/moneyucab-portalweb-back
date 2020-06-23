using Npgsql;
using System;

namespace Comunes.Comun
{
    public class ComFrecuencia : EntidadComun, IEntidadComun
    {
        public int _idFrecuencia { get; set; }
        public char _codigo { get; set; }
        public string _descripcion { get; set; }
        public int _estatus { get; set; }

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

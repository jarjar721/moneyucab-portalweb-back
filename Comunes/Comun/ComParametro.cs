using Npgsql;
using System;

namespace Comunes.Comun
{
    public class ComParametro : EntidadComun, IEntidadComun
    {
        public ComTipoParametro _tipoParametro = new ComTipoParametro();
        public ComFrecuencia _frecuencia = new ComFrecuencia();
        public int _idParametro { get; set; }
        public string _nombre { get; set; }
        public int _estatus { get; set; }

        public ComParametro()
        {

        }

        public ComParametro(int idParametro)
        {
            this._idParametro = idParametro;
        }

        public void LlenadoDataNpgsql(NpgsqlDataReader data)
        {
            this._idParametro = data.GetInt32(0 + _offset);
            this._nombre = data.GetString(3 + _offset);
            this._estatus = data.GetInt32(4 + _offset);
            this._tipoParametro._offset = 5 + _offset;
            this._tipoParametro.LlenadoDataNpgsql(data);
            this._frecuencia._offset = 8 + _offset;
            this._frecuencia.LlenadoDataNpgsql(data);
        }
    }
}

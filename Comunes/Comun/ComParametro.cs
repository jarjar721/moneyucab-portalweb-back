using Npgsql;
using System;

namespace Comunes.Comun
{
    public class ComParametro : EntidadComun, IEntidadComun
    {
        private ComTipoParametro _tipoParametro = new ComTipoParametro();
        private ComFrecuencia _frecuencia = new ComFrecuencia();
        public int _idParametro { get; set; }
        private string _nombre { get; set; }
        private int _estatus { get; set; }

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
            this._nombre = data.GetString(3);
            this._estatus = data.GetInt32(4);
            this._tipoParametro._offset = 9 + _offset;
            this._tipoParametro.LlenadoDataNpgsql(data);
            this._frecuencia._offset = 5 + _offset;
            this._frecuencia.LlenadoDataNpgsql(data);
        }
    }
}

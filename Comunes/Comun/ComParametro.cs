using Npgsql;
using System;

namespace Comunes.Comun
{
    public class ComParametro : EntidadComun, IEntidadComun
    {
        private ComTipoParametro _tipoParametro = new ComTipoParametro();
        private ComFrecuencia _frecuencia = new ComFrecuencia();
        private int _idParametro;
        private string _nombre;
        private string _estatus;


        public void LlenadoDataNpgsql(NpgsqlDataReader data)
        {
            this._idParametro = data.GetInt32(0 + _offset);
            this._nombre = data.GetString(3);
            this._estatus = data.GetString(4);
            this._tipoParametro._offset = 5;
            this._tipoParametro.LlenadoDataNpgsql(data);
            this._frecuencia._offset = 9;
            this._frecuencia.LlenadoDataNpgsql(data);
        }
    }
}

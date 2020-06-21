using Npgsql;
using NpgsqlTypes;
using System;

namespace Comunes.Comun
{
    public class ComOperacionTarjeta : EntidadComun, IEntidadComun
    {
        private int _idOperacionTarjeta;
        private int _idUsuarioReceptor;
        private int _idTarjeta;
        private NpgsqlDate _fecha;
        //private Npgsql _hora;
        private double _monto;
        private string _referencia;

        public ComOperacionTarjeta()
        {

        }

        public void LlenadoDataNpgsql(NpgsqlDataReader data)
        {
            this._idOperacionTarjeta = data.GetInt32(0 + _offset);
            this._idUsuarioReceptor = data.GetInt32(1 + _offset);
            this._idTarjeta = data.GetInt32(2 + _offset);
            this._fecha = data.GetDate(3 + _offset);
            //this._hora = data.GetDateTime(4 + _offset);
            this._monto = data.GetDouble(5 + _offset);
            this._referencia = data.GetString(6 + _offset);
        }
    }
}

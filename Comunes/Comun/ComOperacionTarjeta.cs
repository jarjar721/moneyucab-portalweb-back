using Npgsql;
using NpgsqlTypes;
using System;

namespace Comunes.Comun
{
    public class ComOperacionTarjeta : EntidadComun, IEntidadComun
    {
        private int _idOperacionTarjeta { get; set; }
        private int _idUsuarioReceptor { get; set; }
        private int _idTarjeta { get; set; }
        private NpgsqlDate _fecha { get; set; }
        //private Npgsql _hora{ get; set; }
        private double _monto { get; set; }
        private string _referencia { get; set; }

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

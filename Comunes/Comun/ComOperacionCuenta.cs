using Npgsql;
using NpgsqlTypes;
using System;

namespace Comunes.Comun
{
    public class ComOperacionCuenta : EntidadComun, IEntidadComun
    {
        public int _idOperacionCuenta { get; set; }
        public int _idUsuarioReceptor { get; set; }
        public int _idCuenta { get; set; }
        public NpgsqlDate _fecha { get; set; }
        //private string _hora{ get; set; }
        public double _monto { get; set; }
        public string _referencia { get; set; }

        public ComOperacionCuenta()
        {

        }

        public void LlenadoDataNpgsql(NpgsqlDataReader data)
        {
            this._idOperacionCuenta = data.GetInt32(0 + _offset);
            this._idUsuarioReceptor = data.GetInt32(1 + _offset);
            this._idCuenta = data.GetInt32(2 + _offset);
            this._fecha = data.GetDate(3 + _offset);
            //this._hora = data.GetString(4 + _offset);
            this._monto = data.GetDouble(5 + _offset);
            this._referencia = data.GetString(6 + _offset);
        }
    }
}
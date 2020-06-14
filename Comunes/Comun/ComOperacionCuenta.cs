using Npgsql;
using System;

namespace Comunes.Comun
{
    public class ComOperacionCuenta : EntidadComun, IEntidadComun
    {
        private int _idOperacionCuenta;
        private int _idUsuarioReceptor;
        private int _idCuenta;
        private string _fecha;
        private string _hora;
        private double _monto;
        private string _referencia;

        public void LlenadoDataNpgsql(NpgsqlDataReader data)
        {
            this._idOperacionCuenta = data.GetInt32(0 + _offset);
            this._idUsuarioReceptor = data.GetInt32(1 + _offset);
            this._idCuenta = data.GetInt32(2 + _offset);
            this._fecha = data.GetString(3 + _offset);
            this._hora = data.GetString(4 + _offset);
            this._monto = data.GetDouble(0 + _offset);
            this._referencia = data.GetString(6 + _offset);
        }
    }
}

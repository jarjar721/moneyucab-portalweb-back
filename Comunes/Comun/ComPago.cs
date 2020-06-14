using Npgsql;
using NpgsqlTypes;
using System;

namespace Comunes.Comun
{
    public class ComPago : EntidadComun, IEntidadComun
    {
        private int _idPago;
        private int _idUsuarioSolicitante;
        private int _idUsuarioReceptor;
        private NpgsqlDate _fecha;
        private double _monto;
        private string _estatus;
        private string _referencia;

        public void LlenadoDataNpgsql(NpgsqlDataReader data)
        {
            this._idPago = data.GetInt32(0 + _offset);
            this._idUsuarioSolicitante = data.GetInt32(1 + _offset);
            this._idUsuarioReceptor = data.GetInt32(2 + _offset);
            this._fecha = data.GetDate(3 + _offset);
            this._monto = data.GetDouble(4 + _offset);
            this._estatus = data.GetString(5 + _offset);
            this._referencia = data.GetString(6 + _offset);
        }
    }
}

using Npgsql;
using NpgsqlTypes;
using System;

namespace Comunes.Comun
{
    public class ComTarjeta : EntidadComun, IEntidadComun
    {

        private ComTipoTarjeta _tipoTarjeta = new ComTipoTarjeta();
        private ComBanco _banco = new ComBanco();
        private int _idTarjeta;
        private int _idUsuario;
        private int _numero;
        private NpgsqlDate _fecha_vencimiento;
        private int _cvc;
        private int _estatus;


        public void LlenadoDataNpgsql(NpgsqlDataReader data)
        {
            this._tipoTarjeta._offset = 11;
            this._tipoTarjeta.LlenadoDataNpgsql(data);
            this._banco._offset = 8;
            this._banco.LlenadoDataNpgsql(data);
            this._idTarjeta = data.GetInt32(0 + _offset);
            this._idUsuario = data.GetInt32(1 + _offset);
            this._numero = data.GetInt32(2 + _offset);
            this._fecha_vencimiento = data.GetDate(3);
            this._cvc = data.GetInt32(4 + _offset);
            this._estatus = data.GetInt32(5 + _offset);
        }
    }
}

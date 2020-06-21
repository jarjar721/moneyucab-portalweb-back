using Npgsql;
using NpgsqlTypes;
using System;

namespace Comunes.Comun
{
    public class ComTarjeta : EntidadComun, IEntidadComun, IFormularioInsert
    {

        private ComTipoTarjeta _tipoTarjeta = new ComTipoTarjeta();
        private ComBanco _banco = new ComBanco();
        private int _idTarjeta;
        private int _idUsuario;
        private int _numero;
        private NpgsqlDate _fecha_vencimiento;
        private int _cvc;
        private int _estatus;

        public ComTarjeta()
        {

        }

        public ComTarjeta(ComTipoTarjeta tipotarjeta, ComBanco banco, int idUsuario, int numero, NpgsqlDate fecha_vencimiento, int cvc, int estatus)
        {
            this._tipoTarjeta = tipotarjeta;
            this._banco = banco;
            this._idUsuario = idUsuario;
            this._numero = numero;
            this._fecha_vencimiento = fecha_vencimiento;
            this._cvc = cvc;
            this._estatus = estatus;
        }

        public void LlenadoDataForm(NpgsqlCommand ComandoSQL)
        {
            ComandoSQL.Parameters.Add(new NpgsqlParameter("UsuarioId", this._idUsuario));
            ComandoSQL.Parameters.Add(new NpgsqlParameter("TipoTarjetaId", this._tipoTarjeta._idTipoTarjeta));
            ComandoSQL.Parameters.Add(new NpgsqlParameter("BancoId", this._banco._idBanco));
            ComandoSQL.Parameters.Add(new NpgsqlParameter("Numero", this._numero));
            ComandoSQL.Parameters.Add(new NpgsqlParameter("FechaVencimiento", this._fecha_vencimiento));
            ComandoSQL.Parameters.Add(new NpgsqlParameter("cvc", this._cvc));
            ComandoSQL.Parameters.Add(new NpgsqlParameter("Estatus", this._estatus));
        }

        public void LlenadoDataNpgsql(NpgsqlDataReader data)
        {
            this._tipoTarjeta._offset = 11;
            this._tipoTarjeta.LlenadoDataNpgsql(data);
            this._banco._offset = 8;
            this._banco.LlenadoDataNpgsql(data);
            this._idTarjeta = data.GetInt32(0 + _offset);
            this._idUsuario = data.GetInt32(1 + _offset);
            this._numero = data.GetInt32(4 + _offset);
            this._fecha_vencimiento = data.GetDate(5);
            this._cvc = data.GetInt32(6 + _offset);
            this._estatus = data.GetInt32(7 + _offset);
        }
    }
}

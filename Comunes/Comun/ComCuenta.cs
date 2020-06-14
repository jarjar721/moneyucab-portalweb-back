using Npgsql;
using System;

namespace Comunes.Comun
{
    public class ComCuenta : EntidadComun, IEntidadComun
    {

        private ComTipoCuenta _tipoCuenta = new ComTipoCuenta();
        private ComBanco _banco = new ComBanco();
        private int _idCuenta;
        private int _idUsuario;
        private int _numero;


        public void LlenadoDataNpgsql(NpgsqlDataReader data)
        {
            this._tipoCuenta._offset = 8;
            this._tipoCuenta.LlenadoDataNpgsql(data);
            this._banco._offset = 5;
            this._banco.LlenadoDataNpgsql(data);
            this._idCuenta = data.GetInt32(0);
            this._idUsuario = data.GetInt32(1);
            this._numero = data.GetInt32(4);
        }
    }
}

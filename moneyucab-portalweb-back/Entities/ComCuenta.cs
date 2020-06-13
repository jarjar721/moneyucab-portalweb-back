using Npgsql;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace moneyucab_portalweb_back.Entities
{
    public class ComCuenta : EntidadComun, IEntidadComun
    {

        private ComTipoCuenta _tipoCuenta= new ComTipoCuenta();
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
            this._idCuenta = Int32.Parse(data.GetString(0));
            this._idUsuario = Int32.Parse(data.GetString(1));
            this._numero = Int32.Parse(data.GetString(4));
        }
    }
}

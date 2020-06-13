using Npgsql;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace moneyucab_portalweb_back.Entities
{
    public class ComTarjeta : EntidadComun, IEntidadComun
    {

        private ComTipoTarjeta _tipoTarjeta= new ComTipoTarjeta();
        private ComBanco _banco = new ComBanco();
        private int _idTarjeta;
        private int _idUsuario;
        private int _numero;
        private string _fecha_vencimiento;
        private int _cvc;
        private int _estatus;


        public void LlenadoDataNpgsql(NpgsqlDataReader data)
        {
            this._tipoTarjeta._offset = 11;
            this._tipoTarjeta.LlenadoDataNpgsql(data);
            this._banco._offset = 8;
            this._banco.LlenadoDataNpgsql(data);
            this._idTarjeta = Int32.Parse(data.GetString(0));
            this._idUsuario = Int32.Parse(data.GetString(1));
            this._numero = Int32.Parse(data.GetString(2));
            this._fecha_vencimiento = data.GetString(3);
            this._cvc = Int32.Parse(data.GetString(4));
            this._estatus = Int32.Parse(data.GetString(5));
        }
    }
}

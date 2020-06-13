using Npgsql;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace moneyucab_portalweb_back.Entities
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
            this._idOperacionCuenta = Int32.Parse(data.GetString(0 + _offset));
            this._idUsuarioReceptor = Int32.Parse(data.GetString(1 + _offset));
            this._idCuenta = Int32.Parse(data.GetString(2 + _offset));
            this._fecha = data.GetString(3 + _offset);
            this._hora = data.GetString(4 + _offset);
            this._monto = Double.Parse(data.GetString(5 + _offset));
            this._referencia = data.GetString(6 + _offset);
        }
    }
}

using Npgsql;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace moneyucab_portalweb_back.Entities
{
    public class ComOperacionTarjeta : EntidadComun, IEntidadComun
    {
        private int _idOperacionTarjeta;
        private int _idUsuarioReceptor;
        private int _idTarjeta;
        private string _fecha;
        private string _hora;
        private double _monto;
        private string _referencia;

        public void LlenadoDataNpgsql(NpgsqlDataReader data)
        {
            this._idOperacionTarjeta = Int32.Parse(data.GetString(0 + _offset));
            this._idUsuarioReceptor = Int32.Parse(data.GetString(1 + _offset));
            this._idTarjeta = Int32.Parse(data.GetString(2 + _offset));
            this._fecha = data.GetString(3 + _offset);
            this._hora = data.GetString(4 + _offset);
            this._monto = Double.Parse(data.GetString(5 + _offset));
            this._referencia = data.GetString(6 + _offset);
        }
    }
}

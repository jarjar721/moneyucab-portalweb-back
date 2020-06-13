using Npgsql;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace moneyucab_portalweb_back.Entities
{
    public class ComParametro : EntidadComun, IEntidadComun
    {
        private ComTipoParametro _tipoParametro = new ComTipoParametro();
        private ComFrecuencia _frecuencia= new ComFrecuencia();
        private int _idParametro;
        private string _nombre;
        private string _estatus;

        
        public void LlenadoDataNpgsql(NpgsqlDataReader data)
        {
            this._idParametro = Int32.Parse(data.GetString(0));
            this._nombre = data.GetString(3);
            this._estatus = data.GetString(4);
            this._tipoParametro._offset = 5;
            this._tipoParametro.LlenadoDataNpgsql(data);
            this._frecuencia._offset = 9;
            this._frecuencia.LlenadoDataNpgsql(data);
        }
    }
}

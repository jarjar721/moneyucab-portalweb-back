using Npgsql;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace moneyucab_portalweb_back.Entities
{
    public class ComComercio : EntidadComun, IEntidadComun
    {
        private string _razon_social;
        private string _nombre_representante;
        private string _apellido_representante;

        public void LlenadoDataNpgsql(NpgsqlDataReader data)
        {
            this._razon_social = data.GetString(0 + _offset);
            this._nombre_representante = data.GetString(1 + _offset);
            this._apellido_representante = data.GetString(2 + _offset);
        }
    }
}

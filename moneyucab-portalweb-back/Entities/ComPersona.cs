using Npgsql;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace moneyucab_portalweb_back.Entities
{
    public class ComPersona : EntidadComun, IEntidadComun
    {
        private ComTipoIdentificacion _tipoIdentificacion = new ComTipoIdentificacion();
        private string _nombre;
        private string _apellido;
        private string _fecha_nacimiento;

        
        public void LlenadoDataNpgsql(NpgsqlDataReader data)
        {
            this._nombre = data.GetString(0 + _offset);
            this._apellido = data.GetString(1 + _offset);
            this._fecha_nacimiento = data.GetString(2 + _offset);
            this._tipoIdentificacion._offset = 7 + _offset;
            this._tipoIdentificacion.LlenadoDataNpgsql(data);
        }
    }
}

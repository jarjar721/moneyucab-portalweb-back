using Microsoft.VisualBasic.CompilerServices;
using Npgsql;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Numerics;
using System.Threading.Tasks;

namespace moneyucab_portalweb_back.Entities
{
    public class ComBanco : EntidadComun, IEntidadComun
    {
        private int _idBanco;
        private string _nombre;
        private int _estatus;

        public void LlenadoDataNpgsql(NpgsqlDataReader data)
        {
            this._idBanco = Int32.Parse(data.GetString(0 + _offset));
            this._nombre = data.GetString(1 + _offset);
            this._estatus = Int32.Parse(data.GetString(2 + _offset));
        }
    }
}

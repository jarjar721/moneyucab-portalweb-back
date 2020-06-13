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
    public class ComTipoCuenta : EntidadComun, IEntidadComun
    {
        private int _idTipoCuenta;
        private string _descripcion;
        private int _estatus;

        public void LlenadoDataNpgsql(NpgsqlDataReader data)
        {
            this._idTipoCuenta = Int32.Parse(data.GetString(0 + _offset));
            this._descripcion = data.GetString(1 + _offset);
            this._estatus = Int32.Parse(data.GetString(2 + _offset));
        }
    }
}

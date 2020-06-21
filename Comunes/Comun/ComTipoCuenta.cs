﻿using Npgsql;
using System;

namespace Comunes.Comun
{
    public class ComTipoCuenta : EntidadComun, IEntidadComun
    {
        public int _idTipoCuenta;
        private string _descripcion;
        private int _estatus;

        public ComTipoCuenta()
        {

        }

        public ComTipoCuenta(int idTipoCuenta)
        {
            this._idTipoCuenta = idTipoCuenta;
        }

        public void LlenadoDataNpgsql(NpgsqlDataReader data)
        {
            this._idTipoCuenta = data.GetInt32(0 + _offset);
            this._descripcion = data.GetString(1 + _offset);
            this._estatus = data.GetInt32(2 + _offset);
        }
    }
}

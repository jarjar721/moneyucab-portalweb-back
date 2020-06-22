﻿using Npgsql;
using System;

namespace Comunes.Comun
{
    public class ComEstadoCivil : EntidadComun, IEntidadComun
    {
        public int _idEstadoCivil { get; set; }
        private string _descripcion { get; set; }
        private char _codigo { get; set; }
        private int _estatus { get; set; }

        public ComEstadoCivil()
        {

        }

        public ComEstadoCivil(int idEstadoCivil, string descripcion, char codigo, int estatus)
        {
            this._idEstadoCivil = idEstadoCivil;
            this._descripcion = descripcion;
            this._codigo = codigo;
            this._estatus = estatus;
        }

        public void LlenadoDataNpgsql(NpgsqlDataReader data)
        {
            this._idEstadoCivil = data.GetInt32(0 + _offset);
            this._descripcion = data.GetString(1 + _offset);
            this._codigo = data.GetChar(2 + _offset);
            this._estatus = data.GetInt32(3 + _offset);
        }
    }
}

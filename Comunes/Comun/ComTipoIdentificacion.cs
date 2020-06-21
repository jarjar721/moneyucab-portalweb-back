﻿using Npgsql;
using System;

namespace Comunes.Comun
{
    public class ComTipoIdentificacion : EntidadComun, IEntidadComun
    {
        public int _idTipoIdentificacion;
        private char _codigo;
        private string _descripcion;
        private int _estatus;

        public ComTipoIdentificacion()
        {

        }

        public ComTipoIdentificacion(int idTipoIdentificacion, char codigo, string descripcion, int estatus)
        {
            this._idTipoIdentificacion = idTipoIdentificacion;
            this._codigo = codigo;
            this._descripcion = descripcion;
            this._estatus = estatus;
        }

        public void LlenadoDataNpgsql(NpgsqlDataReader data)
        {
            this._idTipoIdentificacion = data.GetInt32(0 + _offset);
            this._codigo = data.GetChar(1 + _offset);
            this._descripcion = data.GetString(2 + _offset);
            this._estatus = data.GetInt32(3 + _offset);
        }
    }
}
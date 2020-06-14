using Npgsql;
using NpgsqlTypes;
using System;

namespace Comunes.Comun
{
    public class ComUsuario : EntidadComun, IEntidadComun
    {

        private ComComercio _comercio = new ComComercio();
        private ComPersona _persona = new ComPersona();
        private ComTipoIdentificacion _tipoIdentificacion = new ComTipoIdentificacion();
        private int _idUsuario;
        private string _idEntity;
        private string _usuario;
        private NpgsqlDate _fecha_registro;
        private int _nro_identificacion;
        private string _email;
        private string _telefono;
        private string _direccion;
        private int _estatus;


        public void LlenadoDataNpgsql(NpgsqlDataReader data)
        {
            this._comercio._offset = 18;
            this._comercio.LlenadoDataNpgsql(data);
            this._persona._offset = 13;
            this._persona.LlenadoDataNpgsql(data);
            this._idUsuario = data.GetInt32(0 + _offset);
            this._idEntity = data.GetString(3 + _offset);
            this._usuario = data.GetString(4 + _offset);
            this._fecha_registro = data.GetDate(5 + _offset);
            this._nro_identificacion = data.GetInt32(6 + _offset);
            this._email = data.GetString(7 + _offset);
            this._telefono = data.GetString(8 + _offset);
            this._direccion = data.GetString(9 + _offset);
            this._estatus = data.GetInt32(10 + _offset);
            this._tipoIdentificacion._offset = 20;
            this._tipoIdentificacion.LlenadoDataNpgsql(data);
        }
    }
}

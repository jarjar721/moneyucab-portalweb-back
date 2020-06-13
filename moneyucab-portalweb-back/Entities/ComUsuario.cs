using Npgsql;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace moneyucab_portalweb_back.Entities
{
    public class ComUsuario : EntidadComun, IEntidadComun
    {

        private ComComercio _comercio= new ComComercio();
        private ComPersona _persona = new ComPersona();
        private int _idUsuario;
        private string _idEntity;
        private string _usuario;
        private string _fecha_registro;
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
            this._idUsuario = Int32.Parse(data.GetString(0 + _offset));
            this._idEntity = data.GetString(3 + _offset);
            this._usuario = data.GetString(4 + _offset);
            this._fecha_registro = data.GetString(5 + _offset);
            this._nro_identificacion = Int32.Parse(data.GetString(6 + _offset));
            this._email = data.GetString(7 + _offset);
            this._telefono = data.GetString(8 + _offset);
            this._direccion = data.GetString(9 + _offset);
            this._estatus = Int32.Parse(data.GetString(10 + _offset));
        }
    }
}

using Npgsql;
using NpgsqlTypes;
using System;

namespace Comunes.Comun
{
    public class ComUsuario : EntidadComun, IEntidadComun, IFormularioRegistro
    {

        public ComComercio _comercio = new ComComercio();
        public ComPersona _persona = new ComPersona();
        public ComTipoIdentificacion _tipoIdentificacion = new ComTipoIdentificacion();
        public int _idUsuario { get; set; }
        public string _idEntity { get; set; }
        public string _usuario { get; set; }
        public NpgsqlDate _fecha_registro { get; set; }
        public int _nro_identificacion { get; set; }
        public string _email { get; set; }
        public string _telefono { get; set; }
        public string _direccion { get; set; }
        public int _estatus { get; set; }
        public string _contrasena { get; set; }
        public int _idTipoUsuario { get; set; }

        public ComUsuario()
        {

        }

        public ComUsuario(ComComercio comercio, ComPersona persona, ComTipoIdentificacion tipoIdentificacion, int idUsuario, string idEntity, string usuario,
                            NpgsqlDate fecha_registro, int nro_identificacion, string email, string telefono, string direccion, int estatus, string contrasena)
        {
            this._comercio = comercio;
            this._persona = persona;
            this._idUsuario = idUsuario;
            this._idEntity = idEntity;
            this._usuario = usuario;
            this._fecha_registro = fecha_registro;
            this._nro_identificacion = nro_identificacion;
            this._email = email;
            this._telefono = telefono;
            this._direccion = direccion;
            this._estatus = 1;
            this._tipoIdentificacion = tipoIdentificacion;
            this._idTipoUsuario = 1;
            this._contrasena = contrasena;
        }

        public void LlenadoDataFormPersona(NpgsqlCommand ComandoSQL)
        {
            //ComandoSQL.Parameters.Add(new NpgsqlParameter("EntityId", this._idEntity));
            ComandoSQL.Parameters.Add(new NpgsqlParameter("TipoUsuarioId", this._idTipoUsuario));
            ComandoSQL.Parameters.Add(new NpgsqlParameter("TipoIdentificacionId", this._tipoIdentificacion._idTipoIdentificacion));
            ComandoSQL.Parameters.Add(new NpgsqlParameter("Usuario", this._usuario));
            ComandoSQL.Parameters.Add(new NpgsqlParameter("FechaRegistro", this._fecha_registro));
            ComandoSQL.Parameters.Add(new NpgsqlParameter("NroIdentificacion", this._nro_identificacion));
            ComandoSQL.Parameters.Add(new NpgsqlParameter("Email", this._email));
            ComandoSQL.Parameters.Add(new NpgsqlParameter("Telefono", this._telefono));
            ComandoSQL.Parameters.Add(new NpgsqlParameter("Direccion", this._direccion));
            ComandoSQL.Parameters.Add(new NpgsqlParameter("TipoSol", 'P'));
            ComandoSQL.Parameters.Add(new NpgsqlParameter("Contrasena", this._contrasena));
            ComandoSQL.Parameters.Add(new NpgsqlParameter("Estatus", this._estatus));
            this._persona.LlenadoDataFormPersona(ComandoSQL);
        }

        public void LlenadoDataFormComercio(NpgsqlCommand ComandoSQL)
        {
            //ComandoSQL.Parameters.Add(new NpgsqlParameter("EntityId", this._idEntity));
            ComandoSQL.Parameters.Add(new NpgsqlParameter("TipoUsuarioId", this._idUsuario));
            ComandoSQL.Parameters.Add(new NpgsqlParameter("TipoIdentificacionId", this._tipoIdentificacion._idTipoIdentificacion));
            ComandoSQL.Parameters.Add(new NpgsqlParameter("Usuario", this._usuario));
            ComandoSQL.Parameters.Add(new NpgsqlParameter("FechaRegistro", this._fecha_registro));
            ComandoSQL.Parameters.Add(new NpgsqlParameter("NroIdentificacion", this._nro_identificacion));
            ComandoSQL.Parameters.Add(new NpgsqlParameter("Email", this._email));
            ComandoSQL.Parameters.Add(new NpgsqlParameter("Telefono", this._telefono));
            ComandoSQL.Parameters.Add(new NpgsqlParameter("Direccion", this._direccion));
            ComandoSQL.Parameters.Add(new NpgsqlParameter("Estatus", this._estatus));
            ComandoSQL.Parameters.Add(new NpgsqlParameter("TipoSol", 'C'));
            ComandoSQL.Parameters.Add(new NpgsqlParameter("Contrasena", this._contrasena));
            this._comercio.LlenadoDataFormComercio(ComandoSQL);
        }

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

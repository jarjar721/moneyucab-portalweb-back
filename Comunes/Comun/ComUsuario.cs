using Npgsql;
using NpgsqlTypes;
using System;

namespace Comunes.Comun
{
    public class ComUsuario : EntidadComun, IEntidadComun, IFormularioRegistro
    {

        public ComComercio comercio = new ComComercio();
        public ComPersona persona = new ComPersona();
        public ComTipoIdentificacion tipoIdentificacion = new ComTipoIdentificacion();
        public int idUsuario { get; set; }
        public string idEntity { get; set; }
        public string usuario { get; set; }
        public NpgsqlDate fechaRegistro { get; set; }
        public int nroIdentificacion { get; set; }
        public string email { get; set; }
        public string telefono { get; set; }
        public string direccion { get; set; }
        public int estatus { get; set; }
        public string contrasena { get; set; }
        public int idTipoUsuario { get; set; }

        public ComUsuario()
        {

        }

        public ComUsuario(ComComercio Comercio, ComPersona Persona, ComTipoIdentificacion TipoIdentificacion, int IdUsuario, string IdEntity, string Usuario,
                            NpgsqlDate FechaRegistro, int NroIdentificacion, string Email, string Telefono, string Direccion, int Estatus, string Contrasena)
        {
            this.comercio = Comercio;
            this.persona = Persona;
            this.idUsuario = IdUsuario;
            this.idEntity = IdEntity;
            this.usuario = Usuario;
            this.fechaRegistro = FechaRegistro;
            this.nroIdentificacion = NroIdentificacion;
            this.email = Email;
            this.telefono = Telefono;
            this.direccion = Direccion;
            this.estatus = 1;
            this.tipoIdentificacion = TipoIdentificacion;
            this.idTipoUsuario = 1;
            this.contrasena = Contrasena;
        }

        public void LlenadoDataFormPersona(NpgsqlCommand ComandoSQL)
        {
            //ComandoSQL.Parameters.Add(new NpgsqlParameter("EntityId", this._idEntity));
            ComandoSQL.Parameters.Add(new NpgsqlParameter("TipoUsuarioId", this.idTipoUsuario));
            ComandoSQL.Parameters.Add(new NpgsqlParameter("TipoIdentificacionId", this.tipoIdentificacion.idTipoIdentificacion));
            ComandoSQL.Parameters.Add(new NpgsqlParameter("Usuario", this.usuario));
            ComandoSQL.Parameters.Add(new NpgsqlParameter("FechaRegistro", this.fechaRegistro));
            ComandoSQL.Parameters.Add(new NpgsqlParameter("NroIdentificacion", this.nroIdentificacion));
            ComandoSQL.Parameters.Add(new NpgsqlParameter("Email", this.email));
            ComandoSQL.Parameters.Add(new NpgsqlParameter("Telefono", this.telefono));
            ComandoSQL.Parameters.Add(new NpgsqlParameter("Direccion", this.direccion));
            ComandoSQL.Parameters.Add(new NpgsqlParameter("TipoSol", 'P'));
            ComandoSQL.Parameters.Add(new NpgsqlParameter("Contrasena", this.contrasena));
            ComandoSQL.Parameters.Add(new NpgsqlParameter("Estatus", this.estatus));
            this.persona.LlenadoDataFormPersona(ComandoSQL);
        }

        public void LlenadoDataFormComercio(NpgsqlCommand ComandoSQL)
        {
            //ComandoSQL.Parameters.Add(new NpgsqlParameter("EntityId", this._idEntity));
            ComandoSQL.Parameters.Add(new NpgsqlParameter("TipoUsuarioId", this.idTipoUsuario));
            ComandoSQL.Parameters.Add(new NpgsqlParameter("TipoIdentificacionId", this.tipoIdentificacion.idTipoIdentificacion));
            ComandoSQL.Parameters.Add(new NpgsqlParameter("Usuario", this.usuario));
            ComandoSQL.Parameters.Add(new NpgsqlParameter("FechaRegistro", this.fechaRegistro));
            ComandoSQL.Parameters.Add(new NpgsqlParameter("NroIdentificacion", this.nroIdentificacion));
            ComandoSQL.Parameters.Add(new NpgsqlParameter("Email", this.email));
            ComandoSQL.Parameters.Add(new NpgsqlParameter("Telefono", this.telefono));
            ComandoSQL.Parameters.Add(new NpgsqlParameter("Direccion", this.direccion));
            ComandoSQL.Parameters.Add(new NpgsqlParameter("Estatus", this.estatus));
            ComandoSQL.Parameters.Add(new NpgsqlParameter("TipoSol", 'C'));
            ComandoSQL.Parameters.Add(new NpgsqlParameter("Contrasena", this.contrasena));
            this.comercio.LlenadoDataFormComercio(ComandoSQL);
        }

        public void LlenadoDataNpgsql(NpgsqlDataReader Data)
        {
            this.comercio.offset = 17;
            this.comercio.LlenadoDataNpgsql(Data);
            this.persona.offset = 13;
            this.persona.LlenadoDataNpgsql(Data);
            this.idUsuario = Data.GetInt32(0 + offset);
            this.idEntity = Data.GetString(3 + offset);
            this.usuario = Data.GetString(4 + offset);
            this.fechaRegistro = Data.GetDate(5 + offset);
            this.nroIdentificacion = Data.GetInt32(6 + offset);
            this.email = Data.GetString(7 + offset);
            this.telefono = Data.GetString(8 + offset);
            this.direccion = Data.GetString(9 + offset);
            this.estatus = Data.GetInt32(10 + offset);
            this.tipoIdentificacion.offset = 20;
            this.tipoIdentificacion.LlenadoDataNpgsql(Data);
        }
    }
}

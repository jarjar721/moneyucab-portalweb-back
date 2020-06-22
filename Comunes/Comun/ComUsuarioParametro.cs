using Npgsql;
using NpgsqlTypes;
using System;

namespace Comunes.Comun
{
    public class ComUsuarioParametro : EntidadComun, IEntidadComun, IFormularioInsert
    {
        private int _idUsuario { get; set; }
        private ComParametro _parametro = new ComParametro();
        private string _validacion { get; set; }
        private int _estatus { get; set; }

        public ComUsuarioParametro()
        {
            
        }

        public ComUsuarioParametro(int idUsuario, int idParametro, string validacion, int estatus)
        {
            this._idUsuario = idUsuario;
            this._validacion = validacion;
            this._estatus = estatus;
            this._parametro = new ComParametro(1);
        }

        public void LlenadoDataForm(NpgsqlCommand ComandoSQL)
        {
            ComandoSQL.Parameters.Add(new NpgsqlParameter("UsuarioId", this._idUsuario));
            ComandoSQL.Parameters.Add(new NpgsqlParameter("ParametroId", this._parametro._idParametro));
            ComandoSQL.Parameters.Add(new NpgsqlParameter("Validacion", this._validacion));
            ComandoSQL.Parameters.Add(new NpgsqlParameter("Estatus", this._estatus));
        }

        public void LlenadoDataNpgsql(NpgsqlDataReader data)
        {
            this._idUsuario = data.GetInt32(0 + _offset);
            this._validacion = data.GetString(2 + _offset);
            this._estatus = data.GetInt32(3 + _offset);
            this._parametro._offset = 5;
            this._parametro.LlenadoDataNpgsql(data);
        }
    }
}

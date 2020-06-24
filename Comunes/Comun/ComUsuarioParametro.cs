using Npgsql;
using NpgsqlTypes;
using System;

namespace Comunes.Comun
{
    public class ComUsuarioParametro : EntidadComun, IEntidadComun, IFormularioInsert
    {
        public int idUsuario { get; set; }
        public ComParametro parametro = new ComParametro();
        public string validacion { get; set; }
        public int estatus { get; set; }

        public ComUsuarioParametro()
        {
            
        }

        public ComUsuarioParametro(int IdUsuario, int IdParametro, string Validacion, int Estatus)
        {
            this.idUsuario = IdUsuario;
            this.validacion = Validacion;
            this.estatus = Estatus;
            this.parametro = new ComParametro(IdParametro);
        }

        public void LlenadoDataForm(NpgsqlCommand ComandoSQL)
        {
            ComandoSQL.Parameters.Add(new NpgsqlParameter("UsuarioId", this.idUsuario));
            ComandoSQL.Parameters.Add(new NpgsqlParameter("ParametroId", this.parametro.idParametro));
            ComandoSQL.Parameters.Add(new NpgsqlParameter("Validacion", this.validacion));
            ComandoSQL.Parameters.Add(new NpgsqlParameter("Estatus", this.estatus));
        }

        public void LlenadoDataNpgsql(NpgsqlDataReader Data)
        {
            this.idUsuario = Data.GetInt32(0 + offset);
            this.validacion = Data.GetString(2 + offset);
            this.estatus = Data.GetInt32(3 + offset);
            this.parametro.offset = 4;
            this.parametro.LlenadoDataNpgsql(Data);
        }
    }
}

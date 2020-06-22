using Npgsql;
using System;

namespace Comunes.Comun
{
    public class ComCuenta : EntidadComun, IEntidadComun, IFormularioInsert
    {

        private ComTipoCuenta _tipoCuenta = new ComTipoCuenta();
        private ComBanco _banco = new ComBanco();
        private int _idCuenta { get; set; }
        private int _idUsuario { get; set; }
        private string _numero { get; set; }

        public ComCuenta()
        {

        }

        public ComCuenta(ComTipoCuenta tipoCuenta, ComBanco banco, int idUsuario, string numero)
        {
            this._tipoCuenta = tipoCuenta;
            this._banco = banco;
            this._idUsuario = idUsuario;
            this._numero = numero;
        }

        public void LlenadoDataForm(NpgsqlCommand ComandoSQL)
        {
            ComandoSQL.Parameters.Add(new NpgsqlParameter("UsuarioId", this._idUsuario));
            ComandoSQL.Parameters.Add(new NpgsqlParameter("TipoCuentaId", this._tipoCuenta._idTipoCuenta));
            ComandoSQL.Parameters.Add(new NpgsqlParameter("BancoId", this._banco._idBanco));
            ComandoSQL.Parameters.Add(new NpgsqlParameter("Numero", this._numero));
        }

        public void LlenadoDataNpgsql(NpgsqlDataReader data)
        {
            this._tipoCuenta._offset = 8;
            this._tipoCuenta.LlenadoDataNpgsql(data);
            this._banco._offset = 5;
            this._banco.LlenadoDataNpgsql(data);
            this._idCuenta = data.GetInt32(0);
            this._idUsuario = data.GetInt32(1);
            this._numero = data.GetString(4);
        }
    }
}

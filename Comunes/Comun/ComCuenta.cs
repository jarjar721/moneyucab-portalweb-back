using Npgsql;
using System;

namespace Comunes.Comun
{
    public class ComCuenta : EntidadComun, IEntidadComun, IFormularioInsert
    {

        public ComTipoCuenta _tipoCuenta = new ComTipoCuenta();
        public ComBanco _banco = new ComBanco();
        public int _idCuenta { get; set; }
        public int _idUsuario { get; set; }
        public string _numero { get; set; }

        public ComCuenta()
        {

        }

        public ComCuenta(ComTipoCuenta TipoCuenta, ComBanco Banco, int IdUsuario, string Numero)
        {
            this._tipoCuenta = TipoCuenta;
            this._banco = Banco;
            this._idUsuario = IdUsuario;
            this._numero = Numero;
        }

        public void LlenadoDataForm(NpgsqlCommand ComandoSQL)
        {
            ComandoSQL.Parameters.Add(new NpgsqlParameter("UsuarioId", this._idUsuario));
            ComandoSQL.Parameters.Add(new NpgsqlParameter("TipoCuentaId", this._tipoCuenta.idTipoCuenta));
            ComandoSQL.Parameters.Add(new NpgsqlParameter("BancoId", this._banco.idBanco));
            ComandoSQL.Parameters.Add(new NpgsqlParameter("Numero", this._numero));
        }

        public void LlenadoDataNpgsql(NpgsqlDataReader Data)
        {
            this._tipoCuenta.offset = 8;
            this._tipoCuenta.LlenadoDataNpgsql(Data);
            this._banco.offset = 5;
            this._banco.LlenadoDataNpgsql(Data);
            this._idCuenta = Data.GetInt32(0);
            this._idUsuario = Data.GetInt32(1);
            this._numero = Data.GetString(4);
        }
    }
}

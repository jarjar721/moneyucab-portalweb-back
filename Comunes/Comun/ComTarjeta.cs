using Npgsql;
using NpgsqlTypes;
using System;

namespace Comunes.Comun
{
    public class ComTarjeta : EntidadComun, IEntidadComun, IFormularioInsert
    {

        public ComTipoTarjeta tipoTarjeta = new ComTipoTarjeta();
        public ComBanco banco = new ComBanco();
        public int idTarjeta { get; set; }
        public int idUsuario { get; set; }
        public int numero { get; set; }
        public NpgsqlDate fechaVencimiento { get; set; }
        public int cvc { get; set; }
        public int estatus { get; set; }

        public ComTarjeta()
        {

        }

        public ComTarjeta(ComTipoTarjeta Tipotarjeta, ComBanco Banco, int IdUsuario, int Numero, NpgsqlDate FechaVencimiento, int Cvc, int Estatus)
        {
            this.tipoTarjeta = Tipotarjeta;
            this.banco = Banco;
            this.idUsuario = IdUsuario;
            this.numero = Numero;
            this.fechaVencimiento = FechaVencimiento;
            this.cvc = Cvc;
            this.estatus = Estatus;
        }

        public void LlenadoDataForm(NpgsqlCommand ComandoSQL)
        {
            ComandoSQL.Parameters.Add(new NpgsqlParameter("UsuarioId", this.idUsuario));
            ComandoSQL.Parameters.Add(new NpgsqlParameter("TipoTarjetaId", this.tipoTarjeta.idTipoTarjeta));
            ComandoSQL.Parameters.Add(new NpgsqlParameter("BancoId", this.banco.idBanco));
            ComandoSQL.Parameters.Add(new NpgsqlParameter("Numero", this.numero));
            ComandoSQL.Parameters.Add(new NpgsqlParameter("FechaVencimiento", this.fechaVencimiento));
            ComandoSQL.Parameters.Add(new NpgsqlParameter("cvc", this.cvc));
            ComandoSQL.Parameters.Add(new NpgsqlParameter("Estatus", this.estatus));
        }

        public void LlenadoDataNpgsql(NpgsqlDataReader Data)
        {
            this.tipoTarjeta.offset = 11;
            this.tipoTarjeta.LlenadoDataNpgsql(Data);
            this.banco.offset = 8;
            this.banco.LlenadoDataNpgsql(Data);
            this.idTarjeta = Data.GetInt32(0 + offset);
            this.idUsuario = Data.GetInt32(1 + offset);
            this.numero = Data.GetInt32(4 + offset);
            this.fechaVencimiento = Data.GetDate(5);
            this.cvc = Data.GetInt32(6 + offset);
            this.estatus = Data.GetInt32(7 + offset);
        }
    }
}

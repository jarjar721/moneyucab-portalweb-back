using Npgsql;
using System;

namespace Comunes.Comun
{
    public class ComTipoCuenta : EntidadComun, IEntidadComun
    {
        public int idTipoCuenta { get; set; }
        public string descripcion { get; set; }
        public int estatus { get; set; }

        public ComTipoCuenta()
        {

        }

        public ComTipoCuenta(int IdTipoCuenta)
        {
            this.idTipoCuenta = IdTipoCuenta;
        }

        public void LlenadoDataNpgsql(NpgsqlDataReader Data)
        {
            this.idTipoCuenta = Data.GetInt32(0 + offset);
            this.descripcion = Data.GetString(1 + offset);
            this.estatus = Data.GetInt32(2 + offset);
        }
    }
}

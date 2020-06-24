using Npgsql;
using NpgsqlTypes;
using System;

namespace Comunes.Comun
{
    public class ComOperacionTarjeta : EntidadComun, IEntidadComun
    {
        public int idOperacionTarjeta { get; set; }
        public int idUsuarioReceptor { get; set; }
        public int idTarjeta { get; set; }
        public NpgsqlDate fecha { get; set; }
        //private Npgsql _hora{ get; set; }
        public double monto { get; set; }
        public string referencia { get; set; }

        public ComOperacionTarjeta()
        {

        }

        public void LlenadoDataNpgsql(NpgsqlDataReader Data)
        {
            this.idOperacionTarjeta = Data.GetInt32(0 + offset);
            this.idUsuarioReceptor = Data.GetInt32(1 + offset);
            this.idTarjeta = Data.GetInt32(2 + offset);
            this.fecha = Data.GetDate(3 + offset);
            //this._hora = data.GetDateTime(4 + _offset);
            this.monto = Data.GetDouble(5 + offset);
            this.referencia = Data.GetString(6 + offset);
        }
    }
}

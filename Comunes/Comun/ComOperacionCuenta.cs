using Npgsql;
using NpgsqlTypes;
using System;

namespace Comunes.Comun
{
    public class ComOperacionCuenta : EntidadComun, IEntidadComun
    {
        public int idOperacionCuenta { get; set; }
        public int idUsuarioReceptor { get; set; }
        public int idCuenta { get; set; }
        public NpgsqlDate fecha { get; set; }
        //private string _hora{ get; set; }
        public double monto { get; set; }
        public string referencia { get; set; }

        public ComOperacionCuenta()
        {

        }

        public void LlenadoDataNpgsql(NpgsqlDataReader Data)
        {
            this.idOperacionCuenta = Data.GetInt32(0 + offset);
            this.idUsuarioReceptor = Data.GetInt32(1 + offset);
            this.idCuenta = Data.GetInt32(2 + offset);
            this.fecha = Data.GetDate(3 + offset);
            //this._hora = data.GetString(4 + _offset);
            this.monto = Data.GetDouble(5 + offset);
            this.referencia = Data.GetString(6 + offset);
        }
    }
}
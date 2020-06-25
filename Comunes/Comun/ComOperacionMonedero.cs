using Npgsql;
using NpgsqlTypes;
using System;

namespace Comunes.Comun
{
    public class ComOperacionMonedero : EntidadComun, IEntidadComun
    {
        public ComTipoOperacion tipoOperacion = new ComTipoOperacion();
        public ComOperacionTarjeta operacionTarjeta = new ComOperacionTarjeta();
        public ComOperacionCuenta operacionCuenta = new ComOperacionCuenta();
        public int idOperacionMonedero { get; set; }
        public int idUsuario { get; set; }
        public double monto { get; set; }
        public NpgsqlDate fecha { get; set; }
        //private NpgsqlDateTime _hora{ get; set; }
        public string referencia { get; set; }

        public ComOperacionMonedero()
        {
            
        }

        public void LlenadoDataNpgsql(NpgsqlDataReader Data)
        {
            try
            {
                this.operacionTarjeta.offset = 10;
                this.operacionTarjeta.LlenadoDataNpgsql(Data);
            }
            catch (InvalidCastException)
            {
                this.operacionTarjeta = null;
            }
            try
            {
                this.operacionCuenta.offset = 17;
                this.operacionCuenta.LlenadoDataNpgsql(Data);
            }
            catch (InvalidCastException)
            {
                this.operacionCuenta = null;
            }
            this.idOperacionMonedero = Data.GetInt32(0 + offset);
            this.idUsuario = Data.GetInt32(1 + offset);
            this.fecha = Data.GetDate(4 + offset);
            //this._hora = data.GetDateTime(5 + _offset);
            this.monto = Data.GetDouble(3 + offset);
            this.referencia = Data.GetString(6 + offset);
            this.tipoOperacion.offset = 7;
            this.tipoOperacion.LlenadoDataNpgsql(Data);
        }

        public void LlenadoDataCierreNpgsql(NpgsqlDataReader Data)
        {
            this.idOperacionMonedero = Data.GetInt32(0 + offset);
            this.idUsuario = Data.GetInt32(1 + offset);
            this.fecha = Data.GetDate(4 + offset);
            //this._hora = data.GetDateTime(5 + _offset);
            this.monto = Data.GetDouble(3 + offset);
            this.referencia = Data.GetString(6 + offset);
            this.tipoOperacion.offset = 7;
            this.tipoOperacion.LlenadoDataNpgsql(Data);
        }
    }
}

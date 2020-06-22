using Npgsql;
using NpgsqlTypes;
using System;

namespace Comunes.Comun
{
    public class ComOperacionMonedero : EntidadComun, IEntidadComun
    {
        private ComTipoOperacion _TipoOperacion = new ComTipoOperacion();
        private ComOperacionTarjeta _OperacionTarjeta = new ComOperacionTarjeta();
        private ComOperacionCuenta _OperacionCuenta = new ComOperacionCuenta();
        private int _idOperacionMonedero { get; set; }
        private int _idUsuario { get; set; }
        private double _monto { get; set; }
        private NpgsqlDate _fecha { get; set; }
        //private NpgsqlDateTime _hora{ get; set; }
        private string _referencia { get; set; }

        public ComOperacionMonedero()
        {
            
        }

        public void LlenadoDataNpgsql(NpgsqlDataReader data)
        {
            this._TipoOperacion._offset = 7;
            this._TipoOperacion.LlenadoDataNpgsql(data);
            try
            {
                this._OperacionTarjeta._offset = 10;
                this._OperacionTarjeta.LlenadoDataNpgsql(data);
            }
            catch (InvalidCastException)
            {
                this._OperacionTarjeta = null;
            }
            try
            {
                this._OperacionCuenta._offset = 17;
                this._OperacionCuenta.LlenadoDataNpgsql(data);
            }
            catch (InvalidCastException)
            {
                this._OperacionCuenta = null;
            }
            this._idOperacionMonedero = data.GetInt32(0 + _offset);
            this._idUsuario = data.GetInt32(1 + _offset);
            this._fecha = data.GetDate(4 + _offset);
            //this._hora = data.GetDateTime(5 + _offset);
            this._monto = data.GetDouble(3 + _offset);
            this._referencia = data.GetString(6 + _offset);
        }
    }
}

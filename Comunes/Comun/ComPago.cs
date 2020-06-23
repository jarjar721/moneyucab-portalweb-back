using Npgsql;
using NpgsqlTypes;
using System;

namespace Comunes.Comun
{
    public class ComPago : EntidadComun, IEntidadComun
    {
        public int _idPago { get; set; }
        public int _idUsuarioSolicitante { get; set; }
        public int _idUsuarioReceptor { get; set; }
        public NpgsqlDate _fecha { get; set; }
        public string _monto { get; set; }
        public string _estatus { get; set; }
        public string _referencia { get; set; }

        public ComPago()
        {

        }

        public void LlenadoDataNpgsql(NpgsqlDataReader data)
        {
            this._idPago = data.GetInt32(0 + _offset);
            this._idUsuarioSolicitante = data.GetInt32(1 + _offset);
            this._idUsuarioReceptor = data.GetInt32(2 + _offset);
            this._fecha = data.GetDate(3 + _offset);
            this._monto = data.GetString(4 + _offset);
            this._estatus = data.GetString(5 + _offset);
            try
            {
                this._referencia = data.GetString(6 + _offset);
            }
            catch (InvalidCastException)
            {
                this._referencia = null;
            }
        }
    }
}

using Npgsql;
using NpgsqlTypes;
using System;

namespace Comunes.Comun
{
    public class ComReintegro : EntidadComun, IEntidadComun
    {
        private int _idReintegro { get; set; }
        private int _idUsuarioSolicitante { get; set; }
        private int _idUsuarioReceptor { get; set; }
        private NpgsqlDate _fecha { get; set; }
        private string _referencia_reintegro { get; set; }
        private string _referencia { get; set; }
        private string _estatus { get; set; }

        public ComReintegro()
        {

        }

        public void LlenadoDataNpgsql(NpgsqlDataReader data)
        {
            this._idReintegro = data.GetInt32(0 + _offset);
            this._idUsuarioSolicitante = data.GetInt32(1 + _offset);
            this._idUsuarioReceptor = data.GetInt32(2 + _offset);
            this._fecha = data.GetDate(3 + _offset);
            this._referencia_reintegro = data.GetString(4 + _offset);
            try
            {
                this._referencia = data.GetString(5 + _offset);
            }
            catch (InvalidCastException)
            {
                this._referencia = null;
            }
            this._estatus = data.GetString(6 + _offset);
        }
    }
}

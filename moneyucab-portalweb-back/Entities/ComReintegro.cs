using Npgsql;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace moneyucab_portalweb_back.Entities
{
    public class ComReintegro : EntidadComun, IEntidadComun
    {
        private int _idReintegro;
        private int _idUsuarioSolicitante;
        private int _idUsuarioReceptor;
        private string _fecha;
        private string _referencia_reintegro;
        private string _referencia;
        private string _estatus;

        public void LlenadoDataNpgsql(NpgsqlDataReader data)
        {
            this._idReintegro = Int32.Parse(data.GetString(0 + _offset));
            this._idUsuarioSolicitante = Int32.Parse(data.GetString(1 + _offset));
            this._idUsuarioReceptor = Int32.Parse(data.GetString(2 + _offset));
            this._fecha = data.GetString(3 + _offset);
            this._referencia_reintegro = data.GetString(4 + _offset);
            this._referencia = data.GetString(5 + _offset);
            this._estatus = data.GetString(6 + _offset);
        }
    }
}

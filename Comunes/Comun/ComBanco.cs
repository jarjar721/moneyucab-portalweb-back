using Npgsql;
using System;

namespace Comunes.Comun
{
    public class ComBanco : EntidadComun, IEntidadComun
    {
        public int _idBanco { get; set; }
        public string _nombre { get; set; }
        public int _estatus { get; set; }

        public ComBanco()
        {

        }

        public ComBanco(int idBanco)
        {
            this._idBanco = idBanco;
        }

        public int IdBanco
        {
            get { return _idBanco; }
            set { _idBanco = value; }
        }

        public string Nombre
        {
            get { return _nombre; }
            set { _nombre = value; }
        }

        public int Estatus
        {
            get { return _estatus; }
            set { _estatus = value; }
        }

        public void LlenadoDataNpgsql(NpgsqlDataReader data)
        {
            this._idBanco = data.GetInt32(0 + _offset);
            this._nombre = data.GetString(1 + _offset);
            this._estatus = data.GetInt32(2 + _offset);
        }
    }
}

using Npgsql;
using NpgsqlTypes;

namespace Comunes.Comun
{
    public class ComPersona : EntidadComun, IEntidadComun
    {
        private ComEstadoCivil _EstadoCivil = new ComEstadoCivil();
        private string _nombre;
        private string _apellido;
        private NpgsqlDate _fecha_nacimiento;


        public void LlenadoDataNpgsql(NpgsqlDataReader data)
        {
            this._nombre = data.GetString(0 + _offset);
            this._apellido = data.GetString(1 + _offset);
            this._fecha_nacimiento = data.GetDate(2 + _offset);
            this._EstadoCivil._offset = 24;
            this._EstadoCivil.LlenadoDataNpgsql(data);
        }
    }
}

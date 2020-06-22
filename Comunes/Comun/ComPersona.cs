using Excepciones;
using Npgsql;
using NpgsqlTypes;

namespace Comunes.Comun
{
    public class ComPersona : EntidadComun, IEntidadComun, IFormularioRegistro
    {
        private ComEstadoCivil _EstadoCivil = new ComEstadoCivil();
        private string _nombre { get; set; }
        private string _apellido { get; set; }
        private NpgsqlDate _fecha_nacimiento { get; set; }

        public ComPersona()
        {

        }

        public ComPersona(ComEstadoCivil estadoCivil, string nombre, string apellido, NpgsqlDate fecha_Nacimiento)
        {
            this._EstadoCivil = estadoCivil;
            this._nombre = nombre;
            this._apellido = apellido;
            this._fecha_nacimiento = fecha_Nacimiento;
        }

        public void LlenadoDataFormComercio(NpgsqlCommand ComandoSQL)
        {
            throw new MoneyUcabException(null, "Llenado de información inválido", 100);
        }

        public void LlenadoDataFormPersona(NpgsqlCommand ComandoSQL)
        {
            ComandoSQL.Parameters.Add(new NpgsqlParameter("Nombre", this._nombre));
            ComandoSQL.Parameters.Add(new NpgsqlParameter("Apellido", this._apellido));
            ComandoSQL.Parameters.Add(new NpgsqlParameter("FechaNacimiento", this._fecha_nacimiento));
            ComandoSQL.Parameters.Add(new NpgsqlParameter("IdEstadoCivil", this._EstadoCivil._idEstadoCivil));
            ComandoSQL.Parameters.Add(new NpgsqlParameter("RazonSocial", ""));
        }

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

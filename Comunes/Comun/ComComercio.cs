using Excepciones;
using Npgsql;

namespace Comunes.Comun
{
    public class ComComercio : EntidadComun, IEntidadComun, IFormularioRegistro
    {
        private string _razon_social { get; set; }
        private string _nombre_representante { get; set; }
        private string _apellido_representante { get; set; }

        public ComComercio()
        {

        }

        public ComComercio(string razonSocial, string nombreRepresentante, string apellidoRepresentante)
        {
            this._razon_social = razonSocial;
            this._nombre_representante = nombreRepresentante;
            this._apellido_representante = apellidoRepresentante;
        }

        public void LlenadoDataFormComercio(NpgsqlCommand ComandoSQL)
        {
            ComandoSQL.Parameters.Add(new NpgsqlParameter("RazonSocial", this._razon_social));
            ComandoSQL.Parameters.Add(new NpgsqlParameter("Nombre", this._nombre_representante));
            ComandoSQL.Parameters.Add(new NpgsqlParameter("Apellido", this._apellido_representante));
            ComandoSQL.Parameters.Add(new NpgsqlParameter("FechaNacimiento", new NpgsqlTypes.NpgsqlDate(2020, 5, 30)));
            ComandoSQL.Parameters.Add(new NpgsqlParameter("IdEstadoCivil", 1));
        }

        public void LlenadoDataFormPersona(NpgsqlCommand ComandoSQL)
        {
            throw new MoneyUcabException(null, "Llenado de información inválido", 100);
        }

        public void LlenadoDataNpgsql(NpgsqlDataReader data)
        {
            this._razon_social = data.GetString(0 + _offset);
            this._nombre_representante = data.GetString(1 + _offset);
            this._apellido_representante = data.GetString(2 + _offset);
        }
    }
}

using Excepciones;
using Npgsql;

namespace Comunes.Comun
{
    public class ComComercio : EntidadComun, IEntidadComun, IFormularioRegistro
    {
        public string razonSocial { get; set; }
        public string nombreRepresentante { get; set; }
        public string apellidoRepresentante { get; set; }

        public ComComercio()
        {

        }

        public ComComercio(string RazonSocial, string NombreRepresentante, string ApellidoRepresentante)
        {
            this.razonSocial = RazonSocial;
            this.nombreRepresentante = NombreRepresentante;
            this.apellidoRepresentante = ApellidoRepresentante;
        }

        public void LlenadoDataFormComercio(NpgsqlCommand ComandoSQL)
        {
            ComandoSQL.Parameters.Add(new NpgsqlParameter("RazonSocial", this.razonSocial));
            ComandoSQL.Parameters.Add(new NpgsqlParameter("Nombre", this.nombreRepresentante));
            ComandoSQL.Parameters.Add(new NpgsqlParameter("Apellido", this.apellidoRepresentante));
            ComandoSQL.Parameters.Add(new NpgsqlParameter("FechaNacimiento", new NpgsqlTypes.NpgsqlDate(2020, 5, 30)));
            ComandoSQL.Parameters.Add(new NpgsqlParameter("IdEstadoCivil", 1));
        }

        public void LlenadoDataFormComercioReg(NpgsqlCommand ComandoSQL)
        {
            ComandoSQL.Parameters.Add(new NpgsqlParameter("RazonSocial", this.razonSocial));
            ComandoSQL.Parameters.Add(new NpgsqlParameter("Nombre", this.nombreRepresentante));
            ComandoSQL.Parameters.Add(new NpgsqlParameter("Apellido", this.apellidoRepresentante));
        }

        public void LlenadoDataFormPersona(NpgsqlCommand ComandoSQL)
        {
            throw new MoneyUcabException(null, "Llenado de información inválido", 100);
        }

        public void LlenadoDataNpgsql(NpgsqlDataReader Data)
        {
            this.razonSocial = Data.GetString(0 + offset);
            this.nombreRepresentante = Data.GetString(1 + offset);
            this.apellidoRepresentante = Data.GetString(2 + offset);
        }
    }
}

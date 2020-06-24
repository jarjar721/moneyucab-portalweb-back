using Excepciones;
using Npgsql;
using NpgsqlTypes;

namespace Comunes.Comun
{
    public class ComPersona : EntidadComun, IEntidadComun, IFormularioRegistro
    {
        public ComEstadoCivil estadoCivil = new ComEstadoCivil();
        public string nombre { get; set; }
        public string apellido { get; set; }
        public NpgsqlDate fechaNacimiento { get; set; }

        public ComPersona()
        {

        }

        public ComPersona(ComEstadoCivil EstadoCivil, string Nombre, string Apellido, NpgsqlDate FechaNacimiento)
        {
            this.estadoCivil = EstadoCivil;
            this.nombre = Nombre;
            this.apellido = Apellido;
            this.fechaNacimiento = FechaNacimiento;
        }

        public void LlenadoDataFormComercio(NpgsqlCommand ComandoSQL)
        {
            throw new MoneyUcabException(null, "Llenado de información inválido", 100);
        }

        public void LlenadoDataFormPersona(NpgsqlCommand ComandoSQL)
        {
            ComandoSQL.Parameters.Add(new NpgsqlParameter("Nombre", this.nombre));
            ComandoSQL.Parameters.Add(new NpgsqlParameter("Apellido", this.apellido));
            ComandoSQL.Parameters.Add(new NpgsqlParameter("FechaNacimiento", this.fechaNacimiento));
            ComandoSQL.Parameters.Add(new NpgsqlParameter("IdEstadoCivil", this.estadoCivil.idEstadoCivil));
            ComandoSQL.Parameters.Add(new NpgsqlParameter("RazonSocial", ""));
        }

        public void LlenadoDataNpgsql(NpgsqlDataReader Data)
        {
            this.nombre = Data.GetString(0 + offset);
            this.apellido = Data.GetString(1 + offset);
            this.fechaNacimiento = Data.GetDate(2 + offset);
            this.estadoCivil.offset = 24;
            this.estadoCivil.LlenadoDataNpgsql(Data);
        }
    }
}
